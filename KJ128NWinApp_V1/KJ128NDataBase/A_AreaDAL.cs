using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_AreaDAL
    {

        #region【声明】

        private DBAcess dba = new DBAcess();

        private string strSQL;

        #endregion


        #region【方法：获取区域类型——区域类型】

        public DataSet GetTerType_TerType()
        {
            strSQL = " Select CONVERT(varchar,Tt.TerritorialTypeID) as ID, " +
                            " Tt.TypeName as Name , " +
                            " '0' as ParentID, " +
                            " 'true' as IsChild , " +
                            " 'false' as IsUserNum ,  " +
                            " 0 as Num  " +
                    " From Territorial_Type as Tt ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询区域类型】

        public DataSet SelectTerTypeInfo(string strWhere)
        {
            strSQL = " Select TypeName as 区域类型, Remark as 备注 ,TerritorialTypeID From Territorial_Type Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获得区域类别——修改、查看绑定】

        public DataSet GetTerType_Binding(int intTerritorialTypeID)
        {
            strSQL = " Select * From Territorial_Type Where TerritorialTypeID = " + intTerritorialTypeID;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：根据区域名称验证数据中是否有该记录】

        public DataSet GetKJ128NTerTypeTable(string strTerTypeName)
        {
            strSQL = "select * from Territorial_Type where TypeName = '" + strTerTypeName + "' ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：添加 区域类别】

        public int SaveTerType(string TypeName, byte IsAlarm, string Remark)
        {
            strSQL = string.Format(
            "if(not exists(select 1 from Territorial_Type where TypeName='" + TypeName + "')) "
            + " begin "
            + " insert into Territorial_Type(TerritorialTypeID,TypeName,IsAlarm,Remark) values({3},'{0}',{1},'{2}')"
            + " end ", TypeName, IsAlarm, Remark, TypeName.GetHashCode());
            return dba.ExecuteSql(strSQL);
        }

        #endregion

        #region【方法：修改 区域类型】

        public int UpDateTerType(int TerTypeID, string TypeName, byte IsAlarm, string Remark)
        {
            strSQL = string.Format(
                " if(exists(select TypeName from Territorial_Type where TerritorialTypeID =" + TerTypeID.ToString() + " )) "
                + " begin "
                + " update Territorial_Type set TypeName='{0}',IsAlarm={1},Remark='{2}' where TerritorialTypeID={3}"
                + " end", TypeName, IsAlarm, Remark, TerTypeID);
            return dba.ExecuteSql(strSQL);
        }
        #endregion

        #region [ 方法: 删除 区域信息 ]
        public int DeleteTerType(string strTerTypeID)
        {
            strSQL = "delete from Territorial_Type where TerritorialTypeID in " +
                    "(select TerritorialTypeID from Territorial_Type " +
                    "where (" + strTerTypeID + ") and TypeName <> '限制区域' and TypeName <> '重点区域' and TypeName <> '地域')";

            return dba.ExecuteSql(strSQL);
        }
        #endregion







        #region【方法：获取区域信息——区域信息】

        public DataSet GetTer_Ter()
        {
            strSQL = " Select 'T'+ CONVERT(varchar,Tt.TerritorialTypeID) as ID, " +
                            " Tt.TypeName as Name , " +
                            " '0' as ParentID, " +
                            " 'true' as IsChild , " +
                            " 'false' as IsUserNum , " +
                            " 0 as Num " +
                    " From Territorial_Type as Tt " +
                    " Union " +
                    " Select 'I'+ Convert(varchar,Ti.TerritorialID) as ID, " +
                            " Ti.TerritorialName as Name, " +
                            " 'T'+Convert(varchar,Ti.TerritorialTypeID) as ParentID," +
                            " 'true' as IsChild , " +
                            " 'false' as IsUserNum ,  " +
                            " 0 as Num  " +
                    " From Territorial_Info as Ti";

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region 【方法: 查询区域信息】

        public DataSet SelectTerInfo(string strWhere)
        {
            strSQL = " Select * From A_KJ128N_TerInfo_Table Where " + strWhere;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取 区域类型(DataSet)】

        //获取 区域类型(DataSet)
        /// <summary>
        /// 获取 区域类型(DataSet)
        /// </summary>
        /// <returns>返回区域类型(DataSet)</returns>
        public DataSet GetTerTypeDataSet()
        {
            return dba.GetDataSet("select TerritorialTypeID,TypeName from Territorial_Type");
        }
        #endregion

        #region【方法：select * from KJ128N_TerInfo_Table】

        public DataSet GetTreInfoTable(string strTerInfoName)
        {
            strSQL = string.Format("select * from KJ128N_TerInfo_Table where 区域名称='{0}'", strTerInfoName);
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region[编号重复]
        public bool IsExistsTNO(string tno)
        {
            string sqlstr = "select count(1) from Territorial_Info where TerritorialNO=" + tno;
            string num = dba.ExecuteScalarSql(sqlstr);
            try
            {
                if (int.Parse(num) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion



        #region【方法：添加区域信息】

        public int SaveTer(string strTerName, int intTerTypeID, int intTerEmpCount, int intTerWorkTime, string strTerRemark,string no)
        {
            SqlParameter[] para = { new SqlParameter("@TerritorialName",SqlDbType.NVarChar,20),
                                    new SqlParameter("@TerritorialTypeID",SqlDbType.Int),
                                    new SqlParameter("@IsEnable",SqlDbType.Bit),
                                    new SqlParameter("@Instruction",SqlDbType.NVarChar,500),
                                    new SqlParameter("@TerWorkTime",SqlDbType.Int),
                                    new SqlParameter("@TerEmpCount",SqlDbType.Int),
                                    new SqlParameter("@Remark",SqlDbType.NVarChar,200),
                                    new SqlParameter("@ID",SqlDbType.Int),
                                    new SqlParameter("@NO",SqlDbType.VarChar,50)
            };
            para[0].Value = strTerName;
            para[1].Value = intTerTypeID;
            para[2].Value = 1;
            para[3].Value = "";
            para[4].Value = intTerWorkTime;
            para[5].Value = intTerEmpCount;
            para[6].Value = strTerRemark;
            para[7].Value = strTerName.GetHashCode();
            para[8].Value = no;

            return dba.ExecuteSql("A_TerInfo_Insert", para);
        }

        #endregion

        #region【方法：修改区域信息】

        public int UpDateTer(string strTerName, int intTerTypeID, int intTerEmpCount, int intTerWorkTime, string strTerRemark,int intTerID,string no)
        {
            SqlParameter[] para = { new SqlParameter("@TerritorialName",SqlDbType.NVarChar,20),
                                    new SqlParameter("@TerritorialTypeID",SqlDbType.Int),
                                    new SqlParameter("@IsEnable",SqlDbType.Bit),
                                    new SqlParameter("@Instruction",SqlDbType.NVarChar,500),
                                    new SqlParameter("@TerWorkTime",SqlDbType.Int),
                                    new SqlParameter("@TerEmpCount",SqlDbType.Int),
                                    new SqlParameter("@Remark",SqlDbType.NVarChar,200),
                                    new SqlParameter("@TerritorialID",SqlDbType.Int),
                                    new SqlParameter("@NO",SqlDbType.VarChar,50)
            };
            para[0].Value = strTerName;
            para[1].Value = intTerTypeID;
            para[2].Value = 1;
            para[3].Value = "";
            para[4].Value = intTerWorkTime;
            para[5].Value = intTerEmpCount;
            para[6].Value = strTerRemark;
            para[7].Value = intTerID;
            para[8].Value = no;

            return dba.ExecuteSql("A_TerInfo_UpDate", para);
        }

        #endregion

        #region【方法：获得区域类别——修改、查看绑定】

        public DataSet GetTer_Binding(int intTerritorialID)
        {
            strSQL = " select * From Territorial_Info as Ti left join Territorial_Config as Tc on Ti.TerritorialID =Tc.TerritorialID Where Ti.TerritorialID = " + intTerritorialID;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region [ 方法: 删除 区域信息 ]
        public int DeleteTer(string strTerID)
        {
            SqlParameter[] para = { new SqlParameter("@where",SqlDbType.VarChar,2000)
            };
            para[0].Value = strTerID;

            return dba.ExecuteSql("A_TerInfo_Delete", para);
        }
        #endregion

        #region [ 方法: 区域设置信息 ]
        public DataSet GetTerSet(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_KJ128N_TerTypeSet_Table";
            para[1].Value = "TerritorialSetID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region [ 方法: 特殊工种配置信息 ]
        public DataSet GetSWork(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_SWorkTer";
            para[1].Value = "TerriAlarmID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region【方法：获取探头信息——全部】

        public DataSet GetStaHead_ALL()
        {
            strSQL = " Select 'S'+ CONVERT(varchar,Si.StationAddress) as ID, " +
                        " Si.StationPlace as Name , " +
                        " '0' as ParentID, " +
                        " 'false' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num " +
                     " From Station_Info as Si " +
                     " Union " +
                     " Select 'H'+ Convert(varchar,Shi.StationHeadID) as ID, " +
                        " Shi.StationHeadPlace as Name, " +
                        " 'S'+Convert(varchar,Shi.StationAddress) as ParentID, " +
                        " 'true' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num  " +
                     " From Station_Head_Info as Shi";

            return dba.GetDataSet(strSQL);
        }

        #endregion

        //#region【方法：根据探头的编号获取探头的ID】

        //private DataSet GetStationHeadID(string strStationAddress, string strStaHeadAddress)
        //{
        //    strSQL = " Select StationHeadID From Station_Head_Info Where StationAddress = " + strStationAddress + " and StationHeadAddress = " + strStaHeadAddress;
        //    return dba.GetDataSet(strSQL);
        //}

        //#endregion


        #region【方法：保存区域信息】

        public int SaveTerSet(int intTerritorialID, int intStationHeadID, int intIsTerriorialEnter)
        {
            SqlParameter[] para = { new SqlParameter("@TerritorialID",SqlDbType.Int),
                                    new SqlParameter("@StationHeadID",SqlDbType.Int),
                                    new SqlParameter("@IsTerriorialEnter",SqlDbType.Bit),
                                    new SqlParameter("@ID",SqlDbType.Int)
            };
            para[0].Value = intTerritorialID;
            para[1].Value = intStationHeadID;
            para[2].Value = intIsTerriorialEnter;
            para[3].Value = (intTerritorialID.ToString() + intStationHeadID.ToString()).GetHashCode();

            return dba.ExecuteSql("A_TerSet_Insert", para);
        }

        #endregion

        #region【方法：更改区域信息】

        public int UpDateTerSet(int intTerritorialID,string strWhere)
        {
            SqlParameter[] para = { new SqlParameter("@TerritorialID",SqlDbType.Int),
                                    new SqlParameter("@Where",SqlDbType.VarChar,3000)
            };
            para[0].Value = intTerritorialID;
            para[1].Value = strWhere;

            return dba.ExecuteSql("A_TerSet_Update", para);
        }

        #endregion

        #region【方法：根据区域ID获取探头信息】

        public DataSet GetTerSet_StaHead(int intTerID)
        {
            strSQL = " Select 'S'+ CONVERT(varchar,Si.StationAddress) as ID, " +
                        " Si.StationPlace as Name , " +
                        " '0' as ParentID, " +
                        " 'false' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num " +
                     " From Station_Info as Si Left Join Territorial_Set as Ts On Si.StationID=Ts.StationID " +
                     " Where Ts.TerritorialID = " + intTerID.ToString() +
                     " Union " +
                     " Select 'H'+ Convert(varchar,Shi.StationHeadID) as ID, " +
                        " Shi.StationHeadPlace as Name, " +
                        " 'S'+Convert(varchar,Shi.StationAddress) as ParentID, " +
                        " 'true' as IsChild , " +
                        " 'false' as IsUserNum , " +
                        " 0 as Num  " +
                     " From Station_Head_Info as Shi Left Join Territorial_Set as Ts On Shi.StationHeadID=Ts.StationHeadID " +
                     " Where Ts.TerritorialID = " + intTerID.ToString();
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：根据区域ID获取区域口信息】

        public DataSet GetTerriorialEnter(int intTerID)
        {
            strSQL = " Select  'H'+ Convert(varchar,Shi.StationHeadID) as ID,'S'+Convert(varchar, Shi.StationAddress) as ParentID " +
                     " From Territorial_Set as Ts left join Station_Head_Info as Shi on Ts.StationHeadID=Shi.StationHeadID " +
                            " left join Station_Info as Si on Ts.StationID=Si.StationID " +
                     " Where Ts.IsTerriorialEnter=1 And Ts.TerritorialID = " + intTerID.ToString();

            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：删除 区域范围】

        public int DeleteTerSet(string strTerSetID)
        {
            strSQL = "Delete From Territorial_Set Where " + strTerSetID;
            return dba.ExecuteSql(strSQL);
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
