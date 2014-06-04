using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using DataBaseHelp;
using System.Xml;
using System.Windows.Forms;

namespace KJ128A.HostBack
{
    #region 【表结构体】
    public struct SqlTableHead
    {
        /// <summary>
        /// 数据表
        /// </summary>
        public string strTable;
        /// <summary>
        /// 列表头
        /// </summary>
        public string strHead;
        /// <summary>
        /// 主键
        /// </summary>
        public string strPK;
        /// <summary>
        /// 表类型  0为配置表 1为实时表 2为历史表单表  3为历史表多表
        /// </summary>
        public int tableType;
        /// <summary>
        /// 日期字段
        /// </summary>
        public string strTime;
        /// <summary>
        /// 配置表时间配置
        /// </summary>
        public DateTime dtimeConfig;
        /// <summary>
        /// 配置文件名称
        /// </summary>
        public string strConfigFile;


        /// <summary>
        /// Czlt-查询结束时间
        /// </summary>
        public string strEndTime;

    }
    #endregion

    public class RBSqlConn
    {
        #region 【自定义参数】
        /// <summary>
        /// 数据连接字符串
        /// </summary>
        string strConnection = "server=.;database=kj128N;uid=sa;pwd=sa;Connection Timeout=20";
        //private readonly string m_ConnectionString_KJ128 = "server=.;database=kj128N;uid=sa;pwd=sa;Connection Timeout=5";

        /// <summary>
        /// 一天历史数据线程对象
        /// </summary>
        Thread tHisOneThread = null;

        /// <summary>
        /// 表信息
        /// </summary>
        private ArrayList sqlTableHeadsAL;
        /// <summary>
        /// 实时表记数
        /// </summary>
        private static int m_realTimeCount = 0;
        /// <summary>
        /// 历史表计数
        /// </summary>
        private static int m_HisCount = 0;
        /// <summary>
        /// 定时器对象
        /// </summary>
        private System.Timers.Timer tCount = new System.Timers.Timer();
        /// <summary>
        /// 配置文件定时控制对象
        /// </summary>
        public System.Timers.Timer tConfig = new System.Timers.Timer();

        /// <summary>
        /// Czlt-2011-12-10 热备天数
        /// </summary>
        private int czltDays = 0;

        private bool m_ConnState;

        /// <summary>
        /// 主备连接状态
        /// </summary>
        public bool ConnState
        {
            set { m_ConnState = value; }
        }

        bool firstFlag = false;

        /// <summary>
        /// Czlt-2011-08-20 双机热备实时更新
        /// </summary>
        private System.Timers.Timer czltRTChange = new System.Timers.Timer();

        /// <summary>
        /// Czlt-2011-08-22 修改定时器
        /// </summary>
        private bool isStopTime = false;
        /// <summary>
        /// Czlt-2011-08-22 修改定时器
        /// </summary>
        public bool IsStopTime
        {
            set { isStopTime = value; }
            get { return isStopTime; }
        }


        /// <summary>
        /// Czlt-2011-12-10 热备天数
        /// </summary>
        public int CzltDays
        {
            set { czltDays = value; }
            get { return czltDays; }
        }





        #endregion

        #region 【构造函数】
        public RBSqlConn()
        {
            sqlTableHeadsAL = SetSqlTableHead();

        }
        #endregion

        #region 【方法：设置Table属性】
        public ArrayList SetSqlTableHead()
        {
            ArrayList al = new ArrayList();
            SqlTableHead sqlTableHead = new SqlTableHead();
            DateTime dtNow = DateTime.Now;

            #region 【配置表】
            #region 【枚举表】
            sqlTableHead.strTable = "EnumTable";
            sqlTableHead.strHead = "ID,FunID,EnumID,Title,IsBase,EnumValue,Remark";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "EnumTable.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【报警选项表】
            sqlTableHead.strTable = "AlarmSet";
            sqlTableHead.strHead = "AlarmSetID,AlarmSetType,AlarmWaveType,AlarmWavePath";
            sqlTableHead.strPK = "AlarmSetID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "AlarmSet.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【权限表】
            #region 【菜单表】
            sqlTableHead.strTable = "menus1";
            sqlTableHead.strHead = "ID,PMenuID,Title,name";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【用户组权限表】
            sqlTableHead.strTable = "UserGroupPower";
            sqlTableHead.strHead = "ID,UGPLevelID,UGPowerName,Remark";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Power.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【用户组配置表】
            sqlTableHead.strTable = "UserGroups";
            sqlTableHead.strHead = "ID,UGName,IsEnable,IsUseEndDate,UseEndDate,UGPowerID,Remark";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Power.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【用户组菜单表】
            sqlTableHead.strTable = "UserGroupMenu1";
            sqlTableHead.strHead = "ID,UserGroupID,MenuID,ISuse,Remark";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Power.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【登录】
            sqlTableHead.strTable = "Admins";
            sqlTableHead.strHead = "ID,Account,Password,IsEnable,IsUseEndDate,UseEndDate,UserGroupID,LoginTotal,CreateID,CreateDate,CreateIP,FlagTag,Style,Remark,Passwordback";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Power.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion
            #endregion

            #region 【TCPIP配置表】
            sqlTableHead.strTable = "TcpIPConfig";
            sqlTableHead.strHead = "IPId,IPAddress,IPPort,PLACE";
            sqlTableHead.strPK = "IPId";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "TCPIP.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【传输分站配置表】
            sqlTableHead.strTable = "Station_Info";
            sqlTableHead.strHead = "StationID,StationAddress,StationPlace,StationTel,StationTypeID,StationType,StationState,BreakTimes,BreakTime,StationX,StationY,EditBaseInfo,StationGroup,StationVersion,Remark,IPAddressID,StationModel";
            sqlTableHead.strPK = "StationAddress";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "StationHead.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【读卡分站配置表】
            sqlTableHead.strTable = "Station_Head_Info";
            sqlTableHead.strHead = "StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace,StationHeadTel,StationHeadTypeID,StationHeadType,StationHeadX,StationHeadY,StationHeadState,EditBaseInfo,AntennaA,AntennaB,AntennaAX,AntennaAY,AntennaBX,AntennaBY,BreakTimes,BreakTime,Remark,StationHeadNO";
            sqlTableHead.strPK = "StationHeadID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "StationHead.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【方法性配置表】
            sqlTableHead.strTable = "CodeSender_DirectionalAntenna";
            sqlTableHead.strHead = "CodeSenderDirlID,DetectionInfo,Directional,Remark,BeginStationAddress,BeginStationHeadAddress,EndStationAddress,EndStationHeadAddress";
            sqlTableHead.strPK = "CodeSenderDirlID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Directional.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【考勤表】
            #region 【班制表】
            sqlTableHead.strTable = "InfoClass";
            sqlTableHead.strHead = "ID,ClassName,ShortName,Remark";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Class.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【班次表】
            sqlTableHead.strTable = "TimerInterval";
            sqlTableHead.strHead = "ID,IntervalName,NameShort,StartWorkTime,EndWorkTime,SWDateType,EWDateType,SWFrontTime,SWAfterTime,EWFrontTime,EWAfterTime,ClassID,DataAttendanceType";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Class.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion
            #endregion

            #region 【区域表】
            #region 【区域类型表】
            sqlTableHead.strTable = "Territorial_Type";
            sqlTableHead.strHead = "TerritorialTypeID,TypeName,IsAlarm,Remark";
            sqlTableHead.strPK = "TerritorialTypeID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Territorial.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【区域信息表】
            sqlTableHead.strTable = "Territorial_Info";
            sqlTableHead.strHead = "TerritorialID,TerritorialName,TerritorialTypeID,IsEnable,Instruction,Remark,TerritorialNO";
            sqlTableHead.strPK = "TerritorialID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Territorial.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【区域配置信息表】
            sqlTableHead.strTable = "Territorial_Config";
            sqlTableHead.strHead = "TerConfigID,TerritorialID,TerWorkTime,TerEmpCount";
            sqlTableHead.strPK = "TerConfigID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Territorial.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【区域分站关联信息表】
            sqlTableHead.strTable = "Territorial_Set";
            sqlTableHead.strHead = "TerritorialSetID,TerritorialID,StationID,StationHeadID,Remark,IsTerriorialEnter";
            sqlTableHead.strPK = "TerritorialSetID,StationHeadID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Territorial.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【特殊工种进出区域信息表】
            sqlTableHead.strTable = "SWorkTypeTerrialSet";
            sqlTableHead.strHead = "TerriAlarmID,TerrialID,WorkTypeID,IsAlarm,Remark";
            sqlTableHead.strPK = "TerriAlarmID,WorkTypeID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Territorial.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion
            #endregion

            #region 【证书配置表】
            sqlTableHead.strTable = "Certificate_Info";
            sqlTableHead.strHead = "CerTypeID,CerName,CerVestIn,IsCheckExpDate,Remark";
            sqlTableHead.strPK = "CerTypeID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Employees.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【工种表】
            #region 【工种配置表】
            sqlTableHead.strTable = "WorkType_Info";
            sqlTableHead.strHead = "WorkTypeID,WtName,CerTypeID,Remark";
            sqlTableHead.strPK = "WorkTypeID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Employees.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【工种WorkType_SysSet表】
            sqlTableHead.strTable = "WorkType_SysSet";
            sqlTableHead.strHead = "WorkTypeSysSetID,WorkTypeID,MaxTimeSec,MinTimeSec,Remark";
            sqlTableHead.strPK = "WorkTypeSysSetID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Employees.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion
            #endregion

            #region 【职务表】
            sqlTableHead.strTable = "Duty_Info";
            sqlTableHead.strHead = "DutyID,DutyName,DutyClassID,Remark";
            sqlTableHead.strPK = "DutyID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Employees.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【部门表】
            #region 【部门基础表】
            sqlTableHead.strTable = "Dept_Info";
            sqlTableHead.strHead = "DeptID,ParentDeptID,DeptLevelID,DeptNO,DeptName,Remark,ClassID,SerialNO,MaxTimeSec,MinTimeSec";
            sqlTableHead.strPK = "DeptID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Employees.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【部门Dept_Detail表】
            sqlTableHead.strTable = "Dept_Detail";
            sqlTableHead.strHead = "DeptID,DeptTel1,DeptTel2,DeptFax,DeptPost,DeptAddress,DeptEmail,Remark,EmpName,LeadDateTime,UnitPrice";
            sqlTableHead.strPK = "DeptID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Employees.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion
            #endregion

            #region 【人员表】
            #region 【人员基础表】
            sqlTableHead.strTable = "Emp_Info";
            sqlTableHead.strHead = "EmpID,EmpNO,EmpName,Sex,DeptID,DeptName,DutyID,DutyName,MaxSecTime,MinSecTime,Selectmode,classGroup,workPlace,photo,idCard,workTypeid,worktypeName,Remark";
            sqlTableHead.strPK = "EmpID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Employees.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【人员Emp_Detail表】
            sqlTableHead.strTable = "Emp_Detail";
            sqlTableHead.strHead = "EmpID,Nation,Wedlock,Clan,NativePlace,CensusRegister,SchoolRecord,GraduateFrom,Specialty,OfficialDesignation,BirthDay,blood,Height,Weight,StateOfHealth,HomeTel,Tel,HomeAddress,Postalcode,ProbationDate,OfficiallyDate,ContractExpDate,ContractExpAppendDate,IsGearShift,HireTypeID,Archives,DimissionTime";
            sqlTableHead.strPK = "EmpID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Employees.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #endregion

            #region 【设备表】
            #region 【生产厂家配置表】
            sqlTableHead.strTable = "FactoryInfo";
            sqlTableHead.strHead = "FactoryID,FactoryNO,FactoryName,FactoryAddress,FactoryFax,FactoryTel,FactoryEmployee,FactoryEmpoyeeTel,Remark";
            sqlTableHead.strPK = "FactoryID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Factory.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【设备基础配置表】
            sqlTableHead.strTable = "Equ_BaseInfo";
            sqlTableHead.strHead = "EquID,EquNO,EquName,DeptID,DeptName,EquType,EquState,FactoryID,Remark";
            sqlTableHead.strPK = "EquID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Factory.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【设备详细配置表】
            sqlTableHead.strTable = "Equ_DetailInfo";
            sqlTableHead.strHead = "EquDetailID,EquID,ModelSpecial,DutyEmployee,UseRange,ProductionDate,EquHeight,EquPower,UserDate";
            sqlTableHead.strPK = "EquDetailID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Factory.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion
            #endregion

            #region 【发码器表】
            sqlTableHead.strTable = "CodeSender_Info";
            sqlTableHead.strHead = "CodeSenderID,CodeSenderAddress,AlarmElectricity,CodeSenderStateID,IsCodeSenderUser,Remark,CodeSenderStateTime";
            sqlTableHead.strPK = "CodeSenderID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "CodeSender.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【发码器配置表】
            sqlTableHead.strTable = "CodeSender_Set";
            sqlTableHead.strHead = "CsSetID,CodeSenderID,CodeSenderAddress,UserID,CsTypeID,Remark";
            sqlTableHead.strPK = "CsSetID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "CodeSender.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【假别管理表】
            sqlTableHead.strTable = "HolidayType";
            sqlTableHead.strHead = "ID,HolidayCode,HolidayName,HolidayAcronym,Remark";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Holiday.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【超速欠速配置表】
            sqlTableHead.strTable = "OverSpeed";
            sqlTableHead.strHead = "OverSpeedID,FirstStationAddress,FirstStationHeadAddress,LastStationAddress,LastStationHeadAddress,WalkTime,Remark,LackWalkTime";
            sqlTableHead.strPK = "OverSpeedID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "OverSpeed.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【巡检配置表】
            #region 【路径表】
            sqlTableHead.strTable = "Path_Info";
            sqlTableHead.strHead = "PathNo,PathName,Remark";
            sqlTableHead.strPK = "PathNo";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Path_Info.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【路线表】
            sqlTableHead.strTable = "Path_Detail";
            sqlTableHead.strHead = "PathNo,StationAddress,StationHeadAddress,PathInterval";
            sqlTableHead.strPK = "PathNo";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Path_Info.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【人员路线匹配表】
            sqlTableHead.strTable = "Path_Emp_Relation";
            sqlTableHead.strHead = "PathNo,Empid";
            sqlTableHead.strPK = "PathNo";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Path_Info.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion
            #endregion

            #region 【图形配置】
            #region 【颜色表】
            sqlTableHead.strTable = "G_DColor";
            sqlTableHead.strHead = "ColorID,ColorName";
            sqlTableHead.strPK = "ColorID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Picture.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【图片文件表】
            sqlTableHead.strTable = "G_DPicFile";
            sqlTableHead.strHead = "FileID,[Filename],Fileimg";
            sqlTableHead.strPK = "[Filename]";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Picture.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【配置文件表】
            sqlTableHead.strTable = "G_DConfigFile";
            sqlTableHead.strHead = "[FileName],ConfigFile,MapFileID";
            sqlTableHead.strPK = "[FileName]";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Picture.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【路径点表】
            sqlTableHead.strTable = "G_DPoint";
            sqlTableHead.strHead = "ID,PointID,x,y,FileID";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Picture.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【路径正反表】
            sqlTableHead.strTable = "G_DRoute";
            sqlTableHead.strHead = "ID,routefrom,routeto,routelength,FileID";
            sqlTableHead.strPK = "ID";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Picture.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            #region 【文件下读卡分站信息表】
            sqlTableHead.strTable = "G_File_Station";
            sqlTableHead.strHead = "FileID,StationHeadId";
            sqlTableHead.strPK = "StationHeadId";
            sqlTableHead.tableType = 0;
            sqlTableHead.strTime = "";
            sqlTableHead.strConfigFile = "Picture.xml";
            sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion
            #endregion
            #endregion

            #region 【实时表】


            #region 【传输分站配置表-状态】
            sqlTableHead.strTable = "Station_Info";
            //"StationID,StationAddress,StationPlace,StationTel,StationTypeID,StationType,StationState,BreakTimes,BreakTime,StationX,StationY,EditBaseInfo,StationGroup,StationVersion,Remark,IPAddressID,StationModel
            sqlTableHead.strHead = "StationID,StationAddress,StationPlace,StationTel,StationTypeID,StationType,StationState,BreakTimes,BreakTime,StationX,StationY,EditBaseInfo,StationGroup,StationVersion,Remark,IPAddressID,StationModel";
            sqlTableHead.strPK = "StationID";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            //sqlTableHead.strConfigFile = "StationHead.xml";
            //sqlTableHead.dtimeConfig = dtNow;
            al.Add(sqlTableHead);
            #endregion

            //#region 【读卡分站配置表-状态】
            //sqlTableHead.strTable = "Station_Head_Info";
            //sqlTableHead.strHead = "StationHeadID,StationHeadState,BreakTimes,BreakTime ";
            //sqlTableHead.strPK = "StationHeadID";
            //sqlTableHead.tableType = 1;
            //sqlTableHead.strTime = "";
            //sqlTableHead.strConfigFile = "StationHead.xml";
            //sqlTableHead.dtimeConfig = dtNow;
            //al.Add(sqlTableHead);
            //#endregion


            #region 【实时读卡分站表】
            sqlTableHead.strTable = "Station_Head_Info";
            sqlTableHead.strHead = "StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace,StationHeadTel,StationHeadTypeID,StationHeadType,StationHeadX,StationHeadY,StationHeadState,EditBaseInfo,AntennaA,AntennaB,AntennaAX,AntennaAY,AntennaBX,AntennaBY,BreakTimes,BreakTime,Remark,StationHeadNO";
            //sqlTableHead.strHead = "StationHeadID,StationHeadState,BreakTimes,BreakTime";
            sqlTableHead.strPK = "StationHeadID";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时进上井口分站表】
            sqlTableHead.strTable = "InMineStationInfo";
            sqlTableHead.strHead = "StationHeadID,StationAddress,StationHeadAddress,CodeSenderAddress,InMineStationTime";
            sqlTableHead.strPK = "CodeSenderAddress";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时下井表】
            sqlTableHead.strTable = "RT_InOutMine";
            sqlTableHead.strHead = "StationHeadID,CsSetID,InTime,CodeSenderAddress";
            sqlTableHead.strPK = "CodeSenderAddress";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时考勤表】
            sqlTableHead.strTable = "RealTimeAttendance";
            sqlTableHead.strHead = "BlockID,EmployeeID,EmployeeName,DeptID,ClassID,ClassShortName,BeginWorkTime,IsLate,TimerIntervalID,DataAttendance";
            sqlTableHead.strPK = "BlockID";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时进出读卡分站表】
            sqlTableHead.strTable = "RT_InStationHeadInfo";
            sqlTableHead.strHead = "CodeSenderAddress,StationHeadID,CsSetID,CsTypeID,UserID,InAntennaPlace,InStationHeadTime,InOutFlag,StationHeadTime,Directional";
            sqlTableHead.strPK = "CodeSenderAddress";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时进出读卡分站临时表】
            sqlTableHead.strTable = "RTInstationHeadTmep";
            sqlTableHead.strHead = "CodeSenderAddress,StationAddress,StationHeadAddress,CsSetID,CsTypeID,UserID,InStationHeadTime";
            sqlTableHead.strPK = "CodeSenderAddress,StationAddress,StationHeadAddress";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时超员表】
            sqlTableHead.strTable = "RTOverEmployees";
            sqlTableHead.strHead = "beginTime,ratingEmpCount,MaxEmpCount,MaxEmpTime,realTimeEmpCount";
            sqlTableHead.strPK = "beginTime";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时区域表】
            sqlTableHead.strTable = "RT_TerritorialInfo";
            sqlTableHead.strHead = "TerritorialID,TerritorialName,InTerritorialTime,CodeSenderAddress,CsSetID,CsTypeID,UserID,TerritorialTypeName,IsAlarm";
            sqlTableHead.strPK = "TerritorialID,CodeSenderAddress";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时异地交接班信息】
            sqlTableHead.strTable = "Associate";
            sqlTableHead.strHead = "id,stationAddress,stationHeadAddress,stationHeadPlace,beginTime,endTime,empID1,empID2,empName1,empName2,isFlagEmp1,isFlagEmp2";
            sqlTableHead.strPK = "id";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时巡检表】
            sqlTableHead.strTable = "RealTimePathCheck";
            sqlTableHead.strHead = "EmpID,Interval,CheckTime";
            sqlTableHead.strPK = "EmpID";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时巡检报警表】
            sqlTableHead.strTable = "RealTimeAlarmPathInfo";
            sqlTableHead.strHead = "EmpID,StationAddress,StationHeadAddress,AlarmDatetime";
            sqlTableHead.strPK = "EmpID";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时求救报警信息】
            sqlTableHead.strTable = "RT_EmpHelp";
            sqlTableHead.strHead = "CodeSenderAddress,StationAddress,StationHeadAddress,EmpID,BeginDateTime,Measure";
            sqlTableHead.strPK = "CodeSenderAddress";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时区域超员报警信息】
            sqlTableHead.strTable = "RT_TerOverEmp";
            sqlTableHead.strHead = "TerritorialID,TerritorialName,TerritorialTypeName,TerEmpCount,NowTerEmpCount,NowOverCount,MaxOverCount,OverEmpBeginTime";
            sqlTableHead.strPK = "TerritorialID";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion

            #region 【实时唯一性报警】
            sqlTableHead.strTable = "CheckCards";
            sqlTableHead.strHead = "CodeSenderAddress,CsSetID,CsTypeID,UserID,InStationHeadTime";
            sqlTableHead.strPK = "CodeSenderAddress";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);

