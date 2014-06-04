using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.A_Print
{
    public partial class A_FrmPrint : Form
    {

        #region【声明】

        private TaskTimeBLL tpbll = new TaskTimeBLL();

        #endregion

        #region【构造函数】

        public A_FrmPrint()
        {
            InitializeComponent();

            tpbll.GetTime(cmb_Hour, cmb_Minute, checkBox2, groupBox2);
            bind();
        }

        #endregion

        #region【方法：绑定】

        private void bind()
        {
            for (int i = 1; i < 29; i++)
            {
                cmbDay.Items.Add(i < 10 ? "0" + i.ToString() : i.ToString());
            }
            cmbDay.SelectedIndex = 0;
            cmbHour.SelectedIndex = 0;
            cmb.SelectedIndex = 0;

            DataTable dt = tpbll.GetPrint();
            if (dt != null)
            {
                #region【下井人员统计】

                if (dt.Select("EnumID=1")[0]["EnumValue"].ToString() == "1")    
                {
                    cbx1.Checked = true;
                }
                else
                {
                    cbx1.Checked = false;
                }

                #endregion
                #region【重点区域人员统计】

                if (dt.Select("EnumID=2")[0]["EnumValue"].ToString() == "1")
                {
                    cbx2.Checked = true;
                }
                else
                {
                    cbx2.Checked = false;
                }

                #endregion
                #region【超时报警人员统计】

                if (dt.Select("EnumID=3")[0]["EnumValue"].ToString() == "1")
                {
                    cbx3.Checked = true;
                }
                else
                {
                    cbx3.Checked = false;
                }

                #endregion
                #region【限制区域报警人员统计】

                if (dt.Select("EnumID=5")[0]["EnumValue"].ToString() == "1")
                {
                    cbx5.Checked = true;
                }
                else
                {
                    cbx5.Checked = false;
                }

                #endregion
                #region【特种作业人员工作异常报警人员统计】

                if (dt.Select("EnumID=6")[0]["EnumValue"].ToString() == "1")
                {
                    cbx6.Checked = true;
                }
                else
                {
                    cbx6.Checked = false;
                }

                #endregion

                #region【领导干部每月下井总数统计】

                string s = dt.Select("EnumID=7")[0]["EnumValue"].ToString();
                if (s != "0")
                {
                    cmbDay.Enabled = cmb.Enabled = cmbHour.Enabled = cbx7.Checked = true;
                    cmbDay.SelectedIndex = int.Parse(s.Substring(0, 2))-1;
                    cmbHour.SelectedIndex = int.Parse(s.Substring(3, 2));
                    cmb.SelectedIndex = int.Parse(s.Substring(6, 2));
                }
                else
                {
                    cmbDay.Enabled = cmb.Enabled = cmbHour.Enabled = cbx7.Checked = false;
                }
                #endregion
            }
        }

        #endregion

        #region【事件：保存】

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string str1, str2, str3, str4, str5, str6, str7, strTime;
                str1 = str2 = str3 = str4 = str5 = str6 = str7 = strTime = "0";
                if (cbx1.Checked)
                {
                    str1 = "1";
                }
                if (cbx2.Checked)
                {
                    str2 = "1";
                }
                if (cbx3.Checked)
                {
                    str3 = "1";
                }

                if (cbx5.Checked)
                {
                    str5 = "1";
                }
                if (cbx6.Checked)
                {
                    str6 = "1";
                }
                if (cbx7.Checked)
                {
                    str7 = cmbDay.Text + ":" + cmbHour.Text + ":" + cmb.Text;
                }
                if (checkBox2.Checked)
                {
                    strTime = cmb_Hour.Text + ":" + cmb_Minute.Text;
                }


                int result = tpbll.SavePrint(str1, str2, str3, str4, str5, str6, str7, strTime);

                if (result > 0)
                {
                    MessageBox.Show("打印设置保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("打印设置保存失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印设置保存时出现错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region【事件：是否启用定时打印】

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                cmb_Hour.SelectedIndex = 0;
                cmb_Minute.SelectedIndex = 0;
                groupBox2.Enabled = false;
            }
        }

        #endregion

        #region【事件：是否启用领导干部月下井打印】

        private void cbx7_CheckedChanged(object sender, EventArgs e)
        {
            cmb.Enabled = cmbDay.Enabled = cmbHour.Enabled = cbx7.Checked;
        }

        #endregion

        #region【事件：退出】

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
