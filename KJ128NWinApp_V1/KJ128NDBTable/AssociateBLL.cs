using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class AssociateBLL
    {
        #region 【自定义参数】
        private AssociateDAL associateDal = new AssociateDAL();
        private DegonControlLib.TreeViewControl tvc = new DegonControlLib.TreeViewControl();
        #endregion

        #region 【方法：获取分站树信息】
        /// <summary>
        /// 获取分站树信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStationTree()
        {
            DataTable dt;
            DataSet ds;
            ds = associateDal.GetStationTree();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            else
            {
                dt = tvc.BuildMenusEntity();
            }

            DataRow dr = dt.NewRow();
            SetDataRow(ref dr, 0, "所有", -1, false, false, 0);
            dt.Rows.Add(dr);
            dt.AcceptChanges();

            return dt;
        }
        #endregion

        #region 【方法：设置树信息】
        /// <summary>
        /// 设置树信息
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="parentid"></param>
        /// <param name="isChild"></param>
        /// <param name="isUserNum"></param>
        /// <param name="num"></param>
        private void SetDataRow(ref DataRow dr, int id, string name, int parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }
        #endregion

        #region 【方法：添加异地交接班信息】
        /// <summary>
        /// 添加异地交接班信息
        /// </summary>
        /// <param name="stationAddress">传输分站地址号</param>
        /// <param name="stationHeadAddress">读卡分站地址号</param>
        /// <param name="stationHeadPlace">读卡分站安装位置</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="empid1">人员编号1</param>
        /// <param name="empid2">人员编号2</param>
        /// <param name="empName1">人员姓名1</param>
        /// <param name="empName2">人员姓名2</param>
        /// <returns></returns>
        public int AddAssociate(int stationAddress, int stationHeadAddress, string stationHeadPlace, DateTime beginTime, DateTime endTime, int empid1, int empid2, string empName1, string empName2)
        {
            try
            {
                return associateDal.AddAssociate(stationAddress, stationHeadAddress, stationHeadPlace, beginTime, endTime, empid1, empid2, empName1, empName2);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region 【方法：删除异地交接班信息】
        public int DeleteAssociate(int id)
        {
            try
            {
                return associateDal.DeleteAssociate(id);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region 【方法：获取交接班显示配置】
        /// <summary>
        /// 获取交接班显示配置信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页显示个数</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回记录集</returns>
        public DataSet getAssociateConfig(int pageIndex, int pageSize, string strWhere)
        {
            try
            {
                return associateDal.getAssociateConfig(pageIndex, pageSize, strWhere);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 【方法：显示交接班实时异常信息】
        /// <summary>
        /// 获取实时交接班异常信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetRealTimeAssociateAlertInfo(int pageIndex, int pageSize, string strWhere)
        {
            try
            {
                return associateDal.GetRealTimeAssociateAlertInfo(pageIndex, pageSize, strWhere);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 【方法：获取交接班历史信息】
        /// <summary>
        /// 获取交接班信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAssociateInfo(int pageIndex, int pageSize, string strWhere)
        {
            try
            {
                return associateDal.GetAssociateInfo(pageIndex, pageSize, strWhere);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 【方法：显示交接班实时异常统计信息】
        /// <summary>
        /// 获取实时交接班异常统计信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetRealTimeAssociateAlertCount()
        {
            try
            {
                return associateDal.GetRealTimeAssociateAlertCount();
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 【方法：获取传输分站下拉列表框信息】
        /// <summary>
        /// 获取传输分站下拉列表框信息
        /// </summary>
        /// <param name="cmb"></param>
        public void GetStationInfoComboBox(ComboBox cmb)
        {
            DataSet ds = associateDal.GetStationInfo();
            cmb.DataSource = null;
            cmb.Items.Clear();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["stationID"] = "0";
                dr["stationAddress"] = "选择";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "stationAddress";
                cmb.ValueMember = "stationID";
            }
            else
            {
                cmb.Items.Insert(0, "选择");
            }
        }
        #endregion

        #region 【方法：获取读卡分站下拉列表框信息】
        /// <summary>
        /// 获取读卡分站下拉列表框信息
        /// </summary>
        /// <param name="cmb"></param>
        public void GetStationHeadInfoComboBox(ComboBox cmb, string strWhere)
        {
            DataSet ds = associateDal.GetStationHeadInfo(strWhere);
            cmb.DataSource = null;
            cmb.Items.Clear();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["stationHeadPlace"] = "0";
                dr["stationHeadAddress"] = "选择";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "stationHeadAddress";
                cmb.ValueMember = "stationHeadPlace";
            }
            else
            {
                cmb.Items.Insert(0, "选择");
            }
        }
        #endregion

        #region 【方法：获取工种信息下拉列表框信息】
        /// <summary>
        /// 获取工种下拉列表框信息
        /// </summary>
        /// <param name="cmb"></param>
        public void GetWorkTypeInfoComboBox(ComboBox cmb)
        {
            DataSet ds = associateDal.GetWorkTypeInfo();
            cmb.DataSource = null;
            cmb.Items.Clear();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["workTypeID"] = "0";
                dr["WtName"] = "选择";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "WtName";
                cmb.ValueMember = "workTypeID";
            }
            else
            {
                cmb.Items.Insert(0, "选择");
            }
        }
        #endregion

        #region 【方法：获取员工姓名下拉列表框信息】
        /// <summary>
        /// 获取员工姓名下拉列表框信息
        /// </summary>
        /// <param name="cmb"></param>
        public void GetEmpInfoComboBox(ComboBox cmb, string strWhere)
        {
            DataSet ds = associateDal.GetEmpInfo(strWhere);
            cmb.DataSource = null;
            cmb.Items.Clear();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["empid"] = "0";
                dr["empName"] = "选择";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "empName";
                cmb.ValueMember = "empid";
            }
            else
            {
                cmb.Items.Insert(0, "选择");
            }
        }
        #endregion

    }
}
