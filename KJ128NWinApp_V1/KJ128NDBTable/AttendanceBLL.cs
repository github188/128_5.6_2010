using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using KJ128NModel;
using System.Windows.Forms;

namespace KJ128NDBTable
{
    public class AttendanceBLL
    {

        #region [ 声明 ]

        AttendanceDAL dal = new AttendanceDAL();

        #endregion

        /*
         * 方法
         */

        #region 【方法：获取班次信息】
        public ComboBox getClassNameCmb(ComboBox cmb)
        {
            DataSet ds = dal.getClassName();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "className";
                cmb.ValueMember = "ID";

            }
            return cmb;
        }
        #endregion

        #region [ 方法: 人员考勤明细 ]

        public DataSet GetEmployeeAttendanceParticulars(string strWhere, string txtBeginTime,string txtEndTime, int intPageIndex, int intPageSize, out string strErrMsg)
        {
            return dal.GetEmployeeAttendanceParticulars(strWhere, txtBeginTime,txtEndTime, intPageIndex, intPageSize,out strErrMsg);
        }

        #endregion

        #region [ 方法: 人员考勤原始数据 ]

        public DataSet GetEmployeeAttendanceInitialData(string[] strWhere, bool isUnion)
        {
            return dal.GetEmployeeAttendanceInitialData(strWhere, isUnion);
        }

        #endregion

        #region [ 方法: 人员考勤出勤率统计 ]

        /// <summary>
        /// 人员考勤出勤率统计
        /// </summary>
        /// <param name="strBeginTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strErrMsg">执行后的带出信息</param>
        /// <returns>返回的结果集</returns>
        public DataSet GetEmployeeAttendanceRateStatistic(string strBeginTime, string strEndTime, out string strErrMsg)
        {
            return dal.GetEmployeeAttendanceRateStatistic(strBeginTime, strEndTime, out strErrMsg);
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
            return dal.GetEmployeeAttendancePersonelStatistic(strBeginTime, strEndTime, strWhere, intPageIndex, intPageSize,out strErrMsg);
        }

        #endregion

        #region [ 方法: 员工考勤逐日统计 ]
        
