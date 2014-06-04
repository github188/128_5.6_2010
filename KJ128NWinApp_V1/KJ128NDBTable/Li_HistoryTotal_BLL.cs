/*
 *  �����
 *  ʱ��: 2007-9-22
 *  ����: ��ʷ������Ϣ
 */

using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class Li_HistoryTotal_BLL
    {
        private DataSet ds;
        private Li_HistoryTotalDAL lidal = new Li_HistoryTotalDAL();
        private string strStartDateTime, strEndDateTime;

        #region �� TreeView �ؼ�����(����, ����, ְ��, ְ��ȼ�)������Ϣ
        /// <summary>
        /// �� TreeView �ؼ�����(����, ����, ְ��, ְ��ȼ�)������Ϣ
        /// </summary>
        /// <param name="tv">Ҫ���ص� TreeView �ؼ�</param>
        /// <param name="strFlagFun">��Ϣ��־, ����Ϊ"Dept", ����Ϊ"WorkType", ְ��Ϊ"Business", ְ��ȼ�Ϊ"BusLevel"</param>
        /// <param name="intUserType">�û�����, 1Ϊ��Ա, 2Ϊ�豸</param>
        /// <returns></returns>
        public bool LoadInfo(TreeView tv, string strFlagFun, int intUserType, string strStartTime, string strEndTime)
        {
            if (DateTime.Compare(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime)) > 0)
            {
                MessageBox.Show("�Բ���,��ʼʱ�䲻�ܴ��ڽ���ʱ�䣡");
                return false;
            }

            tv.Nodes.Clear();

            using (ds = new DataSet())
            {
                switch (strFlagFun)
                {
                    case "Dept":
                        ds = lidal.GetDeptInfo(intUserType, strStartTime, strEndTime);
                        strStartDateTime = strStartTime;
                        strEndDateTime = strEndTime;
                        TreeNode tnDept = new TreeNode();
                        tnDept.Text = "���в���";
                        tv.Nodes.Add(tnDept);
                        LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count, intUserType == 0 ? "��" : "��", strStartTime, strEndTime);

                        tnDept.Text = "���Բ���( " + lidal.GetDeptCounts("0", strStartTime, strEndTime) + " ��)";
                        break;
                    case "WorkType":
                        ds = lidal.GetWorkTypeInfo(strStartTime, strEndTime);
                        TreeNode tnWorkType = new TreeNode();
                        tnWorkType.Text = "���й���";
                        tv.Nodes.Add(tnWorkType);
                        LoadChildWorkType(tnWorkType);
                        break;
                    case "Business":
                        ds = lidal.GetBusinessInfo(strStartTime, strEndTime);
                        TreeNode tnBusiness = new TreeNode();
                        tnBusiness.Text = "����ְ��";
                        tv.Nodes.Add(tnBusiness);
                        LoadChildBusiness(tnBusiness);
                        break;
                    case "BusLevel":
                        ds = lidal.GetBusLevelInfo(strStartTime, strEndTime);
                        TreeNode tnBusLevel = new TreeNode();
                        tnBusLevel.Text = "����ְ��ȼ�";
                        tv.Nodes.Add(tnBusLevel);
                        LoadChildBusLevel(tnBusLevel);
                        break;
                    case "Territorial":
                        ds = lidal.GetTerritorialInfo(strStartTime, strEndTime);
                        TreeNode tnTerritorial = new TreeNode();
                        tnTerritorial.Text = "��������";
                        tv.Nodes.Add(tnTerritorial);
                        LoadChildTerritorial(tnTerritorial);
                        break;
                        
                    default:
                    return false;
                }
            }

            return true;
        }

        #region �� TreeView �ؼ����ز���
        /// <summary>
        /// �� TreeView �ؼ����ز���
        /// </summary>
        /// <param name="tn">���ڵ�</param>
        /// <param name="intParentDeptID">��ID</param>
        /// <param name="intRowsIndex">��ǰ����</param>
        /// <param name="intRowsCount">������</param>
        private void LoadChildDept(TreeNode tn, int intParentDeptID, int intRowsIndex, int intRowsCount, string strUnit,string strStartTime, string strEndTime)
        {
            if (intRowsIndex == intRowsCount)
            {
                return;
            }

            if (int.Parse(ds.Tables[0].Rows[intRowsIndex]["ParentDeptID"].ToString()).Equals(intParentDeptID))
            {
                TreeNode tnChild = new TreeNode();
                //tnChild.Text = ds.Tables[0].Rows[intRowsIndex]["DeptName"].ToString() + " (" + ds.Tables[0].Rows[intRowsIndex]["Counts"].ToString() + strUnit + ")";
                //intDeptCounts +=Convert.ToInt32(GetDeptCounts(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()));
                tnChild.Text = ds.Tables[0].Rows[intRowsIndex]["DeptName"].ToString() + " (" + lidal.GetDeptCounts(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString(), strStartTime, strEndTime) + strUnit + ")";
                tn.Nodes.Add(tnChild);

                LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount, strUnit, strStartTime, strEndTime);
            }

            LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount, strUnit, strStartTime, strEndTime);
        }

        
        #endregion

        #region �� TreeView �ؼ����ع���
        private void LoadChildWorkType(TreeNode tn)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["WtName"].ToString() + " (" + dr["Counts"].ToString() + "��)";
                tn.Nodes.Add(tnChild);
            }
        }
        #endregion

        #region �� TreeView �ؼ�����ְ��
        private void LoadChildBusiness(TreeNode tn)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["DutyName"].ToString() + " (" + dr["Counts"].ToString() + "��)";
                tn.Nodes.Add(tnChild);
            }
        }
        #endregion

        #region �� TreeView �ؼ�����ְ��ȼ�
        private void LoadChildBusLevel(TreeNode tn)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["Title"].ToString() + " (" + dr["Counts"].ToString() + "��)";
                tn.Nodes.Add(tnChild);
            }
        }
        #endregion

        #region �� TreeView �ؼ���������

        private void LoadChildTerritorial(TreeNode tn)
        {
            int i = 0;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                string strID = string.Empty;

                string territorialTypeName = dr1["TerritorialTypeName"].ToString();
                i += Convert.ToInt32(dr1["Counts"]);
                TreeNode tnChildTer = new TreeNode();
                tnChildTer.Text = dr1["TerritorialTypeName"].ToString() + " (" + dr1["Counts"].ToString() + " ��)";
                //strID = dr1["TerritorialTypeID"].ToString();
                tnChildTer.Name = "T" + territorialTypeName;
                foreach (DataRow dr2 in ds.Tables[1].Rows)
                {
                    if (dr2["TerritorialTypeName"].ToString().Equals(territorialTypeName))
                    {
                        tnChildTer.Nodes.Add("Y" + dr2["TerritorialName"].ToString(), dr2["TerritorialName"].ToString() + " (" + dr2["Counts"].ToString() + " ��)");
                    }
                }

                tn.Nodes.Add(tnChildTer);
            }
            tn.Text = "��������(" + i.ToString() + " ��)";
        }

        #endregion

        #endregion
    }
}
