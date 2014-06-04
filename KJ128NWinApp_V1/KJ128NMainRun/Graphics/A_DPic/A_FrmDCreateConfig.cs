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
using Wilson.Controls.Docking;

namespace KJ128NMainRun.Graphics.DPic
{
    public partial class A_FrmDCreateConfig : Wilson.Controls.Docking.DockContent
    {
        private bool IsOut = false;
        private TreeNode LastSelectNode = null;
        //private string MapFilePath = string.Empty;
        private string FileID = string.Empty;
        private bool MapConfiged = false;
        private XmlDocument ConfigXml = null;
        private XmlNode RootNode = null;
        public bool isSaveed = true;
        private Graphics_ConfigFileBLL gcfb = new Graphics_ConfigFileBLL();
        private Graphics_DpicBLL dpicbll = new Graphics_DpicBLL();
        private List<Panel> pnlList = new List<Panel>();
        private Button FirstButton = null;
        private DataTable DivDt = new DataTable();
        private DockPanel Dockpanel=null;
        private string NowFileName = string.Empty;

        public A_FrmDCreateConfig()
        {
            InitializeComponent();
        }

        public A_FrmDCreateConfig(DockPanel dockpanel)
        {
            InitializeComponent();
            Dockpanel = dockpanel;
        }

        private void FrmCreateConfig_Load(object sender, EventArgs e)
        {            
            CreateDir();
            CreatePnls();
            //pnlInOut.Visible = false;
            InitConfigXml();
            MapGis.UseDiv = true;
            MapGis.UseGif = false;
            //isSaveed = true;
            //btn_Click(FirstButton, new EventArgs());
        }

