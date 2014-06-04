using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class AssociateDAL
    {
        #region 【自定义参数】
        /// <summary>
        /// 数据访问层对象
        /// </summary>
        private DBAcess dba = new DBAcess();
        #endregion

        #region 【方法：获取分站树信息】
        /// <summary>
        /// 获取分站树信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetStationTree()
        {
            string strSQL = " Select * From A_StaHeadTree_HisStaHead";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region 【方法：添加异地交接班信息】
        /// <summary>
        /// 添加异地交接班信息
        /// </summary>
        /// <param name="stationAddress">传输分站号</param>
        /// <param name="stationHeadAddress">读卡分站号</param>
        /// <param name="stationHeadPlace">读卡分站安装位置</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="empid1">人员编号1</param>
        /// <param name="empid2">人员编号2</param>
        /// <param name="empName1">人员姓名1</param>
        /// <param name="empName2">人员姓名2</param>
        /// <returns>执行的行数</returns>
        public int AddAssociate(int stationAddress, int stationHeadAddress, string stationHeadPlace, DateTime beginTime, DateTime endTime, int empid1, int empid2, string empName1, string empName2)
        {
            SqlParameter[] para = { new SqlParameter("@stationAddress",SqlDbType.Int),
                                    new SqlParameter("@stationHeadAddress",SqlDbType.Int),
                                    new SqlParameter("@stationHeadPlace",SqlDbType.VarChar,20),
                                    new SqlParameter("@beginTime",SqlDbType.DateTime),
                                    new SqlParameter("@endTime",SqlDbType.DateTime),
                                    new SqlParameter("@empid1",SqlDbType.Int),
                                    new SqlParameter("@empid2",SqlDbType.Int),
                                    new SqlParameter("@empName1",SqlDbType.VarChar,20),
                                    new SqlParameter("@empName2",SqlDbType.VarChar,20),
                                    new SqlParameter("@ID",SqlDbType.Int)
            };
            para[0].Value = stationAddress;
            para[1].Value = stationHeadAddress;
            para[2].Value = stationHeadPlace;
            para[3].Value = beginTime;
            para[4].Value = endTime;
            para[5].Value = empid1;
            para[6].Value = empid2;
            para[7].Value = empName1;
            para[8].Value = empName2;
            para[9].Value = (stationAddress.ToString() + "," + stationHeadAddress.ToString() + "," + beginTime.ToString() + "," + endTime.ToString() + "," + empid1.ToString() + "," + empid2.ToString()).GetHashCode();

            return dba.ExecuteSql("Associate_Insert", para);
        }
        #endregion

        #region 【方法：删除异地交接班信息】
        /// <summary>
        /// 删除异地交接班信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>执行的行数</returns>
        public int DeleteAssociate(int id)
        {
            SqlParameter[] para = { new SqlParameter("@id", SqlDbType.Int) };
            para[0].Value = id;
            return dba.ExecuteSql("Associate_Delete", para);
        }
        #endregion

        #region 【方法：显示交接班配置信息】
        /// <summary>
        /// 显示交接班配置信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页显示个数</param>
        /// <param name="strWhere">查询添加</param>
        /// <returns>返回记录集</returns>
        public DataSet getAssociateConfig(int pageIndex, int pageSize, string strWhere)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "AssociateConfigView";
            para[1].Value = "id";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = strWhere;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region 【方法：显示交接班实时异常信息】
        /// <summary>
        /// 获取实时交接班异常信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetRealTimeAssociateAlertInfo(int pageIndex, int pageSize, string strWhere)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "AssociateAlertView";
            para[1].Value = "id";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = strWhere;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region 【方法：显示交接班实时异常统计信息】
        /// <summary>
        /// 获取实时交接班异常统计信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetRealTimeAssociateAlertCount()
        {
            string strSql = "select count(1) from AssociateAlertView";

            return dba.GetDataSet(strSql);
        }
        #endregion

        #region 【方法：获取交接班历史信息】
        /// <summary>
        /// 获取实时交接班异常信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAssociateInfo(int pageIndex, int pageSize, string strWhere)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "AssociateView";
            para[1].Value = "id";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = strWhere;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region 【方法：获取传输分站信息】
        public DataSet GetStationInfo()
        {
            string strSql = "select stationID,convert(varchar(20),stationAddress) as stationAddress from Station_Info";
            return dba.GetDataSet(strSql);
        }
        #endregion

        #region 【方法：获取读卡分站信息】
        /// <summary>
        /// 获取读卡分站信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetStationHeadInfo(string strWhere)
        {
            string strSql = "select stationHeadPlace,convert(varchar(20),stationHeadAddress) as stationHeadAddress from Station_Head_Info where " + strWhere;
            return dba.GetDataSet(strSql);
        }
        #endregion

        #region 【方法：获取工种信息】
        /// <summary>
        /// 获取工种信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetWorkTypeInfo()
        {
            string strSql = "select workTypeID,WtName from dbo.WorkType_Info";
            return dba.GetDataSet(strSql);
        }
        #endregion

        #region 【方法：获取员工信息】
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetEmpInfo(string strWhere)
        {
            string strSql = "select empid,empName from emp_info where " + strWhere;
            return dba.GetDataSet(strSql);
        }
        #endregion
    }
}
