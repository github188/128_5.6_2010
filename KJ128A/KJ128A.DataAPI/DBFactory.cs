using System.Data.OleDb;

namespace KJ128A.DataAPI
{
    /// <summary>
    /// ���ݿ⹤��
    /// </summary>
    public sealed class DBFactory
    {
        #region [ ���캯�� ]
        
        /// <summary> 
		/// Factory�๹�캯�� 
		/// </summary> 
        private DBFactory() 
		{
		} 

        #endregion

        #region [ ����: ����Factory��ʵ�� ]

        /// <summary> 
        /// ����Factory��ʵ�� 
        /// </summary> 
        /// <param name="enumDBType">���ݿ�����</param>
        /// <returns>Factory��ʵ��</returns> 
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
