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
    public class Li_HistoryTimeOut_BLL
    {

        //���ô�BLL�Ĵ��壬�ѱ�����
        private DataSet ds;
        private string strSql = string.Empty;

        #region [ ����: ��ѯ��ʷ��ʱ��¼ ]
        /// <summary>
        /// ��ѯ��ʷ��ʱ��¼
        /// </summary>
        /// <param name="strStartTime">��ʼʱ��</param>
        /// <param name="strEndTime">����ʱ��</param>
        /// <param name="strCard">������</param>
        /// <param name="dv">��Ҫ�󶨵� DataGridView</param>
        /// <returns></returns>
        public bool SearchHisTimeOut(
            string strStartTime, 
            string strEndTime, 
            string strCard,
            DataGridViewKJ128 dv)
        {
            if (DateTime.Compare(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime)) > 0)
            {
                MessageBox.Show("�Բ���, ��ʼʱ�䲻�ܴ��ڽ���ʱ�䣡");
                return false;
            }

            strSql = " Select " +
                     " Hi.CodeSenderAddress As "+HardwareName.Value(CorpsName.CodeSender)+", " +
                     " Ei.EmpName As ����, " +
                     " Di.DeptName As ����, " +
                     " Hi.InMineTime As �¾�ʱ��, " +
                     " Hi.DelayedStartTime As ��ʱ��ʼʱ��, " +
                     " Hi.DelayedEndTime As ��ʱ����ʱ��, " +
                     " Hi.DelayedTime As ��ʱ����ʱ�� " +
                     " From His_OverTimeAlarm As Hi " +
                     " Left Join Emp_Info As Ei On Ei.EmpID = Hi.UserID " +
                     " Left Join Emp_NowCompany As En On En.EmpID = Ei.EmpID " +
                     " Left Join Dept_Info As Di On Di.DeptID = En.DeptID " +
                     " Where Hi.CsTypeID = 1 And Hi.InMineTime >= '" + strStartTime + "' And Hi.InMineTime <= '" + strEndTime + "' ";

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And Hi.CodeSenderAddress = " + strCard;
            }

            strSql += " Union " +
                     " Select " +
                     " Hi.CodeSenderAddress As " + HardwareName.Value(CorpsName.CodeSender) + ", " +
                     " Eb.EquName As ����, " +
                     " Di.DeptName As ����, " +
                     " Hi.InMineTime As �¾�ʱ��, " +
                     " Hi.DelayedStartTime As ��ʱ��ʼʱ��, " +
                     " Hi.DelayedEndTime As ��ʱ����ʱ��, " +
                     " Hi.DelayedTime As ��ʱ����ʱ�� " +
                     " From His_OverTimeAlarm As Hi " +
                     " Left Join Equ_BaseInfo As Eb On Eb.EquID = Hi.UserID " +
                     " Left Join Dept_Info As Di On Di.DeptID = Eb.DeptID " +
                     " Where Hi.CsTypeID = 2 And Hi.InMineTime >= '" + strStartTime + "' And Hi.InMineTime <= '" + strEndTime + "' ";

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And Hi.CodeSenderAddress = " + strCard;
            }

            return true;
        }
        #endregion
    }
}
