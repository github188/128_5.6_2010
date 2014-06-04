using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Data.SqlClient;
using KJ128NInterfaceShow;
using System.Windows.Forms;


namespace KJ128NDBTable
{
    public class RTClassifyBLL
    {

        #region [ ���� ]

        private DataSet ds;

        private static int intDetpCounts = 0;               //���㲿���¾�������

        private RTClassifyDAL rtcdal = new RTClassifyDAL();

        #endregion

        /*
         * �ⲿ����
         */
 
        #region [ ����: ��TreeView�ؼ�����(����, ����, ְ��, ְ��ȼ�)������Ϣ ]

        /// <summary>
        /// �� TreeView �ؼ�����(����, ����, ְ��, ְ��ȼ�)������Ϣ
        /// </summary>
        /// <param name="tv">Ҫ���ص� TreeView �ؼ�</param>
        /// <param name="strFlagFun">��Ϣ��־, ����Ϊ"Dept", ����Ϊ"WorkType", ְ��Ϊ"Business", ְ��ȼ�Ϊ"BusLevel",������Ϊ"Directional"</param>
        /// <param name="intUserType">�û�����, 1Ϊ��Ա, 2Ϊ�豸</param>
        /// <returns>���ؼ��غ�� TreeView </returns>
        public bool N_LoadInfo(TreeView tv, string strFlagFun, int intUserType)
        {
            tv.Nodes.Clear();

            using (ds = new DataSet())
            {
                switch (strFlagFun)
                {
                    case "Dept":
                        intDetpCounts = 0;
                        ds = this.N_GetDeptInfo(intUserType);
                        TreeNode tnDept = new TreeNode();
                        tnDept.Text = "���в���";
                        tv.Nodes.Add(tnDept);
                        this.N_LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count, intUserType == 1 ? " ��" : " ��");
                        tnDept.Text = "���в���( " + intDetpCounts.ToString() + " ��)";
                        break;
                    case "WorkType":
                        ds = this.N_GetWorkTypeInfo();
                        TreeNode tnWorkType = new TreeNode();
                        tnWorkType.Text = "���й���";
                        tv.Nodes.Add(tnWorkType);
                        this.N_LoadChildWorkType(tnWorkType);
                        break;
                    case "Business":
                        ds = this.N_GetBusinessInfo();
                        TreeNode tnBusiness = new TreeNode();
                        tnBusiness.Text = "����ְ��";
                        tv.Nodes.Add(tnBusiness);
                        this.N_LoadChildBusiness(tnBusiness);
                        break;
                    case "BusLevel":
                        ds = this.N_GetBusLevelInfo();
                        TreeNode tnBusLevel = new TreeNode();
                        tnBusLevel.Text = "����ְ��ȼ�";
                        tv.Nodes.Add(tnBusLevel);
                        this.N_LoadChildBusLevel(tnBusLevel);
                        break;
                    case "Directional":
                        ds = this.N_GetDirectionalInfo();
                        TreeNode tnDirectional = new TreeNode();
                        tnDirectional.Text = "���з�����";
                        tv.Nodes.Add(tnDirectional);
                        this.N_LoadChildDirectional(tnDirectional, ds);
                        break;
                    case "Territorial":
                        ds = this.N_GetTerritorialInfo();
                        TreeNode tnTerritorial = new TreeNode();
                        tnTerritorial.Text = "��������";
                        tv.Nodes.Add(tnTerritorial);
                        this.N_LoadChildTerritorial(tnTerritorial, ds);
                        break;
                    default:
                        return false;
                }
            }
            tv.ExpandAll();
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
        private void N_LoadChildDept(TreeNode tn, int intParentDeptID, int intRowsIndex, int intRowsCount, string strUnit)
        {
            if (intRowsIndex == intRowsCount)
            {
                return;
            }
           
            if (int.Parse(ds.Tables[0].Rows[intRowsIndex]["ParentDeptID"].ToString()).Equals(intParentDeptID))
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = ds.Tables[0].Rows[intRowsIndex]["DeptName"].ToString() + " ( " + ds.Tables[0].Rows[intRowsIndex]["Counts"].ToString() + strUnit + ")";
                intDetpCounts += Convert.ToInt32(ds.Tables[0].Rows[intRowsIndex]["Counts"]);
                tn.Nodes.Add(tnChild);

                this.N_LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount, strUnit);
            }

