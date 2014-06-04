using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using KJ128A.BatmanAPI;
using KJ128A.Ports;
using KJ128A.Controls.Batman;
using KJ128A.HostBack;

namespace KJ128A.Batman
{
    /// <summary>
    /// 
    /// </summary>
    public class StationUpdateTimer
    {
        #region[声明]

        private  MemStation[] memStation;

        private HostBacker hostBacker;

        private HostBack.DataSave sqlSave;
        
        private string _stationXmlFilePath;

        private bool _commType;

        private static int _Count = 0;
        /// <summary>
        /// 
        /// </summary>
        public string StationXmlFilePath
        {
            get { return _stationXmlFilePath; }
            set { _stationXmlFilePath = value; }
        }
        private string _stationConfigFilePath;
        /// <summary>
        /// 
        /// </summary>
        public string StationConfigFilePath
        {
            get { return _stationConfigFilePath; }
            set { _stationConfigFilePath = value; }
        }
        #endregion

        //A_FrmStationInfo a_frmStationInfo = new A_FrmStationInfo();

        #region [声明事件：分站数据改变事件]
        /// <summary>
        /// 声明分站数据改变事件
        /// </summary>
        public delegate void StationInfoChangeEventHandler();

        /// <summary>
        /// 定义分站数据改变事件
        /// </summary>
        public event StationInfoChangeEventHandler StationInfoChange;
        #endregion [声明事件：分站数据改变事件]

        Timer stationtimer = null;
        Timer stationChangeTime = new Timer();

        DateTime dtLast = new DateTime();

        #region[构造函数]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostBacker"></param>
        /// <param name="strpath"></param>
        /// <param name="configpath"></param>
        /// <param name="memStation"></param>
        public StationUpdateTimer(HostBack.DataSave sqlSave,bool commType, string strpath, string configpath, MemStation[] memStation)
        {
            this.sqlSave = sqlSave;
            this._commType = commType;
            this.StationXmlFilePath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strpath;
            this.StationConfigFilePath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + configpath;
            this.memStation = memStation;
            stationChangeTime.Interval = 5000;
            stationChangeTime.Tick += new EventHandler(stationChangeTime_Tick);
        }

        void stationChangeTime_Tick(object sender, EventArgs e)
        {
            if (!File.GetLastWriteTime(StationXmlFilePath).Equals(dtLast))
            {
                //基站信息被改变了
                if (StationInfoChange != null)
                {
                    StationInfoChange();
                }
                sqlSave.GetStationInfo();
                dtLast = File.GetLastWriteTime(StationXmlFilePath);
            }
        }
        #endregion

