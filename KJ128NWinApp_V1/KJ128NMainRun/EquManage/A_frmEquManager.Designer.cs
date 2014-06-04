namespace KJ128NMainRun.EquManage
{
    partial class A_frmEquManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEqu = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.trvEqu = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEqu = new System.Windows.Forms.Button();
            this.pnlFactory = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.trvFactory = new System.Windows.Forms.TreeView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnFactory = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.pnlEqu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlFactory.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.label4);
            this.panelLeftBottom.Controls.Add(this.label2);
            this.panelLeftBottom.Controls.Add(this.label1);
            // 
            // btnAdd
            // 
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Text = "设备配置";
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
            this.panelMainMain.Controls.Add(this.pnlFactory);
            this.panelMainMain.Controls.Add(this.pnlEqu);
            this.panelMainMain.Controls.Add(this.dgv);
            // 
            // btnConfigModel
            // 
            this.btnConfigModel.Click += new System.EventHandler(this.btnConfigModel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // pnlEqu
            // 
            this.pnlEqu.Controls.Add(this.panel3);
            this.pnlEqu.Controls.Add(this.panel2);
            this.pnlEqu.Location = new System.Drawing.Point(168, 17);
            this.pnlEqu.Name = "pnlEqu";
            this.pnlEqu.Size = new System.Drawing.Size(188, 306);
            this.pnlEqu.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.trvEqu);
            this.panel3.Location = new System.Drawing.Point(0, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(188, 280);
            this.panel3.TabIndex = 2;
            // 
            // trvEqu
            // 
            this.trvEqu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvEqu.Location = new System.Drawing.Point(0, 0);
            this.trvEqu.Name = "trvEqu";
            this.trvEqu.Size = new System.Drawing.Size(188, 280);
            this.trvEqu.TabIndex = 0;
            this.trvEqu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvEqu_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEqu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 25);
            this.panel2.TabIndex = 1;
            // 
            // btnEqu
            // 
            this.btnEqu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEqu.Location = new System.Drawing.Point(0, 0);
            this.btnEqu.Name = "btnEqu";
            this.btnEqu.Size = new System.Drawing.Size(188, 25);
            this.btnEqu.TabIndex = 0;
            this.btnEqu.Text = "设备配置";
            this.btnEqu.UseVisualStyleBackColor = true;
            this.btnEqu.Click += new System.EventHandler(this.btnEqu_Click);
            // 
            // pnlFactory
            // 
            this.pnlFactory.Controls.Add(this.panel5);
            this.pnlFactory.Controls.Add(this.panel6);
            this.pnlFactory.Location = new System.Drawing.Point(393, 17);
            this.pnlFactory.Name = "pnlFactory";
            this.pnlFactory.Size = new System.Drawing.Size(200, 294);
            this.pnlFactory.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.trvFactory);
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 268);
            this.panel5.TabIndex = 2;
            // 
            // trvFactory
            // 
            this.trvFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFactory.Location = new System.Drawing.Point(0, 0);
            this.trvFactory.Name = "trvFactory";
            this.trvFactory.Size = new System.Drawing.Size(200, 268);
            this.trvFactory.TabIndex = 0;
            this.trvFactory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFactory_AfterSelect);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnFactory);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 25);
            this.panel6.TabIndex = 1;
            // 
            // btnFactory
            // 
            this.btnFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFactory.Location = new System.Drawing.Point(0, 0);
            this.btnFactory.Name = "btnFactory";
            this.btnFactory.Size = new System.Drawing.Size(200, 25);
            this.btnFactory.TabIndex = 0;
            this.btnFactory.Text = "生产厂家";
            this.btnFactory.UseVisualStyleBackColor = true;
            this.btnFactory.Click += new System.EventHandler(this.btnFactory_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(783, 459);
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            this.dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.FalseValue = "false";
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.TrueValue = "true";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(27, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "添加设备配置流程：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(31, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "第二步:新增设备";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(31, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "第一步:新增生产厂家";
            // 
            // A_frmEquManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "A_frmEquManager";
            this.TabText = "设备配置";
            this.Text = "A_frmEquManager";
            this.Load += new System.EventHandler(this.A_frmEquManager_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_frmEquManager_FormClosing);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            this.panelLeftBottom.PerformLayout();
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.panelMainMain.ResumeLayout(false);
            this.pnlEqu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlFactory.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEqu;
        private System.Windows.Forms.Button btnEqu;
        private System.Windows.Forms.Panel pnlFactory;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TreeView trvFactory;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnFactory;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView trvEqu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}