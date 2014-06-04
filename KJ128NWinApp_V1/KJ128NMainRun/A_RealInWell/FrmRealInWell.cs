using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using KJ128NDBTable;
using Wilson.Controls.Docking;

namespace KJ128NMainRun.A_RealInWell
{
    ///// <summary>
    ///// 列配置
    ///// </summary>
    //public struct ColumnConfig
    //{
    //    public string columnID;
    //    public string columnName;
    //    public bool isShow;
    //}
    ///// <summary>
    ///// 选项卡配置
    ///// </summary>
    //public struct TabPageConfig
    //{
    //    public string tabpageID;
    //    public string tabpageName;
    //    public bool isShow;
    //}

    public partial class FrmRealInWell : FromModel.FrmModel
    {
        #region 【自定义参数】
        /// <summary>
        /// 实时显示配置文件路径
        /// </summary>
        public readonly string m_strPath = Directory.GetCurrentDirectory() + "\\realInWellShowConfig.xml";
        /// <summary>
        /// 列配置集合
        /// </summary>
        //public ColumnConfig[] columnConfigs = new ColumnConfig[17];
        /// <summary>
        /// 选项卡配置集合
        /// </summary>
        //public TabPageConfig[] tabpageConfigs = new TabPageConfig[6];
        /// <summary>
        /// 实时下井逻辑对象
        /// </summary>
        private A_RealTimeInWellBll realtimeInwellBll = new A_RealTimeInWellBll();
        /// <summary>
        /// 班次逻辑对象
        /// </summary>
        private TimerIntervalBLL timerIntervalBll = new TimerIntervalBLL();
        /// <summary>
        /// 页显示行数
        /// </summary>
        private int m_PSize = 40;
        /// <summary>
        /// 查询条件
        /// </summary>
        private string m_StrWhere = "";
        System.Timers.Timer timer = new System.Timers.Timer();
        private int m_PCounts = 0;
        private delegate void SetGetTabControlInfoBack();


        //czlt-2010-9-16*start*****
        SortOrder sortDirection = new SortOrder();
        private int index = 0;
        private bool isHearderSort = false;
        private bool isClickSort;
        ListSortDirection listSort;
        //czlt-2010-9-16*end*****

        #endregion
        DockPanel dockPanel = null;
        #region 【构造函数】
        public FrmRealInWell(DockPanel dock)
        {
            InitializeComponent();
            dockPanel = dock;
            timer.Interval = KJ128NInterfaceShow.RefReshTime._rtTime;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
            this.cmbSelectCounts.Items.Add("全部");
            timerIntervalBll.BindComBoxAddAll(cmbClass);
            cmbSelectCounts.SelectedIndex = 0;
            m_PSize = 40;
            
            BindDeptTree();
            BindData(1);
        }

        
        #endregion

