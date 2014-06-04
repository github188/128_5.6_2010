using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class NewHolidayTypeSetDAL
    {
        private RealTimeDAL dal = new RealTimeDAL();

        #region [ 方法: 获取假别信息 ]

        //HolidayType 假别管理
        public DataSet GetHolidayType(int pageIndex, int pageSize, string where)
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
            para[0].Value = "HolidayType";
            para[1].Value = "id";
            para[2].Value = "id,HolidayCode as 编号,HolidayName as 假别全称,HolidayAcronym as 假别简称,Remark as 备注";
            para[3].Value = "HolidayCode";
            if (pageIndex > 0)
            {
                pageIndex--;
            }
            para[4].Value = pageIndex;
            para[5].Value = pageSize;
            if (where.Length == 0)
            {
                where = "1=1";
            }
            para[6].Value = where;
            para[7].Value = 0;

            return this.dal.getRTDeptInfo(para);
        }

        #endregion
    }
}
