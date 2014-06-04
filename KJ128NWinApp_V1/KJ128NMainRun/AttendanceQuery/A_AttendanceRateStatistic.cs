using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;

namespace KJ128NInterfaceShow
{
    public partial class AttendanceRateStatistic :KJ128NMainRun.FromModel.FrmModel
    {

        #region [ 声明 ]

        string strErr = string.Empty;
       
        AttendanceBLL aBLL = new AttendanceBLL();

        #endregion


        #region [ 构造函数 ]

        public AttendanceRateStatistic()
        {
            InitializeComponent();
            base.Text = "部门人员出勤率统计";
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
            base.lblCounts.Hide();
            lblCounts.Text = "";

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

            DataSet ds = aBLL.GetEmployeeAttendanceRateStatistic(dtpStartTime.Value.ToString("yyyy-MM-dd"), dtpEndTime.Value.ToString("yyyy-MM-dd"), out strErr);

            if (ds != null)
            {
                DataTable dt = new DataTable();

                dgrd.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    if (ds.Tables[0].Columns.Count == 4)
                    {
                        dgrd.AddSpanHeader(2, 2, ds.Tables[0].Columns[2].ColumnName.ToString());
                        dgrd.Columns[2].HeaderText = "出勤次数";
                        dgrd.Columns[3].HeaderText = "均工时数(时)";
                    }
                    if (ds.Tables[0].Columns.Count == 6)
                    {
                        dgrd.AddSpanHeader(2, 2, ds.Tables[0].Columns[2].ColumnName.ToString());
                        dgrd.Columns[2].HeaderText = "出勤次数";
                        dgrd.Columns[3].HeaderText = "均工时数(时)";
                        dgrd.AddSpanHeader(4, 2, ds.Tables[0].Columns[4].ColumnName.ToString());
                        dgrd.Columns[4].HeaderText = "出勤次数";
                        dgrd.Columns[5].HeaderText = "均工时数(时)";
                    }
                    if (ds.Tables[0].Columns.Count == 8)
                    {
                        dgrd.AddSpanHeader(2, 2, ds.Tables[0].Columns[2].ColumnName.ToString());
                        dgrd.Columns[2].HeaderText = "出勤次数";
                        dgrd.Columns[3].HeaderText = "均工时数(时)";
                        dgrd.AddSpanHeader(4, 2, ds.Tables[0].Columns[4].ColumnName.ToString());
                        dgrd.Columns[4].HeaderText = "出勤次数";
                        dgrd.Columns[5].HeaderText = "均工时数(时)";
                        dgrd.AddSpanHeader(6, 2, ds.Tables[0].Columns[6].ColumnName.ToString());
                        dgrd.Columns[6].HeaderText = "出勤次数";
                        dgrd.Columns[7].HeaderText = "均工时数(时)";
                    }
                }
            }
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void AttendanceRateStatistic_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = Convert.ToDateTime(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            BindDataGridView();
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

        #region [ 事件: 打印 ]

        //private void buttonCaptionPanel4_Click(object sender, EventArgs e)
        //{
        //    PrintBLL.Print(dgrd,Text);
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgrd, Text, "共" + dgrd.Rows.Count.ToString() + "条记录");
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

        private void button3_Click(object sender, EventArgs e)
        {
            new PrintCore.ExportExcel().Sql_ExportExcel(dgrd, "");
        }

  
    }
}