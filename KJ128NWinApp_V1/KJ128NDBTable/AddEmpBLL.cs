using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using KJ128WindowsLibrary;
using System.Windows.Forms;
using System.Drawing;
using KJ128NModel;

namespace KJ128NDBTable
{
    public class AddEmpBLL
    {
        #region [ 声明 ]

        private AddEmpDAL aedal = new AddEmpDAL();
        private EnumInfoDAL eidal = new EnumInfoDAL();
        private DeptDAL ddal = new DeptDAL();

        DataSet ds;
        private string strSql = string.Empty;

        Font font_labelFont = new Font
               ("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        Color color_ForeColor = Color.FromArgb(32, 77, 137);
        Color color_BackColor = Color.FromArgb(231, 235, 247);

        #endregion

        #region [2008-6-23修改的添加员工信息的方法,通过EmpModel传参数，执行一条存储过程]

        /// <summary>
        /// 增加员工信息(全部10张表信息)
        /// </summary>
        /// <param name="empModel">员工类实体</param>
        /// <returns>返回执行影响行数，大于0就执行成功</returns>
        public int InsertEmpInfo(EmpModel empModel)
        {
            //if (aedal == null)
            //    aedal = new AddEmpDAL();

            //return aedal.InsertEmpInfo(empModel);
            return 0;
        }

        /// <summary>
        /// 修改员工信息(全部10张表信息)
        /// </summary>
        /// <param name="empModel">员工类实体</param>
        /// <returns>返回执行影响行数，大于0就执行成功</returns>
        public int UpdateEmpInfo(EmpModel empModel)
        {
            //if (aedal == null)
            //    aedal = new AddEmpDAL();

            //return aedal.UpdateEmpInfo(empModel);
            return 0;
        }

        #endregion

        #region 【 方法: 添加 员工信息 】

        public int SaveEmpInfo()
        {

            return 0;
        }

        #endregion

        #region [ 方法: 添加 员工信息 ]
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
            return aedal.SaveEmployeeBaseInfoData(empName, empNO, sex, remark);
        }
        #endregion

        #region [ 方法: 存储员工信息明细 ]
        /// <summary>
        /// 添加员工信息明细
        /// </summary>
        /// <param name="EmpNO">员工NO</param>
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
            return aedal.SaveEmployeeDetaiData(EmpNO, Nation, WedlockID, ClanID, NativePlace, CensusRegister, SchoolRecordID, GraduateFrom, Specialty, OfficialDesignation, Remark, BirthDay, IDcard);
        }
        #endregion

        #region [ 方法: 存储员工联系方式 ]

