using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using KJ128A.BatmanAPI;
using KJ128A.Ports;
using KJ128A.Controls.Batman;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Xml;

namespace KJ128A.Batman
{
    /// <summary>
    /// ������˵�
    /// </summary>
    public class MenuHelper
    {
        #region [ API: ���±� ]

        /// <summary>
        /// ������Ϣ�����±�
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        /// <summary>
        /// ���Ҿ��
        /// </summary>
        /// <param name="hwndParent"></param>
        /// <param name="hwndChildAfter"></param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindow"></param>
        /// <returns></returns>
        [DllImport("User32.DLL")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        /// <summary>
        /// ���±���Ҫ�ĳ���
        /// </summary>
        public const uint WM_SETTEXT = 0x000C;

        #endregion

        #region [ ���� ]

        private readonly FrmMain frmMain = null;     // ������

        private ToolStripMenuItem menuItemShowMain = null;              // ��ʾ������
        private ToolStripMenuItem menuItemManageA = null;               // ����˵�
        private ToolStripMenuItem menuItemManageB = null;               // ����˵�
        private ToolStripMenuItem menuItemConfig = null;                // ���ò˵�
        private ToolStripMenuItem menuItemFunction = null;              // ���ܲ˵�
        private ToolStripMenuItem menuItemHelp = null;                  // �����˵�
        private readonly ToolStripSeparator menuItemSeparator4 = new ToolStripSeparator();       // ����


        #region��Czlt-2011-08-10 ���ô����վ,������վ,��ʶ���š�
        /// <summary>
        /// �����еı�ʶ������
        /// </summary>
        private int[] _Cards;
        /// <summary>
        /// ˫��ͨѶ�㲥��վ����
        /// </summary>
        private int[] _Order;

        /// <summary>
        /// Czlt-2011-08-10 ��ʶ����
        /// </summary>
        private string strCodeNum = string.Empty;

        /// <summary>
        /// Czlt-2011-08-10 ˫ͨ����ı�ʶ����
        /// </summary>
        public string StrCodeNum
        {
            get { return strCodeNum; }
            set { strCodeNum = value; }
        }
        /// <summary>
        /// Czlt-2011-08-10 �����վ��
        /// </summary>
        private string strStaNum = string.Empty;
        /// <summary>
        /// Czlt-2011-08-10 ������վ��
        /// </summary>
        private string strStaHeadNum = string.Empty;

        /// <summary>
        /// Czlt-2011-08-10 ˫��ͨѶ������
        /// </summary>
        //private System.Timers.Timer callTime = new System.Timers.Timer();
        /// <summary>
        /// Czlt-2011-08-10 ˫ͨ����
        /// </summary>
        private int czltIndex = 0;

        /// <summary>
        /// Czlt-2011-08-10 �ܵ�Ѳ�����
        /// </summary>
        private int czltSum = 180;
        private int czltStopTime = 1;
        //��ʶ���ļ���
        private Dictionary<int, string> czltCards = new Dictionary<int, string>();
        KJ128A.Controls.GetCardInfo czltGetCard = new KJ128A.Controls.GetCardInfo();
        private Dictionary<int, int> czltGroup = new Dictionary<int, int>();
        private string strCodeName = string.Empty;

        /// <summary>
        /// ȫ�󾮺���
        /// </summary>
        // private System.Timers.Timer callAllTime = new System.Timers.Timer();
        //ȫ�󾮺���
        private bool isCallAll = false;
        /// <summary>
        /// Czlt-2011-10-08 �Ƿ�Ϊȫ�����
        /// </summary>
        public bool IsCallAll
        {
            get { return isCallAll; }
            set { isCallAll = value; }
        }

        //Czlt-2011-08-17 ����·��
        //private string strErrPath = Application.StartupPath + "\\CzltTest";

        private string strMessage = "";
        /// <summary>
        /// ������ʾ��Ϣ
        /// </summary>
        public string StrMessage
        {
            get { return strMessage; }
            set { strMessage = value; }
        }

        #endregion

        #endregion

        #region [ ���캯�� ]

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public MenuHelper()
        {

            //Czlt-2011-08-10 ˫��ͨѶ
            //callTime.Interval = 10000;
            //callTime.Elapsed += new System.Timers.ElapsedEventHandler(callTime_Elapsed);
            //callTime.Enabled = false;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="ctl"></param>
        public MenuHelper(FrmMain frm, Control ctl)
        {
            frmMain = frm;

            BuildMainMenu(ctl);


        }

        #endregion

        /*
         * �����˵�
        */

        #region [ ����: �������˵� ]

        /// <summary>
        /// �������˵�
        /// </summary>
        public void BuildMainMenu(Control ctl)
        {
            #region [ �˵�: ��ʾ/���� ]

            // �������˵��������� ��ʾ/����
            if (ctl.GetType() == typeof(ContextMenuStrip))
            {
                menuItemShowMain = new ToolStripMenuItem("����/��ʾ(&S)");
                menuItemShowMain.Click += delegate
                {
                    if (frmMain.WindowState != FormWindowState.Minimized)
                    {
                        frmMain.WindowState = FormWindowState.Minimized;
                        frmMain.Visible = false;
                    }
                    else
                    {
                        frmMain.WindowState = FormWindowState.Maximized;
                        frmMain.Visible = true;
                        frmMain.Activate();
                    }
                };
                ((ContextMenuStrip)(ctl)).Items.Add(menuItemShowMain);

                // �ָ���
                ToolStripSeparator menuItemSeparator3 = new ToolStripSeparator();
                if (ctl.GetType() == typeof(MenuStrip))
                {
                    ((MenuStrip)(ctl)).Items.Add(menuItemSeparator3);
                }
                else
                {
                    ((ContextMenuStrip)(ctl)).Items.Add(menuItemSeparator3);
                }
            }

            #endregion

            // ����˵�
            menuItemManageA = new ToolStripMenuItem("����(&M)");
            menuItemManageB = new ToolStripMenuItem("����(&M)");

            if (ctl.GetType() == typeof(MenuStrip))
            {
                ((MenuStrip)(ctl)).Items.Add(menuItemManageA);
            }
            else
            {
                ((ContextMenuStrip)(ctl)).Items.Add(menuItemManageB);
            }

            BuildManageMenuA();
            BuildManageMenuB();

            // ���ò˵�
            menuItemConfig = new ToolStripMenuItem("����(&C)");
            if (ctl.GetType() == typeof(MenuStrip))
            {
                ((MenuStrip)(ctl)).Items.Add(menuItemConfig);
            }
            else
            {
                ((ContextMenuStrip)(ctl)).Items.Add(menuItemConfig);
            }

            BuildConfigMenu();

            // ���ܲ˵�
            menuItemFunction = new ToolStripMenuItem("����(&G)");
            if (ctl.GetType() == typeof(MenuStrip))
            {
                ((MenuStrip)(ctl)).Items.Add(menuItemFunction);
            }
            else
            {
                ((ContextMenuStrip)(ctl)).Items.Add(menuItemFunction);
            }

            BuildFunctionMenu();

            // �����˵�
            menuItemHelp = new ToolStripMenuItem("����(&H)");
            if (ctl.GetType() == typeof(MenuStrip))
            {
                ((MenuStrip)(ctl)).Items.Add(menuItemHelp);
            }
            else
            {
                ((ContextMenuStrip)(ctl)).Items.Add(menuItemHelp);
            }

            BuildHelpMenu();


            #region [ ������: ע���˵� ]

            if (ctl.GetType() == typeof(ContextMenuStrip))
            {
                // �ָ���
                if (ctl.GetType() == typeof(MenuStrip))
                {
                    ((MenuStrip)(ctl)).Items.Add(menuItemSeparator4);
                }
                else
                {
                    ((ContextMenuStrip)(ctl)).Items.Add(menuItemSeparator4);
                }


                //menuItemLoginB.Click += delegate
                //{
                //    if (menuItemLoginB.Text == "ע��(&L)")
                //    {
                //        MainHelper.MenuPowerChange(EnumPowers.Default);
                //    }
                //    else
                //    {
                //        FrmLogin frmLogin = new FrmLogin(frmMain, "Login.xml");
                //        frmLogin.ErrorMessage += frmLogin_ErrorMessage;
                //        frmLogin.ShowDialog();
                //        frmLogin.Dispose();
                //    }
                //};
                //((ContextMenuStrip)(ctl)).Items.Add(menuItemLoginB);
            }

            #endregion

        }

        private void frmLogin_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            frmMain.ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
        }

        #endregion

        #region [ ����: ����˵� A ]

        ToolStripMenuItem menuItemPwdChangeA = null;         // �����޸Ĳ˵�
        ToolStripMenuItem menuItemLoginA = null;             // �û���¼�˵�
        ToolStripSeparator menuItemSeparator1A = null;       // �ָ��� 1
        //ToolStripMenuItem menuItemPluginA = null;            // �������˵�
        //ToolStripSeparator menuItemSeparator2A = null;       // �ָ��� 2
        ToolStripMenuItem menuItemExitA = null;              // �˳��˵�

        /// <summary>
        /// ��������˵�
        /// </summary>
        private void BuildManageMenuA()
        {
            // �����޸Ĳ˵�
            menuItemPwdChangeA = new ToolStripMenuItem("�����޸�(&P");
            menuItemPwdChangeA.Click += delegate
            {
                FrmChangePwd frmPwdChange = new FrmChangePwd(frmMain, "Login.xml");
                frmPwdChange.ErrorMessage += frmPwdChange_ErrorMessage;
                frmPwdChange.ShowDialog();
                frmPwdChange.Dispose();
            };
            menuItemManageA.DropDownItems.Add(menuItemPwdChangeA);

            // �û���¼�˵�
            menuItemLoginA = new ToolStripMenuItem("��¼(&L)");             // ��¼�˵�
            menuItemLoginA.Click += delegate
            {
                if (menuItemLoginA.Text == "ע��(&L)")
                {
                    //Czlt-2010-09-25
                    DialogResult result;
                    result = MessageBox.Show("�Ƿ�Ҫע��ϵͳ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MainHelper.MenuPowerChange(EnumPowers.Default);
                    }
                    //MainHelper.MenuPowerChange(EnumPowers.Default);
                }
                else
                {
                    FrmLogin frmLogin = new FrmLogin(frmMain, "Login.xml");
                    frmLogin.ErrorMessage += frmLogin_ErrorMessage;
                    frmLogin.ShowDialog();
                    frmLogin.Dispose();
                }
            };
            menuItemManageA.DropDownItems.Add(menuItemLoginA);


            // �ָ���
            menuItemSeparator1A = new ToolStripSeparator();                // �ָ��� 1
            menuItemManageA.DropDownItems.Add(menuItemSeparator1A);

            //// �������˵�
            //menuItemPluginA = new ToolStripMenuItem("�������(&M)");        // ����˵�
            //menuItemManageA.DropDownItems.Add(menuItemPluginA);

            //// �ָ���
            //menuItemSeparator2A = new ToolStripSeparator();                // �ָ��� 2
            //menuItemManageA.DropDownItems.Add(menuItemSeparator2A);

            // �˳��˵�
            menuItemExitA = new ToolStripMenuItem("�˳�(&X)");              // �˳��˵�
            menuItemExitA.Click += delegate
            {
                //Czlt-2010-09-25
                DialogResult result;
                result = MessageBox.Show("�Ƿ�Ҫ�˳�ϵͳ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    frmMain.Exit();
                }
                //   frmMain.Exit(); 
            };
            menuItemManageA.DropDownItems.Add(menuItemExitA);
        }

        private void frmPwdChange_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            frmMain.ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
        }

