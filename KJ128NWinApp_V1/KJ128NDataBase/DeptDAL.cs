using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
	public class DeptDAL
	{

		#region [ 丁静超 ]

		DbHelperSQL DB = new DbHelperSQL();

		DBAcess dba = new DBAcess();

		#region 部门信息List

		//自增列 名称
		public DataSet GetDeptInfo()
		{
			return dba.GetDataSet("select DeptID,DeptName from Dept_Info");
		}

		#endregion

		#region 获取部门所有信息

		public DataSet GetDeptAll()
		{
			string sqlString = string.Format("select * from Dept_Info");
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region 取职务信息List

		//自增列 名称
		public DataSet getDutyInfo()
		{
			return dba.GetDataSet("select DutyID,DutyName from Duty_Info");
		}

		//职务等级 EnumID,Title funid = 4
		public DataSet getDutyClassInfo()
		{
			return dba.GetDataSet("select EnumID,Title from EnumTable where FunID=4");
		}

		#endregion

		#region 工种名称List

		//自增列 名称
		public DataSet getWorkTypeInfo()
		{
			return dba.GetDataSet("select WorkTypeID,WtName from WorkType_Info");
		}

		#endregion

		#region 证书类别List

		// 自增列 名称
		public DataSet getCerTypeInfo()
		{
			return dba.GetDataSet("select CerTypeID,CerName from Certificate_Info");
		}

		#endregion

		#region 设备类型
		// 设备类型 EnumID,Title funid = 9
		public DataSet getEquTYpe()
		{
			return dba.GetDataSet("select EnumID,Title from EnumTable where FunID=9");
		}

		#endregion

		#region 生产厂家
		// 设备类型 EnumID,Title funid = 9
		public DataSet getEquFactory()
		{
			return dba.GetDataSet("select FactoryID,FactoryName from FactoryInfo where FactoryName <> '未知'");
		}

		#endregion
		#endregion

		#region [ 赵建伟 ]

		DBAcess dbAcess = new DBAcess();

		#region 部门

		#region 根据SQL语句，返回部门信息(DataTable)
		/// <summary>
		/// 根据SQL语句，返回部门信息(DataTable)
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <returns>返回部门信息(DataTable)</returns>
		public DataTable GetDataTableDept(string sql)
		{
			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					DataColumn dcDept = new DataColumn("上级部门名称");
					DataColumn dcMax = new DataColumn("最大工作时间");
					DataColumn dcMin = new DataColumn("最小工作时间");
					dt.Columns.Add(dcDept);
					dt.Columns.Add(dcMax);
					dt.Columns.Add(dcMin);
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						string strMax, strMin;
						if (dt.Rows[j][6].ToString() != "")
						{
							string strTempSql = "select * from KJ128N_AllDept where DeptID=" + Convert.ToInt32(dt.Rows[j][6]);
							using (DataSet dsTemp = dbAcess.GetDataSet(strTempSql))
							{
								if (dsTemp != null)
								{
									DataTable drTemp;
									drTemp = dsTemp.Tables[0];
									if (drTemp.Rows.Count == 1)
									{
										dt.Rows[j]["上级部门名称"] = drTemp.Rows[0][3].ToString();
									}
									else if (drTemp.Rows.Count == 0)
									{
										dt.Rows[j]["上级部门名称"] = "无";
									}
								}
							}
						}
						#region 计算最大工作时间
						if (dt.Rows[j][4].ToString().CompareTo("") == 0)
						{
							strMax = "无";
						}
						else
						{
							int intMax = Convert.ToInt32(dt.Rows[j][4]);
							int hourMax = intMax / 3600;
							int minuteMax = (intMax - hourMax * 3600) / 60;
							int secondMax = intMax % 60;
							strMax = hourMax + "时" + minuteMax + "分" + secondMax + "秒";
						}
						dt.Rows[j]["最大工作时间"] = strMax.ToString();
						#endregion
						#region 计算最小工作时间
						if (dt.Rows[j][5].ToString().CompareTo("") == 0)
						{
							strMin = "无";
						}
						else
						{
							int intMin = Convert.ToInt32(dt.Rows[j][5]);
							int hourMin = intMin / 3600;
							int minuteMin = (intMin - hourMin * 3600) / 60;
							int secondMin = intMin % 60;
							strMin = hourMin + "时" + minuteMin + "分" + secondMin + "秒";
						}
						dt.Rows[j]["最小工作时间"] = strMin.ToString();
						#endregion
					}
					return dt;
				}
				else
				{
					return null;
				}
			}
		}
		#endregion

		#region [ 方法: 增加部门信息 ]

		public int SaveDeptInfo(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID,
			 string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail,
			int MaxTimeSec, int MinTimeSec,
			int EmpID, string LeadDateTime)
		{
			SqlParameter[] sqlParmeters ={
                new SqlParameter("ParentDeptID",SqlDbType.Int),
                new SqlParameter("DeptLevelID",SqlDbType.Int),
                new SqlParameter("DeptNO",SqlDbType.NVarChar,20),
                new SqlParameter("DeptName",SqlDbType.NVarChar,20),
                new SqlParameter("Remark",SqlDbType.NVarChar,200),
                new SqlParameter("ClassID",SqlDbType.Int),
                new SqlParameter("@MaxTimeSec",SqlDbType.Int),
                new SqlParameter("@MinTimeSec",SqlDbType.Int),
                new SqlParameter("DeptTel1",SqlDbType.NVarChar,20),
                new SqlParameter("DeptTel2",SqlDbType.NVarChar,20),
                new SqlParameter("DeptFax",SqlDbType.NVarChar,20),
                new SqlParameter("DeptPost",SqlDbType.NVarChar,6),
                new SqlParameter("DeptAddress",SqlDbType.NVarChar,250),
                new SqlParameter("DeptEmail",SqlDbType.NVarChar,100),
                new SqlParameter("EmpID",SqlDbType.Int),
                new SqlParameter("LeadDateTime",SqlDbType.DateTime)
            };

			sqlParmeters[0].Value = ParentDeptID;
			sqlParmeters[1].Value = DeptLevelID;
			sqlParmeters[2].Value = DeptNO;
			sqlParmeters[3].Value = DeptName;
			sqlParmeters[4].Value = Remark;
			sqlParmeters[5].Value = ClassID;
			sqlParmeters[6].Value = MaxTimeSec;
			sqlParmeters[7].Value = MinTimeSec;
			sqlParmeters[8].Value = DeptTel1;
			sqlParmeters[9].Value = DeptTel2;
			sqlParmeters[10].Value = DeptFax;
			sqlParmeters[11].Value = DeptPost;
			sqlParmeters[12].Value = DeptAddress;
			sqlParmeters[13].Value = DeptEmail;
			sqlParmeters[14].Value = EmpID;
			if (LeadDateTime.CompareTo("") == 0)
			{
				sqlParmeters[15].Value = DateTime.Parse("1800-01-01");
			}
			else
			{
				sqlParmeters[15].Value = DateTime.Parse(LeadDateTime);
			}
			return dba.ExecuteSql("zjw_DeptInfo_Insert", sqlParmeters);
		}

		#endregion

		#region 添加 部门基本信息
		/// <summary>
		/// 添加 部门基本信息
		/// </summary>
		/// <param name="ParentDeptID">上级部门的ID</param>
		/// <param name="DeptLevelID">部门级别</param>
		/// <param name="DeptNO">部门编号</param>
		/// <param name="DeptName">部门名称</param>
		/// <param name="Remark">备注</param>
		/// <returns>返回影响行数(int)</returns>
		public int SaveDeptInfoData(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID)
		{
			SqlParameter[] sqlParmeters ={
                new SqlParameter("ParentDeptID",SqlDbType.Int),
                new SqlParameter("DeptLevelID",SqlDbType.Int),
                new SqlParameter("DeptNO",SqlDbType.NVarChar,20),
                new SqlParameter("DeptName",SqlDbType.NVarChar,20),
                new SqlParameter("Remark",SqlDbType.NVarChar,200),
                new SqlParameter("ClassID",SqlDbType.Int)
            };
			sqlParmeters[0].Value = ParentDeptID;
			sqlParmeters[1].Value = DeptLevelID;
			sqlParmeters[2].Value = DeptNO;
			sqlParmeters[3].Value = DeptName;
			sqlParmeters[4].Value = Remark;
			sqlParmeters[5].Value = ClassID;
			return dba.ExecuteSql("KJ128N_Dept_Info_Insert", sqlParmeters);
		}
		#endregion

		#region 添加 部门信息
		/// <summary>
		/// 添加部门信息
		/// </summary>
		/// <param name="DeptNO">部门NO</param>
		/// <param name="DeptTel1">部门电话1</param>
		/// <param name="DeptTel2">部门电话2</param>
		/// <param name="DeptFax">部门传真</param>
		/// <param name="DeptPost">部门邮编</param>
		/// <param name="DeptAddress">部门地址</param>
		/// <param name="DeptEmail">部门电子邮箱</param>
		/// <returns>返回影响行数</returns>
		public int SaveDeptDetailData(string DeptNO, string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail)
		{
			SqlParameter[] sqlParmeters ={
                new SqlParameter("DeptNO",SqlDbType.NVarChar,20),
                new SqlParameter("DeptTel1",SqlDbType.NVarChar,20),
                new SqlParameter("DeptTel2",SqlDbType.NVarChar,20),
                new SqlParameter("DeptFax",SqlDbType.NVarChar,20),
                new SqlParameter("DeptPost",SqlDbType.NVarChar,6),
                new SqlParameter("DeptAddress",SqlDbType.NVarChar,250),
                new SqlParameter("DeptEmail",SqlDbType.NVarChar,100)
            };
			sqlParmeters[0].Value = DeptNO;
			sqlParmeters[1].Value = DeptTel1;
			sqlParmeters[2].Value = DeptTel2;
			sqlParmeters[3].Value = DeptFax;
			sqlParmeters[4].Value = DeptPost;
			sqlParmeters[5].Value = DeptAddress;
			sqlParmeters[6].Value = DeptEmail;
			return dba.ExecuteSql("KJ128N_Dept_Detail_InsertAndUpdate", sqlParmeters);
		}

		#endregion

		#region  添加 部门设置
		/// <summary>
		/// 添加 部门设置
		/// </summary>
		/// <param name="DeptNO">部门NO</param>
		/// <param name="MaxTimeSec">最大工作时间</param>
		/// <param name="MinTimeSec">最小工作时间</param>
		/// <returns>返回影响行数(int)</returns>
		public int SaveDeptSysSetData(string DeptNO, int MaxTimeSec, int MinTimeSec)
		{
			SqlParameter[] sqlParmeters ={
                new SqlParameter("@DeptNO",SqlDbType.NVarChar,20),
                new SqlParameter("@MaxTimeSec",SqlDbType.Int),
                new SqlParameter("@MinTimeSec",SqlDbType.Int)
            };
			sqlParmeters[0].Value = DeptNO;
			sqlParmeters[1].Value = MaxTimeSec;
			sqlParmeters[2].Value = MinTimeSec;
			return dba.ExecuteSql("KJ128N_Emp_SysSet_Insert", sqlParmeters);
		}
		#endregion

		#region 添加 部门领导
		/// <summary>
		/// 添加 部门领导
		/// </summary>
		/// <param name="DeptNO">部门NO</param>
		/// <param name="EmpID">领导ID</param>
		/// <param name="LeadDateTime">领导上任时间</param>
		/// <returns>返回影响行数(int)</returns>
		public int SaveDeptLeadData(string DeptNO, int EmpID, string LeadDateTime)
		{
			SqlParameter[] sqlParmeters ={
                new SqlParameter("DeptNO",SqlDbType.NVarChar,20),
                new SqlParameter("EmpID",SqlDbType.Int),
                new SqlParameter("LeadDateTime",SqlDbType.DateTime)
            };
			sqlParmeters[0].Value = DeptNO;
			sqlParmeters[1].Value = EmpID;
			if (LeadDateTime.CompareTo("") == 0)
			{
				sqlParmeters[2].Value = DateTime.Parse("1800-01-01");
			}
			else
			{
				sqlParmeters[2].Value = DateTime.Parse(LeadDateTime);
			}
			return dba.ExecuteSql("KJ128N_Dept_Lead_Insert", sqlParmeters);     //KJ128N_Dept_Lead_Insert

		}
		#endregion

		#region 修改 部门基本信息
		/// <summary>
		/// 修改部门基本信息
		/// </summary>
		/// <param name="DeptID">部门ID</param>
		/// <param name="ParentDeptID">上级部门ID</param>
		/// <param name="DeptLevelID">部门级别</param>
		/// <param name="DeptNO">部门编号</param>
		/// <param name="DeptName">部门名称</param>
		/// <param name="Remark">备注</param>
		/// <returns>返回影响行数</returns>
		public int UpDateDeptInfoData(int DeptID, int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID)
		{
			string updateString = string.Format("update Dept_Info set ParentDeptID={0},DeptLevelID={1}"
				+ ",DeptNO='{2}',DeptName='{3}',Remark='{4}',ClassID={5} where DeptID = {6}",
				 ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark, ClassID, DeptID);
			return dba.ExecuteSql(updateString);
		}
		#endregion

		#region 修改 部门信息
		/// <summary>
		/// 修改部门信息
		/// </summary>
		/// <param name="DeptID">部门ID</param>
		/// <param name="DeptTel1">部门电话1</param>
		/// <param name="DeptTel2">部门电话2</param>
		/// <param name="DeptFax">部门传真</param>
		/// <param name="DeptPost">部门邮编</param>
		/// <param name="DeptAddress">部门地址</param>
		/// <param name="DeptEmail">部门电子邮箱</param>
		/// <returns>返回影响行数</returns>
		public int UpDateDeptDetailData(int DeptID, string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail)
		{
			string updateString = string.Format("update Dept_Detail set DeptTel1='{0}',DeptTel2='{1}',DeptFax='{2}',DeptPost='{3}'"
				+ ",DeptAddress='{4}',DeptEmail='{5}' where DeptID = {6}",
				 DeptTel1, DeptTel2, DeptFax, DeptPost, DeptAddress, DeptEmail, DeptID);
			return dba.ExecuteSql(updateString);
		}
		#endregion

		#region 修改 部门配置
		/// <summary>
		/// 修改部门配置
		/// </summary>
		/// <param name="DeptID">部门ID</param>
		/// <param name="MaxTimeSec">最大工作时间</param>
		/// <param name="MinTimeSec">最小工作时间</param>
		/// <returns>返回影响行数</returns>
		public int UpDateDeptSysSetData(int DeptID, int MaxTimeSec, int MinTimeSec)
		{
			string updateString = "";
			string sqlString = string.Format("select * from Dept_SysSet where DeptID='{0}'", DeptID);
			using (DataSet ds = dba.GetDataSet(sqlString))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					if (dt.Rows.Count != 0)         //部门配置表中有该记录，可以修改
					{
						updateString = string.Format("update Dept_SysSet set MaxTimeSec={0},MinTimeSec={1} where DeptID = {2}",
							MaxTimeSec, MinTimeSec, DeptID);
					}
					else                           //部门配置表中没有该记录，需要增加
					{
						updateString = string.Format("insert into Dept_SysSet(DeptID,MaxTimeSec,MinTimeSec) values({0},{1},{2})",
							 DeptID, MaxTimeSec, MinTimeSec);
					}
				}
			}

			return dba.ExecuteSql(updateString);
		}
		#endregion

		#region 修改 部门领导信息
		/// <summary>
		/// 修改部门领导信息
		/// </summary>
		/// <param name="DeptID">部门ID</param>
		/// <param name="EmpID">部门领导ID</param>
		/// <param name="LeadDateTime">领导上任时间</param>
		/// <returns>返回影响行数</returns>
		public int UpDateDeptLeadData(string DeptNO, int EmpID, string LeadDateTime)
		{
			SqlParameter[] sqlParmeters ={
                new SqlParameter("DeptNO",SqlDbType.NVarChar,20),
                new SqlParameter("EmpID",SqlDbType.Int),
                new SqlParameter("LeadDateTime",SqlDbType.DateTime)
            };
			sqlParmeters[0].Value = DeptNO;
			sqlParmeters[1].Value = EmpID;
			if (LeadDateTime.CompareTo("") == 0)
			{
				sqlParmeters[2].Value = DateTime.Parse("1800-01-01");
			}
			else
			{
				sqlParmeters[2].Value = DateTime.Parse(LeadDateTime);
			}
			return dba.ExecuteSql("KJ128N_Dept_Lead_Insert", sqlParmeters);
			//DateTime dtLead;
			//if (LeadDateTime.CompareTo("") == 0)
			//{
			//    dtLead = DateTime.Parse("1800-01-01");
			//}
			//else
			//{
			//    dtLead = DateTime.Parse(LeadDateTime);
			//}
			//string updateString = string.Format("update Dept_Lead set EmpID={0},LeadDateTime='{1}' where DeptID = {2}",
			//     EmpID, dtLead, DeptID);
			//return dba.ExecuteSql(updateString);
		}
		#endregion

		#region 删除部门领导信息
		/// <summary>
		/// 删除部门领导信息
		/// </summary>
		/// <param name="DeptID">部门ID</param>
		/// <returns>返回影响行数</returns>
		public int DeleteDeptLead(int DeptID)
		{
			string sqlString = "Delete from Dept_Lead Where DeptID=" + DeptID.ToString();
			return dba.ExecuteSql(sqlString);
		}
		#endregion

		#region 删除 部门信息
		/// <summary>
		/// 删除部门信息
		/// </summary>
		/// <param name="DeptID">部门ID</param>
		/// <returns>返回影响行数</returns>
		public int DeleteDept(int DeptID)
		{
			string sqlString = string.Format("delete from Dept_Info where DeptID={0} or DeptID in(select DeptID from Dept_Info where ParentDeptID={0}) or deptID in(select DeptID from Dept_Info where ParentDeptID in(select DeptID from Dept_Info where ParentDeptID={0})) or deptID in(select DeptID from Dept_Info where ParentDeptID in(select DeptID from Dept_Info where ParentDeptID in(select DeptID from Dept_Info where ParentDeptID={0})))", DeptID);
			return dba.ExecuteSql(sqlString);
		}
		#endregion

		#region 获取 上级部门(DataSet)
		//获取 上级部门(DataSet)
		/// <summary>
		/// 获取 上级部门(DataSet)
		/// </summary>
		/// <returns>上级部门(DataSet)</returns>
		public DataSet GetParentDeptDataSet()
		{
			return dba.GetDataSet("select DeptID,DeptName from Dept_Info where DeptLevelID<5 and DeptLevelID>0");
		}
		#endregion

		#region 获取 班制名称(DataSet)
		public DataSet GetClassDataSet()
		{
			return dba.GetDataSet("select ID,ClassName from InfoClass");
		}
		#endregion


		#region [ 获取部门信息 ]

		public DataSet GetDeptDataSet()
		{
			return dbAcess.GetDataSet("KJ128N_Dept_Info_Select_TreeView", new SqlParameter[0]);
		}

		#endregion

		#endregion

		#region 职务

		#region 根据SQL语句，返回职务信息(DataTable)
		/// <summary>
		/// 根据SQL语句，返回职务信息(DataTable)
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <returns>返回职务信息(DataTable)</returns>
		public DataTable GetDataTableDuty(string sql)
		{

			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					DataColumn dc = new DataColumn("职务等级");
					dt.Columns.Add(dc);
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						string strSql = "select Title from EnumTable where FunID=4 and EnumID=" + dt.Rows[j][2].ToString();
						dt.Rows[j]["职务等级"] = GetString(strSql);

					}
					dt.Columns[4].SetOrdinal(2);
					return dt;
				}
				else
				{
					return null;
				}
			}
		}
		#endregion

		#region 添加 职务信息
		/// <summary>
		/// 添加职务信息
		/// </summary>
		/// <param name="DutyName">职务名称</param>
		/// <param name="DutyClassID">职务等级</param>
		/// <param name="DuptRemark"><备注/param>
		/// <returns>返回影响行数</returns>
		public int SaveDutyInfoData(string DutyName, int DutyClassID, string DuptRemark)
		{
			string SaveString = " If( not exists ( Select 1 From Duty_Info Where DutyName= '" + DutyName + "')) " +
								" Begin " +
									" insert into Duty_Info(DutyName,DutyClassID,Remark) " +
									" Values( '" + DutyName + "' , " + DutyClassID + ", '" + DuptRemark + "' )" +
								" End ";
			//string SaveString = string.Format("insert into Duty_Info(DutyName,DutyClassID,Remark) values('{0}',{1},'{2}')",
			//    DutyName, DutyClassID, DuptRemark);
			return dba.ExecuteSql(SaveString);
		}
		#endregion

		#region 修改 职务信息
		/// <summary>
		/// 修改职务信息
		/// </summary>
		/// <param name="DutyID">职务ID</param>
		/// <param name="DutyName">职务名称</param>
		/// <param name="DutyClassID">职务等级</param>
		/// <param name="DutyRemark">备注</param>
		/// <returns>返回影响行数</returns>
		public int UpDateDutyInfo(int DutyID, string DutyName, int DutyClassID, string DutyRemark)
		{
			string UpDateString = string.Format("update Duty_Info set DutyName='{0}',DutyClassID={1},Remark='{2}' where DutyID={3}",
				DutyName, DutyClassID, DutyRemark, DutyID);
			return dba.ExecuteSql(UpDateString);
		}
		#endregion

		#region 删除 职务信息
		/// <summary>
		/// 删除职务信息
		/// </summary>
		/// <param name="DutyID">职务ID</param>
		/// <returns>返回影响行数</returns>
		public int DeleteDuty(int DutyID)
		{
			string sqlString = string.Format("delete from Duty_Info where DutyID={0}", DutyID);
			return dba.ExecuteSql(sqlString);
		}
		#endregion

		#endregion

		#region 证书

		#region 根据SQL语句，返回证书信息(DataTable)
		/// <summary>
		/// 根据SQL语句，返回证书信息(DataTable)
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <returns>返回证书信息(DataTable)</returns>
		public DataTable GetDataTableCertificate(string sql)
		{

			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					DataColumn dc = new DataColumn("是否检查证书有效期");
					dt.Columns.Add(dc);
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						int i;
						i = Convert.ToInt32(dt.Rows[j][3]);

						if (i == 0)
						{
							dt.Rows[j]["是否检查证书有效期"] = "不检查";
						}
						else
						{
							dt.Rows[j]["是否检查证书有效期"] = "检查";
						}
					}
					dt.Columns[5].SetOrdinal(4);
					return dt;
				}
				else
				{
					return null;
				}
			}
		}
		#endregion

		#region 添加 证书信息
		/// <summary>
		/// 添加证书信息
		/// </summary>
		/// <param name="CerName">证书名称</param>
		/// <param name="CerVestIn">发证单位</param>
		/// <param name="IsCheckExpDate">是否检查证书有效期</param>
		/// <param name="CertificateRemark">备注</param>
		/// <returns>影响行数</returns>
		public int SaveCertificateData(string CerName, string CerVestIn, int IsCheckExpDate, string CertificateRemark)
		{
			string SaveString = " If( not exists ( Select 1 From Certificate_Info Where CerName='" + CerName + "')) " +
								" Begin " +
									" insert into Certificate_Info(CerName,CerVestIn,IsCheckExpDate,Remark) " +
									" Values( '" + CerName + "' , '" + CerVestIn + "' , " + IsCheckExpDate + " , '" + CertificateRemark + "')" +
								" End ";

			//string SaveString = string.Format("insert into Certificate_Info(CerName,CerVestIn,IsCheckExpDate,Remark) values('{0}','{1}',{2},'{3}')",
			//    CerName, CerVestIn, IsCheckExpDate, CertificateRemark);
			return dba.ExecuteSql(SaveString);
		}
		#endregion

		#region 修改 证书信息
		/// <summary>
		/// 修改证书信息
		/// </summary>
		/// <param name="CerTypeID">证书ID</param>
		/// <param name="CerName">证书名称</param>
		/// <param name="CerVestIn">发证单位</param>
		/// <param name="IsCheckExpDate">是否检查证书有效期</param>
		/// <param name="CertificateRemark">备注</param>
		/// <returns>返回影响行数</returns>
		public int UpDateCertificate(int CerTypeID, string CerName, string CerVestIn, int IsCheckExpDate, string CertificateRemark)
		{
			string UpDateString = string.Format("update Certificate_Info set CerName='{0}',CerVestIn='{1}',IsCheckExpDate={2},Remark='{3}' where CerTypeID={4}",
				CerName, CerVestIn, IsCheckExpDate, CertificateRemark, CerTypeID);
			return dba.ExecuteSql(UpDateString);
		}
		#endregion

		#region 删除 证书信息
		/// <summary>
		/// 删除证书信息
		/// </summary>
		/// <param name="CerTypeID">证书ID</param>
		/// <returns>返回影响行数</returns>
		public int DeleteCertificate(int CerTypeID)
		{
			string sqlString = string.Format("delete from Certificate_Info where CerTypeID={0}", CerTypeID);
			return dba.ExecuteSql(sqlString);
		}
		#endregion

		#endregion

		#region 工种

		#region 根据SQL语句，返回工种信息(DataTable)
		/// <summary>
		/// 根据SQL语句，返回工种信息(DataTable)
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <returns>返回工种信息(DataTable)</returns>
		public DataTable GetDataTableWorkType(string sql)
		{
			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					DataColumn dcMax = new DataColumn("最大工作时间");
					DataColumn dcMin = new DataColumn("最小工作时间");
					dt.Columns.Add(dcMax);
					dt.Columns.Add(dcMin);
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						string strMax, strMin;
						#region 计算最大工作时间
						if (dt.Rows[j][5].ToString().CompareTo("") == 0)
						{
							strMax = "";
						}
						else
						{
							int intMax = Convert.ToInt32(dt.Rows[j][5]);
							int hourMax = intMax / 3600;
							int minuteMax = (intMax - hourMax * 3600) / 60;
							int secondMax = intMax % 60;
							strMax = hourMax + "时" + minuteMax + "分" + secondMax + "秒";
						}
						dt.Rows[j]["最大工作时间"] = strMax.ToString();
						#endregion
						#region 计算最小工作时间
						if (dt.Rows[j][6].ToString().CompareTo("") == 0)
						{
							strMin = "";
						}
						else
						{
							int intMin = Convert.ToInt32(dt.Rows[j][6]);
							int hourMin = intMin / 3600;
							int minuteMin = (intMin - hourMin * 3600) / 60;
							int secondMin = intMin % 60;
							strMin = hourMin + "时" + minuteMin + "分" + secondMin + "秒";
						}
						dt.Rows[j]["最小工作时间"] = strMin.ToString();
						#endregion
					}
					dt.Columns[8].SetOrdinal(4);
					dt.Columns[9].SetOrdinal(5);
					return dt;
				}
				else
				{
					return null;
				}
			}
		}
		#endregion

		#region 【方法: 添加 工种信息 】

		public int SaveWorkData(string WtName, int CerTypeID, string WorkRemark,
			int MaxTimeSec, int MinTimeSec)
		{
			SqlParameter[] sqlParmeters ={
                new SqlParameter("@WtName",SqlDbType.NVarChar,50),
                new SqlParameter("@CerTypeID",SqlDbType.Int),
                new SqlParameter("@Remark",SqlDbType.NVarChar,50),
                new SqlParameter("@MaxTimeSec",SqlDbType.Int),
                new SqlParameter("@MinTimeSec",SqlDbType.Int)
            };
			sqlParmeters[0].Value = WtName;
			sqlParmeters[1].Value = CerTypeID;
			sqlParmeters[2].Value = WorkRemark;
			sqlParmeters[3].Value = MaxTimeSec;
			sqlParmeters[4].Value = MinTimeSec;

			return dba.ExecuteSql("zjw_WorkType_Insert", sqlParmeters);


		}

		#endregion

		#region 【方法: 修改 工种信息 】

		public int UpDateWorkType(string WtName, int CerTypeID, string WorkRemark,
			int MaxTimeSec, int MinTimeSec)
		{
			SqlParameter[] sqlParmeters ={
                new SqlParameter("@WtName",SqlDbType.NVarChar,50),
                new SqlParameter("@CerTypeID",SqlDbType.Int),
                new SqlParameter("@Remark",SqlDbType.NVarChar,50),
                new SqlParameter("@MaxTimeSec",SqlDbType.Int),
                new SqlParameter("@MinTimeSec",SqlDbType.Int)
            };
			sqlParmeters[0].Value = WtName;
			sqlParmeters[1].Value = CerTypeID;
			sqlParmeters[2].Value = WorkRemark;
			sqlParmeters[3].Value = MaxTimeSec;
			sqlParmeters[4].Value = MinTimeSec;

			return dba.ExecuteSql("zjw_WorkType_Update", sqlParmeters);

		}

		#endregion

		#region 删除 工种信息
		public int DeleteWork(int WorkTypeID)
		{
			string sqlString = string.Format("delete from WorkType_Info where WorkTypeID={0}", WorkTypeID);
			return dba.ExecuteSql(sqlString);
		}

		#endregion

		#region 获取证书名称
		public DataSet GetWorkCerDataSet()
		{
			return dba.GetDataSet("select * from Certificate_Info");
		}
		#endregion

		#endregion

		#region 执行SQL语句，返回执行结果（整形）
		/// <summary>
		/// 执行SQL语句，返回执行结果（整形）
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <returns>返回执行结果(int)</returns>
		public int GetID(string sql)
		{
			//KJ128NDataBase.DBAcess dbAcess = new KJ128NDataBase.DBAcess();
			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null && ds.Tables.Count > 0)
				{
					DataTable dt = ds.Tables[0];
					if (dt.Rows.Count > 0)
					{
						return (Int32)ds.Tables[0].Rows[0][0];
					}
					else
					{
						return 0;
					}
				}
				else
				{
					return 0;
				}
			}
		}
		#endregion

		#region 执行SQL语句，返回执行结果（string）
		/// <summary>
		/// 执行SQL语句，返回执行结果（整形）
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <returns>返回执行结果(string)</returns>
		public string GetString(string sql)
		{
			//KJ128NDataBase.DBAcess dbAcess = new KJ128NDataBase.DBAcess();
			using (DataSet ds = dba.GetDataSet(sql))
			{
				DataTable dt = ds.Tables[0];
				return ds.Tables[0].Rows[0][0].ToString();
			}
		}
		#endregion

		#region 执行SQL语句，返回执行结果（Table）
		/// <summary>
		/// 执行SQL语句，返回执行结果（Table）
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <returns>返回执行结果(Table)</returns>
		public DataTable GetTable(string sql)
		{
			//KJ128NDataBase.DBAcess dbAcess = new KJ128NDataBase.DBAcess();
			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null)
					return ds.Tables[0];
				else
					return null;
			}
		}
		#endregion
		#endregion

		#region [ 易晓岚 ]

		#region 部门信息
		/// <summary>
		/// 部门信息
		/// </summary>
		/// <returns></returns>
		public DataSet getDept()
		{
			return dba.GetDataSet("select DeptID, DeptNo,DeptName from Dept_Info order by DeptName");
		}

		#endregion

		#region 设备状态
		/// <summary>
		/// 设备状态
		/// </summary>
		/// <returns></returns>
		public DataSet getEquStation()
		{
			return dba.GetDataSet("select EnumID,Title from EnumTable where FunID = 10");
		}
		#endregion

		#endregion

		#region [ 申云飞 ]
		#region 根据部门流水得到时段信息
		public DataSet GetClassInfo(int intDeptId, out string strErrMsg)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@intDept", SqlDbType.Int)};
			parameters[0].Value = intDeptId;
			return DB.RunProcedureByDataSet("Shine_Departments_GetClassInfoByDeptID", "ds", parameters, out strErrMsg);
		}
		#endregion

		#region 查询部门工时单价信息
		public DataSet GetUnitPriceInfo(string strWhere, out string strErr)
		{
			SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,200)
            };

			parameter[0].Value = strWhere;

			return DB.RunProcedureByDataSet("Shine_Shen_UnitPrice_Query", "dst", parameter, out strErr);
		}
		#endregion

		#region 添加部门工时单价信息
		public int InsertUnitPriceInfo(int intDeptID, float fUnitPrice, string strRemark, out string strErr)
		{
			SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@DeptID",SqlDbType.Int,4),
                new SqlParameter("@UnitPrice",SqlDbType.Float,8),
                new SqlParameter("@Remark",SqlDbType.VarChar,200)
            };

			parameter[0].Value = intDeptID;
			parameter[1].Value = fUnitPrice;
			parameter[2].Value = strRemark;

			return DB.RunProcedureByInt("Shine_Shen_UnitPrice_Add", parameter, out strErr);
		}
		#endregion

		#region 修改部门工时单价信息
		public int UpdateUnitPriceInfo(int intDeptID, float fUnitPrice, string strRemark, out string strErr)
		{
			SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@DeptID",SqlDbType.Int,4),
                new SqlParameter("@UnitPrice",SqlDbType.Float,8),
                new SqlParameter("@Remark",SqlDbType.VarChar,200)
            };

			parameter[0].Value = intDeptID;
			parameter[1].Value = fUnitPrice;
			parameter[2].Value = strRemark;

			return DB.RunProcedureByInt("Shine_Shen_UnitPrice_Modify", parameter, out strErr);
		}
		#endregion

		#region 删除部门工时单价信息
		public int DeleteUnitPriceInfo(int intDeptID, out string strErr)
		{
			SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@DeptID",SqlDbType.Int,4)
            };

			parameter[0].Value = intDeptID;

			return DB.RunProcedureByInt("Shine_Shen_UnitPrice_Delete", parameter, out strErr);
		}
		#endregion
		#endregion

		#region [ 修改 ]

		#region [ 方法: KJ128N_AllDept ]

		public DataSet GetKJ128NAllDept(int tempDept_ID)
		{
			string strsql = "select * from KJ128N_AllDept where DeptID=" + tempDept_ID;
			return dba.GetDataSet(strsql);
		}

		#endregion

		#region [ 方法: 根据部门DeptID获取部门信息 ]

		public DataSet GetIDDeptInfo(string strDeptID)
		{
			string strTempSql = "select * from KJ128N_AllDept where DeptID=" + strDeptID;
			return dba.GetDataSet(strTempSql);
		}

		#endregion

		#region [ 方法: 根据EmpID得到人员信息 ]

		public DataSet GetEmpIDEmpInfo(string empID)
		{
			string strTempSql = "select * from Emp_Info where EmpID=" + empID;
			return dba.GetDataSet(strTempSql);
		}

		#endregion

		#region [ 方法: 验证部门编号唯一性 ]

		public DataSet GetIDDeptID(string deptID)
		{
			string sqlString = string.Format("select * from KJ128N_Dept_Info_Table where 部门编号='{0}'", deptID);
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region [ 方法: 验证部门领导 ]

		public DataSet GetEmpNameEmpInfo(string empName)
		{
			string sqlString = string.Format("select * from Emp_Info where EmpName='{0}'", empName);
			return dba.GetDataSet(sqlString);
		}

		#endregion


		#region [ 方法: 验证部门领导 ]

		public DataSet GetDutyInfoTable(string empName)
		{
			string sqlString = string.Format("select * from KJ128N_Duty_Info_Table where 职务名称='{0}'", empName);
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region [ 方法: KJ128N_Duty_Info_Table ]

		public DataSet GetIDDutyInfoTable(int tempDuty_ID)
		{
			string sqlString = "select * from KJ128N_Duty_Info_Table where DutyID=" + tempDuty_ID;
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region [ 方法: KJ128N_Duty_Info_Table ]

		public DataSet GetIDWorkTypeInfoTable(int tempWork_ID)
		{
			string sqlString = "select * from KJ128N_WorkType_Info_Table where 工种编号=" + tempWork_ID;
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region [ 方法: KJ128N_Duty_Info_Table ]

		public DataSet GetNameWorkTypeInfoTable(string WtName)
		{
			string sqlString = string.Format("select * from KJ128N_WorkType_Info_Table where 工种名称='{0}'", WtName);
			return dba.GetDataSet(sqlString);
		}

		#endregion


		#region [ 方法: 获得职务等级 ]

		public DataSet GetDutyGrade()
		{
			string sqlString = "select Title from EnumTable where FunID=4";
			return dba.GetDataSet(sqlString);

		}

		#endregion

		#region [ 方法: 获得证书信息 ]

		public DataSet GetCertificateInfo(int tempCer_ID)
		{
			string sqlString = "select * from KJ128N_Certificate_Info_Table where 证书类别=" + tempCer_ID;
			return dba.GetDataSet(sqlString);
		}

		#endregion

		//strsql = "select * from KJ128N_Certificate_Info_Table where 证书类别=" + tempCer_ID;
		#endregion

		#region 【Czlt-2011-06-14 领导级别查询】
		public DataSet CzltGetDutyClassInfo()
		{
			return dba.GetDataSet("select EnumID,Title from EnumTable where FunID=4 and EnumValue =1 order by EnumID");
		}
		#endregion

		#region 【Czlt-2012-05-21 查询子部门名称】
		/// <summary>
		/// Czlt-2012-5-21查询部门名称
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public DataTable GetDeptId(string strSql)
		{
			DataTable dt = null;
			DataSet ds = dba.GetDataSet(strSql);
			if (ds != null && ds.Tables.Count > 0)
			{
				dt = ds.Tables[0];
			}
			return dt;
		}
		#endregion
	}
}

