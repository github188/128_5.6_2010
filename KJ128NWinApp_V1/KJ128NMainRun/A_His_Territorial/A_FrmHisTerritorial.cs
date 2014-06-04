using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Threading;

namespace KJ128NMainRun.A_His_Territorial
{
    public partial class A_FrmHisTerritorial : Wilson.Controls.Docking.DockContent
    {


        #region【声明】

        private A_RTTerritorialBLL rttbll = new A_RTTerritorialBLL();

        private A_HisTerritorialBLL httbll = new A_HisTerritorialBLL();

        private A_TreeBLL tbll = new A_TreeBLL();

        private bool blIsEmp = true;
        private DataSet ds;
        private string TableName = string.Empty;
        private string TableName2 = string.Empty;

        private bool blIsRefreshTree = true;

        private string strWhere = " 1=1";

        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        /// <summary>
        /// 1：区域；2：限制区域；3：重点区域；4：地域
        /// </summary>
        private int intSelectModel = 1;

        #endregion

        #region【构造函数】

        public A_FrmHisTerritorial()
        {
            InitializeComponent();

            //区域
            dmc_Info.Add(pl_HisTerritorial, true);

            //限制区域
            dmc_Info.Add(pl_ConfineArea);

            //重点区域
            dmc_Info.Add(pl_KeyArea);

            //地域
            dmc_Info.Add(pl_DistrictArea);

            dmc_Info.LeftPartResize();
        }

        #endregion

        #region【窗体加载】

        private void A_FrmHisTerritorial_Load(object sender, EventArgs e)
        {
            dtp_Ter_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            dtp_Ter_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            LoadComboBox_Dept();    //加载部门信息
            LoadCmbDuty();          //加载工种信息
            LoadTree(1);            //加载树

            cmbSelectCounts.Text = "40";

            //默认查询人员信息
            //strWhere = StrWhere();
            //Select_Territorial_Emp(1);
        }

        #endregion

        #region【方法：加载部门】

        /// <summary>
        /// 加载部门
        /// </summary>
        private void LoadComboBox_Dept()
        {
            using (ds = new DataSet())
            {
                ds = rttbll.GetDeptComboBox();
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = 0;
                    dr[1] = "所有";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cmb_Dept.DataSource = ds.Tables[0];
                    cmb_Dept.DisplayMember = "DeptName";
                    cmb_Dept.ValueMember = "DeptID";
                    cmb_Dept.SelectedValue = 0;
                }
            }
        }

        #endregion

