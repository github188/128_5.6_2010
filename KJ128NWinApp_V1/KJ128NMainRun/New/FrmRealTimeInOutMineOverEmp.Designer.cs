namespace KJ128NMainRun.New
{
    partial class FrmRealTimeInOutMineOverEmp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRealTimeInOutMineOverEmp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvMain = new KJ128NInterfaceShow.DataGridViewKJ128();
            this.cpStationToExcel = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.sxpPanelGroup1 = new Wilson.Controls.XPPanel.Images.SXPPanelGroup();
            this.sxpPanel2 = new Wilson.Controls.XPPanel.SXPPanel();
            this.bcpSelect = new KJ128WindowsLibrary.ButtonCaptionPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpName = new Shine.ShineTextBox();
            this.txtCodeSender = new Shine.ShineTextBox();
            this.shineTextBox3 = new Shine.ShineTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).BeginInit();
            this.sxpPanelGroup1.SuspendLayout();
            this.sxpPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(243, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 36);
            this.panel1.TabIndex = 129;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.ColumnHeadersHeight = 32;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMain.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.BlueStyle;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(191)))), ((int)(((byte)(219)))));
            this.dgvMain.Location = new System.Drawing.Point(243, 36);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(750, 492);
            this.dgvMain.TabIndex = 128;
            this.dgvMain.VerticalScrollBarMax = 1;
            this.dgvMain.VerticalScrollBarValue = 0;
            // 
            // cpStationToExcel
            // 
            this.cpStationToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpStationToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpStationToExcel.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.cpStationToExcel.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.cpStationToExcel.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.cpStationToExcel.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.cpStationToExcel.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cpStationToExcel.CaptionBottomLineWidth = 1;
            this.cpStationToExcel.CaptionCloseButtonControlLeft = 2;
            this.cpStationToExcel.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cpStationToExcel.CaptionCloseButtonTitle = "×";
            this.cpStationToExcel.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpStationToExcel.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cpStationToExcel.CaptionHeight = 20;
            this.cpStationToExcel.CaptionLeft = 1;
            this.cpStationToExcel.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.cpStationToExcel.CaptionTitle = " 打  印";
            this.cpStationToExcel.CaptionTitleLeft = 10;
            this.cpStationToExcel.CaptionTitleTop = 4;
            this.cpStationToExcel.CaptionTop = 1;
            this.cpStationToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpStationToExcel.IsBorderLine = true;
            this.cpStationToExcel.IsCaptionSingleColor = false;
            this.cpStationToExcel.IsOnlyCaption = true;
            this.cpStationToExcel.IsPanelImage = true;
            this.cpStationToExcel.IsUserButtonClose = false;
            this.cpStationToExcel.IsUserCaptionBottomLine = false;
            this.cpStationToExcel.IsUserSystemCloseButtonLeft = true;
            this.cpStationToExcel.Location = new System.Drawing.Point(865, 5);
            this.cpStationToExcel.Name = "cpStationToExcel";
            this.cpStationToExcel.PanelImage = null;
            this.cpStationToExcel.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.cpStationToExcel.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.cpStationToExcel.Size = new System.Drawing.Size(91, 22);
            this.cpStationToExcel.TabIndex = 127;
            this.cpStationToExcel.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // sxpPanelGroup1
            // 
            this.sxpPanelGroup1.AutoScroll = true;
            this.sxpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanelGroup1.Controls.Add(this.sxpPanel2);
            this.sxpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sxpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.sxpPanelGroup1.Name = "sxpPanelGroup1";
            this.sxpPanelGroup1.PanelGradient = ((Wilson.Controls.XPPanel.Colors.GradientColor)(resources.GetObject("sxpPanelGroup1.PanelGradient")));
            this.sxpPanelGroup1.Size = new System.Drawing.Size(243, 528);
            this.sxpPanelGroup1.TabIndex = 126;
            // 
            // sxpPanel2
            // 
            this.sxpPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sxpPanel2.BackColor = System.Drawing.Color.Transparent;
            this.sxpPanel2.Caption = "查询条件";
            this.sxpPanel2.CaptionCornerType = ((Wilson.Controls.XPPanel.Enums.CornerType)((Wilson.Controls.XPPanel.Enums.CornerType.TopLeft | Wilson.Controls.XPPanel.Enums.CornerType.TopRight)));
            this.sxpPanel2.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.sxpPanel2.CaptionGradient.Start = System.Drawing.Color.White;
            this.sxpPanel2.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sxpPanel2.Controls.Add(this.shineTextBox3);
            this.sxpPanel2.Controls.Add(this.txtCodeSender);
            this.sxpPanel2.Controls.Add(this.txtEmpName);
            this.sxpPanel2.Controls.Add(this.label4);
            this.sxpPanel2.Controls.Add(this.label2);
            this.sxpPanel2.Controls.Add(this.label1);
            this.sxpPanel2.Controls.Add(this.bcpSelect);
            this.sxpPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sxpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sxpPanel2.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.sxpPanel2.ImageItems.ImageSet = null;
            this.sxpPanel2.ImageItems.Normal = -1;
            this.sxpPanel2.Location = new System.Drawing.Point(8, 8);
            this.sxpPanel2.Name = "sxpPanel2";
            this.sxpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.sxpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.sxpPanel2.Size = new System.Drawing.Size(227, 152);
            this.sxpPanel2.TabIndex = 1;
            this.sxpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.sxpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.sxpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            this.sxpPanel2.XPPanelStyle = Wilson.Controls.XPPanel.Enums.XPPanelStyle.WindowsXP;
            // 
            // bcpSelect
            // 
            this.bcpSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bcpSelect.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(153)))), ((int)(((byte)(199)))));
            this.bcpSelect.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(233)))));
            this.bcpSelect.CaptionBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.bcpSelect.CaptionBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.bcpSelect.CaptionBottomLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bcpSelect.CaptionBottomLineWidth = 1;
            this.bcpSelect.CaptionCloseButtonControlLeft = 2;
            this.bcpSelect.CaptionCloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bcpSelect.CaptionCloseButtonTitle = "×";
            this.bcpSelect.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcpSelect.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bcpSelect.CaptionHeight = 20;
            this.bcpSelect.CaptionLeft = 1;
            this.bcpSelect.CaptionPanelLineMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcpSelect.CaptionTitle = "查 询";
            this.bcpSelect.CaptionTitleLeft = 8;
            this.bcpSelect.CaptionTitleTop = 4;
            this.bcpSelect.CaptionTop = 1;
            this.bcpSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcpSelect.IsBorderLine = true;
            this.bcpSelect.IsCaptionSingleColor = false;
            this.bcpSelect.IsOnlyCaption = true;
            this.bcpSelect.IsPanelImage = true;
            this.bcpSelect.IsUserButtonClose = false;
            this.bcpSelect.IsUserCaptionBottomLine = false;
            this.bcpSelect.IsUserSystemCloseButtonLeft = true;
            this.bcpSelect.Location = new System.Drawing.Point(151, 118);
            this.bcpSelect.Name = "bcpSelect";
            this.bcpSelect.PanelImage = null;
            this.bcpSelect.SetButtonStyle = KJ128WindowsLibrary.ButtonCaptionPanelButtonStyle.Office2003Style;
            this.bcpSelect.SetCaptionPanelStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.windowsStyle;
            this.bcpSelect.Size = new System.Drawing.Size(60, 22);
            this.bcpSelect.TabIndex = 5;
            this.bcpSelect.UnEnableStyle = KJ128WindowsLibrary.CaptionPanelStyleEnum.UnEnableWindowsStyle;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 3000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 130;
            this.label1.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 131;
            this.label2.Text = "标识卡编号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "部门：";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(90, 42);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(121, 20);
            this.txtEmpName.TabIndex = 135;
            this.txtEmpName.TextType = Shine.TextType.WithOutChar;
            // 
            // txtCodeSender
            // 
            this.txtCodeSender.Location = new System.Drawing.Point(90, 67);
            this.txtCodeSender.Name = "txtCodeSender";
            this.txtCodeSender.Size = new System.Drawing.Size(121, 20);
            this.txtCodeSender.TabIndex = 136;
            this.txtCodeSender.TextType = Shine.TextType.Number;
            // 
            // shineTextBox3
            // 
            this.shineTextBox3.Location = new System.Drawing.Point(90, 92);
            this.shineTextBox3.Name = "shineTextBox3";
            this.shineTextBox3.Size = new System.Drawing.Size(121, 20);
            this.shineTextBox3.TabIndex = 137;
            this.shineTextBox3.TextType = Shine.TextType.WithOutChar;
            // 
            // FrmRealTimeInOutMineOverEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 528);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cpStationToExcel);
            this.Controls.Add(this.sxpPanelGroup1);
            this.Name = "FrmRealTimeInOutMineOverEmp";
            this.Text = "实时上下井超员信息";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sxpPanelGroup1)).EndInit();
            this.sxpPanelGroup1.ResumeLayout(false);
            this.sxpPanel2.ResumeLayout(false);
            this.sxpPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KJ128NInterfaceShow.DataGridViewKJ128 dgvMain;
        private KJ128WindowsLibrary.ButtonCaptionPanel cpStationToExcel;
        private Wilson.Controls.XPPanel.Images.SXPPanelGroup sxpPanelGroup1;
        private Wilson.Controls.XPPanel.SXPPanel sxpPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private KJ128WindowsLibrary.ButtonCaptionPanel bcpSelect;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label4;
        private Shine.ShineTextBox shineTextBox3;
        private Shine.ShineTextBox txtCodeSender;
        private Shine.ShineTextBox txtEmpName;
    }
}