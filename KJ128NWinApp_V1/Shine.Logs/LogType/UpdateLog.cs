using System;
using System.Collections.Generic;
using System.Text;
using Shine.Logs.LogType;

namespace Shine.Logs
{
    /// <summary>
    /// ������־
    /// </summary>
    public class UpdateLog : Log
    {
        #region [���ԣ������汾]

        /// <summary>
        /// �����汾
        /// </summary>
        private string updateVerson;

        /// <summary>
        /// �����汾
        /// </summary>
        public string UpdateVerson
        {
            get { return updateVerson; }
            set { updateVerson = value; }
        }

        #endregion

        #region [���ԣ���������]

        /// <summary>
        /// ��������
        /// </summary>
        private string updateValue;

        /// <summary>
        /// ��������
        /// </summary>
        public string UpdateValue
        {
            get { return updateValue; }
            set { updateValue = value; }
        }

        #endregion
    }
}
