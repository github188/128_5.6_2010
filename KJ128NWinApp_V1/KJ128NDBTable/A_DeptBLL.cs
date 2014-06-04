using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;
using KJ128NInterfaceShow;

namespace KJ128NDBTable
{
    public class A_DeptBLL
    {

        private A_DeptDAL ddal = new A_DeptDAL();

        #region [ 赵建伟 ]


        #region 部门
        #region 根据SQL语句，返回部门信息(DataTable)
        /// <summary>
        /// 根据SQL语句，返回部门信息(DataTable)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回部门信息(DataTable)</returns>
        public DataTable GetDataTableDept(string sql)
        {
            return ddal.GetDataTableDept(sql);
        }
        #endregion

        #region [ 方法: 增加部门信息 ]

        public int SaveDeptInfo(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName,int ClassID,string remark,
             string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail,
            int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond,
            string EmpName, string LeadDateTime, float flUnitPrice, int intSerialNO)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return ddal.SaveDeptInfo(ParentDeptID, DeptLevelID, DeptNO, DeptName,remark,ClassID, DeptTel1, DeptTel2, DeptFax, DeptPost,
                DeptAddress, DeptEmail, MaxTimeSec, MinTimeSec, EmpName, LeadDateTime, flUnitPrice, intSerialNO);
        }

        #endregion

        #region【方法：修改部门信息】

