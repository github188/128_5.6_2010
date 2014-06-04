using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun
{
    public partial class Form2Test : Form
    {
        public Form2Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics.FrmRealTime frmrealtime = new KJ128NMainRun.Graphics.FrmRealTime();
            frmrealtime.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics.FrmPicConfig f = new KJ128NMainRun.Graphics.FrmPicConfig();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics.FrmHistroyRoute f = new KJ128NMainRun.Graphics.FrmHistroyRoute();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics.FrmRouteConfig f = new KJ128NMainRun.Graphics.FrmRouteConfig();
            f.Show();
        }

        private void Form2Test_Load(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            Graphics.Config.FrmCreateConfig f = new KJ128NMainRun.Graphics.Config.FrmCreateConfig();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Graphics.Config.FrmCfgRealTime f = new KJ128NMainRun.Graphics.Config.FrmCfgRealTime();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Graphics.Config.frmFileDialog f = new KJ128NMainRun.Graphics.Config.frmFileDialog();
            f.ShowDialog();
        }
    }
}