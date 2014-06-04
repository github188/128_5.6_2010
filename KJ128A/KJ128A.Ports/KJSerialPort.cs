using System;
using System.Text;
using System.Threading;
using KJ128A.Controls.Batman;
using KJ128A.Protocol;
using System.IO;

namespace KJ128A.Ports
{
    /// <summary>
    /// 串口类的最终封装
    /// </summary>
    public class KJSerialPort : KJ128N_Port
    {

        #region [ 声明 ]

        /// <summary>
        /// 主机故障时备机巡检周期时间（毫秒）
        /// </summary>
        private int intHostTime = 1200;

        /// <summary>
        /// 主机正常时备机巡检周期时间（毫秒）
        /// </summary>
        private int intBackerTime = 1900;

        /// <summary>
        /// 备机发送次数
        /// </summary>
        private int backerSendCount = 0;

        private int sqlSend = 0;
        #endregion

        #region [ 属性 ] 是否数据保存

        private bool _IsSaveData;

        /// <summary>
        /// 是否数据保存
        /// </summary>
        public bool IsSaveData
        {
            get { return _IsSaveData; }
            set { _IsSaveData = value; }
        }

        #endregion

        #region [ 属性 ] 是否热备通讯中

        private int _IsMark;

        /// <summary>
        /// 是否数据保存
        /// </summary>
        public int IsMark
        {
            get { return _IsMark; }
            set { _IsMark = value; }
        }

        #endregion

        #region [属性：是否是启动热备]
        private bool _IsStartHostBacker;
        /// <summary>
        /// 是否是启动热备
        /// </summary>
        public bool IsStartHostBacker
        {
            get { return _IsStartHostBacker; }
            set { _IsStartHostBacker = value; }
        }
        #endregion [属性：是否是启动热备]

        #region [属性：是否是主/备机]
        private bool _IsHost;
        /// <summary>
        /// 是否是主/备机  true为主机  false为备机
        /// </summary>
        public bool IsHost
        {
            get { return _IsHost; }
            set { _IsHost = value; }
        }
        #endregion [属性：是否是主/备机]

        #region [属性：网络是否连接]
        /// <summary>
        /// 网络是否连接
        /// </summary>
        private bool _isNetWork;
        /// <summary>
        /// 网络是否连接
        /// </summary>
        public bool IsNetWork
        {
            get { return _isNetWork; }
            set { _isNetWork = value; }
        }
        #endregion

        #region 【属性：数据库是否连接成功】
        private bool _isDatabaseConnect;
        /// <summary>
        /// 本地数据库是否连接成功
        /// </summary>
        public bool IsDataBaseConnect
        {
            get { return _isDatabaseConnect; }
            set { _isDatabaseConnect = value; }
        }
        #endregion

        #region 【属性：是否在存数据库】
        private bool _isSaveSql;
        public bool IsSaveSql
        {
            get { return _isSaveSql; }
            set { _isSaveSql = value; }
        }
        #endregion

        #region 【属性：热备是否在运行中】
        private bool m_RbSend;
        public bool RbSend
        {
            get { return m_RbSend; }
            set { m_RbSend = value; }
        }
        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="index">索引号</param>
        /// <param name="strPortName">串口名称</param>
        /// <param name="iGroup">基站组编号</param>
        /// <param name="iMark">主备标志</param>
        public KJSerialPort(int index, string strPortName, int iGroup, int iMark)
        {
            Index = index;
            PortName = strPortName;
            Group = iGroup;
            Mark = iMark;
            intHostTime = base.sendTime;
            intBackerTime = base.sendTime + 400;

        }

        #endregion

        #region [ 声明: 委托 ] 基站状态改变

        /// <summary>
        /// 基站状态改变委托声明
        /// </summary>
        public delegate void StationStateChangedEventHandler(int index, int iAddress, int iState, string strStateRemark);

        /// <summary>
        /// 基站状态改变
        /// </summary>
        public event StationStateChangedEventHandler StationStateChanged;

        #endregion

        #region [ 声明: 委托 ] 主备工作状态切换

        /// <summary>
        /// 主备工作状态切换委托声明
        /// </summary>
        public delegate void MarkStateChangedEventHandler(int index, int IsMark);

        /// <summary>
        /// 主备工作状态切换
        /// </summary>
        public event MarkStateChangedEventHandler MarkStateChanged;

        #endregion

        #region [ 声明: 委托 ] 数据抵达

        /// <summary>
        /// 数据抵达委托声明
        /// </summary>
        /// <param name="cmdReceived"></param>
        /// <param name="iMark"></param>
        public delegate void DataReceivedEventHandler(byte[] cmdReceived, int iMark, int iGroup);

        /// <summary>
        /// 数据抵达
        /// </summary>
        public event DataReceivedEventHandler DataReceived;

        #endregion

        #region [ 方法: 发送指令 ]

        private int iStationLoc = 0;        // 当前操作的基站位置

        /// <summary>
        /// 发送指令
        /// </summary>
        public void SendCmd()
        {
            try
            {
                if (_isDatabaseConnect == true && m_RbSend == true)//数据库连接发送
                {
                    if (_isSaveSql == false)//数据库是否正在保存,如果不在则发送
                    {
                        try
                        {
                            bool isSend = false;

                            #region 是否发送数据
                            //是否启动热备
                            if (_IsStartHostBacker)
                            {
                                if (_IsHost)//主机
                                {
                                    isSend = true;
                                }
                                else//备机
                                {
                                    if (_isNetWork)//网络连接
                                    {
                                        isSend = false;

                                        // 如果当前状态标记为非热备状态，则通知通讯程序热备已经切换（赵建伟热备逻辑需要用到）
                                        if (IsMark == 0 || IsMark == 2)
                                        {
                                            IsMark = 1;
                                            MarkStateChanged(1, IsMark);
                                            base.timer.Interval = base.sendTime + 400;
                                        }

                                        // 如果发现一个基站是热备，则认定该串口所有基站都处于热备状态。
                                        for (int i = 0; i < _Stations.Length; i++)
                                        {
                                            if (_Stations[i].State != -10000)
                                            {
                                                _Stations[i].State = -10000;
                                                StationStateChanged(1, _Stations[i].Address, _Stations[i].State, _Stations[i].CState);
                                                Thread.Sleep(10);
                                            }
                                        }
                                        for (int i = 0; i < _TempStations.Length; i++)
                                        {
                                            if (_TempStations[i].State != -10000)
                                            {
                                                _TempStations[i].State = -10000;
                                            }
                                        }

                                    }
                                    else//网络不连接
                                    {
                                        isSend = true;
                                    }
                                }
                            }
                            else//不启动热备
                            {
                                isSend = true;
                            }
                            #endregion

                            if (isSend)
                            {
                                timer.Enabled = true;
                                SendCmd(ref iStationLoc);
                            }
                            else
                            {
                                timer.Enabled = true;
                            }
                        }
                        catch { timer.Enabled = true; }
                    }
                    else
                    {
                        timer.Enabled = true;
                    }
                }
                else//数据库未连接
                {
                    timer.Enabled = true;
                }
            }
            catch { timer.Enabled = true; }
        }

