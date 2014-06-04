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

        private string strWhere_Path = " 1=1 ";

        #endregion


        #region【方法：组织查询条件——工作异常】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_Path()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_Path_Dept.SelectedNode != null && !tvc_Path_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_Path_Dept.SelectedNode) + " )";
            }
            if (!txt_Path_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like '%" + txt_Path_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_Path_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_Path_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询——工作异常】

        private void Select_Path()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_Path(strWhere_Path);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_Path";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    //lblMainTitle.Text = "工作异常报警：  共 " + ds.Tables[1].Rows.Count + " 人";
                    if (dgv_Main.Columns.Count >= 7)
                    {
                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["姓名"].DisplayIndex = 1;
                        dgv_Main.Columns["部门"].DisplayIndex = 2;
                        dgv_Main.Columns["职务"].DisplayIndex = 3;
                        dgv_Main.Columns["工种"].DisplayIndex = 4;
                        dgv_Main.Columns["传输分站位置"].DisplayIndex = 5;
                        dgv_Main.Columns["读卡分站位置"].DisplayIndex = 6;
                        dgv_Main.Columns["开始时间"].DisplayIndex = 7;

                        dgv_Main.Columns["职务"].DefaultCellStyle.NullValue = "——";
                        dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";

                        dgv_Main.Columns["DeptID"].Visible = false;
                        dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                    //lblMainTitle.Text = "工作异常报警：  共 0 人";
                }
            }

        }

        #endregion


        #region【方法：刷新——实时超时】

        private void Refresh_Path()
        {
            LoadTree(5);        //加载部门树——工作异常

            Select_Path();           //查询实时工作异常信息  
        }

        #endregion


        
        #region【事件：选择实时超时报警信息——抽屉式菜单】

        private void bt_Path_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_Path.Name);
            this.AcceptButton = bt_Path_Enquiries;
            tvc_Path_Dept.Nodes.Clear();

            //刷新
            Refresh_Path();

            tvc_Path_Dept.ExpandAll();

            lblMainTitle.Text = "工作异常报警";
            intSelectModel = 4;
            strWhere_Path = " 1=1 ";

            IsShowRescue(false);

            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[3]);
        }

        #endregion

        #region【事件：部门树点击事件——工作异常】

        private void tvc_Path_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere_Path = StrWhere_Path();
            Select_Path();
        }

        #endregion

        #region【事件：查询——工作异常】

        private void bt_Path_Enquiries_Click(object sender, EventArgs e)
        {
            strWhere_Path = StrWhere_Path();
            Select_Path();
        }

        #endregion


        #region【事件：重置——工作异常】

        private void bt_Path_Reset_Click(object sender, EventArgs e)
        {
            txt_Path_EmpName.Text = txt_Path_CodeSenderAddress.Text = "";
            if (tvc_Path_Dept.Nodes.Count > 0)
            {
                tvc_Path_Dept.Nodes.Clear();

                LoadTree(5);        //加载部门树
                tvc_Path_Dept.ExpandAll();

                strWhere_Path = StrWhere_Path();
                Select_Path();
            }
        }

        #endregion


    }
}
