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
    public  class ConDeptManageBLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private ConDeptManageDAL cddal = new ConDeptManageDAL();

        #endregion

        /*
         * 内部调用
         */ 

        #region [ 方法:给TreeView控件加载部门 ]

        /// <summary>
        /// 给 TreeView 控件加载部门
        /// </summary>
        /// <param name="tn">父节点</param>
        /// <param name="intParentDeptID">父ID</param>
        /// <param name="intRowsIndex">当前行数</param>
        /// <param name="intRowsCount">总行数</param>
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
                tnChild.Name = ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString();
                tn.Nodes.Add(tnChild);

                this.N_LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount);
            }

            this.N_LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount);
        }
        #endregion

        #region [ 方法: 获取工种信息 ]

        private DataSet N_GetWorkTypeInfo()
        {
            return cddal.N_GetWorkTypeInfo();
        }

        #endregion

        #region [ 方法: 获取证书信息 ]

        private DataSet N_GetCertificateInfo()
        {
            return cddal.N_GetCertificateInfo();
        }

        #endregion

        #region [ 方法: 获取职务信息 ]

        private DataSet N_GetDutyInfo()
        {
            return cddal.N_GetDutyInfo();
        }

        #endregion
     
        #region [ 方法: 根据部门ID,获取部门详细信息 ]

        /// <summary>
        /// 根据部门ID,获取部门详细信息
        /// </summary>
        /// <param name="strDeptID">部门ID</param>
        /// <returns></returns>
        private DataSet N_GetSearchDeptInfo(string strDeptID)
        {
            return cddal.N_GetSearchDeptInfo(strDeptID);
        }

        #endregion

        #region [方法: 获取部门基本信息 ]

        private DataSet N_GetDeptInfo()
        {
            return cddal.N_GetDeptInfo();
        }

        #endregion

        /*
         * 外部调用
         */ 

        #region [ 方法: 加载部门信息 ]

        /// <summary>
        /// 加载部门信息
        /// </summary>
        /// <param name="tvDep">部门树</param>
        /// <param name="intUserType"></param>
        /// <returns></returns>
        public bool N_LoadInfo(TreeView tvDep, int intUserType)
        {
            //加载部门
            using (ds = new DataSet())
            {
                ds = this.N_GetDeptInfo();
                TreeNode tnDept = new TreeNode();
                tnDept.Text = "所有部门";
                tnDept.Name = "0";
                tvDep.Nodes.Add(tnDept);
                this.N_LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count);
            }

            return true;
        }

        #endregion

        #region [ 方法: 查询部门信息 ]

        /// <summary>
        /// 查询部门信息
        /// </summary>
        /// <param name="dv">要绑定的DataGridView</param>
        /// <param name="strDeptID">部门ID</param>
        /// <returns>true 成功，false 不成功</returns>
        public int N_SearchDeptInfo(DataGridViewKJ128 dv, string strDeptID)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = this.N_GetSearchDeptInfo(strDeptID);
                dv.DataSource = ds.Tables[0].DefaultView;
                //dv.Columns[0].FillWeight = 76;
                //dv.Columns[1].FillWeight = 76;
                //dv.Columns[2].FillWeight = 53;
                //dv.Columns[3].FillWeight = 70;
                //dv.Columns[4].FillWeight = 70;
                //dv.Columns[5].FillWeight = 70;
                //dv.Columns[6].FillWeight = 90;
                //dv.Columns[7].FillWeight = 100;
                //dv.Columns[8].FillWeight = 100;
            }

            return ds.Tables[0].Rows.Count;
        }

        #endregion

        #region [ 方法:查询(工种、证书、职务)信息 ]

        /// <summary>
        /// 查询(工种、证书、职务) 信息
        /// </summary>
        /// <param name="dv">要绑定的DataGridView</param>
        /// <param name="strFlagFun">信息标志,  工种为"WorkType", 证书为"Certificate", 职务为"Duty"</param>
        /// <returns>true 成功，false 不成功</returns>
        public int N_SearchInfo(DataGridViewKJ128 dv, string strFlagFun)
        {
            int iSum = 0;
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                switch (strFlagFun)
                {
                    case "WorkType":
                        ds = this.N_GetWorkTypeInfo();
                        dv.DataSource = ds.Tables[0].DefaultView;
                        dv.Columns[0].FillWeight = 45;
                        dv.Columns[1].FillWeight = 45;
                        dv.Columns[2].FillWeight = 50;
                        dv.Columns[3].FillWeight = 50;
                        break;
                    case "Certificate":
                        ds = this.N_GetCertificateInfo();
                        dv.DataSource = ds.Tables[0].DefaultView;
                        dv.Columns[0].FillWeight = 45;
                        dv.Columns[1].FillWeight = 65;
                        dv.Columns[2].FillWeight = 45;
                        break;
                    case "Duty":
                        ds = this.N_GetDutyInfo();
                        dv.DataSource = ds.Tables[0].DefaultView;
                        dv.Columns[0].FillWeight = 45;
                        dv.Columns[1].FillWeight = 45;
                        break;
                    default:
                        return 0;
                }
                iSum = ds.Tables[0].Rows.Count;
            }
            return iSum;
        }

        #endregion
    }
}
