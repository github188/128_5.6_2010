using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class FrmStationHeadStat : Wilson.Controls.Docking.DockContent
    {
        public FrmStationHeadStat()
        {
            InitializeComponent();
        }

        private RealTimeStationHeadStatBLL bll = new RealTimeStationHeadStatBLL();

        private void InitializeDataGridView(DateTime beginTime, DateTime endTime)
        {
            //if (beginTime > endTime)
            //{
            //    MessageBox.Show("开始时间不能大于结束时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            DataTable dt = bll.SelectRealTimeSationHeadStatInfo(beginTime, endTime);
            this.dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = HardwareName.Value(CorpsName.StationAddress);
            dgvMain.Columns[1].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);
            dgvMain.Columns[2].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
            dgvMain.Columns[3].HeaderText = "进天线A" + HardwareName.Value(CorpsName.CodeSender) + "数";
            dgvMain.Columns[4].HeaderText = "进天线B" + HardwareName.Value(CorpsName.CodeSender) + "数";
            dgvMain.Columns[5].HeaderText = "出" + HardwareName.Value(CorpsName.StaHead) + HardwareName.Value(CorpsName.CodeSender) + "数";
            dgvMain.Columns[6].HeaderText = "进出" + HardwareName.Value(CorpsName.StaHead) + HardwareName.Value(CorpsName.CodeSender) + "总数";

        }

        private void FrmStationHeadStat_Load(object sender, EventArgs e)
        {
            dtpBegin.Text = DateTime.Now.ToShortDateString() + " 00:00:00";

            timer.Start();

            DateTime begin = Convert.ToDateTime(dtpBegin.Text);
            DateTime end = Convert.ToDateTime(dtpEnd.Text);

            InitializeDataGridView(begin, end);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (cbRe.Checked)
            {
                //dtpBegin.Text = DateTime.Now.ToShortDateString() + " 00:00:00";
                dtpEnd.Text = DateTime.Now.ToString();

                DateTime begin = Convert.ToDateTime(dtpBegin.Text);
                DateTime end = Convert.ToDateTime(dtpEnd.Text);

                InitializeDataGridView(begin, end);
            }
        }

        private void tcpQuery_Click(object sender, EventArgs e)
        {
            DateTime begin = Convert.ToDateTime(dtpBegin.Text);
            DateTime end = Convert.ToDateTime(dtpEnd.Text);

            if (begin > end)
            {
                MessageBox.Show("开始时间不能大于结束时间","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return; 
            }

            InitializeDataGridView(begin, end);
        }
    }
}
