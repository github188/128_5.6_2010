using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using KJ128A.Controls;

namespace KJ128A.Batman
{
    class GetTwoMessage
    {
        GetCardInfo getCardInfo = new GetCardInfo();

        #region 【方法：获取传输分站信息】
        /// <summary>
        /// 获取传输分站信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStn()
        {

            return getCardInfo.ExecSql("select 0 StationAddress,'传输分站' StationPlace union all select StationAddress ,convert(nvarchar(20),StationAddress)+'号 '+convert(nvarchar(50),StationPlace) as StationPlace from  Station_Info where StationModel = 1").Tables[0];

        }
        #endregion


        #region 【方法：获取读卡分站信息】
        /// <summary>
        /// 获取读卡分站信息
        /// </summary>
        /// <param name="iStnNO"></param>
        /// <returns></returns>
        public DataTable GetStnHead(int iStnNO)
        {

            return getCardInfo.ExecSql("select 0 StationHeadAddress,'读卡分站' StationHeadPlace union all select StationHeadAddress ,convert(nvarchar(20),StationHeadAddress)+'号 '+convert(nvarchar(50),StationHeadPlace) as StationHeadPlace from  Station_Head_Info where StationHeadTypeID=32 and StationAddress=" + iStnNO).Tables[0];

        }
        #endregion


        #region 【方法：获取员工姓名】
        /// <summary>
        /// 获取员工姓名
        /// </summary>
        /// <param name="iStnNO">标识卡号</param>
        /// <returns></returns>
        public DataTable GetEnpNameByCard(int iCardNO)
        {
            string str = string.Format("select EmpName from Emp_Info left join CodeSender_Set on Emp_Info.EmpID=CodeSender_Set.UserID where CodeSenderAddress= {0} ", iCardNO);
            return getCardInfo.ExecSql(str).Tables[0];

        }
        #endregion

    }
}
