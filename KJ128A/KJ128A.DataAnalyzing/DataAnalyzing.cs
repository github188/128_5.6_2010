using System;
using System.Collections;
using System.Text;
using System.Data;
using KJ128A.Controls.Batman;

namespace KJ128A.DataAnalyzing
{
    public class DataAnalyzing
    {
        #region [ 方法: 数据分析 ]

        public MemDataAnalyz Analyzing(byte[] cmdInfo, int stationModel)
        {
            if (cmdInfo == null)
            {
                return new MemDataAnalyz();
            }
            
            // 解析有效指令
            int iSAddress = cmdInfo[0];     // 基站号
            int iCmdNO = cmdInfo[1];        // 命令号
            MemDataAnalyz memDataAnalyz = new MemDataAnalyz();
            switch (stationModel)
            {
                case 1:
                case 3:
                    #region 【KJ128A解析】
                    int iMark = cmdInfo[2];         // 主备标志
                    memDataAnalyz.IsEnable = true;

                    memDataAnalyz.StationAddress = iSAddress;
                    memDataAnalyz.Mark = iMark;

                    switch (iCmdNO)
                    {
                        case 22:    // 查询版本
                            memDataAnalyz.StationVer = cmdInfo[6] + cmdInfo[7] * 256;       // 提取版本号
                            memDataAnalyz.enumAnalyzing = EnumDataType.Ver;
                            memDataAnalyz.CmdLength = 3;
                            return memDataAnalyz;

                        case 23:    // 校时
                            memDataAnalyz.enumAnalyzing = EnumDataType.SyncDate;
                            return memDataAnalyz;

                        case 20:    // 巡检
                            memDataAnalyz.enumAnalyzing = EnumDataType.Polling;
                            return AnalysisPolling_20071210_1(cmdInfo, memDataAnalyz);

                        case 21:    // 数据确认
                            memDataAnalyz.enumAnalyzing = EnumDataType.PollingRight;
                            return memDataAnalyz;

                        default:
                            memDataAnalyz.IsEnable = false;
                            return memDataAnalyz;
                    }
                    #endregion
                default:
                    #region [KJ128V2解析]
                    memDataAnalyz.IsEnable = false;

                    memDataAnalyz.StationAddress = iSAddress;

                    switch (iCmdNO)
                    {
                        case 23:    // 校时
                            memDataAnalyz.enumAnalyzing = EnumDataType.SyncDate;
                            return memDataAnalyz;

                        case 20:    // 巡检
                            memDataAnalyz.enumAnalyzing = EnumDataType.Polling;
                            return AnalysisPolling_20060610_1(cmdInfo, memDataAnalyz);

                        case 21:    // 数据确认
                            memDataAnalyz.enumAnalyzing = EnumDataType.PollingRight;
                            return memDataAnalyz;

                        default:
                            memDataAnalyz.IsEnable = false;
                            return memDataAnalyz;
                    }
                    #endregion
            }
        }

        #endregion

        #region [ 方法: 使用 2007-12-10 第 1 版协议解析数据 ]

