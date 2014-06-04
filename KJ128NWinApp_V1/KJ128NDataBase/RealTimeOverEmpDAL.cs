using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class RealTimeOverEmpDAL
    {

        #region [ 申明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion


        #region [ 方法: 查询超员信息 ]

        public DataSet SelectOverEmp(int intOverEmpType)
        {
            strSql = " Select " +
                        " RT_RatingEmployeesCount as 额定下井人数 , " +
                        " RT_FactEmployeeCount as 当前下井人数, " +
                        " RT_FactEmployeeCount-RT_RatingEmployeesCount as 超员人数, " +
                        " RT_OverEmployeeBeginTime as 超员开始时间, " +
                        " dbo.FunConvertTime((Select DateDiff(ss, Ro.RT_OverEmployeeBeginTime, getDate()))) As 持续时间" +
                     " From " +
                        " RT_OverEmployees as Ro" +
                     " Where " +
                        " Ro.RT_OverEmployeeTypeID = " + intOverEmpType.ToString();

            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
