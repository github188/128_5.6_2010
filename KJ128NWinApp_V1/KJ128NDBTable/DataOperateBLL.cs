using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using KJ128NDataBase;
using System.Data;
using Microsoft.VisualBasic;
using System.Configuration;

namespace KJ128NMainRun
{
    public static class DataOperateBLL
    {
        private static ProgressBar pBar;

        #region [ 方法: 获取数据库服务器列表 ]

        // 在用户的配置时，我们需要列出当前局域网内所有的数据库服务器，并且要列出指定服务器的所有数据库，实现代码如下： 
        // 取得数据库服务器列表：

        /// <summary>
        /// 获取数据库服务器列表
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetServerList(out bool isErr)
        {
            ArrayList allServers = new ArrayList();
            try
            {
                SQLDMO.Application sqlApp = new SQLDMO.ApplicationClass();
                // 将局域网类的所有能够连接SQL的服务器名称列出
                SQLDMO.NameList serverList = sqlApp.ListAvailableSQLServers();

                allServers.Add("(local)");
                for (int i = 1; i <= serverList.Count; i++)
                {
                    // 添加到列表中
                    allServers.Add(serverList.Item(i));
                }
                sqlApp.Quit();
                isErr = true;
            }
            catch (Exception e)
            {
                isErr = SqlErrRepair(e.Message.ToString());
                return GetServerList(out isErr);
            }
            return allServers;
        }

        #endregion

        #region [ 方法: GetServerList方法 的错误处理 ]

        /// <summary>
        /// GetServerList方法 的错误处理
        /// </summary>
        private static bool SqlErrRepair(string errInfo)
        {
            // 缺少sqldmo.dll文件
            if (errInfo.IndexOf("10020100-E260-11CF-AE68-00AA004A34D5") > 0 || errInfo.IndexOf("10020200-E260-11CF-AE68-00AA004A34D5") > 0)
            {
                // "缺少sqldmo.dll" 修复
                try
                {
                    File.Copy(Application.StartupPath + "\\filebackup\\sqldmo.dll", @"C:\Program Files\Microsoft SQL Server\80\Tools\Binn\sqldmo.dll");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("修复失败:" + ex.Message.ToString());
                    return false;
                }
            }
            else if (errInfo.IndexOf("0022406-E260-11CF-AE68-00AA004A34D5") > 0)
            {
                MessageBox.Show("SqlServer2000 SP4补丁未安装或未安装完整");
                return false;
            }
            else
            {
                MessageBox.Show("数据库连接异常:" + errInfo);
                return false;
            }
            return true;
        }

        #endregion

        #region [ 方法: 登录服务器，获取数据库列表 ]

