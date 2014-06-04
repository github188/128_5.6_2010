using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NMainRun.StationManage;
using KJ128NMainRun.RealTime;
using KJ128NDataBase;
using System.Collections;
using Shine.Logs;
using Shine.Logs.LogType;
using Wilson.Controls.Docking;
using System.IO;
using System.Diagnostics;
using System.Xml;
using KJ128NMainRun.EmployeeManage;
using KJ128NMainRun.A_RTAlarm;
using KJ128NInterfaceShow;
using KJ128NMainRun.A_Tool;
using KJ128NMainRun.A_RT_StationHead;
using KJ128NMainRun.A_His_StationHead;
using KJ128NMainRun.A_InMineDayReport;
using KJ128NMainRun.A_Statement;
using KJ128NMainRun.A_Print;
using KJ128NMainRun.A_StationConfigInfo;
using KJ128A.HostBack;
using System.Runtime.InteropServices;

namespace KJ128NMainRun
{
    public partial class A_FrmMain : Form
    {

        #region【声明】

        private A_MainBLL mbll = new A_MainBLL();
        DataSave dsave = new DataSave();
        /// <summary>
        /// 是否记住密码
        /// </summary>
        public static bool blIsMemorize = true;
        //czlt-2010-9-29
        Hashtable hashPlugins = new Hashtable();
        string[] str;   //czlt-声明数组
        /// <summary>
        /// 系统日志的路径
        /// 
        /// </summary>
        private string strLogPath = Application.StartupPath + "\\KJ128ALog\\";
        private DataSet ds;
        private A_FrmRTAlarm AlarmFrm = null;
        public MenuStrip MS
        {
            get { return this.msMainMenu; }
        }
        private A_PrintBLL pbll = new A_PrintBLL();
        private bool isShow = true;

        //Czlt-2012-04-23 设置自动调用GC的定时器
        private System.Timers.Timer gcTime = new System.Timers.Timer();

        #endregion


        #region【构造函数】


        public A_FrmMain()
        {
            SetRefreshTime();
            SetHostBackRefresh();
            LoadEmpHelp();

            InitializeComponent();

            //Czlt-10-9打开外挂程序
            OpenFile();

            //是采用环网进行配置
            if (IsRingNetwork())
            {
                tsmiTcpConfig.Visible = true;
                toolStripSeparator7.Visible = true;
            }
            else
            {
                tsmiTcpConfig.Visible = false;
                toolStripSeparator7.Visible = false;
            }

            ///设置定时器的时间为90秒
            gcTime.Interval = 600000;
            gcTime.Enabled = true;
            gcTime.Elapsed += new System.Timers.ElapsedEventHandler(gcTime_Elapsed);
        }

       

        #endregion

        #region 【打开外挂程序】
        public void OpenFile()
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
                        //czlt-2010-9-29
                        XmlNode nodeId = node.SelectSingleNode("ID");

                        XmlNode nodeEnable = node.SelectSingleNode("isEnable");
                        XmlNode nodeOuterPath = node.SelectSingleNode("OuterPath");

                        if (nodeEnable.InnerText.Equals("1"))
                        {
                            try
                            {
                                if (File.Exists(nodeOuterPath.InnerText))
                                {
                                    //czlt-2010-9-29
                                    str = nodeOuterPath.InnerText.Split('\\');
                                    hashPlugins.Add(nodeId.InnerText, str[str.Length - 1].Substring(0, (str[str.Length - 1].Length - 4)));

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


        #region【窗体加载】

        private void A_FrmMain_Load(object sender, EventArgs e)
        {
            dockPanel1.AllowEndUserDocking = false;


            #region 实时报警信息
            A_FrmRTAlarm frmrta = new A_FrmRTAlarm(dockPanel1);
            this.AlarmFrm = frmrta;
            frmrta.Show(dockPanel1, DockState.Document);
            #endregion

            #region 分站状态信息
            A_FrmStationConfigInfo frm = new A_FrmStationConfigInfo(dockPanel1);
            frm.Show(dockPanel1, DockState.Document);
            #endregion

            #region 实时下井人员名单
            //RealTime.FrmRealTimeInMineEmp frmE = new FrmRealTimeInMineEmp(dockPanel1);
            //frmE.Show(dockPanel1, DockState.Document);
            #endregion


            #region 判断主、备机、客户端

            string configPath = Application.StartupPath + @"\HostIPConfig.xml";

            XmlDocument docConfig = new XmlDocument();


            if (File.Exists(configPath))
            {
                //MessageBox.Show("HostIPConfig.xml文件不存在,配置文件后会自动生成此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                docConfig.Load(configPath);

                string isStartHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;

                if (isStartHost.ToUpper() == "TRUE")
                {

                    string isHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[1].InnerText;


                    if (isHost.ToUpper() == "TRUE")
                    {
                        this.Text = "KJ128A型矿用人员管理系统--[主机]";

                    }
                    else
                    {
                        this.Text = "KJ128A型矿用人员管理系统--[备机]";
                        timer_Clear.Enabled = false;
                        //qyz备机功能全开
                        tsmiSystem.Enabled = true;             //登录菜单
                        tsmiConfiguration.Enabled = false;              //配置菜单
                        tsmiTools.Enabled = false;     //工具菜单
                        tsbtnLogin.Enabled = true;                 //状态栏-登录

                         DataTable stationdt = this.GetStationTable();
                         ReplaceStationXml(stationdt, Application.StartupPath + "\\Station.xml");

                    }


                }
                else
                {

                    if (New_DBAcess.blIsClient)
                    {
                        this.Text = "KJ128A型矿用人员管理系统--[客户端]";
                        tsmiOuterProject.Visible = false;
                        timer_Clear.Enabled = false;
                    }
                }
            }

            #endregion

            #region 关闭欢迎画面

            FrmWelcome frmWelcome = (FrmWelcome)Application.OpenForms["FrmWelcome"];
            if (frmWelcome != null)
            {
                frmWelcome.Close();
            }

            #endregion

            #region 是否是客户端程序

            if (New_DBAcess.blIsClient)
            {
                tsmiSystem.Enabled = true;             //登录菜单               
                //Czlt-2010-10-9 - 客户端打包时使用
                tsmiConfiguration.Visible = false;              //配置菜单
                //Czlt-2010-10-9 - 主机和客户端(可配置) 使用
                //tsmiConfiguration.Visible = true;              //配置菜单
                tsmiTools.Enabled = false;     //工具菜单
                tsmiTools.Visible = false;
                tsbtnLogin.Enabled = true;                 //状态栏-登录
                tsmiHolidayClass.Visible = false;
                tsmiHolidayManage.Visible = false;
                tsmiRealTimeAdd.Visible = false;
                tsmiAddHistoryAttendance.Visible = false;
                toolStripSeparator12.Visible = false;
                timer_Clear.Enabled = false;
            }

            #endregion

            #region[]
            FlashTsmi();
            #endregion

            #region[状态栏信息]
            int width = this.stsMes.Width / 5;
            for (int i = 0; i < this.stsMes.Items.Count; i++)
            {
                this.stsMes.Items[i].Width = width - 5;
            }
            this.stsUsername.Text = "用户名:来宾";
            this.stsLoginTime.Text = "登录时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
            if (this.Text.Contains("--"))
            {
                this.stsBak.Text = this.Text.Substring(this.Text.IndexOf("--") + 2);
            }
            else
            {
                this.stsBak.Text = "[单机]";
            }
            this.stsBeginTime.Text = "运行时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (AlarmFrm.BlIsAlarm)
            {
                stsAlarm.ForeColor = Color.Red;
                stsAlarm.Text = "报警显示:报警";
                timeShow.Enabled = true;

            }
            else
            {
                stsAlarm.ForeColor = Color.Black;
                stsAlarm.Text = "报警显示:无报警";
                timeShow.Enabled = false;
            }
            #endregion

            timer_Alarm.Interval = RefReshTime._rtTime;

            #region[判断是否删除数据]
            if (mbll.DeleteSql())
            {
                if (MessageBox.Show("由于您设置了定时删除历史数据，选择“Yes”自动执行，选择“No”取消删除(您可以在系统配置中重新设置自动删除数据时间)", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (MessageBox.Show("准备执行自动删除历史数据，请确认备份了数据库以防止不可逆转的数据丢失，确定删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            mbll.DeleteSql1();
                        }
                    }
                    catch { }
                }
            }
            #endregion

            if (!File.Exists(Application.StartupPath + "\\PowerManager.xml"))
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\PowerManager.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter ws = new StreamWriter(fs);
                ws.WriteLine("<Root>");
                ws.WriteLine("<IsOpen>False</IsOpen>");
                ws.WriteLine("</Root>");
                ws.Close();
                ws.Dispose();
                fs.Close();
                fs.Dispose();

            }

            //#region 【Czlt-2011-12-26 软件启动时修改配置信息,并启动KJ128诊断软件】
            //CzltSaveChkXml(false, true);

            ////打开KJ128检测系统

            //int iCount = 0;
            //foreach (Process process in Process.GetProcesses())
            //{
            //    if (process.ProcessName.Equals("Kj128ChkHost"))
            //    {
            //        iCount++;
            //    }
            //}

            ////Czlt-2011-01-25 删除打开多个程序控制
            ////qyz-2011-11-27 加入多开限制
            //if (iCount > 0)
            //{
            //    // MessageBox.Show("已经有一个KJ128A桌面程序在运行,请勿重复打开!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
            //else
            //{

            //    //打开KJ128检测系统
            //    if (File.Exists(Application.StartupPath + "\\Kj128ChkHost.exe"))
            //    {
            //        try
            //        {
            //            string strPath = @"Kj128ChkHost.exe";
            //            Process TongXun = new Process();
            //            TongXun.StartInfo.FileName = strPath;
            //            TongXun.Start();
            //            //给提示信息
            //        }
            //        catch { }
            //    }
            //}
            //#endregion


        }

        #endregion

        #region[备机菜单屏蔽]
        public void SetTsmiFalse()
        {
            //Czlt-2010-12-20 - 主备机切换
            XmlDocument docIsHost = new XmlDocument();
            string isHostConn = "true";
            if (File.Exists(Application.StartupPath + @"\HostConnState.xml"))
            {
                docIsHost.Load(Application.StartupPath + @"\HostConnState.xml");
                isHostConn = docIsHost.ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;
            }

            if (isHostConn.ToLower().Equals("true"))
            {
                tsmiSystem.Enabled = true;             //登录菜单
                tsmiConfiguration.Enabled = true;              //配置菜单
                tsmiTools.Enabled = true;     //工具菜单
                tsbtnLogin.Enabled = true;                 //状态栏-登录
            }
            else if (isHostConn.ToLower().Equals("false"))
            {
                tsmiSystem.Enabled = true;             //登录菜单
                tsmiConfiguration.Enabled = true;              //配置菜单
                tsmiTools.Enabled = true;     //工具菜单
                tsbtnLogin.Enabled = true;                 //状态栏-登录
            }
        }
        #endregion

        #region[工作异常是否显示]
        public void FlashTsmi()
        {
            bool visible1 = mbll.IsAlarmWalk();
            bool visible2 = mbll.IsAlarmWork();
            tsmiWorkExceptional.Visible = visible1 || visible2;
            tsmiWalkConfig.Visible = visible1;
            tsmiAssociate.Visible = visible2;
            tsmiHistroryAssociate.Visible = visible2;
        }
        #endregion

        #region【事件：窗体关闭】

        private void A_FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (LoginBLL.user.Equals("KJ128AORKJ128N"))
            {

                // 终止定时打印线程
                // th.Abort();
            }
            else if (LoginBLL.user == "guest" && !New_DBAcess.blIsClient)
            {
                DialogResult dre = MessageBox.Show("你没有权限关闭本软件,如想关闭本软件，请重先登录！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dre == DialogResult.Yes)
                {
                    A_FrmLogin frm = new A_FrmLogin(this);
                    frm.ShowDialog();
                }
                e.Cancel = true;
            }
            else
            {
                A_FrmExit frme = new A_FrmExit();

                DialogResult dir = frme.ShowDialog();

                if (dir == DialogResult.Cancel)
                {
                    //用户取消关闭系统
                    e.Cancel = true;
                    return;
                }
                else if (dir == DialogResult.OK)
                {
                    //用户需要挂包通讯程序

                    #region【关闭通讯程序】

                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Equals("KJ128A.Batman"))
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch { }
                           // break;
                        }

                        //关闭Kj128保护程序                      
                        if (process.ProcessName.Equals("Kj128ChkHost"))
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch { }

                        }
                    }

                    #endregion

                    //#region 【Czlt-2011-12-26 软件正常关闭时修改配置信息,并关闭KJ128诊断软件】
                    //CzltSaveChkXml(true, true);
                    //#endregion

                    ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "关闭KJ128A矿用人员管理系统，并关闭通讯程序！");
                }
                else
                {

                    //#region 【Czlt-2011-12-26 软件正常关闭时修改配置信息,并关闭KJ128诊断软件】
                    //CzltSaveChkXml(true, false);                  
                    //#endregion

                    ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "关闭KJ128A矿用人员管理系统！");

                }
                // 终止定时打印线程
                //th.Abort();

