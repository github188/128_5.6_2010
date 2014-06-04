using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.FromModel;
using KJ128NDBTable;

namespace KJ128NMainRun.SetCoder
{
    public partial class A_frmCodeSender : FrmModel
    {
        private A_CodeSenderBLL codebll = new A_CodeSenderBLL();

        private List<EmpMacCodeSender> list = new List<EmpMacCodeSender>();

        private List<string> ExitsEmpIdlist = new List<string>();

        private int pagecount = 0;

        private bool isCodeSenderSet = true;
        private string strCodeSender = "";
        private string strDept = "所有";
        private int num = 0;
        private string type = "";
        private int m_RowCount = 40;
        private string strCode = "";

        /// <summary>
        /// 热备当前刷新次数
        /// </summary>
        private int intRefReshCount = 0;

        /// <summary>
        /// 热备刷新最大次数
        /// </summary>
        private int intHostBackRefCount = 2;

        #region 【构造函数】
        public A_frmCodeSender()
        {
            InitializeComponent();
            //cmbSelectCounts.SelectedIndex = 0;
            //LoadTrvDept();
            //drawerMainControl1.Add();
            //drawerMainControl1.LeftPartResize()
            drawerLeftMain.Add(pnl1, true);
            drawerLeftMain.Add(pnl2);
            drawerLeftMain.LeftPartResize();
        }
        #endregion

        #region 【事件方法：窗体加载】
        private void A_frmCodeSender_Load(object sender, EventArgs e)
        {
            this.cmbSelectCounts.Items.Add("全部");
            cmbSelectCounts.Text = "40";
            //cmbSelectCounts.SelectedIndex = 0;
            //LoadTrvDept();
            //trvDept.Nodes[0].Expand();
            //trvCodesender.Nodes[0].Expand();
            //trvDept.SelectedNode = trvDept.Nodes[0];
            //if (rdbEmp.Checked)
            //    type = rdbEmp.Text;
            //else
            //    type = rdbMch.Text;
            this.AcceptButton = btnSearch;
            btnLaws.Enabled = false;
        }
        #endregion

        #region 【自定义方法】
        #region 【方法：加载部门树控件】
        private void LoadTrvDept()
        {
            trvDept.Nodes.Clear();
            DataTable depttable = codebll.GetDeptInfo();
            trvDept.Nodes.Add("0", "所有");
            AddTreeNode(depttable, trvDept.Nodes[0]);
            //trvPdept.Nodes.Add("0", "所有");
            //AddTreeNode(depttable, trvPdept.Nodes[0]);
        }
        #endregion

