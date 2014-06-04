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
    public class Li_HisInOutStationHeadRecodset_BLL : Li_HisInMineRecordSet_BLL
    {

        #region [ 声明 ]
        
        private Li_HisInOutStationHeadRecodsetDAL li = new Li_HisInOutStationHeadRecodsetDAL();
        private DataSet ds;
        private string strSql = string.Empty;

        #endregion


        #region [ 方法: 给ComboBox控件加载分站,接收器信息 ]

        /// <summary>
        /// 给 ComboBox 控件加载分站, 接收器信息
        /// </summary>
        /// <param name="cmbStation">加载分站的 ComboBox 控件</param>
        /// <param name="cmbStationHead">加载控头的 ComboBox 控件</param>
        /// <param name="blFlagLoadStationHead">是否加载控头</param>
        /// <returns></returns>
        public bool LoadInfo(ComboBox cmbStation, ComboBox cmbStationHead, bool blFlagLoadStationHead)
        {
            if (blFlagLoadStationHead)
            {
                string strStationAddress = cmbStation.SelectedValue.ToString();

                if (!strStationAddress.Equals("0"))
                {
                    using (ds = new DataSet())
                    {
                        ds = li.GetStationHeadInfo(strStationAddress);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            LoadStationHeadInfo(cmbStationHead);
                        }
                    }
                }
                else
                {
                    //重置接收器信息
                    ResetStationHead(cmbStationHead);
                }
            }
            else
            {
                using (ds = new DataSet())
                {
                    ds = li.GetStationInfo();
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        LoadStationInfo(cmbStation);

                        //重置接收器信息
                        ResetStationHead(cmbStationHead);
                    }
                }
            }

            return true;
        }

        #region 给 ComboBox 控件加载分站
        private void LoadStationInfo(ComboBox cmbStation)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["StationAddress"].ToString(), dr["StationPlace"].ToString()));
            }

            cmbStation.DataSource = mylist;
            cmbStation.DisplayMember = "Value";
            cmbStation.ValueMember = "Key";
            cmbStation.SelectedIndex = 0;
        }
        #endregion

        #region 给 ComboBox 控件加载接收器
        private void LoadStationHeadInfo(ComboBox cmbStationHead)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["StationHeadAddress"].ToString(), dr["StationHeadPlace"].ToString()));
            }

            cmbStationHead.DataSource = mylist;
            cmbStationHead.DisplayMember = "Value";
            cmbStationHead.ValueMember = "Key";
            cmbStationHead.SelectedIndex = 0;
        }
        #endregion

        #region 重置接收器信息
        private void ResetStationHead(ComboBox cmbStationHead)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));
            cmbStationHead.DataSource = mylist;
            cmbStationHead.DisplayMember = "Value";
            cmbStationHead.ValueMember = "Key";
            cmbStationHead.SelectedIndex = 0;
        }
        #endregion
        #endregion

        #region [ 方法: 组织查询条件 ]

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strName">姓名</param>
        /// <param name="strCard">卡号</param>
        /// <param name="strIdCard">身份证号</param>
        /// <param name="strDeptName">部门名称</param>
        /// <param name="strCerTypeId">证书ID</param>
        /// <param name="strDutyId">职务ID</param>
        /// <param name="strStationAddress">分站地址</param>
        /// <param name="strStationHeadAddress">接收器地址</param>
        /// <returns>返回查询条件</returns>
        public string SelectWhere(string strStartTime,string strEndTime,string strName,string strCard,string strIdCard,string strDeptName,string strCerTypeId,string strDutyId,
            string strStationAddress,string strStationHeadAddress)
        {
            strSql = "  进入接收器时间 >= '" + strStartTime + "' And 进入接收器时间 <= '" + strEndTime + "' ";

            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And 姓名 like '%" + strName + "%' ";
            }

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And 发码器 = " + strCard;
            }

            if (!(strIdCard.Equals("") | strIdCard.Equals(null)))
            {
                strSql += " And Idcard like '%" + strIdCard + "%' ";
            }

            if (!(strDeptName.Equals("所有部门")))
            {
                strSql += " And ( 部门 = " + strDeptName + ") ";
            }

            if (!strCerTypeId.Equals("0"))
            {
                strSql += " And CerTypeID = " + strCerTypeId;
            }

            if (!strDutyId.Equals("0"))
            {
                strSql += " And DutyID = " + strDutyId;
            }

            if (!(strStationAddress.Equals("0")))
            {
                strSql += " And 分站地址 = " + strStationAddress;
            }

            if (!(strStationHeadAddress.Equals("0")))
            {
                strSql += " And 接收器地址 = " + strStationHeadAddress;
            }

            return strSql;

        }

        #endregion

        #region [ 方法: 查询历史进出接收器信息 ]

        public DataSet GetInOutStationHeadSet(int pageIndex, int pageSize, string where)
        {
            return li.GetInOutStationHeadSet(pageIndex, pageSize, where);
        }

        #endregion


        #region [ 方法: 获得设备查询表 ]

        /// <summary>
        /// 获得查询表
        /// </summary>
        /// <param name="strEquID">设备名称</param>
        /// <param name="strDeptID">部门编号</param>
        /// <param name="strFactoryID">生产厂家</param>
        /// <param name="strInStationHeadTime">进入分站时间</param>
        /// <param name="strOutStationHeadTime">离开分站时间</param>
        /// <returns>表</returns>
        public DataSet GetConditionEqu(string strEquID, string strDeptID, string strFactoryID, string strEquType, string strInStationHeadTime, string strOutStationHeadTime)
        {
            return li.GetConditionEqu(strEquID, strDeptID, strFactoryID, strEquType, strInStationHeadTime, strOutStationHeadTime);
        }

        #endregion 

    }
}
