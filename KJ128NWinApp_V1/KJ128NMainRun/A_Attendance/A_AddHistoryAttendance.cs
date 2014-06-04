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
using System.Web.UI.WebControls;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.A_Attendance
{
    public partial class A_AddHistoryAttendance :KJ128NMainRun.FromModel.FrmModel
    {
        KJ128NDBTable.A_Attendance.A_AttendaceBLL bll = new KJ128NDBTable.A_Attendance.A_AttendaceBLL();
        #region [ 声明 ]

        InfoClassBLL icBLL = new InfoClassBLL();
        TimerIntervalBLL tiBLL = new TimerIntervalBLL();
        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        AddEmpBLL aeBLL = new AddEmpBLL();
        string strErr = string.Empty;
        HistoryAttendanceModel ham = new HistoryAttendanceModel();

        private int intPageIndex = 1;//页索引
        private int intPageCount = 0;//页面总数
        private int intPageSize = 40;//每页行数

        string[] str = null;
        #endregion
        private string id;
        public string _id
        {
            get { return id; }
            set { id = value; }
        }

        private bool isAdd;
        public bool _isAdd
        {
            get { return isAdd; }
            set { isAdd = value; }
        }

        #region【构造函数】

        public A_AddHistoryAttendance()
        {
            InitializeComponent();
            base.Text = "历史补单";
            loadTree();
            tiBLL.BindComBoxAddAll(ddlTimerInterval, "1=1");
            this.cmbSelectCounts.Items.Add("全部");
            //base.cmbSelectCounts.SelectedValue = "50";
            base.lblMainTitle.Hide();
            dtpStartTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            lblCounts.Text = "";
            lblPageCounts.Text = "1";
            //cmbSelectCounts.SelectedIndex = 0;
            cmbSelectCounts.Text = "40";
            maxTimes = RefReshTime.intHostBackRefCount;
            timerHostBack.Interval = RefReshTime.intHostBackRefTime;
        }

        #endregion

        private void loadTree()
        {
            DeptTree.Nodes.Clear();
            DataTable dt = bll.Dept_Tree_Static();
            DeptTree.DataSouce = dt;
            DeptTree.LoadNode("");
            DeptTree.ExpandAll();
        }

        #region [ 方法: 绑定多少行 ]

        void BindRowsSet()
        {
            ArrayList al = new ArrayList();
            for (int i = 1; i <= 10; i++)
            {
                int j = i * 10;

                al.Add(new KJ128NInterfaceShow.ListItem(j.ToString(), j.ToString()));
            }

            cmbSelectCounts.DataSource = al;
            //cmbSelectCounts.DisplayMember = "Name";
            //cmbSelectCounts.ValueMember = "ID";
            //cmbSelectCounts.SelectedText
        }

        #endregion

        #region [ 事件: 行数下拉列表索引变化事件 ]

        private void ddlRowsSet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSelectCounts.Text.Trim() == "全部")
                intPageSize = 9999999;
            else
                intPageSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);
            lblCounts.Text = "";
            intPageIndex = 1;
            BindDataDataGridView();

        }

        #endregion

        #region【事件：重置】

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBlock.Text = "";
            txtUserName.Text = "";
            dtpStartTime.Value = DateTime.Now.Date;
            dtpEndTime.Value = DateTime.Now;
            ddlTimerInterval.SelectedIndex = 0;
            dgrd.DataSource = null;
        }

        #endregion

        #region【事件：上一页】

        private void btnPreview_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }
            intPageIndex = page;

            BindDataDataGridView();
        }

        #endregion

        #region【事件：下一页】

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;
            if (page > intPageCount)
            {
                return;
            }
            intPageIndex = page;
            BindDataDataGridView();
        }
        #endregion

        #region【事件：跳至】

        private void txtSkipPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string value = txtSkipPage.Text;
                if (value.CompareTo("") == 0)       //为空值时
                {
                    return;
                }
                else if (int.Parse(value) > 0)
                {
                    int page = int.Parse(value);
                    if (page > intPageCount)
                    {
                        page = intPageCount;
                    }
                    intPageIndex = page;
                    BindDataDataGridView();
                }
            }
        }

        #endregion

        #region【方法：控制翻页状态】

        private void SetPageEnable(int pIndex, int sumPage)
        {
            if (pIndex == 1)
            {
                if (sumPage == 1)
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = true;
                }
            }
            else if (pIndex >= sumPage)
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = false;
            }
            else
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = true;
            }
        }

        #endregion

        #region [ 方法: 绑定DataGridView ]

        void BindDataDataGridView()
        {
            string strWhere =string.Empty;
            if (DeptTree.SelectedNode!= null)
            {
                if (DeptTree.SelectedNode.Name != "0")
                {
                    strWhere += " and D.DeptID = " + DeptTree.SelectedNode.Name;
                }
            }
            if (ddlTimerInterval.SelectedValue.ToString().Trim() != "0")
            {
                strWhere += " and H.TimerIntervalID = " + ddlTimerInterval.SelectedValue.ToString();
            }
            if (txtBlock.Text.Trim() != "")
            {
                strWhere += " and H.BlockID = " + txtBlock.Text.ToString().Trim();
            }
            if (txtUserName.Text.Trim() != "")
            {
                strWhere += " and H.EmployeeName like '%" + txtUserName.Text.Trim() + "%'";
            }

            strWhere += " and H.DataAttendance>='" + dtpStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and H.DataAttendance<='" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            //if (cmbSelectCounts.Text.ToString() == "")
            //{
            //    intPageSize = 20;
            //}
            //else
            //{

            //    intPageSize = Convert.ToInt32(cmbSelectCounts.SelectedItem.ToString());
            //}


            DataSet ds = aBLL.GetEmployeeAttendanceHistoryList(strWhere, intPageIndex, intPageSize, dtpStartTime.Value.ToString("yyyyM"), dtpEndTime.Value.ToString("yyyyM"), out strErr);

            if (ds != null && ds.Tables.Count>0)
            {
                 // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % intPageSize != 0 ? sumPage / intPageSize + 1 : sumPage / intPageSize;
                intPageCount = sumPage;

                if (sumPage == 0)
                {
                    dgrd.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    ds.Tables[0].TableName = "A_AddHistoryAttendance";
                    dgrd.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                    lblPageCounts.Text = intPageIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(intPageIndex, sumPage);
                }

                if (dgrd.Columns.Count >= 9)
                {
                    int width = (dgrd.Width - 50 - 2) / (dgrd.Columns.Count - 6);

                    dgrd.Columns[1].Visible = false;
                    dgrd.Columns[2].HeaderText = "卡号";
                    dgrd.Columns[2].ReadOnly = true;
                    dgrd.Columns[2].Width = width;
                    dgrd.Columns[3].HeaderText = "姓名";
                    dgrd.Columns[3].ReadOnly = true;
                    dgrd.Columns[3].Width = width;
                    dgrd.Columns[4].Visible = false;
                    dgrd.Columns[5].Visible = false;
                    dgrd.Columns[6].HeaderText = "部门";
                    dgrd.Columns[6].ReadOnly = true;
                    dgrd.Columns[6].Width = width;
                    dgrd.Columns[7].HeaderText = "班次";
                    dgrd.Columns[7].ReadOnly = true;
                    dgrd.Columns[7].Width = width;
                    dgrd.Columns[8].HeaderText = "上班时间";
                    dgrd.Columns[8].ReadOnly = true;
                    dgrd.Columns[8].Width = width;
                    dgrd.Columns[9].HeaderText = "下班时间";
                    dgrd.Columns[9].ReadOnly = true;
                    dgrd.Columns[9].Width = width;
                    dgrd.Columns[10].Visible = false;
                    dgrd.Columns[11].Visible = false;
                    dgrd.Columns[12].HeaderText = "记工时间";
                    dgrd.Columns[12].ReadOnly = true;
                    dgrd.Columns[12].Width = width;
                }
            }
        }

        #endregion

        private void A_AddHistoryAttendance_Load(object sender, EventArgs e)
        {
            //BindDataDataGridView();
        }

        #region【事件：查询】

        private void btnEnquiries_Click(object sender, EventArgs e)
        {

            if (dtpStartTime.Text.Trim() == "" || dtpEndTime.Text.Trim() == "")
            {
                MessageBox.Show("开始和结束时间都不能为空，请选择");
                return;
            }

            if (((Convert.ToInt16(dtpStartTime.Value.Year) == Convert.ToInt16(dtpEndTime.Value.Year) - 1 && Convert.ToInt16(dtpStartTime.Value.Month) == 12 && Convert.ToInt16(dtpEndTime.Value.Month) == 1)) || (dtpStartTime.Value.Year == dtpEndTime.Value.Year && ((dtpStartTime.Value.Month == dtpEndTime.Value.Month) || (dtpStartTime.Value.Month == dtpEndTime.Value.AddMonths(-1).Month))))
            {
            }
            else
            {
                MessageBox.Show("不能跨两个以上月份查询数据，请重新选择！", "提示", MessageBoxButtons.OK);
                return;
            }
            TimeSpan ts1 = new TimeSpan(dtpStartTime.Value.Ticks);
            TimeSpan ts2 = new TimeSpan(dtpEndTime.Value.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if ((int)ts.Days > 31)
            {
                MessageBox.Show("跨月查询不能多于三十一天！", "提示", MessageBoxButtons.OK);
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

            lblCounts.Text = "";
            intPageIndex = 1;
            BindDataDataGridView();
        }

        #endregion


        #region【事件：修改】

        private void btnLaws_Click(object sender, EventArgs e)
        {
            isAdd = false;
            int a = 0;
            int b = 0;
            if (dgrd.Rows.Count>0)
            {
                for (int j = 0; j < dgrd.Rows.Count; j++)
                {
                    if (((DataGridViewCheckBoxCell)dgrd.Rows[j].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgrd.Rows[j].Cells[0]).TrueValue)
                    {
                        a = a + 1;
                        b = j;
                    }
                }
                if (a != 0)
                {
                    if (a > 1)
                    {

                        MessageBox.Show("修改只能选择一项！","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        if (dgrd.Rows[b].Cells[1].Value != null)
                        {
                            id = dgrd.Rows[b].Cells[1].Value.ToString();
                        }
                        else
                        {
                            id = "";
                        }
                        A_AddHistoryAttendance_Add Afr = new A_AddHistoryAttendance_Add(this);
                        Afr.ShowDialog();
                        //DialogResult dr = Afr.ShowDialog();
                        //if (dr == DialogResult.OK)
                        //{
                        //    BindDataDataGridView();
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("没有选择修改项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        #endregion

       

        private void DeptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (dtpStartTime.Text.Trim() == "" || dtpEndTime.Text.Trim() == "")
            {
                MessageBox.Show("开始和结束时间都不能为空，请选择");
                return;
            }

            if (dtpStartTime.Value.Year == dtpEndTime.Value.Year && ((dtpStartTime.Value.Month == dtpEndTime.Value.Month) || (dtpStartTime.Value.Month == dtpEndTime.Value.AddMonths(-1).Month)))                
            {
            }
            else
            {
                MessageBox.Show("不能跨两个以上月份查询数据，请重新选择！", "提示", MessageBoxButtons.OK);
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

            intPageIndex = 1;
            BindDataDataGridView();
        }

        private void txtSkipPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Enter)
            {
                lblCounts.Text = "";
                lblCounts.ForeColor = Color.Red;

                if (txtSkipPage.Text.Trim() == "")
                {
                    lblCounts.Text = "跳转页数不能为空!";
                    return;
                }
                if (txtSkipPage.Text.Trim() == "0")
                {
                    lblCounts.Text = "跳转页数不能为零!";
                    return;
                }

                try
                {
                    Convert.ToInt32(txtSkipPage.Text.Trim());
                }
                catch
                {
                    lblCounts.Text = "跳转页数只能为数字!";
                    return;
                }

                if (Convert.ToInt32(txtSkipPage.Text.Trim()) >= intPageCount)
                {
                    intPageIndex = intPageCount;
                    txtSkipPage.Text = intPageCount.ToString();
                }
                else
                {
                    intPageIndex = Convert.ToInt32(txtSkipPage.Text);
                }


                BindDataDataGridView();
            }
        }

        #region【事件：补单】

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            A_AddHistoryAttendance_Add Afr = new A_AddHistoryAttendance_Add(this);
            Afr.ShowDialog();
        }

        #endregion

        #region【热备刷新】

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

        public void RefreshBackUp()
        {
            if (!New_DBAcess.IsDouble)
            {
                BindDataDataGridView();
            }
            else
            {
                times = 0;
                timerHostBack.Start();
            }
        }

        private void timerHostBack_Tick(object sender, EventArgs e)
        {
            //刷最大次数(两次)
            if (times < maxTimes)
            {
                times++;

                //刷新
                BindDataDataGridView();
            }
            else
            {
                times = 0;
                timerHostBack.Stop();
            }
        }
        #endregion        


        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        private System.Windows.Forms.IButtonControl IB = null;
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }

        #region [删除]
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDeleteflag = true;
            string strErr="";
            if (dgrd.Rows.Count > 0)
            {
                for (int j = 0; j < dgrd.Rows.Count; j++)
                {
                    if (((DataGridViewCheckBoxCell)dgrd.Rows[j].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgrd.Rows[j].Cells[0]).TrueValue)
                    {
                        isDeleteflag = false;
                        aBLL.DeleteHistoryAttendance(Int64.Parse(dgrd.Rows[j].Cells[1].Value.ToString()),int.Parse(dgrd.Rows[j].Cells[2].Value.ToString()),"", DateTime.Parse(dgrd.Rows[j].Cells["dataAttendance"].Value.ToString()), out strErr);

                        RefreshBackUp();
                    }
                }
                if (isDeleteflag)
                {
                    MessageBox.Show("没有选择要删除的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        #endregion

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgrd, "历史补单");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgrd, "历史补单", "");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgrd, "历史补单", "共" + dgrd.Rows.Count.ToString() + "条记录");
        }
    }
}
