using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class EnumInfoDAL
    {

        #region [ ���� ]
        
        private DBAcess dba = new DBAcess();

        private string strSQL = string.Empty;
        #endregion


        #region [ ����: ����FunID��ö�Ӧ������ ]

        /// <summary>
        /// ����FunID��ö�Ӧ������
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


        #region [ ����: ����Title��FunID��ö�Ӧ��ö������ ]


        public string getEnumID(string title,int funId)
        {
            strSQL = string.Format("select EnumID from EnumTable where Title ='{0}' and FunID = {1}", title, funId);
            object obj = dba.ExecuteScalarSql(strSQL);
            return obj != null ? obj.ToString() : "";
        }

        #endregion

        #region ����FunID��ȡDataSet

        public DataSet GetEnumList(string funId)
        {
            strSQL = string.Format("select EnumID,Title from EnumTable where FunID={0} order by EnumID", funId);
            return dba.GetDataSet(strSQL);
        }

        #endregion
    }
}
