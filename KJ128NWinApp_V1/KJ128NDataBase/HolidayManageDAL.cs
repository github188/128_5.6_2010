using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HolidayManageDAL
    {
        DBAcess DB = new DBAcess();

        #region 添加请假信息
        public int HolidayManage_Insert(int intBlockID, string strEmployeeName, int intDeptID, string strBeginWorkDate, string strHolidayName, int intOperatorID, int ClassID, out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BlockID",SqlDbType.Int,4),
                new SqlParameter("@EmployeeName",SqlDbType.VarChar,20),
                new SqlParameter("@DeptID",SqlDbType.Int,4),
                new SqlParameter("@BeginWorkDate",SqlDbType.VarChar,20),
                new SqlParameter("@HolidayName",SqlDbType.VarChar,20),
                new SqlParameter("@OperatorID",SqlDbType.Int,4)
                //new SqlParameter("@ClassID",SqlDbType.Int,4)
            };

            parameters[0].Value = intBlockID;
            parameters[1].Value = strEmployeeName;
            parameters[2].Value = intDeptID;
            parameters[3].Value = strBeginWorkDate;
            parameters[4].Value = strHolidayName;
            parameters[5].Value = intOperatorID;
            //parameters[6].Value = ClassID;
            

            return DB.ExecuteSql("Shine_HistoryHolidays_Add", parameters, out strErr);
        }
        #endregion

        #region 更新请假信息
        public int HolidayManage_Update(long intID, int intBlockID, string strEmployeeName, int intDeptID, string strBeginWorkDate, string strHolidayName, int intOperatorID,int ClassID, out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.BigInt,4),
                new SqlParameter("@BlockID",SqlDbType.Int,4),
                new SqlParameter("@EmployeeName",SqlDbType.VarChar,20),
                new SqlParameter("@DeptID",SqlDbType.Int,4),
                new SqlParameter("@BeginWorkDate",SqlDbType.VarChar,20),
                new SqlParameter("@HolidayName",SqlDbType.VarChar,20),
                new SqlParameter("@OperatorID",SqlDbType.Int,4)
                //new SqlParameter("@ClassID",SqlDbType.Int,4)
            };

            parameters[0].Value = intID;
            parameters[1].Value = intBlockID;
            parameters[2].Value = strEmployeeName;
            parameters[3].Value = intDeptID;
            parameters[4].Value = strBeginWorkDate;
            parameters[5].Value = strHolidayName;
            parameters[6].Value = intOperatorID;
           // parameters[7].Value = ClassID;

            return DB.ExecuteSql("Shine_HistoryHolidays_Update", parameters, out strErr);
        }
        #endregion

        #region 删除请假信息
        public int HolidayManage_Delete(long intID,string strTableName,out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.BigInt),
                new SqlParameter("@strTableName",SqlDbType.VarChar,20)
            };

            parameters[0].Value = intID;
            parameters[1].Value = strTableName;

            return DB.ExecuteSql("Shine_HistoryHolidays_Delete", parameters, out strErr);
        }
        #endregion

        #region 查询请假信息
        public DataSet HolidayManage_Query(int intPageIndex, int intPageSize, string strWhere, string strTableName, string strTableName2)
        {            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4),
                new SqlParameter("@strWhere",SqlDbType.VarChar,300),
                new SqlParameter("@tableName",SqlDbType.VarChar,20),
                new SqlParameter("@tableName2",SqlDbType.VarChar,20)
            };

            parameters[0].Value = intPageIndex;
            parameters[1].Value = intPageSize;
            parameters[2].Value = strWhere;
            parameters[3].Value = strTableName;
            parameters[4].Value = strTableName2;

            return DB.ExecuteSqlDataSet("Shine_HistoryHolidays_Query", parameters);            
        }
        #endregion

        #region 【根据部门获取标识卡信息】
        /// <summary>
        /// 根据部门获取标识卡号信息
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public DataSet GetEmpInfo(string deptID)
        {
            string strWhere = "";
            if (deptID.Trim() != "")
            {
                strWhere = "e.DeptID=" + deptID;
            }
            else
            {
                strWhere = "1=1";
            }
            string strSql = "select convert(varchar(20),cs.CodeSenderAddress) as CodeSenderAddress,e.empName from emp_info e join CodeSender_Set cs ON e.empid=cs.userID AND cs.CsTypeID = 0 where  " + strWhere;
            return DB.GetDataSet(strSql);
        }
        #endregion
    }
}
