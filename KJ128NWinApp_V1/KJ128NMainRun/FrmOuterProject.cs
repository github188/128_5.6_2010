using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun
{
    public partial class FrmOuterProject : Form
    {
        public FrmOuterProject()
        {
            InitializeComponent();
        }

        private void FrmOuterProject_Load(object sender, EventArgs e)
        {
            CreateOuterPathFile();
        }

        /// <summary>
        /// 创建外挂程序配置文件，并判断文件中属性
        /// </summary>
        private void CreateOuterPathFile()
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "OuterPath.xml"))
            {
                //创建
                FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "OuterPath.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                sw.WriteLine("<Path>");
                for (int i = 0; i < 8; i++)
                {
                    sw.WriteLine("<OuterConfig>");
                    sw.WriteLine("<ID>" + (i + 1).ToString() + "</ID>");
                    sw.WriteLine("<isEnable>0</isEnable>");
                    sw.WriteLine("<OuterPath></OuterPath>");
                    sw.WriteLine("</OuterConfig>");
                }
                sw.WriteLine("</Path>");
                sw.Flush();
                sw.Close();
                sw.Dispose();
                fs.Close();
                fs.Dispose();
            }

            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "OuterPath.xml");
                XmlNodeList nodes = xmlDocument.SelectNodes("/Path/OuterConfig");
                foreach (XmlNode node in nodes)
                {
                    if (node!=null)
                    {
                        XmlNode nodeID = node.SelectSingleNode("ID");
                        XmlNode nodeEnable = node.SelectSingleNode("isEnable");
                        XmlNode nodeOuterPath = node.SelectSingleNode("OuterPath");
                        switch (nodeID.InnerText)
                        {
                            case "1":
                                if (nodeEnable.InnerText.Equals("1"))
                                {
                                    chbPath1.Checked = true;
                                    btnPath1.Enabled = true;
                                    txtPath1.Text = nodeOuterPath.InnerText;
                                }
                                else
                                {
                                    chbPath1.Checked = false;
                                }
                                break;
                            case "2":
                                if (nodeEnable.InnerText.Equals("1"))
                                {
                                    chbPath2.Checked = true;
                                    btnPath2.Enabled = true;
                                    txtPath2.Text = nodeOuterPath.InnerText;
                                }
                                else
                                {
                                    chbPath2.Checked = false;
                                }
                                break;
                            case "3":
                                if (nodeEnable.InnerText.Equals("1"))
                                {
                                    chbPath3.Checked = true;
                                    btnPath3.Enabled = true;
                                    txtPath3.Text = nodeOuterPath.InnerText;
                                }
                                else
                                {
                                    chbPath3.Checked = false;
                                }
                                break;
                            case "4":
                                if (nodeEnable.InnerText.Equals("1"))
                                {
                                    chbPath4.Checked = true;
                                    btnPath4.Enabled = true;
                                    txtPath4.Text = nodeOuterPath.InnerText;
                                }
                                else
                                {
                                    chbPath4.Checked = false;
                                }
                                break;
                            case "5":
                                if (nodeEnable.InnerText.Equals("1"))
                                {
                                    chbPath5.Checked = true;
                                    btnPath5.Enabled = true;
                                    txtPath5.Text = nodeOuterPath.InnerText;
                                }
                                else
                                {
                                    chbPath5.Checked = false;
                                }
                                break;
                            case "6":
                                if (nodeEnable.InnerText.Equals("1"))
                                {
                                    chbPath6.Checked = true;
                                    btnPath6.Enabled = true;
                                    txtPath6.Text = nodeOuterPath.InnerText;
                                }
                                else
                                {
                                    chbPath6.Checked = false;
                                }
                                break;
                            case "7":
                                if (nodeEnable.InnerText.Equals("1"))
                                {
                                    chbPath7.Checked = true;
                                    btnPath7.Enabled = true;
                                    txtPath7.Text = nodeOuterPath.InnerText;
                                }
                                else
                                {
                                    chbPath7.Checked = false;
                                }
                                break;
                            case "8":
                                if (nodeEnable.InnerText.Equals("1"))
                                {
                                    chbPath8.Checked = true;
                                    btnPath8.Enabled = true;
                                    txtPath8.Text = nodeOuterPath.InnerText;
                                }
                                else
                                {
                                    chbPath8.Checked = false;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void chbPath1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPath1.Checked)
            {
                btnPath1.Enabled = true;
            }
            else
            {
                btnPath1.Enabled = false;
            }
        }

        private void chbPath2_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPath2.Checked)
            {
                btnPath2.Enabled = true;
            }
            else
            {
                btnPath2.Enabled = false;
            }
        }

        private void chbPath3_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPath3.Checked)
            {
                btnPath3.Enabled = true;
            }
            else
            {
                btnPath3.Enabled = false;
            }
        }

        private void chbPath4_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPath4.Checked)
            {
                btnPath4.Enabled = true;
            }
            else
            {
                btnPath4.Enabled = false;
            }
        }

        private void chbPath5_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPath5.Checked)
            {
                btnPath5.Enabled = true;
            }
            else
            {
                btnPath5.Enabled = false;
            }
        }

        private void chbPath6_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPath6.Checked)
            {
                btnPath6.Enabled = true;
            }
            else
            {
                btnPath6.Enabled = false;
            }
        }

        private void chbPath7_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPath7.Checked)
            {
                btnPath7.Enabled = true;
            }
            else
            {
                btnPath7.Enabled = false;
            }
        }

        private void chbPath8_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPath8.Checked)
            {
                btnPath8.Enabled = true;
            }
            else
            {
                btnPath8.Enabled = false;
            }
        }

        private void btnPath1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtPath1.Text = ofd.FileName;
            }
        }

        private void btnPath2_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtPath2.Text = ofd.FileName;
            }
        }

        private void btnPath3_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtPath3.Text = ofd.FileName;
            }
        }

        private void btnPath4_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtPath4.Text = ofd.FileName;
            }
        }

        private void btnPath5_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtPath5.Text = ofd.FileName;
            }
        }

        private void btnPath6_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtPath6.Text = ofd.FileName;
            }
        }

        private void btnPath7_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtPath7.Text = ofd.FileName;
            }
        }

        private void btnPath8_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtPath8.Text = ofd.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "OuterPath.xml");
                XmlNodeList nodes = xmlDocument.SelectNodes("/Path/OuterConfig");
                foreach (XmlNode node in nodes)
                {
                    if (node != null)
                    {
                        XmlNode nodeID = node.SelectSingleNode("ID");
                        XmlNode nodeEnable = node.SelectSingleNode("isEnable");
                        XmlNode nodeOuterPath = node.SelectSingleNode("OuterPath");
                        switch (nodeID.InnerText)
                        {
                            case "1":
                                if (chbPath1.Checked)
                                {
                                    nodeEnable.InnerText = "1";
                                    nodeOuterPath.InnerText = txtPath1.Text;
                                }
                                else
                                {
                                    nodeEnable.InnerText = "0";
                                    nodeOuterPath.InnerText = "";
                                }
                                break;
                            case "2":
                                if (chbPath2.Checked)
                                {
                                    nodeEnable.InnerText = "1";
                                    nodeOuterPath.InnerText = txtPath2.Text;
                                }
                                else
                                {
                                    nodeEnable.InnerText = "0";
                                    nodeOuterPath.InnerText = "";
                                }
                                break;
                            case "3":
                                if (chbPath3.Checked)
                                {
                                    nodeEnable.InnerText = "1";
                                    nodeOuterPath.InnerText = txtPath3.Text;
                                }
                                else
                                {
                                    nodeEnable.InnerText = "0";
                                    nodeOuterPath.InnerText = "";
                                }
                                break;
                            case "4":
                                if (chbPath4.Checked)
                                {
                                    nodeEnable.InnerText = "1";
                                    nodeOuterPath.InnerText = txtPath4.Text;
                                }
                                else
                                {
                                    nodeEnable.InnerText = "0";
                                    nodeOuterPath.InnerText = "";
                                }
                                break;
                            case "5":
                                if (chbPath5.Checked)
                                {
                                    nodeEnable.InnerText = "1";
                                    nodeOuterPath.InnerText = txtPath5.Text;
                                }
                                else
                                {
                                    nodeEnable.InnerText = "0";
                                    nodeOuterPath.InnerText = "";
                                }
                                break;
                            case "6":
                                if (chbPath6.Checked)
                                {
                                    nodeEnable.InnerText = "1";
                                    nodeOuterPath.InnerText = txtPath6.Text;
                                }
                                else
                                {
                                    nodeEnable.InnerText = "0";
                                    nodeOuterPath.InnerText = "";
                                }
                                break;
                            case "7":
                                if (chbPath7.Checked)
                                {
                                    nodeEnable.InnerText = "1";
                                    nodeOuterPath.InnerText = txtPath7.Text;
                                }
                                else
                                {
                                    nodeEnable.InnerText = "0";
                                    nodeOuterPath.InnerText = "";
                                }
                                break;
                            case "8":
                                if (chbPath8.Checked)
                                {
                                    nodeEnable.InnerText = "1";
                                    nodeOuterPath.InnerText = txtPath8.Text;
                                }
                                else
                                {
                                    nodeEnable.InnerText = "0";
                                    nodeOuterPath.InnerText = "";
                                }
                                break;
                            default:
                                break;
                        }
                        
                    }
                }
                xmlDocument.Save(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "OuterPath.xml");
                if (MessageBox.Show("保存外接程序路径成功！\r\n 是否要关闭配置界面？", "KJ128A", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
                
            }
            catch
            {
            }
        }
    }
}
