using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Threading;

namespace KJ128NMainRun.A_RealInWell
{
    public partial class FrmHisInWell : FromModel.FrmModel
    {

        delegate void ThreadBindData(int i);
        int ppindex;
        Thread th = null;
        private string TableName = string.Empty;
        private string TableName2 = string.Empty;
        #region 【自定义参数】
        /// <summary>
        /// 时段逻辑对象
        /// </summary>
        private TimerIntervalBLL timerIntervalBll = new TimerIntervalBLL();
        /// <summary>
        /// 历史下井逻辑对象
        /// </summary>
        private A_HisInWellBLL hisInwellBll = new A_HisInWellBLL();
        /// <summary>
        /// 查询条件
        /// </summary>
        private string m_StrWhere = "";
        /// <summary>
        /// 页显示行数
        /// </summary>
        private int m_PSize = 40;

        private int m_PCounts = 0;


        #endregion

        #region 【构造函数】
        public FrmHisInWell()
        {
            InitializeComponent();
            cmbSelectCounts.SelectedIndex = 0;
            m_PSize = int.Parse(cmbSelectCounts.SelectedItem.ToString());
            DateTime dtTemp = DateTime.Now;
            this.cmbSelectCounts.Items.Add("全部");
            dateTimePickerBegin.Value = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0);
            dateTimePickerEnd.Value = dtTemp;
            BindDeptTree(dateTimePickerBegin.Value, dateTimePickerEnd.Value);
            GetScaleString();
            pictureBox1.Visible = false;
            //BindData(1);
        }
        #endregion

        #region 【自定义方法】
        #region 【方法：绑定部门树信息】
        /// <summary>
        /// 绑定部门树
        /// </summary>
        private void BindDeptTree(DateTime beginTime, DateTime endTime)
        {
            DataSet ds = hisInwellBll.GetHisDeptTree(beginTime, endTime);
            LoadTree(treeViewDept, ds, "人", false);
        }
        #endregion

        #region【方法：绑定工种树信息】
        /// <summary>
        /// 绑定工种树
        /// </summary>
        private void BindWorkTypeTree(DateTime beginTime, DateTime endTime)
        {
            DataSet ds = hisInwellBll.GetHisWorkTypeTree(beginTime, endTime);
            LoadTree(treeViewWorkType, ds, "人", false);
        }
        #endregion

        #region【方法：绑定职务树信息】
        /// <summary>
        /// 绑定职务树
        /// </summary>
        private void BindDutyTree(DateTime beginTime, DateTime endTime)
        {
            DataSet ds = hisInwellBll.GetHisDutyInfoTree(beginTime, endTime);
            LoadTree(treeViewDuty, ds, "人", false);
        }
        #endregion

        #region 【方法：初始化树控件】
        /// <summary>
        /// 初始化树控件
        /// </summary>
        private void LoadTree(DegonControlLib.TreeViewControl tvc, DataSet dsTemp, string strName, bool blCount)
        {
            if (tvc.Nodes.Count > 0)
            {
                tvc.Nodes.Clear();
            }
            DataTable dt;

            if (dsTemp != null && dsTemp.Tables.Count > 0)
            {
                dt = dsTemp.Tables[0];
            }
            else
            {
                dt = tvc.BuildMenusEntity();
            }

            DataRow dr = dt.NewRow();
            SetDataRow(ref dr, 0, "所有", -1, false, blCount, 0);
            dt.Rows.Add(dr);

            tvc.DataSouce = dt;
            tvc.LoadNode(strName);


            tvc.ExpandAll();
            tvc.SelectedNode = tvc.Nodes[0];
            tvc.SetSelectNodeColor();
        }
        private void SetDataRow(ref DataRow dr, int id, string name, int parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }
        #endregion

