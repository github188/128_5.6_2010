using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace KJ128NDataBase
{
    public class CustomerDAL
    {
        DbHelperSQL DB = new DbHelperSQL();
        #region 以列表的形式获取所有的数据

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public DataSet GetList(out string ErrMsgString)
        {
            return DB.RunProcedureByDataSet("Shine_Customer_GetList", "ds", out ErrMsgString);
        }

        #endregion
    }
}