            this.N_LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount, strUnit);
        }

        #endregion

        #region [ ����: ��TreeView�ؼ����ط����� ]

        private void N_LoadChildDirectional(TreeNode tn, DataSet ds)
        {
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i += Convert.ToInt32(dr["Counts"]);
                string strSta, strStaPlace;
                strSta = dr["StationAddress"].ToString();
                strStaPlace = dr["StationPlace"].ToString();
                if (tn.Nodes[strSta] == null)
                {
                    int j = 0;
                    foreach (DataRow darow in ds.Tables[0].Rows)
                    {
                        if (darow["StationAddress"].ToString() == strSta)
                        {
                            j += Convert.ToInt32(darow["Counts"]);
                        }
                    }
                    TreeNode tnSta = new TreeNode();
                    tnSta.Text = strStaPlace + "  �� " + j.ToString() + " ��";
                    tnSta.Name = strSta;
                    tn.Nodes.Add(tnSta);
                }
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["Directional"].ToString() + " ( " + dr["Counts"].ToString() + " ��)";
                tn.Nodes[strSta].Nodes.Add(tnChild);
            }
            tn.Text = "����" + "( " + i.ToString() + " ��)";
        }

        #endregion

        #region [ ����: ��TreeView�ؼ����ع��� ]

        private void N_LoadChildWorkType(TreeNode tn)
        {
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i += Convert.ToInt32(dr["Counts"]);
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["WtName"].ToString() + " ( " + dr["Counts"].ToString() + " ��)";
                tn.Nodes.Add(tnChild);
            }
            tn.Text = "����" + "( " + i.ToString() + " ��)";
        }
        #endregion

        #region [ ����: ��TreeView�ؼ�����ְ�� ]

        private void N_LoadChildBusiness(TreeNode tn)
        {
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i += Convert.ToInt32(dr["Counts"]);
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["DutyName"].ToString() + " ( " + dr["Counts"].ToString() + " ��)";
                tn.Nodes.Add(tnChild);
            }
            tn.Text = "����" + "( " + i.ToString() + " ��)";
        }

        #endregion

        #region [ ����: ��TreeView�ؼ�����ְ��ȼ� ]

        private void N_LoadChildBusLevel(TreeNode tn)
        {
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i += Convert.ToInt32(dr["Counts"]);
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["Title"].ToString() + " ( " + dr["Counts"].ToString() + " ��)";
                tn.Nodes.Add(tnChild);
            }
            tn.Text = "����" + "( " + i.ToString() + " ��)";
        }
        #endregion

        #region [ ����: ��TreeView�ؼ��������� ]

        private void N_LoadChildTerritorial(TreeNode tn, DataSet ds)
        {
            int i = 0;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                string strID=string.Empty;

                i += Convert.ToInt32(dr1["Counts"]);
                TreeNode tnChildTer = new TreeNode();
                tnChildTer.Text = dr1["TypeName"].ToString() + " (" + dr1["Counts"].ToString() + " ��)";
                strID = dr1["TerritorialTypeID"].ToString();
                tnChildTer.Name = "T"+strID;
                foreach (DataRow dr2 in ds.Tables[1].Rows)
                {
                    if (dr2["TerritorialTypeID"].ToString().Equals(strID))
                    {
                        tnChildTer.Nodes.Add("Y" + dr2["TerritorialID"].ToString(), dr2["TerritorialName"].ToString() + " (" + dr2["Counts"].ToString() + " ��)");
                    }
                }
                
                tn.Nodes.Add(tnChildTer);
            }
            tn.Text = "��������(" + i.ToString() + " ��)";           
        }
        #endregion


        #region [ ����: ��ȡ������Ϣ ]

        private DataSet N_GetDeptInfo(int intUserType)
        {
            return rtcdal.N_GetDeptInfo(intUserType);
        }

        #endregion

        #region [ ����: ��ȡ������Ϣ ]

        private DataSet N_GetWorkTypeInfo()
        {
            return rtcdal.N_GetWorkTypeInfo();
        }

        #endregion

        #region [ ����: ��ȡְ����Ϣ ]

        private DataSet N_GetBusinessInfo()
        {
            return rtcdal.N_GetBusinessInfo();
        }
        #endregion

        #region [ ����: ��ȡְ��ȼ���Ϣ ]

        private DataSet N_GetBusLevelInfo()
        {
            return rtcdal.N_GetBusLevelInfo();
        }

        #endregion

        #region [ ����: ��ȡ��������Ϣ ]

        private DataSet N_GetDirectionalInfo()
        {
            return rtcdal.N_GetDirectionalInfo();
        }
        #endregion

        #region [ ����: ��ȡ������Ϣ ]

        private DataSet N_GetTerritorialInfo()
        {
            return rtcdal.N_GetTerritorialInfo();
        }
        #endregion

    }
}
