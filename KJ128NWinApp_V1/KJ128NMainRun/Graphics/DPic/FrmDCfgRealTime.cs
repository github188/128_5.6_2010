using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using KJ128NDBTable;
using KJ128NModel;
using System.Collections;
using KJ128NMainRun.Graphics.Config;

namespace KJ128NMainRun.Graphics.DPic
{
    public partial class FrmDCfgRealTime : Wilson.Controls.Docking.DockContent
    {
        #region[声明]
        private string MapFilePath;
        private string StationFilePath;
        private string MoverZFilePath;
        private string MoverFFilePath;
        private bool isConfiged=true;
        private bool IsOut = false;
        private bool ReIsOut = false;
        private bool HRIsOut = false;
        private DateTime hisStartTime;
        private DateTime hisEndTime;
        private bool isRealTime = true;
        private bool ShowedEmpPosition = false;
        private bool IsHis = false;
        private bool ShowStationDgv = true;
        private string FileID = string.Empty;

        private Point MousePoint;
        private Point pnlPoint;
        private Timer FlashTimer;
        private Graphics_DpicBLL dpicbll = new Graphics_DpicBLL();
        private Graphics_His_EmpPlaceBLL ghepb = new Graphics_His_EmpPlaceBLL();
        private Graphics_RealTimeBLL grtb = new Graphics_RealTimeBLL();
        #endregion

        #region[事件]
        /// <summary>
        /// 初始化
        /// </summary>
        public FrmDCfgRealTime()
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
            if (ShowStationDgv)
            {
                if (EventStation.StationState == "正常" && EventStation.HasShowed)
                {
                    DataTable dt;
                    if (isRealTime)
                    {
                        dt = new Graphics_RealTimeBLL().GetRealTimeInStationByStationInfo(EventStation.StationID,true);
                        cpStationHead.CaptionTitle = EventStation.StationName + "  共检测到" + dt.Rows.Count.ToString() + "人";
                    }
                    else
                    {
                        dt = ghepb.GetHisStationHeadInfo(hisStartTime, hisEndTime, EventStation.StationID);
                        cpStationHead.CaptionTitle = EventStation.StationName + "  共检测到" + dt.Rows.Count.ToString() + "人次";
                    }
                    dgvRealTime.DataSource = dt;
                    pnlRealTime.Visible = true;
                    pnlRealTime.Location = Point.Round(EventStation.StationNowPoint);
                }
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
                CreateDir();
                trvRealTime.Nodes.Add("qy", "按区域划分");
                trvRealTime.Nodes.Add("gz", "按工种划分");
                trvRealTime.Nodes.Add("bm", "按部门划分");
                trvStation.Nodes.Add("cf", "分站状态");
                this.MoverZFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Zg.GIF";
                this.MoverFFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Fg.GIF";
                pnlRealTime.Visible = false;
                pnlRtEmpPosition.Left = 0 - PicRtEmpPosition.Left;
                pnlHRoute.Left = 0 - picHRoute.Left;
                this.StationFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Signal.gif";
                SetPnlTimePickerVisible(false);          
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("您所配置的图形已经失效,请重新配置后使用..", "提示", MessageBoxButtons.OK);
            }
        }

