using System;
using System.IO;
using System.Xml;
using System.Threading;
using KJ128A.DataAnalyzing;
using System.Data.SqlClient;
using System.Data;
using KJ128A.DataSave;
using KJ128NDataBase;

namespace KJ128A.HostBack
{
    public class DataSaveBackUp
    {

        #region [ 声明 ]

        /// <summary>
        /// 将数据存SQL的线程
        /// </summary>
        public Thread m_thread;

        /// <summary>
        /// 处理数据存储
        /// </summary>
        private readonly InterfaceHostBack interHostBack = new InterfaceHostBack();

        private readonly SerialAndReserialOperate KJ128Nsad = new SerialAndReserialOperate();

        /// <summary>
        /// 处理数据
        /// </summary>
        private readonly DataAnalyzing.DataAnalyzing dataAing = new DataAnalyzing.DataAnalyzing();

        private DataBaseSync dbs = new DataBaseSync();

        private DataTable dt_Satation;
        #endregion

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

        #region [ 属性: 待发送的命令 ]

        private byte[] _CmdInfo;

        /// <summary>
        /// 命令内容
        /// </summary>
        public byte[] CmdInfo
        {
            get { return _CmdInfo; }
            set
            {
                _CmdInfo = value;
            }
        }

        #endregion

        #region [ 属性: 存储命令的时间 ]

        private string _str_Save;

        /// <summary>
        /// 存储命令的时间
        /// </summary>
        public string Str_Save
        {
            get { return _str_Save; }
            set { _str_Save = value; }
        }

        #endregion

        #region [ 属性: 是否停止线程 ]

        /// <summary>
        /// 是否停止线程
        /// </summary>
        private bool _IsStop = false;

