namespace KJ128NMainRun.A_StationConfigInfo
{
    partial class A_FrmStationConfigInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.pnlStation = new System.Windows.Forms.Panel();
            this.tvStation = new DegonControlLib.TreeViewControl();
            this.btnStation = new System.Windows.Forms.Button();
            this.pnlStationHead = new System.Windows.Forms.Panel();
            this.btnStationHead = new System.Windows.Forms.Button();
            this.lblPlace = new System.Windows.Forms.Label();
            this.txtPlace = new Shine.ShineTextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.timer_Alarm = new System.Windows.Forms.Timer(this.components);
            this.chb = new System.Windows.Forms.CheckBox();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.pnlStation.SuspendLayout();
            this.pnlStationHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.chb);
            this.panelLeftBottom.Controls.Add(this.btnClear);
            this.panelLeftBottom.Controls.Add(this.btnQuery);
            this.panelLeftBottom.Controls.Add(this.txtPlace);
            this.panelLeftBottom.Controls.Add(this.lblPlace);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 404);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 119);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 404);
            // 
            // btnAdd
            // 
            this.btnAdd.Visible = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Size = new System.Drawing.Size(77, 12);
            this.lblMainTitle.Text = "分站状态信息";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Visible = false;
            // 
            // btnLaws
            // 
            this.btnLaws.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblSumPage
            // 
            this.lblSumPage.Visible = false;
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.Visible = false;
            // 
            // label8
            // 
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.Visible = false;
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.Visible = false;
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // label6
            // 
            this.label6.Visible = false;
            // 
            // lblPageCounts
            // 
            this.lblPageCounts.Visible = false;
            // 
            // btnDownPage
            // 
            this.btnDownPage.Visible = false;
            // 
            // btnUpPage
            // 
            this.btnUpPage.Visible = false;
            // 
            // label9
            // 
            this.label9.Visible = false;
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.pnlStationHead);
            this.panelMainMain.Controls.Add(this.pnlStation);
            this.panelMainMain.Controls.Add(this.dgvMain);
            // 
            // btnConfigModel
            // 
            this.btnConfigModel.Click += new System.EventHandler(this.btnConfigModel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(783, 459);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMain_ColumnHeaderMouseClick);
            this.dgvMain.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            this.dgvMain.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMain_DataBindingComplete);
            // 
            // pnlStation
            // 
            this.pnlStation.Controls.Add(this.tvStation);
            this.pnlStation.Controls.Add(this.btnStation);
            this.pnlStation.Location = new System.Drawing.Point(139, 92);
            this.pnlStation.Name = "pnlStation";
            this.pnlStation.Size = new System.Drawing.Size(205, 215);
            this.pnlStation.TabIndex = 1;
            // 
            // tvStation
            // 
            this.tvStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStation.Location = new System.Drawing.Point(0, 25);
            this.tvStation.Name = "tvStation";
            this.tvStation.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvStation.Size = new System.Drawing.Size(205, 190);
            this.tvStation.TabIndex = 1;
            this.tvStation.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStation_AfterSelect);
            // 
            // btnStation
            // 
            this.btnStation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStation.Location = new System.Drawing.Point(0, 0);
            this.btnStation.Name = "btnStation";
            this.btnStation.Size = new System.Drawing.Size(205, 25);
            this.btnStation.TabIndex = 0;
            this.btnStation.Text = "传输分站";
            this.btnStation.UseVisualStyleBackColor = true;
            this.btnStation.Click += new System.EventHandler(this.btnStation_Click);
            // 
            // pnlStationHead
            // 
            this.pnlStationHead.Controls.Add(this.btnStationHead);
            this.pnlStationHead.Location = new System.Drawing.Point(376, 92);
            this.pnlStationHead.Name = "pnlStationHead";
            this.pnlStationHead.Size = new System.Drawing.Size(205, 215);
            this.pnlStationHead.TabIndex = 2;
            // 
            // btnStationHead
            // 
            this.btnStationHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStationHead.Location = new System.Drawing.Point(0, 0);
            this.btnStationHead.Name = "btnStationHead";
            this.btnStationHead.Size = new System.Drawing.Size(205, 25);
            this.btnStationHead.TabIndex = 0;
            this.btnStationHead.Text = "读卡分站";
            this.btnStationHead.UseVisualStyleBackColor = true;
            this.btnStationHead.Click += new System.EventHandler(this.btnStationHead_Click);
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(13, 22);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(65, 12);
            this.lblPlace.TabIndex = 0;
            this.lblPlace.Text = "安装位置：";
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(78, 16);
            this.txtPlace.MaxLength = 30;
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(100, 21);
            this.txtPlace.TabIndex = 1;
            this.txtPlace.TextType = Shine.TextType.WithOutChar;
            this.txtPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlace_KeyPress);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(25, 56);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(53, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(110, 56);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "重置";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // timer_Alarm
            // 
            this.timer_Alarm.Interval = 3000;
            this.timer_Alarm.Tick += new System.EventHandler(this.timer_Alarm_Tick);
            // 
            // chb
            // 
            this.chb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chb.AutoSize = true;
            this.chb.Checked = true;
            this.chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb.Location = new System.Drawing.Point(15, 93);
            this.chb.Name = "chb";
            this.chb.Size = new System.Drawing.Size(96, 16);
            this.chb.TabIndex = 4;
            this.chb.Text = "实时更新数据";
            this.chb.UseVisualStyleBackColor = true;
            // 
            // A_FrmStationConfigInfo
            // 
            this.AcceptButton = this.btnQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_FrmStationConfigInfo";
            this.TabText = "实时分站状态";
            this.Text = "实时分站状态";
            this.Load += new System.EventHandler(this.A_FrmStationConfigInfo_Load);
            this.Activated += new System.EventHandler(this.A_FrmStationConfigInfo_Activated);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            this.panelLeftBottom.PerformLayout();
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.panelMainMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.pnlStation.ResumeLayout(false);
            this.pnlStationHead.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel pnlStation;
        private System.Windows.Forms.Button btnStation;
        private System.Windows.Forms.Panel pnlStationHead;
        private System.Windows.Forms.Button btnStationHead;
        
        private DegonControlLib.TreeViewControl tvStation;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnClear;
        private Shine.ShineTextBox txtPlace;
        private System.Windows.Forms.Timer timer_Alarm;
        private System.Windows.Forms.CheckBox chb;
    }
}