using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.FromModel;
using KJ128NDBTable;
using System.Threading;

namespace KJ128NMainRun.A_Statement
{
    public partial class A_FrmLeadDayStatement : FrmModel
    {

        #region【声明】

        private A_StatementBLL Sbll = new A_StatementBLL();
        Thread th = null;
        private DataSet ds;

        #endregion

        #region【构造函数】

        public A_FrmLeadDayStatement()
        {
            InitializeComponent();

            dtp_Begin.Value = DateTime.Now.Date.AddDays(-1);
            pictureBox2.Visible = false;
            //Select_Info();
        }

        #endregion

        #region【方法：查询】

        private void Select_Info()
        {
            using (ds = new DataSet())
            {
                ds = Sbll.Get_LearderDayStatement(dtp_Begin.Value.ToString("yyyy-MM-dd"));
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    dt.Columns["员工编号"].ColumnName = "人员编号";
                    dt.Columns["姓名"].ColumnName = "人员姓名";
                    dt.TableName = "A_FrmLeadDayStatement";

                    if (dgv_Main.IsHandleCreated)
                    {
                        dgv_Main.Invoke(new MethodInvoker(delegate()
                        {
                            dgv_Main.DataSource = dt;
                        }));
                    }
                    if (lblCounts.IsHandleCreated)
                    {
                        lblCounts.Invoke(new MethodInvoker(delegate()
                        {
                            lblCounts.Text = "共 " + ds.Tables[0].Rows.Count.ToString() + " 条记录";
                        }));
                    }
                    //dgv_Main.DataSource = dt;

                    //lblCounts.Text = "共 " + ds.Tables[0].Rows.Count.ToString() + " 条记录";
                }
                else
                {
                    if (dgv_Main.IsHandleCreated)
                    {
                        dgv_Main.Invoke(new MethodInvoker(delegate()
                        {
                            dgv_Main.DataSource = null;
                        }));
                    }
                    if (lblCounts.IsHandleCreated)
                    {
                        lblCounts.Invoke(new MethodInvoker(delegate()
                        {
                            lblCounts.Text = "共 0 条记录";
                        }));
                    }
                    //dgv_Main.DataSource = null;

                    //lblCounts.Text = "共 0 条记录";
                }
            }
        }

        #endregion

        #region【事件：查询】

        private void bt_Enquiries_Click(object sender, EventArgs e)
        {
            if(dtp_Begin.Value>DateTime.Now)
            {
                MessageBox.Show("查询日期不能大于当前日期！","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return;
            }
            pictureBox2.Visible = true;
            bt_Enquiries.Enabled = false;
            th = new Thread(BingdingDGV);
            th.Start();
            
        }
        private void BingdingDGV()
        {
            Select_Info();
            if (this.IsHandleCreated)
            {
                pictureBox2.Invoke(new MethodInvoker(delegate()
                    {
                        pictureBox2.Visible = false;
                    }));
                bt_Enquiries.Invoke(new MethodInvoker(delegate()
                {
                    bt_Enquiries.Enabled = true;
                }));
            }
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

        #region 【事件：导出 - Czlt-2010-12-23】
        private void btnLaws_Click(object sender, EventArgs e)
        {
            if (dgv_Main != null && dgv_Main.Rows.Count > 0)
            {
                new PrintCore.ExportExcel().Sql_ExportExcel(this.dgv_Main, "");
            }
            else
            {
                MessageBox.Show("没有导出信息，请查询后导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, "领导干部日下井统计");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "领导干部日下井统计", "");
        }
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //领导干部日下井统计
            //KJ128NDBTable.PrintBLL.Print(dgv_Main, lblMainTitle.Text, dtp_Begin.Value.ToString("yyyy-MM-dd")+"下井情况 "+lblCounts.Text);
            if (dgv_Main != null && dgv_Main.Rows.Count > 0)
            {
                KJ128NDBTable.PrintBLL.Print(dgv_Main, "领导干部日下井统计", "统计时间:" + dtp_Begin.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                MessageBox.Show("没有打印信息，请查询后打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
        private void A_FrmLeadDayStatement_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                th.Abort();
            }
            catch { }
        }

    }
}
