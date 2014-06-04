using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace Shine.Command
{
    /// <summary>
    /// Xml帮助类
    /// </summary>
    public class XMLHelper
    {
        #region [ 公用方法:根据提供的字符名称获得 XmlDocument ]

        /// <summary>
        /// 根据提供的字符名称获得XmlDocument
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="nodeName">结点名</param>
        /// <returns>XmlDocument树</returns>
        public static XmlDocument EntityToXmlByName(string path, string nodeName)
        {
            XmlDocument doc = new XmlDocument();

            XmlNode node = null;

            if (File.Exists(path))
            {
                try
                {
                    doc.Load(path);

                    node = doc.SelectSingleNode(nodeName);

                    if (node == null)
                    {
                        node = doc.CreateElement(nodeName);
                        doc.AppendChild(node);
                    }
                }
                catch
                {

                }
            }

            if (node == null)
            {
                XmlNode nodehead = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");

                node = doc.CreateElement(nodeName);

                doc.AppendChild(nodehead);

                doc.AppendChild(node);
            }

            return doc;
        }

        #endregion

        #region [ 公用方法:根据对象存为XmlDocument ]

        /// <summary>
        /// 根据对象存为XmlDocument
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="obj">对象</param>
        /// <returns>XmlDocument树</returns>
        public static XmlDocument EntityToXmlByObject(string path, Object obj)
        {
            return EntityToXmlByName(path, obj.GetType().Name);
        }

        #endregion
    }
}
