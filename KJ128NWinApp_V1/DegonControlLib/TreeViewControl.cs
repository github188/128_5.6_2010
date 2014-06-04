using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DegonControlLib
{
    public partial class TreeViewControl : TreeView
    {
        public TreeViewControl()
        {
            InitializeComponent();
        }

        private DataTable dtMenus = new DataTable();

        /// <summary>
        /// 数据源
        /// </summary>
        public DataTable DataSouce
        {
            set { dtMenus = value; }
        }

        private Color _nodeBackColor = Color.FromArgb(44, 67, 132);
        public Color NodeBackColor
        {
            get { return _nodeBackColor; }
            set { _nodeBackColor = value; }
        }
        
        private TreeNode tnode = new TreeNode();
        /// <summary>
        /// 设置选中节点颜色
        /// </summary>
        public void SetSelectNodeColor()
        {
            if (this.Nodes.Count <= 0)
            {
                return;
            }
            if (this.SelectedNode != null)
            {
                tnode = this.SelectedNode;
                //tnode.ForeColor = Color.White;
                //tnode.BackColor = _nodeBackColor;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this.Nodes.Count <= 0)
            {
                return;
            }
            if (this.SelectedNode != null)
            {
                tnode = this.SelectedNode;
                tnode.ForeColor = Color.White;
                tnode.BackColor = _nodeBackColor;
            } 
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (tnode != null)
            {
                tnode.BackColor = Color.White;
                tnode.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 构建树表结构
        /// </summary>
        /// <returns></returns>
        public DataTable BuildMenusEntity()
        {
            DataTable dt = new DataTable("Menus");
            dt.Columns.Add("ID", typeof(System.String));
            dt.Columns.Add("Name", typeof(System.String));
            dt.Columns.Add("ParentID", typeof(System.String));
            dt.Columns.Add("IsChild", typeof(System.Boolean));
            dt.Columns.Add("IsUserNum", typeof(System.Boolean));
            dt.Columns.Add("Num", typeof(System.Int32));
            return dt;
        }

        /// <summary>
        /// 加载节点
        /// </summary>
        /// <param name="unit">单位</param>
        public void LoadNode(string unit)
        {
            DataRow[] drs = dtMenus.Select("IsChild=false");
            foreach (DataRow dr in drs)
            {
                TreeNode node = new TreeNode();
                string strText = "";
                node.Name = dr["ID"].ToString().Trim();
                strText = dr["Name"].ToString().Trim();
                node.Tag = dr["Name"].ToString().Trim();
                node.BackColor = Color.White;
                node.ForeColor = Color.Black;
                if (!this.Nodes.ContainsKey(node.Name))
                {
                    this.Nodes.Add(node);
                }
                else
                {
                    node = Nodes[node.Name];
                }
                int num = int.Parse(dr["Num"].ToString()) + this.LoadNode(node, bool.Parse(dr["IsUserNum"].ToString()), false, unit);
                if (bool.Parse(dr["IsUserNum"].ToString()))
                {
                    strText += "(" + num.ToString() + unit + ")";
                }
                if (!node.Text.Equals(strText))
                {
                    node.Text = strText;
                }
            }
            bool flag = false;
            for (int i = this.Nodes.Count-1; i >=0 ; i--)
            {
                flag = false;
                foreach (DataRow dr in drs)
                {
                    if (this.Nodes[i].Name.Equals(dr["ID"].ToString().Trim()))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    this.Nodes.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// 加载节点
        /// </summary>
        /// <param name="node">上级节点</param>
        /// <param name="showFlag">是否显示数值</param>
        /// <param name="flag">是否是子节点  true 是 false 不是</param>
        /// <param name="unit">显示单位</param>
        /// <returns>数据</returns>
        private int LoadNode(TreeNode node, bool showFlag, bool flag, string unit)
        {
            string filter = "ParentID = '" + node.Name+"'";
            DataRow[] rows = dtMenus.Select(filter);
            int number = 0;
            TreeNode sub = null;
            foreach (DataRow row in rows)
            {
                sub = new TreeNode();
                string strText = "";
                strText = row["Name"].ToString().Trim();
                //sub.Text = row["Name"].ToString().Trim();
                bool boolShowFlag = bool.Parse(row["IsUserNum"].ToString());
                if (boolShowFlag)
                {
                    strText += "(" + row["Num"].ToString() + unit + ")";
                    //sub.Text += "(" + row["Num"].ToString() + unit + ")";
                    number += int.Parse(row["Num"].ToString());
                }
                sub.Name = row["ID"].ToString().Trim();
                sub.Tag = row["Name"].ToString().Trim();
                sub.BackColor = Color.White;
                sub.ForeColor = Color.Black;
                if (!node.Nodes.ContainsKey(sub.Name))
                {
                    node.Nodes.Add(sub);
                }
                else
                {
                    sub = node.Nodes[sub.Name];
                }
                if (!node.Nodes[sub.Name].Text.Equals(strText))
                {
                    node.Nodes[sub.Name].Text = strText;
                }
                number += this.LoadNode(sub, boolShowFlag, true, unit);

            }
            if (showFlag)
            {
                if (flag && rows.Length > 0)
                {
                    string strTemp = node.Text.Insert(node.Text.Length - 1, "+" + number.ToString() + unit);
                    if (!node.Text.Equals(strTemp))
                    {
                        node.Text = strTemp;
                    }
                }
            }

            bool fflag = false;
            for (int i = node.Nodes.Count - 1; i >= 0; i--)
            {
                fflag = false;
                foreach (DataRow row in rows)
                {
                    if (node.Nodes[i].Name.Equals(row["ID"].ToString().Trim()))
                    {
                        fflag = true;
                        break;
                    }
                }
                if (!fflag)
                {
                    node.Nodes.RemoveAt(i);
                }
            }

            return number;
        }
    }
}