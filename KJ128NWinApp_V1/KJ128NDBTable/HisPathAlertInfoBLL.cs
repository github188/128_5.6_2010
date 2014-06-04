using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class HisPathAlertInfoBLL
    {
        private  HisPathAlertInfoDal dal = new HisPathAlertInfoDal();

        public DataTable GetHisPathAlertInfo(string condition)
        {
            if(dal == null)
                dal = new HisPathAlertInfoDal();

            DataTable dt = dal.GetHisPathAlertInfo(condition);
            return dt;
        }

        /// <summary>
        /// 返回执行的行数
        /// </summary>
        /// <param name="Id">要删除的记录Id</param>
        /// <returns>返回的行数</returns>
        public int DeletePathAlertInfo(int Id)
        {
            if (dal == null)
                dal = new HisPathAlertInfoDal();

            int result = dal.DeletePathAlertInfo(Id);
            return result;
        }

    }
}
