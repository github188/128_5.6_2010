using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm
    {
        #region【声明】

        private string strWhere_OverSpeed = "1=1";

        #endregion

        #region【方法：刷新——实时超速】

        private void Refresh_OverSpeed()
        {
            LoadTree(6);        //加载部门树——超速

            Select_OverSpeed();           //查询实时超速信息 
        }

        #endregion

        #region【方法：组织查询条件——实时超时】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_OverSpeed()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_OverSpeed_Dept.SelectedNode != null && !tvc_OverSpeed_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_OverSpeed_Dept.SelectedNode) + " )";
            }

            if (!txt_OverSpeed_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like '%" + txt_OverSpeed_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_OverSpeed_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_OverSpeed_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion


        #region【方法：查询】

        private void Select_OverSpeed()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_OverSpeed(strWhere_OverSpeed);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_OverSpeed";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    //lblMainTitle.Text = "超速报警：  共 " + ds.Tables[1].Rows.Count + " 人";

                    if (dgv_Main.Columns.Count >= 14)
                    {
                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["姓名"].DisplayIndex = 1;
                        dgv_Main.Columns["部门"].DisplayIndex = 2;
                        dgv_Main.Columns["起始传输分站编号"].DisplayIndex = 3;
                        dgv_Main.Columns["起始读卡分站编号"].DisplayIndex = 4;
                        dgv_Main.Columns["起始读卡分站位置"].DisplayIndex = 5;
                        dgv_Main.Columns["起始读卡分站监测时间"].DisplayIndex = 6;
                        dgv_Main.Columns["终点传输分站编号"].DisplayIndex = 7;
                        dgv_Main.Columns["终点读卡分站编号"].DisplayIndex = 8;
                        dgv_Main.Columns["终点读卡分站位置"].DisplayIndex = 9;
                        dgv_Main.Columns["终点读卡分站监测时间"].DisplayIndex = 10;
                        dgv_Main.Columns["额定行走时间"].DisplayIndex = 11;
                        dgv_Main.Columns["实际行走时间"].DisplayIndex = 12;
                        

                        dgv_Main.Columns["HisOverSpeedID"].Visible = false;
                        dgv_Main.Columns["起始读卡分站监测时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgv_Main.Columns["终点读卡分站监测时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                    //lblMainTitle.Text = "超速报警：  共 0 人";
                }
            }

        }

        #endregion

        #region【事件：选择实时超员报警信息——抽屉式菜单】

        private void bt_Walk_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_OverSpeed.Name);
            this.AcceptButton = bt_OverSpeed_Enquiries;
            tvc_OverSpeed_Dept.Nodes.Clear();

            //刷新
            Refresh_OverSpeed();

            tvc_OverSpeed_Dept.ExpandAll();

            lblMainTitle.Text = "超速报警";
            intSelectModel = 9;
            strWhere_OverSpeed = " 1 = 1";
            IsShowRescue(false);

            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[8]);
        }

        #endregion

        #region【事件：查询——实时超速报警信息】

        private void bt_OverSpeed_Enquiries_Click(object sender, EventArgs e)
        {
            strWhere_OverSpeed = StrWhere_OverSpeed();
            Select_OverSpeed();
        }

        #endregion

        #region【事件：重置——实时超速报警信息】

        private void bt_OverSpeed_Reset_Click(object sender, EventArgs e)
        {
            txt_OverSpeed_CodeSenderAddress.Text = txt_OverSpeed_EmpName.Text = "";
            if (tvc_OverSpeed_Dept.Nodes.Count > 0)
            {
                tvc_OverSpeed_Dept.Nodes.Clear();

                LoadTree(6);        //加载部门树
                tvc_OverSpeed_Dept.ExpandAll();

                strWhere_OverSpeed = StrWhere_OverSpeed();
                Select_OverSpeed();
            }
        }

        #endregion

        #region【事件：选择部门】

        private void tvc_OverSpeed_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere_OverSpeed = StrWhere_OverSpeed();
            Select_OverSpeed();
        }

        #endregion

    }
}
