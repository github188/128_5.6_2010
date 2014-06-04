namespace KJ128NMainRun.StationManage
{
    partial class A_FrmDirectionalManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pl_Left = new System.Windows.Forms.Panel();
            this.dmc_Info = new DegonControlLib.DrawerMainControl();
            this.pl_Directional = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbc_Info = new System.Windows.Forms.TabControl();
            this.tp_StaHead_Begin = new System.Windows.Forms.TabPage();
            this.tvc_BeginStaHead_Select = new DegonControlLib.TreeViewControl();
            this.tp_StaHead_End = new System.Windows.Forms.TabPage();
            this.tvc_EndStaHead_Select = new DegonControlLib.TreeViewControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Reset = new System.Windows.Forms.Button();
            this.txt_Description_Select = new Shine.ShineTextBox();
            this.bt_Enquiries = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_DirectionalInfo = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pl_Main = new System.Windows.Forms.Panel();
            this.pl_M_Middle = new System.Windows.Forms.Panel();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.pl_M_Bottom = new System.Windows.Forms.Panel();
            this.lblSumPage = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_SelectCounts = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSkipPage = new Shine.ShineTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPageCounts = new System.Windows.Forms.Label();
            this.btnDownPage = new System.Windows.Forms.Button();
            this.btnUpPage = new System.Windows.Forms.Button();
            this.lblCounts = new System.Windows.Forms.Label();
            this.pl_M_Top = new System.Windows.Forms.Panel();
            this.btnConfigModel = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.bt_Print = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_Laws = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.lb_Info = new System.Windows.Forms.Label();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.cl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pl_Left.SuspendLayout();
            this.dmc_Info.SuspendLayout();
            this.pl_Directional.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tbc_Info.SuspendLayout();
            this.tp_StaHead_Begin.SuspendLayout();
            this.tp_StaHead_End.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pl_Main.SuspendLayout();
            this.pl_M_Middle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.pl_M_Bottom.SuspendLayout();
            this.pl_M_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_Left
            // 
            this.pl_Left.Controls.Add(this.dmc_Info);
            this.pl_Left.Controls.Add(this.panel5);
            this.pl_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pl_Left.Location = new System.Drawing.Point(0, 0);
            this.pl_Left.Name = "pl_Left";
            this.pl_Left.Size = new System.Drawing.Size(200, 523);
            this.pl_Left.TabIndex = 1;
            // 
            // dmc_Info
            // 
            this.dmc_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dmc_Info.Controls.Add(this.pl_Directional);
            this.dmc_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dmc_Info.Location = new System.Drawing.Point(0, 0);
            this.dmc_Info.MainHeight = 481;
            this.dmc_Info.Name = "dmc_Info";
            this.dmc_Info.PartTime = 10;
            this.dmc_Info.PType = DegonControlLib.PartType.Time;
            this.dmc_Info.Size = new System.Drawing.Size(200, 370);
            this.dmc_Info.SplitHeight = 1;
            this.dmc_Info.TabIndex = 3;
            this.dmc_Info.TitleHeight = 25;
            // 
            // pl_Directional
            // 
            this.pl_Directional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_Directional.Controls.Add(this.panel2);
            this.pl_Directional.Controls.Add(this.panel1);
            this.pl_Directional.Location = new System.Drawing.Point(3, 9);
            this.pl_Directional.Name = "pl_Directional";
            this.pl_Directional.Size = new System.Drawing.Size(200, 392);
            this.pl_Directional.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 365);
            this.panel2.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tbc_Info);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(198, 273);
            this.panel6.TabIndex = 14;
            // 
            // tbc_Info
            // 
            this.tbc_Info.Controls.Add(this.tp_StaHead_Begin);
            this.tbc_Info.Controls.Add(this.tp_StaHead_End);
            this.tbc_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc_Info.Location = new System.Drawing.Point(0, 0);
            this.tbc_Info.Name = "tbc_Info";
            this.tbc_Info.SelectedIndex = 0;
            this.tbc_Info.Size = new System.Drawing.Size(198, 273);
            this.tbc_Info.TabIndex = 13;
            this.tbc_Info.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbc_Info_Selecting);
            // 
            // tp_StaHead_Begin
            // 
            this.tp_StaHead_Begin.Controls.Add(this.tvc_BeginStaHead_Select);
            this.tp_StaHead_Begin.Location = new System.Drawing.Point(4, 21);
            this.tp_StaHead_Begin.Name = "tp_StaHead_Begin";
            this.tp_StaHead_Begin.Padding = new System.Windows.Forms.Padding(3);
            this.tp_StaHead_Begin.Size = new System.Drawing.Size(190, 248);
            this.tp_StaHead_Begin.TabIndex = 0;
            this.tp_StaHead_Begin.Text = "起始分站";
            this.tp_StaHead_Begin.UseVisualStyleBackColor = true;
            // 
            // tvc_BeginStaHead_Select
            // 
            this.tvc_BeginStaHead_Select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_BeginStaHead_Select.Location = new System.Drawing.Point(3, 3);
            this.tvc_BeginStaHead_Select.Name = "tvc_BeginStaHead_Select";
            this.tvc_BeginStaHead_Select.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_BeginStaHead_Select.Size = new System.Drawing.Size(184, 242);
            this.tvc_BeginStaHead_Select.TabIndex = 1;
            this.tvc_BeginStaHead_Select.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_BeginStaHead_Select_AfterSelect);
            // 
            // tp_StaHead_End
            // 
            this.tp_StaHead_End.Controls.Add(this.tvc_EndStaHead_Select);
            this.tp_StaHead_End.Location = new System.Drawing.Point(4, 21);
            this.tp_StaHead_End.Name = "tp_StaHead_End";
            this.tp_StaHead_End.Padding = new System.Windows.Forms.Padding(3);
            this.tp_StaHead_End.Size = new System.Drawing.Size(190, 248);
            this.tp_StaHead_End.TabIndex = 1;
            this.tp_StaHead_End.Text = "终止分站";
            this.tp_StaHead_End.UseVisualStyleBackColor = true;
            // 
            // tvc_EndStaHead_Select
            // 
            this.tvc_EndStaHead_Select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvc_EndStaHead_Select.Location = new System.Drawing.Point(3, 3);
            this.tvc_EndStaHead_Select.Name = "tvc_EndStaHead_Select";
            this.tvc_EndStaHead_Select.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(67)))), ((int)(((byte)(132)))));
            this.tvc_EndStaHead_Select.Size = new System.Drawing.Size(184, 242);
            this.tvc_EndStaHead_Select.TabIndex = 1;
            this.tvc_EndStaHead_Select.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvc_EndStaHead_Select_AfterSelect);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.bt_Reset);
            this.panel7.Controls.Add(this.txt_Description_Select);
            this.panel7.Controls.Add(this.bt_Enquiries);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 273);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(198, 92);
            this.panel7.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "方向性描述：";
            // 
            // bt_Reset
            // 
            this.bt_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Reset.Location = new System.Drawing.Point(120, 57);
            this.bt_Reset.Name = "bt_Reset";
            this.bt_Reset.Size = new System.Drawing.Size(56, 23);
            this.bt_Reset.TabIndex = 12;
            this.bt_Reset.Text = "重  置";
            this.bt_Reset.UseVisualStyleBackColor = true;
            this.bt_Reset.Click += new System.EventHandler(this.bt_Reset_Click);
            // 
            // txt_Description_Select
            // 
            this.txt_Description_Select.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Description_Select.Location = new System.Drawing.Point(85, 23);
            this.txt_Description_Select.Name = "txt_Description_Select";
            this.txt_Description_Select.Size = new System.Drawing.Size(106, 21);
            this.txt_Description_Select.TabIndex = 8;
            this.txt_Description_Select.TextType = Shine.TextType.WithOutChar;
            this.txt_Description_Select.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Description_Select_KeyPress);
            // 
            // bt_Enquiries
            // 
            this.bt_Enquiries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Enquiries.Location = new System.Drawing.Point(21, 57);
            this.bt_Enquiries.Name = "bt_Enquiries";
            this.bt_Enquiries.Size = new System.Drawing.Size(56, 23);
            this.bt_Enquiries.TabIndex = 11;
            this.bt_Enquiries.Text = "查  询";
            this.bt_Enquiries.UseVisualStyleBackColor = true;
            this.bt_Enquiries.Click += new System.EventHandler(this.bt_Enquiries_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_DirectionalInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 25);
            this.panel1.TabIndex = 7;
            // 
            // bt_DirectionalInfo
            // 
            this.bt_DirectionalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_DirectionalInfo.Location = new System.Drawing.Point(0, 0);
            this.bt_DirectionalInfo.Name = "bt_DirectionalInfo";
            this.bt_DirectionalInfo.Size = new System.Drawing.Size(198, 25);
            this.bt_DirectionalInfo.TabIndex = 0;
            this.bt_DirectionalInfo.Text = "方向性";
            this.bt_DirectionalInfo.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::KJ128NMainRun.Properties.Resources.方向性1;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 370);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 153);
            this.panel5.TabIndex = 4;
            // 
            // pl_Main
            // 
            this.pl_Main.Controls.Add(this.pl_M_Middle);
            this.pl_Main.Controls.Add(this.pl_M_Bottom);
            this.pl_Main.Controls.Add(this.pl_M_Top);
            this.pl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_Main.Location = new System.Drawing.Point(200, 0);
            this.pl_Main.Name = "pl_Main";
            this.pl_Main.Size = new System.Drawing.Size(787, 523);
            this.pl_Main.TabIndex = 2;
            // 
            // pl_M_Middle
            // 
            this.pl_M_Middle.Controls.Add(this.dgv_Main);
            this.pl_M_Middle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_M_Middle.Location = new System.Drawing.Point(0, 30);
            this.pl_M_Middle.Name = "pl_M_Middle";
            this.pl_M_Middle.Size = new System.Drawing.Size(787, 463);
            this.pl_M_Middle.TabIndex = 2;
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToDeleteRows = false;
            this.dgv_Main.AllowUserToResizeRows = false;
            this.dgv_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Main.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl});
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.EnableHeadersVisualStyles = false;
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Main.RowHeadersVisible = false;
            this.dgv_Main.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Main.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(787, 463);
            this.dgv_Main.TabIndex = 0;
            this.dgv_Main.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellDoubleClick);
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            this.dgv_Main.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Main_DataError);
            this.dgv_Main.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Main_DataBindingComplete);
            this.dgv_Main.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellContentClick);
            // 
            // pl_M_Bottom
            // 
            this.pl_M_Bottom.Controls.Add(this.lblSumPage);
            this.pl_M_Bottom.Controls.Add(this.label9);
            this.pl_M_Bottom.Controls.Add(this.cmb_SelectCounts);
            this.pl_M_Bottom.Controls.Add(this.label8);
            this.pl_M_Bottom.Controls.Add(this.label7);
            this.pl_M_Bottom.Controls.Add(this.txtSkipPage);
            this.pl_M_Bottom.Controls.Add(this.label6);
            this.pl_M_Bottom.Controls.Add(this.lblPageCounts);
            this.pl_M_Bottom.Controls.Add(this.btnDownPage);
            this.pl_M_Bottom.Controls.Add(this.btnUpPage);
            this.pl_M_Bottom.Controls.Add(this.lblCounts);
            this.pl_M_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pl_M_Bottom.Location = new System.Drawing.Point(0, 493);
            this.pl_M_Bottom.Name = "pl_M_Bottom";
            this.pl_M_Bottom.Size = new System.Drawing.Size(787, 30);
            this.pl_M_Bottom.TabIndex = 1;
            // 
            // lblSumPage
            // 
            this.lblSumPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumPage.AutoSize = true;
            this.lblSumPage.Location = new System.Drawing.Point(482, 9);
            this.lblSumPage.Name = "lblSumPage";
            this.lblSumPage.Size = new System.Drawing.Size(29, 12);
            this.lblSumPage.TabIndex = 11;
            this.lblSumPage.Text = "/1页";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(748, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "条数";
            // 
            // cmb_SelectCounts
            // 
            this.cmb_SelectCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_SelectCounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SelectCounts.FormattingEnabled = true;
            this.cmb_SelectCounts.Items.AddRange(new object[] {
            "40",
            "100",
            "200",
            "500"});
            this.cmb_SelectCounts.Location = new System.Drawing.Point(705, 6);
            this.cmb_SelectCounts.Name = "cmb_SelectCounts";
            this.cmb_SelectCounts.Size = new System.Drawing.Size(41, 20);
            this.cmb_SelectCounts.TabIndex = 8;
            this.cmb_SelectCounts.DropDownClosed += new System.EventHandler(this.cmb_SelectCounts_DropDownClosed);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(646, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "每页显示";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(626, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "页";
            // 
            // txtSkipPage
            // 
            this.txtSkipPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSkipPage.Location = new System.Drawing.Point(588, 6);
            this.txtSkipPage.MaxLength = 4;
            this.txtSkipPage.Name = "txtSkipPage";
            this.txtSkipPage.Size = new System.Drawing.Size(32, 21);
            this.txtSkipPage.TabIndex = 5;
            this.txtSkipPage.Text = "1";
            this.txtSkipPage.TextType = Shine.TextType.Number;
            this.txtSkipPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SkipPage_KeyDown);
            this.txtSkipPage.Leave += new System.EventHandler(this.txtSkipPage_Leave);
            this.txtSkipPage.Enter += new System.EventHandler(this.txtSkipPage_Enter);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(553, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "跳至";
            // 
            // lblPageCounts
            // 
            this.lblPageCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageCounts.AutoSize = true;
            this.lblPageCounts.Location = new System.Drawing.Point(462, 9);
            this.lblPageCounts.Name = "lblPageCounts";
            this.lblPageCounts.Size = new System.Drawing.Size(11, 12);
            this.lblPageCounts.TabIndex = 3;
            this.lblPageCounts.Text = "1";
            // 
            // btnDownPage
            // 
            this.btnDownPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownPage.Image = global::KJ128NMainRun.Properties.Resources.Right_01;
            this.btnDownPage.Location = new System.Drawing.Point(523, 4);
            this.btnDownPage.Name = "btnDownPage";
            this.btnDownPage.Size = new System.Drawing.Size(23, 23);
            this.btnDownPage.TabIndex = 2;
            this.btnDownPage.UseVisualStyleBackColor = true;
            this.btnDownPage.Click += new System.EventHandler(this.bt_DownPage_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpPage.Image = global::KJ128NMainRun.Properties.Resources.Left_01;
            this.btnUpPage.Location = new System.Drawing.Point(434, 5);
            this.btnUpPage.Name = "btnUpPage";
            this.btnUpPage.Size = new System.Drawing.Size(23, 23);
            this.btnUpPage.TabIndex = 1;
            this.btnUpPage.UseVisualStyleBackColor = true;
            this.btnUpPage.Click += new System.EventHandler(this.bt_UpPage_Click);
            // 
            // lblCounts
            // 
            this.lblCounts.AutoSize = true;
            this.lblCounts.Location = new System.Drawing.Point(6, 9);
            this.lblCounts.Name = "lblCounts";
            this.lblCounts.Size = new System.Drawing.Size(143, 12);
            this.lblCounts.TabIndex = 0;
            this.lblCounts.Text = "符合筛选条件：共 456 人";
            // 
            // pl_M_Top
            // 
            this.pl_M_Top.Controls.Add(this.btnConfigModel);
            this.pl_M_Top.Controls.Add(this.btnExportExcel);
            this.pl_M_Top.Controls.Add(this.bt_Print);
            this.pl_M_Top.Controls.Add(this.bt_Delete);
            this.pl_M_Top.Controls.Add(this.bt_Laws);
            this.pl_M_Top.Controls.Add(this.btnSelectAll);
            this.pl_M_Top.Controls.Add(this.bt_Add);
            this.pl_M_Top.Controls.Add(this.lb_Info);
            this.pl_M_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_M_Top.Location = new System.Drawing.Point(0, 0);
            this.pl_M_Top.Name = "pl_M_Top";
            this.pl_M_Top.Size = new System.Drawing.Size(787, 30);
            this.pl_M_Top.TabIndex = 0;
            // 
            // btnConfigModel
            // 
            this.btnConfigModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfigModel.Image = global::KJ128NMainRun.Properties.Resources.app_booth;
            this.btnConfigModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigModel.Location = new System.Drawing.Point(721, 4);
            this.btnConfigModel.Name = "btnConfigModel";
            this.btnConfigModel.Size = new System.Drawing.Size(54, 23);
            this.btnConfigModel.TabIndex = 29;
            this.btnConfigModel.Text = "设置";
            this.btnConfigModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfigModel.UseVisualStyleBackColor = true;
            this.btnConfigModel.Click += new System.EventHandler(this.btnConfigModel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportExcel.Image = global::KJ128NMainRun.Properties.Resources.app_share;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(658, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(54, 23);
            this.btnExportExcel.TabIndex = 28;
            this.btnExportExcel.Text = "导出";
            this.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // bt_Print
            // 
            this.bt_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Print.Image = global::KJ128NMainRun.Properties.Resources.Print_01;
            this.bt_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Print.Location = new System.Drawing.Point(597, 4);
            this.bt_Print.Name = "bt_Print";
            this.bt_Print.Size = new System.Drawing.Size(54, 23);
            this.bt_Print.TabIndex = 2;
            this.bt_Print.Text = "打印";
            this.bt_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Print.UseVisualStyleBackColor = true;
            this.bt_Print.Click += new System.EventHandler(this.bt_Print_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Delete.Image = global::KJ128NMainRun.Properties.Resources.Delete_02;
            this.bt_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Delete.Location = new System.Drawing.Point(537, 4);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(54, 23);
            this.bt_Delete.TabIndex = 2;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_Laws
            // 
            this.bt_Laws.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Laws.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Laws.Image = global::KJ128NMainRun.Properties.Resources.Laws_01;
            this.bt_Laws.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Laws.Location = new System.Drawing.Point(477, 4);
            this.bt_Laws.Name = "bt_Laws";
            this.bt_Laws.Size = new System.Drawing.Size(54, 23);
            this.bt_Laws.TabIndex = 2;
            this.bt_Laws.Text = "修改";
            this.bt_Laws.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Laws.UseVisualStyleBackColor = true;
            this.bt_Laws.Click += new System.EventHandler(this.bt_Laws_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectAll.Image = global::KJ128NMainRun.Properties.Resources.SelectAll_01;
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.Location = new System.Drawing.Point(417, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(54, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.bt_SelectAll_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Add.Image = global::KJ128NMainRun.Properties.Resources.Add_01;
            this.bt_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Add.Location = new System.Drawing.Point(357, 4);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(54, 23);
            this.bt_Add.TabIndex = 1;
            this.bt_Add.Text = "新增";
            this.bt_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // lb_Info
            // 
            this.lb_Info.AutoSize = true;
            this.lb_Info.Location = new System.Drawing.Point(6, 9);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(65, 12);
            this.lb_Info.TabIndex = 0;
            this.lb_Info.Text = "方向性配置";
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Interval = 400;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // cl
            // 
            this.cl.FalseValue = "0";
            this.cl.FillWeight = 30F;
            this.cl.HeaderText = "";
            this.cl.IndeterminateValue = "2";
            this.cl.Name = "cl";
            this.cl.ReadOnly = true;
            this.cl.TrueValue = "1";
            // 
            // A_FrmDirectionalManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 523);
            this.Controls.Add(this.pl_Main);
            this.Controls.Add(this.pl_Left);
            this.Name = "A_FrmDirectionalManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "方向性配置";
            this.Text = "方向性配置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.A_FrmDirectionalManage_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.A_FrmDirectionalManage_FormClosing);
            this.pl_Left.ResumeLayout(false);
            this.dmc_Info.ResumeLayout(false);
            this.pl_Directional.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tbc_Info.ResumeLayout(false);
            this.tp_StaHead_Begin.ResumeLayout(false);
            this.tp_StaHead_End.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pl_Main.ResumeLayout(false);
            this.pl_M_Middle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.pl_M_Bottom.ResumeLayout(false);
            this.pl_M_Bottom.PerformLayout();
            this.pl_M_Top.ResumeLayout(false);
            this.pl_M_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_Left;
        private DegonControlLib.DrawerMainControl dmc_Info;
        private System.Windows.Forms.Panel pl_Directional;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TabControl tbc_Info;
        private System.Windows.Forms.TabPage tp_StaHead_Begin;
        private DegonControlLib.TreeViewControl tvc_BeginStaHead_Select;
        private System.Windows.Forms.TabPage tp_StaHead_End;
        private DegonControlLib.TreeViewControl tvc_EndStaHead_Select;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Reset;
        private Shine.ShineTextBox txt_Description_Select;
        private System.Windows.Forms.Button bt_Enquiries;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_DirectionalInfo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pl_Main;
        private System.Windows.Forms.Panel pl_M_Middle;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Panel pl_M_Bottom;
        private System.Windows.Forms.Label lblSumPage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_SelectCounts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Shine.ShineTextBox txtSkipPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPageCounts;
        private System.Windows.Forms.Button btnDownPage;
        private System.Windows.Forms.Button btnUpPage;
        private System.Windows.Forms.Label lblCounts;
        private System.Windows.Forms.Panel pl_M_Top;
        private System.Windows.Forms.Button bt_Print;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Laws;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Label lb_Info;
        public System.Windows.Forms.Timer timer_Refresh;
        protected System.Windows.Forms.Button btnConfigModel;
        protected System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cl;
    }
}