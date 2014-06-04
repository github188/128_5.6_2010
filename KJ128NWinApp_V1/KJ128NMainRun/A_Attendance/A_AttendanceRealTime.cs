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
    public partial class A_AttendanceRealTime : KJ128NMainRun.FromModel.FrmModel
    {
        #region [ 声明 ]

        private int intPageIndex = 1;//页索引
        private int intPageCount = 0;//页面总数
        private int intPageSize = 40;//每页行数
        string strErr = string.Empty;
        string[] del=null;
        int i=0;
        DBAcess db = new DBAcess();
        InfoClassBLL icBLL = new InfoClassBLL();
        TimerIntervalBLL tiBLL = new TimerIntervalBLL();
        AttendanceBLL aBLL = new AttendanceBLL();
        DeptBLL dBLL = new DeptBLL();
        HistoryAttendanceModel ham = new HistoryAttendanceModel();
        StationBLL sBLL = new StationBLL();
        KJ128NDBTable.A_Attendance.A_AttendaceBLL bll = new KJ128NDBTable.A_Attendance.A_AttendaceBLL();
        public static  int intUpDateID = 0;
        public static string name;
        public static string deptname;
        public static string strInWellDatetime;
        public static string strShortName;

        #endregion

        
        public A_AttendanceRealTime()
        {
            InitializeComponent();
            base.Text = "实时补单";
            base.lblMainTitle.Hide();
            base.btnAdd.Text = "补单";
            this.cmbSelectCounts.Items.Add("全部");
            base.btnSelectAll.Hide();
            base.btnLaws.Hide();
            timer1.Interval = KJ128NInterfaceShow.RefReshTime._rtTime;
            bindcombox(ddlClass, ddlTimerInterval);
            loadTree();
            lblPageCounts.Text = "";
            cmbSelectCounts.Text = "40";

            maxTimes = RefReshTime.intHostBackRefCount;
            timer1.Interval = RefReshTime.intHostBackRefTime;
        }
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
            //ddlRowsSet.DisplayMember = "Name";
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
            //lblCounts.Text = "";
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
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }
            intPageIndex = page;

            BindDataGridView();
        }

        #endregion

        #region [ 事件: 下一页按钮_Click事件 ]

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;
            if (page > intPageCount)
            {
                return;
            }
            intPageIndex = page;
            BindDataGridView();
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
                    BindDataGridView();
                }
            }
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

        public void RefreshBackUp()
        {
            if (!New_DBAcess.IsDouble)
            {
                BindDataGridView();
            }
            else
            {
                times = 0;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //刷最大次数(两次)
            if (times < maxTimes)
            {
                times++;

                //刷新
                BindDataGridView();
            }
            else
            {
                times = 0;
                timer1.Stop();
            }
        }

        #endregion        

        #region [ 事件: 查询按钮_Click事件 ]

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //lblCounts.Text = "";
            intPageIndex = 1;
            BindDataGridView();
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

        void BindDataGridView()
        {
            int intRowsCount = 0;
            string strWhere = string.Empty;
            if (DeptTree.SelectedNode!=null)
            {
                if (DeptTree.SelectedNode.Name != "0")
                {
                    strWhere += " and ei.DeptID = " + DeptTree.SelectedNode.Name.ToString();
                }
            }
            if (ddlTimerInterval.SelectedValue!=null && ddlTimerInterval.SelectedValue.ToString() != "0")
            {
                strWhere += " and RT.TimerIntervalID = " + ddlTimerInterval.SelectedValue.ToString();
            }

            if (ddlClass.SelectedValue != null && ddlClass.SelectedValue.ToString()!="0")
            {
                strWhere += " And RT.ClassID = " + ddlClass.SelectedValue.ToString();
            }

            if (txtUserName.Text.Trim() != "")
            {
                strWhere += " and ei.empName like '%" + txtUserName.Text.Trim() + "%'";
            }

            if (txtBlock.Text.Trim() != "")
            {
                try
                {
                    //Convert.ToInt32(txtBlock.Text.Trim());
                    //yc11
                    Convert.ToInt64(txtBlock.Text.Trim());
                    //yc12
                    strWhere += " and RTI.CodeSenderAddress =" + txtBlock.Text.Trim();
                }
                catch
                {
                    //lblCounts.ForeColor = Color.Red;
                    //lblCounts.Text = "发码器编号只能为数字!";
                    return;
                }
            }
            //strWhere += " And RT.EmployeeID is not null ";
            //qyz 屏蔽
            //if (cmbSelectCounts.Text.ToString() == "")
            //{
            //    intPageSize = 40;
            //}
            //else
            //{

            //    intPageSize = Convert.ToInt32(cmbSelectCounts.SelectedItem.ToString());
            //}

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
            if (ds != null && ds.Tables.Count>0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % intPageSize != 0 ? sumPage / intPageSize + 1 : sumPage / intPageSize;
                intPageCount = sumPage;
                ds.Tables[0].TableName = "A_AttendanceRealTimeSave";
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
                    
                    dgrd.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";

                    lblPageCounts.Text = intPageIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(intPageIndex, sumPage);
                }

                if (dgrd.Columns.Count >= 9)
                {
                    int width = (dgrd.Width - 50 - 2) / (dgrd.Columns.Count - 4);
                    if (width < 0)
                    {
                        width = 0;
                    }
                    dgrd.Columns[1].HeaderText = "卡号";
                    dgrd.Columns[1].ReadOnly = true;
                    dgrd.Columns[1].FillWeight = width;
                    dgrd.Columns[3].HeaderText = "姓名";
                    dgrd.Columns[3].ReadOnly = true;
                    dgrd.Columns[3].FillWeight = width;
                    dgrd.Columns[4].HeaderText = "所属部门";
                    dgrd.Columns[4].ReadOnly = true;
                    dgrd.Columns[4].FillWeight = width;
                    dgrd.Columns[5].HeaderText = "班次";
                    dgrd.Columns[5].ReadOnly = true;
                    dgrd.Columns[5].FillWeight = width;
                    dgrd.Columns[6].HeaderText = "下井时间";
                    dgrd.Columns[6].ReadOnly = true;
                    dgrd.Columns[6].FillWeight = width;


                    dgrd.Columns[2].Visible = false;
                    dgrd.Columns[7].Visible = false;
                    dgrd.Columns[8].Visible = false;

                }
            }
           

        }

        #endregion

        #region【窗体加载】

        private void A_AttendanceRealTime_Load(object sender, EventArgs e)
        {
            BindDataGridView();
        }

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int j = 0; j < dgrd.Rows.Count; j++)
            {
                if (((DataGridViewCheckBoxCell)dgrd.Rows[j].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgrd.Rows[j].Cells[0]).TrueValue)
                {
                    num++;
                }
            }
            if (num > 0)
            {
                if (MessageBox.Show("你确定要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //存入日志
                    //LogSave.Messages("[AttendanceRealTime]", LogIDType.UserLogID, "删除实时考勤补单，部门编号为："
                    //    +  dgrd.Rows[e.RowIndex].Cells[3].Value.ToString() + "，发码器编号：" + dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()
                    //    + "，员工姓名：" + dgrd.Rows[e.RowIndex].Cells[4].Value.ToString()
                    //    + "，上班时间：" + dgrd.Rows[e.RowIndex].Cells[7].Value.ToString() + "。");

                    for (int j = 0; j < dgrd.Rows.Count; j++)
                    {
                        if (((DataGridViewCheckBoxCell)dgrd.Rows[j].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgrd.Rows[j].Cells[0]).TrueValue)
                        {
                            aBLL.GetEmployeeAttendanceRealTimeDelete(Convert.ToInt32(dgrd.Rows[j].Cells[1].Value.ToString()), out strErr);
                        }
                    }
                    //aBLL.GetEmployeeAttendanceRealTimeDelete(Convert.ToInt32(dgrd.Rows[e.RowIndex].Cells[2].Value.ToString()), out strErr);
                    if (strErr == "Succeeds")
                    {
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        RefreshBackUp();
                    }



                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region 判断点多少个
           
            int i;
            try
            {
                i = 0;
                foreach (DataGridViewRow dgvr in dgrd.Rows)
                {
                    if (dgvr.Cells["delckek"].Value != null && dgvr.Cells["delckek"].Value.Equals("True"))
                    {
                        //这里要处理为空的
                        try
                        {
                            intUpDateID = int.Parse(dgvr.Cells["BlockID"].Value.ToString());
                            name = dgvr.Cells["EmployeeName"].Value.ToString();
                            deptname = dgvr.Cells["DeptName"].Value.ToString();
                            strInWellDatetime = dgvr.Cells["BeginWorkTime"].Value.ToString();
                            strShortName = dgvr.Cells["ClassShortName"].Value.ToString();
                        }
                        catch(Exception ex)
                        {

                        }

                        i += 1;
                    }
                }

             
            }
            catch
            {
                intUpDateID = -1;
                i = 0;
            }
            if (i == 0)
            {
                MessageBox.Show("请选择要补单的员工", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (i > 1)
            {
                MessageBox.Show("所选员工不能大于1人，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                //tempEmpID = intUpDateID;
                ////GetEmpInfo_Add();
                ////pl_AddEmpInfo.Visible = true;

                ////bt_AddEmpReset.Enabled = false;

                ////bt_AddEmpSave.Enabled = groupBox1.Enabled = groupBox3.Enabled = groupBox4.Enabled = groupBox5.Enabled = groupBox6.Enabled = true;
                ////tbc_EmpInfo.SelectedTab = tbp_EmpBasic;

                //A_FrmEmpInfo_AddEmpInfo frmAei = new A_FrmEmpInfo_AddEmpInfo(this);
                //frmAei.ShowDialog();
                //MessageBox.Show(intUpDateID.ToString());
                A_AttendanceRealTime_Add frm = new A_AttendanceRealTime_Add(this);
                frm.ShowDialog();
            }


            #endregion
            //A_AttendanceRealTime_Add frm = new A_AttendanceRealTime_Add();
            //DialogResult dr = new DialogResult();
            //dr = frm.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    BindDataGridView();
            //}
        }

        //private void DeptTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    BindDataGridView();
        //}
        private void bindcombox(ComboBox cb1, ComboBox cb2)
        {
            //cb1.DataSource = db.GetDataSet("select ID,ShortName from InfoClass").Tables[0];
            //cb1.DisplayMember = "ShortName";
            //cb1.ValueMember = "ID";
            //if (cb1.SelectedValue != null)
            //{
            //    cb2.DataSource = db.GetDataSet("select ID,NameShort from TimerInterval where ClassID=" + cb1.SelectedValue.ToString() + " union all select 0 ID, '所有' NameShort").Tables[0];
            //    cb2.DisplayMember = "NameShort";
            //    cb2.ValueMember = "ID";
            //}
            DataSet ds = db.GetDataSet("Select 0 as ID, '所有' as ShortName union all select ID,ShortName from InfoClass  ");
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //cb1.DataSource = null;
                cb1.DataSource = ds.Tables[0];
                cb1.DisplayMember = "ShortName";
                cb1.ValueMember = "ID";
                cb1.SelectedValue = 0;
            }
            if (cb1.SelectedValue != null)//&& !cb1.SelectedValue.ToString().Equals("0")
            {
                DataSet ds1;
                using (ds1=new DataSet())
                {
                    ds1 = db.GetDataSet("select 0 ID, '所有' NameShort union all  select ID,NameShort from TimerInterval where ClassID=" + cb1.SelectedValue.ToString() + " ");
                    if (ds1 != null && ds1.Tables.Count > 0)
                    {
                        //cb2.DataSource = null;
         
                        cb2.DataSource = ds1.Tables[0];
                        cb2.DisplayMember = "NameShort";
                        cb2.ValueMember = "ID";
                        cb2.SelectedValue = 0;
                    }
                }

            }
        }

       
        private void DeptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BindDataGridView();
        }

        //private void txtSkipPage_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        //lblCounts.Text = "";
        //        //lblCounts.ForeColor = Color.Red;

        //        if (txtSkipPage.Text.Trim() == "")
        //        {
        //            //lblCounts.Text = "跳转页数不能为空!";
        //            return;
        //        }
        //        if (txtSkipPage.Text.Trim() == "0")
        //        {
        //            //lblCounts.Text = "跳转页数不能为零!";
        //            return;
        //        }

        //        try
        //        {
        //            Convert.ToInt32(txtSkipPage.Text.Trim());
        //        }
        //        catch
        //        {
        //            //lblCounts.Text = "跳转页数只能为数字!";
        //            return;
        //        }

        //        if (Convert.ToInt32(txtSkipPage.Text.Trim()) >= intPageCount)
        //        {
        //            intPageIndex = intPageCount;
        //            txtSkipPage.Text = intPageCount.ToString();
        //        }
        //        else
        //        {
        //            intPageIndex = Convert.ToInt32(txtSkipPage.Text);
        //        }


        //        BindDataGridView();
        //    }
        //}


        #region【方法：关联班次】

        /// <summary>
        /// 关联班次
        /// </summary>
        /// <param name="cb1">班制</param>
        /// <param name="cb2">班次</param>
        private void GetClassInfo(ComboBox cb1, ComboBox cb2)
        {
            if (cb1.SelectedValue != null)
            {
                DataSet ds1;
                using (ds1 = new DataSet())
                {
                    ds1 = db.GetDataSet("select 0 ID, '所有' NameShort union all  select ID,NameShort from TimerInterval where ClassID=" + cb1.SelectedValue.ToString() + " ");
                    if (ds1 != null && ds1.Tables.Count > 0)
                    {
                        //cb2.DataSource = null;

                        cb2.DataSource = ds1.Tables[0];
                        cb2.DisplayMember = "NameShort";
                        cb2.ValueMember = "ID";
                        cb2.SelectedValue = 0;
                    }
                }
            }
        }

        #endregion

        #region【事件：选择班制】

        private void ddlClass_DropDownClosed(object sender, EventArgs e)
        {
            GetClassInfo(ddlClass, ddlTimerInterval);
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

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgrd, "实时补单");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgrd, "实时补单", "");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgrd, "实时补单");
        }




    }
}
