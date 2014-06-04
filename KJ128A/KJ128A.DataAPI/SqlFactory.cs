using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KJ128A.DataAPI
{
    /// <summary>
    /// SqlFactory ��
    /// </summary>
    public class SqlFactory: IDbFactory
    {
        #region ICollection ��Ա

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSynchronized
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        /// <summary>
        /// 
        /// </summary>
        public object SyncRoot
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region IEnumerable ��Ա
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region [ ���캯�� ]

        /// <summary> 
        /// ���캯�� 
        /// </summary> 
        public SqlFactory()
        {
        }

        #endregion

        #region [ ����: ���� Connection ���� ]

        /// <summary> 
        /// ����Ĭ��Connection���� 
        /// </summary> 
        /// <returns>Connection����</returns> 
        public IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        /// <summary> 
        /// ���������ַ�������Connection���� 
        /// </summary> 
        /// <param name="strConn">�����ַ���</param> 
        /// <returns>Connection����</returns> 
        public IDbConnection CreateConnection(string strConn)
        {
            return new SqlConnection(strConn);
        }

        #endregion

        #region IDbFactory ��Ա
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        #endregion
    }
}
