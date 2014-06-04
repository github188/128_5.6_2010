using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using KJ128NDBTable;
using ZzhaControlLibrary;
using System.Threading;

namespace KJ128NMainRun.Graphics
{
    public partial class FrmRouteConfig : Wilson.Controls.Docking.DockContent
    {
        #region[声明]
        private string MapFilePath;
        private string StationFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Signal.gif";
        private string MoverZFilePath;
        private string MoverFFilePath;
        private bool isConfiged=true;
        private Thread SaveThread;
        #endregion

        #region[载入]
        public FrmRouteConfig()
        {
            InitializeComponent();
        }
        #endregion

        #region[事件]
        private void FrmRouteConfig_Load(object sender, EventArgs e)
        {
            try
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
                        this.MapFilePath = Application.StartupPath + "\\MapGis\\Map\\" + SafeFileName;
                        XmlDocument xmldoc = new XmlDocument();
                        XmlDeclaration xmldec = xmldoc.CreateXmlDeclaration("1.0", "", "yes");
                        xmldoc.AppendChild(xmldec);
                        XmlNode rootnode = xmldoc.CreateElement("Config");
                        XmlNode node = xmldoc.CreateElement("底图");
                        node.InnerText = SafeFileName;
                        rootnode.AppendChild(node);
                        xmldoc.AppendChild(rootnode);
                        xmldoc.Save(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml");
                    }
                    catch (Exception ex)
                    {
                        SetBtnEnabel(false);
                        MessageBox.Show("无法识别的图片!", "提示", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    //this.Close();
                    this.btnRollback.Enabled = false;
                    this.btnSave.Enabled = false;
                    this.btnCreate.Enabled = false;
                    return;
                }
                if (System.IO.File.Exists(MapFilePath))
                {
                    this.MapGis.MapFilePath = MapFilePath;
                    this.MapGis.StationFilePath = StationFilePath;
                }
                else
                {
                    SetBtnEnabel(false);
                    MessageBox.Show("您所配置的图形加载失败,请重新配置后使用..", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (isConfiged)
                {
                    DataTable stationdt = new Graphics_StationInfoBLL().GetStationInfo();
                    if (stationdt != null && stationdt.Rows.Count > 0)
                    {
                        AddStationToMapGis(stationdt);
                    }
                    this.MapGis.StartSetting();
                }
            }
            catch (ArgumentException ex)
            {
                SetBtnEnabel(false);
                MessageBox.Show("您所配置的图形加载失败,请重新配置后使用..", "提示", MessageBoxButtons.OK);
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

        private void AddStationToMapGis(DataTable dt)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i]["stationaddress"].ToString() + "." + dt.Rows[i]["stationheadaddress"].ToString();
                    string stationname = dt.Rows[i]["stationheadplace"].ToString();
                    ZzhaControlLibrary.StationInfo sinfo = new ZzhaControlLibrary.StationInfo(id, stationname);
                    this.MapGis.StationHashTable.Add(sinfo.StationName, sinfo);
                }
            }
            catch (Exception ex)
            {
                this.SetBtnEnabel(false);
                MessageBox.Show("接收器安装地址存在重复值,请做修改!", "提示", MessageBoxButtons.OK);
            }
        }

        private void btnRollback_Click(object sender, EventArgs e)
        {
            this.MapGis.RollBackRoute();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isConfiged)
            {
                bool flag = true;
                string savestring = "begin ";
                foreach (Object o in MapGis.StationHashTable.Keys)
                {
                    PointF p = ((ZzhaControlLibrary.StationInfo)MapGis.StationHashTable[o]).StationPoint;
                    if (p == null)
                        p = new PointF(0, 0);
                    string stationname = ((ZzhaControlLibrary.StationInfo)MapGis.StationHashTable[o]).StationName;
                    savestring = savestring + new Graphics_StationInfoBLL().UpdateStationHeadInfo(p, stationname);
                }
                savestring = savestring + new Graphics_StationInfoBLL().DelRoute();
                foreach (RouteModel rm in MapGis.RouteList)
                {
                    if(rm.RouteLength!=0)
                        savestring = savestring + new Graphics_StationInfoBLL().InsertIntoRoute(rm.From, rm.To, rm.RouteLength);
                }
                savestring = savestring + " end";
                if (new Graphics_StationInfoBLL().SaveStationAndRoute(savestring))
                {
                    MapGis.IsStationChangeed = false;
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("保存失败", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (isConfiged)
            {
                if (MapGis.IsStationChangeed)
                {
                    if (MessageBox.Show("您所作的配置已发生修改,并未保存,是否放弃修改并生成路径?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SaveThread = new Thread(new ThreadStart(ThreadRun));
                        SaveThread.Start();
                    }
                }
                else
                {
                    SaveThread = new Thread(new ThreadStart(ThreadRun));
                    SaveThread.Start();
                }
            }
        }

        private delegate void SetBtnflag(bool flag);
        private void SetBtnEnabel(bool flag)
        {
            this.btnRollback.Enabled = flag;
            this.btnSave.Enabled = flag;
            this.btnCreate.Enabled = flag;
        }

        private void ThreadSetBtnEnabel(bool flag)
        {
            if (btnCreate.InvokeRequired)
            {
                btnCreate.Invoke(new SetBtnflag(this.SetBtnEnabel), new object[] { flag });
            }
            else
            {
                SetBtnEnabel(flag);
            }
        }

        private void ThreadRun()
        {
            ThreadSetBtnEnabel(false);
            frmWait f = new frmWait("正在生成路径请稍候....");
            f.Show();
            f.Refresh();
            string message = new RouteService().ProductRoutePoint(f, f.PgbWait);
            f.Close();
            MessageBox.Show(message);
            ThreadSetBtnEnabel(true);
            SaveThread.Abort();
        }
        #endregion

        private void 载入路径LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MapGis.RouteList.Count == 0)
            {
                DataTable stationposition = new Graphics_RouteBLL().GetStationHeadPosition();
                DataTable routedt = new Graphics_RouteBLL().GetAllRoute();
                if (routedt.Rows.Count > 0)
                {
                    this.MapGis.ClareRouteModelList();
                    this.MapGis.ClearAllStation();
                    for (int i = 0; i < stationposition.Rows.Count; i++)
                    {
                        string stationname = stationposition.Rows[i][0].ToString();
                        PointF p = new PointF(float.Parse(stationposition.Rows[i][1].ToString()), float.Parse(stationposition.Rows[i][2].ToString()));
                        MapGis.AddConfigStation(stationname, p);
                    }
                    for (int i = 0; i < routedt.Rows.Count; i++)
                    {
                        ZzhaControlLibrary.RouteModel rm = new RouteModel();
                        string from = routedt.Rows[i][0].ToString();
                        string[] fromxy = from.Split(',');
                        rm.From = new PointF(float.Parse(fromxy[0]), float.Parse(fromxy[1]));
                        string to = routedt.Rows[i][1].ToString();
                        string[] toxy = to.Split(',');
                        rm.To = new PointF(float.Parse(toxy[0]), float.Parse(toxy[1]));
                        rm.RouteLength = int.Parse(routedt.Rows[i][2].ToString());
                        MapGis.AddConfigRouteModel(rm);
                    }
                    MapGis.FlashAll();
                }
                else
                {
                    MessageBox.Show("您尚未配置过路径,无法载入上次路径配置信息...", "提示", MessageBoxButtons.OK);
                }
            }
        }
    }
}