using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class Li_HisInMineRecordSetDAL
    {
        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #region 获取(部门, 工种, 证书, 职务, 职务等级) 基本信息
        public DataSet GetDeptInfo()
        {
            strSql = " Select DeptID, ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark From Dept_Info Order By DeptLevelID";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetWorkTypeInfo()
        {
            strSql = " Select WorkTypeID, WtName, CerTypeID ,Remark From WorkType_Info ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetCerType()
        {
            strSql = " Select CerTypeID, CerName, CerVestIn, IsCheckExpDate, Remark From Certificate_Info ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetBusinessInfo()
        {
            strSql = " Select DutyID, DutyName, DutyClassID, Remark From Duty_Info ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetBusLevelInfo()
        {
            strSql = " Select ID, FunID, EnumID, Title, IsBase, EnumValue, Remark From EnumTable Where FunID = 4 ";
            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region 查询 历史下井信息
        public DataSet GetHisInMineSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };

            para[0].Value = "KJ128N_HisInMine_Info_View";
            para[1].Value = "HisInOutMineID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion
    }
}
