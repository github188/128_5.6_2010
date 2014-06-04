using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace KJ128NInterfaceShow
{
    public partial class FrmAboutUs : Form
    {
        public FrmAboutUs()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSysInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //string exeName = "sysdm.cpl";
                string exeName = "msinfo32.exe";

                Process.Start(exeName);
            }
            catch(Exception ex)
            {
                MessageBox.Show("调用操作系统信息程序失败，调用失败消息：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void FrmAboutUs_Load(object sender, EventArgs e)
        {
            string osInfo = GetOSInfo();
            this.lblOSInfo.Text = "运行操作系统:" + osInfo + "。";

            //string clrInfo = GetCLRInfo();
            //this.lblCLRVer.Text += clrInfo + "。";
        }


        private string GetOSInfo()
        {

            //SystemInformation. 
            int ma = Environment.OSVersion.Version.Major;

            int mi = Environment.OSVersion.Version.Minor;


            if (ma == 5 && mi == 2)
            {
                return "Windows Server 2003";
            }
            else if(ma == 5 && mi == 1)
            {
                return "Windows XP";
            }
            else if (ma == 5 && mi == 0)
            {
                return "Windows Server 2000";
            }
            else
            {
                return "版本过低或过高的操作系统";
            }

            //return Environment.OSVersion.ToString(); 
        }

        //private string GetCLRInfo()
        //{
        //    return Environment.Version.Major.ToString();
        //}
    }
}
