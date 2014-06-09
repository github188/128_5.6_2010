--1.xxh 2014-6-5 给Emp_Info 添加两列
ALTER TABLE dbo.Emp_Info ADD [ClassID] [int] NULL,
[IsClassEnabled] [bit] NULL  DEFAULT (0 )
GO
---------------------------------------------------------------------------------------------
--2.xxh 2014-6-5 修改新增人员存储过程
/*
       增加员工信息
       蔡建钢
      2009-08-12 13 ：
*/

ALTER        PROC [dbo].[A_zjw_Emp_Insert]
    (
      @EmpName NVARCHAR(20 ) ,
      @Sex BIT ,
      @Remark NVARCHAR(200 ) ,
      @EmpNO NVARCHAR(10 ) ,
      @DeptID INT ,
      @DutyID INT ,
      @MaxSecTime INT ,
      @MinSecTime INT ,
      @Selectmode INT ,
      @ClassGroup NVARCHAR(50 ) = NULL ,
      @WorkPlace NVARCHAR(50 ) = NULL ,
      @Photo IMAGE = NULL ,
      @Nation NVARCHAR(30 ) = NULL ,
      @Wedlock NVARCHAR(50 ) = NULL ,
      @Clan NVARCHAR(50 ) = NULL ,
      @NativePlace NVARCHAR(50 ) = NULL ,
      @CensusRegister NVARCHAR(50 ) = NULL ,
      @SchoolRecord NVARCHAR(50 ) = NULL ,
      @GraduateFrom NVARCHAR(35 ) = NULL ,
      @Specialty NVARCHAR(50 ) = NULL ,
      @OfficialDesignation NVARCHAR(50 ) = NULL ,
      @Idcard NVARCHAR(20 ) = NULL ,
      @BirthDay DATETIME = NULL ,
      @Height INT = 0 ,
      @Weight INT = 0 ,
      @StateOfHealth NVARCHAR(50 ) = NULL ,
      @HomeTel1 NVARCHAR(20 ) = NULL ,
      @HomeTel2 NVARCHAR(20 ) = NULL ,
      @HomeAddress NVARCHAR(250 ) = NULL ,
      @Postalcode NVARCHAR(6 ) = NULL ,
      @ProbationDate DATETIME = NULL ,
      @OfficiallyDate DATETIME = NULL ,
      @ContractExpDate DATETIME = NULL ,
      @ContractExpAppendDate DATETIME = NULL ,
      @IsGearShift BIT ,
      @HireTypeID INT ,
      @Archives NVARCHAR(100 ) = NULL ,
      @DimissionTime DATETIME = NULL ,
      @EmpDetailRemark NVARCHAR(200 ) = NULL ,
      @EmpSerchRemark NVARCHAR(200 ) = NULL ,
      @EmpHomeRemark NVARCHAR(200 ) = NULL ,
      @EmpInCompanyRemark NVARCHAR(200 ) = NULL ,
      @EmpNowCompanyRemark NVARCHAR(200 ) = NULL ,
      @WorkTypeID1 INT ,
      @IsMostly1 BIT ,
      @IsEnable1 BIT ,
      @blood NVARCHAR(20 ) = NULL ,
      @ID INT ,
      @DeptName NVARCHAR(50 ) ,
      @DutyName NVARCHAR(50 ) = NULL ,
      @WorkTypeName NVARCHAR(50 ) = NULL ,
      @ClassID INT = NULL
    )
