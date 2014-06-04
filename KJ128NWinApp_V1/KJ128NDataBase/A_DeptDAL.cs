using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_DeptDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private string strSQL;

        #endregion

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
                            using (DataSet dsTemp = dba.GetDataSet(strTempSql))
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

        public int SaveDeptInfo(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName,string remark,int ClassID,
             string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail,
            int MaxTimeSec, int MinTimeSec, string  EmpName, string LeadDateTime, float flUnitPrice, int intSerialNO)
        {
            SqlParameter[] sqlParmeters ={
                new SqlParameter("ID",SqlDbType.Int),
                new SqlParameter("ParentDeptID",SqlDbType.Int),
                new SqlParameter("DeptLevelID",SqlDbType.Int),
                new SqlParameter("DeptNO",SqlDbType.NVarChar,20),
                new SqlParameter("DeptName",SqlDbType.NVarChar,20),
                new SqlParameter("ClassID",SqlDbType.Int),
                new SqlParameter("SerialNO",SqlDbType.Int),
                new SqlParameter("MaxTimeSec",SqlDbType.Int),
                new SqlParameter("MinTimeSec",SqlDbType.Int),
                new SqlParameter("Remark",SqlDbType.NVarChar,200),
                new SqlParameter("DeptTel1",SqlDbType.NVarChar,20),
                new SqlParameter("DeptTel2",SqlDbType.NVarChar,20),
                new SqlParameter("DeptFax",SqlDbType.NVarChar,20),
                new SqlParameter("DeptPost",SqlDbType.NVarChar,6),
                new SqlParameter("DeptAddress",SqlDbType.NVarChar,250),
                new SqlParameter("DeptEmail",SqlDbType.NVarChar,100),
                new SqlParameter("EmpName",SqlDbType.NVarChar,20),
                new SqlParameter("LeadDateTime",SqlDbType.DateTime),
                new SqlParameter("UnitPrice",SqlDbType.Float)
                                         };

            sqlParmeters[0].Value = DeptNO.GetHashCode();
            sqlParmeters[1].Value = ParentDeptID;
            sqlParmeters[2].Value = DeptLevelID;
            sqlParmeters[3].Value = DeptNO;
            sqlParmeters[4].Value = DeptName;
            sqlParmeters[5].Value = ClassID;
            sqlParmeters[6].Value = intSerialNO;
            sqlParmeters[7].Value = MaxTimeSec;
            sqlParmeters[8].Value = MinTimeSec;
            sqlParmeters[9].Value = remark;
            sqlParmeters[10].Value = DeptTel1;
            sqlParmeters[11].Value = DeptTel2;
            sqlParmeters[12].Value = DeptFax;
            sqlParmeters[13].Value = DeptPost;
            sqlParmeters[14].Value = DeptAddress;
            sqlParmeters[15].Value = DeptEmail;
            sqlParmeters[16].Value = EmpName;

            if (LeadDateTime.CompareTo("") == 0)
            {
                sqlParmeters[17].Value = DateTime.Parse("1800-01-01");
            }
            else
            {
                sqlParmeters[17].Value = DateTime.Parse(LeadDateTime);
            }
            sqlParmeters[18].Value = flUnitPrice;

            return dba.ExecuteSql("A_zjw_DeptInfo_Insert", sqlParmeters);
        }

        #endregion

        #region 【方法: 修改部门信息】

        public int UpDateDeptInfo(int ParentDeptID, int DeptLevelID, string DeptNO, string DeptName, string Remark, int ClassID,
             string DeptTel1, string DeptTel2, string DeptFax, string DeptPost, string DeptAddress, string DeptEmail,
            int MaxTimeSec, int MinTimeSec, string EmpName, string LeadDateTime, float flUnitPrice, int intDeptID, int intSerialNO)
        {
            SqlParameter[] sqlParmeters ={
                new SqlParameter("ParentDeptID",SqlDbType.Int),
                new SqlParameter("DeptLevelID",SqlDbType.Int),
                new SqlParameter("DeptNO",SqlDbType.NVarChar,20),
                new SqlParameter("DeptName",SqlDbType.NVarChar,20),
                new SqlParameter("Remark",SqlDbType.NVarChar,200),
                new SqlParameter("ClassID",SqlDbType.Int),
                new SqlParameter("MaxTimeSec",SqlDbType.Int),
                new SqlParameter("MinTimeSec",SqlDbType.Int),
                new SqlParameter("DeptTel1",SqlDbType.NVarChar,20),
                new SqlParameter("DeptTel2",SqlDbType.NVarChar,20),
                new SqlParameter("DeptFax",SqlDbType.NVarChar,20),
                new SqlParameter("DeptPost",SqlDbType.NVarChar,6),
                new SqlParameter("DeptAddress",SqlDbType.NVarChar,250),
                new SqlParameter("DeptEmail",SqlDbType.NVarChar,100),
                new SqlParameter("EmpName",SqlDbType.NVarChar,50),
                new SqlParameter("LeadDateTime",SqlDbType.DateTime),
                new SqlParameter("UnitPrice",SqlDbType.Float),
                new SqlParameter("DeptID",SqlDbType.Int),
                new SqlParameter("SerialNO",SqlDbType.Int)
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
            sqlParmeters[14].Value = EmpName;
            if (LeadDateTime.CompareTo("") == 0)
            {
                sqlParmeters[15].Value = DateTime.Parse("1800-01-01");
            }
            else
            {
                sqlParmeters[15].Value = DateTime.Parse(LeadDateTime);
            }
            sqlParmeters[16].Value = flUnitPrice;
            sqlParmeters[17].Value = intDeptID;
            sqlParmeters[18].Value = intSerialNO;

            return dba.ExecuteSql("A_zjw_DeptInfo_UpDate", sqlParmeters);
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
            return dba.GetDataSet("select DeptID,DeptName from Dept_Info where DeptLevelID<=5 and DeptLevelID>=0");
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
            return dba.GetDataSet("KJ128N_Dept_Info_Select_TreeView", new SqlParameter[0]);
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
                                    " insert into Duty_Info(DutyID,DutyName,DutyClassID,Remark) " +
                                    " Values("+DutyName.GetHashCode()+", '" + DutyName + "' , " + DutyClassID + ", '" + DuptRemark + "' )" +
                                " End ";
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
        /// <param name="CertificateRemark">备注</param>
        /// <returns>影响行数</returns>
        public int SaveCertificateData(string CerName, string CerVestIn, string CertificateRemark)
        {
            string SaveString = " If( not exists ( Select 1 From Certificate_Info Where CerName='" + CerName + "')) " +
                                " Begin " +
                                    " insert into Certificate_Info(CerTypeID,CerName,CerVestIn,Remark) " +
                                    " Values(" + CerName.GetHashCode() + ", '" + CerName + "' , '" + CerVestIn + "' , '" + CertificateRemark + "')" +
                                " End ";

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
        /// <param name="CertificateRemark">备注</param>
        /// <returns>返回影响行数</returns>
        public int UpDateCertificate(int CerTypeID, string CerName, string CerVestIn, string CertificateRemark)
        {
            string UpDateString = string.Format("update Certificate_Info set CerName='{0}',CerVestIn='{1}',Remark='{2}' where CerTypeID={3}",
                CerName, CerVestIn, CertificateRemark, CerTypeID);
            return dba.ExecuteSql(UpDateString);
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
                new SqlParameter("@MinTimeSec",SqlDbType.Int),
                new SqlParameter("@ID",SqlDbType.Int)
            };
            sqlParmeters[0].Value = WtName;
            sqlParmeters[1].Value = CerTypeID;
            sqlParmeters[2].Value = WorkRemark;
            sqlParmeters[3].Value = MaxTimeSec;
            sqlParmeters[4].Value = MinTimeSec;
            sqlParmeters[5].Value = WtName.GetHashCode();

            return dba.ExecuteSql("zjw_WorkType_Insert", sqlParmeters);


        }

        #endregion

        #region 【方法: 修改 工种信息 】

        public int UpDateWorkType(string WtName, int CerTypeID, string WorkRemark,
            int MaxTimeSec, int MinTimeSec,int intWorkTypID)
        {
            SqlParameter[] sqlParmeters ={
                new SqlParameter("@WorkTypeID",SqlDbType.Int),
                new SqlParameter("@WtName",SqlDbType.NVarChar,50),
                new SqlParameter("@CerTypeID",SqlDbType.Int),
                new SqlParameter("@Remark",SqlDbType.NVarChar,50),
                new SqlParameter("@MaxTimeSec",SqlDbType.Int),
                new SqlParameter("@MinTimeSec",SqlDbType.Int)
            };
            sqlParmeters[0].Value = intWorkTypID;
            sqlParmeters[1].Value = WtName;
            sqlParmeters[2].Value = CerTypeID;
            sqlParmeters[3].Value = WorkRemark;
            sqlParmeters[4].Value = MaxTimeSec;
            sqlParmeters[5].Value = MinTimeSec;

            return dba.ExecuteSql("A_zjw_WorkType_Update", sqlParmeters);

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

        #region [ 修改 ]

        #region [ 方法: KJ128N_AllDept ]

        public DataSet GetKJ128NAllDept(int tempDept_ID)
        {
            string strsql = "SELECT di.DeptID, di.ParentDeptID, di.DeptNO,di.DeptName, di.Remark, di.MaxTimeSec,di.MinTimeSec, dd.EmpName, dd.LeadDateTime,dd.DeptTel1, dd.DeptTel2, dd.DeptFax,dd.DeptPost, dd.DeptAddress, dd.DeptEmail,di.ClassID,UnitPrice,SerialNO FROM Dept_Info di LEFT join Dept_Detail dd ON di.DeptID = dd.DeptID where di.DeptID=" + tempDept_ID;
            return dba.GetDataSet(strsql);
        }

        #endregion

        #region [ 方法: 根据部门DeptID获取部门信息 ]

        public DataSet GetIDDeptInfo(string strDeptID)
        {
            string strTempSql = "select * from Dept_Info where DeptID=" + strDeptID;
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

        public DataSet GetIDWorkTypeInfoTable(int tempWork_ID)
        {
            string sqlString = "select * from A_KJ128N_WorkType_Info_Table where WorkTypeID =" + tempWork_ID;
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

        #region【方法：获取部门信息——部门】

        public DataSet GetDept_Dept()
        {
            strSQL = " Select Dei.DeptID as ID, " +
                        " Dei.DeptName as Name , " +
                        " Dei.ParentDeptID as ParentID, " +
                        " 'true' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num  " +
                     " From Dept_Info as Dei " +
                     " Order By SerialNO ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region [ 方法: 查询部门信息 ]
        public DataSet SelectDeptInfo(string strWhere)
        {
            strSQL = " Select * From A_KJ128N_Dept_Info_Table Where" + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion


        #region 【方法: 删除 部门信息】

        public int DeleteDept(string strDeptID)
        {
            SqlParameter[] sqlParmeters ={
                new SqlParameter("strWhere",SqlDbType.VarChar,2000)
            };

            sqlParmeters[0].Value = strDeptID;

            return dba.ExecuteSql("A_zjw_DeptInfo_Delete", sqlParmeters);
        }

        #endregion


        #region【方法：获取职务信息——职务】

        public DataSet GetDuty_Duty()
        {
            strSQL = " Select Dut.DutyID as ID, " +
                            " Dut.DutyName as Name ," +
                            " 0 as ParentID, " +
                            " 'true' as IsChild , " +
                            " 'false' as IsUserNum , " +
                            " 0 as Num  " +
                     " From Duty_Info as Dut ";
            return dba.GetDataSet(strSQL);
        }

        #endregion


        #region 【方法: 查询职务信息】

        public DataSet SelectDutyInfo(string strWhere)
        {
            strSQL = " Select * From A_KJ128N_Duty_Info_Table Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion


        #region [ 方法: KJ128N_Duty_Info_Table ]

        public DataSet GetIDDutyInfoTable(int tempDuty_ID)
        {
            string sqlString = "select * from A_KJ128N_Duty_Info_Table where DutyID=" + tempDuty_ID;
            return dba.GetDataSet(sqlString);
        }

        #endregion

        #region 删除 职务信息
        /// <summary>
        /// 删除职务信息
        /// </summary>
        /// <param name="DutyID">职务ID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteDuty(string strDutyID)
        {
            SqlParameter[] sqlParmeters ={
                new SqlParameter("@strWhere",SqlDbType.VarChar,2000)
            };

            sqlParmeters[0].Value = strDutyID;

            return dba.ExecuteSql("A_zjw_DutyInfo_Delete", sqlParmeters);
        }
        #endregion

        #region【方法：获取工种信息——工种】

        public DataSet GetWorkType_WorkType()
        {
            strSQL = " Select Wt.WorkTypeID as ID, " +
                        " Wt.WtName as Name , " +
                        " 0 as ParentID, " +
                        " 'true' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num " +
                    " From WorkType_Info as Wt ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询工种信息】

        public DataSet SelectWorkTypeInfo(string strWhere)
        {
            strSQL = " Select * From A_KJ128N_WorkType_Info_Table Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 删除 工种信息
        public int DeleteWork(string strWorkTypeID)
        {
            strSQL = "update emp_info set worktypeid=0,worktypename=null where " + strWorkTypeID + ";delete from WorkType_Info where " + strWorkTypeID;
            return dba.ExecuteSql(strSQL);
        }

        #endregion

        #region【方法：获取证书信息——证书】

        public DataSet GetCer_Cer()
        {
            strSQL = " Select Ce.CerTypeID as ID, " +
                            " Ce.CerName as Name ," +
                            " 0 as ParentID, " +
                            " 'true' as IsChild , " +
                            " 'false' as IsUserNum , " +
                            " 0 as Num  " +
                     " From Certificate_Info as Ce ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询证书信息】

        public DataSet SelectCerInfo(string strWhere)
        {
            strSQL = " Select * From A_KJ128N_Cer_Info_Table Where " + strWhere;
            return dba.GetDataSet(strSQL);
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
            strSQL = "delete from Certificate_Info where " + strCerTypeID;
            return dba.ExecuteSql(strSQL);
        }
        #endregion

        #region【方法：验证证书名称不能重复】

        public DataSet GetNameCertificateInfoTable(string strCerName)
        {
            strSQL = " select * from Certificate_Info where CerName = '" + strCerName + "'";

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门ID和部门上级ID】

        public DataSet GetAllDeptIDAndParentDeptID()
        {
            strSQL = " select DeptID,ParentDeptID from Dept_Info ";

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
    }
}
