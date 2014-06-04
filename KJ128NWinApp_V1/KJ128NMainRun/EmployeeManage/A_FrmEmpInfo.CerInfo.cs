using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Shine.Logs.LogType;
using Shine.Logs;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using System.Drawing;

namespace KJ128NMainRun.EmployeeManage
{
    partial class A_FrmEmpInfo
    {

        #region 【方法：初始化证书树（查询）】

        /// <summary>
        /// 初始化证书树
        /// </summary>
        private void LoadCer_Cer()
        {
            if (tvc_Cer_Cer.Nodes.Count > 0)
            {
                tvc_Cer_Cer.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = dbll.GetCer_Cer();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_Cer_Cer.BuildMenusEntity();
                }

                DataRow dr = dt.NewRow();
                SetDataRow(ref dr, 0, "所有", -1, false, false, 0);
                dt.Rows.Add(dr);

                tvc_Cer_Cer.DataSouce = dt;
                tvc_Cer_Cer.LoadNode("人");
            }

            tvc_Cer_Cer.ExpandAll();
            tvc_Cer_Cer.SelectedNode = tvc_Cer_Cer.Nodes[0];

        }

        #endregion

        #region【方法：查询证书信息】

        private void SelectCerInfo()
        {

            string strCerWhere = " 1=1 ";

            using (ds = new DataSet())
            {
                if (tvc_Cer_Cer.SelectedNode != null && !tvc_Cer_Cer.SelectedNode.Name.Equals("0"))
                {
                    strCerWhere += " And CerTypeID = " + tvc_Cer_Cer.SelectedNode.Name;
                }

                ds = dbll.SelectCerInfo(strCerWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmEmpInfo_CerInfo";
                    dgv_Main.DataSource = ds.Tables[0];

                    lb_Counts.Text = "符合筛选条件：共 " + ds.Tables[0].Rows.Count + " 个证书";

                    dgv_Main.Columns["CerTypeID"].Visible = false;

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lb_Counts.Text = "符合筛选条件：共 0 个证书";
                }
                if (bt_SelectAll.Text.Equals("取消"))
                {
                    bt_SelectAll.Text = "全选";
                }
            }

        }

        #endregion

        #region【方法：刷新——证书】

        public void Refresh_Cer()
        {
            LoadCer_Cer();        //加载证书信息中的证书树

            SelectCerInfo();       //加载证书查询信息
        }

        #endregion



        #region【事件：选择证书信息——抽屉式菜单】

        private void bt_CerInfo_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 5)
            {
                dmc_Info.ButtonClick(pl_Cer.Name);

                IsVisiblePage(false);

                intSelectModel = 5;

                //刷新
                Refresh_Cer();
            }
        }

        #endregion

        #region【事件：职务——职务树单击事件】

        private void tvc_Cer_Cer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectCerInfo(); 
        }

        #endregion
    }
}