AS
    BEGIN

        DECLARE @EmpID INT      --定义员工 ID

        BEGIN TRANSACTION              --创建事务

        IF ( NOT EXISTS ( SELECT    1
                          FROM      Emp_Info
                          WHERE     EmpNO = @EmpNO )
           )
            BEGIN
                IF ( @Idcard = '' )
                    SET @Idcard = NULL


       --插入员工信息表(Emp_Info)
                INSERT  INTO [Emp_Info]
                        ( EmpID ,
                          EmpNO ,
                          EmpName ,
                          Sex ,
                          DeptID ,
                          DeptName ,
                          DutyID ,
                          DutyName ,
                          MaxSecTime ,
                          MinSecTime ,
                          Selectmode ,
                          classGroup ,
                          workPlace ,
                          photo ,
                          idCard ,
                          workTypeid ,
                          worktypeName ,
                          Remark ,
                          ClassID
                        )
                VALUES  ( @ID ,
                          @EmpNO ,
                          @EmpName ,
                          @Sex ,
                          @DeptID ,
                          @DeptName ,
                          @DutyID ,
                          @DutyName ,
                          @MaxSecTime ,
                          @MinSecTime ,
                          @Selectmode ,
                          @ClassGroup ,
                          @WorkPlace ,
                          @Photo ,
                          @Idcard ,
                          @WorkTypeID1 ,
                          @WorkTypeName ,
                          @Remark ,
                          @ClassID
                        )

       --为员工ID(EmpID) 赋值
                SELECT  @EmpID = EmpID
                FROM    Emp_Info
                WHERE   EmpNO = @EmpNO
     
       --插入员工详细信息表(Emp_Detail)
                IF ( NOT EXISTS ( SELECT    1
                                  FROM      Emp_Detail
                                  WHERE     EmpID = @EmpID )
                   )
                    BEGIN
                        IF ( @Height = 0 )
                            BEGIN
                                SET @Height = NULL
                            END

                        IF ( @Weight = 0 )
                            BEGIN
                                SET @Weight = NULL
                            END
                        IF ( @BirthDay = '1900-1-1 00:00:01' )
                            BEGIN
                                SET @BirthDay = NULL
                            END

                        IF ( @ProbationDate = '1900-1-1 00:00:01' )
                            BEGIN
                                SET @ProbationDate = NULL
                            END

                        IF ( @OfficiallyDate = '1900-1-1 00:00:01' )
                            BEGIN
                                SET @OfficiallyDate = NULL
                            END

                        IF ( @ContractExpDate = '1900-1-1 00:00:01' )
                            BEGIN
                                SET @ContractExpDate = NULL
                            END

                        IF ( @ContractExpAppendDate = '1900-1-1 00:00:01' )
                            BEGIN
                                SET @ContractExpAppendDate = NULL
                            END    

                        IF ( @DimissionTime = '1900-1-1 00:00:01' )
                            BEGIN
                                SET @DimissionTime = NULL
                            END          

                        INSERT  INTO Emp_Detail
                                ( EmpID ,
                                  Nation ,
                                  Wedlock ,
                                  Clan ,
                                  NativePlace ,
                                  CensusRegister ,
                                  SchoolRecord ,
                                  GraduateFrom ,
                                  Specialty ,
                                  OfficialDesignation ,
                                  BirthDay ,
                                  blood ,
                                  Height ,
                                  Weight ,
                                  StateOfHealth ,
                                  HomeTel ,
                                  Tel ,
                                  HomeAddress ,
                                  Postalcode ,
                                  ProbationDate ,
                                  OfficiallyDate ,
                                  ContractExpDate ,
                                  ContractExpAppendDate ,
                                  IsGearShift ,
                                  HireTypeID ,
                                  Archives ,
                                  DimissionTime
                                )
                        VALUES  ( @EmpID ,
                                  @Nation ,
                                  @Wedlock ,
                                  @Clan ,
                                  @NativePlace ,
                                  @CensusRegister ,
                                  @SchoolRecord ,
                                  @GraduateFrom ,
                                  @Specialty ,
                                  @OfficialDesignation ,
                                  @BirthDay ,
                                  @blood ,
                                  @Height ,
                                  @Weight ,
                                  @StateOfHealth ,
                                  @HomeTel1 ,
                                  @HomeTel2 ,
                                  @HomeAddress ,
                                  @Postalcode ,
                                  @ProbationDate ,
                                  @OfficiallyDate ,
                                  @ContractExpDate ,
                                  @ContractExpAppendDate ,
                                  @IsGearShift ,
                                  @HireTypeID ,
                                  @Archives ,
                                  @DimissionTime
                                )
                    END

            END
        COMMIT
    END
    GO
