namespace KJ128NMainRun.A_Statement
{
    partial class A_FrmOverTimeEmpStatement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_FrmOverTimeEmpStatement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dmc_Info = new DegonControlLib.DrawerMainControl();
            this.pl_OverTimeEmpStatement = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bt_ConfineAreaStatement = new System.Windows.Forms.Button();
            this.bt_Enquiries = new System.Windows.Forms.Button();
            this.dtp_Begin = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.dmc_Info.SuspendLayout();
            this.pl_OverTimeEmpStatement.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.bt_Enquiries);
            this.panelLeftBottom.Controls.Add(this.dtp_Begin);
            this.panelLeftBottom.Controls.Add(this.label22);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 421);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 102);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.dmc_Info);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 421);
            // 
            // btnAdd
            // 
            this.btnAdd.Visible = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Size = new System.Drawing.Size(101, 12);
            this.lblMainTitle.Text = "超时报警人员统计";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Visible = false;
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(659, 4);
            this.btnLaws.Text = "导出";
            this.btnLaws.Click += new System.EventHandler(this.btnLaws_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(599, 4);
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
            this.panelMainMain.Controls.Add(this.pictureBox2);
            this.panelMainMain.Controls.Add(this.dgv_Main);
            // 
            // btnConfigModel
            // 
            this.btnConfigModel.Click += new System.EventHandler(this.btnConfigModel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dmc_Info
            // 
            this.dmc_Info.Controls.Add(this.pl_OverTimeEmpStatement);
            this.dmc_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dmc_Info.Location = new System.Drawing.Point(0, 0);
            this.dmc_Info.MainHeight = 100;
            this.dmc_Info.Name = "dmc_Info";
            this.dmc_Info.PartTime = 50;
            this.dmc_Info.PType = DegonControlLib.PartType.Time;
            this.dmc_Info.Size = new System.Drawing.Size(196, 417);
            this.dmc_Info.SplitHeight = 1;
            this.dmc_Info.TabIndex = 3;
            this.dmc_Info.TitleHeight = 25;
            // 
            // pl_OverTimeEmpStatement
            // 
            this.pl_OverTimeEmpStatement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_OverTimeEmpStatement.Controls.Add(this.panel3);
            this.pl_OverTimeEmpStatement.Controls.Add(this.panel4);
            this.pl_OverTimeEmpStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_OverTimeEmpStatement.Location = new System.Drawing.Point(0, 0);
            this.pl_OverTimeEmpStatement.Name = "pl_OverTimeEmpStatement";
            this.pl_OverTimeEmpStatement.Size = new System.Drawing.Size(196, 417);
            this.pl_OverTimeEmpStatement.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.pb);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 390);
            this.panel3.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 390);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(194, 390);
            this.pb.TabIndex = 16;
            this.pb.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.bt_ConfineAreaStatement);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 25);
            this.panel4.TabIndex = 7;
            // 
            // bt_ConfineAreaStatement
            // 
            this.bt_ConfineAreaStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_ConfineAreaStatement.Location = new System.Drawing.Point(0, 0);
            this.bt_ConfineAreaStatement.Name = "bt_ConfineAreaStatement";
            this.bt_ConfineAreaStatement.Size = new System.Drawing.Size(194, 25);
            this.bt_ConfineAreaStatement.TabIndex = 0;
            this.bt_ConfineAreaStatement.Text = "超时报警人员统计";
            this.bt_ConfineAreaStatement.UseVisualStyleBackColor = true;
            // 
            // bt_Enquiries
            // 
            this.bt_Enquiries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Enquiries.Location = new System.Drawing.Point(123, 61);
            this.bt_Enquiries.Name = "bt_Enquiries";
            this.bt_Enquiries.Size = new System.Drawing.Size(53, 23);
            this.bt_Enquiries.TabIndex = 34;
            this.bt_Enquiries.Text = "查询";
            this.bt_Enquiries.UseVisualStyleBackColor = true;
            this.bt_Enquiries.Click += new System.EventHandler(this.bt_Enquiries_Click);
            // 
            // dtp_Begin
            // 
            this.dtp_Begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtp_Begin.CustomFormat = "yyyy-MM-dd";
            this.dtp_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Begin.Location = new System.Drawing.Point(91, 22);
            this.dtp_Begin.Name = "dtp_Begin";
            this.dtp_Begin.Size = new System.Drawing.Size(85, 21);
            this.dtp_Begin.TabIndex = 36;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 35;
            this.label22.Text = "查询日期：";
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToResizeRows = false;
            this.dgv_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.EnableHeadersVisualStyles = false;
            this.dgv_Main.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Main.RowHeadersVisible = false;
            this.dgv_Main.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(783, 459);
            this.dgv_Main.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(783, 459);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // A_FrmOverTimeEmpStatement
            // 
            this.AcceptButton = this.bt_Enquiries;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_FrmOverTimeEmpStatement";
            this.TabText = "超时报警人员统计";
            this.Text = "超时报警人员统计";
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            this.panelLeftBottom.PerformLayout();
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.drawerLeftMain.ResumeLayout(false);
            this.panelMainMain.ResumeLayout(false);
            this.dmc_Info.ResumeLayout(false);
            this.pl_OverTimeEmpStatement.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DegonControlLib.DrawerMainControl dmc_Info;
        private System.Windows.Forms.Panel pl_OverTimeEmpStatement;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button bt_ConfineAreaStatement;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bt_Enquiries;
        private System.Windows.Forms.DateTimePicker dtp_Begin;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}