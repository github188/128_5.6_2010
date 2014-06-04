using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDBTable;
using System.Windows.Forms;

namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm
    {

        #region【声明】

        private DataSet ds;

        private string strWhere_EmpOverTime = " 1 = 1 ";

        #endregion



        #region【方法：查询——实时超时】

        private void Select_EmpOverTime()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_EmpOverTime(strWhere_EmpOverTime);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_OverTime";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    //lblMainTitle.Text = "超时报警：  共 " + ds.Tables[1].Rows.Count + " 人";
                    if (dgv_Main.Columns.Count >= 7)
                    {
                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["姓名"].DisplayIndex = 1;
                        dgv_Main.Columns["部门"].DisplayIndex = 2;
                        dgv_Main.Columns["职务"].DisplayIndex = 3;
                        dgv_Main.Columns["工种"].DisplayIndex = 4;
                        //Czlt-2010-9-21--删除代码
                        //dgv_Main.Columns["开始时间"].DisplayIndex = 5;
                        //dgv_Main.Columns["持续时长"].DisplayIndex = 6;
                        //Czlt-2010-9-21-修改代码
                        dgv_Main.Columns["入井时间"].DisplayIndex = 5;
                        dgv_Main.Columns["开始时间"].DisplayIndex = 6;
                        dgv_Main.Columns["持续时长"].DisplayIndex = 7;
                    }

                    //dgv_Main.Columns["CerTypeID"].Visible = false;
                    dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                    //lblMainTitle.Text = "超时报警：  共 0 人";
                }
            }

        }

        #endregion


        #region【方法：刷新——实时超时】

        private void Refresh_EmpOverTime()
        {
            LoadTree(1);        //加载部门树

            Select_EmpOverTime();           //查询实时超时信息  
        }

        #endregion




        #region【方法：组织查询条件——实时超时】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_EmpOverTime()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_EmpOverTime_Dept.SelectedNode !=null && !tvc_EmpOverTime_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_EmpOverTime_Dept.SelectedNode) + " )";
            }
            if (!txt_EmpOverTime_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like '%" + txt_EmpOverTime_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_EmpOverTime_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_EmpOverTime_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【事件：选择实时超时报警信息——抽屉式菜单】

        private void bt_EmpOverTime_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_EmpOverTime.Name);
            this.AcceptButton = bt_EmpOverTime_Enquiries;
            tvc_EmpOverTime_Dept.Nodes.Clear();
            txt_EmpOverTime_EmpName.Text = "";
            txt_EmpOverTime_CodeSenderAddress.Text = "";
            //刷新
            Refresh_EmpOverTime();
            tvc_EmpOverTime_Dept.ExpandAll();

            lblMainTitle.Text = "超时报警";
            intSelectModel = 2;
            strWhere_EmpOverTime = " 1=1";

            IsShowRescue(false);

            this.btnPrint.Text = "打印";

            //刷新报警按钮
            SelctText(!IsAlarmFull[1]);
        }

        #endregion


        #region【事件：部门树点击事件——实时超时报警】

        private void tvc_EmpOverTime_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {

                strWhere_EmpOverTime = StrWhere_EmpOverTime();
                Select_EmpOverTime();
            
        }

        #endregion


        #region【事件：查询——实时超时报警】

        private void bt_EmpOverTime_Enquiries_Click(object sender, EventArgs e)
        {
            strWhere_EmpOverTime = StrWhere_EmpOverTime();
            Select_EmpOverTime();
        }

        #endregion

        #region【事件：重置——实时超时报警】

        private void bt_EmpOverTime_Reset_Click(object sender, EventArgs e)
        {
            txt_EmpOverTime_CodeSenderAddress.Text = txt_EmpOverTime_EmpName.Text = "";
            if (tvc_EmpOverTime_Dept.Nodes.Count > 0)
            {
                tvc_EmpOverTime_Dept.Nodes.Clear();

                LoadTree(1);        //加载部门树
                tvc_EmpOverTime_Dept.ExpandAll();

                strWhere_EmpOverTime = StrWhere_EmpOverTime();
                Select_EmpOverTime();
            }
        }

        #endregion
    }
}
