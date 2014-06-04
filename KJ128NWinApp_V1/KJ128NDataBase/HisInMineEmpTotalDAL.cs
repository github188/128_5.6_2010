using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HisInMineEmpTotalDAL
    {
        private DbHelperSQL db = new DbHelperSQL();

        #region [ 方法: 历史下井总数及人员信息统计 ]

        public DataSet HisInMineEmpTotal(int index,int size,string where)
        {
            SqlParameter[] para = { new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,300)
            };
            para[0].Value = index;
            para[1].Value = size;
            para[2].Value = where;

            return db.ReturnDataSet("Shine_djc_HisInMineEmpTotal", para);
        }

        #endregion

    }
}
