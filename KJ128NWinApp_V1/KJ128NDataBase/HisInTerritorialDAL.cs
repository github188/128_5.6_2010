using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class HisInTerritorialDAL
    {
        private DBAcess dbacc = new DBAcess();
        private string strSql = string.Empty;

        #region 查询历史区域员工信息
        public DataSet GetHisInTerInfoSet(int pageIndex, int pageSize, string where, bool blIsEmp)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            if (blIsEmp)
            {
                para[0].Value = "KJ128N_HisInTer_Emp_Info";
            }
            else
            {
                para[0].Value = "KJ128N_HisInTer_Equ_Info";
            }
            para[1].Value = "HisTerritorialID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region 获取区域类别
        public DataSet GetTerTypeInfo()
        {
            strSql = " Select TerritorialTypeID, TypeName From Territorial_Type ";
            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region 获取区域信息
        public DataSet GetTerInfo()
        {
            strSql = " Select TerritorialID, TerritorialName From Territorial_Info ";
            return dbacc.GetDataSet(strSql);
        }
        #endregion
    }
}
