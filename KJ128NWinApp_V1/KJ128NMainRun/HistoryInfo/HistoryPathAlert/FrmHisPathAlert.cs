using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NDBTable;

namespace KJ128NInterfaceShow
{
    public partial class FrmHisPathAlert : Wilson.Controls.Docking.DockContent
    {

        private readonly HisPathAlertInfoBLL bll = new HisPathAlertInfoBLL();

        public FrmHisPathAlert()
        {
            InitializeComponent();
        }

        #region [����]

        private void FrmPathAlert_Load(object sender, EventArgs e)
        {
            //HisPathAlertInfo
            BandingDataGrid("");
            InnitializeTime();
            
        }

        private void BandingDataGrid(string condition)
        {
            DataTable dt = bll.GetHisPathAlertInfo(condition);
            this.dbgvMain.DataSource = dt;

            if (dt != null && dt.Rows.Count > 0)
            {
                dbgvMain.Columns[8].HeaderText = HardwareName.Value(CorpsName.StationSplace);
                dbgvMain.Columns[9].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);

                dbgvMain.Columns["EmpID"].Visible = false;

                cpnlTop.CaptionTitle = "��ʷ·��������Ϣ��\t��" + dt.Rows.Count.ToString() + "����Ϣ";
            }
            else
            {
                cpnlTop.CaptionTitle = "��ʷ·��������Ϣ��\t��0����Ϣ";
            }

            //this.listBox1.Items.Clear();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    this.listBox1.Items.Add(dr["AlertBeginTime"].ToString() + "--" + dr["AlertEndTime"].ToString());
            //}
        }

        private void bcpSearch_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpBegin.Text) > Convert.ToDateTime(dtpEnd.Text))
            {
                MessageBox.Show("��ʼʱ�䲻�ܴ��ڽ���ʱ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                string condition = "AlertBeginTime>='" + dtpBegin.Text.Trim() + "'"
                    + " and AlertEndTime<='" + dtpEnd.Text.Trim() + "'";

                //begintime >= '" + strStartTime + "' And endtime <= '"
                BandingDataGrid(condition);
            }
        }

        private void bcpReset_Click(object sender, EventArgs e)
        {
            //dtpBegin.Text = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
            //dtpBegin.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00").ToString();
            //dtpEnd.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            InnitializeTime();
        }

        #region [ �¼�: ��ӡ ]
        
        private void bcpExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dbgvMain,Text);
        }

        #endregion


        private void InnitializeTime()
        {
            dtpBegin.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00").ToString();
            dtpEnd.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #endregion
    }
}