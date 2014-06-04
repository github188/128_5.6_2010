using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    /// <summary>
    /// 员工信息实体类，包含多张表信息
    /// </summary>
    public class EmpModel
    {

        public EmpModel()
        {
            workType1.EmpWorkTypeID = 0;
            workType2.EmpWorkTypeID = 0;
            workType3.EmpWorkTypeID = 0;
        }

        #region 员工基本信息[Emp_Info]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            EmpID	Y	Y	int	4	10	0			EmpID
            EmpName			nvarchar	40	20	0	Y		员工姓名
            Sex			bit	1	1	0	Y		性别
            Remark			nvarchar	400	200	0	Y		备注
            EmpNO			nvarchar	20	10	0	Y		员工编号
         *
         */

        /// <summary>
        /// 员工基本信息流水号
        /// </summary>
        private int empID;
        /// <summary>
        /// 员工基本信息流水号
        /// </summary>
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        /// <summary>
        /// 员工编号
        /// </summary>
        private string empNO;
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmpNO
        {
            get { return empNO; }
            set { empNO = value; }
        }

        /// <summary>
        /// 员工性别
        /// </summary>
        private bool sex;
        /// <summary>
        /// 员工性别
        /// </summary>
        public bool Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        /// <summary>
        /// 员工姓名
        /// </summary>
        private string empName;
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        /// <summary>
        /// 员工基本表备注
        /// </summary>
        private string baseRemark;
        /// <summary>
        /// 员工基本表备注
        /// </summary>
        public string BaseRemark
        {
            get { return baseRemark; }
            set { baseRemark = value; }
        }

        #endregion

        #region 员工详细信息[Emp_Detail]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            EmpDetailID	Y	Y	int	4	10	0			EmpDetailID
            EmpID			int	4	10	0	Y		EmpID
            Nation			nvarchar	60	30	0	Y		民族
            WedlockID			int	4	10	0	Y		WedlockID（婚姻状况）
            ClanID			int	4	10	0	Y		ClanID(政治面貌)
            NativePlace			nvarchar	100	50	0	Y		籍贯
            CensusRegister			nvarchar	100	50	0	Y		户籍
            SchoolRecordID			int	4	10	0	Y		SchoolRecordID(学历)
            GraduateFrom			nvarchar	70	35	0	Y		毕业院校
            Specialty			nvarchar	100	50	0	Y		专业
            OfficialDesignation			nvarchar	100	50	0	Y		职称
            PhotoID			int	4	10	0	Y		PhotoID(照片)
            Idcard			nvarchar	40	20	0	Y		身份证编号
            BirthDay			datetime	8	23	3	Y		生日
            Remark			nvarchar	400	200	0	Y		备注
         * 
         */

        /// <summary>
        /// 员工详细信息流水号
        /// </summary>
        private int empDetailID;
        /// <summary>
        /// 员工详细信息流水号
        /// </summary>
        public int EmpDetailID
        {
            get { return empDetailID; }
            set { empDetailID = value; }
        }

        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        private int empIDToDetail;
        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        public int EmpIDToDetail
        {
            get { return empIDToDetail; }
            set { empIDToDetail = value; }
        }

        /// <summary>
        /// 民族
        /// </summary>
        private string nation;
        /// <summary>
        /// 民族
        /// </summary>
        public string Nation
        {
            get { return nation; }
            set { nation = value; }
        }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        private string wedlock;
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Wedlock
        {
            get { return wedlock; }
            set { wedlock = value; }
        }

        /// <summary>
        /// 政治面貌
        /// </summary>
        private string clan;
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Clan
        {
            get { return clan; }
            set { clan = value; }
        }

        /// <summary>
        /// 籍贯
        /// </summary>
        private string nativePlace;
        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace
        {
            get { return nativePlace; }
            set { nativePlace = value; }
        }

        /// <summary>
        /// 户籍
        /// </summary>
        private string censusRegister;
        /// <summary>
        /// 户籍
        /// </summary>
        public string CensusRegister
        {
            get { return censusRegister; }
            set { censusRegister = value; }
        }

        /// <summary>
        /// 学历
        /// </summary>
        private string schoolRecord;
        /// <summary>
        /// 学历
        /// </summary>
        public string SchoolRecord
        {
            get { return schoolRecord; }
            set { schoolRecord = value; }
        }

        /// <summary>
        /// 毕业院校
        /// </summary>
        private string graduateFrom;
        /// <summary>
        /// 毕业院校
        /// </summary>
        public string GraduateFrom
        {
            get { return graduateFrom; }
            set { graduateFrom = value; }
        }

        /// <summary>
        /// 专业
        /// </summary>
        private string specialty;
        /// <summary>
        /// 专业
        /// </summary>
        public string Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }

        /// <summary>
        /// 职称
        /// </summary>
        private string officialDesignation;
        /// <summary>
        /// 职称
        /// </summary>
        public string OfficialDesignation
        {
            get { return officialDesignation; }
            set { officialDesignation = value; }
        }

        /// <summary>
        /// 照片ID,对应照片表里面的photoID流水号
        /// </summary>
        private int photoIDToDetail;
        /// <summary>
        /// 照片ID,对应照片表里面的photoID流水号
        /// </summary>
        public int PhotoIDToDetail
        {
            get { return photoIDToDetail; }
            set { photoIDToDetail = value; }
        }

        /// <summary>
        /// 身份证编号
        /// </summary>
        private string idCard;
        /// <summary>
        /// 身份证编号
        /// </summary>
        public string IdCard
        {
            get { return idCard; }
            set { idCard = value; }
        }

        /// <summary>
        /// 生日
        /// </summary>
        private DateTime birthDay;
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        /// <summary>
        /// 员工详细信息备注
        /// </summary>
        private string detailRemark;
        /// <summary>
        /// 员工详细信息备注
        /// </summary>
        public string DetailRemark
        {
            get { return detailRemark; }
            set { detailRemark = value; }
        }

        /// <summary>
        /// 血型
        /// </summary>
        private string company;
        /// <summary>
        /// 血型
        /// </summary>
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        #endregion

        #region 员工健康信息[Emp_Health]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            EmpHealthID	Y	Y	int	4	10	0			EmpHealthID
            EmpID			int	4	10	0	Y		EmpID
            Height			int	4	10	0	Y		身高
            Weight			int	4	10	0	Y		体重
            StateOfHealth			nvarchar	400	200	0	Y		健康状况
            Remark			nvarchar	400	200	0	Y		备注
         *
         */

        /// <summary>
        /// 员工健康信息流水号
        /// </summary>
        private int empHealthID;
        /// <summary>
        /// 员工健康信息流水号
        /// </summary>
        public int EmpHealthID
        {
            get { return empHealthID; }
            set { empHealthID = value; }
        }

        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        private int empIDToHealth;
        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        public int EmpIDToHealth
        {
            get { return empIDToHealth; }
            set { empIDToHealth = value; }
        }

        /// <summary>
        /// 员工身高
        /// </summary>
        private int height;
        /// <summary>
        /// 员工身高
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// 员工体重
        /// </summary>
        private int weight;
        /// <summary>
        /// 员工体重
        /// </summary>
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        /// <summary>
        /// 员工健康状况
        /// </summary>
        private string stateOfHealth;
        /// <summary>
        /// 员工健康状况
        /// </summary>
        public string StateOfHealth
        {
            get { return stateOfHealth; }
            set { stateOfHealth = value; }
        }

        /// <summary>
        /// 员工健康状况备注
        /// </summary>
        private string healthRemark;
        /// <summary>
        /// 员工健康状况备注
        /// </summary>
        public string HealthRemark
        {
            get { return healthRemark; }
            set { healthRemark = value; }
        }

        #endregion

        #region 员工家庭信息[Emp_Home]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            EmpHomeID	Y	Y	int	4	10	0			EmpHomeID
            EmpID			int	4	10	0	Y		EmpID
            HomeTel1			nvarchar	40	20	0	Y		家庭电话1
            HomeTel2			nvarchar	40	20	0	Y		家庭电话2
            HomeAddress			nvarchar	500	250	0	Y		家庭住址
            Postalcode			nvarchar	12	6	0	Y		邮政编码
            Remark			nvarchar	400	200	0	Y		备注
         *
         */

        /// <summary>
        /// 员工家庭信息表流水号
        /// </summary>
        private int empHomeID;
        /// <summary>
        /// 员工家庭信息表流水号
        /// </summary>
        public int EmpHomeID
        {
            get { return empHomeID; }
            set { empHomeID = value; }
        }

        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        private int empIDToHome;
        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        public int EmpIDToHome
        {
            get { return empIDToHome; }
            set { empIDToHome = value; }
        }

        /// <summary>
        /// 家庭电话1
        /// </summary>
        private string homeTel1;
        /// <summary>
        /// 家庭电话1
        /// </summary>
        public string HomeTel1
        {
            get { return homeTel1; }
            set { homeTel1 = value; }
        }

        /// <summary>
        /// 家庭电话2
        /// </summary>
        private string homeTel2;
        /// <summary>
        /// 家庭电话2
        /// </summary>
        public string HomeTel2
        {
            get { return homeTel2; }
            set { homeTel2 = value; }
        }

        /// <summary>
        /// 家庭地址
        /// </summary>
        private string homeAddress;
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        private string postalCode;
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }


        /// <summary>
        /// 员工家庭信息备注
        /// </summary>
        private string homeRemark;
        /// <summary>
        /// 员工家庭信息备注
        /// </summary>
        public string HomeRemark
        {
            get { return homeRemark; }
            set { homeRemark = value; }
        }


        #endregion

        #region 员工照片信息[Emp_Photo]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            PhotoID	Y	Y	int	4	10	0			PhotoID
            EmpID			int	4	10	0	Y		EmpID
            Photo			image	16	2147483647	0	Y		照片
            Remark			nchar	200	100	0	Y		备注
         *
         */

        /// <summary>
        /// 照片信息流水号
        /// </summary>
        private int photoID;
        /// <summary>
        /// 照片信息流水号
        /// </summary>
        public int PhotoID
        {
            get { return photoID; }
            set { photoID = value; }
        }

        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        private int empIDToPhoto;
        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        public int EmpIDToPhoto
        {
            get { return empIDToPhoto; }
            set { empIDToPhoto = value; }
        }

        /// <summary>
        /// 照片信息(二进制信息)
        /// </summary>
        private byte[] photo;
        /// <summary>
        /// 照片信息(二进制信息)
        /// </summary>
        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        /// <summary>
        /// 照片信息备注
        /// </summary>
        private string photoRemark;
        /// <summary>
        /// 照片信息备注
        /// </summary>
        public string PhotoRemark
        {
            get { return photoRemark; }
            set { photoRemark = value; }
        }

        #endregion

        #region 员工工种信息[Emp_WorkType]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            EmpWorkTypeID	Y	Y	int	4	10	0			EmpWorkTypeID
            EmpID			int	4	10	0	Y		EmpID
            WorkTypeID			int	4	10	0			WorkTypeID（工种信息）
            IsMostly			bit	1	1	0	Y		是否主要工种
            IsEnable			bit	1	1	0	Y		是否启用
            Remark			nvarchar	400	200	0	Y		备注
         *
         */

        /// <summary>
        /// 工种1
        /// </summary>
        private EmpWorkType workType1 = new EmpWorkType();
        /// <summary>
        /// 工种1
        /// </summary>
        public EmpWorkType WorkType1
        {
            get { return workType1; }
            set { workType1 = value; }
        }

        /// <summary>
        /// 工种2
        /// </summary>
        private EmpWorkType workType2 = new EmpWorkType();
        /// <summary>
        /// 工种2
        /// </summary>
        public EmpWorkType WorkType2
        {
            get { return workType2; }
            set { workType2 = value; }
        }

        /// <summary>
        /// 工种3
        /// </summary>
        private EmpWorkType workType3 = new EmpWorkType();
        /// <summary>
        /// 工种3
        /// </summary>
        public EmpWorkType WorkType3
        {
            get { return workType3; }
            set { workType3 = value; }
        }

        #endregion

        #region 员工配置信息[Emp_SysSet]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            EmpSysSetID	Y	Y	int	4	10	0			EmpSysSetID
            EmpID			int	4	10	0	Y		EmpID
            MaxTimeSec			int	4	10	0	Y		经过多少秒算超时
            MinTimeSec			int	4	10	0	Y		不足多少秒算欠时
            MaxTimeSource			int	4	10	0	Y		超时来源 [0-禁用超时, 1-员工, 2-部门, 3-工种]
            MinTimeSource			int	4	10	0	Y		欠时来源 [0-禁用超时, 1-员工, 2-部门, 3-工种]
            Remark			nvarchar	400	200	0	Y		备注

         */

        /// <summary>
        /// 员工配置信息流水号
        /// </summary>
        private int empSysSetID;
        /// <summary>
        /// 员工配置信息流水号
        /// </summary>
        public int EmpSysSetID
        {
            get { return empSysSetID; }
            set { empSysSetID = value; }
        }

        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        private int empIDToSysSet;
        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        public int EmpIDToSysSet
        {
            get { return empIDToSysSet; }
            set { empIDToSysSet = value; }
        }

        /// <summary>
        /// 经过多少秒算超时
        /// </summary>
        private int maxTimeSec;
        /// <summary>
        /// 经过多少秒算超时
        /// </summary>
        public int MaxTimeSec
        {
            get { return maxTimeSec; }
            set { maxTimeSec = value; }
        }

        /// <summary>
        /// 不足多少秒算欠时
        /// </summary>
        private int minTimeSec;
        /// <summary>
        /// 不足多少秒算欠时
        /// </summary>
        public int MinTimeSec
        {
            get { return minTimeSec; }
            set { minTimeSec = value; }
        }

        /// <summary>
        /// 超时来源 [0-禁用超时, 1-员工, 2-部门, 3-工种]
        /// </summary>
        private int maxTimeSource;
        /// <summary>
        /// 超时来源 [0-禁用超时, 1-员工, 2-部门, 3-工种]
        /// </summary>
        public int MaxTimeSource
        {
            get { return maxTimeSource; }
            set { maxTimeSource = value; }
        }

        /// <summary>
        /// 欠时来源 [0-禁用超时, 1-员工, 2-部门, 3-工种]
        /// </summary>
        private int minTimeSource;
        /// <summary>
        /// 欠时来源 [0-禁用超时, 1-员工, 2-部门, 3-工种]
        /// </summary>
        public int MinTimeSource
        {
            get { return minTimeSource; }
            set { minTimeSource = value; }
        }

        /// <summary>
        /// 员工配置信息备注
        /// </summary>
        private string empSysSetRemark;
        /// <summary>
        /// 员工配置信息备注
        /// </summary>
        public string EmpSysSetRemark
        {
            get { return empSysSetRemark; }
            set { empSysSetRemark = value; }
        }

        #endregion

        #region 员工联系方式信息[Emp_Search]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            EmpSearchID	Y		int	4	10	0			EmpSearchID
            EmpID			int	4	10	0	Y		EmpID
            EmpTel1			nvarchar	40	20	0	Y		手机
            EmpTel2			nvarchar	40	20	0	Y		小灵通
            EmpTel3			nvarchar	40	20	0	Y		备用电话
            EmpQQ			nvarchar	40	20	0	Y		QQ
            EmpMsn			nvarchar	200	100	0	Y		Msn
            HomePage			nvarchar	400	200	0	Y		主页
            EmpEmail			nvarchar	160	80	0	Y		电子信箱（主）
            EmpEmailBackup			nvarchar	160	80	0	Y		电子信箱（备用）
            Remark			nvarchar	400	200	0	Y		备注

         */

        /// <summary>
        /// 员工联系方式信息流水号
        /// </summary>
        private int empSearchID;
        /// <summary>
        /// 员工联系方式信息流水号
        /// </summary>
        public int EmpSearchID
        {
            get { return empSearchID; }
            set { empSearchID = value; }
        }

        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        private int empIDToSearch;
        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        public int EmpIDToSearch
        {
            get { return empIDToSearch; }
            set { empIDToSearch = value; }
        }

        /// <summary>
        /// 员工手机号码
        /// </summary>
        private string empTel1;
        /// <summary>
        /// 员工手机号码
        /// </summary>
        public string EmpTel1
        {
            get { return empTel1; }
            set { empTel1 = value; }
        }

        /// <summary>
        /// 员工小灵通号码
        /// </summary>
        private string empTel2;
        /// <summary>
        /// 员工小灵通号码
        /// </summary>
        public string EmpTel2
        {
            get { return empTel2; }
            set { empTel2 = value; }
        }

        /// <summary>
        /// 员工备用号码
        /// </summary>
        private string empTel3;
        /// <summary>
        /// 员工备用号码
        /// </summary>
        public string EmpTel3
        {
            get { return empTel3; }
            set { empTel3 = value; }
        }

        /// <summary>
        /// 员工qq号码
        /// </summary>
        private string empQQ;
        /// <summary>
        /// 员工qq号码
        /// </summary>
        public string EmpQQ
        {
            get { return empQQ; }
            set { empQQ = value; }
        }

        /// <summary>
        /// 员工MSN号码
        /// </summary>
        private string empMsn;
        /// <summary>
        /// 员工MSN号码
        /// </summary>
        public string EmpMsn
        {
            get { return empMsn; }
            set { empMsn = value; }
        }

        /// <summary>
        /// 员工主页
        /// </summary>
        private string homePage;
        /// <summary>
        /// 员工主页
        /// </summary>
        public string HomePage
        {
            get { return homePage; }
            set { homePage = value; }
        }

        /// <summary>
        /// 员工eMail
        /// </summary>
        private string empEmail;
        /// <summary>
        /// 员工eMail
        /// </summary>
        public string EmpEmail
        {
            get { return empEmail; }
            set { empEmail = value; }
        }

        /// <summary>
        /// 员工备用eMail
        /// </summary>
        private string empEmailBackUp;
        /// <summary>
        /// 员工备用eMail
        /// </summary>
        public string EmpEmailBackUp
        {
            get { return empEmailBackUp; }
            set { empEmailBackUp = value; }
        }

        /// <summary>
        /// 员工联系信息备注
        /// </summary>
        private string searchRemark;
        /// <summary>
        /// 员工联系信息备注
        /// </summary>
        public string SearchRemark
        {
            get { return searchRemark; }
            set { searchRemark = value; }
        }

        #endregion

        #region 员工进公司前信息[Emp_InCompany]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            EmpInCoID	Y	Y	int	4	10	0			EmpInCoID
            EmpID			int	4	10	0	Y		EmpID
            ProbationDate			datetime	8	23	3	Y		试用日期
            OfficiallyDate			datetime	8	23	3	Y		转正日期
            ContractExpDate			datetime	8	23	3	Y		合同有效期
            ContractExpAppendDate			datetime	8	23	3	Y		续签有效期
            IsGearShift			bit	1	1	0	Y		是否已调档
            HireTypeID			int	4	10	0	Y		聘用形式
            Archives			nvarchar	200	100	0	Y		如果未调档，档案所在地
            DimissionTime			datetime	8	23	3	Y		离职时间
            Remark			nvarchar	400	200	0	Y		备注
         *
         */

        /// <summary>
        /// 员工进公司前信息流水号
        /// </summary>
        private int empInCompanyID;
        /// <summary>
        /// 员工进公司前信息流水号
        /// </summary>
        public int EmpInCompanyID
        {
            get { return empInCompanyID; }
            set { empInCompanyID = value; }
        }

        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        private int empIDToInCompany;
        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        public int EmpIDToInCompany
        {
            get { return empIDToInCompany; }
            set { empIDToInCompany = value; }
        }

        /// <summary>
        /// 试用日期
        /// </summary>
        private DateTime probationDate;
        /// <summary>
        /// 试用日期
        /// </summary>
        public DateTime ProbationDate
        {
            get { return probationDate; }
            set { probationDate = value; }
        }

        /// <summary>
        /// 转正日期
        /// </summary>
        private DateTime officiallyDate;
        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime OfficiallyDate
        {
            get { return officiallyDate; }
            set { officiallyDate = value; }
        }

        /// <summary>
        /// 合同有效期
        /// </summary>
        private DateTime contractExpDate;
        /// <summary>
        /// 合同有效期
        /// </summary>
        public DateTime ContractExpDate
        {
            get { return contractExpDate; }
            set { contractExpDate = value; }
        }

        /// <summary>
        /// 续签有效期
        /// </summary>
        private DateTime contractExpAppendDate;
        /// <summary>
        /// 续签有效期
        /// </summary>
        public DateTime ContractExpAppendDate
        {
            get { return contractExpAppendDate; }
            set { contractExpAppendDate = value; }
        }

        /// <summary>
        /// 是否已调档
        /// </summary>
        private bool isGearShift;
        /// <summary>
        /// 是否已调档
        /// </summary>
        public bool IsGearShift
        {
            get { return isGearShift; }
            set { isGearShift = value; }
        }

        /// <summary>
        /// 聘用形式ID
        /// </summary>
        private int hireTypeID;
        /// <summary>
        /// 聘用形式ID
        /// </summary>
        public int HireTypeID
        {
            get { return hireTypeID; }
            set { hireTypeID = value; }
        }

        /// <summary>
        /// 如果未调档，档案所在地
        /// </summary>
        private string archives;
        /// <summary>
        /// 如果未调档，档案所在地
        /// </summary>
        public string Archives
        {
            get { return archives; }
            set { archives = value; }
        }

        /// <summary>
        /// 离职时间
        /// </summary>
        private DateTime dimissionTime;
        /// <summary>
        /// 离职时间
        /// </summary>
        public DateTime DimissionTime
        {
            get { return dimissionTime; }
            set { dimissionTime = value; }
        }

        /// <summary>
        /// 员工进公司前信息备注
        /// </summary>
        private string inCompanyRemark;
        /// <summary>
        /// 员工进公司前信息备注
        /// </summary>
        public string InCompanyRemark
        {
            get { return inCompanyRemark; }
            set { inCompanyRemark = value; }
        }

        #endregion

        #region 员工在公司信息[Emp_NowCompany]

        /*
         * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
            EmpNowCoID	Y	Y	int	4	10	0			EmpInCoID
            EmpID			int	4	10	0	Y		EmpID
            DeptID			int	4	10	0	Y		DeptID（所在部门）
            DutyID			int	4	10	0	Y		DutyID（担任职务）
            MaxSecTime			int	4	10	0	Y		最大工作时间
            MinSecTime			int	4	10	0	Y		最小工作时间
            Selectmode			int	4	10	0	Y		启用最大最小时间的模式
            Remark			nvarchar	400	200	0	Y		备注
         *
         */


        /// <summary>
        /// 员工在公司信息流水号
        /// </summary>
        private int empNowCompanyID;
        /// <summary>
        /// 员工在公司信息流水号
        /// </summary>
        public int EmpNowCompanyID
        {
            get { return empNowCompanyID; }
            set { empNowCompanyID = value; }
        }

        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        private int empIDToNowCompany;
        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        public int EmpIDToNowCompany
        {
            get { return empIDToNowCompany; }
            set { empIDToNowCompany = value; }
        }

        /// <summary>
        /// 员工所在部门ID
        /// </summary>
        private int deptID;
        /// <summary>
        /// 员工所在部门
        /// </summary>
        public int DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }

        /// <summary>
        /// 员工所在部门名称
        /// </summary>
        private string deptName;
        /// <summary>
        /// 员工所在部门名称
        /// </summary>
        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }

        /// <summary>
        /// 员工担任职务ID
        /// </summary>
        private int dutyID;
        /// <summary>
        /// 员工担任职务ID
        /// </summary>
        public int DutyID
        {
            get { return dutyID; }
            set { dutyID = value; }
        }

        /// <summary>
        /// 员工担任职务名称
        /// </summary>
        private string dutyName;
        /// <summary>
        /// 员工担任职务名称
        /// </summary>
        public string DutyName
        {
            get { return dutyName; }
            set { dutyName = value; }
        }

        /// <summary>
        /// 员工最大工作时间
        /// </summary>
        private int maxSecTime;
        /// <summary>
        /// 员工最大工作时间
        /// </summary>
        public int MaxSecTime
        {
            get { return maxSecTime; }
            set { maxSecTime = value; }
        }

        /// <summary>
        /// 员工最小工作时间
        /// </summary>
        private int minSecTime;
        /// <summary>
        /// 员工最小工作时间
        /// </summary>
        public int MinSecTime
        {
            get { return minSecTime; }
            set { minSecTime = value; }
        }

        /// <summary>
        /// 启用最大最小时间的模式
        /// </summary>
        private int selectMode;
        /// <summary>
        /// 启用最大最小时间的模式
        /// </summary>
        public int SelectMode
        {
            get { return selectMode; }
            set { selectMode = value; }
        }

        /// <summary>
        /// 员工在公司信息备注
        /// </summary>
        private string nowCompanyRemark;
        /// <summary>
        /// 员工在公司信息备注
        /// </summary>
        public string NowCompanyRemark
        {
            get { return nowCompanyRemark; }
            set { nowCompanyRemark = value; }
        }

        /// <summary>
        /// 组
        /// </summary>
        private string classGroup;
        /// <summary>
        /// 组
        /// </summary>
        public string ClassGroup
        {
            get { return classGroup; }
            set { classGroup = value; }
        }

        /// <summary>
        /// 工作地点
        /// </summary>
        private string workPlace;
        /// <summary>
        /// 工作地点
        /// </summary>
        public string WorkPlace
        {
            get { return workPlace; }
            set { workPlace = value; }
        }

        #endregion
    }

    /// <summary>
    /// 员工工种信息
    /// </summary>
    public class EmpWorkType
    {

        /*
        * 字段名	标识	主键	类型	字节数	长度	小数位数	允许空	默认值	字段说明
           EmpWorkTypeID	Y	Y	int	4	10	0			EmpWorkTypeID
           EmpID			int	4	10	0	Y		EmpID
           WorkTypeID			int	4	10	0			WorkTypeID（工种信息）
           IsMostly			bit	1	1	0	Y		是否主要工种
           IsEnable			bit	1	1	0	Y		是否启用
           Remark			nvarchar	400	200	0	Y		备注
        *
        */

        /// <summary>
        /// 员工工种信息流水号
        /// </summary>
        private int empWorkTypeID;
        /// <summary>
        /// 员工工种信息流水号
        /// </summary>
        public int EmpWorkTypeID
        {
            get { return empWorkTypeID; }
            set { empWorkTypeID = value; }
        }

        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        private int empIDToWorkType;
        /// <summary>
        /// 员工ID，对应员工基本信息表流水号
        /// </summary>
        public int EmpIDToWorkType
        {
            get { return empIDToWorkType; }
            set { empIDToWorkType = value; }
        }

        /// <summary>
        /// 工种信息ID
        /// </summary>
        private int workTypeID;
        /// <summary>
        /// 工种信息ID
        /// </summary>
        public int WorkTypeID
        {
            get { return workTypeID; }
            set { workTypeID = value; }
        }
        /// <summary>
        /// 工种信息名称
        /// </summary>
        private string workTypeName;
        /// <summary>
        /// 工种信息名称
        /// </summary>
        public string WorkTypeName
        {
            get { return workTypeName; }
            set { workTypeName = value; }
        }

        /// <summary>
        /// 是否主要工种
        /// </summary>
        private bool isMostly;
        /// <summary>
        /// 是否主要工种
        /// </summary>
        public bool IsMostly
        {
            get { return isMostly; }
            set { isMostly = value; }
        }

        /// <summary>
        /// 是否启用工种
        /// </summary>
        private bool isEnable;
        /// <summary>
        /// 是否启用工种
        /// </summary>
        public bool IsEnable
        {
            get { return isEnable; }
            set { isEnable = value; }
        }

        /// <summary>
        /// 员工工种信息备注
        /// </summary>
        private string empWorkTypeRemark;
        /// <summary>
        /// 员工工种信息备注
        /// </summary>
        public string EmpWorkTypeRemark
        {
            get { return empWorkTypeRemark; }
            set { empWorkTypeRemark = value; }
        }
    }
}
