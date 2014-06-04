namespace KJ128NMainRun.AreaManage
{
    partial class A_FrmAreaManage_AddTerSet
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
            this.bt_TerSet_Close = new System.Windows.Forms.Button();
            this.bt_TerSet_Reset = new System.Windows.Forms.Button();
            this.bt_TerSet_Save = new System.Windows.Forms.Button();
            this.lb_TerSetTipsInfo = new System.Windows.Forms.Label();
            this.lb_TerSetTipsInfo2 = new System.Windows.Forms.Label();
            this.gb_AddTerSetInfo = new System.Windows.Forms.GroupBox();
            this.bt_Left = new System.Windows.Forms.Button();
            this.bt_Right = new System.Windows.Forms.Button();
            this.tvc_StationHead_Ter = new DegonControlLib.TreeViewControl();
            this.chb_IsTer = new System.Windows.Forms.CheckBox();
            this.tvc_StationHead_All = new DegonControlLib.TreeViewControl();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gb_AddTerSetInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_TerSet_Close
            // 
            this.bt_TerSet_Close.Location = new System.Drawing.Point(320, 313);
            this.bt_TerSet_Close.Name = "bt_TerSet_Close";
            this.bt_TerSet_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_TerSet_Close.TabIndex = 74;
            this.bt_TerSet_Close.Text = "返回";
            this.bt_TerSet_Close.UseVisualStyleBackColor = true;
            this.bt_TerSet_Close.Click += new System.EventHandler(this.bt_TerSet_Close_Click);
            // 
            // bt_TerSet_Reset
            // 
            this.bt_TerSet_Reset.Location = new System.Drawing.Point(253, 313);
            this.bt_TerSet_Reset.Name = "bt_TerSet_Reset";
            this.bt_TerSet_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_TerSet_Reset.TabIndex = 73;
            this.bt_TerSet_Reset.Text = "重置";
            this.bt_TerSet_Reset.UseVisualStyleBackColor = true;
            this.bt_TerSet_Reset.Click += new System.EventHandler(this.bt_TerSet_Reset_Click);
            // 
            // bt_TerSet_Save
            // 
            this.bt_TerSet_Save.Location = new System.Drawing.Point(185, 313);
            this.bt_TerSet_Save.Name = "bt_TerSet_Save";
            this.bt_TerSet_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_TerSet_Save.TabIndex = 72;
            this.bt_TerSet_Save.Text = "保存";
            this.bt_TerSet_Save.UseVisualStyleBackColor = true;
            this.bt_TerSet_Save.Click += new System.EventHandler(this.bt_TerSet_Save_Click);
            // 
            // lb_TerSetTipsInfo
            // 
            this.lb_TerSetTipsInfo.AutoSize = true;
            this.lb_TerSetTipsInfo.Location = new System.Drawing.Point(57, 297);
            this.lb_TerSetTipsInfo.Name = "lb_TerSetTipsInfo";
            this.lb_TerSetTipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_TerSetTipsInfo.TabIndex = 71;
            this.lb_TerSetTipsInfo.Text = "保存成功";
            // 
            // lb_TerSetTipsInfo2
            // 
            this.lb_TerSetTipsInfo2.AutoSize = true;
            this.lb_TerSetTipsInfo2.Location = new System.Drawing.Point(10, 297);
            this.lb_TerSetTipsInfo2.Name = "lb_TerSetTipsInfo2";
            this.lb_TerSetTipsInfo2.Size = new System.Drawing.Size(41, 12);
            this.lb_TerSetTipsInfo2.TabIndex = 70;
            this.lb_TerSetTipsInfo2.Text = "提示：";
            // 
            // gb_AddTerSetInfo
            // 
            this.gb_AddTerSetInfo.BackColor = System.Drawing.SystemColors.Control;
            this.gb_AddTerSetInfo.Controls.Add(this.bt_Left);
            this.gb_AddTerSetInfo.Controls.Add(this.bt_Right);
            this.gb_AddTerSetInfo.Controls.Add(this.tvc_StationHead_Ter);
            this.gb_AddTerSetInfo.Controls.Add(this.chb_IsTer);
            this.gb_AddTerSetInfo.Controls.Add(this.tvc_StationHead_All);
            this.gb_AddTerSetInfo.Controls.Add(this.label12);
            this.gb_AddTerSetInfo.Controls.Add(this.label11);
            this.gb_AddTerSetInfo.Location = new System.Drawing.Point(1, 6);
            this.gb_AddTerSetInfo.Name = "gb_AddTerSetInfo";
            this.gb_AddTerSetInfo.Size = new System.Drawing.Size(404, 277);
            this.gb_AddTerSetInfo.TabIndex = 69;
            this.gb_AddTerSetInfo.TabStop = false;
            // 
            // bt_Left
            // 
            this.bt_Left.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Left.Location = new System.Drawing.Point(179, 177);
            this.bt_Left.Name = "bt_Left";
            this.bt_Left.Size = new System.Drawing.Size(41, 23);
            this.bt_Left.TabIndex = 7;
            this.bt_Left.Text = "<-";
            this.bt_Left.UseVisualStyleBackColor = true;
            this.bt_Left.Click += new System.EventHandler(this.bt_Left_Click);
            // 
            // bt_Right
            // 
            this.bt_Right.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Right.Location = new System.Drawing.Point(179, 123);
            this.bt_Right.Name = "bt_Right";
            this.bt_Right.Size = new System.Drawing.Size(41, 23);
            this.bt_Right.TabIndex = 6;
            this.bt_Right.Text = "->";
            this.bt_Right.UseVisualStyleBackColor = true;
            this.bt_Right.Click += new System.EventHandler(this.bt_Right_Click);
            // 
            // tvc_StationHead_Ter
            // 
            this.tvc_StationHead_Ter.Location = new System.Drawing.Point(231, 32);
            this.tvc_StationHead_Ter.Name = "tvc_StationHead_Ter";
            this.tvc_StationHead_Ter.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_StationHead_Ter.Size = new System.Drawing.Size(164, 238);
            this.tvc_StationHead_Ter.TabIndex = 5;
            // 
            // chb_IsTer
            // 
            this.chb_IsTer.BackColor = System.Drawing.Color.Transparent;
            this.chb_IsTer.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chb_IsTer.Location = new System.Drawing.Point(174, 77);
            this.chb_IsTer.Name = "chb_IsTer";
            this.chb_IsTer.Size = new System.Drawing.Size(61, 37);
            this.chb_IsTer.TabIndex = 4;
            this.chb_IsTer.Text = "是否为区域口";
            this.chb_IsTer.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chb_IsTer.UseVisualStyleBackColor = false;
            // 
            // tvc_StationHead_All
            // 
            this.tvc_StationHead_All.Location = new System.Drawing.Point(6, 32);
            this.tvc_StationHead_All.Name = "tvc_StationHead_All";
            this.tvc_StationHead_All.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_StationHead_All.Size = new System.Drawing.Size(164, 238);
            this.tvc_StationHead_All.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(245, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "区域读卡分站：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "系统读卡分站：";
            // 
            // A_FrmAreaManage_AddTerSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(407, 342);
            this.Controls.Add(this.bt_TerSet_Close);
            this.Controls.Add(this.bt_TerSet_Reset);
            this.Controls.Add(this.bt_TerSet_Save);
            this.Controls.Add(this.lb_TerSetTipsInfo);
            this.Controls.Add(this.lb_TerSetTipsInfo2);
            this.Controls.Add(this.gb_AddTerSetInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_FrmAreaManage_AddTerSet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增区域范围";
            this.gb_AddTerSetInfo.ResumeLayout(false);
            this.gb_AddTerSetInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_TerSet_Close;
        private System.Windows.Forms.Button bt_TerSet_Reset;
        private System.Windows.Forms.Button bt_TerSet_Save;
        private System.Windows.Forms.Label lb_TerSetTipsInfo;
        private System.Windows.Forms.Label lb_TerSetTipsInfo2;
        private System.Windows.Forms.GroupBox gb_AddTerSetInfo;
        private System.Windows.Forms.Button bt_Left;
        private System.Windows.Forms.Button bt_Right;
        private DegonControlLib.TreeViewControl tvc_StationHead_Ter;
        private System.Windows.Forms.CheckBox chb_IsTer;
        private DegonControlLib.TreeViewControl tvc_StationHead_All;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}