using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class RealtimeStationBreakDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        #region [ 方法: 查询 实时分站信息 ]

        /// <summary>
        /// 查询 实时分站信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_StaBreakInfo(string strState)
        {
            strSql = " Select * From KJ128N_RTStation_Info_View ";
            if (!(strState == "" | strState.Equals("所有") | strState.Equals(null)))
            {
                strSql += " Where 分站状态='" + strState + "' ";
            }
            strSql += " Order By  分站地址 ";

            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
