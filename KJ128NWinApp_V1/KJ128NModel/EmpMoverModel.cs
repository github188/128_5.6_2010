using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    public class EmpMoverModel
    {
        private string _EmpName;
        /// <summary>
        /// 雇员姓名
        /// </summary>
        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; }
        }
        
        private string _EmpID;
        /// <summary>
        /// 雇员id
        /// </summary>
        public string EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        public EmpMoverModel()
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="empname">雇员姓名</param>
        /// <param name="empid">雇员ID</param>
        public EmpMoverModel(string empname, string empid)
        {
            this.EmpName = empname;
            this.EmpID = empid;
        }
    }
}
