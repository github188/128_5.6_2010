using System.Threading;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using KJ128A.DataSave;
using System;
using System.Diagnostics;
using KJ128A.SwitchDatabase;
using System.Text;

namespace KJ128A.HostBack
{
    public class HostBacker
    {

        #region [ ���� ]
        SwitchDatabase.SwitchDatabase switchDatabase = new KJ128A.SwitchDatabase.SwitchDatabase();

        /// <summary>
        /// �������ݴ洢
        /// </summary>
        private readonly InterfaceHostBack interHostBack = new InterfaceHostBack();

        /// <summary>
        /// ��KJ128NBackUp���ݿ�
        /// </summary>
        private DataSaveBackUp wdSaveBack;
 
        /// <summary>
        /// ��KJ128N���ݿ�
        /// </summary>
        private DataSave dsBatman;

        public DataSave DsBatman
        {
            get { return dsBatman; }
        }

        private DataSend dsDataSend;

        /// <summary>
        /// True:����;False:����
        /// </summary>
        private bool isHost;


        /// <summary>
        /// �ϴ������л��Ƿ����
        /// </summary>
        private bool isBackData = true;

        /// <summary>
        /// �����л���־��True:�л�����;False:�л��ɱ�
        /// </summary>
        private bool isSwitchHost = true;

        private DataBaseSync dbs = new DataBaseSync();
        #endregion


        private DateTime temp_dt;

        /*
        * ί��
        */

        #region [ ί��: ������Ϣ�¼� ]

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="iErrNO">������</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        public delegate void ErrorMessageEventHandler(int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// ������Ϣ�¼�
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ ί�з��� ]
        /// <summary>
        /// ע�������Ϣ����
        /// </summary>
        /// <param name="iErrNO">������Ϣ���</param>
        /// <param name="strStackTrace">��ȡ��ǰ�쳣����ʱ���ö�ջ�ϵ�֡���ַ�����ʾ��ʽ</param>
        /// <param name="strSource">��ʶ��ǰ��һ�γ�����Ĵ���</param>
        /// <param name="strMessage">��ȡ������ǰ�쳣����Ϣ</param>
        void _ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        #region [ ���캯�� ]

        public HostBacker()
        {
            //���SQL Server�����ݿ��Ƿ����
            dbs.InitCheckDB();

          
            ////ע�����ί���¼�
            //dbs.ErrorMessage += _ErrorMessage;
            //dbs.SyncComplete += dbs_SyncComplete;

        }
        #endregion

        #region [ �ӿ�: ��ʼ���ȱ� ]

