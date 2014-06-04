using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.FromModel;
using PrintCore;
using KJ128NDBTable;
using System.Threading;

namespace KJ128NMainRun.A_Statement
{
    public partial class A_FrmWorkExceptionStatement : FrmModel
    {
        #region[私有变量]

        private A_WorkExceptionStatementBLL bll = new A_WorkExceptionStatementBLL();

        #endregion

        #region[构造函数]

        public A_FrmWorkExceptionStatement()
        {
            InitializeComponent();
        }

        #endregion

        #region[私有方法]

        private void A_FrmWorkExceptionStatement_Load(object sender, EventArgs e)
        {
            //btnQery_Click(sender, e);
        }
        Thread th = null;
        private void btnQery_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            th = new Thread(SelectInfo);
            th.IsBackground = true;
            th.Start();
        }

       

        private void SelectInfo()
        {
            DateTime begin = Convert.ToDateTime(Convert.ToDateTime(dtpDate.Text + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss"));

            DateTime end = Convert.ToDateTime(Convert.ToDateTime(dtpDate.Text + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss"));

            DataSet ds = bll.SelectWorkExceptionStatementInfo(begin, end);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmWorkExceptionStatement";
                    if (this.IsHandleCreated)
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            this.dgvMain.DataSource = ds.Tables[0];
                        }));
                }
            }
            if (this.IsHandleCreated)
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            pictureBox2.Visible = false;
                        }));
            th.Abort();
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

        #region【Czlt-2010-12-23 导出】
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

        #region[打印导出]
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "特殊作业人员报警统计");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "特殊作业人员报警统计", "");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvMain != null && dgvMain.Rows.Count > 0)
            {
                //FormPrint printForm = new FormPrint();
                //printForm.CallPrintForm(this.dgvMain, dtpDate.Value.ToString("yyyy-MM-dd")+"日 特殊作业人员报警统计", "共" + this.dgvMain.Rows.Count.ToString() + "条记录");
                KJ128NDBTable.PrintBLL.Print(this.dgvMain, "特殊作业人员报警统计", "统计时间:" + dtpDate.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                MessageBox.Show("没有打印信息，请查询后打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