        #region 【绑定数据】
        private delegate void SetBindData(int pIndex);
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="pIndex">页索引</param>
        public void BindData(int pIndex)
        {
            if (this.InvokeRequired)
            {
                SetBindData d = new SetBindData(BindData);
                Invoke(d, new object[] { pIndex });
            }
            else
            {
                if (pIndex < 1)
                {
                    MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                    return;
                }

                if (pIndex == 1)
                {
                    btnUpPage.Enabled = false;
                }

                DataSet ds = realtimeInwellBll.GetRealTimeInWell(pIndex, m_PSize, m_StrWhere);

                if (ds.Tables != null && ds.Tables.Count > 0)
                {
                    // 重新设置页数
                    int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                    sumPage = sumPage % m_PSize != 0 ? sumPage / m_PSize + 1 : sumPage / m_PSize;
                    m_PCounts = sumPage;//获取总页数
                    #region[qyz 设置显示内容]
                    DataTable dt = ds.Tables[0];
                    dt.Columns.Remove("EmpNo");
                    dt.Columns.Remove("classGroup");
                    dt.Columns.Remove("ClassName");
                    dt.Columns.Remove("Directional");
                    dt.Columns.Remove("DeptID");
                    dt.Columns.Remove("workTypeID");
                    dt.Columns.Remove("DutyID");
                    dt.Columns.Remove("DutyClassID");
                    dt.Columns.Remove("InHereLong");
                    #endregion
                    dt.TableName = "FrmRealInWell";
                    if (pIndex > sumPage)
                    {
                        if (sumPage == 0)
                        {
                            lblCounts.Text = "共 0 条信息";
                            lblPageCounts.Text = "1";
                            lblSumPage.Text = "/" + 1 + "页";
                            btnUpPage.Enabled = false;
                            btnDownPage.Enabled = false;
                            dgvMain.DataSource = dt;
                            #region[qyz 设置显示内容]
                            dgvMain.Columns["CodeSenderAddress"].HeaderText = "标识卡";
                            dgvMain.Columns["EmpName"].HeaderText = "姓名";
                            dgvMain.Columns["DeptName"].HeaderText = "部门";
                            dgvMain.Columns["WorkTypeName"].HeaderText = "工种";
                            dgvMain.Columns["DutyName"].HeaderText = "职务";
                            dgvMain.Columns["IntervalName"].HeaderText = "班次";
                            dgvMain.Columns["StationHeadPlace"].HeaderText = "下井位置";
                            dgvMain.Columns["InTime"].HeaderText = "下井时间";
                            dgvMain.Columns["InTimeLong"].HeaderText = "下井时长";
                            dgvMain.Columns["InWellPlace"].HeaderText = "现处位置";
                            dgvMain.Columns["StationHeadDetectTime"].HeaderText = "检测时间";
                            #endregion
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

                    lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条信息";


                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";
                   
                    
                    dgvMain.DataSource = dt;
                    #region[qyz 设置显示内容]
                    dgvMain.Columns["CodeSenderAddress"].HeaderText = "标识卡";
                    dgvMain.Columns["EmpName"].HeaderText = "姓名";
                    dgvMain.Columns["DeptName"].HeaderText = "部门";
                    dgvMain.Columns["WorkTypeName"].HeaderText = "工种";
                    dgvMain.Columns["DutyName"].HeaderText = "职务";
                    dgvMain.Columns["IntervalName"].HeaderText = "班次";
                    dgvMain.Columns["StationHeadPlace"].HeaderText = "下井位置";
                    dgvMain.Columns["InTime"].HeaderText = "下井时间";
                    dgvMain.Columns["InTimeLong"].HeaderText = "下井时长";
                    dgvMain.Columns["InWellPlace"].HeaderText = "现处位置";
                    dgvMain.Columns["StationHeadDetectTime"].HeaderText = "检测时间";
                    #endregion
                }
                else
                {
                    lblCounts.Text = "共 0 条信息";
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/" + 1 + "页";
                    dgvMain.DataSource = null;
                }
                //****czlt-2010-9-16**start****
                if (isHearderSort == true)
                {                
                    DataGridViewColumn newColumn = dgvMain.Columns[index];                  
                    dgvMain.Sort(newColumn, listSort);
                }
                //****czlt-2010-9-16**end****
            }

            

        }
        #endregion

        #region 【方法组：绑定各个树控件信息】
        #region 【方法：绑定部门树信息】
        /// <summary>
        /// 绑定部门树
        /// </summary>
        private void BindDeptTree()
        {
            DataSet ds = realtimeInwellBll.GetRealTime_DeptTree();
            LoadTree(treeViewDept, ds, "人", true);
        }
        #endregion

        #region【方法：绑定工种树信息】
        /// <summary>
        /// 绑定工种树
        /// </summary>
        private void BindWorkTypeTree()
        {
            DataSet ds = realtimeInwellBll.GetRealTime_WorkTypeTree();
            LoadTree(treeViewWorkType, ds, "人", true);
        }
        #endregion

        #region【方法：绑定职务树信息】
        /// <summary>
        /// 绑定职务树
        /// </summary>
        private void BindDutyTree()
        {
            DataSet ds = realtimeInwellBll.GetRealTime_DutyInfoTree();
            LoadTree(treeViewDuty, ds, "人", true);
        }
        #endregion

        #region 【方法：初始化树控件】
        /// <summary>
        /// 初始化树控件
        /// </summary>
        private void LoadTree(DegonControlLib.TreeViewControl tvc, DataSet dsTemp, string strName, bool blCount)
        {
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

        #endregion

        #region 【方法：获取各个选项卡的信息】
        /// <summary>
        /// 获取各个选项卡信息
        /// </summary>
        public void GetTabControlInfo()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetGetTabControlInfoBack d = new SetGetTabControlInfoBack(GetTabControlInfo);
                    Invoke(d);
                }
                else
                {
                    if (tabControl1.SelectedTab != null)
                    {
                        switch (tabControl1.SelectedTab.Text)
                        {
                            case "部门":
                                BindDeptTree();
                                break;
                            case "工种":
                                BindWorkTypeTree();
                                break;
                            case "职务":
                                BindDutyTree();
                                break;
                        }
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 【方法：获取查询条件】
        /// <summary>
        /// 得到查询条件
        /// </summary>
        /// <returns></returns>
        private void GetSecalString()
        {
            string strWhereSql = "";
            switch (tabControl1.SelectedTab.Text)
            {
                case "部门":
                    if (treeViewDept.SelectedNode !=null && treeViewDept.SelectedNode.Level > 0)
                    {
                        //strWhereSql = " DeptID in (" + GetNodeAllChild(treeViewDept.SelectedNode) + ")";

                        string strDeptId = GetNodeAllChild(treeViewDept.SelectedNode);

                        strWhereSql = " DeptID in (" + strDeptId + ")";
                    }
                    break;
                case "工种":
                    if (treeViewWorkType.SelectedNode != null && treeViewWorkType.SelectedNode.Level > 0)
                    {
                        if (treeViewWorkType.SelectedNode.Name.Equals("99999"))
                        {
                            strWhereSql = "codeSenderAddress not in(select codeSenderAddress from View_RealTimeInWell where WorktypeName <>'')";
                        }
                        else
                        {
                            strWhereSql = " WorkTypeID=" + treeViewWorkType.SelectedNode.Name;
                        }
                    }
                    break;
                case "职务":
                    if (treeViewDuty.SelectedNode != null && treeViewDuty.SelectedNode.Level > 0)
                    {
                        if (treeViewDuty.SelectedNode.Name.Equals("99999"))
                        {
                            strWhereSql = "codeSenderAddress not in(select codeSenderAddress from View_RealTimeInWell where DutyID IS not NULL and DutyID<>0)";
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
                strWhereSql += " EmpName like '%" + txtName.Text + "%'";
            }
            if (cmbClass.SelectedIndex>0)
            {
                if (!strWhereSql.Equals(""))
                {
                    strWhereSql += " and ";
                }
                strWhereSql += " IntervalName='" + cmbClass.Text.ToString() + "'";
            }
            m_StrWhere = strWhereSql;
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
                        BindDeptTree();
                        break;
                    case "工种":
                        BindWorkTypeTree();
                        break;
                    case "职务":
                        BindDutyTree();
                        break;
                     
                }
                GetSecalString();
                BindData(1);
            }
        }
        #endregion

        #region 【事件方法：按各个条件查询数据】
        private void btnSecal_Click(object sender, EventArgs e)
        {
            //****czlt-2010-9-13**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-13**end****

            GetSecalString();
            BindData(1);
        }
        #endregion

        #region 【事件方法：显示上一页的数据】
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
            BindData(page);
        }
        #endregion

        #region 【事件方法：显示下一页的数据】
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
            BindData(page);
        }
        #endregion

        #region 【事件方法：按下回车，显示改页信息】
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
                        BindData(page);
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        #endregion

        #region 【事件方法：选择每页显示行数改变后发生】
        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (cmbSelectCounts.Text.Trim() == "全部")
                    m_PSize = 9999999;
                else
                    m_PSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);

                BindData(1);
        }
        #endregion

