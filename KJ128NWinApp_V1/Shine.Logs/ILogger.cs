using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection; 
using System.Data;
using Shine.Logs.LogType;
using Shine.Command;

namespace Shine.Logs
{
    public class ILogger
    {
        #region [ 公有方法：写入日志 ]

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="strFilePath">日志路径</param>
        /// <param name="s1">内容1：
        /// EnumLogType.ErrorLog;(错误代码)
        /// EnumLogType.OperateLog;(操作员)
        /// EnumLogType.SuggestionLog;(建议人)
        /// EnumLogType.SystemLog;(系统名)
        /// EnumLogType.UpdateLog;(更新版本)
        /// </param>
        /// 
        /// <param name="s2">内容2
        /// EnumLogType.ErrorLog;(错误内容)
        /// EnumLogType.OperateLog;(操作内容)
        /// EnumLogType.SuggestionLog;(建议内容)
        /// EnumLogType.SystemLog;(系统操作内容)
        /// EnumLogType.UpdateLog;(更新内容)
        /// </param>
        /// <param name="enumLogType">日志类型</param>
        /// <returns>是否保存成功</returns>
        public static bool Write(EnumLogType enumLogType, string strFilePath, string s1, string s2)
        {
            Log log = null;

            switch (enumLogType)
            {
                case EnumLogType.ErrorLog:
                    log = new ErrorLog();
                    ((ErrorLog)log).ErrorCode = s1;
                    ((ErrorLog)log).ErrorValue = s2;
                    break;

                case EnumLogType.OperateLog:
                    log = new OperateLog();
                    ((OperateLog)log).Operater = s1;
                    ((OperateLog)log).OperateValue = s2;
                    break;

                case EnumLogType.SuggestionLog:
                    log = new SuggestionLog();
                    ((SuggestionLog)log).Sender = s1;
                    ((SuggestionLog)log).SuggestionValue = s2;
                    break;

                case EnumLogType.SystemLog:
                    log = new SystemLog();
                    ((SystemLog)log).SystemName = s1;
                    ((SystemLog)log).Operate = s2;
                    break;

                case EnumLogType.UpdateLog:
                    log = new UpdateLog();
                    ((UpdateLog)log).UpdateVerson = s1;
                    ((UpdateLog)log).UpdateValue = s2;
                    break;

                default:
                    break;
            }

            //return SaveLogData(log, strFilePath);
            return log.SaveLogData(strFilePath);
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="enumLogType">日志类型</param>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool Write(EnumLogType enumLogType, string s1, string s2)
        {
            string path = GetSavePath(enumLogType);
            return Write(enumLogType, path, s1, s2);
        }

        /// <summary>
        /// 保存错误日志
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteErrorLog(string strFilePath, string s1, string s2)
        {
           return Write(EnumLogType.ErrorLog, strFilePath, s1, s2);
        }

        /// <summary>
        /// 保存错误日志
        /// </summary>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteErrorLog(string s1, string s2)
        {
            return Write(EnumLogType.ErrorLog, s1, s2);
        }

        /// <summary>
        /// 保存操作日志
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteOperateLog(string strFilePath, string s1, string s2)
        {
            return Write(EnumLogType.OperateLog, strFilePath, s1, s2);
        }

        /// <summary>
        /// 保存操作日志
        /// </summary>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteOperateLog(string s1, string s2)
        {
            return Write(EnumLogType.OperateLog, s1, s2);
        }

        /// <summary>
        /// 保存建议日志
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteSuggestionLog(string strFilePath, string s1, string s2)
        {
            return Write(EnumLogType.SuggestionLog, strFilePath, s1, s2);
        }

        /// <summary>
        /// 保存建议日志
        /// </summary>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteSuggestionLog(string s1, string s2)
        {
            return Write(EnumLogType.SuggestionLog, s1, s2);
        }

        /// <summary>
        /// 保存升级日志
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteSystemLog(string strFilePath, string s1, string s2)
        {
            return Write(EnumLogType.SystemLog, strFilePath, s1, s2);
        }

        /// <summary>
        /// 保存系统日志
        /// </summary>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteSystemLog(string s1, string s2)
        {
            return Write(EnumLogType.SystemLog, s1, s2);
        }

        /// <summary>
        /// 保存升级日志
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteUpdateLog(string strFilePath, string s1, string s2)
        {
            return Write(EnumLogType.UpdateLog, strFilePath, s1, s2);
        }

        /// <summary>
        /// 保存升级日志
        /// </summary>
        /// <param name="s1">内容1</param>
        /// <param name="s2">内容2</param>
        /// <returns>返回是否保存成功</returns>
        public static bool WriteUpdateLog(string s1, string s2)
        {
            return Write(EnumLogType.UpdateLog, s1, s2);
        }


        #endregion

        #region [ 私有方法: 根据不同的日志获取路径 ]

        /// <summary>
        /// 根据不同的日志获取路径
        /// </summary>
        /// <param name="log">日志对象</param>
        /// <returns>返回路径</returns>
        private static string GetSavePath(EnumLogType enumLogType)
        {
            string path=String.Empty;

            switch (enumLogType)
            {
                case EnumLogType.SystemLog:
                    return path = @"AppLogs\SystemLog.xml";
                    //break;

                case EnumLogType.ErrorLog:
                    return path = @"AppLogs\ErrorLog.xml";
                    //break;

                case EnumLogType.OperateLog:
                    return path = @"AppLogs\OperateLog.xml";
                    //break;

                case EnumLogType.UpdateLog:
                    return path = @"AppLogs\UpdateLog.xml";
                    //break;

                case EnumLogType.SuggestionLog:
                    return path = @"AppLogs\SuggestionLog.xml";
                    //break;

                default:
                    return path = "";
                    //break;
            }
        }

        #endregion

        #region [公有方法：查询日志]

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <param name=param name="enumLogType">日志类型</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetLogs(string path, EnumLogType enumLogType)
        {
            try
            {
                Log log = null;

                switch (enumLogType)
                {
                    case EnumLogType.ErrorLog:
                        log = new ErrorLog();

                        break;

                    case EnumLogType.OperateLog:
                        log = new OperateLog();

                        break;

                    case EnumLogType.SuggestionLog:
                        log = new SuggestionLog();

                        break;

                    case EnumLogType.SystemLog:
                        log = new SystemLog();

                        break;

                    case EnumLogType.UpdateLog:
                        log = new UpdateLog();

                        break;

                    default:
                        break;
                }

                DataTable dt = new DataTable();

                PropertyInfo[] pinfo = log.GetType().GetProperties();

                for (int i = 0; i < pinfo.Length; i++)
                {
                    DataColumn dc = new DataColumn(pinfo[i].Name);
                    dt.Columns.Add(dc);
                }


                XmlDocument doc = XMLHelper.EntityToXmlByObject(path, log);
                
                XmlNode node = doc.SelectSingleNode(log.GetType().Name);

                if (node != null)
                {
                    foreach (XmlNode lognode in node.ChildNodes)
                    {
                        DataRow dr = dt.NewRow();
                        foreach (XmlNode cnode in lognode.ChildNodes)
                        {
                            dr[cnode.Name] = cnode.InnerText;
                        }
                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="enumLogType">日志类型</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetLogs(EnumLogType enumLogType)
        {
            string path = GetSavePath(enumLogType);
            return GetLogs(path, enumLogType);
        }

        /// <summary>
        /// 查询错误日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetErrorLog(string path)
        {
            return GetLogs(path, EnumLogType.ErrorLog);
        }

        /// <summary>
        /// 查询错误日志
        /// </summary>
        /// <returns>日志DataTable</returns>
        public static DataTable GetErrorLog()
        {
            return GetLogs(EnumLogType.ErrorLog);
        }

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetOperateLog(string path)
        {
            return GetLogs(path, EnumLogType.OperateLog);
        }

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetOperateLog()
        {
            return GetLogs(EnumLogType.OperateLog);
        }

        /// <summary>
        /// 查询建议日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetSuggestionLog(string path)
        {
            return GetLogs(path, EnumLogType.SuggestionLog);
        }

        /// <summary>
        /// 查询建议日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetSuggestionLog()
        {
            return GetLogs(EnumLogType.SuggestionLog);
        }

        /// <summary>
        /// 查询系统日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetSystemLog(string path)
        {
            return GetLogs(path, EnumLogType.SystemLog);
        }

        /// <summary>
        /// 查询系统日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetSystemLog()
        {
            return GetLogs(EnumLogType.SystemLog);
        }

        /// <summary>
        /// 查询升级日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetUpdateLog(string path)
        {
            return GetLogs(path, EnumLogType.UpdateLog);
        }

        /// <summary>
        /// 查询升级日志
        /// </summary>
        /// <param name="path">日志路径</param>
        /// <returns>日志DataTable</returns>
        public static DataTable GetUpdateLog()
        {
            return GetLogs(EnumLogType.UpdateLog);
        }

        #endregion
    }
}
