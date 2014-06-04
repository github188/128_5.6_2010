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

        #region [ 声明 ]

        private DataSet ds;

        private static int intDetpCounts = 0;               //计算部门下井总人数

        private RTClassifyDAL rtcdal = new RTClassifyDAL();

        #endregion

        /*
         * 外部调用
         */
 
        #region [ 方法: 给TreeView控件加载(部门, 工种, 职务, 职务等级)基本信息 ]

        /// <summary>
        /// 给 TreeView 控件加载(部门, 工种, 职务, 职务等级)基本信息
        /// </summary>
        /// <param name="tv">要加载的 TreeView 控件</param>
        /// <param name="strFlagFun">信息标志, 部门为"Dept", 工种为"WorkType", 职务为"Business", 职务等级为"BusLevel",方向性为"Directional"</param>
        /// <param name="intUserType">用户类型, 1为人员, 2为设备</param>
        /// <returns>返回加载后的 TreeView </returns>
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
                        tnDept.Text = "所有部门";
                        tv.Nodes.Add(tnDept);
                        this.N_LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count, intUserType == 1 ? " 个" : " 人");
                        tnDept.Text = "所有部门( " + intDetpCounts.ToString() + " 人)";
                        break;
                    case "WorkType":
                        ds = this.N_GetWorkTypeInfo();
                        TreeNode tnWorkType = new TreeNode();
                        tnWorkType.Text = "所有工种";
                        tv.Nodes.Add(tnWorkType);
                        this.N_LoadChildWorkType(tnWorkType);
                        break;
                    case "Business":
                        ds = this.N_GetBusinessInfo();
                        TreeNode tnBusiness = new TreeNode();
                        tnBusiness.Text = "所有职务";
                        tv.Nodes.Add(tnBusiness);
                        this.N_LoadChildBusiness(tnBusiness);
                        break;
                    case "BusLevel":
                        ds = this.N_GetBusLevelInfo();
                        TreeNode tnBusLevel = new TreeNode();
                        tnBusLevel.Text = "所有职务等级";
                        tv.Nodes.Add(tnBusLevel);
                        this.N_LoadChildBusLevel(tnBusLevel);
                        break;
                    case "Directional":
                        ds = this.N_GetDirectionalInfo();
                        TreeNode tnDirectional = new TreeNode();
                        tnDirectional.Text = "所有方向性";
                        tv.Nodes.Add(tnDirectional);
                        this.N_LoadChildDirectional(tnDirectional, ds);
                        break;
                    case "Territorial":
                        ds = this.N_GetTerritorialInfo();
                        TreeNode tnTerritorial = new TreeNode();
                        tnTerritorial.Text = "所有区域";
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
         * 内部调用
         */
 
        #region [ 方法: 给TreeView控件加载部门 ]

        /// <summary>
        /// 给 TreeView 控件加载部门
        /// </summary>
        /// <param name="tn">父节点</param>
        /// <param name="intParentDeptID">父ID</param>
        /// <param name="intRowsIndex">当前行数</param>
        /// <param name="intRowsCount">总行数</param>
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

        #region [ 方法: 给TreeView控件加载方向性 ]

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
                    tnSta.Text = strStaPlace + "  共 " + j.ToString() + " 人";
                    tnSta.Name = strSta;
                    tn.Nodes.Add(tnSta);
                }
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["Directional"].ToString() + " ( " + dr["Counts"].ToString() + " 人)";
                tn.Nodes[strSta].Nodes.Add(tnChild);
            }
            tn.Text = "所有" + "( " + i.ToString() + " 人)";
        }

        #endregion

        #region [ 方法: 给TreeView控件加载工种 ]

        private void N_LoadChildWorkType(TreeNode tn)
        {
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i += Convert.ToInt32(dr["Counts"]);
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["WtName"].ToString() + " ( " + dr["Counts"].ToString() + " 人)";
                tn.Nodes.Add(tnChild);
            }
            tn.Text = "所有" + "( " + i.ToString() + " 人)";
        }
        #endregion

        #region [ 方法: 给TreeView控件加载职务 ]

        private void N_LoadChildBusiness(TreeNode tn)
        {
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i += Convert.ToInt32(dr["Counts"]);
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["DutyName"].ToString() + " ( " + dr["Counts"].ToString() + " 人)";
                tn.Nodes.Add(tnChild);
            }
            tn.Text = "所有" + "( " + i.ToString() + " 人)";
        }

        #endregion

        #region [ 方法: 给TreeView控件加载职务等级 ]

        private void N_LoadChildBusLevel(TreeNode tn)
        {
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i += Convert.ToInt32(dr["Counts"]);
                TreeNode tnChild = new TreeNode();
                tnChild.Text = dr["Title"].ToString() + " ( " + dr["Counts"].ToString() + " 人)";
                tn.Nodes.Add(tnChild);
            }
            tn.Text = "所有" + "( " + i.ToString() + " 人)";
        }
        #endregion

        #region [ 方法: 给TreeView控件加载区域 ]

        private void N_LoadChildTerritorial(TreeNode tn, DataSet ds)
        {
            int i = 0;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                string strID=string.Empty;

                i += Convert.ToInt32(dr1["Counts"]);
                TreeNode tnChildTer = new TreeNode();
                tnChildTer.Text = dr1["TypeName"].ToString() + " (" + dr1["Counts"].ToString() + " 人)";
                strID = dr1["TerritorialTypeID"].ToString();
                tnChildTer.Name = "T"+strID;
                foreach (DataRow dr2 in ds.Tables[1].Rows)
                {
                    if (dr2["TerritorialTypeID"].ToString().Equals(strID))
                    {
                        tnChildTer.Nodes.Add("Y" + dr2["TerritorialID"].ToString(), dr2["TerritorialName"].ToString() + " (" + dr2["Counts"].ToString() + " 人)");
                    }
                }
                
                tn.Nodes.Add(tnChildTer);
            }
            tn.Text = "所有区域(" + i.ToString() + " 人)";           
        }
        #endregion


        #region [ 方法: 获取部门信息 ]

        private DataSet N_GetDeptInfo(int intUserType)
        {
            return rtcdal.N_GetDeptInfo(intUserType);
        }

        #endregion

        #region [ 方法: 获取工种信息 ]

        private DataSet N_GetWorkTypeInfo()
        {
            return rtcdal.N_GetWorkTypeInfo();
        }

        #endregion

        #region [ 方法: 获取职务信息 ]

        private DataSet N_GetBusinessInfo()
        {
            return rtcdal.N_GetBusinessInfo();
        }
        #endregion

        #region [ 方法: 获取职务等级信息 ]

        private DataSet N_GetBusLevelInfo()
        {
            return rtcdal.N_GetBusLevelInfo();
        }

        #endregion

        #region [ 方法: 获取方向性信息 ]

        private DataSet N_GetDirectionalInfo()
        {
            return rtcdal.N_GetDirectionalInfo();
        }
        #endregion

        #region [ 方法: 获取区域信息 ]

        private DataSet N_GetTerritorialInfo()
        {
            return rtcdal.N_GetTerritorialInfo();
        }
        #endregion

    }
}