                #region【关闭主界面程序】

                Process p = Process.GetCurrentProcess();
                p.Kill();

                #endregion
            }
        }

        #endregion

        #region [ 方法: 将所有菜单设置为可用 ]

        /// <summary>
        /// 将所有菜单设置为可用
        /// </summary>
        /// <param name="items"></param>
        private void SettingMenuTrue(ToolStripItemCollection items)
        {
            foreach (ToolStripItem tsi in items)
            {
                if (tsi is ToolStripMenuItem)
                {
                    tsi.Enabled = true;
                    if (((ToolStripMenuItem)tsi).DropDownItems.Count > 0)
                    {
                        SettingMenuTrue(((ToolStripMenuItem)tsi).DropDownItems);
                    }
                }
            }
        }

        #endregion

        #region【方法: 用户验证密码】


        private bool IsValidate()
        {
            if (blIsMemorize && !LoginBLL.user.Equals("guest"))
            {
                return true;
            }
            A_FrmValidate frm = new A_FrmValidate();
            frm.ShowDialog();

            if (!frm.IsValidate)
            {
                frm.Dispose();
                return false;
            }

            frm.Dispose();

            return true;
        }

        #endregion

        #region【方法：获取下井人数】

        private void GetInWellCount()
        {
            using (ds = new DataSet())
            {
                ds = mbll.GetInWellCount();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lb_InWellEmpCounts.Text = "当前井下共 " + ds.Tables[0].Rows[0][0].ToString() + " 人";
                    }
                }
            }
        }

        #endregion

        #region 默认权限菜单
        /// <summary>
        /// 权限管理
        /// </summary>
        /// <param name="bl">true 通过验证，false 未通过验证</param>
        private void Power(bool bl)
        {
            //菜单
            tsmiLogin.Enabled = !bl;
            tsmiExit.Enabled = bl;
            tsmiClose.Enabled = bl;
            tsmiConfiguration.Enabled = bl;

            //工具栏
            tsbtnLogin.Enabled = !bl;
            tsbtnExit.Enabled = bl;

            //假别
            tsmiHolidayClass.Enabled = bl;
            //请假
            tsmiHolidayManage.Enabled = bl;
            //实时补单、历史补单
            tsmiRealTimeAdd.Enabled = bl;
            tsmiAddHistoryAttendance.Enabled = bl;

            //系统配置
            tsmiSystemConfigurationTools.Enabled = bl;
            //备份还原
            tsmiBackupTools.Enabled = bl;
            //导入导出
            tsmiExcelTools.Enabled = bl;
            //选项
            tsmiOptionsTools.Enabled = bl;
            //定时打印设置
            tsmiPrint.Enabled = bl;
            //删除历史数据
            tsmideleteHisData.Enabled = bl;

            tsmiMonitoring.Enabled = bl;
            tsmiEnquiries.Enabled = bl;
            tsmiStatements.Enabled = bl;
            tsmiAttendance.Enabled = bl;
            tsmiTools.Enabled = bl;
            tsbtnReal.Enabled = bl;
            tsbtnHis.Enabled = bl;
            tsbtnGHis.Enabled = bl;
        }
        #endregion

        #region【方法：获取界面刷新时间】

        private void SetRefreshTime()
        {
            using (ds = new DataSet())
            {
                try
                {
                    ds = mbll.GetRefreshTime();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        RefReshTime._rtTime = Convert.ToInt32(ds.Tables[0].Rows[0]["EnumValue"]) * 1000;
                    }
                }
                catch
                {
                    RefReshTime._rtTime = 3000;
                }
            }
        }

        #endregion

        #region【方法：获取热备刷新间隔时间和刷新次数】

        private void SetHostBackRefresh()
        {
            using (ds = new DataSet())
            {
                try
                {
                    ds = mbll.GetHostBackRefresh();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] dr1 = ds.Tables[0].Select("EnumID = 1 ");
                        if (dr1.Length > 0)
                        {
                            RefReshTime.intHostBackRefTime = Convert.ToInt32(dr1[0]["EnumValue"].ToString());
                        }

                        DataRow[] dr2 = ds.Tables[0].Select("EnumID = 2");
                        if (dr2.Length > 0)
                        {
                            RefReshTime.intHostBackRefCount = Convert.ToInt32(dr2[0]["EnumValue"].ToString());
                        }
                    }
                }
                catch
                {
                    RefReshTime.intHostBackRefTime = 400;
                    RefReshTime.intHostBackRefCount = 2;
                }
            }
        }

        #endregion

        #region【方法：获取是否加载求救界面】

        private void LoadEmpHelp()
        {
            using (ds = new DataSet())
            {
                try
                {
                    ds = mbll.LoadEmpHelp();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
                        {
                            RefReshTime.blIsLoadEmpHelp = true;
                        }
                    }
                }
                catch
                {
                    RefReshTime.blIsLoadEmpHelp = false;
                }

            }
        }

        #endregion

        #region【事件：工具栏单击事件】

        //登录
        private void tsbtnLogin_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开登录菜单");

            A_FrmLogin frm = new A_FrmLogin(this);
            frm.ShowDialog();
            this.stsUsername.Text = "用户名:" + LoginBLL.user;
            this.stsLoginTime.Text = "登录时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //注销
        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开注销菜单");

            //***Czlt-2010-9-15-中试添加-退出提示*start*****/
            DialogResult result;
            result = MessageBox.Show("是否要注销系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginBLL.user = "来宾";
                //LoginBLL.user = "guest";
                SettingMenuTrue(msMainMenu.Items);
                Power(false);
                this.stsUsername.Text = "用户名:来宾";
                this.stsLoginTime.Text = "登录时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                CloseOtherFrom();
            }
            //***Czlt-2010-9-15-中试添加-退出提示*End*****/

        }

        #endregion

        private void CloseOtherFrom()
        {
            try
            {
                for (int i = dockPanel1.Contents.Count; i > 0; i--)
                {
                    if (!((Form)dockPanel1.Contents[i - 1]).Name.Equals("A_FrmRTAlarm"))
                    {
                        ((Form)dockPanel1.Contents[i - 1]).Close();
                    }
                }
            }
            catch { }
        }

        #region【事件：菜单单击事件】


        #region【系统】


        //登录
        private void tsmiLogin_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开登录菜单");

            A_FrmLogin frm = new A_FrmLogin(this);
            frm.ShowDialog();
            this.stsUsername.Text = "用户名:" + LoginBLL.user;
            this.stsLoginTime.Text = "登录时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        //退出
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开注销菜单");

            //***Czlt-2010-9-15-中试添加-退出提示*start*****/
            DialogResult result;
            result = MessageBox.Show("是否要注销系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginBLL.user = "guest";
                SettingMenuTrue(msMainMenu.Items);
                Power(false);
                this.stsUsername.Text = "用户名:来宾";
                this.stsLoginTime.Text = "登录时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                CloseOtherFrom();
            }
            //***Czlt-2010-9-15-中试添加-退出提示*End*****/
        }

        //关闭
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            A_FrmExit frme = new A_FrmExit();
            DialogResult dir = frme.ShowDialog();

            if (dir == DialogResult.Cancel)
            {
                //用户取消关闭系统      
                return;
            }
            else if (dir == DialogResult.OK)
            {
                //用户需要挂包通讯程序

                #region【关闭通讯程序】

                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Equals("KJ128A.Batman"))
                    {
                        try
                        {
                            process.Kill();
                            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "关闭KJ128A矿用人员管理系统，并关闭通讯程序！");
                        }
                        catch { }
                        // break;
                    }

                    ///Czlt-2010-9-29关闭其他外挂程序!
                    if (hashPlugins.ContainsValue(process.ProcessName))
                    {
                        process.Kill();
                        //Czlt-2010-9-29-添加声光报警器的日志
                        ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "关闭KJ128A矿用人员管理系统，并关闭" + process.ProcessName + "！");
                    }

                    //关闭Kj128保护程序
                    if (process.ProcessName.Equals("Kj128ChkHost"))
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch { }

                    }
                }

                #endregion

                //#region 【Czlt-2011-12-26 软件正常关闭时修改配置信息,并关闭KJ128诊断软件】
                //CzltSaveChkXml(true, true);
                //#endregion

                //Czlt-2010-9-29-注销
                // ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "关闭KJ128A矿用人员管理系统，并关闭通讯程序！");
            }
            else
            {
                #region 【Czlt-2011-12-26 软件正常关闭时修改配置信息,并关闭KJ128诊断软件】
                //CzltSaveChkXml(true, false);
                #endregion
                ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "关闭KJ128A矿用人员管理系统！");

            }

            // 终止定时打印线程
            //th.Abort();

            #region【关闭主界面程序】

            Process p = Process.GetCurrentProcess();
            p.Kill();

            #endregion
        }

        #endregion

        #region【配置】

        //员工
        private void tsmiEmpInfoConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmEmpInfo"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开员工菜单");

            A_FrmEmpInfo frmE = new A_FrmEmpInfo();
            frmE.Show(dockPanel1, DockState.Document);
        }

        //分站
        private void tsmiStationConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmStationInfo"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开分站菜单");

            A_FrmStationInfo frmE = new A_FrmStationInfo();
            frmE.Show(dockPanel1, DockState.Document);
        }

        //区域
        private void tsmiRegionalConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmAreaManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开区域配置菜单");

            A_FrmAreaManage frmE = new A_FrmAreaManage();
            frmE.Show(dockPanel1, DockState.Document);
        }

        //方向性
        private void tsmiDirectionConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmDirectionalManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开方向性菜单");

            A_FrmDirectionalManage frmD = new A_FrmDirectionalManage();
            frmD.Show(dockPanel1, DockState.Document);
        }

        //考勤
        private void tsmiAttendanceConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmAttendanceManger"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤菜单");

            AttendanceInfoSet.FrmAttendanceManger frmE = new AttendanceInfoSet.FrmAttendanceManger();
            frmE.Show(dockPanel1, DockState.Document);
        }

        //巡检
        private void tsmiInspectionConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmPathManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开巡检菜单");

            PathManage.FrmPathManage frmE = new PathManage.FrmPathManage();
            frmE.Show(dockPanel1, DockState.Document);
        }

        //设备
        private void tsmiDeviceConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_frmEquManager"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开设备配置菜单");

            KJ128NMainRun.EquManage.A_frmEquManager frmE = new KJ128NMainRun.EquManage.A_frmEquManager();
            frmE.Show(dockPanel1, DockState.Document);
        }

        //权限
        private void tsmiCompetenceConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_frmUser"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开权限菜单");

            KJ128NMainRun.admin.A_frmUser frmE = new KJ128NMainRun.admin.A_frmUser(this);
            frmE.Show(dockPanel1, DockState.Document);
        }

        //标识卡
        private void tsmiCodeSenderConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_frmCodeSender"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开标识卡配置菜单");

            KJ128NMainRun.SetCoder.A_frmCodeSender frmE = new KJ128NMainRun.SetCoder.A_frmCodeSender();
            frmE.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #region【监控】

        private void tsmiRegionalMonitoring_Click_1(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmRTTerritorial"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时区域菜单");

            KJ128NMainRun.A_RT_Territorial.A_FrmRTTerritorial frmrtt = new KJ128NMainRun.A_RT_Territorial.A_FrmRTTerritorial(dockPanel1);
            frmrtt.Show(dockPanel1, DockState.Document);
        }
        //标识卡
        private void tsmiCodeSenderMonitoring_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_frmRtCodeSender"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时标识卡菜单");

            KJ128NMainRun.SetCoder.A_frmRtCodeSender frmrtt = new KJ128NMainRun.SetCoder.A_frmRtCodeSender();
            frmrtt.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region[图形]
        private void tsmiGraphicMonitoring_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmDCfgRealTime"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开图形图层系统菜单");

            KJ128NMainRun.Graphics.DPic.A_FrmDCfgRealTime frmE = new KJ128NMainRun.Graphics.DPic.A_FrmDCfgRealTime();
            frmE.Show(dockPanel1, DockState.Document);
        }
        private void tsmiGraphicConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmDCreateConfig"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开图形图层配置菜单");

            //KJ128NMainRun.Graphics.DPic.A_FrmDCreateConfig frmE = new KJ128NMainRun.Graphics.DPic.A_FrmDCreateConfig(dockPanel1);
            KJ128NMainRun.Graphics.Expert.A_FrmDCreateConfig frmE = new KJ128NMainRun.Graphics.Expert.A_FrmDCreateConfig(dockPanel1);
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region [假别设置]
        private void tsmiHolidayClass_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_NewHolidayMange"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开假别设置菜单");

            AttendanceInfoSet.A_NewHolidayMange frmE = new AttendanceInfoSet.A_NewHolidayMange();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region【查询】

        //历史报警
        private void tsmiHisAlarmEnquiries_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmHisAlarm"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史报警菜单");

            KJ128NMainRun.A_HisAlarm.A_FrmHisAlarm frmHA = new KJ128NMainRun.A_HisAlarm.A_FrmHisAlarm();
            frmHA.Show(dockPanel1, DockState.Document);
        }

        //天线
        private void tsmiAntennaMonitoring_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_frmRealAntanne"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开天线监测菜单");

            KJ128NMainRun.A_Antenna.A_frmRealAntanne frmHA = new KJ128NMainRun.A_Antenna.A_frmRealAntanne();
            frmHA.Show(dockPanel1, DockState.Document);
        }


        //历史区域
        private void tsmiRegionalEnquiries_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmHisTerritorial"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开区域查询菜单");

            KJ128NMainRun.A_His_Territorial.A_FrmHisTerritorial frmHt = new KJ128NMainRun.A_His_Territorial.A_FrmHisTerritorial();
            frmHt.Show(dockPanel1, DockState.Document);
        }

        //下井次数
        private void tsmiInWellCountsEnquiries_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmHisInWellCounts"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开下井次数查询菜单");

            KJ128NMainRun.A_His_InWellCounts.A_FrmHisInWellCounts frmHt = new KJ128NMainRun.A_His_InWellCounts.A_FrmHisInWellCounts();
            frmHt.Show(dockPanel1, DockState.Document);
        }
        //历史天线
        private void tsmiAntennaEnquiries_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_frmHisAntenna"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开天线查询菜单");

            KJ128NMainRun.A_Antenna.A_frmHisAntenna frmHt = new KJ128NMainRun.A_Antenna.A_frmHisAntenna();
            frmHt.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region 人员考勤明细
        private void tsmiAttendanceParticulars_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceParticulars"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开人员考勤明细菜单");

            KJ128NInterfaceShow.AttendanceParticulars frmE = new AttendanceParticulars();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region【工具】

        //选项
        private void tsmiOptionsTools_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开选项菜单");

            A_FrmToolOptions frmto = new A_FrmToolOptions(this);
            frmto.ShowDialog();
        }

        #endregion

        #endregion

        #region 考勤统计
        private void tsmiAttendanceStatistics_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_AttendacePersonelStatistic"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤统计菜单");
            //KJ128NInterfaceShow.AttendacePersonelStatistic frmE = new AttendacePersonelStatistic();
            //frmE.Show(dockPanel1, DockState.Document);
            KJ128NMainRun.A_Attendance.A_AttendacePersonelStatistic frmE = new KJ128NMainRun.A_Attendance.A_AttendacePersonelStatistic();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region 考勤原始数据
        private void tsmiAttendanceInitialData_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceInitialData"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤原始数据菜单");

            KJ128NInterfaceShow.AttendanceInitialData frmE = new AttendanceInitialData();
            frmE.Show(dockPanel1, DockState.Document);
        }

        #endregion
        #region 部门逐日考勤
        private void tsmiAttendanceDayByDayStatistic_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_AttendanceDayByDayStatistic"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门逐日考勤菜单");

            KJ128NMainRun.A_Attendance.A_AttendanceDayByDayStatistic frmE = new KJ128NMainRun.A_Attendance.A_AttendanceDayByDayStatistic();
            frmE.Show(dockPanel1, DockState.Document);
        }

        #endregion
        #region 部门出勤率统计
        private void tsmiAttendanceDeptEmpStatistics_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceRateStatistic"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开部门出勤率统计菜单");

            KJ128NInterfaceShow.AttendanceRateStatistic frmE = new AttendanceRateStatistic();
            frmE.Show(dockPanel1, DockState.Document);
        }

        #endregion
        #region 干部下井考勤
        private void tsmiDeptCadresInMineStatistics_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceStatisticByDuty"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开干部下井考勤菜单");

            KJ128NInterfaceShow.AttendanceStatisticByDuty frmE = new AttendanceStatisticByDuty();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region 实时补单
        private void tsmiRealTimeAdd_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_AttendanceRealTime"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时补单菜单");

            KJ128NMainRun.A_Attendance.A_AttendanceRealTime frmE = new KJ128NMainRun.A_Attendance.A_AttendanceRealTime();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region 历史补单
        private void tsmiAddHistoryAttendance_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_AddHistoryAttendance"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史补单菜单");

            KJ128NMainRun.A_Attendance.A_AddHistoryAttendance frmE = new KJ128NMainRun.A_Attendance.A_AddHistoryAttendance();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        //实时下井人员
        private void tsmiInMineEmpMonitoring_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealInWell"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时下井人员菜单");

            A_RealInWell.FrmRealInWell frmE = new A_RealInWell.FrmRealInWell(dockPanel1);
            frmE.Show(dockPanel1, DockState.Document);
        }

        #region 实时巡检
        private void tsmiInspectionMonitoring_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_RT_PathCheck"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开巡检监控菜单");

            KJ128NMainRun.A_RT_PathCheck.A_RT_PathCheck frmE = new KJ128NMainRun.A_RT_PathCheck.A_RT_PathCheck();
            //KJ128NMainRun.RealTime.RealTimePathCheck.FrmRealTimePathCheck_new frmE = new KJ128NMainRun.RealTime.RealTimePathCheck.FrmRealTimePathCheck_new();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region 历史巡检
        private void tsmiInspectionEnquiries_Click(object sender, EventArgs e)
        {

            if (Searcher.FindFormByName("Form_HistoryInspection"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开巡检查询菜单");

            KJ128NMainRun.HistoryInfo.HistoryInspection.Form_HistoryInspection frmE = new KJ128NMainRun.HistoryInfo.HistoryInspection.Form_HistoryInspection();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        //历史下井人员
        private void tsmiInMineEmpEnquiries_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisInWell"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开下井人员查询菜单");

            A_RealInWell.FrmHisInWell frmE = new A_RealInWell.FrmHisInWell();
            frmE.Show(dockPanel1, DockState.Document);
        }
        //热备系统配置信息
        private void tsmiSystemConfigurationTools_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\KJ128AConfig.exe";

            if (Searcher.FindProcessByName("KJ128AConfig"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开热备系统配置菜单");

            // 数据库备份和还原
            //KJ128NMainRun.DataOperate.FrmDataManage frm = new KJ128NMainRun.DataOperate.FrmDataManage();
            //frm.Show(dockPanel1, DockState.Document);

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("热备配置工具不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //系统运行日志查看
        private void tsmiLogViewTools_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\KJ128ALogView.exe";

            if (Searcher.FindProcessByName("KJ128ALogView"))
            {
                return;
            }


            ////验证用户密码
            //if (!IsValidate())
            //{
            //    return;
            //}
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开系统运行日志菜单");

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("系统日志查看程序不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //KJ128A系统备份与还原
        private void tsmiBackupTools_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\备份\beifen.exe";

            if (Searcher.FindProcessByName("beifen"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开KJ128A系统备份与还原菜单");


            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("系统备份与还原工具不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //数据库导入、导出Excel
        private void tsmiExcelTools_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\导入导出\InfomationIO.exe";

           // if (Searcher.FindProcessByName("daochu"))
            if (Searcher.FindProcessByName("InfomationIO"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开数据库导入、导出Excel菜单");

            if (File.Exists(path))
            {
                
                 Process.Start(path);
            }
            else
            {
                MessageBox.Show("数据库导入、导出Excel工具不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        //日下井行进路线
        private void tsmiInMineLine_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmInMineDayReport"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开日下井行进路线菜单");

            FrmInMineDayReport frmE = new FrmInMineDayReport();
            frmE.Show(dockPanel1, DockState.Document);
        }
        //月下井次数
        private void tsmiInMineCounts_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_Month_Down_Mine_Count"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开月下井次数菜单");

            A_Report_Forms.A_Month_Down_Mine_Count frmE = new KJ128NMainRun.A_Report_Forms.A_Month_Down_Mine_Count();
            frmE.Show(dockPanel1, DockState.Document);
        }

        //请假管理
        private void tsmiHolidayManage_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("NewHolidayTypeSet"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开请假管理菜单");

            AttendanceInfoSet.NewHolidayTypeSet frmE = new AttendanceInfoSet.NewHolidayTypeSet();
            frmE.Show(dockPanel1, DockState.Document);
        }


        //考勤明细
        private void tsmiAttendanceParticulars_Click_1(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("AttendanceParticulars"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤明细菜单");

            KJ128NInterfaceShow.AttendanceParticulars frmE = new AttendanceParticulars();
            frmE.Show(dockPanel1, DockState.Document);
        }
        //历史读卡分站
        private void tsmiStationHeadEnquiries_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmHisStationHead"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开读卡分站查询菜单");

            //A_His_Station_Data.A_His_Station_data frmE = new KJ128NMainRun.A_His_Station_Data.A_His_Station_data();
            //frmE.Show(dockPanel1, DockState.Document);
            A_FrmHisStationHead frmS = new A_FrmHisStationHead();
            frmS.Show(dockPanel1, DockState.Document);
        }
        //实时读卡分站
        private void tsmiStationHeadMonitoring_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmRTStationHead"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开读卡分站监控菜单");

            A_FrmRTStationHead frmE = new A_FrmRTStationHead(dockPanel1);
            frmE.Show(dockPanel1, DockState.Document);
        }
        //下井人员名单
        private void tsmiInMineEmployee_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInMineEmp"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开下井人员监控菜单");

            RealTime.FrmRealTimeInMineEmp frmE = new FrmRealTimeInMineEmp(dockPanel1);
            frmE.Show(dockPanel1, DockState.Document);
        }

        #region
        private void tsbtnHis_Click(object sender, EventArgs e)
        {
            tsmiStationHeadMonitoring_Click(this, new EventArgs());
        }

        private void tsbtnGHis_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmDCfgRealTime"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开图形图层系统菜单");

            KJ128NMainRun.Graphics.DPic.A_FrmDCfgRealTime frmE = new KJ128NMainRun.Graphics.DPic.A_FrmDCfgRealTime(3);
            frmE.Show(dockPanel1, DockState.Document);
        }

        private void tsbtnReal_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInMineEmp"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时下井人员名单菜单");

            RealTime.FrmRealTimeInMineEmp frmE = new FrmRealTimeInMineEmp(dockPanel1);
            frmE.Show(dockPanel1, DockState.Document);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

            KJ128NMainRun.A_Antenna.Form1 f = new KJ128NMainRun.A_Antenna.Form1();
            f.Show();
        }


        #region【事件：定时刷新】

        private void timer_Alarm_Tick(object sender, EventArgs e)
        {
            try
            {
                GetInWellCount();
                if (AlarmFrm != null && AlarmFrm.BlIsAlarm)
                {
                    stsAlarm.ForeColor = Color.Red;
                    stsAlarm.Text = "报警显示:报警";
                    timeShow.Enabled = true;
                }
                else
                {
                    stsAlarm.ForeColor = Color.Black;
                    stsAlarm.Text = "报警显示:无报警";
                    timeShow.Enabled = false;
                }

                #region【Czlt-2014-05-06 判断有没有注册】


                #endregion
            }
            catch { }
        }

        #endregion


        #region [方法: 判断是否是环网]

        private bool IsRingNetwork()
        {
            try
            {
                string path = Application.StartupPath + @"\CommType.xml";

                if (File.Exists(path))
                {

                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);

                    XmlNode node = doc.ChildNodes[1].SelectSingleNode("commType");

                    if (node != null)
                    {
                        if (node.InnerText.Equals("1"))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 【环网配置】
        private void tsmiTcpConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("Frm_Ip_add_new1"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开环网配置菜单");

            IpConfig.Frm_Ip_add_new1 frmE = new IpConfig.Frm_Ip_add_new1();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        //行走异常
        private void tsmiWalkConfig_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmWalkConfig"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开行走异常配置菜单");

            KJ128NMainRun.A_Speed.A_FrmWalkConfig frmS = new KJ128NMainRun.A_Speed.A_FrmWalkConfig();
            frmS.Show(dockPanel1, DockState.Document);
        }

        #region 【异地交接班配置】
        private void tsmiAssociate_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmAssociateManage"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开异地交接班配置菜单");

            KJ128NMainRun.AssociateWithEmp.FrmAssociateManage frmS = new KJ128NMainRun.AssociateWithEmp.FrmAssociateManage();
            frmS.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region 【历史异地交接班信息】
        private void tsmiHistroryAssociate_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmHisAssociateInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开历史异地交接班信息");

            KJ128NMainRun.AssociateWithEmp.FrmHisAssociateInfo frmS = new KJ128NMainRun.AssociateWithEmp.FrmHisAssociateInfo();
            frmS.Show(dockPanel1, DockState.Document);
        }
        #endregion

        private void A_FrmMain_SizeChanged(object sender, EventArgs e)
        {
            int width = this.stsMes.Width / 5;
            for (int i = 0; i < this.stsMes.Items.Count; i++)
            {
                this.stsMes.Items[i].Width = width - 5;
            }
        }
        //关于
        #region 关于
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAboutUs frm = new FrmAboutUs();
            frm.ShowDialog();
        }
        #endregion

        //下井人员统计
        private void tsmiEmpInWell_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmEmpInWellStatement"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开下井人员统计菜单");

            A_FrmEmpInWellStatement frmE = new A_FrmEmpInWellStatement();
            frmE.Show(dockPanel1, DockState.Document);
        }

        private void tsmiLeadershipStatistics_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmLeadMonthStatement"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开领导每月下井统计菜单");

            A_FrmLeadMonthStatement frmE = new A_FrmLeadMonthStatement();
            frmE.Show(dockPanel1, DockState.Document);
        }

        //重点区域人员统计
        private void tsmiKeyAreaEmpStatistics_Click_1(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmKeyAreaEmpStatement"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开重点区域人员统计菜单");

            A_FrmKeyAreaEmpStatement frmK = new A_FrmKeyAreaEmpStatement();
            frmK.Show(dockPanel1, DockState.Document);
        }

        //当前下井人数——点击事件
        private void lb_InWellEmpCounts_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeInMineEmp"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时下井人员名单菜单");

            RealTime.FrmRealTimeInMineEmp frmE = new FrmRealTimeInMineEmp(dockPanel1);
            frmE.Show(dockPanel1, DockState.Document);
        }

        //限制区域报警人员统计
        private void tsmiConfineAreaEmpStatistics_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmConfineAreaStatement"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开限制区域报警人员统计菜单");

            A_FrmConfineAreaStatement frmK = new A_FrmConfineAreaStatement();
            frmK.Show(dockPanel1, DockState.Document);
        }

        //超时报警人员统计
        private void tsmiOverTimeEmpStatistics_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmOverTimeEmpStatement"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开超时报警人员统计菜单");

            A_FrmOverTimeEmpStatement frmO = new A_FrmOverTimeEmpStatement();
            frmO.Show(dockPanel1, DockState.Document);
        }

        //特殊作业工作异常统计
        private void tsmiPathStatistics_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmWorkExceptionStatement"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开特殊人员报警统计菜单");

            A_FrmWorkExceptionStatement frm = new A_FrmWorkExceptionStatement();
            frm.Show(dockPanel1, DockState.Document);
        }

        //定时打印设置
        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            A_FrmPrint frmP = new A_FrmPrint();
            frmP.ShowDialog();
        }

        #region【方法：判断当前时间是否与打印时间相等】

        /// <summary>
        /// 判断当前时间是否与打印时间相等
        /// </summary>
        /// <returns>true：打印；False：不打印</returns>
        private bool IsPrint(DateTime dtTime)
        {
            try
            {
                string strPrintTime = "";
                using (ds = new DataSet())
                {
                    ds = pbll.GetPrintTime();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        strPrintTime = ds.Tables[0].Rows[0][0].ToString();
                        if (strPrintTime.Equals(dtTime.ToString("HH:mm")))
                        {
                            return true;
                        }
                    }
                }

            }
            catch { }
            return false;
        }

        #endregion

        #region【方法：判断是否打印领导月下井信息】

        /// <summary>
        /// 判断是否打印领导月下井信息
        /// </summary>
        /// <returns>true：打印；False：不打印</returns>
        private bool IsPrintLeadershipInWell(DateTime dtTime)
        {
            try
            {
                string strPrintTime = "";
                using (ds = new DataSet())
                {
                    ds = pbll.GetPrintTime_Leadership();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        strPrintTime = ds.Tables[0].Rows[0][0].ToString();
                        if (strPrintTime.Equals(dtTime.ToString("dd:HH:mm")))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch { }
            return false;
        }

        #endregion

        #region【方法：定时打印】

        private void PrintInfo()
        {
            try
            {
                using (ds = new DataSet())
                {
                    A_StatementBLL stbll = new A_StatementBLL();
                    DataSet dsPrint;

                    ds = pbll.GetPrint();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];

                        #region【打印下井人员统计】

                        if (dt.Select("EnumID=1")[0]["EnumValue"].ToString() == "1")
                        {
                            using (dsPrint = new DataSet())
                            {
                                dsPrint = stbll.Get_EmpInWellStatement(DateTime.Now.Date.AddDays(-1).ToString("yyyy-MM-dd"));
                                if (dsPrint != null && dsPrint.Tables.Count > 0)
                                {
                                    DataGridView dgvRTInfo = new DataGridView();
                                    dgvRTInfo.DataSource = dsPrint.Tables[0];

                                    Bind(dgvRTInfo, dsPrint.Tables[0]);

                                    AutoPrint(dgvRTInfo, "下井人员总数及人员", "下井人员总数：" + dsPrint.Tables[0].Rows.Count + " 人");
                                }
                            }
                        }

                        #endregion

                        #region【打印重点区域人员统计】

                        if (dt.Select("EnumID=2")[0]["EnumValue"].ToString() == "1")
                        {
                            using (dsPrint = new DataSet())
                            {
                                dsPrint = stbll.Get_KeyAreaStatement(DateTime.Now.Date.AddDays(-1).ToString("yyyy-MM-dd"));
                                if (dsPrint != null && dsPrint.Tables.Count > 0)
                                {
                                    DataGridView dgvKyeArea = new DataGridView();
                                    dgvKyeArea.DataSource = dsPrint.Tables[0];

                                    Bind(dgvKyeArea, dsPrint.Tables[0]);

                                    AutoPrint(dgvKyeArea, "重点区域人员总数及人员", "重点区域人员总数：" + dsPrint.Tables[0].Rows.Count + " 人");
                                }
                            }
                        }

                        #endregion

                        #region【打印超时报警人员统计】

                        if (dt.Select("EnumID=3")[0]["EnumValue"].ToString() == "1")
                        {
                            using (dsPrint = new DataSet())
                            {
                                dsPrint = stbll.Get_OverTimeEmpStatement(DateTime.Now.Date.AddDays(-1).ToString("yyyy-MM-dd"));
                                if (dsPrint != null && dsPrint.Tables.Count > 0)
                                {
                                    DataGridView dgvOverTime = new DataGridView();
                                    dgvOverTime.DataSource = dsPrint.Tables[0];

                                    Bind(dgvOverTime, dsPrint.Tables[0]);

                                    AutoPrint(dgvOverTime, "超时报警人员总数及人员", "超时报警人员总数：" + dsPrint.Tables[0].Rows.Count + " 人");
                                }
                            }
                        }

                        #endregion

                        #region【打印限制区域报警人员统计】

                        if (dt.Select("EnumID=5")[0]["EnumValue"].ToString() == "1")
                        {
                            using (dsPrint = new DataSet())
                            {
                                dsPrint = stbll.Get_ConfineAreaStatement(DateTime.Now.Date.AddDays(-1).ToString("yyyy-MM-dd"));
                                if (dsPrint != null && dsPrint.Tables.Count > 0)
                                {
                                    DataGridView dgvConfineArea = new DataGridView();
                                    dgvConfineArea.DataSource = dsPrint.Tables[0];

                                    Bind(dgvConfineArea, dsPrint.Tables[0]);

                                    AutoPrint(dgvConfineArea, "限制区域报警人员总数及人员", "报警人员总数：" + dsPrint.Tables[0].Rows.Count + " 人");
                                }
                            }
                        }

                        #endregion

                        #region【打印工作异常报警人员统计】

                        if (dt.Select("EnumID=6")[0]["EnumValue"].ToString() == "1")
                        {
                            A_WorkExceptionStatementBLL webll = new A_WorkExceptionStatementBLL();
                            using (dsPrint = new DataSet())
                            {
                                dsPrint = webll.SelectWorkExceptionStatementInfo(DateTime.Now.Date.AddDays(-1));
                                if (dsPrint != null && dsPrint.Tables.Count > 0)
                                {
                                    DataGridView dgvWorkEx = new DataGridView();
                                    dgvWorkEx.DataSource = dsPrint.Tables[0];

                                    Bind(dgvWorkEx, dsPrint.Tables[0]);

                                    AutoPrint(dgvWorkEx, "特殊作业人员工作异常报警总数及人员", "报警人员总数：" + dsPrint.Tables[0].Rows.Count + " 人");
                                }
                            }
                        }

                        #endregion
                    }
                }

            }
            catch { }
        }

        //绑定DataGridView
        private void Bind(DataGridView dgv, DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                DataGridViewColumn c = new DataGridViewColumn();
                c.DataPropertyName = col.ColumnName;
                //c.Name = col.ColumnName;
                c.HeaderText = col.ColumnName;
                dgv.Columns.Add(c);
            }
        }

        //自动打印
        private void AutoPrint(DataGridView dgv, string title, string strSum)
        {
            //FormPrint print1 = new FormPrint();
            //print1.CallPrintForm(dgv, title, strSum, true);
            PrintBLL.Print(dgv, title, "AutoPrint");
        }

        #endregion

        #region【事件：定时打印】

        private void timer_Print_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dtTime = DateTime.Now;

                if (IsPrint(dtTime))            //判断是否打印（下井人员、重点区域、限制区域、超时、工作异常）
                {
                    PrintInfo();
                }

                if (IsPrintLeadershipInWell(dtTime))      //判断是否打印（领导月下井信息）
                {
                    DataSet dsPrint;
                    using (dsPrint = new DataSet())
                    {
                        A_LeadMonthStatementBLL lmbll = new A_LeadMonthStatementBLL();
                        dsPrint = lmbll.SelectLeadMonthStatementInfo(DateTime.Now.Date.AddDays(-1));
                        if (dsPrint != null && dsPrint.Tables.Count > 0)
                        {
                            DataGridView dgvLead = new DataGridView();
                            dgvLead.DataSource = dsPrint.Tables[0];

                            Bind(dgvLead, dsPrint.Tables[0]);

                            AutoPrint(dgvLead, "领导干部每月下井统计", "干部下井总数：" + dsPrint.Tables[0].Rows.Count + " 人");
                        }
                    }
                }

            }
            catch { }
        }

        #endregion

        private void tsmiStationConfigInfo_Click(object sender, EventArgs e)
        {
            //A_FrmStationConfigInfo
            if (Searcher.FindFormByName("A_FrmStationConfigInfo"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开实时分站状态菜单");

            A_FrmStationConfigInfo frm = new A_FrmStationConfigInfo(dockPanel1);
            frm.Show(dockPanel1, DockState.Document);
        }

        private void tsmiAlertOption_Click(object sender, EventArgs e)
        {
            ////A_FrmStationConfigInfo
            //if (Searcher.FindFormByName("A_FrmOption"))
            //{
            //    return;
            //}

            //ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开报警选项菜单");

            //A_FrmOption frm = new A_FrmOption();
            //frm.Show(dockPanel1, DockState.Document);
            //frm.Show();
        }

        private void tsmideleteHisData_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\HistoryDataDelete.exe";

            if (Searcher.FindProcessByName("HistoryDataDelete"))
            {
                return;
            }

            //验证用户密码
            if (!IsValidate())
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开删除历史数据工具菜单");

            // 数据库备份和还原
            //KJ128NMainRun.DataOperate.FrmDataManage frm = new KJ128NMainRun.DataOperate.FrmDataManage();
            //frm.Show(dockPanel1, DockState.Document);

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("删除历史数据工具不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsmiHelpDocuments_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\help\KJ128帮助系统.CHM";

            if (Searcher.FindProcessByName("hh"))
            {
                MessageBox.Show("您已打开帮助文档！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "帮助文档不存在");

            // 数据库备份和还原
            //KJ128NMainRun.DataOperate.FrmDataManage frm = new KJ128NMainRun.DataOperate.FrmDataManage();
            //frm.Show(dockPanel1, DockState.Document);

            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("帮助文档不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void stsAlarm_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmRTAlarm"))
            {
                return;
            }
        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void tsmiOuterProject_Click(object sender, EventArgs e)
        {
            FrmOuterProject frmOuterProject = new FrmOuterProject();
            frmOuterProject.ShowDialog(this);
        }

        #region [人员显示信息]
        private void tsmiEmployeeInfo_Select_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmEmployeeInfo_Select"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开人员信息菜单");

            FrmEmployeeInfo_Select frm = new FrmEmployeeInfo_Select();
            frm.Show(dockPanel1, DockState.Document);
        }
        #endregion
        #endregion

        private void 现升井人员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("FrmRealTimeOutMineEmp"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开现升井人员菜单");

            FrmRealTimeOutMineEmp frmE = new FrmRealTimeOutMineEmp();
            frmE.Show(dockPanel1, DockState.Document);
        }

        #region【Czlt-2010-10-19-考勤部门统计】
        private void tsmiDeptAttendanceStatistics_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_AttendaceDeptStatistic"))
            {
                return;
            }
            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开考勤统计菜单");

            KJ128NMainRun.A_Attendance.A_AttendaceDeptStatistic frmE = new KJ128NMainRun.A_Attendance.A_AttendaceDeptStatistic();
            frmE.Show(dockPanel1, DockState.Document);
        }
        #endregion

        #region【Czlt-2010-12-23-领导干部日下井统计】
        private void tsmiLeaderDayStatistics_Click(object sender, EventArgs e)
        {
            if (Searcher.FindFormByName("A_FrmLeadDayStatement"))
            {
                return;
            }

            ILogger.Write(EnumLogType.OperateLog, strLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, "打开领导每日下井统计菜单");

            A_FrmLeadDayStatement frmE = new A_FrmLeadDayStatement();
            frmE.Show(dockPanel1, DockState.Document);

        }
        #endregion

        #region【Czlt-2011-01-20 报警闪烁】
        private void timeShow_Tick(object sender, EventArgs e)
        {
            if (isShow)
            {
                stsAlarm.Visible = true;
                isShow = false;
            }
            else
            {
                stsAlarm.Visible = false;
                isShow = true;
            }
        }
        #endregion


        #region【qyz 自动补单，同步实时数据】
        //qyz 同步实时标示卡信息和实时下井人员信息
        private void timer_Clear_Tick(object sender, EventArgs e)
        {
            AutoCompleteCode();
        }
        //qyz 自动补单
        private void AutoCompleteCode()
        {
            try
            {
                if (!File.Exists(Application.StartupPath.ToString() + "\\AutoComplete.xml"))
                {
                    FileStream fs = new FileStream(Application.StartupPath.ToString() + "\\AutoComplete.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<AutoComplete>");
                    sw.WriteLine("<IsUse>false</IsUse>");
                    sw.WriteLine("<hours>24</hours>");
                    sw.WriteLine("</AutoComplete>");
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }

                mbll.RepareAttendanceInfo();//修复考勤
                mbll.ClearRtInfo();//同步实时数据



                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath.ToString() + "\\AutoComplete.xml");
                string hours = doc.SelectSingleNode("AutoComplete/hours").InnerText.ToString();
                bool isuse = Convert.ToBoolean(doc.SelectSingleNode("AutoComplete/IsUse").InnerText);
                if (isuse)//判断是否开启
                {
                    //实时井下分站8小时内无信息及入井超过15小时
                    DataTable dt = mbll.AutoCodeComplete(hours);//自动补单
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataTable dts = mbll.Get_UpStation();
                        if (dts != null && dts.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                //判断电量状态
                                int state = mbll.GetCodeState(dr[0].ToString());
                                //自动补单出井
                                if (dsave.SaveCodeSenderInfo(Convert.ToInt32(dts.Rows[0][0]), Convert.ToInt32(dts.Rows[0][1]), state, 0, DateTime.Now, dr[0].ToString(), true))
                                {
                                    dsave.SaveCodeSenderInfo(Convert.ToInt32(dts.Rows[0][0]), Convert.ToInt32(dts.Rows[0][1]), state, 1, DateTime.Now.AddSeconds(16), dr[0].ToString(), true);
                                    LogSave.Messages("[自动补单]", LogIDType.UserLogID, "自动补单：发码器编号：" + dr[0].ToString() + "，下班时间为：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "。");
                                }
                            }
                        }
                    }
                }
            }
            catch
            { }
        }
        #endregion

        //#region
        ///// <summary>
        ///// Czlt-2011-12-26 对是不是正常关闭程序的状态做修改
        ///// </summary>
        //private void CzltSaveChkXml(bool isChk, bool isHost)
        //{

        //    if (File.Exists(Application.StartupPath + "\\ChkType.Xml"))
        //    {
        //        XmlDocument dom = new XmlDocument();
        //        dom.Load(Application.StartupPath + @"\" + "ChkType.Xml");

        //        XmlNode xnHostType = dom.SelectSingleNode("//TypeHost//IsType");
        //        xnHostType.InnerText = isChk.ToString();
        //        if (isChk == false)
        //        {
        //            XmlNode xnHostTime = dom.SelectSingleNode("//TypeHost//CloseTime");
        //            xnHostTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        //            XmlNode xnHostSumNum = dom.SelectSingleNode("//TypeHost//SumNum");
        //            xnHostSumNum.InnerText = (Convert.ToInt32(xnHostSumNum.InnerText) + 1).ToString();

        //        }

        //        //关闭主通讯程序的时候 isHost == true
        //        if (isHost)
        //        {
        //            XmlNode xnSignalType = dom.SelectSingleNode("//TypeSignal//IsType");
        //            xnSignalType.InnerText = isChk.ToString();

        //            if (isChk == false)
        //            {
        //                XmlNode xnSignalTime = dom.SelectSingleNode("//TypeSignal//CloseTime");
        //                xnSignalTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        //                XmlNode xnSignalSumNum = dom.SelectSingleNode("//TypeSignal//SumNum");
        //                xnSignalSumNum.InnerText = (Convert.ToInt64(xnSignalSumNum.InnerText) + 1).ToString();
        //            }

        //        }

        //        dom.Save(Application.StartupPath.ToString() + "\\ChkType.xml");
        //    }


        //}
        //#endregion


        #region Czlt-2011-12-26 对是不是正常关闭程序的状态做修改
        /// <summary>
        /// Czlt-2011-12-26 对是不是正常关闭程序的状态做修改
        /// </summary>
        private void CzltSaveChkXml(bool isChk, bool isHost)
        {

            if (File.Exists(Application.StartupPath + "\\ChkType.Xml"))
            {
                string czltIsAdd = "";
                XmlDocument dom = new XmlDocument();
                dom.Load(Application.StartupPath + @"\" + "ChkType.Xml");

                XmlNode xnHostType = dom.SelectSingleNode("//TypeHost//IsType");
                czltIsAdd = xnHostType.InnerText.ToString();
                xnHostType.InnerText = isChk.ToString();
                if (isChk == false)
                {
                    XmlNode xnHostTime = dom.SelectSingleNode("//TypeHost//CloseTime");
                    xnHostTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    if (czltIsAdd.Trim().ToLower().Equals("false"))
                    {
                        XmlNode xnHostSumNum = dom.SelectSingleNode("//TypeHost//SumNum");
                        xnHostSumNum.InnerText = (Convert.ToInt32(xnHostSumNum.InnerText) + 1).ToString();
                    }

                }

                //关闭主通讯程序的时候 isHost == true
                if (isHost)
                {
                    XmlNode xnSignalType = dom.SelectSingleNode("//TypeSignal//IsType");
                    czltIsAdd = xnSignalType.InnerText.ToString();
                    xnSignalType.InnerText = isChk.ToString();

                    if (isChk == false)
                    {
                        XmlNode xnSignalTime = dom.SelectSingleNode("//TypeSignal//CloseTime");
                        xnSignalTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        if (czltIsAdd.Trim().ToLower().Equals("false"))
                        {
                            XmlNode xnSignalSumNum = dom.SelectSingleNode("//TypeSignal//SumNum");
                            xnSignalSumNum.InnerText = (Convert.ToInt64(xnSignalSumNum.InnerText) + 1).ToString();
                        }
                    }

                }

                dom.Save(Application.StartupPath.ToString() + "\\ChkType.xml");
            }


        }
        #endregion


        #region【Czlt-2012-02-26 重写通讯分站信息】
        /// <summary>
        /// 重写通讯分站信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public bool ReplaceStationXml(DataTable dt, string strPath)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\SerialPort.xml");
                XmlNode markrootnode = xml.SelectSingleNode("DocumentElement");
                int commType = 0;
                int tcpMark = 0;
                XmlDocument xmlcomm = new XmlDocument();
                if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\CommType.xml"))
                {
                    xmlcomm.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\CommType.xml");
                    try
                    {
                        XmlNode xmlnodeComm = xmlcomm.SelectSingleNode("/comm/commType");
                        if (xmlnodeComm != null)
                        {
                            commType = int.Parse(xmlnodeComm.InnerText);
                        }
                    }
                    catch
                    {
                    }
                    if (commType != 0)
                    {
                        try
                        {
                            XmlNode xmlnodeTcpMark = xmlcomm.SelectSingleNode("/comm/TcpMark");
                            if (xmlnodeTcpMark != null)
                            {
                                tcpMark = int.Parse(xmlnodeTcpMark.InnerText);
                            }
                        }
                        catch { }
                    }
                }

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(strPath);
                XmlNode rootnode = xmldoc.SelectSingleNode("DocumentElement");
                rootnode.RemoveAll();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < markrootnode.ChildNodes.Count; j++)
                        {
                            if (commType == 0)
                            {
                                XmlNode Groupnode = xmldoc.CreateElement("Group");
                                if (markrootnode.ChildNodes[j].ChildNodes[2].InnerText.Equals(dt.Rows[i]["StationGroup"].ToString()))
                                {
                                    Groupnode.InnerText = dt.Rows[i]["StationGroup"].ToString();
                                    XmlNode node = xmldoc.CreateElement("Station");
                                    XmlNode idnode = xmldoc.CreateElement("ID");
                                    idnode.InnerText = dt.Rows[i]["ID"].ToString();
                                    XmlNode addressnode = xmldoc.CreateElement("Address");
                                    addressnode.InnerText = dt.Rows[i]["Address"].ToString();

                                    XmlNode statenode = xmldoc.CreateElement("State");
                                    statenode.InnerText = "0";
                                    XmlNode marknode = xmldoc.CreateElement("Mark");

                                    marknode.InnerText = markrootnode.ChildNodes[j].ChildNodes[3].InnerText;

                                    XmlNode isenablenode = xmldoc.CreateElement("Ver");
                                    isenablenode.InnerText = dt.Rows[i]["Ver"].ToString();
                                    XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                                    ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                                    XmlNode ipPort = xmldoc.CreateElement("IpPort");
                                    ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                                    XmlNode stationModelNode = xmldoc.CreateElement("StationModel");
                                    stationModelNode.InnerText = dt.Rows[i]["StationModel"].ToString();
                                    node.AppendChild(idnode);
                                    node.AppendChild(addressnode);
                                    node.AppendChild(Groupnode);
                                    node.AppendChild(statenode);
                                    node.AppendChild(marknode);
                                    node.AppendChild(isenablenode);
                                    node.AppendChild(ipaddressNode);
                                    node.AppendChild(ipPort);
                                    node.AppendChild(stationModelNode);
                                    rootnode.AppendChild(node);
                                }
                            }
                            else
                            {
                                XmlNode Groupnode = xmldoc.CreateElement("Group");
                                if (markrootnode.ChildNodes[j].ChildNodes[2].InnerText.Equals(dt.Rows[i]["StationGroup"].ToString()))
                                {
                                    Groupnode.InnerText = dt.Rows[i]["StationGroup"].ToString();
                                    XmlNode node = xmldoc.CreateElement("Station");
                                    XmlNode idnode = xmldoc.CreateElement("ID");
                                    idnode.InnerText = dt.Rows[i]["ID"].ToString();
                                    XmlNode addressnode = xmldoc.CreateElement("Address");
                                    addressnode.InnerText = dt.Rows[i]["Address"].ToString();

                                    XmlNode statenode = xmldoc.CreateElement("State");
                                    statenode.InnerText = "0";
                                    XmlNode marknode = xmldoc.CreateElement("Mark");

                                    marknode.InnerText = tcpMark.ToString();

                                    XmlNode isenablenode = xmldoc.CreateElement("Ver");
                                    isenablenode.InnerText = dt.Rows[i]["Ver"].ToString();
                                    XmlNode ipaddressNode = xmldoc.CreateElement("IpAddress");
                                    ipaddressNode.InnerText = dt.Rows[i]["IpAddress"].ToString();
                                    XmlNode ipPort = xmldoc.CreateElement("IpPort");
                                    ipPort.InnerText = dt.Rows[i]["IpPort"].ToString();
                                    XmlNode stationModelNode = xmldoc.CreateElement("StationModel");
                                    stationModelNode.InnerText = dt.Rows[i]["StationModel"].ToString();
                                    node.AppendChild(idnode);
                                    node.AppendChild(addressnode);
                                    node.AppendChild(Groupnode);
                                    node.AppendChild(statenode);
                                    node.AppendChild(marknode);
                                    node.AppendChild(isenablenode);
                                    node.AppendChild(ipaddressNode);
                                    node.AppendChild(ipPort);
                                    node.AppendChild(stationModelNode);
                                    rootnode.AppendChild(node);
                                }

                            }
                        }
                    }
                }
                xmldoc.Save(strPath);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private bool GetCommType()
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(System.Windows.Forms.Application.StartupPath.ToString() + @"\" + "CommType.xml");
                XmlNode node = xmlDocument.SelectSingleNode("/comm/commType");
                if (node.InnerText != "" && node.InnerText.Equals("1") == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }



        private DataTable GetStationTable()
        {
            bool commType = this.GetCommType();
            if (!commType)
            {
                return this.GetStationInfo(1);
            }
            else
            {
                return this.GetStationInfo(2);
            }
        }

        private DataTable GetStationInfo(int sign)
        {
            return new A_StationBLL().Get_StationInfo(sign);
        }

        #endregion


        #region【Czlt-2012-04-23 回收系统资源的方法】
        /// <summary>
        /// 调用系统本身的垃圾回收器
        /// </summary>
        /// <param name="process"></param>
        /// <param name="minSize"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        private void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }

        /// <summary>
        /// Czlt-2012-04-23自动调用系统定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gcTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            FlushMemory();
        }
        #endregion

    }
}
