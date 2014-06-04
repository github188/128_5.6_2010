using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_PrintBLL
    {

        #region【声明】

        private A_PrintDAL pdal = new A_PrintDAL();

        #endregion

        #region【方法：获取打印时间】

        public DataSet GetPrintTime()
        {
            return pdal.GetPrintTime();
        }

        #endregion

        #region【方法：获取定时打印时间——领导干部下井】

        public DataSet GetPrintTime_Leadership()
        {
            return pdal.GetPrintTime_Leadership();
        }

        #endregion

        #region【方法：获取打印项目】

        public DataSet GetPrint()
        {
            return pdal.GetPrint();
        }

        #endregion
    }
}
