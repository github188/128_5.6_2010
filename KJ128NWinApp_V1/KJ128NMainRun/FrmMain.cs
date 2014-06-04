using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using KJ128NDBTable;
using KJ128NMainRun.EquManage;
using KJ128NMainRun.RealTime.RealTimeInWellInfo;
using KJ128NMainRun.RealTime.ReelTimeMonitorInfo;
using KJ128NMainRun.StationManage;
using KJ128NMainRun.RealTime;
using KJ128NMainRun.RealTime.RealtimeInTerritorial;
using KJ128NMainRun.HistoryInfo.HistoryInTerritorial;
using KJ128NMainRun.RealTime.RealtimeOverTimeInfo;
using KJ128NMainRun.HistoryInfo.HistoryOverTimeInfo;
using KJ128NMainRun.RealTime.RealtimeStationBreak;
using KJ128NMainRun.HistoryInfo.HistoryStationBreak;
using KJ128NMainRun.RealTime.RealTimeStaHeadBreak;
using KJ128NDataBase;
using KJ128NMainRun.ConfigInfo.ConStaHeadInfo;
using KJ128NMainRun.ConfigInfo.ConEmployeeInfo;
using KJ128NMainRun.ConfigInfo.ConDeptManage;
using KJ128NMainRun.ConfigInfo.ConEquManage;
using KJ128NMainRun.ConfigInfo.ConCodeSenderInfo;
using KJ128NMainRun.ConfigInfo.ConDirectionalManage;
using KJ128NMainRun;
using KJ128NMainRun.ConfigInfo.ConAreaManage;
using System.Data.SqlClient;
using KJ128NMainRun.AlarmSet;
using System.Media;
using KJ128NMainRun.RealTime.RealTimeDirectional;
using KJ128NMainRun.RealTime.RealtimeAlarmElectricity;
using KJ128NMainRun.ConfigInfo.ConDeptEmpCounts;
using KJ128NMainRun.HistoryInfo;
using KJ128NMainRun.PathManage;
using System.Collections;
using Shine.Logs;
using Shine.Logs.LogType;
using System.Threading;
using KJ128NMainRun.Graphics;
using KJ128NMainRun.Graphics.Config;
using Wilson.Controls.Docking;
using System.IO;
using System.Runtime;
using System.Diagnostics;
using System.Xml;
using KJ128NMainRun.EmployeeManage;

namespace KJ128NInterfaceShow
{
    public partial class FrmMain : Form
    {
        #region [ 变量: 定时打印 ]

        TaskTimeBLL ttbll = new TaskTimeBLL();
        Thread th;

        #endregion

        #region 私有变量

        /// <summary>
        /// 是否记住密码
        /// </summary>
        public static bool blIsMemorize = true;

        /// <summary>
        /// 系统日志的路径
        /// </summary>
        private string strLogPath = Application.StartupPath + "\\KJ128ALog\\";

        private MainBLL mbll = new MainBLL();
        private DBAcess dbacc = new DBAcess();
        private DataSet ds;
        /// <summary>
        /// 实时超时信息
        /// </summary>
        private static FrmRealtimeOverTimeInfo froti1 = new FrmRealtimeOverTimeInfo(true);
        /// <summary>
        /// 实时区域信息
        /// </summary>
        private static RealTimeSpecialWorkTypeTerrialAlarm frtit1 = new RealTimeSpecialWorkTypeTerrialAlarm();
        /// <summary>
        /// 实时分站信息
        /// </summary>
        private static FrmRealtimeStationBreak frsb1 = new FrmRealtimeStationBreak(true);
        /// <summary>
        /// 实时超员报警信息(点击超员报警)
        /// </summary>
        private static FrmRealTimeOverEmp frtoe1 = new FrmRealTimeOverEmp();
        /// <summary>
        /// 实时低电量报警

        /// </summary>
        private static FrmRealtimeAlarmElectricity frae1 = new FrmRealtimeAlarmElectricity();
        /// <summary>
        /// 实时接收器信息
        /// </summary>
        private static FrmRealTimeStaHeadBreak frtshb1 = new FrmRealTimeStaHeadBreak(true);

        /// <summary>
        /// 实时路线报警
        /// </summary>
        private static FrmRealTimeAlarmPath frtap = new FrmRealTimeAlarmPath();

        /// <summary>
        /// 特殊工种进出区域报警设置
        /// </summary>
        
        private bool blIsClickDept = false;
        //private bool blIsClickDirectional = false;
        /// <summary>
        /// 单一声音路径
        /// </summary>
        private string strPath;
        private int intAlarm = 1;
        private string[] strAlarm = new string[7];
        private bool blIsAlarmErr = false;
        private static bool isMenu = false;
        private int intDetpCounts = 0;              //记录部门总人数

        private static Size size = new Size(120, 120);// 接收器控件的size
        private static int ppageSum = 20;           // 每页显示记录数

        /// <summary>
        /// 部门统计的用户类型, 0人员 1设备 2卡 
        /// </summary>
        private static int intDept = 0;
        /// <summary>
        /// 方向性的用户类型, 0人员 1设备 2卡 
        /// </summary>
        private static int intDirectional = 0;
        private static int displayDeptType = 0;         // 部门显示类型 0人员 1设备 2卡 
        private static int displayType = 0;         // 显示类型 0人员 1设备 2卡 
        private static int headDisplayType = 0;     //接收器显示类型 0人员 1设备 2卡 
        private static int displayFun = 3;          // 显示方式    1分站 2接收器 3分站和接收器

        /// <summary>
        /// 显示天线安装位置的附加内容

        /// </summary>
        private static string showAntennaString = ""; //显示天线安装位置的附加内容

        private StationBLL stationBLL = new StationBLL();

        // 接收器间距vspStationInfo
        private int vartical = 10;
        private int leftVartical = 0;
        private int topVartical = 0;

        /// <summary>
        /// 离开上井口都少分钟后不显示

        /// </summary>
        int intOutWellTime = 30;
        // 分辨率 
        private int varwidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

        //拖动
        private bool isMove = false;            // (设置面板) 是否移动
        private int mleft = 0;
        private int mtop = 0;

        #endregion

        private void TimePrint()
        {
            while (true)
            {
                Thread.Sleep(15000);
                ttbll.TimePrint();
            }
        }

        #region 构造函数

