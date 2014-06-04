using System;
using System.Collections.Generic;
using System.Text;

namespace Shine.Logs
{
    /// <summary>
    /// ������־
    /// </summary>
    public class SuggestionLog:Log
    {
        #region [���ԣ���������]

        /// <summary>
        /// ��������
        /// </summary>
        private string suggestionValue;

        /// <summary>
        /// ��������
        /// </summary>
        public string SuggestionValue
        {
            get { return suggestionValue; }
            set { suggestionValue = value; }
        }

        #endregion

        #region [���ԣ�������]

        /// <summary>
        /// ������
        /// </summary>
        private string sender;

        /// <summary>
        /// ������
        /// </summary>
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        #endregion
    }
}
