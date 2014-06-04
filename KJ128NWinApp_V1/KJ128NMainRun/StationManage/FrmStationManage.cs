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

namespace KJ128NInterfaceShow
{
    public partial class FrmStationManage : Wilson.Controls.Docking.DockContent
    {
        private static int pageSize = 20;
        private StationBLL sbll = new StationBLL();
        private EnumBLL ebll = new EnumBLL();
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

        #region 私有变量
        private bool isMove = false;            // (设置面板) 是否移动
        private int mleft = 0;
        private int mtop = 0;
        /// <summary>
        /// 存储分站信息
        /// </summary>
        private DataTable dtStationInfo = new DataTable();

        #region 新增分站面板
        /// <summary>
        /// 新增分站面板
        /// </summary>
        private VSPanel vspAddNewStation = new VSPanel(); //新增分站面板

        #region 新增分站标题子控件

        /// <summary>
        /// 表示分站面板上的标题
        /// </summary>
        private VSPanel vspAddStationCaption = new VSPanel();//表示分站面板上的标题
        /// <summary>
        /// 分站面板的标题

        /// </summary>
        private ButtonCaptionPanel bcpAddStationTitle = new ButtonCaptionPanel();//分站面板的标题

        /// <summary>
        /// 分站面板上的保存并新增按钮

        /// </summary>
        private ButtonCaptionPanel bcpAddStationNewStation = new ButtonCaptionPanel();//分站面板上的保存并新增按钮

        /// <summary>
        /// 关闭面板
        /// </summary>
        private ButtonCaptionPanel bcpAddStationClosePanel = new ButtonCaptionPanel();
        /// <summary>
        /// 是否启用批量添加
        /// </summary>
        private CheckBox chbEnabledBatchAdd = new CheckBox();

        #endregion

        #region 接收器编辑面板

        private VSPanel shStationHeadFrm = new VSPanel();

        private VSPanel shAddStationCaption = new VSPanel();//标题面板

        private ButtonCaptionPanel shAddStationTitle = new ButtonCaptionPanel();//标题

        private ButtonCaptionPanel shAddStationNewStation = new ButtonCaptionPanel();//标题按钮

        private ButtonCaptionPanel shAddStationClosePanel = new ButtonCaptionPanel();//关闭

        #endregion

        #region 批量添加的面板内容

        /// <summary>
        /// 地址标签
        /// </summary>
        private LabelTransparent lblBatchStationAddress = new LabelTransparent();
        /// <summary>
        ///输入最小值

        /// </summary>
        private TxtNumber txtBatchStationAddressMin = new TxtNumber();
        /// <summary>
        /// 输入最大值

        /// </summary>
        private TxtNumber txtBatchStationAddressMax = new TxtNumber();
        /// <summary>
        /// 分隔符 -
        /// </summary>
        private LabelTransparent lblBatchSeparate = new LabelTransparent();

        private Label label1 = new Label();
        private Label label2 = new Label();
        private Label label3 = new Label();
        private Label label4 = new Label();
        private TextBox txtPlace = new Shine.ShineTextBox();                           // 分站安装地点
        private TxtNumber txtTel = new TxtNumber();                             // 电话
        private ComboBox cmbType = new ComboBox();                          // 类型
        private ComboBox cmbGroup = new ComboBox();                         // 分组
        private Label lblInfo = new Label();                                // 提示信息

        private Label label11 = new Label();
        private Label label22 = new Label();
        private Label label33 = new Label();
        private Label label44= new Label();
        private Label label55 = new Label();
        private Label label66 = new Label();
        private Label label77 = new Label();
        private Label label88 = new Label();
        private TextBox shtxta = new Shine.ShineTextBox();                               // 天线a
        private TextBox shtxtb = new Shine.ShineTextBox();                             // 天线b
        private Label lblStationAddress = new Label();                      //接收器所属分站地址号

        private TxtNumber lblStationHeadAddress = new TxtNumber();             // 接收器地址号

        private TextBox shtxtPlace = new Shine.ShineTextBox();                           // 分站安装地点
        private TxtNumber shtxtTel = new TxtNumber();                             // 电话
        private ComboBox shcmbType = new ComboBox();                          // 类型
        private TextBox shRemark = new Shine.ShineTextBox();                         // 分组
        private Label shlblInfo = new Label();                                // 提示信息

        #endregion

        #endregion
       
        private CaptionPanel cpStationConfig = new CaptionPanel();//分站配置外框
        /// <summary>
        /// 分站配置主面板

        /// </summary>
        private VSPanel vspStationConfigInfo=new VSPanel();//分站配置主面板


