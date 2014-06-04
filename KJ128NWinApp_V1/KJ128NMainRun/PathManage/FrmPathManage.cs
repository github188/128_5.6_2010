using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDataBase;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.PathManage
{
    public partial class FrmPathManage : FromModel.FrmModel
    {
        #region 【自定义参数】
        /// <summary>
        /// 路线逻辑对象
        /// </summary>
        private PathInfoBll pathInfoBll = new PathInfoBll();
        /// <summary>
        /// 人员巡检逻辑对象
        /// </summary>
        private PathEmpRelationBll pathempRelationBll = new PathEmpRelationBll();
        /// <summary>
        /// 选择的菜单类型  0为人员巡检  1为巡检路径
        /// </summary>
        private int selectPanleType = 0;
        /// <summary>
        /// 获取的数据
        /// </summary>
        private DataTable dt = new DataTable();
        /// <summary>
        /// 热备当前刷新次数
        /// </summary>
        private int intRefReshCount = 0;

        /// <summary>
        /// 热备刷新最大次数
        /// </summary>
        private int intHostBackRefCount = 2;
        #endregion

        #region 【构造函数】
        public FrmPathManage()
        {
            InitializeComponent();
            lblMainTitle.Text = "人员巡检";

            //添加抽屉菜单面板并重置
            drawerLeftMain.Add(pnlPathEmp, true);
            drawerLeftMain.Add(pnlPath);
            drawerLeftMain.LeftPartResize();

            //设置选择的抽屉菜单类型
            selectPanleType = 0;
            
            //设置人员巡检左边树菜单
            SetTreeViewPathEmp();
            BindData("");
        }
        #endregion

        #region 【系统事件方法】
        
        #region 【人员巡检菜单展开】
        private void btnPathEmp_Click(object sender, EventArgs e)
        {
            lblMainTitle.Text = "人员巡检";
            selectPanleType = 0;
            if (drawerLeftMain.ButtonClick(pnlPathEmp.Name))
            {
                //设置人员巡检左边树菜单
                SetTreeViewPathEmp();
                BindData("");
            }
        }
        #endregion

        #region 【巡检路线菜单展开】
        private void btnPath_Click(object sender, EventArgs e)
        {
            lblMainTitle.Text = "巡检路线";
            selectPanleType = 1;
            if (drawerLeftMain.ButtonClick(pnlPath.Name))
            {
                //设置巡检路线左边树菜单
                SetTreeViewPath();
                BindData("");
            }
        }
        #endregion

        #region 【事件方法：巡检路径树控件节点单击】
        private void treeViewPath_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewPath.SelectedNode = e.Node;
            int id = 0;
            string strWhere = "";
            switch (e.Node.Level)
            {
                case 1:
                    id = int.Parse(e.Node.Name);
                    strWhere = "pa.id=" + id.ToString() + "";
                    break;
                default:
                    break;
            }
            BindData(strWhere);
        }
        #endregion

        #region 【事件方法：人员巡检树控件节点单击】
        private void treeViwePathEmp_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewPath.SelectedNode = e.Node;
            int id = 0;
            string strWhere = "";
            switch (e.Node.Level)
            {
                case 1:
                    id = int.Parse(e.Node.Name);
                    strWhere = id.ToString();
                    break;
                default:
                    break;
            }
            BindData(strWhere);
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
                    if (dgvMain.Rows[e.RowIndex].Cells[0].Value != null && dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("True"))
                    {
                        dgvMain.Rows[e.RowIndex].Cells[0].Value = "False";
                    }
                    else
                    {
                        dgvMain.Rows[e.RowIndex].Cells[0].Value = "True";
                    }
                }
            }
        }
        #endregion

        #region 【事件方法：删除巡检路径或人员巡检】
        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (selectPanleType)
            {
                case 0://人员巡检
                    DeletePathEmpInfo();
                    break;
                case 1://巡检路径
                    DeletePathInfo();
                    break;
            }
        }
        #endregion

        #region 【事件方法：添加人员巡检信息或添加巡检路径信息】
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSelectAll.Text = "全选";
            switch (selectPanleType)
            {
                case 0://人员巡检
                    FrmEmpPathAdd frmEmpPathAdd = new FrmEmpPathAdd(1, this);
                    frmEmpPathAdd.ShowDialog(this);
                    break;
                case 1://巡检路径
                    FrmPathDetailAdd frmPathDetailAdd = new FrmPathDetailAdd(1, this);
                    frmPathDetailAdd.ShowDialog(this);
                    break;
            }
        }
        #endregion

        #region 【事件方法：修改人员巡检信息或添加巡检路径信息】
        private void btnLaws_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = null;
            DataGridViewRow rTemp = null;
            int i = 0;
            switch (selectPanleType)
            {
                case 0://人员巡检
                    foreach (DataGridViewRow row in dgvMain.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[0].Value.Equals("True"))
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
                        MessageBox.Show("请选择要修改的人员巡检路径配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选人员巡检路径不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (r != null)
                    {
                        FrmEmpPathAdd frmEmpPathAdd = new FrmEmpPathAdd(2, this);
                        frmEmpPathAdd.DgvRow = r;
                        frmEmpPathAdd.ShowDialog(this);
                        btnSelectAll.Text = "全选";
                    }
                    break;
                case 1://巡检路径
                    foreach (DataGridViewRow row in dgvMain.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.Equals("True"))
                        {
                            if (rTemp != null)
                            {
                                if (!row.Cells["pathNo"].Value.Equals(rTemp.Cells["pathNo"].Value))
                                {
                                    i++;
                                    if (i > 1)
                                    {
                                        break;
                                    }
                                }
                                //r = row;
                            }
                            else
                            {
                                i++;
                                r = row;
                            }
                            rTemp = row;
                        }
                    }
                    if (i == 0)
                    {
                        MessageBox.Show("请选择要修改的巡检路径配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选巡检路径不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (r != null)
                    {
                        FrmPathDetailAdd frmPathDetailAdd = new FrmPathDetailAdd(2, this);
                        frmPathDetailAdd.DgvRow = r;
                        frmPathDetailAdd.ShowDialog(this);
                        btnSelectAll.Text = "全选";
                    }
                    break;
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
                switch (selectPanleType)
                {
                    case 0://人员巡检
                        //刷新
                        BindData("");
                        SetTreeViewPathEmp();
                        break;
                    case 1://巡检路径
                        //刷新
                        BindData("");
                        SetTreeViewPath();
                        break;
                }
                #endregion

            }
        }
        #endregion

        #endregion


        #region 【自定义方法】

        #region 【设置人员巡检树控件信息】
        /// <summary>
        /// 设置人员巡检树控件信息
        /// </summary>
        public void SetTreeViewPathEmp()
        {
            treeViwePathEmp.DataSouce = pathInfoBll.getPathInfoTreeViewTable();
            treeViwePathEmp.Nodes.Clear();
            treeViwePathEmp.LoadNode("");
            treeViwePathEmp.ExpandAll();
        }
        #endregion

        #region 【设置巡检路线树控件信息】
        /// <summary>
        /// 设置巡检路线树控件信息
        /// </summary>
        public void SetTreeViewPath()
        {
            treeViewPath.DataSouce = pathInfoBll.getPathInfoTreeViewTable();
            treeViewPath.Nodes.Clear();
            treeViewPath.LoadNode("");
            treeViewPath.ExpandAll();
        }
        #endregion

        #region 【绑定DataGridViwe数据】

        #region 【绑定所有的数据】
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public void BindData(string strWhere)
        {
            btnSelectAll.Text = "全选";
            //DataGridView中的列和行都清空
            if (dgvMain.Rows.Count > 0)
            {
                for (int i = 0; i < dgvMain.Rows.Count; i++)
                {
                    this.dgvMain.Rows.RemoveAt(i);
                }
            }
            this.dgvMain.Columns.Clear();
            
            //选择显示的面板
            switch (selectPanleType)
            {
                case 0:
                    BindPathEmpData();
                    try
                    {
                        dt = pathInfoBll.SelectPathEmpRelation(strWhere);
                    }
                    catch { }
                    break;
                case 1:
                    BindPathData();
                    try
                    {
                        dt = pathInfoBll.SelectPathDetail(strWhere);
                    }
                    catch { }
                    break;
                default:
                    break;
            }
            
            if (dt==null)
            {
                dt = new DataTable();
            }
            dt.TableName = "FrmPathManager1";
            dgvMain.DataSource = dt;

            lblCounts.Text = "共 " + dt.Rows.Count + " 条记录";
        }
        #endregion

        #region 【绑定人员巡检数据】
        /// <summary>
        /// 绑定人员巡检数据
        /// </summary>
        /// <param name="strWhere"></param>
        private void BindPathEmpData()
        {
            #region 【定义显示列对象】
            System.Windows.Forms.DataGridViewCheckBoxColumn Column1 = new DataGridViewCheckBoxColumn();
            Column1.DisplayIndex = 0;
            Column1.Width = 50;
            Column1.TrueValue = "True";
            Column1.FalseValue = "False";
            Column1.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column2 = new DataGridViewTextBoxColumn();
            Column2.Name = "pathno1";
            Column2.DataPropertyName = "pathno1";
            Column2.HeaderText = "路线编号";
            Column2.DisplayIndex = 1;
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column3 = new DataGridViewTextBoxColumn();
            Column3.Name = "pathName1";
            Column3.DataPropertyName = "pathName1";
            Column3.HeaderText = "巡检路线";
            Column3.DisplayIndex = 2;
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column4 = new DataGridViewTextBoxColumn();
            Column4.Name = "empno";
            Column4.DataPropertyName = "empno";
            Column4.HeaderText = "人员编号";
            Column4.DisplayIndex = 3;
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column5 = new DataGridViewTextBoxColumn();
            Column5.Name = "empName";
            Column5.DataPropertyName = "empName";
            Column5.HeaderText = "姓名";
            Column5.DisplayIndex = 4;
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column6 = new DataGridViewTextBoxColumn();
            Column6.Name = "DeptName";
            Column6.DataPropertyName = "DeptName";
            Column6.HeaderText = "部门";
            Column6.DisplayIndex = 5;
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column6.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column7 = new DataGridViewTextBoxColumn();
            Column7.Name = "wtName";
            Column7.DataPropertyName = "wtName";
            Column7.HeaderText = "工种";
            Column7.DisplayIndex = 6;
            Column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column7.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column8 = new DataGridViewTextBoxColumn();
            Column8.Name = "id";
            Column8.DataPropertyName = "id";
            Column8.DisplayIndex = 7;
            Column8.Visible = false;

            System.Windows.Forms.DataGridViewTextBoxColumn Column9 = new DataGridViewTextBoxColumn();
            Column9.Name = "empid";
            Column9.DataPropertyName = "empid";
            Column9.DisplayIndex = 8;
            Column9.Visible = false;

            System.Windows.Forms.DataGridViewTextBoxColumn Column10 = new DataGridViewTextBoxColumn();
            Column10.Name = "deptid";
            Column10.DataPropertyName = "deptid";
            Column10.DisplayIndex = 9;
            Column10.Visible = false;

            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            Column1,Column2,Column3,Column4,Column5,Column6,Column7,Column8,Column9,Column10});

            #endregion
        }
        #endregion

        #region 【绑定巡检路线数据】
        /// <summary>
        /// 绑定巡检路线数据
        /// </summary>
        /// <param name="strWhere"></param>
        private void BindPathData()
        {
            #region 【定义显示列对象】
            System.Windows.Forms.DataGridViewCheckBoxColumn Column1 = new DataGridViewCheckBoxColumn();
            Column1.DisplayIndex = 0;
            Column1.Width = 50;
            Column1.TrueValue = "True";
            Column1.FalseValue = "False";
            Column1.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column2 = new DataGridViewTextBoxColumn();
            Column2.Name = "pathNo";
            Column2.DataPropertyName = "pathNo";
            Column2.HeaderText = "路线编号";
            Column2.DisplayIndex = 1;
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column3 = new DataGridViewTextBoxColumn();
            Column3.Name = "PathName";
            Column3.DataPropertyName = "PathName";
            Column3.HeaderText = "巡检路线";
            Column3.DisplayIndex = 2;
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column4 = new DataGridViewTextBoxColumn();
            Column4.Name = "stationAddress";
            Column4.DataPropertyName = "stationAddress";
            Column4.HeaderText = "传输分站编号";
            Column4.DisplayIndex = 3;
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column5 = new DataGridViewTextBoxColumn();
            Column5.Name = "stationHeadAddress";
            Column5.DataPropertyName = "stationHeadAddress";
            Column5.HeaderText = "读卡分站编号";
            Column5.DisplayIndex = 4;
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column6 = new DataGridViewTextBoxColumn();
            Column6.Name = "StationHeadPlace";
            Column6.DataPropertyName = "StationHeadPlace";
            Column6.HeaderText = "读卡分站安装位置";
            Column6.DisplayIndex = 5;
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column6.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column7 = new DataGridViewTextBoxColumn();
            Column7.Name = "remark";
            Column7.DataPropertyName = "remark";
            Column7.HeaderText = "备注";
            Column7.DisplayIndex = 6;
            Column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column7.Visible = true;

            System.Windows.Forms.DataGridViewTextBoxColumn Column8 = new DataGridViewTextBoxColumn();
            Column8.Name = "pID";
            Column8.DataPropertyName = "pID";
            Column8.DisplayIndex = 7;
            Column8.Visible = false;

            System.Windows.Forms.DataGridViewTextBoxColumn Column9 = new DataGridViewTextBoxColumn();
            Column9.Name = "did";
            Column9.DataPropertyName = "did";
            Column9.DisplayIndex = 8;
            Column9.Visible = false;

            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            Column1,Column2,Column3,Column4,Column5,Column6,Column7,Column8,Column9});
            #endregion
        }
        #endregion

        #endregion

        #region 【删除巡检路径配置】
        /// <summary>
        /// 删除巡检路径配置
        /// </summary>
        private void DeletePathInfo()
        {
            int i = 0;
            ArrayList al = new ArrayList();
            DialogResult result;

            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                if (dgvr.Cells[0].Value != null && dgvr.Cells[0].Value.Equals("True"))
                {
                    i += 1;
                    string[] strID = new string[2];
                    strID[0] = dgvr.Cells["did"].Value.ToString();
                    strID[1] = dgvr.Cells["pathNo"].Value.ToString();
                    al.Add(strID);
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要删除的巡检路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            result = MessageBox.Show("是否要删除选中巡检路径？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnSelectAll.Text = "全选";
                for (int j = 0; j < al.Count; j++)
                {
                    string[] strTemp=(string[])al[j];
                    //操作数据库删除
                    pathInfoBll.DeletePathDetail(int.Parse(strTemp[0]), strTemp[1]);
                    //存入日志
                    LogSave.Messages("[FrmPathManage]", LogIDType.UserLogID, "删除巡检路径信息，编号为：" + strTemp[0]);
                }

                dgvMain.ClearSelection();

                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    //刷新
                    BindData("");
                    SetTreeViewPath();
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }
                
            }
        }
        #endregion

        #region 【删除人员巡检配置】
        /// <summary>
        /// 删除巡检路径配置
        /// </summary>
        private void DeletePathEmpInfo()
        {
            int i = 0;
            ArrayList al = new ArrayList();
            DialogResult result;

            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                if (dgvr.Cells[0].Value != null && dgvr.Cells[0].Value.Equals("True"))
                {
                    i += 1;
                    int id = int.Parse(dgvr.Cells["id"].Value.ToString());
                    al.Add(id);
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要删除的人员巡检路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            result = MessageBox.Show("是否要删除选中人员巡检路径？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnSelectAll.Text = "全选";
                for (int j = 0; j < al.Count; j++)
                {
                    int iTemp = (int)al[j];
                    //操作数据库删除
                    pathempRelationBll.DeletePathEmpRelation(iTemp);
                    //存入日志
                    LogSave.Messages("[FrmPathManage]", LogIDType.UserLogID, "删除人员巡检路径信息，编号为：" + iTemp.ToString());
                }

                dgvMain.ClearSelection();
                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    //刷新
                    BindData("");
                    SetTreeViewPathEmp();
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }
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
            this.AcceptButton = IB;
        }
        #region 【方法：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvMain, PrintTableName());
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, PrintTableName(), "");
        }

        private string PrintTableName()
        {
            switch (selectPanleType)
            {
                case 0://人员巡检
                    return "人员巡检";
                case 1://巡检路径
                    return "巡检路线";
                default: return "人员巡检";
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            switch (selectPanleType)
            {
                case 0://人员巡检
                    KJ128NDBTable.PrintBLL.Print(dgvMain, PrintTableName(), lblCounts.Text);
                    break;
                case 1://巡检路径
                    KJ128NDBTable.PrintBLL.Print(dgvMain, PrintTableName(), lblCounts.Text);
                    break;
            }
        }
        #endregion

        private void FrmPathManage_Load(object sender, EventArgs e)
        {

        }
    }
}
