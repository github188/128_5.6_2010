namespace KJ128NMainRun.RealTime
{
    partial class FrmWorkPlace
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
            this.vsPanel1 = new KJ128WindowsLibrary.VSPanel();
            this.chk = new System.Windows.Forms.CheckBox();
            this.btnCancel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.gbx_Emp = new System.Windows.Forms.GroupBox();
            this.textBox1 = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCard = new KJ128N.Command.TxtNumber();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new Shine.ShineTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSearch = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeInfo = new KJ128WindowsLibrary.TreeViewDepartment();
            this.vsPanel1.SuspendLayout();
            this.gbx_Emp.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // vsPanel1
            // 
            this.vsPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.vsPanel1.BackLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.vsPanel1.BetweenControlCount = 2;
            this.vsPanel1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.vsPanel1.BottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.vsPanel1.Controls.Add(this.chk);
            this.vsPanel1.Controls.Add(this.btnCancel);
            this.vsPanel1.Controls.Add(this.gbx_Emp);
            this.vsPanel1.Controls.Add(this.btnSearch);
            this.vsPanel1.Controls.Add(this.groupBox2);
            this.vsPanel1.Controls.Add(this.groupBox3);
            this.vsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.vsPanel1.HorizontalInterval = 8;
            this.vsPanel1.IsBorderLine = true;
            this.vsPanel1.IsBottomLineColor = false;
            this.vsPanel1.IsCaptionSingleColor = true;
            this.vsPanel1.IsDragModel = false;
            this.vsPanel1.IsmiddleInterval = false;
            this.vsPanel1.LayoutType = KJ128WindowsLibrary.VSPanelLayoutType.FreeLayoutType;
            this.vsPanel1.LeftInterval = 0;
            this.vsPanel1.LinearGradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.vsPanel1.LinearGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.vsPanel1.Location = new System.Drawing.Point(0, 0);
            this.vsPanel1.MiddleInterval = 80;
            this.vsPanel1.Name = "vsPanel1";
            this.vsPanel1.RightInterval = 0;
            this.vsPanel1.SetBackGroundStyle = KJ128WindowsLibrary.VsPaneBackGroundStyle.windowsStyle;
            this.vsPanel1.Size = new System.Drawing.Size(1028, 138);
            this.vsPanel1.TabIndex = 19;
            this.vsPanel1.TopInterval = 0;
            this.vsPanel1.VerticalInterval = 8;
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.Location = new System.Drawing.Point(24, 110);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(96, 16);
            this.chk.TabIndex = 19;
            this.chk.Text = "实时更新数据";
            this.chk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnCancel.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnCancel.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnCancel.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnCancel.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnCancel.CaptionBottomLineWidth = 1;
            this.btnCancel.CaptionCloseButtonControlLeft = 2;
            this.btnCancel.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.CaptionCloseButtonTitle = "×";
            this.btnCancel.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.CaptionHeight = 20;
            this.btnCancel.CaptionLeft = 1;
            this.btnCancel.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancel.CaptionTitle = "重置";
            this.btnCancel.CaptionTitleLeft = 12;
            this.btnCancel.CaptionTitleTop = 4;
            this.btnCancel.CaptionTop = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.IsBorderLine = true;
            this.btnCancel.IsCaptionSingleColor = false;
            this.btnCancel.IsOnlyCaption = true;
            this.btnCancel.IsPanelImage = true;
            this.btnCancel.IsUserButtonClose = false;
            this.btnCancel.IsUserCaptionBottomLine = false;
            this.btnCancel.IsUserSystemCloseButtonLeft = true;
            this.btnCancel.Location = new System.Drawing.Point(901, 85);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PanelImage = null;
            this.btnCancel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnCancel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnCancel.Size = new System.Drawing.Size(61, 22);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // gbx_Emp
            // 
            this.gbx_Emp.Controls.Add(this.textBox1);
            this.gbx_Emp.Controls.Add(this.label2);
            this.gbx_Emp.Controls.Add(this.dateTimePicker1);
            this.gbx_Emp.Controls.Add(this.label1);
            this.gbx_Emp.Controls.Add(this.txtCard);
            this.gbx_Emp.Controls.Add(this.label8);
            this.gbx_Emp.Controls.Add(this.txtName);
            this.gbx_Emp.Controls.Add(this.label10);
            this.gbx_Emp.Location = new System.Drawing.Point(258, 13);
            this.gbx_Emp.Name = "gbx_Emp";
            this.gbx_Emp.Size = new System.Drawing.Size(384, 110);
            this.gbx_Emp.TabIndex = 18;
            this.gbx_Emp.TabStop = false;
            this.gbx_Emp.Text = "分类查询";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 76);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextType = Shine.TextType.WithOutChar;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "身份证号：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(276, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(73, 21);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "出生年月：";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(89, 43);
            this.txtCard.MaxLength = 38;
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(91, 21);
            this.txtCard.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "发码器编号：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 16);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(91, 21);
            this.txtName.TabIndex = 1;
            this.txtName.TextType = Shine.TextType.WithOutChar;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "姓名：";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.btnSearch.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.btnSearch.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnSearch.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnSearch.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btnSearch.CaptionBottomLineWidth = 1;
            this.btnSearch.CaptionCloseButtonControlLeft = 2;
            this.btnSearch.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.CaptionCloseButtonTitle = "×";
            this.btnSearch.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.CaptionHeight = 20;
            this.btnSearch.CaptionLeft = 1;
            this.btnSearch.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSearch.CaptionTitle = "查询";
            this.btnSearch.CaptionTitleLeft = 12;
            this.btnSearch.CaptionTitleTop = 4;
            this.btnSearch.CaptionTop = 1;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.IsBorderLine = true;
            this.btnSearch.IsCaptionSingleColor = false;
            this.btnSearch.IsOnlyCaption = true;
            this.btnSearch.IsPanelImage = true;
            this.btnSearch.IsUserButtonClose = false;
            this.btnSearch.IsUserCaptionBottomLine = false;
            this.btnSearch.IsUserSystemCloseButtonLeft = true;
            this.btnSearch.Location = new System.Drawing.Point(901, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PanelImage = null;
            this.btnSearch.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.btnSearch.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.btnSearch.Size = new System.Drawing.Size(61, 22);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtEndTime);
            this.groupBox2.Controls.Add(this.dtStartTime);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 84);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "监测时间范围";
            // 
            // dtEndTime
            // 
            this.dtEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(68, 48);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(139, 21);
            this.dtEndTime.TabIndex = 5;
            // 
            // dtStartTime
            // 
            this.dtStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTime.Location = new System.Drawing.Point(68, 17);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(139, 21);
            this.dtStartTime.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "结束时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "开始时间：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeInfo);
            this.groupBox3.Location = new System.Drawing.Point(648, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 112);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择部门";
            // 
            // treeInfo
            // 
            this.treeInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.treeInfo.Location = new System.Drawing.Point(9, 16);
            this.treeInfo.Name = "treeInfo";
            this.treeInfo.Size = new System.Drawing.Size(161, 87);
            this.treeInfo.TabIndex = 12;
            // 
            // FrmWorkPlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 684);
            this.Controls.Add(this.vsPanel1);
            this.Name = "FrmWorkPlace";
            this.Text = "实时班组信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.vsPanel1.ResumeLayout(false);
            this.vsPanel1.PerformLayout();
            this.gbx_Emp.ResumeLayout(false);
            this.gbx_Emp.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KJ128WindowsLibrary.VSPanel vsPanel1;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.GroupBox gbx_Emp;
        private KJ128N.Command.TxtNumber txtCard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private KJ128WindowsLibrary.TreeViewDepartment treeInfo;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnCancel;
        private KJ128WindowsLibrary.ButtonCaptionPanel btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Shine.ShineTextBox txtName;
        private Shine.ShineTextBox textBox1;
    }
}