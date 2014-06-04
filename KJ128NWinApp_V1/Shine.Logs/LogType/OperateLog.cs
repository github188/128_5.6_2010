using System;
using System.Collections.Generic;
using System.Text;

namespace Shine.Logs
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class OperateLog : Log
    {
        #region [属性：操作人员]

        /// <summary>
        /// 操作人员
        /// </summary>
        private string operater;

        /// <summary>
        /// 操作人员
        /// </summary>
        public string Operater
        {
            get { return operater; }
            set { operater = value; }
        }

        #endregion

        #region[属性：操作内容]

        /// <summary>
        /// 操作内容
        /// </summary>
        private string operateValue;

        /// <summary>
        /// 操作内容
        /// </summary>
        public string OperateValue
        {
            get { return operateValue; }
            set { operateValue = value; }
        }

        #endregion
    }
}