            sqlTableHead.strTable = "RT_Onlyones";
            sqlTableHead.strHead = "rtOnlyoneID,CodeSenderAddress,CsSetID,CsTypeID,UserID,beginAlarmTime";
            sqlTableHead.strPK = "rtOnlyoneID";
            sqlTableHead.tableType = 1;
            sqlTableHead.strTime = "";
            al.Add(sqlTableHead);
            #endregion
            #endregion

            #region 【历史表】
            #region 【历史上下井表】
            sqlTableHead.strTable = "His_InOutMine_";
            sqlTableHead.strHead = "[HisInOutMineID],[InStationAddress],[InStationHeadAddress],[InWellPlace],[CodeSenderAddress],[UserID],[UserNo],[UserName],[DeptID],[DeptName],[DutyID],[DutyName],[WorkTypeID],[WorkTypeName],[InTime],[OutStationAddress],[OutStationHeadAddress],[OutWellPlace],[OutTime],[ContinueTime],[IsMend]";
            sqlTableHead.strPK = "HisInOutMineID,CodeSenderAddress,InTime";
            sqlTableHead.tableType = 3;
            sqlTableHead.strTime = "InTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史进出读卡分站表】
            sqlTableHead.strTable = "His_InOutStationHead_";
            sqlTableHead.strHead = "[HisStationHeadID],[StationAddress],[StationHeadAddress],[StationHeadPlace],[CodeSenderAddress],[CsTypeID],[UserID],[UserNo],[UserName],[DeptID],[DeptName],[DutyID],[DutyName],[WorkTypeID],[WorkTypeName],[InStationHeadTime],[OutStationHeadTime],[ContinueTime],[IsMend]";
            sqlTableHead.strPK = "HisStationHeadID,CodeSenderAddress,InStationHeadTime";
            sqlTableHead.tableType = 3;
            sqlTableHead.strTime = "InStationHeadTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史进出区域表】
            sqlTableHead.strTable = "His_InOutTerritorial_";
            sqlTableHead.strHead = "[HisTerritorialID],[TerritorialID],[TerritorialName],[TerritorialTypeName],[InTerritorialTime],	[CodeSenderAddress],[UserID],[UserNo],[UserName],[DeptID],[DeptName],[DutyID],[DutyName],[WorkTypeID],[WorkTypeName],[OutTerritorialTime],[ContinueTime],[IsAlarm]";
            sqlTableHead.strPK = "HisTerritorialID,TerritorialID,InTerritorialTime,CodeSenderAddress";
            sqlTableHead.tableType = 3;
            sqlTableHead.strTime = "InTerritorialTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史考勤表】
            sqlTableHead.strTable = "HistoryAttendance_";
            sqlTableHead.strHead = "[ID],[BlockID],[EmployeeID],[EmployeeName],[DeptID],[ClassID],[ClassShortName],[BeginWorkTime],[EndWorkTime],[WorkTime],[IsHoliday],[OperatorID],[OperatorTime],[TimerIntervalID],[DataAttendance],[IsMend]";
            sqlTableHead.strPK = "[ID],DataAttendance";
            sqlTableHead.tableType = 3;
            sqlTableHead.strTime = "BeginWorkTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史进出井超速欠速表】
            sqlTableHead.strTable = "His_OverSpeed";
            sqlTableHead.strHead = "HisOverSpeedID,CodeSenderAddress,CsTypeID,UserID,FirstStationAddress,FirstStationHeadAddress,FirstMonitoringTime,LastStationAddress,LastStationHeadAddress,LastMonitoringTime,WalkTime,IsOverSpeed,DeptName,DutyName,WtName,IsOutWell,IsEnd,EmpName,LackWalkTime,IsLackSpeed";
            sqlTableHead.strPK = "HisOverSpeedID";
            sqlTableHead.tableType = 2;
            sqlTableHead.strTime = "FirstMonitoringTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史进出井超时表】
            sqlTableHead.strTable = "His_OverTimeAlarm";
            sqlTableHead.strHead = "HisOverTimeAlarmID,CodeSenderAddress,CsSetID,CsTypeID,UserID,UserName,InMineTime,DelayedStartTime,DelayedEndTime,DelayedTime,DeptName";
            sqlTableHead.strPK = "HisOverTimeAlarmID";
            sqlTableHead.tableType = 2;
            sqlTableHead.strTime = "DelayedStartTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史进出井超员表】
            sqlTableHead.strTable = "HisOverEmployee";
            sqlTableHead.strHead = "HisOverEmployeeID,beginTime,endTime,ratingEmpCount,maxEmpCount,maxEmpTime,existstime";
            sqlTableHead.strPK = "HisOverEmployeeID";
            sqlTableHead.tableType = 2;
            sqlTableHead.strTime = "beginTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史分站故障表】
            sqlTableHead.strTable = "HistoryBadStations";
            sqlTableHead.strHead = "HistoryBadStationsID,StationAddress,StationHeadAddress,StationPlace,BadBeginTime,BadEndTime,BadTime";
            sqlTableHead.strPK = "HistoryBadStationsID";
            sqlTableHead.tableType = 2;
            sqlTableHead.strTime = "BadBeginTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史区域超员报警表】
            sqlTableHead.strTable = "His_TerOverEmp";
            sqlTableHead.strHead = "HisTerOverEmpID,TerritorialID,TerritorialName,TerritorialTypeName,TerEmpCount,MaxOverCount,OverEmpBeginTime,OverEmpEndTime";
            sqlTableHead.strPK = "HisTerOverEmpID,TerritorialID";
            sqlTableHead.tableType = 2;
            sqlTableHead.strTime = "OverEmpBeginTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史区域超时报警表】
            sqlTableHead.strTable = "His_TerritorialEmpOverTime";
            sqlTableHead.strHead = "HisTerEmpOverTimeID,TerritorialID,TerritorialName,TerritorialTypeName,InTerritorialTime,TerWorkTime,OutTerritorialTime,CodeSenderAddress,EmpID,EmpName,DeptID,DeptName,WtName";
            sqlTableHead.strPK = "HisTerEmpOverTimeID,TerritorialID";
            sqlTableHead.tableType = 2;
            sqlTableHead.strTime = "InTerritorialTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史巡检报警表】
            sqlTableHead.strTable = "His_PathAlert";
            sqlTableHead.strHead = "Id,EmpID,EmpName,StationAddress,StationHeadAddress,AlertBeginTime,AlertEndTime,AlertTimeValue";
            sqlTableHead.strPK = "Id";
            sqlTableHead.tableType = 2;
            sqlTableHead.strTime = "AlertBeginTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史求救报警表】
            sqlTableHead.strTable = "His_EmpHelp";
            sqlTableHead.strHead = "CodeSenderAddress,StationAddress,StationPlace,StationHeadAddress,StationHeadPlace,EmpName,DeptName,DutyName,WtName,BeginDateTime,EndDateTime,Measure";
            sqlTableHead.strPK = "HisEmpHelpID";
            sqlTableHead.tableType = 2;
            sqlTableHead.strTime = "BeginDateTime";
            al.Add(sqlTableHead);
            #endregion

            #region 【历史唯一性报警表】
            sqlTableHead.strTable = "His_Onlyones";
            sqlTableHead.strHead = "HisOnlyoneID,CodeSenderAddress,CsSetID,CsTypeID,UserID,UserName,beginAlarmTime,endAlarmTime";
            sqlTableHead.strPK = "HisOnlyoneID";
            sqlTableHead.tableType = 2;
            sqlTableHead.strTime = "beginAlarmTime";
            al.Add(sqlTableHead);
            #endregion
            #endregion