        #endregion
        
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmStationManage()
        {
            InitializeComponent();
            InitStationHeadFrm();
            InitAddNewStation();
            InitComponent();//初始化窗体布局，组件的放置
            vspAddNewStation.Visible = false;
            
            SetDataTableStationInfo();//给表赋初值

            InitData();                 // 加载分站及接收器信息
            //vspAddNewStation.MouseDown += new MouseEventHandler(cpStationConfig_MouseDown);
            //vspAddNewStation.MouseMove += new MouseEventHandler(cpStationConfig_MouseMove);
            //vspAddNewStation.MouseUp += new MouseEventHandler(cpStationConfig_MouseUp);
            //vspAddNewStation.Click += new EventHandler(bcpAddStationTitle_Click);
            timer1.Stop();
            timer2.Stop();
        }

        #endregion

        #region panel拖动

        //void cpStationConfig_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (isMove)
        //    {
        //        VSPanel p = (VSPanel)(sender);
        //        p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
        //    }
        //}

        //void cpStationConfig_MouseMove(object sender, MouseEventArgs e)
        //{
        //    isMove = true;
        //    VSPanel p = (VSPanel)(sender);
        //    mleft = e.Location.X;
        //    mtop = e.Location.Y;
        //}

        //void cpStationConfig_MouseUp(object sender, MouseEventArgs e)
        //{
        //    isMove = false;
        //}

        #endregion

        #region 方法  添加分站面板需要处理的方法
        
        /// <summary>
        /// 初始增加新的分站的页面布局
        /// </summary>
        private void InitAddNewStation()
        {
            #region 添加分站的主面板
            //vspAddNewStation.Location = new Point(175, 85);
            //vspAddNewStation.Size = new Size(500, 400);
            vspAddNewStation.Location = new Point(250, 150);
            vspAddNewStation.Size = new Size(340, 230);
            vspAddNewStation.IsCaptionSingleColor = false;
            vspAddNewStation.SetBackGroundStyle = VsPaneBackGroundStyle.windowsStyle;
            vspAddNewStation.BackLinearGradientMode = LinearGradientMode.Vertical;
            vspAddNewStation.LayoutType = VSPanelLayoutType.FreeLayoutType;
            this.Controls.Add(vspAddNewStation);
            #endregion

            #region 添加分站的主面板上的标题面板
            vspAddStationCaption.Location = new Point(1, 1);
            vspAddStationCaption.Size = new Size(vspAddNewStation.Width - 2, 30);
            vspAddStationCaption.LayoutType = VSPanelLayoutType.FreeLayoutType;
            vspAddStationCaption.SetBackGroundStyle = VsPaneBackGroundStyle.paleCaption;
            vspAddNewStation.Controls.Add(vspAddStationCaption);
            #endregion

            #region 标题面板内的子控件

            #region 标题
            bcpAddStationTitle.Location = new Point(0,1);
            bcpAddStationTitle.Size = new Size(120,100);
            bcpAddStationTitle.CaptionHeight = 26;
            bcpAddStationTitle.CaptionTitleTop = 7;
            bcpAddStationTitle.SetButtonStyle = ButtonCaptionPanelButtonStyle.None;
            bcpAddStationTitle.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            bcpAddStationTitle.CaptionTitle = "添加"+KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station);
            vspAddStationCaption.Controls.Add(bcpAddStationTitle);
            #endregion
            #region 关闭
            bcpAddStationClosePanel.Location = new Point(vspAddStationCaption.Right - 22, 4);
            bcpAddStationClosePanel.Size = new Size(18, 30);
            bcpAddStationClosePanel.CaptionHeight = 18;
            bcpAddStationClosePanel.CaptionTitleTop = 4;
            bcpAddStationClosePanel.CaptionTitleLeft = 1;
            bcpAddStationClosePanel.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;
            bcpAddStationClosePanel.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            bcpAddStationClosePanel.CaptionTitle = "×";
            bcpAddStationClosePanel.Click += new EventHandler(bcpAddStationClosePanel_Click);
            vspAddStationCaption.Controls.Add(bcpAddStationClosePanel);
            #endregion
            #region 存储并新增

            bcpAddStationNewStation.Location = new Point(bcpAddStationClosePanel.Left-45,4);
            bcpAddStationNewStation.Size = new Size(45,30);
            bcpAddStationNewStation.CaptionHeight = 18;
            bcpAddStationNewStation.CaptionTitleLeft=4;
            bcpAddStationNewStation.CaptionTitleTop = 4;
            bcpAddStationNewStation.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;

            bcpAddStationNewStation.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            bcpAddStationNewStation.CaptionTitle = "存储";
            bcpAddStationNewStation.Click += new EventHandler(bcpAddStationNewStation_Click);
            bcpAddStationNewStation.CausesValidation = true;
            vspAddStationCaption.Controls.Add(bcpAddStationNewStation);

            #endregion

            #region 启用批量添加
            chbEnabledBatchAdd.AutoSize = true;
            chbEnabledBatchAdd.Location = new Point(bcpAddStationNewStation.Left - 95, 8);
            chbEnabledBatchAdd.Text = "启用批量添加";
           
            chbEnabledBatchAdd.ForeColor = bcpAddStationNewStation.CaptionForeColor;
            chbEnabledBatchAdd.CheckedChanged += new EventHandler(chbEnabledBatchAdd_CheckedChanged);
            vspAddStationCaption.Controls.Add(chbEnabledBatchAdd);
            #endregion
            #endregion

