using System;
using System.Collections.Generic;
using System.Text;
using Shine.Logs.LogType;
using System.Xml;
using System.Reflection;
using Shine.Command;
using System.IO;

namespace Shine.Logs
{
    /// <summary>
    /// 日志基类
    /// </summary>
    public class Log
    {
        #region [ 属性: 记录日志当前时间 ]

        /// <summary>
        /// 记录日志当前时间
        /// </summary>
        private DateTime crruentTime = DateTime.Now;

        /// <summary>
        /// 记录日志当前时间
        /// </summary>
        public DateTime CrruentTime
        {
            get { return crruentTime; }
            set { crruentTime = value; }
        }

        #endregion

        #region [私有方法：保存日志数据]

        /// <summary>
        /// 保存日志数据
        /// </summary>
        /// <param name="log">日志对象</param>
        /// <param name="path">保存路径</param>
        /// <returns>保存是否成功</returns>
        public bool SaveLogData(string path)
        {
            try
            {
                XmlDocument doc = XMLHelper.EntityToXmlByObject(path, this);

                XmlNode node = doc.SelectSingleNode(this.GetType().Name);

                if (node != null)
                {
                    XmlNode cnode = ClassToXML(doc, this);
                    node.AppendChild(cnode);
                }

                if (!File.Exists(path))
                {
                    int po = path.LastIndexOf(Convert.ToChar(@"\"));
                    string dir = path.Substring(0, po);
                    Directory.CreateDirectory(dir);
                }

                doc.Save(path);

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region [私有方法：构造日志xml项]

        /// <summary>
        /// 构造日志xml项
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="log">日志对象</param>
        /// <returns>xmlnode</returns>
        private XmlNode ClassToXML(XmlDocument doc, Log log)
        {
            XmlElement elementnode = doc.CreateElement("log");

            PropertyInfo[] pinfo = log.GetType().GetProperties();

            for (int i = 0; i < pinfo.Length; i++)
            {
                XmlNode ele = doc.CreateElement(pinfo[i].Name);

                ele.InnerText = pinfo[i].GetValue(log, null).ToString();

                elementnode.AppendChild(ele);
            }

            return elementnode;
        }

        #endregion
    }


}
