using System;
using System.Collections;
using System.Text;
using System.Data;
using KJ128A.Controls.Batman;

namespace KJ128A.DataAnalyzing
{
    public class DataAnalyzing
    {
        #region [ ����: ���ݷ��� ]

        public MemDataAnalyz Analyzing(byte[] cmdInfo, int stationModel)
        {
            if (cmdInfo == null)
            {
                return new MemDataAnalyz();
            }
            
            // ������Чָ��
            int iSAddress = cmdInfo[0];     // ��վ��
            int iCmdNO = cmdInfo[1];        // �����
            MemDataAnalyz memDataAnalyz = new MemDataAnalyz();
            switch (stationModel)
            {
                case 1:
                case 3:
                    #region ��KJ128A������
                    int iMark = cmdInfo[2];         // ������־
                    memDataAnalyz.IsEnable = true;

                    memDataAnalyz.StationAddress = iSAddress;
                    memDataAnalyz.Mark = iMark;

                    switch (iCmdNO)
                    {
                        case 22:    // ��ѯ�汾
                            memDataAnalyz.StationVer = cmdInfo[6] + cmdInfo[7] * 256;       // ��ȡ�汾��
                            memDataAnalyz.enumAnalyzing = EnumDataType.Ver;
                            memDataAnalyz.CmdLength = 3;
                            return memDataAnalyz;

                        case 23:    // Уʱ
                            memDataAnalyz.enumAnalyzing = EnumDataType.SyncDate;
                            return memDataAnalyz;

                        case 20:    // Ѳ��
                            memDataAnalyz.enumAnalyzing = EnumDataType.Polling;
                            return AnalysisPolling_20071210_1(cmdInfo, memDataAnalyz);

                        case 21:    // ����ȷ��
                            memDataAnalyz.enumAnalyzing = EnumDataType.PollingRight;
                            return memDataAnalyz;

                        default:
                            memDataAnalyz.IsEnable = false;
                            return memDataAnalyz;
                    }
                    #endregion
                default:
                    #region [KJ128V2����]
                    memDataAnalyz.IsEnable = false;

                    memDataAnalyz.StationAddress = iSAddress;

                    switch (iCmdNO)
                    {
                        case 23:    // Уʱ
                            memDataAnalyz.enumAnalyzing = EnumDataType.SyncDate;
                            return memDataAnalyz;

                        case 20:    // Ѳ��
                            memDataAnalyz.enumAnalyzing = EnumDataType.Polling;
                            return AnalysisPolling_20060610_1(cmdInfo, memDataAnalyz);

                        case 21:    // ����ȷ��
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

        #region [ ����: ʹ�� 2007-12-10 �� 1 ��Э��������� ]

        /// <summary>
        /// ʹ�� 2007-12-10 �� 1 ��Э���������
        /// </summary>
        private static MemDataAnalyz AnalysisPolling_20071210_1(byte[] cmdRight, MemDataAnalyz memDataAnalyz)
        {   
            int iCmdLength = cmdRight[3] + cmdRight[4] * 256; // �����

            memDataAnalyz.IsEnable = true;
            memDataAnalyz.CmdLength = iCmdLength;

            int iCmdLoc = 5;
            ArrayList arrayList = new ArrayList();

            while (iCmdLoc < iCmdLength + 5)
            {
                MemHead memHead = new MemHead();

                #region [ ���̽ͷ����ʱ���״̬ ]

                memHead.IsBreak = false;                // ̽ͷ�Ƿ����

                int iSHead = cmdRight[iCmdLoc];         // ̽ͷ��
                int iSecond = cmdRight[iCmdLoc + 4];    // �룬�������λ 1 ʱ��ʾ̽ͷ����
                memHead.HeadAddress = iSHead;

                DateTime dtTime = DateTime.Now;

                int iPerCount = 0;
                int iPerLength = 0;

                //Czlt-2011-11-17--��ֱ������
                if (iSHead == 7)
                {
                    //if (iSecond >= 128)
                    //    iSecond = iSecond - 128;

                    if (cmdRight[iCmdLoc + 1] != 0)
                    {
                        // ���յ����ݵ�ʱ��
                        dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                            cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);

                        memHead.Time = dtTime;
                    }

                    iPerCount = cmdRight[iCmdLoc + 5];              // ����
                    iPerLength = cmdRight[iCmdLoc + 5] * 2;         // ����
                    memHead.CodeCount = iPerCount;                  // ̽ͷ��⵽������
                }
                else
                {
                    if (iSecond >= 128)
                    {
                        // �����λΪ 1 ʱ̽ͷ����
                        iSecond = iSecond - 128;

                        if (cmdRight[iCmdLoc + 1] != 0)
                        {
                            // ���յ����ݵ�ʱ��
                            dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                                cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);

                            memHead.Time = dtTime;
                        }

                        memHead.IsBreak = true;         // ��̽ͷ����
                    }
                    else
                    {
                        if (cmdRight[iCmdLoc + 1] != 0)
                        {
                            dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                                cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);
                            memHead.Time = dtTime;

                        }

                        iPerCount = cmdRight[iCmdLoc + 5];              // ����
                        iPerLength = cmdRight[iCmdLoc + 5] * 2;         // ����
                        memHead.CodeCount = iPerCount;                  // ̽ͷ��⵽������
                    }

                }
                #endregion

                #region [ ̽ͷ���յ��Ŀ��� ]

                StringBuilder sbHeadA = new StringBuilder();    // ̽ͷ A ���յ��ķ�����
                StringBuilder sbHeadB = new StringBuilder();    // ̽ͷ B ���յ��ķ�����
                StringBuilder sbHeadC = new StringBuilder();    // ̽ͷ ���յ�ȫΪ 0 �ķ�����   ��
                StringBuilder sbHeadD = new StringBuilder();    // ̽ͷ ���յ�ȫΪ 1 �ķ�����   ���
                StringBuilder sbHeadE = new StringBuilder();    // �͵���   ̽ͷ A ���յ��ķ�����
                StringBuilder sbHeadF = new StringBuilder();    // �͵���   ̽ͷ B ���յ��ķ�����
                StringBuilder sbHeadG = new StringBuilder();    // �͵���   ̽ͷ ���յ�ȫΪ 0 �ķ�����   ��
                StringBuilder sbHeadH = new StringBuilder();    // �͵���   ̽ͷ ���յ�ȫΪ 1 �ķ�����   ���

                //Czlt-2011-11-17-��ӽ�ֱ�����ж�
                StringBuilder dyHead = new StringBuilder();

                int i;
                for (i = iCmdLoc + 6; i < iCmdLoc + 6 + iPerLength; i += 2)
                {
                    int iCard = cmdRight[i] + cmdRight[i + 1] * 256;

                    #region ��Czlt-2011-11-17 ��ֱ�����硿
                    //Czlt -2011-11-17 -��ֱ������
                    if (iCard == 24486) //����
                    {
                        dyHead.Append("3.");
                    }
                    else if (iCard == 24487) //ֱ��
                    {
                        dyHead.Append("2.");
                    }

                    #endregion
                    if (iCard > 49152)//���
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
                    else if (iCard >= 32768)//A����
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
                    else if (iCard >= 16384)//B����
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
                    else//��
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

                //Czlt-2011-11-17 ��ֱ����Դ
                memHead.CodesDY = dyHead.ToString();

                if (memHead.IsBreak)
                {
                    iCmdLoc = i - 1;
                }
                else
                {
                    iCmdLoc = i;
                }

                // ��ʾ̽ͷ�����������ſ�
                if (iPerCount > 0)
                {
//                    RTxtMsgc.WriteTxt(strMsg.ToString(), " RX", true);
                    //return strMsg.ToString();
                }

                #endregion

                arrayList.Add(memHead);

                #region [ �����λ�Ƿ���� ]

                if (cmdRight[iCmdLoc++] != 255)
                {
                    break;
                }

                #endregion
            }

            // ��ʼ��̽ͷ
            memDataAnalyz.memHead= new MemHead[arrayList.Count];
            
            // ѭ�����̽ͷ
            for (int i = 0; i < arrayList.Count;i++ )
            {
                memDataAnalyz.memHead[i] = (MemHead)arrayList[i];
            }

            return memDataAnalyz;
        }

        #endregion

        #region [ ����: ʹ�� 2006-6-10 �� 1 ��Э��������� ]

        /// <summary>
        /// ʹ�� 2007-12-10 �� 1 ��Э���������
        /// </summary>
        private static MemDataAnalyz AnalysisPolling_20060610_1(byte[] cmdRight, MemDataAnalyz memDataAnalyz)
        {
            int iCmdLength = cmdRight[2] + cmdRight[3] * 256; // �����

            memDataAnalyz.IsEnable = true;
            memDataAnalyz.CmdLength = iCmdLength;

            ArrayList arrayList = new ArrayList();

            // ����
            int iPerCount = cmdRight[4] + cmdRight[5] * 256;
            //��ȡ���ݵ�ʱ��
            DateTime dtTime = BuildDateTime(cmdRight[6], cmdRight[7], cmdRight[8]);
            
            MemHead memHead = new MemHead();
            memHead.Time = dtTime;
            memHead.CodeCount = iPerCount;                  // ̽ͷ��⵽������
            memHead.HeadAddress = 0;
            memHead.IsBreak = true;

            #region [ ��վ���յ��Ŀ��� ]
            StringBuilder sbHeadA = new StringBuilder();    // ��վ ���յ����λΪ 1 �ķ�����  ����վ
            StringBuilder sbHeadC = new StringBuilder();    // ��վ ��һλ�͵ڶ�λΪ0 �ķ�����  ����վ
            StringBuilder sbHeadD = new StringBuilder();    // ��վ ���յ�ȫΪ 1 �ķ�����   �����
            StringBuilder sbHeadE = new StringBuilder();    // �͵���  ��վ ���յ����λΪ 1 �ķ�����   ����վ
            StringBuilder sbHeadG = new StringBuilder();    // �͵���  ��վ ��һλ�͵ڶ�λΪ0 �ķ�����  ����վ
            StringBuilder sbHeadH = new StringBuilder();    // �͵���  ��վ ���յ�ȫΪ 1 �ķ�����   �����
            for (int i = 0; i < iPerCount; i++)
            {
                int iCard;
                iCard = (int)cmdRight[9 + 2 * i] + (int)cmdRight[10 + 2 * i] * 256;
                if (iCard != 29998 && iCard != 62766 && iCard !=29999)
                {
                    if (iCard > 49152)//���
                    {
                        iCard = iCard - 49152;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadH.Append(iCard + ",");
                        }
                        sbHeadD.Append(iCard + ",");
                    }
                    else if (iCard >= 32768)//����վ
                    {
                        iCard = iCard - 32768;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadE.Append(iCard + ",");
                        }
                        sbHeadA.Append(iCard + ",");
                    }
                    else if (iCard >= 16384)//B����
                    {
                        //iCard = iCard - 16384;
                        //if (iCard > 8192)
                        //{
                        //    iCard = iCard - 8192;
                        //    sbHeadF.Append(iCard + ",");
                        //}
                        //sbHeadB.Append(iCard + ",");
                    }
                    else//����վ
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

            // ��ʼ��̽ͷ
            memDataAnalyz.memHead = new MemHead[arrayList.Count];

            // ѭ�����̽ͷ
            for (int i = 0; i < arrayList.Count; i++)
            {
                memDataAnalyz.memHead[i] = (MemHead)arrayList[i];
            }

            return memDataAnalyz;
        }

        #endregion

        #region [ ����: BuildDateTime ���ݽ��յ���ʱ�䣬�����µ�ʱ�� ]

        /// <summary>
        /// ����ʱ��
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
                // ʱ�䲻�Ϸ����򷵻�ϵͳ��Сʱ��
                if (Day >= 32 || Hour >= 24 || Minute >= 60 || Second >= 60)
                {
                    return new DateTime(2000, 1, 1, 0, 0, 1);
                }

                int int_Year = dtTime.Year;
                int int_Month = dtTime.Month;

                // ��ǰ��ĩ
                if (dtTime.Day == DateTime.DaysInMonth(int_Year, int_Month))
                {
                    // �ϴ�����Ϊ�³�
                    if (Day == 1)
                    {
                        int_Month++;
                    }
                }
                else
                {
                    // ��ǰ�³�
                    if (dtTime.Day == 1)
                    {
                        // �ϴ�����Ϊ��ĩ
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
                        // ���³���ĩ
                        if (Day > dtTime.Day + 1)
                        {
                            int_Month--;
                        }
                    }
                }

                // �����µ�ʱ��
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
        /// ����ʱ��
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
                // ʱ�䲻�Ϸ����򷵻�ϵͳ��Сʱ��
                if (Hour >= 24 || Minute >= 60 || Second >= 60)
                {
                    return new DateTime(2000, 1, 1, 0, 0, 1);
                }

                //���յ����ݵ�ʱ���֡���
                int int_Year = dtTime.Year;
                int int_Month = dtTime.Month;
                int int_Day = DateTime.Now.Day;
                DateTime dtTimeGet = new DateTime(int_Year, int_Month, int_Day, Hour, Minute, Second);

                if (dtTime >= dtTimeGet.AddMinutes(-5)) //��ǰʱ����ڷ������ݵ�ʱ��
                {
                    return dtTimeGet;
                }
                else //��һ��
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
