using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm
    {

        #region【声明】

        private string strWhere_Electricity = " 1=1";

        #endregion

        #region【方法：刷新——实时低电量信息】

        private void Refresh_Electricity()
        {
            Select_Electricity();           //查询实时低电量信息 
        }

        #endregion

        #region【方法：组织查询条件——实时低电量信息】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_Electricity()
        {
            string strTempWhere = " 1=1 ";

            if (rb_Emp.Checked)
            {
                strTempWhere += " And CsTypeID = 0 ";
            }
            else if (rb_Equ.Checked)
            {
                strTempWhere += " And CsTypeID = 1";
            }
            else if (rb_NotRegister.Checked)
            {
                strTempWhere += " And CsTypeID is null ";
            }

            return strTempWhere;
        }

        #endregion


        #region【方法：查询——实时低电量信息】

        private void Select_Electricity()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_Electricity(strWhere_Electricity);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_Electricity";
                    dgv_Main.DataSource = ds.Tables[0];

                    if (dgv_Main.Columns.Count >= 5)
                    {
                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["标识卡状态"].DisplayIndex = 1;
                        dgv_Main.Columns["配置类型"].DisplayIndex = 2;
                        dgv_Main.Columns["称呼"].DisplayIndex = 3;
                        dgv_Main.Columns["部门"].DisplayIndex = 4;


                        dgv_Main.Columns["配置类型"].DefaultCellStyle.NullValue = "——";
                        dgv_Main.Columns["称呼"].DefaultCellStyle.NullValue = "——";
                        dgv_Main.Columns["部门"].DefaultCellStyle.NullValue = "——";

                        dgv_Main.Columns["CsTypeID"].Visible = false;
                    }
                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                }
            }

        }

        #endregion

        #region【事件：选择实时低电量报警信息——抽屉式菜单】

        private void bt_Electricity_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_Electricity.Name);

            //刷新
            Refresh_Electricity();

            lblMainTitle.Text = "低电量报警";
            intSelectModel = 8;

            strWhere_Electricity = " 1=1 ";

            IsShowRescue(false);

            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[7]);
        }

        #endregion

        #region【事件：选择标识卡类型】

        private void rb_Emp_CheckedChanged(object sender, EventArgs e)
        {
            strWhere_Electricity = StrWhere_Electricity();
            Select_Electricity();
        }

        #endregion


    }
}
