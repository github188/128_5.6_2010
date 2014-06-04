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

        private string strWhere_EmpHelp = " 1 = 1 ";

        #endregion

        #region【方法：查询——人员求救】

        private void Select_EmpHelp()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_EmpHelp(strWhere_EmpHelp);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_Help";
                    dgv_Main.DataSource = ds.Tables[0];
                    dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    //lblMainTitle.Text = "求救报警：  共 " + ds.Tables[1].Rows.Count + " 人";
                    if (dgv_Main.Columns.Count >= 11)
                    {
                        if (!dgv_Main.Columns.Contains("clMeasure"))
                        {
                            DataGridViewButtonColumn colName = new DataGridViewButtonColumn();
                            colName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                            colName.HeaderText = "操作";
                            colName.Name = "clMeasure";
                            colName.ReadOnly = true;
                            colName.Text = "操作";
                            colName.UseColumnTextForButtonValue=true;
                            dgv_Main.Columns.Add(colName);
                        }
                        dgv_Main.Columns["clMeasure"].DisplayIndex = dgv_Main.Columns.Count-1;
                        dgv_Main.Columns["标识卡号"].DisplayIndex = 1;
                        dgv_Main.Columns["姓名"].DisplayIndex = 2;
                        dgv_Main.Columns["部门"].DisplayIndex = 3;
                        dgv_Main.Columns["职务"].DisplayIndex = 4;
                        dgv_Main.Columns["工种"].DisplayIndex = 5;
                        dgv_Main.Columns["读卡分站位置"].DisplayIndex = 8;
                        dgv_Main.Columns["求救开始时间"].DisplayIndex = 9;
                        dgv_Main.Columns["持续时长"].DisplayIndex = 10;


                        dgv_Main.Columns["读卡分站编号"].Visible = false;
                        dgv_Main.Columns["传输分站编号"].Visible = false;
                        dgv_Main.Columns["救援措施"].Visible = false;
                        //dgv_Main.Columns["传输分站位置"].Visible = false;
                        dgv_Main.Columns["RTEmpHelpID"].Visible = false;

                        dgv_Main.Columns["求救开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                    //lblMainTitle.Text = "求救报警：  共 0 人";
                }
            }

        }

        #endregion


        #region【方法：刷新——人员求救】

        private void Refresh_EmpHelp()
        {
            LoadTree(8);        //加载部门树

            Select_EmpHelp();           //查询人员求救信息  
        }

        #endregion




        #region【方法：组织查询条件——人员求救】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_EmpHelp()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_EmpHelp_Dept.SelectedNode != null && !tvc_EmpHelp_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_EmpHelp_Dept.SelectedNode) + " )";
            }
            if (!txt_EmpHelp_EmpName.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like '%" + txt_EmpHelp_EmpName.Text.Trim() + "%' ";
            }

            if (!txt_EmpHelp_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_EmpHelp_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【事件：选择求救报警信息——抽屉式菜单】

        private void bt_EmpHelp_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_EmpHelp.Name);
            this.AcceptButton = bt_EmpHelp_Enquiries;
            tvc_EmpHelp_Dept.Nodes.Clear();

            //刷新
            Refresh_EmpHelp();
            tvc_EmpHelp_Dept.ExpandAll();

            lblMainTitle.Text = "求救报警";
            intSelectModel = 5;
            strWhere_EmpHelp = " 1=1";

            IsShowRescue(true);
            btnLaws.Text = "措施";

            //this.btnPrint.Text = "导出";           
            //刷新报警按钮
            SelctText(!IsAlarmFull[4]);
        }

        #endregion

        #region【事件：部门树点击事件——求救报警】

        private void tvc_EmpHelp_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere_EmpHelp = StrWhere_EmpHelp();
            Select_EmpHelp();
        }

        #endregion

        #region【事件：查询——求救报警】

        private void bt_EmpHelp_Enquiries_Click(object sender, EventArgs e)
        {
            strWhere_EmpHelp = StrWhere_EmpHelp();
            Select_EmpHelp();
        }

        #endregion

        #region【事件：重置——求救报警】

        private void bt_EmpHelp_Reset_Click(object sender, EventArgs e)
        {
            txt_EmpHelp_CodeSenderAddress.Text = txt_EmpHelp_EmpName.Text = "";
            if (tvc_EmpHelp_Dept.Nodes.Count > 0)
            {
                tvc_EmpHelp_Dept.Nodes.Clear();

                LoadTree(8);        //加载部门树
                tvc_EmpHelp_Dept.ExpandAll();

                strWhere_EmpHelp = StrWhere_EmpHelp();
                Select_EmpHelp();
            }
        }

        #endregion
    }
}
