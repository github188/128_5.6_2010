using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using System.Drawing.Drawing2D;
using KJ128NDBTable;
using System.Data.SqlClient;
using KJ128N.Command;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;
using System.Xml;
using System.IO;

namespace KJ128NMainRun.StationManage
{
    public partial class A_FrmStationInfo : Wilson.Controls.Docking.DockContent
    {

        /// <summary>
        /// 是否是修改
        /// </summary>
        public bool blIsUpDate = true;

        /// <summary>
        /// 热备当前刷新次数
        /// </summary>
        private int intRefReshCount = 0;

        /// <summary>
        /// 热备刷新最大次数
        /// </summary>
        private int intHostBackRefCount = 2;

        /// <summary>
        /// 刷新模式(1：分站；2：探头)
        /// </summary>
        public int intSelectModel = 1;

        public int intStationAddress = -1;

        public int intStationHeadID = -1;

        public int intStationAddressJudgment;

        private static int pageSize = 20;
        private A_StationBLL sbll = new A_StationBLL();
        private A_EnumBLL ebll = new A_EnumBLL();
        private StationMakeupVspanel tempSingleStation = null;

        private CaptionPanel sumCount = null;
        private ButtonCaptionPanel cpUp = null;
        private ButtonCaptionPanel cpDown = null;
        private CaptionPanel txtPage = null;
        private CaptionPanel lblSumPage = null;
        private TextBox txtCheckPage = null;
        private ButtonCaptionPanel cpCheckPage = null;
        private ButtonCaptionPanel cpCount=null;
        private ComboBox cbpageSize = null;

        private DataSet  dsTemp;

        private bool _IsSave = false;

        public bool IsSave
        {
            get { return _IsSave; }
            set { _IsSave = value; }
        }

        #region 私有变量
        private bool isMove = false;            // (设置面板) 是否移动
        private int mleft = 0;
        private int mtop = 0;
        /// <summary>
        /// 存储分站信息
        /// </summary>
        private DataTable dtStationInfo = new DataTable();

        private ButtonCaptionPanel shAddStationTitle = new ButtonCaptionPanel();//标题

        private CaptionPanel cpStationConfig = new CaptionPanel();//分站配置外框

        /// <summary>
        /// 分站配置主面板
        /// </summary>
        private VSPanel vspStationConfigInfo=new VSPanel();//分站配置主面板

        private int cmsStationHand1;
        public int _cmsStationHand1
        {
            get { return cmsStationHand1; }
            set { cmsStationHand1 = value; }
        }

        private string  cmsStationHand2;
        public string  _cmsStationHand2
        {
            get { return cmsStationHand2; }
            set { cmsStationHand2 = value; }
        }

        public delegate void StationChange();

        public event StationChange StationChanged;

        #endregion
        
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public A_FrmStationInfo()
        {
            InitializeComponent();
            
           
            InitComponent();//初始化窗体布局，组件的放置
            //vspAddNewStation.Visible = false;

            SetDataTableStationInfo();//给表赋初值

            InitData();                 // 加载分站及接收器信息
            timer1.Stop();
            timer2.Stop();
            this.Controls.Add(pl_AddStationInfo);
            pl_AddStationInfo.Size = pl_AddStaHeadInfo.Size = new Size(393, 299);
            this.StationChanged += new StationChange(A_FrmStationInfo_StationChanged);
        }

        void A_FrmStationInfo_StationChanged()
        {
            
        }
        #endregion

        /// <summary>
        /// 未解决
        /// 给分站信息表赋值
        /// </summary>
        private void SetDataTableStationInfo()
        {
            dtStationInfo.Columns.Add("地址号", Type.GetType("System.Int16"));
            dtStationInfo.Columns.Add("安装位置", Type.GetType("System.String"));
            dtStationInfo.Columns.Add("联系电话", Type.GetType("System.String"));
            dtStationInfo.Columns.Add("分站类型", Type.GetType("System.String"));
            dtStationInfo.Columns.Add("分站组号", Type.GetType("System.Int16"));
            dtStationInfo.Columns.Add("版本号", Type.GetType("System.Int16"));
            dtStationInfo.Columns.Add("备注", Type.GetType("System.Int16"));
        }

        #region 初始化窗体，组件的布局

