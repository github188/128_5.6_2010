using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using KJ128NInterfaceShow;

namespace KJ128NDBTable
{
    public class RealTimeDirectionalBLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private RealTimeDirectionalDAL rtddal = new RealTimeDirectionalDAL();
        
        #endregion

        /*
         * 外部调用
         */ 

        #region [ 方法: 给TreeView控件加载部门 ]

        public void N_LoadDept(TreeView tvDep)
        {
            //加载部门
            using (ds = new DataSet())
            {
                ds = this.N_GetDeptInfo();
                TreeNode tnDept = new TreeNode();
                tnDept.Text = "所有部门";
                tvDep.Nodes.Add(tnDept);
                this.N_LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count);
                tvDep.ExpandAll();
            }
        }

        #endregion

        #region [ 方法: 查询实时方向性信息 ]

        public void N_SelectRTDirectional(string strDept, string strName, string strCardAddress, string strStation, string strStaHead, bool blIsEmp,string strDirectional, DataGridViewKJ128 dv,out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = rtddal.N_GetRTDirectional(strDept, strName, strCardAddress, strStation, strStaHead, blIsEmp, strDirectional);

                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns[3].ColumnName = HardwareName.Value(CorpsName.StationAddress);
                ds.Tables[0].Columns[4].ColumnName = HardwareName.Value(CorpsName.StaHeadAddress);
                ds.Tables[0].Columns[6].ColumnName = HardwareName.Value(CorpsName.Inspect);


                if (ds != null && ds.Tables.Count > 0)
                {

                    //ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                    //ds.Tables[0].Columns[3].ColumnName = HardwareName.Value(CorpsName.StationAddress);
                    //ds.Tables[0].Columns[4].ColumnName = HardwareName.Value(CorpsName.StaHeadAddress);
                    //ds.Tables[0].Columns[6].ColumnName = HardwareName.Value(CorpsName.Inspect);

                    dv.DataSource = ds.Tables[0].DefaultView;
                    dv.Columns[7].Visible = false;
                    dv.Columns[0].FillWeight = 50;
                    dv.Columns[1].FillWeight = 60;
                    dv.Columns[2].FillWeight = 60;
                    dv.Columns[3].FillWeight = 45;
                    dv.Columns[4].FillWeight = 45;
                    dv.Columns[5].FillWeight = 120;
                    dv.Columns[6].FillWeight = 85;

                    //将监测时间精确到秒
                    dv.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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
                else
                {
                    dv.DataSource = null;
                    strCounts = "0";
                }
            }             
        }
        #endregion

        #region [ 方法: 根据分站地址查询分站位置 ]

        public string SelectStationPlace(string strStation)
        {
            return rtddal.N_SelectStationPlace(strStation);
        }

        #endregion

        /*
         * 内部调用
         */ 

        #region [ 方法: 获取部门信息 ]
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns>部门信息(DataSet)</returns>
        private DataSet N_GetDeptInfo()
        {
            return rtddal.N_GetDeptInfo();
        }

        #endregion

        #region [ 方法: 给TreeView控件加载部门 ]

        /// <summary>
        /// 给TreeView控件加载部门
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
                tn.Nodes.Add(tnChild);

                this.N_LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount);
            }

            this.N_LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount);
        }

        #endregion
    }
}
