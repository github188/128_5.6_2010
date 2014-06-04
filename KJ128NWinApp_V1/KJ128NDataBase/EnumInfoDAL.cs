using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class EnumInfoDAL
    {

        #region [ 声明 ]
        
        private DBAcess dba = new DBAcess();

        private string strSQL = string.Empty;
        #endregion


        #region [ 方法: 根据FunID获得对应的数据 ]

        /// <summary>
        /// 根据FunID获得对应的数据
        /// </summary>
        /// <param name="funId"></param>
        /// <returns>Title,EnumID</returns>
        public DataTable getEnumInfo(int funId)
        {
            strSQL = string.Format("select Title,EnumID from EnumTable where FunID = {0}", funId);
            using (DataSet ds = dba.GetDataSet(strSQL))
            {
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return new DataTable();
        }

        #endregion


        #region [ 方法: 根据Title和FunID获得对应的枚举数据 ]


        public string getEnumID(string title,int funId)
        {
            strSQL = string.Format("select EnumID from EnumTable where Title ='{0}' and FunID = {1}", title, funId);
            object obj = dba.ExecuteScalarSql(strSQL);
            return obj != null ? obj.ToString() : "";
        }

        #endregion

        #region 根据FunID获取DataSet

        public DataSet GetEnumList(string funId)
        {
            strSQL = string.Format("select EnumID,Title from EnumTable where FunID={0} order by EnumID", funId);
            return dba.GetDataSet(strSQL);
        }

        #endregion
    }
}
