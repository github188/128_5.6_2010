using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class EmpInfoBLL
    {

        #region [ 声明 ]

        private EmpInfoDAL eidal = new EmpInfoDAL();

        private DataSet ds;
        #endregion

        #region [ 方法: 获取人员信息 ]

        public DataTable GetEmpInfo(string strID, bool blIsEmp)
        {
            using (ds=new DataSet())
            {
                ds = eidal.GetEmpInfo(strID,blIsEmp);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }

            }
            return null;
        }

        #endregion
    }
}
