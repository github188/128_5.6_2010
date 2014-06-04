using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class RealTimeEmpHelpDAL
    {
        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSQL = string.Empty;

        #endregion

        #region [ 方法: 查询历史进出接收器信息 ]

        public DataSet SelectRealTimeEmpHelpInfo(string strBeginTime, string strEndTime,string strCodeSenderAddress, string strStatationAddress, string strStaHeadAddress, string strEmpName, string strDeptName, string strDutyName, string strWtName, string strMeasure)
        {
            strSQL = "Select * From zjw_RT_EmpHelp_View Where 求救开始时间>='" + strBeginTime + "' and 求救开始时间<='" + strEndTime + "' ";

            if (!strCodeSenderAddress.Equals(""))
            {
                strSQL += " And 发码器编号 = " + strCodeSenderAddress;
            }

            if (!strStatationAddress.Equals("0"))
            {
                strSQL += " and 分站编号= " + strStatationAddress;
            }

            if (!strStaHeadAddress.Equals("0"))
            {
                strSQL += " and 接收器编号= " + strStaHeadAddress;
            }

            if (!strEmpName.Equals(""))
            {
                strSQL += " And 姓名 like '%" + strEmpName + "%' ";
            }

            if (!strDeptName.Equals("所有部门"))
            {
                strSQL += " And ( 部门 = " + strDeptName + ")";
            }

            if (!strDutyName.Equals("所有"))
            {
                strSQL += " And 职务='" + strDutyName + "' ";
            }

            if (!strWtName.Equals("所有"))
            {
                strSQL += " And 工种='" + strWtName + "' ";
            }

            if (!strMeasure.Equals(""))
            {
                strSQL += " And 救援措施 like '%" + strMeasure + "% ";
            }

            return dbacc.GetDataSet(strSQL);

        }

        #endregion

        #region [ 方法: 获取救援措施 ]

        public string GetMeasure(string strEmpID)
        {

            strSQL = "Select 救援措施 From zjw_RT_EmpHelp_View Where EmpID="+strEmpID ;

            return dbacc.ExecuteScalarSql(strSQL);
        }

        #endregion

        #region [ 方法: 保存救援措施 ]

        public int SaveMeasure(string strEmpID, string strMeasure)
        {
            strSQL = "Update RT_EmpHelp Set Measure='" + strMeasure + "' where EmpID=" + strEmpID;

            return dbacc.ExecuteSql(strSQL);
        }

        #endregion

        #region [ 方法: 查询求救信息的总数 ]

        public string GetEmpHelpCounts()
        {
            strSQL = " Select Count(1) as Counts From RT_EmpHelp ";

            return dbacc.ExecuteScalarSql(strSQL);
        }

        #endregion

        #region [ 方法: 删除实时求救信息 ]

        public int DeleteRTEmpHelp(string strEmpID)
        {
            SqlParameter[] sqlParmeters ={
                new SqlParameter("EmpID",SqlDbType.Int) 
            };
            sqlParmeters[0].Value = strEmpID;

            return dbacc.ExecuteSql("zjw_Delete_RT_EmpHelp", sqlParmeters);

        }

        #endregion
    }
}
