using System;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Collections;
using System.Timers;
using System.Xml;

namespace KJ128A.Controls.Batman
{
    /// <summary>
    /// ������
    /// </summary>
    public class Base_SerialPort
    {
        #region��Czlt-2010-11-29 ˫��ͨѶ��
        #region [ �¼�: ʱ��-��ʱȡ��˫��ͨѶ ]

        /// <summary>
        /// ʱ��-��ʱȡ��˫��ͨѶ
        /// </summary>
        protected Timer timer_Call = new Timer();

        /// <summary>
        /// ʱ��ؼ��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void timer_Call_Elapsed(object sender, ElapsedEventArgs e)
        {


        }

        #endregion
        #endregion
        #region [ ���� ]

        /// <summary>
        /// ���ݻ������Ĵ�С
        /// </summary>
        protected static int iBufferSize = 2048;
        /// <summary>
        /// �����־λ
        /// </summary>
        private bool flag = false;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        protected int sendTime = 660;
        #endregion

        #region [ ����:ί�� ] ������Ϣ�¼�

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="index">����, ����ʼ���������ʱ, ���������ڵĳ�ʼ����ʶ</param>
        /// <param name="iErrNO">������</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        public delegate void ErrorMessageEventHandler(int index, int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// ������Ϣ�¼�
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ ���� ] ��������

        /// <summary>
        /// ��ȡ�����ô�������
        /// </summary>
        public string PortName
        {
            get { return serialPort.PortName; }
            set { serialPort.PortName = value; }
        }

        #endregion

        #region [ ���� ] ����

        private int _Index;

        /// <summary>
        /// ����, ����ʼ���������ʱ, ���������ڵĳ�ʼ����ʶ
        /// </summary>
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        #endregion

        #region [ ���� ] ���ʱ��

        private double _Interval;

        /// <summary>
        /// ��ȡ�����ü��ʱ��
        /// </summary>
        public double Interval
        {
            get
            {
                _Interval = timer.Interval;
                return _Interval; 
            }
            set 
            {
                timer.Interval = value;
                _Interval = value; 
            }
        }

        #endregion

        #region [ �¼�: ʱ�� ]

        /// <summary>
        /// �����շ����ݵļ�ʱ��
        /// </summary>
        protected readonly Timer timer = new Timer();

        /// <summary>
        /// ʱ��ؼ��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void timer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }

        #endregion

        #region [ ���캯�� ]

        /// <summary>
        /// ������Դ�˿�
        /// </summary>
        protected readonly SerialPort serialPort = new SerialPort();

        /// <summary>
        /// ���캯��
        /// </summary>
        public Base_SerialPort()
        {
            LoadSendTimeFile();
            // ���ڲ�������
            serialPort.BaudRate = 1200;
            serialPort.Encoding = Encoding.UTF8;
            serialPort.Parity = Parity.Even;

            // �������ݵִ��¼�
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

            // ʱ���¼����������
            timer.Interval = sendTime;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);


