using System;
using System.Collections.Generic;
using System.Text;
using Shine.Logs.LogType;
using System.Windows.Forms;
using KJ128NDBTable;

namespace Shine.Logs
{
    public static class LogSave
    {
        /// <summary>
        /// 保存系统配置日志
        /// </summary>
        ///<param name="strClassName">模块信息，如[FrmMain]</param>
        /// <param name="logIDType">日志信息枚举值</param>
        /// <param name="strlog">日志信息</param>
        public static void Messages(string strClassName, LogIDType logIDType, string strlog)
        {

            ILogger.Write(EnumLogType.OperateLog, Application.StartupPath + "\\KJ128ALog\\"+ DateTime.Now.ToString("yyyy-MM-dd") + ".xml", LoginBLL.user, strlog);

            return;
        }
    }
}
