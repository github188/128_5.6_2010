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
    /// 改变Tcp网络连接设置
    /// </summary>
    public class TcpClientUpdateTimer
    {
        #region[声明]

        private SocketPacket[] socketPackets;

        private HostBacker hostBacker;

        private HostBack.DataSave sqlSave;

        private string _tcpClientXmlFilePath;
        private static int _Count = 0;

        private System.Timers.Timer timeTcpChange = new System.Timers.Timer();
        private Timer nettimer = new Timer();

        DateTime dtLast = new DateTime();

        /// <summary>
        /// 
        /// </summary>
        public string TcpClientXmlFilePath
        {
            get { return _tcpClientXmlFilePath; }
            set { _tcpClientXmlFilePath = value; }
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

        #region [声明事件：网络数据改变事件]
        /// <summary>
        /// 声明分站数据改变事件
        /// </summary>
        public delegate void NetInfoChangeEventHandler();

        /// <summary>
        /// 定义分站数据改变事件
        /// </summary>
        public event NetInfoChangeEventHandler NetInfoChange;
        #endregion [声明事件：网络数据改变事件]

        #region[构造函数]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostBacker"></param>
        /// <param name="strpath"></param>
        /// <param name="configpath"></param>
        /// <param name="memStation"></param>
        public TcpClientUpdateTimer(HostBack.DataSave sqlSave, string strpath, string configpath, SocketPacket[] socketPackets)
        {
            this.sqlSave = sqlSave;
            this.TcpClientXmlFilePath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strpath;
            this.StationConfigFilePath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + configpath;
            this.socketPackets = socketPackets;

            timeTcpChange.Interval = 5000;
            timeTcpChange.AutoReset = true;
            timeTcpChange.Elapsed += new System.Timers.ElapsedEventHandler(timeTcpChange_Elapsed);
        }

        void timeTcpChange_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (File.Exists(TcpClientXmlFilePath) && !File.GetLastWriteTime(TcpClientXmlFilePath).Equals(dtLast))
            {
                //网络信息改变了
                if (NetInfoChange != null)
                {
                    NetInfoChange();
                }
                sqlSave.GetTcpInfo();
                dtLast = File.GetLastWriteTime(TcpClientXmlFilePath);
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
                    nettimer.Interval = int.Parse(TimeInterVal);
                    nettimer.Tick += new EventHandler(nettimer_Tick);
                    nettimer.Start();
                }
            }
            catch { }
            //catch (System.Exception ex)
            //{
            //    throw ex;
            //}
        }

        void nettimer_Tick(object sender, EventArgs e)
        {
            nettimer.Stop();
            try
            {
                if (_Count == 0)
                {
                    DataTable dtT = sqlSave.GetTcpClientInfo();
                    if (this.TcpClientLoad(this.TcpClientXmlFilePath))
                    {
                        if (!CompareStations(dtT))
                        {
                            this.ReplaceNetXml(dtT, this.TcpClientXmlFilePath);
                            //网络信息改变了
                            if (NetInfoChange != null)
                            {
                                NetInfoChange();
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
                dtLast = File.GetLastWriteTime(TcpClientXmlFilePath);
                timeTcpChange.Start();
            }
        }
        #endregion

        #region[定时更新网络操作]
        /// <summary>
        /// 重写TcpIp.xml文件
        /// </summary>
        /// <returns>true重写成功false重写失败</returns>
        public bool ReplaceNetXml(DataTable dt, string strPath)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(strPath);
                XmlNode rootnode = xmldoc.SelectSingleNode("DocumentElement");
                rootnode.RemoveAll();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        XmlNode node = xmldoc.CreateElement("TcpIpConfig");
                        XmlNode idNode = xmldoc.CreateElement("ipID");
                        idNode.InnerText = dt.Rows[i]["ipID"].ToString();
                        XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                        ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                        XmlNode ipPort = xmldoc.CreateElement("IpPort");
                        ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                        node.AppendChild(idNode);
                        node.AppendChild(ipaddressNode);
                        node.AppendChild(ipPort);
                        rootnode.AppendChild(node);
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
        /// 比较网络信息
        /// </summary>
        /// <param name="dt">从数据库中取出的网络数据</param>
        /// <returns></returns>
        public bool CompareStations(DataTable dt)
        {
            try
            {
                bool flag = true;
                if (socketPackets.Length > 0)
                {
                    if (dt==null)
                    {
                        return true;
                    }
                    if (socketPackets.Length <= dt.Rows.Count)
                    {
                        if (socketPackets.Length < dt.Rows.Count)
                        {
                            return false;
                        }
                        else
                        {
                            for (int i = 0; i < socketPackets.Length; i++)
                            {
                                DataRow[] dr = dt.Select("IPID=" + socketPackets[i].ID.ToString());
                                if (dr.Length > 0)
                                {
                                    if (dr[0]["IpAddress"] != null && dr[0]["IpAddress"].ToString().Equals(socketPackets[i].IpAddress) == false)
                                    {
                                        flag = false;
                                        break;
                                    }
                                    if (dr[0]["IpPort"] != null && int.Parse(dr[0]["IpPort"].ToString()).Equals(socketPackets[i].ClientPort) == false)
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
        /// 构建 TcpConfig 表格
        /// </summary>
        /// <returns></returns>
        private DataTable BuildTcpClientTable()
        {
            DataTable dtTcpClient = new DataTable("TcpIpConfig");

            DataColumn dcID = new DataColumn("IPID", typeof(int));
            dtTcpClient.Columns.Add(dcID);

            DataColumn dcIpAddress = new DataColumn("IpAddress", typeof(string));
            dtTcpClient.Columns.Add(dcIpAddress);

            DataColumn dcIpPort = new DataColumn("IpPort", typeof(int));
            dtTcpClient.Columns.Add(dcIpPort);

            return dtTcpClient;
        }

        /// <summary>
        /// 加载网络信息
        /// </summary>
        /// <param name="strPath">网络文件保存的路径</param>
        /// <returns></returns>
        public bool TcpClientLoad(string strPath)
        {
            DataTable dtTcpClient = BuildTcpClientTable();

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
                dtTcpClient.ReadXml(strPath);

                int iTcpClientCount = dtTcpClient.Rows.Count;
                socketPackets = new SocketPacket[iTcpClientCount];

                for (int i = 0; i < iTcpClientCount; i++)
                {
                    DataRow dr = dtTcpClient.Rows[i];
                    socketPackets[i] = new SocketPacket();
                    socketPackets[i].ID = int.Parse(dr["IPID"].ToString());
                    socketPackets[i].IpAddress = dr["IpAddress"].ToString();
                    socketPackets[i].ClientPort = int.Parse(dr["IpPort"].ToString());
                }
            }
            catch
            {
                try
                {
                    File.Delete(strPath);
                }
                catch
                { }
                return false;
            }
            finally
            {
                // 释放表格对象
                dtTcpClient.Dispose();
            }

            return true;
        }
        #endregion
    }
}
