namespace KJ128NMainRun.A_His_StationHead
{
    partial class A_FrmHisStationHead
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_FrmHisStationHead));
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.pl_StaHead = new System.Windows.Forms.Panel();
            this.tbc = new System.Windows.Forms.TabControl();
            this.tbp_Dept = new System.Windows.Forms.TabPage();
            this.tvc_Dept = new DegonControlLib.TreeViewControl();
            this.tbp_StationHead = new System.Windows.Forms.TabPage();
            this.tvc_StationHead = new DegonControlLib.TreeViewControl();
            this.tbp_WorkType = new System.Windows.Forms.TabPage();
            this.tvc_WorkType = new DegonControlLib.TreeViewControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtp_Ter_End = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.dtp_Ter_Begin = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CodeSenderAddress = new Shine.ShineTextBox();
            this.txt_EmpName = new Shine.ShineTextBox();
            this.bt_EmpOverTime_Reset = new System.Windows.Forms.Button();
            this.bt_EmpOverTime_Enquiries = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.rbtNoSet = new System.Windows.Forms.RadioButton();
            this.rb_Equ = new System.Windows.Forms.RadioButton();
            this.rb_Emp = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.pl_StaHead.SuspendLayout();
            this.tbc.SuspendLayout();
            this.tbp_Dept.SuspendLayout();
            this.tbp_StationHead.SuspendLayout();
            this.tbp_WorkType.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.groupBox1);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 420);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 103);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.pl_StaHead);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 420);
            // 
            // btnAdd
            // 
            this.btnAdd.Visible = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Size = new System.Drawing.Size(65, 12);
            this.lblMainTitle.Text = "历史标识卡";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Visible = false;
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(479, 4);
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
            this.lblSumPage.Location = new System.Drawing.Point(463, 11);
            this.lblSumPage.Visible = false;
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.Visible = false;
            this.cmbSelectCounts.DropDownClosed += new System.EventHandler(this.cmbSelectCounts_DropDownClosed);
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
            this.txtSkipPage.Location = new System.Drawing.Point(569, 6);
            this.txtSkipPage.MaxLength = 5;
            this.txtSkipPage.Size = new System.Drawing.Size(42, 21);
            this.txtSkipPage.Visible = false;
            this.txtSkipPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSkipPage_KeyDown);
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // label6
            // 
            this.label6.Visible = false;
            // 
            // lblPageCounts
            // 
            this.lblPageCounts.Location = new System.Drawing.Point(434, 11);
            this.lblPageCounts.Visible = false;
            // 
            // btnDownPage
            // 
            this.btnDownPage.Enabled = false;
            this.btnDownPage.Visible = false;
            this.btnDownPage.Click += new System.EventHandler(this.btnDownPage_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Enabled = false;
            this.btnUpPage.Location = new System.Drawing.Point(407, 5);
            this.btnUpPage.Visible = false;
            this.btnUpPage.Click += new System.EventHandler(this.btnUpPage_Click);
            // 
            // label9
            // 
            this.label9.Visible = false;
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.pictureBox1);
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
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToDeleteRows = false;
            this.dgv_Main.AllowUserToResizeRows = false;
            this.dgv_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
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
            this.dgv_Main.TabIndex = 4;
            // 
            // pl_StaHead
            // 
            this.pl_StaHead.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pl_StaHead.Controls.Add(this.tbc);
            this.pl_StaHead.Controls.Add(this.panel3);
            this.pl_StaHead.Controls.Add(this.panel2);
            this.pl_StaHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_StaHead.Location = new System.Drawing.Point(0, 0);
            this.pl_StaHead.Name = "pl_StaHead";
            this.pl_StaHead.Size = new System.Drawing.Size(196, 416);
            this.pl_StaHead.TabIndex = 2;
            // 
            // tbc
            // 
            this.tbc.Controls.Add(this.tbp_Dept);
            this.tbc.Controls.Add(this.tbp_StationHead);
            this.tbc.Controls.Add(this.tbp_WorkType);
            this.tbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc.Location = new System.Drawing.Point(0, 25);
            this.tbc.Name = "tbc";
            this.tbc.SelectedIndex = 0;
            this.tbc.Size = new System.Drawing.Size(192, 190);
            this.tbc.TabIndex = 1;
            this.tbc.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbc_Selecting);
            // 
            // tbp_Dept
            // 
            this.tbp_Dept.Controls.Add(this.tvc_Dept);
            this.tbp_Dept.Location = new System.Drawing.Point(4, 21);
            this.tbp_Dept.Name = "tbp_Dept";
            this.tbp_Dept.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Dept.Size = new System.Drawing.Size(184, 165);
            this.tbp_Dept.TabIndex = 0;
            this.tbp_Dept.Text = "部门";
            this.tbp_Dept.UseVisualStyleBackColor = true;
            // 
            // tvc_Dept
            // 
            this.tvc_Dept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_Dept.Location = new System.Drawing.Point(3, 3);
            this.tvc_Dept.Name = "tvc_Dept";
            this.tvc_Dept.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_Dept.Size = new System.Drawing.Size(178, 159);
            this.tvc_Dept.TabIndex = 2;
            // 
            // tbp_StationHead
            // 
            this.tbp_StationHead.Controls.Add(this.tvc_StationHead);
            this.tbp_StationHead.Location = new System.Drawing.Point(4, 21);
            this.tbp_StationHead.Name = "tbp_StationHead";
            this.tbp_StationHead.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_StationHead.Size = new System.Drawing.Size(184, 165);
            this.tbp_StationHead.TabIndex = 1;
            this.tbp_StationHead.Text = "分站";
            this.tbp_StationHead.UseVisualStyleBackColor = true;
            // 
            // tvc_StationHead
            // 
            this.tvc_StationHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_StationHead.Location = new System.Drawing.Point(3, 3);
            this.tvc_StationHead.Name = "tvc_StationHead";
            this.tvc_StationHead.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_StationHead.Size = new System.Drawing.Size(178, 159);
            this.tvc_StationHead.TabIndex = 1;
            // 
            // tbp_WorkType
            // 
            this.tbp_WorkType.Controls.Add(this.tvc_WorkType);
            this.tbp_WorkType.Location = new System.Drawing.Point(4, 21);
            this.tbp_WorkType.Name = "tbp_WorkType";
            this.tbp_WorkType.Size = new System.Drawing.Size(184, 165);
            this.tbp_WorkType.TabIndex = 2;
            this.tbp_WorkType.Text = "工种";
            this.tbp_WorkType.UseVisualStyleBackColor = true;
            // 
            // tvc_WorkType
            // 
            this.tvc_WorkType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_WorkType.Location = new System.Drawing.Point(0, 0);
            this.tvc_WorkType.Name = "tvc_WorkType";
            this.tvc_WorkType.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_WorkType.Size = new System.Drawing.Size(184, 165);
            this.tvc_WorkType.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtp_Ter_End);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.dtp_Ter_Begin);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txt_CodeSenderAddress);
            this.panel3.Controls.Add(this.txt_EmpName);
            this.panel3.Controls.Add(this.bt_EmpOverTime_Reset);
            this.panel3.Controls.Add(this.bt_EmpOverTime_Enquiries);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 215);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(192, 197);
            this.panel3.TabIndex = 1;
            // 
            // dtp_Ter_End
            // 
            this.dtp_Ter_End.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtp_Ter_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_Ter_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Ter_End.Location = new System.Drawing.Point(28, 70);
            this.dtp_Ter_End.Name = "dtp_Ter_End";
            this.dtp_Ter_End.Size = new System.Drawing.Size(145, 21);
            this.dtp_Ter_End.TabIndex = 32;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 55);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 31;
            this.label21.Text = "终止时间：";
            // 
            // dtp_Ter_Begin
            // 
            this.dtp_Ter_Begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtp_Ter_Begin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_Ter_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Ter_Begin.Location = new System.Drawing.Point(28, 28);
            this.dtp_Ter_Begin.Name = "dtp_Ter_Begin";
            this.dtp_Ter_Begin.Size = new System.Drawing.Size(145, 21);
            this.dtp_Ter_Begin.TabIndex = 30;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 29;
            this.label22.Text = "开始时间：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "标识卡：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "姓  名：";
            // 
            // txt_CodeSenderAddress
            // 
            this.txt_CodeSenderAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CodeSenderAddress.Location = new System.Drawing.Point(77, 100);
            this.txt_CodeSenderAddress.Name = "txt_CodeSenderAddress";
            this.txt_CodeSenderAddress.Size = new System.Drawing.Size(94, 21);
            this.txt_CodeSenderAddress.TabIndex = 18;
            this.txt_CodeSenderAddress.TextType = Shine.TextType.Number;
            // 
            // txt_EmpName
            // 
            this.txt_EmpName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_EmpName.Location = new System.Drawing.Point(77, 127);
            this.txt_EmpName.Name = "txt_EmpName";
            this.txt_EmpName.Size = new System.Drawing.Size(94, 21);
            this.txt_EmpName.TabIndex = 16;
            this.txt_EmpName.TextType = Shine.TextType.WithOutChar;
            // 
            // bt_EmpOverTime_Reset
            // 
            this.bt_EmpOverTime_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_EmpOverTime_Reset.Location = new System.Drawing.Point(118, 160);
            this.bt_EmpOverTime_Reset.Name = "bt_EmpOverTime_Reset";
            this.bt_EmpOverTime_Reset.Size = new System.Drawing.Size(53, 23);
            this.bt_EmpOverTime_Reset.TabIndex = 14;
            this.bt_EmpOverTime_Reset.Text = "重置";
            this.bt_EmpOverTime_Reset.UseVisualStyleBackColor = true;
            this.bt_EmpOverTime_Reset.Click += new System.EventHandler(this.bt_EmpOverTime_Reset_Click);
            // 
            // bt_EmpOverTime_Enquiries
            // 
            this.bt_EmpOverTime_Enquiries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_EmpOverTime_Enquiries.Location = new System.Drawing.Point(18, 160);
            this.bt_EmpOverTime_Enquiries.Name = "bt_EmpOverTime_Enquiries";
            this.bt_EmpOverTime_Enquiries.Size = new System.Drawing.Size(53, 23);
            this.bt_EmpOverTime_Enquiries.TabIndex = 13;
            this.bt_EmpOverTime_Enquiries.Text = "查询";
            this.bt_EmpOverTime_Enquiries.UseVisualStyleBackColor = true;
            this.bt_EmpOverTime_Enquiries.Click += new System.EventHandler(this.bt_EmpOverTime_Enquiries_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 25);
            this.panel2.TabIndex = 0;
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(192, 25);
            this.button.TabIndex = 0;
            this.button.Text = "分站位置";
            this.button.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtAll);
            this.groupBox1.Controls.Add(this.rbtNoSet);
            this.groupBox1.Controls.Add(this.rb_Equ);
            this.groupBox1.Controls.Add(this.rb_Emp);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 86);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标示卡匹配类型";
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Location = new System.Drawing.Point(108, 56);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(47, 16);
            this.rbtAll.TabIndex = 3;
            this.rbtAll.Text = "所有";
            this.rbtAll.UseVisualStyleBackColor = true;
            // 
            // rbtNoSet
            // 
            this.rbtNoSet.AutoSize = true;
            this.rbtNoSet.Location = new System.Drawing.Point(28, 57);
            this.rbtNoSet.Name = "rbtNoSet";
            this.rbtNoSet.Size = new System.Drawing.Size(59, 16);
            this.rbtNoSet.TabIndex = 2;
            this.rbtNoSet.Text = "未配置";
            this.rbtNoSet.UseVisualStyleBackColor = true;
            // 
            // rb_Equ
            // 
            this.rb_Equ.AutoSize = true;
            this.rb_Equ.Location = new System.Drawing.Point(108, 24);
            this.rb_Equ.Name = "rb_Equ";
            this.rb_Equ.Size = new System.Drawing.Size(47, 16);
            this.rb_Equ.TabIndex = 1;
            this.rb_Equ.Text = "设备";
            this.rb_Equ.UseVisualStyleBackColor = true;
            // 
            // rb_Emp
            // 
            this.rb_Emp.AutoSize = true;
            this.rb_Emp.Checked = true;
            this.rb_Emp.Location = new System.Drawing.Point(28, 25);
            this.rb_Emp.Name = "rb_Emp";
            this.rb_Emp.Size = new System.Drawing.Size(47, 16);
            this.rb_Emp.TabIndex = 0;
            this.rb_Emp.TabStop = true;
            this.rb_Emp.Text = "人员";
            this.rb_Emp.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(783, 459);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // A_FrmHisStationHead
            // 
            this.AcceptButton = this.bt_EmpOverTime_Enquiries;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_FrmHisStationHead";
            this.TabText = "历史标识卡";
            this.Text = "历史读卡分站";
            this.Load += new System.EventHandler(this.A_FrmHisStationHead_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_FrmHisStationHead_FormClosing);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.drawerLeftMain.ResumeLayout(false);
            this.panelMainMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.pl_StaHead.ResumeLayout(false);
            this.tbc.ResumeLayout(false);
            this.tbp_Dept.ResumeLayout(false);
            this.tbp_StationHead.ResumeLayout(false);
            this.tbp_WorkType.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Panel pl_StaHead;
        private System.Windows.Forms.TabControl tbc;
        private System.Windows.Forms.TabPage tbp_Dept;
        private DegonControlLib.TreeViewControl tvc_Dept;
        private System.Windows.Forms.TabPage tbp_StationHead;
        private DegonControlLib.TreeViewControl tvc_StationHead;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Shine.ShineTextBox txt_CodeSenderAddress;
        private Shine.ShineTextBox txt_EmpName;
        private System.Windows.Forms.Button bt_EmpOverTime_Reset;
        private System.Windows.Forms.Button bt_EmpOverTime_Enquiries;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Equ;
        private System.Windows.Forms.RadioButton rb_Emp;
        private System.Windows.Forms.DateTimePicker dtp_Ter_End;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtp_Ter_Begin;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.RadioButton rbtNoSet;
        private System.Windows.Forms.TabPage tbp_WorkType;
        private DegonControlLib.TreeViewControl tvc_WorkType;
    }
}