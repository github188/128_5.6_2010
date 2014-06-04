using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using Shine.Logs;
using Shine.Logs.LogType;
using System.Drawing;

namespace KJ128NMainRun.EmployeeManage
{
    partial class A_FrmEmpInfo
    {
        
        #region【方法：刷新——职务】

        public void Refresh_Duty()
        {
            LoadDuty_Duty();        //加载职务信息中的职务树

            SelectDutyInfo();       //加载职务查询信息
        }

        #endregion

        #region【方法：查询职务信息】

        private void SelectDutyInfo()
        {

            string strDutyWhere = " 1=1 ";

            using (ds = new DataSet())
            {
                if (tvc_Duty_Duty.SelectedNode != null && !tvc_Duty_Duty.SelectedNode.Name.Equals("0"))
                {
                    strDutyWhere += " And DutyID = " + tvc_Duty_Duty.SelectedNode.Name ;
                }

                ds = dbll.SelectDutyInfo(strDutyWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmEmpInfo_DutyInfo";
                    dgv_Main.DataSource = ds.Tables[0];

                    lb_Counts.Text = "符合筛选条件：共 " + ds.Tables[0].Rows.Count + " 职务";

                    dgv_Main.Columns["DutyID"].Visible = false;

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lb_Counts.Text = "符合筛选条件：共 0 职务";
                }
                if (bt_SelectAll.Text.Equals("取消"))
                {
                    bt_SelectAll.Text = "全选";
                }
            }

        }

        #endregion

        #region 【方法：初始化职务树（查询）】

        /// <summary>
        /// 初始化职务树
        /// </summary>
        private void LoadDuty_Duty()
        {
            if (tvc_Duty_Duty.Nodes.Count > 0)
            {
                tvc_Duty_Duty.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = dbll.GetDuty_Duty();
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

                tvc_Duty_Duty.DataSouce = dt;
                tvc_Duty_Duty.LoadNode("人");
            }

            tvc_Duty_Duty.ExpandAll();
            tvc_Duty_Duty.SelectedNode = tvc_Duty_Duty.Nodes[0];

        }

        #endregion



        #region【事件：选择职务信息——抽屉式菜单】

        private void bt_DutyInfo_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 3)
            {
                dmc_Info.ButtonClick(pl_Duty.Name);

                Refresh_Duty();

                IsVisiblePage(false);

                intSelectModel = 3;
            }
        }

        #endregion

        #region【事件：职务——职务树单击事件】

        private void tvc_Duty_Duty_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectDutyInfo(); 
        }

        #endregion

    }
}
