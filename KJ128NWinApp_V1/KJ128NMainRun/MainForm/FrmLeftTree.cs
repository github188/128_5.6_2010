using System;
using System.Data;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NDBTable;
using KJ128NMainRun;
using KJ128NMainRun.AlarmSet;
using KJ128NMainRun.ConfigInfo.ConAreaManage;
using KJ128NMainRun.ConfigInfo.ConCodeSenderInfo;
using KJ128NMainRun.ConfigInfo.ConDeptEmpCounts;
using KJ128NMainRun.ConfigInfo.ConDeptManage;
using KJ128NMainRun.ConfigInfo.ConDirectionalManage;
using KJ128NMainRun.ConfigInfo.ConEmployeeInfo;
using KJ128NMainRun.ConfigInfo.ConEquManage;
using KJ128NMainRun.ConfigInfo.ConStaHeadInfo;
using KJ128NMainRun.EquManage;
using KJ128NMainRun.Graphics;
using KJ128NMainRun.HistoryInfo;
using KJ128NMainRun.HistoryInfo.HistoryInTerritorial;
using KJ128NMainRun.HistoryInfo.HistoryOverTimeInfo;
using KJ128NMainRun.HistoryInfo.HistoryStationBreak;
using KJ128NMainRun.PathManage;
using KJ128NMainRun.RealTime;
using KJ128NMainRun.RealTime.RealtimeAlarmElectricity;
using KJ128NMainRun.RealTime.RealTimeDirectional;
using KJ128NMainRun.RealTime.RealtimeInTerritorial;
using KJ128NMainRun.RealTime.RealTimeInWellInfo;
using KJ128NMainRun.RealTime.RealtimeOverTimeInfo;
using KJ128NMainRun.RealTime.RealTimeStaHeadBreak;
using KJ128NMainRun.RealTime.RealtimeStationBreak;
using KJ128NMainRun.RealTime.ReelTimeMonitorInfo;
using KJ128NMainRun.StationManage;
using KJ128WindowsLibrary;
using Shine.Logs;
using Shine.Logs.LogType;
using Wilson.Controls.Docking;
using System.IO;

namespace KJ128NInterfaceShow
{
    public partial class FrmLeftTree : Wilson.Controls.Docking.DockContent
    {

        #region [ 变量: 定时打印 ]

        TaskTimeBLL ttbll = new TaskTimeBLL();
        //Thread th;

        #endregion

        #region 私有变量

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
        private int leftVartical = 3;
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

        private Form frmmain = Application.OpenForms["FrmMain"];

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

        public FrmLeftTree()
        {
            InitializeComponent();

            Initdisplay();                      //初始化显示设置

            //视觉效果改变时的颜色
            if (System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsSupported)
            {

            }
            else
            {
                cpStationInfo.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                cpDepartment.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                BackColor = Color.FromArgb(211, 220, 233);
            }
            Init();                         // 初始化

            LoadDeptTree();                 // 加载实时部门树
            //th = new Thread(TimePrint);
            //th.Start();
        }

        #endregion

        #region 初始化

        private void Init()
        {
            txtPage.CaptionTitle = "1";

            vspStationInfo.LeftInterval = leftVartical;
            vspStationInfo.TopInterval = topVartical;
            vspStationInfo.VerticalInterval = vartical;
            //loadRTDeptSmallInfo(0);          // 部门信息
            InitStationData();              // 初始化加载分站信息


            timeControl.Start();
            timeControl.Tick += new EventHandler(timeControl_Tick);
            vspStationInfo.Layout += new LayoutEventHandler(vspStationInfo_Layout); // 重排子控件


            AppDomainSetup domaininfo = new AppDomainSetup();
            strPath = "file:///" + System.Environment.CurrentDirectory + "\\Sound\\Alarm.wav";        //获取默认声音路径

            AddAlarmLinkLabel();                //加载报警设置
            //IsAlarm();                          //报警判断
        }

        #region 部门DataGridView

        // 加载部门信息
        //private void loadRTDeptSmallInfo(int oldSelectRow)
        //{
        //    dgvRTDept.Columns.Clear();

        //    DataSet ds = stationBLL.GetRTDeptSmallInfo(displayDeptType);
        //    DataTable dt = ds.Tables[0];
        //    dt.Columns.Add("tmpCol");
        //    dgvRTDept.DataSource = dt;

        //    // Column查询
        //    DataGridViewLinkColumn dgvLBtnCol = new DataGridViewLinkColumn();
        //    dgvLBtnCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    dgvLBtnCol.HeaderText = "详细";
        //    dgvLBtnCol.DataPropertyName = "tmpCol";
        //    dgvLBtnCol.Text = "查看";
        //    dgvLBtnCol.Visible = true;
        //    dgvLBtnCol.UseColumnTextForLinkValue = true;
        //    dgvRTDept.Columns.Insert(3, dgvLBtnCol);

        //    string displayStr = string.Empty;
        //    switch (displayDeptType)
        //    {
        //        case 0: displayStr = displayStr + "人数";
        //            break;
        //        case 1: displayStr = displayStr + "设备";
        //            break;
        //        case 2: displayStr = displayStr + "发码器";
        //            break;
        //        default: displayStr.ToString();
        //            break;
        //    }
        //    // Head控制
        //    dgvRTDept.Columns[1].HeaderText = "部门名称";
        //    dgvRTDept.Columns[2].HeaderText = displayStr;
        //    dgvRTDept.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    dgvRTDept.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    dgvRTDept.Columns[0].Visible = false;
        //    dgvRTDept.Columns["tmpCol"].Visible = false;

        //    // 上次选择的行
        //    if (dgvRTDept.Rows.Count != 0)
        //    {
        //        dgvRTDept.Rows[oldSelectRow].Selected = true;
        //    }
        //    displayStr = string.Empty;
        //    switch (displayDeptType)
        //    {
        //        case 0: displayStr = displayStr + "人";
        //            break;
        //        case 1: displayStr = displayStr + "设备";
        //            break;
        //        case 2: displayStr = displayStr + "发码器";
        //            break;
        //        default: displayStr.ToString();
        //            break;
        //    }
        //    //cpDepartment.CaptionTitle = "下井人员统计     共" + ds.Tables[1].Rows[0][0].ToString() + "个"+displayStr;

        //}
        //DataGridView查询
        //private void dgvRTDept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        dgvRTDept.Rows[e.RowIndex].Selected = true;
        //        ((DataGridViewLinkColumn)dgvRTDept.Columns[3]).VisitedLinkColor = Color.Blue;
        //    }
        //}

        #endregion

        #region 初始化加载分站信息

        /// <summary>
        /// 初始化加载分站信息

        /// </summary>
        private void InitStationData()
        {
            if (displayFun == 2)
            {
                // 加载接收器信息
                loadStationHeadList(1, 0);
            }
            else if (displayFun == 3 || displayFun == 1)
            {
                AddStationInfo(1, 0);
            }
        }

        #endregion

        /// <summary>
        /// 获得当前页分站信息

        /// </summary>
        private void loadStationData()
        {
            int pIndex = int.Parse(txtPage.CaptionTitle);
            if (displayFun == 1)
            {
                AddStationInfo(pIndex, 0);
            }
            else if (displayFun == 2)
            {
                // 加载接收器信息
                loadStationHeadList(pIndex, 0);
            }
            else if (displayFun == 3)
            {
                AddStationInfo(pIndex, 0);
                // 检测要加载接收器的分站      
                string addressList = "";
                foreach (Control ctl in vspStationInfo.Controls)
                {
                    if (ctl.GetType().ToString() == "KJ128WindowsLibrary.StationMakeupVspanel")
                    {
                        StationMakeupVspanel smv = (StationMakeupVspanel)ctl;
                        if (smv.Enabled)
                        {
                            if (smv.Controls.Count > 1)
                            {
                                addressList += smv.StationAddress.ToString() + ",";
                            }
                        }
                        else
                        {
                            // 如果分站故障 且分站已加载接收器 将接收器清空


                            if (smv.Controls.Count > 1)
                            {
                                for (int i = smv.Controls.Count - 1; i >= 1; i--)
                                {
                                    smv.Controls.RemoveAt(i);
                                }
                                smv.Height = 22;
                                // 分站信息控件 默认高度
                                ((StationCaptionPanel)smv.Controls[0]).CaptionCloseButtonTitle = "-";
                            }
                        }
                    }
                }
                addressList = addressList.Length > 0 ? addressList.Substring(0, addressList.Length - 1) : "";
                // 加载接收器信息
                if (addressList.Length >= 1)
                {
                    loadStationHead(addressList);
                }
            }
        }

        //定时刷新数据
        void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                loadStationData();          // 刷新当前页分站信息

                LoadDeptTree();             //刷新 下井部门树

                //if (dgvRTDept.Rows.Count > 0 && dgvRTDept.SelectedRows.Count > 0)
                //{

