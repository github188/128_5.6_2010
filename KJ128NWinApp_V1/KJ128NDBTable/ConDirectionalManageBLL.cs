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
    public class ConDirectionalManageBLL
    {

        #region [ 声明 ]

        private DataSet ds;
        
        private ConDirectionalManageDAL cdmdal = new ConDirectionalManageDAL();

        #endregion


        #region [ 方法: 查询方向性配置信息 ]

        public bool N_SearchDirectionalManage(string txtDetection, string strWhere, DataGridViewKJ128 dv,out string strCounts)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = cdmdal.N_SearchDirectionalManage(txtDetection, strWhere);

                dv.DataSource = ds.Tables[0].DefaultView;
                dv.Columns[0].FillWeight = 70;
                dv.Columns[1].FillWeight = 85;
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
