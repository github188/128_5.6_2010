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
    public class HisInTerritorialBLL
    {
        private HisInTerritorialDAL hi = new HisInTerritorialDAL();
        private string strSql = string.Empty;

        #region 给 ComboBox 控件加载区域名称
        public void LoadTerName(ComboBox cmb)
        {
            DataSet ds = hi.GetTerInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "TerritorialName";
                cmb.ValueMember = "TerritorialID";
            }
        }
        #endregion

        #region 给 ComboBox 控件加载区域类别
        public void LoadTerTypeName(ComboBox cmb)
        {
            DataSet ds = hi.GetTerTypeInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "TypeName";
                cmb.ValueMember = "TerritorialTypeID";
            }

        }
        #endregion

        #region 组织 历史区域 查询条件
        /// <summary>
        /// 组织 历史区域 查询条件
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strTerTypeName">区域类型</param>
        /// <param name="strTerName">区域名称</param>
        /// <param name="blIsEmp">true:员工,false:设备</param>
        /// <returns>查询语句</returns>
        public string SelectWhere(string strStartTime, string strEndTime, string strTerTypeName, string strTerName, bool blIsEmp)
        {
            if (blIsEmp)                                            //员工
            {
                strSql = " CsTypeID=0 ";
            }
            else                                                   //设备
            {
                strSql = " CsTypeID=1 ";

            }
            strSql += " And 进入区域时间 >= '" + strStartTime + "' And 进入区域时间 <='" + strEndTime + "' ";

            if (strTerName != "所有")                                     //区域名称
            {
                strSql += " And 区域名称= '" + strTerName + "'";
            }
            if (strTerTypeName != "所有")                                  //区域类别
            {
                strSql += " And 区域类别='" + strTerTypeName + "'";
            }

            return strSql;
        }
        #endregion

        #region 查询历史区域员工信息
        public DataSet GetHisInTerInfoSet(int pageIndex, int pageSize, string where,bool blIsEmp)
        {
            DataSet ds = hi.GetHisInTerInfoSet(pageIndex, pageSize, where, blIsEmp);
            if (ds!=null&&ds.Tables.Count>0)
            {
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);
                ds.Tables[0].Columns["进入区域时间"].ColumnName = HardwareName.Value(CorpsName.InTerritorialTime);
                ds.Tables[0].Columns["离开区域时间"].ColumnName = HardwareName.Value(CorpsName.OutTerritorialTime);
                ds.Tables[0].Columns["持续时长"].ColumnName = HardwareName.Value(CorpsName.StandingTime);
            }
            return ds;
        }
        #endregion

    }
}
