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
        private string strWhere_InWellValidate = " 1=1 ";
        #endregion

        #region 【方法：加载人员下井验证界面】
        /// <summary>
        /// 加载唯一性报警界面
        /// </summary>
        private void Refresh_InWellValidate()
        {
            //LoadTree(15);        //加载部门树

            //Select_InWellValidate();           //查询人员下井验证信息  
        }
        #endregion

        #region【方法：查询——下井人员验证】
        /// <summary>
        /// 查询方法
        /// </summary>
        private void Select_InWellValidate()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_InWellValidate(strWhere_InWellValidate);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_InWellValidate";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    if (dgv_Main.Columns.Count >= 6)
                    {
                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["姓名"].DisplayIndex = 1;
                        dgv_Main.Columns["部门"].DisplayIndex = 2;
                        dgv_Main.Columns["职务"].DisplayIndex =3;
                        dgv_Main.Columns["工种"].DisplayIndex = 4;
                        dgv_Main.Columns["下井时间"].DisplayIndex = 5;
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

        #region【方法：组织查询条件——实时超时】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_InWellValidate()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_InWellValidate.SelectedNode != null && !tvc_InWellValidate.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_InWellValidate.SelectedNode) + " )";
            }
            if (!txtName_InWellValidate.Text.Trim().Equals(""))
            {
                strTempWhere += " And 姓名 like '%" + txtName_InWellValidate.Text.Trim() + "%' ";
            }

            if (!txtCode_InWellValidate.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txtCode_InWellValidate.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        private void btnInWellValidate_Click(object sender, EventArgs e)
        {
            //dmc_Info.ButtonClick(palInWellValidate.Name);
            //this.AcceptButton = btnSearch_InWellValidate;
            //tvc_InWellValidate.Nodes.Clear();
            //txtCode_InWellValidate.Text = "";
            //txtName_InWellValidate.Text = "";
            ////刷新
            //Refresh_InWellValidate();
            //tvc_InWellValidate.ExpandAll();

            //lblMainTitle.Text = "人员下井验证";
            //intSelectModel = 15;
            //strWhere_InWellValidate = " 1=1 ";

            //IsShowRescue(false);

            //this.btnPrint.Text = "打印";
            ////刷新报警按钮
            //SelctText(!IsAlarmFull[14]);
        }

        private void btnSearch_InWellValidate_Click(object sender, EventArgs e)
        {
            strWhere_InWellValidate = StrWhere_InWellValidate();
            Select_InWellValidate();
        }

        private void btnReset_InWellValidate_Click(object sender, EventArgs e)
        {
            txtName_InWellValidate.Text = txtCode_InWellValidate.Text = "";
            if (tvc_InWellValidate.Nodes.Count > 0)
            {
                tvc_InWellValidate.Nodes.Clear();

                LoadTree(15);        //加载部门树
                tvc_InWellValidate.ExpandAll();

                strWhere_InWellValidate = StrWhere_InWellValidate();
                Select_InWellValidate();
            }
        }

        private void tvc_InWellValidate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere_InWellValidate = StrWhere_InWellValidate();
            Select_InWellValidate();
        }
    }
}
