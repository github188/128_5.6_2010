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

namespace KJ128NInterfaceShow
{

    public partial class FrmBottomAlert : Wilson.Controls.Docking.DockContent
    {

        #region [ 变量: 定时打印 ]

        TaskTimeBLL ttbll = new TaskTimeBLL();
        //Thread th;

        #endregion

        #region 私有变量


        private RTEmpHelpBLL rtehbll = new RTEmpHelpBLL();

        /// <summary>
        /// 实时救援信息
        /// </summary>
        private FrmFlash frmRteh;


        /// <summary>
        /// 系统日志的路径
        /// </summary>
        private string strLogPath = Application.StartupPath + "\\KJ128ALog\\";

        private MainBLL mbll = new MainBLL();
        private DBAcess dbacc = new DBAcess();
        private DataSet ds;

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
        /// <summary>
        /// 声音在数组中的位置
        /// </summary>
        private int intSoundid = 0;
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
        /// <summary>
        /// label7是否显示,初始值为false 不显示
        /// </summary>
        private bool labe7vis = false;
        /// <summary>
        /// label7是否显示,初始值为false 不显示
        /// </summary>
        private bool labe7vis1 = false;
        private void TimePrint()
        {
            while (true)
            {
                Thread.Sleep(15000);
                ttbll.TimePrint();
            }
        }

        #region 构造函数

        public FrmBottomAlert()
        {
            InitializeComponent();

            //Initdisplay();                      //初始化显示设置

            //视觉效果改变时的颜色
            if (System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsSupported)
            {

            }
            else
            {
                //cpStationInfo.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                //cpDepartment.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                BackColor = Color.FromArgb(211, 220, 233);
            }
            Init();                         // 初始化

            //LoadDeptTree();                 // 加载实时部门树
            //th = new Thread(TimePrint);
            //th.Start();
        }

        #endregion

        #region [注释]

        // #region 初始化

        private void Init()
        {
            //txtPage.CaptionTitle = "1";

            //vspStationInfo.LeftInterval = leftVartical;
            //vspStationInfo.TopInterval = topVartical;
            //vspStationInfo.VerticalInterval = vartical;
            //loadRTDeptSmallInfo(0);          // 部门信息
            // InitStationData();              // 初始化加载分站信息


            timeControl.Start();
            timeControl.Tick += new EventHandler(timeControl_Tick);
            //vspStationInfo.Layout += new LayoutEventHandler(vspStationInfo_Layout); // 重排子控件


            AppDomainSetup domaininfo = new AppDomainSetup();
            //strPath = "file:///" + System.Environment.CurrentDirectory + "\\Sound\\Alarm.wav";        //获取默认声音路径
            strPath = System.Environment.CurrentDirectory + "\\Sound\\Alarm.wav";
            AddAlarmLinkLabel();                //加载报警设置
            IsAlarm();                          //报警判断
        }



        //定时刷新数据
        void timeControl_Tick(object sender, EventArgs e)
        {

            AddAlarmLinkLabel();                //加载报警设置
            IsAlarm();                       //报警判断
        }




        #endregion


        #region [报警]


        #region 添加报警 LinkLabel
        private void AddAlarmLinkLabel()
        {
            cpAlram.Controls.Clear();

            DataTable dt = new DataTable();

            dt = mbll.SearchAlarmType();

            if (dt != null && dt.Rows.Count > 0)
            {
                int i = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    LinkLabel ll = new LinkLabel();
                    ll.Text = dr[0].ToString();
                    ll.Location = new Point(32 + i, 30);
                    ll.Size = new Size(110, 16);
                    //ll.Font.Underline = false;
                    //ll.MouseClick += new MouseEventHandler(ll_MouseClick);
                    ll.Click += new EventHandler(ll_Click);
                    //ll.LinkColor = Color.Red;
                    cpAlram.Controls.Add(ll);
                    i += 150;
                }
            }
            strAlarm[0] = strAlarm[1] = strAlarm[2] = strAlarm[3] = strAlarm[4] = strAlarm[5] = strAlarm[6] = "";
        }


