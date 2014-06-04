using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using KJ128NDBTable;
using KJ128NModel;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class AddHistoryAttendance : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        InfoClassBLL icBLL = new InfoClassBLL();
        TimerIntervalBLL tiBLL = new TimerIntervalBLL();
        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        AddEmpBLL aeBLL = new AddEmpBLL();
        string strErr = string.Empty;
        HistoryAttendanceModel ham = new HistoryAttendanceModel();
        static int intPageIndex = 1;//页索引
        static int intPageCount = 0;//页总数
        static int intRowsCount = 0;//记录总条数
        static int intPerRows = 0;

        #endregion


        #region [ 构造函数 ]

        public AddHistoryAttendance()
        {
            InitializeComponent();
            icBLL.InfoClass_BindComboBox(ddlClass);
        }

        #endregion

        /*
         * 方法
         */

        #region [ 方法: 绑定多少行 ]

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

        #region [ 方法: 级联更新时段下拉列表内容 ]

        void BindDDLTimeerInterval(ComboBox cbClass, ComboBox cbTimerInterval, bool flag)
        {
            if (flag)
            {
                if (ddlClass.SelectedValue.ToString() != "0")
                {
                    tiBLL.BindComBoxAddAll(cbTimerInterval, "ClassID=" + cbClass.SelectedValue.ToString());
                }
                else
                {
                    tiBLL.BindComBoxAddAll(ddlTimerInterval, "");
                }
            }
            else
            {
                if (ddlClass.SelectedValue.ToString() != "0")
                {
                    tiBLL.BindComBox(cbTimerInterval, "ClassID=" + cbClass.SelectedValue.ToString());
                }
                else
                {
                    tiBLL.BindComBox(ddlTimerInterval, "");
                }
            }
        }

        #endregion

        #region [ 方法: 绑定DataGridView ]

        void BindDataDataGridView()
        {
            string strWhere = string.Empty;
            if (ddlDept.SelectedValue.ToString() != "0")
            {
                strWhere += " and D.DeptID = " + ddlDept.SelectedValue.ToString();
            }
            if (ddlTimerInterval.SelectedValue.ToString() != "0")
            {
                strWhere += " and H.TimerIntervalID = " + ddlTimerInterval.SelectedValue.ToString();
            }
            if (txtBlock.Text.Trim() != "")
            {
                try
                {
                    Convert.ToInt32(txtBlock.Text);
                }
                catch
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "发码器编号只能为数字!";
                }
                strWhere += " and H.BlockID = " + txtBlock.Text.ToString().Trim();
            }
            if (txtUserName.Text.Trim() != "")
            {
                strWhere += " and H.EmployeeName = '" + txtUserName.Text.Trim() + "'";
            }

            strWhere += " and H.DataAttendance>='" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "' and H.DataAttendance<='" + dtpEndTime.Value.ToString("yyyy-MM-dd") + "'";

            intPerRows = Convert.ToInt32(ddlRowsSet.SelectedValue.ToString());

            DataSet ds =new DataSet();//= aBLL.GetEmployeeAttendanceHistoryList(strWhere, intPageIndex, intPerRows, out strErr);

            if (ds != null)
            {
                dgrd.DataSource = ds.Tables[0];
                dgrd.Columns[2].Visible = false;
                dgrd.Columns[5].Visible = false;
                dgrd.Columns[6].Visible = false;
                dgrd.Columns[11].Visible = false;
                dgrd.Columns[12].Visible = false;
                dgrd.Columns[3].HeaderText = "发码器编号";
                dgrd.Columns[4].HeaderText = "员工姓名";
                dgrd.Columns[7].HeaderText = "所属部门";
                dgrd.Columns[8].HeaderText = "所属班次";
                dgrd.Columns[9].HeaderText = "上班时间";
                dgrd.Columns[10].HeaderText = "下班时间";
                dgrd.Columns[13].HeaderText = "记工日期";
                dgrd.Columns[0].DisplayIndex = 13;
                dgrd.Columns[1].DisplayIndex = 13;

                intRowsCount = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                intPageCount = intRowsCount / intPerRows;
                if (intRowsCount % intPerRows != 0)
                {
                    intPageCount++;
                }

                if (intPageCount == 0)
                {
                    intPageCount = 1;
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

                btnRowsCount.CaptionTitle = "共有" + intRowsCount.ToString() + "条记录";
                btnPageIndexAndPageCount.CaptionTitle = intPageIndex.ToString() + "/" + intPageCount.ToString();


            }
        }

        #endregion

        #region [ 方法: 显示隐藏控件 ]

        void ShowOrHidden(bool flag)
        {
            gbModify.Visible = flag;
            btnModifyAndAdd.Visible = flag;
            btnReturn.Visible = flag;
            cpModify.Visible = flag;
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void AddHistoryAttendance_Load(object sender, EventArgs e)
        {

            dBLL.getDeptAddAll(ddlDept);
            dBLL.getDept(ddlDeptAdd);
            icBLL.InfoClass_BindComboBox(ddlClass);
            icBLL.BindComboBoxAddEmpty(ddlClassAdd);
            BindDDLTimeerInterval(ddlClass,ddlTimerInterval,true);
            BindDDLTimeerInterval(ddlClassAdd, ddlTimerIntervalAdd, false);
            ShowOrHidden(false);
            BindRowsSet();
            this.ddlRowsSet.SelectedValue = "50";
            dtpBeginTimeAdd.Value = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"));
            dtpStartTime.Value = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dtpEndTimeAdd.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            BindDataDataGridView();
        }

        #endregion

        #region [ 事件: 班制下拉列表的选项更改事件 ]

        private void ddlClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindDDLTimeerInterval(ddlClass, ddlTimerInterval, true);
        }

        private void ddlClassAdd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindDDLTimeerInterval(ddlClass, ddlTimerInterval, false);
        }

        #endregion

        #region [ 事件: 补单按钮_Click事件 ]

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnModifyAndAdd.CaptionTitle = "添 加";
            ShowOrHidden(true);
        }

        #endregion

        #region [ 事件: 返回按钮_Click事件 ]

        private void btnReturn_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            ShowOrHidden(false);
        }

        #endregion

        #region [ 事件: 添加/修改按钮_Click事件 ]

        private void btnModifyAndAdd_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (this.txtBlockAdd.Text.Trim() == "")
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "卡号不能为空!";
                return;
            }

            if (this.ddlClassAdd.Items.Count == 0)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "没有班制，无法进行下一步的操作!";
                return;
            }

            if (ddlTimerIntervalAdd.Items.Count == 0)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "没有时段，无法进行下一步的操作!!";
                return;
            }

            if (this.ddlDeptAdd.Items.Count == 0)
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "没有部门，无法进行下一步的操作!!";
                return;
            }

            ham.BlockID = Convert.ToInt32(txtBlockAdd.Text.Trim());
            ham.EmployeeName = txtUserNameAdd.Text.Trim();
            ham.DeptID = Convert.ToInt32(ddlDeptAdd.SelectedValue.ToString());
            ham.ClassID = Convert.ToInt32(ddlClassAdd.SelectedValue.ToString());
            ham.TimerIntervalID = Convert.ToInt32(ddlTimerIntervalAdd.SelectedValue.ToString());
            ham.ClassShortName = ddlTimerIntervalAdd.Text.Trim();
            ham.BeginWorkTime = dtpBeginTimeAdd.Value.ToString();
            ham.EndWorkTime = dtpEndTimeAdd.Value.ToString();
            ham.DataAttendance = dtpDataAttendanceAdd.Value.ToString();
            ham.Remark = txtRemarkAdd.Text.Trim();
            ham.OperatorID = 0;
            
            if (btnModifyAndAdd.CaptionTitle == "添 加")
            {
                //存入日志
                LogSave.Messages("[AddHistoryAttendance]", LogIDType.UserLogID, "添加历史补单，部门编号为："
                    + ham.DeptID.ToString() + "，发码器编号：" + ham.BlockID.ToString() + "，员工姓名：" + ham.EmployeeName
                    + "，上班时间：" + ham.BeginWorkTime+ "。");

                aBLL.AddEmployeeAttendanceHistory(ham, out strErr);
                if (strErr == "Succeeds")
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "添加成功!";
                    txtUserNameAdd.Text = "";
                    txtBlockAdd.Text = "";

                    if (!New_DBAcess.IsDouble)
                    {
                        BindDataDataGridView();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
            else
            {
                //存入日志
                LogSave.Messages("[AddHistoryAttendance]", LogIDType.UserLogID, "修改历史补单，部门编号为："
                    + ham.DeptID.ToString() + "，发码器编号：" + ham.BlockID.ToString() + "，员工姓名：" + ham.EmployeeName
                    + "，上班时间：" + ham.BeginWorkTime + "。");

                aBLL.UpdateEmployeeAttendanceHistory(ham, out strErr);
                if (strErr == "Succeeds")
                {
                    lblErr.ForeColor = Color.Blue;
                    lblErr.Text = "修改成功!";

                    if (!New_DBAcess.IsDouble)
                    {
                        BindDataDataGridView();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
        }

        #endregion

        #region [ 事件: 员工姓名控件得到焦点事件 ]

        private void txtUserNameAdd_Enter(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Red;
            if (txtBlockAdd.Text == "")
            {
                lblErr.Text = "发码器编号不能为空!";
                return;
            }
            try
            {
                int intBlockID = Convert.ToInt32(txtBlockAdd.Text);
            }
            catch
            {

                lblErr.Text = "发码器编号只能为数字!";
                return;
            }

            DataSet ds = aeBLL.GetEmployeeNameByDeptIDAndCoderSenderID(Convert.ToInt32(ddlDeptAdd.SelectedValue), Convert.ToInt32(txtBlockAdd.Text));
            if (ds == null || ds.Tables[0].Rows.Count != 0)
            {
                txtUserNameAdd.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                txtUserNameAdd.Text = "";
            }
        }

        #endregion

        #region [ 事件: 查询按钮_Click事件 ]

        private void btnQuery_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            intPageIndex = 1;
            BindDataDataGridView();
        }

        #endregion

        #region [ 事件: 行数设置控件索引变化事件 ]

        private void ddlRowsSet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            intPageIndex = 1;
            BindDataDataGridView();
        }

        #endregion

        #region [ 事件: DataGridView单元格单击事件 ]

        private void dgrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Blue;
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                ham.ID_HistoryAttendance = Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtBlockAdd.Text = dgrd.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUserNameAdd.Text = dgrd.Rows[e.RowIndex].Cells[4].Value.ToString();
                ddlDeptAdd.SelectedValue = dgrd.Rows[e.RowIndex].Cells[5].Value.ToString();
                ddlClass.SelectedValue = dgrd.Rows[e.RowIndex].Cells[6].Value.ToString();
                ddlTimerIntervalAdd.Text = dgrd.Rows[e.RowIndex].Cells[8].Value.ToString();
                dtpBeginTimeAdd.Value = Convert.ToDateTime(dgrd.Rows[e.RowIndex].Cells[9].Value.ToString());
                dtpEndTimeAdd.Value = Convert.ToDateTime(dgrd.Rows[e.RowIndex].Cells[10].Value.ToString());
                dtpDataAttendanceAdd.Value = Convert.ToDateTime(dgrd.Rows[e.RowIndex].Cells[13].Value.ToString());
                ShowOrHidden(true);
                btnModifyAndAdd.CaptionTitle = "修 改";
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                if (MessageBox.Show("你确定要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[AddHistoryAttendance]", LogIDType.UserLogID, "删除历史补单，部门编号为："
                        + dgrd.Rows[e.RowIndex].Cells[5].Value.ToString()
                        + "，发码器编号：" + dgrd.Rows[e.RowIndex].Cells[3].Value.ToString() + "，员工姓名：" + dgrd.Rows[e.RowIndex].Cells[4].Value.ToString()
                        + "，上班时间：" + dgrd.Rows[e.RowIndex].Cells[9].Value.ToString() + "。");

                    aBLL.DeleteHistoryAttendance(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()), out strErr);
                    lblErr.Text = "删除成功!";


                    if (!New_DBAcess.IsDouble)
                    {
                        BindDataDataGridView();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
        }

        #endregion

        #region [ 事件: 上一页按钮_Click事件 ]

        private void btnPreview_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (intPageIndex > 1)
            {
                intPageIndex--;
            }
            BindDataDataGridView();
        }

        #endregion

        #region [ 事件: 下一页按钮_Click事件 ]
 
        private void btnNext_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (intPageIndex < intPageCount)
            {
                intPageIndex++;
            }
            BindDataDataGridView();
        }

        #endregion

        #region [ 事件: 跳转按钮_Click事件 ]

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


            BindDataDataGridView();
        }

        #endregion

        #region [ 事件: 重置按钮_Click事件 ]

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            txtBlock.Text = "";
            txtUserName.Text = "";
            dtpStartTime.Value = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            ddlDept.SelectedIndex = 0;
            ddlClass.SelectedIndex = 0;
            ddlTimerInterval.SelectedIndex = 0;
        }

        #endregion

        #region [热备定时刷新]

        /// <summary>
        /// 最大刷新次数
        /// </summary>
        private int maxTimes = 2;

        /// <summary>
        /// 查询刷新次数
        /// </summary>
        private int times = 0;

        /// <summary>
        /// 1表示 增加，修改 2 表示删除,3表示修改
        /// </summary>
        private int operated = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //刷最大次数(两次)
            if (times < maxTimes)
            {
                times++;

                //刷新
                BindDataDataGridView();
                timer1_Tick(sender, e);
            }
            else
            {
                times = 0;
                timer1.Stop();
            }
        }

        #endregion        

    }
}