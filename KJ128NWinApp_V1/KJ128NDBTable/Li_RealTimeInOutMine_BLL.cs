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
    public class Li_RealTimeInOutMine_BLL
    {
        //没有任何窗体调用此BLL

        private DBAcess dbacc;
        private DataSet ds;
        private string strSql = string.Empty;

        public Li_RealTimeInOutMine_BLL()
        {
            dbacc = new DBAcess();
        }

        #region 获取实时超时信息
        private DataSet GetRtInOutMine()
        {
            strSql = " Select " +
                     " CodeSenderAddress As 发码器, " +
                     " '人员' As 配置类型, " +
                     " Ei.EmpName As 使用者名称, " +
                     " Ri.InTime As 下井时间, " +
                     " Ri.DelayedStartTime As 超时开始时间, " +
                     " DateDiff(ss, Ri.DelayedStartTime, getDate()) As 超时持续时间 " +
                     " From Rt_InOutMine As Ri " +
                     " Left Join Emp_Info As Ei On Ei.EmpID = Ri.UserID " +
                     " Left Join CodeSender_Set As Cs On Cs.CsSetID = Ri.CsSetID " +
                     " Where Ri.CsTypeID = 1 And IsTimeOut = 1 " +
                     " Union " +
                     " Select " +
                     " CodeSenderAddress As 发码器, " +
                     " '设备' As 配置类型, " +
                     " Eb.EquName As 使用者名称, " +
                     " Ri.InTime As 下井时间, " +
                     " Ri.DelayedStartTime As 超时开始时间, " +
                     " DateDiff(ss, Ri.DelayedStartTime, getDate()) As 超时持续时间 " +
                     " From Rt_InOutMine As Ri " +
                     " Left Join Equ_BaseInfo As Eb On Eb.EquID = Ri.UserID " +
                     " Left Join CodeSender_Set As Cs On Cs.CsSetID = Ri.CsSetID " +
                     " Where Ri.CsTypeID = 2 And IsTimeOut = 1 ";

            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region 查询实时超时信息
        /// <summary>
        /// 查询实时超时信息
        /// </summary>
        /// <param name="dv">要显示的DataGridView</param>
        /// <returns></returns>
        public bool SearchRtInOutMine(DataGridViewKJ128 dv)
        {
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = GetRtInOutMine();
                dv.DataSource = ds.Tables[0].DefaultView;
            }

            return true;
        }
        #endregion
    }
}
