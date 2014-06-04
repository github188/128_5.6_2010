namespace KJ128NMainRun.RealTime.RealTimeDirectional
{
    partial class FrmRealTimeDirectional
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRealTimeDirectional));
            this.dgvRTInfo = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.buttonCaptionPanel8 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.vspSingleSelect = new KJ128WindowsLibrary.VSPanel();
            this.chk = new System.Windows.Forms.CheckBox();
            this.gbx0 = new System.Windows.Forms.GroupBox();
            this.txtDirectional = new Shine.ShineTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStaHead = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.txtCardAddress = new KJ128N.Command.TxtNumber();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bcpClear = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cbpExec = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.group = new System.Windows.Forms.GroupBox();
            this.rbtnEqu = new System.Windows.Forms.RadioButton();
            this.rbtnEmp = new System.Windows.Forms.RadioButton();
            this.buttonCaptionPanel3 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.tvDept = new KJ128WindowsLibrary.TreeViewDepartment();
            this.buttonCaptionPanel2 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.buttonCaptionPanel1 = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.timeControl = new System.Windows.Forms.Timer(this.components);
            this.bcpPageSum = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.cpToExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel3 = new Wilson.Controls.XPPanel.SXPPanel();
            this.sxpPanel2 = new Wilson.Controls.XPPanel.SXPPanel();
            this.sxpPanel1 = new Wilson.Controls.XPPanel.SXPPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRTInfo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel3.SuspendLayout();
            this.sxpPanel2.SuspendLayout();
            this.sxpPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRTInfo
            // 
            this.dgvRTInfo.AllowUserToAddRows = false;
            this.dgvRTInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvRTInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRTInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRTInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgvRTInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRTInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRTInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRTInfo.ColumnHeadersHeight = 32;
            this.dgvRTInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRTInfo.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgvRTInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRTInfo.EnableHeadersVisualStyles = false;
            this.dgvRTInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgvRTInfo.Location = new System.Drawing.Point(220, 32);
            this.dgvRTInfo.Name = "dgvRTInfo";
            this.dgvRTInfo.ReadOnly = true;
            this.dgvRTInfo.RowHeadersVisible = false;
            this.dgvRTInfo.RowHeadersWidth = 20;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvRTInfo.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRTInfo.RowTemplate.Height = 23;
            this.dgvRTInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRTInfo.Size = new System.Drawing.Size(808, 706);
            this.dgvRTInfo.TabIndex = 34;
            this.dgvRTInfo.VerticalScrollBarMax = 1;
            this.dgvRTInfo.VerticalScrollBarValue = 0;
            // 
            // buttonCaptionPanel8
            // 
            this.buttonCaptionPanel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel8.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel8.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel8.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel8.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel8.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel8.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel8.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel8.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel8.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel8.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel8.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel8.CaptionHeight = 30;
            this.buttonCaptionPanel8.CaptionLeft = 1;
            this.buttonCaptionPanel8.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel8.CaptionTitle = "实时方向性信息：";
            this.buttonCaptionPanel8.CaptionTitleLeft = 8;
            this.buttonCaptionPanel8.CaptionTitleTop = 8;
            this.buttonCaptionPanel8.CaptionTop = 1;
            this.buttonCaptionPanel8.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCaptionPanel8.IsBorderLine = true;
            this.buttonCaptionPanel8.IsCaptionSingleColor = false;
            this.buttonCaptionPanel8.IsOnlyCaption = true;
            this.buttonCaptionPanel8.IsPanelImage = true;
            this.buttonCaptionPanel8.IsUserButtonClose = false;
            this.buttonCaptionPanel8.IsUserCaptionBottomLine = true;
            this.buttonCaptionPanel8.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel8.Location = new System.Drawing.Point(220, 0);
            this.buttonCaptionPanel8.Name = "buttonCaptionPanel8";
            this.buttonCaptionPanel8.PanelImage = null;
            this.buttonCaptionPanel8.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel8.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.buttonCaptionPanel8.Size = new System.Drawing.Size(808, 32);
            this.buttonCaptionPanel8.TabIndex = 33;
            this.buttonCaptionPanel8.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // vspSingleSelect
            // 
            this.vspSingleSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.vspSingleSelect.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vspSingleSelect.BetweenControlCount = 2;
            this.vspSingleSelect.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vspSingleSelect.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vspSingleSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vspSingleSelect.HorizontalInterval = 8;
            this.vspSingleSelect.IsBorderLine = true;
            this.vspSingleSelect.IsBottomLineColor = true;
            this.vspSingleSelect.IsCaptionSingleColor = true;
            this.vspSingleSelect.IsDragModel = false;
            this.vspSingleSelect.IsmiddleInterval = false;
            this.vspSingleSelect.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.FreeLayoutType;
            this.vspSingleSelect.LeftInterval = 0;
            this.vspSingleSelect.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.vspSingleSelect.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.vspSingleSelect.Location = new System.Drawing.Point(0, 76);
            this.vspSingleSelect.MiddleInterval = 80;
            this.vspSingleSelect.Name = "vspSingleSelect";
            this.vspSingleSelect.RightInterval = 0;
            this.vspSingleSelect.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.paleCaption;
            this.vspSingleSelect.Size = new System.Drawing.Size(138, 21);
            this.vspSingleSelect.TabIndex = 9;
            this.vspSingleSelect.TopInterval = 0;
            this.vspSingleSelect.VerticalInterval = 8;
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.Location = new System.Drawing.Point(98, 73);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(104, 17);
            this.chk.TabIndex = 11;
            this.chk.Text = "实时更新数据";
            this.chk.UseVisualStyleBackColor = true;
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // gbx0
            // 
            this.gbx0.Location = new System.Drawing.Point(103, 12);
            this.gbx0.Name = "gbx0";
            this.gbx0.Size = new System.Drawing.Size(82, 17);
            this.gbx0.TabIndex = 7;
            this.gbx0.TabStop = false;
            this.gbx0.Text = "分类查询";
            this.gbx0.Visible = false;
            // 
            // txtDirectional
            // 
            this.txtDirectional.Location = new System.Drawing.Point(92, 99);
            this.txtDirectional.MaxLength = 20;
            this.txtDirectional.Name = "txtDirectional";
            this.txtDirectional.Size = new System.Drawing.Size(106, 20);
            this.txtDirectional.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "方向性描述：";
            // 
            // cmbStaHead
            // 
            this.cmbStaHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaHead.FormattingEnabled = true;
            this.cmbStaHead.Location = new System.Drawing.Point(92, 155);
            this.cmbStaHead.Name = "cmbStaHead";
            this.cmbStaHead.Size = new System.Drawing.Size(106, 20);
            this.cmbStaHead.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "接收器编号：";
            // 
            // cmbStation
            // 
            this.cmbStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStation.FormattingEnabled = true;
            this.cmbStation.Location = new System.Drawing.Point(92, 127);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(106, 20);
            this.cmbStation.TabIndex = 5;
            this.cmbStation.SelectionChangeCommitted += new System.EventHandler(this.cmbStation_SelectionChangeCommitted);
            // 
            // txtCardAddress
            // 
            this.txtCardAddress.Location = new System.Drawing.Point(92, 71);
            this.txtCardAddress.MaxLength = 38;
            this.txtCardAddress.Name = "txtCardAddress";
            this.txtCardAddress.Size = new System.Drawing.Size(106, 20);
            this.txtCardAddress.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "发码器编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "分站编号：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 44);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(106, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓    名：";
            // 
            // bcpClear
            // 
            this.bcpClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpClear.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpClear.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpClear.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpClear.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpClear.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpClear.CaptionBottomLineWidth = 1;
            this.bcpClear.CaptionCloseButtonControlLeft = 2;
            this.bcpClear.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpClear.CaptionCloseButtonTitle = "×";
            this.bcpClear.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpClear.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpClear.CaptionHeight = 20;
            this.bcpClear.CaptionLeft = 1;
            this.bcpClear.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpClear.CaptionTitle = "重  置";
            this.bcpClear.CaptionTitleLeft = 12;
            this.bcpClear.CaptionTitleTop = 4;
            this.bcpClear.CaptionTop = 1;
            this.bcpClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpClear.IsBorderLine = true;
            this.bcpClear.IsCaptionSingleColor = false;
            this.bcpClear.IsOnlyCaption = true;
            this.bcpClear.IsPanelImage = true;
            this.bcpClear.IsUserButtonClose = false;
            this.bcpClear.IsUserCaptionBottomLine = false;
            this.bcpClear.IsUserSystemCloseButtonLeft = true;
            this.bcpClear.Location = new System.Drawing.Point(126, 99);
            this.bcpClear.Name = "bcpClear";
            this.bcpClear.PanelImage = null;
            this.bcpClear.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpClear.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpClear.Size = new System.Drawing.Size(63, 22);
            this.bcpClear.TabIndex = 10;
            this.bcpClear.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpClear.Click += new System.EventHandler(this.bcpClear_Click);
            // 
            // cbpExec
            // 
            this.cbpExec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbpExec.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cbpExec.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cbpExec.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.cbpExec.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.cbpExec.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cbpExec.CaptionBottomLineWidth = 1;
            this.cbpExec.CaptionCloseButtonControlLeft = 2;
            this.cbpExec.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbpExec.CaptionCloseButtonTitle = "×";
            this.cbpExec.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbpExec.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbpExec.CaptionHeight = 20;
            this.cbpExec.CaptionLeft = 1;
            this.cbpExec.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cbpExec.CaptionTitle = "查  询";
            this.cbpExec.CaptionTitleLeft = 12;
            this.cbpExec.CaptionTitleTop = 4;
            this.cbpExec.CaptionTop = 1;
            this.cbpExec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbpExec.IsBorderLine = true;
            this.cbpExec.IsCaptionSingleColor = false;
            this.cbpExec.IsOnlyCaption = true;
            this.cbpExec.IsPanelImage = true;
            this.cbpExec.IsUserButtonClose = false;
            this.cbpExec.IsUserCaptionBottomLine = false;
            this.cbpExec.IsUserSystemCloseButtonLeft = true;
            this.cbpExec.Location = new System.Drawing.Point(18, 99);
            this.cbpExec.Name = "cbpExec";
            this.cbpExec.PanelImage = null;
            this.cbpExec.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cbpExec.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cbpExec.Size = new System.Drawing.Size(63, 22);
            this.cbpExec.TabIndex = 9;
            this.cbpExec.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cbpExec.Click += new System.EventHandler(this.cbpExec_Click);
            // 
            // group
            // 
            this.group.Location = new System.Drawing.Point(58, 702);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(78, 24);
            this.group.TabIndex = 6;
            this.group.TabStop = false;
            this.group.Text = "选择查询类型";
            this.group.Visible = false;
            // 
            // rbtnEqu
            // 
            this.rbtnEqu.AutoSize = true;
            this.rbtnEqu.Location = new System.Drawing.Point(115, 47);
            this.rbtnEqu.Name = "rbtnEqu";
            this.rbtnEqu.Size = new System.Drawing.Size(51, 17);
            this.rbtnEqu.TabIndex = 6;
            this.rbtnEqu.Text = "设备";
            this.rbtnEqu.UseVisualStyleBackColor = true;
            // 
            // rbtnEmp
            // 
            this.rbtnEmp.AutoSize = true;
            this.rbtnEmp.Checked = true;
            this.rbtnEmp.Location = new System.Drawing.Point(20, 47);
            this.rbtnEmp.Name = "rbtnEmp";
            this.rbtnEmp.Size = new System.Drawing.Size(51, 17);
            this.rbtnEmp.TabIndex = 6;
            this.rbtnEmp.TabStop = true;
            this.rbtnEmp.Text = "人员";
            this.rbtnEmp.UseVisualStyleBackColor = true;
            // 
            // buttonCaptionPanel3
            // 
            this.buttonCaptionPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel3.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel3.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.buttonCaptionPanel3.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.buttonCaptionPanel3.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel3.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel3.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel3.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel3.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel3.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel3.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel3.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(22)))), ((int)(((byte)(110)))));
            this.buttonCaptionPanel3.CaptionHeight = 20;
            this.buttonCaptionPanel3.CaptionLeft = 1;
            this.buttonCaptionPanel3.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel3.CaptionTitle = "单选条件";
            this.buttonCaptionPanel3.CaptionTitleLeft = 8;
            this.buttonCaptionPanel3.CaptionTitleTop = 4;
            this.buttonCaptionPanel3.CaptionTop = 1;
            this.buttonCaptionPanel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCaptionPanel3.IsBorderLine = true;
            this.buttonCaptionPanel3.IsCaptionSingleColor = true;
            this.buttonCaptionPanel3.IsOnlyCaption = true;
            this.buttonCaptionPanel3.IsPanelImage = true;
            this.buttonCaptionPanel3.IsUserButtonClose = false;
            this.buttonCaptionPanel3.IsUserCaptionBottomLine = true;
            this.buttonCaptionPanel3.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel3.Location = new System.Drawing.Point(0, 54);
            this.buttonCaptionPanel3.Name = "buttonCaptionPanel3";
            this.buttonCaptionPanel3.PanelImage = null;
            this.buttonCaptionPanel3.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel3.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.paleCaption;
            this.buttonCaptionPanel3.Size = new System.Drawing.Size(138, 22);
            this.buttonCaptionPanel3.TabIndex = 8;
            this.buttonCaptionPanel3.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // tvDept
            // 
            this.tvDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDept.Location = new System.Drawing.Point(2, 35);
            this.tvDept.Name = "tvDept";
            this.tvDept.Size = new System.Drawing.Size(200, 196);
            this.tvDept.TabIndex = 7;
            this.tvDept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDept_AfterSelect);
            // 
            // buttonCaptionPanel2
            // 
            this.buttonCaptionPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel2.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.buttonCaptionPanel2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.buttonCaptionPanel2.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.buttonCaptionPanel2.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel2.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel2.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel2.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel2.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel2.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel2.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel2.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(22)))), ((int)(((byte)(110)))));
            this.buttonCaptionPanel2.CaptionHeight = 20;
            this.buttonCaptionPanel2.CaptionLeft = 1;
            this.buttonCaptionPanel2.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel2.CaptionTitle = "选择部门";
            this.buttonCaptionPanel2.CaptionTitleLeft = 8;
            this.buttonCaptionPanel2.CaptionTitleTop = 4;
            this.buttonCaptionPanel2.CaptionTop = 1;
            this.buttonCaptionPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCaptionPanel2.IsBorderLine = true;
            this.buttonCaptionPanel2.IsCaptionSingleColor = true;
            this.buttonCaptionPanel2.IsOnlyCaption = true;
            this.buttonCaptionPanel2.IsPanelImage = true;
            this.buttonCaptionPanel2.IsUserButtonClose = false;
            this.buttonCaptionPanel2.IsUserCaptionBottomLine = true;
            this.buttonCaptionPanel2.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel2.Location = new System.Drawing.Point(0, 32);
            this.buttonCaptionPanel2.Name = "buttonCaptionPanel2";
            this.buttonCaptionPanel2.PanelImage = null;
            this.buttonCaptionPanel2.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel2.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.paleCaption;
            this.buttonCaptionPanel2.Size = new System.Drawing.Size(138, 22);
            this.buttonCaptionPanel2.TabIndex = 6;
            this.buttonCaptionPanel2.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // buttonCaptionPanel1
            // 
            this.buttonCaptionPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCaptionPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.buttonCaptionPanel1.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel1.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.buttonCaptionPanel1.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.buttonCaptionPanel1.CaptionBottomLineWidth = 1;
            this.buttonCaptionPanel1.CaptionCloseButtonControlLeft = 2;
            this.buttonCaptionPanel1.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCaptionPanel1.CaptionCloseButtonTitle = "×";
            this.buttonCaptionPanel1.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCaptionPanel1.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCaptionPanel1.CaptionHeight = 30;
            this.buttonCaptionPanel1.CaptionLeft = 1;
            this.buttonCaptionPanel1.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.buttonCaptionPanel1.CaptionTitle = "筛选条件：";
            this.buttonCaptionPanel1.CaptionTitleLeft = 8;
            this.buttonCaptionPanel1.CaptionTitleTop = 8;
            this.buttonCaptionPanel1.CaptionTop = 1;
            this.buttonCaptionPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCaptionPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCaptionPanel1.IsBorderLine = true;
            this.buttonCaptionPanel1.IsCaptionSingleColor = false;
            this.buttonCaptionPanel1.IsOnlyCaption = true;
            this.buttonCaptionPanel1.IsPanelImage = true;
            this.buttonCaptionPanel1.IsUserButtonClose = false;
            this.buttonCaptionPanel1.IsUserCaptionBottomLine = true;
            this.buttonCaptionPanel1.IsUserSystemCloseButtonLeft = true;
            this.buttonCaptionPanel1.Location = new System.Drawing.Point(0, 0);
            this.buttonCaptionPanel1.Name = "buttonCaptionPanel1";
            this.buttonCaptionPanel1.PanelImage = null;
            this.buttonCaptionPanel1.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.buttonCaptionPanel1.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.BlueCaption;
            this.buttonCaptionPanel1.Size = new System.Drawing.Size(138, 32);
            this.buttonCaptionPanel1.TabIndex = 5;
            this.buttonCaptionPanel1.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // timeControl
            // 
            this.timeControl.Enabled = true;
            this.timeControl.Interval = KJ128NInterfaceShow.RefReshTime._rtTime;
            this.timeControl.Tick += new System.EventHandler(this.timeControl_Tick);
            // 
            // bcpPageSum
            // 
            this.bcpPageSum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpPageSum.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpPageSum.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpPageSum.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpPageSum.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpPageSum.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpPageSum.CaptionBottomLineWidth = 1;
            this.bcpPageSum.CaptionCloseButtonControlLeft = 2;
            this.bcpPageSum.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpPageSum.CaptionCloseButtonTitle = "×";
            this.bcpPageSum.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpPageSum.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.bcpPageSum.CaptionHeight = 20;
            this.bcpPageSum.CaptionLeft = 1;
            this.bcpPageSum.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpPageSum.CaptionTitle = "";
            this.bcpPageSum.CaptionTitleLeft = 8;
            this.bcpPageSum.CaptionTitleTop = 4;
            this.bcpPageSum.CaptionTop = 1;
            this.bcpPageSum.Cursor = System.Windows.Forms.Cursors.Default;
            this.bcpPageSum.IsBorderLine = true;
            this.bcpPageSum.IsCaptionSingleColor = true;
            this.bcpPageSum.IsOnlyCaption = true;
            this.bcpPageSum.IsPanelImage = false;
            this.bcpPageSum.IsUserButtonClose = false;
            this.bcpPageSum.IsUserCaptionBottomLine = false;
            this.bcpPageSum.IsUserSystemCloseButtonLeft = true;
            this.bcpPageSum.Location = new System.Drawing.Point(338, 4);
            this.bcpPageSum.Name = "bcpPageSum";
            this.bcpPageSum.PanelImage = null;
            this.bcpPageSum.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.None;
            this.bcpPageSum.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.Office2007Panel;
            this.bcpPageSum.Size = new System.Drawing.Size(82, 22);
            this.bcpPageSum.TabIndex = 38;
            this.bcpPageSum.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.bcpPageSum.Visible = false;
            // 
            // cpToExcel
            // 
            this.cpToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpToExcel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpToExcel.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpToExcel.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.cpToExcel.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.cpToExcel.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpToExcel.CaptionBottomLineWidth = 1;
            this.cpToExcel.CaptionCloseButtonControlLeft = 2;
            this.cpToExcel.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpToExcel.CaptionCloseButtonTitle = "×";
            this.cpToExcel.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpToExcel.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpToExcel.CaptionHeight = 20;
            this.cpToExcel.CaptionLeft = 1;
            this.cpToExcel.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpToExcel.CaptionTitle = " 打  印";
            this.cpToExcel.CaptionTitleLeft = 10;
            this.cpToExcel.CaptionTitleTop = 4;
            this.cpToExcel.CaptionTop = 1;
            this.cpToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpToExcel.IsBorderLine = true;
            this.cpToExcel.IsCaptionSingleColor = false;
            this.cpToExcel.IsOnlyCaption = true;
            this.cpToExcel.IsPanelImage = true;
            this.cpToExcel.IsUserButtonClose = false;
            this.cpToExcel.IsUserCaptionBottomLine = false;
            this.cpToExcel.IsUserSystemCloseButtonLeft = true;
            this.cpToExcel.Location = new System.Drawing.Point(938, 4);
            this.cpToExcel.Name = "cpToExcel";
            this.cpToExcel.PanelImage = null;
            this.cpToExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpToExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpToExcel.Size = new System.Drawing.Size(84, 22);
            this.cpToExcel.TabIndex = 118;
            this.cpToExcel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            this.cpToExcel.Click += new System.EventHandler(this.cpToExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vspSingleSelect);
            this.panel1.Controls.Add(this.buttonCaptionPanel3);
            this.panel1.Controls.Add(this.buttonCaptionPanel2);
            this.panel1.Controls.Add(this.buttonCaptionPanel1);
            this.panel1.Location = new System.Drawing.Point(41, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 97);
            this.panel1.TabIndex = 119;
            this.panel1.Visible = false;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel3);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel2);
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel1);
            this.sxpPanelGroup1.Controls.Add(this.group);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(220, 738);
            this.sxpPanelGroup1.TabIndex = 120;
            // 
            // sxpPanel3
            // 
            this.sxpPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel3.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel3.Caption = "查询";
            this.sxpPanel3.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel3.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel3.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel3.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel3.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel3.Controls.Add(this.rbtnEqu);
            this.sxpPanel3.Controls.Add(this.chk);
            this.sxpPanel3.Controls.Add(this.rbtnEmp);
            this.sxpPanel3.Controls.Add(this.bcpClear);
            this.sxpPanel3.Controls.Add(this.cbpExec);
            this.sxpPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel3.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel3.ImageItems.ImageSet = null;
            this.sxpPanel3.ImageItems.Normal = -1;
            this.sxpPanel3.Location = new System.Drawing.Point(8, 447);
            this.sxpPanel3.Name = "sxpPanel3";
            this.sxpPanel3.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel3.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel3.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel3.Size = new System.Drawing.Size(204, 134);
            this.sxpPanel3.TabIndex = 2;
            this.sxpPanel3.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel3.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel3.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel3.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // sxpPanel2
            // 
            this.sxpPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel2.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel2.Caption = "分类查询";
            this.sxpPanel2.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel2.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel2.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel2.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel2.Controls.Add(this.gbx0);
            this.sxpPanel2.Controls.Add(this.label1);
            this.sxpPanel2.Controls.Add(this.txtDirectional);
            this.sxpPanel2.Controls.Add(this.label2);
            this.sxpPanel2.Controls.Add(this.label7);
            this.sxpPanel2.Controls.Add(this.txtName);
            this.sxpPanel2.Controls.Add(this.cmbStaHead);
            this.sxpPanel2.Controls.Add(this.label3);
            this.sxpPanel2.Controls.Add(this.label4);
            this.sxpPanel2.Controls.Add(this.txtCardAddress);
            this.sxpPanel2.Controls.Add(this.cmbStation);
            this.sxpPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel2.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel2.ImageItems.ImageSet = null;
            this.sxpPanel2.ImageItems.Normal = -1;
            this.sxpPanel2.Location = new System.Drawing.Point(8, 250);
            this.sxpPanel2.Name = "sxpPanel2";
            this.sxpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.Size = new System.Drawing.Size(204, 189);
            this.sxpPanel2.TabIndex = 1;
            this.sxpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel2.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // sxpPanel1
            // 
            this.sxpPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel1.Caption = "选择部门";
            this.sxpPanel1.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel1.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel1.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel1.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel1.Controls.Add(this.panel1);
            this.sxpPanel1.Controls.Add(this.tvDept);
            this.sxpPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel1.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel1.ImageItems.ImageSet = null;
            this.sxpPanel1.ImageItems.Normal = -1;
            this.sxpPanel1.Location = new System.Drawing.Point(8, 8);
            this.sxpPanel1.Name = "sxpPanel1";
            this.sxpPanel1.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel1.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel1.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel1.Size = new System.Drawing.Size(204, 234);
            this.sxpPanel1.TabIndex = 0;
            this.sxpPanel1.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel1.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel1.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel1.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // FrmRealTimeDirectional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 738);
            this.Controls.Add(this.dgvRTInfo);
            this.Controls.Add(this.cpToExcel);
            this.Controls.Add(this.bcpPageSum);
            this.Controls.Add(this.buttonCaptionPanel8);
            this.Controls.Add(this.sxpPanelGroup1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRealTimeDirectional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "实时方向性";
            this.Text = "实时方向性";
            this.Load += new System.EventHandler(this.FrmRealTimeDirectional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRTInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel3.ResumeLayout(false);
            this.sxpPanel3.PerformLayout();
            this.sxpPanel2.ResumeLayout(false);
            this.sxpPanel2.PerformLayout();
            this.sxpPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KJ128WindowsLibrary.VSPanel vspSingleSelect;
        private System.Windows.Forms.CheckBox chk;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpClear;
        private KJ128WindowsLibrary.ButtonCaptionPanel cbpExec;
        private System.Windows.Forms.GroupBox gbx0;
        private System.Windows.Forms.TextBox txtDirectional;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStaHead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStation;
        private KJ128N.Command.TxtNumber txtCardAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.RadioButton rbtnEqu;
        private System.Windows.Forms.RadioButton rbtnEmp;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel3;
        private KJ128WindowsLibrary.TreeViewDepartment tvDept;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel2;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvRTInfo;
        private KJ128WindowsLibrary.ButtonCaptionPanel buttonCaptionPanel8;
        private System.Windows.Forms.Timer timeControl;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpPageSum;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpToExcel;
        private System.Windows.Forms.Panel panel1;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel2;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel3;

    }
}