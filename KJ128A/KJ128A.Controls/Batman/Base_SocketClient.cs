using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using KJ128A.BatmanAPI;

using System.Timers;

namespace KJ128A.Controls.Batman
{
    /// <summary>
    /// TCP/IP客户端连接
    /// </summary>
    public class Base_SocketClient
    {
        #region 【自定义变量】
        /// <summary>
        /// 异步操作调用方法对象
        /// </summary>
        private AsyncCallback m_pfnCallBack;
        /// <summary>
        /// socket客户端套接字列表
        /// </summary>
        private ArrayList m_socketClientList;
        /// <summary>
        /// 获取socket客户端套接字列表
        /// </summary>
        public ArrayList SocketClientList
        {
            get { return m_socketClientList; }
            set { m_socketClientList = value; }
        }
        /// <summary>
        /// 重新连接远程主机线程对象
        /// </summary>
        Thread threadRepeatStart;
        #endregion 【自定义变量】

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

        #region 【事件声明：获取数据】
        /// <summary>
        /// 获取数据和远程客户端地址事件声明
        /// </summary>
        /// <param name="bytes">获取的字节</param>
        /// <param name="strAddress">远程客户端地址</param>
        public delegate void DataReceivedEventHandler(byte[] bytes, string strAddress);
        /// <summary>
        /// 获取数据和远程客户端地址事件
        /// </summary>
        public event DataReceivedEventHandler DataReceivedByAddress;

        /// <summary>
        /// 回发数据判断
        /// </summary>
        private System.Timers.Timer m_reviceTime = new System.Timers.Timer();

        #endregion 【事件声明：获取数据】

        #region 【构造函数】
        /// <summary>
        /// 构造客户端连接对象
        /// </summary>
        /// <param name="socketClientList">socketPacket对象列表</param>
        public Base_SocketClient(ArrayList socketClientList)
        {
            m_socketClientList = socketClientList;

            //m_reviceTime.Interval = 10000;
            //m_reviceTime.Elapsed += new ElapsedEventHandler(m_reviceTime_Elapsed);
            //m_reviceTime.Start();

        }

        /// <summary>
        /// 判断网络是否是假连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_reviceTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            //m_reviceTime.Stop();
            //for (int i = 0; i < m_socketClientList.Count; i++)
            //{
            //    try
            //    {
            //        SocketPacket sPacket = (SocketPacket)m_socketClientList[i];
            //        if (sPacket != null && sPacket.ReviceCount > 3)
            //        {
            //            sPacket.ReviceCount = 0;
            //            if (sPacket.CurrentSocket != null)
            //            {
            //                sPacket.CurrentSocket.Shutdown(SocketShutdown.Both);
            //                sPacket.CurrentSocket.Close();
                           
            //                sPacket.CurrentSocket = null;
            //            }
            //        }
            //    }
            //    catch { }
            //}
            //m_reviceTime.Start();
        }
        #endregion 【构造函数】

        #region 【方法：重新建立连接】
        /// <summary>
        /// 开始重新连接远程主机
        /// </summary>
        public void RepeatStart()
        {
            threadRepeatStart = new Thread(this.Repeat);
            threadRepeatStart.Name = "Repeat";
            threadRepeatStart.Start();
        }

        /// <summary>
        /// 重新连接远程主机
        /// </summary>
        private void Repeat()
        {
            while (true)
            {
                try
                {
                    for (int i = 0; i < m_socketClientList.Count; i++)
                    {
                        SocketPacket s = (SocketPacket)m_socketClientList[i];
                        if (s.CurrentSocket == null || (s.CurrentSocket.Connected == false && s.State != 1))
                        {
                            if (s.CurrentSocket != null)
                            {
                                s.CurrentSocket.Close();
                                s.CurrentSocket = null;
                            }
                            s.State = 1;
                            StartClient(s);
                        }
                    }
                }
                catch
                { }
                finally
                {
                    //3s后重新连接
                    Thread.Sleep(3000);
                }
            }
        }
        #endregion 【方法：重新建立连接】

