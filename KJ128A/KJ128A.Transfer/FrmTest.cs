using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace KJ128A.Transfer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmTest : Form
    {
        NetTraner n;
        Thread t;
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        public FrmTest()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            t = new Thread(Start);
            n = new NetTraner("192.168.1.130", 1112, 1111);
            n.DataReceived += new NetTraner.DataReceivedEventHandler(n_DataReceived);
            n.ErrorMessage += new NetTraner.ErrorMessageEventHandler(n_ErrorMessage);
            n.InitSendLink += new NetTraner.InitSendLinkEventHandler(n_InitSendLink);
            n.InitListenLink += new NetTraner.InitListenLinkEventHandler(n_InitListenLink);
            n.CutSendLink += new NetTraner.CutSendLinkEventHandler(n_CutSendLink);
        }

        void n_CutSendLink()
        {
            MessageBox.Show("CutSendLink ok");
            //Thread.Sleep(10000);
        }

        void n_InitListenLink()
        {
            MessageBox.Show("11������������");
        }

        void n_InitSendLink()
        {
            MessageBox.Show("11���ͳ�������");
        }
        // �����¼�
        void n_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            textBox3.Text+= iErrNO+":"+strMessage;
        }
        //�����õ�������
        void n_DataReceived(byte[] dataInfo,out bool result)
        {
            textBox1.Text += Encoding.Default.GetString(dataInfo)+"\r\n";
            File.AppendAllText("c:/jieshou.txt", Encoding.Default.GetString(dataInfo));
            result = true;
            //MessageBox.Show("n_DataReceived:" + Encoding.Default.GetString(dataInfo) + "[" + dataInfo.Length.ToString()+"]");
        }

        //��������
        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        private void Start()
        {
            //n.SendMessage(Encoding.Default.GetBytes("A:" + DateTime.Now.ToString("yyyyMMddHHmmss.fff")), true); 
            //textBox2.Text += "��: 1\r\n";
            for (int i = 0; i < 300; i++)
            {
                while (true)
                {
                    if (n.SendMessage(Encoding.Default.GetBytes("A:" + i.ToString() + "    " + DateTime.Now.ToString("yyyyMMddHHmmss.fff"))))
                    {
                        File.AppendAllText("c:/Send.txt", "��: " + i + "\r\n");
                        textBox2.Text += "��: " + i + "\r\n";
                        Thread.Sleep(100);
                        break;
                    }
                }
            }
        }
        //�ر�socket�ͼ����߳�
        private void FrmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            n.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}