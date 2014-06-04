namespace KJ128NInterfaceShow
{
    partial class AttendanceDayByDayStatistic
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ddlDept = new System.Windows.Forms.ComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgrd = new KJ128NInterfaceShow.DataGridViewMultiHeaders();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Size = new System.Drawing.Size(200, 588);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(839, 588);
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 308);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 280);
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelMainBottom.Location = new System.Drawing.Point(0, 554);
            this.panelMainBottom.Size = new System.Drawing.Size(835, 30);
            // 
            // panelMainTop
            // 
            this.panelMainTop.BackColor = System.Drawing.SystemColors.Control;
            this.panelMainTop.Size = new System.Drawing.Size(835, 30);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.BackColor = System.Drawing.SystemColors.Control;
            this.drawerLeftMain.Controls.Add(this.button2);
            this.drawerLeftMain.Controls.Add(this.panel1);
            this.drawerLeftMain.Controls.Add(this.lblStartTime);
            this.drawerLeftMain.Controls.Add(this.lblDept);
            this.drawerLeftMain.Controls.Add(this.lblEndTime);
            this.drawerLeftMain.Controls.Add(this.dtpStartTime);
            this.drawerLeftMain.Controls.Add(this.ddlDept);
            this.drawerLeftMain.Controls.Add(this.dtpEndTime);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 308);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(618, 4);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(692, 4);
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(766, 4);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(840, 4);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(914, 4);
            // 
            // panelMainMain
            // 
            this.panelMainMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMainMain.Controls.Add(this.dgrd);
            this.panelMainMain.Size = new System.Drawing.Size(835, 524);
            // 
            // ddlDept
            // 
            this.ddlDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDept.FormattingEnabled = true;
            this.ddlDept.Location = new System.Drawing.Point(85, 171);
            this.ddlDept.Name = "ddlDept";
            this.ddlDept.Size = new System.Drawing.Size(91, 20);
            this.ddlDept.TabIndex = 58;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(22, 174);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(47, 12);
            this.lblDept.TabIndex = 57;
            this.lblDept.Text = "部  门:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(86, 128);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(90, 21);
            this.dtpEndTime.TabIndex = 56;
            this.dtpEndTime.Value = new System.DateTime(2007, 10, 26, 0, 0, 0, 0);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(22, 102);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(59, 12);
            this.lblEndTime.TabIndex = 55;
            this.lblEndTime.Text = "结束日期:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(86, 71);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(90, 21);
            this.dtpStartTime.TabIndex = 54;
            this.dtpStartTime.Value = new System.DateTime(2007, 10, 26, 0, 0, 0, 0);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(22, 53);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(59, 12);
            this.lblStartTime.TabIndex = 53;
            this.lblStartTime.Text = "开始日期:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 30);
            this.panel1.TabIndex = 60;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "部门逐日考勤统计";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(54, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 61;
            this.button2.Text = "查  询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgrd
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgrd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgrd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrd.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.WindowsStyle;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrd.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.dgrd.Location = new System.Drawing.Point(0, 0);
            this.dgrd.Name = "dgrd";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(93)))), ((int)(((byte)(165)))));
            this.dgrd.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.Size = new System.Drawing.Size(835, 524);
            this.dgrd.TabIndex = 0;
            this.dgrd.VerticalScrollBarMax = 1;
            this.dgrd.VerticalScrollBarValue = 0;
            // 
            // AttendanceDayByDayStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1039, 588);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttendanceDayByDayStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "部门逐日考勤统计";
            this.Text = "部门逐日考勤统计";
            this.Load += new System.EventHandler(this.AttendanceDayByDayStatistic_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.drawerLeftMain.ResumeLayout(false);
            this.drawerLeftMain.PerformLayout();
            this.panelMainMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlDept;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private DataGridViewMultiHeaders dgrd;
    }
}