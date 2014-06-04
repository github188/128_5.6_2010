using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.Protocol
{
    /// <summary>
    /// 2006-6-10 协议
    /// </summary>
    public class P20060610
    {
        #region [对时命令]
        /// <summary>
        /// 发送对时命令
        /// </summary>
        /// <param name="stationID"></param>
        /// <returns></returns>
        public static byte[] sendTime(int stationID)
        {
            DateTime tempDT = DateTime.Now;
            byte[] eBit = new byte[1];
            byte[] Fs = new byte[14];
            Fs[0] = 10;
            for (int i = 1; i <= 5; i++)
            {
                Fs[i] = 255;
            }
            Fs[6] = (byte)stationID;//基站地址号
            Fs[7] = 23;//命令号
            Fs[8] = 3;//长度
            Fs[9] = (byte)tempDT.Hour;//当前时间的小时部分
            Fs[10] = (byte)tempDT.Minute;//当前时间的分部分
            Fs[11] = (byte)tempDT.Second;//当前时间的秒部分
            eBit = CRCVerify.Crc(Fs, 12, 1);
            Fs[12] = eBit[1];//低位
            Fs[13] = eBit[0];//高位
            return Fs;
        }
        #endregion

        #region [数据确认命令]
        /// <summary>
        /// 数据确认命令
        /// </summary>
        /// <param name="stationID"></param>
        /// <returns></returns>
        public static byte[] sendInfoAffirm(int stationID)
        {
            byte[] eBit = new byte[1];
            byte[] Fs = new byte[10];
            Fs[0] = 10;
            for (int i = 1; i <= 5; i++)
            {
                Fs[i] = 255;
            }
            Fs[6] = (byte)stationID;//分站号
            Fs[7] = 21;     //命令号
            eBit = CRCVerify.Crc(Fs, 8, 1);
            Fs[8] = eBit[1]; //低位
            Fs[9] = eBit[0]; //高位
            return Fs;
        }
        #endregion

        #region [要数据命令]
        /// <summary>
        /// 要数据命令
        /// </summary>
        /// <param name="stationID"></param>
        /// <returns></returns>
        public static byte[] sendScout(int stationID)
        {
            byte[] eBit = new byte[1];
            byte[] Fs = new byte[10];
            Fs[0] = 10;
            for (int i = 1; i <= 5; i++)
            {
                Fs[i] = 255;
            }
            Fs[6] = (byte)stationID;//分站号
            Fs[7] = 20;     //命令号
            eBit = CRCVerify.Crc(Fs, 8, 1);
            Fs[8] = eBit[1]; //低位
            Fs[9] = eBit[0]; //高位
            return Fs;
        }
        #endregion

        #region [重启]
        /// <summary>
        /// 重启分站
        /// </summary>
        /// <param name="stationID">分站编号</param>
        /// <returns></returns>
        public static byte[] Reset(int stationID)
        {
            try
            {
                byte[] Fs = new byte[8];
                Fs[0] = 10;
                for (int i = 1; i <= 5; i++)
                {
                    Fs[i] = 255;
                }
                Fs[6] = (byte)stationID; // 分站号
                Fs[7] = 25; // 命令号
                return Fs;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
