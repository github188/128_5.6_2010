using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using System.Windows.Forms;
namespace KJ128NDBTable
{
    public class SpecialWorkTypeTerrialSetBLL
    {
        SpecialWorkTypeTerrialSetDAL DAL = new SpecialWorkTypeTerrialSetDAL();

        #region 添加特殊工种进出区域配置信息
        /// <summary>
        /// 添加特殊工种进出区域配置信息
        /// </summary>
        /// <param name="intEmpID">员工流水</param>
        /// <param name="intTerrialID">区域流水</param>
        /// <param name="intWorkTypeID">工种流水</param>
        /// <param name="bIsAlarm">是否报警标志</param>
        /// <param name="strRemark">备注</param>
        /// <param name="strErr">带出的错误</param>
        /// <returns></returns>
        public int Insert_SpecialWorkTypeTerrialSet(int intEmpID, int intTerrialID, int intWorkTypeID, bool bIsAlarm, string strRemark, out string strErr)
        {
            return DAL. Insert_SpecialWorkTypeTerrialSet(intEmpID, intTerrialID, intWorkTypeID, bIsAlarm, strRemark, out strErr);

        }
        #endregion

        #region 修改特殊工种进出区域配置信息
        /// <summary>
        /// 修改特殊工种进出区域配置信息
        /// </summary>
        /// <param name="intID">自动流水号</param>
        /// <param name="intEmpID">员工流水</param>
        /// <param name="intTerrialID">区域流水</param>
        /// <param name="intWorkTypeID">工种流水</param>
        /// <param name="bIsAlarm">是否报警标志</param>
        /// <param name="strRemark">备注</param>
        /// <param name="strErr">带出的错误</param>
        /// <returns></returns>
        public int Update_SpecialWorkTypeTerrialSet(int intID, int intEmpID, int intTerrialID, int intWorkTypeID, bool bIsAlarm, string strRemark,string strWhere, out string strErr)
        {

            return DAL.Update_SpecialWorkTypeTerrialSet(intID, intEmpID, intTerrialID, intWorkTypeID, bIsAlarm, strRemark, strWhere, out strErr);
        }
        #endregion

        #region 删除特殊工种进出区域配置信息
        /// <summary>
        /// 删除特殊工种进出区域配置信息
        /// </summary>
        /// <param name="intID">自动流水</param>
        /// <param name="strErr">带出的信息</param>
        /// <returns></returns>
        public int Delete_SpecialWorkTypeTerrialSet(int intID, out string strErr)
        {
            return DAL.Delete_SpecialWorkTypeTerrialSet(intID, out strErr);
        }
        #endregion

        #region 查询特殊工种进出区域配置信息
        /// <summary>
        /// 查询特殊工种进出区域配置信息
        /// </summary>
        /// <param name="intPageIndex">页索引</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strErr">带出的信息</param>
        /// <returns></returns>
        public DataSet Query_SpecialWorkTypeTerrialSet(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            return DAL.Query_SpecialWorkTypeTerrialSet(intPageIndex, intPageSize, strWhere, out strErr);
        }
        #endregion

        #region 查询实时特殊工种进出区域报警信息
        /// <summary>
        /// 查询实时特殊工种进出区域报警信息
        /// </summary>
        /// <param name="intPageIndex">页索引</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strErr">带出的错误</param>
        /// <returns></returns>
        public DataSet Query_RealTimeSpecialWorkTypeAlarm(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            return DAL.Query_RealTimeSpecialWorkTypeAlarm(intPageIndex, intPageSize, strWhere, out strErr);
        }
        #endregion

        #region 查询历史特殊工种进出区域报警信息
        /// <summary>
        /// 查询历史特殊工种进出区域报警信息
        /// </summary>
        /// <param name="intPageIndex">页索引</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strErr">带出错误</param>
        /// <returns></returns>
        public DataSet Query_HistorySpecialWorkTypeAlarm(int intPageIndex, int intPageSize, string strWhere, out string strErr)
        {
            return DAL.Query_HistorySpecialWorkTypeAlarm(intPageIndex, intPageSize, strWhere, out strErr);
        }
        #endregion

