using System;
using System.Collections.Generic;
using System.Text;
using Shine.Logs.LogType;

namespace Shine.Logs
{
    /// <summary>
    /// 升级日志
    /// </summary>
    public class UpdateLog : Log
    {
        #region [属性：升级版本]

        /// <summary>
        /// 升级版本
        /// </summary>
        private string updateVerson;

        /// <summary>
        /// 升级版本
        /// </summary>
        public string UpdateVerson
        {
            get { return updateVerson; }
            set { updateVerson = value; }
        }

        #endregion

        #region [属性：升级内容]

        /// <summary>
        /// 升级内容
        /// </summary>
        private string updateValue;

        /// <summary>
        /// 升级内容
        /// </summary>
        public string UpdateValue
        {
            get { return updateValue; }
            set { updateValue = value; }
        }

        #endregion
    }
}
