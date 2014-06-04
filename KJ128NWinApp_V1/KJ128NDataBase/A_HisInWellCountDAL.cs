using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_HisInWellCountDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private DataSet ds;

        private string strSQL;

        #endregion


        #region【方法：获取部门信息（树）】

        public DataSet GetDeptTree()
        {
            strSQL = " Select * From A_Tree_Dept order by SerialNo,[Name] ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：人员下井次数统计】
        public DataSet GetInfo_HisInWellCounts(int pageIndex, int pageSize, string where,string strDateTime,string TableName,string TableName2)
        {
            SqlParameter[] para = { new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000),
                                    new SqlParameter("@strDateTime",SqlDbType.VarChar,600),
                                    new SqlParameter("@strTable",SqlDbType.VarChar,30),
                                     new SqlParameter("@strTable2",SqlDbType.VarChar,30)
            };
            para[0].Value = pageSize;
            para[1].Value = pageIndex;
            para[2].Value = where;
            para[3].Value = strDateTime;
            para[4].Value = TableName;
            para[5].Value = TableName2; 
            return dba.ExecuteSqlDataSet("A_EmpInWellCount_Select", para);    
        }
        #endregion

        #region【Czlt-2010-10-03添加历史上下井记录】

        /// <summary>
        /// 添加人员到历史进出井信息
        /// </summary>
        /// <param name="drHisInOutMine"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public int AddHisInOutMine(DataRow drHisInOutMine, string strTableName)
        {
            try
            {
                SqlParameter[] sqlParmeters = {
                                                new SqlParameter("HisInOutMineID",SqlDbType.BigInt),
                                                new SqlParameter("InStationAddress",SqlDbType.Int),
                                                new SqlParameter("InStationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("InWellPlace",SqlDbType.NVarChar,50),
                                                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                new SqlParameter("UserID",SqlDbType.Int),
                                                new SqlParameter("UserNo",SqlDbType.NVarChar,50),
                                                new SqlParameter("UserName",SqlDbType.NVarChar,20),
                                                new SqlParameter("DeptID",SqlDbType.Int),
                                                new SqlParameter("DeptName",SqlDbType.NVarChar,50),
                                                new SqlParameter("DutyID",SqlDbType.Int),
                                                new SqlParameter("DutyName",SqlDbType.NVarChar,50),
                                                new SqlParameter("WorkTypeID",SqlDbType.Int),
                                                new SqlParameter("WorkTypeName",SqlDbType.NVarChar,50),
                                                new SqlParameter("InTime",SqlDbType.DateTime),
                                                new SqlParameter("OutStationAddress",SqlDbType.Int),
                                                new SqlParameter("OutStationHeadAddress",SqlDbType.Int),
                                                new SqlParameter("OutWellPlace",SqlDbType.NVarChar,50),
                                                new SqlParameter("OutTime",SqlDbType.DateTime),
                                                new SqlParameter("ContinueTime",SqlDbType.BigInt),
                                                new SqlParameter("IsMend",SqlDbType.Bit),
                                                new SqlParameter("TableName",SqlDbType.VarChar,20)
                                          };

                sqlParmeters[0].Value = drHisInOutMine["HisInOutMineID"];
                sqlParmeters[1].Value = drHisInOutMine["InStationAddress"];
                sqlParmeters[2].Value = drHisInOutMine["InStationHeadAddress"];
                sqlParmeters[3].Value = drHisInOutMine["InWellPlace"];
                sqlParmeters[4].Value = drHisInOutMine["CodeSenderAddress"];
                sqlParmeters[5].Value = drHisInOutMine["UserID"];
                sqlParmeters[6].Value = drHisInOutMine["UserNo"];
                sqlParmeters[7].Value = drHisInOutMine["UserName"];
                sqlParmeters[8].Value = drHisInOutMine["DeptID"];
                sqlParmeters[9].Value = drHisInOutMine["DeptName"];
                sqlParmeters[10].Value = drHisInOutMine["DutyID"];
                sqlParmeters[11].Value = drHisInOutMine["DutyName"];
                sqlParmeters[12].Value = drHisInOutMine["WorkTypeID"];
                sqlParmeters[13].Value = drHisInOutMine["WorkTypeName"];
                sqlParmeters[14].Value = drHisInOutMine["InTime"];
                sqlParmeters[15].Value = drHisInOutMine["OutStationAddress"];
                sqlParmeters[16].Value = drHisInOutMine["OutStationHeadAddress"];
                sqlParmeters[17].Value = drHisInOutMine["OutWellPlace"];
                sqlParmeters[18].Value = drHisInOutMine["OutTime"];
                sqlParmeters[19].Value = drHisInOutMine["ContinueTime"];
                sqlParmeters[20].Value = drHisInOutMine["IsMend"];
                sqlParmeters[21].Value = strTableName;
                // return ExecuteSql(true, "proc_AddHisInOutMine", sqlParmeters);

                dba.ExecuteSql("proc_AddHisInOutMine", sqlParmeters);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        /// <summary>
        /// 查找井口分站信息名称
        /// </summary>
        /// <returns></returns>
        public string GetStationHeadInfoDal()
        {
            string strReturn = string.Empty;
            string strSql = "select  top 1 stationAddress,stationHeadAddress,StationHeadPlace from dbo.Station_Head_Info where stationHeadTypeId = '8' ";
            DataSet ds = new DataSet();
            ds = dba.GetDataSet(strSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    strReturn = dr["stationAddress"] + "," + dr["stationHeadAddress"] + "," + dr["StationHeadPlace"];
                }
            }
            return strReturn;
        }

        /// <summary>
        /// 返回查询人员信息
        /// </summary>
        /// <param name="strEmpID"></param>
        /// <returns></returns>
        public DataSet GetEmpInfo(string strEmpID)
        {
            string strSql = "select * from dbo.Emp_Info where EmpID = " + strEmpID;
            return dba.GetDataSet(strSql);

        }

        /// <summary>
        /// 查询补单的日期中是不是存在该班次
        /// </summary>
        /// <param name="strTableName">表明</param>
        /// <param name="blockId">卡号</param>
        /// <param name="employeeId">员工ID</param>
        /// <param name="classId">班制号</param>
        /// <param name="classShortName">班次号</param>
        /// <param name="dataAttendance">记工日期</param>
        /// <returns></returns>
        public bool FindEmpClassInfo(string strTableName, string blockId, string employeeId, string classId, string classShortName, string dataAttendance)
        {

            string strSql = "select Employeeid from dbo.HistoryAttendance_" + strTableName + " where blockid = '" + blockId + "' and Employeeid  = '" + employeeId + "' and classID = '" + classId + "' and classshortName = '" + classShortName + "'  and DataAttendance = '" + dataAttendance + "'";
            DataSet ds = dba.GetDataSet(strSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }
        #endregion

        #region【Czlt-2010-12-07 获取工种信息树】
        public DataSet GetWorkTypeTree()
        {
            //strSQL = "select wt.workTypeID as ID,wt.wtName as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From WorkType_Info as wt  ";
            strSQL = "select wt.workTypeID as ID,wt.wtName as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From WorkType_Info as wt union all select distinct 99999 as ID,'未配置' as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From WorkType_Info as wt order by [name]";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region【Czlt-2010-12-07 获取职务信息树】
        public DataSet GetDutyTree()
        {
            //strSQL = "select wt.DutyID as ID,wt.DutyName as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From Duty_Info as wt";
            strSQL = "select wt.DutyID as ID,wt.DutyName as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From Duty_Info as wt union all select distinct 99999 as id,'未配置' as Name,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From Duty_Info as wt  order by [name]";
            return dba.GetDataSet(strSQL);
        }
        #endregion

    }
}