        #region 【方法：添加节点】
        private void AddTreeNode(DataTable dt, TreeNode node)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["parentdeptid"].ToString() == node.Name)
                {
                    TreeNode childnode = new TreeNode(dt.Rows[i]["deptname"].ToString());
                    childnode.Name = dt.Rows[i]["deptid"].ToString();
                    node.Nodes.Add(childnode);
                    AddTreeNode(dt, childnode);
                }
            }
        }
        #endregion

        #region 【方法：加载标示卡人员数据】
        private delegate void SetBindDataCodeSetCallBack(int index);
        public void BindCodeSet(int index)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetBindDataCodeSetCallBack d = new SetBindDataCodeSetCallBack(BindCodeSet);
                    Invoke(d, new object[] { index });
                }
                else
                {
                    btnSelectAll.Text = "全选";
                    if (index == 1)
                    {
                        btnUpPage.Enabled = false;
                    }

                    DataSet ds = codebll.GetCodeSenderSet(strDept, type, strCodeSender, m_RowCount, index);
                    int width = 0;
                    if (ds.Tables != null && ds.Tables.Count > 0)
                    {
                        ds.Tables[0].TableName = "A_FrmCodeSender1";
                        // 重新设置页数
                        int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                        sumPage = sumPage % m_RowCount != 0 ? sumPage / m_RowCount + 1 : sumPage / m_RowCount;
                        pagecount = sumPage;//获取总页数
                        if (index > sumPage)
                        {
                            if (sumPage == 0)
                            {
                                lblCounts.Text = "符合筛选条件：共 0 条信息";
                                lblPageCounts.Text = "1";
                                lblSumPage.Text = "/" + 1 + "页";
                                btnUpPage.Enabled = false;
                                btnDownPage.Enabled = false;
                                dgvCodeSenderSet.DataSource = ds.Tables[0];
                                
                                //try
                                //{
                                //    width = (dgvCodeSenderSet.Width - 50 - 2) / (dgvCodeSenderSet.Columns.Count - 1);
                                //}
                                //catch (Exception ex)
                                //{ }
                                for (int i = 1; i < dgvCodeSenderSet.Columns.Count; i++)
                                {
                                    dgvCodeSenderSet.Columns[i].ReadOnly = true;
                                    //dgvCodeSenderSet.Columns[i].Width = width;
                                }
                                return;
                            }
                            index = sumPage;
                        }

                        btnUpPage.Enabled = true;
                        btnDownPage.Enabled = true;
                        if (index == 1)
                        {
                            btnUpPage.Enabled = false;
                        }
                        if (index == sumPage)
                        {
                            btnDownPage.Enabled = false;
                        }

                        lblCounts.Text = "符合筛选条件：共 " + ds.Tables[1].Rows[0][0].ToString() + " 条信息";

                        lblPageCounts.Text = index.ToString();
                        lblSumPage.Text = "/" + sumPage + "页";
                        dgvCodeSenderSet.DataSource = ds.Tables[0];
                        try
                        {
                            width = (dgvCodeSenderSet.Width - 50 - 2) / (dgvCodeSenderSet.Columns.Count - 1);
                        }
                        catch (Exception ex)
                        { }
                        for (int i = 1; i < dgvCodeSenderSet.Columns.Count; i++)
                        {
                            dgvCodeSenderSet.Columns[i].ReadOnly = true;
                            dgvCodeSenderSet.Columns[i].Width = width;
                        }
                    }
                    else
                    {
                        lblCounts.Text = "符合筛选条件：共 0 条信息";
                        btnUpPage.Enabled = false;
                        btnDownPage.Enabled = false;
                        lblPageCounts.Text = "1";
                        lblSumPage.Text = "/" + 1 + "页";
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 【方法：加载标识卡数据】
        private delegate void SetBindDataCallBack(int index);
        public void BindCode(int index)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetBindDataCallBack d = new SetBindDataCallBack(BindCode);
                    Invoke(d, new object[] { index });
                }
                else
                {
                    btnSelectAll.Text = "全选";
                    btnUpPage.Enabled = true;
                    btnDownPage.Enabled = true;
                    int rowcount = 0;
                    DataTable codesenderdt = codebll.GetCodeSenderByUse(num, strCode, m_RowCount, index, out pagecount, out rowcount);
                    codesenderdt.TableName = "A_FrmCodeSender2";
                    dgvCodeSenderSet.DataSource = codesenderdt;
                    //int width = 0;
                    //try
                    //{
                    //    width = (dgvCodeSenderSet.Width - 50 - 2) / (dgvCodeSenderSet.Columns.Count - 1);
                    //}
                    //catch (Exception ex)
                    //{ }
                    for (int i = 1; i < dgvCodeSenderSet.Columns.Count; i++)
                    {
                        dgvCodeSenderSet.Columns[i].ReadOnly = true;
                        //dgvCodeSenderSet.Columns[i].Width = width;
                    }
                    lblPageCounts.Text = index.ToString();
                    lblSumPage.Text = "/" + pagecount.ToString() + "页";
                    txtSkipPage.Text = index.ToString();
                    lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
                }
            }
            catch { }
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

        #region 【事件方法：部门树选择后筛选】
        private void trvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e!=null && e.Node != null)
            {
                if (!e.Node.Text.Trim().Equals("所有"))
                {
                    trvDept.SelectedNode = e.Node;
                    //strDept = trvDept.SelectedNode.Text;

                    string strDid = GetNodeAllChild(trvDept.SelectedNode);
                    strDept = "  ( '" + strDid + "' )";
                }
                else
                {
                    strDept = "所有";
 
                }
            }
            else
            {
                trvDept.SelectedNode = null;
                strDept = "所有";
            }
            strCodeSender = txtCodeSender.Text;
            BindCodeSet(1);
            //DataTable codesenderdt = codebll.GetCodeSenderSet(strDept, type, strCodeSender, m_RowCount, num, out pagecount, out rowcount);
            //dgvCodeSenderSet.DataSource = codesenderdt;
            //int width = 0;
            //try
            //{
            //    width = (dgvCodeSenderSet.Width - 50 - 2) / (dgvCodeSenderSet.Columns.Count - 1);
            //}
            //catch (Exception ex)
            //{ }
            //for (int i = 1; i < dgvCodeSenderSet.Columns.Count; i++)
            //{
            //    dgvCodeSenderSet.Columns[i].ReadOnly = true;
            //    dgvCodeSenderSet.Columns[i].Width = width;
            //}
            //lblPageCounts.Text = num.ToString();
            //lblSumPage.Text = "/" + pagecount.ToString() + "页";
            //txtSkipPage.Text = num.ToString();
            //lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
        }
        #endregion

        #region 【事件方法：标识卡树选择后数据筛选】
        private void trvCodesender_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e!=null && e.Node !=null)
            {
                trvCodesender.SelectedNode = e.Node;
                if (trvCodesender.SelectedNode.Text == "所有")
                {
                    num = 0;
                }
                if (trvCodesender.SelectedNode.Text == "配置")
                {
                    num = 1;
                }
                if (trvCodesender.SelectedNode.Text == "未配置")
                {
                    num = 2;
                }
            }
            else
            {
                trvCodesender.SelectedNode = null;
                num = 0;
            }
            
            strCode = txtCode.Text;

            BindCode(1);

            //int rowcount = 0;
            //DataTable codesenderdt = codebll.GetCodeSenderByUse(num,strCode, m_RowCount, 1, out pagecount, out rowcount);
            //dgvCodeSenderSet.DataSource = codesenderdt;
            //int width = 0;
            //try
            //{
            //    width = (dgvCodeSenderSet.Width - 50 - 2) / (dgvCodeSenderSet.Columns.Count - 1);
            //}
            //catch (Exception ex)
            //{ }
            //for (int i = 1; i < dgvCodeSenderSet.Columns.Count; i++)
            //{
            //    dgvCodeSenderSet.Columns[i].ReadOnly = true;
            //    dgvCodeSenderSet.Columns[i].Width = width;
            //}
            //lblSumPage.Text = "/" + pagecount.ToString() + "页";
            //txtSkipPage.Text = lblPageCounts.Text;
            //lblCounts.Text = "符合筛选条件：共 " + rowcount.ToString() + " 条";
        }
        #endregion

        #region 【事件方法：显示上一页】
        private void btnUpPage_Click(object sender, EventArgs e)
        {
            if (isCodeSenderSet)
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
                BindCodeSet(page);

            }
            else
            {
                if (int.Parse(this.lblPageCounts.Text) > 1)
                {
                    lblPageCounts.Text = Convert.ToString(int.Parse(lblPageCounts.Text) - 1);
                    BindCode(int.Parse(this.lblPageCounts.Text));
                }
            }
        }
        #endregion

        #region 【事件方法：显示下一页】
        private void btnDownPage_Click(object sender, EventArgs e)
        {
            if (isCodeSenderSet)
            {
                int page = int.Parse(lblPageCounts.Text);
                page++;

                if (!btnUpPage.Enabled)
                {
                    btnUpPage.Enabled = true;
                }
                if (page == pagecount)              //最后一页时
                {

                    btnDownPage.Enabled = false;
                }
                else if (page > pagecount)          //大于最后一页时
                {
                    return;
                }
                else
                {
                    btnDownPage.Enabled = true;

                }
                BindCodeSet(page);
            }
            else
            {
                if (int.Parse(this.lblPageCounts.Text) < pagecount)
                {
                    lblPageCounts.Text = Convert.ToString(int.Parse(lblPageCounts.Text) + 1);
                    BindCode(int.Parse(this.lblPageCounts.Text));
                }
            }
        }
        #endregion

        #region 【事件方法：选择每页显示个数】
        private void cmbSelectCounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (m_RowCount == Convert.ToInt32(cmbSelectCounts.SelectedItem))
                //{
                //    return;
                //}
                if (cmbSelectCounts.Text.Trim() == "全部")
                    m_RowCount = 9999999;
                else
                    m_RowCount = Convert.ToInt32(cmbSelectCounts.SelectedItem);
                //m_RowCount = Convert.ToInt32(cmbSelectCounts.SelectedItem);
                if (isCodeSenderSet)
                {
                    BindCodeSet(1);
                }
                else
                {
                    BindCode(1);
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 【事件方法：跳转页数】
        private void txtSkipPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    int indexpage = int.Parse(this.txtSkipPage.Text);
                    if (indexpage > pagecount)
                    {
                        this.txtSkipPage.Text = pagecount.ToString();
                    }
                    if (indexpage <= 0)
                    {
                        txtSkipPage.Text = "1";
                    }
                }
                catch
                {
                    txtSkipPage.Text = "1";
                }

                try
                {
                    if (isCodeSenderSet)
                    {
                        BindCodeSet(int.Parse(txtSkipPage.Text));
                    }
                    else
                    {
                        BindCode(int.Parse(txtSkipPage.Text));
                    }
                }
                catch
                { }
            }
        }
        #endregion

        #region 【事件方法：按条件点击查询标识卡人员配置信息】
        private void btnSearch_Click(object sender, EventArgs e)
        {
            strCodeSender = txtCodeSender.Text;
            BindCodeSet(1);
        }
        #endregion

        #region 【事件方法：重置查询标识卡人员配置信息条件】
        private void btnReSet_Click(object sender, EventArgs e)
        {
            this.txtCodeSender.Text = "";
            strCodeSender = "";
            btnSearch_Click(null, null);
        }
        #endregion

        #region 【事件方法：按条件点击查询标识卡信息】
        private void btnCodeSearch_Click(object sender, EventArgs e)
        {
            strCode = txtCode.Text;
            BindCode(1);
        }
        #endregion

        #region 【事件方法：重置查询条件】
        private void button2_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            strCode = "";
            btnCodeSearch_Click(null, null);
        }
        #endregion

        #region 【事件方法：全选】
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text == "全选")
            {
                for (int i = 0; i < dgvCodeSenderSet.Rows.Count; i++)
                {
                    ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).TrueValue;
                }
                btnSelectAll.Text = "取消";
            }
            else
            {
                for (int i = 0; i < dgvCodeSenderSet.Rows.Count; i++)
                {
                    ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).FalseValue;
                }
                btnSelectAll.Text = "全选";
            }
        }
        #endregion

        #region 【事件方法：删除数据】
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool bFalg = false;
            for (int i = (dgvCodeSenderSet.Rows.Count - 1); i >= 0; i--)
            {
                if (((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).TrueValue)
                {
                    bFalg = true;
                    break;
                }
            }
            
            if (isCodeSenderSet)
            {
                if (!bFalg)
                {
                    MessageBox.Show("未选中要删除的标识卡和人员关联信息", "提示");
                    return;
                }

                DialogResult result;
                result = MessageBox.Show("是否要删除选中标识卡和人员关联信息？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    for (int i = (dgvCodeSenderSet.Rows.Count - 1); i >= 0; i--)
                    {
                        if (((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).TrueValue)
                        {
                            string codeaddress = dgvCodeSenderSet.Rows[i].Cells[1].Value.ToString();
                            if (codebll.DeleteCodeSenderSet(codeaddress) > 0)
                            {
                                dgvCodeSenderSet.Rows.RemoveAt(i);
                            }
                        }
                    }

                    //Czlt-2011-12-19 配置信息删除,跟新配置时间
                    codebll.UpdateTime();

                    btnSelectAll.Text = "全选";
                    if (isCodeSenderSet)
                    {
                        BindCodeSet(1);
                    }
                    else
                    {
                        BindCode(1);
                    }
                }
            }
            else
            {
                if (!bFalg)
                {
                    MessageBox.Show("未选中要删除的标识卡信息", "提示");
                    return;
                }
                DialogResult result;
                result = MessageBox.Show("是否要删除选中标识卡信息？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    for (int i = (dgvCodeSenderSet.Rows.Count - 1); i >= 0; i--)
                    {
                        if (((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).TrueValue)
                        {
                            string codeaddress = dgvCodeSenderSet.Rows[i].Cells[1].Value.ToString();
                            if (codebll.DelCodeSenderByAddress(codeaddress))
                            {
                                dgvCodeSenderSet.Rows.RemoveAt(i);
                            }
                        }
                    }

                    //Czlt-2011-12-19 配置信息删除,跟新配置时间
                    codebll.UpdateTime();

                    btnSelectAll.Text = "全选";
                    if (isCodeSenderSet)
                    {
                        BindCodeSet(1);
                    }
                    else
                    {
                        BindCode(1);
                    }
                }
            }
        }
        #endregion

        #region 【事件方法：标识卡关联信息】
        public void btnCodesender_Click(object sender, EventArgs e)
        {
            isCodeSenderSet = true;
            btnLaws.Enabled = false;
            this.AcceptButton = btnSearch;
            //trvCodesender.SelectedNode = trvCodesender.Nodes[0];
            //trvCodesender_AfterSelect(this, new TreeViewEventArgs(trvCodesender.Nodes[0]));
            //trvDept_AfterSelect(this, null);
            drawerLeftMain.ButtonClick(pnl1.Name);
            BindCodeSet(1);
        }
        #endregion

        #region 【事件方法：标识卡信息】
        public void btnCode_Click(object sender, EventArgs e)
        {
            isCodeSenderSet = false;
            btnLaws.Enabled = true;
            this.AcceptButton = btnCodeSearch;
            //trvCodesender_AfterSelect(this, null);
            drawerLeftMain.ButtonClick(pnl2.Name);
            BindCode(1);
        }
        #endregion

        #region 【事件方法：显示添加界面】
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isCodeSenderSet)
            {
                A_frmCodeSenderSet f = new A_frmCodeSenderSet(this);
                f.ShowDialog();
                //Flash();
            }
            else
            {
                A_frmAddCode f = new A_frmAddCode(this);
                f.ShowDialog();
                //Flash();
            }
        }
        #endregion

        #region 【事件方法：显示修改界面】
        private void btnLaws_Click(object sender, EventArgs e)
        {
            int num = 0;
            int index = -1;
            for (int i = 0; i < dgvCodeSenderSet.Rows.Count; i++)
            {
                if (((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgvCodeSenderSet.Rows[i].Cells[0]).TrueValue)
                {
                    num++;
                    index = i;
                }
            }
            if (num <= 0)
            {
                MessageBox.Show("请选择要修改的标识卡记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (num > 1)
            {
                MessageBox.Show("每次只能修改一条记录...", "提示", MessageBoxButtons.OK);
            }
            else
            {
                if (index != -1)
                {
                    string codesenderaddress = dgvCodeSenderSet.Rows[index].Cells[1].Value.ToString();
                    A_frmAddCode f = new A_frmAddCode(codesenderaddress, 1,this);
                    f.ShowDialog();
                    //Flash();
                }
            }
        }
        #endregion

        #region 【方法：刷新数据（该方法无用）】
        //private Timer t = null;
        //private int FlashNum = 0;
        
        //private void Flash()
        //{
        //    FlashNum = KJ128NInterfaceShow.RefReshTime.intHostBackRefCount;
        //    int interval = KJ128NInterfaceShow.RefReshTime.intHostBackRefTime;
        //    if (t == null)
        //    {
        //        t = new Timer();
        //    }
        //    t.Interval = interval;
        //    t.Tick += new EventHandler(t_Tick);
        //    t.Start();
        //}
        //#endregion

        //#region 【事件方法：定时刷新】
        //void t_Tick(object sender, EventArgs e)
        //{
        //    if (FlashNum > 0)
        //    {
        //        FlashNum--;
        //        if (isCodeSenderSet)
        //        {
        //            BindCodeSet(1);
        //            //btnCodesender_Click(this, new EventArgs());
        //        }
        //        else
        //        {
        //            BindCode(1);
        //            //btnCode_Click(this, new EventArgs());
        //        }
        //    }
        //    else
        //    {
        //        t.Stop();
        //    }
        //}
        #endregion

       

        #region 【事件方法：单选】
        private void dgvCodeSenderSet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    btnSelectAll.Text = "全选";
                    if (dgvCodeSenderSet.Rows[e.RowIndex].Cells[0].Value != null && dgvCodeSenderSet.Rows[e.RowIndex].Cells[0].Value.ToString().Equals("True"))
                    {
                        dgvCodeSenderSet.Rows[e.RowIndex].Cells[0].Value = "false";
                    }
                    else
                    {
                        dgvCodeSenderSet.Rows[e.RowIndex].Cells[0].Value = "true";
                    }
                }
            }
        }
        #endregion

        #region 【事件方法：树颜色改变】
        private Color _nodeBackColor = Color.FromArgb(44, 67, 132);
        private TreeNode tnode = new TreeNode();
        private TreeNode tnode2 = new TreeNode();
        private void trvDept_Enter(object sender, EventArgs e)
        {
            if (tnode != null)
            {
                tnode.BackColor = Color.White;
                tnode.ForeColor = Color.Black;
            }
        }

        private void trvDept_Leave(object sender, EventArgs e)
        {
            if (trvDept.SelectedNode != null)
            {
                tnode = trvDept.SelectedNode;
                tnode.ForeColor = Color.White;
                tnode.BackColor = _nodeBackColor;
            } 
        }

        private void trvCodesender_Enter(object sender, EventArgs e)
        {
            if (tnode2 != null)
            {
                tnode2.BackColor = Color.White;
                tnode2.ForeColor = Color.Black;
            }
        }

        private void trvCodesender_Leave(object sender, EventArgs e)
        {
            if (trvCodesender.SelectedNode != null)
            {
                tnode2 = trvCodesender.SelectedNode;
                tnode2.ForeColor = Color.White;
                tnode2.BackColor = _nodeBackColor;
            }
        }
        #endregion

        #region 【事件方法：人员、设备选项改变】
        private void rdbEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEmp.Checked)
                type = rdbEmp.Text;
            else
                type = rdbMch.Text;
            BindCodeSet(1);
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
                if (isCodeSenderSet)
                {
                    BindCodeSet(1);
                }
                else
                {
                    BindCode(1);
                }
                #endregion

            }
        }
        #endregion

        private void A_frmCodeSender_Activated(object sender, EventArgs e)
        {
            if (rdbEmp.Checked)
                type = rdbEmp.Text;
            else
                type = rdbMch.Text;
            cmbSelectCounts.SelectedIndex = 0;
            LoadTrvDept();
            trvDept.Nodes[0].Expand();
            trvCodesender.Nodes[0].Expand();
            trvDept.SelectedNode = trvDept.Nodes[0];

        }

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        private void dgvCodeSenderSet_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
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

        private void A_frmCodeSender_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("CodeSender.xml");
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

        #region 【事件方法：打印 导出】 
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgvCodeSenderSet, PrintTableName());
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgvCodeSenderSet, PrintTableName(), "");
        }
        private string PrintTableName()
        {
            if (isCodeSenderSet)
            {
                return "标识卡匹配信息";
            }
            else
            {
                return "标识卡信息";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            KJ128NDBTable.PrintBLL.Print(dgvCodeSenderSet, PrintTableName(), lblCounts.Text);
            
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

            strNodeChildName = tn.Text.ToString();
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    string strDid = string.Empty;
                    if (n.Nodes.Count > 0)
                    {
                        strDid =GetNodeAllChild(n);
                    }
                    if (strDid.Equals(""))
                    {
                        strNodeChildName += "','" + n.Text.ToString();
                    }
                    else
                    {
                        strNodeChildName += "','" + n.Text.ToString()+"','"+strDid; 
                    }
                }
            }
            return strNodeChildName;
        }
        #endregion
    }
}
