using System;
using System.Collections.Generic;
using System.Text;
using Shine.Logs.LogType;

namespace Shine.Logs
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class SystemLog : Log
    {
        #region [属性：系统名]

        /// <summary>
        /// 系统名
        /// </summary>
        private string systemName;

        /// <summary>
        /// 系统名
        /// </summary>
        public string SystemName
        {
            get { return systemName; }
            set { systemName = value; }
        }

        #endregion

        #region [属性：系统操作内容]

        /// <summary>
        /// 系统操作内容
        /// </summary>
        private string operate;

        /// <summary>
        /// 系统操作内容
        /// </summary>
        public string Operate
        {
            get { return operate; }
            set { operate = value; }
        }

        #endregion
    }
}
