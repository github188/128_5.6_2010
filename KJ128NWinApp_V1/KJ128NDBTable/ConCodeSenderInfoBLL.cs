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
    public class ConCodeSenderInfoBLL
    {

        #region [ 声明 ]

        private DataSet ds;

        private ConCodeSenderInfoDAL ccsdal = new ConCodeSenderInfoDAL();

        #endregion


        #region [ 方法: 加载发码器状态 ]

        /// <summary>
        /// 加载 发码器状态
        /// </summary>
        /// <param name="cmbCsTypeName">发码器状态ComboBox</param>
        /// <returns>true 成功</returns>
        public bool N_LoadInfo(ComboBox cmbCsTypeName)
        {
            using (ds = new DataSet())
            {
                ds = ccsdal.N_GetCsTypeName();
                this.N_LoadCsTypeName(cmbCsTypeName);
            }
            return true;
        }

        #region 给 ComboBox 控件加载 发码器状态

        /// <summary>
        /// 给 ComboBox 控件加载 发码器状态
        /// </summary>
        /// <param name="cmbCsTypeName"></param>
        private void N_LoadCsTypeName(ComboBox cmbCsTypeName)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(new DictionaryEntry("0", "所有"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                mylist.Add(new DictionaryEntry(dr["EnumID"].ToString(), dr["Title"].ToString()));
            }

            cmbCsTypeName.DataSource = mylist;
            cmbCsTypeName.DisplayMember = "Value";
            cmbCsTypeName.ValueMember = "Key";
            cmbCsTypeName.SelectedIndex = 0;
        }
        #endregion

        //#region 获取 发码器状态 基本信息

        ///// <summary>
        ///// 获取 发码器状态 基本信息
        ///// </summary>
        ///// <returns></returns>
        //private DataSet N_GetCsTypeName()
        //{
        //    strSql = " Select EnumID,Title From EnumTable Where FunID=2 ";
        //    return dbacc.GetDataSet(strSql);
        //}

        //#endregion

        #endregion

        #region [ 方法: 发码器查询 ]

        /// <summary>
        /// 发码器查询
        /// </summary>
        /// <param name="strCodeSender">发码器编号</param>
        /// <param name="strCodeSenderStateID">发码器状态ID</param>
        /// <param name="dv">要绑定的DataGridView</param>
        /// <returns>true 成功，false 不成功</returns>
        public bool N_SearchCodeInfo(string strCodeSender, string strCodeSenderStateID,  DataGridViewKJ128 dv,out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = ccsdal.N_SearchCodeInfo(strCodeSender, strCodeSenderStateID);

                dv.DataSource = ds.Tables[0].DefaultView;
                dv.Columns[0].FillWeight = 40;
                dv.Columns[1].FillWeight = 40;
                dv.Columns[2].FillWeight = 40;
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

                dv.Columns[1].HeaderText = HardwareName.Value(CorpsName.CodeSender) + "状态";
            }
            return true;
        }

        #endregion

        #region [ 方法: 发码器配置查询 ]

        /// <summary>
        /// 发码器配置查询
        /// </summary>
        /// <param name="strCodeSender">发码器地址</param>
        /// <param name="strName">设备或员工的名称</param>
        /// <param name="intUserType">0表示人员，1表示设备，2表示人员和设备</param>
        /// <param name="dv">要绑定的DataGridView</param>
        /// <returns>true 成功，false 不成功</returns>
        public bool N_SearchCodeSetInfo(string strCodeSender, string strName, int intUserType, DataGridViewKJ128 dv,out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = ccsdal.N_SearchCodeSetInfo(strCodeSender, strName, intUserType);

                dv.DataSource = ds.Tables[0].DefaultView;

                
                dv.Columns[0].FillWeight = 50;
                dv.Columns[1].FillWeight = 40;
                dv.Columns[2].FillWeight = 40;
                dv.Columns[3].FillWeight = 50;
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


    }
}