        /// <summary>
        /// 是否停止线程
        /// </summary>
        public bool IsStop
        {
            get { return _IsStop; }
            set { _IsStop = value; }
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

        #region [ 方法: 开始线程]
        /// <summary>
        /// 开始线程
        /// </summary>
        /// <returns></returns>
        public bool ThreadStart()
        {
            m_thread = new Thread(this.Run);
            m_thread.Name = "DataSaveBackUp";
            m_thread.Start();

            return true;
        }

        #endregion

        #region [ 方法: 调用存储SQL线程 ]

        /// <summary>
        /// 调用存储SQL线程
        /// </summary>
        private void Run()
        {
            //_IsStopped = false;
            //try
            //{
            //    //将发送表（NewData）中，所有未发送的数据的存储标志位置为0
            //    //interHostBack.UpData_NewData_SaveState();
            //    //Thread.Sleep(10);
            //    //interHostBack.UpData_NewData_SaveState(3);
            //    while (!IsStop)
            //    {
            //        string strSaveTime;
            //        byte[] bCmdInfo;
            //        string str_ConfigSaveTime;
            //        byte[] bt_ConfigCmdInfo;
            //        int iConfigSyncing;

            //        #region [处理config表未完成的同步数据]

            //        XmlDocument xmldocConfig = new XmlDocument();
            //        XmlNode nodeConfig = null;

            //        if (!File.Exists(Directory.GetCurrentDirectory() + "\\configOperator.xml"))
            //        {
            //            #region configOperator.xml文件不存在则创建
            //            try
            //            {
            //                //创建
            //                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\configOperator.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //                StreamWriter sw = new StreamWriter(fs);
            //                sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
            //                sw.WriteLine("<ConfigDate>");
            //                sw.WriteLine("<configLastDate>2000-1-1 00:00:00</configLastDate>");
            //                sw.WriteLine("</ConfigDate>");
            //                sw.Flush();
            //                sw.Close();
            //                sw.Dispose();
            //                fs.Close();
            //                fs.Dispose();
            //            }
            //            catch { }
            //            #endregion
            //        }
            //        else
            //        {
            //            #region [加载configOperator.xml文件]
            //            try
            //            {
            //                //加载
            //                xmldocConfig.Load(Directory.GetCurrentDirectory() + "\\configOperator.xml");
            //                nodeConfig = xmldocConfig.SelectSingleNode("/ConfigDate/configLastDate");
            //            }
            //            catch
            //            {
            //                #region [加载configOperator.xml文件错误则重新创建]
            //                try
            //                {
            //                    File.Delete(Directory.GetCurrentDirectory() + "\\configOperator.xml");
            //                }
            //                catch { }
            //                try
            //                {
            //                    FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\configOperator.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //                    StreamWriter sw = new StreamWriter(fs);
            //                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
            //                    sw.WriteLine("<ConfigDate>");
            //                    sw.WriteLine("<configLastDate>2000-1-1 00:00:00</configLastDate>");
            //                    sw.WriteLine("</ConfigDate>");
            //                    sw.Flush();
            //                    sw.Close();
            //                    sw.Dispose();
            //                    fs.Close();
            //                    fs.Dispose();
            //                }
            //                catch { }
            //                #endregion
            //            }
            //            #endregion
            //        }

            //        #region [获取最后一次操作config文件时间]
            //        DateTime configLastFindDate;
            //        try
            //        {
            //            if (nodeConfig != null)
            //            {
            //                configLastFindDate = DateTime.Parse(nodeConfig.InnerText);
            //            }
            //            else
            //            {
            //                configLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
            //            }
            //        }
            //        catch
            //        {
            //            configLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
            //        }
            //        #endregion

            //        #region [获取未同步的数据,并操作]
            //        while (true)
            //        {
            //            if (interHostBack.IfExistConfigData_IsSyncing(configLastFindDate, out str_ConfigSaveTime, out bt_ConfigCmdInfo, out iConfigSyncing))//获取未同步数据
            //            {
            //                switch (iConfigSyncing)
            //                {
            //                    case 0://正常流程
            //                    case 1:
            //                        //插入SQLSERVER数据库方法
            //                        InsertSQLSERVER(str_ConfigSaveTime, bt_ConfigCmdInfo, 1);
            //                        break;
            //                    case 2://已插入sqlserver，未插入new表
            //                        //插入new表,成功了置isSync标志位为-1
            //                        //存入Access中的发送表(new表)
            //                        if (interHostBack.InsertData_NewData(str_ConfigSaveTime, bt_ConfigCmdInfo, false, false, -1))
            //                        {
            //                            //isSync标志位为-1
            //                            //修改配置表（ConfigData）同步标志位
            //                            interHostBack.UpdateTable_ConfigData(str_ConfigSaveTime, true, -1);

            //                            string strYear = str_ConfigSaveTime.Substring(0, 4);
            //                            string strMonth = str_ConfigSaveTime.Substring(4, 2);
            //                            string strDay = str_ConfigSaveTime.Substring(6, 2);
            //                            string strHour = str_ConfigSaveTime.Substring(8, 2);
            //                            string strMin = str_ConfigSaveTime.Substring(10, 2);
            //                            string strSec = str_ConfigSaveTime.Substring(12, 2);
            //                            string strTempTime = strYear + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMin + ":" + strSec;
            //                            try
            //                            {
            //                                //置时间到org操作表中
            //                                configLastFindDate = DateTime.Parse(strTempTime);
            //                            }
            //                            catch
            //                            {
            //                                configLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
            //                            }
            //                            try
            //                            {
            //                                nodeConfig.InnerText = configLastFindDate.ToString("yyyy-MM-dd HH:mm:ss");
            //                                xmldocConfig.Save(Directory.GetCurrentDirectory() + "\\configOperator.xml");
            //                            }
            //                            catch { }
            //                        }

            //                        break;
            //                    default:
            //                        break;
            //                }
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }
            //        #endregion
            //        xmldocConfig = null;
            //        #endregion

            //        #region 操作备机上的new 表数据库
            //        //获取new表中操作时间
            //        if (!File.Exists(Directory.GetCurrentDirectory() + "\\findDate.xml"))
            //        {
            //            try
            //            {
            //                //创建
            //                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\findDate.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //                StreamWriter sw = new StreamWriter(fs);
            //                sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
            //                sw.WriteLine("<FindDate>");
            //                sw.WriteLine("<orgLastDate>2000-1-1 00:00:00</orgLastDate>");
            //                sw.WriteLine("<newLastDate>2000-1-1 00:00:00</newLastDate>");
            //                sw.WriteLine("<sendLastDate>2000-1-1 00:00:00</sendLastDate>");
            //                sw.WriteLine("</FindDate>");
            //                sw.Flush();
            //                sw.Close();
            //                sw.Dispose();
            //                fs.Close();
            //                fs.Dispose();
            //                sw = null;
            //                fs = null;
            //            }
            //            catch { }
            //        }
            //        XmlDocument xmldocument = new XmlDocument();
            //        //加载

            //        XmlNode node = null;

            //        try
            //        {
            //            xmldocument.Load(Directory.GetCurrentDirectory() + "\\findDate.xml");
            //            node = xmldocument.SelectSingleNode("/FindDate/newLastDate");
            //        }
            //        catch
            //        {
            //            try
            //            {
            //                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\findDate.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //                StreamWriter sw = new StreamWriter(fs);
            //                sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
            //                sw.WriteLine("<FindDate>");
            //                sw.WriteLine("<orgLastDate>2000-1-1 00:00:00</orgLastDate>");
            //                sw.WriteLine("<newLastDate>2000-1-1 00:00:00</newLastDate>");
            //                sw.WriteLine("<sendLastDate>2000-1-1 00:00:00</sendLastDate>");
            //                sw.WriteLine("</FindDate>");
            //                sw.Flush();
            //                sw.Close();
            //                sw.Dispose();
            //                fs.Close();
            //                fs.Dispose();
            //            }
            //            catch { }
            //            try
            //            {
            //                xmldocument.Load(Directory.GetCurrentDirectory() + "\\findDate.xml");
            //                node = xmldocument.SelectSingleNode("/FindDate/orgLastDate");
            //            }
            //            catch { }
            //        }

            //        DateTime newLastFindDate;
            //        try
            //        {
            //            if (node != null)
            //            {
            //                newLastFindDate = DateTime.Parse(node.InnerText);
            //            }
            //            else
            //            {
            //                newLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
            //            }
            //        }
            //        catch
            //        {
            //            newLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
            //        }

            //        bool bfile = true;
            //        //从Access数据库的发送表（newData）中提取未发送
            //        if (interHostBack.IFExistDataInAllMDB_IsSend_SaveState(newLastFindDate, out strSaveTime, out bCmdInfo))
            //        {
            //            CmdInfo = bCmdInfo;
            //            Str_Save = strSaveTime;
            //            int icount = 0;
            //            while (!Save())             //存SQL Server数据库不成功
            //            {
            //                if (SQLSave.bConBackStateFlag)      //数据库连接正常
            //                {
            //                    if (icount >= 10)
            //                    {
            //                        //修改Access中发送表的存SQL状态（备机），但该命令并没有存入SQL数据库（备）
            //                        interHostBack.UpDataTable_NewData(Str_Save, -1);
            //                        //Thread.Sleep(10);
            //                        ////修改Access中发送备份数据库表的存SQL状态（备机），但该命令并没有存入SQL数据库（备）
            //                        //interHostBack.UpDataTable_NewData(3, Str_Save, -1);

            //                        //写入错误日志
            //                        if (ErrorMessage != null)
            //                        {
            //                            ErrorMessage(6032005, "", "[DataSaveBackUp:Run]", "连续存入SQL Server失败10次，且当时的SQL Server连接正常,当前时间为" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            //                        }
            //                        bfile = false;
            //                        break;
            //                    }
            //                    icount++;
            //                    Thread.Sleep(20);
            //                }
            //                else                             //数据库连接失败
            //                {
            //                    Thread.Sleep(500);
            //                }
            //            }
            //            if (bfile)
            //            {
            //                string strYear = strSaveTime.Substring(0, 4);
            //                string strMonth = strSaveTime.Substring(4, 2);
            //                string strDay = strSaveTime.Substring(6, 2);
            //                string strHour = strSaveTime.Substring(8, 2);
            //                string strMin = strSaveTime.Substring(10, 2);
            //                string strSec = strSaveTime.Substring(12, 2);
            //                string strTempTime = strYear + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMin + ":" + strSec;

            //                newLastFindDate = DateTime.Parse(strTempTime);
            //                try
            //                {
            //                    node.InnerText = newLastFindDate.ToString("yyyy-MM-dd HH:mm:ss");
            //                    xmldocument.Save(Directory.GetCurrentDirectory() + "\\findDate.xml");
            //                }
            //                catch { }
            //            }
            //        }
            //        xmldocument = null;
            //        #endregion

            //        Thread.Sleep(200);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //此处需要另外捕捉错误信息存入日志文件
            //    if (ErrorMessage != null)
            //    {
            //        ErrorMessage(6032001, ex.StackTrace, "[DataSaveBackUp:Run]", ex.Message);
            //    }
            //}
            //_IsStopped = true;
        }
        #endregion

