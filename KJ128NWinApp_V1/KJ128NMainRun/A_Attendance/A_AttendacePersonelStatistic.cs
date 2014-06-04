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
using System;
using KJ128NInterfaceShow;
using PrintCore;
using System.Threading;

namespace KJ128NMainRun.A_Attendance
{
    public partial class A_AttendacePersonelStatistic : KJ128NMainRun.FromModel.FrmModel
    {
         #region [ 声明 ]

        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        string strErr = string.Empty;
        KJ128NDBTable.A_Attendance.A_AttendaceBLL bll = new KJ128NDBTable.A_Attendance.A_AttendaceBLL();
        Thread th = null;
        private int pages = 1;
        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;   

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        //****************czlt-2010-8-24**start****************************************/
        //班次hash表
        Hashtable hashShift = new Hashtable();

        /// <summary>
        /// 班次逻辑对象
        /// </summary>
        private TimerIntervalBLL timerIntervalBll = new TimerIntervalBLL();

        int intTimeLong = 0;
        private string findType = "";
        //****************czlt-2010-8-24**start*****************************************/
        private bool isUnion = false;
        private string endWhere = "";

        #endregion


        #region [ 构造函数 ]

        public A_AttendacePersonelStatistic()
        {
            InitializeComponent();
            base.Text = "考勤人员统计";
            base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            //base.btnLaws.Hide();
            base.btnDelete.Hide();
            
            
            lblCounts.Text = "";
            dtpStartTime.Value=
            dtpStartTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            bindDeptCmb();

            //DataSet dsT=aBLL.GetEmployeeAttendancePersonelStatistic(dtpStartTime.Value.ToString("yyyy-MM-dd"), dtpEndTime.Value.ToString("yyyy-MM-dd"), " and 1=1", 1, 100000, out strErr);
            //int pages = 0;
            //if (dsT != null)
            //{
            //    pages = int.Parse(dsT.Tables[1].Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
            //}
            //lblSumPage.Text = @"/" + pages.ToString() + "页";
            //lblPageCounts.Text = "1";
            //BindDataGridView(1);

            cmbSelectCounts.Text = "40";
            panelLeftBottom.BringToFront();

            //czlt-2010-8-25-添加班次
            HashSetValue();
        }

        #endregion

        /*
         * 方法
         */


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

