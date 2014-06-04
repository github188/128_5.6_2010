namespace KJ128NMainRun.AssociateWithEmp
{
    partial class FrmAssociateManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlAssociate = new System.Windows.Forms.TabControl();
            this.tabPageStation = new System.Windows.Forms.TabPage();
            this.treeViewControlStation = new DegonControlLib.TreeViewControl();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.beginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationHeadAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationHeadPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpScealBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpScealEndData = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpName1 = new Shine.ShineTextBox();
            this.txtEmpName2 = new Shine.ShineTextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSecal = new System.Windows.Forms.Button();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControlAssociate.SuspendLayout();
            this.tabPageStation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.btnReset);
            this.panelLeftBottom.Controls.Add(this.btnSecal);
            this.panelLeftBottom.Controls.Add(this.txtEmpName2);
            this.panelLeftBottom.Controls.Add(this.txtEmpName1);
            this.panelLeftBottom.Controls.Add(this.label4);
            this.panelLeftBottom.Controls.Add(this.label3);
            this.panelLeftBottom.Controls.Add(this.dtpScealEndData);
            this.panelLeftBottom.Controls.Add(this.label2);
            this.panelLeftBottom.Controls.Add(this.label1);
            this.panelLeftBottom.Controls.Add(this.dtpScealBeginDate);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.tabControlAssociate);
            this.drawerLeftMain.Controls.Add(this.panel1);
            // 
            // btnAdd
            // 
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnLaws
            // 
            this.btnLaws.Enabled = false;
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
            this.cmbSelectCounts.SelectedIndexChanged += new System.EventHandler(this.cmbSelectCounts_SelectedIndexChanged);
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
            // panelMainMain
            // 
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
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 25);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "异地交接班配置";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabControlAssociate
            // 
            this.tabControlAssociate.Controls.Add(this.tabPageStation);
            this.tabControlAssociate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAssociate.Location = new System.Drawing.Point(0, 25);
            this.tabControlAssociate.Name = "tabControlAssociate";
            this.tabControlAssociate.SelectedIndex = 0;
            this.tabControlAssociate.Size = new System.Drawing.Size(196, 314);
            this.tabControlAssociate.TabIndex = 1;
            // 
            // tabPageStation
            // 
            this.tabPageStation.Controls.Add(this.treeViewControlStation);
            this.tabPageStation.Location = new System.Drawing.Point(4, 21);
            this.tabPageStation.Name = "tabPageStation";
            this.tabPageStation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStation.Size = new System.Drawing.Size(188, 289);
            this.tabPageStation.TabIndex = 0;
            this.tabPageStation.Text = "分站";
            this.tabPageStation.UseVisualStyleBackColor = true;
            // 
            // treeViewControlStation
            // 
            this.treeViewControlStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewControlStation.Location = new System.Drawing.Point(3, 3);
            this.treeViewControlStation.Name = "treeViewControlStation";
            this.treeViewControlStation.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.treeViewControlStation.Size = new System.Drawing.Size(182, 283);
            this.treeViewControlStation.TabIndex = 0;
            this.treeViewControlStation.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewControlStation_NodeMouseClick);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.beginTime,
            this.endTime,
            this.stationAddress,
            this.stationHeadAddress,
            this.stationHeadPlace,
            this.empName1,
            this.empName2,
            this.id});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(783, 459);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            this.dgvMain.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            this.dgvMain.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMain_DataBindingComplete);
            // 
            // colSelect
            // 
            this.colSelect.FalseValue = "False";
            this.colSelect.FillWeight = 30F;
            this.colSelect.HeaderText = "";
            this.colSelect.Name = "colSelect";
            this.colSelect.ReadOnly = true;
            this.colSelect.TrueValue = "True";
            // 
            // beginTime
            // 
            this.beginTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.beginTime.DataPropertyName = "beginTime";
            dataGridViewCellStyle6.Format = "G";
            dataGridViewCellStyle6.NullValue = null;
            this.beginTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.beginTime.HeaderText = "开始时间";
            this.beginTime.MinimumWidth = 200;
            this.beginTime.Name = "beginTime";
            this.beginTime.ReadOnly = true;
            // 
            // endTime
            // 
            this.endTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.endTime.DataPropertyName = "endTime";
            dataGridViewCellStyle7.Format = "G";
            dataGridViewCellStyle7.NullValue = null;
            this.endTime.DefaultCellStyle = dataGridViewCellStyle7;
            this.endTime.HeaderText = "结束时间";
            this.endTime.MinimumWidth = 200;
            this.endTime.Name = "endTime";
            this.endTime.ReadOnly = true;
            // 
            // stationAddress
            // 
            this.stationAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stationAddress.DataPropertyName = "stationAddress";
            this.stationAddress.HeaderText = "传输分站";
            this.stationAddress.MinimumWidth = 80;
            this.stationAddress.Name = "stationAddress";
            this.stationAddress.ReadOnly = true;
            // 
            // stationHeadAddress
            // 
            this.stationHeadAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stationHeadAddress.DataPropertyName = "stationHeadAddress";
            this.stationHeadAddress.HeaderText = "读卡分站";
            this.stationHeadAddress.MinimumWidth = 80;
            this.stationHeadAddress.Name = "stationHeadAddress";
            this.stationHeadAddress.ReadOnly = true;
            // 
            // stationHeadPlace
            // 
            this.stationHeadPlace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stationHeadPlace.DataPropertyName = "stationHeadPlace";
            this.stationHeadPlace.HeaderText = "交接地点";
            this.stationHeadPlace.MinimumWidth = 200;
            this.stationHeadPlace.Name = "stationHeadPlace";
            this.stationHeadPlace.ReadOnly = true;
            // 
            // empName1
            // 
            this.empName1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.empName1.DataPropertyName = "empName1";
            this.empName1.HeaderText = "交接人员1";
            this.empName1.MinimumWidth = 150;
            this.empName1.Name = "empName1";
            this.empName1.ReadOnly = true;
            // 
            // empName2
            // 
            this.empName2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.empName2.DataPropertyName = "empName2";
            this.empName2.HeaderText = "交接人员2";
            this.empName2.MinimumWidth = 150;
            this.empName2.Name = "empName2";
            this.empName2.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // dtpScealBeginDate
            // 
            this.dtpScealBeginDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpScealBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScealBeginDate.Location = new System.Drawing.Point(74, 15);
            this.dtpScealBeginDate.Name = "dtpScealBeginDate";
            this.dtpScealBeginDate.Size = new System.Drawing.Size(120, 21);
            this.dtpScealBeginDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束日期：";
            // 
            // dtpScealEndData
            // 
            this.dtpScealEndData.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpScealEndData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScealEndData.Location = new System.Drawing.Point(74, 46);
            this.dtpScealEndData.Name = "dtpScealEndData";
            this.dtpScealEndData.Size = new System.Drawing.Size(119, 21);
            this.dtpScealEndData.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "员工姓名1：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "员工姓名2：";
            // 
            // txtEmpName1
            // 
            this.txtEmpName1.Location = new System.Drawing.Point(74, 77);
            this.txtEmpName1.MaxLength = 20;
            this.txtEmpName1.Name = "txtEmpName1";
            this.txtEmpName1.Size = new System.Drawing.Size(118, 21);
            this.txtEmpName1.TabIndex = 6;
            this.txtEmpName1.TextType = Shine.TextType.WithOutChar;
            this.txtEmpName1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName1_KeyPress);
            // 
            // txtEmpName2
            // 
            this.txtEmpName2.Location = new System.Drawing.Point(74, 108);
            this.txtEmpName2.MaxLength = 20;
            this.txtEmpName2.Name = "txtEmpName2";
            this.txtEmpName2.Size = new System.Drawing.Size(118, 21);
            this.txtEmpName2.TabIndex = 7;
            this.txtEmpName2.TextType = Shine.TextType.WithOutChar;
            this.txtEmpName2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName2_KeyPress);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(101, 146);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSecal
            // 
            this.btnSecal.Location = new System.Drawing.Point(19, 146);
            this.btnSecal.Name = "btnSecal";
            this.btnSecal.Size = new System.Drawing.Size(75, 23);
            this.btnSecal.TabIndex = 8;
            this.btnSecal.Text = "查询";
            this.btnSecal.UseVisualStyleBackColor = true;
            this.btnSecal.Click += new System.EventHandler(this.btnSecal_Click);
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // FrmAssociateManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "FrmAssociateManage";
            this.TabText = "异地交接班配置";
            this.Text = "异地交接班配置";
            this.Load += new System.EventHandler(this.FrmAssociateManage_Load);
            this.Activated += new System.EventHandler(this.FrmAssociateManage_Activated);
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
            this.panel1.ResumeLayout(false);
            this.tabControlAssociate.ResumeLayout(false);
            this.tabPageStation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAssociate;
        private System.Windows.Forms.TabPage tabPageStation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpScealBeginDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpScealEndData;
        private System.Windows.Forms.Label label2;
        private Shine.ShineTextBox txtEmpName1;
        private Shine.ShineTextBox txtEmpName2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSecal;
        private DegonControlLib.TreeViewControl treeViewControlStation;
        private System.Windows.Forms.Timer timer_Refresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn beginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationHeadAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationHeadPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn empName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn empName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}