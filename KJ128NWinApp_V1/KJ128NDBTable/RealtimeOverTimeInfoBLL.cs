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
    public class RealtimeOverTimeInfoBLL
    {

        #region [ 声明 ]
        
        private DataSet ds;
        
        private string strSql = string.Empty;

        private RealtimeOverTimeInfoDAL rtotdal = new RealtimeOverTimeInfoDAL();

        #endregion 

        /*
         * 外部调用
         */ 

        #region [ 方法: 加载部门,工种,职务信息 ]

        public bool N_LoadInfo(TreeView tvDep, ComboBox cmbWorkType, ComboBox cmbDutyName, int intUserType)
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

            //加载工种
            using(ds=new DataSet())
            {
                ds = this.N_GetWorkTypeInfo();
                this.N_LoadWorkType(cmbWorkType,ds);
            }

            //加载职务
            using (ds = new DataSet())
            {
                ds = this.N_GetBusinessInfo();
                this.N_LoadDuty(cmbDutyName,ds);
            }

            return true;
        }

        #endregion

        #region [ 方法: 查询实时超时信息 ]

        public bool N_SearchOverTimeInfo(string strName,string strCard,string strDeptID,string strWorkTypeId,string strDutyId,DataGridViewKJ128 dv,out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                //ds = dbacc.GetDataSet(strSql);

                ds=rtotdal.N_GetOverTimeInfo(strName,strCard,strDeptID,strWorkTypeId,strDutyId);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dv.DataSource = ds.Tables[0].DefaultView;

                    //将开始超时时间精确到秒

                    dv.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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

        #region [ 方法: 查询实时超时信息 ]

        public bool SearchOverTimeInfo(string strName, string strCard, string strDeptID, string strWorkTypeId, string strDutyId, DataGridViewKJ128 dv, out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                //ds = dbacc.GetDataSet(strSql);

                ds = rtotdal.N_GetOverTimeInfo(strName, strCard, strDeptID, strWorkTypeId, strDutyId);
                ds.Tables[0].TableName = "TaskTimeBLL_RtOverTime";
                dv.DataSource = ds.Tables[0].DefaultView;

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

        #region [ 方法: 给ComboBox控件加载工种 ]

        private ComboBox N_LoadWorkType(ComboBox cmb, DataSet ds)
        {
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "WtName";
                cmb.ValueMember = "WorkTypeID";
            }
            return cmb;
        }

        #endregion

        #region [ 方法: 给ComboBox控件加载职务 ]

        private ComboBox N_LoadDuty(ComboBox cmb, DataSet ds)
        {
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DutyName";
                cmb.ValueMember = "DutyID";
            }
            return cmb;
        }

        #endregion

        #region [ 方法: 获取部门信息 ]

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns>部门信息(DataSet)</returns>
        private DataSet N_GetDeptInfo()
        {
            return rtotdal.N_GetDeptInfo();
        }

        #endregion

        #region [ 方法: 获取工种信息 ]

        /// <summary>
        /// 获取工种信息
        /// </summary>
        /// <returns>工种信息(DataSet)</returns>
        private DataSet N_GetWorkTypeInfo()
        {
            return rtotdal.N_GetWorkTypeInfo();
        }

        #endregion

        #region [ 方法: 获取职务信息 ]

        /// <summary>
        /// 获取职务信息
        /// </summary>
        /// <returns>职务信息(DataSet)</returns>
        private DataSet N_GetBusinessInfo()
        {
            return rtotdal.N_GetBusinessInfo();
        }

        #endregion

    }
}
