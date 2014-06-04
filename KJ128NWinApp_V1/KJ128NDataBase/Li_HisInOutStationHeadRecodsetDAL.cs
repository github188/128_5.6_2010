using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class Li_HisInOutStationHeadRecodsetDAL
    {

        #region [ ���� ]

        private DBAcess dbacc = new DBAcess();

        #endregion


        #region [ ����: ��ȡ(��վ,������)������Ϣ ]

        public DataSet GetStationInfo()
        {
            string strSql = " Select StationAddress, StationPlace From Station_Info ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet GetStationHeadInfo(string strStationAddress)
        {
            string strSql = " Select StationHeadAddress, StationHeadPlace From Station_Head_Info Where StationAddress = " + strStationAddress;
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ ����: ��ѯ��ʷ������������Ϣ ]

        public DataSet GetInOutStationHeadSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "KJ128N_HisInOutStationHead_Info_View";
            para[1].Value = "HisStationHeadID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dbacc.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }

        #endregion

        #region [ ����: ����豸��ѯ�� ]

        /// <summary>
        /// ��ò�ѯ��
        /// </summary>
        /// <param name="strEquID">�豸����</param>
        /// <param name="strDeptID">���ű��</param>
        /// <param name="strFactoryID">��������</param>
        /// <param name="strInStationHeadTime">�����վʱ��</param>
        /// <param name="strOutStationHeadTime">�뿪��վʱ��</param>
        /// <returns>��</returns>
        public DataSet GetConditionEqu(string strEquID, string strDeptID, string strFactoryID, string strEquType, string strInStationHeadTime, string strOutStationHeadTime)
        {
            // ��ò�ѯ����
            string[,] strArr = new string[6, 4] 
            {
                {"Eb.EquName","=",strEquID,"string"},
                {"Di.DeptName","=",strDeptID,"string"},
                {"Fi.FactoryID","=",strFactoryID,"int"},
                {"Ei.EnumID","=",strEquType,"int"},
                {"Hi.InStationHeadTime",">=",strInStationHeadTime,"datetime"},
                {"Hi.OutStationHeadTime","<=",strOutStationHeadTime,"datetime"}
            };

            // ������ת��Ϊ���
            string strSQL = string.Empty;

            for (int i = 0; i < (strArr.GetUpperBound(0) + 1); i++)
            {
                if (strArr[i, 2].Trim() != "0")
                {
                    //���Ǿ�ȷ��ѯ
                    if (strArr[i, 3] == "datetime")
                    {
                        strArr[i, 2] = "'" + strArr[i, 2].Trim() + "'";
                    }

                    if (strArr[i, 3] == "string")
                    {
                        strArr[i, 1] = "  like  ";
                        strArr[i, 2] = "'%" + strArr[i, 2].Trim() + "%'";
                    }

                    strSQL += " and " + strArr[i, 0] + strArr[i, 1] + strArr[i, 2] + " ";
                }
            }

            string strProcName = "KJ128N_HisStationHead_Query_Equ";
            SqlParameter[] sqlPar ={ 
                new SqlParameter("strWhere",DbType.String)
            };

            sqlPar[0].Value = strSQL;
            return dbacc.ExecuteSqlDataSet(strProcName, sqlPar);
        }
        #endregion 
    }
}
