using System;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using KJ128A.BatmanAPI;
using KJ128A.Controls.Batman;

namespace KJ128A.Ports
{
    /// <summary>
    /// 
    /// </summary>
    public class StartTcp
    {
        #region [ 声明:委托 ] 基站状态改变

        /// <summary>
        /// 基站状态改变声明
        /// </summary>
        public delegate void StationStateChangedEventHandler(int index, int iAddress, int iState, string strStateRemark);

        /// <summary>
        /// 基站状态改变事件
        /// </summary>
        public event StationStateChangedEventHandler StationStateChanged;

        #endregion

        #region [ 声明: 委托 ] 数据抵达

        /// <summary>
        /// 数据抵达委托声明
        /// </summary>
        /// <param name="cmdReceived"></param>
        /// <param name="iHost"></param>
        public delegate void DataReceivedEventHandler(byte[] cmdReceived, int iHost,int iGroup);

        /// <summary>
        /// 数据抵达
        /// </summary>
        public event DataReceivedEventHandler DataReceived;

        #endregion

        #region [ 声明:委托 ] 错误消息

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="index"></param>
        /// <param name="iErrNO"></param>
        /// <param name="strStackTrace"></param>
        /// <param name="Source"></param>
        /// <param name="strMessage"></param>
        public delegate void ErrorMessageEventHandler(int index, int iErrNO, string strStackTrace, string Source, string strMessage);

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

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

        #region [属性：是否是网络已经连接]
        /// <summary>
        /// 设置网络是否连接，true为未连接，false为已连接
        /// </summary>
        public bool IsNetWork
        {
            set
            {
                if (m_TcpClientPort != null)
                {
                    m_TcpClientPort.IsNetWork = value;
                }
            }
        }
        #endregion

        #region 【属性：热备是否已经在运行中】
        private bool m_RbSend;
        /// <summary>
        /// 热备运行中标志位
        /// </summary>
        public bool RbSend
        {
            get { return m_RbSend; }
            set
            {
                m_RbSend = value;
                if (m_TcpClientPort != null)
                {
                    m_TcpClientPort.RbSend = m_RbSend;
                }
            }
        }
        #endregion

        #region 【属性：本地数据库是否已经连接】
        /// <summary>
        /// 本地数据库是否已经连接
        /// </summary>
        private bool _IsDataBaseConnection;
        /// <summary>
        /// 设置本地数据库是否已经连接   true 为连接  false 为未连接
        /// </summary>
        public bool IsDataBaseConnection
        {
            get { return _IsDataBaseConnection; }
            set
            {
                _IsDataBaseConnection = value;
                if (m_TcpClientPort != null)
                {
                    m_TcpClientPort.IsDataBaseConnect = _IsDataBaseConnection;
                }
            }
        }
        #endregion

