using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.AssociateWithEmp
{
    public partial class FrmHisAssociateInfo : FromModel.FrmModel
    {
        #region 【自定义参数】
        /// <summary>
        /// 查询条件
        /// </summary>
        string m_StrWhere = "";
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
        #endregion

        #region 【构造函数】
        public FrmHisAssociateInfo()
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

        #region 【方法：获取查询条件】
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetScaelSql()
        {
            m_StrWhere = "";
            //员工1的姓名
            if (!txtEmpName1.Text.Trim().Equals(""))
            {
                m_StrWhere = " empName1 like '%" + txtEmpName1.Text + "%' ";
            }
            if (!txtEmpName2.Text.Trim().Equals(""))
            {
                if (!m_StrWhere.Equals(""))
                {
                    m_StrWhere += " and ";
                }
                m_StrWhere += " empName2 like '%" + txtEmpName2.Text + "%' ";
            }
            if (treeViewControlStation.SelectedNode != null)
            {
                if (treeViewControlStation.SelectedNode.Level > 0)
                {
                    if (!m_StrWhere.Equals(""))
                    {
                        m_StrWhere += " and ";
                    }
                    if (treeViewControlStation.SelectedNode.Level == 1)
                    {
                        m_StrWhere += "stationAddress=" + treeViewControlStation.SelectedNode.Name.Substring(1);
                    }
                    else
                    {
                        m_StrWhere += "stationAddress=" + treeViewControlStation.SelectedNode.Parent.Name.Substring(1);
                    }
                }
                if (treeViewControlStation.SelectedNode.Level > 1)
                {
                    if (!m_StrWhere.Equals(""))
                    {
                        m_StrWhere += " and ";
                    }
                    m_StrWhere += " stationHeadAddress=" + treeViewControlStation.SelectedNode.Name.Substring(1);
                }
            }
            if (checkBox1.Checked)
            {
                if (!m_StrWhere.Equals(""))
                {
                    m_StrWhere += " and ";
                }
                m_StrWhere += " (isFlagEmp1='异常' or isFlagEmp2='异常')";
            }
            if (!m_StrWhere.Equals(""))
            {
                m_StrWhere += " and ";
            }
            m_StrWhere += " beginTime>'" + dtpScealBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and beginTime<'" + dtpScealEndData.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        }

        #endregion

        #region 【方法：重置查询条件】
        /// <summary>
        /// 重置查询条件
        /// </summary>
        private void ResetSceal()
        {
            dtpScealBeginDate.Value = DateTime.Now.Date;
            dtpScealEndData.Value = DateTime.Now;
            txtEmpName1.Text = "";
            txtEmpName2.Text = "";
            //checkBox1.Checked = false;
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
                ds = associateBll.GetAssociateInfo(pIndex, m_PSize, m_StrWhere);
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
                if (sumPage == 0)
                {
                    sumPage = 1;
                }
                lblSumPage.Text = "/" + sumPage + "页";
                ds.Tables[0].TableName = "FrmHisAssociateInfo";
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

        #region 【方法：查询条件判断】
        /// <summary>
        /// 查询条件判断
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if (dtpScealBeginDate.Value > dtpScealEndData.Value)
            {
                dtpScealEndData.Value = DateTime.Now;
            }
            if (dtpScealBeginDate.Value.AddDays(7).Date < dtpScealEndData.Value.Date)
            {
                MessageBox.Show("开始时间和结束时间之间天数不能大于7天，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpScealEndData.Value > DateTime.Now)
            {
                MessageBox.Show("结束时间不能大于当前时间，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

        #region 【系统事件方法】
        #region 【事件方法：窗体激活时加载】
        private void FrmHisAssociateInfo_Activated(object sender, EventArgs e)
        {
            LoadStationTree();
            ResetSceal();
            //BindData(1);
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
            BindData(page);
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

        #region 【事件方法：按查询条件查询】
        private void btnSecal_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                GetScaelSql();
                BindData(1);
            }
        }
        #endregion

        #region 【事件方法：重置查询条件】
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetSceal();
                dgvMain.DataSource = new DataTable();

                this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colBeginTime,
                this.colEndTime,
                this.colStation,
                this.colStationHeadID,
                this.colStationHeadPlace,
                this.colEmpName1,
                this.colState1,
                this.colEmpName2,
                this.colState2,
                this.colID});

                colBeginTime.DisplayIndex = 0;
                colEndTime.DisplayIndex = 1;
                colStation.DisplayIndex = 2;
                colStationHeadID.DisplayIndex = 3;
                colStationHeadPlace.DisplayIndex = 4;
                colEmpName1.DisplayIndex = 5;
                colState1.DisplayIndex = 6;
                colEmpName2.DisplayIndex = 7;
                colState2.DisplayIndex = 8;

                lblCounts.Text = "共 0 条信息";
                lblPageCounts.Text = "1";
                lblSumPage.Text = "/" + 1 + "页";
                btnUpPage.Enabled = false;
                btnDownPage.Enabled = false;
            }
            catch
            { }
            //GetScaelSql();
            //BindData(1);
        }
        #endregion

        #region 【事件方法：选择显示是所有信息还是故障信息】
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpScealBeginDate.Value > dtpScealEndData.Value)
            {
                dtpScealBeginDate.Value = DateTime.Now.AddDays(-7);
                dtpScealEndData.Value = DateTime.Now;
            }
            if (dtpScealBeginDate.Value.AddDays(7).Date < dtpScealEndData.Value.Date)
            {
                dtpScealBeginDate.Value = DateTime.Now.AddDays(-7);
                dtpScealEndData.Value = DateTime.Now;
            }
            if (dtpScealEndData.Value > DateTime.Now)
            {
                dtpScealBeginDate.Value = DateTime.Now.AddDays(-7);
                dtpScealEndData.Value = DateTime.Now;
            }
            GetScaelSql();
            BindData(1);
        }
        #endregion

        #region 【事件方法：单击树控件，显示信息】
        private void treeViewControlStation_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewControlStation.SelectedNode = e.Node;
            if (dtpScealBeginDate.Value > dtpScealEndData.Value)
            {
                dtpScealBeginDate.Value = DateTime.Now.AddDays(-7);
                dtpScealEndData.Value = DateTime.Now;
            }
            if (dtpScealBeginDate.Value.AddDays(7).Date < dtpScealEndData.Value.Date)
            {
                dtpScealBeginDate.Value = DateTime.Now.AddDays(-7);
                dtpScealEndData.Value = DateTime.Now;
            }
            if (dtpScealEndData.Value > DateTime.Now)
            {
                dtpScealBeginDate.Value = DateTime.Now.AddDays(-7);
                dtpScealEndData.Value = DateTime.Now;
            }
            GetScaelSql();
            BindData(1);
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
        #region[打印 导出]
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvMain, "历史异地交接班信息");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvMain, "历史异地交接班信息", "");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgvMain, "历史异地交接班信息", lblCounts.Text);
        }
        #endregion
    }
}
