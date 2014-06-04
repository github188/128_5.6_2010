namespace KJ128NMainRun.A_Speed
{
    partial class A_FrmWalkConfig
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
            this.dmc_Info = new DegonControlLib.DrawerMainControl();
            this.pl_Walk = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbc_Info = new System.Windows.Forms.TabControl();
            this.tp_StaHead_Begin = new System.Windows.Forms.TabPage();
            this.tvc_BeginStaHead_Select = new DegonControlLib.TreeViewControl();
            this.tp_StaHead_End = new System.Windows.Forms.TabPage();
            this.tvc_EndStaHead_Select = new DegonControlLib.TreeViewControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bt_Walk = new System.Windows.Forms.Button();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.cl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.dmc_Info.SuspendLayout();
            this.pl_Walk.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tbc_Info.SuspendLayout();
            this.tp_StaHead_Begin.SuspendLayout();
            this.tp_StaHead_End.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 401);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 122);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.dmc_Info);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 401);
            // 
            // btnAdd
            // 
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Size = new System.Drawing.Size(101, 12);
            this.lblMainTitle.Text = "行走异常配置信息";
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
            // dmc_Info
            // 
            this.dmc_Info.Controls.Add(this.pl_Walk);
            this.dmc_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dmc_Info.Location = new System.Drawing.Point(0, 0);
            this.dmc_Info.MainHeight = 100;
            this.dmc_Info.Name = "dmc_Info";
            this.dmc_Info.PartTime = 50;
            this.dmc_Info.PType = DegonControlLib.PartType.Time;
            this.dmc_Info.Size = new System.Drawing.Size(196, 397);
            this.dmc_Info.SplitHeight = 1;
            this.dmc_Info.TabIndex = 2;
            this.dmc_Info.TitleHeight = 25;
            // 
            // pl_Walk
            // 
            this.pl_Walk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_Walk.Controls.Add(this.panel3);
            this.pl_Walk.Controls.Add(this.panel4);
            this.pl_Walk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_Walk.Location = new System.Drawing.Point(0, 0);
            this.pl_Walk.Name = "pl_Walk";
            this.pl_Walk.Size = new System.Drawing.Size(196, 397);
            this.pl_Walk.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbc_Info);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(194, 370);
            this.panel3.TabIndex = 1;
            // 
            // tbc_Info
            // 
            this.tbc_Info.Controls.Add(this.tp_StaHead_Begin);
            this.tbc_Info.Controls.Add(this.tp_StaHead_End);
            this.tbc_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc_Info.Location = new System.Drawing.Point(3, 3);
            this.tbc_Info.Name = "tbc_Info";
            this.tbc_Info.SelectedIndex = 0;
            this.tbc_Info.Size = new System.Drawing.Size(188, 364);
            this.tbc_Info.TabIndex = 14;
            this.tbc_Info.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbc_Info_Selecting);
            // 
            // tp_StaHead_Begin
            // 
            this.tp_StaHead_Begin.Controls.Add(this.tvc_BeginStaHead_Select);
            this.tp_StaHead_Begin.Location = new System.Drawing.Point(4, 21);
            this.tp_StaHead_Begin.Name = "tp_StaHead_Begin";
            this.tp_StaHead_Begin.Padding = new System.Windows.Forms.Padding(3);
            this.tp_StaHead_Begin.Size = new System.Drawing.Size(180, 339);
            this.tp_StaHead_Begin.TabIndex = 0;
            this.tp_StaHead_Begin.Text = "起始分站";
            this.tp_StaHead_Begin.UseVisualStyleBackColor = true;
            // 
            // tvc_BeginStaHead_Select
            // 
            this.tvc_BeginStaHead_Select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_BeginStaHead_Select.Location = new System.Drawing.Point(3, 3);
            this.tvc_BeginStaHead_Select.Name = "tvc_BeginStaHead_Select";
            this.tvc_BeginStaHead_Select.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_BeginStaHead_Select.Size = new System.Drawing.Size(174, 333);
            this.tvc_BeginStaHead_Select.TabIndex = 1;
            this.tvc_BeginStaHead_Select.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_BeginStaHead_Select_AfterSelect);
            // 
            // tp_StaHead_End
            // 
            this.tp_StaHead_End.Controls.Add(this.tvc_EndStaHead_Select);
            this.tp_StaHead_End.Location = new System.Drawing.Point(4, 21);
            this.tp_StaHead_End.Name = "tp_StaHead_End";
            this.tp_StaHead_End.Padding = new System.Windows.Forms.Padding(3);
            this.tp_StaHead_End.Size = new System.Drawing.Size(180, 339);
            this.tp_StaHead_End.TabIndex = 1;
            this.tp_StaHead_End.Text = "终止分站";
            this.tp_StaHead_End.UseVisualStyleBackColor = true;
            // 
            // tvc_EndStaHead_Select
            // 
            this.tvc_EndStaHead_Select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_EndStaHead_Select.Location = new System.Drawing.Point(3, 3);
            this.tvc_EndStaHead_Select.Name = "tvc_EndStaHead_Select";
            this.tvc_EndStaHead_Select.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_EndStaHead_Select.Size = new System.Drawing.Size(174, 333);
            this.tvc_EndStaHead_Select.TabIndex = 1;
            this.tvc_EndStaHead_Select.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_EndStaHead_Select_AfterSelect);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.bt_Walk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 25);
            this.panel4.TabIndex = 0;
            // 
            // bt_Walk
            // 
            this.bt_Walk.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Walk.Location = new System.Drawing.Point(0, 0);
            this.bt_Walk.Name = "bt_Walk";
            this.bt_Walk.Size = new System.Drawing.Size(194, 25);
            this.bt_Walk.TabIndex = 0;
            this.bt_Walk.Text = "行走异常";
            this.bt_Walk.UseVisualStyleBackColor = true;
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
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
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl});
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
            // timer_Refresh
            // 
            this.timer_Refresh.Interval = 400;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // A_FrmWalkConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_FrmWalkConfig";
            this.TabText = "行走异常配置信息";
            this.Text = "行走异常配置信息";
            this.Load += new System.EventHandler(this.A_FrmWalkConfig_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_FrmWalkConfig_FormClosing);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.drawerLeftMain.ResumeLayout(false);
            this.panelMainMain.ResumeLayout(false);
            this.dmc_Info.ResumeLayout(false);
            this.pl_Walk.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tbc_Info.ResumeLayout(false);
            this.tp_StaHead_Begin.ResumeLayout(false);
            this.tp_StaHead_End.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DegonControlLib.DrawerMainControl dmc_Info;
        private System.Windows.Forms.Panel pl_Walk;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tbc_Info;
        private System.Windows.Forms.TabPage tp_StaHead_Begin;
        private DegonControlLib.TreeViewControl tvc_BeginStaHead_Select;
        private System.Windows.Forms.TabPage tp_StaHead_End;
        private DegonControlLib.TreeViewControl tvc_EndStaHead_Select;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button bt_Walk;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cl;
        private System.Windows.Forms.Timer timer_Refresh;
    }
}