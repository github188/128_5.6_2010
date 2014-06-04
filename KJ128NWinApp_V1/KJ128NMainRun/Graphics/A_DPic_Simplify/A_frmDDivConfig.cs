using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using KJ128NDBTable;
using KJ128NMainRun.Graphics.Config;
using KJ128NMainRun.Graphics.DPic;
namespace KJ128NMainRun.Graphics.Simplify
{
    public partial class A_frmDDivConfig : Wilson.Controls.Docking.DockContent
    {
        private bool IsOut = false;
        private TreeNode LastSelectNode = null;
        private TreeView trvDiv = null;
        private double MinWidth;
        private double MaxWidth;
        private double DivMinWidth;
        private double DivMaxWidth;
        //private string MapFilePath=string.Empty;
        private string FileID = string.Empty;
        private Point MousePoint;
        private Point pnlPoint;
        //private Label labGifTitle;
        //private Label labWordTitle;
        private List<string> imgNameList = new List<string>();
        private System.Collections.Hashtable imgFileht = new System.Collections.Hashtable();
        private ImageList imgList = new ImageList();
        private ZzhaControlLibrary.StaticObject EventStaticObject=null;
        private bool StaticCanMove = false;
        private XmlDocument ConfigXml = null;
        private bool HasMonied = false;
        private string OldDivName = string.Empty;
        private Graphics_DpicBLL dpicbll = new Graphics_DpicBLL();
        private A_FrmDCreateConfig_Simplify FrmConfig = null;
        private bool isPic = true;


        public A_frmDDivConfig()
        {
            InitializeComponent();
        }

