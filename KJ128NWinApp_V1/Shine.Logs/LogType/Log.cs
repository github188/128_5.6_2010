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
    /// ��־����
    /// </summary>
    public class Log
    {
        #region [ ����: ��¼��־��ǰʱ�� ]

        /// <summary>
        /// ��¼��־��ǰʱ��
        /// </summary>
        private DateTime crruentTime = DateTime.Now;

        /// <summary>
        /// ��¼��־��ǰʱ��
        /// </summary>
        public DateTime CrruentTime
        {
            get { return crruentTime; }
            set { crruentTime = value; }
        }

        #endregion

        #region [˽�з�����������־����]

        /// <summary>
        /// ������־����
        /// </summary>
        /// <param name="log">��־����</param>
        /// <param name="path">����·��</param>
        /// <returns>�����Ƿ�ɹ�</returns>
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

        #region [˽�з�����������־xml��]

        /// <summary>
        /// ������־xml��
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="log">��־����</param>
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
