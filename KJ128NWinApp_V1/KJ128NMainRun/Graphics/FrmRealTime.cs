using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using KJ128NDBTable;

namespace KJ128NMainRun.Graphics
{
    public partial class FrmRealTime : Wilson.Controls.Docking.DockContent
    {
        #region[声明]
        private string MapFilePath;
        private string StationFilePath;
        private string MoverZFilePath;
        private string MoverFFilePath;
        private bool isConfiged=true;
        private bool IsOut = false;

        private Point MousePoint;
        private Point pnlPoint;
        private Timer FlashTimer;
        #endregion

        #region[事件]
        /// <summary>
        /// 初始化
        /// </summary>
        public FrmRealTime()
        {
            InitializeComponent();
            this.MapGis.StationClick += new ZzhaControlLibrary.ZzhaMapGis.ClickStation(MapGis_StationClick);
        }
        /// <summary>
        /// 点击分站事件
        /// </summary>
        /// <param name="EventStation"></param>
        void MapGis_StationClick(ZzhaControlLibrary.Station EventStation)
        {
            if (EventStation.StationState == "正常")
            {
                DataTable dt = new Graphics_RealTimeBLL().GetRealTimeInStationByStationInfo(EventStation.StationID,true);
                cpStationHead.CaptionTitle = EventStation.StationName + "  共检测到" + dt.Rows.Count.ToString() + "人";
                dgvRealTime.DataSource = dt;
                pnlRealTime.Visible = true;
                pnlRealTime.Location = Point.Round(EventStation.StationNowPoint);
            }
        }

        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRealTime_Load(object sender, EventArgs e)
        {            
            try
            {
                trvRealTime.Nodes.Add("qy", "按区域划分");
                trvRealTime.Nodes.Add("gz", "按工种划分");
                trvRealTime.Nodes.Add("bm", "按部门划分");
                pnlRealTime.Visible = false;
                LoadGisMapInfo();
                if (System.IO.File.Exists(MapFilePath))
                {
                    this.MapGis.MapFilePath = MapFilePath;
                    this.MapGis.StationFilePath = StationFilePath;
                }
                else
                {
                    MessageBox.Show("您所配置的图形已经失效,请重新配置后使用..", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (isConfiged)
                {
                    DataTable stationinfodt = new Graphics_StationInfoBLL().GetStationInfo();
                    if (stationinfodt != null && stationinfodt.Rows.Count > 0)
                    {
                        try
                        {
                            for (int i = 0; i < stationinfodt.Rows.Count; i++)
                            {
                                string stationID = stationinfodt.Rows[i][0].ToString() + "." + stationinfodt.Rows[i][1].ToString();
                                string stationName = stationinfodt.Rows[i][2].ToString();
                                float stationheadx = float.Parse(stationinfodt.Rows[i][3].ToString());
                                float stationheady = float.Parse(stationinfodt.Rows[i][4].ToString());
                                string stationstate = stationinfodt.Rows[i][5].ToString();
                                if (this.StationFilePath != null && this.StationFilePath != "")
                                {                                    
                                        if (stationstate == "正常")
                                            this.MapGis.AddStation(stationheadx, stationheady, stationName, stationID, "正常", new Bitmap(StationFilePath));
                                        if (stationstate == "故障")
                                            this.MapGis.AddStation(stationheadx, stationheady, stationName, stationID, stationstate, new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\No-Signal.gif"));
                                        if (stationstate == "休眠")
                                            this.MapGis.AddStation(stationheadx, stationheady, stationName, stationID, stationstate, new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\Station.GIF"));                                  
                                }
                            }
                            MapGis.FalshStations();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("图形系统中部分图片已经不存在", "提示", MessageBoxButtons.OK);
                        }
                    }
                    IsOut = true;
                    LoadRealTimeInfo();
                    IsOut = false;
                    FlashTimer = new Timer();
                    FlashTimer.Interval = 5000;
                    FlashTimer.Tick += new EventHandler(t_Tick);
                    FlashTimer.Start();
                }
                
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("您所配置的图形已经失效,请重新配置后使用..", "提示", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// 时间函数事件 重新载入实时信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void t_Tick(object sender, EventArgs e)
        {
            LoadRealTimeInfo();
        }
        /// <summary>
        /// 重新载入实时事件
        /// </summary>
        private void LoadRealTimeInfo()
        {
            try
            {
                if (IsOut)
                {
                    int allNum = int.Parse(new Graphics_RealTimeBLL().GetEmpInMineCounts());
                    this.labTitle.Text = "实时分布: 共有" + allNum.ToString() + "人下井";
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
                }
                FlashStationInfo();
            }
            catch (Exception ex)
            {
                FlashTimer.Stop();
            }
        }

        private void FlashStationInfo()
        {
            DataTable stationinfodt = new Graphics_StationInfoBLL().GetStationInfo();
            if (stationinfodt != null && stationinfodt.Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < stationinfodt.Rows.Count; i++)
                    {
                        string stationID = stationinfodt.Rows[i][0].ToString() + "." + stationinfodt.Rows[i][1].ToString();
                        string stationName = stationinfodt.Rows[i][2].ToString();
                        float stationheadx = float.Parse(stationinfodt.Rows[i][3].ToString());
                        float stationheady = float.Parse(stationinfodt.Rows[i][4].ToString());
                        string stationstate = stationinfodt.Rows[i][5].ToString();
                        string empnum = "共" + new Graphics_RealTimeBLL().GetRealTimeInStationByStationInfo(stationID,true).Rows.Count.ToString() + "人";
                        if (this.StationFilePath != null && this.StationFilePath != "")
                        {
                            if (stationstate == "正常")
                                this.MapGis.ChangeStationState(stationID, stationstate, empnum, new Bitmap(StationFilePath));
                            if (stationstate == "故障")
                                this.MapGis.ChangeStationState(stationID, stationstate, empnum, new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\No-Signal.gif"));
                            if (stationstate == "休眠")
                                this.MapGis.ChangeStationState(stationID, stationstate, empnum, new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\Station.GIF"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 载入图形系统信息
        /// </summary>
        private void LoadGisMapInfo()
        {
            XmlDocument xmldoc = new XmlDocument();
            if (System.IO.File.Exists(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml"))
            {
                xmldoc.Load(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml");
            }
            else
            {
                MessageBox.Show("图形图形尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
                isConfiged = false;
                return;
            }
            if (xmldoc.SelectSingleNode("//底图").InnerText == null || xmldoc.SelectSingleNode("//底图").InnerText == "")
            {
                MessageBox.Show("图形图形尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
                isConfiged = false;
                return;
            }
            else
            {
                MapFilePath = Application.StartupPath + "\\MapGis\\Map\\" + xmldoc.SelectSingleNode("//底图").InnerText;
            }
            StationFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Signal.gif";
            MoverZFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Zg.GIF";
            MoverFFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Fg.GIF";
        }
        /// <summary>
        /// 人员信息窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cpConfigHead_CloseButtonClick(object sender, EventArgs e)
        {
            pnlRealTime.Visible = false;
        }
        #region[人员信息窗口移动]
        private void cpStationHead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.MousePoint = cpStationHead.PointToScreen(e.Location);
                this.pnlPoint = pnlRealTime.Location;
            }
        }

        private void cpStationHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = cpStationHead.PointToScreen(e.Location);
                this.pnlRealTime.Left = this.pnlPoint.X + p.X - MousePoint.X;
                this.pnlRealTime.Top = this.pnlPoint.Y + p.Y - MousePoint.Y;
            }
        }
        #endregion
        /// <summary>
        /// 弹出窗口单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picInOut_Click(object sender, EventArgs e)
        {
            if (IsOut)
            {
                this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.right;
                this.pnlInOut.Left = this.pnlInOut.Left - this.pnlEmp.Width;
                IsOut = false;
            }
            else
            {
                this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.left;
                this.pnlInOut.Left = this.pnlInOut.Left + this.pnlEmp.Width;
                IsOut = true;
            }
        }
        #endregion

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (this.btnShowAll.Text == "显示读卡分站")
            {
                this.btnShowAll.Text = "隐藏读卡分站";
                this.MapGis.IsShowAllStations(true);
            }
            else
            {
                this.btnShowAll.Text = "显示读卡分站";
                this.MapGis.IsShowAllStations(false);
            }
        }

        private void labColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.labColor.BackColor = colorDialog.Color;
                this.MapGis.StationStrColor = colorDialog.Color;
                this.MapGis.FlashAll();
            }
        }

       
            //this.MapGis.ChangeStationState("1.1", "故障", Image.FromFile("e:\\Map.jpg"));
        
    }
}