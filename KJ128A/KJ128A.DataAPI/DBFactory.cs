using System.Data.OleDb;

namespace KJ128A.DataAPI
{
    /// <summary>
    /// 数据库工厂
    /// </summary>
    public sealed class DBFactory
    {
        #region [ 构造函数 ]
        
        /// <summary> 
		/// Factory类构造函数 
		/// </summary> 
        private DBFactory() 
		{
		} 

        #endregion

        #region [ 方法: 建立Factory类实例 ]

        /// <summary> 
        /// 建立Factory类实例 
        /// </summary> 
        /// <param name="enumDBType">数据库类型</param>
        /// <returns>Factory类实例</returns> 
        public static IDbFactory CreateInstance(EnumDBType enumDBType)
        {
            IDbFactory dbFactory = null;

            switch (enumDBType)
            {
                case EnumDBType.Sql:
                    dbFactory = new SqlFactory();
                    break;
                
                case EnumDBType.Access:
                    //dbFactory = new OleDbFactory();
                    break;
            }

            return dbFactory;
        }

        #endregion
    }
}
