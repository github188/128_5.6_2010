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
    public class Li_RealTimeInOutStationHeadInfo_BLL : Li_HistoryInOutAntenna_BLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private Li_RealTimeInOutStationHeadInfo_DAL lrtdal = new Li_RealTimeInOutStationHeadInfo_DAL();

        #endregion


        /*
         * 外部调用
         */ 

        #region [ 方法: 加载部门,工种信息 ]

        public bool N_LoadInfo(TreeView tvDep, ComboBox cmbWorkType, int intUserType)
        {
            //加载部门
            using (ds = new DataSet())
            {
                ds = lrtdal.N_GetDeptInfo();
                if (ds != null && ds.Tables.Count > 0)
                {
                    TreeNode tnDept = new TreeNode();
                    tnDept.Text = "所有部门";
                    tnDept.Name = "0";
                    tvDep.Nodes.Add(tnDept);
                    this.N_LoadChildDept(tnDept, 0, 0, ds.Tables[0].Rows.Count);
                }
            }

            //加载工种
            using (ds = new DataSet())
            {
                ds = lrtdal.N_GetWorkTypeInfo();
                if (ds != null && ds.Tables.Count > 0)
                {
                    this.N_LoadWorkType(cmbWorkType);
                }
            }

            return true;
        }

        #endregion

        #region [ 方法: 查询实时进出接收器信息_人员 ]

        /// <summary>
        /// 查询实时进出接收器信息_人员 
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strStationAddress">分站编号</param>
        /// <param name="strStationHeadAddress">接收器号</param>
        /// <param name="strName">姓名</param>
        /// <param name="strCard">发码器</param>
        /// <param name="strWorkTypeId">工种</param>
        /// <param name="strDeptName">部门</param>
        /// <param name="intUserType">用户类型 1人 2设备</param>
        /// <param name="dv">要显示的DataGridView</param>
        /// <returns></returns>
        public bool N_SearchRTInOutStationHeadInfo(
            string strStartTime, 
            string strEndTime, 
            string strStationAddress, 
            string strStationHeadAddress,
            string strName,
            string strCard,
            string strWorkTypeId,
            string strDeptName,
            int intUserType,
            DataGridViewKJ128 dv,
            out string strCounts)
        {
            if (DateTime.Compare(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime)) > 0)
            {
                MessageBox.Show("对不起, 开始时间不能大于结束时间！");
                strCounts="-1";
                return false;
            }

            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                //ds = dbacc.GetDataSet(strSql);
                ds = lrtdal.N_GetRTInOutStationHeadInfo(strStartTime, strEndTime, strStationAddress, strStationHeadAddress, strName, strCard, strWorkTypeId, strDeptName, intUserType);

                dv.DataSource = ds.Tables[0].DefaultView;
                if (ds != null && ds.Tables.Count > 0)
                {
                    dv.Columns[4].FillWeight = 60;
                    dv.Columns[5].FillWeight = 60;
                    dv.Columns[6].FillWeight = 160;
                    dv.Columns[8].FillWeight = 130;

                    //将监测时间精确到秒
                    dv.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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

        #region [ 方法: 查询实时进出接收器信息_设备 ]

        /// <summary>
        /// 查询实时进出接收器信息_设备
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strStationAddress">分站编号</param>
        /// <param name="strStationHeadAddress">接收器号</param>
        /// <param name="strName">设备名称</param>
        /// <param name="strCard">发码器编号</param>
        /// <param name="strEquNO">设备编号</param>
        /// <param name="strDeptName">部门</param>
        /// <param name="dv">要显示的DataGridView</param>
        /// <returns></returns>
        public bool N_SearchRTInOutStationHeadInfo_Equ(
            string strStartTime,
            string strEndTime,
            string strStationAddress,
            string strStationHeadAddress,
            string strName,
            string strCard,
            string strEquNO,
            string strDeptName,
            DataGridViewKJ128 dv,
            out string strCounts)
        {
            if (DateTime.Compare(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime)) > 0)
            {
                MessageBox.Show("对不起, 开始时间不能大于结束时间！");
                strCounts = "-1";
                return false;
            }

            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                //ds = dbacc.GetDataSet(strSql);
                ds = lrtdal.N_GetRTInOutStationHeadInfo_Equ(strStartTime, strEndTime, strStationAddress, strStationHeadAddress, strName, strCard,strEquNO, strDeptName );

                dv.DataSource = ds.Tables[0];
                if (ds != null && ds.Tables.Count > 0)
                {
                    dv.Columns[0].FillWeight = 60;
                    dv.Columns[2].FillWeight = 60;
                    dv.Columns[4].FillWeight = 60;
                    dv.Columns[5].FillWeight = 60;
                    dv.Columns[6].FillWeight = 150;
                    dv.Columns[7].FillWeight = 150;
                    dv.Columns[8].FillWeight = 140;
                    dv.Columns[9].FillWeight = 130;

                    //将监测时间精确到秒
                    dv.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

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
                tnChild.Name = ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString();
                tnChild.Text = ds.Tables[0].Rows[intRowsIndex]["DeptName"].ToString();
                tn.Nodes.Add(tnChild);

                this.N_LoadChildDept(tnChild, int.Parse(ds.Tables[0].Rows[intRowsIndex]["DeptID"].ToString()), intRowsIndex + 1, intRowsCount);
            }

            this.N_LoadChildDept(tn, intParentDeptID, intRowsIndex + 1, intRowsCount);
        }

        #endregion

        #region [ 方法: 给ComboBox控件加载工种 ]

        private void N_LoadWorkType(ComboBox cmbWorkType)
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

    }
}