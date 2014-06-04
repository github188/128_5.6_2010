using System;
using System.Collections.Generic;
using System.Text;

namespace Shine.Logs
{
    /// <summary>
    /// 建议日志
    /// </summary>
    public class SuggestionLog:Log
    {
        #region [属性：建议内容]

        /// <summary>
        /// 建议内容
        /// </summary>
        private string suggestionValue;

        /// <summary>
        /// 建议内容
        /// </summary>
        public string SuggestionValue
        {
            get { return suggestionValue; }
            set { suggestionValue = value; }
        }

        #endregion

        #region [属性：建议人]

        /// <summary>
        /// 建议人
        /// </summary>
        private string sender;

        /// <summary>
        /// 建议人
        /// </summary>
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        #endregion
    }
}