            #region 【考勤统计记录表】
            sqlTableHead.strTable = "kqtj";
            sqlTableHead.strHead = "[DataAttendance],[blockid],[EmpName],[Deptid],[DeptName],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31]";
            sqlTableHead.strPK = "DataAttendance,blockid";
            sqlTableHead.tableType = 4;
            sqlTableHead.strTime = "DataAttendance";
            al.Add(sqlTableHead);

            //sqlTableHead.strTable = "kqtj";
            //sqlTableHead.strHead = "[DataAttendance],[blockid],[EmpName],[Deptid],[DeptName],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20]";
            //sqlTableHead.strPK = "DataAttendance,blockid";
            //sqlTableHead.tableType = 4;
            //sqlTableHead.strTime = "DataAttendance";
            //al.Add(sqlTableHead);

            //sqlTableHead.strTable = "kqtj";
            //sqlTableHead.strHead = "[DataAttendance],[blockid],[EmpName],[Deptid],[DeptName],[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31]";
            //sqlTableHead.strPK = "DataAttendance,blockid";
            //sqlTableHead.tableType = 4;
            //sqlTableHead.strTime = "DataAttendance";
            //al.Add(sqlTableHead);
            #endregion

            #region【Czlt-2012-3-26-月下井次数统计表】

            ///月下井次数统计表
            sqlTableHead.strTable = "Czlt_MonthEmpNum";
            sqlTableHead.strHead = "[codesender],[empID],[empName],[deptID],[deptName],[cYear],[cM1],[cM2],[cM3],[cM4],[cM5],[cM6],[cM7],[cM8],[cM9],[cM10],[cM11],[cM12]";
            sqlTableHead.strPK = "codesender,empName,cYear";
            sqlTableHead.tableType = 4;
            sqlTableHead.strTime = "cYear";
            al.Add(sqlTableHead);

            ///月下井时长统计表
            sqlTableHead.strTable = "Czlt_MonthEmpTime";
            sqlTableHead.strHead = "[codesender],[empID],[empName],[deptID],[deptName],[cYear],[cM1],[cM2],[cM3],[cM4],[cM5],[cM6],[cM7],[cM8],[cM9],[cM10],[cM11],[cM12]";
            sqlTableHead.strPK = "codesender,empName,cYear";
            sqlTableHead.tableType = 4;
            sqlTableHead.strTime = "cYear";
            al.Add(sqlTableHead);
            #endregion

            return al;
        }
        #endregion

