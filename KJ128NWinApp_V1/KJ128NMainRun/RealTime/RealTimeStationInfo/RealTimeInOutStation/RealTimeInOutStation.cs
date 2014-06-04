using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NInterfaceShow
{
    public partial class RealTimeInOutStation : Wilson.Controls.Docking.DockContent
    {
        
        //此窗体已被废弃
        public RealTimeInOutStation()
        {
            InitializeComponent();
        }

        private void RealTimeInOutStation_Load(object sender, EventArgs e)
        {

            ShowDate();


        }
        private void ShowDate()
        {
            KJ128NDataBase.DBAcess dbAcess = new KJ128NDataBase.DBAcess();
            DataTable dtInStationTable = dbAcess.GetDataSet("select * from KJ128N_RT_InStation_Table order by 发码器地址").Tables[0];
            dgvInOutStationInfo.DataSource = dtInStationTable.DefaultView;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowDate();
        }
    }
}