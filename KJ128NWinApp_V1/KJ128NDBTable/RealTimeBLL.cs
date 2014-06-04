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

        #region [ ���� ]

        private RealTimeDAL rtdal = new RealTimeDAL();

        string strSql = string.Empty;

        #endregion

        /*
         * ����
         */ 

        #region [ ����: ���ű���Ϣ ]

        // ��䲿����
        public DataTable getDeptInfo()
        {
            return rtdal.getDeptInfo();
        }

        #endregion

        #region [ ����: ʵʱ������Ա��Ϣ ]

        //View_GetRTEmptyCardInfo ʵʱ������Ա��Ϣ
        public DataSet getRTEmptyCardInfo(int pageIndex, int pageSize)
        {
            return rtdal.N_getRTEmptyCardInfo(pageIndex, pageSize);
        }

        #endregion

        #region [ ����: ʵʱ������Ա��Ϣ ]

        //View_GetRTDeptEmpInfo ʵʱ������Ա��Ϣ
        public DataSet getRTDeptInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_getRTDeptInfo(pageIndex, pageSize, where);
        }

        #endregion

        #region [ ����:  ʵʱ�����豸��Ϣ ]

        //View_GetRTDeptEmpInfo ʵʱ�����豸��Ϣ
        public DataSet getRTDeptEquInfo(int pageIndex, int pageSize, string where)
        {
            //return rtdal.N_getRTDeptInfo(pageIndex, pageSize, where);
            return rtdal.N_getRTDeptEquInfo(pageIndex, pageSize, where);
        }

        #endregion

        #region [ ����: ʵʱ�¾� ]

        #region ʵʱ�¾���Ա��Ϣ

        public DataSet getRTInWellEmpInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_getRTInWellEmpInfo(pageIndex, pageSize, where);
        }

        #endregion

        #region ʵʱ�¾��豸
        //View_GetInWellEquInfo ʵʱ�����豸��Ϣ
        public DataSet getRTInWellEquInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_getRTInWellEquInfo(pageIndex, pageSize, where);
        }

        #endregion

        #endregion

        #region [ ����: ���ź͸ò���ʵʱ�¾����� ]

        public DataSet GetDeptEmpInWellInfo()
        {
            return rtdal.GetDeptEmpInWellInfo();
        }
        //��
        public DataSet GetEmpInWellInfo()
        {
            return rtdal.GetEmpInWellInfo();
        }
        #endregion

        #region [ ����: ���ź͸ò���ʵʱ�¾����� ]

        //View_GetRTDeptEmpInfo ʵʱ������Ա��Ϣ
        public DataSet GetRTDeptAllEmpInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_GetRTDeptAllEmpInfo(pageIndex, pageSize, where);
        }

        //��
        public DataSet GetRTInMineEmpInfo(int pageIndex, int pageSize, string where)
        {
            return rtdal.N_GetRTInMineEmpInfo(pageIndex, pageSize, where);
        }
        #endregion

        #region [ ����: ���ݲ�ѯ��ʽ�õ���ѯ���� ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTest"></param>
        /// <param name="selectFun">1 ��ȷ</param>
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
                            //��ȷ
                            strTest[i, 2] = "'" + strTest[i, 2].Trim() + "'";
                        }
                        else
                        {
                            //ģ��
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

        #region [ ����: ��֯��ѯ����������Ա ]
        public string WhereEmp(string strName,string strCodeSenderAddress,int intDutyID,int intWorkType,int intCerTypeID,string strIDCard,string strDeptID)
        {
            strSql = " CsTypeID=0 ";
            if (strName != null && strName != "")
            {
                strSql += " And ��Ա���� like '%" + strName + "%' ";
            }
            if (strCodeSenderAddress != null && strCodeSenderAddress != "")
            {
                strSql += " And ������ =" + strCodeSenderAddress;
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

        #region [ ����: ��֯��ѯ���������豸 ]

        public string WhereEqu(string strEquNO,string strEquName,string strCodeSenderAddress,string strDateBegin,string strDateEnd,int intEquType, int intFactoryID,string strDeptID)
        {
            strSql = " CsTypeID=1 ";
            if (strEquNO != null && strEquNO != "")
            {
                strSql += " And EquNO like '" + strEquNO + "'";
            }
            if (strEquName != null && strEquName != "")
            {
                strSql += " And �豸���� like '" + strEquName + "'";
            }
            if (strCodeSenderAddress != null && strCodeSenderAddress != "")
            {
                strSql += " And ������=" + strCodeSenderAddress;
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

        #region [ ����: ��ѯʵʱ�¾���������Ϣ������Ա ]

        public DataSet GetRTInMineEmp(int pageIndex, int pageSize, string where)
        {
            DataSet ds = rtdal.N_GetRTInMineEmp(pageIndex, pageSize, where);
            if (ds!=null&&ds.Tables.Count>0)
            {
                ds.Tables[0].Columns["������"].ColumnName = "��ʶ�����";
            }
            return ds;
        }
        #endregion

        #region [ ����: ��ѯʵʱ�¾���������Ϣ�����豸 ]

        public DataSet GetRTInMineEqu(int pageIndex, int pageSize, string where)
        {
            DataSet ds = rtdal.N_GetRTInMineEqu(pageIndex, pageSize, where);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns["������"].ColumnName = "��ʶ�����";
            }
            return ds;
        }
        #endregion

        #region [ ����: ͳ���¾������� ]

        public string EmpInMineCounts()
        {
            return rtdal.N_EmpInMineCounts();
        }
        #endregion

        #region ʵʱ��ѯ

        public DataSet Query_RT_Info(int intPageIndex, int intPageSize, string strWhere)
        {
            DataSet ds = rtdal.Query_RT_Info(intPageIndex, intPageSize, strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "��ʶ�����";
                ds.Tables[0].Columns[1].ColumnName = "����";
                ds.Tables[0].Columns[2].ColumnName = "��ǰ���ڴ����վ";
                ds.Tables[0].Columns[3].ColumnName = "��ǰ���ڶ�����վ";
                ds.Tables[0].Columns[4].ColumnName = "��������";
                ds.Tables[0].Columns[5].ColumnName = "�¾�ʱ��";
                ds.Tables[0].Columns[6].ColumnName = "����ʱ��";
                ds.Tables[0].Columns[7].ColumnName = "��������";
                ds.Tables[0].Columns.RemoveAt(8);
                ds.Tables[0].Columns.RemoveAt(8);
            }
            return ds;
        }

        #endregion

        #region ��ʷ��ѯ

        public DataSet Query_His_Info(int intPageIndex, int intPageSize, string strWhere)
        {
            DataSet ds = rtdal.Query_His_Info(intPageIndex, intPageSize, strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "��ʶ�����";
                ds.Tables[0].Columns[1].ColumnName = "����";
                ds.Tables[0].Columns[2].ColumnName = "��ǰ���ڴ����վ";
                ds.Tables[0].Columns[3].ColumnName = "��ǰ���ڶ�����վ";
                ds.Tables[0].Columns[4].ColumnName = "��������";
                ds.Tables[0].Columns[5].ColumnName = "���ʱ��";
                ds.Tables[0].Columns[6].ColumnName = "��������";
                ds.Tables[0].Columns.RemoveAt(7);
                ds.Tables[0].Columns.RemoveAt(7);
                ds.Tables[0].Columns.RemoveAt(7);
            }
            return ds;
        }

        #endregion

        

        #region ��ʱ��β�ѯ

        public DataSet QueryByTime(string strWhere)
        {
            DataSet ds = rtdal.QueryByTime(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            { 
                ds.Tables[0].Columns[0].ColumnName = "��ʶ����";
                ds.Tables[0].Columns[1].ColumnName = "����";
                ds.Tables[0].Columns[2].ColumnName = "�¾�ʱ��";
                ds.Tables[0].Columns[3].ColumnName = "�Ͼ�ʱ��";
                ds.Tables[0].Columns[4].ColumnName = "���¹���ʱ��";
                ds.Tables[0].Columns[5].ColumnName = "����λ��";
                ds.Tables[0].Columns[6].ColumnName = "����ʱ��";
                ds.Tables[0].Columns[7].ColumnName = "���뷽��";
                ds.Tables[0].Columns[8].ColumnName = "�뿪ʱ��";
                ds.Tables[0].Columns[9].ColumnName = "�뿪����";
                ds.Tables[0].Columns[10].ColumnName = "ͣ��ʱ��";
            }
            return ds;
        }

        #endregion

        #region ʵʱ������

        public DataSet QueryRTArea(string strWhere)
        {
            DataSet ds = rtdal.QueryRTArea(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "��������";
                ds.Tables[0].Columns[1].ColumnName = "��������";
                ds.Tables[0].Columns[2].ColumnName = "��ʶ����";
                ds.Tables[0].Columns[3].ColumnName = "����";
                ds.Tables[0].Columns[4].ColumnName = "��������ʱ��";
                ds.Tables[0].Columns[5].ColumnName = "��������";
                ds.Tables[0].Columns[6].ColumnName = "ͣ��ʱ��";
            }
            return ds;
        }

        #endregion


    }
}
