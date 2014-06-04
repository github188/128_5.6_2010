using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    public class EmpPostModel
    {
        /// <summary>
        /// postID自增列
        /// </summary>
        private int postID;
        /// <summary>
        /// postID自增列
        /// </summary>
        public int PostID
        {
            get { return postID; }
            set { postID = value; }
        }

        /// <summary>
        /// EmpID自增列
        /// </summary>
        private int codeSenderAddress;
        /// <summary>
        /// EmpID自增列
        /// </summary>
        public int CodeSenderAddress
        {
            get { return codeSenderAddress; }
            set { codeSenderAddress = value; }
        }

        /// <summary>
        /// TerritorialID自增列
        /// </summary>
        private int territorialID;
        /// <summary>
        /// TerritorialID自增列
        /// </summary>
        public int TerritorialID
        {
            get { return territorialID; }
            set { territorialID = value; }
        }

        /// <summary>
        /// WorkTime自增列
        /// </summary>
        private int workTime;
        /// <summary>
        /// WorkTime自增列
        /// </summary>
        public int WorkTime
        {
            get { return workTime; }
            set { workTime = value; }
        }

        /// <summary>
        /// Remark自增列
        /// </summary>
        private string remark;
        /// <summary>
        /// Remark自增列
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

    }
}
