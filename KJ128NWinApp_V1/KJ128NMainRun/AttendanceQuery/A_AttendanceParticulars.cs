using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Collections;
using System.Threading;
using KJ128NMainRun;
using PrintCore;

namespace KJ128NInterfaceShow
{
    public partial class AttendanceParticulars : KJ128NMainRun.FromModel.FrmModel
    {

        #region [ 声明 ]


        delegate void ThreadBindData();

        Thread th = null;

        private string StrWhere = string.Empty;


        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        static int intPageIndex = 1;
        static int intPageSize = 0;
        static int intRowsCount = 0;
        static int intPageCount = 0;
        string strErr = string.Empty;

        //*****czlt--2010-8-21*******
        string tableStartTime = "";
        private string deptNameFind = "";
        private string deptIdFind = "";
        private string cardidFind = "";
        private string shiftNameFind = "";
        private string startTimeFind = "";
        private string endTimeFind = "";
        private string empNameFind = "";
        private bool IsFind = false;
        private string findType = "";
        private string findTimelong = "";
        private string tableEndTime = "";

        int intTimeLong = 0;
        //*****czlt--2010-8-21********

        #region 【Czlt-2011-10-16 添加合并考勤功能】
        private bool isUnoin = false;
        private string endWhere = "";
        #endregion
        #endregion


        #region [ 构造函数 ]

        public AttendanceParticulars()
        {
            InitializeComponent();

            base.Text = "考勤明细";
            base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            //base.btnLaws.Hide();
            base.btnDelete.Hide();
            lblCounts.Text = "";
            dtpBeginTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            cmbSelectCounts.Text = "40";
            pictureBox2.Visible = false;
        }


        #region 【czlt-2010-8-22 重写构造函数】
        //*********************czlt-2010-8-22**************************************/      

        public AttendanceParticulars(string deptName, string deptid, string cardid, string shiftName, string startTime, string endTime, string empName, string findType, string intTimelong)
        {
            InitializeComponent();

            base.Text = "考勤明细";
            //base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            //base.btnLaws.Hide();
            base.btnDelete.Hide();
            lblCounts.Text = "";
            dtpBeginTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            cmbSelectCounts.Text = "40";
            pictureBox2.Visible = false;
            TerSetButionFalse();
            //StrWhere = CreateWhere(deptid,cardid,shiftName,startTime,endTime);
            deptNameFind = deptName;
            deptIdFind = deptid;
            cardidFind = cardid;
            shiftNameFind = shiftName;
            startTimeFind = startTime;
            endTimeFind = endTime;
            empNameFind = empName;
            IsFind = true;
            this.findType = findType;
            this.findTimelong = intTimelong;



        }
        //**************************czlt-2010-8-22**********************************/
        #endregion

        #region 【czlt-2010-8-22 重写构造函数】
        //*********************czlt-2010-8-22**************************************/      

        public AttendanceParticulars(string deptName, string deptid, string cardid, string shiftName, string startTime, string endTime, string empName, string findType, string intTimelong, bool isUn)
        {
            InitializeComponent();

            base.Text = "考勤明细";
            //base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            //base.btnLaws.Hide();
            base.btnDelete.Hide();
            lblCounts.Text = "";
            dtpBeginTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            cmbSelectCounts.Text = "40";
            pictureBox2.Visible = false;
            TerSetButionFalse();
            //StrWhere = CreateWhere(deptid,cardid,shiftName,startTime,endTime);
            deptNameFind = deptName;
            //deptIdFind = deptid;
            deptIdFind = "";
            cardidFind = cardid;
            shiftNameFind = shiftName;
            startTimeFind = startTime;
            endTimeFind = endTime;
            empNameFind = empName;
            IsFind = true;
            this.findType = findType;
            this.findTimelong = intTimelong;
            isUnoin = isUn;



        }
        //**************************czlt-2010-8-22**********************************/
        #endregion

        #endregion

        /*
         * 方法
         */
        #region[多线程方法]
        private delegate void LabelTextSet(Label lab, string text);
        private void SetLabelText(Label lab, string text)
        {
            lab.Text = text;
        }

