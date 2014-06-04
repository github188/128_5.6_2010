using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun
{
    public partial class FrmAllEmpState : Wilson.Controls.Docking.DockContent
    {
        private AllEmpStateBLL bll = new AllEmpStateBLL();

        public FrmAllEmpState()
        {
            InitializeComponent();
        }


        private DataTable SelectAllEmpStateInfo(DateTime beginTime, DateTime endTime)
        {
            if (bll == null)
                bll = new AllEmpStateBLL();

            return bll.SelectAllEmpStateInfo(beginTime, endTime);
        }


        private void BandingDataGridView()
        {
            DateTime begin = Convert.ToDateTime(dtpBegin.Text);

            DateTime end = Convert.ToDateTime(dtpEnd.Text);

            DataTable dt = SelectAllEmpStateInfo(begin, end);

            this.dgvMain.DataSource = dt;

            //if (dt != null)
            //{
            //    this.buttonCaptionPanel1.CaptionTitle = "共有" + dt.Rows.Count.ToString() + "条信息";
            //}
            //else
            //{
            //    this.buttonCaptionPanel1.CaptionTitle = "共有0条信息";
            //}
        }

        private void FrmAllEmpState_Load(object sender, EventArgs e)
        {
            dtpBegin.Text = DateTime.Today.ToString();

            dtpEnd.Text = DateTime.Now.ToString();

            BandingDataGridView();
        }

        private void bcpSelect_Load(object sender, EventArgs e)
        {
            BandingDataGridView();
        }

        private void cpStationToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvMain, this.Text, "共 " + dgvMain.Rows.Count.ToString() + " 条记录");
        }

        private void bcpSelect_Click(object sender, EventArgs e)
        {
            BandingDataGridView();
        }
    }
}