        public A_frmDDivConfig(TreeNode node, double min, double max, XmlDocument configXml, TreeView trv,A_FrmDCreateConfig_Simplify frm)
        {
            InitializeComponent();
            this.LastSelectNode = node;
            this.OldDivName = node.Text;
            this.trvDiv = trv;
            FrmConfig = frm;
            MinWidth = min;
            MaxWidth = max;
            FileID = configXml.SelectSingleNode("//Map").InnerText;
            //MapFilePath = mapfilepath;
            //this.MapGis.MapFilePath = MapFilePath;
            //this.MapGis.MinWidth = MapGis.Width;
            //this.MapGis.MaxWidth = MapGis.Width;
            this.MapGis.IsShowAllStations(true);
            ConfigXml = configXml;
            MapGis.StaticClick += new ZzhaControlLibrary.ZzhaMapGis.ClickStatic(MapGis_StaticClick);
            MapGis.MouseMove += new MouseEventHandler(MapGis_MouseMove);
            MapGis.MouseDown += new MouseEventHandler(MapGis_MouseDown);
            dmc.Add(pnl1,true);
            dmc.Add(pnl2);
            dmc.Add(pnl3);
            dmc.LeftPartResize();
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

        private void frmDivConfig_Load(object sender, EventArgs e)
        {
            MapGis.UseGif = false;
            //if (this.LastSelectNode != null)
            //    txtDivName.Text = LastSelectNode.Text;
            //DataTable stationdt = dpicbll.GetStationHeadPlaceByFileID(FileID);
            ////for (int i = 0; i < stationdt.Columns.Count; i++)
            ////{
            ////    if (stationdt.Columns[i].ColumnName != "StationHeadPlace")
            ////    {
            ////        stationdt.Columns.RemoveAt(i);
            ////        i--;
            ////    }
            ////}
            //this.dgvStations.DataSource = stationdt;
            //LoadDivConfig();
            //LoadOtherImage(); 
            //LoadRealTimeInfo();

        }

        private void LoadDivConfig()
        {
            XmlNode DivRootNode = ConfigXml.SelectSingleNode("//Divs");
            foreach (XmlNode Node in DivRootNode.ChildNodes)
            {
                if (Node.InnerText == LastSelectNode.Text)
                {
                    this.ntbMin.Text = Node.Attributes["MinWidth"].InnerText;
                    this.ntbMax.Text = Node.Attributes["MaxWidth"].InnerText;
                    
                    XmlNode StationRoot = ConfigXml.SelectSingleNode("//Stations");
                    if (StationRoot != null && StationRoot.ChildNodes.Count > 0)
                    {
                        foreach (XmlNode stationnode in StationRoot.ChildNodes)
                        {
                            for (int i = 0; i < dgvStations.Rows.Count; i++)
                            {
                                if (dgvStations.Rows[i].Cells[1].Value.ToString() == stationnode.Attributes[0].InnerText)
                                {
                                    if(stationnode.InnerText.Contains(LastSelectNode.Text+"|"))
                                    {
                                        dgvStations.Rows[i].Cells[0].Value = 1;
                                        break;
                                    }
                                }
                            }
                        }
                        btnSelectAll.Text = "全选";
                    }
                }
            }
        }

        private void LoadStatic()
        {
            XmlNode StaticRoot = ConfigXml.SelectSingleNode("//Statics");
            if (StaticRoot != null && StaticRoot.ChildNodes.Count > 0)
            {
                foreach (XmlNode staticnode in StaticRoot.ChildNodes)
                {
                    if (staticnode.ChildNodes[0].InnerText.Contains(LastSelectNode.Text + "|"))
                    {
                        float x = float.Parse(staticnode.ChildNodes[2].InnerText);
                        float y = float.Parse(staticnode.ChildNodes[3].InnerText);
                        string filepath =staticnode.ChildNodes[1].InnerText;
                        string divname = LastSelectNode.Text;
                        int width = int.Parse(staticnode.ChildNodes[4].InnerText);
                        int height = int.Parse(staticnode.ChildNodes[5].InnerText);
                        string name=staticnode.ChildNodes[6].InnerText;
                        string key = staticnode.ChildNodes[7].InnerText;
                        ZzhaControlLibrary.StaticType type = ZzhaControlLibrary.StaticType.ImageAndWord ;
                        string fontname = staticnode.ChildNodes[9].Attributes[0].InnerText;
                        float size = float.Parse(staticnode.ChildNodes[9].Attributes[1].InnerText);
                        FontStyle fontstyle = (FontStyle)Enum.Parse(typeof(FontStyle), staticnode.ChildNodes[9].Attributes[2].InnerText);
                        Color FontColor = Color.FromArgb(int.Parse(staticnode.ChildNodes[9].InnerText));
                        System.Drawing.Font staticFont = new Font(fontname, size, fontstyle);
                        if (staticnode.ChildNodes[8].InnerText == "Image")
                        {
                            type = ZzhaControlLibrary.StaticType.Image;
                            MapGis.AddStaticObj(x, y, new Bitmap(Application.StartupPath + filepath), divname, width, height, filepath, name, key, type, staticFont, FontColor);
                        }
                        if (staticnode.ChildNodes[8].InnerText == "ImageAndWord")
                        {
                            type = ZzhaControlLibrary.StaticType.ImageAndWord;
                            MapGis.AddStaticObj(x, y, new Bitmap(Application.StartupPath + filepath), divname, width, height, filepath, name, key, type, staticFont, FontColor);
                        }
                        if (staticnode.ChildNodes[8].InnerText == "Word")
                        {
                            type = ZzhaControlLibrary.StaticType.Word;
                            MapGis.AddStaticObj(x, y, name, key, divname, staticFont, FontColor);
                        }
                    }
                }
            }
        }

        private void LoadOtherImage()
        {
            if (System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\OtherImage"))
            {
                string[] filename = System.IO.Directory.GetFiles(Application.StartupPath + "\\MapGis\\OtherImage","*.gif");
                for (int i = 0; i < filename.Length; i++)
                {
                    string name = filename[i].Substring(filename[i].LastIndexOf("\\")+1);
                    imgFileht.Add(name, filename[i].Substring(filename[i].LastIndexOf("\\MapGis")));
                    imgList.Images.Add(filename[i], new Bitmap(filename[i]));
                }
                filename = System.IO.Directory.GetFiles(Application.StartupPath + "\\MapGis\\OtherImage", "*.jpg");
                for (int i = 0; i < filename.Length; i++)
                {
                    string name = filename[i].Substring(filename[i].LastIndexOf("\\") + 1);
                    imgFileht.Add(name, filename[i].Substring(filename[i].LastIndexOf("\\MapGis")));
                    imgList.Images.Add(filename[i], new Bitmap(filename[i]));
                }
                filename = System.IO.Directory.GetFiles(Application.StartupPath + "\\MapGis\\OtherImage", "*.bmp");
                for (int i = 0; i < filename.Length; i++)
                {
                    string name = filename[i].Substring(filename[i].LastIndexOf("\\") + 1);
                    imgFileht.Add(name, filename[i].Substring(filename[i].LastIndexOf("\\MapGis")));
                    imgList.Images.Add(filename[i], new Bitmap(filename[i]));
                }
                lsvImg.LargeImageList = imgList;
                imgList.ImageSize = new Size(50, 38);
                foreach (object key in imgFileht.Keys)
                {
                    ListViewItem item = new ListViewItem(key.ToString(), Application.StartupPath + imgFileht[key].ToString());
                    lsvImg.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("对不起!没有找到图形系统文件,请确认是否被人为删除!", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 重新载入实时事件
        /// </summary>
        private void LoadRealTimeInfo()
        {
            try
            {
                trvRealTime.Nodes.Add("zong", "下井总人数");
                trvRealTime.Nodes.Add("qy", "按区域划分");
                trvRealTime.Nodes.Add("gz", "按工种划分");
                trvRealTime.Nodes.Add("bm", "按部门划分");
                trvRealTime.Nodes.Add("cf", "传输分站状态");
                int allNum = int.Parse(new Graphics_RealTimeBLL().GetEmpInMineCounts());
                trvRealTime.Nodes["zong"].Text = "实时分布: 共有" + allNum.ToString() + "人下井";
                List<string> list = new Graphics_AreaRealtimeBLL().GetAreaInfoAndEmpcount();
                //trvRealTime.Nodes["qy"].Nodes.Clear();
                //foreach (string s in list)
                //{
                //    trvRealTime.Nodes["qy"].Nodes.Add(s);
                //}
                if (list.Count >= trvRealTime.Nodes["qy"].Nodes.Count)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (trvRealTime.Nodes["qy"].Nodes.ContainsKey("qy" + i.ToString()))
                            trvRealTime.Nodes["qy"].Nodes["qy" + i.ToString()].Text = list[i];
                        else
                            trvRealTime.Nodes["qy"].Nodes.Add("qy" + i.ToString(), list[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < trvRealTime.Nodes["qy"].Nodes.Count; i++)
                    {
                        if (i < list.Count)
                            trvRealTime.Nodes["qy"].Nodes["qy" + i.ToString()].Text = list[i];
                        else
                            trvRealTime.Nodes["qy"].Nodes.RemoveAt(i);
                    }
                }
                list = new Graphics_RealTimeBLL().GetEmpWorkTypeNumRealTime(allNum);
                //trvRealTime.Nodes["gz"].Nodes.Clear();
                //foreach (string s in list)
                //{
                //    trvRealTime.Nodes["gz"].Nodes.Add(s);
                //}
                if (list.Count >= trvRealTime.Nodes["gz"].Nodes.Count)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (trvRealTime.Nodes["gz"].Nodes.ContainsKey("gz" + i.ToString()))
                            trvRealTime.Nodes["gz"].Nodes["gz" + i.ToString()].Text = list[i];
                        else
                            trvRealTime.Nodes["gz"].Nodes.Add("gz" + i.ToString(), list[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < trvRealTime.Nodes["gz"].Nodes.Count; i++)
                    {
                        if (i < list.Count)
                            trvRealTime.Nodes["gz"].Nodes["gz" + i.ToString()].Text = list[i];
                        else
                            trvRealTime.Nodes["gz"].Nodes.RemoveAt(i);
                    }
                }
                list = new Graphics_RealTimeBLL().GetRealTimeEmpNumByDept();
                //trvRealTime.Nodes["bm"].Nodes.Clear();
                //foreach (string s in list)
                //{
                //    trvRealTime.Nodes["bm"].Nodes.Add(s);
                //}    
                if (list.Count >= trvRealTime.Nodes["bm"].Nodes.Count)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (trvRealTime.Nodes["bm"].Nodes.ContainsKey("bm" + i.ToString()))
                            trvRealTime.Nodes["bm"].Nodes["bm" + i.ToString()].Text = list[i];
                        else
                            trvRealTime.Nodes["bm"].Nodes.Add("bm" + i.ToString(), list[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < trvRealTime.Nodes["bm"].Nodes.Count; i++)
                    {
                        if (i < list.Count)
                            trvRealTime.Nodes["bm"].Nodes["bm" + i.ToString()].Text = list[i];
                        else
                            trvRealTime.Nodes["bm"].Nodes.RemoveAt(i);
                    }
                }
                list = new Graphics_RealTimeBLL().GetAllStationState();
                //trvRealTime.Nodes["bm"].Nodes.Clear();
                //foreach (string s in list)
                //{
                //    trvRealTime.Nodes["bm"].Nodes.Add(s);
                //}    
                if (list.Count >= trvRealTime.Nodes["cf"].Nodes.Count)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (trvRealTime.Nodes["cf"].Nodes.ContainsKey("cf" + i.ToString()))
                            trvRealTime.Nodes["cf"].Nodes["cf" + i.ToString()].Text = list[i];
                        else
                            trvRealTime.Nodes["cf"].Nodes.Add("cf" + i.ToString(), list[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < trvRealTime.Nodes["cf"].Nodes.Count; i++)
                    {
                        if (i < list.Count)
                            trvRealTime.Nodes["cf"].Nodes["cf" + i.ToString()].Text = list[i];
                        else
                            trvRealTime.Nodes["cf"].Nodes.RemoveAt(i);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void txtDivName_Leave(object sender, EventArgs e)
        {
            CheckReName(txtDivName.Text);
        }

        private void CheckReName(string name)
        {
            if (trvDiv.Nodes.ContainsKey(name))
            {
                CheckReName(1, name);
            }
            else
            {
                LastSelectNode.Name = name;
                LastSelectNode.Text = name;
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
                LastSelectNode.Name = name + nameid.ToString();
                LastSelectNode.Text = name + nameid.ToString();
            }
        }

        private void ntbMin_Leave(object sender, EventArgs e)
        {
            if (this.ntbMin.Text != "" && this.ntbMin.Text != "格式错误")
            {
                if (double.Parse(ntbMin.Text) < MinWidth)
                {
                    MessageBox.Show("图层显示范围不能超越整个地图显示范围!", "提示", MessageBoxButtons.OK);
                    ntbMin.Focus();
                    return;
                }
            }
            if (this.ntbMax.Text != "" && this.ntbMin.Text != "" && this.ntbMin.Text != "格式错误" && this.ntbMax.Text != "格式错误")
            {
                if (double.Parse(ntbMin.Text) < MinWidth || double.Parse(ntbMin.Text) > MaxWidth)
                {
                    MessageBox.Show("图层显示范围不能超越整个地图显示范围!", "提示", MessageBoxButtons.OK);
                    ntbMin.Focus();
                }
                else
                {
                    this.DivMinWidth = double.Parse(ntbMin.Text);
                    ShowMap();
                }
            }
        }

        private void ntbMax_Leave(object sender, EventArgs e)
        {
            if (this.ntbMax.Text != "")
            {
                if (double.Parse(ntbMax.Text) > MaxWidth)
                {
                    MessageBox.Show("图层显示范围不能超越整个地图显示范围!", "提示", MessageBoxButtons.OK);
                    ntbMin.Focus();
                    return;
                }
            }
            if (this.ntbMax.Text != "" && this.ntbMin.Text != "")
            {
                if (double.Parse(ntbMax.Text) < MinWidth || double.Parse(ntbMax.Text) > MaxWidth)
                {
                    MessageBox.Show("图层显示范围不能超越整个地图显示范围!", "提示", MessageBoxButtons.OK);
                    ntbMin.Focus();
                }
                else
                {
                    this.DivMaxWidth = double.Parse(ntbMax.Text);
                    ShowMap();
                }
            }
        }

        private void lnkAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnkAll.Text == "全选")
            {
                for (int i = 0; i < dgvStations.Rows.Count; i++)
                {
                    ((DataGridViewCheckBoxCell)dgvStations.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgvStations.Rows[i].Cells[0]).TrueValue;
                }
                lnkAll.Text = "全选";
            }
            else
            {
                for (int i = 0; i < dgvStations.Rows.Count; i++)
                {
                    ((DataGridViewCheckBoxCell)dgvStations.Rows[i].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgvStations.Rows[i].Cells[0]).FalseValue;
                }
                lnkAll.Text = "全选";
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ntbMin.Text) > Convert.ToInt32(ntbMax.Text))
                    throw new Exception();
                this.MapGis.MinWidth = Convert.ToInt32(ntbMin.Text);
                this.MapGis.MaxWidth = Convert.ToInt32(ntbMax.Text);
                //this.MapGis.MapFilePath = Application.StartupPath + MapFilePath;
                try
                {
                    DataTable dt = dpicbll.GetBackPicByFileID(FileID);
                    byte[] buffer = (byte[])dt.Rows[0][0];
                    Graphics.Config.FileChanger fc = new KJ128NMainRun.Graphics.Config.FileChanger();
                    if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\DMap"))
                    {
                        System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\DMap");
                    }
                    fc.CreateFile(Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString(), buffer);
                    this.MapGis.MapFilePath = Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString();
                    System.IO.File.Delete(Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法识别的图片!", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("图层显示范围没有配置或配置不正确,请检查!", "提示", MessageBoxButtons.OK);
                return;
            }
            AddSelectedStations();
            LoadStatic();
            HasMonied = true;
            MapGis.FlashAll();
            pnl2.Visible = true;
            pnl3.Visible = true;
        }

        private void AddSelectedStations()
        {
            this.MapGis.ClearAllStation();
            DataTable stationinfodt = dpicbll.GetStationHeadByFileID(FileID);
            if (stationinfodt != null && stationinfodt.Rows.Count > 0)
            {
                for (int i = 0; i < stationinfodt.Rows.Count; i++)
                {
                    //if (dgvStations.Rows[i].Cells[0].Value != null && dgvStations.Rows[i].Cells[0].Value.ToString() == "1")
                    //{
                        string stationID = stationinfodt.Rows[i][0].ToString() + "." + stationinfodt.Rows[i][1].ToString();
                        string stationName = stationinfodt.Rows[i][2].ToString();
                        float stationheadx = float.Parse(stationinfodt.Rows[i][3].ToString());
                        float stationheady = float.Parse(stationinfodt.Rows[i][4].ToString());
                        if (System.IO.File.Exists(Application.StartupPath + "\\MapGis\\ShineImage\\Signal.gif"))
                        {
                            this.MapGis.AddStation(stationheadx, stationheady, stationName, stationID, "正常", new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\Signal.gif"));
                        }
                        else
                        {
                            MessageBox.Show("系统提供的图形文件已不存在!", "提示", MessageBoxButtons.OK);
                            return;
                        }
                    //}
                }
            }
            MapGis.FalshStations();
            MapGis.FalshStatics();
            MapGis.FlashMap();
        }

        private void lnkPicList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (HasMonied)
            {
                //this.pnlPicList.Visible = true;
                pnlPicList.BringToFront();
            }
            else
            {
                MessageBox.Show("在您打开图库之前请先加载图层", "提示", MessageBoxButtons.OK);
            }
        }

        private void cpStationHead_CloseButtonClick(object sender, EventArgs e)
        {
            this.pnlPicList.Visible = false;
            this.pnlEmp.Visible = false;
            this.lsvImg.Visible = false;
        }

        private void cpStationHead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.MousePoint = cpStationHead.PointToScreen(e.Location);
                this.pnlPoint = pnlPicList.Location;
            }
        }

        private void cpStationHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = cpStationHead.PointToScreen(e.Location);
                this.pnlPicList.Left = this.pnlPoint.X + p.X - MousePoint.X;
                this.pnlPicList.Top = this.pnlPoint.Y + p.Y - MousePoint.Y;
            }
        }

        //private void InitPicListPanel()
        //{
        //    this.labGifTitle = new Label();
        //    labGifTitle.Left = 0;
        //    labGifTitle.Top = cpStationHead.Bottom;
        //}

        

        private void MapGis_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isPic)
                {
                    if (lsvImg.SelectedItems.Count > 0)
                    {
                        PointF p = ZzhaControlLibrary.PositionChanger.PositionChange(new PointF(MapGis.MapX, MapGis.MapY), new PointF(0, 0), e.Location);
                        p = ZzhaControlLibrary.PositionChanger.ZoomPositionChange(Convert.ToDouble(MapGis.OldMapWidth) / Convert.ToDouble(MapGis._MapWidth), p);
                        MapGis.AddStaticObj(p.X, p.Y, new Bitmap(Application.StartupPath + imgFileht[lsvImg.SelectedItems[0].Text].ToString()), imgFileht[lsvImg.SelectedItems[0].Text].ToString(), LastSelectNode.Text, ZzhaControlLibrary.StaticType.Image, Label.DefaultFont, Color.Red);
                    }
                }
                else
                {
                    if (trvRealTime.SelectedNode != null)
                    {
                        if (this.trvRealTime.SelectedNode.Name != "bm" && this.trvRealTime.SelectedNode.Name != "gz" && this.trvRealTime.SelectedNode.Name != "qy" && this.trvRealTime.SelectedNode.Name != "cf")
                        {
                            PointF p = ZzhaControlLibrary.PositionChanger.PositionChange(new PointF(MapGis.MapX, MapGis.MapY), new PointF(0, 0), e.Location);
                            p = ZzhaControlLibrary.PositionChanger.ZoomPositionChange(Convert.ToDouble(MapGis.OldMapWidth) / Convert.ToDouble(MapGis._MapWidth), p);
                            MapGis.AddStaticObj(p.X, p.Y, trvRealTime.SelectedNode.Text, trvRealTime.SelectedNode.Name, LastSelectNode.Text, Label.DefaultFont, Color.Red);
                        }
                    }
                }
                MapGis.FlashAll();
            }
        }

        void MapGis_StaticClick(ZzhaControlLibrary.StaticObject EventStaticObj)
        {
            this.EventStaticObject = EventStaticObj;
            if (EventStaticObject.Type == ZzhaControlLibrary.StaticType.Word)
                cmsMenu.Items[1].Visible = false;
            else
                cmsMenu.Items[1].Visible = true;
            cmsMenu.Show(MousePosition);
        }

        private void tsmiConfig_Click(object sender, EventArgs e)
        {
            if (this.EventStaticObject != null)
            {
                frmStaticConfig f = new frmStaticConfig(EventStaticObject, MapGis);
                f.ShowDialog();
                MapGis.FlashAll();
            }
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            if (this.EventStaticObject != null)
            {
                MapGis.DelStaticObj(this.EventStaticObject);
                MapGis.FlashAll();
            }
        }

        private void tsmiMove_Click(object sender, EventArgs e)
        {
            if (this.EventStaticObject != null)
            {
                this.StaticCanMove = true;
            }
        }

        void MapGis_MouseMove(object sender, MouseEventArgs e)
        {
            if (EventStaticObject != null)
            {
                if (StaticCanMove)
                {
                    PointF p = ZzhaControlLibrary.PositionChanger.PositionChange(new PointF(MapGis.MapX, MapGis.MapY), new PointF(0, 0), e.Location);
                    p = ZzhaControlLibrary.PositionChanger.ZoomPositionChange(Convert.ToDouble(MapGis.OldMapWidth) / Convert.ToDouble(MapGis._MapWidth), p);
                    this.EventStaticObject.StaticPoint = p;
                    MapGis.FalshStatics();
                    MapGis.FlashMap();
                }
            }
        }

        void MapGis_MouseDown(object sender, MouseEventArgs e)
        {
            if (StaticCanMove)
            {
                StaticCanMove = false;
            }
        }

        private void lnkSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CanShowMap())
            {
                if (HasMonied)
                {
                    XmlNode DivNode = ConfigXml.SelectSingleNode("//Divs");
                    AddDiv(DivNode, ntbMin.Text, ntbMax.Text, LastSelectNode.Text);
                    XmlNode StationNode = ConfigXml.SelectSingleNode("//Stations");
                    this.ClareStation(LastSelectNode.Text);
                    for (int i = 0; i < MapGis.StationsList.Count; i++)
                    {
                        AddStation(StationNode, LastSelectNode.Text, MapGis.StationsList[i].StationName);
                    }
                    XmlNode StaticNode = ConfigXml.SelectSingleNode("//Statics");
                    this.ClareStatic(LastSelectNode.Text);
                    for (int i = 0; i < MapGis.StaticList.Count; i++)
                    {
                        AddStatic(StaticNode, LastSelectNode.Text, MapGis.StaticList[i]);
                    }
                    MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK);
                    FrmConfig.isSaveed = false;
                    IsSave = true;
                }
                else
                {
                    MessageBox.Show("操作无效,您尚未加载图层,请先加载图层之后再保存!", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void AddDiv(XmlNode pntNode, string min,string max, string divname)
        {
            if (divname != OldDivName)
            {
                XmlNode DivRootNode = ConfigXml.SelectSingleNode("//Divs");
                foreach (XmlNode Node in DivRootNode.ChildNodes)
                {
                    if (Node.InnerText == OldDivName)
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
                OldDivName = divname;
            }
            XmlNode DivRoot = ConfigXml.SelectSingleNode("//Divs");
            XmlNode node = null;
            foreach (XmlNode divnode in DivRoot.ChildNodes)
            {
                if (divnode.Attributes["key"].InnerText == LastSelectNode.Name)
                {
                    node = divnode;
                    break;
                }
            }
            if (node == null)
            {
                node = ConfigXml.CreateElement("Div");
                node.InnerText = divname;
                XmlAttribute att = ConfigXml.CreateAttribute("key");
                att.InnerText = LastSelectNode.Name;
                node.Attributes.Append(att);
                att = ConfigXml.CreateAttribute("MinWidth");
                att.InnerText = min;
                node.Attributes.Append(att);
                att = ConfigXml.CreateAttribute("MaxWidth");
                att.InnerText = max;
                node.Attributes.Append(att);
                pntNode.AppendChild(node);
            }
            else
            {
                node.InnerText = divname;
                node.Attributes["MinWidth"].InnerText = min;
                node.Attributes["MaxWidth"].InnerText = max;
            }
        }

        private void ClareStatic(string divname)
        {
            XmlNode StaticRoot = ConfigXml.SelectSingleNode("//Statics");
            for (int i = (StaticRoot.ChildNodes.Count-1); i >= 0; i--)
            {
                StaticRoot.ChildNodes[i].ChildNodes[0].InnerText = StaticRoot.ChildNodes[i].ChildNodes[0].InnerText.Replace(divname + "|", string.Empty);
                if (StaticRoot.ChildNodes[i].ChildNodes[0].InnerText == "")
                {
                    StaticRoot.RemoveChild(StaticRoot.ChildNodes[i]);
                }
            }
        }

        private void AddStatic(XmlNode pntNode, string divname, ZzhaControlLibrary.StaticObject sobj)
        {
            string nodename ="Static" + sobj.StaticPoint.X.ToString() + sobj.StaticPoint.Y.ToString();
            XmlNode node = ConfigXml.SelectSingleNode("//" + nodename);
            if (node != null)
            {
                node.ChildNodes[0].InnerText = node.ChildNodes[0].InnerText + divname+"|";
                node.ChildNodes[2].InnerText = sobj.StaticPoint.X.ToString();
                node.ChildNodes[3].InnerText = sobj.StaticPoint.Y.ToString();
                node.ChildNodes[4].InnerText = sobj.StaticWidth.ToString();
                node.ChildNodes[5].InnerText = sobj.StaticHeight.ToString();
                node.ChildNodes[6].InnerText = sobj.StaticName.ToString();
            }
            else
            {
                node = ConfigXml.CreateElement(nodename);
                XmlNode newnode = ConfigXml.CreateElement("Divname");
                newnode.InnerText = divname+"|";
                node.AppendChild(newnode);
                newnode = ConfigXml.CreateElement("Path");
                newnode.InnerText = sobj.StaticState;
                node.AppendChild(newnode);
                newnode = ConfigXml.CreateElement("X");
                newnode.InnerText = sobj.StaticPoint.X.ToString();
                node.AppendChild(newnode);
                newnode = ConfigXml.CreateElement("Y");
                newnode.InnerText = sobj.StaticPoint.Y.ToString();
                node.AppendChild(newnode);
                newnode = ConfigXml.CreateElement("Width");
                newnode.InnerText = sobj.StaticWidth.ToString();
                node.AppendChild(newnode);
                newnode = ConfigXml.CreateElement("Height");
                newnode.InnerText = sobj.StaticHeight.ToString();
                node.AppendChild(newnode);
                newnode = ConfigXml.CreateElement("Word");
                newnode.InnerText = sobj.StaticName;
                node.AppendChild(newnode);
                newnode = ConfigXml.CreateElement("Key");
                newnode.InnerText = sobj.NameKey;
                node.AppendChild(newnode);
                newnode = ConfigXml.CreateElement("Type");
                newnode.InnerText = sobj.Type.ToString();
                node.AppendChild(newnode);
                newnode = ConfigXml.CreateElement("Font");
                #region[字体]
                string FontName = sobj.StaticFont.Name;
                string FontSize = sobj.StaticFont.Size.ToString();
                string Fontstyle = sobj.StaticFont.Style.ToString();
                string FontColor = sobj.StaticColor.ToArgb().ToString();
                XmlAttribute fontnode = ConfigXml.CreateAttribute("Name");
                fontnode.InnerText = FontName;
                newnode.Attributes.Append(fontnode);
                fontnode = ConfigXml.CreateAttribute("Size");
                fontnode.InnerText = FontSize;
                newnode.Attributes.Append(fontnode);
                fontnode = ConfigXml.CreateAttribute("Style");
                fontnode.InnerText = Fontstyle;
                newnode.Attributes.Append(fontnode);
                newnode.InnerText = FontColor;
                node.AppendChild(newnode);
                #endregion
                pntNode.AppendChild(node);
            }
        }

        private void ClareStation(string divname)
        {
            XmlNode StationRoot = ConfigXml.SelectSingleNode("//Stations");
            foreach (XmlNode stationnode in StationRoot.ChildNodes)
            {
                stationnode.InnerText = stationnode.InnerText.Replace(divname + "|", string.Empty);
            }
        }

        private void AddStation(XmlNode pntNode, string divname, string stationplace)
        {
            XmlNode node = ConfigXml.GetElementById(stationplace);
            if (node != null)
            {
                node.InnerText = node.InnerText + divname+"|";
            }
            else
            {
                node = ConfigXml.CreateElement("Station");
                XmlAttribute name = ConfigXml.CreateAttribute("SSN");
                name.InnerText = stationplace;
                node.Attributes.Append(name);
                node.InnerText = divname+"|";
                pntNode.AppendChild(node);
            }
        }

        private void tsmiWordConfig_Click(object sender, EventArgs e)
        {
            if (EventStaticObject != null)
            {
                frmWordConfig f;
                if (EventStaticObject.StaticName == "")
                    f = new frmWordConfig();
                else
                    f = new frmWordConfig(EventStaticObject.StaticName, EventStaticObject.NameKey);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (f.ConfigLab.Text != "")
                    {
                        if (EventStaticObject.StaticImage != null)
                        {
                            EventStaticObject.Type = ZzhaControlLibrary.StaticType.ImageAndWord;
                        }
                        EventStaticObject.StaticName = f.ConfigLab.Text;
                        EventStaticObject.StaticFont = f.ConfigLab.Font;
                        EventStaticObject.StaticColor = f.ConfigLab.ForeColor;
                        EventStaticObject.NameKey = f.Key;
                    }
                    MapGis.FlashAll();
                }
            }
        }

        public void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text == "全选")
            {
                for (int i = 0; i < dgvStations.Rows.Count; i++)
                {
                    dgvStations.Rows[i].Cells[0].Value = 1;
                }
                btnSelectAll.Text = "全选";
            }
            else
            {
                for (int i = 0; i < dgvStations.Rows.Count; i++)
                {
                    dgvStations.Rows[i].Cells[0].Value = 0;
                }
                btnSelectAll.Text = "全选";
            }
            ShowMap();
        }

