using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class RTClassifyDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();
        
        string strSql = string.Empty;

        #endregion 

        /*
         * 方法
         */ 

        #region [ 方法: 获取部门信息 ]

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="intUserType">查询类型,0:人员;1:设备;</param>
        /// <returns></returns>
        public DataSet N_GetDeptInfo(int intUserType)
        {
            if (intUserType.Equals(0))
            {
                strSql = " Select " +
                            " Di.DeptID, " +
                            " Di.ParentDeptID, " +
                            " Di.DeptName, " +
                            " ( " +
                            " Select Count(*) From " +
                            " ( " +
                            " Select Distinct Cs.UserID From RT_InOutMine As Ri left join CodeSender_Set as Cs on Cs.CsSetID=Ri.CsSetID " +
                            " Left Join Emp_NowCompany As En On En.DeptID = Di.DeptID Left Join Emp_Info As Ei On Ei.EmpID = En.EmpID  " +
                            " Where Cs.UserID = Ei.EmpID And Cs.CsTypeID = 0 " +
                            " ) " +
                            " As T1 " +
                            " ) " +
                            " As Counts  " +
                        " From Dept_Info As Di " +
                        " Order By DeptLevelID ";
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取工种信息 ]

        /// <summary>
        /// 获取工种信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetWorkTypeInfo()
        {
            strSql = " Select " +
                        " Count( Distinct CodeSenderAddress) as Counts," +
                        " case When WtName is null then '未配置' else WtName end 'WtName' " +
                      " From " +
                        " ( Select Wi.WorkTypeID,Wi.WtName,rti.CodeSenderAddress From RT_InOutMine as rti " +
                        " left join CodeSender_Set as css on rti.CodeSenderAddress=css.CodeSenderAddress " +
                        " left join Emp_WorkType as ewt on css.UserID=ewt.EmpID and css.CsTypeID=0 And ewt.IsEnable=1 " +
                        " left join WorkType_Info as wi on ewt.WorkTypeID=wi.WorkTypeID " +
                        " Where css.CsTypeID=0" +
                        " ) as A" +
                      " group by WorkTypeID,WtName ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取职务信息 ]

        /// <summary>
        /// 获取职务信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetBusinessInfo()
        {
            strSql = " Select " +
                        " Count( DISTINCT CodeSenderAddress) as Counts , " +
                        " case when DutyName is null then '未配置' else DutyName end 'DutyName' " +
                     " From  " +
                        " ( Select di.DutyID,di.DutyName,rti.CodeSenderAddress From RT_InOutMine as rti " +
                        " left join CodeSender_Set as css on rti.CodeSenderAddress=css.CodeSenderAddress " +
                        " left join Emp_NowCompany as enc on css.UserID = enc.EmpID " +
                        " left join Duty_Info as di on enc.DutyID=di.DutyID  " +
                        " where css.CsTypeID=0 " +
                        " ) as A " +
                     " group by DutyID,DutyName ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取职务等级信息 ]

        /// <summary>
        /// 获取职务等级信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetBusLevelInfo()
        {
            strSql = " Select " +
                        " Count( Distinct CodeSenderAddress) as Counts, " +
                        " case when Title is null then '未配置' else Title end 'Title' " +
                     " From " +
                        " ( select et.Title,et.EnumID ,rti.CodeSenderAddress  From RT_InOutMine as rti " +
                        " left join CodeSender_Set as css on rti.CodeSenderAddress=css.CodeSenderAddress " +
                        " left join Emp_NowCompany as enc on css.UserID = enc.EmpID " +
                        " left join Duty_Info as di on enc.DutyID=di.DutyID  " +
                        " left join EnumTable as et on et.EnumID=di.DutyClassID and et.FunID=4 " +
                        " where css.CsTypeID=0 " +
                        " ) as A " +
                     " group by EnumID,Title ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取方向性信息 ]

        /// <summary>
        /// 获取方向性信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetDirectionalInfo()
        {
            string procName = "KJ128N_RTDirectional_Select";
            SqlParameter[] sqlParmeters ={
                            new SqlParameter("sumType",SqlDbType.Int)
            };
            sqlParmeters[0].Value = 0;

            return dbacc.GetDataSet(procName, sqlParmeters);
        }
        #endregion

        #region [ 方法: 获取区域信息 ]

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns></returns>
        public DataSet N_GetTerritorialInfo()
        {
            //string procName = "KJ128N_RTTerritorial_Select";
            //SqlParameter[] sqlParmeters ={
            //                new SqlParameter("sumType",SqlDbType.Int)
            //};
            //sqlParmeters[0].Value = 0;

            string sqlText = "select TeT.TerritorialTypeID,TeT.TypeName, "
                            + "("
                            + " Select Count(1) From dbo.RT_TerritorialInfo as RT_Ti left join dbo.Territorial_Info as Tei on RT_Ti.TerritorialID=Tei.TerritorialID "
                            + " where Tei.TerritorialTypeID =TeT.TerritorialTypeID and RT_Ti.CsTypeID=0 "
                            + " ) as Counts "
                             + " From dbo.Territorial_Type as TeT "

                            + " select Tei.TerritorialID,Tei.TerritorialName,Tei.TerritorialTypeID, "
                            + "("
                            + " Select Count(*) From dbo.RT_TerritorialInfo as RT_Ti where RT_Ti.TerritorialID =Tei.TerritorialID and RT_Ti.CsTypeID=0 "
                            + " ) as Counts "
                            + " From dbo.Territorial_Info as Tei";

            return dbacc.GetDataSet(sqlText);
        }

        #endregion
    }
}
