using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_RealTimeInWellDAL
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
        public DataSet GetRealTime_DeptTree()
        {
            string strSQL = " Select * From A_DeptTree_RTInWell order by SerialNo,[Name] ";
            return dba.GetDataSet(strSQL);
        }
        /// <summary>
        /// 获取工种树信息
        /// </summary>
        public DataSet GetRealTime_WorkTypeTree()
        {
            string strSQL = " Select * From a_workType_RTInWell ";
            return dba.GetDataSet(strSQL);
        }
        /// <summary>
        /// 获取工种树信息
        /// </summary>
        public DataSet GetRealTime_DutyInfoTree()
        {
            string strSQL = " Select * From a_DutyInfo_RTInWell ";
            return dba.GetDataSet(strSQL);
            
        }
        /// <summary>
        /// 获取方向性树信息
        /// </summary>
        public DataSet GetRealTime_DirectionalTree()
        {
            string strSQL = " Select * From a_Directional_RTInWell ";
            return dba.GetDataSet(strSQL);

        }
        /// <summary>
        /// 获取职务等级树信息
        /// </summary>
        public DataSet GetRealTime_DutyLeverTree()
        {
            string strSQL = " Select * From a_DutyLever_RTInWell ";
            return dba.GetDataSet(strSQL);

        }
        #endregion

        #region 【方法：获取实时下井人员信息】
        /// <summary>
        /// 实时下井信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页总数</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataSet GetRealTimeInWell(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "View_RealTimeInWell";
            para[1].Value = "CodeSenderAddress";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion
        #endregion
    }
}
