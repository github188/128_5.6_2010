using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.A_RT_OverSee
{
    public partial class A_RT_Time_Set : Form
    {
        public A_RT_Time_Set()
        {
            InitializeComponent();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.DialogResult = DialogResult.OK;
                A_RT_Station_Head Afr = (A_RT_Station_Head)Application.OpenForms["A_RT_Station_Head"];
                Afr._time1 = dateTimePicker1.Value.ToString();
                Afr._time2 = dateTimePicker2.Value.ToString();
            }
        }

        private void removebutton_Click(object sender, EventArgs e)
        {

        }

        private void returnbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
