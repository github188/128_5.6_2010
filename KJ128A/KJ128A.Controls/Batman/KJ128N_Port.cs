using System;
using System.Collections.Generic;
using System.Text;
using KJ128A.Protocol;
using KJ128A.BatmanAPI;
using System.Data;
using System.IO;


namespace KJ128A.Controls.Batman
{
    /// <summary>
    /// KJ128N 所需要的串口类二次封装
    /// </summary>
    public class KJ128N_Port: Base_SerialPort
    {

        #region 【Czlt-2010-11-29 双向通讯】

        #region 【属性】
        GetCardInfo getCardInfo = new GetCardInfo();
        /// <summary>
        /// 是否继续双通讯
        /// </summary>
        private bool iScloseCall = true;
        #endregion

        #region 【属性】 双向通信状态
        /// <summary>
        /// 双向通信状态
        /// </summary>
        private bool _IsTwoMessage;

        /// <summary>
        /// 双向通信状态
        /// </summary>
        public bool IsTwoMessage
        {
            get { return _IsTwoMessage; }
            set
            {
                _IsTwoMessage = value;
                timer_Call.Enabled = value;
            }
        }

        #endregion


        #region 【属性】 要呼叫的标识卡
        /// <summary>
        /// 要呼叫的标识卡（根据实时进状态）
        /// </summary>
        public int[] CardToCall;


        #endregion

        #region 【属性】 双向通讯广播信息
        /// <summary>
        /// 双向通讯广播信息（0-传输分站，1-读卡分站，2-标识卡号）
        /// </summary>
        public int[] CallOrder;

        /// <summary>
        /// Czlt-2012-04-21 出分站的标识卡
        /// </summary>
        public string strOutCard;

        #endregion

        /// <summary>
        /// 双向通讯命令集
        /// </summary>
        protected byte[][] CallOrders;


        /// <summary>
        /// 标识卡所在分站
        /// </summary>
        private DataTable dtStn;

        #endregion

        #region [ 属性 ] 标准数据面板

        private KJRichTextBox _RTxtMsg = null;

        /// <summary>
        /// 标准数据面板
        /// </summary>
        public KJRichTextBox RTxtMsg
        {
            get { return _RTxtMsg; }
            set { _RTxtMsg = value; }
        }

        #endregion

        #region [ 属性 ] 错误数据面板

        private KJRichTextBox _RTxtMsge = null;

        /// <summary>
        /// 错误数据面板
        /// </summary>
        public KJRichTextBox RTxtMsge
        {
            get { return _RTxtMsge; }
            set { _RTxtMsge = value; }
        }

        #endregion

        #region [ 属性 ] 中文数据面板

        private KJRichTextBox _RTxtMsgc = null;

