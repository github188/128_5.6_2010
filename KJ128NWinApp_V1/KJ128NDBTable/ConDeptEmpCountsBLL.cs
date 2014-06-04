using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;

namespace KJ128NDBTable
{
    public class ConDeptEmpCountsBLL
    {

        #region [ 申明 ]

        private ConDeptEmpCountsDAL cddal = new ConDeptEmpCountsDAL();

        private DataSet ds;

        #endregion

        /*
         * 外部调用
         */ 

        #region [ 方法: 加载部门树 ]

        /// <summary>
        /// 加载 部门树
        /// </summary>
        public void N_LoadDeptTree(TreeView trDept)
        {
            using (ds = new DataSet())
            {
                trDept.Nodes.Clear();
                //intDetpCounts = 0;
                ds = this.N_GetDeptInfo();
                TreeNode tnDept = new TreeNode();
                tnDept.Text = "所有部门";
                tnDept.Name = "0";
                trDept.Nodes.Add(tnDept);
                this.N_LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count, "人");

                tnDept.Text = "所有部门( " + this.N_GetDeptCounts() + " 人)";
                //cpDepartment.CaptionTitle = "下井人员部门统计      共" + intDetpCounts.ToString() + "人";

            }
            trDept.ExpandAll();
        }

        #endregion

        /*
         * 内部调用
         */ 

        #region [ 方法: 获取部门信息 ]

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns>返回 部门信息(DataSet)</returns>
        private DataSet N_GetDeptInfo()
        {
            return cddal.N_GetDeptInfo();
        }

        #endregion

        #region [ 方法: 获取总人数 ]

        /// <summary>
        /// 获取总人数
        /// </summary>
        /// <returns></returns>
        private string N_GetDeptCounts()
        {
            return cddal.N_GetDeptCounts();
        }

        #endregion

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
                tnChild.Text = ds.Tables[0].Rows[intRowsIndex]["DeptName"].ToString() + " (" + ds.Tables[0].Rows[intRowsIndex]["Counts"].ToString() + strUnit + ")";
                tnChild.Name = ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString();
                //intDetpCounts += Convert.ToInt32(ds.Tables[0].Rows[intRowsIndex]["Counts"]);
                tn.Nodes.Add(tnChild);

                this.N_LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount, strUnit);
            }

            this.N_LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount, strUnit);
        }
        #endregion


    }
}
