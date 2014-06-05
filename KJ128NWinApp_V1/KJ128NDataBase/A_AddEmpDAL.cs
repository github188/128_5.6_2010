using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KJ128NModel;


namespace KJ128NDataBase
{
	public class A_AddEmpDAL
	{
		#region [2008-6-23修改的添加员工信息的方法,通过EmpModel传参数，执行一条存储过程]

		/// <summary>
		/// 增加保存员工信息(全部10张表的信息)
		/// </summary>
		/// <param name="empModel">员工类实体，包含全部表信息</param>
		/// <returns>返回执行影响的行数</returns>
		public int InsertEmpInfo(EmpModel empModel)
		{

			SqlParameter[] para = new SqlParameter[] {

                #region[Emp_Info 员工基本信息表]

                new SqlParameter("@EmpName",SqlDbType.NVarChar,20),
                new SqlParameter("@Sex",SqlDbType.Bit),
                new SqlParameter("@Remark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("@DeptID",SqlDbType.Int),
                new SqlParameter("@DutyID",SqlDbType.Int),
                new SqlParameter("@MaxSecTime",SqlDbType.Int),
                new SqlParameter("@MinSecTime",SqlDbType.Int),
                new SqlParameter("@Selectmode",SqlDbType.Int),
                new SqlParameter("@ClassGroup",SqlDbType.NVarChar,50),
                new SqlParameter("@WorkPlace",SqlDbType.NVarChar,50),
                new SqlParameter("@Photo",SqlDbType.Image),
                new SqlParameter("@Nation",SqlDbType.NVarChar,30),
                new SqlParameter("@Wedlock",SqlDbType.NVarChar,50),
                new SqlParameter("@Clan",SqlDbType.NVarChar,50),
                new SqlParameter("@NativePlace",SqlDbType.NVarChar,50),
                new SqlParameter("@CensusRegister",SqlDbType.NVarChar,50),
                new SqlParameter("@SchoolRecord",SqlDbType.NVarChar,50),
                new SqlParameter("@GraduateFrom",SqlDbType.NVarChar,35),
                new SqlParameter("@Specialty",SqlDbType.NVarChar,50),
                new SqlParameter("@OfficialDesignation",SqlDbType.NVarChar,50),
                new SqlParameter("@Idcard",SqlDbType.NVarChar,20),
                new SqlParameter("@BirthDay",SqlDbType.DateTime),
                new SqlParameter("@Height",SqlDbType.Int),
                new SqlParameter("@Weight",SqlDbType.Int),
                new SqlParameter("@StateOfHealth",SqlDbType.NVarChar,50),
                new SqlParameter("@HomeTel1",SqlDbType.NVarChar,20),
                new SqlParameter("@HomeTel2",SqlDbType.NVarChar,20),
                new SqlParameter("@HomeAddress",SqlDbType.NVarChar,250),
                new SqlParameter("@Postalcode",SqlDbType.NVarChar,6),
                new SqlParameter("@ProbationDate",SqlDbType.DateTime),
                new SqlParameter("@OfficiallyDate",SqlDbType.DateTime),
                new SqlParameter("@ContractExpDate",SqlDbType.DateTime),
                new SqlParameter("@ContractExpAppendDate",SqlDbType.DateTime),
                new SqlParameter("@IsGearShift",SqlDbType.Bit),
                new SqlParameter("@HireTypeID",SqlDbType.Int),
                new SqlParameter("@Archives",SqlDbType.NVarChar,100),
                new SqlParameter("@DimissionTime",SqlDbType.DateTime),
                new SqlParameter("@EmpDetailRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpSerchRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpHomeRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpInCompanyRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpNowCompanyRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@WorkTypeID1",SqlDbType.Int),
                new SqlParameter("@IsMostly1",SqlDbType.Bit),
                new SqlParameter("@IsEnable1",SqlDbType.Bit),
                new SqlParameter("@blood ",SqlDbType.NVarChar,20),
                new SqlParameter("@ID",SqlDbType.Int),
                new SqlParameter("@DeptName",SqlDbType.NVarChar,50),
	            new SqlParameter("@DutyName",SqlDbType.NVarChar,50),
	            new SqlParameter("@WorkTypeName",SqlDbType.NVarChar,50),
	            new SqlParameter("@ClassID",SqlDbType.Int)
                #endregion
            };

			para[0].Value = empModel.EmpName;
			para[1].Value = empModel.Sex;
			para[2].Value = empModel.BaseRemark;
			para[3].Value = empModel.EmpNO;
			para[4].Value = empModel.DeptID;
			para[5].Value = empModel.DutyID;
			para[6].Value = empModel.MaxSecTime;
			para[7].Value = empModel.MinSecTime;
			para[8].Value = empModel.SelectMode;
			para[9].Value = empModel.ClassGroup;
			para[10].Value = empModel.WorkPlace;
			para[11].Value = empModel.Photo;
			para[12].Value = empModel.Nation;
			para[13].Value = empModel.Wedlock;
			para[14].Value = empModel.Clan;
			para[15].Value = empModel.NativePlace;
			para[16].Value = empModel.CensusRegister;
			para[17].Value = empModel.SchoolRecord;
			para[18].Value = empModel.GraduateFrom;
			para[19].Value = empModel.Specialty;
			para[20].Value = empModel.OfficialDesignation;
			para[21].Value = empModel.IdCard;
			para[22].Value = empModel.BirthDay;
			para[23].Value = empModel.Height;
			para[24].Value = empModel.Weight;
			para[25].Value = empModel.StateOfHealth;
			para[26].Value = empModel.HomeTel1;
			para[27].Value = empModel.HomeTel2;
			para[28].Value = empModel.HomeAddress;
			para[29].Value = empModel.PostalCode;
			para[30].Value = empModel.ProbationDate;
			para[31].Value = empModel.OfficiallyDate;
			para[32].Value = empModel.ContractExpDate;
			para[33].Value = empModel.ContractExpAppendDate;
			para[34].Value = empModel.IsGearShift;
			para[35].Value = empModel.HireTypeID;
			para[36].Value = empModel.Archives;
			para[37].Value = empModel.DimissionTime;
			para[38].Value = empModel.DetailRemark;
			para[39].Value = empModel.SearchRemark;
			para[40].Value = empModel.HomeRemark;
			para[41].Value = empModel.InCompanyRemark;
			para[42].Value = empModel.NowCompanyRemark;
			para[43].Value = empModel.WorkType1.WorkTypeID;
			para[44].Value = 1;// empModel.WorkType1.IsMostly;
			para[45].Value = 1;// empModel.WorkType1.IsEnable;
			para[46].Value = empModel.Company;
			para[47].Value = empModel.EmpNO.GetHashCode();
			para[48].Value = empModel.DeptName;
			para[49].Value = empModel.DutyName;
			para[50].Value = empModel.WorkType1.WorkTypeName;
			if (empModel.ClassID == 0)
			{
				para[51].Value = DBNull.Value;
			}
			else
			{
				para[51].Value = empModel.ClassID;
			}
			return dba.ExecuteSql("A_zjw_Emp_Insert", para);
		}


		/// <summary>
		/// 修改保存员工信息(全部10张表的信息)
		/// </summary>
		/// <param name="empModel">员工类实体，包含全部表信息</param>
		/// <param name="intEmpID">员工ID</param>
		/// <returns>返回执行影响的行数</returns>
		public int UpdateEmpInfo(EmpModel empModel, int intEmpID)
		{

			SqlParameter[] para = new SqlParameter[] {

                #region[Emp_Info 员工基本信息表]

                new SqlParameter("@EmpName",SqlDbType.NVarChar,20),
                new SqlParameter("@Sex",SqlDbType.Bit),
                new SqlParameter("@Remark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpNO",SqlDbType.NVarChar,10),
                new SqlParameter("@DeptID",SqlDbType.Int),
                new SqlParameter("@DutyID",SqlDbType.Int),
                new SqlParameter("@MaxSecTime",SqlDbType.Int),
                new SqlParameter("@MinSecTime",SqlDbType.Int),
                new SqlParameter("@Selectmode",SqlDbType.Int),
                new SqlParameter("@ClassGroup",SqlDbType.NVarChar,50),
                new SqlParameter("@WorkPlace",SqlDbType.NVarChar,50),
                new SqlParameter("@Photo",SqlDbType.Image),
                new SqlParameter("@Nation",SqlDbType.NVarChar,30),
                new SqlParameter("@Wedlock",SqlDbType.NVarChar,50),
                new SqlParameter("@Clan",SqlDbType.NVarChar,50),
                new SqlParameter("@NativePlace",SqlDbType.NVarChar,50),
                new SqlParameter("@CensusRegister",SqlDbType.NVarChar,50),
                new SqlParameter("@SchoolRecord",SqlDbType.NVarChar,50),
                new SqlParameter("@GraduateFrom",SqlDbType.NVarChar,35),
                new SqlParameter("@Specialty",SqlDbType.NVarChar,50),
                new SqlParameter("@OfficialDesignation",SqlDbType.NVarChar,50),
                new SqlParameter("@Idcard",SqlDbType.NVarChar,20),
                new SqlParameter("@BirthDay",SqlDbType.DateTime),
                new SqlParameter("@Height",SqlDbType.Int),
                new SqlParameter("@Weight",SqlDbType.Int),
                new SqlParameter("@StateOfHealth",SqlDbType.NVarChar,50),
                new SqlParameter("@HomeTel1",SqlDbType.NVarChar,20),
                new SqlParameter("@HomeTel2",SqlDbType.NVarChar,20),
                new SqlParameter("@HomeAddress",SqlDbType.NVarChar,250),
                new SqlParameter("@Postalcode",SqlDbType.NVarChar,6),
                new SqlParameter("@ProbationDate",SqlDbType.DateTime),
                new SqlParameter("@OfficiallyDate",SqlDbType.DateTime),
                new SqlParameter("@ContractExpDate",SqlDbType.DateTime),
                new SqlParameter("@ContractExpAppendDate",SqlDbType.DateTime),
                new SqlParameter("@IsGearShift",SqlDbType.Bit),
                new SqlParameter("@HireTypeID",SqlDbType.Int),
                new SqlParameter("@Archives",SqlDbType.NVarChar,100),
                new SqlParameter("@DimissionTime",SqlDbType.DateTime),
                new SqlParameter("@EmpDetailRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpSerchRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpHomeRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpInCompanyRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@EmpNowCompanyRemark",SqlDbType.NVarChar,200),
                new SqlParameter("@WorkTypeID1",SqlDbType.Int),
                new SqlParameter("@IsMostly1",SqlDbType.Bit),
                new SqlParameter("@IsEnable1",SqlDbType.Bit),
                new SqlParameter("@blood ",SqlDbType.NVarChar,20),
                new SqlParameter("@EmpID",SqlDbType.Int),
                new SqlParameter("@DeptName",SqlDbType.NVarChar,50),
	            new SqlParameter("@DutyName",SqlDbType.NVarChar,50),
	            new SqlParameter("@WorkTypeName",SqlDbType.NVarChar,50),
	            new SqlParameter("@ClassID",SqlDbType.Int)
                #endregion
            };

			para[0].Value = empModel.EmpName;
			para[1].Value = empModel.Sex;
			para[2].Value = empModel.BaseRemark;
			para[3].Value = empModel.EmpNO;
			para[4].Value = empModel.DeptID;
			para[5].Value = empModel.DutyID;
			para[6].Value = empModel.MaxSecTime;
			para[7].Value = empModel.MinSecTime;
			para[8].Value = empModel.SelectMode;
			para[9].Value = empModel.ClassGroup;
			para[10].Value = empModel.WorkPlace;
			para[11].Value = empModel.Photo;
			para[12].Value = empModel.Nation;
			para[13].Value = empModel.Wedlock;
			para[14].Value = empModel.Clan;
			para[15].Value = empModel.NativePlace;
			para[16].Value = empModel.CensusRegister;
			para[17].Value = empModel.SchoolRecord;
			para[18].Value = empModel.GraduateFrom;
			para[19].Value = empModel.Specialty;
			para[20].Value = empModel.OfficialDesignation;
			para[21].Value = empModel.IdCard;
			para[22].Value = empModel.BirthDay;
			para[23].Value = empModel.Height;
			para[24].Value = empModel.Weight;
			para[25].Value = empModel.StateOfHealth;
			para[26].Value = empModel.HomeTel1;
			para[27].Value = empModel.HomeTel2;
			para[28].Value = empModel.HomeAddress;
			para[29].Value = empModel.PostalCode;
			para[30].Value = empModel.ProbationDate;
			para[31].Value = empModel.OfficiallyDate;
			para[32].Value = empModel.ContractExpDate;
			para[33].Value = empModel.ContractExpAppendDate;
			para[34].Value = empModel.IsGearShift;
			para[35].Value = empModel.HireTypeID;
			para[36].Value = empModel.Archives;
			para[37].Value = empModel.DimissionTime;
			para[38].Value = empModel.DetailRemark;
			para[39].Value = empModel.SearchRemark;
			para[40].Value = empModel.HomeRemark;
			para[41].Value = empModel.InCompanyRemark;
			para[42].Value = empModel.NowCompanyRemark;
			para[43].Value = empModel.WorkType1.WorkTypeID;
			para[44].Value = 1;// empModel.WorkType1.IsMostly;
			para[45].Value = 1;// empModel.WorkType1.IsEnable;
			para[46].Value = empModel.Company;
			para[47].Value = intEmpID;
			para[48].Value = empModel.DeptName;
			para[49].Value = empModel.DutyName;
			para[50].Value = empModel.WorkType1.WorkTypeName;
			if (empModel.ClassID == 0)
			{
				para[51].Value = DBNull.Value;
			}
			else
			{
				para[51].Value = empModel.ClassID;
			}

			return dba.ExecuteSql("A_zjw_Emp_Update", para);
		}

		#endregion

		#region [ 声明 ]

		private DeptDAL ddal = new DeptDAL();
		private DBAcess dba = new DBAcess();
		DbHelperSQL DB = new DbHelperSQL();
		string sqlString = string.Empty;

		private DataSet ds;

		private string strSQL;

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
			para[0].Value = "A_KJ128N_Emp_Table";
			para[1].Value = "编号";
			para[2].Value = pageSize;
			para[3].Value = pageIndex;
			para[4].Value = 1;
			para[5].Value = 0;
			para[6].Value = where;

			return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
		}

