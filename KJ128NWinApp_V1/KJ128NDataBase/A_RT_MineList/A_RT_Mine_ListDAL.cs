using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase.A_RT_MineList
{
    public class A_RT_Mine_ListDAL
    {
        DBAcess db = new DBAcess();
        public DataTable DutyTree()
        {

            DataTable dt = db.GetDataSet("select 0 ID ,'所有' Name ,-1 ParentID ,'False' IsChild ,'True' IsUserNum ,0 Num union all select t.DutyID ID,t.DutyName Name,0 ParentID,'True' IsChild,'True' IsUserNum,(select count(*)from dbo.view_RT_InOutMineEmpNameList where 职务ID=t.DutyID) Num from dbo.Duty_Info as t union all select -2 ID,'未配置' Name,0 ParentID,'True' IsChild,'True' IsUserNum,(select count(*)from dbo.view_RT_InOutMineEmpNameList where 职务ID is null or 职务ID=0) Num ").Tables[0];
            return dt;
        }
        public DataTable Get_Mine_EmpList(string strwhere)
        {
            string sql = "select * from dbo.view_RT_InOutMineEmpNameList where " + strwhere;
            return db.GetDataSet(sql).Tables[0];
        }

        public DataTable Get_Mine_Panel(string EmpID)
        {
            string sql = "select cs.CodeSenderAddress 标识卡, em.EmpName 姓名,em.DeptName 部门, " +
                            "em.DutyName 职务,rt.stationheadtime 时间, " +
                            "sh.StationHeadPlace 地址,em.Photo pic  from dbo.Emp_Info as em " +
                            " left join dbo.CodeSender_Set as cs on em.EmpID=cs.UserID  " +
                            "left join dbo.RT_InStationHeadInfo as rt on cs.CodeSenderAddress=rt.CodeSenderAddress " +
                            " left join dbo.Station_Head_Info as sh " +
                            " on rt.stationheadid=sh.stationheadid " +
                            "where cs.CsTypeID=0 and em.EmpID=" + EmpID;
            return db.GetDataSet(sql).Tables[0];
        }



        #region 【czlt-2014-01-14 修改实时下井人员名单】
        /// <summary>
        /// 默认部门树
        /// </summary>
        /// <returns></returns>
        public DataSet DeptTree()
        {
            return db.GetDataSet(" exec Czlt_HN_DeptTree1 ");

        }

        /// <summary>
        /// 默认分站类型
        /// </summary>
        /// <param name="staType"></param>
        /// <returns></returns>
        public DataSet StaTree()
        {
            DataSet ds = new DataSet();
            ds = db.GetDataSet(" exec  Czlt_HN_StaTree1 ");
            return ds;
        }

        /// <summary>
        /// 根据ID 查询部门下面的所有子部门
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public DataSet GetDetpLevId(string strID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] czltParmeters = {
                                                new SqlParameter("@deptID",SqlDbType.Int),
                            
                };
            czltParmeters[0].Value = Convert.ToInt32(strID);
            ds = db.GetDataSet("Proc_GetLevelDeptID", czltParmeters);
            return ds;

        }
        #endregion

    }
}
