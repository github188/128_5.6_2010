using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Xml;
using System.Threading;
using System.IO;

namespace KJ128A.HostBack
{
    public class ServerRB
    {
        #region 【参数】
        /// <summary>
        /// 3S定时器判断刚开机时备机连接状态
        /// </summary>
        private System.Timers.Timer timerCount = new System.Timers.Timer();
        /// <summary>
        /// 发送对时时间定时器
        /// </summary>
        private System.Timers.Timer timerSend = new System.Timers.Timer();
        /// <summary>
        /// 发送对时时间定时次数
        /// </summary>
        private static int timerSendCount = 0;
        /// <summary>
        /// 备机IP地址
        /// </summary>
        private string m_StandbyIpAddress = "";
        /// <summary>
        /// 侦听端口
        /// </summary>
        private int m_port;
        /// <summary>
        /// 主备机连接状态
        /// </summary>
        private bool m_ConnState = false;
        /// <summary>
        /// 备机上次连接状态
        /// </summary>
        private bool m_LastStandbyState = false;
        /// <summary>
        /// 服务器对象
        /// </summary>
        private SockServer socketServer = new SockServer();
        /// <summary>
        /// 文件操作对象
        /// </summary>
        private FileOperator fileOperator = new FileOperator();
        /// <summary>
        /// 热备操作数据库对象
        /// </summary>
        private RBSqlConn rbSqlConn = new RBSqlConn();
        /// <summary>
        /// 表信息
        /// </summary>
        private ArrayList sqlTableHeadsAL;

        /// <summary>
        ///Czlt-2011-12-10 备机上次状态改变的时间
        /// </summary>
        private string lastStandbyStateTime = string.Empty;

        /// <summary>
        /// Czlt-2011-12-10 故障天数
        /// </summary>
        private int czltIntDay = 0;
        #endregion

        #region 【设置本地时间API函数】
        /// <summary>
        /// 设置本地时间
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static int SetLocalTime(ref SystemTime st);
        #endregion

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

        #region 【事件声明：错误消息事件】

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

        #endregion 【事件声明：错误消息事件】

        #region 【构造函数】
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strStandbyIpAddress">备机Ip地址</param>
        /// <param name="port">侦听端口</param>
        public ServerRB(string strStandbyIpAddress,int port)
        {
            m_StandbyIpAddress = strStandbyIpAddress;
            m_port = port;
            //获取各个表信息
            sqlTableHeadsAL = rbSqlConn.SetSqlTableHead();
            //创建链接服务器
            rbSqlConn.ExecCreadLineServer(strStandbyIpAddress);

            socketServer.ClientConnect += new SockServer.ClientConnectEventHandler(socketServer_ClientConnect);
            socketServer.DataReceivedByAddress += new SockServer.DataReceivedEventHandler(socketServer_DataReceivedByAddress);
            socketServer.ErrorMessage += new SockServer.ErrorMessageEventHandler(socketServer_ErrorMessage);
            timerCount.Interval = 3000;
            timerCount.Elapsed += new System.Timers.ElapsedEventHandler(timerCount_Elapsed);
            timerSend.Interval = 3000;
            timerSend.Elapsed += new System.Timers.ElapsedEventHandler(timerSend_Elapsed);
        }
        #endregion

        #region 【事件方法：同步主备机时间】
        void timerSend_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (m_ConnState)
            {
                if (timerSendCount >= 1200)
                {
                    timerSendCount = 0;
                    //发送主机时间给备机对时
                    string strMsg = "T1," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",T1";
                    byte[] byData = System.Text.Encoding.ASCII.GetBytes(strMsg);
                    socketServer.Send(byData, m_StandbyIpAddress);
                }
                timerSendCount++;
            }
        }
        #endregion

        #region 【事件方法：错误处理】
        void socketServer_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {

            //Czlt-2012-03-06 通讯已连接的时候,通讯状态为True
            if (iErrNO == 8033001)
            {
                fileOperator.StandbyState = true;
                m_ConnState = true;
                rbSqlConn.ConnState = true;
            }
            else
            {
                fileOperator.StandbyState = false;
                m_ConnState = false;
                rbSqlConn.ConnState = false;
            }

            //Czlt-2012-01-05 主机正常备机故障的时候 修改备机状态
           // fileOperator.StandbyState = false;
            fileOperator.StandbyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd");
            fileOperator.UpdateHostFile();

         

            //Czlt-2012-03-06 注销
            //m_ConnState = false;
            //rbSqlConn.ConnState = false;
            if (ErrorMessage!=null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }
        #endregion

        #region 【方法：侦听端口】
        /// <summary>
        /// 侦听端口
        /// </summary>
        public void Listen()
        {
            //侦听端口
            socketServer.StartListen(m_port);
            //判断备机是否连接定时器开始
            timerCount.Start();
            timerSend.Start();
        }
        #endregion


        #region 【事件方法：定时判断连接备机状态】
        void timerCount_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            //让主机正常收发数据
            if (ErrorMessage != null)
            {
                ErrorMessage(8033002, "", "[ServerRB:timerCount_Elapsed]", "");
            }

            timerCount.Stop();
            //主备机连接故障
            m_ConnState = false;
            rbSqlConn.ConnState = false;
            //记录备机故障时间和故障状态
            fileOperator.StandbyState = false;
            fileOperator.StandbyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd");
            fileOperator.UpdateHostFile();
           
        }
        #endregion

