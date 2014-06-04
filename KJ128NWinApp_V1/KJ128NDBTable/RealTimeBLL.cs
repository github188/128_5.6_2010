using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDBTable
{
    public class RealTimeBLL
    {

        #region [ 声明 ]

        private RealTimeDAL rtdal = new RealTimeDAL();

        string strSql = string.Empty;

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 部门表信息 ]

        // 填充部门树
        public DataTable getDeptInfo()
        {
            return rtdal.getDeptInfo();
        }

        #endregion

        #region [ 方法: 实时部门人员信息 ]

        //View_GetRTEmptyCardInfo 实时部门人员信息
        public DataSet getRTEmptyCardInfo(int pageIndex, int pageSize)
        {
            return rtdal.N_getRTEmptyCardInfo(pageIndex, pageSize);
        }

        #endregion

        #region [ 方法: 实时部门人员信息 ]

        //View_GetRTDeptEmpInfo 实时部门人员信息
        public DataSet getRTDeptInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_getRTDeptInfo(pageIndex, pageSize, where);
        }

        #endregion

        #region [ 方法:  实时部门设备信息 ]

        //View_GetRTDeptEmpInfo 实时部门设备信息
        public DataSet getRTDeptEquInfo(int pageIndex, int pageSize, string where)
        {
            //return rtdal.N_getRTDeptInfo(pageIndex, pageSize, where);
            return rtdal.N_getRTDeptEquInfo(pageIndex, pageSize, where);
        }

        #endregion

        #region [ 方法: 实时下井 ]

        #region 实时下井人员信息

        public DataSet getRTInWellEmpInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_getRTInWellEmpInfo(pageIndex, pageSize, where);
        }

        #endregion

        #region 实时下井设备
        //View_GetInWellEquInfo 实时部门设备信息
        public DataSet getRTInWellEquInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_getRTInWellEquInfo(pageIndex, pageSize, where);
        }

        #endregion

        #endregion

        #region [ 方法: 部门和该部门实时下井人数 ]

        public DataSet GetDeptEmpInWellInfo()
        {
            return rtdal.GetDeptEmpInWellInfo();
        }
        //赵
        public DataSet GetEmpInWellInfo()
        {
            return rtdal.GetEmpInWellInfo();
        }
        #endregion

        #region [ 方法: 部门和该部门实时下井人数 ]

        //View_GetRTDeptEmpInfo 实时部门人员信息
        public DataSet GetRTDeptAllEmpInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_GetRTDeptAllEmpInfo(pageIndex, pageSize, where);
        }

        //赵
        public DataSet GetRTInMineEmpInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_GetRTInMineEmpInfo(pageIndex, pageSize, where);
        }
        #endregion

        #region [ 方法: 根据查询方式得到查询条件 ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTest"></param>
        /// <param name="selectFun">1 精确</param>
        /// <returns></returns>
        public string SelectWhere(string[,] strTest, int selectFun)
        {
            string strNewSql = string.Empty;
            bool blnFirst = true;
            strNewSql = "1=1";
            for (int i = 0; i < strTest.GetUpperBound(0) + 1; i++)
            {
                if (strTest[i, 2].Trim() != string.Empty)
                {

                    if (strTest[i, 3].Trim() == "string")
                    {
                        if (selectFun == 1)
                        {
                            //精确
                            strTest[i, 2] = "'" + strTest[i, 2].Trim() + "'";
                        }
                        else
                        {
                            //模糊
                            strTest[i, 2] = "'%" + strTest[i, 2].Trim() + "%'";
                            strTest[i, 1] = "like";
                        }
                    }

                    if (strTest[i, 3].Trim() == "datetime")
                    {
                        strTest[i, 2] = "'" + strTest[i, 2].Trim() + "'";
                    }

                    //if (blnFirst)
                    //{
                    //    strNewSql = "(" + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ")";
                    //    blnFirst = false;
                    //}
                    //else
                    //{
                        strNewSql += " and (" + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + " )";
                    //}
                   // strNewSql = " (" + strNewSql + ")";

                }
            }
            return strNewSql;
        }

        #endregion

        #region [ 方法: 组织查询条件——人员 ]
        public string WhereEmp(string strName,string strCodeSenderAddress,int intDutyID,int intWorkType,int intCerTypeID,string strIDCard,string strDeptID)
        {
            strSql = " CsTypeID=0 ";
            if (strName != null && strName != "")
            {
                strSql += " And 人员姓名 like '%" + strName + "%' ";
            }
            if (strCodeSenderAddress != null && strCodeSenderAddress != "")
            {
                strSql += " And 发码器 =" + strCodeSenderAddress;
            }
            if ( intDutyID != 0)
            {
                strSql += " And DutyID=" + intDutyID.ToString();
            }
            if (intWorkType != 0)
            {
                strSql += " And WorkTypeID=" + intWorkType.ToString();
            }
            if (intCerTypeID != 0)
            {
                strSql += " And CerTypeID=" + intCerTypeID.ToString();
            }
            if (strIDCard != null && strIDCard != "")
            {
                strSql += " And IDCard like '%" + strIDCard + "%' ";
            }
            if (strDeptID != null && strDeptID != "")
            {
                strSql += " And ( DeptID=" + strDeptID + " ) ";
            }
            return strSql;
        }
        #endregion

        #region [ 方法: 组织查询条件——设备 ]

        public string WhereEqu(string strEquNO,string strEquName,string strCodeSenderAddress,string strDateBegin,string strDateEnd,int intEquType, int intFactoryID,string strDeptID)
        {
            strSql = " CsTypeID=1 ";
            if (strEquNO != null && strEquNO != "")
            {
                strSql += " And EquNO like '" + strEquNO + "'";
            }
            if (strEquName != null && strEquName != "")
            {
                strSql += " And 设备名称 like '" + strEquName + "'";
            }
            if (strCodeSenderAddress != null && strCodeSenderAddress != "")
            {
                strSql += " And 发码器=" + strCodeSenderAddress;
            }
            if (strDateBegin != null && strDateBegin != "")
            {
                strSql += " And ProductionDate >='" + strDateBegin + "' ";
            }
            if (strDateEnd != null && strDateEnd != "")
            {
                strSql += " And ProductionDate <='" + strDateEnd + "' ";
            }
            if (intEquType != 0)
            {
                strSql += " And EquType=" + intEquType.ToString();
            }
            if (intFactoryID != 0)
            {
                strSql += " And FactoryID=" + intFactoryID.ToString();
            }
            if (strDeptID != null && strDeptID != "")
            {
                strSql += " And (DeptID=" + strDeptID + ") ";
            }
            return strSql ;
        }
        #endregion

        #region [ 方法: 查询实时下井发码器信息——人员 ]

        public DataSet GetRTInMineEmp(int pageIndex, int pageSize, string where)
        {
            DataSet ds = rtdal.N_GetRTInMineEmp(pageIndex, pageSize, where);
            if (ds!=null&&ds.Tables.Count>0)
            {
                ds.Tables[0].Columns["发码器"].ColumnName = "标识卡编号";
            }
            return ds;
        }
        #endregion

        #region [ 方法: 查询实时下井发码器信息——设备 ]

        public DataSet GetRTInMineEqu(int pageIndex, int pageSize, string where)
        {
            DataSet ds = rtdal.N_GetRTInMineEqu(pageIndex, pageSize, where);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns["发码器"].ColumnName = "标识卡编号";
            }
            return ds;
        }
        #endregion

        #region [ 方法: 统计下井总人数 ]

        public string EmpInMineCounts()
        {
            return rtdal.N_EmpInMineCounts();
        }
        #endregion

        #region 实时查询

        public DataSet Query_RT_Info(int intPageIndex, int intPageSize, string strWhere)
        {
            DataSet ds = rtdal.Query_RT_Info(intPageIndex, intPageSize, strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "标识卡编号";
                ds.Tables[0].Columns[1].ColumnName = "姓名";
                ds.Tables[0].Columns[2].ColumnName = "当前所在传输分站";
                ds.Tables[0].Columns[3].ColumnName = "当前所在读卡分站";
                ds.Tables[0].Columns[4].ColumnName = "方向描述";
                ds.Tables[0].Columns[5].ColumnName = "下井时刻";
                ds.Tables[0].Columns[6].ColumnName = "持续时刻";
                ds.Tables[0].Columns[7].ColumnName = "所在区域";
                ds.Tables[0].Columns.RemoveAt(8);
                ds.Tables[0].Columns.RemoveAt(8);
            }
            return ds;
        }

        #endregion

        #region 历史查询

        public DataSet Query_His_Info(int intPageIndex, int intPageSize, string strWhere)
        {
            DataSet ds = rtdal.Query_His_Info(intPageIndex, intPageSize, strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "标识卡编号";
                ds.Tables[0].Columns[1].ColumnName = "姓名";
                ds.Tables[0].Columns[2].ColumnName = "当前所在传输分站";
                ds.Tables[0].Columns[3].ColumnName = "当前所在读卡分站";
                ds.Tables[0].Columns[4].ColumnName = "方向描述";
                ds.Tables[0].Columns[5].ColumnName = "监测时刻";
                ds.Tables[0].Columns[6].ColumnName = "所在区域";
                ds.Tables[0].Columns.RemoveAt(7);
                ds.Tables[0].Columns.RemoveAt(7);
                ds.Tables[0].Columns.RemoveAt(7);
            }
            return ds;
        }

        #endregion

        

        #region 按时间段查询

        public DataSet QueryByTime(string strWhere)
        {
            DataSet ds = rtdal.QueryByTime(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            { 
                ds.Tables[0].Columns[0].ColumnName = "标识卡号";
                ds.Tables[0].Columns[1].ColumnName = "姓名";
                ds.Tables[0].Columns[2].ColumnName = "下井时刻";
                ds.Tables[0].Columns[3].ColumnName = "上井时刻";
                ds.Tables[0].Columns[4].ColumnName = "井下工作时间";
                ds.Tables[0].Columns[5].ColumnName = "所在位置";
                ds.Tables[0].Columns[6].ColumnName = "进入时刻";
                ds.Tables[0].Columns[7].ColumnName = "进入方向";
                ds.Tables[0].Columns[8].ColumnName = "离开时刻";
                ds.Tables[0].Columns[9].ColumnName = "离开方向";
                ds.Tables[0].Columns[10].ColumnName = "停留时刻";
            }
            return ds;
        }

        #endregion

        #region 实时区域方向

        public DataSet QueryRTArea(string strWhere)
        {
            DataSet ds = rtdal.QueryRTArea(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "区域名称";
                ds.Tables[0].Columns[1].ColumnName = "区域类型";
                ds.Tables[0].Columns[2].ColumnName = "标识卡号";
                ds.Tables[0].Columns[3].ColumnName = "姓名";
                ds.Tables[0].Columns[4].ColumnName = "进入区域时间";
                ds.Tables[0].Columns[5].ColumnName = "进区域方向";
                ds.Tables[0].Columns[6].ColumnName = "停留时间";
            }
            return ds;
        }

        #endregion


    }
}
