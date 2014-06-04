using System;
using System.IO;
using System.Threading;
using KJ128A.DataAnalyzing;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using KJ128A.DataSave;
//using KJ128NDBTable;
using KJ128NDataBase;
using System.Text;

namespace KJ128A.HostBack
{
    public class DataSave
    {

        #region [ 声明 ]

        ////Czlt-2011-03-23 测试目录
        //string strDirectoryPath = @"D:\DataBase\FileText";
        // //日志文件大小总和
        //int intErrorLogFileSizeCount = 500;

        /// <summary>
        /// 将数据存SQL的线程
        /// </summary>
        public Thread m_thread;

        /// <summary>
        /// 处理数据存储
        /// </summary>
        //private InterfaceHostBack interHostBack = new InterfaceHostBack();
        private readonly SerialAndReserialOperate KJ128Nsad = new SerialAndReserialOperate();

        /// <summary>
        /// 处理数据
        /// </summary>
        private readonly DataAnalyzing.DataAnalyzing dataAing = new DataAnalyzing.DataAnalyzing();

        /// <summary>
        /// 检测基站信息的间隔(以秒为单位)
        /// </summary>
        public long long_DetectTime = 6;

        private DataBaseSync dbs = new DataBaseSync();

        private DataTable dt_Satation;
        private DataTable czltDt;
        public DataTable Dt_Satation
        {
            get { return dt_Satation; }
        }

        private DataTable dt_TcpClient;
        public DataTable Dt_TcpClient
        {
            get { return dt_TcpClient; }
        }
        /// <summary>
        /// 是否在切换数据库
        /// </summary>
        public bool isSyncHost = false;

        #endregion

        #region [ 委托: 错误消息事件 ]

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        public delegate void ErrorMessageEventHandler(int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ 委托方法 ]
        /// <summary>
        /// 注册错误消息处理
        /// </summary>
        /// <param name="iErrNO">错误消息编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        void _ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataSave()
        {
            //interHostBack.ErrorMessage += _ErrorMessage;

            ////Czlt-2011-03-24测试代码
            //DetectDirectoryIsExists();

            czltDt = new DataTable();
        }

        #endregion

        #region [ 方法: 存储通讯数据 ]
        /// <summary>
        /// 保存通讯数据
        /// </summary>
        /// <returns>True:操作成功;False:操作失败</returns>
        private bool Save(string temp_strSaveTime, byte[] temp_byteCmdInfo)
        {
            try
            {
                if (temp_byteCmdInfo.Length > 1)
                {
                    int iCmdNO = temp_byteCmdInfo[1];
                    switch (iCmdNO)
                    {
                        case 20:        // 巡检命令
                            if (!this.Save_Detecting(temp_byteCmdInfo))           //存SQL Server失败
                            {
                                return false;
                            }
                            break;
                        case 22:        //版本命令
                            break;
                        case 99:            //基站状态命令
                            if (!this.Save_StationChangeState(temp_byteCmdInfo))           //存SQL Server失败
                            {
                                return false;
                            }
                            break;
                        //case 100:                           //申云飞
                        //    if (!KJ128Nsad.DeserialOperate(temp_byteCmdInfo, true))
                        //    {
                        //        return false;
                        //    }
                        //break;
                        default:
                            return false;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031007, ex.StackTrace, "[DataSave:Save]", ex.Message);
                }
                return true;
            }
        }

        #endregion

