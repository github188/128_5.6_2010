using System;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Text;
using System.Threading;
using KJ128A.HostBack;
using KJ128A.Transfer;
using System.Windows.Forms;
using KJ128A.DataSave;
using System.Messaging;

namespace KJ128A.HostBack
{
    public class DataSend
    {

        #region [ 声明 ]
        //private SendMessageQueuel sendQueuel;
        private HostBacker hb;

        private readonly NetTraner n;

        /// <summary>
        /// 处理数据存储
        /// </summary>
        private InterfaceHostBack interHostBack = new InterfaceHostBack();

        /// <summary>
        /// 发送数据的线程
        /// </summary>
        public Thread thread_DataSend;

        /// <summary>
        /// 存储接收到的数据
        /// </summary>
        public string str_DataSend = string.Empty;

        /// <summary>
        /// 是否第一次监听
        /// </summary>
        private bool bl_FirstListen = false;

        /// <summary>
        /// 是否为主机
        /// </summary>
        private readonly bool isHost;

        /// <summary>
        /// 对方电脑的IP地址
        /// </summary>
        private readonly string str_IPAddress = string.Empty;

        /// <summary>
        /// 备份数据库是否完成
        /// </summary>
        private bool isBackData = true;


        /// <summary>
        /// 本机通讯的主备标志
        /// </summary>
        private string strPort = string.Empty;

        /// <summary>
        /// 是否在切换数据库
        /// </summary>
        public bool isSyncHost = false;
        #endregion
        private System.Timers.Timer angenTime = new System.Timers.Timer();
        private int angenCount = 0;
        #region [ 构造函数 ]

        public DataSend(bool isHost,string strIP,int intSendPort,int intListenPort,string  strPort,HostBacker hb)
        {
            this.isHost = isHost;
            this.strPort = strPort;
            this.hb = hb;
            n = new NetTraner(strIP, intSendPort, intListenPort);
            str_IPAddress = strIP;
            //错误事件
            interHostBack.ErrorMessage += _ErrorMessage;
            n.ErrorMessage += _ErrorMessage;
            
            n.DataReceived += n_DataReceived;
            n.InitListenLink += n_InitListenLink;
            n.CutSendLink += n_CutSendLink;

            angenCount = 0;
            //angenTime.Interval = 1000;
            //angenTime.Elapsed += new System.Timers.ElapsedEventHandler(angenTime_Elapsed);
            //angenTime.Stop();
        }
        #endregion

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


        #region [ 属性: 是否停止线程 ]

        /// <summary>
        /// 是否停止线程
        /// </summary>
        private bool _IsStop;

        /// <summary>
        /// 是否停止线程
        /// </summary>
        public bool IsStop
        {
            get { return _IsStop; }
            set
            {
                _IsStop = value;
                if (value) n.Dispose();
            }
        }

        #endregion

        #region [ 属性: 线程是否已经停止 ]

        /// <summary>
        /// 线程是否已经停止
        /// </summary>
        private bool _IsStopped;

        /// <summary>
        /// 线程是否已经停止
        /// </summary>
        public bool IsStopped
        {
            get { return _IsStopped; }
        }

        #endregion

        #region [ 属性: 是否将上一次记录发送成功 ]

        private bool _IsSend = true;

        /// <summary>
        /// 是否将上一次记录发送成功
        /// </summary>
        public bool IsSend
        {
            get { return _IsSend; }
        }

        #endregion

        #region [ 方法: 开始线程]
        /// <summary>
        /// 开始线程
        /// </summary>
        /// <returns></returns>
        public bool ThreadStart()
        {
            thread_DataSend = new Thread(this.Run);
            thread_DataSend.Name = "DataSend";
            thread_DataSend.Start();

            return true;
        }

        #endregion

        #region [ 方法: 调用发送数据的线程 ]

