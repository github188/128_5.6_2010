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
    public class Li_RealTimeInOutStationHeadInfo_BLL : Li_HistoryInOutAntenna_BLL
    {

        #region [ ���� ]

        private DataSet ds;

        private Li_RealTimeInOutStationHeadInfo_DAL lrtdal = new Li_RealTimeInOutStationHeadInfo_DAL();

        #endregion


        /*
         * �ⲿ����
         */ 

        #region [ ����: ���ز���,������Ϣ ]

        public bool N_LoadInfo(TreeView tvDep, ComboBox cmbWorkType, int intUserType)
        {
            //���ز���
            using (ds = new DataSet())
            {
                ds = lrtdal.N_GetDeptInfo();
                if (ds != null && ds.Tables.Count > 0)
                {
                    TreeNode tnDept = new TreeNode();
                    tnDept.Text = "���в���";
                    tnDept.Name = "0";
                    tvDep.Nodes.Add(tnDept);
                    this.N_LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count);
                }
            }

            //���ع���
            using (ds = new DataSet())
            {
                ds = lrtdal.N_GetWorkTypeInfo();
                if (ds != null && ds.Tables.Count > 0)
                {
                    this.N_LoadWorkType(cmbWorkType);
                }
            }

            return true;
        }

        #endregion

        #region [ ����: ��ѯʵʱ������������Ϣ_��Ա ]

        /// <summary>
        /// ��ѯʵʱ������������Ϣ_��Ա 
        /// </summary>
        /// <param name="strStartTime">��ʼʱ��</param>
        /// <param name="strEndTime">����ʱ��</param>
        /// <param name="strStationAddress">��վ���</param>
        /// <param name="strStationHeadAddress">��������</param>
        /// <param name="strName">����</param>
        /// <param name="strCard">������</param>
        /// <param name="strWorkTypeId">����</param>
        /// <param name="strDeptName">����</param>
        /// <param name="intUserType">�û����� 1�� 2�豸</param>
        /// <param name="dv">Ҫ��ʾ��DataGridView</param>
        /// <returns></returns>
        public bool N_SearchRTInOutStationHeadInfo(
            string strStartTime, 
            string strEndTime, 
            string strStationAddress, 
            string strStationHeadAddress,
            string strName,
            string strCard,
            string strWorkTypeId,
            string strDeptName,
            int intUserType,
            DataGridViewKJ128 dv,
            out string strCounts)
        {
            if (DateTime.Compare(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime)) > 0)
            {
                MessageBox.Show("�Բ���, ��ʼʱ�䲻�ܴ��ڽ���ʱ�䣡");
                strCounts="-1";
                return false;
            }

            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                //ds = dbacc.GetDataSet(strSql);
                ds = lrtdal.N_GetRTInOutStationHeadInfo(strStartTime, strEndTime, strStationAddress, strStationHeadAddress, strName, strCard, strWorkTypeId, strDeptName, intUserType);

                dv.DataSource = ds.Tables[0].DefaultView;
                if (ds != null && ds.Tables.Count > 0)
                {
                    dv.Columns[4].FillWeight = 60;
                    dv.Columns[5].FillWeight = 60;
                    dv.Columns[6].FillWeight = 160;
                    dv.Columns[8].FillWeight = 130;

                    //�����ʱ�侫ȷ����
                    dv.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strCounts = ds.Tables[0].Rows.Count.ToString();
                    }
                    else
                    {
                        strCounts = "0";
                    }


                }
                else
                {
                    strCounts = "0";
                }
            }

            return true;
        }
        #endregion

        #region [ ����: ��ѯʵʱ������������Ϣ_�豸 ]

        /// <summary>
        /// ��ѯʵʱ������������Ϣ_�豸
        /// </summary>
        /// <param name="strStartTime">��ʼʱ��</param>
        /// <param name="strEndTime">����ʱ��</param>
        /// <param name="strStationAddress">��վ���</param>
        /// <param name="strStationHeadAddress">��������</param>
        /// <param name="strName">�豸����</param>
        /// <param name="strCard">���������</param>
        /// <param name="strEquNO">�豸���</param>
        /// <param name="strDeptName">����</param>
        /// <param name="dv">Ҫ��ʾ��DataGridView</param>
        /// <returns></returns>
        public bool N_SearchRTInOutStationHeadInfo_Equ(
            string strStartTime,
            string strEndTime,
            string strStationAddress,
            string strStationHeadAddress,
            string strName,
            string strCard,
            string strEquNO,
            string strDeptName,
            DataGridViewKJ128 dv,
            out string strCounts)
        {
            if (DateTime.Compare(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime)) > 0)
            {
                MessageBox.Show("�Բ���, ��ʼʱ�䲻�ܴ��ڽ���ʱ�䣡");
                strCounts = "-1";
                return false;
            }

            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                //ds = dbacc.GetDataSet(strSql);
                ds = lrtdal.N_GetRTInOutStationHeadInfo_Equ(strStartTime, strEndTime, strStationAddress, strStationHeadAddress, strName, strCard,strEquNO, strDeptName );

                dv.DataSource = ds.Tables[0];
                if (ds != null && ds.Tables.Count > 0)
                {
                    dv.Columns[0].FillWeight = 60;
                    dv.Columns[2].FillWeight = 60;
                    dv.Columns[4].FillWeight = 60;
                    dv.Columns[5].FillWeight = 60;
                    dv.Columns[6].FillWeight = 150;
                    dv.Columns[7].FillWeight = 150;
                    dv.Columns[8].FillWeight = 140;
                    dv.Columns[9].FillWeight = 130;

                    //�����ʱ�侫ȷ����
                    dv.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strCounts = ds.Tables[0].Rows.Count.ToString();
                    }
                    else
                    {
                        strCounts = "0";
                    }
                }
                else
                {
                    strCounts = "0";
                }
            }

            return true;
        }
        #endregion

        /*
         * �ڲ�����
         */

        #region [ ����: ��TreeView�ؼ����ز��� ]

        /// <summary>
        /// �� TreeView �ؼ����ز���
        /// </summary>
        /// <param name="tn">���ڵ�</param>
        /// <param name="intParentDeptID">��ID</param>
        /// <param name="intRowsIndex">��ǰ����</param>
        /// <param name="intRowsCount">������</param>
        private void N_LoadChildDept(TreeNode tn, int intParentDeptID, int intRowsIndex, int intRowsCount)
        {
            if (intRowsIndex == intRowsCount)
            {
                return;
            }

            if (int.Parse(ds.Tables[0].Rows[intRowsIndex]["ParentDeptID"].ToString()).Equals(intParentDeptID))
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Name = ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString();
                tnChild.Text = ds.Tables[0].Rows[intRowsIndex]["DeptName"].ToString();
                tn.Nodes.Add(tnChild);

                this.N_LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount);
            }

            this.N_LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount);
        }

        #endregion

        #region [ ����: ��ComboBox�ؼ����ع��� ]

        private void N_LoadWorkType(ComboBox cmbWorkType)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "����"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["WorkTypeID"].ToString(), dr["WtName"].ToString()));
            }

            cmbWorkType.DataSource = mylist;
            cmbWorkType.DisplayMember = "Value";
            cmbWorkType.ValueMember = "Key";
            cmbWorkType.SelectedIndex = 0;
        }

        #endregion

    }
}