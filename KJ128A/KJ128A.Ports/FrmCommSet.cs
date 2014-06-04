using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using KJ128A.Controls.Batman;
using KJ128A.BatmanAPI;

namespace KJ128A.Ports
{
    /// <summary>
    /// 串口配置页面
    /// </summary>
    public partial class FrmCommSet : Form
    {
        private CommParameter[] comm = null;
        private DataTable dtComms = null;
        private IFrmMain frmMain = null;
        private string strPath = string.Empty;
        bool commType = false;
        int tcpMark = 1;

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strFilePath">XML文件路径</param>
        /// <param name="frm">主窗体</param>
        public FrmCommSet(string strFilePath, IFrmMain frm)
        {
            InitializeComponent();

            strPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strFilePath;
            frmMain = frm;
        }

        #endregion 

        #region [ 事件: 窗体加载 ]

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCommSet_Load(object sender, EventArgs e)
        {
            LoadCommType();

            if (commType)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            comboBox1.Text = tcpMark.ToString();
            comboBox1.Enabled = radioButton2.Checked;

            // 加载串口信息
            ReadData();

            cmbCommCount.Enabled = radioButton1.Checked;
            // 默认选中串口个数
            if (dtComms.Rows.Count > 0)
            {
                cmbCommCount.SelectedIndex = dtComms.Rows.Count-1;
            }

            // 创建面板对象集
            BuildCommPanel(dtComms.Rows.Count);

            // 为每个面板初始化值
            FillCommPanel(dtComms.Select());
        }

        #endregion 

        #region [ 事件: SelectedIndexChanged ]

        private void cmbCommCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iComCount = int.Parse(cmbCommCount.Text);

            BuildCommPanel(iComCount);

            FillCommPanel(dtComms.Select());            
        }

        #endregion 

        #region [ 事件: 自动检测 ]

        private void btnAuto_Click(object sender, EventArgs e)
        {
            ArrayList list = Base_SerialPort.List();

            cmbCommCount.SelectedIndex = list.Count;
            // 构造面板
            BuildCommPanel(list.Count);

            // 
            DataTable dt = BuildTable();
            for (int i = 0; i < list.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i + 1;
                dr[1] = list[i].ToString();
                dr[2] = i + 1;
                dr[3] = i + 1;
                dr[4] = false;
                dt.Rows.Add(dr);
            }

            // 填充数据
            FillCommPanel(dt.Select());
            
        }

        #endregion 

        #region [ 事件: 加载 ]

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // BuildCommPanel(0);

            ReadData();

            // 默认选中串口个数
            if (dtComms.Rows.Count > 0)
            {
                cmbCommCount.SelectedIndex = dtComms.Rows.Count-1;
            }

            // 创建面板对象集
            BuildCommPanel(dtComms.Rows.Count);

