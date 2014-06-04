using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NModel;

namespace KJ128NDataBase
{
    /// <summary>
    /// 实时行走异常类
    /// </summary>
    public class RealTimeWalkDAL
    {
        DbHelperSQL help = new DbHelperSQL();
        string outStr = String.Empty;

        /// <summary>
        /// 查询实时行走异常报警信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRealTimeWalkAlarmInfo(string condition)
        {
            SqlParameter[] para = {
                                      new SqlParameter("@condition",SqlDbType.VarChar,1000)
                                  };
            para[0].Value = condition;

            return help.ReturnDataTable("SelectRealTimeWalkAlarmInfo", para);
        }

        /// <summary>
        /// 修改实时行走异常措施
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="measure">措施内容</param>
        /// <returns>返回操作影响的行数</returns>
        public int UpdateRealTimeWalkMeasure(int id,string measure)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@id",SqlDbType.Int),
                new SqlParameter("@measure", SqlDbType.VarChar,100)};

            para[0].Value = id;
            para[1].Value = measure;

            return help.RunProcedureByInt("UpdateRealTimeWalkMeasure", para, out outStr);
        }

        /// <summary>
        /// 完成（删除）实时行走异常信息，再写入历史
        /// </summary>
        /// <returns>返回操作影响的行数</returns>
        public int DeleteRealTimeWalkInfoToHistroy(int id)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int) };
            para[0].Value = id;

            return help.RunProcedureByInt("DeleteRealTimeWalkByID", para, out outStr);
        }

        //public DataTable SelectRealTimeWalkAlarmInfo()
        //{
        //    throw new NotImplementedException();
        //}
    }

    /// <summary>
    /// 历史行走异常类
    /// </summary>
    public class HistoryWalkDAL
    {
        private DBAcess dbacc = new DBAcess();

        /// <summary>
        /// 查询历史行走异常信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回查询到的记录</returns>
        public DataSet SelectHiatoryWalkInfo(int pIndex, int pSize, string where)
        {

            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };

            para[0].Value = "View_HistoryWalkInfo";
            para[1].Value = "HistoryWalkId";
            para[2].Value = pSize;
            para[3].Value = pIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }

    }

    /// <summary>
    /// 行走异常配置类
    /// </summary>
    public class WalkConfigDAL
    {
        DbHelperSQL help = new DbHelperSQL();
        string outStr = String.Empty;

        /// <summary>
        /// 查询行走异常配置信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回查询到的记录</returns>
        public DataTable SelectWalkConfigInfo(string condition)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@condition", SqlDbType.VarChar, 1000) };

            para[0].Value = condition;

            return help.ReturnDataTable("SelectWalkConfigInfo", para);
        }

        /// <summary>
        /// 添加行走异常配置信息
        /// </summary>
        /// <returns>返回执行结果行数</returns>
        public int InsertWalkConfigInfo(WalkConfigModel model)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                //new SqlParameter("@WalkConfigId", SqlDbType.Int, 1000) , 

                new SqlParameter("@EmpID", SqlDbType.Int, 1000) ,

                new SqlParameter("@FirstStationAddress", SqlDbType.Int) ,
                new SqlParameter("@FirstStationHeadAddress", SqlDbType.Int) ,
                new SqlParameter("@FirstStationHeadAntennaA", SqlDbType.Bit) ,
                new SqlParameter("@FirstStationHeadAntennaB", SqlDbType.Bit) ,

                new SqlParameter("@MiddleStationAddress", SqlDbType.Int, 1000) ,
                new SqlParameter("@MiddleStationHeadAddress", SqlDbType.Int, 1000) ,
                new SqlParameter("@MiddleStationHeadAntennaA", SqlDbType.Bit) ,
                new SqlParameter("@MiddleStationHeadAntennaB", SqlDbType.Bit) ,

                new SqlParameter("@LastStationAddress", SqlDbType.Int) ,
                new SqlParameter("@LastStationHeadAddress", SqlDbType.Int) ,
                new SqlParameter("@LastStationHeadAntennaA", SqlDbType.Bit) ,
                new SqlParameter("@LastStationHeadAntennaB", SqlDbType.Bit) ,


                new SqlParameter("@TimeValue", SqlDbType.Int) 
            };

            //para[0].Value = model.WalkConfigId;

            para[0].Value = model.EmpId;
            
            para[1].Value = model.FirstStationHead.StationAddress;
            para[2].Value = model.FirstStationHead.StationHeadAddress;
            para[3].Value = model.FirstStationHead.StationHeadAntennaA;
            para[4].Value = model.FirstStationHead.StationHeadAntennaB;
            
            para[5].Value = model.MiddleStationHead.StationAddress;
            para[6].Value = model.MiddleStationHead.StationHeadAddress;
            para[7].Value = model.MiddleStationHead.StationHeadAntennaA;
            para[8].Value = model.MiddleStationHead.StationHeadAntennaB;
            
            para[9].Value = model.LastStationHead.StationAddress;
            para[10].Value = model.LastStationHead.StationHeadAddress;
            para[11].Value = model.LastStationHead.StationHeadAntennaA;
            para[12].Value = model.LastStationHead.StationHeadAntennaB;

            para[13].Value = model.TimeValue;


            return help.RunProcedureByInt("InsertWalkConfigInfo", para, out outStr);
        }

        /// <summary>
        /// 更新行走异常配置信息
        /// </summary>
        /// <returns>返回执行影响的行数</returns>
        public int UpdateWalkConfigInfo(WalkConfigModel model)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@WalkConfigId", SqlDbType.Int, 1000) , 

                new SqlParameter("@EmpID", SqlDbType.Int, 1000) ,

                new SqlParameter("@FirstStationAddress", SqlDbType.Int) ,
                new SqlParameter("@FirstStationHeadAddress", SqlDbType.Int) ,
                new SqlParameter("@FirstStationHeadAntennaA", SqlDbType.Bit) ,
                new SqlParameter("@FirstStationHeadAntennaB", SqlDbType.Bit) ,

                new SqlParameter("@MiddleStationAddress", SqlDbType.Int, 1000) ,
                new SqlParameter("@MiddleStationHeadAddress", SqlDbType.Int, 1000) ,
                new SqlParameter("@MiddleStationHeadAntennaA", SqlDbType.Bit) ,
                new SqlParameter("@MiddleStationHeadAntennaB", SqlDbType.Bit) ,

                new SqlParameter("@LastStationAddress", SqlDbType.Int) ,
                new SqlParameter("@LastStationHeadAddress", SqlDbType.Int) ,
                new SqlParameter("@LastStationHeadAntennaA", SqlDbType.Bit) ,
                new SqlParameter("@LastStationHeadAntennaB", SqlDbType.Bit) ,


                new SqlParameter("@TimeValue", SqlDbType.Int) 
            };

            para[0].Value = model.WalkConfigId;

            para[1].Value = model.EmpId;

            para[2].Value = model.FirstStationHead.StationAddress;
            para[3].Value = model.FirstStationHead.StationHeadAddress;
            para[4].Value = model.FirstStationHead.StationHeadAntennaA;
            para[5].Value = model.FirstStationHead.StationHeadAntennaB;

            para[6].Value = model.MiddleStationHead.StationAddress;
            para[7].Value = model.MiddleStationHead.StationHeadAddress;
            para[8].Value = model.MiddleStationHead.StationHeadAntennaA;
            para[9].Value = model.MiddleStationHead.StationHeadAntennaB;

            para[10].Value = model.LastStationHead.StationAddress;
            para[11].Value = model.LastStationHead.StationHeadAddress;
            para[12].Value = model.LastStationHead.StationHeadAntennaA;
            para[13].Value = model.LastStationHead.StationHeadAntennaB;

            para[14].Value = model.TimeValue;

            return help.RunProcedureByInt("UpdateWalkConfigInfo", para, out outStr);
        }

        /// <summary>
        /// 删除行走异常配置信息
        /// </summary>
        /// <param name="id">行走异常配置信息</param>
        /// <returns>返回执行结果行数</returns>
        public int DeleteWalkConfigInfo(int id)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int) };

            para[0].Value = id;

            return help.RunProcedureByInt("DeleteWalkConfigInfo", para, out outStr);
        }
    }
}
