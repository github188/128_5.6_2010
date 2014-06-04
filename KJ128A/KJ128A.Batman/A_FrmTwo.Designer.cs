namespace KJ128A.Batman
{
    partial class A_FrmTwo
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
            this.btnExit = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCallCard = new System.Windows.Forms.Button();
            this.cmbStaHead = new System.Windows.Forms.ComboBox();
            this.lblSta = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rTxtBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.numTxtCard = new Shine.ShineTextBox();
            this.cmbSta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCallAll = new System.Windows.Forms.Button();
            this.btnSta = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(291, 236);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "取消呼叫";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Blue;
            this.lblName.Location = new System.Drawing.Point(157, 94);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(119, 12);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "(输入单呼标识卡号!)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "标识卡号：";
            // 
            // btnCallCard
            // 
            this.btnCallCard.Location = new System.Drawing.Point(200, 236);
            this.btnCallCard.Name = "btnCallCard";
            this.btnCallCard.Size = new System.Drawing.Size(75, 23);
            this.btnCallCard.TabIndex = 8;
            this.btnCallCard.Text = "人员呼叫 ";
            this.btnCallCard.UseVisualStyleBackColor = true;
            this.btnCallCard.Click += new System.EventHandler(this.btnCallCard_Click);
            // 
            // cmbStaHead
            // 
            this.cmbStaHead.FormattingEnabled = true;
            this.cmbStaHead.Location = new System.Drawing.Point(78, 55);
            this.cmbStaHead.Name = "cmbStaHead";
            this.cmbStaHead.Size = new System.Drawing.Size(251, 20);
            this.cmbStaHead.TabIndex = 3;
            // 
            // lblSta
            // 
            this.lblSta.AutoSize = true;
            this.lblSta.Location = new System.Drawing.Point(13, 24);
            this.lblSta.Name = "lblSta";
            this.lblSta.Size = new System.Drawing.Size(65, 12);
            this.lblSta.TabIndex = 0;
            this.lblSta.Text = "传输分站：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.rTxtBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.numTxtCard);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbStaHead);
            this.groupBox1.Controls.Add(this.lblSta);
            this.groupBox1.Controls.Add(this.cmbSta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(21, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 227);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rTxtBox
            // 
            this.rTxtBox.Location = new System.Drawing.Point(78, 124);
            this.rTxtBox.Name = "rTxtBox";
            this.rTxtBox.ReadOnly = true;
            this.rTxtBox.Size = new System.Drawing.Size(251, 89);
            this.rTxtBox.TabIndex = 50;
            this.rTxtBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 49;
            this.label3.Text = "待呼人员：";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(232, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 23);
            this.btnAdd.TabIndex = 47;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // numTxtCard
            // 
            this.numTxtCard.Location = new System.Drawing.Point(78, 88);
            this.numTxtCard.MaxLength = 5;
            this.numTxtCard.Name = "numTxtCard";
            this.numTxtCard.Size = new System.Drawing.Size(73, 21);
            this.numTxtCard.TabIndex = 46;
            this.numTxtCard.TextType = Shine.TextType.Number;
            this.numTxtCard.TextChanged += new System.EventHandler(this.numTxtCard_TextChanged);
            // 
            // cmbSta
            // 
            this.cmbSta.FormattingEnabled = true;
            this.cmbSta.Location = new System.Drawing.Point(78, 21);
            this.cmbSta.Name = "cmbSta";
            this.cmbSta.Size = new System.Drawing.Size(251, 20);
            this.cmbSta.TabIndex = 2;
            this.cmbSta.SelectedIndexChanged += new System.EventHandler(this.cmbSta_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "读卡分站：";
            // 
            // btnCallAll
            // 
            this.btnCallAll.BackColor = System.Drawing.SystemColors.Control;
            this.btnCallAll.ForeColor = System.Drawing.Color.Blue;
            this.btnCallAll.Location = new System.Drawing.Point(21, 236);
            this.btnCallAll.Name = "btnCallAll";
            this.btnCallAll.Size = new System.Drawing.Size(75, 23);
            this.btnCallAll.TabIndex = 10;
            this.btnCallAll.Text = "全矿呼叫";
            this.btnCallAll.UseVisualStyleBackColor = false;
            this.btnCallAll.Click += new System.EventHandler(this.btnCallAll_Click);
            // 
            // btnSta
            // 
            this.btnSta.Location = new System.Drawing.Point(110, 236);
            this.btnSta.Name = "btnSta";
            this.btnSta.Size = new System.Drawing.Size(75, 23);
            this.btnSta.TabIndex = 11;
            this.btnSta.Text = "区域呼叫";
            this.btnSta.UseVisualStyleBackColor = true;
            this.btnSta.Click += new System.EventHandler(this.btnSta_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(285, 88);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(44, 23);
            this.btnDel.TabIndex = 51;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // A_FrmTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 271);
            this.Controls.Add(this.btnSta);
            this.Controls.Add(this.btnCallAll);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCallCard);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "A_FrmTwo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "双向通讯";
            this.Load += new System.EventHandler(this.A_FrmTwo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCallCard;
        private System.Windows.Forms.ComboBox cmbStaHead;
        private System.Windows.Forms.Label lblSta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSta;
        private System.Windows.Forms.Label label2;
        private Shine.ShineTextBox numTxtCard;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rTxtBox;
        private System.Windows.Forms.Button btnCallAll;
        private System.Windows.Forms.Button btnSta;
        private System.Windows.Forms.Button btnDel;
    }
}