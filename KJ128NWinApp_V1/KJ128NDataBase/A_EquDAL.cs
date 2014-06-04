using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_EquDAL
    {
        private string strSQL;
        private DBAcess dba = new DBAcess();

        public DataTable GetEquTypes()
        {
            string sqlstr = "select title,enumid from EnumTable where funid=9";
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

        public DataTable GetFactoryNames()
        {
            string sqlstr = "select factoryname,factoryid from FactoryInfo";
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

        //public DataTable GetFactoryInfo(string factoryid, int pagenum, int pageindex, out int pagecount, out int rowcount)
        //{
        //    string selectstring = "A_PagesShow";
        //    SqlParameter[] parameters = new SqlParameter[] {
        //                                                        new SqlParameter("@tablename", SqlDbType.VarChar, 500),
        //                                                        new SqlParameter("@pagenum", SqlDbType.Int),
        //                                                        new SqlParameter("@pageindex", SqlDbType.Int),
        //                                                        new SqlParameter("@columnname", SqlDbType.VarChar,20),
        //                                                        new SqlParameter("@pagecount", SqlDbType.Int),
        //                                                        new SqlParameter("@rowcount", SqlDbType.Int)
        //                                                   };
        //    if (factoryid == "all")
        //    {
        //        parameters[0].Value = "(select factoryno as 编号,factoryname as 厂名,factorytel as 电话, " +
        //                                "factoryfax as 传真,factoryemployee as 联系人,factoryempoyeetel as 联系人电话, " +
        //                                "factoryaddress as 厂址,remark as 备注 from FactoryInfo)";
        //    }
        //    else
        //    {
        //        parameters[0].Value = string.Format("(select factoryno as 编号,factoryname as 厂名,factorytel as 电话, "+
        //                                                "factoryfax as 传真,factoryemployee as 联系人,factoryempoyeetel as 联系人电话, "+
        //                                                "factoryaddress as 厂址,remark as 备注 from FactoryInfo "+
        //                                                "where factoryid={0})",factoryid); 
        //    }
        //    parameters[1].Value = pagenum;
        //    parameters[2].Value = pageindex;
        //    parameters[3].Value = "编号";
        //    parameters[4].Direction = ParameterDirection.Output;
        //    parameters[5].Direction = ParameterDirection.Output;
        //    try
        //    {
        //        DataSet ds = dba.GetDataSet(selectstring, parameters);
        //        pagecount = Convert.ToInt32(parameters[4].Value);
        //        rowcount = Convert.ToInt32(parameters[5].Value);
        //        return ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        pagecount = 0;
        //        rowcount = 0;
        //        return new DataTable();
        //    }
        //}
        #region【方法：查询厂家信息】

        public DataTable GetFactoryInfo(string factoryid)
        {
            strSQL = "select factoryno as 编号,factoryname as 厂名,factorytel as 电话, " +
                                        "factoryfax as 传真,factoryemployee as 联系人,factoryempoyeetel as 联系人电话, " +
                                        "factoryaddress as 厂址,remark as 备注,FactoryID from FactoryInfo";
            if (factoryid != "all" && factoryid !="")
            {
                strSQL += " Where FactoryID = " + factoryid;
            }
            try
            {
                DataSet ds = dba.GetDataSet(strSQL);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }

        #endregion

        #region【方法：查询设备信息】


        public DataTable GetEquInfo(string equtype)
        {
            strSQL = " Select * From A_EquView";

            if (equtype != "设备" && equtype!="")
            {
                strSQL += " Where 类型='" + equtype + "'";
            }
            try
            {
                DataSet ds = dba.GetDataSet(strSQL);
                return ds.Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }


        #endregion

        public DataTable GetDepts()
        {
            string sqlstr = "select deptid,deptname from Dept_Info";
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

        //public DataTable GetEquTypes()
        //{
        //    string sqlstr = "select enumid,title from EnumTable where funid=9";
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

        public DataTable GetEquStates()
        {
            string sqlstr = "select enumid,title from EnumTable where funid=10";
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

        public DataTable GetEquFactorys()
        {
            string sqlstr = "select factoryid,factoryname from FactoryInfo";
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

        public bool IsExitsEquNo(string equno)
        {
            string sqlstr = string.Format("select count(EquNO) from Equ_BaseInfo where equno='{0}'", equno);
            int num = int.Parse(dba.ExecuteScalarSql(sqlstr));
            if (num > 0)
                return true;
            else
                return false;
        }

        public bool InsertEquBaseInfo(string equno,string equname,int deptid,string DeptName, int equtype,int equstate,int factoryid,string remark)
        {
            string sqlstr = string.Format("if not exists (select * from Equ_BaseInfo where equno='{0}') insert into Equ_BaseInfo(EquID,EquNO,EquName,DeptID,DeptName,EquType,EquState,FactoryID,Remark) values ({0},'{1}','{2}',{3},'{4}',{5},{6},{7},'{8}')", equno.GetHashCode(), equno, equname, deptid, DeptName, equtype, equstate, factoryid, remark);
            if (dba.ExecuteSql(sqlstr) > 0)
                return true;
            else
                return false;
        }

        #region【方法：修改设备基本信息】

        public bool UpdateEquBaseInfo(string equno, string equname, int deptid,string strDeptName,int equtype, int equstate, int factoryid, string remark,string strEquID)
        {
            string sqlstr = string.Format("update Equ_BaseInfo set equname='{1}',deptid={2},deptName='{8}',equtype={3},equstate={4},factoryid={5},remark='{6}' , equno='{0}' where EquID={7}", equno, equname, deptid, equtype, equstate, factoryid, remark,strEquID,strDeptName);
            if (dba.ExecuteSql(sqlstr) > 0)
                return true;
            else
                return false;
        }

        #endregion

        public string GetEquIDbyEquno(string equno)
        {
            string sqlstr = string.Format("select equid from Equ_BaseInfo where equno='{0}'", equno);
            return dba.ExecuteScalarSql(sqlstr);
        }

        public bool InsertEquDetailInfo(string equid, string ModelSpecial, string DutyEmployee, string UseRange, string ProductionDate, string EquHeight, string EquPower, string UserDate)
        {
            string sqlstr = string.Format("if not exists (select * from Equ_DetailInfo where equid={0}) insert into Equ_DetailInfo values ({8},{0},'{1}','{2}','{3}',{4},{5},{6},{7})",
                equid, ModelSpecial, DutyEmployee, UseRange, ProductionDate, EquHeight, EquPower, UserDate, equid);
            if (dba.ExecuteSql(sqlstr) > 0)
                return true;
            else
                return false;
        }

        #region【方法：修改设备信息】

        public bool UpdateEquDetailInfo(string equid, string ModelSpecial, string DutyEmployee, string UseRange, DateTime ProductionDate, string EquHeight, string EquPower, DateTime UserDate)
        {
            string sqlstr = "update Equ_DetailInfo set modelspecial='" + ModelSpecial + "',dutyemployee='" + DutyEmployee + "',userange='" + UseRange + "',productiondate='" + ProductionDate + "'";
            if (EquHeight != "")
            {
                sqlstr += " , equheight= "+EquHeight;
            }
            if (EquPower != "")
            {
                sqlstr += " , equpower = "+EquPower;
            }
            sqlstr += " , userdate ='" + UserDate + "' " + " Where  equid=" + equid;
            //string sqlstr = string.Format("update Equ_DetailInfo set modelspecial='{1}',dutyemployee='{2}',userange='{3}',productiondate='{4}',equheight={5},equpower={6},userdate='{7}' where equid={0}",
            //    equid, ModelSpecial, DutyEmployee, UseRange, ProductionDate, EquHeight, EquPower, UserDate);
            if (dba.ExecuteSql(sqlstr) > 0)
                return true;
            else
                return false;
        }

        #endregion

        public void DelEquInfo(string equno)
        {
            string sqlstr = string.Format("delete from Equ_DetailInfo where equid in (select equid from Equ_BaseInfo where equno='{0}') " +
                                            "delete from Equ_BaseInfo where equno='{0}'", equno);
            dba.ExecuteSql(sqlstr);
        }

        public DataTable GetEquInfoByEquNO(string equno)
        {
            string sqlstr = string.Format("select * from A_EquView where 编号='{0}'", equno);
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

        public DataTable GetEquDetailInfobyEquID(string equid)
        {
            string sqlstr = string.Format("select * from Equ_DetailInfo where equid={0}", equid);
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

        public void DelFactory(string factoryno)
        {
            string sqlstr = string.Format("delete from FactoryInfo where factoryno='{0}'", factoryno);
            dba.ExecuteSql(sqlstr);
        }

        public bool isExitsFactory(string fno)
        {
            string sqlstr = string.Format("select count(factoryno) from FactoryInfo where factoryno='{0}'", fno);
            int num = int.Parse(dba.ExecuteScalarSql(sqlstr));
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertFactory(string fno,string fname,string faddress,string ffax,string ftel,string femp,string femptel,string fremark)
        {
            string sqlstr = string.Format("if not exists (select * from FactoryInfo where factoryno='{0}') " +
                                            "insert into FactoryInfo values({8},'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", fno, fname, faddress, ffax, ftel, femp, femptel, fremark, fno.GetHashCode());
            int num = dba.ExecuteSql(sqlstr);
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetFactoryByFno(string fno)
        {
            string sqlstr = string.Format("select * from FactoryInfo where factoryno='{0}'", fno);
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

        public bool UpdateFactory(string fno, string fname, string faddress, string ffax, string ftel, string femp, string femptel, string fremark, string strFactoryID)
        {
            string sqlstr = string.Format("update FactoryInfo set factoryname='{1}',factoryaddress='{2}',factoryfax='{3}',factorytel='{4}',factoryemployee='{5}',factoryempoyeetel='{6}',remark='{7}',factoryno='{0}' Where FactoryID ={8}", fno, fname, faddress, ffax, ftel, femp, femptel, fremark,strFactoryID);
            int num = dba.ExecuteSql(sqlstr);
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region【方法：Czlt-2011-12-10 修改配置时间】

        public void UpdateTime()
        {
            strSQL = "UPDATE [CzltChangeTable] SET ChangeTime ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            dba.GetDataSet(strSQL);
        }

        #endregion
    }
}
