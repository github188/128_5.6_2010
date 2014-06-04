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
    /// 串口启动程序
    /// </summary>
    public class StartPort
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
                if (s_serialPort != null)
                {
                    for (int i = 0; i < s_serialPort.Length; i++)
                    {
                        if (s_serialPort[i] != null)
                        {
                            s_serialPort[i].RbSend = m_RbSend;
                        }
                    }
                }
            }
        }
        #endregion

        #region [属性：是否是网络已经连接]
        /// <summary>
        /// 是否是网络已经连接
        /// </summary>
        private bool _IsNetWork;
        /// <summary>
        /// 设置网络是否连接，true为未连接，false为已连接
        /// </summary>
        public bool IsNetWork
        {
            get { return _IsNetWork; }
            set
            {
                _IsNetWork = value;
                if (s_serialPort != null)
                {
                    for (int i = 0; i < s_serialPort.Length; i++)
                    {
                        if (s_serialPort[i] != null)
                        {
                            s_serialPort[i].IsNetWork = _IsNetWork;
                        }
                    }
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
                if (s_serialPort != null)
                {
                    for (int i = 0; i < s_serialPort.Length; i++)
                    {
                        if (s_serialPort[i]!=null)
                        {
                            s_serialPort[i].IsDataBaseConnect = _IsDataBaseConnection;
                        }
                    }
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
                if (s_serialPort != null)
                {
                    for (int i = 0; i < s_serialPort.Length; i++)
                    {
                        if (s_serialPort[i] != null)
                        {
                            s_serialPort[i].IsSaveSql = _IsSaveSql;
                        }
                    }
                }
            }
        }
        #endregion

        #region [ 实例化串口 ]

        /// <summary>
        /// 串口实例数组
        /// </summary>
        public static KJSerialPort[] s_serialPort;

        #region InitSerialPort

        /// <summary>
        /// 实例化串口对象
        /// </summary>
        /// <param name="memSerialPort"></param>
        /// <returns></returns>
        public bool InitSerialPort(MemSerialPort[] memSerialPort)
        {
            if (memSerialPort != null)
            {

                // 初始化串口
                s_serialPort = new KJSerialPort[memSerialPort.Length];

                // 实例化
                for (int i = 0; i < s_serialPort.Length; i++)
                {
                    s_serialPort[i] = new KJSerialPort(i, memSerialPort[i].PortName, memSerialPort[i].Group, memSerialPort[i].Mark);
                    s_serialPort[i].ErrorMessage += new Base_SerialPort.ErrorMessageEventHandler(StartPort_ErrorMessage);
                    s_serialPort[i].DataReceived += Port_DataReceived;
                    s_serialPort[i].StationStateChanged += delegate(int index, int iAddress, int iState, string strStateRemark)
                    {
                        if (StationStateChanged != null)
                        {
                            StationStateChanged(index, iAddress, iState, strStateRemark);
                        }
                    };
                    s_serialPort[i].MarkStateChanged += delegate(int index, int IsMark)
                    {
                        if (MarkStateChanged != null)
                        {
                            MarkStateChanged(index, IsMark);
                        }
                    };
                }

                if (!(s_serialPort != null && s_serialPort.Length > 0)) return false;

                return true;
            }
            else
            {
                return false;
            }
        }

        private void StartPort_ErrorMessage(int index, int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(index, iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        private void Port_DataReceived(byte[] cmdReceived, int iMark,int iGroup)
        {
            if (DataReceived != null)
            {
                DataReceived(cmdReceived, iMark,iGroup);
            }
        }

        #endregion

        #region InitStation

        /// <summary>
        /// 初始化基站信息
        /// </summary>
        /// <param name="dgStation"></param>
        /// <param name="memStation"></param>
        /// <returns></returns>
        public bool InitStation(DataGridView[] dgStation, MemStation[] memStation)
        {
            if (!(s_serialPort != null && s_serialPort.Length > 0)) return false;

            if (memStation == null || memStation.Length <= 0) return false;

            for (int i = 0; i < s_serialPort.Length; i++)
            {
                ArrayList al = new ArrayList();

                // 根据串口巡检的基站组提取符合条件的基站
                for (int j = 0; j < memStation.Length; j++)
                {
                    if (s_serialPort[i].Group == memStation[j].Group)
                    {
                        al.Add(memStation[j]);
                    }
                }

                // 重新组织基站数据
                MemStation[] tmpStation = new MemStation[al.Count];
                for (int k = 0; k < al.Count; k++)
                {
                    tmpStation[k] = (MemStation)al[k];

                    if (tmpStation[k].StationModel == 1 || tmpStation[k].StationModel == 3)
                    {
                        // 初始化校对版本号命令
                        tmpStation[k].CmdVersion = KJ128A.Protocol.P20071210.Version(tmpStation[k].Address, 0, s_serialPort[i].Mark);
                    }
                }

                // 更新串口中的基站数据
                s_serialPort[i].Stations = tmpStation;
                s_serialPort[i].TempStations = tmpStation;
                s_serialPort[i].IsStationChange = false;
                // 更新界面显示的基站数据
                dgStation[i].Visible = false;
                dgStation[i].DataSource = s_serialPort[i].TempStations;
                dgStation[i].Visible = true;
                al = null;
            }

            return true;
        }

        /// <summary>
        /// 分站信息改变
        /// </summary>
        /// <param name="dgStation"></param>
        /// <param name="memStation"></param>
        /// <returns></returns>
        public bool StationChange(DataGridView[] dgStation, MemStation[] memStation)
        {
            if (!(s_serialPort != null && s_serialPort.Length > 0)) return false;

            for (int i = 0; i < s_serialPort.Length; i++)
            {
                ArrayList al = new ArrayList();

                // 根据串口巡检的基站组提取符合条件的基站
                for (int j = 0; j < memStation.Length; j++)
                {
                    if (s_serialPort[i].Group == memStation[j].Group)
                    {
                        al.Add(memStation[j]);
                    }
                }

                // 重新组织基站数据
                MemStation[] tmpStation = new MemStation[al.Count];
                MemStation[] oldStations = s_serialPort[i].Stations;
                for (int k = 0; k < al.Count; k++)
                {
                    tmpStation[k] = (MemStation)al[k];
                    if (oldStations != null)
                    {
                        for (int m = 0; m < oldStations.Length; m++)
                        {
                            if (oldStations[m].Address == tmpStation[k].Address && oldStations[m].ID == tmpStation[k].ID && oldStations[m].StationModel == tmpStation[k].StationModel)
                            {
                                tmpStation[k] = oldStations[m];
                                tmpStation[k].NoAnswer = 0;
                                break;
                            }
                        }
                    }
                    if (tmpStation[k].CmdVersion == null)
                    {
                        if (tmpStation[k].StationModel == 1 || tmpStation[k].StationModel == 3)
                        {
                            // 初始化校对版本号命令
                            tmpStation[k].CmdVersion = KJ128A.Protocol.P20071210.Version(tmpStation[k].Address, 0, s_serialPort[i].Mark);
                        }
                    }

                    if (!IsHost)
                    {
                        tmpStation[k].State = -10000;
                        //if (tmpStation[k].State != -10000)
                        //{
                        //    tmpStation[k].State = 0;
                        //}
                        //else
                        //{
                            
                        //}
                    }
                    else
                    {
                        tmpStation[k].State = 0;
                    }
                }

                // 更新串口中的基站数据
                s_serialPort[i].TempStations = tmpStation;
                s_serialPort[i].IsStationChange = true;
                // 更新界面显示的基站数据
                dgStation[i].Visible = false;
                dgStation[i].DataSource = s_serialPort[i].TempStations;
                dgStation[i].Visible = true;
                al = null;
            }

            return true;
        }

        #endregion
        
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
            if (s_serialPort == null || s_serialPort.Length == 0) return false;

            for (int i = 0; i < s_serialPort.Length; i++)
            {
                s_serialPort[i].IsStartHostBacker = _IsStartHostBacker;
                s_serialPort[i].IsHost = _IsHost;
                //初始化分站改变状态为未改变
                s_serialPort[i].IsStationChange = false;
                //初始化热备网络连接为未连接
                s_serialPort[i].IsNetWork = _IsNetWork;
                //初始化数据库连接状态为未连接
                s_serialPort[i].IsDataBaseConnect = _IsDataBaseConnection;
                //初始化为正在保存数据库
                s_serialPort[i].IsSaveSql = false;
                s_serialPort[i].RbSend = m_RbSend;
                if (s_serialPort[i] != null)
                {
                    if (s_serialPort[i].Stations != null)
                    {
                        for (int j = 0; j < s_serialPort[i].Stations.Length; j++)
                        {
                            if (_IsStartHostBacker)
                            {
                                if (!_IsHost)
                                {
                                    s_serialPort[i].Stations[j].State = -10000;
                                }
                            }
                        }
                    }
                    s_serialPort[i].Open();
                    s_serialPort[i].SendCmd();
                }
            }
            return true;
        }

        #endregion

    }
}
