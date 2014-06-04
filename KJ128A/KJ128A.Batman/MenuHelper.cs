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
    /// 主窗体菜单
    /// </summary>
    public class MenuHelper
    {
        #region [ API: 记事本 ]

        /// <summary>
        /// 传递消息给记事本
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        /// <summary>
        /// 查找句柄
        /// </summary>
        /// <param name="hwndParent"></param>
        /// <param name="hwndChildAfter"></param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindow"></param>
        /// <returns></returns>
        [DllImport("User32.DLL")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        /// <summary>
        /// 记事本需要的常量
        /// </summary>
        public const uint WM_SETTEXT = 0x000C;

        #endregion

        #region [ 声明 ]

        private readonly FrmMain frmMain = null;     // 主窗体

        private ToolStripMenuItem menuItemShowMain = null;              // 显示主窗体
        private ToolStripMenuItem menuItemManageA = null;               // 管理菜单
        private ToolStripMenuItem menuItemManageB = null;               // 管理菜单
        private ToolStripMenuItem menuItemConfig = null;                // 配置菜单
        private ToolStripMenuItem menuItemFunction = null;              // 功能菜单
        private ToolStripMenuItem menuItemHelp = null;                  // 帮助菜单
        private readonly ToolStripSeparator menuItemSeparator4 = new ToolStripSeparator();       // 空行


        #region【Czlt-2011-08-10 设置传输分站,读卡分站,标识卡号】
        /// <summary>
        /// 待呼叫的标识卡数组
        /// </summary>
        private int[] _Cards;
        /// <summary>
        /// 双向通讯广播分站命令
        /// </summary>
        private int[] _Order;

        /// <summary>
        /// Czlt-2011-08-10 标识卡号
        /// </summary>
        private string strCodeNum = string.Empty;

        /// <summary>
        /// Czlt-2011-08-10 双通传入的标识卡号
        /// </summary>
        public string StrCodeNum
        {
            get { return strCodeNum; }
            set { strCodeNum = value; }
        }
        /// <summary>
        /// Czlt-2011-08-10 传输分站号
        /// </summary>
        private string strStaNum = string.Empty;
        /// <summary>
        /// Czlt-2011-08-10 读卡分站号
        /// </summary>
        private string strStaHeadNum = string.Empty;

        /// <summary>
        /// Czlt-2011-08-10 双向通讯控制器
        /// </summary>
        //private System.Timers.Timer callTime = new System.Timers.Timer();
        /// <summary>
        /// Czlt-2011-08-10 双通次数
        /// </summary>
        private int czltIndex = 0;

        /// <summary>
        /// Czlt-2011-08-10 总的巡检次数
        /// </summary>
        private int czltSum = 180;
        private int czltStopTime = 1;
        //标识卡的集合
        private Dictionary<int, string> czltCards = new Dictionary<int, string>();
        KJ128A.Controls.GetCardInfo czltGetCard = new KJ128A.Controls.GetCardInfo();
        private Dictionary<int, int> czltGroup = new Dictionary<int, int>();
        private string strCodeName = string.Empty;

        /// <summary>
        /// 全矿井呼叫
        /// </summary>
        // private System.Timers.Timer callAllTime = new System.Timers.Timer();
        //全矿井呼叫
        private bool isCallAll = false;
        /// <summary>
        /// Czlt-2011-10-08 是否为全矿呼叫
        /// </summary>
        public bool IsCallAll
        {
            get { return isCallAll; }
            set { isCallAll = value; }
        }

        //Czlt-2011-08-17 保存路径
        //private string strErrPath = Application.StartupPath + "\\CzltTest";

        private string strMessage = "";
        /// <summary>
        /// 呼叫提示信息
        /// </summary>
        public string StrMessage
        {
            get { return strMessage; }
            set { strMessage = value; }
        }

        #endregion

        #endregion

        #region [ 构造函数 ]

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public MenuHelper()
        {

            //Czlt-2011-08-10 双向通讯
            //callTime.Interval = 10000;
            //callTime.Elapsed += new System.Timers.ElapsedEventHandler(callTime_Elapsed);
            //callTime.Enabled = false;
        }

        /// <summary>
        /// 构造函数
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
         * 创建菜单
        */

        #region [ 方法: 创建主菜单 ]

        /// <summary>
        /// 创建主菜单
        /// </summary>
        public void BuildMainMenu(Control ctl)
        {
            #region [ 菜单: 显示/隐藏 ]

            // 任务栏菜单特有属性 显示/隐藏
            if (ctl.GetType() == typeof(ContextMenuStrip))
            {
                menuItemShowMain = new ToolStripMenuItem("隐藏/显示(&S)");
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

                // 分隔符
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

            // 管理菜单
            menuItemManageA = new ToolStripMenuItem("管理(&M)");
            menuItemManageB = new ToolStripMenuItem("管理(&M)");

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

            // 配置菜单
            menuItemConfig = new ToolStripMenuItem("配置(&C)");
            if (ctl.GetType() == typeof(MenuStrip))
            {
                ((MenuStrip)(ctl)).Items.Add(menuItemConfig);
            }
            else
            {
                ((ContextMenuStrip)(ctl)).Items.Add(menuItemConfig);
            }

            BuildConfigMenu();

            // 功能菜单
            menuItemFunction = new ToolStripMenuItem("功能(&G)");
            if (ctl.GetType() == typeof(MenuStrip))
            {
                ((MenuStrip)(ctl)).Items.Add(menuItemFunction);
            }
            else
            {
                ((ContextMenuStrip)(ctl)).Items.Add(menuItemFunction);
            }

            BuildFunctionMenu();

            // 帮助菜单
            menuItemHelp = new ToolStripMenuItem("帮助(&H)");
            if (ctl.GetType() == typeof(MenuStrip))
            {
                ((MenuStrip)(ctl)).Items.Add(menuItemHelp);
            }
            else
            {
                ((ContextMenuStrip)(ctl)).Items.Add(menuItemHelp);
            }

            BuildHelpMenu();


            #region [ 任务栏: 注销菜单 ]

            if (ctl.GetType() == typeof(ContextMenuStrip))
            {
                // 分隔符
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
                //    if (menuItemLoginB.Text == "注销(&L)")
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

        #region [ 方法: 管理菜单 A ]

        ToolStripMenuItem menuItemPwdChangeA = null;         // 密码修改菜单
        ToolStripMenuItem menuItemLoginA = null;             // 用户登录菜单
        ToolStripSeparator menuItemSeparator1A = null;       // 分隔符 1
        //ToolStripMenuItem menuItemPluginA = null;            // 插件管理菜单
        //ToolStripSeparator menuItemSeparator2A = null;       // 分隔符 2
        ToolStripMenuItem menuItemExitA = null;              // 退出菜单

        /// <summary>
        /// 创建管理菜单
        /// </summary>
        private void BuildManageMenuA()
        {
            // 密码修改菜单
            menuItemPwdChangeA = new ToolStripMenuItem("密码修改(&P");
            menuItemPwdChangeA.Click += delegate
            {
                FrmChangePwd frmPwdChange = new FrmChangePwd(frmMain, "Login.xml");
                frmPwdChange.ErrorMessage += frmPwdChange_ErrorMessage;
                frmPwdChange.ShowDialog();
                frmPwdChange.Dispose();
            };
            menuItemManageA.DropDownItems.Add(menuItemPwdChangeA);

            // 用户登录菜单
            menuItemLoginA = new ToolStripMenuItem("登录(&L)");             // 登录菜单
            menuItemLoginA.Click += delegate
            {
                if (menuItemLoginA.Text == "注销(&L)")
                {
                    //Czlt-2010-09-25
                    DialogResult result;
                    result = MessageBox.Show("是否要注销系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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


            // 分隔符
            menuItemSeparator1A = new ToolStripSeparator();                // 分隔符 1
            menuItemManageA.DropDownItems.Add(menuItemSeparator1A);

            //// 插件管理菜单
            //menuItemPluginA = new ToolStripMenuItem("插件管理(&M)");        // 插件菜单
            //menuItemManageA.DropDownItems.Add(menuItemPluginA);

            //// 分隔符
            //menuItemSeparator2A = new ToolStripSeparator();                // 分隔符 2
            //menuItemManageA.DropDownItems.Add(menuItemSeparator2A);

            // 退出菜单
            menuItemExitA = new ToolStripMenuItem("退出(&X)");              // 退出菜单
            menuItemExitA.Click += delegate
            {
                //Czlt-2010-09-25
                DialogResult result;
                result = MessageBox.Show("是否要退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        #region [ 方法: 管理菜单 B ]

        ToolStripMenuItem menuItemPwdChangeB = null;         // 密码修改菜单
        //ToolStripMenuItem menuItemLoginB = new ToolStripMenuItem("登录(&L)");             // 用户登录菜单
        ToolStripMenuItem menuItemLoginB = null;
        ToolStripSeparator menuItemSeparator1B = null;       // 分隔符 1
        ToolStripMenuItem menuItemPluginB = null;            // 插件管理菜单
        ToolStripSeparator menuItemSeparator2B = null;       // 分隔符 2
        ToolStripMenuItem menuItemExitB = null;              // 退出菜单

        /// <summary>
        /// 创建管理菜单
        /// </summary>
        private void BuildManageMenuB()
        {
            // 密码修改菜单
            menuItemPwdChangeB = new ToolStripMenuItem("密码修改(&P");
            menuItemPwdChangeB.Click += delegate
            {
                FrmChangePwd frmPwdChange = new FrmChangePwd(frmMain, "Login.xml");
                frmPwdChange.ShowDialog();
                frmPwdChange.Dispose();
            };
            menuItemManageB.DropDownItems.Add(menuItemPwdChangeB);

            // 用户登录菜单
            menuItemLoginB = new ToolStripMenuItem("登录(&L)");             // 登录菜单
            menuItemLoginB.Click += delegate
            {
                if (menuItemLoginB.Text == "注销(&L)")
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

            // 分隔符
            menuItemSeparator1B = new ToolStripSeparator();               // 分隔符 1
            menuItemManageB.DropDownItems.Add(menuItemSeparator1B);

            //// 插件管理菜单
            //menuItemPluginB = new ToolStripMenuItem("插件管理(&M)");        // 插件菜单
            //menuItemManageB.DropDownItems.Add(menuItemPluginB);

            //// 分隔符
            //menuItemSeparator2B = new ToolStripSeparator();                // 分隔符 2
            //menuItemManageB.DropDownItems.Add(menuItemSeparator2B);

            // 退出菜单
            menuItemExitB = new ToolStripMenuItem("退出(&X)");              // 退出菜单
            menuItemExitB.Click += delegate {
                if (MessageBox.Show("关闭通讯程序会对数据造成一定影响，确定要关闭通讯程序吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    CzltSaveChkXml2(true);
                    frmMain.Exit();
                }
            };
            menuItemManageB.DropDownItems.Add(menuItemExitB);
        }

        #endregion

        #region [ 方法: 配置菜单 ]

        /// <summary>
        /// 创建配置菜单
        /// </summary>
        private void BuildConfigMenu()
        {
            //// 参数设置
            //ToolStripMenuItem menuParams = new ToolStripMenuItem("参数设置(&P)");
            //menuParams.Click += delegate
            //{
            //    FrmParams frmParams = new FrmParams("Params.xml");
            //    frmParams.ShowDialog();
            //    frmParams.Dispose();
            //};
            //menuItemConfig.DropDownItems.Add(menuParams);

            //// 分隔符
            //menuItemConfig.DropDownItems.Add("-");

            // 串口配置
            ToolStripMenuItem menuCommConfig = new ToolStripMenuItem("通讯配置(&C)");
            menuCommConfig.Click += delegate
            {
                StartPort.ShowCommSetDialog("SerialPort.xml", frmMain);
            };
            menuItemConfig.DropDownItems.Add(menuCommConfig);

            //// 数据库配置
            //ToolStripMenuItem menuDBConfig = new ToolStripMenuItem("数据库(&D)");
            //menuItemConfig.DropDownItems.Add(menuDBConfig);

            //// 主数据库
            //ToolStripMenuItem menuDBConfigMain = new ToolStripMenuItem("主数据库(&M)");
            //menuDBConfigMain.Click += delegate
            //{
            //    FrmDBSet frmDBSet = new FrmDBSet(frmMain, 1, "DbConfig.xml");
            //    frmDBSet.ErrorMessage += frmDBSet_ErrorMessage;
            //    frmDBSet.ShowDialog();
            //    frmDBSet.Dispose();
            //};
            //menuDBConfig.DropDownItems.Add(menuDBConfigMain);

            //// 备数据库
            //ToolStripMenuItem menuDBConfigBackup = new ToolStripMenuItem("备数据库(&B)");
            //menuDBConfigBackup.Click += delegate
            //{
            //    FrmDBSet frmDBSet = new FrmDBSet(frmMain, 2, "DbConfig.xml");
            //    frmDBSet.ErrorMessage += frmDBSet_ErrorMessage;
            //    frmDBSet.ShowDialog();
            //    frmDBSet.Dispose();
            //};
            //menuDBConfig.DropDownItems.Add(menuDBConfigBackup);

            // 热备配置 --袁丽修改 2008-03-04
            ToolStripMenuItem menuHostConfig = new ToolStripMenuItem("热备配置(&R)");
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

        #region [ 方法: 功能菜单 ]

        private ToolStripMenuItem menuItemPause = null;         // 暂停菜单
        private ToolStripMenuItem menuItemDataCopy = null;      // 数据复制菜单
        private ToolStripMenuItem menuItemTwo = null;

        /// <summary>
        /// 创建功能菜单
        /// </summary>
        private void BuildFunctionMenu()
        {
            // 暂停菜单
            menuItemPause = new ToolStripMenuItem("暂停(&P)");
            menuItemFunction.DropDownItems.Add(menuItemPause);

            // 数据复制菜单
            menuItemDataCopy = new ToolStripMenuItem("数据复制(&C)");
            menuItemFunction.DropDownItems.Add(menuItemDataCopy);

            //Czlt-2010-11-29-双向通讯
            menuItemTwo = new ToolStripMenuItem("双向通讯(&T)");
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
                //    //this.rchTxtChinese.WriteTxt("呼叫已停止！\n", " ", true, System.Drawing.Color.Blue);


                //}



                if (!File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "Calling.xml"))
                {
                    //创建
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
                    ////加载
                    //xmldocument.Load(Application.StartupPath + "\\SwitchDatabase.xml");
                    //XmlNode node = xmldocument.SelectSingleNode("/Database");
                    //node.InnerText = strState;
                    //xmldocument.Save(Application.StartupPath + "\\SwitchDatabase.xml");

                    //启用双通
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

                        //被呼叫的标识卡号
                        XmlNode nodeCode = czltXmlDocument.SelectSingleNode("/Call/strCodeNum");
                        nodeCode.InnerText = a_frmTwo.CodeNum;

                        //被呼叫的传输分站号
                        XmlNode nodeSta = czltXmlDocument.SelectSingleNode("/Call/strStaNum");
                        nodeSta.InnerText = a_frmTwo.StationNum;

                        //被呼叫的读卡分站号
                        XmlNode nodeSHead = czltXmlDocument.SelectSingleNode("/Call/strStaHeadNum");
                        nodeSHead.InnerText = a_frmTwo.StaHeadNum;

                        //被呼叫的卡号和人员
                        XmlNode nodeCodeName = czltXmlDocument.SelectSingleNode("/Call/strCodeName");
                        nodeCodeName.InnerText = a_frmTwo.StrCodeAndName;                      
                      
                    }

                    if (frmMain.commType)//环网通讯
                    {
                        //环网 true
                        XmlNode nodeType = czltXmlDocument.SelectSingleNode("/Call/commType");
                        nodeType.InnerText = "true";
                    }
                    else//串口通讯
                    {
                      //串口 false
                        XmlNode nodeType = czltXmlDocument.SelectSingleNode("/Call/commType");
                        nodeType.InnerText = "true";
                    }
                }

                //Czlt-2011-10-08 取消呼叫通讯
                if (a_frmTwo.IsClose)
                {
                    //启用双通
                    XmlNode node = czltXmlDocument.SelectSingleNode("/Call/isCall");
                    node.InnerText = "false";

                    //取消全矿呼叫
                    XmlNode nodeCallAll = czltXmlDocument.SelectSingleNode("/Call/CallAll");
                    nodeCallAll.InnerText = "false";

                    //被呼叫的标识卡号
                    XmlNode nodeCode = czltXmlDocument.SelectSingleNode("/Call/strCodeNum");
                    nodeCode.InnerText = "";

                    //被呼叫的传输分站号
                    XmlNode nodeSta = czltXmlDocument.SelectSingleNode("/Call/strStaNum");
                    nodeSta.InnerText = a_frmTwo.StationNum;

                    //被呼叫的读卡分站号
                    XmlNode nodeSHead = czltXmlDocument.SelectSingleNode("/Call/strStaHeadNum");
                    nodeSHead.InnerText = a_frmTwo.StaHeadNum;

                    //被呼叫的读卡分站号
                    XmlNode nodeCodeName = czltXmlDocument.SelectSingleNode("/Call/strCodeName");
                    nodeCodeName.InnerText = "";     
                }

                czltXmlDocument.Save(Application.StartupPath + "\\Calling.xml");

                //if (a_frmTwo.ShowDialog() == DialogResult.OK)
                //{

                //    if (frmMain.commType)//环网通讯
                //    {
                //        StartTcp.m_TcpClientPort.IsTwoMessage = true;
                //        StartTcp.m_TcpClientPort.CardToCall = a_frmTwo.GetCards();
                //        StartTcp.m_TcpClientPort.CallOrder = a_frmTwo.GetOrder();

                //    }
                //    else//串口通讯
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
            //隐藏双通功能
            menuItemTwo.Visible = true;
            menuItemFunction.DropDownItems.Add(menuItemTwo);

        }

        /// <summary>
        /// 同步功能菜单
        /// </summary>
        public void MenuSyncFunction(KJRichTextBox _RtxtSysMsg)
        {
            if (frmMain.commType)
            {
                if (StartTcp.m_TcpClientPort != null)
                {
                    ToolStripMenuItem menuItemSerialPortPause = new ToolStripMenuItem("环网发送暂停");

                    menuItemSerialPortPause.Click += delegate(object sender, EventArgs e)
                    {
                        if (StartTcp.m_TcpClientPort.IsPause)
                        {
                            ((ToolStripMenuItem)(sender)).Text = "环网发送暂停";
                        }
                        else
                        {
                            ((ToolStripMenuItem)(sender)).Text = "环网继续发送";
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
                // 暂停子菜单
                if (StartPort.s_serialPort != null)
                {
                    ToolStripMenuItem[] menuItemSerialPortPause = new ToolStripMenuItem[StartPort.s_serialPort.Length];
                    for (int i = 0; i < StartPort.s_serialPort.Length; i++)
                    {
                        menuItemSerialPortPause[i] = new ToolStripMenuItem(StartPort.s_serialPort[i].PortName + " 发送暂停");
                        menuItemSerialPortPause[i].Tag = i;
                        menuItemSerialPortPause[i].Click += delegate(object sender, EventArgs e)
                        {
                            if (StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].IsPause)
                            {
                                ((ToolStripMenuItem)(sender)).Text = StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].PortName + " 发送暂停";
                            }
                            else
                            {
                                ((ToolStripMenuItem)(sender)).Text = StartPort.s_serialPort[int.Parse(((ToolStripMenuItem)(sender)).Tag.ToString())].PortName + " 继续发送";
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

            // 启动应用程序
            menuItemDataCopy.Click += delegate
            {

                string strTran = string.Empty;  // 需要传送的内容
                bool blnNotepad = false;         // 记事本成功启动

                #region [ 启动记事本 ]

                System.Diagnostics.Process Proc;

                try
                {
                    // 启动记事本
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

                #region [ 系统消息面板 ]

                if (_RtxtSysMsg != null)
                {
                    // 如果记事本启动成功，则将系统消息面板中的数据提交给记事本，否则发送到内存中。
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

                #region [ 数据面板 ]
                if (frmMain.commType)
                {
                    // 如果记事本启动成功，则将数据面板中的数据提交给记事本，否则发送到内存中。
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
                    // 如果记事本启动成功，则将数据面板中的数据提交给记事本，否则发送到内存中。
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

                #region [ 传递数据给记事本 ]

                if (blnNotepad && Proc != null)
                {
                    // 调用 API, 传递数据
                    while (Proc.MainWindowHandle == IntPtr.Zero)
                    {
                        Proc.Refresh();
                    }

                    IntPtr vHandle = FindWindowEx(Proc.MainWindowHandle, IntPtr.Zero, "Edit", null);

                    // 传递数据给记事本
                    SendMessage(vHandle, WM_SETTEXT, 0, strTran);
                }

                #endregion

            };
        }

        #endregion


        #region 【Czlt-2011-12-26 对是不是正常关闭程序的状态做修改】
        /// <summary>
        /// Czlt-2011-12-26 对是不是正常关闭程序的状态做修改
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

        #region [ 方法: 配置菜单 ]

        /// <summary>
        /// 创建配置菜单
        /// </summary>
        private void BuildHelpMenu()
        {
            // 参数设置
            ToolStripMenuItem menuAbout = new ToolStripMenuItem("关于(&A)");
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
         * 菜单权限
         */

        #region [ 方法: 菜单权限 ]

        /// <summary>
        /// 菜单权限
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
                    menuItemLoginA.Text = "注销(&L)";

                    //menuItemPluginB.Visible = true;
                    menuItemExitB.Visible = true;
                    menuItemPwdChangeB.Visible = true;
                    menuItemSeparator1B.Visible = true;
                    //menuItemSeparator2B.Visible = true;
                    menuItemLoginB.Text = "注销(&L)";

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
                    menuItemLoginA.Text = "注销(&L)";

                    //menuItemPluginB.Visible = false;
                    menuItemExitB.Visible = true;
                    menuItemPwdChangeB.Visible = true;
                    menuItemSeparator1B.Visible = true;
                    menuItemLoginB.Text = "注销(&L)";

                    menuItemManageB.Visible = true;
                    menuItemSeparator4.Visible = true;

                    break;

                case EnumPowers.Default:    // 默认没有任何权限
                    menuItemFunction.Visible = false;
                    menuItemConfig.Visible = false;

                    //menuItemPluginA.Visible = false;
                    menuItemExitA.Visible = false;
                    menuItemPwdChangeA.Visible = false;
                    menuItemSeparator1A.Visible = false;
                    //menuItemSeparator2A.Visible = false;
                    menuItemLoginA.Text = "登录(&L)";

                    //menuItemPluginB.Visible = false;
                    menuItemExitB.Visible = false;
                    menuItemPwdChangeB.Visible = false;
                    menuItemSeparator1B.Visible = false;
                    //menuItemSeparator2B.Visible = false;
                    menuItemLoginB.Text = "登录(&L)";

                    menuItemManageB.Visible = false;
                    menuItemSeparator4.Visible = false;

                    break;
            }
        }

        #endregion

        #region 【Czlt-2011-12-26 对是不是正常关闭程序的状态做修改】
        /// <summary>
        /// Czlt-2011-12-26 对是不是正常关闭程序的状态做修改
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

        //#region 【Czlt-2011-08-10 控制巡检周期】
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
        //            //Czlt2011-08-10 假如标示卡号为空
        //            if (strCodeNum.Equals(""))
        //            {
        //                //传输分站不为空的时候
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
        //                            StrMessage = strStaNum + "号传输分站,呼叫启动！\n";

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

        //                string skOutCard = string.Empty; //出分站的标识卡
        //                string skInCard = string.Empty;//进分站的标识卡
        //                Dictionary<int, string> czltGCodes = new Dictionary<int, string>();

        //                #region 【Czlt-2011-08-15 双通优化】

        //                string skyCodes = string.Empty; //标识卡号

        //                foreach (int codeId in czltCards.Keys)
        //                {
        //                    //根据标识卡号查询分站
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
        //                    StrMessage = skInCard.Substring(0, skInCard.Length - 1) + " 标识卡,呼叫启动！\n";
        //                    //this.rchTxtChinese.WriteTxt(skInCard + " 标识卡,呼叫启动！\n", " ", true, System.Drawing.Color.Blue);
        //                }


        //                if (skOutCard.Length > 0)
        //                {
        //                    StrMessage += skOutCard.Substring(0, skOutCard.Length - 1) + "号标识卡出分站,呼叫等待！\n";
        //                    // this.rchTxtChinese.WriteTxt(skOutCard.Substring(0, skOutCard.Length - 1) + "号标识卡出分站,呼叫等待！\n", " ", true, System.Drawing.Color.Red);
        //                }

        //            }
        //        }
        //        czltIndex = czltIndex + czltStopTime;
        //    }
        //}

        //#endregion

        //#region【Czlt-2011-08-17 全矿井呼叫】
        ///// <summary>
        ///// 全矿井呼叫
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
        //        StrMessage = "全矿呼叫已停止！！！\n";
        //        //this.rchTxtChinese.WriteTxt("全矿呼叫已停止！！！\n", " ", true, System.Drawing.Color.Blue);
        //    }
        //    else
        //    {
        //        czltIndex += 6;
        //        Dictionary<int, string> czltGCodes = new Dictionary<int, string>();
        //        string skyStations = string.Empty; //2号通讯组文件

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
        //                StrMessage = "全矿呼叫已经启动！！！\n";
        //                //this.rchTxtChinese.WriteTxt("全矿呼叫已经启动！！！\n", " ", true, System.Drawing.Color.Red);
        //            }
        //        }
        //    }

        //}
        //#endregion
    }

}
