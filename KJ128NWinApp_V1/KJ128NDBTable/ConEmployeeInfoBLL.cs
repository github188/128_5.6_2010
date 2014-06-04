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
    public class ConEmployeeInfoBLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private ConEmployeeInfoDAL ceidal = new ConEmployeeInfoDAL();

        #endregion

        /*
         * 内部调用
         */ 

        #region [ 方法: 获取部门信息 ]

        private DataSet N_GetDeptInfo()
        {
            return ceidal.N_GetDeptInfo();
        }

        #endregion

        #region [ 方法: 获取工种信息 ]

        private DataSet N_GetWorkTypeInfo()
        {
            return ceidal.N_GetWorkTypeInfo();
        }

        #endregion

        #region [ 方法: 获取职务信息 ]

        private DataSet N_GetBusinessInfo()
        {
            return ceidal.N_GetBusinessInfo();
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
                tnChild.Name = ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString();
                tn.Nodes.Add(tnChild);

                LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount);
            }

            LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount);
        }

        #endregion

        #region [ 方法: 给ComboBox控件加载工种 ]

        private void LoadWorkType(ComboBox cmbWorkType)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

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

        #region [ 方法: 给ComboBox控件加载职务 ]

        private void LoadDuty(ComboBox cmbDutyName)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["DutyID"].ToString(), dr["DutyName"].ToString()));
            }

            cmbDutyName.DataSource = mylist;
            cmbDutyName.DisplayMember = "Value";
            cmbDutyName.ValueMember = "Key";
            cmbDutyName.SelectedIndex = 0;
        }

        #endregion

        /*
         * 外部调用
         */ 

        #region [ 方法: 加载部门,工种,职务信息 ]

        public bool LoadInfo(TreeView tvDep, ComboBox cmbWorkType, ComboBox cmbDutyName, int intUserType)
        {
            //加载部门
            using (ds = new DataSet())
            {
                ds = this.N_GetDeptInfo();
                TreeNode tnDept = new TreeNode();
                tnDept.Text = "所有部门";
                tnDept.Name = "0";
                tvDep.Nodes.Add(tnDept);
                LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count);
            }

            //加载工种
            using (ds = new DataSet())
            {
                ds = this.N_GetWorkTypeInfo();
                LoadWorkType(cmbWorkType);
            }

            //加载职务
            using (ds = new DataSet())
            {
                ds = this.N_GetBusinessInfo();
                LoadDuty(cmbDutyName);
            }

            return true;
        }

        #endregion

        #region [ 方法: 查询人员配置信息 ]

        /// <summary>
        /// 查询人员配置信息
        /// </summary>
        /// <param name="strName">员工姓名</param>
        /// <param name="strNo">员工编号</param>
        /// <param name="strIdCard">身份证编号</param>
        /// <param name="strDeptID">部门ID</param>
        /// <param name="strWorkTypeId">工种ID</param>
        /// <param name="strDutyId">职务ID</param>
        /// <param name="dv">要绑定的DataGridView</param>
        /// <returns>true 成功，false 不成功</returns>
        public bool N_SearchConEmployeeInfo(string strName, string strNo, string strIdCard, string strDeptID, string strWorkTypeId, string strDutyId, DataGridViewKJ128 dv, out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = ceidal.N_GetConEmployeeInfo(strName, strNo, strIdCard, strDeptID, strWorkTypeId, strDutyId);

                dv.DataSource = ds.Tables[0].DefaultView;
                dv.Columns[0].FillWeight = 76;
                dv.Columns[1].FillWeight = 76;
                dv.Columns[2].FillWeight = 53;
                dv.Columns[3].FillWeight = 70;
                dv.Columns[4].FillWeight = 70;
                dv.Columns[5].FillWeight = 70;
                dv.Columns[6].FillWeight = 90;
                dv.Columns[7].FillWeight = 100;
                dv.Columns[8].FillWeight = 100;
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

    }
}
