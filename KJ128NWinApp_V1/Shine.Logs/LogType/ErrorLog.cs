using System;
using System.Collections.Generic;
using System.Text;

namespace Shine.Logs
{
    public class ErrorLog:Log
    {
        #region [ÊôĞÔ£º´íÎó´úÂë ]

        /// <summary>
        /// ´íÎó´úÂë
        /// </summary>
        private string errorCode;

        /// <summary>
        /// ´íÎó´úÂë
        /// </summary>
        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        #endregion

        #region [ÊôĞÔ£º´íÎóÄÚÈİ]

        /// <summary>
        /// ´íÎóÄÚÈİ
        /// </summary>
        private string errorValue;

        /// <summary>
        /// ´íÎóÄÚÈİ
        /// </summary>
        public string ErrorValue
        {
            get { return errorValue; }
            set { errorValue = value; }
        }

        #endregion
    }
}