---------------------------------------------------------------------------------------------
--3.xxh 2014-6-5 修改更新人员存储过程
/*
       修改员工信息
       蔡建钢
      2009-08-13 13 ：
*/

ALTER        PROC [dbo].[A_zjw_Emp_Update]
    (
      @EmpName NVARCHAR(20 ) ,
      @Sex BIT ,
      @Remark NVARCHAR(200 ) ,
      @EmpNO NVARCHAR(10 ) ,
      @DeptID INT ,
      @DutyID INT ,
      @MaxSecTime INT ,
      @MinSecTime INT ,
      @Selectmode INT ,
      @ClassGroup NVARCHAR(50 ) = NULL ,
      @WorkPlace NVARCHAR(50 ) = NULL ,
      @Photo IMAGE = NULL ,
      @Nation NVARCHAR(30 ) = NULL ,
      @Wedlock NVARCHAR(50 ) = NULL ,
      @Clan NVARCHAR(50 ) = NULL ,
      @NativePlace NVARCHAR(50 ) = NULL ,
      @CensusRegister NVARCHAR(50 ) = NULL ,
      @SchoolRecord NVARCHAR(50 ) = NULL ,
      @GraduateFrom NVARCHAR(35 ) = NULL ,
      @Specialty NVARCHAR(50 ) = NULL ,
      @OfficialDesignation NVARCHAR(50 ) = NULL ,
      @Idcard NVARCHAR(20 ) = NULL ,
      @BirthDay DATETIME = NULL ,
      @Height INT = 0 ,
      @Weight INT = 0 ,
      @StateOfHealth NVARCHAR(50 ) = NULL ,
      @HomeTel1 NVARCHAR(20 ) = NULL ,
      @HomeTel2 NVARCHAR(20 ) = NULL ,
      @HomeAddress NVARCHAR(250 ) = NULL ,
      @Postalcode NVARCHAR(6 ) = NULL ,
      @ProbationDate DATETIME = NULL ,
      @OfficiallyDate DATETIME = NULL ,
      @ContractExpDate DATETIME = NULL ,
      @ContractExpAppendDate DATETIME = NULL ,
      @IsGearShift BIT ,
      @HireTypeID INT ,
      @Archives NVARCHAR(100 ) = NULL ,
      @DimissionTime DATETIME = NULL ,
      @EmpDetailRemark NVARCHAR(200 ) = NULL ,
      @EmpSerchRemark NVARCHAR(200 ) = NULL ,
      @EmpHomeRemark NVARCHAR(200 ) = NULL ,
      @EmpInCompanyRemark NVARCHAR(200 ) = NULL ,
      @EmpNowCompanyRemark NVARCHAR(200 ) = NULL ,
      @WorkTypeID1 INT ,
      @IsMostly1 BIT ,
      @IsEnable1 BIT ,
      @blood NVARCHAR(20 ) = NULL ,
      @EmpID INT ,
      @DeptName NVARCHAR(50 ) ,
      @DutyName NVARCHAR(50 ) = NULL ,
      @WorkTypeName NVARCHAR(50 ) = NULL ,
      @ClassID INT = NULL
    )
