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
    public class Li_HisInMineRecordSet_BLL
    {
        private Li_HisInMineRecordSetDAL lim = new Li_HisInMineRecordSetDAL();
        private DataSet ds;
        private string strSql = string.Empty;

        #region 加载部门,工种, 证书, 职务,职务等级 信息
        public bool LoadInfo(TreeView tvDep, ComboBox cmbWorkType, ComboBox cmbCerType, ComboBox cmbDutyName, ComboBox cmbDutyClass, int intUserType)
        {
            if (tvDep != null)
            {
                //加载部门
                using (ds = new DataSet())
                {
                    ds = lim.GetDeptInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        TreeNode tnDept = new TreeNode();
                        tnDept.Text = "所有部门";
                        tvDep.Nodes.Add(tnDept);
                        LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count);
                    }
                }
            }

            if (cmbWorkType != null)
            {
                //加载工种
                using (ds = new DataSet())
                {
                    ds = lim.GetWorkTypeInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadWorkType(cmbWorkType);
                    }
                }
            }

            if (cmbDutyClass != null)
            {
                //加载职务等级
                using (ds = new DataSet())
                {
                    ds = lim.GetBusLevelInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadDutyClass(cmbDutyClass);
                    }
                }
            }

            if (cmbCerType != null)
            {
                //加载证书
                using (ds = new DataSet())
                {
                    ds = lim.GetCerType();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadCerType(cmbCerType);
                    }
                }
            }

            if (cmbDutyName != null)
            {
                //加载职务
                using (ds = new DataSet())
                {
                    ds = lim.GetBusinessInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadDuty(cmbDutyName);
                    }
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

        #region 给 ComboBox 控件加载工种
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

        #region 给 ComboBox 控件加载证书
        private void LoadCerType(ComboBox cmbCerType)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["CerTypeID"].ToString(), dr["CerName"].ToString()));
            }

            cmbCerType.DataSource = mylist;
            cmbCerType.DisplayMember = "Value";
            cmbCerType.ValueMember = "Key";
            cmbCerType.SelectedIndex = 0;
        }
        #endregion

        #region 给 ComboBox 控件加载职务
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

        #region 给 ComboBox 控件加载职务等级
        private void LoadDutyClass(ComboBox cmbDutyClass)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["EnumID"].ToString(), dr["Title"].ToString()));
            }

            cmbDutyClass.DataSource = mylist;
            cmbDutyClass.DisplayMember = "Value";
            cmbDutyClass.ValueMember = "Key";
            cmbDutyClass.SelectedIndex = 0;
        }
        #endregion
        #endregion

        #region 组织查询条件
        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strName">姓名</param>
        /// <param name="strCard">卡号</param>
        /// <param name="strIdCard">身份证号</param>
        /// <param name="strWorkTypeId">工种ID号</param>
        /// <param name="strCerTypeId">证书ID号</param>
        /// <param name="strDutyId">职务ID号</param>
        /// <param name="strDutyClassId">职务等级ID号</param>
        /// <returns>返回查询条件</returns>
        public string SelectWhere(string strStartTime, string strEndTime, string strName, string strCard, string strIdCard, string strDeptName,
            string strWorkTypeId, string strCerTypeId, string strDutyId,string strDutyClassId)
        {
            strSql = " 下井时间 >= '" + strStartTime + "' And 下井时间 <= '" + strEndTime + "' ";

            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And 姓名 Like '%" + strName + "%' ";
            }

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And 发码器 = " + strCard;
            }

            if (!(strIdCard.Equals("") | strIdCard.Equals(null)))
            {
                strSql += " And Idcard Like '%" + strIdCard + "%' ";
            }

            if (!(strDeptName.Equals("所有部门")))
            {
                strSql += " And ( 部门 = " + strDeptName + ") ";
            }

            if (!strWorkTypeId.Equals("0"))
            {
                strSql += " And WorkTypeID = " + strWorkTypeId;
            }

            if (!strCerTypeId.Equals("0"))
            {
                strSql += " And CerTypeID = " + strCerTypeId;
            }

            if (!strDutyId.Equals("0"))
            {
                strSql += " And DutyID = " + strDutyId;
            }

            if (!strDutyClassId.Equals("0"))
            {
                strSql += " And EnumID = " + strDutyClassId;
            }
            return strSql;
        }
        #endregion

        #region 查询 历史下井信息
        public DataSet GetHisInMineSet(int pageIndex, int pageSize, string where)
        {
            DataSet ds  = lim.GetHisInMineSet(pageIndex,pageSize,where);
            if (ds!=null &&ds.Tables.Count>0)
            {
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns["下井时间"].ColumnName = HardwareName.Value(CorpsName.InWellTime);
                ds.Tables[0].Columns["上井时间"].ColumnName = HardwareName.Value(CorpsName.OutWellTime);
                ds.Tables[0].Columns["井下时长"].ColumnName = HardwareName.Value(CorpsName.StandingWellTime);
            }
            return ds;
        }
        #endregion
    }
}
