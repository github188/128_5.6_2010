using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Shine.Logs;
using Shine.Logs.LogType;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using System.Drawing;

namespace KJ128NMainRun.EmployeeManage
{
    partial class A_FrmEmpInfo
    {

        #region 【方法：初始化职务树（查询）】

        /// <summary>
        /// 初始化职务树
        /// </summary>
        private void LoadWorkType_WorkType()
        {
            if (tvc_WorkType_WorkType.Nodes.Count > 0)
            {
                tvc_WorkType_WorkType.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = dbll.GetWorkType_WorkType();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_WorkType_WorkType.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, 0, "所有", -1, false, false, 0);
                dt.Rows.Add(dr);

                tvc_WorkType_WorkType.DataSouce = dt;
                tvc_WorkType_WorkType.LoadNode("人");
            }

            tvc_WorkType_WorkType.ExpandAll();
            tvc_WorkType_WorkType.SelectedNode = tvc_WorkType_WorkType.Nodes[0];

        }

        #endregion

        #region【方法：查询工种信息】

        private void SelectWorkTypeInfo()
        {

            string strWorkTypeWhere = " 1=1 ";

            using (ds = new DataSet())
            {
                if (tvc_WorkType_WorkType.SelectedNode != null && !tvc_WorkType_WorkType.SelectedNode.Name.Equals("0"))
                {
                    strWorkTypeWhere += " And WorkTypeID = " + tvc_WorkType_WorkType.SelectedNode.Name;
                }

                ds = dbll.SelectWorkTypeInfo(strWorkTypeWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmEmpInfo_WorkType";
                    dgv_Main.DataSource = ds.Tables[0];

                    lb_Counts.Text = "符合筛选条件：共 " + ds.Tables[0].Rows.Count + " 工种";

                    dgv_Main.Columns["WorkTypeID"].Visible = false;
                    dgv_Main.Columns["MaxTimeSec"].Visible = false;
                    dgv_Main.Columns["MinTimeSec"].Visible = false;
                    dgv_Main.Columns["备注"].DisplayIndex = dgv_Main.Columns.Count-1;
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lb_Counts.Text = "符合筛选条件：共 0 工种";
                }
                if (bt_SelectAll.Text.Equals("取消"))
                {
                    bt_SelectAll.Text = "全选";
                }
            }

        }

        #endregion

        #region【方法：刷新——工种】

        public void Refresh_WorkType()
        {
            LoadWorkType_WorkType();        //加载工种信息中的工种树

            //SelectDutyInfo();       //加载职务查询信息
        }

        #endregion


        #region【事件：选择工种信息——抽屉式菜单】

        private void bt_WorkTypeInfo_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 4)
            {
                dmc_Info.ButtonClick(pl_WorkType.Name);


                Refresh_WorkType();

                IsVisiblePage(false);

                intSelectModel = 4;
            }
        }

        #endregion

        #region【事件：工种——工种树单击事件】

        private void tvc_WorkType_WorkType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectWorkTypeInfo();
        }

        #endregion
    }
}
