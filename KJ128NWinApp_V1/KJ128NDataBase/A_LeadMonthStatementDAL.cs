using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    /// <summary>
    /// 领导每月下进总数及时间统计

    /// </summary>
    public class A_LeadMonthStatementDAL
    {

        #region【声明】


        private DBAcess dba = new DBAcess();

        #endregion


        /// <summary>
        /// 下井统计信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>数据集</returns>
        public DataSet SelectLeadMonthStatementInfo(DateTime beginTime, DateTime endTime)
        {
            #region 【Czlt-2010-9-21-注销】
            //SqlParameter[] para = { new SqlParameter("@strTable",SqlDbType.NVarChar,20)
            //};

            //para[0].Value = beginTime.ToString("yyyyM");

            //DataSet ds = dba.ExecuteSqlDataSet("leadMonthStatement", para);

            //return ds;
            #endregion
            //Czlt-2010-9-21 添加领导干部月下井统计排序
            string time = beginTime.ToString("yyyyM");
            string sql = "select 标识卡,人员编号,人员姓名,职务,工种,部门,下井次数,下井时间总长 from (select distinct CodeSenderAddress as 标识卡,hiom.UserNo as 人员编号 ,UserName as 人员姓名,hiom.DutyName as 职务,hiom.WorkTypeName as 工种,hiom.DeptName as 部门,(select count(hiom1.UserID) from His_InOutMine_" + time + " as hiom1 where hiom1.UserID=hiom.UserID ) as 下井次数,dbo.FunConvertTime((select sum(ContinueTime) from His_InOutMine_" + time + " as hiom2 where hiom2.UserID=hiom.UserID )) as 下井时间总长,DutyClassID  from His_InOutMine_" + time + " as hiom join Duty_Info as dui on dui.DutyID = hiom.DutyID join Emp_Info as ei on hiom.UserNo =ei.EmpNo where dui.DutyClassID < 6) h order by DutyClassID,职务";

            DataSet ds = dba.GetDataSet(sql);
            return ds;
        }

    #region 【Czlt-2011-09-10 查询 领导代班月下井记录】
        public DataSet CzltGetMonth(DateTime beginTime, DateTime endTime, string strDeptWhere, string strDutyClassWhere, string strTime)
        {
            #region 【Czlt-2010-9-21-注销】
            //SqlParameter[] para = { new SqlParameter("@strTable",SqlDbType.NVarChar,20)
            //};

            //para[0].Value = beginTime.ToString("yyyyM");

            //DataSet ds = dba.ExecuteSqlDataSet("leadMonthStatement", para);

            //return ds;
            #endregion
            //Czlt-2010-9-21 添加领导干部月下井统计排序
            string strWhere = strDeptWhere + " " + strDutyClassWhere;
             SqlParameter[] para = { new SqlParameter("@BeginTime",SqlDbType.VarChar,20),
                                       new SqlParameter("@EndTime",SqlDbType.VarChar,20),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,500),
                                    new SqlParameter("@strTime",SqlDbType.VarChar,100)
                                 
            };
            para[0].Value = beginTime;
            para[1].Value = endTime;
            para[2].Value = strWhere;// HisStationHeadID //进入分站的时间Czlt-2011-06-05
            para[3].Value = strTime;
         

            //string sql = "select 标识卡,人员姓名,职务,工种,部门,下井次数,下井总时长,平均时长 from (select distinct CodeSenderAddress as 标识卡,hiom.UserNo as 人员编号 ,UserName as 人员姓名,ei.DutyName as 职务,ei.WorkTypeName as 工种,hiom.DeptName as 部门,(select count(hiom1.UserID) from His_InOutMine_" + time + " as hiom1 where hiom1.UserID=hiom.UserID ) as 下井次数,dbo.FunConvertTime((select sum(ContinueTime) from His_InOutMine_" + time + " as hiom2 where hiom2.UserID=hiom.UserID )) as 下井总时长,dbo.FunConvertTime(((select sum(ContinueTime) from His_InOutMine_" + time + " as hiom2  where hiom2.UserID=hiom.UserID )/(select count(hiom1.UserID) from His_InOutMine_" + time + " as hiom1 where hiom1.UserID=hiom.UserID ))) as 平均时长,DutyClassID  from His_InOutMine_" + time + " as hiom  join Emp_Info as ei on hiom.UserID =ei.EmpID join Duty_Info as dui on dui.DutyID = ei.DutyID where 1=1 " + strDeptWhere + "  " + strDutyClassWhere + ") h order by  标识卡 ";
            DataSet ds = dba.ExecuteSqlDataSet("Czlt_leadMonthStatement", para);         
            return ds;
        }
        #endregion
    
    }
}