        #region [ 方法: DataGridView的数据绑定 ]
        string Where = string.Empty;
        private void where()
        {
            string strWhere = string.Empty;
            if (!txtUserName.Text.Trim().Equals(""))
                strWhere = " and H.EmployeeName like ('%" + txtUserName.Text + "%') ";

            if (ddlDept.SelectedValue != null)
            {
                if (ddlDept.SelectedValue.ToString() != "0")
                {
                    //strWhere += " and H.DeptID = " + ddlDept.SelectedValue.ToString();

                    string strValue = dBLL.GetValueOrIdByID(false, ddlDept.SelectedValue.ToString());
                    if (strValue != null && !strValue.Trim().Equals(""))
                    {
                        strWhere += " and H.DeptID in ('" + strValue + "')";
                    }
                }
            }

            if (txtBlock.Text.Trim() != "")
            {
                try
                {
                    
                    //Convert.ToInt32(txtBlock.Text);
                    //yc11
                    Convert.ToInt64(txtBlock.Text);
                    //yc12
                }
                catch
                {

                    //lblCounts.ForeColor = Color.Red;
                    lblCounts.Text = "发码器编号只能为数字!";
                    return;
                }
                strWhere += " and H.BlockID = " + txtBlock.Text.ToString().Trim();
            }

            if (strWhere.Equals(""))
                strWhere = " and 1=1";
           
            //************czlt-2011-03-07*Start*************
            if (chkAll.Checked)
            {
                findType = "";
                endWhere = "  1=1 ";
            }
            else
            {
                //if (radFull.Checked)
                //{
                //    findType = "1";
                //    endWhere = " worktime>= minsecTime ";
                //}
                //else if (radLast.Checked)
                //{
                //    findType = "2";
                //    endWhere = " worktime < minsecTime ";
                //}

                if (!numTimeLong.Text.Equals("0") && !numTimeLong.Text.Trim().Equals(""))
                {
                    intTimeLong = Convert.ToInt32(numTimeLong.Text) * 60;

                }
                if (radFull.Checked)
                {
                    findType = "1";
                    if (chkUnion.Checked == false)
                    {
                        strWhere += " and  H.workTime >=" + intTimeLong.ToString();
                    }
                    //Czlt-2012-3-30- 假如工作时长不为空的时候,按照输入的时间来查询
                    if (!numTimeLong.Text.Equals("0") && !numTimeLong.Text.Trim().Equals(""))
                    {
                        endWhere = " worktime>=" + intTimeLong.ToString();
                    }
                    else
                    {
                        endWhere = " worktime>= minsecTime ";
 
                    }
                }
                else if (radLast.Checked)
                {
                    findType = "2";
                    if (chkUnion.Checked == false)
                    {
                        strWhere += " and  H.workTime <" + intTimeLong.ToString();
                    }
                    //   //Czlt-2012-3-30- 假如工作时长不为空的时候,按照输入的时间来查询
                    if (!numTimeLong.Text.Equals("0") && !numTimeLong.Text.Trim().Equals(""))
                    {
                        endWhere = " worktime <" + intTimeLong.ToString();
                    }
                    else
                    {
                        endWhere = " worktime < minsecTime ";
 
                    }
                }
            }

            Where = strWhere;
            //是否合并考勤
            if (chkUnion.Checked)
            {
                isUnion = true;
            }
            else
            {
                isUnion = false;
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        void BindDataGridView()
        {
            int page = pages;

            //************czlt-2011-03-07*End*************


            //注销
            //DataSet ds = aBLL.GetEmployeeAttendancePersonelStatistic(dtpStartTime.Value.ToString("yyyy-MM-dd"), dtpEndTime.Value.ToString("yyyy-MM-dd"), strWhere, page, pSize, out strErr);

            //czlt-2011-10-18 考勤合并
            DataSet ds = aBLL.Czlt_GetEmployeeAttendancePersonelStatistic(isUnion, dtpStartTime.Value.ToString("yyyy-MM-dd"), dtpEndTime.Value.ToString("yyyy-MM-dd"), Where, page, pSize, endWhere, out strErr);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = new DataTable();

                    //更改名称 发码器->发码器编号
                    ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                    ds.Tables[0].TableName = "A_AttendancePersonelStatistic";
                    if (ds.Tables[0].Columns.Contains("跟班"))
                    {
                        ds.Tables[0].Columns.Remove("跟班");
                    }
                    dgrd.Invoke(new MethodInvoker(delegate()
                    {
                        dgrd.DataSource = ds.Tables[0];
                    }));


                    // 重新设置页数
                    int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                    sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                    countPage = sumPage;

                    if (sumPage == 0)
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            lblCounts.Text = "共 0 条记录";

                            lblPageCounts.Text = "1";
                            lblSumPage.Text = "/1页";

                            btnUpPage.Enabled = false;
                            btnDownPage.Enabled = false;
                        }));
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                            lblPageCounts.Text = page.ToString();
                            lblSumPage.Text = "/" + sumPage + "页";

