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
    public class RealTimeInTerritorialBLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private RealTimeInTerritorialDAL rtitdal = new RealTimeInTerritorialDAL();

        #endregion

        /*
         * 外部调用
         */ 

        #region [ 方法: 给ComboBox 控件加载区域名称 ]

        public void N_LoadTerName(ComboBox cmb)
        {
            DataSet ds = this.N_GetTerInfo();
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

        #region [ 方法: 给ComboBox控件加载区域类别 ]

        public void  N_LoadTerTypeName(ComboBox cmb)
        {
            DataSet ds = this.N_GetTerTypeInfo();
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

        #region [ 方法: 查询实时区域信息 ]

        public bool N_SearchRTInTerritorialInfo(int  intTerTypeID,string strTerName,bool blIsEmp,string strIsAlarm, DataGridViewKJ128 dv,out string strCounts)
        {            
            using (ds = new DataSet())                              //加载信息
            {
                dv.Columns.Clear();
                ds = rtitdal.N_GetRTInTerritorialInfo(intTerTypeID, strTerName, blIsEmp, strIsAlarm);
                dv.DataSource = ds.Tables[0].DefaultView;

                //将进入区域时间精确到秒
                dv.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dv.Columns[6].FillWeight = 120;

                dv.Columns[5].Visible  = false;

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

        #region 是否是人员区域报警

        public bool IsEmpAlarm()
        {
            using (ds=new DataSet())
            {
                ds = rtitdal.GetEmpAlarm();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        /*
         * 内部调用
         */ 

        #region [ 方法: 获取区域信息 ]

        private DataSet N_GetTerInfo()
        {
            return rtitdal.N_GetTerInfo();
        }

        #endregion

        #region [ 方法: 获取区域类别 ]

        private DataSet N_GetTerTypeInfo()
        {
            return rtitdal.N_GetTerTypeInfo();
        }

        #endregion

    }
}
