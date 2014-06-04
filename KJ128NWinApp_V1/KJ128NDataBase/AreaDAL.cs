using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
    public class AreaDAL
    {
        private DBAcess dba = new DBAcess();

        #region [ ����: ɾ�������� ]

        public void DeleteStationHead(int intValue)
        {
            string deleteString = string.Format(" delete from Territorial_Set where  StationHeadID={0}", intValue);
            dba.ExecuteSql(deleteString);
        }

        #endregion

        #region [ ����: ɾ�������� ]

        public int DeleteStation(int intValue)
        {
            string deleteString = string.Format(" delete from Territorial_Set where StationID={0}", intValue);
            return dba.ExecuteSql(deleteString);
        }

        #endregion

        #region [ KJ128N_TerSet_Head_Table ]

        public DataSet GetTerSetHeadTable(int temp_TerID)
        {
            string strSql = string.Format("select * from KJ128N_TerSet_Head_Table where TerritorialID={0}", temp_TerID);
            return dba.GetDataSet(strSql);
        }

        #endregion

        #region [ ����: KJ128N_Station_Info_Select_TreeView ]

        public DataSet GetStationInfoTreeView()
        {
            return dba.GetDataSet("KJ128N_Station_Info_Select_TreeView", null);
        }

        #endregion

        #region [ ����: �������� ]

        public int EditArea(int id, int intSta, int intHead, int isTerrEnter)
        {
            string insertString = string.Format("insert into Territorial_Set(TerritorialID,StationID,StationHeadID,IsTerriorialEnter) values({0},{1},{2},{3})",
                        id, intSta, intHead, isTerrEnter);
            return dba.ExecuteSql(insertString);
        }

        #endregion

        #region [ ����: ɾ���������� ]

        public int RemoveAreaSet(int int_TerSet)
        {
            string deleteString = string.Format(" delete from Territorial_Set where TerritorialSetID={0}", int_TerSet);
            return dba.ExecuteSql(deleteString);
        }

        #endregion

        #region [ ����: select * from KJ128N_TerInfo_Table ]

        public DataSet GetTreInfoTable(string strTerInfoName)
        {
            string sqlString = string.Format("select * from KJ128N_TerInfo_Table where ��������='{0}'", strTerInfoName);
            return dba.GetDataSet(sqlString);
        }

        #endregion

        #region [ ����: KJ128N_TerType_Table ]

        public DataSet GetKJ128NTerTypeTable(string strTerTypeName)
        {
            string sqlString = string.Format("select * from KJ128N_TerType_Table where �������='{0}'", strTerTypeName);
            return dba.GetDataSet(sqlString);
        }

        #endregion

        //string.Format("select * from KJ128N_TerType_Table where �������='{0}'",

        #region [ ����: ��� ������Ϣ ]
        public int SaveTerInfoData(string TerName,int TerTypeID,byte IsEnable,string Instruction,string Remark)
        {
            string SaveString;
            if (TerTypeID == 0)
            {
                SaveString = string.Format(
                    "if(not exists(select 1 from Territorial_Info where TerritorialName='" + TerName + "')) "
                    + " begin "
                    + " insert into Territorial_Info(TerritorialName,TerritorialTypeID,IsEnable,Instruction,Remark) values('{0}',null,{1},'{2}','{3}')"
                    + " end",
                 TerName, IsEnable, Instruction, Remark);
            }
            else
            {
                SaveString = string.Format(
                    "if(not exists(select 1 from Territorial_Info where TerritorialName='" + TerName + "')) "
                    + " begin"
                    + " insert into Territorial_Info(TerritorialName,TerritorialTypeID,IsEnable,Instruction,Remark) values('{0}',{1},{2},'{3}','{4}')"
                    + " end",
                    TerName, TerTypeID, IsEnable, Instruction, Remark);
            }
            return dba.ExecuteSql(SaveString);
        }
        #endregion

        #region [ ����: �޸� ������Ϣ ]
        public int UpDateTerInfo(int TerInfoID,string TerName, int TerTypeID, byte IsEnable, string Instruction, string Remark)
        {
            string  UpDateString;
            if (TerTypeID == 0)
            {
                UpDateString = string.Format(
                    " if(not exists(select TerritorialName from Territorial_Info "
                    + " where TerritorialID<>" + TerInfoID.ToString() + " and TerritorialName='" + TerName + "')) "
                    + " begin"
                    + " update Territorial_Info set TerritorialName='{0}',TerritorialTypeID=null,IsEnable={1},Instruction='{2}',Remark='{3}' where TerritorialID={4}"
                    + " end",
                    TerName, IsEnable, Instruction, Remark, TerInfoID);
            }
            else
            {
                UpDateString = string.Format(
                    " if(not exists(select TerritorialName from Territorial_Info "
                    + " where TerritorialID<>" + TerInfoID.ToString() + "and TerritorialName='" + TerName + "')) "
                    + " begin"
                    + " update Territorial_Info set TerritorialName='{0}',TerritorialTypeID={1},IsEnable={2},Instruction='{3}',Remark='{4}' where TerritorialID={5}"
                    + " end",
                    TerName, TerTypeID, IsEnable, Instruction, Remark, TerInfoID);
            }
            return dba.ExecuteSql(UpDateString);
        }
        #endregion

        #region [ ����: ɾ�� ������Ϣ ]
        public int DeleteTerInfo(int TerInfoID)
        {
            string DelString = string.Format("delete from Territorial_Info where TerritorialID={0}", TerInfoID);
            return dba.ExecuteSql(DelString);
        }
        #endregion

        #region [ ����: ��� ������� ]
        public int SaveTerTypeData(string TypeName, byte IsAlarm, string Remark)
        {

            string SaveString = string.Format(
            "if(not exists(select 1 from Territorial_Type where TypeName='" + TypeName + "')) "
            + " begin "
            + " insert into Territorial_Type(TypeName,IsAlarm,Remark) values('{0}',{1},'{2}')"
            + " end ", TypeName, IsAlarm, Remark);
            return dba.ExecuteSql(SaveString);
        }
        #endregion

        #region [ ����: �޸� ������Ϣ ]
        public int UpDateTerType(int TerTypeID, string TypeName, byte IsAlarm, string Remark)
        {
            string UpDateString = string.Format(
                " if(not exists(select TypeName from Territorial_Type where TerritorialTypeID<>" + TerTypeID.ToString() + " and TypeName='" + TypeName + "')) "
                + " begin "
                + " update Territorial_Type set TypeName='{0}',IsAlarm={1},Remark='{2}' where TerritorialTypeID={3}"
                + " end", TypeName, IsAlarm, Remark, TerTypeID);
            return dba.ExecuteSql(UpDateString);
        }
        #endregion

        #region [ ����: ɾ�� ������Ϣ ]
        public int DeleteTerType(int TerTypeID)
        {
            string DelString = string.Format("delete from Territorial_Type where TerritorialTypeID="+
                "(select TerritorialTypeID from Territorial_Type "+
                "where TerritorialTypeID={0} and TypeName <> '��������' and TypeName <> '�ص�����')"
                , TerTypeID);
            return dba.ExecuteSql(DelString);
        }
        #endregion

        #region [ ����: ��ȡ ��������(DataSet) ]
        //��ȡ ��������(DataSet)
        /// <summary>
        /// ��ȡ ��������(DataSet)
        /// </summary>
        /// <returns>������������(DataSet)</returns>
        public DataSet GetTerTypeDataSet()
        {
            return dba.GetDataSet("select TerritorialTypeID,TypeName from Territorial_Type");
        }
        #endregion

        #region [ ����: ��ȡ ��������(DataSet) ]
        //��ȡ ��������(DataSet)
        /// <summary>
        /// ��ȡ ��������(DataSet)
        /// </summary>
        /// <returns>������������(DataSet)</returns>
        public DataSet GetTerNameDataSet()
        {
            return dba.GetDataSet("select TerritorialID,TerritorialName from Territorial_Info");
        }
        #endregion

        #region [ ����: ����������𣬷�����������(DataTable) ]
        public DataTable GetTerTypeSetTable(int TerTypeID)
        {
            string strsql=string.Format("select * from KJ128N_TerTypeSet_Table where TerritorialTypeID={0}",TerTypeID);
            return dba.GetDataSet(strsql).Tables[0];
        }
        #endregion

        #region [ ����: �����������ƣ�������������(DataTable) ]
        public DataTable GetTerNameSetTable(int TerNameID)
        {
            string strsql = string.Format("select * from KJ128N_TerTypeSet_Table where TerritorialID={0}", TerNameID);
            return dba.GetDataSet(strsql).Tables[0];
        }
        #endregion

        #region [ ����: ���������������� ]
        public DataTable GetTerSetTable()
        {
            return dba.GetDataSet("select * from KJ128N_TerTypeSet_Table").Tables[0];
        }
        #endregion

        #region [ ����: ����������Ϣ ]
        public DataTable GetTerInfoTable()
        {
            using (DataSet ds = dba.GetDataSet("select * from KJ128N_TerInfo_Table"))
            {
                if (ds != null)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region [ ����: ����������� ]
        public DataTable GetTerTypeTable()
        {
            using (DataSet ds = dba.GetDataSet("select * from KJ128N_TerType_Table"))
            {
                if (ds != null)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region [ ����: ����������Ϣ ]
        //int pageIndex,int pageSize,string where//View_GetRTDeptInfo
        public DataSet GetTerSet(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion
    }
}
