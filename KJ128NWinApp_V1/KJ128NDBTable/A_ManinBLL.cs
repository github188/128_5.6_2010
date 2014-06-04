using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_MainBLL
    {

        #region【声明】

        private A_MainDAL mdal = new A_MainDAL();

        #endregion

        #region【方法：获取界面刷新时间】

        public DataSet GetRefreshTime()
        {
            return mdal.GetRefreshTime();
        }

        #endregion

        #region【方法：获取热备刷新间隔时间和次数】

        public DataSet GetHostBackRefresh()
        {
            return mdal.GetHostBackRefresh();
        }

        #endregion

        #region【方法：获取下井人数】

        public DataSet GetInWellCount()
        {
            return mdal.GetInWellCount();
        }

        #endregion

        #region【方法：获取是否加载求救界面】

        public DataSet LoadEmpHelp()
        {
            return mdal.LoadEmpHelp();
        }

        #endregion

        public bool IsAlarmWalk()
        {
            return mdal.IsAlarmWalk();
        }

        public bool IsAlarmWork()
        {
            return mdal.IsAlarmWork();
        }

        public void ClearRtInfo()
        {
            mdal.ClearRtInfo();
        }

        public void RepareAttendanceInfo()
        {
            mdal.RepareAttendanceInfo();
            
        }
        public DataTable AutoCodeComplete(string hours)
        {
            return mdal.AutoCodeComplete(hours);
        }

        public DataTable Get_UpStation()
        {
            return mdal.Get_UpStation();
        }
        public int GetCodeState(string CodeSender)
        {
            DataTable dt = mdal.GetCodeState(CodeSender);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0][0]) != 4)
                    return 0;
                else
                    return 1;
            }
            else
            {
                return 0;
            }
        }
        public bool DeleteSql()
        {
            DataSet ds = mdal.DeleteSql();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows[0][0].ToString() != "0")
                return true;
            else
                return false;
        }
        public void DeleteSql1()
        {
            mdal.DeleteSql1();
        }
    }
}