        /// <summary>
        /// 使用 2007-12-10 第 1 版协议解析数据
        /// </summary>
        private static MemDataAnalyz AnalysisPolling_20071210_1(byte[] cmdRight, MemDataAnalyz memDataAnalyz)
        {   
            int iCmdLength = cmdRight[3] + cmdRight[4] * 256; // 命令长度

            memDataAnalyz.IsEnable = true;
            memDataAnalyz.CmdLength = iCmdLength;

            int iCmdLoc = 5;
            ArrayList arrayList = new ArrayList();

            while (iCmdLoc < iCmdLength + 5)
            {
                MemHead memHead = new MemHead();

                #region [ 检测探头数据时间和状态 ]

                memHead.IsBreak = false;                // 探头是否故障

                int iSHead = cmdRight[iCmdLoc];         // 探头号
                int iSecond = cmdRight[iCmdLoc + 4];    // 秒，其中最高位 1 时表示探头故障
                memHead.HeadAddress = iSHead;

                DateTime dtTime = DateTime.Now;

                int iPerCount = 0;
                int iPerLength = 0;

                //Czlt-2011-11-17--交直流供电
                if (iSHead == 7)
                {
                    //if (iSecond >= 128)
                    //    iSecond = iSecond - 128;

                    if (cmdRight[iCmdLoc + 1] != 0)
                    {
                        // 接收到数据的时间
                        dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                            cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);

                        memHead.Time = dtTime;
                    }

                    iPerCount = cmdRight[iCmdLoc + 5];              // 人数
                    iPerLength = cmdRight[iCmdLoc + 5] * 2;         // 长度
                    memHead.CodeCount = iPerCount;                  // 探头检测到的人数
                }
                else
                {
                    if (iSecond >= 128)
                    {
                        // 秒最高位为 1 时探头故障
                        iSecond = iSecond - 128;

                        if (cmdRight[iCmdLoc + 1] != 0)
                        {
                            // 接收到数据的时间
                            dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                                cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);

                            memHead.Time = dtTime;
                        }

                        memHead.IsBreak = true;         // 该探头故障
                    }
                    else
                    {
                        if (cmdRight[iCmdLoc + 1] != 0)
                        {
                            dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                                cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);
                            memHead.Time = dtTime;

                        }

                        iPerCount = cmdRight[iCmdLoc + 5];              // 人数
                        iPerLength = cmdRight[iCmdLoc + 5] * 2;         // 长度
                        memHead.CodeCount = iPerCount;                  // 探头检测到的人数
                    }

                }
                #endregion

                #region [ 探头接收到的卡号 ]

                StringBuilder sbHeadA = new StringBuilder();    // 探头 A 接收到的发码器
                StringBuilder sbHeadB = new StringBuilder();    // 探头 B 接收到的发码器
                StringBuilder sbHeadC = new StringBuilder();    // 探头 接收到全为 0 的发码器   出
                StringBuilder sbHeadD = new StringBuilder();    // 探头 接收到全为 1 的发码器   求救
                StringBuilder sbHeadE = new StringBuilder();    // 低电量   探头 A 接收到的发码器
                StringBuilder sbHeadF = new StringBuilder();    // 低电量   探头 B 接收到的发码器
                StringBuilder sbHeadG = new StringBuilder();    // 低电量   探头 接收到全为 0 的发码器   出
                StringBuilder sbHeadH = new StringBuilder();    // 低电量   探头 接收到全为 1 的发码器   求救

                //Czlt-2011-11-17-添加交直流的判断
                StringBuilder dyHead = new StringBuilder();

