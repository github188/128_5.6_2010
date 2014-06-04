namespace KJ128NMainRun.Graphics
{
    partial class A_FrmRouteConfig
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_FrmRouteConfig));
            this.MapGis = new ZzhaControlLibrary.ZzhaMapGis();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRollback = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.操作WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入路径LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadRoute = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUseMap = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();
            // 
            // MapGis
            // 
            this.MapGis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MapGis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MapGis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MapGis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapGis.HashNameColor = ((System.Collections.Hashtable)(resources.GetObject("MapGis.HashNameColor")));
            this.MapGis.Index = 0;
            this.MapGis.IsMoving = false;
            this.MapGis.IsPaintRoute = false;
            this.MapGis.IsStationChangeed = false;
            this.MapGis.Location = new System.Drawing.Point(171, 0);
            this.MapGis.MapFilePath = null;
            this.MapGis.MaxWidth = 35000;
            this.MapGis.MinWidth = 500;
            this.MapGis.MoverStrColor = System.Drawing.Color.Red;
            this.MapGis.Name = "MapGis";
            this.MapGis.ShowStationOther = false;
            this.MapGis.Size = new System.Drawing.Size(816, 523);
            this.MapGis.StartPoint = ((System.Drawing.PointF)(resources.GetObject("MapGis.StartPoint")));
            this.MapGis.StationFilePath = null;
            this.MapGis.StationStrColor = System.Drawing.Color.Red;
            this.MapGis.StrImpEmpName = "";
            this.MapGis.StrNameAndColor = null;
            this.MapGis.TabIndex = 0;
            this.MapGis.UseDiv = false;
            this.MapGis.UseGif = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(6, 308);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRollback.Location = new System.Drawing.Point(88, 273);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(75, 23);
            this.btnRollback.TabIndex = 2;
            this.btnRollback.Text = "撤销";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreate.Location = new System.Drawing.Point(88, 308);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "生成路径点";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作WToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(987, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // 操作WToolStripMenuItem
            // 
            this.操作WToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.载入路径LToolStripMenuItem});
            this.操作WToolStripMenuItem.Name = "操作WToolStripMenuItem";
            this.操作WToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.操作WToolStripMenuItem.Text = "操作(&W)";
            // 
            // 载入路径LToolStripMenuItem
            // 
            this.载入路径LToolStripMenuItem.Name = "载入路径LToolStripMenuItem";
            this.载入路径LToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.载入路径LToolStripMenuItem.Text = "载入路径(&L)";
            this.载入路径LToolStripMenuItem.Click += new System.EventHandler(this.载入路径LToolStripMenuItem_Click);
            // 
            // btnLoadRoute
            // 
            this.btnLoadRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadRoute.Location = new System.Drawing.Point(6, 273);
            this.btnLoadRoute.Name = "btnLoadRoute";
            this.btnLoadRoute.Size = new System.Drawing.Size(75, 23);
            this.btnLoadRoute.TabIndex = 5;
            this.btnLoadRoute.Text = "载入路径";
            this.btnLoadRoute.UseVisualStyleBackColor = true;
            this.btnLoadRoute.Click += new System.EventHandler(this.btnLoadRoute_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnUseMap);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.txtFilePath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picImg);
            this.panel1.Controls.Add(this.btnRollback);
            this.panel1.Controls.Add(this.btnLoadRoute);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 347);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "底图及轨迹配置";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnUseMap
            // 
            this.btnUseMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUseMap.Location = new System.Drawing.Point(88, 238);
            this.btnUseMap.Name = "btnUseMap";
            this.btnUseMap.Size = new System.Drawing.Size(75, 23);
            this.btnUseMap.TabIndex = 10;
            this.btnUseMap.Text = "应用该图";
            this.btnUseMap.UseVisualStyleBackColor = true;
            this.btnUseMap.Click += new System.EventHandler(this.btnUseMap_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(134, 54);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(29, 23);
            this.btnOpen.TabIndex = 9;
            this.btnOpen.Text = "...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilePath.Location = new System.Drawing.Point(6, 55);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(122, 21);
            this.txtFilePath.TabIndex = 8;
            this.txtFilePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilePath_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "底图选择:";
            // 
            // picImg
            // 
            this.picImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImg.Location = new System.Drawing.Point(6, 87);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(157, 141);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImg.TabIndex = 6;
            this.picImg.TabStop = false;
            // 
            // A_FrmRouteConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MapGis);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "A_FrmRouteConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "底图及轨迹配置";
            this.Text = "底图及轨迹配置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRouteConfig_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZzhaControlLibrary.ZzhaMapGis MapGis;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 操作WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 载入路径LToolStripMenuItem;
        private System.Windows.Forms.Button btnLoadRoute;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUseMap;
        private System.Windows.Forms.Button button1;
    }
}