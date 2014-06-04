using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
    /// <summary>
    /// 进出井所有信息统计DAL
    /// </summary>
    public class InOutMineAllDAL
    {
        private DBAcess dbacc = new DBAcess();

        /// <summary>
        /// 查询进出井所有信息
        /// </summary>
        ///<param name="pageIndex">分页索引</param>
        ///<param name="pageSize">每页记录条数</param>
        ///<param name="where">查询条件</param>
        /// <returns>数据集</returns>
        public DataSet SelectInOutMineAllInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };

            para[0].Value = "zjw_RtAndHisInOutMine";
            para[1].Value = "ID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);

        }
    }
}
