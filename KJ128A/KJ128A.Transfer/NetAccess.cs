using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;

namespace KJ128A.Transfer
{
    /// <summary>
    /// 网络传输类
    /// </summary>
    public class NetAccess : IDisposable
    {

        #region [ 声明: 委托 ] 错误消息事件

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        public delegate void ErrorMessageEventHandler(int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ 声明: 委托 ] 数据抵达消息事件

        /// <summary>
        /// 数据抵达声明
        /// </summary>
        /// <param name="dataInfo">数据信息</param>
        /// <param name="result">返回执行结果</param>
        public delegate void DataReceivedEventHandler(byte[] dataInfo, out bool result);

        /// <summary>
        /// 数据抵达事件
        /// </summary>
        public event DataReceivedEventHandler DataReceived;

        #endregion

        #region [ 声明: 委托 ] 发送初次连接

        /// <summary>
        /// 发送初次连接 在 InitSendSocket 方法中
        /// </summary>
        public delegate void InitSendLinkEventHandler();

        /// <summary>
        /// 发送初次连接事件
        /// </summary>
        public event InitSendLinkEventHandler InitSendLink;

        #endregion

        #region [ 声明: 委托 ] 监听初次连接

        /// <summary>
        /// 监听初次连接 在 Start 方法中
        /// </summary>
        public delegate void InitListenLinkEventHandler();

        /// <summary>
        /// 监听初次连接事件
        /// </summary>
        public event InitListenLinkEventHandler InitListenLink;

        #endregion

        #region [ 声明: 委托 ] 发送连接断开

        /// <summary>
        /// 监听初次连接 在 Start 方法中
        /// </summary>
        public delegate void CutSendLinkEventHandler();

        /// <summary>
        /// 监听初次连接事件
        /// </summary>
        public event CutSendLinkEventHandler CutSendLink;

        #endregion

        #region [ 变量: 参数 ]

        private Thread threadNet;
        private Thread thLink;
        private int port, bSize;             //端口 接收数据缓存字节数组大小
        private Socket socketListen;
        private Socket socketSend;
        private Socket socketLink;
        private string sendIp;
        private int sendPort;
        private bool _blConnect = false, _blSending = false;
        private bool _blFirstCut = true, _blFirstLink = true;
        Network n = new Network();
        //private bool _

        #endregion

        #region [ 方法: 初始化监听参数并开始监听 ]

        /// <summary>
        /// 初始化监听参数并开始监听
        /// </summary>
        /// <param name="strIp">远程机器ip</param>
        /// <param name="pPort">监听端口</param>
        /// <param name="sPort">远程机器端口</param>
        /// <param name="size">接收数据字节数组大小</param>
        public void StartListen(string strIp, int pPort, int sPort, int size)
        {
            // 初始化参数
            sendIp = strIp;
            port = pPort;
            sendPort = sPort;
            bSize = size;

            threadNet = new Thread(Start);
            threadNet.Start();
            // 开启测试线程
            thLink = new Thread(SendTest);
            thLink.Start();
        }

        #endregion

        #region [ 方法: 测试连接 ]

        /// <summary>
        /// 初次监听时判断网络状态
        /// </summary>
        /// <returns></returns>
        private bool Ping()
        {
            try
            {
                if (!n.Ping(sendIp))
                {
                    ErrorMessage(2100004, "156行", "[NetAccess:CheckPing]", "网络ping不通");
                    return false;
                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.IndexOf("由于网络连接不可用，无法使用 ping 命令") > -1)
                {
                    return false;
                }
                return false;
            }
            
            return true;
        }

        #endregion

        #region [ 初次握手测试连接 ]

        private void SendTest()
        {
            int _priCount = 0;
            while (true)
            {
                if (!_blSending)
                {
                    _priCount = 0;
                    #region 初次握手测试连接
                    while (!SendTcpFun(Encoding.Default.GetBytes("ko")))
                    {
                        socketSend = null;
                        // 连接状态
                        _blConnect = false;
                        _priCount++;
                        if (_priCount < 3)
                        {
                            continue;
                        }
                        // 初次断开连接 
                        if (_blFirstCut)
                        {
                            CutSendLink();
                            // 状态
                            _blFirstCut = false;
                            _blFirstLink = true;
                        }
                        Thread.Sleep(1000);
                    }
                    _blFirstCut = true;
                    // 初次连接事件
                    if (_blFirstLink)
                    {
                        // 不接收数据
                        InitListenLink();

                        // 初次连接为假
                        _blFirstLink = false;
                    }
                    // 状态为连接
                    _blConnect = true;
                    #endregion
                    Thread.Sleep(3000);
                    continue;
                }
                else
                {
                    Thread.Sleep(3000);
                }
            }
        }