        #region 查询区域类别信息
        /// <summary>
        /// 查询区域类别信息
        /// </summary>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public void Query_TerrialType(ComboBox ddl,out string strErr)
        {
            DataSet DS = DAL.Query_TerrialType(out strErr);

            if (DS != null)
            {
                if (DS.Tables[0].Rows.Count == 0)
                {
                    DataRow dr = DS.Tables[0].NewRow();
                    dr[0] = "0";
                    dr[1] = "无";
                    DS.Tables[0].Rows.Add(dr);
                }

                ddl.DataSource = DS.Tables[0];
                ddl.ValueMember = "TerritorialTypeID";
                ddl.DisplayMember = "TypeName";
            }
        }
        #endregion

        #region 根据区域类别查询区域信息
        /// <summary>
        /// 根据区域类别查询区域信息
        /// </summary>
        /// <param name="intTerrialTypeID">区域流水</param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public void Query_TerrialInfo(ComboBox ddl, int intTerrialTypeID, int intFlag, out string strErr)
        {
            DataSet DS = DAL.Query_TerrialInfo(intTerrialTypeID, out strErr);

            if (DS != null && DS.Tables.Count > 0)
            {
                if (intFlag == 1)
                {
                    DataRow dr = DS.Tables[0].NewRow();
                    dr[0] = "0";
                    dr[1] = "所有";
                    DS.Tables[0].Rows.InsertAt(dr, 0);
                }
                if (DS.Tables[0].Rows.Count == 0)
                {
                    DataRow dr = DS.Tables[0].NewRow();
                    dr[0] = "0";
                    dr[1] = "无";
                    DS.Tables[0].Rows.Add(dr);
                }


                ddl.DataSource = DS.Tables[0];
                ddl.ValueMember = "TerritorialID";
                ddl.DisplayMember = "TerritorialName";
            }
        }
        #endregion

        #region 查询工种信息
        /// <summary>
        /// 查询工种信息
        /// </summary>
        /// <param name="strErr">带出的错误</param>
        /// <returns></returns>
        public void Querey_WorkType(ComboBox ddl, int intFlag, out string strErr)
        {
            DataSet DS = DAL.Querey_WorkType(out strErr);

            if (DS != null && DS.Tables.Count > 0)
            {
                if (intFlag == 1)
                {
                    DataRow dr = DS.Tables[0].NewRow();
                    dr[0] = "0";
                    dr[1] = "所有";
                    DS.Tables[0].Rows.InsertAt(dr, 0);
                }
                if (DS.Tables[0].Rows.Count == 0)
                {
                    DataRow dr = DS.Tables[0].NewRow();
                    dr[0] = "0";
                    dr[1] = "无";
                    DS.Tables[0].Rows.Add(dr);
                }

                ddl.DataSource = DS.Tables[0];
                ddl.ValueMember = "WorkTypeID";
                ddl.DisplayMember = "WtName";
            }


        }
        #endregion

        #region 根据工种流水号查询员工信息
        /// <summary>
        /// 根据工种流水号查询员工信息
        /// </summary>
        /// <param name="intWorkTypeID">工种流水</param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public void Query_Employee_ByWorkType(ComboBox ddl,int intWorkTypeID, out string strErr)
        {
            DataSet DS = DAL.Query_Employee_ByWorkType(intWorkTypeID, out strErr);

            if (DS != null && DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count == 0)
                {
                    DataRow dr = DS.Tables[0].NewRow();
                    dr[0] = "0";
                    dr[1] = "无";
                    DS.Tables[0].Rows.Add(dr);
                }

                ddl.DataSource = DS.Tables[0];
                ddl.ValueMember = "EmpID";
                ddl.DisplayMember = "员工姓名";
            }
        }
        #endregion

        public DataTable GetTerrialInfo()
        {
            return DAL.GetTerrialInfo();
        }

        public DataTable GetWtInfoByTerID(string terid)
        {
            return DAL.GetWtInfoByTerID(terid);
        }

        public DataTable GetWtInfo()
        {
            return DAL.GetWtInfo();
        }

        public bool InsertSWTer(string terid, string wtid)
        {
            return DAL.InsertSWTer(terid, wtid);
        }

        public void DelSWTer(string id)
        {
            DAL.DelSWTer(id);
        }

        //***********czlt-2010-9-16**start**********
        //特殊区域工种删除
        public void DelSWTer(string terriAlarmID, string workTypeID)
        {
            DAL.DelSWTer(terriAlarmID, workTypeID);
        }
        //***********czlt-2010-9-16**End**********
    }
}
