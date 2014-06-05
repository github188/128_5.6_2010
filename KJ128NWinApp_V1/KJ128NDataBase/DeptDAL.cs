using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
	public class DeptDAL
	{

		#region [ ������ ]

		DbHelperSQL DB = new DbHelperSQL();

		DBAcess dba = new DBAcess();

		#region ������ϢList

		//������ ����
		public DataSet GetDeptInfo()
		{
			return dba.GetDataSet("select DeptID,DeptName from Dept_Info");
		}

		#endregion

		#region ��ȡ����������Ϣ

		public DataSet GetDeptAll()
		{
			string sqlString = string.Format("select * from Dept_Info");
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region ȡְ����ϢList

		//������ ����
		public DataSet getDutyInfo()
		{
			return dba.GetDataSet("select DutyID,DutyName from Duty_Info");
		}

		//ְ��ȼ� EnumID,Title funid = 4
		public DataSet getDutyClassInfo()
		{
			return dba.GetDataSet("select EnumID,Title from EnumTable where FunID=4");
		}

		#endregion

		#region ��������List

		//������ ����
		public DataSet getWorkTypeInfo()
		{
			return dba.GetDataSet("select WorkTypeID,WtName from WorkType_Info");
		}

		#endregion

		#region ֤�����List

		// ������ ����
		public DataSet getCerTypeInfo()
		{
			return dba.GetDataSet("select CerTypeID,CerName from Certificate_Info");
		}

		#endregion

		#region �豸����
		// �豸���� EnumID,Title funid = 9
		public DataSet getEquTYpe()
		{
			return dba.GetDataSet("select EnumID,Title from EnumTable where FunID=9");
		}

		#endregion

		#region ��������
		// �豸���� EnumID,Title funid = 9
		public DataSet getEquFactory()
		{
			return dba.GetDataSet("select FactoryID,FactoryName from FactoryInfo where FactoryName <> 'δ֪'");
		}

		#endregion
		#endregion

		#region [ �Խ�ΰ ]

		DBAcess dbAcess = new DBAcess();

		#region ����

		#region ����SQL��䣬���ز�����Ϣ(DataTable)
		/// <summary>
		/// ����SQL��䣬���ز�����Ϣ(DataTable)
		/// </summary>
		/// <param name="sql">SQL���</param>
		/// <returns>���ز�����Ϣ(DataTable)</returns>
		public DataTable GetDataTableDept(string sql)
		{
			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					DataColumn dcDept = new DataColumn("�ϼ���������");
					DataColumn dcMax = new DataColumn("�����ʱ��");
					DataColumn dcMin = new DataColumn("��С����ʱ��");
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
										dt.Rows[j]["�ϼ���������"] = drTemp.Rows[0][3].ToString();
									}
									else if (drTemp.Rows.Count == 0)
									{
										dt.Rows[j]["�ϼ���������"] = "��";
									}
								}
							}
						}
						#region ���������ʱ��
						if (dt.Rows[j][4].ToString().CompareTo("") == 0)
						{
							strMax = "��";
						}
						else
						{
							int intMax = Convert.ToInt32(dt.Rows[j][4]);
							int hourMax = intMax / 3600;
							int minuteMax = (intMax - hourMax * 3600) / 60;
							int secondMax = intMax % 60;
							strMax = hourMax + "ʱ" + minuteMax + "��" + secondMax + "��";
						}
						dt.Rows[j]["�����ʱ��"] = strMax.ToString();
						#endregion
						#region ������С����ʱ��
						if (dt.Rows[j][5].ToString().CompareTo("") == 0)
						{
							strMin = "��";
						}
						else
						{
							int intMin = Convert.ToInt32(dt.Rows[j][5]);
							int hourMin = intMin / 3600;
							int minuteMin = (intMin - hourMin * 3600) / 60;
							int secondMin = intMin % 60;
							strMin = hourMin + "ʱ" + minuteMin + "��" + secondMin + "��";
						}
						dt.Rows[j]["��С����ʱ��"] = strMin.ToString();
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

		#region [ ����: ���Ӳ�����Ϣ ]

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

		#region ��� ���Ż�����Ϣ
		/// <summary>
		/// ��� ���Ż�����Ϣ
		/// </summary>
		/// <param name="ParentDeptID">�ϼ����ŵ�ID</param>
		/// <param name="DeptLevelID">���ż���</param>
		/// <param name="DeptNO">���ű��</param>
		/// <param name="DeptName">��������</param>
		/// <param name="Remark">��ע</param>
		/// <returns>����Ӱ������(int)</returns>
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

		#region ��� ������Ϣ
		/// <summary>
		/// ��Ӳ�����Ϣ
		/// </summary>
		/// <param name="DeptNO">����NO</param>
		/// <param name="DeptTel1">���ŵ绰1</param>
		/// <param name="DeptTel2">���ŵ绰2</param>
		/// <param name="DeptFax">���Ŵ���</param>
		/// <param name="DeptPost">�����ʱ�</param>
		/// <param name="DeptAddress">���ŵ�ַ</param>
		/// <param name="DeptEmail">���ŵ�������</param>
		/// <returns>����Ӱ������</returns>
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

		#region  ��� ��������
		/// <summary>
		/// ��� ��������
		/// </summary>
		/// <param name="DeptNO">����NO</param>
		/// <param name="MaxTimeSec">�����ʱ��</param>
		/// <param name="MinTimeSec">��С����ʱ��</param>
		/// <returns>����Ӱ������(int)</returns>
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

		#region ��� �����쵼
		/// <summary>
		/// ��� �����쵼
		/// </summary>
		/// <param name="DeptNO">����NO</param>
		/// <param name="EmpID">�쵼ID</param>
		/// <param name="LeadDateTime">�쵼����ʱ��</param>
		/// <returns>����Ӱ������(int)</returns>
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

		#region �޸� ���Ż�����Ϣ
		/// <summary>
		/// �޸Ĳ��Ż�����Ϣ
		/// </summary>
		/// <param name="DeptID">����ID</param>
		/// <param name="ParentDeptID">�ϼ�����ID</param>
		/// <param name="DeptLevelID">���ż���</param>
		/// <param name="DeptNO">���ű��</param>
		/// <param name="DeptName">��������</param>
		/// <param name="Remark">��ע</param>
		/// <returns>����Ӱ������</returns>
		public int UpDateDeptInfoData(int DeptID, int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID)
		{
			string updateString = string.Format("update Dept_Info set ParentDeptID={0},DeptLevelID={1}"
				+ ",DeptNO='{2}',DeptName='{3}',Remark='{4}',ClassID={5} where DeptID = {6}",
				 ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark, ClassID, DeptID);
			return dba.ExecuteSql(updateString);
		}
		#endregion

		#region �޸� ������Ϣ
		/// <summary>
		/// �޸Ĳ�����Ϣ
		/// </summary>
		/// <param name="DeptID">����ID</param>
		/// <param name="DeptTel1">���ŵ绰1</param>
		/// <param name="DeptTel2">���ŵ绰2</param>
		/// <param name="DeptFax">���Ŵ���</param>
		/// <param name="DeptPost">�����ʱ�</param>
		/// <param name="DeptAddress">���ŵ�ַ</param>
		/// <param name="DeptEmail">���ŵ�������</param>
		/// <returns>����Ӱ������</returns>
		public int UpDateDeptDetailData(int DeptID, string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail)
		{
			string updateString = string.Format("update Dept_Detail set DeptTel1='{0}',DeptTel2='{1}',DeptFax='{2}',DeptPost='{3}'"
				+ ",DeptAddress='{4}',DeptEmail='{5}' where DeptID = {6}",
				 DeptTel1, DeptTel2, DeptFax, DeptPost, DeptAddress, DeptEmail, DeptID);
			return dba.ExecuteSql(updateString);
		}
		#endregion

		#region �޸� ��������
		/// <summary>
		/// �޸Ĳ�������
		/// </summary>
		/// <param name="DeptID">����ID</param>
		/// <param name="MaxTimeSec">�����ʱ��</param>
		/// <param name="MinTimeSec">��С����ʱ��</param>
		/// <returns>����Ӱ������</returns>
		public int UpDateDeptSysSetData(int DeptID, int MaxTimeSec, int MinTimeSec)
		{
			string updateString = "";
			string sqlString = string.Format("select * from Dept_SysSet where DeptID='{0}'", DeptID);
			using (DataSet ds = dba.GetDataSet(sqlString))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					if (dt.Rows.Count != 0)         //�������ñ����иü�¼�������޸�
					{
						updateString = string.Format("update Dept_SysSet set MaxTimeSec={0},MinTimeSec={1} where DeptID = {2}",
							MaxTimeSec, MinTimeSec, DeptID);
					}
					else                           //�������ñ���û�иü�¼����Ҫ����
					{
						updateString = string.Format("insert into Dept_SysSet(DeptID,MaxTimeSec,MinTimeSec) values({0},{1},{2})",
							 DeptID, MaxTimeSec, MinTimeSec);
					}
				}
			}

			return dba.ExecuteSql(updateString);
		}
		#endregion

		#region �޸� �����쵼��Ϣ
		/// <summary>
		/// �޸Ĳ����쵼��Ϣ
		/// </summary>
		/// <param name="DeptID">����ID</param>
		/// <param name="EmpID">�����쵼ID</param>
		/// <param name="LeadDateTime">�쵼����ʱ��</param>
		/// <returns>����Ӱ������</returns>
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

		#region ɾ�������쵼��Ϣ
		/// <summary>
		/// ɾ�������쵼��Ϣ
		/// </summary>
		/// <param name="DeptID">����ID</param>
		/// <returns>����Ӱ������</returns>
		public int DeleteDeptLead(int DeptID)
		{
			string sqlString = "Delete from Dept_Lead Where DeptID=" + DeptID.ToString();
			return dba.ExecuteSql(sqlString);
		}
		#endregion

		#region ɾ�� ������Ϣ
		/// <summary>
		/// ɾ��������Ϣ
		/// </summary>
		/// <param name="DeptID">����ID</param>
		/// <returns>����Ӱ������</returns>
		public int DeleteDept(int DeptID)
		{
			string sqlString = string.Format("delete from Dept_Info where DeptID={0} or DeptID in(select DeptID from Dept_Info where ParentDeptID={0}) or deptID in(select DeptID from Dept_Info where ParentDeptID in(select DeptID from Dept_Info where ParentDeptID={0})) or deptID in(select DeptID from Dept_Info where ParentDeptID in(select DeptID from Dept_Info where ParentDeptID in(select DeptID from Dept_Info where ParentDeptID={0})))", DeptID);
			return dba.ExecuteSql(sqlString);
		}
		#endregion

		#region ��ȡ �ϼ�����(DataSet)
		//��ȡ �ϼ�����(DataSet)
		/// <summary>
		/// ��ȡ �ϼ�����(DataSet)
		/// </summary>
		/// <returns>�ϼ�����(DataSet)</returns>
		public DataSet GetParentDeptDataSet()
		{
			return dba.GetDataSet("select DeptID,DeptName from Dept_Info where DeptLevelID<5 and DeptLevelID>0");
		}
		#endregion

		#region ��ȡ ��������(DataSet)
		public DataSet GetClassDataSet()
		{
			return dba.GetDataSet("select ID,ClassName from InfoClass");
		}
		#endregion


		#region [ ��ȡ������Ϣ ]

		public DataSet GetDeptDataSet()
		{
			return dbAcess.GetDataSet("KJ128N_Dept_Info_Select_TreeView", new SqlParameter[0]);
		}

		#endregion

		#endregion

		#region ְ��

		#region ����SQL��䣬����ְ����Ϣ(DataTable)
		/// <summary>
		/// ����SQL��䣬����ְ����Ϣ(DataTable)
		/// </summary>
		/// <param name="sql">SQL���</param>
		/// <returns>����ְ����Ϣ(DataTable)</returns>
		public DataTable GetDataTableDuty(string sql)
		{

			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					DataColumn dc = new DataColumn("ְ��ȼ�");
					dt.Columns.Add(dc);
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						string strSql = "select Title from EnumTable where FunID=4 and EnumID=" + dt.Rows[j][2].ToString();
						dt.Rows[j]["ְ��ȼ�"] = GetString(strSql);

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

		#region ��� ְ����Ϣ
		/// <summary>
		/// ���ְ����Ϣ
		/// </summary>
		/// <param name="DutyName">ְ������</param>
		/// <param name="DutyClassID">ְ��ȼ�</param>
		/// <param name="DuptRemark"><��ע/param>
		/// <returns>����Ӱ������</returns>
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

		#region �޸� ְ����Ϣ
		/// <summary>
		/// �޸�ְ����Ϣ
		/// </summary>
		/// <param name="DutyID">ְ��ID</param>
		/// <param name="DutyName">ְ������</param>
		/// <param name="DutyClassID">ְ��ȼ�</param>
		/// <param name="DutyRemark">��ע</param>
		/// <returns>����Ӱ������</returns>
		public int UpDateDutyInfo(int DutyID, string DutyName, int DutyClassID, string DutyRemark)
		{
			string UpDateString = string.Format("update Duty_Info set DutyName='{0}',DutyClassID={1},Remark='{2}' where DutyID={3}",
				DutyName, DutyClassID, DutyRemark, DutyID);
			return dba.ExecuteSql(UpDateString);
		}
		#endregion

		#region ɾ�� ְ����Ϣ
		/// <summary>
		/// ɾ��ְ����Ϣ
		/// </summary>
		/// <param name="DutyID">ְ��ID</param>
		/// <returns>����Ӱ������</returns>
		public int DeleteDuty(int DutyID)
		{
			string sqlString = string.Format("delete from Duty_Info where DutyID={0}", DutyID);
			return dba.ExecuteSql(sqlString);
		}
		#endregion

		#endregion

		#region ֤��

		#region ����SQL��䣬����֤����Ϣ(DataTable)
		/// <summary>
		/// ����SQL��䣬����֤����Ϣ(DataTable)
		/// </summary>
		/// <param name="sql">SQL���</param>
		/// <returns>����֤����Ϣ(DataTable)</returns>
		public DataTable GetDataTableCertificate(string sql)
		{

			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					DataColumn dc = new DataColumn("�Ƿ���֤����Ч��");
					dt.Columns.Add(dc);
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						int i;
						i = Convert.ToInt32(dt.Rows[j][3]);

						if (i == 0)
						{
							dt.Rows[j]["�Ƿ���֤����Ч��"] = "�����";
						}
						else
						{
							dt.Rows[j]["�Ƿ���֤����Ч��"] = "���";
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

		#region ��� ֤����Ϣ
		/// <summary>
		/// ���֤����Ϣ
		/// </summary>
		/// <param name="CerName">֤������</param>
		/// <param name="CerVestIn">��֤��λ</param>
		/// <param name="IsCheckExpDate">�Ƿ���֤����Ч��</param>
		/// <param name="CertificateRemark">��ע</param>
		/// <returns>Ӱ������</returns>
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

		#region �޸� ֤����Ϣ
		/// <summary>
		/// �޸�֤����Ϣ
		/// </summary>
		/// <param name="CerTypeID">֤��ID</param>
		/// <param name="CerName">֤������</param>
		/// <param name="CerVestIn">��֤��λ</param>
		/// <param name="IsCheckExpDate">�Ƿ���֤����Ч��</param>
		/// <param name="CertificateRemark">��ע</param>
		/// <returns>����Ӱ������</returns>
		public int UpDateCertificate(int CerTypeID, string CerName, string CerVestIn, int IsCheckExpDate, string CertificateRemark)
		{
			string UpDateString = string.Format("update Certificate_Info set CerName='{0}',CerVestIn='{1}',IsCheckExpDate={2},Remark='{3}' where CerTypeID={4}",
				CerName, CerVestIn, IsCheckExpDate, CertificateRemark, CerTypeID);
			return dba.ExecuteSql(UpDateString);
		}
		#endregion

		#region ɾ�� ֤����Ϣ
		/// <summary>
		/// ɾ��֤����Ϣ
		/// </summary>
		/// <param name="CerTypeID">֤��ID</param>
		/// <returns>����Ӱ������</returns>
		public int DeleteCertificate(int CerTypeID)
		{
			string sqlString = string.Format("delete from Certificate_Info where CerTypeID={0}", CerTypeID);
			return dba.ExecuteSql(sqlString);
		}
		#endregion

		#endregion

		#region ����

		#region ����SQL��䣬���ع�����Ϣ(DataTable)
		/// <summary>
		/// ����SQL��䣬���ع�����Ϣ(DataTable)
		/// </summary>
		/// <param name="sql">SQL���</param>
		/// <returns>���ع�����Ϣ(DataTable)</returns>
		public DataTable GetDataTableWorkType(string sql)
		{
			using (DataSet ds = dba.GetDataSet(sql))
			{
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					DataColumn dcMax = new DataColumn("�����ʱ��");
					DataColumn dcMin = new DataColumn("��С����ʱ��");
					dt.Columns.Add(dcMax);
					dt.Columns.Add(dcMin);
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						string strMax, strMin;
						#region ���������ʱ��
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
							strMax = hourMax + "ʱ" + minuteMax + "��" + secondMax + "��";
						}
						dt.Rows[j]["�����ʱ��"] = strMax.ToString();
						#endregion
						#region ������С����ʱ��
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
							strMin = hourMin + "ʱ" + minuteMin + "��" + secondMin + "��";
						}
						dt.Rows[j]["��С����ʱ��"] = strMin.ToString();
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

		#region ������: ��� ������Ϣ ��

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

		#region ������: �޸� ������Ϣ ��

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

		#region ɾ�� ������Ϣ
		public int DeleteWork(int WorkTypeID)
		{
			string sqlString = string.Format("delete from WorkType_Info where WorkTypeID={0}", WorkTypeID);
			return dba.ExecuteSql(sqlString);
		}

		#endregion

		#region ��ȡ֤������
		public DataSet GetWorkCerDataSet()
		{
			return dba.GetDataSet("select * from Certificate_Info");
		}
		#endregion

		#endregion

		#region ִ��SQL��䣬����ִ�н�������Σ�
		/// <summary>
		/// ִ��SQL��䣬����ִ�н�������Σ�
		/// </summary>
		/// <param name="sql">SQL���</param>
		/// <returns>����ִ�н��(int)</returns>
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

		#region ִ��SQL��䣬����ִ�н����string��
		/// <summary>
		/// ִ��SQL��䣬����ִ�н�������Σ�
		/// </summary>
		/// <param name="sql">SQL���</param>
		/// <returns>����ִ�н��(string)</returns>
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

		#region ִ��SQL��䣬����ִ�н����Table��
		/// <summary>
		/// ִ��SQL��䣬����ִ�н����Table��
		/// </summary>
		/// <param name="sql">SQL���</param>
		/// <returns>����ִ�н��(Table)</returns>
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

		#region [ ����� ]

		#region ������Ϣ
		/// <summary>
		/// ������Ϣ
		/// </summary>
		/// <returns></returns>
		public DataSet getDept()
		{
			return dba.GetDataSet("select DeptID, DeptNo,DeptName from Dept_Info order by DeptName");
		}

		#endregion

		#region �豸״̬
		/// <summary>
		/// �豸״̬
		/// </summary>
		/// <returns></returns>
		public DataSet getEquStation()
		{
			return dba.GetDataSet("select EnumID,Title from EnumTable where FunID = 10");
		}
		#endregion

		#endregion

		#region [ ���Ʒ� ]
		#region ���ݲ�����ˮ�õ�ʱ����Ϣ
		public DataSet GetClassInfo(int intDeptId, out string strErrMsg)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@intDept", SqlDbType.Int)};
			parameters[0].Value = intDeptId;
			return DB.RunProcedureByDataSet("Shine_Departments_GetClassInfoByDeptID", "ds", parameters, out strErrMsg);
		}
		#endregion

		#region ��ѯ���Ź�ʱ������Ϣ
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

		#region ��Ӳ��Ź�ʱ������Ϣ
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

		#region �޸Ĳ��Ź�ʱ������Ϣ
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

		#region ɾ�����Ź�ʱ������Ϣ
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

		#region [ �޸� ]

		#region [ ����: KJ128N_AllDept ]

		public DataSet GetKJ128NAllDept(int tempDept_ID)
		{
			string strsql = "select * from KJ128N_AllDept where DeptID=" + tempDept_ID;
			return dba.GetDataSet(strsql);
		}

		#endregion

		#region [ ����: ���ݲ���DeptID��ȡ������Ϣ ]

		public DataSet GetIDDeptInfo(string strDeptID)
		{
			string strTempSql = "select * from KJ128N_AllDept where DeptID=" + strDeptID;
			return dba.GetDataSet(strTempSql);
		}

		#endregion

		#region [ ����: ����EmpID�õ���Ա��Ϣ ]

		public DataSet GetEmpIDEmpInfo(string empID)
		{
			string strTempSql = "select * from Emp_Info where EmpID=" + empID;
			return dba.GetDataSet(strTempSql);
		}

		#endregion

		#region [ ����: ��֤���ű��Ψһ�� ]

		public DataSet GetIDDeptID(string deptID)
		{
			string sqlString = string.Format("select * from KJ128N_Dept_Info_Table where ���ű��='{0}'", deptID);
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region [ ����: ��֤�����쵼 ]

		public DataSet GetEmpNameEmpInfo(string empName)
		{
			string sqlString = string.Format("select * from Emp_Info where EmpName='{0}'", empName);
			return dba.GetDataSet(sqlString);
		}

		#endregion


		#region [ ����: ��֤�����쵼 ]

		public DataSet GetDutyInfoTable(string empName)
		{
			string sqlString = string.Format("select * from KJ128N_Duty_Info_Table where ְ������='{0}'", empName);
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region [ ����: KJ128N_Duty_Info_Table ]

		public DataSet GetIDDutyInfoTable(int tempDuty_ID)
		{
			string sqlString = "select * from KJ128N_Duty_Info_Table where DutyID=" + tempDuty_ID;
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region [ ����: KJ128N_Duty_Info_Table ]

		public DataSet GetIDWorkTypeInfoTable(int tempWork_ID)
		{
			string sqlString = "select * from KJ128N_WorkType_Info_Table where ���ֱ��=" + tempWork_ID;
			return dba.GetDataSet(sqlString);
		}

		#endregion

		#region [ ����: KJ128N_Duty_Info_Table ]

		public DataSet GetNameWorkTypeInfoTable(string WtName)
		{
			string sqlString = string.Format("select * from KJ128N_WorkType_Info_Table where ��������='{0}'", WtName);
			return dba.GetDataSet(sqlString);
		}

		#endregion


		#region [ ����: ���ְ��ȼ� ]

		public DataSet GetDutyGrade()
		{
			string sqlString = "select Title from EnumTable where FunID=4";
			return dba.GetDataSet(sqlString);

		}

		#endregion

		#region [ ����: ���֤����Ϣ ]

		public DataSet GetCertificateInfo(int tempCer_ID)
		{
			string sqlString = "select * from KJ128N_Certificate_Info_Table where ֤�����=" + tempCer_ID;
			return dba.GetDataSet(sqlString);
		}

		#endregion

		//strsql = "select * from KJ128N_Certificate_Info_Table where ֤�����=" + tempCer_ID;
		#endregion

		#region ��Czlt-2011-06-14 �쵼�����ѯ��
		public DataSet CzltGetDutyClassInfo()
		{
			return dba.GetDataSet("select EnumID,Title from EnumTable where FunID=4 and EnumValue =1 order by EnumID");
		}
		#endregion

		#region ��Czlt-2012-05-21 ��ѯ�Ӳ������ơ�
		/// <summary>
		/// Czlt-2012-5-21��ѯ��������
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

