using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace KJ128NInterfaceShow
{
    public partial class RealTimeEmployeeInfo : Wilson.Controls.Docking.DockContent
    {
        //此窗体已被废弃
        public RealTimeEmployeeInfo()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            KJ128NDataBase.DBAcess dbAcess = new KJ128NDataBase.DBAcess();
            using (DataSet ds = dbAcess.GetDataSet("Select * from KJ128_RealTimeEmployee_Info_Table"))
            {
                dgvRealTimeEmployeeInfo.DataSource=ds.Tables[0].DefaultView;
            }
            dgvRealTimeEmployeeInfo.EnableHeadersVisualStyles = false;
            timer1.Interval = 5000;
        }

        //显示内容：　员工姓名　所在部门　

    }
}