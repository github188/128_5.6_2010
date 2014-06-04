using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_RealTimeDAL
    {

        #region [ 声明 ]

        DBAcess dba = new DBAcess();
        private DbHelperSQL db = new DbHelperSQL();

        string strSql = string.Empty;

        #endregion


        #region [ 方法: 部门表信息 ]
        // 填充部门树
        public DataTable getDeptInfo()
        {
            return dba.GetDataSet("select * from Dept_Info Order By DeptLevelID").Tables[0];
        }

        #endregion

        #region [ 方法: 实时部门信息 ]

        //int pageIndex,int pageSize,string where//View_GetRTDeptInfo
        public DataSet getRTDeptInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("GetPagingRecord", para);
        }

        #endregion

        #region [ 方法: 部门和该部门实时下井人数 ]

        public DataSet GetDeptEmpInWellInfo()
        {
            return dba.GetDataSet("select * from View_GetDeptEmpInWellInfo");
        }
        //赵
        public DataSet GetEmpInWellInfo()
        {
            return dba.GetDataSet("select * from View_GetDeptEmpInWellInfo_InWell");
        }

        #endregion

        #region [ 方法: 实时部门人员信息 ]

        //View_GetRTEmptyCardInfo 实时部门人员信息
        public DataSet N_getRTEmptyCardInfo(int pageIndex, int pageSize)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetRTEmptyCardInfo";
            para[1].Value = "RTCodeSenderID";
            para[2].Value = "CodeSenderAddress as 发码器编号,StationAddress as 分站编号,StationHeadAddress as 接收器编号,InStationHeadAntenna as 天线号,StationHeadDetectTime as 监测时间,Directional as 方向性,NowLocation as 所在地点";
            para[3].Value = "RTCodeSenderID";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = "1=1";
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #region [ 方法: 实时部门人员信息 ]

        //View_GetRTDeptEmpInfo 实时部门人员信息
        public DataSet N_getRTDeptInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetRTDeptEmpInfo";
            para[1].Value = "RTCodeSenderID";
            para[2].Value = "CodeSenderAddress as 发码器编号,EmpName as 人员姓名,DeptName as 部门,WtName as 工种,DutyName as 职务,StationHeadDetectTime as 监测时间,Directional as 方向性,NowLocation as 所在地点";
            para[3].Value = "RTCodeSenderID";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #region [ 方法: 实时部门设备信息 ]

        //View_GetRTDeptEmpInfo 实时部门设备信息
        public DataSet N_getRTDeptEquInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetRTDeptEquInfo";
            para[1].Value = "RTCodeSenderID";
            para[2].Value = "CodeSenderAddress as 发码器编号,EquName as 设备名称,DeptName as 部门,StationHeadDetectTime as 监测时间,Directional as 方向性,NowLocation as 所在地点";
            para[3].Value = "RTCodeSenderID,DeptName";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #region [ 方法: 实时下井 ]

        #region [ 方法: 实时下井人员信息]

        public DataSet N_getRTInWellEmpInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetInWellEmpInfo";
            para[1].Value = "RtInOutMineID";
            para[2].Value = "CodeSenderAddress as 发码器编号,EmpName as 人员姓名,DeptName as 部门,WtName as 工种,DutyName as 职务,InTime as 下井时间,sumTime as 持续时间";
            para[3].Value = "CodeSenderAddress";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #region [ 方法: 实时下井设备 ]

        //View_GetInWellEquInfo 实时部门设备信息
        public DataSet N_getRTInWellEquInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetInWellEquInfo";
            para[1].Value = "RtInOutMineID";
            para[2].Value = "CodeSenderAddress as 发码器编号,EquName as 设备名称,DeptName as 部门,InTime as 下井时间,sumTime as 持续时间";
            para[3].Value = "CodeSenderAddress";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #endregion

        #region [ 方法: 部门和该部门实时下井人数 ]

        //View_GetRTDeptEmpInfo 实时部门人员信息
        public DataSet N_GetRTDeptAllEmpInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetRTDeptEmpInfo";
            para[1].Value = "RTCodeSenderID";
            para[2].Value = "CodeSenderAddress as 发码器编号,EmpName as 人员姓名,StationHeadDetectTime as 监测时间,NowLocation as 所在地点,StationAddress,StationHeadAddress,InStationHeadAntenna";
            para[3].Value = "RTCodeSenderID";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        //赵
        public DataSet N_GetRTInMineEmpInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@keyField",SqlDbType.VarChar,255),
                                    new SqlParameter("@fieldList",SqlDbType.VarChar,2000),
                                    new SqlParameter("@orderField",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000),
                                    new SqlParameter("@orderType",SqlDbType.Bit)
            };
            para[0].Value = "View_GetRTDeptEmpInfo_InWell";
            para[1].Value = "RTCodeSenderID";
            para[2].Value = "CodeSenderAddress as 发码器编号,EmpName as 人员姓名,StationHeadDetectTime as 监测时间,NowLocation as 所在地点,StationAddress,StationHeadAddress,InStationHeadAntenna";
            para[3].Value = "RTCodeSenderID";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }
        #endregion

        #region [ 方法: 查询实时下井发码器信息——人员 ]

        public DataSet N_GetRTInMineEmp(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "View_GetRTDeptEmpInfo_InMine";
            para[1].Value = "发码器";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region [ 方法: 查询实时下井发码器信息——设备 ]

        public DataSet N_GetRTInMineEqu(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "View_GetRTDeptEquInfo_InMine";
            para[1].Value = "发码器";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region [ 方法: 统计下井总人数 ]

        public string N_EmpInMineCounts()
        {
            //strSql = "Select Count( Distinct CodeSenderAddress) as Counts From RT_InOutMine ";
            strSql = " select Count(Distinct Ri.CodeSenderAddress ) as Counts from RT_InOutMine as Ri left join CodeSender_Set as Css on Ri.CodeSenderAddress=Css.CodeSenderAddress where CsTypeID=0 ";
            DataSet ds;
            using (ds = new DataSet())
            {
                ds = dba.GetDataSet(strSql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0]["Counts"].ToString();
                    }
                }
                return "0";
            }
        }
        #endregion

        #region [ 方法: 实时查询 7-8 丁 ]

        public DataSet Query_RT_Info(int intPageIndex, int intPageSize, string strWhere)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Int),
                                    new SqlParameter("@OrderType",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000)
            };
            para[0].Value = "View_RT_Info";
            para[1].Value = "CodeSenderAddress";
            para[2].Value = intPageSize;
            para[3].Value = intPageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = strWhere;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }

        #endregion

        #region [ 方法: 历史查询 7-8 丁 ]

        public DataSet Query_His_Info(int intPageIndex, int intPageSize, string strWhere)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Int),
                                    new SqlParameter("@OrderType",SqlDbType.Int),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,8000)
            };
            para[0].Value = "View_His_Info";
            para[1].Value = "id";
            para[2].Value = intPageSize;
            para[3].Value = intPageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = strWhere;
            string sql = "select count(DISTINCT CodeSenderAddress) from View_His_Info";
            sql += strWhere == "" ? "" : " where " + strWhere;
            string s = dba.ExecuteScalarSql(sql);
            DataTable dt = new DataTable("TabCount");
            dt.Columns.Add("EmpCount");
            DataRow dr = dt.NewRow();
            dr["EmpCount"] = s;
            dt.Rows.Add(dr);
            DataSet ds = dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
            ds.Tables.Add(dt);
            return ds;
        }

        #endregion


        #region [ 方法: 按时间段查询 7-12 丁 ]

        public DataSet QueryByTime(string strWhere)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,2000)
            };

            parameter[0].Value = strWhere;
            string strErr = string.Empty;
            return db.RunProcedureByDataSet("SSZY_QueryByTime_DJC", "dst", parameter, out strErr);
        }

        #endregion

        #region [ 方法: 按时间段查询 7-12 丁 ]

        public DataSet QueryRTArea(string strWhere)
        {
            string sql = "select AreaName,AreaTypeName,CodeSenderAddress,EmpName,InTime,InDirection,dbo.FunConvertTime(datediff(second,InTime,getdate())) as a from RT_AreaDirection";
            sql += strWhere == "" ? " where EmpName is not null" : (" where " + strWhere + " and EmpName is not null");
            return db.Query(sql);
        }

        #endregion

    }
}