        #region 【属性：是否在存数据库】
        private bool _IsSaveSql;
        public bool IsSaveSql
        {
            get { return _IsSaveSql; }
            set
            {
                _IsSaveSql = value;
                if (m_TcpClientPort != null)
                {
                    m_TcpClientPort.IsSaveSql = _IsSaveSql;
                }
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public static KJTcpClientPort m_TcpClientPort;
        ArrayList socketArrayList = new ArrayList();

        #region [InitTcpClientPort]
        /// <summary>
        /// 初始化网络客户端连接
        /// </summary>
        /// <param name="socketPackets"></param>
        /// <param name="iMark"></param>
        public void InitTcpClientPort(SocketPacket[] socketPackets, int iMark)
        {
            InitSocket(socketPackets);

            if (socketArrayList == null)
            {
                socketArrayList = new ArrayList();
            }
            m_TcpClientPort = new KJTcpClientPort(socketArrayList, 1, iMark);
            m_TcpClientPort.DataReceived += new KJTcpClientPort.DataReceivedEventHandler(m_TcpClientPort_DataReceived);
            m_TcpClientPort.ErrorMessage += new SocketClient.ErrorMessageEventHandler(m_TcpClientPort_ErrorMessage);
            m_TcpClientPort.StationStateChanged += delegate(int index, int iAddress, int iState, string strStateRemark)
            {
                if (StationStateChanged != null)
                {
                    StationStateChanged(index, iAddress, iState, strStateRemark);
                }
            };
            m_TcpClientPort.MarkStateChanged += delegate(int index, int IsMark)
            {
                if (MarkStateChanged != null)
                {
                    MarkStateChanged(index, IsMark);
                }
            };
        }

        void m_TcpClientPort_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            ErrorMessage(1, iErrNO, strStackTrace, strSource, strMessage);
        }

        void m_TcpClientPort_DataReceived(byte[] cmdReceived, int iMark)
        {
            DataReceived(cmdReceived, iMark,1);
        }
        #endregion [InitTcpClientPort]

        #region [InitSocket]
        /// <summary>
        /// 初始化连接端口
        /// </summary>
        /// <param name="socketPackets"></param>
        /// <returns></returns>
        private bool InitSocket(SocketPacket[] socketPackets)
        {
            if (socketPackets == null || socketPackets.Length <= 0) return false;
            for (int i = 0; i < socketPackets.Length; i++)
            {
                socketArrayList.Add(socketPackets[i]);
            }

            return true;
        }
        #endregion [InitSocket]
        
        #region [方法：网络信息改变]
        public bool NetChange(SocketPacket[] socketPackets)
        {
            if (m_TcpClientPort == null) return false;
            if (socketPackets == null || socketPackets.Length <= 0)
            {
                if (socketArrayList != null && socketArrayList.Count > 0)
                {
                    m_TcpClientPort.Clean();
                    return true;
                }
            }
            else
            {
                ArrayList arrayListTemp = new ArrayList();
                ArrayList arrayListOld = m_TcpClientPort.SocketClientList;
                bool falg = false;
                if (arrayListOld != null)
                {
                    for (int k = 0; k < socketPackets.Length; k++)
                    {
                        falg = false;
                        for (int i = 0; i < arrayListOld.Count; i++)
                        {
                            SocketPacket socketTemp = (SocketPacket)arrayListOld[i];
                            if (socketPackets[k].IpAddress.Equals(socketTemp.IpAddress) && socketPackets[k].ClientPort.Equals(socketTemp.ClientPort))//数据存在
                            {
                                falg = true;
                                break;
                            }
                        }
                        //在原来数据中没有找到，则添加
                        if (!falg)
                        {
                            m_TcpClientPort.Add(socketPackets[k].IpAddress, socketPackets[k].ClientPort);
                        }
                    }

                    for (int i = 0; i < arrayListOld.Count; i++)
                    {
                        falg = false;
                        SocketPacket socketTemp = (SocketPacket)arrayListOld[i];
                        for (int k = 0; k < socketPackets.Length; k++)
                        {
                            if (socketPackets[k].IpAddress.Equals(socketTemp.IpAddress) && socketPackets[k].ClientPort.Equals(socketTemp.ClientPort))//数据存在
                            {
                                falg = true;
                                break;
                            }
                        }
                        if (!falg)//移除
                        {
                            m_TcpClientPort.Remove(socketTemp.IpAddress, socketTemp.ClientPort);
                        }
                    }
                }
                else //如果原始的为空，则添加进去
                {
                    for (int i = 0; i < socketPackets.Length; i++)
                    {
                        m_TcpClientPort.Add(socketPackets[i].IpAddress, socketPackets[i].ClientPort);
                    }
                }
            }
            return true;
        }
        #endregion

        #region [InitStation]
        /// <summary>
        /// 初始化基站信息
        /// </summary>
        /// <param name="dgStation"></param>
        /// <param name="memStation"></param>
        /// <returns></returns>
        public bool InitStation(DataGridView[] dgStation, MemStation[] memStation)
        {
            if (m_TcpClientPort == null) return false;

            ArrayList al = new ArrayList();

            // 根据串口巡检的基站组提取符合条件的基站
            for (int j = 0; j < memStation.Length; j++)
            {
                if (1 == memStation[j].Group)
                {
                    al.Add(memStation[j]);
                }
            }

            // 重新组织基站数据
            MemStation[] tmpStation = new MemStation[al.Count];
            for (int k = 0; k < al.Count; k++)
            {
                tmpStation[k] = (MemStation)al[k];

                // 初始化校对版本号命令
                if (tmpStation[k].StationModel == 1)
                {
                    tmpStation[k].CmdVersion = KJ128A.Protocol.P20071210.Version(tmpStation[k].Address, 0, m_TcpClientPort.Mark);
                }
            }

            // 更新串口中的基站数据
            m_TcpClientPort.Stations = tmpStation;
            m_TcpClientPort.TempStations = tmpStation;
            m_TcpClientPort.IsStationChange = false;

            // 更新界面显示的基站数据
            dgStation[0].Visible = false;
            dgStation[0].DataSource = m_TcpClientPort.Stations;
            dgStation[0].Visible = true;

            al = null;

            return true;
        }

        #endregion

        #region [方法：分站信息改变]
        /// <summary>
        /// 分站信息改变
        /// </summary>
        /// <param name="dgStation"></param>
        /// <param name="memStation"></param>
        /// <returns></returns>
        public bool StationChange(DataGridView[] dgStation, MemStation[] memStation)
        {
            if (m_TcpClientPort == null) return false;

            ArrayList al = new ArrayList();

            // 根据串口巡检的基站组提取符合条件的基站
            for (int j = 0; j < memStation.Length; j++)
            {
                if (1 == memStation[j].Group)
                {
                    al.Add(memStation[j]);
                }
            }

            // 重新组织基站数据
            MemStation[] tmpStation = new MemStation[al.Count];
            MemStation[] oldStations = m_TcpClientPort.Stations;
            for (int k = 0; k < al.Count; k++)
            {
                tmpStation[k] = (MemStation)al[k];
                for (int m = 0; m < oldStations.Length; m++)
                {
                    if (oldStations[m].Address == tmpStation[k].Address && oldStations[m].ID == tmpStation[k].ID && oldStations[m].IpAddress.Equals(tmpStation[k].IpAddress) && oldStations[m].Port.Equals(tmpStation[k].Port) && oldStations[m].StationModel == tmpStation[k].StationModel)
                    {
                        tmpStation[k] = oldStations[m];
                        tmpStation[k].NoAnswer = 0;
                        //tmpStation[k].State = oldStations[m].State;
                        break;
                    }
                }
                if (tmpStation[k].CmdVersion == null)
                {
                    if (tmpStation[k].StationModel == 1)
                    {
                        // 初始化校对版本号命令
                        tmpStation[k].CmdVersion = KJ128A.Protocol.P20071210.Version(tmpStation[k].Address, 0, m_TcpClientPort.Mark);
                    }
                    
                }
                if (!IsHost)
                {
                    tmpStation[k].State = -10000;
                }
                else
                {
                    tmpStation[k].State = 0;
                }
            }

            // 更新串口中的基站数据
            m_TcpClientPort.TempStations = tmpStation;
            m_TcpClientPort.IsStationChange = true;
            // 更新界面显示的基站数据
            dgStation[0].Visible = false;
            dgStation[0].DataSource = m_TcpClientPort.TempStations;
            dgStation[0].Visible = true;
            al = null;

            return true;
        }
        #endregion

        #region [ 窗体: 配置串口 ]
        /// <summary>
        /// 配置串口窗体
        /// </summary>
        /// <param name="strFilePath">串口文件存放路径</param>
        /// <param name="frm">主窗体</param>
        public static void ShowCommSetDialog(string strFilePath, IFrmMain frm)
        {
            FrmCommSet frmCommSet = new FrmCommSet(strFilePath, frm);
            frmCommSet.ShowDialog();
            frmCommSet = null;
        }
        #endregion

        #region [ 运行 ]

        /// <summary>
        /// 运行
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (m_TcpClientPort == null) return false;

            m_TcpClientPort.IsStartHostBacker = _IsStartHostBacker;
            m_TcpClientPort.IsHost = _IsHost;
            m_TcpClientPort.IsStationChange = false;
            m_TcpClientPort.IsNetChange = false;
            m_TcpClientPort.IsNetWork = true;
            //初始化数据库连接状态为未连接
            m_TcpClientPort.IsDataBaseConnect = _IsDataBaseConnection;
            //初始化为正在保存数据库
            m_TcpClientPort.IsSaveSql = false;
            m_TcpClientPort.RbSend = m_RbSend;
            if (m_TcpClientPort != null)
            {
                if (m_TcpClientPort.Stations != null)
                {
                    for (int j = 0; j < m_TcpClientPort.Stations.Length; j++)
                    {
                        if (_IsStartHostBacker)
                        {
                            if (!_IsHost)
                            {
                                m_TcpClientPort.Stations[j].State = -10000;
                            }
                        }
                    }
                }
            }

            m_TcpClientPort.RepeatStart();
            Thread.Sleep(1000);
            m_TcpClientPort.SendCmd();
            return true;
        }

        #endregion
    }
}
