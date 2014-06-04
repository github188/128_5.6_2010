using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Threading;
using KJ128NMainRun;
using PrintCore;


namespace KJ128NInterfaceShow
{
    public partial class AttendanceInitialData :KJ128NMainRun.FromModel.FrmModel
    {

        #region [ 数据载入 ]
        delegate void lblmain(Label lbl, string str);

        delegate void dgv(DataTable dt);

        delegate void pic(bool bl);

        int ipage;

        string[] str;

        Thread th = null;
        private void lblGet(Label lbl, string str)
        {
            if (lbl.InvokeRequired)
            {
                lblmain a = new lblmain(lblGet);
                this.Invoke(a, new object[] { lbl, str });
            }
            else
            {
                if (str == null)
                {
                    lbl.ForeColor = Color.Red;
                }
                else
                {
                    lbl.Text = str;
                }
            }
        }
        private void Getdgv(DataTable dt)
        {
            if (dgrd.InvokeRequired)
            {
                dgv b = new dgv(Getdgv);
                this.Invoke(b, new object[] { dt });
            }
            else
            {
                dt.TableName = "A_InitialData";
                dgrd.DataSource = dt;
                if (dgrd.Columns.Contains("blockid"))
                {
                    dgrd.Columns.Remove("blockid");
                    dgrd.Columns.Remove("empname1");
                    dgrd.Columns.Remove("blockid1");
                    dgrd.Columns.Remove("empName2");
                }
                int sum = 0;
                dgrd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach (DataGridViewColumn dc in dgrd.Columns)
                {
                    sum += dc.Width;
                }
                if (sum > dgrd.Width)
                {
                    dgrd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    dgrd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void picvis(bool bl)
        {
            if (pictureBox1.InvokeRequired)
            {
                pic c = new pic(picvis);
                this.Invoke(c, new object[] { bl });
            }
            else
            {
                pictureBox1.Visible = bl;
            }
        }
        #endregion




        #region [ 声明 ]

        string strErr = string.Empty;
        DeptBLL dBLL = new DeptBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        bool isUnion = false;
        #endregion

        #region [ 构造函数 ]

        public AttendanceInitialData()
        {
            InitializeComponent();
            base.lblMainTitle.Hide();
            base.btnAdd.Hide();
            base.btnSelectAll.Hide();
            //base.btnLaws.Hide();
            base.btnDelete.Hide();
            cmbSelectCounts.SelectedIndex = 0;
            lblPageCounts.Text = "1";
            //BindDataGridView(1);
            lblCounts.Text = "";
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
            pictureBox1.Visible = false;
            panelLeftBottom.BringToFront();
        }

        #endregion

        /*
         * 方法
         */
       

        private string[] strr()
        {
            string[] strWhere = new string[6];
            strWhere[0] = dtpStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            strWhere[1] = dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (ddlDept.SelectedIndex > 0)
            {
                if (ddlDept.SelectedValue.ToString() != "0")
                {
                    //strWhere[2] = " and DeptName = '" + ddlDept.Text.ToString()+"'";
                    string strValue = dBLL.GetValueOrId(true, ddlDept.Text.ToString());
                    if (strValue != null && !strValue.Trim().Equals(""))
                    {
                        strWhere[2] = " and DeptName in ('" + strValue + "') ";
                    }
                    else
                    {
                        strWhere[2] = " and 1=1";
                    }

               
                }
            }
            else
            {
                strWhere[2] = " and 1=1";

            }
            if (cmbDuty.SelectedIndex > 0)
            {
                if (!cmbDuty.SelectedValue.ToString().Equals("0"))
                {
                    strWhere[3] += " and E.DutyName = '" + cmbDuty.Text.ToString() + "'";
                }
            }
            else
            {
                strWhere[3] = " and 1=1";
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
                    lblGet(lblCounts, null);
                    lblGet(lblCounts, "发码器编号只能为数字!");
                }
                strWhere[5] = " and BlockID like " + txtBlock.Text;
            }
            else
            {
                strWhere[5] = " and 1=1";
            }
            //员工姓名
            if (txtUserName.Text.Trim() != "")
            {
                strWhere[4] += " And E.EmpName like '%" + txtUserName.Text.Trim() + "%' ";
            }
            else
            {
                strWhere[4] = " and 1=1";
            }
            return strWhere;

        }

        #region[线程使用方法]
        private delegate void SetControlEnabel(Control c, bool enabel);
        private void ControlEnabelSet(Control c, bool enabel)
        {
            c.Enabled = enabel;
        }

        private void BtnEnabel(bool enabel)
        {
            btnClear.Invoke(new SetControlEnabel(ControlEnabelSet), new object[] { btnClear, enabel });
            btnQuery.Invoke(new SetControlEnabel(ControlEnabelSet), new object[] { btnQuery, enabel });
            btnPrint.Invoke(new SetControlEnabel(ControlEnabelSet), new object[] { btnPrint, enabel });
        }
        #endregion

        #region [ 方法: DataGridView绑定数据 ]

        private void BindDataGridView( )
        {
            try
            {
                int page = ipage;
                BtnEnabel(false);
                string[] strWhere = str;
                if (chkUnion.Checked)
                {
                    isUnion = true;
                }
                else
                {
                    isUnion = false;
                }
                DataSet ds = aBLL.GetEmployeeAttendanceInitialData(strWhere, isUnion);

                if (ds != null)
                {
                    DataTable dt = new DataTable();

                    //dgrd.DataSource = ds.Tables[0];
                    Getdgv(ds.Tables[1]);
                    lblGet(lblCounts, "共有" + ds.Tables[0].Rows[0][0].ToString() + "条记录");

                }
                else
                {
                    lblGet(lblCounts, "共有0条记录");
                }
                //pictureBox1.Visible = false;
                picvis(false);
                BtnEnabel(true);
            }
            catch (Exception ex)
            {
                try
                {
                    picvis(false);
                    BtnEnabel(true);
                }
                catch (Exception exp)
                { }
            }
            th.Abort();
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void AttendanceInitialData_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dBLL.getDeptAddAll(ddlDept);
            dBLL.getDutyNameCmb(cmbDuty);
        }

        #endregion

        #region [ 事件: 查询按钮_Click事件 ]
       
        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgrd.DataSource = null;
            if (decideTime())
            {
                str = strr();
                pictureBox1.Visible = true;
                ipage = int.Parse(lblPageCounts.Text);
                ThreadStart ths = new ThreadStart(BindDataGridView);
                th = new Thread(ths);
                th.Start();
            }
        }
        private bool decideTime()
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

        #region [ 事件: 重置按钮_Click事件 ]

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBlock.Text = "";
            txtUserName.Text = "";
        }

