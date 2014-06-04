using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
    public class StationDAL
    {

        #region [ ���� ]

        DBAcess dba = new DBAcess();
        DbHelperSQL DB = new DbHelperSQL();

        #endregion

        #region [ ����: ��վ��Ϣ���� ]

        #region �޸ķ�վ��Ϣ

        public int updateStation(int sAddress, string place, string tel, int typeId, string typeName, int group)
        {
            string sqlString = string.Format("update Station_Info set StationPlace='{0}',StationTel='{1}',StationTypeID={2},StationType='{3}'"+
                ",EditBaseInfo=2,StationGroup={4} where StationAddress={5}", place, tel, typeId, typeName, group, sAddress);
            return dba.ExecuteSql(sqlString);
        }

        #endregion

        #region ɾ����վ��Ϣ(�Ƚ���վ�����н�����ɾ��)

        public int deleteStation(int stationAddress)
        {
           // string sqlString = string.Format("Delete From RT_InOUtStation Where StationAddress = {0}", stationAddress);
           // dba.ExecuteSql(sqlString);
           // string temString="";
           //temString+="Delete From RT_InStationHeadInfo";
           // temString+="where ";
           // temString += "StationHeadID in(";
           // temString+="Select RTI.StationHeadID from RT_InStationHeadInfo RTI";
           // temString+="left join dbo.Station_Head_Info SHI On RTI.StationHeadID=SHI.StationHeadID";
           // string temStationAddress = string.Format("where SHI.StationAddress={0}", stationAddress);
           // temString += temStationAddress;
           // dba.ExecuteSql(sqlString);
            
            string sqlString = string.Format("delete from Station_Info where StationAddress = {0}", stationAddress);
            return dba.ExecuteSql(sqlString);
        }

        #endregion

        #region ���յ�ַ�Ż�÷�վ��Ϣreturn DataRow

        public DataRow getStationInfo(int stationAddress)
        {
            string sqlString = string.Format("select * from Station_Info where StationAddress = {0}",stationAddress);
            DataSet ds = dba.GetDataSet(sqlString);
            if (ds.Tables != null && ds.Tables[0].Rows.Count != 0)
            {
                return ds.Tables[0].Rows[0];
            }
            return ds.Tables[0].Rows[0];
        }

        #endregion

        #region �鿴��վ��ַ���Ƿ��Ѵ���

        /// <summary>
        /// �鿴��վ��ַ���Ƿ��Ѵ���
        /// </summary>
        /// <param name="address">��վ��ַ��</param>
        /// <returns>Ӱ�������,-1 ִ��ʧ��</returns>
        public int existsStationAddress(int address)
        {
            string existsString = string.Format("select count(StationAddress) from Station_Info where StationAddress = {0}", address);
            DataSet ds = dba.GetDataSet(existsString);
            if (ds!=null && ds.Tables.Count>0)
            {
                string str = ds.Tables[0].Rows[0][0].ToString();
                if (str != string.Empty)
                {
                    return int.Parse(str);
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        #endregion

        #region ��ӷ�վ��Ϣ����Ӹ÷�վ��Ĭ�Ͻ�����

        #region ��ӷ�վ��6��Ĭ�Ͻ����� return int

        public int insertStationAddress(string addressList, string place, string tel, int typeId, string typeName, int group)
        {
            SqlParameter[] para = { new SqlParameter("@str",SqlDbType.VarChar,3000),
                                    new SqlParameter("@StationPlace",SqlDbType.NVarChar,30),        //��վ��Ϣ
                                    new SqlParameter("@StationTel",SqlDbType.NVarChar,20),
                                    new SqlParameter("@StationTypeID",SqlDbType.Int),
                                    new SqlParameter("@StationType",SqlDbType.NVarChar,10),
                                    new SqlParameter("@StationState",SqlDbType.Int),
                                    new SqlParameter("@EditBaseInfo",SqlDbType.Int),    
                                    new SqlParameter("@StationGroup",SqlDbType.Int)                        
            };
            para[0].Value = addressList;
            // ��վ��Ϣ
            para[1].Value = place;
            para[2].Value = tel;
            para[3].Value = typeId;
            para[4].Value = typeName;
            para[5].Value = -1;
            para[6].Value = 1;
            para[7].Value = group;
            return dba.ExecuteSql("AddStationHead", para);
        }

        #endregion

        // �������ʱ����Ѿ����ڵķ�վ��ַ
        public DataTable getExistsStationAddress(string addressAll)
        {
            string insertString = string.Format("SELECT col FROM Array_Split('{0}',',') where col in (select StationAddress from Station_Info)", addressAll);
            DataSet ds = dba.GetDataSet(insertString);
            if (ds != null)
                return dba.GetDataSet(insertString).Tables[0];
            else
                return new DataTable();
        }

        #endregion

        #region ����������

        #region id��ý�������Ϣ return DataRow

        public DataRow getStationHeadRowInfo(int id)
        {
            string sqlString = string.Format("select * from Station_Head_Info where StationHeadID = {0}", id);

            DataSet ds = dba.GetDataSet(sqlString);
            if (ds.Tables != null && ds.Tables[0].Rows.Count != 0)
            {
                return ds.Tables[0].Rows[0];
            }
            return ds.Tables[0].Rows[0];
        }

        #endregion

        #region �鿴��������ַ���Ƿ��Ѵ���

        /// <summary>
        /// �鿴��������ַ���Ƿ��Ѵ���
        /// </summary>
        /// <param name="addressHead">��������ַ��</param>
        /// <returns>Ӱ�������,-1 ִ��ʧ��</returns>
        public int existsStationHeadAddress(int addressHead,int address)
        {
            string existsString = string.Format("select count(StationHeadAddress) from Station_Head_Info where StationHeadAddress = {0} and StationAddress = {1}", addressHead,address);
            DataSet ds = dba.GetDataSet(existsString);
            if (ds != null && ds.Tables.Count > 0)
            {
                string str = ds.Tables[0].Rows[0][0].ToString();
                try
                {
                    if (str != string.Empty)
                    {
                        return int.Parse(str);
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            return 0;
        }

        #endregion

        #region ��ӵ���������

        public int insertStationHead(int stationAddress, int shAddress, string shPlace, string shTel, int shTypeId, string shType, float shx, float shy, int shState, string antennaA, string antennaB, string remark)
        {
            string insertString = string.Format("if not exists(select 1 from Station_Head_Info"
                +" where StationAddress={0} and StationHeadAddress={1})"
                +" begin insert into Station_Head_Info(StationAddress,StationHeadAddress,StationHeadPlace,StationHeadTel"
                + ",StationHeadTypeID,StationHeadType,StationHeadX,StationHeadY,StationHeadState,EditBaseInfo,AntennaA"
                + ",AntennaB,Remark) values({0},{1},'{2}','{3}',{4},'{5}',{6},{7},{8},1,'{9}','{10}','{11}')"
                + " end",
                stationAddress, shAddress, shPlace, shTel, shTypeId, shType, shx, shy, shState, antennaA, antennaB, remark);
            return dba.ExecuteSql(insertString);

        }

        #endregion

        #region �޸Ľ�����

        public int updateStationHead(int headId, string shPlace, string shTel, int shTypeId, string shType, string antennaA, string antennaB, string remark)
        {
            string updateString = string.Format("update Station_Head_Info set StationHeadPlace='{0}',StationHeadTel='{1}'"
                + ",StationHeadTypeID={2},StationHeadType='{3}',EditBaseInfo = 2,AntennaA='{4}',AntennaB='{5}',Remark='{6}' where StationHeadID = {7}",
                 shPlace, shTel, shTypeId, shType, antennaA, antennaB, remark, headId);
            return dba.ExecuteSql(updateString);
        }

        #endregion

        #region ɾ��������

        // ɾ������������
        public int deletdStationHead(int id)
        {
            string sqlString = string.Format("delete from Station_Head_Info where StationHeadID = {0}", id);

            SqlParameter[] sqlParmeter = new SqlParameter[1];
            sqlParmeter[0] = new SqlParameter("@StationHeadID", SqlDbType.Int);
            sqlParmeter[0].Direction = ParameterDirection.Input;
            sqlParmeter[0].Value = id;

            return dba.ExecuteSql("KJ128N_Delete_StationHead", sqlParmeter);
           
        }

        // ɾ���÷�վ�����н�����
        public int deleteStationHeads(int stationAddress)
        {
            string sqlString = string.Format("delete from Station_Head_Info where StationAddress = {0}", stationAddress);

            return dba.ExecuteSql(sqlString);
        }

        #endregion
        
        #endregion

        #region ���ָ����վ�Ľ�����

        public DataTable getStationHeadInfoAll(int stationAddress)
        {
            //string sqlString = string.Format("select StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace from Station_Head_Info where EditBaseInfo>-1 and StationAddress={0} order by StationAddress,StationHeadAddress",stationAddress);
            string sqlString = string.Format("select StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace from Station_Head_Info where EditBaseInfo>-1 and StationAddress={0} order by StationHeadAddress", stationAddress);
            return dba.GetDataSet(sqlString).Tables[0];
        }

        #endregion

        #region ��� ��վ�Ͷ�Ӧ�Ľ���������Ϣ 

        public DataSet getStationHeadInfo(int pageIndex,int pageSize)
        {
            SqlParameter[] para={new SqlParameter("@pageIndex",SqlDbType.Int),
                                new SqlParameter("@pageSize",SqlDbType.Int)
            };
            para[0].Value = pageIndex;
            para[1].Value = pageSize;
            return dba.ExecuteSqlDataSet("PROC_GetStation_Info",para);
        }
        
        #endregion

        #endregion

        #region [ ����: ��վʵʱ��Ϣ��ʾ ]

        #region ��ȡ��վʵʱ��Ϣ

        public DataSet GetRTStationInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("PROC_GetRTStationInfo", para);
        }

        // ��վ��������Ϣ
        public DataSet GetRTStationHeadInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("PROC_GetRTStationHeadInfo", para);
        }

        // ��ʾʱ��ȡ��վ��������Ϣ
        public DataSet GetRTDisplayStationHeadInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("PROC_GetRTDisplayStationHeadInfo", para);
        }

        #endregion

        #region ������Ϣ

        public DataSet GetRTDeptSmallInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("PROC_GetRTDeptSmallInfo", para);
        }

        #endregion

        #endregion

        #region ��������Ӽ��ж��Ƿ����

        public int addDirectionalAntenna(string detectionInfo, string directional)
        {
            string tmpString = string.Format("insert into CodeSender_DirectionalAntenna(DetectionInfo,Directional) " +
            "select DetectionInfo,Directional from " +
            "(select '{0}' as DetectionInfo,'{1}' Directional,count(1) as ct from CodeSender_DirectionalAntenna " +
            "where DetectionInfo = '{0}') as tmp where ct<1", detectionInfo, directional);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region �������������޸�

        public int upDateDirectionalAntenna(int CodeSenderDirlID, string Directional)
        {
            string tmpString = string.Format("update CodeSender_DirectionalAntenna set Directional='{0}'  where CodeSenderDirlID = {1}", Directional, CodeSenderDirlID);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region ������������ɾ��

        public int removeDirectionalAntenna(int CodeSenderDirlID)
        {
            string tmpString = string.Format("delete from CodeSender_DirectionalAntenna where CodeSenderDirlID = {0}", CodeSenderDirlID);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region [ ����: �����Թ��� ]

        #region FrmDirectional��÷�վ�ͽ���������

        public DataSet GetStationAndHead()
        {
            return dba.GetDataSet("select StationAddress,StationPlace from Station_Info;select StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace,AntennaA,AntennaB " +
                "from Station_Head_Info order by StationAddress,StationHeadAddress");
        }

        #endregion

        #region �жϷ������Ƿ����

        public int existsDirectional(string dStr)
        {
            string tmpString = string.Format("select count(DetectionInfo) from CodeSender_Directional where DetectionInfo='{}'", dStr);
            return dba.ExistsSql(tmpString);
        }

        #endregion

        #region ��������������Ӽ��ж��Ƿ����

        public int addDirectional(string detectionInfo, string directional)
        {
            string tmpString = string.Format("insert into CodeSender_Directional(DetectionInfo,Directional) " +
            "select DetectionInfo,Directional from " +
            "(select '{0}' as DetectionInfo,'{1}' Directional,count(1) as ct from CodeSender_Directional " +
            "where DetectionInfo = '{0}') as tmp where ct<1", detectionInfo, directional);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region ������ɾ��

        public int removeDirectional(int CodeSenderDirlID)
        {
            string tmpString = string.Format("delete from CodeSender_Directional where CodeSenderDirlID = {0}", CodeSenderDirlID);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region �������޸�

        public int upDateDirectional(int CodeSenderDirlID, string Directional)
        {
            string tmpString = string.Format("update CodeSender_Directional set Directional='{0}'  where CodeSenderDirlID = {1}", Directional, CodeSenderDirlID);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #endregion

        #region [ ����: �õ�������վ��Ϣ ]

        public DataSet GetOutWellStationInfo(out string strErr)
        {
            return DB.RunProcedureByDataSet("KJ128N_Station_OutStationType_Query", "DS", out strErr);
        }
        #endregion

    }
}
