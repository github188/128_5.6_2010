using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Threading;

namespace KJ128A.DataSave
{

    /// <summary>
    /// Access数据插入类
    /// </summary>
    public class AccessInsert
    {

        #region [ 声明 ]

        // 建立数据库实时连接
        private static OleDbConnection dbNewSql = null;

        //保存Access的目录路径
        private readonly string strAccessPath = System.Windows.Forms.Application.StartupPath + @"\AccessDB";

        private DateTime nowMark;  // 实时数据标志

        private readonly AccessBase accImp = new AccessBase();

        private readonly DiskCheck check = new DiskCheck();

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

        /*
         * 构造函数
         */

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessInsert()
        {
            //注册委托事件
            check.InitListenFreeSpace += c_FreeSpace;
            accImp.ErrorMessage += _ErrorMessage;
            //实例化
            nowMark = DateTime.Now;
            //检查并创建数据库
            accImp.CreateMDBFile(nowMark);
            //创建连接
            //dbNewSql = accImp.SetConnect(nowMark.ToString("yyyy-MM-dd") + ".mdb");
        }

        #endregion

        #region [ 注册委托 : 错误消息 ]

        /// <summary>
        /// 错误消息事件声明
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
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

        #region [ 注册委托 : 清理磁盘方案 ]

        /// <summary>
        /// 磁盘清理方案
        /// </summary>
        /// <param name="flag">1，表示需要用户清理磁盘空间；2，表示程序直接清理磁盘空间</param>
        private void c_FreeSpace(int flag)
        {
            if (flag == 2)
            {
                string[] strFileName =accImp.FindAllMDBOfFile(strAccessPath);
                if (strFileName != null)
                {
                    if (strFileName.Length > 0)
                    {
                        try
                        {
                            accImp.CancelFileReadOnly(strFileName[0]);
                            File.Delete(strFileName[0]);
                            if (ErrorMessage != null)
                            {
                                ErrorMessage(4020001, "", "", "");
                                //ShowMessage("注意：系统已经帮您清理出一些磁盘空间，为保证程序的正确运行请您尽快大量清理磁盘！", true);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ErrorMessage != null)
                            {
                                ErrorMessage(6020013, ex.StackTrace, ex.Source, ex.Message);
                            }
                        }
                    }
                }
            }
            else if (flag == 1)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(4020002, "", "", "");
                    //ShowMessage("注意：磁盘空间不足200M，请尽快清理磁盘！当磁盘容量小于100M时，我们将强制清理磁盘！", true);
                }
            }
        }

        #endregion

        /*
         * 外部调用
         */

        #region [ 方法:关闭数据库插入数据的连接 ]

        /// <summary>
        ///  关闭数据库插入数据的连接
        /// </summary>
        public bool CloeseInsertConnect()
        {
            try
            {
                if (dbNewSql != null)
                {
                    dbNewSql.Dispose();
                    dbNewSql = null;
                }
            }
            catch(Exception ex)
            {
                if (ErrorMessage != null)
                {
                    ErrorMessage(6020010, ex.StackTrace, "[InsertAccess:CloeseInsertConnect]", ex.Message);
                }
                return false;
            }

            return true;
        }

        #endregion

