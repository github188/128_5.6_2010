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

        #region [方法]

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (cbRealTime.Checked)
                {
                    //获取实时报警信息
                    GetRealTimeAlarmPayhInfo();
                }
            }
        }

        private void FrmRealTimeAlarmPath_Load(object sender, EventArgs e)
        {
            //获取信息
            GetRealTimeAlarmPayhInfo();
            
            if (New_DBAcess.blIsClient)     //客户端程序
            {
                bcpDelete.Visible = false;
            }
        }

        /// <summary>
        /// 获取实时路线报警信息
        /// </summary>
        private void GetRealTimeAlarmPayhInfo()
        {
            if (rtpBLL == null)

            rtpBLL = new RealTimeAlarmPathBLL();

            DataTable dt = rtpBLL.RealTimeAlarmPathInfo();

            if (dt != null && dt.Rows.Count > 0)
            {
                this.cpnlTop.CaptionTitle = "实时工作异常报警信息显示： 当前有" + dt.Rows.Count.ToString() + "条工作异常报警记录";
                dgvMain.DataSource = dt;
                dgvMain.Columns["StationPlace"].HeaderText = HardwareName.Value(CorpsName.StationSplace);
                dgvMain.Columns["StationHeadPlace"].HeaderText = HardwareName.Value(CorpsName.StaHeadSplace);
                dgvMain.Columns["EmpID"].Visible = false;
            }
            else
            {
                this.bcpPageSum.CaptionTitle = "当前无工作异常报警记录";
                dgvMain.DataSource = dt;
            }

        }

        private void bcpExcel_Click(object sender, EventArgs e)
        {
            //ExcelExports.ExportDataGridViewToExcel(this.dbgvMain);
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgvMain, "实时工作异常报警信息", "工作异常报警总数为:" + dgvMain.Rows.Count.ToString());
            KJ128NDBTable.PrintBLL.Print(this.dgvMain, "实时工作异常报警信息", "工作异常报警总数为:" + dgvMain.Rows.Count.ToString());
        } 

        #endregion

        private void bcpDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvMain.CurrentRow == null)
            {
                MessageBox.Show("无工作异常信息可删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dr = MessageBox.Show("是否要删除所选行报警信息?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int EmpID = Convert.ToInt32(this.dgvMain.CurrentRow.Cells["EmpID"].Value.ToString());
                //MessageBox.Show(EmpNo);

                int count = rtpBLL.DeleteRealTimeAlarmPathByEmpID(EmpID);
                if (count == 1)
                {
                    GetRealTimeAlarmPayhInfo();
                    MessageBox.Show("删除信息成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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