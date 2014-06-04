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

using Wilson.Controls.Docking;
using System.IO;
using System.Runtime;
using System.Diagnostics;
using KJ128NInterfaceShow;
using System.Xml;

namespace KJ128NMainRun
{
    public partial class FrmNav : Wilson.Controls.Docking.DockContent
    {
        #region 私有变量

        private Form frmMain = Application.OpenForms["FrmMain"];

        /// <summary>
        /// 系统日志的路径
        /// </summary>
        private string strLogPath = Application.StartupPath + "\\KJ128ALog\\";

        private bool isClient = false;

        private string isClientPath = Application.StartupPath + @"\IsClient.xml";

        #endregion

        private void CheckClient()
        {
            //XmlDocument doc = new XmlDocument();

            //if (File.Exists(isClientPath))
            //{
            //    try
            //    {
            //        doc.Load(isClientPath);

            //        XmlNode node = doc.SelectSingleNode("Root");

            //        if (node != null)
            //        {
            //            XmlNode isClientNode = node.SelectSingleNode("IsClient");
            //            if (isClientNode != null)
            //            {
            //                isClient = (isClientNode.InnerText.ToLower()=="true"?true:false);
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        isClient = false;
            //    }
            ////}
            isClient = New_DBAcess.blIsClient;

        }

        /// <summary>
        /// 根据isClient判断是否为客户端
        /// </summary>
        private void InitializeInterface()
        {
            if (isClient)
            {
                #region [禁用基础数据]

                pbTool1.Enabled = false;
                label1.Enabled = false;
                pnlBaseData.Enabled = false;

                #endregion

                #region [禁用区域信息]

                pictureBox40.Enabled = false;
                label41.Enabled = false;

                #endregion

                #region [禁用考勤信息]

                pictureBox45.Enabled = false;
                label46.Enabled = false;


                pictureBox44.Enabled = false;
                label45.Enabled = false;

                pictureBox41.Enabled = false;
                label42.Enabled = false;

                pictureBox37.Enabled = false;
                label38.Enabled = false;

                #endregion

                #region [禁用图形系统]

                pictureBox53.Enabled = false;
                label54.Enabled = false;

                pictureBox51.Enabled = false;
                label53.Enabled = false;

                #endregion
            }
        }


        public FrmNav()
        {
            InitializeComponent();
        }

        #region 验证

        private bool IsValidate()
        {
            if (KJ128NInterfaceShow.FrmMain.blIsMemorize && !LoginBLL.user.Equals("guest"))
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

        #region 窗体事件

        private void FrmNav_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void FrmNav_Load(object sender, EventArgs e)
        {
            #region 初始化基础数据面板状态

            CheckClient();

            InitializeInterface();

            label1.ForeColor = Color.Blue;

            pnlBaseData.Dock = DockStyle.Fill;

            pnlBaseData.Visible = true;

            #endregion
        }

        #endregion
       
        #region 主导航事件

        private void pbTool1_Click(object sender, EventArgs e)
        {
 
            ShowPanel("pnlBaseData");
            ChageLabelColor("label1");
        }

        private void pbTool2_Click(object sender, EventArgs e)
        {

            ShowPanel("pnlView");
            ChageLabelColor("label2");
        }

        private void pbTool3_Click(object sender, EventArgs e)
        {
            ShowPanel("pnlDown");
            ChageLabelColor("label3");
        }

        private void pbTool4_Click(object sender, EventArgs e)
        {
            ShowPanel("pnlArea");
            ChageLabelColor("label4");
        }

        private void pbTool5_Click(object sender, EventArgs e)
        {
            ShowPanel("pnlAtt");
            ChageLabelColor("label5");
        }

        private void pbTool6_Click(object sender, EventArgs e)
        {
            ShowPanel("pnlGraphi");
            ChageLabelColor("label55");
        }

        private void ChageLabelColor(string lableName)
        {
            foreach (Control lbl in pnlLeft.Controls)
            {
                if (lbl is Label)
                {
                    if (((Label)lbl).Name == lableName)
                    {
                        ((Label)lbl).ForeColor = Color.Blue;
                    }
                    else
                    {
                        ((Label)lbl).ForeColor = Color.Black;
                    }
                }
            }
        }

        private void ShowPanel(string panelName)
        {
            foreach (Panel col in pnlPar.Controls)
            {
                if (col.Name == panelName)
                {
                    col.Dock = DockStyle.Fill;
                    col.Visible = true;
                }
                else 
                {
                    col.Visible = false;
                }
            }
        }

        #endregion

        #region 基础数据

        private void pictureBox5_Click(object sender, EventArgs e)
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
            frmSM.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        } 

        private void pictureBox6_Click(object sender, EventArgs e)
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

            //frmE.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);

        }

        private void pictureBox7_Click(object sender, EventArgs e)
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
            frmDepartmentManage.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
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
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
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
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmDirectionalManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开方向性配置菜单");

