using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Wilson.Controls.Docking;

namespace KJ128NMainRun
{
    public partial class FrmEmployeeInfo_Select : FromModel.FrmModel
    {
        #region【声明】
        private A_AddEmpBLL aebll = new A_AddEmpBLL();

        /// <summary>
        /// 查询条件
        /// </summary>
        private static string where="";

        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        private DataSet ds;

        private string strParentDeptID;

        #endregion
        #region 【构造函数】
        public FrmEmployeeInfo_Select()
        {
            InitializeComponent();
            cmbSelectCounts.Text = "40";
            LoadDept_Emp();
            this.cmbSelectCounts.Items.Add("全部");
            LoadDuty_Emp();
            LoadWorkType_Emp();
            EmpInfo(1);
        }
        #endregion

        #region 【自定义方法】
        #region 【方法：查询人员信息】
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">所有查询的页数</param>
        public void EmpInfo(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            ds = aebll.GetEmployeeInfo(pIndex, pSize, where);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                ds.Tables[0].TableName = "FrmEmployeeInfo_Select";
                if (sumPage == 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 0 人";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 人";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }
                dgv_Main.Columns["deptid"].Visible = false;
                //Czlt-2012-3-27注销
                //if (dgv_Main.Columns.Count >= 6)
                //{
                //    dgv_Main.Columns["编号"].DisplayIndex = 0;
                //    dgv_Main.Columns["姓名"].DisplayIndex = 1;
                //    dgv_Main.Columns["标示卡号"].DisplayIndex = 2;
                //    dgv_Main.Columns["部门"].DisplayIndex = 3;
                //    dgv_Main.Columns["职务"].DisplayIndex = 4;
                //    dgv_Main.Columns["工种"].DisplayIndex = 5;
                //    dgv_Main.Columns["身份证"].DisplayIndex = 6;  //矿灯号
                //    //dgv_Main.Columns["矿灯号"].DisplayIndex = 6;
                //    dgv_Main.Columns["deptid"].Visible = false;

                //    dgv_Main.Columns["标示卡号"].DefaultCellStyle.NullValue = "——";
                //    dgv_Main.Columns["职务"].DefaultCellStyle.NullValue = "——";
                //    dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";
                //    dgv_Main.Columns["身份证"].DefaultCellStyle.NullValue = "——";
                //    //dgv_Main.Columns["矿灯号"].DefaultCellStyle.NullValue = "——";
                //}
            }
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

        #region 【方法: 遍历节点下的所有子节点】

