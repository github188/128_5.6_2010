using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    /// <summary>
    /// 分站配置信息
    /// </summary>
    public class A_StationConfigInfoDAL
    {
        #region[声明]

        private DBAcess dba = new DBAcess();

        #endregion

        /// <summary>
        /// 查询分站信息
        /// </summary>
        /// <param name="selectModel">查询模式 0传输分站 1读卡分站 2为全部传输分站 </param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>数据集</returns>
        public DataSet SelectStationConfigInfo(int selectModel, string strWhere)
        {
            SqlParameter[] para = { new SqlParameter("@selectModel",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };

            para[0].Value = selectModel;
            para[1].Value = strWhere;

            //Czlt-2011-11-22 交直流供电
            DataSet ds = new DataSet();
            if (selectModel.ToString().Trim().Equals("0"))
            {
                ds = dba.ExecuteSqlDataSet("proc_Czlt_TcpStationMode", para);
            }
            else
            {
                ds = dba.ExecuteSqlDataSet("selectStationConfigInfo", para);
            }

            //Czlt-2011-11-22注销
            //DataSet ds = dba.ExecuteSqlDataSet("selectStationConfigInfo", para);

            return ds;
        }
    }
}