        #region 【事件方法：重置查询条件】
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCardID.Text = "";
            txtName.Text = "";

            //****czlt-2010-9-13**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-13**end****

            cmbClass.SelectedIndex = 0;
            //qyz 导致实时信息不刷新问题    屏蔽2012-3-27
            //timer.Enabled = false;
            GetSecalString();
            BindData(1);
            if (ckbRealTime.Checked)
            {
                timer.Enabled = true;
            }
        }
        #endregion

        #region 【事件方法：弹出显示内容框】
        private void btnShow_Click(object sender, EventArgs e)
        {
            FrmInWellShowConfig frmInWellConfig = new FrmInWellShowConfig(this);
            frmInWellConfig.ShowDialog(this);
        }
        #endregion

        #region 【事件方法：定时更新数据】
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (ckbRealTime.Checked)
            {
                //qyz 修改 获取焦点刷新
                if (this.IsActivated || this.DockHandler == dockPanel.ActiveDocument.DockHandler)
                {
                    timer.Enabled = false;
                    GetTabControlInfo();
                    BindData(int.Parse(lblPageCounts.Text.Trim()));
                    timer.Enabled = true;
                }
            }
        }
        #endregion

        #region 【事件方法：关闭窗体】
        private void FrmRealInWell_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (timer !=null)
            {
                this.timer.Enabled = false;
                this.timer.Close();
            }
        }
        #endregion

        #region 【事件方法：选择树控件信息 获取信息】
        private void treeViewDept_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //qyz 导致实时信息不刷新问题    屏蔽2012-3-27
            //timer.Enabled = false;
            switch (tabControl1.SelectedTab.Text)
            {
                case "部门":
                    treeViewDept.SelectedNode = e.Node;
                    break;
                case "工种":
                    treeViewWorkType.SelectedNode = e.Node;
                    break;
                case "职务":
                    treeViewDuty.SelectedNode = e.Node;
                    break;
               
            }

            //****czlt-2010-9-13**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-13**end****

            GetSecalString();
            BindData(1);
            if (ckbRealTime.Checked)
            {
                timer.Enabled = true;
            }

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

        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            try
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
               
            }
            catch (Exception ex)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            try
            {
                if (dgv.Columns.Count > 0)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dgv.Columns[i].DefaultCellStyle.NullValue = "——";
                    }
                }
            }
            catch (Exception ex)
            {

            }
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


        #region Czlt-2010-9-16***点击表头信息****
        /// <summary>
        /// 标头点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {           
            index = e.ColumnIndex;
            if (isClickSort == false)
            {
                listSort = ListSortDirection.Ascending;
                isClickSort = true;
            }
            else if (isClickSort == true)
            {
                listSort = ListSortDirection.Descending;
                isClickSort = false;
            }         

            isHearderSort = true;
        }


        #endregion

        #region Czlt-2010-9-16***窗体加载事件****
        private void FrmRealInWell_Load(object sender, EventArgs e)
        {
            listSort = new ListSortDirection();
            isClickSort = false;
        }
        #endregion

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region 【事件方法：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "实时下井人员信息", "统计时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "实时下井人员信息", "统计时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
       
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgvMain, "实时下井人员信息", "统计时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        #endregion

        #region 【方法: 遍历节点下的所有子节点】

        /// <summary>
        /// 遍历节点下的所有子节点
        /// </summary>
        /// <param name="tn"></param>
        private string GetNodeAllChild(TreeNode tn)
        {
            string strNodeChildName;

            strNodeChildName = tn.Name.ToString();
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    string strDid = string.Empty;
                    if (n.Nodes.Count > 0)
                    {
                        strDid = GetNodeAllChild(n);
                    }
                    if (!strDid.Equals(""))
                    {
                        strNodeChildName += "," + n.Name.ToString() + "," + strDid;
 
                    }
                    else
                    {
                        strNodeChildName += "," + n.Name.ToString();
                    }
                }
            }
            return strNodeChildName;
        }
        #endregion


    }
}
