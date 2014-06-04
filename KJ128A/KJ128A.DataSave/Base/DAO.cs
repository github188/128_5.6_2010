using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace KJ128A.DataSave
{
    /// <summary>
    /// Access数据连接
    /// </summary>
    public class DAO
    {
        /// <summary>
        /// Access数据库连接
        /// </summary>
        /// <param name="strMDBName"></param>
        /// <returns></returns>
        public static OleDbConnection GetConn(string strMDBName)
        {
            string strDBPath = System.Windows.Forms.Application.StartupPath.ToString() + @"\AccessDB\" + strMDBName;  //数据库路径
            
            return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strDBPath + ";Jet OLEDB:Database Password=shkj;");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static OleDbConnection GetConnByPath(string path)
        {
            return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + path + ";Jet OLEDB:Database Password=shkj;");
        }
    }
}