        /// <summary>
        /// 遍历节点下的所有子节点
        /// </summary>
        /// <param name="tn"></param>
        private string GetNodeAllChild(TreeNode tn)
        {
            string strNodeChildName;

            strNodeChildName = tn.Name.ToString();
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    string strDid = string.Empty;
                    if (n.Nodes.Count > 0)
                    {
                        strDid =GetNodeAllChild(n);
                    }
                    if (!strDid.Equals(""))
                    {
                        strNodeChildName += " or deptid=" + n.Name.ToString() + " or deptid=" + strDid;

                    }
                    else
                    {
                        strNodeChildName += " or deptid=" + n.Name.ToString();
                    }
                }
            }
            return strNodeChildName;
        }
        #endregion

        #region 【方法：组织查询条件】
        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere()
        {
            string strSQL;

            strSQL = " 1=1 ";

            if (tbcEmployee.SelectedTab.Text.Equals("部门"))
            {
                if (tvc_Emp_Dept.SelectedNode != null && !tvc_Emp_Dept.SelectedNode.Tag.ToString().Equals("所有"))
                {
                    //strSQL += " And ( deptid=" + GetNodeAllChild(tvc_Emp_Dept.SelectedNode) + ") ";
                    string strDeptId = GetNodeAllChild(tvc_Emp_Dept.SelectedNode);
                    strSQL += " And ( deptid=" + strDeptId + ") ";

                }
            }
            else if (tbcEmployee.SelectedTab.Text.Equals("职务"))
            {
                if (tvc_Emp_Duty.SelectedNode != null)
                {
                    if (!tvc_Emp_Duty.SelectedNode.Name.ToString().Equals("0") && !tvc_Emp_Duty.SelectedNode.Name.Equals("-2"))
                    {
                        strSQL += " And 职务='" + tvc_Emp_Duty.SelectedNode.Tag.ToString() + "' ";
                    }
                    else if (tvc_Emp_Duty.SelectedNode.Name.Equals("-2"))
                    {
                        strSQL += " And 职务 is null ";
                    }
                }
            }
            else if (tbcEmployee.SelectedTab.Text.Equals("工种"))
            {


                if (tvc_Emp_WorkType.SelectedNode != null)
                {
                    if (!tvc_Emp_WorkType.SelectedNode.Name.Equals("0") && !tvc_Emp_WorkType.SelectedNode.Name.Equals("-2"))
                    {
                        strSQL += " And 工种 = '" + tvc_Emp_WorkType.SelectedNode.Tag.ToString() + "' ";
                    }
                    else if (tvc_Emp_WorkType.SelectedNode.Name.Equals("-2"))
                    {
                        strSQL += " And 工种 is null ";
                    }
                }
            }
            if (txtEmpName_Query.Text.Trim() != "")
            {
                strSQL += " And 姓名 like '%" + txtEmpName_Query.Text.Trim() + "%' ";
            }

            if (txtEmpNo_Query.Text.Trim() != "")
            {
                strSQL += " And 编号 = '" + txtEmpNo_Query.Text.Trim() + "' ";
            }

            if (txtCard_Query.Text.Trim() != "")
            {
                strSQL += " And 标示卡号 = " + txtCard_Query.Text.Trim();
            }

            return strSQL;
        }
        #endregion


        #region 【方法：初始化部门树（查询）】

        /// <summary>
        /// 初始化部门树
        /// </summary>
        private void LoadDept_Emp()
        {
            if (tvc_Emp_Dept.Nodes.Count > 0)
            {
                tvc_Emp_Dept.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = aebll.GetDept_Emp();

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_Emp_Dept.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, 0, "所有", -1, false, true, 0);
                dt.Rows.Add(dr);

                tvc_Emp_Dept.DataSouce = dt;
                tvc_Emp_Dept.LoadNode("人");
            }

            tvc_Emp_Dept.ExpandAll();
            tvc_Emp_Dept.SelectedNode = tvc_Emp_Dept.Nodes[0];

        }

        #endregion

        #region【方法：初始化职务树（查询）】

        private void LoadDuty_Emp()
        {
            if (tvc_Emp_Duty.Nodes.Count > 0)
            {
                tvc_Emp_Duty.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = aebll.GetDuty_Emp();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_Emp_Duty.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, 0, "所有", -1, false, true, 0);
                dt.Rows.Add(dr);

                tvc_Emp_Duty.DataSouce = dt;
                tvc_Emp_Duty.LoadNode("人");
            }
            tvc_Emp_Duty.ExpandAll();
            tvc_Emp_Duty.SelectedNode = tvc_Emp_Duty.Nodes[0];
        }

        #endregion

        #region【方法：初始化工种树（查询）】

        private void LoadWorkType_Emp()
        {
            if (tvc_Emp_WorkType.Nodes.Count > 0)
            {
                tvc_Emp_WorkType.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = aebll.GetWorkType_Emp();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_Emp_WorkType.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, 0, "所有", -1, false, true, 0);
                dt.Rows.Add(dr);

                tvc_Emp_WorkType.DataSouce = dt;
                tvc_Emp_WorkType.LoadNode("人");
            }
            tvc_Emp_WorkType.ExpandAll();
            tvc_Emp_WorkType.SelectedNode = tvc_Emp_WorkType.Nodes[0];
        }

        #endregion

        #region【方法：自定义树的表的行结构】
        private void SetDataRow(ref DataRow dr, int id, string name, int parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }

        #endregion

        #endregion

        #region 【系统事件方法】
        #region 【事件方法：向前翻页】
        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }
            EmpInfo(page);
        }
        #endregion

        #region 【事件方法：向后翻页】
        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (page > countPage)
            {
                return;
            }

            EmpInfo(page);
        }
        #endregion


        #region 【事件方法：页面跳转】
        private void txtSkipPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
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
                        EmpInfo(page);
                    }
                }
                catch (Exception ex)
                { }
            }
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

        #region 【事件方法：选择显示列数】
        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbSelectCounts.Text.Trim() == "全部")
                pSize = 9999999;
            else
                pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);
            EmpInfo(1);
        }
        #endregion

        #region 【事件方法：查询】
        private void btnQuery_Click(object sender, EventArgs e)
        {
            where = StrWhere();
            EmpInfo(1);
        }
        #endregion

        #region 【事件方法：重置查询条件】
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCard_Query.Text = "";
            txtEmpName_Query.Text = "";
            txtEmpNo_Query.Text = "";
            where = "";
            EmpInfo(1);
        }
        #endregion

        private void tvc_Emp_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            where = StrWhere();
            EmpInfo(1);
        }

        #endregion

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            new PrintCore.ExportExcel().Sql_ExportExcel(this.dgv_Main, "员工信息");
        }

        private void txtEmpNo_Query_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtEmpName_Query_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtCard_Query_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region[打印 导出]
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, "人员基本信息");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "人员基本信息", "");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, "人员基本信息", "共 " + dgv_Main.Rows.Count.ToString() + " 个员工");
        }
        #endregion
    }
}
