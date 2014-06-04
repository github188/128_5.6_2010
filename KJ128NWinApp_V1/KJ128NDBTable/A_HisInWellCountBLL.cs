using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class A_HisInWellCountBLL
    {
        #region【声明】

        private A_HisInWellCountDAL his = new A_HisInWellCountDAL();

        #endregion

        #region【方法：获取部门信息（树）——历史超时】

        public DataSet GetDeptTree()
        {
            return his.GetDeptTree();
        }

        #endregion

        #region【方法：人员下井次数统计】

        public DataSet GetInfo_HisInWellCounts(int pageIndex, int pageSize, string where, string strDateTime,string TableName,string TableName2)
        {
            return his.GetInfo_HisInWellCounts(pageIndex, pageSize, where, strDateTime, TableName, TableName2);
        }

        #endregion

        #region【Czlt-2010-11-03】
        /// <summary>
        /// 添加历史上下井记录 在his_InOutMine_yyyyM表中
        /// </summary>
        /// <param name="drHis"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public int AddHisInOutMineBll(DataRow drHis, string strTableName)
        {
            return his.AddHisInOutMine(drHis, strTableName);
        }

        /// <summary>
        /// 查找井口分站信息
        /// </summary>
        /// <returns></returns>
        public string GetStationHeadInfo()
        {
            return his.GetStationHeadInfoDal();
        }

        /// <summary>
        /// 返回查找人员信息
        /// </summary>
        /// <param name="strEmpId"></param>
        /// <returns></returns>
        public DataSet GetEmpInfoBll(string strEmpId)
        {
            return his.GetEmpInfo(strEmpId);
        }

        /// <summary>
        /// 查询记工日期中该员工要补的班次是不是已经存在
        /// </summary>
        /// <param name="strTableName">表的名称</param>
        /// <param name="blockId">标识卡ID</param>
        /// <param name="employeeId">员工ID</param>
        /// <param name="classId">班制ID</param>
        /// <param name="classShortName">班次名</param>
        /// <param name="dataAttendance">记工日期</param>
        /// <returns></returns>
        public bool GetEmpClassInfo(string strTableName, string blockId, string employeeId, string classId, string classShortName, string dataAttendance)
        {
            return his.FindEmpClassInfo(strTableName, blockId, employeeId, classId, classShortName, dataAttendance);
        }
        #endregion


        #region【Czlt-2010-12-07 查找工种树】
        public DataSet GetWorkTypeTree()
        {
            return his.GetWorkTypeTree();
        }
        #endregion

        #region【Czlt-2010-12-07 查找职务树】
        public DataSet GetDutyTree()
        {
            return his.GetDutyTree();
        }
        #endregion
    }
}