        #region 【事件方法：获取某个远程连接的数据】
        void socketServer_DataReceivedByAddress(string strMsg, string strAddress)
        {
            if (strAddress.Equals(m_StandbyIpAddress))
            {
                if (!strMsg.Equals("1\0"))
                {
                    //Czlt-2011-12-10 修改备机配置信息的标识状态
                    bool czltIsTrue = true;
                    string[] strTemp = strMsg.Split(',');
                    //定义备机发送过来的主机状态参数
                    bool sStateTemp;
                    string strTime = "";
                    if (strTemp.Length > 2)
                    {
                        
                        switch (strTemp[0].Substring(strTemp[0].Length-1,1))
                        {
                            case "C"://备机发送的主机的状态
                                //获取备机发送过来的主机状态
                                sStateTemp = bool.Parse(strTemp[1]);
                                if (!sStateTemp)
                                {
                                    if (m_LastStandbyState)//备机上次为正常
                                    {
                                        //Czlt-2011-12-10 修改配置状态
                                        czltIsTrue = false;
                                        #region 【设置主机的时间】
                                        strTime = strTemp[2];//获取发送过来的时间
                                        SystemTime systNew = new SystemTime();
                                        string[] sArray = strTime.Split(' ');
                                        if (sArray.Length > 1)
                                        {
                                            string[] sArrYear = sArray[0].ToString().Split('-');
                                            string[] sArrTime = sArray[1].ToString().Split(':');
                                            systNew.wYear = Convert.ToInt16(sArrYear[0].ToString());
                                            systNew.wMonth = Convert.ToInt16(sArrYear[1].ToString());
                                            systNew.wDay = Convert.ToInt16(sArrYear[2].ToString());
                                            systNew.wHour = Convert.ToInt16(sArrTime[0].ToString());
                                            systNew.wMinute = Convert.ToInt16(sArrTime[1].ToString());
                                            systNew.wSecond = Convert.ToInt16(sArrTime[2].ToString());
                                            SetLocalTime(ref systNew);
                                        }
                                        #endregion

                                        //File.AppendAllText("D:\\TestSqlTS.txt", "获取备机的实时数据，写入主机数据库中，读异地存本地 开始时间："+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n   ", Encoding.Default);
                                        //获取备机的实时数据，写入主机数据库中，读异地存本地
                                       // rbSqlConn.ExecReadOtherUpdateLocalReal();

                                        //Czlt-2011-12-12 获取备机的实时数据和配置信息，写入主机数据库中，读异地存本地  
                                        rbSqlConn.ConnState = true;
                                        rbSqlConn.ExecReadOtherUpdateLocalRealConfig();

                                        //Czlt-2012-3-23 同步考勤原始数据
                                        rbSqlConn.GetKqtj();
                                       // File.WriteAllText("D:\\TestSqlServerRB.txt", " 获取备机的实时数据和配置信息：ExecReadOtherUpdateLocalRealConfig() 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\r\n   ", Encoding.Default);
                                    }
                                    //else//备机上次为故障
                                    //{
                                       
                                        //发送主机的时间给备机对时
                                        timerSendCount = 0;
                                        //发送主机时间给备机对时
                                        string strMsg1 = "T," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",T";
                                        byte[] byData = System.Text.Encoding.ASCII.GetBytes(strMsg1);
                                        socketServer.Send(byData, m_StandbyIpAddress);

                                      
                                    //}

                                     
                                   // czltIntDay=Convert.ToString(lastStandbyStateTime)
                                    ////获取最后一天的的历史数据线程开启--注销
                                    //rbSqlConn.StartHisOneThread();

                                   // File.WriteAllText("D:\\TestSqlServerRB.txt", " 上次备机故障的时间：lastStandbyStateTime " + lastStandbyStateTime + "打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n   ", Encoding.Default);
                                    //Czlt-2011-12-10 故障的时间为空的时候赋值给前三天的值
                                    if (lastStandbyStateTime.Trim().Equals(""))
                                    {
                                        lastStandbyStateTime = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss");
                                    }
                                    //Czlt-2011-12-12 相差天数
                                    czltIntDay = (DateTime.Now - Convert.ToDateTime(lastStandbyStateTime)).Days;
                                   // File.WriteAllText("D:\\TestSqlServerRB.txt", " 备机上次为正常，主机故障的天数：czltIntDay " + czltIntDay + "打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n   ", Encoding.Default);
                                    rbSqlConn.CzltDays = czltIntDay;

                                    if (czltIntDay <= 3)
                                    {
                                        
                                        rbSqlConn.StartHisOneThread();
                                       // File.WriteAllText("D:\\TestSqlServerRB.txt", " 执行备份一天的历史数据！StartHisOneThread() 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\r\n   ", Encoding.Default);

 
                                    }
                                    else
                                    {
                                        //Czlt-2011-12-12 获取一个月的数据
                                        //File.WriteAllText("D:\\TestSqlServerRB.txt", " 执行备份一个月的历史数据！CzltStartHisMthThread() 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\r\n   ", Encoding.Default);
                                        rbSqlConn.CzltStartHisMthThread();
 
                                    }
                                    

                                }
                                else//主机正常
                                {
                                    timerSendCount = 0;
                                    //发送主机时间给备机对时
                                    string strMsg1 = "T," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",T";
                                    byte[] byData = System.Text.Encoding.ASCII.GetBytes(strMsg1);
                                    socketServer.Send(byData, m_StandbyIpAddress);
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    //Czlt-2011-12-12 假如备机上次为正常的时候，不从主机拷贝配置信息
                    if (czltIsTrue)
                    {
                        //开始设置异地配置信息
                        rbSqlConn.StartConfigThread();
                       
                    }
                    else
                    {
                        czltIsTrue = true;
                    }



                    //让主机正常收发数据
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(8033001, "", "[ServerRB:socketServer_ClientConnect]", "");
                    }
                }
            }
        }
        #endregion

        #region 【事件方法：获取某个远程连接的状态】
        void socketServer_ClientConnect(string strIpAddress, bool connState)
        {
            //判断获取得到的远程连接的IP地址是否是备机的IP地址
            if (strIpAddress.Equals(m_StandbyIpAddress))
            {
                //获取主备机目前的连接状态
                m_ConnState = connState;
                rbSqlConn.ConnState = connState;
                if (connState)//和备机连接成功
                {
                    //Czlt-2012-03-06 添加移动关闭的位置
                    timerCount.Stop();

                    //让主机正常收发数据
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(8033001, "", "[ServerRB:socketServer_ClientConnect]", "");
                    }

                    //Czlt-2012-03-06 注销
                    //timerCount.Stop();

                    //获取主机记录的备机信息是否有故障信息
                    fileOperator.ReadHostFile();
                    m_LastStandbyState = fileOperator.StandbyState;

                    //Czlt-2011-12-10 给上次的时间赋值
                    lastStandbyStateTime = fileOperator.StandbyTime;

                    //Czlt-2012-03-06 添加状态的修改
                    m_ConnState = true;
                    rbSqlConn.ConnState = true;

                    fileOperator.StandbyState = true;
                    fileOperator.StandbyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    fileOperator.UpdateHostFile();

                    // File.WriteAllText("D:\\TestSqlServerRB.txt", " 备机上次故障的时间：" + m_LastStandbyState + "打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\r\n   ", Encoding.Default);


                    //发送备机状态给主机
                    string strMsg = "S," + m_LastStandbyState.ToString() + ",S1";
                    byte[] byData = System.Text.Encoding.ASCII.GetBytes(strMsg);
                    socketServer.Send(byData, strIpAddress);
                    ////让主机与备机连接正常
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(8033008, "", "[ServerRB:socketServer_ClientConnect]", "");
                    //}
                    ////让主机正常收发数据
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(8033001, "", "[ServerRB:socketServer_ClientConnect]", "");
                    //}
                }
                else//和备机连接失败
                {


                    //让主机正常收发数据
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(8033002, "", "[ServerRB:socketServer_ClientConnect]", "");
                    }

                    //记录备机故障时间和故障状态
                    fileOperator.StandbyState = false;
                    fileOperator.StandbyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    fileOperator.UpdateHostFile();


                }
            }
            else
            {
                ////让主机正常收发数据
                //if (ErrorMessage != null)
                //{
                //    ErrorMessage(8033002, "", "[ServerRB:socketServer_ClientConnect]", "");
                //}
            }
        }
        #endregion


    }
}
