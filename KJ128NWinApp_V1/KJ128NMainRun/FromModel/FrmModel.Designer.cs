namespace KJ128NMainRun.FromModel
{
    partial class FrmModel
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.drawerLeftMain = new DegonControlLib.DrawerMainControl();
            this.panelLeftBottom = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMainMain = new System.Windows.Forms.Panel();
            this.panelMainBottom = new System.Windows.Forms.Panel();
            this.lblSumPage = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSelectCounts = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSkipPage = new Shine.ShineTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPageCounts = new System.Windows.Forms.Label();
            this.btnDownPage = new System.Windows.Forms.Button();
            this.btnUpPage = new System.Windows.Forms.Button();
            this.lblCounts = new System.Windows.Forms.Label();
            this.panelMainTop = new System.Windows.Forms.Panel();
            this.btnConfigModel = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLaws = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.drawerLeftMain);
            this.panelLeft.Controls.Add(this.panelLeftBottom);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 523);
            this.panelLeft.TabIndex = 0;
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawerLeftMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawerLeftMain.Location = new System.Drawing.Point(0, 0);
            this.drawerLeftMain.MainHeight = 100;
            this.drawerLeftMain.Name = "drawerLeftMain";
            this.drawerLeftMain.PartTime = 50;
            this.drawerLeftMain.PType = DegonControlLib.PartType.Time;
            this.drawerLeftMain.Size = new System.Drawing.Size(200, 343);
            this.drawerLeftMain.SplitHeight = 1;
            this.drawerLeftMain.TabIndex = 2;
            this.drawerLeftMain.TitleHeight = 25;
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 343);
            this.panelLeftBottom.Name = "panelLeftBottom";
            this.panelLeftBottom.Size = new System.Drawing.Size(200, 180);
            this.panelLeftBottom.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Controls.Add(this.panelMainMain);
            this.panelMain.Controls.Add(this.panelMainBottom);
            this.panelMain.Controls.Add(this.panelMainTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(787, 523);
            this.panelMain.TabIndex = 1;
            // 
            // panelMainMain
            // 
            this.panelMainMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainMain.Location = new System.Drawing.Point(0, 30);
            this.panelMainMain.Name = "panelMainMain";
            this.panelMainMain.Size = new System.Drawing.Size(783, 459);
            this.panelMainMain.TabIndex = 3;
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.Controls.Add(this.lblSumPage);
            this.panelMainBottom.Controls.Add(this.label9);
            this.panelMainBottom.Controls.Add(this.cmbSelectCounts);
            this.panelMainBottom.Controls.Add(this.label8);
            this.panelMainBottom.Controls.Add(this.label7);
            this.panelMainBottom.Controls.Add(this.txtSkipPage);
            this.panelMainBottom.Controls.Add(this.label6);
            this.panelMainBottom.Controls.Add(this.lblPageCounts);
            this.panelMainBottom.Controls.Add(this.btnDownPage);
            this.panelMainBottom.Controls.Add(this.btnUpPage);
            this.panelMainBottom.Controls.Add(this.lblCounts);
            this.panelMainBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMainBottom.Location = new System.Drawing.Point(0, 489);
            this.panelMainBottom.Name = "panelMainBottom";
            this.panelMainBottom.Size = new System.Drawing.Size(783, 30);
            this.panelMainBottom.TabIndex = 2;
            // 
            // lblSumPage
            // 
            this.lblSumPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumPage.AutoSize = true;
            this.lblSumPage.Location = new System.Drawing.Point(474, 11);
            this.lblSumPage.Name = "lblSumPage";
            this.lblSumPage.Size = new System.Drawing.Size(29, 12);
            this.lblSumPage.TabIndex = 22;
            this.lblSumPage.Text = "/1页";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(744, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "条数";
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelectCounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectCounts.FormattingEnabled = true;
            this.cmbSelectCounts.Items.AddRange(new object[] {
            "40",
            "100",
            "200",
            "500"});
            this.cmbSelectCounts.Location = new System.Drawing.Point(697, 7);
            this.cmbSelectCounts.Name = "cmbSelectCounts";
            this.cmbSelectCounts.Size = new System.Drawing.Size(41, 20);
            this.cmbSelectCounts.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(638, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "每页显示";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(612, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "页";
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSkipPage.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSkipPage.Location = new System.Drawing.Point(574, 6);
            this.txtSkipPage.MaxLength = 4;
            this.txtSkipPage.Name = "txtSkipPage";
            this.txtSkipPage.Size = new System.Drawing.Size(32, 21);
            this.txtSkipPage.TabIndex = 17;
            this.txtSkipPage.Text = "1";
            this.txtSkipPage.TextType = Shine.TextType.Number;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(539, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "跳至";
            // 
            // lblPageCounts
            // 
            this.lblPageCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageCounts.AutoSize = true;
            this.lblPageCounts.Location = new System.Drawing.Point(457, 11);
            this.lblPageCounts.Name = "lblPageCounts";
            this.lblPageCounts.Size = new System.Drawing.Size(11, 12);
            this.lblPageCounts.TabIndex = 15;
            this.lblPageCounts.Text = "1";
            // 
            // btnDownPage
            // 
            this.btnDownPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDownPage.Image = global::KJ128NMainRun.Properties.Resources.Right_01;
            this.btnDownPage.Location = new System.Drawing.Point(509, 4);
            this.btnDownPage.Name = "btnDownPage";
            this.btnDownPage.Size = new System.Drawing.Size(23, 23);
            this.btnDownPage.TabIndex = 14;
            this.btnDownPage.UseVisualStyleBackColor = true;
            // 
            // btnUpPage
            // 
            this.btnUpPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpPage.Image = global::KJ128NMainRun.Properties.Resources.Left_01;
            this.btnUpPage.Location = new System.Drawing.Point(428, 5);
            this.btnUpPage.Name = "btnUpPage";
            this.btnUpPage.Size = new System.Drawing.Size(23, 23);
            this.btnUpPage.TabIndex = 13;
            this.btnUpPage.UseVisualStyleBackColor = true;
            // 
            // lblCounts
            // 
            this.lblCounts.AutoSize = true;
            this.lblCounts.Location = new System.Drawing.Point(6, 9);
            this.lblCounts.Name = "lblCounts";
            this.lblCounts.Size = new System.Drawing.Size(89, 12);
            this.lblCounts.TabIndex = 12;
            this.lblCounts.Text = "符合筛选条件：";
            // 
            // panelMainTop
            // 
            this.panelMainTop.Controls.Add(this.btnConfigModel);
            this.panelMainTop.Controls.Add(this.btnExportExcel);
            this.panelMainTop.Controls.Add(this.lblMainTitle);
            this.panelMainTop.Controls.Add(this.btnPrint);
            this.panelMainTop.Controls.Add(this.btnDelete);
            this.panelMainTop.Controls.Add(this.btnAdd);
            this.panelMainTop.Controls.Add(this.btnLaws);
            this.panelMainTop.Controls.Add(this.btnSelectAll);
            this.panelMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainTop.Location = new System.Drawing.Point(0, 0);
            this.panelMainTop.Name = "panelMainTop";
            this.panelMainTop.Size = new System.Drawing.Size(783, 30);
            this.panelMainTop.TabIndex = 0;
            // 
            // btnConfigModel
            // 
            this.btnConfigModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfigModel.Image = global::KJ128NMainRun.Properties.Resources.app_booth;
            this.btnConfigModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigModel.Location = new System.Drawing.Point(720, 3);
            this.btnConfigModel.Name = "btnConfigModel";
            this.btnConfigModel.Size = new System.Drawing.Size(54, 23);
            this.btnConfigModel.TabIndex = 19;
            this.btnConfigModel.Text = "设置";
            this.btnConfigModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfigModel.UseVisualStyleBackColor = true;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportExcel.Image = global::KJ128NMainRun.Properties.Resources.app_share;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(660, 3);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(54, 23);
            this.btnExportExcel.TabIndex = 20;
            this.btnExportExcel.Text = "导出";
            this.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Location = new System.Drawing.Point(6, 9);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(53, 12);
            this.lblMainTitle.TabIndex = 18;
            this.lblMainTitle.Text = "人员配置";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Image = global::KJ128NMainRun.Properties.Resources.Print_01;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(600, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(54, 23);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "打印";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Image = global::KJ128NMainRun.Properties.Resources.Delete_02;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(540, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(54, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::KJ128NMainRun.Properties.Resources.Add_01;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(360, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "新增";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnLaws
            // 
            this.btnLaws.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaws.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLaws.Image = global::KJ128NMainRun.Properties.Resources.Laws_01;
            this.btnLaws.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaws.Location = new System.Drawing.Point(480, 3);
            this.btnLaws.Name = "btnLaws";
            this.btnLaws.Size = new System.Drawing.Size(54, 23);
            this.btnLaws.TabIndex = 14;
            this.btnLaws.Text = "修改";
            this.btnLaws.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLaws.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectAll.Image = global::KJ128NMainRun.Properties.Resources.SelectAll_01;
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.Location = new System.Drawing.Point(420, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(54, 23);
            this.btnSelectAll.TabIndex = 15;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // FrmModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLeft);
            this.Name = "FrmModel";
            this.TabText = "FrmModel";
            this.Text = "FrmModel";
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelLeft;
        protected System.Windows.Forms.Panel panelMain;
        protected System.Windows.Forms.Panel panelLeftBottom;
        protected System.Windows.Forms.Panel panelMainBottom;
        protected System.Windows.Forms.Panel panelMainTop;
        protected DegonControlLib.DrawerMainControl drawerLeftMain;
        protected System.Windows.Forms.Button btnAdd;
        protected System.Windows.Forms.Label lblMainTitle;
        protected System.Windows.Forms.Button btnSelectAll;
        protected System.Windows.Forms.Button btnLaws;
        protected System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.Button btnPrint;
        protected System.Windows.Forms.Label lblSumPage;
        protected System.Windows.Forms.ComboBox cmbSelectCounts;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label7;
        protected Shine.ShineTextBox txtSkipPage;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label lblPageCounts;
        protected System.Windows.Forms.Button btnDownPage;
        protected System.Windows.Forms.Button btnUpPage;
        protected System.Windows.Forms.Label lblCounts;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Panel panelMainMain;
        protected System.Windows.Forms.Button btnConfigModel;
        protected System.Windows.Forms.Button btnExportExcel;
    }
}