using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.A_RTAlarm
{
    partial class A_FrmRTAlarm
    {
        #region【声明】

        private string strEmpCount = "";

        #endregion

        #region【方法：查询——实时超员】

        private void Select_OverEmp()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.Select_OverEmp();

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTAlarm_OverEmp";
                    dgv_Main.DataSource = ds.Tables[0];

                    if (dgv_Main.Columns.Count >= 5)
                    {
                        dgv_Main.Columns["开始时间"].DisplayIndex = 0;
                        dgv_Main.Columns["额定下井人数"].DisplayIndex = 1;
                        dgv_Main.Columns["最大超员人数"].DisplayIndex = 2;
                        dgv_Main.Columns["最大超员人数时间"].DisplayIndex = 3;
                        dgv_Main.Columns["实时超员人数"].DisplayIndex = 4;
            
                        dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        #region【方法：刷新——实时超员】

        private void Refresh_OverEmp()
        {
            if (!txt_RationEmpCount.Focused)
            {
                LoadEmpCount();             //额定工作人数
            }
            
            Select_OverEmp();           //查询实时超员信息  
        }

        #endregion

        #region【方法：重新判断当前是否超员 ]

        private bool IsOverEmp()
        {
            return rtabll.IsOverEmp();
        }

        #endregion

        #region【方法：初始化额定超员人数】

        private void LoadEmpCount()
        {
            using (ds=new DataSet())
            {
                ds = rtabll.GetEmpCount();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    strEmpCount = ds.Tables[0].Rows[0][0].ToString();
                    txt_RationEmpCount.Text = strEmpCount;
                }
            }
        }

        #endregion

        #region【事件：选择实时超员报警信息——抽屉式菜单】

        private void bt_OverEmp_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(pl_OverEmp.Name);

            LoadEmpCount();             //额定工作人数

            //刷新
            Refresh_OverEmp();

            lblMainTitle.Text = "超员报警";
            intSelectModel = 1;

            IsShowRescue(false);

            this.btnPrint.Text = "打印";
            //刷新报警按钮
            SelctText(!IsAlarmFull[0]);
        }

        #endregion


        #region【事件：设置额定工作人数】

        private void txt_RationEmpCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (LoginBLL.user.ToLower().Equals("admin") || LoginBLL.user.ToLower().Equals("3shine"))
                {
                    //txt_RationEmpCount.Enabled = true;
                    if (Convert.ToInt32(txt_RationEmpCount.Text.Trim()) == 0)
                    {
                        MessageBox.Show("额定超员人数必须大于0，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txt_RationEmpCount.Focus();
                        txt_RationEmpCount.Text = strEmpCount;
                        txt_RationEmpCount.SelectAll();
                        return;
                    }
                    if (!txt_RationEmpCount.Text.Trim().Equals(strEmpCount))
                    {
                        rtabll.SaveEmpCount(txt_RationEmpCount.Text.Trim());
                        ConfigXmlWiter.Write("EnumTable.xml");
                        IsOverEmp();
                    }
                }
                else
                {
                    MessageBox.Show("您没有修改权限,请使用超级管理admin进行修改!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        #endregion
    }
}
