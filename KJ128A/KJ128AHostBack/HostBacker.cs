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

        #region [ 声明 ]
        SwitchDatabase.SwitchDatabase switchDatabase = new KJ128A.SwitchDatabase.SwitchDatabase();

        /// <summary>
        /// 处理数据存储
        /// </summary>
        private readonly InterfaceHostBack interHostBack = new InterfaceHostBack();

        /// <summary>
        /// 存KJ128NBackUp数据库
        /// </summary>
        private DataSaveBackUp wdSaveBack;
 
        /// <summary>
        /// 存KJ128N数据库
        /// </summary>
        private DataSave dsBatman;

        public DataSave DsBatman
        {
            get { return dsBatman; }
        }

        private DataSend dsDataSend;

        /// <summary>
        /// True:主机;False:备机
        /// </summary>
        private bool isHost;


        /// <summary>
        /// 上次主备切换是否完成
        /// </summary>
        private bool isBackData = true;

        /// <summary>
        /// 主备切换标志，True:切换成主;False:切换成备
        /// </summary>
        private bool isSwitchHost = true;

        private DataBaseSync dbs = new DataBaseSync();
        #endregion


        private DateTime temp_dt;

        /*
        * 委托
        */

        #region [ 委托: 错误消息事件 ]

        /// <summary>
        /// 错误消息声明
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        public delegate void ErrorMessageEventHandler(int iErrNO, string strStackTrace, string strSource, string strMessage);

        /// <summary>
        /// 错误消息事件
        /// </summary>
        public event ErrorMessageEventHandler ErrorMessage;

        #endregion

        #region [ 委托方法 ]
        /// <summary>
        /// 注册错误消息处理
        /// </summary>
        /// <param name="iErrNO">错误消息编号</param>
        /// <param name="strStackTrace">获取当前异常发生时调用堆栈上的帧的字符串表示形式</param>
        /// <param name="strSource">标识当前哪一段程序出的错误</param>
        /// <param name="strMessage">获取描述当前异常的消息</param>
        void _ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace, strSource, strMessage);
            }
        }

        #endregion

        #region [ 构造函数 ]

        public HostBacker()
        {
            //检测SQL Server主数据库是否存在
            dbs.InitCheckDB();

          
            ////注册错误委托事件
            //dbs.ErrorMessage += _ErrorMessage;
            //dbs.SyncComplete += dbs_SyncComplete;

        }
        #endregion

        #region [ 接口: 初始化热备 ]

        /// <summary>
        /// 初始化热备
        /// </summary>
        /// <param name="isHost">是否主机</param>
        /// <param name="commType">通讯类型 true 网口  false 串口</param>
        /// <param name="strIP">对方的 IP 地址</param>
        /// <param name="intListenPort">本机监听端口</param>
        /// <param name="strPort">热备标志位</param>
        public bool InitHostBacker(bool isHost, bool commType, string strIP, int intListenPort, string strPort)
        {
            try
            {
                //Exit();

                this.isHost = isHost;

                if (isHost)//主机
                {
                    ServerRB server = new ServerRB(strIP, intListenPort);
                    server.ErrorMessage += new ServerRB.ErrorMessageEventHandler(server_ErrorMessage);
                    server.Listen();
                }
                else//备机
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

        #region [ 接口: 不启用热备程序 ]

        /// <summary>
        /// 不启用热备程序
        /// </summary>
        /// <returns></returns>
        public bool InitHostBacker(bool commType)
        {
            try
            {
                this.isHost = true;
                //检测SQL Server主数据库是否存在
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

        #region [ 接口: 主备切换 ]

        private void WriteSwitchDatabaseFile(string strState)
        {
            //创建
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
            //加载
            xmldocument.Load(Application.StartupPath + "\\SwitchDatabase.xml");
            XmlNode node = xmldocument.SelectSingleNode("/Database");
            node.InnerText = strState;
            xmldocument.Save(Application.StartupPath + "\\SwitchDatabase.xml");
        }

        public bool SwitchHostBack(int isMark)
        {
            if (!isHost)
            {
                if (isMark==2)         //收到的数据是自己的
                {
                    isSwitchHost = false;

                    //dsDataSend.isSyncHost = true;
                    //dsBatman.isSyncHost = true;        //通知DataSave线程，正在切换数据库

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

                        //主备切换时关闭挂接程序
                        CloseFile();
                    }

                    //第三种
                    WriteSwitchDatabaseFile("-1");

                    //切换成备数据库
                    SwitchKJ128NBackUpData();

                    //File.AppendAllText("D:\\Test_HostBacker.txt", "SwitchHostBack() isMark：" + isMark + " 切换成备机数据库 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n   ", Encoding.Default);
                    File.WriteAllText("D:\\Test_HostBacker.txt", "SwitchHostBack() isMark：" + isMark + " 切换成备机数据库 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\r\n", Encoding.Default);
                    //打开外接程序
                    //OpenFile();
                    
                }
                else if (isMark == 1)                //热备中,收到的数据不是自己的
                {
                    if (!isSwitchHost)      //如果已切换成备数据库，则切换成主数据库
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

                            //主备切换时关闭挂接程序
                            CloseFile();
                          
                        }
                        //第三种
                        WriteSwitchDatabaseFile("-1");

                        //切换成主数据库
                        SwitchKJ128NData();

                        //File.AppendAllText("D:\\Test_HostBacker.txt", "SwitchHostBack() isMark：" + isMark + " 切换成主机数据库 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n", Encoding.Default);
                        File.WriteAllText("D:\\Test_HostBacker.txt", "SwitchHostBack() isMark：" + isMark + " 切换成主机数据库 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\r\n", Encoding.Default);
                        //dsBatman.isSyncHost = false;     //通知DataSave线程，可以使用数据库

                        isSwitchHost = true;

                    }
                }
            }
            return true;
        }

        #endregion

        #region 【打开外挂程序】
        /// <summary>
        /// 打开外接程序
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

       

        #region 【关闭外接程序】
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
                        //            //if (nodeOuterPath.InnerText.Equals(strPath))//保存的路径和传入的路径一致，则置TRUE，并退出方法
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


        #region [ 方法: 切换成备数据库 ]

        private bool SwitchKJ128NBackUpData()
        {
            if (!isHost)        //备机
            {  
                isBackData = false;

                //DateTime orgLastFindDate = DateTime.Parse("2000-1-1 00:00:00");

                //while (interHostBack.IFExistDataInAllMDB_IsSync(orgLastFindDate))        //Access数据库的原始表（OrgData）中数据是否已经全部存入SQL Server数据库
                //{
                //    Thread.Sleep(200);
                //}

                if (ErrorMessage != null)
                {
                    ErrorMessage(8034003, "", "[HostBacker:SwitchKJ128NBackUpData]", "开始切换使用备机数据库！");
                }

                Thread.Sleep(1000);

                //temp_dt = DateTime.Now;

                ////切换数据库
                //dbs.DBSync();

                dbs_SyncComplete();
            }
            return true;
        }

        #endregion

        #region [ 方法: 切换成主数据库 ]

        private bool SwitchKJ128NData()
        {
            //if (ErrorMessage != null)
            //{
            //    ErrorMessage(8034006, "", "[HostBacker:SwitchKJ128NData]", "开始切换成主数据库！");
            //}

            if (ErrorMessage != null)
            {
                ErrorMessage(8034005, "", "[HostBacker:SwitchKJ128NData]", "切换成主机数据库成功，开始使用主机数据库！");
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

        #region [ 方法:  退出 ]

        /// <summary>
        /// 退出
        /// </summary>
        public bool Exit()
        {
            try
            {
                if (!isBackData)        //判断上一次数据库切换是否完成
                {
                    //停止上次切换数据库
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
                    ////结束存SQL Server数据库的线程
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
                    //结束发送数据的线程
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
                    //结束 SQLDMO连接
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

        #region [ 事件: 完成切换成备数据库 ]

        /// <summary>
        /// 完成切换成备数据库
        /// </summary>
        void dbs_SyncComplete()
        {

            if (ErrorMessage != null)
            {
                ErrorMessage(8034002, "", "[HostBacker:dbs_SyncComplete]", "切换成备机数据库成功，开始使用备机数据库运行！");
            }

            //第三种
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
