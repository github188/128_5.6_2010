using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun
{
    public partial class FormSoftReg : Form
    {

        SoftReg sr;
        bool isRegistered = false;

        public delegate void RegisterHandle(bool isSuccessed);
        public event RegisterHandle RegisterEvent;
        public void OnRegisterEvent(bool isSuccessed)
        {
            if (RegisterEvent != null)
            {
                RegisterEvent(isSuccessed);
            }
        }

        public FormSoftReg()
        {
            InitializeComponent();
        }


        private void FormSoftReg_Load(object sender, EventArgs e)
        {
            sr = new SoftReg();
            tbDiskNumber.Text = sr.GetMNum();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string correctNum = sr.GetRNum(tbDiskNumber.Text);
            string buildNum = tbRegNum1.Text.Trim()
                + tbRegNum2.Text.Trim()
                + tbRegNum3.Text.Trim()
                + tbRegNum4.Text.Trim()
                + tbRegNum5.Text.Trim()
                + tbRegNum6.Text.Trim();

            if (buildNum.Length < 24)
            {
                MessageBox.Show("注册码输入有误，请核实！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (correctNum.Equals(buildNum))
            {
                //存入配置文件
                buildNum = buildNum.Insert(4, "-");
                buildNum = buildNum.Insert(9, "-");
                buildNum = buildNum.Insert(14, "-");
                buildNum = buildNum.Insert(19, "-");
                buildNum = buildNum.Insert(24, "-");
                FileConfig.SetValue("Num", buildNum);
                OnRegisterEvent(true);
                isRegistered = true;
                MessageBox.Show("注册成功！");
            }
            else
            {
                OnRegisterEvent(false);
                isRegistered = false;
                MessageBox.Show("注册失败！请重新输入注册码。");
            }
        }

        private void FormSoftReg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isRegistered)
            {
                if (MessageBox.Show("软件尚未注册成功，是否立即退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
