using System;
using System.Collections.Generic;
using System.Text;
using Shine.Logs.LogType;

namespace Shine.Logs
{
    /// <summary>
    /// ϵͳ��־
    /// </summary>
    public class SystemLog : Log
    {
        #region [���ԣ�ϵͳ��]

        /// <summary>
        /// ϵͳ��
        /// </summary>
        private string systemName;

        /// <summary>
        /// ϵͳ��
        /// </summary>
        public string SystemName
        {
            get { return systemName; }
            set { systemName = value; }
        }

        #endregion

        #region [���ԣ�ϵͳ��������]

        /// <summary>
        /// ϵͳ��������
        /// </summary>
        private string operate;

        /// <summary>
        /// ϵͳ��������
        /// </summary>
        public string Operate
        {
            get { return operate; }
            set { operate = value; }
        }

        #endregion
    }
}
