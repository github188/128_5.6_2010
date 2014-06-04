using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class Li_HisInOutMineDAL
    {
        private DBAcess dbacc = new DBAcess();

        #region [ 方法: 查询历史下井记录 ]

        public DataSet GetHisInOutMineSet(string where)
        {
            SqlParameter[] para = { new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };

            para[0].Value = where;

            return dbacc.ExecuteSqlDataSet("zjw_HisInOutMine_Select", para);
        }

        #endregion

        #region 获得设备查询表
        /// <summary>
        /// 获得查询表
        /// </summary>
        /// <param name="strEquID">设备名称</param>
        /// <param name="strDeptID">部门编号</param>
        /// <param name="strFactoryID">生产厂家</param>
        /// <param name="strInStationHeadTime">下井时间</param>
        /// <param name="strOutStationHeadTime">上井时间</param>
        /// <returns>表</returns>
        public DataSet GetConditionEqu(string strEquID, string strDeptID, string strFactoryID, string strEquType, string strInTime, string strOutTime)
        {
            // 获得查询参数
            string[,] strArr = new string[6, 4] 
            {
                {"Eb.EquName","=",strEquID,"string"},
                {"Di.DeptName","=",strDeptID,"string"},
                {"Fi.FactoryID","=",strFactoryID,"int"},
                {"Ei.EnumID","=",strEquType,"int"},
                {"Hi.InTime",">=",strInTime,"datetime"},
                {"Hi.OutTime","<=",strOutTime,"datetime"}
            };

            // 将参数转换为语句
            string strSQL = string.Empty;

            for (int i = 0; i < (strArr.GetUpperBound(0) + 1); i++)
            {
                if (strArr[i, 2].Trim() != "0")
                {
                    //都是精确查询
                    if (strArr[i, 3] == "datetime")
                    {
                        strArr[i, 2] = "'" + strArr[i, 2].Trim() + "'";
                    }

                    if (strArr[i, 3] == "string")
                    {
                        strArr[i, 1] = "  like  ";
                        strArr[i, 2] = "'%" + strArr[i, 2].Trim() + "%'";
                    }

                    strSQL += " and " + strArr[i, 0] + strArr[i, 1] + strArr[i, 2] + " ";
                }
            }

            string strProcName = "KJ128N_His_InoutMine_Query_Equ";
            SqlParameter[] sqlPar ={ 
                new SqlParameter("strWhere",DbType.String)
            };

            sqlPar[0].Value = strSQL;
            return dbacc.ExecuteSqlDataSet(strProcName, sqlPar);
        }
        #endregion 
    }
}
