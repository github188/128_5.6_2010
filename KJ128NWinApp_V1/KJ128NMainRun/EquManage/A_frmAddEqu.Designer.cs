namespace KJ128NMainRun.EquManage
{
    partial class A_frmAddEqu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_frmAddEqu));
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.labMessage = new System.Windows.Forms.Label();
            this.labTT = new System.Windows.Forms.Label();
            this.gb_Equ = new System.Windows.Forms.GroupBox();
            this.txtDutyEmployee = new Shine.ShineTextBox();
            this.txtModelSpecial = new Shine.ShineTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbEqufactory = new KJ128WindowsLibrary.ZzhaComBox();
            this.cmbEqustate = new KJ128WindowsLibrary.ZzhaComBox();
            this.cmbEquDept = new KJ128WindowsLibrary.ZzhaComBox();
            this.cmbEqutype = new KJ128WindowsLibrary.ZzhaComBox();
            this.dtpUseDate = new System.Windows.Forms.DateTimePicker();
            this.dtpProductDate = new System.Windows.Forms.DateTimePicker();
            this.txtEquKw = new Shine.ShineTextBox();
            this.txtEquHeight = new Shine.ShineTextBox();
            this.txtEquRemark = new Shine.ShineTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUserange = new Shine.ShineTextBox();
            this.txtEquName = new Shine.ShineTextBox();
            this.txtEquNo = new Shine.ShineTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gb_Equ.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(339, 300);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(56, 23);
            this.btnReturn.TabIndex = 20;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(277, 300);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(56, 23);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(215, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.ForeColor = System.Drawing.Color.Black;
            this.labMessage.Location = new System.Drawing.Point(47, 281);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(53, 12);
            this.labMessage.TabIndex = 17;
            this.labMessage.Text = "保存成功";
            this.labMessage.Visible = false;
            // 
            // labTT
            // 
            this.labTT.AutoSize = true;
            this.labTT.Location = new System.Drawing.Point(12, 281);
            this.labTT.Name = "labTT";
            this.labTT.Size = new System.Drawing.Size(35, 12);
            this.labTT.TabIndex = 16;
            this.labTT.Text = "提示:";
            // 
            // gb_Equ
            // 
            this.gb_Equ.Controls.Add(this.txtDutyEmployee);
            this.gb_Equ.Controls.Add(this.txtModelSpecial);
            this.gb_Equ.Controls.Add(this.label23);
            this.gb_Equ.Controls.Add(this.label24);
            this.gb_Equ.Controls.Add(this.label20);
            this.gb_Equ.Controls.Add(this.label19);
            this.gb_Equ.Controls.Add(this.label18);
            this.gb_Equ.Controls.Add(this.label17);
            this.gb_Equ.Controls.Add(this.label16);
            this.gb_Equ.Controls.Add(this.label15);
            this.gb_Equ.Controls.Add(this.cmbEqufactory);
            this.gb_Equ.Controls.Add(this.cmbEqustate);
            this.gb_Equ.Controls.Add(this.cmbEquDept);
            this.gb_Equ.Controls.Add(this.cmbEqutype);
            this.gb_Equ.Controls.Add(this.dtpUseDate);
            this.gb_Equ.Controls.Add(this.dtpProductDate);
            this.gb_Equ.Controls.Add(this.txtEquKw);
            this.gb_Equ.Controls.Add(this.txtEquHeight);
            this.gb_Equ.Controls.Add(this.txtEquRemark);
            this.gb_Equ.Controls.Add(this.label14);
            this.gb_Equ.Controls.Add(this.txtUserange);
            this.gb_Equ.Controls.Add(this.txtEquName);
            this.gb_Equ.Controls.Add(this.txtEquNo);
            this.gb_Equ.Controls.Add(this.label1);
            this.gb_Equ.Controls.Add(this.checkBox2);
            this.gb_Equ.Controls.Add(this.label2);
            this.gb_Equ.Controls.Add(this.checkBox1);
            this.gb_Equ.Controls.Add(this.label3);
            this.gb_Equ.Controls.Add(this.label13);
            this.gb_Equ.Controls.Add(this.label4);
            this.gb_Equ.Controls.Add(this.label12);
            this.gb_Equ.Controls.Add(this.label5);
            this.gb_Equ.Controls.Add(this.label11);
            this.gb_Equ.Controls.Add(this.label6);
            this.gb_Equ.Controls.Add(this.label10);
            this.gb_Equ.Controls.Add(this.label7);
            this.gb_Equ.Controls.Add(this.label9);
            this.gb_Equ.Controls.Add(this.label8);
            this.gb_Equ.Location = new System.Drawing.Point(12, 12);
            this.gb_Equ.Name = "gb_Equ";
            this.gb_Equ.Size = new System.Drawing.Size(383, 257);
            this.gb_Equ.TabIndex = 21;
            this.gb_Equ.TabStop = false;
            // 
            // txtDutyEmployee
            // 
            this.txtDutyEmployee.Location = new System.Drawing.Point(267, 98);
            this.txtDutyEmployee.MaxLength = 20;
            this.txtDutyEmployee.Name = "txtDutyEmployee";
            this.txtDutyEmployee.Size = new System.Drawing.Size(90, 21);
            this.txtDutyEmployee.TabIndex = 82;
            this.txtDutyEmployee.TextType = Shine.TextType.WithOutChar;
            this.txtDutyEmployee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDutyEmployee_KeyPress);
            // 
            // txtModelSpecial
            // 
            this.txtModelSpecial.Location = new System.Drawing.Point(80, 98);
            this.txtModelSpecial.MaxLength = 50;
            this.txtModelSpecial.Name = "txtModelSpecial";
            this.txtModelSpecial.Size = new System.Drawing.Size(100, 21);
            this.txtModelSpecial.TabIndex = 81;
            this.txtModelSpecial.TextType = Shine.TextType.WithOutChar;
            this.txtModelSpecial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModelSpecial_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(31, 101);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 79;
            this.label23.Text = "规格：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(207, 101);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 80;
            this.label24.Text = "责任人：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(208, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 12);
            this.label20.TabIndex = 78;
            this.label20.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(208, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 12);
            this.label19.TabIndex = 77;
            this.label19.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(196, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 76;
            this.label18.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(22, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 75;
            this.label17.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(22, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 74;
            this.label16.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(22, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 73;
            this.label15.Text = "*";
            // 
            // cmbEqufactory
            // 
            this.cmbEqufactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEqufactory.FormattingEnabled = true;
            this.cmbEqufactory.Location = new System.Drawing.Point(267, 73);
            this.cmbEqufactory.Name = "cmbEqufactory";
            this.cmbEqufactory.Size = new System.Drawing.Size(90, 20);
            this.cmbEqufactory.TabIndex = 72;
            this.cmbEqufactory.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("cmbEqufactory.Values")));
            // 
            // cmbEqustate
            // 
            this.cmbEqustate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEqustate.FormattingEnabled = true;
            this.cmbEqustate.Location = new System.Drawing.Point(80, 73);
            this.cmbEqustate.Name = "cmbEqustate";
            this.cmbEqustate.Size = new System.Drawing.Size(100, 20);
            this.cmbEqustate.TabIndex = 71;
            this.cmbEqustate.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("cmbEqustate.Values")));
            // 
            // cmbEquDept
            // 
            this.cmbEquDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquDept.FormattingEnabled = true;
            this.cmbEquDept.Location = new System.Drawing.Point(267, 49);
            this.cmbEquDept.Name = "cmbEquDept";
            this.cmbEquDept.Size = new System.Drawing.Size(90, 20);
            this.cmbEquDept.TabIndex = 70;
            this.cmbEquDept.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("cmbEquDept.Values")));
            // 
            // cmbEqutype
            // 
            this.cmbEqutype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEqutype.FormattingEnabled = true;
            this.cmbEqutype.Location = new System.Drawing.Point(80, 49);
            this.cmbEqutype.Name = "cmbEqutype";
            this.cmbEqutype.Size = new System.Drawing.Size(100, 20);
            this.cmbEqutype.TabIndex = 62;
            this.cmbEqutype.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("cmbEqutype.Values")));
            // 
            // dtpUseDate
            // 
            this.dtpUseDate.Enabled = false;
            this.dtpUseDate.Location = new System.Drawing.Point(80, 199);
            this.dtpUseDate.Name = "dtpUseDate";
            this.dtpUseDate.Size = new System.Drawing.Size(121, 21);
            this.dtpUseDate.TabIndex = 69;
            // 
            // dtpProductDate
            // 
            this.dtpProductDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpProductDate.Enabled = false;
            this.dtpProductDate.Location = new System.Drawing.Point(80, 173);
            this.dtpProductDate.Name = "dtpProductDate";
            this.dtpProductDate.Size = new System.Drawing.Size(121, 21);
            this.dtpProductDate.TabIndex = 68;
            // 
            // txtEquKw
            // 
            this.txtEquKw.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtEquKw.Location = new System.Drawing.Point(267, 123);
            this.txtEquKw.MaxLength = 6;
            this.txtEquKw.Name = "txtEquKw";
            this.txtEquKw.Size = new System.Drawing.Size(65, 21);
            this.txtEquKw.TabIndex = 67;
            this.txtEquKw.TextType = Shine.TextType.Number;
            // 
            // txtEquHeight
            // 
            this.txtEquHeight.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtEquHeight.Location = new System.Drawing.Point(80, 123);
            this.txtEquHeight.MaxLength = 6;
            this.txtEquHeight.Name = "txtEquHeight";
            this.txtEquHeight.Size = new System.Drawing.Size(75, 21);
            this.txtEquHeight.TabIndex = 66;
            this.txtEquHeight.TextType = Shine.TextType.Number;
            // 
            // txtEquRemark
            // 
            this.txtEquRemark.Location = new System.Drawing.Point(80, 223);
            this.txtEquRemark.MaxLength = 100;
            this.txtEquRemark.Name = "txtEquRemark";
            this.txtEquRemark.Size = new System.Drawing.Size(277, 21);
            this.txtEquRemark.TabIndex = 65;
            this.txtEquRemark.TextType = Shine.TextType.WithOutChar;
            this.txtEquRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEquRemark_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 226);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 64;
            this.label14.Text = "备注：";
            // 
            // txtUserange
            // 
            this.txtUserange.Location = new System.Drawing.Point(80, 148);
            this.txtUserange.MaxLength = 50;
            this.txtUserange.Name = "txtUserange";
            this.txtUserange.Size = new System.Drawing.Size(277, 21);
            this.txtUserange.TabIndex = 63;
            this.txtUserange.TextType = Shine.TextType.WithOutChar;
            this.txtUserange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserange_KeyPress);
            // 
            // txtEquName
            // 
            this.txtEquName.Location = new System.Drawing.Point(267, 23);
            this.txtEquName.MaxLength = 20;
            this.txtEquName.Name = "txtEquName";
            this.txtEquName.Size = new System.Drawing.Size(90, 21);
            this.txtEquName.TabIndex = 61;
            this.txtEquName.TextType = Shine.TextType.WithOutChar;
            this.txtEquName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEquName_KeyPress);
            // 
            // txtEquNo
            // 
            this.txtEquNo.Location = new System.Drawing.Point(80, 23);
            this.txtEquNo.MaxLength = 10;
            this.txtEquNo.Name = "txtEquNo";
            this.txtEquNo.Size = new System.Drawing.Size(100, 21);
            this.txtEquNo.TabIndex = 60;
            this.txtEquNo.TextType = Shine.TextType.WithOutChar;
            this.txtEquNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEquNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "编号：";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(227, 199);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 59;
            this.checkBox2.Text = "是否启用";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "名称：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(227, 176);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 58;
            this.checkBox1.Text = "是否启用";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "类型：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 57;
            this.label13.Text = "使用期限：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "部门：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 56;
            this.label12.Text = "生产日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 49;
            this.label5.Text = "状态：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 55;
            this.label11.Text = "使用范围：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 50;
            this.label6.Text = "生产厂：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(340, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 54;
            this.label10.Text = "Kw";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 51;
            this.label7.Text = "重量：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(163, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 53;
            this.label9.Text = "Kg";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 52;
            this.label8.Text = "功耗：";
            // 
            // A_frmAddEqu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(407, 335);
            this.Controls.Add(this.gb_Equ);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.labTT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_frmAddEqu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增设备";
            this.Load += new System.EventHandler(this.A_frmAddEqu_Load);
            this.gb_Equ.ResumeLayout(false);
            this.gb_Equ.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Label labTT;
        private System.Windows.Forms.GroupBox gb_Equ;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private KJ128WindowsLibrary.ZzhaComBox cmbEqufactory;
        private KJ128WindowsLibrary.ZzhaComBox cmbEqustate;
        private KJ128WindowsLibrary.ZzhaComBox cmbEquDept;
        private KJ128WindowsLibrary.ZzhaComBox cmbEqutype;
        private System.Windows.Forms.DateTimePicker dtpUseDate;
        private System.Windows.Forms.DateTimePicker dtpProductDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Shine.ShineTextBox txtDutyEmployee;
        private Shine.ShineTextBox txtModelSpecial;
        private Shine.ShineTextBox txtEquKw;
        private Shine.ShineTextBox txtEquHeight;
        private Shine.ShineTextBox txtEquRemark;
        private Shine.ShineTextBox txtUserange;
        private Shine.ShineTextBox txtEquName;
        private Shine.ShineTextBox txtEquNo;

    }
}