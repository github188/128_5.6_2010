namespace KJ128NInterfaceShow
{
    partial class AttendanceStatisticByDuty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceStatisticByDuty));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBlock = new Shine.ShineTextBox();
            this.txtEmployeeName = new Shine.ShineTextBox();
            this.lblBlockID = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.ddlDept = new System.Windows.Forms.ComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.ddlDuty = new System.Windows.Forms.ComboBox();
            this.lblDuty = new System.Windows.Forms.Label();
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
            // panelLeftBottom
            // 
            this.panelLeftBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeftBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLeftBottom.BackgroundImage")));
            this.panelLeftBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 277);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 246);
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.BackColor = System.Drawing.SystemColors.Control;
            // 
            // panelMainTop
            // 
            this.panelMainTop.BackColor = System.Drawing.SystemColors.Control;
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.BackColor = System.Drawing.SystemColors.Control;
            this.drawerLeftMain.Controls.Add(this.button2);
            this.drawerLeftMain.Controls.Add(this.panel1);
            this.drawerLeftMain.Controls.Add(this.lblStartTime);
            this.drawerLeftMain.Controls.Add(this.ddlDuty);
            this.drawerLeftMain.Controls.Add(this.lblBlockID);
            this.drawerLeftMain.Controls.Add(this.ddlDept);
            this.drawerLeftMain.Controls.Add(this.lblEmployeeName);
            this.drawerLeftMain.Controls.Add(this.dtpStartTime);
            this.drawerLeftMain.Controls.Add(this.lblDept);
            this.drawerLeftMain.Controls.Add(this.txtEmployeeName);
            this.drawerLeftMain.Controls.Add(this.dtpEndTime);
            this.drawerLeftMain.Controls.Add(this.lblDuty);
            this.drawerLeftMain.Controls.Add(this.txtBlock);
            this.drawerLeftMain.Controls.Add(this.lblEndTime);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 277);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(423, 4);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(497, 4);
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(571, 4);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(645, 4);
            // 
            // btnPrint
            // 
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // panelMainMain
            // 
            this.panelMainMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMainMain.Controls.Add(this.dgrd);
            // 
            // txtBlock
            // 
            this.txtBlock.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBlock.Location = new System.Drawing.Point(85, 203);
            this.txtBlock.MaxLength = 5;
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(96, 21);
            this.txtBlock.TabIndex = 90;
            this.txtBlock.TextType = Shine.TextType.Number;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(86, 242);
            this.txtEmployeeName.MaxLength = 20;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(96, 21);
            this.txtEmployeeName.TabIndex = 89;
            this.txtEmployeeName.TextType = Shine.TextType.WithOutChar;
            this.txtEmployeeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmployeeName_KeyPress);
            // 
            // lblBlockID
            // 
            this.lblBlockID.AutoSize = true;
            this.lblBlockID.Location = new System.Drawing.Point(22, 206);
            this.lblBlockID.Name = "lblBlockID";
            this.lblBlockID.Size = new System.Drawing.Size(47, 12);
            this.lblBlockID.TabIndex = 88;
            this.lblBlockID.Text = "标识卡:";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(22, 245);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(47, 12);
            this.lblEmployeeName.TabIndex = 87;
            this.lblEmployeeName.Text = "姓  名:";
            // 
            // ddlDept
            // 
            this.ddlDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDept.FormattingEnabled = true;
            this.ddlDept.Location = new System.Drawing.Point(86, 120);
            this.ddlDept.Name = "ddlDept";
            this.ddlDept.Size = new System.Drawing.Size(96, 20);
            this.ddlDept.TabIndex = 84;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(22, 123);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(47, 12);
            this.lblDept.TabIndex = 83;
            this.lblDept.Text = "部  门:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(86, 78);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(95, 21);
            this.dtpEndTime.TabIndex = 82;
            this.dtpEndTime.Value = new System.DateTime(2007, 10, 26, 0, 0, 0, 0);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(10, 82);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(59, 12);
            this.lblEndTime.TabIndex = 81;
            this.lblEndTime.Text = "结束日期:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(86, 37);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(95, 21);
            this.dtpStartTime.TabIndex = 80;
            this.dtpStartTime.Value = new System.DateTime(2007, 10, 26, 0, 0, 0, 0);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(10, 41);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(59, 12);
            this.lblStartTime.TabIndex = 79;
            this.lblStartTime.Text = "开始日期:";
            // 
            // ddlDuty
            // 
            this.ddlDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDuty.FormattingEnabled = true;
            this.ddlDuty.Location = new System.Drawing.Point(85, 164);
            this.ddlDuty.Name = "ddlDuty";
            this.ddlDuty.Size = new System.Drawing.Size(96, 20);
            this.ddlDuty.TabIndex = 94;
            // 
            // lblDuty
            // 
            this.lblDuty.AutoSize = true;
            this.lblDuty.Location = new System.Drawing.Point(22, 168);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(47, 12);
            this.lblDuty.TabIndex = 93;
            this.lblDuty.Text = "职  务:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 25);
            this.panel1.TabIndex = 95;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "部门干部下井统计";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(50, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 96;
            this.button2.Text = "查  询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgrd
            // 
            this.dgrd.AllowUserToAddRows = false;
            this.dgrd.AllowUserToDeleteRows = false;
            this.dgrd.AllowUserToResizeRows = false;
            this.dgrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.ColumnHeadersHeight = 50;
            this.dgrd.DataGridShowStype = KJ128NInterfaceShow.DataGridViewKJ128Style.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrd.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgrd.Location = new System.Drawing.Point(0, 0);
            this.dgrd.Name = "dgrd";
            this.dgrd.ReadOnly = true;
            this.dgrd.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgrd.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrd.Size = new System.Drawing.Size(783, 459);
            this.dgrd.TabIndex = 0;
            this.dgrd.VerticalScrollBarMax = 1;
            this.dgrd.VerticalScrollBarValue = 0;
            // 
            // AttendanceStatisticByDuty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "AttendanceStatisticByDuty";
            this.TabText = "各部门干部下井统计报表";
            this.Text = "各部门干部下井统计报表";
            this.Load += new System.EventHandler(this.AttendanceStatisticByDuty_Load);
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

        private System.Windows.Forms.Label lblBlockID;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.ComboBox ddlDept;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.ComboBox ddlDuty;
        private System.Windows.Forms.Label lblDuty;
        private Shine.ShineTextBox txtBlock;
        private Shine.ShineTextBox txtEmployeeName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private DataGridViewMultiHeaders dgrd;
    }
}