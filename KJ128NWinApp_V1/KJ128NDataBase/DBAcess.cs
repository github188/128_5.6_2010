using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.Windows.Forms;
using KJ128NModel;
namespace KJ128NDataBase
{
    /// <summary>
    /// ���ݷ��ʲ�
    /// </summary>
    public class DBAcess:IDBAcess
    {
        #region ˽�б���
        //private static string m_ConnectionString_KJ128 =ConfigurationSettings.AppSettings["ConnectionString"];
        //private SqlConnection m_SqlConnection=new SqlConnection(m_ConnectionString_KJ128);
        New_DBAcess NDA = new New_DBAcess();
        SerialModel SM = new SerialModel();
        SerialAndReserialOperate SARO = new SerialAndReserialOperate();
        #endregion

        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public DBAcess()
        {
            //XmlDocument xmld = new XmlDocument();
            //xmld.Load(@"./app.config");
            //XmlNode xmldd = xmld.SelectSingleNode("add");
            //m_ConnectionString_KJ128 = xmldd.Attributes["connectionString"].ToString();
            //m_SqlConnection = new SqlConnection(m_ConnectionString_KJ128);
        }
        #endregion

        #region  ��Czlt-2011-01-28 �����ַ�����
        public string GetConn()
        {
            return New_DBAcess.strConn;
        }

        #endregion
        #region �����ַ�������������
        /// <summary>
        ///  ����һ������
        /// </summary>
        /// <returns>������Ϣ</returns>
        public int CreateConnection()
        {
            //try
            //{

            //    m_SqlConnection.Open();
            //    return 0;
            //}
            //catch
            //{
            //    return -1;
            //}
            return NDA.CreateConnection();
        }
        /// <summary>
        /// �ر�һ������
        /// </summary>
        /// <returns></returns>
        public int CloseConnection()
        {
            //try
            //{
            //    m_SqlConnection.Close();
            //    return 0;
            //}
            //catch
            //{
            //    return -1;
            //}
            return NDA.CloseConnection();
        }
        #endregion

        #region ��Ȿ�汾��KJ128A���򷵻�True,����汾ΪKJ128N���򷵻�False
        public bool CheckIsKJ128A()
        {
            bool Flag = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath+"\\IsKJ128AOrKJ128N.xml");
            if (Convert.ToBoolean(doc.ChildNodes[1].ChildNodes[0].InnerText))
            {
                Flag = true;
            }
            return Flag;
            
        }
        #endregion

        #region ����

        #region ִ��Sql����洢���̣�����һ��DataSet
        /// <summary>
        /// ִ��һ���洢���̣�����һ��DataSet��¼��
        /// </summary>
        /// <param name="procName">�洢���̵�����</param>
        /// <param name="sqlParmeters">�洢���̵Ĳ���</param>
        /// <returns>DataSet��ļ�¼��</returns>
        public DataSet GetDataSet(string procName,SqlParameter[] sqlParmeters)
        {
            return NDA.GetDataSet(procName, sqlParmeters);
            
        }
        /// <summary>
        ///ִ��һ��SQL���,����һ��DataSet��¼��
        /// </summary>
        /// <param name="sqlText">һ��Sql���</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string sqlText)
        {
            return NDA.GetDataSet(sqlText);
        }
        /// <summary>
        /// ����һ��SqlCommand����
        /// </summary>
        /// <param name="procName">��������</param>
        /// <param name="sqlParmeters">��������</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildSqlCommand(SqlConnection sqlConn,string procName,SqlParameter[] sqlParmeters)
        {
            SqlCommand sqlComm = new SqlCommand(procName, sqlConn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            if (sqlParmeters != null)
            {
                foreach (SqlParameter sqlParameter in sqlParmeters)
                {
                    sqlComm.Parameters.Add(sqlParameter);
                }
            }
            return sqlComm;
        }
        /// <summary>
        /// ����һ��SqlCommand����
        /// </summary>
        /// <param name="sqlConn">����</param>
        /// <param name="sqlText">sql���</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildSqlCommand(SqlConnection sqlConn, string sqlText)
        {
            SqlCommand sqlComm = new SqlCommand(sqlText, sqlConn);
            sqlComm.CommandType = CommandType.Text;
            return sqlComm;
        }
        #endregion

        #region ִ��SQL����洢���̣�����Ӱ������� int
        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <returns>Ӱ�������,-1 ִ��ʧ��</returns>
        public int ExecuteSql(string procName,SqlParameter[] sqlParameters)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql1";
            //    SM.parameter = new parameters[sqlParameters.Length];
            //    for (int i = 0; i < sqlParameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = sqlParameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = sqlParameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = sqlParameters[i].Size;
            //        SM.parameter[i].objValue = sqlParameters[i].Value;
                    
            //    }
            //    SM.RestoryProcedureName = procName;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }
                
            //}
            //else
            //{
            intValue =  NDA.ExecuteSql(procName, sqlParameters);
            //}

            return intValue;
        }

