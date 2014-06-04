using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class Graphics_His_EmpPlaceDAL
    {
        #region[申明]
        private DBAcess dba = new DBAcess();
        #endregion

        public string GetHisEmpNum(string startDate, string endDate)
        {
            string sqlstr = string.Format("SELECT count(DISTINCT codesenderaddress) FROM His_InOutMine" +
                " WHERE dbo.His_InOutMine.OutTime > '{0}' AND dbo.His_InOutMine.InTime < '{1}'", startDate, endDate);
            return dba.ExecuteScalarSql(sqlstr);
        }

        public string GetHisAreaEmpNum(string startDate, string endDate, string areaId)
        {
            try
            {
                string sqlstr = string.Format("SELECT COUNT(DISTINCT dbo.His_InOutTerritorial.CodeSenderAddress) AS EmpNum "+
                                                "FROM dbo.His_InOutMine INNER JOIN "+
                                                "dbo.His_InOutTerritorial ON  "+
                                                "dbo.His_InOutMine.CodeSenderAddress = dbo.His_InOutTerritorial.CodeSenderAddress "+
                                                "WHERE (dbo.His_InOutMine.OutTime > '{0}') AND " +
                                                "(dbo.His_InOutMine.InTime < '{1}') AND "+
                                                "(dbo.His_InOutTerritorial.TerritorialID={2})", startDate, endDate, areaId);
                return dba.ExecuteScalarSql(sqlstr);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetHisWorkTypeEmpNum(string sDate, string eDate, string worktype)
        {
            string sqlstr = string.Format("SELECT COUNT(DISTINCT dbo.His_InOutMine.CodeSenderAddress) AS EmpNum "+
                                            "FROM dbo.WorkType_Info INNER JOIN "+
                                            "dbo.Emp_WorkType ON  "+
                                            "dbo.WorkType_Info.WorkTypeID = dbo.Emp_WorkType.WorkTypeID INNER JOIN "+
                                            "dbo.His_InOutMine ON  "+
                                            "dbo.Emp_WorkType.EmpID = dbo.His_InOutMine.UserID "+
                                            "WHERE (dbo.His_InOutMine.OutTime > '{0}') AND  "+
                                            "(dbo.His_InOutMine.InTime < '{1}') AND "+
                                            "(dbo.Emp_WorkType.IsEnable = 1) AND cstypeid=0 and" +
                                            "(dbo.WorkType_Info.WtName = '{2}')", sDate, eDate, worktype);
            return dba.ExecuteScalarSql(sqlstr);
        }

        public string GetHisDeptEmpNum(string sDate, string eDate, string dept)
        {
            string sqlstr = string.Format("SELECT COUNT(DISTINCT dbo.His_InOutMine.CodeSenderAddress) AS EmpNum " +
                                            "FROM dbo.Dept_Info INNER JOIN " +
                                            "dbo.Emp_NowCompany ON  " +
                                            "dbo.Dept_Info.DeptID = dbo.Emp_NowCompany.DeptID INNER JOIN " +
                                            "dbo.His_InOutMine ON  " +
                                            "dbo.Emp_NowCompany.EmpID = dbo.His_InOutMine.UserID " +
                                            "WHERE (dbo.His_InOutMine.OutTime > '{0}' AND dbo.His_InOutMine.InTime < '{1}')  " +
                                            "AND (dbo.Dept_Info.DeptName = '{2}') and cstypeid=0", sDate, eDate, dept);
            return dba.ExecuteScalarSql(sqlstr);
        }

        public DataTable GetHisStationHeadInfo(string sdate, string edate, int stationid, int stationheadid)
        {
            string sqlstr = string.Format("SELECT dbo.His_InOutStation.CodeSenderAddress as 标识卡,dbo.Emp_Info.EmpName as 姓名, dbo.Dept_Info.DeptName as 部门,  "+
                                            "dbo.His_InOutStation.StationHeadDetectTime as 监测时间  "+
                                            "FROM dbo.His_InOutStation INNER JOIN "+
                                            "dbo.Emp_Info ON  "+
                                            "dbo.His_InOutStation.UserID = dbo.Emp_Info.EmpID INNER JOIN "+
                                            "dbo.Emp_NowCompany ON  "+
                                            "dbo.Emp_Info.EmpID = dbo.Emp_NowCompany.EmpID INNER JOIN "+
                                            "dbo.Dept_Info ON dbo.Emp_NowCompany.DeptID = dbo.Dept_Info.DeptID "+
                                            "WHERE (dbo.His_InOutStation.codesenderaddress IN "+
                                            "(SELECT DISTINCT codesenderaddress "+
                                            "FROM His_InOutMine "+
                                            "WHERE outtime > '{0}' AND intime < '{1}')) AND  "+
                                            "(dbo.His_InOutStation.StationHeadDetectTime < '{1}') "+
                                            "and dbo.His_InOutStation.StationAddress={2} and His_InOutStation.StationHeadAddress={3} "+
                                            "order by dbo.His_InOutStation.StationHeadDetectTime", sdate, edate, stationid, stationheadid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
    }
}
