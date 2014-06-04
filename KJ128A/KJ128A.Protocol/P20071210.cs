using System;
using System.Collections.Generic;
using System.Text;


namespace KJ128A.Protocol
{
    /// <summary>
    /// 2007-12-10 日协议
    /// </summary>
    public class P20071210
    {
        #region 巡检命令 [20]

        /// <summary>
        /// 巡检命令
        /// </summary>
        /// <param name="iStationAddress">基站地址</param>
        /// <param name="iMark">主备标志</param>
        /// <returns></returns>
        public static byte[] Polling(int iStationAddress, int iMark)
        {
            try
            {
                //byte[] eBit;
                //byte[] Fs = new byte[11];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // 分站号
                //Fs[7] = 20; // 命令号
                //Fs[8] = (byte)iMark; // 主备标志
                //eBit = CRCVerify.Crc(Fs, 9, 1);
                //Fs[9] = eBit[1]; // 低位
                //Fs[10] = eBit[0]; // 高位
                //return Fs;
                byte[] eBit;
                byte[] Fs = new byte[12];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // 分站号
                Fs[8] = 20; // 命令号
                Fs[9] = (byte)iMark; // 主备标志
                eBit = CRCVerify.Crc(Fs, 10, 2);
                Fs[10] = eBit[1]; // 低位
                Fs[11] = eBit[0]; // 高位
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 数据确认命令 [21]

        /// <summary>
        /// 数据确认命令
        /// </summary>
        /// <param name="iStationAddress">基站地址</param>
        /// <param name="iMark">主备标志</param>
        /// <returns></returns>
        public static byte[] PollingRight(int iStationAddress, int iMark)
        {
            try
            {
                //byte[] eBit;
                //byte[] Fs = new byte[11];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // 分站号
                //Fs[7] = 21; // 命令号
                //Fs[8] = (byte)iMark; // 主备标志
                //eBit = CRCVerify.Crc(Fs, 9, 1);
                //Fs[9] = eBit[1]; // 低位
                //Fs[10] = eBit[0]; // 高位
                //return Fs;

                byte[] eBit;
                byte[] Fs = new byte[12];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // 分站号
                Fs[8] = 21; // 命令号
                Fs[9] = (byte)iMark; // 主备标志
                eBit = CRCVerify.Crc(Fs, 10, 2);
                Fs[10] = eBit[1]; // 低位
                Fs[11] = eBit[0]; // 高位
                return Fs;

            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 基站对时命令 [23]

        /// <summary>
        /// 基站对时命令
        /// </summary>
        /// <param name="iStationAddress">基站地址</param>
        /// <param name="iMark">主备标志</param>
        /// <returns></returns>
        public static byte[] SyncDate(int iStationAddress, int iMark)
        {
            try
            {
                //DateTime tempDT = DateTime.Now;
                //byte[] eBit;
                //byte[] Fs = new byte[17];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // 基站地址号
                //Fs[7] = 23; // 命令号
                //Fs[8] = (byte)iMark; // 主备标志
                //Fs[9] = (byte)(tempDT.Year - 2000);     // 年
                //Fs[10] = (byte)tempDT.Month;            // 月
                //Fs[11] = (byte)tempDT.Day;             // 日
                //Fs[12] = (byte)tempDT.Hour; // 当前时间的小时部分
                //Fs[13] = (byte)tempDT.Minute; // 当前时间的分部分
                //Fs[14] = (byte)tempDT.Second; // 当前时间的秒部分
                //eBit = CRCVerify.Crc(Fs, 15, 1);
                //Fs[15] = eBit[1]; //低位
                //Fs[16] = eBit[0]; //高位
                //return Fs;

                DateTime tempDT = DateTime.Now;
                byte[] eBit;
                byte[] Fs = new byte[18];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // 基站地址号
                Fs[8] = 23; // 命令号
                Fs[9] = (byte)iMark; // 主备标志
                Fs[10] = (byte)(tempDT.Year - 2000);     // 年
                Fs[11] = (byte)tempDT.Month;            // 月
                Fs[12] = (byte)tempDT.Day;             // 日
                Fs[13] = (byte)tempDT.Hour; // 当前时间的小时部分
                Fs[14] = (byte)tempDT.Minute; // 当前时间的分部分
                Fs[15] = (byte)tempDT.Second; // 当前时间的秒部分
                eBit = CRCVerify.Crc(Fs, 16, 2);
                Fs[16] = eBit[1]; //低位
                Fs[17] = eBit[0]; //高位
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 基站重启命令 [25]

        /// <summary>
        /// 基站重启命令
        /// </summary>
        /// <param name="iStationAddress">基站地址</param>
        /// <param name="iMark">主备标志</param>
        /// <param name="iStationHead">控头地址</param>
        /// <returns></returns>
        public static byte[] Reset(int iStationAddress, int iMark, int iStationHead)
        {
            try
            {
                //byte[] eBit;
                //byte[] Fs = new byte[12];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // 分站号
                //Fs[7] = 25; // 命令号
                //Fs[8] = (byte)iMark; // 主备标志
                //Fs[9] = (byte)iStationHead; // 探头号
                //eBit = CRCVerify.Crc(Fs, 10, 1);
                //Fs[10] = eBit[1]; // 低位
                //Fs[11] = eBit[0]; // 高位
                //return Fs;

                byte[] eBit;
                byte[] Fs = new byte[13];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // 分站号
                Fs[8] = 25; // 命令号
                Fs[9] = (byte)iMark; // 主备标志
                Fs[10] = (byte)iStationHead; // 探头号
                eBit = CRCVerify.Crc(Fs, 11, 2);
                Fs[11] = eBit[1]; // 低位
                Fs[12] = eBit[0]; // 高位
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 版本号查询 [22]

        /// <summary>
        /// 版本号查询
        /// </summary>
        /// <param name="iStationAddress">基站地址</param>
        /// <param name="iStationHead">探头地址</param>
        /// <param name="iMark">主备标志</param>
        /// <returns></returns>
        public static byte[] Version(int iStationAddress, int iStationHead, int iMark)
        {
            try
            {
                //byte[] eBit;
                //byte[] Fs = new byte[12];
                //Fs[0] = 10;
                //for (int i = 1; i <= 5; i++)
                //{
                //    Fs[i] = 255;
                //}
                //Fs[6] = (byte)iStationAddress; // 分站号
                //Fs[7] = 22; // 命令号
                //Fs[8] = (byte)iMark; // 主备标志
                //Fs[9] = (byte)iStationHead; // 探头号
                //eBit = CRCVerify.Crc(Fs, 10, 1);
                //Fs[10] = eBit[1]; // 低位
                //Fs[11] = eBit[0]; // 高位
                //return Fs;

                byte[] eBit;
                byte[] Fs = new byte[13];
                Fs[0] = 00;
                Fs[1] = 10;
                for (int i = 2; i <= 6; i++)
                {
                    Fs[i] = 255;
                }
                Fs[7] = (byte)iStationAddress; // 分站号
                Fs[8] = 22; // 命令号
                Fs[9] = (byte)iMark; // 主备标志
                Fs[10] = (byte)iStationHead; // 探头号
                eBit = CRCVerify.Crc(Fs, 11, 2);
                Fs[11] = eBit[1]; // 低位
                Fs[12] = eBit[0]; // 高位
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 双向通讯 [33]

        /// <summary>
        /// 双向通讯命令（呼叫标识卡）
        /// </summary>
        /// <param name="iStationAddress">传输分站号</param>
        /// <param name="iStationHead">读卡分站号</param>
        /// /<param name="iCardNO">标识卡卡号</param>
        /// <param name="iMark">主备标志</param>
        /// <returns></returns>       
        public static byte[] TwoMessage(int iStationAddress, int iStationHead, int iCardNO, int iMark)
        {
            try
            {
                //byte[] eBit;
                //byte[] iCard;
                //byte[] Fs = new byte[14];
                //Fs[0] = 10;
                //Fs[1] = 255;
                //Fs[2] = 255;
                //Fs[3] = 255;
                //Fs[4] = 255;
                //Fs[5] = 255;
                //Fs[6] = (byte)iStationAddress; // 传输分站号
                //Fs[7] = 33; // 命令号
                //Fs[8] = (byte)iMark; // 主备标志
                //Fs[9] = (byte)iStationHead; // 读卡分站号（0X00 即0时表示所有读卡分站）

                //iCard = SetCardNO(iCardNO);//标识卡卡号(0XFF+0XFF 即65535 是为群发)
                //Fs[10] = iCard[0];
                //Fs[11] = iCard[1];
                //eBit = CRCVerify.Crc(Fs, 12, 1);
                //Fs[12] = eBit[1]; // 低位
                //Fs[13] = eBit[0]; // 高位
                //return Fs;

                byte[] eBit;
                byte[] iCard;
                byte[] Fs = new byte[15];
                Fs[0] = 00;
                Fs[1] = 10;
                Fs[2] = 255;
                Fs[3] = 255;
                Fs[4] = 255;
                Fs[5] = 255;
                Fs[6] = 255;
                Fs[7] = (byte)iStationAddress; // 传输分站号
                Fs[8] = 33; // 命令号
                Fs[9] = (byte)iMark; // 主备标志
                Fs[10] = (byte)iStationHead; // 读卡分站号（0X00 即0时表示所有读卡分站）

                iCard = SetCardNO(iCardNO);//标识卡卡号(0XFF+0XFF 即65535 是为群发)
                Fs[11] = iCard[0];
                Fs[12] = iCard[1];
                eBit = CRCVerify.Crc(Fs, 13, 2);
                Fs[13] = eBit[1]; // 低位
                Fs[14] = eBit[0]; // 高位
                return Fs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region【方法：整型卡号转换成byte数组】
        /// <summary>
        /// 整型卡号转换成byte数组
        /// </summary>
        /// <param name="CardNO">标识卡卡号</param>
        /// <returns></returns>
        private static byte[] SetCardNO(int CardNO)
        {
            try
            {
                byte[] icard = BitConverter.GetBytes(CardNO);
                byte[] Fs = new byte[2];
                Fs[0] = icard[1];
                Fs[1] = icard[0];
                return Fs;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        public static byte[] Two(int iStationAddress, int iMark,int iCard,string strMessage)
        {
            try
            {
                byte[] eBit;
                byte[] Fs = new byte[55];
                Fs[0] = 10;
                for (int i = 1; i <= 5; i++)
                {
                    Fs[i] = 255;
                }
                Fs[6] = (byte)iStationAddress; // 基站地址号
                Fs[7] = 19; // 命令号
                Fs[8] = (byte)iMark; // 主备标志
                Fs[9] = (byte)43;     // 长度
                Fs[10] = (byte)0;            // 控制
                if (iCard > 0)
                {
                    if (iCard > 256)
                    {
                        Fs[11] = (byte)(iCard / 256);
                        Fs[12] = (byte)(iCard - 256);
                    }
                    else
                    {
                        Fs[11] = (byte)0;
                        Fs[12] = (byte)iCard;
                    }
                    
                }
                else
                {
                    Fs[11] = (byte)0; // 卡号
                    Fs[12] = (byte)0; // 卡号
                }
                byte[] bMessage = new byte[40];
                Encoding.ASCII.GetBytes(strMessage, 0, strMessage.Length, bMessage, 0);
                for (int i = 0; i < 40; i++)
                {
                    Fs[13 + i] = bMessage[i];
                }
                eBit = CRCVerify.Crc(Fs, 53, 1);
                Fs[53] = eBit[1]; //低位
                Fs[54] = eBit[0]; //高位
                return Fs;
            }
            catch
            {
                return null;
            }
        }
    }
}
