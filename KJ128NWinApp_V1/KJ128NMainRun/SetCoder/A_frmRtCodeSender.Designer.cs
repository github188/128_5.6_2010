namespace KJ128NMainRun.SetCoder
{
    partial class A_frmRtCodeSender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_frmRtCodeSender));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtObj = new System.Windows.Forms.TextBox();
            this.labObj = new System.Windows.Forms.Label();
            this.txtCode = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.trv = new KJ128WindowsLibrary.ZzhaTreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCodesender = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDown = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtEqu = new System.Windows.Forms.RadioButton();
            this.rbtEmp = new System.Windows.Forms.RadioButton();
            this.chkRealTime = new System.Windows.Forms.CheckBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.pnl.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.panel1);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 414);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 109);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 414);
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
            this.txtSkipPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSkipPage_KeyPress);
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
            this.panelMainMain.Controls.Add(this.pnl);
            this.panelMainMain.Controls.Add(this.dgv);
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.panel4);
            this.pnl.Controls.Add(this.panel3);
            this.pnl.Controls.Add(this.panel2);
            this.pnl.Location = new System.Drawing.Point(95, 84);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(200, 324);
            this.pnl.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btnReset);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.txtObj);
            this.panel4.Controls.Add(this.labObj);
            this.panel4.Controls.Add(this.txtCode);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(0, 225);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 99);
            this.panel4.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Location = new System.Drawing.Point(108, 65);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(18, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtObj
            // 
            this.txtObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtObj.Location = new System.Drawing.Point(69, 38);
            this.txtObj.Name = "txtObj";
            this.txtObj.Size = new System.Drawing.Size(114, 21);
            this.txtObj.TabIndex = 3;
            this.txtObj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObj_KeyPress);
            // 
            // labObj
            // 
            this.labObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labObj.AutoSize = true;
            this.labObj.Location = new System.Drawing.Point(16, 41);
            this.labObj.Name = "labObj";
            this.labObj.Size = new System.Drawing.Size(53, 12);
            this.labObj.TabIndex = 2;
            this.labObj.Text = "姓  名：";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCode.Location = new System.Drawing.Point(69, 11);
            this.txtCode.MaxLength = 5;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(114, 21);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextType = Shine.TextType.Number;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标识卡：";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.trv);
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 201);
            this.panel3.TabIndex = 1;
            // 
            // trv
            // 
            this.trv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv.IdIndex = 0;
            this.trv.Location = new System.Drawing.Point(0, 0);
            this.trv.Name = "trv";
            this.trv.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.trv.ParentIdName = "ParentDeptID";
            this.trv.RootIndexValue = "0";
            this.trv.RootNode = null;
            this.trv.Size = new System.Drawing.Size(196, 197);
            this.trv.TabIndex = 0;
            this.trv.TextIndex = 2;
            this.trv.TreeDataSource = null;
            this.trv.ValueList = ((System.Collections.Generic.List<string>)(resources.GetObject("trv.ValueList")));
            this.trv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnCodesender);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 29);
            this.panel2.TabIndex = 0;
            // 
            // btnCodesender
            // 
            this.btnCodesender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCodesender.Location = new System.Drawing.Point(0, 0);
            this.btnCodesender.Name = "btnCodesender";
            this.btnCodesender.Size = new System.Drawing.Size(200, 29);
            this.btnCodesender.TabIndex = 0;
            this.btnCodesender.Text = "标识卡";
            this.btnCodesender.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkDown);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.chkRealTime);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 103);
            this.panel1.TabIndex = 0;
            // 
            // chkDown
            // 
            this.chkDown.AutoSize = true;
            this.chkDown.Location = new System.Drawing.Point(8, 25);
            this.chkDown.Name = "chkDown";
            this.chkDown.Size = new System.Drawing.Size(144, 16);
            this.chkDown.TabIndex = 2;
            this.chkDown.Text = "仅显示井下人员或设备";
            this.chkDown.UseVisualStyleBackColor = true;
            this.chkDown.CheckedChanged += new System.EventHandler(this.chkDown_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtEqu);
            this.groupBox1.Controls.Add(this.rbtEmp);
            this.groupBox1.Location = new System.Drawing.Point(3, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标识卡匹配类型";
            // 
            // rbtEqu
            // 
            this.rbtEqu.AutoSize = true;
            this.rbtEqu.Location = new System.Drawing.Point(115, 20);
            this.rbtEqu.Name = "rbtEqu";
            this.rbtEqu.Size = new System.Drawing.Size(47, 16);
            this.rbtEqu.TabIndex = 1;
            this.rbtEqu.Text = "设备";
            this.rbtEqu.UseVisualStyleBackColor = true;
            this.rbtEqu.CheckedChanged += new System.EventHandler(this.rbtEqu_CheckedChanged);
            // 
            // rbtEmp
            // 
            this.rbtEmp.AutoSize = true;
            this.rbtEmp.Checked = true;
            this.rbtEmp.Location = new System.Drawing.Point(24, 20);
            this.rbtEmp.Name = "rbtEmp";
            this.rbtEmp.Size = new System.Drawing.Size(47, 16);
            this.rbtEmp.TabIndex = 0;
            this.rbtEmp.TabStop = true;
            this.rbtEmp.Text = "人员";
            this.rbtEmp.UseVisualStyleBackColor = true;
            this.rbtEmp.CheckedChanged += new System.EventHandler(this.rbtEmp_CheckedChanged);
            // 
            // chkRealTime
            // 
            this.chkRealTime.AutoSize = true;
            this.chkRealTime.Checked = true;
            this.chkRealTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRealTime.Location = new System.Drawing.Point(8, 3);
            this.chkRealTime.Name = "chkRealTime";
            this.chkRealTime.Size = new System.Drawing.Size(96, 16);
            this.chkRealTime.TabIndex = 0;
            this.chkRealTime.Text = "实时更新数据";
            this.chkRealTime.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(783, 459);
            this.dgv.TabIndex = 20;
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            // 
            // A_frmRtCodeSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_frmRtCodeSender";
            this.TabText = "实时标识卡";
            this.Text = "A_frmRtCodeSender";
            this.Load += new System.EventHandler(this.A_frmRtCodeSender_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.panelMainMain.ResumeLayout(false);
            this.pnl.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtObj;
        private System.Windows.Forms.Label labObj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCodesender;
        private KJ128WindowsLibrary.ZzhaTreeView trv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtEqu;
        private System.Windows.Forms.RadioButton rbtEmp;
        private System.Windows.Forms.CheckBox chkRealTime;
        private System.Windows.Forms.DataGridView dgv;
        private Shine.ShineTextBox txtCode;
    }
}