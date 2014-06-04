using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class RT_InOutMineEmpNameListBLL
    {

        #region[声明]
        RT_InOutMineEmpNameListDAL dal = new RT_InOutMineEmpNameListDAL();
        #endregion



        #region[获取实时员工部门ID和部门人数]
        public DataTable RT_Dept()
        {
            return dal.RT_Dept();
        }
        #endregion

        #region[获取部门名]
        public DataTable RT_DeptID(string ID)
        {
            return dal.RT_DeptID(ID);
        }
        #endregion


        #region[根据部门ID获取下井员工信息]
        public DataTable get_mes(string DeptID)
        {
            return dal.get_mes(DeptID);
        }
        #endregion




        #region[获取实时井下人员的信息]
        public DataTable RT_InOutEmp(string str)
        {
            return dal.RT_InOutEmp(str);
        }

        public DataSet RT_InOutEmp(int pageIndex, int pageSize, string where)
        {
            return dal.RT_InOutEmp(pageIndex, pageSize, where);
        }
        #endregion


        public DataTable ALL_DeptNAME(string id)
        {
            return dal.ALL_DeptNAME(id);
        }

        public DataTable GetEmpID()
        {
            return dal.GetEmpID();
        }

        public DataTable GetImage(string id)
        {
            return dal.GetImage(id);
        }

        #region[获取实时井下人员的数量]
        public string RTcount()
        {
            return dal.RTcount();
        }
        #endregion

        #region 【方法：根据时间获取下井人员信息】
        /// <summary>
        /// 根据条件获取下井人员信息
        /// </summary>
        /// <param name="dateTimeStart">开始时间</param>
        /// <param name="dateTimeEnd">结束时间</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable GetEmpRealTimeOutMine(DateTime dateTimeStart,DateTime dateTimeEnd,string strWhere)
        {
            return dal.GetEmpRealTimeOutMine(dateTimeStart, dateTimeEnd,strWhere);
        }
        #endregion

        #region 【方法：根据当前时间获取当班范围时间】
        public DataTable GetClassTimeByNowTime(DateTime dateTimeNow)
        {
            return dal.GetClassTimeByNowTime(dateTimeNow);
        }
        #endregion
    }
}
