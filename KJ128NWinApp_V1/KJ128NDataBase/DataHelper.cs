using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace KJ128NDataBase
{
    /*
     * 李乐
     */

    /// <summary>
    /// 查询需要的数据
    /// </summary>
    public class DataHelper
    {
        private static DbHelperSQL help = new DbHelperSQL();

        private string outStr = String.Empty;

        /// <summary>
        /// 获取传输分站信息
        /// </summary>
        /// <returns>数据表</returns>
        public static DataTable GetStationInfo()
        {
           return help.ReturnDataTable("select_StationInfo", null);
        }

        /// <summary>
        /// 根据传输分站地址获取所属读卡分站
        /// </summary>
        /// <param name="stationAddress">传输分站地址</param>
        /// <returns>数据表</returns>
        public static DataTable GetPointInfo(int stationAddress)
        {
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@stationAddress", SqlDbType.Int)
            };

            para[0].Value = stationAddress;

            return help.ReturnDataTable("select_StationHeadInfo", para);

        }

        /// <summary>
        /// 根据部门获取员工信息
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns>数据表</returns>
        public static DataTable GetEmpInfo(int deptId)
        {
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@DeptId", SqlDbType.Int)
            };

            para[0].Value = deptId;
            return help.ReturnDataTable("select_Emp_Info", para);
        }

        /// <summary>
        /// 获取部门名
        /// </summary>
        /// <returns>数据表</returns>
        public static DataTable GetDeptInfo()
        {
            return help.ReturnDataTable("select_Dept_Info", null);
        }

        /// <summary>
        /// 获取重点区域信息名称
        /// </summary>
        /// <returns>数据表</returns>
        public static DataTable GetKeyAreaInfo()
        {
            return help.ReturnDataTable("selectKeyAreaInfo", null);
        }

        /// <summary>
        /// 获取限制区域信息名称
        /// </summary>
        /// <returns>数据表</returns>
        public static DataTable GetConfineAreaInfo()
        {
            return help.ReturnDataTable("selectConfineAreaInfo", null);
        }

        /// <summary>
        /// 获取地域信息名称
        /// </summary>
        /// <returns>数据表</returns>
        public static DataTable GetClimeInfo()
        {
            return help.ReturnDataTable("selectClimeInfo", null);
        }
    }

    /// <summary>
    /// 查找数据记录是否存在
    /// </summary>
    public class RecordSearch
    {

        private static DbHelperSQL help = new DbHelperSQL();

        private static string outStr = String.Empty;

        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="dataTpye">数据类型</param>
        /// <returns>返回是否存在 true表示存在 false表示不存在</returns>
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
                //测试查看异常信息
                throw ex;
                //return false;
            }
        }

        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strWhere">SQL查询条件（sql语句中where后面的条件）</param>
        /// <returns>返回是否存在 true表示存在 false表示不存在</returns>
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
                //测试查看异常信息
                throw ex;
                //return false;
            }
        }
    }

    /// <summary>
    /// 表示数据类型
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// 字符型
        /// </summary>
        String,

        /// <summary>
        /// 时间日期型
        /// </summary>
        DateTime,
 
        /// <summary>
        /// 整型
        /// </summary>
        Int,

        /// <summary>
        /// 小数型
        /// </summary>
        Decimal
    }
}
