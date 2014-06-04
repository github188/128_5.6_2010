using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using KJ128NMainRun.Graphics.Expert;
namespace KJ128NMainRun.Graphics.A_DPic_Wizard
{
    public partial class A_DPic_Welcom : Form
    {
        A_FrmDCreateConfig frmMain = null;

        #region 构造函数
        public A_DPic_Welcom(A_FrmDCreateConfig frm)
        {
            InitializeComponent();

            frmMain = frm;
        }
        #endregion

        #region 下一步按钮的单击事件
        private void btnNext_Click(object sender, EventArgs e)
        {
            //对是否自动弹出进行验证
            if (checkBox1.Checked)
            {

                System.IO.File.WriteAllText(Application.StartupPath + "\\MapGis\\AutoShowWizard.txt", "false");

            }
            else
            {

                System.IO.File.WriteAllText(Application.StartupPath + "\\MapGis\\AutoShowWizard.txt", "true");

            }

            A_DPic_ImportPic adpicimport = new A_DPic_ImportPic(frmMain);

            adpicimport.Show();

            this.Close();
          

            //frmMain.FrmCreateConfig_Load(sender, e);


        }
        #endregion

        #region 窗体关闭按钮的单击事件
        private void A_DPic_Welcom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBox1.Checked)
            {

                System.IO.File.WriteAllText(Application.StartupPath + "\\MapGis\\AutoShowWizard.txt", "false");

            }
            else
            {

                System.IO.File.WriteAllText(Application.StartupPath + "\\MapGis\\AutoShowWizard.txt", "true");

            }

        }
        #endregion

        #region 窗体加载事件
        private void A_DPic_Welcom_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\MapGis\\AutoShowWizard.txt"))
            {
                if (System.IO.File.ReadAllText(Application.StartupPath + "\\MapGis\\AutoShowWizard.txt").IndexOf("true") >= 0)
                {
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox1.Checked = true;
                }
            }
        }
        #endregion 
    }
}
