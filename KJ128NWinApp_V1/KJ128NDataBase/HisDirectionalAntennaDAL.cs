using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
    public class HisDirectionalAntennaDAL
    {
        private DbHelperSQL DB = new DbHelperSQL();

        #region 历史探头方向性 Proc_His_DirectionalAntenna

        public DataSet Query_His_DirectionalAntenna(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.VarChar,2000)
            };

            parameter[0].Value = intPageSize;
            parameter[1].Value = intPageIndex - 1;
            parameter[2].Value = strWhere;

            return DB.RunProcedureByDataSet("Proc_His_DirectionalAntenna", "dst", parameter, out strErr);
        }

        #endregion

        #region 历史进出读卡分站 Proc_His_InOutReceiver

        public DataSet Query_His_InOutReceiver(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.VarChar,2000)
            };

            parameter[0].Value = intPageSize;
            parameter[1].Value = intPageIndex - 1;
            parameter[2].Value = strWhere;

            return DB.RunProcedureByDataSet("Proc_His_InOutReceiver", "dst", parameter, out strErr);
        }

        #endregion

        #region 历史进出读卡分站 Proc_His_InOutReceiver

        public DataSet Query_His_InOutArea(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.VarChar,2000)
            };

            parameter[0].Value = intPageSize;
            parameter[1].Value = intPageIndex - 1;
            parameter[2].Value = strWhere;

            return DB.RunProcedureByDataSet("Proc_His_Area", "dst", parameter, out strErr);
        }

        #endregion
    }
}
