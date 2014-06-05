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
	public class A_AddEmpBLL
	{
		#region [ 声明 ]

		private A_AddEmpDAL aedal = new A_AddEmpDAL();
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
			if (aedal == null)
				aedal = new A_AddEmpDAL();

			return aedal.InsertEmpInfo(empModel);
		}

		/// <summary>
		/// 修改员工信息(全部10张表信息)
		/// </summary>
		/// <param name="empModel">员工类实体</param>
		/// <returns>返回执行影响行数，大于0就执行成功</returns>
		public int UpdateEmpInfo(EmpModel empModel, int intEmpID)
		{
			if (aedal == null)
				aedal = new A_AddEmpDAL();

			return aedal.UpdateEmpInfo(empModel, intEmpID);
		}

		#endregion

		#region 【 方法: 添加 员工信息 】

		public int SaveEmpInfo()
		{

			return 0;
		}

		#endregion

		#region  [ 方法: 根据PhotoID，返回DataTable ]

		public DataTable GetPhotoTab(int PhotoID)
		{
			return aedal.GetPhotoTab(PhotoID);
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

		public DataSet GetEmployeeInfo(int pageIndex, int pageSize, string where)
		{
			return aedal.GetEmployeeInfo(pageIndex, pageSize, where);
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
				//cmb.Items.Clear();
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
			string strsql = string.Format("select  DeptID,DeptName,MaxTimeSec ,MinTimeSec  from Dept_Info where DeptID={0}", DeptID);
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

		#region [ 方法: 获取员工班次设置Table ]
		public DataTable GetEmpClassByID(int EmpID)
		{
			string strsql = string.Format(
						  "SELECT  ic.ID ,											"
						+ "        ic.ClassName										"
						+ "FROM    dbo.Emp_Info ei									"
						+ "        LEFT JOIN dbo.InfoClass ic ON ic.ID = ei.ClassID	"
						+ "WHERE ei.EmpID = '{0}'										"
				, EmpID);
			return ddal.GetTable(strsql);
		}

		public DataTable GetClass()
		{
			string strsql = "SELECT ID,ClassName FROM dbo.InfoClass";
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
							strNewSql = "(" + strTest[i, 0].Trim() + " " + strTest[i, 1].Trim() + " " + strTest[i, 2].Trim() + ") and IsEnable=1";
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
			string strsql = string.Format("select WtName from WorkType_Info where WorkTypeID={0}", WorkTypeID);
			return ddal.GetString(strsql);
		}
		#endregion

		#region [ 方法: 人员信息 ]
		public DataSet GetEmpInfo(int pageIndex, int pageSize, string where)
		{
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
		public int DeleteEmp(string strEmpID, string strUserID)
		{
			return aedal.DeleteEmp(strEmpID, strUserID);
		}
		#endregion

		#region [ 方法: 绑定 职务并判断(comboBox) ]

		public void GetDutyNameCmb(ComboBox cmb, bool bl)
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

		#region [ 方法: 绑定 班制名称(comboBox) xxh 2014-6-5 界沟]
		public void GetEmpClassCmb(ComboBox cmb)
		{
			DataTable dt = GetClass();
			if (dt != null)
			{
				cmb.DataSource = null;
				DataRow dr = dt.NewRow();
				dr[0] = 0;
				dr[1] = "无";
				dt.Rows.InsertAt(dr, 0);
				cmb.DataSource = dt;
				cmb.DisplayMember = "ClassName";
				cmb.ValueMember = "ID";
				cmb.SelectedValue = 0;
			}
		}

		public void UpdateClass(bool isClassEnabled)
		{
			if (isClassEnabled)
			{
				aedal.ExecuteSql("UPDATE dbo.Emp_Info SET IsClassEnabled = 1");
			}
			else
			{
				aedal.ExecuteSql("UPDATE dbo.Emp_Info SET IsClassEnabled = 0");
			}
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

		public bool IsEmpName(string strEmpName)
		{
			using (ds = new DataSet())
			{
				ds = aedal.IsEmpName(strEmpName);
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					if (dt.Rows.Count >= 1)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool IsEmpName(string strEmpName, string strEmpNo)
		{
			using (ds = new DataSet())
			{
				ds = aedal.IsEmpName(strEmpName, strEmpNo);
				if (ds != null)
				{
					DataTable dt = ds.Tables[0];
					if (dt.Rows.Count >= 1)
					{
						return true;
					}
				}
			}
			return false;
		}

		#region【方法：获取部门信息——员工】

		public DataSet GetDept_Emp()
		{
			return aedal.GetDept_Emp();
		}

		#endregion

		#region【方法：获取职务信息——员工】

		public DataSet GetDuty_Emp()
		{
			return aedal.GetDuty_Emp();
		}

		#endregion

		#region【方法：获取工种信息——员工】

		public DataSet GetWorkType_Emp()
		{
			return aedal.GetWorkType_Emp();
		}

		#endregion

		#region【方法：Czlt-2011-12-10 修改时间】

		public void UpdateTime()
		{
			aedal.UpdateTime();
		}
		#endregion
	}
}