        #region[开始定时更新基站]
        /// <summary>
        /// 
        /// </summary>
        public void StartTimer()
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(this.StationConfigFilePath);
                XmlNode node = xmldoc.SelectSingleNode("StationUpdateConfig");
                string AutoUpdate = node.ChildNodes[0].InnerText;
                string TimeInterVal = node.ChildNodes[1].InnerText;
                if (bool.Parse(AutoUpdate))
                {
                    if (stationtimer == null)
                    {
                        stationtimer = new Timer();
                        stationtimer.Interval = int.Parse(TimeInterVal);
                        stationtimer.Tick += new EventHandler(stationtimer_Tick);
                        stationtimer.Start();
                    }
                }
            }
            catch { }
            //catch (Exception ex)
            //{
            //    MessageBox.Show("发生错误");                
            //}
        }

        void stationtimer_Tick(object sender, EventArgs e)
        {
            stationtimer.Stop();
            try
            {
                if (_Count == 0)
                {
                    int selectType = 0;
                    if (_commType == false)
                    {
                        selectType = 1;
                    }
                    else
                    {
                        selectType = 2;
                    }
                    DataTable dtS = sqlSave.GetStationInfo(selectType);
                    if (this.StationLoad(this.StationXmlFilePath))
                    {
                        if (!CompareStations(dtS))
                        {
                            if (this.ReplaceStationXml(dtS, this.StationXmlFilePath))
                            {
                                //基站信息被改变了
                                if (StationInfoChange != null)
                                {
                                    StationInfoChange();
                                }
                            }
                        }
                    }
                }
                _Count++;
                if (_Count >= 10)
                    _Count = 0;
            }
            catch { }
            finally
            {
                dtLast = File.GetLastWriteTime(StationXmlFilePath);
                stationChangeTime.Start();
            }
            
            
        }
        #endregion

        #region[定时更新基站操作]
        /// <summary>
        /// 重写Station.xml文件
        /// </summary>
        /// <returns>true重写成功false重写失败</returns>
        public bool ReplaceStationXml(DataTable dt, string strPath)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\SerialPort.xml");
                XmlNode markrootnode = xml.SelectSingleNode("DocumentElement");

                int commType = 0;
                int tcpMark = 0;
                XmlDocument xmlcomm = new XmlDocument();
                if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\CommType.xml"))
                {
                    xmlcomm.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\CommType.xml");
                    try
                    {
                        XmlNode xmlnodeComm = xmlcomm.SelectSingleNode("/comm/commType");
                        if (xmlnodeComm != null)
                        {
                            commType = int.Parse(xmlnodeComm.InnerText);
                        }
                    }
                    catch
                    {
                    }
                    if (commType!=0)
                    {
                        try
                        {
                            XmlNode xmlnodeTcpMark = xmlcomm.SelectSingleNode("/comm/TcpMark");
                            if (xmlnodeTcpMark != null)
                            {
                                tcpMark = int.Parse(xmlnodeTcpMark.InnerText);
                            }
                        }
                        catch { }
                    }
                }

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(strPath);
                XmlNode rootnode = xmldoc.SelectSingleNode("DocumentElement");
                rootnode.RemoveAll();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < markrootnode.ChildNodes.Count; j++)
                        {
                            if (commType == 0)
                            {
                                XmlNode Groupnode = xmldoc.CreateElement("Group");
                                if (markrootnode.ChildNodes[j].ChildNodes[2].InnerText.Equals(dt.Rows[i]["StationGroup"].ToString()))
                                {
                                    Groupnode.InnerText = dt.Rows[i]["StationGroup"].ToString();
                                    XmlNode node = xmldoc.CreateElement("Station");
                                    XmlNode idnode = xmldoc.CreateElement("ID");
                                    idnode.InnerText = dt.Rows[i]["ID"].ToString();
                                    XmlNode addressnode = xmldoc.CreateElement("Address");
                                    addressnode.InnerText = dt.Rows[i]["Address"].ToString();

                                    XmlNode statenode = xmldoc.CreateElement("State");
                                    statenode.InnerText = "0";
                                    XmlNode marknode = xmldoc.CreateElement("Mark");

                                    marknode.InnerText = markrootnode.ChildNodes[j].ChildNodes[3].InnerText;

                                    XmlNode isenablenode = xmldoc.CreateElement("Ver");
                                    isenablenode.InnerText = dt.Rows[i]["Ver"].ToString();
                                    XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                                    ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                                    XmlNode ipPort = xmldoc.CreateElement("IpPort");
                                    ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                                    XmlNode stationModelNode = xmldoc.CreateElement("StationModel");
                                    stationModelNode.InnerText = dt.Rows[i]["StationModel"].ToString();
                                    node.AppendChild(idnode);
                                    node.AppendChild(addressnode);
                                    node.AppendChild(Groupnode);
                                    node.AppendChild(statenode);
                                    node.AppendChild(marknode);
                                    node.AppendChild(isenablenode);
                                    node.AppendChild(ipaddressNode);
                                    node.AppendChild(ipPort);
                                    node.AppendChild(stationModelNode);
                                    rootnode.AppendChild(node);
                                }
                            }
                            else
                            {
                                XmlNode Groupnode = xmldoc.CreateElement("Group");
                                if (markrootnode.ChildNodes[j].ChildNodes[2].InnerText.Equals(dt.Rows[i]["StationGroup"].ToString()))
                                {
                                    Groupnode.InnerText = dt.Rows[i]["StationGroup"].ToString();
                                    XmlNode node = xmldoc.CreateElement("Station");
                                    XmlNode idnode = xmldoc.CreateElement("ID");
                                    idnode.InnerText = dt.Rows[i]["ID"].ToString();
                                    XmlNode addressnode = xmldoc.CreateElement("Address");
                                    addressnode.InnerText = dt.Rows[i]["Address"].ToString();

                                    XmlNode statenode = xmldoc.CreateElement("State");
                                    statenode.InnerText = "0";
                                    XmlNode marknode = xmldoc.CreateElement("Mark");

                                    marknode.InnerText = tcpMark.ToString();

                                    XmlNode isenablenode = xmldoc.CreateElement("Ver");
                                    isenablenode.InnerText = dt.Rows[i]["Ver"].ToString();
                                    XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                                    ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                                    XmlNode ipPort = xmldoc.CreateElement("IpPort");
                                    ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                                    XmlNode stationModelNode = xmldoc.CreateElement("StationModel");
                                    stationModelNode.InnerText = dt.Rows[i]["StationModel"].ToString();
                                    node.AppendChild(idnode);
                                    node.AppendChild(addressnode);
                                    node.AppendChild(Groupnode);
                                    node.AppendChild(statenode);
                                    node.AppendChild(marknode);
                                    node.AppendChild(isenablenode);
                                    node.AppendChild(ipaddressNode);
                                    node.AppendChild(ipPort);
                                    node.AppendChild(stationModelNode);
                                    rootnode.AppendChild(node);
                                }

                            }
                        }
                    }
                }
                xmldoc.Save(strPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 比较基站信息
        /// </summary>
        /// <param name="dt">从数据库中取出的基站数据</param>
        /// <returns></returns>
        public bool CompareStations(DataTable dt)
        {
            try
            {
                bool flag = true;
                if (memStation.Length > 0)
                {
                    if (dt == null)
                    {
                        return true;
                    }
                    if (memStation.Length <= dt.Rows.Count)
                    {
                        if (memStation.Length < dt.Rows.Count)
                        {
                            return false;
                        }
                        else
                        {
                            for (int i = 0; i < memStation.Length; i++)
                            {
                                DataRow[] dr = dt.Select("ID=" + memStation[i].ID.ToString());
                                if (dr.Length > 0)
                                {
                                    //有相同基站 对比数据
                                    if (int.Parse(dr[0]["StationGroup"].ToString()) != memStation[i].Group)
                                    {
                                        flag = false;
                                        break;
                                    }
                                    if (int.Parse(dr[0]["Address"].ToString()) != memStation[i].Address)
                                    {
                                        flag = false;
                                        break;
                                    }
                                    if (int.Parse(dr[0]["Ver"].ToString()) != memStation[i].Ver)
                                    {
                                        flag = false;
                                        break;
                                    }
                                    
                                    if (dr[0]["IpAddress"] != null && dr[0]["IpAddress"].ToString().Equals(memStation[i].IpAddress) == false)
                                    {
                                        flag = false;
                                        break;
                                    }
                                    if (dr[0]["IpPort"] != null && int.Parse(dr[0]["IpPort"].ToString()).Equals(memStation[i].Port) == false)
                                    {
                                        flag = false;
                                        break;
                                    }
                                    if (dr[0]["StationModel"] != null && int.Parse(dr[0]["StationModel"].ToString()).Equals(memStation[i].StationModel) == false)
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    flag = false;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return flag;
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// 构建 Station 表格
        /// </summary>
        /// <returns></returns>
        private DataTable BuildStationTable()
        {
            DataTable dtStation = new DataTable("Station");

            DataColumn dcID = new DataColumn("ID", typeof(int));
            dtStation.Columns.Add(dcID);

            DataColumn dcAddress = new DataColumn("Address", typeof(int));
            dtStation.Columns.Add(dcAddress);

            DataColumn dcGroup = new DataColumn("Group", typeof(int));
            dtStation.Columns.Add(dcGroup);

            DataColumn dcState = new DataColumn("State", typeof(int));
            dtStation.Columns.Add(dcState);

            DataColumn dcMark = new DataColumn("Mark", typeof(int));
            dtStation.Columns.Add(dcMark);

            DataColumn dcVer = new DataColumn("Ver", typeof(int));
            dtStation.Columns.Add(dcVer);

            DataColumn dcIpAddress = new DataColumn("IpAddress", typeof(string));
            dtStation.Columns.Add(dcIpAddress);

            DataColumn dcIpPort = new DataColumn("IpPort", typeof(int));
            dtStation.Columns.Add(dcIpPort);

            DataColumn dcStationModel = new DataColumn("StationModel", typeof(int));
            dtStation.Columns.Add(dcStationModel);

            return dtStation;
        }

        /// <summary>
        /// 加载基站信息
        /// </summary>
        /// <param name="strPath">基站文件保存的路径</param>
        /// <returns></returns>
        public bool StationLoad(string strPath)
        {
            DataTable dtStation = BuildStationTable();

            try
            {
                if (!File.Exists(strPath))
                {
                    //创建station.xml文件
                    FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<DocumentElement>");
                    sw.WriteLine("</DocumentElement>");
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch { }

            try
            {
                dtStation.ReadXml(strPath);

                int iStationCount = dtStation.Rows.Count;
                memStation = new MemStation[iStationCount];

                for (int i = 0; i < iStationCount; i++)
                {
                    DataRow dr = dtStation.Rows[i];

                    memStation[i].ID = int.Parse(dr["ID"].ToString());
                    memStation[i].Address = int.Parse(dr["Address"].ToString());
                    memStation[i].Group = int.Parse(dr["Group"].ToString());
                    memStation[i].State = int.Parse(dr["State"].ToString());
                    memStation[i].Ver = int.Parse(dr["Ver"].ToString());
                    if (dr["IpAddress"] != null)
                    {
                        memStation[i].IpAddress = dr["IpAddress"].ToString();
                    }
                    else
                    {
                        memStation[i].IpAddress = "";
                    }
                    if (dr["IpPort"] != null)
                    {
                        memStation[i].Port = int.Parse(dr["IpPort"].ToString());
                    }
                    else
                    {
                        memStation[i].Port = 0;
                    }
                    memStation[i].StationModel = int.Parse(dr["StationModel"].ToString());
                }
            }
            catch
            {
                try
                {
                    File.Delete(strPath);
                }
                catch { }
                return false;
            }
            finally
            {
                // 释放表格对象
                dtStation.Dispose();
            }

            return true;
        }
        #endregion
    }
}
