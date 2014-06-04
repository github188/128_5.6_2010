using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace KJ128NDataBase
{
    public class InfoClassDAL
    {

        #region [ 声明 ]

        DBAcess DB = new DBAcess();

        #endregion

        #region [ 方法: 添加班制信息 ]

        public int InfoClass_Insert(string strClassName, string strShortName, string strRemark, out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ClassName",SqlDbType.VarChar,20),
                new SqlParameter("@ShortName",SqlDbType.VarChar,20),
                new SqlParameter("@Remark",SqlDbType.VarChar,200),
                new SqlParameter("@ID",SqlDbType.Int)
            };

            parameters[0].Value = strClassName;
            parameters[1].Value = strShortName;
            parameters[2].Value = strRemark;
            parameters[3].Value = strClassName.GetHashCode();

            return DB.ExecuteSql("Shine_InfoClass_Add", parameters, out strErr);
        }

        #endregion

        #region [ 方法: 更新班制信息 ]

        public int InfoClass_Update(int intID, string strClassName, string strShortName, string strRemark, out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4),
                new SqlParameter("@ClassName",SqlDbType.VarChar,20),
                new SqlParameter("@ShortName",SqlDbType.VarChar,20),
                new SqlParameter("@Remark",SqlDbType.VarChar,200)
            };

            parameters[0].Value = intID;
            parameters[1].Value = strClassName;
            parameters[2].Value = strShortName;
            parameters[3].Value = strRemark;

            return DB.ExecuteSql("Shine_InfoClass_Update", parameters, out strErr);
        }

        #endregion

        #region [ 方法: 删除班制信息 ]

        public int InfoClass_Delete(int intID, out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4)
            };

            parameters[0].Value = intID;

            return DB.ExecuteSql("Shine_InfoClass_Delete", parameters, out strErr);
        }

        #endregion

        #region [ 方法: 查询班制信息 ]

        public DataSet InfoClass_Query(string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };

            parameters[0].Value = strWhere;

            return DB.ExecuteSqlDataSet("Shine_InfoClass_Query", parameters);
        }

        #endregion
    }
}
