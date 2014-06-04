using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class RTDirectionalAntennaDAL
    {
        private DbHelperSQL DB = new DbHelperSQL();

        #region 实时探头方向性 Proc_RT_DirectionalAntenna

        public DataSet Query_RT_DirectionalAntenna(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.VarChar,2000)
            };

            parameter[0].Value = intPageSize;
            parameter[1].Value = intPageIndex-1;
            parameter[2].Value = strWhere;

            return DB.RunProcedureByDataSet("Proc_RT_DirectionalAntenna", "dst", parameter, out strErr);
        }

        #endregion
    }
}
