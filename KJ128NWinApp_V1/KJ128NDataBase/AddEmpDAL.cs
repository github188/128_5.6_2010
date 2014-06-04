using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KJ128NModel;


namespace KJ128NDataBase
{
    public class AddEmpDAL
    {
        #region [2008-6-23修改的添加员工信息的方法,通过EmpModel传参数，执行一条存储过程]

        ///// <summary>
        ///// 增加保存员工信息(全部10张表的信息)
        ///// </summary>
        ///// <param name="empModel">员工类实体，包含全部表信息</param>
        ///// <returns>返回执行影响的行数</returns>
        //public int InsertEmpInfo(EmpModel empModel)
        //{

        //    SqlParameter[] para = new SqlParameter[] {

        //        #region[Emp_Info 员工基本信息表]

        //        new SqlParameter("@EmpName",SqlDbType.NVarChar,20),
        //        new SqlParameter("@Sex",SqlDbType.Bit),
        //        new SqlParameter("@Remark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpNO",SqlDbType.NVarChar,10),
        //        new SqlParameter("@DeptID",SqlDbType.Int),

        //        new SqlParameter("@DutyID",SqlDbType.Int),
        //        new SqlParameter("@MaxSecTime",SqlDbType.Int),
        //        new SqlParameter("@MinSecTime",SqlDbType.Int),
        //        new SqlParameter("@Selectmode",SqlDbType.Int),
        //        new SqlParameter("@ClassGroup",SqlDbType.NVarChar,50),

        //        new SqlParameter("@WorkPlace",SqlDbType.NVarChar,50),
        //        new SqlParameter("@Photo",SqlDbType.Image),
        //        new SqlParameter("@EmpTel1",SqlDbType.NVarChar,20),
        //        new SqlParameter("@EmpTel2",SqlDbType.NVarChar,20),
        //        new SqlParameter("@EmpTel3",SqlDbType.NVarChar,20),

        //        new SqlParameter("@EmpQQ",SqlDbType.NVarChar,20),
        //        new SqlParameter("@EmpMsn",SqlDbType.NVarChar,20),
        //        new SqlParameter("@HomePage",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpEmail",SqlDbType.NVarChar,80),
        //        new SqlParameter("@EmpEmailBackup",SqlDbType.NVarChar,80),

        //        new SqlParameter("@Nation",SqlDbType.NVarChar,30),
        //        new SqlParameter("@WedlockID",SqlDbType.Int),
        //        new SqlParameter("@ClanID",SqlDbType.Int),
        //        new SqlParameter("@NativePlace",SqlDbType.NVarChar,50),
        //        new SqlParameter("@CensusRegister",SqlDbType.NVarChar,50),

        //        new SqlParameter("@SchoolRecordID",SqlDbType.Int),
        //        new SqlParameter("@GraduateFrom",SqlDbType.NVarChar,35),
        //        new SqlParameter("@Specialty",SqlDbType.NVarChar,50),
        //        new SqlParameter("@OfficialDesignation",SqlDbType.NVarChar,50),
        //        new SqlParameter("@Idcard",SqlDbType.NVarChar,20),

        //        new SqlParameter("@BirthDay",SqlDbType.DateTime),
        //        new SqlParameter("@Height",SqlDbType.Int),
        //        new SqlParameter("@Weight",SqlDbType.Int),
        //        new SqlParameter("@StateOfHealth",SqlDbType.NVarChar,50),
        //        new SqlParameter("@HomeTel1",SqlDbType.NVarChar,20),

        //        new SqlParameter("@HomeTel2",SqlDbType.NVarChar,20),
        //        new SqlParameter("@HomeAddress",SqlDbType.NVarChar,250),
        //        new SqlParameter("@Postalcode",SqlDbType.NVarChar,6),
        //        new SqlParameter("@ProbationDate",SqlDbType.DateTime),
        //        new SqlParameter("@OfficiallyDate",SqlDbType.DateTime),

        //        new SqlParameter("@ContractExpDate",SqlDbType.DateTime),
        //        new SqlParameter("@ContractExpAppendDate",SqlDbType.DateTime),
        //        new SqlParameter("@IsGearShift",SqlDbType.Bit),
        //        new SqlParameter("@HireTypeID",SqlDbType.Int),
        //        new SqlParameter("@Archives",SqlDbType.NVarChar,100),

        //        new SqlParameter("@DimissionTime",SqlDbType.DateTime),
        //        new SqlParameter("@EmpDetailRemark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpSerchRemark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpHomeRemark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpInCompanyRemark",SqlDbType.NVarChar,200),

        //        new SqlParameter("@EmpNowCompanyRemark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@WorkTypeID1",SqlDbType.Int),
        //        new SqlParameter("@IsMostly1",SqlDbType.Bit),
        //        new SqlParameter("@IsEnable1",SqlDbType.Bit),
        //        new SqlParameter("@WorkTypeID2",SqlDbType.Int),

        //        new SqlParameter("@IsMostly2",SqlDbType.Bit),
        //        new SqlParameter("@IsEnable2",SqlDbType.Bit),
        //        new SqlParameter("@WorkTypeID3",SqlDbType.Int),
        //        new SqlParameter("@IsMostly3",SqlDbType.Bit),
        //        new SqlParameter("@IsEnable3",SqlDbType.Bit),
        //        #endregion
        //    };

        //    para[0].Value = empModel.EmpName;
        //    para[1].Value = empModel.Sex;
        //    para[2].Value = empModel.BaseRemark;
        //    para[3].Value = empModel.EmpNO;
        //    para[4].Value = empModel.DeptID;

