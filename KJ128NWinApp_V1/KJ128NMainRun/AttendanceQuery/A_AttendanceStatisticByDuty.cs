using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
using KJ128NMainRun;
namespace KJ128NInterfaceShow
{
    public partial class AttendanceStatisticByDuty : KJ128NMainRun.FromModel.FrmModel
    {

        #region [ 声明 ]

        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        string strErr = string.Empty;

        #endregion

        #region [ 构造函数 ]

        public AttendanceStatisticByDuty()
        {
            InitializeComponent();
            base.Text = "各部门干部下井统计报表";
            base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            base.btnLaws.Hide();
            base.btnDelete.Hide();
            base.btnUpPage.Hide();
            base.lblPageCounts.Hide();
            base.lblSumPage.Hide();
            base.btnDownPage.Hide();
            base.txtSkipPage.Hide();
            base.cmbSelectCounts.Hide();
            base.label6.Hide();
            base.label7.Hide();
            base.label8.Hide();
            base.label9.Hide();
        }

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: DataGridView绑定函数 ]

        void BindDataGridView()
        {
            lblCounts.Text = "";
            if (txtBlock.Text.ToString() != "")
            {
                try
                {
                    Convert.ToInt32(txtBlock.Text);
                }
                catch
                {

                    lblCounts.ForeColor = Color.Red;
                    lblCounts.Text = "卡号只能为数字！";
                    return;
                }
            }
            #region 得到查询条件
            string strWhere = string.Empty;
            string strTime = string.Empty;

            strWhere = " and DataAttendance >='" + dtpStartTime.Text + "' and DataAttendance <='" + dtpEndTime.Text + "'";

            if (ddlDept.SelectedValue.ToString() != "0")
            {
                strTime = " en.DeptID =" + ddlDept.SelectedValue.ToString();
            }
            if (ddlDuty.SelectedValue.ToString() != "0")
            {
                if (strTime != "")
                {
                    strTime = strTime + " and en.DutyID =" + ddlDuty.SelectedValue.ToString();
                }
                else
                {
                    strTime = " en.DutyID =" + ddlDuty.SelectedValue.ToString();
                }
            }
            if (this.txtEmployeeName.Text.Trim() != "")
            {
                if (strTime != "")
                {
                    strTime = strTime + " and ei.EmpName like ('" + txtEmployeeName.Text.Trim() + "')";
                }
                else
                {
                    strTime = " ei.EmpName like ('" + txtEmployeeName.Text.Trim() + "')";
                }
            }
            if (txtBlock.Text.Trim() != "")
            {
                if (strTime != "")
                {
                    strTime = strTime + " and A.卡号 = " + txtBlock.Text.Trim();
                }
                else
                {
                    strTime = " A.卡号 = " + txtBlock.Text.Trim();
                }
            }
            if (strTime != "")
            {
                strTime = " where " + strTime;
            }
            #endregion
            strWhere += " And EmployeeID is not null ";
            DataSet ds = aBLL.GetAttendanceStatisticByDuty(strWhere, strTime, out strErr);

            if (strErr.ToString() == "Succeeds")
            {
                ds.Tables[0].Columns[1].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);

                dgrd.DataSource = ds.Tables[0];
               
                dgrd.AddSpanHeader(6, 3, "其 中");

                lblCounts.ForeColor = Color.Blue;
                lblCounts.Text = "共有 " + ds.Tables[0].Rows.Count.ToString() + " 条记录";
            }
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void AttendanceStatisticByDuty_Load(object sender, EventArgs e)
        {
           
            dtpStartTime.Text = DateTime.Now.ToString("yyyy-MM") + "-01";
            dtpEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dBLL.getDeptAddAll(ddlDept);
            dBLL.getDutyNameCmb(ddlDuty);
            BindDataGridView();
        }

        #endregion

        #region [ 事件: 查询按钮的单击事件 ]

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
                MessageBox.Show("结束时间不能大于当前时间，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BindDataGridView();
        }

        #endregion

        #region【事件：打印】

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgrd, "各干部下井统计", "共" + dgrd.Rows.Count.ToString() + "条记录");
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

        private void txtEmployeeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        


    }
}