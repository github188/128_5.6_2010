using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.InteropServices;

namespace KJ128A.HostBack
{
    public class ClientRB
    {
        #region 【自定义参数】
        /// <summary>
        /// TCP/IP客户端连接对象
        /// </summary>
        private SocketClient baseSocketClient;
        /// <summary>
        /// 文件操作对象
        /// </summary>
        private FileOperator fileOperator = new FileOperator();
        /// <summary>
        /// 热备操作数据库对象
        /// </summary>
        private RBSqlConn rbSqlConn = new RBSqlConn();
        SocketPacketRB socketPack;
        #region 【属性：socket客户端套接字列表】
        /// <summary>
        /// socket客户端套接字列表
        /// </summary>
        private ArrayList m_socketClientList;
        /// <summary>
        /// 获取socket客户端套接字列表
        /// </summary>
        public ArrayList SocketClientList
        {
            get
            {
                if (baseSocketClient != null)
                {
                    return baseSocketClient.SocketClientList;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
        #endregion

        #region 【事件实现：错误消息】
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
        #endregion 【事件实现：错误消息】

        #region[qyz]
        public delegate void ConnectIfOk(int i);
        public event ConnectIfOk ConIfOkEvent;
        #endregion

        #region 【构造函数】
        /// <summary>
        /// 构造客户端连接对象
        /// </summary>
        /// <param name="socketArrayList">客户端连接列表</param>
        public ClientRB(string strIPaddress, int port)
        {
            if (baseSocketClient == null)
            {
                ArrayList socketArrayList = new ArrayList();
                socketPack = new SocketPacketRB();
                socketPack.IpAddress = strIPaddress;
                socketPack.ClientPort = port;
                socketPack.ErrorShow = false;
                socketPack.State = 0;
                socketArrayList.Add(socketPack);

                //创建链接服务器
                rbSqlConn.ExecCreadLineServer(strIPaddress);
                baseSocketClient = new SocketClient(socketArrayList);
                baseSocketClient.DataReceivedByAddress += new SocketClient.DataReceivedEventHandler(baseSocketClient_DataReceivedByAddress);
                baseSocketClient.ErrorMessage += new SocketClient.ErrorMessageEventHandler(baseSocketClient_ErrorMessage);

                //开始连接远程服务器
                RepeatStart();
            }
        }   
        #endregion 【构造函数】

        #region 【事件方法：获取和远程连接服务器连接状态】
        void baseSocketClient_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (iErrNO != 8033001)//连接失败
            {
                rbSqlConn.ConnState = false;
                //记录主机故障时间和故障状态
                fileOperator.HostState = false;
                fileOperator.HostTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                fileOperator.UpdateStandbyFile();

                rbSqlConn.IsStopTime = true;
              
            }
            else
            {
                rbSqlConn.ConnState = true;
            }

            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }
        #endregion

        #region 【事件：数据回发】
        void baseSocketClient_DataReceivedByAddress(string strMsg, string strAddress)
        {
            //获取主机发送过来的数据
            string[] strTemp = strMsg.Split(',');
            if (strTemp.Length >= 2)
            {
                switch (strTemp[0])
                {
                    case "T1":
                        string strTime1 = strTemp[1];//获取发送过来的时间
                        #region 【设置主机的时间】
                        EditTime(strTime1);
                        #endregion
                        break;
                    case "T"://对时                    
                        string strTime = strTemp[1];//获取发送过来的时间
                        #region 【设置主机的时间】
                        EditTime(strTime);
                        //czlt-2011-08-22 取消定时器的关闭
                        rbSqlConn.IsStopTime = false;
                        //启动获取实时数据和历史数据线程
                        rbSqlConn.StartRealHisDataThread();

                        //File.WriteAllText("D:\\TestSqlClientRB.txt", " rbSqlConn.StartRealHisDataThread(); 启动获取实时数据和历史数据线程   \n   ", Encoding.Default);
                        #endregion
                        break;
                    case "S"://主机发送过来的备机状态
                        bool _StandbyState;//备机状态             

                        _StandbyState = bool.Parse(strTemp[1]);
                        //获取上次主机连接的状态
                        fileOperator.ReadStandbyFile();
                        bool m_LastHostState = fileOperator.HostState;

                        string strDateTime = string.Empty;
                        strDateTime = fileOperator.HostTime;
                        if (strDateTime.Trim().Equals(""))
                        {
                            strDateTime = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss");
 
                        }
                        //Czlt-2011-12-10 获取备机更新时间 
                        rbSqlConn.CzltDays = (DateTime.Now - Convert.ToDateTime(strDateTime)).Days;
                       // File.WriteAllText("D:\\TestSqlClientRB.txt", rbSqlConn.CzltDays+" 天 备机故障的时间\r\n   ", Encoding.Default);

                        //判断上次主机的连接状态 正常的获取主机配置信息和实时数据。
                        //if (!_StandbyState)
                        //{
                        if (m_LastHostState)
                        {
                           
                            //获取主机配置信息和实时数据
                            rbSqlConn.ExecReadOtherUpdateLocalRealConfig();
                          
                        }
                        else
                        {
                           
                            //获取主机配置信息
                            //rbSqlConn.ExecReadOtherUpdateLocalConfig();
                           
                        }
                        //}
                        //发送上次主机连接的状态
                        string strMsg1 = "C," + m_LastHostState.ToString() + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",C";
                        byte[] byData = System.Text.Encoding.ASCII.GetBytes(strMsg1);
                        baseSocketClient.Send(byData, socketPack.IpAddress, socketPack.ClientPort);

                        //2011-03-29 添加
                        //记录这次主机正常状态和时间
                        fileOperator.HostState = true;
                        fileOperator.HostTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        fileOperator.UpdateStandbyFile();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region 【方法：开始连接远程客户端】
        /// <summary>
        /// 开始连接远程主机
        /// </summary>
        public void RepeatStart()
        {
            baseSocketClient.RepeatStart();
        }
        #endregion 【方法：开始连接远程客户端】

        #region 【方法：设置本地时间】
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
        #endregion
    }
}
