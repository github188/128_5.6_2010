using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun
{
    public partial class FrmTimePrint : Wilson.Controls.Docking.DockContent
    {

        private TaskTimeBLL tpbll = new TaskTimeBLL();

        #region [ 构造函数 ]

        public FrmTimePrint()
        {
            InitializeComponent();
        }

        #endregion

        #region [ 事件: 窗体加载 ]

        private void FrmTimePrint_Load(object sender, EventArgs e)
        {
            tpbll.GetTime(cmb_Hour, cmb_Minute,checkBox2,groupBox2);
            bind();
        }

        #endregion

        #region [ 方法: 绑定 ]

        private void bind()
        {
            for (int i = 1; i < 29; i++)
			{
			    cmbDay.Items.Add(i<10?"0"+i.ToString():i.ToString());
			}
            cmbDay.SelectedIndex = 0;
            cmbHour.SelectedIndex = 0;
            cmb.SelectedIndex = 0;

            DataTable dt = tpbll.GetPrint();
            if (dt != null)
            {
                for (int i = 1; i < 7; i++)
                {
                    if (dt.Select("EnumID=" + i.ToString())[0]["EnumValue"].ToString() == "1")
                    {
                        foreach (Control c in Controls)
                        {
                            if (c.Name == "cbx" + i.ToString())
                            {
                                ((CheckBox)c).Checked = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (Control c in Controls)
                        {
                            if (c.Name == "cbx" + i.ToString())
                            {
                                ((CheckBox)c).Checked = false;
                            }
                        }
                    }
                }
                string s = dt.Select("EnumID=7")[0]["EnumValue"].ToString();
                if (s != "0")
                {
                    cmb.Enabled = cmbHour.Enabled = cbx7.Checked = true;
                    cmbDay.SelectedIndex = 0;
                    cmbHour.SelectedIndex = int.Parse(s.Substring(3, 2));
                    cmb.SelectedIndex = int.Parse(s.Substring(6,2));
                }
            }
        }

        #endregion

        #region [ 事件: 保存设置 ]

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
                if (cbx4.Checked)
                {
                    str4 = "1";
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

                if (result >0)
                {
                    MessageBox.Show("打印设置保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("打印设置保存失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("打印设置保存时出现错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region [ 事件: 启用定时打印 ]

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

        #region [ 事件: 退出 ]

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void cbx7_CheckedChanged(object sender, EventArgs e)
        {
            cmb.Enabled = cmbDay.Enabled = cmbHour.Enabled = cbx7.Checked;
        }
    }
}