        /// <summary>
        /// 员工考勤逐日统计
        /// </summary>
        /// <param name="strBeginTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strWhere">统计条件</param>
        /// <param name="intPageIndex">页面索引</param>
        /// <param name="intPageSize">页面大小</param>
        /// <param name="strErrMsg">带出的结果</param>
        /// <returns>返回的数据集</returns>
        public DataSet GetEmployeeAttendanceDayByDayStatistic(string strBeginTime, string strEndTime, string strWhere, int intPageIndex, int intPageSize, out  string strErrMsg)
        {
            return dal.GetEmployeeAttendanceDayByDayStatistic(strBeginTime, strEndTime, strWhere, intPageIndex, intPageSize, out strErrMsg);
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
            return dal.GetEmployeeAttendanceRealTime(strWhere, intPageIndex, intPageSize, out strErrMsg);
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
        public DataSet GetEmployeeAttendanceHistoryList(string strWhere, int intPageIndex, int intPageSize,string strTableName,string strTableName2, out string strErrMsg)
        {
            return dal.GetEmployeeAttendanceHistoryList(strWhere, intPageIndex, intPageSize, strTableName, strTableName2, out strErrMsg);
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
            return dal.UpdateEmployeeAttendanceHistory(haModel, out strErrMsg);
        }

        #endregion

        public DataSet GetKQTJbyCards(string strCards, DateTime dtime, out string strErrMsg)
        {
            return dal.GetKQTJbyCards(strCards, dtime, out strErrMsg);
        }

        public int AddKQTJ(DateTime dataAttendance, int codeSenderAddress, string strEmpName, int deptID, string strDeptName, out string strErrMsg)
        {
            return dal.AddKQTJ(dataAttendance, codeSenderAddress, strEmpName, deptID, strDeptName, out strErrMsg);
        }

        public int UpdateKQTJ(DateTime dataAttendance, int codeSenderAddress, string strClassShortName, int deptID, string strDeptName, out string strErrMsg)
        {
            return dal.UpdateKQTJ(dataAttendance, codeSenderAddress, strClassShortName,deptID,strDeptName, out strErrMsg);
        }

        #region [ 方法: 添加历出勤数据 ]

        /// <summary>
        /// 添加历史出勤数据
        /// </summary>
        /// <param name="haModel">历史出勤对象</param>
        /// <param name="strErrMsg">带出的结果</param>
        /// <returns>返回的参数 -1为操作失败 1为操作成功</returns>
        public int AddEmployeeAttendanceHistory(HistoryAttendanceModel haModel, out string strErrMsg)
        {
            return dal.AddEmployeeAttendanceHistory(haModel, out strErrMsg);
        }

        public int AddEmployeeAttendanceHistory(HistoryAttendanceModel haModel,string strTableName, out string strErrMsg)
        {
            return dal.AddEmployeeAttendanceHistory(haModel,strTableName, out strErrMsg);
        }
        #endregion

        #region [ 方法: 删除历出勤数据 ]

        /// <summary>
        /// 删除历出勤数据
        /// </summary>
        /// <param name="intID">流水号</param>
        /// <param name="strErrMsg">带出的信息</param>
        /// <returns>删除失败 返回-1 删除成功 1</returns>
        public int DeleteHistoryAttendance(int intID, out string strErrMsg)
        {
            return dal.DeleteHistoryAttendance(intID, out strErrMsg);
        }

        public int DeleteHistoryAttendance(long intID, int blockID, string strShortName, DateTime dataAttendance, out string strErrMsg)
        {
            return dal.DeleteHistoryAttendance(intID, blockID,strShortName,dataAttendance, out strErrMsg);
        }
        #endregion

        #region [ 方法: 考勤异常数据列表 ]

        public DataSet GetEmployeeAttendanceRealTimeError(string strWhere, int intPageIndex, int intPageSize, out string strErrMsg)
        {
            return dal.GetEmployeeAttendanceRealTimeError(strWhere, intPageIndex, intPageSize, out strErrMsg);
        }

        #endregion

        #region [ 方法: 考勤异常补单 ]

        public DataSet GetEmployeeAttendanceRealTimeErrorInsertAndDelete(HistoryAttendanceModel haModel, out string strErrMsg)
        {
            return dal.GetEmployeeAttendanceRealTimeErrorInsertAndDelete(haModel, out strErrMsg);
        }

        #endregion

        #region [ 方法: 删除异常考勤 ]

        public int DeleteEmployeeAttendanceError(int intID, out string strErrMsg)
        {
            return dal.DeleteEmployeeAttendanceError(intID, out strErrMsg);
        }

        #endregion

        #region [ 方法: 实时考勤补单 ]

        public DataSet GetEmployeeAttendanceRealTimeInsertAndDelete(HistoryAttendanceModel haModel, out string strErrMsg)
        {
            return dal.GetEmployeeAttendanceRealTimeInsertAndDelete(haModel, out strErrMsg);
        }

        #endregion

        #region [ 方法: 删除实时考勤信息 ]

        public int GetEmployeeAttendanceRealTimeDelete(int intBlockID, out string strErrMsg)
        {
            return dal.GetEmployeeAttendanceRealTimeDelete(intBlockID, out strErrMsg);
        }

        #endregion

        #region [ 方法: 插入历史下井表并删除实时下井表 ]

        public void InertHistoryOutStationAndDeleteRealTimeInStation(int intBlockID, DateTime dtOutTime, int intStationAddress, int intStationHeadAddress, out string strErr)
        {
            dal.InertHistoryOutStationAndDeleteRealTimeInStation(intBlockID, dtOutTime, intStationAddress, intStationHeadAddress, out strErr);
        }

        #endregion

        #region [ 方法: 得到员工劳动考勤报表 ]

        public DataSet GetAttendanceSalary(string strWhere,int intStandardTime, out string strErr)
        {
            return dal.GetAttendanceSalary(strWhere, intStandardTime, out strErr);
        }

        #endregion

        #region [ 方法: 得到各部门干部出勤报表 ]

        public DataSet GetAttendanceStatisticByDuty(string strWhere, string strTime, out string strErr)
        {
            return dal.GetAttendanceStatisticByDuty(strWhere, strTime, out strErr);
        }

        #endregion

        #region【方法：获取部门信息】

        public DataSet getDept()
        {
            return dal.getDept();
        }

        #endregion

        #region【方法：根据部门ID，获取人员姓名】

        public DataSet getEmpName(string strDeptID)
        {
            return dal.getEmpName(strDeptID);
        }

        #endregion

        #region【方法：根据员工ID，获取标识卡号】

        public DataSet getCodeSenderAddress(string strEmpID)
        {
            return dal.getCodeSenderAddress(strEmpID);
        }

        #endregion

        #region 【czlt--2010-8-18-考勤部门统计】
        ///
        /// <summary>
        /// 考勤部门统计
        /// </summary>
        /// <param name="strBeginTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strWhere"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public DataSet GetEmployeeAttendanceDeptStatistic(string strBeginTime, string strEndTime, string strWhere, int intPageIndex, int intPageSize,bool isUnion, out string strErrMsg)
        {
            return dal.GetEmployeeAttendanceDeptStatistic(strBeginTime, strEndTime, strWhere, intPageIndex, intPageSize,isUnion, out strErrMsg);
        }
        #endregion

        #region 【Czlt-2011-10-16 考勤明细合并考勤】
        /// <summary>
        /// Czlt-2011-10-18 考勤明细 合并考勤
        /// </summary>
        /// <param name="isUnon"></param>
        /// <param name="txtBeginTime"></param>
        /// <param name="txtEndTime"></param>
        /// <param name="strWhere"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="endWhere"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public DataSet Czlt_GetEmployeeAttendanceParticulars(bool isUnon, string txtBeginTime, string txtEndTime, string strWhere, int intPageIndex, int intPageSize,string endWhere, out string strErrMsg)
        {
            return dal.Czlt_GetEmployeeAttendanceParticulars(isUnon, txtBeginTime, txtEndTime, strWhere, intPageIndex, intPageSize, endWhere,out strErrMsg);
        }
        #endregion

        #region 【Czlt-2011-10-18 人员统计考勤合并】
        /// <summary>
        /// Czlt-2011-10-18 人员统计考勤合并
        /// </summary>
        /// <param name="strBeginTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="strWhere"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public DataSet Czlt_GetEmployeeAttendancePersonelStatistic(bool isUnoin, string strBeginTime, string strEndTime, string strWhere, int intPageIndex, int intPageSize, string endWhere, out string strErrMsg)
        {
            return dal.Czlt_GetEmployeeAttendancePersonelStatistic(isUnoin, strBeginTime, strEndTime, strWhere, intPageIndex, intPageSize,endWhere, out strErrMsg);
        }
        #endregion
    }
}
