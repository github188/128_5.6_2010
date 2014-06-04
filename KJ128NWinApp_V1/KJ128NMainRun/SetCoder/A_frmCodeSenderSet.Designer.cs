namespace KJ128NMainRun.SetCoder
{
    partial class A_frmCodeSenderSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_frmCodeSenderSet));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvSet = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lsbCodeSender = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lsbEmpMac = new KJ128WindowsLibrary.ZzhaListBox();
            this.btnPsearch = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtMac = new System.Windows.Forms.RadioButton();
            this.rbtEmp = new System.Windows.Forms.RadioButton();
            this.trvPdept = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPP = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnPReset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labMessage = new System.Windows.Forms.Label();
            this.labOut = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSet)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 357);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(239, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(286, 353);
            this.panel6.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.dgvSet);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(115, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(167, 349);
            this.panel8.TabIndex = 1;
            // 
            // dgvSet
            // 
            this.dgvSet.AllowUserToAddRows = false;
            this.dgvSet.AllowUserToDeleteRows = false;
            this.dgvSet.AllowUserToResizeRows = false;
            this.dgvSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSet.Location = new System.Drawing.Point(0, 25);
            this.dgvSet.Name = "dgvSet";
            this.dgvSet.ReadOnly = true;
            this.dgvSet.RowHeadersVisible = false;
            this.dgvSet.RowTemplate.Height = 23;
            this.dgvSet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSet.Size = new System.Drawing.Size(165, 316);
            this.dgvSet.TabIndex = 3;
            this.dgvSet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSet_CellDoubleClick);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 25);
            this.label11.TabIndex = 2;
            this.label11.Text = "匹配预览";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lsbCodeSender);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(115, 349);
            this.panel7.TabIndex = 0;
            // 
            // lsbCodeSender
            // 
            this.lsbCodeSender.FormattingEnabled = true;
            this.lsbCodeSender.ItemHeight = 12;
            this.lsbCodeSender.Location = new System.Drawing.Point(0, 25);
            this.lsbCodeSender.Name = "lsbCodeSender";
            this.lsbCodeSender.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbCodeSender.Size = new System.Drawing.Size(113, 316);
            this.lsbCodeSender.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 25);
            this.label10.TabIndex = 1;
            this.label10.Text = "标识卡";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.lsbEmpMac);
            this.panel5.Controls.Add(this.btnPsearch);
            this.panel5.Controls.Add(this.txtName);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Controls.Add(this.trvPdept);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(239, 353);
            this.panel5.TabIndex = 1;
            // 
            // lsbEmpMac
            // 
            this.lsbEmpMac.FormattingEnabled = true;
            this.lsbEmpMac.ItemHeight = 12;
            this.lsbEmpMac.Location = new System.Drawing.Point(129, 27);
            this.lsbEmpMac.Name = "lsbEmpMac";
            this.lsbEmpMac.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbEmpMac.Size = new System.Drawing.Size(108, 316);
            this.lsbEmpMac.TabIndex = 7;
            this.lsbEmpMac.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("lsbEmpMac.Values")));
            // 
            // btnPsearch
            // 
            this.btnPsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPsearch.Location = new System.Drawing.Point(51, 323);
            this.btnPsearch.Name = "btnPsearch";
            this.btnPsearch.Size = new System.Drawing.Size(75, 23);
            this.btnPsearch.TabIndex = 6;
            this.btnPsearch.Text = "查询";
            this.btnPsearch.UseVisualStyleBackColor = true;
            this.btnPsearch.Click += new System.EventHandler(this.btnPsearch_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtName.Location = new System.Drawing.Point(40, 296);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(86, 21);
            this.txtName.TabIndex = 5;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.rbtMac);
            this.groupBox2.Controls.Add(this.rbtEmp);
            this.groupBox2.Location = new System.Drawing.Point(2, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 48);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置类型";
            // 
            // rbtMac
            // 
            this.rbtMac.AutoSize = true;
            this.rbtMac.Location = new System.Drawing.Point(69, 22);
            this.rbtMac.Name = "rbtMac";
            this.rbtMac.Size = new System.Drawing.Size(47, 16);
            this.rbtMac.TabIndex = 1;
            this.rbtMac.Text = "设备";
            this.rbtMac.UseVisualStyleBackColor = true;
            this.rbtMac.CheckedChanged += new System.EventHandler(this.rbtMac_CheckedChanged);
            // 
            // rbtEmp
            // 
            this.rbtEmp.AutoSize = true;
            this.rbtEmp.Checked = true;
            this.rbtEmp.Location = new System.Drawing.Point(14, 22);
            this.rbtEmp.Name = "rbtEmp";
            this.rbtEmp.Size = new System.Drawing.Size(47, 16);
            this.rbtEmp.TabIndex = 0;
            this.rbtEmp.TabStop = true;
            this.rbtEmp.Text = "人员";
            this.rbtEmp.UseVisualStyleBackColor = true;
            this.rbtEmp.CheckedChanged += new System.EventHandler(this.rbtEmp_CheckedChanged);
            // 
            // trvPdept
            // 
            this.trvPdept.Location = new System.Drawing.Point(4, 27);
            this.trvPdept.Name = "trvPdept";
            this.trvPdept.Size = new System.Drawing.Size(122, 209);
            this.trvPdept.TabIndex = 1;
            this.trvPdept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvPdept_AfterSelect);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "人员和设备";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnPP);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnPReset);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.labMessage);
            this.panel2.Controls.Add(this.labOut);
            this.panel2.Location = new System.Drawing.Point(0, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 45);
            this.panel2.TabIndex = 0;
            // 
            // btnPP
            // 
            this.btnPP.Location = new System.Drawing.Point(257, 9);
            this.btnPP.Name = "btnPP";
            this.btnPP.Size = new System.Drawing.Size(56, 23);
            this.btnPP.TabIndex = 18;
            this.btnPP.Text = "匹配";
            this.btnPP.UseVisualStyleBackColor = true;
            this.btnPP.Click += new System.EventHandler(this.btnPP_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(460, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "返回";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnPReset
            // 
            this.btnPReset.Location = new System.Drawing.Point(393, 9);
            this.btnPReset.Name = "btnPReset";
            this.btnPReset.Size = new System.Drawing.Size(56, 23);
            this.btnPReset.TabIndex = 16;
            this.btnPReset.Text = "重置";
            this.btnPReset.UseVisualStyleBackColor = true;
            this.btnPReset.Click += new System.EventHandler(this.btnPReset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.ForeColor = System.Drawing.Color.Black;
            this.labMessage.Location = new System.Drawing.Point(56, 14);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(53, 12);
            this.labMessage.TabIndex = 14;
            this.labMessage.Text = "保存成功";
            this.labMessage.Visible = false;
            // 
            // labOut
            // 
            this.labOut.AutoSize = true;
            this.labOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labOut.Location = new System.Drawing.Point(9, 14);
            this.labOut.Name = "labOut";
            this.labOut.Size = new System.Drawing.Size(41, 12);
            this.labOut.TabIndex = 13;
            this.labOut.Text = "提示：";
            // 
            // A_frmCodeSenderSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(528, 405);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_frmCodeSenderSet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标识卡匹配信息";
            this.Load += new System.EventHandler(this.A_frmCodeSenderSet_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSet)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPP;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnPReset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Label labOut;
        private System.Windows.Forms.Panel panel5;
        private KJ128WindowsLibrary.ZzhaListBox lsbEmpMac;
        private System.Windows.Forms.Button btnPsearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtMac;
        private System.Windows.Forms.RadioButton rbtEmp;
        private System.Windows.Forms.TreeView trvPdept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvSet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListBox lsbCodeSender;
        private System.Windows.Forms.Label label10;
    }
}