        //    para[5].Value = empModel.DutyID;
        //    para[6].Value = empModel.MaxSecTime;
        //    para[7].Value = empModel.MinSecTime;
        //    para[8].Value = empModel.SelectMode;
        //    para[9].Value = empModel.ClassGroup;

        //    para[10].Value = empModel.WorkPlace;
        //    para[11].Value = empModel.Photo;
        //    para[12].Value = empModel.EmpTel1;
        //    para[13].Value = empModel.EmpTel2;
        //    para[14].Value = empModel.EmpTel3;

        //    para[15].Value = empModel.EmpQQ;
        //    para[16].Value = empModel.EmpMsn;
        //    para[17].Value = empModel.HomePage;
        //    para[18].Value = empModel.EmpEmail;
        //    para[19].Value = empModel.EmpEmailBackUp;

        //    para[20].Value = empModel.Nation;
        //    para[21].Value = empModel.WedlockID;
        //    para[22].Value = empModel.ClanID;
        //    para[23].Value = empModel.NativePlace;
        //    para[24].Value = empModel.CensusRegister;

        //    para[25].Value = empModel.SchoolRecordID;
        //    para[26].Value = empModel.GraduateFrom;
        //    para[27].Value = empModel.Specialty;
        //    para[28].Value = empModel.OfficialDesignation;
        //    para[29].Value = empModel.IdCard;

            

        //    para[30].Value = empModel.BirthDay;
        //    para[31].Value = empModel.Height;
        //    para[32].Value = empModel.Weight;
        //    para[33].Value = empModel.StateOfHealth;
        //    para[34].Value = empModel.HomeTel1;

        //    para[35].Value = empModel.HomeTel2;
        //    para[36].Value = empModel.HomeAddress;
        //    para[37].Value = empModel.PostalCode;
        //    para[38].Value = empModel.ProbationDate;
        //    para[39].Value = empModel.OfficiallyDate;

        //    para[40].Value = empModel.ContractExpDate;
        //    para[41].Value = empModel.ContractExpAppendDate;
        //    para[42].Value = empModel.IsGearShift;
        //    para[43].Value = empModel.HireTypeID;
        //    para[44].Value = empModel.Archives;

        //    para[45].Value = empModel.DimissionTime;
        //    para[46].Value = empModel.DetailRemark;
        //    para[47].Value = empModel.SearchRemark;
        //    para[48].Value = empModel.HomeRemark;
        //    para[49].Value = empModel.InCompanyRemark;

        //    para[50].Value = empModel.NowCompanyRemark;
        //    para[51].Value = empModel.WorkType1.WorkTypeID;
        //    para[52].Value = empModel.WorkType1.IsMostly;
        //    para[53].Value = empModel.WorkType1.IsEnable;
        //    para[54].Value = empModel.WorkType2.WorkTypeID;

        //    para[55].Value = empModel.WorkType2.IsMostly;
        //    para[56].Value = empModel.WorkType2.IsEnable;
        //    para[57].Value = empModel.WorkType3.WorkTypeID;
        //    para[58].Value = empModel.WorkType3.IsMostly;
        //    para[59].Value = empModel.WorkType3.IsEnable;

        //    return dba.ExecuteSql("zjw_Emp_Insert", para);
        //}

        ///// <summary>
        ///// 修改保存员工信息(全部10张表的信息)
        ///// </summary>
        ///// <param name="empModel">员工类实体，包含全部表信息</param>
        ///// <returns>返回执行影响的行数</returns>
        //public int UpdateEmpInfo(EmpModel empModel)
        //{

        //    SqlParameter[] para = new SqlParameter[] {

        //        #region[Emp_Info 员工基本信息表]

        //        new SqlParameter("@EmpName",SqlDbType.NVarChar,20),
        //        new SqlParameter("@Sex",SqlDbType.Bit),
        //        new SqlParameter("@Remark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpNO",SqlDbType.NVarChar,10),
        //        new SqlParameter("@DeptID",SqlDbType.Int),

        //        new SqlParameter("@DutyID",SqlDbType.Int),
        //        new SqlParameter("@MaxSecTime",SqlDbType.Int),
        //        new SqlParameter("@MinSecTime",SqlDbType.Int),
        //        new SqlParameter("@Selectmode",SqlDbType.Int),
        //        new SqlParameter("@ClassGroup",SqlDbType.NVarChar,50),

        //        new SqlParameter("@WorkPlace",SqlDbType.NVarChar,50),
        //        new SqlParameter("@Photo",SqlDbType.Image),
        //        new SqlParameter("@EmpTel1",SqlDbType.NVarChar,20),
        //        new SqlParameter("@EmpTel2",SqlDbType.NVarChar,20),
        //        new SqlParameter("@EmpTel3",SqlDbType.NVarChar,20),

        //        new SqlParameter("@EmpQQ",SqlDbType.NVarChar,20),
        //        new SqlParameter("@EmpMsn",SqlDbType.NVarChar,20),
        //        new SqlParameter("@HomePage",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpEmail",SqlDbType.NVarChar,80),
        //        new SqlParameter("@EmpEmailBackup",SqlDbType.NVarChar,80),

        //        new SqlParameter("@Nation",SqlDbType.NVarChar,30),
        //        new SqlParameter("@WedlockID",SqlDbType.Int),
        //        new SqlParameter("@ClanID",SqlDbType.Int),
        //        new SqlParameter("@NativePlace",SqlDbType.NVarChar,50),
        //        new SqlParameter("@CensusRegister",SqlDbType.NVarChar,50),

        //        new SqlParameter("@SchoolRecordID",SqlDbType.Int),
        //        new SqlParameter("@GraduateFrom",SqlDbType.NVarChar,35),
        //        new SqlParameter("@Specialty",SqlDbType.NVarChar,50),
        //        new SqlParameter("@OfficialDesignation",SqlDbType.NVarChar,50),
        //        new SqlParameter("@Idcard",SqlDbType.NVarChar,20),

