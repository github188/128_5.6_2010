namespace KJ128NMainRun.Graphics.A_DPic_Wizard
{
    partial class A_DPic_RouteConfig
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRollback = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxLineStyleChoose = new System.Windows.Forms.GroupBox();
            this.rbnLine = new System.Windows.Forms.RadioButton();
            this.rbnPolyLine = new System.Windows.Forms.RadioButton();
            this.btn_BeginDrawRoute = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MapGis = new ZzhaControlLibrary.ZzhaMapGis();
            this.panel1.SuspendLayout();
            this.gbxLineStyleChoose.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(38, 99);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRollback.Location = new System.Drawing.Point(119, 99);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(75, 23);
            this.btnRollback.TabIndex = 2;
            this.btnRollback.Text = "撤销";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(38, 99);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "生成轨迹";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Visible = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gbxLineStyleChoose);
            this.panel1.Controls.Add(this.btn_BeginDrawRoute);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnRollback);
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 177);
            this.panel1.TabIndex = 4;
            // 
            // gbxLineStyleChoose
            // 
            this.gbxLineStyleChoose.Controls.Add(this.rbnLine);
            this.gbxLineStyleChoose.Controls.Add(this.rbnPolyLine);
            this.gbxLineStyleChoose.Location = new System.Drawing.Point(27, 12);
            this.gbxLineStyleChoose.Name = "gbxLineStyleChoose";
            this.gbxLineStyleChoose.Size = new System.Drawing.Size(167, 74);
            this.gbxLineStyleChoose.TabIndex = 19;
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
            this.rbnLine.CheckedChanged += new System.EventHandler(this.rbnLine_CheckedChanged);
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
            this.btn_BeginDrawRoute.Location = new System.Drawing.Point(38, 99);
            this.btn_BeginDrawRoute.Name = "btn_BeginDrawRoute";
            this.btn_BeginDrawRoute.Size = new System.Drawing.Size(75, 23);
            this.btn_BeginDrawRoute.TabIndex = 16;
            this.btn_BeginDrawRoute.Text = "开始画路径";
            this.btn_BeginDrawRoute.UseVisualStyleBackColor = true;
            this.btn_BeginDrawRoute.Click += new System.EventHandler(this.btn_BeginDrawRoute_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(119, 128);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 15;
            this.btnPreview.Text = "上一步";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(38, 128);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(75, 23);
            this.btnComplete.TabIndex = 14;
            this.btnComplete.Text = "完成";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 278);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本步骤操作指南";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "第四步.单击完成按钮";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 72);
            this.label4.TabIndex = 3;
            this.label4.Text = "第三步.所有分站的位置放置完后，就开始\r\n       画路径线了，在底图上左键单击、\r\n       移动、单击即可画出一条线段了，\r\n       按照这种方" +
                "法把所有分站沿底图的\r\n       巷道连通即可；如果想回一步，单\r\n       击撤销按钮。";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 48);
            this.label3.TabIndex = 2;
            this.label3.Text = "第二步.在右边的煤矿底图上双击左键，标\r\n       记为蓝色的分站就会出现在你双击\r\n       的位置；按下左键并拖动就可以移\r\n       动分站了。" +
                "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "第一步.单击本栏右边的箭头，当分站列表\r\n　　　 弹出后，列表中的第一个分站已经\r\n　　　 被默认选中标为蓝色。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本步骤为图形配置向导第五步";
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
            this.MapGis.Location = new System.Drawing.Point(247, 0);
            this.MapGis.MapFilePath = null;
            this.MapGis.MaxWidth = 35000;
            this.MapGis.MinWidth = 500;
            this.MapGis.MoverStrColor = System.Drawing.Color.Red;
            this.MapGis.Name = "MapGis";
            this.MapGis.ShowStationOther = false;
            this.MapGis.Size = new System.Drawing.Size(740, 523);
            this.MapGis.StationFilePath = null;
            this.MapGis.StationStrColor = System.Drawing.Color.Red;
            this.MapGis.TabIndex = 0;
            this.MapGis.UseDiv = false;
            this.MapGis.UseGif = false;
            // 
            // A_DPic_RouteConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MapGis);
            this.Name = "A_DPic_RouteConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图形配置向导　第五步　配置分站坐标及路径";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRouteConfig_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_FrmDRouteConfig_FormClosing);
            this.panel1.ResumeLayout(false);
            this.gbxLineStyleChoose.ResumeLayout(false);
            this.gbxLineStyleChoose.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZzhaControlLibrary.ZzhaMapGis MapGis;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btn_BeginDrawRoute;
        private System.Windows.Forms.GroupBox gbxLineStyleChoose;
        private System.Windows.Forms.RadioButton rbnLine;
        private System.Windows.Forms.RadioButton rbnPolyLine;
    }
}