AS
    BEGIN

        BEGIN TRANSACTION EmpInfo_Trans   --创建事务

        BEGIN

            IF ( EXISTS ( SELECT     1
                          FROM      Emp_Info
                          WHERE     EmpID = @EmpID ) )
                BEGIN

                    IF ( @Idcard = '' )
                        SET @Idcard = NULL
     
       --修改员工信息表(Emp_Info)
                    UPDATE  Emp_Info
                    SET     EmpName = @EmpName ,
                            Sex = @Sex ,
                            Remark = @Remark ,
                            EmpNO = @EmpNO ,
                            DeptID = @DeptID ,
                            DeptName = @DeptName ,
                            DutyID = @DutyID ,
                            DutyName = @DutyName ,
                            MaxSecTime = @MaxSecTime ,
                            MinSecTime = @MinSecTime ,
                            Selectmode = @Selectmode ,
                            classGroup = @ClassGroup ,
                            workPlace = @WorkPlace ,
                            photo = @Photo ,
                            idCard = @Idcard ,
                            workTypeid = @WorkTypeID1 ,
                            worktypeName = @WorkTypeName ,
                            ClassID = @ClassID
                    WHERE   EmpID = @EmpID


                    IF ( @Height = 0 )
                        BEGIN
                            SET @Height = NULL
                        END

                    IF ( @Weight = 0 )
                        BEGIN
                            SET @Weight = NULL
                        END
                    IF ( @BirthDay = '1900-1-1 00:00:01' )
                        BEGIN
                            SET @BirthDay = NULL
                        END

                    IF ( @ProbationDate = '1900-1-1 00:00:01' )
                        BEGIN
                            SET @ProbationDate = NULL
                        END

                    IF ( @OfficiallyDate = '1900-1-1 00:00:01' )
                        BEGIN
                            SET @OfficiallyDate = NULL
                        END

                    IF ( @ContractExpDate = '1900-1-1 00:00:01' )
                        BEGIN
                            SET @ContractExpDate = NULL
                        END

                    IF ( @ContractExpAppendDate = '1900-1-1 00:00:01' )
                        BEGIN
                            SET @ContractExpAppendDate = NULL
                        END  

                    IF ( @DimissionTime = '1900-1-1 00:00:01' )
                        BEGIN
                            SET @DimissionTime = NULL
                        END        
       --修改员工详细信息表(Emp_Detail)
                    IF ( NOT EXISTS ( SELECT    1
                                      FROM      Emp_Detail
                                      WHERE     EmpID = @EmpID )
                       )
                        BEGIN
                            INSERT  INTO Emp_Detail
                                    ( EmpID ,
                                      Nation ,
                                      Wedlock ,
                                      Clan ,
                                      NativePlace ,
                                      CensusRegister ,
                                      SchoolRecord ,
                                      GraduateFrom ,
                                      Specialty ,
                                      OfficialDesignation ,
                                      BirthDay ,
                                      blood ,
                                      Height ,
                                      Weight ,
                                      StateOfHealth ,
                                      HomeTel ,
                                      Tel ,
                                      HomeAddress ,
                                      Postalcode ,
                                      ProbationDate ,
                                      OfficiallyDate ,
                                      ContractExpDate ,
                                      ContractExpAppendDate ,
                                      IsGearShift ,
                                      HireTypeID ,
                                      Archives ,
                                      DimissionTime
                                    )
                            VALUES  ( @EmpID ,
                                      @Nation ,
                                      @Wedlock ,
                                      @Clan ,
                                      @NativePlace ,
                                      @CensusRegister ,
                                      @SchoolRecord ,
                                      @GraduateFrom ,
                                      @Specialty ,
                                      @OfficialDesignation ,
                                      @BirthDay ,
                                      @blood ,
                                      @Height ,
                                      @Weight ,
                                      @StateOfHealth ,
                                      @HomeTel1 ,
                                      @HomeTel2 ,
                                      @HomeAddress ,
                                      @Postalcode ,
                                      @ProbationDate ,
                                      @OfficiallyDate ,
                                      @ContractExpDate ,
                                      @ContractExpAppendDate ,
                                      @IsGearShift ,
                                      @HireTypeID ,
                                      @Archives ,
                                      @DimissionTime
                                    )
                        END
                    ELSE
                        BEGIN
                            UPDATE  Emp_Detail
                            SET     Nation = @Nation ,
                                    Wedlock = @Wedlock ,
                                    Clan = @Clan ,
                                    NativePlace = @NativePlace ,
                                    CensusRegister = @CensusRegister ,
                                    SchoolRecord = @SchoolRecord ,
                                    GraduateFrom = @GraduateFrom ,
                                    Specialty = @Specialty ,
                                    OfficialDesignation = @OfficialDesignation ,
                                    BirthDay = @BirthDay ,
                                    blood = @blood ,
                                    Height = @Height ,
                                    Weight = @Weight ,
                                    StateOfHealth = @StateOfHealth ,
                                    HomeTel = @HomeTel1 ,
                                    Tel = @HomeTel2 ,
                                    HomeAddress = @HomeAddress ,
                                    Postalcode = @Postalcode ,
                                    ProbationDate = @ProbationDate ,
                                    OfficiallyDate = @OfficiallyDate ,
                                    ContractExpDate = @ContractExpDate ,
                                    ContractExpAppendDate = @ContractExpAppendDate ,
                                    IsGearShift = @IsGearShift ,
                                    HireTypeID = @HireTypeID ,
                                    Archives = @Archives ,
                                    DimissionTime = @DimissionTime
                            WHERE   EmpID = @EmpID
                        END
                END

        END

    END


