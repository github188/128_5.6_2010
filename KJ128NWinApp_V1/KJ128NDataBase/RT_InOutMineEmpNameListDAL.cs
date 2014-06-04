using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class RT_InOutMineEmpNameListDAL
    {
        #region[声明]

        private DBAcess dbacc = new DBAcess();

        #endregion

        #region[获取实时员工部门和部门人数]

        public DataTable RT_Dept()
        {
            string sql = @"select distinct 部门ID,count(员工部门) as com from view_RT_InOutMineEmpNameList group by 部门ID";
            return dbacc.GetDataSet(sql).Tables[0];

        }

        #endregion

        public DataTable RT_DeptID(string ID)
        {
            string sql = "select distinct 员工部门 from view_RT_InOutMineEmpNameList_FW where 部门ID=" + ID;

            return dbacc.GetDataSet(sql).Tables[0];
        }

        public DataTable ALL_DeptNAME(string id)
        {
            string sql = "select W.员工部门 from (select distinct 员工部门,部门ID from view_RT_InOutMineEmpNameList_FW  where " + id + " ) as W order by W.部门ID ";
            return dbacc.GetDataSet(sql).Tables[0];
        }

        #region[根据部门ID获取下井员工信息]

        public DataTable get_mes(string DeptID)
        {
            string sql = " select * from view_RT_InOutMineEmpNameList where 部门ID=" + DeptID ;
            return dbacc.GetDataSet(sql).Tables[0];
        }

        #endregion

        #region[获取实时员工的信息]

        public DataTable RT_InOutEmp( string str)
        {
            string sql = @"select * from view_RT_InOutMineEmpNameList_FW where " + str;
         
            return dbacc.GetDataSet(sql).Tables[0];
        }

        /// <summary>
        /// 实时进出人员信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页总数</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataSet RT_InOutEmp(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "view_RT_InOutMineEmpNameList_FW";
            para[1].Value = "员工ID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Pro_GetRTInMineEmp_ByPage", para);
        }

        #endregion

        public DataTable GetEmpID()
        {
            string sql = "select distinct 员工ID from dbo.view_RT_InOutMineEmpNameList_FW";
            return dbacc.GetDataSet(sql).Tables[0];
        }

        public DataTable GetImage(string id)
        {
            string sql = "select Photo from dbo.Emp_Photo where EmpID=" + id;
            return dbacc.GetDataSet(sql).Tables[0];
        }

        #region[实时下井人数]

        public string RTcount()
        {
            string sql = @"select count(*) as count from view_RT_InOutMineEmpNameList_FW";

            DataSet ds = dbacc.GetDataSet(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows[0]["count"].ToString();
            }
            else
            {
                return "0";
            }
        }

        #endregion

        #region FrmRealTimeOutMineEmp
        public DataTable GetEmpRealTimeOutMine(DateTime dateTimeStart,DateTime dateTimeEnd,string strWhere)
        {
            string sql = "select A.codeSenderAddress as 标识卡号,A.UserName as 姓名,B.DeptName as 部门,A.InTime as 下井时间,A.OutTime as 上井时间 from " +
                "dbo.His_InOutMine_" + dateTimeStart.ToString("yyyyM") + " as A join Emp_Info as B on A.UserID=B.EmpID where A.InTime >='" + dateTimeStart.ToString("yyyy-MM-dd HH:mm:ss") + "' and A.inTime<='" + dateTimeEnd.ToString("yyyy-MM-dd HH:mm:ss") + "' and A.CodeSenderAddress not in (select CodeSenderAddress from dbo.RT_InOutMine) " + strWhere;
            DataSet ds = new DataSet();
            ds = dbacc.GetDataSet(sql);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 【方法：获取当班时间范围】
        public DataTable GetClassTimeByNowTime(DateTime dateTimeNow)
        {
            string sql = "select * from (select convert(varchar,dateAdd(mi,-SwFrontTime,StartWorkTime),108) StartWorkTime1,convert(varchar,dateAdd(mi,-SwFrontTime,EndWorkTime),108) EndWorkTime1,SwDateType,EWdateType from TimerInterval) t "
            + " where (convert(varchar,StartWorkTime1,108)<='" + dateTimeNow.ToString("HH:mm:ss") + "' and convert(varchar,EndWorkTime1,108)>='" + dateTimeNow.ToString("HH:mm:ss")+"') or "
            + "(convert(varchar,StartWorkTime1,108)<'" + dateTimeNow.ToString("HH:mm:ss") + "' and convert(varchar,EndWorkTime1,108)<'" + dateTimeNow.ToString("HH:mm:ss") + "' and ewdatetype=1 and swDateType=0) or"
            + "(convert(varchar,StartWorkTime1,108)>='" + dateTimeNow.ToString("HH:mm:ss") + "' and convert(varchar,EndWorkTime1,108)>='" + dateTimeNow.ToString("HH:mm:ss") + "' and ewdatetype=1 and swDateType=0) or"
            + "(convert(varchar,StartWorkTime1,108)<'" + dateTimeNow.ToString("HH:mm:ss") + "' and convert(varchar,EndWorkTime1,108)<'" + dateTimeNow.ToString("HH:mm:ss") + "' and ewdatetype=0 and swDateType=-1) or"
            + "(convert(varchar,StartWorkTime1,108)>='" + dateTimeNow.ToString("HH:mm:ss") + "' and convert(varchar,EndWorkTime1,108)>='" + dateTimeNow.ToString("HH:mm:ss") + "' and ewdatetype=0 and swDateType=-1)";
            DataSet ds = new DataSet();
            ds = dbacc.GetDataSet(sql);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