        private void CreateDir()
        {
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\Map"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\Map");
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\MapConfigFiles"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\MapConfigFiles");
        }

        private void CreatePnls()
        {
            DataTable dt = dpicbll.GetAllFileName();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Panel pnl = new Panel();
                Button btn = new Button();
                DataGridView dgv = new DataGridView();
                pnl.Controls.Add(btn);
                pnl.Controls.Add(dgv);
                pnl.Name = "pnl" + i.ToString();
                pnl.Height = 200;
                btn.Dock = System.Windows.Forms.DockStyle.Top;
                btn.Location = new System.Drawing.Point(0, 0);
                btn.Size = new System.Drawing.Size(167, 25);
                btn.UseVisualStyleBackColor = true;
                btn.Text = dt.Rows[i][0].ToString();
                dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv.AllowUserToResizeColumns = false;
                dgv.ColumnHeadersHeight = 25;
                dgv.RowHeadersVisible = false;
                dgv.ReadOnly = true;
                dgv.Dock = System.Windows.Forms.DockStyle.Fill;
                dgv.Location = new System.Drawing.Point(0, 26);
                dgv.RowTemplate.Height = 23;
                dgv.Size = new System.Drawing.Size(200, 200);
                dgv.Columns.Clear();
                DataGridViewCheckBoxColumn Column1 = new DataGridViewCheckBoxColumn();
                Column1.FalseValue = "false";
                Column1.HeaderText = "";
                Column1.Name = "Column1";
                Column1.TrueValue = "true";
                Column1.Width = 50;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToResizeRows = false;
                dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                Column1});
                dgv.Location = new System.Drawing.Point(0, 0);
                //dgv.ReadOnly = true;
                dgv.RowTemplate.Height = 23;
                dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                dgv.RowHeadersVisible = false;
                dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
                dgv.CellMouseDown += new DataGridViewCellMouseEventHandler(dgv_CellMouseDown);
                dgv.MouseDown += new MouseEventHandler(dgv_MouseDown);
                dgv.DataError+=new DataGridViewDataErrorEventHandler(dgv_DataError);
                btn.Click += new EventHandler(btn_Click);
                btn.MouseDown += new MouseEventHandler(btn_MouseDown);
                if (i == 0)
                {
                    dmc.Add(pnl, true);
                    this.FirstButton = btn;
                    OpenFile(btn.Text, dgv);
                }
                else
                {
                    dmc.Add(pnl);
                }
                pnlList.Add(pnl);
            }
            dmc.LeftPartResize();
            MapGis.FlashAll();
        }

        private void CreatePnlsFalse()
        {
            DataTable dt = dpicbll.GetAllFileName();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Panel pnl = new Panel();
                Button btn = new Button();
                DataGridView dgv = new DataGridView();
                pnl.Controls.Add(btn);
                pnl.Controls.Add(dgv);
                pnl.Name = "pnl" + i.ToString();
                pnl.Height = 200;
                btn.Dock = System.Windows.Forms.DockStyle.Top;
                btn.Location = new System.Drawing.Point(0, 0);
                btn.Size = new System.Drawing.Size(167, 25);
                btn.UseVisualStyleBackColor = true;
                btn.Text = dt.Rows[i][0].ToString();
                dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv.AllowUserToResizeColumns = false;
                dgv.ColumnHeadersHeight = 25;
                dgv.RowHeadersVisible = false;
                dgv.ReadOnly = true;
                dgv.Dock = System.Windows.Forms.DockStyle.Fill;
                dgv.Location = new System.Drawing.Point(0, 26);
                dgv.RowTemplate.Height = 23;
                dgv.Size = new System.Drawing.Size(200, 200);
                dgv.Columns.Clear();
                DataGridViewCheckBoxColumn Column1 = new DataGridViewCheckBoxColumn();
                Column1.FalseValue = "false";
                Column1.HeaderText = "";
                Column1.Name = "Column1";
                Column1.TrueValue = "true";
                Column1.Width = 50;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToResizeRows = false;
                dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                Column1});
                dgv.Location = new System.Drawing.Point(0, 0);
                //dgv.ReadOnly = true;
                dgv.RowTemplate.Height = 23;
                dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                dgv.RowHeadersVisible = false;
                dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
                dgv.CellMouseDown += new DataGridViewCellMouseEventHandler(dgv_CellMouseDown);
                dgv.MouseDown += new MouseEventHandler(dgv_MouseDown);
                dgv.DataError+=new DataGridViewDataErrorEventHandler(dgv_DataError);
                btn.Click += new EventHandler(btn_Click);
                btn.MouseDown += new MouseEventHandler(btn_MouseDown);
                dmc.Add(pnl);
                pnlList.Add(pnl);
            }
            dmc.LeftPartResize();
            MapGis.FlashAll();
        }

        private Button DelButton = null;
        void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsConfig.Show(((Button)sender).PointToScreen(e.Location));
                this.DelButton = (Button)sender;
            }
        }

        void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    btnMoni_Click(this, new EventArgs());
                    DataGridView dgv = (DataGridView)sender;
                    if (((DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[0]).TrueValue)
                    {
                        ((DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[0]).FalseValue;
                        //MapGis.FilterDivList.Add(dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
                        //MapGis.Refresh();
                    }
                    else
                    {
                        ((DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[0]).TrueValue;
                        //MapGis.FilterDivList.Remove(dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
                        //MapGis.Refresh();
                    }
                    //btnMoni_Click(this, new EventArgs());
                    MapGis.FilterDivList.Clear();
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).FalseValue)
                        {
                            MapGis.FilterDivList.Add(dgv.Rows[i].Cells[1].Value.ToString());
                        }
                        if (((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).TrueValue)
                        {
                            MapGis.FilterDivList.Remove(dgv.Rows[i].Cells[1].Value.ToString());
                        }
                    }
                    MapGis.FlashAll();
                }
            }
            catch (Exception ex)
            { }
        }

        void btn_Click(object sender, EventArgs e)
        {
            try
            {
                trvDiv.Nodes.Clear();
                dmc.ButtonClick(((Button)sender).Parent.Name);
                if (dpicbll.ExitsFileName(((Button)sender).Text))
                {
                    tsmiClose_Click(this, new EventArgs());
                    OpenFile(((Button)sender).Text, (DataGridView)((Button)sender).Parent.Controls[1]);
                    this.NowBtn = (Button)sender;
                    this.NowDgv = (DataGridView)((Button)sender).Parent.Controls[1];
                    ReFlashDivDt();
                    this.NowDgv.DataSource = DivDt;
                    for (int i = 0; i < NowDgv.Rows.Count; i++)
                    {
                        ((DataGridViewCheckBoxCell)NowDgv.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)NowDgv.Rows[i].Cells[0]).TrueValue;
                    }
                    this.NowFileName = ((Button)sender).Text;
                }
                else
                {
                    this.NowBtn = (Button)sender;
                    this.NowDgv = (DataGridView)((Button)sender).Parent.Controls[1];
                    ReFlashDivDt();
                    InitConfigXml();
                    ntbMin.Text = txtMin.Text;
                    ntbMax.Text = txtMax.Text;
                    XmlNode node = ConfigXml.SelectSingleNode("//Map");
                    if (node != null)
                    {
                        if (node.Attributes.Count > 0)
                        {
                            node.Attributes["MinWidth"].Value = txtMin.Text;
                            node.Attributes["MaxWidth"].Value = txtMax.Text;
                        }
                        else
                        {
                            XmlAttribute attribute = ConfigXml.CreateAttribute("MinWidth");
                            attribute.Value = txtMin.Text;
                            node.Attributes.Append(attribute);
                            attribute = ConfigXml.CreateAttribute("MaxWidth");
                            attribute.Value = txtMax.Text;
                            node.Attributes.Append(attribute);
                        }
                    }
                    else
                    {
                        XmlNode newnode = ConfigXml.CreateElement("Map");
                        XmlAttribute attribute = ConfigXml.CreateAttribute("MinWidth");
                        attribute.Value = txtMin.Text;
                        newnode.Attributes.Append(attribute);
                        attribute = ConfigXml.CreateAttribute("MaxWidth");
                        attribute.Value = txtMax.Text;
                        newnode.Attributes.Append(attribute);
                        RootNode.AppendChild(newnode);
                    }
                    MapGis.ClearAllStatic();
                    MapGis.ClearAllStation();
                    MapGis.FilterDivList.Clear();
                    MapGis.ClearMap();
                    MapGis.FlashAll();
                }
            }
            catch (Exception ex)
            { 
                
            }
        }

        private void OpenFile(string filename, DataGridView dgv)
        {
            //frmFileDialog openfileDlg = new frmFileDialog(false);
            //if (openfileDlg.ShowDialog() == DialogResult.OK)
            //{
            //this.MapGis.UseDiv = true;
            //this.MapGis.ReSet();
            //XmlDocument xmldoc = new XmlDocument();
            //DataTable bufferdt = dpicbll.GetXmlByFileName(filename);
            //if (bufferdt.Rows.Count > 0)
            //{
            //    byte[] xmlbytes = (byte[])bufferdt.Rows[0][0];
            //    FileChanger filechanger = new FileChanger();
            //    xmldoc = filechanger.BytesToXml(xmlbytes);
            //    XmlNode node = xmldoc.SelectSingleNode("//Map");
            //    this.FileID = node.InnerText;
            //    //if (node != null)
            //    //{
            //    //    try
            //    //    {
            //    //        CreateWmf(mapbytes, Application.StartupPath + node.InnerText);
            //    //    }
            //    //    catch (Exception ex)
            //    //    {
            //    //        MessageBox.Show("读取图形系统配置文件发生错误,可能配置文件未完成或已损坏!", "提示", MessageBoxButtons.OK);
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    MessageBox.Show("读取图形系统配置文件发生错误,可能配置文件未完成或已损坏!", "提示", MessageBoxButtons.OK);
            //    //}
            //    if (!new MapXml().LoadAllMapConfig(xmldoc, MapGis))
            //    {
            //        //pnlInOut.Visible = true;
            //        //SetMenuEnabel(false);
            //        MapGis.Refresh();
            //        return;
            //    }
            //}
            //}
            //else
            //{
            //    return;
            //}
            ////this.MapGis.StationClick += new ZzhaControlLibrary.ZzhaMapGis.ClickStation(MapGis_StationClick);
            //StartTimer();
            //IsOut = true;
            //LoadRealTimeInfo();
            //IsOut = false;
            //pnlInOut.Visible = true;
            //SetMenuEnabel(true);
            if (dpicbll.ExitsFileName(filename))
            {
                DataTable bufferdt = dpicbll.GetXmlByFileName(filename);
                byte[] xmlbytes = (byte[])bufferdt.Rows[0][0];
                FileChanger filechanger = new FileChanger();
                ConfigXml = filechanger.BytesToXml(xmlbytes);
                LoadMapConfig(filechanger.BytesToXml(xmlbytes));
                //this.isSaveed = false;
            }
            else
            {
                MessageBox.Show("打开文件时发生错误...", "提示", MessageBoxButtons.OK);
            }
            btnMoni_Click(this, new EventArgs());
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).FalseValue)
                {
                    MapGis.FilterDivList.Add(dgv.Rows[i].Cells[1].Value.ToString());
                }
                if (((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgv.Rows[i].Cells[0]).TrueValue)
                {
                    MapGis.FilterDivList.Remove(dgv.Rows[i].Cells[1].Value.ToString());
                }
            }
            MapGis.Refresh();
        }

        private void CreateWmf(byte[] filebyte, string filepath)
        {
            new FileChanger().CreateFile(filepath, filebyte);
        }


        private void CreateDgv(DataGridView dgv, XmlDocument xmldoc)
        {
            dgv.Columns.Clear();
            DataGridViewCheckBoxColumn Column1 = new DataGridViewCheckBoxColumn();
            Column1.FalseValue = "false";
            Column1.HeaderText = "";
            Column1.Name = "Column1";
            Column1.TrueValue = "true";
            Column1.Width = 50;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            Column1});
            dgv.Location = new System.Drawing.Point(0, 0);
            //dgv.ReadOnly = true;
            dgv.RowTemplate.Height = 23;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            DataTable dt = new DataTable();
            dt.Columns.Add("图层名称");
            XmlNode DivRoot = xmldoc.SelectSingleNode("//Divs");
            foreach (XmlNode divnode in DivRoot)
            {
                DataRow dr = dt.NewRow();
                dr[0] = divnode.InnerText;
                dt.Rows.Add(dr);
            }
            dgv.DataSource = dt;
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
            //A_frmDivConfig f = new A_frmDivConfig(LastSelectNode, double.Parse(ntbMin.Text), double.Parse(ntbMax.Text), ConfigXml, trvDiv,);
            //f.Show();
            A_frmDDivConfig f = new A_frmDDivConfig(LastSelectNode, double.Parse(ntbMin.Text), double.Parse(ntbMax.Text), ConfigXml, trvDiv, this);
            f.Show(Dockpanel, DockState.Document);
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
                    this.isSaveed = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法识别的图片!", "提示", MessageBoxButtons.OK);
                }
            }
            dmc.ScrollControlIntoView(this.NowBtn);
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
            MapGis.DelAllDiv();
            MapGis.ReSet();
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
            trvDiv.SelectedNode = trvDiv.Nodes[NowDivName];
            #region[原]
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
            #endregion
            this.MapGis.ReSet();
            ReFlashDivDt();
            NowDgv.DataSource = DivDt;
            this.isSaveed = false;
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            frmDFileDialog openfileDlg = new frmDFileDialog(false);
            //openfileDlg.Multiselect = false;
            //openfileDlg.InitialDirectory = Application.StartupPath + "\\MapGis\\MapConfigFiles";
            //openfileDlg.Filter = "三恒科技图形系统文件|*.shz";
            if (openfileDlg.ShowDialog() == DialogResult.OK)
            {
                //pnlInOut.Visible = false;
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
            //this.isSaveed = false;
            MapGis.ReSet();
            MapGis.Refresh();
            //InitConfigXml();
            LastSelectNode = null;
            MapConfiged = false;
            this.picMap.Image = null;
            this.ntbMax.Text = string.Empty;
            this.ntbMin.Text = string.Empty;
            this.trvDiv.Nodes.Clear();
            //pnlInOut.Visible = false;
            if (!IsOut)
            {
                this.picInOut_Click(this, new EventArgs());
            }      
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            //this.isSaveed = false;
            MapGis.ReSet();
            MapGis.Refresh();
            InitConfigXml();
            LastSelectNode = null;
            MapConfiged = false;
            this.picMap.Image = null;
            this.ntbMax.Text = string.Empty;
            this.ntbMin.Text = string.Empty;
            this.trvDiv.Nodes.Clear();
            //pnlInOut.Visible = false;
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
                    //this.lnkSave_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lnkSave.Links[0]));
                    try
                    {
                        if (isSaveed == false)
                        {
                            //if (MapConfiged)
                            //{
                            //    frmDFileDialog f = new frmDFileDialog();
                            //    //f.InitialDirectory = Application.StartupPath + "\\MapGis\\MapConfigFiles";
                            //    //f.DefaultExt = "shz";
                            //    //f.Filter = "三恒科技图形系统配置文件|*.shz";
                            //    if (f.ShowDialog() == DialogResult.OK)
                            //    {
                            //ConfigXml.Save(f.FileName);
                            string filename = NowFileName;
                            byte[] xmlbytes = new FileChanger().XmlToBytes(ConfigXml);
                            if (dpicbll.ExitsFileName(filename))
                                dpicbll.UpdateFile(filename, xmlbytes, FileID);
                            else
                                dpicbll.AddFile(filename, xmlbytes, FileID);
                            this.isSaveed = true;
                            MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
                            //    }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("底图尚未配置!", "提示", MessageBoxButtons.OK);
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存失败", "提示", MessageBoxButtons.OK);
                    }
                }
            }
            ConfigXmlWiter.Write("Picture.xml");
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            if (!isSaveed)
            {
                DialogResult result = MessageBox.Show("是否需要保存该图形系统文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (isSaveed == false)
                        {
                            //if (MapConfiged)
                            //{
                            //    frmDFileDialog f = new frmDFileDialog();
                            //    //f.InitialDirectory = Application.StartupPath + "\\MapGis\\MapConfigFiles";
                            //    //f.DefaultExt = "shz";
                            //    //f.Filter = "三恒科技图形系统配置文件|*.shz";
                            //    if (f.ShowDialog() == DialogResult.OK)
                            //    {
                            //ConfigXml.Save(f.FileName);
                            string filename = NowFileName;
                            byte[] xmlbytes = new FileChanger().XmlToBytes(ConfigXml);
                            if (dpicbll.ExitsFileName(filename))
                                dpicbll.UpdateFile(filename, xmlbytes, FileID);
                            else
                                dpicbll.AddFile(filename, xmlbytes, FileID);
                            this.isSaveed = true;
                            MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
                            //    }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("底图尚未配置!", "提示", MessageBoxButtons.OK);
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存失败", "提示", MessageBoxButtons.OK);
                    }
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
            //this.pnlInOut.Visible = false;
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

        private void btnNewConfig_Click(object sender, EventArgs e)
        {
            if (CheckMinMax())
            {
                dmc.ControlsClean();
                Panel pnl = new Panel();
                Button btn = new Button();
                DataGridView dgv = new DataGridView();
                pnl.Controls.Add(btn);
                pnl.Controls.Add(dgv);
                pnl.Name = "pnl" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                pnl.Height = 200;
                btn.Dock = System.Windows.Forms.DockStyle.Top;
                btn.Location = new System.Drawing.Point(0, 0);
                btn.Size = new System.Drawing.Size(167, 25);
                btn.UseVisualStyleBackColor = true;
                btn.Text = "";
                dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv.AllowUserToResizeColumns = false;
                dgv.ColumnHeadersHeight = 25;
                dgv.RowHeadersVisible = false;
                dgv.ReadOnly = true;
                dgv.Dock = System.Windows.Forms.DockStyle.Fill;
                dgv.Location = new System.Drawing.Point(0, 26);
                dgv.RowTemplate.Height = 23;
                dgv.Size = new System.Drawing.Size(200, 200);
                dgv.Columns.Clear();
                DataGridViewCheckBoxColumn Column1 = new DataGridViewCheckBoxColumn();
                Column1.FalseValue = 0;
                Column1.HeaderText = "";
                Column1.Name = "Column1";
                Column1.TrueValue = 1;
                Column1.Width = 50;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToResizeRows = false;
                dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                Column1});
                dgv.Location = new System.Drawing.Point(0, 0);
                //dgv.ReadOnly = true;
                dgv.RowTemplate.Height = 23;
                dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                dgv.RowHeadersVisible = false;
                dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
                dgv.CellMouseDown += new DataGridViewCellMouseEventHandler(dgv_CellMouseDown);
                dgv.MouseDown += new MouseEventHandler(dgv_MouseDown);
                dgv.DataError += new DataGridViewDataErrorEventHandler(dgv_DataError);
                btn.Click += new EventHandler(btn_Click);
                btn.MouseDown += new MouseEventHandler(btn_MouseDown);
                dmc.Add(pnl, true);
                pnlList.Add(pnl);
                TextBox txtname = new TextBox();
                pnl.Controls.Add(txtname);
                txtname.Multiline = true;
                txtname.MaxLength = 20;
                txtname.Height = 25;
                txtname.Text = "新建图形";
                txtname.Dock = DockStyle.Top;
                txtname.LostFocus += new EventHandler(txtname_LostFocus);
                txtname.KeyPress += new KeyPressEventHandler(txtname_KeyPress);
                btn.Visible = false;
                dgv.Visible = false;
                this.NowBtn = btn;
                //dmc.LeftPartResize();
                //DivDt.Columns.Add("图层名称");
                //dgv.DataSource = DivDt;
                tsmiNew_Click(this, new EventArgs());
                ntbMin.Text = txtMin.Text;
                ntbMax.Text = txtMax.Text;
                XmlNode node = ConfigXml.SelectSingleNode("//Map");
                if (node != null)
                {
                    if (node.Attributes.Count > 0)
                    {
                        node.Attributes["MinWidth"].Value = txtMin.Text;
                        node.Attributes["MaxWidth"].Value = txtMax.Text;
                    }
                    else
                    {
                        XmlAttribute attribute = ConfigXml.CreateAttribute("MinWidth");
                        attribute.Value = txtMin.Text;
                        node.Attributes.Append(attribute);
                        attribute = ConfigXml.CreateAttribute("MaxWidth");
                        attribute.Value = txtMax.Text;
                        node.Attributes.Append(attribute);
                    }
                }
                else
                {
                    XmlNode newnode = ConfigXml.CreateElement("Map");
                    XmlAttribute attribute = ConfigXml.CreateAttribute("MinWidth");
                    attribute.Value = txtMin.Text;
                    newnode.Attributes.Append(attribute);
                    attribute = ConfigXml.CreateAttribute("MaxWidth");
                    attribute.Value = txtMax.Text;
                    newnode.Attributes.Append(attribute);
                    RootNode.AppendChild(newnode);
                }
                CreatePnlsFalse();
                dmc.LeftPartResize();
                NowBtn = btn;
                NowDgv = dgv;
            }
            dmc.ScrollControlIntoView(dmc.Controls[0].Controls[0]);
        }

        void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private string NowDivName = string.Empty;
        void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && e.ColumnIndex == 1)
                {
                    NowDivName = NowDgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    trvDiv.SelectedNode = trvDiv.Nodes[NowDivName];
                    tsmiAdd.Visible = false;
                    tsmEdit.Visible = true;
                    tsmDel.Visible = true;
                    int y = NowDgv.ColumnHeadersHeight + NowDgv.Rows[0].Height * (e.RowIndex);
                    Point p = new Point(((Control)sender).PointToScreen(e.Location).X + 50, ((Control)sender).PointToScreen(e.Location).Y + y);
                    cmsDiv.Show(p);
                }
            }
            catch (Exception ex)
            { }
        }

        private bool CheckMinMax()
        {
            try
            {
                int min = int.Parse(txtMin.Text);
                int max = int.Parse(txtMax.Text);
                if (min > max)
                {
                    MessageBox.Show("图形范围配置错误...", "提示", MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("图形范围配置错误...", "提示", MessageBoxButtons.OK);
                return false;
            }
        }

        private DataGridView NowDgv = null;
        void dgv_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    NowDgv = (DataGridView)sender;
                    tsmiAdd.Visible = true;
                    tsmEdit.Visible = false;
                    tsmDel.Visible = false;
                    cmsDiv.Show(((DataGridView)sender).PointToScreen(e.Location));
                }
            }
            catch (Exception ex)
            { }
        }

        void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string filename = ((TextBox)sender).Text;
                if (filename.Trim() == ""||filename.Contains("'"))
                {
                    MessageBox.Show("文件名命名错误...", "提示", MessageBoxButtons.OK);
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Focus();
                }
                else
                {
                    if (dpicbll.ExitsFileName(filename))
                    {
                        MessageBox.Show("文件名已存在...", "提示", MessageBoxButtons.OK);
                        ((TextBox)sender).Text = "";
                        ((TextBox)sender).Focus();
                    }
                    else
                    {
                        this.NowBtn = ((Button)((TextBox)sender).Parent.Controls[0]);
                        this.NowDgv = ((DataGridView)((TextBox)sender).Parent.Controls[1]);
                        this.NowBtn.Text = filename.Replace("\r\n", "");
                        this.NowFileName = NowBtn.Text;
                        NowDgv.Visible = true;
                        ((TextBox)sender).Visible = false;
                        this.NowBtn.Visible = true;
                        dmc.ScrollControlIntoView(this.NowBtn);
                        this.isSaveed = false;
                    }
                }
            }
        }

        private Button NowBtn = null;

        void txtname_LostFocus(object sender, EventArgs e)
        {
            //string filename = ((TextBox)sender).Text;
            //if (filename == "" || filename.Contains("'"))
            //{
            //    MessageBox.Show("文件名命名错误...", "提示", MessageBoxButtons.OK);
            //    ((TextBox)sender).Text = "";
            //((TextBox)sender).Focus();
            //}
            //else
            //{
            //    if (dpicbll.ExitsFileName(filename))
            //    {
            //        MessageBox.Show("文件名已存在...", "提示", MessageBoxButtons.OK);
            //        ((TextBox)sender).Text = "";
            //        ((TextBox)sender).Focus();
            //    }
            //    else
            //    {
            //        this.NowBtn.Text = filename;
            //        this.NowFileName = NowBtn.Text;
            //        NowDgv.Visible = true;
            //        ((TextBox)sender).Visible = false;
            //        this.NowBtn.Visible = true;
            //        dmc.ScrollControlIntoView(this.NowBtn);
            //    }
            //}
        }

        private void tsmiConfigDel_Click(object sender, EventArgs e)
        {
            //dmc.Controls.Remove(DelButton.Parent);
            if (dpicbll.ExitsFileName(DelButton.Text))
            {
                dpicbll.RemoveFile(DelButton.Text);
            }
            isSaveed = true;
            tsmiClose_Click(this, new EventArgs());
            dmc.ControlsClean();
            CreatePnls();
            dmc.LeftPartResize();
            btn_Click(FirstButton, new EventArgs());
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            XmlNode node = ConfigXml.SelectSingleNode("//Map");
            string fileid = node.InnerText;
            if (fileid == "")
            {
                MessageBox.Show("底图尚未选择...", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (dpicbll.HasConfigRoutePoint(fileid))
                {
                    this.lnkNew_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lnkNew.Links[0]));
                    ReFlashDivDt();
                    NowDgv.DataSource = DivDt;
                }
                else
                {
                    MessageBox.Show("路径尚未配置...", "提示", MessageBoxButtons.OK);
                    return; 
                }
            }
        }

        public void ReFlashDivDt()
        {
            DivDt = new DataTable();
            DivDt.Columns.Add("图层名称");
            for (int i = 0; i < trvDiv.Nodes.Count; i++)
            { 
                DataRow dr=DivDt.NewRow();
                dr[0] = trvDiv.Nodes[i].Text;
                DivDt.Rows.Add(dr);
            }
            NowDgv.DataSource = DivDt;
            for (int i = 0; i < NowDgv.Rows.Count; i++)
            {
                ((DataGridViewCheckBoxCell)NowDgv.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)NowDgv.Rows[i].Cells[0]).TrueValue;
            }
            btnMoni_Click(this, new EventArgs());
        }

        private void tsmiMapSelect_Click(object sender, EventArgs e)
        {
            btnMapSelect_Click(this, new EventArgs());
        }

        private void tsmiRouteConfig_Click(object sender, EventArgs e)
        {
            XmlNode node = ConfigXml.SelectSingleNode("//Map");
            string fileid = node.InnerText;
            if (fileid == "")
            {
                MessageBox.Show("底图尚未选择...", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (dpicbll.HasConfigRoutePoint(fileid))
                {
                    if (MessageBox.Show("已经配置了分站及路径,是否重新配置?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        A_FrmDRouteConfig routeconfig = new A_FrmDRouteConfig(fileid, this);
                        routeconfig.Show(this.Dockpanel, DockState.Document);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    A_FrmDRouteConfig routeconfig = new A_FrmDRouteConfig(fileid, this);
                    routeconfig.Show(this.Dockpanel, DockState.Document);
                }
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSaveed == false)
                {
                    //if (MapConfiged)
                    //{
                    //    frmDFileDialog f = new frmDFileDialog();
                    //    //f.InitialDirectory = Application.StartupPath + "\\MapGis\\MapConfigFiles";
                    //    //f.DefaultExt = "shz";
                    //    //f.Filter = "三恒科技图形系统配置文件|*.shz";
                    //    if (f.ShowDialog() == DialogResult.OK)
                    //    {
                    //ConfigXml.Save(f.FileName);
                    string filename = NowBtn.Text;
                    byte[] xmlbytes = new FileChanger().XmlToBytes(ConfigXml);
                    if (dpicbll.ExitsFileName(filename))
                        dpicbll.UpdateFile(filename, xmlbytes, FileID);
                    else
                        dpicbll.AddFile(filename, xmlbytes, FileID);
                    this.isSaveed = true;
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("底图尚未配置!", "提示", MessageBoxButtons.OK);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败", "提示", MessageBoxButtons.OK);
            }
        }

        private void A_FrmDCreateConfig_Shown(object sender, EventArgs e)
        {
            isSaveed = true;
            btn_Click(FirstButton, new EventArgs());
        }

        private void btnPicConfig_Click(object sender, EventArgs e)
        {
            A_FrmAddPic frm = new A_FrmAddPic();
            frm.ShowDialog();
        }

        private void txtMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
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
