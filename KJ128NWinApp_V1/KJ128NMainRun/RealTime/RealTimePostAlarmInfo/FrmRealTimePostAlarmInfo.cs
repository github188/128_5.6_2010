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
    public partial class FrmRealTimePostAlarmInfo : Wilson.Controls.Docking.DockContent
    {

        private RealTimePostBLL bll = new RealTimePostBLL();

        public FrmRealTimePostAlarmInfo()
        {
            InitializeComponent();
        }


        private DataTable SelectRealTimePostAlarmInfo(string condition)
        {
            return bll.SelectRealTimePostAlarmInfo(condition);
        }

        private void BandingDataGridView(string condition)
        {
            DataTable dt = SelectRealTimePostAlarmInfo(condition);

            this.dgvMain.DataSource = dt;
        }

        private void FrmRealTimePostAlarmInfo_Load(object sender, EventArgs e)
        {
            BandingDataGridView("");
        }

        private void bcpSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = String.Empty;

                if (txtEmpName.Text.Trim() != "")
                {
                    condition = " and EmpName like '%" + txtEmpName.Text + "%'";
                }
                else
                {
                    condition = "1=1";
                }

                if (txtCodeSenderAddress.Text.Trim() != "")
                {
                    condition += " and CodeSenderAddress=" + txtCodeSenderAddress.Text;
                }

                condition += " and Begintime>='" + dtpBegin.Text + "' and Begintime<='" + dtpEnd.Text + "'";

                BandingDataGridView(condition);
            }
            catch (Exception ex)
            {
                MessageBox.Show("组织查询条件导致SQL查询错误\n错误消息：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
