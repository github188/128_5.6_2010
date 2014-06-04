using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_AntennaDAL
    {
        private DBAcess dba = new DBAcess();

        public DataTable GetAllStation()
        {
            string sqlstr = "select StationAddress,stationplace from Station_Info";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetStationHeadByStationAddress(string stationaddress)
        {
            string sqlstr = string.Format("select StationAddress,stationheadaddress,stationheadplace,antennaa,antennab from Station_Head_Info where stationaddress={0}", stationaddress);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetRTantennaInfo(string sqlstr, int pagenum, int pageindex, out int pagecount, out int rowcount)
        {
            string selectstring = "A_PagesShow";
            SqlParameter[] parameters = new SqlParameter[] {
																new SqlParameter("@tablename", SqlDbType.VarChar, 1000),
																new SqlParameter("@pagenum", SqlDbType.Int),
																new SqlParameter("@pageindex", SqlDbType.Int),
																new SqlParameter("@columnname", SqlDbType.VarChar,20),
                                                                new SqlParameter("@pagecount", SqlDbType.Int),
                                                                new SqlParameter("@rowcount", SqlDbType.Int)
                                                           };
            parameters[0].Value = "("+sqlstr+")";
            parameters[1].Value = pagenum;
            parameters[2].Value = pageindex;
            parameters[3].Value = "结束巡检时间";
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Direction = ParameterDirection.Output;
            try
            {
                DataSet ds = dba.GetDataSet(selectstring, parameters);
                pagecount = Convert.ToInt32(parameters[4].Value);
                rowcount = Convert.ToInt32(parameters[5].Value);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                pagecount = 0;
                rowcount = 0;
                return new DataTable();
            }
        }

        /// <summary>
        /// 历史天线信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页总数</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataSet GetHisantennaInfoByCodeSenderAddress(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_His_InOutStationView1";
            para[1].Value = "HisInStationID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }

    }
}
