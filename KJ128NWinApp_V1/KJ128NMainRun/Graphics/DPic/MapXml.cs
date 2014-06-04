using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using KJ128NDBTable;

namespace KJ128NMainRun.Graphics.DPic
{
    public class MapXml
    {
        Graphics_DpicBLL dpicbll = new Graphics_DpicBLL();
        public bool LoadAllMapConfig(XmlDocument xmldoc, ZzhaControlLibrary.ZzhaMapGis mapgis)
        {
            //MapGis.ClearAllStation();
            //MapGis.ClearAllStatic();
            XmlNode MapNode = xmldoc.SelectSingleNode("//Map");            
            if (MapNode.Attributes.Count == 0)
            {
                MessageBox.Show("全图范围尚未配置,请先配置全图范围后再模拟全图", "提示", MessageBoxButtons.OK);
                return false;
            }
            //mapgis.MapFilePath = Application.StartupPath + MapNode.InnerText;
            try
            {
                DataTable dt = dpicbll.GetBackPicByFileID(MapNode.InnerText);
                byte[] buffer = (byte[])dt.Rows[0][0];
                Graphics.Config.FileChanger fc = new KJ128NMainRun.Graphics.Config.FileChanger();
                if (!System.IO.Directory.Exists(Application.StartupPath + "\\MapGis\\DMap"))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\MapGis\\DMap");
                }
                fc.CreateFile(Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString(), buffer);
                mapgis.MapFilePath = Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString();
                System.IO.File.Delete(Application.StartupPath + "\\MapGis\\DMap\\" + dt.Rows[0][1].ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show("无法识别的图片!", "提示", MessageBoxButtons.OK);
                return false;
            }
            mapgis.MapX = 0;
            mapgis.MapY = 0;
            mapgis.MinWidth = int.Parse(MapNode.Attributes["MinWidth"].InnerText);
            mapgis.MaxWidth = int.Parse(MapNode.Attributes["MaxWidth"].InnerText);
            XmlNode DivRoot = xmldoc.SelectSingleNode("//Divs");
            foreach (XmlNode divnode in DivRoot.ChildNodes)
            {
                mapgis.AddDiv(divnode.InnerText, int.Parse(divnode.Attributes["MinWidth"].InnerText), int.Parse(divnode.Attributes["MaxWidth"].InnerText));
            }
            //加到DIV结束
            XmlNode StaticRoot = xmldoc.SelectSingleNode("//Statics");
            if (StaticRoot != null && StaticRoot.ChildNodes.Count > 0)
            {
                foreach (XmlNode staticnode in StaticRoot.ChildNodes)
                {
                    float x = float.Parse(staticnode.ChildNodes[2].InnerText);
                    float y = float.Parse(staticnode.ChildNodes[3].InnerText);
                    string filepath =staticnode.ChildNodes[1].InnerText;
                    string divname = staticnode.ChildNodes[0].InnerText;
                    int width = int.Parse(staticnode.ChildNodes[4].InnerText);
                    int height = int.Parse(staticnode.ChildNodes[5].InnerText);
                    string name = staticnode.ChildNodes[6].InnerText;
                    string key = staticnode.ChildNodes[7].InnerText;
                    ZzhaControlLibrary.StaticType type = ZzhaControlLibrary.StaticType.ImageAndWord;
                    string fontname = staticnode.ChildNodes[9].Attributes[0].InnerText;
                    float size = float.Parse(staticnode.ChildNodes[9].Attributes[1].InnerText);
                    FontStyle fontstyle = (FontStyle)Enum.Parse(typeof(FontStyle), staticnode.ChildNodes[9].Attributes[2].InnerText);
                    Color FontColor = Color.FromArgb(int.Parse(staticnode.ChildNodes[9].InnerText));
                    System.Drawing.Font staticFont = new Font(fontname, size, fontstyle);
                    if (staticnode.ChildNodes[8].InnerText == "Image")
                    {
                        type = ZzhaControlLibrary.StaticType.Image;
                        mapgis.AddStaticObj(x, y, new Bitmap(Application.StartupPath + filepath), divname, width, height, filepath, name, key, type, staticFont, FontColor);
                    }
                    if (staticnode.ChildNodes[8].InnerText == "ImageAndWord")
                    {
                        type = ZzhaControlLibrary.StaticType.ImageAndWord;
                        mapgis.AddStaticObj(x, y, new Bitmap(Application.StartupPath + filepath), divname, width, height, filepath, name, key, type, staticFont, FontColor);
                    }
                    if (staticnode.ChildNodes[8].InnerText == "Word")
                    {
                        type = ZzhaControlLibrary.StaticType.Word;
                        mapgis.AddStaticObj(x, y, name, key, divname, staticFont, FontColor);
                    }
                }
            }
            XmlNode StationRoot = xmldoc.SelectSingleNode("//Stations");
            if (StationRoot != null && StationRoot.ChildNodes.Count > 0)
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
                            XmlNode stationnode = xmldoc.GetElementById(stationName);
                            if (stationnode != null)
                            {
                                string stationdivname = stationnode.InnerText;

                                if (stationstate == "正常" || stationstate == "未初始化")
                                    mapgis.AddStation(stationheadx, stationheady, stationName, stationID, "正常", new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\Signal.gif"), stationdivname);
                                if (stationstate == "故障")
                                    mapgis.AddStation(stationheadx, stationheady, stationName, stationID, stationstate, new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\No-Signal.gif"), stationdivname);
                                if (stationstate == "休眠")
                                    mapgis.AddStation(stationheadx, stationheady, stationName, stationID, stationstate, new Bitmap(Application.StartupPath + "\\MapGis\\ShineImage\\Station.GIF"), stationdivname);

                            }
                        }
                        mapgis.FalshStations();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("图形系统中部分图片已经不存在", "提示", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            mapgis.FlashAll();
            return true;
        }
    }
}