        private bool IsSave = false;
        public void btnSave_Click(object sender, EventArgs e)
        {
            this.lnkSave_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lnkSave.Links[0]));
            //IsSave = true;
        }

        private void btnTuku_Click(object sender, EventArgs e)
        {
            this.lnkPicList_LinkClicked(this, new LinkLabelLinkClickedEventArgs(lnkPicList.Links[0]));
        }

        private void btnLoadDiv_Click(object sender, EventArgs e)
        {
            this.linkLabel1_LinkClicked(this, new LinkLabelLinkClickedEventArgs(linkLabel1.Links[0]));
        }

        private void A_frmDDivConfig_Shown(object sender, EventArgs e)
        {
            if (this.LastSelectNode != null)
                txtDivName.Text = LastSelectNode.Text;
            DataTable stationdt = dpicbll.GetStationHeadPlaceByFileID(FileID);
            //for (int i = 0; i < stationdt.Columns.Count; i++)
            //{
            //    if (stationdt.Columns[i].ColumnName != "StationHeadPlace")
            //    {
            //        stationdt.Columns.RemoveAt(i);
            //        i--;
            //    }
            //}
            this.dgvStations.DataSource = stationdt;
            this.dgvStations.Columns[1].ReadOnly = true;
            LoadDivConfig();
            LoadOtherImage();
            LoadRealTimeInfo();
            FrmConfig.DockState = Wilson.Controls.Docking.DockState.Hidden;
            ShowMap();
        }

        private void A_frmDDivConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmConfig.DockState = Wilson.Controls.Docking.DockState.Document;
            FrmConfig.ReFlashDivDt();
        }

        private void btnDivConfig_Click(object sender, EventArgs e)
        {
            dmc.ButtonClick(pnl1.Name);
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            dmc.ButtonClick(pnl3.Name);
            this.isPic = true;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            dmc.ButtonClick(pnl2.Name);
            this.isPic = false;
        }

        private void ShowMap()
        {
            try
            {
                //this.MapGis.MapFilePath = Application.StartupPath + MapFilePath;
                try
                {
                    DataTable dt = dpicbll.GetBackPicByFileID(FileID);
                    byte[] buffer = (byte[])dt.Rows[0][0];
                    Graphics.Config.FileChanger fc = new KJ128NMainRun.Graphics.Config.FileChanger();
                    if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\DMap"))
                    {
                        System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\DMap");
                    }
                    fc.CreateFile(Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString(), buffer);
                    this.MapGis.MapFilePath = Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString();
                    System.IO.File.Delete(Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法识别的图片!", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (Convert.ToInt32(ntbMin.Text) > Convert.ToInt32(ntbMax.Text))
                    throw new Exception();
                this.MapGis.MinWidth = Convert.ToInt32(ntbMin.Text);
                this.MapGis.MaxWidth = Convert.ToInt32(ntbMax.Text);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("图层显示范围没有配置或配置不正确,请检查!", "提示", MessageBoxButtons.OK);
                //return;
            }
            MapGis.ClearAllStation();
            MapGis.ClearAllStatic();
            AddSelectedStations();
            LoadStatic();
            HasMonied = true;
            MapGis.FlashAll();
            pnl2.Visible = true;
            pnl3.Visible = true;
        }

        private bool CanShowMap()
        {
            try
            {
                //this.MapGis.MapFilePath = Application.StartupPath + MapFilePath;
                try
                {
                    DataTable dt = dpicbll.GetBackPicByFileID(FileID);
                    byte[] buffer = (byte[])dt.Rows[0][0];
                    Graphics.Config.FileChanger fc = new KJ128NMainRun.Graphics.Config.FileChanger();
                    if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\DMap"))
                    {
                        System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\DMap");
                    }
                    fc.CreateFile(Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString(), buffer);
                    this.MapGis.MapFilePath = Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString();
                    System.IO.File.Delete(Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法识别的图片!", "提示", MessageBoxButtons.OK);
                    return false;
                }
                try
                {
                    if (Convert.ToInt32(ntbMin.Text) > Convert.ToInt32(ntbMax.Text))
                        throw new Exception();
                    this.MapGis.MinWidth = Convert.ToInt32(ntbMin.Text);
                    this.MapGis.MaxWidth = Convert.ToInt32(ntbMax.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("图层显示范围没有配置或配置不正确,请检查!", "提示", MessageBoxButtons.OK);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("存取文件异常!", "提示", MessageBoxButtons.OK);
                return false;
            }
            AddSelectedStations();
            //LoadStatic();
            HasMonied = true;
            MapGis.FlashAll();
            pnl2.Visible = true;
            pnl3.Visible = true;
            return true;
        }

        private void dgvStations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1 && e.ColumnIndex != -1)
            //{
            //    if (((DataGridViewCheckBoxCell)dgvStations.Rows[e.RowIndex].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgvStations.Rows[e.RowIndex].Cells[0]).TrueValue)
            //    {
            //        ((DataGridViewCheckBoxCell)dgvStations.Rows[e.RowIndex].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgvStations.Rows[e.RowIndex].Cells[0]).FalseValue;
            //    }
            //    if (((DataGridViewCheckBoxCell)dgvStations.Rows[e.RowIndex].Cells[0]).Value == ((DataGridViewCheckBoxCell)dgvStations.Rows[e.RowIndex].Cells[0]).FalseValue)
            //    {
            //        ((DataGridViewCheckBoxCell)dgvStations.Rows[e.RowIndex].Cells[0]).Value = ((DataGridViewCheckBoxCell)dgvStations.Rows[e.RowIndex].Cells[0]).TrueValue;
            //    }
            //    MessageBox.Show(dgvStations.Rows[e.RowIndex].Cells[1].Value.ToString());
            //    ShowMap();
            //}
        }

        public void btnClose_Click(object sender, EventArgs e)
        {
            //btnSave_Click(this, new EventArgs());
            if (IsSave)
            {
                FrmConfig.ReFlashDivDt();
                this.Close();
            }
            else
            {
                if (MessageBox.Show("尚未保存图层,是否退出?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FrmConfig.ReFlashDivDt();
                    this.Close();
                }
            }
        }

        private void dgvStations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (dgvStations.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (dgvStations.Rows[e.RowIndex].Cells[0].Value.ToString()=="0")
                    {
                        dgvStations.Rows[e.RowIndex].Cells[0].Value = 1;
                    }
                    else
                    {
                        dgvStations.Rows[e.RowIndex].Cells[0].Value = 0;
                    }
                }
                else
                {
                    dgvStations.Rows[e.RowIndex].Cells[0].Value = 1;
                }
                ShowMap();
            }
        }

        private void txtDivName_KeyPress(object sender, KeyPressEventArgs e)
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
