using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace KJ128A.HostBack
{
    public class SockServer
    {
        #region 【自定义参数】
        public AsyncCallback pfnWorkerCallBack;
        
        /// <summary>
        /// 侦听Socket
        /// </summary>
        private Socket m_mainSocket;

        /// <summary>
        /// Socket接入数组
        /// </summary>
        private System.Collections.ArrayList m_workerSocketList = ArrayList.Synchronized(new System.Collections.ArrayList());

        #region 【属性：备机是否连接】
        /// <summary>
        /// 备机是否连接
        /// </summary>
        private bool m_IsStandbyState;
        /// <summary>
        /// 获取备机连接状态
        /// </summary>
        public bool IsStandbyState
        {
            get { return m_IsStandbyState; }
        }
        #endregion

        #region 【socket客户端套接字列表】
        ///// <summary>
        ///// socket客户端套接字列表
        ///// </summary>
        //private ArrayList m_socketClientList;
        ///// <summary>
        ///// 获取socket客户端套接字列表
        ///// </summary>
        //public ArrayList SocketClientList
        //{
        //    get { return m_socketClientList; }
        //    set { m_socketClientList = value; }
        //}
        #endregion

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

        #region 【事件声明：有客户端请求接入】
        /// <summary>
        /// 获取远程客户端地址和连接状态事件声明
        /// </summary>
        /// <param name="strIpAddress">远程客户端地址</param>
        /// <param name="connState">连接状态  true为连接正常，false为连接失败</param>
        public delegate void ClientConnectEventHandler(string strIpAddress,bool connState);
        /// <summary>
        /// 获取远程客户端地址和连接状态事件
        /// </summary>
        public event ClientConnectEventHandler ClientConnect;
        #endregion

        #region 【事件声明：获取数据】
        /// <summary>
        /// 获取数据和远程客户端地址和数据事件声明
        /// </summary>
        /// <param name="bytes">获取的字节</param>
        /// <param name="strAddress">远程客户端地址</param>
        public delegate void DataReceivedEventHandler(string strMsg, string strAddress);
        /// <summary>
        /// 获取数据和远程客户端地址和数据事件
        /// </summary>
        public event DataReceivedEventHandler DataReceivedByAddress;
        #endregion 【事件声明：获取数据】

        #region 【构造函数】
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strStandbyIpAddress"></param>
        public SockServer()
        {
        }
        #endregion

        #region 【方法：异步侦听】
        /// <summary>
        /// 开始异步侦听
        /// </summary>
        /// <param name="port">侦听端口号</param>
        public void StartListen(int port)
        {
            try
            {
                // 创建侦听 socket...
                m_mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, port);
                // 绑定本地的地址端口对象
                m_mainSocket.Bind(ipLocal);
                // 开始侦听
                m_mainSocket.Listen(1);
                // 创建一个连接回滚对象
                m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
            catch(Exception ee)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(140001, ee.StackTrace, "[Base_SocketClient:StartClient]", ee.Message);
                }
            }
        }
        #endregion

        #region 【方法：异步回调方法  客户端请求连接同意】
        /// <summary>
        /// 回调方法  客户端请求连接同意
        /// </summary>
        /// <param name="asyn"></param>
        public void OnClientConnect(IAsyncResult asyn)
        {
            Socket workerSocket = null;
            SocketPacketRB sp = null;
            try
            {
                //同意接收接入
                workerSocket = m_mainSocket.EndAccept(asyn);

                sp = new SocketPacketRB();
                sp.ErrorShow = false;
                sp.CurrentSocket = workerSocket;
                sp.IpAddress = ((IPEndPoint)workerSocket.RemoteEndPoint).Address.ToString();
                // 把接入的Socket添加到动态数组中
                m_workerSocketList.Add(sp);

                if (ClientConnect != null)
                {
                    ClientConnect(((IPEndPoint)workerSocket.RemoteEndPoint).Address.ToString(), true);
                }
            }
            catch(Exception ee)
            {
                if (workerSocket != null)
                {
                    if (ClientConnect != null)
                    {
                        ClientConnect(((IPEndPoint)workerSocket.RemoteEndPoint).Address.ToString(), false);
                    }
                }
                if (ErrorMessage != null && sp.ErrorShow == false)
                {
                    sp.ErrorShow = true;
                    ErrorMessage(8033002, ee.StackTrace, "[Base_SocketClient:StartClient]", ee.Message);
                }
            }
            finally
            {
                if (sp != null)
                {
                    if (sp.CurrentSocket != null && sp.CurrentSocket.Connected)
                    {
                        //ErrorMessage(30007, "", "[Base_SocketClient:ConnectCallback]", SocketPacketRB.IpAddress + "已连接");
                        sp.ErrorShow = false;
                        //等待接收数据
                        WaitForData(sp);
                        //其他客户端连接，异步调用请求同意方法
                        m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
                    }
                }
            }
        }
        #endregion

        #region 【等待接收数据】
        /// <summary>
        /// 等待从客户端发送过来的数据
        /// </summary>
        /// <param name="soc"></param>
        /// <param name="clientNumber"></param>
        public void WaitForData(SocketPacketRB soc)
        {
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    // 获取等待发送数据回调方法
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }
                soc.DataBuffer = new byte[soc.DataLength];
                //调用开始异步接收数据方法
                soc.CurrentSocket.BeginReceive(soc.DataBuffer, 0, soc.DataBuffer.Length, SocketFlags.None, pfnWorkerCallBack, soc);
            }
            catch (Exception se)
            {
                if (soc != null && soc.CurrentSocket!=null)
                {
                    if (ClientConnect != null)
                    {
                        ClientConnect(((IPEndPoint)soc.CurrentSocket.RemoteEndPoint).Address.ToString(), false);
                    }
                }
                if (ErrorMessage != null && soc.ErrorShow == false)
                {
                    soc.ErrorShow = false;
                    ErrorMessage(8033002, se.StackTrace, "[Base_SocketClient:StartClient]", se.Message);
                }
            }
        }
        

        /// <summary>
        /// 接收数据方法
        /// </summary>
        /// <param name="asyn"></param>
        public void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacketRB socketData = null;
            try
            {
                socketData = (SocketPacketRB)asyn.AsyncState;
                //获取异步读取得到的数据包
                int iRx = socketData.CurrentSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(socketData.DataBuffer, 0, iRx, chars, 0);

                System.String szData = new System.String(chars);

                if (DataReceivedByAddress != null)
                {
                    DataReceivedByAddress(szData, ((IPEndPoint)socketData.CurrentSocket.RemoteEndPoint).Address.ToString());

                    ////Czlt-2012-2-24 
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(8033001, "", "[Base_SocketClient:StartClient]", "已连接");
                    //}
                }
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054 && socketData.ErrorShow == false)
                {
                    socketData.ErrorShow = true;

                    //移除
                    if (socketData.CurrentSocket != null)
                    {
                        socketData.CurrentSocket.Close();
                        socketData.CurrentSocket = null;
                    }
                    m_workerSocketList.Remove(socketData);
                    //m_workerSocketList[socketData.m_clientNumber - 1] = null;

                    if (socketData != null && socketData.CurrentSocket != null)
                    {
                        if (ClientConnect != null)
                        {
                            ClientConnect(((IPEndPoint)socketData.CurrentSocket.RemoteEndPoint).Address.ToString(), false);
                        }
                    }

                    try
                    {
                        if (ErrorMessage != null)
                        {
                            ErrorMessage(8033002, se.StackTrace, "[Base_SocketClient:StartClient]", se.Message);
                        }
                    }
                    catch { }
                }
            }
            finally
            {
                if (socketData != null && socketData.CurrentSocket!=null)
                {
                    //继续等待数据
                    WaitForData(socketData);
                }
            }
        }
        #endregion

        #region 【方法：发送数据】
        /// <summary>
        /// 开始发送数据
        /// </summary>
        /// <param name="bytes">发送字节</param>
        /// <param name="strIpAddress">发送的地址</param>
        /// <param name="port">发送的端口</param>
        public void Send(byte[] bytes, string strIpAddress)
        {
            SocketPacketRB spCollect = new SocketPacketRB();
            try
            {
                for (int i = 0; i < m_workerSocketList.Count; i++)
                {
                    spCollect = (SocketPacketRB)m_workerSocketList[i];
                    if (spCollect.IpAddress.Equals(strIpAddress))
                    {
                        //开始异步发送数据
                        spCollect.CurrentSocket.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(SendCallback), spCollect);
                        break;
                    }
                }
            }
            catch (SocketException se)
            {
                try
                {
                    if (spCollect != null && spCollect.CurrentSocket != null)
                    {
                        if (ClientConnect != null)
                        {
                            ClientConnect(((IPEndPoint)spCollect.CurrentSocket.RemoteEndPoint).Address.ToString(), false);
                        }
                    }
                    if (!spCollect.IpAddress.Equals("") && spCollect.ErrorShow == false)
                    {
                        ErrorMessage(8033002, se.StackTrace, "[Base_SocketClient:Send]", spCollect.IpAddress + "未连接");
                        spCollect.ErrorShow = true;
                    }
                    if (spCollect.CurrentSocket != null)
                    {
                        spCollect.CurrentSocket.Close();
                        spCollect.CurrentSocket = null;
                    }

                }
                catch { }
            }
            catch (Exception ee)
            {
                
            }
        }

        /// <summary>
        /// 结束挂起的异步发送
        /// </summary>
        /// <param name="ar">异步操作对象</param>
        private void SendCallback(IAsyncResult ar)
        {
            SocketPacketRB sp_SendCallbace = new SocketPacketRB();
            try
            {
                sp_SendCallbace = (SocketPacketRB)ar.AsyncState;

                sp_SendCallbace.CurrentSocket.EndSend(ar);
            }
            catch (SocketException e)
            {
                try
                {
                    if (sp_SendCallbace != null && sp_SendCallbace.CurrentSocket != null)
                    {
                        if (ClientConnect != null)
                        {
                            ClientConnect(((IPEndPoint)sp_SendCallbace.CurrentSocket.RemoteEndPoint).Address.ToString(), false);
                        }
                    }
                    if (sp_SendCallbace.State == 2 && !sp_SendCallbace.IpAddress.Equals("") && sp_SendCallbace.ErrorShow == false)
                    {
                        ErrorMessage(8033002, e.StackTrace, "[Base_SocketClient:SendCallback]", sp_SendCallbace.IpAddress + "未连接");
                        sp_SendCallbace.ErrorShow = true;
                    }
                    if (sp_SendCallbace.CurrentSocket != null)
                    {
                        sp_SendCallbace.CurrentSocket.Close();
                        sp_SendCallbace.CurrentSocket = null;
                    }

                }
                catch { }
            }
            catch (Exception ee)
            {
                
            }
        }
        #endregion 【方法：发送数据】
    }
}
