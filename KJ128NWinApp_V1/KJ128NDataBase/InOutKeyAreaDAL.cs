﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    /// <summary>
    /// 实时进出井时刻信息DAL类
    /// </summary>
    public class RealTimeInOutKeyAreaDAL
    {
        private DbHelperSQL help = new DbHelperSQL();

        /// <summary>
        /// 查询实时进出重点区域信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>数据表</returns>
        public DataTable SelectRealTimeInOutKeyAreaInfo(string condition)
        {
            SqlParameter[] para = {
                new SqlParameter("@condition",SqlDbType.VarChar,1000)
            };
            para[0].Value = condition;

            return help.ReturnDataTable("SelectInOutKeyAreaTimeInfo", para);
        }
    }

    /// <summary>
    /// 历史进出井时刻信息DAL类
    /// </summary>
    public class HistoryInOutKeyAreaDAL
    {
        private DBAcess dbacc = new DBAcess();

        /// <summary>
        /// 查询历史进出重点区域信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>数据表</returns>
        public DataSet SelectHistoryInOutKeyAreaInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };

            para[0].Value = "InOutKeyAreaTime";
            para[1].Value = "HisTerritorialID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

        }
    }
}