            #region 批量添加的子控件

            #region 地址标签
            lblBatchStationAddress.Location = new Point(50,53);
            lblBatchStationAddress.Size = new Size(101,12);
            lblBatchStationAddress.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StationAddress) + ":";
            lblBatchStationAddress.IsTransparent = true;
            vspAddNewStation.Controls.Add(lblBatchStationAddress);

            #endregion
            #region 地址分隔符

            lblBatchSeparate.Location = new Point(204,53);
            lblBatchSeparate.Size = new Size(17,12);
            lblBatchSeparate.Text = "--";
            lblBatchSeparate.IsTransparent = true;
            lblBatchSeparate.Visible = false ;
            vspAddNewStation.Controls.Add(lblBatchSeparate);
            #endregion

            #region 文本输入最小值

            txtBatchStationAddressMin.Location = new Point(166,50);
            txtBatchStationAddressMin.Size = new Size(32,12);
            txtBatchStationAddressMin.MaxLength = 3;
            txtBatchStationAddressMin.Validated += new EventHandler(txtBatchStationAddressMin_Validated);
            vspAddNewStation.Controls.Add(txtBatchStationAddressMin);
            #endregion
            #region 文本输入最大值

            txtBatchStationAddressMax.Location = new Point(227,50);
            txtBatchStationAddressMax.Size = new Size(32,12);
            txtBatchStationAddressMax.MaxLength = 3;
            txtBatchStationAddressMax.Validated += new EventHandler(txtBatchStationAddressMax_Validated);
            txtBatchStationAddressMax.Visible = false;
            vspAddNewStation.Controls.Add(txtBatchStationAddressMax);
            #endregion

