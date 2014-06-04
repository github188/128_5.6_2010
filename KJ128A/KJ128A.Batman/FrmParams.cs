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
    /// 参数配置
    /// </summary>
    public partial class FrmParams : Form
    {
        #region [ 构造函数 ]
        private string str;
        /// <summary>
        /// 构造函数
        /// </summary>
        private FrmParams()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strFilePath">参数配置的存储路径</param>
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
                #region 选中的值去改xml

                MessageBox.Show("asdf");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(str);

                XmlNodeList nodeList = xmlDoc.SelectSingleNode("quanxian").ChildNodes;//获取quanxian节点的所有子节点
                foreach (XmlNode xn in nodeList)//遍历所有子节点
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                    if (xe.Name == "Exit")
                    {
                        xe.InnerText="0";
                        break;
                    }
                }
                xmlDoc.Save(str);//保存。
                #endregion
            }
            else
            {
 
            }

        }
    }
}