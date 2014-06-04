using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm
    {

        #region【方法：查询——区域超员】

        private void Select_TerOverEmp()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_TerOverEmp();

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_TerOverEmp";
                    dgv_Main.DataSource = ds.Tables[0];

                    if (dgv_Main.Columns.Count >= 8)
                    {
                        dgv_Main.Columns["区域名称"].DisplayIndex = 0;
                        dgv_Main.Columns["区域类别"].DisplayIndex = 1;
                        dgv_Main.Columns["当前区域人数"].DisplayIndex = 2;
                        dgv_Main.Columns["区域额定人数"].DisplayIndex = 3;
                        dgv_Main.Columns["区域超员人数"].DisplayIndex = 4;
                        dgv_Main.Columns["最高超员人数"].DisplayIndex = 5;
                        dgv_Main.Columns["开始时间"].DisplayIndex = 6;
                        dgv_Main.Columns["持续时长"].DisplayIndex = 7;

                        dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
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

        #region【方法：刷新——区域超员】

        private void Refresh_TerOverEmp()
        {
            Select_TerOverEmp();           //查询区域超员信息  
        }

        #endregion

        #region【事件：选择区域超员报警信息——抽屉式菜单】

        private void bt_TerOverEmp_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 12)
            {
                dmc_Info.ButtonClick(pl_TerOverEmp.Name);

                //刷新
                Refresh_TerOverEmp();

                lblMainTitle.Text = "区域超员报警";
                intSelectModel = 12;

                IsShowRescue(false);

                this.btnPrint.Text = "打印";
                //刷新报警按钮
                SelctText(!IsAlarmFull[11]);
            }
        }

        #endregion


    }
}
