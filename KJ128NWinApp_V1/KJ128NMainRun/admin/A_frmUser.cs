using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.FromModel;
using KJ128NDataBase;

namespace KJ128NMainRun.admin
{
    public partial class A_frmUser : FrmModel
    {
        
        #region【声明】

        private KJ128NDBTable.A_UserBLL bll = new KJ128NDBTable.A_UserBLL();
        private int PageCount = 0;
        private bool isUser = true;
        private A_FrmMain main = null;
        private string strUserNameTree = "all";

        #endregion


        public A_frmUser()
        {
            InitializeComponent();
            drawerLeftMain.Add(pnlUser,true);
            drawerLeftMain.Add(pnlLimit);
            drawerLeftMain.LeftPartResize();
        }

        public A_frmUser(A_FrmMain f)
        {
            InitializeComponent();
            drawerLeftMain.Add(pnlUser, true);
            drawerLeftMain.Add(pnlLimit);
            drawerLeftMain.LeftPartResize();
            this.main = f;
        }

        #region【窗体加载】

        private void A_frmUser_Load(object sender, EventArgs e)
        {
            cmbSelectCounts.SelectedIndex = 0;
            LoadTrees();
            btnUser_Click(this, new EventArgs());
        }

        #endregion

        private void LoadTrees()
        {
            trvUser.Nodes.Add("all", "所有");
            DataTable dt = bll.GetUserGroups();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode trvnode = new TreeNode(dt.Rows[i][1].ToString());
                trvnode.Name = dt.Rows[i][0].ToString();
                trvUser.Nodes[0].Nodes.Add(trvnode);
                //DataTable nodedt = bll.GetUserByUG(trvnode.Name);
                //for (int j = 0; j < dt.Rows.Count; j++)
                //{
                //    trvnode.Nodes.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                //}
            }
            trvUser.Nodes[0].Expand();
            trvLimit.Nodes.Add("all", "所有");
            dt = bll.GetUserGroups();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode trvnode = new TreeNode(dt.Rows[i][1].ToString());
                trvnode.Name = dt.Rows[i][0].ToString();
                trvLimit.Nodes[0].Nodes.Add(trvnode);
            }
            trvLimit.Nodes[0].Expand();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            drawerLeftMain.ButtonClick(pnlUser.Name);
            this.dgv.Visible = true;
            trvUserLimit.Visible = false;
            trvUser.SelectedNode = trvUser.Nodes[0];
            trvUser_AfterSelect(this, new TreeViewEventArgs(trvUser.Nodes[0]));
            isUser = true;
            this.panelMainBottom.Visible = true;
            btnSave.Visible = false;
            btnAdd.Visible = true;
            btnLaws.Visible = true;
            btnSelectAll.Visible = true;
            btnDelete.Visible = true;
            btnPrint.Visible = true;
            btnConfigModel.Visible = true;
            btnExportExcel.Visible = true;
            trvUser.Nodes.Clear();
            trvLimit.Nodes.Clear();
            LoadTrees();
        }

        private void btnLimit_Click(object sender, EventArgs e)
        {
            drawerLeftMain.ButtonClick(pnlLimit.Name);
            isUser = false;
            this.dgv.Visible = false;
            this.trvUserLimit.Dock = DockStyle.Fill;
            this.trvUserLimit.Visible = true;
            this.panelMainBottom.Visible = false;
            btnSave.Visible = true;
            btnAdd.Visible = false;
            btnLaws.Visible = false;
            btnSelectAll.Visible = false;
            btnDelete.Visible = false;
            btnPrint.Visible = false;
            btnConfigModel.Visible = false;
            btnExportExcel.Visible = false;
            trvUser.Nodes.Clear();
            trvLimit.Nodes.Clear();
            LoadTrees();
        }

        #region【方法：查询】

        private void Select_User()
        {
            if (strUserNameTree == "")
            {
                strUserNameTree = "all";
            }

            DataTable dt = bll.GetAdmins(strUserNameTree);
            dt.TableName = "A_FrmUserConfig";
            dgv.DataSource = dt;
            int width = 0;
            try
            {
                width = (dgv.Width - 50 - 2) / (dgv.Columns.Count - 1);
            }
            catch (Exception ex)
            { }
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].ReadOnly = false;
                dgv.Columns[i].Width = width;
            }
            lblCounts.Text = "共 " + dt.Rows.Count.ToString() + " 条";

            if (btnSelectAll.Text.Equals("取消"))
            {
                btnSelectAll.Text = "全选";
            }

            //try
            //{
            //    dgv.Columns["是否可用"].ReadOnly = false;
            //}
            //catch{}

        }

        #endregion

        #region【事件：选择用户树】

        private void trvUser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strUserNameTree = trvUser.SelectedNode.Name;
            Select_User();
        }

        #endregion

        private static int id = 0;
        private string UserGroupID = string.Empty;
        private void trvLimit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvLimit.SelectedNode.Text != "所有")
            {
                if (main != null)
                {
                    UserGroupID = trvLimit.SelectedNode.Name;
                    trvUserLimit.Nodes.Clear();
                    MenuStrip mm = main.MS;
                    LoadMenuToTree(mm, trvUserLimit);
                }
            }
            else
            {
                trvUserLimit.Nodes.Clear();
            }
        }

        private void LoadMenuToTree(MenuStrip mm, TreeView trv)
        {
            foreach (ToolStripMenuItem item in mm.Items)
            {
                TreeNode node = new TreeNode();
                node.Name = item.Name;
                node.Text = item.Text;
                node.ImageKey = (++id).ToString();
                node.Checked = bll.GetUGMenuPower(node.Name, UserGroupID);
                trv.Nodes.Add(node);
                LoadMenuToTreeNode(item, node);
            }
        }

        private void LoadMenuToTreeNode(ToolStripMenuItem mitem, TreeNode node)
        {
            for (int i = 0; i < mitem.DropDownItems.Count; i++)
            {
                try
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)mitem.DropDownItems[i];
                    TreeNode chnode = new TreeNode();
                    chnode.Name = item.Name;
                    chnode.Text = item.Text;
                    chnode.Checked = bll.GetUGMenuPower(chnode.Name, UserGroupID);
                    chnode.ImageKey = (++id).ToString();
                    node.Nodes.Add(chnode);
                    LoadMenuToTreeNode(item, chnode);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }





        #region【热备刷新】

        private Timer t = null;
        private int FlashNum = 0;
        public void Flash()
        {
            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
            {
                if (isUser)
                {
                    Select_User();
                }
            }
            else                                //热备版，启用定时器
            {
                FlashNum = KJ128NInterfaceShow.RefReshTime.intHostBackRefCount;
                int interval = KJ128NInterfaceShow.RefReshTime.intHostBackRefTime;
                if (t == null)
                {
                    t = new Timer();
                }
                t.Interval = interval;
                t.Tick += new EventHandler(t_Tick);
                t.Start();
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (FlashNum > 0)
            {
                FlashNum--;
                if (isUser)
                {
                    Select_User();
                }
            }
            else
            {
                t.Stop();
            }
        }

        #endregion

        #region【事件：新增】

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isUser)
            {
                A_frmAddUser f = new A_frmAddUser(this);
                f.ShowDialog();
                //Flash();
            }
        }

        #endregion

        #region【事件：删除】

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isUser)
            {
                int num = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["cl"].Value != null && int.Parse(dgv.Rows[i].Cells["cl"].Value.ToString()) == 1)
                    {
                        num++;
                    }
                }
                if (num == 0)
                {
                    MessageBox.Show("请选择要删除的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (MessageBox.Show("是否要删除选择的记录？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (dgv.Rows[i].Cells["cl"].Value != null && int.Parse(dgv.Rows[i].Cells["cl"].Value.ToString()) == 1)
                        {
                            if (dgv.Rows[i].Cells[1].Value.ToString() == "admin")
                            {
                                MessageBox.Show("admin为系统用户无法删除！", "提示", MessageBoxButtons.OK);
                                continue;
                            }
                            bll.DelUserByUserName(dgv.Rows[i].Cells[1].Value.ToString());
                        }
                    }

                    //Czlt-2011-12-18 删除配置信息,更新时间
                    bll.UpdateTime();
                    Flash();
                }
            }
        }

        #endregion

        #region【事件：全选】

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (btnSelectAll.Text == "全选")
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        ((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).TrueValue;
                    }
                    btnSelectAll.Text = "取消";
                }
                else
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        ((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).FalseValue;
                    }
                    btnSelectAll.Text = "全选";
                }
            }
        }

        #endregion

        #region【事件：修改】

        private void btnLaws_Click(object sender, EventArgs e)
        {
            int num = 0;
            int index = -1;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["cl"].Value != null && int.Parse(dgv.Rows[i].Cells["cl"].Value.ToString()) == 1)
                {
                    num++;
                    index = i;
                }
            }
            if (num == 0)
            {
                MessageBox.Show("请选择要修改的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (num > 1)
            {
                MessageBox.Show("每次只能修改一条记录！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else
            {
                if (index != -1)
                {
                    if (isUser)
                    {
                        string username = dgv.Rows[index].Cells[1].Value.ToString();
                        string usergroup = dgv.Rows[index].Cells[2].Value.ToString();
                        bool isenable = Convert.ToBoolean(dgv.Rows[index].Cells[3].Value);
                        string remark = dgv.Rows[index].Cells[4].Value.ToString();
                        A_frmAddUser f = new A_frmAddUser(dgv.Rows[index].Cells[1].Value.ToString(), 1, usergroup, isenable, remark,this);
                        f.ShowDialog();
                        //Flash();
                    }
                }
            }
        }

        #endregion

        #region【事件：添加用户组信息】

        private void btnUserGroupAdd_Click(object sender, EventArgs e)
        {
            TreeNode trvnode = new TreeNode();
            trvUser.LabelEdit = true;
            trvUser.Nodes[0].Nodes.Add(trvnode);
            trvUser.ExpandAll();
            trvnode.BeginEdit();
        }

        #endregion

        private void trvUser_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            try
            {
                if (e.Label.Trim() != "" && e.Label != null && !e.Label.Contains("'"))
                {
                    if (bll.InsertUserGroup(e.Label))
                    {
                        e.Node.Name = bll.GetUGidByName(e.Label);
                        e.Node.Text = e.Label;
                        e.Node.EndEdit(false);
                        //Czlt-2011-12-20 修改配置信息
                        bll.UpdateTime();
                        
                    }
                    else
                    {
                        MessageBox.Show("添加用户组名失败...", "提示", MessageBoxButtons.OK);
                        e.Node.EndEdit(true);
                        e.Node.Remove();
                    }
                }
                else
                {
                    MessageBox.Show("输入用户组名格式错误...", "提示", MessageBoxButtons.OK);
                    e.Node.EndEdit(true);
                    e.Node.Remove();
                    //trvUser.Nodes[0].Nodes.RemoveAt(trvUser.Nodes[0].Nodes.Count - 1);
                }
            }
            catch (Exception ex)
            {
                if (e.Node.Text != "")
                {
                    return;
                }
                e.Node.EndEdit(true);
                e.Node.Remove();
                
            }
            trvUser.LabelEdit = false;
            //trvUser.Nodes.Clear();
            //trvLimit.Nodes.Clear();
            //LoadTrees();
            //e.Node.EndEdit();
            //btnUser_Click(this, new EventArgs());
        }

        private void trvUserLimit_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckAllChild(e.Node, e.Node.Checked);
        }

        private void CheckAllChild(TreeNode node, bool ch)
        {
            foreach (TreeNode chnode in node.Nodes)
            {
                chnode.Checked = ch;
                CheckAllChild(chnode, ch);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (trvLimit.SelectedNode != null && trvLimit.SelectedNode.Name != "all")
                {
                    string ugid = trvLimit.SelectedNode.Name;
                    bll.DelMenuByUGid(ugid);
                    if (bll.IsMenuSaved())
                    {
                        foreach (TreeNode node in trvUserLimit.Nodes)
                        {
                            SaveMenu(node, "-1", ugid);
                        }
                    }
                    else
                    {
                        foreach (TreeNode node in trvUserLimit.Nodes)
                        {
                            SaveInsertMenu(node, "-1", ugid);
                        }
                    }
                }
                MessageBox.Show("保存成功...", "提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败...", "提示", MessageBoxButtons.OK);
            }
        }

        private void SaveMenu(TreeNode node,string pid,string ugid)
        {
            //bll.InsertMenu(pid, node.Text, node.Name);
            string cpid = bll.GetMenuPidByMenuName(node.Name);
            node.ImageKey = cpid;
            bll.InsertUGmenu(ugid, cpid, node.Checked, "");
            foreach (TreeNode chnode in node.Nodes)
            {
                SaveMenu(chnode, node.ImageKey, ugid);
            }
        }

        private void SaveInsertMenu(TreeNode node, string pid, string ugid)
        {
            bll.InsertMenu(pid, node.Text, node.Name);
            string cpid = bll.GetMenuPidByMenuName(node.Name);
            node.ImageKey = cpid;
            bll.InsertUGmenu(ugid, cpid, node.Checked, "");
            foreach (TreeNode chnode in node.Nodes)
            {
                SaveInsertMenu(chnode, node.ImageKey, ugid);
            }
        }

      

        #region【事件：删除用户组】

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                if (trvUser.SelectedNode != null && trvUser.SelectedNode.Text != "所有")
                {
                    if (trvUser.SelectedNode.Text=="管理员")
                    {
                        MessageBox.Show("不能删除管理员用户组", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    result = MessageBox.Show("删除该用户组，将会丢失与该用户组相关的用户信息，是否删除", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Yes)
                    {
                        //Czlt-2011-12-20 删除用户更新
                        bll.UpdateTime();
                        bll.DelUserGroupByID(trvUser.SelectedNode.Name);
                        btnUser_Click(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("请选择要删除的用户组", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region【事件：单元格单击事件——改变是否选中】

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv.Columns[e.ColumnIndex].Name.Equals("cl"))
                {
                    if (dgv.Rows[e.RowIndex].Cells["cl"].Value != null && dgv.Rows[e.RowIndex].Cells["cl"].Value.ToString().Equals("1"))
                    {
                        dgv.Rows[e.RowIndex].Cells["cl"].Value = 0;
                        if (btnSelectAll.Text.Equals("取消"))
                        {
                            btnSelectAll.Text = "全选";
                        }
                    }
                    else
                    {
                        dgv.Rows[e.RowIndex].Cells["cl"].Value = 1;
                    }
                }
            }
        }

        #endregion

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
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

        private void A_frmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("Power.xml");
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
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv, "权限信息");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.PrintSet(dgv, "权限信息", "");
        }
      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv, "权限信息", lblCounts.Text);
        }

        #endregion
    }
}