        #endregion

        #region [ 方法: 监听 ]

        /// <summary>
        /// 开始监听
        /// </summary>
        private void Start()
        {
            // 缓存字节数组用于接收
            byte[] recvBytes = new byte[bSize];        // 缓存字节数组用于接收

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPEndPoint ipe = null;
            for (int i = 0; i <ipHostInfo.AddressList.Length; i++)
            {
                if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ipe = new IPEndPoint(ipHostInfo.AddressList[i], port);
                    break;                    
                }
            }

            while (true)
            {
                try
                {
                    if (socketListen == null)
                    {
                        socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socketListen.Bind(ipe);           // 绑定IP和端口
                        socketListen.Listen(0);           // 开始监听
                        //socketListen.ReceiveTimeout = 10000;
                    }

                    socketLink = socketListen.Accept();
                    socketLink.ReceiveTimeout = 10000;
                    // 循环监听
                    try
                    {
                        while (true)
                        {
                            #region 接受数据验证并回发验证数据
                            //recvBytes = new byte[bSize];        // 缓存字节数组用于接收
                            socketLink.Receive(recvBytes, recvBytes.Length, 0);
                            // 数据为空  监听连接断开后重新创建连接
                            if (Encoding.Default.GetString(recvBytes, 0, 1) != "\0")
                            {
                                bool blResult = true;
                                // 数据抵达
                                DataReceived(SubByteArray(recvBytes, 26, 26 + int.Parse(System.Text.Encoding.Default.GetString(SubByteArray(recvBytes, 0, 9)))), out blResult);
                                byte[] bytesTime = SubByteArray(recvBytes, 9, 26);
                                string strTime = Encoding.Default.GetString(bytesTime);
                                // 事件完成后返回false
                                if (!blResult)
                                {
                                    // 17位时间 1位返回确认信息 1true 0false
                                    strTime += "0";
                                }
                                else
                                {
                                    strTime += "1";
                                }
                                bytesTime = Encoding.Default.GetBytes(strTime);
                                // 返回确认信息
                                socketLink.Send(bytesTime);
                                bytesTime = null;
                            }
                            else
                            {
                                ErrorMessage(2100054, "240行", "[NetAccess:Start]", "通讯机器断开连接");
                                // 跳出循环  重新创建监听连接 等待监听
                                break;
                            }
                            #endregion
                            //recvBytes = null;
                        }
                    }
                    catch (SocketException se)
                    {
                        if (socketLink != null)
                        {
                            socketLink.Close();
                            socketLink = null;
                        }
                        if (se.ErrorCode == 10048)
                        {
                            ErrorMessage(2100048, se.StackTrace, "[NetAccess:Start]", se.Message);
                            return;
                        }
                        else if (se.ErrorCode == 10054)
                        {
                            ErrorMessage(7100054, se.StackTrace, "[NetAccess:Start]", se.Message);
                        }
                        else
                        {
                            ErrorMessage(7100054, se.StackTrace, "[NetAccess:Start]", se.Message);
                        }
                    }
                    catch (Exception ee)
                    {
                        if (socketLink != null)
                        {
                            socketLink.Close();
                            socketLink = null;
                        }
                        ErrorMessage(7100054, ee.StackTrace, "[NetAccess:Start]", ee.Message);
                    }
                }
                catch (System.Security.SecurityException)
                {
                    if (socketLink != null)
                    {
                        socketLink.Close();
                        socketLink = null;
                    }
                    //MessageBox.Show("防火墙安全错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (SocketException sse)
                {
                    if (socketLink != null)
                    {
                        socketLink.Close();
                        socketLink = null;
                    }
                    ErrorMessage(6100001, sse.StackTrace, "[NetAccess:Start]", sse.Message);
                }
                catch (Exception ee)
                {
                    if (socketLink != null)
                    {
                        socketLink.Close();
                        socketLink = null;
                    }
                    ErrorMessage(6100009, ee.StackTrace, "[NetAccess:Start]", ee.Message);
                }
            }
        }

        #endregion

