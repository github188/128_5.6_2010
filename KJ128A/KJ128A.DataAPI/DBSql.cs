using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KJ128A.DataAPI
{
    /// <summary>
    /// SQL Server ���ݿ�
    /// </summary>
    public class DBSql: IDisposable
    {
        private readonly string _DBConnectionString = string.Empty;

        private readonly IDbFactory _dbFactory;
        private IDbConnection _dbConn;
        private IDbCommand _dbCommand;

        #region [ ���캯�� ]

        /// <summary>
        /// ���캯��
        /// </summary>
        public DBSql(string strConnectionString, EnumDBType enumDBType)
        {
            _dbFactory = DBFactory.CreateInstance(enumDBType);

            // ���������ַ���
            _DBConnectionString = strConnectionString;

            CreateConnection();
        }

        #endregion

        #region [ ����: �������� ]

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        private bool CreateConnection()
        {
            _dbConn = _dbFactory.CreateConnection();
            _dbConn.ConnectionString = _DBConnectionString;

            return true;
        }

        #endregion

        #region [ ����: �������� ]

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        private bool CreateCommand(string strCmdText, CommandType cmdType)
        {
            _dbCommand = _dbFactory.CreateCommand();
            _dbCommand.Connection = _dbConn;

            _dbCommand.CommandText = strCmdText;
            _dbCommand.CommandType = cmdType;

            return true;
        }

        #endregion

        #region [ ����: ִ�д洢���� ]

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <returns></returns>
        public int ExecProc(string strCmdText, IDbDataParameter[] dbParams)
        {
            CreateCommand(strCmdText, CommandType.StoredProcedure);

            foreach (IDbDataParameter sqlParameter in dbParams)
            {
                _dbCommand.Parameters.Add(sqlParameter);
            }

            return _dbCommand.ExecuteNonQuery();
        }

        #endregion

        #region [ ����: ������ ]

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                _dbConn.Open();
            }
            catch
            {
                
            }
            
            return true;
        }

        #endregion

        #region [ ����: �ر����� ]

        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            _dbConn.Close();
            return true;
        }

        #endregion

        #region [ ����: �������ӵ����ݿ� ]

        private bool _ConnectionToDB;

        /// <summary>
        /// �������ӵ����ݿ�
        /// </summary>
        public bool ConnectionToDB
        {
            get { return _ConnectionToDB ; }
            set { _ConnectionToDB = value; }
        }

        #endregion

        #region IDisposable ��Ա

        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        public void Dispose()
        {
            _dbConn.Dispose();
            _dbConn = null;
        }

        #endregion
    }
}