        #endregion

        #region 报警 点击事件 Click
        void ll_Click(object sender, EventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            if (ll.LinkColor == Color.Red)
            {
                switch (ll.Text)
                {
                    case "超时报警":
                        
                        if (!Searcher.FindFormByName("FrmRealtimeOverTimeInfo"))
                        {
                            FrmRealtimeOverTimeInfo froti1 = new FrmRealtimeOverTimeInfo(true);
                            OpenForm(froti1);
                        }
                        break;
                    case "区域报警":

                        if (!Searcher.FindFormByName("RealTimeSpecialWorkTypeTerrialAlarm"))
                        {
                            RealTimeSpecialWorkTypeTerrialAlarm frtit1 = new RealTimeSpecialWorkTypeTerrialAlarm();
                            OpenForm(frtit1);
                        }
                        break;
                    case "传输分站故障报警":
                        if (!Searcher.FindFormByName("FrmRealtimeStationBreak"))
                        {
                            FrmRealtimeStationBreak frsb1 = new FrmRealtimeStationBreak(true);
                            OpenForm(frsb1);
                        }
                        break;
                    case "超员报警":
                        if (!Searcher.FindFormByName("FrmRealTimeOverEmp"))
                        {
                            FrmRealTimeOverEmp frtoe1 = new FrmRealTimeOverEmp();
                            OpenForm(frtoe1);
                        }
                        break;
                    case "低电量报警":
                        if (!Searcher.FindFormByName("FrmRealtimeAlarmElectricity"))
                        {
                            FrmRealtimeAlarmElectricity frae1 = new FrmRealtimeAlarmElectricity();
                            OpenForm(frae1);
                        }
                        break;
                    case "读卡分站故障报警":
                        if (!Searcher.FindFormByName("FrmRealTimeStaHeadBreak"))
                        {
                            FrmRealTimeStaHeadBreak frtshb1 = new FrmRealTimeStaHeadBreak(true);
                            OpenForm(frtshb1);
                        }
                        break;
                    case "工作异常报警":
                        if (!Searcher.FindFormByName("FrmRealTimeAlarmPath"))
                        {
                            FrmRealTimeAlarmPath frtap = new FrmRealTimeAlarmPath();
                            OpenForm(frtap);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region 判断是否 报警
        private void IsAlarm()
        {
            try
            {
                //判断是否有求救信息
                string strEmpHelpCount = rtehbll.GetEmpHelpCounts().ToString();
                if (Convert.ToInt32(strEmpHelpCount) > 0)
                {
                    if (frmRteh == null)
                    {
                        try
                        {
                            frmRteh = new FrmFlash();
                            frmRteh.GetCount(strEmpHelpCount);
                            frmRteh.Show();
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        frmRteh.GetCount(strEmpHelpCount);
                    }
                    //为窗体赋焦点
                    // frmRteh.Activate();   
                }
                else
                {
                    if (frmRteh != null)
                    {
                        frmRteh.Close();
                        frmRteh.Dispose();
                        frmRteh = null;
                    }
                }

                DataTable dt;
                //blIsAlarmErr = false;
                foreach (Control cl in cpAlram.Controls)
                {
                    LinkLabel ll;
                    switch (cl.Text)
                    {
                        case "超时报警":
                            ll = (LinkLabel)cl;
                            if (mbll.IsAlarm(1))
                            {
                                ll.LinkColor = Color.Red;
                                using (dt = new DataTable())
                                {
                                    dt = mbll.LoadAlarmPath(1);
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        AlarmSound(1, dt);
                                    }
                                }
                            }
                            else
                            {
                                ll.LinkColor = Color.FromArgb(0, 0, 255);
                                ll.Enabled = false;
                            }
                            break;
                        case "区域报警":
                            ll = (LinkLabel)cl;
                            if (mbll.IsAlarm(2))
                            {
                                ll.LinkColor = Color.Red;
                                using (dt = new DataTable())
                                {
                                    dt = mbll.LoadAlarmPath(2);
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        AlarmSound(2, dt);
                                    }
                                }
                            }
                            else
                            {
                                ll.LinkColor = Color.FromArgb(0, 0, 255);
                                ll.Enabled = false;
                            }
                            break;
                        case "传输分站故障报警":
                            ll = (LinkLabel)cl;
                            if (mbll.IsAlarm(3))
                            {
                                ll.LinkColor = Color.Red;
                                using (dt = new DataTable())
                                {
                                    dt = mbll.LoadAlarmPath(3);
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        AlarmSound(3, dt);
                                    }
                                }
                            }
                            else
                            {
                                ll.LinkColor = Color.FromArgb(0, 0, 255);
                                ll.Enabled = false;
                            }
                            break;
                        case "超员报警":
                            ll = (LinkLabel)cl;
                            if (mbll.IsAlarm(4))
                            {
                                ll.LinkColor = Color.Red;
                                using (dt = new DataTable())
                                {
                                    dt = mbll.LoadAlarmPath(4);
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        AlarmSound(4, dt);
                                    }
                                }
                            }
                            else
                            {
                                ll.LinkColor = Color.FromArgb(0, 0, 255);
                                ll.Enabled = false;
                            }
                            break;
                        case "低电量报警":
                            ll = (LinkLabel)cl;
                            if (mbll.IsAlarm(5))
                            {
                                ll.LinkColor = Color.Red;
                                using (dt = new DataTable())
                                {
                                    dt = mbll.LoadAlarmPath(5);
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        AlarmSound(5, dt);
                                    }
                                }
                            }
                            else
                            {
                                ll.LinkColor = Color.FromArgb(0, 0, 255);
                                ll.Enabled = false;
                            }
                            break;
                        case "读卡分站故障报警":
                            ll = (LinkLabel)cl;
                            if (mbll.IsAlarm(6))
                            {
                                ll.LinkColor = Color.Red;
                                using (dt = new DataTable())
                                {
                                    dt = mbll.LoadAlarmPath(6);
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        AlarmSound(6, dt);
                                    }
                                }
                            }
                            else
                            {
                                ll.LinkColor = Color.FromArgb(0, 0, 255);
                                ll.Enabled = false;
                            }
                            break;

                        case "工作异常报警":
                            ll = (LinkLabel)cl;
                            if (mbll.IsAlarm(7))
                            {
                                ll.LinkColor = Color.Red;
                                using (dt = new DataTable())
                                {
                                    dt = mbll.LoadAlarmPath(7);
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        AlarmSound(7, dt);
                                    }
                                }
                            }
                            else
                            {
                                ll.LinkColor = Color.FromArgb(0, 0, 255);
                                ll.Enabled = false;
                            }

                            break;

                        default:
                            break;
                    }
                }

            }
            catch
            {
                return;
            }
        }
        #endregion

        #region 报警声音
        /// <summary>
        /// 报警声音
        /// </summary>
        /// <param name="dt">报警声音(DataTable)</param>
        private void AlarmSound(int intAlarmType, DataTable dt)
        {
            int intType = Convert.ToInt32(dt.Rows[0][0]);
            string strNowPath = "";
            switch (intType)
            {
                case 1:
                    strAlarm[intAlarmType - 1] = "-1";

                    break;
                case 2:
                    strNowPath = strPath;
                    //Sound(strNowPath);
                    strAlarm[intAlarmType - 1] = strNowPath;
                    NoExitsSoundFile.Clear();
                    break;
                case 3:
                case 4:
                    strNowPath = dt.Rows[0][1].ToString();
                    //Sound(strNowPath);
                    strAlarm[intAlarmType - 1] = strNowPath;
                    NoExitsSoundFile.Clear();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 播放声音
        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="str">声音文件路径</param>
        private void Sound(string str)
        {
            SoundPlayer simpleSound;
            if (str == null || str.Equals("-1") || str == "")
            {
                return;
            }
            try
            {
                simpleSound = new SoundPlayer(@str);
                simpleSound.Play();
                //System.Threading.Thread.Sleep(1500);
                //  label7.Visible = false;
            }
            catch (Exception ex)
            {
                //label_msg.Text = ex.Message.ToString();
                //label7.Text = ex.Message.ToString();
                // label7.Visible = true;
                blIsAlarmErr = false;
                //blIsAlarmErr = true;
                simpleSound = new SoundPlayer(@strPath);
            }

        }
        #endregion
        private List<string> NoExitsSoundFile = new List<string>();
        #region 定时播放报警声音
        private void timerAlarm_Tick(object sender, EventArgs e)
        {
            bool flag = true;
            if (labe7vis)
            {
                label7.Visible = true;
            }
            else
            {
                label7.Visible = false;
            }
            for (int i = intAlarm - 1; i < 6; i++)
            {
                if (strAlarm[i] != "" && strAlarm[i] != "-1")
                {
                    intAlarm = i + 1;
                    break;
                }
                else
                {
                    intAlarm = i + 1;
                }
            }
            //if (strAlarm[intAlarm - 1] == null || strAlarm[intAlarm - 1] == "-1")
            //{
            //    intAlarm++;
            //}
            Sound(strAlarm[intAlarm - 1]);

            intAlarm += 1;
            if (intAlarm >= 8)
            {
                //lbAlarmErr.Visible = blIsAlarmErr;          //是否显示错误提示
                //label7.Visible = blIsAlarmErr;
                string temp = label7.Text;
                intAlarm = 1;
                blIsAlarmErr = false;
                flag = false;

            }


            int s = 0;
            if (intAlarm > 1)
            {
                intSoundid = intAlarm - 2;
            }
            string stringpath = strAlarm[intSoundid].ToString();
            if (stringpath == null || stringpath.Equals("-1") || stringpath == "")
            {
                //return;
            }
            else
            {
                try
                {
                    System.IO.FileStream fs = new System.IO.FileStream(stringpath, System.IO.FileMode.Open);
                    long alldata = fs.Length;
                    if (NoExitsSoundFile.Contains(stringpath))
                        NoExitsSoundFile.Remove(stringpath);
                    if (NoExitsSoundFile.Count == 0)
                        labe7vis = false;
                    if (fs.Length > 44)
                    {
                        byte[] buffer = new byte[44];
                        fs.Read(buffer, 0, 44);
                        long datanum = (long)System.BitConverter.ToInt32(buffer, 28);
                        s = Convert.ToInt32(alldata / datanum);
                        if (s == 0)
                        {
                            s++;
                        }
                        fs.Close();
                        fs.Dispose();
                        //if (intSoundid == 7)
                        //{ 

                        //}
                        //
                        // labe7vis = false;
                    }

                    if (flag)
                    {
                        timerAlarm.Interval = s * 1000;
                    }
                    else
                    {
                        timerAlarm.Interval = 1;
                    }



                }
                catch
                {
                    if (!NoExitsSoundFile.Contains(stringpath))
                        NoExitsSoundFile.Add(stringpath);
                    label7.Text = "找不到声音文件";
                    labe7vis = true;
                    timerAlarm.Interval = 1;
                }

            }
        }
        #endregion

        private void FrmBottomAlert_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion

        #region 【 方法：打开窗体 】

        private void OpenForm(Wilson.Controls.Docking.DockContent myfrm)
        {
            FrmMain frm = (FrmMain)Application.OpenForms["FrmMain"];
            if (frm != null)
            {
                myfrm.Show(frm.dockPanel1, DockState.Document);
                myfrm.Activate();
            }
            else
            {
                myfrm.Show();
                myfrm.Activate();
            }
        }
        #endregion
    }

}