namespace KJ128NMainRun.A_RealInWell
{
    partial class FrmRealInWell
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnShow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageWorkType = new System.Windows.Forms.TabPage();
            this.treeViewWorkType = new DegonControlLib.TreeViewControl();
            this.tabPageDuty = new System.Windows.Forms.TabPage();
            this.treeViewDuty = new DegonControlLib.TreeViewControl();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSecal = new System.Windows.Forms.Button();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.txtName = new Shine.ShineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardID = new Shine.ShineTextBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.ckbRealTime = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbFixing = new System.Windows.Forms.RadioButton();
            this.rdbEmp = new System.Windows.Forms.RadioButton();
            this.treeViewDept = new DegonControlLib.TreeViewControl();
            this.tabPageDept = new System.Windows.Forms.TabPage();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageWorkType.SuspendLayout();
            this.tabPageDuty.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPageDept.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.groupBox1);
            this.panelLeftBottom.Controls.Add(this.ckbRealTime);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 479);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 44);
            // 
            // panelMainTop
            // 
            this.panelMainTop.Controls.Add(this.btnShow);
            this.panelMainTop.Controls.SetChildIndex(this.btnExportExcel, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnConfigModel, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnLaws, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnAdd, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnDelete, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnPrint, 0);
            this.panelMainTop.Controls.SetChildIndex(this.lblMainTitle, 0);
            this.panelMainTop.Controls.SetChildIndex(this.btnShow, 0);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.panel1);
            this.drawerLeftMain.Controls.Add(this.panel2);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 479);
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
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShow.Image = global::KJ128NMainRun.Properties.Resources.显示2;
            this.btnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShow.Location = new System.Drawing.Point(95, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(80, 23);
            this.btnShow.TabIndex = 19;
            this.btnShow.Text = "显示内容";
            this.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Visible = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 345);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDept);
            this.tabControl1.Controls.Add(this.tabPageWorkType);
            this.tabControl1.Controls.Add(this.tabPageDuty);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(192, 316);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPageWorkType
            // 
            this.tabPageWorkType.Controls.Add(this.treeViewWorkType);
            this.tabPageWorkType.Location = new System.Drawing.Point(4, 21);
            this.tabPageWorkType.Name = "tabPageWorkType";
            this.tabPageWorkType.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorkType.Size = new System.Drawing.Size(184, 291);
            this.tabPageWorkType.TabIndex = 1;
            this.tabPageWorkType.Text = "工种";
            this.tabPageWorkType.UseVisualStyleBackColor = true;
            // 
            // treeViewWorkType
            // 
            this.treeViewWorkType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewWorkType.Location = new System.Drawing.Point(3, 3);
            this.treeViewWorkType.Name = "treeViewWorkType";
            this.treeViewWorkType.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.treeViewWorkType.Size = new System.Drawing.Size(178, 285);
            this.treeViewWorkType.TabIndex = 0;
            this.treeViewWorkType.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDept_NodeMouseClick);
            // 
            // tabPageDuty
            // 
            this.tabPageDuty.Controls.Add(this.treeViewDuty);
            this.tabPageDuty.Location = new System.Drawing.Point(4, 21);
            this.tabPageDuty.Name = "tabPageDuty";
            this.tabPageDuty.Size = new System.Drawing.Size(184, 291);
            this.tabPageDuty.TabIndex = 2;
            this.tabPageDuty.Text = "职务";
            this.tabPageDuty.UseVisualStyleBackColor = true;
            // 
            // treeViewDuty
            // 
            this.treeViewDuty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDuty.Location = new System.Drawing.Point(0, 0);
            this.treeViewDuty.Name = "treeViewDuty";
            this.treeViewDuty.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.treeViewDuty.Size = new System.Drawing.Size(184, 291);
            this.treeViewDuty.TabIndex = 0;
            this.treeViewDuty.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDept_NodeMouseClick);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "实时下井人员";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnSecal);
            this.panel2.Controls.Add(this.cmbClass);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCardID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 345);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 130);
            this.panel2.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(104, 100);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSecal
            // 
            this.btnSecal.Location = new System.Drawing.Point(22, 100);
            this.btnSecal.Name = "btnSecal";
            this.btnSecal.Size = new System.Drawing.Size(75, 23);
            this.btnSecal.TabIndex = 6;
            this.btnSecal.Text = "查询";
            this.btnSecal.UseVisualStyleBackColor = true;
            this.btnSecal.Click += new System.EventHandler(this.btnSecal_Click);
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(67, 68);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(121, 20);
            this.cmbClass.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(67, 41);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 21);
            this.txtName.TabIndex = 4;
            this.txtName.TextType = Shine.TextType.WithOutChar;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "班  次：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓  名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "标识卡：";
            // 
            // txtCardID
            // 
            this.txtCardID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCardID.Location = new System.Drawing.Point(67, 14);
            this.txtCardID.MaxLength = 5;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(121, 21);
            this.txtCardID.TabIndex = 0;
            this.txtCardID.TextType = Shine.TextType.Number;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(783, 459);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMain_ColumnHeaderMouseClick);
            this.dgvMain.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            this.dgvMain.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMain_DataBindingComplete);
            // 
            // ckbRealTime
            // 
            this.ckbRealTime.AutoSize = true;
            this.ckbRealTime.Checked = true;
            this.ckbRealTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbRealTime.Location = new System.Drawing.Point(49, 15);
            this.ckbRealTime.Name = "ckbRealTime";
            this.ckbRealTime.Size = new System.Drawing.Size(96, 16);
            this.ckbRealTime.TabIndex = 0;
            this.ckbRealTime.Text = "实时更新数据";
            this.ckbRealTime.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbFixing);
            this.groupBox1.Controls.Add(this.rdbEmp);
            this.groupBox1.Location = new System.Drawing.Point(16, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标识卡匹配类型";
            this.groupBox1.Visible = false;
            // 
            // rdbFixing
            // 
            this.rdbFixing.AutoSize = true;
            this.rdbFixing.Location = new System.Drawing.Point(95, 30);
            this.rdbFixing.Name = "rdbFixing";
            this.rdbFixing.Size = new System.Drawing.Size(47, 16);
            this.rdbFixing.TabIndex = 1;
            this.rdbFixing.Text = "设备";
            this.rdbFixing.UseVisualStyleBackColor = true;
            // 
            // rdbEmp
            // 
            this.rdbEmp.AutoSize = true;
            this.rdbEmp.Checked = true;
            this.rdbEmp.Location = new System.Drawing.Point(27, 30);
            this.rdbEmp.Name = "rdbEmp";
            this.rdbEmp.Size = new System.Drawing.Size(47, 16);
            this.rdbEmp.TabIndex = 0;
            this.rdbEmp.TabStop = true;
            this.rdbEmp.Text = "人员";
            this.rdbEmp.UseVisualStyleBackColor = true;
            // 
            // treeViewDept
            // 
            this.treeViewDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDept.Location = new System.Drawing.Point(3, 3);
            this.treeViewDept.Name = "treeViewDept";
            this.treeViewDept.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.treeViewDept.Size = new System.Drawing.Size(178, 285);
            this.treeViewDept.TabIndex = 0;
            this.treeViewDept.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDept_NodeMouseClick);
            // 
            // tabPageDept
            // 
            this.tabPageDept.Controls.Add(this.treeViewDept);
            this.tabPageDept.Location = new System.Drawing.Point(4, 21);
            this.tabPageDept.Name = "tabPageDept";
            this.tabPageDept.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDept.Size = new System.Drawing.Size(184, 291);
            this.tabPageDept.TabIndex = 0;
            this.tabPageDept.Text = "部门";
            this.tabPageDept.UseVisualStyleBackColor = true;
            // 
            // FrmRealInWell
            // 
            this.AcceptButton = this.btnSecal;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "FrmRealInWell";
            this.TabText = "实时下井人员";
            this.Text = "实时下井人员";
            this.Load += new System.EventHandler(this.FrmRealInWell_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRealInWell_FormClosed);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPageWorkType.ResumeLayout(false);
            this.tabPageDuty.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageDept.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageWorkType;
        private System.Windows.Forms.TabPage tabPageDuty;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbEmp;
        private System.Windows.Forms.CheckBox ckbRealTime;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSecal;
        private System.Windows.Forms.RadioButton rdbFixing;
        private DegonControlLib.TreeViewControl treeViewDuty;
        private DegonControlLib.TreeViewControl treeViewWorkType;
        private Shine.ShineTextBox txtName;
        private Shine.ShineTextBox txtCardID;
        private System.Windows.Forms.TabPage tabPageDept;
        private DegonControlLib.TreeViewControl treeViewDept;
    }
}