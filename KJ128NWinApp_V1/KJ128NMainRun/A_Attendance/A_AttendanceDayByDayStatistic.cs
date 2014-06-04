using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NMainRun.A_Attendance
{
    public partial class A_AttendanceDayByDayStatistic : KJ128NMainRun.FromModel.FrmModel
    {
        #region [ 声明 ]

        string strErr = string.Empty;
        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        KJ128NDBTable.A_Attendance.A_AttendaceBLL bll = new KJ128NDBTable.A_Attendance.A_AttendaceBLL();
        #endregion

        #region [ 构造函数 ]

        public A_AttendanceDayByDayStatistic()
        {
            InitializeComponent();
            base.Text = "部门逐日考勤";
              base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            base.btnLaws.Hide();
            base.btnDelete.Hide();
            base.btnUpPage.Hide();
            base.lblPageCounts.Hide();
            base.lblSumPage.Hide();
            base.btnDownPage.Hide();
            base.label6.Hide();
            base.txtSkipPage.Hide();
            base.label7.Hide();
            base.label8.Hide();
            base.cmbSelectCounts.Hide();
            base.label9.Hide();
            lblCounts.Text = "";
            dtpStartTime.Value = Convert.ToDateTime(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            bindDeptCmb();
            BindDataGridView();

            panelLeftBottom.BringToFront();
        }

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: DataGridView数据绑定 ]

        void BindDataGridView()
        {
            string strWhere = string.Empty;
            if (ddlDept.SelectedValue.ToString() != "0")
            {
                strWhere += " and D.DeptID = " + ddlDept.SelectedValue.ToString();
            }

            DataSet ds = aBLL.GetEmployeeAttendanceDayByDayStatistic(dtpStartTime.Value.ToString("yyyy-MM-dd"), dtpEndTime.Value.ToString("yyyy-MM-dd"), strWhere, 1, 10000, out strErr);

            if (ds != null)
            {
                DataTable dt = new DataTable();

                dgrd.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    if (ds.Tables[0].Columns.Count == 6)
                    {
                        dgrd.AddSpanHeader(3, 3, ds.Tables[0].Columns[3].ColumnName.ToString());
                        dgrd.Columns[3].HeaderText = "出勤次数";
                        dgrd.Columns[4].HeaderText = "工时合计(分)";
                        dgrd.Columns[5].HeaderText = "均工时数(分)";
                    }
                    if (ds.Tables[0].Columns.Count == 9)
                    {
                        dgrd.AddSpanHeader(3, 3, ds.Tables[0].Columns[3].ColumnName.ToString());
                        dgrd.Columns[3].HeaderText = "出勤次数";
                        dgrd.Columns[4].HeaderText = "工时合计(分)";
                        dgrd.Columns[5].HeaderText = "均工时数(分)";
                        dgrd.AddSpanHeader(6, 3, ds.Tables[0].Columns[6].ColumnName.ToString());
                        dgrd.Columns[6].HeaderText = "出勤次数";
                        dgrd.Columns[7].HeaderText = "工时合计(分)";
                        dgrd.Columns[8].HeaderText = "均工时数(分)";
                    }
                    if (ds.Tables[0].Columns.Count == 12)
                    {
                        dgrd.AddSpanHeader(3, 3, ds.Tables[0].Columns[3].ColumnName.ToString());
                        dgrd.Columns[3].HeaderText = "出勤次数";
                        dgrd.Columns[4].HeaderText = "工时合计(分)";
                        dgrd.Columns[5].HeaderText = "均工时数(分)";
                        dgrd.AddSpanHeader(6, 3, ds.Tables[0].Columns[6].ColumnName.ToString());
                        dgrd.Columns[6].HeaderText = "出勤次数";
                        dgrd.Columns[7].HeaderText = "工时合计(分)";
                        dgrd.Columns[8].HeaderText = "均工时数(分)";
                        dgrd.AddSpanHeader(9, 3, ds.Tables[0].Columns[9].ColumnName.ToString());
                        dgrd.Columns[9].HeaderText = "出勤次数";
                        dgrd.Columns[10].HeaderText = "工时合计(分)";
                        dgrd.Columns[11].HeaderText = "均工时数(分)";
                    }
                }
            }
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void AttendanceDayByDayStatistic_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = Convert.ToDateTime(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
           
            BindDataGridView();
            lblCounts.Text = "";
        }

        #endregion

        #region [ 事件: 查询按钮_Click事件 ]

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (dtpStartTime.Text.Trim() == "" || dtpEndTime.Text.Trim() == "")
            {
                MessageBox.Show("开始和结束时间都不能为空！");
                return;
            }
            if (DateTime.Compare(DateTime.Parse(dtpStartTime.Text), DateTime.Parse(dtpEndTime.Text)) > 0)
            {
                MessageBox.Show("开始时间不能大于结束时间，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Compare(DateTime.Parse(dtpStartTime.Text), DateTime.Parse(dtpEndTime.Text)) > 7)
            {
                MessageBox.Show("开始时间和结束时间之间天数不能大于7天，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpEndTime.Value > DateTime.Now)
            {
                dtpEndTime.Value = DateTime.Now;
            }

            BindDataGridView();
        }

        #endregion


        private void bindDeptCmb()
        {
            ddlDept.DataSource = bll.Dept_Tree_Static();
            ddlDept.DisplayMember = "Name";
            ddlDept.ValueMember = "ID";
        }

        #region [ 事件: 打印 ]

        private void buttonCaptionPanel1_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgrd,Text);
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            new PrintCore.ExportExcel().Sql_ExportExcel(dgrd, "");
        }

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

    }
    }

