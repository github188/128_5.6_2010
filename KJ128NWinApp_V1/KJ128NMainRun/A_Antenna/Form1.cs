using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.A_Antenna
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv.DataSource = new KJ128NDBTable.A_AntennaBLL().GetAllStation();
            dgv1.DataSource = new KJ128NDBTable.A_AntennaBLL().GetAllStation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text = dgv1.Columns[0].GetType().ToString();
            //dgv1.Columns[1].Visible = false;
            KJ128NDBTable.PrintBLL.Print(dgv1, "sss");
            //dgv1.Columns[1].Visible = true;
        }
    }
}