            label1.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station) + "安装地点:";
            label2.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station) + "联系电话:";
            label3.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station) + "类型:";
            label4.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station) + "分组号:";

            label1.Location = new Point(50,83);
            label2.Location = new Point(50,113);
            label3.Location = new Point(50,173);
            label4.Location = new Point(50,143);

            txtPlace.Location = new Point(166,83);
            txtTel.Location = new Point(166,113);
            cmbType.Location = new Point(166,173);
            cmbGroup.Location = new Point(166, 143);

            //隐藏基站类型
            cmbType.Visible = false;
            label3.Visible = false;

            txtPlace.MaxLength = 30;
            txtTel.MaxLength = 15;
            vspAddNewStation.Controls.Add(label1);
            vspAddNewStation.Controls.Add(label2);
            vspAddNewStation.Controls.Add(label3);
            vspAddNewStation.Controls.Add(label4);

            vspAddNewStation.Controls.Add(txtPlace);

            txtTel.Validated += new EventHandler(txtTel_Validated);
            vspAddNewStation.Controls.Add(txtTel);

            cmbType.DataSource = sbll.getStationTypeTab();
            cmbType.DisplayMember = "Title";
            cmbType.ValueMember = "EnumID";
            cmbType.SelectedIndex = -1;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            vspAddNewStation.Controls.Add(cmbType);

            for (int i = 1; i < 9; i++)
            {
                cmbGroup.Items.Add(i);
            }
            cmbGroup.SelectedIndex = 0;
            cmbGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            vspAddNewStation.Controls.Add(cmbGroup);

            #region 文本输入最大值

            lblInfo.Location = new Point(50, 200);
            lblInfo.Size = new Size(170, 60);
            lblInfo.AutoSize = true;
            
            vspAddNewStation.Controls.Add(lblInfo);
            #endregion
            #endregion
        }

        #endregion

        #region 接收器编辑面板初始化


        private void InitStationHeadFrm()
        {
            #region 添加分站的主面板
            //shStationHeadFrm.Location = new Point(175, 85);
            shStationHeadFrm.Location = new Point(250, 150);
            //shStationHeadFrm.Size = new Size(500, 400);
            shStationHeadFrm.Size = new Size(340, 320);
            shStationHeadFrm.IsCaptionSingleColor = false;
            shStationHeadFrm.SetBackGroundStyle = VsPaneBackGroundStyle.windowsStyle;
            shStationHeadFrm.BackLinearGradientMode = LinearGradientMode.Vertical;
            shStationHeadFrm.LayoutType = VSPanelLayoutType.FreeLayoutType;
            //shStationHeadFrm.BringToFront();
            this.Controls.Add(shStationHeadFrm);
            #endregion

            #region 添加分站的主面板上的标题面板
            shAddStationCaption.Location = new Point(1, 1);
            shAddStationCaption.Size = new Size(shStationHeadFrm.Width - 2, 30);
            shAddStationCaption.LayoutType = VSPanelLayoutType.FreeLayoutType;
            shAddStationCaption.SetBackGroundStyle = VsPaneBackGroundStyle.paleCaption;
            shStationHeadFrm.Controls.Add(shAddStationCaption);
            #endregion

            #region 标题面板内的子控件

            #region 标题
            shAddStationTitle.Location = new Point(0, 1);
            shAddStationTitle.Size = new Size(120, 100);
            shAddStationTitle.CaptionHeight = 26;
            shAddStationTitle.CaptionTitleTop = 7;
            shAddStationTitle.SetButtonStyle = ButtonCaptionPanelButtonStyle.None;
            shAddStationTitle.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            shAddStationTitle.CaptionTitle = "修改" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead) + "信息";
            shAddStationCaption.Controls.Add(shAddStationTitle);
            #endregion
            #region 关闭
            shAddStationClosePanel.Location = new Point(shAddStationCaption.Right - 22, 4);
            shAddStationClosePanel.Size = new Size(18, 30);
            shAddStationClosePanel.CaptionHeight = 18;
            shAddStationClosePanel.CaptionTitleTop = 4;
            shAddStationClosePanel.CaptionTitleLeft = 1;
            shAddStationClosePanel.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;
            shAddStationClosePanel.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            shAddStationClosePanel.CaptionTitle = "×";
            shAddStationClosePanel.Click += new EventHandler(shAddStationClosePanel_Click);
            shAddStationCaption.Controls.Add(shAddStationClosePanel);
            #endregion
            #region 存储并新增

            shAddStationNewStation.Location = new Point(shAddStationClosePanel.Left - 45, 4);
            //shAddStationNewStation.Size = new Size(84, 30);
            shAddStationNewStation.Size = new Size(45, 30);
            shAddStationNewStation.CaptionHeight = 18;
            shAddStationNewStation.CaptionTitleLeft = 4;
            shAddStationNewStation.CaptionTitleTop = 4;
            shAddStationNewStation.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;

            shAddStationNewStation.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            shAddStationNewStation.CaptionTitle = "存储";
            shAddStationNewStation.Click += new EventHandler(shAddStationNewStation_Click);
            shAddStationNewStation.CausesValidation = true;
            shAddStationCaption.Controls.Add(shAddStationNewStation);
            #endregion

            label55.Text = "所属" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StationAddress) + ":";
            label11.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHeadSplace)+":";
            label22.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead)+"联系电话:";
            label33.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead)+"类型:";
            label44.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead)+"备注:";            
            label66.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHeadAddress)+":";
            label77.Text = "天线A描述:";
            label88.Text = "天线B描述:";

            label55.Location = new Point(50, 53);
            label66.Location = new Point(50, 83);
            label11.Location = new Point(50, 113);
            label22.Location = new Point(50, 143);
            label33.Location = new Point(50, 173);
            label77.Location = new Point(50, 203);
            label88.Location = new Point(50, 233);
            label44.Location = new Point(50, 263);
            
            lblStationAddress.Location = new Point(166, 53);
            lblStationHeadAddress.Location = new Point(166, 83);
            lblStationHeadAddress.MaxLength = 3;
            lblStationHeadAddress.Validated += new EventHandler(lblStationHeadAddress_Validated);
            shtxtPlace.Location = new Point(166, 113);
            shtxtPlace.MaxLength = 50;
            shtxtTel.Location = new Point(166, 143);
            shtxtTel.MaxLength = 15;
            shcmbType.Location = new Point(166, 173);
            shtxta.Location = new Point(166, 203);
            shtxta.MaxLength = 20;
            shtxtb.Location = new Point(166, 233);
            shtxtb.MaxLength = 20;
            shRemark.Location = new Point(166, 263);
            shRemark.MaxLength = 200;
            shlblInfo.Location = new Point(50, 293);

            shlblInfo.Size = new Size(150,12);
            shStationHeadFrm.Controls.Add(label11);
            shStationHeadFrm.Controls.Add(label22);
            shStationHeadFrm.Controls.Add(label33);
            shStationHeadFrm.Controls.Add(label44);
            shStationHeadFrm.Controls.Add(label55);
            shStationHeadFrm.Controls.Add(label66);
            shStationHeadFrm.Controls.Add(label77);
            shStationHeadFrm.Controls.Add(label88);
            shStationHeadFrm.Controls.Add(shtxta);
            shStationHeadFrm.Controls.Add(shtxtb);
            shStationHeadFrm.Controls.Add(lblStationAddress);
            shStationHeadFrm.Controls.Add(lblStationHeadAddress);
            shStationHeadFrm.Controls.Add(shlblInfo);

            shStationHeadFrm.Controls.Add(shtxtPlace);


            shtxtTel.Validated += new EventHandler(shtxtTel_Validated);
            shStationHeadFrm.Controls.Add(shtxtTel);

            shcmbType.DataSource = sbll.getStationTypeTab();
            shcmbType.DisplayMember = "Title";
            shcmbType.ValueMember = "EnumID";
            shcmbType.SelectedIndex = -1;
            shcmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            shStationHeadFrm.Controls.Add(shcmbType);

            shStationHeadFrm.Controls.Add(shRemark);

            #endregion
            shStationHeadFrm.Hide();
            shStationHeadFrm.BringToFront();

        }

        private void lblStationHeadAddress_Validated(object sender, EventArgs e)
        {
            if (!sbll.IsNumeric(lblStationHeadAddress.Text) && lblStationHeadAddress.Text != string.Empty)
            {
                shlblInfo.ForeColor = Color.Red;
                shlblInfo.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StationAddress) + "只能为整数";
                lblStationHeadAddress.Focus();
                return;
            }
            shlblInfo.Text = "";
        }

        private void lblStationAddress_Validated(object sender, EventArgs e)
        {
            if (!sbll.IsNumeric(lblStationAddress.Text) && lblStationAddress.Text != string.Empty)
            {
                shlblInfo.ForeColor = Color.Red;
                shlblInfo.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHeadAddress)+"只能为整数";
                lblStationAddress.Focus();
                return;
            }
            shlblInfo.Text = "";
        }

        #region 接收器编辑面板事件


        // 存储按钮
        public void shAddStationNewStation_Click(object sender, EventArgs e)
        {
            if (lblStationHeadAddress.Text.Trim() != "")
            {
                if (Convert.ToInt32(lblStationHeadAddress.Text.Trim()) > 31)
                {
                    MessageBox.Show("接收器编号不能大于31", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            
            //存入日志
            LogSave.Messages("[FrmStationManage]", LogIDType.UserLogID, "添加接收器，分站编号：" +lblStationAddress.Text +"，添加的接收器编号："+lblStationHeadAddress.Text );


            if (shcmbType.SelectedValue == null) 
            { 
                shlblInfo.ForeColor = Color.Red; shlblInfo.Text = "请选择" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead) + "类型"; 
                return; 
            }

            this.Validate();
            if (!lblStationHeadAddress.Enabled)
            {
                if (!sbll.IsTel(shtxtTel.Text) && shtxtTel.Text != string.Empty)
                {
                    shlblInfo.ForeColor = Color.Red;
                    shlblInfo.Text = "电话号码输入不正确";
                    shtxtTel.Focus();
                    return;
                }
                shlblInfo.Text = "";

                model = 2;

                if (sbll.updateStationHead(int.Parse(shStationHeadFrm.Tag.ToString()), shtxtPlace.Text
                    , shtxtTel.Text, int.Parse(shcmbType.SelectedValue.ToString() == "" ? "0" : shcmbType.SelectedValue.ToString())
                    , shcmbType.Text.ToString()
                    , shtxta.Text, shtxtb.Text, shRemark.Text) == 1)
                {
                    shlblInfo.ForeColor = Color.Blue;
                    shlblInfo.Text = "修改成功";

                     
                }
            }
            else
            {
                int stationAddress = int.Parse(lblStationAddress.Text);
                if (lblStationHeadAddress.Text == null || lblStationHeadAddress.Text == string.Empty) 
                { 
                    shlblInfo.ForeColor = Color.Red; shlblInfo.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHeadAddress)+"不能为空"; 
                    return;
                }

                if (!sbll.IsNumeric(lblStationHeadAddress.Text) && lblStationHeadAddress.Text != string.Empty)
                {
                    shlblInfo.ForeColor = Color.Red;
                    shlblInfo.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StationAddress) + "只能为整数";
                    lblStationHeadAddress.Focus();
                    return;
                }
                else
                {
                    shlblInfo.Text = "";
                }
                if (sbll.existsStationHeadAddress(int.Parse(lblStationHeadAddress.Text), stationAddress) < 1)
                {
                    if (sbll.insertStationHead(stationAddress, int.Parse(lblStationHeadAddress.Text), shtxtPlace.Text
                        , shtxtTel.Text, int.Parse(shcmbType.SelectedValue.ToString() == "" ? "0" : shcmbType.SelectedValue.ToString())
                        , shcmbType.Text.ToString()
                        , shtxta.Text, shtxtb.Text, shRemark.Text) == 1)
                    {
                        shlblInfo.ForeColor = Color.Blue;
                        shlblInfo.Text = "添加成功";
                    }

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
                        timer1.Start();
                    }
                }
                else
                {
                    shlblInfo.ForeColor = Color.Red;
                    shlblInfo.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHeadAddress)+"已存在,请重新输入";
                    return;
                }
            }

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
        }

        // 关闭按钮
        public void shAddStationClosePanel_Click(object sender, EventArgs e)
        {
            shStationHeadFrm.Visible = false;
            stationHeadClear();
        }

        // 清空接收器数据

        private void stationHeadClear()
        {
            lblStationHeadAddress.Text = "";
            shtxtPlace.Text = "";
            shtxtTel.Text = "";
            shcmbType.SelectedIndex = -1;
            shtxta.Text = "";
            shtxtb.Text = "";
            shRemark.Text = "";
        }

        #endregion

        #endregion

        #region Validated验证

        #region 电话号码验证

        // 接收器修改

        private void shtxtTel_Validated(object sender, EventArgs e)
        {
            if (!sbll.IsTel(shtxtTel.Text) && shtxtTel.Text != string.Empty)
            {
                shlblInfo.ForeColor = Color.Red;
                shlblInfo.Text = "电话号码输入不正确";
                shtxtTel.Focus();
                return;
            }
            shlblInfo.Text = "";
        }

        private void txtTel_Validated(object sender, EventArgs e)
        {
            if (!sbll.IsTel(txtTel.Text) && txtTel.Text != string.Empty)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "电话号码输入不正确";
                txtTel.Focus();
                return;
            }
            lblInfo.Text = "";
        }

        #endregion

        #region 分站地址号验证（是否为整数）

        private void txtBatchStationAddressMax_Validated(object sender, EventArgs e)
        {
            if (!sbll.IsNumeric(txtBatchStationAddressMax.Text) && txtBatchStationAddressMax.Text != string.Empty)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StationAddress)+"只能为整数";
                txtBatchStationAddressMax.Focus();
                return;
            }
            lblInfo.Text = "";
        }

        private void txtBatchStationAddressMin_Validated(object sender, EventArgs e)
        {
            if (!sbll.IsNumeric(txtBatchStationAddressMin.Text) && txtBatchStationAddressMin.Text != string.Empty)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StationAddress)+"能为整数";
                txtBatchStationAddressMin.Focus();
                return;
            }            
            lblInfo.Text = "";
        }

        #endregion

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

        

        #region 翻页事件

        // 初始化分站和接收器信息

        private void InitData()
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
                cmsStationHand.Items[0].Click += new EventHandler(FrmStationManage_Click);
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
            vspAddNewStation.Visible = false;

        }

        void pshi_one_MouseHover(object sender, EventArgs e)
        {
            PanelStationHeadInfo pshi = ((PanelStationHeadInfo)sender);
            toolTip.SetToolTip((Control)sender, pshi.ValueStationHeadPlace.FieldName + pshi.ValueAntennaA.FieldName);
            toolTip.Active = true;
        }

        private void pshi_one_Click(object sender, EventArgs e)
        {
            shAddStationTitle.CaptionTitle = "查看" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead) + "信息";
            shStationHeadFrm.BringToFront();
            shStationHeadFrm.Show();
            
            StationHeadFrmControlsEnable(false);
            shAddStationNewStation.Hide();
            shlblInfo.Text = "";
            shStationHeadFrm.Tag = ((PanelStationHeadInfo)sender).Tag.ToString();
            DataRow dr = sbll.getStationHeadRowInfo(int.Parse(((PanelStationHeadInfo)sender).Tag.ToString()));
            lblStationAddress.Text = dr["StationAddress"].ToString();
            lblStationHeadAddress.Text = dr["StationHeadAddress"].ToString();
            lblStationHeadAddress.Enabled = false;
            shtxtPlace.Text = dr["StationHeadPlace"].ToString();
            shtxtTel.Text = dr["StationHeadTel"].ToString();
            shcmbType.SelectedIndex = cmbType.FindString(dr["StationHeadType"].ToString());
            shtxta.Text = dr["AntennaA"].ToString();
            shtxtb.Text = dr["AntennaB"].ToString();
            shRemark.Text = dr["Remark"].ToString();
            vspAddNewStation.Visible = false;
        }

        #region Enable

        private void StationHeadFrmControlsEnable(bool bl)
        {
            lblStationHeadAddress.Enabled = bl;
            shtxtPlace.Enabled = bl;
            shtxtTel.Enabled = bl;
            shcmbType.Enabled = bl;
            shtxta.Enabled = bl;
            shtxtb.Enabled = bl;
            shRemark.Enabled = bl;
        }

        #endregion

        #region 菜单操作事件

        // 右键单击接收器信息

        void pshi_one_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tempSingleStation = ((StationMakeupVspanel)((PanelStationHeadInfo)sender).Parent);
                cmsStationHand.Tag = ((PanelStationHeadInfo)sender).Tag;
                cmsStationHand.Items["tsMenuDelete"].Tag = ((PanelStationHeadInfo)sender).ValueStationHeadAddress.ToString();
                vspAddNewStation.Visible = false;
            }
        }

        // 单击右键菜单->修改
        private void FrmStationManage_Click(object sender, EventArgs e)
        {
            shAddStationTitle.CaptionTitle = "修改" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead) + "信息";
            shStationHeadFrm.BringToFront();
            shStationHeadFrm.Show();

            StationHeadFrmControlsEnable(true);
            shAddStationNewStation.Show();
            shlblInfo.Text = "";
            shStationHeadFrm.Tag = cmsStationHand.Tag.ToString();
            DataRow dr = sbll.getStationHeadRowInfo(int.Parse(cmsStationHand.Tag.ToString()));
            lblStationAddress.Text = dr["StationAddress"].ToString();
            lblStationHeadAddress.Text = dr["StationHeadAddress"].ToString();
            lblStationHeadAddress.Enabled = false;
            shtxtPlace.Text = dr["StationHeadPlace"].ToString();
            shtxtTel.Text = dr["StationHeadTel"].ToString();
            shcmbType.SelectedIndex = cmbType.FindString(dr["StationHeadType"].ToString());
            shtxta.Text = dr["AntennaA"].ToString();
            shtxtb.Text = dr["AntennaB"].ToString();
            shRemark.Text = dr["Remark"].ToString();
            vspAddNewStation.Visible = false;
        }

        // 单击右键菜单->删除
        private void tsMenuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定删除" + tempSingleStation.StationAddress.ToString() + "号" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station) + "的[" + cmsStationHand.Items["tsMenuDelete"].Tag.ToString() + "]号" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead), "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                model = 2;

                if (cmsStationHand.Tag != null && cmsStationHand.Tag != string.Empty)
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
                            timer1.Start();
                        }
                    }
                }
            }
            
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmsStationHand.Hide();
        }

        #endregion

        #region 添加按钮 添加接收器


        private void smvpSingleStation_ClickAddStationHead(object sender, EventArgs e)
        {
            shAddStationTitle.CaptionTitleLeft = 1;
            shAddStationTitle.CaptionTitle = "添加" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StaHead) + "信息";
            stationHeadClear();
            shAddStationNewStation.Show();
            shStationHeadFrm.Show();
            StationHeadFrmControlsEnable(true);
            shlblInfo.Text = "";
            lblStationHeadAddress.Enabled = true;
            tempSingleStation = (StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent;
            lblStationAddress.Text = tempSingleStation.StationAddress.ToString();
            shcmbType.SelectedIndex = 0;
            vspAddNewStation.Visible = false;
        }

        #endregion

        #region 删除按钮单击事件

        private void smvpSingleStation_ClickDeleteStationButton(object sender, EventArgs e)
        {
            StationMakeupVspanel stationAddress = ((StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent);

            //存入日志
            LogSave.Messages("[FrmStationManage]", LogIDType.UserLogID, "删除传输分站，传输分站编号：" + stationAddress.StationAddress);

            if (MessageBox.Show("您确定删除[" + stationAddress.StationAddress.ToString() + "]号"+KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station), "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                model = 1;
                operated = 2;

                if (sbll.deleteStation(stationAddress.StationAddress) == 1)
                {
                    if (!New_DBAcess.IsDouble)
                    {
                        // 重新加载
                        int page = int.Parse(txtPage.CaptionTitle);
                        AddSingleStationInfo(page, false);
                    }
                    else
                    {
                        timer2.Start();
                    }
                }
            }
        }

        #endregion

        #region 修改按钮 单击事件

        private void smvpSingleStation_ClickEditStationButton(object sender, EventArgs e)
        {
            
            bcpAddStationTitle.CaptionTitle = "修改"+KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station)+"信息";
            vspAddNewStation.Visible = true;
            vspAddNewStation.BringToFront();
            lblBatchSeparate.Visible = false;
            chbEnabledBatchAdd.Visible = false;                 //隐藏批量添加按钮
            tempSingleStation = (StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent;
            DataRow dr = sbll.getStationInfo(int.Parse(((StationMakeupVspanel)((StationCaptionPanel)((ButtonCaptionPanel)sender).Parent).Parent).StationAddress.ToString()));
            txtBatchStationAddressMin.Enabled = false;
            txtBatchStationAddressMin.Text = dr["StationAddress"].ToString();
            txtBatchStationAddressMax.Text = string.Empty;
            txtBatchStationAddressMax.Visible = false;
            txtPlace.Text = dr["StationPlace"].ToString();
            txtTel.Text = dr["StationTel"].ToString();
            cmbType.SelectedIndex = cmbType.FindString(dr["StationType"].ToString()) == 0 ? 0 : cmbType.FindString(dr["StationType"].ToString());
            cmbGroup.SelectedIndex = cmbGroup.FindString(dr["StationGroup"].ToString());
            shStationHeadFrm.Visible = false;
        }

        #endregion

        #region 事件处理 新增分站面板内　各控件的事件处理
        /// <summary>
        /// 单击增加分站面板上的关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bcpAddStationClosePanel_Click(object sender, EventArgs e)
        {
            vspAddNewStation.Visible = false;
            this.clearStationForm();
            lblInfo.Text = "";
        }
       
        /// <summary>
        /// 当用户改变新增分站面板CheckBox的值时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chbEnabledBatchAdd_CheckedChanged(object sender, EventArgs e)
        {
            txtBatchStationAddressMax.Visible = chbEnabledBatchAdd.Checked;
            lblBatchSeparate.Visible = chbEnabledBatchAdd.Checked;
        }


        /// <summary>
        /// 单击　存储并新增

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bcpAddStationNewStation_Click(object sender, EventArgs e)
        {
            
            if (txtBatchStationAddressMin.Text.Trim() != "")
            {
                if (Convert.ToInt32(txtBatchStationAddressMin.Text) > 254)
                {
                    MessageBox.Show("分站号不能大于254", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            model = 1;

            //添加
            string min = txtBatchStationAddressMin.Text == string.Empty ? "0" : txtBatchStationAddressMin.Text;
            if (cmbType.SelectedValue == null) { lblInfo.ForeColor = Color.Red; lblInfo.Text = "请选择"+KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station)+"类型"; return; }
            if (cmbGroup.SelectedItem == null) { lblInfo.ForeColor = Color.Red; lblInfo.Text = "请选择" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station) + "分组"; return; }
            if (bcpAddStationTitle.CaptionTitle == "添加" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station) + "信息")
            {               
                string max = txtBatchStationAddressMax.Text == string.Empty ? "0" : txtBatchStationAddressMax.Text;
                if (txtBatchStationAddressMin.Text != string.Empty)
                {
                    string result = string.Empty;
                    sbll.addSatationAddress(int.Parse(min), int.Parse(max)
                        , txtPlace.Text == string.Empty ? "" : txtPlace.Text
                        , txtTel.Text, int.Parse(cmbType.SelectedValue.ToString() == "" ? "0" : cmbType.SelectedValue.ToString())
                        , cmbType.SelectedText.ToString()
                        , int.Parse(cmbGroup.SelectedItem.ToString()), chbEnabledBatchAdd.Checked,out result);
                    if (result == "添加成功")
                    {
                        //存入日志
                        LogSave.Messages("[FrmStationManage]", LogIDType.UserLogID, "添加新分站，分站编号：" + txtBatchStationAddressMin.Text + "，安装位置：" + txtPlace.Text);

                        MessageBox.Show(result);

                        if (!New_DBAcess.IsDouble)
                        {
                            InitData();             // 重新加载
                        }
                        else
                        {
                            timer1.Start();
                        }
                    }
                    else if (result.IndexOf("成功") != -1)
                    {
                        this.clearStationForm();
                        
                        MessageBox.Show(result);

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
                        MessageBox.Show(result);
                    }
                }
                else
                {
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Text = "请输入"+KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.StationAddress);
                }
                txtBatchStationAddressMin.Enabled = true;
            }
            else
            {
                //存入日志
                LogSave.Messages("[FrmStationManage]", LogIDType.UserLogID, "修改新分站，分站编号：" + txtBatchStationAddressMin.Text + "，安装位置：" + txtPlace.Text);

                if (!sbll.IsTel(txtTel.Text) && txtTel.Text != string.Empty)
                {
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Text = "电话号码输入不正确";
                    txtTel.Focus();
                    return;
                }
                lblInfo.Text = "";
                //修改保存
                int temp = sbll.updateStation(int.Parse(min), txtPlace.Text == string.Empty ? "" : txtPlace.Text
                        , txtTel.Text, int.Parse(cmbType.SelectedValue.ToString() == "" ? "0" : cmbType.SelectedValue.ToString())
                        , cmbType.Text.ToString()
                        , int.Parse(cmbGroup.SelectedItem.ToString()));
                if (temp == 1)
                {
                    tempSingleStation.LabelStationInfoText = "安装位置" + txtPlace.Text;
                    lblInfo.Text = "修改成功";
                    lblInfo.ForeColor = Color.Blue;
                    txtBatchStationAddressMin.Enabled = false;
                }
            }
            
        }

        #region 清空分站

        private void clearStationForm()
        {
            txtBatchStationAddressMin.Text = string.Empty;
            txtBatchStationAddressMax.Text = string.Empty;
            txtPlace.Text = string.Empty;
            txtTel.Text = string.Empty;
            cmbType.SelectedIndex = 0;
            cmbGroup.SelectedIndex = 0;
        }

        #endregion

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
        
        /// <summary>
        /// 单击　新增分站　按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpAddNewStation_Click(object sender, EventArgs e)
        {
            bcpAddStationTitle.CaptionTitle = "添加" + KJ128NDataBase.HardwareName.Value(KJ128NDataBase.CorpsName.Station)+"信息";
            // -- 
            chbEnabledBatchAdd.Checked = false;
            #region [ 清空数据 ]

            txtBatchStationAddressMin.Text = "";
            txtBatchStationAddressMax.Text = "";
            txtTel.Text = txtPlace.Text = "";

            #endregion

            txtBatchStationAddressMin.Enabled = true;
            vspAddNewStation.Visible = true;
            vspAddNewStation.BringToFront();
            //chbEnabledBatchAdd.Visible = true;
            shStationHeadFrm.Visible = false;
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


        #region 【删除分站】

        private void timer2_Tick(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            AddSingleStationInfo(page, false);
            timer2.Stop();
        }

        #endregion

        private void buttonCaptionPanel1_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            AddSingleStationInfo(page, false);
        }

        private void FrmStationManage_Load(object sender, EventArgs e)
        {
            chbEnabledBatchAdd.Visible = false;
        }

    }
}