            FrmDirectionalManage frm = new FrmDirectionalManage();
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }
        
        #endregion

        #region 检测数据

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("RealTimeMonitorInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时发码器信息菜单");

            RealTimeMonitorInfo rtmi = new RealTimeMonitorInfo("");
            rtmi.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("RealTimeInOutAntennaInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时进出天线菜单");

            RealTimeInOutAntennaInfo rtioai = new RealTimeInOutAntennaInfo();
            rtioai.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHistoryInOutAntenna"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史进出天线信息菜单");

            FrmHistoryInOutAntenna fhioa = new FrmHistoryInOutAntenna();
            fhioa.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealtimeStationBreak"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时分站信息菜单");

            FrmRealtimeStationBreak frm = new FrmRealtimeStationBreak(false);
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisStationBreak"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史分站接收器故障信息菜单");

            FrmHisStationBreak frm = new FrmHisStationBreak(1);
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInOutStationHead"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史进出接收器信息菜单");

            FrmHisInOutStationHead fhiosh = new FrmHisInOutStationHead();
            fhiosh.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("RealTimeInOutStationHeadInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时进接收器信息菜单");

            RealTimeInOutStationHeadInfo rtioshi = new RealTimeInOutStationHeadInfo();
            rtioshi.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        #endregion

        #region 井下数据

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInMineEmp"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时下井人员名单显示菜单");
            //KJ128NMainRun.RealTime.FrmRealTime frm = new KJ128NMainRun.RealTime.FrmRealTime();
            KJ128NMainRun.RealTime.FrmRealTimeInMineEmp frm = new KJ128NMainRun.RealTime.FrmRealTimeInMineEmp(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1);
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);


        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("EmployeeClassify"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时井下人员汇总信息菜单");

            EmployeeClassify frm = new EmployeeClassify();
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHistoryTotalInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史下井记录人数统计菜单");

            FrmHistoryTotalInfo fhti = new FrmHistoryTotalInfo();
            fhti.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInWellInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时下井信息菜单");

            FrmRealTimeInWellInfo frtiwi = new FrmRealTimeInWellInfo(false, "0");
            frtiwi.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInMineRecordSet"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史下井信息菜单");

            FrmHisInMineRecordSet frm = new FrmHisInMineRecordSet();
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("RealTimeAttendanceQuery"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时人员班次查询菜单");

            RealTimeAttendanceQuery rtaq = new RealTimeAttendanceQuery();
            rtaq.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("HistoryQueryByClass"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史上下井按班次查询菜单");

            HistoryQueryByClass hqbc = new HistoryQueryByClass();
            hqbc.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInOutMine"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史下井记录次数统计菜单");

            FrmHisInOutMine fhom = new FrmHisInOutMine();
            fhom.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmStatMonthEmpInMine"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史每月下井次数统计菜单");
            FrmStatMonthEmpInMine frm = new FrmStatMonthEmpInMine();
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        #endregion

        #region 考勤信息

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("ClassInfoManage"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤班制设置菜单");

            ClassInfoManage cim = new ClassInfoManage();
            cim.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmTimerInterval"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤时段设置菜单");

            FrmTimerInterval FrmTI = new FrmTimerInterval();
            FrmTI.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("HolidayTypeSet"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开假别设置菜单");

            HolidayTypeSet hcs = new HolidayTypeSet();
            hcs.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox37_Click(object sender, EventArgs e)
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
            dss.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceParticulars"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开人员考勤明细菜单");

            AttendanceParticulars ap = new AttendanceParticulars();
            ap.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceInitialData"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工考勤原始数据菜单");

            AttendanceInitialData aid = new AttendanceInitialData();
            aid.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendacePersonelStatistic"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开个人出勤率统计菜单");

            //AttendacePersonelStatistic aps = new AttendacePersonelStatistic();
            //aps.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceDayByDayStatistic"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门逐日出勤统计菜单");

            AttendanceDayByDayStatistic adds = new AttendanceDayByDayStatistic();
            adds.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        #endregion

        #region 区域信息

        private void pictureBox40_Click(object sender, EventArgs e)
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
            frm.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInTerritorial"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时区域信息菜单");

            FrmRealTimeInTerritorial frtit = new FrmRealTimeInTerritorial(false);
            frtit.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        #endregion

        #region 图形系统

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmPicConfig"))
            {
                return;
            }

            FrmPicConfig frmPicCfig = new FrmPicConfig();
            frmPicCfig.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHistroyRoute"))
            {
                return;
            }

            FrmHistroyRoute frmHisRoute = new FrmHistroyRoute();
            frmHisRoute.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRouteConfig"))
            {
                return;
            }

            KJ128NMainRun.Graphics.FrmRouteConfig frmRouteCfig = new KJ128NMainRun.Graphics.FrmRouteConfig();
            frmRouteCfig.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTime"))
            {
                return;
            }

            KJ128NMainRun.Graphics.FrmRealTime frmRTime = new KJ128NMainRun.Graphics.FrmRealTime();
            frmRTime.Show(((KJ128NInterfaceShow.FrmMain)frmMain).dockPanel1, DockState.Document);
        }

        #endregion        

        #region 图片改变大小效果

        private void PictureBoxEnter(Object box)
        {
            ((PictureBox)box).BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void PictureBoxLeave(Object box)
        {
            ((PictureBox)box).BackgroundImageLayout = ImageLayout.Center;
        }

        private void pbTool1_MouseEnter(object sender, EventArgs e)
        {
            PictureBoxEnter(sender);
        }

        private void pbTool1_MouseLeave(object sender, EventArgs e)
        {
            PictureBoxLeave(sender);
        }

        #endregion     
    }
}