        /// <summary>
        /// 调用发送数据的线程
        /// </summary>
        private void Run()
        {
            // 标记线程开始
            _IsStopped = false;

            try
            {
                //if (!interHostBack.UpDataTable_NewData_IsSending())    //将发送中的数据的标志位改成未发送且不在发送中
                //{
                //    //写入错误日志
                //    if (ErrorMessage != null)
                //    {
                //        ErrorMessage(6033007, "", "[DataSend:Run]", "将发送中的数据的标志位改成未发送且不在发送中时失败,当前时间为"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                //    }
                //}

                while (!IsStop)
                {
                    string send_SaveTime;
                    byte[] send_CmdInfo;

                    //获取new表中操作时间
                    if (!File.Exists(Directory.GetCurrentDirectory() + "\\findDate.xml"))
                    {
                        try
                        {
                            //创建
                            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\findDate.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            StreamWriter sw = new StreamWriter(fs);
                            sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                            sw.WriteLine("<FindDate>");
                            sw.WriteLine("<orgLastDate>2000-1-1 00:00:00</orgLastDate>");
                            sw.WriteLine("<newLastDate>2000-1-1 00:00:00</newLastDate>");
                            sw.WriteLine("<sendLastDate>2000-1-1 00:00:00</sendLastDate>");
                            sw.WriteLine("</FindDate>");
                            sw.Flush();
                            sw.Close();
                            sw.Dispose();
                            fs.Close();
                            fs.Dispose();
                        }
                        catch { }
                    }
                    XmlDocument xmldocument = new XmlDocument();
                    

                    XmlNode node = null;

                    try
                    {
                        //加载
                        xmldocument.Load(Directory.GetCurrentDirectory() + "\\findDate.xml");
                        node = xmldocument.SelectSingleNode("/FindDate/sendLastDate");
                    }
                    catch
                    {
                        try
                        {
                            File.Delete(Directory.GetCurrentDirectory() + "\\findDate.xml");
                            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\findDate.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            StreamWriter sw = new StreamWriter(fs);
                            sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                            sw.WriteLine("<FindDate>");
                            sw.WriteLine("<orgLastDate>2000-1-1 00:00:00</orgLastDate>");
                            sw.WriteLine("<newLastDate>2000-1-1 00:00:00</newLastDate>");
                            sw.WriteLine("<sendLastDate>2000-1-1 00:00:00</sendLastDate>");
                            sw.WriteLine("</FindDate>");
                            sw.Flush();
                            sw.Close();
                            sw.Dispose();
                            fs.Close();
                            fs.Dispose();
                        }
                        catch{}
                        try
                        {
                            xmldocument.Load(Directory.GetCurrentDirectory() + "\\findDate.xml");
                            node = xmldocument.SelectSingleNode("/FindDate/sendLastDate");
                        }
                        catch { }
                    }
                    DateTime sendLastFindDate;
                    try
                    {
                        if (node != null)
                        {
                            sendLastFindDate = DateTime.Parse(node.InnerText);
                        }
                        else
                        {
                            sendLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
                        }
                    }
                    catch
                    {
                        sendLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
                    }
                    //if (interHostBack.IFExistDataInAllMDB_IsSend(sendLastFindDate,out send_SaveTime, out send_CmdInfo))
                    //{
                    //    //在Access数据库的发送表（NewData）中，将该命令的已发送置为False，发送中置为True
                    //    //interHostBack.UpDataTable_NewData(send_SaveTime, false, true);

                    //    Send(send_SaveTime, send_CmdInfo);
                    //    string strYear = send_SaveTime.Substring(0, 4);
                    //    string strMonth = send_SaveTime.Substring(4, 2);
                    //    string strDay = send_SaveTime.Substring(6, 2);
                    //    string strHour = send_SaveTime.Substring(8, 2);
                    //    string strMin = send_SaveTime.Substring(10, 2);
                    //    string strSec = send_SaveTime.Substring(12, 2);
                    //    string strTempTime = strYear + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMin + ":" + strSec;
                    //    try
                    //    {
                    //        //置时间到org操作表中
                    //        sendLastFindDate = DateTime.Parse(strTempTime);
                    //    }
                    //    catch
                    //    {
                    //        sendLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
                    //    }
                    //    try
                    //    {
                    //        node.InnerText = sendLastFindDate.ToString("yyyy-MM-dd HH:mm:ss");
                    //        xmldocument.Save(Directory.GetCurrentDirectory() + "\\findDate.xml");
                    //    }
                    //    catch { }
                    //    Thread.Sleep(20);
                    //}
                    //else               //所有数据都已经发送完成
                    //{
                    //    Thread.Sleep(200);
                    //}
                    Thread.Sleep(20);
                   
                }
            }
            catch(Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6033001, ex.StackTrace, "[DataSend:Run]", ex.Message);
                }
            }