        /// <summary>
        /// 添加员工联系方式
        /// </summary>
        /// <param name="EmpNO">员工NO</param>
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
            return aedal.SaveEmployeeSearchData(EmpNO, EmpTel1, EmpTel2, EmpTel3, EmpQQ, EmpMsn, HomePage, EmpEmail, EmpEmailBackup, Remark);
        }
        #endregion

        #region [ 方法: 存储员工家庭信息 ]

        /// <summary>
        /// 添加员工家庭信息
        /// </summary>
        /// <param name="EmpNO">员工NO</param>
        /// <param name="HomeTel1">家庭电话1</param>
        /// <param name="HomeTel2">家庭电话2</param>
        /// <param name="HomeAddress">家庭住址</param>
        /// <param name="Postalcode">邮政编码</param>
        /// <param name="Remark">备注</param>
        /// <returns>返回影响行数</returns>
        public int SaveEmployeeHomeData(string EmpNO, String HomeTel1, String HomeTel2, String HomeAddress, String Postalcode, String Remark)
        {
            return aedal.SaveEmployeeHomeData(EmpNO, HomeTel1, HomeTel2, HomeAddress, Postalcode, Remark);
        }
        #endregion

        #region [ 方法: 存储员工进公司情况 ]

        /// <summary>
        /// 添加员工进公司情况
        /// </summary>
        /// <param name="EmpNO">员工NO</param>
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
            return aedal.SaveEmployeeComeCompanyInfoData(EmpNO, ProbationDate, OfficiallyDate, ContractExpDate, ContractExpAppendDate, IsGearShift, HireTypeID, Archives, DimissionTime, Remark);
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
        public int SaveHealthData(string EmpNO, string Height, string Weight, string StateOfHealth)
        {
            int x, y;
            if (Height.CompareTo("") == 0)
            {
                x = 0;
            }
            else
            {
                x = Convert.ToInt32(Height);
            }
            if (Weight.CompareTo("") == 0)
            {
                y = 0;
            }
            else
            {
                y = Convert.ToInt32(Weight);
            }
            return aedal.SaveHealthData(EmpNO, x, y, StateOfHealth);
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
        public int SaveEmployeeNowCompanyData(string EmpNO, int DeptID, int DutyID, int MaxHour,int MaxMinute,int MaxSecond,int MinHour,int MinMinute,int MinSecond,int SelectMode, string Remark,string strClassGroup,string strWorkPlace)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return aedal.SaveEmployeeNowCompanyData(EmpNO, DeptID, DutyID, MaxTimeSec, MinTimeSec, SelectMode, Remark,strClassGroup,strWorkPlace);
        }
        #endregion

        #region [ 方法: 增加员工工种信息 ]

        public int SaveWorkTypeData(string EmpNO, int WorkTypeID, int IsMostly, int IsEnable)
        {
            return aedal.SaveWorkTypeData(EmpNO, WorkTypeID, IsMostly, IsEnable);
        }
        #endregion

        #region [ 方法: 添加 照片 ]

        public int SaveEmpPhoto(string EmpNO,byte[] Photo, string Remark)
        {
            return aedal.SaveEmpPhoto(EmpNO,Photo, Remark);
        }
        #endregion

        #region [ 方法: 修改 照片 ]

        public int UpDateEmpPhoto(int PhotoID ,string EmpNO, byte[] Photo, string Remark)
        {
            return aedal.UpDateEmpPhoto(PhotoID, EmpNO, Photo, Remark);
        }
        #endregion

        #region [ 方法: 删除 照片 ]

        public int DeleteEmpPhoto(int EmpID)
        {
            return aedal.DeleteEmpPhoto(EmpID);
        }
                #endregion

        #region [ 方法: 获取PhotoID ]

        public int GetPhotoID(int EmpID)
        {
            return aedal.GetPhotoID(EmpID);
        }
        #endregion

        #region  [ 方法: 根据PhotoID，返回DataTable ]

        public DataTable GetPhotoTab(int PhotoID)
        {
            return aedal.GetPhotoTab(PhotoID);
        }

        #endregion

        #region [ 方法: 修改员工基本信息 ]

        public int UpDateEmpInfo(int EmpID, string EmpNO, string EmpName, int Sex, string Remark)
        {
            return aedal.UpDateEmpInfo(EmpID, EmpNO, EmpName, Sex, Remark);
        }
        #endregion 

        #region [ 方法: 修改 员工工种信息 ]
        public int UpDateEmpWorkType(int EmpWorkTypeID, int WorkTypeID, byte IsMostly, byte IsEnable)
        {
            return aedal.UpDateEmpWorkType(EmpWorkTypeID, WorkTypeID, IsMostly, IsEnable);
        }
        #endregion

        #region [ 方法: 删除 工种信息 ]
        public int DeleteEmpWorkType(int EmpWorkTypeID)
        {
            return aedal.DeleteEmpWorkType(EmpWorkTypeID);
        }
        #endregion

        #region [ 方法: 获取员工ID ]
        /// <summary>
        /// 获取员工ID
        /// </summary>
        /// <param name="EmpNo">员工编号</param>
        /// <returns>返回员工ID</returns>
        public int GetEmpID(string EmpNo)
        {
            string strsql = string.Format("select EmpID from Emp_Info where EmpNo='{0}'", EmpNo);
            return ddal.GetID(strsql);
        }
        #endregion

        #region [ 方法: 获取聘用形式的Table ]

        /// <summary>
        /// 获取聘用形式的Table
        /// </summary>
        /// <returns>返回聘用形式的Table</returns>
        public DataTable GetEmpHireTypeTab()
        {
            return eidal.getEnumInfo(43);
        }

        #endregion

        #region [ 方法: 获取学历Table ]

        /// <summary>
        /// 获取学历Table
        /// </summary>
        /// <returns>返回学历Table</returns>
        public DataTable GetEmpSchoolRecordTab()
        {
            return eidal.getEnumInfo(42);
        }
        #endregion

        #region [ 方法: 获取政治面貌Table ]

        /// <summary>
        /// 获取政治面貌Table
        /// </summary>
        /// <returns>返回政治面貌Table</returns>
        public DataTable GetEmpClanTab()
        {
            return eidal.getEnumInfo(41);
        }
        #endregion

        #region [ 方法: 获取婚姻状况Table ]

        /// <summary>
        /// 获取婚姻状况Table
        /// </summary>
        /// <returns>返回婚姻状况Table</returns>
        public DataTable GetEmpWedlockTab()
        {
            return eidal.getEnumInfo(40);
        }
        #endregion

        #region [ 方法: 获取性别Table ]

        /// <summary>
        /// 获取性别Table
        /// </summary>
        /// <returns>返回性别Table</returns>
        public DataTable GetEmpSexTab()
        {
            return eidal.getEnumInfo(44);
        }
        #endregion

        #region [ 方法: 获取启用模式Table ]
        /// <summary>
        /// 获取启用模式Table
        /// </summary>
        /// <returns>返回启用模式Table</returns>
        public DataTable GetSelectmodeTab()
        {
            return eidal.getEnumInfo(45);
        }
        #endregion

        #region [ 方法: 获取部门Table ]

        /// <summary>
        /// 获取部门信息Table
        /// </summary>
        /// <returns>返回部门Table</returns>
        public DataTable GetDeparmentTab()
        {
            return aedal.GetDeparmentTab();
        }
        #endregion

        #region [ 方法: 获取职务Table ]
        /// <summary>
        /// 获取职务Table
        /// </summary>
        /// <returns>返回职务Table</returns>
        public DataTable GetEmpDutyTab()
        {
            return aedal.GetEmpDutyTab();
        }
        #endregion

        #region [ 方法: 绑定工种 ]

        /// <summary>
        /// 绑定工种
        /// </summary>
        /// <returns>返回ComboBox</returns>
        public ComboBox GetWorkTypeCmb(ComboBox cmb)
        {
            DataSet ds = ddal.getWorkTypeInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "无";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "WtName";
                cmb.ValueMember = "WorkTypeID";
            }
            return cmb;
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
            return aedal.GetDataTableEmp(sql);
        }
        #endregion

        #region [ 方法: 获取员工基本信息Table ]

        /// <summary>
        /// 获取员工基本信息(Table)
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <returns>返回员工基本信息(Table)</returns>
        public DataTable GetEmpBaseInfoTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Info where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ 方法: 获取员工信息明细Table ]

        /// <summary>
        /// 获取员工信息明细(Table)
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <returns>返回员工信息明细(Table)</returns>
        public DataTable GetEmpDetailTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Detail where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ 方法: 获取员工联系方式Table ]

        /// <summary>
        /// 获取员工联系方式(Table)
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <returns>返回员工联系方式(Table)</returns>
        public DataTable GetEmpSearchTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Search where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ 方法: 获取员工家庭信息Table ]

        /// <summary>
        /// 获取员工家庭信息(Table)
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <returns>返回员工家庭信息(Table)</returns>
        public DataTable GetEmpHomeTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Home where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ 方法: 获取员工健康状况Table ]

        /// <summary>
        /// 获取员工健康状况(Table)
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <returns>返回员工健康状况(Table)</returns>
        public DataTable GetEmpHealthTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_Health where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ 方法: 获取员工进公司情况Table ]

        /// <summary>
        /// 获取员工进公司情况(Table)
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <returns>返回员工进公司情况(Table)</returns>
        public DataTable GetEmpInCompanyTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_InCompany where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
                #endregion

        #region [ 方法: 获取员工在公司情况Table ]

        /// <summary>
        /// 获取员工在公司情况(Table)
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <returns>返回员工在公司情况(Table)</returns>
        public DataTable GetEmpNowCompanyTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_NowCompany where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ 方法: 获取部门设置Table ]

        public DataTable GetDeptSysSetTab(int DeptID)
        {
            string strsql = string.Format("select * from Dept_SysSet where DeptID={0}", DeptID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ 方法: 获取工种设置Table ]

        public DataTable GetWorkTypeSysSetTab(int WorkTypeID)
        {
            string strsql = string.Format("select * from WorkType_SysSet where WorkTypeID={0}", WorkTypeID);
            return ddal.GetTable(strsql);
        }
        #endregion

        #region [ 方法: 获取员工工种设置Table ]

        /// <summary>
        /// 获取员工工种设置(Table)
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <returns>返回员工工种设置(Table)</returns>
        public DataTable GetEmpWorkTypeTab(int EmpID)
        {
            string strsql = string.Format("select * from Emp_WorkType where EmpID={0}", EmpID);
            return ddal.GetTable(strsql);
        }
         #endregion

        #region [ 方法: 根据查询方式得到查询条件 ]

        /// <summary>
        /// 根据查询方式得到查询条件
        /// </summary>
        /// <param name="strTest"></param>
        /// <param name="selectFun">1 精确</param>
        /// <returns></returns>
        public string SelectWhere(string[,] strTest, int selectFun)
        {
            string strNewSql = string.Empty;
            bool blnFirst = true;
            bool isWorkType = false;
            for (int i = 0; i < strTest.GetUpperBound(0) + 1; i++)
            {
                if (strTest[i, 2].Trim() != string.Empty)
                {
                    if (strTest[i, 3].Trim() == "string")
                    {
                        if (strTest[i, 0].Trim() == "工种名称")
                        {
                            isWorkType = true;
                        }
                        else
                        {
                            isWorkType = false;
                        }
                        if (selectFun == 1)
                        {
                            //精确
                            strTest[i, 2] = "'" + strTest[i, 2].Trim() + "'";
                        }
                        else
                        {
                            //模糊
                            strTest[i, 2] = "'%" + strTest[i, 2].Trim() + "%'";
                            strTest[i, 1] = "like";
                        }
                    }

                    if (strTest[i, 3].Trim() == "datetime")
                    {
                        strTest[i, 2] = "'" + strTest[i, 2].Trim() + "'";
                    }


                    if (blnFirst)
                    {
                        if (isWorkType)
                        {
                            strNewSql ="("+ strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ") and IsEnable=1";
                            blnFirst = false;
                        }
                        else
                        {
                            strNewSql = "(" + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ")";
                            blnFirst = false;
                        }
                    }
                    else if (isWorkType)
                    {
                        strNewSql += "and (" + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ") and IsEnable=1";
                    }
                    else
                    {
                        strNewSql += " and (" + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ")";
                    }
                }
            }
            return strNewSql;
        }

        #endregion

        #region [ 方法: 根据工种ID获取工种名称 ]

        public string GetWorkTyepStr(int WorkTypeID)
        {
            string strsql=string.Format("select WtName from WorkType_Info where WorkTypeID={0}",WorkTypeID);
            return ddal.GetString(strsql);
        }
        #endregion

        #region [ 方法: 人员信息 ]
        public DataSet GetEmpInfo(int pageIndex, int pageSize, string where)
        {
            //SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
            //                        new SqlParameter("@fldName",SqlDbType.VarChar,255),
            //                        new SqlParameter("@PageSize",SqlDbType.Int),
            //                        new SqlParameter("@PageIndex",SqlDbType.Int),
            //                        new SqlParameter("@IsReCount",SqlDbType.Bit),
            //                        new SqlParameter("@OrderType",SqlDbType.Bit),
            //                        new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            //};
            //para[0].Value = "KJ128N_Emp_Table";
            //para[1].Value = "EmpID";
            //para[2].Value = pageSize;
            //para[3].Value = pageIndex;
            //para[4].Value = 1;
            //para[5].Value = 0;
            //para[6].Value = where;

            //return aedal.GetEmpInfo(para);

            return aedal.GetEmpInfo(pageIndex, pageSize, where);
        }

        #endregion

        #region [ 方法: 部门表信息 ]
        // 填充部门树
        public DataTable GetDeptInfo()
        {
            return aedal.GetDeptInfo();
        }

        #endregion

        #region [ 方法: 删除 人员信息 ]
        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="WorkTypeID">人员ID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteEmp(int EmpID)
        {
            return aedal.DeleteEmp(EmpID);
        }
        #endregion

        #region [ 方法: 初始化StationMakeupVspanel ]
        public StationMakeupVspanel InitSmvp(StationMakeupVspanel Smvp,string str, Point x,Size y  )
        {
            Smvp.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top) | (AnchorStyles.Right));
            Smvp.CaptionTitle = str;
            Smvp.VerticalInterval = 8;
            Smvp.LeftInterval = 22;
            Smvp.TopInterval = 8;
            Smvp.BackColor = color_BackColor;
            Smvp.IsmiddleInterval = true;
            Smvp.IsCaptionSingleColor = true;

            Smvp.IsShowAddNewStationHeadInfo = false;   //不显示增加接收器为
            Smvp.IsShowDeleteStationInfo = false;       //不显示删除分站
            Smvp.IsShowEditStationInfo = false;         //不显示编辑分站

            Smvp.IsShowLabelStationInfo = false;
            Smvp.LayoutType = VSPanelLayoutType.VerticalType;
            Smvp.Location = x;
            Smvp.Size = y; ;

            return Smvp;
        }
        #endregion

        #region [ 方法: 初始化LabelTransparent ]

        public LabelTransparent InitLabel(LabelTransparent lab, string str)
        {
            lab.Font = font_labelFont;
            lab.BackColor = color_BackColor;
            lab.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            lab.Text = str;
            lab.AutoSize = true;
            lab.IsTransparent = true;
            lab.ForeColor = color_ForeColor;

            return lab;
        }
        #endregion

        #region [ 方法: 初始化TextBox ]

        public TextBox InitTextBox(TextBox tBox,Size y)
        {
            tBox.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            tBox.Text = "";
            tBox.Size = y;

            return tBox;
        }
        #endregion

        #region [ 方法: 初始化CheckBox ]

        public CheckBox InitCheckBox(CheckBox chBox,string str, Size y,bool z)
        {
            chBox.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            chBox.BackColor = color_BackColor;
            chBox.Text = str;
            chBox.Size = y;
            chBox.AutoSize = true;
            chBox.ForeColor = color_ForeColor;
            chBox.Font = font_labelFont;
            chBox.Checked = z;

            return chBox;
        }
        #endregion

        #region [ 方法: 初始化DateTimePicker ]

        public DateTimePicker InitDateTimePicker(DateTimePicker dtp, bool z)
        {
            dtp.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            dtp.BackColor = color_BackColor;
            dtp.AutoSize = true;
            dtp.ForeColor = color_ForeColor;
            dtp.Enabled = z;
            dtp.Size = new Size(110, 21);
            return dtp;
        }
        #endregion

        #region [ 方法: 初始化RadioButton ]

        public RadioButton InitRadioButton(RadioButton raBon, string str, Point x)
        {
            raBon.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            raBon.Size = new Size(53, 16);
            raBon.Font = font_labelFont;
            raBon.Text = str;
            raBon.AutoSize = true;
            raBon.ForeColor = color_ForeColor;
            raBon.Location = x;

            return raBon;
        }
        #endregion

        #region [ 方法: 初始化GroupBox ]

        public GroupBox InitGroupBox(GroupBox grBox, string str, Point x)
        {
            grBox.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Top));
            grBox.Location = x;
            grBox.Size = new Size(98, 131);
            grBox.Font = font_labelFont;
            grBox.Text = str;
            grBox.AutoSize = true;
            grBox.ForeColor = color_ForeColor;
            grBox.BackColor = color_BackColor;

            return grBox;
        }
                #endregion

        #region [ 方法: 绑定工种名称(cmboBox) ]

        public ComboBox GetCerNameCmb(ComboBox cmb)
        {
            DataTable dt = aedal.GetWorkTypeTab();
            if (dt != null )
            {
                cmb.DataSource = null;
                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
                cmb.DisplayMember = "WtName";
                cmb.ValueMember = "WorkTypeID";
                cmb.SelectedIndex = 0;
            }
            return cmb;
        }
        #endregion

        #region [ 方法: 绑定 职务并判断(comboBox) ]

        public void GetDutyNameCmb(ComboBox cmb,bool bl)
        {
            DataSet ds = GetDutyNameInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                if (bl)
                {
                    dr[1] = "所有";
                }
                else
                {
                    dr[1] = "无";
                }
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DutyName";
                cmb.ValueMember = "DutyID";
                cmb.SelectedValue = 0;
            }
        }

        private DataSet GetDutyNameInfo()
        {
            return aedal.GetDutyNameInfo();
        }

        #endregion

        #region [ 方法: 绑定 部门名称(comboBox) ]

        public void GetDeptNameCmb(ComboBox cmb)
        {
            DataSet ds = GetDeptNameInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.DataSource = null;
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "无";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DeptName";
                cmb.ValueMember = "DeptID";
                cmb.SelectedValue = 0;
            }
        }

        private DataSet GetDeptNameInfo()
        {
            return aedal.GetDeptNameInfo();
        }

        #endregion

        #region [ 方法: 根据部门和发码器得到员工姓名 ]

        public DataSet GetEmployeeNameByDeptIDAndCoderSenderID(int intDeptID, int intBlockID)
        {
            return aedal.GetEmployeeNameByDeptIDAndCoderSenderID(intDeptID, intBlockID);
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
        public void GetListBox(System.Web.UI.WebControls.ListBox list, string textField, string valueField, string strWhere, out string strErrMsg)
        {
            list.DataSource = aedal.GetDropDownList(textField, valueField, strWhere, out strErrMsg);
            list.DataTextField = textField;
            list.DataValueField = valueField;
            list.DataBind();
        }
        #endregion

        #region [ 方法: 验证数据库库该员工是否存在 ]
        /// <summary>
        /// 验证数据库库该员工是否存在
        /// </summary>
        /// <param name="strEmpNO">员工编号</param>
        /// <returns>True:存在;False:不存在</returns>
        public bool IsEmp(string strEmpNO)
        {
            using (ds = new DataSet())
            {
                ds = aedal.IsEmpNO(strEmpNO);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count == 1)
                    {
                        //存在该员工编号
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

       

    }
}
