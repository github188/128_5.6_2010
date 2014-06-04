using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KJ128NDataBase
{
    public class A_StationDAL
    {
        #region [ 声明 ]

        DBAcess dba = new DBAcess();
        DbHelperSQL DB = new DbHelperSQL();

        private string strSQL;

        #endregion

        #region [ 方法: 分站信息管理 ]

        #region 修改分站信息

        public int updateStation(int sAddress, string place, string tel, int typeId, string typeName, int group)
        {
            string sqlString = string.Format("update Station_Info set StationPlace='{0}',StationTel='{1}',StationTypeID={2},StationType='{3}'" +
                ",EditBaseInfo=2,StationGroup={4} where StationAddress={5}", place, tel, typeId, typeName, group, sAddress);
            return dba.ExecuteSql(sqlString);
        }

        #endregion

        #region 删除分站信息(先将分站的所有接收器删除)

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

        #region 接收地址号获得分站信息return DataRow

        public DataRow getStationInfo(int stationAddress)
        {
            string sqlString = string.Format("select * from Station_Info where StationAddress = {0}", stationAddress);
            DataSet ds = dba.GetDataSet(sqlString);
            if (ds.Tables != null && ds.Tables[0].Rows.Count != 0)
            {
                return ds.Tables[0].Rows[0];
            }
            return null;
        }

        #endregion

        #region 查看分站地址号是否已存在

        /// <summary>
        /// 查看分站地址号是否已存在
        /// </summary>
        /// <param name="address">分站地址号</param>
        /// <returns>影响的行数,-1 执行失败</returns>
        public int existsStationAddress(int address)
        {
            string existsString = string.Format("select count(StationAddress) from Station_Info where StationAddress = {0}", address);
            DataSet ds = dba.GetDataSet(existsString);
            if (ds != null && ds.Tables.Count > 0)
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

        #region 添加分站信息并添加该分站的默认接收器

        #region 添加分站和6个默认接收器 return int

        public int insertStationAddress(string addressList, string place, string tel, int typeId, string typeName, int group)
        {
            SqlParameter[] para = { new SqlParameter("@str",SqlDbType.VarChar,3000),
                                    new SqlParameter("@StationPlace",SqlDbType.NVarChar,30),        //分站信息
                                    new SqlParameter("@StationTel",SqlDbType.NVarChar,20),
                                    new SqlParameter("@StationTypeID",SqlDbType.Int),
                                    new SqlParameter("@StationType",SqlDbType.NVarChar,10),
                                    new SqlParameter("@StationState",SqlDbType.Int),
                                    new SqlParameter("@EditBaseInfo",SqlDbType.Int),    
                                    new SqlParameter("@StationGroup",SqlDbType.Int)                        
            };
            para[0].Value = addressList;
            // 分站信息
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

        // 批量添加时获得已经存在的分站地址
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

        #region 接收器操作

        #region id获得接收器信息 return DataRow

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

        #region 查看接收器地址号是否已存在

        /// <summary>
        /// 查看接收器地址号是否已存在
        /// </summary>
        /// <param name="addressHead">接收器地址号</param>
        /// <returns>影响的行数,-1 执行失败</returns>
        public int existsStationHeadAddress(int addressHead, int address)
        {
            string existsString = string.Format("select count(StationHeadAddress) from Station_Head_Info where StationHeadAddress = {0} and StationAddress = {1}", addressHead, address);
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

        #region 添加单个接收器

        public int insertStationHead(int stationAddress, int shAddress, string shPlace, string shTel, int shTypeId, string shType, float shx, float shy, int shState, string antennaA, string antennaB, string remark,string no)
        {
            //string insertString = string.Format("if not exists(select 1 from Station_Head_Info"
            //    + " where StationAddress={0} and StationHeadAddress={1})"
            //    + " begin insert into Station_Head_Info(StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace,StationHeadTel"
            //    + ",StationHeadTypeID,StationHeadType,StationHeadX,StationHeadY,StationHeadState,EditBaseInfo,AntennaA"
            //    + ",AntennaB,Remark,BreakTime,StationHeadNO) values({13},{0},{1},'{2}','{3}',{4},'{5}',{6},{7},{8},1,'{9}','{10}','{11}','{12}','{13}')"
            //    + " end",
            //    stationAddress, shAddress, shPlace, shTel, shTypeId, shType, shx, shy, shState, antennaA, antennaB, remark, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), stationAddress.ToString() + shAddress.ToString(), no);
            //return dba.ExecuteSql(insertString);

            string insertString = string.Format("if not exists(select 1 from Station_Head_Info"
                + " where StationAddress={0} and StationHeadAddress={1})"
                + " begin insert into Station_Head_Info(StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace,StationHeadTel"
                + ",StationHeadTypeID,StationHeadType,StationHeadX,StationHeadY,StationHeadState,EditBaseInfo,AntennaA"
                + ",AntennaB,Remark,BreakTime) values({13},{0},{1},'{2}','{3}',{4},'{5}',{6},{7},{8},2000,'{9}','{10}','{11}','{12}')"
                + " end",
                stationAddress, shAddress, shPlace, shTel, shTypeId, shType, shx, shy, shState, antennaA, antennaB, remark, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), stationAddress.ToString() + shAddress.ToString());
            return dba.ExecuteSql(insertString);

        }

        #endregion

        #region[是否重复编号]
        public bool IsExistsStationHeadNO(string no)
        {
            string sqlstr = "select count(1) from Station_Head_Info where StationHeadNO=" + no;
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

        #region 修改接收器

        public int updateStationHead(string strStationAddress,string strStaHeadAddress, string shPlace, string shTel, int shTypeId, string shType, string antennaA, string antennaB, string remark)
        {
            strSQL = "update Station_Head_Info set StationHeadPlace='" + shPlace + "',StationHeadTel='" + shTel + "'" +
                ",StationHeadTypeID=" + shTypeId + ",StationHeadType='" + shType + "',EditBaseInfo = 2,AntennaA='" + antennaA +
                "',AntennaB='" + antennaB + "',Remark='" + remark + "' where StationAddress = " + strStationAddress + " And StationHeadAddress=" + strStaHeadAddress;

            return dba.ExecuteSql(strSQL);
        }

        #endregion

        #region 删除接收器

        // 删除单个接收器
        public int deletdStationHead(int id)
        {
            string sqlString = string.Format("delete from Station_Head_Info where StationHeadID = {0}", id);

            SqlParameter[] sqlParmeter = new SqlParameter[1];
            sqlParmeter[0] = new SqlParameter("@StationHeadID", SqlDbType.Int);
            sqlParmeter[0].Direction = ParameterDirection.Input;
            sqlParmeter[0].Value = id;

            return dba.ExecuteSql("KJ128N_Delete_StationHead", sqlParmeter);

        }

        // 删除该分站的所有接收器
        public int deleteStationHeads(int stationAddress)
        {
            string sqlString = string.Format("delete from Station_Head_Info where StationAddress = {0}", stationAddress);

            return dba.ExecuteSql(sqlString);
        }

        #endregion

        #endregion

        #region 获得指定分站的接收器

        public DataTable getStationHeadInfoAll(int stationAddress)
        {
            //string sqlString = string.Format("select StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace from Station_Head_Info where EditBaseInfo>-1 and StationAddress={0} order by StationAddress,StationHeadAddress",stationAddress);
            string sqlString = string.Format("select StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace from Station_Head_Info where EditBaseInfo>-1 and StationAddress={0} order by StationHeadAddress", stationAddress);
            return dba.GetDataSet(sqlString).Tables[0];
        }

        #endregion

        #region 获得 分站和对应的接收器号信息

        public DataSet getStationHeadInfo(int pageIndex, int pageSize)
        {
            SqlParameter[] para ={new SqlParameter("@pageIndex",SqlDbType.Int),
                                new SqlParameter("@pageSize",SqlDbType.Int)
            };
            para[0].Value = pageIndex;
            para[1].Value = pageSize;
            return dba.ExecuteSqlDataSet("PROC_GetStation_Info", para);
        }

        #endregion

        #endregion

        #region [ 方法: 分站实时信息显示 ]

        #region 获取分站实时信息

        public DataSet GetRTStationInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("PROC_GetRTStationInfo", para);
        }

        // 分站接收器信息
        public DataSet GetRTStationHeadInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("PROC_GetRTStationHeadInfo", para);
        }

        // 显示时获取分站接收器信息
        public DataSet GetRTDisplayStationHeadInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("PROC_GetRTDisplayStationHeadInfo", para);
        }

        #endregion

        #region 部门信息

        public DataSet GetRTDeptSmallInfo(SqlParameter[] para)
        {
            return dba.ExecuteSqlDataSet("PROC_GetRTDeptSmallInfo", para);
        }

        #endregion

        #endregion

        #region 方向性添加及判断是否存在

        public int addDirectionalAntenna(string detectionInfo, string directional)
        {
            string tmpString = string.Format("insert into CodeSender_DirectionalAntenna(DetectionInfo,Directional) " +
            "select DetectionInfo,Directional from " +
            "(select '{0}' as DetectionInfo,'{1}' Directional,count(1) as ct from CodeSender_DirectionalAntenna " +
            "where DetectionInfo = '{0}') as tmp where ct<1", detectionInfo, directional);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region 接收器方向性修改

        public int upDateDirectionalAntenna(int CodeSenderDirlID, string Directional)
        {
            string tmpString = string.Format("update CodeSender_DirectionalAntenna set Directional='{0}'  where CodeSenderDirlID = {1}", Directional, CodeSenderDirlID);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region 接收器方向性删除

        public int removeDirectionalAntenna(int CodeSenderDirlID)
        {
            string tmpString = string.Format("delete from CodeSender_DirectionalAntenna where CodeSenderDirlID = {0}", CodeSenderDirlID);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region [ 方法: 方向性管理 ]

        #region FrmDirectional获得分站和接收器数据

        public DataSet GetStationAndHead()
        {
            return dba.GetDataSet("select StationAddress,StationPlace from Station_Info;select StationHeadID,StationAddress,StationHeadAddress,StationHeadPlace,AntennaA,AntennaB " +
                "from Station_Head_Info order by StationAddress,StationHeadAddress");
        }

        #endregion

        #region 判断方向性是否存在

        public int existsDirectional(string dStr)
        {
            string tmpString = string.Format("select count(DetectionInfo) from CodeSender_Directional where DetectionInfo='{}'", dStr);
            return dba.ExistsSql(tmpString);
        }

        #endregion

        #region 接收器方向性添加及判断是否存在

        public int addDirectional(string detectionInfo, string directional)
        {
            string tmpString = string.Format("insert into CodeSender_Directional(DetectionInfo,Directional) " +
            "select DetectionInfo,Directional from " +
            "(select '{0}' as DetectionInfo,'{1}' Directional,count(1) as ct from CodeSender_Directional " +
            "where DetectionInfo = '{0}') as tmp where ct<1", detectionInfo, directional);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region 方向性删除

        public int removeDirectional(int CodeSenderDirlID)
        {
            string tmpString = string.Format("delete from CodeSender_Directional where CodeSenderDirlID = {0}", CodeSenderDirlID);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #region 方向性修改

        public int upDateDirectional(int CodeSenderDirlID, string Directional)
        {
            string tmpString = string.Format("update CodeSender_Directional set Directional='{0}'  where CodeSenderDirlID = {1}", Directional, CodeSenderDirlID);
            return dba.ExecuteSql(tmpString);
        }

        #endregion

        #endregion

        #region [ 方法: 得到出井分站信息 ]

        public DataSet GetOutWellStationInfo(out string strErr)
        {
            return DB.RunProcedureByDataSet("KJ128N_Station_OutStationType_Query", "DS", out strErr);
        }
        #endregion

        #region【方法：保存分站信息】

        public int SaveStationInfo(int intStationAddress, string strPlace, string strTel, int intTypeID, string strTypeName, int intGroup, int intStationModel)
        {
            SqlParameter[] para = { new SqlParameter("@StationAddress",SqlDbType.Int),
                                    new SqlParameter("@StationPlace",SqlDbType.NVarChar,30),        //分站信息
                                    new SqlParameter("@StationTel",SqlDbType.NVarChar,20),
                                    new SqlParameter("@StationTypeID",SqlDbType.Int),
                                    new SqlParameter("@StationType",SqlDbType.NVarChar,10),
                                    new SqlParameter("@StationState",SqlDbType.Int),
                                    new SqlParameter("@EditBaseInfo",SqlDbType.Int),    
                                    new SqlParameter("@StationGroup",SqlDbType.Int),
                                    new SqlParameter("@StationModel",SqlDbType.Int),
                                    new SqlParameter("@BreakTime",SqlDbType.DateTime)
            };
            para[0].Value = intStationAddress;
            para[1].Value = strPlace;
            para[2].Value = strTel;
            para[3].Value = 1;
            para[4].Value = strTypeName;
            para[5].Value = intTypeID;
            para[6].Value = 1;
            para[7].Value = intGroup;
            para[8].Value = intStationModel;
            para[9].Value = DateTime.Now;

            return dba.ExecuteSql("A_StationInfo_Add", para);
        }

        #endregion

        #region【方法：修改分站信息】

        public int UpDateStationInfo(int intStationAddress, string strPlace, string strTel, int intTypeID, string strTypeName, int intGroup, int intStationModel)
        {
            SqlParameter[] para = { new SqlParameter("@StationAddress",SqlDbType.Int),
                                    new SqlParameter("@StationPlace",SqlDbType.NVarChar,30),        //分站信息
                                    new SqlParameter("@StationTel",SqlDbType.NVarChar,20),
                                    new SqlParameter("@StationTypeID",SqlDbType.Int),
                                    new SqlParameter("@StationType",SqlDbType.NVarChar,10),
                                    new SqlParameter("@StationState",SqlDbType.Int),
                                    new SqlParameter("@EditBaseInfo",SqlDbType.Int),    
                                    new SqlParameter("@StationGroup",SqlDbType.Int),
                                    new SqlParameter("@StationModel",SqlDbType.Int)
            };
            para[0].Value = intStationAddress;
            para[1].Value = strPlace;
            para[2].Value = strTel;
            para[3].Value = 1;
            para[4].Value = strTypeName;
            para[5].Value = intTypeID;
            para[6].Value = 1;
            para[7].Value = intGroup;
            para[8].Value = intStationModel;

            return dba.ExecuteSql("A_StationInfo_UpDate", para);
        }

        #endregion

        #region【方法：获取分站的协议号】

        public DataSet GetStationModel(int intStationAddress)
        {
            strSQL = "Select StationModel From Station_Info Where StationAddress = " + intStationAddress;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：查看接收器安装位置是否已存在】

        public int ExistsStationHeadPlace(string strStaHeadPlace)
        {
            strSQL = "Select Count(1) From Station_Head_Info Where  StationHeadPlace ='"+strStaHeadPlace+"' " ;

            DataSet ds = dba.GetDataSet(strSQL);
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
                catch
                {

                }
            }
            return 0;
        }

        #endregion

        #region【方法：获取分站、探头信息（绑定树）】

        public DataSet GetStaHeadInfo()
        {
            strSQL = " Select 'S' + CONVERT(varchar,StationAddress ) as ID,StationPlace as Name ,convert(varchar,0) as ParentID ,'true' as IsChild , 'false' as IsUserNum , 0 as Num " +
                     " From Station_Info " +
                     " Union " +
                     " Select 'H'+convert(varchar,StationHeadAddress) as ID, StationHeadPlace as Name, 'S'+convert(varchar,StationAddress) as ParentID ,'true' as IsChild , 'false' as IsUserNum , 0 as Num " +
                     " From Station_Head_Info";
           return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取分站、探头信息（绑定树）——新增】

        public DataSet GetStaHeadInfo_Binding()
        {
            strSQL = " Select 'S' + CONVERT(varchar,StationAddress ) as ID,StationPlace as Name ,convert(varchar,0) as ParentID ,'false' as IsChild , 'false' as IsUserNum , 0 as Num " +
                     " From Station_Info " +
                     " Union " +
                     " Select 'H'+convert(varchar,StationHeadAddress) as ID, StationHeadPlace as Name, 'S'+convert(varchar,StationAddress) as ParentID ,'true' as IsChild , 'false' as IsUserNum , 0 as Num " +
                     " From Station_Head_Info";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法: 方向性信息】

        public DataSet GetDirectionalInfo(int pageIndex, int pageSize, string where)
        {
            SqlParameter[] para = { new SqlParameter("@tblName",SqlDbType.VarChar,255),
                                    new SqlParameter("@fldName",SqlDbType.VarChar,255),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@IsReCount",SqlDbType.Bit),
                                    new SqlParameter("@OrderType",SqlDbType.Bit),
                                    new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
            };
            para[0].Value = "A_View_GetAllDirectionalAntenna";
            para[1].Value = "CodeSenderDirlID";
            para[2].Value = pageSize;
            para[3].Value = pageIndex;
            para[4].Value = 1;
            para[5].Value = 0;
            para[6].Value = where;

            return dba.ExecuteSqlDataSet("Shine_GetRecordByPage", para);
        }
        #endregion

        #region【方法：获取方向性信息——绑定】

        public DataSet GetDirectionalInfo_Binding(int intCodeSenderDirlID)
        {
            strSQL = " Select * From CodeSender_DirectionalAntenna Where CodeSenderDirlID=" + intCodeSenderDirlID;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：删除 方向性信息】

        /// <summary>
        /// 删除 方向性信息
        /// </summary>
        /// <param name="WorkTypeID">CodeSenderDirlID</param>
        /// <returns>返回影响行数</returns>
        public int DeleteDirectional(string strCodeSenderDirlID)
        {
            strSQL = "Delete From CodeSender_DirectionalAntenna Where " + strCodeSenderDirlID;
            return dba.ExecuteSql(strSQL);

        }
        #endregion


        #region【方法：添加方向性信息】

        public int SaveDirectionalInfo(string strDirectional, int intBeginStationAddress, int intBeginStationHeadAddress, int intEndStationAddress, int intEndStationHeadAddress)
        {
            SqlParameter[] para = { new SqlParameter("@DetectionInfo",SqlDbType.NVarChar,20),
                                    new SqlParameter("@Directional",SqlDbType.NVarChar,50),
                                    new SqlParameter("@BeginStationAddress",SqlDbType.Int),
                                    new SqlParameter("@BeginStationHeadAddress",SqlDbType.Int),
                                    new SqlParameter("@EndStationAddress",SqlDbType.Int),
                                    new SqlParameter("@EndStationHeadAddress",SqlDbType.Int),
                                    new SqlParameter("@CodeSenderDirlID",SqlDbType.Int)
            };
            para[0].Value = intBeginStationAddress.ToString() + "," + intBeginStationHeadAddress.ToString() + ":" + intEndStationAddress.ToString() + "," + intEndStationHeadAddress.ToString();
            para[1].Value = strDirectional;
            para[2].Value = intBeginStationAddress;
            para[3].Value = intBeginStationHeadAddress;
            para[4].Value = intEndStationAddress;
            para[5].Value = intEndStationHeadAddress;
            para[6].Value = strDirectional.GetHashCode();

            return dba.ExecuteSql("A_Directional_Inset", para);
        }

        #endregion

        #region【方法：修改方向性信息】

        public int UpDateDirectionalInfo(string strDirectional, int intBeginStationAddress, int intBeginStationHeadAddress, int intEndStationAddress, int intEndStationHeadAddress)
        {
            SqlParameter[] para = { new SqlParameter("@DetectionInfo",SqlDbType.NVarChar,20),
                                    new SqlParameter("@Directional",SqlDbType.NVarChar,50)
            };
            para[0].Value = intBeginStationAddress.ToString() + "," + intBeginStationHeadAddress.ToString() + ":" + intEndStationAddress.ToString() + "," + intEndStationHeadAddress.ToString();
            para[1].Value = strDirectional;

            return dba.ExecuteSql("A_Directional_UpDate", para);
        }

        #endregion

        #region【方法：验证方向性是否存在】

        public DataSet IsDirectionalBeing(string strDetectionInfo)
        {
            strSQL = "Select * From CodeSender_DirectionalAntenna Where DetectionInfo = '" + strDetectionInfo + "' ";
            return dba.GetDataSet(strSQL);
        }
        public DataSet IsDirectionalBeings(string strDetectionInfo)
        {
            strSQL = "Select * From CodeSender_DirectionalAntenna Where Directional = '" + strDetectionInfo + "' ";
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取分站信息——绑定】

        public DataSet GetStationInfo_Binding(int intStationAddress)
        {
            strSQL = " Select * From Station_Info Where StationAddress=" + intStationAddress.ToString();
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：获取读卡分站信息——绑定】

        public DataSet GetStationHeadInfo_Binding(int id)
        {
            strSQL = "select * from Station_Head_Info where StationHeadID =" + id.ToString();
            return dba.GetDataSet(strSQL);
        }

        #endregion

        #region【方法：查询传输分站下的的非1号读卡分站的个数】

        public DataSet GetStationHeadCount(string strStationAddress)
        {
            strSQL = " Select 1 From Station_Head_Info Where StationHeadAddress <>1 and StationAddress = "+strStationAddress;
            return dba.GetDataSet(strSQL);
        }

        #endregion

        public DataTable Get_StationInfo(int flag)
        {
            try
            {
                SqlParameter[] sqlParmeters = { new SqlParameter("sign", SqlDbType.Int) };
                sqlParmeters[0].Value = flag;
                DataSet ds = dba.GetDataSet("zjw_Select_Station", sqlParmeters);
                if (ds != null)
                    return ds.Tables[0];
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
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