        #region [ 方法: 发送数据 ]

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="byteArray">发送的数据</param>
        /// <returns>执行结果</returns>
        public bool SendTcpFun(byte[] byteArray)
        {
            bool sendTcpFunFalg = true;
            try
            {
                // 为空时初始化连接
                if (socketSend == null)
                {
                    IPAddress ipAddress = IPAddress.Parse(sendIp);
                    IPEndPoint ipe = new IPEndPoint(ipAddress, sendPort);
                    socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    if (!Ping())
                    {
                        socketSend = null;
                        return false;
                    }
                    socketSend.Connect(ipe);
                    socketSend.SendTimeout = 600;
                    socketSend.ReceiveTimeout = 600;
                }
                // 记录验证时间
                byte[] bTimeCheckout = null;
                // 格式化数据
                byte[] bSendData = FormatSendData(byteArray, out bTimeCheckout);
                socketSend.Send(bSendData);                 // 发送
                // 接收从服务器返回的信息
                byte[] recvBytes = new byte[18];
                socketSend.Receive(recvBytes);

                if (System.Text.Encoding.Default.GetString(recvBytes, 0, 17) != System.Text.Encoding.Default.GetString(bTimeCheckout))
                {
                    // 时间校验数据     数据不正确 网络故障 或执行操作结果
                    socketSend.Close();
                    socketSend = null;
                    sendTcpFunFalg = false;
                }
                else if (System.Text.Encoding.Default.GetString(recvBytes, 17, 1) == "0")
                {
                    socketSend.Close();
                    socketSend = null;
                    sendTcpFunFalg = false;
                }

                bTimeCheckout = null;
                bSendData = null;
                recvBytes = null;
            }
            #region 错误捕捉
            catch (SocketException ex)
            {
                if (socketSend != null)
                {
                    socketSend.Close();
                    socketSend = null;
                }
                if (ex.ErrorCode == 10048)
                {
                    ErrorMessage(2100048, ex.StackTrace, "[NetAccess:SendTcpFun]", ex.Message);
                }
                if (ex.ErrorCode == 10054)
                {
                    ErrorMessage(7100054, ex.StackTrace, "[NetAccess:SendTcpFun]", ex.Message);
                }
                if (ex.ErrorCode == 10053)
                {
                    ErrorMessage(7100053, ex.StackTrace, "[NetAccess:SendTcpFun]", ex.Message);
                }
                if (ex.ErrorCode == 10057)
                {
                    ErrorMessage(7100057, ex.StackTrace, "[NetAccess:SendTcpFun]", ex.Message);
                }
                if (ex.ErrorCode == 10060)
                {
                    ErrorMessage(7100060, ex.StackTrace, "[NetAccess:SendTcpFun]", ex.Message);
                }
                if (ex.ErrorCode == 10061)
                {
                    ErrorMessage(7100061, ex.StackTrace, "[NetAccess:SendTcpFun]", ex.Message);
                }
                if (ex.ErrorCode == 10065)
                {
                    ErrorMessage(7100065, ex.StackTrace, "[NetAccess:SendTcpFun]", ex.Message);
                }

                sendTcpFunFalg = false;
            }
            catch (Exception e)
            {
                if (socketSend != null)
                {
                    socketSend.Close();
                    socketSend = null;
                }
                
                ErrorMessage(6100001, e.StackTrace, "[NetAccess:SendTcpFun]", e.Message);
                sendTcpFunFalg = false;
            }

            return sendTcpFunFalg;
            #endregion
        }

