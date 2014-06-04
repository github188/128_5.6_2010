namespace KJ128NMainRun.A_Attendance
{
    partial class A_AttendanceRealTime_Add
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
            this.label10 = new System.Windows.Forms.Label();
            this.txtBlockAdd = new Shine.ShineTextBox();
            this.txtUserNameAdd = new Shine.ShineTextBox();
            this.txtRemark = new Shine.ShineTextBox();
            this.ddlDeptAdd = new System.Windows.Forms.ComboBox();
            this.ddlClassAdd = new System.Windows.Forms.ComboBox();
            this.ddlTimerIntervalAdd = new System.Windows.Forms.ComboBox();
            this.cbOutStation = new System.Windows.Forms.ComboBox();
            this.dtpBeginTimeAdd = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTimeAdd = new System.Windows.Forms.DateTimePicker();
            this.dtpDataAttendanceAdd = new System.Windows.Forms.DateTimePicker();
            this.lblErr = new System.Windows.Forms.Label();
            this.bt_Save = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_dep = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部    门：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "标 示 卡：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "姓    名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "班    制：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "班    次：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "出井分站：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "上班时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "下班时间：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "记工日期：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "备    注：";
            // 
            // txtBlockAdd
            // 
            this.txtBlockAdd.Enabled = false;
            this.txtBlockAdd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBlockAdd.Location = new System.Drawing.Point(341, 10);
            this.txtBlockAdd.Name = "txtBlockAdd";
            this.txtBlockAdd.Size = new System.Drawing.Size(141, 21);
            this.txtBlockAdd.TabIndex = 10;
            this.txtBlockAdd.TextType = Shine.TextType.Number;
            this.txtBlockAdd.TextChanged += new System.EventHandler(this.txtBlockAdd_TextChanged);
            // 
            // txtUserNameAdd
            // 
            this.txtUserNameAdd.Enabled = false;
            this.txtUserNameAdd.Location = new System.Drawing.Point(105, 10);
            this.txtUserNameAdd.Name = "txtUserNameAdd";
            this.txtUserNameAdd.Size = new System.Drawing.Size(141, 21);
            this.txtUserNameAdd.TabIndex = 11;
            this.txtUserNameAdd.TextType = Shine.TextType.WithOutChar;
            this.txtUserNameAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserNameAdd_KeyPress);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(105, 170);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(377, 76);
            this.txtRemark.TabIndex = 12;
            this.txtRemark.TextType = Shine.TextType.WithOutChar;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // ddlDeptAdd
            // 
            this.ddlDeptAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDeptAdd.FormattingEnabled = true;
            this.ddlDeptAdd.Location = new System.Drawing.Point(151, 267);
            this.ddlDeptAdd.Name = "ddlDeptAdd";
            this.ddlDeptAdd.Size = new System.Drawing.Size(100, 20);
            this.ddlDeptAdd.TabIndex = 13;
            this.ddlDeptAdd.Visible = false;
            // 
            // ddlClassAdd
            // 
            this.ddlClassAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClassAdd.FormattingEnabled = true;
            this.ddlClassAdd.Location = new System.Drawing.Point(105, 73);
            this.ddlClassAdd.Name = "ddlClassAdd";
            this.ddlClassAdd.Size = new System.Drawing.Size(141, 20);
            this.ddlClassAdd.TabIndex = 14;
            this.ddlClassAdd.SelectedValueChanged += new System.EventHandler(this.ddlClassAdd_SelectedValueChanged);
            // 
            // ddlTimerIntervalAdd
            // 
            this.ddlTimerIntervalAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTimerIntervalAdd.FormattingEnabled = true;
            this.ddlTimerIntervalAdd.Location = new System.Drawing.Point(341, 41);
            this.ddlTimerIntervalAdd.Name = "ddlTimerIntervalAdd";
            this.ddlTimerIntervalAdd.Size = new System.Drawing.Size(141, 20);
            this.ddlTimerIntervalAdd.TabIndex = 15;
            // 
            // cbOutStation
            // 
            this.cbOutStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutStation.FormattingEnabled = true;
            this.cbOutStation.Location = new System.Drawing.Point(341, 73);
            this.cbOutStation.Name = "cbOutStation";
            this.cbOutStation.Size = new System.Drawing.Size(141, 20);
            this.cbOutStation.TabIndex = 16;
            this.cbOutStation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbOutStation_KeyPress);
            // 
            // dtpBeginTimeAdd
            // 
            this.dtpBeginTimeAdd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTimeAdd.Enabled = false;
            this.dtpBeginTimeAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTimeAdd.Location = new System.Drawing.Point(105, 105);
            this.dtpBeginTimeAdd.Name = "dtpBeginTimeAdd";
            this.dtpBeginTimeAdd.Size = new System.Drawing.Size(141, 21);
            this.dtpBeginTimeAdd.TabIndex = 17;
            // 
            // dtpEndTimeAdd
            // 
            this.dtpEndTimeAdd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTimeAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTimeAdd.Location = new System.Drawing.Point(341, 105);
            this.dtpEndTimeAdd.Name = "dtpEndTimeAdd";
            this.dtpEndTimeAdd.Size = new System.Drawing.Size(141, 21);
            this.dtpEndTimeAdd.TabIndex = 18;
            // 
            // dtpDataAttendanceAdd
            // 
            this.dtpDataAttendanceAdd.CustomFormat = "yyyy-MM-dd";
            this.dtpDataAttendanceAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataAttendanceAdd.Location = new System.Drawing.Point(105, 137);
            this.dtpDataAttendanceAdd.Name = "dtpDataAttendanceAdd";
            this.dtpDataAttendanceAdd.Size = new System.Drawing.Size(141, 21);
            this.dtpDataAttendanceAdd.TabIndex = 19;
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(106, 267);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 12);
            this.lblErr.TabIndex = 20;
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(299, 267);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 23);
            this.bt_Save.TabIndex = 21;
            this.bt_Save.Text = "保  存";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(383, 267);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "返  回";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "提示：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(21, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(21, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 26;
            this.label13.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(262, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 27;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(262, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(21, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(262, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 30;
            this.label17.Text = "*";
            // 
            // textBox_dep
            // 
            this.textBox_dep.Enabled = false;
            this.textBox_dep.Location = new System.Drawing.Point(105, 41);
            this.textBox_dep.Name = "textBox_dep";
            this.textBox_dep.Size = new System.Drawing.Size(141, 21);
            this.textBox_dep.TabIndex = 31;
            // 
            // A_AttendanceRealTime_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 317);
            this.Controls.Add(this.textBox_dep);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.dtpDataAttendanceAdd);
            this.Controls.Add(this.dtpEndTimeAdd);
            this.Controls.Add(this.dtpBeginTimeAdd);
            this.Controls.Add(this.cbOutStation);
            this.Controls.Add(this.ddlTimerIntervalAdd);
            this.Controls.Add(this.ddlClassAdd);
            this.Controls.Add(this.ddlDeptAdd);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtUserNameAdd);
            this.Controls.Add(this.txtBlockAdd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "A_AttendanceRealTime_Add";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "实时补单";
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
        private System.Windows.Forms.Label label10;
        private Shine.ShineTextBox txtBlockAdd;
        private Shine.ShineTextBox txtUserNameAdd;
        private Shine.ShineTextBox txtRemark;
        private System.Windows.Forms.ComboBox ddlDeptAdd;
        private System.Windows.Forms.ComboBox ddlClassAdd;
        private System.Windows.Forms.ComboBox ddlTimerIntervalAdd;
        private System.Windows.Forms.ComboBox cbOutStation;
        private System.Windows.Forms.DateTimePicker dtpBeginTimeAdd;
        private System.Windows.Forms.DateTimePicker dtpEndTimeAdd;
        private System.Windows.Forms.DateTimePicker dtpDataAttendanceAdd;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_dep;
    }
}