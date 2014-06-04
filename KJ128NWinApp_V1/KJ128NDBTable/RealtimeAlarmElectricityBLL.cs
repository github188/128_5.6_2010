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
    public class RealtimeAlarmElectricityBLL
    {

        #region [ ���� ]

        private DataSet ds;

        private RealtimeAlarmElectricityDAL rtaedal = new RealtimeAlarmElectricityDAL();

        #endregion


        #region [ ����: ��ȡ�͵�����Ϣ ]

        /// <summary>
        /// ��ȡ�͵�����Ϣ
        /// </summary>
        /// <param name="CodeSenderStateID">������״̬,4:�͵���</param>
        /// <param name="dv"></param>
        /// <param name="strCounts"></param>
        /// <returns></returns>
        public bool N_SelectAlarmElectricity(int CodeSenderStateID,int intCsTypeID, DataGridViewKJ128 dv,out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();

                ds = rtaedal.N_GetAlarmElectricity(CodeSenderStateID,intCsTypeID);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strCounts = ds.Tables[0].Rows.Count.ToString();
                    }
                    else
                    {
                        strCounts = "0";
                    }

                    ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);

                    dv.DataSource = ds.Tables[0];
                }
                else
                {
                    strCounts = "0";
                }                
            }
            return true;
        }

        #endregion

    }
}
