namespace KJ128NInterfaceShow
{
    partial class AttendanceQuerySalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceQuerySalary));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ddlDept = new System.Windows.Forms.ComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblBlockID = new System.Windows.Forms.Label();
            this.txtEmployeeName = new Shine.ShineTextBox();
            this.txtBlock = new Shine.ShineTextBox();
            this.lblErr = new System.Windows.Forms.Label();
            this.txtStandardTime = new Shine.ShineTextBox();
            this.lblStandardTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgrd = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Size = new System.Drawing.Size(200, 551);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(828, 551);
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeftBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLeftBottom.BackgroundImage")));
            this.panelLeftBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeftBottom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 98);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 453);
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelMainBottom.Location = new System.Drawing.Point(0, 517);
            this.panelMainBottom.Size = new System.Drawing.Size(824, 30);
            // 
            // panelMainTop
            // 
            this.panelMainTop.BackColor = System.Drawing.SystemColors.Control;
            this.panelMainTop.Size = new System.Drawing.Size(824, 30);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.BackColor = System.Drawing.SystemColors.Control;
            this.drawerLeftMain.Controls.Add(this.panel2);
            this.drawerLeftMain.Controls.Add(this.button1);
            this.drawerLeftMain.Controls.Add(this.lblStartTime);
            this.drawerLeftMain.Controls.Add(this.lblEmployeeName);
            this.drawerLeftMain.Controls.Add(this.lblDept);
            this.drawerLeftMain.Controls.Add(this.lblBlockID);
            this.drawerLeftMain.Controls.Add(this.dtpEndTime);
            this.drawerLeftMain.Controls.Add(this.dtpStartTime);
            this.drawerLeftMain.Controls.Add(this.txtBlock);
            this.drawerLeftMain.Controls.Add(this.lblStandardTime);
            this.drawerLeftMain.Controls.Add(this.txtStandardTime);
            this.drawerLeftMain.Controls.Add(this.ddlDept);
            this.drawerLeftMain.Controls.Add(this.txtEmployeeName);
            this.drawerLeftMain.Controls.Add(this.lblEndTime);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 98);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(830, 4);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(904, 4);
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(978, 4);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1052, 4);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1126, 4);
            // 
            // panelMainMain
            // 
            this.panelMainMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMainMain.Controls.Add(this.dgrd);
            this.panelMainMain.Size = new System.Drawing.Size(824, 487);
            // 
            // ddlDept
            // 
            this.ddlDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDept.FormattingEnabled = true;
            this.ddlDept.Location = new System.Drawing.Point(102, 104);
            this.ddlDept.Name = "ddlDept";
            this.ddlDept.Size = new System.Drawing.Size(90, 20);
            this.ddlDept.TabIndex = 69;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(36, 107);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(47, 12);
            this.lblDept.TabIndex = 68;
            this.lblDept.Text = "部  门:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(102, 69);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(90, 21);
            this.dtpEndTime.TabIndex = 67;
            this.dtpEndTime.Value = new System.DateTime(2007, 10, 26, 0, 0, 0, 0);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(24, 73);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(59, 12);
            this.lblEndTime.TabIndex = 66;
            this.lblEndTime.Text = "结束日期:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(102, 34);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(90, 21);
            this.dtpStartTime.TabIndex = 65;
            this.dtpStartTime.Value = new System.DateTime(2007, 10, 26, 0, 0, 0, 0);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(24, 38);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(59, 12);
            this.lblStartTime.TabIndex = 64;
            this.lblStartTime.Text = "开始日期:";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(36, 140);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(47, 12);
            this.lblEmployeeName.TabIndex = 72;
            this.lblEmployeeName.Text = "姓  名:";
            // 
            // lblBlockID
            // 
            this.lblBlockID.AutoSize = true;
            this.lblBlockID.Location = new System.Drawing.Point(36, 172);
            this.lblBlockID.Name = "lblBlockID";
            this.lblBlockID.Size = new System.Drawing.Size(47, 12);
            this.lblBlockID.TabIndex = 73;
            this.lblBlockID.Text = "标识卡:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(101, 137);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(91, 21);
            this.txtEmployeeName.TabIndex = 74;
            this.txtEmployeeName.TextType = Shine.TextType.WithOutChar;
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(101, 169);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(91, 21);
            this.txtBlock.TabIndex = 75;
            this.txtBlock.TextType = Shine.TextType.Number;
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(276, 434);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 76;
            // 
            // txtStandardTime
            // 
            this.txtStandardTime.Location = new System.Drawing.Point(101, 206);
            this.txtStandardTime.Name = "txtStandardTime";
            this.txtStandardTime.Size = new System.Drawing.Size(91, 21);
            this.txtStandardTime.TabIndex = 78;
            this.txtStandardTime.Text = "8";
            this.txtStandardTime.TextType = Shine.TextType.WithOutChar;
            // 
            // lblStandardTime
            // 
            this.lblStandardTime.AutoSize = true;
            this.lblStandardTime.Location = new System.Drawing.Point(24, 209);
            this.lblStandardTime.Name = "lblStandardTime";
            this.lblStandardTime.Size = new System.Drawing.Size(59, 12);
            this.lblStandardTime.TabIndex = 77;
            this.lblStandardTime.Text = "额定工时:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 79;
            this.button1.Text = "查  询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgrd
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrd.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrd.Location = new System.Drawing.Point(0, 0);
            this.dgrd.Name = "dgrd";
            this.dgrd.ReadOnly = true;
            this.dgrd.RowHeadersVisible = false;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.Size = new System.Drawing.Size(824, 487);
            this.dgrd.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 25);
            this.panel2.TabIndex = 80;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 25);
            this.button2.TabIndex = 0;
            this.button2.Text = "考情劳动报表";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AttendanceQuerySalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1028, 551);
            this.Controls.Add(this.lblErr);
            this.Name = "AttendanceQuerySalary";
            this.TabText = "员工出勤劳动报表";
            this.Text = "员工出勤劳动报表";
            this.Load += new System.EventHandler(this.AttendanceQuerySalary_Load);
            this.Controls.SetChildIndex(this.lblErr, 0);
            this.Controls.SetChildIndex(this.panelLeft, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.drawerLeftMain.ResumeLayout(false);
            this.drawerLeftMain.PerformLayout();
            this.panelMainMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlDept;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblBlockID;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label lblStandardTime;
        private Shine.ShineTextBox txtEmployeeName;
        private Shine.ShineTextBox txtBlock;
        private Shine.ShineTextBox txtStandardTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgrd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
    }
}