namespace KJ128NMainRun.A_Attendance
{
    partial class A_AttendanceRealTime
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.DeptTree = new DegonControlLib.TreeViewControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlClass = new System.Windows.Forms.ComboBox();
            this.ddlTimerInterval = new System.Windows.Forms.ComboBox();
            this.txtUserName = new Shine.ShineTextBox();
            this.txtBlock = new Shine.ShineTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgrd = new System.Windows.Forms.DataGridView();
            this.delckek = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.button3);
            this.panelLeftBottom.Controls.Add(this.button2);
            this.panelLeftBottom.Controls.Add(this.txtBlock);
            this.panelLeftBottom.Controls.Add(this.txtUserName);
            this.panelLeftBottom.Controls.Add(this.ddlTimerInterval);
            this.panelLeftBottom.Controls.Add(this.ddlClass);
            this.panelLeftBottom.Controls.Add(this.label4);
            this.panelLeftBottom.Controls.Add(this.label3);
            this.panelLeftBottom.Controls.Add(this.label2);
            this.panelLeftBottom.Controls.Add(this.label1);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 306);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 217);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.DeptTree);
            this.drawerLeftMain.Controls.Add(this.panel1);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 306);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(539, 3);
            this.btnAdd.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(359, 3);
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(419, 3);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(479, 3);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(599, 3);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.SelectedIndexChanged += new System.EventHandler(this.ddlRowsSet_SelectionChangeCommitted);
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSkipPage_KeyDown);
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // btnDownPage
            // 
            this.btnDownPage.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.dgrd);
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
            this.button1.Text = "实时补单";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DeptTree
            // 
            this.DeptTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeptTree.Location = new System.Drawing.Point(0, 25);
            this.DeptTree.Name = "DeptTree";
            this.DeptTree.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.DeptTree.Size = new System.Drawing.Size(196, 277);
            this.DeptTree.TabIndex = 1;
            this.DeptTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DeptTree_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡  号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓  名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "班  制：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "班  次：";
            // 
            // ddlClass
            // 
            this.ddlClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClass.FormattingEnabled = true;
            this.ddlClass.Location = new System.Drawing.Point(79, 82);
            this.ddlClass.Name = "ddlClass";
            this.ddlClass.Size = new System.Drawing.Size(98, 20);
            this.ddlClass.TabIndex = 4;
            this.ddlClass.DropDownClosed += new System.EventHandler(this.ddlClass_DropDownClosed);
            // 
            // ddlTimerInterval
            // 
            this.ddlTimerInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTimerInterval.FormattingEnabled = true;
            this.ddlTimerInterval.Location = new System.Drawing.Point(79, 114);
            this.ddlTimerInterval.Name = "ddlTimerInterval";
            this.ddlTimerInterval.Size = new System.Drawing.Size(98, 20);
            this.ddlTimerInterval.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(77, 49);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 6;
            this.txtUserName.TextType = Shine.TextType.WithOutChar;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // txtBlock
            // 
            this.txtBlock.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBlock.Location = new System.Drawing.Point(77, 18);
            this.txtBlock.MaxLength = 11;
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(100, 21);
            this.txtBlock.TabIndex = 7;
            this.txtBlock.TextType = Shine.TextType.Number;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "查  询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(102, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "重  置";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgrd
            // 
            this.dgrd.AllowUserToAddRows = false;
            this.dgrd.AllowUserToDeleteRows = false;
            this.dgrd.AllowUserToResizeRows = false;
            this.dgrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delckek});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.dgrd.RowHeadersVisible = false;
            this.dgrd.RowTemplate.Height = 23;
            this.dgrd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrd.Size = new System.Drawing.Size(783, 459);
            this.dgrd.TabIndex = 0;
            this.dgrd.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            // 
            // delckek
            // 
            this.delckek.FalseValue = "False";
            this.delckek.FillWeight = 30F;
            this.delckek.HeaderText = "";
            this.delckek.IndeterminateValue = "";
            this.delckek.Name = "delckek";
            this.delckek.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delckek.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delckek.TrueValue = "True";
            // 
            // A_AttendanceRealTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_AttendanceRealTime";
            this.TabText = "实时补单";
            this.Text = "实时补单";
            this.Load += new System.EventHandler(this.A_AttendanceRealTime_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DegonControlLib.TreeViewControl DeptTree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlClass;
        private System.Windows.Forms.ComboBox ddlTimerInterval;
        private Shine.ShineTextBox txtBlock;
        private Shine.ShineTextBox txtUserName;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgrd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn delckek;
    }
}