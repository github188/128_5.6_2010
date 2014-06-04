namespace KJ128NMainRun
{
    partial class FrmEmployeeInfo_Select
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tbcEmployee = new System.Windows.Forms.TabControl();
            this.tbpDept = new System.Windows.Forms.TabPage();
            this.tvc_Emp_Dept = new DegonControlLib.TreeViewControl();
            this.tbpDuty = new System.Windows.Forms.TabPage();
            this.tvc_Emp_Duty = new DegonControlLib.TreeViewControl();
            this.tbpWorkType = new System.Windows.Forms.TabPage();
            this.tvc_Emp_WorkType = new DegonControlLib.TreeViewControl();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtEmpNo_Query = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmpName_Query = new System.Windows.Forms.TextBox();
            this.txtCard_Query = new System.Windows.Forms.TextBox();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.panelMainTop.SuspendLayout();
            this.drawerLeftMain.SuspendLayout();
            this.panelMainMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.tbcEmployee.SuspendLayout();
            this.tbpDept.SuspendLayout();
            this.tbpDuty.SuspendLayout();
            this.tbpWorkType.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.txtCard_Query);
            this.panelLeftBottom.Controls.Add(this.txtEmpName_Query);
            this.panelLeftBottom.Controls.Add(this.label3);
            this.panelLeftBottom.Controls.Add(this.label2);
            this.panelLeftBottom.Controls.Add(this.label1);
            this.panelLeftBottom.Controls.Add(this.txtEmpNo_Query);
            this.panelLeftBottom.Controls.Add(this.btnReset);
            this.panelLeftBottom.Controls.Add(this.btnQuery);
            // 
            // drawerLeftMain
            // 
            this.drawerLeftMain.Controls.Add(this.tbcEmployee);
            this.drawerLeftMain.Controls.Add(this.button1);
            // 
            // btnAdd
            // 
            this.btnAdd.Visible = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Visible = false;
            // 
            // btnLaws
            // 
            this.btnLaws.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::KJ128NMainRun.Properties.Resources.Laws_01;
            this.btnDelete.Text = "导出";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbSelectCounts
            // 
            this.cmbSelectCounts.DropDownClosed += new System.EventHandler(this.cmbSelectCounts_DropDownClosed);
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSkipPage_KeyDown);
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // btnDownPage
            // 
            this.btnDownPage.Click += new System.EventHandler(this.btnDownPage_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Click += new System.EventHandler(this.btnUpPage_Click);
            // 
            // panelMainMain
            // 
            this.panelMainMain.Controls.Add(this.dgv_Main);
            // 
            // btnConfigModel
            // 
            this.btnConfigModel.Click += new System.EventHandler(this.btnConfigModel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToDeleteRows = false;
            this.dgv_Main.AllowUserToResizeRows = false;
            this.dgv_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Main.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            this.dgv_Main.RowHeadersVisible = false;
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(783, 459);
            this.dgv_Main.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "人员基本信息";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbcEmployee
            // 
            this.tbcEmployee.Controls.Add(this.tbpDept);
            this.tbcEmployee.Controls.Add(this.tbpDuty);
            this.tbcEmployee.Controls.Add(this.tbpWorkType);
            this.tbcEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcEmployee.Location = new System.Drawing.Point(0, 25);
            this.tbcEmployee.Name = "tbcEmployee";
            this.tbcEmployee.SelectedIndex = 0;
            this.tbcEmployee.Size = new System.Drawing.Size(196, 314);
            this.tbcEmployee.TabIndex = 1;
            // 
            // tbpDept
            // 
            this.tbpDept.Controls.Add(this.tvc_Emp_Dept);
            this.tbpDept.Location = new System.Drawing.Point(4, 21);
            this.tbpDept.Name = "tbpDept";
            this.tbpDept.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDept.Size = new System.Drawing.Size(188, 289);
            this.tbpDept.TabIndex = 0;
            this.tbpDept.Text = "部门";
            this.tbpDept.UseVisualStyleBackColor = true;
            // 
            // tvc_Emp_Dept
            // 
            this.tvc_Emp_Dept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_Emp_Dept.Location = new System.Drawing.Point(3, 3);
            this.tvc_Emp_Dept.Name = "tvc_Emp_Dept";
            this.tvc_Emp_Dept.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_Emp_Dept.Size = new System.Drawing.Size(182, 283);
            this.tvc_Emp_Dept.TabIndex = 0;
            this.tvc_Emp_Dept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_Emp_Dept_AfterSelect);
            // 
            // tbpDuty
            // 
            this.tbpDuty.Controls.Add(this.tvc_Emp_Duty);
            this.tbpDuty.Location = new System.Drawing.Point(4, 21);
            this.tbpDuty.Name = "tbpDuty";
            this.tbpDuty.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDuty.Size = new System.Drawing.Size(188, 289);
            this.tbpDuty.TabIndex = 1;
            this.tbpDuty.Text = "职务";
            this.tbpDuty.UseVisualStyleBackColor = true;
            // 
            // tvc_Emp_Duty
            // 
            this.tvc_Emp_Duty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_Emp_Duty.Location = new System.Drawing.Point(3, 3);
            this.tvc_Emp_Duty.Name = "tvc_Emp_Duty";
            this.tvc_Emp_Duty.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_Emp_Duty.Size = new System.Drawing.Size(182, 283);
            this.tvc_Emp_Duty.TabIndex = 0;
            this.tvc_Emp_Duty.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_Emp_Dept_AfterSelect);
            // 
            // tbpWorkType
            // 
            this.tbpWorkType.Controls.Add(this.tvc_Emp_WorkType);
            this.tbpWorkType.Location = new System.Drawing.Point(4, 21);
            this.tbpWorkType.Name = "tbpWorkType";
            this.tbpWorkType.Size = new System.Drawing.Size(188, 289);
            this.tbpWorkType.TabIndex = 2;
            this.tbpWorkType.Text = "工种";
            this.tbpWorkType.UseVisualStyleBackColor = true;
            // 
            // tvc_Emp_WorkType
            // 
            this.tvc_Emp_WorkType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_Emp_WorkType.Location = new System.Drawing.Point(0, 0);
            this.tvc_Emp_WorkType.Name = "tvc_Emp_WorkType";
            this.tvc_Emp_WorkType.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_Emp_WorkType.Size = new System.Drawing.Size(188, 289);
            this.tvc_Emp_WorkType.TabIndex = 0;
            this.tvc_Emp_WorkType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_Emp_Dept_AfterSelect);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(10, 133);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(104, 133);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtEmpNo_Query
            // 
            this.txtEmpNo_Query.Location = new System.Drawing.Point(79, 14);
            this.txtEmpNo_Query.Name = "txtEmpNo_Query";
            this.txtEmpNo_Query.Size = new System.Drawing.Size(100, 21);
            this.txtEmpNo_Query.TabIndex = 2;
            this.txtEmpNo_Query.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpNo_Query_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "卡号：";
            // 
            // txtEmpName_Query
            // 
            this.txtEmpName_Query.Location = new System.Drawing.Point(79, 51);
            this.txtEmpName_Query.Name = "txtEmpName_Query";
            this.txtEmpName_Query.Size = new System.Drawing.Size(100, 21);
            this.txtEmpName_Query.TabIndex = 6;
            this.txtEmpName_Query.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName_Query_KeyPress);
            // 
            // txtCard_Query
            // 
            this.txtCard_Query.Location = new System.Drawing.Point(79, 89);
            this.txtCard_Query.Name = "txtCard_Query";
            this.txtCard_Query.Size = new System.Drawing.Size(100, 21);
            this.txtCard_Query.TabIndex = 7;
            this.txtCard_Query.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCard_Query_KeyPress);
            // 
            // FrmEmployeeInfo_Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Name = "FrmEmployeeInfo_Select";
            this.TabText = "人员基本信息";
            this.Text = "人员基本信息";
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            this.panelLeftBottom.PerformLayout();
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            this.panelMainTop.ResumeLayout(false);
            this.panelMainTop.PerformLayout();
            this.drawerLeftMain.ResumeLayout(false);
            this.panelMainMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.tbcEmployee.ResumeLayout(false);
            this.tbpDept.ResumeLayout(false);
            this.tbpDuty.ResumeLayout(false);
            this.tbpWorkType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tbcEmployee;
        private System.Windows.Forms.TabPage tbpDept;
        private System.Windows.Forms.TabPage tbpDuty;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtCard_Query;
        private System.Windows.Forms.TextBox txtEmpName_Query;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpNo_Query;
        private System.Windows.Forms.TabPage tbpWorkType;
        private DegonControlLib.TreeViewControl tvc_Emp_Dept;
        private DegonControlLib.TreeViewControl tvc_Emp_Duty;
        private DegonControlLib.TreeViewControl tvc_Emp_WorkType;
    }
}