        #region 【方法：添加一个远程连接地址】
        /// <summary>
        /// 添加远程连接
        /// </summary>
        /// <param name="strIpAddress">远程连接地址</param>
        /// <param name="port">远程连接端口</param>
        public void Add(string strIpAddress, int port)
        {
            #region [判断要连接的列表中是否存在]
            SocketPacket spCollect;
            for (int i = 0; i < m_socketClientList.Count; i++)
            {
                spCollect = (SocketPacket)m_socketClientList[i];
                if (spCollect.IpAddress.Equals(strIpAddress) && spCollect.ClientPort.Equals(port))
                {
                    return;
                }
            }
            spCollect = null;
            #endregion [判断要连接的列表中是否存在]

            #region [添加到要连接的服务器列表中]
            SocketPacket sp = new SocketPacket();
            sp.IpAddress = strIpAddress;
            sp.ClientPort = port;
            sp.ErrorShow = false;
            sp.State = 0;
            m_socketClientList.Add(sp);
            #endregion [添加到要连接的服务器列表中]

            //开始连接远程服务器
            StartClient(sp);
        }
        #endregion 【方法：添加一个远程连接地址】

        #region 【方法：移除一个远程连接地址】
        /// <summary>
        /// 移除一个远程连接
        /// </summary>
        /// <param name="strIpAddress">远程连接地址</param>
        /// <param name="port">远程连接端口</param>
        public void Remove(string strIpAddress, int port)
        {
            SocketPacket spCollect;
            for (int i = 0; i < m_socketClientList.Count; i++)
            {
                spCollect = (SocketPacket)m_socketClientList[i];
                if (spCollect.IpAddress.Equals(strIpAddress) && spCollect.ClientPort.Equals(port))
                {
                    if (threadRepeatStart.ThreadState != ThreadState.Aborted)
                    {
                        threadRepeatStart.Abort();//停止重新连接远程主机
                        
                    }
                    spCollect.CurrentSocket.Shutdown(SocketShutdown.Both);
                    spCollect.CurrentSocket.Close();
                    spCollect.CurrentSocket = null;
                    m_socketClientList.Remove(spCollect);
                    RepeatStart();//开始连接远程主机
                    //threadRepeatStart.Start();//开始连接远程主机
                    break;
                }
            }
        }
        #endregion 【方法：移除一个远程连接地址】

