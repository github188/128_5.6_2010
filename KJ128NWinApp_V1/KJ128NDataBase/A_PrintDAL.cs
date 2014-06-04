using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class A_PrintDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private string strSql;

        #endregion

        #region [ 方法: 获取定时打印时间 ]

        public DataSet GetPrintTime()
        {
            strSql = " Select EnumValue From EnumTable Where FunID=16 and EnumID =1";

            return dba.GetDataSet(strSql);
        }

        #endregion

        #region【方法：获取定时打印时间——领导干部下井】

        public DataSet GetPrintTime_Leadership()
        {
            strSql = " Select EnumValue From EnumTable Where FunID=15 and EnumID =7";

            return dba.GetDataSet(strSql);
        }

        #endregion

        #region【方法：获取打印项目】

        public DataSet GetPrint()
        {
            strSql = " Select EnumValue,EnumID From EnumTable Where FunID=15 ";

            return dba.GetDataSet(strSql);
        }

        #endregion

    }
}
