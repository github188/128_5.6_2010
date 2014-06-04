using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace KJ128NDataBase
{
    /*
     * ����
     */

    /// <summary>
    /// ��ѯ��Ҫ������
    /// </summary>
    public class DataHelper
    {
        private static DbHelperSQL help = new DbHelperSQL();

        private string outStr = String.Empty;

        /// <summary>
        /// ��ȡ�����վ��Ϣ
        /// </summary>
        /// <returns>���ݱ�</returns>
        public static DataTable GetStationInfo()
        {
           return help.ReturnDataTable("select_StationInfo", null);
        }

        /// <summary>
        /// ���ݴ����վ��ַ��ȡ����������վ
        /// </summary>
        /// <param name="stationAddress">�����վ��ַ</param>
        /// <returns>���ݱ�</returns>
        public static DataTable GetPointInfo(int stationAddress)
        {
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@stationAddress", SqlDbType.Int)
            };

            para[0].Value = stationAddress;

            return help.ReturnDataTable("select_StationHeadInfo", para);

        }

        /// <summary>
        /// ���ݲ��Ż�ȡԱ����Ϣ
        /// </summary>
        /// <param name="deptId">����ID</param>
        /// <returns>���ݱ�</returns>
        public static DataTable GetEmpInfo(int deptId)
        {
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@DeptId", SqlDbType.Int)
            };

            para[0].Value = deptId;
            return help.ReturnDataTable("select_Emp_Info", para);
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <returns>���ݱ�</returns>
        public static DataTable GetDeptInfo()
        {
            return help.ReturnDataTable("select_Dept_Info", null);
        }

        /// <summary>
        /// ��ȡ�ص�������Ϣ����
        /// </summary>
        /// <returns>���ݱ�</returns>
        public static DataTable GetKeyAreaInfo()
        {
            return help.ReturnDataTable("selectKeyAreaInfo", null);
        }

        /// <summary>
        /// ��ȡ����������Ϣ����
        /// </summary>
        /// <returns>���ݱ�</returns>
        public static DataTable GetConfineAreaInfo()
        {
            return help.ReturnDataTable("selectConfineAreaInfo", null);
        }

        /// <summary>
        /// ��ȡ������Ϣ����
        /// </summary>
        /// <returns>���ݱ�</returns>
        public static DataTable GetClimeInfo()
        {
            return help.ReturnDataTable("selectClimeInfo", null);
        }
    }

    /// <summary>
    /// �������ݼ�¼�Ƿ����
    /// </summary>
    public class RecordSearch
    {

        private static DbHelperSQL help = new DbHelperSQL();

        private static string outStr = String.Empty;

        /// <summary>
        /// �жϼ�¼�Ƿ����
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="fieldName">�ֶ���</param>
        /// <param name="fieldValue">�ֶ�ֵ</param>
        /// <param name="dataTpye">��������</param>
        /// <returns>�����Ƿ���� true��ʾ���� false��ʾ������</returns>
        public static bool IsRecordExists(string tableName, string fieldName, string fieldValue, DataType dataTpye)
        {
            try
            {
                string sqlStr = "select * from " + tableName + " where " + fieldName + " = ";

                switch (dataTpye)
                {
                    case DataType.String:

                    case DataType.DateTime:
                        sqlStr += "'" + fieldValue + "'";

                        break;

                    case DataType.Int:

                    case DataType.Decimal:
                        sqlStr += fieldValue;
                        break;
                    default:
                        sqlStr += fieldValue;
                        break;
                }

                bool result = help.Exists(sqlStr);

                return result;
            }
            catch(Exception ex)
            {
                //���Բ鿴�쳣��Ϣ
                throw ex;
                //return false;
            }
        }

        /// <summary>
        /// �жϼ�¼�Ƿ����
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="strWhere">SQL��ѯ������sql�����where�����������</param>
        /// <returns>�����Ƿ���� true��ʾ���� false��ʾ������</returns>
        public static bool IsRecordExists(string tableName, string strWhere)
        {
            try
            {
                string sqlStr = "select * from " + tableName + " where " + strWhere;

                bool result = help.Exists(sqlStr);

                return result;
            }
            catch (Exception ex)
            {
                //���Բ鿴�쳣��Ϣ
                throw ex;
                //return false;
            }
        }
    }

    /// <summary>
    /// ��ʾ��������
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// �ַ���
        /// </summary>
        String,

        /// <summary>
        /// ʱ��������
        /// </summary>
        DateTime,
 
        /// <summary>
        /// ����
        /// </summary>
        Int,

        /// <summary>
        /// С����
        /// </summary>
        Decimal
    }
}
