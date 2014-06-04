using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HolidayTypeDAL
    {
        DBAcess DB = new DBAcess();

        #region 添加假类型
        public int HolidayType_Insert(string strHolidayCode, string strHolidayName, string strHolidayAcronym, string remark, out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HolidayCode",SqlDbType.VarChar,20),
                new SqlParameter("@HolidayName",SqlDbType.VarChar,20),
                new SqlParameter("@HolidayAcronym",SqlDbType.VarChar,10),
                new SqlParameter("@remark",SqlDbType.VarChar,200),
                new SqlParameter("@ID",SqlDbType.Int)
            };

            parameters[0].Value = strHolidayCode;
            parameters[1].Value = strHolidayName;
            parameters[2].Value = strHolidayAcronym;
            //if (remark.Length == 0)
            //{
            //    remark = "";
            //}
            parameters[3].Value = remark;
            parameters[4].Value = strHolidayCode.GetHashCode();

            return DB.ExecuteSql("Shine_HolidayType_Add", parameters, out strErr);
        }
        #endregion

        #region 更新假别类型
        public int HolidayType_Update(int intID, string strHolidayCode, string strHolidayName, string strHolidayAcronym,string remark, out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4),
                new SqlParameter("@HolidayCode",SqlDbType.VarChar,20),
                new SqlParameter("@HolidayName",SqlDbType.VarChar,20),
                new SqlParameter("@HolidayAcronym",SqlDbType.VarChar,10),
                new SqlParameter("@remark",SqlDbType.VarChar,200)
            };

            parameters[0].Value = intID;
            parameters[1].Value = strHolidayCode;
            parameters[2].Value = strHolidayName;
            parameters[3].Value = strHolidayAcronym;
            parameters[4].Value = remark;

            return DB.ExecuteSql("Shine_HolidayType_Update", parameters, out strErr);
        }
        #endregion

        #region 删除假别类型
        public int HolidayType_Delete(int intID, out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4),
            };

            parameters[0].Value = intID;

            return DB.ExecuteSql("Shine_HolidayType_Delete", parameters, out strErr);
        }
        #endregion

        #region 假别类型查询
        public DataSet HolidayType_Query(string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,200),
            };

            parameters[0].Value = strWhere;

            return DB.ExecuteSqlDataSet("Shine_HolidayType_Query", parameters);
        }
        #endregion
    }
}