		public DataSet GetEmployeeInfo(int pageIndex, int pageSize, string where)
		{
			SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
			para[0].Value = "view_EmployeeInfo";
			para[1].Value = "编号";
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

		public int DeleteEmp(string strEmpID, string strUserID)
		{
			int i;
			string sqlStr1 = "delete from Emp_Info where " + strEmpID;
			i = dba.ExecuteSql(sqlStr1);
			string sqlStr2 = "select * from CodeSender_Set where ( " + strUserID + " ) and CsTypeID=0";
			if (GetBool(sqlStr2))
			{
				string sqlStr3 = "delete from CodeSender_Set where ( " + strUserID + " ) and CsTypeID=0";
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

		public DataSet IsEmpName(string strEmpName)
		{
			sqlString = string.Format("select EmpName from Emp_Info where EmpName='{0}'", strEmpName);
			return dba.GetDataSet(sqlString);
		}

		public DataSet IsEmpName(string strEmpName, string strEmpNo)
		{
			sqlString = string.Format("select EmpName from Emp_Info where EmpName='{0}' and EmpNo<>'{1}'", strEmpName, strEmpNo);
			return dba.GetDataSet(sqlString);
		}

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
			sqlString = " Select DeptID, DeptName From Dept_Info  order by SerialNO,DeptName ";
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region【方法：获取部门信息——员工】

		public DataSet GetDept_Emp()
		{
			return dba.GetDataSet("select Dei.DeptID as ID,Dei.DeptName as Name ,Dei.ParentDeptID as ParentID,'true' as IsChild ,'true' as IsUserNum ,(Select count(1) From Emp_Info Where DeptID=Dei.DeptID) as Num From Dept_Info as Dei order by Dei.SerialNO,DeptName ");
		}

		#endregion

		#region【方法：获取职务信息——员工】

		public DataSet GetDuty_Emp()
		{
			strSQL = " Select  Dui.DutyID as ID,Dui.DutyName as Name,0 as ParentID,'true' as IsChild ,'true' as IsUserNum ,(Select count(1) From Emp_Info Where DutyID=Dui.DutyID )as Num " +
					" From Duty_Info as Dui " +
					" Union " +
					" Select -2 as ID,'未配置' as Name,0 as ParentID,'true','true',(Select count(1) From Emp_Info where (DutyID is null or DutyID=0)) ";

			return dba.GetDataSet(strSQL);

		}

		#endregion

		#region【方法：获取工种信息——员工】

		public DataSet GetWorkType_Emp()
		{
			strSQL = " Select Wi.WorkTypeID as ID,Wi.WtName as Name,0 as ParentID,'true' as IsChild ,'true' as IsUserNum , " +
							" (Select count(1) From ( select Ei.EmpID ,Ei.WorkTypeID From Emp_Info as Ei) as T Where T.WorkTypeID=Wi.WorkTypeID ) as Num " +
					 " From WorkType_Info as Wi " +
					 " Union " +
					 " Select -2 as ID,'未配置' as Name,0 as ParentID,'true','true',(Select count(1) From ( " +
							" Select Ei.EmpID ,Wti.WorkTypeID From Emp_Info as Ei " +
							" left join WorkType_Info as Wti on Ei.WorkTypeID=Wti.WorkTypeID ) as T where T.WorkTypeID is null)";

			return dba.GetDataSet(strSQL);
		}

		#endregion

		#region【方法：Czlt-2011-12-10 修改配置时间】

		public void UpdateTime()
		{
			strSQL = "UPDATE [CzltChangeTable] SET ChangeTime ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
			dba.GetDataSet(strSQL);
		}

		#endregion

		public void ExecuteSql(string sql)
		{
			dba.ExecuteSql(sql);
		}
	}
}
