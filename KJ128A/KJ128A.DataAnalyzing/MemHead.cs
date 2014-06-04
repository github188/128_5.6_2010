using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.DataAnalyzing
{
    public struct MemHead
    {
        /// <summary>
        /// 探头号
        /// </summary>
        public int HeadAddress;

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time;

        /// <summary>
        /// 人数
        /// </summary>
        public int CodeCount;

        /// <summary>
        /// 天线
        /// </summary>
        public int Antenna;

        /// <summary>
        /// 是否故障（true 为故障）
        /// </summary>
        public bool IsBreak;

        /// <summary>
        /// A 天线接收到的卡号
        /// </summary>
        public string CodesA;

        /// <summary>
        /// B 天线接收到的卡号
        /// </summary>
        public string CodesB;

        /// <summary>
        /// 出探头卡号
        /// </summary>
        public string CodesC;

        /// <summary>
        /// 求救卡号
        /// </summary>
        public string CodesD;

        /// <summary>
        ///  低电量  A 天线接收到的卡号
        /// </summary>
        public string CodesE;
        /// <summary>
        /// 低电量  B 天线接收到的卡号
        /// </summary>
        public string CodesF;
        /// <summary>
        /// 低电量  出探头卡号
        /// </summary>
        public string CodesG;
        /// <summary>
        /// 低电量  求救卡号
        /// </summary>
        public string CodesH;

        /// <summary>
        /// Czlt-2011-11-17 - 交直流供电
        /// </summary>
        public string CodesDY;
    }
}