        /// <summary>
        /// 中文数据面板
        /// </summary>
        public KJRichTextBox RTxtMsgc
        {
            get { return _RTxtMsgc; }
            set { _RTxtMsgc = value; }
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

        #region [ 属性 ] 命令号

        private int _CmdNO;

        /// <summary>
        /// 获取或设置发送的命令号
        /// </summary>
        public int CmdNO
        {
            get { return _CmdNO; }
            set { _CmdNO = value; }
        }

        #endregion

        #region [ 属性 ] 待巡检的基站序列

        /// <summary>
        /// 待巡检的基站序列
        /// </summary>
        protected MemStation[] _Stations;

        /// <summary>
        /// 待巡检的基站序列
        /// </summary>
        public MemStation[] Stations
        {
            get { return _Stations; }
            set { _Stations = value; }
        }

        protected MemStation[] _TempStations;

        /// <summary>
        /// 临时巡检基站序列
        /// </summary>
        public MemStation[] TempStations
        {
            get { return _TempStations; }
            set { _TempStations = value; }
        }
        #endregion

        #region [属性] 分站数据是否改变
        protected bool _isStationChange;
        /// <summary>
        /// 是否分站数据已经改变
        /// </summary>
        public bool IsStationChange
        {
            get { return _isStationChange; }
            set { _isStationChange = value; }
        }
        #endregion

        #region [属性：接收到的数据分析的效验位]
        protected byte[] _crcByte = new byte[1];
        #endregion

        #region [ 属性 ] 暂停收发

        private bool _IsPause;

        /// <summary>
        /// 暂停收发
        /// </summary>
        public bool IsPause
        {
            get { return _IsPause; }
            set
            {
                _IsPause = value;
                if (_IsPause)
                {
                    timer.Enabled = false;
                }
                else
                {
                    timer.Enabled = true;
                }
            }
        }

        #endregion

        #region [ 方法 ] 发送命令

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="iStationLoc"></param>
        protected void SendCmd(ref int iStationLoc)
        {
            if (timer.Enabled == false)
            {
                timer.Enabled = true;
            }
            // 是否暂停发送
            if (IsPause)
            {
                return;
            }

            #region 【Czlt-2010-11-29 双向通讯】
            if (!iScloseCall)
            {
                iScloseCall = true;
                timer_Call.Enabled = false;
                _IsTwoMessage = false;
                CallOrder = null;
                CallOrders = null;
                CardToCall = null;
                dtStn = null;
            }

            #endregion

            if (_Stations == null || _Stations.Length <= 0)
            {
                iStationLoc = 0;
                if (_isStationChange == true)
                {
                    _Stations = _TempStations;
                    _isStationChange = false;
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
                return;
            }
            //else
            //{
            //    timer.Enabled = false;
            //}
            iCurLoc = 0;
            for (int i = 0; i < byteBuffer.Length; i++)
			{
                byteBuffer[i] = 0;
			}

            // 重置所有的标志位
            iStartLoc = -1;
            iEndLoc = -1;
            iEndStartLoc = -1;

            byte[] cmdBytes = null;
            switch (_Stations[iStationLoc].StationModel)
            {
                case 1:
                case 3:
                    #region [KJ128A发送指令]
                    //// 根据基站状态，生成待发指令
                    //if (_Stations[iStationLoc].IsTwo == true)
                    //{
                    //    //switch (_Stations[iStationLoc].Ver)
                    //    //{
                    //    //    case 256:
                    //    cmdBytes = _Stations[iStationLoc].CmdTwo;
                    //    _Stations[iStationLoc].SCmd = 19;
                    //    CmdNO = 19;
                    //    _Stations[iStationLoc].IsTwo = false;
                    //    //        break;
                    //    //}
                    //}
                    //if (iStationLoc == 0 && _IsTwoMessage == true)
                    if ( _IsTwoMessage == true)
                    {
                        ///Czlt-2012-04-22 不在呼叫区域的卡
                        if (strOutCard != null && !strOutCard.Trim().Equals(""))
                        {
                            RTxtMsgc.WriteTxt(strOutCard + " 号标识卡不在呼叫区域内！", " RX", true, System.Drawing.Color.Red);
                            strOutCard = string.Empty;
                        }
                        #region[存在呼叫命令标志时]

                        if (CallOrder != null && CallOrder.Length == 3)
                        {
                            cmdBytes = KJ128A.Protocol.P20071210.TwoMessage(CallOrder[0], CallOrder[1], CallOrder[2], Mark);
                            //Czlt-2011-11-22 添加确认提示标志
                            if (RTxtMsgc != null)
                            {
                                RTxtMsgc.WriteTxt(CallOrder[0] + "号传输 " + CallOrder[1] + "号读卡分站 对" + CallOrder[2] + " 号标识卡启动呼叫！", " RX", true, System.Drawing.Color.Blue);
                            }

                            CallOrders = null;
                            CardToCall = null;
                            _IsTwoMessage = false;
                        }
                        else if (CardToCall != null)
                        {
                            if (CallOrders == null)
                            {
                                CallOrder = null;
                                string strCard = SetCardToStr(CardToCall);
                                dtStn = getCardInfo.GetRTStnHead(strCard);
                                int iCount = dtStn.Rows.Count;
                                if (iCount > 0)
                                {
                                    byte[][] tmp = new byte[iCount][];
                                    for (int i = 0; i < iCount; i++)
                                    {
                                        int iStn = Convert.ToInt32(dtStn.Rows[i]["StationAddress"].ToString());
                                        int iStnHead = Convert.ToInt32(dtStn.Rows[i]["StationHeadAddress"].ToString()); ;
                                        int iCard = Convert.ToInt32(dtStn.Rows[i]["CodeSenderAddress"].ToString()); ;
                                        tmp[i] = KJ128A.Protocol.P20071210.TwoMessage(iStn, iStnHead, iCard, Mark);
                                    }

                                    CallOrders = tmp;

                                    if (iCount >= CardToCall.Length)
                                    {
                                        CardToCall = null;
                                    }
                                    else
                                    {
                                        for (int j = 0; j < CardToCall.Length; j++)
                                        {
                                            for (int s = 0; s < iCount; s++)
                                            {
                                                if (CardToCall[j] == Convert.ToInt32(dtStn.Rows[s]["CodeSenderAddress"].ToString()))
                                                {
                                                    CardToCall[j] = 0;
                                                    break;
                                                }
                                            }
                                        }
                                        int[] iTempCard = new int[CardToCall.Length - iCount];

                                        int iIdex = 0;
                                        for (int x = 0; x < CardToCall.Length; x++)
                                        {
                                            if (CardToCall[x] != 0)
                                            {
                                                iTempCard[iIdex] = CardToCall[x];
                                                iIdex++;
                                            }
                                        }
                                        CardToCall = iTempCard;//状态不为出的标识卡
                                    }

                                }
                                int iRowcount = -1;
                                if (CallOrders != null)
                                {
                                    iRowcount = CallOrders.GetLength(0);
                                    cmdBytes = CallOrders[0];
                                    if (iRowcount > 1)
                                    {
                                        byte[][] tmpOrder = new byte[iRowcount - 1][];
                                        for (int i = 0; i < iRowcount - 1; i++)
                                        {
                                            tmpOrder[i] = CallOrders[i + 1];
                                        }

                                        CallOrders = tmpOrder;

                                    }
                                    else
                                    {
                                        CallOrders = null;
                                        if (CardToCall == null)
                                        {
                                            _IsTwoMessage = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int iRowcount = -1;
                                if (CallOrders != null)
                                {
                                    iRowcount = CallOrders.GetLength(0);
                                    cmdBytes = CallOrders[0];
                                    if (iRowcount > 1)
                                    {
                                        byte[][] tmpOrder = new byte[iRowcount - 1][];
                                        for (int i = 0; i < iRowcount - 1; i++)
                                        {
                                            tmpOrder[i] = CallOrders[i + 1];
                                        }

                                        CallOrders = tmpOrder;

                                    }
                                    else
                                    {
                                        CallOrders = null;
                                        if (CardToCall == null)
                                        {
                                            _IsTwoMessage = false;
                                        }
                                    }
                                }
                            }


                        }
                        else if (CallOrders != null)
                        {
                            int iRowcount = -1;
                            if (CallOrders != null)
                            {
                                iRowcount = CallOrders.GetLength(0);
                                cmdBytes = CallOrders[0];
                                if (iRowcount > 1)
                                {
                                    byte[][] tmpOrder = new byte[iRowcount - 1][];
                                    for (int i = 0; i < iRowcount - 1; i++)
                                    {
                                        tmpOrder[i] = CallOrders[i + 1];
                                    }

                                    CallOrders = tmpOrder;

                                }
                                else
                                {
                                    CallOrders = null;
                                    if (CardToCall == null)
                                    {
                                        _IsTwoMessage = false;
                                    }
                                }
                            }
                        }

                        #region[如果没有生成呼叫命令该位置的分站生成相应的正常轮询命令]
                        if (cmdBytes == null)
                        {
                            switch (_Stations[iStationLoc].State)
                            {
                                case -10000:    // 热备
                                case 5000:      // 基站故障
                                case 3000:      // 基站未登录
                                case 2400:      // 响应基站请求校时命令
                                case 1900:      //双向命令
                                case 0:         // 未初始化，执行查询版本命令
                                    cmdBytes = _Stations[iStationLoc].CmdVersion;
                                    _Stations[iStationLoc].SCmd = 22;
                                    CmdNO = 22;
                                    break;

                                case 2200:  // 查询版本结束后，执行校时命令
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:   // N 版 V1.0
                                            _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                            cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                            _Stations[iStationLoc].SCmd = 23;
                                            CmdNO = 23;
                                            break;
                                    }
                                    break;

                                case 2300:  // 校时命令结束后，执行巡检命令
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:
                                            cmdBytes = _Stations[iStationLoc].CmdPolling;
                                            _Stations[iStationLoc].SCmd = 20;
                                            CmdNO = 20;
                                            break;
                                    }
                                    break;

                                case 2000:  // 巡检命令结束后，执行信息确认命令
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:
                                            cmdBytes = _Stations[iStationLoc].CmdPollingRight;
                                            _Stations[iStationLoc].SCmd = 21;
                                            CmdNO = 21;
                                            break;
                                    }
                                    break;

                                case 2100:  // 信息确认命令结束后，发送巡检命令
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:
                                            if (_Stations[iStationLoc].TimeCheckOut.AddMinutes(30) <= DateTime.Now)
                                            {
                                                _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                                cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                                _Stations[iStationLoc].SCmd = 23;
                                                CmdNO = 23;
                                            }
                                            else
                                            {
                                                cmdBytes = _Stations[iStationLoc].CmdPolling;
                                                _Stations[iStationLoc].SCmd = 20;
                                                CmdNO = 20;
                                            }
                                            break;
                                    }
                                    break;                               

                                case -1000: // 休眠
                                    iStationLoc++;
                                    SendCmd(ref iStationLoc);
                                    return;

                                case 2500:  // 重启
                                    switch (_Stations[iStationLoc].Ver)
                                    {
                                        case 256:
                                            cmdBytes = _Stations[iStationLoc].CmdReset;
                                            _Stations[iStationLoc].SCmd = 25;
                                            CmdNO = 25;
                                            break;
                                    }
                                    break;
                            }
                        }
                        #endregion

                        #endregion
                    }
                    else
                    {
                        #region 【无双向通讯标识卡的时候】
                        ///Czlt-2012-04-22 不在呼叫区域的卡
                        if (strOutCard != null && !strOutCard.Trim().Equals(""))
                        {
                            RTxtMsgc.WriteTxt(strOutCard + " 号标识卡不在呼叫区域内！", " RX", true, System.Drawing.Color.Red);
                            strOutCard = string.Empty;
                        }
                        switch (_Stations[iStationLoc].State)
                        {
                            case -10000:    // 热备
                            case 5000:      // 基站故障
                            case 3000:      // 基站未登录
                            //case 2400:      // 响应基站请求校时命令
                            case 1900:      //双向命令
                            case 0:         // 未初始化，执行查询版本命令
                                cmdBytes = _Stations[iStationLoc].CmdVersion;
                                _Stations[iStationLoc].SCmd = 22;
                                CmdNO = 22;
                                break;

                            case 2200:  // 查询版本结束后，执行校时命令
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:   // N 版 V1.0
                                        ////Czlt-2011-12-21 假如分站故障直接发送请求数据的命令
                                        //if (_Stations[iStationLoc].IsStaFault)
                                        //{
                                        //    File.AppendAllText("D:\\CzltKJ128N_Port.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 16-22  假如分站故障直接发送请求数据的命令 22 ", Encoding.Unicode);
                                        //    cmdBytes = _Stations[iStationLoc].CmdPolling;
                                        //    _Stations[iStationLoc].SCmd = 20;
                                        //    CmdNO = 20;

                                        //    //Czlt-2011-12-20 设置故障标识位
                                        //    _Stations[iStationLoc].IsStaFault = false;
 
                                        //}
                                        //else
                                        //{
                                            _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                            cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                            _Stations[iStationLoc].SCmd = 23;
                                            CmdNO = 23;
                                        //}
                                        break;
                                }
                                break;

                            case 2300:  // 校时命令结束后，执行巡检命令
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:
                                        cmdBytes = _Stations[iStationLoc].CmdPolling;
                                        _Stations[iStationLoc].SCmd = 20;
                                        CmdNO = 20;
                                        break;
                                }
                                break;

                            case 2000:  // 巡检命令结束后，执行信息确认命令
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:
                                        cmdBytes = _Stations[iStationLoc].CmdPollingRight;
                                        _Stations[iStationLoc].SCmd = 21;
                                        CmdNO = 21;
                                        break;
                                }
                                break;

                            case 2100:  // 信息确认命令结束后，发送巡检命令
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:
                                        if (_Stations[iStationLoc].TimeCheckOut.AddMinutes(30) <= DateTime.Now || _Stations[iStationLoc].TimeCheckOut.AddMinutes(-30)>DateTime.Now)
                                        {
                                            _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                            cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                            _Stations[iStationLoc].SCmd = 23;
                                            CmdNO = 23;
                                        }
                                        else
                                        {
                                            cmdBytes = _Stations[iStationLoc].CmdPolling;
                                            _Stations[iStationLoc].SCmd = 20;
                                            CmdNO = 20;
                                        }
                                        break;
                                }
                                break;
                            case 2400:      // 响应基站请求校时命令
                                ////Czlt-2011-12-20 假如分站发送上来对时命令，就直接给其对时
                                //if (_Stations[iStationLoc].IsStaFault)
                                //{
                                //    File.AppendAllText("D:\\CzltKJ128N_Port.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 17-23 响应基站请求校时命令，发送对时命令 23 ", Encoding.Unicode);
                                //    _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                //    cmdBytes = KJ128A.Protocol.P20071210.SyncDate(_Stations[iStationLoc].Address, Mark);
                                //    _Stations[iStationLoc].SCmd = 23;
                                //    CmdNO = 23;
                                //}
                                break;
                            case -1000: // 休眠
                                iStationLoc++;
                                SendCmd(ref iStationLoc);
                                return;

                            case 2500:  // 重启
                                switch (_Stations[iStationLoc].Ver)
                                {
                                    case 256:
                                        //Czlt-2011-12-10 给重启标识位赋值
                                        //_Stations[iStationLoc].IsStaFault = false;
                                        cmdBytes = _Stations[iStationLoc].CmdReset;
                                        _Stations[iStationLoc].SCmd = 25;
                                        CmdNO = 25;
                                        break;
                                }
                                break;
                        }
                        #endregion
                    }
                    #endregion
                    break;
                default:
                    #region [KJ128V2发送指令]
                    switch (_Stations[iStationLoc].State)
                    {
                        case -10000:    // 热备
                        case 5000:      // 基站故障
                        case 3000:      // 基站未登录
                        case 2400:      // 响应基站请求校时命令
                        case 1900:      // 双向命令
                        case 0:         // 未初始化，执行查询版本命令
                            _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                            cmdBytes = KJ128A.Protocol.P20060610.sendTime(_Stations[iStationLoc].Address);
                            _Stations[iStationLoc].SCmd = 23;
                            CmdNO = 23;
                            break;

                        case 2300:  // 校时命令结束后，执行巡检命令
                            cmdBytes = _Stations[iStationLoc].CmdPolling;
                            _Stations[iStationLoc].SCmd = 20;
                            CmdNO = 20;
                            break;

                        case 2000:  // 巡检命令结束后，执行信息确认命令
                            cmdBytes = _Stations[iStationLoc].CmdPollingRight;
                            _Stations[iStationLoc].SCmd = 21;
                            CmdNO = 21;
                            break;

                        case 2100:  // 信息确认命令结束后，发送巡检命令
                            if (_Stations[iStationLoc].TimeCheckOut.AddMinutes(30) <= DateTime.Now || _Stations[iStationLoc].TimeCheckOut.AddMinutes(-30) > DateTime.Now)
                            {
                                _Stations[iStationLoc].TimeCheckOut = DateTime.Now;
                                cmdBytes = KJ128A.Protocol.P20060610.sendTime(_Stations[iStationLoc].Address);
                                _Stations[iStationLoc].SCmd = 23;
                                CmdNO = 23;
                            }
                            else
                            {
                                cmdBytes = _Stations[iStationLoc].CmdPolling;
                                _Stations[iStationLoc].SCmd = 20;
                                CmdNO = 20;
                            }
                            break;
                        case -1000: // 休眠
                            iStationLoc++;
                            SendCmd(ref iStationLoc);
                            return;

                        case 2500:  // 重启
                            cmdBytes = _Stations[iStationLoc].CmdReset;
                            _Stations[iStationLoc].SCmd = 25;
                            CmdNO = 25;
                            break;
                    }
                    #endregion
                    break;
            }
            if (cmdBytes != null)
            {
                if (RTxtMsg != null)
                {
                    //Czlt-2012-04-20 注销
                   // RTxtMsg.WriteTxt(cmdBytes, " TX", true, 6);


                    //Czlt-2012-04-20 通讯前面添加了00
                    RTxtMsg.WriteTxt(cmdBytes, " TX", true, 7);
                }
                Write(cmdBytes);

                // 如果基站状态是重启的话，接着往下巡检
                if (_Stations[iStationLoc].State == 2500)
                {
                    _Stations[iStationLoc].State = 0;

                    iStationLoc++;
                    SendCmd(ref iStationLoc);
                }
            }

        }

        #endregion

        #region [ 方法 ] 数据抵达

        /// <summary>
        /// 开始标志
        /// </summary>
        protected int iStartLoc = -1;     // 开始标志

        /// <summary>
        /// 结束标志
        /// </summary>
        protected int iEndLoc = -1;       // 结束标志

        /// <summary>
        /// 找到结束位的开始标记
        /// </summary>
        protected int iEndStartLoc = -1;  // 找结束位的开始标记

        /// <summary>
        /// 新的命令
        /// </summary>
        protected byte[] cmdNewBytes = null;

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
                #region [ 缓冲区溢出 ]

                // 如果不存在数据
                if (iCurLoc == 0)
                {
                    iStartLoc = -1;
                    iEndLoc = -1;
                    iEndStartLoc = -1;
                    if (timer.Enabled == false)
                    {
                        timer.Enabled = true;
                    }
                    return;
                }

                #endregion

                #region [ 寻找开始标记 ]

                // 寻找开始标记
                int i238;
                if (iStartLoc == -1)
                {
                    i238 = 0;
                    for (int i = 0; i < iCurLoc; i++)
                    {
                        if (byteBuffer[i] == 238)
                        {
                            i238++;
                        }
                        else
                        {
                            i238 = 0;
                        }

                        if (i238 >= 5)
                        {
                            iStartLoc = i - 5;
                            iEndStartLoc = i + 1;
                            break;
                        }
                    }
                }

                if (iEndStartLoc == -1) return;

                #endregion

                #region [获取分站信息]
                //分站地址号
                int address = (int)byteBuffer[iStartLoc + 6];
                MemStation mStation = new MemStation();
                if (address != 0)
                {
                    mStation = GetStation(address);
                }
                if (mStation.Address == 0)
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
                #endregion

                int iCmdNewLength = 0;

                switch (mStation.StationModel)
                {
                    case 1://KJ128A
                    case 3:
                        #region [ 寻找结束标记 ]

                        // 寻找结束标记
                        int i254;
                        if (iEndLoc == -1)
                        {
                            i254 = 0;
                            int iTmp = 0;
                            for (iTmp = iEndStartLoc; iTmp < iCurLoc; iTmp++)
                            {
                                if (byteBuffer[iTmp] == 254)
                                {
                                    i254++;
                                }
                                else
                                {
                                    i254 = 0;
                                }

                                if (i254 >= 3)
                                {
                                    iEndLoc = iTmp;
                                    break;
                                }
                            }

                            // 记录下一次开始寻找结束标志的位置
                            if (iEndLoc == -1)
                            {
                                iEndStartLoc = iTmp - 2;
                                return;
                            }
                        }

                        // Error: 写日志
                        if (iEndStartLoc == -1) return;

                        #endregion

                        #region [ 检索重复开始标志 ]

                        // 检索开始标志后，结束标志前，是否还有第二个开始标志
                        i238 = 0;
                        for (int i = iEndLoc - 2; i > iStartLoc + 4; i--)
                        {
                            if (byteBuffer[i] == 238)
                            {
                                i238++;
                            }
                            else
                            {
                                i238 = 0;
                            }

                            if (i238 >= 5)
                            {
                                // 提取重复标志位的数据
                                int iErrCmd = iEndLoc - iStartLoc + 1;
                                byte[] cmdErr = new byte[iErrCmd];
                                for (int k = 0; k < iErrCmd; k++)
                                {
                                    if (iStartLoc > -1)
                                    {
                                        cmdErr[k] = byteBuffer[iStartLoc + k];
                                    }
                                }

                                // 显示重复标志位的数据
                                //if (RTxtMsge != null)
                                //{
                                //    RTxtMsge.WriteTxt(cmdErr, " [标志重复]", true, 0);
                                //}
                                for (int j = 0; j < byteBuffer.Length; j++)
                                {
                                    byteBuffer[j] = (byte)0;
                                }
                                iStartLoc = i - 1;
                                break;
                            }
                        }

                        #endregion

                        #region [ 提取完整命令 ]

                        // 根据命令长度，分配命令存放的空间
                        iCmdNewLength = iEndLoc - iStartLoc - 9;
                        if (iCmdNewLength < 1)
                        {
                            // Error: 
                            string str = string.Empty;
                            return;
                        }
                        cmdNewBytes = new byte[iCmdNewLength];

                        // 提取完整命令
                        for (int i = 0; i < iCmdNewLength; i++)
                        {
                            cmdNewBytes[i] = byteBuffer[iStartLoc + i + 6];
                        }

                        iCurLoc = 0;
                        for (int i = 0; i < byteBuffer.Length; i++)
                        {
                            byteBuffer[i] = (byte)0;
                        }

                        //// 将后续命令前移
                        //if (iEndLoc + 1 < iCurLoc)
                        //{
                        //    iEndLoc++;

                        //    int iCmdTmpLength = iCurLoc - iEndLoc;
                        //    for (int i = 0; i <= iCmdTmpLength; i++)
                        //    {
                        //        byteBuffer[i] = byteBuffer[iEndLoc + i];
                        //    }

                        //    iCurLoc = iCmdTmpLength;
                        //}
                        //else
                        //{
                        //    iCurLoc = 0;
                        //}

                        #endregion
                        break;
                    default://KJ128V2
                        #region [ 提取完整命令 ]
                        try
                        {
                            iCmdNewLength = 0;
                            if (byteBuffer.Length > 9)
                            {
                                switch (byteBuffer[iStartLoc + 7])
                                {
                                    case 20://数据回送
                                        iCmdNewLength = 6 + int.Parse(byteBuffer[iStartLoc + 8].ToString()) + int.Parse(byteBuffer[iStartLoc + 9].ToString()) * 256;
                                        if (iCmdNewLength <= 6)
                                        {
                                            cmdNewBytes = null;
                                            if (timer.Enabled == false)
                                            {
                                                timer.Enabled = true;
                                            }
                                            return;
                                        }
                                        if (byteBuffer.Length < iCmdNewLength + 6)
                                        {
                                            iCmdNewLength = 0;
                                            for (int i = 0; i < byteBuffer.Length; i++)
                                            {
                                                byteBuffer[i] = (byte)0;
                                            }
                                        }
                                        break;
                                    case 21://数据回送成功确认
                                    case 23://对时成功确认
                                    case 24://请求对时
                                        iCmdNewLength = 4;
                                        break;
                                    default:
                                        for (int i = 0; i < byteBuffer.Length; i++)
                                        {
                                            byteBuffer[i] = (byte)0;
                                        }
                                        break;
                                }
                            }


                            // 根据命令长度，分配命令存放的空间
                            if (iCmdNewLength < 1)
                            {
                                // Error: 
                                string str = string.Empty;
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            cmdNewBytes = new byte[iCmdNewLength];
                            byte[] cmdBytesAll = new byte[iCmdNewLength + 5];
                            for (int i = 0; i < iCmdNewLength + 5; i++)
                            {
                                cmdBytesAll[i] = byteBuffer[iStartLoc + i + 1];
                            }
                            // 提取完整命令
                            for (int i = 0; i < iCmdNewLength; i++)
                            {
                                cmdNewBytes[i] = byteBuffer[iStartLoc + i + 6];
                            }

                            #region [分析效验位]
                            _crcByte = CRCVerify.Crc(cmdBytesAll, iCmdNewLength + 3, 0);
                            #endregion

                            if (_crcByte == null)
                            {
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            if (cmdNewBytes[1] == 0)
                            {
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            //if (cmdNewBytes[cmdNewBytes.Length - 1] == 0 && cmdNewBytes[cmdNewBytes.Length - 2] == 0)
                            //    return;
                            // 验证命令号是否正确  cmdNewBytes[1] != CmdNO
                            if (cmdNewBytes[1] != mStation.SCmd && cmdNewBytes[1] != 24)
                            {
                                for (int i = 0; i < byteBuffer.Length; i++)
                                {
                                    byteBuffer[i] = (byte)0;
                                }
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            // Crc 校验
                            if (!_crcByte[0].Equals(cmdNewBytes[cmdNewBytes.Length - 1]) || !_crcByte[1].Equals(cmdNewBytes[cmdNewBytes.Length - 2]))
                            {
                                cmdNewBytes = null;
                                if (timer.Enabled == false)
                                {
                                    timer.Enabled = true;
                                }
                                return;
                            }
                            iCurLoc = 0;
                            for (int i = 0; i < byteBuffer.Length; i++)
                            {
                                byteBuffer[i] = (byte)0;
                            }
                        }
                        catch
                        {
                            for (int i = 0; i < byteBuffer.Length; i++)
                            {
                                byteBuffer[i] = (byte)0;
                            }
                            cmdNewBytes = null;
                            if (timer.Enabled == false)
                            {
                                timer.Enabled = true;
                            }
                        }

                        #endregion
                        break;
                }
            }
            catch
            {
                cmdNewBytes = null;
                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                }
            }
            
            //// 重置所有的标志位
            //iStartLoc = -1;
            //iEndLoc = -1;
            //iEndStartLoc = -1;
        }

        #endregion

        #region [ 方法 ] 根据基站地址获取基站编号

        /// <summary>
        /// 根据基站地址获取基站编号
        /// </summary>
        /// <param name="iAddress">基站地址号</param>
        public int GetStationID(int iAddress)
        {
            for (int i = 0; i < Stations.Length; i++)
            {
                if (Stations[i].Address == iAddress)
                {
                    return Stations[i].ID;
                }
            }

            return -1;
        }

        /// <summary>
        /// 根据分站地址获取分站信息
        /// </summary>
        /// <param name="iAddress">分站地址号</param>
        /// <returns>分站信息</returns>
        public MemStation GetStation(int iAddress)
        {
            for (int i = 0; i < Stations.Length; i++)
            {
                if (Stations[i].Address == iAddress)
                {
                    return Stations[i];
                }
            }
            return new MemStation();
        }

        #endregion


        #region【Czlt-2010-11-29 双向通讯】
        #region 【方法：获取要呼叫的标识卡】
        /// <summary>
        /// 获取要呼叫的标识卡
        /// </summary>
        /// <param name="iCards">标识卡数组</param>
        /// <returns></returns>
        public string SetCardToStr(int[] iCards)
        {
            try
            {
                string strCard = "";

                if (iCards.Length < 1)
                {
                    return null;
                }

                for (int i = 0; i < iCards.Length; i++)
                {
                    if (i == iCards.Length - 1)
                    {
                        strCard += iCards[i];
                    }
                    else
                    {
                        strCard += iCards[i] + ",";
                    }
                }
                return strCard;
            }
            catch
            {
                return null;
            }

        }
        #endregion


        public override void timer_Call_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            iScloseCall = false;
        }
        #endregion

    }
}
