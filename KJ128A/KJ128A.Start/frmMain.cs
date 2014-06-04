using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128A.Start
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process Proc = null;

            // 2.5 秒后启动程序
            System.Threading.Thread.Sleep(2500);

            try
            {
                Proc = new System.Diagnostics.Process();
                Proc.StartInfo.FileName = "KJ128A.Batman.exe";

                Proc.StartInfo.UseShellExecute = false;
                Proc.StartInfo.RedirectStandardInput = true;
                Proc.StartInfo.RedirectStandardOutput = true;

                Proc.Start();
            }
            catch
            {
            }

            Application.Exit();
        }
    }
}