        //        new SqlParameter("@BirthDay",SqlDbType.DateTime),
        //        new SqlParameter("@Height",SqlDbType.Int),
        //        new SqlParameter("@Weight",SqlDbType.Int),
        //        new SqlParameter("@StateOfHealth",SqlDbType.NVarChar,50),
        //        new SqlParameter("@HomeTel1",SqlDbType.NVarChar,20),

        //        new SqlParameter("@HomeTel2",SqlDbType.NVarChar,20),
        //        new SqlParameter("@HomeAddress",SqlDbType.NVarChar,250),
        //        new SqlParameter("@Postalcode",SqlDbType.NVarChar,6),
        //        new SqlParameter("@ProbationDate",SqlDbType.DateTime),
        //        new SqlParameter("@OfficiallyDate",SqlDbType.DateTime),

        //        new SqlParameter("@ContractExpDate",SqlDbType.DateTime),
        //        new SqlParameter("@ContractExpAppendDate",SqlDbType.DateTime),
        //        new SqlParameter("@IsGearShift",SqlDbType.Bit),
        //        new SqlParameter("@HireTypeID",SqlDbType.Int),
        //        new SqlParameter("@Archives",SqlDbType.NVarChar,100),

        //        new SqlParameter("@DimissionTime",SqlDbType.DateTime),
        //        new SqlParameter("@EmpDetailRemark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpSerchRemark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpHomeRemark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@EmpInCompanyRemark",SqlDbType.NVarChar,200),

        //        new SqlParameter("@EmpNowCompanyRemark",SqlDbType.NVarChar,200),
        //        new SqlParameter("@WorkTypeID1",SqlDbType.Int),
        //        new SqlParameter("@IsMostly1",SqlDbType.Bit),
        //        new SqlParameter("@IsEnable1",SqlDbType.Bit),
        //        new SqlParameter("@WorkTypeID2",SqlDbType.Int),

        //        new SqlParameter("@IsMostly2",SqlDbType.Bit),
        //        new SqlParameter("@IsEnable2",SqlDbType.Bit),
        //        new SqlParameter("@WorkTypeID3",SqlDbType.Int),
        //        new SqlParameter("@IsMostly3",SqlDbType.Bit),
        //        new SqlParameter("@IsEnable3",SqlDbType.Bit),
        //        #endregion
        //    };

        //    para[0].Value = empModel.EmpName;
        //    para[1].Value = empModel.Sex;
        //    para[2].Value = empModel.BaseRemark;
        //    para[3].Value = empModel.EmpNO;
        //    para[4].Value = empModel.DeptID;

        //    para[5].Value = empModel.DutyID;
        //    para[6].Value = empModel.MaxSecTime;
        //    para[7].Value = empModel.MinSecTime;
        //    para[8].Value = empModel.SelectMode;
        //    para[9].Value = empModel.ClassGroup;

        //    para[10].Value = empModel.WorkPlace;
        //    para[11].Value = empModel.Photo;
        //    para[12].Value = empModel.EmpTel1;
        //    para[13].Value = empModel.EmpTel2;
        //    para[14].Value = empModel.EmpTel3;

        //    para[15].Value = empModel.EmpQQ;
        //    para[16].Value = empModel.EmpMsn;
        //    para[17].Value = empModel.HomePage;
        //    para[18].Value = empModel.EmpEmail;
        //    para[19].Value = empModel.EmpEmailBackUp;

        //    para[20].Value = empModel.Nation;
        //    para[21].Value = empModel.WedlockID;
        //    para[22].Value = empModel.ClanID;
        //    para[23].Value = empModel.NativePlace;
        //    para[24].Value = empModel.CensusRegister;

        //    para[25].Value = empModel.SchoolRecordID;
        //    para[26].Value = empModel.GraduateFrom;
        //    para[27].Value = empModel.Specialty;
        //    para[28].Value = empModel.OfficialDesignation;
        //    para[29].Value = empModel.IdCard;



        //    para[30].Value = empModel.BirthDay;
        //    para[31].Value = empModel.Height;
        //    para[32].Value = empModel.Weight;
        //    para[33].Value = empModel.StateOfHealth;
        //    para[34].Value = empModel.HomeTel1;

        //    para[35].Value = empModel.HomeTel2;
        //    para[36].Value = empModel.HomeAddress;
        //    para[37].Value = empModel.PostalCode;
        //    para[38].Value = empModel.ProbationDate;
        //    para[39].Value = empModel.OfficiallyDate;

        //    para[40].Value = empModel.ContractExpDate;
        //    para[41].Value = empModel.ContractExpAppendDate;
        //    para[42].Value = empModel.IsGearShift;
        //    para[43].Value = empModel.HireTypeID;
        //    para[44].Value = empModel.Archives;

        //    para[45].Value = empModel.DimissionTime;
        //    para[46].Value = empModel.DetailRemark;
        //    para[47].Value = empModel.SearchRemark;
        //    para[48].Value = empModel.HomeRemark;
        //    para[49].Value = empModel.InCompanyRemark;

        //    para[50].Value = empModel.NowCompanyRemark;
        //    para[51].Value = empModel.WorkType1.WorkTypeID;
        //    para[52].Value = empModel.WorkType1.IsMostly;
        //    para[53].Value = empModel.WorkType1.IsEnable;
        //    para[54].Value = empModel.WorkType2.WorkTypeID;

