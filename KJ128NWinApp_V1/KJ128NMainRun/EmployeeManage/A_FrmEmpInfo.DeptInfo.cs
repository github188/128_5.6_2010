
using KJ128NDBTable;
using KJ128NDataBase;
using System.Data;
using System;
using System.Windows.Forms;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128WindowsLibrary;
using System.Drawing;
namespace KJ128NMainRun.EmployeeManage
{
    partial class A_FrmEmpInfo
    {

        #region【声明】

        private A_DeptBLL dbll = new A_DeptBLL();
        private A_AddEmpDAL adal = new A_AddEmpDAL();

        //private DataSet ds;

        #endregion


        #region 【方法：初始化部门树（查询）】

        /// <summary>
        /// 初始化部门树
        /// </summary>
        private void LoadDept_Dept()
        {
            if (tvc_Dept_Dept.Nodes.Count > 0)
            {
                tvc_Dept_Dept.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = dbll.GetDept_Dept();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_Dept_Dept.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, 0, "所有", -1, false, false, 0);
                dt.Rows.Add(dr);

                tvc_Dept_Dept.DataSouce = dt;
                tvc_Dept_Dept.LoadNode("人");
            }

            tvc_Dept_Dept.ExpandAll();
            tvc_Dept_Dept.SelectedNode = tvc_Dept_Dept.Nodes[0];

        }

        #endregion

        #region【方法：查询部门信息】

        private void SelectDeptInfo()
        {

            string strDeptWhere =" 1=1 ";

            using (ds = new DataSet())
            {
                if (tvc_Dept_Dept.SelectedNode != null && !tvc_Dept_Dept.SelectedNode.Name.Equals("0"))
                {
                    strDeptWhere += " And ( DeptID = " + GetNodeAllChild(tvc_Dept_Dept.SelectedNode) + ")";
                }

                ds = dbll.SelectDeptInfo(strDeptWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmEmpInfo_DeptInfo";
                    dgv_Main.DataSource = ds.Tables[0];

                    lb_Counts.Text = "符合筛选条件：共 " + ds.Tables[0].Rows.Count + " 部门";

                    dgv_Main.Columns["DeptID"].Visible = false;

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lb_Counts.Text = "符合筛选条件：共 0 部门";
                }
                if (bt_SelectAll.Text.Equals("取消"))
                {
                    bt_SelectAll.Text = "全选";
                }
            }
            
        }

        #endregion

        #region【方法：刷新——部门】

        public void Refresh_Dept()
        {
            LoadDept_Dept();        //加载部门信息中的部门树

            SelectDeptInfo();       //加载部门查询信息
        }

        #endregion


        #region【事件：选择部门信息——抽屉式菜单】

        private void bt_DeptInfo_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 2)
            {
                dmc_Info.ButtonClick(pl_Dept.Name);

                Refresh_Dept();

                IsVisiblePage(false);

                intSelectModel = 2;
            }
        }

        #endregion

        #region【事件：部门——部门树单击事件】

        private void tvc_Dept_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectDeptInfo();
        }

        #endregion

        #region【方法：是否显示 翻页】

        /// <summary>
        /// 是否显示 翻页
        /// </summary>
        /// <param name="blIsVisible">true:显示；false：隐藏</param>
        private void IsVisiblePage(bool blIsVisible)
        {
            bt_UpPage.Visible = lb_PageCounts.Visible = lb_SumPage.Visible = bt_DownPage.Visible = label6.Visible = txt_SkipPage.Visible = label7.Visible = label8.Visible = cmb_SelectCounts.Visible = label9.Visible = blIsVisible;
        }

        #endregion

    }
}
