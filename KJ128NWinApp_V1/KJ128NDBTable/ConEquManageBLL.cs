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
    public class ConEquManageBLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private ConEquManageDAL cemdal = new ConEquManageDAL();

        #endregion

        /*
         * 外部调用
         */ 

        #region [ 方法: 加载厂家名称 ]

        public bool N_LoadInfo(ComboBox cmbFactoryName)
        {
            using (ds = new DataSet())
            {
                ds = this.N_GetFactoryName();
                this.N_LoadFactoryName(cmbFactoryName);
            }

            return true;
        }

        #endregion

        #region [ 方法: 查询设备信息 ]

        public bool N_SearchEquInfo(string strEquNO,string strEquName,string strFacID, DataGridViewKJ128 dv,out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                //ds = dbacc.GetDataSet(strSql);
                ds = cemdal.N_GetEquInfo(strEquNO, strEquName, strFacID);

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

        #region [ 方法: 查询厂家信息 ]

        public bool N_SearchFactoryInfo(string strFacNO, string strFacID, DataGridViewKJ128 dv,out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = cemdal.N_GetFactoryInfo(strFacNO, strFacID);

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

        /*
         * 内部调用
         */ 

        #region [ 方法: 给ComboBox控件加载厂家名称 ]

        private void N_LoadFactoryName(ComboBox cmbFactoryName)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["FactoryID"].ToString(), dr["FactoryName"].ToString()));
            }

            cmbFactoryName.DataSource = mylist;
            cmbFactoryName.DisplayMember = "Value";
            cmbFactoryName.ValueMember = "Key";
            cmbFactoryName.SelectedIndex = 0;
        }

        #endregion

        #region [ 方法: 获取厂家名称基本信息 ]

        private DataSet N_GetFactoryName()
        {
            return cemdal.N_GetFactoryName();
        }

        #endregion
    }
}
