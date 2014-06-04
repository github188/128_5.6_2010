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
using System.Drawing.Imaging;
using Wilson.Controls.Docking;

namespace KJ128NMainRun.Graphics.Config
{
    public partial class A_FrmCreateConfig : Wilson.Controls.Docking.DockContent
    {
        private A_GraphicsBLL bll = new A_GraphicsBLL();
        private bool IsOut = false;
        private TreeNode LastSelectNode = null;
        private string MapFilePath = string.Empty;
        private XmlDocument ConfigXml = null;
        private XmlNode RootNode = null;
        private bool isSaveed = true;
        private Graphics_ConfigFileBLL gcfb = new Graphics_ConfigFileBLL();
        private Wilson.Controls.Docking.DockPanel dp;

        public A_FrmCreateConfig()
        {
            InitializeComponent();
        }

        public A_FrmCreateConfig(Wilson.Controls.Docking.DockPanel dock)
        {
            InitializeComponent();
            this.dp = dock;
        }

        private void FrmCreateConfig_Load(object sender, EventArgs e)
        {
            CreateDir();
            label2.SendToBack();
            //pnlInOut.Visible = false;
            InitConfigXml();
            MapGis.UseDiv = true;
            DataTable dt = bll.GetBackMap();
            string SafeFileName = dt.Rows[0][0].ToString();
            byte[] buffer = (byte[])dt.Rows[0][1];
            SaveBackMap(SafeFileName, buffer);
            this.picMap.Image = CreateBitMap(Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName);
            this.MapFilePath = Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName;
            XmlNode node = ConfigXml.SelectSingleNode("//Map");
            if (node != null)
            {
                node.InnerText = "\\MapGis\\Map\\" + SafeFileName;
            }
            else
            {
                XmlNode newnode = ConfigXml.CreateElement("Map");
                newnode.InnerText = "\\MapGis\\Map\\" + SafeFileName;
                RootNode.AppendChild(newnode);
            }
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
        //    if (IsOut)
        //    {
        //        this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.right;
        //        this.pnlInOut.Left = this.pnlInOut.Left - picInOut.Left;
        //        IsOut = false;
        //    }
        //    else
        //    {
        //        this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.left;
        //        this.pnlInOut.Left = this.pnlInOut.Left + picInOut.Left;
        //        IsOut = true;
        //    }
        }

        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ntbMin.Text == "" || ntbMax.Text == "")
            {
                MessageBox.Show("地图显示范围尚未配置", "提示", MessageBoxButtons.OK);
                return;
            }
            if (this.MapFilePath == "")
            {
                MessageBox.Show("地图路径尚未配置", "提示", MessageBoxButtons.OK);
                return;
            }
            CheckReName("新建图层");
            this.isSaveed = false;
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
            A_frmDivConfig f = new A_frmDivConfig(LastSelectNode, double.Parse(ntbMin.Text), double.Parse(ntbMax.Text), this.MapFilePath.Substring(MapFilePath.LastIndexOf("\\MapGis")), ConfigXml, trvDiv, this);
            f.Show(dp, DockState.Document);
        }

        //private Image CreateBitMap(string filepath)
        //{
        //    Stream stream = new FileStream(filepath, FileMode.Open);
        //    byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
        //    stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
        //    stream.Close();
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
        //    return Image.FromStream(ms);
        //}

        private void btnMapSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath + "\\MapGis\\Map";
            ofd.Filter = "所有图片文件(*.wmf;*.bmp;*.gif;*.jpg)|*.wmf;*.bmp;*.gif;*.jpg|图元(*.wmf)|*.wmf|位图(*.bmp)|*.bmp|动态图片(*.gif)|*.gif|静态图片(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string SafeFileName = ofd.FileName.Substring(ofd.FileName.LastIndexOf("\\") + 1);
                if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\Map"))
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\Map");
                if (System.IO.File.Exists(Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName))
                {
                    if ((Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName) != ofd.FileName)
                    {
                        if (MessageBox.Show("文件已经存在,是否替换？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            System.IO.File.Delete(Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName);
                            System.IO.File.Copy(ofd.FileName, Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName);
                        }
                    }
                }
                else
                {
                    System.IO.File.Copy(ofd.FileName, Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName);
                }
                try
                {
                    this.picMap.Image =this.CreateBitMap(Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName);
                    this.MapFilePath = Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName;
                    XmlNode node = ConfigXml.SelectSingleNode("//Map");
                    if (node != null)
                    {
                        node.InnerText = "\\MapGis\\Map\\" + SafeFileName;
                    }
                    else
                    {
                        XmlNode newnode = ConfigXml.CreateElement("Map");
                        newnode.InnerText = "\\MapGis\\Map\\" + SafeFileName;
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
                frmFileDialog f = new frmFileDialog();
                //f.InitialDirectory = Application.StartupPath + "\\MapGis\\MapConfigFiles";
                //f.DefaultExt = "shz";
                //f.Filter = "三恒科技图形系统配置文件|*.shz";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    //ConfigXml.Save(f.FileName);
                    string filename = f.SafeFileName;
                    byte[] xmlbytes = new FileChanger().XmlToBytes(ConfigXml);
                    XmlNode MapNode = ConfigXml.SelectSingleNode("//Map");
                    if (!System.IO.File.Exists(Application.StartupPath + MapNode.InnerText))
                    {
                        MessageBox.Show("底图尚未选择或您选择的底图不正确!", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    byte[] imgbytes = new FileChanger().ImageToBytes(Application.StartupPath + MapNode.InnerText);
                    if(gcfb.ExitsFile(filename))
                        gcfb.UpdateFile(filename, xmlbytes, imgbytes);
                    else
                        gcfb.AddFile(filename, xmlbytes, imgbytes);
                    this.isSaveed = true;
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
            frmFileDialog openfileDlg = new frmFileDialog(false);
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
                if (gcfb.ExitsFile(openfileDlg.SafeFileName))
                {
                    DataTable bufferdt = gcfb.GetXmlAndMapByFileName(openfileDlg.SafeFileName);
                    byte[] xmlbytes = (byte[])bufferdt.Rows[0][0];
                    byte[] mapbytes = (byte[])bufferdt.Rows[0][1];
                    FileChanger filechanger = new FileChanger();
                    ConfigXml = filechanger.BytesToXml(xmlbytes);
                    LoadMapConfig(filechanger.BytesToXml(xmlbytes), mapbytes);
                    this.isSaveed = false;
                }
                else
                {
                    MessageBox.Show("您所选择的文件不存在!", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void CreateFile(string filepath, byte[] filebyte)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate);
            fs.Write(filebyte, 0, filebyte.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        private void LoadMapConfig(XmlDocument configXml,byte[] imgBytes)
        {
            this.ClearControls();
            MapGis.ReSet();
            MapGis.Refresh();
            XmlNode MapNode = configXml.SelectSingleNode("//Map");
            //map.Save(Application.StartupPath + MapNode.InnerText, System.Drawing.Imaging.ImageFormat.Wmf);
            try
            {
                string filename = MapNode.InnerText.Substring(MapNode.InnerText.LastIndexOf("\\")+1);
                byte[] buffer = bll.GetBackMapByFileName(filename);
                if (buffer != null)
                {
                    CreateFile(Application.StartupPath + MapNode.InnerText, buffer);
                }
                else
                {
                    MessageBox.Show(",该配置文件已经过时...", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("读取图形系统配置文件发生错误,可能配置文件未完成或已损坏!", "提示", MessageBoxButtons.OK);
            }
            if (MapNode != null)
            {
                this.MapFilePath = MapNode.InnerText;
                try
                {
                    picMap.Image = CreateBitMap(Application.StartupPath + MapNode.InnerText);
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
            MapFilePath = string.Empty;
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
            MapFilePath = string.Empty;
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
            MapFilePath = string.Empty;
            this.picMap.Image = null;
            this.ntbMax.Text = string.Empty;
            this.ntbMin.Text = string.Empty;
            this.trvDiv.Nodes.Clear();
            if(IsOut)
            {
                this.picInOut_Click(this, new EventArgs());
            }
            //this.pnlInOut.Visible = false;
            DataTable dt = bll.GetBackMap();
            string SafeFileName = dt.Rows[0][0].ToString();
            byte[] buffer = (byte[])dt.Rows[0][1];
            SaveBackMap(SafeFileName, buffer);
            this.picMap.Image = CreateBitMap(Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName);
            this.MapFilePath = Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName;
            XmlNode node = ConfigXml.SelectSingleNode("//Map");
            if (node != null)
            {
                node.InnerText = "\\MapGis\\Map\\" + SafeFileName;
            }
            else
            {
                XmlNode newnode = ConfigXml.CreateElement("Map");
                newnode.InnerText = "\\MapGis\\Map\\" + SafeFileName;
                RootNode.AppendChild(newnode);
            }
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
            this.ntbMax_Leave(this, new EventArgs());
        }

        private bool SaveBackMap(string safefilename, byte[] buffer)
        {
            try
            {
                if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\Map"))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\Map");
                }
                string filepath = Application.StartupPath + "\\MapGis\\Map\\" + safefilename;
                System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate);
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 创建底图的Image实例
        /// </summary>
        /// <param name="filepath">底图图片路径</param>
        /// <returns>返回创建好的底图实例</returns>
        private Image CreateBitMap(string filepath)
        {
            try
            {
                Metafile bitmap = new Metafile(filepath);
                return bitmap;
            }
            catch (System.Exception ex)
            {
                Image image = NewBitMap(filepath);
                return image;
            }
        }

        private Image NewBitMap(string filepath)
        {
            Stream stream = new FileStream(filepath, FileMode.Open);
            byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            stream.Close();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            return Image.FromStream(ms);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            tsmiOpen_Click(this, new EventArgs());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            tsmiClose_Click(this, new EventArgs());
        }

        private void ntbMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void ntbMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

    }
}
