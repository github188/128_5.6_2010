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
    public partial class AttendanceRealTime : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        static int intPageIndex = 1;//页索引
        static int intPageCount = 0;//页面总数
        static int intPageSize = 0;//每页行数
        string strErr = string.Empty;

        InfoClassBLL icBLL = new InfoClassBLL();
        TimerIntervalBLL tiBLL = new TimerIntervalBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        DeptBLL dBLL = new DeptBLL();
        HistoryAttendanceModel ham = new HistoryAttendanceModel();
        StationBLL sBLL = new StationBLL();

        #endregion


        #region [ 窗体构造 ]

        public AttendanceRealTime()
        {
            InitializeComponent();
        }

        #endregion

        /*
         * 方法
         */

        #region [ 方法: 显示/隐藏控件 ]

        void ShowOrHiddenControl(bool flag)
        {
            cpModify.Visible = flag;
            gbModify.Visible = flag;
            btnModify.Visible = flag;
            btnReturn.Visible = flag;
        }

        #endregion

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

        #region [ 方法: 绑定DataGridView ]

        void BindDataGridView()
        {
            int intRowsCount = 0;
            string strWhere = string.Empty;
            if (ddlDept.SelectedValue.ToString() != "0")
            {
                strWhere += " and RT.DeptID = " + ddlDept.SelectedValue.ToString();
            }

            if (ddlTimerInterval.SelectedValue.ToString() != "0")
            {
                strWhere += " and RT.TimerIntervalID = " + ddlTimerInterval.SelectedValue.ToString();
            }

            if (txtUserName.Text.Trim() != "")
            {
                strWhere += " and RT.EmployeeName = '" + txtUserName.Text.Trim() + "'";
            }

            if (txtBlock.Text.Trim() != "")
            {
                try
                {
                    Convert.ToInt32(txtBlock.Text.Trim());
                    strWhere += " and RT.BlockID =" + txtBlock.Text.Trim();
                }
                catch
                {
                    lblErr.ForeColor = Color.Red;
                    lblErr.Text = "发码器编号只能为数字!";
                    return;
                }
            }

            intPageSize = Convert.ToInt32(ddlRowsSet.SelectedValue.ToString());

            DataSet ds = aBLL.GetEmployeeAttendanceRealTime(strWhere, intPageIndex, intPageSize, out strErr);
            bool Flag = false;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][5].ToString() == "")
                {
                    aBLL.GetEmployeeAttendanceRealTimeDelete(int.Parse(ds.Tables[0].Rows[i][0].ToString()), out strErr);
                    Flag = true;
                }
            }

            if (Flag)
            {
                ds = aBLL.GetEmployeeAttendanceRealTime(strWhere, intPageIndex, intPageSize, out strErr);
            }
            if (ds != null)
            {
                dgrd.DataSource = ds.Tables[0];

                dgrd.Columns[3].Visible = false;
                dgrd.Columns[8].Visible = false;
                dgrd.Columns[9].Visible = false;
                dgrd.Columns[0].DisplayIndex = 8;
                dgrd.Columns[1].DisplayIndex = 8;
                dgrd.Columns[2].HeaderText = "发码器编号";
                dgrd.Columns[4].HeaderText = "员工姓名";
                dgrd.Columns[5].HeaderText = "所属部门";
                dgrd.Columns[6].HeaderText = "班次";
                dgrd.Columns[7].HeaderText = "下井时间";



                intRowsCount = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                intPageCount = intRowsCount / intPageSize;

                

                if (intRowsCount % intPageSize != 0)
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

        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void AttendanceRealTime_Load(object sender, EventArgs e)
        {
            
            ShowOrHiddenControl(false);
            BindRowsSet();
            ddlRowsSet.SelectedValue = "50";
            dBLL.getDeptAddAll(ddlDept);
            dBLL.getDept(ddlDeptAdd);
            icBLL.InfoClass_BindComboBox(ddlClass);
            icBLL.InfoClass_BindComboBox(ddlClassAdd);
            BindDDLTimeerInterval(ddlClass, ddlTimerInterval, true);
            BindDDLTimeerInterval(ddlClassAdd, ddlTimerIntervalAdd, false);
            sBLL.GetOutWellStationInfo(cbOutStation);
            BindDataGridView();
        }

        #endregion

        #region [ 事件: DataGridView单元格单击事件 ]

        private void dgrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                btnModify.Enabled = true;
                cpModify.Visible = true;
                gbModify.Visible = true;
                btnModify.Visible = true;
                btnReturn.Visible = true;
                ddlTimerIntervalAdd.Text = dgrd.Rows[e.RowIndex].Cells[6].Value.ToString();
                ddlDeptAdd.SelectedValue = dgrd.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUserNameAdd.Text = dgrd.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtBlockAdd.Text = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtpBeginTimeAdd.Value = Convert.ToDateTime(dgrd.Rows[e.RowIndex].Cells[7].Value.ToString());
                dtpEndTimeAdd.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                if (MessageBox.Show("你确定要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[AttendanceRealTime]", LogIDType.UserLogID, "删除实时考勤补单，部门编号为："
                        +  dgrd.Rows[e.RowIndex].Cells[3].Value.ToString() + "，发码器编号：" + dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()
                        + "，员工姓名：" + dgrd.Rows[e.RowIndex].Cells[4].Value.ToString()
                        + "，上班时间：" + dgrd.Rows[e.RowIndex].Cells[7].Value.ToString() + "。");

                    aBLL.GetEmployeeAttendanceRealTimeDelete(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()),out strErr);
                    if (strErr == "")
                    {
                        lblErr.ForeColor = Color.Blue;
                        lblErr.Text = "删除成功!";
                    }

                    if (!New_DBAcess.IsDouble)
                    {
                        BindDataGridView();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
        }

        #endregion

        #region [ 事件: 补单按钮的单击事件 ]

        private void btnModify_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";

            if (ddlClassAdd.SelectedValue.ToString() == "0")
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "班制不能选所有!";
                return;
                
            }
            if (ddlTimerIntervalAdd.SelectedValue.ToString() == "0")
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "时段不能选所有!";
                return;

            }

            ham.BlockID = Convert.ToInt32(txtBlockAdd.Text.Trim());
            ham.EmployeeName = txtUserNameAdd.Text;
            ham.DeptID = Convert.ToInt32(ddlDeptAdd.SelectedValue.ToString());
            ham.TimerIntervalID = Convert.ToInt32(ddlTimerIntervalAdd.SelectedValue.ToString());
            ham.ClassShortName = ddlTimerIntervalAdd.Text.ToString();
            ham.ClassID = Convert.ToInt32(ddlClassAdd.SelectedValue.ToString());
            ham.BeginWorkTime = dtpBeginTimeAdd.Value.ToString();
            ham.EndWorkTime = dtpEndTimeAdd.Value.ToString();
            ham.DataAttendance = dtpDataAttendanceAdd.Value.ToString();
            ham.Remark = txtRemark.Text.Trim();

            //存入日志
            LogSave.Messages("[AttendanceRealTime]", LogIDType.UserLogID, "实时考勤补单，部门编号为："
                + ham.DeptID.ToString() + "，发码器编号：" + ham.BlockID.ToString() + "，员工姓名：" + ham.EmployeeName
                + "，上班时间：" + ham.BeginWorkTime + "。");


            if (cbOutStation.Text == "无")
            {
                lblErr.Text = "<font color=red>出井分站不能选无!</font>";
                return;
            }

            string[] str =  this.cbOutStation.SelectedValue.ToString().Split(new char[] { ',' });
            aBLL.InertHistoryOutStationAndDeleteRealTimeInStation(ham.BlockID, Convert.ToDateTime(ham.EndWorkTime), Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), out strErr);

            //aBLL.GetEmployeeAttendanceRealTimeInsertAndDelete(ham, out strErr);
            if (strErr.ToString() == "Succeeds")
            {
                lblErr.ForeColor = Color.Blue;
                lblErr.Text = "补单成功!";
                btnModify.Enabled = false;

                if (!New_DBAcess.IsDouble)
                {
                    BindDataGridView();
                }
                else
                {
                    timer1.Start();
                }
                
            }
        }

        #endregion

        #region [ 事件: 返回按钮_Click事件 ]

        private void btnReturn_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            cpModify.Visible = false;
            gbModify.Visible = false;
            btnModify.Visible = false;
            btnReturn.Visible = false;
        }

        #endregion

        #region [ 事件: 查询按钮_Click事件 ]

        private void btnQuery_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            intPageIndex = 1;
            BindDataGridView();
        }

        #endregion

        #region [ 事件: 行数下拉列表索引变化事件 ]

        private void ddlRowsSet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblErr.Text = "";
            intPageIndex = 1;
            BindDataGridView();
        }

        #endregion

        #region [ 事件: 重置按钮_Click事件 ]

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBlock.Text = "";
            txtUserName.Text = "";
        }

        #endregion

        #region [ 事件: 上一页按钮_Click事件 ]

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (intPageIndex > 1)
            {
                intPageIndex--;
            }
            BindDataGridView();
        }

        #endregion

        #region [ 事件: 下一页按钮_Click事件 ]

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (intPageIndex < intPageCount)
            {
                intPageIndex++;
            }
            BindDataGridView();
        }
        #endregion

        #region [ 事件: 跳转按钮_Click事件 ]

        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
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
                BindDataGridView();
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