        /// <summary>
        /// 发送数据（发送失败会循环发送直到发送成功）
        /// </summary>
        /// <param name="byteArray">发送的数据</param>
        /// <param name="iMillisecond">发送失败后循环发送间隔时间</param>
        /// <returns>执行结果</returns>
        public bool SendTcpFun(byte[] byteArray, int iMillisecond)
        {
            while (true)
            {
                try
                {
                    // 状态未发送
                    if (!_blConnect)
                    {
                        Thread.Sleep(500);
                    }
                    else
                    {
                        // 状态发送中
                        _blSending = true;
                        // 为空时初始化连接
                        if (socketSend == null)
                        {
                            IPAddress ipAddress = IPAddress.Parse(sendIp);
                            IPEndPoint ipe = new IPEndPoint(ipAddress, sendPort);
                            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            if (!Ping())
                            {
                                // 转交连接线程
                                _blSending = false;
                                _blConnect = false;
                                socketSend = null;
                                //发送等待
                                continue;
                            }
                            socketSend.Connect(ipe);
                        }
                        socketSend.ReceiveTimeout = 20000;
                        // 记录验证时间
                        byte[] bTimeCheckout = null;
                        // 格式化数据
                        byte[] bSendData = FormatSendData(byteArray, out bTimeCheckout);
                        socketSend.Send(bSendData);                 // 发送
                        // 接收从服务器返回的信息 17位时间 1位返回确认信息 1true 0false
                        byte[] recvBytes = new byte[18];
                        socketSend.Receive(recvBytes);

                        if (System.Text.Encoding.Default.GetString(recvBytes, 0, 17) != System.Text.Encoding.Default.GetString(bTimeCheckout))
                        {
                            // 时间校验数据     数据不正确 网络故障 或执行操作结果
                            continue;
                        }
                        else if (System.Text.Encoding.Default.GetString(recvBytes, 17, 1) == "0")
                        {
                            // 事件返回false时
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                #region 错误捕捉
                catch (SocketException se)
                {
                    _blConnect = false;
                    _blSending = false;
                    if (socketSend != null)
                    {
                        socketSend.Close();
                        socketSend = null;
                    }
                    if (se.ErrorCode == 10048)
                    {
                        ErrorMessage(2100048, se.StackTrace, "[NetAccess:SendTcpFun]", se.Message);
                        return false;
                    }
                    if (se.ErrorCode == 10054)
                    {
                        ErrorMessage(7100054, se.StackTrace, "[NetAccess:SendTcpFun]", se.Message);
                    }
                    if (se.ErrorCode == 10053)
                    {
                        ErrorMessage(7100053, se.StackTrace, "[NetAccess:SendTcpFun]", se.Message);
                    }
                    if (se.ErrorCode == 10057)
                    {
                        ErrorMessage(7100057, se.StackTrace, "[NetAccess:SendTcpFun]", se.Message);
                    }
                    if (se.ErrorCode == 10060)
                    {
                        ErrorMessage(7100060, se.StackTrace, "[NetAccess:SendTcpFun]", se.Message);
                    }
                    if (se.ErrorCode == 10061)
                    {
                        ErrorMessage(7100061, se.StackTrace, "[NetAccess:SendTcpFun]", se.Message);
                    }
                    if (se.ErrorCode == 10065)
                    {
                        ErrorMessage(7100065, se.StackTrace, "[NetAccess:SendTcpFun]", se.Message);
                    }
                }
                catch (Exception e)
                {
                    _blConnect = false;
                    _blSending = false;
                    if (socketSend != null)
                    {
                        socketSend.Close();
                        socketSend = null;
                    }
                    ErrorMessage(6100001, e.StackTrace, "[NetAccess:SendTcpFun]", e.Message);
                }
                #endregion
            }
            // 状态未发送
            _blSending = false;
            return true;
        }

        #endregion

        #region [ 方法: 截取byte数组 ]

        /// <summary>
        /// 截取byte数组
        /// </summary>
        /// <param name="byteArray">要截取的byte数组</param>
        /// <param name="iStartIndex"></param>
        /// <param name="iEndIndex"></param>
        /// <returns></returns>
        private byte[] SubByteArray(byte[] byteArray, int iStartIndex, int iEndIndex)
        {
            if (iEndIndex > iStartIndex)
            {
                byte[] bRValue = new byte[iEndIndex - iStartIndex];
                Array.Copy(byteArray, iStartIndex, bRValue, 0, bRValue.Length);
                return bRValue;
            }
            return null;
        }

        #endregion

        #region [ 方法: 格式化发送数据 ]

        /// <summary>
        /// 格式化发送数据
        /// </summary>
        /// <param name="byteArray">原始数据</param>
        /// <param name="bTimeCheckout">发送时间(格式:yyyyMMddHHmmssfff)</param>
        /// <returns>格式化后的数据</returns>
        private byte[] FormatSendData(byte[] byteArray, out byte[] bTimeCheckout)
        {
            // 9位长度 不足9位前面补0
            string strTmp = byteArray.Length.ToString();
            int iTmp = 9 - byteArray.Length.ToString().Length;
            if (strTmp.Length < 9)
            {
                for (int i = 0; i < iTmp; i++)
                {
                    strTmp = "0" + strTmp;
                }
            }
            // 17位时间校验
            bTimeCheckout = System.Text.Encoding.Default.GetBytes(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            // 格式化发送数据
            byte[] byteData = new byte[9 + 17 + byteArray.Length];
            byte[] byteLen = System.Text.Encoding.Default.GetBytes(strTmp);
            byteLen.CopyTo(byteData, 0);
            bTimeCheckout.CopyTo(byteData, byteLen.Length);
            byteArray.CopyTo(byteData, byteLen.Length + bTimeCheckout.Length);
            return byteData;
        }

        #endregion

        #region [ 函数: 释放 ]

        /// <summary>
        /// 释放tcp连接,关闭监听线程
        /// </summary>
        public void Dispose()
        {
            if (thLink != null)
            {
                thLink.Abort();
            }
            if (threadNet != null)
            {
                threadNet.Abort();
            }
            if (socketLink != null)
            {
                socketLink.Close();
                socketLink = null;
            }
            if (socketListen != null)
            {
                socketListen.Close();
                socketListen = null;
            }
            if (socketSend != null)
            {
                socketSend.Close();
                socketSend = null;
            }
        }

        #endregion

    }
}