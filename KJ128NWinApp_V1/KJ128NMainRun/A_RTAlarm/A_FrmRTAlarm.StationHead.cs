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

        private string strWhere_StationHead = " 1= 1";

        #endregion



        #region【方法：刷新——实时读卡分站故障信息】

        private void Refresh_StationHead()
        {
            LoadTree(3);                //加载读卡分站树

            Select_StationHead();           //查询实时读卡分站报警信息 
        }

        #endregion

        #region【方法：组织查询条件——实时读卡分站】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_StationHead()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_StationHead.SelectedNode != null && !tvc_StationHead.SelectedNode.Name.Equals("0"))
            {
                if (tvc_StationHead.SelectedNode.Name.Substring(0, 1).Equals("S"))
                {
                    strTempWhere += " And 传输分站编号 = " + tvc_StationHead.SelectedNode.Name.Substring(1);
                }
                else if (tvc_StationHead.SelectedNode.Name.Substring(0,1).Equals("H"))
                {
                    strTempWhere += " And 读卡分站编号 = " + tvc_StationHead.SelectedNode.Name.Substring(1) + " And 传输分站编号 = " + tvc_StationHead.SelectedNode.Parent.Name.Substring(1);
                }
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询——实时读卡分站故障信息】

        private void Select_StationHead()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_StationHead(strWhere_StationHead);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_StationHead";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    dgv_Main.Columns["故障开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (dgv_Main.Columns.Count >= 8)
                    {
                        dgv_Main.Columns["传输分站编号"].DisplayIndex = 0;
                        dgv_Main.Columns["传输分站位置"].DisplayIndex = 1;
                        dgv_Main.Columns["读卡分站编号"].DisplayIndex = 2;
                        dgv_Main.Columns["读卡分站位置"].DisplayIndex = 3;
                        dgv_Main.Columns["分站联系电话"].DisplayIndex = 4;
                        dgv_Main.Columns["分站类型"].DisplayIndex = 5;
                        dgv_Main.Columns["故障类型"].DisplayIndex = 6;
                        dgv_Main.Columns["故障开始时间"].DisplayIndex = 7;
                    }

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                }
            }

        }

        #endregion


        #region【事件：选择实时读卡分站故障报警信息——抽屉式菜单】

        private void bt_StationHead_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_StationHead.Name);

            tvc_StationHead.Nodes.Clear();

            //刷新
            Refresh_StationHead();
            tvc_StationHead.ExpandAll();

            lblMainTitle.Text = "读卡分站故障报警";
            intSelectModel = 7;
            strWhere_StationHead = " 1= 1";

            IsShowRescue(false);

            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[6]);
        }

        #endregion

        #region【事件：读卡分站树点击事件——实时读卡分站故障报警】

        private void tvc_StationHead_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere_StationHead = StrWhere_StationHead();
            Select_StationHead();
        }

        #endregion


    }
}
