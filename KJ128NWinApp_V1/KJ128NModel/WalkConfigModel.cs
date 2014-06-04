using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    /// <summary>
    /// 行走异常配置类
    /// </summary>
    public class WalkConfigModel
    {
        /// <summary>
        /// 行走异常配置Id
        /// </summary>
        private int walkConfigId;
        /// <summary>
        /// 行走异常配置Id
        /// </summary>
        public int WalkConfigId 
        {
            get { return walkConfigId; }
            set { walkConfigId = value; } 
        }

        /// <summary>
        /// 人员编号
        /// </summary>
        private int empId;
        /// <summary>
        /// 人员编号
        /// </summary>
        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        /// <summary>
        /// 规定行走时长(以秒计算)
        /// </summary>
        private int timeValue;
        /// <summary>
        /// 规定行走时长(以秒计算)
        /// </summary>
        public int TimeValue
        {
            get { return timeValue; }
            set { timeValue = value; }
        }

        /// <summary>
        /// 第一个点（分站编号，探测器编号，天线A，天线B）
        /// </summary>
        private StationHeadModel firstStationHead = new StationHeadModel();
        /// <summary>
        /// 第一个点（分站编号，探测器编号，天线A，天线B）
        /// </summary>
        public StationHeadModel FirstStationHead
        {
            get { return firstStationHead; }
            set
            {
                if (value != null)
                {
                    firstStationHead = value;
                }
            }
        }

        /// <summary>
        /// 中间一个点（分站编号，探测器编号，天线A，天线B）
        /// </summary>
        private StationHeadModel middleStationHead = new StationHeadModel();
        /// <summary>
        /// 中间一个点（分站编号，探测器编号，天线A，天线B）
        /// </summary>
        public StationHeadModel MiddleStationHead
        {
            get { return middleStationHead; }
            set
            {
                if (value != null)
                {
                    middleStationHead = value;
                }
            }
        }

        /// <summary>
        /// 最后一个点（分站编号，探测器编号，天线A，天线B）
        /// </summary>
        private StationHeadModel lastStationHead = new StationHeadModel();
        /// <summary>
        /// 最后一个点（分站编号，探测器编号，天线A，天线B）
        /// </summary>
        public StationHeadModel LastStationHead
        {
            get { return lastStationHead; }
            set 
            {
                if (value != null)
                {
                    lastStationHead = value;
                }
            }
        }
    }

    /// <summary>
    /// 探测器类
    /// </summary>
    public class StationHeadModel
    {
        /// <summary>
        /// 分站地址
        /// </summary>
        private int stationAddress = 0;
        /// <summary>
        /// 分站地址
        /// </summary>
        public int StationAddress
        {
            get { return stationAddress; }
            set { stationAddress = value; }
        }

        /// <summary>
        /// 探测器地址
        /// </summary>
        private int stationHeadAddress = 0;
        /// <summary>
        /// 探测器地址
        /// </summary>
        public int StationHeadAddress
        {
            get { return stationHeadAddress; }
            set { stationHeadAddress = value; }
        }

        /// <summary>
        /// 是否天线A
        /// </summary>
        private bool stationHeadAntennaA;
        /// <summary>
        /// 是否天线A
        /// </summary>
        public bool StationHeadAntennaA
        {
            get { return stationHeadAntennaA; }
            set { stationHeadAntennaA = value; }
        }

        /// <summary>
        /// 是否天线B
        /// </summary>
        private bool stationHeadAntennaB;
        /// <summary>
        /// 是否天线B
        /// </summary>
        public bool StationHeadAntennaB
        {
            get { return stationHeadAntennaB; }
            set { stationHeadAntennaB = value; }
        }
    }
}
