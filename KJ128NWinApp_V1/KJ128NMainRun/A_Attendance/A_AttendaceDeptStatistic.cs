/*********************************************************************************************************
 * 
 * 创建时间：2010-8-26
 * 
 * 创 建 人：刘涛-czlt
 *  
 * 修 改 人：
 * 
 * 类功能描述：考勤部门统计 UI层界面布局已经功能的实现
 * 
 * 
 * ********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Threading;

namespace KJ128NMainRun.A_Attendance
{
    public partial class A_AttendaceDeptStatistic : KJ128NMainRun.FromModel.FrmModel
    {
        #region 【属性字段】
        bool isUnion = false;
        Thread th = null;
        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        string strErr = string.Empty;
        KJ128NDBTable.A_Attendance.A_AttendaceBLL bll = new KJ128NDBTable.A_Attendance.A_AttendaceBLL();

        //全局SqlWhere
        private string strSqlWhere = string.Empty;

        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;
        private int pages = 1;
        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        #endregion

        #region 【构造函数】
        public A_AttendaceDeptStatistic()
        {
            InitializeComponent();
            base.Text = "考勤部门统计";
            base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
           // base.btnLaws.Hide();
            base.btnDelete.Hide();

            bindDeptCmb();
            cmbSelectCounts.Text = "40";
            //Control.CheckForIllegalCrossThreadCalls = false;

        }
        #endregion

        #region 【功能事件】

        #region 【查询功能】
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                GetSqlWhere();
                pages = 1;
                btnFind.Enabled = false;
                btnReset.Enabled = false;
                pictureBox2.Visible = true;
                th = new Thread(BingdingDGV);
                th.Start();
            }
        }


        private void BingdingDGV()
        {
            GridViewBind();
            if (this.IsHandleCreated)
            {
                pictureBox2.Invoke(new MethodInvoker(delegate()
                    {
                        pictureBox2.Visible = false;
                    }));
                this.Invoke(new MethodInvoker(delegate()
                {
                    btnFind.Enabled = true;
                    btnReset.Enabled = true;
                }));
            }
            th.Abort();
        }
        #endregion

        

        #region【下一页】
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (page > countPage)
            {
                return;
            }
            pages = page;
            pictureBox2.Visible = true;
            th = new Thread(BingdingDGV);
            th.Start();

        }
        #endregion

        #region【上一页】
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;

            if (page > 1)
            {
                return;
            }
            pages = page;
            pictureBox2.Visible = true;
            th = new Thread(BingdingDGV);
            th.Start();
        }
        #endregion

        #region 【每页显示多少条信息下拉列表改变事件】
        //每页显示多少条信息下拉列表改变事件
        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region【键盘按下事件】
        /// <summary>
        /// 键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        pages = page;
                        GridViewBind();
                    }
                }
                catch (Exception ex)
                { }
            }
        }
        #endregion

        #region 【控件激活时事件】
        private IButtonControl IB = null;
        //控件激活时事件
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;

        }
        #endregion

        #region【不再是激活控件时发生的事件】
        /// <summary>
        /// 不再是激活控件时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }
        #endregion

        #region 【组合下拉框关闭后事件】
        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);
            pages = 1;
            pictureBox2.Visible = true;
            th = new Thread(BingdingDGV);
            th.Start();
        }
        #endregion

        #region【重置方法】
        /// <summary>
        /// 重置方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            bindDeptCmb();
            dgViewDept.DataSource = new DataTable();
            lblCounts.Text = "共 0 条记录";
        }
        #endregion

        #endregion

        #region 【私有方法】

        #region 【绑定部门】
        /// <summary>
        /// 绑定部门
        /// </summary>
        private void bindDeptCmb()
        {
            ddlDept.DataSource = bll.Dept_Tree_Static();
            ddlDept.DisplayMember = "Name";
            ddlDept.ValueMember = "ID";
        }
        #endregion

        #region 【条件检测】
        /// <summary>
        /// 条件检测
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            TimeSpan ts1 = new TimeSpan(dtpStartTime.Value.Ticks);
            TimeSpan ts2 = new TimeSpan(dtpEndTime.Value.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if ((int)ts.Days > 31)
            {
                MessageBox.Show("跨月查询不能多于三十一天！", "提示", MessageBoxButtons.OK);
                return false;
            }
            //--czlt-开始时间大于当前时间的时候,把开始时间设置为当前时间
            if (dtpStartTime.Value > DateTime.Now)
            {
                dtpStartTime.Value = DateTime.Now;
            }

            //--czlt-结束时间大于当前时间的时候,把结束时间设置为当前时间
            if (dtpEndTime.Value > DateTime.Now)
            {
                dtpEndTime.Value = DateTime.Now;
            }

            //1.非空校验
            if (dtpStartTime.Text.Trim().Equals("") || dtpEndTime.Text.Trim().Equals(""))
            {
                MessageBox.Show("开始和结束时间都不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //2.时间先后校验
            if (dtpEndTime.Value < dtpStartTime.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //3.跨月校验
            if (((Convert.ToInt16(dtpStartTime.Value.Year) == Convert.ToInt16(dtpEndTime.Value.Year) - 1 && Convert.ToInt16(dtpStartTime.Value.Month) == 12 && Convert.ToInt16(dtpEndTime.Value.Month) == 1)) || (dtpStartTime.Value.Year == dtpEndTime.Value.Year && ((dtpStartTime.Value.Month == dtpEndTime.Value.Month) || (dtpStartTime.Value.Month == dtpEndTime.Value.AddMonths(-1).Month))))
            { }
            else
            {
                MessageBox.Show("不能跨两个或两个月份以上查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }
        #endregion

        #region【根据条件组织where条件 GetSqlWhere()】
        /// <summary>
        /// 根据条件组织where条件
        /// </summary>
        private void GetSqlWhere()
        {
            int intTimeLong = 0;
            string strWhere = string.Empty;
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

            if (strWhere.Equals(""))
                strWhere = "and 1=1 ";
                       
            strSqlWhere = strWhere;
        }

        #endregion

        #region【加载并绑定数据】
        /// <summary>
        /// 加载并绑定数据
        /// </summary>
        /// <param name="intPage"></param>
        private void GridViewBind()
        {
            int intPage = pages;
            if (chkUnion.Checked)
            {
                isUnion = true;
            }
            else
            {
                isUnion = false;
            }
            DataSet ds = aBLL.GetEmployeeAttendanceDeptStatistic(dtpStartTime.Value.ToString("yyyy-MM-dd"), dtpEndTime.Value.ToString("yyyy-MM-dd"), strSqlWhere, intPage, pSize, isUnion, out strErr);

            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    //ds.Tables[0].Columns[0].SetOrdinal(2);
                    //ds.Tables[0].Columns[2].SetOrdinal(0);
                    //DataTable dt = new DataTable();
                   
                    //int count0 = 0;
                    //int count4 = 0;
                    //int count8 = 0;
                    //int count9 = 0;
                    //int count10 = 0;
                    //foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                    //    count0 = count0 + Convert.ToInt32(dr[3]);
                    //    count4 = count4 + Convert.ToInt32(dr[4]);
                    //    count8 = count8 + Convert.ToInt32(dr[5]);
                    //    count9 = count9 + Convert.ToInt32(dr[6]);
                    //    count10 = count10 + Convert.ToInt32(dr[7]);
                    //}

                    //DataRow r = ds.Tables[0].NewRow();
                    //r[2] = "合计";
                    //r[3] = count0;
                    //r[4] = count4;
                    //r[5] = count8;
                    //r[6] = count9;
                    //r[7] = count10;
                    //ds.Tables[0].Rows.Add(r);

                    //ds.Tables[0].Columns.Remove("deptid");
                    //ds.Tables[0].TableName = "A_AttendanceDeptStatistic";
                    this.Invoke(new MethodInvoker(delegate()
                        {

                            dgViewDept.DataSource = ds.Tables[0];
                            //dgViewDept.DataSource = dt;

                            // 重新设置页数
                            int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                            sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                            countPage = sumPage;

                            if (sumPage == 0)
                            {

                                lblCounts.Text = "共 0 条记录";

                                lblPageCounts.Text = "1";
                                lblSumPage.Text = "/1页";

                                btnUpPage.Enabled = false;
                                btnDownPage.Enabled = false;
                            }
                            else
                            {
                                lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                                lblPageCounts.Text = intPage.ToString();
                                lblSumPage.Text = "/" + sumPage + "页";

                                //控制翻页状态
                                SetPageEnable(intPage, sumPage);
                            }
                            //customersDataGridView.Columns["ContactName"].DisplayIndex = 0;
                            //customersDataGridView.Columns["ContactTitle"].DisplayIndex = 1;
                            //dgViewDept.Controls["部门名称"];
                            //dgViewDept.Columns[1].Visible = false;
                            //dgViewDept.Columns[0].DisplayIndex = 1;
                            //dgViewDept.Columns[1].DisplayIndex = 0;
                        }));
                }
                else
                {
                    MessageBox.Show("没有符合条件的查询结果,请重新选择查询条件进行查询!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DataTable dt = new DataTable("A_AttendanceDeptStatistic_BindDataGridView");
                    //dt.Columns.Add("部门名称");
                    //dt.Columns.Add("班制");
                    //dt.Columns.Add("出勤汇总");
                    //dt.Columns.Add("早班汇总");
                    //dt.Columns.Add("中班汇总");
                    //dt.Columns.Add("晚班汇总");
                    //dt.Columns.Add("请假汇总");
                    //this.Invoke(new MethodInvoker(delegate()
                    //   {
                    //       dgViewDept.DataSource = dt;
                    //       lblCounts.Text = "共 0 个人";
                    //   }));
                }
            }
            catch
            {
                MessageBox.Show("您的查询有误,请重新查询!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //DataTable dt = new DataTable("A_AttendanceDeptStatistic_BindDataGridView");
                //dt.Columns.Add("部门名称");
                //dt.Columns.Add("班制");
                //dt.Columns.Add("出勤汇总");
                //dt.Columns.Add("早班汇总");
                //dt.Columns.Add("中班汇总");
                //dt.Columns.Add("晚班汇总");
                //dt.Columns.Add("请假汇总");
                //this.Invoke(new MethodInvoker(delegate()
                //       {
                //           dgViewDept.DataSource = dt;
                //           lblCounts.Text = "共 0 个人";
                //       }));
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

        #region 【方法：打印- Czlt-2010-12-24】
        private void btnLaws_Click(object sender, EventArgs e)
        {
            if (dgViewDept != null && dgViewDept.Rows.Count > 0)
            {
                new PrintCore.ExportExcel().Sql_ExportExcel(dgViewDept, "");
            }
            else
            {
                MessageBox.Show("没有导出数据，请查询后导出！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        #endregion

        private void A_AttendaceDeptStatistic_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = dtpEndTime.Value = DateTime.Now;
        }
        #region【打印事件 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgViewDept, "考勤部门统计表", "统计时间:" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgViewDept, "考勤部门统计表", "统计时间:" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
        }
        /// <summary>
        /// 打印功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgViewDept != null && dgViewDept.Rows.Count > 0)
            {
                KJ128NDBTable.PrintBLL.Print(dgViewDept, "考勤部门统计表", "统计时间:" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                MessageBox.Show("没有打印数据，请查询后打印！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


        private void A_AttendaceDeptStatistic_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                th.Abort();
            }
            catch { }
        }

        //private void chkAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkAll.Checked)
        //    {
        //        grpMessage.Visible = false;
        //    }
        //    else
        //    {
        //        grpMessage.Visible = true;
        //    }
        //}


        #endregion

        #region 【注销掉的方法】
        //两个月以后清除 2010-8-24
        //行操作
        //private void dgViewDept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
        //    string strValue = dgViewDept.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        //    if (!strValue.Equals(0))
        //    {
        //        string deptid = dgViewDept.Rows[e.RowIndex].Cells[0].Value.ToString();
        //        string dateTime = dtpStartTime.Value.ToString("yyyy-MM");
        //        //NewHolidayTypeSet holidaySet = new NewHolidayTypeSet();
        //        if (Searcher.FindFormByName("tsmiDeptAttendanceStatistics"))
        //        {
        //            return;
        //        }
        //        KJ128NMainRun.AttendanceInfoSet.NewHolidayTypeSet holidaySet = new KJ128NMainRun.AttendanceInfoSet.NewHolidayTypeSet(deptid, dtpStartTime.Value.ToString("yyyy-MM-dd"),"", dtpEndTime.Value.ToString("yyyy-MM-dd"),dtpStartTime.Value.ToString("yyyyM"));
        //        holidaySet.ShowDialog();


        //    }
        //}
        #endregion
    }
}

