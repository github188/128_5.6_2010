using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class ConAreaManageDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion
        


        #region [ 方法: 获取( 区域名称、区域类别)基本信息 ]

        public DataSet N_GetTerName()
        {
            strSql = " Select TerritorialID,TerritorialName From Territorial_Info ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet N_GetTerType()
        {
            strSql = " Select TerritorialTypeID,TypeName From Territorial_Type ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询区域设置 ]

        /// <summary>
        /// 查询 区域设置
        /// </summary>
        /// <param name="strTerID">区域ID</param>
        /// <param name="strTerTypeID">区域类别ID</param>
        /// <returns>true: 成功</returns>
        public DataSet N_SearchTerSet(string strTerID, string strTerTypeID)
        {
            bool blIsFirst = false;
            strSql = " Select " +
                        " TerritorialName as 区域名称, " +
                        " TypeName as 区域类别, " +
                        " Si.StationAddress as " + HardwareName.Value(CorpsName.StationAddress) + ", " +
                        " StationPlace as " + HardwareName.Value(CorpsName.StationSplace) + ", " +
                        " StationHeadAddress as " + HardwareName.Value(CorpsName.StaHeadAddress) + ", " +
                        " StationHeadPlace as " + HardwareName.Value(CorpsName.StaHeadSplace) +
                     " From " +
                        " Territorial_Set as Ts left join Territorial_Info as Ti on Ts.TerritorialID=Ti.TerritorialID " +
                        " left join Territorial_Type as Tt on Tt.TerritorialTypeID=Ti.TerritorialTypeID " +
                        " left join Station_Info as Si on Si.StationID=Ts.StationID " +
                        " left join Station_Head_Info as Shi on Shi.StationHeadID=Ts.StationHeadID ";
            if (!strTerID.Equals("0"))
            {
                strSql += " Where Ti.TerritorialID =" + strTerID;
                blIsFirst = true;
            }
            if (!strTerTypeID.Equals("0"))
            {
                if (blIsFirst)
                {
                    strSql += " And Tt.TerritorialTypeID =" + strTerTypeID;
                }
                else
                {
                    strSql += " Where Tt.TerritorialTypeID =" + strTerTypeID;
                }
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询区域信息 ]

        public DataSet N_SearchTerInfo()
        {
            strSql = " Select " +
                        " TerritorialName as 区域名称, " +
                        " TypeName as 区域类型, " +
                        " 是否启用= case when IsEnable=0 then '不启用' when IsEnable=1 then '启用' end, " +
                        " Instruction as 区域介绍, " +
                        " Ti.Remark as 备注 " +
                     " From " +
                        " Territorial_Info as Ti left join Territorial_Type as Tt on Ti.TerritorialTypeID=Tt.TerritorialTypeID ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询区域类型 ]

        public DataSet N_SearchTerType()
        {
            strSql = " Select " +
                        " TypeName as 区域类型, " +
                        " 是否报警= case when IsAlarm=0 then '不报警' when IsAlarm=1 then '报警' end, " +
                        " Remark as 备注 " +
                     " From " +
                        " Territorial_Type ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion
    }
}
