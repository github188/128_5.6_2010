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

namespace KJ128NMainRun.AssociateWithEmp
{
    public partial class FrmAssociateManage : FromModel.FrmModel
    {
        #region 【自定义参数】
        /// <summary>
        /// 异地交接班逻辑对象
        /// </summary>
        private AssociateBLL associateBll = new AssociateBLL();
        /// <summary>
        /// 页显示行数
        /// </summary>
        private int m_PSize = 40;
        /// <summary>
        /// 页个数
        /// </summary>
        private int m_PCounts = 0;
        /// <summary>
        /// 查询条件
        /// </summary>
        private string m_StrWhere = "";

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
        public FrmAssociateManage()
        {
            InitializeComponent();
            cmbSelectCounts.Text = m_PSize.ToString();
        }
        #endregion

        #region 【自定义方法】
        #region 【方法：绑定分站树信息】
        /// <summary>
        /// 绑定分站树信息
        /// </summary>
        private void LoadStationTree()
        {
            DataTable dt = associateBll.GetStationTree();
            treeViewControlStation.DataSouce = dt;
            treeViewControlStation.LoadNode("");

            treeViewControlStation.ExpandAll();
        }
        #endregion

        #region 【方法：重置查询条件】
        /// <summary>
        /// 重置查询条件
        /// </summary>
        private void ResetSceal()
        {
            dtpScealBeginDate.Value = DateTime.Now;
            dtpScealEndData.Value = DateTime.Now.AddDays(7);
            txtEmpName1.Text = "";
            txtEmpName2.Text = "";
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
            //员工1的姓名
            if (!txtEmpName1.Text.Trim().Equals(""))
            {
                strWhereSql = " empName1 like '%" + txtEmpName1.Text + "%' ";
            }
            if (!txtEmpName2.Text.Trim().Equals(""))
            {
                if (!strWhereSql.Equals(""))
                {
                    strWhereSql += " and ";
                }
                m_StrWhere += " empName2 like '%" + txtEmpName2.Text + "%' ";
            }
            if (treeViewControlStation.SelectedNode != null)
            {
                if (treeViewControlStation.SelectedNode.Level > 0)
                {
                    if (!strWhereSql.Equals(""))
                    {
                        strWhereSql += " and ";
                    }
                    if (treeViewControlStation.SelectedNode.Level == 1)
                    {
                        strWhereSql += "stationAddress=" + treeViewControlStation.SelectedNode.Name.Substring(1);
                    }
                    else
                    {
                        strWhereSql += "stationAddress=" + treeViewControlStation.SelectedNode.Parent.Name.Substring(1);
                    }
                }
                if (treeViewControlStation.SelectedNode.Level > 1)
                {
                    if (!strWhereSql.Equals(""))
                    {
                        strWhereSql += " and ";
                    }
                    strWhereSql += " stationHeadAddress=" + treeViewControlStation.SelectedNode.Name.Substring(1);
                }
            }
            if (!strWhereSql.Equals(""))
            {
                strWhereSql += " and ";
            }
            strWhereSql += " beginTime>'" + dtpScealBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and beginTime<'" + dtpScealEndData.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            m_StrWhere = strWhereSql;
        }
        #endregion