            //Czlt-2010-11-29 -˫��ͨѶ
            timer_Call.Interval = 1800000;
            timer_Call.Elapsed += new ElapsedEventHandler(timer_Call_Elapsed);
            timer_Call.Enabled = false;
        }

        //public Base_SerialPort(string strPortName)
        //    : this()
        //{

        //}

        #endregion

        #region �����������ط���ʱ�䡿
        /// <summary>
        /// ���ط���ʱ���ļ�
        /// </summary>
        private void LoadSendTimeFile()
        {
            //����
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\SendTime.xml"))
            {
                try
                {
                    FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\SendTime.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<SendTime>");
                    sw.WriteLine("<send>1200</send>");
                    sw.WriteLine("</SendTime>");
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
                XmlDocument xmldocument = new XmlDocument();
                try
                {
                    //����
                    xmldocument.Load(Directory.GetCurrentDirectory() + "\\SendTime.xml");
                    XmlNode node = xmldocument.SelectSingleNode("SendTime/send");
                    sendTime = int.Parse(node.InnerText);
                }
                catch
                {
                    sendTime = 1200;
                }
            }
        }
        #endregion

        /*
         * ���ڵ���ز���
         */

        #region [ �¼�:���ݵִ� ]

        /// <summary>
        /// ��ǰ��������ָ��
        /// </summary>
        protected int iCurLoc = 0;

        /// <summary>
        /// ���ݻ�����
        /// </summary>
        protected byte[] byteBuffer = new byte[iBufferSize];

        /// <summary>
        /// ���ڵ����ݵִ��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (timer.Enabled == true)
            {
                timer.Enabled = false;
            }
            try
            {
                // ���ջ����������ݵ��ֽ���
                int int_Len = serialPort.BytesToRead;

                // ��������
                byte[] bytes = new byte[int_Len];
                serialPort.Read(bytes, 0, int_Len);

                if (RTxtMsgo != null)
                {
                    RTxtMsgo.WriteTxt(bytes, " RX ", true, 0);
                }

                // ���������
                if (iCurLoc + int_Len > iBufferSize)
                {
                    iCurLoc = 0;
                    return;
                }

                // �����ݴ��뻺����
                for (int i = 0; i < int_Len; i++)
                {
                    byteBuffer[iCurLoc + i] = bytes[i];
                }

                bytes = null;

                // �޸ĵ�ǰָ���λ��
                iCurLoc += int_Len;
            }
            catch 
            {
                if (timer.Enabled == false)
                {
                    timer.Enabled = true;
                }
            }
            finally
            {
                //if (timer.Enabled == false)
                //{
                //    timer.Enabled = true;
                //}
            }
        }

        #endregion

        #region [ ���� ] �򿪴���

        /// <summary>
        /// �򿪴���
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                }
                if (flag)
                {
                    ErrorMessage(Index, 0, "", "[Base_SerialPort:Open]", serialPort.PortName + "�����´�");
                    flag = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                if (!flag)
                {
                    ErrorMessage(Index, 1, ex.StackTrace, "[Base_SerialPort:Open]", ex.Message);
                    flag = true;
                }
                return false;
            }
        }

        #endregion

        #region [ ���� ] �رմ���

        /// <summary>
        /// �رմ���
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                flag = false;
                return true;
            }
            catch (Exception ex)
            {
                if (!flag)
                {
                    ErrorMessage(Index, 2, ex.StackTrace, "[Base_SerialPort:Close]", ex.Message);
                    flag = true;
                }
                return false;
            }
        }

        #endregion

        #region [ ���� ] ��������д����

        /// <summary>
        /// ������д����
        /// </summary>
        /// <param name="bytes">��Ҫ���͵��ֽ�����</param>
        /// <returns></returns>
        public bool Write(byte[] bytes)
        {
            try
            {
                //Czlt-20140213 �ڽ�������ǰ��ʧ���л�������
                serialPort.DiscardInBuffer();

                //����֮ǰ���߳�����20����
                //System.Threading.Thread.Sleep(20);

                // д����
                serialPort.Write(bytes, 0, bytes.Length);
                if (flag)
                {
                    ErrorMessage(Index, 0, "", "[Base_SerialPort:Open]", serialPort.PortName + "�����´�");
                    flag = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                if (serialPort != null && serialPort.IsOpen == false)
                {
                    Open();

                    try
                    {
                        serialPort.Write(bytes, 0, bytes.Length);
                    }
                    catch
                    {
                    }
                }
                if (!flag)
                {
                    ErrorMessage(Index, 4, ex.StackTrace, "[Base_SerialPort:Write]", ex.Message);
                    flag = true;
                }

                return false;
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        #endregion
        
        #region [ ���� ] ���Դ����Ƿ��Ѿ���

        /// <summary>
        /// ���Դ����Ƿ��Ѿ���
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            try
            {
                if (serialPort == null)
                {
                    return false;
                }

                return serialPort.IsOpen;
            }
            catch (Exception ex)
            {
                ErrorMessage(Index, 3, ex.StackTrace, "[Base_SerialPort:IsOpen]", ex.Message);
                return false;
            }
        }

        #endregion

        #region [ ���� ] ��ȡ���ڵ��б�

        /// <summary>
        /// ��ȡ���ڵ��б�
        /// </summary>
        /// <returns></returns>
        public static ArrayList List()
        {
            try
            {
                ArrayList al = new ArrayList();

                ManagementClass mc = new ManagementClass("Win32_SerialPort");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    al.Add(mo["DeviceID"].ToString());
                }

                return al;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        /*
         * ԭʼ������ʾ���
         */

        #region [ ���� ] ԭʼ����

        private KJRichTextBox _RTxtMsgo = null;

        /// <summary>
        /// ԭʼ����
        /// </summary>
        public KJRichTextBox RTxtMsgo
        {
            get { return _RTxtMsgo; }
            set { _RTxtMsgo = value; }
        }

        #endregion


        #region [ ���� ] ��־λ

        private int _Mark;

        /// <summary>
        /// ��־λ
        /// </summary>
        public int Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }

        #endregion

    }
}
