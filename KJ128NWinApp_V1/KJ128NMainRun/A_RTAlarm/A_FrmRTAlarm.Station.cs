using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm
    {
        #region【声明】

        private string strWhere_Station = " 1= 1";

        #endregion

        #region【方法：刷新——实时传输分站故障信息】

        private void Refresh_Station()
        {
            LoadTree(2);                //加载传输分站树

            Select_Station();           //查询实时传输分站报警信息 
        }

        #endregion

        #region【方法：组织查询条件——实时传输分站】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_Station()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_Station.SelectedNode != null && !tvc_Station.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And StationAddress = " + tvc_Station.SelectedNode.Name;
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询——实时传输分站故障信息】

        private void Select_Station()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_Station(strWhere_Station);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_Station";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    dgv_Main.Columns["故障开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    //Czlt-2012-3-28 注销
                    //if (dgv_Main.Columns.Count >= 4)
                    //{
                    //    dgv_Main.Columns["分站编号"].DisplayIndex = 0;
                    //    dgv_Main.Columns["分站位置"].DisplayIndex = 1;
                    //    dgv_Main.Columns["分站联系电话"].DisplayIndex = 2;
                    //    dgv_Main.Columns["故障开始时间"].DisplayIndex = 3;
                    //}
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                }
            }

        }

        #endregion


        #region【事件：选择实时传输分站故障报警信息——抽屉式菜单】

        private void bt_Station_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_Station.Name);

            tvc_Station.Nodes.Clear();

            //刷新
            Refresh_Station();

            tvc_Station.ExpandAll();

            lblMainTitle.Text = "传输分站故障报警";
            intSelectModel = 6;
            strWhere_Station = " 1= 1";

            IsShowRescue(false);

            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[5]);
        }

        #endregion

        #region【事件：传输分站树点击事件——实时传输分站故障报警】

        private void tvc_Station_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere_Station = StrWhere_Station();
            Select_Station();
        }

        #endregion

    }
}
