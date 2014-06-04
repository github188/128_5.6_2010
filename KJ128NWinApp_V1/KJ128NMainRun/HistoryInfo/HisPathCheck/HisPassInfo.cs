using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using PrintCore;

namespace KJ128NMainRun
{
    public partial class FormHisPassInfo : Wilson.Controls.Docking.DockContent
    {

        private HisPathCheckBll bll = new HisPathCheckBll();

        private int empID;

        private string empName = String.Empty;

        private string beginTime = String.Empty;

        public FormHisPassInfo()
        {
            InitializeComponent();
        }

        public FormHisPassInfo(string EmpID,string EmpName,string beginTime)
        {
            try
            {
                InitializeComponent();
                this.empName = EmpName;
                this.empID = Convert.ToInt32(EmpID);
                this.beginTime = beginTime;
                cpnlTop.CaptionTitle = "[ " + EmpName + " ]经过接受器信息";
            }
            catch(Exception ex)
            {
                MessageBox.Show("构造窗体失败，失败信息：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private DataTable GetEmpPassInfo()
        {
            if (bll == null)
                bll = new HisPathCheckBll();
            return bll.SelectEmpPassInfo(empID, Convert.ToDateTime(beginTime));
            
        }

        private void BandingInfo()
        {
            DataTable dt = GetEmpPassInfo();
            
            this.dgVMain.DataSource = dt;
        }

        private void HisPassInfo_Load(object sender, EventArgs e)
        {
            BandingInfo();
        }

        private void bcpPrint_Click(object sender, EventArgs e)
        {
            //FormPrint frm = new FormPrint();
            //frm.CallPrintForm(this.dgVMain, "[ " + empName + " ]经过接受器信息", "共" + dgVMain.Rows.Count.ToString()+"条信息");
            KJ128NDBTable.PrintBLL.Print(this.dgVMain, "[ " + empName + " ]经过接受器信息", "共" + dgVMain.Rows.Count.ToString() + "条信息");
        }
    }
}