        #endregion

        #region [ 方法: 命令错误 ]

        /// <summary>
        /// 命令错误
        /// </summary>
        public void CmdError(string strErr, int stationModel)
        {
            try
            {
                switch (stationModel)
                {
                    case 1:
                    case 3:
                        // 提取错误
                        int iErrCmd = iEndLoc - iStartLoc + 1;
                        byte[] cmdErr = new byte[iErrCmd];
                        if (iStartLoc >= 0)
                        {
                            for (int k = 0; k < iErrCmd; k++)
                            {
                                cmdErr[k] = byteBuffer[iStartLoc + k];
                            }
                        }
                        // 显示错误信息
                        //if (RTxtMsge != null && cmdErr.Length > 0)
                        //{
                        //    RTxtMsge.WriteTxt(cmdErr, strErr, true, 0);
                        //}
                        for (int i = 0; i < byteBuffer.Length; i++)
                        {
                            byteBuffer[i] = (byte)0;
                        }

                        break;
                    default:
                        for (int i = 0; i < byteBuffer.Length; i++)
                        {
                            byteBuffer[i] = (byte)0;
                        }
                        // 显示错误信息
                        //if (RTxtMsge != null)
                        //{
                        //    RTxtMsge.WriteTxt(new byte[1], strErr, true, 0);
                        //}
                        break;
                }

            }
            catch { }

            cmdNewBytes = null;


            iStartLoc = -1;
            iEndLoc = -1;
            iEndStartLoc = -1;

            // 发送下一条指令
            if (!_Stations[iStationLoc].IsPointSelect)
            {
                iStationLoc++;
            }
            SendCmd();
        }

        #endregion

        #region [ 数据抵达 ]

