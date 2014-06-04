using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.RealTime;

namespace KJ128NInterfaceShow
{
    public partial class FrmFlash : Form
    {
        private FrmRealTimeEmpHelp frmrtEmpHelp;

        public FrmFlash()
        {
            InitializeComponent();
        }

        private void FrmFlash_Load(object sender, EventArgs e)
        {
            this.Top = Screen.PrimaryScreen.WorkingArea.Height;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 2;
            
            timer.Start();
        }

        private void LockPosition()
        {
            this.Top -= 5;

        }

        /// <summary>
        /// 更改当前求救人数
        /// </summary>
        /// <param name="strCounts">求救人数</param>
        public void GetCount(string strCounts)
        {
            this.linkLabel1.Text = "当前求救人员共" + strCounts + "人，点击查看详细信息";
            this.linkLabel1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Top > (Screen.PrimaryScreen.WorkingArea.Height - this.Height + 5))
            {
                LockPosition();
            }
            else
            {
                this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 2;
                this.TopMost = true;
                this.timer.Stop();
            }
        }

        //单击连接事件
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmrtEmpHelp = (FrmRealTimeEmpHelp)Application.OpenForms["FrmRealTimeEmpHelp"];

            if (frmrtEmpHelp == null)
            {
                frmrtEmpHelp = new FrmRealTimeEmpHelp();
            }

            frmrtEmpHelp.Show();
            frmrtEmpHelp.Activate();
            
            
        }
    }
}