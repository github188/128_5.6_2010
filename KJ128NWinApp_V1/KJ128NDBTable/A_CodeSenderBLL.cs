using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_CodeSenderBLL
    {
        private A_CodeSenderDAL codedal = new A_CodeSenderDAL(); 

        public DataTable GetDeptInfo()
        {
            return codedal.GetDeptInfo();
        }

        public DataSet GetCodeSenderSet(string deptname, string type, string code,int pagenum, int pageindex)
        {
            string strSql = "";
            if (!deptname.Equals("所有"))
            {
                strSql += string.Format(" 部门 in {0} ", deptname);
            }
            if (!code.Equals(""))
            {
                if(!strSql.Trim().Equals(""))
                    strSql += " and ";
                strSql += string.Format(" 标识卡号={0} ", code);
            }
            if (!type.Equals(""))
            {
                if (!strSql.Trim().Equals(""))
                    strSql += " and ";
                strSql += string.Format(" 类型='{0}' ", type);
            }
            return codedal.GetCodeSenderSet( pageindex,pagenum, strSql);
        }

        public DataTable GetCodeSenderSetByCode(string code, string type, int pagenum, int pageindex, out int pagecount)
        {
            string strSql = "";
            if (!code.Equals(""))
            {
                if (!strSql.Contains("Where"))
                    strSql += " Where ";
                strSql += string.Format(" 标识卡号={0} ", code);
            }
            if (!type.Equals(""))
            {
                if (!strSql.Contains("Where"))
                    strSql += " Where ";
                else
                    strSql += " and ";
                strSql += string.Format(" 类型='{0}' ", type);
            }
            return codedal.GetCodeSenderSetByCode(strSql, pagenum, pageindex, out pagecount);
        }

        public int DeleteCodeSenderSet(string codeaddress)
        {
            return codedal.DeleteCodeSenderSet(codeaddress);
        }

        public DataTable GetLastEmpByDept(string dept,string type,string strName)
        {
            if (type == "人员")
            {
                if (!strName.Equals(""))
                {
                    strName = string.Format(" and empname like '%{0}%' ", strName);
                }
                if (!dept.Equals("") && !dept.Equals("0"))
                {
                    dept = string.Format(" and deptid={0} ", dept);
                }
                else
                {
                    dept = "";
                }
                return codedal.GetLastEmpByDept(dept,strName);
            }
            else
            {
                if (!strName.Equals(""))
                {
                    strName = string.Format(" and equname like '%{0}%' ", strName);
                }
                if (!dept.Equals("") && !dept.Equals("0"))
                {
                    dept = string.Format(" and deptid={0} ", dept);
                }
                else
                {
                    dept = "";
                }
                return codedal.GetLastEquByDept(dept, strName);
            }
        }

        //public DataTable GetLastEquByDept(string dept)
        //{
        //    return codedal.GetLastEquByDept(dept);
        //}

        public DataTable GetLastEmpByName(string name,string type)
        {
            if (type == "人员")
            {
                return codedal.GetLastEmpByName(name);
            }
            else
            {
                return codedal.GetLastEquByName(name);
            }
        }

        //public DataTable GetLastEquByName(string name)
        //{
        //    return codedal.GetLastEquByName(name);
        //}

        public DataTable GetLastCodesender()
        {
            return codedal.GetLastCodesender();
        }

        public string GetCodesenderIDbyCodesenderAddress(string codesenderaddress)
        {
            return codedal.GetCodesenderIDbyCodesenderAddress(codesenderaddress);
        }

        public int InsertIntoCodesenderSet( string codesenderaddress, string userid, string cstypeid)
        {
            string codesenderid = codedal.GetCodesenderIDbyCodesenderAddress(codesenderaddress);
            return codedal.InsertIntoCodesenderSet(codesenderid, codesenderaddress, userid, cstypeid);
        }

        public DataTable GetCodeSenderByUse(int use,string code, int pagenum, int pageindex, out int pagecount,out int rowcount)
        {
            string strSql = "";
            if (!code.Equals(""))
            {
                if (!strSql.Contains("Where"))
                    strSql += " Where ";
                strSql += string.Format(" codesenderAddress={0} ", code);
            }
            if (use!=0)
            {
                if (!strSql.Contains("Where"))
                    strSql += " Where ";
                else
                    strSql += " and ";
                strSql += string.Format(" iscodesenderuser={0} ", use);
            }
            return codedal.GetCodeSenderByUse(strSql, pagenum, pageindex, out pagecount, out rowcount);
        }

        public bool DelCodeSenderByAddress(string codesenderaddress)
        {
            return codedal.DelCodeSenderByAddress(codesenderaddress);
        }

        //public DataTable GetCodeSenderInfoByCodeSenderAddress(string codesenderaddress)
        //{
        //    return codedal.GetCodeSenderByAddress(codesenderaddress);
        //}

        public int InsertCodeSender(int codesendaddress, int alarm, int state, int used, string remark)
        {
            return codedal.InsertCodeSender(codesendaddress, alarm, state, used, remark);
        }

        public int UpdateCodeSenderState(int codesenderaddress, int state)
        {
            return codedal.UpdateCodeSenderState(codesenderaddress, state);
        }

        public DataTable GetCodeSenderByAddress(string codesenderaddress)
        {
            string strSql = "";
            if (!codesenderaddress.Equals(""))
            {
                if (!strSql.Contains("Where"))
                    strSql += " Where ";
                strSql += string.Format(" codesenderAddress={0} ", codesenderaddress);
            }
            return codedal.GetCodeSenderByAddress(strSql);
        }

        public bool UpdateCodeSenderState(string codesenseraddress, int state, string remark)
        {
            return codedal.UpdateCodeSenderState(codesenseraddress, state, remark);
        }

        public DataTable GetRTcodesender(string mes, bool isemp, bool isdown,string codesenderaddress,string name, int pagenum, int pageindex, out int pagecount, out int rowcount)
        {
            if (isdown)
            {
                if (mes.Contains("where"))
                {
                    mes = mes + " and stationheadtypeid=32";
                }
                else
                {
                    mes = mes + " where stationheadtypeid=32";
                }
            }
            if (codesenderaddress != "")
            {
                if (mes.Contains("where"))
                {
                    mes = mes + string.Format(" and 标识卡号={0}", codesenderaddress);
                }
                else
                {
                    mes = mes + string.Format(" where 标识卡号={0}", codesenderaddress);
                }
            }
            if (isemp)
            {
                if (name != "")
                {
                    if (mes.Contains("where"))
                    {
                        mes = mes + string.Format(" and 姓名 like '%{0}%'", name);
                    }
                    else
                    {
                        mes = mes + string.Format(" where 姓名 like '%{0}%'", name);
                    }
                }
                string sqlstr = "select 标识卡号,姓名,部门,工种,职务,位置,监测时间,方向性 from A_RtCodeSenderEmpView";
                sqlstr = sqlstr + " " + mes;
                return codedal.GetRTCodesenderInfo(sqlstr, pagenum, pageindex, out pagecount, out rowcount);
            }
            else
            {
                if (name != "")
                {
                    if (mes.Contains("where"))
                    {
                        mes = mes + string.Format(" and 设备名称 like '%{0}%'", name);
                    }
                    else
                    {
                        mes = mes + string.Format(" where 设备名称 like '%{0}%'", name);
                    }
                }
                string sqlstr = "select 标识卡号,设备名称,设备编号,设备类型,生产厂家,生产日期,部门,位置,监测时间,方向性 from A_RtCodeSenderEquView";
                sqlstr = sqlstr + " " + mes;
                return codedal.GetRTCodesenderInfo(sqlstr, pagenum, pageindex, out pagecount, out rowcount);
            }
        }


        #region【方法：Czlt-2011-12-10 修改时间】

        public void UpdateTime()
        {
            codedal.UpdateTime();
        }
        #endregion

    }
}
