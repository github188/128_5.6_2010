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
    /// Xml������
    /// </summary>
    public class XMLHelper
    {
        #region [ ���÷���:�����ṩ���ַ����ƻ�� XmlDocument ]

        /// <summary>
        /// �����ṩ���ַ����ƻ��XmlDocument
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        /// <param name="nodeName">�����</param>
        /// <returns>XmlDocument��</returns>
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

        #region [ ���÷���:���ݶ����ΪXmlDocument ]

        /// <summary>
        /// ���ݶ����ΪXmlDocument
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        /// <param name="obj">����</param>
        /// <returns>XmlDocument��</returns>
        public static XmlDocument EntityToXmlByObject(string path, Object obj)
        {
            return EntityToXmlByName(path, obj.GetType().Name);
        }

        #endregion
    }
}
