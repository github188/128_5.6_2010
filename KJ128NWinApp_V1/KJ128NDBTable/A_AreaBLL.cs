using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;
using System.Windows.Forms;


namespace KJ128NDBTable
{
    public class A_AreaBLL
    {

        #region【声明】

        private A_AreaDAL areadal = new A_AreaDAL();

        private DataSet ds;

        #endregion


        #region【方法：获取区域类型——区域类型】

        public DataSet GetTerType_TerType()
        {
            return areadal.GetTerType_TerType();
        }

        #endregion

        #region 【方法: 查询区域类型】

        public DataSet SelectTerTypeInfo(string strWhere)
        {
            return areadal.SelectTerTypeInfo(strWhere);
        }

        #endregion

        #region【方法：获得区域类别——修改、查看绑定】

        public DataSet GetTerType_Binding(int intTerritorialTypeID)
        {
            return areadal.GetTerType_Binding(intTerritorialTypeID);
        }

        #endregion

        #region【方法：根据区域名称验证数据中是否有该记录】

        public DataSet GetKJ128NTerTypeTable(string strTerTypeName)
        {
            return areadal.GetKJ128NTerTypeTable(strTerTypeName);
        }

        #endregion

        #region【方法：添加 区域类别】

        public int SaveTerType(string TypeName, byte IsAlarm, string Remark)
        {
            return areadal.SaveTerType(TypeName, IsAlarm, Remark);
        }
        #endregion

        #region【方法：修改 区域类型】

        public int UpDateTerType(int TerTypeID, string TypeName, byte IsAlarm, string Remark)
        {
            return areadal.UpDateTerType(TerTypeID, TypeName, IsAlarm, Remark);
        }

        #endregion

        #region【方法：删除 区域类型】
        public int DeleteTerType(string strTerTypeID)
        {
            return areadal.DeleteTerType(strTerTypeID);
        }
        #endregion





        #region【方法：获取区域信息——区域信息】

        public DataSet GetTer_Ter()
        {
            return areadal.GetTer_Ter();
        }

        #endregion

        #region 【方法: 查询区域信息】

        public DataSet SelectTerInfo(string strWhere)
        {
            return areadal.SelectTerInfo(strWhere);
        }

        #endregion

        #region【方法：绑定 区域类别(不返回"所有")】
        public ComboBox GetTerTypeCmb2(ComboBox cmb)
        {
            DataSet ds = areadal.GetTerTypeDataSet();
            if (ds!= null && ds.Tables.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "TypeName";
                cmb.ValueMember = "TerritorialTypeID";
                //cmb.SelectedItem = 0;
            }
            return cmb;
        }
        #endregion

        #region【方法: select * from KJ128N_TerInfo_Table】

        public DataSet GetTreInfoTable(string strTerInfoName)
        {
            return areadal.GetTreInfoTable(strTerInfoName);
        }

        #endregion

        public bool IsExistsTNO(string tno)
        {
            return areadal.IsExistsTNO(tno);
        }


        #region【方法：添加区域信息】

        public int SaveTer(string strTerName, int intTerTypeID, int intTerEmpCount, int intTerWorkTime, string strTerRemark,string no)
        {
            return areadal.SaveTer(strTerName, intTerTypeID, intTerEmpCount, intTerWorkTime, strTerRemark, no);
        }

        #endregion

        #region【方法：修改区域信息】

        public int UpDateTer(string strTerName, int intTerTypeID, int intTerEmpCount, int intTerWorkTime, string strTerRemark,int intTerID,string no)
        {
            return areadal.UpDateTer(strTerName, intTerTypeID, intTerEmpCount, intTerWorkTime, strTerRemark, intTerID, no);
        }

        #endregion

        #region【方法：获得区域信息——修改、查看绑定】

        public DataSet GetTer_Binding(int intTerritorialID)
        {
            return areadal.GetTer_Binding(intTerritorialID);
        }

        #endregion

        #region【方法：删除 区域信息】
        public int DeleteTer(string strTerID)
        {
            return areadal.DeleteTer(strTerID);
        }
        #endregion


        #region [ 方法: 区域设置信息 ]
        public DataSet GetTerSet(int pageIndex, int pageSize, string where)
        {
            return areadal.GetTerSet(pageIndex, pageSize, where);
        }

        #endregion

        public DataSet GetSWork(int pageIndex, int pageSize, string where)
        {
            return areadal.GetSWork(pageIndex, pageSize, where);
        }

        #region【方法：获取探头信息——全部】

        public DataSet GetStaHead_ALL()
        {
            return areadal.GetStaHead_ALL();
        }

        #endregion

        //#region【方法：根据探头的编号获取探头的ID】

        //private string GetStationHeadID(string strStationAddress, string strStaHeadAddress)
        //{
        //    using (ds=new DataSet())
        //    {
        //        ds = areadal.GetStationHeadID(strStationAddress, strStaHeadAddress);
        //        if (ds != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows > 0)
        //            {
        //                return ds.Tables[0].Rows[0][0].ToString();
        //            }
        //        }

        //    }
        //    return "-1";           
        //}

        //#endregion

        #region【方法：保存区域信息】

        public int SaveTerSet(int intTerritorialID, int intStationHeadID, int intIsTerriorialEnter)
        {
            return areadal.SaveTerSet(intTerritorialID, intStationHeadID, intIsTerriorialEnter);
        }

        #endregion

        #region【方法：更改区域信息】

        public int UpDateTerSet(int intTerritorialID, string strWhere)
        {
            return areadal.UpDateTerSet(intTerritorialID, strWhere);
        }

        #endregion

        #region【方法：根据区域ID获取探头信息】

        public DataSet GetTerSet_StaHead(int intTerID)
        {
            return areadal.GetTerSet_StaHead(intTerID);
        }

        #endregion

        #region【方法：根据区域ID获取区域口信息】

        public DataSet GetTerriorialEnter(int intTerID)
        {
            return areadal.GetTerriorialEnter(intTerID);
        }

        #endregion

        #region【方法：删除 区域范围】

        public int DeleteTerSet(string strTerSetID)
        {
            return areadal.DeleteTerSet(strTerSetID);
        }

        #endregion


        #region【方法：Czlt-2011-12-10 修改时间】

        public void UpdateTime()
        {
            areadal.UpdateTime();
        }
        #endregion

    }
}
