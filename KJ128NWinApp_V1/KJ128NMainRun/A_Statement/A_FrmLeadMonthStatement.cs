using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.FromModel;
using KJ128NDBTable;
using PrintCore;
using System.Threading;

namespace KJ128NMainRun.A_Statement
{
    public partial class A_FrmLeadMonthStatement : FrmModel
    {

        #region[私有变量]

        private A_LeadMonthStatementBLL bll = new A_LeadMonthStatementBLL();
        DeptBLL dBLL = new DeptBLL();
        Thread th = null;
        #endregion

        #region[构造函数]

        public A_FrmLeadMonthStatement()
        {
            InitializeComponent();
        }

        #endregion

        #region[私有方法]

        private void A_FrmLeadMonthStatement_Load(object sender, EventArgs e)
        {
            //btnQery_Click(sender, e);
            dBLL.getDeptAddAll(cmbDept);
            dBLL.CzltGetDutyClassCmb(cmbDutyClass);
            pictureBox2.Visible = false;

        }

        private void btnQery_Click(object sender, EventArgs e)
        {
            if (!decidetime())
            {
                return;
            }
            pictureBox2.Visible = true;
            btnQery.Enabled = false;
            th = new Thread(BingdingDGV);
            th.Start();
        }
        private void BingdingDGV()
        {
            DataSet ds = SelectInfo();
            if (dgvMain.IsHandleCreated)
            {
                dgvMain.Invoke(new MethodInvoker(delegate()
                    {
                        BandingDataGridView(ds);
                    }));
            }
            if (this.IsHandleCreated)
            {
                pictureBox2.Invoke(new MethodInvoker(delegate()
                {
                    pictureBox2.Visible = false;
                }));
                btnQery.Invoke(new MethodInvoker(delegate()
                {
                    btnQery.Enabled = true;
                }));
            }
        }
        private bool decidetime()
        {
            TimeSpan ts1 = new TimeSpan(dtpDate.Value.Ticks);
            TimeSpan ts2 = new TimeSpan(dtpDate1.Value.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if ((int)ts.Days > 31)
            {
                MessageBox.Show("跨月查询不能多于三十一天！", "提示", MessageBoxButtons.OK);
                return false;
            }
            if ((dtpDate.Value.AddYears(1).Year == dtpDate1.Value.Year || dtpDate.Value.Year == dtpDate1.Value.Year) && ((dtpDate.Value.Month == dtpDate1.Value.Month) || (dtpDate.Value.AddMonths(1).Month == dtpDate1.Value.Month)))
            { }
            else
            {
                MessageBox.Show("不能跨多月份查询！", "提示", MessageBoxButtons.OK);
                return false;
            }
            if ((int)ts.Days > 31)
            {
                MessageBox.Show("跨月查询不能多于三十一天！", "提示", MessageBoxButtons.OK);
                return false;
            }
            if (Convert.ToDateTime(dtpDate1.Value) > DateTime.Now)
            {
                dtpDate1.Value = DateTime.Now;
            }
            if (Convert.ToDateTime(dtpDate.Value).Date > Convert.ToDateTime(dtpDate1.Value).Date)
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        

        private DataSet SelectInfo()
        {
            DateTime begin = Convert.ToDateTime(Convert.ToDateTime(dtpDate.Text + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss"));

            DateTime end = Convert.ToDateTime(Convert.ToDateTime(dtpDate1.Text + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss"));

            //Czlt-2011-06-11 选择部门
            string strDeptWhere = "";
            cmbDept.Invoke(new MethodInvoker(delegate()
            {
                if (cmbDept.SelectedIndex > 0)
                {
                    strDeptWhere = " and H.deptID = " + cmbDept.SelectedValue.ToString();
                }
                else
                {
                    strDeptWhere = " and 1=1 ";
                }
            }));
           

            //Czlt-2011-06-11 选择职务等级
            string strDutyClassWhere = "";
            cmbDutyClass.Invoke(new MethodInvoker(delegate()
            {
                if (cmbDutyClass.SelectedIndex > 0)
                {
                    strDutyClassWhere = " and  DutyClassID=" + cmbDutyClass.SelectedValue.ToString();
                }
                else
                {
                    strDutyClassWhere = " and DutyClassID < 6 ";
                }
            }));
            string strTime = "28800";
            cmbTime.Invoke(new MethodInvoker(delegate()
            {
                if (!cmbTime.Text.Trim().Equals(""))
                {
                    strTime = (Convert.ToInt32(cmbTime.Text.Trim()) * 3600).ToString();
                }
            }));
            DataSet ds = bll.CzltGetMonth(begin,end, strDeptWhere, strDutyClassWhere, strTime);
            //DataSet ds = bll.SelectLeadMonthStatementInfo(begin, end,strDeptWhere,strDutyClassWhere);

            return ds;
        }

        private void BandingDataGridView(DataSet ds)
        {
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmLeadMonthStatement_Load";
                    this.dgvMain.DataSource = ds.Tables[0];
                    this.lblCounts.Visible = true;
                    this.lblCounts.Text = "共有" + ds.Tables[0].Rows.Count + "条记录";
                }
                else
                {
                    DataTable dt = new DataTable("A_FrmLeadMonthStatement_BindDataGridView");
                    dt.Columns.Add("卡号");
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("所属部门");
                    dt.Columns.Add("职务");
                    dt.Columns.Add("出勤合计");
                    dt.Columns.Add("早班");
                    dt.Columns.Add("中班");
                    dt.Columns.Add("晚班");
                    dt.Columns.Add("跟班");
                    dt.Columns.Add("工作总时长");
                    dt.Columns.Add("平均时长");

                    this.dgvMain.DataSource = dt;
                    this.lblCounts.Text = "共有0条记录";
                }
            }
            catch
            {
                DataTable dt = new DataTable("A_FrmLeadMonthStatement_BindDataGridView");
                dt.Columns.Add("卡号");
                dt.Columns.Add("姓名");
                dt.Columns.Add("所属部门");
                dt.Columns.Add("职务");
                dt.Columns.Add("出勤合计");
                dt.Columns.Add("早班");
                dt.Columns.Add("中班");
                dt.Columns.Add("晚班");
                dt.Columns.Add("跟班");
                dt.Columns.Add("工作总时长");
                dt.Columns.Add("平均时长");

                this.dgvMain.DataSource = dt;
                this.lblCounts.Text = "共有0条记录";
            }
        }

        #endregion

        private IButtonControl IB = null;
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }
        #region 【Czlt-2010-12-23 导出】
        private void btnLaws_Click(object sender, EventArgs e)
        {
            if (dgvMain != null && dgvMain.Rows.Count > 0)
            {
                new PrintCore.ExportExcel().Sql_ExportExcel(dgvMain, "");
            }
            else
            {
                MessageBox.Show("没有导出信息，请查询后导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region[打印 导出]
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "领导干部月下井统计", "统计时间:" + dtpDate.Text + "--" + dtpDate1.Text);
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "领导干部月下井统计", "统计时间:" + dtpDate.Text + "--" + dtpDate1.Text);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvMain != null && dgvMain.Rows.Count > 0)
            {
                KJ128NDBTable.PrintBLL.Print(this.dgvMain, " 领导干部月下井统计", "统计时间:" + dtpDate.Value.ToString("yyyy-MM"));
            }
            else
            {
                MessageBox.Show("没有打印信息，请查询后打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        /// <summary>
        /// Czlt-2013-1-5 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            if (cmbTime.Text.Length == 1)
            {
                e.Handled = true;
            }
           
        }
    }
}
