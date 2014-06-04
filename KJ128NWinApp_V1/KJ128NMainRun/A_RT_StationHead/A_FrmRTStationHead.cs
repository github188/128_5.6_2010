using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Wilson.Controls.Docking;

namespace KJ128NMainRun.A_RT_StationHead
{
    public partial class A_FrmRTStationHead : FromModel.FrmModel
    {

        #region【声明】

        private A_TreeBLL tbll = new A_TreeBLL();

        private A_RTStationHeadBLL rtsbll = new A_RTStationHeadBLL();

        private bool blIsRefreshTree = true;

        private DataSet ds;

        private string strWhere = " StationHeadTypeID=32 ";

        public bool isEnableTime = false;   //是否启用时间查询

        public DateTime dtBeginTime; //开始时间

        public DateTime dtEndTime;   //结束时间


        //czlt-2010-9-16*start*****
        SortOrder sortDirection = new SortOrder();
        private int index = 0;
        private bool isHearderSort = false;
        private bool isClickSort;
        ListSortDirection listSort;
        //czlt-2010-9-16*end*****



        #endregion

        #region【构造函数】
        DockPanel dockPanel = null;
        public A_FrmRTStationHead(DockPanel dock)
        {
            InitializeComponent();
            dockPanel = dock;
        }

        #endregion

        #region【加载窗体】

        private void A_FrmRTStationHead_Load(object sender, EventArgs e)
        {
            listSort = new ListSortDirection();
            isClickSort = false;
            LoadTree(1);
            tvc_Dept.ExpandAll();
            strWhere = StrWhere_Emp();
        }

        #endregion


