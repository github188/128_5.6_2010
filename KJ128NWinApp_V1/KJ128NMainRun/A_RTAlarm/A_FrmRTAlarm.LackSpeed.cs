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

        private string strWhere_LackSpeed = "1=1";

        #endregion

        #region【方法：刷新——实时超速】

        private void Refresh_LackSpeed()
        {
            LoadTree(7);        //加载部门树——超速

            Select_LackSpeed();           //查询实时超速信息 
        }

        #endregion

        #region【方法：组织查询条件——实时超时】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_LackSpeed()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_LackSpeed_Dept.SelectedNode != null && !tvc_LackSpeed_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_LackSpeed_Dept.SelectedNode) + " )";
            }

            if (!txt_LackSpeed_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like '%" + txt_LackSpeed_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_LackSpeed_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_LackSpeed_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion


        #region【方法：查询】

        private void Select_LackSpeed()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_LackSpeed(strWhere_LackSpeed);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_LackSpeed";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    //lblMainTitle.Text = "欠速报警：  共 " + ds.Tables[1].Rows.Count + " 人";

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
                    //lblMainTitle.Text = "欠速报警：  共 0 人";
                }
            }

        }

        #endregion

        #region【事件：选择实时超员报警信息——抽屉式菜单】

        private void bt_LackSpeed_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_LackSpeed.Name);
            this.AcceptButton = bt_LackSpeed_Enquiries;
            tvc_LackSpeed_Dept.Nodes.Clear();

            //刷新
            Refresh_LackSpeed();

            tvc_LackSpeed_Dept.ExpandAll();

            lblMainTitle.Text = "欠速报警";
            intSelectModel = 10;
            strWhere_LackSpeed = " 1 = 1";

            IsShowRescue(false);
            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[9]);
        }

        #endregion

        #region【事件：查询】

        private void bt_LackSpeed_Enquiries_Click(object sender, EventArgs e)
        {
            strWhere_LackSpeed = StrWhere_LackSpeed();
            Select_LackSpeed();
        }

        #endregion

        #region【事件：重置】

        private void bt_LackSpeed_Reset_Click(object sender, EventArgs e)
        {
            txt_LackSpeed_CodeSenderAddress.Text = txt_LackSpeed_EmpName.Text = "";
            if (tvc_LackSpeed_Dept.Nodes.Count > 0)
            {
                tvc_LackSpeed_Dept.Nodes.Clear();

                LoadTree(7);        //加载部门树
                tvc_LackSpeed_Dept.ExpandAll();

                strWhere_LackSpeed = StrWhere_LackSpeed();
                Select_LackSpeed();
            }
        }

        #endregion

        #region【事件：选择部门】

        private void tvc_LackSpeed_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere_LackSpeed = StrWhere_LackSpeed();
            Select_LackSpeed();
        }

        #endregion
    }
}
