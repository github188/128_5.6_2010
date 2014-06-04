namespace KJ128NMainRun.Graphics.Expert
{
    partial class A_FrmDRouteConfig
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
            this.MapGis = new ZzhaControlLibrary.ZzhaMapGis();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRollback = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxLineStyleChoose = new System.Windows.Forms.GroupBox();
            this.rbnLine = new System.Windows.Forms.RadioButton();
            this.rbnPolyLine = new System.Windows.Forms.RadioButton();
            this.btn_BeginDrawRoute = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadRoute = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbxLineStyleChoose.SuspendLayout();
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
            this.MapGis.IsMoving = false;
            this.MapGis.IsStationChangeed = false;
            this.MapGis.Location = new System.Drawing.Point(203, 0);
            this.MapGis.MapFilePath = null;
            this.MapGis.MaxWidth = 35000;
            this.MapGis.MinWidth = 500;
            this.MapGis.MoverStrColor = System.Drawing.Color.Red;
            this.MapGis.Name = "MapGis";
            this.MapGis.ShowStationOther = false;
            this.MapGis.Size = new System.Drawing.Size(784, 523);
            this.MapGis.StationFilePath = null;
            this.MapGis.StationStrColor = System.Drawing.Color.Red;
            this.MapGis.TabIndex = 0;
            this.MapGis.UseDiv = false;
            this.MapGis.UseGif = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(11, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRollback.Location = new System.Drawing.Point(97, 133);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(75, 23);
            this.btnRollback.TabIndex = 2;
            this.btnRollback.Text = "撤销";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(97, 324);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "生成轨迹";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gbxLineStyleChoose);
            this.panel1.Controls.Add(this.btn_BeginDrawRoute);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnLoadRoute);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnRollback);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 357);
            this.panel1.TabIndex = 4;
            // 
            // gbxLineStyleChoose
            // 
            this.gbxLineStyleChoose.Controls.Add(this.rbnLine);
            this.gbxLineStyleChoose.Controls.Add(this.rbnPolyLine);
            this.gbxLineStyleChoose.Location = new System.Drawing.Point(8, 43);
            this.gbxLineStyleChoose.Name = "gbxLineStyleChoose";
            this.gbxLineStyleChoose.Size = new System.Drawing.Size(167, 74);
            this.gbxLineStyleChoose.TabIndex = 21;
            this.gbxLineStyleChoose.TabStop = false;
            this.gbxLineStyleChoose.Text = "路径点连线方式";
            // 
            // rbnLine
            // 
            this.rbnLine.AutoSize = true;
            this.rbnLine.Checked = true;
            this.rbnLine.Location = new System.Drawing.Point(15, 22);
            this.rbnLine.Name = "rbnLine";
            this.rbnLine.Size = new System.Drawing.Size(71, 16);
            this.rbnLine.TabIndex = 17;
            this.rbnLine.TabStop = true;
            this.rbnLine.Text = "两点连线";
            this.rbnLine.UseVisualStyleBackColor = true;
            this.rbnLine.Click += new System.EventHandler(this.rbnLine_Click);
            // 
            // rbnPolyLine
            // 
            this.rbnPolyLine.AutoSize = true;
            this.rbnPolyLine.Location = new System.Drawing.Point(15, 47);
            this.rbnPolyLine.Name = "rbnPolyLine";
            this.rbnPolyLine.Size = new System.Drawing.Size(71, 16);
            this.rbnPolyLine.TabIndex = 18;
            this.rbnPolyLine.Text = "多点连线";
            this.rbnPolyLine.UseVisualStyleBackColor = true;
            this.rbnPolyLine.Click += new System.EventHandler(this.rbnPolyLine_Click);
            // 
            // btn_BeginDrawRoute
            // 
            this.btn_BeginDrawRoute.Location = new System.Drawing.Point(11, 133);
            this.btn_BeginDrawRoute.Name = "btn_BeginDrawRoute";
            this.btn_BeginDrawRoute.Size = new System.Drawing.Size(75, 23);
            this.btn_BeginDrawRoute.TabIndex = 20;
            this.btn_BeginDrawRoute.Text = "开始画路径";
            this.btn_BeginDrawRoute.UseVisualStyleBackColor = true;
            this.btn_BeginDrawRoute.Click += new System.EventHandler(this.btn_BeginDrawRoute_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "底图及轨迹配置";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnLoadRoute
            // 
            this.btnLoadRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadRoute.Location = new System.Drawing.Point(11, 295);
            this.btnLoadRoute.Name = "btnLoadRoute";
            this.btnLoadRoute.Size = new System.Drawing.Size(161, 23);
            this.btnLoadRoute.TabIndex = 6;
            this.btnLoadRoute.Text = "载入路径";
            this.btnLoadRoute.UseVisualStyleBackColor = true;
            this.btnLoadRoute.Click += new System.EventHandler(this.btnLoadRoute_Click);
            // 
            // A_FrmDRouteConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MapGis);
            this.Name = "A_FrmDRouteConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "分站及路径配置";
            this.Text = "显示内容及轨迹设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRouteConfig_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_FrmDRouteConfig_FormClosing);
            this.panel1.ResumeLayout(false);
            this.gbxLineStyleChoose.ResumeLayout(false);
            this.gbxLineStyleChoose.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZzhaControlLibrary.ZzhaMapGis MapGis;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadRoute;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbxLineStyleChoose;
        private System.Windows.Forms.RadioButton rbnLine;
        private System.Windows.Forms.RadioButton rbnPolyLine;
        private System.Windows.Forms.Button btn_BeginDrawRoute;
    }
}