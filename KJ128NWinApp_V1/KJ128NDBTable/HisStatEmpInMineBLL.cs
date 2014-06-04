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

        #region [ ����: ����Ա�¾�ͳ�� ]

        public DataSet StatMonthEmp(string strYear,int index,int size,string where,string isLead)
        {
            DataSet ds = dal.StatMonthEmp(strYear, index, size, where, isLead);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "����";
                ds.Tables[0].Columns[1].ColumnName = "һ��";
                ds.Tables[0].Columns[2].ColumnName = "����";
                ds.Tables[0].Columns[3].ColumnName = "����";
                ds.Tables[0].Columns[4].ColumnName = "����";
                ds.Tables[0].Columns[5].ColumnName = "����";
                ds.Tables[0].Columns[6].ColumnName = "����";
                ds.Tables[0].Columns[7].ColumnName = "����";
                ds.Tables[0].Columns[8].ColumnName = "����";
                ds.Tables[0].Columns[9].ColumnName = "����";
                ds.Tables[0].Columns[10].ColumnName = "ʮ��";
                ds.Tables[0].Columns[11].ColumnName = "ʮһ��";
                ds.Tables[0].Columns[12].ColumnName = "ʮ����";
                if (isLead == "0")
                {
                    ds.Tables[0].Columns[13].ColumnName = "�ϼƴ���";
                }
                else
                {
                    ds.Tables[0].Columns[13].ColumnName = "�ϼ��¾�ʱ��";
                }
                return ds;
            }
            return null;
        }

        #endregion

        #region������������Ա�¾�ͳ�ơ����޷�ҳ��

        public DataSet StatMonthEmp(string strYear, string where, string isLead)
        {
            DataSet ds = dal.StatMonthEmp(strYear, where, isLead);
            if (ds != null && ds.Tables.Count > 0)
            {
                //ds.Tables[0].Columns[0].ColumnName = "��ʶ��";
                //ds.Tables[0].Columns[1].ColumnName = "����";
                //ds.Tables[0].Columns[2].ColumnName = "һ��";
                //ds.Tables[0].Columns[3].ColumnName = "����";
                //ds.Tables[0].Columns[4].ColumnName = "����";
                //ds.Tables[0].Columns[5].ColumnName = "����";
                //ds.Tables[0].Columns[6].ColumnName = "����";
                //ds.Tables[0].Columns[7].ColumnName = "����";
                //ds.Tables[0].Columns[8].ColumnName = "����";
                //ds.Tables[0].Columns[9].ColumnName = "����";
                //ds.Tables[0].Columns[10].ColumnName = "����";
                //ds.Tables[0].Columns[11].ColumnName = "ʮ��";
                //ds.Tables[0].Columns[12].ColumnName = "ʮһ��";
                //ds.Tables[0].Columns[13].ColumnName = "ʮ����";
                //if (isLead == "0")
                //{
                //    ds.Tables[0].Columns[14].ColumnName = "�ϼƴ���";
                //}
                //else
                //{
                //    ds.Tables[0].Columns[14].ColumnName = "�ϼ��¾�ʱ��";
                //}
                return ds;
            }
            return null;
        }

        #endregion

        #region [ ����: ����Ȼ������Ա�¾�ͳ�� ]

        public DataSet A_StatMonthEmp(string strYear, string Uday, string Dday, int index, int size, string strWhere, string isLead)
        {
            DataSet ds = dal.A_StatMonthEmp(strYear, Uday,  Dday,  index,  size,  strWhere, isLead);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "����";
                ds.Tables[0].Columns[1].ColumnName = "һ��";
                ds.Tables[0].Columns[2].ColumnName = "����";
                ds.Tables[0].Columns[3].ColumnName = "����";
                ds.Tables[0].Columns[4].ColumnName = "����";
                ds.Tables[0].Columns[5].ColumnName = "����";
                ds.Tables[0].Columns[6].ColumnName = "����";
                ds.Tables[0].Columns[7].ColumnName = "����";
                ds.Tables[0].Columns[8].ColumnName = "����";
                ds.Tables[0].Columns[9].ColumnName = "����";
                ds.Tables[0].Columns[10].ColumnName = "ʮ��";
                ds.Tables[0].Columns[11].ColumnName = "ʮһ��";
                ds.Tables[0].Columns[12].ColumnName = "ʮ����";
                if (isLead == "0")
                {
                    ds.Tables[0].Columns[13].ColumnName = "�ϼƴ���";
                }
                else
                {
                    ds.Tables[0].Columns[13].ColumnName = "�ϼ��¾�ʱ��";
                }
                return ds;
            }
            return null;
        }

        #endregion
    }
}