        /// <summary>
        /// ��ʼ���ȱ�
        /// </summary>
        /// <param name="isHost">�Ƿ�����</param>
        /// <param name="commType">ͨѶ���� true ����  false ����</param>
        /// <param name="strIP">�Է��� IP ��ַ</param>
        /// <param name="intListenPort">���������˿�</param>
        /// <param name="strPort">�ȱ���־λ</param>
        public bool InitHostBacker(bool isHost, bool commType, string strIP, int intListenPort, string strPort)
        {
            try
            {
                //Exit();

                this.isHost = isHost;

                if (isHost)//����
                {
                    ServerRB server = new ServerRB(strIP, intListenPort);
                    server.ErrorMessage += new ServerRB.ErrorMessageEventHandler(server_ErrorMessage);
                    server.Listen();
                }
                else//����
                {
                    ClientRB client = new ClientRB(strIP, intListenPort);
                    client.ErrorMessage += new ClientRB.ErrorMessageEventHandler(client_ErrorMessage);
                }

                //dsDataSend = new DataSend(isHost, strIP, intListenPort, intListenPort, strPort, this);
                //dsDataSend.ErrorMessage += _ErrorMessage;

                //dsDataSend.ThreadStart();
                //dsBatman.ThreadStart();

            }
            catch (System.Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6034001, ex.StackTrace, "[HostBacker:InitHostBacker]", ex.Message);
                }
                return false;
            }
            return true;
        }

        void client_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        void server_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        #region [ �ӿ�: �������ȱ����� ]

        /// <summary>
        /// �������ȱ�����
        /// </summary>
        /// <returns></returns>
        public bool InitHostBacker(bool commType)
        {
            try
            {
                this.isHost = true;
                //���SQL Server�����ݿ��Ƿ����
                //dbs.InitCheckDB();

                //dsBatman = new DataSave(true, commType);
                //dsBatman.ErrorMessage += _ErrorMessage;

                //dsBatman.ThreadStart();

            }
            catch (System.Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6034002, ex.StackTrace, "[HostBacker:InitHostBacker]", ex.Message);
                }
                return false;
            }
            return true;
        }
        #endregion

        #region [ �ӿ�: �����л� ]

        private void WriteSwitchDatabaseFile(string strState)
        {
            //����
            if (!File.Exists(Application.StartupPath + "\\SwitchDatabase.xml"))
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\SwitchDatabase.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                sw.WriteLine("<Database>0</Database>");
                sw.Flush();
                sw.Close();
                sw.Dispose();
                fs.Close();
                fs.Dispose();
            }
            XmlDocument xmldocument = new XmlDocument();
            //����
            xmldocument.Load(Application.StartupPath + "\\SwitchDatabase.xml");
            XmlNode node = xmldocument.SelectSingleNode("/Database");
            node.InnerText = strState;
            xmldocument.Save(Application.StartupPath + "\\SwitchDatabase.xml");
        }

        public bool SwitchHostBack(int isMark)
        {
            if (!isHost)
            {
                if (isMark==2)         //�յ����������Լ���
                {
                    isSwitchHost = false;

                    //dsDataSend.isSyncHost = true;
                    //dsBatman.isSyncHost = true;        //֪ͨDataSave�̣߳������л����ݿ�

                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Equals("KJ128NMainRun"))
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch { }
                            
                        }

                        //�����л�ʱ�رչҽӳ���
                        CloseFile();
                    }

                    //������
                    WriteSwitchDatabaseFile("-1");

                    //�л��ɱ����ݿ�
                    SwitchKJ128NBackUpData();

                    //File.AppendAllText("D:\\Test_HostBacker.txt", "SwitchHostBack() isMark��" + isMark + " �л��ɱ������ݿ� ��ӡʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n   ", Encoding.Default);
                    File.WriteAllText("D:\\Test_HostBacker.txt", "SwitchHostBack() isMark��" + isMark + " �л��ɱ������ݿ� ��ӡʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\r\n", Encoding.Default);
                    //����ӳ���
                    //OpenFile();
                    
                }
                else if (isMark == 1)                //�ȱ���,�յ������ݲ����Լ���
                {
                    if (!isSwitchHost)      //������л��ɱ����ݿ⣬���л��������ݿ�
                    {
                        foreach (Process process in Process.GetProcesses())
                        {
                            if (process.ProcessName.Equals("KJ128NMainRun"))
                            {
                                try
                                {
                                    process.Kill();
                                }
                                catch { }
                            }

                            //�����л�ʱ�رչҽӳ���
                            CloseFile();
                          
                        }
                        //������
                        WriteSwitchDatabaseFile("-1");

                        //�л��������ݿ�
                        SwitchKJ128NData();

                        //File.AppendAllText("D:\\Test_HostBacker.txt", "SwitchHostBack() isMark��" + isMark + " �л����������ݿ� ��ӡʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n", Encoding.Default);
                        File.WriteAllText("D:\\Test_HostBacker.txt", "SwitchHostBack() isMark��" + isMark + " �л����������ݿ� ��ӡʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\r\n", Encoding.Default);
                        //dsBatman.isSyncHost = false;     //֪ͨDataSave�̣߳�����ʹ�����ݿ�

                        isSwitchHost = true;

                    }
                }
            }
            return true;
        }

        #endregion

        #region ������ҳ���
        /// <summary>
        /// ����ӳ���
        /// </summary>
        private void OpenFile()
        {
            if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "OuterPath.xml"))
            {
                XmlDocument xmlDocument = new XmlDocument();
                try
                {
                    xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "OuterPath.xml");
                    XmlNodeList nodes = xmlDocument.SelectNodes("/Path/OuterConfig");
                    foreach (XmlNode node in nodes)
                    {
                        XmlNode nodeEnable = node.SelectSingleNode("isEnable");
                        XmlNode nodeOuterPath = node.SelectSingleNode("OuterPath");

                        if (nodeEnable.InnerText.Equals("1"))
                        {
                            try
                            {
                                if (File.Exists(nodeOuterPath.InnerText))
                                {
                                    Process configFile = new Process();
                                    configFile.StartInfo.FileName = nodeOuterPath.InnerText;
                                    configFile.Start();
                                }
                            }
                            catch { }
                        }
                    }
                }
                catch { }
            }
        }
        #endregion

       

        #region ���ر���ӳ���
        private bool CloseFile()
        {
            if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "OuterPath.xml"))
            {
                XmlDocument xmlDocument = new XmlDocument();
                try
                {
                    xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "OuterPath.xml");
                    XmlNodeList nodes = xmlDocument.SelectNodes("/Path/OuterConfig");
                    foreach (XmlNode node in nodes)
                    {
                        XmlNode nodeEnable = node.SelectSingleNode("isEnable");
                        XmlNode nodeOuterPath = node.SelectSingleNode("OuterPath");
                        if (nodeOuterPath.InnerText != "")
                        {
                            FileInfo file = new FileInfo(nodeOuterPath.InnerText.ToString());
                            foreach (Process process in Process.GetProcesses())
                            {
                                if (process.ProcessName.Equals(file.Name))
                                {
                                    try
                                    {
                                        process.Kill();
                                    }
                                    catch { }
                                }
                            }
                        }
                        //if (nodeEnable.InnerText.Equals("1"))
                        //{
                        //    try
                        //    {
                        //        if (File.Exists(nodeOuterPath.InnerText))
                        //        {
                        //            //if (nodeOuterPath.InnerText.Equals(strPath))//�����·���ʹ����·��һ�£�����TRUE�����˳�����
                        //            //{
                        //            //    return true;
                        //            //}
                        //            if (process.ProcessName.Equals("KJ128NMainRun"))
                        //            {
                        //                try
                        //                {
                        //                    process.Kill();
                        //                }
                        //                catch { }
                        //                break;
                        //            }
                        //        }
                        //    }
                        //    catch { }
                        //}
                    }
                }
                catch { }
            }
            return false;
        }
        #endregion  


        #region [ ����: �л��ɱ����ݿ� ]

        private bool SwitchKJ128NBackUpData()
        {
            if (!isHost)        //����
            {  
                isBackData = false;

                //DateTime orgLastFindDate = DateTime.Parse("2000-1-1 00:00:00");

                //while (interHostBack.IFExistDataInAllMDB_IsSync(orgLastFindDate))        //Access���ݿ��ԭʼ��OrgData���������Ƿ��Ѿ�ȫ������SQL Server���ݿ�
                //{
                //    Thread.Sleep(200);
                //}

                if (ErrorMessage != null)
                {
                    ErrorMessage(8034003, "", "[HostBacker:SwitchKJ128NBackUpData]", "��ʼ�л�ʹ�ñ������ݿ⣡");
                }

                Thread.Sleep(1000);

                //temp_dt = DateTime.Now;

                ////�л����ݿ�
                //dbs.DBSync();

                dbs_SyncComplete();
            }
            return true;
        }

        #endregion

        #region [ ����: �л��������ݿ� ]

        private bool SwitchKJ128NData()
        {
            //if (ErrorMessage != null)
            //{
            //    ErrorMessage(8034006, "", "[HostBacker:SwitchKJ128NData]", "��ʼ�л��������ݿ⣡");
            //}

            if (ErrorMessage != null)
            {
                ErrorMessage(8034005, "", "[HostBacker:SwitchKJ128NData]", "�л����������ݿ�ɹ�����ʼʹ���������ݿ⣡");
            }

            WriteSwitchDatabaseFile("1");

            if (File.Exists(Application.StartupPath + "\\KJ128NMainRun.exe"))
            {
                try
                {
                    string strPath = Application.StartupPath+"\\KJ128NMainRun.exe";
                    Process TongXun = new Process();
                    TongXun.StartInfo.FileName = strPath;
                    TongXun.Start();
                }
                catch { }
            }


            return true;
        }

        #endregion

        #region [ ����:  �˳� ]

        /// <summary>
        /// �˳�
        /// </summary>
        public bool Exit()
        {
            try
            {
                if (!isBackData)        //�ж���һ�����ݿ��л��Ƿ����
                {
                    //ֹͣ�ϴ��л����ݿ�
                    dbs.Close();
                }
                bool flgStopped = true;
                if (dsBatman != null)
                {
                    //while (flgStopped)
                    //{
                    //    dsBatman.IsStop = true;

                    //    flgStopped = dsBatman.IsStopped;

                    //    Thread.Sleep(100);
                    //}
                    ////������SQL Server���ݿ���߳�
                    //dsBatman.ExitSQLThread();
                }
                if (dsDataSend != null)
                {
                    flgStopped = true;
                    while (flgStopped)
                    {
                        dsDataSend.IsStop = true;

                        flgStopped = dsDataSend.IsStopped;

                        Thread.Sleep(100);
                    }
                    //�����������ݵ��߳�
                    dsDataSend.ExitSendThread();
                }
                if (wdSaveBack != null)
                {
                    flgStopped = true;
                    while (flgStopped)
                    {
                        wdSaveBack.IsStop = true;
                        flgStopped = wdSaveBack.IsStopped;
                        Thread.Sleep(100);
                    }
                    wdSaveBack.ExitSQLThread();
                   
                }
                if (dbs != null)
                {
                    if (!isBackData)
                    {
                        dbs.Close();
                    }
                    //���� SQLDMO����
                    dbs.Dispose();

                }

            }
            catch (System.Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6034003, ex.StackTrace, "[HostBacker:InitHostBacker]", ex.Message);
                }
                return false;
            }
            return true;
        }

        #endregion

        #region [ �¼�: ����л��ɱ����ݿ� ]

        /// <summary>
        /// ����л��ɱ����ݿ�
        /// </summary>
        void dbs_SyncComplete()
        {

            if (ErrorMessage != null)
            {
                ErrorMessage(8034002, "", "[HostBacker:dbs_SyncComplete]", "�л��ɱ������ݿ�ɹ�����ʼʹ�ñ������ݿ����У�");
            }

            //������
            WriteSwitchDatabaseFile("2");

            if (File.Exists(Application.StartupPath + "\\KJ128NMainRun.exe"))
            {
                try
                {
                    string strPath = Application.StartupPath+"\\KJ128NMainRun.exe";
                    Process TongXun = new Process();
                    TongXun.StartInfo.FileName = strPath;
                    TongXun.Start();
                }
                catch { }
            }

            //MessageBox.Show(Convert.ToString(DateTime.Now - temp_dt));

            isBackData = true;
        }

        #endregion
    }
}