        #endregion

        #region [ ����: ����˵� B ]

        ToolStripMenuItem menuItemPwdChangeB = null;         // �����޸Ĳ˵�
        //ToolStripMenuItem menuItemLoginB = new ToolStripMenuItem("��¼(&L)");             // �û���¼�˵�
        ToolStripMenuItem menuItemLoginB = null;
        ToolStripSeparator menuItemSeparator1B = null;       // �ָ��� 1
        ToolStripMenuItem menuItemPluginB = null;            // �������˵�
        ToolStripSeparator menuItemSeparator2B = null;       // �ָ��� 2
        ToolStripMenuItem menuItemExitB = null;              // �˳��˵�

        /// <summary>
        /// ��������˵�
        /// </summary>
        private void BuildManageMenuB()
        {
            // �����޸Ĳ˵�
            menuItemPwdChangeB = new ToolStripMenuItem("�����޸�(&P");
            menuItemPwdChangeB.Click += delegate
            {
                FrmChangePwd frmPwdChange = new FrmChangePwd(frmMain, "Login.xml");
                frmPwdChange.ShowDialog();
                frmPwdChange.Dispose();
            };
            menuItemManageB.DropDownItems.Add(menuItemPwdChangeB);

            // �û���¼�˵�
            menuItemLoginB = new ToolStripMenuItem("��¼(&L)");             // ��¼�˵�
            menuItemLoginB.Click += delegate
            {
                if (menuItemLoginB.Text == "ע��(&L)")
                {
                    MainHelper.MenuPowerChange(EnumPowers.Default);
                }
                else
                {
                    FrmLogin frmLogin = new FrmLogin(frmMain, "Login.xml");
                    frmLogin.ErrorMessage += frmLogin_ErrorMessage;
                    frmLogin.ShowDialog();
                    frmLogin.Dispose();
                }
            };
            menuItemManageB.DropDownItems.Add(menuItemLoginB);

            // �ָ���
            menuItemSeparator1B = new ToolStripSeparator();               // �ָ��� 1
            menuItemManageB.DropDownItems.Add(menuItemSeparator1B);

            //// �������˵�
            //menuItemPluginB = new ToolStripMenuItem("�������(&M)");        // ����˵�
            //menuItemManageB.DropDownItems.Add(menuItemPluginB);

            //// �ָ���
            //menuItemSeparator2B = new ToolStripSeparator();                // �ָ��� 2
            //menuItemManageB.DropDownItems.Add(menuItemSeparator2B);

            // �˳��˵�
            menuItemExitB = new ToolStripMenuItem("�˳�(&X)");              // �˳��˵�
            menuItemExitB.Click += delegate {
                if (MessageBox.Show("�ر�ͨѶ�������������һ��Ӱ�죬ȷ��Ҫ�ر�ͨѶ������", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    CzltSaveChkXml2(true);
                    frmMain.Exit();
                }
            };
            menuItemManageB.DropDownItems.Add(menuItemExitB);
        }

        #endregion

        #region [ ����: ���ò˵� ]

        /// <summary>
        /// �������ò˵�
        /// </summary>
        private void BuildConfigMenu()
        {
            //// ��������
            //ToolStripMenuItem menuParams = new ToolStripMenuItem("��������(&P)");
            //menuParams.Click += delegate
            //{
            //    FrmParams frmParams = new FrmParams("Params.xml");
            //    frmParams.ShowDialog();
            //    frmParams.Dispose();
            //};
            //menuItemConfig.DropDownItems.Add(menuParams);

            //// �ָ���
            //menuItemConfig.DropDownItems.Add("-");

            // ��������
            ToolStripMenuItem menuCommConfig = new ToolStripMenuItem("ͨѶ����(&C)");
            menuCommConfig.Click += delegate
            {
                StartPort.ShowCommSetDialog("SerialPort.xml", frmMain);
            };
            menuItemConfig.DropDownItems.Add(menuCommConfig);

            //// ���ݿ�����
            //ToolStripMenuItem menuDBConfig = new ToolStripMenuItem("���ݿ�(&D)");
            //menuItemConfig.DropDownItems.Add(menuDBConfig);

            //// �����ݿ�
            //ToolStripMenuItem menuDBConfigMain = new ToolStripMenuItem("�����ݿ�(&M)");
            //menuDBConfigMain.Click += delegate
            //{
            //    FrmDBSet frmDBSet = new FrmDBSet(frmMain, 1, "DbConfig.xml");
            //    frmDBSet.ErrorMessage += frmDBSet_ErrorMessage;
            //    frmDBSet.ShowDialog();
            //    frmDBSet.Dispose();
            //};
            //menuDBConfig.DropDownItems.Add(menuDBConfigMain);

            //// �����ݿ�
            //ToolStripMenuItem menuDBConfigBackup = new ToolStripMenuItem("�����ݿ�(&B)");
            //menuDBConfigBackup.Click += delegate
            //{
            //    FrmDBSet frmDBSet = new FrmDBSet(frmMain, 2, "DbConfig.xml");
            //    frmDBSet.ErrorMessage += frmDBSet_ErrorMessage;
            //    frmDBSet.ShowDialog();
            //    frmDBSet.Dispose();
            //};
            //menuDBConfig.DropDownItems.Add(menuDBConfigBackup);

            // �ȱ����� --Ԭ���޸� 2008-03-04
            ToolStripMenuItem menuHostConfig = new ToolStripMenuItem("�ȱ�����(&R)");
            menuHostConfig.Click += delegate
           {
               FrmHostIpSet frmHost = new FrmHostIpSet("HostIPConfig.xml");
               frmHost.ErrorMessage += frmDBSet_ErrorMessage;
               frmHost.ListenHostSet += new FrmHostIpSet.ListenHostSetEventHandler(frmHost_ListenHostSet);
               frmHost.ShowDialog();
               frmHost.Dispose();
           };
            //menuItemConfig.DropDownItems.Add(menuHostConfig);
        }

        void frmHost_ListenHostSet(bool bIsStartHost, bool IsHost, string strIpAddress, string strPort)
        {
            frmMain.ReadHostSet();
        }

        private void frmDBSet_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            frmMain.ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
        }