        public int UpdateDeptInfo(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID,
            string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail,
            int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond,
            string EmpName, string LeadDateTime, float flUnitPrice, int intDeptID, int intSerialNO)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return ddal.UpDateDeptInfo(ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark, ClassID, DeptTel1, DeptTel2, DeptFax, DeptPost,
                DeptAddress, DeptEmail, MaxTimeSec, MinTimeSec, EmpName, LeadDateTime, flUnitPrice, intDeptID, intSerialNO);
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
            return ddal.DeleteDeptLead(DeptID);
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
            return ddal.DeleteDept(DeptID);
        }
        #endregion
        #region 获取部门级别
        /// <summary>
        /// 获取部门级别
        /// </summary>
        /// <param name="ParentDeptName">上级部门名称</param>
        /// <returns>部门级别</returns>
        public int GetDeptLevelID(int DeptID)
        {
            if (DeptID == 0)
            {
                return 1;
            }
            else
            {
                string sqlString = string.Format("select DeptLevelID from Dept_Info where DeptID={0}", DeptID);
                return ddal.GetID(sqlString) + 1;
            }
        }
        #endregion
        #region 获取部门ID
        /// <summary>
        /// 获取部门ID
        /// </summary>
        /// <param name="DeptNO">部门编号</param>
        /// <returns>部门ID</returns>
        public int GetDeptID(String DeptNO)
        {
            string sqlString = "select DeptID from KJ128N_Dept_Info_Table where 部门编号='" + DeptNO + "'";
            return ddal.GetID(sqlString);
        }
        #endregion
        #region 获取部门领导的ID
        /// <summary>
        /// 获取部门领导的ID
        /// </summary>
        /// <param name="DeptLeadName">部门领导的姓名</param>
        public int GetDeptLeadID(String DeptLeadName)
        {
            string sqlString = "select EmpID from Emp_Info where EmpName='" + DeptLeadName + "'";
            return ddal.GetID(sqlString);
        }
        #endregion
        #region 绑定上级部门
        public ComboBox GetParentDeptCmb(ComboBox cmb)
        {
            DataSet ds = ddal.GetParentDeptDataSet();
            if (ds!= null && ds.Tables.Count > 0)
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

            return cmb;
        }
        #endregion
        #region 绑定班制名称
        public ComboBox GetClassNameCmb(ComboBox cmb)
        {
            DataSet ds = ddal.GetClassDataSet();
            cmb.DataSource = null;
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmb.DataSource = ds.Tables[0];
                    cmb.DisplayMember = "ClassName";
                    cmb.ValueMember = "ID";
                    cmb.SelectedIndex = 0;
                }
            }
            return cmb;
        }
        #endregion

        #region [ 获取部门信息 ]

        public DataSet GetDeptDataSet()
        {
            return ddal.GetDeptDataSet();
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
            return ddal.GetDataTableDuty(sql);
        }
        #endregion
        #region 添加 职务信息
        /// <summary>
        /// 添加职务信息
        /// </summary>
        /// <param name="DutyName">职务名称</param>
        /// <param name="DutyClassID">职务等级</param>
        /// <param name="DuptRemark">备注</param>
        /// <returns>返回影响行数</returns>
        public int SaveDutyInfoData(string DutyName, int DutyClassID, string DuptRemark)
        {
            return ddal.SaveDutyInfoData(DutyName, DutyClassID, DuptRemark);
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
            return ddal.UpDateDutyInfo(DutyID, DutyName, DutyClassID, DutyRemark);
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
            return ddal.GetDataTableCertificate(sql);
        }
        #endregion

        #region 修改 证书信息
        /// <summary>
        /// 修改证书信息
        /// </summary>
        /// <param name="CerTypeID">证书ID</param>
        /// <param name="CerName">证书名称</param>
        /// <param name="CerVestIn">发证单位</param>
        /// <param name="CertificateRemark">备注</param>
        /// <returns>返回影响行数</returns>
        public int UpDateCertificate(int CerTypeID, string CerName, string CerVestIn, string CertificateRemark)
        {
            return ddal.UpDateCertificate(CerTypeID, CerName, CerVestIn,  CertificateRemark);
        }
        #endregion
        #region 删除 证书信息
        /// <summary>
        /// 删除证书信息
        /// </summary>
        /// <param name="CerTypeID">证书ID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteCertificate(string strCerTypeID)
        {
            return ddal.DeleteCertificate(strCerTypeID);
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
            return ddal.GetDataTableWorkType(sql);
        }
        #endregion
        #region 获取证书ID
        /// <summary>
        /// 获取证书ID
        /// </summary>
        /// <param name="CerName">证书名称</param>
        /// <returns>返回证书ID</returns>
        public int GetCerID(String CerName)
        {
            string strsql = string.Format("select CerTypeID from Certificate_Info where CerName='{0}'", CerName);
            return ddal.GetID(strsql);
        }
        #endregion
        #region 获取工种ID
        /// <summary>
        /// 获取工种ID
        /// </summary>
        /// <param name="WorkName">工种名称</param>
        /// <returns>返回工种ID</returns>
        public int GetWorkID(string WorkName)
        {
            string sqlString = "select WorkTypeID from WorkType_Info where WtName='" + WorkName + "'";
            return ddal.GetID(sqlString);
        }
        #endregion

        #region 【方法: 添加 工种信息 】

        public int SaveWorkData(string WtName, int CerTypeID, string WorkRemark,
            int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;

            return ddal.SaveWorkData(WtName, CerTypeID, WorkRemark, MaxTimeSec, MinTimeSec);
        }

        #endregion

        #region 【方法: 修改 工种信息 】

        public int UpDateWorkType(string WtName, int CerTypeID, string WorkRemark,
            int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond,int intWorkTypeID)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;

            return ddal.UpDateWorkType(WtName, CerTypeID, WorkRemark, MaxTimeSec, MinTimeSec,intWorkTypeID);
        }

        #endregion

        #region 删除 工种信息
        /// <summary>
        /// 删除工种信息
        /// </summary>
        /// <param name="WorkTypeID">工种ID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteWork(string strWorkTypeID)
        {
            return ddal.DeleteWork(strWorkTypeID);
        }
        #endregion
        
        #region 绑定工种(返回DataGridViewKJ128)
        /// <summary>
        /// 绑定工种(返回DataGridView)
        /// </summary>
        /// <returns>返回DataGridView</returns>
        public DataGridViewKJ128 GetWorkTypeDgv(DataGridViewKJ128 dgv)
        {
            string strSql = "select * from KJ128N_WorkType_Info_Table";
            DataTable dt = GetDataTableWorkType(strSql);
            //DataGridViewColumn dgvc1=new DataGridViewColumn();
            //DataGridViewColumn dgvc2=new DataGridViewColumn();
            dgv.DataSource = dt;
            dgv.ReadOnly = true;
            dgv.Columns[0].DisplayIndex = 11;
            dgv.Columns[1].DisplayIndex = 11;
            dgv.Columns[4].Visible = false;
            dgv.Columns[9].Visible = false;
            dgv.Columns[10].Visible = false;
            dgv.Columns[11].Visible = false;
            dgv.Columns[2].Visible = false;
            dgv.Columns[8].Visible = false;
            return dgv;
        }
        #endregion

        #endregion
        #endregion

        #region [ 修改 ]

        #region [ KJ128N_AllDept ]

        public DataSet GetKJ128NAllDept(int tempDept_ID)
        {
            return ddal.GetKJ128NAllDept(tempDept_ID);
        }

        #endregion

        #region [ 方法: 根据部门DeptID获取部门信息 ]

        public DataSet GetIDDeptInfo(string strDeptID)
        {
            return ddal.GetIDDeptInfo(strDeptID);
        }

        #endregion

        #region [ 方法: 根据EmpID得到人员信息 ]

        public DataSet GetEmpIDEmpInfo(string empID)
        {
            return ddal.GetEmpIDEmpInfo(empID);
        }

        #endregion

        #region [ 方法: 验证部门编号唯一性 ]

        public DataSet GetIDDeptID(string deptID)
        {
            return ddal.GetIDDeptID(deptID);
        }

        #endregion

        #region [ 方法: 返回职务信息 ]

        public DataSet GetDutyInfoTable(string empName)
        {
            return ddal.GetDutyInfoTable(empName);
        }

        #endregion

        #region [ 方法: 验证部门领导 ]

        public DataSet GetEmpNameEmpInfo(string empName)
        {
            return ddal.GetEmpNameEmpInfo(empName);
        }

        #endregion

        #region [ 方法: KJ128N_Duty_Info_Table ]

        public DataSet GetIDWorkTypeInfoTable(int tempWork_ID)
        {
            return ddal.GetIDWorkTypeInfoTable(tempWork_ID);
        }

        #endregion

        #region [ 方法: KJ128N_Duty_Info_Table ]

        public DataSet GetNameWorkTypeInfoTable(string WtName)
        {
            return ddal.GetNameWorkTypeInfoTable(WtName);
        }

        #endregion

        #region [ 方法: 获得职务等级 ]

        public DataSet GetDutyGrade()
        {
            return ddal.GetDutyGrade();

        }

        #endregion

        #region [ 方法: 获得证书信息 ]

        public DataSet GetCertificateInfo(int tempCer_ID)
        {
            return ddal.GetCertificateInfo(tempCer_ID);
        }

        #endregion

        #endregion

        #region【方法：获取部门信息——部门】

        public DataSet GetDept_Dept()
        {
            return ddal.GetDept_Dept();
        }
        
        #endregion

        #region 【方法: 查询部门信息】

        public DataSet SelectDeptInfo(string strWhere)
        {
            return ddal.SelectDeptInfo(strWhere);
        }

        #endregion


        #region 【方法: 删除 部门信息】
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="WorkTypeID">部门ID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteDept(string strDeptID)
        {
            return ddal.DeleteDept(strDeptID);
        }
        #endregion

        #region【方法：获取职务信息——职务】

        public DataSet GetDuty_Duty()
        {
            return ddal.GetDuty_Duty();
        }

        #endregion

        #region 【方法: 查询职务信息】

        public DataSet SelectDutyInfo(string strWhere)
        {
            return ddal.SelectDutyInfo(strWhere);
        }

        #endregion

        #region [ 方法: KJ128N_Duty_Info_Table ]

        public DataSet GetIDDutyInfoTable(int tempDuty_ID)
        {
            return ddal.GetIDDutyInfoTable(tempDuty_ID);
        }

        #endregion

        #region 删除 职务信息
        /// <summary>
        /// 删除 职务信息
        /// </summary>
        /// <param name="DutyID">职务ID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteDuty(string strDutyID)
        {
            return ddal.DeleteDuty(strDutyID);
        }
        #endregion

        #region 绑定 证书名称
        public ComboBox GetWorkCerCmb(ComboBox cmb)
        {
            DataSet ds = ddal.GetWorkCerDataSet();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = null;
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "CerName";
                cmb.ValueMember = "CerTypeID";
                cmb.SelectedIndex = 0;
            }
            return cmb;
        }
        #endregion

        #region【方法：获取工种信息——工种】

        public DataSet GetWorkType_WorkType()
        {
            return ddal.GetWorkType_WorkType();
        }

        #endregion

        #region 【方法: 查询工种信息】

        public DataSet SelectWorkTypeInfo(string strWhere)
        {
            return ddal.SelectWorkTypeInfo(strWhere);
        }

        #endregion

        #region【方法：获取证书信息——证书】

        public DataSet GetCer_Cer()
        {
            return ddal.GetCer_Cer();
        }

        #endregion

        #region 【方法: 查询证书信息】

        public DataSet SelectCerInfo(string strWhere)
        {
            return ddal.SelectCerInfo(strWhere);
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
        /// <returns>返回影响行数</returns>
        public int SaveCertificateData(string CerName, string CerVestIn, string CertificateRemark)
        {
            return ddal.SaveCertificateData(CerName, CerVestIn, CertificateRemark);
        }
        #endregion


        #region【方法：验证证书名称不能重复】

        public DataSet GetNameCertificateInfoTable(string strCerName)
        {
            return ddal.GetNameCertificateInfoTable(strCerName);
        }

        #endregion

        #region【方法：获取部门ID和部门上级ID】

        public DataSet GetAllDeptIDAndParentDeptID()
        {
            return ddal.GetAllDeptIDAndParentDeptID();
        }

        #endregion


        #region【方法：Czlt-2011-12-10 修改时间】

        public void UpdateTime()
        {
            ddal.UpdateTime();
        }
        #endregion

    }
}
