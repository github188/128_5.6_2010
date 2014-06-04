using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace KJ128A.Batman
{
    /// <summary>
    /// ��������
    /// </summary>
    public partial class FrmParams : Form
    {
        #region [ ���캯�� ]
        private string str;
        /// <summary>
        /// ���캯��
        /// </summary>
        private FrmParams()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="strFilePath">�������õĴ洢·��</param>
        public FrmParams(string strFilePath):this()
        {
             str = strFilePath;

        }

        #endregion

        private void button_save_Click(object sender, EventArgs e)
        {
            label1.Text = str;
            if (checkBox_quanxian.Checked)
            {
                #region ѡ�е�ֵȥ��xml

                MessageBox.Show("asdf");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(str);

                XmlNodeList nodeList = xmlDoc.SelectSingleNode("quanxian").ChildNodes;//��ȡquanxian�ڵ�������ӽڵ�
                foreach (XmlNode xn in nodeList)//���������ӽڵ�
                {
                    XmlElement xe = (XmlElement)xn;//���ӽڵ�����ת��ΪXmlElement����
                    if (xe.Name == "Exit")
                    {
                        xe.InnerText="0";
                        break;
                    }
                }
                xmlDoc.Save(str);//���档
                #endregion
            }
            else
            {
 
            }

        }
    }
}