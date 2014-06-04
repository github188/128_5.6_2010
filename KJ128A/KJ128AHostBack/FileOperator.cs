using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace KJ128A.HostBack
{
    public class FileOperator
    {
        #region 【属性：主机状态】
        private bool m_HostState;
        /// <summary>
        /// 主机状态
        /// </summary>
        public bool HostState
        {
            get { return m_HostState;}
            set { m_HostState = value; }
        }
        #endregion

        #region 【属性：备机状态】
        private bool m_StandbyState;
        /// <summary>
        /// 备机状态
        /// </summary>
        public bool StandbyState
        {
            get { return m_StandbyState; }
            set { m_StandbyState = value; }
        }
        #endregion

        #region 【属性：主机时间】
        private string m_StrHostTime;
        /// <summary>
        /// 主机时间
        /// </summary>
        public string HostTime
        {
            get { return m_StrHostTime; }
            set { m_StrHostTime = value; }
        }
        #endregion

        #region 【属性：备机时间】
        private string m_StrStandbyTime;
        /// <summary>
        /// 备机时间
        /// </summary>
        public string StandbyTime
        {
            get { return m_StrStandbyTime; }
            set { m_StrStandbyTime = value; }
        }
        #endregion

        #region 【方法：创建主机热备文件】
        /// <summary>
        /// 创建主机热备文件
        /// </summary>
        public bool CreateHostFile()
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                if (!File.Exists(Directory.GetCurrentDirectory() + "\\HostHot.xml"))
                {
                    fs = new FileStream(Directory.GetCurrentDirectory() + "\\HostHot.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<Host>");
                    sw.WriteLine("<StandbyState>true</StandbyState>");
                    sw.WriteLine("<StandbyTime>"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"</StandbyTime>");
                    sw.WriteLine("</Host>");
                    sw.Flush();
                    if (sw != null)
                    {
                        sw.Close();
                        sw.Dispose();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                        fs.Dispose();
                    }
                }
                return true;
            }
            catch 
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                return false; 
            }
        }
        #endregion

        #region 【方法：创建备机热备文件】
        /// <summary>
        /// 创建备机热备文件
        /// </summary>
        public bool CreateStandbyFile()
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                if (!File.Exists(Directory.GetCurrentDirectory() + "\\StandbyHot.xml"))
                {
                    fs = new FileStream(Directory.GetCurrentDirectory() + "\\StandbyHot.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<Standby>");
                    sw.WriteLine("<HostState>true</HostState>");
                    sw.WriteLine("<HostTime>" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</HostTime>");
                    sw.WriteLine("</Standby>");
                    sw.Flush();
                    if (sw != null)
                    {
                        sw.Close();
                        sw.Dispose();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                        fs.Dispose();
                    }
                }
                return true;
            }
            catch
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                return false;
            }
        }
        #endregion

        #region 【方法：读取主机热备文件】
        /// <summary>
        /// 读取主机热备文件
        /// </summary>
        /// <returns></returns>
        public bool ReadHostFile()
        {
            try
            {
                if (CreateHostFile())
                {
                    XmlDocument xmldocument = new XmlDocument();
                    //加载
                    xmldocument.Load(Directory.GetCurrentDirectory() + "\\HostHot.xml");
                    XmlNode node = xmldocument.SelectSingleNode("/Host/StandbyState");
                    m_StandbyState = bool.Parse(node.InnerText);
                    XmlNode node1 = xmldocument.SelectSingleNode("/Host/StandbyTime");
                    m_StrStandbyTime = node1.InnerText;
                    return true;
                }
                else
                { return false; }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 【方法：读取备机热备文件】
        /// <summary>
        /// 读取备机热备文件
        /// </summary>
        /// <returns></returns>
        public bool ReadStandbyFile()
        {
            try
            {
                if (CreateStandbyFile())
                {
                    XmlDocument xmldocument = new XmlDocument();
                    //加载
                    xmldocument.Load(Directory.GetCurrentDirectory() + "\\StandbyHot.xml");
                    XmlNode node = xmldocument.SelectSingleNode("/Standby/HostState");
                    m_HostState = bool.Parse(node.InnerText);
                    XmlNode node1 = xmldocument.SelectSingleNode("/Standby/HostTime");
                    m_StrHostTime = node1.InnerText;
                    return true;
                }
                else
                { return false; }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 【方法：修改主机热备文件】
        /// <summary>
        /// 修改主机热备文件
        /// </summary>
        /// <returns></returns>
        public bool UpdateHostFile()
        {
            try
            {
                if (CreateHostFile())
                {
                    XmlDocument xmldocument = new XmlDocument();
                    //加载
                    xmldocument.Load(Directory.GetCurrentDirectory() + "\\HostHot.xml");
                    XmlNode node = xmldocument.SelectSingleNode("/Host/StandbyState");
                    node.InnerText = m_StandbyState.ToString();
                    XmlNode node1 = xmldocument.SelectSingleNode("/Host/StandbyTime");
                    node1.InnerText = m_StrStandbyTime;
                    xmldocument.Save(Directory.GetCurrentDirectory() + "\\HostHot.xml");
                    return true;
                }
                else
                { return false; }
            }
            catch { return false; }
        }
        #endregion

        #region 【方法：修改备机热备文件】
        /// <summary>
        /// 修改备机热备文件
        /// </summary>
        /// <returns></returns>
        public bool UpdateStandbyFile()
        {
            try
            {
                if (CreateStandbyFile())
                {
                    XmlDocument xmldocument = new XmlDocument();
                    //加载
                    xmldocument.Load(Directory.GetCurrentDirectory() + "\\StandbyHot.xml");
                    XmlNode node = xmldocument.SelectSingleNode("/Standby/HostState");
                    node.InnerText = m_HostState.ToString();
                    XmlNode node1 = xmldocument.SelectSingleNode("/Standby/HostTime");
                    node1.InnerText = m_StrHostTime;
                    xmldocument.Save(Directory.GetCurrentDirectory() + "\\StandbyHot.xml");
                    return true;
                }
                else
                { return false; }
            }
            catch { return false; }
        }
        #endregion
    }
}