        #endregion

        #region [ ����: ���ܲ˵� ]

        private ToolStripMenuItem menuItemPause = null;         // ��ͣ�˵�
        private ToolStripMenuItem menuItemDataCopy = null;      // ���ݸ��Ʋ˵�
        private ToolStripMenuItem menuItemTwo = null;

        /// <summary>
        /// �������ܲ˵�
        /// </summary>
        private void BuildFunctionMenu()
        {
            // ��ͣ�˵�
            menuItemPause = new ToolStripMenuItem("��ͣ(&P)");
            menuItemFunction.DropDownItems.Add(menuItemPause);

            // ���ݸ��Ʋ˵�
            menuItemDataCopy = new ToolStripMenuItem("���ݸ���(&C)");
            menuItemFunction.DropDownItems.Add(menuItemDataCopy);

            //Czlt-2010-11-29-˫��ͨѶ
            menuItemTwo = new ToolStripMenuItem("˫��ͨѶ(&T)");
            menuItemTwo.Click += delegate
            {
                //FrmTwo frmTwo = new FrmTwo();
                //frmTwo.ShowDialog();

                A_FrmTwo a_frmTwo = new A_FrmTwo();

                //a_frmTwo.Codes = czltCards.Count.ToString();
                //a_frmTwo.StrCodeAndName = strCodeName;
                //if (a_frmTwo.ShowDialog() == DialogResult.OK)
                //{


                //    callTime.Interval = 10000;
                //    if (a_frmTwo.IsCallAll)
                //    {
                //        czltIndex = 0;
                //        isCallAll = true;
                //        callTime.Enabled = true;
                //        callTime.Interval = 60000;
                //    }
                //    else
                //    {
                //        czltIndex = 0;
                //        strCodeNum = a_frmTwo.CodeNum;
                //        strStaNum = a_frmTwo.StationNum;
                //        strStaHeadNum = a_frmTwo.StaHeadNum;
                //        strCodeName = a_frmTwo.StrCodeAndName;
                //        if (callTime.Enabled == false)
                //        {
                //            callTime.Enabled = true;
                //        }
                //    }

                //}
                //if (a_frmTwo.IsClose)
                //{
                //    a_frmTwo.IsCallAll = false;
                //    isCallAll = false;
                //    callTime.Interval = 10000;
                //    callTime.Enabled = false;
                //    czltIndex = 0;
                //    czltStopTime = 0;
                //    czltCards.Clear();
                //    strCodeName = "";
                //    strCodeNum = "";
                //    //this.rchTxtChinese.WriteTxt("������ֹͣ��\n", " ", true, System.Drawing.Color.Blue);


                //}



                if (!File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "Calling.xml"))
                {
                    //����
                    FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "Calling.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<Call>");
                    sw.WriteLine("<isCall>false</isCall>");
                    sw.WriteLine("<commType>false</commType>");
                    sw.WriteLine("<CallAll>false</CallAll>");
                    sw.WriteLine("<strCodeNum></strCodeNum>");
                    sw.WriteLine("<strStaNum></strStaNum>");
                    sw.WriteLine("<strStaHeadNum></strStaHeadNum>");
                    sw.WriteLine("<strCodeName></strCodeName>");
                    sw.WriteLine("</Call>");
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }

                XmlDocument czltXmlDocument = new XmlDocument();
                czltXmlDocument.Load(Application.StartupPath + "\\Calling.xml");
                a_frmTwo.StrCodeAndName = czltXmlDocument.SelectSingleNode("/Call/strCodeName").InnerText.ToString();
                a_frmTwo.StrCodes = czltXmlDocument.SelectSingleNode("/Call/strCodeNum").InnerText.ToString();
                if (a_frmTwo.ShowDialog() == DialogResult.OK)
                {

                 

                    //XmlDocument xmldocument = new XmlDocument();
                    ////����
                    //xmldocument.Load(Application.StartupPath + "\\SwitchDatabase.xml");
                    //XmlNode node = xmldocument.SelectSingleNode("/Database");
                    //node.InnerText = strState;
                    //xmldocument.Save(Application.StartupPath + "\\SwitchDatabase.xml");

                    //����˫ͨ
                    XmlNode nodeIsCall = czltXmlDocument.SelectSingleNode("/Call/isCall");
                    nodeIsCall.InnerText = "true";
                    if (a_frmTwo.IsCallAll)
                    {
                        XmlNode nodeCallAll = czltXmlDocument.SelectSingleNode("/Call/CallAll");
                        nodeCallAll.InnerText = "true";
                     
                    }
                    else
                    {
                        XmlNode nodeCallAll = czltXmlDocument.SelectSingleNode("/Call/CallAll");
                        nodeCallAll.InnerText = "false";

                        //�����еı�ʶ����
                        XmlNode nodeCode = czltXmlDocument.SelectSingleNode("/Call/strCodeNum");
                        nodeCode.InnerText = a_frmTwo.CodeNum;

                        //�����еĴ����վ��
                        XmlNode nodeSta = czltXmlDocument.SelectSingleNode("/Call/strStaNum");
                        nodeSta.InnerText = a_frmTwo.StationNum;

                        //�����еĶ�����վ��
                        XmlNode nodeSHead = czltXmlDocument.SelectSingleNode("/Call/strStaHeadNum");
                        nodeSHead.InnerText = a_frmTwo.StaHeadNum;

                        //�����еĿ��ź���Ա
                        XmlNode nodeCodeName = czltXmlDocument.SelectSingleNode("/Call/strCodeName");
                        nodeCodeName.InnerText = a_frmTwo.StrCodeAndName;                      
                      
                    }

                    if (frmMain.commType)//����ͨѶ
                    {
                        //���� true
                        XmlNode nodeType = czltXmlDocument.SelectSingleNode("/Call/commType");
                        nodeType.InnerText = "true";
                    }
                    else//����ͨѶ
                    {
                      //���� false
                        XmlNode nodeType = czltXmlDocument.SelectSingleNode("/Call/commType");
                        nodeType.InnerText = "true";
                    }
                }

