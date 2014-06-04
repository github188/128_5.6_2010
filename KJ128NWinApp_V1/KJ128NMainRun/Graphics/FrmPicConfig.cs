using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Threading;

namespace KJ128NMainRun.Graphics
{
    public partial class FrmPicConfig : Wilson.Controls.Docking.DockContent
    {
        #region[初始化]
        public FrmPicConfig()
        {
            InitializeComponent();
        }
        #endregion

        #region[事件]
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPicConfig_Load(object sender, EventArgs e)
        {
            XmlDocument xmldoc;
            if (!Directory.Exists("MapGis"))
            {
                Directory.CreateDirectory("MapGis");
            }
            if (!File.Exists(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml"))
            {
                xmldoc=new XmlDocument();
                XmlDeclaration xmldec = xmldoc.CreateXmlDeclaration("1.0","","yes");
                xmldoc.AppendChild(xmldec);
                XmlNode rootnode=xmldoc.CreateElement("Config");   
                XmlNode node = xmldoc.CreateElement("底图");
                node.InnerText = "";
                rootnode.AppendChild(node);
                xmldoc.AppendChild(rootnode);
                xmldoc.Save(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml");
            }
            
       
            xmldoc = new XmlDocument();
            xmldoc.Load(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml");
            XmlNode selectNode = xmldoc.SelectSingleNode("Config");
            for (int i = 0; i < selectNode.ChildNodes.Count; i++)
            {
                this.lsbPic.Items.Add(selectNode.ChildNodes[i].Name);
            }
        }
        /// <summary>
        /// 查看对应图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbPic_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nodename = this.lsbPic.Items[lsbPic.SelectedIndex].ToString();
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml");
            XmlNode node = doc.SelectSingleNode("//"+nodename);            
            try
            {
                this.picPic.Image = new Bitmap(node.InnerText);
                if (picPic.Image.Width > picPic.Width)
                    picPic.SizeMode = PictureBoxSizeMode.StretchImage;
                else
                    picPic.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            catch (Exception ex)
            {
                this.picPic.Image = null;
                MessageBox.Show("图片已经失效,请重新选择!", "提示", MessageBoxButtons.OK);
            }            
        }
        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.lsbPic.SelectedItem != null)
            {
                OpenFileDialog openfileDlg = new OpenFileDialog();
                openfileDlg.Filter = "所有图片文件(*.wmf;*.bmp;*.gif;*.jpg)|*.wmf;*.bmp;*.gif;*.jpg|图元(*.wmf)|*.wmf|位图(*.bmp)|*.bmp|动态图片(*.gif)|*.gif|静态图片(*.jpg)|*.jpg";
                if (openfileDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.picPic.Image = new Bitmap(openfileDlg.FileName);
                        if (picPic.Image.Width > picPic.Width)
                            picPic.SizeMode = PictureBoxSizeMode.StretchImage;
                        else
                            picPic.SizeMode = PictureBoxSizeMode.CenterImage;
                        string nodename = lsbPic.SelectedItem.ToString();
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml");
                        XmlNode node = doc.SelectSingleNode("//" + nodename);
                        node.InnerText = openfileDlg.FileName;
                        doc.Save(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("无法识别的图片!", "提示", MessageBoxButtons.OK);
                    }
                }
            }
        }
        #endregion
    }
}