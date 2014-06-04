namespace KJ128NMainRun.HistoryInfo.HistoryInspection
{
    partial class Form_HistoryInspection
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_Begin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CodeSenderAddress = new Shine.ShineTextBox();
            this.txt_EmpName = new Shine.ShineTextBox();
            this.bt_Enquiries = new System.Windows.Forms.Button();
            this.bt_Reset = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvc_Path = new DegonControlLib.TreeViewControl();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.bt_Reset);
            this.panelLeftBottom.Controls.Add(this.bt_Enquiries);
            this.panelLeftBottom.Controls.Add(this.txt_EmpName);
            this.panelLeftBottom.Controls.Add(this.txt_CodeSenderAddress);
            this.panelLeftBottom.Controls.Add(this.label4);
            this.panelLeftBottom.Controls.Add(this.label3);
            this.panelLeftBottom.Controls.Add(this.dtp_End);
            this.panelLeftBottom.Controls.Add(this.label2);
            this.panelLeftBottom.Controls.Add(this.dtp_Begin);
            this.panelLeftBottom.Controls.Add(this.label1);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 329);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 194);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.tabControl1);
            this.drawerLeftMain.Controls.Add(this.button1);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 329);
            // 
            // btnAdd
            // 
            this.btnAdd.Visible = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Text = "历史巡检";
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
            this.lblCounts.Size = new System.Drawing.Size(17, 12);
            this.lblCounts.Text = "99";
            this.lblCounts.Visible = false;
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.dgv_Main);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "历史巡检";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间：";
            // 
            // dtp_Begin
            // 
            this.dtp_Begin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Begin.Location = new System.Drawing.Point(30, 28);
            this.dtp_Begin.Name = "dtp_Begin";
            this.dtp_Begin.Size = new System.Drawing.Size(140, 21);
            this.dtp_Begin.TabIndex = 1;
            this.dtp_Begin.Value = new System.DateTime(2008, 8, 14, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束时间：";
            // 
            // dtp_End
            // 
            this.dtp_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_End.Location = new System.Drawing.Point(30, 72);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(140, 21);
            this.dtp_End.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "标识卡：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "姓名：";
            // 
            // txt_CodeSenderAddress
            // 
            this.txt_CodeSenderAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_CodeSenderAddress.Location = new System.Drawing.Point(70, 100);
            this.txt_CodeSenderAddress.MaxLength = 5;
            this.txt_CodeSenderAddress.Name = "txt_CodeSenderAddress";
            this.txt_CodeSenderAddress.Size = new System.Drawing.Size(100, 21);
            this.txt_CodeSenderAddress.TabIndex = 7;
            this.txt_CodeSenderAddress.TextType = Shine.TextType.Number;
            // 
            // txt_EmpName
            // 
            this.txt_EmpName.Location = new System.Drawing.Point(70, 128);
            this.txt_EmpName.MaxLength = 20;
            this.txt_EmpName.Name = "txt_EmpName";
            this.txt_EmpName.Size = new System.Drawing.Size(100, 21);
            this.txt_EmpName.TabIndex = 8;
            this.txt_EmpName.TextType = Shine.TextType.WithOutChar;
            this.txt_EmpName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_EmpName_KeyPress);
            // 
            // bt_Enquiries
            // 
            this.bt_Enquiries.Location = new System.Drawing.Point(19, 158);
            this.bt_Enquiries.Name = "bt_Enquiries";
            this.bt_Enquiries.Size = new System.Drawing.Size(53, 23);
            this.bt_Enquiries.TabIndex = 10;
            this.bt_Enquiries.Text = "查询";
            this.bt_Enquiries.UseVisualStyleBackColor = true;
            this.bt_Enquiries.Click += new System.EventHandler(this.bt_Enquiries_Click);
            // 
            // bt_Reset
            // 
            this.bt_Reset.Location = new System.Drawing.Point(114, 158);
            this.bt_Reset.Name = "bt_Reset";
            this.bt_Reset.Size = new System.Drawing.Size(53, 23);
            this.bt_Reset.TabIndex = 11;
            this.bt_Reset.Text = "重置";
            this.bt_Reset.UseVisualStyleBackColor = true;
            this.bt_Reset.Click += new System.EventHandler(this.bt_Reset_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(196, 299);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvc_Path);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(188, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "巡检线路";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvc_Path
            // 
            this.tvc_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_Path.Location = new System.Drawing.Point(3, 3);
            this.tvc_Path.Name = "tvc_Path";
            this.tvc_Path.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_Path.Size = new System.Drawing.Size(182, 268);
            this.tvc_Path.TabIndex = 0;
            this.tvc_Path.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_Path_AfterSelect);
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
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
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.EnableHeadersVisualStyles = false;
            this.dgv_Main.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
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
            this.dgv_Main.TabIndex = 3;
            // 
            // Form_HistoryInspection
            // 
            this.AcceptButton = this.bt_Enquiries;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "Form_HistoryInspection";
            this.TabText = "历史巡检";
            this.Text = "历史巡检";
            this.Load += new System.EventHandler(this.Form_HistoryInspection_Load);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Reset;
        private System.Windows.Forms.Button bt_Enquiries;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_Begin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private DegonControlLib.TreeViewControl tvc_Path;
        private Shine.ShineTextBox txt_EmpName;
        private Shine.ShineTextBox txt_CodeSenderAddress;
        private System.Windows.Forms.DataGridView dgv_Main;
    }
}