        #region【方法：加载树】
        /// <summary>
        /// 加载树
        /// </summary>
        /// <param name="intModel">1:部门树(人员)，2：部门树(设备)，3：分站树(人员)，4：分站树(设备)</param>
        private void LoadTree(int intModel)
        {
            blIsRefreshTree = false;


            switch (intModel)
            {
                case 1:

                    #region【部门树(人员)】

                    using (ds = new DataSet())
                    {
                        ds = rtsbll.GetDeptTree_Emp(cb_Show.Checked);
                        tbll.LoadTree(tvc_Dept, ds, "", false, "所有");

                    }

                    #endregion

                    break;
                case 2:

                    #region【部门树(设备)】

                    using (ds = new DataSet())
                    {
                        ds = rtsbll.GetDeptTree_Emp(cb_Show.Checked);
                        tbll.LoadTree(tvc_Dept, ds, "", false, "所有");

                    }

                    #endregion

                    break;
                case 3:

                    #region【分站树(人员)】

                    using (ds = new DataSet())
                    {
                        ds = rtsbll.GetStaHeadTree_Emp(cb_Show.Checked);

                        tbll.LoadTree(tvc_StationHead, ds, "人", false, "所有");
                    }

                    #endregion

                    break;
                case 4:

                    #region【分站树(设备)】

                    using (ds = new DataSet())
                    {
                        ds = rtsbll.GetStaHeadTree_Emp(cb_Show.Checked);

                        tbll.LoadTree(tvc_StationHead, ds, "人", false, "所有");
                    }

                    #endregion

                    break;
                default:
                    break;
            }

            blIsRefreshTree = true;
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
                    string strD = string.Empty;

                    if (n.Nodes.Count > 0)
                    {
                        strD = GetNodeAllChild(n);
                    }
                    if (!strD.Equals(""))
                    {
                        strNodeChildName += " or 部门= "+strD;
                    }
                    else
                    {
                        strNodeChildName += " or 部门= '" + n.Tag.ToString() + "' ";
                    }
                }
            }
            return strNodeChildName;
        }
        #endregion

        #region【方法：刷新】

        private void RT_StationHead_RefResh()
        { 
            Select_StationHead_Emp();
        }

        #endregion

        #region【方法：组织查询条件】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_Emp()
        {
            string strTempWhere = " 1=1 ";
            if (tbc.SelectedTab != null)
            {
                if (tbc.SelectedTab.Name.Equals("tbp_Dept"))        //部门
                {
                    if (tvc_Dept.SelectedNode != null && !tvc_Dept.SelectedNode.Name.Equals("0"))
                    {
                        //strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_Dept.SelectedNode) + " )";
                        string strDeptId = GetNodeAllChild(tvc_Dept.SelectedNode);
                        strTempWhere += " And ( 部门 = " + strDeptId + " )";
                    }
                }
                else if (tbc.SelectedTab.Name.Equals("tbp_StationHead"))    //分站
                {
                    if (tvc_StationHead.SelectedNode != null && !tvc_StationHead.SelectedNode.Name.Equals("0"))
                    {
                        if (tvc_StationHead.SelectedNode.Name.Substring(0, 1).Equals("S"))     //传输分站  
                        {
                            strTempWhere += " And  传输分站编号 = " + tvc_StationHead.SelectedNode.Name.Substring(1);
                        }
                        else if (tvc_StationHead.SelectedNode.Name.Substring(0, 1).Equals("H"))
                        {
                            strTempWhere += " And  读卡分站编号 = " + tvc_StationHead.SelectedNode.Name.Substring(1) + " And 传输分站编号 = " + tvc_StationHead.SelectedNode.Parent.Name.Substring(1);
                        }
                    }
                }
            }

            if (!txt_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like '%" + txt_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_CodeSenderAddress.Text.Trim();
            }

            //if (isEnableTime)
            //{
            //    strTempWhere += " And 监测时间>='" + dtBeginTime.ToString("yyyy-MM-dd HH:mm:ss") + "' And 监测时间<='" + dtEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'"; 
            //}            

            if (rb_Emp.Checked)
            {
                strTempWhere += " and cstypeid=0";
            }
            if (rb_Equ.Checked)
            {
                strTempWhere += " and cstypeid=1";
            }
            if (rbtNoSet.Checked)
            {
                strTempWhere += " and cstypeid is null";
            }

            if (!cb_Show.Checked)
            {
                strTempWhere += " And StationHeadTypeID=32";
            }
            else
            {
                if (shineTextBox1.Text.Trim().Equals(""))
                {
                    shineTextBox1.Text = "3";
                }
                strTempWhere += " And StationHeadTypeID=32 or (" + strTempWhere + " and StationHeadTypeid=8 and 监测时间 > dateadd(minute,-" + shineTextBox1.Text + ",getdate()))";
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询实时读卡分站——人员】

        private void Select_StationHead_Emp()
        {
            try
            {
                using (ds = new DataSet())
                {
                    ds = rtsbll.Select_StationHead_Emp(strWhere);

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        ds.Tables[0].TableName = "A_RrmRTStationHead";
                        dgv_Main.DataSource = ds.Tables[0];

                        lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个记录";                        
                        //lblMainTitle.Text = "实时读卡分站：  共 " + ds.Tables[1].Rows.Count + " 人";

                        if (dgv_Main.Columns.Count >= 11)
                        {
                            dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                            dgv_Main.Columns["姓名"].DisplayIndex = 1;
                            dgv_Main.Columns["部门"].DisplayIndex = 2;
                            dgv_Main.Columns["职务"].DisplayIndex = 3;
                            dgv_Main.Columns["工种"].DisplayIndex = 4;
                            dgv_Main.Columns["分站编号"].DisplayIndex = 5;
                            //dgv_Main.Columns["读卡分站编号"].DisplayIndex = 4;
                            dgv_Main.Columns["读卡分站位置"].DisplayIndex = 6;
                            dgv_Main.Columns["监测时间"].DisplayIndex = 7;
                            dgv_Main.Columns["进出状态"].DisplayIndex = 8;
                            dgv_Main.Columns["方向性"].DisplayIndex = 9;
                            dgv_Main.Columns["cstypeid"].Visible = false;

                            dgv_Main.Columns["职务"].DefaultCellStyle.NullValue = "——";
                            dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";

                            dgv_Main.Columns["监测时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                            dgv_Main.Columns["传输分站编号"].Visible = false;
                            dgv_Main.Columns["读卡分站编号"].Visible = false;
                            dgv_Main.Columns["DeptID"].Visible = false;
                            dgv_Main.Columns["StationHeadTypeID"].Visible = false;
                            if (dgv_Main.Columns.Contains("serialno"))
                            {
                                dgv_Main.Columns["serialno"].Visible = false;
                            }
                        }

                    }
                    else
                    {
                        dgv_Main.DataSource = null;
                        lblCounts.Text = "共 0 个记录";
                        //lblMainTitle.Text = "实时读卡分站：  共 0 人";
                    }


                    //****czlt-2010-9-16**start****
                    if (isHearderSort == true)
                    {
                        DataGridViewColumn newColumn = dgv_Main.Columns[index];

                        dgv_Main.Sort(newColumn, listSort);
                    }
                    //****czlt-2010-9-16**end****

                }

            }
            catch
            {
                dgv_Main.DataSource = null;
                lblCounts.Text = "共 0 个记录";
            }
        }

        #endregion


        #region【方法：组织查询条件——设备】

        /// <summary>
        /// 组织查询条件(设备)
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_Equ()
        {
            string strTempWhere = " 1=1 ";
            if (tbc.SelectedTab != null)
            {
                if (tbc.SelectedTab.Name.Equals("tbp_Dept"))        //部门
                {
                    if (tvc_Dept.SelectedNode != null && !tvc_Dept.SelectedNode.Name.Equals("0"))
                    {
                        strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_Dept.SelectedNode) + " )";
                    }
                }
                else if (tbc.SelectedTab.Name.Equals("tbp_StationHead"))    //分站
                {
                    if (tvc_StationHead.SelectedNode != null && !tvc_StationHead.SelectedNode.Name.Equals("0"))
                    {
                        if (tvc_StationHead.SelectedNode.Name.Substring(0, 1).Equals("S"))     //传输分站  
                        {
                            strTempWhere += " And  传输分站编号 = " + tvc_StationHead.SelectedNode.Name.Substring(1);
                        }
                        else if (tvc_StationHead.SelectedNode.Name.Substring(0, 1).Equals("H"))
                        {
                            strTempWhere += " And  读卡分站编号 = " + tvc_StationHead.SelectedNode.Name.Substring(1) + " And 传输分站编号 = " + tvc_StationHead.SelectedNode.Parent.Name.Substring(1);
                        }
                    }
                }
            }

            if (!txt_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 设备名称 like '%" + txt_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_CodeSenderAddress.Text.Trim();
            }

            if (isEnableTime)
            {
                strTempWhere += " And 进入时间>='" + dtBeginTime.ToString("yyyy-MM-dd HH:mm:ss") + "' And 进入时间<='" + dtEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            if (!cb_Show.Checked)
            {
                strTempWhere += " And StationHeadTypeID=32";
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询实时读卡分站——设备】

        private void Select_StationHead_Equ()
        {
            using (ds = new DataSet())
            {
                ds = rtsbll.Select_StationHead_Equ(strWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个记录";
                    //lblMainTitle.Text = "实时读卡分站：  共 " + ds.Tables[1].Rows.Count + " 台";

                    if (dgv_Main.Columns.Count >= 10)
                    {

                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["设备编号"].DisplayIndex = 1;
                        dgv_Main.Columns["设备名称"].DisplayIndex = 2;
                        dgv_Main.Columns["部门"].DisplayIndex = 3;
                        dgv_Main.Columns["传输分站编号"].DisplayIndex = 4;
                        dgv_Main.Columns["读卡分站编号"].DisplayIndex = 5;
                        dgv_Main.Columns["读卡分站位置"].DisplayIndex = 6;
                        dgv_Main.Columns["监测时间"].DisplayIndex = 7;
                        dgv_Main.Columns["进出状态"].DisplayIndex = 8;

                        dgv_Main.Columns["监测时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        dgv_Main.Columns["DeptID"].Visible = false;
                        dgv_Main.Columns["StationHeadTypeID"].Visible = false;
                    }

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个记录";
                    lblMainTitle.Text = "实时读卡分站：  共 0 台";
                }
            }

        }

        #endregion


        #region【事件：选项卡选择事件】

        private void tbc_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != null)
            {
                if (e.TabPage.Name == "tbp_Dept")       //部门
                {
                    tvc_Dept.Nodes.Clear();

                    if (rb_Emp.Checked)     //人员
                    {
                        LoadTree(1);
                    }
                    else                    //设备
                    {
                        LoadTree(2);
                    }
                    tvc_Dept.ExpandAll();
                }
                else if (e.TabPage.Name == "tbp_StationHead")   //职务
                {
                    tvc_StationHead.Nodes.Clear();

                    if (rb_Emp.Checked)     //人员
                    {
                        LoadTree(3);
                    }
                    else                    //设备
                    {
                        LoadTree(4);
                    }
                    tvc_StationHead.ExpandAll();
                }
            }
        }

        #endregion

        #region【事件：选择人员、设备】

        private void rb_Emp_CheckedChanged(object sender, EventArgs e)
        {


            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            strWhere = StrWhere_Emp();
            Select_StationHead_Emp();
        }

        private void rb_Equ_CheckedChanged(object sender, EventArgs e)
        {

            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            strWhere = StrWhere_Emp();
            Select_StationHead_Emp();
        }

        private void rbtNoSet_CheckedChanged(object sender, EventArgs e)
        {

            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            strWhere = StrWhere_Emp();
            Select_StationHead_Emp();
        }

        private void rbtAll_CheckedChanged(object sender, EventArgs e)
        {

            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            strWhere = StrWhere_Emp();
            Select_StationHead_Emp();
        }
        #endregion

        #region【事件：查询】

        private void bt_EmpOverTime_Enquiries_Click(object sender, EventArgs e)
        {
            //if (rb_Emp.Checked)     //人员
            //{
            //    strWhere = StrWhere_Emp();
            //    Select_StationHead_Emp();
            //}
            //else                 //设备
            //{
            //    strWhere = StrWhere_Equ();
            //    Select_StationHead_Equ();
            //}


            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            strWhere = StrWhere_Emp();
            Select_StationHead_Emp();
        }

        #endregion

        #region【事件：重置】

        private void bt_EmpOverTime_Reset_Click(object sender, EventArgs e)
        {
            txt_CodeSenderAddress.Text = "";
            txt_EmpName.Text = "";

            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            strWhere = StrWhere_Emp();
            Select_StationHead_Emp();



        }

        #endregion

        #region【事件：定时器】
        private void timer_Alarm_Tick(object sender, EventArgs e)
        {
            //qyz 修改获得焦点刷新
            if (this.IsActivated || this.DockHandler == dockPanel.ActiveDocument.DockHandler)
            {
                if (cb.Checked)
                {
                    RT_StationHead_RefResh();
                   
                }
            }
        }

        #endregion

        #region【事件：选择部门树】

        private void tvc_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (rb_Emp.Checked)     //人员
            //{
            //    strWhere = StrWhere_Emp();
            //    Select_StationHead_Emp();
            //}
            //else                    //设备
            //{
            //    strWhere = StrWhere_Equ();
            //    Select_StationHead_Equ();
            //}
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            strWhere = StrWhere_Emp();
            Select_StationHead_Emp();
        }

        #endregion

        #region【事件：选择分站树】

        private void tvc_StationHead_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (rb_Emp.Checked)     //人员
            //{
            //    strWhere = StrWhere_Emp();
            //    Select_StationHead_Emp();
            //}
            //else                    //设备
            //{
            //    strWhere = StrWhere_Equ();
            //    Select_StationHead_Equ();
            //}
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            strWhere = StrWhere_Emp();
            Select_StationHead_Emp();
        }

        #endregion

       

        #region【事件：设置】

        private void bt_Set_Click(object sender, EventArgs e)
        {

            A_FrmRTStationHead_Set frm = new A_FrmRTStationHead_Set(this);
            frm.ShowDialog();
        }

        #endregion

        #region【事件：是否显示上井口信息】

        private void cb_Show_CheckedChanged(object sender, EventArgs e)
        {
            //if(rb_Emp.Checked)
            //{
            //    strWhere = StrWhere_Emp();
            //}
            //else
            //{
            //    strWhere = StrWhere_Equ();
            //}
            strWhere = StrWhere_Emp();
            RT_StationHead_RefResh();
        }

        #endregion

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        public void Flash()
        {
            strWhere = StrWhere_Emp();
            Select_StationHead_Emp();
        }

        private void dgv_Main_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgv.Columns.Count > 0)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dgv.Columns[i].DefaultCellStyle.NullValue = "——";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void A_FrmRTStationHead_Shown(object sender, EventArgs e)
        {
            Select_StationHead_Emp();
        }

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

        #region Czlt-2010-9-16***点击表头信息****
        /// <summary>
        /// 点击列表头信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (index != e.ColumnIndex)
            {
                index = e.ColumnIndex;
                isClickSort = false;
            }
            if (isClickSort == false)
            {
                listSort = ListSortDirection.Ascending;
                isClickSort = true;
            }
            else if (isClickSort == true)
            {
                listSort = ListSortDirection.Descending;
                isClickSort = false;
            }
            isHearderSort = true;
        }
        #endregion

        private void txt_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, "实时标识卡信息", "统计时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "实时标识卡信息", "统计时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, "实时标识卡信息", "统计时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        #endregion

    }
}
