using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class HisStatEmpInMineBLL
    {
        private HisStatEmpInMineDAL dal = new HisStatEmpInMineDAL();

        #region [ 方法: 月人员下井统计 ]

        public DataSet StatMonthEmp(string strYear,int index,int size,string where,string isLead)
        {
            DataSet ds = dal.StatMonthEmp(strYear, index, size, where, isLead);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "姓名";
                ds.Tables[0].Columns[1].ColumnName = "一月";
                ds.Tables[0].Columns[2].ColumnName = "二月";
                ds.Tables[0].Columns[3].ColumnName = "三月";
                ds.Tables[0].Columns[4].ColumnName = "四月";
                ds.Tables[0].Columns[5].ColumnName = "五月";
                ds.Tables[0].Columns[6].ColumnName = "六月";
                ds.Tables[0].Columns[7].ColumnName = "七月";
                ds.Tables[0].Columns[8].ColumnName = "八月";
                ds.Tables[0].Columns[9].ColumnName = "九月";
                ds.Tables[0].Columns[10].ColumnName = "十月";
                ds.Tables[0].Columns[11].ColumnName = "十一月";
                ds.Tables[0].Columns[12].ColumnName = "十二月";
                if (isLead == "0")
                {
                    ds.Tables[0].Columns[13].ColumnName = "合计次数";
                }
                else
                {
                    ds.Tables[0].Columns[13].ColumnName = "合计下井时间";
                }
                return ds;
            }
            return null;
        }

        #endregion

        #region【方法：月人员下井统计——无分页】

        public DataSet StatMonthEmp(string strYear, string where, string isLead)
        {
            DataSet ds = dal.StatMonthEmp(strYear, where, isLead);
            if (ds != null && ds.Tables.Count > 0)
            {
                //ds.Tables[0].Columns[0].ColumnName = "标识卡";
                //ds.Tables[0].Columns[1].ColumnName = "姓名";
                //ds.Tables[0].Columns[2].ColumnName = "一月";
                //ds.Tables[0].Columns[3].ColumnName = "二月";
                //ds.Tables[0].Columns[4].ColumnName = "三月";
                //ds.Tables[0].Columns[5].ColumnName = "四月";
                //ds.Tables[0].Columns[6].ColumnName = "五月";
                //ds.Tables[0].Columns[7].ColumnName = "六月";
                //ds.Tables[0].Columns[8].ColumnName = "七月";
                //ds.Tables[0].Columns[9].ColumnName = "八月";
                //ds.Tables[0].Columns[10].ColumnName = "九月";
                //ds.Tables[0].Columns[11].ColumnName = "十月";
                //ds.Tables[0].Columns[12].ColumnName = "十一月";
                //ds.Tables[0].Columns[13].ColumnName = "十二月";
                //if (isLead == "0")
                //{
                //    ds.Tables[0].Columns[14].ColumnName = "合计次数";
                //}
                //else
                //{
                //    ds.Tables[0].Columns[14].ColumnName = "合计下井时间";
                //}
                return ds;
            }
            return null;
        }

        #endregion

        #region [ 方法: 非自然月月人员下井统计 ]

        public DataSet A_StatMonthEmp(string strYear, string Uday, string Dday, int index, int size, string strWhere, string isLead)
        {
            DataSet ds = dal.A_StatMonthEmp(strYear, Uday,  Dday,  index,  size,  strWhere, isLead);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "姓名";
                ds.Tables[0].Columns[1].ColumnName = "一月";
                ds.Tables[0].Columns[2].ColumnName = "二月";
                ds.Tables[0].Columns[3].ColumnName = "三月";
                ds.Tables[0].Columns[4].ColumnName = "四月";
                ds.Tables[0].Columns[5].ColumnName = "五月";
                ds.Tables[0].Columns[6].ColumnName = "六月";
                ds.Tables[0].Columns[7].ColumnName = "七月";
                ds.Tables[0].Columns[8].ColumnName = "八月";
                ds.Tables[0].Columns[9].ColumnName = "九月";
                ds.Tables[0].Columns[10].ColumnName = "十月";
                ds.Tables[0].Columns[11].ColumnName = "十一月";
                ds.Tables[0].Columns[12].ColumnName = "十二月";
                if (isLead == "0")
                {
                    ds.Tables[0].Columns[13].ColumnName = "合计次数";
                }
                else
                {
                    ds.Tables[0].Columns[13].ColumnName = "合计下井时间";
                }
                return ds;
            }
            return null;
        }

        #endregion
    }
}
