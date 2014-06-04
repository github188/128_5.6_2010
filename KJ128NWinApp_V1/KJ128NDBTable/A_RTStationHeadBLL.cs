using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class A_RTStationHeadBLL
    {
        #region【声明】

        private A_RTStationHeadDAL rtsdal = new A_RTStationHeadDAL();

        #endregion

        #region【方法：获取部门（树）——人员】

        public DataSet GetDeptTree_Emp(bool bl)
        {
            return rtsdal.GetDeptTree_Emp(bl);
        }

        #endregion

        #region【方法：获取部门（树）——设备】

        public DataSet GetDeptTree_Equ(bool bl)
        {
            return rtsdal.GetDeptTree_Equ(bl);
        }

        #endregion

        #region【方法：获取分站（树）——人员】

        public DataSet GetStaHeadTree_Emp(bool bl)
        {
            return rtsdal.GetStaHeadTree_Emp(bl);
        }

        #endregion

        #region【方法：获取分站（树）——设备】

        public DataSet GetStaHeadTree_Equ(bool bl)
        {
            return rtsdal.GetStaHeadTree_Equ(bl);
        }

        #endregion

        #region 【方法: 查询实时读卡分站——人员】

        public DataSet Select_StationHead_Emp(string strWhere)
        {
            DataSet ds = rtsdal.Select_StationHead_Emp(strWhere);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                dt.Columns.Add("分站编号");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["分站编号"] = dt.Rows[i]["传输分站编号"].ToString() + "." + dt.Rows[i]["读卡分站编号"];
                }
                return ds;
            }
            else
            {
                return new DataSet();
            }
        }

        #endregion

        #region 【方法: 查询实时读卡分站——设备】

        public DataSet Select_StationHead_Equ(string strWhere)
        {
            return rtsdal.Select_StationHead_Equ(strWhere);
        }

        #endregion
    }
}
