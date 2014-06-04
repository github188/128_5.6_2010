using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class A_RTStationHeadDAL
    {
        #region【声明】

        private DBAcess dba = new DBAcess();

        private DataSet ds;

        private string strSQL;

        #endregion

        #region【方法：获取部门（树）——人员】

        public DataSet GetDeptTree_Emp(bool bl)
        {
            //if (bl)      //显示上井口信息
            //{
            //    strSQL = " Select * From A_DeptTree_RTStaHead_Emp ";
            //}
            //else         //不显示上井口信息
            //{
            //    //(Select count(1) From A_RTStaHead_Emp as Rt Where Rt.DeptID=Dei.DeptID and StationHeadTypeID=32)
            //    strSQL = " Select Dei.DeptID as ID, " +
            //                " Dei.DeptName as Name , " +
            //                " Dei.ParentDeptID as ParentID, " +
            //                " 'true' as IsChild , " +
            //                " 'false' as IsUserNum , " +
            //                " 0 as Num " +
            //            " From Dept_Info as Dei ";
            //}
            strSQL = " Select Dei.DeptID as ID, " +
                           " Dei.DeptName as Name , " +
                           " Dei.ParentDeptID as ParentID, " +
                           " 'true' as IsChild , " +
                           " 'false' as IsUserNum , " +
                           " 0 as Num " +
                       " From Dept_Info as Dei order by serialno,DeptName ";

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取部门（树）——设备】

        public DataSet GetDeptTree_Equ(bool bl)
        {
            if (bl)      //显示上井口信息
            {
                strSQL = " Select * From A_DeptTree_RTStaHead_Equ ";
            }
            else         //不显示上井口信息
            {
                strSQL = " Select Dei.DeptID as ID, " +
                            " Dei.DeptName as Name , " +
                            " Dei.ParentDeptID as ParentID, " +
                            " 'true' as IsChild , " +
                            " 'false' as IsUserNum , " +
                            " (Select count(1) From A_RTStaHead_Equ as Rt Where Rt.DeptID=Dei.DeptID and StationHeadTypeID=32)as Num " +
                        " From Dept_Info as Dei ";
            }
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取分站（树）——人员】

        public DataSet GetStaHeadTree_Emp(bool bl)
        {
            //if (bl)     //显示上井口信息
            //{
            //    strSQL = " Select 'S'+ CONVERT(varchar,Si.StationAddress) as ID, " +
            //                " Si.StationPlace as Name, " +
            //                " '0' as ParentID, " +
            //                " 'true' as IsChild , " +
            //                " 'false' as IsUserNum , " +
            //                " 0 as Num " +
            //            " From Station_Info as Si " +
            //            " Union " +
            //            " Select 'H'+ CONVERT(varchar,Shi.StationHeadAddress) as ID, " +
            //                " Shi.StationHeadPlace as Name, " +
            //                " 'S'+ CONVERT(varchar,Shi.StationAddress) as ParentID, " +
            //                " 'true' as IsChild , " +
            //                " 'false' as IsUserNum , " +
            //                " 0 as Num " +
            //            " From Station_Head_Info as Shi";
            //}
            //else        //不显示上井口信息
            //{
            //    //(Select Count(1) From A_RTStaHead_Emp Where 读卡分站编号=Shi.StationHeadAddress and 传输分站编号=Shi.StationAddress and StationHeadTypeID=32)
            //    strSQL = " Select 'S'+ CONVERT(varchar,Si.StationAddress) as ID, " +
            //                " Si.StationPlace as Name, " +
            //                " '0' as ParentID, " +
            //                " 'true' as IsChild , " +
            //                " 'false' as IsUserNum , " +
            //                " 0 as Num " +
            //            " From Station_Info as Si " +
            //            " Union " +
            //            " Select 'H'+ CONVERT(varchar,Shi.StationHeadAddress) as ID, " +
            //                " Shi.StationHeadPlace as Name, " +
            //                " 'S'+ CONVERT(varchar,Shi.StationAddress) as ParentID, " +
            //                " 'true' as IsChild , " +
            //                " 'false' as IsUserNum , " +
            //                " 0 as Num " +
            //            " From Station_Head_Info as Shi";

            //}
            strSQL = " Select 'S'+ CONVERT(varchar,Si.StationAddress) as ID, " +
                            " Si.StationPlace as Name, " +
                            " '0' as ParentID, " +
                            " 'true' as IsChild , " +
                            " 'false' as IsUserNum , " +
                            " 0 as Num " +
                        " From Station_Info as Si " +
                        " Union " +
                        " Select 'H'+ CONVERT(varchar,Shi.StationHeadAddress) as ID, " +
                            " Shi.StationHeadPlace as Name, " +
                            " 'S'+ CONVERT(varchar,Shi.StationAddress) as ParentID, " +
                            " 'true' as IsChild , " +
                            " 'false' as IsUserNum , " +
                            " 0 as Num " +
                        " From Station_Head_Info as Shi";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取分站（树）——设备】

        public DataSet GetStaHeadTree_Equ(bool bl)
        {
            if (bl)     //显示上井口信息
            {
                strSQL = " Select * From A_StaHeadTree_RTStaHead_Equ ";
            }
            else        //不显示上井口信息
            {
                strSQL = " Select 'S'+ CONVERT(varchar,Si.StationAddress) as ID, " +
                           " Si.StationPlace as Name, " +
                           " '0' as ParentID, " +
                           " 'true' as IsChild , " +
                           " 'true' as IsUserNum , " +
                           " 0 as Num " +
                       " From Station_Info as Si " +
                       " Union " +
                       " Select 'H'+ CONVERT(varchar,Shi.StationHeadAddress) as ID, " +
                           " Shi.StationHeadPlace as Name, " +
                           " 'S'+ CONVERT(varchar,Shi.StationAddress) as ParentID, " +
                           " 'true' as IsChild , " +
                           " 'true' as IsUserNum , " +
                           " (Select Count(1) From A_RTStaHead_Equ Where 读卡分站编号=Shi.StationHeadAddress and 传输分站编号=Shi.StationAddress and StationHeadTypeID=32) as Num " +
                       " From Station_Head_Info as Shi";
            }
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询实时读卡分站——人员】

        public DataSet Select_StationHead_Emp(string strWhere)
        {
            strSQL = " Select * From A_RTStaHead_Emp Where " + strWhere + " order by serialno";
            //strSQL += " Select DISTINCT(标识卡号) From A_RTStaHead_Emp Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询实时读卡分站——设备】

        public DataSet Select_StationHead_Equ(string strWhere)
        {
            strSQL = " Select * From A_RTStaHead_Equ Where " + strWhere;
            //strSQL += " Select DISTINCT(标识卡号) From A_RTStaHead_Equ Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion
    }
}