--判断是否全部执行成功
    IF @@error = 0
        BEGIN
            COMMIT TRANSACTION EmpInfo_Trans
        END
    ELSE
        BEGIN
            ROLLBACK TRANSACTION EmpInfo_Trans
        END
        GO
---------------------------------------------------------------------------------------------
--4.xxh 2014-6-5 修改实时考勤存储过程proc_InsertRTEmployeeAttendance
--添加到实时人员考勤信息取个人考勤版
ALTER   proc [dbo].[proc_InsertRTEmployeeAttendance]
      @DetectTime datetime ,                -- 检测时间
      @Cards varchar (6000 )
as
insert into RealTimeAttendance( BlockID, EmployeeID ,EmployeeName , DeptID, ClassID ,ClassShortName , BeginWorkTime, DataAttendance ,TimerIntervalID )
-- 按部门考勤的
select T1.F1, ssa.UserID , ssa.UserName ,ssa.deptid, ssa.classid , ssa.NameShort ,@DetectTime ,
case ssa.DataAttendanceType
when - 1 then
( case when datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0
then dateadd (day ,- 1, convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),DATEPART ( dd, @DetectTime )))))
else convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),
DATEPART (dd , @DetectTime))))
end )
when 0 then
( case when datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0
then convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),
DATEPART (dd , @DetectTime))))
else
dateadd (day , 1, convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),DATEPART ( dd, @DetectTime )))))
end )
when 1 then  
( case when datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0
then dateadd (day , 1, convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),DATEPART ( dd, @DetectTime )))))
else convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),
DATEPART (dd , @DetectTime))))
end )
end as DataAttendance ,
ssa.TimerIntervalID
from ( select F1 from f_splitstr (@Cards , ',')) as T1
       join Shine_Shen_AttendanceClass ssa on T1.F1 = ssa.blockID
       LEFT JOIN (SELECT css.CodeSenderAddress, ei.ClassID , ei.IsClassEnabled FROM dbo.Emp_Info ei LEFT JOIN  dbo.CodeSender_Set css ON css.UserID = ei.EmpID) atC ON atC.CodeSenderAddress = T1.F1
