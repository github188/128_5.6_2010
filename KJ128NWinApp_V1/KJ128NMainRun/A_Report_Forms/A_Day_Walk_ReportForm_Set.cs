using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;


namespace KJ128NMainRun.A_Report_Forms
{
    public partial class A_Day_Walk_ReportForm_Set : Form
    {
        DBAcess db = new DBAcess();
        public A_Day_Walk_ReportForm_Set()
        {
            InitializeComponent();
            DutyLevelCMB.DataSource = db.GetDataSet("select EnumID,Title from dbo.EnumTable where FunID=4").Tables[0];
            DutyLevelCMB.DisplayMember = "Title";
            DutyLevelCMB.ValueMember = "EnumID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A_Day_Walk_ReportForm fre = (A_Day_Walk_ReportForm)Application.OpenForms["A_Day_Walk_ReportForm"];
            if (fre != null)
            {
                fre._dutyclassid = DutyLevelCMB.SelectedValue.ToString();
                lbree.ForeColor = Color.Red;
                lbree.Text = "保存成功";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
