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
    public class ConStaHeadInfoBLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private ConStaHeadInfoDAL csdal = new ConStaHeadInfoDAL();

        #endregion 

        /*
         * 内部调用
         */ 

        #region [ 方法: 查询分站信息 ]

        private DataSet N_GetStationInfo()
        {
            return csdal.N_GetStationInfo();
        }

        #endregion

        #region [ 方法: 查询分站信息 ]

        private DataSet N_GetStaHeadInfo(string strStationAddress)
        {
            return csdal.N_GetStationInfo(strStationAddress);
        }

        #endregion

        /*
         * 外部调用
         */ 

        #region [ 方法: 查询分站信息 ]

        /// <summary>
        /// 查询分站信息
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public int N_SearchStationInfo(DataGridViewKJ128 dv)
        {
            int iSum = 0;
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = this.N_GetStationInfo();
                dv.DataSource = ds.Tables[0].DefaultView;
                iSum = ds.Tables[0].Rows.Count;
                if (dv.Rows.Count > 0)
                {
                    dv.Rows[0].Selected = true;
                }
                dv.Columns[0].FillWeight = 60;
                dv.Columns[2].FillWeight = 80;
                dv.Columns[3].FillWeight = 60;
            }

            return iSum;
        }
        #endregion

        #region [ 方法: 按分站编号查询接收器信息 ]

        /// <summary>
        /// 按分站编号查询接收器信息
        /// </summary>
        /// <param name="strStationAddress">分站编号</param>
        /// <param name="dv"></param>
        /// <returns></returns>
        public int N_SearchStaHeadInfo(string strStationAddress, DataGridViewKJ128 dv)
        {
            int iSum = 0;
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = this.N_GetStaHeadInfo(strStationAddress);
                dv.DataSource = ds.Tables[0].DefaultView;
                if (dv.Rows.Count > 0)
                {
                    iSum = ds.Tables[0].Rows.Count;
                    dv.Rows[0].Selected = true;
                    dv.Columns[0].FillWeight = 50;
                    dv.Columns[2].FillWeight = 55;
                    dv.Columns[3].FillWeight = 50;
                    dv.Columns[4].FillWeight = 65;
                    dv.Columns[5].FillWeight = 65;
                }
            }

            return iSum;
        }
        #endregion

    }
}
