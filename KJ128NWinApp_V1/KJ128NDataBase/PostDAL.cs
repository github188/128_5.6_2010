using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    /// <summary>
    /// 实时岗位异常
    /// </summary>
    public class RealTimePostDAL
    {
        private DbHelperSQL help = new DbHelperSQL();
        private string outStr = String.Empty;

        /// <summary>
        /// 查询实时岗位信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回查询结果</returns>
        public DataTable SelectRealTimePostInfo(string condition)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@condition", SqlDbType.VarChar, 1000) };

            para[0].Value = condition;

            return help.ReturnDataTable("SelectRealTimePostInfo", para);
        }

        /// <summary>
        /// 查询岗位异常报警信息
        /// </summary>
        /// <returns>返回查询结果</returns>
        public DataTable SelectRealTimePostAlarmInfo(string condition)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@condition", SqlDbType.VarChar, 1000) };

            para[0].Value = condition;

            return help.ReturnDataTable("SelectRealTimeAlarmPostInfo", para);
        }

        /// <summary>
        /// 修改实时岗位异常报警信息措施信息
        /// </summary>
        /// <param name="id">异常报警信息id</param>
        /// <param name="measure">措施内容</param>
        /// <returns>返回影响的行数</returns>
        public int UpdateRealTimePostAlarmInfoMeasure(int id, string measure)
        {

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@measure", SqlDbType.VarChar,100)};
            para[0].Value = id;
            para[1].Value = measure;

            return help.RunProcedureByInt("UpdateRealTimePostMeasure", para, out outStr);
        }

        /// <summary>
        /// 删除（完成）实时岗位异常报警信息，再写入历史
        /// </summary>
        /// <param name="id">岗位异常报警信息Id</param>
        /// <returns>返回影响的行数</returns>
        public int DeleteRealTimePostAlarmInfoToHistory(int id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int)
            };
            para[0].Value = id;

            return help.RunProcedureByInt("DeleteRealTimePostInfoByID", para, out outStr);
        }
    }


    /// <summary>
    /// 历史岗位异常
    /// </summary>
    public class HistoryPostDAL
    {
        private DBAcess dbacc = new DBAcess();

        /// <summary>
        /// 根据条件查询历史岗位异常信息
        /// </summary>、
        /// <param name="condition">查询条件</param>
        /// <returns>返回查询结果</returns>
        public DataSet SelectHistoryPostInfoByCondition(int pIndex, int pSize, string where)
        {


            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };

            para[0].Value = "View_SelectHistoryPostInfo";
            para[1].Value = "HisPostID";
            para[2].Value = pSize;
            para[3].Value = pIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
    }
}
