using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing;
using System.Management;

namespace KJ128A.Ports
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CommParameter :UserControl
    {
        private SerialPort commPort = null;

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        public CommParameter()
        {
            InitializeComponent();
            try
            {
                //ManagementClass class2 = new ManagementClass("Win32_SerialPort");
                //foreach (ManagementObject obj2 in class2.GetInstances())
                //{
                //    this.cmbCommPort.Items.Add(obj2["DeviceID"].ToString());
                //}

                foreach (string mo in SerialPort.GetPortNames())
                {
                    this.cmbCommPort.Items.Add(mo);
                } 
                if (this.cmbCommPort.Items.Count > 0)
                {
                    this.cmbCommPort.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("��ȡCOM����Ϣʧ��,ʧ����Ϣ��" + exception.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        #endregion 

        #region [ ���� : ���ڱ��� ]

        /// <summary>
        /// ���ڱ���
        /// </summary>
        public string PortTitle
        {
            get { return gpbPort.Text; }
            set { gpbPort.Text = value; }
        }

        #endregion 

        #region [ ���� : ���ں� ]

        /// <summary>
        /// ���ں�
        /// </summary>
        public string PortName
        {
            get { return cmbCommPort.Text; }
            set { cmbCommPort.Text = value; }
        }

        #endregion

        #region [ ���� : ������ ]

        /// <summary>
        ///  ������
        /// </summary>
        public int BaudRate
        {
            get { return int.Parse(cmbBaudRate.Text); }
            set
            {
                int iValue = value / 300;
                int iCount = 0;
                while (iValue != 1)
                {
                    iValue /= 2;
                    iCount++;
                }
                cmbBaudRate.SelectedIndex = iCount;
            }
        }

        #endregion 

        #region [ ���� : ��־λ ]

        /// <summary>
        /// ��־λ
        /// </summary>
        public int Mark
        {
            get { return int.Parse(cmbMark.Text); }
            set { cmbMark.Text = value.ToString(); }
        }

        #endregion

        #region [ ���� : ��վ�� ]

        /// <summary>
        /// ��վ��
        /// </summary>
        public int Group
        {
            get { return int.Parse(cmbGroup.Text); }
            set { cmbGroup.Text = value.ToString(); }
        }

        #endregion

        #region [ ���� : �Ƿ����� ]

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsCheck
        {
            get { return chkInvo.Checked; }
            set { chkInvo.Checked = value; gpbPort.Enabled = value; }
        }

        #endregion

        #region [ ���� : ��ͬ�Ĵ����� ]

        private bool bln_Same_ProtName = false;

        /// <summary>
        /// ��ͬ�Ĵ�����
        /// </summary>
        public bool Same_ProtName
        {
            get { return bln_Same_ProtName; }
            set
            {
                bln_Same_ProtName = value;
                if (value)
                {
                    cmbCommPort.ForeColor = Color.Red;
                }
                else
                {
                    cmbCommPort.ForeColor = Color.Black;
                }
            }
        }

        #endregion

        #region [ ���� : ��ͬ�ı�־λ����վ�� ]

        private bool bln_Same_MarkGroup = false;

        /// <summary>
        /// ��ͬ�ı�־λ����վ��
        /// </summary>
        public bool Same_MarkGroup
        {
            get { return bln_Same_MarkGroup; }
            set 
            {
                bln_Same_MarkGroup = value;
                if (value)
                {
                    cmbGroup.ForeColor = cmbMark.ForeColor = Color.Red;
                }
                else
                {
                    cmbGroup.ForeColor = cmbMark.ForeColor = Color.Black;
                }
            }
        }

        #endregion


        #region [ �¼� : ��ť ]

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (cmbCommPort.Text.Trim().Equals(string.Empty))
            { 
                // ��ʾ ��д���ں�
                ChangeState(lblCommState, 4);
                return;
            }

            if (btnOpenClose.Text == "�򿪴���")
            {
                if (StartPort.s_serialPort != null)
                {
                    for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                    {
                        if (StartPort.s_serialPort[i].PortName == cmbCommPort.Text)
                        {
                            if (StartPort.s_serialPort[i].IsOpen())
                            {
                                ChangeState(lblCommState, 5);
                                return;
                            }
                        }
                    }
                }

                if (commPort == null)
                {
                    commPort = new SerialPort(cmbCommPort.Text, int.Parse(cmbBaudRate.Text));
                }
                // �򿪴���
                Open();

                // �ж��Ƿ��
                if (!IsOpen())
                {
                    // ��ʾ���ڴ�ʧ��
                    ChangeState(lblCommState, 3);
                    return;
                }

                btnOpenClose.Text = "�رմ���";
                // ��ʾ����״̬
                ChangeState(lblCommState, 1);
            }
            else
            {
                Close();

                btnOpenClose.Text = "�򿪴���";
                // ��ʾ����״̬
                ChangeState(lblCommState, 2);
            }
        }

        #endregion 
   
        #region [ �¼� : �Ƿ�����]

        private void chkInvo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInvo.Checked)
            {
                gpbPort.Enabled = true;
            }
            else
            {
                gpbPort.Enabled = false;
                ChangeState(lblCommState, 6);
                btnOpenClose.Text = "�򿪴���";
            }
        }

        #endregion

        #region [ ���� : ���Ĵ���״̬ ]

        /// <summary>
        /// ���Ĵ���״̬
        /// </summary>
        /// <param name="lblState">��ʾ�ؼ�</param>
        /// <param name="iState">״̬��1���� 2���ر� 3����ʧ�� 4����д��</param>
        public void ChangeState(Label lblState, int iState)
        {
            switch (iState)
            { 
                case 1:
                    lblState.ForeColor = Color.Blue;
                    cmbBaudRate.Enabled = false;
                    cmbCommPort.Enabled = false;
                    cmbMark.Enabled = false;
                    cmbGroup.Enabled = false;
                    lblState.Text = "���ڴ�״̬";
                    break;
                case 2:
                    lblState.Text = "���ڹر�״̬";
                    lblState.ForeColor = Color.Black;
                    cmbBaudRate.Enabled = true;
                    cmbCommPort.Enabled = true;
                    cmbMark.Enabled = true;
                    cmbGroup.Enabled = true;
                    break;
                case 3:
                    lblState.Text = "���ڴ�ʧ��";
                    lblState.ForeColor = Color.Red;
                    break;
                case 4:
                    lblState.Text = "����д���ں�";
                    lblState.ForeColor = Color.Red;
                    break;
                case 5:
                    lblState.Text = "����ʹ����";
                    lblState.ForeColor = Color.Green;
                    break;
                case 6:
                    lblState.Text = "����״̬δ֪";
                    lblState.ForeColor = Color.Black;
                    break;
            }
        }

        #endregion

        #region  [ ���� : �򿪴��� ]

        /// <summary>
        ///  �򿪴���
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                if (!commPort.IsOpen)
                {
                    commPort.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region [ ���� : �رմ��� ]

        /// <summary>
        /// �رմ���
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            try
            {
                if (commPort!=null)
                {
                    commPort.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region [ ���� : �жϴ����Ƿ�� ]

        /// <summary>
        /// �жϴ����Ƿ��
        /// </summary>
        /// <returns>true ��</returns>
        public bool IsOpen()
        {
            try
            {
                if (commPort == null) return false;
                return commPort.IsOpen;
            }
            catch
            {
                return false;
            }
        }

        #endregion 

    }
}
