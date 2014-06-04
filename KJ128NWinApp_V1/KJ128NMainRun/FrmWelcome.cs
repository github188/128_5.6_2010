using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using KJ128NDataBase;

namespace KJ128NInterfaceShow
{
    public partial class FrmWelcome : Form
    {

        DbHelperSQL db = new DbHelperSQL();

        

        public string CurrentState(string strValue)
        {

            this.lblState.Text = strValue;
            this.lblState.Refresh();
            return strValue;

        }
        /// <summary>
        /// 欢迎画面当前执行状态
        /// </summary>
        //public string CurrentState
        //{
        //    set
        //    {
        //        this.lblState.Text = value;
        //        this.lblState.Refresh();
        //    }
        //}

        public FrmWelcome()
        {
            InitializeComponent();

            ArrayList list = new ArrayList();
            //1.历史上下井
            list.Add("ALTER  proc CreateHis_InOutMine @YearValue int, @MoonValue int as Declare @TableName nvarchar(10) declare @StartTime DateTime declare @EndTime DateTime Declare @SqlString nvarchar(4000) declare @DropSql nvarchar(100) set @TableName=cast(@YearValue as nvarchar(4)) +cast(@MoonValue as nvarchar(2)) if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[His_InOutMine_'+@TableName+']') and OBJECTPROPERTY(id, N'IsUserTable') = 1) begin set @StartTime=cast(@YearValue as nvarchar(4))+'-'+Cast(@MoonValue as nvarchar(2))+'-'+'1' set @EndTime=dateadd(Month,1,@StartTime) set @SqlString='CREATE TABLE [His_InOutMine_'+@TableName+'] ([HisInOutMineID] [bigint] NOT NULL ,[InStationAddress] [int] NULL ,[InStationHeadAddress] [int] NULL ,[InWellPlace] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[CodeSenderAddress] [int] NOT NULL ,[UserID] [int] NULL,[UserNo] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[UserName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,[DeptID] [int] NULL ,[DeptName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[DutyID] [int] NULL ,[DutyName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[WorkTypeID] [int] NULL ,[WorkTypeName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[InTime] [datetime] NOT NULL ,[OutStationAddress] [int] NULL ,[OutStationHeadAddress] [int] NULL ,[OutWellPlace] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[OutTime] [datetime] NULL ,[ContinueTime] [bigint] NULL,[IsMend] [bit] NULL) ON [PRIMARY]' exec (@SqlString) set @SqlString='ALTER TABLE [dbo].[His_InOutMine_'+@TableName+'] WITH NOCHECK ADD  CONSTRAINT [PK_His_InOutMine_'+@TableName+'] PRIMARY KEY  CLUSTERED ([HisInOutMineID],[InTime],[CodeSenderAddress])  ON [PRIMARY] ' exec (@SqlString) set @SqlString='ALTER TABLE [dbo].[His_InOutMine_'+@TableName+'] ADD CONSTRAINT [CK_His_InOutMine_'+@TableName+'] CHECK (InTime >=  '''+cast(datepart(year,@StartTime) as nvarchar(4))+'-'+cast(datepart(month,@StartTime) as nvarchar(2))+'-'+cast(datepart(day,@StartTime) as nvarchar(2))+''' and InTime< '''+ cast(datepart(year,@EndTime) as nvarchar(4))+'-'+cast(datepart(month,@EndTime) as nvarchar(2))+'-'+cast(datepart(day,@EndTime) as nvarchar(2))+''')' exec (@SqlString) end");
            //2.历史进出分站表
            list.Add("ALTER  proc CreateHis_InOutStationHead @YearValue int, @MoonValue int as Declare @TableName nvarchar(10) declare @StartTime DateTime declare @EndTime DateTime Declare @SqlString nvarchar(4000) declare @DropSql nvarchar(100) set @TableName=cast(@YearValue as nvarchar(4)) +cast(@MoonValue as nvarchar(2)) if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[His_InOutStationHead_'+@TableName+']') and OBJECTPROPERTY(id, N'IsUserTable') = 1) begin set @StartTime=cast(@YearValue as nvarchar(4))+'-'+Cast(@MoonValue as nvarchar(2))+'-'+'1' set @EndTime=dateadd(Month,1,@StartTime) set @SqlString='CREATE TABLE [dbo].[His_InOutStationHead_'+@TableName+'] ([HisStationHeadID] [bigint] NOT NULL ,[StationAddress] [int] NOT NULL ,[StationHeadAddress] [int] NOT NULL ,[StationHeadPlace] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,[CodeSenderAddress] [int] NOT NULL ,[CsTypeID] [int] NULL ,[UserID] [int] NULL,[UserNo] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[UserName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,[DeptID] [int] NULL ,[DeptName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[DutyID] [int] NULL ,[DutyName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[WorkTypeID] [int] NULL ,[WorkTypeName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[InStationHeadTime] [datetime] NOT NULL ,[OutStationHeadTime] [datetime] NOT NULL,[ContinueTime] [bigint] NULL,[IsMend] [bit] NULL) ON [PRIMARY]' exec (@SqlString) set @SqlString='ALTER TABLE [dbo].[His_InOutStationHead_'+@TableName+'] WITH NOCHECK ADD  CONSTRAINT [PK_His_InOutStationHead_'+@TableName+'] PRIMARY KEY  CLUSTERED ([HisStationHeadID],[InStationHeadTime],[CodeSenderAddress])  ON [PRIMARY]' exec (@SqlString) set @SqlString='ALTER TABLE [dbo].[His_InOutStationHead_'+@TableName+'] ADD  CONSTRAINT [CK_His_InOutStationHead_'+@TableName+'] CHECK (InStationHeadTime >=  ''' +cast(datepart(year,@StartTime) as nvarchar(4))+'-'	+cast(datepart(month,@StartTime) as nvarchar(2))+'-' +cast(datepart(day,@StartTime) as nvarchar(2))+''' and InStationHeadTime <'''+ cast(datepart(year,@EndTime) as nvarchar(4))+'-'+cast(datepart(month,@EndTime) as nvarchar(2))+'-'+cast(datepart(day,@EndTime) as nvarchar(2)) + ''')'  exec (@SqlString)  end");
            //3.历史考勤表
            list.Add("ALTER  proc CreateHistoryAttendance @YearValue int,@MoonValue int as Declare @TableName nvarchar(10) declare @StartTime DateTime declare @EndTime DateTime Declare @SqlString nvarchar(4000) declare @DropSql nvarchar(100) set @TableName=cast(@YearValue as nvarchar(4)) +cast(@MoonValue as nvarchar(2)) if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HistoryAttendance_'+@TableName+']') and OBJECTPROPERTY(id, N'IsUserTable') = 1) begin set @StartTime=cast(@YearValue as nvarchar(4))+'-'+Cast(@MoonValue as nvarchar(2)) +'-'+'1' set @EndTime=dateadd(Month,1,@StartTime) set @SqlString='CREATE TABLE [HistoryAttendance_'+@TableName+'] ([ID] [bigint] NOT NULL ,[BlockID] [int] NULL ,[EmployeeID] [int] NULL ,[EmployeeName] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL ,[DeptID] [int] NULL ,[ClassID] [int] NULL ,[ClassShortName] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL ,[BeginWorkDate] [datetime] NULL ,[BeginWorkTime] [datetime] NULL ,[EndWorkTime] [datetime] NULL ,[WorkTime] [int] NULL ,[ManNumberUnit] [int] NULL ,[BookWorkTime] [int] NULL ,[AvailableWorkTime] [int] NULL ,[IsAddAttendance] [bit] NULL ,[IsHoliday] [bit] NULL ,[IsAvailable] [bit] NULL ,[OperatorID] [int] NULL ,[OperatorTime] [datetime] NULL ,[IsLate] [bit] NULL ,[IsLeaveEarly] [bit] NULL ,[IsEnoughAttendance] [bit] NULL ,[LateTimeLongth] [int] NULL ,[LeaveEarlyTimeLength] [int] NULL ,[Remark] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,[TimerIntervalID] [int] NULL ,[DataAttendance] [datetime] NOT NULL,[IsMend] [bit] NULL) ON [PRIMARY]' exec (@SqlString) set @SqlString='ALTER TABLE [dbo].[HistoryAttendance_'+@TableName+'] WITH NOCHECK ADD  CONSTRAINT [PK_HistoryAttendance_'+@TableName+'] PRIMARY KEY  CLUSTERED ([ID],[DataAttendance]) ON [PRIMARY] ' exec (@SqlString) set @SqlString='ALTER TABLE [dbo].[HistoryAttendance_'+@TableName+'] ADD 	CONSTRAINT [DF_HistoryAttendance_'+@TableName+'_IsHoliday] DEFAULT (0) FOR [IsHoliday]' exec (@SqlString) end ");
            //4.历史1区域信息
            list.Add("ALTER   proc CreateHis_InOutTerritorial @YearValue int, @MoonValue int as Declare @TableName nvarchar(10) declare @StartTime DateTime declare @EndTime DateTime Declare @SqlString nvarchar(4000) declare @DropSql nvarchar(100) set @TableName=cast(@YearValue as nvarchar(4))+cast(@MoonValue as nvarchar(2)) if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[His_InOutTerritorial_'+@TableName+']') and OBJECTPROPERTY(id, N'IsUserTable') = 1) begin set @StartTime=cast(@YearValue as nvarchar(4))+'-'+Cast(@MoonValue as nvarchar(2)) +'-'+'1' set @EndTime=dateadd(Month,1,@StartTime) set @SqlString='CREATE TABLE [His_InOutTerritorial_'+@TableName+'] ([HisTerritorialID] [bigint] NOT NULL ,[TerritorialID] [int] NOT NULL ,[TerritorialName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,[TerritorialTypeName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,[InTerritorialTime] [datetime] NOT NULL ,[CodeSenderAddress] [int] NOT NULL ,[UserID] [int] NULL,[UserNo] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[UserName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,[DeptID] [int] NULL ,[DeptName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[DutyID] [int] NULL ,[DutyName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[WorkTypeID] [int] NULL ,[WorkTypeName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[OutTerritorialTime] [datetime] NULL ,[ContinueTime] [bigint] NULL, [IsAlarm] [bit] NULL ) ON [PRIMARY]' exec (@SqlString) set @SqlString='ALTER TABLE [dbo].[His_InOutTerritorial_'+@TableName+'] WITH NOCHECK ADD  CONSTRAINT [PK_His_Territorial_'+@TableName+'] PRIMARY KEY  CLUSTERED ([HisTerritorialID],[TerritorialID],[InTerritorialTime],[CodeSenderAddress])  ON [PRIMARY] ' exec (@SqlString) end ");

            //5.新的执行过程生成四个历史表的存储过程
            list.Add(" if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Czlt_CreateHistoryDataTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)  drop procedure [dbo].[Czlt_CreateHistoryDataTable] ");
            list.Add(" create  proc [dbo].[Czlt_CreateHistoryDataTable]   @year int,   @month int   as Declare @temYear int  Declare @i  int set @temYear=@year set @i=@month 	    exec CreateHis_InOutStationHead @temYear,@i 		exec CreateHis_InOutMine @temYear,@i 		exec CreateHistoryAttendance @temYear,@i  		exec CreateHis_InOutTerritorial @temYear,@i	 ");

            db.ExecuteSqlTran(list);

        }
    }
}