                //Czlt-2011-10-08 ȡ������ͨѶ
                if (a_frmTwo.IsClose)
                {
                    //����˫ͨ
                    XmlNode node = czltXmlDocument.SelectSingleNode("/Call/isCall");
                    node.InnerText = "false";

                    //ȡ��ȫ�����
                    XmlNode nodeCallAll = czltXmlDocument.SelectSingleNode("/Call/CallAll");
                    nodeCallAll.InnerText = "false";

                    //�����еı�ʶ����
                    XmlNode nodeCode = czltXmlDocument.SelectSingleNode("/Call/strCodeNum");
                    nodeCode.InnerText = "";

                    //�����еĴ����վ��
                    XmlNode nodeSta = czltXmlDocument.SelectSingleNode("/Call/strStaNum");
                    nodeSta.InnerText = a_frmTwo.StationNum;

                    //�����еĶ�����վ��
                    XmlNode nodeSHead = czltXmlDocument.SelectSingleNode("/Call/strStaHeadNum");
                    nodeSHead.InnerText = a_frmTwo.StaHeadNum;

                    //�����еĶ�����վ��
                    XmlNode nodeCodeName = czltXmlDocument.SelectSingleNode("/Call/strCodeName");
                    nodeCodeName.InnerText = "";     
                }

                czltXmlDocument.Save(Application.StartupPath + "\\Calling.xml");

                //if (a_frmTwo.ShowDialog() == DialogResult.OK)
                //{

                //    if (frmMain.commType)//����ͨѶ
                //    {
                //        StartTcp.m_TcpClientPort.IsTwoMessage = true;
                //        StartTcp.m_TcpClientPort.CardToCall = a_frmTwo.GetCards();
                //        StartTcp.m_TcpClientPort.CallOrder = a_frmTwo.GetOrder();

