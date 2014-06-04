using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class RealTimeDirectionalDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private DataSet ds;

        private string strSql = string.Empty;

        #endregion


        #region [ 方法: 获取部门信息 ]

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns>部门信息(DataSet)</returns>
        public DataSet N_GetDeptInfo()
        {
            strSql = " Select DeptID, ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark From Dept_Info Order By DeptLevelID ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询实时方向性信息 ]

        public DataSet N_GetRTDirectional(string strDept, string strName, string strCardAddress, string strStation, string strStaHead, bool blIsEmp, string strDirectional)
        {
            string procName = "KJ128N_RTDirectionalAll_Select";
            SqlParameter[] sqlParmeters ={
                            new SqlParameter("sumType",SqlDbType.Int),
                            new SqlParameter("strName",SqlDbType.NVarChar,20),
                            new SqlParameter("DeptName",SqlDbType.NVarChar,2000),
                            new SqlParameter("CodeSenderAddress",SqlDbType.NVarChar,20),
                            new SqlParameter("StationAddress",SqlDbType.Int),
                            new SqlParameter("StaHeadAddress",SqlDbType.Int),
                            new SqlParameter("strDirectional",SqlDbType.NVarChar,2000)
            };
            if (blIsEmp)
            {
                sqlParmeters[0].Value = 0;
            }
            else
            {
                sqlParmeters[0].Value = 1;
            }
            sqlParmeters[1].Value = strName;
            sqlParmeters[2].Value = strDept;
            sqlParmeters[3].Value = strCardAddress;
            sqlParmeters[4].Value = Convert.ToInt32(strStation);
            sqlParmeters[5].Value = Convert.ToInt32(strStaHead);
            sqlParmeters[6].Value = strDirectional;

            return dbacc.GetDataSet(procName, sqlParmeters);

        }

        #endregion

        #region [ 方法: 根据分站地址查询分站位置 ]

        public string N_SelectStationPlace(string strStation)
        {
            strSql = " Select StationPlace From Station_Info Where StationAddress=" + strStation;
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
