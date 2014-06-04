namespace KJ128NMainRun.A_RT_StationHead
{
    partial class A_FrmRTStationHead
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pl_StaHead = new System.Windows.Forms.Panel();
            this.tbc = new System.Windows.Forms.TabControl();
            this.tbp_Dept = new System.Windows.Forms.TabPage();
            this.tvc_Dept = new DegonControlLib.TreeViewControl();
            this.tbp_StationHead = new System.Windows.Forms.TabPage();
            this.tvc_StationHead = new DegonControlLib.TreeViewControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CodeSenderAddress = new Shine.ShineTextBox();
            this.txt_EmpName = new Shine.ShineTextBox();
            this.bt_EmpOverTime_Reset = new System.Windows.Forms.Button();
            this.bt_EmpOverTime_Enquiries = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button = new System.Windows.Forms.Button();
            this.cb = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.rbtNoSet = new System.Windows.Forms.RadioButton();
            this.rb_Equ = new System.Windows.Forms.RadioButton();
            this.rb_Emp = new System.Windows.Forms.RadioButton();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.timer_Alarm = new System.Windows.Forms.Timer(this.components);
            this.bt_Set = new System.Windows.Forms.Button();
            this.cb_Show = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.shineTextBox1 = new Shine.ShineTextBox();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.pl_StaHead.SuspendLayout();
            this.tbc.SuspendLayout();
            this.tbp_Dept.SuspendLayout();
            this.tbp_StationHead.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.shineTextBox1);
            this.panelLeftBottom.Controls.Add(this.label3);
            this.panelLeftBottom.Controls.Add(this.cb_Show);
            this.panelLeftBottom.Controls.Add(this.cb);
            this.panelLeftBottom.Controls.Add(this.groupBox1);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 359);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 164);
            // 
            // panelMainTop
            // 
            this.panelMainTop.Controls.Add(this.bt_Set);
            this.panelMainTop.Controls.SetChildIndex(this.btnExportExcel, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnConfigModel, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnLaws, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnPrint, 0);
            this.panelMainTop.Controls.SetChildIndex(this.lblMainTitle, 0);
            this.panelMainTop.Controls.SetChildIndex(this.bt_Set, 0);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.pl_StaHead);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 359);
            // 
            // btnAdd
            // 
            this.btnAdd.Visible = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Size = new System.Drawing.Size(65, 12);
            this.lblMainTitle.Text = "实时标识卡";
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
            // pl_StaHead
            // 
            this.pl_StaHead.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pl_StaHead.Controls.Add(this.tbc);
            this.pl_StaHead.Controls.Add(this.panel3);
            this.pl_StaHead.Controls.Add(this.panel2);
            this.pl_StaHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_StaHead.Location = new System.Drawing.Point(0, 0);
            this.pl_StaHead.Name = "pl_StaHead";
            this.pl_StaHead.Size = new System.Drawing.Size(196, 355);
            this.pl_StaHead.TabIndex = 1;
            // 
            // tbc
            // 
            this.tbc.Controls.Add(this.tbp_Dept);
            this.tbc.Controls.Add(this.tbp_StationHead);
            this.tbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc.Location = new System.Drawing.Point(0, 25);
            this.tbc.Name = "tbc";
            this.tbc.SelectedIndex = 0;
            this.tbc.Size = new System.Drawing.Size(192, 217);
            this.tbc.TabIndex = 1;
            this.tbc.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbc_Selecting);
            // 
            // tbp_Dept
            // 
            this.tbp_Dept.Controls.Add(this.tvc_Dept);
            this.tbp_Dept.Location = new System.Drawing.Point(4, 21);
            this.tbp_Dept.Name = "tbp_Dept";
            this.tbp_Dept.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Dept.Size = new System.Drawing.Size(184, 192);
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
            this.tvc_Dept.Size = new System.Drawing.Size(178, 186);
            this.tvc_Dept.TabIndex = 2;
            this.tvc_Dept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_Dept_AfterSelect);
            // 
            // tbp_StationHead
            // 
            this.tbp_StationHead.Controls.Add(this.tvc_StationHead);
            this.tbp_StationHead.Location = new System.Drawing.Point(4, 21);
            this.tbp_StationHead.Name = "tbp_StationHead";
            this.tbp_StationHead.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_StationHead.Size = new System.Drawing.Size(184, 192);
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
            this.tvc_StationHead.Size = new System.Drawing.Size(178, 186);
            this.tvc_StationHead.TabIndex = 1;
            this.tvc_StationHead.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_StationHead_AfterSelect);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txt_CodeSenderAddress);
            this.panel3.Controls.Add(this.txt_EmpName);
            this.panel3.Controls.Add(this.bt_EmpOverTime_Reset);
            this.panel3.Controls.Add(this.bt_EmpOverTime_Enquiries);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 242);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(192, 109);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
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
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "姓  名：";
            // 
            // txt_CodeSenderAddress
            // 
            this.txt_CodeSenderAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CodeSenderAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_CodeSenderAddress.Location = new System.Drawing.Point(77, 12);
            this.txt_CodeSenderAddress.Name = "txt_CodeSenderAddress";
            this.txt_CodeSenderAddress.Size = new System.Drawing.Size(94, 21);
            this.txt_CodeSenderAddress.TabIndex = 18;
            this.txt_CodeSenderAddress.TextType = Shine.TextType.Number;
            // 
            // txt_EmpName
            // 
            this.txt_EmpName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_EmpName.Location = new System.Drawing.Point(77, 39);
            this.txt_EmpName.Name = "txt_EmpName";
            this.txt_EmpName.Size = new System.Drawing.Size(94, 21);
            this.txt_EmpName.TabIndex = 16;
            this.txt_EmpName.TextType = Shine.TextType.WithOutChar;
            this.txt_EmpName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_EmpName_KeyPress);
            // 
            // bt_EmpOverTime_Reset
            // 
            this.bt_EmpOverTime_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_EmpOverTime_Reset.Location = new System.Drawing.Point(118, 72);
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
            this.bt_EmpOverTime_Enquiries.Location = new System.Drawing.Point(18, 72);
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
            this.button.Text = "标识卡";
            this.button.UseVisualStyleBackColor = true;
            // 
            // cb
            // 
            this.cb.AutoSize = true;
            this.cb.Checked = true;
            this.cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb.Location = new System.Drawing.Point(16, 6);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(96, 16);
            this.cb.TabIndex = 3;
            this.cb.Text = "实时更新数据";
            this.cb.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtAll);
            this.groupBox1.Controls.Add(this.rbtNoSet);
            this.groupBox1.Controls.Add(this.rb_Equ);
            this.groupBox1.Controls.Add(this.rb_Emp);
            this.groupBox1.Location = new System.Drawing.Point(6, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标示卡匹配类型";
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Location = new System.Drawing.Point(108, 49);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(47, 16);
            this.rbtAll.TabIndex = 3;
            this.rbtAll.Text = "所有";
            this.rbtAll.UseVisualStyleBackColor = true;
            this.rbtAll.CheckedChanged += new System.EventHandler(this.rbtAll_CheckedChanged);
            // 
            // rbtNoSet
            // 
            this.rbtNoSet.AutoSize = true;
            this.rbtNoSet.Location = new System.Drawing.Point(28, 50);
            this.rbtNoSet.Name = "rbtNoSet";
            this.rbtNoSet.Size = new System.Drawing.Size(59, 16);
            this.rbtNoSet.TabIndex = 2;
            this.rbtNoSet.Text = "未配置";
            this.rbtNoSet.UseVisualStyleBackColor = true;
            this.rbtNoSet.CheckedChanged += new System.EventHandler(this.rbtNoSet_CheckedChanged);
            // 
            // rb_Equ
            // 
            this.rb_Equ.AutoSize = true;
            this.rb_Equ.Location = new System.Drawing.Point(108, 21);
            this.rb_Equ.Name = "rb_Equ";
            this.rb_Equ.Size = new System.Drawing.Size(47, 16);
            this.rb_Equ.TabIndex = 1;
            this.rb_Equ.Text = "设备";
            this.rb_Equ.UseVisualStyleBackColor = true;
            this.rb_Equ.CheckedChanged += new System.EventHandler(this.rb_Equ_CheckedChanged);
            // 
            // rb_Emp
            // 
            this.rb_Emp.AutoSize = true;
            this.rb_Emp.Checked = true;
            this.rb_Emp.Location = new System.Drawing.Point(28, 22);
            this.rb_Emp.Name = "rb_Emp";
            this.rb_Emp.Size = new System.Drawing.Size(47, 16);
            this.rb_Emp.TabIndex = 0;
            this.rb_Emp.TabStop = true;
            this.rb_Emp.Text = "人员";
            this.rb_Emp.UseVisualStyleBackColor = true;
            this.rb_Emp.CheckedChanged += new System.EventHandler(this.rb_Emp_CheckedChanged);
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToDeleteRows = false;
            this.dgv_Main.AllowUserToResizeRows = false;
            this.dgv_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.EnableHeadersVisualStyles = false;
            this.dgv_Main.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Main.RowHeadersVisible = false;
            this.dgv_Main.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(783, 459);
            this.dgv_Main.TabIndex = 3;
            this.dgv_Main.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Main_ColumnHeaderMouseClick);
            this.dgv_Main.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            this.dgv_Main.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Main_DataBindingComplete);
            // 
            // timer_Alarm
            // 
            this.timer_Alarm.Enabled = true;
            this.timer_Alarm.Interval = 3000;
            this.timer_Alarm.Tick += new System.EventHandler(this.timer_Alarm_Tick);
            // 
            // bt_Set
            // 
            this.bt_Set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Set.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Set.Location = new System.Drawing.Point(299, 4);
            this.bt_Set.Name = "bt_Set";
            this.bt_Set.Size = new System.Drawing.Size(54, 23);
            this.bt_Set.TabIndex = 4;
            this.bt_Set.Text = "设置";
            this.bt_Set.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Set.UseVisualStyleBackColor = true;
            this.bt_Set.Visible = false;
            this.bt_Set.Click += new System.EventHandler(this.bt_Set_Click);
            // 
            // cb_Show
            // 
            this.cb_Show.AutoSize = true;
            this.cb_Show.Location = new System.Drawing.Point(16, 28);
            this.cb_Show.Name = "cb_Show";
            this.cb_Show.Size = new System.Drawing.Size(108, 16);
            this.cb_Show.TabIndex = 4;
            this.cb_Show.Text = "显示上井口信息";
            this.cb_Show.UseVisualStyleBackColor = true;
            this.cb_Show.CheckedChanged += new System.EventHandler(this.cb_Show_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "上井口离开时间(分)";
            // 
            // shineTextBox1
            // 
            this.shineTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shineTextBox1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.shineTextBox1.Location = new System.Drawing.Point(123, 52);
            this.shineTextBox1.Name = "shineTextBox1";
            this.shineTextBox1.Size = new System.Drawing.Size(50, 21);
            this.shineTextBox1.TabIndex = 19;
            this.shineTextBox1.Text = "3";
            this.shineTextBox1.TextType = Shine.TextType.Number;
            // 
            // A_FrmRTStationHead
            // 
            this.AcceptButton = this.bt_EmpOverTime_Enquiries;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_FrmRTStationHead";
            this.TabText = "实时标识卡";
            this.Text = "实时读卡分站";
            this.Load += new System.EventHandler(this.A_FrmRTStationHead_Load);
            this.Shown += new System.EventHandler(this.A_FrmRTStationHead_Shown);
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
            this.pl_StaHead.ResumeLayout(false);
            this.tbc.ResumeLayout(false);
            this.tbp_Dept.ResumeLayout(false);
            this.tbp_StationHead.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_StaHead;
        private DegonControlLib.TreeViewControl tvc_StationHead;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TabControl tbc;
        private System.Windows.Forms.TabPage tbp_Dept;
        private System.Windows.Forms.TabPage tbp_StationHead;
        private DegonControlLib.TreeViewControl tvc_Dept;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Equ;
        private System.Windows.Forms.RadioButton rb_Emp;
        private System.Windows.Forms.Button bt_EmpOverTime_Reset;
        private System.Windows.Forms.Button bt_EmpOverTime_Enquiries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Shine.ShineTextBox txt_CodeSenderAddress;
        private Shine.ShineTextBox txt_EmpName;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Timer timer_Alarm;
        private System.Windows.Forms.Button bt_Set;
        private System.Windows.Forms.CheckBox cb_Show;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.RadioButton rbtNoSet;
        private System.Windows.Forms.Label label3;
        private Shine.ShineTextBox shineTextBox1;
    }
}