        #region【方法:Czlt-2010-12-06 加载职务】
        private void LoadCmbDuty()
        {
            using (ds = new DataSet())
            {
                ds = rttbll.GetWorkType();
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = 0;
                    dr[1] = "所有";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cmb_duty.DataSource = ds.Tables[0];
                    cmb_duty.DisplayMember = "WtName";
                    cmb_duty.ValueMember = "workTypeID";
                    cmb_duty.SelectedValue = 0;
                }
            }
        }
        #endregion

        #region【方法：返回当前区域类别】

        private string GetStrTitle()
        {
            string strTitle = "区域";
            switch (intSelectModel)
            {
                case 1:

                    strTitle = "区域";

                    break;
                case 2:

                    strTitle = "限制区域";

                    break;
                case 3:

                    strTitle = "重点区域";

                    break;
                case 4:

                    strTitle = "地域";

                    break;
                default:
                    break;
            }
            return strTitle + "信息";
        }

        #endregion

        #region 【方法: 遍历节点下的所有子节点】

        /// <summary>
        /// 遍历节点下的所有子节点
        /// </summary>
        /// <param name="tn"></param>
        private string GetNodeAllChild(TreeNode tn)
        {
            string strNodeChildName;

            strNodeChildName = " '" + tn.Tag.ToString() + "' ";
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    if (n.Nodes.Count > 0)
                    {
                        GetNodeAllChild(n);
                    }
                    strNodeChildName += " or DeptName= '" + n.Tag.ToString() + "'";
                }
            }
            return strNodeChildName;
        }
        #endregion


        #region【方法：控制翻页状态】

        private void SetPageEnable(int pIndex, int sumPage)
        {
            if (pIndex == 1)
            {
                if (sumPage == 1)
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = true;
                }
            }
            else if (pIndex >= sumPage)
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = false;
            }
            else
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = true;
            }
        }

        #endregion

        #region【方法：加载树】

        /// <summary>
        /// 加载树
        /// </summary>
        /// <param name="intModel">1：区域类型树——区域；2：部门——限制区域；3：部门树——重点区域；4：部门树——地域</param>
        private void LoadTree(int intModel)
        {
            switch (intModel)
            {
                case 1:

                    #region【区域】

                    using (ds = new DataSet())
                    {
                        ds = httbll.GetTerritorialTree();
                        tvc_Territorial.Nodes.Clear();
                        tbll.LoadTree(tvc_Territorial, ds, "人", false, "所有");
                        tvc_Territorial.ExpandAll();
                    }

                    #endregion

                    break;
                case 2:

                    #region【限制区域】

                    using (ds = new DataSet())
                    {
                        ds = httbll.GetDeptTree();
                        tvc_ConfineArea_Dept.Nodes.Clear();
                        tbll.LoadTree(tvc_ConfineArea_Dept, ds, "人", false, "所有");
                        tvc_ConfineArea_Dept.ExpandAll();
                    }

                    #endregion

                    break;
                case 3:

                    #region【重点区域】

                    using (ds = new DataSet())
                    {
                        ds = httbll.GetDeptTree();
                        tvc_KeyArea_Dept.Nodes.Clear();
                        tbll.LoadTree(tvc_KeyArea_Dept, ds, "人", false, "所有");
                        tvc_KeyArea_Dept.ExpandAll();
                    }

                    #endregion

                    break;
                case 4:

                    #region【地域】

                    using (ds = new DataSet())
                    {
                        ds = httbll.GetDeptTree();
                        tvc_DistrictArea_Dept.Nodes.Clear();
                        tbll.LoadTree(tvc_DistrictArea_Dept, ds, "人", false, "所有");
                        tvc_DistrictArea_Dept.ExpandAll();
                    }

                    #endregion

                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 【方法: 组织查询条件——区域】

        private string StrWhere()
        {
            TableName = dtp_Ter_Begin.Value.ToString("yyyyM");
            TableName2 = dtp_Ter_End.Value.ToString("yyyyM");
            string strTempWhere = " InTerritorialTime >= '" + dtp_Ter_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' And InTerritorialTime <='" + dtp_Ter_End.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";

            if (tvc_Territorial.SelectedNode != null && !tvc_Territorial.SelectedNode.Name.Equals("0"))
            {
                if (tvc_Territorial.SelectedNode.Name.Substring(0, 1).Equals("T"))  //区域类型
                {
                    strTempWhere += " And TerritorialTypeName = '" + tvc_Territorial.SelectedNode.Tag.ToString() + "' ";
                }
                else if (tvc_Territorial.SelectedNode.Name.Substring(0, 1).Equals("I"))  //区域名称
                {
                    strTempWhere += " And TerritorialName = '" + tvc_Territorial.SelectedNode.Tag.ToString() + "' ";
                }
            }

            if (!txt_Territorial_EmpName.Text.Trim().Equals(""))
            {
                if (blIsEmp)            //人员
                {
                    strTempWhere += " And UserName like  '%" + txt_Territorial_EmpName.Text.Trim() + "%' ";
                }
                else                    //设备
                {
                    strTempWhere += " And UserName like  '%" + txt_Territorial_EmpName.Text.Trim() + "%' ";
                }
            }

            if (!txt_Territorial_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And CodeSenderAddress = " + txt_Territorial_CodeSenderAddress.Text.Trim();
            }

            if (!cmb_Dept.SelectedValue.Equals(0))
            {
                strTempWhere += " And DeptName ='" + cmb_Dept.Text + "' ";
            }

            //Czlt-2010-12-06 - 工种查询条件
            if (!cmb_duty.SelectedValue.Equals(0))
            {
                strTempWhere += "And workTypeName='" + cmb_duty.Text.Trim() + "' ";
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询——人员】

        public void Select_Territorial_Emp(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = httbll.GetInfo_HisTerritorial_Emp(pIndex, 9999999, strWhere, TableName, TableName2);
            if (!this.IsHandleCreated)
                return;
            this.Invoke(new MethodInvoker(delegate()
                {
                    if (ds.Tables != null && ds.Tables.Count > 0)
                    {
                        // 重新设置页数
                        int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                        sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                        countPage = sumPage;
                        ds.Tables[0].TableName = "A_FrmHisTerritorial_Emp";
                        if (sumPage == 0)
                        {
                            dgv_Main.DataSource = ds.Tables[0];

                            //lblMainTitle.Text = GetStrTitle() + "：  共 0 人";
                            lblCounts.Text = "共 0 条记录";

                            lblPageCounts.Text = "1";
                            lblSumPage.Text = "/1页";

                            btnUpPage.Enabled = false;
                            btnDownPage.Enabled = false;
                        }
                        else
                        {

                            dgv_Main.DataSource = ds.Tables[0];

                            //lblMainTitle.Text = GetStrTitle() + "：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 人";
                            lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                            lblPageCounts.Text = pIndex.ToString();
                            lblSumPage.Text = "/" + sumPage + "页";

                            //控制翻页状态
                            SetPageEnable(pIndex, sumPage);
                        }
                        if (dgv_Main.Columns.Count >= 10)
                        {
                            dgv_Main.Columns["InTerritorialTime"].HeaderText = "进入时间";
                            dgv_Main.Columns["InTerritorialTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                            dgv_Main.Columns["OutTerritorialTime"].HeaderText = "离开时间";
                            dgv_Main.Columns["OutTerritorialTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                            dgv_Main.Columns["HisTerritorialID"].Visible = false;

                            dgv_Main.Columns["CodeSenderAddress"].HeaderText = "标识卡号";
                            dgv_Main.Columns["CodeSenderAddress"].DisplayIndex = 0;
                            dgv_Main.Columns["UserName"].HeaderText = "姓名";
                            dgv_Main.Columns["UserName"].DisplayIndex = 1;
                            dgv_Main.Columns["DeptName"].HeaderText = "部门";
                            dgv_Main.Columns["DeptName"].DisplayIndex = 2;
                            dgv_Main.Columns["DutyName"].HeaderText = "职务";
                            dgv_Main.Columns["DutyName"].DisplayIndex = 3;
                            dgv_Main.Columns["WorkTypeName"].HeaderText = "工种";
                            dgv_Main.Columns["WorkTypeName"].DisplayIndex = 4;
                            dgv_Main.Columns["TerritorialTypeName"].HeaderText = "区域类型";
                            dgv_Main.Columns["TerritorialTypeName"].DisplayIndex = 5;
                            dgv_Main.Columns["TerritorialName"].HeaderText = "区域名称";
                            dgv_Main.Columns["TerritorialName"].DisplayIndex = 6;
                            dgv_Main.Columns["InTerritorialTime"].HeaderText = "进入时间";
                            dgv_Main.Columns["InTerritorialTime"].DisplayIndex = 7;
                            dgv_Main.Columns["OutTerritorialTime"].HeaderText = "离开时间";
                            dgv_Main.Columns["OutTerritorialTime"].DisplayIndex = 8;
                            dgv_Main.Columns["ContinueTime"].HeaderText = "持续时长";
                            dgv_Main.Columns["ContinueTime"].DisplayIndex = 9;
                            dgv_Main.Columns["ContinueTime"].Visible = false;

                            dgv_Main.Columns["DutyName"].DefaultCellStyle.NullValue = "——";
                            dgv_Main.Columns["WorkTypeName"].DefaultCellStyle.NullValue = "——";

                            dgv_Main.Columns["TerritorialID"].Visible = false;
                            dgv_Main.Columns["UserNo"].Visible = false;
                            dgv_Main.Columns["DeptID"].Visible = false;
                            dgv_Main.Columns["DutyID"].Visible = false;
                            dgv_Main.Columns["WorkTypeID"].Visible = false;
                            dgv_Main.Columns["IsAlarm"].Visible = false;
                            dgv_Main.Columns["UserID"].Visible = false;

                            if (intSelectModel == 1)
                            {
                                dgv_Main.Columns["TerritorialTypeName"].Visible = true;
                            }
                            else
                            {
                                dgv_Main.Columns["TerritorialTypeName"].Visible = false;
                            }

                            if (ds.Tables.Count > 0)
                            {
                                DataColumn dc = new DataColumn("持续时长");
                                ds.Tables[0].Columns.Add(dc);

                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    Int64 iTime = Int64.Parse(ds.Tables[0].Rows[i]["ContinueTime"].ToString());
                                    int iDay = (int)(iTime / 86400);
                                    int iHour = (int)((iTime - iDay * 86400) / 3600);
                                    int iMinute = (int)((iTime - iDay * 86400 - iHour * 3600) / 60);
                                    ds.Tables[0].Rows[i]["持续时长"] = string.Format("{0}天{1}时{2}分{3}秒",
                                        iDay, iHour, iMinute, iTime % 60);
                                }
                            }
                        }
                    }
                }));
        }
        #endregion

        #region【方法：查询——设备】

        public void Select_Territorial_Equ(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = httbll.GetInfo_HisTerritorial_Equ(pIndex, pSize, strWhere);
            if (!this.IsHandleCreated)
                return;
            this.Invoke(new MethodInvoker(delegate()
                {
                    if (ds.Tables != null && ds.Tables.Count > 0)
                    {
                        // 重新设置页数
                        int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                        sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                        countPage = sumPage;
                        ds.Tables[0].TableName = "A_FrmHisTerritorial_Equ";
                        if (sumPage == 0)
                        {
                            dgv_Main.DataSource = ds.Tables[0];

                            //lblMainTitle.Text = GetStrTitle() + "：  共 0 个";
                            lblCounts.Text = "共 0 条记录";

                            lblPageCounts.Text = "1";
                            lblSumPage.Text = "/1页";

                            btnUpPage.Enabled = false;
                            btnDownPage.Enabled = false;
                        }
                        else
                        {

                            dgv_Main.DataSource = ds.Tables[0];

                            //lblMainTitle.Text = GetStrTitle() + "：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 个";
                            lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                            lblPageCounts.Text = pIndex.ToString();
                            lblSumPage.Text = "/" + sumPage + "页";

                            //控制翻页状态
                            SetPageEnable(pIndex, sumPage);
                        }
                        if (dgv_Main.Columns.Count >= 9)
                        {
                            dgv_Main.Columns["进入时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                            dgv_Main.Columns["离开时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                            dgv_Main.Columns["HisTerritorialID"].Visible = false;

                            dgv_Main.Columns["CodeSenderAddress"].HeaderText = "标识卡号";
                            dgv_Main.Columns["CodeSenderAddress"].DisplayIndex = 0;
                            dgv_Main.Columns["UserName"].HeaderText = "设备名称";
                            dgv_Main.Columns["UserName"].DisplayIndex = 1;
                            dgv_Main.Columns["UserID"].HeaderText = "设备编号";
                            dgv_Main.Columns["UserID"].DisplayIndex = 2;
                            dgv_Main.Columns["DeptName"].HeaderText = "部门";
                            dgv_Main.Columns["DeptName"].DisplayIndex = 3;
                            dgv_Main.Columns["TerritorialTypeName"].HeaderText = "区域类型";
                            dgv_Main.Columns["TerritorialTypeName"].DisplayIndex = 4;
                            dgv_Main.Columns["TerritorialName"].HeaderText = "区域名称";
                            dgv_Main.Columns["TerritorialName"].DisplayIndex = 5;
                            dgv_Main.Columns["InTerritorialTime"].HeaderText = "进入时间";
                            dgv_Main.Columns["InTerritorialTime"].DisplayIndex = 6;
                            dgv_Main.Columns["OutTerritorialTime"].HeaderText = "离开时间";
                            dgv_Main.Columns["OutTerritorialTime"].DisplayIndex = 7;
                            dgv_Main.Columns["ContinueTime"].HeaderText = "持续时长";
                            dgv_Main.Columns["ContinueTime"].DisplayIndex = 8;

                            if (intSelectModel == 1)
                            {
                                dgv_Main.Columns["TerritorialTypeName"].Visible = true;
                            }
                            else
                            {
                                dgv_Main.Columns["TerritorialTypeName"].Visible = false;
                            }

                            dgv_Main.Columns["TerritorialID"].Visible = false;
                            dgv_Main.Columns["UserNO"].Visible = false;
                            dgv_Main.Columns["DeptID"].Visible = false;
                            dgv_Main.Columns["WorkTypeName"].Visible = false;
                            dgv_Main.Columns["DeptName"].Visible = false;
                            dgv_Main.Columns["DutyID"].Visible = false;
                            dgv_Main.Columns["WorkTypeID"].Visible = false;
                            dgv_Main.Columns["IsAlarm"].Visible = false;


                            if (ds.Tables.Count > 0)
                            {
                                DataColumn dc = new DataColumn("持续时长");
                                ds.Tables[0].Columns.Add(dc);

                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    Int64 iTime = Int64.Parse(ds.Tables[0].Rows[i]["ContinueTime"].ToString());
                                    int iDay = (int)(iTime / 86400);
                                    int iHour = (int)((iTime - iDay * 86400) / 3600);
                                    int iMinute = (int)((iTime - iDay * 86400 - iHour * 3600) / 60);
                                    ds.Tables[0].Rows[i]["持续时长"] = string.Format("{0}天{1}时{2}分{3}秒",
                                        iDay, iHour, iMinute, iTime % 60);
                                }
                            }
                        }
                    }
                }));
        }
        #endregion

        #region【方法：判断时间】

        private bool DecideTime(DateTimePicker dtpBegin, DateTimePicker dtpEnd)
        {
            if (dtpEnd.Value > DateTime.Now)
            {
                dtpEnd.Value = DateTime.Now;
            }
            if (dtpBegin.Value >= dtpEnd.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            //Czlt-2010-11-30 优化
            //if (dtpBegin.Value.AddDays(7) < dtpEnd.Value)
            //{
            //    MessageBox.Show("开始时间与结束时间相差不能大于7天！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return false;
            //}
            return true;
        }

        #endregion



        #region【事件：选择区域类型、区域名称】

        private void tvc_Territorial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (!DecideTime(dtp_Ter_Begin, dtp_Ter_End))
            //{
            //    return;
            //}

            //strWhere = StrWhere();

            //if (blIsEmp)        //人员
            //{
            //    Select_Territorial_Emp(1);
            //}
            //else                //设备
            //{
            //    Select_Territorial_Equ(1);
            //}
        }

        #endregion
        Thread th = null;
        private void BingdingDGV()
        {

            if (blIsEmp)            //人员
            {
                Select_Territorial_Emp(1);
            }
            else                    //设备
            {
                Select_Territorial_Equ(1);
            }
            pictureBox1.Invoke(new MethodInvoker(delegate()
            {
                pictureBox1.Visible = false;
            }));
            th.Abort();
        }

        #region【事件：查询】

        private void bt_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_Ter_Begin, dtp_Ter_End))
            {
                return;
            }
            
            strWhere = StrWhere();
            pictureBox1.Visible = true;
            th = new Thread(BingdingDGV);
            th.Start();
        }

        #endregion

        #region【事件：重置】

        private void bt_Reset_Click(object sender, EventArgs e)
        {
            dtp_Ter_Begin.Value = DateTime.Now.Date;
            dtp_Ter_End.Value = DateTime.Now;
            txt_Territorial_CodeSenderAddress.Text = "";
            txt_Territorial_EmpName.Text = "";
            cmb_Dept.SelectedValue = 0;
            dgv_Main.DataSource = new DataTable();
            lblCounts.Text = "共 0 条记录";
        }

        #endregion

        #region【事件：上一页】

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }

            pictureBox1.Visible = true;

            th = new Thread(BingdingDGV);
            th.Start();
        }

        #endregion

        #region【事件：下一页】

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (page > countPage)
            {
                return;
            }

            pictureBox1.Visible = true;
          
            th = new Thread(BingdingDGV);
            th.Start();
        }

        #endregion

        #region【事件：跳至】

        private void txtSkipPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string value = txtSkipPage.Text;
                if (value.CompareTo("") == 0)       //为空值时
                {
                    return;
                }
                else if (int.Parse(value) > 0)
                {
                    int page = int.Parse(value);
                    if (page > countPage)
                    {
                        page = countPage;
                    }

                    pictureBox1.Visible = true;
                    th = new Thread(BingdingDGV);
                    th.Start();
                }
            }
        }

        #endregion

        #region【事件：选择每页显示条数】

        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbSelectCounts.Text.Trim() == "全部")
                pSize = 9999999;
            else
                pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);

            pictureBox1.Visible = true;
            th = new Thread(BingdingDGV);
            th.Start();
        }


        #endregion

        #region【事件：选择人员、设备】

        private void rb_Emp_CheckedChanged(object sender, EventArgs e)
        {
            //if (rb_Emp.Checked)         //人员
            //{
            //    blIsEmp = true;
            //    label1.Text = "姓名：";

            //    #region【获取查询条件】

            //    switch (intSelectModel)
            //    {
            //        case 1:
                        
            //            #region【区域】

            //            txt_Territorial_CodeSenderAddress.Text = "";
            //            txt_Territorial_EmpName.Text = "";
            //            cmb_Dept.SelectedValue = 0;
            //            dtp_Ter_Begin.Value = DateTime.Today;
            //            dtp_Ter_End.Value = DateTime.Now;

            //            strWhere = StrWhere();

            //            #endregion

            //            break;
            //        case 2:

            //            #region【限制区域】

            //            txt_ConfineArea_CodeSenderAddress.Text = "";
            //            txt_ConfineArea_EmpName.Text = "";
            //            dtp_ConfineArea_Begin.Value = DateTime.Today;
            //            dtp_ConfineArea_End.Value = DateTime.Now;

            //            strWhere = StrWhere_ConfineArea();

            //            #endregion

            //            break;
            //        case 3:

            //            #region【重点区域】

            //            txt_KeyArea_CodeSenderAddress.Text = "";
            //            txt_KeyArea_EmpName.Text = "";
            //            dtp_KeyArea_Begin.Value = DateTime.Today;
            //            dtp_KeyArea_End.Value = DateTime.Now;

            //            strWhere = StrWhere_KeyArea();

            //            #endregion
                        
            //            break;
            //        case 4:

            //            #region【地域】

            //            txt_DistrictArea_CodeSenderAddress.Text = "";
            //            txt_DistrictArea_EmpName.Text = "";
            //            dtp_DistrictArea_Begin.Value = DateTime.Today;
            //            dtp_DistrictArea_End.Value = DateTime.Now;

            //            strWhere = StrWhere_DistrictArea();

            //            #endregion

            //            break;
            //        default:
            //            break;
            //    }

            //    #endregion

            //    Select_Territorial_Emp(1);
            //}
            //else                        //设备
            //{
            //    blIsEmp = false;
            //    label1.Text = "设备：";

            //    #region【获取查询条件】

            //    switch (intSelectModel)
            //    {
            //        case 1:

            //            #region【区域】

            //            txt_Territorial_CodeSenderAddress.Text = "";
            //            txt_Territorial_EmpName.Text = "";
            //            cmb_Dept.SelectedValue = 0;
            //            dtp_Ter_Begin.Value = DateTime.Today;
            //            dtp_Ter_End.Value = DateTime.Now;

            //            strWhere = StrWhere();

            //            #endregion

            //            break;
            //        case 2:

            //            #region【限制区域】

            //            txt_ConfineArea_CodeSenderAddress.Text = "";
            //            txt_ConfineArea_EmpName.Text = "";
            //            dtp_ConfineArea_Begin.Value = DateTime.Today;
            //            dtp_ConfineArea_End.Value = DateTime.Now;

            //            strWhere = StrWhere_ConfineArea();

            //            #endregion

            //            break;
            //        case 3:

            //            #region【重点区域】

            //            txt_KeyArea_CodeSenderAddress.Text = "";
            //            txt_KeyArea_EmpName.Text = "";
            //            dtp_KeyArea_Begin.Value = DateTime.Today;
            //            dtp_KeyArea_End.Value = DateTime.Now;

            //            strWhere = StrWhere_KeyArea();

            //            #endregion

            //            break;
            //        case 4:

            //            #region【地域】

            //            txt_DistrictArea_CodeSenderAddress.Text = "";
            //            txt_DistrictArea_EmpName.Text = "";
            //            dtp_DistrictArea_Begin.Value = DateTime.Today;
            //            dtp_DistrictArea_End.Value = DateTime.Now;

            //            strWhere = StrWhere_DistrictArea();

            //            #endregion

            //            break;
            //        default:
            //            break;
            //    }

            //    #endregion

            //    Select_Territorial_Equ(1);
            //}

        }

        #endregion

       

        #region【事件：选择区域信息——抽屉式菜单】

        private void bt_HisTerritorial_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 1)
            {
                dmc_Info.ButtonClick(pl_HisTerritorial.Name);
                this.AcceptButton = bt_Enquiries;
                dtp_Ter_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_Ter_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "区域";
                intSelectModel = 1;
                LoadComboBox_Dept();

                LoadTree(1);

                //strWhere = StrWhere();

                //if (blIsEmp)                //人员
                //{
                //    Select_Territorial_Emp(1);
                //}
                //else                        //设备
                //{
                //    Select_Territorial_Equ(1);
                //}

                dgv_Main.DataSource = null;

            }
        }

        #endregion



        /*****************************限制区域*****************************/

        #region 【方法: 组织查询条件——限制区域】

        private string StrWhere_ConfineArea()
        {
            TableName = dtp_ConfineArea_Begin.Value.ToString("yyyyM");
            TableName2 = dtp_ConfineArea_End.Value.ToString("yyyyM");
            string strTempWhere = " TerritorialTypeName='限制区域' and InTerritorialTime >= '" + dtp_ConfineArea_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                "' And InTerritorialTime <='" + dtp_ConfineArea_End.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";

            if (tvc_ConfineArea_Dept.SelectedNode != null && !tvc_ConfineArea_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( DeptName = " + GetNodeAllChild(tvc_ConfineArea_Dept.SelectedNode) + " )";
            }

            if (!txt_ConfineArea_EmpName.Text.Trim().Equals(""))
            {
                if (blIsEmp)            //人员
                {
                    strTempWhere += " And UserName like  '%" + txt_ConfineArea_EmpName.Text.Trim() + "%' ";
                }
                else                    //设备
                {
                    strTempWhere += " And UserName like  '%" + txt_ConfineArea_EmpName.Text.Trim() + "%' ";
                }
            }
            if (!txt_ConfineArea_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And CodeSenderAddress = " + txt_ConfineArea_CodeSenderAddress.Text.Trim();
            }


            return strTempWhere;
        }

        #endregion

        #region【事件：选择限制区域信息——抽屉式菜单】

        private void bt_ConfineArea_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 2)
            {
                dmc_Info.ButtonClick(pl_ConfineArea.Name);
                this.AcceptButton = bt_ConfineArea_Enquiries;
                dtp_ConfineArea_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_ConfineArea_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "限制区域";
                intSelectModel = 2;

                LoadTree(2);

                strWhere = StrWhere_ConfineArea();

                //if (blIsEmp)                //人员
                //{
                //    Select_Territorial_Emp(1);
                //}
                //else                        //设备
                //{
                //    Select_Territorial_Equ(1);
                //}
                dgv_Main.DataSource = null;
            }
        }

        #endregion

        #region【事件：查询——限制区域】

        private void bt_ConfineArea_Enquiries_Click(object sender, EventArgs e)
        {
            //先对时间验证
            if (!DecideTime(dtp_ConfineArea_Begin, dtp_ConfineArea_End))
            {
                return;
            }
            strWhere = StrWhere_ConfineArea();
            pictureBox1.Visible = true;
            th = new Thread(BingdingDGV);
            th.Start();
        }

        #endregion

        #region【事件：重置——限制区域】

        private void bt_ConfineArea_Reset_Click(object sender, EventArgs e)
        {
            dtp_ConfineArea_Begin.Value = DateTime.Now.Date;
            dtp_ConfineArea_End.Value = DateTime.Now;
            txt_ConfineArea_CodeSenderAddress.Text = "";
            txt_ConfineArea_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
            lblCounts.Text = "共 0 条记录";
        }

        #endregion

        #region【事件：选择部门——限制区域】

        private void tvc_ConfineArea_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (!DecideTime(dtp_ConfineArea_Begin, dtp_ConfineArea_End))
            //{
            //    return;
            //}

            //strWhere = StrWhere_ConfineArea();
            //if (blIsEmp)            //人员
            //{
            //    Select_Territorial_Emp(1);
            //}
            //else                    //设备
            //{
            //    Select_Territorial_Equ(1);
            //}
        }

        #endregion



        /*****************************重点区域*****************************/

        #region 【方法: 组织查询条件——重点区域】

        private string StrWhere_KeyArea()
        {
            TableName = dtp_KeyArea_Begin.Value.ToString("yyyyM");
            TableName2 = dtp_KeyArea_End.Value.ToString("yyyyM");
            string strTempWhere = " TerritorialTypeName = '重点区域' and InTerritorialTime >= '" + dtp_KeyArea_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                "' And InTerritorialTime <='" + dtp_KeyArea_End.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";

            if (tvc_KeyArea_Dept.SelectedNode != null && !tvc_KeyArea_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( DeptName = " + GetNodeAllChild(tvc_KeyArea_Dept.SelectedNode) + " )";
            }


            if (!txt_KeyArea_EmpName.Text.Trim().Equals(""))
            {
                if (blIsEmp)            //人员
                {
                    strTempWhere += " And UserName like  '%" + txt_KeyArea_EmpName.Text.Trim() + "%' ";
                }
                else                    //设备
                {
                    strTempWhere += " And UserName like  '%" + txt_KeyArea_EmpName.Text.Trim() + "%' ";
                }
            }
            if (!txt_KeyArea_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And CodeSenderAddress = " + txt_KeyArea_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【事件：选择重点区域信息——抽屉式菜单】

        private void bt_KeyArea_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 3)
            {
                dmc_Info.ButtonClick(pl_KeyArea.Name);
                this.AcceptButton = bt_KeyArea_Enquiries;
                dtp_KeyArea_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_KeyArea_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "重点区域";
                intSelectModel = 3;

                LoadTree(3);

                strWhere = StrWhere_KeyArea();

                //if (blIsEmp)                //人员
                //{
                //    Select_Territorial_Emp(1);
                //}
                //else                        //设备
                //{
                //    Select_Territorial_Equ(1);
                //}
                dgv_Main.DataSource = null;
            }
        }

        #endregion

        #region【事件：查询——重点区域】

        private void bt_KeyArea_Enquiries_Click(object sender, EventArgs e)
        {
            //先对时间验证
            if (!DecideTime(dtp_KeyArea_Begin, dtp_KeyArea_End))
            {
                return;
            }
            strWhere = StrWhere_KeyArea();
            pictureBox1.Visible = true;
            th = new Thread(BingdingDGV);
            th.Start();
        }

        #endregion

        #region【事件：重置——重点区域】

        private void bt_KeyArea_Reset_Click(object sender, EventArgs e)
        {
            dtp_KeyArea_Begin.Value = DateTime.Now.Date;
            dtp_KeyArea_End.Value = DateTime.Now;
            txt_KeyArea_CodeSenderAddress.Text = "";
            txt_KeyArea_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
            lblCounts.Text = "共 0 条记录";
        }

        #endregion

        #region【事件：选择部门——重点区域】

        private void tvc_KeyArea_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (!DecideTime(dtp_KeyArea_Begin, dtp_KeyArea_End))
            //{
            //    return;
            //}

            //strWhere = StrWhere_KeyArea();
            //if (blIsEmp)            //人员
            //{
            //    Select_Territorial_Emp(1);
            //}
            //else                    //设备
            //{
            //    Select_Territorial_Equ(1);
            //}
        }

        #endregion


        /*****************************地域*****************************/

        #region 【方法: 组织查询条件——地域】

        private string StrWhere_DistrictArea()
        {
            TableName = dtp_DistrictArea_Begin.Value.ToString("yyyyM");
            TableName2 = dtp_DistrictArea_End.Value.ToString("yyyyM");
            string strTempWhere = " TerritorialTypeName = '地域' and InTerritorialTime >= '" + dtp_DistrictArea_Begin.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                "' And InTerritorialTime <='" + dtp_DistrictArea_End.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";

            if (tvc_DistrictArea_Dept.SelectedNode != null && !tvc_DistrictArea_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( DeptName = " + GetNodeAllChild(tvc_DistrictArea_Dept.SelectedNode) + " )";
            }


            if (!txt_DistrictArea_EmpName.Text.Trim().Equals(""))
            {
                if (blIsEmp)            //人员
                {
                    strTempWhere += " And UserName like  '%" + txt_DistrictArea_EmpName.Text.Trim() + "%' ";
                }
                else                    //设备
                {
                    strTempWhere += " And UserName like  '%" + txt_DistrictArea_EmpName.Text.Trim() + "%' ";
                }
            }
            if (!txt_DistrictArea_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And CodeSenderAddress = " + txt_DistrictArea_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【事件：选择地域信息——抽屉式菜单】

        private void bt_DistrictArea_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 4)
            {
                dmc_Info.ButtonClick(pl_DistrictArea.Name);
                this.AcceptButton = bt_DistrictArea_Enquiries;
                dtp_DistrictArea_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_DistrictArea_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "地域";
                intSelectModel = 4;

                LoadTree(4);

                strWhere = StrWhere_DistrictArea();

                //if (blIsEmp)                //人员
                //{
                //    Select_Territorial_Emp(1);
                //}
                //else                        //设备
                //{
                //    Select_Territorial_Equ(1);
                //}
                dgv_Main.DataSource = null;
            }
        }

        #endregion

        #region【事件：查询——地域】

        private void bt_DistrictArea_Enquiries_Click(object sender, EventArgs e)
        {
            //先对时间验证
            if (!DecideTime(dtp_DistrictArea_Begin, dtp_DistrictArea_End))
            {
                return;
            }
            strWhere = StrWhere_DistrictArea();
            pictureBox1.Visible = true;
            th = new Thread(BingdingDGV);
            th.Start();
        }

        #endregion

        #region【事件：重置——地域】

        private void bt_DistrictArea_Reset_Click(object sender, EventArgs e)
        {
            dtp_DistrictArea_Begin.Value = DateTime.Now.Date;
            dtp_DistrictArea_End.Value = DateTime.Now;
            txt_DistrictArea_CodeSenderAddress.Text = "";
            txt_DistrictArea_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
            lblCounts.Text = "共 0 条记录";
        }

        #endregion

        #region【事件：选择部门——地域】

        private void tvc_DistrictArea_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (!DecideTime(dtp_DistrictArea_Begin, dtp_DistrictArea_End))
            //{
            //    return;
            //}

            //strWhere = StrWhere_DistrictArea();
            //if (blIsEmp)            //人员
            //{
            //    Select_Territorial_Emp(1);
            //}
            //else                    //设备
            //{
            //    Select_Territorial_Equ(1);
            //}
        }

        #endregion

        private IButtonControl IB = null;
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }

        private void txt_Territorial_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_ConfineArea_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_KeyArea_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_DistrictArea_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, GetStrTitle());
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, GetStrTitle(), "");
        }
      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, GetStrTitle(), "");
        }

        #endregion
        private void A_FrmHisTerritorial_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                th.Abort();
            }
            catch { }
        }
    }
}