        #region 【方法：获取读异地更新本地数据执行字符串】
        /// <summary>
        /// 获取读异地更新本地数据执行字符串
        /// </summary>
        /// <param name="strTable">数据表</param>
        /// <param name="strHead">数据列头</param>
        /// <param name="strWhere">查询条件 本地数据用b 远程用 i 其中 opti选择1时只使用到i；选择2时只使用到b；选择3时两者都使用</param>
        /// <param name="Opti">1为插入本地数据  2为删除本地数据  3为修改本地数据</param>
        /// <param name="strPk">每次执行插入的数量</param>
        /// <returns>连接字符串</returns>
        public string ReadOtherUpdateLocal(string strTable, string strHead, string strWhere, string strPk, int Opti, string strTop)
        {
            string sql = "";
            switch (Opti)
            {
                case 1:
                    sql = "Insert into [" + strTable + "](" + strHead + ") select " + strTop + strHead + " from [128RB].[KJ128N].[dbo].[" + strTable + "] b where " + strWhere;
                    string[] strTempPK2 = strPk.Split(',');//获取各个主键
                    if (strTempPK2.Length > 0)
                    {
                        sql += " and not exists(select " + strTempPK2[0] + " from [" + strTable + "] c where " + strWhere;
                        for (int m = 0; m < strTempPK2.Length; m++)
                        {
                            //if (m > 0)
                            //    sql += " or ";
                            //else
                            //    sql += " and (";
                            ////sql += strTempPK2[m] + " not in (select " + strTempPK2[m] + " from [" + strTable + "])"; //Czlt-2011-07-01 注销
                            //sql += strTempPK2[m] + " not in (select " + strTempPK2[m] + " from [" + strTable + "]  where " + strWhere + ")"; //Czlt-2011-07-01 添加where条件
                            sql += " and c." + strTempPK2[m] + "=b." + strTempPK2[m];
                        }
                        sql += ")";
                    }
                    ////2011-03-30 修改
                    //if(strTempPK2.Length>0)
                    //    sql+=")";
                    break;
                case 2:
                    //czlt-2011-17 注销 删除不能同步
                    //sql = "Delete from [" + strTable + "] where ";
                    //string[] strTempPK1 = strPk.Split(',');//获取各个主键
                    //if (strTempPK1.Length > 0)
                    //{
                    //    sql += " not exists(select " + strTempPK1[0] + " from [128RB].[KJ128N].[dbo].[" + strTable + "] c where ";
                    //    for (int k = 0; k < strTempPK1.Length; k++)
                    //    {
                    //        //if (k > 0)
                    //        //    sql += " or ";
                    //        //sql += strTempPK1[k] + " not in (select " + strTempPK1[k] + " from [128RB].[KJ128N].[dbo].[" + strTable + "])";
                    //        if (k > 0)
                    //            sql += " and ";
                    //        sql += "[" + strTable + "]." + strTempPK1[k] + "=c." + strTempPK1[k];
                    //    }
                    //    sql += ")";
                    //}

                    //czlt-2011-17 优化删除方法
                    sql = "Delete [" + strTable + "] from [" + strTable + "] d where ";
                    string[] strTempPK1 = strPk.Split(',');//获取各个主键
                    if (strTempPK1.Length > 0)
                    {
                        sql += " not exists(select " + strTempPK1[0] + " from [128RB].[KJ128N].[dbo].[" + strTable + "] c where ";
                        for (int k = 0; k < strTempPK1.Length; k++)
                        {
                            //if (k > 0)
                            //    sql += " or ";
                            //sql += strTempPK1[k] + " not in (select " + strTempPK1[k] + " from [128RB].[KJ128N].[dbo].[" + strTable + "])";
                            if (k > 0)
                                sql += " and ";
                            sql += "d." + strTempPK1[k] + "=c." + strTempPK1[k];
                        }
                        sql += ")";
                    }
                    break;
                case 3:
                    string strNOTWhere = string.Empty;
                    sql = "update [" + strTable + "] set ";
                    string[] strTempHead = strHead.Split(',');//获取各个列表头
                    string[] strTempPK = strPk.Split(',');//获取各个主键
                    for (int i = 0; i < strTempHead.Length; i++)
                    {
                        bool flag = false;
                        for (int j = 0; j < strTempPK.Length; j++)
                        {
                            if (strTempPK[j].Equals(strTempHead[i]))
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (!flag)
                        {
                            sql += strTempHead[i] + "=i." + strTempHead[i] + ",";
                            //if (!strTempHead[i].ToString().Equals("photo"))
                            //{
                            //    strNOTWhere += " and b." + strTempHead[i] + " <> i." + strTempHead[i];
                            //}
                        }
                    }
                    sql = sql.Substring(0, sql.Length - 1);
                    sql += " from [" + strTable + "] b , [128RB].[KJ128N].[dbo].[" + strTable + "] i where " + strWhere + strNOTWhere;
                    break;
                default:
                    break;
            }

            ////实时下井
            //if (strTable.Equals("RT_InOutMine"))
            //{
            //    File.AppendAllText("D:\\CzltUpdateSql.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",读异存本 RT_InOutMine \r\n" + sql + "\r\n", Encoding.Unicode);
            //}
            ////
            //if (strTable.Equals("Station_Head_Info"))
            //{
            //    File.AppendAllText("D:\\CzltUpdateSql.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",读异存本 Station_Head_Info \r\n" + sql + "\r\n", Encoding.Unicode);
            //}
            return sql;
        }
        #endregion

        #region 【方法：获取读本地更新异地数据执行字符串】
        /// <summary>
        /// 获取读取本地更新异地数据执行字符串
        /// </summary>
        /// <param name="strTable">数据表</param>
        /// <param name="strHead">数据列头</param>
        /// <param name="strWhere">查询条件 本地数据用b 远程用 i 其中 opti选择1时只使用到b；选择2时只使用到i；选择3时两者都使用</param>
        /// <param name="opti">1为插入异地数据  2为删除异地数据  3为修改异地数据</param>
        /// <returns></returns>
        public string ReadLocalUpdateOther(string strTable, string strHead, string strWhere, string strPk, int Opti, string strTop)
        {
            string sql = "";
            switch (Opti)
            {
                case 1:
                    //sql = "Insert into [128RB].[KJ128N].[dbo].[" + strTable + "](" + strHead + ") select " + strHead + " from [" + strTable + "] b where not exists (select * from [128RB].[KJ128N].[dbo].[" + strTable + "] where   " + strWhere + ")";
                    sql = "Insert into [128RB].[KJ128N].[dbo].[" + strTable + "](" + strHead + ") select " + strHead + " from [" + strTable + "] b where " + strWhere;
                    string[] strTempPK2 = strPk.Split(',');//获取各个主键
                    if (strTempPK2.Length > 0)
                    {
                        sql += " and not exists(select " + strTempPK2[0] + " from [128RB].[KJ128N].[dbo].[" + strTable + "] c where " + strWhere;
                        for (int m = 0; m < strTempPK2.Length; m++)
                        {
                            //sql += " and " + strTempPK2[m] + " not in (select " + strTempPK2[m] + " from [128RB].[KJ128N].[dbo].[" + strTable + "])"; //Czlt-2011-07-01 注销
                            sql += " and c." + strTempPK2[m] + "=b." + strTempPK2[m];
                        }
                        sql += ")";
                    }
                    break;
                case 2:
                    //czlt-2011-11-17 注销 删除不能实现
                    //sql = "Delete from [128RB].[KJ128N].[dbo].[" + strTable + "]  where ";
                    //string[] strTempPK1 = strPk.Split(',');//获取各个主键
                    //if (strTempPK1.Length > 0)
                    //{
                    //    sql += "  not exists(select " + strTempPK1[0] + " from [" + strTable + "] c where ";
                    //    for (int k = 0; k < strTempPK1.Length; k++)
                    //    {
                    //        if (k > 0)
                    //            sql += " and ";
                    //        sql += "[" + strTable + "]." + strTempPK1[k] + "=c." + strTempPK1[k];
                    //    }
                    //    sql += ")";
                    //}

                    //Czlt-2011-11-17 优化删除方法
                    sql = "Delete  [128RB].[KJ128N].[dbo].[" + strTable + "]  from [128RB].[KJ128N].[dbo].[" + strTable + "] d where ";
                    string[] strTempPK1 = strPk.Split(',');//获取各个主键
                    if (strTempPK1.Length > 0)
                    {
                        sql += "  not exists(select " + strTempPK1[0] + " from [" + strTable + "] c where ";
                        for (int k = 0; k < strTempPK1.Length; k++)
                        {
                            if (k > 0)
                                sql += " and ";
                            sql += " d." + strTempPK1[k] + "=c." + strTempPK1[k];
                        }
                        sql += ")";
                    }

                    break;
                case 3:
                    string strNOTWhere = string.Empty;
                    sql = "update [128RB].[KJ128N].[dbo].[" + strTable + "] set ";
                    string[] strTempHead = strHead.Split(',');//获取各个列表头
                    string[] strTempPK = strPk.Split(',');//获取各个主键
                    for (int i = 0; i < strTempHead.Length; i++)
                    {
                        bool flag = false;
                        for (int j = 0; j < strTempPK.Length; j++)
                        {
                            if (strTempPK[j].Equals(strTempHead[i]))
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (!flag)
                        {
                            sql += strTempHead[i] + "=b." + strTempHead[i] + ",";
                            //strNOTWhere += " and b." + strTempHead[i] + " <> i." + strTempHead[i];
                        }
                    }
                    sql = sql.Substring(0, sql.Length - 1);
                    sql += " from [128RB].[KJ128N].[dbo].[" + strTable + "] i , [" + strTable + "] b where " + strWhere + strNOTWhere;
                    break;
                default:
                    break;
            }

            ////实时下井
            //if (strTable.Equals("RT_InOutMine"))
            //{
            //    File.AppendAllText("D:\\CzltUpdateSql.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",读本存异 RT_InOutMine \r\n" + sql + "\r\n", Encoding.Unicode);
            //}
            ////
            //if (strTable.Equals("Station_Head_Info"))
            //{
            //    File.AppendAllText("D:\\CzltUpdateSql.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",读本存异 Station_Head_Info \r\n" + sql + "\r\n", Encoding.Unicode);
            //}
            return sql;
        }
        #endregion

        #region 【方法：执行数据字符串】
        /// <summary>
        /// 执行数据字符串
        /// </summary>
        /// <param name="strSql"></param>
        public int ExecSql(string strSql)
        {
            int i = 0;
            try
            {
                i = SqlHelper.ExecuteNonQuery(strConnection, CommandType.Text, strSql);

                //StringBuilder strB = new StringBuilder();
                //strB.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"执行Sql语句：\r\n   " + strSql + " \r\n");
                //File.WriteAllText("D:\\StringError.txt", strB.ToString(), Encoding.Unicode);

                return i;
            }
            catch (Exception ee)
            {

                StringBuilder strB = new StringBuilder();
                strB.Append("\n 执行Sql语句：   " + strSql + " \n");
                strB.Append(ee.ToString() + "\n");
                //File.WriteAllText("D:\\StringError.txt", strB.ToString(), Encoding.Unicode);
                return i;
            }
        }
        #endregion

        #region 【方法：执行读异地存本地数据（获取实时数据和配置数据）】
        /// <summary>
        /// 执行读异地存本地数据（获取实时数据和配置数据）
        /// </summary>
        public void ExecReadOtherUpdateLocalRealConfig()
        {
            //Czlt-2011-12-10 跟新时间数据
            File.WriteAllText("D:\\CzltPZ2.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",01,主备连接正常开始同步配置信息和实时信息！", Encoding.Unicode);
          
            string strSql = "";
            for (int i = 0; i < sqlTableHeadsAL.Count; i++)
            {
                SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];
                if ((sqltableHead.tableType == 0 || sqltableHead.tableType == 1) && m_ConnState == true)               
                {
                    string strUpdateSqlWhere = "";
                    string strInsertSqlWhere = " 1=1 ";
                    string strDeleteSqlWhere = "";
                    string[] strTempPk = sqltableHead.strPK.Split(',');
                    for (int j = 0; j < strTempPk.Length; j++)
                    {
                        if (j > 0)
                        {
                            strUpdateSqlWhere += " and ";
                            //strInsertSqlWhere += " and ";
                            strDeleteSqlWhere += " and ";
                        }
                        strUpdateSqlWhere += "b." + strTempPk[j] + "=" + "i." + strTempPk[j];
                        //strInsertSqlWhere += strTempPk[j] + "=" + "i." + strTempPk[j];
                        strDeleteSqlWhere += "i." + strTempPk[j] + "=" + strTempPk[j];
                    }
                    //删除
                    if (!(sqltableHead.strTable.Equals("Station_Head_Info") && sqltableHead.tableType == 1))
                    {
                        if (sqltableHead.strTable.Equals("G_DPicFile") || sqltableHead.strTable.Equals("G_DConfigFile"))
                        {
                            strSql = "Delete from [" + sqltableHead.strTable + "]";
                        }
                        else
                        {
                            strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere, sqltableHead.strPK, 2, "");
                        }

                        //strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere, sqltableHead.strPK, 2, "");
                        try
                        {
                            if (strSql != "")
                            {
                                //if (sqltableHead.strTable.Equals("RT_InOutMine") || sqltableHead.strTable.Equals("RTInstationHeadTmep") || sqltableHead.strTable.Equals("RT_InStationHeadInfo") || sqltableHead.strTable.Equals("RealTimeAttendance"))
                                //{
                                //    File.AppendAllText("D:\\CzltSqlHelp.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + sqltableHead.strTable + " 表删除Sql语句:\r\n" + strSql+"\r\n", Encoding.Unicode);

                                //}
                                ExecSql(strSql);
                                Thread.Sleep(50);
                            }
                        }
                        catch
                        { }
                    }

                    //修改
                    if (!sqltableHead.strTable.Equals("G_DPicFile") && !sqltableHead.strTable.Equals("G_DConfigFile"))
                    {
                        strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere, sqltableHead.strPK, 3, "");
                        try
                        {
                            //if (sqltableHead.strTable.Equals("RT_InOutMine") || sqltableHead.strTable.Equals("RTInstationHeadTmep") || sqltableHead.strTable.Equals("RT_InStationHeadInfo") || sqltableHead.strTable.Equals("RealTimeAttendance"))
                            //{
                            //    File.AppendAllText("D:\\CzltSqlHelp.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + sqltableHead.strTable + " 表修改Sql语句:\r\n" + strSql + "\r\n", Encoding.Unicode);

                            //}
                            if (strSql != "")
                            {
                                ExecSql(strSql);
                                Thread.Sleep(50);
                            }
                        }
                        catch
                        { }
                    }

                    if (!(sqltableHead.strTable.Equals("Station_Head_Info") && sqltableHead.tableType == 1))
                    {
                        //添加
                        strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");
                        try
                        {
                            //if (sqltableHead.strTable.Equals("RT_InOutMine") || sqltableHead.strTable.Equals("RTInstationHeadTmep") || sqltableHead.strTable.Equals("RT_InStationHeadInfo") || sqltableHead.strTable.Equals("RealTimeAttendance"))
                            //{
                            //    File.AppendAllText("D:\\CzltSqlHelp.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + sqltableHead.strTable + " 表添加Sql语句:\r\n" + strSql + "\r\n", Encoding.Unicode);

                            //}
                            if (strSql != "")
                            {
                                ExecSql(strSql);
                                Thread.Sleep(50);
                            }
                        }
                        catch
                        { }
                    }
                }
                ////实时下井
                //if (sqltableHead.strTable.Equals("RT_InOutMine"))
                //{
                //    File.AppendAllText("D:\\CzltUpdateSql.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",RT_InOutMine \r\n" + strSql+"\r\n", Encoding.Unicode); 
                //}
                ////
                //if (sqltableHead.strTable.Equals("Station_Head_Info"))
                //{
                //    File.AppendAllText("D:\\CzltUpdateSql.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",Station_Head_Info \r\n" + strSql + "\r\n", Encoding.Unicode);
                //}

            }
            File.WriteAllText("D:\\CzltPZ2.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",01,开始同步配置信息实时信息！\r\n配置信息和实时信息同步完成！", Encoding.Unicode);


        }
        #endregion

        #region 【方法：执行读异地存本地数据（获取实时数据）】
        /// <summary>
        /// 执行读异地存本地数据（获取实时数据）
        /// </summary>
        public void ExecReadOtherUpdateLocalReal()
        {
            //Czlt-2011-12-10 跟新时间数据
            //File.WriteAllText("D:\\CzltSS.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",1", Encoding.Unicode);

            //Czlt-2011-02-07 注销
           // File.AppendAllText("D:\\CzltMessageCopy.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",地存本地数据（获取实时数据）\n\r", Encoding.Unicode);
            string strSql = "";
            for (int i = 0; i < sqlTableHeadsAL.Count; i++)
            {
                SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];
                if (sqltableHead.tableType == 1 && m_ConnState == true)
                {

                    string strUpdateSqlWhere = "";
                    string strInsertSqlWhere = " 1=1 ";
                    string strDeleteSqlWhere = "";
                    string[] strTempPk = sqltableHead.strPK.Split(',');
                    for (int j = 0; j < strTempPk.Length; j++)
                    {
                        if (j > 0)
                        {
                            strUpdateSqlWhere += " and ";
                            //strInsertSqlWhere += " and ";
                            strDeleteSqlWhere += " and ";
                        }
                        strUpdateSqlWhere += "b." + strTempPk[j] + "=" + "i." + strTempPk[j];
                        //strInsertSqlWhere += strTempPk[j] + "=" + "i." + strTempPk[j];
                        strDeleteSqlWhere += "i." + strTempPk[j] + "=" + strTempPk[j];
                    }
                    //删除
                    strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere, sqltableHead.strPK, 2, "");

                    try
                    {
                        if (strSql != "")
                        {
                            ExecSql(strSql);
                            Thread.Sleep(50);
                        }
                    }
                    catch
                    { }
                    //修改
                    strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere, sqltableHead.strPK, 3, "");

                    try
                    {
                        if (strSql != "")
                        {
                            ExecSql(strSql);
                            Thread.Sleep(50);
                        }
                    }
                    catch
                    { }
                    //添加
                    strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");

                    try
                    {
                        if (strSql != "")
                        {
                            ExecSql(strSql);
                            Thread.Sleep(50);
                        }
                    }
                    catch
                    { }
                }

            }
        }
        #endregion

        #region 【方法：执行读异地存本地数据（获取配置数据）】
        /// <summary>
        /// 执行读异地存本地数据（获取配置数据）
        /// </summary>
        public void ExecReadOtherUpdateLocalConfig()
        {
            //Czlt-2011-12-10 跟新时间数据
            //File.WriteAllText("D:\\CzltPZ.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",0", Encoding.Unicode);

            //Czlt-2011-02-07 注销
            //File.AppendAllText("D:\\CzltMessageCopy.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",执行读异地存本地数据（获取配置数据）\n\r", Encoding.Unicode);
            string strSql = "";
            for (int i = 0; i < sqlTableHeadsAL.Count; i++)
            {
                SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];
                if (sqltableHead.tableType == 0 && m_ConnState == true)
                {
                    string strUpdateSqlWhere = "";
                    string strInsertSqlWhere = " 1=1 ";
                    string strDeleteSqlWhere = "";
                    string[] strTempPk = sqltableHead.strPK.Split(',');
                    for (int j = 0; j < strTempPk.Length; j++)
                    {
                        if (j > 0)
                        {
                            strUpdateSqlWhere += " and ";
                            //strInsertSqlWhere += " and ";
                            strDeleteSqlWhere += " and ";
                        }
                        strUpdateSqlWhere += "b." + strTempPk[j] + "=" + "i." + strTempPk[j];
                        //strInsertSqlWhere += strTempPk[j] + "=" + "i." + strTempPk[j];
                        strDeleteSqlWhere += "i." + strTempPk[j] + "=" + strTempPk[j];
                    }
                    if (!sqltableHead.strTable.Equals("Station_Head_Info"))
                    {
                        //删除
                        if (sqltableHead.strTable.Equals("G_DPicFile") || sqltableHead.strTable.Equals("G_DConfigFile"))
                        {
                            strSql = "Delete from [" + sqltableHead.strTable + "]";
                        }
                        else
                        {
                            strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere, sqltableHead.strPK, 2, "");
                        }
                        try
                        {
                            if (strSql != "")
                            {
                                ExecSql(strSql);
                                Thread.Sleep(50);
                            }
                        }
                        catch
                        { }
                    }

                    //修改
                    if (!sqltableHead.strTable.Equals("G_DPicFile") && !sqltableHead.strTable.Equals("G_DConfigFile"))
                    {
                        strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere, sqltableHead.strPK, 3, "");
                        try
                        {
                            if (strSql != "")
                            {
                                ExecSql(strSql);
                                Thread.Sleep(50);
                            }
                        }
                        catch
                        { }
                    }

                    if (!sqltableHead.strTable.Equals("Station_Head_Info"))
                    {
                        //添加
                        strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");
                        try
                        {
                            if (strSql != "")
                            {
                                ExecSql(strSql);
                                Thread.Sleep(50);
                            }
                        }
                        catch
                        { }
                    }
                }

            }
        }
        #endregion

        #region 【方法：获取一天的历史数据,读异地存本地】
        /// <summary>
        /// 获取一天的历史数据，读异地存本地
        /// </summary>
        public void ExecReadOtherUpdateLocalHisData()
        {
            try
            {
                for (int i = 0; i < sqlTableHeadsAL.Count; i++)
                {
                    SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];
                    if ((sqltableHead.tableType == 2 || sqltableHead.tableType == 3 || sqltableHead.tableType == 4) && m_ConnState == true)
                    {
                        string strInsertSqlWhere = "";
                        string strDeleteSqlWhere = "";
                        string strUpdateSqlWhere = "";
                        string strSql = "";
                        string strTable = "";

                        if (sqltableHead.tableType == 4)
                        {
                            string[] strTempPk = sqltableHead.strPK.Split(',');
                            for (int j = 0; j < strTempPk.Length; j++)
                            {
                                if (j > 0)
                                {
                                    strUpdateSqlWhere += " and ";
                                    strDeleteSqlWhere += " and ";
                                }
                                strUpdateSqlWhere += "b." + strTempPk[j] + "=" + "i." + strTempPk[j];
                                strDeleteSqlWhere += "i." + strTempPk[j] + "=" + strTempPk[j];
                            }

                            try
                            {
                                strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere, sqltableHead.strPK, 2, "");
                                if (strSql != "")
                                {
                                    ExecSql(strSql);
                                    Thread.Sleep(50);
                                }
                            }
                            catch
                            { }

                            strSql = "";
                            try
                            {
                                strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere, sqltableHead.strPK, 3, "");
                                if (strSql != "")
                                {
                                    ExecSql(strSql);
                                    Thread.Sleep(50);
                                }
                            }
                            catch
                            { }

                            strInsertSqlWhere += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + "'";
                        }
                        else
                        {
                            strInsertSqlWhere += sqltableHead.strTime + ">='" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                        }

                        if (sqltableHead.tableType == 2 || sqltableHead.tableType == 4)
                        {
                            strTable = sqltableHead.strTable;
                        }
                        else
                        {
                            strTable = sqltableHead.strTable + DateTime.Now.AddDays(-3).ToString("yyyyM");
                            ExecCreateHistory(DateTime.Now.AddDays(-3));
                        }
                        strSql = "";
                        strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, " TOP 300 ");

                       // File.AppendAllText("D:\\CzltMessage.txt", " 同步一天的数据：strInsertSqlWhere " + strInsertSqlWhere + " strTable " + strTable + " sqltableHead.strHead " + sqltableHead.strHead, Encoding.Unicode);
                        int x;
                        while (true)
                        {
                            try
                            {
                                x = ExecSql(strSql);
                            }
                            catch
                            {
                                break;
                            }
                            if (x < 300)
                                break;
                            Thread.Sleep(50);
                        }
                        //跨月处理
                        if (DateTime.Now.AddDays(-3).Month != DateTime.Now.Month && sqltableHead.tableType == 3)
                        {
                            strTable = sqltableHead.strTable + DateTime.Now.ToString("yyyyM");
                            ExecCreateHistory(DateTime.Now);
                            //strInsertSqlWhere += sqltableHead.strTime + ">='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                            strSql = "";
                            strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, " TOP 300 ");
                            int y;
                            while (true)
                            {
                                try
                                {
                                    y = ExecSql(strSql);
                                }
                                catch
                                {
                                    break;
                                }
                                if (y < 300)
                                    break;
                                Thread.Sleep(50);
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch { }
            if (tHisOneThread != null && tHisOneThread.ThreadState != ThreadState.Aborted)
            {
                tHisOneThread.Abort();
            }
        }
        #endregion


        #region 【方法：开启读取一天历史数据的线程】
        /// <summary>
        /// 开启读取一天历史数据的线程
        /// </summary>
        public void StartHisOneThread()
        {
            File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2,备机一直正常运行,主机同步一天历史数据！：" , Encoding.Unicode);
            //Czlt-2011-12-10 跟新时间数据
            //File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2", Encoding.Unicode);


            File.WriteAllText("D:\\CzltMessageCopy.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",开启读取一天历史数据的线程!", Encoding.Unicode);
            tHisOneThread = new Thread(this.ExecReadOtherUpdateLocalHisData);
            tHisOneThread.Name = "ExecReadOtherUpdateLocalHisData";
            tHisOneThread.Start();
        }
        #endregion

        #region 【方法：开启每一分钟获取实时数据，每十分钟获取三天前数据】
        public void StartRealHisDataThread()
        {
            if (!firstFlag)
            {
                //m_HisCount = 61;
                m_HisCount = 19;
                m_realTimeCount = 0;
                firstFlag = true;
            }
            else
            {
                m_HisCount = 1;
                m_realTimeCount = 0;
            }

            czltRTChange.AutoReset = true;
            czltRTChange.Interval = 10000;
            czltRTChange.Elapsed += new System.Timers.ElapsedEventHandler(czltRTChange_Elapsed);
            czltRTChange.Start();

            tCount.AutoReset = true;
            tCount.Interval = 10000;//10S
            tCount.Elapsed += new System.Timers.ElapsedEventHandler(tCount_Elapsed);
            tCount.Start();

            //Czlt-2012-3-23 同步考勤原始数据
            GetKqtj();

        }

        /// <summary>
        /// Czlt-2011-08-20 更新实时数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void czltRTChange_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            czltRTChange.Stop();
            //Czlt-2011-12-10 跟新时间数据
            //File.WriteAllText("D:\\CzltSS.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+",1",Encoding.Unicode);
            //File.WriteAllText("D:\\CzltMessageCopy.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",更新实时数据!", Encoding.Unicode);
            //Czlt-2011-08-22 设置定时器的关闭
            if (IsStopTime == true)
            {
                return;
            }
            if (m_ConnState)
            {
                CzltExecReadOtherUpdateLocalRealData();
            }
           
            czltRTChange.Start();

        }

        void tCount_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tCount.Stop();

            //Czlt-2011-08-22 设置定时器的关闭
            if (IsStopTime == true)
            {
                return;
            }

            //Czlt-2011-12-10 跟新时间数据
           // File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2", Encoding.Unicode);
            
          
            if (m_ConnState)
            {
                ////Czlt-2011-12-10 同步历史数据
                //ExecReadOtherUpdateLocalRealDataAndHisData();

                /***************Czlt-2011-12-10*备机更新主机的历史数据**start***************************************/
                if (CzltDays <= 3)
                {
                   // File.AppendAllText("D:\\CzltMessage.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\r\n 提示执行了那个防对方---同步三天数据：ExecReadOtherUpdateLocalRealDataAndHisData() " , Encoding.Unicode);
                    File.WriteAllText("D:\\CzltMessageCopy.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",同步三天历史数据!", Encoding.Unicode);
                    //同步三天的数据
                    ExecReadOtherUpdateLocalRealDataAndHisData();
                    CzltDays = 2;
                }
                else
                {
                   // File.AppendAllText("D:\\CzltMessage.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n 同步一个月的数据：CzltExecReadOtherUpdateLocalRealDataAndHisDataMonth()  天数：" + CzltDays, Encoding.Unicode);
                    File.WriteAllText("D:\\CzltMessageCopy.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",同步一个月历史数据!", Encoding.Unicode);
                    if (CzltDays >= 30)
                    {
                        //同步一个月的数据
                        CzltDays = 28;
                        CzltExecReadOtherUpdateLocalRealDataAndHisDataMonth();
                        CzltDays = 2;
                    }
                    else
                    {
                        CzltExecReadOtherUpdateLocalRealDataAndHisDataMonth();
                        CzltDays = 2;
 
                    }
                }
                /***************Czlt-2011-12-10*备机更新主机的历史数据**End***************************************/
            }
            tCount.Start();
        }
        #endregion

        #region 【方法：执行每一分钟获取实时数据，每十分钟获取三天前数据】
        /// <summary>
        /// Czlt-2011-08-20 更新实时数据
        /// </summary>
        public void CzltExecReadOtherUpdateLocalRealData()
        {
            try
            {
                File.WriteAllText("D:\\CzltSS.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",1,开始更新实时数据！", Encoding.Unicode);
                m_realTimeCount++;
                //m_HisCount++;
                string strSql = "";
                for (int i = 0; i < sqlTableHeadsAL.Count; i++)
                {
                    SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];

                    switch (sqltableHead.tableType)
                    {
                        case 1://实时数据
                            if (m_realTimeCount > 6)
                            {
                                try
                                {
                                    #region 【实时数据】
                                    string strUpdateSqlWhere = "";
                                    string strInsertSqlWhere = " 1=1 ";
                                    string strDeleteSqlWhere = "";
                                    string[] strTempPk = sqltableHead.strPK.Split(',');
                                    for (int j = 0; j < strTempPk.Length; j++)
                                    {
                                        if (j > 0)
                                        {
                                            strUpdateSqlWhere += " and ";
                                            //strInsertSqlWhere += " and ";
                                            strDeleteSqlWhere += " and ";
                                        }
                                        strUpdateSqlWhere += "b." + strTempPk[j] + "=" + "i." + strTempPk[j];
                                        //strInsertSqlWhere += strTempPk[j] + "=" + "i." + strTempPk[j];
                                        strDeleteSqlWhere += "i." + strTempPk[j] + "=" + strTempPk[j];
                                    }
                                    //删除
                                    strSql = "";
                                    strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere, sqltableHead.strPK, 2, "");
                                    try
                                    {
                                        if (strSql != "")
                                        {
                                            ExecSql(strSql);
                                            Thread.Sleep(50);
                                        }
                                    }
                                    catch
                                    { }
                                    //修改
                                    strSql = "";
                                    strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere, sqltableHead.strPK, 3, "");
                                    try
                                    {
                                        if (strSql != "")
                                        {
                                            ExecSql(strSql);
                                            Thread.Sleep(50);
                                        }
                                    }
                                    catch
                                    { }
                                    //添加
                                    strSql = "";
                                    strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");
                                    try
                                    {
                                        if (strSql != "")
                                        {
                                            ExecSql(strSql);
                                            Thread.Sleep(50);
                                        }
                                    }
                                    catch
                                    { }
                                    #endregion
                                }
                                catch (Exception er)
                                { }
                            }
                            break;
                        //case 3:
                        //case 2:
                        //case 4:
                        //    if (m_HisCount > 60)
                        //    {
                        //        try
                        //        {
                        //            #region 【历史数据】
                        //            string strInsertSqlWhere1 = "";
                        //            string strUpdateSqlWhere1 = "";
                        //            string strDeleteSqlWhere1 = "";

                        //            if (sqltableHead.tableType == 4)
                        //            {
                        //                string[] strTempPk1 = sqltableHead.strPK.Split(',');
                        //                for (int j = 0; j < strTempPk1.Length; j++)
                        //                {
                        //                    if (j > 0)
                        //                    {
                        //                        strUpdateSqlWhere1 += " and ";
                        //                        strDeleteSqlWhere1 += " and ";
                        //                    }
                        //                    strUpdateSqlWhere1 += "b." + strTempPk1[j] + "=" + "i." + strTempPk1[j];
                        //                    strDeleteSqlWhere1 += "i." + strTempPk1[j] + "=" + strTempPk1[j];
                        //                }
                        //                strSql = "";
                        //                strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere1, sqltableHead.strPK, 2, "");
                        //                try
                        //                {
                        //                    if (strSql != "")
                        //                    {
                        //                        ExecSql(strSql);
                        //                        Thread.Sleep(50);
                        //                    }
                        //                }
                        //                catch
                        //                { }
                        //                strSql = "";
                        //                strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere1, sqltableHead.strPK, 3, "");
                        //                try
                        //                {
                        //                    if (strSql != "")
                        //                    {
                        //                        ExecSql(strSql);
                        //                        Thread.Sleep(50);
                        //                    }
                        //                }
                        //                catch
                        //                { }

                        //                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + "'";
                        //            }
                        //            else
                        //            {
                        //                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                        //            }

                        //            strSql = "";
                        //            string strTable = "";
                        //            if (sqltableHead.tableType == 2 || sqltableHead.tableType == 4)
                        //            {
                        //                strTable = sqltableHead.strTable;
                        //            }
                        //            else
                        //            {
                        //                strTable = sqltableHead.strTable + DateTime.Now.AddDays(-3).ToString("yyyyM");
                        //                ExecCreateHistory(DateTime.Now.AddDays(-3));
                        //            }
                        //            strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, " TOP 1000 ");
                        //            int x;
                        //            while (true)
                        //            {
                        //                try
                        //                {
                        //                    x = ExecSql(strSql);
                        //                }
                        //                catch
                        //                {
                        //                    break;
                        //                }
                        //                if (x < 1000)
                        //                    break;
                        //                Thread.Sleep(50);
                        //            }
                        //            //跨月处理
                        //            if (DateTime.Now.AddDays(-3).Month != DateTime.Now.Month && sqltableHead.tableType == 3)
                        //            {
                        //                strTable = sqltableHead.strTable + DateTime.Now.ToString("yyyyM");
                        //                ExecCreateHistory(DateTime.Now);
                        //                //strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                        //                strSql = "";
                        //                strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, " TOP 1000 ");
                        //                int y;
                        //                while (true)
                        //                {
                        //                    try
                        //                    {
                        //                        y = ExecSql(strSql);
                        //                    }
                        //                    catch
                        //                    {
                        //                        break;
                        //                    }
                        //                    if (y < 1000)
                        //                        break;
                        //                    Thread.Sleep(50);
                        //                }
                        //            }
                        //            #endregion
                        //        }
                        //        catch (Exception eh)
                        //        {
                        //        }
                        //    }
                        //    break;
                        default:
                            break;
                    }
                    //Thread.Sleep(100);
                }
                if (m_realTimeCount > 6)
                    m_realTimeCount = 0;
                //if (m_HisCount > 60)
                //    m_HisCount = 0;



                File.WriteAllText("D:\\CzltSS.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",1,实时数据更新已完成！", Encoding.Unicode);
            }
            catch
            {
                if (m_realTimeCount > 6)
                    m_realTimeCount = 0;
                //if (m_HisCount > 60)
                //    m_HisCount = 0;
            }

        }

        /// <summary>
        /// Czlt-2011-08--20 更新历史数据
        /// </summary>
        public void ExecReadOtherUpdateLocalRealDataAndHisData()
        {
            try
            {
                // m_realTimeCount++;
                m_HisCount++;
                string strSql = "";
                for (int i = 0; i < sqlTableHeadsAL.Count; i++)
                {
                    SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];

                    switch (sqltableHead.tableType)
                    {
                        //case 1://实时数据
                        //    if (m_realTimeCount > 6)
                        //    {
                        //        try
                        //        {
                        //            #region 【实时数据】
                        //            string strUpdateSqlWhere = "";
                        //            string strInsertSqlWhere = " 1=1 ";
                        //            string strDeleteSqlWhere = "";
                        //            string[] strTempPk = sqltableHead.strPK.Split(',');
                        //            for (int j = 0; j < strTempPk.Length; j++)
                        //            {
                        //                if (j > 0)
                        //                {
                        //                    strUpdateSqlWhere += " and ";
                        //                    //strInsertSqlWhere += " and ";
                        //                    strDeleteSqlWhere += " and ";
                        //                }
                        //                strUpdateSqlWhere += "b." + strTempPk[j] + "=" + "i." + strTempPk[j];
                        //                //strInsertSqlWhere += strTempPk[j] + "=" + "i." + strTempPk[j];
                        //                strDeleteSqlWhere += "i." + strTempPk[j] + "=" + strTempPk[j];
                        //            }
                        //            //删除
                        //            strSql = "";
                        //            strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere, sqltableHead.strPK, 2, "");
                        //            try
                        //            {
                        //                if (strSql != "")
                        //                {
                        //                    ExecSql(strSql);
                        //                    Thread.Sleep(50);
                        //                }
                        //            }
                        //            catch
                        //            { }
                        //            //修改
                        //            strSql = "";
                        //            strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere, sqltableHead.strPK, 3, "");
                        //            try
                        //            {
                        //                if (strSql != "")
                        //                {
                        //                    ExecSql(strSql);
                        //                    Thread.Sleep(50);
                        //                }
                        //            }
                        //            catch
                        //            { }
                        //            //添加
                        //            strSql = "";
                        //            strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");
                        //            try
                        //            {
                        //                if (strSql != "")
                        //                {
                        //                    ExecSql(strSql);
                        //                    Thread.Sleep(50);
                        //                }
                        //            }
                        //            catch
                        //            { }
                        //            #endregion
                        //        }
                        //        catch (Exception er)
                        //        { }
                        //    }
                        //    break;
                        case 3:
                        case 2:
                        case 4:
                            if (m_HisCount > 18)
                            {
                                try
                                {
                                    #region 【历史数据】
                                    string strInsertSqlWhere1 = "";
                                    string strUpdateSqlWhere1 = "";
                                    string strDeleteSqlWhere1 = "";

                                    if (sqltableHead.tableType == 4)
                                    {
                                        string[] strTempPk1 = sqltableHead.strPK.Split(',');
                                        for (int j = 0; j < strTempPk1.Length; j++)
                                        {
                                            if (j > 0)
                                            {
                                                strUpdateSqlWhere1 += " and ";
                                                strDeleteSqlWhere1 += " and ";
                                            }
                                            strUpdateSqlWhere1 += "b." + strTempPk1[j] + "=" + "i." + strTempPk1[j];
                                            strDeleteSqlWhere1 += "i." + strTempPk1[j] + "=" + strTempPk1[j];
                                        }

                                        //Czlt-2014-02-14 优化kqtj
                                        if (!strUpdateSqlWhere1.Trim().Equals(""))
                                        {
                                            if (sqltableHead.strTable.Trim().Equals("kqtj"))
                                            {
                                                strUpdateSqlWhere1 += " and i.DataAttendance>='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + "' ";

                                            }
                                            else if (sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpTime"))
                                            {
                                                strUpdateSqlWhere1 += " and i.cYear>='" + DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd") + "' ";
                                            }
                                            else if (sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpNum"))
                                            {
                                                strUpdateSqlWhere1 += " and i.cYear>='" + DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd") + "' ";
                                            }

                                        }


                                        strSql = "";
                                        strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere1, sqltableHead.strPK, 2, "");
                                        try
                                        {
                                            if (strSql != "")
                                            {
                                                ExecSql(strSql);
                                                Thread.Sleep(50);
                                            }
                                        }
                                        catch
                                        { }
                                        strSql = "";
                                        strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere1, sqltableHead.strPK, 3, "");
                                        try
                                        {
                                            if (strSql != "")
                                            {
                                                ExecSql(strSql);
                                                Thread.Sleep(50);
                                            }
                                        }
                                        catch
                                        { }

                                        //Czlt-2011-12-12 注销
                                        //strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + "'";

                                        //************Czlt-2011-11-22*添加时间的查询条件**Start**************

                                        if (sqltableHead.strTable.Trim().Equals("kqtj"))
                                        {

                                            if (sqltableHead.strEndTime == null || sqltableHead.strEndTime.Equals(""))
                                            {
                                                //sqltableHead.strEndTime = Convert.ToDateTime(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss")).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                //strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";


                                                //czlt-2014-01-24 优化
                                                sqltableHead.strEndTime = Convert.ToDateTime(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")).ToString("yyyy-MM-dd");
                                                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + "' and " + sqltableHead.strTime + "<'" + Convert.ToDateTime(sqltableHead.strEndTime).AddDays(30).ToString("yyyy-MM-dd") + "' ";
                                            }
                                            else
                                            {
                                                string czltStrStartTime = sqltableHead.strEndTime;
                                                //sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                //strInsertSqlWhere1 += sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";

                                                //Czlt-2014-01-24 优化
                                                sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddDays(30).ToString("yyyy-MM-dd");
                                                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";
                                            }

                                        }
                                        else if (sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpTime") || sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpNum"))
                                        {
                                            if (sqltableHead.strEndTime == null || sqltableHead.strEndTime.Equals(""))
                                            {                                              
                                                //czlt-2014-01-24 优化
                                                sqltableHead.strEndTime = Convert.ToDateTime(DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd")).ToString("yyyy-MM-dd");
                                                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd") + "' and " + sqltableHead.strTime + "<'" + Convert.ToDateTime(sqltableHead.strEndTime).AddYears(1).ToString("yyyy-MM-dd") + "' ";
                                            }
                                            else
                                            {
                                                string czltStrStartTime = sqltableHead.strEndTime;                                         

                                                //Czlt-2014-01-24 优化
                                                sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddYears(1).ToString("yyyy-MM-dd");
                                                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";
                                            }

                                        }
                                        //************Czlt-2011-11-22*添加时间的查询条件**End**************


                                    }
                                    else
                                    {
                                        //Czlt-2011-12-10 注销
                                        // strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss") + "'";

                                        //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                                        if (sqltableHead.strEndTime == null || sqltableHead.strEndTime.Equals(""))
                                        {
                                            sqltableHead.strEndTime = Convert.ToDateTime(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss")).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                            strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss") + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                        }
                                        else
                                        {
                                            //if(sqltableHead.strEndTime)
                                            string czltStrStartTime = sqltableHead.strEndTime;
                                            sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                            strInsertSqlWhere1 += sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                        }
                                        //************Czlt-2011-11-22*添加时间的查询条件**End***************

                                    }

                                    strSql = "";
                                    string strTable = "";
                                    if (sqltableHead.tableType == 2 || sqltableHead.tableType == 4)
                                    {
                                        strTable = sqltableHead.strTable;
                                        //File.WriteAllText("D:\\CzltPZ.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",0,开始同步报警信息："+strTable, Encoding.Unicode);
                                        File.WriteAllText("D:\\CzltPZ.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",0,开始同步报警信息表！" , Encoding.Unicode);
                                    }
                                    else
                                    {
                                        strTable = sqltableHead.strTable + DateTime.Now.AddDays(-3).ToString("yyyyM");

                                        //File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2,开始同步历史表：" + strTable, Encoding.Unicode);
                                        File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2,开始同步历史信息表！" , Encoding.Unicode);

                                        ExecCreateHistory(DateTime.Now.AddDays(-3));
                                    }

                                    //Czlt-2011-12-10 注销
                                    //strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");
                                    int x;
                                    while (true)
                                    {
                                        try
                                        {
                                            //Czlt-2011-12-10 注销
                                            // x = ExecSql(strSql);

                                            //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                                            string czltStrStartTime = sqltableHead.strEndTime;
                                            string czTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                            if (sqltableHead.tableType == 4)
                                            {
                                                czTime = DateTime.Now.ToString("yyyy-MM-dd");
                                                if ((Convert.ToDateTime(czTime) - Convert.ToDateTime(czltStrStartTime)).TotalDays > 30)
                                                {
                                                    strInsertSqlWhere1 = "";
                                                    if (sqltableHead.strTable.Trim().Equals("kqtj"))
                                                    {

                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddDays(30).ToString("yyyy-MM-dd");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                    }
                                                    else if (sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpTime") || sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpNum"))
                                                    {
                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddYears(1).ToString("yyyy-MM-dd");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
 
                                                    }
                                                    strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");
                                                    x = ExecSql(strSql);
                                                }
                                                else
                                                {
                                                    //    //跳出以后给最后时间赋值                                               
                                                    if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalHours >= 8)
                                                    {
                                                        strInsertSqlWhere1 = "";

                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddDays(30).ToString("yyyy-MM-dd");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                        strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");

                                                        x = ExecSql(strSql);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                if ((Convert.ToDateTime(czTime) - Convert.ToDateTime(czltStrStartTime)).TotalHours > 1)
                                                {
                                                    strInsertSqlWhere1 = "";

                                                    sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                    strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                    strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");

                                                    //File.AppendAllText("D:\\CzltSqlConn.txt", " ExecReadOtherUpdateLocalRealDataAndHisData() 热备拷贝的天数 " + CzltDays + " 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n  执行SQL： " + strSql + "\r\n", Encoding.Unicode);
                                                    x = ExecSql(strSql);
                                                }
                                                else
                                                {
                                                    //    //跳出以后给最后时间赋值
                                                    //    //sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddHours(-12).ToString();

                                                    if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalMinutes >= 3)
                                                    {
                                                        strInsertSqlWhere1 = "";

                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                        strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");

                                                        //File.AppendAllText("D:\\CzltSqlConn.txt", " ExecReadOtherUpdateLocalRealDataAndHisData() 热备拷贝的天数 " + CzltDays + " 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n  执行SQL： " + strSql + "\r\n", Encoding.Unicode);
                                                        x = ExecSql(strSql);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }

                                                }
                                            }

                                            

                                            //************Czlt-2011-11-22*添加时间的查询条件**End****************
                                        }
                                        catch
                                        {
                                            break;
                                        }
                                        //czlt-2011-12-10 注销
                                        //if (x < 500)
                                        //    break;
                                        Thread.Sleep(50);
                                    }
                                    //跨月处理
                                    if (DateTime.Now.AddDays(-3).Month != DateTime.Now.Month && sqltableHead.tableType == 3)
                                    {
                                        strTable = sqltableHead.strTable + DateTime.Now.ToString("yyyyM");
                                        ExecCreateHistory(DateTime.Now);

                                        //Czlt-2011-12-10 注销
                                        //strSql = "";
                                        //strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, " TOP 500 ");
                                        int y;
                                        while (true)
                                        {
                                            try
                                            {
                                                //czlt-2011-12-10 注销
                                                //y = ExecSql(strSql);

                                                //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                                                string czltStrStartTime = sqltableHead.strEndTime;
                                                if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalHours > 1)
                                                {

                                                    strInsertSqlWhere1 = "";
                                                    sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                    strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                    strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");
                                                    y = ExecSql(strSql);
                                                }
                                                else
                                                {
                                                //    //跳出之前给最后时间赋值
                                                //    sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddHours(-12).ToString();
                                                    if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalMinutes >=3)
                                                    {

                                                        strInsertSqlWhere1 = "";
                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                        strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");
                                                        y = ExecSql(strSql);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        //    //跳出之前给最后时间赋值
                                                        //    sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddHours(-12).ToString();
                                                        break;
                                                    }
                                                }
                                                //************Czlt-2011-11-22*添加时间的查询条件**End*************
                                            }
                                            catch
                                            {
                                                break;
                                            }
                                            //Czlt-2011-12-10 注销
                                            //if (y < 500)
                                            //    break;
                                            Thread.Sleep(50);
                                        }
                                    }
                                    #endregion
                                }
                                catch (Exception eh)
                                {
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    //Thread.Sleep(100);
                }
                //if (m_realTimeCount > 6)
                //    m_realTimeCount = 0;
                if (m_HisCount > 18)
                    m_HisCount = 0;
            }
            catch
            {
                //if (m_realTimeCount > 6)
                //    m_realTimeCount = 0;
                if (m_HisCount > 18)
                    m_HisCount = 0;
            }
        }

        #endregion

        #region 【方法：开始设置异地的配置信息】
        /// <summary>
        /// 开始设置异地配置信息
        /// </summary>
        public void StartConfigThread()
        {
            tConfig.AutoReset = true;
            tConfig.Interval = 1000;
            tConfig.Elapsed += new System.Timers.ElapsedEventHandler(tConfig_Elapsed);

            DateTime dtNow = DateTime.Now;

            for (int i = 0; i < sqlTableHeadsAL.Count; i++)
            {
                SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];
                if (sqltableHead.tableType == 0)
                {
                    sqltableHead.dtimeConfig = dtNow;
                    sqlTableHeadsAL[i] = sqltableHead;
                }
            }
            tConfig.Start();
        }

        void tConfig_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tConfig.Stop();
            ExecUpdateConfig();
            tConfig.Start();
        }
        #endregion

        #region 【方法：执行配置信息改变，修改异地配置信息】
        public void ExecUpdateConfig()
        {
            try
            {
                string strSql = "";
                if (m_ConnState)//主备机连接状态
                {
                    DateTime dtNow = DateTime.Now;
                    for (int i = 0; i < sqlTableHeadsAL.Count; i++)
                    {
                        SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];
                        if (sqltableHead.tableType == 0)
                        {
                            if (m_ConnState == true && sqltableHead.strConfigFile != "" && File.Exists(System.Windows.Forms.Application.StartupPath.ToString() + @"\config//" + sqltableHead.strConfigFile) && sqltableHead.dtimeConfig < File.GetLastWriteTime(System.Windows.Forms.Application.StartupPath.ToString() + @"\config//" + sqltableHead.strConfigFile))
                            {
                                string strUpdateSqlWhere = "";
                                string strInsertSqlWhere = " 1=1 ";
                                string strDeleteSqlWhere = "";
                                string[] strTempPk = sqltableHead.strPK.Split(',');
                                for (int j = 0; j < strTempPk.Length; j++)
                                {
                                    if (j > 0)
                                    {
                                        strUpdateSqlWhere += " and ";
                                        //strInsertSqlWhere += " and ";
                                        strDeleteSqlWhere += " and ";
                                    }
                                    strUpdateSqlWhere += "b." + strTempPk[j] + "=" + "i." + strTempPk[j];
                                    //strInsertSqlWhere += strTempPk[j] + "=" + "b." + strTempPk[j];
                                    strDeleteSqlWhere += "b." + strTempPk[j] + "=" + strTempPk[j];
                                }

                                //删除
                                if (sqltableHead.strTable.Equals("G_DPicFile") || sqltableHead.strTable.Equals("G_DConfigFile"))
                                {
                                    strSql = "Delete from [128RB].[KJ128N].[dbo].[" + sqltableHead.strTable + "]";
                                }
                                else
                                {
                                    strSql = ReadLocalUpdateOther(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere, sqltableHead.strPK, 2, "");
                                }
                                try
                                {
                                    if (strSql != "")
                                    {
                                        ExecSql(strSql);
                                        Thread.Sleep(50);
                                    }
                                }
                                catch
                                { }
                                //修改
                                if (!sqltableHead.strTable.Equals("G_DPicFile") && !sqltableHead.strTable.Equals("G_DConfigFile"))
                                {
                                    strSql = ReadLocalUpdateOther(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere, sqltableHead.strPK, 3, "");
                                    try
                                    {
                                        if (strSql != "")
                                        {
                                            ExecSql(strSql);
                                            Thread.Sleep(50);
                                        }
                                    }
                                    catch
                                    { }
                                }

                                //添加
                                strSql = ReadLocalUpdateOther(sqltableHead.strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");
                                try
                                {
                                    if (strSql != "")
                                    {
                                        ExecSql(strSql);
                                        Thread.Sleep(50);
                                    }
                                }
                                catch
                                { }

                                sqltableHead.dtimeConfig = dtNow;
                                sqlTableHeadsAL[i] = sqltableHead;
                            }
                        }
                    }
                }
            }
            catch
            { }
        }
        #endregion

        #region 【方法：执行创建链接服务器】
        public void ExecCreadLineServer(string strIp)
        {
            string strSql;
            strSql = "if exists(select   *   from   master.dbo.sysservers   where   srvname   ='128RB') begin exec sp_droplinkedsrvlogin '128RB','" + GetConfigValue("uid").ToString().Trim() + "' exec sp_dropserver '128RB','droplogins' end exec sp_addlinkedserver  '128RB','','SQLOLEDB','" + strIp + "','','','KJ128N' exec sp_addlinkedsrvlogin '128RB','false',null,'" + GetConfigValue("uid").ToString().Trim() + "','" + GetConfigValue("pwd").ToString().Trim() + "'";
            ExecSql(strSql);
        }
        #endregion

        #region 【方法：创建历史表】
        public void ExecCreateHistory(DateTime dtTime)
        {
            SqlParameter[] para = { new SqlParameter("@DetectTime", SqlDbType.DateTime, 8) };
            para[0].Value = dtTime;
            try
            {
                SqlHelper.ExecuteNonQuery(strConnection, CommandType.StoredProcedure, "CreateHistory", para);
            }
            catch { }
        }
        #endregion



        #region 【方法：Czlt-2011-12-12 开启读取一个月的历史数据的线程】
        /// <summary>
        /// 开启读取一天历史数据的线程
        /// </summary>
        public void CzltStartHisMthThread()
        {
            File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2,备机一直正常运行,主机同步一个月历史数据！" , Encoding.Unicode);
            tHisOneThread = new Thread(this.CzltExecReadOtherUpdateLocalHisDataMoth);
            tHisOneThread.Name = "CzltExecReadOtherUpdateLocalHisDataMoth";
            tHisOneThread.Start();
        }
        #endregion

        #region 【方法：Czlt-2011-12-12 第一次打开的时候获取一个月的历史数据,读异地存本地】
        /// <summary>
        /// 获取一天的历史数据，读异地存本地
        /// </summary>
        public void CzltExecReadOtherUpdateLocalHisDataMoth()
        {
            try
            {
                for (int i = 0; i < sqlTableHeadsAL.Count; i++)
                {
                    SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];
                    if ((sqltableHead.tableType == 2 || sqltableHead.tableType == 3 || sqltableHead.tableType == 4) && m_ConnState == true)
                    {
                        string strInsertSqlWhere = "";
                        string strDeleteSqlWhere = "";
                        string strUpdateSqlWhere = "";
                        string strSql = "";
                        string strTable = "";

                        if (sqltableHead.tableType == 4)
                        {
                            string[] strTempPk = sqltableHead.strPK.Split(',');
                            for (int j = 0; j < strTempPk.Length; j++)
                            {
                                if (j > 0)
                                {
                                    strUpdateSqlWhere += " and ";
                                    strDeleteSqlWhere += " and ";
                                }
                                strUpdateSqlWhere += "b." + strTempPk[j] + "=" + "i." + strTempPk[j];
                                strDeleteSqlWhere += "i." + strTempPk[j] + "=" + strTempPk[j];
                            }

                            try
                            {
                                strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere, sqltableHead.strPK, 2, "");
                                if (strSql != "")
                                {
                                    ExecSql(strSql);
                                    Thread.Sleep(50);
                                }
                            }
                            catch
                            { }

                            strSql = "";
                            try
                            {
                                strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere, sqltableHead.strPK, 3, "");
                                if (strSql != "")
                                {
                                    ExecSql(strSql);
                                    Thread.Sleep(50);
                                }
                            }
                            catch
                            { }

                            strInsertSqlWhere += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + "'";
                        }
                        else
                        {
                            //strInsertSqlWhere += sqltableHead.strTime + ">='" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss") + "'";


                            //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                            if (sqltableHead.strEndTime == null || sqltableHead.strEndTime.Equals(""))
                            {
                                sqltableHead.strEndTime = Convert.ToDateTime(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss")).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                strInsertSqlWhere += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";

                            }
                            else
                            {
                                string czltStrStartTime = sqltableHead.strEndTime;
                                sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                strInsertSqlWhere += sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";

                            }
                            //************Czlt-2011-11-22*添加时间的查询条件**End**************
                        }

                        if (sqltableHead.tableType == 2 || sqltableHead.tableType == 4)
                        {
                            strTable = sqltableHead.strTable;
                            //File.WriteAllText("D:\\CzltPZ.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",0,开始同步报警信息：" + strTable, Encoding.Unicode);
                            File.WriteAllText("D:\\CzltPZ.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",0,开始同步报警信息表！" , Encoding.Unicode);

                        }
                        else
                        {
                            if (CzltDays <= 1 || CzltDays > 30)
                            {
                                CzltDays = 28;
                            }
                           // File.AppendAllText("D:\\CzltSqlConn.txt", " 热备拷贝的天数 " + CzltDays + " 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n   ", Encoding.Unicode);

                            strTable = sqltableHead.strTable + DateTime.Now.AddDays(-CzltDays).ToString("yyyyM");
                            //File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2,开始同步历史表：" + strTable, Encoding.Unicode);
                            File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2,开始同步历史信息表！" , Encoding.Unicode);
                            ExecCreateHistory(DateTime.Now.AddDays(-CzltDays));
                        }
                        //strSql = "";
                        //strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, " TOP 300 ");
                        int x;
                        while (true)
                        {
                            try
                            {
                                // x = ExecSql(strSql);

                                //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                                string czltStrStartTime = sqltableHead.strEndTime;
                                if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalHours > 1)
                                {
                                    strInsertSqlWhere = "";

                                    sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                    strInsertSqlWhere = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                    strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");

                                    x = ExecSql(strSql);
                                }
                                else
                                {                                

                                    if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalMinutes >= 3)
                                    {
                                        strInsertSqlWhere = "";

                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                        strInsertSqlWhere = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                        strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");

                                        x = ExecSql(strSql);

                                       
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                //************Czlt-2011-11-22*添加时间的查询条件**End****************
                            }
                            catch
                            {
                                break;
                            }
                            //if (x < 300)
                            //    break;
                            Thread.Sleep(50);
                        }
                        //跨月处理
                        if (DateTime.Now.AddDays(-CzltDays).Month != DateTime.Now.Month && sqltableHead.tableType == 3)
                        {
                            strTable = sqltableHead.strTable + DateTime.Now.ToString("yyyyM");
                            ExecCreateHistory(DateTime.Now);

                            //Czlt-2011-12-10 注销
                            //strSql = "";
                            //strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, " TOP 300 ");
                            int y;
                            while (true)
                            {
                                try
                                {
                                    // y = ExecSql(strSql);

                                    //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                                    string czltStrStartTime = sqltableHead.strEndTime;
                                    if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalHours > 1)
                                    {
                                        strInsertSqlWhere = "";

                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                        strInsertSqlWhere = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                        strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");

                                        y = ExecSql(strSql);
                                    }
                                    else
                                    {
                                    //    //跳出以后给最后时间赋值
                                    //    sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddHours(-12).ToString();

                                        if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalMinutes >=3 )
                                        {
                                            strInsertSqlWhere = "";

                                            sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                            strInsertSqlWhere = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                            strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere, sqltableHead.strPK, 1, "");

                                            y = ExecSql(strSql);
                                            break;
                                        }
                                        else
                                        {
                                           
                                            break;
                                        }
                                    }
                                    //************Czlt-2011-11-22*添加时间的查询条件**End****************
                                }
                                catch
                                {
                                    break;
                                }
                                //if (y < 300)
                                //    break;
                                Thread.Sleep(50);
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch { }
            if (tHisOneThread != null && tHisOneThread.ThreadState != ThreadState.Aborted)
            {
                tHisOneThread.Abort();
            }
        }
        #endregion

        #region 【方法：Czlt-2011-12-12 更新备机历史数据】
        /// <summary>
        /// Czlt-2011-08-20 更新历史数据
        /// </summary>
        public void CzltExecReadOtherUpdateLocalRealDataAndHisDataMonth()
        {
            try
            {
                m_HisCount++;
                string strSql = "";
                for (int i = 0; i < sqlTableHeadsAL.Count; i++)
                {
                    SqlTableHead sqltableHead = (SqlTableHead)sqlTableHeadsAL[i];

                    switch (sqltableHead.tableType)
                    {
                        case 3:
                        case 2:
                        case 4:
                            if (m_HisCount > 18)
                            {
                                try
                                {
                                    #region 【历史数据】
                                    string strInsertSqlWhere1 = "";
                                    string strUpdateSqlWhere1 = "";
                                    string strDeleteSqlWhere1 = "";

                                    if (sqltableHead.tableType == 4)
                                    {
                                        string[] strTempPk1 = sqltableHead.strPK.Split(',');
                                        for (int j = 0; j < strTempPk1.Length; j++)
                                        {
                                            if (j > 0)
                                            {
                                                strUpdateSqlWhere1 += " and ";
                                                strDeleteSqlWhere1 += " and ";
                                            }
                                            strUpdateSqlWhere1 += "b." + strTempPk1[j] + "=" + "i." + strTempPk1[j];
                                            strDeleteSqlWhere1 += "i." + strTempPk1[j] + "=" + strTempPk1[j];
                                        }

                                        //Czlt-2014-01-25 添加修改条件
                                        if (!strUpdateSqlWhere1.Trim().Equals(""))
                                        {
                                            if (sqltableHead.strTable.Trim().Equals("kqtj"))
                                            {
                                                strUpdateSqlWhere1 += " and i.DataAttendance>='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + "' ";

                                            }
                                            else if (sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpTime"))
                                            {
                                                strUpdateSqlWhere1 += " and i.cYear>='" + DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd") + "' ";
                                            }
                                            else if (sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpNum"))
                                            {
                                                strUpdateSqlWhere1 += " and i.cYear>='" + DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd") + "' ";
                                            }

                                        }

                                        strSql = "";
                                        strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strDeleteSqlWhere1, sqltableHead.strPK, 2, "");
                                        try
                                        {
                                            if (strSql != "")
                                            {
                                                ExecSql(strSql);
                                                Thread.Sleep(50);
                                            }
                                        }
                                        catch
                                        { }
                                        strSql = "";
                                        strSql = ReadOtherUpdateLocal(sqltableHead.strTable, sqltableHead.strHead, strUpdateSqlWhere1, sqltableHead.strPK, 3, "");
                                        try
                                        {
                                            if (strSql != "")
                                            {
                                                ExecSql(strSql);
                                                Thread.Sleep(50);
                                            }
                                        }
                                        catch
                                        { }

                                        //Czlt-2011-12-12 注销
                                        //strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + "'";

                                        //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                                        if (sqltableHead.strTable.Trim().Equals("kqtj"))
                                        {
                                            if (sqltableHead.strEndTime == null || sqltableHead.strEndTime.Equals(""))
                                            {
                                                //sqltableHead.strEndTime = Convert.ToDateTime(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss")).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                //strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";

                                                //czlt-2014-01-24 优化
                                                sqltableHead.strEndTime = Convert.ToDateTime(DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd")).AddDays(30).ToString("yyyy-MM-dd");
                                                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd") + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";

                                            }
                                            else
                                            {
                                                string czltStrStartTime = sqltableHead.strEndTime;
                                                //sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                //strInsertSqlWhere1 += sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";
                                                //Czlt-2014-01-24 优化
                                                sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddDays(30).ToString("yyyy-MM-dd");
                                                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";

                                            }
                                        }
                                        else if (sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpTime") || sqltableHead.strTable.Trim().Equals("Czlt_MonthEmpNum"))
                                        
                                        {
                                            if (sqltableHead.strEndTime == null || sqltableHead.strEndTime.Equals(""))
                                            {                                                

                                                //czlt-2014-01-24 优化
                                                sqltableHead.strEndTime = Convert.ToDateTime(DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd")).ToString("yyyy-MM-dd");
                                                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd") + "' and " + sqltableHead.strTime + "<'" + Convert.ToDateTime(sqltableHead.strEndTime).AddYears(1).ToString("yyyy-MM-dd") + "' ";

                                            }
                                            else
                                            {
                                                string czltStrStartTime = sqltableHead.strEndTime;                                               
                                                //Czlt-2014-01-24 优化
                                                sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddYears(1).ToString("yyyy-MM-dd");
                                                strInsertSqlWhere1 += sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + "<'" + sqltableHead.strEndTime + "' ";

                                            }
                                        }
                                        //************Czlt-2011-11-22*添加时间的查询条件**End**************


                                    }
                                    else
                                    {
                                        //Czlt-2011-12-10 注销
                                        // strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss") + "'";

                                        //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                                        if (sqltableHead.strEndTime == null || sqltableHead.strEndTime.Equals(""))
                                        {
                                            sqltableHead.strEndTime = Convert.ToDateTime(DateTime.Now.AddDays(-CzltDays).ToString("yyyy-MM-dd HH:mm:ss")).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                            strInsertSqlWhere1 += sqltableHead.strTime + ">='" + DateTime.Now.AddDays(-CzltDays).ToString("yyyy-MM-dd HH:mm:ss") + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                        }
                                        else
                                        {
                                            string czltStrStartTime = sqltableHead.strEndTime;
                                            sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                            strInsertSqlWhere1 += sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                        }
                                        //************Czlt-2011-11-22*添加时间的查询条件**End***************

                                    }

                                   

                                    strSql = "";
                                    string strTable = "";
                                    if (sqltableHead.tableType == 2 || sqltableHead.tableType == 4)
                                    {
                                        strTable = sqltableHead.strTable;
                                        //File.WriteAllText("D:\\CzltPZ.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",0,开始同步报警信息：" + strTable, Encoding.Unicode);
                                        File.WriteAllText("D:\\CzltPZ.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",0,开始同步报警信息表！" , Encoding.Unicode);
                                    }
                                    else
                                    {
                                        strTable = sqltableHead.strTable + DateTime.Now.AddDays(-CzltDays).ToString("yyyyM");
                                        //File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2,开始同步历史表：" + strTable, Encoding.Unicode);
                                        File.WriteAllText("D:\\CzltHis.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",2,开始同步历史信息表！" , Encoding.Unicode);
                                        ExecCreateHistory(DateTime.Now.AddDays(-CzltDays));
                                    }

                                   
                                    int x;
                                    while (true)
                                    {
                                        try
                                        {
                                            //Czlt-2011-12-10 注销
                                            // x = ExecSql(strSql);

                                            //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                                            string czltStrStartTime = sqltableHead.strEndTime;
                                            if (sqltableHead.tableType == 4)
                                            {
                                                string czTime = DateTime.Now.ToString("yyyy-MM-dd");
                                                if ((Convert.ToDateTime(czTime) - Convert.ToDateTime(czltStrStartTime)).TotalDays > 30)
                                                {
                                                    strInsertSqlWhere1 = "";

                                                    if (sqltableHead.strTable.Trim().Equals("kqtj"))
                                                    {
                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddDays(30).ToString("yyyy-MM-dd");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                    }
                                                    else
                                                    {
                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddYears(1).ToString("yyyy-MM-dd");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                    }
                                                    strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");
                                                    x = ExecSql(strSql);
                                                }
                                                else
                                                {
                                                    //    //跳出以后给最后时间赋值                                               
                                                    if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalHours >= 8)
                                                    {
                                                        strInsertSqlWhere1 = "";

                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddDays(30).ToString("yyyy-MM-dd");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                        strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");

                                                        x = ExecSql(strSql);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalHours > 1)
                                                {
                                                    strInsertSqlWhere1 = "";

                                                    sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                    strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                    strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");

                                                    // File.AppendAllText("D:\\CzltSqlConn.txt", " 热备拷贝的天数 " + CzltDays + " 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n  执行SQL： " + strSql+"\r\n", Encoding.Unicode);
                                                    x = ExecSql(strSql);
                                                }
                                                else
                                                {
                                                    if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalMinutes >= 3)
                                                    {
                                                        strInsertSqlWhere1 = "";

                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                        strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");

                                                        // File.AppendAllText("D:\\CzltSqlConn.txt", " 热备拷贝的天数 " + CzltDays + " 打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n  执行SQL： " + strSql+"\r\n", Encoding.Unicode);
                                                        x = ExecSql(strSql);
                                                    }


                                                    break;
                                                }
                                            }
                                            //************Czlt-2011-11-22*添加时间的查询条件**End****************
                                        }
                                        catch
                                        {
                                            break;
                                        }

                                        Thread.Sleep(50);
                                    }
                                    //跨月处理
                                    if (DateTime.Now.AddDays(-CzltDays).Month != DateTime.Now.Month && sqltableHead.tableType == 3)
                                    {
                                        strTable = sqltableHead.strTable + DateTime.Now.ToString("yyyyM");
                                        ExecCreateHistory(DateTime.Now);

                                        //Czlt-2011-12-10 注销
                                        //strSql = "";
                                        //strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, " TOP 500 ");
                                        int y;
                                        while (true)
                                        {
                                            try
                                            {
                                                //czlt-2011-12-10 注销
                                                //y = ExecSql(strSql);

                                                //************Czlt-2011-11-22*添加时间的查询条件**Start**************
                                                string czltStrStartTime = sqltableHead.strEndTime;
                                                if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalHours > 1)
                                                {
                                                    strInsertSqlWhere1 = "";
                                                    sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                    strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                    strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");
                                                    y = ExecSql(strSql);
                                                }
                                                else
                                                {
                                                    if ((DateTime.Now - Convert.ToDateTime(czltStrStartTime)).TotalMinutes >=3)
                                                    {
                                                        strInsertSqlWhere1 = "";
                                                        sqltableHead.strEndTime = Convert.ToDateTime(sqltableHead.strEndTime).AddMinutes(60).ToString("yyyy-MM-dd HH:mm:ss");
                                                        strInsertSqlWhere1 = sqltableHead.strTime + ">='" + czltStrStartTime + "' and " + sqltableHead.strTime + " <'" + sqltableHead.strEndTime + "' ";
                                                        strSql = ReadOtherUpdateLocal(strTable, sqltableHead.strHead, strInsertSqlWhere1, sqltableHead.strPK, 1, "");
                                                        y = ExecSql(strSql);
                                                    }
                                                    break;
                                                }

                                                //************Czlt-2011-11-22*添加时间的查询条件**End*************
                                            }
                                            catch
                                            {
                                                break;
                                            }

                                            Thread.Sleep(50);
                                        }
                                    }
                                    #endregion
                                }
                                catch (Exception eh)
                                {
                                }
                            }
                            break;
                        default:
                            break;
                    }

                }

                if (m_HisCount > 18)
                    m_HisCount = 0;
            }
            catch
            {
                if (m_HisCount > 18)
                    m_HisCount = 0;
            }
        }
        #endregion


        #region【同步实时数据】
        /// <summary>
        /// 主机开启是假如备机正常运行 拷贝备机的实时信息
        /// </summary>
        public void CzltUpdateRT()
        {
            try
            {
                string strSql = string.Empty;
                //1.实时上井口分站
                //删除
                strSql = "Delete [InMineStationInfo] from [InMineStationInfo] d where  not exists(select CodeSenderAddress from [128RB].[KJ128N].[dbo].[InMineStationInfo] c where d.CodeSenderAddress=c.CodeSenderAddress)";
                ExecSql(strSql);
                //修改
                strSql = "update [InMineStationInfo] set StationHeadID=i.StationHeadID,StationAddress=i.StationAddress,StationHeadAddress=i.StationHeadAddress,CodeSenderAddress=i.CodeSenderAddress,InMineStationTime=i.InMineStationTime from [InMineStationInfo] b , [128RB].[KJ128N].[dbo].[InMineStationInfo] i where b.CodeSenderAddress=i.CodeSenderAddress";
                ExecSql(strSql);

                //新增
                strSql = "Insert into [InMineStationInfo](StationHeadID,StationAddress,StationHeadAddress,CodeSenderAddress,InMineStationTime) select StationHeadID,StationAddress,StationHeadAddress,CodeSenderAddress,InMineStationTime from [128RB].[KJ128N].[dbo].[InMineStationInfo] b where  1=1  and not exists(select CodeSenderAddress from [InMineStationInfo] c where  1=1  and c.CodeSenderAddress=b.CodeSenderAddress)";
                ExecSql(strSql);

                //2.实时下井表 RT_InOutMine
                //删除
                strSql = "Delete [RT_InOutMine] from [RT_InOutMine] d where  not exists(select CodeSenderAddress from [128RB].[KJ128N].[dbo].[RT_InOutMine] c where d.CodeSenderAddress=c.CodeSenderAddress)";
                ExecSql(strSql);
                //修改
                strSql = "update [RT_InOutMine] set StationHeadID=i.StationHeadID,CsSetID=i.CsSetID,InTime=i.InTime,CodeSenderAddress=i.CodeSenderAddress from [RT_InOutMine] b , [128RB].[KJ128N].[dbo].[RT_InOutMine] i where b.CodeSenderAddress=i.CodeSenderAddress";
                ExecSql(strSql);

                //新增
                strSql = "Insert into [RT_InOutMine](StationHeadID,CsSetID,InTime,CodeSenderAddress) select StationHeadID,CsSetID,InTime,CodeSenderAddress from [128RB].[KJ128N].[dbo].[RT_InOutMine] b where  1=1  and not exists(select CodeSenderAddress from [RT_InOutMine] c where  1=1  and c.CodeSenderAddress=b.CodeSenderAddress)";
                ExecSql(strSql);

                //3.实时考勤表 RealTimeAttendance
                //删除
                strSql = "Delete [RealTimeAttendance] from [RealTimeAttendance] d where  not exists(select BlockID from [128RB].[KJ128N].[dbo].[RealTimeAttendance] c where d.BlockID=c.BlockID)";
                ExecSql(strSql);
                //修改
                strSql = "update [RealTimeAttendance] set BlockID=i.BlockID,EmployeeID=i.EmployeeID,EmployeeName=i.EmployeeName,DeptID=i.DeptID ,ClassID=i.ClassID,ClassShortName=i.ClassShortName,BeginWorkTime=i.BeginWorkTime,IsLate=i.IsLate,TimerIntervalID=i.TimerIntervalID,DataAttendance=i.DataAttendance from [RealTimeAttendance] b , [128RB].[KJ128N].[dbo].[RealTimeAttendance] i where b.BlockID=i.BlockID";
                ExecSql(strSql);
                //新增
                strSql = "Insert into [RealTimeAttendance](BlockID,EmployeeID,EmployeeName,DeptID,ClassID,ClassShortName,BeginWorkTime,IsLate,TimerIntervalID,DataAttendance) select BlockID,EmployeeID,EmployeeName,DeptID,ClassID,ClassShortName,BeginWorkTime,IsLate,TimerIntervalID,DataAttendance from [128RB].[KJ128N].[dbo].[RealTimeAttendance] b where  1=1  and not exists(select BlockID from [RealTimeAttendance] c where  1=1  and c.BlockID=b.BlockID)";
                ExecSql(strSql);


                //4.实时进出读卡分站表 RT_InStationHeadInfo
                //删除
                strSql = "Delete [RT_InStationHeadInfo] from [RT_InStationHeadInfo] d where  not exists(select CodeSenderAddress from [128RB].[KJ128N].[dbo].[RT_InStationHeadInfo] c where d.CodeSenderAddress=c.CodeSenderAddress)";
                ExecSql(strSql);
                //修改
                strSql = "update [RT_InStationHeadInfo] set CodeSenderAddress=i.CodeSenderAddress,StationHeadID=i.StationHeadID,CsSetID=i.CsSetID,CsTypeID=i.CsTypeID ,UserID=i.UserID,InAntennaPlace=i.InAntennaPlace,InStationHeadTime=i.InStationHeadTime,InOutFlag=i.InOutFlag,StationHeadTime=i.StationHeadTime,Directional=i.Directional from [RT_InStationHeadInfo] b , [128RB].[KJ128N].[dbo].[RT_InStationHeadInfo] i where b.CodeSenderAddress=i.CodeSenderAddress";
                ExecSql(strSql);
                //新增
                strSql = "Insert into [RT_InStationHeadInfo](CodeSenderAddress,StationHeadID,CsSetID,CsTypeID,UserID,InAntennaPlace,InStationHeadTime,InOutFlag,StationHeadTime,Directional) select CodeSenderAddress,StationHeadID,CsSetID,CsTypeID,UserID,InAntennaPlace,InStationHeadTime,InOutFlag,StationHeadTime,Directional from [128RB].[KJ128N].[dbo].[RT_InStationHeadInfo] b where  1=1  and not exists(select CodeSenderAddress from [RT_InStationHeadInfo] c where  1=1  and c.CodeSenderAddress=b.CodeSenderAddress)";
                ExecSql(strSql);

                //5.实时进出读卡分站临时表  RTInstationHeadTmep
                //删除
                strSql = "Delete [RTInstationHeadTmep] from [RTInstationHeadTmep] d where  not exists(select CodeSenderAddress from [128RB].[KJ128N].[dbo].[RTInstationHeadTmep] c where d.CodeSenderAddress=c.CodeSenderAddress)";
                ExecSql(strSql);
                //修改
                strSql = "update [RTInstationHeadTmep] set CodeSenderAddress=i.CodeSenderAddress,StationAddress=i.StationAddress,StationHeadAddress=i.StationHeadAddress,CsTypeID=i.CsTypeID ,UserID=i.UserID,CsSetID=i.CsSetID,InStationHeadTime=i.InStationHeadTime from [RTInstationHeadTmep] b , [128RB].[KJ128N].[dbo].[RTInstationHeadTmep] i where b.CodeSenderAddress=i.CodeSenderAddress";
                ExecSql(strSql);
                //新增
                strSql = "Insert into [RTInstationHeadTmep](CodeSenderAddress,StationAddress,StationHeadAddress,CsSetID,CsTypeID,UserID,InStationHeadTime) select CodeSenderAddress,StationAddress,StationHeadAddress,CsSetID,CsTypeID,UserID,InStationHeadTime from [128RB].[KJ128N].[dbo].[RTInstationHeadTmep] b where  1=1  and not exists(select CodeSenderAddress from [RTInstationHeadTmep] c where  1=1  and c.CodeSenderAddress=b.CodeSenderAddress and c.StationAddress=b.StationAddress and c.StationHeadAddress=b.StationHeadAddress)";
                ExecSql(strSql);
            }
            catch { }

        }
        #endregion

        #region [Czlt-2012-03-23 同步考勤原始数据]

        /// <summary>
        /// 同步
        /// </summary>
        public void GetKqtj()
        {
            try
            {
                string startTime = DateTime.Now.AddMonths(-1).ToString("yyyy-MM").ToString() + "-01 00:00:00";
                string strSql = string.Empty;
                strSql = "Insert into [kqtj]([DataAttendance],[blockid],[EmpName],[Deptid],[DeptName],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31]) select [DataAttendance],[blockid],[EmpName],[Deptid],[DeptName],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31] from [128RB].[KJ128N].[dbo].[kqtj] b where DataAttendance>='" + startTime + "'  and not exists(select DataAttendance from [kqtj] c where DataAttendance>='" + startTime + "'  and c.DataAttendance=b.DataAttendance and c.blockid=b.blockid)";
                ExecSql(strSql);
                strSql = "update [kqtj] set [DataAttendance]=i.[DataAttendance],[blockid]=i.[blockid],[EmpName]=i.[EmpName],[Deptid]=i.[Deptid],[DeptName]=i.[DeptName],[1]=i.[1],[2]=i.[2],[3]=i.[3],[4]=i.[4],[5]=i.[5],[6]=i.[6],[7]=i.[7],[8]=i.[8],[9]=i.[9],[10]=i.[10],[11]=i.[11],[12]=i.[12],[13]=i.[13],[14]=i.[14],[15]=i.[15],[16]=i.[16],[17]=i.[17],[18]=i.[18],[19]=i.[19],[20]=i.[20],[21]=i.[21],[22]=i.[22],[23]=i.[23],[24]=i.[24],[25]=i.[25],[26]=i.[26],[27]=i.[27],[28]=i.[28],[29]=i.[29],[30]=i.[30],[31]=i.[31] from [kqtj] b , [128RB].[KJ128N].[dbo].[kqtj] i where b.DataAttendance=i.DataAttendance and b.blockid=i.blockid and b.DataAttendance>='" + startTime + "' ";
                ExecSql(strSql);


                startTime = DateTime.Now.AddYears(-1).ToString("yyyy-MM").ToString() + "-01 00:00:00";
                //更新年历史上下井次数表
                strSql = "Insert into [Czlt_MonthEmpNum] ([codesender],[empID],[empName],[deptID],[deptName],[cYear],[cM1],[cM2],[cM3],[cM4],[cM5],[cM6],[cM7],[cM8],[cM9],[cM10],[cM11],[cM12])  select [codesender],[empID],[empName],[deptID],[deptName],[cYear],[cM1],[cM2],[cM3],[cM4],[cM5],[cM6],[cM7],[cM8],[cM9],[cM10],[cM11],[cM12] from [128RB].[KJ128N].[dbo].[Czlt_MonthEmpNum] b where cYear>='" + startTime + "'  and not exists(select cYear from [Czlt_MonthEmpNum] c where cYear>='" + startTime + "'   and c.cYear=b.cYear and c.codesender=b.codesender and c.empName=b.empName)";
                File.WriteAllText("D:\\CzltHostCzlt_Month.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 执行Sql:\r\n" + strSql.ToString(), Encoding.Unicode);
                ExecSql(strSql);
                strSql = "update [Czlt_MonthEmpNum] set [codesender]=i.[codesender],[empID]=i.[empID],[empName]=i.[empName],[deptID]=i.[deptID],[deptName]=i.[deptName],[cYear]=i.[cYear],[cM1]=i.[cM1],[cM2]=i.[cM2],[cM3]=i.[cM3],[cM4]=i.[cM4],[cM5]=i.[cM5],[cM6]=i.[cM6],[cM7]=i.[cM7],[cM8]=i.[cM8],[cM9]=i.[cM9],[cM10]=i.[cM10],[cM11]=i.[cM11],[cM12]=i.[cM12] from [Czlt_MonthEmpNum] b , [128RB].[KJ128N].[dbo].[Czlt_MonthEmpNum] i where b.cYear=i.cYear  and b.codesender=i.codesender and b.empName=i.empName  and b.cYear>='" + startTime + "' ";
                ExecSql(strSql);
                File.AppendAllText("D:\\CzltHostCzlt_Month.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 执行Sql:\r\n" + strSql.ToString(), Encoding.Unicode);

                //更新年历史上下井时长表
                strSql = "Insert into [Czlt_MonthEmpTime] ([codesender],[empID],[empName],[deptID],[deptName],[cYear],[cM1],[cM2],[cM3],[cM4],[cM5],[cM6],[cM7],[cM8],[cM9],[cM10],[cM11],[cM12])  select [codesender],[empID],[empName],[deptID],[deptName],[cYear],[cM1],[cM2],[cM3],[cM4],[cM5],[cM6],[cM7],[cM8],[cM9],[cM10],[cM11],[cM12] from [128RB].[KJ128N].[dbo].[Czlt_MonthEmpTime] b where cYear>='" + startTime + "'  and not exists(select cYear from [Czlt_MonthEmpTime] c where cYear>='" + startTime + "'  and c.cYear=b.cYear and c.codesender=b.codesender and c.empName=b.empName)";
                ExecSql(strSql);
                File.AppendAllText("D:\\CzltHostCzlt_Month.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 执行Sql:\r\n" + strSql.ToString(), Encoding.Unicode);
                strSql = "update [Czlt_MonthEmpTime] set [codesender]=i.[codesender],[empID]=i.[empID],[empName]=i.[empName],[deptID]=i.[deptID],[deptName]=i.[deptName],[cYear]=i.[cYear],[cM1]=i.[cM1],[cM2]=i.[cM2],[cM3]=i.[cM3],[cM4]=i.[cM4],[cM5]=i.[cM5],[cM6]=i.[cM6],[cM7]=i.[cM7],[cM8]=i.[cM8],[cM9]=i.[cM9],[cM10]=i.[cM10],[cM11]=i.[cM11],[cM12]=i.[cM12] from [Czlt_MonthEmpTime] b , [128RB].[KJ128N].[dbo].[Czlt_MonthEmpTime] i where b.cYear=i.cYear  and b.codesender=i.codesender and b.empName=i.empName  and b.cYear>='" + startTime + "' ";
                ExecSql(strSql);
                File.AppendAllText("D:\\CzltHostCzlt_Month.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 执行Sql:\r\n" + strSql.ToString(), Encoding.Unicode);
            
            }
            catch
            { }

        }
        #endregion


        #region 【Czlt-2013-03-30 连接字符串】
        /// <summary>
        /// Czlt-2013-03-30 连接字符串
        /// </summary>
        /// <param name="appKey"></param>
        /// <returns></returns>
        private string GetConfigValue(string appKey)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Application.StartupPath + "\\KJ128NMainRun.exe.config");

                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion

    }
}