            // 标记线程已经停止
            _IsStopped = true;
        }
        #endregion

        #region [ 方法: 发送数据 ]

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sendSaveData">时间字符</param>
        /// <param name="sendInfo">要发送的Byte数组</param>
        /// <returns></returns>
        private void Send(string sendSaveData, byte[] sendInfo)
        {
            try
            {
                //为命令增加头
                byte[] temp_a = Encoding.Default.GetBytes("FS" + sendSaveData);
                byte[] temp_SendInfo = new byte[sendInfo.Length + temp_a.Length];

                temp_a.CopyTo(temp_SendInfo, 0);
                sendInfo.CopyTo(temp_SendInfo, temp_a.Length);

                n.SendMessage(temp_SendInfo);     //发送数据

                //返回确认信息正确，将Access数据库的发送表（NewData）的已发送置为True，发送中置为False
                
                //interHostBack.UpDataTable_NewData(sendSaveData, true, false);
                ////返回确认信息正确，将Access的发送备份数据库表（NewData）的已发送置为True，发送中置为False
                //Thread.Sleep(10);
                //interHostBack.UpDataTable_NewData(3, sendSaveData, true, false);
                
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6033002, ex.StackTrace, "[DataSend:Send]", ex.Message);
                }
                
            }

            _IsSend = true;

            return;
        }

        #endregion

        #region [ 方法: 结束发送数据的线程 ]

        /// <summary>
        /// 结束发送数据的线程
        /// </summary>
        public bool ExitSendThread()
        {
            bool bl;
            try
            {
                if (thread_DataSend != null)
                {
                    if (thread_DataSend.ThreadState == System.Threading.ThreadState.Suspended)
                    {
                        thread_DataSend.Resume();
                    }

                    if (thread_DataSend.IsAlive)
                    {
                        thread_DataSend.Abort();
                    }
                }

              //  //关闭 备机存SQL Server线程
              //bl=  wdSaveBack.ExitSQLThread();

                //关闭数据库链接
              
                  bl = interHostBack.CloeseConnect();
              

                //关闭网络连接连接
                n.Dispose();
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6033003, ex.StackTrace, "[DataSend:ExitSendThread]", ex.Message);
                }
                return false;
            }

            return true;
        }

        #endregion

        #region [ 方法: 监听得到的数据 ]

        void n_DataReceived(byte[] dataInfo, out bool result)
        {
            result = false;
            try
            {
                //判断当前是否在切换数据库,如果在切换并且当前是备机时，则跳出
                if (isSyncHost&& !isHost)
                {
                    return;
                }

                if (!isBackData)    //如果切换数据库未完成，则抛弃已接收到的数据
                {
                    return;
                }

                string listen_strSaveTime;

                string str_Head=Encoding.Default.GetString(dataInfo, 0, 2); //获取命令的标头

                if ( str_Head== "FS")     //表示监听得到的数据是发送数据
                {
                    #region [ 通讯或界面信息 ]

                    //获取命令信息的时间字符
                    listen_strSaveTime = Encoding.Default.GetString(dataInfo, 2, 17);
                    byte[] listen_CmdInfo = new byte[dataInfo.Length - 19];
                    DateTime temp_TimeSave;

                    Array.Copy(dataInfo, 19, listen_CmdInfo, 0, dataInfo.Length - 19);

                    bool falgtime = true;

                    if (isHost)         //主机
                    {
                        temp_TimeSave = DateTime.Now;
                    }
                    else               //备机
                    {
                        listen_strSaveTime = listen_strSaveTime.Insert(4, "-");
                        listen_strSaveTime = listen_strSaveTime.Insert(7, "-");
                        listen_strSaveTime = listen_strSaveTime.Insert(10, " ");
                        listen_strSaveTime = listen_strSaveTime.Insert(13, ":");
                        listen_strSaveTime = listen_strSaveTime.Insert(16, ":");
                        listen_strSaveTime = listen_strSaveTime.Insert(19, ".");

                        try
                        {
                            temp_TimeSave = DateTime.Parse(listen_strSaveTime);
                        }
                        catch
                        {
                            temp_TimeSave = DateTime.Now;
                            falgtime = false;
                        }
                    }

                    if (bl_FirstListen)         //监听时，第一次连接
                    {
                        
                            //if (interHostBack.DataSelectInAllMDB_CreateInfo(Encoding.Default.GetString(dataInfo, 2, 17)))
                            //{
                            //    result = true;
                            //}
                            //else
                            //{
                            //    if (falgtime)
                            //    {
                            //        //存入Access数据库的原始表（OrgData）
                            //        result = interHostBack.InsertData_OrgData(temp_TimeSave, listen_CmdInfo, false, 0);
                            //    }
                            //    //string strTemp = Encoding.Default.GetString(listen_CmdInfo);

                            //    //string strTemp = temp_TimeSave.ToString("yyyyMMddHHmmssfff");

                            //    #region [消息队列]
                            //    //if (sendQueuel == null)
                            //    //{
                            //    //    sendQueuel = new SendMessageQueuel();
                            //    //}
                            //    //try
                            //    //{
                            //    //    sendQueuel.SendMessage("101" + strTemp, listen_CmdInfo);
                            //    //}
                            //    //catch
                            //    //{ }
                            //    ////catch (Exception ee)
                            //    ////{
                            //    ////    File.AppendAllText("e.txt", "100   " + ee.Message+"\r\n");
                            //    ////}
                            //    #endregion

                            //    #region [句柄传值]
                            //    //byte[] sarr = System.Text.Encoding.Default.GetBytes(strTemp);
                            //    //int len = sarr.Length;
                            //    //COPYDATASTRUCT cds;
                            //    //cds.dwData = (IntPtr)101;
                            //    //cds.cbData = len + 1;
                            //    //cds.lpData = strTemp;

                            //    //SendMessageAPI.SendMessageAPI.Send("FrmDataOperator", ref cds);
                            //    #endregion

                            //    //result = true;
                            //}
                       
                    }
                    else
                    {
                        if (falgtime)
                        {
                            //存入Access数据库的原始表（OrgData）
                            //result = interHostBack.InsertData_OrgData(temp_TimeSave, listen_CmdInfo, false, 0);
                        }

                        //string strTemp = Encoding.Default.GetString(listen_CmdInfo);
                        //string strTemp = temp_TimeSave.ToString("yyyyMMddHHmmssfff");

                        #region [消息队列]
                        //if (sendQueuel == null)
                        //{
                        //    sendQueuel = new SendMessageQueuel();
                        //}
                        //try
                        //{
                        //    sendQueuel.SendMessage("201" + strTemp, listen_CmdInfo);
                        //}
                        //catch
                        //{}
                        ////catch (Exception ee)
                        ////{
                        ////    File.AppendAllText("e.txt", "100   " + ee.Message+"\r\n");
                        ////}
                        #endregion

                        #region [句柄传值]
                        //byte[] sarr = System.Text.Encoding.Default.GetBytes(strTemp);
                        //int len = sarr.Length;
                        //COPYDATASTRUCT cds;
                        //cds.dwData = (IntPtr)201;
                        //cds.cbData = len + 1;
                        //cds.lpData = strTemp;

                        //SendMessageAPI.SendMessageAPI.Send("FrmDataOperator", ref cds);
                        #endregion

                        //result = true;
                    }

                    listen_CmdInfo = null;
                #endregion
                }
                else if (str_Head=="HB")
                {
                    #region [ 防止同时配置成主机或备机 ]
                    string temp_IsHost = Encoding.Default.GetString(dataInfo, 2, 1);
                    if (temp_IsHost == "1" && isHost)
                    {
                        if (ErrorMessage != null)
                        {
                            ErrorMessage(8033005, "", "[DataSend:n_DataReceived]", "配置主备信息错误,本机和对方电脑（IP地址为:" + str_IPAddress + "）都被配置成主机!");
                        }
                        result = false;
                        return;
                    }
                    else if (temp_IsHost == "2" && !isHost)
                    {
                        if (ErrorMessage != null)
                        {
                            ErrorMessage(8033006, "", "[DataSend:n_DataReceived]", "配置主备信息错误,本机和对方电脑（IP地址为:" + str_IPAddress + "）都被配置成备机!");
                        }
                        result = false;
                        return;
                    }
                    #endregion

                    #region [ 防止通信中的主备标志位被配置成相同 ]

                    string  temp_strIsSerial = Encoding.Default.GetString(dataInfo,3,dataInfo.Length-3);
                    string[] temp_str = temp_strIsSerial.Split(',');
                    foreach (string str in temp_str)
                    {
                        if (strPort.IndexOf(str) > -1)
                        {
                            if (ErrorMessage != null)
                            {
                                ErrorMessage(8033007, "", "[DataSend:n_DataReceived]", "主、备电脑上的主备标志位相同（都被配置成:" + str + "）,请重新配置");
                            }
                            result = false;
                            temp_str = null;
                            return;
                        }
                    }
                    temp_str = null;
                    //if (temp_IsSerial == str_IsSerial)
                    //{
                    //    if (ErrorMessage != null)
                    //    {
                    //        ErrorMessage(8033007, "", "[DataSend:n_DataReceived]", "主、备电脑上的主备标志位相同（都被配置成:"+str_IsSerial+"）,请重新配置");
                    //    }
                    //    result = false;
                    //    return;
                    //}
                    #endregion
                    result = true;
                }
                else if(str_Head=="ST")
                {
                    #region [ 备机接受对时命令 ]
                    if (!isHost)
                    {
                        result = n.SyncTime(Encoding.Default.GetString(dataInfo).Substring(2));
                        return;
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6033004, ex.StackTrace, "[DataSend:n_DataReceived]", ex.Message);
                }
                
                return;
            }
        }

        #endregion


        

        #region [ 事件: 初次被连接 ]

        void n_InitListenLink()
        {
            try
            {
               
                //防止同时配置成主机或备机
                if (isHost)
                {
                    int i = 0;
                    while (!n.SendOnce(System.Text.Encoding.Default.GetBytes("HB1" + strPort)) && !IsStop)
                    {
                        i++;
                        if (i == 3)
                        {
                            //MessageBox.Show("同时配置为主机或同时配置为备机!");
                        }
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    int i = 0;
                    while (!n.SendOnce(System.Text.Encoding.Default.GetBytes("HB2" + strPort)) && !IsStop)
                    {
                        i++;
                        if (i == 3)
                        {
                            //MessageBox.Show("同时配置为主机或同时配置为备机!");
                        }
                        Thread.Sleep(1000);
                    }
                }

                // 发送对时命令
                if (isHost)
                {
                    int i = 0;
                    while (!n.SendOnce(System.Text.Encoding.Default.GetBytes("ST" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))) && !IsStop)
                    {
                        i++;
                        if (i == 3)
                        {
                            //对时失败
                            ErrorMessage(5039001, "", "[DataSend:n_InitListenLink]", "对时失败！");
                        }
                        Thread.Sleep(1000);
                    }
                }
                
                // 连接成功消息
                if (ErrorMessage != null)
                {
                    ErrorMessage(8033001, "", "[DataSend:n_InitListenLink]", "网络连接成功！");
                }
                //angenTime.Start();
                angenCount = 0;
               // hb.SwitchHostBack(1);
                bl_FirstListen = true;
               
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6033005, ex.StackTrace, "[DataSend:n_InitListenLink]", ex.Message);
                }
                return;
            }
        }

        #endregion

        void angenTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (angenCount >= 3600)
            {
                angenCount = 0;
                try
                {
                    n.SendOnce(System.Text.Encoding.Default.GetBytes("ST" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                catch
                {}
            }
            else
            {
                angenCount += 1;
            }
        }

        #region [ 事件 : 初次网络断开事件]

        void n_CutSendLink()
        {
            angenTime.Stop();
            angenCount = 0;
            try
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(8033002, "", "[DataSend:n_CutSendLink]", "网络被断开！");
                }

                //hb.SwitchHostBack(2);  
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6033006, ex.StackTrace, "[DataSend:n_CutSendLink]", ex.Message);
                }
            }
        }

        #endregion

    }
}