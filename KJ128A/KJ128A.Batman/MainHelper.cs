using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using KJ128A.HostBack;
using KJ128A.BatmanAPI;
using KJ128A.Ports;
using KJ128A.Controls.Batman;

namespace KJ128A.Batman
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public class MainHelper
    {

        /* 
         * 基站配置信息
         */
        private static bool _commType = false;

        #region [ 属性: 串口信息 ]

        private static MemSerialPort[] _memSerialPort;

        /// <summary>
        /// 串口信息
        /// </summary>
        public static MemSerialPort[] memSerialPort
        {
            get { return _memSerialPort; }
            set { _memSerialPort = value; }
        }

        #endregion

        #region [属性：网络数据配置]
        private static SocketPacket[] _socketPacket;
        /// <summary>
        /// 网络数据配置
        /// </summary>
        public static SocketPacket[] SocketPackets
        {
            get { return _socketPacket; }
            set { _socketPacket = value; }
        }
        #endregion

        #region [ 属性: 基站信息 ]

        private static MemStation[] _memStation;

        /// <summary>
        /// 基站信息
        /// </summary>
        public static MemStation[] memStation
        {
            get { return _memStation; }
            set { _memStation = value; }
        }

        #endregion

        #region [自定义参数]
        /// <summary>
        /// 分站信息保存路径
        /// </summary>
        private static string strStationSavePath;
        /// <summary>
        /// 网络配置信息保存路径
        /// </summary>
        private static string strTcpIpSavePath;
        #endregion

        #region [ 集合: 基站 ]

        /// <summary>
        /// 加载基站信息
        /// </summary>
        /// <param name="strPath">基站文件保存的路径</param>
        /// <returns></returns>
        public static bool StationLoad(string strPath)
        {
            DataTable dtStation = BuildStationTable();
            strStationSavePath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strPath;
            try
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strPath))
                {
                    try
                    {
                        dtStation.ReadXml(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strPath);
                    }
                    catch (Exception ee)
                    {
                        string str = ee.Message;
                    }
                    int iStationCount = dtStation.Rows.Count;
                    _memStation = new MemStation[iStationCount];

                    for (int i = 0; i < iStationCount; i++)
                    {
                        DataRow dr = dtStation.Rows[i];

                        _memStation[i].ID = int.Parse(dr["ID"].ToString());
                        _memStation[i].Address = int.Parse(dr["Address"].ToString());
                        _memStation[i].Group = int.Parse(dr["Group"].ToString());
                        _memStation[i].State = int.Parse(dr["State"].ToString());
                        _memStation[i].Ver = int.Parse(dr["Ver"].ToString());
                        if (dr["IpAddress"] != null)
                        {
                            _memStation[i].IpAddress = dr["IpAddress"].ToString();
                        }
                        if (dr["IpPort"] != null)
                        {
                            _memStation[i].Port = int.Parse(dr["IpPort"].ToString());
                        }
                        _memStation[i].StationModel = int.Parse(dr["StationModel"].ToString());
                        _memStation[i].IsPointSelect = false;
                        _memStation[i].IsTwo = false;
                    }
                }
                else
                {
                    _memStation = new MemStation[0];
                }
            }
            catch
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + strPath))
                {
                    File.Delete(Directory.GetCurrentDirectory() + "\\" + strPath);
                }
                //创建station.xml文件
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + strPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                sw.WriteLine("<DocumentElement>");
                sw.WriteLine("</DocumentElement>");
                sw.Flush();
                sw.Close();
                sw.Dispose();
                fs.Close();
                fs.Dispose();
                return false;
            }
            finally
            {
                // 释放表格对象
                dtStation.Dispose();
            }

            return true;
        }
 
        /// <summary>
        /// 开始定时更新基站
        /// </summary>
        /// <param name="sqlSave">从数据库中取出的基站数据</param>
        /// <param name="commType">通讯模式</param>
        /// <param name="strPath">station.xml文件路径</param>
        /// <param name="configPath">所设置的间隔时间</param>
        public static void StartStationUpdateTimer(HostBack.DataSave sqlSave,bool commType, string strPath, string configPath)
        {
            StationUpdateTimer stationUpdateTime = new StationUpdateTimer(sqlSave,commType, strPath, configPath, memStation);
            stationUpdateTime.StartTimer();
            stationUpdateTime.StationInfoChange += new StationUpdateTimer.StationInfoChangeEventHandler(stationUpdateTime_StationInfoChange);
        }

        /// <summary>
        /// 分站信息改变
        /// </summary>
        static void stationUpdateTime_StationInfoChange()
        {
            DataTable dtStation = BuildStationTable();
            try
            {
                //新的分站表数据
                dtStation.ReadXml(strStationSavePath);

                int iStationCount = dtStation.Rows.Count;
                MemStation[] _memStationTemp = new MemStation[iStationCount];
                //构建新的分站表数据
                for (int i = 0; i < iStationCount; i++)
                {
                    DataRow dr = dtStation.Rows[i];

                    _memStationTemp[i].ID = int.Parse(dr["ID"].ToString());
                    _memStationTemp[i].Address = int.Parse(dr["Address"].ToString());
                    _memStationTemp[i].Group = int.Parse(dr["Group"].ToString());
                    _memStationTemp[i].State = int.Parse(dr["State"].ToString());
                    _memStationTemp[i].Ver = int.Parse(dr["Ver"].ToString());
                    if (dr["IpAddress"] != null)
                    {
                        _memStationTemp[i].IpAddress = dr["IpAddress"].ToString();
                    }
                    if (dr["IpPort"] != null)
                    {
                        _memStationTemp[i].Port = int.Parse(dr["IpPort"].ToString());
                    }
                    _memStationTemp[i].StationModel = int.Parse(dr["StationModel"].ToString());
                    _memStationTemp[i].IsPointSelect = false;
                    _memStationTemp[i].IsTwo = false;
                }

                //通知信息改变
                if (!_commType)
                {
                    _port.StationChange(dgStation, _memStationTemp);
                }
                else
                {
                    _startTcp.StationChange(dgStation, _memStationTemp);
                }
            }
            catch
            {
            }
            finally
            {
                // 释放表格对象
                dtStation.Dispose();
            }
        }
        
        /// <summary>
        /// 构建 Station 表格
        /// </summary>
        /// <returns></returns>
        private static DataTable BuildStationTable()
        {
            DataTable dtStation = new DataTable("Station");

            DataColumn dcID = new DataColumn("ID", typeof(int));
            dtStation.Columns.Add(dcID);

            DataColumn dcAddress = new DataColumn("Address", typeof(int));
            dtStation.Columns.Add(dcAddress);

            DataColumn dcGroup = new DataColumn("Group", typeof(int));
            dtStation.Columns.Add(dcGroup);

            DataColumn dcState = new DataColumn("State", typeof(int));
            dtStation.Columns.Add(dcState);

            DataColumn dcMark = new DataColumn("Mark", typeof(int));
            dtStation.Columns.Add(dcMark);

            DataColumn dcVer = new DataColumn("Ver", typeof(int));
            dtStation.Columns.Add(dcVer);

            DataColumn dcIpAddress = new DataColumn("IpAddress", typeof(string));
            dtStation.Columns.Add(dcIpAddress);

            DataColumn dcPort = new DataColumn("IpPort", typeof(int));
            dtStation.Columns.Add(dcPort);

            DataColumn dcStationModel = new DataColumn("StationModel", typeof(int));
            dtStation.Columns.Add(dcStationModel);

            return dtStation;
        }

        #endregion

        #region 【静态方法：加载网络连接集合】
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostBacker"></param>
        /// <param name="strPath"></param>
        /// <param name="configPath"></param>
        public static void StartTcpUpdateTime(HostBack.DataSave sqlSave, string strPath, string configPath)
        {
            TcpClientUpdateTimer tcpClinetUpdateTime = new TcpClientUpdateTimer(sqlSave, strPath, configPath, SocketPackets);
            tcpClinetUpdateTime.StartTimer();
            tcpClinetUpdateTime.NetInfoChange += new TcpClientUpdateTimer.NetInfoChangeEventHandler(tcpClinetUpdateTime_NetInfoChange);
        }

        /// <summary>
        /// 网络信息改变了
        /// </summary>
        static void tcpClinetUpdateTime_NetInfoChange()
        {
            DataTable dtTcpServer = BuildTcpServers();
            try
            {
                dtTcpServer.ReadXml(strTcpIpSavePath);
                int iTcpServerCount = dtTcpServer.Rows.Count;
                _socketPacket = new SocketPacket[iTcpServerCount];
                for (int i = 0; i < iTcpServerCount; i++)
                {
                    DataRow dr = dtTcpServer.Rows[i];
                    _socketPacket[i] = new SocketPacket();
                    _socketPacket[i].ID = int.Parse(dr["IPID"].ToString());
                    _socketPacket[i].IpAddress = dr["IpAddress"].ToString();
                    _socketPacket[i].ClientPort = int.Parse(dr["IpPort"].ToString());
                }
                if (_commType)
                {
                    _startTcp.NetChange(_socketPacket);
                }
            }
            catch
            {
            }
            finally
            {
                dtTcpServer.Dispose();
                dtTcpServer = null;
            }
        }

        /// <summary>
        /// 加载网络配置信息
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static bool TcpServersLoad(string strPath)
        {
            DataTable dtTcpServer = BuildTcpServers();
            strTcpIpSavePath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strPath;
            bool falg;
            try
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strPath))
                {
                    dtTcpServer.ReadXml(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strPath);
                    int iTcpServerCount = dtTcpServer.Rows.Count;
                    _socketPacket = new SocketPacket[iTcpServerCount];
                    for (int i = 0; i < iTcpServerCount; i++)
                    {
                        DataRow dr = dtTcpServer.Rows[i];
                        _socketPacket[i] = new SocketPacket();
                        _socketPacket[i].ID = int.Parse(dr["ipID"].ToString());
                        _socketPacket[i].IpAddress = dr["IpAddress"].ToString();
                        _socketPacket[i].ClientPort = int.Parse(dr["IpPort"].ToString());
                    }
                }
                else
                {
                    _socketPacket = new SocketPacket[0];
                }
                falg = true;
            }
            catch
            {
                falg = false;
            }
            finally
            {
                dtTcpServer.Dispose();
                dtTcpServer = null;
            }
            return falg;
        }

        private static DataTable BuildTcpServers()
        {
            DataTable dtTcpServer = new DataTable("TcpIpConfig");

            DataColumn dcID = new DataColumn("ipID", typeof(int));
            dtTcpServer.Columns.Add(dcID);

            DataColumn dcIpAddress = new DataColumn("IpAddress", typeof(string));
            dtTcpServer.Columns.Add(dcIpAddress);

            DataColumn dcPort = new DataColumn("IpPort", typeof(int));
            dtTcpServer.Columns.Add(dcPort);

            return dtTcpServer;
        }
        #endregion 【静态方法：加载网络连接集合】

        #region [ 集合: 串口 ]

        /// <summary>
        /// 加载串口信息
        /// </summary>
        /// <param name="strPath">串口文件保存的路径</param>
        /// <returns></returns>
        public static bool SerialPortLoad(string strPath)
        {
            DataTable dtSerialPort = BuildSerialPortTable();

            try
            {
                dtSerialPort.ReadXml(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strPath);      // 从文件中加载串口信息

                // 将串口信息存入 MemSerialPort 数组中
                int iSerialCount = dtSerialPort.Rows.Count;
                _memSerialPort = new MemSerialPort[iSerialCount];

                for (int i = 0; i < iSerialCount; i++)
                {
                    DataRow dr = dtSerialPort.Rows[i];

                    _memSerialPort[i].ID = int.Parse(dr[0].ToString());
                    _memSerialPort[i].PortName = dr[1].ToString();
                    _memSerialPort[i].Group = int.Parse(dr[2].ToString());
                    _memSerialPort[i].Mark = int.Parse(dr[3].ToString());
                }
            }
            catch
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strPath))
                {
                    File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strPath);
                }

                try
                {
                    //创建station.xml文件
                    FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + strPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<DocumentElement>");
                    sw.WriteLine("<SerialPort>");
                    sw.WriteLine("<ID>1</ID>");
                    sw.WriteLine("<PortName>COM1</PortName>");
                    sw.WriteLine("<Group>1</Group>");
                    sw.WriteLine("<Mark>1</Mark>");
                    sw.WriteLine("<IsEnable>true</IsEnable>");
                    sw.WriteLine("</SerialPort>");
                    sw.WriteLine("</DocumentElement>");
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                catch { }

                _memSerialPort = new MemSerialPort[1];
                _memSerialPort[0].ID = 1;
                _memSerialPort[0].PortName = "COM1";
                _memSerialPort[0].Group = 1;
                _memSerialPort[0].Mark = 1;
                return false;
            }
            finally
            {
                // 释放表格对象
                dtSerialPort.Dispose();
            }

            return true;
        }

        /// <summary>
        /// 构建 SerialPort 表格
        /// </summary>
        /// <returns></returns>
        private static DataTable BuildSerialPortTable()
        {
            DataTable dtSerialPort = new DataTable("SerialPort");

            DataColumn dcID = new DataColumn("ID", typeof(int));
            dtSerialPort.Columns.Add(dcID);

            DataColumn dcPortName = new DataColumn("PortName", typeof(string));
            dtSerialPort.Columns.Add(dcPortName);

            DataColumn dcGroup = new DataColumn("Group", typeof(int));
            dtSerialPort.Columns.Add(dcGroup);

            DataColumn dcMark = new DataColumn("Mark", typeof(int));
            dtSerialPort.Columns.Add(dcMark);

            return dtSerialPort;
        }

        #endregion

        /*
         * 界面布局
         */

        #region [ 声明 ]

        /// <summary>
        /// 基站面板对象
        /// </summary>
        public static DGStation[] dgStation;

        private static KJRichTextBox _RtxtSysMsg;    // 系统消息

        private static KJRichTextBox[] rtxtMsg;     // 标准消息面板
        private static KJRichTextBox[] rtxtMsgo;    // 原始回送数据面板
        private static KJRichTextBox[] rtxtMsge;    // 错误消息面板
        private static KJRichTextBox[] rtxtMsgc;    // 中文数据面版

        private static MenuHelper menuHelper_Main = null;
        private static MenuHelper menuHelper_Notify = null;

        #endregion

        #region [ 界面: 布局 ]

        private readonly static GroupBox gbBox = new GroupBox();
        private readonly static TabControl tcMsg = new TabControl();

        /// <summary>
        /// 加载界面布局
        /// </summary>
        /// <returns></returns>
        public static bool LoadFaceLayout(FrmMain frmMain, KJRichTextBox rtxtSysMsg)
        {
            _RtxtSysMsg = rtxtSysMsg;

            // 加载数据面板
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            //pnl.BackColor = System.Drawing.Color.YellowGreen;
            frmMain.Controls.Add(pnl);

            #region [ 数据面板: 加载系统消息面板 ]

            // 加载数据面板中的内容

            tcMsg.Dock = DockStyle.Fill;

            rtxtSysMsg.Visible = false;
            pnl.Controls.Add(rtxtSysMsg);

            // 系统消息面板
            //TabPage tpSysMsg = new TabPage("系统消息");
            //rtxtSysMsg.Dock = DockStyle.Fill;
            //tpSysMsg.Controls.Add(rtxtSysMsg);
            //tcMsg.Controls.Add(tpSysMsg);

            pnl.Controls.Add(tcMsg);

            #endregion

            // 加载传输分站面板
            gbBox.Text = "被巡检的传输分站信息";
            gbBox.Dock = DockStyle.Left;
            gbBox.Width = 175;
            frmMain.Controls.Add(gbBox);

            return true;
        }

        #endregion

        #region [ 界面: 基站面板 ]

        /// <summary>
        /// 加载基站面板
        /// </summary>
        /// <param name="frm">窗体对象</param>
        /// <returns></returns>
        public static bool LoadFaceStationPanel(IFrmMain frm, bool CommType)
        {
            if (CommType)
            {
                dgStation = new DGStation[1];
                dgStation[0] = new DGStation(0, frm);
                // 加载基站信息
                TabControl tcStation = new TabControl();
                tcStation.Dock = DockStyle.Fill;

                // 初始化 TabPage
                TabPage tpStation = new TabPage("环网");
                tcStation.Controls.Add(tpStation);

                // 加载 DataGrid
                tpStation.Controls.Add(dgStation[0]);

                gbBox.Controls.Add(tcStation);
            }
            else
            {
                if (memSerialPort != null)
                {
                    // 根据串口数量构建创建面板的数量
                    int iSerialPortLength = memSerialPort.Length;
                    dgStation = new DGStation[iSerialPortLength];

                    // 根据串口数量实例化基站信息
                    for (int i = 0; i < iSerialPortLength; i++)
                    {
                        dgStation[i] = new DGStation(i, frm);
                    }

                    // 加载基站信息
                    TabControl tcStation = new TabControl();
                    tcStation.Dock = DockStyle.Fill;

                    for (int i = 0; i < iSerialPortLength; i++)
                    {
                        // 初始化 TabPage
                        TabPage tpStation = new TabPage(memSerialPort[i].PortName);
                        tcStation.Controls.Add(tpStation);

                        // 加载 DataGrid
                        tpStation.Controls.Add(dgStation[i]);
                    }

                    gbBox.Controls.Add(tcStation);
                }
            }
            return true;
        }

        #endregion

        #region [ 界面: 数据面板 ]

        /// <summary>
        /// 加载数据面板
        /// </summary>
        /// <returns></returns>
        public static bool LoadFaceDataPanel(bool commType)
        {
            if (commType)
            {
                rtxtMsg = new KJRichTextBox[1];
                rtxtMsgo = new KJRichTextBox[1];
                rtxtMsgc = new KJRichTextBox[1];
                //rtxtMsge = new KJRichTextBox[1];

                // 标准数据面板
                TabPage tpSerialPort = new TabPage("环网");

                rtxtMsg[0] = new KJRichTextBox("CriterionData_" + 0);
                rtxtMsg[0].ReadOnly = true;
                rtxtMsg[0].Dock = DockStyle.Fill;
                tpSerialPort.Controls.Add(rtxtMsg[0]);

                tcMsg.Controls.Add(tpSerialPort);

                // 中文数据面版
                TabPage tpSerialPortC = new TabPage("环网(c)");

                rtxtMsgc[0] = new KJRichTextBox("ChineseData_" + 0);
                rtxtMsgc[0].ReadOnly = true;
                rtxtMsgc[0].Dock = DockStyle.Fill;
                tpSerialPortC.Controls.Add(rtxtMsgc[0]);

                tcMsg.Controls.Add(tpSerialPortC);

                // 原始回送数据面板
                TabPage tpSerialPortO = new TabPage("环网(o)");

                rtxtMsgo[0] = new KJRichTextBox("OrgData_" + 0);
                rtxtMsgo[0].ReadOnly = true;
                rtxtMsgo[0].Dock = DockStyle.Fill;
                tpSerialPortO.Controls.Add(rtxtMsgo[0]);

                tcMsg.Controls.Add(tpSerialPortO);

                // 错误数据面板
                //TabPage tpSerialPortE = new TabPage("环网(e)");

                //rtxtMsge[0] = new KJRichTextBox("ErrData_" + 0);
                //rtxtMsge[0].ReadOnly = true;
                //rtxtMsge[0].Dock = DockStyle.Fill;
                //tpSerialPortE.Controls.Add(rtxtMsge[0]);

                //tcMsg.Controls.Add(tpSerialPortE);

            }
            else
            {
                if (memSerialPort != null)
                {
                    // 根据串口数量构建创建面板的数量
                    int iSerialPortLength = memSerialPort.Length;

                    rtxtMsg = new KJRichTextBox[iSerialPortLength];
                    rtxtMsgo = new KJRichTextBox[iSerialPortLength];
                    rtxtMsgc = new KJRichTextBox[iSerialPortLength];
                    rtxtMsge = new KJRichTextBox[iSerialPortLength];

                    for (int i = 0; i < iSerialPortLength; i++)
                    {
                        // 标准数据面板
                        TabPage tpSerialPort = new TabPage(memSerialPort[i].PortName);

                        rtxtMsg[i] = new KJRichTextBox("CriterionData_" + i);
                        rtxtMsg[i].ReadOnly = true;
                        rtxtMsg[i].Dock = DockStyle.Fill;
                        tpSerialPort.Controls.Add(rtxtMsg[i]);

                        tcMsg.Controls.Add(tpSerialPort);

                        // 中文数据面版
                        TabPage tpSerialPortC = new TabPage(memSerialPort[i].PortName + "(c)");

                        rtxtMsgc[i] = new KJRichTextBox("ChineseData_" + i);
                        rtxtMsgc[i].ReadOnly = true;
                        rtxtMsgc[i].Dock = DockStyle.Fill;
                        tpSerialPortC.Controls.Add(rtxtMsgc[i]);

                        tcMsg.Controls.Add(tpSerialPortC);

                        // 原始回送数据面板
                        TabPage tpSerialPortO = new TabPage(memSerialPort[i].PortName + "(o)");

                        rtxtMsgo[i] = new KJRichTextBox("OrgData_" + i);
                        rtxtMsgo[i].ReadOnly = true;
                        rtxtMsgo[i].Dock = DockStyle.Fill;
                        tpSerialPortO.Controls.Add(rtxtMsgo[i]);

                        tcMsg.Controls.Add(tpSerialPortO);

                        // 错误数据面板
                        //TabPage tpSerialPortE = new TabPage(memSerialPort[i].PortName + "(e)");

                        //rtxtMsge[i] = new KJRichTextBox("ErrData_" + i);
                        //rtxtMsge[i].ReadOnly = true;
                        //rtxtMsge[i].Dock = DockStyle.Fill;

                        //tpSerialPortE.Controls.Add(rtxtMsge[i]);

                        //tcMsg.Controls.Add(tpSerialPortE);
                    }
                }
            }
            return true;
        }

        #endregion

        #region [ 界面: 消息面板 ]

        /// <summary>
        /// 加载消息面板
        /// </summary>
        /// <returns></returns>
        public static bool InitMsgPanel(bool commType)
        {
            if (!commType)
            {
                if (rtxtMsg != null && StartPort.s_serialPort != null)
                {
                    for (int i = 0; i < rtxtMsg.Length; i++)
                    {
                        StartPort.s_serialPort[i].RTxtMsgo = rtxtMsgo[i];    // 原始数据面板
                        StartPort.s_serialPort[i].RTxtMsg = rtxtMsg[i];      // 标准数据面板
                        //StartPort.s_serialPort[i].RTxtMsge = rtxtMsge[i];    // 错误数据面板
                        StartPort.s_serialPort[i].RTxtMsgc = rtxtMsgc[i];    // 中文数据面板
                    }
                }
            }
            else
            {
                if (rtxtMsg != null && StartTcp.m_TcpClientPort != null)
                {
                    StartTcp.m_TcpClientPort.RTxtMsgo = rtxtMsgo[0];// 原始数据面板
                    StartTcp.m_TcpClientPort.RTxtMsg = rtxtMsg[0];      // 标准数据面板
                    //StartTcp.m_TcpClientPort.RTxtMsge = rtxtMsge[0];    // 错误数据面板
                    StartTcp.m_TcpClientPort.RTxtMsgc = rtxtMsgc[0];    // 中文数据面板
                }
            }
            return true;
        }

        #endregion

        #region [ 界面: 菜单面板 ]

        /// <summary>
        /// 加载主窗体菜单
        /// </summary>
        /// <param name="frmMain"></param>
        /// <returns></returns>
        public static bool LoadMenuPanel(FrmMain frmMain)
        {
            // 加载主菜单
            MenuStrip menuStrip = new MenuStrip();

            menuHelper_Main = new MenuHelper(frmMain, menuStrip);

            frmMain.Controls.Add(menuStrip);

            // 返回
            return true;
        }

        static void menuHelper_Main_ErrorMessage(int iErrNO, string strStackTrace, string Source, string strMessage)
        {
            
            //ErrorMessage(iErrNO, strStackTrace, Source, strMessage);
        }

        /// <summary>
        /// 加载主窗体菜单
        /// </summary>
        /// <param name="frmMain"></param>
        /// <param name="notifyIcon"></param>
        /// <returns></returns>
        public  static bool LoadNotifyMenu(FrmMain frmMain, NotifyIcon notifyIcon)
        {

            // 加载任务栏菜单
            ContextMenuStrip menuNotify = new ContextMenuStrip();

            menuHelper_Notify = new MenuHelper(frmMain, menuNotify);

            notifyIcon.ContextMenuStrip = menuNotify;   // 菜单
            notifyIcon.Text = frmMain.Text;             // 标题
            notifyIcon.Visible = true;                  // 显示
            
            // 事件: 双击 隐藏/显示窗体
            notifyIcon.DoubleClick += delegate {
                if (frmMain.WindowState != FormWindowState.Minimized)
                {
                    frmMain.WindowState = FormWindowState.Minimized;
                    frmMain.Visible = false;
                }
                else
                {
                    frmMain.WindowState = FormWindowState.Maximized;
                    frmMain.Visible = true;
                    frmMain.Activate();
                }                                  
            };

            return true;
        }

        #endregion

        

        #region [环网：初始化]
        private static StartTcp _startTcp = null;
        /// <summary>
        /// 环网初始化
        /// </summary>
        /// <param name="port"></param>
        /// <param name="iMark"></param>
        /// <param name="commType"></param>
        /// <returns></returns>
        public static bool InitNetPort(StartTcp port, int iMark,bool commType)
        {
            _startTcp = port;
            _commType = commType;
            //实例化网络对象
            port.InitTcpClientPort(SocketPackets, iMark);

            port.InitStation(dgStation, memStation);

            // 初始化功能菜单
            menuHelper_Main.MenuSyncFunction(_RtxtSysMsg);
            menuHelper_Notify.MenuSyncFunction(_RtxtSysMsg);
            return true;
        }
        #endregion [环网：初始化]

        /*
         * 串口程序调用
         */

        #region [ 串口: 初始化 ]
        private static StartPort _port = null;
        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool InitSerialPort(StartPort port,bool commType)
        {
            _port = port;
            _commType = commType;
            // 实例化串口对象
            port.InitSerialPort(memSerialPort);

            // 将基站信息传递给串口
            port.InitStation(dgStation, memStation);

            // 初始化功能菜单
            menuHelper_Main.MenuSyncFunction(_RtxtSysMsg);
            menuHelper_Notify.MenuSyncFunction(_RtxtSysMsg);
            return true;
        }

        #endregion

        /*
         * 
         */

        #region [ 菜单: 禁用 ]

        /// <summary>
        /// 权限变更
        /// </summary>
        /// <param name="enumPower"></param>
        public static void MenuPowerChange(EnumPowers enumPower)
        {
            menuHelper_Main.MenuPowerChange(enumPower);
            menuHelper_Notify.MenuPowerChange(enumPower);
        }

        #endregion


        #region [ 方法: 构建 Login 表格 ]

        /// <summary>
        /// 构建 Login 表格
        /// </summary>
        /// <returns></returns>
        public static DataTable BuildLoginTable()
        {
            // 创建登录信息表
            DataTable dtLogin = new DataTable();
            dtLogin.TableName = "Login";

            // 创建表格中的列
            DataColumn colAccount = new DataColumn("Account", typeof(string));
            dtLogin.Columns.Add(colAccount);

            DataColumn colPwd = new DataColumn("Password", typeof(string));
            dtLogin.Columns.Add(colPwd);

            DataColumn colCompetence = new DataColumn("Competence", typeof(int));
            dtLogin.Columns.Add(colCompetence);

            // 返回表格对象
            return dtLogin;
        }

        #endregion

        #region [ 方法: 构建 DBConfig 表格 ]

        /// <summary>
        /// 创建一个配置信息表格
        /// </summary>
        /// <param name="strTableName">表名</param>
        /// <returns></returns>
        public static DataTable BuildDBConfigTable(string strTableName)
        {
            DataTable dt = new DataTable(strTableName);

            dt.Columns.Add(new DataColumn("ID"));
            dt.Columns.Add(new DataColumn("serverName"));
            dt.Columns.Add(new DataColumn("bWindows"));
            dt.Columns.Add(new DataColumn("Uid"));
            dt.Columns.Add(new DataColumn("Psw"));
            dt.Columns.Add(new DataColumn("DataBase"));

            return dt;
        }

        #endregion


    }
}
