using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_StatementBLL
    {
        #region【声明】

        private A_StatementDAL sdal = new A_StatementDAL();

        #endregion

        
        #region【方法：查询——下井人员统计】

        public DataSet Get_EmpInWellStatement(string strDate)
        {
            return sdal.Get_EmpInWellStatement(strDate);
        }

        #endregion

        #region【方法：查询——重点区域人员统计】

        public DataSet Get_KeyAreaStatement(string strDate)
        {
            return sdal.Get_KeyAreaStatement(strDate);
        }

        #endregion

        #region【方法：查询——限制区域报警人员统计】

        public DataSet Get_ConfineAreaStatement(string strDate)
        {
            return sdal.Get_ConfineAreaStatement(strDate);
        }

        #endregion

        #region【方法：查询——超时报警人员统计】

        public DataSet Get_OverTimeEmpStatement(string strDate)
        {
            return sdal.Get_OverTimeEmpStatement(strDate);
        }

        #endregion


        #region【Czlt-2010-11-10-领导干部日下井统计】

        public DataSet Get_LearderDayStatement(string strDate)
        {
            return sdal.Get_LearderDayStatement(strDate);

        }

        #endregion
    }
}