                //    loadRTDeptSmallInfo(dgvRTDept.SelectedRows[0].Index);      // 刷新部门信息
                //}
                //else
                //{
                //    loadRTDeptSmallInfo(0);      // 刷新部门信息
                //}
                //AddAlarmLinkLabel();                //加载报警设置
                //IsAlarm();                       //报警判断
            }
        }

        #endregion

        #region 翻页事件
        // 跳至
        void cpCheckPage_Click(object sender, EventArgs e)
        {
            if (txtCheckPage.Text == string.Empty || txtCheckPage.Text == null) return;
            string value = txtCheckPage.Text;
            int page = int.Parse(value);
            if (displayFun == 1)
            {
                AddStationInfo(page, 1);                   // 加载分站
            }
            else if (displayFun == 2)
            {
                // 加载接收器信息    
                loadStationHeadList(page, 1);           // 加载接收器
            }
            else if (displayFun == 3)
            {
                pageClear();                            // 清空数据
                AddStationInfo(page, 0);                   // 加载分站
            }

        }

        // 下一页

        void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            // 显示方式
            if (displayFun == 1)
            {
                AddStationInfo(page, 1);                   // 加载分站
            }
            else if (displayFun == 2)
            {
                // 加载接收器信息    
                loadStationHeadList(page, 1);           // 加载接收器
            }
            else if (displayFun == 3)
            {
                pageClear();                                    // 清空数据
                AddStationInfo(page, 0);                   // 加载分站
            }
        }

        // 翻页清空
        private void pageClear()
        {
            foreach (Control cl in vspStationInfo.Controls)
            {
                if (cl.Controls.Count > 1)
                {
                    for (int i = cl.Controls.Count - 1; i > 0; i--)
                    {
                        cl.Controls[i].Dispose();
                        cl.Height = 22;
                    }
                }
            }
        }

        // 上一页

        void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            // 显示方式
            if (displayFun == 1)
            {
                AddStationInfo(page, 1);                   // 加载分站
            }
            else if (displayFun == 2)
            {
                // 加载接收器信息
                loadStationHeadList(page, 1);       // 加载接收器
            }
            else if (displayFun == 3)
            {
                pageClear();                                // 清空数据
                AddStationInfo(page, 0);
            }
        }

        #endregion

        #region 信息显示

        #region 处理空数据页数显示

        /// <summary>
        /// 处理空数据页数显示

        /// </summary>
        /// <param name="bl"></param>
        private void pageControlsVisible(bool bl)
        {
            cpUp.Visible = bl;

            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
            cpSumCount.Visible = bl;
        }

        #endregion

        #region 分站显示
        // 分站信息显示
        private void AddStationInfo(int pIndex, int loadType)
        {
            DataSet ds = stationBLL.GetRTStationInfo(pIndex - 1, ppageSum, displayType);
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                try
                {
                    sumPage = sumPage % ppageSum != 0 ? sumPage / ppageSum + 1 : sumPage / ppageSum;
                }
                catch
                {
                    ppageSum = 20;
                    sumPage = sumPage % ppageSum != 0 ? sumPage / ppageSum + 1 : sumPage / ppageSum;

                    // 弹出错误消息，让用户重新填写某个配置

                    MessageBox.Show("主界面显示设置配置有误，请检查配置后重新配置!");

                }
                //if (ds.Tables[0].Rows.Count <= 0)

                if (!cpUp.Enabled)
                {
                    cpUp.Enabled = true;
                    cpUp.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                }
                if (!cpDown.Enabled)
                {
                    cpDown.Enabled = true;
                    cpDown.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                }

                if (pIndex == 1)
                {
                    // 只有一页时
                    if (sumPage <= 1)
                    {
                        //vspStationInfo.Controls.Clear();
                        pageControlsVisible(false);
                    }
                    else
                    {
                        pageControlsVisible(true);
                        cpUp.Enabled = false;
                        cpUp.SetCaptionPanelStyle = CaptionPanelStyleEnum.UnEnableWindowsStyle;
                    }
                }
                else if (pIndex == sumPage)
                {
                    cpDown.Enabled = false;
                    cpDown.SetCaptionPanelStyle = CaptionPanelStyleEnum.UnEnableWindowsStyle;
                    // 最后一页


                }
                else if (pIndex > sumPage)
                {
                    // 大于最后一页


                    AddStationInfo(sumPage, 1);
                    return;
                }
                //cpSumCount.CaptionTitle = "共" + ds.Tables[1].Rows[0][0].ToString() + "条/本页" + ds.Tables[0].Rows.Count.ToString() + "条";
                cpSumCount.CaptionTitle = "共" + ds.Tables[1].Rows[0][0].ToString() + "条";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";
                if (displayFun == 1)
                {
                    if (loadType == 1)
                    {
                        if (vspStationInfo.Controls.Count > 1)
                        {
                            vspStationInfo.Controls.Clear();
                        }
                    }
                    PanelStationInfo psi = null;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (vspStationInfo.Controls.Count > i)
                        {
                            if (vspStationInfo.Controls[i] != null)
                            {
                                psi = (PanelStationInfo)vspStationInfo.Controls[i];
                                psi = loadDisplayStationInfo(psi, ds.Tables[0].Rows[i], displayType);
                                vspStationInfo.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Right) | (AnchorStyles.Top));
                            }
                        }
                        else
                        {
                            psi = new PanelStationInfo();
                            vspStationInfo.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Right) | (AnchorStyles.Top));
                            psi = loadDisplayStationInfo(psi, ds.Tables[0].Rows[i], displayType);
                            vspStationInfo.Controls.Add(psi);
                        }
                    }

                }
                else if (displayFun == 3)
                {
                    StationMakeupVspanel smvpSingleStation = null;

                    

                    if (vspStationInfo.Controls.Count != ds.Tables[0].Rows.Count)
                    {
                        vspStationInfo.Controls.Clear();
                    }
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (vspStationInfo.Controls.Count > i)
                        {
                            if (vspStationInfo.Controls[i] != null)
                            {
                                smvpSingleStation = (StationMakeupVspanel)vspStationInfo.Controls[i];
                                smvpSingleStation = loadStationInfo(smvpSingleStation, ds.Tables[0].Rows[i], displayType);
                                vspStationInfo.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Right) | (AnchorStyles.Top));
                            }
                        }
                        else
                        {
                            smvpSingleStation = new StationMakeupVspanel();
                            smvpSingleStation.ShiftButtonMouseClick += new EventHandler(smvpSingleStation_ShiftButtonMouseClick);
                            vspStationInfo.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Right) | (AnchorStyles.Top));
                            smvpSingleStation = loadStationInfo(smvpSingleStation, ds.Tables[0].Rows[i], displayType);

                            vspStationInfo.Controls.Add(smvpSingleStation);
                        }
                    }
                }
            }
            else
            {
                pageControlsVisible(false);
            }
        }


        // 单击伸缩按钮+
        void smvpSingleStation_ShiftButtonMouseClick(object sender, EventArgs e)
        {
            StationMakeupVspanel smv = (StationMakeupVspanel)((Label)sender).Parent.Parent;
            loadStationHead(smv.StationAddress.ToString(), size, smv, headDisplayType);
        }

        // 重绘
        void vspStationInfo_Layout(object sender, LayoutEventArgs e)
        {
            vspStationInfo.RainRangeControl();
        }

        // 分站接收器信息显示
        private void AddStationHeadInfo(DataTable dt)
        {
            StationMakeupVspanel smvpSingleStation = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (vspStationInfo.Controls.Count > i)
                {
                    if (vspStationInfo.Controls[i] != null)
                    {
                        smvpSingleStation = (StationMakeupVspanel)vspStationInfo.Controls[i];
                        smvpSingleStation = loadStationInfo(smvpSingleStation, dt.Rows[i], displayType);
                        vspStationInfo.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Right) | (AnchorStyles.Top));
                    }
                }
                else
                {
                    smvpSingleStation = new StationMakeupVspanel();
                    vspStationInfo.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Right) | (AnchorStyles.Top));
                    smvpSingleStation = loadStationInfo(smvpSingleStation, dt.Rows[i], displayType);
                    vspStationInfo.Controls.Add(smvpSingleStation);
                }
            }
        }

        #endregion

        #region 显示接收器信息
        /// <summary>
        /// 加载接收器列表信息     
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="loadType">加载类型1是翻页</param>
        private void loadStationHeadList(int pIndex, int loadType)
        {
            DataSet ds = stationBLL.GetRTDisplayStationHeadInfo(pIndex - 1, ppageSum, headDisplayType);

            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % ppageSum != 0 ? sumPage / ppageSum + 1 : sumPage / ppageSum;
                //if (ds.Tables[0].Rows.Count <= 0)

                if (!cpUp.Enabled)
                {
                    cpUp.Enabled = true;
                    cpUp.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                }
                if (!cpDown.Enabled)
                {
                    cpDown.Enabled = true;
                    cpDown.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
                }

                if (pIndex == 1)
                {
                    // 只有一页时
                    if (sumPage <= 1)
                    {
                        //vspStationInfo.Controls.Clear();
                        pageControlsVisible(false);
                    }
                    else
                    {
                        pageControlsVisible(true);
                        cpUp.Enabled = false;
                        cpUp.SetCaptionPanelStyle = CaptionPanelStyleEnum.UnEnableWindowsStyle;
                    }
                }
                else if (pIndex == sumPage)
                {
                    cpDown.Enabled = false;
                    // 最后一页

                    cpDown.SetCaptionPanelStyle = CaptionPanelStyleEnum.UnEnableWindowsStyle;


                }
                else if (pIndex > sumPage || pIndex < 1)
                {
                    // 大于最后一页



                    MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                    return;
                }

                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";

                DataTable dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    PanelStationHeadInfo pshi = null;
                    if (vspStationInfo.Controls.Count == ds.Tables[0].Rows.Count)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            pshi = (PanelStationHeadInfo)vspStationInfo.Controls[i];
                            pshi.MouseHover += new EventHandler(pshi_MouseHover);
                            loadDisplayStationHeadInfo(pshi, size, ds.Tables[0].Rows[i], headDisplayType);
                        }
                    }
                    else
                    {
                        // 清空
                        for (int i = vspStationInfo.Controls.Count - 1; i >= 0; i--)
                        {
                            vspStationInfo.Controls[i].Dispose();
                        }
                        // 重新加载
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            pshi = new PanelStationHeadInfo();
                            pshi.MouseHover += new EventHandler(pshi_MouseHover);
                            pshi.MouseClick += new MouseEventHandler(pshi_MouseClick);
                            vspStationInfo.Controls.Add(loadDisplayStationHeadInfo(pshi, size, ds.Tables[0].Rows[j], headDisplayType));
                        }
                    }
                }
                dt.Dispose();
            }
            else
            {
                pageControlsVisible(false);
            }
            ds.Dispose();
        }

        // 添加接收器
        private void loadStationHead(string addList)
        {
            DataSet ds = stationBLL.GetRTStationHeadInfo(addList, headDisplayType);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                foreach (Control ctl in vspStationInfo.Controls)
                {
                    if (ctl.Controls.Count > 1)
                    {
                        StationMakeupVspanel smv = (StationMakeupVspanel)ctl;
                        DataRow[] dr = dt.Select("StationAddress=" + smv.StationAddress.ToString());

                        PanelStationHeadInfo pshi = null;
                        if (smv.Controls.Count == dr.GetLength(0) / 2 + 1)
                        {
                            for (int i = 0, j = 1; i < dr.GetLength(0); i += 2, j++)
                            {
                                pshi = (PanelStationHeadInfo)smv.Controls[j];
                                loadStationHeadInfo(pshi, size, dr[i], dr[i + 1], headDisplayType, smv.StationAddress.ToString());
                            }
                        }
                        else
                        {
                            // 清空
                            for (int i = smv.Controls.Count - 1; i > 0; i--)
                            {
                                smv.Controls[i].Dispose();
                            }
                            // 重新加载
                            for (int j = 0; j < dr.GetLength(0); j += 2)
                            {
                                pshi = new PanelStationHeadInfo();
                                pshi.MouseClick += new MouseEventHandler(pshi_MouseClick);      //添加接收器后，在主界面中加载接收器时，加载点击事件

                                smv.Controls.Add(loadStationHeadInfo(pshi, size, dr[j], dr[j + 1], headDisplayType, smv.StationAddress.ToString()));
                            }
                        }

                    }
                }
                dt.Dispose();
                ds.Dispose();
            }
        }


        #endregion

        #endregion

        #region panel拖动

        private void cpConfigHead_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void cpConfigHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void cpConfigHead_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        #endregion

        #region 构造控件


        #region 构造分站控件

        /// <summary>
        /// 载入分站信息
        /// </summary>
        /// <param name="smvpSingleStation"></param>
        /// <param name="dr"></param>
        /// <param name="displayType"></param>
        /// <returns></returns>
        public StationMakeupVspanel loadStationInfo(StationMakeupVspanel smvpSingleStation, DataRow dr, int displayType)
        {
            smvpSingleStation.StationAddress = int.Parse(dr["StationAddress"].ToString());// 分站地址号


            //smvpSingleStation.Enabled = false;
            string stationInfo;
            switch (dr["StationState"].ToString())
            {
                case "-1000":
                    {
                        ((StationCaptionPanel)smvpSingleStation.CaptionTitleControl).CaptionForeColor = Color.Red;
                        smvpSingleStation.CaptionTitle = string.Format("{0}号传输分站 故障", dr["StationAddress"].ToString());
                        stationInfo = dr["StationPlace"].ToString() + " 检测到 " + dr["sumCard"].ToString();
                        //smvpSingleStation.IsShrink = true;
                    }
                    break;
                case "0":
                case "-1":
                    {
                        ((StationCaptionPanel)smvpSingleStation.CaptionTitleControl).CaptionForeColor = Color.FromArgb(128, 128, 128);
                        smvpSingleStation.CaptionTitle = string.Format("{0}号传输分站 未初始化", dr["StationAddress"].ToString());
                        stationInfo = dr["StationPlace"].ToString() + " 检测到 " + dr["sumCard"].ToString();
                        //smvpSingleStation.IsShrink = true;
                    }
                    break;
                case "-2000":
                    {
                        ((StationCaptionPanel)smvpSingleStation.CaptionTitleControl).CaptionForeColor = Color.FromArgb(128, 128, 128);
                        smvpSingleStation.CaptionTitle = string.Format("{0}号传输分站 休眠", dr["StationAddress"].ToString());
                        stationInfo = dr["StationPlace"].ToString() + " 检测到 " + dr["sumCard"].ToString();
                        //smvpSingleStation.IsShrink = true;
                    }
                    break;
                default:
                    smvpSingleStation.Enabled = true;
                    ((StationCaptionPanel)smvpSingleStation.CaptionTitleControl).CaptionForeColor = Color.FromArgb(21, 47, 147);
                    //((StationCaptionPanel)smvpSingleStation.CaptionTitleControl).CaptionForeColor = Color.FromArgb(255, 255, 255);
                    smvpSingleStation.CaptionTitle = string.Format("{0}号传输分站", dr["StationAddress"].ToString());
                    stationInfo = dr["StationPlace"].ToString() + " 检测到 " + dr["sumCard"].ToString();
                    //smvpSingleStation.IsShrink = false;
                    break;

            }
            // 分站故障 丁静超

            /*
            if (dr["StationState"].ToString() == "-1000" )
            {
                smvpSingleStation.Enabled = false;
                ((StationCaptionPanel)smvpSingleStation.CaptionTitleControl).CaptionForeColor = Color.Red;
                smvpSingleStation.CaptionTitle = string.Format("{0}号分站 故障", dr["StationAddress"].ToString());
                //((StationCaptionPanel)smvpSingleStation.CaptionTitleControl).CaptionForeColor = Colo

            }
            else
            {
                smvpSingleStation.Enabled = true;
                ((StationCaptionPanel)smvpSingleStation.CaptionTitleControl).CaptionForeColor = Color.FromArgb(21, 47, 147);
                smvpSingleStation.CaptionTitle = string.Format("{0}号分站", dr["StationAddress"].ToString());
            }
            */

            //string stationInfo = dr["StationPlace"].ToString() + " 检测到 " + dr["sumCard"].ToString();

            switch (displayType)
            {
                case 0: stationInfo = stationInfo + " 人";
                    break;
                case 1: stationInfo = stationInfo + " 个设备";
                    break;
                case 2: stationInfo = stationInfo + " 个发码器";
                    break;
                default: stationInfo.ToString();
                    break;
            }

            smvpSingleStation.LabelStationInfoText = stationInfo;

            smvpSingleStation.LayoutType = VSPanelLayoutType.VerticalType;

            //新加的
            //smvpSingleStation.Left = pnlLeft1.Left + pnlLeft1.Width + 30;
            smvpSingleStation.Width = varwidth - 250;
            smvpSingleStation.IsShowAddNewStationHeadInfo = false;
            smvpSingleStation.IsShowEditStationInfo = false;
            smvpSingleStation.IsShowDeleteStationInfo = false;

            //smvpSingleStation.MouseClick += new MouseEventHandler(smvpSingleStation_MouseClick);


            return smvpSingleStation;
        }


        #endregion

        #region 构造接收器控件

        public void loadStationHead(string addList, Size size, StationMakeupVspanel smv, int headDisplayType)
        {
            DataSet ds = stationBLL.GetRTStationHeadInfo(addList, headDisplayType);
            DataTable dt = ds.Tables[0];
            DataRow[] dr = dt.Select("StationAddress=" + smv.StationAddress.ToString());
            int rows = dr.GetLength(0) / 2;
            for (int i = 0, j = 1; i < dr.GetLength(0); i += 2, j++)
            {
                PanelStationHeadInfo pshi = null;
                // 如果存在修改信息
                if (smv.Controls.Count == rows + 1)
                {
                    pshi = (PanelStationHeadInfo)smv.Controls[j];
                    pshi.MouseHover += new EventHandler(pshi_MouseHover);
                    this.loadStationHeadInfo(pshi, size, dr[i], dr[i + 1], headDisplayType, addList);
                }// 接收器控件少于得到的接收器信息数添加接收器控件
                else if (smv.Controls.Count < rows + 1)
                {
                    pshi = new PanelStationHeadInfo();
                    pshi.MouseHover += new EventHandler(pshi_MouseHover);
                    pshi.MouseClick += new MouseEventHandler(pshi_MouseClick);          //加载 MouseClick 事件
                    smv.Controls.Add(this.loadStationHeadInfo(pshi, size, dr[i], dr[i + 1], headDisplayType, addList));
                }
            }
            dt.Dispose();
            ds.Dispose();
        }

        #region [ 方法: 显示提示 ]

        void pshi_MouseHover(object sender, EventArgs e)
        {

            toolTip.Active = true;
            PanelStationHeadInfo pshi = ((PanelStationHeadInfo)sender);
            toolTip.SetToolTip((Control)sender, "天线:\r\n" + pshi.OldFA + pshi.ValueAntennaA.FieldName
                + "\r\n" + pshi.OldFB + pshi.ValueAntennaB.FieldName);
        }

        #endregion

        #endregion

        #region 加载接收器信息
        public PanelStationHeadInfo loadDisplayStationHeadInfo(PanelStationHeadInfo pshi, Size size, DataRow dr, int headDisplayType)
        {
            pshi.Cursor = System.Windows.Forms.Cursors.Hand;
            pshi.Height = size.Height;
            pshi.Width = size.Width;
            pshi.SetBackGroundGradineMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;

            SetLabelInfo(pshi.FieldStationAddress, "传输分站编号:");
            SetLabelInfo(pshi.ValueStationAddress, dr["StationAddress"].ToString() + "号");
            if (dr["StationHeadState"].ToString() == "-1000")
            {
                pshi.Enabled = false;
                SetLabelInfo(pshi.ValueStationHeadAddress, dr["StationHeadAddress"].ToString() + "号 故障");
                pshi.ValueStationHeadAddress.FieldColor = Color.Red;
            }
            else
            {
                pshi.Enabled = true;
                pshi.ValueStationHeadAddress.FieldColor = Color.Black;
                SetLabelInfo(pshi.ValueStationHeadAddress, dr["StationHeadAddress"].ToString() + "号");
            }

            string displayStr = "共 " + Convert.ToString(int.Parse(dr["SumCardA"].ToString()) + int.Parse(dr["SumCardB"].ToString()));
            string typeString = "";
            switch (headDisplayType)
            {
                case 0: displayStr = displayStr + " 人";
                    typeString = " 人";
                    break;
                case 1: displayStr = displayStr + " 个";
                    typeString = " 个设备";
                    break;
                case 2: displayStr = displayStr + " 个";
                    typeString = " 个";
                    break;
                default: displayStr.ToString();
                    break;
            }
            /*
             * zdc 修改
             */
            string tempAntennaStr = dr["AntennaA"].ToString().Length == 0 ? "天线1" : dr["AntennaA"].ToString() + ":";
            string AntennaAContent = tempAntennaStr + showAntennaString;
            tempAntennaStr = dr["AntennaB"].ToString().Length == 0 ? "天线2" : dr["AntennaB"].ToString() + ":";
            string AntennaBContent = tempAntennaStr + showAntennaString;

            pshi.OldFA = AntennaAContent;
            pshi.OldFB = AntennaBContent;

            SetLabelInfo(pshi.ValueEnterTotalPerson, displayStr);
            SetLabelInfo(pshi.ValueStationHeadPlace, dr["StationHeadPlace"].ToString());
            SetLabelInfo(pshi.FieldAntennaA, AntennaAContent, new PointF(4, 80));
            SetLabelInfo(pshi.FieldAntennaB, AntennaBContent, new PointF(4, 95));
            SetLabelInfo(pshi.ValueAntennaA, dr["SumCardA"].ToString() + typeString, new PointF(pshi.Width - 48, 80));
            SetLabelInfo(pshi.ValueAntennaB, dr["SumCardB"].ToString() + typeString, new PointF(pshi.Width - 48, 95));
            pshi.StationAddress = dr["StationAddress"].ToString();              //记录该控件所加载的分站地址
            pshi.StationHeadAddress = dr["StationHeadAddress"].ToString();      //记录该控件所加载的接收器地址
            return pshi;
        }

        // 加载分站下的接收器信息
        public PanelStationHeadInfo loadStationHeadInfo(PanelStationHeadInfo pshi, Size size, DataRow dr1, DataRow dr2, int headDisplayType, string strStaAddress)
        {
            pshi.Cursor = System.Windows.Forms.Cursors.Hand;
            pshi.Height = size.Height;
            pshi.Width = size.Width;

            pshi.SetBackGroundGradineMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;

            if (dr1["StationHeadState"].ToString() == "-1000")
            {
                pshi.Enabled = false;
                SetLabelInfo(pshi.ValueStationHeadAddress, dr1["StationHeadAddress"].ToString() + "号 故障");
                pshi.ValueStationHeadAddress.FieldColor = Color.Red;
            }
            else
            {
                pshi.Enabled = true;
                pshi.ValueStationHeadAddress.FieldColor = Color.Black;
                SetLabelInfo(pshi.ValueStationHeadAddress, dr1["StationHeadAddress"].ToString() + "号");
            }

            string displayStr = "共 " + Convert.ToString(int.Parse(dr1["SumCard"].ToString()) + int.Parse(dr2["SumCard"].ToString()));
            string typeString = "";
            switch (headDisplayType)
            {
                case 0: displayStr = displayStr + " 人";
                    typeString = " 人";
                    break;
                case 1: displayStr = displayStr + " 个";
                    typeString = " 个";
                    break;
                case 2: displayStr = displayStr + " 个";
                    typeString = " 个";
                    break;
                default: displayStr.ToString();
                    break;
            }
            string tempAntennaStr = dr1["HeadAntennaName"].ToString().Length == 0 ? "天线1" : dr1["HeadAntennaName"].ToString();
            string AntennaAContent = tempAntennaStr + showAntennaString + ":";
            tempAntennaStr = dr2["HeadAntennaName"].ToString().Length == 0 ? "天线2" : dr2["HeadAntennaName"].ToString();
            string AntennaBContent = tempAntennaStr + showAntennaString + ":";

            pshi.OldFA = AntennaAContent;
            pshi.OldFB = AntennaBContent;

            SetLabelInfo(pshi.ValueEnterTotalPerson, displayStr);
            SetLabelInfo(pshi.ValueStationHeadPlace, dr1["StationHeadPlace"].ToString());
            SetLabelInfo(pshi.FieldAntennaA, AntennaAContent, new PointF(4, 80));
            SetLabelInfo(pshi.FieldAntennaB, AntennaBContent, new PointF(4, 95));
            //SetLabelInfo(pshi.ValueAntennaA, dr1["SumCard"].ToString() + typeString, new PointF(65, 80));
            //SetLabelInfo(pshi.ValueAntennaB, dr2["SumCard"].ToString() + typeString, new PointF(65, 95));
            SetLabelInfo(pshi.ValueAntennaA, dr1["SumCard"].ToString() + typeString, new PointF(pshi.Width - 48, 80));
            SetLabelInfo(pshi.ValueAntennaB, dr2["SumCard"].ToString() + typeString, new PointF(pshi.Width - 48, 95));
            pshi.StationAddress = strStaAddress;                                    //记录该控件所加载的分站地址
            pshi.StationHeadAddress = dr1["StationHeadAddress"].ToString();         //记录该控件所加载的接收器地址
            return pshi;
        }

        private void SetLabelInfo(LabelInfo labelInfo, string text)
        {
            LabelInfo lInfo = labelInfo;
            lInfo.FieldName = text;
            labelInfo = lInfo;
        }

        private void SetLabelInfo(LabelInfo labelInfo, string text, PointF point)
        {
            LabelInfo lInfo = labelInfo;
            lInfo.FieldName = text;
            lInfo.Location = point;
            labelInfo = lInfo;
        }
        #endregion

        #region 构造只显示分站
        public PanelStationInfo loadDisplayStationInfo(PanelStationInfo pshi, DataRow dr, int headDisplayType)
        {
            pshi.Cursor = System.Windows.Forms.Cursors.Hand;
            pshi.Height = 120;
            pshi.Width = 125;
            pshi.SetBackGroundGradineMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;

            SetLabelInfo(pshi.FieldStationAddress, "传输分站编号:");

            if (dr["StationState"].ToString() == "-1000")
            {
                pshi.Enabled = false;
                pshi.ValueStationAddress.FieldColor = Color.Red;
                SetLabelInfo(pshi.ValueStationAddress, dr["StationAddress"].ToString() + "号 故障");
            }
            else
            {
                pshi.Enabled = true;
                pshi.ValueStationAddress.FieldColor = Color.Black;
                SetLabelInfo(pshi.ValueStationAddress, dr["StationAddress"].ToString() + "号");
            }

            string displayStr = "共 " + Convert.ToString(int.Parse(dr["SumCard"].ToString()));
            string typeString = "";
            switch (headDisplayType)
            {
                case 0: displayStr = displayStr + " 人";
                    typeString = " 人";
                    break;
                case 1: displayStr = displayStr + " 个设备";
                    typeString = " 个设备";
                    break;
                case 2: displayStr = displayStr + " 个发码器";
                    typeString = " 个发码器";
                    break;
                default: displayStr.ToString();
                    break;
            }
            SetLabelInfo(pshi.ValueEnterTotalPerson, displayStr);
            SetLabelInfo(pshi.ValueStationHeadPlace, "安装位置:" + dr["StationPlace"].ToString());
            pshi.MouseClick += new MouseEventHandler(pshi_Sta_MouseClick);
            return pshi;
        }

        #endregion

        #endregion

        #region 自动事件处理
        void pshi_one_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("此读卡分站内检测到的标识卡信息");
        }

        private void cpConfigHead_CloseButtonClick(object sender, EventArgs e)
        {
            vspDisplayConfig.Visible = false;
        }

        #region 取消 单击事件 Click
        private void cpbtnHide_Click(object sender, EventArgs e)
        {
            vspDisplayConfig.Hide();
        }
        #endregion
        #endregion

        #region 菜单 单击事件 Click

        #region 登录系统
        //登录
        private void tsmLogin_Login_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开登录菜单");

            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }

        //注销
        private void tsmLogin_LoginOut_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开注销菜单");
            LoginBLL.user = "guest";
            //SettingMenuTrue(msMainMenu.Items);
            Power(false);
        }

        //用户信息
        private void tsmUserInfo_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            adminInfo info = new adminInfo();
            info.ShowDialog();
        }



        #endregion

        #region 基本配置

        //分站及相关配置
        private void tsmStationConfig_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开传输分站及相关配置菜单");

            FrmStationManage frmSM = new FrmStationManage();
            frmSM.ShowDialog();
            //Init();
            // InitStationData();              // 初始化加载分站信息

        }

        //员工档案管理
        private void tsmEmployeeManager_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工档案管理菜单");

            //frmEmployeesInfo frmE = new frmEmployeesInfo();
            //frmE.ShowDialog();
        }

        //发码器设置

        private void tsmCodeBlockManager_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开发码器配置菜单");

            FrmSetCodeSender frm = new FrmSetCodeSender();
            frm.ShowDialog();
        }

        //部门、工种、职务、证书
        private void tsmDepartmentManager_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门、工种、职务、证书菜单");

            FrmDepartmentManage frmDepartmentManage = new FrmDepartmentManage();
            frmDepartmentManage.ShowDialog();
        }

        //设备档案管理
        private void tsmEquipmentManager_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开设备档案管理菜单");

            FrmEquManage frm = new FrmEquManage();
            frm.ShowDialog();
        }

        //方向性管理
        private void tsmFrmDirectionalManage_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开方向性配置菜单");

            FrmDirectionalManage frm = new FrmDirectionalManage();
            frm.Show();
        }
        #endregion

        #region 辅助配置
        //区域管理
        private void tsmAreaManager_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开区域配置菜单");

            FrmAreaManage frm = new FrmAreaManage();
            frm.ShowDialog();
        }

        //报警参数设置
        private void tsmAlarmParameterManager_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开报警参数设置菜单");

            FrmAlarmSet frm = new FrmAlarmSet();
            frm.ShowDialog();
        }

        //部门工时单价
        private void MenuDeptUnitPrice_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            DepartmnetSalarySet dss = new DepartmnetSalarySet();
            dss.ShowDialog();
        }

        // 定时打印
        private void tsmTimePrint_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }
            FrmTimePrint frm = new FrmTimePrint();
            frm.ShowDialog();
        }

        //数据库备份和还原
        private void 数据库备份还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            // 数据库备份和还原
            KJ128NMainRun.DataOperate.FrmDataManage frm = new KJ128NMainRun.DataOperate.FrmDataManage();
            frm.ShowDialog();
        }

        //路径基本信息
        private void tsPatnInfo_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            FrmPathInfo frm = new FrmPathInfo();
            frm.ShowDialog();
            frm.Dispose();
        }

        //员工路径关系信息
        private void tspathEmp_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            FrmPathEmp frm = new FrmPathEmp();
            frm.ShowDialog();
            frm.Dispose();
        }

        //路径详细信息
        private void tspathDetail_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            FrmPathDetail frm = new FrmPathDetail();
            frm.ShowDialog();
            frm.Dispose();
        }

        //特殊工种进出区域报警设置
        private void SpecialWorkTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecialWorkTypeTerrialSet swtts = new SpecialWorkTypeTerrialSet();
            if (!IsValidate())
            {
                return;
            }

            swtts.Show();

        }
        #endregion

        #region 实时数据

        //实时发码器信息
        private void tsmiRealTimeCodeSenderInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时发码器信息菜单");

            RealTimeMonitorInfo rtmi = new RealTimeMonitorInfo("");
            rtmi.Show();
        }

        //实时进接收器信息
        private void tsmiRealTimeInStationHeadInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时进读卡分站信息菜单");

            RealTimeInOutStationHeadInfo rtioshi = new RealTimeInOutStationHeadInfo();
            rtioshi.Show();
        }

        //实时进出天线
        private void tsmiRealTimeInOutAntennaInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时进出天线菜单");

            RealTimeInOutAntennaInfo rtioai = new RealTimeInOutAntennaInfo();
            rtioai.Show();
        }

        //实时下井信息
        private void tsmRealTimeInWellInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时下井信息菜单");

            FrmRealTimeInWellInfo frtiwi = new FrmRealTimeInWellInfo(false, "0");
            frtiwi.Show();
        }

        //实时区域信息
        private void tsmiRealTimeAreaInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时区域信息菜单");

            FrmRealTimeInTerritorial frtit = new FrmRealTimeInTerritorial(false);
            frtit.Show();
        }

        //实时超时信息
        private void tsmiRealTimeOverTimeInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时超时信息菜单");

            FrmRealtimeOverTimeInfo frm = new FrmRealtimeOverTimeInfo(false);
            frm.Show();
        }

        //实时分站信息
        private void tsmiRealtimeStationBreak_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时传输分站信息菜单");

            FrmRealtimeStationBreak frm = new FrmRealtimeStationBreak(false);
            frm.Show();
        }

        //实时接收器信息
        private void tsmiRealTimeStaHeadBreak_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时读卡分站信息菜单");

            FrmRealTimeStaHeadBreak frtshb = new FrmRealTimeStaHeadBreak(false);
            frtshb.Show();
        }

        //实时方向性信息
        private void tsmRealTimeDirectional_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时方向性信息菜单");

            FrmRealTimeDirectional frtd = new FrmRealTimeDirectional(false, "", 0, "");
            frtd.Show();
        }

        //发码器低电量信息
        private void tsmiRealtimeAlarmElectricity_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时发码器低电量信息菜单");

            FrmRealtimeAlarmElectricity frtae = new FrmRealtimeAlarmElectricity();
            frtae.Show();
        }

        //实时井下人员汇总信息
        private void tsmiEmployeeClassify_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时井下人员汇总信息菜单");

            EmployeeClassify frm = new EmployeeClassify();
            frm.Show();
        }

        //实时下井人员名单显示
        private void tsmFrmRealTime_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时下井人员名单显示菜单");

            //KJ128NMainRun.RealTime.FrmRealTime frm = new KJ128NMainRun.RealTime.FrmRealTime();
            //frm.Show();
        }

        //实时人员班次查询
        private void MenuRealTimeAttendanceQuery_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时人员班次查询菜单");

            RealTimeAttendanceQuery rtaq = new RealTimeAttendanceQuery();
            rtaq.Show();
        }

        //实时超员信息
        private void tsmiRealTimeOverEmp_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时超员信息菜单");

            FrmRealTimeOverEmp frtoe = new FrmRealTimeOverEmp();
            frtoe.Show();
        }

        //实时路线报警信息
        private void tsmiRealtimeAlarmPath_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时路线报警信息菜单");

            FrmRealTimeAlarmPath frm = new FrmRealTimeAlarmPath();
            frm.Show();
        }

        #endregion

        #region 历史数据

        //历史进出天线信息
        private void tsmiHistoryInOutAntenna_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史进出天线信息菜单");

            FrmHistoryInOutAntenna fhioa = new FrmHistoryInOutAntenna();
            fhioa.Show();
        }

        //历史进出接收器信息
        private void tsmiHistoryInOutStationHeadInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史进出读卡分站信息菜单");

            FrmHisInOutStationHead fhiosh = new FrmHisInOutStationHead();
            fhiosh.Show();
        }

        // 历史下井信息
        private void tsmiHistroyInOutInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史下井信息菜单");

            FrmHisInMineRecordSet frm = new FrmHisInMineRecordSet();
            frm.Show();
        }

        //历史区域信息
        private void tsmiHisInTerritorial_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史区域信息菜单");

            FrmHisInTerritorial frm = new FrmHisInTerritorial();
            frm.Show();
        }

        //历史超时信息
        private void tsmiHisOverTimeInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史超时信息菜单");

            FrmHisOverTimeInfo frm = new FrmHisOverTimeInfo();
            frm.Show();
        }

        //历史分站接收器故障信息
        //private void tsmiHisStationBreak_Click(object sender, EventArgs e)
        //{
        //    ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史分站接收器故障信息菜单");

        //    FrmHisStationBreak frm = new FrmHisStationBreak();
        //    frm.Show();
        //}

        //历史下井记录次数统计
        private void tsmiHistoryInWellTimeTotal_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史下井记录次数统计菜单");

            FrmHisInOutMine fhom = new FrmHisInOutMine();
            fhom.Show();
        }

        //历史下井记录人数统计
        private void tsmiHistoryInWell_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史下井记录人数统计菜单");

            FrmHistoryTotalInfo fhti = new FrmHistoryTotalInfo();
            fhti.Show();
        }

        //历史超员信息
        private void tsmiHisOverTimeOverEmp_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史超员信息菜单");

            FrmHisOverEmp frmoe = new FrmHisOverEmp();
            frmoe.Show();
        }

        //历史路线报警信息
        private void tsHisPathAlarm_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开路线报警信息菜单");

            FrmHisPathAlert frm = new FrmHisPathAlert();
            frm.Show();
        }

       //历史特殊工种进出区域报警信息查询
        private void SpcialWorkTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorySpecialWorkTypeTerrialAlarm frm = new HistorySpecialWorkTypeTerrialAlarm();
            frm.Show();
        }
        #endregion

        #region 考勤信息
        //考勤班制设置
        private void InfoClassMenu_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤班制设置菜单");

            ClassInfoManage cim = new ClassInfoManage();
            cim.Show();
        }

        //考勤时段设置
        private void MenuTimerInterval_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤时段设置菜单");

            FrmTimerInterval FrmTI = new FrmTimerInterval();
            FrmTI.Show();
        }

        //假别设置
        private void MenuHolidayClass_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开假别设置菜单");

            HolidayTypeSet hcs = new HolidayTypeSet();
            hcs.Show();
        }

        //请假管理
        private void MenuHolidayManage_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开请假管理菜单");

            HolidayMange HM = new HolidayMange();
            HM.Show();
        }

        //历史考勤补单
        private void MenuAddHistoryAttendance_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史考勤补单菜单");

            AddHistoryAttendance aa = new AddHistoryAttendance();
            aa.Show();
        }

        //个人出勤统计
        private void MenuAttendacePersonelStatistic_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开个人出勤率统计菜单");

            //AttendacePersonelStatistic aps = new AttendacePersonelStatistic();
            //aps.Show();
        }

        //部门逐日出勤统计
        private void MenuAttendanceDayByDayStatistic_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门逐日出勤统计菜单");

            AttendanceDayByDayStatistic adds = new AttendanceDayByDayStatistic();
            adds.Show();
        }

        //员工考勤原始数据
        private void MenuAttendanceInitialData_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工考勤原始数据菜单");

            AttendanceInitialData aid = new AttendanceInitialData();
            aid.Show();
        }

        //人员考勤明细
        private void MenuAttendanceParticulars_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开人员考勤明细菜单");

            AttendanceParticulars ap = new AttendanceParticulars();
            ap.Show();

        }

        //部门人员出勤率统计
        private void MenuAttendanceRateStatistic_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门人员出勤率统计菜单");

            AttendanceRateStatistic ars = new AttendanceRateStatistic();
            ars.Show();
        }

        //实时考勤补单
        private void MenuRealTimeAdd_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时考勤补单菜单");

            AttendanceRealTime art = new AttendanceRealTime();
            art.Show();
        }

        //历史上下井按班次查询
        private void MenuHistoryClass_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史上下井按班次查询菜单");

            HistoryQueryByClass hqbc = new HistoryQueryByClass();
            hqbc.Show();
        }

        //员工出勤劳动报表
        private void MenuAttendanceSalary_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工出勤劳动报表菜单");

            AttendanceQuerySalary aqs = new AttendanceQuerySalary();
            aqs.Show();
        }

        //各部门干部下井统计报表
        private void MenuAttendanceStatisticByDuty_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开各部门干部下井统计报表菜单");

            AttendanceStatisticByDuty asbd = new AttendanceStatisticByDuty();
            asbd.Show();
        }
        #endregion

        #region 配置信息
        //分站接收器配置信息
        private void tsmFrmStaHeadInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开传输分站读卡分站配置信息菜单");

            FrmConStaHeadInfo frm = new FrmConStaHeadInfo();
            frm.Show();
        }

        //员工配置信息
        private void 员工配置信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工配置信息菜单");

            FrmConEmployeeInfo frm = new FrmConEmployeeInfo();
            frm.Show();
        }

        //部门工种职务配置信息
        private void 部门工种职务配置信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门工种职务配置信息菜单");

            FrmConDeptManage frm = new FrmConDeptManage();
            frm.Show();
        }

        //部门人数汇总信息

        private void tsmiConDeptEmpCounts_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门人数汇总信息菜单");

            FrmConDeptEmpCounts frm = new FrmConDeptEmpCounts();
            frm.Show();
        }
        //设备配置信息
        private void 设备配置信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开设备配置信息菜单");

            FrmConEquManage frm = new FrmConEquManage();
            frm.Show();
        }

        //发码器配置信息

        private void tsmConCodeSenderInfo_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开发码器配置信息菜单");

            FrmConCodeSenderInfo frm = new FrmConCodeSenderInfo();
            frm.Show();
        }

        // 历史每月下井次数统计
        private void tsmHisMonthEmp_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史每月下井次数统计菜单");
            FrmStatMonthEmpInMine frm = new FrmStatMonthEmpInMine();
            frm.ShowDialog();
        }

        //方向性配置信息

        private void tsmFrmConDirectionalManage_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开方向性配置信息菜单");

            FrmConDirectionalManage frm = new FrmConDirectionalManage();
            frm.Show();
        }
        //区域设置信息
        private void tsmiConAreaManage_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开区域设置信息菜单");

            FrmConAreaManage frm = new FrmConAreaManage();
            frm.Show();
        }
        #endregion

        #region 图形
        //历史轨迹回放
        private void tsmtHistroy_Click(object sender, EventArgs e)
        {
            FrmHistroyRoute frmHisRoute = new FrmHistroyRoute();
            frmHisRoute.Show();
        }

        //图形图片配置
        private void tsmtPicconfig_Click(object sender, EventArgs e)
        {
            FrmPicConfig frmPicCfig = new FrmPicConfig();
            frmPicCfig.Show();
        }

        //实时分布
        private void tsmtReadtime_Click(object sender, EventArgs e)
        {
            KJ128NMainRun.Graphics.FrmRealTime frmRTime = new KJ128NMainRun.Graphics.FrmRealTime();
            frmRTime.Show();
        }

        //分站及路径配置
        private void tsmtRouteConfig_Click(object sender, EventArgs e)
        {
            KJ128NMainRun.Graphics.FrmRouteConfig frmRouteCfig = new KJ128NMainRun.Graphics.FrmRouteConfig();
            frmRouteCfig.Show();
        }

        #endregion

        #endregion

        #region 部门树

        #region 加载 部门树

        /// <summary>
        /// 加载 部门树

        /// </summary>
        private void LoadDeptTree()
        {
            using (ds = new DataSet())
            {
                ds = GetDeptInfo();

                #region 以前代码

                //trDept.Nodes.Clear();
                //intDetpCounts = 0;

                //TreeNode tnDept = new TreeNode();
                //tnDept.Text = "所有部门";
                //tnDept.Name = "0";
                //trDept.Nodes.Add(tnDept);
                //LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count, intDept == 0 ? "人" : "个");
                //LoadChildDept(tnDept, ds.Tables[0], intDept == 0 ? "人" : "个");
                //if (intDept == 0)               //人员
                //{
                //    tnDept.Text = "所有部门( " + intDetpCounts.ToString() + " 人)";
                //    cpDepartment.CaptionTitle = "下井人员部门统计      共" + intDetpCounts.ToString() + "人";
                //}
                //else                               //设备
                //{
                //    tnDept.Text = "所有部门( " + intDetpCounts.ToString() + " 个)";
                //    cpDepartment.CaptionTitle = "下井设备部门统计      共" + intDetpCounts.ToString() + "个";
                //}

                #endregion

                if (ds != null && ds.Tables.Count > 0)
                {
                    AddTreeRoot(trDept, ds.Tables[0]);
                }
            }
            trDept.ExpandAll();
        }
        #endregion

        #region 获取部门信息
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns>返回 部门信息(DataSet)</returns>
        private DataSet GetDeptInfo()
        {
            string strSql;
            if (intDept == 0)                   //人员
            {
                strSql = " Select " +
                            " Di.DeptID, " +
                            " Di.ParentDeptID, " +
                            " Di.DeptName, " +
                            " ( " +
                            " Select Count(*) From " +
                            " ( " +
                            " Select Distinct Cs.UserID From RT_InOutMine As Ri left join CodeSender_Set as Cs on Cs.CsSetID=Ri.CsSetID " +
                            " Left Join Emp_NowCompany As En On En.DeptID = Di.DeptID Left Join Emp_Info As Ei On Ei.EmpID = En.EmpID  " +
                            " Where Cs.UserID = Ei.EmpID And Cs.CsTypeID = 0 " +
                            " ) " +
                            " As T1 " +
                            " ) " +
                            " As Counts, " +
                            " Di.DeptLevelID " +
                        " From Dept_Info As Di " +
                        " Order By DeptLevelID ";
            }
            else                                //设备
            {
                strSql = " Select " +
                            " Di.DeptID, " +
                            " Di.ParentDeptID, " +
                            " Di.DeptName, " +
                            " ( " +
                            " Select Count(*) From " +
                            " ( " +
                            " Select Distinct Cs.UserID From RT_InOutMine As Ri left join CodeSender_Set as Cs on Cs.CsSetID=Ri.CsSetID " +
                            " Left Join Emp_NowCompany As En On En.DeptID = Di.DeptID Left Join Emp_Info As Ei On Ei.EmpID = En.EmpID  " +
                            " Where Cs.UserID = Ei.EmpID And Cs.CsTypeID = 1 " +
                            " ) " +
                            " As T1 " +
                            " ) " +
                            " As Counts, " +
                            " Di.DeptLevelID " +
                        " From Dept_Info As Di " +
                        " Order By DeptLevelID ";
            }
            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region 根据部门ID，获取该部门的下井人数

        private string GetDeptCounts(string strDeptID)
        {
            string strSql;
            //if (intDept == 0)                   //人员
            //{
            strSql = " Select count(Distinct Ri.CodeSenderAddress ) as Counts " +
                      " From RT_InOutMine As Ri left join CodeSender_Set as Cs on Cs.CsSetID=Ri.CsSetID  " +
                            " left join Emp_NowCompany as En on En.EmpID=Cs.UserID and CsTypeID= " + intDept.ToString() + " " +
                     " Where DeptID=" + strDeptID + " or DeptID in(select DeptID From Dept_Info Where ParentDeptID=" + strDeptID + " ) " +
                         " or DeptID in(Select DeptID From Dept_Info where DeptID in(Select DeptID From Dept_Info Where ParentDeptID=" + strDeptID + ")) " +
                         " or DeptID in(select DeptID From Dept_Info Where DeptID in(select DeptID From Dept_Info Where DeptID in(Select DeptID From Dept_Info where ParentDeptID =" + strDeptID + "))) ";
            //}
            //else                                //设备
            //{
            //    strSql = " Select " +
            //                " Di.DeptID, " +
            //                " Di.ParentDeptID, " +
            //                " Di.DeptName, " +
            //                " ( " +
            //                " Select Count(*) From " +
            //                " ( " +
            //                " Select Distinct Cs.UserID From RT_InOutMine As Ri left join CodeSender_Set as Cs on Cs.CsSetID=Ri.CsSetID " +
            //                " Left Join Emp_NowCompany As En On En.DeptID = Di.DeptID Left Join Emp_Info As Ei On Ei.EmpID = En.EmpID  " +
            //                " Where Cs.UserID = Ei.EmpID And Cs.CsTypeID = 1 " +
            //                " ) " +
            //                " As T1 " +
            //                " ) " +
            //                " As Counts, " +
            //                " Di.DeptLevelID " +
            //            " From Dept_Info As Di";
            //}
            //strSql += " Where Di.DeptID=" + strDeptID;
            DataSet tempDs;
            using (tempDs = new DataSet())
            {
                tempDs = dbacc.GetDataSet(strSql);
                if (tempDs != null && tempDs.Tables.Count > 0)
                {
                    if (tempDs.Tables[0].Rows.Count > 0)
                    {
                        return tempDs.Tables[0].Rows[0]["Counts"].ToString();
                    }
                }
            }
            return null;
        }
        #endregion

        #region 给 TreeView 控件加载部门
        /// <summary>
        /// 给 TreeView 控件加载部门
        /// </summary>
        /// <param name="tn">父节点</param>
        /// <param name="intParentDeptID">父ID</param>
        /// <param name="intRowsIndex">当前行数</param>
        /// <param name="intRowsCount">总行数</param>
        private void LoadChildDept(TreeNode tn, int intParentDeptID, int intRowsIndex, int intRowsCount, string strUnit)
        {
            if (intRowsIndex == intRowsCount)
            {
                return;
            }
            if (int.Parse(ds.Tables[0].Rows[intRowsIndex]["ParentDeptID"].ToString()).Equals(intParentDeptID))
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = ds.Tables[0].Rows[intRowsIndex]["DeptName"].ToString() + " (" + GetDeptCounts(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()) /*ds.Tables[0].Rows[intRowsIndex]["Counts"].ToString()*/ + strUnit + ")";
                tnChild.Name = ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString();
                intDetpCounts += Convert.ToInt32(ds.Tables[0].Rows[intRowsIndex]["Counts"]);
                tn.Nodes.Add(tnChild);

                LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount, strUnit);
            }

            LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount, strUnit);
        }
        #endregion

        #region 点击 部门树 跳转到 实时下井信息
        private void trDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            blIsClickDept = true;
        }

        private void trDept_DoubleClick(object sender, EventArgs e)
        {
            if (blIsClickDept)
            {
                if (trDept.SelectedNode != null)
                {
                    FrmRealTimeInWellInfo frtiwi = new FrmRealTimeInWellInfo(false, trDept.SelectedNode.ImageKey);
                    frtiwi.Show(((KJ128NInterfaceShow.FrmMain)frmmain).dockPanel1,DockState.Document);
                }
                blIsClickDept = false;
            }
        }
        #endregion

        #region 周自豪树

        private TreeNode tnDept = null ;

        private void AddTreeRoot(TreeView tr,DataTable dt)
        {
            DataRow[] dr = dt.Select("ParentDeptID=0");

            int sum = 0;

            foreach (DataRow d in dt.Rows)
            {
                sum += Convert.ToInt32(d["Counts"].ToString());
            }

            if (tnDept == null)
            tnDept = new TreeNode();

            tnDept.Text = "所有部门";
            tnDept.Name = "0";
            if (!tr.Nodes.Contains(tnDept))
            {
                tr.Nodes.Add(tnDept);
            }

            tnDept.Text = "所有部门( " + sum.ToString() + " 人)";

            AddTreeNode(tnDept, "0", dt);
            
        }

        private void AddTreeNode(TreeNode tr, string id,DataTable dt)
        {
            DataRow[] dr = dt.Select("ParentDeptID=" + id);
            if (tr.Nodes.Count >= dr.Length)
            {
                for (int i = 0; i < tr.Nodes.Count; i++)
                {
                    if (i < dr.Length)
                    {
                        tr.Nodes[i.ToString()].Text = dr[i]["DeptName"].ToString() + "(" + dr[i]["Counts"].ToString() + "人)";
                        tr.Nodes[i.ToString()].ImageKey = dr[i]["DeptID"].ToString();
                        AddTreeNode(tr.Nodes[i.ToString()], dr[i].ItemArray[0].ToString(), dt);
                    }
                    else
                        tr.Nodes.RemoveAt(i);
                }
            }
            else
            {
                for (int i = 0; i < dr.Length; i++)
                {
                    if (tr.Nodes.ContainsKey(i.ToString()))
                    {
                        tr.Nodes[i.ToString()].Text = dr[i]["DeptName"].ToString() + "(" + dr[i]["Counts"].ToString() + "人)";
                        tr.Nodes[i.ToString()].ImageKey = dr[i]["DeptID"].ToString();
                        AddTreeNode(tr.Nodes[i.ToString()], dr[i].ItemArray[0].ToString(), dt);
                    }
                    else
                    {
                        tr.Nodes.Add(i.ToString(), dr[i]["DeptName"].ToString() + "(" + dr[i]["Counts"].ToString() + "人)", dr[i]["DeptID"].ToString());

                        AddTreeNode(tr.Nodes[i.ToString()], dr[i].ItemArray[0].ToString(), dt);
                    }
                }
            }
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
            //tsmUserPopedom.Enabled = bl;
            //tsmAttendanceInfoSet.Enabled = bl;
            //tsmBaseConfig.Enabled = bl;
            //tsmAssistConfig.Enabled = bl;
            //tsmLogin_LoginOut.Enabled = bl;
            //tsmLogin_Login.Enabled = !bl;
        }
        #endregion

        #region 属性

        /// <summary>
        /// IsMenu属性

        /// </summary>
        public static bool IsMenu
        {
            get { return isMenu; }
            set
            {
                isMenu = value;
            }
        }
        #endregion

        #region 只显示 分站 点击事件 MouseClick
        void pshi_Sta_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PanelStationInfo psi = (PanelStationInfo)sender;
                vspStaHead.Visible = true;
                string strSta = psi.ValueStationAddress.ToString();
                int intSta = strSta.Length;
                string strCounts;
                mbll.SearchStaInfo(psi.ValueStationAddress.ToString().Substring(0, intSta - 1), displayType, dgvStaHead, out strCounts);
                switch (displayType)
                {
                    case 0:
                        strCounts += " 人";
                        break;
                    case 1:
                        strCounts += " 设备";
                        break;
                    case 2:
                        strCounts += " 发码器";
                        break;
                    default:
                        break;
                }
                bcpStaHead.CaptionTitle = strSta + "传输分站具体人员或设备信息(" + mbll.SelectStationPlace(strSta.Substring(0, intSta - 1)) + ")" + " 共 " + strCounts;
            }
        }
        #endregion

        #region 显示分站和接收器图标 点击事件 MouseClick
        void pshi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PanelStationHeadInfo pshi = (PanelStationHeadInfo)sender;
                vspStaHead.Visible = true;
                string strCounts;
                mbll.SearchStaHeadInfo(pshi.StationAddress, pshi.StationHeadAddress, headDisplayType, dgvStaHead, out strCounts);
                switch (headDisplayType)
                {
                    case 0:
                        strCounts += " 人";
                        break;
                    case 1:
                        strCounts += " 设备";
                        break;
                    case 2:
                        strCounts += " 发码器";
                        break;
                    default:
                        break;
                }
                bcpStaHead.CaptionTitle = pshi.StationAddress + "号传输分站" + pshi.StationHeadAddress + "号读卡分站具体人员或设备信息(" + mbll.SelectStaHeadPlace(pshi.StationAddress, pshi.StationHeadAddress) + ")" + " 共 " + strCounts;
            }
        }
        #endregion

        #region 接收器具体信息 关闭事件
        private void buttonCaptionPanel19_CloseButtonClick(object sender, EventArgs e)
        {
            vspStaHead.Visible = false;
        }
        #endregion

        #region 接收器具体信息 返回 单击事件 Click
        private void bcpExit_Click(object sender, EventArgs e)
        {
            vspStaHead.Visible = false;
        }
        #endregion

        #region 显示设置
        #region 页面设置 Click
        void cpPageConfig_Click(object sender, EventArgs e)
        {
            //系统是否强验证
            if (!(FrmMain.blIsMemorize && !LoginBLL.user.Equals("guest")))
            {
                //验证用户密码
                if (!IsValidate())
                {
                    return;
                }
            }
            switch (intDept)
            {
                case 0:
                    rbtnDept0.Checked = true;
                    break;
                case 1:
                    rbtnDept1.Checked = true;
                    break;
                default:
                    break;
            }
            switch (intDirectional)
            {
                case 0:
                    rbtnDir0.Checked = true;
                    break;
                case 1:
                    rbtnDir1.Checked = true;
                    break;
                default:
                    break;
            }
            switch (displayType)
            {
                case 0: rbtnStation0.Checked = true;
                    break;
                case 1: rbtnStation1.Checked = true;
                    break;
                case 2: rbtnStation2.Checked = true;
                    break;
                default:
                    break;
            }
            switch (headDisplayType)
            {
                case 0: rbtnHead0.Checked = true;
                    break;
                case 1: rbtnHead1.Checked = true;
                    break;
                case 2: rbtnHead2.Checked = true;
                    break;
                default:
                    break;
            }
            switch (displayFun)
            {
                case 1: rbtnFun1.Checked = true;
                    break;
                case 2: rbtnFun2.Checked = true;
                    break;
                case 3: rbtnFun3.Checked = true;
                    break;
                default:
                    break;
            }
            txtHeight.Text = size.Height.ToString();
            txtWidth.Text = size.Width.ToString();
            txtPageSum.Text = ppageSum.ToString();

            txtVartical.Text = vartical.ToString();
            txtLeftVartical.Text = leftVartical.ToString();
            txtTopVartical.Text = topVartical.ToString();
            txtOutWellTime.Text = intOutWellTime.ToString();

            vspDisplayConfig.Show();
        }
        #endregion

        #region 初始化显示设置

        /// <summary>
        /// 初始化显示设置

        /// </summary>
        private void Initdisplay()
        {
            using (ds = new DataSet())
            {
                ds = mbll.GetInitdisplay();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        displayFun = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        ppageSum = Convert.ToInt32(ds.Tables[0].Rows[1][0]);
                        vartical = Convert.ToInt32(ds.Tables[0].Rows[2][0]);
                        leftVartical = Convert.ToInt32(ds.Tables[0].Rows[3][0]);
                        topVartical = Convert.ToInt32(ds.Tables[0].Rows[4][0]);
                        displayType = Convert.ToInt32(ds.Tables[0].Rows[5][0]);
                        headDisplayType = Convert.ToInt32(ds.Tables[0].Rows[6][0]);
                        intDept = Convert.ToInt32(ds.Tables[0].Rows[7][0]);
                        intDirectional = Convert.ToInt32(ds.Tables[0].Rows[8][0]);
                        size = new Size(Convert.ToInt32(ds.Tables[0].Rows[9][0]), Convert.ToInt32(ds.Tables[0].Rows[10][0]));
                        intOutWellTime = Convert.ToInt32(ds.Tables[0].Rows[11][0]) / 60;
                    }
                }
            }
            InitStationData();                  // 初始化分站


            LoadDeptTree();                     //重新加载部门树

            vspDisplayConfig.Hide();            //关闭 显示设置

        }


        #endregion

        #region 显示设置保存
        private void cpbtnSave_Click(object sender, EventArgs e)
        {

            //if (txtPageSum.Text)
            int pageSum = 1;

            try
            {
                pageSum = Convert.ToInt32(txtPageSum.Text);
            }
            catch
            {
                MessageBox.Show("请检查配置正确","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if (pageSum <= 0)
            {
                MessageBox.Show("请检查配置正确,确保每页显示数大于0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            //存入日志
            LogSave.Messages("[FrmMain]", LogIDType.UserLogID, "修改实时显示信息");

            size.Height = int.Parse(txtHeight.Text);
            size.Width = int.Parse(txtWidth.Text);
            ppageSum = int.Parse(txtPageSum.Text);

            vartical = int.Parse(txtVartical.Text);
            leftVartical = int.Parse(txtLeftVartical.Text);
            topVartical = int.Parse(txtTopVartical.Text);

            varwidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

            // 分站显示宽度
            varwidth -= leftVartical;

            vspStationInfo.LeftInterval = leftVartical;
            vspStationInfo.TopInterval = topVartical;
            vspStationInfo.VerticalInterval = vartical;

            // 部门显示方式
            if (rbtnDept0.Checked)
            {
                intDept = 0;
                //displayDeptType = 0;
            }
            else if (rbtnDept1.Checked)
            {
                intDept = 1;
                //displayDeptType = 1;
            }

            //方向性显示方式

            if (rbtnDir0.Checked)
            {
                intDirectional = 0;
            }
            else if (rbtnDir1.Checked)
            {
                intDirectional = 1;
            }

            // 分站显示方式
            if (rbtnStation0.Checked)
            {
                displayType = 0;
            }
            else if (rbtnStation1.Checked)
            {
                displayType = 1;
            }
            else if (rbtnStation2.Checked)
            {
                displayType = 2;
            }

            // 接收器显示方式
            if (rbtnHead0.Checked)
            {
                headDisplayType = 0;
            }
            else if (rbtnHead1.Checked)
            {
                headDisplayType = 1;
            }
            else if (rbtnHead2.Checked)
            {
                headDisplayType = 2;
            }

            // 显示方式处理
            if (rbtnFun1.Checked)
            {
                displayFun = 1;
            }
            else if (rbtnFun2.Checked)
            {
                displayFun = 2;
            }
            else if (rbtnFun3.Checked)
            {
                displayFun = 3;
            }
            intOutWellTime = Convert.ToInt32(txtOutWellTime.Text.Trim());
            mbll.SaveDisplayInfo(displayFun.ToString(), ppageSum.ToString(), vartical.ToString(), leftVartical.ToString(), topVartical.ToString(), displayType.ToString(), headDisplayType.ToString(), intDept.ToString(), intDirectional.ToString(), size.Height.ToString(), size.Width.ToString(), Convert.ToString(intOutWellTime * 60));
           
            vspStationInfo.Controls.Clear();    // 清空
            InitStationData();                  // 初始化分站


            LoadDeptTree();                     //重新加载部门树

            vspDisplayConfig.Hide();            //关闭 显示设置



        }

        #endregion
        #endregion

        #region 添加报警 LinkLabel
        private void AddAlarmLinkLabel()
        {
            //cpAlram.Controls.Clear();
            DataTable dt = new DataTable();

            dt = mbll.SearchAlarmType();
            if (dt!=null && dt.Rows.Count > 0)
            {
                int i = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    LinkLabel ll = new LinkLabel();
                    ll.Text = dr[0].ToString();
                    ll.Location = new Point(32 + i, 30);
                    ll.Size = new Size(80, 12);
                    //ll.Font.Underline = false;
                    //ll.MouseClick += new MouseEventHandler(ll_MouseClick);
                    ll.Click += new EventHandler(ll_Click);
                    //ll.LinkColor = Color.Red;
                    //cpAlram.Controls.Add(ll);
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
                        try
                        {
                            froti1.Show();
                        }
                        catch
                        {
                            froti1 = new FrmRealtimeOverTimeInfo(true);
                            froti1.Show();
                        }
                        froti1.Activate();
                        break;
                    case "区域报警":
                        try
                        {
                            frtit1.Show();
                        }
                        catch
                        {
                            frtit1 = new RealTimeSpecialWorkTypeTerrialAlarm();
                            frtit1.Show();
                        }
                        frtit1.Activate();
                        break;
                    case "分站故障报警":
                        try
                        {
                            frsb1.Show();
                        }
                        catch
                        {
                            frsb1 = new FrmRealtimeStationBreak(true);
                            frsb1.Show();
                        }
                        frsb1.Activate();
                        break;
                    case "超员报警":
                        try
                        {
                            frtoe1.Show();
                        }
                        catch
                        {
                            frtoe1 = new FrmRealTimeOverEmp();
                            frtoe1.Show();
                        }
                        frtoe1.Activate();
                        break;
                    case "低电量报警":
                        try
                        {
                            frae1.Show();
                        }
                        catch
                        {
                            frae1 = new FrmRealtimeAlarmElectricity();
                            frae1.Show();
                        }
                        frae1.Activate();
                        break;
                    case "接收器故障报警":
                        try
                        {
                            frtshb1.Show();
                        }
                        catch
                        {
                            frtshb1 = new FrmRealTimeStaHeadBreak(true);
                            frtshb1.Show();
                        }
                        frtshb1.Activate();
                        break;
                    case "工作异常报警":
                        try
                        {
                            frtap.Show();
                        }
                        catch
                        {
                            frtap = new FrmRealTimeAlarmPath();
                            frtap.Show();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region 判断是否 报警
        //private void IsAlarm()
        //{
        //    DataTable dt;
        //    //blIsAlarmErr = false;
        //    foreach (Control cl in cpAlram.Controls)
        //    {
        //        LinkLabel ll;
        //        switch (cl.Text)
        //        {
        //            case "超时报警":
        //                ll = (LinkLabel)cl;
        //                if (mbll.IsAlarm(1))
        //                {
        //                    ll.LinkColor = Color.Red;
        //                    using (dt = new DataTable())
        //                    {
        //                        dt = mbll.LoadAlarmPath(1);
        //                        if (dt != null && dt.Rows.Count > 0)
        //                        {
        //                            AlarmSound(1, dt);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    ll.LinkColor = Color.FromArgb(0, 0, 255);
        //                    ll.Enabled = false;
        //                }
        //                break;
        //            case "区域报警":
        //                ll = (LinkLabel)cl;
        //                if (mbll.IsAlarm(2))
        //                {
        //                    ll.LinkColor = Color.Red;
        //                    using (dt = new DataTable())
        //                    {
        //                        dt = mbll.LoadAlarmPath(2);
        //                        if (dt != null && dt.Rows.Count > 0)
        //                        {
        //                            AlarmSound(2, dt);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    ll.LinkColor = Color.FromArgb(0, 0, 255);
        //                    ll.Enabled = false;
        //                }
        //                break;
        //            case "分站故障报警":
        //                ll = (LinkLabel)cl;
        //                if (mbll.IsAlarm(3))
        //                {
        //                    ll.LinkColor = Color.Red;
        //                    using (dt = new DataTable())
        //                    {
        //                        dt = mbll.LoadAlarmPath(3);
        //                        if (dt != null && dt.Rows.Count > 0)
        //                        {
        //                            AlarmSound(3, dt);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    ll.LinkColor = Color.FromArgb(0, 0, 255);
        //                    ll.Enabled = false;
        //                }
        //                break;
        //            case "超员报警":
        //                ll = (LinkLabel)cl;
        //                if (mbll.IsAlarm(4))
        //                {
        //                    ll.LinkColor = Color.Red;
        //                    using (dt = new DataTable())
        //                    {
        //                        dt = mbll.LoadAlarmPath(4);
        //                        if (dt != null && dt.Rows.Count > 0)
        //                        {
        //                            AlarmSound(4, dt);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    ll.LinkColor = Color.FromArgb(0, 0, 255);
        //                    ll.Enabled = false;
        //                }
        //                break;
        //            case "低电量报警":
        //                ll = (LinkLabel)cl;
        //                if (mbll.IsAlarm(5))
        //                {
        //                    ll.LinkColor = Color.Red;
        //                    using (dt = new DataTable())
        //                    {
        //                        dt = mbll.LoadAlarmPath(5);
        //                        if (dt != null && dt.Rows.Count > 0)
        //                        {
        //                            AlarmSound(5, dt);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    ll.LinkColor = Color.FromArgb(0, 0, 255);
        //                    ll.Enabled = false;
        //                }
        //                break;
        //            case "接收器故障报警":
        //                ll = (LinkLabel)cl;
        //                if (mbll.IsAlarm(6))
        //                {
        //                    ll.LinkColor = Color.Red;
        //                    using (dt = new DataTable())
        //                    {
        //                        dt = mbll.LoadAlarmPath(6);
        //                        if (dt != null && dt.Rows.Count > 0)
        //                        {
        //                            AlarmSound(6, dt);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    ll.LinkColor = Color.FromArgb(0, 0, 255);
        //                    ll.Enabled = false;
        //                }
        //                break;

        //            case "工作异常报警":
        //                ll = (LinkLabel)cl;
        //                if (mbll.IsAlarm(7))
        //                {
        //                    ll.LinkColor = Color.Red;
        //                    using (dt = new DataTable())
        //                    {
        //                        dt = mbll.LoadAlarmPath(7);
        //                        if (dt != null && dt.Rows.Count > 0)
        //                        {
        //                            AlarmSound(7, dt);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    ll.LinkColor = Color.FromArgb(0, 0, 255);
        //                    ll.Enabled = false;
        //                }

        //                break;

        //            default:
        //                break;
        //        }
        //    }
        //}
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
                    break;
                case 3:
                case 4:
                    strNowPath = dt.Rows[0][1].ToString();
                    //Sound(strNowPath);
                    strAlarm[intAlarmType - 1] = strNowPath;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 播放声音
         ///<summary>
         ///播放声音
         ///</summary>
         ///<param name="str">声音文件路径</param>
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

            }
            catch (Exception ex)
            {
                //label7.Text = ex.Message.ToString() + str;
                //label7.Visible = true;
                blIsAlarmErr = false;
                //blIsAlarmErr = true;
                simpleSound = new SoundPlayer(@strPath);
            }

        }
        #endregion

        #region 定时播放报警声音
        private void timerAlarm_Tick(object sender, EventArgs e)
        {
            for (int i = intAlarm - 1; i < 6; i++)
            {
                if (strAlarm[i] != "")
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
            if (intAlarm > 6)
            {
                //lbAlarmErr.Visible = blIsAlarmErr;          //是否显示错误提示
                //label7.Visible = blIsAlarmErr;
                intAlarm = 1;
                blIsAlarmErr = false;

            }
        }
        #endregion

        #region [ 事件: 窗体关闭事件 ]

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(LoginBLL.user.Equals("KJ128AORKJ128N"))
            //{

            //    // 终止定时打印线程
            //    th.Abort();
            //}
            //else if (LoginBLL.user == "guest")
            //{

            //    DialogResult dre = MessageBox.Show("你没有权限关闭本软件,如想关闭本软件，请重先登录！", "提示", MessageBoxButtons.YesNo);
            //    if (dre == DialogResult.Yes)
            //    {
            //        FrmLogin frm = new FrmLogin();
            //        frm.ShowDialog();
            //    }
            //    e.Cancel = true;
            //}
            //else
            //{
            //    DialogResult dre = MessageBox.Show("确定要关闭本软件吗？", "提示", MessageBoxButtons.YesNo);
            //    if (dre == DialogResult.No)
            //    {
            //        e.Cancel = true;
            //    }
            //    // 终止定时打印线程
            //    th.Abort();
            //}

            e.Cancel = true;
        }

        #endregion

        private void 用户组管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            usergroupInfo user = new usergroupInfo();
            user.ShowDialog();
        }

        private void 用户权限分配ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            usergroup use = new usergroup();
            use.ShowDialog();
        }

        #region [ 方法: 菜单处理相关 ]

        #region 窗体事件
        int cc = 0;
        private void FrmMain_Activated(object sender, EventArgs e)
        {
            timeControl_Tick(null, null);
            if (cc == 0)
            {
                cc++;
                if (LoginBLL.user == "3shine")
                {

                    GetMenus();
                }
                else
                {
                    Power(false);                   // 权限管理
                }
            }
            //this.tsmLogin_Login.Enabled = true;
            //tsmLoginManage.Enabled = true;

        }
        private void FrmLeftTree_Load(object sender, EventArgs e)
        {
            //setData();
            //this.tsmLogin_Login.Enabled = true;
            //tsmLoginManage.Enabled = true;


            #region 删除SwitchDatabase.xml

            //try
            //{
            //    if (File.Exists("SwitchDatabase.xml"))
            //    {
            //        File.Delete("SwitchDatabase.xml");
            //    }
            //}
            //catch
            //{

            //}

            #endregion

            if (New_DBAcess.blIsClient)
            {
                cpPageConfig.Enabled = false;
            }
        }
        #endregion 

        #region 设置树形控件
        public void TreeViewData(TreeView treeview)
        {
            //foreach (ToolStripItem item in msMainMenu.Items)
            //{
            //    TreeNode node = new TreeNode();
            //    getSonMenu(item, node);
            //    node.Text = item.Text.Substring(0,item.Text.Length-4);
            //    node.Name = item.Name;
            //    treeview.Nodes.Add(node);
            //}
        }

        public void getSonMenu(ToolStripItem item, TreeNode node)
        {
            ToolStripMenuItem tItem = (ToolStripMenuItem)item;

            if (tItem.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem titem in tItem.DropDownItems)
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
            //foreach (ToolStripItem item in msMainMenu.Items)
            //{
            //    getSonMenus(item, "", ref strSQL);
            //}
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
        //public void setData()
        //{
        //    UserGroupBLL bll = new UserGroupBLL();
        //    DataSet ds = bll.selectUserGroups(LoginBLL.user.ToString());
        //    Hashtable ht = new Hashtable();
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            if (dr[3].ToString().Trim() == "")
        //            {
        //                if (ht.Contains(dr[2].ToString()))
        //                {
        //                    ht[dr[2].ToString()] = Convert.ToBoolean(dr[1]);
        //                }
        //                else
        //                {
        //                    ht.Add(dr[2].ToString(), Convert.ToBoolean(dr[1]));
        //                }
        //            }
        //            else
        //            {
        //                if (ht.Contains(dr[2].ToString()))
        //                {
        //                    ht[dr[2].ToString()] = false;
        //                }
        //                else
        //                {
        //                    ht.Add(dr[2].ToString(), false);
        //                }
        //            }
        //        }
        //        foreach (ToolStripItem item in msMainMenu.Items)
        //        {
        //            getSonMenus(item, ht);
        //        }
        //    }
        //}

        //public void getSonMenus(ToolStripItem item, Hashtable ht)
        //{
        //    ToolStripMenuItem tItem = (ToolStripMenuItem)item;
        //    tItem.Enabled = Convert.ToBoolean(ht[tItem.Name]);

        //    if (tItem.DropDownItems.Count > 0)
        //    {
        //        foreach (ToolStripItem titem in tItem.DropDownItems)
        //        {
        //            ToolStripMenuItem toolMenu = (ToolStripMenuItem)titem;
        //            getSonMenus(toolMenu, ht);
        //        }
        //    }
        //}
        #endregion

        #endregion


        #region [ 方法: 用户验证密码 ]

        private bool IsValidate()
        {
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

        #region [ 菜单点击事件 ]

        private void rtPathCheck_Click(object sender, EventArgs e)
        {
            FrmRealTimePathCheck frm = new FrmRealTimePathCheck();
            frm.ShowDialog();
        }

        private void hisPathCheck_Click(object sender, EventArgs e)
        {
            FrmHisPathCheck frm = new FrmHisPathCheck();
            frm.ShowDialog();
        }
        
        #endregion

        private void dgvRTDept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




    }

}