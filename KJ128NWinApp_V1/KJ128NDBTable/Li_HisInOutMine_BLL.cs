using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

using KJ128NDataBase;
using KJ128NInterfaceShow;

namespace KJ128NDBTable
{
    public class Li_HisInOutMine_BLL : Li_HisInMineRecordSet_BLL
    {
        private string strSql = string.Empty;
        private Li_HisInOutMineDAL li = new Li_HisInOutMineDAL();

        #region ��֯��ѯ����
        /// <summary>
        /// ��֯��ѯ����
        /// </summary>
        /// <param name="strStartTime">��ʼʱ��</param>
        /// <param name="strEndTime">����ʱ��</param>
        /// <param name="strName">����</param>
        /// <param name="strCard">����</param>
        /// <param name="strIdCard">���֤��</param>
        /// <param name="strWorkTypeId">����ID��</param>
        /// <param name="strCerTypeId">֤��ID��</param>
        /// <param name="strDutyId">ְ��ID��</param>
        /// <param name="strDutyClassId">ְ��ȼ�ID��</param>
        /// <returns>���ز�ѯ����</returns>
        public string SelectWhere(
            string strStartTime,
            string strEndTime,
            string strName,
            string strCard,
            string strDeptName,
            string strWorkTypeId,
            string strDutyId)
        {
            strSql = " And InTime >= '" + strStartTime + "' And InTime <= '" + strEndTime + "' "; ;

            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And Ei.EmpName like '%" + strName + "%' ";
            }

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And Hi.CodeSenderAddress = " + strCard;
            }
            if (!(strDeptName.Equals("")))
            {
                strSql += " And ( Di.DeptName = " + strDeptName + ") ";
            }

            if (!strWorkTypeId.Equals("0"))
            {
                strSql += " And Wi.WorkTypeID = " + strWorkTypeId;
            }

            if (!strDutyId.Equals("0"))
            {
                strSql += " And Dio.DutyID = " + strDutyId;
            }

            return strSql;
        }
        #endregion

        #region [ ����: ��ѯ��ʷ�¾���¼ ]
        public DataSet GetHisInOutMineSet( string where)
        {
            DataSet ds =li.GetHisInOutMineSet(where);
            if (ds!=null &&ds.Tables.Count>0)
            {
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);

            }
            return ds;
        }
        #endregion

        #region [ ����: ����豸��ѯ�� ]
        /// <summary>
        /// ��ò�ѯ��
        /// </summary>
        /// <param name="strEquID">�豸����</param>
        /// <param name="strDeptID">���ű��</param>
        /// <param name="strFactoryID">��������</param>
        /// <param name="strInStationHeadTime">�¾�ʱ��</param>
        /// <param name="strOutStationHeadTime">�Ͼ�ʱ��</param>
        /// <returns>��</returns>
        public DataSet GetConditionEqu(string strEquID, string strDeptID, string strFactoryID,string strEquType, string strInTime, string strOutTime)
        {
            return li.GetConditionEqu(strEquID, strDeptID, strFactoryID,
                strEquType, strInTime, strOutTime);
        }
        #endregion 

    }
}
