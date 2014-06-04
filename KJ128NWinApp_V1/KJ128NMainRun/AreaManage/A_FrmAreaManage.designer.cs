namespace KJ128NMainRun
{
    partial class A_FrmAreaManage
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
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.cl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pl_TerType = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tvc_TerType_TerType = new DegonControlLib.TreeViewControl();
            this.panel14 = new System.Windows.Forms.Panel();
            this.bt_TerTypeInfo = new System.Windows.Forms.Button();
            this.dmc_Info = new DegonControlLib.DrawerMainControl();
            this.pl_TerSet = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tvc_TerSet_TerSet = new DegonControlLib.TreeViewControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bt_TerSet = new System.Windows.Forms.Button();
            this.pl_TerInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvc_Ter_Ter = new DegonControlLib.TreeViewControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_TerInfo = new System.Windows.Forms.Button();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pl_Swork = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.trvTer = new DegonControlLib.TreeViewControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_SWorkType = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.pl_TerType.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.dmc_Info.SuspendLayout();
            this.pl_TerSet.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pl_TerInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pl_Swork.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.label5);
            this.panelLeftBottom.Controls.Add(this.label3);
            this.panelLeftBottom.Controls.Add(this.label4);
            this.panelLeftBottom.Controls.Add(this.label10);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.dmc_Info);
            // 
            // btnAdd
            // 
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Size = new System.Drawing.Size(29, 12);
            this.lblMainTitle.Text = "区域";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnLaws
            // 
            this.btnLaws.Click += new System.EventHandler(this.btnLaws_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.DropDownClosed += new System.EventHandler(this.cmbSelectCounts_DropDownClosed);
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSkipPage_KeyDown);
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
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
            // lblCounts
            // 
            this.lblCounts.Size = new System.Drawing.Size(59, 12);
            this.lblCounts.Text = "共 456 人";
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.pl_Swork);
            this.panelMainMain.Controls.Add(this.pl_TerInfo);
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
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl});
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.EnableHeadersVisualStyles = false;
            this.dgv_Main.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.MultiSelect = false;
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
            this.dgv_Main.TabIndex = 1;
            this.dgv_Main.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellDoubleClick);
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            this.dgv_Main.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            this.dgv_Main.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Main_DataBindingComplete);
            // 
            // cl
            // 
            this.cl.FalseValue = "0";
            this.cl.FillWeight = 30F;
            this.cl.HeaderText = "";
            this.cl.IndeterminateValue = "2";
            this.cl.Name = "cl";
            this.cl.ReadOnly = true;
            this.cl.TrueValue = "1";
            // 
            // pl_TerType
            // 
            this.pl_TerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_TerType.Controls.Add(this.panel13);
            this.pl_TerType.Controls.Add(this.panel14);
            this.pl_TerType.Location = new System.Drawing.Point(2, 304);
            this.pl_TerType.Name = "pl_TerType";
            this.pl_TerType.Size = new System.Drawing.Size(192, 34);
            this.pl_TerType.TabIndex = 8;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tvc_TerType_TerType);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 30);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(3);
            this.panel13.Size = new System.Drawing.Size(190, 2);
            this.panel13.TabIndex = 1;
            // 
            // tvc_TerType_TerType
            // 
            this.tvc_TerType_TerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_TerType_TerType.Location = new System.Drawing.Point(3, 3);
            this.tvc_TerType_TerType.Name = "tvc_TerType_TerType";
            this.tvc_TerType_TerType.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_TerType_TerType.Size = new System.Drawing.Size(184, 0);
            this.tvc_TerType_TerType.TabIndex = 1;
            this.tvc_TerType_TerType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_TerType_TerType_AfterSelect);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.bt_TerTypeInfo);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(190, 30);
            this.panel14.TabIndex = 0;
            // 
            // bt_TerTypeInfo
            // 
            this.bt_TerTypeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_TerTypeInfo.Location = new System.Drawing.Point(0, 0);
            this.bt_TerTypeInfo.Name = "bt_TerTypeInfo";
            this.bt_TerTypeInfo.Size = new System.Drawing.Size(190, 30);
            this.bt_TerTypeInfo.TabIndex = 0;
            this.bt_TerTypeInfo.Text = "区域类型";
            this.bt_TerTypeInfo.UseVisualStyleBackColor = true;
            this.bt_TerTypeInfo.Click += new System.EventHandler(this.bt_TerTypeInfo_Click);
            // 
            // dmc_Info
            // 
            this.dmc_Info.Controls.Add(this.pl_TerSet);
            this.dmc_Info.Controls.Add(this.pl_TerType);
            this.dmc_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dmc_Info.Location = new System.Drawing.Point(0, 0);
            this.dmc_Info.MainHeight = 100;
            this.dmc_Info.Name = "dmc_Info";
            this.dmc_Info.PartTime = 50;
            this.dmc_Info.PType = DegonControlLib.PartType.Time;
            this.dmc_Info.Size = new System.Drawing.Size(196, 339);
            this.dmc_Info.SplitHeight = 1;
            this.dmc_Info.TabIndex = 0;
            this.dmc_Info.TitleHeight = 25;
            // 
            // pl_TerSet
            // 
            this.pl_TerSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_TerSet.Controls.Add(this.panel3);
            this.pl_TerSet.Controls.Add(this.panel4);
            this.pl_TerSet.Location = new System.Drawing.Point(3, 0);
            this.pl_TerSet.Name = "pl_TerSet";
            this.pl_TerSet.Size = new System.Drawing.Size(193, 260);
            this.pl_TerSet.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tvc_TerSet_TerSet);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(191, 228);
            this.panel3.TabIndex = 1;
            // 
            // tvc_TerSet_TerSet
            // 
            this.tvc_TerSet_TerSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_TerSet_TerSet.Location = new System.Drawing.Point(3, 3);
            this.tvc_TerSet_TerSet.Name = "tvc_TerSet_TerSet";
            this.tvc_TerSet_TerSet.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_TerSet_TerSet.Size = new System.Drawing.Size(185, 222);
            this.tvc_TerSet_TerSet.TabIndex = 1;
            this.tvc_TerSet_TerSet.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_TerSet_TerSet_AfterSelect);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.bt_TerSet);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(191, 30);
            this.panel4.TabIndex = 0;
            // 
            // bt_TerSet
            // 
            this.bt_TerSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_TerSet.Location = new System.Drawing.Point(0, 0);
            this.bt_TerSet.Name = "bt_TerSet";
            this.bt_TerSet.Size = new System.Drawing.Size(191, 30);
            this.bt_TerSet.TabIndex = 0;
            this.bt_TerSet.Text = "区域范围";
            this.bt_TerSet.UseVisualStyleBackColor = true;
            this.bt_TerSet.Click += new System.EventHandler(this.bt_TerSet_Click);
            // 
            // pl_TerInfo
            // 
            this.pl_TerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_TerInfo.Controls.Add(this.panel1);
            this.pl_TerInfo.Controls.Add(this.panel2);
            this.pl_TerInfo.Location = new System.Drawing.Point(51, 112);
            this.pl_TerInfo.Name = "pl_TerInfo";
            this.pl_TerInfo.Size = new System.Drawing.Size(191, 133);
            this.pl_TerInfo.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvc_Ter_Ter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(189, 101);
            this.panel1.TabIndex = 1;
            // 
            // tvc_Ter_Ter
            // 
            this.tvc_Ter_Ter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_Ter_Ter.Location = new System.Drawing.Point(3, 3);
            this.tvc_Ter_Ter.Name = "tvc_Ter_Ter";
            this.tvc_Ter_Ter.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_Ter_Ter.Size = new System.Drawing.Size(183, 95);
            this.tvc_Ter_Ter.TabIndex = 1;
            this.tvc_Ter_Ter.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_Ter_Ter_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_TerInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 30);
            this.panel2.TabIndex = 0;
            // 
            // bt_TerInfo
            // 
            this.bt_TerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_TerInfo.Location = new System.Drawing.Point(0, 0);
            this.bt_TerInfo.Name = "bt_TerInfo";
            this.bt_TerInfo.Size = new System.Drawing.Size(189, 30);
            this.bt_TerInfo.TabIndex = 0;
            this.bt_TerInfo.Text = "区域信息";
            this.bt_TerInfo.UseVisualStyleBackColor = true;
            this.bt_TerInfo.Click += new System.EventHandler(this.bt_TerInfo_Click);
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Interval = 400;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(26, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "第三步：配置区域范围";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(26, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "第二步：添加区域名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(39, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "添加区域流程：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(26, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "第一步：添加区域类型";
            // 
            // pl_Swork
            // 
            this.pl_Swork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_Swork.Controls.Add(this.panel6);
            this.pl_Swork.Controls.Add(this.panel7);
            this.pl_Swork.Location = new System.Drawing.Point(295, 99);
            this.pl_Swork.Name = "pl_Swork";
            this.pl_Swork.Size = new System.Drawing.Size(193, 260);
            this.pl_Swork.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.trvTer);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 30);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3);
            this.panel6.Size = new System.Drawing.Size(191, 228);
            this.panel6.TabIndex = 1;
            // 
            // trvTer
            // 
            this.trvTer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTer.Location = new System.Drawing.Point(3, 3);
            this.trvTer.Name = "trvTer";
            this.trvTer.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.trvTer.Size = new System.Drawing.Size(185, 222);
            this.trvTer.TabIndex = 1;
            this.trvTer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTer_AfterSelect);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_SWorkType);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(191, 30);
            this.panel7.TabIndex = 0;
            // 
            // btn_SWorkType
            // 
            this.btn_SWorkType.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_SWorkType.Location = new System.Drawing.Point(0, 0);
            this.btn_SWorkType.Name = "btn_SWorkType";
            this.btn_SWorkType.Size = new System.Drawing.Size(191, 30);
            this.btn_SWorkType.TabIndex = 0;
            this.btn_SWorkType.Text = "特殊工种区域配置";
            this.btn_SWorkType.UseVisualStyleBackColor = true;
            this.btn_SWorkType.Click += new System.EventHandler(this.btn_SWorkType_Click);
            // 
            // A_FrmAreaManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_FrmAreaManage";
            this.TabText = "区域";
            this.Text = "区域";
            this.Load += new System.EventHandler(this.A_FrmAreaManage_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_FrmAreaManage_FormClosing);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.pl_TerType.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.dmc_Info.ResumeLayout(false);
            this.pl_TerSet.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pl_TerInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pl_Swork.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Panel pl_TerType;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button bt_TerTypeInfo;
        private DegonControlLib.TreeViewControl tvc_TerType_TerType;
        private DegonControlLib.DrawerMainControl dmc_Info;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cl;
        private System.Windows.Forms.Panel pl_TerInfo;
        private System.Windows.Forms.Panel panel1;
        private DegonControlLib.TreeViewControl tvc_Ter_Ter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_TerInfo;
        private System.Windows.Forms.Panel pl_TerSet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button bt_TerSet;
        private DegonControlLib.TreeViewControl tvc_TerSet_TerSet;
        public System.Windows.Forms.Timer timer_Refresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pl_Swork;
        private System.Windows.Forms.Panel panel6;
        private DegonControlLib.TreeViewControl trvTer;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_SWorkType;
    }
}