using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_RTAlarmDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private string strSQL;

        #endregion

        #region【方法：获取部门信息（树）——实时超时】

        public DataSet GetDeptTree_EmpOverTime()
        {
            strSQL = " Select * From A_DeptTree_RTEmpOverTime ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询实时超时报警】

        public DataSet Select_EmpOverTime(string strWhere)
        {
            //Czlt-2010-9-21-实时超时加入入井时间
            strSQL = " Select 标识卡号,姓名,部门,职务,工种,InTime as 入井时间,开始时间,持续时长 From A_Alarm_RTEmpOverTime join RT_InOutMine on  A_Alarm_RTEmpOverTime.标识卡号=RT_InOutMine.CodeSenderAddress where " + strWhere;
            //Czlt-2010-9-21-注销代码
            //strSQL = " Select * From A_Alarm_RTEmpOverTime Where " + strWhere;
           
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region[区域超时]
        public DataSet Selelct_Ter_count()
        {
            strSQL = "select count(*) from dbo.RT_Terr_OverTime";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region[方法：查询区域超时]
        public DataSet Select_TerEmpOverTime(string str)
        {
            strSQL = "select rt.CodeSenderAddress 标识卡,rt.EmpName 姓名,em.DeptName 部门,em.DutyName 职务,em.workTypeName 工种,rt.TerritorialName 区域名称,rt.TerritorialTypeName 区域类型,rt.StartOverTime 开始时间, dbo.FunConvertTime(datediff(ss,rt.StartOverTime,getdate()))持续时长 from dbo.RT_Terr_OverTime as rt join dbo.CodeSender_Set as cs on rt.CodeSenderAddress=cs.CodeSenderAddress join dbo.Emp_Info as em on cs.UserID=em.EmpID  " + str;
                //+ " select count(distinct rt.CodeSenderAddress)  from dbo.RT_Terr_OverTime as rt left join dbo.CodeSender_Set as cs on rt.CodeSenderAddress=cs.CodeSenderAddress left join dbo.Emp_NowCompany as em on cs.UserID=em.EmpID left join dbo.Dept_Info as de on em.DeptID=de.DeptID left join dbo.Duty_Info as du on em.DutyID=du.DutyID where cs.CsTypeID=0 " + str;
            return dba.GetDataSet(strSQL);
        }
        #endregion


        #region [ 方法: 查询求救信息的总数 ]

        public string GetEmpHelpCounts()
        {
            strSQL = " Select Count(1) as Counts From RT_EmpHelp ";

            return dba.ExecuteScalarSql(strSQL);
        }

        #endregion

        #region【方法：查询超时】

        public DataSet OverTimeAlarm()
        {
            strSQL = " Select count(1) From RT_OverTimeInfo_View ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：判断区域报警】

        public DataSet TerAlarm()
        {
            strSQL = " Select count(1) From A_Alarm_Territorial ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：判断分站报警】

        public DataSet StationAlarm()
        {
            strSQL = " Select count(*) From Station_Info Where StationState=-1000 ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：判断超员报警】

        public DataSet OverEmpCountAlarm()
        {
            strSQL = " Select count(1) From RTOverEmployees ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：下井总人数】

        public DataSet RTInOutMineEmpCount()
        {
            strSQL = " Select count(*) From RT_InOutMine as Ri left join CodeSender_Set as Cs on Cs.CsSetID=Ri.CsSetID Where CsTypeID=0 ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：判断低电量报警】

        public DataSet ElectricityAlarm()
        {
            string procName = "KJ128N_CodeAlarmElectricity_Select";

            SqlParameter[] sqlParmeters ={
                new SqlParameter("CodeSenderStateID",SqlDbType.Int)
            };

            sqlParmeters[0].Value = 4;

            return dba.GetDataSet(procName, sqlParmeters);

        }

        #endregion

        #region【方法：判断接收器故障报警】
        
        public DataSet StaHeadAlarm()
        {
            strSQL = " Select Count(1) From A_Alarm_StationHeadBreak ";
           return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：判断路线报警】

        public DataSet PathAlarm()
        {
            strSQL = " Select Count(1) From RealTimeAlarmPathInfo";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：判断超速报警】

        public DataSet OverSpeedAlarm()
        {
            strSQL = " Select Count(1) From A_Alarm_RTOverSpeed";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：判断欠速报警】

        public DataSet LackSpeedAlarm()
        {
            strSQL = " Select Count(1) From A_Alarm_RTLackSpeed";
            return dba.GetDataSet(strSQL);
        }

        #endregion


        #region【方法：判断区域超员报警】

        public DataSet TerOverEmpAlarm()
        {
            strSQL = " Select Count(1) From A_Alarm_RTTerOverEmp";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法：判断异地交接班报警】
        public DataSet AssociateAlarm()
        {
            strSQL = "select count(1) from AssociateAlertView";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region 【方法：判断唯一性报警】
        public DataSet CheckCardsAlarm()
        {
            strSQL = "select count(1) from A_Alarm_RTCheckCards";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region 【方法：判断下井人员验证】
        public DataSet InWellValidateAlarm()
        {
            strSQL = "select count(1) from InWellValidate";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region【方法：获取报警路径】

        public DataSet LoadAlarmPath(int intType)
        {
            strSQL = " Select AlarmWaveType,AlarmWavePath From AlarmSet Where AlarmSetType=" + intType.ToString();
            return dba.GetDataSet(strSQL);
        }
        
        #endregion

        #region 【方法: 查询实时超员信息】

        /// <summary>
        /// 查询实时超员信息
        /// </summary>
        /// <param name="intOverEmpType">超员类别,1:超员;2:欠员</param>
        /// <returns></returns>
        public DataSet Select_OverEmp(int intOverEmpType)
        {
            //strSQL = " Select " +
            //           " RT_RatingEmployeesCount as 额定下井人数 , " +
            //           " RT_FactEmployeeCount as 当前下井人数, " +
            //           " RT_FactEmployeeCount-RT_RatingEmployeesCount as 超员人数, " +
            //           " RT_OverEmployeeBeginTime as 开始时间, " +
            //           " dbo.FunConvertTime((Select DateDiff(ss, Ro.RT_OverEmployeeBeginTime, getDate()))) As 持续时长" +
            //        " From " +
            //           " RT_OverEmployees as Ro" +
            //        " Where " +
            //           " Ro.RT_OverEmployeeTypeID = " + intOverEmpType.ToString();
            strSQL = "select begintime as 开始时间, ratingempcount as 额定下井人数,"+
                        "realtimeempcount as 实时超员人数,maxempcount as 最大超员人数,maxemptime as 最大超员人数时间   from RTOverEmployees";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法：查询实时异地交接班报警信息】
        /// <summary>
        /// 查询实时异地交接班报警信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Select_Associate(string strWhere)
        {
            strSQL = "select beginTime as 开始时间,endTime as 结束时间,stationAddress as 传输分站号,stationHeadAddress as 读卡分站号,stationHeadPlace as 交接地点,empName1 as 人员姓名1,isFlagEmp1 as 人员1交接状态,empName2 as 人员姓名2,isFlagEmp2 as 人员2交接状态 from AssociateAlertView where "+strWhere;
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region [ 方法: 存储超员报警人数 ]

        public int SaveEmpCount(string strEmpCount)
        {
            strSQL = " UpDate EnumTable Set EnumValue='" + strEmpCount + "' Where FunID=8 and EnumID=1";
            return dba.ExecuteSql(strSQL);
        }

        #endregion

        #region【方法：判断是否超员】

        public bool IsOverEmp()
        {
            try
            {
                dba.ExecuteSql("zjw_OverEmpInWell", new SqlParameter[0]);
                dba.ExecuteSql("zjw_OverEmpOutWell", new SqlParameter[0]);
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region【方法：加载超员人数】

        public DataSet GetEmpCount()
        {
            strSQL = " Select EnumValue From EnumTable Where FunID=8 And EnumID=1";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取区域信息（树）——实时区域】

        public DataSet GetDeptTree_Territorial()
        {
            strSQL = " Select * From A_AlarmTree_Territorial ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询实时区域报警】

        public DataSet Select_Territorial(string strWhere)
        {
            strSQL = " Select * From A_Alarm_Territorial Where " + strWhere;
            //strSQL += " Select DISTINCT(标识卡号) From A_Alarm_Territorial Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取传输分站信息（树）——实时传输分站】

        public DataSet GetTree_Station()
        {
            strSQL = " Select StationAddress as ID, " +
                        " StationPlace as Name, " +
                        " '0' as ParentID, " +
                        " 'true' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num " +
                     " From Station_Info " +
                     " Where StationState = -1000 ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询实时传输分站故障信息】

        public DataSet Select_Station(string strWhere)
        {
            //Czlt-2012-3-28 注销
            //strSQL = " Select StationAddress as 分站编号,StationPlace as 分站位置,StationTel as 分站联系电话,BreakTime as 故障开始时间 " +
            //         " From Station_Info " +
            //         " Where StationState = -1000 And " + strWhere;

            //Czlt-2012-3-28 -去掉分站联系电话
            strSQL = " Select StationAddress as 分站编号,StationPlace as 分站位置,BreakTime as 故障开始时间 " +
                   " From Station_Info " +
                   " Where StationState = -1000 And " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取读卡分站信息（树）——实时读卡分站】

        public DataSet GetTree_StationHead()
        {
            strSQL = " Select * From A_AlarmTree_StationHeadBreak ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询实时读卡分站故障信息】

        public DataSet Select_StationHead(string strWhere)
        {
            strSQL = " Select *  From A_Alarm_StationHeadBreak  Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：查询实时低电量信息】

        public DataSet Select_Electricity(string strWhere)
        {
            strSQL = " Select  * From A_Alarm_Electricity Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门信息（树）——工作异常】

        public DataSet GetDeptTree_Path()
        {
            strSQL = " Select * From A_AlarmTree_Path ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询工作异常信息】

        public DataSet Select_Path(string strWhere)
        {
            strSQL = " Select * From A_Alarm_Path Where " + strWhere;
            //strSQL += " Select DISTINCT(标识卡号) From A_Alarm_Path Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门信息（树）——超速】

        public DataSet GetDeptTree_OverSpeed()
        {
            strSQL = " Select * From A_DeptTree_RTOverSpeed ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询超速报警】

        public DataSet Select_OverSpeed(string strWhere)
        {
            strSQL = " Select * From A_Alarm_RTOverSpeed Where " + strWhere;
            //strSQL += " Select DISTINCT(标识卡号) From A_Alarm_RTOverSpeed Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门信息（树）——超速】

        public DataSet GetDeptTree_LackSpeed()
        {
            strSQL = " Select * From A_DeptTree_RTLackSpeed ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询超速报警】

        public DataSet Select_LackSpeed(string strWhere)
        {
            strSQL = " Select * From A_Alarm_RTLackSpeed Where " + strWhere;
            //strSQL += " Select DISTINCT(标识卡号) From A_Alarm_RTLackSpeed Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        public DataSet Select_InWellValidate(string strWhere)
        {
            strSQL = " Select * From InWellValidate Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #region【方法：获取部门信息（树）——求救】

        public DataSet GetDeptTree_EmpHelp()
        {
            strSQL = " Select * From A_DeptTree_RTEmpHelp ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法：获取部门信息（树）--人员下井验证】
        public DataSet GetDeptTree_InWellValidate()
        {
            strSQL = " Select * From DeptTree_InWellValidate ";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region 【方法: 查询求救报警】

        public DataSet Select_EmpHelp(string strWhere)
        {
            string sql = "select CodeSenderAddress from RT_EmpHelp where RT_EmpHelp.EmpID not in (select UserID from RT_InOutMine,CodeSender_Set where RT_InOutMine.CsSetID = CodeSender_Set.CsSetID) ";
            DataSet ds = dba.GetDataSet(sql);
            if (ds != null & ds.Tables[0] != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    SqlParameter[] sqlParmeters ={
                                                        new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                                        new SqlParameter("EndTime",SqlDbType.DateTime),
                                                        new SqlParameter("Measure",SqlDbType.NVarChar,200)
                                                 };
                    sqlParmeters[0].Value = Convert.ToInt32(dr[0]);
                    sqlParmeters[1].Value = DateTime.Now;
                    sqlParmeters[2].Value = "上井自动解除";

                    dba.ExecuteSql("A_RT_EmpHelp_Delete", sqlParmeters);
                }
            }
       
            
            strSQL = " Select * From A_Alarm_RTEmpHelp Where " + strWhere;
            //strSQL += " Select DISTINCT(标识卡号) From A_Alarm_RTEmpHelp Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法：获取部门信息（树）--唯一性】
        public DataSet GetDeptTree_CheckCards()
        {
            strSQL = " Select * From A_DeptTree_RTCheckCards ";
            return dba.GetDataSet(strSQL);
        }
        #endregion

        #region 【方法: 查询唯一性报警】

        public DataSet Select_OnlyOne(string strWhere)
        {
            strSQL = " Select * From A_Alarm_RTCheckCards Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：完成求救信息】

        public int DeleteRTEmpHelp(string strCodeSenderAddress, string strMeasure)
        {
            SqlParameter[] sqlParmeters ={
                new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                new SqlParameter("EndTime",SqlDbType.DateTime),
                new SqlParameter("Measure",SqlDbType.NVarChar,200)
            };
            sqlParmeters[0].Value = strCodeSenderAddress;
            sqlParmeters[1].Value = DateTime.Now;
            sqlParmeters[2].Value = strMeasure;

            return dba.ExecuteSql("A_RT_EmpHelp_Delete", sqlParmeters);

        }

        #endregion

        #region 【方法：解除唯一性报警信息】
        public int UnChainOnlyone(string strCodeSenderAddress,string strName)
        {
            SqlParameter[] sqlParmeters ={
                                             new SqlParameter("CodeSenderAddress",SqlDbType.Int),
                                             new SqlParameter("UserName",SqlDbType.VarChar,20),
                                             new SqlParameter("EndTime",SqlDbType.DateTime)
                                        };
            sqlParmeters[0].Value = strCodeSenderAddress;
            sqlParmeters[1].Value = strName;
            sqlParmeters[2].Value = DateTime.Now;

            return dba.ExecuteSql("UnChainOnlyone", sqlParmeters);
        }
        #endregion

        #region 【方法: 查询区域超员信息】

        /// <summary>
        /// 查询区域超员信息
        /// </summary>
        /// <returns></returns>
        public DataSet Select_TerOverEmp()
        {
            strSQL = " Select * From A_Alarm_RTTerOverEmp";
            return dba.GetDataSet(strSQL);
        }

        #endregion


        #region【方法：获取是否启用该报警】

        public DataSet IsEnableAlarm(int intAlarm)
        {
            strSQL = " Select EnumValue From EnumTable where FunID=12 And EnumID = " + intAlarm.ToString();
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【Czlt-2011-05-25 交直流供电】
        /// <summary>
        /// 得到分站直流供电信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetTree_StaEle()
        {
            strSQL = " Select StationAddress as ID,  StationPlace as Name,  '0' as ParentID, 'true' as IsChild , 'false' as IsUserNum ,  0 as Num From Station_Info  Where stationVersion = 2 ";
            return dba.GetDataSet(strSQL);
        }

        /// <summary>
        /// 得到交换机的交直流供电情况
        /// </summary>
        /// <returns></returns>
        public DataSet GetTree_JHHEle()
        {
            strSQL = "Select distinct IpId as ID,  Place as Name,  '0' as ParentID, 'true' as IsChild , 'false' as IsUserNum ,  0 as Num From TcpIPConfig ti left join  dbo.station_info si on si.IPAddressID = ti.IPid  Where remark = 2";
            return dba.GetDataSet(strSQL);
        }

        /// <summary>
        /// 查询分站供电状态的信息
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataSet GetStationEle(string strwhere)
        {
            strSQL = "select  StationAddress as 传输分站编号,StationPlace as 安装位置,StationGroup as 分组编号,传输协议 = case StationModel  when 1 then 'A版协议'  when 2 then 'V2版协议' when 3 then '检卡协议' end, 供电状态 = case stationVersion  when 1 then '未初始化' when 2 then '直流供电' when 3 then '交流供电' end,BreakTime as 开始时间 from Station_Info where StationVersion = 2  and " + strwhere;
            return dba.GetDataSet(strSQL);
        }

        /// <summary>
        /// 查询交换机供电情况
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetJHJEle(string strWhere, int type)
        {
            if (type == 0)
            {
                strSQL = " select IP地址,端口号, 安装位置,分组编号,供电状态,max(开始时间) 开始时间  from  ( select IPaddress IP地址,IPPort 端口号,Place 安装位置,StationGroup 分组编号,供电状态 = case remark  when 1 then '未初始化' when 2 then '直流供电' when 3 then '交流供电' end, BreakTime as 开始时间  from dbo.TcpIPConfig ti left join station_info si on ti.IPid = si.IPAddressID where remark=2 and " + strWhere + " ) rr group by IP地址,端口号, 安装位置,分组编号,供电状态 ";
            }
            else
            {
                strSQL = "select top(1) IPaddress IP地址,IPPort 端口号,Place 安装位置,StationGroup 分组编号,供电状态 = case remark  when 1 then '未初始化' when 2 then '直流供电' when 3 then '交流供电' end, BreakTime as 开始时间  from dbo.TcpIPConfig ti left join station_info si on ti.IPid = si.IPAddressID where remark=2 and " + strWhere;

            }
            return dba.GetDataSet(strSQL);
        }

        /// <summary>
        /// 判断传输分站是否报警
        /// </summary>
        /// <returns></returns>
        public DataTable StationEleAlarm()
        {
            strSQL = " Select count(*) From Station_Info Where StationVersion = 2 ";
            DataSet ds = dba.GetDataSet(strSQL);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 判断交换机是否报警
        /// </summary>
        /// <returns></returns>
        public DataTable JHJEleAlarm()
        {
            strSQL = " Select count(*) From Station_Info Where remark = 2 ";
            DataSet ds = dba.GetDataSet(strSQL);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion


        #region 【Czlt-2011-12-10 监测配置文件被修改的日期】
        /// <summary>
        /// Czlt-2011-12-10 监测配置文件被修改的日期
        /// </summary>
        /// <returns></returns>
        public string Select_Change()
        {
            try
            {
                strSQL = " select changeTime from CzltChangeTable ";
                if (dba.GetDataSet(strSQL) != null)
                {
                   return dba.GetDataSet(strSQL).Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }
                 


            }
            catch 
            {
                return "";
            }

        }
        #endregion

        #region 【Czlt-2012-01-12 生成历史四种历史表】
        /// <summary>
        ///  生成历史四种历史表
        /// </summary>
        /// <param name="iYear">年</param>
        /// <param name="iMonth">月</param>
        /// <returns></returns>
        public int CzltCreateHisTable(int iYear, int iMonth)
        {
            SqlParameter[] sqlParmeters ={
                                             new SqlParameter("@year",SqlDbType.Int),
                                             new SqlParameter("@month",SqlDbType.Int)
                                             
                                        };
            sqlParmeters[0].Value = iYear;
            sqlParmeters[1].Value = iMonth;


            return dba.ExecuteSql("Czlt_CreateHistoryDataTable", sqlParmeters);
        }
        #endregion
    }
}
