using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NDataBase;
using System.Windows.Forms;
using KJ128NInterfaceShow;
using System.Web.UI.WebControls;
namespace KJ128NDBTable
{
    public class DeptBLL
    {

        #region [ 丁静超 ]

        DeptDAL deptdal = new DeptDAL();

        #region 部门信息

        public DataSet GetDeptInfo()
        {
            return deptdal.GetDeptInfo();
        }

        #endregion

        #region 获得部门信息

        public DataSet GetDeptInfoAll()
        {
            return deptdal.GetDeptAll();
        }

        #endregion

        #region 部门所有信息

        public string GetDeptChildAll(DataSet ds, string tmpWhere, int deptID)
        {
            DataRow[] drArray = ds.Tables[0].Select("ParentDeptID=" + deptID.ToString());
            foreach (DataRow dr in drArray)
            {
                if (ds.Tables[0].Select("ParentDeptID=" + deptID.ToString()).GetUpperBound(0) + 1 > 0)
                {
                    tmpWhere = GetDeptChildAll(ds, tmpWhere, int.Parse(dr["DeptID"].ToString()));
                }
                tmpWhere += " or DeptID=" + dr["DeptID"].ToString();
            }
            return tmpWhere;
        }

        #endregion
        //GetDeptInfo()

        #region 职务信息绑定

