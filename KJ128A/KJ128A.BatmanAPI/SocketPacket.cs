using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;

namespace KJ128A.Controls.Batman
{
    /// <summary>
    /// 网络连接数据包
    /// </summary>
    public class SocketPacket
    {
        /// <summary>
        /// 客户端连接套接字
        /// </summary>
        private Socket m_currentSocket;
        /// <summary>
        /// 获取或设置客户端连接
        /// </summary>
        public Socket CurrentSocket
        {
            get { return m_currentSocket; }
            set { m_currentSocket = value; }
        }

        private static int m_dataLength = 2048;

        /// <summary>
        /// 获取数据长度
        /// </summary>
        public int DataLength
        {
            get { return m_dataLength; }
        }
        //从客户端接收到的字符串
        private byte[] m_dataBuffer = new byte[m_dataLength];
        /// <summary>
        /// 获取或设置从客户端接收到的字符串
        /// </summary>
        public byte[] DataBuffer
        {
            get { return m_dataBuffer; }
            set { m_dataBuffer = value; }
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string m_IpAddress;
        /// <summary>
        /// 获取或设置远程地址
        /// </summary>
        public string IpAddress
        {
            get { return m_IpAddress; }
            set { m_IpAddress = value; }
        }

        private int m_clientPort;
        /// <summary>
        /// 获取或设置远程连接端口
        /// </summary>
        public int ClientPort
        {
            get { return m_clientPort; }
            set { m_clientPort = value; }
        }

        private int m_state;
        /// <summary>
        /// 获取或设置连接状态
        /// </summary>
        public int State
        {
            get { return m_state; }
            set { m_state = value; }
        }

        private bool m_errorShow;
        /// <summary>
        /// 错误故障显示
        /// </summary>
        public bool ErrorShow
        {
            get { return m_errorShow; }
            set { m_errorShow = value; }
        }


        private int reviceCount ;
        public int ReviceCount 
        {
            get { return reviceCount; }
            set { reviceCount = value; }
        }
        /// <summary>
        /// 构造客户端连接套接字
        /// </summary>
        public SocketPacket()
        { }

    }
}
