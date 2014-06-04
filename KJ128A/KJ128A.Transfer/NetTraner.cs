using System.Text.RegularExpressions;
using System;
using System.Runtime.InteropServices;
namespace KJ128A.Transfer
{
    /// <summary>
    /// 网络传输
    /// </summary>
    public class NetTraner
    {

        #region [ 声明:委托 ] 错误消息事件

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
        /// 发送连接断开
        /// </summary>
        public delegate void CutSendLinkEventHandler();

        /// <summary>
        /// 发送连接断开
        /// </summary>
        public event CutSendLinkEventHandler CutSendLink;

        #endregion

        #region [ 变量: 网络参数 ]

        private string sendIp;
        private int selfPort, sendPort;
        private NetAccess netAccess;

        #endregion

        #region [ 构造函数: 实例化网络接口 ]

        /// <summary>
        /// 初始化网络连接参数
        /// </summary>
        /// <param name="strIP">接收机IP</param>
        /// /// <param name="iSendPort">接收机器的端口</param>
        /// <param name="iLinstenPort">本机监听端口</param>
        public NetTraner(string strIP, int iSendPort, int iLinstenPort)
        {
            if (!Regex.IsMatch(strIP, @"^((0|(?:[1-9]\d{0,1})|(?:1\d{2})|(?:2[0-4]\d)|(?:25[0-5]))\.){3}((?:[1-9]\d{0,1})|(?:1\d{2})|(?:2[0-4]\d)|(?:25[0-5]))$"))
            {
                ErrorMessage(3100003, "123", "[NetAccess:SendTcpFun]", "指定IP无效");
                return;
            }
            sendIp = strIP;
            selfPort = iLinstenPort;    // 本机监听端口
            sendPort = iSendPort;       // 接收机器端口
            // 实例化netAccess
            netAccess = new NetAccess();
            // 监听    字节1048576
            netAccess.StartListen(strIP, selfPort, iSendPort, 10485760);

            netAccess.ErrorMessage += netAccess_ErrorMessage;
            netAccess.DataReceived += netAccess_DataReceived;
            netAccess.InitSendLink += netAccess_InitSendLink;
            netAccess.InitListenLink += netAccess_InitListenLink;
            netAccess.CutSendLink += netAccess_CutSendLink;
        }

        void netAccess_CutSendLink()
        {
            if (CutSendLink != null)
            {
                CutSendLink();
            }
        }

        /// <summary>
        /// 监听初次连接上触发
        /// </summary>
        void netAccess_InitListenLink()
        {
            if (InitListenLink != null)                       //事件已注册时
            {
                InitListenLink();
            }
        }

        /// <summary>
        /// 发送初次连接上触发
        /// </summary>
        void netAccess_InitSendLink()
        {
            if (InitSendLink != null)                       //事件已注册时
            {
                InitSendLink();
            }
        }

        /// <summary>
        /// 数据抵达
        /// </summary>
        /// <param name="dataInfo">数据信息</param>
        /// <param name="result">执行结果</param>
        void netAccess_DataReceived(byte[] dataInfo, out bool result)
        {
            result = true;
            if (DataReceived != null)                       //事件已注册时
            {
                if (System.Text.Encoding.Default.GetString(dataInfo) == "ko")
                    return;
                DataReceived(dataInfo, out result);
            }
        }

        /// <summary>
        /// 错误消息
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        void netAccess_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)                       //事件已注册时
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        #region [ 接口: 发送消息 ]

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="dataBytes">消息内容</param>
        public bool SendMessage(byte[] dataBytes)
        {
            return netAccess.SendTcpFun(dataBytes, 50);
        }

        #endregion

        #region [ 接口: 发送对时命令 ]

        /// <summary>
        /// 发送一单次发送数据命令
        /// </summary>
        /// <param name="dataBytes"></param>
        /// <returns></returns>
        public bool SendOnce(byte[] dataBytes)
        {
            return netAccess.SendTcpFun(dataBytes);
        }

        #endregion

        #region [ 方法: 错误处理 ]

        /// <summary>
        /// 处理错误
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="isShowMsgBox">是否在 MessageBox 中显示</param>
        /// <param name="isExit">是否退出</param>
        public void ErrorMessageFun(int iErrNO, bool isShowMsgBox, bool isExit)
        {
            string strErrMsg = string.Empty;        // 错误消息内容
            switch (iErrNO)
            {
                case 2100003:
                    strErrMsg = "指定IP无效";
                    break;
                case 2100048:
                    strErrMsg = "端口已被占用";
                    break;
                case 7100053:
                    strErrMsg = "远程机器断开连接";
                    break;
                case 7100054:
                    strErrMsg = "远程机器断开连接";   //远程主机强迫关闭了一个现有的连接
                    break;
                case 7100057:
                    strErrMsg = "发送或接收数据的请求没有被接受";
                    break;
                case 7100060:
                    strErrMsg = "连接超时远程机器连接失败";
                    break;
                case 7100061:
                    strErrMsg = "通讯机器未开启";
                    break;
                case 7100065:
                    strErrMsg = "网络不通或程序未开启";
                    break;
                case 6100002:
                    strErrMsg = "发送数据不能为空";
                    break;
                default: break;
            }
        }

        #endregion

        #region [ 函数: 释放 ]

        /// <summary>
        /// 释放tcp连接
        /// </summary>
        public void Dispose()
        {
            netAccess.Dispose();
        }

        #endregion

        /// <summary>
        /// 设置本地时间
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static int SetLocalTime(ref SystemTime st);

        #region [ 结构: SystemTime ]

        /// <summary>
        /// SystemTime
        /// </summary>
        public struct SystemTime
        {
            /// <summary>
            /// wYear
            /// </summary>
            public short wYear;
            /// <summary>
            /// wMonth
            /// </summary>
            public short wMonth;
            /// <summary>
            /// wDayOfWeek
            /// </summary>
            public short wDayOfWeek;
            /// <summary>
            /// wDay
            /// </summary>
            public short wDay;
            /// <summary>
            /// wHour
            /// </summary>
            public short wHour;
            /// <summary>
            /// wMinute
            /// </summary>
            public short wMinute;
            /// <summary>
            /// wSecond
            /// </summary>
            public short wSecond;
            /// <summary>
            /// wMilliseconds
            /// </summary>
            public short wMilliseconds;

        }
        #endregion

        #region [ 方法: 修改计算机时间 ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        private bool EditTime(string strTime)
        {
            try
            {
                SystemTime systNew = new SystemTime();

                string[] sArray = strTime.Split(' ');
                string[] sArrYear = sArray[0].ToString().Split('-');
                string[] sArrTime = sArray[1].ToString().Split(':');

                systNew.wYear = Convert.ToInt16(sArrYear[0].ToString());
                systNew.wMonth = Convert.ToInt16(sArrYear[1].ToString());
                systNew.wDay = Convert.ToInt16(sArrYear[2].ToString());
                systNew.wHour = Convert.ToInt16(sArrTime[0].ToString());
                systNew.wMinute = Convert.ToInt16(sArrTime[1].ToString());
                systNew.wSecond = Convert.ToInt16(sArrTime[2].ToString());
                int result = SetLocalTime(ref systNew);


                if (result == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                if (ex.Message == "尝试读取或写入受保护的内存。这通常指示其他内存已损坏。")
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region [ 时间同步 ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTime">yyyy-MM-dd HH:mm:ss</param>
        /// <returns></returns>
        public bool SyncTime(string strTime)
        {
            return EditTime(strTime);
        }

        #endregion

    }
}