                            //控制翻页状态
                            SetPageEnable(page, sumPage);
                        }));
                    }
                    //***************czlt-2010-8-24*start*************************************
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        if (ds.Tables[0].Columns.Count >= 9)
                        {
                            for (int i = 5; i < ds.Tables[0].Columns.Count; i++)
                            {
                                dgrd.Columns[i].DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 255);
                                // Font f = new Font("Tahoma",FontStyle.Underline);
                                //DataGridColumnStyle dgvStyle = new datagridviews
                                System.Windows.Forms.DataGridViewCellStyle dgvStyle = new System.Windows.Forms.DataGridViewCellStyle();
                                dgvStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                dgvStyle.ForeColor = Color.FromArgb(0, 0, 255);
                                dgvStyle.SelectionForeColor = Color.Red;
                                dgrd.Columns[i].DefaultCellStyle = dgvStyle;
                            }
                        }
                        if (dgrd.Columns["deptID"] != null)
                        {
                            dgrd.Columns["deptID"].Visible = false;
                        }
                    }));
                }
                else
                {
                    DataTable dt = new DataTable("A_AttendancePersonelStatistic_BindDataGridView");
                    dt.Columns.Add("部门名称");
                    dt.Columns.Add("班制");
                    dt.Columns.Add("出勤汇总");
                    dt.Columns.Add("早班汇总");
                    dt.Columns.Add("中班汇总");
                    dt.Columns.Add("晚班汇总");
                    dt.Columns.Add("请假汇总");
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        dgrd.DataSource = dt;
                        lblCounts.Text = "共 0 个人";
                    }));
                }

            }
            catch
            {
                DataTable dt = new DataTable("A_AttendancePersonelStatistic_BindDataGridView");
                dt.Columns.Add("部门名称");
                dt.Columns.Add("班制");
                dt.Columns.Add("出勤汇总");
                dt.Columns.Add("早班汇总");
                dt.Columns.Add("中班汇总");
                dt.Columns.Add("晚班汇总");
                dt.Columns.Add("请假汇总");
                this.Invoke(new MethodInvoker(delegate()
                    {
                        dgrd.DataSource = dt;
                        lblCounts.Text = "共 0 个人";
                    }));
            }
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void AttendacePersonelStatistic_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            //BindDataGridView(int.Parse(lblPageCounts.Text));
        }

        private void bindDeptCmb()
        {
            ddlDept.DataSource = bll.Dept_Tree_Static();
            ddlDept.DisplayMember = "Name";
            ddlDept.ValueMember = "ID";
        }

        #endregion

        #region [ 事件: 查询按钮_Click事件 ]

        private void BingdingDGV()
        {
            BindDataGridView();
            if (pictureBox2.IsHandleCreated)
            {
                pictureBox2.Invoke(new MethodInvoker(delegate()
                {
                    pictureBox2.Visible = false;
                }));
               this.Invoke(new MethodInvoker(delegate()
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                }));
            }

            th.Abort();
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //--czlt-开始时间大于当前时间的时候,把开始时间设置为当前时间
            if (dtpStartTime.Value > DateTime.Now)
            {
                dtpStartTime.Value = DateTime.Now;
            }

            //--czlt-结束时间大于当前时间的时候,把结束时间设置为当前时间

            TimeSpan ts1 = new TimeSpan(dtpStartTime.Value.Ticks);
            TimeSpan ts2 = new TimeSpan(dtpEndTime.Value.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if ((int)ts.Days > 31)
            {
                MessageBox.Show("跨月查询不能多于三十一天！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (dtpEndTime.Value > DateTime.Now)
            {
                dtpEndTime.Value = DateTime.Now;
            }

            if (dtpStartTime.Text.Trim() == "" || dtpEndTime.Text.Trim() == "")
            {
                MessageBox.Show("开始和结束时间都不能为空！");
                return;
            }
            if ((dtpStartTime.Value.AddYears(1).Year == dtpEndTime.Value.Year || dtpStartTime.Value.Year == dtpEndTime.Value.Year) && ((dtpStartTime.Value.Month == dtpEndTime.Value.Month) || (dtpStartTime.Value.Month == dtpEndTime.Value.AddMonths(-1).Month)))
            {
            }
            else
            {
                MessageBox.Show("不能跨两个或两个月份查询，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (DateTime.Compare(DateTime.Parse(dtpStartTime.Text), DateTime.Parse(dtpEndTime.Text)) > 0)
            {
                MessageBox.Show("开始时间不能大于结束时间，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (DateTime.Parse(dtpStartTime.Text).AddDays(7) < DateTime.Parse(dtpEndTime.Text))
            //{
            //    MessageBox.Show("开始时间和结束时间之间天数不能大于7天，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            where();
            pictureBox2.Visible = true;
            button2.Enabled = false;
            button3.Enabled = false;
            pages = 1;
            th = new Thread(BingdingDGV);
            th.Start();
            
        }

        #endregion

        #region [ 事件: 重置按钮_Click事件 ]

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBlock.Text = "";
            txtUserName.Text = "";
            dgrd.DataSource = new DataTable();
            lblCounts.Text = "共 0 条记录";
        }

          #endregion

       


        #region【事件：上一页】

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }
            pictureBox2.Visible = true;
            pages = page;
            th = new Thread(BingdingDGV);
            th.Start();
        }

        #endregion

        #region【事件：下一页】

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (page > countPage)
            {
                return;
            }

            pictureBox2.Visible = true;
            pages = page;
            th = new Thread(BingdingDGV);
            th.Start();
        }

        #endregion

        #region【事件：跳至】

        private void txtSkipPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    string value = txtSkipPage.Text;
                    if (value.CompareTo("") == 0)       //为空值时
                    {
                        return;
                    }
                    else if (int.Parse(value) > 0)
                    {
                        int page = int.Parse(value);
                        if (page > countPage)
                        {
                            page = countPage;
                        }
                        pictureBox2.Visible = true;
                        pages = page;
                        th = new Thread(BingdingDGV);
                        th.Start();
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        #endregion

        #region【事件：选择每页行数】
        
        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);
            pages = 1;
            BindDataGridView();
        }

        #region 【私有方法 czlt-2010-8-21】
        //*********************************开始************************************************/
        //为Hash表赋值
        private void HashSetValue()
        {
            DataTable dtTimeInterval = new DataTable();
            dtTimeInterval = timerIntervalBll.getTimeInterval("");
            if (dtTimeInterval.Rows.Count != 0)
            {
                for (int i = 0; i < dtTimeInterval.Rows.Count; i++)
                {
                    hashShift.Add(dtTimeInterval.Rows[i].ItemArray[1].ToString(), dtTimeInterval.Rows[i].ItemArray[0].ToString());
                }
            }
        }

        /// <summary>
        /// 点击单元格内的内容时候发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // string strValue = dgViewDept.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (e.RowIndex == -1)
                return;
            if (e.ColumnIndex == -1)
                return;
            string strHeardValue = dgrd.Columns[e.ColumnIndex].HeaderText.ToString();
            string deptid = dgrd.Rows[e.RowIndex].Cells[2].Value.ToString();
            string cardid = dgrd.Rows[e.RowIndex].Cells[0].Value.ToString();
            string startTime = dtpStartTime.Value.ToString("yyyy-MM-dd");
            string endTime = dtpEndTime.Value.ToString("yyyy-MM-dd");
            string empName = dgrd.Rows[e.RowIndex].Cells[1].Value.ToString();
            string deptName = dgrd.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            string cellText = dgrd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (!cellText.Equals("0"))
            {
                // dgrd.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "点击数字可以查看明细!";
                if (hashShift.ContainsKey(strHeardValue))
                {
                    //this.Cursor = Cursors.Hand;
                    string shiftid = hashShift[strHeardValue].ToString();

                    AttendanceParticulars frmAP = new AttendanceParticulars(deptName, deptid, cardid, shiftid, startTime, endTime, empName, findType, intTimeLong.ToString(),isUnion);
                    frmAP.ShowDialog();
                }
                else if (strHeardValue.Equals("出勤合计"))
                {
                    //string shiftid = hashShift[strHeardValue].ToString();
                    //this.Cursor = Cursors.Hand;

                    AttendanceParticulars frmAP = new AttendanceParticulars(deptName, deptid, cardid, "", startTime, endTime, empName, findType, intTimeLong.ToString(),isUnion);
                    frmAP.ShowDialog();
                }
                else if (strHeardValue.Equals("跟班"))
                {
                    //this.Cursor = Cursors.Hand;
                    //KJ128NMainRun.AttendanceInfoSet.NewHolidayTypeSet holidaySet = new KJ128NMainRun.AttendanceInfoSet.NewHolidayTypeSet(deptName, deptid, cardid, startTime, endTime, dtpStartTime.Value.ToString("yyyyM"), empName);
                    AttendanceParticulars frmAP = new AttendanceParticulars(deptName, deptid, cardid, "跟班", startTime, endTime, empName, findType, intTimeLong.ToString(), isUnion);

                    frmAP.ShowDialog();
                }

            }

        }


        /// <summary>
        /// Czlt-2010-10-19 - 鼠标指针离开单元格时候发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrd_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Czlt2010-10-19 鼠标指针移过单元格时候发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrd_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;

            string strHeardValue = dgrd.Columns[e.ColumnIndex].HeaderText.ToString();
            string cellText = dgrd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (!cellText.Equals("0"))
            {
                if (hashShift.ContainsKey(strHeardValue))
                {
                    this.Cursor = Cursors.Hand;
                    dgrd.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "点击数字可以查看明细!";
                }
                else if (strHeardValue.Equals("出勤合计"))
                {
                    this.Cursor = Cursors.Hand;
                    dgrd.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "点击数字可以查看明细!";
                }
                else if (strHeardValue.Equals("请假"))
                {
                    this.Cursor = Cursors.Hand;
                    dgrd.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "点击数字可以查看明细!";
                }
                else if (strHeardValue.Equals("跟班"))
                {
                    this.Cursor = Cursors.Hand;
                    dgrd.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "点击数字可以查看明细!";
                }

            }
        }

        #endregion 【私有方法 czlt-2010-8-21】

        private void btnLaws_Click(object sender, EventArgs e)
        {
            if (dgrd != null && dgrd.Rows.Count > 0)
            {
                DataTable dt =(DataTable)dgrd.DataSource;
                if (dt.Columns.Contains("deptid"))
                {
                    dt.Columns["deptid"].ColumnName = "部门编号";

                    dgrd.Columns["部门编号"].Visible = false;
                }

                new PrintCore.ExportExcel().Sql_ExportExcel(dgrd, "");
            }
            else
            {
                MessageBox.Show("没有导出数据，请查询后导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region 【Czlt-2011-03-07-考勤人员工具满工设置】
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                grpMessage.Enabled= false;
            }
            else
            {
                grpMessage.Enabled = true;
            }

        }
        #endregion

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        /// <summary>
        /// Czlt-2011-10-18 是否启用考勤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkUnion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnion.Checked)
            {
                isUnion = true;
            }
            else 
            {
                isUnion = false;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel excel = new ExportExcel();
            excel.Sql_ExportExcel(dgrd, "考勤人员统计信息", "统计时间:" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
       
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgrd, "考勤人员统计信息", "统计时间:" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgrd != null && dgrd.Rows.Count > 0)
            {

                KJ128NDBTable.PrintBLL.Print(dgrd, "考勤人员统计信息", "统计时间:" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                MessageBox.Show("未查询考勤统计信息，请查询后导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 

        private void A_AttendacePersonelStatistic_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                th.Abort();
            }
            catch { }
        }




    }
}
