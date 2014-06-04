using System;
using System.Collections.Generic;
using System.Text;
using SQLDMO;
using System.IO;
using System.Xml;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 
    /// </summary>
    public class DataBaseManage : IDisposable
    {
        #region [ 声明: 委托 ] 错误消息事件

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

        #region [ 声明: 委托 ] 完成同步

        /// <summary>
        /// 完成同步
        /// </summary>
        public delegate void SyncCompleteEventHandler();

        /// <summary>
        /// 完成同步
        /// </summary>
        public event SyncCompleteEventHandler SyncComplete;

        #endregion

        #region [ 委托: 返回进去百分比 ]

        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="percent">拷贝进度百分比</param>
        public delegate void GuageEventHandler(int percent);

        /// <summary>
        /// 事件
        /// </summary>
        public event GuageEventHandler GuageEvent;

        private void GuageEventFun(int percent)
        {
            if (GuageEvent != null)
            {
                GuageEvent(percent);
            }
        }

        #endregion

        #region [ 变量: 数据库参数 ]

        private string dbName = "kj128n", dbBackUpName = "kj128nbackup";
        private SQLServer svr = null;
        private string backPath = @"d:\database\backup\", dbPath = @"d:\database\";
        private FileCopy fc = null;
        #endregion

        #region [ 方法: 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataBaseManage()
        {
            
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="oldDbName">原数据库名</param>
        /// <param name="backUpName">备数据库名</param>
        /// <param name="backUpPath">备数据库文件路径</param>
        /// <param name="oldDbPath">原数据库文件路径</param>
        public DataBaseManage(string oldDbName, string backUpName, string backUpPath, string oldDbPath)
        {
            dbName = oldDbName;
            dbBackUpName = backUpName;
            backPath = backUpPath;
            dbPath = oldDbPath;
        }

        #endregion

        #region [ 方法: 连接数据库 ]

        private bool Open()
        {
            try
            {
                string strIP = GetConfigValue("Server").ToString();
                string uid = GetConfigValue("uid").ToString();
                string pwd = GetConfigValue("pwd").ToString();

                if (svr == null)
                {
                    svr = new SQLServerClass();
                   // svr.Connect(".", "sa", "sa");
                    svr.Connect(strIP, uid, pwd);
                }
                else
                {
                    svr.Close();
                    svr = new SQLServerClass();
                   // svr.Connect(".", "sa", "sa");
                    svr.Connect(strIP, uid, pwd);
                }
                
            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                if (ce.ErrorCode == -2147203048)
                {
                    ErrorMessage(2023048, ce.StackTrace, "[DataBaseManage:Open]", ce.Message);
                    return false;
                }

                //不存在或访问被拒绝
                if (ce.ErrorCode == -2147221504)
                {
                    ErrorMessage(2021504, ce.StackTrace, "[DataBaseManage:Open]", ce.Message);
                    return false;
                }
            }
            return true;
        }

        //private void LinkNull(SQLServer svr)
        //{
        //    //if (svr != null)
        //    //{
        //    //    svr.Close();
        //    //    svr = null;
        //    //}
        //}

        /// <summary>
        /// 开启数据库并连接
        /// </summary>
        /// <returns>执行结果</returns>
        public bool LinkSql()
        {
            string strIP = GetConfigValue("Server").ToString();
            string uid = GetConfigValue("uid").ToString();
            string pwd = GetConfigValue("pwd").ToString();
            try
            {
               // svr.Start(true, ".", "sa", "sa");
                svr.Start(true, strIP, uid, pwd);
            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                //不存在或访问被拒绝
                if (ce.ErrorCode == -2147221504)
                {
                    //ErrorMessage(-2147221504, ce.StackTrace, "[DataBaseManage:InitCheckDB]", ce.Message);
                    ErrorMessage(2021504,ce.StackTrace,"[DataBaseManage:LinkSql]", ce.Message);
                    return false;
                }
                // 服务的范例已在运行中
                if (ce.ErrorCode == -2147023840)
                {
                    //svr.Connect(".", "sa", "sa");
                    svr.Start(true, strIP, uid, pwd);
                }
            }
            return true;
        }

        #endregion

        #region [ 方法: 检测数据库 ]

        /// <summary>
        /// 检测数据库
        /// </summary>
        /// <returns></returns>
        public bool InitCheckDB()
        {
            // 检测数据库
            return CheckDBState();
        }

        #endregion

        #region [ private方法: 检测数据库 ]

        /// <summary>
        /// 检测数据库
        /// </summary>
        private bool CheckDBState()
        {
            // 逻辑:检测数据库没有主数据库名时查看文件,有文件附加,备数据库没文件时同步主备数据库有文件则附加
            bool bl = false;
            bool falg = true;
            try
            {
                if (!Open())
                {
                    return false;
                }
                foreach (Database db in svr.Databases)
                {
                    if (db.Name != null && db.Name.ToLowerInvariant() == dbName)
                    {
                        bl = true;
                        break;
                    }
                }

                if (!bl)
                {
                    if (File.Exists(dbPath + dbName + ".mdf"))
                    {
                        svr.AttachDB(dbName, dbPath + dbName + ".mdf;" + dbPath + dbName + "_log.ldf");
                    }
                    else
                    {
                        ErrorMessage(2024001, "", "[DataBaseManage:CheckDBState]", "没有发现kj128数据库");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(6024002, ex.StackTrace, "[DataBaseManage:CheckDBState]", ex.Message);
                falg = false;
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
            return falg;
        }

        #endregion

        #region [ 方法: 检测 KJ128NBcakUp数据库是否存在 ]
        /// <summary>
        /// 检测 KJ128NBcakUp数据库是否存在
        /// </summary>
        /// <returns>True:存在;False:不存在</returns>
        public bool CheckBackUpDBState()
        {
            bool bl = false;
            try
            {
                if (!Open())
                {
                    return false;
                }
                foreach (Database db in svr.Databases)
                {
                    if (db.Name != null && db.Name.ToLowerInvariant() == "kj128nbackup")
                    {
                        bl = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(6024002, ex.StackTrace, "[DataBaseManage:CheckDBState]", ex.Message);
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
            return bl;
        }

        #endregion

        #region [ 方法: 删除备份数据库 ]

        /// <summary>
        /// 删除备份数据库
        /// </summary>
        /// <returns></returns>
        public bool DBDelete()
        {
            bool falg = true;
            try
            {
                if (!Open())
                {
                    return false;
                }
                foreach (Database db in svr.Databases)
                {
                    if (db.Name != null && db.Name.ToLowerInvariant() == dbBackUpName)
                    {
                        #region 关闭sql连接
                        // 获取所有的进程列表
                        SQLDMO.QueryResults qr = svr.EnumProcesses(-1);

                        // 查找 SPID 和 DBName 的位置
                        int iColPIDNum = -1;        // 标记 SPID 的位置
                        int iColDbName = -1;        // 标记 DBName 的位置

                        for (int i = 1; i <= qr.Columns; i++)
                        {
                            string strName = qr.get_ColumnName(i);

                            if (strName.ToUpper().Trim() == "SPID")
                            {
                                // 标记 SPID
                                iColPIDNum = i;
                            }
                            else if (strName.ToUpper().Trim() == "DBNAME")
                            {
                                // 标记 DBName
                                iColDbName = i;
                            }

                            // 如果找到 SPID 和 DBName, 则跳出循环
                            if (iColPIDNum != -1 && iColDbName != -1)
                            {
                                break;
                            }
                        }

                        // 发现正在操作指定恢复的数据库的进程，将其强制终止
                        for (int i = 1; i <= qr.Rows; i++)
                        {
                            // 获取该进程正在操作的数据库名称
                            int lPID = qr.GetColumnLong(i, iColPIDNum);
                            string strDBName = qr.GetColumnString(i, iColDbName);

                            // 比对被操作的数据库是否是我们要还原的数据库
                            if (strDBName.ToUpper() == dbBackUpName.ToUpper())
                            {
                                svr.KillProcess(lPID);
                            }
                        }
                        #endregion

                        // 删除备数据库
                        svr.KillDatabase(dbBackUpName);

                        break;
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                if (ce.ErrorCode == -2147217803)
                {
                    // 分离错误 正在使用无法删除
                    ErrorMessage(202, ce.StackTrace, "[DBManage:DBDelete]", ce.Message);
                }
                falg = false;
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
            return falg;

        }

        #endregion

        #region[收缩数据库]
        public bool ZipDataBase()
        {
            bool falg = true;
            try
            {
                if (!Open())
                {
                    return false;
                }
                foreach (Database db in svr.Databases)
                {
                    if (db.Name != null && db.Name.ToLowerInvariant() == dbName)
                    {
                        #region 关闭sql连接
                        // 获取所有的进程列表
                        SQLDMO.QueryResults qr = svr.EnumProcesses(-1);

                        // 查找 SPID 和 DBName 的位置
                        int iColPIDNum = -1;        // 标记 SPID 的位置
                        int iColDbName = -1;        // 标记 DBName 的位置

                        for (int i = 1; i <= qr.Columns; i++)
                        {
                            string strName = qr.get_ColumnName(i);

                            if (strName.ToUpper().Trim() == "SPID")
                            {
                                // 标记 SPID
                                iColPIDNum = i;
                            }
                            else if (strName.ToUpper().Trim() == "DBNAME")
                            {
                                // 标记 DBName
                                iColDbName = i;
                            }

                            // 如果找到 SPID 和 DBName, 则跳出循环
                            if (iColPIDNum != -1 && iColDbName != -1)
                            {
                                break;
                            }
                        }

                        // 发现正在操作指定恢复的数据库的进程，将其强制终止
                        for (int i = 1; i <= qr.Rows; i++)
                        {
                            // 获取该进程正在操作的数据库名称
                            int lPID = qr.GetColumnLong(i, iColPIDNum);
                            string strDBName = qr.GetColumnString(i, iColDbName);

                            // 比对被操作的数据库是否是我们要还原的数据库
                            if (strDBName.ToUpper() == dbBackUpName.ToUpper())
                            {
                                svr.KillProcess(lPID);
                            }
                        }
                        #endregion
                        db.Shrink(-1, 0);

                        break;
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                if (ce.ErrorCode == -2147217803)
                {
                    if (ErrorMessage!=null)
                    {
                        // 分离错误 正在使用无法删除
                        ErrorMessage(202, ce.StackTrace, "[DBManage:DBzip]", ce.Message);
                    }
                }
                falg = false;
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
            return falg;
        }
        #endregion

        #region [ 方法: 主备数据库同步 ]

        /// <summary>
        /// 数据库主备同步
        /// </summary>
        /// <returns></returns>
        public void DBSync()
        {
            try
            {
                // 删除备数据库
                if (!DBDelete())
                {

                }

                int dbSize = 1;
                Open();
                foreach (Database db in svr.Databases)
                {
                    if (db.Name == dbName)
                    {
                        //得到数据库大小
                        dbSize = db.FileGroups.Item(1).DBFiles.Item(1).Size;
                        break;
                    }
                }
                #region [ 判断磁盘剩余空间是否可进行备份 ]

                // 获取磁盘剩余空间大小
                DriveInfo d = new DriveInfo(dbPath.Substring(0, 1));
                int diskSize = Convert.ToInt32(d.AvailableFreeSpace / 1024 / 1024);
                if (diskSize < dbSize)
                {
                    ErrorMessage(2024003, "", "[DataBaseManage:CheckDBState]", "备份数据库所需磁盘空间不够" + dbSize + "M\r\n磁盘[" + d.Name + "]存储空间过小,无法备份");
                    return;
                }
                #endregion

                #region [ 强制关闭主数据库的连接 ]
                // 获取所有的进程列表
                SQLDMO.QueryResults qr = svr.EnumProcesses(-1);

                // 查找 SPID 和 DBName 的位置
                int iColPIDNum = -1;        // 标记 SPID 的位置
                int iColDbName = -1;        // 标记 DBName 的位置

                for (int i = 1; i <= qr.Columns; i++)
                {
                    string strName = qr.get_ColumnName(i);

                    if (strName.ToUpper().Trim() == "SPID")
                    {
                        // 标记 SPID
                        iColPIDNum = i;
                    }
                    else if (strName.ToUpper().Trim() == "DBNAME")
                    {
                        // 标记 DBName
                        iColDbName = i;
                    }

                    // 如果找到 SPID 和 DBName, 则跳出循环
                    if (iColPIDNum != -1 && iColDbName != -1)
                    {
                        break;
                    }
                }

                // 发现正在操作指定恢复的数据库的进程，将其强制终止
                for (int i = 1; i <= qr.Rows; i++)
                {
                    // 获取该进程正在操作的数据库名称
                    int lPID = qr.GetColumnLong(i, iColPIDNum);
                    string strDBName = qr.GetColumnString(i, iColDbName);

                    // 比对被操作的数据库是否是我们要还原的数据库
                    if (strDBName.ToUpper() == dbName.ToUpper())
                    {
                        svr.KillProcess(lPID);
                    }
                }
                #endregion
                // 分离原数据库
                string s = svr.DetachDB(dbName, false);

                // 判断 文件夹不存在则创建 文件存在则删除 
                if (!Directory.Exists(backPath))
                {
                    Directory.CreateDirectory(backPath);
                }

                try
                {
                    // 删除备数据库
                    svr.KillDatabase(dbBackUpName);
                }
                catch { }

                // 备数据库主文件
                if (File.Exists(backPath + dbName + ".mdf"))
                {
                    // 分离原数据库
                    try
                    {
                        svr.DetachDB(dbBackUpName, false);
                    }
                    catch { }
                    File.Delete(backPath + dbName + ".mdf");
                }
                // 备数据库日志文件
                if (File.Exists(backPath + dbBackUpName + "_log.ldf"))
                {
                    File.Delete(backPath + dbBackUpName + "_log.ldf");
                }

                #region copy文件

                fc = new FileCopy(dbPath + dbName + ".mdf", backPath + dbName + ".mdf");
                fc.CopyComplete += new FileCopy.CopyCompleteEventHandler(fc_CopyComplete);
                fc.GuageEvent += new FileCopy.GuageEventHandler(fc_GuageEvent);
                // 开始copy
                fc.Copy();
                
                #endregion

            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                if (ce.ErrorCode == -2147217803)//("因为它当前正在使用") != -1)
                {
                    // 分离错误 正在使用无法删除
                    ErrorMessage(-2147217803, ce.StackTrace, "[DBManage:DBSync]", ce.Message);
                }
            }
            //finally
            //{
            //    LinkNull(svr);
            //}
        }

        void fc_GuageEvent(int percent)
        {
            GuageEventFun(percent);
        }

        #region [ 方法: 停止数据库同步 ]

        /// <summary>
        /// 停止数据库同步
        /// </summary>
        public void Close()
        {
            if (fc != null)
            {
                fc.Close();
                fc.Dispose();
                if (File.Exists(backPath + dbName + ".mdf"))
                {
                    try
                    {
                        File.Delete(backPath + dbName + ".mdf");
                    }
                    catch { }
                }
                // 备数据库日志文件
                if (File.Exists(backPath + dbBackUpName + "_log.ldf"))
                {
                    try
                    {
                        File.Delete(backPath + dbBackUpName + "_log.ldf");
                    }
                    catch { }
                }
                InitCheckDB();
            }
        }

        #endregion

        /// <summary>
        /// 拷贝完成
        /// </summary>
        void fc_CopyComplete()
        {
            //try
            //{
            //    Open();
            //    // 附加数据库
            //    svr.AttachDB(dbName, dbPath + dbName + @".mdf;" + dbPath + dbName + "_log.ldf");
            //    svr.AttachDBWithSingleFile(dbBackUpName, backPath + dbName + @".mdf");
            //}
            //catch (System.Runtime.InteropServices.COMException ce)
            //{
            //    //LinkNull(svr);
            //    if (ce.ErrorCode == -2147217803)//("因为它当前正在使用") != -1)
            //    {
            //        // 分离错误 正在使用无法删除
            //        ErrorMessage(-2147217803, ce.StackTrace, "[DBManage:DBSync]", ce.Message);
            //    }
            //}
            //finally
            //{
            //    LinkNull(svr);
            //}
            // 数据库同步完成
            SyncCompleteFun();
        }

        private void SyncCompleteFun()
        {
            if (SyncComplete != null)
            {
                SyncComplete();
            }
        }

        #endregion

        #region [ 方法: 释放 ]

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            //if (svr != null)
            //{
            //    svr.Close();
            //    svr = null;
            //}
        }

        #endregion
        
        #region【获取数据库配置链接】
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appKey"></param>
        /// <returns></returns>
        private string GetConfigValue(string appKey)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(System.Windows.Forms.Application.StartupPath + "\\KJ128NMainRun.exe.config");

                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion
    }
}
