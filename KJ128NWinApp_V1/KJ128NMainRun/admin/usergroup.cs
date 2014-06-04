using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NInterfaceShow;
using System.Collections;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NInterfaceShow
{
    public partial class usergroup : Wilson.Controls.Docking.DockContent
    {
        public usergroup()
        {
            InitializeComponent();
        }
        
        UserGroupBLL bll = new UserGroupBLL();
        MenuBLL mBLL = new MenuBLL();
        #region  登陆事件
        private void usergroup_Load(object sender, EventArgs e)
        {
            bll.setCboUserGroup(this.cboUserGroup);
            if (cboUserGroup.Items.Count > 0)
            {
                TreeViewData();
            }
            cboUserGroup_SelectedIndexChanged(null, null);

        }
        #endregion

        #region 树形控件绑定

        public void TreeViewData()
        {
            FrmMain main = new FrmMain();
            main.TreeViewData(this.treeView1);
        }

        Hashtable ht = new Hashtable();
        public void setData(int id)
        {
            ht.Clear();
            DataSet ds = bll.selectUserGroups(id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (ht.Contains(dr[2].ToString()))
                    {
                        ht[dr[2].ToString()] = Convert.ToBoolean(dr[1].ToString());
                    }
                    else
                    {
                        ht.Add(dr[2].ToString(), Convert.ToBoolean(dr[1].ToString()));
                    }
                }

                foreach (TreeNode node in treeView1.Nodes)
                {
                    setTreeView(node);
                }
            }
            else
            {
                foreach (TreeNode tn  in treeView1.Nodes)
                {
                    tn.Checked = false;
                    if (tn.Nodes.Count > 0)
                    {
                        foreach (TreeNode item in tn.Nodes)
                        {
                            item.Checked = false;
                        }
                    }
                }
            }
        }

        public void setTreeView(TreeNode node)
        {
            node.Checked = Convert.ToBoolean(ht[node.Name.ToString()]);
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode node1 in node.Nodes)
                {
                    setTreeView(node1);
                }
            }
        }

        #endregion 

        #region 用户组绑定 
        private void cboUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUserGroup.SelectedValue != null && cboUserGroup.SelectedValue.ToString() != "System.Data.DataRowView")
                setData((int)cboUserGroup.SelectedValue);
        }
        #endregion 

        #region 树形控件事件
     
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            setChecked(e.Node);
            pNodeCheck(e.Node);
        }

        public void  setChecked(TreeNode node)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode node1 in node.Nodes)
                {
                    node1.Checked = node.Checked;
                    setChecked(node1);
                }
            }
        }

        public void pNodeCheck(TreeNode node)
        {
            if (node.Parent != null && node.Parent.Level >= 0 )
            {
                if (node.Checked)
                {
                    node.Parent.Checked = node.Checked;
                    pNodeCheck(node.Parent);
                }
                else
                {
                    node.Parent.Checked = SNodeCheck(node.Parent);
                }
            }
        }


        public bool SNodeCheck(TreeNode node)
        {

            if (node.Nodes.Count > 0 )
            {
                foreach (TreeNode node1 in node.Nodes)
                {
                    if (node1.Checked)
                    {
                        return true;
                    }
                 
                }
            }
            return false;
        }
        #endregion 

        #region 保存菜单信息到数据库
        private void buttonCaptionPanel1_Click(object sender, EventArgs e)
        {
            //存入日志
            LogSave.Messages("[usergroup]", LogIDType.UserLogID, "配置用户组权限，用户组名称：" + cboUserGroup.SelectedText);

            foreach (TreeNode node1 in treeView1.Nodes)
            {
                sql = sql + " exec insertUserGroupMenu1 '" + node1.Name + "'," + cboUserGroup.SelectedValue.ToString() + "," + Convert.ToByte(node1.Checked) + " ";
                if (node1.Nodes.Count > 0)
                {
                    getChangNodeItem(node1);
                }
            }


            if (mBLL.ExcuteSql(sql) >= 0)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }     
        }
     
        string sql = "";
        public void getChangNodeItem(TreeNode node)
        {
            foreach (TreeNode node1 in node.Nodes)
            {
                sql = sql + " exec insertUserGroupMenu1 '" + node1.Name + "'," + cboUserGroup.SelectedValue.ToString() + "," + Convert.ToByte(node1.Checked) + " ";
                if (node1.Nodes.Count > 0)
                { 
                    getChangNodeItem(node1);
                }
            }

        }

        #endregion

        #region 关闭
        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
    }
}