        /// <summary>
        /// 数据抵达
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            base.serialPort_DataReceived(sender, e);
            try
            {
                // 如果没有一条完整指令，则不处理
                if (cmdNewBytes == null)
                {
                    if (timer.Enabled == false)
                    {
                        timer.Enabled = true;
                    }
                    return;
                }

                // 如果命令长度小于5，则不处理
                if (cmdNewBytes.Length < 3)
                {
                    if (timer.Enabled == false)
                    {
                        timer.Enabled = true;
                    }
                    return;
                }

                // 解析完整指令
                int iSAddress = cmdNewBytes[0];     // 基站号
                int iCmdNO = cmdNewBytes[1];        // 命令号
                int iCmdLength = 0;
                int iOldState = 0;
                switch (_Stations[iStationLoc].StationModel)
                {
                    case 1:
                    case 3:
                        #region [ 解析完整指令 ]

                        // 解析完整指令
                        int iMark = cmdNewBytes[2];         // 主备标志

                        // 计算命令长度
                        if (iCmdNO == 20 || iCmdNO == 22)
                        {
                            iCmdLength = cmdNewBytes[3] + cmdNewBytes[4] * 256 + 7;
                        }
                        else
                        {
                            iCmdLength = 5;
                        }

                        if (_Stations == null || _Stations.Length <= 0)
                        {
                            if (_TempStations != null && _TempStations.Length > 0)
                            {
                                _Stations = _TempStations;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        if (iMark == 0)
                        {
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }
                        // 验证主备标志是否正确
                        if (iMark != Mark)
                        {
                            // 如果不存在基站，则不处理
                            if (_Stations.Length == 0)
                            {
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            if (_IsStartHostBacker)
                            {
                                if (!_IsHost)
                                {
                                    backerSendCount = 0;
                                    // 不是热备状态时执行下述程序
                                    if (_Stations[iStationLoc].State != -10000)
                                    {
                                        if (_Stations[iStationLoc].State != -10100)
                                        {
                                            _Stations[iStationLoc].State = -10100;
                                            _Stations[iStationLoc].NoAnswer = 0;
                                        }
                                        else
                                        {
                                            _Stations[iStationLoc].NoAnswer--;

                                            // 当第 2 次回备机数据时，显示热备
                                            _Stations[iStationLoc].State = -10000;

                                            //// Error: 这个逻辑可能有问题
                                            if (_Stations[iStationLoc].NoAnswer == -2)
                                            {
                                                if (StationStateChanged != null)
                                                {
                                                    StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                                                }
                                            }


                                            // 如果发现一个基站是热备，则认定该串口所有基站都处于热备状态。
                                            for (int i = 0; i < _Stations.Length; i++)
                                            {
                                                _Stations[i].State = -10000;
                                            }
                                            for (int i = 0; i < _TempStations.Length; i++)
                                            {
                                                _TempStations[i].State = -10000;
                                            }



                                            // 如果当前状态标记为非热备状态，则通知通讯程序热备已经切换（赵建伟热备逻辑需要用到）
                                            if (IsMark == 0 || IsMark == 2)
                                            {
                                                IsMark = 1;
                                                MarkStateChanged(Index, IsMark);
                                                base.timer.Interval = base.sendTime + 400;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (IsMark == 0 || IsMark == 2)
                                        {
                                            IsMark = 1;
                                            // 如果发现一个基站是热备，则认定该串口所有基站都处于热备状态。
                                            for (int i = 0; i < _Stations.Length; i++)
                                            {
                                                _Stations[i].State = -10000;
                                            }
                                            for (int i = 0; i < _TempStations.Length; i++)
                                            {
                                                _TempStations[i].State = -10000;
                                            }
                                            MarkStateChanged(Index, IsMark);
                                            base.timer.Interval = base.sendTime + 400;
                                        }
                                    }
                                }
                                else
                                {
                                    timer_Elapsed(null, null);
                                }
                            }

                            #region [ 重置标志位 ]

                            // 重置所有的标志位
                            iStartLoc = -1;
                            iEndLoc = -1;
                            iEndStartLoc = -1;

                            #endregion

                            // 释放有效命令
                            cmdNewBytes = null;
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }
                        else
                        {
                            // 如果当前状态标记为非热备状态，则通知通讯程序热备已经切换（赵建伟热备逻辑需要用到）
                            if (IsMark == 0 || IsMark == 1)
                            {

                                if (_IsStartHostBacker)
                                {
                                    if (!_IsHost)
                                    {
                                        // 如果发现一个基站是热备，则认定该串口所有基站都处于热备状态。
                                        for (int i = 0; i < _Stations.Length; i++)
                                        {
                                            _Stations[i].State = 0;
                                        }
                                        for (int i = 0; i < _TempStations.Length; i++)
                                        {
                                            _TempStations[i].State = 0;
                                        }
                                        backerSendCount++;
                                        if (backerSendCount >= 30)
                                        {
                                            IsMark = 2;
                                            MarkStateChanged(Index, IsMark);
                                        }
                                    }
                                    else
                                    {
                                        IsMark = 2;
                                    }
                                }
                                else
                                {
                                    IsMark = 2;
                                }
                                base.timer.Interval = base.sendTime;
                            }
                        }

                        // 验证命令长度
                        if (cmdNewBytes.Length != iCmdLength)
                        {
                            CmdError(" [长度错误]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // 验证基站号是否正确
                        if (iSAddress != _Stations[iStationLoc].Address)
                        {
                            CmdError(" [传输分站号错]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // 验证命令号是否正确 iCmdNO != CmdNO
                        if (iCmdNO != _Stations[iStationLoc].SCmd && iCmdNO != 24 && iCmdNO != 33)
                        {
                            CmdError(" [命令号错]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // Crc 校验
                        byte[] cmdCrcNewBytes = new byte[cmdNewBytes.Length + 5];
                        for (int i = 0; i < 5; i++)
                        {
                            cmdCrcNewBytes[i] = 238;
                        }
                        for (int i = 5; i < cmdCrcNewBytes.Length; i++)
                        {
                            cmdCrcNewBytes[i] = cmdNewBytes[i - 5];
                        }
                        byte[] crcByte = CRCVerify.Crc(cmdCrcNewBytes, cmdCrcNewBytes.Length - 2, 0);
                        if (crcByte[0] != cmdCrcNewBytes[cmdCrcNewBytes.Length - 1] || crcByte[1] != cmdCrcNewBytes[cmdCrcNewBytes.Length - 2])
                        {
                            CmdError(" [CRC效验错] ", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        if (RTxtMsg != null)
                        {
                            // 显示命令
                            RTxtMsg.WriteTxt(cmdNewBytes, " RX", true, 0);
                        }

                        // 记录基站上次状态
                        iOldState = _Stations[iStationLoc].State;

                        #endregion
                        break;
                    default:
                        #region [ 解析完整指令 ]

                        // 解析完整指令
                        //int iMark = cmdNewBytes[2];         // 主备标志

                        // 计算命令长度

                        if (iCmdNO == 20 || iCmdNO == 22)
                        {
                            iCmdLength = cmdNewBytes[2] + cmdNewBytes[3] * 256 + 6;
                        }
                        else
                        {
                            iCmdLength = 4;
                        }

                        if (_Stations == null || _Stations.Length <= 0)
                        {
                            if (_TempStations != null && _TempStations.Length > 0)
                            {
                                _Stations = _TempStations;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        #region 备机时处理
                        // 验证主备标志是否正确
                        if (!_IsHost)
                        {
                            if (_isNetWork)
                            {
                                // 如果不存在基站，则不处理
                                if (_Stations.Length == 0)
                                {
                                    if (timer.Enabled == false)
                                    {
                                        timer.Enabled = true;
                                    }
                                    return;
                                }
                                if (_IsStartHostBacker)
                                {
                                    // 不是热备状态时执行下述程序
                                    if (_Stations[iStationLoc].State != -10000)
                                    {
                                        if (_Stations[iStationLoc].State != -10100)
                                        {
                                            _Stations[iStationLoc].State = -10100;
                                            _Stations[iStationLoc].NoAnswer = 0;
                                        }
                                        else
                                        {
                                            _Stations[iStationLoc].NoAnswer--;

                                            // 当第 2 次回备机数据时，显示热备
                                            _Stations[iStationLoc].State = -10000;

                                            //// Error: 这个逻辑可能有问题
                                            if (_Stations[iStationLoc].NoAnswer == -2)
                                            {
                                                StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                                            }


                                            // 如果发现一个基站是热备，则认定该串口所有基站都处于热备状态。
                                            for (int i = 0; i < _Stations.Length; i++)
                                            {
                                                _Stations[i].State = -10000;
                                            }
                                            for (int i = 0; i < _TempStations.Length; i++)
                                            {
                                                _TempStations[i].State = -10000;
                                            }

                                            // 如果当前状态标记为非热备状态，则通知通讯程序热备已经切换（赵建伟热备逻辑需要用到）
                                            if (IsMark == 0 || IsMark == 2)
                                            {
                                                IsMark = 1;
                                                MarkStateChanged(Index, IsMark);
                                                base.timer.Interval = base.sendTime + 400;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (IsMark == 0 || IsMark == 2)
                                        {
                                            IsMark = 1;
                                            // 如果发现一个基站是热备，则认定该串口所有基站都处于热备状态。
                                            for (int i = 0; i < _Stations.Length; i++)
                                            {
                                                _Stations[i].State = -10000;
                                            }
                                            for (int i = 0; i < _TempStations.Length; i++)
                                            {
                                                _TempStations[i].State = -10000;
                                            }
                                            MarkStateChanged(Index, IsMark);
                                            base.timer.Interval = base.sendTime + 400;
                                        }
                                    }
                                }
                                #region [ 重置标志位 ]

                                // 重置所有的标志位
                                iStartLoc = -1;
                                iEndLoc = -1;
                                iEndStartLoc = -1;

                                #endregion

                                for (int i = 0; i < byteBuffer.Length; i++)
                                {
                                    byteBuffer[i] = (byte)0;
                                }
                                // 释放有效命令
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            else
                            {
                                // 如果当前状态标记为非热备状态，则通知通讯程序热备已经切换（赵建伟热备逻辑需要用到）
                                if (IsMark == 0 || IsMark == 1)
                                {
                                    IsMark = 2;
                                    if (_IsStartHostBacker)
                                    {
                                        // 如果发现一个基站是热备，则认定该串口所有基站都处于热备状态。
                                        for (int i = 0; i < _Stations.Length; i++)
                                        {
                                            _Stations[i].State = 0;
                                        }
                                        for (int i = 0; i < _TempStations.Length; i++)
                                        {
                                            _TempStations[i].State = 0;
                                        }
                                    }
                                    MarkStateChanged(Index, IsMark);
                                    base.timer.Interval = base.sendTime;
                                }
                            }
                        }
                        #endregion

                        if (iCurLoc > iCmdLength + 5)
                        {
                            iCurLoc = 0;
                            for (int i = 0; i < byteBuffer.Length; i++)
                            {
                                byteBuffer[i] = (byte)0;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // 验证命令长度
                        if (iCmdLength <= 6 && iCmdNO == 20)
                        {
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }
                        if (iSAddress == 0 || iCmdNO == 0)
                        {
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }
                        //if (cmdNewBytes[cmdNewBytes.Length - 1] == 0 && cmdNewBytes[cmdNewBytes.Length - 2] == 0)
                        //{
                        //    if (timer.Enabled == false)
                        //    {
                        //        timer.Enabled = true;
                        //    }
                        //    return;
                        //}
                        if (cmdNewBytes.Length != iCmdLength)
                        {
                            CmdError(" [长度错误]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }


                        // 验证基站号是否正确
                        if (iSAddress != _Stations[iStationLoc].Address)
                        {
                            CmdError(" [基站号错]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // 验证命令号是否正确iCmdNO != CmdNO
                        if (iCmdNO != _Stations[iStationLoc].SCmd && iCmdNO != 24)
                        {
                            CmdError(" [命令号错]", _Stations[iStationLoc].StationModel);
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // Crc 校验
                        if (!_crcByte[0].Equals(cmdNewBytes[cmdNewBytes.Length - 1]) || !_crcByte[1].Equals(cmdNewBytes[cmdNewBytes.Length - 2]))
                        {
                            //CmdError(" [效验位错]");
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        if (RTxtMsg != null)
                        {
                            // 显示命令
                            RTxtMsg.WriteTxt(cmdNewBytes, " RX", true, 0);
                        }

                        // 记录基站上次状态
                        iOldState = _Stations[iStationLoc].State;

                        #endregion
                        break;
                }

                #region [ 重置标志位 ]

                // 重置所有的标志位
                iStartLoc = -1;
                iEndLoc = -1;
                iEndStartLoc = -1;

                #endregion

                switch (_Stations[iStationLoc].StationModel)
                {
                    case 1:
                    case 3:
                        // 分析回送的数据
                        DataAnalyzing(cmdNewBytes);
                        break;
                    default:
                        DataAnalyzing20060610(cmdNewBytes);
                        break;
                }

                #region [ 响应指令 ]

                // 基站无响应次数清零
                _Stations[iStationLoc].NoAnswer = 0;

                if (_Stations[iStationLoc].State != -1000)
                {
                    switch (_Stations[iStationLoc].StationModel)
                    {
                        case 1:
                            // 响应命令
                            switch (iCmdNO)
                            {
                                #region [ 响应: 查询版本 ]

                                case 22:    // 基站响应了查询版本
                                    //假如分站上传为故障，对时后发重启命令
                                    _Stations[iStationLoc].State = 2200;


                                    // 生成固定的命令，发送时不需要每次生成
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:

                                            // 巡检命令
                                            _Stations[iStationLoc].CmdPolling = KJ128A.Protocol.P20071210.Polling(_Stations[iStationLoc].Address, Mark);

                                            // 信息确认命令
                                            _Stations[iStationLoc].CmdPollingRight = KJ128A.Protocol.P20071210.PollingRight(_Stations[iStationLoc].Address, Mark);

                                            // 重启命令
                                            _Stations[iStationLoc].CmdReset = KJ128A.Protocol.P20071210.Reset(_Stations[iStationLoc].Address, Mark, 0);

                                            break;
                                    }
                                    //if (!_Stations[iStationLoc].IsPointSelect)
                                    //{
                                    //    iStationLoc++;
                                    //}
                                    break;

                                #endregion

                                #region [ 响应: 校时命令 ]

                                case 23:    // 基站响应了校时命令
                                    ////Czlt-2011-12-20 假如分站上传为故障，对时后发重启命令
                                    //if (_Stations[iStationLoc].IsStaFault)
                                    //{
                                    //    _Stations[iStationLoc].State = 2500;
                                    //    File.AppendAllText("D:\\CzltKJSerialPort.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 17-23 基站请求校时命令,IsStaFault=true ", Encoding.Unicode);
                                    //}
                                    //else
                                    //{
                                        _Stations[iStationLoc].State = 2300;
                                    //}
                                  
                                    break;

                                #endregion

                                #region [ 响应: 巡检命令 ]

                                case 20:    // 基站响应了巡检命令
                                    _Stations[iStationLoc].State = 2000;
                                    break;

                                #endregion

                                #region [ 响应: 信息确认 ]

                                case 21:    // 基站响应了信息确认命令
                                    _Stations[iStationLoc].State = 2100;
                                    //if (!_Stations[iStationLoc].IsPointSelect)
                                    //{
                                    //    iStationLoc++;
                                    //}
                                    break;

                                #endregion

                                #region [ 响应: 请求校时 ]

                                case 24:    // 基站请求校时命令
                                    _Stations[iStationLoc].State = 2400;
                                   // _Stations[iStationLoc].IsStaFault = true;
                                    break;

                                #endregion
                            }
                            break;
                        case 3:
                            switch (iCmdNO)
                            {
                                #region [ 响应: 查询版本 ]

                                case 22:    // 基站响应了查询版本
                                    _Stations[iStationLoc].State = 2200;

                                    // 生成固定的命令，发送时不需要每次生成
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:

                                            // 巡检命令
                                            _Stations[iStationLoc].CmdPolling = KJ128A.Protocol.P20071210.Polling(_Stations[iStationLoc].Address, Mark);

                                            // 信息确认命令
                                            _Stations[iStationLoc].CmdPollingRight = KJ128A.Protocol.P20071210.PollingRight(_Stations[iStationLoc].Address, Mark);

                                            // 重启命令
                                            _Stations[iStationLoc].CmdReset = KJ128A.Protocol.P20071210.Reset(_Stations[iStationLoc].Address, Mark, 0);

                                            break;
                                    }
                                    //if (!_Stations[iStationLoc].IsPointSelect)
                                    //{
                                    //    iStationLoc++;
                                    //}
                                    break;

                                #endregion

                                #region [ 响应: 校时命令 ]

                                case 23:    // 基站响应了校时命令
                                    _Stations[iStationLoc].State = 2300;
                                    //if (!_Stations[iStationLoc].IsPointSelect)
                                    //{
                                    //    iStationLoc++;
                                    //}
                                    break;

                                #endregion

                                #region [ 响应: 巡检命令 ]

                                case 20:    // 基站响应了巡检命令
                                    _Stations[iStationLoc].State = 2100;
                                    break;

                                #endregion

                                #region [ 响应: 请求校时 ]

                                case 24:    // 基站请求校时命令
                                    _Stations[iStationLoc].State = 2400;
                                    //_Stations[iStationLoc].IsStaFault = true;
                                    break;

                                #endregion
                                default:
                                    break;
                            }
                            break;
                        default:
                            // 响应命令
                            switch (iCmdNO)
                            {
                                #region [ 响应: 校时命令 ]

                                case 23:    // 基站响应了校时命令
                                    _Stations[iStationLoc].State = 2300;
                                    if (_Stations[iStationLoc].CmdPolling == null || _Stations[iStationLoc].CmdPolling.Length < 4)
                                    {
                                        // 巡检命令
                                        _Stations[iStationLoc].CmdPolling = KJ128A.Protocol.P20060610.sendScout(_Stations[iStationLoc].Address);
                                    }
                                    if (_Stations[iStationLoc].CmdPollingRight == null || _Stations[iStationLoc].CmdPollingRight.Length < 4)
                                    {
                                        // 信息确认命令
                                        _Stations[iStationLoc].CmdPollingRight = KJ128A.Protocol.P20060610.sendInfoAffirm(_Stations[iStationLoc].Address);
                                    }
                                    if (_Stations[iStationLoc].CmdReset == null || _Stations[iStationLoc].CmdReset.Length < 4)
                                    {
                                        // 重启命令
                                        _Stations[iStationLoc].CmdReset = KJ128A.Protocol.P20060610.Reset(_Stations[iStationLoc].Address);
                                    }
                                    break;

                                #endregion

                                #region [ 响应: 巡检命令 ]

                                case 20:    // 基站响应了巡检命令
                                    _Stations[iStationLoc].State = 2000;
                                    break;

                                #endregion

                                #region [ 响应: 信息确认 ]

                                case 21:    // 基站响应了信息确认命令
                                    _Stations[iStationLoc].State = 2100;
                                    break;

                                #endregion

                                #region [ 响应: 请求校时 ]

                                case 24:    // 基站请求校时命令
                                    _Stations[iStationLoc].State = 2400;
                                    break;

                                #endregion
                            }
                            break;
                    }

                }

                #region [ 更新基站状态 ]

                if (iOldState != 2200 && iOldState != 2300 && iOldState != 2000 && iOldState != 2100 && iOldState != 2400)
                {
                    StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                }
                else
                {
                    if (_Stations[iStationLoc].SaveCount <= 10)
                    {
                        _Stations[iStationLoc].SaveCount++;
                        StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                    }
                }

                //// 检测当前基站状态
                //if (iOldState == 0 || iOldState == 3000 || iOldState == 5000 &&
                //    (_Stations[iStationLoc].State != 0 && _Stations[iStationLoc].State != 3000 && _Stations[iStationLoc].State != 5000))
                //{
                //    StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                //}

                #endregion

                #region [基站号增加，巡检下一条记录]
                switch (iCmdNO)
                {
                    case 22:
                    case 23:
                    case 21:
                        if (!_Stations[iStationLoc].IsPointSelect)
                        {
                            iStationLoc++;
                        }
                        break;
                }
                #endregion

                // 释放有效命令
                cmdNewBytes = null;

                #endregion

                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                }

                // 发送下一条指令
                SendCmd();
            }
            catch
            {
                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                }
                #region [ 重置标志位 ]

                // 重置所有的标志位
                iStartLoc = -1;
                iEndLoc = -1;
                iEndStartLoc = -1;

                #endregion

                for (int i = 0; i < byteBuffer.Length; i++)
                {
                    byteBuffer[i] = (byte)0;
                }
                // 释放有效命令
                cmdNewBytes = null;
            }

        }

        #endregion

        #region [ 数据分析 ]

        /// <summary>
        /// 分析回送的数据
        /// </summary>
        /// <param name="cmdNewBytes">字节数组</param>
        /// <returns></returns>
        private void DataAnalyzing(byte[] cmdNewBytes)
        {
            if (cmdNewBytes == null)
            {
                return;
            }

            // 解析有效指令
            int iSAddress = cmdNewBytes[0];     // 基站号
            int iCmdNO = cmdNewBytes[1];        // 命令号

            switch (iCmdNO)
            {
                case 22:    // 查询版本

                    // 提取版本号
                    _Stations[iStationLoc].Ver = cmdNewBytes[6] + cmdNewBytes[7] * 256;

                    // 组织数据显示
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt("传输分站 [ " + iSAddress + " ] 的版本号: " + _Stations[iStationLoc].Ver, " RX", true, System.Drawing.Color.Black);
                    }

                    break;

                case 23:    // 校时

                    // 组织数据显示
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt("传输分站 [ " + iSAddress + " ] 校时. ", " RX", true, System.Drawing.Color.Black);
                    }

                    break;

                case 20:    // 巡检

                    AnalysisPolling_20071210_1(cmdNewBytes);

                    break;

                case 21:    // 数据确认

                    // 组织数据显示
                    //if (RTxtMsgc != null)
                    //{
                    //    RTxtMsgc.WriteTxt("基站 [ " + iSAddress + " ] 数据确认. ", " RX", true);
                    //}

                    break;
                case 33:    // 呼叫标识卡传输分站确认

                    // 组织数据显示
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt("传输分站 [ " + iSAddress + " ] 呼叫标识卡确认. ", " RX", true, System.Drawing.Color.Blue);
                    }

                    break;
            }

            // 传递给数据存储模块
            switch (iCmdNO)
            {
                case 20:    // 巡检
                case 22:    // 查询版本
                    DataReceived(cmdNewBytes, Mark, Group);
                    break;
            }

            return;
        }

        /// <summary>
        /// 分析回送的数据
        /// </summary>
        /// <param name="cmdNewBytes">字节数组</param>
        /// <returns></returns>
        private void DataAnalyzing20060610(byte[] cmdNewBytes)
        {
            if (cmdNewBytes == null)
            {
                return;
            }

            // 解析有效指令
            int iSAddress = cmdNewBytes[0];     // 基站号
            int iCmdNO = cmdNewBytes[1];        // 命令号

            switch (iCmdNO)
            {
                case 22:    // 查询版本

                    //// 提取版本号
                    //_Stations[iStationLoc].Ver = cmdNewBytes[6] + cmdNewBytes[7] * 256;

                    //// 组织数据显示
                    //if (RTxtMsgc != null)
                    //{
                    //    RTxtMsgc.WriteTxt("基站 [ " + iSAddress + " ] 的版本号: " + _Stations[iStationLoc].Ver, " RX", true);
                    //}

                    break;

                case 23:    // 校时

                    // 组织数据显示
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt("基站 [ " + iSAddress + " ] 校时. ", " RX", true, System.Drawing.Color.Black);
                    }

                    break;

                case 20:    // 巡检

                    AnalysisPolling_20060610_1(cmdNewBytes);

                    break;

                case 21:    // 数据确认

                    // 组织数据显示
                    //if (RTxtMsgc != null)
                    //{
                    //    RTxtMsgc.WriteTxt("基站 [ " + iSAddress + " ] 数据确认. ", " RX", true);
                    //}

                    break;
            }

            // 传递给数据存储模块
            switch (iCmdNO)
            {
                case 20:    // 巡检
                case 22:    // 查询版本
                    DataReceived(cmdNewBytes, Mark, Group);
                    break;
            }

            return;
        }

        #endregion

        #region [ 方法 ] 使用 2007-12-10 第 1 版协议解析数据

        /// <summary>
        /// 使用 2007-12-10 第 1 版协议解析数据
        /// </summary>
        private void AnalysisPolling_20071210_1(byte[] cmdRight)
        {
            int iCmdLength = cmdRight[3] + cmdRight[4] * 256; // 命令长度

            int iCmdLoc = 5;


            while (iCmdLoc < iCmdLength + 5)
            {
                #region [ 检测探头数据时间和状态 ]

                bool blnIsShutDown = false;             // 探头是否故障

                int iSHead = cmdRight[iCmdLoc];         // 探头号
                int iSecond = cmdRight[iCmdLoc + 4];    // 秒，其中最高位 1 时表示探头故障

                DateTime dtTime = DateTime.Now;

                int iPerCount = 0;
                int iPerLength = 0;
                if (iSecond >= 128)
                {
                    // 秒最高位为 1 时探头故障
                    iSecond = iSecond - 128;

                    if (cmdRight[iCmdLoc + 1] != 0)
                    {
                        // 接收到数据的时间
                        dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                            cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);
                    }
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt(dtTime + " [ " + cmdRight[0] + " ] 号传输分站 [ " + cmdRight[iCmdLoc] + " ] 号读卡分站 [ 未登录 ]", " RX", true, System.Drawing.Color.Black);
                    }
                    blnIsShutDown = true;
                }
                else
                {
                    if (cmdRight[iCmdLoc + 1] != 0)
                    {
                        dtTime = BuildDateTime(cmdRight[iCmdLoc + 1],
                            cmdRight[iCmdLoc + 2], cmdRight[iCmdLoc + 3], iSecond);
                    }

                    iPerCount = cmdRight[iCmdLoc + 5];              // 人数
                    iPerLength = cmdRight[iCmdLoc + 5] * 2;         // 长度

                    //if (Base.KJ_bln_IsUseDataBase)
                    //{
                    //    // 更新基站状态，置探头状态为正常
                    //    QueriesTableAdapter qtAdapter = new QueriesTableAdapter();
                    //    qtAdapter.Wwy_Station_StateChange(iStation, iSHead, 2000, DateTime.Now);
                    //}
                }

                // 保证数据完整
                //if (cmdRight.Length < iCmdLoc + 6 + iPerLength - 1)
                //{
                //    return;
                //}

                #endregion

                #region [ 探头接收到的卡号 ]

                StringBuilder sbHeadA = new StringBuilder();    // 探头 A 接收到的发码器
                StringBuilder sbHeadB = new StringBuilder();    // 探头 B 接收到的发码器
                StringBuilder sbHeadC = new StringBuilder();    // 探头 接收到全为 0 的发码器
                StringBuilder sbHeadD = new StringBuilder();    // 探头 接收到全为 1 的发码器   求救
                StringBuilder sbHeadE = new StringBuilder();    // 低电量   探头 A 接收到的发码器
                StringBuilder sbHeadF = new StringBuilder();    // 低电量   探头 B 接收到的发码器
                StringBuilder sbHeadG = new StringBuilder();    // 低电量   探头 接收到全为 0 的发码器   出
                StringBuilder sbHeadH = new StringBuilder();    // 低电量   探头 接收到全为 1 的发码器   求救

                int i;
                for (i = iCmdLoc + 6; i < iCmdLoc + 6 + iPerLength; i += 2)
                {
                    int iCard = cmdRight[i] + cmdRight[i + 1] * 256;

                    if (iCard > 49152)//求救
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
                    else if (iCard >= 32768)//A天线
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
                    else if (iCard >= 16384)//B天线
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
                    else//出
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

                if (blnIsShutDown)
                {
                    iCmdLoc = i - 1;
                }
                else
                {
                    iCmdLoc = i;
                }

                // 构造要显示的内容
                StringBuilder strMsg = new StringBuilder();
                strMsg.Append(dtTime + " [ " + cmdRight[0] + " ] 号传输分站 [ " + iSHead + " ] 号读卡分站 共检测到: " + iPerCount + " 张标识卡");
                if (sbHeadA.Length > 0) strMsg.Append("\n\t\t[进]: " + sbHeadA);
                if (sbHeadB.Length > 0) strMsg.Append("\n\t\t[进]: " + sbHeadB);
                if (sbHeadC.Length > 0) strMsg.Append("\n\t\t[出]: " + sbHeadC);
                if (sbHeadD.Length > 0) strMsg.Append("\n\t\t[求救]: " + sbHeadD);
                if (sbHeadE.Length > 0) strMsg.Append("\n\t\t[低][进]:" + sbHeadE);
                if (sbHeadF.Length > 0) strMsg.Append("\n\t\t[低][进]:" + sbHeadF);
                if (sbHeadG.Length > 0) strMsg.Append("\n\t\t[低][出]:" + sbHeadG);
                if (sbHeadH.Length > 0) strMsg.Append("\n\t\t[低][求救]:" + sbHeadH);
                strMsg.Append("\n");

                // 显示探头出检测出多少张卡
                if (iPerCount > 0)
                {
                    if (RTxtMsgc != null)
                    {
                        RTxtMsgc.WriteTxt(strMsg.ToString(), " RX", true, System.Drawing.Color.Black);
                    }
                }

                #endregion

                #region [ 检测标记位是否存在 ]

                if (cmdRight[iCmdLoc++] != 255)
                {
                    break;
                }

                #endregion
            }
        }

        #endregion

        #region [ 方法 ] 使用 2006-6-10 第 1 版协议解析数据

        /// <summary>
        /// 使用 2006-6-10 第 1 版协议解析数据
        /// </summary>
        private void AnalysisPolling_20060610_1(byte[] cmdRight)
        {
            // 命令长度
            int iCmdLength = cmdRight[2] + cmdRight[3] * 256;
            // 人数
            int iPerCount = cmdRight[4] + cmdRight[5] * 256;
            //获取数据的时间
            DateTime dtTime = BuildDateTime(cmdRight[6], cmdRight[7], cmdRight[8]);

            int iPerCount1 = 0;
            iPerCount1 = iPerCount;

            #region [ 分站接收到的卡号 ]
            StringBuilder sbHeadA = new StringBuilder();    // 分站 接收到最高位为 1 的发码器
            StringBuilder sbHeadB = new StringBuilder();    // 分站 接收到第二位为 1 的发码器
            StringBuilder sbHeadC = new StringBuilder();    // 分站 第一位和第二位为0 的发码器
            StringBuilder sbHeadD = new StringBuilder();    // 低电量
            StringBuilder sbHeadE = new StringBuilder();    // 分站 接收到最高位和第二位全为 1 的发码器   即求救
            for (int i = 0; i < iPerCount; i++)
            {
                int iCard;//人员卡号
                //得到临时卡号和状态
                iCard = (int)cmdRight[9 + 2 * i] + (int)cmdRight[10 + 2 * i] * 256;
                if (iCard != 29998 && iCard != 62766 && iCard != 29999)
                {
                    if (iCard > 49152)
                    {
                        iCard = iCard - 49152;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadD.Append(iCard + ",");
                        }
                        sbHeadE.Append(iCard + ",");
                    }
                    else if (iCard >= 32768)
                    {
                        iCard = iCard - 32768;
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadD.Append(iCard + ",");
                        }
                        sbHeadA.Append(iCard + ",");
                    }
                    else if (iCard >= 16384)
                    {
                        //iCard = iCard - 16384;
                        //if (iCard > 8192)
                        //{
                        //    iCard = iCard - 8192;
                        //    sbHeadD.Append(iCard + ",");
                        //}
                        //sbHeadB.Append(iCard + ",");
                    }
                    else
                    {
                        if (iCard > 8192)
                        {
                            iCard = iCard - 8192;
                            sbHeadD.Append(iCard + ",");
                        }
                        sbHeadC.Append(iCard + ",");
                    }
                }
                else
                {
                    iPerCount1--;
                }
            }

            // 构造要显示的内容
            StringBuilder strMsg = new StringBuilder();
            strMsg.Append(dtTime + " [ " + cmdRight[0] + " ] 号基站  共检测到: " + iPerCount1 + " 张卡");
            if (sbHeadA.Length > 0) strMsg.Append("\n\t\t[出]: " + sbHeadA);
            if (sbHeadC.Length > 0) strMsg.Append("\n\t\t[进]: " + sbHeadC);
            if (sbHeadD.Length > 0) strMsg.Append("\n\t\t[低]: " + sbHeadD);
            if (sbHeadE.Length > 0) strMsg.Append("\n\t\t[求救]" + sbHeadE);
            strMsg.Append("\n");

            // 显示探头出检测出多少张卡
            if (iPerCount > 0)
            {
                if (RTxtMsgc != null)
                {
                    RTxtMsgc.WriteTxt(strMsg.ToString(), " RX", true, System.Drawing.Color.Black);
                }
            }

            #endregion
        }

        #endregion

        #region BuildDateTime 根据接收到的时间，构造新的时间

        /// <summary>
        /// 构造时间
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
                // 时间不合法，则返回系统最小时间
                if (Day >= 32 || Hour >= 24 || Minute >= 60 || Second >= 60)
                {
                    return new DateTime(2000, 1, 1, 0, 0, 1);
                }

                int int_Year = dtTime.Year;
                int int_Month = dtTime.Month;

                // 当前月末
                if (dtTime.Day == DateTime.DaysInMonth(int_Year, int_Month))
                {
                    // 上传数据为月初
                    if (Day == 1)
                    {
                        int_Month++;
                    }
                }
                else
                {
                    // 当前月初
                    if (dtTime.Day == 1)
                    {
                        // 上传数据为月末
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
                        // 非月初月末
                        if (Day > dtTime.Day + 1)
                        {
                            int_Month--;
                        }
                    }
                }

                // 构造新的时间
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
        /// 构造时间
        /// </summary>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        /// <returns></returns>
        public static DateTime BuildDateTime(int Hour, int Minute, int Second)
        {
            //当前系统的时、分、秒
            DateTime dtTime = DateTime.Now;

            try
            {
                // 时间不合法，则返回系统最小时间
                if (Hour >= 24 || Minute >= 60 || Second >= 60)
                {
                    return new DateTime(2000, 1, 1, 0, 0, 1);
                }

                //接收到数据的时、分、秒
                int int_Year = dtTime.Year;
                int int_Month = dtTime.Month;
                int int_Day = DateTime.Now.Day;
                DateTime dtTimeGet = new DateTime(int_Year, int_Month, int_Day, Hour, Minute, Second);

                if (dtTime >= dtTimeGet.AddMinutes(-5)) //当前时间大于发送数据的时间
                {
                    return dtTimeGet;
                }
                else //减一天
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

        #region [ 事件: 定时发送命令 ]

        /// <summary>
        /// 定时发送命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timer.Stop();
                if (_isDatabaseConnect == true && m_RbSend == true)//数据库连接
                {
                    if (_isSaveSql == false)//数据库是否正在保存,如果不在则发送
                    {
                        //sqlSend = 0;
                        base.timer_Elapsed(sender, e);

                        if (IsPause)
                        {
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }

                            return;
                        }

                        // 如果基站不存在，则退出
                        if (_Stations == null || _Stations.Length <= 0)
                        {
                            iStationLoc = 0;
                            if (_isStationChange == true)
                            {
                                _Stations = _TempStations;
                                _isStationChange = false;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        // 如果超过基站数，从头开始巡检
                        if (iStationLoc >= _Stations.Length)
                        {
                            iStationLoc = 0;
                            if (_isStationChange == true)
                            {
                                _Stations = _TempStations;
                                _isStationChange = false;
                            }
                        }

                        // 如果基站不存在，则退出
                        if (_Stations == null || _Stations.Length <= 0)
                        {
                            iStationLoc = 0;
                            if (_isStationChange == true)
                            {
                                _Stations = _TempStations;
                                _isStationChange = false;
                            }
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                            return;
                        }

                        //启动热备
                        if (_IsStartHostBacker)
                        {
                            //是备机
                            if (!_IsHost)
                            {
                                backerSendCount++;
                                if (backerSendCount < 30)
                                {
                                    if (timer.Enabled == false)
                                    {
                                        timer.Enabled = true;
                                    }
                                    return;
                                }
                                backerSendCount = 30;
                            }
                        }

                        // 如果故障次数超过 61000，则将故障减掉 60000
                        if (_Stations[iStationLoc].NoAnswer > 61000)
                        {
                            _Stations[iStationLoc].NoAnswer -= 60000;
                        }
                        else
                        {
                            _Stations[iStationLoc].NoAnswer++;
                        }

                        //Czlt-2012-3-28 添加热备通讯状态的修改  0:未初始化,3000:初始化,-10000:热备通讯
                        if (_Stations[iStationLoc].State == 0 || _Stations[iStationLoc].State == 3000 || _Stations[iStationLoc].State == -10000)
                        {
                            // 基站未初始化时，三次无响应置离线，五次无响应置故障
                            if (_Stations[iStationLoc].NoAnswer == 3)
                            {
                                _Stations[iStationLoc].State = 3000;
                                _Stations[iStationLoc].SaveCount = 0;
                                StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                            }

                            if (_Stations[iStationLoc].NoAnswer == 5)
                            {
                                _Stations[iStationLoc].State = 5000;
                                _Stations[iStationLoc].SaveCount = 0;
                                StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                            }
                        }
                        else
                        {
                            // 如果程序运行中出现三次无响应，则置基站故障
                            if (_Stations[iStationLoc].NoAnswer == 3 && _Stations[iStationLoc].State != -10000)
                            {
                                _Stations[iStationLoc].State = 5000;
                                _Stations[iStationLoc].SaveCount = 0;
                                StationStateChanged(Index, _Stations[iStationLoc].Address, _Stations[iStationLoc].State, _Stations[iStationLoc].CState);
                            }
                        }

                        iStartLoc = -1;
                        iEndLoc = -1;
                        iEndStartLoc = -1;

                        // 发送下一条指令
                        if (!_Stations[iStationLoc].IsPointSelect)
                        {
                            iStationLoc++;
                        }
                        SendCmd();
                    }
                    else
                    {
                        //sqlSend++;
                        //if (sqlSend>1)
                        //{
                        //    _isSaveSql = false;
                        //}
                        timer.Enabled = true;
                    }
                }
                else//数据库未连接
                {
                    timer.Enabled = true;
                }
            }
            catch { }
            finally
            {
                if (timer.Enabled == false)
                {
                    timer.Start();
                }
            }
        }

        #endregion
    }
}
