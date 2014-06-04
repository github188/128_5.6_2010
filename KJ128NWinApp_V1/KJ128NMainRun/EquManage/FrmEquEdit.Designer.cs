namespace KJ128NMainRun.EquManage
{
    partial class FrmEquEdit
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCanel = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.vsPanel = new KJ128WindowsLibrary.VSPanel();
            this.plEquDetail = new KJ128WindowsLibrary.StationMakeupVspanel();
            this.txtEquPower = new KJ128N.Command.TxtNumber();
            this.txtEquHeight = new KJ128N.Command.TxtNumber();
            this.dtimeUserDate = new System.Windows.Forms.DateTimePicker();
            this.txtUseRange = new Shine.ShineTextBox();
            this.dtimeProductionDate = new System.Windows.Forms.DateTimePicker();
            this.txtDutyEmployee = new Shine.ShineTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModelSpecial = new Shine.ShineTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.plEqu_BaseInfo = new KJ128WindowsLibrary.StationMakeupVspanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemark = new Shine.ShineTextBox();
            this.cmbEquState = new System.Windows.Forms.ComboBox();
            this.cmbEquType = new System.Windows.Forms.ComboBox();
            this.txtEquNO = new Shine.ShineTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFactoryID = new System.Windows.Forms.ComboBox();
            this.txtEquName = new Shine.ShineTextBox();
            this.cmbDeptID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vsPanel.SuspendLayout();
            this.plEquDetail.SuspendLayout();
            this.plEqu_BaseInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(109, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "确定";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(216, 8);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(68, 23);
            this.btnCanel.TabIndex = 5;
            this.btnCanel.Text = "清空";
            this.btnCanel.UseVisualStyleBackColor = true;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(326, 8);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(68, 23);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // vsPanel
            // 
            this.vsPanel.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vsPanel.BetweenControlCount = 2;
            this.vsPanel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.vsPanel.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vsPanel.Controls.Add(this.plEquDetail);
            this.vsPanel.Controls.Add(this.plEqu_BaseInfo);
            this.vsPanel.Controls.Add(this.panel1);
            this.vsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsPanel.HorizontalInterval = 8;
            this.vsPanel.IsBorderLine = true;
            this.vsPanel.IsBottomLineColor = false;
            this.vsPanel.IsCaptionSingleColor = true;
            this.vsPanel.IsDragModel = false;
            this.vsPanel.IsmiddleInterval = false;
            this.vsPanel.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.VerticalType;
            this.vsPanel.LeftInterval = 0;
            this.vsPanel.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.vsPanel.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.vsPanel.Location = new System.Drawing.Point(0, 0);
            this.vsPanel.MiddleInterval = 80;
            this.vsPanel.Name = "vsPanel";
            this.vsPanel.RightInterval = 0;
            this.vsPanel.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vsPanel.Size = new System.Drawing.Size(513, 548);
            this.vsPanel.TabIndex = 3;
            this.vsPanel.TopInterval = 0;
            this.vsPanel.VerticalInterval = 8;
            // 
            // plEquDetail
            // 
            this.plEquDetail.AddNewStationHeadInfoText = "";
            this.plEquDetail.AddNewStationHeadInfoWidth = 76;
            this.plEquDetail.AllowMaxHeight = false;
            this.plEquDetail.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.plEquDetail.BetweenControlCount = 2;
            this.plEquDetail.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.plEquDetail.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.plEquDetail.CaptionTitle = "设备详细信息(选填)";
            this.plEquDetail.Controls.Add(this.txtEquPower);
            this.plEquDetail.Controls.Add(this.txtEquHeight);
            this.plEquDetail.Controls.Add(this.dtimeUserDate);
            this.plEquDetail.Controls.Add(this.txtUseRange);
            this.plEquDetail.Controls.Add(this.dtimeProductionDate);
            this.plEquDetail.Controls.Add(this.txtDutyEmployee);
            this.plEquDetail.Controls.Add(this.label8);
            this.plEquDetail.Controls.Add(this.txtModelSpecial);
            this.plEquDetail.Controls.Add(this.label10);
            this.plEquDetail.Controls.Add(this.label9);
            this.plEquDetail.Controls.Add(this.label11);
            this.plEquDetail.Controls.Add(this.label12);
            this.plEquDetail.Controls.Add(this.label14);
            this.plEquDetail.Controls.Add(this.label13);
            this.plEquDetail.DeleteStationButtonText = "";
            this.plEquDetail.DeleteStationButtonWidth = 76;
            this.plEquDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.plEquDetail.EditStationInfoText = "";
            this.plEquDetail.EditStationInfoWidth = 76;
            this.plEquDetail.HorizontalInterval = 8;
            this.plEquDetail.IsBorderLine = true;
            this.plEquDetail.IsBottomLineColor = false;
            this.plEquDetail.IsCaptionSingleColor = true;
            this.plEquDetail.IsDragModel = true;
            this.plEquDetail.IsLabelStationInfoAlarm = false;
            this.plEquDetail.IsmiddleInterval = false;
            this.plEquDetail.IsShowAddNewStationHeadInfo = false;
            this.plEquDetail.IsShowDeleteStationInfo = false;
            this.plEquDetail.IsShowEditStationInfo = false;
            this.plEquDetail.IsShowLabelStationInfo = false;
            this.plEquDetail.IsShrink = true;
            this.plEquDetail.LabelStationInfoForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.plEquDetail.LabelStationInfoLeft = 74;
            this.plEquDetail.LabelStationInfoText = "";
            this.plEquDetail.LabelStatonInfoWidth = 300;
            this.plEquDetail.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.FreeLayoutType;
            this.plEquDetail.LeftInterval = 0;
            this.plEquDetail.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.plEquDetail.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.plEquDetail.Location = new System.Drawing.Point(0, 268);
            this.plEquDetail.MaxHeight = 22;
            this.plEquDetail.MiddleInterval = 80;
            this.plEquDetail.Name = "plEquDetail";
            this.plEquDetail.RightInterval = 0;
            this.plEquDetail.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.plEquDetail.Size = new System.Drawing.Size(513, 22);
            this.plEquDetail.StationAddress = 1;
            this.plEquDetail.TabIndex = 3;
            this.plEquDetail.TopInterval = 0;
            this.plEquDetail.VerticalInterval = 8;
            this.plEquDetail.ShiftButtonMouseClick += new System.EventHandler(this.plEqu_BaseInfo_ShiftButtonMouseClick);
            // 
            // txtEquPower
            // 
            this.txtEquPower.Location = new System.Drawing.Point(326, 122);
            this.txtEquPower.MaxLength = 10;
            this.txtEquPower.Name = "txtEquPower";
            this.txtEquPower.Size = new System.Drawing.Size(125, 21);
            this.txtEquPower.TabIndex = 17;
            // 
            // txtEquHeight
            // 
            this.txtEquHeight.Location = new System.Drawing.Point(89, 122);
            this.txtEquHeight.MaxLength = 5;
            this.txtEquHeight.Name = "txtEquHeight";
            this.txtEquHeight.Size = new System.Drawing.Size(125, 21);
            this.txtEquHeight.TabIndex = 16;
            // 
            // dtimeUserDate
            // 
            this.dtimeUserDate.Location = new System.Drawing.Point(89, 199);
            this.dtimeUserDate.Name = "dtimeUserDate";
            this.dtimeUserDate.Size = new System.Drawing.Size(125, 21);
            this.dtimeUserDate.TabIndex = 15;
            // 
            // txtUseRange
            // 
            this.txtUseRange.Location = new System.Drawing.Point(89, 163);
            this.txtUseRange.MaxLength = 50;
            this.txtUseRange.Name = "txtUseRange";
            this.txtUseRange.Size = new System.Drawing.Size(362, 21);
            this.txtUseRange.TabIndex = 13;
            // 
            // dtimeProductionDate
            // 
            this.dtimeProductionDate.Location = new System.Drawing.Point(326, 82);
            this.dtimeProductionDate.Name = "dtimeProductionDate";
            this.dtimeProductionDate.Size = new System.Drawing.Size(125, 21);
            this.dtimeProductionDate.TabIndex = 14;
            // 
            // txtDutyEmployee
            // 
            this.txtDutyEmployee.Location = new System.Drawing.Point(89, 83);
            this.txtDutyEmployee.MaxLength = 10;
            this.txtDutyEmployee.Name = "txtDutyEmployee";
            this.txtDutyEmployee.Size = new System.Drawing.Size(125, 21);
            this.txtDutyEmployee.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "使用期限";
            // 
            // txtModelSpecial
            // 
            this.txtModelSpecial.Location = new System.Drawing.Point(89, 44);
            this.txtModelSpecial.MaxLength = 50;
            this.txtModelSpecial.Name = "txtModelSpecial";
            this.txtModelSpecial.Size = new System.Drawing.Size(362, 21);
            this.txtModelSpecial.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "规  格";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "使用范围";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "责任人";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(257, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "功耗(KW)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(257, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "生产日期";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "重  量(Kg)";
            // 
            // plEqu_BaseInfo
            // 
            this.plEqu_BaseInfo.AddNewStationHeadInfoText = "";
            this.plEqu_BaseInfo.AddNewStationHeadInfoWidth = 76;
            this.plEqu_BaseInfo.AllowMaxHeight = false;
            this.plEqu_BaseInfo.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.plEqu_BaseInfo.BetweenControlCount = 2;
            this.plEqu_BaseInfo.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.plEqu_BaseInfo.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.plEqu_BaseInfo.CaptionTitle = "设备基本信息(必填)";
            this.plEqu_BaseInfo.Controls.Add(this.label1);
            this.plEqu_BaseInfo.Controls.Add(this.label4);
            this.plEqu_BaseInfo.Controls.Add(this.txtRemark);
            this.plEqu_BaseInfo.Controls.Add(this.cmbEquState);
            this.plEqu_BaseInfo.Controls.Add(this.cmbEquType);
            this.plEqu_BaseInfo.Controls.Add(this.txtEquNO);
            this.plEqu_BaseInfo.Controls.Add(this.label7);
            this.plEqu_BaseInfo.Controls.Add(this.label5);
            this.plEqu_BaseInfo.Controls.Add(this.cmbFactoryID);
            this.plEqu_BaseInfo.Controls.Add(this.txtEquName);
            this.plEqu_BaseInfo.Controls.Add(this.cmbDeptID);
            this.plEqu_BaseInfo.Controls.Add(this.label2);
            this.plEqu_BaseInfo.Controls.Add(this.label3);
            this.plEqu_BaseInfo.Controls.Add(this.label6);
            this.plEqu_BaseInfo.DeleteStationButtonText = "";
            this.plEqu_BaseInfo.DeleteStationButtonWidth = 76;
            this.plEqu_BaseInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plEqu_BaseInfo.EditStationInfoText = "";
            this.plEqu_BaseInfo.EditStationInfoWidth = 76;
            this.plEqu_BaseInfo.HorizontalInterval = 8;
            this.plEqu_BaseInfo.IsBorderLine = true;
            this.plEqu_BaseInfo.IsBottomLineColor = false;
            this.plEqu_BaseInfo.IsCaptionSingleColor = true;
            this.plEqu_BaseInfo.IsDragModel = true;
            this.plEqu_BaseInfo.IsLabelStationInfoAlarm = true;
            this.plEqu_BaseInfo.IsmiddleInterval = false;
            this.plEqu_BaseInfo.IsShowAddNewStationHeadInfo = false;
            this.plEqu_BaseInfo.IsShowDeleteStationInfo = false;
            this.plEqu_BaseInfo.IsShowEditStationInfo = false;
            this.plEqu_BaseInfo.IsShowLabelStationInfo = false;
            this.plEqu_BaseInfo.IsShrink = false;
            this.plEqu_BaseInfo.LabelStationInfoForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(47)))), ((int)(((byte)(147)))));
            this.plEqu_BaseInfo.LabelStationInfoLeft = 74;
            this.plEqu_BaseInfo.LabelStationInfoText = "";
            this.plEqu_BaseInfo.LabelStatonInfoWidth = 300;
            this.plEqu_BaseInfo.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.FreeLayoutType;
            this.plEqu_BaseInfo.LeftInterval = 0;
            this.plEqu_BaseInfo.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.plEqu_BaseInfo.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.plEqu_BaseInfo.Location = new System.Drawing.Point(0, 0);
            this.plEqu_BaseInfo.MaxHeight = 22;
            this.plEqu_BaseInfo.MiddleInterval = 80;
            this.plEqu_BaseInfo.Name = "plEqu_BaseInfo";
            this.plEqu_BaseInfo.RightInterval = 0;
            this.plEqu_BaseInfo.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.plEqu_BaseInfo.Size = new System.Drawing.Size(513, 268);
            this.plEqu_BaseInfo.StationAddress = 1;
            this.plEqu_BaseInfo.TabIndex = 0;
            this.plEqu_BaseInfo.TopInterval = 0;
            this.plEqu_BaseInfo.VerticalInterval = 8;
            this.plEqu_BaseInfo.ShiftButtonMouseClick += new System.EventHandler(this.plEqu_BaseInfo_ShiftButtonMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "设备编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "设备类型";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(123, 167);
            this.txtRemark.MaxLength = 100;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(355, 85);
            this.txtRemark.TabIndex = 3;
            // 
            // cmbEquState
            // 
            this.cmbEquState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquState.FormattingEnabled = true;
            this.cmbEquState.Location = new System.Drawing.Point(123, 123);
            this.cmbEquState.Name = "cmbEquState";
            this.cmbEquState.Size = new System.Drawing.Size(118, 20);
            this.cmbEquState.TabIndex = 13;
            // 
            // cmbEquType
            // 
            this.cmbEquType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquType.FormattingEnabled = true;
            this.cmbEquType.Location = new System.Drawing.Point(360, 80);
            this.cmbEquType.Name = "cmbEquType";
            this.cmbEquType.Size = new System.Drawing.Size(118, 20);
            this.cmbEquType.TabIndex = 12;
            // 
            // txtEquNO
            // 
            this.txtEquNO.Location = new System.Drawing.Point(123, 36);
            this.txtEquNO.MaxLength = 10;
            this.txtEquNO.Name = "txtEquNO";
            this.txtEquNO.Size = new System.Drawing.Size(118, 21);
            this.txtEquNO.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "备  注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "设备状态";
            // 
            // cmbFactoryID
            // 
            this.cmbFactoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFactoryID.FormattingEnabled = true;
            this.cmbFactoryID.Location = new System.Drawing.Point(360, 123);
            this.cmbFactoryID.Name = "cmbFactoryID";
            this.cmbFactoryID.Size = new System.Drawing.Size(118, 20);
            this.cmbFactoryID.TabIndex = 14;
            // 
            // txtEquName
            // 
            this.txtEquName.Location = new System.Drawing.Point(360, 36);
            this.txtEquName.MaxLength = 20;
            this.txtEquName.Name = "txtEquName";
            this.txtEquName.Size = new System.Drawing.Size(118, 21);
            this.txtEquName.TabIndex = 2;
            // 
            // cmbDeptID
            // 
            this.cmbDeptID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeptID.FormattingEnabled = true;
            this.cmbDeptID.Location = new System.Drawing.Point(123, 80);
            this.cmbDeptID.Name = "cmbDeptID";
            this.cmbDeptID.Size = new System.Drawing.Size(118, 20);
            this.cmbDeptID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "设备名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "部  门";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "生产厂家";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnCanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 505);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 43);
            this.panel1.TabIndex = 2;
            // 
            // FrmEquEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(513, 548);
            this.Controls.Add(this.vsPanel);
            this.MaximizeBox = false;
            this.Name = "FrmEquEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "FrmEquEdit";
            this.Text = "FrmEquEdit";
            this.vsPanel.ResumeLayout(false);
            this.plEquDetail.ResumeLayout(false);
            this.plEquDetail.PerformLayout();
            this.plEqu_BaseInfo.ResumeLayout(false);
            this.plEqu_BaseInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KJ128WindowsLibrary.StationMakeupVspanel plEqu_BaseInfo;
        private System.Windows.Forms.ComboBox cmbDeptID;
        private System.Windows.Forms.TextBox txtEquName;
        private System.Windows.Forms.TextBox txtEquNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.ComboBox cmbEquState;
        private System.Windows.Forms.ComboBox cmbEquType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFactoryID;
        private KJ128WindowsLibrary.VSPanel vsPanel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCanel;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Panel panel1;
        private KJ128WindowsLibrary.StationMakeupVspanel plEquDetail;
        private KJ128N.Command.TxtNumber txtEquPower;
        private KJ128N.Command.TxtNumber txtEquHeight;
        private System.Windows.Forms.DateTimePicker dtimeUserDate;
        private System.Windows.Forms.TextBox txtUseRange;
        private System.Windows.Forms.DateTimePicker dtimeProductionDate;
        private System.Windows.Forms.TextBox txtDutyEmployee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtModelSpecial;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}