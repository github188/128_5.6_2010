using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_HisInWellDAL
    {
        #region 【自定义参数】
        /// <summary>
        /// 数据访问层对象
        /// </summary>
        private DBAcess dba = new DBAcess();
        #endregion

        #region 【自定义方法】
        #region 【获取各个树控件的表信息】
        /// <summary>
        /// 获取部门树信息
        /// </summary>
        public DataSet GetHisDeptTree(string strWhere)
        {
            string strWhereSql = "1=1";
            if (!strWhere.Trim().Equals(""))
            {
                strWhereSql = strWhere;
            }
            string strSQL = "select Dei.DeptID as ID,Dei.DeptName as Name ,Dei.ParentDeptID as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From Dept_Info as Dei  order by SerialNo, [name]";
            return dba.GetDataSet(strSQL);
        }
        /// <summary>
        /// 获取工种树信息
        /// </summary>
        public DataSet GetHisWorkTypeTree(string strWhere)
        {
            string strWhereSql = "1=1";
            if (!strWhere.Trim().Equals(""))
            {
                strWhereSql = strWhere;
            }
            string strSQL = "select wt.workTypeID as ID,wt.wtName as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From WorkType_Info as wt union all select distinct 99999 as ID,'未配置' as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From WorkType_Info as wt order by [name] ";
            return dba.GetDataSet(strSQL);
        }
        /// <summary>
        /// 获取工种树信息
        /// </summary>
        public DataSet GetHisDutyInfoTree(string strWhere)
        {
            string strWhereSql = "1=1";
            if (!strWhere.Trim().Equals(""))
            {
                strWhereSql = strWhere;
            }
            string strSQL = "select wt.DutyID as ID,wt.DutyName as Name ,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From Duty_Info as wt union all select distinct 99999 as id,'未配置' as Name,0 as ParentID,'true' as IsChild ,'false' as IsUserNum ,0 as Num From Duty_Info as wt  order by [name] ";
            return dba.GetDataSet(strSQL);

        }
        #endregion

        #region 【方法：获取历史下井人员信息】
        /// <summary>
        /// 历史下井信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页总数</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataSet GetHisInWell(string TableName,string TableName2, int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@tblName2",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value =  TableName ;
            para[1].Value = TableName2;
            para[2].Value = "CodeSenderAddress";
            para[3].Value = pageSize;
            para[4].Value = pageIndex;
            para[5].Value = 1;
            para[6].Value = 0;
            para[7].Value = where;
            //para[6].Value = "1=1";

            DataSet ds = dba.ExecuteSqlDataSet("Shine_InOutMine_ByPage", para);
            return ds;
        }
        #endregion
        #endregion
    }
}
