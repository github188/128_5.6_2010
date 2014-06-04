using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NDataBase
{

    /// <summary>
    /// 硬件设备名称枚举
    /// </summary>
    public enum CorpsName
    {
        /// <summary>
        /// 分站
        /// </summary>
        Station,

        /// <summary>
        /// 分站编号
        /// </summary>
        StationAddress,

        /// <summary>
        /// 分站安装位置
        /// </summary>
        StationSplace,

        /// <summary>
        /// 接收器
        /// </summary>
        StaHead,

        /// <summary>
        /// 接收器编号
        /// </summary>
        StaHeadAddress,

        /// <summary>
        /// 接收器安装位置
        /// </summary>
        StaHeadSplace,

        /// <summary>
        /// 监测时间
        /// </summary>
        Inspect,

        /// <summary>
        /// 发码器
        /// </summary>
        CodeSender,

        /// <summary>
        /// 发码器编号
        /// </summary>
        CodeSenderAddress,

        /// <summary>
        /// 入井时刻
        /// </summary>
        InWellTime,

        /// <summary>
        /// 出井时刻
        /// </summary>
        OutWellTime,

        /// <summary>
        /// 下井工作时间
        /// </summary>
        StandingWellTime,

        /// <summary>
        /// 进入区域时刻
        /// </summary>
        InTerritorialTime,

        /// <summary>
        /// 离开区域时刻
        /// </summary>
        OutTerritorialTime,

        /// <summary>
        /// 滞留时间
        /// </summary>
        StandingTime

    }

    /// <summary>
    /// 硬件设备名称
    /// </summary>
    public class HardwareName
    {
        public static string Value(CorpsName hName)
        {
            string strTmp = string.Empty;
            switch (hName)
            {
                case CorpsName.Station:
                    strTmp = "传输分站";
                    break;
                case CorpsName.StationAddress:
                    strTmp = "传输分站编号";
                    break;
                case CorpsName.StationSplace:
                    strTmp = "传输分站安装位置";
                    break;
                case CorpsName.StaHead:
                    strTmp = "读卡分站";
                    break;
                case CorpsName.StaHeadAddress:
                    strTmp = "读卡分站编号";
                    break;
                case CorpsName.StaHeadSplace:
                    strTmp = "读卡分站安装位置";
                    break;
                case CorpsName.Inspect:
                    strTmp = "监测时间";
                    break;
                case CorpsName.CodeSender:
                    strTmp = "标识卡";
                    break;
                case CorpsName.CodeSenderAddress:
                    strTmp = "标识卡编号";
                    break;
                case CorpsName.InWellTime:
                    strTmp = "入井时刻";
                    break;
                case CorpsName.OutWellTime:
                    strTmp = "出井时刻";
                    break;
                case CorpsName.StandingWellTime:
                    strTmp = "下井工作时间";
                    break;
                case CorpsName.InTerritorialTime:
                    strTmp = "进入区域时刻";
                    break;
                case CorpsName.OutTerritorialTime:
                    strTmp = "离开区域时刻";
                    break;
                case CorpsName.StandingTime:
                    strTmp = "滞留时间";
                    break;
                default:
                    break;
            }
            return strTmp;
        }   
    }

    
}
