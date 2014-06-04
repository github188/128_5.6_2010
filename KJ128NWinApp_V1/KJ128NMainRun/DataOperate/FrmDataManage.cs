using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using KJ128NDataBase;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.DataOperate
{
    public partial class FrmDataManage : Wilson.Controls.Docking.DockContent
    {
        private Thread myThread;
        // dbName ���������ݿ��� serverIp ���ݿ����ڻ�����ip path��ֵʹ��
        private string dbName = "kj128n",serverIp="127.0.0.1",path = "";
        private int WM_NCLBUTTONDOWN = 0x00A1;
        private int HTCLOSE = 20;

        #region [ ���캯�� ]

        public FrmDataManage()
        {
            InitializeComponent();
            Init();                                                 // ��ʼ��
            Control.CheckForIllegalCrossThreadCalls = false;        // ������Դ����̵߳ĵ���
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        #endregion

        #region [ ���� ]

        #region [ ����: ��ʼ�� ]

        private void Init()
        {
            txtPath.Text = @"D:\database\backup";          // ��ʼ�������ļ�Ĭ���ļ���
            // �ļ��в������򴴽�
            if (!Directory.Exists(@"D:\database\backup"))
            {
                Directory.CreateDirectory(@"D:\database\backup");
            }
            lblBackupPath.Visible = false;
            lblFileName.Visible = false;
        }

        #endregion

        #region [ ����: ���岻���϶� ]

        protected override void WndProc(ref   Message msg)
        {
            if (msg.Msg == WM_NCLBUTTONDOWN)
                if (msg.WParam.ToInt32() != HTCLOSE)
                    return;
            base.WndProc(ref   msg);
        }

        #endregion

        #region [ ����: ִ�в���ʱ����Ч�� ]

        /// <summary>
        /// ִ�в���ʱ����Ч��
        /// </summary>
        /// <param name="state">ִ�в���ʱ����״̬ 0�޲��� 1���� 2��ԭ</param>
        private void RunState(int state)
        {
            switch (state)
            {
                case 0:
                    // ��ť״̬
                    btnBackup.Enabled = true;
                    btnRevert.Enabled = true;
                    btnScan.Enabled = true;
                    lblInfo.Visible = false;
                    lbl.Visible = false;
                    pBarDB.Visible = false;
                    break;
                case 1:
                    // ��ť״̬
                    pBarDB.Value = 0;
                    btnBackup.Enabled = false;
                    btnRevert.Enabled = false;
                    btnScan.Enabled = false;

                    lblBackupPath.Visible = false;
                    lblFileName.Visible = false;
                    linklblScan.Visible = false;        // �����ť״̬
                    lblInfo.Visible = true;
                    lblInfo.Text = "���ݿⱸ�ݽ���";      // ������ʾ��Ϣ
                    break;
                case 2:
                    // ��ť״̬
                    pBarDB.Value = 0;
                    btnBackup.Enabled = false;
                    btnRevert.Enabled = false;
                    btnScan.Enabled = false;

                    lblBackupPath.Visible = false;
                    lblFileName.Visible = false;
                    linklblScan.Visible = false;        // �����ť״̬
                    lblInfo.Visible = true;
                    lblInfo.Text = "���ݿ⻹ԭ����";      // ������ʾ��Ϣ
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ ����: ���ݡ���ԭ ]

        /// <summary>
        /// ִ�л�ԭ
        /// </summary>
        private void RestoreThread()
        {
            if (DataOperateBLL.RestoreDB(dbName, path, serverIp, "sa", "sa",pBarDB))
            {
                MessageBox.Show("��ԭ�ɹ�");
            }
            RunState(0);
        }

        /// <summary>
        /// ִ�б���
        /// </summary>
        private void BackupThread()
        {
            if (DataOperateBLL.BackUPDB(dbName, path, serverIp, "sa", "sa", pBarDB))
            {
                string p = txtPath.Text;
                p = p.Length > 24 ? (p.Substring(0, 24) + "...") : p;
                lblBackupPath.Text = p;
                lblFileName.Text = "�ļ���Ϊ " + txtPath.Tag.ToString();
                if (MessageBox.Show(@"���Ѿ��ɹ������ݿⱸ�ݵ�" + "\r\n" + p + "\r\n�ļ���Ϊ " + txtPath.Tag.ToString() + "\r\n�Ƿ���ļ���",
                    "��ʾ��Ϣ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select,"+txtPath.Text+"\\" + txtPath.Tag.ToString());
                }
            }
            RunState(0);
        }

        #endregion

        #region [ ����: ��ʾ�������ٷֱ� ]

        private void DisplayBarValue()
        {
            lbl.Visible = true;                     // ��ʾ���Ȱٷֱ�
            Thread th = new Thread(BarValue);
            th.Start();
        }

        private void BarValue()
        {
            
            while (pBarDB.Value < 100)
            {
                lbl.Text = "����� " + pBarDB.Value + "%";
                Thread.Sleep(1000);
            }
            lbl.Text = "���";
        }

        #endregion
        
        #endregion

        #region [ �¼� ]

        #region [ �¼�: ����ѡ���ļ��� ]

        private void btnScan_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog s = new FolderBrowserDialog();
            if (s.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = s.SelectedPath;
            }
        }

        #endregion

        #region [ �¼�: ���� ]

        private void btnBackup_Click(object sender, EventArgs e)
        {
            // �����ݵ��ļ���������txtPath.Tag��
            txtPath.Tag = dbName + DateTime.Now.ToString("[yyyyMMdd-HHmm]");

            // �����ļ�·��
            if (txtPath.Tag == null) return;
            path = txtPath.Text + "\\" + txtPath.Tag.ToString();

            // ����ʱ����Ч��
            RunState(1);
            DisplayBarValue();                  // ��ʾ���Ȱٷֱ�
            // �����߳�ִ�б���
            myThread = new Thread(new ThreadStart(BackupThread));
            myThread.Start();

            //������־
            LogSave.Messages("[FrmDataManage]", LogIDType.UserLogID, "���ݿⱸ�ݣ�������־·��Ϊ��" + path);
        }

        #endregion

        #region [ �¼�: ������� ��������ļ� ]

        private void linklblScan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ���ļ��� ��Ĭ��ѡ�б��ݺ���ļ�
            if (linklblScan.Tag != null)
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select," + linklblScan.Tag.ToString() + "\\" + txtPath.Tag.ToString());
            }
        }

        #endregion

        #region [ �¼�: ��ԭ ]

        private void btnRevert_Click(object sender, EventArgs e)
        {
            #region [ ���ѡ���ļ� ]

            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = @"D:\database\backup"; // Ĭ��·��ΪĬ�ϱ���·��
            if (o.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = o.FileName;
            }
            else
            {
                return;
            }

            #endregion

            #region [ ��ԭ���ݿ����ʱ�Ƿ��ȱ��� ]

            // ���ݿ����ʱ��ʾ�Ǳ��ݷ�ǿ�ƻ�ԭ
            ArrayList array = DataOperateBLL.GetDbList(serverIp, "sa", "sa");
            foreach (object obj in array)
            {
                if (obj.ToString().ToLower() == dbName.ToLower())
                {
                    DialogResult msgType = MessageBox.Show("���ݿ� ["
                        + dbName
                        + "] �Ѵ���,��ԭǰ�Ƿ��ȱ���", "��ʾ��Ϣ", MessageBoxButtons.YesNoCancel);
                    // ����
                    if (msgType == DialogResult.Yes)
                    {
                        // ����ǰѡ���ļ���
                        FolderBrowserDialog s = new FolderBrowserDialog();
                        if (s.ShowDialog() == DialogResult.OK)
                        {
                            txtPath.Text = s.SelectedPath;
                        }
                        else
                        {
                            return;
                        }

                        // ����
                        btnBackup_Click(sender, e);
                        return;
                    }// ȡ����ԭ
                    else if (msgType == DialogResult.Cancel)
                    {
                        lblInfo.Visible = false;
                        return;
                    }
                }
            }

            #endregion

            // ��ԭ�ļ�·�����ļ���
            path = txtFile.Text;

            // ��ԭʱ����Ч��
            RunState(2);
            DisplayBarValue();              // ��ʾ���Ȱٷֱ�
            // �����߳�ִ�л�ԭ
            myThread = new Thread(RestoreThread);
            myThread.Start();

            //������־
            LogSave.Messages("[FrmDataManage]", LogIDType.UserLogID, "��ԭ���ݿ⣬��ԭ�ļ�·�����ļ���Ϊ��" + path);
        }

        #endregion

        #region [ �¼�: ����ر�Closing ]

        private void FrmDataManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lblInfo.Text.Length > 2 && lblInfo.Visible)
            {
                if (MessageBox.Show("��ȷ��Ҫ��ֹ[" + lblInfo.Text.Substring(0, 5) + "]����", "�ر���ʾ", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (lblInfo.Text.Substring(0, 5) == "���ݿⱸ��")
                    { 
                        
                    }
                    // δ�������رպ� δ����������ݿ�ɾ��
                    //if (txtPath.Tag.ToString().IndexOf(" ") > 1)
                    //{
                    //    //return;
                    //}c
                    //try
                    //{	        
                    //    //File.Delete(path);
                    //}
                    //catch (Exception ex)
                    //{                       
                    //    MessageBox.Show(ex.Message.ToString());
                    //    throw;
                    //}
                }
            }
        }

        #endregion

        // ɾ��δ������ɵ��ļ�
        private void RemoveFile()
        {
            bool bl = true;
            while (bl)
            {
                Thread.Sleep(10000);
                try
                {
                    File.Delete(path);
                    bl = false;
                }
                catch (Exception ex)
                {
                    bl = true;
                }
            }
        }

        #endregion

        private void rtxt_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + txtPath.Text.ToString() + "\\" + txtPath.Tag.ToString());
        }
    }
}