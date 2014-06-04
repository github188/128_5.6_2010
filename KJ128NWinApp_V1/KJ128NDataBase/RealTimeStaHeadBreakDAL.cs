using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class RealTimeStaHeadBreakDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();
        
        private string strSql = string.Empty;

        #endregion

        #region [ 方法: 根据分站状态获取接收器信息 ]

        /// <summary>
        /// 根据分站状态获取接收器信息
        /// </summary>
        /// <param name="strState">分站状态</param>
        /// <returns></returns>
        public DataSet N_GetStaHeadBreakInfo(string strState)
        {
            strSql = " Select * From KJ128N_RTStaHead_Info_View ";
            if (!(strState.Equals("所有") | strState.Equals(null)))
            {
                strSql += " Where 接收器状态='" + strState + "' ";
            }
            strSql += " Order By  分站地址,接收器地址 ";

            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
