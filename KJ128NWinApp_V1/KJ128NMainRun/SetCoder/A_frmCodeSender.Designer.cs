namespace KJ128NMainRun.SetCoder
{
    partial class A_frmCodeSender
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("配置");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("未配置");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("所有", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnReSet = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbMch = new System.Windows.Forms.RadioButton();
            this.rdbEmp = new System.Windows.Forms.RadioButton();
            this.txtCodeSender = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trvDept = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCodesender = new System.Windows.Forms.Button();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCodeSearch = new System.Windows.Forms.Button();
            this.txtCode = new Shine.ShineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trvCodesender = new System.Windows.Forms.TreeView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnCode = new System.Windows.Forms.Button();
            this.dgvCodeSenderSet = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeSenderSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.label12);
            this.panelLeftBottom.Controls.Add(this.label11);
            this.panelLeftBottom.Controls.Add(this.label10);
            this.panelLeftBottom.Controls.Add(this.label4);
            this.panelLeftBottom.Controls.Add(this.label1);
            this.panelLeftBottom.Controls.Add(this.label5);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(422, 3);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Size = new System.Drawing.Size(65, 12);
            this.lblMainTitle.Text = "标识卡配置";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(482, 3);
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(601, 3);
            this.btnLaws.Click += new System.EventHandler(this.btnLaws_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(541, 3);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(601, 3);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.SelectedIndexChanged += new System.EventHandler(this.cmbSelectCounts_SelectedIndexChanged);
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
            this.txtSkipPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSkipPage_KeyPress);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // btnDownPage
            // 
            this.btnDownPage.Click += new System.EventHandler(this.btnDownPage_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Click += new System.EventHandler(this.btnUpPage_Click);
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.pnl2);
            this.panelMainMain.Controls.Add(this.pnl1);
            this.panelMainMain.Controls.Add(this.dgvCodeSenderSet);
            // 
            // btnConfigModel
            // 
            this.btnConfigModel.Click += new System.EventHandler(this.btnConfigModel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.panel11);
            this.pnl1.Controls.Add(this.panel2);
            this.pnl1.Location = new System.Drawing.Point(91, 44);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(200, 287);
            this.pnl1.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnReSet);
            this.panel11.Controls.Add(this.btnSearch);
            this.panel11.Controls.Add(this.groupBox1);
            this.panel11.Controls.Add(this.txtCodeSender);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.trvDept);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 25);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 262);
            this.panel11.TabIndex = 9;
            // 
            // btnReSet
            // 
            this.btnReSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReSet.Location = new System.Drawing.Point(115, 229);
            this.btnReSet.Name = "btnReSet";
            this.btnReSet.Size = new System.Drawing.Size(59, 23);
            this.btnReSet.TabIndex = 12;
            this.btnReSet.Text = "重置";
            this.btnReSet.UseVisualStyleBackColor = true;
            this.btnReSet.Click += new System.EventHandler(this.btnReSet_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(27, 229);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.rdbMch);
            this.groupBox1.Controls.Add(this.rdbEmp);
            this.groupBox1.Location = new System.Drawing.Point(6, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 49);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置类型";
            // 
            // rdbMch
            // 
            this.rdbMch.AutoSize = true;
            this.rdbMch.Location = new System.Drawing.Point(121, 21);
            this.rdbMch.Name = "rdbMch";
            this.rdbMch.Size = new System.Drawing.Size(47, 16);
            this.rdbMch.TabIndex = 1;
            this.rdbMch.Text = "设备";
            this.rdbMch.UseVisualStyleBackColor = true;
            // 
            // rdbEmp
            // 
            this.rdbEmp.AutoSize = true;
            this.rdbEmp.Checked = true;
            this.rdbEmp.Location = new System.Drawing.Point(21, 21);
            this.rdbEmp.Name = "rdbEmp";
            this.rdbEmp.Size = new System.Drawing.Size(47, 16);
            this.rdbEmp.TabIndex = 0;
            this.rdbEmp.TabStop = true;
            this.rdbEmp.Text = "人员";
            this.rdbEmp.UseVisualStyleBackColor = true;
            this.rdbEmp.CheckedChanged += new System.EventHandler(this.rdbEmp_CheckedChanged);
            // 
            // txtCodeSender
            // 
            this.txtCodeSender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodeSender.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCodeSender.Location = new System.Drawing.Point(60, 147);
            this.txtCodeSender.MaxLength = 5;
            this.txtCodeSender.Name = "txtCodeSender";
            this.txtCodeSender.Size = new System.Drawing.Size(128, 21);
            this.txtCodeSender.TabIndex = 9;
            this.txtCodeSender.TextType = Shine.TextType.Number;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "标识卡:";
            // 
            // trvDept
            // 
            this.trvDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvDept.Location = new System.Drawing.Point(6, 5);
            this.trvDept.Name = "trvDept";
            this.trvDept.Size = new System.Drawing.Size(189, 130);
            this.trvDept.TabIndex = 7;
            this.trvDept.Enter += new System.EventHandler(this.trvDept_Enter);
            this.trvDept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDept_AfterSelect);
            this.trvDept.Leave += new System.EventHandler(this.trvDept_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCodesender);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 25);
            this.panel2.TabIndex = 8;
            // 
            // btnCodesender
            // 
            this.btnCodesender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCodesender.Location = new System.Drawing.Point(0, 0);
            this.btnCodesender.Name = "btnCodesender";
            this.btnCodesender.Size = new System.Drawing.Size(200, 25);
            this.btnCodesender.TabIndex = 7;
            this.btnCodesender.Text = "标识卡配置";
            this.btnCodesender.UseVisualStyleBackColor = true;
            this.btnCodesender.Click += new System.EventHandler(this.btnCodesender_Click);
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.panel10);
            this.pnl2.Controls.Add(this.panel9);
            this.pnl2.Location = new System.Drawing.Point(356, 44);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(200, 287);
            this.pnl2.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.button2);
            this.panel10.Controls.Add(this.btnCodeSearch);
            this.panel10.Controls.Add(this.txtCode);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.trvCodesender);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 25);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(200, 262);
            this.panel10.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(111, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCodeSearch
            // 
            this.btnCodeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCodeSearch.Location = new System.Drawing.Point(29, 229);
            this.btnCodeSearch.Name = "btnCodeSearch";
            this.btnCodeSearch.Size = new System.Drawing.Size(64, 23);
            this.btnCodeSearch.TabIndex = 10;
            this.btnCodeSearch.Text = "查询";
            this.btnCodeSearch.UseVisualStyleBackColor = true;
            this.btnCodeSearch.Click += new System.EventHandler(this.btnCodeSearch_Click);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCode.Location = new System.Drawing.Point(60, 202);
            this.txtCode.MaxLength = 5;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(133, 21);
            this.txtCode.TabIndex = 9;
            this.txtCode.TextType = Shine.TextType.Number;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "标识卡:";
            // 
            // trvCodesender
            // 
            this.trvCodesender.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvCodesender.Location = new System.Drawing.Point(6, 5);
            this.trvCodesender.Name = "trvCodesender";
            treeNode1.Name = "节点1";
            treeNode1.Text = "配置";
            treeNode2.Name = "";
            treeNode2.Text = "未配置";
            treeNode3.Name = "all";
            treeNode3.Text = "所有";
            this.trvCodesender.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.trvCodesender.Size = new System.Drawing.Size(187, 191);
            this.trvCodesender.TabIndex = 7;
            this.trvCodesender.Enter += new System.EventHandler(this.trvCodesender_Enter);
            this.trvCodesender.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvCodesender_AfterSelect);
            this.trvCodesender.Leave += new System.EventHandler(this.trvCodesender_Leave);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnCode);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(200, 25);
            this.panel9.TabIndex = 8;
            // 
            // btnCode
            // 
            this.btnCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCode.Location = new System.Drawing.Point(0, 0);
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(200, 25);
            this.btnCode.TabIndex = 7;
            this.btnCode.Text = "标识卡";
            this.btnCode.UseVisualStyleBackColor = true;
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            // 
            // dgvCodeSenderSet
            // 
            this.dgvCodeSenderSet.AllowUserToAddRows = false;
            this.dgvCodeSenderSet.AllowUserToDeleteRows = false;
            this.dgvCodeSenderSet.AllowUserToOrderColumns = true;
            this.dgvCodeSenderSet.AllowUserToResizeRows = false;
            this.dgvCodeSenderSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCodeSenderSet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCodeSenderSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCodeSenderSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvCodeSenderSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCodeSenderSet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgvCodeSenderSet.Location = new System.Drawing.Point(0, 0);
            this.dgvCodeSenderSet.Name = "dgvCodeSenderSet";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCodeSenderSet.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCodeSenderSet.RowHeadersVisible = false;
            this.dgvCodeSenderSet.RowTemplate.Height = 23;
            this.dgvCodeSenderSet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodeSenderSet.Size = new System.Drawing.Size(783, 459);
            this.dgvCodeSenderSet.TabIndex = 4;
            this.dgvCodeSenderSet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodeSenderSet_CellClick);
            this.dgvCodeSenderSet.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            this.dgvCodeSenderSet.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCodeSenderSet_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.FalseValue = "false";
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "true";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(30, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "标识卡配置流程：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(31, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "第二步:匹配人员和标识卡";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(31, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "第一步:新增标识卡";
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Interval = 400;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(35, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "注意：";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(31, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "员工在更换卡时请使用同一";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(31, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "号码,以免影响考勤统计！";
            // 
            // A_frmCodeSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_frmCodeSender";
            this.TabText = "标识卡配置";
            this.Text = "A_frmCodeSender";
            this.Load += new System.EventHandler(this.A_frmCodeSender_Load);
            this.Activated += new System.EventHandler(this.A_frmCodeSender_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_frmCodeSender_FormClosing);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            this.panelLeftBottom.PerformLayout();
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.panelMainMain.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeSenderSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnReSet;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbMch;
        private System.Windows.Forms.RadioButton rdbEmp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView trvDept;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCodesender;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCodeSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView trvCodesender;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnCode;
        private System.Windows.Forms.DataGridView dgvCodeSenderSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Shine.ShineTextBox txtCodeSender;
        private Shine.ShineTextBox txtCode;
        private System.Windows.Forms.Timer timer_Refresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
    }
}