        //    para[55].Value = empModel.WorkType2.IsMostly;
        //    para[56].Value = empModel.WorkType2.IsEnable;
        //    para[57].Value = empModel.WorkType3.WorkTypeID;
        //    para[58].Value = empModel.WorkType3.IsMostly;
        //    para[59].Value = empModel.WorkType3.IsEnable;

        //    return dba.ExecuteSql("zjw_Emp_Update", para);
        //}

        #endregion





        #region [ 声明 ]

        private DeptDAL ddal = new DeptDAL();
        private DBAcess dba = new DBAcess();
        DbHelperSQL DB = new DbHelperSQL();
        string sqlString = string.Empty;

        #endregion


        #region [ 方法: 存储员工基本信息 ]
        /// <summary>
        /// 存储员工基本信息
        /// </summary>
        /// <param name="empName">员工姓名</param>
        /// <param name="empNO">员工工号</param>
        /// <param name="sex">员工性别</param>
        /// <param name="remark">备注</param>
        /// <returns>返回影响行数(int)</returns>
        public int SaveEmployeeBaseInfoData(string empName, string empNO, bool sex, string remark)
        {

            string procName = "KJ128N_Emp_Info_Insert";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("EmpName",SqlDbType.NVarChar,20),
                new SqlParameter("EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("Sex",SqlDbType.Bit),
                new SqlParameter("Remark",SqlDbType.NVarChar,200)
            };
            sqlParmeters[0].Value = empName;
            sqlParmeters[1].Value = empNO;
            sqlParmeters[2].Value = sex;
            sqlParmeters[3].Value = remark;
            return dba.ExecuteSql(procName, sqlParmeters);

        }
        #endregion

        #region [ 方法: 存储员工信息明细 ]

        /// <summary>
        /// 添加员工信息明细
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="Nation">民族</param>
        /// <param name="WedlockID">婚姻状况</param>
        /// <param name="ClanID">政治面貌</param>
        /// <param name="NativePlace">籍贯</param>
        /// <param name="CensusRegister">户籍</param>
        /// <param name="SchoolRecordID">学历</param>
        /// <param name="GraduateFrom">毕业院校</param>
        /// <param name="Specialty">专业</param>
        /// <param name="OfficialDesignation">职称</param>
        /// <param name="Remark">备注</param>
        /// <param name="BirthDay">生日</param>
        /// <param name="IDcard">身份证</param>
        /// <returns>返回影响行数</returns>
        public int SaveEmployeeDetaiData(string EmpNO, String Nation, int WedlockID, int ClanID, String NativePlace, String CensusRegister, int SchoolRecordID, String GraduateFrom, String Specialty, String OfficialDesignation, String Remark, String BirthDay, String IDcard)
        {
            string procName = "KJ128N_Emp_Detail_InsertAndUpDate";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("Nation",SqlDbType.NVarChar,30),
                new SqlParameter("WedlockID",SqlDbType.Int),
                new SqlParameter("ClanID",SqlDbType.Int),
                new SqlParameter("NativePlace",SqlDbType.NVarChar,50),
                new SqlParameter("CensusRegister",SqlDbType.NVarChar,50),
                new SqlParameter("SchoolRecordID",SqlDbType.Int),
                new SqlParameter("GraduateFrom",SqlDbType.NVarChar,35),
                new SqlParameter("Specialty",SqlDbType.NVarChar,50),
                new SqlParameter("OfficialDesignation",SqlDbType.NVarChar,50),
                new SqlParameter("Remark",SqlDbType.NVarChar,200),
                new SqlParameter("BirthDay",SqlDbType.DateTime),
                new SqlParameter("IDcard",SqlDbType.NVarChar,20)
            };
            sqlParmeters[0].Value = EmpNO;
            sqlParmeters[1].Value = Nation.ToString();
            sqlParmeters[2].Value = WedlockID; //comboBox_EmployeeWedlock.SelectedIndex;
            sqlParmeters[3].Value = ClanID;// comboBox_EmployeeClan.SelectedIndex;
            sqlParmeters[4].Value = NativePlace.ToString();
            sqlParmeters[5].Value = CensusRegister.ToString();
            sqlParmeters[6].Value = SchoolRecordID;// comboBox_EmployeeSchoolRecord.SelectedIndex;
            sqlParmeters[7].Value = GraduateFrom.ToString();
            sqlParmeters[8].Value = Specialty.ToString();
            sqlParmeters[9].Value = OfficialDesignation.ToString();
            sqlParmeters[10].Value = Remark.ToString();

            if (BirthDay == "")
            {
                sqlParmeters[11].Value = DateTime.Parse("1800-01-01");
            }
            else
            {
                sqlParmeters[11].Value = DateTime.Parse(BirthDay);
            }
            sqlParmeters[12].Value = IDcard.ToString();
            return dba.ExecuteSql(procName, sqlParmeters);
        }
        #endregion

        #region [ 方法: 存储员工联系方式 ]

