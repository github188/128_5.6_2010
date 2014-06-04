namespace KJ128NMainRun.AssociateWithEmp
{
    partial class FrmHisAssociateInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.colBeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStationHeadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStationHeadPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlAssociate = new System.Windows.Forms.TabControl();
            this.tabPageStation = new System.Windows.Forms.TabPage();
            this.treeViewControlStation = new DegonControlLib.TreeViewControl();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSecal = new System.Windows.Forms.Button();
            this.txtEmpName2 = new Shine.ShineTextBox();
            this.txtEmpName1 = new Shine.ShineTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpScealEndData = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpScealBeginDate = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControlAssociate.SuspendLayout();
            this.tabPageStation.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.checkBox1);
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
            this.btnAdd.Visible = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Visible = false;
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
            this.colBeginTime,
            this.colEndTime,
            this.colStation,
            this.colStationHeadID,
            this.colStationHeadPlace,
            this.colEmpName1,
            this.colState1,
            this.colEmpName2,
            this.colState2,
            this.colID});
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
            this.dgvMain.TabIndex = 1;
            // 
            // colBeginTime
            // 
            this.colBeginTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBeginTime.DataPropertyName = "beginTime";
            dataGridViewCellStyle6.Format = "G";
            dataGridViewCellStyle6.NullValue = null;
            this.colBeginTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.colBeginTime.HeaderText = "开始时间";
            this.colBeginTime.MinimumWidth = 200;
            this.colBeginTime.Name = "colBeginTime";
            this.colBeginTime.ReadOnly = true;
            // 
            // colEndTime
            // 
            this.colEndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEndTime.DataPropertyName = "endTime";
            dataGridViewCellStyle7.Format = "G";
            dataGridViewCellStyle7.NullValue = null;
            this.colEndTime.DefaultCellStyle = dataGridViewCellStyle7;
            this.colEndTime.HeaderText = "结束时间";
            this.colEndTime.MinimumWidth = 200;
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            // 
            // colStation
            // 
            this.colStation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStation.DataPropertyName = "stationAddress";
            this.colStation.HeaderText = "传输分站";
            this.colStation.MinimumWidth = 80;
            this.colStation.Name = "colStation";
            this.colStation.ReadOnly = true;
            // 
            // colStationHeadID
            // 
            this.colStationHeadID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStationHeadID.DataPropertyName = "stationHeadAddress";
            this.colStationHeadID.HeaderText = "读卡分站";
            this.colStationHeadID.MinimumWidth = 80;
            this.colStationHeadID.Name = "colStationHeadID";
            this.colStationHeadID.ReadOnly = true;
            // 
            // colStationHeadPlace
            // 
            this.colStationHeadPlace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStationHeadPlace.DataPropertyName = "stationHeadPlace";
            this.colStationHeadPlace.HeaderText = "交接地点";
            this.colStationHeadPlace.MinimumWidth = 200;
            this.colStationHeadPlace.Name = "colStationHeadPlace";
            this.colStationHeadPlace.ReadOnly = true;
            // 
            // colEmpName1
            // 
            this.colEmpName1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmpName1.DataPropertyName = "empName1";
            this.colEmpName1.HeaderText = "交接人员1";
            this.colEmpName1.MinimumWidth = 150;
            this.colEmpName1.Name = "colEmpName1";
            this.colEmpName1.ReadOnly = true;
            // 
            // colState1
            // 
            this.colState1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colState1.DataPropertyName = "isFlagEmp1";
            this.colState1.HeaderText = "员工1交接状态";
            this.colState1.MinimumWidth = 150;
            this.colState1.Name = "colState1";
            this.colState1.ReadOnly = true;
            // 
            // colEmpName2
            // 
            this.colEmpName2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmpName2.DataPropertyName = "empName2";
            this.colEmpName2.HeaderText = "交接人员2";
            this.colEmpName2.MinimumWidth = 150;
            this.colEmpName2.Name = "colEmpName2";
            this.colEmpName2.ReadOnly = true;
            // 
            // colState2
            // 
            this.colState2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colState2.DataPropertyName = "isFlagEmp2";
            this.colState2.HeaderText = "员工2交接状态";
            this.colState2.MinimumWidth = 150;
            this.colState2.Name = "colState2";
            this.colState2.ReadOnly = true;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 25);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "异地交接班信息";
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
            this.tabControlAssociate.TabIndex = 2;
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
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(103, 152);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSecal
            // 
            this.btnSecal.Location = new System.Drawing.Point(21, 152);
            this.btnSecal.Name = "btnSecal";
            this.btnSecal.Size = new System.Drawing.Size(75, 23);
            this.btnSecal.TabIndex = 18;
            this.btnSecal.Text = "查询";
            this.btnSecal.UseVisualStyleBackColor = true;
            this.btnSecal.Click += new System.EventHandler(this.btnSecal_Click);
            // 
            // txtEmpName2
            // 
            this.txtEmpName2.Location = new System.Drawing.Point(74, 95);
            this.txtEmpName2.MaxLength = 20;
            this.txtEmpName2.Name = "txtEmpName2";
            this.txtEmpName2.Size = new System.Drawing.Size(118, 21);
            this.txtEmpName2.TabIndex = 17;
            this.txtEmpName2.TextType = Shine.TextType.WithOutChar;
            this.txtEmpName2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName2_KeyPress);
            // 
            // txtEmpName1
            // 
            this.txtEmpName1.Location = new System.Drawing.Point(74, 64);
            this.txtEmpName1.MaxLength = 20;
            this.txtEmpName1.Name = "txtEmpName1";
            this.txtEmpName1.Size = new System.Drawing.Size(118, 21);
            this.txtEmpName1.TabIndex = 16;
            this.txtEmpName1.TextType = Shine.TextType.WithOutChar;
            this.txtEmpName1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "员工姓名2：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "员工姓名1：";
            // 
            // dtpScealEndData
            // 
            this.dtpScealEndData.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpScealEndData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScealEndData.Location = new System.Drawing.Point(74, 33);
            this.dtpScealEndData.Name = "dtpScealEndData";
            this.dtpScealEndData.Size = new System.Drawing.Size(119, 21);
            this.dtpScealEndData.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "结束日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "开始日期：";
            // 
            // dtpScealBeginDate
            // 
            this.dtpScealBeginDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpScealBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScealBeginDate.Location = new System.Drawing.Point(74, 2);
            this.dtpScealBeginDate.Name = "dtpScealBeginDate";
            this.dtpScealBeginDate.Size = new System.Drawing.Size(120, 21);
            this.dtpScealBeginDate.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 130);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(156, 16);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "显示异地交接班异常信息";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FrmHisAssociateInfo
            // 
            this.AcceptButton = this.btnSecal;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "FrmHisAssociateInfo";
            this.TabText = "历史异地交接班信息";
            this.Text = "历史异地交接班信息";
            this.Activated += new System.EventHandler(this.FrmHisAssociateInfo_Activated);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControlAssociate.ResumeLayout(false);
            this.tabPageStation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControlAssociate;
        private System.Windows.Forms.TabPage tabPageStation;
        private DegonControlLib.TreeViewControl treeViewControlStation;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSecal;
        private Shine.ShineTextBox txtEmpName2;
        private Shine.ShineTextBox txtEmpName1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpScealEndData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpScealBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationHeadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationHeadPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
    }
}