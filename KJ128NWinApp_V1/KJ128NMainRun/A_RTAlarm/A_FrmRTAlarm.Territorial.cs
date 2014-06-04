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

        private string strWhere_Territorial = " 1 = 1";

        #endregion

        #region【方法：刷新——实时区域】

        private void Refresh_Territorial()
        {
            LoadTree(4);        //加载区域树

            Select_Territorial();           //查询实时区域报警信息 
        }

        #endregion

        #region【方法：组织查询条件——实时超时】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_Territorial()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_Territorial.SelectedNode != null && !tvc_Territorial.SelectedNode.Name.Equals("0"))
            {
                if (tvc_Territorial.SelectedNode.Name.Substring(0, 1).Equals("T"))  //区域类型
                {
                    strTempWhere += " And 区域类型 = '" + tvc_Territorial.SelectedNode.Tag.ToString() + "' ";
                }
                else if (tvc_Territorial.SelectedNode.Name.Substring(0,1).Equals("I"))  //区域名称
                {
                    strTempWhere += " And 区域名称 = '" + tvc_Territorial.SelectedNode.Tag.ToString() + "' "; 
                }
            }

            if (!txt_Territorial_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like '%" + txt_Territorial_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_Territorial_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_Territorial_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询——实时区域报警信息】

        private void Select_Territorial()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_Territorial(strWhere_Territorial);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_Territorial";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    //lblMainTitle.Text = "区域报警：  共 " + ds.Tables[1].Rows.Count + " 人";
                    dgv_Main.Columns["TerritorialTypeID"].Visible = false;
                    dgv_Main.Columns["TerritorialID"].Visible = false;
                    dgv_Main.Columns["进入区域时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (dgv_Main.Columns.Count >= 7)
                    {
                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["姓名"].DisplayIndex = 1;
                        dgv_Main.Columns["工种"].DisplayIndex = 2;
                        dgv_Main.Columns["区域类型"].DisplayIndex = 3;
                        dgv_Main.Columns["区域名称"].DisplayIndex = 4;
                        dgv_Main.Columns["进入区域时间"].DisplayIndex = 5;
                        dgv_Main.Columns["滞留时长"].DisplayIndex = 6;
                        dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";
                    }

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                    //lblMainTitle.Text = "区域报警：  共 0 人";
                }
            }

        }

        #endregion


        #region【事件：选择实时超员报警信息——抽屉式菜单】

        private void bt_Territorial_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_Territorial.Name);
            this.AcceptButton = bt_Territorial_Enquiries;
            tvc_Territorial.Nodes.Clear();

            //刷新
            Refresh_Territorial();

            tvc_Territorial.ExpandAll();

            lblMainTitle.Text = "区域报警";
            intSelectModel = 3;
            strWhere_Territorial = " 1 = 1";

            IsShowRescue(false);

            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[2]);
        }

        #endregion

        #region【事件：部门树点击事件——实时超时报警】

        private void tvc_Territorial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere_Territorial = StrWhere_Territorial();
            Select_Territorial();
        }

        #endregion

        #region【事件：查询——实时区域报警信息】

        private void bt_Territorial_Enquiries_Click(object sender, EventArgs e)
        {
            strWhere_Territorial = StrWhere_Territorial();
            Select_Territorial();
        }

        #endregion

        #region【事件：重置——实时区域报警信息】

        private void bt_Territorial_Reset_Click(object sender, EventArgs e)
        {
            txt_Territorial_CodeSenderAddress.Text = txt_Territorial_EmpName.Text = "";
            if (tvc_Territorial.Nodes.Count > 0)
            {
                tvc_Territorial.Nodes.Clear();

                LoadTree(4);        //加载部门树
                tvc_Territorial.ExpandAll();

                strWhere_Territorial = StrWhere_Territorial();
                Select_Territorial();
            }
        }

        #endregion

    }
}