        /// <summary>
        /// 添加员工联系方式
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="EmpTel1">手机号码</param>
        /// <param name="EmpTel2">小灵通号码</param>
        /// <param name="EmpTel3">备用电话号码</param>
        /// <param name="EmpQQ">QQ号码</param>
        /// <param name="EmpMsn">Msn号码</param>
        /// <param name="HomePage">个人主页</param>
        /// <param name="EmpEmail">电子邮箱(主)</param>
        /// <param name="EmpEmailBackup">电子邮箱(备用)</param>
        /// <param name="Remark">备注</param>
        /// <returns>返回影响行数</returns>
        public int SaveEmployeeSearchData(string EmpNO, String EmpTel1, String EmpTel2, String EmpTel3, String EmpQQ, String EmpMsn, String HomePage, String EmpEmail, String EmpEmailBackup, String Remark)
        {
            string procName = "KJ128N_Emp_Search_InsertAndUpDate";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("EmpTel1",SqlDbType.NVarChar,20),
                new SqlParameter("EmpTel2",SqlDbType.NVarChar,20),
                new SqlParameter("EmpTel3",SqlDbType.NVarChar,20),
                new SqlParameter("EmpQQ",SqlDbType.NVarChar,20),
                new SqlParameter("EmpMsn",SqlDbType.NVarChar,100),
                new SqlParameter("HomePage",SqlDbType.NVarChar,200),
                new SqlParameter("EmpEmail",SqlDbType.NVarChar,80),
                new SqlParameter("EmpEmailBackup",SqlDbType.NVarChar,80),
                new SqlParameter("Remark",SqlDbType.NVarChar,200)
            };
            sqlParmeters[0].Value = EmpNO;
            sqlParmeters[1].Value = EmpTel1.ToString();
            sqlParmeters[2].Value = EmpTel2.ToString();
            sqlParmeters[3].Value = EmpTel3.ToString();
            sqlParmeters[4].Value = EmpQQ.ToString();
            sqlParmeters[5].Value = EmpMsn.ToString();
            sqlParmeters[6].Value = HomePage.ToString();
            sqlParmeters[7].Value = EmpEmail.ToString();
            sqlParmeters[8].Value = EmpEmailBackup.ToString();
            sqlParmeters[9].Value = Remark.ToString();

