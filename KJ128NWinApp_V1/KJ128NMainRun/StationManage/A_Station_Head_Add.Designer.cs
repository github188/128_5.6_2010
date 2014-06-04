namespace KJ128NMainRun.StationManage
{
    partial class A_Station_Head_Add
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
            this.gb_AddStaHeadInfo = new System.Windows.Forms.GroupBox();
            this.txt_StaHeadPlace = new Shine.ShineTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNO = new Shine.ShineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_StaHeadRemark = new Shine.ShineTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_StaHeadTel = new Shine.ShineTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_StaHeadAddress = new Shine.ShineTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_CheckCard = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.rb_WellUp = new System.Windows.Forms.RadioButton();
            this.rb_WellHead = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_StaHead_StaAddress = new Shine.ShineTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_StaHeadAntennaA = new Shine.ShineTextBox();
            this.txt_StaHeadAntennaB = new Shine.ShineTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.bt_StaHead_Close = new System.Windows.Forms.Button();
            this.bt_StaHead_Reset = new System.Windows.Forms.Button();
            this.bt_StaHead_Save = new System.Windows.Forms.Button();
            this.lb_StaHeadTipsInfo = new System.Windows.Forms.Label();
            this.lb_StaHeadTipsInfo2 = new System.Windows.Forms.Label();
            this.gb_AddStaHeadInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_AddStaHeadInfo
            // 
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadPlace);
            this.gb_AddStaHeadInfo.Controls.Add(this.label16);
            this.gb_AddStaHeadInfo.Controls.Add(this.label1);
            this.gb_AddStaHeadInfo.Controls.Add(this.txtNO);
            this.gb_AddStaHeadInfo.Controls.Add(this.label2);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadRemark);
            this.gb_AddStaHeadInfo.Controls.Add(this.label21);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadTel);
            this.gb_AddStaHeadInfo.Controls.Add(this.label13);
            this.gb_AddStaHeadInfo.Controls.Add(this.label15);
            this.gb_AddStaHeadInfo.Controls.Add(this.label9);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadAddress);
            this.gb_AddStaHeadInfo.Controls.Add(this.label12);
            this.gb_AddStaHeadInfo.Controls.Add(this.groupBox3);
            this.gb_AddStaHeadInfo.Controls.Add(this.label17);
            this.gb_AddStaHeadInfo.Controls.Add(this.label18);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHead_StaAddress);
            this.gb_AddStaHeadInfo.Controls.Add(this.label19);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadAntennaA);
            this.gb_AddStaHeadInfo.Controls.Add(this.txt_StaHeadAntennaB);
            this.gb_AddStaHeadInfo.Controls.Add(this.label20);
            this.gb_AddStaHeadInfo.Location = new System.Drawing.Point(12, 12);
            this.gb_AddStaHeadInfo.Name = "gb_AddStaHeadInfo";
            this.gb_AddStaHeadInfo.Size = new System.Drawing.Size(356, 197);
            this.gb_AddStaHeadInfo.TabIndex = 64;
            this.gb_AddStaHeadInfo.TabStop = false;
            // 
            // txt_StaHeadPlace
            // 
            this.txt_StaHeadPlace.Location = new System.Drawing.Point(89, 48);
            this.txt_StaHeadPlace.MaxLength = 50;
            this.txt_StaHeadPlace.Name = "txt_StaHeadPlace";
            this.txt_StaHeadPlace.Size = new System.Drawing.Size(229, 21);
            this.txt_StaHeadPlace.TabIndex = 67;
            this.txt_StaHeadPlace.TextType = Shine.TextType.WithOutChar;
            this.txt_StaHeadPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StaHeadPlace_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 66;
            this.label16.Text = "安装位置：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(36, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 85;
            this.label1.Text = "*";
            this.label1.Visible = false;
            // 
            // txtNO
            // 
            this.txtNO.Location = new System.Drawing.Point(89, 48);
            this.txtNO.MaxLength = 50;
            this.txtNO.Name = "txtNO";
            this.txtNO.Size = new System.Drawing.Size(118, 21);
            this.txtNO.TabIndex = 84;
            this.txtNO.TextType = Shine.TextType.WithOutChar;
            this.txtNO.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 83;
            this.label2.Text = "编号：";
            this.label2.Visible = false;
            // 
            // txt_StaHeadRemark
            // 
            this.txt_StaHeadRemark.Location = new System.Drawing.Point(57, 165);
            this.txt_StaHeadRemark.MaxLength = 200;
            this.txt_StaHeadRemark.Name = "txt_StaHeadRemark";
            this.txt_StaHeadRemark.Size = new System.Drawing.Size(283, 21);
            this.txt_StaHeadRemark.TabIndex = 82;
            this.txt_StaHeadRemark.TextType = Shine.TextType.WithOutChar;
            this.txt_StaHeadRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StaHeadRemark_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 168);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 81;
            this.label21.Text = "备注：";
            // 
            // txt_StaHeadTel
            // 
            this.txt_StaHeadTel.Location = new System.Drawing.Point(89, 138);
            this.txt_StaHeadTel.MaxLength = 20;
            this.txt_StaHeadTel.Name = "txt_StaHeadTel";
            this.txt_StaHeadTel.Size = new System.Drawing.Size(206, 21);
            this.txt_StaHeadTel.TabIndex = 80;
            this.txt_StaHeadTel.TextType = Shine.TextType.Number;
            this.txt_StaHeadTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_StaHeadTel_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 79;
            this.label13.Text = "联系电话：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(298, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 76;
            this.label15.Text = "(1-6)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 74;
            this.label9.Text = "读卡分站号：";
            // 
            // txt_StaHeadAddress
            // 
            this.txt_StaHeadAddress.Enabled = false;
            this.txt_StaHeadAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_StaHeadAddress.Location = new System.Drawing.Point(257, 14);
            this.txt_StaHeadAddress.MaxLength = 1;
            this.txt_StaHeadAddress.Name = "txt_StaHeadAddress";
            this.txt_StaHeadAddress.Size = new System.Drawing.Size(38, 21);
            this.txt_StaHeadAddress.TabIndex = 75;
            this.txt_StaHeadAddress.TextType = Shine.TextType.Number;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(8, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 73;
            this.label12.Text = "*";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_CheckCard);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.rb_WellUp);
            this.groupBox3.Controls.Add(this.rb_WellHead);
            this.groupBox3.Location = new System.Drawing.Point(19, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 51);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "  读卡分站类型";
            // 
            // rb_CheckCard
            // 
            this.rb_CheckCard.AutoSize = true;
            this.rb_CheckCard.Location = new System.Drawing.Point(221, 20);
            this.rb_CheckCard.Name = "rb_CheckCard";
            this.rb_CheckCard.Size = new System.Drawing.Size(83, 16);
            this.rb_CheckCard.TabIndex = 75;
            this.rb_CheckCard.Text = "检卡仪分站";
            this.rb_CheckCard.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(10, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 74;
            this.label14.Text = "*";
            // 
            // rb_WellUp
            // 
            this.rb_WellUp.AutoSize = true;
            this.rb_WellUp.Checked = true;
            this.rb_WellUp.Location = new System.Drawing.Point(138, 21);
            this.rb_WellUp.Name = "rb_WellUp";
            this.rb_WellUp.Size = new System.Drawing.Size(71, 16);
            this.rb_WellUp.TabIndex = 1;
            this.rb_WellUp.TabStop = true;
            this.rb_WellUp.Text = "井下分站";
            this.rb_WellUp.UseVisualStyleBackColor = true;
            // 
            // rb_WellHead
            // 
            this.rb_WellHead.AutoSize = true;
            this.rb_WellHead.Location = new System.Drawing.Point(38, 21);
            this.rb_WellHead.Name = "rb_WellHead";
            this.rb_WellHead.Size = new System.Drawing.Size(83, 16);
            this.rb_WellHead.TabIndex = 0;
            this.rb_WellHead.Text = "上井口分站";
            this.rb_WellHead.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(171, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 61;
            this.label17.Text = "天线A：";
            this.label17.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "传输分站号：";
            // 
            // txt_StaHead_StaAddress
            // 
            this.txt_StaHead_StaAddress.Enabled = false;
            this.txt_StaHead_StaAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_StaHead_StaAddress.Location = new System.Drawing.Point(89, 13);
            this.txt_StaHead_StaAddress.MaxLength = 3;
            this.txt_StaHead_StaAddress.Name = "txt_StaHead_StaAddress";
            this.txt_StaHead_StaAddress.Size = new System.Drawing.Size(38, 21);
            this.txt_StaHead_StaAddress.TabIndex = 18;
            this.txt_StaHead_StaAddress.TextType = Shine.TextType.Number;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(155, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 12);
            this.label19.TabIndex = 19;
            this.label19.Text = "*";
            // 
            // txt_StaHeadAntennaA
            // 
            this.txt_StaHeadAntennaA.Location = new System.Drawing.Point(221, 80);
            this.txt_StaHeadAntennaA.MaxLength = 20;
            this.txt_StaHeadAntennaA.Name = "txt_StaHeadAntennaA";
            this.txt_StaHeadAntennaA.Size = new System.Drawing.Size(119, 21);
            this.txt_StaHeadAntennaA.TabIndex = 70;
            this.txt_StaHeadAntennaA.TextType = Shine.TextType.WithOutChar;
            this.txt_StaHeadAntennaA.Visible = false;
            // 
            // txt_StaHeadAntennaB
            // 
            this.txt_StaHeadAntennaB.Location = new System.Drawing.Point(218, 102);
            this.txt_StaHeadAntennaB.MaxLength = 20;
            this.txt_StaHeadAntennaB.Name = "txt_StaHeadAntennaB";
            this.txt_StaHeadAntennaB.Size = new System.Drawing.Size(119, 21);
            this.txt_StaHeadAntennaB.TabIndex = 78;
            this.txt_StaHeadAntennaB.TextType = Shine.TextType.WithOutChar;
            this.txt_StaHeadAntennaB.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(171, 114);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 77;
            this.label20.Text = "天线B：";
            this.label20.Visible = false;
            // 
            // bt_StaHead_Close
            // 
            this.bt_StaHead_Close.Location = new System.Drawing.Point(317, 237);
            this.bt_StaHead_Close.Name = "bt_StaHead_Close";
            this.bt_StaHead_Close.Size = new System.Drawing.Size(56, 23);
            this.bt_StaHead_Close.TabIndex = 73;
            this.bt_StaHead_Close.Text = "返回";
            this.bt_StaHead_Close.UseVisualStyleBackColor = true;
            this.bt_StaHead_Close.Click += new System.EventHandler(this.bt_StaHead_Close_Click);
            // 
            // bt_StaHead_Reset
            // 
            this.bt_StaHead_Reset.Location = new System.Drawing.Point(250, 237);
            this.bt_StaHead_Reset.Name = "bt_StaHead_Reset";
            this.bt_StaHead_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_StaHead_Reset.TabIndex = 72;
            this.bt_StaHead_Reset.Text = "重置";
            this.bt_StaHead_Reset.UseVisualStyleBackColor = true;
            this.bt_StaHead_Reset.Click += new System.EventHandler(this.bt_StaHead_Reset_Click);
            // 
            // bt_StaHead_Save
            // 
            this.bt_StaHead_Save.Location = new System.Drawing.Point(182, 237);
            this.bt_StaHead_Save.Name = "bt_StaHead_Save";
            this.bt_StaHead_Save.Size = new System.Drawing.Size(56, 23);
            this.bt_StaHead_Save.TabIndex = 71;
            this.bt_StaHead_Save.Text = "保存";
            this.bt_StaHead_Save.UseVisualStyleBackColor = true;
            this.bt_StaHead_Save.Click += new System.EventHandler(this.bt_StaHead_Save_Click);
            // 
            // lb_StaHeadTipsInfo
            // 
            this.lb_StaHeadTipsInfo.AutoSize = true;
            this.lb_StaHeadTipsInfo.Location = new System.Drawing.Point(54, 221);
            this.lb_StaHeadTipsInfo.Name = "lb_StaHeadTipsInfo";
            this.lb_StaHeadTipsInfo.Size = new System.Drawing.Size(53, 12);
            this.lb_StaHeadTipsInfo.TabIndex = 70;
            this.lb_StaHeadTipsInfo.Text = "保存成功";
            this.lb_StaHeadTipsInfo.Visible = false;
            // 
            // lb_StaHeadTipsInfo2
            // 
            this.lb_StaHeadTipsInfo2.AutoSize = true;
            this.lb_StaHeadTipsInfo2.Location = new System.Drawing.Point(7, 221);
            this.lb_StaHeadTipsInfo2.Name = "lb_StaHeadTipsInfo2";
            this.lb_StaHeadTipsInfo2.Size = new System.Drawing.Size(41, 12);
            this.lb_StaHeadTipsInfo2.TabIndex = 69;
            this.lb_StaHeadTipsInfo2.Text = "提示：";
            // 
            // A_Station_Head_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 272);
            this.Controls.Add(this.bt_StaHead_Close);
            this.Controls.Add(this.bt_StaHead_Reset);
            this.Controls.Add(this.bt_StaHead_Save);
            this.Controls.Add(this.lb_StaHeadTipsInfo);
            this.Controls.Add(this.lb_StaHeadTipsInfo2);
            this.Controls.Add(this.gb_AddStaHeadInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_Station_Head_Add";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增读卡分站";
            this.Load += new System.EventHandler(this.A_Station_Head_Add_Load);
            this.gb_AddStaHeadInfo.ResumeLayout(false);
            this.gb_AddStaHeadInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_AddStaHeadInfo;
        private Shine.ShineTextBox txt_StaHeadRemark;
        private System.Windows.Forms.Label label21;
        private Shine.ShineTextBox txt_StaHeadTel;
        private System.Windows.Forms.Label label13;
        private Shine.ShineTextBox txt_StaHeadAntennaB;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private Shine.ShineTextBox txt_StaHeadAddress;
        private System.Windows.Forms.Label label12;
        private Shine.ShineTextBox txt_StaHeadAntennaA;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rb_WellUp;
        private System.Windows.Forms.RadioButton rb_WellHead;
        private Shine.ShineTextBox txt_StaHeadPlace;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private Shine.ShineTextBox txt_StaHead_StaAddress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button bt_StaHead_Close;
        private System.Windows.Forms.Button bt_StaHead_Reset;
        private System.Windows.Forms.Button bt_StaHead_Save;
        private System.Windows.Forms.Label lb_StaHeadTipsInfo;
        private System.Windows.Forms.Label lb_StaHeadTipsInfo2;
        private System.Windows.Forms.Label label1;
        private Shine.ShineTextBox txtNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_CheckCard;


    }
}