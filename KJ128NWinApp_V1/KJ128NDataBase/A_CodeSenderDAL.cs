using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_CodeSenderDAL
    {
        #region[申明]
        private DBAcess dba = new DBAcess();
        #endregion
        /// <summary>
        /// 返回部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDeptInfo()
        {
            string sqlstr = "select deptid,parentdeptid,deptname from Dept_Info order by SerialNO,deptname asc";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }
        /// <summary>
        /// 按指定的分页信息返回指定的标识卡配置信息
        /// </summary>
        /// <param name="deptname"></param>
        /// <param name="type"></param>
        /// <param name="pagenum"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagecount"></param>
        /// <returns></returns>
        public DataSet GetCodeSenderSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_CodeSenderSetView";
            para[1].Value = "标识卡号";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }

        /// <summary>
        /// 按指定的分页信息和标识卡号返回指定的标识卡配置信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <param name="pagenum"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagecount"></param>
        /// <returns></returns>
        public DataTable GetCodeSenderSetByCode(string strWhere, int pagenum, int pageindex, out int pagecount)
        {
            string selectstring = "A_PagesShow";
            SqlParameter[] parameters = new SqlParameter[] {
																new SqlParameter("@tablename", SqlDbType.VarChar, 100),
																new SqlParameter("@pagenum", SqlDbType.Int),
																new SqlParameter("@pageindex", SqlDbType.Int),
																new SqlParameter("@columnname", SqlDbType.VarChar,20),
                                                                new SqlParameter("@pagecount", SqlDbType.Int),
                                                                new SqlParameter("@rowcount", SqlDbType.Int)
                                                            };
            parameters[0].Value = string.Format("(select * from A_CodeSenderSetView {0})", strWhere);
            parameters[1].Value = pagenum;
            parameters[2].Value = pageindex;
            parameters[3].Value = "标识卡号";
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Direction = ParameterDirection.Output;
            try
            {
                DataSet ds = dba.GetDataSet(selectstring, parameters);
                pagecount = Convert.ToInt32(parameters[4].Value);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                pagecount = 0;
                return new DataTable();
            }
        }

        /// <summary>
        /// 按指定的分页信息和标识卡号返回指定的标识卡配置信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <param name="pagenum"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagecount"></param>
        /// <returns></returns>
        public DataTable GetCodeSenderSetByCode(string code, string type, int pagenum, int pageindex, out int pagecount)
        {
            string selectstring = "A_PagesShow";
            SqlParameter[] parameters = new SqlParameter[] {
																new SqlParameter("@tablename", SqlDbType.VarChar, 100),
																new SqlParameter("@pagenum", SqlDbType.Int),
																new SqlParameter("@pageindex", SqlDbType.Int),
																new SqlParameter("@columnname", SqlDbType.VarChar,20),
                                                                new SqlParameter("@pagecount", SqlDbType.Int),
                                                                new SqlParameter("@rowcount", SqlDbType.Int)
                                                            };
            parameters[0].Value = string.Format("(select * from A_CodeSenderSetView where 标识卡号={0} and 类型='{1}')", code, type);
            parameters[1].Value = pagenum;
            parameters[2].Value = pageindex;
            parameters[3].Value = "标识卡号";
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Direction = ParameterDirection.Output;
            try
            {
                DataSet ds = dba.GetDataSet(selectstring, parameters);
                pagecount = Convert.ToInt32(parameters[4].Value);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                pagecount = 0;
                return new DataTable();
            }
        }
        /// <summary>
        /// 删除指定的标识卡配置信息
        /// </summary>
        /// <param name="codeaddress"></param>
        /// <returns></returns>
        public int DeleteCodeSenderSet(string codeaddress)
        {
            string sqlstr = string.Format("delete from CodeSender_Set where codesenderaddress={0} update CodeSender_Info set iscodesenderuser=2 where codesenderaddress={0}", codeaddress);
            return dba.ExecuteSql(sqlstr);
        }

        /// <summary>
        /// 按部门查询未配置的人员信息
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        public DataTable GetLastEmpByDept(string dept,string strName)
        {
            string sqlstr;
            //if (dept == "0")
            //{
            //    sqlstr = "select empid,empname from Emp_Info where Empid not in(select userid from CodeSender_Set)";
            //}
            //else
            //{
            //    sqlstr = string.Format("select empid,empname from Emp_Info where Empid not in(select userid from CodeSender_Set) and empname like '%{1}%' and empid in(select empid from Emp_NowCompany where deptid={0})", dept,strName);
            //}

            sqlstr = string.Format("select empid,empname from Emp_Info where Empid not in(select userid from CodeSender_Set where csTypeID=0) {0} {1}  order by empno", dept, strName);

            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// 按部门查询未匹配的设备信息
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        public DataTable GetLastEquByDept(string dept,string strName)
        {
            string sqlstr;
            //if (dept == "0")
            //{
            //    sqlstr = "select equid,equname from Equ_BaseInfo where equid not in(select userid from CodeSender_Set)";
            //}
            //else
            //{
            //    sqlstr = string.Format("select equid,equname from Equ_BaseInfo where deptid={0} and equid not in(select userid from CodeSender_Set)", dept);
            //}

            sqlstr = string.Format("select equid,equname from Equ_BaseInfo where  equid not in(select userid from CodeSender_Set where csTypeID=1) {0} {1} ", dept,strName);

            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }
        /// <summary>
        /// 查询未匹配的人员信息根据名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetLastEmpByName(string name)
        {
            string sqlstr;
            sqlstr = string.Format("select empid,empname from Emp_Info where Empid not in(select userid from CodeSender_Set where csTypeID=0) and empname='{0}'", name);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }
        /// <summary>
        /// 查询未匹配的设备信息根据名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetLastEquByName(string name)
        {
            string sqlstr;
            sqlstr = string.Format("select equid,equname from Equ_BaseInfo where equname='{0}' and equid not in(select userid from CodeSender_Set where csTypeID=1)", name);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// 查询未匹配的标识卡
        /// </summary>
        /// <returns></returns>
        public DataTable GetLastCodesender()
        {
            string sqlstr = "select codesenderaddress from CodeSender_Info where codesenderaddress not in(select codesenderaddress from CodeSender_Set)";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }
        /// <summary>
        /// 根据标识卡号查询标识卡ID
        /// </summary>
        /// <param name="codesenderaddress"></param>
        /// <returns></returns>
        public string GetCodesenderIDbyCodesenderAddress(string codesenderaddress)
        {
            string sqlstr = string.Format("select codesenderid from CodeSender_Info where codesenderaddress={0}", codesenderaddress);
            return dba.ExecuteScalarSql(sqlstr);
        }
        /// <summary>
        /// 插入人员或者设备的标识卡匹配信息
        /// </summary>
        /// <param name="codesenderid"></param>
        /// <param name="codesenderaddress"></param>
        /// <param name="userid"></param>
        /// <param name="cstypeid"></param>
        /// <returns></returns>
        public int InsertIntoCodesenderSet(string codesenderid, string codesenderaddress, string userid, string cstypeid)
        {
            string sqlstr = string.Format("if not exists (select * from CodeSender_Set where codesenderaddress={1}) begin " +
                "update CodeSender_Info set iscodesenderuser=1 where codesenderid={0} " +
                "insert into CodeSender_Set (CsSetID,codesenderid,codesenderaddress,userid,cstypeid) values({4},{0},{1},{2},{3}) end", codesenderid, codesenderaddress, userid, cstypeid, codesenderaddress);
            return dba.ExecuteSql(sqlstr);
        }

        //public DataTable GetCodeSenderByUse(int use)
        //{
        //    string sqlstr;
        //    if (use == 0)
        //    {
        //        sqlstr = "select codesenderAddress as 标识卡号,(select title from EnumTable where enumid= iscodesenderuser and Funid=2) as 状态, " +
        //                                    "(select title from EnumTable where enumid= iscodesenderuser and funid=5) as 是否配置, Remark as 备注 from CodeSender_Info";
        //    }
        //    else
        //    {
        //        sqlstr = string.Format("select codesenderAddress as 标识卡号,(select title from EnumTable where enumid= iscodesenderuser and Funid=2) as 状态, " +
        //                                    "(select title from EnumTable where enumid= iscodesenderuser and funid=5) as 是否配置, Remark as 备注 from CodeSender_Info " +
        //                                    "where iscodesenderuser=2", use);
        //    }
        //    DataSet ds = dba.GetDataSet(sqlstr);
        //    if (ds != null)
        //    {
        //        return ds.Tables[0];
        //    }
        //    else
        //    {
        //        return new DataTable();
        //    }
        //}

        public DataTable GetCodeSenderByUse(string strWhere, int pagenum, int pageindex, out int pagecount,out int rowcount)
        {
            string selectstring = "A_PagesShow";
            SqlParameter[] parameters = new SqlParameter[] {
																new SqlParameter("@tablename", SqlDbType.VarChar, 500),
																new SqlParameter("@pagenum", SqlDbType.Int),
																new SqlParameter("@pageindex", SqlDbType.Int),
																new SqlParameter("@columnname", SqlDbType.VarChar,20),
                                                                new SqlParameter("@pagecount", SqlDbType.Int),
                                                                new SqlParameter("@rowcount", SqlDbType.Int)
                                                           };
 
            parameters[0].Value = string.Format("(select codesenderAddress as 标识卡号,(select title from EnumTable where enumid= CodeSenderStateID and Funid=2) as 状态, " +
                                            "(select title from EnumTable where enumid= iscodesenderuser and funid=5) as 是否配置, Remark as 备注 from CodeSender_Info " +
                                            "{0})", strWhere);

            parameters[1].Value = pagenum;
            parameters[2].Value = pageindex;
            parameters[3].Value = "标识卡号";
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Direction = ParameterDirection.Output;
            try
            {
                DataSet ds = dba.GetDataSet(selectstring, parameters);
                pagecount = Convert.ToInt32(parameters[4].Value);
                rowcount = Convert.ToInt32(parameters[5].Value);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                pagecount = 0;
                rowcount = 0;
                return new DataTable();
            }
        }

        public bool DelCodeSenderByAddress(string codesenderaddress)
        {
            try
            {
                string sqlstr = string.Format("delete from CodeSender_Info where CodeSenderAddress={0}", codesenderaddress);
                if (dba.ExecuteSql(sqlstr) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

   

        public int InsertCodeSender(int codesendaddress, int alarm, int state, int used, string remark)
        {
            string sqlstr = string.Format("declare @count int select @count=count(CodeSenderAddress) from CodeSender_Info where CodeSenderAddress={0} if(@count=0) begin insert into CodeSender_Info (CodeSenderID,CodeSenderAddress,AlarmElectricity,CodeSenderStateID,IsCodeSenderUser,Remark) " +
                                           "values ({4},{0},{1},{2},2,'{3}') end", codesendaddress, alarm, state, remark, codesendaddress);
            return dba.ExecuteSql(sqlstr);
        }

        public int UpdateCodeSenderState(int codesenderaddress, int state)
        {
            string sqlstr = string.Format("update CodeSender_Info set CodeSenderStateID={0} where CodeSenderAddress={1}", state, codesenderaddress);
            return dba.ExecuteSql(sqlstr);
        }

        public DataTable GetCodeSenderByAddress(string strWhere)
        {
            //string sqlstr = string.Format("(select codesenderAddress as 标识卡号,(select title from EnumTable where enumid= CodeSenderStateID and Funid=2) as 状态, " +
            //                                "(select title from EnumTable where enumid= iscodesenderuser and funid=5) as 是否配置, Remark as 备注 from CodeSender_Info " +
            //                                "where codesenderAddress={0})", codesenderaddress);
            string sqlstr = string.Format("(select codesenderAddress as 标识卡号,(select title from EnumTable where enumid= CodeSenderStateID and Funid=2) as 状态, " +
                                            "(select title from EnumTable where enumid= iscodesenderuser and funid=5) as 是否配置, Remark as 备注 from CodeSender_Info " +
                                            " {0})", strWhere);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        public bool UpdateCodeSenderState(string codesenseraddress, int state, string remark)
        {
            try
            {
                string sqlstr = string.Format("update CodeSender_Info set codesenderstateid={1},remark='{2}' where codesenderaddress={0}", codesenseraddress, state, remark);
                if (dba.ExecuteSql(sqlstr) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetRTCodesenderInfo(string sqlstr, int pagenum, int pageindex, out int pagecount, out int rowcount)
        {
            string selectstring = "A_PagesShow";
            SqlParameter[] parameters = new SqlParameter[] {
																new SqlParameter("@tablename", SqlDbType.VarChar, 1000),
																new SqlParameter("@pagenum", SqlDbType.Int),
																new SqlParameter("@pageindex", SqlDbType.Int),
																new SqlParameter("@columnname", SqlDbType.VarChar,20),
                                                                new SqlParameter("@pagecount", SqlDbType.Int),
                                                                new SqlParameter("@rowcount", SqlDbType.Int)
                                                           };
            parameters[0].Value = "(" + sqlstr + ")";
            parameters[1].Value = pagenum;
            parameters[2].Value = pageindex;
            parameters[3].Value = "标识卡号";
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Direction = ParameterDirection.Output;
            try
            {
                DataSet ds = dba.GetDataSet(selectstring, parameters);
                pagecount = Convert.ToInt32(parameters[4].Value);
                rowcount = Convert.ToInt32(parameters[5].Value);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                pagecount = 0;
                rowcount = 0;
                return new DataTable();
            }
        }




        #region【方法：Czlt-2011-12-10 修改配置时间】
        public void UpdateTime()
        {
            string strSQL = "UPDATE [CzltChangeTable] SET ChangeTime ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            dba.GetDataSet(strSQL);
        }

        #endregion
    }
}
