namespace KJ128NMainRun.Graphics
{
    partial class FrmHistroyRoute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistroyRoute));
            this.pnlInOut = new System.Windows.Forms.Panel();
            this.labColor = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.picInOut = new System.Windows.Forms.PictureBox();
            this.tbcControl = new System.Windows.Forms.TabControl();
            this.tbpTimeSearch = new System.Windows.Forms.TabPage();
            this.lsbSelectPeople = new KJ128WindowsLibrary.ZzhaListBox();
            this.lsbPeople = new KJ128WindowsLibrary.ZzhaListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.tbpBan = new System.Windows.Forms.TabPage();
            this.lsbBanSelectpeople = new KJ128WindowsLibrary.ZzhaListBox();
            this.lsbBanPeople = new KJ128WindowsLibrary.ZzhaListBox();
            this.btnBanremove = new System.Windows.Forms.Button();
            this.btnBanselect = new System.Windows.Forms.Button();
            this.cmbBan = new System.Windows.Forms.ComboBox();
            this.cmbBanDept = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpban = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnHistoryRoute = new System.Windows.Forms.Button();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MapGis = new ZzhaControlLibrary.ZzhaMapGis();
            this.pnlInOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInOut)).BeginInit();
            this.tbcControl.SuspendLayout();
            this.tbpTimeSearch.SuspendLayout();
            this.tbpBan.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInOut
            // 
            this.pnlInOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlInOut.BackgroundImage = global::KJ128NMainRun.Properties.Resources.ffrm;
            this.pnlInOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInOut.Controls.Add(this.labColor);
            this.pnlInOut.Controls.Add(this.label8);
            this.pnlInOut.Controls.Add(this.btnStop);
            this.pnlInOut.Controls.Add(this.picInOut);
            this.pnlInOut.Controls.Add(this.tbcControl);
            this.pnlInOut.Controls.Add(this.btnHistoryRoute);
            this.pnlInOut.Controls.Add(this.cmbSpeed);
            this.pnlInOut.Controls.Add(this.label4);
            this.pnlInOut.Location = new System.Drawing.Point(-241, 31);
            this.pnlInOut.Name = "pnlInOut";
            this.pnlInOut.Size = new System.Drawing.Size(270, 462);
            this.pnlInOut.TabIndex = 1;
            // 
            // labColor
            // 
            this.labColor.BackColor = System.Drawing.Color.Red;
            this.labColor.Location = new System.Drawing.Point(185, 409);
            this.labColor.Name = "labColor";
            this.labColor.Size = new System.Drawing.Size(49, 19);
            this.labColor.TabIndex = 16;
            this.labColor.Click += new System.EventHandler(this.labColor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(126, 413);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "字体颜色";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(33, 433);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(63, 23);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // picInOut
            // 
            this.picInOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picInOut.BackColor = System.Drawing.Color.White;
            this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.right;
            this.picInOut.Location = new System.Drawing.Point(240, 13);
            this.picInOut.Name = "picInOut";
            this.picInOut.Size = new System.Drawing.Size(24, 434);
            this.picInOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picInOut.TabIndex = 13;
            this.picInOut.TabStop = false;
            this.picInOut.Click += new System.EventHandler(this.picInOut_Click);
            // 
            // tbcControl
            // 
            this.tbcControl.Controls.Add(this.tbpTimeSearch);
            this.tbcControl.Controls.Add(this.tbpBan);
            this.tbcControl.Location = new System.Drawing.Point(3, 6);
            this.tbcControl.Name = "tbcControl";
            this.tbcControl.SelectedIndex = 0;
            this.tbcControl.Size = new System.Drawing.Size(241, 398);
            this.tbcControl.TabIndex = 1;
            this.tbcControl.SelectedIndexChanged += new System.EventHandler(this.tbcControl_SelectedIndexChanged);
            // 
            // tbpTimeSearch
            // 
            this.tbpTimeSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.tbpTimeSearch.Controls.Add(this.lsbSelectPeople);
            this.tbpTimeSearch.Controls.Add(this.lsbPeople);
            this.tbpTimeSearch.Controls.Add(this.btnRemove);
            this.tbpTimeSearch.Controls.Add(this.btnSelect);
            this.tbpTimeSearch.Controls.Add(this.label3);
            this.tbpTimeSearch.Controls.Add(this.cmbDept);
            this.tbpTimeSearch.Controls.Add(this.label2);
            this.tbpTimeSearch.Controls.Add(this.dtpEnd);
            this.tbpTimeSearch.Controls.Add(this.label1);
            this.tbpTimeSearch.Controls.Add(this.dtpStart);
            this.tbpTimeSearch.Location = new System.Drawing.Point(4, 21);
            this.tbpTimeSearch.Name = "tbpTimeSearch";
            this.tbpTimeSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTimeSearch.Size = new System.Drawing.Size(233, 373);
            this.tbpTimeSearch.TabIndex = 0;
            this.tbpTimeSearch.Text = "时间查询";
            // 
            // lsbSelectPeople
            // 
            this.lsbSelectPeople.FormattingEnabled = true;
            this.lsbSelectPeople.ItemHeight = 12;
            this.lsbSelectPeople.Location = new System.Drawing.Point(134, 95);
            this.lsbSelectPeople.Name = "lsbSelectPeople";
            this.lsbSelectPeople.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbSelectPeople.Size = new System.Drawing.Size(93, 268);
            this.lsbSelectPeople.TabIndex = 12;
            this.lsbSelectPeople.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbSelectPeople.Values")));
            // 
            // lsbPeople
            // 
            this.lsbPeople.FormattingEnabled = true;
            this.lsbPeople.ItemHeight = 12;
            this.lsbPeople.Location = new System.Drawing.Point(6, 95);
            this.lsbPeople.Name = "lsbPeople";
            this.lsbPeople.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbPeople.Size = new System.Drawing.Size(99, 268);
            this.lsbPeople.TabIndex = 11;
            this.lsbPeople.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbPeople.Values")));
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(106, 240);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(27, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(106, 183);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(27, 23);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = ">";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "已选择人员";
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(6, 69);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(99, 20);
            this.cmbDept.TabIndex = 4;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束时间";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(77, 42);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(150, 21);
            this.dtpEnd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "起始时间";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(77, 8);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(150, 21);
            this.dtpStart.TabIndex = 0;
            // 
            // tbpBan
            // 
            this.tbpBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.tbpBan.Controls.Add(this.lsbBanSelectpeople);
            this.tbpBan.Controls.Add(this.lsbBanPeople);
            this.tbpBan.Controls.Add(this.btnBanremove);
            this.tbpBan.Controls.Add(this.btnBanselect);
            this.tbpBan.Controls.Add(this.cmbBan);
            this.tbpBan.Controls.Add(this.cmbBanDept);
            this.tbpBan.Controls.Add(this.label7);
            this.tbpBan.Controls.Add(this.label6);
            this.tbpBan.Controls.Add(this.dtpban);
            this.tbpBan.Controls.Add(this.label5);
            this.tbpBan.Location = new System.Drawing.Point(4, 21);
            this.tbpBan.Name = "tbpBan";
            this.tbpBan.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBan.Size = new System.Drawing.Size(233, 373);
            this.tbpBan.TabIndex = 1;
            this.tbpBan.Text = "班次查询";
            // 
            // lsbBanSelectpeople
            // 
            this.lsbBanSelectpeople.FormattingEnabled = true;
            this.lsbBanSelectpeople.ItemHeight = 12;
            this.lsbBanSelectpeople.Location = new System.Drawing.Point(133, 96);
            this.lsbBanSelectpeople.Name = "lsbBanSelectpeople";
            this.lsbBanSelectpeople.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbBanSelectpeople.Size = new System.Drawing.Size(97, 268);
            this.lsbBanSelectpeople.TabIndex = 16;
            this.lsbBanSelectpeople.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbBanSelectpeople.Values")));
            // 
            // lsbBanPeople
            // 
            this.lsbBanPeople.FormattingEnabled = true;
            this.lsbBanPeople.ItemHeight = 12;
            this.lsbBanPeople.Location = new System.Drawing.Point(6, 96);
            this.lsbBanPeople.Name = "lsbBanPeople";
            this.lsbBanPeople.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbBanPeople.Size = new System.Drawing.Size(99, 268);
            this.lsbBanPeople.TabIndex = 15;
            this.lsbBanPeople.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbBanPeople.Values")));
            // 
            // btnBanremove
            // 
            this.btnBanremove.Location = new System.Drawing.Point(106, 241);
            this.btnBanremove.Name = "btnBanremove";
            this.btnBanremove.Size = new System.Drawing.Size(27, 23);
            this.btnBanremove.TabIndex = 14;
            this.btnBanremove.Text = "<";
            this.btnBanremove.UseVisualStyleBackColor = true;
            this.btnBanremove.Click += new System.EventHandler(this.btnBanremove_Click);
            // 
            // btnBanselect
            // 
            this.btnBanselect.Location = new System.Drawing.Point(106, 184);
            this.btnBanselect.Name = "btnBanselect";
            this.btnBanselect.Size = new System.Drawing.Size(27, 23);
            this.btnBanselect.TabIndex = 13;
            this.btnBanselect.Text = ">";
            this.btnBanselect.UseVisualStyleBackColor = true;
            this.btnBanselect.Click += new System.EventHandler(this.btnBanselect_Click);
            // 
            // cmbBan
            // 
            this.cmbBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBan.FormattingEnabled = true;
            this.cmbBan.Location = new System.Drawing.Point(53, 70);
            this.cmbBan.Name = "cmbBan";
            this.cmbBan.Size = new System.Drawing.Size(104, 20);
            this.cmbBan.TabIndex = 5;
            this.cmbBan.SelectedIndexChanged += new System.EventHandler(this.cmbBan_SelectedIndexChanged);
            // 
            // cmbBanDept
            // 
            this.cmbBanDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanDept.FormattingEnabled = true;
            this.cmbBanDept.Location = new System.Drawing.Point(53, 41);
            this.cmbBanDept.Name = "cmbBanDept";
            this.cmbBanDept.Size = new System.Drawing.Size(104, 20);
            this.cmbBanDept.TabIndex = 4;
            this.cmbBanDept.SelectedIndexChanged += new System.EventHandler(this.cmbBanDept_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "班次:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "部门:";
            // 
            // dtpban
            // 
            this.dtpban.Location = new System.Drawing.Point(53, 10);
            this.dtpban.Name = "dtpban";
            this.dtpban.Size = new System.Drawing.Size(163, 21);
            this.dtpban.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "时间:";
            // 
            // btnHistoryRoute
            // 
            this.btnHistoryRoute.Location = new System.Drawing.Point(141, 433);
            this.btnHistoryRoute.Name = "btnHistoryRoute";
            this.btnHistoryRoute.Size = new System.Drawing.Size(63, 23);
            this.btnHistoryRoute.TabIndex = 12;
            this.btnHistoryRoute.Text = "历史轨迹";
            this.btnHistoryRoute.UseVisualStyleBackColor = true;
            this.btnHistoryRoute.Click += new System.EventHandler(this.btnHistoryRoute_Click);
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbSpeed.Location = new System.Drawing.Point(60, 409);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(50, 20);
            this.cmbSpeed.TabIndex = 11;
            this.cmbSpeed.SelectedIndexChanged += new System.EventHandler(this.cmbSpeed_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "行走速度";
            // 
            // MapGis
            // 
            this.MapGis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MapGis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapGis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapGis.IsMoving = false;
            this.MapGis.IsStationChangeed = false;
            this.MapGis.Location = new System.Drawing.Point(0, 0);
            this.MapGis.MapFilePath = null;
            this.MapGis.MaxWidth = 35000;
            this.MapGis.MinWidth = 500;
            this.MapGis.MoverStrColor = System.Drawing.Color.Red;
            this.MapGis.Name = "MapGis";
            this.MapGis.ShowStationOther = false;
            this.MapGis.Size = new System.Drawing.Size(741, 520);
            this.MapGis.StationFilePath = null;
            this.MapGis.StationStrColor = System.Drawing.Color.Red;
            this.MapGis.TabIndex = 0;
            this.MapGis.UseDiv = false;
            this.MapGis.UseGif = true;
            // 
            // FrmHistroyRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 520);
            this.Controls.Add(this.pnlInOut);
            this.Controls.Add(this.MapGis);
            this.Name = "FrmHistroyRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "历史轨迹回放";
            this.Text = "历史轨迹回放";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmHistroyRoute_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHistroyRoute_FormClosing);
            this.pnlInOut.ResumeLayout(false);
            this.pnlInOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInOut)).EndInit();
            this.tbcControl.ResumeLayout(false);
            this.tbpTimeSearch.ResumeLayout(false);
            this.tbpTimeSearch.PerformLayout();
            this.tbpBan.ResumeLayout(false);
            this.tbpBan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZzhaControlLibrary.ZzhaMapGis MapGis;
        private System.Windows.Forms.Panel pnlInOut;
        private System.Windows.Forms.TabControl tbcControl;
        private System.Windows.Forms.TabPage tbpTimeSearch;
        private System.Windows.Forms.TabPage tbpBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHistoryRoute;
        private System.Windows.Forms.ComboBox cmbSpeed;
        private System.Windows.Forms.ComboBox cmbBan;
        private System.Windows.Forms.ComboBox cmbBanDept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpban;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBanremove;
        private System.Windows.Forms.Button btnBanselect;
        private KJ128WindowsLibrary.ZzhaListBox lsbPeople;
        private KJ128WindowsLibrary.ZzhaListBox lsbSelectPeople;
        private KJ128WindowsLibrary.ZzhaListBox lsbBanPeople;
        private KJ128WindowsLibrary.ZzhaListBox lsbBanSelectpeople;
        private System.Windows.Forms.PictureBox picInOut;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labColor;
    }
}