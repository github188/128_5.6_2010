using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NInterfaceShow;
using KJ128NDBTable;
using KJ128NDataBase;
using PrintCore;

namespace KJ128NMainRun
{
    public partial class FrmRealTimeAlarmPath : Wilson.Controls.Docking.DockContent
    {
        RealTimeAlarmPathBLL rtpBLL = new RealTimeAlarmPathBLL(); 

        public FrmRealTimeAlarmPath()
        {
            InitializeComponent();

            dgvMain.Columns["StationPlace"].HeaderText = HardwareName.Value(CorpsName.StationSplace);
            dgvMain.Columns["StationHeadPlace"].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
        }

        #region [����]

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (cbRealTime.Checked)
                {
                    //��ȡʵʱ������Ϣ
                    GetRealTimeAlarmPayhInfo();
                }
            }
        }

        private void FrmRealTimeAlarmPath_Load(object sender, EventArgs e)
        {
            //��ȡ��Ϣ
            GetRealTimeAlarmPayhInfo();
            
            if (New_DBAcess.blIsClient)     //�ͻ��˳���
            {
                bcpDelete.Visible = false;
            }
        }

        /// <summary>
        /// ��ȡʵʱ·�߱�����Ϣ
        /// </summary>
        private void GetRealTimeAlarmPayhInfo()
        {
            if (rtpBLL == null)

            rtpBLL = new RealTimeAlarmPathBLL();

            DataTable dt = rtpBLL.RealTimeAlarmPathInfo();

            if (dt != null && dt.Rows.Count > 0)
            {
                this.cpnlTop.CaptionTitle = "ʵʱ�����쳣������Ϣ��ʾ�� ��ǰ��" + dt.Rows.Count.ToString() + "�������쳣������¼";
                dgvMain.DataSource = dt;
                dgvMain.Columns["StationPlace"].HeaderText = HardwareName.Value(CorpsName.StationSplace);
                dgvMain.Columns["StationHeadPlace"].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
                dgvMain.Columns["EmpID"].Visible = false;
            }
            else
            {
                this.bcpPageSum.CaptionTitle = "��ǰ�޹����쳣������¼";
                dgvMain.DataSource = dt;
            }

        }

        private void bcpExcel_Click(object sender, EventArgs e)
        {
            //ExcelExports.ExportDataGridViewToExcel(this.dbgvMain);
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgvMain, "ʵʱ�����쳣������Ϣ", "�����쳣��������Ϊ:" + dgvMain.Rows.Count.ToString());
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "ʵʱ�����쳣������Ϣ", "�����쳣��������Ϊ:" + dgvMain.Rows.Count.ToString());
        } 

        #endregion

        private void bcpDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvMain.CurrentRow == null)
            {
                MessageBox.Show("�޹����쳣��Ϣ��ɾ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dr = MessageBox.Show("�Ƿ�Ҫɾ����ѡ�б�����Ϣ?","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int EmpID = Convert.ToInt32(this.dgvMain.CurrentRow.Cells["EmpID"].Value.ToString());
                //MessageBox.Show(EmpNo);

                int count = rtpBLL.DeleteRealTimeAlarmPathByEmpID(EmpID);
                if (count == 1)
                {
                    GetRealTimeAlarmPayhInfo();
                    MessageBox.Show("ɾ����Ϣ�ɹ�!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dbgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.bcpDelete.Enabled = true;
                //MessageBox.Show(e.RowIndex.ToString());
            }
            else
            {
                this.bcpDelete.Enabled = false;
            }

        }
    }
}