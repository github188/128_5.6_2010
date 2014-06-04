using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace KJ128WindowsLibrary
{
    /// <summary>
    /// 封装树
    /// </summary>
    public partial class ZzhaTreeView : TreeView
    {
        private DataTable _TreeDataSource;
        /// <summary>
        /// 用于绑定该树的数据源
        /// </summary>
        public DataTable TreeDataSource
        {
            get { return _TreeDataSource; }
            set 
            {
                _TreeDataSource = value;
                this.DataBind();
            }
        }

        private string _RootIndexValue = "0";
        /// <summary>
        /// 数据源中根节点parentid的值
        /// </summary>
        public string RootIndexValue
        {
            get { return _RootIndexValue; }
            set { _RootIndexValue = value; }
        }

        private int _IdIndex = 0;
        /// <summary>
        /// 数据源中ID的下标
        /// </summary>
        public int IdIndex
        {
            get { return _IdIndex; }
            set { _IdIndex = value; }
        }

        private string _ParentIdName = "ParentID";
        /// <summary>
        /// 数据源中父节点ID的列名称
        /// </summary>
        public string ParentIdName
        {
            get { return _ParentIdName; }
            set { _ParentIdName = value; }
        }

        private int _TextIndex = 2;
        /// <summary>
        /// 数据源中于节点文本绑定的列名
        /// </summary>
        public int TextIndex
        {
            get { return _TextIndex; }
            set { _TextIndex = value; }
        }

        private TreeNode _RootNode = null;
        /// <summary>
        /// 根节点  可以为空
        /// </summary>
        public TreeNode RootNode
        {
            get { return _RootNode; }
            set 
            {
                _RootNode = value;
                SetRootNode();
            }
        }

        private List<string> _ValueList = new List<string>();

        public List<string> ValueList
        {
            get { return _ValueList; }
            set { _ValueList = value; }
        }

        private TreeNode tnode = new TreeNode();

        /// <summary>
        /// 初始化
        /// </summary>
        public ZzhaTreeView()
        {
            InitializeComponent();
            this.AfterSelect += new TreeViewEventHandler(ZzhaTreeView_AfterSelect);
        }

        private Color _nodeBackColor = Color.FromArgb(44, 67, 132);
        public Color NodeBackColor
        {
            get { return _nodeBackColor; }
            set { _nodeBackColor = value; }
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

        void ZzhaTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.ValueList.Clear();
            TreeNode node = this.SelectedNode;
            AddKeyToList(node);
        }

        private void AddKeyToList(TreeNode node)
        {
            ValueList.Add(node.ImageKey);
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                AddKeyToList(node.Nodes[i]);
            }
        }

        private void SetRootNode()
        {
            if(RootNode!=null)
                this.Nodes.Add(RootNode);
        }

        private void DataBind()
        {
            if (RootNode == null)
            {
                AddTreeRoot(this);
            }
            else
            {
                AddTreeNode(RootNode, this.RootIndexValue);
            }
        }

        private void AddTreeRoot(TreeView tr)
        {
            if (TreeDataSource != null)
            {
                DataRow[] dr = TreeDataSource.Select(this.ParentIdName + "=" + this.RootIndexValue);
                if (tr.Nodes.Count >= dr.Length)
                {
                    for (int i = 0; i < tr.Nodes.Count; i++)
                    {
                        if (i < dr.Length)
                        {
                            tr.Nodes[i.ToString()].Text = dr[i].ItemArray[TextIndex].ToString();
                            tr.Nodes[i.ToString()].ImageKey = dr[i].ItemArray[IdIndex].ToString();
                            AddTreeNode(tr.Nodes[i.ToString()], dr[i].ItemArray[IdIndex].ToString());
                        }
                        else
                            tr.Nodes.RemoveAt(i);
                    }
                }
                else
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        if (tr.Nodes.ContainsKey(i.ToString()))
                        {
                            tr.Nodes[i.ToString()].Text = dr[i].ItemArray[TextIndex].ToString();
                            tr.Nodes[i.ToString()].ImageKey = dr[i].ItemArray[IdIndex].ToString();
                            AddTreeNode(tr.Nodes[i.ToString()], dr[i].ItemArray[IdIndex].ToString());
                        }
                        else
                        {
                            tr.Nodes.Add(i.ToString(), dr[i].ItemArray[TextIndex].ToString());
                            tr.Nodes[i.ToString()].ImageKey = dr[i].ItemArray[IdIndex].ToString();
                            AddTreeNode(tr.Nodes[i.ToString()], dr[i].ItemArray[IdIndex].ToString());
                        }
                    }
                }
            }
        }

        private void AddTreeNode(TreeNode tr, string id)
        {
            if (TreeDataSource != null)
            {
                DataRow[] dr = TreeDataSource.Select(this.ParentIdName + "=" + id);
                if (tr.Nodes.Count >= dr.Length)
                {
                    for (int i = 0; i < tr.Nodes.Count; i++)
                    {
                        if (i < dr.Length)
                        {
                            tr.Nodes[i.ToString()].Text = dr[i].ItemArray[TextIndex].ToString();
                            tr.Nodes[i.ToString()].ImageKey = dr[i].ItemArray[IdIndex].ToString();
                            AddTreeNode(tr.Nodes[i.ToString()], dr[i].ItemArray[IdIndex].ToString());
                        }
                        else
                            tr.Nodes.RemoveAt(i);
                    }
                }
                else
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        if (tr.Nodes.ContainsKey(i.ToString()))
                        {
                            tr.Nodes[i.ToString()].Text = dr[i].ItemArray[TextIndex].ToString();
                            tr.Nodes[i.ToString()].ImageKey = dr[i].ItemArray[IdIndex].ToString();
                            AddTreeNode(tr.Nodes[i.ToString()], dr[i].ItemArray[IdIndex].ToString());
                        }
                        else
                        {
                            tr.Nodes.Add(i.ToString(), dr[i].ItemArray[TextIndex].ToString());
                            tr.Nodes[i.ToString()].ImageKey = dr[i].ItemArray[IdIndex].ToString();
                            AddTreeNode(tr.Nodes[i.ToString()], dr[i].ItemArray[IdIndex].ToString());
                        }
                    }
                }
            }
        }
    }
}