            // 为每个面板初始化值
            FillCommPanel(dtComms.Select());
        }

        #endregion 

        #region [ 事件: 保存 ]

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 判断串口是否为启用，是否有串口号相同
            if (!CheckSame())
            {
                return;
            }
            if (!MarkGroupSame())
            {
                return;
            }

            DataTable dtComm = BuildTable();
            int iRowCount = 1;
            foreach (CommParameter ctl in (splitContainer2.Panel1.Controls))
            {
                DataRow dr = dtComm.NewRow();
                dr[0] = iRowCount;
                dr[1] = ctl.PortName;
                dr[2] = ctl.Group;
                dr[3] = ctl.Mark;
                dr[4] = ctl.IsCheck;
                dtComm.Rows.Add(dr);
                iRowCount++;
            }

            // 如果文件不存在新建一个文件
            if (!File.Exists(strPath))
            {
                File.AppendAllText(strPath, "");
            }

            try
            {
                // 写如XML文件
                dtComm.WriteXml(strPath);
            }
            catch
            { 
                // 写XML文件失败
            }

            SaveCommType();

            MessageBox.Show("通讯配置修改成功，需要重启通讯程序才能使您所做的配置立即生效");
            this.Close();

            //if (MessageBox.Show("串口配置修改成功，需要重启通讯程序才能使您所做的配置立即生效，是否立即重启？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    frmMain.Reset();
            //}
            //else
            //{
            //    this.Close();
            //}
        }

        #endregion 

        #region [ 事件: 取消 ]

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 关闭
            this.Close();
        }

        #endregion

        #region [方法：保存通讯方式]
        private void SaveCommType()
        {
            int iCommtype;
            if (radioButton1.Checked == true)
            {
                iCommtype = 0;
            }
            else
            {
                iCommtype = 1;
            }
            if (!File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml"))
            {
                try
                {
                    //创建
                    FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<comm>");
                    sw.WriteLine("<commType>" + iCommtype.ToString() + "</commType>");
                    sw.WriteLine("<TcpMark>" + comboBox1.SelectedText + "</TcpMark>");
                    sw.WriteLine("</comm>");
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                catch { }
            }
            else
            {
                XmlDocument xmlDocument = new XmlDocument();
                try
                {
                    xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml");
                    XmlNode node = xmlDocument.SelectSingleNode("/comm/commType");
                    node.InnerText = iCommtype.ToString();
                    XmlNode tcpMarkNode = xmlDocument.SelectSingleNode("/comm/TcpMark");
                    tcpMarkNode.InnerText = comboBox1.SelectedItem.ToString();
                    xmlDocument.Save(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml");
                }
                catch
                {
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml"))
                        {
                            File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml");
                        }
                        //创建
                        FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                        sw.WriteLine("<comm>");
                        sw.WriteLine("<commType>" + iCommtype.ToString() + "</commType>");
                        sw.WriteLine("<TcpMark>" + comboBox1.SelectedText + "</TcpMark>");
                        sw.WriteLine("</comm>");
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                        fs.Close();
                        fs.Dispose();
                    }
                    catch { }
                }
            }
        }
        #endregion [方法：保存通讯方式]

        #region [方法：加载通讯方式]
        /// <summary>
        /// 加载通讯方式
        /// </summary>
        /// <returns></returns>
        private bool LoadCommType()
        {
            try
            {
                if (!File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml"))
                {
                    try
                    {
                        //创建
                        FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                        sw.WriteLine("<comm>");
                        sw.WriteLine("<commType>0</commType>");
                        sw.WriteLine("<TcpMark>1</TcpMark>");
                        sw.WriteLine("</comm>");
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                        fs.Close();
                        fs.Dispose();
                    }
                    catch { }
                    finally
                    {
                        commType = false;
                        tcpMark = 1;
                    }
                }
                else
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    try
                    {
                        xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml");
                        XmlNode node = xmlDocument.SelectSingleNode("/comm/commType");
                        if (node.InnerText != "" && node.InnerText.Equals("1") == true)
                        {
                            commType = true;
                        }
                        else
                        {
                            commType = false;
                        }
                        XmlNode tcpMarkNode = xmlDocument.SelectSingleNode("/comm/TcpMark");
                        if (tcpMarkNode.InnerText != "")
                        {
                            try
                            {
                                tcpMark = int.Parse(tcpMarkNode.InnerText);
                            }
                            catch { tcpMark = 1; }
                        }
                        else
                        {
                            tcpMark = 1;
                        }
                    }
                    catch
                    {
                        commType = false;
                        tcpMark = 1;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion [方法：加载通讯方式]

        #region [ 方法 : 初始化SerialPort表 ]

        /// <summary>
        /// 初始化SerialPort表 
        /// </summary>
        /// <returns>表</returns>
        public DataTable BuildTable()
        {
            DataTable dtSerialPort = new DataTable();
            dtSerialPort.TableName = "SerialPort";

            DataColumn colID = new DataColumn("ID", typeof(int));
            dtSerialPort.Columns.Add(colID);

            DataColumn colPortName = new DataColumn("PortName", typeof(string));
            dtSerialPort.Columns.Add(colPortName);

            DataColumn colGroup = new DataColumn("Group", typeof(int));
            dtSerialPort.Columns.Add(colGroup);

            DataColumn colMark = new DataColumn("Mark", typeof(int));
            dtSerialPort.Columns.Add(colMark);

            DataColumn colIsEnable = new DataColumn("IsEnable", typeof(bool));
            dtSerialPort.Columns.Add(colIsEnable);

            return dtSerialPort;
        }

        #endregion

        #region [ 方法: 加载串口信息 ]

        /// <summary>
        /// 加载串口信息
        /// </summary>
        public void ReadData()
        {
            dtComms = BuildTable();

            try
            {
                dtComms.ReadXml(strPath);
            }
            catch
            {
                
            }
        }

        #endregion 

        #region [ 方法: 判断是否有相同的串口号（仅启动的）]

        /// <summary>
        /// 判断是否有相同的串口号（仅启动的）
        /// </summary>
        /// <returns></returns>
        public bool CheckSame()
        {
            string[] strCommPort = new string[comm.Length];

            // 获取串口名称
            for (int i = 0; i < strCommPort.Length; i++)
            {
                strCommPort[i] = (comm[i].IsCheck) ? comm[i].PortName : string.Empty;
            }

            // 检查有无相同的 [串口名称]
            for (int i = 0; i < strCommPort.Length; i++)
            {
                if (strCommPort[i] == string.Empty) continue;

                for (int j = i + 1; j < strCommPort.Length; j++)
                {
                    if (strCommPort[j] == string.Empty) continue;

                    if (strCommPort[i] == strCommPort[j])
                    {
                        // 红色显示
                        comm[i].Same_ProtName = true;
                        comm[j].Same_ProtName = true;
                        return false;
                    }

                    // 恢复黑色
                    comm[i].Same_ProtName = false;
                }
            }

            return true;
        }

        #endregion

        #region [ 方法: 判断面板中的标志位和基站组是否一样（已启用的） ]

        /// <summary>
        /// [ 方法: 判断面板中的标志位和基站组是否相同（已启用的）]
        /// </summary>
        /// <returns></returns>
        public bool MarkGroupSame()
        {
            int[] strMark = new int[comm.Length];
            int[] strGroup = new int[comm.Length];

            // 获取基站组名称和标志位
            for (int i = 0; i < strGroup.Length; i++)
            {
                strMark[i] = (comm[i].IsCheck) ? comm[i].Mark : 0;
                strGroup[i] = (comm[i].IsCheck) ? comm[i].Group : 0;
            }

            // 检查有无相同的标志位和基站组
            for (int i = 0; i < strMark.Length; i++)
            {
                if (strMark[i] == 0) continue;
                for (int j = i + 1; j < strMark.Length; j++)
                {
                    if (strMark[i] == 0) continue;
                    if (strMark[i] == strMark[j])
                    {
                        if (strGroup[i] == strGroup[j])
                        {
                            comm[i].Same_MarkGroup = true;
                            comm[j].Same_MarkGroup = true;
                            return false;
                        }
                    }
                    comm[i].Same_MarkGroup = false;
                    comm[j].Same_MarkGroup = false;
                }
            }
            return true;
        }

        #endregion 

        #region [ 方法: 根据 DataTable 创建 CommPanel ]

        /// <summary>
        /// 根据 DataTable 创建 CommPanel
        /// </summary>
        /// <param name="drs"></param>
        private void FillCommPanel(DataRow[] drs)
        {
            int iCount = 0;

            // 找到有效的数据个数
            if (drs.Length > comm.Length)
            {
                iCount = comm.Length;
            }
            else
            {
                iCount = drs.Length;
            }

            // 加载串口面板
            for (int i = 0; i < iCount; i++)
            {
                DataRow dr = drs[i];

                // 创建串口面板对象
                comm[i].PortTitle = (i + 1) + " 串口号";
                comm[i].PortName = dr[1].ToString();
                comm[i].BaudRate = 1200;

                comm[i].Group = int.Parse(dr[2].ToString());
                comm[i].Mark = int.Parse(dr[3].ToString());
                comm[i].IsCheck = bool.Parse(dr[4].ToString());
            }

            if (drs.Length < comm.Length)
            {
                // 多出的部分要实例化
                int iCommNO = 1;
                for (int i = drs.Length; i < comm.Length; i++)
                {
                    comm[i].PortTitle = (i + 1) + " 串口号";

                    while (true)
                    {
                        bool blnExit = true;
                        for (int j = 0; j < drs.Length; j++)
                        {
                            if (drs[j][1].ToString() == "COM" + (iCommNO))
                            {
                                iCommNO++;
                                blnExit = false;
                            }
                        }

                        if (blnExit)
                        {
                            break;
                        }
                    }
                    comm[i].PortName = "COM" + (iCommNO);
                    comm[i].BaudRate = 1200;
                    comm[i].Group = i+1;    
                    comm[i].Mark = i+1;
                    comm[i].IsCheck = false;

                    iCommNO++;
                }
            }
        }

        #endregion

        #region [ 方法: 根据 面板数 创建 CommPanel ]

        /// <summary>
        /// 根据 面板数 创建 CommPanel
        /// </summary>
        /// <param name="iCount">面板数</param>
        private void BuildCommPanel(int iCount)
        {
            comm = new CommParameter[iCount];

            // 清空
            splitContainer2.Panel1.Controls.Clear();

            // 加载串口面板
            for (int i = 0; i < iCount; i++)
            {
                // 创建串口面板对象
                comm[i] = new CommParameter();
                comm[i].Enabled = radioButton1.Checked;
                // 边界样式
                comm[i].Top = i * 50;
                comm[i].Left = 10;

                // 加载到控件中
                splitContainer2.Panel1.Controls.Add(comm[i]);
            }

            this.Height = 195 + iCount * 50;
        }

        #endregion

        private void radioButton1_Click(object sender, EventArgs e)
        {
            #region 【串口界面（启用）】
            radioButton1.Checked = true;
            cmbCommCount.Enabled = true;
            for (int i = 0; i < int.Parse(cmbCommCount.SelectedItem.ToString()); i++)
            {
                splitContainer2.Panel1.Controls[i].Enabled = true;
            }
            #endregion

            #region 【环网信息（不启用）】
            radioButton2.Checked = false;
            comboBox1.Enabled = false;
            #endregion
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            #region 【串口界面（不启用）】
            radioButton1.Checked = false;
            cmbCommCount.Enabled = false;
            for (int i = 0; i < int.Parse(cmbCommCount.SelectedItem.ToString()); i++)
            {
                splitContainer2.Panel1.Controls[i].Enabled = false;
            }
            #endregion

            #region 【环网信息（启用）】
            radioButton2.Checked = true;
            comboBox1.Enabled = true;
            #endregion
        }
    }
}