                //    }
                //    else//����ͨѶ
                //    {
                //        for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                //        {
                //            StartPort.s_serialPort[i].IsTwoMessage = true;
                //            StartPort.s_serialPort[i].CardToCall = a_frmTwo.GetCards();
                //            StartPort.s_serialPort[i].CallOrder = a_frmTwo.GetOrder();
                //        }
                //    }
                //}
            };
            //����˫ͨ����
            menuItemTwo.Visible = true;
            menuItemFunction.DropDownItems.Add(menuItemTwo);

        }

        /// <summary>
        /// ͬ�����ܲ˵�
        /// </summary>
        public void MenuSyncFunction(KJRichTextBox _RtxtSysMsg)
        {
            if (frmMain.commType)
            {
                if (StartTcp.m_TcpClientPort != null)
                {
                    ToolStripMenuItem menuItemSerialPortPause = new ToolStripMenuItem("����������ͣ");

                    menuItemSerialPortPause.Click += delegate(object sender, EventArgs e)
                    {
                        if (StartTcp.m_TcpClientPort.IsPause)
                        {
                            ((ToolStripMenuItem)(sender)).Text = "����������ͣ";
                        }
                        else
                        {
                            ((ToolStripMenuItem)(sender)).Text = "������������";
                        }

                        StartTcp.m_TcpClientPort.IsPause = !StartTcp.m_TcpClientPort.IsPause;
                        if (StartTcp.m_TcpClientPort.IsPause == false)
                        {
                            StartTcp.m_TcpClientPort.SendCmd();
                        }
                    };
                    menuItemPause.DropDownItems.Add(menuItemSerialPortPause);
                }
            }
            else
            {
                // ��ͣ�Ӳ˵�
                if (StartPort.s_serialPort != null)
                {
                    ToolStripMenuItem[] menuItemSerialPortPause = new ToolStripMenuItem[StartPort.s_serialPort.Length];
                    for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                    {
                        menuItemSerialPortPause[i] = new ToolStripMenuItem(StartPort.s_serialPort[i].PortName + " ������ͣ");
                        menuItemSerialPortPause[i].Tag = i;
                        menuItemSerialPortPause[i].Click += delegate(object sender, EventArgs e)
                        {
                            if (StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].IsPause)
                            {
                                ((ToolStripMenuItem)(sender)).Text = StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].PortName + " ������ͣ";
                            }
                            else
                            {
                                ((ToolStripMenuItem)(sender)).Text = StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].PortName + " ��������";
                            }

                            StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].IsPause = !StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].IsPause;
                            if (StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].IsPause == false)
                            {
                                StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].SendCmd();
                            }
                        };
                        menuItemPause.DropDownItems.Add(menuItemSerialPortPause[i]);
                    }
                }
            }

            // ����Ӧ�ó���
            menuItemDataCopy.Click += delegate
            {

                string strTran = string.Empty;  // ��Ҫ���͵�����
                bool blnNotepad = false;         // ���±��ɹ�����

                #region [ �������±� ]

                System.Diagnostics.Process Proc;

                try
                {
                    // �������±�
                    Proc = new System.Diagnostics.Process();
                    Proc.StartInfo.FileName = "notepad.exe";
                    Proc.StartInfo.UseShellExecute = false;
                    Proc.StartInfo.RedirectStandardInput = true;
                    Proc.StartInfo.RedirectStandardOutput = true;

                    Proc.Start();

                    blnNotepad = true;
                }
                catch
                {
                    Proc = null;
                }

                #endregion

                #region [ ϵͳ��Ϣ��� ]

                if (_RtxtSysMsg != null)
                {
                    // ������±������ɹ�����ϵͳ��Ϣ����е������ύ�����±��������͵��ڴ��С�
                    if (blnNotepad)
                    {
                        strTran = _RtxtSysMsg.Text.Replace("\n", "\r\n");
                    }
                    else
                    {
                        _RtxtSysMsg.SelectAll();
                        _RtxtSysMsg.Copy();
                    }
                }

                #endregion

                #region [ ������� ]
                if (frmMain.commType)
                {
                    // ������±������ɹ�������������е������ύ�����±��������͵��ڴ��С�
                    if (StartTcp.m_TcpClientPort.RTxtMsg != null)
                    {
                        if (StartTcp.m_TcpClientPort.RTxtMsg.Focused)
                        {
                            if (blnNotepad)
                            {
                                strTran = StartTcp.m_TcpClientPort.RTxtMsg.Text.Replace("\n", "\r\n");
                            }
                            else
                            {
                                StartTcp.m_TcpClientPort.RTxtMsg.SelectAll();
                                StartTcp.m_TcpClientPort.RTxtMsg.Copy();
                            }

                        }
                    }

                    if (StartTcp.m_TcpClientPort.RTxtMsgc != null)
                    {
                        if (StartTcp.m_TcpClientPort.RTxtMsgc.Focused)
                        {
                            if (blnNotepad)
                            {
                                strTran = StartTcp.m_TcpClientPort.RTxtMsgc.Text.Replace("\n", "\r\n");
                            }
                            else
                            {
                                StartTcp.m_TcpClientPort.RTxtMsgc.SelectAll();
                                StartTcp.m_TcpClientPort.RTxtMsgc.Copy();
                            }

                        }
                    }

                    if (StartTcp.m_TcpClientPort.RTxtMsge != null)
                    {
                        if (StartTcp.m_TcpClientPort.RTxtMsge.Focused)
                        {
                            if (blnNotepad)
                            {
                                strTran = StartTcp.m_TcpClientPort.RTxtMsge.Text.Replace("\n", "\r\n");
                            }
                            else
                            {
                                StartTcp.m_TcpClientPort.RTxtMsge.SelectAll();
                                StartTcp.m_TcpClientPort.RTxtMsge.Copy();
                            }

                        }
                    }

                    if (StartTcp.m_TcpClientPort.RTxtMsgo != null)
                    {
                        if (StartTcp.m_TcpClientPort.RTxtMsgo.Focused)
                        {
                            if (blnNotepad)
                            {
                                strTran = StartTcp.m_TcpClientPort.RTxtMsgo.Text.Replace("\n", "\r\n");
                            }
                            else
                            {
                                StartTcp.m_TcpClientPort.RTxtMsgo.SelectAll();
                                StartTcp.m_TcpClientPort.RTxtMsgo.Copy();
                            }

                        }
                    }
                }
                else
                {
                    // ������±������ɹ�������������е������ύ�����±��������͵��ڴ��С�
                    for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                    {
                        if (StartPort.s_serialPort[i].RTxtMsg != null)
                        {
                            if (StartPort.s_serialPort[i].RTxtMsg.Focused)
                            {
                                if (blnNotepad)
                                {
                                    strTran = StartPort.s_serialPort[i].RTxtMsg.Text.Replace("\n", "\r\n");
                                }
                                else
                                {
                                    StartPort.s_serialPort[i].RTxtMsg.SelectAll();
                                    StartPort.s_serialPort[i].RTxtMsg.Copy();
                                }
                                break;
                            }
                        }

                        if (StartPort.s_serialPort[i].RTxtMsgc != null)
                        {
                            if (StartPort.s_serialPort[i].RTxtMsgc.Focused)
                            {
                                if (blnNotepad)
                                {
                                    strTran = StartPort.s_serialPort[i].RTxtMsgc.Text.Replace("\n", "\r\n");
                                }
                                else
                                {
                                    StartPort.s_serialPort[i].RTxtMsgc.SelectAll();
                                    StartPort.s_serialPort[i].RTxtMsgc.Copy();
                                }
                                break;
                            }
                        }

                        if (StartPort.s_serialPort[i].RTxtMsge != null)
                        {
                            if (StartPort.s_serialPort[i].RTxtMsge.Focused)
                            {
                                if (blnNotepad)
                                {
                                    strTran = StartPort.s_serialPort[i].RTxtMsge.Text.Replace("\n", "\r\n");
                                }
                                else
                                {
                                    StartPort.s_serialPort[i].RTxtMsge.SelectAll();
                                    StartPort.s_serialPort[i].RTxtMsge.Copy();
                                }
                                break;
                            }
                        }

                        if (StartPort.s_serialPort[i].RTxtMsgo != null)
                        {
                            if (StartPort.s_serialPort[i].RTxtMsgo.Focused)
                            {
                                if (blnNotepad)
                                {
                                    strTran = StartPort.s_serialPort[i].RTxtMsgo.Text.Replace("\n", "\r\n");
                                }
                                else
                                {
                                    StartPort.s_serialPort[i].RTxtMsgo.SelectAll();
                                    StartPort.s_serialPort[i].RTxtMsgo.Copy();
                                }
                                break;
                            }
                        }
                    }
                }
                #endregion

                #region [ �������ݸ����±� ]

                if (blnNotepad && Proc != null)
                {
                    // ���� API, ��������
                    while (Proc.MainWindowHandle == IntPtr.Zero)
                    {
                        Proc.Refresh();
                    }

                    IntPtr vHandle = FindWindowEx(Proc.MainWindowHandle, IntPtr.Zero, "Edit", null);

                    // �������ݸ����±�
                    SendMessage(vHandle, WM_SETTEXT, 0, strTran);
                }

                #endregion

            };
        }

        #endregion


        #region ��Czlt-2011-12-26 ���ǲ��������رճ����״̬���޸ġ�
        /// <summary>
        /// Czlt-2011-12-26 ���ǲ��������رճ����״̬���޸�
        /// </summary>
        private void CzltSaveChkXml(bool isChk)
        {

            if (File.Exists(Application.StartupPath + "\\ChkType.Xml"))
            {

                XmlDocument dom = new XmlDocument();
                dom.Load(Application.StartupPath + @"\" + "ChkType.Xml");
                XmlNode xnSignalType = dom.SelectSingleNode("//TypeSignal//IsType");
                xnSignalType.InnerText = isChk.ToString();

                if (isChk == false)
                {
                    XmlNode xnSignalTime = dom.SelectSingleNode("//TypeSignal//CloseTime");
                    xnSignalTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    XmlNode xnSignalSumNum = dom.SelectSingleNode("//TypeSignal//SumNum");
                    xnSignalSumNum.InnerText = (Convert.ToInt64(xnSignalSumNum.InnerText) + 1).ToString();
                }
                
                dom.Save(Application.StartupPath.ToString() + "\\ChkType.xml");
            }


        }
        #endregion

        #region [ ����: ���ò˵� ]

        /// <summary>
        /// �������ò˵�
        /// </summary>
        private void BuildHelpMenu()
        {
            // ��������
            ToolStripMenuItem menuAbout = new ToolStripMenuItem("����(&A)");
            menuAbout.Click += delegate
            {
                FrmABout frmABout = new FrmABout();
                frmABout.ShowDialog();
                frmABout.Dispose();
            };
            menuItemHelp.DropDownItems.Add(menuAbout);

        }

        #endregion

        /*
         * �˵�Ȩ��
         */

        #region [ ����: �˵�Ȩ�� ]

        /// <summary>
        /// �˵�Ȩ��
        /// </summary>
        /// <param name="enumPower"></param>
        public void MenuPowerChange(EnumPowers enumPower)
        {
            switch (enumPower)
            {
                case EnumPowers.Administrator:
                    menuItemFunction.Visible = true;
                    menuItemConfig.Visible = true;

                    //menuItemPluginA.Visible = true;       
                    menuItemExitA.Visible = true;
                    menuItemPwdChangeA.Visible = true;
                    menuItemSeparator1A.Visible = true;
                    //menuItemSeparator2A.Visible = true;
                    menuItemLoginA.Text = "ע��(&L)";

                    //menuItemPluginB.Visible = true;
                    menuItemExitB.Visible = true;
                    menuItemPwdChangeB.Visible = true;
                    menuItemSeparator1B.Visible = true;
                    //menuItemSeparator2B.Visible = true;
                    menuItemLoginB.Text = "ע��(&L)";

                    menuItemManageB.Visible = true;
                    menuItemSeparator4.Visible = true;

                    break;

                case EnumPowers.User:
                    menuItemFunction.Visible = true;
                    menuItemConfig.Visible = true;

                    //menuItemPluginA.Visible = false;
                    menuItemExitA.Visible = true;
                    menuItemPwdChangeA.Visible = true;
                    menuItemSeparator1A.Visible = true;
                    menuItemLoginA.Text = "ע��(&L)";

                    //menuItemPluginB.Visible = false;
                    menuItemExitB.Visible = true;
                    menuItemPwdChangeB.Visible = true;
                    menuItemSeparator1B.Visible = true;
                    menuItemLoginB.Text = "ע��(&L)";

                    menuItemManageB.Visible = true;
                    menuItemSeparator4.Visible = true;

                    break;

                case EnumPowers.Default:    // Ĭ��û���κ�Ȩ��
                    menuItemFunction.Visible = false;
                    menuItemConfig.Visible = false;

                    //menuItemPluginA.Visible = false;
                    menuItemExitA.Visible = false;
                    menuItemPwdChangeA.Visible = false;
                    menuItemSeparator1A.Visible = false;
                    //menuItemSeparator2A.Visible = false;
                    menuItemLoginA.Text = "��¼(&L)";

                    //menuItemPluginB.Visible = false;
                    menuItemExitB.Visible = false;
                    menuItemPwdChangeB.Visible = false;
                    menuItemSeparator1B.Visible = false;
                    //menuItemSeparator2B.Visible = false;
                    menuItemLoginB.Text = "��¼(&L)";

                    menuItemManageB.Visible = false;
                    menuItemSeparator4.Visible = false;

                    break;
            }
        }

        #endregion

        #region ��Czlt-2011-12-26 ���ǲ��������رճ����״̬���޸ġ�
        /// <summary>
        /// Czlt-2011-12-26 ���ǲ��������رճ����״̬���޸�
        /// </summary>
        private void CzltSaveChkXml2(bool isChk)
        {

            if (File.Exists(Application.StartupPath + "\\ChkType.Xml"))
            {

                XmlDocument dom = new XmlDocument();
                dom.Load(Application.StartupPath + @"\" + "ChkType.Xml");
                XmlNode xnSignalType = dom.SelectSingleNode("//TypeSignal//IsType");
                xnSignalType.InnerText = isChk.ToString();

                if (isChk == false)
                {
                    XmlNode xnSignalTime = dom.SelectSingleNode("//TypeSignal//CloseTime");
                    xnSignalTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    XmlNode xnSignalSumNum = dom.SelectSingleNode("//TypeSignal//SumNum");
                    xnSignalSumNum.InnerText = (Convert.ToInt64(xnSignalSumNum.InnerText) + 1).ToString();
                }



                dom.Save(Application.StartupPath.ToString() + "\\ChkType.xml");
            }


        }
        #endregion

        //#region ��Czlt-2011-08-10 ����Ѳ�����ڡ�
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void callTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    StrMessage = "";
        //    if (isCallAll == true)
        //    {
        //        CzltCallAll();


        //    }
        //    else
        //    {
        //        string strGroupNum = "";
        //        if (czltIndex >= czltSum)
        //        {
        //            callTime.Interval = 10000;
        //            callTime.Enabled = false;
        //            czltIndex = 0;
        //            czltStopTime = 0;
        //            czltCards.Clear();

        //        }
        //        else
        //        {


        //            DataTable dtStaIP = new DataTable();
        //            //Czlt2011-08-10 �����ʾ����Ϊ��
        //            if (strCodeNum.Equals(""))
        //            {
        //                //�����վ��Ϊ�յ�ʱ��
        //                if (!strStaNum.Equals("0"))
        //                {
        //                    //dtStaIP = czltGetCard.GetIPStaByCard(strStaNum);
        //                    callTime.Interval = 40000;
        //                    czltStopTime++;
        //                    if (czltStopTime == 4)
        //                    {
        //                        callTime.Enabled = false;
        //                        czltIndex = 0;
        //                        czltStopTime = 0;
        //                        czltCards.Clear();
        //                        return;
        //                    }
        //                    if (dtStaIP != null && dtStaIP.Rows.Count > 0)
        //                    {
        //                        DataTable dt = czltGetCard.GetGroupID(dtStaIP.Rows[0][1].ToString());
        //                        if (dt != null && dt.Rows.Count > 0)
        //                        {
        //                            string GroupID = dt.Rows[0][0].ToString();

        //                            string path = Application.StartupPath + "\\CallFlag.txt";
        //                            File.WriteAllText(path, strStaNum + " " + strStaHeadNum + " " + 0, Encoding.Default);
        //                            StrMessage = strStaNum + "�Ŵ����վ,����������\n";

        //                       }
        //                    }

        //                }

        //            }
        //            else
        //            {
        //                string[] strCodes = strCodeNum.Split(',');
        //                foreach (string stKy in strCodes)
        //                {
        //                    if (!czltCards.ContainsKey(Convert.ToInt32(stKy)))
        //                    {
        //                        czltCards.Add(Convert.ToInt32(stKy), stKy);
        //                    }
        //                }

        //                string skOutCard = string.Empty; //����վ�ı�ʶ��
        //                string skInCard = string.Empty;//����վ�ı�ʶ��
        //                Dictionary<int, string> czltGCodes = new Dictionary<int, string>();

        //                #region ��Czlt-2011-08-15 ˫ͨ�Ż���

        //                string skyCodes = string.Empty; //��ʶ����

        //                foreach (int codeId in czltCards.Keys)
        //                {
        //                    //���ݱ�ʶ���Ų�ѯ��վ
         //                   string czltSta = czltGetCard.Czlt_GetRTStnHead(codeId.ToString());
        //                    if (!czltSta.Trim().Equals(""))
        //                    {
        //                        skInCard += codeId.ToString() + ",";
        //                        string[] strC = czltSta.Split(',');
        //                        skyCodes += strC[0] + " " + strC[1] + " " + codeId.ToString() + ",";



        //                    }
        //                    else
        //                    {
        //                        skOutCard += codeId.ToString() + ",";
        //                    }

        //                }
        //                #endregion


        //                if (skyCodes.Length > 0)
        //                {
        //                    skyCodes = skyCodes.Substring(0, skyCodes.Length - 1);

        //                    string path = Application.StartupPath + "\\CallFlag.txt";
        //                    File.WriteAllText(path, skyCodes, Encoding.Default);
        //                    StrMessage = skInCard.Substring(0, skInCard.Length - 1) + " ��ʶ��,����������\n";
        //                    //this.rchTxtChinese.WriteTxt(skInCard + " ��ʶ��,����������\n", " ", true, System.Drawing.Color.Blue);
        //                }


        //                if (skOutCard.Length > 0)
        //                {
        //                    StrMessage += skOutCard.Substring(0, skOutCard.Length - 1) + "�ű�ʶ������վ,���еȴ���\n";
        //                    // this.rchTxtChinese.WriteTxt(skOutCard.Substring(0, skOutCard.Length - 1) + "�ű�ʶ������վ,���еȴ���\n", " ", true, System.Drawing.Color.Red);
        //                }

        //            }
        //        }
        //        czltIndex = czltIndex + czltStopTime;
        //    }
        //}

        //#endregion

        //#region��Czlt-2011-08-17 ȫ�󾮺��С�
        ///// <summary>
        ///// ȫ�󾮺���
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CzltCallAll()
        //{
        //    if (czltIndex >= czltSum)
        //    {
        //        czltIndex = 0;
        //        callTime.Interval = 10000;
        //        isCallAll = false;
        //        callTime.Enabled = false;
        //        StrMessage = "ȫ�������ֹͣ������\n";
        //        //this.rchTxtChinese.WriteTxt("ȫ�������ֹͣ������\n", " ", true, System.Drawing.Color.Blue);
        //    }
        //    else
        //    {
        //        czltIndex += 6;
        //        Dictionary<int, string> czltGCodes = new Dictionary<int, string>();
        //        string skyStations = string.Empty; //2��ͨѶ���ļ�

        //        DataTable dt = czltGetCard.Czlt_GetRTAllSta();
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                skyStations += dr[1] + " " + 0 + " " + 0 + ",";

        //            }
        //            if (skyStations.Length > 0)
        //            {

        //                skyStations = skyStations.Substring(0, skyStations.Length - 1);
        //                string path = Application.StartupPath + "\\CallFlag.txt";
        //                File.WriteAllText(path, skyStations, Encoding.Default);
        //                StrMessage = "ȫ������Ѿ�����������\n";
        //                //this.rchTxtChinese.WriteTxt("ȫ������Ѿ�����������\n", " ", true, System.Drawing.Color.Red);
        //            }
        //        }
        //    }

        //}
        //#endregion
    }

}
