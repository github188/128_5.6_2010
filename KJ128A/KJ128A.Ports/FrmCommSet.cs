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
    /// ��������ҳ��
    /// </summary>
    public partial class FrmCommSet : Form
    {
        private CommParameter[] comm = null;
        private DataTable dtComms = null;
        private IFrmMain frmMain = null;
        private string strPath = string.Empty;
        bool commType = false;
        int tcpMark = 1;

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="strFilePath">XML�ļ�·��</param>
        /// <param name="frm">������</param>
        public FrmCommSet(string strFilePath, IFrmMain frm)
        {
            InitializeComponent();

            strPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\" + strFilePath;
            frmMain = frm;
        }

        #endregion 

        #region [ �¼�: ������� ]

        /// <summary>
        /// �������
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

            // ���ش�����Ϣ
            ReadData();

            cmbCommCount.Enabled = radioButton1.Checked;
            // Ĭ��ѡ�д��ڸ���
            if (dtComms.Rows.Count > 0)
            {
                cmbCommCount.SelectedIndex = dtComms.Rows.Count-1;
            }

            // ����������
            BuildCommPanel(dtComms.Rows.Count);

            // Ϊÿ������ʼ��ֵ
            FillCommPanel(dtComms.Select());
        }

        #endregion 

        #region [ �¼�: SelectedIndexChanged ]

        private void cmbCommCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iComCount = int.Parse(cmbCommCount.Text);

            BuildCommPanel(iComCount);

            FillCommPanel(dtComms.Select());            
        }

        #endregion 

        #region [ �¼�: �Զ���� ]

        private void btnAuto_Click(object sender, EventArgs e)
        {
            ArrayList list = Base_SerialPort.List();

            cmbCommCount.SelectedIndex = list.Count;
            // �������
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

            // �������
            FillCommPanel(dt.Select());
            
        }

        #endregion 

        #region [ �¼�: ���� ]

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // BuildCommPanel(0);

            ReadData();

            // Ĭ��ѡ�д��ڸ���
            if (dtComms.Rows.Count > 0)
            {
                cmbCommCount.SelectedIndex = dtComms.Rows.Count-1;
            }

            // ����������
            BuildCommPanel(dtComms.Rows.Count);

            // Ϊÿ������ʼ��ֵ
            FillCommPanel(dtComms.Select());
        }

        #endregion 

        #region [ �¼�: ���� ]

        private void btnSave_Click(object sender, EventArgs e)
        {
            // �жϴ����Ƿ�Ϊ���ã��Ƿ��д��ں���ͬ
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

            // ����ļ��������½�һ���ļ�
            if (!File.Exists(strPath))
            {
                File.AppendAllText(strPath, "");
            }

            try
            {
                // д��XML�ļ�
                dtComm.WriteXml(strPath);
            }
            catch
            { 
                // дXML�ļ�ʧ��
            }

            SaveCommType();

            MessageBox.Show("ͨѶ�����޸ĳɹ�����Ҫ����ͨѶ�������ʹ������������������Ч");
            this.Close();

            //if (MessageBox.Show("���������޸ĳɹ�����Ҫ����ͨѶ�������ʹ������������������Ч���Ƿ�����������", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    frmMain.Reset();
            //}
            //else
            //{
            //    this.Close();
            //}
        }

        #endregion 

        #region [ �¼�: ȡ�� ]

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // �ر�
            this.Close();
        }

        #endregion

        #region [����������ͨѶ��ʽ]
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
                    //����
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
                        //����
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
        #endregion [����������ͨѶ��ʽ]

        #region [����������ͨѶ��ʽ]
        /// <summary>
        /// ����ͨѶ��ʽ
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
                        //����
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
        #endregion [����������ͨѶ��ʽ]

        #region [ ���� : ��ʼ��SerialPort�� ]

        /// <summary>
        /// ��ʼ��SerialPort�� 
        /// </summary>
        /// <returns>��</returns>
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

        #region [ ����: ���ش�����Ϣ ]

        /// <summary>
        /// ���ش�����Ϣ
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

        #region [ ����: �ж��Ƿ�����ͬ�Ĵ��ںţ��������ģ�]

        /// <summary>
        /// �ж��Ƿ�����ͬ�Ĵ��ںţ��������ģ�
        /// </summary>
        /// <returns></returns>
        public bool CheckSame()
        {
            string[] strCommPort = new string[comm.Length];

            // ��ȡ��������
            for (int i = 0; i < strCommPort.Length; i++)
            {
                strCommPort[i] = (comm[i].IsCheck) ? comm[i].PortName : string.Empty;
            }

            // ���������ͬ�� [��������]
            for (int i = 0; i < strCommPort.Length; i++)
            {
                if (strCommPort[i] == string.Empty) continue;

                for (int j = i + 1; j < strCommPort.Length; j++)
                {
                    if (strCommPort[j] == string.Empty) continue;

                    if (strCommPort[i] == strCommPort[j])
                    {
                        // ��ɫ��ʾ
                        comm[i].Same_ProtName = true;
                        comm[j].Same_ProtName = true;
                        return false;
                    }

                    // �ָ���ɫ
                    comm[i].Same_ProtName = false;
                }
            }

            return true;
        }

        #endregion

        #region [ ����: �ж�����еı�־λ�ͻ�վ���Ƿ�һ���������õģ� ]

        /// <summary>
        /// [ ����: �ж�����еı�־λ�ͻ�վ���Ƿ���ͬ�������õģ�]
        /// </summary>
        /// <returns></returns>
        public bool MarkGroupSame()
        {
            int[] strMark = new int[comm.Length];
            int[] strGroup = new int[comm.Length];

            // ��ȡ��վ�����ƺͱ�־λ
            for (int i = 0; i < strGroup.Length; i++)
            {
                strMark[i] = (comm[i].IsCheck) ? comm[i].Mark : 0;
                strGroup[i] = (comm[i].IsCheck) ? comm[i].Group : 0;
            }

            // ���������ͬ�ı�־λ�ͻ�վ��
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

        #region [ ����: ���� DataTable ���� CommPanel ]

        /// <summary>
        /// ���� DataTable ���� CommPanel
        /// </summary>
        /// <param name="drs"></param>
        private void FillCommPanel(DataRow[] drs)
        {
            int iCount = 0;

            // �ҵ���Ч�����ݸ���
            if (drs.Length > comm.Length)
            {
                iCount = comm.Length;
            }
            else
            {
                iCount = drs.Length;
            }

            // ���ش������
            for (int i = 0; i < iCount; i++)
            {
                DataRow dr = drs[i];

                // ��������������
                comm[i].PortTitle = (i + 1) + " ���ں�";
                comm[i].PortName = dr[1].ToString();
                comm[i].BaudRate = 1200;

                comm[i].Group = int.Parse(dr[2].ToString());
                comm[i].Mark = int.Parse(dr[3].ToString());
                comm[i].IsCheck = bool.Parse(dr[4].ToString());
            }

            if (drs.Length < comm.Length)
            {
                // ����Ĳ���Ҫʵ����
                int iCommNO = 1;
                for (int i = drs.Length; i < comm.Length; i++)
                {
                    comm[i].PortTitle = (i + 1) + " ���ں�";

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

        #region [ ����: ���� ����� ���� CommPanel ]

        /// <summary>
        /// ���� ����� ���� CommPanel
        /// </summary>
        /// <param name="iCount">�����</param>
        private void BuildCommPanel(int iCount)
        {
            comm = new CommParameter[iCount];

            // ���
            splitContainer2.Panel1.Controls.Clear();

            // ���ش������
            for (int i = 0; i < iCount; i++)
            {
                // ��������������
                comm[i] = new CommParameter();
                comm[i].Enabled = radioButton1.Checked;
                // �߽���ʽ
                comm[i].Top = i * 50;
                comm[i].Left = 10;

                // ���ص��ؼ���
                splitContainer2.Panel1.Controls.Add(comm[i]);
            }

            this.Height = 195 + iCount * 50;
        }

        #endregion

        private void radioButton1_Click(object sender, EventArgs e)
        {
            #region �����ڽ��棨���ã���
            radioButton1.Checked = true;
            cmbCommCount.Enabled = true;
            for (int i = 0; i < int.Parse(cmbCommCount.SelectedItem.ToString()); i++)
            {
                splitContainer2.Panel1.Controls[i].Enabled = true;
            }
            #endregion

            #region ��������Ϣ�������ã���
            radioButton2.Checked = false;
            comboBox1.Enabled = false;
            #endregion
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            #region �����ڽ��棨�����ã���
            radioButton1.Checked = false;
            cmbCommCount.Enabled = false;
            for (int i = 0; i < int.Parse(cmbCommCount.SelectedItem.ToString()); i++)
            {
                splitContainer2.Panel1.Controls[i].Enabled = false;
            }
            #endregion

            #region ��������Ϣ�����ã���
            radioButton2.Checked = true;
            comboBox1.Enabled = true;
            #endregion
        }
    }
}