        #endregion

       

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            //if (int.Parse(lblPageCounts.Text) > 1)
            //{
            //    lblPageCounts.Text = (int.Parse(lblPageCounts.Text) - 1).ToString();
            //    str = strr();
            //    pictureBox1.Visible = true;
            //    ipage = int.Parse(lblPageCounts.Text);
            //    ThreadStart ths = new ThreadStart(BindDataGridView);
            //    th = new Thread(ths);
            //    th.Start();
            //}
        }

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            //DataSet dsTemp=aBLL.GetEmployeeAttendanceInitialData("","", "","", 1, 10000, out strErr);
            //int pages = 0;
            //if (dsTemp != null)
            //{
            //    pages = int.Parse(dsTemp.Tables[1].Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
            //}

            //if (int.Parse(lblPageCounts.Text) < pages)
            //{
            //    lblPageCounts.Text = (int.Parse(lblPageCounts.Text) + 1).ToString();
            //    str = strr();
            //    pictureBox1.Visible = true;
            //    ipage = int.Parse(lblPageCounts.Text);
            //    ThreadStart ths = new ThreadStart(BindDataGridView);
            //    th = new Thread(ths);
            //    th.Start();
            //}
        }

        private void txtSkipPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    DataSet dsTemp = aBLL.GetEmployeeAttendanceInitialData("", "", "", "", 1, 10000, out strErr);
            //    int pages = 0;
            //    if (dsTemp != null)
            //    {
            //        pages = int.Parse(dsTemp.Tables[1].Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
            //    }

            //    if (int.Parse(txtSkipPage.Text) < pages && int.Parse(txtSkipPage.Text) > 0)
            //    {
            //        str = strr();
            //        pictureBox1.Visible = true;
            //        ipage = int.Parse(lblPageCounts.Text);
            //        ThreadStart ths = new ThreadStart(BindDataGridView);
            //        th = new Thread(ths);
            //        th.Start();
            //    }
            //}
        }

        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.Visible)
            //{
            //    str = strr();
            //    pictureBox1.Visible = true;
            //    ipage = 1;
            //    ThreadStart ths = new ThreadStart(BindDataGridView);
            //    th = new Thread(ths);
            //    th.Start();
            //    DataSet dsTemp = aBLL.GetEmployeeAttendanceInitialData("", "", "", "", 1, 10000, out strErr);
            //    int pages = 0;
            //    if (dsTemp != null)
            //    {
            //        pages = int.Parse(dsTemp.Tables[1].Rows[0][0].ToString()) / int.Parse(cmbSelectCounts.Text);
            //    }
            //    lblSumPage.Text = @"/" + pages.ToString() + "页";
            //    lblPageCounts.Text = "1";
            //}
        }

        #region【事件：重置】

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            dBLL.getDeptAddAll(ddlDept);
            txtBlock.Text = "";
            txtUserName.Text = "";
            dgrd.DataSource = null;
            lblCounts.Text = "共 0 条记录";
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

        private void btnLaws_Click(object sender, EventArgs e)
        {
            if (dgrd.DataSource != null && dgrd.Rows.Count>0)
            {
                new PrintCore.ExportExcel().Sql_ExportExcel(this.dgrd, "");
            }
            else
            {
                MessageBox.Show("没有导出信息，请查询后导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtBlock_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }


        private void txtUserName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region[打印 导出]
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel excel = new ExportExcel();
            excel.Sql_ExportExcel(dgrd, "考勤原始数据统计", "统计时间:" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgrd, "考勤原始数据统计", "统计时间:" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgrd, "考勤原始数据统计", "统计时间:" + dtpStartTime.Value.ToString("yyyy-MM-dd") + "--" + dtpEndTime.Value.ToString("yyyy-MM-dd"));
        }
        #endregion
    }
}