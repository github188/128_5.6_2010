using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NDBTable;

namespace KJ128NMainRun.HistoryInfo
{
    public partial class HisBadstation : Wilson.Controls.Docking.DockContent
    {

        #region [ 申明 ]

        private HisBadstationBLL hbsbll = new HisBadstationBLL();

        #endregion 

        DbHelperSQL db = new DbHelperSQL();
        public HisBadstation()
        {
            InitializeComponent();

            label3.Text = HardwareName.Value(CorpsName.StationAddress); 
        }

        private void HisBadstation_Load(object sender, EventArgs e)
        {
            begindateTime.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            enddateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            buttonCaptionPanel1_MouseClick(null, null);
        }
       
        #region [ 事件: 确定按钮_Click事件 ]

        private void buttonCaptionPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (rbStation.Checked)
            {
                //查询分站故障统计
                hbsbll.GetHisBadStationInfo(begindateTime.Text, enddateTime.Text, textBox1.Text, dataGridView1);
            }
            else
            {
                //查询接收器故障统计
                hbsbll.GetHisBadStaHeadInfo(begindateTime.Text, enddateTime.Text, textBox1.Text, dataGridView1);

            }
        }

        #endregion

        private void buttonCaptionPanel2_MouseClick(object sender, MouseEventArgs e)
        {
            //string l1 = ll();
            //string sql = "select StationAddress as 分站编号,StationHeadAddress as 接收器编号,count(StationHeadAddress) as 故障次数 ,sum(BadTime) as '总故障时间(秒)' from dbo.HistoryBadStations  where BadEndTime >'" + begindateTime.Value + "' and BadBeginTime <'" + enddateTime.Value + "'  and StationHeadAddress<>0 " + l1 + " group by StationAddress ,StationHeadAddress order by StationAddress,StationHeadAddress";
            //dataGridView1.DataSource = db.Query(sql).Tables[0];
            //dataGridView1.Columns["探头号"].DisplayIndex = 1;
        }
    }
}
