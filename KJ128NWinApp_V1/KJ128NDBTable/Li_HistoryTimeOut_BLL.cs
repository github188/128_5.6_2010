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
    public class Li_HistoryTimeOut_BLL
    {

        //调用此BLL的窗体，已被废弃
        private DataSet ds;
        private string strSql = string.Empty;

        #region [ 方法: 查询历史超时记录 ]
        /// <summary>
        /// 查询历史超时记录
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strCard">发码器</param>
        /// <param name="dv">所要绑定的 DataGridView</param>
        /// <returns></returns>
        public bool SearchHisTimeOut(
            string strStartTime, 
            string strEndTime, 
            string strCard,
            DataGridViewKJ128 dv)
        {
            if (DateTime.Compare(DateTime.Parse(strStartTime), DateTime.Parse(strEndTime)) > 0)
            {
                MessageBox.Show("对不起, 开始时间不能大于结束时间！");
                return false;
            }

            strSql = " Select " +
                     " Hi.CodeSenderAddress As "+HardwareName.Value(CorpsName.CodeSender)+", " +
                     " Ei.EmpName As 名称, " +
                     " Di.DeptName As 部门, " +
                     " Hi.InMineTime As 下井时间, " +
                     " Hi.DelayedStartTime As 超时开始时间, " +
                     " Hi.DelayedEndTime As 超时结束时间, " +
                     " Hi.DelayedTime As 超时持续时间 " +
                     " From His_OverTimeAlarm As Hi " +
                     " Left Join Emp_Info As Ei On Ei.EmpID = Hi.UserID " +
                     " Left Join Emp_NowCompany As En On En.EmpID = Ei.EmpID " +
                     " Left Join Dept_Info As Di On Di.DeptID = En.DeptID " +
                     " Where Hi.CsTypeID = 1 And Hi.InMineTime >= '" + strStartTime + "' And Hi.InMineTime <= '" + strEndTime + "' ";

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And Hi.CodeSenderAddress = " + strCard;
            }

            strSql += " Union " +
                     " Select " +
                     " Hi.CodeSenderAddress As " + HardwareName.Value(CorpsName.CodeSender) + ", " +
                     " Eb.EquName As 名称, " +
                     " Di.DeptName As 部门, " +
                     " Hi.InMineTime As 下井时间, " +
                     " Hi.DelayedStartTime As 超时开始时间, " +
                     " Hi.DelayedEndTime As 超时结束时间, " +
                     " Hi.DelayedTime As 超时持续时间 " +
                     " From His_OverTimeAlarm As Hi " +
                     " Left Join Equ_BaseInfo As Eb On Eb.EquID = Hi.UserID " +
                     " Left Join Dept_Info As Di On Di.DeptID = Eb.DeptID " +
                     " Where Hi.CsTypeID = 2 And Hi.InMineTime >= '" + strStartTime + "' And Hi.InMineTime <= '" + strEndTime + "' ";

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And Hi.CodeSenderAddress = " + strCard;
            }

            return true;
        }
        #endregion
    }
}