        #region 【方法：查询条件判断】
        /// <summary>
        /// 查询条件判断
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            //qyz 可以跨月
            if ((dateTimePickerBegin.Value.AddYears(1).Year == dateTimePickerEnd.Value.Year || dateTimePickerBegin.Value.Year == dateTimePickerEnd.Value.Year) && ((dateTimePickerBegin.Value.Month == dateTimePickerEnd.Value.Month) || (dateTimePickerBegin.Value.AddMonths(1).Month == dateTimePickerEnd.Value.Month)))
            {
                this.TableName = "His_InOutMine_" + dateTimePickerBegin.Value.Year.ToString() + dateTimePickerBegin.Value.Month.ToString();
                this.TableName2 = "His_InOutMine_" + dateTimePickerEnd.Value.Year.ToString() + dateTimePickerEnd.Value.Month.ToString();
            }
            else
            {
                MessageBox.Show("不能跨多月份查询！", "提示", MessageBoxButtons.OK);
                return false;
            }
            if (Convert.ToDateTime(dateTimePickerEnd.Value) > DateTime.Now)
            {
                dateTimePickerEnd.Value = DateTime.Now;
            }
            if (Convert.ToDateTime(dateTimePickerBegin.Value) >= Convert.ToDateTime(dateTimePickerEnd.Value))
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            return true;
        }
        #endregion

        private void RunTH()
        {
            if (TableName != "" && TableName2 != "")
            {
                DataSet ds = null;
                try
                {
                    //DecideTime(dateTimePickerBegin, dateTimePickerEnd);
                    ds = hisInwellBll.GetHisInWell(TableName, TableName2, Convert.ToInt32(lblPageCounts.Text), m_PSize, m_StrWhere);
                  
                }
                catch { }
                if (!this.IsHandleCreated)
                    return;

                if (ds != null && ds.Tables.Count > 0)
                {
                    // 重新设置页数
                    int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                    sumPage = sumPage % m_PSize != 0 ? sumPage / m_PSize + 1 : sumPage / m_PSize;
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条信息";


                        lblPageCounts.Text = ppindex.ToString();
                        lblSumPage.Text = "/" + sumPage + "页";
                    }));

                    DataTable dtHisInWill = ds.Tables[0];
                    if (dtHisInWill.Columns["HisInOutMineID"] != null)
                    {
                        // 移除列
                        dtHisInWill.Columns.Remove("HisInOutMineID");
                        dtHisInWill.Columns.Remove("InStationAddress");
                        dtHisInWill.Columns.Remove("InStationHeadAddress");
                        dtHisInWill.Columns.Remove("UserID");
                        dtHisInWill.Columns.Remove("DeptID");
                        dtHisInWill.Columns.Remove("DutyID");
                        dtHisInWill.Columns.Remove("WorkTypeID");
                        dtHisInWill.Columns.Remove("OutStationAddress");
                        dtHisInWill.Columns.Remove("OutStationHeadAddress");
                        dtHisInWill.Columns.Remove("isMend");
                        //改变顺序
                        dtHisInWill.Columns["CodeSenderAddress"].SetOrdinal(0);
                        dtHisInWill.Columns["UserNo"].SetOrdinal(1);
                        dtHisInWill.Columns["UserName"].SetOrdinal(2);
                        dtHisInWill.Columns["DeptName"].SetOrdinal(3);
                        dtHisInWill.Columns["DutyName"].SetOrdinal(4);
                        dtHisInWill.Columns["WorkTypeName"].SetOrdinal(5);
                        dtHisInWill.Columns["InTime"].SetOrdinal(6);
                        dtHisInWill.Columns["InWellPlace"].SetOrdinal(7);
                        dtHisInWill.Columns["OutTime"].SetOrdinal(8);
                        dtHisInWill.Columns["OutWellPlace"].SetOrdinal(9);
                        dtHisInWill.Columns["ContinueTime"].SetOrdinal(10);
                        //
                        DataColumn dc = new DataColumn("持续时长");
                        ds.Tables[0].Columns.Add(dc);


                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Int64 iTime = Int64.Parse(ds.Tables[0].Rows[i]["ContinueTime"].ToString());
                            int iDay = (int)(iTime / 86400);
                            int iHour = (int)((iTime - iDay * 86400) / 3600);
                            int iMinute = (int)((iTime - iDay * 86400 - iHour * 3600) / 60);
                            ds.Tables[0].Rows[i]["持续时长"] = string.Format("{0}天{1}时{2}分{3}秒",
                                iDay, iHour, iMinute, iTime % 60);
                        }
                    }



                    dtHisInWill.TableName = "FrmHisInWell";
                    if (!dgvMain.IsHandleCreated)
                        return;
                    dgvMain.Invoke(new MethodInvoker(delegate()
                    {
                        dgvMain.DataSource = dtHisInWill;

                        //Czlt-2012-04-22 设置上下井时间的显示样式
                        dgvMain.Columns["InTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgvMain.Columns["OutTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        dgvMain.Columns["CodeSenderAddress"].HeaderText = "标识卡号";
                        dgvMain.Columns["UserNo"].HeaderText = "编号";
                        dgvMain.Columns["UserName"].HeaderText = "姓名";
                        dgvMain.Columns["DeptName"].HeaderText = "部门";
                        dgvMain.Columns["DutyName"].HeaderText = "职务";
                        dgvMain.Columns["WorkTypeName"].HeaderText = "工种";
                        dgvMain.Columns["InTime"].HeaderText = "入井时间";
                        dgvMain.Columns["InWellPlace"].HeaderText = "入井位置";
                        dgvMain.Columns["OutTime"].HeaderText = "出井时间";
                        dgvMain.Columns["OutWellPlace"].HeaderText = "出井位置";
                        dgvMain.Columns["ContinueTime"].Visible = false;
                    }));
                }

                SetPicTrueBoxVisible(false);
            }
        }
        #region 【方法: 遍历节点下的所有子节点】

        /// <summary>
        /// 遍历节点下的所有子节点
        /// </summary>
        /// <param name="tn"></param>
        private string GetNodeAllChild(TreeNode tn)
        {
            string strNodeChildName;

            strNodeChildName = tn.Name;
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    string strD = string.Empty;
                    if (n.Nodes.Count > 0)
                    {
                       strD= GetNodeAllChild(n);
                    }
                    if (!strD.Equals(""))
                    {
                        strNodeChildName += "," + n.Name + "," + strD;
                    }
                    else
                    {
                        strNodeChildName += "," + n.Name;
                    }
                }
            }
            return strNodeChildName;
        }
        #endregion
        #region 【方法：获取查询条件】
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetScaleString()
        {
            string strWhereSql = "";
            switch (tabControl1.SelectedTab.Text)
            {
                case "部门":
                    if (treeViewDept.SelectedNode.Level > 0)
                    {
                        //strWhereSql = " DeptID=" + treeViewDept.SelectedNode.Name;
                        if (treeViewDept.SelectedNode != null && !treeViewDept.SelectedNode.Name.Equals("0"))
                        {
                            //strWhereSql = " DeptID in  ( " + GetNodeAllChild(treeViewDept.SelectedNode) + " )";

                            string strD = GetNodeAllChild(treeViewDept.SelectedNode);
                            strWhereSql = " DeptID in  ( " + strD + " )";
                        }
                    }
                    break;
                case "工种":
                    if (treeViewWorkType.SelectedNode.Level > 0)
                    {
                        if (treeViewWorkType.SelectedNode.Name.Equals("99999"))
                        {
                            strWhereSql = "codeSenderAddress not in(select distinct codeSenderAddress from " + TableName + " where WorkTypeName <>'') ";
                        }
                        else
                        {
                            strWhereSql = " WorkTypeID=" + treeViewWorkType.SelectedNode.Name;
                        }
                    }
                    break;
                case "职务":
                    if (treeViewDuty.SelectedNode.Level > 0)
                    {
                        if (treeViewDuty.SelectedNode.Name.Equals("99999"))
                        {
                            strWhereSql = "codeSenderAddress not in(select distinct codeSenderAddress from " + TableName + " where DutyName <>'无') ";
                        }
                        else
                        {
                            strWhereSql = " DutyID=" + treeViewDuty.SelectedNode.Name;
                        }
                    }
                    break;
            }
            //获取标识卡条件
            if (!txtCardID.Text.Trim().Equals(""))
            {
                if (!strWhereSql.Equals(""))
                {
                    strWhereSql += " and ";
                }
                strWhereSql += " CodeSenderAddress=" + txtCardID.Text;
            }
            if (!txtName.Text.Trim().Equals(""))
            {
                if (!strWhereSql.Equals(""))
                {
                    strWhereSql += " and ";
                }
                strWhereSql += " UserName like '%" + txtName.Text + "%' ";
            }
            if (!strWhereSql.Equals(""))
            {
                strWhereSql += " and ";
            }
            strWhereSql += " inTime>='" + dateTimePickerBegin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and inTime<='" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            m_StrWhere = strWhereSql;
        }
        #endregion

        #region 【绑定数据】
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="pIndex">页索引</param>
        private void BindData()
        {
            if (ppindex < 1)
            {
                ppindex = 1;
                return;
            }

            if (ppindex == 1)
            {
                 if (!this.IsHandleCreated)
                        return;
                 this.Invoke(new MethodInvoker(delegate()
                 {
                     btnUpPage.Enabled = false;
                 }));
            }

            DataSet ds = null;
            try
            {
                //DecideTime(dateTimePickerBegin, dateTimePickerEnd);
                ds = hisInwellBll.GetHisInWell(TableName, TableName2, ppindex, m_PSize, m_StrWhere);
            }
            catch { }

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                if (sumPage != 0)
                {
                    sumPage = sumPage % m_PSize != 0 ? sumPage / m_PSize + 1 : sumPage / m_PSize;
                    m_PCounts = sumPage;//获取总页数
                    if (!this.IsHandleCreated)
                        return;
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        if (ppindex > sumPage)
                        {
                            if (sumPage == 0)
                            {
                                lblCounts.Text = "共 0 条信息";
                                lblPageCounts.Text = "1";
                                lblSumPage.Text = "/" + 1 + "页";
                                btnUpPage.Enabled = false;
                                btnDownPage.Enabled = false;
                                return;
                            }
                            ppindex = sumPage;
                        }

                        btnUpPage.Enabled = true;
                        btnDownPage.Enabled = true;
                        if (ppindex == 1)
                        {
                            btnUpPage.Enabled = false;
                        }
                        if (ppindex == sumPage)
                        {
                            btnDownPage.Enabled = false;
                        }
                    }));
                }
                else
                {
                    if (!this.IsHandleCreated)
                        return;
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        btnUpPage.Enabled = false;
                        btnDownPage.Enabled = false;
                        ppindex = 0;
                    }));
                }
                 if (!this.IsHandleCreated)
                        return;
                 this.Invoke(new MethodInvoker(delegate()
                 {
                     lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条信息";


                     lblPageCounts.Text = ppindex.ToString();
                     lblSumPage.Text = "/" + sumPage + "页";
                 }));
                //dgvMain.DataSource = ds.Tables[0];
                DataTable dtHisInWill = ds.Tables[0];
                //处理datatable
                if (dtHisInWill.Columns["HisInOutMineID"] != null)
                {
                    // 移除列
                    dtHisInWill.Columns.Remove("HisInOutMineID");
                    dtHisInWill.Columns.Remove("InStationAddress");
                    dtHisInWill.Columns.Remove("InStationHeadAddress");
                    dtHisInWill.Columns.Remove("UserID");
                    dtHisInWill.Columns.Remove("DeptID");
                    dtHisInWill.Columns.Remove("DutyID");
                    dtHisInWill.Columns.Remove("WorkTypeID");
                    dtHisInWill.Columns.Remove("OutStationAddress");
                    dtHisInWill.Columns.Remove("OutStationHeadAddress");
                    dtHisInWill.Columns.Remove("isMend");
                    //改变顺序
                    dtHisInWill.Columns["CodeSenderAddress"].SetOrdinal(0);
                    dtHisInWill.Columns["UserNo"].SetOrdinal(1);
                    dtHisInWill.Columns["UserName"].SetOrdinal(2);
                    dtHisInWill.Columns["DeptName"].SetOrdinal(3);
                    dtHisInWill.Columns["DutyName"].SetOrdinal(4);
                    dtHisInWill.Columns["WorkTypeName"].SetOrdinal(5);
                    dtHisInWill.Columns["InTime"].SetOrdinal(6);
                    dtHisInWill.Columns["InWellPlace"].SetOrdinal(7);
                    dtHisInWill.Columns["OutTime"].SetOrdinal(8);
                    dtHisInWill.Columns["OutWellPlace"].SetOrdinal(9);
                    dtHisInWill.Columns["ContinueTime"].SetOrdinal(10);
                    //
                    DataColumn dc = new DataColumn("持续时长");
                    ds.Tables[0].Columns.Add(dc);


                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Int64 iTime = Int64.Parse(ds.Tables[0].Rows[i]["ContinueTime"].ToString());
                        int iDay = (int)(iTime / 86400);
                        int iHour = (int)((iTime - iDay * 86400) / 3600);
                        int iMinute = (int)((iTime - iDay * 86400 - iHour * 3600) / 60);
                        ds.Tables[0].Rows[i]["持续时长"] = string.Format("{0}天{1}时{2}分{3}秒",
                            iDay, iHour, iMinute, iTime % 60);
                    }
                }



                dtHisInWill.TableName = "FrmHisInWell";
                if (!dgvMain.IsHandleCreated)
                        return;
                 dgvMain.Invoke(new MethodInvoker(delegate()
                 {
                     dgvMain.DataSource = dtHisInWill;

                     //Czlt-2012-04-22 设置上下井时间的显示样式
                     dgvMain.Columns["InTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                     dgvMain.Columns["OutTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                     dgvMain.Columns["CodeSenderAddress"].HeaderText = "标识卡号";
                     dgvMain.Columns["UserNo"].HeaderText = "编号";
                     dgvMain.Columns["UserName"].HeaderText = "姓名";
                     dgvMain.Columns["DeptName"].HeaderText = "部门";
                     dgvMain.Columns["DutyName"].HeaderText = "职务";
                     dgvMain.Columns["WorkTypeName"].HeaderText = "工种";
                     dgvMain.Columns["InTime"].HeaderText = "入井时间";
                     dgvMain.Columns["InWellPlace"].HeaderText = "入井位置";
                     dgvMain.Columns["OutTime"].HeaderText = "出井时间";
                     dgvMain.Columns["OutWellPlace"].HeaderText = "出井位置";
                     dgvMain.Columns["ContinueTime"].Visible = false;
                 }));

                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column1", 0 });
                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column2", 1 });
                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column3", 2 });
                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column4", 3 });
                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column5", 4 });
                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column7", 5 });
                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column9", 6 });
                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column6", 7 });
                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column8", 8 });
                //dgvMain.Invoke(new DgvColumnDisplaySet(this.SetDgvColumnDisplay), new object[] { "Column10", 9 });

            }
            else
            {
                 if (!this.IsHandleCreated)
                        return;
                 this.Invoke(new MethodInvoker(delegate()
                 {
                     lblCounts.Text = "共 0 条信息";
                     btnUpPage.Enabled = false;
                     btnDownPage.Enabled = false;
                     lblPageCounts.Text = "1";
                     lblSumPage.Text = "/" + 1 + "页";
                 }));
            }

            SetPicTrueBoxVisible(false);
        }
        #endregion

        private delegate void PicTureBoxVisibleCallBack(bool flag);
        private void SetPicTrueBoxVisible(bool flag)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    PicTureBoxVisibleCallBack pcb = new PicTureBoxVisibleCallBack(SetPicTrueBoxVisible);
                    Invoke(pcb, new object[] { flag });
                }
                else
                {
                    pictureBox1.Visible = flag;
                }
            }
            catch { }
        }

        private delegate void DgvColumnDisplaySet(string columnname, int index);
        private void SetDgvColumnDisplay(string columnname, int index)
        {
            dgvMain.Columns[columnname].DisplayIndex = index;
        }

        #endregion

        #region 【系统事件方法】
        #region 【事件方法：选择选项卡】
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null)
            {
                switch (e.TabPage.Text)
                {
                    case "部门":
                        BindDeptTree(dateTimePickerBegin.Value, dateTimePickerEnd.Value);
                        break;
                    case "工种":
                        BindWorkTypeTree(dateTimePickerBegin.Value, dateTimePickerEnd.Value);
                        break;
                    case "职务":
                        BindDutyTree(dateTimePickerBegin.Value, dateTimePickerEnd.Value);
                        break;
                }
            }
        }
        #endregion

        #region 【事件方法：选择条件后查询数据】
        private void btnSecal_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {
                    GetScaleString();
                    //Czlt-2012-4-25 注销
                    pictureBox1.Visible = true;
                    ppindex = 1;
                    ThreadStart ths = new ThreadStart(BindData);
                    th = new Thread(ths);
                    th.Start();
                    //BindData(1);
                }
            }
            catch (Exception ex)
            {
                SetPicTrueBoxVisible(false);
            }
        }
        #endregion

        #region 【事件方法：重置查询条件】
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.dateTimePickerBegin.Value = DateTime.Now.Date;
                dateTimePickerEnd.Value = DateTime.Now;
                txtCardID.Text = "";
                txtName.Text = "";
                dgvMain.DataSource = new DataTable();

                ppindex = 1;

                lblCounts.Text = "共 0 条信息";
                btnUpPage.Enabled = false;
                btnDownPage.Enabled = false;
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + 1 + "页";
                //ThreadStart ths = new ThreadStart(RunTH);
                //th = new Thread(ths);
                //th.Start();
            }
            catch
            {
                pictureBox1.Visible = false;
            }
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
            pictureBox1.Visible = true;
            ppindex = page;
            ThreadStart ths = new ThreadStart(RunTH);
            th = new Thread(ths);
            th.Start();
            //BindData(page);
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
            pictureBox1.Visible = true;
            ppindex = page;
            ThreadStart ths = new ThreadStart(RunTH);
            th = new Thread(ths);
            th.Start();
            //BindData(page);
        }
        #endregion

        #region 【事件方法：跳转至输入的页数】
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
                        pictureBox1.Visible = true;
                        ppindex = page;
                        ThreadStart ths = new ThreadStart(RunTH);
                        th = new Thread(ths);
                        th.Start();
                        //BindData(page);
                    }
                }
                catch (Exception ex)
                {
                    pictureBox1.Visible = false;
                }
            }
        }
        #endregion

        #region 【事件方法：显示每页的数量发生改变】
        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectCounts.Text.Trim() == "全部")
                m_PSize = 9999999;
            else
                m_PSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);
            pictureBox1.Visible = true;
            ppindex = 1;
            ThreadStart ths = new ThreadStart(RunTH);
            th = new Thread(ths);
            th.Start();
            //BindData(1);
        }
        #endregion

        #region 【事件方法：选择树控件信息 获取信息】
        private void treeViewDept_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //switch (tabControl1.SelectedTab.Text)
            //{
            //    case "部门":
            //        treeViewDept.SelectedNode = e.Node;
            //        break;
            //    case "工种":
            //        treeViewWorkType.SelectedNode = e.Node;
            //        break;
            //    case "职务":
            //        treeViewDuty.SelectedNode = e.Node;
            //        break;
            //}

            //if (Check())
            //{
            //    GetScaleString();
            //    pictureBox1.Visible = true;
            //    ppindex = 1;
            //    ThreadStart ths = new ThreadStart(RunTH);
            //    th = new Thread(ths);
            //    th.Start();
            //    //BindData(1);
            //}
        }
        #endregion


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

        #region【方法：判断时间】

        private bool DecideTime(DateTimePicker dtpBegin, DateTimePicker dtpEnd)
        {
            if (dtpBegin.Value.AddYears(1).Year == dtpEnd.Value.Year && dtpBegin.Value.Year == dtpEnd.Value.Year && dtpBegin.Value.Month == dtpEnd.Value.Month)
            {
                this.TableName = "His_InOutMine_" + dtpEnd.Value.Year.ToString() + dtpEnd.Value.Month.ToString();
            }
            else
            {
                MessageBox.Show("不能跨月查询！", "提示", MessageBoxButtons.OK);
                return false;
            }
            if (Convert.ToDateTime(dtpEnd.Text) > DateTime.Now)
            {
                dtpEnd.Value = DateTime.Now;
            }
            if (Convert.ToDateTime(dtpBegin.Text) >= Convert.ToDateTime(dtpEnd.Text))
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (Convert.ToDateTime(dtpBegin.Text).AddDays(7) < Convert.ToDateTime(dtpEnd.Text))
            {
                MessageBox.Show("开始时间与结束时间相差不能大于7天！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        #endregion

        private void FrmHisInWell_Load(object sender, EventArgs e)
        {

        }

        private void dgvMain_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region[打印 导出]
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "历史下井人员信息", "统计时间:" + dateTimePickerBegin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "--" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "历史下井人员信息", "统计时间:" + dateTimePickerBegin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "--" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgvMain, "历史下井人员信息", "统计时间:" + dateTimePickerBegin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "--" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        #endregion
    }
}
