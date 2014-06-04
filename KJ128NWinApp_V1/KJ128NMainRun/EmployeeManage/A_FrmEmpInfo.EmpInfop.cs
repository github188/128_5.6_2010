using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ZdcCommonLibrary;
using System.Text.RegularExpressions;
using KJ128NModel;
using Shine.Logs.LogType;
using Shine.Logs;
using System.Data;
using System.IO;
using System.Drawing;
using Shine;
using KJ128WindowsLibrary;
using KJ128NDBTable;

namespace KJ128NMainRun.EmployeeManage
{
    partial class A_FrmEmpInfo
    {

        #region【声明】

        private A_TreeBLL tbll = new A_TreeBLL();

        private int intSelectModel_EmpInfo = 1;

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

        #region【方法：加载员工信息（查询）】

        private bool LoadEmpInfo()
        {

            //加载员工查询信息
            where = StrWhere();
            EmpInfo(1);

            return true;
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
                    string stdid = string.Empty;
                    if (n.Nodes.Count > 0)
                    {
                        stdid =GetNodeAllChild(n);
                    }
                    if (stdid.Equals(""))
                    {
                        strNodeChildName += " or DeptID=" + n.Name.ToString();
                    }
                    else
                    {
                        strNodeChildName += " or DeptID=" +stdid;
 
                    }
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
                    bt_UpPage.Enabled = false;
                    bt_DownPage.Enabled = false;
                }
                else
                {
                    bt_UpPage.Enabled = false;
                    bt_DownPage.Enabled = true;
                }
            }
            else if (pIndex >= sumPage)
            {
                bt_UpPage.Enabled = true;
                bt_DownPage.Enabled = false;
            }
            else
            {
                bt_UpPage.Enabled = true;
                bt_DownPage.Enabled = true;
            }
        }

        #endregion

        #region 【方法: 查询信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere()
        {
            string strSQL;

            strSQL = " 1=1 ";

            if (intSelectModel_EmpInfo == 1)
            {
                if (tvc_Emp_Dept.SelectedNode != null && !tvc_Emp_Dept.SelectedNode.Tag.ToString().Equals("所有"))
                {
                    //strSQL += " And ( DeptID = " + GetNodeAllChild(tvc_Emp_Dept.SelectedNode) + ") ";
                    string strDid = GetNodeAllChild(tvc_Emp_Dept.SelectedNode);

                    strSQL += " And ( DeptID = " + strDid + ") ";
                }
            }
            else if (intSelectModel_EmpInfo == 2)
            {


                if (tvc_Emp_Duty.SelectedNode != null)
                {
                    if (!tvc_Emp_Duty.SelectedNode.Name.ToString().Equals("0") && !tvc_Emp_Duty.SelectedNode.Name.Equals("-2"))
                    {
                        strSQL += " And 职务='" + tvc_Emp_Duty.SelectedNode.Tag.ToString() + "' ";
                    }
                    else if (tvc_Emp_Duty.SelectedNode.Name.Equals("-2"))
                    {
                        strSQL += " And (职务 is null or 职务='无')";
                    }
                }
            }
            else if (intSelectModel_EmpInfo == 3)
            {


                if (tvc_Emp_WorkType.SelectedNode != null)
                {
                    if ( !tvc_Emp_WorkType.SelectedNode.Name.Equals("0") && !tvc_Emp_WorkType.SelectedNode.Name.Equals("-2"))
                    {
                        strSQL += " And 工种 = '" + tvc_Emp_WorkType.SelectedNode.Tag.ToString() + "' ";
                    }
                    else if (tvc_Emp_WorkType.SelectedNode.Name.Equals("-2"))
                    {
                        strSQL += " And 工种 is null ";
                    }
                }
            }
            if (txt_EmpName.Text.Trim() != "")
            {
                strSQL += " And 姓名 like '%" + txt_EmpName.Text.Trim() + "%' ";
            }

            if (txt_EmpNO.Text.Trim() != "")
            {
                strSQL += " And 编号 = '" + txt_EmpNO.Text.Trim() + "' ";
            }

            return strSQL;
        }

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
            ds = aebll.GetEmpInfo(pIndex, pSize, where);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;

                if (sumPage == 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    lb_Counts.Text = "共 0 人";

                    lb_PageCounts.Text = "1";
                    lb_SumPage.Text = "/1页";

                    bt_UpPage.Enabled = false;
                    bt_DownPage.Enabled = false;
                }
                else
                {
                    ds.Tables[0].TableName = "A_FrmEmpInfo";
                    dgv_Main.DataSource = ds.Tables[0];

                    lb_Counts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 人";

                    lb_PageCounts.Text = pIndex.ToString();
                    lb_SumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }

                dgv_Main.Columns["EmpID"].Visible = false;
                dgv_Main.Columns["DeptID"].Visible = false;

                //if (dgv_Main.Columns.Count >= 6)
                //{
                //    dgv_Main.Columns["EmpID"].Visible = false;
                //    dgv_Main.Columns["DeptID"].Visible = false;

                //    dgv_Main.Columns["cl"].DisplayIndex = 0;
                //    dgv_Main.Columns["编号"].DisplayIndex = 1;
                //    dgv_Main.Columns["姓名"].DisplayIndex = 2;
                //    dgv_Main.Columns["部门"].DisplayIndex = 3;
                //    dgv_Main.Columns["职务"].DisplayIndex = 4;
                //    dgv_Main.Columns["工种"].DisplayIndex = 5;
                //    //dgv_Main.Columns["矿灯号"].DisplayIndex = 5;
                //    dgv_Main.Columns["身份证"].DisplayIndex = 6;

                //    dgv_Main.Columns["职务"].DefaultCellStyle.NullValue = "——";
                //    dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";
                //    //dgv_Main.Columns["矿灯号"].DefaultCellStyle.NullValue = "——";
                //}
                if (bt_SelectAll.Text.Equals("取消"))
                {
                    bt_SelectAll.Text = "全选";
                }
            }
        }
        #endregion

        #region【方法：刷新——人员】

        public void Refresh_Emp()
        {
            LoadDept_Emp();         //加载部门——员工树

            LoadDuty_Emp();         //加载职务——员工树

            LoadWorkType_Emp();     //加载工种——员工树

            EmpInfo(int.Parse(lb_PageCounts.Text));
        }

        #endregion



        #region【事件：选择人员信息——抽屉式菜单】

        private void bt_EmpInfo_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 1)
            {
                dmc_Info.ButtonClick(pl_Emp.Name);

                IsVisiblePage(true);

                intSelectModel = 1;

                LoadDept_Emp();         //加载部门——员工树

                LoadDuty_Emp();         //加载职务——员工树

                LoadWorkType_Emp();     //加载工种——员工树
                
                //查询
                where = StrWhere();
                EmpInfo(1);
            }
        }

        #endregion

        #region【事件：查询】

        private void bt_Enquiries_Click(object sender, EventArgs e)
        {
            where = StrWhere();
            EmpInfo(1);
        }

        #endregion

        #region【事件：部门树、职务树、工种树——员工点击事件】

        private void tvc_Emp_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            where = StrWhere();
            EmpInfo(1);
        }

        #endregion

        #region【事件：选项卡选择事件(员工查询)】

        private void tbc_Info_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != null)
            {
                if (e.TabPage.Name == "tp_Emp_Dept")       //部门
                {
                    tvc_Emp_Dept.ExpandAll();
                    intSelectModel_EmpInfo = 1;
                }
                else if (e.TabPage.Name == "tp_Emp_Duty")   //职务
                {
                    tvc_Emp_Duty.ExpandAll();
                    intSelectModel_EmpInfo = 2;
                }
                else if (e.TabPage.Name == "tp_Emp_WorkType")    //工种
                {
                    tvc_Emp_WorkType.ExpandAll();
                    intSelectModel_EmpInfo = 3;
                }
                where = StrWhere();
                EmpInfo(1);
            }
        }

        #endregion

        #region【事件：重置(员工查询)】

        private void bt_Reset_Click(object sender, EventArgs e)
        {
            //tbc_Info.SelectedTab = tp_Dept_Dept;
            if (tbc_Info.TabCount > 0)
            {
                tbc_Info.SelectedIndex = 0;
            }
            tvc_Emp_Dept.Visible = true;
            //LoadDept_Emp();
            txt_EmpName.Text = "";
            txt_EmpNO.Text = "";
        }

        #endregion

    }
}