        #region 【方法：开始连接远程服务器】
        /// <summary>
        /// 开始连接远程服务器
        /// </summary>
        /// <param name="socketPacket">要连接的远程服务器包</param>
        private void StartClient(SocketPacket socketPacket)
        {
            try
            {
                //设置指定的网络地址和端口号
                IPAddress ipAddress = IPAddress.Parse(socketPacket.IpAddress);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, socketPacket.ClientPort);
                // 创建一个TCP/IP套接字对象.
                socketPacket.CurrentSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // 对远程主机开始异步连接.
                socketPacket.CurrentSocket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), socketPacket);
            }
            catch (SocketException e)
            {
                try
                {
                    if (socketPacket.CurrentSocket != null)
                    {
                        socketPacket.CurrentSocket.Close();
                        socketPacket.CurrentSocket = null;
                    }
                    if (socketPacket.State == 1 && socketPacket.ErrorShow == false)
                    {
                        ErrorMessage(30001, e.StackTrace, "[Base_SocketClient:StartClient]", socketPacket.IpAddress + "未连接");
                      
                        socketPacket.ErrorShow = true;
                    }
                    socketPacket.State = 2;
                }
                catch { }
            }
            catch (Exception ee)
            { }
        }
        #endregion 【方法：开始连接远程服务器】

        #region 【方法：结束挂起的连接请求】
        /// <summary>
        /// 结束挂起的连接请求
        /// </summary>
        /// <param name="ar">异步调用对象</param>
        private void ConnectCallback(IAsyncResult ar)
        {
            //获取异步操作对象
            SocketPacket socketPacket = (SocketPacket)ar.AsyncState;
            try
            {
                // 与远程主机连接完成
                socketPacket.CurrentSocket.EndConnect(ar);

                if (socketPacket != null)
                {
                    socketPacket.State = 2;
                    if (socketPacket.CurrentSocket != null && socketPacket.CurrentSocket.Connected)
                    {
                        ErrorMessage(30007, "", "[Base_SocketClient:ConnectCallback]", socketPacket.IpAddress + "已连接");
                        socketPacket.ErrorShow = false;
                        //等待接收数据
                        WaitForData(socketPacket);
                    }
                }
            }
            catch (SocketException e)
            {
                try
                {
                    if (socketPacket.CurrentSocket != null)
                    {
                        socketPacket.CurrentSocket.Close();
                        socketPacket.CurrentSocket = null;
                    }
                    if (socketPacket.State == 1 && socketPacket.ErrorShow == false)
                    {
                        ErrorMessage(30002, e.StackTrace, "[Base_SocketClient:ConnectCallback]", socketPacket.IpAddress + "未连接");
                        socketPacket.ErrorShow = true;
                    }
                }
                catch { }
            }
            catch (Exception ee)
            { }
            finally
            {
                if (socketPacket != null)
                {
                    socketPacket.State = 2;
                //    if (socketPacket.CurrentSocket != null && socketPacket.CurrentSocket.Connected)
                //    {
                //        ErrorMessage(30007, "", "[Base_SocketClient:ConnectCallback]", socketPacket.IpAddress + "已连接");
                //        socketPacket.ErrorShow = false;
                //        //等待接收数据
                //        WaitForData(socketPacket);
                //    }
                }
            }
        }
        #endregion 【方法：结束挂起的连接请求】

        #region 【方法：接收数据】
        /// <summary>
        /// 挂起等待接收数据线程
        /// </summary>
        /// <param name="socketPacket">远程连接对象包</param>
        private void WaitForData(SocketPacket socketPacket)
        {
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                // 开始异步获取数据
                socketPacket.DataBuffer = new byte[socketPacket.DataLength];
                socketPacket.CurrentSocket.BeginReceive(socketPacket.DataBuffer, 0, socketPacket.DataBuffer.Length, SocketFlags.None, m_pfnCallBack, socketPacket);
            }
            catch (SocketException se)
            {
                try
                {
                    if (socketPacket.CurrentSocket != null)
                    {
                        socketPacket.CurrentSocket.Close();
                        socketPacket.CurrentSocket = null;
                    }
                    if ((socketPacket.State == 0 || socketPacket.State == 2) && socketPacket.ErrorShow == false)
                    {
                        ErrorMessage(30003, se.StackTrace, "[Base_SocketClient:WaitForData]", socketPacket.IpAddress + "未连接");
                        socketPacket.ErrorShow = true;
                    }
                }
                catch { }
            }
            catch (Exception ee)
            { }

        }

        /// <summary>
        /// 结束挂起的等待接收数据线程
        /// </summary>
        /// <param name="asyn">异步调用对象</param>
        private void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket socketPacket_Received = null;
            try
            {
                socketPacket_Received = (SocketPacket)asyn.AsyncState;
                int iRx = socketPacket_Received.CurrentSocket.EndReceive(asyn);
                if (iRx > 0)//屏蔽无效的空字节qyz 2012-11-30
                {
                    // 获取得到的字符
                    byte[] bytes = new byte[iRx];
                    for (int i = 0; i < iRx; i++)
                    {
                        bytes[i] = socketPacket_Received.DataBuffer[i];
                    }

                    //调用数据获取事件
                    DataReceivedByAddress(bytes, socketPacket_Received.IpAddress);
                }

            }
            catch (SocketException se)
            {
                try
                {
                    if (socketPacket_Received.CurrentSocket != null)
                    {
                        socketPacket_Received.CurrentSocket.Close();
                        socketPacket_Received.CurrentSocket = null;
                    }
                    if ((socketPacket_Received.State == 0 || socketPacket_Received.State == 2) && socketPacket_Received.ErrorShow == false)
                    {
                        ErrorMessage(30004, se.StackTrace, "[Base_SocketClient:WaitForData]", socketPacket_Received.IpAddress + "未连接");
                        socketPacket_Received.ErrorShow = true;
                    }
                    
                }
                catch { }
            }
            catch (Exception ee)
            { }
            finally
            {
                if (socketPacket_Received != null)
                {
                    //继续等待数据
                    WaitForData(socketPacket_Received);
                }
            }
        }
        #endregion 【方法：接收数据】

        #region 【方法：发送数据】
        /// <summary>
        /// 开始发送数据
        /// </summary>
        /// <param name="bytes">发送字节</param>
        /// <param name="strIpAddress">发送的地址</param>
        /// <param name="port">发送的端口</param>
        public void Send(byte[] bytes, string strIpAddress, int port)
        {
            SocketPacket spCollect = new SocketPacket();
            try
            {
                for (int i = 0; i < m_socketClientList.Count; i++)
                {
                    spCollect = (SocketPacket)m_socketClientList[i];
                    if (spCollect.IpAddress.Equals(strIpAddress) && spCollect.ClientPort.Equals(port))
                    {
                        //开始异步发送数据
                        //if (spCollect.CurrentSocket != null)
                        //{
                        //    spCollect.CurrentSocket.SendTimeout = 1800;
                        //    spCollect.CurrentSocket.Blocking = false;                          
                        //    spCollect.ReviceCount++;
                        //    spCollect.CurrentSocket.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(SendCallback), spCollect);
                        //}
                        //break;

                        spCollect.CurrentSocket.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(SendCallback), spCollect);
                        break;
                    }
                }
            }
            catch (SocketException ee)
            {
                try
                {
                    if (spCollect.CurrentSocket != null)
                    {
                        spCollect.CurrentSocket.Close();
                        spCollect.CurrentSocket = null;
                    }
                    if (spCollect.State == 2 && !spCollect.IpAddress.Equals("") && spCollect.ErrorShow == false)
                    {
                        ErrorMessage(30005, ee.StackTrace, "[Base_SocketClient:Send]", spCollect.IpAddress + "未连接");
                        spCollect.ErrorShow = true;
                    }
                }
                catch { }
            }
            catch (Exception e)
            { }
        }

        /// <summary>
        /// 结束挂起的异步发送
        /// </summary>
        /// <param name="ar">异步操作对象</param>
        private void SendCallback(IAsyncResult ar)
        {
            SocketPacket sp_SendCallbace = new SocketPacket();
            try
            {
                sp_SendCallbace = (SocketPacket)ar.AsyncState;

                sp_SendCallbace.CurrentSocket.EndSend(ar);
            }
            catch (SocketException e)
            {
                try
                {
                    if (sp_SendCallbace.CurrentSocket != null)
                    {
                        sp_SendCallbace.CurrentSocket.Close();
                        sp_SendCallbace.CurrentSocket = null;
                    }
                    if (sp_SendCallbace.State == 2 && !sp_SendCallbace.IpAddress.Equals("") && sp_SendCallbace.ErrorShow == false)
                    {
                        ErrorMessage(30005, e.StackTrace, "[Base_SocketClient:SendCallback]", sp_SendCallbace.IpAddress + "未连接");
                        sp_SendCallbace.ErrorShow = true;
                    }
                }
                catch { }
            }
            catch (Exception ee)
            { }
        }
        #endregion 【方法：发送数据】

        #region 【方法：清空所有数据】
        /// <summary>
        /// 清空所有缓存数据
        /// </summary>
        public void Clean()
        {
            threadRepeatStart.Abort();
            SocketPacket spCollect;
            for (int i = 0; i < m_socketClientList.Count; i++)
            {
                spCollect = (SocketPacket)m_socketClientList[i];
                spCollect.CurrentSocket.Shutdown(SocketShutdown.Both);
                spCollect.CurrentSocket.Close();
                spCollect.CurrentSocket = null;
            }
            m_socketClientList.Clear();

            RepeatStart();//开始连接远程主机
        }
        #endregion 【方法：清空所有数据】
    }
}