            return dba.ExecuteSql(procName, sqlParmeters);

        }
        #endregion

        #region [ 方法: 存储员工家庭信息 ]

        /// <summary>
        /// 添加员工家庭信息
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="HomeTel1">家庭电话1</param>
        /// <param name="HomeTel2">家庭电话2</param>
        /// <param name="HomeAddress">家庭住址</param>
        /// <param name="Postalcode">邮政编码</param>
        /// <param name="Remark">备注</param>
        /// <returns>返回影响行数</returns>
        public int SaveEmployeeHomeData(string EmpNO, String HomeTel1, String HomeTel2, String HomeAddress, String Postalcode, String Remark)
        {
            string procName = "KJ128N_Emp_Home_InsertAndUpDate";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("HomeTel1",SqlDbType.NVarChar,20),
                new SqlParameter("HomeTel2",SqlDbType.NVarChar,20),
                new SqlParameter("HomeAddress",SqlDbType.NVarChar,250),
                new SqlParameter("Postalcode",SqlDbType.NVarChar,6),
                new SqlParameter("Remark",SqlDbType.NVarChar,200)
            };
            sqlParmeters[0].Value = EmpNO;
            sqlParmeters[1].Value = HomeTel1.ToString();
            sqlParmeters[2].Value = HomeTel2.ToString();
            sqlParmeters[3].Value = HomeAddress.ToString();
            sqlParmeters[4].Value = Postalcode.ToString();
            sqlParmeters[5].Value = Remark.ToString();
            return dba.ExecuteSql(procName, sqlParmeters);
        }
        #endregion

        #region [ 方法: 存储员工进公司情况 ]

        /// <summary>
        /// 添加员工进公司情况
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="ProbationDate">试用日期</param>
        /// <param name="OfficiallyDate">转正日期</param>
        /// <param name="ContractExpDate">合同有效期</param>
        /// <param name="ContractExpAppendDate">续签有效期</param>
        /// <param name="IsGearShift">是否已调档</param>
        /// <param name="HireTypeID">聘用形式</param>
        /// <param name="Archives">档案所在地</param>
        /// <param name="DimissionTime">离职时间</param>
        /// <param name="Remark">备注</param>
        /// <returns>返回影响行数</returns>
        public int SaveEmployeeComeCompanyInfoData(string EmpNO, String ProbationDate, String OfficiallyDate, String ContractExpDate, String ContractExpAppendDate, Byte IsGearShift, Int32 HireTypeID, String Archives, String DimissionTime, String Remark)
        {
            //DataBaseSave dbSave = new DataBaseSave();
            //IDBAcess iDBAcess = dbSave.GetDBAcess();
            string procName = "KJ128N_Emp_InCompany_InsertAndUpDate";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("ProbationDate",SqlDbType.DateTime),
                new SqlParameter("OfficiallyDate",SqlDbType.DateTime),
                new SqlParameter("ContractExpDate",SqlDbType.DateTime),
                new SqlParameter("ContractExpAppendDate",SqlDbType.DateTime),
                new SqlParameter("IsGearShift",SqlDbType.Bit),
                new SqlParameter("HireTypeID",SqlDbType.Int),
                new SqlParameter("Archives",SqlDbType.NVarChar,100),
                new SqlParameter("DimissionTime",SqlDbType.DateTime),
                new SqlParameter("Remark",SqlDbType.NVarChar,200)

            };
            sqlParmeters[0].Value = EmpNO;
            if (ProbationDate == "")
            {
                sqlParmeters[1].Value = DateTime.Parse("1800-01-01");
            }
            else
            {
                sqlParmeters[1].Value = DateTime.Parse(ProbationDate);
            }
            if (OfficiallyDate == "")
            {
                sqlParmeters[2].Value = DateTime.Parse("1800-01-01");
            }
            else
            {
                sqlParmeters[2].Value = DateTime.Parse(OfficiallyDate);
            }
            if (ContractExpDate == "")
            {
                sqlParmeters[3].Value = DateTime.Parse("1800-01-01");
            }
            else
            {
                sqlParmeters[3].Value = DateTime.Parse(ContractExpDate);
            }
            if (ContractExpAppendDate == "")
            {
                sqlParmeters[4].Value = DateTime.Parse("1800-01-01");
            }
            else
            {
                sqlParmeters[4].Value = DateTime.Parse(ContractExpAppendDate);
            }

            sqlParmeters[5].Value = IsGearShift;

            sqlParmeters[6].Value = HireTypeID;// combobox_EmployeeHireType.SelectedIndex;
            sqlParmeters[7].Value = Archives.ToString();
            if (DimissionTime == "")
            {
                sqlParmeters[8].Value = DateTime.Parse("1800-01-01");
            }
            else
            {
                sqlParmeters[8].Value = DateTime.Parse(DimissionTime);
            }
            sqlParmeters[9].Value = Remark.ToString();
            return dba.ExecuteSql(procName, sqlParmeters);
        }
        #endregion

        #region [ 方法: 存储员工在单位情况 ]

        /// <summary>
        /// 添加员工在单位情况
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="DeptID">部门ID</param>
        /// <param name="DutyID">职务ID</param>
        /// <param name="Remark">备注</param>
        /// <returns>返回影响行数</returns>
        public int SaveEmployeeNowCompanyData(string EmpNO, int DeptID, int DutyID, int MaxTimeSec, int MinTimeSec, int SelectMode, string Remark, string strClassGroup, string strWorkPlace)
        {
            string procName = "KJ128N_Emp_NowCompany_InsertAndUpDate";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("DeptID",SqlDbType.Int),
                new SqlParameter("DutyID",SqlDbType.Int),
                new SqlParameter("MaxSecTime",SqlDbType.Int),
                new SqlParameter("MinSecTime",SqlDbType.Int),
                new SqlParameter("SelectMode",SqlDbType.Int),
                new SqlParameter("Remark",SqlDbType.NVarChar,200),
                new SqlParameter("ClassGroup",SqlDbType.NVarChar,50),
                new SqlParameter("WorkPlace",SqlDbType.NVarChar,50)
            };
            sqlParmeters[0].Value = EmpNO;
            sqlParmeters[1].Value = DeptID;
            sqlParmeters[2].Value = DutyID;
            sqlParmeters[3].Value = MaxTimeSec;
            sqlParmeters[4].Value = MinTimeSec;
            sqlParmeters[5].Value = SelectMode;
            sqlParmeters[6].Value = Remark;
            sqlParmeters[7].Value = strClassGroup;
            sqlParmeters[8].Value = strWorkPlace;

            return dba.ExecuteSql(procName, sqlParmeters);
        }
        #endregion

        #region [ 方法: 存储员工健康状况 ]

        /// <summary>
        /// 添加员工健康状况
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="Height">身高</param>
        /// <param name="Weight">体重</param>
        /// <param name="StateOfHealth">健康状况</param>
        /// <returns>返回影响行数</returns>
        public int SaveHealthData(string EmpNO, int Height, int Weight, string StateOfHealth)
        {
            string procName = "KJ128N_Emp_Health_InsertAndUpDate";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("Height",SqlDbType.Int),
                new SqlParameter("Weight",SqlDbType.Int),
                new SqlParameter("StateOfHealth",SqlDbType.NVarChar,200)
            };
            sqlParmeters[0].Value = EmpNO;
            sqlParmeters[1].Value = Height;
            sqlParmeters[2].Value = Weight;
            sqlParmeters[3].Value = StateOfHealth;
            return dba.ExecuteSql(procName, sqlParmeters);
        }
        #endregion

        #region [ 方法: 添加 照片 ]

        public int SaveEmpPhoto(string EmpNO, byte[] Photo, string Remark)
        {
            string procName = "KJ128N_Emp_Photo_Insert";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("Photo",SqlDbType.Image),
                new SqlParameter("Remark",SqlDbType.NVarChar,200)
            };
            sqlParmeters[0].Value = EmpNO;
            sqlParmeters[1].Value = Photo;
            sqlParmeters[2].Value = Remark;
            return dba.ExecuteSql(procName, sqlParmeters);
        }

        #endregion

        #region [ 方法: 修改 照片 ]

        public int UpDateEmpPhoto(int PhotoID, string EmpNO, byte[] Photo, string Remark)
        {
            string procName = "KJ128N_Emp_Photo_UpDate";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("PhotoID",SqlDbType.Int),
                new SqlParameter("EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("Photo",SqlDbType.Image),
                new SqlParameter("Remark",SqlDbType.NVarChar,200)
            };
            sqlParmeters[0].Value = PhotoID;
            sqlParmeters[1].Value = EmpNO;
            sqlParmeters[2].Value = Photo;
            sqlParmeters[3].Value = Remark;
            return dba.ExecuteSql(procName, sqlParmeters);
        }
        #endregion

        #region [ 方法: 删除 照片 ]

        public int DeleteEmpPhoto(int EmpID)
        {
            sqlString = string.Format("delete from Emp_Photo where EmpID={0}", EmpID);
            return dba.ExecuteSql(sqlString);
        }
        #endregion

        #region [ 方法: 增加员工工种信息 ]

        public int SaveWorkTypeData(string EmpNO, int WorkTypeID, int IsMostly, int IsEnable)
        {
            string SaveString = string.Format(" DECLARE @EmpID int  if(exists(select * From Emp_Info where EmpNO ='{0}')) "
                    + " begin "
                    + " select @EmpID = EmpID from Emp_Info where EmpNO = '{0}' "
                    + " insert into Emp_WorkType(EmpID,WorkTypeID,IsMostly,IsEnable) values(@EmpID,{1},{2},{3})"
                    + " end ",
                    EmpNO, WorkTypeID, IsMostly, IsEnable);
            return dba.ExecuteSql(SaveString);
        }

        #endregion

        #region [ 方法: 修改员工基本信息 ]

        public int UpDateEmpInfo(int EmpID, string EmpNO, string EmpName, int Sex, string Remark)
        {
            string updateString = string.Format("update Emp_Info set EmpNO='{0}',EmpName='{1}',Sex={2},Remark='{3}'"
                + " where EmpID = {4}", EmpNO, EmpName, Sex, Remark, EmpID);
            return dba.ExecuteSql(updateString);
        }
        #endregion

        #region [ 方法: 修改 员工工种信息 ]

        public int UpDateEmpWorkType(int EmpWorkTypeID, int WorkTypeID, byte IsMostly, byte IsEnable)
        {
            string updateString = string.Format("update Emp_WorkType set WorkTypeID={0},IsMostly={1},IsEnable={2}"
                + " where EmpWorkTypeID = {3}", WorkTypeID, IsMostly, IsEnable, EmpWorkTypeID);
            return dba.ExecuteSql(updateString);
        }

        #endregion

        #region [ 方法: 删除 工种信息 ]

        public int DeleteEmpWorkType(int EmpWorkTypeID)
        {
            sqlString = string.Format("delete from Emp_WorkType where EmpWorkTypeID={0}", EmpWorkTypeID);
            return dba.ExecuteSql(sqlString);
        }
        #endregion

        #region [ 方法: 获取部门信息Table ]

        /// <summary>
        /// 获取部门信息Table
        /// </summary>
        /// <returns>返回部门信息Table</returns>
        public DataTable GetDeparmentTab()
        {
            DataTable dt;
            sqlString = "select DeptID,DeptName from KJ128N_Dept_Info_Select_ComboBox_View";
            using (DataSet ds = dba.GetDataSet(sqlString))
            {
                if (ds != null)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = null;
                }
            }
            return dt;
        }
        #endregion

        #region [ 方法: 获取工种Table ]

        /// <summary>
        /// 获取工种Table
        /// </summary>
        /// <returns>返回工种Table</returns>
        public DataTable GetWorkTypeTab()
        {
            DataTable dt;
            sqlString = "select WorkTypeID,WtName from WorkType_Info";
            using (DataSet ds = dba.GetDataSet(sqlString))
            {
                if (ds != null)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = null;
                }
            }
            return dt;
        }
        #endregion

        #region [ 方法: 获取职务Table ]

        /// <summary>
        /// 获取职务Table
        /// </summary>
        /// <returns>返回职务Table</returns>
        public DataTable GetEmpDutyTab()
        {

            sqlString = "select DutyID,职务名称 from KJ128N_Duty_Info_Table";
            KJ128NDataBase.DBAcess dbAcess = new KJ128NDataBase.DBAcess();
            using (DataSet ds = dbAcess.GetDataSet(sqlString))
            {
                if (ds != null)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region [ 方法: 根据SQL语句，返回人员信息(DataTable) ]

        /// <summary>
        /// 根据SQL语句，返回人员信息(DataTable)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回人员信息(DataTable)</returns>
        public DataTable GetDataTableEmp(string sql)
        {
            using (DataSet ds = dba.GetDataSet(sql))
            {
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    #region
                    DataColumn dcDutyClass = new DataColumn("职务等级");
                    DataColumn dcSelectMode = new DataColumn("启用模式");
                    DataColumn dcMax = new DataColumn("最大工作时间");
                    DataColumn dcMin = new DataColumn("最小工作时间");
                    dt.Columns.Add(dcDutyClass);
                    dt.Columns.Add(dcSelectMode);
                    dt.Columns.Add(dcMax);
                    dt.Columns.Add(dcMin);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string strSql1, strSql2, strSql3, strMax, strMin;
                        strSql1 = string.Format("select Title from EnumTable where FunID =4 and EnumID={0}", Convert.ToInt32(dt.Rows[j][6]));
                        dt.Rows[j]["职务等级"] = ddal.GetString(strSql1);
                        strSql2 = string.Format("select Title from EnumTable where FunID =45 and EnumID={0}", Convert.ToInt32(dt.Rows[j][7]));
                        dt.Rows[j]["启用模式"] = ddal.GetString(strSql2);
                        #region 计算最大工作时间
                        if (Convert.ToInt32(dt.Rows[j][7]) == 1)
                        {
                            if (dt.Rows[j][9].ToString().CompareTo("") == 0)
                            {
                                strMax = "无";
                            }
                            else
                            {
                                int intMax = Convert.ToInt32(dt.Rows[j][9]);
                                int hourMax = intMax / 3600;
                                int minuteMax = (intMax - hourMax * 3600) / 60;
                                int secondMax = intMax % 60;
                                strMax = hourMax + "时" + minuteMax + "分" + secondMax + "秒";
                            }

                            if (dt.Rows[j][10].ToString().CompareTo("") == 0)
                            {
                                strMin = "无";
                            }
                            else
                            {
                                int intMin = Convert.ToInt32(dt.Rows[j][10]);
                                int hourMin = intMin / 3600;
                                int minuteMin = (intMin - hourMin * 3600) / 60;
                                int secondMin = intMin % 60;
                                strMin = hourMin + "时" + minuteMin + "分" + secondMin + "秒";
                            }
                        }
                        else if (Convert.ToInt32(dt.Rows[j][7]) == 2)
                        {
                            strSql3 = string.Format("select * from Dept_SysSet where DeptID={0}", Convert.ToInt32(dt.Rows[j][8]));
                            DataTable dtTempSetTime = ddal.GetTable(strSql3);
                            if (dtTempSetTime != null)
                            {
                                if (dtTempSetTime.Rows[0][2].ToString().CompareTo("") == 0)
                                {
                                    strMax = "无";
                                }
                                else
                                {
                                    int intMax = Convert.ToInt32(dtTempSetTime.Rows[0][2]);
                                    int hourMax = intMax / 3600;
                                    int minuteMax = (intMax - hourMax * 3600) / 60;
                                    int secondMax = intMax % 60;
                                    strMax = hourMax + "时" + minuteMax + "分" + secondMax + "秒";
                                }
                                if (dtTempSetTime.Rows[0][3].ToString().CompareTo("") == 0)
                                {
                                    strMin = "无";
                                }
                                else
                                {
                                    int intMin = Convert.ToInt32(dtTempSetTime.Rows[0][3]);
                                    int hourMin = intMin / 3600;
                                    int minuteMin = (intMin - hourMin * 3600) / 60;
                                    int secondMin = intMin % 60;
                                    strMin = hourMin + "时" + minuteMin + "分" + secondMin + "秒";
                                }
                            }
                            else
                            {
                                strMax = "";
                                strMin = "";
                            }
                        }
                        else
                        {
                            strMax = "";
                            strMin = "";
                        }
                        dt.Rows[j]["最大工作时间"] = strMax.ToString();
                        dt.Rows[j]["最小工作时间"] = strMin.ToString();
                        #endregion
                    }
                    #endregion
                    return dt;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region [ 方法: 人员信息 ]

        //int pageIndex,int pageSize,string where//View_GetRTDeptInfo
        //public DataSet GetEmpInfo(SqlParameter[] para)
        //{
        //    return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        //}

        public DataSet GetEmpInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "KJ128N_Emp_Table";
            para[1].Value = "员工编号";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region [ 方法: 部门表信息 ]

        // 填充部门树
        public DataTable GetDeptInfo()
        {
            return dba.GetDataSet("select * from Dept_Info Order By DeptLevelID ").Tables[0];
        }

        #endregion

        #region [ 方法: 删除 人员信息 ]

        public int DeleteEmp(int EmpID)
        {
            int i;
            string sqlStr1 = string.Format("delete from Emp_Info where EmpID={0}", EmpID);
            i = dba.ExecuteSql(sqlStr1);
            string sqlStr2 = string.Format("select * from CodeSender_Set where UserID={0} and CsTypeID=0", EmpID);
            if (GetBool(sqlStr2))
            {
                string sqlStr3 = string.Format("delete from CodeSender_Set where UserID={0} and CsTypeID=0", EmpID);
                i = dba.ExecuteSql(sqlStr3);
            }
            return i;
        }

        #endregion

        #region [ 方法: 获取PhotoID ]

        public int GetPhotoID(int EmpID)
        {
            string strsql;//= string.Format("select PhotoID from Emp_Photo where EmpID =", EmpID);
            strsql = "select PhotoID from Emp_Photo where EmpID =" + EmpID;
            return ddal.GetID(strsql);
        }

        #endregion

        #region  [ 方法: 根据PhotoID，返回DataTable ]

        public DataTable GetPhotoTab(int PhotoID)
        {
            sqlString = string.Format("select * from Emp_Photo where PhotoID={0}", PhotoID);
            KJ128NDataBase.DBAcess dbAcess = new KJ128NDataBase.DBAcess();
            using (DataSet ds = dbAcess.GetDataSet(sqlString))
            {
                if (ds != null)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region [ 方法: 根据SQL语句，返回是否有数据 ]

        public bool GetBool(string strsql)
        {
            using (DataSet ds = dba.GetDataSet(strsql))
            {
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region [ 方法: 根据部门和发码器得到员工姓名 ]

        public DataSet GetEmployeeNameByDeptIDAndCoderSenderID(int intDeptID, int intBlockID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DeptID",SqlDbType.Int,4),
                new SqlParameter("@BlockID",SqlDbType.Int,4)
            };

            parameters[0].Value = intDeptID;
            parameters[1].Value = intBlockID;

            return dba.ExecuteSqlDataSet("Shine_Shen_GetEmployeeInfoByDeptID", parameters);
        }
        #endregion

        #region [ 方法: 根据条件来绑定下拉列表框 ]

        /// <summary>
        /// 绑定列表框
        /// </summary>
        /// <param name="list">列表框</param>
        /// <param name="textField">显示内容</param>
        /// <param name="valueField"></param>
        /// <param name="strWhere"></param>
        /// <param name="strErrMsg"></param>
        public DataSet GetDropDownList(string textField, string valueField, string strWhere, out string strErrMsg)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@textField ", SqlDbType.VarChar, 50),
                    new SqlParameter("@valueField ", SqlDbType.VarChar, 50),
                    new SqlParameter("@strWhere ", SqlDbType.VarChar, 1000)};
            parameters[0].Value = textField;
            parameters[1].Value = valueField;
            parameters[2].Value = strWhere;
            return DB.RunProcedureByDataSet("Shine_GetDropDownListData", "ds", parameters, out strErrMsg);
        }
        #endregion

        #region [ 方法: 判断数据库中是否存在该员工编号 ]

        public DataSet IsEmpNO(string strEmpNO)
        {
            sqlString = string.Format("select EmpNo from Emp_Info where EmpNo='{0}'", strEmpNO);

            return dba.GetDataSet(sqlString);
        }

        #endregion

        #region [ 方法: 获取职务信息 ]
        public DataSet GetDutyNameInfo()
        {
            sqlString = " Select DutyID, DutyName From Duty_Info ";
            return dba.GetDataSet(sqlString);
        }
        #endregion

        #region [ 方法: 获取部门信息 ]

        public DataSet GetDeptNameInfo()
        {
            sqlString = " Select DeptID, DeptName From Dept_Info ";
            return dba.GetDataSet(sqlString);
        }

        #endregion


    }
}