                int i;
                for (i = iCmdLoc + 6; i < iCmdLoc + 6 + iPerLength; i += 2)
                {
                    int iCard = cmdRight[i] + cmdRight[i + 1] * 256;

                    #region 【Czlt-2011-11-17 交直流供电】
                    //Czlt -2011-11-17 -交直流供电
                    if (iCard == 24486) //交流
                    {
                        dyHead.Append("3.");
                    }
                    else if (iCard == 24487) //直流
                    {
                        dyHead.Append("2.");
                    }

                    #endregion
                    if (iCard > 49152)//求救
                    {
                        iCard = iCard - 49152;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadH.Append(iCard + ",");
                        }
                        else
                        {
                            sbHeadD.Append(iCard + ",");
                        }
                    }
                    else if (iCard >= 32768)//A天线
                    {
                        iCard = iCard - 32768;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadE.Append(iCard + ",");
                        }
                        else
                        {
                            sbHeadA.Append(iCard + ",");
                        }
                    }
                    else if (iCard >= 16384)//B天线
                    {
                        iCard = iCard - 16384;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadF.Append(iCard + ",");
                        }
                        else
                        {
                            sbHeadB.Append(iCard + ",");
                        }
                    }
                    else//出
                    {
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadG.Append(iCard + ",");
                        }
                        else
                        {
                            sbHeadC.Append(iCard + ",");
                        }
                    }
                }

                memHead.CodesA = sbHeadA.ToString();
                memHead.CodesB = sbHeadB.ToString();
                memHead.CodesC = sbHeadC.ToString();
                memHead.CodesD = sbHeadD.ToString();
                memHead.CodesE = sbHeadE.ToString();
                memHead.CodesF = sbHeadF.ToString();
                memHead.CodesG = sbHeadG.ToString();
                memHead.CodesH = sbHeadH.ToString();

                //Czlt-2011-11-17 交直流电源
                memHead.CodesDY = dyHead.ToString();

                if (memHead.IsBreak)
                {
                    iCmdLoc = i - 1;
                }
                else
                {
                    iCmdLoc = i;
                }

                // 显示探头出检测出多少张卡
                if (iPerCount > 0)
                {
//                    RTxtMsgc.WriteTxt(strMsg.ToString(), " RX", true);
                    //return strMsg.ToString();
                }

                #endregion

                arrayList.Add(memHead);

                #region [ 检测标记位是否存在 ]

                if (cmdRight[iCmdLoc++] != 255)
                {
                    break;
                }

                #endregion
            }

            // 初始化探头
            memDataAnalyz.memHead= new MemHead[arrayList.Count];
            
            // 循环添加探头
            for (int i = 0; i < arrayList.Count;i++ )
            {
                memDataAnalyz.memHead[i] = (MemHead)arrayList[i];
            }

            return memDataAnalyz;
        }

        #endregion

        #region [ 方法: 使用 2006-6-10 第 1 版协议解析数据 ]

        /// <summary>
        /// 使用 2007-12-10 第 1 版协议解析数据
        /// </summary>
        private static MemDataAnalyz AnalysisPolling_20060610_1(byte[] cmdRight, MemDataAnalyz memDataAnalyz)
        {
            int iCmdLength = cmdRight[2] + cmdRight[3] * 256; // 命令长度

            memDataAnalyz.IsEnable = true;
            memDataAnalyz.CmdLength = iCmdLength;

            ArrayList arrayList = new ArrayList();

            // 人数
            int iPerCount = cmdRight[4] + cmdRight[5] * 256;
            //获取数据的时间
            DateTime dtTime = BuildDateTime(cmdRight[6], cmdRight[7], cmdRight[8]);
            
            MemHead memHead = new MemHead();
            memHead.Time = dtTime;
            memHead.CodeCount = iPerCount;                  // 探头检测到的人数
            memHead.HeadAddress = 0;
            memHead.IsBreak = true;

            #region [ 分站接收到的卡号 ]
            StringBuilder sbHeadA = new StringBuilder();    // 分站 接收到最高位为 1 的发码器  出分站
            StringBuilder sbHeadC = new StringBuilder();    // 分站 第一位和第二位为0 的发码器  进分站
            StringBuilder sbHeadD = new StringBuilder();    // 分站 接收到全为 1 的发码器   即求救
            StringBuilder sbHeadE = new StringBuilder();    // 低电量  分站 接收到最高位为 1 的发码器   出分站
            StringBuilder sbHeadG = new StringBuilder();    // 低电量  分站 第一位和第二位为0 的发码器  进分站
            StringBuilder sbHeadH = new StringBuilder();    // 低电量  分站 接收到全为 1 的发码器   即求救
            for (int i = 0; i < iPerCount; i++)
            {
                int iCard;
                iCard = (int)cmdRight[9 + 2 * i] + (int)cmdRight[10 + 2 * i] * 256;
                if (iCard != 29998 && iCard != 62766 && iCard !=29999)
                {
                    if (iCard > 49152)//求救
                    {
                        iCard = iCard - 49152;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadH.Append(iCard + ",");
                        }
                        sbHeadD.Append(iCard + ",");
                    }
                    else if (iCard >= 32768)//出分站
                    {
                        iCard = iCard - 32768;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadE.Append(iCard + ",");
                        }
                        sbHeadA.Append(iCard + ",");
                    }
                    else if (iCard >= 16384)//B天线
                    {
                        //iCard = iCard - 16384;
                        //if (iCard > 8192)
                        //{
                        //    iCard = iCard - 8192;
                        //    sbHeadF.Append(iCard + ",");
                        //}
                        //sbHeadB.Append(iCard + ",");
                    }
                    else//进分站
                    {
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadG.Append(iCard + ",");
                        }
                        sbHeadC.Append(iCard + ",");
                    }
                }
            }

            #endregion

            memHead.CodesA = sbHeadA.ToString();
            memHead.CodesC = sbHeadC.ToString();
            memHead.CodesD = sbHeadD.ToString();
            memHead.CodesE = sbHeadE.ToString();
            memHead.CodesG = sbHeadG.ToString();
            memHead.CodesH = sbHeadH.ToString();

            arrayList.Add(memHead);

            // 初始化探头
            memDataAnalyz.memHead = new MemHead[arrayList.Count];

            // 循环添加探头
            for (int i = 0; i < arrayList.Count; i++)
            {
                memDataAnalyz.memHead[i] = (MemHead)arrayList[i];
            }

            return memDataAnalyz;
        }

        #endregion

        #region [ 方法: BuildDateTime 根据接收到的时间，构造新的时间 ]

        /// <summary>
        /// 构造时间
        /// </summary>
        /// <param name="Day"></param>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        /// <returns></returns>
        public static DateTime BuildDateTime(int Day, int Hour, int Minute, int Second)
        {
            DateTime dtTime = DateTime.Now;

            try
            {
                // 时间不合法，则返回系统最小时间
                if (Day >= 32 || Hour >= 24 || Minute >= 60 || Second >= 60)
                {
                    return new DateTime(2000, 1, 1, 0, 0, 1);
                }

                int int_Year = dtTime.Year;
                int int_Month = dtTime.Month;

                // 当前月末
                if (dtTime.Day == DateTime.DaysInMonth(int_Year, int_Month))
                {
                    // 上传数据为月初
                    if (Day == 1)
                    {
                        int_Month++;
                    }
                }
                else
                {
                    // 当前月初
                    if (dtTime.Day == 1)
                    {
                        // 上传数据为月末
                        if (int_Month == 1)
                        {
                            if (Day == DateTime.DaysInMonth(int_Year - 1, 12))
                            {
                                int_Month--;
                            }
                        }
                        else
                        {
                            if (Day == DateTime.DaysInMonth(int_Year, int_Month - 1))
                            {
                                int_Month--;
                            }
                        }
                    }
                    else
                    {
                        // 非月初月末
                        if (Day > dtTime.Day + 1)
                        {
                            int_Month--;
                        }
                    }
                }

                // 构造新的时间
                if (int_Month < 1)
                {
                    int_Year--;
                    int_Month = 12;
                }

                if (int_Month > 12)
                {
                    int_Year++;
                    int_Month = 1;
                }

                return new DateTime(int_Year, int_Month, Day, Hour, Minute, Second);
            }
            catch
            {
                return new DateTime(2000, 1, 1, 0, 0, 1);
            }
        }

        /// <summary>
        /// 构造时间
        /// </summary>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        /// <returns></returns>
        public static DateTime BuildDateTime(int Hour, int Minute, int Second)
        {
            DateTime dtTime = DateTime.Now;

            try
            {
                // 时间不合法，则返回系统最小时间
                if (Hour >= 24 || Minute >= 60 || Second >= 60)
                {
                    return new DateTime(2000, 1, 1, 0, 0, 1);
                }

                //接收到数据的时、分、秒
                int int_Year = dtTime.Year;
                int int_Month = dtTime.Month;
                int int_Day = DateTime.Now.Day;
                DateTime dtTimeGet = new DateTime(int_Year, int_Month, int_Day, Hour, Minute, Second);

                if (dtTime >= dtTimeGet.AddMinutes(-5)) //当前时间大于发送数据的时间
                {
                    return dtTimeGet;
                }
                else //减一天
                {
                    return dtTimeGet.AddDays(-1);
                }
            }
            catch
            {
                return new DateTime(2000, 1, 1, 0, 0, 1);
            }
        }
        #endregion

    }
}