        private void CreateDir()
        {
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\Map"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\Map");
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\MapConfigFiles"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\MapConfigFiles");
        }

        private void SetPnlTimePickerVisible(bool flag)
        {
            if (flag)
            {
                this.pnlTimePick.Visible = flag;
                this.pnlEmp.Height = pnlContainer.Height - pnlTimePick.Height;
                this.dtpStartTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                this.dtpEndTime.Value = DateTime.Now;
            }
            else
            {
                this.pnlTimePick.Visible = flag;
                this.pnlEmp.Height = pnlContainer.Height;
            }
        }

        private void StartTimer()
        {
            if (FlashTimer == null)
            {
                FlashTimer = new Timer();
                FlashTimer.Interval = 10000;
                FlashTimer.Tick += new EventHandler(t_Tick);
                FlashTimer.Start();
            }
        }

        private void LoadRealTimeStation()
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
                if (true)
                {
                    int allNum = 0;
                    try
                    {
                        if (isRealTime)
                        {
                            allNum = int.Parse(new Graphics_RealTimeBLL().GetEmpInMineCounts());
                            this.labTitle.Text = "实时分布: 共有" + allNum.ToString() + "人下井";
                        }
                        else
                        {
                            allNum = Convert.ToInt32(ghepb.GetHisEmpNum(this.hisStartTime, this.hisEndTime));
                            this.labTitle.Text = "该时段共有" + allNum.ToString() + "人下井";
                        }
                    }
                    catch (Exception ex)
                    {
                        this.labTitle.Text = "共有" + allNum.ToString() + "人下井";
                    }
                    List<string> list;
                    if (isRealTime)
                    {
                        list = new Graphics_AreaRealtimeBLL().GetAreaInfoAndEmpcount();
                    }
                    else
                    {
                        list = ghepb.GetAllAreaEmpNum(hisStartTime, hisEndTime);
                    }
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
                    if (isRealTime)
                        list = new Graphics_RealTimeBLL().GetEmpWorkTypeNumRealTime(allNum);
                    else
                        list = ghepb.GetHisEmpWorkTypeNum(allNum, this.hisStartTime, this.hisEndTime);
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
                    if (isRealTime)
                        list = new Graphics_RealTimeBLL().GetRealTimeEmpNumByDept();
                    else
                        list = ghepb.GetHisEmpNumByDept(hisStartTime, hisEndTime);
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
                    if (list.Count >= trvStation.Nodes["cf"].Nodes.Count)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (trvStation.Nodes["cf"].Nodes.ContainsKey("cf" + i.ToString()))
                                trvStation.Nodes["cf"].Nodes["cf" + i.ToString()].Text = list[i];
                            else
                                trvStation.Nodes["cf"].Nodes.Add("cf" + i.ToString(), list[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < trvStation.Nodes["cf"].Nodes.Count; i++)
                        {
                            if (i < list.Count)
                                trvStation.Nodes["cf"].Nodes["cf" + i.ToString()].Text = list[i];
                            else
                                trvStation.Nodes["cf"].Nodes.RemoveAt(i);
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
            if (!IsHis)
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
                            string empnum;
                            if (isRealTime)
                                empnum = "共" + new Graphics_RealTimeBLL().GetRealTimeInStationByStationInfo(stationID,true).Rows.Count.ToString() + "人";
                            else
                                empnum = "共" + ghepb.GetHisStationHeadEmpNum(hisStartTime, hisEndTime, stationID) + "人次";
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
                        for (int i = 0; i < MapGis.StaticList.Count; i++)
                        {
                            if (MapGis.StaticList[i].Type != ZzhaControlLibrary.StaticType.Image)
                            {
                                string key = MapGis.StaticList[i].NameKey;
                                try
                                {
                                    if (key == "zong")
                                    {
                                        MapGis.StaticList[i].StaticName = labTitle.Text;
                                    }
                                    else
                                    {

                                        if (key != "null")
                                        {
                                            if (key.Substring(0, 2) == "cf")
                                            {
                                                string text = trvStation.Nodes[key.Substring(0, 2)].Nodes[key].Text;
                                                MapGis.StaticList[i].StaticName = text;
                                            }
                                            else
                                            {
                                                string text = trvRealTime.Nodes[key.Substring(0, 2)].Nodes[key].Text;
                                                MapGis.StaticList[i].StaticName = text;
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MapGis.StaticList[i].StaticName = "已失效";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
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
                MapFilePath = xmldoc.SelectSingleNode("//底图").InnerText;
            }
            if (xmldoc.SelectSingleNode("//分站").InnerText == null || xmldoc.SelectSingleNode("//分站").InnerText == "")
            {
                MessageBox.Show("图形图形尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
                isConfiged = false;
                return;
            }
            else
            {
                StationFilePath = xmldoc.SelectSingleNode("//分站").InnerText;
            }
            if (xmldoc.SelectSingleNode("//正向移动图").InnerText == null || xmldoc.SelectSingleNode("//正向移动图").InnerText == "")
            {
                MessageBox.Show("图形图形尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
                isConfiged = false;
                return;
            }
            else
            {
                MoverZFilePath = xmldoc.SelectSingleNode("//正向移动图").InnerText;
            }
            if (xmldoc.SelectSingleNode("//反向移动图").InnerText == null || xmldoc.SelectSingleNode("//反向移动图").InnerText == "")
            {
                MessageBox.Show("图形图形尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
                isConfiged = false;
                return;
            }
            else
            {
                MoverFFilePath = xmldoc.SelectSingleNode("//反向移动图").InnerText;
            }
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

        private void tsmiFileOpen_Click(object sender, EventArgs e)
        {
            frmDFileDialog openfileDlg = new frmDFileDialog(false);
            if (openfileDlg.ShowDialog() == DialogResult.OK)
            {
                this.MapGis.UseDiv = true;
                this.MapGis.ReSet();
                XmlDocument xmldoc = new XmlDocument();
                DataTable bufferdt = dpicbll.GetXmlByFileName(openfileDlg.SafeFileName);
                byte[] xmlbytes = (byte[])bufferdt.Rows[0][0];
                FileChanger filechanger = new FileChanger();
                xmldoc = filechanger.BytesToXml(xmlbytes);
                XmlNode node = xmldoc.SelectSingleNode("//Map");
                this.FileID = node.InnerText;
                //if (node != null)
                //{
                //    try
                //    {
                //        CreateWmf(mapbytes, Application.StartupPath + node.InnerText);
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("读取图形系统配置文件发生错误,可能配置文件未完成或已损坏!", "提示", MessageBoxButtons.OK);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("读取图形系统配置文件发生错误,可能配置文件未完成或已损坏!", "提示", MessageBoxButtons.OK);
                //}
                if (!new MapXml().LoadAllMapConfig(xmldoc, MapGis))
                {
                    pnlInOut.Visible = false;
                    SetMenuEnabel(false);
                    MapGis.Refresh();
                    return;
                }
            }
            else
            {
                return;
            }
            //this.MapGis.StationClick += new ZzhaControlLibrary.ZzhaMapGis.ClickStation(MapGis_StationClick);
            StartTimer();
            IsOut = true;
            LoadRealTimeInfo();
            IsOut = false;
            pnlInOut.Visible = true;
            SetMenuEnabel(true);
        }

        private void SetMenuEnabel(bool flag)
        {
            tsmiDoWork.Enabled = flag;
            tsmiRealTime.Enabled = flag;
            tsmiHistroy.Enabled = flag;
            tsmiRTemp.Enabled = flag;
            tsmiHisRoute.Enabled = flag;
        }

        private void CreateWmf(byte[] filebyte, string filepath)
        {
            new FileChanger().CreateFile(filepath, filebyte);
        }

        private void tsmiFileClose_Click(object sender, EventArgs e)
        {
            MapGis.ReSet();
            LoadRealTimeStation();
            LoadRealTimeInfo();
            MapGis.UseDiv = false;
            MapGis.FlashAll();
            MapGis.Refresh();
            pnlInOut.Visible = false;
            SetMenuEnabel(false);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiRealTime_Click(object sender, EventArgs e)
        {
            HidePnls();
            pnlInOut.Visible = true;
            SetPnlTimePickerVisible(false);
            this.isRealTime = true;
            if (IsOut)
            {
                LoadRealTimeInfo();
            }
            else
            {
                IsOut = true;
                LoadRealTimeInfo();
                IsOut = false;
            }
            ShowStationDgv = true;
        }

        private void tsmiHistroy_Click(object sender, EventArgs e)
        {
            HidePnls();
            pnlInOut.Visible = true;
            SetPnlTimePickerVisible(true);
            if (IsOut)
            {
                LoadRealTimeInfo();
            }
            else
            {
                IsOut = true;
                LoadRealTimeInfo();
                IsOut = false;
            }
            IsHis = true;
            ShowStationDgv = true;
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            this.dtpEndTime.MinDate = dtpStartTime.Value;
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            this.dtpStartTime.MaxDate = dtpEndTime.Value;
        }

        private bool CheckDatetime()
        {
            DateTime buffertime = dtpStartTime.Value;
            if ((dtpEndTime.Value - dtpStartTime.Value).TotalHours > 12)
                return false;
            else
                return true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!CheckDatetime())
            {
                MessageBox.Show("查询时间差超过12小时或其他未知错误!", "提示", MessageBoxButtons.OK);
                return;
            }
            this.hisStartTime = dtpStartTime.Value;
            this.hisEndTime = dtpEndTime.Value;
            this.isRealTime = false;
            IsHis = false;
            if (IsOut)
            {
                LoadRealTimeInfo();
            }
            else
            {
                IsOut = true;
                LoadRealTimeInfo();
                IsOut = false;
            }
            IsHis = true;
        }

        private void HidePnls()
        {
            if (ShowedEmpPosition)
            {
                MapGis.StaticList.RemoveAt(MapGis.StaticList.Count - 1);
                ShowedEmpPosition = false;
            }
            IsHis = false;
            if (IsOut)
                this.picInOut_Click(this, new EventArgs());
            this.pnlInOut.Visible = false;
            if (ReIsOut)
                this.PicRtEmpPosition_Click(this, new EventArgs());
            this.pnlRtEmpPosition.Visible = false;
            if (HRIsOut)
                this.picHRoute_Click(this, new EventArgs());
            this.pnlHRoute.Visible = false;
            this.MapGis.StopMoving();
            this.ShowStationDgv = false;
        }

        private void PicRtEmpPosition_Click(object sender, EventArgs e)
        {
            if (ReIsOut)
            {
                PicRtEmpPosition.Image = global::KJ128NMainRun.Properties.Resources.right;
                pnlRtEmpPosition.Left = 0 - PicRtEmpPosition.Left;
                ReIsOut = false;
            }
            else
            {
                PicRtEmpPosition.Image = global::KJ128NMainRun.Properties.Resources.left;
                pnlRtEmpPosition.Left = 0;
                ReIsOut = true;
            }
        }

        private void LoadRTempInfo()
        {
            DataTable dt = grtb.GetAllDept();
            if (dt != null)
            {
                cmbREdept.Items.Clear();
                cmbREdept.Values.Clear();
                cmbREdept.AddItem("所有部门", "none");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbREdept.AddItem(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                }
                cmbREdept.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("提取部门信息时发生错误,请检查部门信息是否完整!", "提示", MessageBoxButtons.OK);
            }
        }

        private void tsmiRTemp_Click(object sender, EventArgs e)
        {
            HidePnls();
            isRealTime = true;
            LoadRTempInfo();
            if (IsOut)
            {
                LoadRealTimeInfo();
            }
            else
            {
                IsOut = true;
                LoadRealTimeInfo();
                IsOut = false;
            }
            IsHis = true;
            pnlRtEmpPosition.Visible = true;
        }

        private void cmbREdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbREemp.Items.Clear();
            lsbREemp.Values.Clear();
            DataTable dt = grtb.GetEmpByDeptID(cmbREdept.SelectedValue);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lsbREemp.AddItem(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
            }
        }

        private void lsbREemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ShowedEmpPosition)
            {
                MapGis.StaticList.RemoveAt(MapGis.StaticList.Count - 1);
                ShowedEmpPosition = false;
            }
            DataTable dt = grtb.GetRtEmpPositionByID(lsbREemp.SelectedValue);
            if (dt != null && dt.Rows.Count > 0)
            {
                string stationheadplace = dt.Rows[0][4].ToString();
                if (dpicbll.StationExitsByFileIDandStationPlace(FileID, stationheadplace))
                {
                    string info = "标识卡:" + dt.Rows[0][0].ToString() + "\r\n姓名:" + dt.Rows[0][1].ToString() + "\r\n部门:" + dt.Rows[0][2].ToString() + "\r\n时间:" + dt.Rows[0][3].ToString() + "\r\n地点:" + dt.Rows[0][4].ToString();
                    float x = float.Parse(dt.Rows[0][5].ToString());
                    float y = float.Parse(dt.Rows[0][6].ToString());
                    this.MapGis.AddStaticObj(x, y, new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\Zg.GIF"), "all", 50, 50, Application.StartupPath + "\\MapGis\\ShineImage\\Zg.GIF", info, "", ZzhaControlLibrary.StaticType.ImageAndWord, Label.DefaultFont, labRtpColor.BackColor);
                    ShowedEmpPosition = true;
                }
            }
        }

        private void picHRoute_Click(object sender, EventArgs e)
        {
            if (HRIsOut)
            {
                picHRoute.Image = global::KJ128NMainRun.Properties.Resources.right;
                pnlHRoute.Left = 0 - picHRoute.Left;
                HRIsOut = false;
            }
            else
            {
                picHRoute.Image = global::KJ128NMainRun.Properties.Resources.left;
                pnlHRoute.Left = 0;
                HRIsOut = true;
            }
        }

        private void tsmiHisRoute_Click(object sender, EventArgs e)
        {
            HidePnls();
            this.pnlHRoute.Visible = true;
            IsHis = true;
            LoadHisInfo();
        }

        #region[历史轨迹回放]
        #region[声明]
        ///// <summary>
        ///// 地图路径
        ///// </summary>
        //private string MapFilePath;
        ///// <summary>
        ///// 分站图片路径
        ///// </summary>
        //private string StationFilePath;
        ///// <summary>
        ///// 移动者正向移动图片路径
        ///// </summary>
        //private string MoverZFilePath;
        ///// <summary>
        ///// 移动者反向移动图片路径
        ///// </summary>
        //private string MoverFFilePath;
        /// <summary>
        /// 雇员表
        /// </summary>
        private DataTable EmpDt;
        /// <summary>
        /// 已选中的移动者列表
        /// </summary>
        private List<EmpMoverModel> EmpMoverList = new List<EmpMoverModel>();
        /// <summary>
        /// 部门表
        /// </summary>
        private DataTable BanDeptDt;
        /// <summary>
        /// 当前选中的部门ID
        /// </summary>
        private string Bandeptid;
        /// <summary>
        /// 当前选中的部门班次表
        /// </summary>
        private DataTable classdt;
        /// <summary>
        /// 当前选中日期中所有班次所涉及的雇员表
        /// </summary>
        private DataTable classempdt;
        /// <summary>
        /// 雇员零时表
        /// </summary>
        private DataTable EmpDtBuffer;
        ///// <summary>
        ///// 当前图形系统是否已配置完成
        ///// </summary>
        //private bool isConfiged = true;
        /// <summary>
        /// 没有历史轨迹的人员列表
        /// </summary>
        List<string> NoRoutePeoples = new List<string>();
        /// <summary>
        /// 历史路径生成线程
        /// </summary>
        System.Threading.Thread HistoryThread;
        /// <summary>
        /// 选项卡INDEX
        /// </summary>
        private int PageIndex = 0;
        #endregion
        #region[事件]
        private void LoadHisInfo()
        {
            try
            {
                dtpStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                //LoadGisMapInfo();
                //if (System.IO.File.Exists(MapFilePath))
                //{
                //    this.MapGis.MapFilePath = MapFilePath;
                //    this.MapGis.StationFilePath = StationFilePath;
                //}
                //else
                //{
                //    MessageBox.Show("您所配置的图形已经失效,请重新配置后使用..", "提示", MessageBoxButtons.OK);
                //    return;
                //}
                //this.MapGis.UseGif = true;
                DataTable stationinfodt = new Graphics_StationInfoBLL().GetStationInfo();
                if (stationinfodt != null && stationinfodt.Rows.Count > 0)
                {
                    for (int i = 0; i < stationinfodt.Rows.Count; i++)
                    {
                        string stationID = stationinfodt.Rows[i][0].ToString() + "." + stationinfodt.Rows[i][1].ToString();
                        string stationName = stationinfodt.Rows[i][2].ToString();
                        //float stationheadx = float.Parse(stationinfodt.Rows[i][3].ToString());
                        //float stationheady = float.Parse(stationinfodt.Rows[i][4].ToString());
                        //if (StationFilePath != null && StationFilePath != "")
                        //    this.MapGis.AddStation(stationheadx, stationheady, stationName, stationID, "正常", new Bitmap(StationFilePath));
                        this.MapGis.ChangeStationState(stationID,"正常","",new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\Signal.gif"));
                    }
                    this.MapGis.FalshStations();
                }
                BanDeptDt = new Graphics_RealTimeBLL().GetAllDept();
                if (BanDeptDt != null && BanDeptDt.Rows.Count > 0)
                {
                    cmbDept.Items.Add("全部部门");
                    cmbDept.SelectedIndex = 0;
                    for (int i = 0; i < BanDeptDt.Rows.Count; i++)
                    {
                        cmbDept.Items.Add(BanDeptDt.Rows[i][0]);
                    }
                    for (int i = 0; i < BanDeptDt.Rows.Count; i++)
                    {
                        cmbBanDept.Items.Add(BanDeptDt.Rows[i][0]);
                    }
                    cmbBanDept.SelectedIndex = 0;
                    cmbSpeed.SelectedIndex = 0;
                }
                this.MapGis.MoveEnded += new ZzhaControlLibrary.ZzhaMapGis.MoveingEnd(MapGis_MoveEnded);
                EmpDt = new Graphics_RealTimeBLL().GetAllEmp();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("您所配置的图形已经失效,请重新配置后使用..", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// MAPGIS中移动结束事件
        /// </summary>
        void MapGis_MoveEnded()
        {
            if (MapGis.IsMoving)
                this.btnHistoryRoute.Enabled = false;
            else
                this.btnHistoryRoute.Enabled = true;
        }

        /// <summary>
        /// 部门下拉列表框选择项发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlashPeople();
        }

        /// <summary>
        /// 重新载入雇员进listbox中，按所选择的部门及已经选中的移动者
        /// </summary>
        private void FlashPeople()
        {
            string deptname = cmbDept.SelectedItem.ToString();
            if (deptname != "")
            {
                if (deptname == "全部部门")
                {
                    EmpDtBuffer = new Graphics_RealTimeBLL().GetAllEmp();
                }
                else
                {
                    EmpDtBuffer = new Graphics_RealTimeBLL().GetEmpByDeptName(deptname);
                }
                this.lsbPeople.Items.Clear();
                this.lsbPeople.Values.Clear();
                for (int i = 0; i < EmpDtBuffer.Rows.Count; i++)
                {
                    string item = EmpDtBuffer.Rows[i][0].ToString();
                    string value = EmpDtBuffer.Rows[i][1].ToString();
                    lsbPeople.AddItem(EmpDtBuffer.Rows[i][0].ToString(), EmpDtBuffer.Rows[i][1].ToString());
                }
                for (int i = 0; i < lsbSelectPeople.Items.Count; i++)
                {
                    if (lsbPeople.Values.Contains(lsbSelectPeople.Values[i]))
                    {
                        lsbPeople.Items.RemoveAt(lsbPeople.Values.IndexOf(lsbSelectPeople.Values[i]));
                        lsbPeople.Values.Remove(lsbSelectPeople.Values[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 选择雇员进移动者列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpSelect_Click(object sender, EventArgs e)
        {
            if (lsbSelectPeople.Items.Count < 10)
            {
                if (lsbPeople.SelectedItem != null)
                {
                    if (lsbPeople.SelectedItems.Count > 0)
                    {
                        for (int i = lsbPeople.SelectedItems.Count; i > 0; i--)
                        {
                            if (lsbSelectPeople.Items.Count < 10)
                            {
                                int index = lsbPeople.SelectedIndex;
                                EmpMoverList.Add(new EmpMoverModel(lsbPeople.SelectedItem.ToString(), lsbPeople.SelectedValue));
                                lsbSelectPeople.AddItem(lsbPeople.SelectedItem.ToString(), lsbPeople.SelectedValue);
                                lsbPeople.Values.Remove(lsbPeople.SelectedValue);
                                lsbPeople.Items.RemoveAt(lsbPeople.SelectedIndex);
                                lsbPeople.SelectedIndex = index > (lsbPeople.Items.Count - 1) ? lsbPeople.Items.Count - 1 : index;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 从移动者列表删除雇员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsbSelectPeople.SelectedItem != null)
            {
                if (lsbSelectPeople.SelectedItems.Count > 0)
                {
                    for (int j = lsbSelectPeople.SelectedItems.Count; j > 0; j--)
                    {
                        //for (int i = 0; i < EmpDt.Rows.Count; i++)
                        //{
                        //    if (EmpDt.Rows[i][0].ToString() == lsbSelectPeople.SelectedItem.ToString())
                        //    {
                        //        //EmpHashTable.Remove(lsbSelectPeople.SelectedItem.ToString());

                        //        break;
                        //    }
                        //}
                        RemoveList(new EmpMoverModel(lsbSelectPeople.SelectedItem.ToString(), lsbSelectPeople.SelectedValue));
                        int index = lsbSelectPeople.SelectedIndex;
                        lsbSelectPeople.Values.Remove(lsbSelectPeople.SelectedValue);
                        lsbSelectPeople.Items.RemoveAt(lsbSelectPeople.SelectedIndex);
                        FlashPeople();
                        lsbSelectPeople.SelectedIndex = index > (lsbSelectPeople.Items.Count - 1) ? lsbSelectPeople.Items.Count - 1 : index;
                    }
                }
            }
        }

        /// <summary>
        /// 从移动者列表中删除雇员
        /// </summary>
        /// <param name="emp">要删除的雇员类</param>
        private void RemoveList(EmpMoverModel emp)
        {
            foreach (EmpMoverModel empm in EmpMoverList)
            {
                if (empm.EmpID == emp.EmpID && empm.EmpName == emp.EmpName)
                {
                    EmpMoverList.Remove(empm);
                    break;
                }
            }
        }

        /// <summary>
        /// 委托  开始移动
        /// </summary>
        private delegate void StartMoving();
        /// <summary>
        /// 开始移动方法  线程安全
        /// </summary>
        private void MapgisStartMoving()
        {
            if (MapGis.InvokeRequired)
            {
                MapGis.Invoke(new StartMoving(MapGis.StartMoving));
            }
            else
            {
                MapGis.StartMoving();
            }
        }

        /// <summary>
        /// 设置历史轨迹按钮可用与不可用
        /// </summary>
        /// <param name="value">true为可用，false为不可用</param>
        private void SetHBtnEnabel(bool value)
        {
            this.btnHistoryRoute.Enabled = value;
        }
        /// <summary>
        /// 委托 设置历史轨迹按钮可用与不可用
        /// </summary>
        /// <param name="value">true为可用，false为不可用</param>
        private delegate void SetBtnEnabel(bool value);
        /// <summary>
        /// 设置历史轨迹按钮可用与不可用 线程安全 
        /// </summary>
        /// <param name="value">true为可用，false为不可用</param>
        private void SetHistoryBtnEnabel(bool value)
        {
            if (btnHistoryRoute.InvokeRequired)
            {
                btnHistoryRoute.Invoke(new SetBtnEnabel(SetHBtnEnabel), new object[] { value });
            }
            else
            {
                SetHBtnEnabel(value);
            }
        }

        /// <summary>
        /// 线程运行  生成轨迹
        /// </summary>
        private void ThreadRun()
        {
            try
            {
                SetHistoryBtnEnabel(false);
                string strOutMessage;
                int step = 100 / EmpMoverList.Count;
                frmWait f = new frmWait("正在生成历史轨迹,请稍候....");
                f.Show();
                if (this.PageIndex == 0)
                {
                    #region[时间选择]
                    foreach (EmpMoverModel emm in EmpMoverList)
                    {
                        f.Refresh();
                        //注销
                        //List<string> list = dpicbll.GetRouteInfoByEmpID(emm.EmpID, dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"), int.Parse(FileID));
                        strOutMessage = string.Empty;
                        List<string> list = dpicbll.GetRouteInfoByEmpID(emm.EmpID, dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"), int.Parse(FileID),out strOutMessage);
                        if (list != null && list.Count >= 5)
                            this.MapGis.AddMover(list[0], list[1], list[2], list[3], list[4], MoverZFilePath, MoverFFilePath);
                        else
                            NoRoutePeoples.Add(emm.EmpName);
                        f.PgbWait.Value += step;
                    }
                    if (NoRoutePeoples.Count == 0 && EmpMoverList.Count != 0)
                    {
                        //this.MapGis.StartMoving();
                        //this.btnHistoryRoute.Enabled = false;
                        MapgisStartMoving();
                    }
                    else
                    {
                        if (NoRoutePeoples.Count == EmpMoverList.Count)
                        {
                            MessageBox.Show("选择的人员均没有可播放的历史轨迹!", "提示", MessageBoxButtons.OK);
                            SetHistoryBtnEnabel(true);
                        }
                        else
                        {
                            string message = string.Empty;
                            for (int i = 0; i < NoRoutePeoples.Count; i++)
                            {
                                if (i == 0)
                                    message = NoRoutePeoples[i];
                                else
                                    message = message + "," + NoRoutePeoples[i];
                            }
                            if (message.Length > 0)
                                message.Remove(message.Length - 2);
                            MessageBox.Show(message + "等人员没有可播放的历史轨迹!", "提示", MessageBoxButtons.OK);
                            MapgisStartMoving();
                        }
                    }
                    #endregion
                }
                else
                {
                    #region[班次选择]
                    foreach (EmpMoverModel emm in EmpMoverList)
                    {
                        f.Refresh();
                        //Czlt-2012-04-20 注销
                        //List<string> list = dpicbll.GetRouteInfoByEmpID(emm.EmpID, dtpban.Value.ToString("yyyy-MM-dd 00:00:00"), dtpban.Value.ToString("yyyy-MM-dd 23:59:59"), int.Parse(FileID));
                        strOutMessage = string.Empty;
                        List<string> list = dpicbll.GetRouteInfoByEmpID(emm.EmpID, dtpban.Value.ToString("yyyy-MM-dd 00:00:00"), dtpban.Value.ToString("yyyy-MM-dd 23:59:59"), int.Parse(FileID),out strOutMessage);
                        if (list != null && list.Count >= 5)
                            this.MapGis.AddMover(list[0], list[1], list[2], list[3], list[4], MoverZFilePath, MoverFFilePath);
                        else
                            NoRoutePeoples.Add(emm.EmpName);
                        f.PgbWait.Value += step;
                    }
                    if (NoRoutePeoples.Count == 0)
                    {
                        MapgisStartMoving();
                    }
                    else
                    {
                        if (NoRoutePeoples.Count == EmpMoverList.Count)
                        {
                            MessageBox.Show("选择的所有人员均没有可播放的历史轨迹!", "提示", MessageBoxButtons.OK);
                            SetHistoryBtnEnabel(true);
                        }
                        else
                        {
                            string message = string.Empty;
                            foreach (string str in NoRoutePeoples)
                            {
                                message = message + str + ",";
                            }
                            if (message.Length > 0)
                                message.Remove(message.Length - 1);
                            MessageBox.Show(message + "等人员没有可播放的历史轨迹!", "提示", MessageBoxButtons.OK);
                            MapgisStartMoving();
                        }
                    }
                    #endregion
                }
                f.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("历史轨迹生成失败!", "提示", MessageBoxButtons.OK);
                SetHistoryBtnEnabel(true);
            }
            finally
            {
                NoRoutePeoples.Clear();
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        /// <summary>
        /// 历史轨迹按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoryRoute_Click(object sender, EventArgs e)
        {
            if (isConfiged)
            {
                if (EmpMoverList.Count > 0)
                {
                    HistoryThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadRun));
                    HistoryThread.Start();
                }
                else
                {
                    MessageBox.Show("请先选择人员!", "提示", MessageBoxButtons.OK);
                }
            }
        }
        /// <summary>
        /// 速度变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZzhaControlLibrary.ZzhaMapGis.Speed = Convert.ToInt32(this.cmbSpeed.SelectedItem);
        }
        /// <summary>
        /// 班次 部门选择项变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBanDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bandeptid = BanDeptDt.Rows[cmbBanDept.SelectedIndex][1].ToString();
            classdt = new Graphics_RealTimeBLL().GetClassByDeptID(Bandeptid);
            if (classdt != null && classdt.Rows.Count > 0)
            {
                cmbBan.Items.Clear();
                for (int i = 0; i < classdt.Rows.Count; i++)
                {
                    cmbBan.Items.Add(classdt.Rows[i][0].ToString());
                }
                cmbBan.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 班次 班次发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            BanFlashPeople();
        }
        /// <summary>
        /// 班次 重新载入雇员 根据班次及部门
        /// </summary>
        private void BanFlashPeople()
        {
            DataTable dt = null;
            lsbBanPeople.Items.Clear();
            lsbBanPeople.Values.Clear();
            DataSet ds = new Graphics_RealTimeBLL().GetEmpByDeptAndClass(int.Parse(Bandeptid), dtpban.Value, classdt.Rows[cmbBan.SelectedIndex][1].ToString());
            if (ds != null)
                classempdt = ds.Tables[0];
            classempdt = DistinctDataTable(classempdt, 0);
            for (int i = 0; i < classempdt.Rows.Count; i++)
            {
                lsbBanPeople.AddItem(classempdt.Rows[i]["EmployeeName"].ToString(), classempdt.Rows[i]["EmployeeId"].ToString());
            }
            for (int i = 0; i < lsbBanSelectpeople.Items.Count; i++)
            {
                if (lsbBanPeople.Values.Contains(lsbBanSelectpeople.Values[i]))
                {
                    lsbBanPeople.Items.RemoveAt(lsbBanPeople.Values.IndexOf(lsbBanSelectpeople.Values[i]));
                    lsbBanPeople.Values.Remove(lsbBanSelectpeople.Values[i]);
                }
            }
        }

        private DataTable DistinctDataTable(DataTable dt, int index)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i][index].ToString().Trim();
                if (ht.Contains(dt.Rows[i][index].ToString().Trim()))
                {
                    dt.Rows.RemoveAt(i);
                    i--;
                }
                else
                {
                    ht.Add(dt.Rows[i][index].ToString().Trim(), 1);
                }
            }
            return dt;
        }
        /// <summary>
        /// 班次 选择雇员进移动者表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBanselect_Click(object sender, EventArgs e)
        {
            if (lsbBanSelectpeople.Items.Count < 10)
            {
                if (lsbBanPeople.SelectedItems.Count > 0)
                {
                    for (int j = lsbBanPeople.SelectedItems.Count; j > 0; j--)
                    {
                        if (lsbBanSelectpeople.Items.Count < 10)
                        {
                            string empid = string.Empty;
                            for (int i = 0; i < EmpDt.Rows.Count; i++)
                            {
                                if (EmpDt.Rows[i][0].ToString() == lsbBanPeople.SelectedItem.ToString())
                                {
                                    empid = EmpDt.Rows[i][1].ToString();
                                    break;
                                }
                            }
                            if (empid == "")
                            {
                                for (int i = 0; i < classempdt.Rows.Count; i++)
                                {
                                    if (classempdt.Rows[i]["EmployeeName"].ToString() == lsbBanPeople.SelectedItem.ToString())
                                    {
                                        empid = classempdt.Rows[i]["EmployeeId"].ToString();
                                        break;
                                    }
                                }
                                MessageBox.Show("该员工已离职,运动轨迹中将不显示该员工的部门信息!", "提示", MessageBoxButtons.OK);
                            }
                            int index = lsbBanPeople.SelectedIndex;
                            EmpMoverList.Add(new EmpMoverModel(lsbBanPeople.SelectedItem.ToString(), empid));
                            lsbBanSelectpeople.AddItem(lsbBanPeople.SelectedItem.ToString(), empid);
                            lsbBanPeople.Values.Remove(lsbBanPeople.SelectedValue);
                            lsbBanPeople.Items.RemoveAt(lsbBanPeople.SelectedIndex);
                            if (index > lsbBanPeople.Items.Count - 1)
                                lsbBanPeople.SelectedIndex = lsbBanPeople.Items.Count - 1;
                            else
                                lsbBanPeople.SelectedIndex = index;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 班次 从移动者表中移除雇员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBanremove_Click(object sender, EventArgs e)
        {
            if (lsbBanSelectpeople.SelectedItem != null)
            {
                if (lsbBanSelectpeople.SelectedItems.Count > 0)
                {
                    for (int j = lsbBanSelectpeople.SelectedItems.Count; j > 0; j--)
                    {
                        //for (int i = 0; i < EmpDt.Rows.Count; i++)
                        //{
                        //    if (EmpDt.Rows[i][0].ToString() == lsbBanSelectpeople.SelectedItem.ToString())
                        //    {
                        //        //EmpMoverList.Remove(EmpMoverList.Find(new EmpMoverModel(lsbBanSelectpeople.SelectedItem.ToString(), lsbBanSelectpeople.SelectedValue)));

                        //        break;
                        //    }
                        //}
                        RemoveList(new EmpMoverModel(lsbBanSelectpeople.SelectedItem.ToString(), lsbBanSelectpeople.SelectedValue));
                        int index = lsbBanSelectpeople.SelectedIndex;
                        lsbBanSelectpeople.Values.Remove(lsbBanSelectpeople.SelectedValue);
                        lsbBanSelectpeople.Items.RemoveAt(lsbBanSelectpeople.SelectedIndex);
                        BanFlashPeople();
                        if (index > lsbBanSelectpeople.Items.Count - 1)
                            lsbBanSelectpeople.SelectedIndex = lsbBanSelectpeople.Items.Count - 1;
                        else
                            lsbBanSelectpeople.SelectedIndex = index;
                    }
                }
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHistroyRoute_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.HistoryThread != null && this.HistoryThread.ThreadState == System.Threading.ThreadState.Running)
            {
                HistoryThread.Abort();
            }
        }

        /// <summary>
        /// 选项卡变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbcControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PageIndex = tbcControl.SelectedIndex;
            EmpMoverList.Clear();
            if (PageIndex == 0)
            {
                for (int i = 0; i < lsbSelectPeople.Items.Count; i++)
                {
                    EmpMoverModel emm = new EmpMoverModel(lsbSelectPeople.Items[i].ToString(), lsbSelectPeople.Values[i]);
                    EmpMoverList.Add(emm);
                }
            }
            if (PageIndex == 1)
            {
                for (int i = 0; i < lsbBanSelectpeople.Items.Count; i++)
                {
                    EmpMoverModel emm = new EmpMoverModel(lsbBanSelectpeople.Items[i].ToString(), lsbBanSelectpeople.Values[i]);
                    EmpMoverList.Add(emm);
                }
            }
        }

        /// <summary>
        /// 结束轨迹播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (MapGis.IsMoving)
                {
                    this.MapGis.StopMoving();
                    this.btnHistoryRoute.Enabled = true;
                }
                else
                {
                    MessageBox.Show("当前并没有轨迹在播放中", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("当前并没有轨迹在播放中", "提示", MessageBoxButtons.OK);
            }
        }
        #endregion

        private void labRtpColor_Click(object sender, EventArgs e)
        {
            ColorDialog Cdlg = new ColorDialog();
            if (Cdlg.ShowDialog() == DialogResult.OK)
            {
                labRtpColor.BackColor = Cdlg.Color;
            }
        }

        #endregion

        private void labHRColor_Click(object sender, EventArgs e)
        {
            ColorDialog Cdlg = new ColorDialog();
            if (Cdlg.ShowDialog() == DialogResult.OK)
            {
                labHRColor.BackColor = Cdlg.Color;
                MapGis.MoverStrColor = Cdlg.Color;
                MapGis.FlashAll();
            }
        }

        private void labStationColor_Click(object sender, EventArgs e)
        {
            ColorDialog Cdlg = new ColorDialog();
            if (Cdlg.ShowDialog() == DialogResult.OK)
            {
                labStationColor.BackColor = Cdlg.Color;
                MapGis.StationStrColor = Cdlg.Color;
                MapGis.FlashAll();
            }
        }
    }
}