where T1.F1 not in( select BlockID from RealTimeAttendance) and
       (( datediff( minute ,convert ( varchar( 2 ),DATEPART ( hh, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( mi ,StartWorkTime ))+ ':'+ convert (varchar ( 2), DATEPART (ss , StartWorkTime)),
                         convert (varchar ( 2), DATEPART (hh , EndWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, EndWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,EndWorkTime )))> 0
       and datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , StartWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,StartWorkTime )))<= 0
       and datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0)
       or ( datediff( minute ,convert ( varchar( 2 ),DATEPART ( hh, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( mi ,StartWorkTime ))+ ':'+ convert (varchar ( 2), DATEPART (ss , StartWorkTime)),
                         convert (varchar ( 2), DATEPART (hh , EndWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, EndWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,EndWorkTime )))< 0
       and ( datediff( minute ,convert ( varchar( 2 ),DATEPART ( hh, @DetectTime ))+':' + convert( varchar (2 ), DATEPART( mi ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (ss , @DetectTime)),
                               convert (varchar ( 2), DATEPART (hh , StartWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,StartWorkTime )))<= 0
       and datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))< 0)
       or ( datediff( minute ,convert ( varchar( 2 ),DATEPART ( hh, @DetectTime ))+':' + convert( varchar (2 ), DATEPART( mi ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (ss , @DetectTime)),
                               convert (varchar ( 2), DATEPART (hh , StartWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,StartWorkTime )))>= 0 
       and datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0
       and datediff ( dd, startworkTime ,EndWorkTime )> 0)))
       AND atC.CodeSenderAddress IS NOT NULL -- 已配标识卡
       AND atC.IsClassEnabled = 0 OR ( atC.IsClassEnabled = 1 AND atC.ClassID IS NULL)-- 已关闭个人考勤或者已开启个人考勤但未配置个人考勤班制
-- 按个人考勤的     
UNION ALL
select T1.F1, ssa.UserID , ssa.UserName ,ssa.deptid, ssa.classid , ssa.NameShort ,@DetectTime ,
case ssa.DataAttendanceType
when - 1 then
( case when datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0
then dateadd (day ,- 1, convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),DATEPART ( dd, @DetectTime )))))
else convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),
DATEPART (dd , @DetectTime))))
end )
when 0 then
( case when datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0
then convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),
DATEPART (dd , @DetectTime))))
else
dateadd (day , 1, convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),DATEPART ( dd, @DetectTime )))))
end )
when 1 then  
( case when datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0
then dateadd (day , 1, convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),DATEPART ( dd, @DetectTime )))))
else convert (datetime ,( convert( varchar (4 ), DATEPART( yyyy ,@DetectTime ))+ '-'+ convert (varchar ( 2), DATEPART (mm , @DetectTime))+ '-' +convert ( varchar( 2 ),
DATEPART (dd , @DetectTime))))
end )
end as DataAttendance ,
ssa.TimerIntervalID
from ( select F1 from f_splitstr (@Cards , ',')) as T1
       join Shine_Shen_AttendanceClass_User ssa on T1.F1 = ssa.blockID
       LEFT JOIN (SELECT css.CodeSenderAddress, ei.ClassID , ei.IsClassEnabled FROM dbo.Emp_Info ei LEFT JOIN dbo.CodeSender_Set css ON css.UserID = ei.EmpID) atC ON atC.CodeSenderAddress = T1.F1
