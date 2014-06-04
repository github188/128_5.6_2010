using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KJ128A.DataAPI
{
    /// <summary>
    /// SqlFactory 类
    /// </summary>
    public class SqlFactory: IDbFactory
    {
        #region ICollection 成员

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

        #region IEnumerable 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region [ 构造函数 ]

        /// <summary> 
        /// 构造函数 
        /// </summary> 
        public SqlFactory()
        {
        }

        #endregion

        #region [ 方法: 建立 Connection 对象 ]

        /// <summary> 
        /// 建立默认Connection对象 
        /// </summary> 
        /// <returns>Connection对象</returns> 
        public IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        /// <summary> 
        /// 根据连接字符串建立Connection对象 
        /// </summary> 
        /// <param name="strConn">连接字符串</param> 
        /// <returns>Connection对象</returns> 
        public IDbConnection CreateConnection(string strConn)
        {
            return new SqlConnection(strConn);
        }

        #endregion

        #region IDbFactory 成员
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
