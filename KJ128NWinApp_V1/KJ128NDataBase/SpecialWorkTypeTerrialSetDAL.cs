using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace KJ128NDataBase
{
    public class SpecialWorkTypeTerrialSetDAL
    {
        private DbHelperSQL DB = new DbHelperSQL();
        private DBAcess dba = new DBAcess();

        #region 添加特殊工种进出区域配置信息
        /// <summary>
        /// 添加特殊工种进出区域配置信息
        /// </summary>
        /// <param name="intEmpID">员工流水</param>
        /// <param name="intTerrialID">区域流水</param>
        /// <param name="intWorkTypeID">工种流水</param>
        /// <param name="bIsAlarm">是否报警标志</param>
        /// <param name="strRemark">备注</param>
        /// <param name="strErr">带出的错误</param>
        /// <returns></returns>
        public int Insert_SpecialWorkTypeTerrialSet(int intEmpID,int intTerrialID,int intWorkTypeID,bool bIsAlarm,string strRemark,out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmpID",SqlDbType.Int,4),
                new SqlParameter("@AreaID",SqlDbType.Int,4),
                new SqlParameter("@workTypeID",SqlDbType.Int,4),
                new SqlParameter("@IsAlarm",SqlDbType.Bit),
                new SqlParameter("@Remark",SqlDbType.NVarChar,300)
            };

            parameters[0].Value = intEmpID;
            parameters[1].Value = intTerrialID;
            parameters[2].Value = intWorkTypeID;
            parameters[3].Value = bIsAlarm;
            parameters[4].Value = strRemark;

            return DB.RunProcedureReturnInt("KJ128N_Insert_SpecialWorkTypeTerrial", parameters, out strErr);

        }
        #endregion

        #region 修改特殊工种进出区域配置信息
        /// <summary>
        /// 修改特殊工种进出区域配置信息
        /// </summary>
        /// <param name="intID">自动流水号</param>
        /// <param name="intEmpID">员工流水</param>
        /// <param name="intTerrialID">区域流水</param>
        /// <param name="intWorkTypeID">工种流水</param>
        /// <param name="bIsAlarm">是否报警标志</param>
        /// <param name="strRemark">备注</param>
        /// <param name="strErr">带出的错误</param>
        /// <returns></returns>
        public int Update_SpecialWorkTypeTerrialSet(int intID,int intEmpID, int intTerrialID, int intWorkTypeID, bool bIsAlarm, string strRemark,string strWhere, out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4),
                new SqlParameter("@EmpID",SqlDbType.Int,4),
                new SqlParameter("@AreaID",SqlDbType.Int,4),
                new SqlParameter("@workTypeID",SqlDbType.Int,4),
                new SqlParameter("@IsAlarm",SqlDbType.Bit),
                new SqlParameter("@Remark",SqlDbType.NVarChar,300),
                new SqlParameter("@Where",SqlDbType.NVarChar,200)

            };

            parameters[0].Value = intID;
            parameters[1].Value = intEmpID;
            parameters[2].Value = intTerrialID;
            parameters[3].Value = intWorkTypeID;
            parameters[4].Value = bIsAlarm;
            parameters[5].Value = strRemark;
            parameters[6].Value = strWhere;

            return DB.RunProcedureReturnInt("KJ128N_Update_SpecialWorkTypeTerrial", parameters, out strErr);
        }
        #endregion

        #region 删除特殊工种进出区域配置信息
        /// <summary>
        /// 删除特殊工种进出区域配置信息
        /// </summary>
        /// <param name="intID">自动流水</param>
        /// <param name="strErr">带出的信息</param>
        /// <returns></returns>
        public int Delete_SpecialWorkTypeTerrialSet(int intID,out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4)
            };

            parameter[0].Value = intID;

            return DB.RunProcedureReturnInt("KJ128N_Delete_SpecialWorkTypeTerrial", parameter, out strErr);
        }
        #endregion

        #region 查询特殊工种进出区域配置信息
        /// <summary>
        /// 查询特殊工种进出区域配置信息
        /// </summary>
        /// <param name="intPageIndex">页索引</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strErr">带出的信息</param>
        /// <returns></returns>
        public DataSet Query_SpecialWorkTypeTerrialSet(int intPageIndex,int intPageSize,string strWhere,out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@Where",SqlDbType.VarChar,2000)
            };

            parameter[0].Value = intPageIndex;
            parameter[1].Value = intPageSize;
            parameter[2].Value = strWhere;

            return DB.RunProcedureByDataSet("KJ128N_Query_SpecialWorkTypeTerrial","dst", parameter, out strErr);
        }
        #endregion

        #region 查询实时特殊工种进出区域报警信息
        /// <summary>
        /// 查询实时特殊工种进出区域报警信息
        /// </summary>
        /// <param name="intPageIndex">页索引</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strErr">带出的错误</param>
        /// <returns></returns>
        public DataSet Query_RealTimeSpecialWorkTypeAlarm(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@Where",SqlDbType.VarChar,2000)
            };

            parameter[0].Value = intPageIndex;
            parameter[1].Value = intPageSize;
            parameter[2].Value = strWhere;

            return DB.RunProcedureByDataSet("KJ128N_Query_RealTimeTerrialAlarm", "dst", parameter, out strErr);
        }
        #endregion

        #region 查询历史特殊工种进出区域报警信息
        /// <summary>
        /// 查询历史特殊工种进出区域报警信息
        /// </summary>
        /// <param name="intPageIndex">页索引</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strErr">带出错误</param>
        /// <returns></returns>
        public DataSet Query_HistorySpecialWorkTypeAlarm(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@Where",SqlDbType.VarChar,2000)
            };

            parameter[0].Value = intPageIndex;
            parameter[1].Value = intPageSize;
            parameter[2].Value = strWhere;

            return DB.RunProcedureByDataSet("KJ128N_Query_HistorySpecialWorkTypeTerrial", "dst", parameter, out strErr);
        }
        #endregion

        #region 查询区域类别信息
        /// <summary>
        /// 查询区域类别信息
        /// </summary>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public DataSet Query_TerrialType(out string strErr)
        {
            return DB.RunProcedureByDataSet("KJ128N_Query_TerrialType", "dst", out strErr);
        }
        #endregion

        #region 根据区域类别查询区域信息
        /// <summary>
        /// 根据区域类别查询区域信息
        /// </summary>
        /// <param name="intTerrialTypeID">区域流水</param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public DataSet Query_TerrialInfo(int intTerrialTypeID, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@TerrialTypeID",SqlDbType.Int)
            };

            parameter[0].Value = intTerrialTypeID;

            return DB.RunProcedureByDataSet("KJ128N_Query_TerrialInfo", "dst", parameter, out strErr);
        }
        #endregion

        #region 查询工种信息
        /// <summary>
        /// 查询工种信息
        /// </summary>
        /// <param name="strErr">带出的错误</param>
        /// <returns></returns>
        public DataSet Querey_WorkType(out string strErr)
        {
            return DB.RunProcedureByDataSet("KJ128N_Query_WorkType", "dst", out strErr);
        }
        #endregion

        #region 根据工种流水号查询员工信息
        /// <summary>
        /// 根据工种流水号查询员工信息
        /// </summary>
        /// <param name="intWorkTypeID">工种流水</param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public DataSet Query_Employee_ByWorkType(int intWorkTypeID,out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@WorkTypeID",SqlDbType.Int)
            };

            parameter[0].Value = intWorkTypeID;

            return DB.RunProcedureByDataSet("KJ128N_QueryEmployeeInfo_ByWorkTypeID", "dst",parameter, out strErr);
        }
        #endregion

        public DataTable GetTerrialInfo()
        {
            string sqlstr = "select Territorialid,territorialName from Territorial_Info";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetWtInfoByTerID(string terid)
        {
            string sqlstr = string.Format("SELECT dbo.SWorkTypeTerrialSet.WorkTypeID, dbo.WorkType_Info.WtName " +
                                            "FROM dbo.SWorkTypeTerrialSet INNER JOIN " +
                                            "dbo.WorkType_Info ON  " +
                                            "dbo.SWorkTypeTerrialSet.WorkTypeID = dbo.WorkType_Info.WorkTypeID " +
                                            "where dbo.SWorkTypeTerrialSet.TerrialID={0}", terid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetWtInfo()
        {
            string sqlstr = "select worktypeid,wtname from WorkType_Info";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public bool InsertSWTer(string terid, string wtid)
        {
            string sqlstr = string.Format("insert into SWorkTypeTerrialSet(TerriAlarmID,TerrialID,WorkTypeID,IsAlarm,Remark) values({0},{0},{1},1,'')", terid, wtid);
            if (dba.ExecuteSql(sqlstr) > 0)
                return true;
            else
                return false;
        }

        public void DelSWTer(string id)
        {
            string sqlstr;
            if (id == "")
            {
                sqlstr = "delete from SWorkTypeTerrialSet";
            }
            else
            {
                sqlstr = string.Format("delete from SWorkTypeTerrialSet where TerriAlarmID={0}", id);
            }
            dba.ExecuteSql(sqlstr);
        }


        //*******czlt-2010-9-16***Start***
        //删除特殊区域的工种
        public void DelSWTer(string terriAlarmID, string workTypeID)
        {
            string sqlStr;
            sqlStr = string.Format("delete from SWorkTypeTerrialSet where TerriAlarmID={0} and WorkTypeID = {1}", terriAlarmID, workTypeID);
            dba.ExecuteSql(sqlStr);
        }
        //*******czlt-2010-9-16***End***

    }
}
