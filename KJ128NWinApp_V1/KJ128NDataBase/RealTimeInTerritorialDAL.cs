using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class RealTimeInTerritorialDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();
        
        private string strSql = string.Empty;

        #endregion


        #region [ 方法: 获取区域信息 ]

        public DataSet N_GetTerInfo()
        {
            strSql = " Select TerritorialID, TerritorialName From Territorial_Info ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion


        #region [ 方法: 获取区域信息 ]

        public DataSet N_GetTerInfo_G()
        {
            strSql = " Select TerritorialID, TerritorialName,TerritorialTypeID From Territorial_Info ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取区域类别 ]

        public DataSet N_GetTerTypeInfo()
        {
            strSql = " Select TerritorialTypeID, TypeName From Territorial_Type ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询实时区域信息 ]

        public DataSet N_GetRTInTerritorialInfo(int intTerTypeID, string strTerName, bool blIsEmp, string strIsAlarm)
        {
            if (blIsEmp)                                            //人员
            {
                strSql = " Select " +
                            " CodeSenderAddress as " + HardwareName.Value(CorpsName.CodeSenderAddress) + "," +
                            " EmpName as 员工姓名 ," +
                            " DeptName as 部门名称 ," +
                            " TypeName as  区域类别 ," +
                            " Ti.TerritorialName as 区域名称 ," +
                            " 是否报警 = case when Tt.IsAlarm=1 then '报警' else '不报警' end , " +
                            " InTerritorialTime as " + HardwareName.Value(CorpsName.InTerritorialTime) + " , " +
                            " dbo.FunConvertTime(DATEDIFF(ss,InTerritorialTime, getDate())) AS " + HardwareName.Value(CorpsName.StandingTime) +
                         " From " +
                            " RT_TerritorialInfo as Ri left join Emp_Info As Ei on Ei.EmpID=Ri.UserID " +
                            " left join Emp_NowCompany as En on Ei.EmpID=En.EmpID " +
                            " left join Dept_Info as Di on En.DeptID=Di.DeptID " +
                            " left join Territorial_Info as Ti on Ri.TerritorialID=Ti.TerritorialID " +
                            " left join Territorial_Type as Tt on Ti.TerritorialTypeID=Tt.TerritorialTypeID " +
                        " Where " +
                            " CsTypeID=0";
            }
            else                                                    //设备
            {
                strSql = " Select " +
                            " CodeSenderAddress as " + HardwareName.Value(CorpsName.CodeSenderAddress) + "," +
                            " EquName as 设备名称 ," +
                            " DeptName as 所属部门," +
                            " TypeName as  区域类别," +
                            " Ti.TerritorialName as 区域名称 ," +
                            " 是否报警 = case when Tt.IsAlarm=1 then '报警' else '不报警' end , " +
                            " InTerritorialTime as " + HardwareName.Value(CorpsName.InTerritorialTime) + " , " +
                            " dbo.FunConvertTime(DATEDIFF(ss,InTerritorialTime, getDate())) AS " + HardwareName.Value(CorpsName.StandingTime) +
                        " From " +
                            " RT_TerritorialInfo as Ri left join Equ_BaseInfo as Eb on Ri.UserID=Eb.EquID " +
                            " left join Dept_Info as Di on Eb.DeptID=Di.DeptID " +
                            " left join Territorial_Info as Ti on Ri.TerritorialID=Ti.TerritorialID " +
                            " left join Territorial_Type as Tt on Ti.TerritorialTypeID=Tt.TerritorialTypeID " +
                         " Where " +
                            " CsTypeID=1 ";
            }
            if (intTerTypeID != 0)                                     //区域类型
            {
                strSql += " And Tt.TerritorialTypeID= " + intTerTypeID.ToString();
            }
            if (strTerName != "所有" && strTerName != null)                                  //区域名称
            {
                strSql += " And Ri.TerritorialName='" + strTerName + "'";
            }
            if (strIsAlarm == "报警")
            {
                strSql += " And Tt.IsAlarm =1";
            }
            else if (strIsAlarm == "不报警")
            {
                strSql += " And Tt.IsAlarm =0";
            }
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询实时区域信息 ]

        public DataSet N_GetRTInTerritorialInfo_G(int intTerTypeID, string strTerName, bool blIsEmp, string strIsAlarm)
        {
            if (blIsEmp)                                            //人员
            {
                strSql = " Select " +
                            " CodeSenderAddress as " + HardwareName.Value(CorpsName.CodeSenderAddress) + "," +
                            " EmpName as 员工姓名 ," +
                            " DeptName as 部门名称 ," +
                            " TypeName as  区域类别 ," +
                            " Ti.TerritorialName as 区域名称 ," +
                            " 是否报警 = case when Tt.IsAlarm=1 then '报警' else '不报警' end , " +
                            " InTerritorialTime as " + HardwareName.Value(CorpsName.InTerritorialTime) + " , " +
                            " dbo.FunConvertTime(DATEDIFF(ss,InTerritorialTime, getDate())) AS " + HardwareName.Value(CorpsName.StandingTime) +
                         " From " +
                            " RT_TerritorialInfo as Ri left join Emp_Info As Ei on Ei.EmpID=Ri.UserID " +
                            //Czlt-2010-10-21-注销
                            //" left join Emp_NowCompany as En on Ei.EmpID=En.EmpID " +
                            //" left join Dept_Info as Di on En.DeptID=Di.DeptID " +
                            " left join Territorial_Info as Ti on Ri.TerritorialID=Ti.TerritorialID " +
                            " left join Territorial_Type as Tt on Ti.TerritorialTypeID=Tt.TerritorialTypeID " +
                        " Where " +
                            " CsTypeID=0 and CodeSenderaddress in(Select CodeSenderAddress From dbo.RT_InOutMine)";
            }
            else                                                    //设备
            {
                strSql = " Select " +
                            " CodeSenderAddress as " + HardwareName.Value(CorpsName.CodeSenderAddress) + "," +
                            " EquName as 设备名称 ," +
                            " DeptName as 所属部门," +
                            " TypeName as  区域类别," +
                            " Ti.TerritorialName as 区域名称 ," +
                            " 是否报警 = case when Tt.IsAlarm=1 then '报警' else '不报警' end , " +
                            " InTerritorialTime as " + HardwareName.Value(CorpsName.InTerritorialTime) + " , " +
                            " dbo.FunConvertTime(DATEDIFF(ss,InTerritorialTime, getDate())) AS " + HardwareName.Value(CorpsName.StandingTime) +
                        " From " +
                            " RT_TerritorialInfo as Ri left join Equ_BaseInfo as Eb on Ri.UserID=Eb.EquID " +
                            " left join Dept_Info as Di on Eb.DeptID=Di.DeptID " +
                            " left join Territorial_Info as Ti on Ri.TerritorialID=Ti.TerritorialID " +
                            " left join Territorial_Type as Tt on Ti.TerritorialTypeID=Tt.TerritorialTypeID " +
                         " Where " +
                            " CsTypeID=1 and CodeSenderaddress in(Select CodeSenderAddress From dbo.RT_InOutMine)";
            }
            if (intTerTypeID != 0)                                     //区域类型
            {
                strSql += " And Tt.TerritorialTypeID= " + intTerTypeID.ToString();
            }
            if (strTerName != "所有" && strTerName != null)                                  //区域名称
            {
                strSql += " And Ri.TerritorialName='" + strTerName + "'";
            }
            if (strIsAlarm == "报警")
            {
                strSql += " And Tt.IsAlarm =1";
            }
            else if (strIsAlarm == "不报警")
            {
                strSql += " And Tt.IsAlarm =0";
            }
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询实时区域信息 ]

        public DataSet GetAreaTable(string str)
        {
            strSql = " Select " +
                        " CodeSenderAddress as " + HardwareName.Value(CorpsName.CodeSenderAddress) + "," +
                        " EmpName as 员工姓名 ," +
                        " DeptName as 部门名称 ," +
                        " TypeName as  区域类别 ," +
                        " Ti.TerritorialName as 区域名称 ," +
                        " 是否报警 = case when Tt.IsAlarm=1 then '报警' else '不报警' end , " +
                        " InTerritorialTime as " + HardwareName.Value(CorpsName.InTerritorialTime) + " , " +
                        " dbo.FunConvertTime(DATEDIFF(ss,InTerritorialTime, getDate())) AS " + HardwareName.Value(CorpsName.StandingTime) +
                     " From " +
                        " RT_TerritorialInfo as Ri left join Emp_Info As Ei on Ei.EmpID=Ri.UserID " +
                        " left join Emp_NowCompany as En on Ei.EmpID=En.EmpID " +
                        " left join Dept_Info as Di on En.DeptID=Di.DeptID " +
                        " left join Territorial_Info as Ti on Ri.TerritorialID=Ti.TerritorialID " +
                        " left join Territorial_Type as Tt on Ti.TerritorialTypeID=Tt.TerritorialTypeID " +
                    " Where CsTypeID=0";
            strSql += " And TypeName like '%" + str + "%' And Tt.IsAlarm =1";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region 是否是人员区域报警

        public DataSet GetEmpAlarm()
        {
            strSql = "Select count(1) From RT_TerritorialInfo Where CsTypeID=0 ";

            return dbacc.GetDataSet(strSql);

        }

        #endregion

    }
}
