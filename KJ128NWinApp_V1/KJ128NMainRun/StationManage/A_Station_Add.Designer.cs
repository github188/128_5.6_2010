namespace KJ128NMainRun.StationManage
{
    partial class A_Station_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_Station_Add));
            this.gb_AddStationInfo = new System.Windows.Forms.GroupBox();
            this.chkJHJEle = new System.Windows.Forms.CheckBox();
            this.lblJHJ = new System.Windows.Forms.Label();
            this.llb_StationPacket = new System.Windows.Forms.LinkLabel();
            this.cmb_StationPacket = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_StationModel = new System.Windows.Forms.GroupBox();
            this.rb_CheckCard = new System.Windows.Forms.RadioButton();
            this.llb_Help = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.rb_V2 = new System.Windows.Forms.RadioButton();
            this.rb_A = new System.Windows.Forms.RadioButton();
            this.txt_StationPlace = new Shine.ShineTextBox();
            this.txt_StationAddress = new Shine.ShineTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_StationTel = new Shine.ShineTextBox();
            this.bt_Station_Close = new System.Windows.Forms.Button();
            this.bt_Station_Reset = new System.Windows.Forms.Button();
            this.bt_Station_Save = new System.Windows.Forms.Button();
            this.lb_StationTipsInfo = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.pl_Help = new System.Windows.Forms.Panel();
            this.txt_Help = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_CloseHelp = new System.Windows.Forms.Button();
            this.lb_Help = new System.Windows.Forms.Label();
            this.tt1 = new System.Windows.Forms.ToolTip(this.components);
            this.gb_AddStationInfo.SuspendLayout();
            this.gb_StationModel.SuspendLayout();
            this.pl_Help.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_AddStationInfo
            // 
            this.gb_AddStationInfo.Controls.Add(this.chkJHJEle);
            this.gb_AddStationInfo.Controls.Add(this.lblJHJ);
            this.gb_AddStationInfo.Controls.Add(this.llb_StationPacket);
            this.gb_AddStationInfo.Controls.Add(this.cmb_StationPacket);
            this.gb_AddStationInfo.Controls.Add(this.label4);
            this.gb_AddStationInfo.Controls.Add(this.label19);
            this.gb_AddStationInfo.Controls.Add(this.panel1);
            this.gb_AddStationInfo.Controls.Add(this.label5);
            this.gb_AddStationInfo.Controls.Add(this.gb_StationModel);
            this.gb_AddStationInfo.Controls.Add(this.txt_StationPlace);
            this.gb_AddStationInfo.Controls.Add(this.txt_StationAddress);
            this.gb_AddStationInfo.Controls.Add(this.label6);
            this.gb_AddStationInfo.Controls.Add(this.label2);
            this.gb_AddStationInfo.Controls.Add(this.label1);
            this.gb_AddStationInfo.Location = new System.Drawing.Point(12, 12);
            this.gb_AddStationInfo.Name = "gb_AddStationInfo";
            this.gb_AddStationInfo.Size = new System.Drawing.Size(371, 188);
            this.gb_AddStationInfo.TabIndex = 0;
            this.gb_AddStationInfo.TabStop = false;
            // 
            // chkJHJEle
            // 
            this.chkJHJEle.AutoSize = true;
            this.chkJHJEle.Location = new System.Drawing.Point(295, 163);
            this.chkJHJEle.Name = "chkJHJEle";
            this.chkJHJEle.Size = new System.Drawing.Size(15, 14);
            this.chkJHJEle.TabIndex = 85;
            this.chkJHJEle.UseVisualStyleBackColor = true;
            this.chkJHJEle.CheckedChanged += new System.EventHandler(this.chkJHJEle_CheckedChanged);
            // 
            // lblJHJ
            // 
            this.lblJHJ.AutoSize = true;
            this.lblJHJ.Location = new System.Drawing.Point(171, 163);
            this.lblJHJ.Name = "lblJHJ";
            this.lblJHJ.Size = new System.Drawing.Size(125, 12);
            this.lblJHJ.TabIndex = 84;
            this.lblJHJ.Text = "关联交直流供电情况：";
            // 
            // llb_StationPacket
            // 
            this.llb_StationPacket.AutoSize = true;
            this.llb_StationPacket.Location = new System.Drawing.Point(344, 134);
            this.llb_StationPacket.Name = "llb_StationPacket";
            this.llb_StationPacket.Size = new System.Drawing.Size(11, 12);
            this.llb_StationPacket.TabIndex = 82;
            this.llb_StationPacket.TabStop = true;
            this.llb_StationPacket.Text = "?";
            this.tt1.SetToolTip(this.llb_StationPacket, "123");
            this.llb_StationPacket.MouseEnter += new System.EventHandler(this.llb_StationPacket_MouseEnter);
            // 
            // cmb_StationPacket
            // 
            this.cmb_StationPacket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StationPacket.FormattingEnabled = true;
            this.cmb_StationPacket.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmb_StationPacket.Location = new System.Drawing.Point(238, 131);
            this.cmb_StationPacket.Name = "cmb_StationPacket";
            this.cmb_StationPacket.Size = new System.Drawing.Size(100, 20);
            this.cmb_StationPacket.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(156, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 77;
            this.label4.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(156, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 12);
            this.label19.TabIndex = 20;
            this.label19.Text = "*";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(17, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 164);
            this.panel1.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 69;
            this.label5.Text = "(1-64)";
            this.label5.Visible = false;
            // 
            // gb_StationModel
            // 
            this.gb_StationModel.Controls.Add(this.rb_CheckCard);
            this.gb_StationModel.Controls.Add(this.llb_Help);
            this.gb_StationModel.Controls.Add(this.label8);
            this.gb_StationModel.Controls.Add(this.rb_V2);
            this.gb_StationModel.Controls.Add(this.rb_A);
            this.gb_StationModel.Location = new System.Drawing.Point(169, 76);
            this.gb_StationModel.Name = "gb_StationModel";
            this.gb_StationModel.Size = new System.Drawing.Size(184, 46);
            this.gb_StationModel.TabIndex = 4;
            this.gb_StationModel.TabStop = false;
            this.gb_StationModel.Text = "  传输协议";
            // 
            // rb_CheckCard
            // 
            this.rb_CheckCard.AutoSize = true;
            this.rb_CheckCard.Location = new System.Drawing.Point(111, 21);
            this.rb_CheckCard.Name = "rb_CheckCard";
            this.rb_CheckCard.Size = new System.Drawing.Size(59, 16);
            this.rb_CheckCard.TabIndex = 82;
            this.rb_CheckCard.TabStop = true;
            this.rb_CheckCard.Text = "检卡仪";
            this.rb_CheckCard.UseVisualStyleBackColor = true;
            // 
            // llb_Help
            // 
            this.llb_Help.AutoSize = true;
            this.llb_Help.Location = new System.Drawing.Point(167, 23);
            this.llb_Help.Name = "llb_Help";
            this.llb_Help.Size = new System.Drawing.Size(11, 12);
            this.llb_Help.TabIndex = 81;
            this.llb_Help.TabStop = true;
            this.llb_Help.Text = "?";
            this.tt1.SetToolTip(this.llb_Help, "123");
            this.llb_Help.MouseEnter += new System.EventHandler(this.llb_Help_MouseEnter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(10, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 80;
            this.label8.Text = "*";
            // 
            // rb_V2
            // 
            this.rb_V2.AutoSize = true;
            this.rb_V2.Location = new System.Drawing.Point(64, 21);
            this.rb_V2.Name = "rb_V2";
            this.rb_V2.Size = new System.Drawing.Size(47, 16);
            this.rb_V2.TabIndex = 1;
            this.rb_V2.TabStop = true;
            this.rb_V2.Text = "V2版";
            this.rb_V2.UseVisualStyleBackColor = true;
            // 
            // rb_A
            // 
            this.rb_A.AutoSize = true;
            this.rb_A.Checked = true;
            this.rb_A.Location = new System.Drawing.Point(20, 21);
            this.rb_A.Name = "rb_A";
            this.rb_A.Size = new System.Drawing.Size(41, 16);
            this.rb_A.TabIndex = 0;
            this.rb_A.TabStop = true;
            this.rb_A.Text = "A版";
            this.rb_A.UseVisualStyleBackColor = true;
            // 
            // txt_StationPlace
            // 
            this.txt_StationPlace.Location = new System.Drawing.Point(238, 49);
            this.txt_StationPlace.MaxLength = 20;
            this.txt_StationPlace.Name = "txt_StationPlace";
            this.txt_StationPlace.Size = new System.Drawing.Size(100, 21);
            this.txt_StationPlace.TabIndex = 3;
            this.txt_StationPlace.TextType = Shine.TextType.WithOutChar;
            this.txt_StationPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StationPlace_KeyPress);
            // 
            // txt_StationAddress
            // 
            this.txt_StationAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_StationAddress.Location = new System.Drawing.Point(238, 18);
            this.txt_StationAddress.MaxLength = 4;
            this.txt_StationAddress.Name = "txt_StationAddress";
            this.txt_StationAddress.Size = new System.Drawing.Size(53, 21);
            this.txt_StationAddress.TabIndex = 2;
            this.txt_StationAddress.TextType = Shine.TextType.Number;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 73;
            this.label6.Text = "分组编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "安装位置：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分 站 号：";
            // 
            // txt_StationTel
            // 
            this.txt_StationTel.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_StationTel.Location = new System.Drawing.Point(90, 241);
            this.txt_StationTel.MaxLength = 15;
            this.txt_StationTel.Name = "txt_StationTel";
            this.txt_StationTel.Size = new System.Drawing.Size(100, 21);
            this.txt_StationTel.TabIndex = 74;
            this.txt_StationTel.TextType = Shine.TextType.Number;
            this.txt_StationTel.Visible = false;
            this.txt_StationTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StationTel_KeyPress);
            // 
            // bt_Station_Close
            // 
            this.bt_Station_Close.Location = new System.Drawing.Point(333, 242);
            this.bt_Station_Close.Name = "bt_Station_Close";
            this.bt_Station_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_Station_Close.TabIndex = 75;
            this.bt_Station_Close.Text = "返回";
            this.bt_Station_Close.UseVisualStyleBackColor = true;
            this.bt_Station_Close.Click += new System.EventHandler(this.bt_Station_Close_Click);
            // 
            // bt_Station_Reset
            // 
            this.bt_Station_Reset.Location = new System.Drawing.Point(262, 241);
            this.bt_Station_Reset.Name = "bt_Station_Reset";
            this.bt_Station_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_Station_Reset.TabIndex = 74;
            this.bt_Station_Reset.Text = "重置";
            this.bt_Station_Reset.UseVisualStyleBackColor = true;
            this.bt_Station_Reset.Click += new System.EventHandler(this.bt_Station_Reset_Click);
            // 
            // bt_Station_Save
            // 
            this.bt_Station_Save.Location = new System.Drawing.Point(194, 241);
            this.bt_Station_Save.Name = "bt_Station_Save";
            this.bt_Station_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_Station_Save.TabIndex = 73;
            this.bt_Station_Save.Text = "保存";
            this.bt_Station_Save.UseVisualStyleBackColor = true;
            this.bt_Station_Save.Click += new System.EventHandler(this.bt_Station_Save_Click);
            // 
            // lb_StationTipsInfo
            // 
            this.lb_StationTipsInfo.AutoSize = true;
            this.lb_StationTipsInfo.Location = new System.Drawing.Point(59, 217);
            this.lb_StationTipsInfo.Name = "lb_StationTipsInfo";
            this.lb_StationTipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_StationTipsInfo.TabIndex = 77;
            this.lb_StationTipsInfo.Text = "保存成功";
            this.lb_StationTipsInfo.Visible = false;
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(12, 217);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(41, 12);
            this.label110.TabIndex = 76;
            this.label110.Text = "提示：";
            // 
            // pl_Help
            // 
            this.pl_Help.Controls.Add(this.txt_Help);
            this.pl_Help.Controls.Add(this.panel2);
            this.pl_Help.Location = new System.Drawing.Point(48, 232);
            this.pl_Help.Name = "pl_Help";
            this.pl_Help.Size = new System.Drawing.Size(41, 33);
            this.pl_Help.TabIndex = 78;
            this.pl_Help.Visible = false;
            // 
            // txt_Help
            // 
            this.txt_Help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Help.Location = new System.Drawing.Point(0, 23);
            this.txt_Help.Multiline = true;
            this.txt_Help.Name = "txt_Help";
            this.txt_Help.ReadOnly = true;
            this.txt_Help.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Help.Size = new System.Drawing.Size(41, 10);
            this.txt_Help.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_CloseHelp);
            this.panel2.Controls.Add(this.lb_Help);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(41, 23);
            this.panel2.TabIndex = 1;
            // 
            // bt_CloseHelp
            // 
            this.bt_CloseHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_CloseHelp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_CloseHelp.Location = new System.Drawing.Point(21, 3);
            this.bt_CloseHelp.Margin = new System.Windows.Forms.Padding(0);
            this.bt_CloseHelp.Name = "bt_CloseHelp";
            this.bt_CloseHelp.Size = new System.Drawing.Size(18, 18);
            this.bt_CloseHelp.TabIndex = 1;
            this.bt_CloseHelp.Text = "×";
            this.bt_CloseHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_CloseHelp.UseVisualStyleBackColor = true;
            this.bt_CloseHelp.Click += new System.EventHandler(this.bt_CloseHelp_Click);
            // 
            // lb_Help
            // 
            this.lb_Help.AutoSize = true;
            this.lb_Help.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Help.Location = new System.Drawing.Point(147, 5);
            this.lb_Help.Name = "lb_Help";
            this.lb_Help.Size = new System.Drawing.Size(83, 12);
            this.lb_Help.TabIndex = 0;
            this.lb_Help.Text = "传输协议帮助";
            // 
            // tt1
            // 
            this.tt1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tt1.ToolTipTitle = "传输协议";
            // 
            // A_Station_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 276);
            this.Controls.Add(this.pl_Help);
            this.Controls.Add(this.lb_StationTipsInfo);
            this.Controls.Add(this.label110);
            this.Controls.Add(this.bt_Station_Close);
            this.Controls.Add(this.bt_Station_Reset);
            this.Controls.Add(this.txt_StationTel);
            this.Controls.Add(this.bt_Station_Save);
            this.Controls.Add(this.gb_AddStationInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_Station_Add";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增传输分站";
            this.gb_AddStationInfo.ResumeLayout(false);
            this.gb_AddStationInfo.PerformLayout();
            this.gb_StationModel.ResumeLayout(false);
            this.gb_StationModel.PerformLayout();
            this.pl_Help.ResumeLayout(false);
            this.pl_Help.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_AddStationInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Shine.ShineTextBox txt_StationAddress;
        private Shine.ShineTextBox txt_StationPlace;
        private System.Windows.Forms.GroupBox gb_StationModel;
        private System.Windows.Forms.RadioButton rb_A;
        private System.Windows.Forms.RadioButton rb_V2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Shine.ShineTextBox txt_StationTel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_StationPacket;
        private System.Windows.Forms.Button bt_Station_Close;
        private System.Windows.Forms.Button bt_Station_Reset;
        private System.Windows.Forms.Button bt_Station_Save;
        private System.Windows.Forms.Label lb_StationTipsInfo;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.LinkLabel llb_Help;
        private System.Windows.Forms.Panel pl_Help;
        private System.Windows.Forms.TextBox txt_Help;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_CloseHelp;
        private System.Windows.Forms.Label lb_Help;
        private System.Windows.Forms.ToolTip tt1;
        private System.Windows.Forms.LinkLabel llb_StationPacket;
        private System.Windows.Forms.RadioButton rb_CheckCard;
        private System.Windows.Forms.CheckBox chkJHJEle;
        private System.Windows.Forms.Label lblJHJ;
    }
}