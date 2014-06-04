using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class RealTimeDAL
    {

        #region [ ���� ]

        DBAcess dba = new DBAcess();
        private DbHelperSQL db = new DbHelperSQL();

        string strSql = string.Empty;

        #endregion


        #region [ ����: ���ű���Ϣ ]
        // ��䲿����
        public DataTable getDeptInfo()
        {
            return dba.GetDataSet("select * from Dept_Info Order By DeptLevelID").Tables[0];
        }

        #endregion

        #region [ ����: ʵʱ������Ϣ ]

        //int pageIndex,int pageSize,string where//View_GetRTDeptInfo
        public DataSet getRTDeptInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("GetPagingRecord", para);
        }

        #endregion

        #region [ ����: ���ź͸ò���ʵʱ�¾����� ]

        public DataSet GetDeptEmpInWellInfo()
        {
            return dba.GetDataSet("select * from View_GetDeptEmpInWellInfo");
        }
        //��
        public DataSet GetEmpInWellInfo()
        {
            return dba.GetDataSet("select * from View_GetDeptEmpInWellInfo_InWell");
        }

        #endregion

        #region [ ����: ʵʱ������Ա��Ϣ ]

        //View_GetRTEmptyCardInfo ʵʱ������Ա��Ϣ
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
            para[2].Value = "CodeSenderAddress as ���������,StationAddress as ��վ���,StationHeadAddress as ���������,InStationHeadAntenna as ���ߺ�,StationHeadDetectTime as ���ʱ��,Directional as ������,NowLocation as ���ڵص�";
            para[3].Value = "RTCodeSenderID";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = "1=1";
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #region [ ����: ʵʱ������Ա��Ϣ ]

        //View_GetRTDeptEmpInfo ʵʱ������Ա��Ϣ
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
            para[2].Value = "CodeSenderAddress as ���������,EmpName as ��Ա����,DeptName as ����,WtName as ����,DutyName as ְ��,StationHeadDetectTime as ���ʱ��,Directional as ������,NowLocation as ���ڵص�";
            para[3].Value = "RTCodeSenderID";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #region [ ����: ʵʱ�����豸��Ϣ ]

        //View_GetRTDeptEmpInfo ʵʱ�����豸��Ϣ
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
            para[2].Value = "CodeSenderAddress as ���������,EquName as �豸����,DeptName as ����,StationHeadDetectTime as ���ʱ��,Directional as ������,NowLocation as ���ڵص�";
            para[3].Value = "RTCodeSenderID,DeptName";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #region [ ����: ʵʱ�¾� ]

        #region [ ����: ʵʱ�¾���Ա��Ϣ]

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
            para[2].Value = "CodeSenderAddress as ���������,EmpName as ��Ա����,DeptName as ����,WtName as ����,DutyName as ְ��,InTime as �¾�ʱ��,sumTime as ����ʱ��";
            para[3].Value = "CodeSenderAddress";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #region [ ����: ʵʱ�¾��豸 ]

        //View_GetInWellEquInfo ʵʱ�����豸��Ϣ
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
            para[2].Value = "CodeSenderAddress as ���������,EquName as �豸����,DeptName as ����,InTime as �¾�ʱ��,sumTime as ����ʱ��";
            para[3].Value = "CodeSenderAddress";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        #endregion

        #endregion

        #region [ ����: ���ź͸ò���ʵʱ�¾����� ]

        //View_GetRTDeptEmpInfo ʵʱ������Ա��Ϣ
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
            para[2].Value = "CodeSenderAddress as ���������,EmpName as ��Ա����,StationHeadDetectTime as ���ʱ��,NowLocation as ���ڵص�,StationAddress,StationHeadAddress,InStationHeadAntenna";
            para[3].Value = "RTCodeSenderID";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }

        //��
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
            para[2].Value = "CodeSenderAddress as ���������,EmpName as ��Ա����,StationHeadDetectTime as ���ʱ��,NowLocation as ���ڵص�,StationAddress,StationHeadAddress,InStationHeadAntenna";
            para[3].Value = "RTCodeSenderID";
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            para[6].Value = where;
            para[7].Value = 0;

            return this.getRTDeptInfo(para);
        }
        #endregion

        #region [ ����: ��ѯʵʱ�¾���������Ϣ������Ա ]

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
            para[1].Value = "������";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region [ ����: ��ѯʵʱ�¾���������Ϣ�����豸 ]

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
            para[1].Value = "������";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region [ ����: ͳ���¾������� ]

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

        #region [ ����: ʵʱ��ѯ 7-8 �� ]

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

        #region [ ����: ��ʷ��ѯ 7-8 �� ]

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

        
        #region [ ����: ��ʱ��β�ѯ 7-12 �� ]

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

        #region [ ����: ��ʱ��β�ѯ 7-12 �� ]

        public DataSet QueryRTArea(string strWhere)
        {
            string sql = "select AreaName,AreaTypeName,CodeSenderAddress,EmpName,InTime,InDirection,dbo.FunConvertTime(datediff(second,InTime,getdate())) as a from RT_AreaDirection";
            sql += strWhere == "" ? " where EmpName is not null" : (" where " + strWhere+" and EmpName is not null");
            return db.Query(sql);
        }

        #endregion

    }
}
