using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.BatmanAPI
{
    /// <summary>
    /// 基站状态
    /// </summary>
    public enum EnumStationState
    {
        /// <summary>
        /// 基站未启用
        /// </summary>
        NoInit = 0,

        /// <summary>
        /// 基站重启
        /// </summary>
        Reset = 2500,

        /// <summary>
        /// 基站休眠
        /// </summary>
        Sleep = -1000,

        /// <summary>
        /// 基站离线
        /// </summary>
        Leave = 3000,

        /// <summary>
        /// 基站故障
        /// </summary>
        Malfunction = 5000,

        /// <summary>
        /// 查询版本
        /// </summary>
        SelectEdition=2200,
        /// <summary>
        /// 定点巡检
        /// </summary>
        PointSelect=20000,
        /// <summary>
        /// 撤销巡检
        /// </summary>
        PointCancal=20001,
    }
}