        /// <summary>
        /// 登录服务器，获取数据库列表
        /// </summary>
        /// <param name="strServerName">服务器名称</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strPwd">密码</param>
        /// <returns></returns>
        public static ArrayList GetDbList(string strServerName, string strUserName, string strPwd)
        {
            ArrayList alDbs = new ArrayList();

            SQLDMO.Application sqlApp = new SQLDMO.ApplicationClass();
            SQLDMO.SQLServer svr = new SQLDMO.SQLServerClass();
            try
            {
                // 连接到数据库
                svr.Connect(strServerName, strUserName, strPwd);

                // 将服务器上所有的数据库遍历
                foreach (SQLDMO.Database db in svr.Databases)
                {
                    if (db.Name != null)
                    {
                        if (db.Name != "master" && db.Name != "model"
                        && db.Name != "msdb" && db.Name != "pubs"
                        && db.Name != "Northwind" && db.Name != "tempdb")
                        {
                            alDbs.Add(db.Name);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                //throw (new Exception("连接数据库出错：" + e.Message));
                MessageBox.Show("数据库连接失败");
            }
            finally
            {
                svr.DisConnect();
                sqlApp.Quit();
            }
            return alDbs;
        }

        #endregion

        #region [ 方法: 备份指定数据库文件 ]

        /// <summary>
        /// 备份指定数据库文件
        /// </summary>
        /// <param name="strDbName">数据库名称</param>
        /// <param name="strFileName">备份数据库的路径</param>
        /// <param name="strServerName">服务器名称</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strPassword">密码</param>
        /// <param name="prosBar">进度条</param>
        /// <returns></returns>
        public static bool BackUPDB(string strDbName, string strFileName, string strServerName, string strUserName, string strPassword, ProgressBar bar)
        {
            #region [ 判断磁盘剩余空间是否可进行备份 ]

            DBAcess dba = new DBAcess();
            DataSet tmpds = dba.GetDataSet("exec sp_spaceused");
            if (tmpds.Tables.Count > 0 && tmpds.Tables[0] != null)
            {
                // 得到数据库大小
                string tmpStr = tmpds.Tables[0].Rows[0]["database_size"].ToString();
                int dbSize = Convert.ToInt32(tmpStr.Substring(0, tmpStr.LastIndexOf(".")));
                // 获取磁盘剩余空间大小
                try
                {
                    DriveInfo d = new DriveInfo(strFileName.Substring(0, 1));
                    int diskSize = Convert.ToInt32(d.AvailableFreeSpace / 1024 / 1024);
                    if (diskSize < dbSize)
                    {
                        MessageBox.Show("备份数据库所需空间不能小于" + dbSize + "M\r\n磁盘[" + d.Name + "]存储空间过小,无法备份");
                        return false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("路径不正确");
                    return false;
                    //throw;
                }
            }

            #endregion

            pBar = bar;
            string strTmp = "";
            string tmpPath = strFileName.Substring(0, strFileName.LastIndexOf("\\")).ToString();
            int isEmpty = tmpPath.IndexOf(" ");
            SQLDMO.SQLServer svr = null;
            try
            {
                svr = new SQLDMO.SQLServerClass();
                // 连接到数据库
                svr.Connect(strServerName, strUserName, strPassword);
                SQLDMO.Backup bak = new SQLDMO.BackupClass();
                bak.Action = 0;
                bak.Initialize = true;

                #region 进度条处理

                if (pBar != null)
                {
                    pBar.Visible = true;
                    SQLDMO.BackupSink_PercentCompleteEventHandler pceh = new SQLDMO.BackupSink_PercentCompleteEventHandler(Step);
                    bak.PercentComplete += pceh;
                }

                #endregion

                #region [ 文件夹名称中有空格: 备份前的处理 ]

                // 文件夹不存在时自动创建
                if (!Directory.Exists(tmpPath))
                {
                    Directory.CreateDirectory(tmpPath);
                }

                // 文件夹名称 中有空格 备份文件路径设置为根目录的临时文件夹tmpBackup中
                if (isEmpty > 1 && strFileName.Substring(4).LastIndexOf("\\") > 1)
                {
                    strTmp = strFileName.Substring(0, 1).ToString() + ":\\tmp_backup.kj";
                }
                else
                {
                    strTmp = strFileName;
                }

                #endregion

                // 数据库的备份的名称及文件存放位置
                bak.Files = strTmp;
                bak.Database = strDbName;

                // 备份
                bak.SQLBackup(svr);
            }
            catch (Exception err)
            {
                if (SqlErrRepair(err.Message.ToString()))
                {
                    BackUPDB(strDbName, strFileName, strServerName, strUserName, strPassword, pBar);
                    return true;
                }
                return false;
                //MessageBox.Show("备份数据库失败");

            }
            finally
            {
                if (svr != null)
                {
                    svr.DisConnect();
                }

                #region [ 文件夹名称中有空格: 备份完成后的处理 ]

                // 文件夹名称 中有空格 将备份的文件移动到用户指定的文件夹并将临时目录删除
                if (isEmpty > 1 && strFileName.Substring(4).LastIndexOf("\\") > 1)
                {
                    // 文件存在则替换
                    if (File.Exists(strFileName.Substring(strFileName.LastIndexOf("\\") + 2)))
                    {
                        File.Delete(strFileName.Substring(strFileName.LastIndexOf("\\") + 2));
                    }
                    File.Move(strTmp, strFileName);
                }

                #endregion
            }
            return true;
        }

        #endregion

        #region [ 方法: 恢复指定数据库文件 ]

        /// <summary>
        /// 恢复指定数据库文件
        /// </summary>
        /// <param name="strDbName">数据库名称</param>
        /// <param name="strFileName">还原文件路径</param>
        /// <param name="strServerName">服务器名称</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strPassword">密码</param>
        /// <returns></returns>
        public static bool RestoreDB(string strDbName, string strFileName, string strServerName, string strUserName, string strPassword, ProgressBar bar)
        {
            pBar = bar;
            SQLDMO.SQLServer sqlServer = new SQLDMO.SQLServerClass();
            string str = "";
            string tmpPath = strFileName.Substring(0, strFileName.LastIndexOf("\\")).ToString();
            int isEmpty = tmpPath.IndexOf(" ");

            try
            {
                // 连接到数据库服务器
                sqlServer.Connect(strServerName, strUserName, strPassword);

                // 获取所有的进程列表
                SQLDMO.QueryResults qr = sqlServer.EnumProcesses(-1);

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
                    if (strDBName.ToUpper() == strDbName.ToUpper())
                    {
                        sqlServer.KillProcess(lPID);
                    }
                }

                // 实例化还原操作对象
                SQLDMO.Restore res = new SQLDMO.RestoreClass();

                // 路径中有空格(不包括文件名) 备份到路径的根目录的临时文件夹tmpBackup中
                if (isEmpty > 1 && strFileName.Substring(4).LastIndexOf("\\") > 1)
                {
                    str = strFileName.Substring(0, 1).ToString() + ":\\tmp_backup.kj";
                    File.Move(strFileName, str);
                }
                else
                {
                    str = strFileName;
                }

                // 数据库存放的路径和要恢复的数据库名字
                res.Files = str;
                res.Database = strDbName;

                // 所恢复的数据库文件的类型
                res.Action = SQLDMO.SQLDMO_RESTORE_TYPE.SQLDMORestore_Database;
                res.ReplaceDatabase = true;

                #region 进度条处理

                if (pBar != null)
                {
                    pBar.Visible = true;
                    SQLDMO.RestoreSink_PercentCompleteEventHandler pceh = new SQLDMO.RestoreSink_PercentCompleteEventHandler(Step);
                    res.PercentComplete += pceh;
                }

                #endregion

                // 执行数据库恢复
                res.SQLRestore(sqlServer);
                return true;
            }
            catch (Exception ex)
            {
                string tmpErr = "还原失败";
                if (ex.Message.IndexOf("文件不是有效的 Microsoft 磁带格式备份集") > 1)
                {
                    tmpErr = "文件格式不正确";
                }
                MessageBox.Show(tmpErr);
                return false;
            }
            finally
            {
                sqlServer.DisConnect();
                // 文件夹名称中有空格 将备份的文件移回到用户指定的文件夹并将临时目录删除
                if (isEmpty > 1 && strFileName.Substring(4).LastIndexOf("\\") > 1)
                {
                    File.Move(str, strFileName);
                }
            }
        }

        #endregion

        #region [ 方法: 扩展数据库 ]

        public static void ShrinkDataBase()
        {
            DBAcess dba = new DBAcess();
            try
            {
                // 数据库名从连接字符串中得到
                string dbName = ConfigurationSettings.AppSettings["ConnectionString"];//dba.ConnectionStringKJ128N;
                dbName = dbName.Substring(dbName.IndexOf("database=") + 9);
                dbName = dbName.Substring(0, dbName.IndexOf(";"));
                dba.GetDataSet("DUMP TRANSACTION " + dbName + " WITH NO_LOG");
                MessageBox.Show("清空日志成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("清空日志失败");
            }
        }

        #endregion

        #region [ 事件: 进度条的变化 ]

        private static void Step(string message, int percent)
        {
            pBar.Value = percent;
            // 当进度达到100时将进度条隐藏
            //if (pBar.Value >= 100)
            //{
            //    pBar.Visible = false;
            //}
        }

        #endregion
    }
}
