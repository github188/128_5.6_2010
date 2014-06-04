using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using KJ128NInterfaceShow;

namespace KJ128NDBTable
{
    public class RealTimeDirectionalBLL
    {

        #region [ ���� ]

        private DataSet ds;

        private RealTimeDirectionalDAL rtddal = new RealTimeDirectionalDAL();
        
        #endregion

        /*
         * �ⲿ����
         */ 

        #region [ ����: ��TreeView�ؼ����ز��� ]

        public void N_LoadDept(TreeView tvDep)
        {
            //���ز���
            using (ds = new DataSet())
            {
                ds = this.N_GetDeptInfo();
                TreeNode tnDept = new TreeNode();
                tnDept.Text = "���в���";
                tvDep.Nodes.Add(tnDept);
                this.N_LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count);
                tvDep.ExpandAll();
            }
        }

        #endregion

        #region [ ����: ��ѯʵʱ��������Ϣ ]

        public void N_SelectRTDirectional(string strDept, string strName, string strCardAddress, string strStation, string strStaHead, bool blIsEmp,string strDirectional, DataGridViewKJ128 dv,out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = rtddal.N_GetRTDirectional(strDept, strName, strCardAddress, strStation, strStaHead, blIsEmp, strDirectional);

                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns[3].ColumnName = HardwareName.Value(CorpsName.StationAddress);
                ds.Tables[0].Columns[4].ColumnName = HardwareName.Value(CorpsName.StaHeadAddress);
                ds.Tables[0].Columns[6].ColumnName = HardwareName.Value(CorpsName.Inspect);


                if (ds != null && ds.Tables.Count > 0)
                {

                    //ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                    //ds.Tables[0].Columns[3].ColumnName = HardwareName.Value(CorpsName.StationAddress);
                    //ds.Tables[0].Columns[4].ColumnName = HardwareName.Value(CorpsName.StaHeadAddress);
                    //ds.Tables[0].Columns[6].ColumnName = HardwareName.Value(CorpsName.Inspect);

                    dv.DataSource = ds.Tables[0].DefaultView;
                    dv.Columns[7].Visible = false;
                    dv.Columns[0].FillWeight = 50;
                    dv.Columns[1].FillWeight = 60;
                    dv.Columns[2].FillWeight = 60;
                    dv.Columns[3].FillWeight = 45;
                    dv.Columns[4].FillWeight = 45;
                    dv.Columns[5].FillWeight = 120;
                    dv.Columns[6].FillWeight = 85;

                    //�����ʱ�侫ȷ����
                    dv.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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
                    }
                    else
                    {
                        strCounts = "0";
                    }
                }
                else
                {
                    dv.DataSource = null;
                    strCounts = "0";
                }
            }             
        }
        #endregion

        #region [ ����: ���ݷ�վ��ַ��ѯ��վλ�� ]

        public string SelectStationPlace(string strStation)
        {
            return rtddal.N_SelectStationPlace(strStation);
        }

        #endregion

        /*
         * �ڲ�����
         */ 

        #region [ ����: ��ȡ������Ϣ ]
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <returns>������Ϣ(DataSet)</returns>
        private DataSet N_GetDeptInfo()
        {
            return rtddal.N_GetDeptInfo();
        }

        #endregion

        #region [ ����: ��TreeView�ؼ����ز��� ]

        /// <summary>
        /// ��TreeView�ؼ����ز���
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
                tnChild.Text = ds.Tables[0].Rows[intRowsIndex]["DeptName"].ToString();
                tn.Nodes.Add(tnChild);

                this.N_LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount);
            }

            this.N_LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount);
        }

        #endregion
    }
}
