using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NModel;
namespace KJ128NDataBase
{
    public class AttendanceDAL
    {

        #region [ 声明 ]

        private DbHelperSQL DB = new DbHelperSQL();

        private DBAcess dba = new DBAcess();

        private string strSQL;

        #endregion


        #region [ 方法: 人员考勤明细 ]

        /// <summary>
        /// 人员考勤明细
        /// </summary>
        /// <param name="strWhere">查询的条件语句</param>
        /// <param name="strErrMsg">存储过程执行后带出的结果</param>
        /// <returns></returns>
        public DataSet GetEmployeeAttendanceParticulars(string strWhere, string txtBeginTime, string txtEndTime, int intPageIndex, int intPageSize, out string strErrMsg)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new SqlParameter[] {
                new SqlParameter("@tableName",SqlDbType.VarChar,50),
                new SqlParameter("@tableName2",SqlDbType.VarChar,50),
                new SqlParameter("@strWhere",SqlDbType.VarChar,500),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4)
              
            };

            sqlpara[0].Value = "HistoryAttendance_" + DateTime.Parse(txtBeginTime).ToString("yyyyM");
            sqlpara[1].Value = "HistoryAttendance_" + DateTime.Parse(txtEndTime).ToString("yyyyM");
            sqlpara[2].Value = strWhere;
            sqlpara[3].Value = intPageIndex;
            sqlpara[4].Value = intPageSize;


            // return DB.RunProcedureByDataSet("Shine_Shen_AttendanceParticulars", "dst", sqlpara, out strErrMsg);
            //Czlt-2010-10-19-考勤明细
            ds = DB.RunProcedureByDataSet("Shine_Shen_AttendanceParticularsNew", "dst", sqlpara, out strErrMsg);


