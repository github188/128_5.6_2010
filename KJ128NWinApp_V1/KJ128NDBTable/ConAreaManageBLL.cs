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
    public class ConAreaManageBLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private ConAreaManageDAL camdal = new ConAreaManageDAL();

        #endregion

        /*
         * 内部调用
         */ 

        #region [ 方法: 给ComboBox控件加载区域名称 ]

        private void N_LoadTerName(ComboBox cmbTerName)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["TerritorialID"].ToString(), dr["TerritorialName"].ToString()));
            }

            cmbTerName.DataSource = mylist;
            cmbTerName.DisplayMember = "Value";
            cmbTerName.ValueMember = "Key";
            cmbTerName.SelectedIndex = 0;
        }

        #endregion

        #region [ 方法: 给ComboBox控件加载区域类别 ]

        private void N_LoadTerType(ComboBox cmbTerType)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["TerritorialTypeID"].ToString(), dr["TypeName"].ToString()));
            }

            cmbTerType.DataSource = mylist;
            cmbTerType.DisplayMember = "Value";
            cmbTerType.ValueMember = "Key";
            cmbTerType.SelectedIndex = 0;
        }

        #endregion

        /*
         * 外部调用
         */ 

        #region [ 方法: 加载区域名称、区域类别 ]

        public bool N_LoadInfo(ComboBox cmbTerName,ComboBox cmbTerType)
        {
            //区域名称
            using (ds = new DataSet())
            {
                ds = camdal.N_GetTerName();
                this.N_LoadTerName(cmbTerName);
            }

            //区域类别
            using (ds = new DataSet())
            {
                ds = camdal.N_GetTerType();
                this.N_LoadTerType(cmbTerType);
            }
            return true;
        }

        #endregion

        #region [ 方法: 查询区域设置 ]

        /// <summary>
        /// 查询 区域设置
        /// </summary>
        /// <param name="strTerID">区域ID</param>
        /// <param name="strTerTypeID">区域类别ID</param>
        /// <param name="dv">要绑定的DataGridView</param>
        /// <returns>true: 成功</returns>
        public bool N_SearchTerSet(string strTerID, string strTerTypeID, DataGridViewKJ128 dv, out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = camdal.N_SearchTerSet(strTerID, strTerTypeID);

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

        #region [ 方法: 查询区域信息 ]

        public int N_SearchTerInfo( DataGridViewKJ128 dv)
        {
            int iSum = 0;
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = camdal.N_SearchTerInfo();

                dv.DataSource = ds.Tables[0].DefaultView;
                iSum = ds.Tables[0].Rows.Count;
            }
            return iSum;
        }

        #endregion

        #region [ 方法: 查询区域类型 ]

        public int N_SearchTerType(DataGridViewKJ128 dv)
        {
            int iSum = 0;
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds=camdal.N_SearchTerType();

                dv.DataSource = ds.Tables[0].DefaultView;
                iSum = ds.Tables[0].Rows.Count;
            }
            return iSum;
        }

        #endregion
    }
}
