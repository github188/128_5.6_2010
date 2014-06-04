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
    public class Li_RealTimeInOutMine_BLL
    {
        //û���κδ�����ô�BLL

        private DBAcess dbacc;
        private DataSet ds;
        private string strSql = string.Empty;

        public Li_RealTimeInOutMine_BLL()
        {
            dbacc = new DBAcess();
        }

        #region ��ȡʵʱ��ʱ��Ϣ
        private DataSet GetRtInOutMine()
        {
            strSql = " Select " +
                     " CodeSenderAddress As ������, " +
                     " '��Ա' As ��������, " +
                     " Ei.EmpName As ʹ��������, " +
                     " Ri.InTime As �¾�ʱ��, " +
                     " Ri.DelayedStartTime As ��ʱ��ʼʱ��, " +
                     " DateDiff(ss, Ri.DelayedStartTime, getDate()) As ��ʱ����ʱ�� " +
                     " From Rt_InOutMine As Ri " +
                     " Left Join Emp_Info As Ei On Ei.EmpID = Ri.UserID " +
                     " Left Join CodeSender_Set As Cs On Cs.CsSetID = Ri.CsSetID " +
                     " Where Ri.CsTypeID = 1 And IsTimeOut = 1 " +
                     " Union " +
                     " Select " +
                     " CodeSenderAddress As ������, " +
                     " '�豸' As ��������, " +
                     " Eb.EquName As ʹ��������, " +
                     " Ri.InTime As �¾�ʱ��, " +
                     " Ri.DelayedStartTime As ��ʱ��ʼʱ��, " +
                     " DateDiff(ss, Ri.DelayedStartTime, getDate()) As ��ʱ����ʱ�� " +
                     " From Rt_InOutMine As Ri " +
                     " Left Join Equ_BaseInfo As Eb On Eb.EquID = Ri.UserID " +
                     " Left Join CodeSender_Set As Cs On Cs.CsSetID = Ri.CsSetID " +
                     " Where Ri.CsTypeID = 2 And IsTimeOut = 1 ";

            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region ��ѯʵʱ��ʱ��Ϣ
        /// <summary>
        /// ��ѯʵʱ��ʱ��Ϣ
        /// </summary>
        /// <param name="dv">Ҫ��ʾ��DataGridView</param>
        /// <returns></returns>
        public bool SearchRtInOutMine(DataGridViewKJ128 dv)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = GetRtInOutMine();
                dv.DataSource = ds.Tables[0].DefaultView;
            }

            return true;
        }
        #endregion
    }
}
