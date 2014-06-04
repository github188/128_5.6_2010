/*
 *  李恩仁
 *  时间: 2007-9-22
 *  功能: 历史汇总信息
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

        #region 给 TreeView 控件加载(部门, 工种, 职务, 职务等级)基本信息
        /// <summary>
        /// 给 TreeView 控件加载(部门, 工种, 职务, 职务等级)基本信息
        /// </summary>
        /// <param name="tv">要加载的 TreeView 控件</param>
        /// <param name="strFlagFun">信息标志, 部门为"Dept", 工种为"WorkType", 职务为"Business", 职务等级为"BusLevel"</param>
        /// <param name="intUserType">用户类型, 1为人员, 2为设备</param>
        /// <returns></returns>
        public bool LoadInfo(TreeView tv, string strFlagFun, int intUserType, string strStartTime, string strEndTime)
        {
            if (DateTime.Compare(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime)) > 0)
            {
                MessageBox.Show("对不起,开始时间不能大于结束时间！");
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
                        tnDept.Text = "所有部门";
                        tv.Nodes.Add(tnDept);
                        LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count, intUserType == 0 ? "人" : "个", strStartTime, strEndTime);

                        tnDept.Text = "所以部门( " + lidal.GetDeptCounts("0", strStartTime, strEndTime) + " 人)";
                        break;
                    case "WorkType":
                        ds = lidal.GetWorkTypeInfo(strStartTime, strEndTime);
                        TreeNode tnWorkType = new TreeNode();
                        tnWorkType.Text = "所有工种";
                        tv.Nodes.Add(tnWorkType);
                        LoadChildWorkType(tnWorkType);
                        break;
                    case "Business":
                        ds = lidal.GetBusinessInfo(strStartTime, strEndTime);
                        TreeNode tnBusiness = new TreeNode();
                        tnBusiness.Text = "所有职务";
                        tv.Nodes.Add(tnBusiness);
                        LoadChildBusiness(tnBusiness);
                        break;
                    case "BusLevel":
                        ds = lidal.GetBusLevelInfo(strStartTime, strEndTime);
                        TreeNode tnBusLevel = new TreeNode();
                        tnBusLevel.Text = "所有职务等级";
                        tv.Nodes.Add(tnBusLevel);
                        LoadChildBusLevel(tnBusLevel);
                        break;
                    case "Territorial":
                        ds = lidal.GetTerritorialInfo(strStartTime, strEndTime);
                        TreeNode tnTerritorial = new TreeNode();
                        tnTerritorial.Text = "所有区域";
                        tv.Nodes.Add(tnTerritorial);
                        LoadChildTerritorial(tnTerritorial);
                        break;
                        
                    default:
                    return false;
                }
            }

            return true;
        }

        #region 给 TreeView 控件加载部门
        /// <summary>
        /// 给 TreeView 控件加载部门
        /// </summary>
        /// <param name="tn">父节点</param>
        /// <param name="intParentDeptID">父ID</param>
        /// <param name="intRowsIndex">当前行数</param>
        /// <param name="intRowsCount">总行数</param>
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

        #region 给 TreeView 控件加载工种
        private void LoadChildWorkType(TreeNode tn)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["WtName"].ToString() + " (" + dr["Counts"].ToString() + "人)";
                tn.Nodes.Add(tnChild);
            }
        }
        #endregion

        #region 给 TreeView 控件加载职务
        private void LoadChildBusiness(TreeNode tn)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["DutyName"].ToString() + " (" + dr["Counts"].ToString() + "人)";
                tn.Nodes.Add(tnChild);
            }
        }
        #endregion

        #region 给 TreeView 控件加载职务等级
        private void LoadChildBusLevel(TreeNode tn)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["Title"].ToString() + " (" + dr["Counts"].ToString() + "人)";
                tn.Nodes.Add(tnChild);
            }
        }
        #endregion

        #region 给 TreeView 控件加载区域

        private void LoadChildTerritorial(TreeNode tn)
        {
            int i = 0;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                string strID = string.Empty;

                string territorialTypeName = dr1["TerritorialTypeName"].ToString();
                i += Convert.ToInt32(dr1["Counts"]);
                TreeNode tnChildTer = new TreeNode();
                tnChildTer.Text = dr1["TerritorialTypeName"].ToString() + " (" + dr1["Counts"].ToString() + " 人)";
                //strID = dr1["TerritorialTypeID"].ToString();
                tnChildTer.Name = "T" + territorialTypeName;
                foreach (DataRow dr2 in ds.Tables[1].Rows)
                {
                    if (dr2["TerritorialTypeName"].ToString().Equals(territorialTypeName))
                    {
                        tnChildTer.Nodes.Add("Y" + dr2["TerritorialName"].ToString(), dr2["TerritorialName"].ToString() + " (" + dr2["Counts"].ToString() + " 人)");
                    }
                }

                tn.Nodes.Add(tnChildTer);
            }
            tn.Text = "所有区域(" + i.ToString() + " 人)";
        }

        #endregion

        #endregion
    }
}
