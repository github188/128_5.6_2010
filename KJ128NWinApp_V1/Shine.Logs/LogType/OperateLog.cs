using System;
using System.Collections.Generic;
using System.Text;

namespace Shine.Logs
{
    /// <summary>
    /// ������־
    /// </summary>
    public class OperateLog : Log
    {
        #region [���ԣ�������Ա]

        /// <summary>
        /// ������Ա
        /// </summary>
        private string operater;

        /// <summary>
        /// ������Ա
        /// </summary>
        public string Operater
        {
            get { return operater; }
            set { operater = value; }
        }

        #endregion

        #region[���ԣ���������]

        /// <summary>
        /// ��������
        /// </summary>
        private string operateValue;

        /// <summary>
        /// ��������
        /// </summary>
        public string OperateValue
        {
            get { return operateValue; }
            set { operateValue = value; }
        }

        #endregion
    }
}
