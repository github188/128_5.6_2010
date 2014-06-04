using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.DataAnalyzing
{
    public enum EnumDataType
    {
        /// <summary>
        /// 基站版本
        /// </summary>
        Ver,

        /// <summary>
        /// 巡检命令
        /// </summary>
        Polling,

        /// <summary>
        /// 数据确认
        /// </summary>
        PollingRight,

        /// <summary>
        /// 基站校时
        /// </summary>
        SyncDate
    }
}
