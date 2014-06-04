using System;
using System.Collections.Generic;
using System.Text;
using KJ128NInterfaceShow;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class RealTimeOverEmpBLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private RealTimeOverEmpDAL rtoedal = new RealTimeOverEmpDAL();

        #endregion

        #region [ 方法: 查询超员信息 ]

        /// <summary>
        /// 查询超员信息
        /// </summary>
        /// <param name="intOverEmpType">超员类别,1:超员;2:欠员</param>
        /// <param name="dv"></param>
        /// <returns>True:成功;False:失败</returns>
        public bool SelectOverEmp(int intOverEmpType, DataGridViewKJ128 dv)
        {
            try
            {
                using (ds = new DataSet())
                {
                    dv.Columns.Clear();

                    ds = rtoedal.SelectOverEmp(intOverEmpType);

                    //if (ds == null)
                    //{
                    //    return false;
                    //}
                    ds.Tables[0].TableName = "TaskTimeBLL_RtOverEmp";
                    dv.DataSource = ds.Tables[0].DefaultView;

                }
            }
            catch 
            {
                return false;
            }

            return true;
            
        }

        #endregion
    }
}
