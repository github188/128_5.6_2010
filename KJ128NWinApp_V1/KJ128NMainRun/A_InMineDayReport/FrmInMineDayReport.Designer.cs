namespace KJ128NMainRun.A_InMineDayReport
{
    partial class FrmInMineDayReport
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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.btnHead = new System.Windows.Forms.Button();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.lblTimeBegin = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblCodeSenderAddress = new System.Windows.Forms.Label();
            this.txtCodeSenderAddress = new Shine.ShineTextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnReSet = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Size = new System.Drawing.Size(200, 512);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(691, 512);
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.btnSelect);
            this.panelLeftBottom.Controls.Add(this.txtCodeSenderAddress);
            this.panelLeftBottom.Controls.Add(this.btnReSet);
            this.panelLeftBottom.Controls.Add(this.txtEmpName);
            this.panelLeftBottom.Controls.Add(this.dtpDate);
            this.panelLeftBottom.Controls.Add(this.lblTimeBegin);
            this.panelLeftBottom.Controls.Add(this.lblCodeSenderAddress);
            this.panelLeftBottom.Controls.Add(this.lblEmpName);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 353);
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 159);
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.Location = new System.Drawing.Point(0, 478);
            this.panelMainBottom.Size = new System.Drawing.Size(687, 30);
            // 
            // panelMainTop
            // 
            this.panelMainTop.Size = new System.Drawing.Size(687, 30);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.pnlTime);
            this.drawerLeftMain.Controls.Add(this.btnHead);
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 353);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(315, 4);
            this.btnAdd.Visible = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(375, 4);
            this.btnSelectAll.Visible = false;
            // 
            // btnLaws
            // 
            this.btnLaws.Location = new System.Drawing.Point(435, 3);
            this.btnLaws.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(495, 4);
            this.btnDelete.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(555, 4);
            // 
            // lblSumPage
            // 
            this.lblSumPage.Location = new System.Drawing.Point(329, 11);
            this.lblSumPage.Visible = false;
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.Location = new System.Drawing.Point(552, 7);
            this.cmbSelectCounts.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(493, 11);
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(467, 11);
            this.label7.Visible = false;
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.Location = new System.Drawing.Point(429, 6);
            this.txtSkipPage.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(394, 11);
            this.label6.Visible = false;
            // 
            // lblPageCounts
            // 
            this.lblPageCounts.Location = new System.Drawing.Point(312, 11);
            this.lblPageCounts.Visible = false;
            // 
            // btnDownPage
            // 
            this.btnDownPage.Location = new System.Drawing.Point(364, 4);
            this.btnDownPage.Visible = false;
            // 
            // btnUpPage
            // 
            this.btnUpPage.Location = new System.Drawing.Point(283, 5);
            this.btnUpPage.Visible = false;
            // 
            // lblCounts
            // 
            this.lblCounts.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(599, 11);
            this.label9.Visible = false;
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.dgvMain);
            this.panelMainMain.Size = new System.Drawing.Size(687, 448);
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(687, 448);
            this.dgvMain.TabIndex = 0;
            // 
            // btnHead
            // 
            this.btnHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHead.Location = new System.Drawing.Point(0, 0);
            this.btnHead.Name = "btnHead";
            this.btnHead.Size = new System.Drawing.Size(196, 23);
            this.btnHead.TabIndex = 0;
            this.btnHead.Text = "日下井路线报表";
            this.btnHead.UseVisualStyleBackColor = true;
            // 
            // pnlTime
            // 
            this.pnlTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTime.Location = new System.Drawing.Point(0, 23);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(196, 326);
            this.pnlTime.TabIndex = 8;
            // 
            // lblTimeBegin
            // 
            this.lblTimeBegin.AutoSize = true;
            this.lblTimeBegin.Location = new System.Drawing.Point(10, 16);
            this.lblTimeBegin.Name = "lblTimeBegin";
            this.lblTimeBegin.Size = new System.Drawing.Size(71, 12);
            this.lblTimeBegin.TabIndex = 1;
            this.lblTimeBegin.Text = "日      期:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(91, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(103, 21);
            this.dtpDate.TabIndex = 3;
            // 
            // lblCodeSenderAddress
            // 
            this.lblCodeSenderAddress.AutoSize = true;
            this.lblCodeSenderAddress.Location = new System.Drawing.Point(10, 56);
            this.lblCodeSenderAddress.Name = "lblCodeSenderAddress";
            this.lblCodeSenderAddress.Size = new System.Drawing.Size(71, 12);
            this.lblCodeSenderAddress.TabIndex = 9;
            this.lblCodeSenderAddress.Text = "标识卡编号:";
            // 
            // txtCodeSenderAddress
            // 
            this.txtCodeSenderAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCodeSenderAddress.Location = new System.Drawing.Point(92, 51);
            this.txtCodeSenderAddress.Name = "txtCodeSenderAddress";
            this.txtCodeSenderAddress.Size = new System.Drawing.Size(100, 21);
            this.txtCodeSenderAddress.TabIndex = 10;
            this.txtCodeSenderAddress.TextType = Shine.TextType.Number;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(91, 85);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(100, 21);
            this.txtEmpName.TabIndex = 12;
            this.txtEmpName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName_KeyPress);
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(9, 91);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(71, 12);
            this.lblEmpName.TabIndex = 11;
            this.lblEmpName.Text = "姓      名:";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(9, 120);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 13;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnReSet
            // 
            this.btnReSet.Location = new System.Drawing.Point(117, 121);
            this.btnReSet.Name = "btnReSet";
            this.btnReSet.Size = new System.Drawing.Size(75, 23);
            this.btnReSet.TabIndex = 14;
            this.btnReSet.Text = "重置";
            this.btnReSet.UseVisualStyleBackColor = true;
            this.btnReSet.Click += new System.EventHandler(this.btnReSet_Click);
            // 
            // FrmInMineDayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 512);
            this.Name = "FrmInMineDayReport";
            this.Text = "日下井行进路线报表";
            this.Load += new System.EventHandler(this.FrmInMineDayReport_Load);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnHead;
        private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.Label lblTimeBegin;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private Shine.ShineTextBox txtCodeSenderAddress;
        private System.Windows.Forms.Label lblCodeSenderAddress;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Button btnReSet;
        private System.Windows.Forms.Button btnSelect;
    }
}