        #region [ 方法: 存储通讯数据 ]

        /// <summary>
        /// 保存通讯数据
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            try
            {
                int iCmdNO = CmdInfo[1];
                switch (iCmdNO)
                {
                    case 20:    // 巡检命令
                        if (!Save_Detecting(CmdInfo))           //存SQL Server失败
                        {
                            return false;
                        }
                        break;
                    case 22:    //版本命令

                        break;
                    case 99:    //基站状态命令
                        if (!Save_StationChangeState(CmdInfo))           //存SQL Server失败
                        {
                            return false;
                        }
                        break;
                    case 100:                           //申云飞
                        if (!KJ128Nsad.DeserialOperate(CmdInfo,false))
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                }
                //修改Access中发送表的状态（备机）
                //interHostBack.UpDataTable_NewData(Str_Save, -1);

            }
            catch (Exception ex)
            {
                if (CmdInfo == null)
                {
                    return true;
                }

                if (ErrorMessage != null)
                {
                    ErrorMessage(6032002, ex.StackTrace, "[DataSaveBackUp:Save]", ex.Message);
                }
                return false;
            }
            return true;
        }


        /// <summary>
        /// 保存通讯数据
        /// </summary>
        /// <returns></returns>
        private bool Save(string strDateTime, byte[] cmdInfo, int dataType)
        {
            try
            {
                int iCmdNO = CmdInfo[1];
                switch (iCmdNO)
                {
                    case 100:                           //申云飞
                        if (!KJ128Nsad.DeserialOperate(cmdInfo, false))
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                if (cmdInfo == null)
                {
                    return true;
                }

                if (ErrorMessage != null)
                {
                    ErrorMessage(6032002, ex.StackTrace, "[DataSaveBackUp:Save]", ex.Message);
                }
                return false;
            }
            return true;
        }
        #endregion

        #region [方法：向SqlServer中插入数据]
        public bool InsertSQLSERVER(string strDateTime, byte[] cmdInfo, int dataType)
        {
            int iCount = 0;
            int iNum = 0;
            while (!this.Save(strDateTime, cmdInfo, dataType))        //存SQL失败
            {
                if (SQLSave.bConStateFlag)      //SQL Server数据库连接正常
                {
                    if (iCount >= 10)
                    {
                        //写入错误日志
                        if (ErrorMessage != null)
                        {
                            ErrorMessage(6031006, "", "[DataSave:Run]", "连续存入SQL Server失败10次，且当时的SQL Server连接正常,当前时间为" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            InsertAccessState(strDateTime, cmdInfo, dataType);

                        }
                        iNum = 0;
                        return false;
                    }
                    iCount++;
                    Thread.Sleep(20);
                }
                else                           //SQL Server数据库连接失败
                {
                    if (iNum >= 3)
                    {
                        if (ErrorMessage != null)
                        {
                            ErrorMessage(6031006, "", "[DataSave:Run]", "连续存入SQL Server失败3次,当前时间为" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        }
                        iNum = 0;
                        return false;
                    }
                    iNum++;
                    Thread.Sleep(200);
                }
            }
            return true;
        }

        /// <summary>
        /// 插入到配置表中
        /// </summary>
        /// <param name="temp_strSaveTime"></param>
        /// <param name="temp_byteCmdInfo"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public bool InsertAccessState(string temp_strSaveTime, byte[] temp_byteCmdInfo, int datatype)
        {
            try
            {
                //XmlDocument xmldocument = new XmlDocument();
                //XmlNode node = null;
                ////加载
                //try
                //{
                //    xmldocument.Load(Directory.GetCurrentDirectory() + "\\configOperator.xml");
                //    node = xmldocument.SelectSingleNode("/ConfigDate/configLastDate");
                //}
                //catch { }
                //DateTime configLastFindDate;
                //try
                //{
                //    if (node != null)
                //    {
                //        configLastFindDate = DateTime.Parse(node.InnerText);
                //    }
                //    else
                //    {
                //        configLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
                //    }
                //}
                //catch
                //{
                //    configLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
                //}
                //string strYear = temp_strSaveTime.Substring(0, 4);
                //string strMonth = temp_strSaveTime.Substring(4, 2);
                //string strDay = temp_strSaveTime.Substring(6, 2);
                //string strHour = temp_strSaveTime.Substring(8, 2);
                //string strMin = temp_strSaveTime.Substring(10, 2);
                //string strSec = temp_strSaveTime.Substring(12, 2);
                //string strTempTime = strYear + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMin + ":" + strSec;

                //if (interHostBack.InsertData_NewData(temp_strSaveTime, temp_byteCmdInfo, false, false, -1))
                //{
                //    //isSync标志位为-1
                //    //修改配置表（Config）同步标志位
                //    interHostBack.UpdateTable_ConfigData(temp_strSaveTime, true, -1);

                //    try
                //    {
                //        //置时间到config操作表中
                //        configLastFindDate = DateTime.Parse(strTempTime);
                //    }
                //    catch
                //    {
                //        configLastFindDate = DateTime.Parse("2000-1-1 00:00:00");
                //    }
                //    try
                //    {
                //        node.InnerText = configLastFindDate.ToString("yyyy-MM-dd HH:mm:ss");
                //        xmldocument.Save(Directory.GetCurrentDirectory() + "\\configOperator.xml");
                //    }
                //    catch { }
                //}
                //xmldocument = null;

                return true;
            }
            catch { return false; }
        }
        #endregion

        #region [ 方法: 存检测到的信息 ]

        /// <summary>
        /// 存检测到的信息
        /// </summary>
        private bool Save_Detecting(byte[] temp_byteCmdInfo)
        {
            string strCmdInfo = string.Empty;
            try
            {
                this.GetStationInfo(1);
                MemDataAnalyz memDataAnalyz;

                if (dt_Satation == null)
                {
                    return true;
                }
                DataRow[] dr = dt_Satation.Select("StationAddress=" + int.Parse(temp_byteCmdInfo[0].ToString()).ToString());
                if (dr.Length <= 0)
                {
                    return true;
                }
                //状态类型
                int stationModel = int.Parse(dr[0]["StationModel"].ToString());

                memDataAnalyz = dataAing.Analyzing(temp_byteCmdInfo, stationModel);
                //如果返回的是巡检获送的数据
                if (memDataAnalyz.enumAnalyzing == EnumDataType.Polling)
                {
                    switch (stationModel)
                    {
                        case 1:
                            #region [KJ128A解析]
                            for (int i = 1; i <= memDataAnalyz.memHead.Length; i++)
                            {
                                if (!memDataAnalyz.memHead[i - 1].IsBreak)      //探头不故障时
                                {
                                    //置探头状态为正常
                                    strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "2000" + "." + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ";";

                                    //天线A接收到的发码器
                                    int intStrCountA;
                                    intStrCountA = memDataAnalyz.memHead[i - 1].CodesA.Length;
                                    if (intStrCountA > 0)
                                    {
                                        string strCardA;
                                        strCardA = memDataAnalyz.memHead[i - 1].CodesA.Remove(intStrCountA - 1);
                                        strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "0.1.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardA + ";";
                                    }

                                    //天线B接收到的发码器
                                    int intStrCountB;
                                    intStrCountB = memDataAnalyz.memHead[i - 1].CodesB.Length;
                                    if (intStrCountB > 0)
                                    {
                                        string strCardB;
                                        strCardB = memDataAnalyz.memHead[i - 1].CodesB.Remove(intStrCountB - 1);
                                        strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "0.0.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardB + ";";
                                    }

                                    //探头的出状态
                                    int intStrCountC;
                                    intStrCountC = memDataAnalyz.memHead[i - 1].CodesC.Length;
                                    if (intStrCountC > 0)
                                    {
                                        string strCardC;
                                        strCardC = memDataAnalyz.memHead[i - 1].CodesC.Remove(intStrCountC - 1);
                                        strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "0.0.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardC + ";";
                                    }

                                    //求救的卡
                                    int intStrCountD;
                                    intStrCountD = memDataAnalyz.memHead[i - 1].CodesD.Length;
                                    if (intStrCountD > 0)
                                    {
                                        string strCardD;
                                        strCardD = memDataAnalyz.memHead[i - 1].CodesD.Remove(intStrCountD - 1);
                                        strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "0.1.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardD + ";";
                                    }

                                    //低电量的卡  天线A接收到的发码器
                                    int intStrCountE;
                                    intStrCountE = memDataAnalyz.memHead[i - 1].CodesE.Length;
                                    if (intStrCountE > 0)
                                    {
                                        string strCardE;
                                        strCardE = memDataAnalyz.memHead[i - 1].CodesE.Remove(intStrCountE - 1);
                                        strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "1.1.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardE + ";";
                                    }

                                    //低电量的卡  天线B接收到的发码器
                                    int intStrCountF;
                                    intStrCountF = memDataAnalyz.memHead[i - 1].CodesF.Length;
                                    if (intStrCountF > 0)
                                    {
                                        string strCardF;
                                        strCardF = memDataAnalyz.memHead[i - 1].CodesF.Remove(intStrCountF - 1);
                                        strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "1.0.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardF + ";";
                                    }

                                    //低电量的卡  探头的出状态
                                    int intStrCountG;
                                    intStrCountG = memDataAnalyz.memHead[i - 1].CodesG.Length;
                                    if (intStrCountG > 0)
                                    {
                                        string strCardG;
                                        strCardG = memDataAnalyz.memHead[i - 1].CodesG.Remove(intStrCountG - 1);
                                        strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "1.0.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardG + ";";
                                    }


                                    //低电量的卡  求救的卡
                                    int intStrCountH;
                                    intStrCountH = memDataAnalyz.memHead[i - 1].CodesH.Length;
                                    if (intStrCountH > 0)
                                    {
                                        string strCardH;
                                        strCardH = memDataAnalyz.memHead[i - 1].CodesH.Remove(intStrCountH - 1);
                                        strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "1.1.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardH + ";";
                                    }
                                }
                                else      //探头故障
                                {
                                    //置探头状态为故障
                                    strCmdInfo += memDataAnalyz.StationAddress + "." + memDataAnalyz.memHead[i - 1].HeadAddress + "." + "-1000" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + ";";
                                }
                            }
                            #endregion
                            break;
                        default:
                            #region 【KJ128V2解析】
                            for (int i = 1; i <= memDataAnalyz.memHead.Length; i++)
                            {
                                //if (!memDataAnalyz.memHead[i - 1].IsBreak)      //探头不故障时
                                //{
                                //置探头状态为正常
                                strCmdInfo += memDataAnalyz.StationAddress + "." + 1 + "." + "2000" + "." + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ";";

                                //出
                                int intStrCountA;
                                intStrCountA = memDataAnalyz.memHead[i - 1].CodesA.Length;
                                if (intStrCountA > 0)
                                {
                                    string strCardA;
                                    strCardA = memDataAnalyz.memHead[i - 1].CodesA.Remove(intStrCountA - 1);
                                    strCmdInfo += memDataAnalyz.StationAddress + "." + 1 + "." + "0.0.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardA + ";";
                                }

                                //进状态
                                int intStrCountC;
                                intStrCountC = memDataAnalyz.memHead[i - 1].CodesC.Length;
                                if (intStrCountC > 0)
                                {
                                    string strCardC;
                                    strCardC = memDataAnalyz.memHead[i - 1].CodesC.Remove(intStrCountC - 1);
                                    strCmdInfo += memDataAnalyz.StationAddress + "." + 1 + "." + "0.1.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardC + ";";
                                }

                                //求救的卡
                                int intStrCountD;
                                intStrCountD = memDataAnalyz.memHead[i - 1].CodesD.Length;
                                if (intStrCountD > 0)
                                {
                                    string strCardD;
                                    strCardD = memDataAnalyz.memHead[i - 1].CodesD.Remove(intStrCountD - 1);
                                    strCmdInfo += memDataAnalyz.StationAddress + "." + 0 + "." + "0.1.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardD + ";";
                                }

                                //低电量 出
                                int intStrCountE;
                                intStrCountE = memDataAnalyz.memHead[i - 1].CodesE.Length;
                                if (intStrCountE > 0)
                                {
                                    string strCardE;
                                    strCardE = memDataAnalyz.memHead[i - 1].CodesE.Remove(intStrCountE - 1);
                                    strCmdInfo += memDataAnalyz.StationAddress + "." + 1 + "." + "1.0.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardE + ";";
                                }

                                //低电量 进状态
                                int intStrCountG;
                                intStrCountG = memDataAnalyz.memHead[i - 1].CodesG.Length;
                                if (intStrCountG > 0)
                                {
                                    string strCardG;
                                    strCardG = memDataAnalyz.memHead[i - 1].CodesG.Remove(intStrCountG - 1);
                                    strCmdInfo += memDataAnalyz.StationAddress + "." + 1 + "." + "1.1.0" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardG + ";";
                                }

                                //低电量 求救的卡
                                int intStrCountH;
                                intStrCountH = memDataAnalyz.memHead[i - 1].CodesH.Length;
                                if (intStrCountH > 0)
                                {
                                    string strCardH;
                                    strCardH = memDataAnalyz.memHead[i - 1].CodesH.Remove(intStrCountH - 1);
                                    strCmdInfo += memDataAnalyz.StationAddress + "." + 1 + "." + "1.1.1" + "." + memDataAnalyz.memHead[i - 1].Time.ToString("yyyy-MM-dd HH:mm:ss") + "." + strCardH + ";";
                                }
                            }
                            #endregion
                            break;
                    }
                }

                //去掉命令最后一个的";"
                string strTemp;
                if (strCmdInfo.EndsWith(";"))
                {
                    strTemp = strCmdInfo.Remove(strCmdInfo.Length - 1, 1);
                }
                else
                {
                    strTemp = strCmdInfo;
                }

                return Save_DataBase(strTemp);
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6032003, ex.StackTrace, "[DataSaveBackUp:Save_Detecting]", ex.Message);
                }
                return false;
            }

        }

        #endregion

        #region [ 方法: 存储基站状态 ]

        /// <summary>
        /// 存储基站状态
        /// </summary>
        /// <param name="temp_byteCmdInfo">命令Byte[]</param>
        /// <returns>True:成功;False:失败</returns>
        private bool Save_StationChangeState(byte[] temp_byteCmdInfo)
        {
            int intYear, intMonth, intDay, intHour, intMinute, intSecond;
            try
            {

                intYear = temp_byteCmdInfo[3] * 1000 + temp_byteCmdInfo[4];
                intMonth = temp_byteCmdInfo[5];
                intDay = temp_byteCmdInfo[6];
                intHour = temp_byteCmdInfo[7];
                intMinute = temp_byteCmdInfo[8];
                intSecond = temp_byteCmdInfo[9];

                DateTime dtStationState = new DateTime(intYear, intMonth, intDay, intHour, intMinute, intSecond);

                string strTemp = temp_byteCmdInfo[0] + ".0.";

                switch (temp_byteCmdInfo[2])
                {
                    case 0:         //基站正常
                        strTemp += "2000";
                        break;
                    case 1:         //基站未启用
                        strTemp += "0";
                        break;
                    case 2:         //基站重启
                        strTemp += "-500";
                        break;
                    case 3:         //基站休眠
                        strTemp += "-2000";
                        break;
                    case 4:         //基站离线
                        strTemp += "3000";
                        break;
                    case 5:         //基站故障
                        strTemp += "-1000";
                        break;
                }
                strTemp += "." + dtStationState.ToString("yyyy-MM-dd HH:mm:ss");

                return Save_DataBase(strTemp);

            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6032006, ex.StackTrace, "[DataSaveBackUp:Save_StationChangeState]", ex.Message);
                }
                return false;
            }
        }

        #endregion

        #region [ 方法: 将探头收到的卡的信息存入SQL Server数据库]

        private bool Save_DataBase(string strCmdInfo)
        {
            SqlParameter[] sqlParmeters ={
                new SqlParameter("Commands",SqlDbType.VarChar,7000)
            };
            sqlParmeters[0].Value = strCmdInfo;

            return interHostBack.ExecuteSql(false, "Yl_Station_ExecProc", sqlParmeters);
        }

        #endregion

        #region [ 方法: 结束存SQL Server数据库的线程 ]

        /// <summary>
        /// 结束存SQL Server数据库的线程
        /// </summary>
        public bool ExitSQLThread()
        {
            try
            {
                if (m_thread != null)
                {
                    if (m_thread.IsAlive)
                    {
                        m_thread.Abort();
                    }
                }
                //关闭 数据库连接
                return interHostBack.CloeseConnect();
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6032004, ex.StackTrace, "[DataSaveBackUp:ExitSQLThread]", ex.Message);
                }
                return false;
            }
        }

        #endregion

        #region [ 方法: 提取数据库基站信息 ]

        private bool GetStationInfo(int iSelectType)
        {
            bool bl = false;
            try
            {
                SqlParameter[] sqlParmeters = { new SqlParameter("sign", SqlDbType.Int) };
                sqlParmeters[0].Value = iSelectType;

                if (dbs.CheckBackUpDBState())       //存在 KJ128NBackUp数据库
                {

                    dt_Satation = interHostBack.GetDataTabel(false, "zjw_Select_Station", sqlParmeters);

                }
                else                                //不存在 KJ128NBackU数据库
                {

                    dt_Satation = interHostBack.GetDataTabel(true, "zjw_Select_Station", sqlParmeters);
                }

                sqlParmeters = null;
                bl = true;
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6031008, ex.StackTrace, "[DataSave:GetStationInfo]", ex.Message);
                }
            }
            return bl;
        }

        #endregion

    }
}
