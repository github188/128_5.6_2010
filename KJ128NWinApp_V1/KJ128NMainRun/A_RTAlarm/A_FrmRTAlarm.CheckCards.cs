using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
using System.Windows.Forms;

namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm
    {
        #region【声明】

        private string strWhere_CheckCard = " 1 = 1 ";

        #endregion

        #region 【自定义方法】
        
        #region 【方法：加载唯一性报警界面】
        /// <summary>
        /// 加载唯一性报警界面
        /// </summary>
        private void Refresh_Onlyone()
        {
            LoadTree(14);        //加载部门树

            Select_OnlyOne();           //查询唯一性报警信息  
        }
        #endregion

        #region【方法：查询——唯一性报警】
        /// <summary>
        /// 查询方法
        /// </summary>
        private void Select_OnlyOne()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_OnlyOne(strWhere_CheckCard);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_OnlyOne";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    //lblMainTitle.Text = "求救报警：  共 " + ds.Tables[1].Rows.Count + " 人";
                    if (dgv_Main.Columns.Count >= 7)
                    {
                        if (!dgv_Main.Columns.Contains("clMeasure"))
                        {
                            DataGridViewButtonColumn colName = new DataGridViewButtonColumn();
                            colName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                            colName.HeaderText = "操作";
                            colName.Name = "clMeasure";
                            colName.ReadOnly = true;
                            colName.Text = "操作";
                            colName.UseColumnTextForButtonValue = true;
                            dgv_Main.Columns.Add(colName);
                        }

                        dgv_Main.Columns["标识卡号"].DisplayIndex = 1;
                        dgv_Main.Columns["姓名"].DisplayIndex = 2;
                        dgv_Main.Columns["部门"].DisplayIndex = 3;
                        dgv_Main.Columns["职务"].DisplayIndex = 4;
                        dgv_Main.Columns["工种"].DisplayIndex = 5;
                        dgv_Main.Columns["报警开始时间"].DisplayIndex = 6;
                        dgv_Main.Columns["持续时长"].DisplayIndex = 7;
                        dgv_Main.Columns["clMeasure"].DisplayIndex = dgv_Main.Columns.Count - 1;

                        dgv_Main.Columns["RTOnlyoneID"].Visible = false;
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

        #region【方法：组织查询条件——唯一性报警】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_CheckCards()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_CheckCard_Dept.SelectedNode != null && !tvc_CheckCard_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_CheckCard_Dept.SelectedNode) + " )";
            }
            if (!txt_CheckCards_Name.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like '%" + txt_CheckCards_Name.Text.Trim() + "%' ";
            }

            if (!txt_CheckCards_CodeAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_CheckCards_CodeAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #endregion

        #region 【事件方法】

        #region 【事件方法：点击唯一性查询按钮】
        private void btn_CheckCards_Sceal_Click(object sender, EventArgs e)
        {
            strWhere_CheckCard = StrWhere_CheckCards();
            Select_OnlyOne();
        }
        #endregion

        #region 【事件方法：点击重置按钮】
        private void btn_CheckCards_Reset_Click(object sender, EventArgs e)
        {
            txt_CheckCards_CodeAddress.Text = txt_CheckCards_Name.Text = "";
            if (tvc_CheckCard_Dept.Nodes.Count > 0)
            {
                tvc_CheckCard_Dept.Nodes.Clear();

                LoadTree(14);        //加载部门树
                tvc_CheckCard_Dept.ExpandAll();

                strWhere_CheckCard = StrWhere_CheckCards();
                Select_OnlyOne();
            }
        }
        #endregion

        #region 【事件方法：点击唯一性抽屉菜单】
        private void btnCheckCards_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(palCheckCards.Name);
            this.AcceptButton = btn_CheckCards_Sceal;
            tvc_CheckCard_Dept.Nodes.Clear();

            //刷新
            Refresh_Onlyone();
            tvc_CheckCard_Dept.ExpandAll();

            lblMainTitle.Text = "唯一性报警";
            intSelectModel = 14;
            strWhere_CheckCard = " 1=1";

            IsShowRescue(true);
            btnLaws.Text = "解除";
            btnLaws.Visible = true;

            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[13]);
        }
        #endregion

        #region 【事件方法：点击部门树信息查询】
        private void tvc_CheckCard_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere_CheckCard = StrWhere_CheckCards();
            Select_OnlyOne();
        }
        #endregion

        #endregion
    }
}
