using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Timers;
using KJ128A.BatmanAPI;

namespace KJ128A.Controls.Batman
{
    /// <summary>
    /// socket客户端操作类
    /// </summary>
    public class SocketClient
    {
        #region 【属性：原始数据】
        private KJRichTextBox _RTxtMsgo = null;
        /// <summary>
        /// 原始数据
        /// </summary>
        public KJRichTextBox RTxtMsgo
        {
            get { return _RTxtMsgo; }
            set { _RTxtMsgo = value; }
        }
        #endregion 【属性：原始数据】

        #region 【属性：热备标志位】
        private int _Mark;
        /// <summary>
        /// 标志位
        /// </summary>
        public int Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }

        #endregion 【属性：热备标志位】

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

        #region 【自定义变量】
        /// <summary>
        /// TCP/IP客户端连接对象
        /// </summary>
        private Base_SocketClient baseSocketClient;
        /// <summary>
        /// 数据缓冲区的大小
        /// </summary>
        protected static int iBufferSize = 2048;
        /// <summary>
        /// 当前缓冲区的指针
        /// </summary>
        protected int iCurLoc = 0;
        /// <summary>
        /// 数据缓冲区
        /// </summary>
        protected byte[] byteBuffer = new byte[iBufferSize];
        /// <summary>
        /// 发送时间
        /// </summary>
        protected int sendTime = 660;

        /// <summary>
        /// Czlt-2011-03-23 - 通讯程序停止再次发送
        /// </summary>
        //protected Timer sendAgainTime = new Timer();
        #endregion 【自定义变量】

        #region 【构造函数】
        /// <summary>
        /// 构造客户端连接对象
        /// </summary>
        /// <param name="socketArrayList">客户端连接列表</param>
        public SocketClient(ArrayList socketArrayList)
        {
            LoadSendTimeFile();
            if (baseSocketClient == null)
            {
                baseSocketClient = new Base_SocketClient(socketArrayList);
                baseSocketClient.DataReceivedByAddress += new Base_SocketClient.DataReceivedEventHandler(baseSocketClient_DataReceivedByAddress);
                baseSocketClient.ErrorMessage += new Base_SocketClient.ErrorMessageEventHandler(baseSocketClient_ErrorMessage);
                // 时间事件及触发间隔
                timer.Interval = sendTime;
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);


            }

            #region 【Czlt-2010-11-29 双向通讯定时器】
            timer_Call.Interval = 1800000;
            timer_Call.Elapsed += new ElapsedEventHandler(timer_Call_Elapsed);
            timer_Call.Enabled = false;
            #endregion

            //#region 【Czlt-2011-03-23 通讯程序关闭后一分钟内再次重启】
            //sendAgainTime.Interval = 60000;
            //sendAgainTime.Elapsed += new ElapsedEventHandler(sendAgainTime_Elapsed);
            //#endregion

        }

        /// <summary>
        /// 再次发送数据信息的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void sendAgainTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (timer.Enabled == false)
            {
                timer.Start();
                //sendAgainTime.Stop();
            }
        }
        #endregion 【构造函数】

        #region 【事件生成：错误消息】
        private void baseSocketClient_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
        }
        #endregion 【事件生成：错误消息】

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

        #region 【事件实现：接收数据】
        /// <summary>
        /// TCP/IP客户端接收数据
        /// </summary>
        /// <param name="bytes">接收到字符串</param>
        /// <param name="strAddress">发送数据的远程主机的IP地址</param>
        public virtual void baseSocketClient_DataReceivedByAddress(byte[] bytes, string strAddress)
        {
            if (timer.Enabled == true)
            {
                timer.Enabled = false;
            }
            try
            {
                // 接收缓冲区中数据的字节数
                int int_Len = bytes.Length;
                if (RTxtMsgo != null)
                {
                    RTxtMsgo.WriteTxt(bytes, "RX", true, 0);
                }

                // 缓冲区溢出
                if (iCurLoc + int_Len > iBufferSize)
                {
                    iCurLoc = 0;
                    return;
                }

                // 将数据存入缓冲区
                for (int i = 0; i < int_Len; i++)
                {
                    byteBuffer[iCurLoc + i] = bytes[i];
                }

                bytes = null;

                // 修改当前指针的位置
                iCurLoc += int_Len;
            }
            catch 
            {
                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                }
            }
            finally
            {
                
            }
        }
        #endregion 【事件实现：接收数据】

        #region [ 属性 ] 间隔时间

        private double _Interval;

        /// <summary>
        /// 获取或设置间隔时间
        /// </summary>
        public double Interval
        {
            get
            {
                _Interval = timer.Interval;
                return _Interval;
            }
            set
            {
                timer.Interval = value;
                _Interval = value;
            }
        }

        #endregion

        #region [ 事件: 时间 ]

        /// <summary>
        /// 串口收发数据的计时器
        /// </summary>
        protected readonly Timer timer = new Timer();

        /// <summary>
        /// 时间控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void timer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }

        #endregion

        #region 【方法：加载发送时间】
        /// <summary>
        /// 加载发送时间文件
        /// </summary>
        private void LoadSendTimeFile()
        {
            //创建
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\SendTime.xml"))
            {
                try
                {
                    FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\SendTime.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<SendTime>");
                    sw.WriteLine("<send>1200</send>");
                    sw.WriteLine("</SendTime>");
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                catch { }
            }
            else
            {
                XmlDocument xmldocument = new XmlDocument();
                try
                {
                    //加载
                    xmldocument.Load(Directory.GetCurrentDirectory() + "\\SendTime.xml");
                    XmlNode node = xmldocument.SelectSingleNode("SendTime/send");
                    sendTime = int.Parse(node.InnerText);
                }
                catch
                {
                    sendTime = 1200;
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

        #region 【方法：发送数据】
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="bytes">发送字节</param>
        /// <param name="strIpAddress">远程主机网络地址</param>
        /// <param name="port">远程主机侦听端口</param>
        public void Send(byte[] bytes, string strIpAddress, int port)
        {
            try
            {
                baseSocketClient.Send(bytes, strIpAddress, port);
            }
            catch
            { }
            finally
            {
                //Czlt-2011-03-23 - 通讯停止再次启动
                //if (sendAgainTime.Enabled)
                //    sendAgainTime.Start();
                timer.Enabled = true;
            }
        }
        #endregion 【方法：发送数据】

        #region 【方法：添加一个远程连接地址】
        /// <summary>
        /// 添加远程连接
        /// </summary>
        /// <param name="strIpAddress">远程连接地址</param>
        /// <param name="port">远程连接端口</param>
        public void Add(string strIpAddress, int port)
        {
            baseSocketClient.Add(strIpAddress, port);
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
            baseSocketClient.Remove(strIpAddress, port);
        }
        #endregion 【方法：移除一个远程连接地址】

        #region 【方法：清空所有数据资源】
        /// <summary>
        /// 清空所有数据资源
        /// </summary>
        public void Clean()
        {
            baseSocketClient.Clean();
        }
        #endregion 【方法：清空所有数据资源】

        #region 【Czlt-2010-11-29】
        /// <summary>
        /// 时间-定时取消双向通讯
        /// </summary>
        protected Timer timer_Call = new Timer();

        /// <summary>
        /// 时间控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void timer_Call_Elapsed(object sender, ElapsedEventArgs e)
        {


        }
        #endregion
    }
}