        /// <summary>
        /// 初始化窗体，组件的布局
        /// </summary>
        private void InitComponent()
        {
            cpStationConfig.Location = new Point(5, 43);
            cpStationConfig.Size = new Size(this.Width, 32);
            cpStationConfig.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top) | (AnchorStyles.Right));
            cpStationConfig.CaptionTitle = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station) + "及" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead) + "配置信息";//图示_当前"+KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station)+"配置";
            cpStationConfig.CaptionHeight = 30;
            cpStationConfig.CaptionTitleTop = 8;
            cpStationConfig.IsOnlyCaption = true;
            cpStationConfig.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption;

            // 添加翻页按钮
            sumCount = new CaptionPanel();
            sumCount.CaptionTitleLeft = 0;
            sumCount.Location = new Point(this.Width - 63 - 200 -155, 10);
            sumCount.Size = new Size(130,32);

            cpStationConfig.Controls.Add(sumCount);
            
            cpUp = new ButtonCaptionPanel();
            cpUp.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            cpUp.Location = new Point(this.Width-63-60-155, 10);
            cpUp.Size = new Size(63, 32);
            cpUp.CaptionTitle = "上一页";
            cpUp.IsOnlyCaption = true;
            cpUp.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;
            //cpUp.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption; --zdc
            cpUp.Click += new EventHandler(cpUp_Click);
            
            cpStationConfig.Controls.Add(cpUp);


            cpDown = new ButtonCaptionPanel();
            cpDown.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            cpDown.Location = new Point(this.Width +10-60-155, 10);
            cpDown.Size = new Size(63, 32);
            cpDown.CaptionTitle = "下一页";
            cpDown.IsOnlyCaption = true;
            cpDown.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;
           // cpDown.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption;--zdc
            cpDown.Click += new EventHandler(cpDown_Click);
            cpStationConfig.Controls.Add(cpDown);

            txtPage = new CaptionPanel();
            txtPage.CaptionTitleLeft = 0;
            txtPage.Location = new Point(this.Width + 80-60-155, 10);
            txtPage.Size = new Size(30, 32);
            cpStationConfig.Controls.Add(txtPage);

            lblSumPage = new CaptionPanel();
            lblSumPage.CaptionTitleLeft = 0;
            lblSumPage.Location = new Point(this.Width + 114-60-155, 10);
            lblSumPage.Size = new Size(40, 32);
            cpStationConfig.Controls.Add(lblSumPage);

            txtCheckPage = new KJ128N.Command.TxtNumber();
            txtCheckPage.Location = new Point(this.Width + 149-50-155, 10);
            txtCheckPage.Size = new Size(35, 22);
            txtCheckPage.Text = "1";
            cpStationConfig.Controls.Add(txtCheckPage);

            cpCheckPage = new ButtonCaptionPanel();
            cpCheckPage.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            cpCheckPage.Location = new Point(this.Width + 182-40-155, 10);
            cpCheckPage.Size = new Size(63, 32);
            cpCheckPage.CaptionTitle = "跳  至";
            cpCheckPage.IsOnlyCaption = true;
            cpCheckPage.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;
            //chCheckPage.
            //cpCheckPage.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption; --zdc
            cpCheckPage.Click += new EventHandler(cpCheckPage_Click);
            cpStationConfig.Controls.Add(cpCheckPage);
            this.Controls.Add(cpStationConfig);
            
            //每页显示行数
            cpCount = new ButtonCaptionPanel();
            cpCount.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            cpCount.Location = new Point(350, 5);
            cpCount.Size = new Size(106, 22);
            cpCount.CaptionTitle = "每页显示条数：";
            cpCount.IsOnlyCaption = true;
            cpCount.SetButtonStyle = ButtonCaptionPanelButtonStyle.None;

            cpStationConfig.Controls.Add(cpCount);
            this.Controls.Add(cpStationConfig);

            //选中每页行数
            cbpageSize = new ComboBox();
            cbpageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbpageSize.Size = new System.Drawing.Size(44, 20);
            cbpageSize.Location = new Point(350 + cpCount.Width + 10, 5);
            cbpageSize.Items.AddRange(new object[] {"20","40","50","100","200"});
            cbpageSize.SelectedIndex = 0;
            cbpageSize.DropDownClosed += new EventHandler(cbpageSize_DropDownClosed);
            cpStationConfig.Controls.Add(cbpageSize);
            //panel1.Dock = DockStyle.Top;
            //cpStationConfig.Dock = DockStyle.Top;
            this.panel3.Controls.Add(cpStationConfig);
            cpStationConfig.Dock = DockStyle.Fill;

            vspStationConfigInfo.Location = new Point(5, cpStationConfig.Top + cpStationConfig.Height);
            vspStationConfigInfo.Size = new Size(780, 480);
            vspStationConfigInfo.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top) | (AnchorStyles.Right) | (AnchorStyles.Bottom));
            vspStationConfigInfo.LayoutType = VSPanelLayoutType.VerticalType;
            vspStationConfigInfo.IsBorderLine = true;
            vspStationConfigInfo.AutoScroll = true;
            //vspStationConfigInfo.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(vspStationConfigInfo);
            vspStationConfigInfo.Dock = DockStyle.Fill;
        }

        #endregion

        #region 翻页事件

        // 初始化分站和接收器信息

        public void InitData()
        {
            DataSet ds = sbll.getStationHeadInfo(0, pageSize);
            AddSingleStationInfo(1, false);
            txtPage.CaptionTitle = "1";
        }

        #region 翻页控件是否显示

        // 翻页控件是否显示
        private void checkPageControls(bool bl)
        {
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
            sumCount.Visible = bl;
        }

        #endregion

        // 跳至
        void cpCheckPage_Click(object sender, EventArgs e)
        {
            if(txtCheckPage.Text == string.Empty) return;
            string value = txtCheckPage.Text;
            int page = int.Parse(value);
            AddSingleStationInfo(page, true);                   // 加载分站
        }

        // 下一页

        void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            AddSingleStationInfo(page, false);                   // 加载分站

        }

        // 上一页

        void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            AddSingleStationInfo(page, false);                   // 加载分站
        }
        #endregion

        /// 增加单个分站信息
        private void AddSingleStationInfo(int pIndex,bool isCheckPage)
        {
            if (pIndex <= 0)
            {
                AddSingleStationInfo(1,false);
                return;
            }

            DataSet ds = sbll.getStationHeadInfo(pIndex - 1, pageSize);
            
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[2].Rows[0][0].ToString());
                sumPage = sumPage % pageSize != 0 ? sumPage / pageSize + 1 : sumPage / pageSize;
                
                if (!cpUp.Enabled)
                {
                    cpUp.Enabled = true;
                }
                if (!cpDown.Enabled)
                {
                    cpDown.Enabled = true;
                }

                if (pIndex == 1)
                {
                    // 只有一页时
                    if (sumPage <= 1)
                    {
                        checkPageControls(false);
                    }
                    else
                    {
                        checkPageControls(true);
                        cpUp.Enabled = false;
                    }
                }
                else if (pIndex == sumPage)
                {
                    cpDown.Enabled = false;
                    // 最后一页

                }
                else if (pIndex > sumPage)
                {
                    // 大于最后一页
                    AddSingleStationInfo(sumPage, false);
                    return;
                }
                vspStationConfigInfo.Hide();

                vspStationConfigInfo.Controls.Clear();          //清空数据

                sumCount.CaptionTitle = "共" + ds.Tables[2].Rows[0][0].ToString() + "条/本页" + ds.Tables[0].Rows.Count.ToString() + "条";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string az = "安装位置" + dr["StationPlace"].ToString();
                    string sa = dr["StationAddress"].ToString();

                    StationMakeupVspanel smvpSingleStation = new StationMakeupVspanel();
                    smvpSingleStation.LayoutType = VSPanelLayoutType.VerticalType;
                    smvpSingleStation.Width = vspStationConfigInfo.Width;
                    smvpSingleStation.StationAddress = int.Parse(sa);
                    smvpSingleStation.ClickEditStationButton += new EventHandler(smvpSingleStation_ClickEditStationButton);
                    smvpSingleStation.ClickDeleteStationButton += new EventHandler(smvpSingleStation_ClickDeleteStationButton);
                    smvpSingleStation.ClickAddStationHead += new EventHandler(smvpSingleStation_ClickAddStationHead);
                    smvpSingleStation.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Right) | (AnchorStyles.Top));
                    smvpSingleStation.CaptionTitle = string.Format("{0}号"+KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station), sa);
                    smvpSingleStation.LabelStationInfoLeft = 300;
                    smvpSingleStation.LabelStationInfoText = az;
                    smvpSingleStation.LabelStatonInfoWidth = 200;
                    smvpSingleStation.ShiftButtonMouseClick += new EventHandler(smvpSingleStation_ShiftButtonMouseClick);
                    vspStationConfigInfo.Controls.Add(smvpSingleStation);

                    DataRow[] drArray = ds.Tables[1].Select("StationAddress =" + sa);
                    if (drArray.Length > 0)
                    {
                        foreach (DataRow drStationHead in drArray)
                        {
                            addPanelStationHeadInfo(smvpSingleStation, drStationHead);
                        }
                    }
                }
                //cmsStationHand.Items[0].Click += new EventHandler(FrmStationManage_Click);
                //cmsStationHand.Items[1].Click += new EventHandler(tsMenuDelete_Click);
            }
            else
            {
                checkPageControls(false);
            }
                if (vspStationConfigInfo != null)
                    vspStationConfigInfo.Show();
        }

        /// 添加接收器
        private void addPanelStationHeadInfo(StationMakeupVspanel smv,DataRow drStationHead)
        {            
            shAddStationTitle.CaptionTitle = "添加" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead) + "信息";
            PanelStationHeadInfo pshi_one = new PanelStationHeadInfo();

            pshi_one.MouseHover += pshi_one_MouseHover;

            pshi_one.ValueEnterTotalPerson.FieldName = "";
            
            pshi_one.Height = 84;
            pshi_one.Width = 120;
            pshi_one.SetBackGroundGradineMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            pshi_one.ContextMenuStrip = cmsStationHand;
            pshi_one.MouseDown += new MouseEventHandler(pshi_one_MouseDown);
            pshi_one.Click += new EventHandler(pshi_one_Click);
            
            //tag保存接收器唯一表示列

            pshi_one.Tag = drStationHead["StationHeadID"].ToString();
            LabelInfo stationHeadAddress = pshi_one.ValueStationHeadAddress;
            // 赋值接收器地址号

            stationHeadAddress.FieldName = drStationHead["StationHeadAddress"].ToString();
            pshi_one.ValueStationHeadAddress = stationHeadAddress;

            //赋值接收器安装位置
            LabelInfo l = new LabelInfo("进入总人数", new PointF(4, 60));
            l.FieldName = "安装位置:" + drStationHead["StationHeadPlace"].ToString();
            pshi_one.ValueStationHeadPlace = l;
            smv.Controls.Add(pshi_one);
            //vspAddNewStation.Visible = false;

        }

        void pshi_one_MouseHover(object sender, EventArgs e)
        {
            PanelStationHeadInfo pshi = ((PanelStationHeadInfo)sender);
            toolTip.SetToolTip((Control)sender, pshi.ValueStationHeadPlace.FieldName + pshi.ValueAntennaA.FieldName);
            toolTip.Active = true;
        }

        #region 菜单操作事件

        // 右键单击接收器信息
        void pshi_one_MouseDown(object sender, MouseEventArgs e)
        {
            //接收器右键菜单操作

            if (e.Button == MouseButtons.Right)
            {
                tempSingleStation = ((StationMakeupVspanel)((PanelStationHeadInfo)sender).Parent);
                cmsStationHand.Tag = ((PanelStationHeadInfo)sender).Tag;
                cmsStationHand.Items["tsMenuDelete"].Tag = ((PanelStationHeadInfo)sender).ValueStationHeadAddress.ToString();
                //vspAddNewStation.Visible = false;
            }
        }


        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmsStationHand.Hide();
        }

        #endregion

        #region 事件处理 新增分站面板内　各控件的事件处理

        /// <summary>
        /// 单击缩放图标时，引发重排
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void smvpSingleStation_ShiftButtonMouseClick(object sender, EventArgs e)
        {

            StationMakeupVspanel smv = (StationMakeupVspanel)((StationCaptionPanel)((Label)sender).Parent).Parent;
            if (smv.Controls.Count == 1)
            {
                smv.IsShrink=true;
            }
            vspStationConfigInfo.RainRangeControl();
        }
        
        private void ClearTextBox()
        {
            
        }

        #endregion

        #region 选择每页显示行数
        void cbpageSize_DropDownClosed(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cbpageSize.SelectedItem);
            AddSingleStationInfo(1, false);
        }
        #endregion

        #region [热备定时刷新]


        private string sa;

        private string sha;

        /// <summary>
        /// 最大刷新次数
        /// </summary>
        private int maxTimes = 2;

        /// <summary>
        /// 查询刷新次数
        /// </summary>
        private int times = 0;

        /// <summary>
        /// 1表示 增加，修改 2 表示删除,3表示修改
        /// </summary>
        private int operated = 1;

        /// <summary>
        /// 1表示分站，2表示接收器
        /// </summary>
        private int model = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (model == 1)
            {
                #region [分站]

                if (times < maxTimes)
                {
                    //刷新
                    // 重新加载
                    if (operated == 2)
                    {
                        int page = int.Parse(txtPage.CaptionTitle);
                        AddSingleStationInfo(page, false);
                        //InitData();
                    }
                    else
                    {
                        InitData();
                    }

                    times++;

                    timer1.Stop();
                    timer1.Start();
                }
                else
                {
                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }

                #endregion
            }
            else
            {
                #region[接收器]

                //刷新

                if (times < maxTimes)
                {
                    // 清空接收器panel
                    if (tempSingleStation != null)
                    {
                        for (int i = tempSingleStation.Controls.Count - 1; i >= 0; i--)
                        {
                            if (tempSingleStation.Controls[i].GetType().ToString() == "KJ128WindowsLibrary.PanelStationHeadInfo")
                            {
                                tempSingleStation.Controls.RemoveAt(i);
                            }
                        }
                    }
                    // 重新加载
                    DataTable dsStationHead = sbll.getStationHeadInfoAll(tempSingleStation.StationAddress);
                    if (dsStationHead != null)
                    {
                        if (dsStationHead.Rows.Count > 0)
                        {
                            foreach (DataRow drStationHead in dsStationHead.Rows)
                            {
                                addPanelStationHeadInfo(tempSingleStation, drStationHead);
                            }
                        }
                    }


                    times++;
                    timer1_Tick(sender, e);
                }
                else
                {
                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }

                #endregion
            }
        }

        #endregion       


        #region 【删除分站——刷新】

        private void timer2_Tick(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            AddSingleStationInfo(page, false);
            timer2.Stop();
        }

        #endregion

        #region【方法：清空 分站信息】

        /// <summary>
        /// 清空 分站信息
        /// </summary>
        private void ClearStation()
        {
            txt_StationAddress.Text = "";
            txt_StationPlace.Text = "";
            txt_StationTel.Text = "";
            rb_A.Checked = true;
            cmb_StationPacket.SelectedIndex = 0;
        }
        #endregion

        #region【事件：添加分站信息】

        private void bcpAddNewStation_Click(object sender, EventArgs e)
        {
            //tempSingleStation = (StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent;
            //tempSingleStation = (StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent;

            //cmsStationHand1 = tempSingleStation.StationAddress;
            ////A_Station_Add frm = new A_Station_Add();
            ////DialogResult dr = frm.ShowDialog();
            ////if (dr == DialogResult.OK)
            ////{
            ////    if (!New_DBAcess.IsDouble)
            ////    {
            ////        InitData();             // 重新加载
            ////    }
            ////    else
            ////    {
            ////        timer1.Start();
            ////    }
            ////}
            //pl_AddStationInfo.Visible = true;
            //pl_AddStationInfo.BringToFront();
            //ClearStation();     //清空数据
            //txt_StationAddress.Enabled = true;
            //bt_Station_Reset.Enabled = true;
            //bcp_StationTitle.CaptionTitle = "新增传输分站";
            //lb_StationTipsInfo.Visible = label110.Visible = false;

            intStationAddress = -1;

            A_Station_Add fr = new A_Station_Add(this);
            fr.ShowDialog();
        }

        #endregion

        #region【事件：保存——分站】

        private void bt_Station_Save_Click(object sender, EventArgs e)
        {
            lb_StationTipsInfo.Visible = label110.Visible = true;
            if (txt_StationAddress.Text.Trim().Equals(""))
            {
                lb_StationTipsInfo.Text = "分站号不能为空";
                lb_StationTipsInfo.ForeColor = Color.Red;
                return;
            }
            else
            {
                //Czlt-2011-01-25注销
                //if (Convert.ToInt32(txt_StationAddress.Text.Trim()) > 64)
                //{
                //    lb_StationTipsInfo.Text = "分站号不能大于64";
                //    lb_StationTipsInfo.ForeColor = Color.Red;
                //    return;
                //}
            }
            //if (txt_StationPlace.Text.Trim().Equals(""))
            //{
            //    lb_StationTipsInfo.Text = "分站安装位置不能为空！";
            //    lb_StationTipsInfo.ForeColor = Color.Red;
            //    return;
            //}

            //判断系统中该安装位置是否存在

            int intImpactCounts = 0;
            int intStationModel=1;
            if(rb_V2.Checked)
            {
                intStationModel=2;
            }
            if (bcp_StationTitle.CaptionTitle.Equals("新增传输分站"))       //新增
            {
                //判断系统中是否已经有该探头
                if (sbll.existsStationAddress(int.Parse(txt_StationAddress.Text)) > 0)
                {
                    lb_StationTipsInfo.Text = txt_StationAddress.Text+" 号传输分站已经存在！";
                    lb_StationTipsInfo.ForeColor = Color.Red;
                    return;
                }

                intImpactCounts = sbll.SaveStationInfo(Convert.ToInt32(txt_StationAddress.Text), txt_StationPlace.Text, txt_StationTel.Text,
                    2000, "通用接收器",int.Parse(cmb_StationPacket.Text.ToString()),intStationModel);
                if (intImpactCounts > 0)
                {
                    lb_StationTipsInfo.Text = "保存成功！";
                    lb_StationTipsInfo.ForeColor = Color.Black;

                    //存入日志
                    LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "添加新分站，分站编号：" + txt_StationAddress.Text + "，安装位置：" + txt_StationPlace.Text);

                    if (!New_DBAcess.IsDouble)
                    {
                        InitData();             // 重新加载
                    }
                    else
                    {
                        timer1.Start();
                    }

                }
                else
                {
                    lb_StationTipsInfo.Text = "保存失败！";
                    lb_StationTipsInfo.ForeColor = Color.Red;
                }
            }
            else                                                           //修改
            {
                intImpactCounts = sbll.UpdateStationInfo(Convert.ToInt32(txt_StationAddress.Text), txt_StationPlace.Text, txt_StationTel.Text,
                    2000, "通用接收器", int.Parse(cmb_StationPacket.Text.ToString()), intStationModel);
                if (intImpactCounts > 0)
                {
                    lb_StationTipsInfo.Text = "修改成功！";
                    lb_StationTipsInfo.ForeColor = Color.Black;

                    //存入日志
                    LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "修改分站，分站编号：" + txt_StationAddress.Text + "，安装位置：" + txt_StationPlace.Text);

                    if (!New_DBAcess.IsDouble)
                    {
                        InitData();             // 重新加载
                    }
                    else
                    {
                        timer1.Start();
                    }

                }
                else
                {
                    lb_StationTipsInfo.Text = "修改失败！";
                    lb_StationTipsInfo.ForeColor = Color.Red;
                }

            }
        }

        #endregion

        #region【事件：重置——分站】

        private void bt_Station_Reset_Click(object sender, EventArgs e)
        {
            ClearStation();
        }

        #endregion

        #region【事件：关闭——分站】

        private void bt_Station_Close_Click(object sender, EventArgs e)
        {
            pl_AddStationInfo.Visible = false;
        }

        #endregion

        #region【事件：拖动——分站】

        private void bcp_StationTitle_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            Panel p = (Panel)((ButtonCaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void bcp_StationTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                Panel p = (Panel)((ButtonCaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void bcp_StationTitle_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        #endregion

        #region【事件：修改——分站】

        private void smvpSingleStation_ClickEditStationButton(object sender, EventArgs e)
        {
            //修改分站信息

            //tempSingleStation = (StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent;
            //DataRow dr = sbll.getStationInfo(int.Parse(((StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent).StationAddress.ToString()));

            cmsStationHand1 = int.Parse(((StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent).StationAddress.ToString());
            intStationAddress = cmsStationHand1;

            A_Station_Add fr = new A_Station_Add(this);
            fr.ShowDialog();

        }

        #endregion

        #region【事件：删除——分站】

        private void smvpSingleStation_ClickDeleteStationButton(object sender, EventArgs e)
        {
            //删除分站信息

            StationMakeupVspanel stationAddress = ((StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent);

            if (MessageBox.Show("您确定删除[" + stationAddress.StationAddress.ToString() + "]号" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station), "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                model = 1;
                operated = 2;

                if (sbll.deleteStation(stationAddress.StationAddress) == 1)
                {
                    this.IsSave = true;
                    if (!New_DBAcess.IsDouble)
                    {
                        // 重新加载
                        int page = int.Parse(txtPage.CaptionTitle);
                        AddSingleStationInfo(page, false);
                    }
                    else
                    {
                        buttonCaptionPanel1_Click(this, new EventArgs());
                    }

                    //Czlt-2011-12-10 删除的时候更新配置信息
                    sbll.UpdateTime();
                    //存入日志
                    LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "删除传输分站，传输分站编号：" + stationAddress.StationAddress);
                }
            }
        }

        #endregion


        #region【方法：清空 探头信息】

        /// <summary>
        /// 清空 探头信息
        /// </summary>
        private void ClearStaHead()
        {
            txt_StaHeadPlace.Text = "";
            txt_StaHeadAntennaA.Text = "";
            txt_StaHeadAntennaB.Text = "";
            rb_WellUp.Checked=true;
            txt_StaHeadTel.Text = "";
            txt_StaHeadRemark.Text = "";
        }
        #endregion

        #region【方法：根据分站协议，判断探头号】

        /// <summary>
        /// 判断分站的通讯协议是否是A版
        /// </summary>
        /// <param name="intStationAddress">传输分站的编号</param>
        /// <returns>true:A版；false:V2版</returns>
        private bool GetStationModel(int intStationAddress)
        {
            using (dsTemp = new DataSet())
            {
                dsTemp = sbll.GetStationModel(intStationAddress);
                if (dsTemp != null && dsTemp.Tables.Count > 0)
                {
                    if (dsTemp.Tables[0].Rows.Count > 0)
                    {
                        if (dsTemp.Tables[0].Rows[0][0].ToString().Equals("2"))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        #endregion

        #region【事件：添加——接收器】

        private void smvpSingleStation_ClickAddStationHead(object sender, EventArgs e)
        {
            tempSingleStation = (StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent;
            
            cmsStationHand1 = tempSingleStation.StationAddress;
            cmsStationHand2 = tempSingleStation.StationAddress.ToString();

            intStationAddressJudgment = tempSingleStation.StationAddress;
            intStationHeadID = -1;

            A_Station_Head_Add frm = new A_Station_Head_Add(this);
            frm.ShowDialog();

            //DialogResult dr = frm.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    #region【刷新】

            //    if (!New_DBAcess.IsDouble)
            //    {
            //        //清空添加面板
            //        ClearStaHead();

            //        // 清空接收器panel
            //        if (tempSingleStation != null)
            //        {
            //            for (int i = tempSingleStation.Controls.Count - 1; i >= 0; i--)
            //            {
            //                if (tempSingleStation.Controls[i].GetType().ToString() == "KJ128WindowsLibrary.PanelStationHeadInfo")
            //                {
            //                    tempSingleStation.Controls.RemoveAt(i);
            //                }
            //            }

            //            // 重新加载
            //            DataTable dsStationHead = sbll.getStationHeadInfoAll(int.Parse(tempSingleStation.StationAddress.ToString()));
            //            if (dsStationHead != null)
            //            {
            //                if (dsStationHead.Rows.Count > 0)
            //                {
            //                    foreach (DataRow drStationHead in dsStationHead.Rows)
            //                    {
            //                        addPanelStationHeadInfo(tempSingleStation, drStationHead);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        timer1.Start();
            //    }
            //    #endregion
            //}
            //    //添加——接收器信息
            //pl_AddStaHeadInfo.Visible = true;
            //pl_AddStaHeadInfo.BringToFront();

            ////清空
            //ClearStaHead();

            ////tempSingleStation = (StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent;
            ////判断是A版，还是V2版
            //if (GetStationModel(tempSingleStation.StationAddress))     //A版
            //{
            //    txt_StaHeadAddress.Text = "";
            //    txt_StaHeadAddress.Enabled = true;
            //}
            //else                                                        //V2版
            //{
            //    txt_StaHeadAddress.Text = "1";
            //    txt_StaHeadAddress.Enabled = false;
            //}
            //txt_StaHead_StaAddress.Text = tempSingleStation.StationAddress.ToString();

            //bcp_StaHeadTitle.CaptionTitle = "新增读卡分站";


            //bt_StaHead_Reset.Enabled = true;
            //bt_StaHead_Save.Enabled = gb_AddStaHeadInfo.Enabled = true;
            //lb_StaHeadTipsInfo.Visible = lb_StaHeadTipsInfo2.Visible = false;
        }

        #endregion

        #region【事件：保存——接收器】

        private void bt_StaHead_Save_Click(object sender, EventArgs e)
        {
            lb_StaHeadTipsInfo.Visible = lb_StaHeadTipsInfo2.Visible = true;
           
            if (txt_StaHeadAddress.Text.Trim().Equals(""))
            {
                lb_StaHeadTipsInfo.Text = "读卡分站号不能为空！";
                lb_StaHeadTipsInfo.ForeColor = Color.Red;
                return;
            }
            else
            {
                if (Convert.ToInt32(txt_StaHeadAddress.Text.Trim()) > 6)
                {
                    lb_StaHeadTipsInfo.Text = "读卡分站号不能大于6！";
                    lb_StaHeadTipsInfo.ForeColor = Color.Red;
                    return;
                }
            }
            if (txt_StaHeadPlace.Text.Equals(""))
            {
                lb_StaHeadTipsInfo.Text = "请输入读卡分站的安装位置！";
                lb_StaHeadTipsInfo.ForeColor = Color.Red;
                return;
            }

            ////判断读卡分站的安装位置是否存在
            //if (sbll.ExistsStationHeadPlace(txt_StaHeadPlace.Text) > 0)
            //{
            //    lb_StaHeadTipsInfo.Text = "该读卡分站的安装位置已经存在，请重新输入！";
            //    lb_StaHeadTipsInfo.ForeColor = Color.Red;
                
            //    return;
            //}

            int intImpactCounts = 0;
            int intTypeID;
            string strType ;
            if (rb_WellHead.Checked)        //上井口接收器
            {
                intTypeID = 8;
                strType = "上井口接收器";
            }
            else                            //井下接收器
            {
                intTypeID = 32;
                strType = "井下接收器";
            }
            if (bcp_StaHeadTitle.CaptionTitle.Equals("新增读卡分站"))       //新增
            {
                //判断系统中是否已经有该探头
                if (sbll.existsStationHeadAddress(int.Parse(txt_StaHeadAddress.Text), int.Parse(txt_StaHead_StaAddress.Text)) > 0)
                {
                    lb_StaHeadTipsInfo.Text = txt_StaHead_StaAddress.Text + " 号传输分站下已存在 " + txt_StaHeadAddress.Text + " 号读卡分站！";
                    lb_StaHeadTipsInfo.ForeColor = Color.Red;
                    return;
                }

                intImpactCounts = sbll.insertStationHead(Convert.ToInt32(txt_StaHead_StaAddress.Text), Convert.ToInt32(txt_StaHeadAddress.Text.Trim()),
                    txt_StaHeadPlace.Text, txt_StaHeadTel.Text, intTypeID, strType, txt_StaHeadAntennaA.Text, txt_StaHeadAntennaB.Text,
                    txt_StaHeadRemark.Text,"1");
                if (intImpactCounts > 0)
                {
                    lb_StaHeadTipsInfo.Text = "保存成功！";
                    lb_StaHeadTipsInfo.ForeColor = Color.Black;

                    //存入日志
                    LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "添加新读卡分站，传输分站编号：" + txt_StaHead_StaAddress.Text + "，读卡分站编号："+txt_StaHeadAddress.Text+"，读卡分站安装位置：" + txt_StaHeadPlace.Text);

                    #region【刷新】

                    if (!New_DBAcess.IsDouble)
                    {
                        //清空添加面板
                        ClearStaHead();

                          // 清空接收器panel
                        if (tempSingleStation != null)
                        {
                            for (int i = tempSingleStation.Controls.Count - 1; i >= 0; i--)
                            {
                                if (tempSingleStation.Controls[i].GetType().ToString() == "KJ128WindowsLibrary.PanelStationHeadInfo")
                                {
                                    tempSingleStation.Controls.RemoveAt(i);
                                }
                            }

                            // 重新加载
                            DataTable dsStationHead = sbll.getStationHeadInfoAll(int.Parse(tempSingleStation.StationAddress.ToString()));
                            if (dsStationHead != null)
                            {
                                if (dsStationHead.Rows.Count > 0)
                                {
                                    foreach (DataRow drStationHead in dsStationHead.Rows)
                                    {
                                        addPanelStationHeadInfo(tempSingleStation, drStationHead);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        timer1.Start();
                    }
                    #endregion
                }
                else
                {
                    lb_StaHeadTipsInfo.Text = "保存失败！";
                    lb_StaHeadTipsInfo.ForeColor = Color.Red;
                }
            }
            else                                                             //修改
            {
                intImpactCounts = sbll.updateStationHead(txt_StaHead_StaAddress.Text,txt_StaHeadAddress.Text.Trim(), txt_StaHeadPlace.Text, txt_StaHeadTel.Text, intTypeID, strType, txt_StaHeadAntennaA.Text, txt_StaHeadAntennaB.Text, txt_StaHeadRemark.Text);
                if (intImpactCounts > 0)
                {
                    lb_StaHeadTipsInfo.Text = "修改成功！";
                    lb_StaHeadTipsInfo.ForeColor = Color.Black;

                    //存入日志
                    LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "修改读卡分站，传输分站编号：" + txt_StaHead_StaAddress.Text + "，读卡分站编号：" + txt_StaHeadAddress.Text + "，读卡分站安装位置：" + txt_StaHeadPlace.Text);

                    #region【刷新】

                    if (!New_DBAcess.IsDouble)
                    {
                        //清空添加面板
                        ClearStaHead();

                        // 清空接收器panel
                        if (tempSingleStation != null)
                        {
                            for (int i = tempSingleStation.Controls.Count - 1; i >= 0; i--)
                            {
                                if (tempSingleStation.Controls[i].GetType().ToString() == "KJ128WindowsLibrary.PanelStationHeadInfo")
                                {
                                    tempSingleStation.Controls.RemoveAt(i);
                                }
                            }

                            // 重新加载
                            DataTable dsStationHead = sbll.getStationHeadInfoAll(int.Parse(tempSingleStation.StationAddress.ToString()));
                            if (dsStationHead != null)
                            {
                                if (dsStationHead.Rows.Count > 0)
                                {
                                    foreach (DataRow drStationHead in dsStationHead.Rows)
                                    {
                                        addPanelStationHeadInfo(tempSingleStation, drStationHead);
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        timer1.Start();
                    }
                    #endregion
                }
                else
                {
                    lb_StaHeadTipsInfo.Text = "修改失败！";
                    lb_StaHeadTipsInfo.ForeColor = Color.Red;

                }
                
            }
        }

        #endregion

        #region【事件：重置——接收器】

        private void bt_StaHead_Reset_Click(object sender, EventArgs e)
        {
            ClearStaHead();
            if (txt_StaHeadAddress.Enabled)
            {
                txt_StaHeadAddress.Text = "";
            }
        }

        #endregion

        #region【事件：关闭——接收器】

        private void bt_StaHead_Close_Click(object sender, EventArgs e)
        {
            pl_AddStaHeadInfo.Visible = false;
        }

        #endregion

        #region【事件：拖动——接收器】

        private void bcp_StaHeadTitle_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            Panel p = (Panel)((ButtonCaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void bcp_StaHeadTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                Panel p = (Panel)((ButtonCaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void bcp_StaHeadTitle_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        #endregion

        #region【事件：单击右键菜单->修改——接收器】

        private void FrmStationManage_Click(object sender, EventArgs e)
        {
            //单击右键菜单->修改 ——接收器信息
            //pl_AddStaHeadInfo.Visible = true;
            //pl_AddStaHeadInfo.BringToFront();

            //bcp_StaHeadTitle.CaptionTitle = "修改读卡分站";
            cmsStationHand1 = int.Parse(cmsStationHand.Tag.ToString());

            intStationHeadID = cmsStationHand1;
            blIsUpDate = true;

            A_Station_Head_Add fr = new A_Station_Head_Add(this);

            fr.ShowDialog();

            //DialogResult dr = fr.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    #region【刷新】

            //    if (!New_DBAcess.IsDouble)
            //    {
            //        //清空添加面板
            //        ClearStaHead();

            //        // 清空接收器panel
            //        if (tempSingleStation != null)
            //        {
            //            for (int i = tempSingleStation.Controls.Count - 1; i >= 0; i--)
            //            {
            //                if (tempSingleStation.Controls[i].GetType().ToString() == "KJ128WindowsLibrary.PanelStationHeadInfo")
            //                {
            //                    tempSingleStation.Controls.RemoveAt(i);
            //                }
            //            }

            //            // 重新加载
            //            DataTable dsStationHead = sbll.getStationHeadInfoAll(int.Parse(tempSingleStation.StationAddress.ToString()));
            //            if (dsStationHead != null)
            //            {
            //                if (dsStationHead.Rows.Count > 0)
            //                {
            //                    foreach (DataRow drStationHead in dsStationHead.Rows)
            //                    {
            //                        addPanelStationHeadInfo(tempSingleStation, drStationHead);
            //                    }
            //                }
            //            }

            //        }
            //    }
            //    else
            //    {
            //        timer1.Start();
            //    }
            //    #endregion
            //}
            //DataRow dr = sbll.getStationHeadRowInfo(int.Parse(cmsStationHand.Tag.ToString()));

            //txt_StaHead_StaAddress.Text = dr["StationAddress"].ToString();
            //txt_StaHeadAddress.Text = dr["StationHeadAddress"].ToString();

            //txt_StaHeadAddress.Enabled = false;
            //txt_StaHeadPlace.Text = dr["StationHeadPlace"].ToString();
            //txt_StaHeadTel.Text = dr["StationHeadTel"].ToString();
            //txt_StaHeadAntennaA.Text = dr["AntennaA"].ToString();
            //txt_StaHeadAntennaB.Text = dr["AntennaB"].ToString();
            //if (dr["StationHeadTypeID"].ToString().Equals("8"))
            //{
            //    rb_WellHead.Checked = true;
            //}
            //else
            //{
            //    rb_WellUp.Checked = true;
            //}
            //txt_StaHeadRemark.Text = dr["Remark"].ToString();

            //bt_StaHead_Reset.Enabled = false;
            //bt_StaHead_Save.Enabled = gb_AddStaHeadInfo.Enabled = true;
            //lb_StaHeadTipsInfo.Visible = lb_StaHeadTipsInfo2.Visible = false;
        }

        #endregion

        #region【事件：查看——接收器】

        private void pshi_one_Click(object sender, EventArgs e)
        {

            intStationHeadID = int.Parse(((PanelStationHeadInfo)sender).Tag.ToString());
            blIsUpDate = false;

            A_Station_Head_Add fr = new A_Station_Head_Add(this);

            fr.ShowDialog();

            //pl_AddStaHeadInfo.Visible = true;
            //pl_AddStaHeadInfo.BringToFront();

            //bcp_StaHeadTitle.CaptionTitle = "查看读卡分站";

            //DataRow dr = sbll.getStationHeadRowInfo(int.Parse(((PanelStationHeadInfo)sender).Tag.ToString()));

            //txt_StaHead_StaAddress.Text = dr["StationAddress"].ToString();
            //txt_StaHeadAddress.Text = dr["StationHeadAddress"].ToString();

            //txt_StaHeadAddress.Enabled = false;
            //txt_StaHeadPlace.Text = dr["StationHeadPlace"].ToString();
            //txt_StaHeadTel.Text = dr["StationHeadTel"].ToString();
            //txt_StaHeadAntennaA.Text = dr["AntennaA"].ToString();
            //txt_StaHeadAntennaB.Text = dr["AntennaB"].ToString();
            //if (dr["StationHeadTypeID"].ToString().Equals("8"))
            //{
            //    rb_WellHead.Checked = true;
            //}
            //else
            //{
            //    rb_WellUp.Checked = true;
            //}
            //txt_StaHeadRemark.Text = dr["Remark"].ToString();

            //bt_StaHead_Reset.Enabled = false;
            //bt_StaHead_Save.Enabled = gb_AddStaHeadInfo.Enabled = false;
            //lb_StaHeadTipsInfo.Visible = lb_StaHeadTipsInfo2.Visible = false;
            
        }

        #endregion

        #region【事件：单击右键菜单->删除——接收器】

        private void tsMenuDelete_Click(object sender, EventArgs e)
        {
            DialogResult diar=MessageBox.Show("您确定删除" + tempSingleStation.StationAddress.ToString() + "号" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station) + "的[" + cmsStationHand.Items["tsMenuDelete"].Tag.ToString() + "]号" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead), "提示", MessageBoxButtons.YesNo);
            if ( diar== DialogResult.Yes)
            {
                model = 2;

                if (cmsStationHand.Tag != null && !cmsStationHand.Tag.ToString().Equals(""))
                {
                    int id = int.Parse(cmsStationHand.Tag.ToString());
                    if (sbll.deleteStationHead(id) == 1)
                    {
                        if (!New_DBAcess.IsDouble)
                        {

                            // 清空接收器panel
                            if (tempSingleStation != null)
                            {
                                for (int i = tempSingleStation.Controls.Count - 1; i >= 0; i--)
                                {
                                    if (tempSingleStation.Controls[i].GetType().ToString() == "KJ128WindowsLibrary.PanelStationHeadInfo")
                                    {
                                        tempSingleStation.Controls.RemoveAt(i);
                                    }
                                }
                            }
                            // 重新加载
                            DataTable dsStationHead = sbll.getStationHeadInfoAll(tempSingleStation.StationAddress);
                            if (dsStationHead != null)
                            {
                                if (dsStationHead.Rows.Count > 0)
                                {
                                    foreach (DataRow drStationHead in dsStationHead.Rows)
                                    {
                                        addPanelStationHeadInfo(tempSingleStation, drStationHead);
                                    }
                                }
                            }
                        }
                        else
                        {                           
                            buttonCaptionPanel1_Click(this, new EventArgs());
                        }

                        //Czlt-2011-12-10 删除的时候更新配置信息
                        sbll.UpdateTime();

                    }
                }
            }
            else
            {
                return;
            }
        }

        #endregion


        #region【事件：界面刷新】

        private void buttonCaptionPanel1_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            AddSingleStationInfo(page, false);
        }

        #endregion

        #region【方法：热备刷新】

        /// <summary>
        /// 热备刷新
        /// </summary>
        /// <param name="bl">true:开启刷新;false:终止刷新</param>
        public void HostBackRefresh(bool bl)
        {
            if (bl)
            {
                if (timer_Refresh.Enabled)
                {
                    timer_Refresh.Enabled = false;
                }
                intRefReshCount = 0;
                timer_Refresh.Enabled = true;
            }
            else
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
        }

        #endregion

        #region【事件：热备刷新】

        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            if (intRefReshCount >= intHostBackRefCount)
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
            else
            {
                intRefReshCount = intRefReshCount + 1;

                #region【刷新界面】

                switch (intSelectModel)
                {
                    case 1:

                        #region【传输分站】
                        
                        InitData();

                        #endregion

                        break;
                    case 2:

                        #region【读卡分站】

                        RefreshStationHead();

                        #endregion

                        break;
                    default:
                        break;
                }

                #endregion

            }
        }

        #endregion

        #region【方法：刷新读卡分站信息】

        public void RefreshStationHead()
        {
            // 清空接收器panel
            if (tempSingleStation != null)
            {
                for (int i = tempSingleStation.Controls.Count - 1; i >= 0; i--)
                {
                    if (tempSingleStation.Controls[i].GetType().ToString() == "KJ128WindowsLibrary.PanelStationHeadInfo")
                    {
                        tempSingleStation.Controls.RemoveAt(i);
                    }
                }

                // 重新加载
                DataTable dsStationHead = sbll.getStationHeadInfoAll(int.Parse(tempSingleStation.StationAddress.ToString()));
                if (dsStationHead != null)
                {
                    if (dsStationHead.Rows.Count > 0)
                    {
                        foreach (DataRow drStationHead in dsStationHead.Rows)
                        {
                            addPanelStationHeadInfo(tempSingleStation, drStationHead);
                        }
                    }
                }
            }
        }

        #endregion

        private void A_FrmStationInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSave)
            {
                DataTable stationdt = this.GetStationTable();
                if (ReplaceStationXml(stationdt, Application.StartupPath + "\\Station.xml"))
                {
                    this.StationChanged();
                }
            }
            ConfigXmlWiter.Write("StationHead.xml");
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
            return new A_StationBLL().Get_StationInfo(sign);
        }

        /// <summary>
        /// 重写Station.xml文件
        /// </summary>
        /// <returns>true重写成功false重写失败</returns>
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
                    if (commType != 0)
                    {
                        try
                        {
                            XmlNode xmlnodeTcpMark = xmlcomm.SelectSingleNode("/comm/TcpMark");
                            if (xmlnodeTcpMark != null)
                            {
                                tcpMark = int.Parse(xmlnodeTcpMark.InnerText);
                            }
                        }
                        catch { }
                    }
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

                                    marknode.InnerText = tcpMark.ToString();

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


        private bool GetCommType()
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml");
                XmlNode node = xmlDocument.SelectSingleNode("/comm/commType");
                if (node.InnerText != "" && node.InnerText.Equals("1") == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void bcpAddNewStation_Load(object sender, EventArgs e)
        {

        }

        private void txt_StaHeadPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StaHeadAntennaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StaHeadAntennaB_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StaHeadTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StaHeadRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StationPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StationTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
