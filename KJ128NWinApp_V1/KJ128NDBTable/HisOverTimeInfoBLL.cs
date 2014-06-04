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
    public class HisOverTimeInfoBLL
    {
        private HisOverTimeInfoDAL htdal = new HisOverTimeInfoDAL();
        private DataSet ds;
        

        #region 加载部门 信息
        /// <summary>
        /// 加载部门 信息
        /// </summary>
        /// <param name="tvDep">部门树</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool LoadInfo(TreeView tvDep)
        {
            //加载部门
            using (ds = new DataSet())
            {
                ds = htdal.GetDeptInfo();
                TreeNode tnDept = new TreeNode();
                tnDept.Text = "所有部门";
                tvDep.Nodes.Add(tnDept);
                LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count);
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
        private void LoadChildDept(TreeNode tn, int intParentDeptID, int intRowsIndex, int intRowsCount)
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

                LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount);
            }

            LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount);
        }
        #endregion

        #endregion

        #region 组织 历史超时信息 查询条件
        /// <summary>
        /// 组织 历史超时信息 查询条件
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strName">员工姓名</param>
        /// <param name="strCard">发码器</param>
        /// <param name="strDeptName">部门名称</param>
        /// <returns>查询条件</returns>
        public string SelectWhere(string strStartTime, string strEndTime, string strName, string strCard, string strDeptName)
        {

            string strSql = " CsTypeID=0 And 开始超时时间 >= '" + strStartTime + "' And 开始超时时间 <='" + strEndTime + "' ";

            if (strName != "" && strName != null)
            {
                strSql += " And 员工姓名 like  '%" + strName + "%' ";
            }

            if (strCard != "" && strCard != null)
            {
                strSql += " And 发码器 = " + strCard;
            }

            if (strDeptName != "" && strDeptName != null)
            {
                strSql += " And ( 部门 = " + strDeptName + ") ";
            }

            return strSql;
        }
        #endregion

        #region 查询历史超时信息
        public DataSet GetOverTimeSet(int pageIndex, int pageSize, string where)
        {
            DataSet ds = htdal.GetOverTimeSet(pageIndex,pageSize,where);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
            }
            return ds;
        }
        #endregion
    }
}
