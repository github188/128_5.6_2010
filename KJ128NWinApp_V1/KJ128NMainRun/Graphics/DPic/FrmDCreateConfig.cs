using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using KJ128NDBTable;
using System.IO;
using KJ128NMainRun.Graphics.Config;

namespace KJ128NMainRun.Graphics.DPic
{
    public partial class FrmDCreateConfig : Wilson.Controls.Docking.DockContent
    {
        private bool IsOut = false;
        private TreeNode LastSelectNode = null;
        //private string MapFilePath = string.Empty;
        private string FileID = string.Empty;
        private bool MapConfiged = false;
        private XmlDocument ConfigXml = null;
        private XmlNode RootNode = null;
        private bool isSaveed = true;
        private Graphics_ConfigFileBLL gcfb = new Graphics_ConfigFileBLL();
        private Graphics_DpicBLL dpicbll = new Graphics_DpicBLL();

        public FrmDCreateConfig()
        {
            InitializeComponent();
        }

        private void FrmCreateConfig_Load(object sender, EventArgs e)
        {
            CreateDir();
            pnlInOut.Visible = false;
            InitConfigXml();
            MapGis.UseDiv = true;
        }

        private void CreateDir()
        {
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\Map"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\Map");
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\MapConfigFiles"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\MapConfigFiles");
        }

        private void InitConfigXml()
        {
            ConfigXml = new XmlDocument();
            XmlDeclaration decl = ConfigXml.CreateXmlDeclaration("1.0", "GBK", "yes");
            ConfigXml.AppendChild(decl);
            XmlDocumentType doctype = ConfigXml.CreateDocumentType("root", null, null, "<!ELEMENT Station ANY><!ATTLIST Station SSN ID #REQUIRED>");
            ConfigXml.AppendChild(doctype);
            RootNode = ConfigXml.CreateElement("MapConfig");
            ConfigXml.AppendChild(RootNode);
            XmlNode node = ConfigXml.CreateElement("Map");
            RootNode.AppendChild(node);
            node = ConfigXml.CreateElement("Divs");
            RootNode.AppendChild(node);
            node = ConfigXml.CreateElement("Statics");
            RootNode.AppendChild(node);
            node = ConfigXml.CreateElement("Stations");
            RootNode.AppendChild(node);
            node = ConfigXml.CreateElement("Words");
            RootNode.AppendChild(node);
        }

        private void picInOut_Click(object sender, EventArgs e)
        {
            if (IsOut)
            {
                this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.right;
                this.pnlInOut.Left = this.pnlInOut.Left - picInOut.Left;
                IsOut = false;
            }
            else
            {
                this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.left;
                this.pnlInOut.Left = this.pnlInOut.Left + picInOut.Left;
                IsOut = true;
            }
        }

        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ntbMin.Text == "" || ntbMax.Text == "")
            {
                MessageBox.Show("地图显示范围尚未配置", "提示", MessageBoxButtons.OK);
                return;
            }
            if (!this.MapConfiged)
            {
                MessageBox.Show("地图路径尚未配置", "提示", MessageBoxButtons.OK);
                return;
            }
            CheckReName("新建图层");
        }

        private void CheckReName(string name)
        {
            if (trvDiv.Nodes.ContainsKey(name))
            {
                CheckReName(1, name);
            }
            else
            {
                trvDiv.Nodes.Add(name, name);
            }
        }

        private void CheckReName(int nameid, string name)
        {
            if (trvDiv.Nodes.ContainsKey(name + nameid.ToString()))
            {
                nameid++;
                CheckReName(nameid, name);
            }
            else
            {
                trvDiv.Nodes.Add(name + nameid.ToString(), name + nameid.ToString());
            }
        }

        private void trvDiv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                trvDiv.SelectedNode = trvDiv.GetNodeAt(e.Location);
                if (trvDiv.SelectedNode!=null)
                    cmsDiv.Show(trvDiv, e.Location);
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            this.LastSelectNode = trvDiv.SelectedNode;
            frmDDivConfig f = new frmDDivConfig(LastSelectNode,double.Parse(ntbMin.Text),double.Parse(ntbMax.Text),ConfigXml,trvDiv);
            f.Show();
        }

        private Image CreateBitMap(string filepath)
        {
            Stream stream = new FileStream(filepath, FileMode.Open);
            byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            stream.Close();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            return Image.FromStream(ms);
        }

        private void btnMapSelect_Click(object sender, EventArgs e)
        {
            frmDpicDialog ofd = new frmDpicDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = dpicbll.GetBackPicByFileID(ofd.FileID);
                try
                {
                    this.picMap.Image = this.BytesToImage((byte[])dt.Rows[0][0]);
                    //this.MapFilePath = Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName;
                    this.FileID = ofd.FileID;
                    this.MapConfiged = true;
                    XmlNode node = ConfigXml.SelectSingleNode("//Map");
                    if (node != null)
                    {
                        node.InnerText = ofd.FileID;
                    }
                    else
                    {
                        XmlNode newnode = ConfigXml.CreateElement("Map");
                        newnode.InnerText = ofd.FileID;
                        RootNode.AppendChild(newnode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法识别的图片!", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void ntbMin_Leave(object sender, EventArgs e)
        {
            if (ntbMin.Text != "" && ntbMax.Text != "")
            {
                try
                {
                    if (double.Parse(ntbMin.Text) > double.Parse(ntbMax.Text))
                    {
                        MessageBox.Show("最小值不能大于最大值!", "提示", MessageBoxButtons.OK);
                    }
                    else
                    {
                        XmlNode node = ConfigXml.SelectSingleNode("//Map");
                        if (node != null)
                        {
                            node.Attributes["MinWidth"].Value = ntbMin.Text;
                            node.Attributes["MaxWidth"].Value = ntbMax.Text;
                        }
                        else
                        {
                            XmlNode newnode = ConfigXml.CreateElement("Map");
                            XmlAttribute attribute = ConfigXml.CreateAttribute("MinWidth");
                            attribute.Value = ntbMin.Text;
                            newnode.Attributes.Append(attribute);
                            attribute = ConfigXml.CreateAttribute("MaxWidth");
                            attribute.Value = ntbMax.Text;
                            newnode.Attributes.Append(attribute);
                            RootNode.AppendChild(newnode);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("最大最小值中存在错误!", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void ntbMax_Leave(object sender, EventArgs e)
        {
            if (ntbMin.Text != "" && ntbMax.Text != "")
            {
                try
                {
                    if (double.Parse(ntbMin.Text) > double.Parse(ntbMax.Text))
                    {
                        MessageBox.Show("最小值不能大于最大值!", "提示", MessageBoxButtons.OK);
                    }
                    else
                    {
                        XmlNode node = ConfigXml.SelectSingleNode("//Map");
                        if (node != null)
                        {
                            if (node.Attributes.Count > 0)
                            {
                                node.Attributes["MinWidth"].InnerText = ntbMin.Text;
                                node.Attributes["MaxWidth"].InnerText = ntbMax.Text;
                            }
                            else
                            {
                                XmlAttribute attribute = ConfigXml.CreateAttribute("MinWidth");
                                attribute.InnerText = ntbMin.Text;
                                node.Attributes.Append(attribute);
                                attribute = ConfigXml.CreateAttribute("MaxWidth");
                                attribute.InnerText = ntbMax.Text;
                                node.Attributes.Append(attribute);
                            }
                        }
                        else
                        {
                            XmlNode newnode = ConfigXml.CreateElement("Map");
                            XmlAttribute attribute = ConfigXml.CreateAttribute("MinWidth");
                            attribute.InnerText = ntbMin.Text;
                            newnode.Attributes.Append(attribute);
                            attribute = ConfigXml.CreateAttribute("MaxWidth");
                            attribute.InnerText = ntbMax.Text;
                            newnode.Attributes.Append(attribute);
                            RootNode.AppendChild(newnode);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("最大最小值中存在错误!", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void lklLoadMap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MapGis.ClearAllStation();
            MapGis.ClearAllStatic();
            new MapXml().LoadAllMapConfig(ConfigXml, MapGis);
            if (IsOut)
            {
                this.picInOut_Click(this, new EventArgs());
            }
        }

        private void lnkSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isSaveed == false)
            {
                if (MapConfiged)
                {
                    frmDFileDialog f = new frmDFileDialog();
                    //f.InitialDirectory = Application.StartupPath + "\\MapGis\\MapConfigFiles";
                    //f.DefaultExt = "shz";
                    //f.Filter = "三恒科技图形系统配置文件|*.shz";
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        //ConfigXml.Save(f.FileName);
                        string filename = f.SafeFileName;
                        byte[] xmlbytes = new FileChanger().XmlToBytes(ConfigXml);
                        if (dpicbll.ExitsFileName(filename))
                            dpicbll.UpdateFile(filename, xmlbytes, FileID);
                        else
                            dpicbll.AddFile(filename, xmlbytes, FileID);
                        this.isSaveed = true;
                    }
                }
                else
                {
                    MessageBox.Show("底图尚未配置!", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void tsmDel_Click(object sender, EventArgs e)
        {
            XmlNode DivRootNode = ConfigXml.SelectSingleNode("//Divs");
            foreach (XmlNode Node in DivRootNode.ChildNodes)
            {
                if (Node.InnerText == trvDiv.SelectedNode.Text)
                {
                    DivRootNode.RemoveChild(Node);
                    XmlNode StaticRoot = ConfigXml.SelectSingleNode("//Statics");
                    if (StaticRoot != null && StaticRoot.ChildNodes.Count > 0)
                    {
                        foreach (XmlNode staticnode in StaticRoot.ChildNodes)
                        {
                            if (staticnode.ChildNodes[0].InnerText.Contains(Node.InnerText + "|"))
                            {
                                staticnode.ChildNodes[0].InnerText = staticnode.ChildNodes[0].InnerText.Replace(Node.InnerText + "|", string.Empty);
                            }
                        }
                    }
                    XmlNode StationRoot = ConfigXml.SelectSingleNode("//Stations");
                    if (StationRoot != null && StationRoot.ChildNodes.Count > 0)
                    {
                        foreach (XmlNode stationnode in StationRoot.ChildNodes)
                        {
                            if (stationnode.InnerText.Contains(Node.InnerText + "|"))
                            {
                                stationnode.InnerText = stationnode.InnerText.Replace(Node.InnerText + "|", string.Empty);
                            }
                        }
                    }
                }
            }
            trvDiv.Nodes.Remove(trvDiv.SelectedNode);
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            frmDFileDialog openfileDlg = new frmDFileDialog(false);
            //openfileDlg.Multiselect = false;
            //openfileDlg.InitialDirectory = Application.StartupPath + "\\MapGis\\MapConfigFiles";
            //openfileDlg.Filter = "三恒科技图形系统文件|*.shz";
            if (openfileDlg.ShowDialog() == DialogResult.OK)
            {
                pnlInOut.Visible = true;
                if (!IsOut)
                {
                    this.picInOut_Click(this, new EventArgs());
                }
                if (dpicbll.ExitsFileName(openfileDlg.SafeFileName))
                {
                    DataTable bufferdt = dpicbll.GetXmlByFileName(openfileDlg.SafeFileName);
                    byte[] xmlbytes = (byte[])bufferdt.Rows[0][0];
                    FileChanger filechanger = new FileChanger();
                    ConfigXml = filechanger.BytesToXml(xmlbytes);
                    LoadMapConfig(filechanger.BytesToXml(xmlbytes));
                    this.isSaveed = false;
                }
                else
                {
                    MessageBox.Show("您所选择的文件不存在!", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private Image BytesToImage(byte[] buffer)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            return Image.FromStream(ms);
        }

        private void CreateFile(string filepath, byte[] filebyte)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate);
            fs.Write(filebyte, 0, filebyte.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        private void LoadMapConfig(XmlDocument configXml)
        {
            this.ClearControls();
            MapGis.ReSet();
            MapGis.Refresh();
            XmlNode MapNode = configXml.SelectSingleNode("//Map");
            Image img = null;
            //map.Save(Application.StartupPath + MapNode.InnerText, System.Drawing.Imaging.ImageFormat.Wmf);
            try
            {
                //CreateFile(Application.StartupPath + MapNode.InnerText, imgBytes);
                DataTable dt = dpicbll.GetBackPicByFileID(MapNode.InnerText);
                img = this.BytesToImage((byte[])dt.Rows[0][0]);
            }
            catch(Exception ex)
            {
                MessageBox.Show("读取图形系统配置文件发生错误,可能配置文件未完成或已损坏!", "提示", MessageBoxButtons.OK);
            }
            if (MapNode != null)
            {
                try
                {
                    picMap.Image = img;
                    this.FileID=MapNode.InnerText;
                    this.MapConfiged = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("图形系统中部分图片已经不存在", "提示", MessageBoxButtons.OK);
                }
                for (int i = 0; i < MapNode.Attributes.Count; i++)
                {
                    if (i == 0)
                        ntbMin.Text = MapNode.Attributes[i].InnerText;
                    if (i == 1)
                        ntbMax.Text = MapNode.Attributes[i].InnerText;
                }
            }
            XmlNode DivRoot = configXml.SelectSingleNode("//Divs");
            if (DivRoot != null)
            {
                if (DivRoot.ChildNodes.Count > 0)
                {
                    foreach (XmlNode node in DivRoot.ChildNodes)
                    {
                        trvDiv.Nodes.Add(node.InnerText, node.InnerText);
                    }
                }
            }
        }

        private void ClearControls()
        {
            this.isSaveed = false;
            MapGis.ReSet();
            MapGis.Refresh();
            //InitConfigXml();
            LastSelectNode = null;
            MapConfiged = false;
            this.picMap.Image = null;
            this.ntbMax.Text = string.Empty;
            this.ntbMin.Text = string.Empty;
            this.trvDiv.Nodes.Clear();
            pnlInOut.Visible = true;
            if (!IsOut)
            {
                this.picInOut_Click(this, new EventArgs());
            }      
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            this.isSaveed = false;
            MapGis.ReSet();
            MapGis.Refresh();
            InitConfigXml();
            LastSelectNode = null;
            MapConfiged = false;
            this.picMap.Image = null;
            this.ntbMax.Text = string.Empty;
            this.ntbMin.Text = string.Empty;
            this.trvDiv.Nodes.Clear();
            pnlInOut.Visible = true;
            if (!IsOut)
            {
                this.picInOut_Click(this, new EventArgs());
            }            
        }

        private void FrmCreateConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaveed)
            {
                DialogResult result = MessageBox.Show("是否需要保存该图形系统文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.lnkSave_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lnkSave.Links[0]));
                }
            }
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            if (!isSaveed)
            {
                DialogResult result = MessageBox.Show("是否需要保存该图形系统文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.lnkSave_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lnkSave.Links[0]));
                }
            }
            isSaveed = true;
            MapGis.ReSet();
            MapGis.Refresh();
            InitConfigXml();
            LastSelectNode = null;
            MapConfiged = false;
            this.picMap.Image = null;
            this.ntbMax.Text = string.Empty;
            this.ntbMin.Text = string.Empty;
            this.trvDiv.Nodes.Clear();
            if(IsOut)
            {
                this.picInOut_Click(this, new EventArgs());
            }
            this.pnlInOut.Visible = false;
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            this.lnkSave_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lnkSave.Links[0]));
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.lnkSave_LinkClicked(this, new LinkLabelLinkClickedEventArgs(this.lnkSave.Links[0]));
        }

        private void btnMoni_Click(object sender, EventArgs e)
        {
            this.lklLoadMap_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lklLoadMap.Links[0]));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.lnkNew_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lnkNew.Links[0]));
        }


    }
}
