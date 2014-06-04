using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase.A_RT_OverSee
{
    public class A_Station_HeadDAL
    {
        private DBAcess db = new DBAcess();
        private DbHelperSQL sqldb = new DbHelperSQL();
        #region[监测读卡分站]
        /// <summary>
        /// 监控读卡分站--@pd=1为人员，其他为设备
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataSet A_RT_Station_Head(string StrWhere,int pd)
        {
           
                SqlParameter[] par ={
                                   new SqlParameter("@str",SqlDbType.NVarChar,1000),
                                   new SqlParameter("@pd",SqlDbType.Int)
                               };
                par[0].Value = StrWhere;
                par[1].Value = pd;
                return db.ExecuteSqlDataSet("A_RT_Station_Head_houhui", par);

        }
        #endregion
        public DataSet A_exSQL(string sql)
        {
            return sqldb.Query(sql);
        }
        #region[部门树]
        /// <summary>
        /// isEmp=0是人员其他为设备
        /// </summary>
        /// <param name="isEmp"></param>
        /// <returns></returns>
        public DataSet A_RT_Dept_Tree(int isEmp)
        {
            SqlParameter[] par ={
                                   new SqlParameter("@a",SqlDbType.Int)
                               };
            par[0].Value = isEmp;
            return db.ExecuteSqlDataSet("A_Dept_Tree", par);
        }
        #endregion
        public DataSet A_RT_Station_Head_count(string StrWhere, int pd)
        {

            SqlParameter[] par ={
                                   new SqlParameter("@str",SqlDbType.NVarChar,1000),
                                   new SqlParameter("@pd",SqlDbType.Int)
                               };
            par[0].Value = StrWhere;
            par[1].Value = pd;
            return db.ExecuteSqlDataSet("A_RT_Station_Head_count_houhui", par);

        }
    }
}