        #region [ 方法：向SQLSERVER数据库中插入数据 ]
        public bool InsertSQLSERVER(string strDateTime, byte[] cmdInfo)
        {
            int iCount = 0;
            int iNum = 0;
            if (!this.Save(strDateTime, cmdInfo))        //存SQL失败
            {
                if (SQLSave.bConStateFlag)      //SQL Server数据库连接正常
                {
                    //if (iCount >= 10)
                    //{
                    //写入错误日志
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6031006, "", "[DataSave:Run]", "存入数据失败，且当时的SQL Server连接正常,当前时间为" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    }
                    iNum = 0;
                    return false;
                    //}
                    //iCount++;
                    //Thread.Sleep(20);
                }
                else                           //SQL Server数据库连接失败
                {
                    //if (iNum>=3)
                    //{
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6031006, "", "[DataSave:Run]", "数据库连接失败,当前时间为" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    }
                    iNum = 0;
                    return false;
                    //}
                    //iNum++;
                    //Thread.Sleep(100);
                }
            }
            return true;
        }
        #endregion [ 方法：向SQLSERVER数据库中插入数据 ]

        #region [ 方法: 存检测到的信息 ]

        /// <summary>
        /// 存检测到的信息
        /// </summary>
        /// <param name="temp_byteCmdInfo">命令Byte[]数组</param>
        /// <returns>True:成功;False:失败</returns>
        private bool Save_Detecting(byte[] temp_byteCmdInfo)
        {
            //string strCmdInfo = string.Empty;
            StringBuilder strCmdInfo = new StringBuilder();
            string strTemp = "";
            try
            {
                try
                {
                    MemDataAnalyz memDataAnalyz;

                    if (dt_Satation == null)
                    {
                        return true;
                    }
                    DataRow[] dr = dt_Satation.Select("Address=" + Convert.ToInt32(temp_byteCmdInfo[0].ToString()).ToString());
                    if (dr.Length <= 0)
                    {
                        return true;
                    }
                    //状态类型
                    int stationModel = Convert.ToInt32(dr[0]["StationModel"].ToString());

                    memDataAnalyz = dataAing.Analyzing(temp_byteCmdInfo, stationModel);
                    //如果返回的是巡检获送的数据
                    if (memDataAnalyz.enumAnalyzing == EnumDataType.Polling)
                    {
                        switch (stationModel)
                        {
                            case 1:
                            case 3:
                                #region [KJ128A解析]
                                for (int i = 1; i <= memDataAnalyz.memHead.Length; i++)
                                {
                                    if (!memDataAnalyz.memHead[i - 1].IsBreak)      //探头不故障时
                                    {
                                        //置探头状态为正常
                                        //strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "2000" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + ";";
                                        strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "2000" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + ";");


                                        //天线A接收到的发码器
                                        int intStrCountA;
                                        intStrCountA = memDataAnalyz.memHead[i - 1].CodesA.Length;
                                        if (intStrCountA > 0)
                                        {
                                            string strCardA;
                                            strCardA = memDataAnalyz.memHead[i - 1].CodesA.Remove(intStrCountA - 1);
                                            strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "0.1.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardA + ";");
                                        }

                                        //天线B接收到的发码器
                                        int intStrCountB;
                                        intStrCountB = memDataAnalyz.memHead[i - 1].CodesB.Length;
                                        if (intStrCountB > 0)
                                        {
                                            string strCardB;
                                            strCardB = memDataAnalyz.memHead[i - 1].CodesB.Remove(intStrCountB - 1);
                                            strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "0.0.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardB + ";");
                                        }

                                        //探头的出状态
                                        int intStrCountC;
                                        intStrCountC = memDataAnalyz.memHead[i - 1].CodesC.Length;
                                        if (intStrCountC > 0)
                                        {
                                            string strCardC;
                                            strCardC = memDataAnalyz.memHead[i - 1].CodesC.Remove(intStrCountC - 1);
                                            strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "0.0.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardC + ";");
                                        }

                                        //求救的卡
                                        int intStrCountD;
                                        intStrCountD = memDataAnalyz.memHead[i - 1].CodesD.Length;
                                        if (intStrCountD > 0)
                                        {
                                            string strCardD;
                                            strCardD = memDataAnalyz.memHead[i - 1].CodesD.Remove(intStrCountD - 1);
                                            strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "0.1.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardD + ";");
                                        }

                                        //低电量的卡  天线A接收到的发码器
                                        int intStrCountE;
                                        intStrCountE = memDataAnalyz.memHead[i - 1].CodesE.Length;
                                        if (intStrCountE > 0)
                                        {
                                            string strCardE;
                                            strCardE = memDataAnalyz.memHead[i - 1].CodesE.Remove(intStrCountE - 1);
                                            strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "1.1.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardE + ";");
                                        }

                                        //低电量的卡  天线B接收到的发码器
                                        int intStrCountF;
                                        intStrCountF = memDataAnalyz.memHead[i - 1].CodesF.Length;
                                        if (intStrCountF > 0)
                                        {
                                            string strCardF;
                                            strCardF = memDataAnalyz.memHead[i - 1].CodesF.Remove(intStrCountF - 1);
                                            strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "1.0.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardF + ";");
                                        }

                                        //低电量的卡  探头的出状态
                                        int intStrCountG;
                                        intStrCountG = memDataAnalyz.memHead[i - 1].CodesG.Length;
                                        if (intStrCountG > 0)
                                        {
                                            string strCardG;
                                            strCardG = memDataAnalyz.memHead[i - 1].CodesG.Remove(intStrCountG - 1);
                                            strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "1.0.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardG + ";");
                                        }


                                        //低电量的卡  求救的卡
                                        int intStrCountH;
                                        intStrCountH = memDataAnalyz.memHead[i - 1].CodesH.Length;
                                        if (intStrCountH > 0)
                                        {
                                            string strCardH;
                                            strCardH = memDataAnalyz.memHead[i - 1].CodesH.Remove(intStrCountH - 1);
                                            strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "1.1.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardH + ";");
                                        }


                                        /*****************************Czlt-2011-11-17 交直流供电*********************************************************/
                                        //Czlt-2011-11-17 交直流供电
                                        int intStrDYcount;
                                        intStrDYcount = memDataAnalyz.memHead[i - 1].CodesDY.Length;
                                        if (intStrDYcount > 0)
                                        {
                                            string strDY;
                                            strDY = memDataAnalyz.memHead[i - 1].CodesDY.Remove(intStrDYcount - 1);
                                            strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strDY + ";");
                                        }
                                        /*****************************Czlt-2011-11-17 交直流供电**********************************************************/

                                    }
                                    else      //探头故障
                                    {
                                        //置探头状态为故障
                                        strCmdInfo.Append(memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "-1000" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + ";");
                                    }
                                }
                                #endregion
                                break;
                            default:
                                #region 【KJ128V2解析】
                                for (int i = 1; i <= memDataAnalyz.memHead.Length; i++)
                                {
                                    //if (!memDataAnalyz.memHead[i - 1].IsBreak)      //探头不故障时
                                    //{
                                    //置探头状态为正常
                                    strCmdInfo.Append(memDataAnalyz.StationAddress + "." + 1 + "." + "2000" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + ";");

                                    //出
                                    int intStrCountA;
                                    intStrCountA = memDataAnalyz.memHead[i - 1].CodesA.Length;
                                    if (intStrCountA > 0)
                                    {
                                        string strCardA;
                                        strCardA = memDataAnalyz.memHead[i - 1].CodesA.Remove(intStrCountA - 1);
                                        strCmdInfo.Append(memDataAnalyz.StationAddress + "." + 1 + "." + "0.0.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardA + ";");
                                    }

                                    //进状态
                                    int intStrCountC;
                                    intStrCountC = memDataAnalyz.memHead[i - 1].CodesC.Length;
                                    if (intStrCountC > 0)
                                    {
                                        string strCardC;
                                        strCardC = memDataAnalyz.memHead[i - 1].CodesC.Remove(intStrCountC - 1);
                                        strCmdInfo.Append(memDataAnalyz.StationAddress + "." + 1 + "." + "0.1.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardC + ";");
                                    }

                                    //求救的卡
                                    int intStrCountD;
                                    intStrCountD = memDataAnalyz.memHead[i - 1].CodesD.Length;
                                    if (intStrCountD > 0)
                                    {
                                        string strCardD;
                                        strCardD = memDataAnalyz.memHead[i - 1].CodesD.Remove(intStrCountD - 1);
                                        strCmdInfo.Append(memDataAnalyz.StationAddress + "." + 0 + "." + "0.1.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardD + ";");
                                    }

                                    //低电量 出
                                    int intStrCountE;
                                    intStrCountE = memDataAnalyz.memHead[i - 1].CodesE.Length;
                                    if (intStrCountE > 0)
                                    {
                                        string strCardE;
                                        strCardE = memDataAnalyz.memHead[i - 1].CodesE.Remove(intStrCountE - 1);
                                        strCmdInfo.Append(memDataAnalyz.StationAddress + "." + 1 + "." + "1.0.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardE + ";");
                                    }

                                    //低电量 进状态
                                    int intStrCountG;
                                    intStrCountG = memDataAnalyz.memHead[i - 1].CodesG.Length;
                                    if (intStrCountG > 0)
                                    {
                                        string strCardG;
                                        strCardG = memDataAnalyz.memHead[i - 1].CodesG.Remove(intStrCountG - 1);
                                        strCmdInfo.Append(memDataAnalyz.StationAddress + "." + 1 + "." + "1.1.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardG + ";");
                                    }

                                    //低电量 求救的卡
                                    int intStrCountH;
                                    intStrCountH = memDataAnalyz.memHead[i - 1].CodesH.Length;
                                    if (intStrCountH > 0)
                                    {
                                        string strCardH;
                                        strCardH = memDataAnalyz.memHead[i - 1].CodesH.Remove(intStrCountH - 1);
                                        strCmdInfo.Append(memDataAnalyz.StationAddress + "." + 1 + "." + "1.1.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardH + ";");
                                    }
                                }
                                #endregion
                                break;
                        }
                    }
                    if (strCmdInfo.ToString().EndsWith(";"))
                    {
                        //strTemp = strCmdInfo.Remove(strCmdInfo.Length - 1, 1);
                        strTemp = strCmdInfo.ToString().Remove(strCmdInfo.ToString().Length - 1, 1);
                    }
                    else
                    {
                        //strTemp = strCmdInfo;
                        strTemp = strCmdInfo.ToString();
                    }
                }
                catch { return true; }

                if (!strTemp.Equals(""))
                {
                    //return this.Save_DataBase(strTemp);
                    return this.Save_CoderSender(strTemp);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031003, ex.StackTrace, "[DataSave:Save_Detecting]", ex.Message);
                }
                return false;
            }
        }

        #endregion

        #region [ 方法: 存储基站状态 ]

        /// <summary>
        /// 存储基站状态
        /// </summary>
        /// <param name="temp_byteCmdInfo">命令Byte[]</param>
        /// <returns>True:成功;False:失败</returns>
        private bool Save_StationChangeState(byte[] temp_byteCmdInfo)
        {
            string strTemp = "";

            int intYear, intMonth, intDay, intHour, intMinute, intSecond;

            try
            {
                intYear = temp_byteCmdInfo[3] * 1000 + temp_byteCmdInfo[4];
                intMonth = temp_byteCmdInfo[5];
                intDay = temp_byteCmdInfo[6];
                intHour = temp_byteCmdInfo[7];
                intMinute = temp_byteCmdInfo[8];
                intSecond = temp_byteCmdInfo[9];

                DateTime dtStationState = new DateTime(intYear, intMonth, intDay, intHour, intMinute, intSecond);

                strTemp = temp_byteCmdInfo[0] + ".0.";

                switch (temp_byteCmdInfo[2])
                {
                    case 0:         //基站正常
                        strTemp += "2000";
                        break;
                    case 1:         //基站未启用
                        strTemp += "0";
                        break;
                    case 2:         //基站重启
                        strTemp += "-500";
                        break;
                    case 3:         //基站休眠

                        strTemp += "-2000";
                        break;
                    //Czlt-2012-3-28 注销
                    //case 4:         //基站离线
                    //    strTemp += "3000";
                    //    break;
                    //Czlt-2012-3-28  离线就是故障
                    case 4:         //基站离线
                    case 5:         //基站故障
                        strTemp += "-1000";
                        break;
                }
                strTemp += "." + dtStationState.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch { return true; }
            if (!strTemp.Equals(""))
            {
                return this.Save_StationState(strTemp);

                //return this.Save_DataBase(strTemp);
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region [ 方法: 将探头收到的卡的信息存入SQL Server数据库]
        /// <summary>
        /// 将探头收到的卡的信息存入SQL Server数据库
        /// </summary>
        /// <param name="strCmdInfo">探头收到的信息</param>
        /// <returns>True:成功;False:失败</returns>
        private bool Save_DataBase(string strCmdInfo)
        {
            //判断当前是否在切换数据库,如果在切换则跳出
            if (isSyncHost)
            {
                return true;
            }
            SqlParameter[] sqlParmeters = { new SqlParameter("Commands", SqlDbType.VarChar, 7000) };
            sqlParmeters[0].Value = strCmdInfo;

            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "Yl_Station_ExecProc", sqlParmeters);

            //JYH-2011-11-23 注销 -无法找到表0
            //return interHostBack.ExecuteSql(true, "Yl_Station_ExecProc", sqlParmeters);


        }

        #region 【方法：添加传输分站为故障】
        /// <summary>
        /// 添加传输分站为故障
        /// </summary>
        /// <param name="strCmdInfo"></param>
        /// <returns></returns>
        private bool Save_StationState(string strCmdInfo)
        {
            bool flag = true;
            string[] strTempItems = strCmdInfo.Split('.');

            try
            {
                if (!strTempItems[3].Equals("2000-01-01 00:00:01"))
                {
                    int stationAddress = Convert.ToInt32(strTempItems[0]);
                    int stationHeadAddress = 0;
                    int stationState = Convert.ToInt32(strTempItems[2]);
                    DateTime breakTime = Convert.ToDateTime(strTempItems[3]);
                    if (!SaveStationState(stationAddress, stationHeadAddress, stationState, breakTime))
                        flag = false;
                }
            }
            catch
            {
                flag = false;
            }

            return flag;
        }
        #endregion

        /// <summary>
        /// 保存数据信息
        /// </summary>
        /// <param name="strCmdInfo"></param>
        /// <returns></returns>
        private bool Save_CoderSender(string strCmdInfo)
        {
            //判断当前是否在切换数据库,如果在切换则跳出
            if (isSyncHost)
            {
                return true;
            }
            bool flag = true;
            string[] strTemp = strCmdInfo.Split(';');
            if (strTemp.Length > 0)
            {
                foreach (string strItem in strTemp)
                {
                    string[] strTempItems = strItem.Split('.');
                    if (strTempItems.Length == 4)//读卡分站信息
                    {
                        try
                        {
                            if (!strTempItems[3].Equals("2000-01-01 00:00:01"))
                            {
                                int stationAddress = Convert.ToInt32(strTempItems[0]);
                                int stationHeadAddress = Convert.ToInt32(strTempItems[1]);
                                int stationState = Convert.ToInt32(strTempItems[2]);
                                DateTime breakTime = Convert.ToDateTime(strTempItems[3]);
                                if (!SaveStationHeadState(stationAddress, stationHeadAddress, stationState, breakTime))
                                    flag = false;
                            }
                        }
                        catch
                        {
                            flag = false;
                        }
                    }
                    //****************88Czlt-2011-05-10 - 交直流供电*Start********************
                    else if (strTempItems.Length == 5)
                    {
                        try
                        {
                            if (!strTempItems[2].Equals("2000-01-01 00:00:01"))
                            {
                                int stationAddress = Convert.ToInt32(strTempItems[0]);
                                int stationHeadAddress = Convert.ToInt32(strTempItems[1]);
                                DateTime breakTime = Convert.ToDateTime(strTempItems[2]);
                                int stationState = Convert.ToInt32(strTempItems[3]);
                                int serialState = Convert.ToInt32(strTempItems[4]);
                                if (!CzltSaveDYstate(stationAddress, stationHeadAddress, stationState, serialState, breakTime))
                                    flag = false;
                            }
                        }
                        catch
                        {
                            flag = false;
                        }

                    } //****************88Czlt-2011-05-10 - 交直流供电*End********************
                    else if (strTempItems.Length == 7)//卡号信息
                    {
                        try
                        {
                            if (!strTempItems[5].Equals("2000-01-01 00:00:01"))
                            {
                                //****Czlt-2011-04-09  判断假如传入的时间大于当前的时间,不保存该包数据****
                                DateTime dtCode = Convert.ToDateTime(strTempItems[5].ToString());
                                DateTime dtNow = DateTime.Now;
                                if (dtCode > dtNow)
                                    continue;
                                //****Czlt-2011-04-09  判断假如传入的时间大于当前的时间,不保存该包数据****

                                int stationAddress = Convert.ToInt32(strTempItems[0]);
                                int stationHeadAddress = Convert.ToInt32(strTempItems[1]);
                                int codeSenderCoul = Convert.ToInt32(strTempItems[2]);//电量  （0为正常  1为低）
                                int codeSenderState = 0;
                                if (strTempItems[3].Equals("1") && strTempItems[4].Equals("1"))//求救
                                {
                                    codeSenderState = 2;
                                }
                                else if (strTempItems[3].Equals("0") && strTempItems[4].Equals("0"))//出
                                {
                                    codeSenderState = 1;
                                }
                                else//进
                                {
                                    codeSenderState = 0;
                                }
                                DateTime detectTime = Convert.ToDateTime(strTempItems[5]);
                                string strCodeSender = strTempItems[6];

                                if (!SaveCodeSenderInfo(stationAddress, stationHeadAddress, codeSenderCoul, codeSenderState, detectTime, strCodeSender, false))
                                    flag = false;
                            }
                        }
                        catch (Exception ee)
                        {
                            flag = false;
                        }
                    }
                }
            }
            else
                return true;
            return flag;
        }

        /// <summary>
        /// 保存卡信息
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <param name="codeSenderCoul"></param>
        /// <param name="codeSenderState"></param>
        /// <param name="detecTime"></param>
        /// <param name="strCodeSender"></param>
        /// <returns></returns>
        public bool SaveCodeSenderInfo(int stationAddress, int stationHeadAddress, int codeSenderCoul, int codeSenderState, DateTime detecTime, string strCodeSender, bool isMend)
        {
            
            bool flag = true;
            if (!CreateHisTable(detecTime))//创建历史数据表    -取消删除数据记录
                flag = false;

            ////Czlt-2011-03-23测试文件路径
            //string strFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + stationAddress + "-" + stationHeadAddress;

            ////Czlt-2011-03-23测试文件
            //StringBuilder strBuilder = new StringBuilder();
            //strBuilder.AppendLine("************************************************保存卡信息*" + DateTime.Now.ToString("yyyyMMddHHmmss") + "*Start********************************************************");
            //strBuilder.AppendLine(stationAddress + "号传输分站 " + stationHeadAddress + "读卡分站");
            //strBuilder.AppendLine("开始接收到的标识卡号:");
            //strBuilder.AppendLine(strCodeSender );


            //获取读卡分站信息
            DataTable dtStationHead = GetStationHeadInfoByID(stationAddress, stationHeadAddress);
            if (dtStationHead != null && dtStationHead.Rows.Count > 0)
            {
                //获取这些卡的基本信息
                DataTable dtCodeSenderAddress = GetCodeSenderAddressByCards(strCodeSender);
                //获取这些实时标识卡的信息
                DataTable dtRtInStationHeadInfo = GetRTInStationHeadInfoByCards(strCodeSender);
                //获取临时表中的数据
                DataTable dtRtInStationHeadTemp = GetRTInStationHeadInfoTemp(stationAddress, stationHeadAddress, strCodeSender);
                //获取那些卡在井下有信息
                DataTable dtRtInWell = GetRtInWell(strCodeSender);
                if (codeSenderState == 1)//出
                {
                    ////Czlt-2011-03-23 测试数据
                    //strBuilder.AppendLine("出逻辑处理:");
                    //strBuilder.AppendLine("1.添加到历史进出读卡分站表中");
                    #region 【出逻辑处理】

                    if (dtRtInStationHeadTemp != null && dtRtInStationHeadTemp.Rows.Count > 0)
                    {
                        #region 组织历史数据
                        DataTable dtHisInStationHead = CreateHisInStationHead();//构造历史进出读卡分站表
                        //获取临时数据中单个数据
                        foreach (DataRow dr in dtRtInStationHeadTemp.Rows)
                        {
                            try
                            {
                                DateTime dtimeInStationHeadTime = Convert.ToDateTime(dr["InStationHeadTime"].ToString());
                                if (dtimeInStationHeadTime < detecTime)//进读卡分站的时间比出读卡分站的时间小
                                {
                                    //DataRow[] drEmp = null;
                                    DataView dvEmp = null;
                                    //获取这张卡的基本信息
                                    try
                                    {
                                        dvEmp = new DataView(dtCodeSenderAddress, "CodeSenderAddress=" + dr["CodeSenderAddress"].ToString(), "CodeSenderAddress", DataViewRowState.CurrentRows);
                                    }
                                    catch (Exception eeeeeeeeee)
                                    { }
                                    if (dvEmp != null && dvEmp.Count > 0)//如果存在则处理
                                    {
                                        ////Czlt-2011-03-24-测试代码
                                        //strBuilder.AppendLine(dr["CodeSenderAddress"].ToString() + "," + dtHisInStationHead + "," + dtStationHead + "," + dvEmp[0] + "," + detecTime + "," + dtimeInStationHeadTime + "," + isMend);
                                        //添加到历史进出读卡分站表中
                                        if (!AddHisStationHeadInfo(Convert.ToInt32(dr["CodeSenderAddress"].ToString()), dtHisInStationHead, dtStationHead, dvEmp[0], detecTime, dtimeInStationHeadTime, isMend))
                                            flag = false;
                                    }
                                }
                            }
                            catch (Exception eee)
                            {
                                flag = false;
                            }
                        }
                        #endregion

                        ////Czlt-2011-03-24-测试代码
                        //strBuilder.AppendLine("2.出井逻辑中删除进出分站表记录:");
                        //strBuilder.AppendLine(stationAddress+","+stationHeadAddress+","+strCodeSender);
                        //删除临时进出分站表记录
                        if (!DeleteRtStationHeadTemp(stationAddress, stationHeadAddress, strCodeSender))
                            flag = false;


                        #region 更新实时读卡分站信息
                        ////Czlt-2011-03-24 测试代码
                        //strBuilder.AppendLine("更新实时读卡分站信息:");
                        foreach (DataRow drEmp in dtCodeSenderAddress.Rows)
                        {
                            ////Czlt-2011-03-24 测试代码
                            //strBuilder.AppendLine(drEmp["CodeSenderAddress"].ToString()+" ");
                            //获取单个实时进出标识卡表中的数据
                            DataView dvRTInstationHeadByCodeSender = new DataView(dtRtInStationHeadInfo, "CodeSenderAddress=" + drEmp["CodeSenderAddress"].ToString(), "CodeSenderAddress", DataViewRowState.CurrentRows);
                            if (dvRTInstationHeadByCodeSender != null && dvRTInstationHeadByCodeSender.Count > 0)
                            {
                                //实时进出读卡分站表 读卡分站编号 和 传入的读卡分站编号 比较
                                //相同
                                if (Convert.ToInt32(dvRTInstationHeadByCodeSender[0]["StationHeadID"].ToString()) == Convert.ToInt32(dtStationHead.Rows[0]["StationHeadID"].ToString()))
                                {
                                    try
                                    {
                                        if (detecTime > Convert.ToDateTime(dvRTInstationHeadByCodeSender[0]["InStationHeadTime"].ToString()))
                                        {
                                            if (!UpdateRtInStationHead(dvRTInstationHeadByCodeSender[0], dtStationHead.Rows[0], drEmp, detecTime, 1, dvRTInstationHeadByCodeSender[0]["Directional"].ToString()))
                                                flag = false;
                                        }
                                    }
                                    catch { }
                                }
                                else//不同
                                {
                                    if (Convert.ToInt32(dvRTInstationHeadByCodeSender[0]["InOutFlag"].ToString()) == 1)//实时进出读卡分站表中状态为出
                                    {
                                        try
                                        {
                                            //Czlt-2011-11-17 注销 解决井口区域交叉的情况
                                            //if (detecTime > Convert.ToDateTime(dvRTInstationHeadByCodeSender[0]["InStationHeadTime"].ToString()))
                                            //{
                                            ////Czlt-2010-12-17注销
                                            ////更新实时进出读卡分站表
                                            //if (!UpdateRtInStationHead(dvRTInstationHeadByCodeSender[0], dtStationHead.Rows[0], drEmp, detecTime, 1, dvRTInstationHeadByCodeSender[0]["Directional"].ToString()))
                                            //    flag = false;

                                            //*****************************Czlt-2010-12-17 处理井下分站检测到井口人员信息时的情况*Start*****************************************************************
                                            if (dtStationHead.Rows[0]["stationHeadTypeID"].ToString().Equals("8")) //当分站信息为井口分站的时候直接更新实时进出读卡分站表
                                            {
                                                //Czlt-2011-11-17 判断该人员是否还在井下,如果还在井下更新实时进出读卡分站表
                                                DataView dvRTinMine = new DataView(dtRtInWell, "CodeSenderAddress=" + drEmp["CodeSenderAddress"].ToString(), "CodeSenderAddress", DataViewRowState.CurrentRows);
                                                if (dvRTinMine != null && dvRTinMine.Count > 0)
                                                {
                                                    //Czlt-2011-11-17 该卡号在井下不做处理
                                                }
                                                else
                                                {
                                                    //Czlt-2011-11-17 该卡号不在井下更新实时进出分站
                                                    if (!UpdateRtInStationHead(dvRTInstationHeadByCodeSender[0], dtStationHead.Rows[0], drEmp, detecTime, 1, dvRTInstationHeadByCodeSender[0]["Directional"].ToString()))
                                                        flag = false;
                                                }
                                            }
                                            else if (dtStationHead.Rows[0]["stationHeadTypeID"].ToString().Equals("32"))
                                            {
                                                //Czlt-2011-11-17 比对传入的时间
                                                if (detecTime > Convert.ToDateTime(dvRTInstationHeadByCodeSender[0]["InStationHeadTime"].ToString()))
                                                {
                                                    //判断该人员是否还在井下,如果还在井下更新实时进出读卡分站表
                                                    DataView dvRTinMine = new DataView(dtRtInWell, "CodeSenderAddress=" + drEmp["CodeSenderAddress"].ToString(), "CodeSenderAddress", DataViewRowState.CurrentRows);
                                                    if (dvRTinMine != null && dvRTinMine.Count > 0)
                                                    {
                                                        if (!UpdateRtInStationHead(dvRTInstationHeadByCodeSender[0], dtStationHead.Rows[0], drEmp, detecTime, 1, dvRTInstationHeadByCodeSender[0]["Directional"].ToString()))
                                                            flag = false;
                                                    }
                                                }
                                            }
                                            //*****************************Czlt-2010-12-17 处理井下分站检测到井口人员信息时的情况*End********************************************************************

                                            //}
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                        #endregion

                    }
                    #endregion
                }
                else//进、求救
                {
                    if (codeSenderState == 2)//求救
                    {
                        ////Czlt-2011-03-24 测试代码
                        //strBuilder.AppendLine("求救卡号:");
                        //strBuilder.AppendLine(strCodeSender);

                        if (!UpdateRtEmpHelp(stationAddress, stationHeadAddress, strCodeSender, detecTime))
                            flag = false;
                    }

                    if (codeSenderCoul == 0)//电量正常
                    {
                        if (!SaveCodeSenderStateByOk(strCodeSender))
                            flag = false;
                    }
                    else//低电量
                    {
                        ////Czlt-2011-03-24 测试代码
                        //strBuilder.AppendLine("低电量卡号:");
                        //strBuilder.AppendLine(strCodeSender );

                        if (!SaveCodeSenderStatebyLow(strCodeSender))
                            flag = false;
                    }

                    string[] strCodeList = strCodeSender.Split(',');//分割卡号

                    #region 操作区域进出
                    //获取区域配置信息
                    DataTable dtAreaInfo = GetAreaSet();
                    if (dtAreaInfo != null && dtAreaInfo.Rows.Count > 0)//有区域配置信息
                    {
                        //获取传入读卡分站所在的区域信息，并且该读卡分站不属于区域口
                        DataView dvAreas = new DataView(dtAreaInfo, "StationHeadID=" + dtStationHead.Rows[0]["StationHeadID"].ToString() + " and IsTerriorialEnter=0", "", DataViewRowState.CurrentRows);

                        //获取特殊工种区域配置信息
                        DataTable dtSworktype = GetSWorkTypeAreaSet();

                        //获取传入的卡的实时区域信息
                        DataTable dtRtAreas = GetRtAreaInfo(strCodeSender);
                        //获取传入的卡的实时超时信息
                        DataTable dtRTOverTime = GetTerOverTime(strCodeSender);

                        if (dvAreas != null && dvAreas.Count > 0)//该读卡分站有区域信息
                        {
                            if (dtRtAreas != null && dtRtAreas.Rows.Count > 0)//有实时区域信息
                            {
                                string strWhereTerr1 = "";
                                string strWhereTerr2 = "";

                                foreach (DataRowView drArea in dvAreas)//各个区域信息
                                {
                                    string strCodes = "";
                                    foreach (string strCTemp in strCodeList)
                                    {
                                        strWhereTerr1 = "TerritorialID=" + drArea["TerritorialID"].ToString() + " and CodeSenderAddress=" + strCTemp;
                                        DataView dvRtAreaByExist = new DataView(dtRtAreas, strWhereTerr1, "", DataViewRowState.CurrentRows);//实时区域表中存在存入的区域的卡号信息
                                        if (dvRtAreaByExist == null || dvRtAreaByExist.Count <= 0)
                                        {
                                            strCodes += "," + strCTemp;//获取得到不在这个区域的卡号
                                        }
                                    }
                                    if (!strCodes.Equals(""))
                                    {
                                        strCodes = strCodes.Substring(1);
                                        //添加这些卡到实时区域表中
                                        if (!AddRtTerritorial(strCodes, dtCodeSenderAddress, drArea, detecTime, dtSworktype))
                                            flag = false;
                                    }
                                    strWhereTerr2 += " and TerritorialID<>" + drArea["TerritorialID"].ToString();
                                }
                                strWhereTerr2 = strWhereTerr2.Substring(5);

                                //实时区域表中不在传入的区域的卡号信息
                                DataView dvRtAreaByNotExist = new DataView(dtRtAreas, strWhereTerr2, "", DataViewRowState.CurrentRows);
                                //实时区域人员超时信息
                                DataView dvRTTerOverTime = new DataView(dtRTOverTime, strWhereTerr2, "", DataViewRowState.CurrentRows);

                                if (!AddHisTerritorial(dvRtAreaByNotExist, dtCodeSenderAddress, detecTime, dvRTTerOverTime))//添加到历史数据数据中
                                    flag = false;
                            }
                            else//没有实时区域信息
                            {
                                foreach (DataRowView drArea in dvAreas)//各个区域信息
                                {
                                    //添加所有的读卡分站到实时区域表中
                                    if (!AddRtTerritorial(strCodeSender, dtCodeSenderAddress, drArea, detecTime, dtSworktype))
                                        flag = false;
                                }
                            }
                        }
                        else//该读卡分站没有区域信息
                        {
                            if (dtRtAreas != null && dtRtAreas.Rows.Count > 0)//有实时区域信息
                            {
                                DataView dvRtAreas = new DataView(dtRtAreas);
                                DataView dvRTTerOverTime = new DataView(dtRTOverTime);
                                if (!AddHisTerritorial(dvRtAreas, dtCodeSenderAddress, detecTime, dvRTTerOverTime))
                                    flag = false;
                            }
                        }

                        #region 操作区域超员信息
                        if (!OperatorTerOverEmp(detecTime))
                            flag = false;
                        #endregion

                    }
                    else//没有区域配置信息
                    {
                        if (!DeleteRtTerritorial())//删除所有实时区域信息
                            flag = false;
                        //删除区域超员信息
                        if (!DeleteTerOverEmp())
                            flag = false;

                    }
                    #endregion

                    #region 【操作超速、欠速信息】
                    if (!AddRTOverSpeed(detecTime, stationAddress, stationHeadAddress, strCodeSender))
                        flag = false;
                    #endregion

                    #region 【操作上下井】

                    ////Czlt-2011-03-24 测试代码
                    //strBuilder.AppendLine("进:操作上下井的卡号:");
                    //strBuilder.AppendLine(strCodeSender );

                    //获取进入井口分站表信息
                    DataTable dtInMineStationHead = GetMineStationHead(strCodeSender);
                    //获取实时考勤信息
                    DataTable dtRealTimeAttendance = GetRealTimeAttendanceByCards(strCodeSender);
                    //获取考勤统计信息
                    // DataTable dtKQTJ = GetKQTJbyCards(strCodeSender, detecTime);

                    //***Czlt-2011-12-05 月末的时候查询下一个月的考勤原始信息***Start*
                    DataTable CzltdtKQTJ = null;
                    if (detecTime.Day >= 28)
                    {

                        CzltdtKQTJ = CzltGetKQTJbyCards(strCodeSender, detecTime);
                    }
                    //***Czlt-2011-12-05 月末的时候查询下一个月的考勤原始信息***End*

                    if (dtStationHead.Rows[0]["stationHeadTypeID"].ToString().Equals("8"))//上井口分站
                    {
                        #region 【上井口分站】
                        ////Czlt-2011-03-24 测试代码
                        //strBuilder.AppendLine(" I.上井口分站卡号:");
                        //strBuilder.AppendLine(strCodeSender );

                        //添加到历史超时信息
                        if (!AddHisOverTimeEmployee(detecTime, strCodeSender))
                            flag = false;

                        #region 【获取实时巡检异常】
                        //获取这些卡的巡检异常数据
                        DataTable dtRtPath = GetRealTimePathAlarm(strCodeSender);
                        #endregion


                        ////Czlt-2011-03-24 测试代码
                        //strBuilder.AppendLine(" 1.添加到历史下井信息:");

                        foreach (string strCodeItem1 in strCodeList)
                        {
                            #region 【添加到历史下井信息】
                            if (dtRtInWell != null && dtRtInWell.Rows.Count > 0)//这些卡中有实时井下人员记录
                            {
                                //获取这张卡的实时井下信息
                                DataView dvRtInWell = new DataView(dtRtInWell, "CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);

                                if (dvRtInWell != null && dvRtInWell.Count > 0)//有井下信息
                                {
                                    try
                                    {
                                        //获取这张卡在数据库中的实时标识卡信息
                                        DataView dvRtInStation = new DataView(dtRtInStationHeadInfo, "cstypeid=0 and CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                        //获取这张卡的人员信息
                                        DataView dvEmp = new DataView(dtCodeSenderAddress, "cstypeid=0 and CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);

                                        if (dvEmp != null && dvEmp.Count > 0)//有这个人员的信息
                                        {
                                            //下井时间
                                            DateTime dTimeInWell = Convert.ToDateTime(dvRtInWell[0]["InTime"].ToString());
                                            if (dvRtInStation != null && dvRtInStation.Count > 0)//有这个人的实时标识卡信息
                                            {
                                                DateTime dTimeInStationHeadTime = new DateTime(2000, 1, 1, 0, 0, 0);
                                                try
                                                {
                                                    //实时标识卡进分站时间  --InStationHeadTime
                                                    //dTimeInStationHeadTime = Convert.ToDateTime(dvRtInStation[0]["StationHeadTime"].ToString());
                                                    dTimeInStationHeadTime = Convert.ToDateTime(dvRtInStation[0]["InStationHeadTime"].ToString());
                                                }
                                                catch
                                                {
                                                }

                                                if (!dTimeInStationHeadTime.Equals(new DateTime(2000, 1, 1, 0, 0, 0)))//有时间
                                                {
                                                    if (detecTime < dTimeInStationHeadTime)//进入的时间比标识卡里的时间小
                                                    {
                                                        if (detecTime > dTimeInWell)//进入时间比下井时间大，覆盖下井时间和地点
                                                        {
                                                            if (!UpdateRtInMine(Convert.ToInt32(strCodeItem1), Convert.ToInt32(dtStationHead.Rows[0]["StationHeadID"].ToString()), Convert.ToInt32(dvEmp[0]["csSetID"].ToString()), detecTime))
                                                                flag = false;
                                                        }
                                                    }
                                                    else//进入的时间比实时标识卡里时间大，则做出井处理
                                                    {

                                                        //******Czlt-2011-12-04 没有实时考勤信息的人员，在上下井的时候补加历史考勤信息***start**

                                                        //获取这张卡的人员信息
                                                        // DataView dvEmpAtt = new DataView(dtCodeSenderAddress, "cstypeid=0 and CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                                        //获取考勤统计信息
                                                        //DataView dvKQTJ = new DataView(dtKQTJ, "blockid=" + strCodeItem1, "", DataViewRowState.CurrentRows);

                                                        //获取这张的实时考勤记录
                                                        DataView dvRealTimeAttendance = new DataView(dtRealTimeAttendance, "CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);


                                                        //Cztl-2012-3-12 记工日期
                                                        DateTime czltDataAttendance = new DateTime(2000, 1, 1, 0, 0, 0);

                                                        if (dvRealTimeAttendance != null && dvRealTimeAttendance.Count > 0)
                                                        {
                                                            //Czlt-2012-03-20 给记工日期赋值
                                                            czltDataAttendance = Convert.ToDateTime(dvRealTimeAttendance[0]["DataAttendance"].ToString());
                                                        }
                                                        else
                                                        {
                                                            File.AppendAllText("D:\\CzltAttendance.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "给没有实时考勤信息的标识卡：" + strCodeItem1 + " 在历史下井信息中补录考勤信息！\r\n");
                                                            if (!CzltAddHisAttendance(dvRtInWell[0], dvEmp[0], detecTime, isMend))
                                                                flag = false;


                                                            if (czltDt.Rows.Count > 0)
                                                            {
                                                                czltDataAttendance = Convert.ToDateTime(czltDt.Rows[0]["DataAttendance"].ToString());
                                                            }
                                                            else
                                                            {
                                                                czltDataAttendance = DateTime.Now;
                                                            }
                                                        }

                                                        //******Czlt-2011-12-04 没有实时考勤信息的人员，在上下井的时候补加历史考勤信息***end**

                                                        //巡检操作
                                                        if (!OperatorHisPath(dtRtPath, dvEmp[0], detecTime))
                                                            flag = false;


                                                        //************Czlt-2012-3-20*添加历史上下井年统计信息*Start******************************
                                                        Czlt_MonthEmp(strCodeItem1, Convert.ToInt32(dvEmp[0]["UserID"]), dvEmp[0]["UserName"].ToString(), Convert.ToInt32(dvEmp[0]["DeptID"]), dvEmp[0]["DeptName"].ToString(), Convert.ToDateTime(dvRtInWell[0]["InTime"]), detecTime, czltDataAttendance);
                                                        //************Czlt-2012-3-20*添加历史上下井年统计信息*End**************************

                                                        ////Czlt-2011-03-24 测试代码
                                                        //strBuilder.AppendLine(" 有实时标识卡信息的卡号:" + dvRtInWell[0]["CodeSenderAddress"].ToString() + "," + dvEmp[0]["UserName"].ToString() + "," + dvEmp[0]["DeptName"].ToString() + "," + detecTime + "," + dtStationHead.Rows[0]["StationAddress"].ToString() + "," + dtStationHead.Rows[0]["StationHeadAddress"].ToString() + "," + isMend);
                                                        //上下井操作
                                                        if (!AddHisInOutMine(dvRtInWell[0], dvEmp[0], detecTime, dtStationHead.Rows[0], isMend))
                                                            flag = false;

                                                        //Czlt-2012-04-19 删除该条实时下井人员信息
                                                        if (!DeleteRtInMine(Convert.ToInt32(strCodeItem1)))
                                                            flag = false;
                                                    }
                                                }
                                            }
                                            else//没有这个人的实时标识卡信息
                                            {
                                                if (!OperatorHisPath(dtRtPath, dvEmp[0], detecTime))
                                                    flag = false;
                                                ////Czlt-2011-03-24 测试代码
                                                //strBuilder.AppendLine("没有实时标识卡信息的卡号:" + dvRtInWell[0]["CodeSenderAddress"].ToString() + "," + dvEmp[0]["UserName"].ToString() + "," + dvEmp[0]["DeptName"].ToString() + "," + detecTime + "," + dtStationHead.Rows[0]["StationAddress"].ToString() + "," + dtStationHead.Rows[0]["StationHeadAddress"].ToString() + "," + isMend);
                                                //判断传入的时间比下井的时间大，则做上井处理
                                                if (!AddHisInOutMine(dvRtInWell[0], dvEmp[0], detecTime, dtStationHead.Rows[0], isMend))
                                                    flag = false;
                                            }
                                        }
                                        else
                                        {
                                            ////Czlt-2011-03-24 测试代码
                                            //strBuilder.AppendLine(" 删除实时进井的记录的标识卡:");
                                            //strBuilder.AppendLine(strCodeSender );
                                            //删除实时进井的记录
                                            if (!DeleteRtInMine(Convert.ToInt32(strCodeItem1)))
                                                flag = false;
                                        }
                                    }
                                    catch (Exception errrr)
                                    {
                                        flag = false;
                                    }
                                }
                            }
                            #endregion

                            #region 【添加到井口分站信息】

                            ////Czlt-2011-03-24 测试代码
                            //strBuilder.AppendLine(" 2.添加到井口分站信息的标识卡:");
                            //strBuilder.AppendLine(strCodeItem1 );

                            //写入到进入井口分站的表中
                            DataView dvInMineStationHead = new DataView(dtInMineStationHead, "CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);

                            if (dvInMineStationHead != null && dvInMineStationHead.Count > 0)
                            {
                                //更新进入井口分站表中数据
                                DateTime dTimeInMineStation = new DateTime(2000, 1, 1, 0, 0, 0);
                                try
                                {
                                    dTimeInMineStation = Convert.ToDateTime(dvInMineStationHead[0]["InMineStationTime"].ToString());
                                }
                                catch { }
                                if (dTimeInMineStation.Equals(new DateTime(2000, 1, 1, 0, 0, 0)) || detecTime > dTimeInMineStation)
                                {
                                    //更新
                                    if (!UpdateInMineStation(Convert.ToInt32(dtStationHead.Rows[0]["stationHeadID"].ToString()), stationAddress, stationHeadAddress, Convert.ToInt32(strCodeItem1), detecTime))
                                        flag = false;
                                }
                            }
                            else
                            {
                                ////Czlt-2011-03-24 测试代码
                                //strBuilder.AppendLine(" 添加一条进入井口分站表数据:");
                                //strBuilder.AppendLine(dtStationHead.Rows[0]["stationHeadID"].ToString() + "," + stationAddress + "," + stationHeadAddress + "," + strCodeItem1 +","+ detecTime );
                                //添加一条进入井口分站表数据
                                if (!AddInMineStation(Convert.ToInt32(dtStationHead.Rows[0]["stationHeadID"].ToString()), stationAddress, stationHeadAddress, Convert.ToInt32(strCodeItem1), detecTime))
                                    flag = false;
                            }
                            #endregion

                            #region 【添加到历史考勤记录中】
                            ////Czlt-2011-03-24 测试代码
                            //strBuilder.AppendLine(" 3.添加到历史考勤记录中:");

                            //这些卡有实时考勤记录
                            if (dtRealTimeAttendance != null && dtRealTimeAttendance.Rows.Count > 0)
                            {
                                //获取这张的实时考勤记录
                                DataView dvRealTimeAttendance = new DataView(dtRealTimeAttendance, "CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                //这张卡有实时考勤信息
                                if (dvRealTimeAttendance != null && dvRealTimeAttendance.Count > 0)
                                {
                                    //获取这张卡的人员信息
                                    DataView dvEmpAtt = new DataView(dtCodeSenderAddress, "cstypeid=0 and CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                    //获取这张卡在数据库中的实时标识卡信息
                                    DataView dvRtInStation = new DataView(dtRtInStationHeadInfo, "cstypeid=0 and CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                    if (dvEmpAtt != null && dvEmpAtt.Count > 0)//有这个人员信息
                                    {

                                        DateTime dtimeRealTimeAttendance = new DateTime(2000, 1, 1, 0, 0, 0);
                                        DateTime dTimeInStationHeadTime = new DateTime(2000, 1, 1, 0, 0, 0);

                                        try
                                        {

                                            //实时考勤信息
                                            dtimeRealTimeAttendance = Convert.ToDateTime(dvRealTimeAttendance[0]["BeginWorkTime"].ToString());
                                            //实时标识卡进分站时间                                            
                                           // dTimeInStationHeadTime = Convert.ToDateTime(dvRtInStation[0]["StationHeadTime"].ToString());
                                            dTimeInStationHeadTime = Convert.ToDateTime(dvRtInStation[0]["InStationHeadTime"].ToString());

                                        }
                                        catch { }

                                        if (!dtimeRealTimeAttendance.Equals(new DateTime(2000, 1, 1, 0, 0, 0)))
                                        {
                                            if (detecTime >= dTimeInStationHeadTime)//进入的时间比标识卡里的时间小
                                            {
                                                if (detecTime > dtimeRealTimeAttendance)//传入日期比数据中的日期大，则写入历史表中，并删除实时考勤数据
                                                {
                                                    //去查实时考勤的信息
                                                    DataTable dtKQTJ = GetKQTJbyCards(strCodeItem1, Convert.ToDateTime(dvRealTimeAttendance[0]["DataAttendance"].ToString()));


                                                    //******czlt-2010-最小考勤设置*Start***
                                                    double checkTime = (detecTime - dtimeRealTimeAttendance).TotalSeconds;
                                                    int minTime = 0;
                                                    if (!dvEmpAtt[0]["MinSecTime"].ToString().Equals(""))
                                                    {
                                                        minTime = Int32.Parse(dvEmpAtt[0]["MinSecTime"].ToString());
                                                    }

                                                    //***Czlt-2011-12-05 月末的时候查询下一个月的考勤原始信息***Start*
                                                    if (detecTime.Day >= 28)
                                                    {
                                                        DataView czltdvKQTJ = new DataView(CzltdtKQTJ, "blockid=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                                        if (czltdvKQTJ == null || (czltdvKQTJ != null && czltdvKQTJ.Count <= 0))//统计信息中没有这条记录
                                                        {
                                                            if (detecTime.Month.ToString().Equals("12"))
                                                            {
                                                                //年末添加下一年的考勤记录
                                                                if (!AddKQTJ(new DateTime(detecTime.AddYears(1).Year, detecTime.AddMonths(1).Month, 1, 0, 0, 0), int.Parse(strCodeItem1), dvEmpAtt[0]["UserName"].ToString(), int.Parse(dvEmpAtt[0]["deptID"].ToString()), dvEmpAtt[0]["DeptName"].ToString()))
                                                                    flag = false;
                                                            }
                                                            else
                                                            {
                                                                //添加一条记录到考勤统计表中
                                                                if (!AddKQTJ(new DateTime(detecTime.Year, detecTime.AddMonths(1).Month, 1, 0, 0, 0), int.Parse(strCodeItem1), dvEmpAtt[0]["UserName"].ToString(), int.Parse(dvEmpAtt[0]["deptID"].ToString()), dvEmpAtt[0]["DeptName"].ToString()))
                                                                    flag = false;
                                                            }
                                                        }
                                                    }
                                                    //***Czlt-2011-12-05 月末的时候查询下一个月的考勤原始信息***End*

                                                    if (checkTime >= minTime)
                                                    {
                                                        ////Czlt-2011-03-24 测试代码
                                                        //strBuilder.AppendLine(" 添加一条历史考勤记录:");
                                                        //strBuilder.AppendLine(dvRealTimeAttendance[0]["CodeSenderAddress"] + "," + dvRealTimeAttendance[0]["UserName"] + "," + dvRealTimeAttendance[0]["DeptID"] + "," + dvRealTimeAttendance[0]["ClassID"] + "," + dvRealTimeAttendance[0]["TimerIntervalID"] + "," + dvRealTimeAttendance[0]["BeginWorkTime"] + "," + detecTime + "," + isMend);
                                                        if (!AddHisAttendance(dvRealTimeAttendance[0], detecTime, isMend))
                                                            flag = false;
                                                        //获取考勤统计信息
                                                        DataView dvKQTJ = new DataView(dtKQTJ, "blockid=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                                        if (dvKQTJ == null || (dvKQTJ != null && dvKQTJ.Count <= 0))//统计信息中没有这条记录
                                                        {
                                                            //添加一条记录到考勤统计表中
                                                            if (!AddKQTJ(new DateTime(detecTime.Year, detecTime.Month, 1, 0, 0, 0), Convert.ToInt32(strCodeItem1), dvEmpAtt[0]["UserName"].ToString(), Convert.ToInt32(dvEmpAtt[0]["deptID"].ToString()), dvEmpAtt[0]["DeptName"].ToString()))
                                                                flag = false;
                                                        }

                                                        //修改考勤统计表记录
                                                        if (!UpdateKQTJ(Convert.ToDateTime(dvRealTimeAttendance[0]["DataAttendance"].ToString()), Convert.ToInt32(strCodeItem1), dvRealTimeAttendance[0]["ClassShortName"].ToString(), Convert.ToInt32(dvEmpAtt[0]["deptID"].ToString()), dvEmpAtt[0]["DeptName"].ToString()))
                                                            flag = false;
                                                    }
                                                    else
                                                    {
                                                        if (!AddHisAttendance(dvRealTimeAttendance[0], detecTime, isMend))
                                                            flag = false;
                                                        //获取考勤统计信息
                                                        DataView dvKQTJ = new DataView(dtKQTJ, "blockid=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                                        if (dvKQTJ == null || (dvKQTJ != null && dvKQTJ.Count <= 0))//统计信息中没有这条记录
                                                        {
                                                            //添加一条记录到考勤统计表中
                                                            if (!AddKQTJ(new DateTime(detecTime.Year, detecTime.Month, 1, 0, 0, 0), Convert.ToInt32(strCodeItem1), dvEmpAtt[0]["UserName"].ToString(), Convert.ToInt32(dvEmpAtt[0]["deptID"].ToString()), dvEmpAtt[0]["DeptName"].ToString()))
                                                                flag = false;
                                                        }

                                                        //修改考勤统计表记录
                                                        if (!UpdateKQTJ(Convert.ToDateTime(dvRealTimeAttendance[0]["DataAttendance"].ToString()), Convert.ToInt32(strCodeItem1), dvRealTimeAttendance[0]["ClassShortName"].ToString() + "#", Convert.ToInt32(dvEmpAtt[0]["deptID"].ToString()), dvEmpAtt[0]["DeptName"].ToString()))
                                                            flag = false;

                                                    }
                                                    //******czlt-2010-最小考勤设置*End***

                                                    ////Czlt-2011-03-24 测试代码
                                                    //strBuilder.AppendLine(" 添加历史考勤记录后删除实时考勤信息:" + strCodeItem1 );
                                                    //删除这个人的实时考勤信息
                                                    if (!DelteteRealTimeAttendance(Convert.ToInt32(strCodeItem1)))
                                                        flag = false;

                                                }
                                            }
                                        }
                                        else
                                        {
                                            ////Czlt-2011-03-24 测试代码
                                            //strBuilder.AppendLine(" 传入的时间格式不正确删除实时考勤信息:" + strCodeItem1 + ",开始时间:" + dtimeRealTimeAttendance.ToString("yyyy-MM-dd HH:mm:ss") );
                                            //删除这个人的实时考勤信息
                                            if (!DelteteRealTimeAttendance(Convert.ToInt32(strCodeItem1)))
                                                flag = false;
                                        }

                                    }
                                    else//没有这个人员信息
                                    {
                                        ////Czlt-2011-03-24 测试代码
                                        //strBuilder.AppendLine(" 该标识卡没有个人员信息删除该卡实时考勤信息:" + strCodeItem1);

                                        //删除这个人的实时考勤信息
                                        if (!DelteteRealTimeAttendance(Convert.ToInt32(strCodeItem1)))
                                            flag = false;
                                    }
                                }
                            }
                            #endregion
                        }

                        #region 【添加到历史欠速超速信息】
                        if (!UpdateHisOverSpeed(strCodeSender))
                            flag = false;
                        #endregion

                        #endregion
                    }
                    else if (dtStationHead.Rows[0]["stationHeadTypeID"].ToString().Equals("32"))//井下分站
                    {
                        #region 【井下分站】
                        foreach (string strCodeItem1 in strCodeList)
                        {
                            try
                            {
                                //获取这张卡的人员信息
                                DataView dvEmp = new DataView(dtCodeSenderAddress, "cstypeid=0 and CodeSenderAddress=" + strCodeItem1, "CodeSenderAddress", DataViewRowState.CurrentRows);
                                if (dvEmp != null && dvEmp.Count > 0)//有这个人
                                {
                                    //qyz 2012-5-17 判断是否离开井口分站
                                    //DataTable rttemp = shine_GetRTInstationHeadTmep(strCodeItem1);
                                    //if (rttemp == null || rttemp.Rows.Count == 0)//实时临时表中不存在 井口分站信息，则存入实时下井和实时考勤
                                    //{
                                    //获取单个实时进出标识卡表中的数据
                                    //DataView dvRTInstationHeadByCodeSender = new DataView(dtRtInStationHeadInfo, "CodeSenderAddress=" + strCodeItem1, "CodeSenderAddress", DataViewRowState.CurrentRows);
                                    #region[加入实时下井和实时考勤]
                                    //获取这张卡的实时井下信息
                                    DataView dvRtInWell = new DataView(dtRtInWell, "CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                    if (dvRtInWell == null || (dvRtInWell != null && dvRtInWell.Count <= 0))//没有这个人的实时下井信息
                                    {

                                        //获取这张卡在井口分站表中的数据
                                        DataView dvInMineStation = new DataView(dtInMineStationHead, "CodeSenderAddress=" + strCodeItem1, "", DataViewRowState.CurrentRows);
                                        if (dvInMineStation != null && dvInMineStation.Count > 0)
                                        {
                                            try
                                            {
                                                if (detecTime > Convert.ToDateTime(dvInMineStation[0]["InMineStationTime"].ToString()))
                                                {
                                                    ////Czlt-2011-03-31 判断下井时间假如超过四小时，就使用当前时间存入实时下井时间和实时考勤中                                                   
                                                    if (detecTime.AddHours(-4) > Convert.ToDateTime(dvInMineStation[0]["InMineStationTime"].ToString()))
                                                    {
                                                        //添加到实时下井表中
                                                        if (!AddRtInMine(Convert.ToInt32(strCodeItem1), Convert.ToInt32(dvInMineStation[0]["stationHeadID"].ToString()), Convert.ToInt32(dvEmp[0]["csSetID"].ToString()), detecTime))
                                                            flag = false;
                                                        #region 【实时考勤】
                                                        ////Czlt-2011-03-24 测试代码
                                                        //strBuilder.AppendLine(" 添加到实时考勤表:" + strCodeItem1 + "," + dvInMineStation[0]["InMineStationTime"].ToString());
                                                        if (!AddRTEmployeeAttendance(detecTime, strCodeItem1))
                                                            flag = false;
                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        //添加到实时下井表中
                                                        if (!AddRtInMine(Convert.ToInt32(strCodeItem1), Convert.ToInt32(dvInMineStation[0]["stationHeadID"].ToString()), Convert.ToInt32(dvEmp[0]["csSetID"].ToString()), Convert.ToDateTime(dvInMineStation[0]["InMineStationTime"].ToString())))
                                                            flag = false;
                                                        #region 【实时考勤】
                                                        ////Czlt-2011-03-24 测试代码
                                                        //strBuilder.AppendLine(" 添加到实时考勤表:" + strCodeItem1 + "," + dvInMineStation[0]["InMineStationTime"].ToString());
                                                        if (!AddRTEmployeeAttendance(Convert.ToDateTime(dvInMineStation[0]["InMineStationTime"].ToString()), strCodeItem1))
                                                            flag = false;
                                                        #endregion

                                                    }
                                                }
                                            }
                                            catch { }
                                        }
                                        else  ///Czlt-12-17 老蔡添加井口分站没有检测到时,井下分站检测到了,也要加入实时考勤
                                        {
                                            //添加到实时下井表中
                                            ////Czlt-2011-03-24 测试代码
                                            //strBuilder.AppendLine(" 井口分站没有检测到,井下分站检测到时,添加到实时下井表中:" + strCodeItem1.ToString() + "," + dvInMineStation[0]["stationHeadID"].ToString() + "," + dvEmp[0]["csSetID"].ToString() + "," + dvInMineStation[0]["InMineStationTime"].ToString());

                                            //补漏--在 InMineStationInfo 表中没有数据的时候 找一条井下信息记录作为下井记录
                                            string strHeadId = GetStaHeadID();
                                            if (strHeadId.Equals(""))
                                            {
                                                if (!AddRtInMine(Convert.ToInt32(strCodeItem1), Convert.ToInt32(dtStationHead.Rows[0]["stationHeadID"].ToString()), Convert.ToInt32(dvEmp[0]["csSetID"].ToString()), detecTime))
                                                    flag = false;
                                            }
                                            else
                                            {
                                                if (!AddRtInMine(Convert.ToInt32(strCodeItem1), Convert.ToInt32(strHeadId), Convert.ToInt32(dvEmp[0]["csSetID"].ToString()), detecTime))
                                                    flag = false;
 
                                            }
                                            #region 【实时考勤】
                                            ////Czlt-2011-03-24 测试代码
                                            //strBuilder.AppendLine(" 井口分站没有检测到,井下分站检测到时,添加到实时考勤表:" + strCodeItem1 + "," + detecTime);

                                            if (!AddRTEmployeeAttendance(detecTime, strCodeItem1))
                                                flag = false;
                                            #endregion
                                        }
                                    }

                                    #endregion
                                    //}
                                }
                                else
                                {
                                    ////Czlt-2011-03-24 测试代码
                                    //strBuilder.AppendLine(" 没有配置人员的标识卡从实时下井表中删除:" + strCodeItem1);

                                    //删除实时下井信息
                                    if (!DeleteRtInMine(Convert.ToInt32(strCodeItem1)))
                                        flag = false;
                                }
                            }
                            catch (Exception exxxx)
                            {
                                flag = false;
                            }
                        }

                        #region 【实时巡检】
                        if (!AddRealTimePathCheck(detecTime, stationAddress, stationHeadAddress, strCodeSender))
                            flag = false;
                        #endregion
                        #endregion
                    }
                    #endregion

                    #region 【操作人员进出井超员信息】
                    if (!SaveOverEmp())
                        flag = false;
                    #endregion

                    #region 【操作进入读卡分站信息】

                    ////Czlt-2011-03-24 测试代码
                    //strBuilder.AppendLine(" 4.操作进入读卡分站信息:" + strCodeSender );

                    foreach (DataRow drItemCode in dtCodeSenderAddress.Rows)//传入的人员信息
                    {
                        //qyz 2012-5-17 判断是否离开井口分站
                        //DataTable rttemp = shine_GetRTInstationHeadTmep(drItemCode["CodeSenderAddress"].ToString());
                        //if (rttemp == null || rttemp.Rows.Count == 0)//实时临时表中不存在 井口分站信息，则不更新实时进出分站信息表
                        //{
                        //获取改卡中的实时标识卡信息
                        DataView dvRtInStation = new DataView(dtRtInStationHeadInfo, "CodeSenderAddress=" + drItemCode["CodeSenderAddress"].ToString(), "", DataViewRowState.CurrentRows);
                        if (dvRtInStation != null && dvRtInStation.Count > 0)//数据表中有实时标识卡信息
                        {
                            DateTime dtimeRtInStationHead = new DateTime(2000, 1, 1, 0, 0, 0);
                            try
                            {
                               // dtimeRtInStationHead = Convert.ToDateTime(dvRtInStation[0]["StationHeadTime"].ToString());
                                dtimeRtInStationHead = Convert.ToDateTime(dvRtInStation[0]["InStationHeadTime"].ToString());
                                
                            }
                            catch { }

                            //传入的时间比数据表中的时间大，则做修改
                            if (dtimeRtInStationHead.Equals(new DateTime(2000, 1, 1, 0, 0, 0)) || detecTime > dtimeRtInStationHead)
                            {
                                //获取该读卡分站的方向性信息
                                DataTable dtDirectional = GetCodeSenderDirectionalAntennaByAddress(stationAddress, stationHeadAddress);
                                string strDirectional = "";
                                if (dtDirectional != null && dtDirectional.Rows.Count > 0)
                                {
                                    DataTable dtStationHeadRT = GetStationHeadInfoByID(Convert.ToInt32(dvRtInStation[0]["StationHeadID"].ToString()));
                                    if (dtStationHeadRT != null && dtStationHeadRT.Rows.Count > 0)
                                    {
                                        if (stationAddress == Convert.ToInt32(dtStationHeadRT.Rows[0]["StationAddress"].ToString()) && stationHeadAddress == Convert.ToInt32(dtStationHeadRT.Rows[0]["StationHeadAddress"].ToString()))
                                        {
                                            strDirectional = dvRtInStation[0]["directional"].ToString();
                                        }
                                        else
                                        {
                                            DataView dvDirectional = new DataView(dtDirectional, "beginStationAddress=" + dtStationHeadRT.Rows[0]["StationAddress"].ToString() + " and beginStationHeadAddress=" + dtStationHeadRT.Rows[0]["StationHeadAddress"].ToString(), "", DataViewRowState.CurrentRows);
                                            if (dvDirectional != null && dvDirectional.Count > 0)
                                            {
                                                strDirectional = dvDirectional[0]["directional"].ToString();
                                            }
                                            else
                                                strDirectional = "";
                                        }
                                    }
                                    else
                                        strDirectional = "";
                                }
                                else
                                    strDirectional = "";

                                if (!UpdateRtInStationHead(dvRtInStation[0], dtStationHead.Rows[0], drItemCode, detecTime, 0, strDirectional))
                                    flag = false;
                            }
                        }
                        else//没有实时标识卡信息
                        {

                            ////Czlt-2011-03-24 测试代码
                            //strBuilder.AppendLine(" 没有实时信息的标识卡 添加实时信息:" + drItemCode["codeSenderAddress"].ToString() + "," + dtStationHead.Rows[0]["stationHeadID"]+","+detecTime);

                            //添加一条实时标识卡信息
                            if (!AddRtInStationHead(drItemCode, dtStationHead.Rows[0], detecTime, "", 0))
                                flag = false;
                        }
                        //}

                        //获取该卡的实时标识卡临时信息
                        DataView dvRtInStationTemp = new DataView(dtRtInStationHeadTemp, "CodeSenderAddress=" + drItemCode["CodeSenderAddress"].ToString(), "", DataViewRowState.CurrentRows);
                        if (dvRtInStationTemp != null && dvRtInStationTemp.Count > 0)
                        {
                            DataTable dtHisInStationHead = CreateHisInStationHead();//构造历史进出读卡分站表
                            DateTime dtimeInHisStationHead = new DateTime(2000, 1, 1, 0, 0, 0);
                            try
                            {
                                dtimeInHisStationHead = Convert.ToDateTime(dvRtInStationTemp[0]["InStationHeadTime"].ToString());
                            }
                            catch { }
                            if (!dtimeInHisStationHead.Equals(new DateTime(2000, 1, 1, 0, 0, 0)))
                            {
                                //添加到历史读卡分站中，并更新实时临时标志卡信息
                                if (!AddHisStationHeadInfo(Convert.ToInt32(drItemCode["CodeSenderAddress"].ToString()), dtHisInStationHead, dtStationHead, drItemCode, dtimeInHisStationHead.AddSeconds(5), dtimeInHisStationHead, isMend))
                                    flag = false;
                            }
                            //修改实时临时标识卡中信息
                            if (!UpdateRtInStationHeadTemp(drItemCode, dtStationHead.Rows[0], detecTime))
                                flag = false;
                        }
                        else
                        {
                            ////Czlt-2011-03-24 测试代码
                            //strBuilder.AppendLine(" 没有实时标识卡临时信的标识卡 添加实时临时信息:" + drItemCode["codeSenderAddress"].ToString() + "," + dtStationHead.Rows[0]["stationAddress"] + "," + dtStationHead.Rows[0]["StationHeadAddress"] + "," + detecTime );

                            //添加一条实时标识卡临时信息
                            if (!AddRtInStationHeadTemp(drItemCode, dtStationHead.Rows[0], detecTime))
                                flag = false;
                        }
                    }
                    #endregion
                }
            }
            else
            {
                //删除临时实时标识卡中数据
                if (!DeleteRtStationHeadTemp(stationAddress, stationHeadAddress))
                {
                    flag = false;
                }
            }

            ////Czlt-2011-03-24测试代码
            //strBuilder.AppendLine("");            
            //CreateFile(strBuilder.ToString(), strFileName);
            return flag;
        }
        #endregion

        #region 【方法：创建历史表及删除数据表】
        /// <summary>
        /// 创建历史表及删除数据表
        /// </summary>
        /// <param name="detecTime"></param>
        /// <returns></returns>
        private bool CreateHisTable(DateTime detecTime)
        {
            SqlParameter[] sqlParmeters = { 
                                              new SqlParameter("DetectTime", SqlDbType.DateTime)
                                          };
            sqlParmeters[0].Value = detecTime;

            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "CreateHistoryDataTable", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "CreateHistoryDataTable", sqlParmeters);
        }
        #endregion

        #region 【方法组：保存到数据库】



        #region 【方法：操作人员下井超员信息】
        /// <summary>
        /// 操作人员下井超员信息
        /// </summary>
        /// <returns></returns>
        private bool SaveOverEmp()
        {
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_InsertUpdateRealTimeOverEmp", null);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_InsertUpdateRealTimeOverEmp", null);
        }
        #endregion

        #region 【方法：保存传输分站状态】
        /// <summary>
        /// 保存传输分站状态
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <param name="stationState"></param>
        /// <param name="breakTime"></param>
        /// <returns></returns>
        private bool SaveStationState(int stationAddress, int stationHeadAddress, int stationState, DateTime breakTime)
        {
            SqlParameter[] sqlParmeters = { 
                                              new SqlParameter("StationAddress", SqlDbType.Int),
                                              new SqlParameter("StationHeadAddress", SqlDbType.Int),
                                              new SqlParameter("StationState", SqlDbType.Int),
                                              new SqlParameter("BreakTime", SqlDbType.DateTime)
                                          };
            sqlParmeters[0].Value = stationAddress;
            sqlParmeters[1].Value = stationHeadAddress;
            sqlParmeters[2].Value = stationState;
            sqlParmeters[3].Value = breakTime;

            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "Station_StateChange", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "Station_StateChange", sqlParmeters);
        }
        #endregion

        #region 【方法：保存读卡分站状态】
        /// <summary>
        /// 保存读卡分站状态
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <param name="stationState"></param>
        /// <param name="breakTime"></param>
        /// <returns></returns>
        private bool SaveStationHeadState(int stationAddress, int stationHeadAddress, int stationState, DateTime breakTime)
        {
            SqlParameter[] sqlParmeters = { 
                                              new SqlParameter("StationAddress", SqlDbType.Int),
                                              new SqlParameter("StationHeadAddress", SqlDbType.Int),
                                              new SqlParameter("StationState", SqlDbType.Int),
                                              new SqlParameter("BreakTime", SqlDbType.DateTime)
                                          };
            sqlParmeters[0].Value = stationAddress;
            sqlParmeters[1].Value = stationHeadAddress;
            sqlParmeters[2].Value = stationState;
            sqlParmeters[3].Value = breakTime;

            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "StationHead_StateChange", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "StationHead_StateChange", sqlParmeters);
        }
        #endregion

        #region 【方法：置标示卡状态为低电量】
        /// <summary>
        /// 置标识卡状态为低电量
        /// </summary>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private bool SaveCodeSenderStatebyLow(string strCards)
        {
            SqlParameter[] sqlParmeters = { 
                                              new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                          };
            sqlParmeters[0].Value = strCards;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "KJ128N_Update_CodeSenderLow", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "KJ128N_Update_CodeSenderLow", sqlParmeters);
        }
        #endregion

        #region 【方法：置标识卡状态为正常】
        /// <summary>
        /// 置标识卡状态为正常
        /// </summary>
        /// <param name="strCares"></param>
        /// <returns></returns>
        private bool SaveCodeSenderStateByOk(string strCards)
        {
            SqlParameter[] sqlParmeters = { 
                                              new SqlParameter("Cards", SqlDbType.VarChar,8000)
                                          };
            sqlParmeters[0].Value = strCards;

            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "Shine_Shen_Update_CodeSender_Common", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "Shine_Shen_Update_CodeSender_Common", sqlParmeters);
        }
        #endregion

        #region 【方法：添加一条进出读卡分站历史记录】
        private bool AddHisStationHeadInfo(int codeSenderAddress, DataTable dtHisInOutStationHead, DataTable dtStationHead, DataRowView drEmp, DateTime detecTime, DateTime dtimeInStationHeadTime, bool isMend)
        {
            DataRow drHis = dtHisInOutStationHead.NewRow();
            drHis["HisStationHeadID"] = Convert.ToInt64(DateTime.Now.ToString("yyMMddHHmmssfff") + Convert.ToInt32(drEmp["CodeSenderAddress"].ToString()).ToString("0000"));
            drHis["StationAddress"] = dtStationHead.Rows[0]["stationAddress"];
            drHis["StationHeadAddress"] = dtStationHead.Rows[0]["stationHeadAddress"];
            drHis["StationHeadPlace"] = dtStationHead.Rows[0]["StationHeadPlace"];
            drHis["CodeSenderAddress"] = drEmp["CodeSenderAddress"];
            drHis["CsTypeID"] = drEmp["CsTypeID"];
            drHis["UserID"] = drEmp["UserID"];
            drHis["UserNo"] = drEmp["UserNo"];
            drHis["UserName"] = drEmp["UserName"];
            drHis["DeptID"] = drEmp["DeptID"];
            drHis["DeptName"] = drEmp["DeptName"];
            drHis["DutyID"] = drEmp["DutyID"];
            drHis["DutyName"] = drEmp["DutyName"];
            drHis["WorkTypeID"] = drEmp["WorkTypeID"];
            drHis["WorkTypeName"] = drEmp["WorkTypeName"];
            drHis["InStationHeadTime"] = dtimeInStationHeadTime;
            drHis["OutStationHeadTime"] = detecTime;
            drHis["ContinueTime"] = Convert.ToInt32(((TimeSpan)(detecTime - dtimeInStationHeadTime)).TotalSeconds);
            drHis["IsMend"] = isMend;
            //添加到历史进出井记录中
            return AddHisStationHeadInfo(drHis, dtimeInStationHeadTime.ToString("yyyyM"));
        }

        private bool AddHisStationHeadInfo(int codeSenderAddress, DataTable dtHisInOutStationHead, DataTable dtStationHead, DataRow drEmp, DateTime detecTime, DateTime dtimeInStationHeadTime, bool isMend)
        {
            DataRow drHis = dtHisInOutStationHead.NewRow();
            drHis["HisStationHeadID"] = Convert.ToInt64(DateTime.Now.ToString("yyMMddHHmmssfff") + Convert.ToInt32(drEmp["CodeSenderAddress"].ToString()).ToString("0000"));
            drHis["StationAddress"] = dtStationHead.Rows[0]["stationAddress"];
            drHis["StationHeadAddress"] = dtStationHead.Rows[0]["stationHeadAddress"];
            drHis["StationHeadPlace"] = dtStationHead.Rows[0]["StationHeadPlace"];
            drHis["CodeSenderAddress"] = drEmp["CodeSenderAddress"];
            drHis["CsTypeID"] = drEmp["CsTypeID"];
            drHis["UserID"] = drEmp["UserID"];
            drHis["UserNo"] = drEmp["UserNo"];
            drHis["UserName"] = drEmp["UserName"];
            drHis["DeptID"] = drEmp["DeptID"];
            drHis["DeptName"] = drEmp["DeptName"];
            drHis["DutyID"] = drEmp["DutyID"];
            drHis["DutyName"] = drEmp["DutyName"];
            drHis["WorkTypeID"] = drEmp["WorkTypeID"];
            drHis["WorkTypeName"] = drEmp["WorkTypeName"];
            drHis["InStationHeadTime"] = dtimeInStationHeadTime;
            drHis["OutStationHeadTime"] = detecTime;
            drHis["ContinueTime"] = (int)(((TimeSpan)(detecTime - dtimeInStationHeadTime)).TotalSeconds);
            drHis["IsMend"] = isMend;
            //添加到历史进出井记录中
            return AddHisStationHeadInfo(drHis, dtimeInStationHeadTime.ToString("yyyyM"));
        }

        /// <summary>
        /// 添加一条历史进出读卡分站记录
        /// </summary>
        /// <param name="hisStationHeadID"></param>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <param name="stationHeadPlace"></param>
        /// <param name="codeSenderAddress"></param>
        /// <param name="csTypeID"></param>
        /// <param name="strUserNo"></param>
        /// <param name="strUserName"></param>
        /// <param name="deptID"></param>
        /// <param name="strDeptName"></param>
        /// <param name="dutyID"></param>
        /// <param name="strDutyName"></param>
        /// <param name="workTypeID"></param>
        /// <param name="strWorkTypeName"></param>
        /// <param name="strInStationHeadTime"></param>
        /// <param name="strOutStationHeadTime"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        private bool AddHisStationHeadInfo(DataRow drHis, string strTableName)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("HisStationHeadID",SqlDbType.BigInt),
                                                new SqlParameter("StationAddress",SqlDbType.Int),
                                                new SqlParameter("StationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("StationHeadPlace",SqlDbType.VarChar,50),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("CsTypeID",SqlDbType.Int),
                                                new SqlParameter("UserID",SqlDbType.Int),
                                                new SqlParameter("UserNo",SqlDbType.NVarChar,50),
                                                new SqlParameter("UserName",SqlDbType.NVarChar,20),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("DeptName",SqlDbType.NVarChar,50),
                                                new SqlParameter("DutyID",SqlDbType.Int),
                                                new SqlParameter("DutyName",SqlDbType.NVarChar,50),
                                                new SqlParameter("WorkTypeID",SqlDbType.Int),
                                                new SqlParameter("WorkTypeName",SqlDbType.NVarChar,50),
                                                new SqlParameter("InStationHeadTime",SqlDbType.NVarChar,50),
                                                new SqlParameter("OutStationHeadTime",SqlDbType.NVarChar,50),
                                                new SqlParameter("ContinueTime",SqlDbType.BigInt),
                                                new SqlParameter("IsMend",SqlDbType.Bit),
                                                new SqlParameter("TableName",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = drHis["HisStationHeadID"];
            sqlParmeters[1].Value = drHis["StationAddress"];
            sqlParmeters[2].Value = drHis["StationHeadAddress"];
            sqlParmeters[3].Value = drHis["StationHeadPlace"];
            sqlParmeters[4].Value = drHis["CodeSenderAddress"];
            sqlParmeters[5].Value = drHis["CsTypeID"];
            sqlParmeters[6].Value = drHis["UserID"];
            sqlParmeters[7].Value = drHis["UserNo"];
            sqlParmeters[8].Value = drHis["UserName"];
            sqlParmeters[9].Value = drHis["DeptID"];
            sqlParmeters[10].Value = drHis["DeptName"];
            sqlParmeters[11].Value = drHis["DutyID"];
            sqlParmeters[12].Value = drHis["DutyName"];
            sqlParmeters[13].Value = drHis["WorkTypeID"];
            sqlParmeters[14].Value = drHis["WorkTypeName"];
            sqlParmeters[15].Value = drHis["InStationHeadTime"];
            sqlParmeters[16].Value = drHis["OutStationHeadTime"];
            sqlParmeters[17].Value = drHis["ContinueTime"];
            sqlParmeters[18].Value = drHis["IsMend"];
            sqlParmeters[19].Value = strTableName;

            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_AddHistoryStationHead", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_AddHistoryStationHead", sqlParmeters);
        }
        #endregion

        #region 【方法：添加一条实时进出读卡分站记录】
        /// <summary>
        /// 添加实时进出读卡分站记录
        /// </summary>
        /// <param name="drEmp"></param>
        /// <param name="drStationHead"></param>
        /// <param name="detecTime"></param>
        /// <param name="strDirectional"></param>
        /// <param name="inOutFlag"></param>
        /// <returns></returns>
        private bool AddRtInStationHead(DataRow drEmp, DataRow drStationHead, DateTime detecTime, string strDirectional, int inOutFlag)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("codeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("stationHeadID",SqlDbType.Int),
                                                new SqlParameter("CsSetID",SqlDbType.Int),
                                                new SqlParameter("CsTypeID",SqlDbType.Int),
                                                new SqlParameter("UserID",SqlDbType.Int),
                                                new SqlParameter("InAntennaPlace",SqlDbType.VarChar,50),
                                                new SqlParameter("InStationHeadTime",SqlDbType.DateTime),
                                                new SqlParameter("stationHeadTime",SqlDbType.DateTime),
                                                new SqlParameter("Directional",SqlDbType.VarChar,50),
                                                new SqlParameter("inOutFlag",SqlDbType.SmallInt),
                                          };

            sqlParmeters[0].Value = drEmp["codeSenderAddress"];
            sqlParmeters[1].Value = drStationHead["stationHeadID"];
            sqlParmeters[2].Value = drEmp["CsSetID"];
            sqlParmeters[3].Value = drEmp["CsTypeID"];
            sqlParmeters[4].Value = drEmp["UserID"];
            sqlParmeters[5].Value = drStationHead["StationHeadPlace"];
            sqlParmeters[6].Value = detecTime;
            sqlParmeters[7].Value = detecTime;
            sqlParmeters[8].Value = strDirectional;
            sqlParmeters[9].Value = inOutFlag;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_AddRTInStationHeadInfo", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_AddRTInStationHeadInfo", sqlParmeters);
        }
        #endregion

        #region 【方法：更新实时进出读卡分站记录】
        /// <summary>
        /// 更新实时进出读卡分站记录
        /// </summary>
        /// <param name="drInStationHead"></param>
        /// <param name="drStationHead"></param>
        /// <param name="detctime"></param>
        /// <param name="inOutFlag"></param>
        /// <param name="strDirectional"></param>
        /// <returns></returns>
        private bool UpdateRtInStationHead(DataRowView drInStationHead, DataRow drStationHead, DataRow drEmp, DateTime detctime, int inOutFlag, string strDirectional)
        {
            drInStationHead.BeginEdit();
            drInStationHead["stationHeadID"] = drStationHead["stationHeadID"];
            drInStationHead["CsSetID"] = drEmp["CsSetID"];
            drInStationHead["CsTypeID"] = drEmp["CsTypeID"];
            drInStationHead["UserID"] = drEmp["UserID"];
            drInStationHead["InAntennaPlace"] = drStationHead["StationHeadPlace"];
            drInStationHead["InStationHeadTime"] = detctime;
            if (inOutFlag == 0)
            {
                drInStationHead["stationHeadTime"] = detctime;
            }
            drInStationHead["Directional"] = strDirectional;
            drInStationHead["inOutFlag"] = inOutFlag;
            drInStationHead.EndEdit();

            return UpdateRtInStationHead(drInStationHead);
        }

        private bool UpdateRtInStationHead(DataRowView drInStationHead, DataRow drStationHead, DataRowView drEmp, DateTime detctime, int inOutFlag, string strDirectional)
        {
            drInStationHead.BeginEdit();
            drInStationHead["stationHeadID"] = drStationHead["stationHeadID"];
            drInStationHead["CsSetID"] = drEmp["CsSetID"];
            drInStationHead["CsTypeID"] = drEmp["CsTypeID"];
            drInStationHead["UserID"] = drEmp["UserID"];
            drInStationHead["InAntennaPlace"] = drStationHead["StationHeadPlace"];
            drInStationHead["InStationHeadTime"] = detctime;
            if (inOutFlag == 0)
            {
                drInStationHead["stationHeadTime"] = detctime;
            }
            drInStationHead["Directional"] = strDirectional;
            drInStationHead["inOutFlag"] = inOutFlag;
            drInStationHead.EndEdit();

            return UpdateRtInStationHead(drInStationHead);
        }

        /// <summary>
        /// 更新实时进出读卡分站记录
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool UpdateRtInStationHead(DataRowView dr)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("codeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("stationHeadID",SqlDbType.Int),
                                                new SqlParameter("CsSetID",SqlDbType.Int),
                                                new SqlParameter("CsTypeID",SqlDbType.Int),
                                                new SqlParameter("UserID",SqlDbType.Int),
                                                new SqlParameter("InAntennaPlace",SqlDbType.VarChar,50),
                                                new SqlParameter("InStationHeadTime",SqlDbType.DateTime),
                                                new SqlParameter("stationHeadTime",SqlDbType.DateTime),
                                                new SqlParameter("Directional",SqlDbType.VarChar,50),
                                                new SqlParameter("inOutFlag",SqlDbType.SmallInt),
                                          };

            sqlParmeters[0].Value = dr["codeSenderAddress"];
            sqlParmeters[1].Value = dr["stationHeadID"];
            sqlParmeters[2].Value = dr["CsSetID"];
            sqlParmeters[3].Value = dr["CsTypeID"];
            sqlParmeters[4].Value = dr["UserID"];
            sqlParmeters[5].Value = dr["InAntennaPlace"];
            sqlParmeters[6].Value = dr["InStationHeadTime"];
            sqlParmeters[7].Value = dr["stationHeadTime"];
            sqlParmeters[8].Value = dr["Directional"];
            sqlParmeters[9].Value = dr["inOutFlag"];
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_UpdateRTInStationHeadInfo", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_UpdateRTInStationHeadInfo", sqlParmeters);
        }
        #endregion

        #region 【方法：更新求救信息】
        /// <summary>
        /// 更新求救信息
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <param name="strCards"></param>
        /// <param name="dtimeDecte"></param>
        /// <returns></returns>
        private bool UpdateRtEmpHelp(int stationAddress, int stationHeadAddress, string strCards, DateTime dtimeDecte)
        {
            SqlParameter[] sqlParmeters = { 
                                              new SqlParameter("DetecTime", SqlDbType.DateTime),
                                              new SqlParameter("StationAddress", SqlDbType.Int),
                                              new SqlParameter("StationHeadAddress", SqlDbType.Int),
                                              new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                              
                                          };
            sqlParmeters[0].Value = dtimeDecte;
            sqlParmeters[1].Value = stationAddress;
            sqlParmeters[2].Value = stationHeadAddress;
            sqlParmeters[3].Value = strCards;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "process_EmpHelpInfo", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0

            //return interHostBack.ExecuteSql(true, "process_EmpHelpInfo", sqlParmeters);
        }
        #endregion

        #region 【方法：添加人员到历史区域信息】
        /// <summary>
        /// 添加到历史区域信息操作
        /// </summary>
        /// <param name="dvRtAreas">要添加到历史区域信息中的实时区域表视图信息</param>
        /// <param name="dtEmp">传入的人员信息</param>
        /// <param name="detecTime">传入的时间</param>
        /// <returns></returns>
        private bool AddHisTerritorial(DataView dvRtAreas, DataTable dtEmp, DateTime detecTime, DataView dvRTTerOverTime)
        {
            bool flag = true;
            DataTable dtHisTerritorial = CreateHisInOutTerritorial();//创建历史区域表
            if (dtEmp != null && dtEmp.Rows.Count > 0 && dvRtAreas != null)
            {
                foreach (DataRowView drvTerrOverTime in dvRTTerOverTime)
                {
                    if (Convert.ToDateTime(drvTerrOverTime["StartOverTime"].ToString()) < detecTime)
                    {
                        DataView drEmps = new DataView(dtEmp, "cstypeid=0 and CodeSenderAddress=" + drvTerrOverTime["CodeSenderAddress"].ToString(), "", DataViewRowState.CurrentRows);
                        if (drEmps != null && drEmps.Count > 0)//有这个人员
                        {
                            if (!AddHisTerrOverTime(drvTerrOverTime, drEmps[0], detecTime))
                                flag = false;
                        }
                    }
                }

                foreach (DataRowView drv in dvRtAreas)
                {
                    if (Convert.ToDateTime(drv["InTerritorialTime"].ToString()) < detecTime)
                    {
                        DataView drEmps = new DataView(dtEmp, "cstypeid=0 and CodeSenderAddress=" + drv["CodeSenderAddress"].ToString(), "", DataViewRowState.CurrentRows);
                        if (drEmps != null && drEmps.Count > 0)//有这个人员
                        {
                            try
                            {
                                DataRow drHisTerr = dtHisTerritorial.NewRow();
                                drHisTerr["HisTerritorialID"] = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss") + Convert.ToInt32(drv["CodeSenderAddress"].ToString()).ToString("0000"));
                                drHisTerr["TerritorialID"] = drv["TerritorialID"];
                                drHisTerr["TerritorialName"] = drv["TerritorialName"];
                                drHisTerr["TerritorialTypeName"] = drv["TerritorialTypeName"];
                                drHisTerr["InTerritorialTime"] = drv["InTerritorialTime"];
                                drHisTerr["CodeSenderAddress"] = drEmps[0]["CodeSenderAddress"];
                                drHisTerr["UserID"] = drEmps[0]["UserID"];
                                drHisTerr["UserNo"] = drEmps[0]["UserNo"];
                                drHisTerr["UserName"] = drEmps[0]["UserName"];
                                drHisTerr["DeptID"] = drEmps[0]["DeptID"];
                                drHisTerr["DeptName"] = drEmps[0]["DeptName"];
                                drHisTerr["DutyID"] = drEmps[0]["DutyID"];
                                drHisTerr["DutyName"] = drEmps[0]["DutyName"];
                                drHisTerr["WorkTypeID"] = drEmps[0]["WorkTypeID"];
                                drHisTerr["WorkTypeName"] = drEmps[0]["WorkTypeName"];
                                drHisTerr["OutTerritorialTime"] = detecTime;
                                drHisTerr["ContinueTime"] = Convert.ToInt32(((TimeSpan)(detecTime - Convert.ToDateTime(drv["InTerritorialTime"].ToString()))).TotalSeconds);
                                drHisTerr["IsAlarm"] = drv["IsAlarm"].ToString();
                                //添加到历史区域表中
                                if (!AddHisTerritorial(drHisTerr, Convert.ToDateTime(drv["InTerritorialTime"].ToString()).ToString("yyyyM")))
                                    flag = false;
                            }
                            catch (Exception ee)
                            {
                                flag = false;
                            }
                        }
                        //删除实时信息
                        if (!DeleteRtTerritorial(Convert.ToInt32(drv["TerritorialID"].ToString()), Convert.ToInt32(drv["CodeSenderAddress"].ToString())))
                            flag = false;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 添加到历史区域信息（执行存储过程）
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        private bool AddHisTerritorial(DataRow dr, string strTableName)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("HisTerritorialID",SqlDbType.BigInt),
                                                new SqlParameter("TerritorialID",SqlDbType.Int),
                                                new SqlParameter("TerritorialName",SqlDbType.NVarChar,20),
                                                new SqlParameter("TerritorialTypeName",SqlDbType.NVarChar,20),
                                                new SqlParameter("InTerritorialTime",SqlDbType.DateTime),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("UserID",SqlDbType.Int),
                                                new SqlParameter("UserNo",SqlDbType.NVarChar,50),
                                                new SqlParameter("UserName",SqlDbType.NVarChar,20),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("DeptName",SqlDbType.NVarChar,50),
                                                new SqlParameter("DutyID",SqlDbType.Int),
                                                new SqlParameter("DutyName",SqlDbType.NVarChar,50),
                                                new SqlParameter("WorkTypeID",SqlDbType.Int),
                                                new SqlParameter("WorkTypeName",SqlDbType.NVarChar,50),
                                                new SqlParameter("OutTerritorialTime",SqlDbType.DateTime),
                                                new SqlParameter("ContinueTime",SqlDbType.BigInt),
                                                new SqlParameter("IsAlarm",SqlDbType.Bit),
                                                new SqlParameter("TableName",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = dr["HisTerritorialID"];
            sqlParmeters[1].Value = dr["TerritorialID"];
            sqlParmeters[2].Value = dr["TerritorialName"];
            sqlParmeters[3].Value = dr["TerritorialTypeName"];
            sqlParmeters[4].Value = dr["InTerritorialTime"];
            sqlParmeters[5].Value = dr["CodeSenderAddress"];
            sqlParmeters[6].Value = dr["UserID"];
            sqlParmeters[7].Value = dr["UserNo"];
            sqlParmeters[8].Value = dr["UserName"];
            sqlParmeters[9].Value = dr["DeptID"];
            sqlParmeters[10].Value = dr["DeptName"];
            sqlParmeters[11].Value = dr["DutyID"];
            sqlParmeters[12].Value = dr["DutyName"];
            sqlParmeters[13].Value = dr["WorkTypeID"];
            sqlParmeters[14].Value = dr["WorkTypeName"];
            sqlParmeters[15].Value = dr["OutTerritorialTime"];
            sqlParmeters[16].Value = dr["ContinueTime"];
            sqlParmeters[17].Value = dr["IsAlarm"];
            sqlParmeters[18].Value = strTableName;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_AddHistoryTerritorial", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_AddHistoryTerritorial", sqlParmeters);
        }
        #endregion

        #region 【方法：添加历史人员区域超时信息】
        /// <summary>
        /// 添加历史人员区域超时信息
        /// </summary>
        /// <param name="drvTerOverTime"></param>
        /// <param name="drvEmp"></param>
        /// <returns></returns>
        private bool AddHisTerrOverTime(DataRowView drvTerOverTime, DataRowView drvEmp, DateTime detecTime)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("HisTerEmpOverTimeID",SqlDbType.BigInt),
                                                new SqlParameter("TerritorialID",SqlDbType.Int),
                                                new SqlParameter("TerritorialName",SqlDbType.NVarChar,20),
                                                new SqlParameter("TerritorialTypeName",SqlDbType.NVarChar,20),
                                                new SqlParameter("InTerritorialTime",SqlDbType.DateTime),
                                                new SqlParameter("StartOverTime",SqlDbType.DateTime),
                                                new SqlParameter("TerWorkTime",SqlDbType.Int),
                                                new SqlParameter("OutTerritorialTime",SqlDbType.DateTime),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.NVarChar,20),
                                                new SqlParameter("EmpID",SqlDbType.Int),
                                                new SqlParameter("EmpName",SqlDbType.NVarChar,50),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("DeptName",SqlDbType.NVarChar,20),
                                                new SqlParameter("WtName",SqlDbType.NVarChar,50)
                                          };

            sqlParmeters[0].Value = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss") + Convert.ToInt32(drvEmp["CodeSenderAddress"].ToString()).ToString("0000")); ;
            sqlParmeters[1].Value = drvTerOverTime["TerritorialID"];
            sqlParmeters[2].Value = drvTerOverTime["TerritorialName"];
            sqlParmeters[3].Value = drvTerOverTime["TerritorialTypeName"];
            sqlParmeters[4].Value = drvTerOverTime["InTerritorialTime"];
            sqlParmeters[5].Value = drvTerOverTime["StartOverTime"];
            sqlParmeters[6].Value = Convert.ToInt32(((TimeSpan)(detecTime - Convert.ToDateTime(drvTerOverTime["StartOverTime"].ToString()))).TotalSeconds);
            sqlParmeters[7].Value = detecTime;
            sqlParmeters[8].Value = drvEmp["CodeSenderAddress"];
            sqlParmeters[9].Value = drvEmp["UserID"];
            sqlParmeters[10].Value = drvEmp["UserName"];
            sqlParmeters[11].Value = drvEmp["DeptID"];
            sqlParmeters[12].Value = drvEmp["DeptName"];
            sqlParmeters[13].Value = drvEmp["WorkTypeName"];
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_InsertHisTerOverTime", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_InsertHisTerOverTime", sqlParmeters);
        }
        #endregion

        #region 【方法：添加人员到实时区域信息】
        /// <summary>
        /// 添加人员到实时区域信息
        /// </summary>
        /// <param name="strCode">要添加到实时区域表中的卡号信息</param>
        /// <param name="dtEmp">人员信息</param>
        /// <param name="drArea">区域信息</param>
        /// <param name="detecTime">日期</param>
        /// <param name="isAlarm">是否报警</param>
        /// <returns></returns>
        private bool AddRtTerritorial(string strCode, DataTable dtEmp, DataRowView drArea, DateTime detecTime, DataTable dtSworktype)
        {
            bool flag = true;
            string[] strCodeTemp = strCode.Split(',');
            bool isAlarm = false;

            foreach (string strItem in strCodeTemp)
            {
                DataView dvEmp = new DataView(dtEmp, "cstypeid=0 and CodeSenderAddress=" + strItem, "", DataViewRowState.CurrentRows);
                if (dvEmp != null && dvEmp.Count > 0)
                {
                    try
                    {
                        DataView dvSworktype = new DataView(dtSworktype, "TerrialID=" + drArea["TerritorialID"].ToString() + " and WorkTypeID=" + dvEmp[0]["WorkTypeID"].ToString(), "", DataViewRowState.CurrentRows);
                        if (dvSworktype != null && dvSworktype.Count > 0)
                            isAlarm = true;
                        else
                            isAlarm = false;
                    }
                    catch { }
                    if (!AddRtTerritorial(Convert.ToInt32(drArea["TerritorialID"].ToString()), drArea["TerritorialName"].ToString(), detecTime, Convert.ToInt32(strItem), Convert.ToInt32(dvEmp[0]["CsSetID"].ToString()), Convert.ToInt32(dvEmp[0]["CsTypeID"].ToString()), Convert.ToInt32(dvEmp[0]["UserID"].ToString()), drArea["TypeName"].ToString(), isAlarm))
                        flag = false;
                }
            }
            return flag;
        }

        private bool AddRtTerritorial(int territorialID, string strTerritorialName, DateTime inTerritorialTime, int codeSenderAddress, int csSetID, int csTypeID, int userID, string strTerritorialTypeName, bool isAlarm)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("TerritorialID",SqlDbType.Int),
                                                new SqlParameter("TerritorialName",SqlDbType.NVarChar,20),
                                                new SqlParameter("InTerritorialTime",SqlDbType.DateTime),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("CsSetID",SqlDbType.Int),
                                                new SqlParameter("CsTypeID",SqlDbType.Int),
                                                new SqlParameter("UserID",SqlDbType.Int),
                                                new SqlParameter("TerritorialTypeName",SqlDbType.NVarChar,20),
                                                new SqlParameter("IsAlarm",SqlDbType.Bit),
                                          };

            sqlParmeters[0].Value = territorialID;
            sqlParmeters[1].Value = strTerritorialName;
            sqlParmeters[2].Value = inTerritorialTime;
            sqlParmeters[3].Value = codeSenderAddress;
            sqlParmeters[4].Value = csSetID;
            sqlParmeters[5].Value = csTypeID;
            sqlParmeters[6].Value = userID;
            sqlParmeters[7].Value = strTerritorialTypeName;
            sqlParmeters[8].Value = isAlarm;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_AddRTAreaInfo", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_AddRTAreaInfo", sqlParmeters);
        }
        #endregion

        #region 【方法：添加到历史超时信息】
        /// <summary>
        /// 添加到历史超时信息
        /// </summary>
        /// <param name="detecTime"></param>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private bool AddHisOverTimeEmployee(DateTime detecTime, string strCards)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("DetectTime",SqlDbType.DateTime),
                                                new SqlParameter("Cards",SqlDbType.VarChar,6000)
                                          };

            sqlParmeters[0].Value = detecTime;
            sqlParmeters[1].Value = strCards;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_InsertHisOverTimeEmployee", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_InsertHisOverTimeEmployee", sqlParmeters);
        }
        #endregion

        #region 【方法：操作区域超员信息】
        /// <summary>
        /// 操作区域超员信息
        /// </summary>
        /// <param name="detecTime"></param>
        /// <returns></returns>
        private bool OperatorTerOverEmp(DateTime detecTime)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("DetectTime",SqlDbType.DateTime)
                                          };

            sqlParmeters[0].Value = detecTime;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "OperatorTerOverEmp", sqlParmeters);
            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "OperatorTerOverEmp", sqlParmeters);
        }
        #endregion

        #region 【方法：添加到实时巡检路线信息】
        private bool AddRealTimePathCheck(DateTime detecTime, int stationAddress, int stationHeadAddress, string strCards)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("DetecTime",SqlDbType.DateTime),
                                                new SqlParameter("StationAddress",SqlDbType.Int),
                                                new SqlParameter("StationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("Cards",SqlDbType.VarChar,6000)
                                          };

            sqlParmeters[0].Value = detecTime;
            sqlParmeters[1].Value = stationAddress;
            sqlParmeters[2].Value = stationHeadAddress;
            sqlParmeters[3].Value = strCards;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "insertRealTimePathCheck", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "insertRealTimePathCheck", sqlParmeters);
        }
        #endregion

        #region 【方法：保存到实时超速欠速报警信息】
        /// <summary>
        /// 操作区域超员信息
        /// </summary>
        /// <param name="detecTime"></param>
        /// <returns></returns>
        private bool AddRTOverSpeed(DateTime detecTime, int stationAddress, int stationHeadAddress, string strCards)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("DetectTime",SqlDbType.DateTime),
                                                new SqlParameter("StationAddress",SqlDbType.Int),
                                                new SqlParameter("StationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("Cards",SqlDbType.VarChar,6000)
                                          };

            sqlParmeters[0].Value = detecTime;
            sqlParmeters[1].Value = stationAddress;
            sqlParmeters[2].Value = stationHeadAddress;
            sqlParmeters[3].Value = strCards;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_InsertRTOverSpeed", sqlParmeters);
            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_InsertRTOverSpeed", sqlParmeters);
        }
        #endregion

        #region 【方法：修改历史超速、欠速信息】
        /// <summary>
        /// 修改历史超速、欠速信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private bool UpdateHisOverSpeed(string strCards)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("Cards",SqlDbType.VarChar,6000)
                                          };

            sqlParmeters[0].Value = strCards;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_UpdateHisOverSpeed", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_UpdateHisOverSpeed", sqlParmeters);
        }
        #endregion

        #region 【方法：删除区域超员信息】
        /// <summary>
        /// 删除区域超员信息
        /// </summary>
        /// <returns></returns>
        private bool DeleteTerOverEmp()
        {
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_DeleteTerOverEmp", null);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_DeleteTerOverEmp", null);
        }
        #endregion

        #region 【方法：添加人员到历史进出井信息】
        private bool AddHisInOutMine(DataRowView drRtInMine, DataRowView drEmp, DateTime detecTime, DataRow drOutStationHead, bool isMend)
        {
            bool flag = true;
            DataTable dtHisInOutMine = CreateHisInOutMine();
            DataRow drHisInOutMine = dtHisInOutMine.NewRow();

            DataTable dtInMineStationHead = GetStationHeadInfoByID(Convert.ToInt32(drRtInMine["stationHeadID"].ToString()));//获取进井读卡分站信息




            if (dtInMineStationHead != null && dtInMineStationHead.Rows.Count > 0)
            {
                drHisInOutMine["HisInOutMineID"] = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss") + Convert.ToInt32(drRtInMine["CodeSenderAddress"].ToString()).ToString("0000")); ;
                drHisInOutMine["InStationAddress"] = dtInMineStationHead.Rows[0]["StationAddress"];
                drHisInOutMine["InStationHeadAddress"] = dtInMineStationHead.Rows[0]["StationHeadAddress"];
                drHisInOutMine["InWellPlace"] = dtInMineStationHead.Rows[0]["StationHeadPlace"];
                drHisInOutMine["CodeSenderAddress"] = drRtInMine["CodeSenderAddress"];
                drHisInOutMine["UserID"] = drEmp["UserID"];
                drHisInOutMine["UserNo"] = drEmp["UserNo"];
                drHisInOutMine["UserName"] = drEmp["UserName"];
                drHisInOutMine["DeptID"] = drEmp["DeptID"];
                drHisInOutMine["DeptName"] = drEmp["DeptName"];
                drHisInOutMine["DutyID"] = drEmp["DutyID"];
                drHisInOutMine["DutyName"] = drEmp["DutyName"];
                drHisInOutMine["WorkTypeID"] = drEmp["WorkTypeID"];
                drHisInOutMine["WorkTypeName"] = drEmp["WorkTypeName"];
                drHisInOutMine["InTime"] = drRtInMine["InTime"];
                drHisInOutMine["OutStationAddress"] = drOutStationHead["StationAddress"];
                drHisInOutMine["OutStationHeadAddress"] = drOutStationHead["StationHeadAddress"];
                drHisInOutMine["OutWellPlace"] = drOutStationHead["StationHeadPlace"];
                drHisInOutMine["OutTime"] = detecTime;
                drHisInOutMine["ContinueTime"] = Convert.ToInt32(((TimeSpan)(detecTime - Convert.ToDateTime(drRtInMine["InTime"].ToString()))).TotalSeconds);
                drHisInOutMine["IsMend"] = isMend;

                if (!AddHisInOutMine(drHisInOutMine, Convert.ToDateTime(drRtInMine["InTime"].ToString()).ToString("yyyyM")))
                    flag = false;
            }

            //删除该条实时下井人员信息
            if (!DeleteRtInMine(Convert.ToInt32(drRtInMine["CodeSenderAddress"].ToString())))
                flag = false;

            return flag;
        }

        private bool AddHisInOutMine(DataRow drHisInOutMine, string strTableName)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("HisInOutMineID",SqlDbType.BigInt),
                                                new SqlParameter("InStationAddress",SqlDbType.Int),
                                                new SqlParameter("InStationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("InWellPlace",SqlDbType.NVarChar,50),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("UserID",SqlDbType.Int),
                                                new SqlParameter("UserNo",SqlDbType.NVarChar,50),
                                                new SqlParameter("UserName",SqlDbType.NVarChar,20),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("DeptName",SqlDbType.NVarChar,50),
                                                new SqlParameter("DutyID",SqlDbType.Int),
                                                new SqlParameter("DutyName",SqlDbType.NVarChar,50),
                                                new SqlParameter("WorkTypeID",SqlDbType.Int),
                                                new SqlParameter("WorkTypeName",SqlDbType.NVarChar,50),
                                                new SqlParameter("InTime",SqlDbType.DateTime),
                                                new SqlParameter("OutStationAddress",SqlDbType.Int),
                                                new SqlParameter("OutStationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("OutWellPlace",SqlDbType.NVarChar,50),
                                                new SqlParameter("OutTime",SqlDbType.DateTime),
                                                new SqlParameter("ContinueTime",SqlDbType.BigInt),
                                                new SqlParameter("IsMend",SqlDbType.Bit),
                                                new SqlParameter("TableName",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = drHisInOutMine["HisInOutMineID"];
            sqlParmeters[1].Value = drHisInOutMine["InStationAddress"];
            sqlParmeters[2].Value = drHisInOutMine["InStationHeadAddress"];
            sqlParmeters[3].Value = drHisInOutMine["InWellPlace"];
            sqlParmeters[4].Value = drHisInOutMine["CodeSenderAddress"];
            sqlParmeters[5].Value = drHisInOutMine["UserID"];
            sqlParmeters[6].Value = drHisInOutMine["UserNo"];
            sqlParmeters[7].Value = drHisInOutMine["UserName"];
            sqlParmeters[8].Value = drHisInOutMine["DeptID"];
            sqlParmeters[9].Value = drHisInOutMine["DeptName"];
            sqlParmeters[10].Value = drHisInOutMine["DutyID"];
            sqlParmeters[11].Value = drHisInOutMine["DutyName"];
            sqlParmeters[12].Value = drHisInOutMine["WorkTypeID"];
            sqlParmeters[13].Value = drHisInOutMine["WorkTypeName"];
            sqlParmeters[14].Value = drHisInOutMine["InTime"];
            sqlParmeters[15].Value = drHisInOutMine["OutStationAddress"];
            sqlParmeters[16].Value = drHisInOutMine["OutStationHeadAddress"];
            sqlParmeters[17].Value = drHisInOutMine["OutWellPlace"];
            sqlParmeters[18].Value = drHisInOutMine["OutTime"];
            sqlParmeters[19].Value = drHisInOutMine["ContinueTime"];
            sqlParmeters[20].Value = drHisInOutMine["IsMend"];
            sqlParmeters[21].Value = strTableName;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_AddHisInOutMine", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_AddHisInOutMine", sqlParmeters);
        }
        #endregion

        #region 【方法：添加进入井口分站信息】
        /// <summary>
        /// 添加进入井口分站信息
        /// </summary>
        /// <param name="stationHeadID"></param>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <param name="codeSenderAddress"></param>
        /// <param name="dectime"></param>
        /// <returns></returns>
        private bool AddInMineStation(int stationHeadID, int stationAddress, int stationHeadAddress, int codeSenderAddress, DateTime dectime)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("StationHeadID",SqlDbType.Int),
                                                new SqlParameter("@stationAddress",SqlDbType.Int),
                                                new SqlParameter("@stationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("@CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("@InMineStationTime",SqlDbType.DateTime)
                                          };

            sqlParmeters[0].Value = stationHeadID;
            sqlParmeters[1].Value = stationAddress;
            sqlParmeters[2].Value = stationHeadAddress;
            sqlParmeters[3].Value = codeSenderAddress;
            sqlParmeters[4].Value = dectime;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_AddInMineStationInfo", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_AddInMineStationInfo", sqlParmeters);
        }
        #endregion

        #region 【方法：更新进入井口分站信息】
        /// <summary>
        /// 更新进入井口分站信息
        /// </summary>
        /// <param name="stationHeadID"></param>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <param name="codeSenderAddress"></param>
        /// <param name="dectime"></param>
        /// <returns></returns>
        private bool UpdateInMineStation(int stationHeadID, int stationAddress, int stationHeadAddress, int codeSenderAddress, DateTime dectime)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("StationHeadID",SqlDbType.Int),
                                                new SqlParameter("@stationAddress",SqlDbType.Int),
                                                new SqlParameter("@stationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("@CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("@InMineStationTime",SqlDbType.DateTime)
                                          };

            sqlParmeters[0].Value = stationHeadID;
            sqlParmeters[1].Value = stationAddress;
            sqlParmeters[2].Value = stationHeadAddress;
            sqlParmeters[3].Value = codeSenderAddress;
            sqlParmeters[4].Value = dectime;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_UpdateInMineStationInfo", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_UpdateInMineStationInfo", sqlParmeters);
        }
        #endregion

        #region 【方法：添加实时下井人员信息】
        /// <summary>
        /// 更新实时下井人员信息
        /// </summary>
        /// <param name="codeSenderAddress"></param>
        /// <param name="stationHeadID"></param>
        /// <param name="csSetID"></param>
        /// <param name="inTime"></param>
        /// <returns></returns>
        private bool AddRtInMine(int codeSenderAddress, int stationHeadID, int csSetID, DateTime inTime)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("StationHeadID",SqlDbType.Int),
                                                new SqlParameter("CsSetID",SqlDbType.Int),
                                                new SqlParameter("InTime",SqlDbType.DateTime),
                                          };

            sqlParmeters[0].Value = codeSenderAddress;
            sqlParmeters[1].Value = stationHeadID;
            sqlParmeters[2].Value = csSetID;
            sqlParmeters[3].Value = inTime;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_AddRTInMine", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_AddRTInMine", sqlParmeters);
        }
        #endregion

        #region 【方法：删除实时下井人员信息】
        /// <summary>
        /// 删除实时下井人员信息
        /// </summary>
        /// <param name="codeSenderAddress"></param>
        /// <returns></returns>
        private bool DeleteRtInMine(int codeSenderAddress)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int)
                                          };
            sqlParmeters[0].Value = codeSenderAddress;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_DeleteRTInMine", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_DeleteRTInMine", sqlParmeters);
        }
        #endregion

        #region 【方法：更新实时下井人员信息】
        /// <summary>
        /// 更新实时下井人员信息
        /// </summary>
        /// <param name="codeSenderAddress"></param>
        /// <param name="stationHeadID"></param>
        /// <param name="csSetID"></param>
        /// <param name="inTime"></param>
        /// <returns></returns>
        private bool UpdateRtInMine(int codeSenderAddress, int stationHeadID, int csSetID, DateTime inTime)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("StationHeadID",SqlDbType.Int),
                                                new SqlParameter("CsSetID",SqlDbType.Int),
                                                new SqlParameter("InTime",SqlDbType.DateTime),
                                          };

            sqlParmeters[0].Value = codeSenderAddress;
            sqlParmeters[1].Value = stationHeadID;
            sqlParmeters[2].Value = csSetID;
            sqlParmeters[3].Value = inTime;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_UpdateRTInMine", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_UpdateRTInMine", sqlParmeters);
        }
        #endregion

        #region 【方法：删除实时区域信息】
        /// <summary>
        /// 删除所有的实时区域信息
        /// </summary>
        /// <returns></returns>
        private bool DeleteRtTerritorial()
        {
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_DeleteRtTerritorialAll", null);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_DeleteRtTerritorialAll", null);
        }

        /// <summary>
        /// 按照区域编号和标识卡删除实时区域信息
        /// </summary>
        /// <param name="territorialID"></param>
        /// <param name="codeSenderAddress"></param>
        /// <returns></returns>
        private bool DeleteRtTerritorial(int territorialID, int codeSenderAddress)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("TerritorialID",SqlDbType.Int),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int)
                                          };
            sqlParmeters[0].Value = territorialID;
            sqlParmeters[1].Value = codeSenderAddress;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_DeleteRtTerritorialByValue", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_DeleteRtTerritorialByValue", sqlParmeters);
        }
        #endregion

        #region 【方法：添加临时实时标识卡信息】
        /// <summary>
        /// 添加临时实时标识卡信息
        /// </summary>
        /// <param name="drEmp"></param>
        /// <param name="drStationHead"></param>
        /// <param name="detecTime"></param>
        /// <returns></returns>
        private bool AddRtInStationHeadTemp(DataRow drEmp, DataRow drStationHead, DateTime detecTime)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("codeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("stationAddress",SqlDbType.Int),
                                                new SqlParameter("StationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("csSetID",SqlDbType.Int),
                                                new SqlParameter("csTypeID",SqlDbType.Int),
                                                new SqlParameter("UserID",SqlDbType.Int),
                                                new SqlParameter("InStationHeadTime",SqlDbType.DateTime),
                                          };

            sqlParmeters[0].Value = drEmp["codeSenderAddress"];
            sqlParmeters[1].Value = drStationHead["stationAddress"];
            sqlParmeters[2].Value = drStationHead["StationHeadAddress"];
            sqlParmeters[3].Value = drEmp["csSetID"];
            sqlParmeters[4].Value = drEmp["csTypeID"];
            sqlParmeters[5].Value = drEmp["UserID"];
            sqlParmeters[6].Value = detecTime;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_AddRtInStationHeadTemp", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_AddRtInStationHeadTemp", sqlParmeters);
        }
        #endregion

        #region 【方法：修改临时实时标识卡信息】
        /// <summary>
        /// 修改临时实时标识卡信息
        /// </summary>
        /// <param name="drEmp"></param>
        /// <param name="drStationHead"></param>
        /// <param name="detecTime"></param>
        /// <returns></returns>
        private bool UpdateRtInStationHeadTemp(DataRow drEmp, DataRow drStationHead, DateTime detecTime)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("codeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("stationAddress",SqlDbType.Int),
                                                new SqlParameter("StationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("csSetID",SqlDbType.Int),
                                                new SqlParameter("csTypeID",SqlDbType.Int),
                                                new SqlParameter("UserID",SqlDbType.Int),
                                                new SqlParameter("InStationHeadTime",SqlDbType.DateTime),
                                          };

            sqlParmeters[0].Value = drEmp["codeSenderAddress"];
            sqlParmeters[1].Value = drStationHead["stationAddress"];
            sqlParmeters[2].Value = drStationHead["StationHeadAddress"];
            sqlParmeters[3].Value = drEmp["csSetID"];
            sqlParmeters[4].Value = drEmp["csTypeID"];
            sqlParmeters[5].Value = drEmp["UserID"];
            sqlParmeters[6].Value = detecTime;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_UpdateRtInStationHeadTemp", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_UpdateRtInStationHeadTemp", sqlParmeters);
        }
        #endregion

        #region 【方法：删除临时实时标识卡中的数据】
        /// <summary>
        /// 删除临时实时标识卡中的数据
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <returns></returns>
        private bool DeleteRtStationHeadTemp(int stationAddress, int stationHeadAddress)
        {
            SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("stationAddress", SqlDbType.Int) ,
                                                  new SqlParameter("StationHeadAddress",SqlDbType.Int)
                                              };
            sqlParmeters[0].Value = stationAddress;
            sqlParmeters[1].Value = stationHeadAddress;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_DeleteRtInStationHeadTemp", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_DeleteRtInStationHeadTemp", sqlParmeters);
        }
        #endregion

        #region 【方法：删除临时实时标识卡中的数据】
        /// <summary>
        /// 删除临时实时标识卡中的数据
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <returns></returns>
        private bool DeleteRtStationHeadTemp(int stationAddress, int stationHeadAddress, string strCards)
        {
            SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("stationAddress", SqlDbType.Int) ,
                                                  new SqlParameter("StationHeadAddress",SqlDbType.Int),
                                                  new SqlParameter("Cards",SqlDbType.VarChar,6000)
                                              };
            sqlParmeters[0].Value = stationAddress;
            sqlParmeters[1].Value = stationHeadAddress;
            sqlParmeters[2].Value = strCards;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_DeleteRtInStationHeadTempByCards", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_DeleteRtInStationHeadTempByCards", sqlParmeters);
        }

        /// <summary>
        /// 删除临时实时标识卡中的数据
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <returns></returns>
        private bool DeleteRtStationHeadTemp(int stationAddress, int stationHeadAddress, int codeSenderAddress)
        {
            SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("stationAddress", SqlDbType.Int) ,
                                                  new SqlParameter("StationHeadAddress",SqlDbType.Int),
                                                  new SqlParameter("codeSenderAddress",SqlDbType.Int)
                                              };
            sqlParmeters[0].Value = stationAddress;
            sqlParmeters[1].Value = stationHeadAddress;
            sqlParmeters[2].Value = codeSenderAddress;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_DeleteRtInStationHeadTempByID", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_DeleteRtInStationHeadTempByID", sqlParmeters);
        }
        #endregion

        #region 【方法：添加到实时考勤数据中】
        /// <summary>
        /// 添加到实时考勤数据
        /// </summary>
        /// <param name="detecTime"></param>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private bool AddRTEmployeeAttendance(DateTime detecTime, string strCards)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("DetectTime",SqlDbType.DateTime),
                                                new SqlParameter("Cards",SqlDbType.VarChar,6000)
                                          };

            sqlParmeters[0].Value = detecTime;
            sqlParmeters[1].Value = strCards;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_InsertRTEmployeeAttendance", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_InsertRTEmployeeAttendance", sqlParmeters);
        }
        #endregion

        #region 【方法：删除实时考勤数据】
        /// <summary>
        /// 删除实时考勤数据
        /// </summary>
        /// <param name="codeSenderAddress"></param>
        /// <returns></returns>
        private bool DelteteRealTimeAttendance(int codeSenderAddress)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int)
                                          };
            sqlParmeters[0].Value = codeSenderAddress;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_DeleteRealTimeAttendanceByCodeSenderAddress", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_DeleteRealTimeAttendanceByCodeSenderAddress", sqlParmeters);
        }
        #endregion

        #region 【方法：添加历史考勤信息】
        /// <summary>
        /// 添加历史考勤信息
        /// </summary>
        /// <param name="drRtAttendance"></param>
        /// <param name="detecTime"></param>
        /// <returns></returns>
        private bool AddHisAttendance(DataRowView drRtAttendance, DateTime detecTime, bool isMend)
        {
            DataTable dtHis = CreateHisAttendance();
            DataRow drHis = dtHis.NewRow();
            drHis["ID"] = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss") + Convert.ToInt32(drRtAttendance["CodeSenderAddress"].ToString()).ToString("0000"));
            drHis["BlockID"] = drRtAttendance["CodeSenderAddress"];
            drHis["EmployeeID"] = drRtAttendance["UserID"];
            drHis["EmployeeName"] = drRtAttendance["UserName"];
            drHis["DeptID"] = drRtAttendance["DeptID"];
            drHis["ClassID"] = drRtAttendance["ClassID"];
            drHis["ClassShortName"] = drRtAttendance["ClassShortName"];
            drHis["BeginWorkTime"] = drRtAttendance["BeginWorkTime"];
            drHis["EndWorkTime"] = detecTime;
            drHis["WorkTime"] = Convert.ToInt32(((TimeSpan)(detecTime - Convert.ToDateTime(drRtAttendance["BeginWorkTime"].ToString()))).TotalSeconds);
            drHis["TimerIntervalID"] = drRtAttendance["TimerIntervalID"];
            drHis["DataAttendance"] = drRtAttendance["DataAttendance"];
            drHis["IsMend"] = isMend;

            return AddHisAttendance(drHis, Convert.ToDateTime(drRtAttendance["DataAttendance"].ToString()).ToString("yyyyM"));
        }


        /// <summary>
        /// 添加到历史考勤信息
        /// </summary>
        /// <param name="drHis"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        private bool AddHisAttendance(DataRow drHis, string strTableName)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("ID",SqlDbType.BigInt),
                                                new SqlParameter("BlockID",SqlDbType.Int),
                                                new SqlParameter("EmployeeID",SqlDbType.Int),
                                                new SqlParameter("EmployeeName",SqlDbType.NVarChar,50),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("ClassID",SqlDbType.VarChar,20),
                                                new SqlParameter("ClassShortName",SqlDbType.VarChar,10),
                                                new SqlParameter("BeginWorkTime",SqlDbType.VarChar,50),
                                                new SqlParameter("EndWorkTime",SqlDbType.VarChar,50),
                                                new SqlParameter("WorkTime",SqlDbType.Int),
                                                new SqlParameter("TimerIntervalID",SqlDbType.Int),
                                                new SqlParameter("DataAttendance",SqlDbType.VarChar,50),
                                                new SqlParameter("IsMend",SqlDbType.Bit),
                                                new SqlParameter("TableName",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = drHis["ID"];
            sqlParmeters[1].Value = drHis["BlockID"];
            sqlParmeters[2].Value = drHis["EmployeeID"];
            sqlParmeters[3].Value = drHis["EmployeeName"];
            sqlParmeters[4].Value = drHis["DeptID"];
            sqlParmeters[5].Value = drHis["ClassID"];
            sqlParmeters[6].Value = drHis["ClassShortName"];
            sqlParmeters[7].Value = drHis["BeginWorkTime"];
            sqlParmeters[8].Value = drHis["EndWorkTime"];
            sqlParmeters[9].Value = drHis["WorkTime"];
            sqlParmeters[10].Value = drHis["TimerIntervalID"];
            sqlParmeters[11].Value = drHis["DataAttendance"];
            sqlParmeters[12].Value = drHis["IsMend"];
            sqlParmeters[13].Value = strTableName;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_AddHisAttendance", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_AddHisAttendance", sqlParmeters);
        }
        #endregion

        #region 【方法：添加考勤统计记录】
        /// <summary>
        /// 添加考勤统计记录
        /// </summary>
        /// <param name="dataAttendance"></param>
        /// <param name="codeSenderAddress"></param>
        /// <param name="strEmpName"></param>
        /// <param name="deptID"></param>
        /// <param name="strDeptName"></param>
        /// <returns></returns>
        private bool AddKQTJ(DateTime dataAttendance, int codeSenderAddress, string strEmpName, int deptID, string strDeptName)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("dataAttendance",SqlDbType.DateTime),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("EmpName",SqlDbType.VarChar,20),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("DeptName",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = dataAttendance;
            sqlParmeters[1].Value = codeSenderAddress;
            sqlParmeters[2].Value = strEmpName;
            sqlParmeters[3].Value = deptID;
            sqlParmeters[4].Value = strDeptName;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_InsertKQTJ", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_InsertKQTJ", sqlParmeters);
        }
        #endregion

        #region 【方法：修改考勤统计记录】
        /// <summary>
        /// 修改考勤统计记录
        /// </summary>
        /// <param name="dataAttendance"></param>
        /// <param name="codeSenderAddress"></param>
        /// <param name="strClassShortName"></param>
        /// <returns></returns>
        private bool UpdateKQTJ(DateTime dataAttendance, int codeSenderAddress, string strClassShortName, int deptID, string strDeptName)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("dataAttendance",SqlDbType.DateTime),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("ClassShortName",SqlDbType.VarChar,20),
                                                new SqlParameter("deptID",SqlDbType.Int),
                                                new SqlParameter("deptName",SqlDbType.VarChar,50)
                                          };

            sqlParmeters[0].Value = dataAttendance;
            sqlParmeters[1].Value = codeSenderAddress;
            sqlParmeters[2].Value = strClassShortName;
            sqlParmeters[3].Value = deptID;
            sqlParmeters[4].Value = strDeptName;
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "proc_UpdateKQTJ", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "proc_UpdateKQTJ", sqlParmeters);
        }
        #endregion

        #region 【方法：插入历史巡检异常记录】
        private bool OperatorHisPath(DataTable dtRtPath, DataRowView drvEmp, DateTime detecTime)
        {
            bool flag = true;
            if (dtRtPath != null && dtRtPath.Rows.Count > 0)
            {
                //获取这张卡在实时巡检中有没有报警记录
                DataView dvRTPath = new DataView(dtRtPath, "empid=" + drvEmp["userid"].ToString(), "", DataViewRowState.CurrentRows);
                if (dvRTPath != null && dvRTPath.Count > 0)
                {
                    //插入历史巡检异常报警数据并删除实时
                    if (!AddHisPathAlarm(dvRTPath[0], drvEmp, detecTime))
                        flag = false;
                }
            }
            return flag;
        }

        private bool AddHisPathAlarm(DataRowView drvRtPath, DataRowView drvEmp, DateTime detecTime)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("Id",SqlDbType.BigInt),
                                                new SqlParameter("EmpID",SqlDbType.Int),
                                                new SqlParameter("EmpName",SqlDbType.VarChar,20),
                                                new SqlParameter("StationAddress",SqlDbType.Int),
                                                new SqlParameter("StationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("AlertBeginTime",SqlDbType.DateTime),
                                                new SqlParameter("AlertEndTime",SqlDbType.DateTime),
                                                new SqlParameter("AlertTimeValue",SqlDbType.Int)
                                          };

            sqlParmeters[0].Value = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss") + Convert.ToInt32(drvEmp["CodeSenderAddress"].ToString()).ToString("0000"));
            sqlParmeters[1].Value = drvRtPath["empid"];
            sqlParmeters[2].Value = drvEmp["UserName"];
            sqlParmeters[3].Value = drvRtPath["stationAddress"];
            sqlParmeters[4].Value = drvRtPath["stationHeadAddress"];
            sqlParmeters[5].Value = drvRtPath["alarmDateTime"];
            sqlParmeters[6].Value = detecTime;
            sqlParmeters[7].Value = Convert.ToInt32(((TimeSpan)(detecTime - Convert.ToDateTime(drvRtPath["alarmDateTime"].ToString()))).TotalSeconds);
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "insert_His_PathAlert", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //return interHostBack.ExecuteSql(true, "insert_His_PathAlert", sqlParmeters);
        }
        #endregion
        #endregion

        #region 【方法组：提取数据库中数据】

        #region 【方法：获取是否离开井口分站】
        /// <summary>
        /// 获取是否离开井口分站
        /// qyz 增加判断卡是否离开井口分站，防止重复区域 出井时仍存入下井信息
        /// </summary>
        /// <returns></returns>
        private DataTable shine_GetRTInstationHeadTmep(string strCards)
        {
            DataTable dtStationHeadTemp = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("@Cards",SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = strCards;

                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtStationHeadTemp = interHostBack.GetDataTabel(true, "shine_GetRTInstationHeadTmep", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:shine_GetRTInstationHeadTmep]", ex.Message);
                }
            }
            return dtStationHeadTemp;
        }
        #endregion

        #region 【方法:获取读卡分站信息】
        /// <summary>
        /// 获取读卡分站信息
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <returns></returns>
        private DataTable GetStationHeadInfoByID(int stationAddress, int stationHeadAddress)
        {
            DataTable dtStationHead = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("stationAddress", SqlDbType.Int) ,
                                                  new SqlParameter("StationHeadAddress",SqlDbType.Int)
                                              };
                sqlParmeters[0].Value = stationAddress;
                sqlParmeters[1].Value = stationHeadAddress;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtStationHead = interHostBack.GetDataTabel(true, "proc_GetStationHeadByAddress", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtStationHead = interHostBack.GetDataTabel(true, "proc_GetStationHeadByAddress", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetStationHeadByAddress]", ex.Message);
                }
            }
            return dtStationHead;
        }

        /// <summary>
        /// 获取读卡分站信息
        /// </summary>
        /// <param name="stationHeadID"></param>
        /// <returns></returns>
        private DataTable GetStationHeadInfoByID(int stationHeadID)
        {
            DataTable dtStationHead = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("stationHeadID", SqlDbType.Int)
                                              };
                sqlParmeters[0].Value = stationHeadID;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtStationHead = interHostBack.GetDataTabel(true, "proc_GetStationHeadByID", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtStationHead = interHostBack.GetDataTabel(true, "proc_GetStationHeadByID", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetStationHeadByID]", ex.Message);
                }
            }
            return dtStationHead;
        }
        #endregion

        #region 【方法：获取临时表中的数据】
        /// <summary>
        /// 获取临时表中的数据
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private DataTable GetRTInStationHeadInfoTemp(int stationAddress, int stationHeadAddress, string strCards)
        {
            DataTable dtStationHeadTemp = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("stationAddress", SqlDbType.Int) ,
                                                  new SqlParameter("StationHeadAddress",SqlDbType.Int),
                                                  new SqlParameter("Cards",SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = stationAddress;
                sqlParmeters[1].Value = stationHeadAddress;
                sqlParmeters[2].Value = strCards;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtStationHeadTemp = interHostBack.GetDataTabel(true, "proc_GetRTInStationHeadTempInfoByCards", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtStationHeadTemp = interHostBack.GetDataTabel(true, "proc_GetRTInStationHeadTempInfoByCards", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetRTInStationHeadTempInfoByCards]", ex.Message);
                }
            }
            return dtStationHeadTemp;
        }
        /// <summary>
        /// 获取临时表中的数据
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <returns></returns>
        private DataTable GetRTInStationHeadInfoTemp(int stationAddress, int stationHeadAddress)
        {
            DataTable dtStationHeadTemp = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("stationAddress", SqlDbType.Int) ,
                                                  new SqlParameter("StationHeadAddress",SqlDbType.Int)
                                              };
                sqlParmeters[0].Value = stationAddress;
                sqlParmeters[1].Value = stationHeadAddress;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtStationHeadTemp = interHostBack.GetDataTabel(true, "proc_GetRTInStationHeadTempInfoByCards", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtStationHeadTemp = interHostBack.GetDataTabel(true, "proc_GetRTInStationHeadTempInfoByCards", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetRTInStationHeadTempInfoByCards]", ex.Message);
                }
            }
            return dtStationHeadTemp;
        }
        /// <summary>
        /// 获取临时表中的数据
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <returns></returns>
        private DataTable GetRTInStationHeadInfoTemp(int stationAddress)
        {
            DataTable dtStationHeadTemp = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("stationAddress", SqlDbType.Int)
                                              };
                sqlParmeters[0].Value = stationAddress;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtStationHeadTemp = interHostBack.GetDataTabel(true, "proc_GetRTInStationHeadTempInfoByCards", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtStationHeadTemp = interHostBack.GetDataTabel(true, "proc_GetRTInStationHeadTempInfoByCards", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetRTInStationHeadTempInfoByCards]", ex.Message);
                }
            }
            return dtStationHeadTemp;
        }
        #endregion

        #region 【方法：获取实时考勤信息】
        /// <summary>
        /// 按照传入卡号获取实时考勤信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private DataTable GetRealTimeAttendanceByCards(string strCards)
        {
            DataTable dtRealTimeAttendance = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = strCards;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtRealTimeAttendance = interHostBack.GetDataTabel(true, "proc_GetRealTimeAttendanceByCards", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtRealTimeAttendance = interHostBack.GetDataTabel(true, "proc_GetRealTimeAttendanceByCards", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetRealTimeAttendanceByCards]", ex.Message);
                }
            }
            return dtRealTimeAttendance;
        }
        #endregion

        #region 【方法：获取标识卡配置信息】
        /// <summary>
        /// 获取标识卡配置信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private DataTable GetCodeSenderAddressByCards(string strCards)
        {
            DataTable dtCodeSenderAddress = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = strCards;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtCodeSenderAddress = interHostBack.GetDataTabel(true, "proc_GetCodeSenderSetByCards", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtCodeSenderAddress = interHostBack.GetDataTabel(true, "proc_GetCodeSenderSetByCards", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetCodeSenderSetByCards]", ex.Message);
                }
            }
            return dtCodeSenderAddress;
        }
        #endregion

        #region 【方法：获取实时标识卡信息】
        /// <summary>
        /// 获取实时标识卡信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private DataTable GetRTInStationHeadInfoByCards(string strCards)
        {
            DataTable dtRTInStationHeadInfo = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = strCards;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtRTInStationHeadInfo = interHostBack.GetDataTabel(true, "proc_GetRTInStationHeadInfoByCards", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtRTInStationHeadInfo = interHostBack.GetDataTabel(true, "proc_GetRTInStationHeadInfoByCards", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetRTInStationHeadInfoByCards]", ex.Message);
                }
            }
            return dtRTInStationHeadInfo;
        }
        #endregion

        #region 【方法：获取区域配置信息】
        /// <summary>
        /// 获取区域配置信息
        /// </summary>
        /// <returns></returns>
        private DataTable GetAreaSet()
        {
            DataTable dtAreaInfo = null;
            try
            {
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtAreaInfo = interHostBack.GetDataTabel(true, "proc_GetAreaSet", null);

                //JYH-2011-11-23 注销 无法找到表0
                //dtAreaInfo = interHostBack.GetDataTabel(true, "proc_GetAreaSet", null);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetAreaSet]", ex.Message);
                }
            }
            return dtAreaInfo;
        }
        #endregion

        #region 【方法：获取人员区域超时信息】
        /// <summary>
        /// 获取人员区域超时信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private DataTable GetTerOverTime(string strCards)
        {
            DataTable dtRTTerOverTime = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = strCards;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtRTTerOverTime = interHostBack.GetDataTabel(true, "proc_GetTerOverTime", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtRTTerOverTime = interHostBack.GetDataTabel(true, "proc_GetTerOverTime", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetTerOverTime]", ex.Message);
                }
            }
            return dtRTTerOverTime;
        }
        #endregion

        #region 【方法：获取特殊工种配置信息】
        /// <summary>
        /// 获取特殊工种区域配置
        /// </summary>
        /// <returns></returns>
        private DataTable GetSWorkTypeAreaSet()
        {
            DataTable dtSWorkTypeAreaInfo = null;
            try
            {
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtSWorkTypeAreaInfo = interHostBack.GetDataTabel(true, "proc_GetSWorkTypeAresSet", null);

                //JYH-2011-11-23 注销 无法找到表0
                //dtSWorkTypeAreaInfo = interHostBack.GetDataTabel(true, "proc_GetSWorkTypeAresSet", null);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetSWorkTypeAresSet]", ex.Message);
                }
            }
            return dtSWorkTypeAreaInfo;
        }
        #endregion

        #region 【方法：获取实时区域信息】
        private DataTable GetRtAreaInfo(string strCards)
        {
            DataTable dtRtAreaInfo = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = strCards;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtRtAreaInfo = interHostBack.GetDataTabel(true, "proc_GetRTAreaInfo", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtRtAreaInfo = interHostBack.GetDataTabel(true, "proc_GetRTAreaInfo", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetRTAreaInfo]", ex.Message);
                }
            }
            return dtRtAreaInfo;
        }
        #endregion

        #region 【方法：获取实时井下人员信息】
        /// <summary>
        /// 获取传入的卡号的实时井下人员信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private DataTable GetRtInWell(string strCards)
        {
            DataTable dtRtInWell = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = strCards;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtRtInWell = interHostBack.GetDataTabel(true, "proc_GetRTInMine", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtRtInWell = interHostBack.GetDataTabel(true, "proc_GetRTInMine", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetRTInMine]", ex.Message);
                }
            }
            return dtRtInWell;
        }
        #endregion

        #region 【方法：获取进入井口分站信息】
        /// <summary>
        /// 获取最后一次进入井口分站信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private DataTable GetMineStationHead(string strCards)
        {
            DataTable dtInMineStationHeadInfo = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = strCards;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtInMineStationHeadInfo = interHostBack.GetDataTabel(true, "proc_GetInMineStationInfo", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtInMineStationHeadInfo = interHostBack.GetDataTabel(true, "proc_GetInMineStationInfo", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetInMineStationInfo]", ex.Message);
                }
            }
            return dtInMineStationHeadInfo;
        }
        #endregion

        #region 【方法：获取方向性配置信息】
        /// <summary>
        /// 按照地点获取方向性配置信息
        /// </summary>
        /// <param name="stationAddress"></param>
        /// <param name="stationHeadAddress"></param>
        /// <returns></returns>
        private DataTable GetCodeSenderDirectionalAntennaByAddress(int stationAddress, int stationHeadAddress)
        {
            DataTable dtDirectional = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("stationAddress", SqlDbType.Int) ,
                                                  new SqlParameter("StationHeadAddress",SqlDbType.Int)
                                              };
                sqlParmeters[0].Value = stationAddress;
                sqlParmeters[1].Value = stationHeadAddress;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtDirectional = interHostBack.GetDataTabel(true, "proc_GetCodeSenderDirectionalAntennaByAddress", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtDirectional = interHostBack.GetDataTabel(true, "proc_GetCodeSenderDirectionalAntennaByAddress", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetCodeSenderDirectionalAntennaByAddress]", ex.Message);
                }
            }
            return dtDirectional;
        }
        #endregion

        #region 【方法：获取考勤统计信息】
        /// <summary>
        /// 按照卡号获取考勤统计信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <param name="dtime"></param>
        /// <returns></returns>
        private DataTable GetKQTJbyCards(string strCards, DateTime dtime)
        {
            DataTable dtDirectional = null;
            DateTime dTimeKQTJ = new DateTime(dtime.Year, dtime.Month, 1, 0, 0, 0);

            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000) ,
                                                  new SqlParameter("dataAttendance",SqlDbType.DateTime)
                                              };
                sqlParmeters[0].Value = strCards;
                sqlParmeters[1].Value = dTimeKQTJ;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtDirectional = interHostBack.GetDataTabel(true, "proc_GetKQTJByCard", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtDirectional = interHostBack.GetDataTabel(true, "proc_GetKQTJByCard", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetKQTJByCard]", ex.Message);
                }
            }
            return dtDirectional;
        }
        #endregion

        #region 【方法：获取实时巡检异常信息】
        /// <summary>
        /// 获取实时巡检异常信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <returns></returns>
        private DataTable GetRealTimePathAlarm(string strCards)
        {
            DataTable dtRealTimePath = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000)
                                              };
                sqlParmeters[0].Value = strCards;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtRealTimePath = interHostBack.GetDataTabel(true, "proc_GetRealTimePath", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dtRealTimePath = interHostBack.GetDataTabel(true, "proc_GetRealTimePath", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetRealTimePath]", ex.Message);
                }
            }
            return dtRealTimePath;
        }
        #endregion
        #endregion

        #region 【方法组：创建历史数据表】
        #region 【方法：构造历史进出分站表】
        /// <summary>
        /// 构造历史进出分站表
        /// </summary>
        /// <returns></returns>
        private DataTable CreateHisInStationHead()
        {
            DataTable dt = new DataTable("HisInStationHead");
            dt.Columns.Add("HisStationHeadID", typeof(System.Int64));
            dt.Columns.Add("StationAddress", typeof(System.Int32));
            dt.Columns.Add("StationHeadAddress", typeof(System.Int32));
            dt.Columns.Add("StationHeadPlace", typeof(System.String));
            dt.Columns.Add("CodeSenderAddress", typeof(System.Int32));
            dt.Columns.Add("CsTypeID", typeof(System.Int32));
            dt.Columns.Add("UserID", typeof(System.Int32));
            dt.Columns.Add("UserNo", typeof(System.String));
            dt.Columns.Add("UserName", typeof(System.String));
            dt.Columns.Add("DeptID", typeof(System.Int32));
            dt.Columns.Add("DeptName", typeof(System.String));
            dt.Columns.Add("DutyID", typeof(System.Int32));
            dt.Columns.Add("DutyName", typeof(System.String));
            dt.Columns.Add("WorkTypeID", typeof(System.Int32));
            dt.Columns.Add("WorkTypeName", typeof(System.String));
            dt.Columns.Add("InStationHeadTime", typeof(System.DateTime));
            dt.Columns.Add("OutStationHeadTime", typeof(System.DateTime));
            dt.Columns.Add("ContinueTime", typeof(System.Int32));
            dt.Columns.Add("isMend", typeof(System.Boolean));
            return dt;
        }
        #endregion

        #region 【方法：构造历史进出区域表】
        /// <summary>
        /// 构造历史进出区域表
        /// </summary>
        /// <returns></returns>
        private DataTable CreateHisInOutTerritorial()
        {
            DataTable dt = new DataTable("His_InOutTerritorial");
            dt.Columns.Add("HisTerritorialID", typeof(System.Int64));
            dt.Columns.Add("TerritorialID", typeof(System.Int32));
            dt.Columns.Add("TerritorialName", typeof(System.String));
            dt.Columns.Add("TerritorialTypeName", typeof(System.String));
            dt.Columns.Add("InTerritorialTime", typeof(System.DateTime));
            dt.Columns.Add("CodeSenderAddress", typeof(System.Int32));
            dt.Columns.Add("UserID", typeof(System.Int32));
            dt.Columns.Add("UserNo", typeof(System.String));
            dt.Columns.Add("UserName", typeof(System.String));
            dt.Columns.Add("DeptID", typeof(System.Int32));
            dt.Columns.Add("DeptName", typeof(System.String));
            dt.Columns.Add("DutyID", typeof(System.Int32));
            dt.Columns.Add("DutyName", typeof(System.String));
            dt.Columns.Add("WorkTypeID", typeof(System.Int32));
            dt.Columns.Add("WorkTypeName", typeof(System.String));
            dt.Columns.Add("OutTerritorialTime", typeof(System.DateTime));
            dt.Columns.Add("ContinueTime", typeof(System.Int64));
            dt.Columns.Add("IsAlarm", typeof(System.Boolean));
            return dt;
        }
        #endregion

        #region 【方法：构建历史进出井表】
        /// <summary>
        /// 构造历史进出井表
        /// </summary>
        /// <returns></returns>
        private DataTable CreateHisInOutMine()
        {
            DataTable dt = new DataTable("His_InOutMine");
            dt.Columns.Add("HisInOutMineID", typeof(System.Int64));
            dt.Columns.Add("InStationAddress", typeof(System.Int32));
            dt.Columns.Add("InStationHeadAddress", typeof(System.String));
            dt.Columns.Add("InWellPlace", typeof(System.String));
            dt.Columns.Add("CodeSenderAddress", typeof(System.Int32));
            dt.Columns.Add("UserID", typeof(System.Int32));
            dt.Columns.Add("UserNo", typeof(System.String));
            dt.Columns.Add("UserName", typeof(System.String));
            dt.Columns.Add("DeptID", typeof(System.Int32));
            dt.Columns.Add("DeptName", typeof(System.String));
            dt.Columns.Add("DutyID", typeof(System.Int32));
            dt.Columns.Add("DutyName", typeof(System.String));
            dt.Columns.Add("WorkTypeID", typeof(System.Int32));
            dt.Columns.Add("WorkTypeName", typeof(System.String));
            dt.Columns.Add("InTime", typeof(System.DateTime));
            dt.Columns.Add("OutStationAddress", typeof(System.Int32));
            dt.Columns.Add("OutStationHeadAddress", typeof(System.Int32));
            dt.Columns.Add("OutWellPlace", typeof(System.String));
            dt.Columns.Add("OutTime", typeof(System.DateTime));
            dt.Columns.Add("ContinueTime", typeof(System.Int64));
            dt.Columns.Add("isMend", typeof(System.Boolean));
            return dt;
        }
        #endregion

        #region 【方法：构建历史考勤表】
        /// <summary>
        /// 构造历史考勤表
        /// </summary>
        /// <returns></returns>
        private DataTable CreateHisAttendance()
        {
            DataTable dt = new DataTable("His_Attendance");
            dt.Columns.Add("ID", typeof(System.Int64));
            dt.Columns.Add("BlockID", typeof(System.Int32));
            dt.Columns.Add("EmployeeID", typeof(System.Int32));
            dt.Columns.Add("EmployeeName", typeof(System.String));
            dt.Columns.Add("DeptID", typeof(System.Int32));
            dt.Columns.Add("ClassID", typeof(System.Int32));
            dt.Columns.Add("ClassShortName", typeof(System.String));
            dt.Columns.Add("BeginWorkDate", typeof(System.DateTime));
            dt.Columns.Add("BeginWorkTime", typeof(System.DateTime));
            dt.Columns.Add("EndWorkTime", typeof(System.DateTime));
            dt.Columns.Add("WorkTime", typeof(System.Int32));
            dt.Columns.Add("ManNumberUnit", typeof(System.Int32));
            dt.Columns.Add("BookWorkTime", typeof(System.Int32));
            dt.Columns.Add("AvailableWorkTime", typeof(System.Int32));
            dt.Columns.Add("IsAddAttendance", typeof(System.Boolean));
            dt.Columns.Add("IsHoliday", typeof(System.Boolean));
            dt.Columns.Add("IsAvailable", typeof(System.Boolean));
            dt.Columns.Add("OperatorID", typeof(System.Int32));
            dt.Columns.Add("OperatorTime", typeof(System.DateTime));
            dt.Columns.Add("IsLate", typeof(System.Boolean));
            dt.Columns.Add("IsLeaveEarly", typeof(System.Boolean));
            dt.Columns.Add("IsEnoughAttendance", typeof(System.Boolean));
            dt.Columns.Add("LateTimeLongth", typeof(System.Int32));
            dt.Columns.Add("LeaveEarlyTimeLength", typeof(System.Int32));
            dt.Columns.Add("Remark", typeof(System.String));
            dt.Columns.Add("TimerIntervalID", typeof(System.Int32));
            dt.Columns.Add("DataAttendance", typeof(System.DateTime));
            dt.Columns.Add("isMend", typeof(System.Boolean));
            return dt;
        }
        #endregion
        #endregion

        #region【方法：提取数据库基站信息】
        public void GetStationInfo()
        {
            dt_Satation = BuildStationTable();

            try
            {
                //新的分站表数据
                dt_Satation.ReadXml(System.Windows.Forms.Application.StartupPath.ToString() + @"\Station.xml");
            }
            catch { }
        }

        /// <summary>
        /// 构建 Station 表格
        /// </summary>
        /// <returns></returns>
        private DataTable BuildStationTable()
        {
            DataTable dtStation = new DataTable("Station");

            DataColumn dcID = new DataColumn("ID", typeof(int));
            dtStation.Columns.Add(dcID);

            DataColumn dcAddress = new DataColumn("Address", typeof(int));
            dtStation.Columns.Add(dcAddress);

            DataColumn dcGroup = new DataColumn("Group", typeof(int));
            dtStation.Columns.Add(dcGroup);

            DataColumn dcState = new DataColumn("State", typeof(int));
            dtStation.Columns.Add(dcState);

            DataColumn dcMark = new DataColumn("Mark", typeof(int));
            dtStation.Columns.Add(dcMark);

            DataColumn dcVer = new DataColumn("Ver", typeof(int));
            dtStation.Columns.Add(dcVer);

            DataColumn dcIpAddress = new DataColumn("IpAddress", typeof(string));
            dtStation.Columns.Add(dcIpAddress);

            DataColumn dcIpPort = new DataColumn("IpPort", typeof(int));
            dtStation.Columns.Add(dcIpPort);

            DataColumn dcStationModel = new DataColumn("StationModel", typeof(int));
            dtStation.Columns.Add(dcStationModel);

            return dtStation;
        }
        #endregion

        #region [ 方法: 提取数据库基站信息 ]
        /// <summary>
        /// 提取数据库基站信息
        /// </summary>
        /// <param name="iSelectType">1为串口  2为网口</param>
        /// <returns></returns>
        public DataTable GetStationInfo(int iSelectType)
        {
            try
            {
                SqlParameter[] sqlParmeters = { new SqlParameter("sign", SqlDbType.Int) };
                sqlParmeters[0].Value = iSelectType;
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dt_Satation = interHostBack.GetDataTabel(true, "zjw_Select_Station", sqlParmeters);

                //JYH-2011-11-23 注销 无法找到表0
                //dt_Satation = interHostBack.GetDataTabel(true, "zjw_Select_Station", sqlParmeters);

                sqlParmeters = null;
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:GetStationInfo]", ex.Message);
                }
            }
            return dt_Satation;
        }

        #endregion

        #region [方法：提取网络信息]
        public DataTable GetTcpClientInfo()
        {
            try
            {

                SqlParameter[] sqlParmeters = { new SqlParameter("sign", SqlDbType.Int) };
                //JYH-2011-11-23 优化
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dt_TcpClient = interHostBack.GetDataTabel(true, "cjg_select_tcpIpConfig", null);

                //JYH-2011-11-23 注销 无法找到表0
                //dt_TcpClient = interHostBack.GetDataTabel(true, "cjg_select_tcpIpConfig", null);

                sqlParmeters = null;
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:GetTcpClientInfo]", ex.Message);
                }
            }
            return dt_TcpClient;
        }

        public void GetTcpInfo()
        {

        }

        /// <summary>
        /// 构建 TcpConfig 表格
        /// </summary>
        /// <returns></returns>
        private DataTable BuildTcpClientTable()
        {
            DataTable dtTcpClient = new DataTable("TcpIpConfig");

            DataColumn dcID = new DataColumn("IPID", typeof(int));
            dtTcpClient.Columns.Add(dcID);

            DataColumn dcIpAddress = new DataColumn("IpAddress", typeof(string));
            dtTcpClient.Columns.Add(dcIpAddress);

            DataColumn dcIpPort = new DataColumn("IpPort", typeof(int));
            dtTcpClient.Columns.Add(dcIpPort);

            return dtTcpClient;
        }
        #endregion [方法：提取网络信息]

        #region [方法：判断数据库连接]
        public void IsConnect()
        {
            //JYH-2011-11-23 优化
            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            interHostBack.IsConnect(true);
            //return interHostBack.ExecuteSql(true, "KJ128N_Update_CodeSenderLow", sqlParmeters);

            //JYH-2011-11-23 注销 无法找到表0
            //   interHostBack.IsConnect(true);
        }
        #endregion

        #region Czlt-2011-05-11-测试端口号
        #region 【方法：保存传输分站的交直流供电】
        /// <summary>
        /// 保存电源的供电信息
        /// </summary>
        /// <param name="stationAddress">传输分站编号</param>
        /// <param name="stationHeadAddress">读卡分站编号</param>
        /// <param name="stationState">传输分站供电状态</param>
        /// <param name="serialState">串口服务器供电状态</param>
        /// <param name="breakTime">时间</param>
        /// <returns></returns>
        private bool CzltSaveDYstate(int stationAddress, int stationHeadAddress, int stationState, int serialState, DateTime breakTime)
        {
            bool isReturn = false;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                              new SqlParameter("StationAddress", SqlDbType.Int),
                                              new SqlParameter("StationHeadAddress", SqlDbType.Int),
                                              new SqlParameter("StationState", SqlDbType.Int),
                                              new SqlParameter("SerialState",SqlDbType.Int),
                                              new SqlParameter("BreakTime", SqlDbType.DateTime)                                              
                                          };
                sqlParmeters[0].Value = stationAddress;
                sqlParmeters[1].Value = stationHeadAddress;
                sqlParmeters[2].Value = stationState;
                sqlParmeters[3].Value = serialState;
                sqlParmeters[4].Value = breakTime.ToString("yyyy-MM-dd HH:mm:ss");

                //Czlt-2011-06-09 - 重新获取对象，装载数据
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                isReturn = interHostBack.ExecuteSql(true, "Czlt_Proc_DYShowMode", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:Czlt_Proc_DYShowMode]", ex.Message);
                }
            }
            return isReturn;
        }
        #endregion
        #endregion

        #region 【Czlt-2011-12-10 判断有没有安装SP4插件】

        public DataTable GetSqlVersion()
        {
            DataTable dtSql = null;
            try
            {


                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtSql = interHostBack.GetDataTabel(true, "czltGetVer", null);




            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:GetTcpClientInfo]", ex.Message);
                }
            }
            return dtSql;
        }
        #endregion


        #region 【Czlt-2011-12-04 添加历史上下井时，对没有实时考勤的人员补加历史考勤信息】
        private bool CzltAddHisAttendance(DataRowView drRtInMine, DataRowView drEmp, DateTime detecTime, bool isMend)
        {
            bool isTrue = true;
            DataTable dtHis = CreateHisAttendance();
            DataRow drHis = dtHis.NewRow();
            // drHis["ID"] = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss") + Convert.ToInt32(drRtAttendance["CodeSenderAddress"].ToString()).ToString("0000"));
            //Czlt-2011-02-13 修改ID 现在卡号为五位数了
            drHis["ID"] = Convert.ToInt64(DateTime.Now.ToString("yyMMddHHmmssff") + Convert.ToInt32(drRtInMine["CodeSenderAddress"].ToString()).ToString("00000"));
            drHis["BlockID"] = drRtInMine["CodeSenderAddress"];
            drHis["EmployeeID"] = drEmp["UserID"];
            drHis["EmployeeName"] = drEmp["UserName"];
            drHis["DeptID"] = drEmp["DeptID"];
            //drHis["ClassID"] = 19;

            czltDt = GetAttDT(Convert.ToDateTime(drRtInMine["InTime"].ToString()), drRtInMine["CodeSenderAddress"].ToString());
            if (czltDt.Rows.Count > 0)
            {
                drHis["ClassID"] = Convert.ToInt32(czltDt.Rows[0]["classid"].ToString());
                drHis["ClassShortName"] = czltDt.Rows[0]["NameShort"].ToString();
                drHis["TimerIntervalID"] = Convert.ToInt32(czltDt.Rows[0]["TimerIntervalID"].ToString());
                drHis["DataAttendance"] = czltDt.Rows[0]["DataAttendance"].ToString();

            }
            else
            {
                drHis["ClassID"] = 19;
                drHis["ClassShortName"] = "早";
                drHis["TimerIntervalID"] = 1;
                drHis["DataAttendance"] = Convert.ToDateTime(drRtInMine["InTime"].ToString()).ToString("yyyy-MM-dd");

            }

            //if (Convert.ToDateTime(drRtInMine["InTime"].ToString()).Hour >= 4 && Convert.ToDateTime(drRtInMine["InTime"].ToString()).Hour < 11)
            //{
            //    drHis["ClassShortName"] = "早";
            //    drHis["TimerIntervalID"] = 1;
            //    drHis["DataAttendance"] = Convert.ToDateTime(drRtInMine["InTime"].ToString()).ToString("yyyy-MM-dd");

            //}
            //else if (Convert.ToDateTime(drRtInMine["InTime"].ToString()).Hour >= 11 && Convert.ToDateTime(drRtInMine["InTime"].ToString()).Hour < 19)
            //{
            //    drHis["ClassShortName"] = "中";
            //    drHis["TimerIntervalID"] = 2;
            //    drHis["DataAttendance"] = Convert.ToDateTime(drRtInMine["InTime"].ToString()).ToString("yyyy-MM-dd");

            //}
            //else if (Convert.ToDateTime(drRtInMine["InTime"].ToString()).Hour >= 19 || Convert.ToDateTime(drRtInMine["InTime"].ToString()).Hour < 4)
            //{
            //    drHis["ClassShortName"] = "夜";
            //    drHis["TimerIntervalID"] = 3;
            //    drHis["DataAttendance"] = Convert.ToDateTime(drRtInMine["InTime"].ToString()).AddDays(1).ToString("yyyy-MM-dd");

            //}

            drHis["BeginWorkTime"] = drRtInMine["InTime"];
            drHis["EndWorkTime"] = detecTime;
            drHis["WorkTime"] = Convert.ToInt32(((TimeSpan)(detecTime - Convert.ToDateTime(drRtInMine["InTime"].ToString()))).TotalSeconds);
            //drHis["TimerIntervalID"] = drRtAttendance["TimerIntervalID"];
            //drHis["DataAttendance"] = drRtAttendance["DataAttendance"];
            drHis["IsMend"] = isMend;

            //*******Czlt-2011-02-19  历史考勤中 Remark 字段存储下井口类型**Start****
            drHis["remark"] = "1";

            //*******Czlt-2011-02-19  历史考勤中 Remark 字段存储下井口类型**End****

            isTrue = AddHisAttendance(drHis, Convert.ToDateTime(drRtInMine["InTime"].ToString()).ToString("yyyyM"));


            //***Czlt-2011-12-05 最小考勤设置***Start*
            int minSecTime = 0;
            try
            {
                minSecTime = Convert.ToInt32(drEmp["MinSecTime"].ToString());
                if (minSecTime >= 60)
                {
                    minSecTime = minSecTime - 60;
                }
            }
            catch
            {
                minSecTime = 0;
            }

            DateTime dtimeRealTimeAttendance = new DateTime(2000, 1, 1, 0, 0, 0);
            dtimeRealTimeAttendance = Convert.ToDateTime(drRtInMine["InTime"].ToString());


            //去查实时考勤的信息
            DataTable dtKQTJ = GetKQTJbyCards(drHis["BlockID"].ToString(), Convert.ToDateTime(drHis["DataAttendance"].ToString()));

            //获取考勤统计信息
            DataView dvKQTJ = new DataView(dtKQTJ, "blockid=" + drHis["BlockID"].ToString(), "", DataViewRowState.CurrentRows);

            if (detecTime.AddSeconds(-minSecTime) > dtimeRealTimeAttendance)//传入日期比数据中的日期大，则写入历史表中，并删除实时考勤数据
            {
                if (dvKQTJ == null || (dvKQTJ != null && dvKQTJ.Count <= 0))//统计信息中没有这条记录
                {
                    //添加一条记录到考勤统计表中
                    if (!AddKQTJ(new DateTime(detecTime.Year, detecTime.Month, 1, 0, 0, 0), Convert.ToInt32(drRtInMine["CodeSenderAddress"].ToString()), drEmp["UserName"].ToString(), Convert.ToInt32(drEmp["deptID"].ToString()), drEmp["DeptName"].ToString()))
                        isTrue = false;
                }

                //修改考勤统计表记录
                if (!UpdateKQTJ(Convert.ToDateTime(drHis["DataAttendance"].ToString()), Convert.ToInt32(drRtInMine["CodeSenderAddress"].ToString()), drHis["ClassShortName"].ToString(), Convert.ToInt32(drEmp["deptID"].ToString()), drEmp["DeptName"].ToString()))
                    isTrue = false;
            }
            else
            {
                if (dvKQTJ == null || (dvKQTJ != null && dvKQTJ.Count <= 0))//统计信息中没有这条记录
                {
                    //添加一条记录到考勤统计表中
                    if (!AddKQTJ(new DateTime(detecTime.Year, detecTime.Month, 1, 0, 0, 0), Convert.ToInt32(drRtInMine["CodeSenderAddress"].ToString()), drEmp["UserName"].ToString(), Convert.ToInt32(drEmp["deptID"].ToString()), drEmp["DeptName"].ToString()))
                        isTrue = false;
                }

                //修改考勤统计表记录
                if (!UpdateKQTJ(Convert.ToDateTime(drHis["DataAttendance"].ToString()), Convert.ToInt32(drRtInMine["CodeSenderAddress"].ToString()), drHis["ClassShortName"].ToString() + "#", Convert.ToInt32(drEmp["deptID"].ToString()), drEmp["DeptName"].ToString()))
                    isTrue = false;

            }

            // }
            //******czlt-2010-最小考勤设置*End***
            return isTrue;


        }

        #endregion



        #region 【方法：Czlt-2011-12-05-获取考勤统计信息】
        /// <summary>
        /// 按照卡号获取下个月的考勤统计信息
        /// </summary>
        /// <param name="strCards"></param>
        /// <param name="dtime"></param>
        /// <returns></returns>
        private DataTable CzltGetKQTJbyCards(string strCards, DateTime dtime)
        {
            DataTable dtDirectional = null;
            DateTime dTimeKQTJ = new DateTime(dtime.Year, dtime.AddMonths(1).Month, 1, 0, 0, 0);

            if (dtime.Month.ToString().Equals("12"))
            {
                dTimeKQTJ = new DateTime(dtime.AddYears(1).Year, dtime.AddMonths(1).Month, 1, 0, 0, 0);
            }

            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("Cards", SqlDbType.VarChar,6000) ,
                                                  new SqlParameter("dataAttendance",SqlDbType.DateTime)
                                              };
                sqlParmeters[0].Value = strCards;
                sqlParmeters[1].Value = dTimeKQTJ;
                // dtDirectional = interHostBack.GetDataTabel(true, "proc_GetKQTJByCard", sqlParmeters);

                InterfaceHostBack interHostBackCzlt = new InterfaceHostBack();
                interHostBackCzlt.ErrorMessage += _ErrorMessage;
                dtDirectional = interHostBackCzlt.GetDataTabel(true, "proc_GetKQTJByCard", sqlParmeters);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:proc_GetKQTJByCard]", ex.Message);
                }
            }
            return dtDirectional;
        }
        #endregion


        #region【Czlt-2011-12-22 查询班次信息】
        /// <summary>
        /// Czlt-2011-12-22 查询班次信息
        /// </summary>
        /// <param name="detecTime">下井时间</param>
        /// <param name="strCards">卡号</param>
        /// <returns></returns>
        private DataTable GetAttDT(DateTime detecTime, string strCards)
        {
            DataTable dtAtt = null;
            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("@DetectTime", SqlDbType.DateTime),
                                                  new SqlParameter("@Cards",SqlDbType.VarChar,100)
                                              };
                sqlParmeters[0].Value = detecTime;
                sqlParmeters[1].Value = strCards;
                //dtAtt = GetDataTabel(true, "Czlt_GetAttClass", sqlParmeters);
                InterfaceHostBack interHostBackCzlt = new InterfaceHostBack();
                interHostBackCzlt.ErrorMessage += _ErrorMessage;
                dtAtt = interHostBackCzlt.GetDataTabel(true, "Czlt_GetAttClass", sqlParmeters);
            }
            catch (Exception ex)
            {
            }
            return dtAtt;

        }
        #endregion


        #region 【Czlt-2012-3-20 年报表统计】


        /// <summary>
        /// Czlt-2012-3-20 添加年统计信息
        /// </summary>
        /// <param name="codeSenderAddress">标识卡号</param>
        /// <param name="strID">人员ID</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="deptID">部门ID</param>
        /// <param name="strDeptName">部门名称</param>
        /// <param name="inTime">进的时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="DataAttendance">记工日期</param>
        /// <returns>返回值</returns>
        private bool Czlt_MonthEmp(string codeSenderAddress, int strID, string strUserName, int deptID, string strDeptName, DateTime inTime, DateTime endTime, DateTime DataAttendance)
        {
            bool isBool = true;

            //1.查询年下井次数统计表中有没有该卡信息            
            DataTable dtEmpNum = Czlt_GetMonthEmpbyCards(codeSenderAddress, DataAttendance, "Czlt_MonthEmpNum");

            //判断年下井次数表中有没有该人员信息
            if (dtEmpNum == null || (dtEmpNum != null && dtEmpNum.Rows.Count <= 0))
            {

                //没有的话向年下井次数表中添加一条下井记录
                if (!Czlt_AddMonthEmp(DataAttendance, Convert.ToInt32(codeSenderAddress), strID, strUserName, deptID, strDeptName, "Czlt_MonthEmpNum"))
                    isBool = false;
            }

            //年下井次数表中有人员信息的时候修改记录
            if (!Czlt_UpdateMonthEmp(DataAttendance, Convert.ToInt32(codeSenderAddress), 1, strUserName, "Czlt_MonthEmpNum"))
                isBool = false;

            //2.查询年下井时长统计表中有没有该卡信息  
            int intLongTime = Convert.ToInt32(((TimeSpan)(endTime - inTime)).TotalSeconds);
            dtEmpNum = Czlt_GetMonthEmpbyCards(codeSenderAddress, DataAttendance, "Czlt_MonthEmpTime");

            //判断年下井时长表中有没有该人员信息
            if (dtEmpNum == null || (dtEmpNum != null && dtEmpNum.Rows.Count <= 0))
            {
                //没有的话向年下井时长表中添加一条下井记录
                if (!Czlt_AddMonthEmp(DataAttendance, Convert.ToInt32(codeSenderAddress), strID, strUserName, deptID, strDeptName, "Czlt_MonthEmpTime"))
                    isBool = false;
            }

            //年下井时长表中有人员信息的时候修改记录
            if (!Czlt_UpdateMonthEmp(DataAttendance, Convert.ToInt32(codeSenderAddress), intLongTime, strUserName, "Czlt_MonthEmpTime"))
                isBool = false;

            return isBool;
        }

        /// <summary>
        /// Czlt-2012-03-20 修改年报表信息
        /// </summary>
        /// <param name="dataAttendance">记工日期</param>
        /// <param name="codeSenderAddress">标识卡号</param>
        /// <param name="cMNum">修改信息</param>
        /// <param name="empName">人员姓名</param>
        /// <param name="strTName">表名称</param>
        /// <returns></returns>
        private bool Czlt_UpdateMonthEmp(DateTime dataAttendance, int codeSenderAddress, int cMNum, string empName, string strTName)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("@tableName",SqlDbType.VarChar,50),
                                                new SqlParameter("@Cname",SqlDbType.VarChar,20),
                                                new SqlParameter("@cNum",SqlDbType.VarChar,20),
                                                new SqlParameter("@codesender",SqlDbType.VarChar,20),
                                                new SqlParameter("@cYear",SqlDbType.VarChar,20),
                                                new SqlParameter("@empName",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = strTName;
            sqlParmeters[1].Value = "cM" + dataAttendance.Month;
            sqlParmeters[2].Value = cMNum.ToString();
            sqlParmeters[3].Value = codeSenderAddress.ToString();
            sqlParmeters[4].Value = dataAttendance.ToString("yyyy");
            sqlParmeters[5].Value = empName;

            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "Proc_Czlt_MonthEmp_Update", sqlParmeters);

        }


        /// <summary>
        /// Czlt2012-3-20 向年统计表中添加信息
        /// </summary>
        /// <param name="dataAttendance">记工日期</param>
        /// <param name="codeSenderAddress">标识卡号</param>
        /// <param name="empID">人员ID</param>
        /// <param name="strEmpName">人员姓名</param>
        /// <param name="deptID">部门ID</param>
        /// <param name="strDeptName">部门名称</param>
        /// <param name="strTName">表明</param>
        /// <returns>是否成功</returns>
        private bool Czlt_AddMonthEmp(DateTime dataAttendance, int codeSenderAddress, int empID, string strEmpName, int deptID, string strDeptName, string strTName)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("@tableName",SqlDbType.VarChar,50),                                             
                                                new SqlParameter("@codesender",SqlDbType.VarChar,10),
                                                new SqlParameter("@empID",SqlDbType.VarChar,50),
                                                new SqlParameter("@empName",SqlDbType.VarChar,10),
                                                new SqlParameter("@deptID",SqlDbType.VarChar,50),
                                                new SqlParameter("@deptName",SqlDbType.VarChar,50),
                                                new SqlParameter("@cYear",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = strTName;
            sqlParmeters[1].Value = Convert.ToString(codeSenderAddress);
            sqlParmeters[2].Value = Convert.ToString(empID);
            sqlParmeters[3].Value = strEmpName;
            sqlParmeters[4].Value = Convert.ToString(deptID);
            sqlParmeters[5].Value = strDeptName;
            sqlParmeters[6].Value = dataAttendance.ToString("yyyy");

            InterfaceHostBack interHostBack = new InterfaceHostBack();
            interHostBack.ErrorMessage += _ErrorMessage;
            return interHostBack.ExecuteSql(true, "Proc_Czlt_MonthEmp_Insert", sqlParmeters);


        }

        /// <summary>
        /// 查询年报表中有没有该人员信息
        /// </summary>
        /// <param name="strCards">标识卡号</param>
        /// <param name="dtime">记工日期</param>
        /// <returns></returns>
        private DataTable Czlt_GetMonthEmpbyCards(string strCards, DateTime dtime, string strTName)
        {
            DataTable dtDirectional = null;
            DateTime dTimeKQTJ = new DateTime(dtime.Year, dtime.Month, 1, 0, 0, 0);

            try
            {
                SqlParameter[] sqlParmeters = { 
                                                  new SqlParameter("@tableName", SqlDbType.VarChar,50) ,
                                                  new SqlParameter("@codesender", SqlDbType.VarChar,10) ,
                                                  new SqlParameter("@cYear",SqlDbType.VarChar,10)
                                              };
                sqlParmeters[0].Value = strTName;
                sqlParmeters[1].Value = strCards;
                sqlParmeters[2].Value = dTimeKQTJ.ToString("yyyy");

                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtDirectional = interHostBack.GetDataTabel(true, "Proc_Czlt_MonthEmp_Select", sqlParmeters);


            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:GetMonthEmpbyCards]", ex.Message);
                }
            }
            return dtDirectional;

        }
        #endregion

        #region [Czlt-2013-11-20井口分站信息]
        /// <summary>
        /// 当 InMineStationInfo 表中没有下井信息时,找一个井口信息补漏
        /// </summary>
        /// <returns></returns>
        private string GetStaHeadID()
        {
            string strID = string.Empty;
            try
            {
                DataTable dtRtInWell = null;
                InterfaceHostBack interHostBack = new InterfaceHostBack();
                interHostBack.ErrorMessage += _ErrorMessage;
                dtRtInWell = interHostBack.GetDataTabel(true, "proc_CzltGetStationHead", null);
                if (dtRtInWell != null && dtRtInWell.Rows.Count > 0)
                {
                    strID = dtRtInWell.Rows[0][0].ToString();
 
                }
            }
            catch 
            {
            }

            return strID;

        }
        #endregion

        //#region 【Czlt-2011-03-23】
        //public void CreateFile(string strContent, string FileName)
        //{

        //    //如果指定日志目录下的文件总和超过500MB,对已经存在的日志文件清理
        //    if (ReturnDirectoryFileLengthCount(strDirectoryPath) > intErrorLogFileSizeCount * 1024 * 1024)
        //    {
        //        //对已经存在的日志文件进行遍历
        //        for (int intFilesCount = 0; intFilesCount < Directory.GetFiles(strDirectoryPath).Length; intFilesCount++)
        //        {
        //            //重新计算指定日志目录下的文件大小总和
        //            if (ReturnDirectoryFileLengthCount(strDirectoryPath) > intErrorLogFileSizeCount * 1024 * 1024)
        //            {
        //                DateTime dtOrinDateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //                string EalyFilePath = string.Empty;

        //                //得到最早创建的日志文件
        //                foreach (string strFilePath in Directory.GetFiles(strDirectoryPath))
        //                {
        //                    if (TimeSpan.Parse(Convert.ToString(dtOrinDateTime - File.GetLastWriteTime(strFilePath))).TotalSeconds >= 0)
        //                    {
        //                        dtOrinDateTime = File.GetLastWriteTime(strFilePath);
        //                        EalyFilePath = strFilePath;
        //                    }
        //                }

        //                if (EalyFilePath != string.Empty)
        //                {
        //                    File.Delete(EalyFilePath);
        //                }
        //            }
        //        }
        //    }

        //    StreamWriter sw = null;
        //    try
        //    {
        //       // string strDirectoryPath = "D:\DataBase\";
        //        sw = new StreamWriter(strDirectoryPath + "\\" + FileName+".txt", true, Encoding.Default);

        //        sw.Write(strContent);
        //    }
        //    catch (Exception ex)
        //    {
        //       // createErrorLog.CreateLogFile(ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        sw.Close();
        //        sw.Dispose();
        //    }

        //}

        //     #region 检测要保存文件的目录是否存在
        ///// <summary>
        ///// 检测要保存文件的目录是否存在
        ///// </summary>
        //public void DetectDirectoryIsExists()
        //{
        //    string strErr = string.Empty;
        //    if (!Directory.Exists(strDirectoryPath))
        //    {
        //        try
        //        {
        //            Directory.CreateDirectory(strDirectoryPath);
        //        }
        //        catch (Exception ex)
        //        {
        //           // createErrorLog.CreateLogFile(ex.Message.ToString());
        //        }
        //    }
        //}
        //#endregion

        ///// <summary>
        ///// 计算指定文件夹下文件大小总和
        ///// </summary>
        ///// <param name="strDirectoryPath">日志文件目录</param>
        ///// <returns>返回日志文件大小总和</returns>
        //private int ReturnDirectoryFileLengthCount(string strDirectoryPath)
        //{
        //    int intFileAllSize = 0;

        //    DirectoryInfo fileDirectoryInfo = new DirectoryInfo(strDirectoryPath);

        //    foreach (FileSystemInfo fsi in fileDirectoryInfo.GetFileSystemInfos())
        //    {
        //        if (fsi is FileInfo)
        //        {
        //            FileInfo fi = (FileInfo)fsi;
        //            intFileAllSize += int.Parse(fi.Length.ToString());
        //        }
        //    }
        //    return intFileAllSize;
        //}

        //#endregion
    }
}
