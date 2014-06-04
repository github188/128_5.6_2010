using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.BatmanAPI
{
    /// <summary>
    /// 结构体: 基站信息
    /// </summary>
    public struct MemStation
    {
        #region [ 属性 ] 编号

        private int _ID;

        /// <summary>
        /// 获取或设置基站编号
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        #endregion

        #region [属性：发送次数]
        private int _saveCount;
        /// <summary>
        /// 故障后切换成正常保存次数
        /// </summary>
        public int SaveCount
        {
            get { return _saveCount; }
            set { _saveCount = value; }
        }
        #endregion

        #region [ 属性 ] 地址码

        private int _Address;

        /// <summary>
        /// 地址码
        /// </summary>
        public int Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        #endregion

        #region [ 属性 ] 版本号

        private int _Ver;

        /// <summary>
        /// 版本号
        /// </summary>
        public int Ver
        {
            get { return _Ver; }
            set { _Ver = value; }
        }

        #endregion

        #region [ 属性 ] 分组号

        private int _Group;

        /// <summary>
        /// 获取或设置基站分组号
        /// </summary>
        public int Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        #endregion

        #region [ 属性 ] 状态

        private int _State;

        /// <summary>
        /// 状态
        /// </summary>
        public int State
        {
            get { return _State; }
            set
            {
                _State = value;
                switch (_State)
                {
                    case 3000:
                        _CState = "初始化";
                        break;

                    case 5000:
                        _CState = "故障";
                        break;

                    case -10000:
                        _CState = "热备通讯";
                        break;

                    case -1000:
                        _CState = "休眠";
                        break;

                    //case -1000:
                    //    _CState = "通讯故障";
                    //    break;

                    case 0:
                        _CState = "未初始化";
                        break;

                    //case 2000:
                    //    _CState = "巡检";
                    //    break;

                    //case 2100:
                    //    _CState = "信息确认";
                    //    break;

                    //case 2200:
                    //    _CState = "查询版本";
                    //    break;

                    //case 2300:
                    //    _CState = "校时";
                    //    break;

                    //case 2400:
                    //    _CState = "请求校时";
                    //    break;

                    //case 2500:
                    //    _CState = "基站重启";
                    //    break;

                    default:
                        _CState = "正常";
                        break;

                }
            }
        }

        #endregion

        #region [ 属性 ] 状态描述

        private string _CState;

        /// <summary>
        /// 状态描述
        /// </summary>
        public string CState
        {
            get { return _CState; }
            set { _CState = value; }
        }

        #endregion

        #region [属性]  发送的状态
        private int _Cmd;
        /// <summary>
        /// 发送的状态
        /// </summary>
        public int SCmd
        {
            get { return _Cmd; }
            set { _Cmd = value; }
        }
        #endregion

        #region [ 属性 ] 无回送

        private int _NoAnswer;

        /// <summary>
        /// 无回送
        /// </summary>
        public int NoAnswer
        {
            get { return _NoAnswer; }
            set { _NoAnswer = value; }
        }

        #endregion

        #region [属性：是否定点巡检]
        private bool _IsPointSelect;
        /// <summary>
        /// 是否定点巡检
        /// </summary>
        public bool IsPointSelect
        {
            get { return _IsPointSelect; }
            set { _IsPointSelect = value; }
        }
        #endregion [属性：是否定点巡检]

        #region [属性：是否双向通讯]
        private bool _isTwo;
        /// <summary>
        /// 是否双向通讯
        /// </summary>
        public bool IsTwo
        {
            get { return _isTwo; }
            set { _isTwo = value; }
        }
        #endregion

        #region 【属性：发送一定时间后定时校时】
        private DateTime m_timeCheckOut;
        /// <summary>
        /// 发送一定时间后定时校时
        /// </summary>
        public DateTime TimeCheckOut
        {
            get { return m_timeCheckOut; }
            set { m_timeCheckOut = value; }
        }
        #endregion

        #region 【属性：远程网络地址】
        private string m_strIpAddress;
        /// <summary>
        /// 远程网络地址
        /// </summary>
        public string IpAddress
        {
            get { return m_strIpAddress; }
            set { m_strIpAddress = value; }
        }
        #endregion 【属性：远程网络地址】

        #region 【属性：远程网络端口】
        private int m_port;
        /// <summary>
        /// 远程网络端口
        /// </summary>
        public int Port
        {
            get { return m_port; }
            set { m_port = value; }
        }
        #endregion 【属性：远程网络端口】

        #region [属性：分站状态]
        private int _StationModel;
        /// <summary>
        /// 分站状态
        /// </summary>
        public int StationModel
        {
            get { return _StationModel; }
            set { _StationModel = value; }
        }
        #endregion

        // 固定的命令序列

        #region [ 属性:命令 ] 获取版本号

        private byte[] _CmdVersion;

        /// <summary>
        /// 获取版本号
        /// </summary>
        public byte[] CmdVersion
        {
            get { return _CmdVersion; }
            set { _CmdVersion = value; }
        }

        #endregion

        #region [ 属性:命令 ] 巡检

        private byte[] _CmdPolling;

        /// <summary>
        /// 巡检
        /// </summary>
        public byte[] CmdPolling
        {
            get { return _CmdPolling; }
            set { _CmdPolling = value; }
        }

        #endregion

        #region [ 属性:命令 ] 信息确认

        private byte[] _CmdPollingRight;

        /// <summary>
        /// 信息确认
        /// </summary>
        public byte[] CmdPollingRight
        {
            get { return _CmdPollingRight; }
            set { _CmdPollingRight = value; }
        }

        #endregion

        #region [ 属性:命令 ] 重启

        private byte[] _CmdReset;

        /// <summary>
        /// 重启命令
        /// </summary>
        public byte[] CmdReset
        {
            get { return _CmdReset; }
            set { _CmdReset = value; }
        }

        #endregion

        #region [属性：命令] 双向命令
        private byte[] _cmdTwo;
        /// <summary>
        /// 双向命令
        /// </summary>
        public byte[] CmdTwo
        {
            get { return _cmdTwo; }
            set { _cmdTwo = value; }
        }
        #endregion


        //#region 【Czlt-2011-12-20 分站故障是重启分站】

        ///// <summary>
        ///// Czlt-2011-12-20 分站信息
        ///// </summary>
        //private bool _isStaFault;

        ///// <summary>
        ///// Czlt-2011-12-20 分站故障时重启
        ///// </summary>
        //public bool IsStaFault
        //{
        //    get { return _isStaFault; }
        //    set { _isStaFault = value; }
        //}

        //#endregion
    }
}