        public int ExecCommand(SqlCommand comm)
        {
            return NDA.ExecCommand(comm);
        }


        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <returns>Ӱ�������,-1 ִ��ʧ��</returns>
        public int ExecuteSql(string procName, SqlParameter[] sqlParameters,out string strErr)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql2";
            //    SM.parameter = new parameters[sqlParameters.Length];
            //    for (int i = 0; i < sqlParameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = sqlParameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = sqlParameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = sqlParameters[i].Size;
            //        SM.parameter[i].objValue = sqlParameters[i].Value;

            //    }
            //    SM.RestoryProcedureName = procName;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //        strErr = "Succeeds";
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue =  NDA.ExecuteSql(procName, sqlParameters, out strErr);
            //}
            strErr = "Succeeds";
            return intValue;
        }
        /// <summary>
        /// ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <param name="sqlConn">Sql���Ӷ���</param>
        /// <returns>Ӱ�������,-1 ִ��ʧ��</returns>
        public int ExecuteSql(string procName,SqlParameter[] sqlParameters,SqlConnection sqlConn)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql3";
            //    SM.parameter = new parameters[sqlParameters.Length];
            //    for (int i = 0; i < sqlParameters.Length; i++)
            //    {
            //        SM.parameter[i].ParameterName = sqlParameters[i].ParameterName;
            //        SM.parameter[i].ParameterType = sqlParameters[i].SqlDbType;
            //        SM.parameter[i].intLongth = sqlParameters[i].Size;
            //        SM.parameter[i].objValue = sqlParameters[i].Value;

            //    }
            //    SM.RestoryProcedureName = procName;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDA.ExecuteSql(procName, sqlParameters, sqlConn);
            //}

            return intValue;
        }
        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="sqlString">Sql���</param>
        /// <param name="sqlConn">sql���Ӷ���</param>
        /// <returns>Ӱ������� -1 ʧ��</returns>
        public int ExecuteSql(string sqlString,SqlConnection sqlConn)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql4";
               
            //    SM.strSql = sqlString;

            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue =  NDA.ExecuteSql(sqlString, sqlConn);
            //}
            return intValue;
        }


        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="sqlString">Sql���</param>
        /// <returns>Ӱ������� -1 ʧ��</returns>
        public int ExecuteSql(string sqlString)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql5";

            //    SM.strSql = sqlString;


            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue=NDA.ExecuteSql(sqlString);
            //}
            return intValue;

        }

        #region Connection�� �ر�

        //private void ConnOpen()
        //{
        //    if (this.m_SqlConnection.State != ConnectionState.Open)
        //    {
        //        this.m_SqlConnection.Open();
        //    }
        //}

        //private void ConnClose()
        //{
        //    if (this.m_SqlConnection.State != ConnectionState.Closed)
        //    {
        //        this.m_SqlConnection.Close();
        //    }
        //}

        #endregion

        #region ���ؽ�����е�һ�е�һ�е�ֵ

        public string ExecuteScalarSql(string sqlString)
        {
            return NDA.ExecuteScalarSql(sqlString);

        }

        #endregion

        /// <summary>
        ///  ִ��SQL����洢���̣�����Ӱ������� int
        /// </summary>
        /// <param name="sqlString">Sql���</param>
        /// <returns>Ӱ������� -1 ʧ��</returns>
        public int ExistsSql(string sqlString)
        {
            int intValue = 0;
            //if (CheckIsKJ128A())
            //{
            //    SM.FuntionName = "ACCESS_ExecuteSql6";

            //    SM.strSql = sqlString;


            //    if (SARO.DataReceived(SARO.SerialOperate(SM)))
            //    {
            //        intValue = 1;
            //    }
            //    else
            //    {
            //        intValue = -1;
            //    }

            //}
            //else
            //{
                intValue = NDA.ExistsSql(sqlString);
            //}

            return intValue;

        }
        #endregion

        #region MyRegion

        #region ִ��Sql����洢���̣�����һ��DataSet
        /// <summary>
        /// ִ��һ���洢���̣�����һ��DataSet��¼��
        /// </summary>
        /// <param name="procName">�洢���̵�����</param>
        /// <param name="sqlParmeters">�洢���̵Ĳ���</param>
        /// <returns>DataSet��ļ�¼��</returns>
        public SqlDataReader GetDataReader(string sqlString)
        {
            return NDA.GetDataReader(sqlString);
        }

        #endregion
        #endregion

        #endregion

        #region ִ��SQL����洢���̣�����DataSet
        /// <summary>
        /// 
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="sqlParameters">�洢���̲���</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteSqlDataSet(string procName, SqlParameter[] sqlParameters)
        {
            DataSet ds = NDA.ExecuteSqlDataSet(procName, sqlParameters) == null ? new DataSet() : NDA.ExecuteSqlDataSet(procName, sqlParameters);
            return ds;
        }

        #endregion

        #region ����
        /// <summary>
        /// �õ�һ�������ַ���
        /// </summary>
        //public string ConnectionStringKJ128N
        //{
        //    get { return m_ConnectionString_KJ128; }
        //    set { m_ConnectionString_KJ128 = value; }
        //}
        #endregion

    }
}
