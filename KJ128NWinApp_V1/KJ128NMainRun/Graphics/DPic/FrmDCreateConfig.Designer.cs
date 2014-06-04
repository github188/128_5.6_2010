namespace KJ128NMainRun.Graphics.DPic
{
    partial class FrmDCreateConfig
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
            this.pnlInOut = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnMoni = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lnkSave = new System.Windows.Forms.LinkLabel();
            this.lklLoadMap = new System.Windows.Forms.LinkLabel();
            this.trvDiv = new System.Windows.Forms.TreeView();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.ntbMax = new Shine.Command.Controls.NumTextBox();
            this.ntbMin = new Shine.Command.Controls.NumTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.btnMapSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picInOut = new System.Windows.Forms.PictureBox();
            this.cmsDiv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDel = new System.Windows.Forms.ToolStripMenuItem();
            this.MapGis = new ZzhaControlLibrary.ZzhaMapGis();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInOut)).BeginInit();
            this.cmsDiv.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInOut
            // 
            this.pnlInOut.BackgroundImage = global::KJ128NMainRun.Properties.Resources.ffrm;
            this.pnlInOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInOut.Controls.Add(this.btnNew);
            this.pnlInOut.Controls.Add(this.btnMoni);
            this.pnlInOut.Controls.Add(this.btnSave);
            this.pnlInOut.Controls.Add(this.lnkSave);
            this.pnlInOut.Controls.Add(this.lklLoadMap);
            this.pnlInOut.Controls.Add(this.trvDiv);
            this.pnlInOut.Controls.Add(this.lnkNew);
            this.pnlInOut.Controls.Add(this.ntbMax);
            this.pnlInOut.Controls.Add(this.ntbMin);
            this.pnlInOut.Controls.Add(this.label5);
            this.pnlInOut.Controls.Add(this.label4);
            this.pnlInOut.Controls.Add(this.label3);
            this.pnlInOut.Controls.Add(this.label2);
            this.pnlInOut.Controls.Add(this.picMap);
            this.pnlInOut.Controls.Add(this.btnMapSelect);
            this.pnlInOut.Controls.Add(this.label1);
            this.pnlInOut.Controls.Add(this.picInOut);
            this.pnlInOut.Location = new System.Drawing.Point(-200, 57);
            this.pnlInOut.Name = "pnlInOut";
            this.pnlInOut.Size = new System.Drawing.Size(229, 336);
            this.pnlInOut.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(114, 107);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnMoni
            // 
            this.btnMoni.Location = new System.Drawing.Point(114, 306);
            this.btnMoni.Name = "btnMoni";
            this.btnMoni.Size = new System.Drawing.Size(75, 23);
            this.btnMoni.TabIndex = 18;
            this.btnMoni.Text = "模拟全图";
            this.btnMoni.UseVisualStyleBackColor = true;
            this.btnMoni.Click += new System.EventHandler(this.btnMoni_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lnkSave
            // 
            this.lnkSave.AutoSize = true;
            this.lnkSave.Location = new System.Drawing.Point(18, 309);
            this.lnkSave.Name = "lnkSave";
            this.lnkSave.Size = new System.Drawing.Size(29, 12);
            this.lnkSave.TabIndex = 16;
            this.lnkSave.TabStop = true;
            this.lnkSave.Text = "保存";
            this.lnkSave.Visible = false;
            this.lnkSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSave_LinkClicked);
            // 
            // lklLoadMap
            // 
            this.lklLoadMap.AutoSize = true;
            this.lklLoadMap.Location = new System.Drawing.Point(136, 309);
            this.lklLoadMap.Name = "lklLoadMap";
            this.lklLoadMap.Size = new System.Drawing.Size(53, 12);
            this.lklLoadMap.TabIndex = 5;
            this.lklLoadMap.TabStop = true;
            this.lklLoadMap.Text = "模拟全图";
            this.lklLoadMap.Visible = false;
            this.lklLoadMap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklLoadMap_LinkClicked);
            // 
            // trvDiv
            // 
            this.trvDiv.Location = new System.Drawing.Point(15, 132);
            this.trvDiv.Name = "trvDiv";
            this.trvDiv.Size = new System.Drawing.Size(174, 169);
            this.trvDiv.TabIndex = 4;
            this.trvDiv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvDiv_MouseDown);
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(160, 115);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(29, 12);
            this.lnkNew.TabIndex = 13;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新建";
            this.lnkNew.Visible = false;
            this.lnkNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNew_LinkClicked);
            // 
            // ntbMax
            // 
            this.ntbMax.BoundValue = "1-100000";
            this.ntbMax.DefaultStyle = true;
            this.ntbMax.IsUseCopy = true;
            this.ntbMax.IsUseCut = true;
            this.ntbMax.IsUseNegative = false;
            this.ntbMax.IsUseStickUP = true;
            this.ntbMax.Location = new System.Drawing.Point(123, 80);
            this.ntbMax.Name = "ntbMax";
            this.ntbMax.NumberTypes = Shine.Command.Controls.NumberValidate.NumberType.Int;
            this.ntbMax.Size = new System.Drawing.Size(49, 21);
            this.ntbMax.TabIndex = 2;
            this.ntbMax.Leave += new System.EventHandler(this.ntbMax_Leave);
            // 
            // ntbMin
            // 
            this.ntbMin.BoundValue = "1-100000";
            this.ntbMin.DefaultStyle = true;
            this.ntbMin.IsUseCopy = true;
            this.ntbMin.IsUseCut = true;
            this.ntbMin.IsUseNegative = false;
            this.ntbMin.IsUseStickUP = true;
            this.ntbMin.Location = new System.Drawing.Point(123, 54);
            this.ntbMin.Name = "ntbMin";
            this.ntbMin.NumberTypes = Shine.Command.Controls.NumberValidate.NumberType.Int;
            this.ntbMin.Size = new System.Drawing.Size(49, 21);
            this.ntbMin.TabIndex = 1;
            this.ntbMin.Leave += new System.EventHandler(this.ntbMin_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(18, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "图层";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(88, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "最大";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(88, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "最小";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(88, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "显示范围:";
            // 
            // picMap
            // 
            this.picMap.BackColor = System.Drawing.Color.Transparent;
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMap.Location = new System.Drawing.Point(15, 39);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(67, 63);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMap.TabIndex = 3;
            this.picMap.TabStop = false;
            // 
            // btnMapSelect
            // 
            this.btnMapSelect.Location = new System.Drawing.Point(64, 10);
            this.btnMapSelect.Name = "btnMapSelect";
            this.btnMapSelect.Size = new System.Drawing.Size(55, 23);
            this.btnMapSelect.TabIndex = 0;
            this.btnMapSelect.Text = "选择";
            this.btnMapSelect.UseVisualStyleBackColor = true;
            this.btnMapSelect.Click += new System.EventHandler(this.btnMapSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "底图";
            // 
            // picInOut
            // 
            this.picInOut.BackColor = System.Drawing.Color.White;
            this.picInOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.right;
            this.picInOut.Location = new System.Drawing.Point(199, 15);
            this.picInOut.Name = "picInOut";
            this.picInOut.Size = new System.Drawing.Size(25, 306);
            this.picInOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picInOut.TabIndex = 0;
            this.picInOut.TabStop = false;
            this.picInOut.Click += new System.EventHandler(this.picInOut_Click);
            // 
            // cmsDiv
            // 
            this.cmsDiv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEdit,
            this.tsmDel});
            this.cmsDiv.Name = "cmsDiv";
            this.cmsDiv.Size = new System.Drawing.Size(95, 48);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(94, 22);
            this.tsmEdit.Text = "编辑";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmDel
            // 
            this.tsmDel.Name = "tsmDel";
            this.tsmDel.Size = new System.Drawing.Size(94, 22);
            this.tsmDel.Text = "删除";
            this.tsmDel.Click += new System.EventHandler(this.tsmDel_Click);
            // 
            // MapGis
            // 
            this.MapGis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MapGis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MapGis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapGis.IsMoving = false;
            this.MapGis.IsStationChangeed = false;
            this.MapGis.Location = new System.Drawing.Point(0, 24);
            this.MapGis.MapFilePath = null;
            this.MapGis.MaxWidth = 0;
            this.MapGis.MinWidth = 0;
            this.MapGis.MoverStrColor = System.Drawing.Color.Red;
            this.MapGis.Name = "MapGis";
            this.MapGis.ShowStationOther = false;
            this.MapGis.Size = new System.Drawing.Size(904, 610);
            this.MapGis.StationFilePath = null;
            this.MapGis.StationStrColor = System.Drawing.Color.Red;
            this.MapGis.TabIndex = 0;
            this.MapGis.UseDiv = false;
            this.MapGis.UseGif = true;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(904, 24);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "菜单";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiOpen,
            this.tsmiClose,
            this.toolStripSeparator1,
            this.tsmiSave,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(59, 20);
            this.tsmFile.Text = "文件(&F)";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(112, 22);
            this.tsmiNew.Text = "新建(&N)";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(112, 22);
            this.tsmiOpen.Text = "打开(&O)";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(112, 22);
            this.tsmiClose.Text = "关闭(&C)";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(112, 22);
            this.tsmiSave.Text = "保存(&S)";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(109, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(112, 22);
            this.tsmiExit.Text = "退出(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // FrmCreateConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 635);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.pnlInOut);
            this.Controls.Add(this.MapGis);
            this.Name = "FrmCreateConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "图形配置文件系统";
            this.Text = "图形图层配置文件系统";
            this.Load += new System.EventHandler(this.FrmCreateConfig_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCreateConfig_FormClosing);
            this.pnlInOut.ResumeLayout(false);
            this.pnlInOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInOut)).EndInit();
            this.cmsDiv.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZzhaControlLibrary.ZzhaMapGis MapGis;
        private System.Windows.Forms.Panel pnlInOut;
        private System.Windows.Forms.PictureBox picInOut;
        private System.Windows.Forms.Button btnMapSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picMap;
        private Shine.Command.Controls.NumTextBox ntbMax;
        private Shine.Command.Controls.NumTextBox ntbMin;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.ContextMenuStrip cmsDiv;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDel;
        private System.Windows.Forms.TreeView trvDiv;
        private System.Windows.Forms.LinkLabel lklLoadMap;
        private System.Windows.Forms.LinkLabel lnkSave;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.Button btnMoni;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;


    }
}