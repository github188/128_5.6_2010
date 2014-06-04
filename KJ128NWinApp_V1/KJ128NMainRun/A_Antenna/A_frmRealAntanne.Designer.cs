namespace KJ128NMainRun.A_Antenna
{
    partial class A_frmRealAntanne
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.trvHead = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_Name = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReSet = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCodeSenderAddress = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRtAntenna = new System.Windows.Forms.Button();
            this.chbRtTime = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtall = new System.Windows.Forms.RadioButton();
            this.rbtno = new System.Windows.Forms.RadioButton();
            this.rbtequ = new System.Windows.Forms.RadioButton();
            this.rbtemp = new System.Windows.Forms.RadioButton();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnl1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.groupBox1);
            this.panelLeftBottom.Controls.Add(this.chbRtTime);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 396);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 127);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 396);
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
            this.btnLaws.Location = new System.Drawing.Point(660, 3);
            this.btnLaws.Text = "设置";
            this.btnLaws.Click += new System.EventHandler(this.btnLaws_Click);
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
            this.panelMainMain.Controls.Add(this.pnl1);
            this.panelMainMain.Controls.Add(this.dgv);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(783, 459);
            this.dgv.TabIndex = 0;
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.panel3);
            this.pnl1.Controls.Add(this.panel4);
            this.pnl1.Controls.Add(this.panel2);
            this.pnl1.Location = new System.Drawing.Point(130, 21);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(200, 358);
            this.pnl1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.trvHead);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 247);
            this.panel3.TabIndex = 1;
            // 
            // trvHead
            // 
            this.trvHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvHead.Location = new System.Drawing.Point(0, 0);
            this.trvHead.Name = "trvHead";
            this.trvHead.Size = new System.Drawing.Size(196, 243);
            this.trvHead.TabIndex = 0;
            this.trvHead.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvHead_AfterSelect);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.txt_Name);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnReSet);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.txtCodeSenderAddress);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 247);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 111);
            this.panel4.TabIndex = 2;
            // 
            // txt_Name
            // 
            this.txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Name.Location = new System.Drawing.Point(66, 44);
            this.txt_Name.MaxLength = 20;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(127, 21);
            this.txt_Name.TabIndex = 5;
            this.txt_Name.TextType = Shine.TextType.WithOutChar;
            this.txt_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Name_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名：";
            // 
            // btnReSet
            // 
            this.btnReSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReSet.Location = new System.Drawing.Point(109, 80);
            this.btnReSet.Name = "btnReSet";
            this.btnReSet.Size = new System.Drawing.Size(75, 23);
            this.btnReSet.TabIndex = 3;
            this.btnReSet.Text = "重置";
            this.btnReSet.UseVisualStyleBackColor = true;
            this.btnReSet.Click += new System.EventHandler(this.btnReSet_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(16, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCodeSenderAddress
            // 
            this.txtCodeSenderAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodeSenderAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCodeSenderAddress.Location = new System.Drawing.Point(66, 14);
            this.txtCodeSenderAddress.MaxLength = 5;
            this.txtCodeSenderAddress.Name = "txtCodeSenderAddress";
            this.txtCodeSenderAddress.Size = new System.Drawing.Size(127, 21);
            this.txtCodeSenderAddress.TabIndex = 1;
            this.txtCodeSenderAddress.TextType = Shine.TextType.Number;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标识卡：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRtAntenna);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 25);
            this.panel2.TabIndex = 0;
            // 
            // btnRtAntenna
            // 
            this.btnRtAntenna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRtAntenna.Location = new System.Drawing.Point(0, 0);
            this.btnRtAntenna.Name = "btnRtAntenna";
            this.btnRtAntenna.Size = new System.Drawing.Size(200, 25);
            this.btnRtAntenna.TabIndex = 0;
            this.btnRtAntenna.Text = "实时天线";
            this.btnRtAntenna.UseVisualStyleBackColor = true;
            this.btnRtAntenna.Click += new System.EventHandler(this.btnRtAntenna_Click);
            // 
            // chbRtTime
            // 
            this.chbRtTime.AutoSize = true;
            this.chbRtTime.Checked = true;
            this.chbRtTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRtTime.Location = new System.Drawing.Point(23, 12);
            this.chbRtTime.Name = "chbRtTime";
            this.chbRtTime.Size = new System.Drawing.Size(96, 16);
            this.chbRtTime.TabIndex = 0;
            this.chbRtTime.Text = "实时更新数据";
            this.chbRtTime.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtall);
            this.groupBox1.Controls.Add(this.rbtno);
            this.groupBox1.Controls.Add(this.rbtequ);
            this.groupBox1.Controls.Add(this.rbtemp);
            this.groupBox1.Location = new System.Drawing.Point(3, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标识卡匹配类型";
            // 
            // rbtall
            // 
            this.rbtall.AutoSize = true;
            this.rbtall.Location = new System.Drawing.Point(123, 47);
            this.rbtall.Name = "rbtall";
            this.rbtall.Size = new System.Drawing.Size(47, 16);
            this.rbtall.TabIndex = 3;
            this.rbtall.Text = "所有";
            this.rbtall.UseVisualStyleBackColor = true;
            this.rbtall.CheckedChanged += new System.EventHandler(this.rbtall_CheckedChanged);
            // 
            // rbtno
            // 
            this.rbtno.AutoSize = true;
            this.rbtno.Location = new System.Drawing.Point(21, 47);
            this.rbtno.Name = "rbtno";
            this.rbtno.Size = new System.Drawing.Size(59, 16);
            this.rbtno.TabIndex = 2;
            this.rbtno.Text = "未登记";
            this.rbtno.UseVisualStyleBackColor = true;
            this.rbtno.CheckedChanged += new System.EventHandler(this.rbtno_CheckedChanged);
            // 
            // rbtequ
            // 
            this.rbtequ.AutoSize = true;
            this.rbtequ.Location = new System.Drawing.Point(123, 21);
            this.rbtequ.Name = "rbtequ";
            this.rbtequ.Size = new System.Drawing.Size(47, 16);
            this.rbtequ.TabIndex = 1;
            this.rbtequ.Text = "设备";
            this.rbtequ.UseVisualStyleBackColor = true;
            this.rbtequ.CheckedChanged += new System.EventHandler(this.rbtequ_CheckedChanged);
            // 
            // rbtemp
            // 
            this.rbtemp.AutoSize = true;
            this.rbtemp.Checked = true;
            this.rbtemp.Location = new System.Drawing.Point(21, 21);
            this.rbtemp.Name = "rbtemp";
            this.rbtemp.Size = new System.Drawing.Size(47, 16);
            this.rbtemp.TabIndex = 0;
            this.rbtemp.TabStop = true;
            this.rbtemp.Text = "人员";
            this.rbtemp.UseVisualStyleBackColor = true;
            this.rbtemp.CheckedChanged += new System.EventHandler(this.rbtemp_CheckedChanged);
            // 
            // A_frmRealAntanne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_frmRealAntanne";
            this.TabText = "实时天线";
            this.Text = "A_frmRealAntanne";
            this.Load += new System.EventHandler(this.A_frmRealAntanne_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            this.panelLeftBottom.PerformLayout();
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.panelMainMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnl1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnReSet;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRtAntenna;
        private System.Windows.Forms.TreeView trvHead;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbRtTime;
        private System.Windows.Forms.RadioButton rbtall;
        private System.Windows.Forms.RadioButton rbtno;
        private System.Windows.Forms.RadioButton rbtequ;
        private System.Windows.Forms.RadioButton rbtemp;
        private Shine.ShineTextBox txtCodeSenderAddress;
        private Shine.ShineTextBox txt_Name;
        private System.Windows.Forms.Label label2;
    }
}