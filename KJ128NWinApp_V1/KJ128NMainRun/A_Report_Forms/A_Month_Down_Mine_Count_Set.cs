using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.A_Report_Forms
{
    public partial class A_Month_Down_Mine_Count_Set : Form
    {
        private A_Month_Down_Mine_Count frmMonth;

        #region【构造函数】

        public A_Month_Down_Mine_Count_Set(A_Month_Down_Mine_Count frm)
        {
            InitializeComponent();
            frmMonth = frm;
            DdayTEXT.Enabled = false;
            rbCustom.Checked = frmMonth.blIsCustom;
            Udayen();

            if (frmMonth.blIsCustom)
            {
                UdayTEXT.Text = frmMonth._ud;
                DdayTEXT.Text = frmMonth._dd;
            }
        }

        #endregion

        private void shineTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }


        private void textvhangge()
        {
            int a;
            if (UdayTEXT.Text != "")
            {
                a = int.Parse(UdayTEXT.Text) - 1;
                DdayTEXT.Text = a.ToString();
            }
        }

        private void Udayen()
        {
            if (rbMonth.Checked)
            {
                UdayTEXT.Enabled = false;
            }
            else
            {
                UdayTEXT.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Udayen();
        }

        #region【事件：保存】

        private void button1_Click(object sender, EventArgs e)
        {
            lblrr.Visible = true;
                if (rbCustom.Checked)
                {
                    if (UdayTEXT.Text.Trim().Equals(""))
                    {
                        lblrr.Text = "前一月日期不能为空！";
                        lblrr.ForeColor = Color.Red;
                        UdayTEXT.Focus();
                        UdayTEXT.SelectAll();
                        return;
                    }
                    else if(DdayTEXT.Text.Trim().Equals(""))
                    {
                        lblrr.Text = "统计月日期不能为空！";
                        lblrr.ForeColor = Color.Red;
                        DdayTEXT.Focus();
                        DdayTEXT.SelectAll();
                        return;
                    }

                    if (int.Parse(UdayTEXT.Text) > 1 && int.Parse(UdayTEXT.Text) < 32)
                    {
                        //A_Month_Down_Mine_Count afr = (A_Month_Down_Mine_Count)Application.OpenForms["A_Month_Down_Mine_Count"];
                        //if (afr != null)
                        //{
                        //    afr._ud = UdayTEXT.Text;
                        //    afr._dd = DdayTEXT.Text;
                        //    lblrr.Text = "保存成功";
                        //    lblrr.ForeColor = Color.Black;
                        //}
                        frmMonth._ud = UdayTEXT.Text.Trim();
                        frmMonth._dd = DdayTEXT.Text.Trim();
                        lblrr.ForeColor = Color.Black;
                        frmMonth.blIsCustom = rbCustom.Checked;
                    }
                    else
                    {
                        MessageBox.Show("填写日期不符合标准，2-31之间");
                    }
                }
                else
                {
                    lblrr.Text = "保存成功";
                }

        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void UdayTEXT_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (UdayTEXT.Text != "")
            {
                a = int.Parse(UdayTEXT.Text) - 1;
                DdayTEXT.Text = a.ToString();
            }
        }
    }
}