        //职务名称绑定
        public ComboBox getDutyNameCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getDutyInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DutyName";
                cmb.ValueMember = "DutyID";

            }
            return cmb;
        }

        //职务等级绑定
        public ComboBox getDutyClassCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getDutyClassInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
            return cmb;
        }

        #endregion

        #region 工种绑定

        public ComboBox getWorkTypeCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getWorkTypeInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "WtName";
                cmb.ValueMember = "WorkTypeID";
            }
            return cmb;
        }

        #endregion

        #region 证书类别绑定

        public ComboBox getCerTypeCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getCerTypeInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "CerName";
                cmb.ValueMember = "CerTypeID";
            }
            return cmb;
        }

        #endregion

        #region 设备类型绑定

        public ComboBox getEquTYpeCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquTYpe();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
            return cmb;
        }

        #endregion

        #region 设备类型绑定

        public ComboBox getEquFactoryCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquFactory();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "FactoryName";
                cmb.ValueMember = "FactoryID";
            }
            return cmb;
        }

        #endregion
        #endregion

        #region [ 赵建伟 ]
        private DeptDAL ddal = new DeptDAL();

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

        public int SaveDeptInfo(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID,
             string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail,
            int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond,
            int EmpID, string LeadDateTime)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return ddal.SaveDeptInfo(ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark, ClassID, DeptTel1, DeptTel2, DeptFax, DeptPost,
                DeptAddress, DeptEmail, MaxTimeSec, MinTimeSec, EmpID, LeadDateTime);
        }

        #endregion

        #region 添加 部门基本信息
        /// <summary>
        /// 添加部门基本信息
        /// </summary>
        /// <param name="ParentDeptID">上级部门ID</param>
        /// <param name="DeptLevelID">部门等级</param>
        /// <param name="DeptNO">部门编号</param>
        /// <param name="DeptName">部门名称</param>
        /// <param name="Remark">备注</param>
        /// <returns>返回影响行数</returns>
        public int SaveDeptInfoData(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID)
        {
            return ddal.SaveDeptInfoData(ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark, ClassID);
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
        /// <param name="DeptPost">部门邮箱</param>
        /// <param name="DeptAddress">部门地址</param>
        /// <param name="DeptEmail">部门电子邮箱</param>
        /// <returns>返回影响行数</returns>
        public int SaveDeptDetailData(string DeptNO, string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail)
        {
            return ddal.SaveDeptDetailData(DeptNO, DeptTel1, DeptTel2, DeptFax, DeptPost, DeptAddress, DeptEmail);
        }
        #endregion
        #region 添加 部门设置
        /// <summary>
        /// 添加部门设置
        /// </summary>
        /// <param name="DeptID">部门ID</param>
        /// <param name="MaxHour">最大工作时间(时)</param>
        /// <param name="MaxMinute">最大工作时间(分)</param>
        /// <param name="MaxSecond">最大工作时间(秒)</param>
        /// <param name="MinHour">最小工作时间(时)</param>
        /// <param name="MinMinute">最小工作时间(分)</param>
        /// <param name="MinSecond">最小工作时间(秒)</param>
        /// <returns>返回影响行数</returns>
        public int SaveDeptSysSetData(string DeptNO, int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return ddal.SaveDeptSysSetData(DeptNO, MaxTimeSec, MinTimeSec);
        }
        #endregion
        #region 添加 部门领导
        /// <summary>
        /// 添加 部门领导
        /// </summary>
        /// <param name="DeptID">部门ID</param>
        /// <param name="EmpID">领导ID</param>
        /// <param name="LeadDateTime">领导上任时间</param>
        /// <returns>返回影响行数(int)</returns>
        public int SaveDeptLeadData(string DeptNO, int EmpID, string LeadDateTime)
        {
            return ddal.SaveDeptLeadData(DeptNO, EmpID, LeadDateTime);
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
            return ddal.UpDateDeptInfoData(DeptID, ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark, ClassID);
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
            return ddal.UpDateDeptDetailData(DeptID, DeptTel1, DeptTel2, DeptFax, DeptPost, DeptAddress, DeptEmail);
        }
        #endregion
        #region 修改 部门设置
        /// <summary>
        /// 修改部门设置
        /// </summary>
        /// <param name="DeptID">部门ID</param>
        /// <param name="MaxHour">最大工作时间(时)</param>
        /// <param name="MaxMinute">最大工作时间(分)</param>
        /// <param name="MaxSecond">最大工作时间(秒)</param>
        /// <param name="MinHour">最小工作时间(时)</param>
        /// <param name="MinMinute">最小工作时间(分)</param>
        /// <param name="MinSecond">最小工作时间(秒)</param>
        /// <returns>返回影响行数</returns>
        public int UpDateDeptSysSetData(int DeptID, int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;
            return ddal.UpDateDeptSysSetData(DeptID, MaxTimeSec, MinTimeSec);
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
            return ddal.UpDateDeptLeadData(DeptNO, EmpID, LeadDateTime);
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
        #region 删除 职务信息
        /// <summary>
        /// 删除 职务信息
        /// </summary>
        /// <param name="DutyID">职务ID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteDuty(int DutyID)
        {
            return ddal.DeleteDuty(DutyID);
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
        #region 添加 证书信息
        /// <summary>
        /// 添加证书信息
        /// </summary>
        /// <param name="CerName">证书名称</param>
        /// <param name="CerVestIn">发证单位</param>
        /// <param name="IsCheckExpDate">是否检查证书有效期</param>
        /// <param name="CertificateRemark">备注</param>
        /// <returns>返回影响行数</returns>
        public int SaveCertificateData(string CerName, string CerVestIn, int IsCheckExpDate, string CertificateRemark)
        {
            return ddal.SaveCertificateData(CerName, CerVestIn, IsCheckExpDate, CertificateRemark);
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
            return ddal.UpDateCertificate(CerTypeID, CerName, CerVestIn, IsCheckExpDate, CertificateRemark);
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
            return ddal.DeleteCertificate(CerTypeID);
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
            int MaxHour, int MaxMinute, int MaxSecond, int MinHour, int MinMinute, int MinSecond)
        {
            int MaxTimeSec, MinTimeSec;
            MaxTimeSec = MaxHour * 3600 + MaxMinute * 60 + MaxSecond;
            MinTimeSec = MinHour * 3600 + MinMinute * 60 + MinSecond;

            return ddal.UpDateWorkType(WtName, CerTypeID, WorkRemark, MaxTimeSec, MinTimeSec);
        }

        #endregion

        #region 删除 工种信息
        /// <summary>
        /// 删除工种信息
        /// </summary>
        /// <param name="WorkTypeID">工种ID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteWork(int WorkTypeID)
        {
            return ddal.DeleteWork(WorkTypeID);
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

        #region [ 易晓岚 ]

        #region 绑定设备类型（添加时使用）
        /// <summary>
        /// 绑定设备类型（添加时使用）
        /// </summary>
        /// <param name="cmb">控件</param>
        public void getEquType(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquTYpe();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                //DataRow dr = ds.Tables[0].NewRow();
                //dr[0] = 0;
                //dr[1] = "无";
                //ds.Tables[0].Rows.InsertAt(dr,0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
        }
        #endregion 

        #region 绑定生产厂家
        /// <summary>
        /// 绑定生产厂家
        /// </summary>
        /// <param name="cmb"></param>
        public void getFactory(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquFactory();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                //DataRow dr = ds.Tables[0].NewRow();
                //dr[0] = 0;
                //dr[1] = "无";
                //ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "FactoryName";
                cmb.ValueMember = "FactoryID";
            }
        }
        #endregion 

        #region 绑定部门
        /// <summary>
        ///  绑定部门
        /// </summary>
        /// <param name="cmb">控件名</param>
        public void getDept(ComboBox cmb)
        {
            DataSet ds = deptdal.getDept();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //cmb.Items.Clear();
                //DataRow dr = ds.Tables[0].NewRow();
                //dr[0] = 0;
                //dr[1] = "无";
                //ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DeptName";
                cmb.ValueMember = "DeptID";
            }
        }

        //添加‘所有’元素的部门绑定
        public void getDeptAddAll(ComboBox cmb)
        {
            DataSet ds = deptdal.getDept();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[2] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DeptName";
                cmb.ValueMember = "DeptID";
               
            }
        }

        //添加‘所有’元素的部门绑定
        public void getDeptAddAll1(ComboBox cmb)
        {
            DataSet ds = deptdal.getDept();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                //cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[2] = "选择";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "DeptName";
                cmb.ValueMember = "DeptID";

            }
        }
        #endregion 

        #region 绑定设备状态
        /// <summary>
        /// 绑定设备状态
        /// </summary>
        /// <param name="cmb">控件名</param>
        public void getEquState(ComboBox cmb)
        {
            DataSet ds = deptdal.getEquStation();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                //DataRow dr = ds.Tables[0].NewRow();
                //dr[0] = 0;
                //dr[1] = "无";
                //ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
        }
        #endregion 

        #endregion 

        #region [ 与Web控件相关 ]

        #region 绑定部门信息到ListBox（Web控件）
        public void BindDetpLB(System.Web.UI.WebControls.ListBox lb)
        {
            DataSet ds = deptdal.getDept();

            if (ds != null)
            {
                lb.DataSource = ds;
                lb.DataTextField = "DeptName";
                lb.DataValueField = "DeptID";
                lb.DataBind();

                lb.Items.Insert(0, new ListItem("所有部门", "0"));
            }
        }
        #endregion

        #region 绑定部门信息到DropDownList（Web控件）
        public void BindDetpDDL(System.Web.UI.WebControls.DropDownList ddl)
        {
            DataSet ds = deptdal.getDept();

            if (ds != null)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = "DeptName";
                ddl.DataValueField = "DeptID";
                ddl.DataBind();

                ddl.Items.Insert(0, new ListItem("所有部门", "0"));
            }
        }
        #endregion

        #region 根据部门流水得到时段信息
        public DataSet GetClassInfo(int intDeptId, out string strErrMsg)
        {
            return deptdal.GetClassInfo(intDeptId, out strErrMsg);
        }
        #endregion

        #region 查询部门工时单价信息
        public DataSet GetUnitPriceInfo(string strWhere, out string strErr)
        {
            return deptdal.GetUnitPriceInfo(strWhere, out strErr);
        }
        #endregion

        #region 添加部门工时单价信息
        public int InsertUnitPriceInfo(int intDeptID, float fUnitPrice, string strRemark, out string strErr)
        {
            return deptdal.InsertUnitPriceInfo(intDeptID, fUnitPrice, strRemark, out strErr);
        }
        #endregion

        #region 修改部门工时单价信息
        public int UpdateUnitPriceInfo(int intDeptID, float fUnitPrice, string strRemark, out string strErr)
        {
            return deptdal.UpdateUnitPriceInfo(intDeptID, fUnitPrice, strRemark, out strErr);
        }
        #endregion

        #region 删除部门工时单价信息
        public int DeleteUnitPriceInfo(int intDeptID, out string strErr)
        {
            return deptdal.DeleteUnitPriceInfo(intDeptID, out strErr);
        }
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
            return deptdal.GetEmpIDEmpInfo(empID);
        }

        #endregion

        #region [ 方法: 验证部门编号唯一性 ]

        public DataSet GetIDDeptID(string deptID)
        {
            return deptdal.GetIDDeptID(deptID);
        }

        #endregion

        #region [ 方法: 返回职务信息 ]

        public DataSet GetDutyInfoTable(string empName)
        {
            return deptdal.GetDutyInfoTable(empName);
        }

        #endregion

        #region [ 方法: 验证部门领导 ]

        public DataSet GetEmpNameEmpInfo(string empName)
        {
            return deptdal.GetEmpNameEmpInfo(empName);
        }

        #endregion

        #region [ 方法: KJ128N_Duty_Info_Table ]

        public DataSet GetIDDutyInfoTable(int tempDuty_ID)
        {
            return deptdal.GetIDDutyInfoTable(tempDuty_ID) ;
        }

        #endregion

        #region [ 方法: KJ128N_Duty_Info_Table ]

        public DataSet GetIDWorkTypeInfoTable(int tempWork_ID)
        {
            return deptdal.GetIDWorkTypeInfoTable(tempWork_ID) ;
        }

        #endregion

        #region [ 方法: KJ128N_Duty_Info_Table ]

        public DataSet GetNameWorkTypeInfoTable(string WtName)
        {
            return deptdal.GetNameWorkTypeInfoTable(WtName);
        }

        #endregion

        #region [ 方法: 获得职务等级 ]

        public DataSet GetDutyGrade()
        {
            return deptdal.GetDutyGrade() ;

        }

        #endregion

        #region [ 方法: 获得证书信息 ]

        public DataSet GetCertificateInfo(int tempCer_ID)
        {
            return deptdal.GetCertificateInfo(tempCer_ID);
        }

        #endregion

        #endregion

        #region 【Czlt-2011-06-14 领导干部等级查询】

        public ComboBox CzltGetDutyClassCmb(ComboBox cmb)
        {
            DataSet ds = deptdal.CzltGetDutyClassInfo();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                cmb.Items.Clear();
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "所有";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Title";
                cmb.ValueMember = "EnumID";
            }
            return cmb;
        }
        #endregion

        #region 【Czlt-2012-05-17】
        /// <summary>
        /// Czlt-2012-5-21 根据部门名称查找所有子部门
        /// </summary>
        /// <param name="isName">是否返回名称</param>
        /// <param name="strDeptName">父部门名称</param>
        /// <returns></returns>
        public string GetValueOrId(bool isName,string strDeptName)
        {
            string strValue = string.Empty;
            string strSql = "select deptId,deptname from dept_info where ParentDeptID=(select deptId from Dept_info where deptName='" + strDeptName + "') or deptName='" + strDeptName + "'";
            DataTable dt = deptdal.GetDeptId(strSql);
            if (dt != null || dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (isName)
                    {
                        strValue += dr[1].ToString()+"','";
                    }
                    else
                    {
                        strValue += dr[0].ToString()+"','";
                    }
                }
               
            }
            if (strValue.Length > 0)
                strValue = strValue.Substring(0, strValue.Length - 3);
            return strValue;
        }

        /// <summary>
        /// Czlt-2012-5-17 更加ID查询
        /// </summary>
        /// <param name="isName"></param>
        /// <param name="strDeptName"></param>
        /// <returns></returns>
        public string GetValueOrIdByID(bool isName, string strDeptName)
        {
            string strValue = string.Empty;
            string strSql = "select deptId,deptname from dept_info where ParentDeptID='" + strDeptName + "' or deptID='" + strDeptName + "'";
            DataTable dt = deptdal.GetDeptId(strSql);
            if (dt != null || dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (isName)
                    {
                        strValue += dr[1].ToString() + "','";
                    }
                    else
                    {
                        strValue += dr[0].ToString() + "','";
                    }
                }

            }
            if (strValue.Length > 0)
                strValue = strValue.Substring(0, strValue.Length - 3);
            return strValue;
        }
        #endregion

    }
}