        #region [方法：保存配置信息]
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="bytes"></param>
        /// <param name="bIsSync"></param>
        /// <param name="intIsSyncing"></param>
        /// <returns></returns>
        public bool SveDate_Config(string strDateTime, byte[] bytes, bool bIsSync, int intIsSyncing)
        {
            OleDbCommand oleDbComm = SetOleDBPar_Config(strDateTime, bytes, bIsSync, intIsSyncing);   // 创建待插入的Command对象
            bool falg = true;
            int intCounts = 0;
            while (!InsertData(1,oleDbComm, strDateTime, bytes))
            {
                if (intCounts >= 5)
                {
                    //写入错误日志
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020015, "", "[AccessInsert:SaveData_Config]", "插入五次都未成功，该记录的主键（创建时间）" + strDateTime);
                    }
                    falg = false;
                    break;
                }
                intCounts++;
                Thread.Sleep(10);
            }
            if (oleDbComm != null)
            {
                oleDbComm.Dispose();
                oleDbComm = null;
            }
            return falg;
        }

        #endregion

        #region [ 方法: 保存原始表(OrgData)数据 ]

        /// <summary>
        /// 保存原始表(OrgData)数据
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <param name="dataStream">命令数组(Byte[])</param>
        /// <param name="bIsSync">已同步标志位</param>
        /// <param name="intIsSyncing">同步中的状态</param>
        /// <returns>True:成功; False:失败</returns>
        public bool SaveData_OrgData(DateTime dt, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            OleDbCommand oleDbComm = SetOleDbPar_OrgData(dt, dataStream, bIsSync, intIsSyncing);   // 创建待插入的Command对象
            bool falg = true;
            int intCounts = 0;
            while (!InsertData(0,oleDbComm, dt.ToString("yyyyMMddHHmmssfff"), dataStream))
            {
                if (intCounts >= 5)
                {
                    //写入错误日志
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020015, "", "[AccessInsert:SaveData_OrgData]", "插入五次都未成功，该记录的主键（创建时间）" + dt.ToString("yyyyMMddHHmmssfff"));
                    }
                    falg = false;
                    break;
                }
                //dbConn = accImp.SetConnect(dbConn.DataSource.Substring(dbConn.DataSource.LastIndexOf("\\")+1));
                intCounts++;
                Thread.Sleep(10);
            }
            if (oleDbComm != null)
            {
                oleDbComm.Dispose();
                oleDbComm = null;
            }
            return falg;
        }
        /// <summary>
        /// 保存原始表(OrgData)数据
        /// </summary>
        /// <param name="strDateTime">传入时间</param>
        /// <param name="dataStream">命令数组(Byte[])</param>
        /// <param name="bIsSync">已同步标志位</param>
        /// <param name="intIsSyncing">同步中的状态</param>
        /// <returns>True:成功; False:失败</returns>
        public bool SaveData_OrgData(string strDateTime, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            OleDbCommand oleDbComm = SetOleDbPar_OrgData(strDateTime, dataStream, bIsSync, intIsSyncing);   // 创建待插入的Command对象
            bool falg = true;
            int intCounts = 0;
            while (!InsertData(0,oleDbComm, strDateTime, dataStream))
            {
                if (intCounts >= 5)
                {
                    //写入错误日志
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020015, "", "[AccessInsert:SaveData_OrgData]", "插入五次都未成功，该记录的主键（创建时间）" + strDateTime);
                    }
                    falg = false;
                    break;
                }
                //dbConn = accImp.SetConnect(dbConn.DataSource.Substring(dbConn.DataSource.LastIndexOf("\\")+1));
                intCounts++;
                Thread.Sleep(10);
            }
            if (oleDbComm != null)
            {
                oleDbComm.Dispose();
                oleDbComm = null;
            }
            return falg;
        }
        #endregion

        #region [ 方法: 保存发送表(NewData)数据 ]

        /// <summary>
        /// 保存发送表(NewData)数据
        /// </summary>
        /// <param name="strCreateInfo">传入时间字符串</param>
        /// <param name="dataStream">命令数组(Byte[])</param>
        /// <param name="bIsSend">已发送标志位</param>
        /// <param name="bIsSending">发送中的状态</param>
        /// <param name="iSaveState">存储状态</param>
        /// <returns>True:成功; False:失败</returns>
        public bool SaveData_NewData( string strCreateInfo, byte[] dataStream, bool bIsSend, bool bIsSending, int iSaveState)
        {
            bool falg = true;
            OleDbCommand oleDbComm =
                SetOleDbPar_NewData(strCreateInfo, dataStream, bIsSend, bIsSending, iSaveState);

            int intCounts = 0;
            while (!InsertData(0,oleDbComm, strCreateInfo, dataStream))
            {
                if (intCounts >= 5)
                {
                    //写入错误日志
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020015, "", "[AccessInsert:SaveData_NewData]", "插入五次都未成功，该记录的主键（创建时间）" + strCreateInfo);
                    }
                    falg = false;
                    break;
                }
                intCounts++;
                Thread.Sleep(10);
            }
            if (oleDbComm != null)
            {
                oleDbComm.Dispose();
                oleDbComm = null;
            }
            
            return falg;
        }

        #endregion

        /*
         * 内部调用
         */

        #region [ 方法: 获取当前有效连接 ]

        /// <summary>
        /// 获取当前有效连接
        /// </summary>
        /// <param name="dt">传入时间参数</param>
        /// <returns>数据库连接</returns>
        public  IDbConnection GetConnectionByTime(DateTime dt)
        {
           
            // 传入的日期和当前连接的日期不相等
            if (dt.Year * 10000 + dt.Month * 100 + dt.Day != nowMark.Year * 10000 + nowMark.Month * 100 + nowMark.Day)
            {
                nowMark = dt;

                //磁盘空间检测
                check.hardCheckMessure();

                //检查是否要创建新的数据库
                accImp.CreateMDBFile(nowMark);

                //实例数据库连接
                //dbNewSql = accImp.SetConnect(nowMark.ToString("yyyy-MM-dd") + ".mdb");

                return dbNewSql;
            }
            else
            {
                return dbNewSql;
            }
        }

        #endregion

        #region [方法：设置配置表Command对象]
        /// <summary>
        /// 设置配置表Command对象
        /// </summary>
        /// <param name="strDatetime"></param>
        /// <param name="bytes"></param>
        /// <param name="bIsSync"></param>
        /// <param name="intIsSyncing"></param>
        /// <returns></returns>
        public OleDbCommand SetOleDBPar_Config(string strDatetime, byte[] bytes, bool bIsSync, int intIsSyncing)
        {
            string[] name = accImp.GetInforFromString(strDatetime);
            string strTableName = name[1];        // 表名
            string strCreateInfo = strDatetime;    // CreateInfo 字段信息  数据库表主键信息
            int intDataLen = bytes.Length;                         // 字节数组长度

            string strCommand = "INSERT INTO " + strTableName + " ( CreateInfo,CmdLen,CmdInfo,IsSync,IsSyncing ) VALUES(@strCreateInfo,@intDataLen,@dataStream,@bIsSync,@intIsSyncing)";

            OleDbParameter[] oleParmeters ={
                new OleDbParameter("@strCreateInfo", OleDbType.VarWChar),
                new OleDbParameter("@intDataLen", OleDbType.Integer),
                new OleDbParameter("@dataStream", OleDbType.Binary),
                new OleDbParameter("@bIsSync", OleDbType.Boolean),
                new OleDbParameter("@intIsSyncing", OleDbType.Integer)
                };
            oleParmeters[0].Value = strCreateInfo;
            oleParmeters[1].Value = intDataLen;
            oleParmeters[2].Value = bytes;
            oleParmeters[3].Value = bIsSync;
            oleParmeters[4].Value = intIsSyncing;

            return accImp.BuildOleDbCommand(strCommand, oleParmeters);
        }
        #endregion

        #region[ 方法: 设置原始表(OrgData)Command对象 ]

        /// <summary>
        /// 设置原始表(OrgData)Command命令
        /// </summary>
        /// <param name="dt">传入时间</param>
        /// <param name="dataStream">命令数组(Byte[])</param>
        /// <param name="bIsSync">已同步标志位</param>
        /// <param name="intIsSyncing">同步中的状态</param>
        /// <returns>返回Command对象</returns>
        public OleDbCommand SetOleDbPar_OrgData(DateTime dt, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {

            string strTableName = "OrgData" + dt.ToString("HH");        // 表名
            string strCreateInfo = dt.ToString("yyyyMMddHHmmssfff");    // CreateInfo 字段信息  数据库表主键信息
            int intDataLen = dataStream.Length;                         // 字节数组长度

            string strCommand = "INSERT INTO " + strTableName + " ( CreateInfo,CmdLen,CmdInfo,IsSync,IsSyncing ) VALUES(@strCreateInfo,@intDataLen,@dataStream,@bIsSync,@intIsSyncing)";

            OleDbParameter[] oleParmeters ={
                new OleDbParameter("@strCreateInfo", OleDbType.VarWChar),
                new OleDbParameter("@intDataLen", OleDbType.Integer),
                new OleDbParameter("@dataStream", OleDbType.Binary),
                new OleDbParameter("@bIsSync", OleDbType.Boolean),
                new OleDbParameter("@intIsSyncing", OleDbType.Integer)
                };
            oleParmeters[0].Value = strCreateInfo;
            oleParmeters[1].Value = intDataLen;
            oleParmeters[2].Value = dataStream;
            oleParmeters[3].Value = bIsSync;
            oleParmeters[4].Value = intIsSyncing;

            return accImp.BuildOleDbCommand(strCommand, oleParmeters);
        }

        /// <summary>
        /// 设置原始表(OrgData)Command命令
        /// </summary>
        /// <param name="strDateTime">传入时间</param>
        /// <param name="dataStream">命令数组(Byte[])</param>
        /// <param name="bIsSync">已同步标志位</param>
        /// <param name="intIsSyncing">同步中的状态</param>
        /// <returns>返回Command对象</returns>
        public OleDbCommand SetOleDbPar_OrgData(string strDateTime, byte[] dataStream, bool bIsSync, int intIsSyncing)
        {
            //string[] name = accImp.GetInforFromString(databaseType, strDateTime);
            string[] name = accImp.GetInforFromString(true, strDateTime);
            string strTableName = name[1];     //表名
            string strCreateInfo = strDateTime;    // CreateInfo 字段信息  数据库表主键信息
            int intDataLen = dataStream.Length;                         // 字节数组长度

            string strCommand = "INSERT INTO " + strTableName + " ( CreateInfo,CmdLen,CmdInfo,IsSync,IsSyncing ) VALUES(@strCreateInfo,@intDataLen,@dataStream,@bIsSync,@intIsSyncing)";

            OleDbParameter[] oleParmeters ={
                new OleDbParameter("@strCreateInfo", OleDbType.VarWChar),
                new OleDbParameter("@intDataLen", OleDbType.Integer),
                new OleDbParameter("@dataStream", OleDbType.Binary),
                new OleDbParameter("@bIsSync", OleDbType.Boolean),
                new OleDbParameter("@intIsSyncing", OleDbType.Integer)
                };
            oleParmeters[0].Value = strCreateInfo;
            oleParmeters[1].Value = intDataLen;
            oleParmeters[2].Value = dataStream;
            oleParmeters[3].Value = bIsSync;
            oleParmeters[4].Value = intIsSyncing;

            return accImp.BuildOleDbCommand(strCommand, oleParmeters);
        }

        #endregion

        #region[ 方法: 设置发送表(NewData)Command对象 ]

        /// <summary>
        /// 设置发送表(NewData)Command命令
        /// </summary>
        /// <param name="strCreateInfo">传入时间字符串</param>
        /// <param name="dataStream">命令数组(Byte[])</param>
        /// <param name="bIsSend">已发送标志位</param>
        /// <param name="bIsSending">发送中的状态</param>
        /// <param name="iSaveState">存储状态</param>
        /// <returns>返回Command对象</returns>
        public OleDbCommand SetOleDbPar_NewData(string strCreateInfo, byte[] dataStream, bool bIsSend, bool bIsSending, int iSaveState)
        {
            //string[] name = accImp.GetInforFromString(databaseType, strCreateInfo);
            string[] name = accImp.GetInforFromString(false, strCreateInfo);
            string strTableName = name[1];     //表名
            int intDataLen = dataStream.Length;     //CmdLen字段
            string strCommand = "INSERT INTO " + strTableName + " ( CreateInfo,CmdLen,CmdInfo,IsSend,IsSending,SaveState ) VALUES(@strCreateInfo,@intDataLen,@dataStream,@bIsSend,@bIsSending,@iSaveState)";

            OleDbParameter[] oleParmeters ={
                new OleDbParameter("@strCreateInfo", OleDbType.VarWChar),
                new OleDbParameter("@intDataLen", OleDbType.Integer),
                new OleDbParameter("@dataStream", OleDbType.Binary),
                new OleDbParameter("@bIsSend", OleDbType.Boolean),
                new OleDbParameter("@bIsSending", OleDbType.Boolean),
                new OleDbParameter("@iSaveState",OleDbType.Integer)
            };
            oleParmeters[0].Value = strCreateInfo;
            oleParmeters[1].Value = intDataLen;
            oleParmeters[2].Value = dataStream;
            oleParmeters[3].Value = bIsSend;
            oleParmeters[4].Value = bIsSending;
            oleParmeters[5].Value = iSaveState;

            return accImp.BuildOleDbCommand(strCommand, oleParmeters);
        }

        #endregion

        #region [ 方法: 向表中插入数据（公共方法）]

        /// <summary>
        /// 向表中插入数据（公共方法）
        /// </summary>
        /// <param name="dbCommand">Command对象</param>
        /// <param name="strCreateInfo"></param>
        /// <param name="dataStream"></param>
        /// <returns>操作成功返回True</returns>
        private bool InsertData(int insertType,OleDbCommand dbCommand, string strCreateInfo, byte[] dataStream)
        {
            bool falg = true;
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);
            try
            {
                string newTime = strCreateInfo.Substring(0, 4) + "." + strCreateInfo.Substring(4, 2) + "." +
                             strCreateInfo.Substring(6, 2);
                dt = Convert.ToDateTime(newTime);
            }
            catch
            {
                return true;
            }
            if (dt.Equals(new DateTime(2000, 1, 1, 0, 0, 0)))
            {
                return true;
            }
            string filename;
            filename = dt.ToString("yyyy-MM-dd") + ".mdb";
            if (insertType != 0)
            {
                filename = "Config\\config" + filename;
            }
            OleDbConnection conn = null; // 获取有效的连接
            
            try
            {
                conn = DAO.GetConn(filename); // 获取有效的连接
                dbCommand.Connection = conn;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                dbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.Name == "DataSave")
                    Thread.Sleep(100);
                if (ex.Message.IndexOf("找不到输出表") != -1)
                {
                    try
                    {
                        if (ex.Message.IndexOf("NewData") != -1)
                        {
                            //插入New表
                            accImp.CreateNewTable(filename, ex.Message.Substring(ex.Message.IndexOf("'") + 1, 9));
                        }
                        else if(ex.Message.IndexOf("OrgData") != -1)
                        {
                            //插入Org表
                            accImp.CreateOrgTable(filename, ex.Message.Substring(ex.Message.IndexOf("'") + 1, 9));
                        }
                        else if (ex.Message.IndexOf("ConfigData") != -1)
                        {
                            //插入Config表
                            accImp.CreateConfigTable(filename, ex.Message.Substring(ex.Message.IndexOf("'") + 1, 12));
                        }
                    }
                    catch { }
                    falg = false;
                }
                else if (ex.Message.IndexOf("操作必须使用一个可更新的查询") != -1)
                {
                    try
                    {
                        accImp.CancelFileReadOnly(conn.DataSource);
                    }
                    catch { }
                    falg = false;
                }
                else if (ex.Message.IndexOf("找不到文件") != -1)
                {
                    try
                    {
                        accImp.CopyMDB(conn.DataSource);
                    }
                    catch { }
                    falg = false;
                }
                else if (ex.Message.IndexOf("创建重复的值") != -1)
                {
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", "有重复的值出现" + dataStream[0].ToString() + "." + dataStream[1].ToString() + "." + dataStream[2].ToString() + "." + strCreateInfo);
                    //}
                    falg = true;
                    //Thread.Sleep(80);
                }
                else if (ex.Message.IndexOf("当前被锁定") != -1)
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", ex.Message + Thread.CurrentThread.Name);
                    }
                    falg = false;
                    Thread.Sleep(100);
                }
                else if (ex.Message.IndexOf("由于您和其他用户试图同时改变同一数据") != -1)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                    try
                    {
                        string strfilenameTemp = filename.Replace(".mdb", ".ldb");
                        if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp))
                        {
                            File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp);
                        }
                        File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename);
                    }
                    catch { }
                    Thread.Sleep(100);
                    falg = false;
                }
                else if (ex.Message.IndexOf("不可识别的数据库格式") != -1)
                {
                    //if (ErrorMessage != null)
                    //{
                    //    ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", ex.Message + Thread.CurrentThread.Name);
                    //}
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                    try
                    {
                        string strfilenameTemp = filename.Replace(".mdb", ".ldb");
                        if (File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp))
                        {
                            File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strfilenameTemp);
                        }
                        File.Delete(System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + filename);
                    }
                    catch{}
                    //catch(Exception ee) 
                    //{
                    //    string s = ee.Message;
                    //}
                    Thread.Sleep(100);
                    falg = false;
                }
                else
                {
                    if (ErrorMessage != null)
                    {
                        ErrorMessage(6020006, ex.StackTrace, "[InsertAccess:InsertData]", ex.Message + Thread.CurrentThread.Name);
                    }
                    Thread.Sleep(100);
                    falg = false;
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }
            }
            return falg;
        }

        #endregion

    }
}
