using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using KJ128A.BatmanAPI;
using KJ128A.Controls.Batman;
using KJ128A.DataSave;
using KJ128A.HostBack;
using KJ128A.Ports;
using System.Collections.Generic;
using CustomUIControls;
using System.Drawing;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace KJ128A.Batman
{
    public partial class FrmMain : Form, IFrmMain
    {

        #region [ 声明 ]

        private readonly StartPort startPort = new StartPort();     // 串口应用程序
        private readonly StartTcp startTcp = new StartTcp();
        //private  InterfaceSerialPort dataSave = null;                 // 数据保存程序

        private readonly KJRichTextBox rtxtSysMsg = new KJRichTextBox("System");     // 系统消息面板

        private HostBacker hostBacker = new HostBacker();          // 热备程序

        private HostBack.DataSave sqlSave = new KJ128A.HostBack.DataSave();
        Ping ping = new Ping();

        //Czlt-2010-12-20        
        private string strHostPath = string.Empty;

        /// <summary>
        /// sql连接错误
        /// </summary>
        private static int _SQLerrCount = 0;

        string strPortSign = string.Empty;

        ErrorWriter eWriter = new ErrorWriter();              //错误日志类



        /// <summary>
        /// 通讯方式  false 串口  true 网络
        /// </summary>
        public bool commType = false;
        public bool GetCommType()
        {
            return commType;
        }
        private int tcpMark = 1;

        private bool RBSend = false;

        private System.Timers.Timer tConn = new System.Timers.Timer();

        private System.Timers.Timer t1second = new System.Timers.Timer();

        private System.Timers.Timer czltCallTime = new System.Timers.Timer();

        //Czlt-2011-01-26
        DataWrite dtw = new DataWrite(@"D:\DataBase\Test", Encoding.Default);
        string strByte = string.Empty;
        private int czltCount = 0;
        private bool isOk = true;
        private int czltCurrentIndex = 10;

        /// <summary>
        /// Czlt-2012-3-28 每次执行的次数,每100秒刷一次列表
        /// </summary>
        private int czltStationIndex = 0;

        /// <summary>
        /// Czlt-2012-3-28 传输分站的总数
        /// </summary>
        private int czltStaNum = 0;


        #region【Czlt-2011-08-11 双向通讯】
        /// <summary>
        /// 待呼叫的标识卡数组
        /// </summary>
        private int[] _Cards;
        /// <summary>
        /// 双向通讯广播分站命令
        /// </summary>
        private int[] _Order;

        /// <summary>
        /// 判断是否都呼
        /// </summary>
        private bool czltIsCall = false;
        /// <summary>
        /// Czlt-2011-08-17
        /// </summary>
        private Dictionary<int, string> czltGroup = new Dictionary<int, string>();

        KJ128A.Controls.GetCardInfo czltGetCard = new KJ128A.Controls.GetCardInfo();
        /// <summary>
        /// Czlt-2011-08-10 双通次数
        /// </summary>
        private int czltIndex = 0;

        /// <summary>
        /// Czlt-2011-08-10 总的巡检次数
        /// </summary>
        private int czltSum = 180;
        private int czltStopTime = 1;

        string skOutCard;
        #endregion


       // TaskbarNotifier czltNotifier = null;
        int index = 0;

        /// <summary>
        /// 清理内存的计数器
        /// </summary>
        int indexGC = 0;
        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            if (Directory.Exists(@"tmp"))
            {
                string[] strtempFile = Directory.GetFiles(@"tmp");

                if (strtempFile.Length > 0)
                {
                    try
                    {
                        foreach (string strTemp in strtempFile)
                        {
                            try
                            {
                                string strLogTmp = strTemp.Substring(strTemp.IndexOf("$") + 1);
                                strLogTmp = strLogTmp.Replace("_tmp", "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second);
                                string strDir = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                                if (!Directory.Exists(@"log\" + strDir))
                                {
                                    Directory.CreateDirectory(@"log\" + strDir);
                                }

                                File.Copy(strTemp, @"log\" + strDir + "\\" + strLogTmp, true);
                            }
                            catch
                            { }
                        }
                    }
                    catch { }
                }
            }

            WindowState = FormWindowState.Minimized;    // 窗体最大化
            startTcp.ErrorMessage += startTcp_ErrorMessage;
            //startTcp.ErrorMessage += new StartTcp.ErrorMessageEventHandler(startTcp_ErrorMessage);
            startPort.ErrorMessage += startPort_ErrorMessage;
            //startPort.StationStateChanged += startPort_StationStateChanged;
            startPort.StationStateChanged += new StartPort.StationStateChangedEventHandler(startPort_StationStateChanged);
            startTcp.StationStateChanged += new StartTcp.StationStateChangedEventHandler(startTcp_StationStateChanged);
            startPort.DataReceived += startPort_DataReceived;
            startTcp.DataReceived += startPort_DataReceived;
            startPort.MarkStateChanged += new StartPort.MarkStateChangedEventHandler(startPort_MarkStateChanged);
            startTcp.MarkStateChanged += new StartTcp.MarkStateChangedEventHandler(startPort_MarkStateChanged);

            //错误委托
            hostBacker.ErrorMessage += ErrorMessage;
            sqlSave.ErrorMessage += ErrorMessage;

            //DataBaseManage dbManage = new DataBaseManage();
            //try
            //{
            //    dbManage.DBDelete();
            //}
            //catch { }
            //if (dbManage != null)
            //{
            //    dbManage.Dispose();
            //    dbManage = null;
            //}
            //// 赵建伟热备程序
            //hostBacker.InitHostBacker(IsHost, IpAddress, SendPort, ListenPort);
            //accInter.ErrorMessage += new AccessInterface.ErrorMessageEventHandler(accInter_ErrorMessage);
            //accInter.ShowMessage += new AccessInterface.ShowMessageEventHandler(accInter_ShowMessage);
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = KJ128NInterfaceShow.RefReshTime._rtTime;
            t.Tick += new EventHandler(t_Tick);
            t.Start();

            tConn.AutoReset = true;
            tConn.Interval = 10000;
            tConn.Elapsed += new System.Timers.ElapsedEventHandler(tConn_Elapsed);

            t1second.Interval = 10000;
            //t1second.Tick += new System.EventHandler(this.t1second_Tick);
            t1second.Elapsed += new System.Timers.ElapsedEventHandler(t1second_Elapsed);

            czltCallTime.Interval = 1200;
            czltCallTime.Elapsed += new System.Timers.ElapsedEventHandler(czltCallTime_Tick);

        }

        //void t1second_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        void tConn_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //判断数据库是否存在
                sqlSave.IsConnect();
            }
            catch { }
        }

        void startTcp_ErrorMessage(int index, int iErrNO, string strStackTrace, string Source, string strMessage)
        {
            string strError = string.Empty;
            strError = strMessage;
            if (strError != string.Empty)
            {
                if (iErrNO != 0 && iErrNO != 30007)
                {
                    rtxtSysMsg.WriteTxt(strError, " [ 错误信息 ]", true, System.Drawing.Color.Red);
                }
                else
                {
                    rtxtSysMsg.WriteTxt(strError, " [ 提示信息 ]", true, System.Drawing.Color.Blue);
                }
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            GC.Collect(0);
            //this.WindowState = FormWindowState.Minimized;
            //this.OnResize(e);
            //this.WindowState = FormWindowState.Maximized;
            //this.OnResize(e);
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]

        private static extern bool SetProcessWorkingSetSize(

            IntPtr process,

            int minSize,

            int maxSize);



        private static void FlushMemory()
        {

            GC.Collect();

            GC.WaitForPendingFinalizers();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)

                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);

        }

        void startPort_MarkStateChanged(int index, int IsMark)
        {
            //MessageBox.Show("工作状态" + IsMark.ToString());
            hostBacker.SwitchHostBack(IsMark);
        }

        private delegate void SetStationShowCallback(int index);
        private void SetStationShow(int index)
        {
            try
            {
                if (MainHelper.dgStation[index].InvokeRequired)
                {
                    SetStationShowCallback d = new SetStationShowCallback(SetStationShow);
                    MainHelper.dgStation[index].Invoke(d, new object[] { index });
                }
                else
                {
                    try
                    {
                        MainHelper.dgStation[index].Visible = false;
                        MainHelper.dgStation[index].DataSource = StartPort.s_serialPort[index].TempStations;
                        MainHelper.dgStation[index].Visible = true;
                        MainHelper.dgStation[index].Show();
                    }
                    catch
                    { }
                }
            }
            catch { }
        }

        private delegate void SetStationShowTcpCallback();
        private void SetStationShowTcp()
        {
            if (MainHelper.dgStation[0].InvokeRequired)
            {
                SetStationShowTcpCallback d = new SetStationShowTcpCallback(SetStationShowTcp);
                MainHelper.dgStation[0].Invoke(d);
            }
            else
            {
                try
                {
                    MainHelper.dgStation[0].Visible = false;
                    MainHelper.dgStation[0].DataSource = StartTcp.m_TcpClientPort.TempStations;
                    MainHelper.dgStation[0].Visible = true;
                }
                catch
                { }
            }
        }

        void startPort_StationStateChanged(int index, int iAddress, int iState, string strStateRemark)
        {
            Station_ChangeState(index, iAddress, (EnumStationState)iState);
            SetStationShow(index);
        }

        void startTcp_StationStateChanged(int index, int iAddress, int iState, string strStateRemark)
        {
            Station_ChangeState(iAddress, (EnumStationState)iState);
            SetStationShowTcp();
        }

        private void dataSave_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
        }

        private void startPort_ErrorMessage(int index, int iErrNO, string strStackTrace, string Source, string strMessage)
        {
            string strError = string.Empty;
            strError = strMessage;
            if (strError != string.Empty)
            {
                if (iErrNO != 0)
                {
                    if (rtxtSysMsg != null)
                    {
                        rtxtSysMsg.WriteTxt(strError, " [ 错误信息 ]", true, System.Drawing.Color.Red);
                    }
                }
                else
                {
                    if (rtxtSysMsg != null)
                    {
                        rtxtSysMsg.WriteTxt(strError, " [ 提示信息 ]", true, System.Drawing.Color.Black);
                    }
                }
            }
        }


        // 测试用
        void accInter_ShowMessage(string strMessage, bool bIsRecord)
        {
            //MessageBox.Show(strMessage);
        }

        void accInter_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            //MessageBox.Show(strMessage);
        }

        #endregion

        #region [ 声明:委托 ] 错误消息事件

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        public void ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            // 状态栏处理
            StateManage(iErrNO);

            if (strMessage != "" && iErrNO != 8020001)
                this.eWriter.MonthErrorWriter("信息编号:" + iErrNO.ToString() + "\t堆栈帧:" + strStackTrace + "\t程序段:" + strSource + "\t信息内容:" + strMessage);

            string strErrMsg = string.Empty;

            string strError = string.Empty;

            #region [ 二级错误 ]

            if (iErrNO >= 2000000 && iErrNO < 3000000)
            {
                switch (iErrNO)
                {

                    #region SQL Server数据库同步操作

                    case 2023048:
                        strErrMsg = "SqlServer连接失败";
                        break;
                    case 2021504:
                        strErrMsg = "数据库不存在或无法访问";
                        break;

                    #endregion

                    #region 网络传输

                    case 2100003:
                        strErrMsg = "指定IP无效";
                        break;
                    case 2100048:
                        strErrMsg = "端口已被占用";
                        break;
                    #endregion

                    default: break;
                }
            }

            #endregion

            #region [ 三级错误 ]

            if (iErrNO >= 3000000 && iErrNO < 4000000)
            {
                // 弹出消息框提示
                switch (iErrNO)
                {
                    #region FrmChangePwd

                    case 3010001:       // FrmChangePwd
                        strErrMsg = "密码未按要求填写完整.";
                        break;

                    case 3010002:
                        strErrMsg = "新设密码和验证密码不一致.";
                        break;

                    case 3010003:
                        strErrMsg = "帐号 [ " + strMessage + " ] 登录时密码不正确.";
                        break;

                    case 3010004:
                        strErrMsg = "帐号 [ " + strMessage + " ] 的密码修改成功.";
                        break;

                    case 3010005:
                        strErrMsg = "加载文件 [ " + strMessage + " ] 失败, 请检查文件格式是否符合规则.";
                        break;

                    case 3010006:
                        strErrMsg = "加载文件 [ " + strMessage + " ] 失败, 请检查文件是否存在.";
                        break;

                    case 3010007:   // FrmLogin
                        strErrMsg = "请输入用户名和密码.";
                        break;

                    case 3010008:
                        strErrMsg = "帐号 [ " + strMessage + " ] 不存在.";
                        break;

                    case 3010009:
                        strErrMsg = "帐号 [ " + strMessage + " ] 的密码错误.";
                        break;

                    #endregion

                    // FrmDBSet
                    case 3010010:   // 连接数据库失败
                    case 3010011:   // 加载服务器中所有数据库名失败
                        strErrMsg = strMessage;
                        break;

                    case 3010012:
                        strErrMsg = "主备机不可共有一台服务器, 请重新配置.";
                        break;


                    default:
                        break;
                }

                MessageBox.Show(strErrMsg);
            }

            #endregion

            #region [ 四级错误 ]

            if (iErrNO >= 4000000 && iErrNO < 5000000)
            {
                switch (iErrNO)
                {

                    #region 磁盘剩余容量检测

                    case 4020001:
                        strError = "注意：系统已经帮您清理出一些磁盘空间，为保证程序的正确运行请您尽快大量清理磁盘！";
                        break;
                    case 4020002:
                        strError = "注意：磁盘空间不足200M，请尽快清理磁盘！当磁盘容量小于100M时，我们将强制清理磁盘！";
                        break;
                    #endregion

                    #region 文件操作

                    case 4020003:
                        strError = "Interop.MSAdodcLib.Modle.dll( 数据库模板 ）文件被删除！";
                        break;

                    #endregion

                    default:
                        break;
                }
                MessageBox.Show(strErrMsg);
            }

            #endregion

            #region [ 五级错误 ]

            if (iErrNO >= 5000000 && iErrNO < 6000000)
            {


            }

            #endregion

            #region [ 六级错误 ]

            if (iErrNO >= 6000000 && iErrNO < 7000000)
            {
                switch (iErrNO)
                {
                    #region Access数据库操作

                    case 6020001:
                        strError = "连接Access数据库失败，原因：" + strMessage;
                        break;
                    case 6020004:
                        strError = "无法获取AccessDB文件夹下所有数据库的名称，原因为：" + strMessage;
                        break;
                    case 6020006:
                        strError = "向Access数据库中插入数据出错，原因为：" + strMessage;
                        break;
                    case 6020010:
                        strError = "关闭Access数据库连接失败，原因：" + strMessage;
                        break;
                    case 6020011:
                        strError = "查询Access数据库中的数据出错，原因：" + strMessage;
                        break;
                    case 6020012:
                        strError = "更改Access数据库中的数据出错，原因：" + strMessage;
                        break;
                    case 6020014:
                        strError = strMessage;
                        break;
                    case 6020015:
                        strError = strMessage;
                        break;

                    #endregion

                    #region SQL数据库操作

                    case 6020007:
                        if (_SQLerrCount == 0)
                        {
                            strError = "连接SQL数据库失败，接发命令停止，原因：" + strMessage;
                        }
                        _SQLerrCount = 1;
                        break;
                    case 6020008:
                        if (_SQLerrCount == 0)
                        {
                            strError = "执行SQL存储过程失败，接发命令停止，原因：" + strMessage;
                        }
                        _SQLerrCount = 1;
                        break;
                    case 6020009:
                        if (_SQLerrCount == 0)
                        {
                            strError = "关闭SQL数据库连接失败，接发命令停止，原因：" + strMessage;
                        }
                        _SQLerrCount = 1;
                        break;

                    #endregion

                    #region  文件操作

                    case 6020002:
                        strError = "无法创建新的Access数据库，原因：" + strMessage;
                        break;
                    case 6020005:
                        strError = "无法取消文件的只读属性，原因为：" + strMessage;
                        break;
                    case 6020013:
                        strError = "无法删除数据库文件，原因为：" + strMessage;
                        break;
                    #endregion

                    #region 存主数据库操作

                    case 6031001:
                        strError = "存主数据库线程出错,错误原因: " + strMessage;
                        break;
                    case 6031002:
                        strError = "处理同步中数据失败,错误原因: " + strMessage;
                        break;
                    case 6031003:
                        strError = "存检测信息(主数据库)失败,错误原因: " + strMessage;
                        break;
                    case 6031005:
                        strError = "关闭DataSave线程失败,错误原因: " + strMessage;
                        break;
                    case 6031006:
                        strError = strMessage;
                        break;
                    case 6031007:
                        strError = "解析命令(主数据库)出错,错误原因: " + strMessage;
                        break;

                    #endregion

                    #region 存备数据库操作

                    case 6032001:
                        strError = "存备数据库线程出错,错误原因: " + strMessage;
                        break;
                    case 6032002:
                        strError = "解析命令(备数据库)出错,错误原因: " + strMessage;
                        break;
                    case 6032003:
                        strError = "存检测信息(备数据库)失败,错误原因: " + strMessage;
                        break;
                    case 6032004:
                        strError = "关闭DataSaveBackUp线程失败,错误原因: " + strMessage;
                        break;
                    case 6032005:
                        strError = strMessage;
                        break;
                    case 6032006:
                        strError = "存传输分站状态(备数据库)失败,错误原因: " + strMessage;
                        break;

                    #endregion

                    #region 发送、监听数据操作

                    case 6033001:
                        strError = "发送数据线程出错,错误原因: " + strMessage;
                        break;
                    case 6033002:
                        strError = "发送数据出错,错误原因: " + strMessage;
                        break;
                    case 6033003:
                        strError = "结束发送数据线程出错,错误原因: " + strMessage;
                        break;
                    case 6033004:
                        strError = "监听得到的数据出错,错误原因: " + strMessage;
                        break;
                    case 6033005:
                        strError = "初次被连接事件出错,错误原因: " + strMessage;
                        break;
                    case 6033006:
                        strError = "初次断网事件出错,错误原因: " + strMessage;
                        break;
                    case 6033007:
                        strError = strMessage;
                        break;
                    #endregion

                    #region 热备接口操作

                    case 6034001:
                        strError = "初始化热备程序出错,错误原因: " + strMessage;
                        break;
                    case 6034002:
                        strError = "初始化非热备程序出错,错误原因: " + strMessage;
                        break;
                    case 6034003:
                        strError = "退出HostBacker出错,错误原因: " + strMessage;
                        break;

                    #endregion

                    #region 网络传输

                    case 6100002:
                        strError = "发送数据不能为空";
                        break;

                    #endregion

                    default:
                        break;
                }
                //if (strError != "")
                //    this.eWriter.MonthErrorWriter("信息编号:" + iErrNO.ToString() + "\t堆栈帧:" + strStackTrace + "\t程序段:" + strSource + "\t信息内容:" + strError);
            }

            #endregion

            #region [ 七级错误 ]
            string strTmp = string.Empty;
            if (iErrNO >= 7000000 && iErrNO < 8000000)
            {
                switch (iErrNO)
                {
                    case 7100053:
                        strTmp = "远程机器断开连接";
                        break;
                    case 7100054:
                        strTmp = "远程机器断开连接";   //远程主机强迫关闭了一个现有的连接
                        break;
                    case 7100057:
                        strTmp = "发送或接收数据的请求没有被接受";
                        break;
                    case 7100060:
                        strTmp = "连接超时远程机器连接失败";
                        break;
                    case 7100061:
                        strTmp = "通讯机器未开启";
                        break;
                    case 7100065:
                        strTmp = "网络不通或程序未开启";
                        break;
                    default:
                        break;
                }
                //if (strTmp != "")
                //    this.eWriter.MonthErrorWriter(strTmp);
            }
            #endregion

            #region [ 八级消息提示 ]

            if (iErrNO >= 8000000 && iErrNO < 9000000)
            {
                switch (iErrNO)
                {
                    // FrmDBSet
                    case 8010010:
                        strErrMsg = "数据库连接成功. 服务器名 [ " + strMessage + " ]. ";
                        break;

                    case 8010011:
                        strErrMsg = "数据库配置保存成功. 服务器名 [ " + strMessage + " ]. ";
                        break;

                    //FrmHostIP
                    case 8010013:
                        strErrMsg = strMessage;
                        break;

                    // FrmLogin
                    case 8010020:
                        strErrMsg = "帐号 [ " + strMessage + " ] 登录成功";
                        break;

                    #region 发送、监听数据操作

                    case 8033001:
                        strErrMsg = "网络连接成功 对方IP地址:" + IpAddress + " 对方电脑监听端口号:" + ListenPort;
                        break;

                    case 8033002:
                        strErrMsg = "网络断开 对方IP地址:" + IpAddress + " 对方电脑监听端口号:" + ListenPort;
                        break;

                    case 8033003:
                        strErrMsg = "正在切换备数据库";
                        break;

                    case 8033004:
                        strErrMsg = "切换备数据成功，开始使用备数据库";
                        break;

                    case 8033005:
                        strErrMsg = strMessage;
                        break;

                    case 8033006:
                        strErrMsg = strMessage;
                        break;

                    case 8033007:
                        strErrMsg = strMessage;
                        break;

                    #endregion

                    #region 热备接口操作

                    case 8034001:
                        strErrMsg = "切换主数据库失败,失败原因为:正在切换成备数据库!";
                        break;
                    case 8034002:
                        strErrMsg = "切换成备数据库成功,开始使用备数据库!";
                        break;
                    case 8034003:
                        strErrMsg = "开始切换备数据库!";
                        notifyIcon1.ShowBalloonTip(5000, "热备切换", "热备切换中，KJ128系统将自动重启，请稍后！", ToolTipIcon.Info);
                        break;
                    case 8034004:
                        strErrMsg = "切换数据库失败,原因:上次切换未完成!";
                        break;
                    case 8034005:
                        strErrMsg = "切换成主数据库成功,开始使用主数据库!";
                        break;
                    case 8034006://开始切换主数据库
                        strErrMsg = "开始切换主数据库!";
                        notifyIcon1.ShowBalloonTip(5000, "热备切换", "热备切换中，KJ128系统将自动重启，请稍后！", ToolTipIcon.Info);
                        break;
                    #endregion

                    default:
                        break;
                }
                //if(strErrMsg!="")
                //    this.eWriter.MonthErrorWriter("信息编号:" + iErrNO.ToString() + "\t堆栈帧:" + strStackTrace + "\t程序段:" + strSource +"\t信息内容:"+ strErrMsg);
            }

            #endregion

            if (strErrMsg != string.Empty)
            {
                rtxtSysMsg.WriteTxt(strErrMsg, " [ 提示信息 ]", true, System.Drawing.Color.Black);
            }
            if (strError != string.Empty)
            {
                rtxtSysMsg.WriteTxt(strError, " [ 错误信息 ]", true, System.Drawing.Color.Black);
            }
        }

        #endregion

        #region [ 属性: 是否主机 ]
        private bool IsStartHost;
        private bool IsHost;
        private string IpAddress;
        private int ListenPort;

        #endregion

        #region [ 属性: 登录名 ]

        private string _LoginName;

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get { return _LoginName; }
            set { _LoginName = value; }
        }

        #endregion

        #region 【方法：加载通讯方式文件】
        /// <summary>
        /// 加载通讯方式文件
        /// </summary>
        /// <returns></returns>
        private bool LoadCommType()
        {
            try
            {
                if (!File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml"))
                {
                    //创建
                    FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<comm>");
                    sw.WriteLine("<commType>0</commType>");
                    sw.WriteLine("<TcpMark>1</TcpMark>");
                    sw.WriteLine("</comm>");
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }

                XmlDocument xmlDocument = new XmlDocument();
                try
                {
                    xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml");
                    XmlNode node = xmlDocument.SelectSingleNode("/comm/commType");
                    if (node.InnerText != "" && node.InnerText.Equals("1") == true)
                    {
                        commType = true;
                    }
                    else
                    {
                        commType = false;
                    }
                    XmlNode tcpMarkNode = xmlDocument.SelectSingleNode("/comm/TcpMark");
                    if (tcpMarkNode.InnerText != "" && commType == true)
                    {
                        try
                        {
                            tcpMark = int.Parse(tcpMarkNode.InnerText);
                        }
                        catch { tcpMark = 1; }
                    }
                    else
                    {
                        tcpMark = 1;
                    }
                }
                catch
                {
                    commType = false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion 【方法：加载通讯方式文件】

        #region [ 事件: 窗体加载 ]

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            SysMessage("系统启动...");

            if (File.Exists(Directory.GetCurrentDirectory() + "\\SwitchDatabase.xml"))
            {
                try
                {
                    File.Delete(Directory.GetCurrentDirectory() + "\\SwitchDatabase.xml");
                }
                catch { }
            }

            #region [创建文件夹]
            string destFileName1;
            string strAccessPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB";
            if (!Directory.Exists(strAccessPath))
            {
                Directory.CreateDirectory(strAccessPath);
            }
            destFileName1 = strAccessPath + @"\config";     //配置信息文件
            if (!Directory.Exists(destFileName1))
            {
                Directory.CreateDirectory(destFileName1);
            }
            //创建Config目录
            string strConfig = System.Windows.Forms.Application.StartupPath.ToString() + @"\Config";
            try
            {
                if (!Directory.Exists(strConfig))
                {
                    Directory.CreateDirectory(strConfig);
                }
            }
            catch { }

            #endregion

            #region [ 检测时间 ]

            // 检测系统时间
            if (DateTime.Now < new DateTime(2008, 1, 10))
            {
                ErrorMessage(21, true, true);
            }

            #endregion

            #region [加载通讯方式文件]
            SysMessage("加载：通讯方式文件");
            if (!LoadCommType())
            {
                ErrorMessage(32, false, false);
            }
            #endregion [加载通讯方式文件]

            #region [ 加载配置文件 ]
            if (commType)
            {
                SysMessage("加载：环网配置文件");
                if (!MainHelper.TcpServersLoad("TcpServer.xml"))
                {
                    ErrorMessage(31, false, false);
                }
            }
            else
            {
                // 加载配置文件: 串口信息
                SysMessage("加载: 串口配置文件. ");
                if (!MainHelper.SerialPortLoad("SerialPort.xml"))
                {
                    ErrorMessage(22, false, false);
                }
            }
            // 加载配置文件: 基站信息
            SysMessage("加载: 传输分站配置文件. ");
            if (!MainHelper.StationLoad("Station.xml"))
            {
                ErrorMessage(23, false, false);
            }

            #endregion

            #region [ 加载界面 ]

            // 加载: 数据面板（及数据面板中的系统消息面板）、基站面板、菜单面板
            SysMessage("加载: 界面布局.");
            rtxtSysMsg.ReadOnly = true;
            if (!MainHelper.LoadFaceLayout(this, rtxtSysMsg))
            {
                ErrorMessage(24, true, true);
            }

            // 加载: 基站面板
            SysMessage("加载: 传输分站面板.");
            if (!MainHelper.LoadFaceStationPanel(this, commType))
            {
                MessageBox.Show("传输分站面板加载失败. ");
            }

            // 加载: 消息面板
            SysMessage("加载: 消息面板.");
            if (!MainHelper.LoadFaceDataPanel(commType))
            {
                MessageBox.Show("消息面板加载失败.");
            }

            // 加载: 菜单面板
            SysMessage("加载: 菜单面板.");
            if (!MainHelper.LoadMenuPanel(this))
            {
                MessageBox.Show("菜单面板加载失败.");
            }

            // 加载: 任务栏面板
            SysMessage("加载: 任务栏面板.");
            if (!MainHelper.LoadNotifyMenu(this, notifyIcon1))
            {
                MessageBox.Show("菜单面板加载失败.");
            }

            #endregion

            #region [ 串口: 初始化 ]
            if (commType)
            {
                //初始化网络端口
                MainHelper.InitNetPort(startTcp, tcpMark, commType);

                SysMessage("环网应用程序加载成功");
            }
            else
            {
                // 初始化串口
                MainHelper.InitSerialPort(startPort, commType);
                SysMessage("串口应用程序加载成功");
            }
            #endregion

            #region [ 加载消息面板 ]

            // 加载: 消息面板
            if (!MainHelper.InitMsgPanel(commType))
            {
                MessageBox.Show("消息面板加载失败.");
            }

            #endregion

            //开启每秒检测的定时器
            t1second.Start();
            czltCurrentIndex = 0;
            //IsChkSqlSP4();

            //Czlt-2011-12-26
            //CzltSaveChkXml(false);


            //隐藏后事件
            //czltNotifier.CzltEvent += new EventHandler(czltNotifier_CzltEvent);
            ///初始化弹出的窗体
            //LoadNotifier();

            //***********Czlt-2012-3-28 - 分站的个数赋值*Start*********************
            DataTable czltDt = GetStationTable();
            if (czltDt != null)
            {
                czltStaNum = czltDt.Rows.Count;
            }
            //***********Czlt-2012-3-28 - 分站的个数赋值*End*********************
        }



        #endregion

        #region [ 消息: SysMessage ]

        /// <summary>
        /// 系统消息
        /// </summary>
        /// <param name="strMsg">需要显示的消息</param>
        private void SysMessage(string strMsg)
        {
            if (rtxtSysMsg != null)
            {
                rtxtSysMsg.WriteTxt(strMsg, " [ 系统消息 ]", true, System.Drawing.Color.Black);
            }
        }

        #endregion

        #region [ 消息: ErrorMessage ]

        /// <summary>
        /// 发生错误时退出应用程序
        /// </summary>
        /// <param name="strErrMsg">错误消息</param>
        /// <param name="isShowMsgBox">是否在 MessageBox 中显示</param>
        /// <param name="isExit">是否退出</param>
        public void ErrorMessage(string strErrMsg, bool isShowMsgBox, bool isExit)
        {
            // 将错误消息显示到面板上。
            //rtxtSysMsg.SelectionColor = Color.Red;
            if (rtxtSysMsg != null)
            {
                rtxtSysMsg.WriteTxt(strErrMsg, " [ 系统消息 ]", true, System.Drawing.Color.Black);
            }
            //rtxtSysMsg.SelectionColor = Color.Black;

            // 是否以 MessageBox 的形式提示错误
            if (isShowMsgBox)
            {
                MessageBox.Show(strErrMsg);
            }

            // 退出应用程序
            if (isExit)
            {
                Exit();
            }
        }

        /// <summary>
        /// 发生错误时退出应用程序
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="isShowMsgBox">是否在 MessageBox 中显示</param>
        /// <param name="isExit">是否退出</param>
        public void ErrorMessage(int iErrNO, bool isShowMsgBox, bool isExit)
        {
            string strErrMsg = string.Empty;        // 错误消息内容

            switch (iErrNO)
            {
                case 21:
                    strErrMsg = "你的系统时间不正确，程序无法正常运行，请先更改系统时间.";
                    break;

                case 22:
                    strErrMsg = "串口配置文件加载失败.";
                    break;

                case 23:
                    strErrMsg = "传输分站配置文件加载失败.";
                    break;

                case 24:
                    strErrMsg = "界面布局加载失败.";
                    break;

                case 25:
                    strErrMsg = "请输入用户名和密码.";
                    break;

                case 26:// 暂时无人使用
                    strErrMsg = "用户名或密码错误.";
                    break;

                case 27:
                    strErrMsg = "没有用户名信息，请先配置用户信息.";
                    break;

                case 28:
                    strErrMsg = "加载XML文件失败，请检查文件格式";
                    break;

                case 29:
                    strErrMsg = "请确认已按要求将密码信息填写完整.";
                    break;

                case 30:
                    strErrMsg = "新密码和验证密码不相同";
                    break;
                case 31:
                    strErrMsg = "环网配置文件加载失败";
                    break;
                case 32:
                    strErrMsg = "通讯方式文件加载失败";
                    break;
            }

            if (iErrNO != 21)
            {
                // 将错误消息显示到面板上。
                //rtxtSysMsg.SelectionColor = Color.Red;
                if (rtxtSysMsg != null)
                {
                    rtxtSysMsg.WriteTxt(strErrMsg, " [ 系统消息 ]", true, System.Drawing.Color.Black);
                }
            }
            //rtxtSysMsg.SelectionColor = Color.Black;

            // 是否以 MessageBox 的形式提示错误
            if (isShowMsgBox)
            {
                MessageBox.Show(strErrMsg);
            }

            // 退出应用程序
            if (isExit)
            {
                Exit();
            }
        }

        #endregion

        #region [ 接口: DataSaver保存到SQLSERVER中 ]

        /// <summary>
        /// 数据抵达
        /// </summary>
        /// <param name="cmdReceived"></param>
        /// <param name="iHost"></param>
        private void startPort_DataReceived(byte[] cmdReceived, int iHost, int iGroup)
        {
            try
            {
                if (cmdReceived.Length == 7 && cmdReceived[1] == 20 && cmdReceived[3] == 0 && cmdReceived[4] == 0)
                {
                    // 当回送数据库 20 号 巡检，回送长度为 7 个字节时，根据通迅协议，认定无数据上传，不需要处理该命令
                    return;
                }
                if (commType)
                {
                    startTcp.IsSaveSql = true;
                }
                else
                {
                    try
                    {
                        startPort.IsSaveSql = true;
                        //for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                        //{
                        //    if (StartPort.s_serialPort[i].Group == iGroup)
                        //    {
                        //        StartPort.s_serialPort[i].IsSaveSql = true;
                        //        break;
                        //    }
                        //}
                    }
                    catch { }
                }
                try
                {
                    //Czlt-2011-01-26
                    //strByte = ByteToStr(cmdReceived);
                    //dtw.CreateFile(DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.CurrentCulture) + ".txt", strByte, true);

                    //保存数据库
                    sqlSave.InsertSQLSERVER(DateTime.Now.ToString(), cmdReceived);
                }
                catch { }
                if (commType)
                {
                    startTcp.IsSaveSql = false;
                }
                else
                {
                    try
                    {
                        startPort.IsSaveSql = false;
                        //for (int j = 0; j < StartPort.s_serialPort.Length; j++)
                        //{
                        //    if (StartPort.s_serialPort[j].Group == iGroup)
                        //    {
                        //        StartPort.s_serialPort[j].IsSaveSql = false;
                        //        break;
                        //    }
                        //}
                    }
                    catch { }
                }
            }
            catch { }
            //if (IsStartHost)//启动热备
            //{

            //    //dataSave.DataReceived(cmdReceived, IsHost);
            //}
            //else//不使用热备
            //{
            //    sqlSave.InsertSQLSERVER(DateTime.Now.ToString(), cmdReceived);
            //    //dataSave.DataReceived(cmdReceived, true);  
            //}

        }
        #endregion

        #region [ 接口: 改变基站状态 ]

        /// <summary>
        /// 改变基站状态
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="iAddress">基站地址</param>
        /// <param name="enumState">基站状态</param>
        public bool Station_ChangeState(int index, int iAddress, EnumStationState enumState)
        {
            try
            {
                int iStationID = -1;
                int iGroup = 0;
                iStationID = StartPort.s_serialPort[index].GetStationID(iAddress);
                iGroup = StartPort.s_serialPort[index].Group;

                if (iStationID != -1)
                {
                    if (enumState != EnumStationState.PointCancal && enumState != EnumStationState.PointSelect)
                    {

                        #region 生成基站状态命令

                        byte[] changeState = new byte[10];
                        changeState[0] = (byte)iAddress;
                        changeState[1] = 99;
                        changeState[3] = (byte)Convert.ToInt32(DateTime.Now.Year / 1000);
                        changeState[4] = (byte)Convert.ToInt32(DateTime.Now.Year - 2000);
                        changeState[5] = (byte)Convert.ToInt32(DateTime.Now.Month);
                        changeState[6] = (byte)Convert.ToInt32(DateTime.Now.Day);
                        changeState[7] = (byte)Convert.ToInt32(DateTime.Now.Hour);
                        changeState[8] = (byte)Convert.ToInt32(DateTime.Now.Minute);
                        changeState[9] = (byte)Convert.ToInt32(DateTime.Now.Second);

                        if (enumState == EnumStationState.NoInit)       //基站未启用
                        {
                            changeState[2] = 1;
                            startPort_DataReceived(changeState, 1, iGroup);
                        }
                        else if (enumState == EnumStationState.Reset)       //基站重启
                        {
                            changeState[2] = 2;
                            //startPort_DataReceived(changeState, 1);
                        }
                        else if (enumState == EnumStationState.Sleep)       //基站休眠
                        {
                            changeState[2] = 3;
                            startPort_DataReceived(changeState, 1, iGroup);
                        }
                        else if (enumState == EnumStationState.Leave)         //基站离线
                        {
                            changeState[2] = 4;
                            startPort_DataReceived(changeState, 1, iGroup);
                        }
                        else if (enumState == EnumStationState.Malfunction)   //基站故障
                        {
                            changeState[2] = 5;
                            startPort_DataReceived(changeState, 1, iGroup);
                        }
                        //else if(enumState==EnumStationState.SelectEdition) //基站正常
                        //{
                        //    changeState[2] = 0;
                        //    startPort_DataReceived(changeState, 1);
                        //}

                        //基站正常
                        if (enumState != EnumStationState.Leave && enumState != EnumStationState.Malfunction && enumState != EnumStationState.NoInit && enumState != EnumStationState.Sleep)
                        {
                            changeState[2] = 0;
                            startPort_DataReceived(changeState, 1, iGroup);
                        }
                        #endregion

                        if (enumState != EnumStationState.Sleep)
                        {
                            // 如果不是指令基站休眠的话，执行
                            //StartPort.s_serialPort[index].Stations[iStationID].State = enumState.GetHashCode();
                            for (int i = 0; i < StartPort.s_serialPort[index].Stations.Length; i++)
                            {
                                if (StartPort.s_serialPort[index].Stations[i].ID == iStationID)
                                {
                                    StartPort.s_serialPort[index].Stations[i].State = enumState.GetHashCode();
                                    StartPort.s_serialPort[index].TempStations[i].State = enumState.GetHashCode();
                                    if (enumState == EnumStationState.NoInit || enumState == EnumStationState.Reset)
                                    {
                                        StartPort.s_serialPort[index].Stations[i].NoAnswer = 0;
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            int iSleepCount = 0;
                            for (int i = 0; i < StartPort.s_serialPort[index].Stations.Length; i++)
                            {
                                if (StartPort.s_serialPort[index].Stations[i].State == enumState.GetHashCode())
                                {
                                    iSleepCount++;
                                }
                            }

                            // 查看次数
                            if (iSleepCount != StartPort.s_serialPort[index].Stations.Length - 1)
                            {
                                //StartPort.s_serialPort[index].Stations[iStationID].State = enumState.GetHashCode();
                                for (int i = 0; i < StartPort.s_serialPort[index].Stations.Length; i++)
                                {
                                    if (StartPort.s_serialPort[index].Stations[i].ID == iStationID)
                                    {
                                        StartPort.s_serialPort[index].Stations[i].State = enumState.GetHashCode();
                                        StartPort.s_serialPort[index].TempStations[i].State = enumState.GetHashCode();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }

                        }
                    }
                    else
                    {
                        if (enumState == EnumStationState.PointSelect)
                        {
                            for (int i = 0; i < StartPort.s_serialPort[index].Stations.Length; i++)
                            {
                                if (StartPort.s_serialPort[index].Stations[i].ID == iStationID)
                                {
                                    SetText(tsslPointSelect, StartPort.s_serialPort[index].Stations[i].Address.ToString(), System.Drawing.Color.Red);
                                    StartPort.s_serialPort[index].Stations[i].IsPointSelect = true;
                                    break;
                                }
                            }
                        }
                        else if (enumState == EnumStationState.PointCancal)
                        {
                            SetText(tsslPointSelect, "无", System.Drawing.Color.Black);
                            for (int i = 0; i < StartPort.s_serialPort[index].Stations.Length; i++)
                            {
                                StartPort.s_serialPort[index].Stations[i].IsPointSelect = false;
                            }
                        }
                    }
                }
            }
            catch { }

            return true;
        }

        /// <summary>
        /// 改变基站状态
        /// </summary>
        /// <param name="iAddress">基站地址</param>
        /// <param name="enumState">基站状态</param>
        public bool Station_ChangeState(int iAddress, EnumStationState enumState)
        {
            int iStationID = StartTcp.m_TcpClientPort.GetStationID(iAddress);

            if (iStationID != -1)
            {
                if (enumState != EnumStationState.PointCancal && enumState != EnumStationState.PointSelect)
                {
                    #region 生成基站状态命令

                    byte[] changeState = new byte[10];
                    changeState[0] = (byte)iAddress;
                    changeState[1] = 99;
                    changeState[3] = (byte)Convert.ToInt32(DateTime.Now.Year / 1000);
                    changeState[4] = (byte)Convert.ToInt32(DateTime.Now.Year - 2000);
                    changeState[5] = (byte)Convert.ToInt32(DateTime.Now.Month);
                    changeState[6] = (byte)Convert.ToInt32(DateTime.Now.Day);
                    changeState[7] = (byte)Convert.ToInt32(DateTime.Now.Hour);
                    changeState[8] = (byte)Convert.ToInt32(DateTime.Now.Minute);
                    changeState[9] = (byte)Convert.ToInt32(DateTime.Now.Second);

                    if (enumState == EnumStationState.NoInit)       //基站未启用
                    {
                        changeState[2] = 1;
                        startPort_DataReceived(changeState, 1, 1);
                    }
                    else if (enumState == EnumStationState.Reset)       //基站重启
                    {
                        changeState[2] = 2;
                        startPort_DataReceived(changeState, 1, 1);
                    }
                    else if (enumState == EnumStationState.Sleep)       //基站休眠
                    {
                        changeState[2] = 3;
                        startPort_DataReceived(changeState, 1, 1);
                    }
                    else if (enumState == EnumStationState.Leave)         //基站离线
                    {
                        changeState[2] = 4;
                        startPort_DataReceived(changeState, 1, 1);
                    }
                    else if (enumState == EnumStationState.Malfunction)   //基站故障
                    {
                        changeState[2] = 5;
                        startPort_DataReceived(changeState, 1, 1);
                    }
                    //else if(enumState==EnumStationState.SelectEdition) //基站正常
                    //{
                    //    changeState[2] = 0;
                    //    startPort_DataReceived(changeState, 1);
                    //}

                    //基站正常
                    if (enumState != EnumStationState.Leave && enumState != EnumStationState.Malfunction && enumState != EnumStationState.NoInit && enumState != EnumStationState.Sleep)
                    {
                        changeState[2] = 0;
                        startPort_DataReceived(changeState, 1, 1);
                    }
                    #endregion

                    if (enumState != EnumStationState.Sleep)
                    {
                        // 如果不是指令基站休眠的话，执行
                        //StartPort.s_serialPort[index].Stations[iStationID].State = enumState.GetHashCode();
                        for (int i = 0; i < StartTcp.m_TcpClientPort.Stations.Length; i++)
                        {
                            if (StartTcp.m_TcpClientPort.Stations[i].ID == iStationID)
                            {
                                StartTcp.m_TcpClientPort.Stations[i].State = enumState.GetHashCode();
                                if (enumState == EnumStationState.NoInit || enumState == EnumStationState.Reset)
                                {
                                    StartTcp.m_TcpClientPort.Stations[i].NoAnswer = 0;
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        int iSleepCount = 0;
                        for (int i = 0; i < StartTcp.m_TcpClientPort.Stations.Length; i++)
                        {
                            if (StartTcp.m_TcpClientPort.Stations[i].State == enumState.GetHashCode())
                            {

                                iSleepCount++;
                            }
                        }

                        // 查看次数
                        if (iSleepCount != StartTcp.m_TcpClientPort.Stations.Length - 1)
                        {
                            //StartPort.s_serialPort[index].Stations[iStationID].State = enumState.GetHashCode();
                            for (int i = 0; i < StartTcp.m_TcpClientPort.Stations.Length; i++)
                            {
                                if (StartTcp.m_TcpClientPort.Stations[i].ID == iStationID)
                                {
                                    StartTcp.m_TcpClientPort.Stations[i].State = enumState.GetHashCode();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
                else
                {
                    if (enumState == EnumStationState.PointSelect)
                    {
                        for (int i = 0; i < StartTcp.m_TcpClientPort.Stations.Length; i++)
                        {
                            if (StartTcp.m_TcpClientPort.Stations[i].ID == iStationID)
                            {
                                SetText(tsslPointSelect, StartTcp.m_TcpClientPort.Stations[i].Address.ToString(), System.Drawing.Color.Red);
                                StartTcp.m_TcpClientPort.Stations[i].IsPointSelect = true;
                                break;
                            }
                        }
                    }
                    else if (enumState == EnumStationState.PointCancal)
                    {
                        SetText(tsslPointSelect, "无", System.Drawing.Color.Black);
                        for (int i = 0; i < StartTcp.m_TcpClientPort.Stations.Length; i++)
                        {
                            StartTcp.m_TcpClientPort.Stations[i].IsPointSelect = false;
                        }
                    }
                }
            }

            return true;
        }

        #endregion

        #region [ 接口: 改变基站信息 ]

        /// <summary>
        /// 改变基站信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="iAddress"></param>
        /// <param name="enumOP"></param>
        /// <returns></returns>
        public bool Station_Change(int index, int iAddress, EnumOP enumOP)
        {
            //MainHelper.StationAdd("Station.xml");
            //MainHelper.StationLoad("Station.xml");

            //MainHelper.InitSerialPort(startPort);
            /*
            MemStation[] memStation = StartPort.s_serialPort[index].Stations;
             int memleng = memStation.Length + 1;
             MemStation[] memStation1 = new MemStation[memleng];
             for (int i=0; i < memStation.Length; i++)
             {
                 memStation1[i].ID = memStation[i].ID;
                 memStation1[i].Address = memStation[i].Address;
                 memStation1[i].Group = memStation[i].Group;
                 memStation1[i].State = memStation[i].State;
                 memStation1[i].Ver = memStation[i].Ver;
             }
             memStation1[memStation.Length].ID = 2;
             memStation1[memStation.Length].Address = 3;
             memStation1[memStation.Length].Group = 1;
             memStation1[memStation.Length].State = 1;
             memStation1[memStation.Length].Ver = 1;
            */




            //MainHelper.StationChange(startPort, memStation1);



            //            MessageBox.Show("串口" + StartPort.s_serialPort[index].PortName + "基站" + iAddress + "操作" + enumOP.ToString());
            return true;
        }


        public bool DataSaver_StateChange(string strMsg)
        {
            return true;
        }
        #endregion

        #region [ 方法: 用户权限变更 ]

        /// <summary>
        /// 用户权限变更
        /// </summary>
        /// <param name="enumPower"></param>
        public void MenuPowerChange(EnumPowers enumPower)
        {

            MainHelper.MenuPowerChange(enumPower);
        }

        #endregion

        #region [ 方法: 读取热备配置信息 ]

        /// <summary>
        /// 读取热备配置信息
        /// </summary>
        public void ReadHostSet()
        {
            FrmHostIpSet frm = new FrmHostIpSet("HostIPConfig.xml");
            string strPort = String.Empty;
            frm.ReturnHostSet(out IsStartHost, out IsHost, out IpAddress, out strPort);
            if (commType)
            {
                startTcp.IsStartHostBacker = IsStartHost;
            }
            else
            {
                //传给串口是否启动热备
                startPort.IsStartHostBacker = IsStartHost;
            }
            if (IsStartHost)
            {
                //热备没有结束，不发送数据
                RBSend = false;

                ListenPort = Convert.ToInt32(strPort);
                // 退出热备程序
                hostBacker.Exit();

                if (!commType)
                {
                    //读取通信串口标志
                    SetSerial();
                    // 重新初始化赵建伟热备程序
                    hostBacker.InitHostBacker(IsHost, commType, IpAddress, ListenPort, strPortSign);
                    //传给串口是否是主机
                    startPort.IsHost = IsHost;
                    startPort.RbSend = RBSend;
                }
                else
                {
                    // 重新初始化赵建伟热备程序
                    hostBacker.InitHostBacker(IsHost, commType, IpAddress, ListenPort, tcpMark.ToString());
                    startTcp.IsHost = IsHost;
                    startTcp.RbSend = RBSend;
                }


                //更改状态栏中主备机状态
                if (IsHost)
                {
                    SetText(stlHostBack, "主机", System.Drawing.Color.Black);
                }
                else
                {
                    SetText(stlHostBack, "备机", System.Drawing.Color.Black);
                }


                #region[开始定时更新基站]
                if (sqlSave != null)
                {
                    if (commType)
                    {
                        MainHelper.StartTcpUpdateTime(sqlSave, "TcpServer.xml", "StationUpdateConfig.xml");
                    }
                    MainHelper.StartStationUpdateTimer(sqlSave, commType, "Station.xml", "StationUpdateConfig.xml");

                }
                #endregion
            }
            else
            {
                RBSend = true;
                // 退出热备程序
                hostBacker.Exit();

                if (!commType)
                {
                    //读取通信串口标志
                    SetSerial();
                    //传给串口是否是主机
                    startPort.IsHost = true;
                    startPort.RbSend = RBSend;
                }
                else
                {
                    startTcp.IsHost = true;
                    startTcp.RbSend = RBSend;
                }
                ////不启用热备，直接存储数据库
                //hostBacker.InitHostBacker(commType);

                SetText(stlHostBack, "未启用热备", System.Drawing.Color.Black);

                SetText(tslHost, "单机", System.Drawing.Color.Black);

                #region[开始定时更新基站]
                if (sqlSave != null)
                {
                    if (commType)
                    {
                        MainHelper.StartTcpUpdateTime(sqlSave, "TcpServer.xml", "StationUpdateConfig.xml");
                    }
                    MainHelper.StartStationUpdateTimer(sqlSave, commType, "Station.xml", "StationUpdateConfig.xml");

                }
                #endregion
            }
        }

        #endregion

        #region IFrmMain 成员

        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <returns></returns>
        public string GetLoginInfo()
        {
            return LoginName;
        }

        #endregion

        #region IFrmMain 成员

        /// <summary>
        /// 设置登录信息
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <returns></returns>
        public bool SetLoginInfo(string strLoginName)
        {
            LoginName = strLoginName;

            return true;
        }

        #endregion

        #region IFrmMain 成员

        /// <summary>
        /// 返回是否主机
        /// </summary>
        /// <returns></returns>
        public bool IsMainHost()
        {
            return true;
        }

        #endregion

        #region [ 方法: 获取通信端口的标志位 ]

        private void SetSerial()
        {

            if (StartPort.s_serialPort != null)
            {
                for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                {
                    if (i == StartPort.s_serialPort.Length - 1)
                    {
                        strPortSign += StartPort.s_serialPort[i].Mark;
                    }
                    else
                    {
                        strPortSign += StartPort.s_serialPort[i].Mark + ",";
                    }
                }
            }
        }


        #region [ 方法: 读取XML文件 ]

        /// <summary>
        /// 读取XML文件
        /// </summary>
        /// <returns></returns>
        private bool ReadXmlToTable(string strPath, DataSet ds)
        {
            ds.Tables.Clear();
            if (File.Exists(strPath))
            {
                try
                {

                    ds.ReadXml(strPath);            //读取数据库的配置
                }
                catch (Exception ex)
                {
                    ErrorMessage(6010001, ex.StackTrace, ex.Source, ex.Message);
                    return false;
                }
                return true;
            }
            else
            {

                return false;
            }
        }

        #endregion
        #endregion

        #region [ 方法: 状态栏效果处理 ]

        #region [ 委托: 修改状态栏 ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tsl"></param>
        /// <param name="strText"></param>
        /// <param name="col"></param>
        public delegate void SetInvoke(ToolStripStatusLabel tsl, string strText, System.Drawing.Color col);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tsl"></param>
        /// <param name="strText"></param>
        /// <param name="col"></param>
        private void SetText(ToolStripStatusLabel tsl, string strText, System.Drawing.Color col)
        {
            try
            {
                if (ssStateList.InvokeRequired)
                {
                    SetInvoke _myInvoke = new SetInvoke(SetText);
                    this.Invoke(_myInvoke, new object[] { tsl, strText, col });
                }
                else
                {
                    tsl.Text = strText;
                    tsl.ForeColor = col;
                }
            }
            catch { }
        }

        #endregion

        #region [ 枚举: 类型 ]

        /// <summary>
        /// 类型
        /// </summary>
        enum ParameterType
        {
            /// <summary>
            /// 所有状态
            /// </summary>
            All = 0,
            /// <summary>
            /// 主备机状态
            /// </summary>
            Host = 1,
            /// <summary>
            /// 数据库连接状态
            /// </summary>
            DataBase = 2
        };

        #endregion

        #region [ 枚举: 状态 ]

        /// <summary>
        /// 状态
        /// </summary>
        enum StateType
        {
            /// <summary>
            /// 连接
            /// </summary>
            Connect = 1,
            /// <summary>
            /// 未连接
            /// </summary>
            Cut = 2,
            /// <summary>
            /// 未初始化
            /// </summary>
            Init = 0
        };

        #endregion

        #region [ 方法: 状态枚举转换成显示的文字 ]

        /// <summary>
        /// 状态枚举转换成显示的文字
        /// </summary>
        /// <param name="st"></param>
        /// <param name="tsl"></param>
        /// <returns></returns>
        private void StateText(StateType st, ToolStripStatusLabel tsl)
        {
            switch (st)
            {
                case StateType.Connect:
                    SetText(tsl, "已连接", System.Drawing.Color.Black);
                    if (tsl.Name.Equals("tslHost"))
                    {
                        SaveHostStateXml("true");
                        isOk = true;
                    }
                    break;
                case StateType.Cut:
                    SetText(tsl, "未连接", System.Drawing.Color.Red);
                    if (tsl.Name.Equals("tslHost"))
                    {
                        SaveHostStateXml("false");
                        isOk = false;
                        // SetNotiText("提示信息！","主备机通讯未连接,请检查网络连接！");
                    }
                    break;
                case StateType.Init:
                    SetText(tsl, "检测中...", System.Drawing.Color.Black);
                    if (tsl.Name.Equals("tslHost"))
                    {
                        SaveHostStateXml("true");
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region [ 方法: 状态枚举转换成显示的图标 ]

        /// <summary>
        /// 状态枚举转换成显示的文字
        /// </summary>
        /// <param name="st"></param>
        /// <param name="tsl"></param>
        /// <returns></returns>
        private void StateIco(StateType st, ToolStripStatusLabel tsl)
        {
            string strState = string.Empty;
            switch (st)
            {
                case StateType.Connect:
                    strState = @"C:\Documents and Settings\xiaochao21\桌面\icons\connect.jpg";
                    break;
                case StateType.Cut:
                    strState = @"C:\Documents and Settings\xiaochao21\桌面\icons\cut.jpg";
                    break;
                default:
                    break;
            }

            tsl.Image = System.Drawing.Image.FromFile(strState);
        }

        #endregion


        #region [ 方法: 类型 ]

        /// <summary>
        /// 状态处理
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="st"></param>
        private void EditState(ParameterType pt, StateType st)
        {
            switch (pt)
            {
                case ParameterType.All:
                    StateText(st, tslHost);
                    StateText(st, tslDataBase);
                    break;
                case ParameterType.Host:
                    StateText(st, tslHost);
                    break;
                case ParameterType.DataBase:
                    StateText(st, tslDataBase);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ 方法: 状态处理 ]

        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="iErrCode"></param>
        public void StateManage(int iErrCode)
        {
            if (iErrCode == 8033001)
            {
                RBSend = true;
                if (commType)
                {
                    startTcp.IsNetWork = true;
                    startTcp.RbSend = RBSend;
                }
                else
                {
                    startPort.IsNetWork = true;
                    startPort.RbSend = RBSend;
                }
                EditState(ParameterType.Host, StateType.Connect);
            }
            //if (iErrCode == 8033008)
            //{
            //    EditState(ParameterType.Host, StateType.Connect);
            //}
            if (iErrCode == 8033002)
            {
                RBSend = true;
                if (commType)
                {
                    startTcp.IsNetWork = false;
                    startTcp.RbSend = RBSend;
                }
                else
                {
                    startPort.IsNetWork = false;
                    startPort.RbSend = RBSend;
                }
                EditState(ParameterType.Host, StateType.Cut);
            }
            if (iErrCode == 8020001)
            {
                if (_SQLerrCount != 0)
                {
                    if (rtxtSysMsg != null)
                    {
                        rtxtSysMsg.WriteTxt("数据库连接正常，命令正常收发。", " [ 提示信息 ]", true, System.Drawing.Color.Black);
                    }
                }
                _SQLerrCount = 0;
                if (commType)
                {
                    startTcp.IsDataBaseConnection = true;
                }
                else
                {
                    startPort.IsDataBaseConnection = true;
                }
                EditState(ParameterType.DataBase, StateType.Connect);
            }
            if (iErrCode == 6020007 || iErrCode == 6020008 || iErrCode == 6020009)
            {
                if (commType)
                {
                    startTcp.IsDataBaseConnection = false;
                }
                else
                {
                    startPort.IsDataBaseConnection = false;
                }
                EditState(ParameterType.DataBase, StateType.Cut);
            }
        }

        #endregion

        #endregion

        #region [ Exit ]

        /// <summary>
        /// 退出应用程序
        /// </summary>
        public void Exit()
        {
            if (MessageBox.Show("关闭通讯程序会对数据造成一定影响，确定要关闭通讯程序吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;

                //foreach (Process process in Process.GetProcesses())
                //{
                //    if (process.ProcessName.Equals("KJ128ADataOperator"))
                //    {
                //        process.Kill();
                //        break;
                //    }
                //}

                #region 退出应用程序进程

                Process p = Process.GetCurrentProcess();
                p.Kill();

                //CzltSaveChkXml(false);
                #endregion

                Application.DoEvents();

                //dataSave.Exit();

                hostBacker.Exit();


                Application.ExitThread();
                Application.Exit();
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                Visible = false;
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 重启程序
        /// </summary>
        public void Reset()
        {
            Exit();
        }

        #endregion

        #region [ 事件: 窗体初次显示事件 ]

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            EditState(ParameterType.All, StateType.Init);
            //判断数据库是否存在
            sqlSave.IsConnect();

            if (!commType)//串口发送状态
            {
                if (!startPort.IsDataBaseConnection)
                {
                    MessageBox.Show("数据库连接失败，程序将后关闭");
                    this.Close();
                }
            }
            else
            {
                if (!startTcp.IsDataBaseConnection)
                {
                    MessageBox.Show("数据库连接失败，程序将后关闭");
                    this.Close();
                }
            }

            //袁丽 读取热备配置文件
            ReadHostSet();

            MainHelper.MenuPowerChange(EnumPowers.Default);

            if (commType)
            {
                SetText(tslCommType, "环网", System.Drawing.Color.Black);
                startTcp.Run();
            }
            else
            {
                SetText(tslCommType, "串口", System.Drawing.Color.Black);
                startPort.Run();
            }

            // 袁丽保存数据接口
            //dataSave = new InterfaceSerialPort();             // 实例化数据保存程序
            //dataSave.ErrorMessage += dataSave_ErrorMessage;
            tConn.Start();
        }

        #endregion

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        #region 【Czlt-2010-12-20保存主备机的链接状态】
        private void SaveHostStateXml(string str)
        {
            strHostPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\HostConnState.xml";
            DataTable dtSavaXml = new DataTable();
            BuildTable(dtSavaXml);
            if (File.Exists(strHostPath))
            {
                dtSavaXml.Rows.Clear();
                DataRow dr = dtSavaXml.NewRow();
                dr["IsHostConn"] = str;
                dtSavaXml.Rows.Add(dr);
                dtSavaXml.AcceptChanges();
                try
                {
                    dtSavaXml.WriteXml(strHostPath, true);
                }
                catch (Exception ex)
                {
                }

            }
            else
            {
                dtSavaXml.Rows.Add("true");
                dtSavaXml.WriteXml(strHostPath);
                //File.Create(strHostPath);            
            }
        }

        /// <summary>
        /// 构造配置表
        /// </summary>
        private void BuildTable(DataTable dtSave)
        {
            dtSave.TableName = "IPHostBuild";
            dtSave.Columns.Add("IsHostConn", typeof(string));
            dtSave.AcceptChanges();
        }
        #endregion

        #region 【Czlt-2011-01-26 字节转换成字符串】
        private string ByteToStr(byte[] cmdByte)
        {
            StringBuilder strB = new StringBuilder();

            for (int i = 0; i < cmdByte.Length; i++)
            {
                strB.Append(cmdByte[i].ToString()).Append(" ");
            }

            return strB.ToString().Substring(0, strB.Length - 1);



        }
        #endregion

        #region 【每秒检测一下呼叫信息】
        //private void t1second_Tick(object sender, EventArgs e)
        void t1second_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            t1second.Stop();

            //Czlt-2011-12-10 监测IP地址
            PingIP();
            #region【Czlt-2011-12-10 提示信息】
            czltCount++;
            if (czltCount >= 20)
            {
                string configPath = Application.StartupPath + @"\HostConnState.xml";
                XmlDocument docConfig = new XmlDocument();
                docConfig.Load(configPath);
                string isHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;
                if (isHost.ToUpper() == "TRUE")
                {
                    czltCurrentIndex = 0;
                    Notifier();
                    //File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 弹出一次提示框 \r\n", Encoding.Unicode);
                }

                czltCount = 0;



            }
            #endregion
            //Czlt-2011-09-16-获得双向通讯命令
            XmlDocument czltXmlDocument = new XmlDocument();


            if (File.Exists(Application.StartupPath.ToString() + "\\Calling.xml"))
            {
                try
                {
                    skOutCard = string.Empty; //出分站的标识卡
                    string skInCard = string.Empty;//进分站的标识卡

                    //清空呼叫组
                    czltGroup.Clear();
                    //string txt = File.ReadAllText(Application.StartupPath.ToString() + "\\CallFlag.txt");
                    czltXmlDocument.Load(Application.StartupPath + "\\Calling.xml");
                    XmlNode nodeIsCall = czltXmlDocument.SelectSingleNode("/Call/isCall");
                    if (nodeIsCall.InnerText.Equals("true"))
                    {
                        //全矿呼叫
                        XmlNode nodeCallAll = czltXmlDocument.SelectSingleNode("/Call/CallAll");
                        //被呼叫的标识卡号
                        XmlNode nodeCode = czltXmlDocument.SelectSingleNode("/Call/strCodeNum");
                        //被呼叫的传输分站号
                        XmlNode nodeSta = czltXmlDocument.SelectSingleNode("/Call/strStaNum");
                        //被呼叫的读卡分站号
                        XmlNode nodeSHead = czltXmlDocument.SelectSingleNode("/Call/strStaHeadNum");
                        //被呼叫的卡号和人名
                        XmlNode nodeCodeName = czltXmlDocument.SelectSingleNode("/Call/strCodeName");

                        //假如全矿呼叫
                        if (nodeCallAll.InnerText.Equals("true"))
                        {
                            t1second.Interval = 300000;

                            if (czltCount >= 1)
                            {
                                czltCount = 0;
                                string configPath = Application.StartupPath + @"\HostConnState.xml";
                                XmlDocument docConfig = new XmlDocument();
                                docConfig.Load(configPath);
                                string isHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;
                                if (isHost.ToUpper() == "TRUE")
                                {
                                    czltCurrentIndex = 0;
                                    Notifier();
                                    // File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 串口通讯 \r\n", Encoding.Unicode);
                                }
                            }


                            //if (czltStopTime == 3)
                            //{
                            //    t1second.Interval = 10000;
                            //    czltIndex = 0;
                            //    czltStopTime = 1;
                            //    nodeIsCall.InnerText = "false";
                            //    czltGroup.Clear();
                            //    czltCallTime.Enabled = false;
                            //    czltXmlDocument.Save(Application.StartupPath.ToString() + "\\Calling.xml");
                            //    File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 全矿呼叫关闭双通！ \r\n", Encoding.Unicode);
                            //}
                            //else
                            //{
                            czltStopTime++;
                            DataTable dt = czltGetCard.Czlt_GetRTAllSta();
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                //File.AppendAllText("D:\\CzltCallTest.txt", "全矿呼叫已经启动！！！\r\n", Encoding.Unicode);
                                foreach (DataRow dr in dt.Rows)
                                {
                                    string skyStations = dr[1] + " " + 0 + " " + 0;
                                    if (!czltGroup.ContainsKey(Convert.ToInt32(dr[1].ToString())))
                                    {
                                        czltGroup.Add(Convert.ToInt32(dr[1].ToString()), skyStations);
                                    }
                                    // File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + skyStations + "\r\n", Encoding.Unicode);


                                }

                            }
                            //}
                        }
                        else //没有进行全矿呼叫
                        {
                            t1second.Interval = 30000;
                            //假如标识卡为空
                            if (nodeCode.InnerText.Equals(""))
                            {

                                //假如分站不为空的时候
                                if (!nodeSta.InnerText.ToString().Equals("0"))
                                {
                                    t1second.Interval = 40000;
                                    czltStopTime++;
                                    if (czltStopTime >= 4)
                                    {
                                        t1second.Interval = 10000;
                                        czltIndex = 0;
                                        czltStopTime = 1;
                                        nodeIsCall.InnerText = "false";
                                        czltGroup.Clear();
                                        czltCallTime.Enabled = false;
                                        czltXmlDocument.Save(Application.StartupPath.ToString() + "\\Calling.xml");

                                    }
                                    string skySta = nodeSta.InnerText.ToString() + " " + nodeSHead.InnerText.ToString() + " " + 0;

                                    //将要被呼叫的区域添加到呼叫队列中
                                    if (!czltGroup.ContainsKey(Convert.ToInt32(nodeSta.InnerText.ToString())))
                                    {
                                        czltGroup.Add(Convert.ToInt32(nodeSta.InnerText.ToString()), skySta);
                                    }
                                    // File.AppendAllText("D:\\CzltCallTest.txt", "区域呼叫！！！\r\n", Encoding.Unicode);
                                    //File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + skySta + "\r\n", Encoding.Unicode);
                                }
                            }
                            else//假如标识卡不为空
                            {
                                czltStopTime = 3;
                                if (czltIndex >= czltSum)
                                {
                                    t1second.Interval = 10000;
                                    czltIndex = 0;
                                    czltStopTime = 1;
                                    nodeIsCall.InnerText = "false";
                                    czltGroup.Clear();
                                    czltCallTime.Enabled = false;
                                    czltXmlDocument.Save(Application.StartupPath.ToString() + "\\Calling.xml");

                                }
                                else
                                {

                                    //被呼叫的标识卡号
                                    string[] strCodes = nodeCode.InnerText.ToString().Split(',');
                                    //File.AppendAllText("D:\\CzltCallTest.txt", "人员呼叫！！！\r\n", Encoding.Unicode);
                                    foreach (string strCode in strCodes)
                                    {
                                        string czltSta = czltGetCard.Czlt_GetRTStnHead(strCode);

                                        if (!czltSta.Trim().Equals("")) // 进分站的标识卡
                                        {
                                            skInCard += strCode + ",";
                                            string[] strC = czltSta.Split(',');
                                            string skyCode = strC[0] + " " + strC[1] + " " + strCode;

                                            //添加标识卡
                                            if (!czltGroup.ContainsKey(Convert.ToInt32(strCode)))
                                            {
                                                czltGroup.Add(Convert.ToInt32(strCode), skyCode);
                                            }


                                            //File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + skyCode + "进读卡分站\r\n", Encoding.Unicode);
                                        }
                                        else //出分站的标识卡
                                        {
                                            skOutCard += strCode + ",";
                                            //File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + strCode + "出读卡分站\r\n", Encoding.Unicode);
                                        }
                                    }
                                    czltIndex = czltIndex + czltStopTime;
                                   
                                }
                            }
                        }
                        
                        czltCallTime.Enabled = true;
                        czltCallTime.Start();
                        if (commType)//环网通讯
                        {
                            StartTcp.m_TcpClientPort.IsTwoMessage = true;
                            //File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 环网通讯 \r\n", Encoding.Unicode);
                        }
                        else
                        {
                            for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                            {
                                StartPort.s_serialPort[i].IsTwoMessage = true;
                            }
                            // File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 串口通讯 \r\n", Encoding.Unicode);
                        }
                    }
                    else
                    {
                        t1second.Interval = 10000;
                        czltIndex = 0;
                        czltStopTime = 1;
                        czltCallTime.Enabled = false;
                        //File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 关闭双通！ \r\n", Encoding.Unicode);
                    }

                }
                catch { }
            }

            t1second.Start();

            //********Czlt-2012-3-26-刷新分站列表信息*****
            czltStationIndex++;
            Czlt_UpdateSta(czltStationIndex);

            //********Czlt-2012-3-26-系统自动清理内存*****
            if (indexGC >= 90)
            {
                indexGC = 0;
                FlushMemory();

            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void czltCallTime_Tick(object sender, EventArgs e)
        {
            this.czltCallTime.Interval = 2000;
            //File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 被呼叫的集合数目： " + czltGroup.Count + "\r\n", Encoding.Unicode);
            if (czltGroup.Count > 0)
            {
                // File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 呼叫启动！ \r\n", Encoding.Unicode);

                int iCode = 0;
                foreach (int ii in czltGroup.Keys)
                {
                    iCode = ii;

                }
                string[] str = czltGroup[iCode].ToString().Split(' ');
                // File.AppendAllText("D:\\CzltCallTest.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + czltGroup[iCode].ToString() + " 呼叫启动！ \r\n", Encoding.Unicode);


                czltGroup.Remove(iCode);

                if (str.Length == 3)
                {
                    //string[] strCard = str[2].ToString().Split(',');
                    //if (strCard.Length > 1)
                    //{
                    //    _Cards = new int[strCard.Length - 1];
                    //    for (int i = 1; i < strCard.Length; i++)
                    //    {
                    //        _Cards[i - 1] = Convert.ToInt32(strCard[i - 1]);
                    //    }
                    //}
                    //else
                    //{
                    //    _Cards = null;
                    //}
                    _Cards = null;
                    _Order = new int[3];

                    if (str[2].Equals("0"))//标识卡为空
                    {
                        _Order[0] = Convert.ToInt32(str[0]);
                        _Order[1] = Convert.ToInt32(str[1]);
                        _Order[2] = 65535;

                    }
                    else //标识卡不为空
                    {
                        _Order[0] = Convert.ToInt32(str[0]);
                        _Order[1] = Convert.ToInt32(str[1]);
                        _Order[2] = Convert.ToInt32(str[2]);
                    }

                    if (commType)//环网通讯
                    {
                        StartTcp.m_TcpClientPort.CardToCall = _Cards;
                        StartTcp.m_TcpClientPort.CallOrder = _Order;
                        if (skOutCard != null && !skOutCard.ToString().Equals(""))
                        {
                            StartTcp.m_TcpClientPort.strOutCard = skOutCard.Trim().Substring(0,skOutCard.Length-1);
                            skOutCard = string.Empty;
                        }

                    }
                    else//串口通讯
                    {
                        for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                        {
                            StartPort.s_serialPort[i].CardToCall = _Cards;
                            StartPort.s_serialPort[i].CallOrder = _Order;
                            if (skOutCard != null && !skOutCard.ToString().Equals(""))
                            {
                                
                                StartPort.s_serialPort[i].strOutCard = skOutCard.Trim().Substring(0, skOutCard.Length - 1);
                                skOutCard = string.Empty;
                            }
                        }
                    }


                }
            }
            else
            {
                czltCallTime.Enabled = false;

                if (commType)//环网通讯
                {
                    if (skOutCard != null && !skOutCard.ToString().Equals(""))
                    {
                        StartTcp.m_TcpClientPort.strOutCard = skOutCard.Trim().Substring(0, skOutCard.Length - 1);
                        skOutCard = string.Empty;
                    }

                    StartTcp.m_TcpClientPort.CardToCall = null;
                    StartTcp.m_TcpClientPort.CallOrder = null;
                    StartTcp.m_TcpClientPort.IsTwoMessage = false;
                }
                else
                {
                    for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                    {
                        if (skOutCard != null && !skOutCard.ToString().Equals(""))
                        {

                            StartPort.s_serialPort[i].strOutCard = skOutCard.Trim().Substring(0, skOutCard.Length - 1);
                            skOutCard = string.Empty;
                        }
                        StartPort.s_serialPort[i].CardToCall = null;
                        StartPort.s_serialPort[i].CallOrder = null;
                        StartPort.s_serialPort[i].IsTwoMessage = false;
                    }

                }
            }
        }

        #region【Czlt-2011-12-10 提示信息的设置】

        /// <summary>
        /// Czlt-2011-12-10 隐藏后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void czltNotifier_CzltEvent(object sender, EventArgs e)
        {
            try
            {
                //if (czltNotifier != null)
                //{                  

                //    czltNotifier.Dispose();
                //    // czltNotifier.Close();

                //}

                ///判断网络是否连接
                if (czltCurrentIndex == 0)
                {
                    IsChkHost();

                }
                else if (czltCurrentIndex == 1)  //判断是否安装sp4
                {
                    IsChkSqlSP4();
                }
                else if (czltCurrentIndex == 2)
                {
                    IsChkPZ();
                    czltCurrentIndex = 3;
                }
                else if (czltCurrentIndex == 3)
                {
                    IsChkSS();
                    czltCurrentIndex = 4;
                }
                else if (czltCurrentIndex == 4)
                {
                    IsChkHis();
                    czltCurrentIndex = 5;
                }
                else if (czltCurrentIndex == 5)
                {
                    IsChkPZ2();
                    czltCurrentIndex = 6;
                }
                else if (czltCurrentIndex == 6)
                {

                    czltCurrentIndex = 10;
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// 提示信息框
        /// </summary>
        private void Notifier()
        {
            IsChkHost();
            //IsChkSqlSP4();
            // IsChkSS();
        }

        /// <summary>
        /// Czlt-2011-12-10 监测主备机连接
        /// </summary>
        private void IsChkHost()
        {
            if (!isOk)
            {
                SetNotiText("提示信息", "网络故障请检查主备机连接状态！");
                czltCurrentIndex = 10;
            }
            else
            {
                IsChkSS();
                czltCurrentIndex = 1;
            }
        }

        /// <summary>
        /// Czlt-2011-12-10 跟新历史数据
        /// </summary>
        private void IsChkHis()
        {
            if (File.Exists("D:\\CzltHis.txt"))
            {
                if (ReadFile("D:\\CzltHis.txt", 5, 200))
                {
                    string txt = File.ReadAllText("D:\\CzltHis.txt");

                    if (!txt.Trim().Equals(""))
                    {
                        string[] strSS = txt.Split(',');

                        //if (ReadFile("D:\\CzltHis.txt", 5, 200))
                        //{
                        //    File.Delete("D:\\CzltHis.txt");
                        //}
                        if (strSS.Length > 1)
                        {
                            if ((DateTime.Now - Convert.ToDateTime(strSS[0])).TotalMinutes < 20)
                            {
                                if (strSS[1].Equals("2"))
                                {
                                    SetNotiText("热备提示", strSS[0].ToString() + "\r\n-<备份历史信息>-\r\n" + strSS[2].ToString());
                                }
                            }
                        }

                    }
                }
            }
        }


        /// <summary>
        /// Czlt-2011-12-10 跟新实时数据
        /// </summary>
        private void IsChkSS()
        {
            if (File.Exists("D:\\CzltSS.txt"))
            {
                if (ReadFile("D:\\CzltSS.txt", 5, 200))
                {
                    string txt = File.ReadAllText("D:\\CzltSS.txt");
                    if (!txt.Trim().Equals(""))
                    {
                        //if (ReadFile("D:\\CzltSS.txt", 5, 200))
                        //{
                        //    File.Delete("D:\\CzltSS.txt");
                        //}

                        string[] strSS = txt.Split(',');
                        if (strSS.Length > 1)
                        {
                            if ((DateTime.Now - Convert.ToDateTime(strSS[0])).TotalMinutes < 20)
                            {
                                if (strSS[1].Equals("1"))
                                {

                                    SetNotiText("热备提示", strSS[0].ToString() + "\r\n-<备份实时信息>-\r\n" + strSS[2].ToString());
                                }

                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Czlt-2011-12-10 跟新配置信息
        /// </summary>
        private void IsChkPZ()
        {
            if (File.Exists("D:\\CzltPZ.txt"))
            {
                if (ReadFile("D:\\CzltPZ.txt", 5, 200))
                {
                    string txt = File.ReadAllText("D:\\CzltPZ.txt");
                    if (!txt.Trim().Equals(""))
                    {
                        //if (ReadFile("D:\\CzltPZ.txt", 5, 200))
                        //{
                        //    File.Delete("D:\\CzltPZ.txt");
                        //}
                        string[] strSS = txt.Split(',');
                        if (strSS.Length > 1)
                        {
                            if ((DateTime.Now - Convert.ToDateTime(strSS[0])).TotalMinutes < 20)
                            {
                                if (strSS[1].Equals("0"))
                                {
                                    SetNotiText("热备提示", strSS[0].ToString() + "\r\n-<备份报警信息>-\r\n" + strSS[2].ToString());
                                }
                                //else if (strSS[1].Equals("01"))
                                //{
                                //    SetNotiText("热备提示", strSS[0].ToString() + "\r\n-<备份实时和配置信息>-\r\n实时下井表！\r\n实时人员分布！\r\n人员信息表！\r\n");
                                //}

                            }
                        }
                    }
                }
            }



        }


        /// <summary>
        /// Czlt-2011-12-10 跟新配置信息
        /// </summary>
        private void IsChkPZ2()
        {
            try
            {
                if (File.Exists("D:\\CzltPZ2.txt"))
                {
                    if (ReadFile("D:\\CzltPZ2.txt", 5, 200))
                    {
                        string txt = File.ReadAllText("D:\\CzltPZ2.txt");
                        if (!txt.Trim().Equals(""))
                        {
                            //if (ReadFile("D:\\CzltPZ.txt", 5, 200))
                            //{
                            //    File.Delete("D:\\CzltPZ.txt");
                            //}
                            string[] strSS = txt.Split(',');
                            if (strSS.Length > 1)
                            {
                                if ((DateTime.Now - Convert.ToDateTime(strSS[0])).TotalMinutes < 20)
                                {
                                    if (strSS[1].Equals("01"))
                                    {
                                        SetNotiText("热备提示", strSS[0].ToString() + "\r\n-<备份实时和配置信息>-\r\n" + strSS[2].ToString());
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch { }



        }

        /// <summary>
        /// Czlt-2011-12-10监测SQL是否有安装sp4
        /// </summary>
        private void IsChkSqlSP4()
        {
            try
            {
                //object profile = FirewallCurrentProfile();
                //profile.GetType().InvokeMember("FirewallEnabled", BindingFlags.SetProperty, null, profile, new object[] { false });

                //判断有没有安装Sql-SP4补丁
                DataTable dt = sqlSave.GetSqlVersion();
                if (dt != null && dt.Rows.Count > 0)
                {
                    string strDT = dt.Rows[0][0].ToString();
                    if (!strDT.Contains("8.00.2039"))
                    {
                        SetNotiText("提示信息", "请安装数据库的SP4插件,关闭防火墙,以便于实现双机热备！");
                        czltCurrentIndex = 10;
                    }
                    else
                    {
                        IsChkHis();
                        czltCurrentIndex = 2;
                    }
                }
            }
            catch { }
        }

        #region 【Czlt-2011-12-09 设置显示的提示信息】
        private void SetNotiText(string tableName, string strContent)
        {



            #region 【Czlt-2012-02-14 注销测试】
            ////czltNotifier = new TaskbarNotifier();

            ////if (czltNotifier.IsOpen)
            ////{
            ////    czltNotifier.Close();
            ////}

            ////string strPath = Application.StartupPath.ToString();
            ////Bitmap bitmap = new Bitmap(strPath + "\\skin.bmp");
            ////Bitmap bitmapClose = new Bitmap(strPath + "\\close.bmp");
            ////czltNotifier.SetBackgroundBitmap(bitmap, Color.FromArgb(255, 0, 255));
            ////czltNotifier.SetCloseBitmap(bitmapClose, Color.FromArgb(255, 0, 255), new Point(127, 8));
            ////czltNotifier.TitleRectangle = new Rectangle(40, 9, 150, 25);
            ////czltNotifier.ContentRectangle = new Rectangle(8, 41, 140, 68);

            //////czltNotifier.SetBackgroundBitmap
            ////czltNotifier.KeepVisibleOnMousOver = true;
            ////czltNotifier.ReShowOnMouseOver = true;
            ////czltNotifier.EnableSelectionRectangle = true;
            ////czltNotifier.ContentClickable = false;
            ////czltNotifier.CzltEvent += new EventHandler(czltNotifier_CzltEvent);
            ////czltNotifier.CloseClick += new EventHandler(czltNotifier_CloseClick);


            //try
            //{
            //    if (this.IsHandleCreated)
            //    {
            //        this.Invoke(new MethodInvoker(delegate()
            //        {
            //            czltNotifier.Show(tableName, strContent, 400, 1500, 300);
            //        }));

            //    }
            //}
            //catch (Exception ee)
            //{ }
            #endregion

        }

        void czltNotifier_CloseClick(object sender, EventArgs e)
        {
            //czltNotifier.Close();
        }

        /// <summary>
        /// 初始化弹出的窗体
        /// </summary>
        private void LoadNotifier()
        {
            //czltNotifier = new TaskbarNotifier();

            //if (czltNotifier.IsOpen)
            //{
            //    czltNotifier.Close();
            //}

            //string strPath = Application.StartupPath.ToString();
            //Bitmap bitmap = new Bitmap(strPath + "\\skin.bmp");
            //Bitmap bitmapClose = new Bitmap(strPath + "\\close.bmp");
            //czltNotifier.SetBackgroundBitmap(bitmap, Color.FromArgb(255, 0, 255));
            //czltNotifier.SetCloseBitmap(bitmapClose, Color.FromArgb(255, 0, 255), new Point(127, 8));
            //czltNotifier.TitleRectangle = new Rectangle(40, 9, 150, 25);
            //czltNotifier.ContentRectangle = new Rectangle(8, 41, 140, 68);

            ////czltNotifier.SetBackgroundBitmap
            //czltNotifier.KeepVisibleOnMousOver = true;
            //czltNotifier.ReShowOnMouseOver = true;
            //czltNotifier.EnableSelectionRectangle = true;
            //czltNotifier.ContentClickable = false;
            //czltNotifier.CzltEvent += new EventHandler(czltNotifier_CzltEvent);
            //czltNotifier.CloseClick += new EventHandler(czltNotifier_CloseClick);


        }
        #endregion

        /// <summary>
        /// Czlt-2011-12-10 监测网络连接状态
        /// </summary>
        private void PingIP()
        {

            try
            {
                string configPath = Application.StartupPath + @"\HostIPConfig.xml";
                XmlDocument docConfig = new XmlDocument();
                if (File.Exists(configPath))
                {
                    docConfig.Load(configPath);
                    string isHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;
                    string strIP = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[2].InnerText;
                    if (isHost.ToLower().Trim().Equals("true"))
                    {
                        try
                        {
                            //object profile = FirewallCurrentProfile();
                            //profile.GetType().InvokeMember("FirewallEnabled", BindingFlags.SetProperty, null, profile, new object[] { false });


                            PingReply r = ping.Send(strIP);
                            if (r.Status == IPStatus.Success)
                            {
                                //IsChkHost();

                            }
                            else
                            {
                                SetText(tslHost, "未连接", System.Drawing.Color.Red);
                                SetNotiText("提示信息", "主备机连接故障,请检查主备机运行情况！");
                                czltCurrentIndex = 10;

                            }
                        }
                        catch { }
                    }
                }
            }
            catch { }

        }

        #region【Czlt-2011-12-10 关闭防火墙】
        public static object FirewallCurrentProfile()
        {

            //获取管理防火墙的COM组件的type
            Type fwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", true);
            //创建一个COM组件的实例
            object fwMgr = Activator.CreateInstance(fwMgrType);
            //获取实例的LocalPolicy属性
            object localPolicy = fwMgrType.InvokeMember("LocalPolicy", BindingFlags.GetProperty, null, fwMgr, null);
            //获取 LocalPolicy属性的子属性CurrentProfile
            return localPolicy.GetType().InvokeMember("CurrentProfile", BindingFlags.GetProperty, null, localPolicy, null);
            //.LocalPolicy.CurrentProfile.FirewallEnabled


        }



        #endregion


        #region【Czlt-2011-08-11 判断一个文件是否被占用】
        public bool ReadFile(string fileName, int count, int time)
        {
            for (int i = 1; i < count + 1; i++)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(fileName, FileMode.Open);
                    return true;
                }
                catch (IOException ioe)
                {
                    if (ioe.Message.IndexOf("正由另一进程使用，因此该进程无法访问该文件") > -1)
                    {
                        if (i == count)
                        {
                            if (fs != null)
                            {
                                fs.Close();
                                fs.Dispose();
                            }

                            return false;
                        }
                        Thread.Sleep(time);
                    }
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }
            }
            return true;
        }

        #endregion



        #region 【Czlt-2011-12-26 对是不是正常关闭程序的状态做修改】
        /// <summary>
        /// Czlt-2011-12-26 对是不是正常关闭程序的状态做修改
        /// </summary>
        private void CzltSaveChkXml(bool isChk)
        {

            if (File.Exists(Application.StartupPath + "\\ChkType.Xml"))
            {

                XmlDocument dom = new XmlDocument();
                dom.Load(Application.StartupPath + @"\" + "ChkType.Xml");
                XmlNode xnSignalType = dom.SelectSingleNode("//TypeSignal//IsType");
                xnSignalType.InnerText = isChk.ToString();

                if (isChk == false)
                {
                    XmlNode xnSignalTime = dom.SelectSingleNode("//TypeSignal//CloseTime");
                    xnSignalTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    XmlNode xnSignalSumNum = dom.SelectSingleNode("//TypeSignal//SumNum");
                    xnSignalSumNum.InnerText = (Convert.ToInt64(xnSignalSumNum.InnerText) + 1).ToString();
                }



                dom.Save(Application.StartupPath.ToString() + "\\ChkType.xml");
            }


        }
        #endregion

        #endregion



        #region [Czlt-2012-3-27 刷新备机显示分站的个数]
        /// <summary>
        /// 同步备机的个数
        /// </summary>
        private void Czlt_UpdateSta(int index)
        {
            if (index >= 10)
            {
                czltStationIndex = 0;
                XmlDocument xmlConn = new XmlDocument();
                if (File.Exists(Application.StartupPath.ToString() + @"\HostConnState.xml"))
                {
                    xmlConn.Load(Application.StartupPath.ToString() + @"\HostConnState.xml");
                    XmlNode node = xmlConn.SelectSingleNode("/DocumentElement/IPHostBuild/IsHostConn");
                    if (node.InnerText.ToLower().Equals("true"))
                    {

                        string configPath = Application.StartupPath.ToString() + @"\HostIPConfig.xml";
                        if (File.Exists(configPath))
                        {
                            XmlDocument docConfig = new XmlDocument();
                            docConfig.Load(configPath);
                            string isHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;
                            string isHBack = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[1].InnerText;
                            if (isHost.ToUpper() == "TRUE")
                            {
                                //if (isHBack.ToUpper() == "FALSE")
                                //{
                                    DataTable stationdt = this.GetStationTable();
                                    if (stationdt.Rows.Count != czltStaNum)
                                    {
                                        czltStaNum = stationdt.Rows.Count;
                                        ReplaceStationXml(stationdt, Application.StartupPath + "\\Station.xml");
                                    }
                                //}
                            }
                        }
                    }
                }

                //Czlt-2012-3-31 假如分站和串口服务器取消管理,分站状态应该为故障
                Czlt_UpdateStaStateByIP();

            }
        }


        private DataTable GetStationTable()
        {
            bool commType = this.GetCommType();
            if (!commType)
            {
                return this.GetStationInfo(1);
            }
            else
            {
                return this.GetStationInfo(2);
            }
        }

        private DataTable GetStationInfo(int sign)
        {
            return czltGetCard.Get_StationInfo(sign);
        }


        public bool ReplaceStationXml(DataTable dt, string strPath)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\SerialPort.xml");
                XmlNode markrootnode = xml.SelectSingleNode("DocumentElement");
                int commType = 0;
                int tcpMark = 0;
                XmlDocument xmlcomm = new XmlDocument();
                if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\CommType.xml"))
                {
                    xmlcomm.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\CommType.xml");
                    try
                    {
                        XmlNode xmlnodeComm = xmlcomm.SelectSingleNode("/comm/commType");
                        if (xmlnodeComm != null)
                        {
                            commType = int.Parse(xmlnodeComm.InnerText);
                        }
                    }
                    catch
                    {
                    }
                    //if (commType != 0)
                    //{
                    //    try
                    //    {
                    //        XmlNode xmlnodeTcpMark = xmlcomm.SelectSingleNode("/comm/TcpMark");
                    //        if (xmlnodeTcpMark != null)
                    //        {
                    //            tcpMark = int.Parse(xmlnodeTcpMark.InnerText);
                    //        }
                    //    }
                    //    catch { }
                    //}
                }

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(strPath);
                XmlNode rootnode = xmldoc.SelectSingleNode("DocumentElement");
                rootnode.RemoveAll();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < markrootnode.ChildNodes.Count; j++)
                        {
                            if (commType == 0)
                            {
                                XmlNode Groupnode = xmldoc.CreateElement("Group");
                                if (markrootnode.ChildNodes[j].ChildNodes[2].InnerText.Equals(dt.Rows[i]["StationGroup"].ToString()))
                                {
                                    Groupnode.InnerText = dt.Rows[i]["StationGroup"].ToString();
                                    XmlNode node = xmldoc.CreateElement("Station");
                                    XmlNode idnode = xmldoc.CreateElement("ID");
                                    idnode.InnerText = dt.Rows[i]["ID"].ToString();
                                    XmlNode addressnode = xmldoc.CreateElement("Address");
                                    addressnode.InnerText = dt.Rows[i]["Address"].ToString();

                                    XmlNode statenode = xmldoc.CreateElement("State");
                                    statenode.InnerText = "0";
                                    XmlNode marknode = xmldoc.CreateElement("Mark");

                                    marknode.InnerText = markrootnode.ChildNodes[j].ChildNodes[3].InnerText;

                                    XmlNode isenablenode = xmldoc.CreateElement("Ver");
                                    isenablenode.InnerText = dt.Rows[i]["Ver"].ToString();
                                    XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                                    ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                                    XmlNode ipPort = xmldoc.CreateElement("IpPort");
                                    ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                                    XmlNode stationModelNode = xmldoc.CreateElement("StationModel");
                                    stationModelNode.InnerText = dt.Rows[i]["StationModel"].ToString();
                                    node.AppendChild(idnode);
                                    node.AppendChild(addressnode);
                                    node.AppendChild(Groupnode);
                                    node.AppendChild(statenode);
                                    node.AppendChild(marknode);
                                    node.AppendChild(isenablenode);
                                    node.AppendChild(ipaddressNode);
                                    node.AppendChild(ipPort);
                                    node.AppendChild(stationModelNode);
                                    rootnode.AppendChild(node);
                                }
                            }
                            else
                            {
                                XmlNode Groupnode = xmldoc.CreateElement("Group");
                                if (markrootnode.ChildNodes[j].ChildNodes[2].InnerText.Equals(dt.Rows[i]["StationGroup"].ToString()))
                                {
                                    Groupnode.InnerText = dt.Rows[i]["StationGroup"].ToString();
                                    XmlNode node = xmldoc.CreateElement("Station");
                                    XmlNode idnode = xmldoc.CreateElement("ID");
                                    idnode.InnerText = dt.Rows[i]["ID"].ToString();
                                    XmlNode addressnode = xmldoc.CreateElement("Address");
                                    addressnode.InnerText = dt.Rows[i]["Address"].ToString();

                                    XmlNode statenode = xmldoc.CreateElement("State");
                                    statenode.InnerText = "0";
                                    XmlNode marknode = xmldoc.CreateElement("Mark");

                                    //marknode.InnerText = tcpMark.ToString();
                                    marknode.InnerText = "2";

                                    XmlNode isenablenode = xmldoc.CreateElement("Ver");
                                    isenablenode.InnerText = dt.Rows[i]["Ver"].ToString();
                                    XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                                    ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                                    XmlNode ipPort = xmldoc.CreateElement("IpPort");
                                    ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                                    XmlNode stationModelNode = xmldoc.CreateElement("StationModel");
                                    stationModelNode.InnerText = dt.Rows[i]["StationModel"].ToString();
                                    node.AppendChild(idnode);
                                    node.AppendChild(addressnode);
                                    node.AppendChild(Groupnode);
                                    node.AppendChild(statenode);
                                    node.AppendChild(marknode);
                                    node.AppendChild(isenablenode);
                                    node.AppendChild(ipaddressNode);
                                    node.AppendChild(ipPort);
                                    node.AppendChild(stationModelNode);
                                    rootnode.AppendChild(node);
                                }

                            }
                        }
                    }
                }
                xmldoc.Save(strPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 【Czlt-2012-3-31 假如分站和串口服务器取消管理,分站状态应该为故障】
        /// <summary>
        /// Czlt-2012-3-31 假如分站和串口服务器取消管理,分站状态应该为故障
        /// </summary>
        private void Czlt_UpdateStaStateByIP()
        {
            if (commType)//环网通讯
            {
                czltGetCard.Czlt_UpdateStaState();
 
            }
        }
        #endregion



        #region【Czlt-2012-04-22 系统自动回收内存】
        ///// <summary>
        ///// 调用系统本身的垃圾回收器
        ///// </summary>
        ///// <param name="process"></param>
        ///// <param name="minSize"></param>
        ///// <param name="maxSize"></param>
        ///// <returns></returns>
        //[DllImport("kernel32.dll")]
        //private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        //private void FlushMemory()
        //{
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
        //    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        //        SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        //}
        #endregion

    }
}