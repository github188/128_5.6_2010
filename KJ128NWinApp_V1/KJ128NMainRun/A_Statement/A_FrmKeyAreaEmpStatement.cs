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
    public partial class A_FrmKeyAreaEmpStatement : FrmModel
    {
        #region【声明】

        private A_StatementBLL Sbll = new A_StatementBLL();

        private DataSet ds;

        #endregion


        #region【构造函数】

        public A_FrmKeyAreaEmpStatement()
        {
            InitializeComponent();

            dtp_Begin.Value = DateTime.Now.Date.AddDays(-1);
            //Select_Info();
        }

        #endregion

        #region【方法：查询】

        private void Select_Info()
        {
            using (ds = new DataSet())
            {
                ds = Sbll.Get_KeyAreaStatement(dtp_Begin.Value.ToString("yyyy-MM-dd"));
                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmKeyAreaEmpStateMent";
                    if (this.IsHandleCreated)
                        this.Invoke(new MethodInvoker(delegate()
                            {
                                dgv_Main.DataSource = ds.Tables[0];

                                lblCounts.Text = "共 " + ds.Tables[0].Rows.Count.ToString() + " 人";
                                pictureBox1.Visible = false;
                            }));

                }
                else
                {
                    if (this.IsHandleCreated)
                        this.Invoke(new MethodInvoker(delegate()
                            {
                                dgv_Main.DataSource = null;

                                lblCounts.Text = "共 0 人";
                                pictureBox1.Visible = false;
                            }));
                }
            }
            
            th.Abort();
        }

        #endregion


        #region【事件：查询】
        Thread th = null;
        private void bt_Enquiries_Click(object sender, EventArgs e)
        {
            if (dtp_Begin.Value > DateTime.Now)
            {
                MessageBox.Show("查询日期不能大于当前日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            pictureBox1.Visible = true;
            th = new Thread(Select_Info);
            th.IsBackground = true;
            th.Start();
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
            if (dgv_Main != null && dgv_Main.Rows.Count > 0)
            {
                new PrintCore.ExportExcel().Sql_ExportExcel(dgv_Main, "");
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
            excel.Sql_ExportExcel(dgv_Main, "重点区域人员统计");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "重点区域人员统计", "");
        }
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgv_Main != null && dgv_Main.Rows.Count > 0)
            {
                KJ128NDBTable.PrintBLL.Print(dgv_Main, "重点区域人员统计", "统计时间:" + dtp_Begin.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                MessageBox.Show("没有打印信息，请查询后打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