            return ds;
            //考勤明细可以查询时长
            // return DB.RunProcedureByDataSet("Shine_Shen_AttendanceParticularsNewFindTime", "dst", sqlpara, out strErrMsg);
        }

        #endregion

        #region [ 方法: 人员考勤的原始数据 ]

        /// <summary>
        /// 人员考勤原始数据
        /// </summary>
        /// <param name="strWhere">数据查询的条件语句</param>
        /// <param name="strErrMsg">存储过程执行后带出的结果</param>
        /// <returns></returns>
        public DataSet GetEmployeeAttendanceInitialData(string[] strWhere, bool isUnion)
        {
            SqlParameter[] sqlpara = new SqlParameter[] 
            {
                new SqlParameter("@startTime",SqlDbType.VarChar,500),
                new SqlParameter("@endTime",SqlDbType.VarChar,500),
                new SqlParameter("@deptname",SqlDbType.VarChar,500),
                new SqlParameter("@dutyname",SqlDbType.VarChar,500),
                new SqlParameter("@empname",SqlDbType.VarChar,500),
                new SqlParameter("@codesender",SqlDbType.VarChar,500)
            };


            sqlpara[0].Value = strWhere[0].ToString();
            sqlpara[1].Value = strWhere[1].ToString();
            sqlpara[2].Value = strWhere[2].ToString();
            sqlpara[3].Value = strWhere[3].ToString();
            sqlpara[4].Value = strWhere[4].ToString();
            sqlpara[5].Value = strWhere[5].ToString();
            string strErrMsg;
            if (!isUnion)
            return DB.RunProcedureByDataSet("Shine_Shen_Attendancekqtj_qyz", "dst", sqlpara, out strErrMsg);
            else
            return DB.RunProcedureByDataSet("Shine_Shen_Attendancekqtj_qyzUnion", "dst", sqlpara, out strErrMsg);
        }

        #endregion

        #region [ 方法: 人员出勤率统计 ]

        public DataSet GetEmployeeAttendanceRateStatistic(string strBeginTime, string strEndTime, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@BeginTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndTime",SqlDbType.VarChar,20),
            };

            sqlpara[0].Value = strBeginTime;
            sqlpara[1].Value = strEndTime;

            return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendanceRateStatistic", "dst", sqlpara, out strErrMsg);
        }

        #endregion

        #region 【方法:获取班次信息】
        public DataSet getClassName()
        {
            return dba.GetDataSet("select t.id,i.classname+':'+nameShort as className from TimerInterval t join InfoClass i on t.classid=i.id");
        }
        #endregion

        #region [ 方法: 出勤人员统计 ]

        /// <summary>
        /// 出勤人员统计
        /// </summary>
        /// <param name="strBeginTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strWhere">条件</param>
        /// <param name="intPageIndex">页索引</param>
        /// <param name="intPageSize">页面大小</param>
        /// <param name="strErrMsg">带出的错误信息</param>
        /// <returns>返回的数据集</returns>
        public DataSet GetEmployeeAttendancePersonelStatistic(string strBeginTime, string strEndTime, string strWhere, int intPageIndex, int intPageSize, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@BeginTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndTime",SqlDbType.VarChar,20),
                new SqlParameter("@strWhere",SqlDbType.VarChar,500),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4)
            };

            sqlpara[0].Value = strBeginTime;
            sqlpara[1].Value = strEndTime;
            sqlpara[2].Value = strWhere;
            sqlpara[3].Value = intPageIndex;
            sqlpara[4].Value = intPageSize;
            //return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendancePersonelStatistic", "dst", sqlpara, out strErrMsg);
            //czlt-2010-8-20  修改，使用新的存储过程进行查询

            DataSet ds = DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendancePersonelStatisticNew", "dst", sqlpara, out strErrMsg);
            return ds;
        }

        #endregion

        #region  [ 方法: 人员考勤逐日统计 ]

        public DataSet GetEmployeeAttendanceDayByDayStatistic(string strBeginTime, string strEndTime, string strWhere, int intPageIndex, int intPageSize, out  string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@BeginTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndTime",SqlDbType.VarChar,20),
                new SqlParameter("@strWhere",SqlDbType.VarChar,200),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4)
            };

            sqlpara[0].Value = strBeginTime;
            sqlpara[1].Value = strEndTime;
            sqlpara[2].Value = strWhere;
            sqlpara[3].Value = intPageIndex;
            sqlpara[4].Value = intPageSize;

            return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendanceDayByDayStatistic", "dst", sqlpara, out strErrMsg);
        }

        #endregion

        #region [ 方法: 人员出勤实时显示 ]

        /// <summary>
        /// 人员出勤实时显示
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="intPageIndex">页索引</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strErrMsg">带出的信息</param>
        /// <returns>返回的数据集</returns>
        public DataSet GetEmployeeAttendanceRealTime(string strWhere, int intPageIndex, int intPageSize, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,200),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4)
            };

            sqlpara[0].Value = strWhere;
            sqlpara[1].Value = intPageIndex;
            sqlpara[2].Value = intPageSize;

            return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendanceRealTimeQuery", "dst", sqlpara, out strErrMsg);
        }

        #endregion

        #region [ 方法: 得到历史考勤列表 ]

        /// <summary>
        /// 得到历史考勤列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="intPageIndex">页索引</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strErrMsg">带出的条件</param>
        /// <returns>返回的数据库</returns>
        public DataSet GetEmployeeAttendanceHistoryList(string strWhere, int intPageIndex, int intPageSize, string strTableName, string strTableName2, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,500),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4),
                new SqlParameter("@TableName",SqlDbType.VarChar,100),
                new SqlParameter("@TableName2",SqlDbType.VarChar,100)
            };

            sqlpara[0].Value = strWhere;
            sqlpara[1].Value = intPageIndex;
            sqlpara[2].Value = intPageSize;
            sqlpara[3].Value = strTableName;
            sqlpara[4].Value = strTableName2;

            return DB.RunProcedureByDataSet("A_Shine_Shen_EmployeeAttendanceQuery", "dst", sqlpara, out strErrMsg);
        }

        #endregion

        #region [ 方法: 更新历出勤数据 ]

        /// <summary>
        /// 更新历史出勤数据
        /// </summary>
        /// <param name="haModel">历史出勤对象</param>
        /// <param name="strErrMsg">带出的结果</param>
        /// <returns>返回的参数 -1为操作失败 1为操作成功</returns>
        public int UpdateEmployeeAttendanceHistory(HistoryAttendanceModel haModel, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.BigInt),
                new SqlParameter("@BlockID",SqlDbType.Int,4),
                new SqlParameter("@EmployeeName",SqlDbType.VarChar,10),
                new SqlParameter("@DeptID",SqlDbType.Int,4),
                new SqlParameter("@ClassID",SqlDbType.Int,4),
                new SqlParameter("@ClassShortName",SqlDbType.VarChar,20),
                new SqlParameter("@BeginWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@OperatorID",SqlDbType.Int,4),
                new SqlParameter("@Remark",SqlDbType.VarChar,200),
                new SqlParameter("@TimerIntervalID",SqlDbType.Int,4),
                new SqlParameter("@DataAttendance",SqlDbType.VarChar,20)
            };

            sqlpara[0].Value = haModel.ID_HistoryAttendance;
            sqlpara[1].Value = haModel.BlockID;
            sqlpara[2].Value = haModel.EmployeeName;
            sqlpara[3].Value = haModel.DeptID;
            sqlpara[4].Value = haModel.ClassID;
            sqlpara[5].Value = haModel.ClassShortName;
            sqlpara[6].Value = haModel.BeginWorkTime;
            sqlpara[7].Value = haModel.EndWorkTime;
            sqlpara[8].Value = haModel.OperatorID;
            sqlpara[9].Value = haModel.Remark;
            sqlpara[10].Value = haModel.TimerIntervalID;
            sqlpara[11].Value = haModel.DataAttendance;

            return DB.RunProcedureByInt("Shine_Shen_HistoryAttendanceUpdate", sqlpara, out strErrMsg);
        }

        #endregion

        public DataSet GetKQTJbyCards(string strCards, DateTime dtime, out string strErrMsg)
        {
            DateTime dTimeKQTJ = new DateTime(dtime.Year, dtime.Month, 1, 0, 0, 0);

            SqlParameter[] sqlParmeters = { 
                                              new SqlParameter("Cards", SqlDbType.VarChar,6000) ,
                                              new SqlParameter("dataAttendance",SqlDbType.DateTime)
                                          };
            sqlParmeters[0].Value = strCards;
            sqlParmeters[1].Value = dTimeKQTJ;

            return DB.RunProcedureByDataSet("proc_GetKQTJByCard", "dst", sqlParmeters, out strErrMsg);

        }

        #region [ 方法: 添加历史出勤数据 ]

        /// <summary>
        /// 添加历史出勤数据
        /// </summary>
        /// <param name="haModel">历史出勤对象</param>
        /// <param name="strErrMsg">带出的结果</param>
        /// <returns>返回的参数 -1为操作失败 1为操作成功</returns>
        public int AddEmployeeAttendanceHistory(HistoryAttendanceModel haModel, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@BlockID",SqlDbType.Int,4),
                new SqlParameter("@EmployeeName",SqlDbType.VarChar,10),
                new SqlParameter("@DeptID",SqlDbType.Int,4),
                new SqlParameter("@ClassID",SqlDbType.Int,4),
                new SqlParameter("@ClassShortName",SqlDbType.VarChar,20),
                new SqlParameter("@BeginWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@OperatorID",SqlDbType.Int,4),
                new SqlParameter("@Remark",SqlDbType.VarChar,200),
                new SqlParameter("@TimerIntervalID",SqlDbType.Int,4),
                new SqlParameter("@DataAttendance",SqlDbType.VarChar,20)
            };

            sqlpara[0].Value = haModel.BlockID;
            sqlpara[1].Value = haModel.EmployeeName;
            sqlpara[2].Value = haModel.DeptID;
            sqlpara[3].Value = haModel.ClassID;
            sqlpara[4].Value = haModel.ClassShortName;
            sqlpara[5].Value = haModel.BeginWorkTime;
            sqlpara[6].Value = haModel.EndWorkTime;
            sqlpara[7].Value = haModel.OperatorID;
            sqlpara[8].Value = haModel.Remark;
            sqlpara[9].Value = haModel.TimerIntervalID;
            sqlpara[10].Value = haModel.DataAttendance;

            return DB.RunProcedureByInt("Shine_Shen_HistoryAttendanceAdd", sqlpara, out strErrMsg);
        }

        /// <summary>
        /// 添加到历史考勤信息
        /// </summary>
        /// <returns></returns>
        public int AddEmployeeAttendanceHistory(HistoryAttendanceModel haModel, string strTableName, out string strErrMsg)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("ID",SqlDbType.BigInt),
                                                new SqlParameter("BlockID",SqlDbType.Int),
                                                new SqlParameter("EmployeeID",SqlDbType.Int),
                                                new SqlParameter("EmployeeName",SqlDbType.VarChar,10),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("ClassID",SqlDbType.VarChar,20),
                                                new SqlParameter("ClassShortName",SqlDbType.VarChar,10),
                                                new SqlParameter("BeginWorkTime",SqlDbType.VarChar,50),
                                                new SqlParameter("EndWorkTime",SqlDbType.VarChar,50),
                                                new SqlParameter("WorkTime",SqlDbType.Int),
                                                new SqlParameter("TimerIntervalID",SqlDbType.Int),
                                                new SqlParameter("DataAttendance",SqlDbType.VarChar,50),
                                                new SqlParameter("IsMend",SqlDbType.Bit),
                                                new SqlParameter("TableName",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = Int64.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + haModel.BlockID.ToString("0000"));
            sqlParmeters[1].Value = haModel.BlockID;
            sqlParmeters[2].Value = haModel.EmployeeID;
            sqlParmeters[3].Value = haModel.EmployeeName;
            sqlParmeters[4].Value = haModel.DeptID;
            sqlParmeters[5].Value = haModel.ClassID;
            sqlParmeters[6].Value = haModel.ClassShortName;
            sqlParmeters[7].Value = haModel.BeginWorkTime;
            sqlParmeters[8].Value = haModel.EndWorkTime;
            sqlParmeters[9].Value = (int)(((TimeSpan)(DateTime.Parse(haModel.EndWorkTime) - DateTime.Parse(haModel.BeginWorkTime))).TotalSeconds);
            sqlParmeters[10].Value = haModel.TimerIntervalID;
            sqlParmeters[11].Value = haModel.DataAttendance;
            sqlParmeters[12].Value = true;
            sqlParmeters[13].Value = strTableName;
            return DB.RunProcedureByInt("proc_AddHisAttendance", sqlParmeters, out strErrMsg);
        }
        #endregion

        #region 【方法：添加考勤统计记录】
        /// <summary>
        /// 添加考勤统计记录
        /// </summary>
        /// <param name="dataAttendance"></param>
        /// <param name="codeSenderAddress"></param>
        /// <param name="strEmpName"></param>
        /// <param name="deptID"></param>
        /// <param name="strDeptName"></param>
        /// <returns></returns>
        public int AddKQTJ(DateTime dataAttendance, int codeSenderAddress, string strEmpName, int deptID, string strDeptName, out string strErrMsg)
        {
            DateTime dtime = new DateTime(dataAttendance.Year, dataAttendance.Month, 1, 0, 0, 0);
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("dataAttendance",SqlDbType.DateTime),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("EmpName",SqlDbType.VarChar,20),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("DeptName",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = dtime;
            sqlParmeters[1].Value = codeSenderAddress;
            sqlParmeters[2].Value = strEmpName;
            sqlParmeters[3].Value = deptID;
            sqlParmeters[4].Value = strDeptName;
            return DB.RunProcedureByInt("proc_InsertKQTJ", sqlParmeters, out strErrMsg);
        }
        #endregion

        public int UpdateKQTJ(DateTime dataAttendance, int codeSenderAddress, string strClassShortName, int deptID, string strDeptName, out string strErrMsg)
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("dataAttendance",SqlDbType.DateTime),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("ClassShortName",SqlDbType.VarChar,20),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("DeptName",SqlDbType.VarChar,20)
                                          };

            sqlParmeters[0].Value = dataAttendance;
            sqlParmeters[1].Value = codeSenderAddress;
            sqlParmeters[2].Value = strClassShortName;
            sqlParmeters[3].Value = deptID;
            sqlParmeters[4].Value = strDeptName;
            return DB.RunProcedureByInt("proc_UpdateKQTJ", sqlParmeters, out strErrMsg);
        }

        #region [ 方法: 删除历出勤数据 ]

        /// <summary>
        /// 删除历出勤数据
        /// </summary>
        /// <param name="intID">流水号</param>
        /// <param name="strErrMsg">带出的信息</param>
        /// <returns>删除失败 返回-1 删除成功 1</returns>
        public int DeleteHistoryAttendance(int intID, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[] 
            {
                new SqlParameter("@ID",SqlDbType.Int,4)
            };

            sqlpara[0].Value = intID;

            return DB.RunProcedureByInt("Shine_Shen_EmployeeAttendanceDelete", sqlpara, out strErrMsg);
        }

        /// <summary>
        /// 删除历出勤数据
        /// </summary>
        /// <param name="intID">流水号</param>
        /// <param name="strErrMsg">带出的信息</param>
        /// <returns>删除失败 返回-1 删除成功 1</returns>
        public int DeleteHistoryAttendance(long intID, int blockID, string strShortName, DateTime dataAttendance, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[] 
            {
                new SqlParameter("ID",SqlDbType.BigInt),
                new SqlParameter("blockID",SqlDbType.Int),
                new SqlParameter("shortName",SqlDbType.VarChar,20),
                new SqlParameter("dataAttendance",SqlDbType.DateTime)
            };
            sqlpara[0].Value = intID;
            sqlpara[1].Value = blockID;
            sqlpara[2].Value = strShortName;
            sqlpara[3].Value = dataAttendance;
            return DB.RunProcedureByInt("Shine_Shen_EmployeeAttendanceDelete", sqlpara, out strErrMsg);
        }

        #endregion

        #region [ 方法: 得到考勤异常数据列表 ]

        public DataSet GetEmployeeAttendanceRealTimeError(string strWhere, int intPageIndex, int intPageSize, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,300),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4)
            };

            sqlpara[0].Value = strWhere;
            sqlpara[1].Value = intPageIndex;
            sqlpara[2].Value = intPageSize;

            return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendanceRealTimeErrorQuery", "dst", sqlpara, out strErrMsg);
        }

        #endregion

        #region[ 方法: 考勤异常补单 ]

        public DataSet GetEmployeeAttendanceRealTimeErrorInsertAndDelete(HistoryAttendanceModel haModel, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4),
                new SqlParameter("@BlockID",SqlDbType.Int,4),
                new SqlParameter("@EmployeeName",SqlDbType.VarChar,10),
                new SqlParameter("@EmployeeID",SqlDbType.Int,4),
                new SqlParameter("@DeptID",SqlDbType.Int,4),
                new SqlParameter("@ClassID",SqlDbType.Int,4),
                new SqlParameter("@ClassShortName",SqlDbType.VarChar,10),
                new SqlParameter("@BeginWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@OperatorID",SqlDbType.Int,4),
                new SqlParameter("@Remark",SqlDbType.VarChar,200),
                new SqlParameter("@TimerIntervalID",SqlDbType.Int,4),
                new SqlParameter("@DataAttendance",SqlDbType.VarChar,20)
            };

            sqlpara[0].Value = haModel.ID_RealTimeError;
            sqlpara[1].Value = haModel.BlockID;
            sqlpara[2].Value = haModel.EmployeeName;
            sqlpara[3].Value = haModel.EmployeeID;
            sqlpara[4].Value = haModel.DeptID;
            sqlpara[5].Value = haModel.ClassID;
            sqlpara[6].Value = haModel.ClassShortName;
            sqlpara[7].Value = haModel.BeginWorkTime;
            sqlpara[8].Value = haModel.EndWorkTime;
            sqlpara[9].Value = haModel.OperatorID;
            sqlpara[10].Value = haModel.Remark;
            sqlpara[11].Value = haModel.TimerIntervalID;
            sqlpara[12].Value = haModel.DataAttendance;

            return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendanceRealTimeErrorDeleteAndInsert", "dst", sqlpara, out strErrMsg);

        }

        #endregion

        #region [ 方法: 删除异常考勤 ]

        public int DeleteEmployeeAttendanceError(int intID, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4)
            };

            sqlpara[0].Value = intID;

            return DB.RunProcedureByInt("Shine_Shen_EmployeeAttendanceRealTimeErrorDelete", sqlpara, out strErrMsg);
        }

        #endregion

        #region[ 方法: 实时考勤补单 ]

        public DataSet GetEmployeeAttendanceRealTimeInsertAndDelete(HistoryAttendanceModel haModel, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@BlockID",SqlDbType.Int,4),
                new SqlParameter("@EmployeeName",SqlDbType.VarChar,10),
                new SqlParameter("@DeptID",SqlDbType.Int,4),
                new SqlParameter("@ClassID",SqlDbType.Int,4),
                new SqlParameter("@ClassShortName",SqlDbType.VarChar,10),
                new SqlParameter("@BeginWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@OperatorID",SqlDbType.Int,4),
                new SqlParameter("@Remark",SqlDbType.VarChar,200),
                new SqlParameter("@TimerIntervalID",SqlDbType.Int,4),
                new SqlParameter("@DataAttendance",SqlDbType.VarChar,20)
            };

            sqlpara[0].Value = haModel.BlockID;
            sqlpara[1].Value = haModel.EmployeeName;
            sqlpara[2].Value = haModel.DeptID;
            sqlpara[3].Value = haModel.ClassID;
            sqlpara[4].Value = haModel.ClassShortName;
            sqlpara[5].Value = haModel.BeginWorkTime;
            sqlpara[6].Value = haModel.EndWorkTime;
            sqlpara[7].Value = haModel.OperatorID;
            sqlpara[8].Value = haModel.Remark;
            sqlpara[9].Value = haModel.TimerIntervalID;
            sqlpara[10].Value = haModel.DataAttendance;

            return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendanceRealTimeDeleteAndInsert", "dst", sqlpara, out strErrMsg);

        }

        #endregion

        #region [ 方法: 删除实时考勤信息 ]

        public int GetEmployeeAttendanceRealTimeDelete(int intBlockID, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[] {
            new SqlParameter("@BlockID",SqlDbType.Int,4)

            };

            sqlpara[0].Value = intBlockID;

            return DB.RunProcedureByInt("Shine_Shen_EmployeeAttendanceRealTimeDelete", sqlpara, out strErrMsg);
        }

        #endregion

        #region [ 方法: 插入历史下井表并删除实时下井表 ]

        public void InertHistoryOutStationAndDeleteRealTimeInStation(int intBlockID, DateTime dtOutTime, int intStationAddress, int intStationHeadAddress, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
               new SqlParameter("@CodeSenderAddress",SqlDbType.Int,4),
                new SqlParameter("@DetectTime",SqlDbType.DateTime,8),
                new SqlParameter("@StationAddress",SqlDbType.Int,4),
                new SqlParameter("@StationHeadAddress",SqlDbType.Int,4)
            };

            parameter[0].Value = intBlockID;
            parameter[1].Value = dtOutTime;
            parameter[2].Value = intStationAddress;
            parameter[3].Value = intStationHeadAddress;

            DB.RunProcedureByInt("Shine_Shen_AddHistoryOutStation_DeleteRealTimeInStation", parameter, out strErr);
        }

        #endregion

        #region [ 方法: 得到员工劳动考勤报表 ]

        public DataSet GetAttendanceSalary(string strWhere, int intStandardTime, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,2000),
                new SqlParameter("@StandardWorkTime",SqlDbType.Int,4)
            };

            parameter[0].Value = strWhere;
            parameter[1].Value = intStandardTime;

            return DB.RunProcedureByDataSet("Shine_Shen_AttendanceStatisticSalary", "dst", parameter, out strErr);
        }

        #endregion

        #region [ 方法: 得到各部门干部出勤报表 ]

        public DataSet GetAttendanceStatisticByDuty(string strWhere, string strTime, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,1000),
                new SqlParameter("@strTime",SqlDbType.VarChar,300)
            };

            parameter[0].Value = strWhere;
            parameter[1].Value = strTime;

            return DB.RunProcedureByDataSet("Shine_Shen_AttendanceStatisticByDuty", "dst", parameter, out strErr);
        }

        #endregion

        #region【方法：获取部门信息——绑定】

        public DataSet getDept()
        {
            return dba.GetDataSet("Select 0 as DeptID ,'无' as DeptName Union all select DeptID,DeptName from Dept_Info");
        }

        #endregion

        #region【方法：根据部门ID，获取人员姓名】

        public DataSet getEmpName(string strDeptID)
        {
            strSQL = " Select 0 as EmpID ,'无' as EmpName " +
                     " Union all" +
                     " Select EmpID,EmpName " +
                     " From Emp_Info " +
                     " Where DeptID =" + strDeptID;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：根据员工ID，获取标识卡号】

        public DataSet getCodeSenderAddress(string strEmpID)
        {
            strSQL = "Select CodeSenderAddress From CodeSender_Set Where CsTypeID=0 and UserID= " + strEmpID;

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法:考勤部门统计-czlt-2010-08-25】
        //***********************czlt-2010-08-25*考勤部门统计*Start****************************************
        /// <summary>
        /// 考勤部门统计
        /// </summary>
        /// <param name="strBeginTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="intPageIndex">当前页码</param>
        /// <param name="intPageSize">每页显示条数</param>
        /// <param name="strErrMsg">反馈信息</param>
        /// <returns>返回结果集</returns>
        public DataSet GetEmployeeAttendanceDeptStatistic(string strBeginTime, string strEndTime, string strWhere, int intPageIndex, int intPageSize,bool isUnion, out string strErrMsg)
        {
            // int intsearchTime = Int32.Parse(shiftDal.FindSetDal(strBeginTime));   //czlt-2010-8-25
            SqlParameter[] sqlpara = new SqlParameter[] 
            {
                new SqlParameter("@BeginTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndTime",SqlDbType.VarChar,20),
                new SqlParameter("@strWhere",SqlDbType.VarChar,500),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4)                
            };

            sqlpara[0].Value = strBeginTime;
            sqlpara[1].Value = strEndTime;
            sqlpara[2].Value = strWhere;
            sqlpara[3].Value = intPageIndex;
            sqlpara[4].Value = intPageSize;
            if (!isUnion)
            return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendancePersonelStatisticDeptNew", "dst", sqlpara, out strErrMsg);
            else
            return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendancePersonelStatisticDeptNewUnion", "dst", sqlpara, out strErrMsg);

        }
        //***********************czlt-2010-08-25*考勤部门统计*End****************************************
        #endregion


        #region 【Czlt-2011-10-16 考勤明细考勤合并查询 】
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="txtBeginTime"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public DataSet Czlt_GetEmployeeAttendanceParticulars(bool isUnion, string txtBeginTime, string txtEndTime, string strWhere, int intPageIndex, int intPageSize, string endWhere, out string strErrMsg)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new SqlParameter[] {
                new SqlParameter("@BeginTime",SqlDbType.VarChar,20),  //@EndTime
                new SqlParameter("@EndTime",SqlDbType.VarChar,20),
                new SqlParameter("@strWhere",SqlDbType.VarChar,500),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@endWhere",SqlDbType.VarChar,100)//@endWhere
              
            };

            sqlpara[0].Value = txtBeginTime;
            sqlpara[1].Value = txtEndTime;
            sqlpara[2].Value = strWhere;
            sqlpara[3].Value = intPageIndex;
            sqlpara[4].Value = endWhere;


            // return DB.RunProcedureByDataSet("Shine_Shen_AttendanceParticulars", "dst", sqlpara, out strErrMsg);
            //Czlt-2010-10-19-考勤明细
            if (isUnion)  //假如是合并考勤
            {
                //ds = DB.RunProcedureByDataSet("Shine_Shen_AttendanceParticularsNew", "dst", sqlpara, out strErrMsg);
                ds = DB.RunProcedureByDataSet("Shine_Shen_AttendanceParticulars_Czlt_UN", "dst", sqlpara, out strErrMsg);
            }
            else
            {
                //假如考勤不合并
                ds = DB.RunProcedureByDataSet("Shine_Shen_AttendanceParticulars_Czlt", "dst", sqlpara, out strErrMsg);
            }

            return ds;
            //考勤明细可以查询时长
            // return DB.RunProcedureByDataSet("Shine_Shen_AttendanceParticularsNewFindTime", "dst", sqlpara, out strErrMsg);
        }

        #endregion

        #region【Czlt-2011-10-18 人员统计考勤合并】
        public DataSet Czlt_GetEmployeeAttendancePersonelStatistic(bool isUnoin, string strBeginTime, string strEndTime, string strWhere, int intPageIndex, int intPageSize, string endWhere, out string strErrMsg)
        {
            SqlParameter[] sqlpara = new SqlParameter[]
            {
                new SqlParameter("@BeginTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndTime",SqlDbType.VarChar,20),
                new SqlParameter("@strWhere",SqlDbType.VarChar,500),
                new SqlParameter("@PageIndex",SqlDbType.Int,4),
                new SqlParameter("@PageSize",SqlDbType.Int,4),
                new SqlParameter("@EndWhere",SqlDbType.VarChar,100)
            };

            sqlpara[0].Value = strBeginTime;
            sqlpara[1].Value = strEndTime;
            sqlpara[2].Value = strWhere;
            sqlpara[3].Value = intPageIndex;
            sqlpara[4].Value = intPageSize;
            sqlpara[5].Value = endWhere;

            //return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendancePersonelStatistic", "dst", sqlpara, out strErrMsg);
            //czlt-2010-8-20  修改，使用新的存储过程进行查询
            if (isUnoin)
            {
                //Shine_Shen_EmployeeAttendancePersonelStatisticNew_Czlt
                return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendancePersonelStatisticNew_Czlt", "dst", sqlpara, out strErrMsg);
            }
            else
            {
                return DB.RunProcedureByDataSet("Shine_Shen_EmployeeAttendancePersonelStatisticNew", "dst", sqlpara, out strErrMsg);

            }

        }

        #endregion

    }
}
