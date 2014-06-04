using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace KJ128A.DataSave
{
    /// <summary>
    /// 主备数据库同步
    /// </summary>
    public class DataBaseSync:IDisposable
    {
        private DataBaseManage dbm;

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

        #region [ 方法: 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataBaseSync()
        {
            try
            {
                dbm = new DataBaseManage();
                dbm.SyncComplete += new DataBaseManage.SyncCompleteEventHandler(dbm_SyncComplete);
                dbm.GuageEvent += new DataBaseManage.GuageEventHandler(dbm_GuageEvent);
                dbm.ErrorMessage += new DataBaseManage.ErrorMessageEventHandler(dbm_ErrorMessage);
            }
            catch (Exception errInfo)
            {
                // 缺少sqldmo.dll文件
                if (errInfo.Message.IndexOf("10020100-E260-11CF-AE68-00AA004A34D5") > 0 || errInfo.Message.IndexOf("10020200-E260-11CF-AE68-00AA004A34D5") > 0)
                {
                    try
                    {
                        
                        // "缺少sqldmo.dll" 修复
                        //File.Copy(Application.StartupPath + "\\filebackup\\sqldmo.dll", @"C:\Program Files\Microsoft SQL Server\80\Tools\Binn\sqldmo.dll");
                    }catch(Exception ce)
                    {
                        ErrorMessage(2021504, ce.StackTrace, "[DataBaseSync:DataBaseSync]", "sqldmo修复失败");
                        //"sqldmo修复失败";
                    }
                }
                else if (errInfo.Message.IndexOf("0022406-E260-11CF-AE68-00AA004A34D5") > 0)
                {

                    //dbm_ErrorMessage(1, "", "[ DBBackUp:DBBackUp ]", "SqlServer2000 SP4补丁未安装或未安装完整");
                    //"SqlServer2000 SP4补丁未安装或未安装完整";
                }
            }
        }

        void dbm_SyncComplete()
        {
            if (SyncComplete != null)
            {
                SyncComplete();
            }
        }

        void dbm_GuageEvent(int percent)
        {
            if (GuageEvent != null)
            {
                GuageEvent(percent);
            }
        }

        void dbm_ErrorMessage(int iErrNO, string strStackTrace, string strSource, string strMessage)
        {
            if (ErrorMessage != null)
            {
                ErrorMessage(iErrNO, strStackTrace,strSource,strMessage);
            }
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="oldDbName">原数据库名</param>
        /// <param name="backUpName">备数据库名</param>
        /// <param name="backUpPath">备数据库文件路径</param>
        /// <param name="oldDbPath">原数据库文件路径</param>
        public DataBaseSync(string oldDbName, string backUpName, string backUpPath, string oldDbPath)
        {
            try
            {
                dbm = new DataBaseManage(oldDbName,backUpName,backUpPath,oldDbPath);
            }
            catch (Exception errInfo)
            {
                // 缺少sqldmo.dll文件
                if (errInfo.Message.IndexOf("10020100-E260-11CF-AE68-00AA004A34D5") > 0 || errInfo.Message.IndexOf("10020200-E260-11CF-AE68-00AA004A34D5") > 0)
                {
                    try
                    {
                        // "缺少sqldmo.dll" 修复
                        File.Copy(Application.StartupPath + "\\filebackup\\sqldmo.dll", @"C:\Program Files\Microsoft SQL Server\80\Tools\Binn\sqldmo.dll");
                    }
                    catch (Exception)
                    {
                        //"sqldmo修复失败";
                    }
                }
                else if (errInfo.Message.IndexOf("0022406-E260-11CF-AE68-00AA004A34D5") > 0)
                {
                    //"SqlServer2000 SP4补丁未安装或未安装完整";
                    //dbm_ErrorMessage(1, "", "[ DBBackUp:DBBackUp ]", "SqlServer2000 SP4补丁未安装或未安装完整");
                }
            }
        }

        #endregion

        #region [ 方法: 停止数据库同步 ]

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            dbm.Close();
        }

        #endregion

        #region [ 方法: 连接数据库 ]

        ///// <summary>
        ///// 初始化连接数据库
        ///// </summary>
        ///// <returns></returns>
        //public bool LinkSqlServer()
        //{
        //    return dbm.LinkSql();
        //}

        #endregion

        #region [ 方法: 检测数据库 ]

        /// <summary>
        /// 检测数据库
        /// </summary>
        /// <returns></returns>
        public bool InitCheckDB()
        {
            // 初始化检测数据库
            return dbm.InitCheckDB();
        }

        #endregion

        #region [ 方法: 检测 KJ128NBackUp数据库是否存在 ]

        /// <summary>
        /// 检测数据库
        /// </summary>
        /// <returns></returns>
        public bool CheckBackUpDBState()
        {
            // 初始化检测数据库
            return dbm.CheckBackUpDBState();
        }

        #endregion

        #region [ 方法: 删除备数据库 ]

        /// <summary>
        /// 删除备数据库
        /// </summary>
        /// <returns></returns>
        public bool DBDeleteBackUP()
        {
            return dbm.DBDelete();
        }

        #endregion

        #region [ 方法: 主备数据库同步 ]

        /// <summary>
        /// 主备数据库同步
        /// </summary>
        /// <returns></returns>
        public void DBSync()
        {
            dbm.DBSync();
        }

        #endregion

        #region [ 方法: 错误处理 ]

        /// <summary>
        /// 处理错误
        /// </summary>
        /// <param name="iErrNO">错误编号</param>
        public void ErrorMessageFun(int iErrNO)
        {
            string strErrMsg = string.Empty;        // 错误消息内容
            switch (iErrNO)
            {
                case 2023048:
                    strErrMsg = "SqlServer连接失败";
                    break;
                case 2021504:
                    strErrMsg = "数据库不存在或访问被拒绝";
                    break;
                default: break;
            }
        }

        #endregion

        #region [ 方法: 释放 ]

        /// <summary>
        /// 释放对象
        /// </summary>
        public void Dispose()
        {
            dbm.Dispose();
        }

        #endregion
    }
}
