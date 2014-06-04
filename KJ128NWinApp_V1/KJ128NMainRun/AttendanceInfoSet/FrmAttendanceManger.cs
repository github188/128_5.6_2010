using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.AttendanceInfoSet
{
    public partial class FrmAttendanceManger : FromModel.FrmModel
    {
        #region 【自定义参数】
        /// <summary>
        /// 班制逻辑对象
        /// </summary>
        private InfoClassBLL classInfoBll = new InfoClassBLL();
        /// <summary>
        /// 班次逻辑对象
        /// </summary>
        private TimerIntervalBLL timerIntervalBll = new TimerIntervalBLL();
        /// <summary>
        /// 班制表
        /// </summary>
        private DataTable dtClass = new DataTable();
        /// <summary>
        /// 班次显示表
        /// </summary>
        private DataTable dtTimeInterval = new DataTable();
        /// <summary>
        /// 班制编辑状态  0为不编辑  1为添加  2为修改
        /// </summary>
        private int editState = 0;

        private int stype = 0;
        /// <summary>
        /// 热备当前刷新次数
        /// </summary>
        private int intRefReshCount = 0;

        /// <summary>
        /// 热备刷新最大次数
        /// </summary>
        private int intHostBackRefCount = 2;
        #endregion 【自定义参数】

        #region 【初始化面板】
        public FrmAttendanceManger()
        {
            InitializeComponent();
            //添加面板到抽屉菜单控件中
            drawerLeftMain.Add(panelClass, true);
            //drawerLeftMain.Add(panelClassType);
            drawerLeftMain.LeftPartResize();
            //为DataGridView绑定数据并显示格式
            Bind("");
            //显示树菜单信息
            SetTimeIntervalTreeView();
        }
        #endregion 【初始化面板】

        #region 【系统事件实现方法】

        #region 【事件方法：添加班制信息】
        private void tsmAdd_Click(object sender, EventArgs e)
        {
            stype = 0;
            TreeNode node;
            node = treeViewControlClass.Nodes[0].Nodes.Add("");
            treeViewControlClass.LabelEdit = true;
            node.BeginEdit();
            editState = 1;
        }
        #endregion 【事件方法：添加班制信息】

        #region 【事件方法：修改班制信息】
        private void tsmUpdate_Click(object sender, EventArgs e)
        {
            stype = 0;
            TreeNode node = null;
            node = treeViewControlClass.SelectedNode;
            if (node != null && node.Level == 1)
            {
                if (node.Text == "三班")
                {
                    MessageBox.Show("该班次为系统自带班次,无法修改", "提示", MessageBoxButtons.OK);
                    return;
                }
                treeViewControlClass.LabelEdit = true;
                node.BeginEdit();
                editState = 2;
            }
        }
        #endregion

        #region 【事件方法：删除班制信息】
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            stype = 0;
            TreeNode node = null;
            string strError = "";
            node = treeViewControlClass.SelectedNode;
            if (node != null && node.Level==1)
            {
                if (node.Text == "三班")
                {
                    MessageBox.Show("该班次为系统自带班次,无法删除", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (node.Name.Equals("0"))
                {
                    return;
                }
                int id = 0;
                try
                {
                    id = int.Parse(node.Name.Substring(1));
                }
                catch
                {
                    return;
                }
                classInfoBll.InfoClass_Delete(id, out strError);
                if (strError.Equals("Succeeds"))
                {
                    treeViewControlClass.Nodes.Remove(node);
                }
                dgvMain.ClearSelection();
                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    //刷新
                    Bind("");
                    SetTimeIntervalTreeView();
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }
            }
        }
        #endregion

        #region 【事件方法：节点编辑完成后】
        private void treeViewControlClass_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string strError = "";
            if (e.Node !=null && e.Label!=null && !e.Label.Trim().Equals(""))
            {
                
                switch (editState)
                {
                    case 1://添加
                        if (e.Label.Trim().Contains("'"))
                        {
                            MessageBox.Show("输入班制信息时，输入了特殊符号，请重新输入", "提示", MessageBoxButtons.OK);
                            e.CancelEdit = true;
                            treeViewControlClass.LabelEdit = false;
                            editState = 0;
                            treeViewControlClass.Nodes.Remove(e.Node);
                            return;
                        }
                        int classinfoCount = classInfoBll.InfoClass_Insert(e.Label, e.Label, "", out strError);
                        if (!strError.Equals("Succeeds") || classinfoCount<=0)//添加失败
                        {
                            treeViewControlClass.Nodes.Remove(e.Node);
                            break;
                        }
                        //e.CancelEdit = true;
                        //SetTimeIntervalTreeView();
                        break;
                    case 2://修改
                        if (e.Label.Trim().Contains("'"))
                        {
                            MessageBox.Show("输入班制信息时，输入了特殊符号，请重新输入", "提示", MessageBoxButtons.OK);
                            e.CancelEdit = true;
                            treeViewControlClass.LabelEdit = false;
                            editState = 0;
                            return;
                        }
                        TreeNode node = e.Node;
                        int id = 0;
                        try
                        {
                            id = int.Parse(node.Name.Substring(1));
                        }
                        catch
                        {
                            e.CancelEdit = true;
                            treeViewControlClass.LabelEdit = false;
                            editState = 0;
                            return;
                        }
                        int classInfoUpdateCount = classInfoBll.InfoClass_Update(id, e.Label, e.Label, "", out strError);
                        if (!strError.Equals("Succeeds") || classInfoUpdateCount<=0)
                        {
                            e.CancelEdit = true;
                            treeViewControlClass.LabelEdit = false;
                            editState = 0;
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }

            e.CancelEdit = true;
            treeViewControlClass.LabelEdit = false;
            editState = 0;
            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
            {
                //刷新
                SetTimeIntervalTreeView();
            }
            else                                //热备版，启用定时器
            {
                HostBackRefresh(true);
            }
        }
        #endregion 【事件方法：节点编辑完成后】

        #region 【事件方法：鼠标单击节点】
        private void treeViewControlClass_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewControlClass.SelectedNode = e.Node;
            int id = 0;
            string strWhere = "";
            if (e.Node.Level > 0)
            {
                try
                {
                    id = int.Parse(e.Node.Name.Substring(1));
                }
                catch
                {
                    return;
                }
                switch (e.Node.Level)
                {
                    case 1:
                        strWhere = "classid=" + id;
                        break;
                    case 2:
                        strWhere = "t.id=" + id;
                        break;
                    default:
                        break;
                }
            }
            Bind(strWhere);
        }
        #endregion

        #region 【事件方法：添加班次信息】
        private void btnAdd_Click(object sender, EventArgs e)
        {
            stype = 1;
            FrmArrendanceAdd frmArrendanceAdd = new FrmArrendanceAdd(1, this);
            frmArrendanceAdd.ShowDialog(this);
        }
        #endregion

        #region 【事件方法：修改班次信息】
        private void btnLaws_Click(object sender, EventArgs e)
        {
            stype = 1;
            DataGridViewRow r = null;
            int i = 0;
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.Equals("True"))
                    {
                        i++;
                        if (i>1)
                        {
                            break;
                        }
                        r = row;
                    }
                }
            }

            if (i==0)
            {
                MessageBox.Show("请选择要修改的班次配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (i > 1)
            {
                MessageBox.Show("所选班次不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (r!=null)
            {
                FrmArrendanceAdd frmArrendanceAdd = new FrmArrendanceAdd(2, this);
                frmArrendanceAdd.DgvRow = r;
                frmArrendanceAdd.ShowDialog(this);
            }
        }
        #endregion

        #region 【事件方法：双击单元格 查看班次信息】
        private void dgvMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                FrmArrendanceAdd frmArrendanceAdd = new FrmArrendanceAdd(3, this);
                frmArrendanceAdd.DgvRow = dgvMain.Rows[e.RowIndex];
                frmArrendanceAdd.ShowDialog(this);
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

        #region 【事件方法：删除班次信息】
        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnSelectAll.Text = "全选";
            stype = 1;
            int i = 0;
            string strError = "";
            ArrayList al = new ArrayList();
            DialogResult result;

            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                if (dgvr.Cells[0].Value != null && dgvr.Cells[0].Value.Equals("True"))
                {
                    i += 1;
                    al.Add(dgvr.Cells["ID"].Value.ToString());
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要删除的班次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            result = MessageBox.Show("是否要删除选中班次？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                for (int j = al.Count-1; j >=0 ; j--)
                {
                    //操作数据库删除
                    timerIntervalBll.TimerInterval_Delete(int.Parse(al[j].ToString()), out strError);
                    if (strError.Equals("Succeeds"))
                    {
                        //存入日志
                        LogSave.Messages("[FrmAttendanceManger]", LogIDType.UserLogID, "删除班次信息，编号为：" + al[j].ToString());
                    }
                }
                
                dgvMain.ClearSelection();
                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    //刷新
                    Bind("");
                    SetTimeIntervalTreeView();
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }
            }
        }
        #endregion

        #region 【事件方法：热备刷新】
        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            if (intRefReshCount >= intHostBackRefCount)
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
            else
            {
                intRefReshCount = intRefReshCount + 1;

                #region【刷新界面】
                if (stype == 1)
                {
                    //刷新
                    Bind("");
                }
                SetTimeIntervalTreeView();

                #endregion

            }
        }
        #endregion

        #endregion 【系统事件实现方法】

        #region 【自定义方法】

        #region 【方法：绑定数据和网格控件显示格式】
        /// <summary>
        /// 网格控件绑定数据格式
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public void Bind(string strWhere)
        {
            btnSelectAll.Text = "全选";
            //获取班次表数据
            dtTimeInterval = timerIntervalBll.getTimeInterval(strWhere);

            #region 【定义显示列对象】
            System.Windows.Forms.DataGridViewCheckBoxColumn Column1 = new DataGridViewCheckBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Column2 = new DataGridViewTextBoxColumn();
            Column2.Name = "ClassName";
            System.Windows.Forms.DataGridViewTextBoxColumn Column3 = new DataGridViewTextBoxColumn();
            Column3.Name = "ID";
            System.Windows.Forms.DataGridViewTextBoxColumn Column4 = new DataGridViewTextBoxColumn();
            Column4.Name = "IntervalName";
            System.Windows.Forms.DataGridViewTextBoxColumn Column5 = new DataGridViewTextBoxColumn();
            Column5.Name = "NameShort";
            System.Windows.Forms.DataGridViewTextBoxColumn Column6 = new DataGridViewTextBoxColumn();
            Column6.Name = "DataAttendanceTypeName";
            System.Windows.Forms.DataGridViewTextBoxColumn Column7 = new DataGridViewTextBoxColumn();
            Column7.Name = "StartWorkTimeName";
            System.Windows.Forms.DataGridViewTextBoxColumn Column8 = new DataGridViewTextBoxColumn();
            Column8.Name = "EndWorkTimeName";
            System.Windows.Forms.DataGridViewTextBoxColumn Column9 = new DataGridViewTextBoxColumn();
            Column9.Name = "SWFrontTime";
            System.Windows.Forms.DataGridViewTextBoxColumn Column10 = new DataGridViewTextBoxColumn();
            Column10.Name = "SwDateType";
            System.Windows.Forms.DataGridViewTextBoxColumn Column11 = new DataGridViewTextBoxColumn();
            Column11.Name = "StartWorkTime";
            System.Windows.Forms.DataGridViewTextBoxColumn Column12 = new DataGridViewTextBoxColumn();
            Column12.Name = "EndWorkTime";
            System.Windows.Forms.DataGridViewTextBoxColumn Column13 = new DataGridViewTextBoxColumn();
            Column13.Name = "EWDateType";
            System.Windows.Forms.DataGridViewTextBoxColumn Column14 = new DataGridViewTextBoxColumn();
            Column14.Name = "SWAfterTime";
            System.Windows.Forms.DataGridViewTextBoxColumn Column15 = new DataGridViewTextBoxColumn();
            Column15.Name = "EWFrontTime";
            System.Windows.Forms.DataGridViewTextBoxColumn Column16 = new DataGridViewTextBoxColumn();
            Column16.Name = "EWAfterTime";
            System.Windows.Forms.DataGridViewTextBoxColumn Column17 = new DataGridViewTextBoxColumn();
            Column17.Name = "ClassID";
            System.Windows.Forms.DataGridViewTextBoxColumn Column18 = new DataGridViewTextBoxColumn();
            Column18.Name = "DataAttendanceType";
            #endregion

            //网格控件显示列和行都清空
            this.dgvMain.Columns.Clear();

            lblMainTitle.Text = "班次配置";

            #region 【班次数据显示格式】
            Column1.DisplayIndex = 0;
            Column1.Width = 50;
            Column1.TrueValue = "True";
            Column1.FalseValue = "False";
            Column1.Visible = true;

            Column2.DataPropertyName = "ClassName";
            Column2.HeaderText = "班制全称";
            Column2.DisplayIndex = 1;
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.Visible = true;

            Column3.DataPropertyName = "ID";
            Column3.DisplayIndex = 7;
            Column3.Visible = false;

            Column4.DataPropertyName = "IntervalName";
            Column4.HeaderText = "时段全称";
            Column4.DisplayIndex = 2;
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.Visible = true;

            Column5.DataPropertyName = "NameShort";
            Column5.HeaderText = "时段简称";
            Column5.DisplayIndex = 3;
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column5.Visible = true;

            Column6.DataPropertyName = "DataAttendanceTypeName";
            Column6.HeaderText = "记工日期";
            Column6.DisplayIndex = 4;
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column6.Visible = true;

            Column7.DataPropertyName = "StartWorkTimeName";
            Column7.HeaderText = "开始时间";
            Column7.DisplayIndex = 5;
            Column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column7.Visible = true;

            Column8.DataPropertyName = "EndWorkTimeName";
            Column8.HeaderText = "结束时间";
            Column8.DisplayIndex = 6;
            Column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column8.Visible = true;

            Column9.DataPropertyName = "SWFrontTime";
            Column9.DisplayIndex = 8;
            Column9.Visible = false;

            Column10.DataPropertyName = "SwDateType";
            Column10.DisplayIndex = 9;
            Column10.Visible = false;

            Column11.DataPropertyName = "StartWorkTime";
            Column9.DisplayIndex = 10;
            Column11.Visible = false;

            Column12.DataPropertyName = "EndWorkTime";
            Column12.DisplayIndex = 11;
            Column12.Visible = false;

            Column13.DataPropertyName = "EWDateType";
            Column13.DisplayIndex = 12;
            Column13.Visible = false;

            Column14.DataPropertyName = "SWAfterTime";
            Column14.DisplayIndex = 13;
            Column14.Visible = false;

            Column15.DataPropertyName = "EWFrontTime";
            Column15.DisplayIndex = 14;
            Column15.Visible = false;

            Column16.DataPropertyName = "EWAfterTime";
            Column16.DisplayIndex = 15;
            Column16.Visible = false;

            Column17.DataPropertyName = "ClassID";
            Column17.DisplayIndex = 16;
            Column17.Visible = false;

            Column18.DataPropertyName = "DataAttendanceType";
            Column18.DisplayIndex = 17;
            Column18.Visible = false;

            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            Column1,Column2,Column4,Column5,Column6,Column7,Column8,Column3,Column9,Column10,Column11,Column12,Column13,Column14,Column15,Column16,Column17,Column18});
            #endregion
            dtTimeInterval.TableName = "FrmAttendanceManage_Config";
            dgvMain.DataSource = dtTimeInterval;

            lblCounts.Text = "共 " + dtTimeInterval.Rows.Count + " 条记录";
            
        }
        #endregion 【方法：绑定数据和网格控件显示格式】

        #region 【方法：获取班次 树信息】
        /// <summary>
        /// 设置班次的树控件信息
        /// </summary>
        public void SetTimeIntervalTreeView()
        {
            treeViewControlClass.DataSouce = timerIntervalBll.TimeIntervalTree();
            treeViewControlClass.Nodes.Clear();
            treeViewControlClass.LoadNode("");
            treeViewControlClass.ExpandAll();
        }
        #endregion 【方法：获取班次 树信息】

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

      

        #endregion 【自定义方法】

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dgvMain.Columns.Count > 0)
                {
                    for (int i = 0; i < dgvMain.Columns.Count; i++)
                    {
                        dgvMain.Columns[i].DefaultCellStyle.NullValue = "——";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void FrmAttendanceManger_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("Class.xml");
        }


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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "考勤配置");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "考勤配置", "");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgvMain, "考勤配置", lblCounts.Text);
        }

    }
}
