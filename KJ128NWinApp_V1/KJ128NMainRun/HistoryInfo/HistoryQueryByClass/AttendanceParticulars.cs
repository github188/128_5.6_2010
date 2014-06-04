using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Collections;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class HistoryQueryByClass : Wilson.Controls.Docking.DockContent
    {
        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        InfoClassBLL icBLL = new InfoClassBLL();
        TimerIntervalBLL tiBLL = new TimerIntervalBLL();
        static int intPageIndex = 1;
        static int intPageSize = 0;
        static int intRowsCount = 0;
        static int intPageCount = 0;
        string strErr = string.Empty;

        #region 构造函数
        public HistoryQueryByClass()
        {
            InitializeComponent();

            label5.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
        }
        #endregion

        #region 窗体加载事件
        private void AttendanceParticulars_Load(object sender, EventArgs e)
        {
            dtpBeginTime.Value = Convert.ToDateTime(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dBLL.getDutyNameCmb(ddlDuty);
            dBLL.getDeptAddAll(ddlDept);
            icBLL.InfoClass_BindComboBox(cbClass);
            tiBLL.BindComBoxAddAll(cbTimerInterval, " ClassID ="+cbClass.SelectedValue.ToString());
            BindRowsSet();
            this.ddlRowsSet.SelectedValue = "50";
            BindDataGridView();
        }
        #endregion

        #region 绑定多少行
        void BindRowsSet()
        {
            ArrayList al = new ArrayList();
            for (int i = 1; i <= 10; i++)
            {
                int j = i * 10;

                al.Add(new ListItem(j.ToString(), "每页显示" + j.ToString() + "行"));
            }
            ddlRowsSet.DataSource = al;
            ddlRowsSet.DisplayMember = "Name";
            ddlRowsSet.ValueMember = "ID";
        }
        #endregion

        #region DataGridView数据绑定函数
        void BindDataGridView()
        {
            string strWhere = string.Empty;
            strWhere = " and substring(convert(char,DataAttendance,120),1,10) >='" + dtpBeginTime.Value.ToString("yyyy-MM-dd") + "' and substring(convert(char,DataAttendance,120),1,10) <='" + dtpEndTime.Value.ToString("yyyy-MM-dd") + "' ";
            if (ddlDept.SelectedValue.ToString() != "0")
            {
                strWhere += " and H.DeptID="+ddlDept.SelectedValue;
            }

            if (ddlDuty.SelectedValue.ToString() != "0")
            {
                strWhere += " and DI.DutyID=" + ddlDuty.SelectedValue;
            }

            if (txtUserName.Text.Trim() != "")
            {
                strWhere = " and H.EmployeeName = '"+txtUserName.Text.Trim()+"'";
            }
            if (cbTimerInterval.SelectedValue.ToString() != "0")
            {
                strWhere += " and H.TimerIntervalID = "+cbTimerInterval.SelectedValue.ToString();
            }
            try
            {
                if (txtBlock.Text.Trim() != "")
                {
                    Convert.ToInt32(txtBlock.Text.Trim());
                    strWhere += " and H.BlockID ="+txtBlock.Text.Trim();
                }
            }
            catch
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + "只能为数字!";
            }

            intPageSize = Convert.ToInt32(ddlRowsSet.SelectedValue.ToString());
            //DataSet ds = aBLL.GetEmployeeAttendanceParticulars(strWhere,intPageIndex,intPageSize,out strErr);

            //dgrd.DataSource = ds.Tables[0];

            dgrd.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
            dgrd.Columns[1].HeaderText = "员工姓名";
            dgrd.Columns[2].HeaderText = "所属部门";
            dgrd.Columns[3].HeaderText = "班次";
            dgrd.Columns[4].HeaderText = "所担职务";
            dgrd.Columns[5].HeaderText = "上班时间";
            dgrd.Columns[6].HeaderText = "下班时间";
            dgrd.Columns[7].HeaderText = "工作时长(分)";
            dgrd.Columns[8].HeaderText = "工数";
            dgrd.Columns[9].HeaderText = "记工日期";

            dgrd.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgrd.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            //intRowsCount = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());

            intPageCount = intRowsCount/intPageSize;
            if(intRowsCount%intPageSize !=0)
            {
                intPageCount++;
            }
            if(intPageCount == 0)
            {
                intPageCount=1;
            }

            if (intPageIndex == 1)
            {
                btnPreview.Enabled = false;
            }
            else
            {
                btnPreview.Enabled = true;
            }

            if (intPageIndex == intPageCount)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
            btnRowsCount.CaptionTitle = "共有" + intRowsCount.ToString() +"条记录";

            btnPageIndexAndPageCount.CaptionTitle = intPageIndex.ToString() + "/" + intPageCount;

        }
        #endregion

        #region 查询按钮的单击事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            intPageIndex = 1;
            BindDataGridView();
        }
        #endregion

        #region 行数设置下拉列表索引改变事件
        private void ddlRowsSet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblErr.Text = "";
            intPageIndex = 1;
            BindDataGridView();
        }
        #endregion

        #region 上一页按钮的单击事件
        private void btnPreview_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (intPageIndex > 1)
            {
                intPageIndex--;
            }
            BindDataGridView();
        }
        #endregion

        #region 下一页按钮的单击事件
        private void btnNext_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (intPageIndex < intPageCount)
            {
                intPageIndex++;
            }
            BindDataGridView();
        }
        #endregion

        #region 跳转按钮的单击事件
        private void btnJump_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Red;
            if (txtJump.Text.Trim() == "")
            {
                lblErr.Text = "跳转页数不能为空!";
                return;
            }
            if (txtJump.Text.Trim() == "0")
            {
                lblErr.Text = "跳转页数不能为零!";
                return;
            }

            try
            {
                Convert.ToInt32(txtJump.Text.Trim());
            }
            catch
            {
                lblErr.Text = "跳转页数只能为数字!";
                return;
            }

            if (Convert.ToInt32(txtJump.Text.Trim()) >= intPageCount)
            {
                intPageIndex = intPageCount;
                txtJump.Text = intPageCount.ToString();
            }
            else
            {
                intPageIndex = Convert.ToInt32(txtJump.Text);
            }


            BindDataGridView();
        }
        #endregion

        #region 重置按钮的单击事件
        private void btnReset_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            txtBlock.Text = "";
            txtUserName.Text = "";
        }
        #endregion

        #region [ 事件: 打印 ]

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgrd,Text);
            //DataGridViewKJ128 dgv = new DataGridViewKJ128();
            //dgv = dgrd;
            //ExcelExports.ExportDataGridViewToExcel(dgv);
        }

        #endregion
    }
}