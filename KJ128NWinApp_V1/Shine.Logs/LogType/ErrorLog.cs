using System;
using System.Collections.Generic;
using System.Text;

namespace Shine.Logs
{
    public class ErrorLog:Log
    {
        #region [���ԣ�������� ]

        /// <summary>
        /// �������
        /// </summary>
        private string errorCode;

        /// <summary>
        /// �������
        /// </summary>
        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        #endregion

        #region [���ԣ���������]

        /// <summary>
        /// ��������
        /// </summary>
        private string errorValue;

        /// <summary>
        /// ��������
        /// </summary>
        public string ErrorValue
        {
            get { return errorValue; }
            set { errorValue = value; }
        }

        #endregion
    }
}
