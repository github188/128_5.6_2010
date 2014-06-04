using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm
    {
        #region 【自定义参数】
        private AssociateBLL associateBll = new AssociateBLL();
        private string strWhere_Associate = " 1=1 ";
        #endregion

        #region 【自定义方法】
        #region 【方法：绑定分站树信息】
        /// <summary>
        /// 绑定分站树信息
        /// </summary>
        private void LoadStationTree()
        {
            DataTable dt = associateBll.GetStationTree();
            treeViewControlStation.DataSouce = dt;
            treeViewControlStation.LoadNode("");

            treeViewControlStation.ExpandAll();
        }
        #endregion

        #region 【方法：刷新异地交接班报警信息】
        private void Refresh_Associate()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_Associate(strWhere_Associate);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_Associate";
                    dgv_Main.DataSource = ds.Tables[0];

                    if (dgv_Main.Columns.Count >= 5)
                    {
                        dgv_Main.Columns["开始时间"].DisplayIndex = 0;
                        dgv_Main.Columns["结束时间"].DisplayIndex = 1;
                        dgv_Main.Columns["传输分站号"].DisplayIndex = 2;
                        dgv_Main.Columns["读卡分站号"].DisplayIndex = 3;
                        dgv_Main.Columns["交接地点"].DisplayIndex = 4;
                        dgv_Main.Columns["人员姓名1"].DisplayIndex = 5;
                        dgv_Main.Columns["人员1交接状态"].DisplayIndex = 6;
                        dgv_Main.Columns["人员姓名2"].DisplayIndex = 7;
                        dgv_Main.Columns["人员2交接状态"].DisplayIndex = 8;

                        dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgv_Main.Columns["结束时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                }
            }
        }
        #endregion

        #region 【方法：重置查询条件】
        /// <summary>
        /// 重置查询条件
        /// </summary>
        private void ResetSceal_Associate()
        {
            txtEmpName1.Text = "";
            txtEmpName2.Text = "";
        }
        #endregion

        #region 【方法：获取查询条件】
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetScaelSql_Associate()
        {
            strWhere_Associate = "";
            //员工1的姓名
            if (!txtEmpName1.Text.Trim().Equals(""))
            {
                strWhere_Associate = " empName1 like '%" + txtEmpName1.Text + "%' ";
            }
            if (!txtEmpName2.Text.Trim().Equals(""))
            {
                if (!strWhere_Associate.Equals(""))
                {
                    strWhere_Associate += " and ";
                }
                strWhere_Associate += " empName2 like '%" + txtEmpName2.Text + "%' ";
            }
            if (treeViewControlStation.SelectedNode != null)
            {
                if (treeViewControlStation.SelectedNode.Level > 0)
                {
                    if (!strWhere_Associate.Equals(""))
                    {
                        strWhere_Associate += " and ";
                    }
                    if (treeViewControlStation.SelectedNode.Level == 1)
                    {
                        strWhere_Associate += "stationAddress=" + treeViewControlStation.SelectedNode.Name.Substring(1);
                    }
                    else
                    {
                        strWhere_Associate += "stationAddress=" + treeViewControlStation.SelectedNode.Parent.Name.Substring(1);
                    }
                }
                if (treeViewControlStation.SelectedNode.Level > 1)
                {
                    if (!strWhere_Associate.Equals(""))
                    {
                        strWhere_Associate += " and ";
                    }
                    strWhere_Associate += " stationHeadAddress=" + treeViewControlStation.SelectedNode.Name.Substring(1);
                }
            }
            if (strWhere_Associate.Equals(""))
            {
                strWhere_Associate = " 1=1 ";
            }
        }

        #endregion

        #endregion

        #region 【系统事件方法】
        #region 【事件方法：抽屉菜单按钮】
        private void btnAssociate_Click(object sender, EventArgs e)
        {
            lblMainTitle.Text = "异地交接班异常报警";
            intSelectModel = 13;

            if (dmc_Info.ButtonClick(pnlAssociate.Name))
            {
                this.AcceptButton = btnSecalAssociate;
                LoadStationTree();
                strWhere_Associate = " 1=1 ";
                GetScaelSql_Associate();
                //刷新界面
                Refresh_Associate();

                IsShowRescue(false);
            }
        }
        #endregion

        #region 【事件方法：按条件查询】
        private void btnSecalAssociate_Click(object sender, EventArgs e)
        {
            //获取查询条件
            GetScaelSql_Associate();
            //刷新
            Refresh_Associate();
        }
        #endregion

        #region 【事件方法：重置条件】
        private void btnResetAssociate_Click(object sender, EventArgs e)
        {
            //重置查询条件
            ResetSceal_Associate();
            //获取查询条件
            GetScaelSql_Associate();
            //刷新
            Refresh_Associate();
        }
        #endregion

        #region 【事件方法：树点击后查询】
        private void treeViewControlStation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //获取查询条件
            GetScaelSql_Associate();
            //刷新
            Refresh_Associate();
        }
        #endregion
        #endregion
    }
}
