using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_MainDAL
    {
        
        #region【声明】

        private DBAcess dba = new DBAcess();

        private string strSQL;

        #endregion

        #region【方法：获取界面刷新时间】

        public DataSet GetRefreshTime()
        {
            strSQL = " Select EnumValue From EnumTable Where FunID = 51 and EnumID=1";

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取热备刷新间隔时间和次数】

        public DataSet GetHostBackRefresh()
        {
            strSQL = " Select * From EnumTable Where FunID = 52";

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取下井人数】

        public DataSet GetInWellCount()
        {
            strSQL = " Select count(1) as Counts " +
                     " From RT_InOutMine as Rti left join CodeSender_Set as Css on Rti.CodeSenderAddress=Css.CodeSenderAddress " +
                     " Where Css.CsTypeID=0 ";

          return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取是否加载求救界面】

        public DataSet LoadEmpHelp()
        {
            strSQL = " Select EnumValue From EnumTable Where FunID = 48 and EnumID=1";

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region[]
        public bool IsAlarmWalk()
        {
            bool w1 = false;
            bool w2 = false;
            try
            {
                string sqlstr = "select count(*) from enumtable where funid=12 and title='超速报警' and enumvalue=1";
                if (int.Parse(dba.ExecuteScalarSql(sqlstr)) == 1)
                    w1= true;
                else
                    w1= false;
            }
            catch (Exception ex)
            {
                w1= false;
            }
            try
            {
                string sqlstr = "select count(*) from enumtable where funid=12 and title='欠速报警' and enumvalue=1";
                if (int.Parse(dba.ExecuteScalarSql(sqlstr)) == 1)
                    w2 = true;
                else
                    w2 = false;
            }
            catch (Exception ex)
            {
                w2 = false;
            }
            return w1 || w2;
        }

        public bool IsAlarmWork()
        {
            try
            {
                string sqlstr = "select count(*) from enumtable where funid=12 and title='异地交接班报警' and enumvalue=1";
                if (int.Parse(dba.ExecuteScalarSql(sqlstr)) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region[qyz 自动补单，同步实时数据，修复考勤]
        public void ClearRtInfo()
        {
            try
            {
                string sqlstr = "delete from rt_instationheadinfo where codesenderaddress not in(select codesenderaddress from rt_inoutmine)  and userid is not null"
                            + " and stationheadid not in(select stationheadid from station_head_info where stationheadtypeid=8)";
                dba.ExecuteSql(sqlstr);
            }
            catch
            { }
        }

        public void RepareAttendanceInfo()
        {
            string sqlstr = "update Emp_Info set MinSecTime=0 where MinSecTime is null";
            dba.ExecuteSql(sqlstr);
        }
        public DataTable AutoCodeComplete(string hours)
        {
            try
            {
                string sqlstr = "select codesenderaddress from rt_inoutmine where datediff(hh,InTime,getdate())>" + hours;
                DataSet ds = dba.GetDataSet(sqlstr);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
                //return dba.ExecuteSql(sqlstr);
            }
            catch
            { return null; }
        }

        public DataTable Get_UpStation()
        {
            try
            {
                string sqlstr = "select stationaddress,stationheadaddress from station_head_info where stationheadtypeid=8";
                DataSet ds = dba.GetDataSet(sqlstr);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            { return null; }
        }
        public DataTable GetCodeState(string CodeSender)
        {
            try
            {
                string sqlstr = "select CodeSenderStateID from codesender_info where codesenderID=" + CodeSender;
                DataSet ds = dba.GetDataSet(sqlstr);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            { return null; }
        }
        public DataSet DeleteSql()
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("@datetimeValue",SqlDbType.DateTime)
                                           };
            sqlParmeters[0].Value = DateTime.Now;
            DataSet ds = dba.ExecuteSqlDataSet("dropHisTable", sqlParmeters);
            return ds;                          
        }
        public void DeleteSql1()
        {
            SqlParameter[] sqlParmeters = {
                                                new SqlParameter("@datetimeValue",SqlDbType.DateTime)
                                           };
            sqlParmeters[0].Value = DateTime.Now;
            dba.ExecuteSql("dropHisTable1", sqlParmeters);
           
        }
        #endregion
    }
}
