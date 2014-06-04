using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using System.Xml;

namespace KJ128NMainRun.Graphics
{
    public partial class frmRealTimeRoute : Form
    {
        private Graphics_RealTimeBLL grtb = new Graphics_RealTimeBLL();
        private bool isConfiged = true;
        private string MapFilePath;
        private string StationFilePath;
        private string MoverZFilePath;
        private string MoverFFilePath;
        private string SelectedEmpID = string.Empty;
        private string LastPlace = string.Empty;
        private string LastMovedPlace = string.Empty;
        private string EmpName = string.Empty;

        private DataTable MoverDT;
        private bool ismoving = false;

        public frmRealTimeRoute()
        {
            InitializeComponent();
        }

        private void frmRealTimeRoute_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGisMapInfo();
                LoadRTempInfo();
                this.pnlRTRoute.Left = 0 - picRTRouteInOut.Left;
                if (System.IO.File.Exists(MapFilePath))
                {
                    this.MapGis.MapFilePath = MapFilePath;
                    this.MapGis.StationFilePath = StationFilePath;
                    this.MapGis.MinWidth = 500;
                    this.MapGis.MaxWidth = 20000;
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
                }
                this.cmbRTRouteSpeed.SelectedIndex = 0;
                pnlRTRoute.Visible = true;
                this.MapGis.MoveEnded += new ZzhaControlLibrary.ZzhaMapGis.MoveingEnd(MapGis_MoveEnded);
                Timer t = new Timer();
                t.Interval = 10000;
                t.Tick += new EventHandler(t_Tick);
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("图形及轨迹尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
                return;
            }
        }

        
        

        

        private void picRTRouteInOut_Click(object sender, EventArgs e)
        {
            if (pnlRTRoute.Left < 0)
            {
                pnlRTRoute.Left = 0;
                picRTRouteInOut.Image = global::KJ128NMainRun.Properties.Resources.left;
            }
            else
            {
                pnlRTRoute.Left = 0 - picRTRouteInOut.Left;
                picRTRouteInOut.Image = global::KJ128NMainRun.Properties.Resources.right;
            }
        }

        private void LoadRTempInfo()
        {
            DataTable dt = grtb.GetAllDept();
            if (dt != null)
            {
                cmbRTRouteDept.Items.Clear();
                cmbRTRouteDept.Values.Clear();
                cmbRTRouteDept.AddItem("所有部门", "none");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbRTRouteDept.AddItem(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                }
                cmbRTRouteDept.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("提取部门信息时发生错误,请检查部门信息是否完整!", "提示", MessageBoxButtons.OK);
            }
        }

        private void cmbRTRouteDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbRTRouteEmp.Items.Clear();
            lsbRTRouteEmp.Values.Clear();
            DataTable dt = grtb.GetEmpByDeptID(cmbRTRouteDept.SelectedValue);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lsbRTRouteEmp.AddItem(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
            }
        }

        private void LoadGisMapInfo()
        {
            XmlDocument xmldoc = new XmlDocument();
            if (System.IO.File.Exists(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml"))
            {
                xmldoc.Load(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml");
            }
            else
            {
                MessageBox.Show("图形及轨迹尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
                isConfiged = false;
                return;
            }
            if (xmldoc.SelectSingleNode("//底图").InnerText == null || xmldoc.SelectSingleNode("//底图").InnerText == "")
            {
                MessageBox.Show("图形及轨迹图形尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
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

        private void cmbRTRouteSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZzhaControlLibrary.ZzhaMapGis.Speed = Convert.ToInt32(this.cmbRTRouteSpeed.SelectedItem);
        }

        private void lsbRTRouteEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            MapGis.ClareMover();
            MapGis.StopMoving();
            SelectedEmpID = lsbRTRouteEmp.SelectedValue;
            if (grtb.IsEmpInMine(SelectedEmpID))
            {
                DataRow dr;
                List<string> list = grtb.GetLastHisStationByEmpID(SelectedEmpID, out dr);
                FlashMoverDT(dr);
                if (list != null && list.Count == 5)
                {
                    this.MapGis.AddMover(list[0], list[1], list[2], list[3], list[4], MoverZFilePath, MoverFFilePath);
                    this.LastMovedPlace = list[2];
                    this.EmpName = list[4];
                    this.MapGis.StartRTMoving();
                    this.ismoving = true;
                }
            }
        }

        void MapGis_MoveEnded()
        {
            this.ismoving = false;
        }


        void t_Tick(object sender, EventArgs e)
        {
            if (this.LastMovedPlace != string.Empty && this.SelectedEmpID != string.Empty && MoverDT != null)
            {
                DataTable dt = grtb.GetNowStationByEmpID(SelectedEmpID);
                if (dt.Rows.Count > 0)
                {
                    string place = dt.Rows[0]["StationHeadPlace"].ToString();
                    if (place != LastMovedPlace)
                    {
                        DataRow dr = MoverDT.NewRow();
                        dr["StationPlace"] = dt.Rows[0]["StationHeadPlace"];
                        dr["StationAddress"] = dt.Rows[0]["StationAddress"];
                        dr["StationHeadAddress"] = dt.Rows[0]["StationHeadAddress"];
                        dr["StationX"] = dt.Rows[0]["StationHeadX"];
                        dr["StationY"] = dt.Rows[0]["StationHeadY"];
                        dr["InStationTime"] = dt.Rows[0]["StationHeadDetectTime"];
                        dr["OutStationTime"] = dt.Rows[0]["StationHeadDetectTime"];
                        MoverDT.Rows.Add(dr);
                        LastMovedPlace = dt.Rows[0]["StationHeadPlace"].ToString();
                    }
                    if (!this.ismoving && MoverDT.Rows.Count > 1)
                    {
                        DataRow bufferdr;
                        List<string> list = grtb.GetRTEmpRoute(MoverDT, EmpName, out bufferdr);
                        this.LastMovedPlace = MoverDT.Rows[MoverDT.Rows.Count - 1]["StationPlace"].ToString();
                        FlashMoverDT(bufferdr);
                        if (list != null && list.Count == 5)
                        {
                            this.MapGis.StopMoving();
                            this.MapGis.AddMover(list[0], list[1], list[2], list[3], list[4], MoverZFilePath, MoverFFilePath);
                            this.LastMovedPlace = list[2];
                            this.MapGis.StartRTMoving();
                            this.ismoving = true;
                        }
                    }
                }
            }
        }


        private void FlashMoverDT(DataRow dr)
        {
            if (dr != null)
            {
                MoverDT = new DataTable();
                MoverDT.Columns.Add("StationPlace");
                MoverDT.Columns.Add("StationAddress");
                MoverDT.Columns.Add("StationHeadAddress");
                MoverDT.Columns.Add("StationX");
                MoverDT.Columns.Add("StationY");
                MoverDT.Columns.Add("InStationTime");
                MoverDT.Columns.Add("OutStationTime");
                DataRow moverdr = MoverDT.NewRow();
                moverdr["StationPlace"] = dr["StationPlace"];
                moverdr["StationAddress"] = dr["StationAddress"];
                moverdr["StationHeadAddress"] = dr["StationHeadAddress"];
                moverdr["StationX"] = dr["StationX"];
                moverdr["StationY"] = dr["StationY"];
                moverdr["InStationTime"] = dr["InStationTime"];
                moverdr["OutStationTime"] = dr["OutStationTime"];
                MoverDT.Rows.Add(moverdr);
            }
        }
    }
}
