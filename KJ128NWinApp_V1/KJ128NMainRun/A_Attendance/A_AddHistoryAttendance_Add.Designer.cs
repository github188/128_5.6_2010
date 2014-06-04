namespace KJ128NMainRun.A_Attendance
{
    partial class A_AddHistoryAttendance_Add
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.txtCodeSenderAddress = new Shine.ShineTextBox();
            this.ddlClassAdd = new System.Windows.Forms.ComboBox();
            this.ddlTimerIntervalAdd = new System.Windows.Forms.ComboBox();
            this.dtpBeginTimeAdd = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTimeAdd = new System.Windows.Forms.DateTimePicker();
            this.dtpDataAttendanceAdd = new System.Windows.Forms.DateTimePicker();
            this.txtRemarkAdd = new Shine.ShineTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblErr = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEmpName = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部    门：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "标 识 卡：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "姓    名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "上班时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "下班时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "记工日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "备    注：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "班    制：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "班    次：";
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(99, 19);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(138, 20);
            this.cmbDept.TabIndex = 9;
            this.cmbDept.DropDownClosed += new System.EventHandler(this.cmbDept_DropDownClosed);
            // 
            // txtCodeSenderAddress
            // 
            this.txtCodeSenderAddress.Enabled = false;
            this.txtCodeSenderAddress.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCodeSenderAddress.Location = new System.Drawing.Point(99, 88);
            this.txtCodeSenderAddress.Name = "txtCodeSenderAddress";
            this.txtCodeSenderAddress.Size = new System.Drawing.Size(138, 21);
            this.txtCodeSenderAddress.TabIndex = 10;
            this.txtCodeSenderAddress.TextType = Shine.TextType.Number;
            // 
            // ddlClassAdd
            // 
            this.ddlClassAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClassAdd.FormattingEnabled = true;
            this.ddlClassAdd.Location = new System.Drawing.Point(345, 23);
            this.ddlClassAdd.Name = "ddlClassAdd";
            this.ddlClassAdd.Size = new System.Drawing.Size(145, 20);
            this.ddlClassAdd.TabIndex = 12;
            this.ddlClassAdd.SelectedValueChanged += new System.EventHandler(this.ddlClassAdd_SelectedValueChanged);
            // 
            // ddlTimerIntervalAdd
            // 
            this.ddlTimerIntervalAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTimerIntervalAdd.FormattingEnabled = true;
            this.ddlTimerIntervalAdd.Location = new System.Drawing.Point(345, 58);
            this.ddlTimerIntervalAdd.Name = "ddlTimerIntervalAdd";
            this.ddlTimerIntervalAdd.Size = new System.Drawing.Size(145, 20);
            this.ddlTimerIntervalAdd.TabIndex = 13;
            // 
            // dtpBeginTimeAdd
            // 
            this.dtpBeginTimeAdd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTimeAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTimeAdd.Location = new System.Drawing.Point(346, 88);
            this.dtpBeginTimeAdd.Name = "dtpBeginTimeAdd";
            this.dtpBeginTimeAdd.Size = new System.Drawing.Size(144, 21);
            this.dtpBeginTimeAdd.TabIndex = 14;
            // 
            // dtpEndTimeAdd
            // 
            this.dtpEndTimeAdd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTimeAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTimeAdd.Location = new System.Drawing.Point(99, 120);
            this.dtpEndTimeAdd.Name = "dtpEndTimeAdd";
            this.dtpEndTimeAdd.Size = new System.Drawing.Size(138, 21);
            this.dtpEndTimeAdd.TabIndex = 15;
            // 
            // dtpDataAttendanceAdd
            // 
            this.dtpDataAttendanceAdd.CustomFormat = "yyyy-MM-dd";
            this.dtpDataAttendanceAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataAttendanceAdd.Location = new System.Drawing.Point(346, 120);
            this.dtpDataAttendanceAdd.Name = "dtpDataAttendanceAdd";
            this.dtpDataAttendanceAdd.Size = new System.Drawing.Size(144, 21);
            this.dtpDataAttendanceAdd.TabIndex = 16;
            // 
            // txtRemarkAdd
            // 
            this.txtRemarkAdd.AllowDrop = true;
            this.txtRemarkAdd.Location = new System.Drawing.Point(94, 155);
            this.txtRemarkAdd.Multiline = true;
            this.txtRemarkAdd.Name = "txtRemarkAdd";
            this.txtRemarkAdd.Size = new System.Drawing.Size(396, 76);
            this.txtRemarkAdd.TabIndex = 17;
            this.txtRemarkAdd.TextType = Shine.TextType.WithOutChar;
            this.txtRemarkAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarkAdd_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.Location = new System.Drawing.Point(14, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "提示：";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(61, 273);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(346, 301);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(464, 301);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "返回";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(13, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(13, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(13, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 25;
            this.label13.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(255, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 26;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(255, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(255, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 28;
            this.label16.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(13, 124);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 29;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(255, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 30;
            this.label18.Text = "*";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(405, 301);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(53, 23);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEmpName);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtCodeSenderAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ddlClassAdd);
            this.groupBox1.Controls.Add(this.ddlTimerIntervalAdd);
            this.groupBox1.Controls.Add(this.txtRemarkAdd);
            this.groupBox1.Controls.Add(this.dtpBeginTimeAdd);
            this.groupBox1.Controls.Add(this.dtpDataAttendanceAdd);
            this.groupBox1.Controls.Add(this.dtpEndTimeAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 247);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // cmbEmpName
            // 
            this.cmbEmpName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpName.FormattingEnabled = true;
            this.cmbEmpName.Location = new System.Drawing.Point(99, 55);
            this.cmbEmpName.Name = "cmbEmpName";
            this.cmbEmpName.Size = new System.Drawing.Size(138, 20);
            this.cmbEmpName.TabIndex = 31;
            this.cmbEmpName.DropDownClosed += new System.EventHandler(this.cmbEmpName_DropDownClosed);
            // 
            // A_AddHistoryAttendance_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_AddHistoryAttendance_Add";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "历史补单";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDept;
        private Shine.ShineTextBox txtCodeSenderAddress;
        private System.Windows.Forms.ComboBox ddlClassAdd;
        private System.Windows.Forms.ComboBox ddlTimerIntervalAdd;
        private System.Windows.Forms.DateTimePicker dtpBeginTimeAdd;
        private System.Windows.Forms.DateTimePicker dtpEndTimeAdd;
        private System.Windows.Forms.DateTimePicker dtpDataAttendanceAdd;
        private Shine.ShineTextBox txtRemarkAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEmpName;
    }
}