where T1.F1 not in( select BlockID from RealTimeAttendance) and
       (( datediff( minute ,convert ( varchar( 2 ),DATEPART ( hh, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( mi ,StartWorkTime ))+ ':'+ convert (varchar ( 2), DATEPART (ss , StartWorkTime)),
                         convert (varchar ( 2), DATEPART (hh , EndWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, EndWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,EndWorkTime )))> 0
       and datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , StartWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,StartWorkTime )))<= 0
       and datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0)
       or ( datediff( minute ,convert ( varchar( 2 ),DATEPART ( hh, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( mi ,StartWorkTime ))+ ':'+ convert (varchar ( 2), DATEPART (ss , StartWorkTime)),
                         convert (varchar ( 2), DATEPART (hh , EndWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, EndWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,EndWorkTime )))< 0
       and ( datediff( minute ,convert ( varchar( 2 ),DATEPART ( hh, @DetectTime ))+':' + convert( varchar (2 ), DATEPART( mi ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (ss , @DetectTime)),
                               convert (varchar ( 2), DATEPART (hh , StartWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,StartWorkTime )))<= 0
       and datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))< 0)
       or ( datediff( minute ,convert ( varchar( 2 ),DATEPART ( hh, @DetectTime ))+':' + convert( varchar (2 ), DATEPART( mi ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (ss , @DetectTime)),
                               convert (varchar ( 2), DATEPART (hh , StartWorkTime))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, StartWorkTime ))+':' + convert( varchar (2 ), DATEPART( ss ,StartWorkTime )))>= 0 
       and datediff (minute , convert( varchar (2 ), DATEPART( hh ,@DetectTime ))+ ':'+ convert (varchar ( 2), DATEPART (mi , @DetectTime))+ ':' +convert ( varchar( 2 ),DATEPART ( ss, @DetectTime )),
                               convert (varchar ( 2), DATEPART (hh , dateadd( minute ,SwAfterTime , StartWorkTime)))+ ':' +convert ( varchar( 2 ),DATEPART ( mi, dateadd (minute , SwAfterTime, StartWorkTime )))+':' + convert( varchar (2 ), DATEPART( ss ,dateadd ( minute, SwAfterTime ,StartWorkTime ))))> 0
       and datediff ( dd, startworkTime ,EndWorkTime )> 0)))  
       AND atc.CodeSenderAddress IS NOT NULL -- 已配标识卡
       AND atc.IsClassEnabled = 1 -- 已开启个人考勤
       AND atc.ClassID IS NOT NULL -- 已设置个人考勤班制
GO
---------------------------------------------------------------------------------------------
--5.xxh 2014-6-5 查询用户个人的考勤班制
CREATE  VIEW [dbo].[Shine_Shen_AttendanceClass_User]
AS
    SELECT  dbo.TimerInterval.NameShort ,
            dbo.TimerInterval.ClassID ,
            DATEADD(minute , - dbo.TimerInterval.SWFrontTime,
                    dbo.TimerInterval.StartWorkTime) AS StartWorkTime ,
            DATEADD(minute , dbo.TimerInterval.SWAfterTime ,
                    dbo.TimerInterval.StartWorkTime) AS EndWorkTime ,
            dbo.TimerInterval.SWFrontTime ,
            dbo.TimerInterval.SWAfterTime ,
            DATEADD(minute , - dbo.TimerInterval.EWFrontTime,
                    dbo.TimerInterval.EndWorkTime) AS EndTimeFrontTime ,
            DATEADD(minute , dbo.TimerInterval.EWAfterTime ,
                    dbo.TimerInterval.EndWorkTime) AS EndTimeAfterTime ,
            dbo.TimerInterval.EWFrontTime ,
            dbo.TimerInterval.EWAfterTime ,
            dbo.TimerInterval.SWDateType ,
            dbo.TimerInterval.EWDateType ,
            dbo.TimerInterval.ID AS TimerIntervalID ,
            dbo.TimerInterval.DataAttendanceType ,
            dbo.Emp_Info.EmpName AS UserName ,
            dbo.Dept_Info.DeptID ,
            dbo.CodeSender_Set.CodeSenderAddress AS BlockID ,
            dbo.CodeSender_Set.UserID ,
            dbo.Dept_Info.DeptName
    FROM    dbo.InfoClass
            INNER JOIN dbo.TimerInterval ON dbo.InfoClass.ID = dbo.TimerInterval.ClassID
            INNER JOIN dbo.Emp_Info ON dbo.InfoClass.ID = dbo.Emp_Info.ClassID
            INNER JOIN dbo.Dept_Info ON dbo.Emp_Info.DeptID = dbo.Dept_Info.DeptID
            INNER JOIN dbo.CodeSender_Set ON dbo.Emp_Info.EmpID = dbo.CodeSender_Set.UserID
    WHERE   ( dbo.CodeSender_Set.CsTypeID = 0 )
GO
