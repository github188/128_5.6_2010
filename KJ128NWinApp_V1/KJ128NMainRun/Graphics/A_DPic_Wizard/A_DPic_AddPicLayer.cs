using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun.Graphics.Expert;
using System.Xml;
using KJ128NDBTable;
namespace KJ128NMainRun.Graphics.A_DPic_Wizard
{
    public partial class A_DPic_AddPicLayer : Form
    {
        Graphics_DpicBLL grap = new Graphics_DpicBLL();
        A_FrmDCreateConfig frmMain = null;
        string ImageName = string.Empty;
        XmlDocument ConfigXml = null;
        XmlNode RootNode = null;

        #region 构造函数
        public A_DPic_AddPicLayer()
        {
            InitializeComponent();
            
        }
        #endregion

        #region 重载构造函数
        public A_DPic_AddPicLayer(string strImageName, Image img, A_FrmDCreateConfig frm)
        {
            InitializeComponent();

            if (grap.GetAllFileName().Rows.Count > 0)
            {
                for (int i = 0; i < grap.GetAllFileName().Rows.Count;i++ )
                {
                    trv_PicLayerList.Nodes.Add(grap.GetAllFileName().Rows[i][0].ToString());
                }
            }

            ImageName = strImageName;
            this.picShow.Image = img;

            trv_PicLayerList_GetChecked();

            if (trv_PicLayerList.Nodes.Count != 0)
            {
                txtNewPicLayerName.Text = trv_PicLayerList.Nodes[trv_PicLayerList.Nodes.IndexOf(trv_PicLayerList.SelectedNode)].Text;
            }
            else
            {
                trv_PicLayerList.Nodes.Add("新建图层");
            }


            if (txtNewPicLayerName.Text == string.Empty)
            {
                
                txtNewPicLayerName.Text = "新建图层";
            }

            frmMain = frm;

            

            RootNode = frmMain.ConfigXml.SelectSingleNode("//MapConfig");
            
        }
        #endregion

        #region 上一步的单击事件
        private void btnPreview_Click(object sender, EventArgs e)
        {
            A_DPic_ChooseStation adpic_choose = new A_DPic_ChooseStation(ImageName,picShow.Image,frmMain);
            adpic_choose.Show();
            this.Close();

        }
        #endregion

        #region 删除菜单函数
        private void ContextMenuDel_Click(object sender, EventArgs e)
        {
            trv_PicLayerList.Nodes.Remove(trv_PicLayerList.SelectedNode);

            trv_PicLayerList_GetChecked();

        }
        #endregion

        #region 图层遍历函数
        private void trv_PicLayerList_GetChecked()
        {
            if (trv_PicLayerList.Nodes.Count > 0)
            {
                for (int i = trv_PicLayerList.Nodes.Count - 1; i >= 0; i--)
                {
                    if (i == trv_PicLayerList.Nodes.Count - 1)
                    {
                        trv_PicLayerList.Nodes[i].Checked = true;
                        trv_PicLayerList.SelectedNode = trv_PicLayerList.Nodes[i];
                    }
                    else
                    {
                        trv_PicLayerList.Nodes[i].Checked = false;
                    }
                }
            }
        }
        #endregion

        #region 新增按钮的单击事件
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtNewPicLayerName.Text.Trim() != string.Empty)
            {
                for (int i = 0; i < trv_PicLayerList.Nodes.Count;i++)
                {
                    if (txtNewPicLayerName.Text.Trim() == trv_PicLayerList.Nodes[i].Text)
                    {
                        MessageBox.Show("图层选择列表中已经存在相同的图层名称了!", "提示");
                        return;
                    }
                }

                trv_PicLayerList.Nodes.Add(txtNewPicLayerName.Text.Trim());

                trv_PicLayerList_GetChecked();
            }
        }
        #endregion

        #region 菜单控件中鼠标的右击事件
        private void trv_PicLayerList_MouseDown(object sender, MouseEventArgs e)
        {
            if (trv_PicLayerList.SelectedNode != null)
            {
                foreach (TreeNode tn in trv_PicLayerList.Nodes)
                {
                    tn.Checked = false;
                }

                if (e.Button == MouseButtons.Right)
                {
                    TreeNode node = trv_PicLayerList.GetNodeAt(e.Location);
                    if (node != null)
                    {
                        trv_PicLayerList.SelectedNode = node;
                        contextMenu.Show(trv_PicLayerList.PointToScreen(e.Location));
                    }
                }
                
            }
           
        }
        #endregion

        #region 下一步按钮的点击事件
        private void btnNext_Click(object sender, EventArgs e)
        {
            string strPicLayerName = string.Empty;
            TreeNode TN = null;
            if (trv_PicLayerList.Nodes.Count < 1)
            {
                MessageBox.Show("请先新增一个图层名称!");
            }
            else
            {
                bool IsHaveChecked = false;
                foreach (TreeNode tn in trv_PicLayerList.Nodes)
                {
                    if (tn.Checked)
                    {
                        IsHaveChecked = true;
                        TN=tn;
                        strPicLayerName = tn.Text;
                    }
                }

                if (!IsHaveChecked)
                {
                    MessageBox.Show("请在图层选择列表中选中一个图层名称并打上√");
                    return;
                }
                else
                {
                    XmlNode node = frmMain.ConfigXml.SelectSingleNode("//Map");
                 
                    if (node != null)
                    {
                        if (node.Attributes.Count > 0)
                        {
                            node.InnerText = ImageName;
                            node.Attributes["MinWidth"].Value = "500";
                            node.Attributes["MaxWidth"].Value = "20000";
                        }
                        else
                        {
                            node.InnerText = ImageName;
                            XmlAttribute attribute = frmMain.ConfigXml.CreateAttribute("MinWidth");
                            attribute.Value = "500";
                            node.Attributes.Append(attribute);
                            attribute = frmMain.ConfigXml.CreateAttribute("MaxWidth");
                            attribute.Value = "20000";
                            node.Attributes.Append(attribute);
                            RootNode.AppendChild(node);
                        }

                    }
                    else
                    {
                        XmlNode newnode = ConfigXml.CreateElement("Map");
                        newnode.InnerText = ImageName;
                        XmlAttribute attribute = frmMain.ConfigXml.CreateAttribute("MinWidth");
                        attribute.Value = "500";
                        newnode.Attributes.Append(attribute);
                        attribute = frmMain.ConfigXml.CreateAttribute("MaxWidth");
                        attribute.Value = "20000";
                        newnode.Attributes.Append(attribute);
                        RootNode.AppendChild(newnode);
                    }

                    ConfigXml = frmMain.ConfigXml;
                    frmMain.FileName = TN.Text;
                   


                    A_DPic_RouteConfig route = new A_DPic_RouteConfig(ImageName, frmMain, strPicLayerName,TN,trv_PicLayerList,picShow.Image);

                    route.Show();

                    this.Close();

                }

            }

        }
        #endregion

        #region 列表框的选中后事件
        private void trv_PicLayerList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Checked = true;
        }
        #endregion

        #region 列表框的勾选事件
        private void trv_PicLayerList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            txtNewPicLayerName.Text = e.Node.Text;
        }
        #endregion

        private void txtNewPicLayerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }


    }
}