        private delegate void ControlEnabelSet(Control c, bool enabel);
        private void SetControlEnabel(Control c, bool enabel)
        {
            c.Enabled = enabel;
        }

        private delegate void BindData(DataTable dt);
        private void DgvBindData(DataTable dt)
        {
            dgrd.DataSource = dt;
        }

        private delegate void HeadTextSet(int index, string headtext);
        private void SetHeadText(int index, string headtext)
        {
            dgrd.Columns[index].HeaderText = headtext;
        }

        private delegate void ControlVisiabelSet(Control c, bool visabelset);
        private void SetControlVisiabel(Control c, bool visiabel)
        {
            c.Visible = visiabel;
        }

        private void EnabelAll(bool enabel)
        {
            panelLeft.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { panelLeft, enabel });
            cmbSelectCounts.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { cmbSelectCounts, enabel });
            txtSkipPage.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { txtSkipPage, enabel });
            btnDownPage.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { btnDownPage, enabel });
            btnUpPage.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { btnUpPage, enabel });
            btnPrint.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { btnPrint, enabel });
        }
        #endregion


        #region [ 方法: DataGridView数据绑定函数 ]

        private string CreateWhere()
        {
            string strWhere = string.Empty;
            //strWhere = " and substring(convert(char,DataAttendance,120),1,10) >='" + dtpBeginTime.Value.ToString("yyyy-MM-dd") + "' and substring(convert(char,DataAttendance,120),1,10) <='" + dtpEndTime.Value.ToString("yyyy-MM-dd") + "' ";
            strWhere = " and 1=1 ";
            if (ddlDept.SelectedValue != null)
            {
                if (ddlDept.SelectedValue.ToString() != "0")
                {
                    // strWhere += " and H.DeptID=" + ddlDept.SelectedValue;
                    string strValue = dBLL.GetValueOrIdByID(false, ddlDept.SelectedValue.ToString());
                    if (strValue != null && !strValue.Trim().Equals(""))
                    {
                        strWhere += " and H.DeptID in ('" + strValue + "')";
                    }
                }
            }
            if (ddlDuty.SelectedValue != null)
            {
                if (ddlDuty.SelectedValue.ToString() != "0")
                {
                    strWhere += " and E.DutyID=" + ddlDuty.SelectedValue;
                }
            }
            if (txtUserName.Text.Trim() != "")
            {
                strWhere += " and H.EmployeeName like ( '%" + txtUserName.Text.Trim() + "%')";
            }
            try
            {
                if (txtBlock.Text.Trim() != "")
                {
                    //Convert.ToInt32(txtBlock.Text.Trim());
                    //yc11
                    Convert.ToInt64(txtBlock.Text.Trim());
                    //yc12
                    strWhere += " and H.BlockID =" + txtBlock.Text.Trim();
                }
            }
            catch
            {
                lblErr.ForeColor = Color.Red;
                lblErr.Text = "卡号只能为数字!";
            }

            //班次
            if (cboClassName.SelectedValue != null)
            {
                if (!cboClassName.SelectedValue.ToString().Equals("0"))
                {
                    strWhere += " and H.TimerIntervalID=" + cboClassName.SelectedValue.ToString();
                }
            }

            strWhere += " And EmployeeID is not null ";

            tableStartTime = dtpBeginTime.Value.ToString("yyyy-MM-dd");
            tableEndTime = dtpEndTime.Value.ToString("yyyy-MM-dd");
            //if (ddlDept.SelectedValue != null)
            //{
            //    if (ddlDept.SelectedValue.ToString() != "0")
            //    {
            //        strWhere += " or (D.DeptID=" + ddlDept.SelectedValue.ToString() + ") ";
            //    }
            //    //else
            //    //{
            //    //    strWhere += " or (H.EndWorkTime is null) ";
            //    //}
            //}
            intPageSize = Convert.ToInt32(cmbSelectCounts.Text);

            //*************Czlt-2011-03-07-满工查询***********
            if (chkAll.Checked)
            {
                endWhere = " 1=1 ";
            }
            else
            {

                //if (radFull.Checked)
                //{
                //    endWhere = "  worktime>= minsecTime";
                //}
                //else if (radLast.Checked)
                //{
                //    endWhere = "  worktime < minsecTime ";
                //}

                if (!numTimeLong.Text.Equals("0") && !numTimeLong.Text.Trim().Equals(""))
                {
                    if (numTimeLong.Text.Trim().Equals(""))
                        numTimeLong.Text = "0";

                    intTimeLong = Convert.ToInt32(numTimeLong.Text) * 60;
                    // strWhere += " and worktime>= " + intTimeLong.ToString();
                }

                if (radFull.Checked)
                {
                    if (!numTimeLong.Text.Equals("0") && !numTimeLong.Text.Trim().Equals(""))
                    {
                        if (chkUnion.Checked == false)
                        {
                            strWhere += " and worktime>= " + intTimeLong.ToString();
                        }
                    }

                    //Czlt-2012-3-30- 假如工作时长不为空的时候,按照输入的时间来查询
                    if (!numTimeLong.Text.Equals("0") && !numTimeLong.Text.Trim().Equals(""))
                    {
                        endWhere = "  worktime>=" + intTimeLong.ToString();
                    }
                    else
                    {
                        endWhere = "  worktime>= minsecTime";
                    }
                }
                else if (radLast.Checked)
                {
                    if (!numTimeLong.Text.Equals("0") && !numTimeLong.Text.Trim().Equals(""))
                    {
                        if (chkUnion.Checked == false)
                        {
                            strWhere += " and worktime< " + intTimeLong.ToString();
                        }
                    }

                    //Czlt-2012-3-30- 假如工作时长不为空的时候,按照输入的时间来查询
                    if (!numTimeLong.Text.Equals("0") && !numTimeLong.Text.Trim().Equals(""))
                    {
                        endWhere = "  worktime <" + intTimeLong.ToString();
                    }
                    else
                    {
                        endWhere = "  worktime < minsecTime ";
                    }
                }
            }
            //*************Czlt-2011-03-07-满工查询***********

            return strWhere;
        }

        void BindDataGridView()
        {
            try
            {

                //string StrWhere = CreateWhere();
                EnabelAll(false);
                //StrWhere += " And EmployeeID is not null ";

                //intPageSize = Convert.ToInt32(cmbSelectCounts.Text);
                //DataSet ds = aBLL.GetEmployeeAttendanceParticulars(StrWhere, this.dtpBeginTime.Text, intPageIndex, intPageSize, out strErr);
                //clzt-2010-8-24--查询的表名称


                //Czlt-2011-10-16 合并考勤注销
                //DataSet ds = aBLL.GetEmployeeAttendanceParticulars(StrWhere, tableStartTime, intPageIndex, intPageSize, out strErr);

                //Czlt_GetEmployeeAttendanceParticulars
                //isUnoin = false; //不合并考勤
                DataSet ds = aBLL.Czlt_GetEmployeeAttendanceParticulars(isUnoin, tableStartTime, tableEndTime, StrWhere, intPageIndex, intPageSize, endWhere, out strErr);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].Columns.Remove("ManHourNumber");//工数
                    // ds.Tables[0].Columns.Remove("DataAttendance");//计工日期
                    ds.Tables[0].Columns.Remove("WorkTypeName");//工种
                    ds.Tables[0].TableName = "A_AttendanceParticulars";
                    dgrd.Invoke(new BindData(DgvBindData), new object[] { ds.Tables[0] });
                    //dgrd.Columns[0].HeaderText = "标识卡号";
                    dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 0, "卡号" });
                    //dgrd.Columns[1].HeaderText = "姓名";

                    //dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 1, "卡号类型" });

                    dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 1, "姓名" });
                    //dgrd.Columns[2].HeaderText = "部门";
                    dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 2, "部门" });
                    //dgrd.Columns[3].HeaderText = "班次";
                    dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 3, "班次" });
                    //dgrd.Columns[4].HeaderText = "所担职务";
                    dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 4, "职务" });
                    //dgrd.Columns[4].HeaderText = "所担职务";
                    // dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 5, "工种" }); //2011-02-23工种
                    //dgrd.Columns[5].HeaderText = "上班时间";
                    dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 5, "下井时间" });
                    //dgrd.Columns[6].HeaderText = "下班时间";
                    dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 6, "上井时间" });
                    //dgrd.Columns[7].HeaderText = "工作时长(分)";
                    dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 7, "工作时长(时)" });
                    //dgrd.Columns[8].HeaderText = "工数";
                    //dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 9, "工数" });
                    ////dgrd.Columns[9].HeaderText = "记工日期";
                    dgrd.Invoke(new HeadTextSet(SetHeadText), new object[] { 8, "记工日期" });


                    //Czlt-2012-04-22 设置上下井时间的显示样式
                    dgrd.Columns["BeginWorkTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgrd.Columns["EndWorkTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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
                        //btnUpPage.Enabled = false;
                        btnUpPage.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { btnUpPage, false });
                    }
                    else
                    {
                        //btnUpPage.Enabled = true;
                        btnUpPage.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { btnUpPage, true });
                    }

                    if (intPageIndex == intPageCount)
                    {
                        //btnDownPage.Enabled = false;
                        btnDownPage.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { btnDownPage, false });
                    }
                    else
                    {
                        //btnDownPage.Enabled = true;
                        btnDownPage.Invoke(new ControlEnabelSet(SetControlEnabel), new object[] { btnDownPage, true });
                    }


                    lblCounts.Invoke(new LabelTextSet(SetLabelText), new object[] { lblCounts, "共有" + intRowsCount.ToString() + "条记录" });
                    lblCounts.Text = "共有" + intRowsCount.ToString() + "条记录";

                    lblPageCounts.Invoke(new LabelTextSet(SetLabelText), new object[] { lblPageCounts, intPageIndex.ToString() });
                    lblPageCounts.Text = intPageIndex.ToString();

                    lblSumPage.Invoke(new LabelTextSet(SetLabelText), new object[] { lblSumPage, "/" + intPageCount + "页" });
                    lblSumPage.Text = "/" + intPageCount + "页";
                }
                else
                {
                    DataTable dt = new DataTable("A_AttendanceParticulars_BindDataGridView");
                    dt.Columns.Add("卡号");
                    //dt.Columns.Add("卡号类型");
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("部门");
                    dt.Columns.Add("班次");
                    dt.Columns.Add("职务");
                    dt.Columns.Add("下井时间");
                    dt.Columns.Add("上井时间");
                    dt.Columns.Add("工作时长(时)");
                    dt.Columns.Add("记工日期");

                    dgrd.Invoke(new BindData(DgvBindData), new object[] { dt });
                    lblCounts.Invoke(new LabelTextSet(SetLabelText), new object[] { lblCounts, "共有0条记录" });
                }
            }
            catch (Exception ex)
            {
                try
                {
                    pictureBox2.Invoke(new ControlVisiabelSet(SetControlVisiabel), new object[] { pictureBox2, false });
                }
                catch (Exception exp)
                { }
                DataTable dt = new DataTable("A_AttendanceParticulars_BindDataGridView");
                dt.Columns.Add("卡号");
                //dt.Columns.Add("卡号类型");
                dt.Columns.Add("姓名");
                dt.Columns.Add("部门");
                dt.Columns.Add("班次");
                dt.Columns.Add("职务");
                dt.Columns.Add("下井时间");
                dt.Columns.Add("上井时间");
                dt.Columns.Add("工作时长(时)");
                dt.Columns.Add("记工日期");

                dgrd.Invoke(new BindData(DgvBindData), new object[] { dt });
                lblCounts.Invoke(new LabelTextSet(SetLabelText), new object[] { lblCounts, "共有0条记录" });
            }
            //pictureBox2.Visible = false;
            try
            {
                EnabelAll(true);
                pictureBox2.Invoke(new ControlVisiabelSet(SetControlVisiabel), new object[] { pictureBox2, false });
            }
            catch (Exception ex)
            { }
        }

        #endregion

        /*
         * 事件
         */

        #region [ 事件: 窗体加载 ]

        private void AttendanceParticulars_Load(object sender, EventArgs e)
        {
            dBLL.getDutyNameCmb(ddlDuty);
            dBLL.getDeptAddAll(ddlDept);
            aBLL.getClassNameCmb(cboClassName);
            //BindDataGridView();

            //cmbSelectCounts.SelectedIndex = 0;

            //*************************czlt-2010-8-23*从考勤人员统计表联查过来**Start*************************************
            if (IsFind)
            {
                StrWhere = CreateWhere(deptIdFind, cardidFind, shiftNameFind, startTimeFind, endTimeFind);
                if (tableStartTime.Equals(""))
                    return;
                BindDataGridView();
            }
            //*************************czlt-2010-8-23*从考勤人员统计表联查过来**End*************************************/
        }

        #endregion

        #region [ 事件: 查询按钮_Click事件 ]

        private void btnQuery_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            intPageIndex = 1;
            pictureBox2.Visible = true;
            StrWhere = CreateWhere();
            ThreadStart ths = new ThreadStart(RunBindDB);
            th = new Thread(ths);
            th.Start();
            //BindDataGridView();
        }

        #endregion


        private void RunBindDB()
        {
            //ThreadBindData d = new ThreadBindData(BindDataGridView);
            //this.Invoke(d);
            BindDataGridView();
            th.Abort();

        }















        private void btnUpPage_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (intPageIndex > 1)
            {
                intPageIndex--;
            }
            pictureBox2.Visible = true;
            if (IsFind == true)
            {
                //*************************czlt-2010-8-23*从考勤人员统计表联查过来**Start*************************************
                StrWhere = CreateWhere(deptIdFind, cardidFind, shiftNameFind, startTimeFind, endTimeFind);
                BindDataGridView();
                //*************************czlt-2010-8-23*从考勤人员统计表联查过来**End*************************************/
            }
            else
            {
                StrWhere = CreateWhere();
                ThreadStart ths = new ThreadStart(RunBindDB);
                th = new Thread(ths);
                th.Start();
            }
            //BindDataGridView();
        }

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (intPageIndex < intPageCount)
            {
                intPageIndex++;
            }
            pictureBox2.Visible = true;
            if (IsFind == true)
            {
                //*************************czlt-2010-8-23*从考勤人员统计表联查过来**Start*************************************
                StrWhere = CreateWhere(deptIdFind, cardidFind, shiftNameFind, startTimeFind, endTimeFind);
                BindDataGridView();
                //*************************czlt-2010-8-23*从考勤人员统计表联查过来**End*************************************/
            }
            else
            {
                StrWhere = CreateWhere();
                ThreadStart ths = new ThreadStart(RunBindDB);
                th = new Thread(ths);
                th.Start();
            }
            //BindDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtpBeginTime.Text.Trim() == "" || dtpEndTime.Text.Trim() == "")
            {
                MessageBox.Show("开始和结束时间都不能为空，请选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((dtpBeginTime.Value.Year == dtpEndTime.Value.Year || dtpBeginTime.Value.AddYears(1).Year == dtpEndTime.Value.Year) && ((dtpBeginTime.Value.Month == dtpEndTime.Value.Month) || (dtpBeginTime.Value.Month == dtpEndTime.Value.AddMonths(-1).Month)))
            {
            }
            else
            {
                MessageBox.Show("不能跨两个或两个以上月份查询数据，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TimeSpan ts1 = new TimeSpan(dtpBeginTime.Value.Ticks);
            TimeSpan ts2 = new TimeSpan(dtpEndTime.Value.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if ((int)ts.Days > 31)
            {
                MessageBox.Show("跨月查询不能多于三十一天！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (DateTime.Compare(DateTime.Parse(dtpBeginTime.Text), DateTime.Parse(dtpEndTime.Text)) > 0)
            {
                MessageBox.Show("开始时间不能大于结束时间，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (Convert.ToDateTime(dtpBeginTime.Text).AddDays(7) < Convert.ToDateTime(dtpEndTime.Text))
            //{
            //    MessageBox.Show("开始时间和结束时间之间天数不能大于7天，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (DateTime.Compare(DateTime.Parse(dtpBeginTime.Text), DateTime.Now) > 0)
            {
                MessageBox.Show("开始时间不能大于当前时间，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpEndTime.Value > DateTime.Now)
            {
                dtpEndTime.Value = DateTime.Now;
            }

            lblErr.Text = "";
            intPageIndex = 1;
            pictureBox2.Visible = true;
            StrWhere = CreateWhere();
            ThreadStart ths = new ThreadStart(RunBindDB);
            th = new Thread(ths);
            th.Start();
            //BindDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            txtBlock.Text = "";
            txtUserName.Text = "";
            dgrd.DataSource = new DataTable();
            lblCounts.Text = "共 0 条记录";
        }

        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void txtSkipPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                lblErr.Text = "";
                lblErr.ForeColor = Color.Red;
                if (txtSkipPage.Text.Trim() == "")
                {
                    lblErr.Text = "跳转页数不能为空!";
                    return;
                }
                if (txtSkipPage.Text.Trim() == "0")
                {
                    lblErr.Text = "跳转页数不能为零!";
                    return;
                }

                try
                {
                    Convert.ToInt32(txtSkipPage.Text.Trim());
                }
                catch
                {
                    lblErr.Text = "跳转页数只能为数字!";
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

                pictureBox2.Visible = true;
                if (IsFind == true)
                {
                    //*************************czlt-2010-8-23*从考勤人员统计表联查过来**Start*************************************
                    StrWhere = CreateWhere(deptIdFind, cardidFind, shiftNameFind, startTimeFind, endTimeFind);
                    BindDataGridView();
                    //*************************czlt-2010-8-23*从考勤人员统计表联查过来**End*************************************/
                }
                else
                {
                    StrWhere = CreateWhere();
                    ThreadStart ths = new ThreadStart(RunBindDB);
                    th = new Thread(ths);
                    th.Start();
                }
                //BindDataGridView();
            }
        }

        private void AttendanceParticulars_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                th.Abort();
            }
            catch (Exception ex)
            { }
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

        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Red;


            //if (Convert.ToInt32(txtSkipPage.Text.Trim()) >= intPageCount)
            //{
            //    intPageIndex = intPageCount;
            //    txtSkipPage.Text = intPageCount.ToString();
            //}
            //else
            //{
            //    intPageIndex = Convert.ToInt32(txtSkipPage.Text);
            //}
            intPageIndex = 1;

            //BindDataGridView();
            pictureBox2.Visible = true;
            if (IsFind == true)
            {
                //*************************czlt-2010-8-23*从考勤人员统计表联查过来**Start*************************************
                StrWhere = CreateWhere(deptIdFind, cardidFind, shiftNameFind, startTimeFind, endTimeFind);
                BindDataGridView();
                //*************************czlt-2010-8-23*从考勤人员统计表联查过来**End*************************************/
            }
            else
            {
                StrWhere = CreateWhere();
                ThreadStart ths = new ThreadStart(RunBindDB);
                th = new Thread(ths);
                th.Start();
            }
        }


        #region【私有方法 czlt-2010-8-21】

        //组织查询条件
        private string CreateWhere(string deptid, string cardId, string shiftId, string startTime, string endTime)
        {
            string strWhere = string.Empty;
            strWhere = " and substring(convert(char,DataAttendance,120),1,10) >='" + startTime + "' and substring(convert(char,DataAttendance,120),1,10) <='" + endTime + "' ";

            //部门ID
            if (deptNameFind != "")
            {
                if (!String.IsNullOrEmpty(deptid))
                {
                    //strWhere += "and H.DeptID=" + deptid;
                    string strValue = dBLL.GetValueOrIdByID(false, deptid);
                    if (strValue != null && !strValue.Trim().Equals(""))
                    {
                        strWhere += " and H.DeptID in ('" + strValue + "')";
                    }
                }
            }
            else
            {
               // strWhere += " and H.DeptName is null ";
            }

            //卡号ID
            if (!String.IsNullOrEmpty(cardId))
            {
                strWhere += " and H.BlockID =" + cardId.Trim();
            }
            if (!String.IsNullOrEmpty(empNameFind))
            {
                strWhere += " and H.employeename = '" + empNameFind.Trim() + "'";
            }

            //班次ID
            if (!String.IsNullOrEmpty(shiftId) && !shiftId.Equals("跟班"))
            {
                strWhere += " and H.TimerIntervalID=" + shiftId.Trim();
            }

            strWhere += " And EmployeeID is not null ";
            tableStartTime = startTime;

            intPageSize = Convert.ToInt32(cmbSelectCounts.Text);


            //if (chkAll.Checked)
            //{
            //    endWhere = " 1=1 ";
            //}
            //else
            //{

            //    if (radFull.Checked)
            //    {
            //        endWhere = "  worktime>= minsecTime";
            //    }
            //    else if (radLast.Checked)
            //    {
            //        endWhere = "  worktime < minsecTime and worktime > 600 ";
            //    }
            //}

            if (!findType.Equals(""))
            {
                //if (!findTimelong.Equals("0"))
                //{
                //满工查询
                if (findType.Equals("1"))
                {
                    if (!findTimelong.ToString().Equals("0"))
                    {
                        strWhere += " and worktime>= " + findTimelong;
                    }
                    //strWhere += " and worktime>= " + findTimelong;
                    endWhere = "  worktime>= minsecTime";
                }
                //欠工查询
                else if (findType.Equals("2"))
                {
                    if (!findTimelong.ToString().Equals("0"))
                    {
                        strWhere += " and worktime< " + findTimelong;
                    }
                    // strWhere += " and worktime< " + findTimelong;
                    endWhere = "  worktime < minsecTime ";
                }
                //}
            }
            else
            {
                endWhere = " 1=1 ";

            }

            if (shiftNameFind.Equals("跟班"))
            {
                endWhere = "  worktime>= 28800";
            }
            tableEndTime = endTime;
            return strWhere;
        }

        //隐藏界面部分信息
        private void TerSetButionFalse()
        {
            //隐藏左边的条件          
            panelLeft.Visible = false;


            //设置名称
            lblMainTitle.Text = "人员考勤明细";

        }
        #endregion

        private void btnLaws_Click(object sender, EventArgs e)
        {
            if (dgrd != null && dgrd.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgrd.DataSource;
                dt.Columns["BlockID"].ColumnName = "卡号";
                dt.Columns["CardType"].ColumnName = "卡号类型";
                dt.Columns["EmployeeName"].ColumnName = "姓名";
                dt.Columns["DeptName"].ColumnName = "部门";
                dt.Columns["ClassShortName"].ColumnName = "班次";
                dt.Columns["DutyName"].ColumnName = "职务";
                //dt.Columns["WorkTypeName"].ColumnName = "工种";
                dt.Columns["BeginWorkTime"].ColumnName = "下井时间";
                dt.Columns["EndWorkTime"].ColumnName = "上井时间";
                dt.Columns["WorkTime"].ColumnName = "工作时长(时)";
                // dt.Columns["ManHourNumber"].ColumnName = "工数";
                //dt.Columns["RecordDate"].ColumnName = "记工日期";
                //dt.Columns.Remove("RecordDate");

                new PrintCore.ExportExcel().Sql_ExportExcel(dgrd, "");
            }
            else
            {
                MessageBox.Show("没有导出数据，请查询后导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region 【Czlt-2011-03-07 考勤时长做为过滤条件】
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                grpMessage.Enabled = false;
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
        /// Czlt-2011-10-15 合并考勤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkUnion_CheckedChanged(object sender, EventArgs e)
        {
            //是否启用合并考勤功能
            if (chkUnion.Checked)
            {
                isUnoin = true;
            }
            else
            {
                isUnoin = false;
            }
        }


        #region [ 事件: 打印 导出]
        /// <summary>
        /// 打印功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgrd, "人员考勤明细", "统计时间:" + dtpBeginTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));

        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgrd, "人员考勤明细", "统计时间:" + dtpBeginTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgrd, "人员考勤明细", "统计时间:" + dtpBeginTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
        }



        #endregion
    }
}