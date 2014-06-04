using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class Li_HisInOutStationHeadRecodsetDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        #endregion


        #region [ 方法: 获取(分站,接收器)基本信息 ]

        public DataSet GetStationInfo()
        {
            string strSql = " Select StationAddress, StationPlace From Station_Info ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetStationHeadInfo(string strStationAddress)
        {
            string strSql = " Select StationHeadAddress, StationHeadPlace From Station_Head_Info Where StationAddress = " + strStationAddress;
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询历史进出接收器信息 ]

        public DataSet GetInOutStationHeadSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "KJ128N_HisInOutStationHead_Info_View";
            para[1].Value = "HisStationHeadID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }

        #endregion

        #region [ 方法: 获得设备查询表 ]

        /// <summary>
        /// 获得查询表
        /// </summary>
        /// <param name="strEquID">设备名称</param>
        /// <param name="strDeptID">部门编号</param>
        /// <param name="strFactoryID">生产厂家</param>
        /// <param name="strInStationHeadTime">进入分站时间</param>
        /// <param name="strOutStationHeadTime">离开分站时间</param>
        /// <returns>表</returns>
        public DataSet GetConditionEqu(string strEquID, string strDeptID, string strFactoryID, string strEquType, string strInStationHeadTime, string strOutStationHeadTime)
        {
            // 获得查询参数
            string[,] strArr = new string[6, 4] 
            {
                {"Eb.EquName","=",strEquID,"string"},
                {"Di.DeptName","=",strDeptID,"string"},
                {"Fi.FactoryID","=",strFactoryID,"int"},
                {"Ei.EnumID","=",strEquType,"int"},
                {"Hi.InStationHeadTime",">=",strInStationHeadTime,"datetime"},
                {"Hi.OutStationHeadTime","<=",strOutStationHeadTime,"datetime"}
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

            string strProcName = "KJ128N_HisStationHead_Query_Equ";
            SqlParameter[] sqlPar ={ 
                new SqlParameter("strWhere",DbType.String)
            };

            sqlPar[0].Value = strSQL;
            return dbacc.ExecuteSqlDataSet(strProcName, sqlPar);
        }
        #endregion 
    }
}