        public FrmMain()
        {
            InitializeComponent();


            #region 停靠保存

            //m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);


            #endregion

            //是采用环网进行配置
            if (IsRingNetwork())
            {
                tsmRNetworkConfig.Visible = true;
            }
            else
            {
                tsmRNetworkConfig.Visible = false;
            }


            //Initdisplay();                      //初始化显示设置

            //视觉效果改变时的颜色
            //if (System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsSupported)
            //{

            //}
            //else
            //{
            //    cpStationInfo.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            //    cpDepartment.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            //    BackColor = Color.FromArgb(211, 220, 233);
            //}
            //Init();                         // 初始化

            //LoadDeptTree();                 // 加载实时部门树
            th = new Thread(TimePrint);
            th.Start();
        }

        #endregion

        #region 菜单 单击事件 Click

        #region 登录系统
        //登录
        private void tsmLogin_Login_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.tsmLogin_Login.OwnerItem.Name);

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开登录菜单");

            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }

        //注销
        private void tsmLogin_LoginOut_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开注销菜单");
            LoginBLL.user = "guest";
            SettingMenuTrue(msMainMenu.Items);
            Power(false);

        }

        //用户信息
        private void tsmUserInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("adminInfo"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            adminInfo info = new adminInfo();
            info.Show(dockPanel1, DockState.Document);
        }

        private void tsmiUserGroup_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("usergroupInfo"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            usergroupInfo user = new usergroupInfo();
            user.Show(dockPanel1, DockState.Document);
        }

        private void tsmiUserPower_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("usergroup"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            usergroup use = new usergroup();
            use.Show(dockPanel1, DockState.Document);
        }

        //退出系统
        private void tsmLogin_Exit_Click(object sender, EventArgs e)
        {

            if (LoginBLL.user.Equals("KJ128AORKJ128N"))
            {
                // 终止定时打印线程
                th.Abort();
            }
            else if (LoginBLL.user == "guest")
            {

                DialogResult dre = MessageBox.Show("你没有权限关闭本软件,如想关闭本软件，请重先登录！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dre == DialogResult.Yes)
                {
                    FrmLogin frm = new FrmLogin();
                    frm.ShowDialog();
                }
            }
            else
            {
                DialogResult dre = MessageBox.Show("关闭本软件时，是否需要关闭通讯程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dre == DialogResult.No)
                //{
                //    e.Cancel = true;
                //    return;
                //}
                if (dre == DialogResult.Yes)
                {
                    #region 关闭通讯程序

                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Equals("KJ128A.Batman"))
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch { }
                            break;
                        }
                    }

                    #endregion
                }

                #region [保存界面布局]

                // 保存界面布局
                //string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
                //if (m_bSaveLayout)
                //{
                //    dockPanel1.SaveAsXml(configFile);
                //}
                //else if (File.Exists(configFile))
                //{
                //    File.Delete(configFile);
                //}

                #endregion

                // 终止定时打印线程
                th.Abort();


                #region 退出应用程序进程

                Process p = Process.GetCurrentProcess();
                p.CloseMainWindow();
                if (!p.HasExited)
                {
                    p.Kill();
                }

                #endregion
            }
        }


        #endregion

        #region 基本配置

        //分站及相关配置
        private void tsmStationConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmStationManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开分站及相关配置菜单");

            FrmStationManage frmSM = new FrmStationManage();
            frmSM.Show(dockPanel1, DockState.Document);
            //Init();
            // InitStationData();              // 初始化加载分站信息

        }

        //环网配置
        private void tsmRNetworkConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmIpConfig"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开环网配置菜单");

            FrmIpConfig frmIpCon = new FrmIpConfig();
            frmIpCon.Show(dockPanel1, DockState.Document);
        }

        //员工档案管理
        private void tsmEmployeeManager_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("frmEmployeesInfo"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工档案管理菜单");

            //frmEmployeesInfo frmE = new frmEmployeesInfo();
            //frmE.Show(dockPanel1, DockState.Document);
        }

        //发码器设置

        private void tsmCodeBlockManager_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmSetCodeSender"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开发码器配置菜单");

            FrmSetCodeSender frm = new FrmSetCodeSender();
            frm.Show(dockPanel1, DockState.Document);
        }

        //部门、工种、职务、证书
        private void tsmDepartmentManager_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmDepartmentManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门、工种、职务、证书菜单");

            FrmDepartmentManage frmDepartmentManage = new FrmDepartmentManage();
            frmDepartmentManage.Show(dockPanel1, DockState.Document);
        }

        //设备档案管理
        private void tsmEquipmentManager_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmEquManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开设备档案管理菜单");

            FrmEquManage frm = new FrmEquManage();
            frm.Show(dockPanel1, DockState.Document);
        }

        //方向性管理
        private void tsmFrmDirectionalManage_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmDirectionalManageAntenna"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开方向性配置菜单");

            FrmDirectionalManageAntenna frm = new FrmDirectionalManageAntenna();
            frm.Show(dockPanel1, DockState.Document);

            //FrmDirectionalManage frm = new FrmDirectionalManage();
            //frm.Show(dockPanel1, DockState.Document);
        }

        //路径基本信息
        private void tsPatnInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmPathInfo"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            FrmPathInfo frm = new FrmPathInfo();
            frm.Show(dockPanel1, DockState.Document);
            //frm.Dispose();
        }

        //员工路径关系信息
        private void tspathEmp_Click(object sender, EventArgs e)
        {
            //判断窗体是否存在
            if (Searcher.FindFormByName("FrmPathEmp"))
            {
                return;

            }
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            FrmPathEmp frm = new FrmPathEmp();
            frm.Show(dockPanel1, DockState.Document);
            //frm.Show();
            //frm.Dispose();
        }

        //路径详细信息
        private void tspathDetail_Click(object sender, EventArgs e)
        {
            //判断窗体是否存在
            if (Searcher.FindFormByName("FrmPathDetail"))
            {
                return;

            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            FrmPathDetail frm = new FrmPathDetail();
            frm.Show(dockPanel1, DockState.Document);
            //frm.Dispose();
        }

        //特殊工种进出区域报警设置
        private void SpecialWorkTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断窗体是否存在
            if (Searcher.FindFormByName("SpecialWorkTypeTerrialSet"))
            {
                return;

            }

            SpecialWorkTypeTerrialSet swtts = new SpecialWorkTypeTerrialSet();
            if (!IsValidate())
            {
                return;
            }

            swtts.Show(dockPanel1, DockState.Document);

        }

        //区域管理
        private void tsmAreaManager_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmAreaManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开区域配置菜单");

            FrmAreaManage frm = new FrmAreaManage();
            frm.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #region 辅助配置


        //报警参数设置
        private void tsmAlarmParameterManager_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmAlarmSet"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开报警参数设置菜单");

            FrmAlarmSet frm = new FrmAlarmSet();
            frm.Show(dockPanel1, DockState.Document);
        }

        //部门工时单价
        private void MenuDeptUnitPrice_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("DepartmnetSalarySet"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            DepartmnetSalarySet dss = new DepartmnetSalarySet();
            dss.Show(dockPanel1, DockState.Document);
        }

        // 定时打印
        private void tsmTimePrint_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmTimePrint"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }
            FrmTimePrint frm = new FrmTimePrint();
            frm.Show(dockPanel1, DockState.Document);
        }




        #endregion

        #region 实时数据

        //实时发码器信息
        private void tsmiRealTimeCodeSenderInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("RealTimeMonitorInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时发码器信息菜单");

            RealTimeMonitorInfo rtmi = new RealTimeMonitorInfo("");
            rtmi.Show(dockPanel1, DockState.Document);
        }

        //实时进接收器信息
        private void tsmiRealTimeInStationHeadInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("RealTimeInOutStationHeadInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时进接收器信息菜单");

            RealTimeInOutStationHeadInfo rtioshi = new RealTimeInOutStationHeadInfo();
            rtioshi.Show(dockPanel1, DockState.Document);
        }

        //实时进出天线
        private void tsmiRealTimeInOutAntennaInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("RealTimeInOutAntennaInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时进出天线菜单");

            RealTimeInOutAntennaInfo rtioai = new RealTimeInOutAntennaInfo();
            rtioai.Show(dockPanel1, DockState.Document);
        }

        //实时下井信息
        private void tsmRealTimeInWellInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInWellInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时下井信息菜单");

            FrmRealTimeInWellInfo frtiwi = new FrmRealTimeInWellInfo(false, "0");
            frtiwi.Show(dockPanel1, DockState.Document);
        }

        //实时区域信息
        private void tsmiRealTimeAreaInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInTerritorial"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时区域信息菜单");

            FrmRealTimeInTerritorial frtit = new FrmRealTimeInTerritorial(false);
            frtit.Show(dockPanel1, DockState.Document);
        }

        //实时超时信息
        private void tsmiRealTimeOverTimeInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealtimeOverTimeInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时超时信息菜单");

            FrmRealtimeOverTimeInfo frm = new FrmRealtimeOverTimeInfo(false);
            frm.Show(dockPanel1, DockState.Document);
        }

        //实时分站信息
        private void tsmiRealtimeStationBreak_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealtimeStationBreak"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时分站信息菜单");

            FrmRealtimeStationBreak frm = new FrmRealtimeStationBreak(false);
            
            frm.Show(dockPanel1, DockState.Document);

            frm.Refresh();
        }

        //实时接收器信息
        private void tsmiRealTimeStaHeadBreak_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeStaHeadBreak"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时接收器信息菜单");

            FrmRealTimeStaHeadBreak frtshb = new FrmRealTimeStaHeadBreak(false);
            frtshb.Show(dockPanel1, DockState.Document);
        }

        //实时方向性信息
        private void tsmRealTimeDirectional_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeDirectional"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时方向性信息菜单");

            FrmRealTimeDirectional frtd = new FrmRealTimeDirectional(false, "", 0, "");
            frtd.Show(dockPanel1, DockState.Document);
        }

        //发码器低电量信息
        private void tsmiRealtimeAlarmElectricity_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealtimeAlarmElectricity"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时发码器低电量信息菜单");

            FrmRealtimeAlarmElectricity frtae = new FrmRealtimeAlarmElectricity();
            frtae.Show(dockPanel1, DockState.Document);
        }

        //实时井下人员汇总信息
        private void tsmiEmployeeClassify_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("EmployeeClassify"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时井下人员汇总信息菜单");

            EmployeeClassify frm = new EmployeeClassify();
            frm.Show(dockPanel1, DockState.Document);
        }

        //实时下井人员名单显示
        private void tsmFrmRealTime_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInMineEmp"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时下井人员名单显示菜单");

            FrmRealTimeInMineEmp frm = new KJ128NMainRun.RealTime.FrmRealTimeInMineEmp(dockPanel1);
            frm.Show(dockPanel1, DockState.Document);
        }

        //实时人员班次查询
        private void MenuRealTimeAttendanceQuery_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("RealTimeAttendanceQuery"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时人员班次查询菜单");

            RealTimeAttendanceQuery rtaq = new RealTimeAttendanceQuery();
            rtaq.Show(dockPanel1, DockState.Document);
        }

        //实时超员信息
        private void tsmiRealTimeOverEmp_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeOverEmp"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时超员信息菜单");

            FrmRealTimeOverEmp frtoe = new FrmRealTimeOverEmp();
            frtoe.Show(dockPanel1, DockState.Document);
        }

        //实时路线报警信息
        private void tsmiRealtimeAlarmPath_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeAlarmPath"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时路线报警信息菜单");

            FrmRealTimeAlarmPath frm = new FrmRealTimeAlarmPath();
            frm.Show(dockPanel1, DockState.Document);
        }

        // 实时巷道分支方向性
        private void tsmiRTDirectional_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRTDirectionalAntenna"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时巷道分支方向性信息菜单");

            FrmRTDirectionalAntenna frm = new FrmRTDirectionalAntenna();
            frm.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #region 历史数据

        // 历史巷道分支方向性
        private void tsmiHisDirectional_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisDirectionalAntenna"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史巷道分支方向性信息菜单");

            FrmHisDirectionalAntenna frm = new FrmHisDirectionalAntenna();
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史进出天线信息
        private void tsmiHistoryInOutAntenna_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHistoryInOutAntenna"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史进出天线信息菜单");

            FrmHistoryInOutAntenna fhioa = new FrmHistoryInOutAntenna();
            fhioa.Show(dockPanel1, DockState.Document);
        }

        //历史进出接收器信息
        private void tsmiHistoryInOutStationHeadInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInOutStationHead"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史进出接收器信息菜单");

            FrmHisInOutStationHead fhiosh = new FrmHisInOutStationHead();
            fhiosh.Show(dockPanel1, DockState.Document);
        }

        // 历史下井信息
        private void tsmiHistroyInOutInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInMineRecordSet"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史下井信息菜单");

            FrmHisInMineRecordSet frm = new FrmHisInMineRecordSet();
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史区域信息
        private void tsmiHisInTerritorial_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInTerritorial"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史区域信息菜单");

            FrmHisInTerritorial frm = new FrmHisInTerritorial();
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史超时信息
        private void tsmiHisOverTimeInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisOverTimeInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史超时信息菜单");

            FrmHisOverTimeInfo frm = new FrmHisOverTimeInfo();
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史分站故障信息
        private void tsmiHisStationBreak_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisStationBreak"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史分站故障信息菜单");

            FrmHisStationBreak frm = new FrmHisStationBreak(1);
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史接收器故障信息
        private void tsmiHisStaHeadBreak_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisStationBreak"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史接收器故障信息菜单");

            FrmHisStationBreak frm = new FrmHisStationBreak(2);
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史下井记录次数统计
        private void tsmiHistoryInWellTimeTotal_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInOutMine"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史下井记录次数统计菜单");

            FrmHisInOutMine fhom = new FrmHisInOutMine();
            fhom.Show(dockPanel1, DockState.Document);
        }

        //历史下井记录人数统计
        private void tsmiHistoryInWell_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHistoryTotalInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史下井记录人数统计菜单");

            FrmHistoryTotalInfo fhti = new FrmHistoryTotalInfo();
            fhti.Show(dockPanel1, DockState.Document);
        }

        //历史超员信息
        private void tsmiHisOverTimeOverEmp_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisOverEmp"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史超员信息菜单");

            FrmHisOverEmp frmoe = new FrmHisOverEmp();
            frmoe.Show(dockPanel1, DockState.Document);
        }

        //历史路线报警信息
        private void tsHisPathAlarm_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisPathAlert"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开路线报警信息菜单");

            FrmHisPathAlert frm = new FrmHisPathAlert();
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史特殊工种进出区域报警信息查询
        private void SpcialWorkTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("HistorySpecialWorkTypeTerrialAlarm"))
            {
                return;
            }

            HistorySpecialWorkTypeTerrialAlarm frm = new HistorySpecialWorkTypeTerrialAlarm();
            frm.Show(dockPanel1, DockState.Document);
        }

        /*
         送审 添加
         */
        #region 送审 添加

        // 实时按人员查询
        private void tsmiRTEmp_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRTInfo"))
            {
                return;
            }

            FrmRTInfo frm = new FrmRTInfo();
            frm.Show(dockPanel1, DockState.Document);

        }
        // 历史按人员查询
        private void tsmiHisEmp_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInfo"))
            {
                return;
            }

            FrmHisInfo frm = new FrmHisInfo();
            frm.Show(dockPanel1, DockState.Document);
        }
        // 历史进出读卡分站信息
        private void tsmiHisInOutStationHead_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInOutReceiver"))
            {
                return;
            }

            FrmHisInOutReceiver frm = new FrmHisInOutReceiver();
            frm.Show(dockPanel1, DockState.Document);

        }

        // 按时间段查询
        private void tsmiRtHisTime_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmQueryTime"))
            {
                return;
            }

            FrmQueryTime frm = new FrmQueryTime();
            frm.Show(dockPanel1, DockState.Document);
        }

        #endregion
        
        // 实时区域
        private void tsmiRTArea_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("HistorySpecialWorkTypeTerrialAlarm"))
            {
                return;
            }

            HistorySpecialWorkTypeTerrialAlarm frm = new HistorySpecialWorkTypeTerrialAlarm();
            frm.Show(dockPanel1, DockState.Document);
            frm.TabText = "实时区域报警";
            frm.Text = "实时区域报警";
        }

        private void tsmiRTAreaD_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRTArea"))
            {
                return;
            }

            FrmRTArea frm = new FrmRTArea();
            frm.Show(dockPanel1, DockState.Document);
        }

        private void tsmiHisAreaD_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisArea"))
            {
                return;
            }

            FrmHisArea frm = new FrmHisArea();
            frm.Show(dockPanel1, DockState.Document);
        }       

        #endregion

        #region 考勤信息
        //考勤班制设置
        private void InfoClassMenu_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("ClassInfoManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤班制设置菜单");

            ClassInfoManage cim = new ClassInfoManage();
            cim.Show(dockPanel1, DockState.Document);
        }

        //考勤时段设置
        private void MenuTimerInterval_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmTimerInterval"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤时段设置菜单");

            FrmTimerInterval FrmTI = new FrmTimerInterval();
            FrmTI.Show(dockPanel1, DockState.Document);
        }

        //假别设置
        private void MenuHolidayClass_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("HolidayTypeSet"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开假别设置菜单");

            HolidayTypeSet hcs = new HolidayTypeSet();
            hcs.Show(dockPanel1, DockState.Document);
        }

        //请假管理
        private void MenuHolidayManage_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("HolidayMange"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开请假管理菜单");

            HolidayMange HM = new HolidayMange();
            HM.Show(dockPanel1, DockState.Document);
        }

        //历史考勤补单
        private void MenuAddHistoryAttendance_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AddHistoryAttendance"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史考勤补单菜单");

            AddHistoryAttendance aa = new AddHistoryAttendance();
            aa.Show(dockPanel1, DockState.Document);
        }

        //个人出勤统计
        private void MenuAttendacePersonelStatistic_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendacePersonelStatistic"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开个人出勤率统计菜单");

            //AttendacePersonelStatistic aps = new AttendacePersonelStatistic();
            //aps.Show(dockPanel1, DockState.Document);
        }

        //部门逐日出勤统计
        private void MenuAttendanceDayByDayStatistic_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceDayByDayStatistic"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门逐日出勤统计菜单");

            AttendanceDayByDayStatistic adds = new AttendanceDayByDayStatistic();
            adds.Show(dockPanel1, DockState.Document);
        }

        //员工考勤原始数据
        private void MenuAttendanceInitialData_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceInitialData"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工考勤原始数据菜单");

            AttendanceInitialData aid = new AttendanceInitialData();
            aid.Show(dockPanel1, DockState.Document);
        }

        //人员考勤明细
        private void MenuAttendanceParticulars_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceParticulars"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开人员考勤明细菜单");

            AttendanceParticulars ap = new AttendanceParticulars();
            ap.Show(dockPanel1, DockState.Document);

        }

        //部门人员出勤率统计
        private void MenuAttendanceRateStatistic_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceRateStatistic"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门人员出勤率统计菜单");

            AttendanceRateStatistic ars = new AttendanceRateStatistic();
            ars.Show(dockPanel1, DockState.Document);
        }

        //实时考勤补单
        private void MenuRealTimeAdd_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceRealTime"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时考勤补单菜单");

            AttendanceRealTime art = new AttendanceRealTime();
            art.Show(dockPanel1, DockState.Document);
        }

        //历史上下井按班次查询
        private void MenuHistoryClass_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("HistoryQueryByClass"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史上下井按班次查询菜单");

            HistoryQueryByClass hqbc = new HistoryQueryByClass();
            hqbc.Show(dockPanel1, DockState.Document);
        }

        //员工出勤劳动报表
        private void MenuAttendanceSalary_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceQuerySalary"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工出勤劳动报表菜单");

            AttendanceQuerySalary aqs = new AttendanceQuerySalary();
            aqs.Show(dockPanel1, DockState.Document);
        }

        //各部门干部下井统计报表
        private void MenuAttendanceStatisticByDuty_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceStatisticByDuty"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开各部门干部下井统计报表菜单");

            AttendanceStatisticByDuty asbd = new AttendanceStatisticByDuty();
            asbd.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region 配置信息
        //分站接收器配置信息
        private void tsmFrmStaHeadInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmConStaHeadInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开分站接收器配置信息菜单");

            FrmConStaHeadInfo frm = new FrmConStaHeadInfo();
            frm.Show(dockPanel1, DockState.Document);
        }

        //员工配置信息
        private void 员工配置信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmConEmployeeInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工配置信息菜单");

            FrmConEmployeeInfo frm = new FrmConEmployeeInfo();
            frm.Show(dockPanel1, DockState.Document);
        }

        //部门工种职务配置信息
        private void 部门工种职务配置信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmConDeptManage"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门工种职务配置信息菜单");

            FrmConDeptManage frm = new FrmConDeptManage();
            frm.Show(dockPanel1, DockState.Document);
        }

        //部门人数汇总信息

        private void tsmiConDeptEmpCounts_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmConDeptEmpCounts"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门人数汇总信息菜单");

            FrmConDeptEmpCounts frm = new FrmConDeptEmpCounts();
            frm.Show(dockPanel1, DockState.Document);
        }
        //设备配置信息
        private void 设备配置信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmConEquManage"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开设备配置信息菜单");

            FrmConEquManage frm = new FrmConEquManage();
            frm.Show(dockPanel1, DockState.Document);
        }

        //发码器配置信息

        private void tsmConCodeSenderInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmConCodeSenderInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开发码器配置信息菜单");

            FrmConCodeSenderInfo frm = new FrmConCodeSenderInfo();
            frm.Show(dockPanel1, DockState.Document);
        }

        // 历史每月下井次数统计
        private void tsmHisMonthEmp_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmStatMonthEmpInMine"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史每月下井次数统计菜单");
            FrmStatMonthEmpInMine frm = new FrmStatMonthEmpInMine();
            frm.Show(dockPanel1, DockState.Document);
        }

        //方向性配置信息

        private void tsmFrmConDirectionalManage_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmConDirectionalManage"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开方向性配置信息菜单");

            FrmConDirectionalManage frm = new FrmConDirectionalManage();
            frm.Show(dockPanel1, DockState.Document);
        }

        //区域设置信息
        private void tsmiConAreaManage_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmConAreaManage"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开区域设置信息菜单");

            FrmConAreaManage frm = new FrmConAreaManage();
            frm.Show(dockPanel1, DockState.Document);
        }

        private void tsmEmpPsotInfo_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmEmpPost"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工岗位配置信息菜单");

            FrmEmpPost frm = new FrmEmpPost();
            frm.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #region 图形

        //历史轨迹回放
        private void tsmtHistroy_Click(object sender, EventArgs e)
        {
            //if (Searcher.FindFormByName("FrmCfgRealTime"))
            //{
            //    return;
            //}

            FrmCfgRealTime frm = new KJ128NMainRun.Graphics.Config.FrmCfgRealTime(2);
            frm.Show(dockPanel1, DockState.Document);
        }

        //图形图片配置
        private void tsmtPicconfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRouteConfig"))
            {
                return;
            }

            FrmRouteConfig frmRouteCfig = new KJ128NMainRun.Graphics.FrmRouteConfig();
            frmRouteCfig.Show(dockPanel1, DockState.Document);
        }

        //实时分布
        private void tsmtReadtime_Click(object sender, EventArgs e)
        {
            //if (Searcher.FindFormByName("FrmCfgRealTime"))
            //{
            //    return;
            //}

            FrmCfgRealTime frm = new KJ128NMainRun.Graphics.Config.FrmCfgRealTime(1);
            frm.Show(dockPanel1, DockState.Document);
        }

        //分站及路径配置
        private void tsmtRouteConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmPicConfig"))
            {
                return;
            }

            FrmPicConfig frmPicCfig = new FrmPicConfig();
            frmPicCfig.Show(dockPanel1, DockState.Document);
        }

        //图形配置文件系统
        private void tsmiGFSS_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmCreateConfig"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            FrmCreateConfig frm = new FrmCreateConfig();
            frm.Show(dockPanel1, DockState.Document);
        }

        private void tsmiRGGS_Click(object sender, EventArgs e)
        {
            //if (Searcher.FindFormByName("FrmCfgRealTime"))
            //{
            //    return;
            //}

            FrmCfgRealTime frm = new KJ128NMainRun.Graphics.Config.FrmCfgRealTime();
            frm.Show(dockPanel1, DockState.Document);
        }

        private void tsmiDpicConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmAddPic"))
            {
                return;
            }

            KJ128NMainRun.Graphics.DPic.FrmAddPic f = new KJ128NMainRun.Graphics.DPic.FrmAddPic();
            f.Show(dockPanel1, DockState.Document);
        }

        private void 多图系统轨迹配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmDRouteConfig"))
            {
                return;
            }

            KJ128NMainRun.Graphics.DPic.FrmDRouteConfig f = new KJ128NMainRun.Graphics.DPic.FrmDRouteConfig();
            f.Show(dockPanel1, DockState.Document);
        }

        private void 多图图形配置文件系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KJ128NMainRun.Graphics.DPic.FrmDCreateConfig f = new KJ128NMainRun.Graphics.DPic.FrmDCreateConfig();
            f.Show();
        }

        private void 多图图层图形系统DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KJ128NMainRun.Graphics.DPic.FrmDCfgRealTime f = new KJ128NMainRun.Graphics.DPic.FrmDCfgRealTime();
            f.Show();
        }

        private void 实时轨迹播放BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KJ128NMainRun.Graphics.frmRealTimeRoute f = new frmRealTimeRoute();
            f.Show();
        }

        #endregion

        #region 求救

        /// <summary>
        /// 实时求救
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiRealTimeHelp_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeEmpHelp"))
            {
                return;
            }

            FrmRealTimeEmpHelp frm = new FrmRealTimeEmpHelp();
            frm.Show(dockPanel1, DockState.Document);
        }

        /// <summary>
        /// 历史求救
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiHisTimeHelp_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisEmpHelp"))
            {
                return;
            }

            FrmHisEmpHelp frm = new FrmHisEmpHelp();
            frm.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #region 工具

        //KJ128A系统备份与还原
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\备份\beifen.exe";

            if (Searcher.FindProcessByName("beifen"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }


            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("系统备份与还原工具不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //数据库备份和还原
        private void 数据库备份还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\数据库备份还原.exe";
            if (Searcher.FindProcessByName("数据库备份还原"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            // 数据库备份和还原
            //KJ128NMainRun.DataOperate.FrmDataManage frm = new KJ128NMainRun.DataOperate.FrmDataManage();
            //frm.Show(dockPanel1, DockState.Document);

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("数据库备份还原工具不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void tsmiSysRunView_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\数据库备份还原.exe";

            if (Searcher.FindProcessByName("数据库备份还原"))
            {
                return;
            }

            ////验证用户密码
            //if (!IsValidate())
            //{
            //    return;
            //}

            //// 数据库备份和还原
            ////KJ128NMainRun.DataOperate.FrmDataManage frm = new KJ128NMainRun.DataOperate.FrmDataManage();
            ////frm.Show(dockPanel1, DockState.Document);
            //string path = Application.StartupPath + @"\数据库备份还原.exe";

            //if (File.Exists(path))
            //{
            //    Process.Start(path);
            //}
            //else
            //{
            //    MessageBox.Show("数据库备份还原工具不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        //数据库导入、导出Excel
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\导入导出\daochu.exe";

            if (Searcher.FindProcessByName("daochu"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("数据库导入、导出Excel工具不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //热备系统配置信息
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\KJ128AConfig.exe";

            if (Searcher.FindProcessByName("KJ128AConfig"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            // 数据库备份和还原
            //KJ128NMainRun.DataOperate.FrmDataManage frm = new KJ128NMainRun.DataOperate.FrmDataManage();
            //frm.Show(dockPanel1, DockState.Document);

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("热备配置工具不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //系统运行日志查看
        private void tsmiLogView_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\KJ128ALogView.exe";

            if (Searcher.FindProcessByName("KJ128ALogView"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("系统日志查看程序不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region [监测]

        //实时岗位信息
        private void tsmRTEmpPost_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimePostInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时员工岗位信息菜单");

            FrmRealTimePostInfo frm = new FrmRealTimePostInfo();
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史岗位信息
        private void tsmHisEmpPost_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHistoryPostInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史员工岗位信息菜单");

            FrmHistoryPostInfo frm = new FrmHistoryPostInfo();
            frm.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #region 查询
        //接收器间行走时间信息
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("Form_Station_Head_time"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开接收器行走时间信息菜单");

            Form_Station_Head_time fsht = new Form_Station_Head_time();
            fsht.Show(dockPanel1, DockState.Document);
        }

        //实时重点区域信息
        private void tsmiRTKeyArea_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInOutKeyArea"))
            {
                return;
            }

            FrmRealTimeInOutKeyArea frm = new FrmRealTimeInOutKeyArea();
            frm.Show(dockPanel1, DockState.Document);
            //frm.Show();

        }

        //历史重点区域信息
        private void tsmiHisKeyArea_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHistoryInOutKeyArea"))
            {
                return;
            }

            FrmHistoryInOutKeyArea frm = new FrmHistoryInOutKeyArea();
            frm.Show(dockPanel1, DockState.Document);
        }

        //实时限制区域信息
        private void tsmiRTConfineArea_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInOutConfineArea"))
            {
                return;
            }

            FrmRealTimeInOutConfineArea frm = new FrmRealTimeInOutConfineArea();
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史限制区域信息
        private void tsmiHisConfineArea_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHistoryInOutConfineArea"))
            {
                return;
            }

            FrmHistoryInOutConfineArea frm = new FrmHistoryInOutConfineArea();
            frm.Show(dockPanel1, DockState.Document);
        }

        //实时地域信息
        private void tsmiRTClime_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeClime"))
            {
                return;
            }

            FrmRealTimeClime frm = new FrmRealTimeClime();
            frm.Show(dockPanel1, DockState.Document);
        }

        //历史地域信息
        private void tsmiHisClime_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHistoryClime"))
            {
                return;
            }

            FrmHistoryClime frm = new FrmHistoryClime();
            frm.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #region [统计]

        //分站接收器故障统计
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("HisBadstation"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开分站接收器故障统计菜单");

            HisBadstation hbs = new HisBadstation();
            hbs.Show(dockPanel1, DockState.Document);
        }


        #region 实时进出探测器人数统计

        private void tsmiStationHeadStat_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmStationHeadStat"))
            {
                return;
            }

            FrmStationHeadStat frm = new FrmStationHeadStat();
            frm.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #endregion

        #region 关于

        private void tsmAboutInfo_Click(object sender, EventArgs e)
        {
            FrmAboutUs frm = new FrmAboutUs();
            frm.ShowDialog();
        }

        #endregion

        #region [ 菜单点击事件 ]

        private void rtPathCheck_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimePathCheck"))
            {
                return;
            }

            FrmRealTimePathCheck frm = new FrmRealTimePathCheck();
            frm.Show(dockPanel1, DockState.Document);
        }

        private void hisPathCheck_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisPathCheck"))
            {
                return;
            }

            FrmHisPathCheck frm = new FrmHisPathCheck();
            frm.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #endregion

        #region 默认权限菜单
        /// <summary>
        /// 权限管理
        /// </summary>
        /// <param name="bl">true 通过验证，false 未通过验证</param>
        private void Power(bool bl)
        {
            tsmUserPopedom.Enabled = bl;
            tsmAttendanceInfoSet.Enabled = bl;
            tsmBaseConfig.Enabled = bl;
            tsmAssistConfig.Enabled = bl;
            tsmLogin_LoginOut.Enabled = bl;
            tsmLogin_Login.Enabled = !bl;
            tsbtnLogin.Enabled = !bl;
            tsbtnExit.Enabled = bl;

        }
        #endregion

        #region [ 事件: 窗体关闭事件 ]

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(LoginBLL.user.Equals("KJ128AORKJ128N"))
            {

                // 终止定时打印线程
                th.Abort();
            }
            else if (LoginBLL.user == "guest" && !New_DBAcess.blIsClient)
            {
                DialogResult dre = MessageBox.Show("你没有权限关闭本软件,如想关闭本软件，请重先登录！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dre == DialogResult.Yes)
                {
                    FrmLogin frm = new FrmLogin();
                    frm.ShowDialog();
                }
                e.Cancel = true;
            }
            else
            {
                
                DialogResult dre = MessageBox.Show("关闭本软件时，是否需要关闭通讯程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dre == DialogResult.No)
                //{
                //    e.Cancel = true;
                //    return;
                //}
                if (dre == DialogResult.Yes)
                {
                    //关闭通讯程序
                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Equals("KJ128A.Batman"))
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch { }
                            break;
                        }
                    }
                }

                #region [保存界面布局]

                // 保存界面布局
                //string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
                //if (m_bSaveLayout)
                //{
                //    dockPanel1.SaveAsXml(configFile);
                //}
                //else if (File.Exists(configFile))
                //{
                //    File.Delete(configFile);
                //}

                #endregion

                // 终止定时打印线程
                th.Abort();


                #region 退出应用程序进程

                Process p = Process.GetCurrentProcess();
                p.Kill();

                #endregion
            }
        }

        #endregion

        #region [ 方法: 菜单处理相关 ]

        #region 窗体事件
        int cc = 0;
        private void FrmMain_Activated(object sender, EventArgs e)
        {
            if (cc == 0)
            {
                cc++;
                if (!New_DBAcess.blIsClient)
                {
                    if (LoginBLL.user == "3shine")
                    {

                        GetMenus();
                    }
                    else
                    {
                        Power(false);                   // 权限管理
                    }
                    //tsmLoginManage.Enabled = true;
                }
            }
            //this.tsmLogin_Login.Enabled = true;


        }
        
        //private void FrmMain_Load(object sender, EventArgs e)
        //{
        //    setData();
        //    this.tsmLogin_Login.Enabled = true;
        //    tsmLoginManage.Enabled = true;
        //}

        #endregion 

        #region 设置树形控件
        public void TreeViewData(TreeView treeview)
        {
            foreach (ToolStripItem item in msMainMenu.Items)
            {
                TreeNode node = new TreeNode();
                getSonMenu(item, node);
                node.Text = item.Text.Substring(0,item.Text.Length-4);
                node.Name = item.Name;
                treeview.Nodes.Add(node);
            }
        }

        public void getSonMenu(ToolStripItem item, TreeNode node)
        {
            ToolStripMenuItem tItem = (ToolStripMenuItem)item;

            if (tItem.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem titem in tItem.DropDownItems)
                {
                    if (titem is ToolStripMenuItem)
                    {
                        ToolStripMenuItem toolMenu = (ToolStripMenuItem)titem;
                        TreeNode node1 = new TreeNode();
                        node1.Text = titem.Text.Substring(0, titem.Text.Length - 4);
                        node1.Name = titem.Name;
                        node1.Collapse(false);
                        node.Nodes.Add(node1);
                        getSonMenu(toolMenu, node1);
                    }
                }
            }
            else
            {
                return;
            }
        }
        #endregion

        #region [ 方法: 将所有菜单设置为可用 ]

        /// <summary>
        /// 将所有菜单设置为可用
        /// </summary>
        /// <param name="items"></param>
        private void SettingMenuTrue(ToolStripItemCollection items)
        {
            foreach (ToolStripItem tsi in items)
            {
                if (tsi is ToolStripMenuItem)
                {
                    tsi.Enabled = true;
                    if (((ToolStripMenuItem)tsi).DropDownItems.Count > 0)
                    {
                        SettingMenuTrue(((ToolStripMenuItem)tsi).DropDownItems);
                    }
                }
            }
        }

        #endregion

        #region 保存菜单信息到数据库
        public void GetMenus()
        {
            MenuBLL mbll = new MenuBLL();
            string strSQL = "";
            foreach (ToolStripItem item in msMainMenu.Items)
            {
                getSonMenus(item, "", ref strSQL);
            }
            mbll.deleteMenu(strSQL);
        }
        public void getSonMenus(ToolStripItem item, string pName, ref string strSQL)
        {

            MenuBLL bll = new MenuBLL();
            ToolStripMenuItem tItem = (ToolStripMenuItem)item;
            tItem.Enabled = true;
            strSQL = strSQL + "'" + tItem.Name + "',";
            bll.addMenu(tItem.Text, pName, tItem.Name);
            if (tItem.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem titem in tItem.DropDownItems)
                {
                    ToolStripMenuItem toolMenu = (ToolStripMenuItem)titem;
                    getSonMenus(toolMenu, tItem.Name, ref strSQL);
                }
            }
        }
        #endregion

        #region 菜单管理
        public void setData()
        {
            UserGroupBLL bll = new UserGroupBLL();
            DataSet ds = bll.selectUserGroups(LoginBLL.user.ToString());
            Hashtable ht = new Hashtable();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[3].ToString().Trim() == "")
                    {
                        if (ht.Contains(dr[2].ToString()))
                        {
                            ht[dr[2].ToString()] = Convert.ToBoolean(dr[1]);
                        }
                        else
                        {
                            ht.Add(dr[2].ToString(), Convert.ToBoolean(dr[1]));
                        }
                    }
                    else
                    {
                        if (ht.Contains(dr[2].ToString()))
                        {
                            ht[dr[2].ToString()] = false;
                        }
                        else
                        {
                            ht.Add(dr[2].ToString(), false);
                        }
                    }
                }
                foreach (ToolStripItem item in msMainMenu.Items)
                {
                    getSonMenus(item, ht);
                }
            }
        }

        public void getSonMenus(ToolStripItem item, Hashtable ht)
        {
            ToolStripMenuItem tItem = (ToolStripMenuItem)item;
            tItem.Enabled = Convert.ToBoolean(ht[tItem.Name]);

            if (tItem.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem titem in tItem.DropDownItems)
                {
                    ToolStripMenuItem toolMenu = (ToolStripMenuItem)titem;
                    getSonMenus(toolMenu, ht);
                }
            }
        }
        #endregion

        #endregion

        #region [ 方法: 用户验证密码 ]

        private bool IsValidate()
        {
            if (blIsMemorize && !LoginBLL.user.Equals("guest"))
            {
                return true;
            }
            FrmValidate frm = new FrmValidate();
            frm.ShowDialog();

            if (!frm.IsValidate)
            {
                frm.Dispose();
                return false;
            }

            frm.Dispose();

            return true;
        }

        #endregion        

        #region [窗体加载]

        private void FrmMain_Load(object sender, EventArgs e)
        {

            #region 开始检测文件

            //FileWatch();

            #endregion

            #region 判断主、备机、客户端

            string configPath = Application.StartupPath + @"\HostIPConfig.xml";

            XmlDocument docConfig = new XmlDocument();

            if (File.Exists(configPath))
            {
                //MessageBox.Show("HostIPConfig.xml文件不存在,配置文件后会自动生成此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                docConfig.Load(configPath);

                string isStartHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;

                if (isStartHost.ToUpper() == "TRUE")
                {

                    string isHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[1].InnerText;

                    if (isHost.ToUpper() == "TRUE")
                    {
                        this.Text = "KJ128A型矿用人员管理系统--[主机]";
                    }
                    else
                    {
                        this.Text = "KJ128A型矿用人员管理系统--[备机]";
                    }

                }
                else
                {
                    if (New_DBAcess.blIsClient)
                    {
                        this.Text = "KJ128A型矿用人员管理系统--[客户端]";
                    }
                }
            }

            #endregion

            #region 加载窗体设置

            //string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

            //if (File.Exists(configFile))
            //    dockPanel1.LoadFromXml(configFile, m_deserializeDockContent);

            #endregion

            #region 主界面

            FrmLeftTree frm = new FrmLeftTree();

            frm.Show(dockPanel1, DockState.Document);

            #endregion

            #region 导航窗体

            FrmNav frmNav = new FrmNav();
            frmNav.Show(dockPanel1, DockState.Document);

            #endregion

            #region 报警栏

            FrmBottomAlert frmAlert = new FrmBottomAlert();

            frmAlert.Show(dockPanel1, DockState.DockBottom);

            #endregion

            #region 关闭欢迎画面

            FrmWelcome frmWelcome = (FrmWelcome)Application.OpenForms["FrmWelcome"];
            if (frmWelcome != null)
            {
                frmWelcome.Close();
            }

            #endregion

            #region 是否是客户端程序 

            if (New_DBAcess.blIsClient)
            {
                tsmLoginManage.Enabled = false;             //登录菜单
                tsmBaseConfig.Enabled = false;              //配置菜单
                工具TToolStripMenuItem.Enabled = false;     //工具菜单
                选项ToolStripMenuItem.Enabled = false;      //选项菜单
                tsbtnLogin.Enabled = false;                 //状态栏-登录
            }

            #endregion
        }

        #endregion

        #region [停靠私有变量]

        //private DeserializeDockContent m_deserializeDockContent;

        //private bool m_bSaveLayout = true;

        #endregion

        #region 保存菜单


        private void SetMenuAll(ToolStripItemCollection items)
        {
            KJ128NDataBase.DBAcess dba = new KJ128NDataBase.DBAcess();

            foreach (ToolStripItem tsi in items)
            {
                if (tsi is ToolStripMenuItem)
                {

                    //ToolStrip TS =  tsi.Owner;

                    string str = string.Format("insert into menus1(PMenuID,Title,name) values({2},'{0}','{1}')", ((ToolStripMenuItem)tsi).Text.Substring(0, ((ToolStripMenuItem)tsi).Text.Length - 4), ((ToolStripMenuItem)tsi).Name
                    , ((ToolStripMenuItem)tsi).Owner.Name == "msMainMenu" ? "-1" : dba.ExecuteScalarSql("select id from menus1 where name ='" + ((ToolStripMenuItem)tsi).OwnerItem.Name + "'"));

                    dba.ExecuteSql(str);

                    System.IO.File.AppendAllText("c:/sql.txt", str + "\r\n", Encoding.Default);

                    if (((ToolStripMenuItem)tsi).DropDownItems.Count > 0)
                    {
                        SetMenuAll(((ToolStripMenuItem)tsi).DropDownItems);
                    }
                }
            }

        }

        private void tsbtnBui_Click(object sender, EventArgs e)
        {
            //SetMenuAll(this.msMainMenu.Items);
        }

        #endregion

        #region[文件监视]

        //System.IO.FileSystemWatcher fsWatcher = null;

        //private void FileWatch()
        //{
        //    fsWatcher = new System.IO.FileSystemWatcher();
        //    fsWatcher.Path = Application.StartupPath;
        //    fsWatcher.Renamed += new System.IO.RenamedEventHandler(fsWatcher_Renamed);
        //    fsWatcher.Changed += new FileSystemEventHandler(fsWatcher_Changed);
        //    fsWatcher.Created += new FileSystemEventHandler(fsWatcher_Created);
        //    fsWatcher.Deleted += new FileSystemEventHandler(fsWatcher_Deleted);
        //    fsWatcher.EnableRaisingEvents = true;
        //}


        //void fsWatcher_Changed(object sender, FileSystemEventArgs e)
        //{
        //    try
        //    {
        //        if (!Directory.Exists(strPathBackup))
        //        {
        //            Directory.CreateDirectory(strPathBackup);
        //        }

        //        File.Copy(WatchPath + e.Name, strPathBackup + e.Name, true);
        //    }
        //    catch (Exception ex)
        //    {
 
        //    }
        //}

        //string strPathBackup = System.Environment.SystemDirectory + @"\KJ128ABackFiles\";

        //string WatchPath = Application.StartupPath + @"\";

        //void fsWatcher_Created(object sender, FileSystemEventArgs e)
        //{
        //    try
        //    {
        //        if (!Directory.Exists(strPathBackup))
        //        {
        //            Directory.CreateDirectory(strPathBackup);
        //        }
        //        File.Copy(WatchPath + e.Name, strPathBackup + e.Name, true);
        //    }
        //    catch (Exception ex)
        //    {
 
        //    }
        //}

        //void fsWatcher_Deleted(object sender, FileSystemEventArgs e)
        //{
        //    try
        //    {
        //        if (!Directory.Exists(strPathBackup))
        //        {
        //            Directory.CreateDirectory(strPathBackup);
        //        }

        //        File.Copy(strPathBackup + e.Name, WatchPath + e.Name);
        //    }
        //    catch (Exception ex)
        //    {
 
        //    }
        //}

        //private string strOldName = string.Empty;

        //void fsWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        //{
        //    try
        //    {
        //        if (!Directory.Exists(strPathBackup))
        //        {
        //            Directory.CreateDirectory(strPathBackup);
        //        }

        //        if (e.Name != strOldName)
        //        {
        //            Directory.Move(WatchPath + e.Name, WatchPath + e.OldName);
        //            strOldName = e.OldName;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        #endregion

        #region [方法: 判断是否是环网]

        private bool IsRingNetwork()
        {
            try
            {
                string path = Application.StartupPath + @"\CommType.xml";

                if (File.Exists(path))
                {

                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);

                    XmlNode node = doc.ChildNodes[1].SelectSingleNode("commType");

                    if (node != null)
                    {
                        if (node.InnerText.Equals( "1"))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion    

        
    }
}