        #region 【方法：绑定数据】
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="pIndex"></param>
        public void BindData(int pIndex)
        {
            if (pIndex < 1)
            {
                pIndex = 1;
                return;
            }

            if (pIndex == 1)
            {
                btnUpPage.Enabled = false;
            }

            DataSet ds = null;
            try
            {
                ds = associateBll.getAssociateConfig(pIndex, m_PSize, m_StrWhere);
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
                    if (pIndex > sumPage)
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
                    pIndex = 1;
                }

                lblCounts.Text = "共 " + ds.Tables[1].Rows[0][0].ToString() + " 条信息";
                lblPageCounts.Text = pIndex.ToString();
                if (sumPage==0)
                {
                    sumPage = 1;
                }
                lblSumPage.Text = "/" + sumPage + "页";
                ds.Tables[0].TableName = "FrmAssociateManage_1";
                dgvMain.DataSource = ds.Tables[0];
            }
            else
            {
                lblCounts.Text = "共 0 条信息";
                btnDownPage.Enabled = false;
                btnUpPage.Enabled = false;
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + 1 + "页";
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
        #region 【事件方法：窗体激活时发生】
        private void FrmAssociateManage_Activated(object sender, EventArgs e)
        {
            LoadStationTree();
            ResetSceal();
            BindData(1);
        }
        #endregion

        #region 【事件方法：重置查询条件】
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetSceal();
                GetSecalString();
                //BindData(1);
                dgvMain.DataSource = new DataTable();
                this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.beginTime,
                this.endTime,
                this.stationAddress,
                this.stationHeadAddress,
                this.stationHeadPlace,
                this.empName1,
                this.empName2,
                this.id});

                this.colSelect.DisplayIndex = 0;
                this.beginTime.DisplayIndex = 1;
                this.endTime.DisplayIndex = 2;
                this.stationAddress.DisplayIndex = 3;
                this.stationHeadAddress.DisplayIndex = 4;
                this.stationHeadPlace.DisplayIndex = 5;
                this.empName1.DisplayIndex = 6;
                this.empName2.DisplayIndex = 7;
                

                lblCounts.Text = "共 0 条信息";
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + 1 + "页";
                btnUpPage.Enabled = false;
                btnDownPage.Enabled = false;
            }
            catch
            { }
        }
        #endregion

        #region 【事件方法：显示上一页】
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

        #region 【事件方法：显示下一页】
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

        #region 【事件方法：跳转页数】
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
            if (m_PSize != int.Parse(cmbSelectCounts.SelectedItem.ToString()))
            {
                m_PSize = int.Parse(cmbSelectCounts.SelectedItem.ToString());
                BindData(1);
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

        #region 【事件方法：弹出新增异地交接班界面】
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAssociateAdd frmAssociateAdd = new FrmAssociateAdd(this);
            frmAssociateAdd.ShowDialog(this);
        }
        #endregion

        #region 【事件方法：删除异地交接班信息】
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            ArrayList al = new ArrayList();
            DialogResult result;

            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                if (dgvr.Cells[0].Value != null && dgvr.Cells[0].Value.Equals("True"))
                {
                    i += 1;
                    int ID = int.Parse(dgvr.Cells["colid"].Value.ToString());
                    al.Add(ID);
                }
            }

            if (i == 0)
            {
                MessageBox.Show("请选择要删除的异地交接班信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            result = MessageBox.Show("是否要删除选中异地交接班信息？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnSelectAll.Text = "全选";
                for (int j = 0; j < al.Count; j++)
                {
                    int temp = (int)al[j];
                    //操作数据库删除
                    associateBll.DeleteAssociate(temp);
                    //存入日志
                    LogSave.Messages("[FrmPathManage]", LogIDType.UserLogID, "删除异地交接班信息信息，编号为：" + temp.ToString());
                }

                dgvMain.ClearSelection();

                if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                {
                    //刷新
                    BindData(1);
                }
                else                                //热备版，启用定时器
                {
                    HostBackRefresh(true);
                }

            }
        }
        #endregion

       

        #region 【事件方法：查询配置信息】
        private void btnSecal_Click(object sender, EventArgs e)
        {
            GetSecalString();
            BindData(1);
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
                //刷新
                BindData(1);
                #endregion

            }
        }
        #endregion

        #region 【事件方法：树单击是查询】
        private void treeViewControlStation_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewControlStation.SelectedNode = e.Node;
            GetSecalString();
            BindData(1);
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

        private void FrmAssociateManage_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnSecal;
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

        private void txtEmpName1_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtEmpName2_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region 【事件方法：打印信息】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "异地交接班信息");
        
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "异地交接班信息", "");
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgvMain, "异地交接班信息", "共" + dgvMain.Rows.Count.ToString() + "条记录");
        }
        #endregion
    }
}
