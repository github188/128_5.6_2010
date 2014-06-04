namespace KJ128NMainRun.A_Speed
{
    partial class A_FrmWalkConfig_Add
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
            this.gb_WalkInfo = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Remark = new Shine.ShineTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Lack = new System.Windows.Forms.CheckBox();
            this.txt_LackSecond = new Shine.ShineTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_LackMinute = new Shine.ShineTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_LackHour = new Shine.ShineTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Over = new System.Windows.Forms.CheckBox();
            this.txt_OverSecond = new Shine.ShineTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_OverMinute = new Shine.ShineTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_OverHour = new Shine.ShineTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gb_First = new System.Windows.Forms.GroupBox();
            this.txt_FirstStationHeadPlace = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_FirstStaHead = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_FirstStation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Last = new System.Windows.Forms.GroupBox();
            this.txt_LastStationHeadPlace = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_LastStaHead = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_LastStation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_Close = new System.Windows.Forms.Button();
            this.bt_Reset = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.lb_TipsInfo = new System.Windows.Forms.Label();
            this.lb_TipsInfo2 = new System.Windows.Forms.Label();
            this.gb_WalkInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gb_First.SuspendLayout();
            this.gb_Last.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_WalkInfo
            // 
            this.gb_WalkInfo.Controls.Add(this.label15);
            this.gb_WalkInfo.Controls.Add(this.txt_Remark);
            this.gb_WalkInfo.Controls.Add(this.groupBox3);
            this.gb_WalkInfo.Controls.Add(this.gb_First);
            this.gb_WalkInfo.Controls.Add(this.gb_Last);
            this.gb_WalkInfo.Location = new System.Drawing.Point(12, 12);
            this.gb_WalkInfo.Name = "gb_WalkInfo";
            this.gb_WalkInfo.Size = new System.Drawing.Size(436, 355);
            this.gb_WalkInfo.TabIndex = 70;
            this.gb_WalkInfo.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 297);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 84;
            this.label15.Text = "备注：";
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(70, 294);
            this.txt_Remark.MaxLength = 200;
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Remark.Size = new System.Drawing.Size(350, 50);
            this.txt_Remark.TabIndex = 83;
            this.txt_Remark.TextType = Shine.TextType.WithOutChar;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cb_Lack);
            this.groupBox3.Controls.Add(this.txt_LackSecond);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txt_LackMinute);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txt_LackHour);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cb_Over);
            this.groupBox3.Controls.Add(this.txt_OverSecond);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txt_OverMinute);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txt_OverHour);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(15, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 80);
            this.groupBox3.TabIndex = 82;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "额定行走时长";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 92;
            this.label5.Text = "额定欠速时长：";
            // 
            // cb_Lack
            // 
            this.cb_Lack.AutoSize = true;
            this.cb_Lack.Checked = true;
            this.cb_Lack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Lack.Location = new System.Drawing.Point(47, 51);
            this.cb_Lack.Name = "cb_Lack";
            this.cb_Lack.Size = new System.Drawing.Size(15, 14);
            this.cb_Lack.TabIndex = 91;
            this.cb_Lack.UseVisualStyleBackColor = true;
            this.cb_Lack.CheckedChanged += new System.EventHandler(this.cb_Lack_CheckedChanged);
            // 
            // txt_LackSecond
            // 
            this.txt_LackSecond.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_LackSecond.Location = new System.Drawing.Point(304, 45);
            this.txt_LackSecond.MaxLength = 2;
            this.txt_LackSecond.Name = "txt_LackSecond";
            this.txt_LackSecond.Size = new System.Drawing.Size(36, 21);
            this.txt_LackSecond.TabIndex = 90;
            this.txt_LackSecond.Text = "0";
            this.txt_LackSecond.TextType = Shine.TextType.Number;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(346, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 89;
            this.label10.Text = "秒";
            // 
            // txt_LackMinute
            // 
            this.txt_LackMinute.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_LackMinute.Location = new System.Drawing.Point(238, 45);
            this.txt_LackMinute.MaxLength = 2;
            this.txt_LackMinute.Name = "txt_LackMinute";
            this.txt_LackMinute.Size = new System.Drawing.Size(36, 21);
            this.txt_LackMinute.TabIndex = 88;
            this.txt_LackMinute.Text = "0";
            this.txt_LackMinute.TextType = Shine.TextType.Number;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(280, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 87;
            this.label13.Text = "分";
            // 
            // txt_LackHour
            // 
            this.txt_LackHour.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_LackHour.Location = new System.Drawing.Point(173, 45);
            this.txt_LackHour.MaxLength = 4;
            this.txt_LackHour.Name = "txt_LackHour";
            this.txt_LackHour.Size = new System.Drawing.Size(36, 21);
            this.txt_LackHour.TabIndex = 86;
            this.txt_LackHour.Text = "2";
            this.txt_LackHour.TextType = Shine.TextType.Number;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(215, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 85;
            this.label14.Text = "时";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 84;
            this.label3.Text = "额定超速时长：";
            // 
            // cb_Over
            // 
            this.cb_Over.AutoSize = true;
            this.cb_Over.Checked = true;
            this.cb_Over.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Over.Location = new System.Drawing.Point(47, 22);
            this.cb_Over.Name = "cb_Over";
            this.cb_Over.Size = new System.Drawing.Size(15, 14);
            this.cb_Over.TabIndex = 83;
            this.cb_Over.UseVisualStyleBackColor = true;
            this.cb_Over.CheckedChanged += new System.EventHandler(this.cb_Over_CheckedChanged);
            // 
            // txt_OverSecond
            // 
            this.txt_OverSecond.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_OverSecond.Location = new System.Drawing.Point(304, 16);
            this.txt_OverSecond.MaxLength = 2;
            this.txt_OverSecond.Name = "txt_OverSecond";
            this.txt_OverSecond.Size = new System.Drawing.Size(36, 21);
            this.txt_OverSecond.TabIndex = 5;
            this.txt_OverSecond.Text = "0";
            this.txt_OverSecond.TextType = Shine.TextType.Number;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(346, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "秒";
            // 
            // txt_OverMinute
            // 
            this.txt_OverMinute.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_OverMinute.Location = new System.Drawing.Point(238, 16);
            this.txt_OverMinute.MaxLength = 2;
            this.txt_OverMinute.Name = "txt_OverMinute";
            this.txt_OverMinute.Size = new System.Drawing.Size(36, 21);
            this.txt_OverMinute.TabIndex = 3;
            this.txt_OverMinute.Text = "0";
            this.txt_OverMinute.TextType = Shine.TextType.Number;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "分";
            // 
            // txt_OverHour
            // 
            this.txt_OverHour.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_OverHour.Location = new System.Drawing.Point(173, 16);
            this.txt_OverHour.MaxLength = 4;
            this.txt_OverHour.Name = "txt_OverHour";
            this.txt_OverHour.Size = new System.Drawing.Size(36, 21);
            this.txt_OverHour.TabIndex = 1;
            this.txt_OverHour.Text = "1";
            this.txt_OverHour.TextType = Shine.TextType.Number;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "时";
            // 
            // gb_First
            // 
            this.gb_First.Controls.Add(this.txt_FirstStationHeadPlace);
            this.gb_First.Controls.Add(this.label11);
            this.gb_First.Controls.Add(this.cmb_FirstStaHead);
            this.gb_First.Controls.Add(this.label1);
            this.gb_First.Controls.Add(this.cmb_FirstStation);
            this.gb_First.Controls.Add(this.label2);
            this.gb_First.Location = new System.Drawing.Point(15, 18);
            this.gb_First.Name = "gb_First";
            this.gb_First.Size = new System.Drawing.Size(405, 86);
            this.gb_First.TabIndex = 80;
            this.gb_First.TabStop = false;
            this.gb_First.Text = "起始位置";
            // 
            // txt_FirstStationHeadPlace
            // 
            this.txt_FirstStationHeadPlace.Enabled = false;
            this.txt_FirstStationHeadPlace.Location = new System.Drawing.Point(144, 54);
            this.txt_FirstStationHeadPlace.Name = "txt_FirstStationHeadPlace";
            this.txt_FirstStationHeadPlace.Size = new System.Drawing.Size(250, 21);
            this.txt_FirstStationHeadPlace.TabIndex = 21;
            this.txt_FirstStationHeadPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_FirstStationHeadPlace_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "读卡分站安装位置：";
            // 
            // cmb_FirstStaHead
            // 
            this.cmb_FirstStaHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FirstStaHead.FormattingEnabled = true;
            this.cmb_FirstStaHead.Location = new System.Drawing.Point(316, 23);
            this.cmb_FirstStaHead.Name = "cmb_FirstStaHead";
            this.cmb_FirstStaHead.Size = new System.Drawing.Size(54, 20);
            this.cmb_FirstStaHead.TabIndex = 19;
            this.cmb_FirstStaHead.DropDownClosed += new System.EventHandler(this.cmb_FirstStaHead_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "读卡分站号：";
            // 
            // cmb_FirstStation
            // 
            this.cmb_FirstStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FirstStation.Location = new System.Drawing.Point(108, 23);
            this.cmb_FirstStation.Name = "cmb_FirstStation";
            this.cmb_FirstStation.Size = new System.Drawing.Size(60, 20);
            this.cmb_FirstStation.TabIndex = 17;
            this.cmb_FirstStation.SelectedIndexChanged += new System.EventHandler(this.cmb_FirstStation_SelectedIndexChanged);
            this.cmb_FirstStation.DropDownClosed += new System.EventHandler(this.cmb_FirstStation_DropDownClosed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "传输分站号：";
            // 
            // gb_Last
            // 
            this.gb_Last.Controls.Add(this.txt_LastStationHeadPlace);
            this.gb_Last.Controls.Add(this.label12);
            this.gb_Last.Controls.Add(this.cmb_LastStaHead);
            this.gb_Last.Controls.Add(this.label4);
            this.gb_Last.Controls.Add(this.cmb_LastStation);
            this.gb_Last.Controls.Add(this.label6);
            this.gb_Last.Location = new System.Drawing.Point(15, 110);
            this.gb_Last.Name = "gb_Last";
            this.gb_Last.Size = new System.Drawing.Size(405, 86);
            this.gb_Last.TabIndex = 81;
            this.gb_Last.TabStop = false;
            this.gb_Last.Text = "终点位置";
            // 
            // txt_LastStationHeadPlace
            // 
            this.txt_LastStationHeadPlace.Enabled = false;
            this.txt_LastStationHeadPlace.Location = new System.Drawing.Point(144, 53);
            this.txt_LastStationHeadPlace.Name = "txt_LastStationHeadPlace";
            this.txt_LastStationHeadPlace.Size = new System.Drawing.Size(250, 21);
            this.txt_LastStationHeadPlace.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "读卡分站安装位置：";
            // 
            // cmb_LastStaHead
            // 
            this.cmb_LastStaHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_LastStaHead.FormattingEnabled = true;
            this.cmb_LastStaHead.Location = new System.Drawing.Point(316, 23);
            this.cmb_LastStaHead.Name = "cmb_LastStaHead";
            this.cmb_LastStaHead.Size = new System.Drawing.Size(54, 20);
            this.cmb_LastStaHead.TabIndex = 19;
            this.cmb_LastStaHead.DropDownClosed += new System.EventHandler(this.cmb_LastStaHead_DropDownClosed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "读卡分站号：";
            // 
            // cmb_LastStation
            // 
            this.cmb_LastStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_LastStation.FormattingEnabled = true;
            this.cmb_LastStation.Location = new System.Drawing.Point(108, 23);
            this.cmb_LastStation.Name = "cmb_LastStation";
            this.cmb_LastStation.Size = new System.Drawing.Size(60, 20);
            this.cmb_LastStation.TabIndex = 17;
            this.cmb_LastStation.SelectedIndexChanged += new System.EventHandler(this.cmb_LastStation_SelectedIndexChanged);
            this.cmb_LastStation.DropDownClosed += new System.EventHandler(this.cmb_LastStation_DropDownClosed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "传输分站号：";
            // 
            // bt_Close
            // 
            this.bt_Close.Location = new System.Drawing.Point(392, 394);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_Close.TabIndex = 79;
            this.bt_Close.Text = "返回";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // bt_Reset
            // 
            this.bt_Reset.Location = new System.Drawing.Point(325, 394);
            this.bt_Reset.Name = "bt_Reset";
            this.bt_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_Reset.TabIndex = 78;
            this.bt_Reset.Text = "重置";
            this.bt_Reset.UseVisualStyleBackColor = true;
            this.bt_Reset.Click += new System.EventHandler(this.bt_Reset_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(257, 394);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_Save.TabIndex = 77;
            this.bt_Save.Text = "保存";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // lb_TipsInfo
            // 
            this.lb_TipsInfo.AutoSize = true;
            this.lb_TipsInfo.Location = new System.Drawing.Point(57, 381);
            this.lb_TipsInfo.Name = "lb_TipsInfo";
            this.lb_TipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_TipsInfo.TabIndex = 76;
            this.lb_TipsInfo.Text = "保存成功";
            this.lb_TipsInfo.Visible = false;
            // 
            // lb_TipsInfo2
            // 
            this.lb_TipsInfo2.AutoSize = true;
            this.lb_TipsInfo2.Location = new System.Drawing.Point(10, 381);
            this.lb_TipsInfo2.Name = "lb_TipsInfo2";
            this.lb_TipsInfo2.Size = new System.Drawing.Size(41, 12);
            this.lb_TipsInfo2.TabIndex = 75;
            this.lb_TipsInfo2.Text = "提示：";
            // 
            // A_FrmWalkConfig_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(461, 429);
            this.Controls.Add(this.bt_Close);
            this.Controls.Add(this.bt_Reset);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.lb_TipsInfo);
            this.Controls.Add(this.lb_TipsInfo2);
            this.Controls.Add(this.gb_WalkInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_FrmWalkConfig_Add";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增行走异常配置信息";
            this.gb_WalkInfo.ResumeLayout(false);
            this.gb_WalkInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gb_First.ResumeLayout(false);
            this.gb_First.PerformLayout();
            this.gb_Last.ResumeLayout(false);
            this.gb_Last.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_WalkInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private Shine.ShineTextBox txt_OverSecond;
        private System.Windows.Forms.Label label9;
        private Shine.ShineTextBox txt_OverMinute;
        private System.Windows.Forms.Label label8;
        private Shine.ShineTextBox txt_OverHour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gb_First;
        private System.Windows.Forms.TextBox txt_FirstStationHeadPlace;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_FirstStaHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_FirstStation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_Last;
        private System.Windows.Forms.TextBox txt_LastStationHeadPlace;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_LastStaHead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_LastStation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.Button bt_Reset;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Label lb_TipsInfo;
        private System.Windows.Forms.Label lb_TipsInfo2;
        private System.Windows.Forms.Label label15;
        private Shine.ShineTextBox txt_Remark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_Lack;
        private Shine.ShineTextBox txt_LackSecond;
        private System.Windows.Forms.Label label10;
        private Shine.ShineTextBox txt_LackMinute;
        private System.Windows.Forms.Label label13;
        private Shine.ShineTextBox txt_LackHour;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_Over;
    }
}