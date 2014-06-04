using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HisOverTimeInfoDAL
    {
        private DBAcess dbacc = new DBAcess();

        #region 获取部门 基本信息
        /// <summary>
        /// 获取 部门信息
        /// </summary>
        /// <returns>部门信息(DataSet)</returns>
        public DataSet GetDeptInfo()
        {
            string strSql = " Select DeptID, ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark From Dept_Info Order By DeptLevelID";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region 查询历史超时信息
        public DataSet GetOverTimeSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "KJ128N_HisOverTime_Info";
            para[1].Value = "HisOverTimeAlarmID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion
    }
}
