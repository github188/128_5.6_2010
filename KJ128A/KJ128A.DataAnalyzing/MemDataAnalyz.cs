using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.DataAnalyzing
{
    public struct MemDataAnalyz
    {
        /// <summary>
        /// 命令类型
        /// </summary>
        public EnumDataType enumAnalyzing;

        /// <summary>
        /// 基站地址
        /// </summary>
        public int StationAddress; 

        /// <summary>
        /// 基站版本号
        /// </summary>
        public int StationVer;

        /// <summary>
        /// 标志位
        /// </summary>
        public int Mark;

        /// <summary>
        /// 数据是否有效, true 时该结构体类的数据为有效数据， false 时该结构体为无效数据
        /// </summary>
        public bool IsEnable;

        /// <summary>
        /// 命令长度
        /// </summary>
        public int CmdLength;

        /// <summary>
        /// 探头
        /// </summary>
        public MemHead[] memHead;
        
    }
}
