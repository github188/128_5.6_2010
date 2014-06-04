/*********************************************************************************************************
 * 
 * 修改时间：2010-8-31
 * 
 * 创 建 人：
 *  
 * 修 改 人：刘涛-czlt
 * 
 * 类功能描述：假别管理 UI层界面布局已经功能的实现
 * 
 * 
 * ********************************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.FromModel;
using KJ128NDBTable;
using KJ128NDataBase;
using Shine.Logs;
using Shine.Logs.LogType;
using PrintCore;

namespace KJ128NMainRun.AttendanceInfoSet
{
    public partial class NewHolidayTypeSet : FrmModel
    {
        #region 【自定义参数】
        /// <summary>
        /// 部门逻辑对象
        /// </summary>
        private A_DeptBLL deptBll = new A_DeptBLL();
        /// <summary>
        /// 请假管理逻辑对象
        /// </summary>
        private HolidayManageBLL hoilidayBll = new HolidayManageBLL();
        /// <summary>
        /// 查询条件
        /// </summary>
        public string m_StrWhere = "";
        /// <summary>
        /// 页显示行数
        /// </summary>
        private int m_PSize = 40;

        private int m_PCounts = 0;

        /// <summary>
        /// 热备当前刷新次数
        /// </summary>
        private int intRefReshCount = 0;

        /// <summary>
        /// 热备刷新最大次数
        /// </summary>
        private int intHostBackRefCount = 2;

        #region 【czlt-2010-8-24】
        private string deptNameFind = "";
        private string deptIdFind = "";
        private string cardIdFind = "";
        private string startTimeFind = "";
        private string endTimeFind = "";
        private string tableNameFind = "";
        private string empNameFind = "";
        private bool isFind = false;

        #endregion

        #endregion

        #region 【构造函数】
        public NewHolidayTypeSet()
        {
            InitializeComponent();
            cmbSelectCounts.SelectedIndex = 0;
            m_PSize = int.Parse(cmbSelectCounts.SelectedItem.ToString());
            //初始化查询时间
            DateTime dtTemp = DateTime.Now;
            dateTimePickerBegin.Value = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0);
            dateTimePickerEnd.Value = dtTemp;
            //加载部门树
            LoadDeptTree();
            TerSetButionTrue();   //czlt-2010-8-24

        }

        #region 【czlt-2010-8-24】
        /// <summary>
        /// 重写构造函数
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="cardid"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="tableName"></param>
        /// <param name="empName"></param>
        public NewHolidayTypeSet(string deptName, string deptid, string cardid, string startTime, string endTime, string tableName, string empName)
        {
            InitializeComponent();
            cmbSelectCounts.SelectedIndex = 0;
            m_PSize = int.Parse(cmbSelectCounts.SelectedItem.ToString());
            //初始化查询时间
            DateTime dtTemp = DateTime.Now;
            dateTimePickerBegin.Value = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0);
            dateTimePickerEnd.Value = dtTemp;
            //设置名称
            lblMainTitle.Visible = true;
            lblMainTitle.Text = "请假人员明细";
            //加载部门树
            LoadDeptTree();
            deptNameFind = deptName;
            deptIdFind = deptid;
            cardIdFind = cardid;
            startTimeFind = startTime;
            endTimeFind = endTime;
            tableNameFind = tableName;
            empNameFind = empName;
            TerSetButionFalse();
            GetSecalString(deptIdFind, cardIdFind, startTimeFind, endTimeFind);
            BindDataGridView(1, tableNameFind);
            dateTimePickerBegin.Value = DateTime.Parse(startTimeFind);

        }

        private void TerSetButionFalse()
        {
            //全选隐藏
            //btnSelectAll.Visible = false;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnLaws.Visible = false;
            btnSelectAll.Visible = false;
            panelLeft.Visible = false;
            //ClmDelete
            dgvMain.Columns[0].Visible = false;
            isFind = true;
        }


        private void TerSetButionTrue()
        {
            //全选隐藏
            //btnSelectAll.Visible = false;
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnLaws.Visible = true;
            btnSelectAll.Visible = true;
            panelLeft.Visible = true;
            dgvMain.Columns[0].Visible = true;
            isFind = false;
        }

        private void GetSecalString(string deptid, string cardid, string startTime, string endTime)
        {
            string strWhere = "";
            if (!String.IsNullOrEmpty(deptid))
            {
                strWhere += "and h.deptID = " + deptid;
            }

            if (!String.IsNullOrEmpty(cardid))
            {
                strWhere += "and h.BlockId = " + cardid;
            }
            strWhere += " and h.DataAttendance>='" + startTime + "' and h.DataAttendance<='" + endTime + "'";
            m_StrWhere = strWhere;
        }

        #endregion
        #endregion

        #region 【自定义方法】

        #region 【方法：查询条件判断】
        /// <summary>
        /// 查询条件判断
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if (dateTimePickerBegin.Value > dateTimePickerEnd.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //Czlt-2010-12-23 去掉七日限制
            //if (dateTimePickerEnd.Value.AddDays(-7).Date >= dateTimePickerBegin.Value.Date)
            //{
            //    MessageBox.Show("开始时间和结束时间之间天数不能大于7天，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            if (((Convert.ToInt16(dateTimePickerBegin.Value.Year) == Convert.ToInt16(dateTimePickerEnd.Value.Year) - 1 && Convert.ToInt16(dateTimePickerBegin.Value.Month) == 12 && Convert.ToInt16(dateTimePickerEnd.Value.Month) == 1)) || (dateTimePickerBegin.Value.Year == dateTimePickerEnd.Value.Year && ((dateTimePickerBegin.Value.Month == dateTimePickerEnd.Value.Month) || (dateTimePickerBegin.Value.Month == dateTimePickerEnd.Value.AddMonths(-1).Month))))                
            {
            }
            else
            {
                MessageBox.Show("不能跨两个以上月份查询数据，请重新选择！", "提示", MessageBoxButtons.OK);
                return false;
            }
            TimeSpan ts1 = new TimeSpan(dateTimePickerBegin.Value.Ticks);
            TimeSpan ts2 = new TimeSpan(dateTimePickerEnd.Value.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if ((int)ts.Days > 31)
            {
                MessageBox.Show("跨月查询不能多于三十一天！", "提示", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        #endregion

        #region 【方法：加载部门树】
        /// <summary>
        /// 加载部门树
        /// </summary>
        private void LoadDeptTree()
        {
            treeViewDept.Nodes.Clear();
            DataSet ds;
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = deptBll.GetDept_Dept();
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            else
            {
                dt = treeViewDept.BuildMenusEntity();
            }

            DataRow dr = dt.NewRow();
            setDataRow(ref dr, "0", "所有", "-1", false, false, 0);
            dt.Rows.Add(dr);

            treeViewDept.DataSouce = dt;
            treeViewDept.LoadNode("");
            
            treeViewDept.ExpandAll();
        }

        private void setDataRow(ref DataRow dr, string id, string name, string parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }
        #endregion

        #region 【方法: DataGridView数据绑定函数】
        /// <summary>
        /// 加载DataGridView数据
        /// </summary>
        public void BindDataGridView(int pIndex,string strTableName)
        {
            string strTableName2 = dateTimePickerEnd.Value.ToString("yyyyM");
            btnSelectAll.Text = "全选";
            if (pIndex < 1)
            {
                pIndex = 1;
            }

            if (pIndex == 1)
            {
                btnUpPage.Enabled = false;
            }

            DataSet ds = null;
            try
            {
                ds = hoilidayBll.HolidayManage_Query(pIndex, m_PSize, m_StrWhere, strTableName,strTableName2);
            }
            catch
            { }

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                if (sumPage != 0)
                {
                    sumPage = sumPage % m_PSize != 0 ? sumPage / m_PSize + 1 : sumPage / m_PSize;
                    m_PCounts = sumPage;//获取总页数
                    if (pIndex > sumPage)
                    {
                        if (sumPage == 0)
                        {
                            lblCounts.Text = "共 0 条记录";
                            lblPageCounts.Text = "1";
                            lblSumPage.Text = "/" + 1 + "页";
                            btnUpPage.Enabled = false;
                            btnDownPage.Enabled = false;
                            return;
                        }
                        pIndex = sumPage;
                    }

                    btnUpPage.Enabled = true;
                    btnDownPage.Enabled = true;
                    if (pIndex == 1)
                    {
                        btnUpPage.Enabled = false;
                    }
                    if (pIndex == sumPage)
                    {
                        btnDownPage.Enabled = false;
                    }
                }
                else
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                    pIndex = 0;
                }
                lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条记录";


                lblPageCounts.Text = pIndex.ToString();
                lblSumPage.Text = "/" + sumPage + "页";
                ds.Tables[0].TableName = "NewHolidayTypeSet";
                dgvMain.DataSource = ds.Tables[0];
                dgvMain.Columns["ID"].Visible = false;
                dgvMain.Columns["DeptID"].Visible = false;
            }
            else
            {
                lblCounts.Text = "共 0 条记录";
                btnUpPage.Enabled = false;
                btnDownPage.Enabled = false;
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + 1 + "页";
            }

        }
        #endregion

        #region 【方法：获取查询条件】
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetSecalString()
        {
            if (Check())
            {
                string strWhereSql = " and ";
                if (treeViewDept.SelectedNode != null)
                {
                    if (treeViewDept.SelectedNode.Level > 0)
                    {
                        strWhereSql += "h.deptID=" + treeViewDept.SelectedNode.Name;
                        strWhereSql += " and ";
                    }
                }
                if (!txtCardID.Text.Trim().Equals(""))
                {
                    strWhereSql += " h.BlockID=" + txtCardID.Text;
                    strWhereSql += " and ";
                }
                if (!txtName.Text.Trim().Equals(""))
                {
                    strWhereSql += " h.EmployeeName like '%" + txtName.Text + "%'";
                    strWhereSql += " and ";
                }
                strWhereSql += "h.DataAttendance>='" + dateTimePickerBegin.Value.ToString("yyyy-MM-dd") + "' and h.DataAttendance<='" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";
                m_StrWhere = strWhereSql;
            }
        }
        #endregion

        #region 【方法：热备刷新】
        /// <summary>
        /// 热备刷新
        /// </summary>
        /// <param name="bl">true:开启刷新;false:终止刷新</param>
        public void HostBackRefresh(bool bl)
        {
            if (bl)
            {
                if (timer_Refresh.Enabled)
                {
                    timer_Refresh.Enabled = false;
                }
                intRefReshCount = 0;
                timer_Refresh.Enabled = true;
            }
            else
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
        }

        #endregion

        #endregion


        #region 【系统事件方法】

        #region 【事件方法：查询输入框重置】
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtTemp = DateTime.Now;
                dateTimePickerBegin.Value = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0);
                dateTimePickerEnd.Value = dtTemp;
                txtCardID.Text = "";
                txtName.Text = "";

                lblCounts.Text = "共 0 条记录";
                btnUpPage.Enabled = false;
                btnDownPage.Enabled = false;
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + 1 + "页";

                dgvMain.DataSource =null;

                
            }
            catch(Exception ee)
            { }
        }
        #endregion

        #region 【事件方法：显示上一页数据】
        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (!btnDownPage.Enabled)
            {
                btnDownPage.Enabled = true;
            }
            if (page == 1)              //第一页时
            {

                btnUpPage.Enabled = false;
            }
            else if (page < 1)          //小于1时
            {
                return;
            }
            else
            {
                btnUpPage.Enabled = true;
            }
            BindDataGridView(page,dateTimePickerBegin.Value.ToString("yyyyM"));
        }
        #endregion

        #region 【事件方法：显示下一页数据】
        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (!btnUpPage.Enabled)
            {
                btnUpPage.Enabled = true;
            }
            if (page == m_PCounts)              //最后一页时
            {

                btnDownPage.Enabled = false;
            }
            else if (page > m_PCounts)          //大于最后一页时
            {
                return;
            }
            else
            {
                btnDownPage.Enabled = true;

            }
            BindDataGridView(page,dateTimePickerBegin.Value.ToString("yyyyM"));
        }
        #endregion

        #region 【事件方法：跳转至输入的页数】
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
                    if (page == 1)                  //跳至第一页时
                    {
                        btnUpPage.Enabled = false;
                        btnDownPage.Enabled = true;
                    }
                    else if (page == m_PCounts)     //跳至最后一页时
                    {
                        btnUpPage.Enabled = true;
                        btnDownPage.Enabled = false;
                    }
                    else
                    {
                        btnUpPage.Enabled = true;
                        btnDownPage.Enabled = true;
                    }
                    if (page > m_PCounts)           //大于记录的总页数
                    {
                        page = m_PCounts;
                        btnUpPage.Enabled = true;
                        btnDownPage.Enabled = false;
                    }
                    BindDataGridView(page, dateTimePickerBegin.Value.ToString("yyyyM"));
                }
            }
        }
        #endregion

        #region 【事件方法：显示每页的数量发生改变】
        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_PSize != int.Parse(cmbSelectCounts.SelectedItem.ToString()))
            {
                m_PSize = int.Parse(cmbSelectCounts.SelectedItem.ToString());
                BindDataGridView(1, dateTimePickerBegin.Value.ToString("yyyyM"));
            }
        }
        #endregion

        #region 【事件方法：全选择】
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text.Trim().Equals("全选"))
            {
                btnSelectAll.Text = "取消";
                foreach (DataGridViewRow row in dgvMain.Rows)
                {
                    row.Cells[0].Value = "True";
                }
            }
            else
            {
                btnSelectAll.Text = "全选";
                foreach (DataGridViewRow row in dgvMain.Rows)
                {
                    row.Cells[0].Value = "False";
                }
            }
        }
        #endregion

        #region 【事件方法：单选】
        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    btnSelectAll.Text = "全选";
                    if (dgvMain.Rows[e.RowIndex].Cells["ClmDelete"].Value != null && dgvMain.Rows[e.RowIndex].Cells["ClmDelete"].Value.ToString().Equals("True"))
                    {
                        dgvMain.Rows[e.RowIndex].Cells["ClmDelete"].Value = "False";
                    }
                    else
                    {
                        dgvMain.Rows[e.RowIndex].Cells["ClmDelete"].Value = "True";
                    }
                }
            }
        }
        #endregion

        #region 【事件方法：修改请假设置信息】
        private void btnLaws_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = null;
            int i = 0;
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.Cells["ClmDelete"].Value != null)
                {
                    if (row.Cells["ClmDelete"].Value.Equals("True"))
                    {
                        i++;
                        if (i > 1)
                        {
                            break;
                        }
                        r = row;
                    }
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要修改的请假设置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (i > 1)
            {
                MessageBox.Show("所选请假设置不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (r != null)
            {
                NewHolidayTypeSetAdd frmHoilidayTypeAdd = new NewHolidayTypeSetAdd(2, this);
                frmHoilidayTypeAdd.DgvRow = r;
                frmHoilidayTypeAdd.ShowDialog(this);
                btnSelectAll.Text = "全选";
            }
        }
        #endregion

        #region 【事件方法：删除请假信息】
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            ArrayList al = new ArrayList();
            ArrayList al1=new ArrayList();
            DialogResult result;
            string strError = "";
            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                if (dgvr.Cells["ClmDelete"].Value != null && dgvr.Cells["ClmDelete"].Value.Equals("True"))
                {
                    i += 1;
                    long id = long.Parse(dgvr.Cells[1].Value.ToString());
                    string strTableName = DateTime.Parse(dgvr.Cells[7].Value.ToString()).ToString("yyyyM");
                    al.Add(id);
                    al1.Add(strTableName);
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要删除的请假信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            result = MessageBox.Show("是否要删除选中请假信息？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnSelectAll.Text = "全选";
                for (int j = 0; j < al.Count; j++)
                {
                    long idTemp = (long)al[j];
                    string strTable = (string)al1[j];
                    //操作数据库删除
                    hoilidayBll.HolidayManage_Delete(idTemp, strTable, out strError);
                    //存入日志
                    LogSave.Messages("[NewHolidayTypeSet]", LogIDType.UserLogID, "删除请假信息，编号为：" + idTemp.ToString());
                }

                dgvMain.ClearSelection();

                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    m_StrWhere = " and h.DataAttendance>='" + dateTimePickerBegin.Value.ToString("yyyy-MM-dd") + "' and h.DataAttendance<='" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";
                    //刷新
                    BindDataGridView(1, dateTimePickerBegin.Value.ToString("yyyyM"));
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }
                //刷新
                
            }
        }
        #endregion

        #region 【事件方法：添加请假信息】
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewHolidayTypeSetAdd frmHoilidayTypeAdd = new NewHolidayTypeSetAdd(1, this);
            frmHoilidayTypeAdd.ShowDialog(this);
        }
        #endregion

        #region 【事件方法：查询请假信息】
        private void btnSecal_Click(object sender, EventArgs e)
        {
            //**********Czlt-2010-8-27 添加判断条件****************************
            if (Check())
            {
                GetSecalString();
                BindDataGridView(1, dateTimePickerBegin.Value.ToString("yyyyM"));
            }          
        }
        #endregion

        #region 【事件方法：热备刷新】
        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            btnSelectAll.Text = "全选";
            if (intRefReshCount >= intHostBackRefCount)
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
            else
            {
                intRefReshCount = intRefReshCount + 1;

                #region【刷新界面】
                m_StrWhere = " and h.DataAttendance>='" + dateTimePickerBegin.Value.ToString("yyyy-MM-dd") + "' and h.DataAttendance<='" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";
                BindDataGridView(1, dateTimePickerBegin.Value.ToString("yyyyM"));
                #endregion

            }
        }
        #endregion

        #region 【事件方法：选择树控件信息 获取信息】
        private void treeViewDept_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            m_StrWhere = "";
            treeViewDept.SelectedNode = e.Node;
            GetSecalString();
            BindDataGridView(1, dateTimePickerBegin.Value.ToString("yyyyM"));
        }
        #endregion

       
        #endregion

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
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

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region【打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel excel = new ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "请假管理");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "请假管理", "");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

            string showDate = dateTimePickerBegin.Value.ToString("yyyy.MM.dd") + "-" + dateTimePickerEnd.Value.ToString("yyyy.MM.dd");
            KJ128NDBTable.PrintBLL.Print(dgvMain, "请假管理", showDate + " 共" + dgvMain.Rows.Count.ToString() + "条记录");

        }
        #endregion
    }

}
