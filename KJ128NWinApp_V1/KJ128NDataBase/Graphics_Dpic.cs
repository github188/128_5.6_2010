using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NModel;
using System.Diagnostics;

namespace KJ128NDataBase
{
    public class Graphics_Dpic
    {
        private DBAcess dba = new DBAcess();

        public int InsertBackPicFile(string filename, byte[] filebytes)
        {
            int success = 0;
            string sqlstr = "Proc_DbackPic_AddFile";
            SqlParameter[] Parameters = {
                                        new SqlParameter("@filename",SqlDbType.VarChar,50),
                                        new SqlParameter("@fileimg",SqlDbType.Image),
                                        new SqlParameter("@success",SqlDbType.Int),
                                        new SqlParameter("@ID",SqlDbType.Int)
                                        };
            Parameters[0].Value = filename;
            Parameters[1].Value = filebytes;
            Parameters[2].Direction = ParameterDirection.Output;
            Parameters[2].Value = success;
            Parameters[3].Value = filename.GetHashCode();
            dba.ExecuteSql(sqlstr, Parameters);
            success = Convert.ToInt32(Parameters[2].Value);
            return success;
        }

        public int UpdateBackPicFile(string filename, byte[] filebytes)
        {
            try
            {
                int i = 0;
                string sqlstr = "update G_DPicFile set Fileimg=@Fileimg where Filename=@Filename";
                SqlCommand comm = new SqlCommand();
                comm.CommandText = sqlstr;
                comm.Parameters.AddWithValue("@Fileimg", filebytes);
                comm.Parameters.AddWithValue("@Filename", filename);
                //Czlt-2012-12-14 假如图形修改成功以后 要更新备份表中的图形信息
                i = dba.ExecCommand(comm);
                if (i >= 1)
                {
                    CzltUpdateBack();

                }
                return i;
                //return dba.ExecCommand(comm);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public DataTable GetAllBackPicFile()
        {
            string sqlstr = "select * from G_DPicFile";
            DataSet ds = dba.GetDataSet(sqlstr);

            //Czlt-2012-12-14 假如图形丢失就从备份图层中还原一条记录回来
            if (ds == null || ds.Tables.Count == 0)
            {
                CzltGetBackFile();
            }
            ds = dba.GetDataSet(sqlstr);


            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public bool DelBackPicFile(string filename)
        {
            string sqlstr = string.Format("update Station_Head_Info set stationheadx=0, stationheady=0 where stationheadid " +
                                            "in (select stationheadid from G_File_Station where fileid=(select fileid from G_DPicFile where [filename]='{0}')) " +
                                            "delete from G_File_Station where fileid=(select fileid from G_DPicFile where [filename]='{0}') " +
                                            "delete from G_DConfigFile where mapfileid=(select fileid from G_DPicFile where [filename]='{0}') " +
                                            "delete from G_DRoute where fileid=(select fileid from G_DPicFile where [filename]='{0}') " +
                                            "delete from G_DPoint where fileid=(select fileid from G_DPicFile where [filename]='{0}') " +
                                            " delete from G_DPicFile where [filename]='{0}' ", filename);
            try
            {
                dba.ExecuteSql(sqlstr);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetBackPicByFileID(string fileid)
        {
            string sqlstr = string.Format("select Fileimg,Filename from G_DPicFile where FileID={0}", fileid);
            DataSet ds = dba.GetDataSet(sqlstr);


            //Czlt-2012-12-14 假如图形丢失就从备份图层中还原一条记录回来
            if (ds.Tables[0].Rows.Count == 0)
            {
                CzltGetBackFile();
            }
            ds = dba.GetDataSet(sqlstr);


            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        public bool IsRouted(string fileID)
        {
            string sqlstr = string.Format("select count(*) from G_DRoute where FileID={0}", fileID);
            int num;
            try
            {
                num = int.Parse(dba.ExecuteScalarSql(sqlstr));
            }
            catch (Exception ex)
            {
                return false;
            }
            if (num > 0)
                return true;
            else
                return false;
        }

        public bool IsPointed(string fileid)
        {
            string sqlstr = string.Format("select count(*) from G_DPoint where FileID={0}", fileid);
            int num;
            try
            {
                num = int.Parse(dba.ExecuteScalarSql(sqlstr));
            }
            catch (Exception ex)
            {
                return false;
            }
            if (num > 0)
                return true;
            else
                return false;
        }

        public DataTable GetAllStation()
        {
            string sqlstr = "select stationheadid,stationheadplace from Station_Head_Info";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        public bool DelFileStationByFileID(string fileid)
        {
            string sqlstr = string.Format("delete from G_File_Station where FileID={0}", fileid);
            try
            {
                dba.ExecuteSql(sqlstr);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DelAllFileStation()
        {
            string sqlstr = string.Format("delete from G_File_Station");
            try
            {
                dba.ExecuteSql(sqlstr);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void UpdateStationHeadXY(string sqlstr)
        {
            dba.ExecuteSql(sqlstr);
        }

        public bool InsertIntoFileStation(string fileid, string stationid)
        {
            string sqlstr = string.Format("insert into G_File_Station values({0},{1})", fileid, stationid);
            try
            {
                dba.ExecuteSql(sqlstr);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetStationInfoByFileID(string fileid)
        {
            string sqlstr = string.Format("select stationheadid,stationheadplace from Station_Head_Info " +
                                            "where stationheadid in " +
                                            "(select stationheadid from G_File_Station where fileid={0})", fileid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetStationInfo()
        {
            string sqlstr = "select stationheadid,stationheadplace from Station_Head_Info";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }


        public DataTable GetStationPositionByFileID(string fileid)
        {
            string sqlstr = string.Format("select stationheadplace,stationheadx,stationheady from Station_Head_Info " +
                                            "where stationheadid in " +
                                            "(select stationheadid from G_File_Station where fileid={0})", fileid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetRouteInfoPositionByFileID(string fileid)
        {
            string sqlstr = string.Format("select routefrom,routeto,routelength from G_DRoute where fileid={0} order by [id]", fileid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetNotInStationInfoByFileID()
        {
            string sqlstr = "select stationheadid,stationheadplace from Station_Head_Info " +
                                            "where stationheadid not in " +
                                            "(select stationheadid from G_File_Station)";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetAllInStationInfoByFileID()
        {
            string sqlstr = "select stationheadid,stationheadplace from Station_Head_Info ";

            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetStationHeadByFileID(string fileid)
        {
            string sqlstr = string.Format("select stationaddress,stationheadaddress,stationheadplace,stationheadx,stationheady from Station_Head_Info " +
                                            "where stationheadid in " +
                                            "(select stationheadid from G_File_Station where fileid={0})", fileid);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public string DelRoute(string fileid)
        {
            string delstring = string.Format(" delete from G_DRoute where FileID={0} ", fileid);
            dba.ExecuteSql(delstring);
            return delstring;
        }

        /// <summary>
        /// 将一条路径信息插入路径表
        /// </summary>
        /// <param name="from">路径起始点</param>
        /// <param name="to">路径结束点</param>
        /// <param name="length">路径长度</param>
        /// <returns>是否成功</returns>
        public string InsertIntoRoute(string from, string to, int length, string Fileid, int id)
        {
            string insertstring1 = string.Format(" insert into G_DRoute ([ID],routefrom,routeto,routelength,FileID) values({4},'{0}','{1}',{2},{3}) ", from, to, length, Fileid, id);
            string insertstring2 = string.Format(" insert into G_DRoute ([ID],routefrom,routeto,routelength,FileID) values({4},'{0}','{1}',{2},{3}) ", to, from, length, Fileid, id + 1);
            dba.ExecuteSql(insertstring1);
            dba.ExecuteSql(insertstring2);
            return insertstring1 + insertstring2;
        }

        public int GetMaxRouteID()
        {
            int num = 0;
            string sqlstr = "select max(id) from G_DRoute";
            try
            {
                string result = dba.ExecuteScalarSql(sqlstr);
                if (result.Length == 0)
                    return 1;
                else
                    num = int.Parse(dba.ExecuteScalarSql(sqlstr));
                return num;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool HasConfigRoutePoint(string fileid)
        {
            try
            {
                int num = 0;
                string selectstr = string.Format("select count(id) from G_DPoint where FileID={0}", fileid);
                num = Convert.ToInt32(dba.ExecuteScalarSql(selectstr));
                if (num > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<KJ128NModel.RouteModel> GetAllRoute(string fileid)
        {
            try
            {
                List<KJ128NModel.RouteModel> list = new List<RouteModel>();
                string selectstr = string.Format("select * from G_DRoute where FileID={0}", fileid);
                DataTable dt = dba.GetDataSet(selectstr).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RouteModel r = new RouteModel();
                    r.From = dt.Rows[i][1].ToString();
                    r.To = dt.Rows[i][2].ToString();
                    r.RouteLength = Convert.ToInt32(dt.Rows[i][3]);
                    list.Add(r);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Czlt-2011-02-11 删除轨迹点
        /// </summary>
        /// <param name="fileid"></param>
        public void DelAllPoint(string fileid)
        {
            //string sqlstr = string.Format("delete from G_DPoint where FileID={0}", fileid);
            //string sqlstr = string.Format("delete from G_DPoint ");
            string sqlstr = string.Format(" truncate table G_DPoint ");
            dba.ExecuteSql(sqlstr);
        }

        public string InsertPoint(string pointid, double x, double y, string fileid, int id)
        {
            string insertstr = string.Format(" insert into G_DPoint values({4},'{0}',{1},{2},{3}) ", pointid, x, y, fileid, id);
            return insertstr;
            SqlParameter[] parameter = new SqlParameter[]{
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@pointID",SqlDbType.VarChar,50),
                new SqlParameter("@x",SqlDbType.Float),
                new SqlParameter("@y",SqlDbType.Float),
                new SqlParameter("@FileID",SqlDbType.VarChar,50)
            };

            parameter[0].Value = id;
            parameter[1].Value = pointid;
            parameter[2].Value = x;
            parameter[3].Value = y;
            parameter[4].Value = fileid;

            dba.ExecuteSql("G_DPoint_Insert", parameter);
        }

        public int GetMaxPointID()
        {
            string sqlstr = "select Max(id) from G_DPoint";
            try
            {
                string num = dba.ExecuteScalarSql(sqlstr);
                if (num.Length == 0)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(num);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetNumOfRoute(string fileid)
        {
            try
            {
                string selectstr = string.Format("select count(id) from G_DRoute where FileID={0}", fileid);
                string num = dba.ExecuteScalarSql(selectstr);
                if (num.Length == 0)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(num);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region[配置文件操作]
        public DataTable GetAllFileName()
        {
            string sqlstr = "select Filename from G_DConfigFile";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public bool ExitsFileName(string filename)
        {
            string sqlstr = string.Format("select count(FileName) from G_DConfigFile where [FileName]='{0}'", filename);
            string num = dba.ExecuteScalarSql(sqlstr);
            int count = int.Parse(num);
            if (count > 0)
                return true;
            else
                return false;
        }

        public void AddFile(string filename, byte[] xmlbyte, string fileid)
        {
            string sqlstr = "KJ128N_Graphics_AddDConfigFile";
            SqlParameter[] Parameters = {
                                        new SqlParameter("@filename",SqlDbType.VarChar,50),
                                        new SqlParameter("@configfile",SqlDbType.Image),
                                        new SqlParameter("@fileid",SqlDbType.Int)
                                        };
            Parameters[0].Value = filename;
            Parameters[1].Value = xmlbyte;
            Parameters[2].Value = int.Parse(fileid);
            dba.ExecuteSql(sqlstr, Parameters);
        }

        public void UpdateFile(string filename, byte[] xmlbyte, string fileid)
        {
            string sqlstr = "KJ128N_Graphics_UpdateDConfigFile";
            SqlParameter[] Parameters = {
                                        new SqlParameter("@filename",filename),
                                        new SqlParameter("@configfile",xmlbyte),
                                        new SqlParameter("@fileid",int.Parse(fileid))
                                        };
            Parameters[0].Value = filename;
            Parameters[1].Value = xmlbyte;
            Parameters[2].Value = int.Parse(fileid);
            dba.ExecuteSql(sqlstr, Parameters);
        }

        public DataTable GetXmlByFileName(string filename)
        {
            string sqlstr = string.Format("select ConfigFile from G_DConfigFile where filename='{0}'", filename);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public void RemoveFile(string filename)
        {
            string sqlstr = string.Format("delete from G_DConfigFile where [FileName]='{0}'", filename);
            dba.ExecuteScalarSql(sqlstr);
        }
        #endregion

        public DataTable GetStationHeadPlaceByFileID(string fileid)
        {
            string sqlstr = string.Format("select stationheadplace from Station_Head_Info where stationheadid in " +
                                        "(select stationheadid from G_File_Station where fileid={0})", fileid);
            DataSet da = dba.GetDataSet(sqlstr);
            if (da != null)
                return da.Tables[0];
            else
                return new DataTable();
        }

        /// <summary>
        /// 根据人员ID和开始结束日期得到该人员进出分站信息
        /// </summary>
        /// <param name="userid">人员ID</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>信息表</returns>
        public DataTable GetRouteByUserID(int userid, string startDate, string endDate, int fileid)
        {
            string selectstring = "Shine_HistoryInOutStation_QueryView_ZZHA";
            SqlParameter[] parameters = new SqlParameter[] {
																new SqlParameter("@strTableName", SqlDbType.VarChar, 50),
																new SqlParameter("@intBlock", SqlDbType.Int),
																new SqlParameter("@strName", SqlDbType.VarChar, 20),
																new SqlParameter("@intUserType", SqlDbType.Int),
																new SqlParameter("@strStartDateTime", SqlDbType.VarChar, 50),
																new SqlParameter("@strEndDateTime", SqlDbType.VarChar, 50),
                                                                new SqlParameter("@FileID", SqlDbType.Int)};
            parameters[0].Value = "Shen_HisInOutStationHeadInfo_zdc";
            parameters[1].Value = userid;
            parameters[2].Value = "";
            parameters[3].Value = 0;
            parameters[4].Value = startDate;
            parameters[5].Value = endDate;
            parameters[6].Value = fileid;
            try
            {
                return dba.GetDataSet(selectstring, parameters).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetRoutePointByID(string ID, bool isdesc, string fileid)
        {
            string selectstring = string.Empty;
            if (isdesc)
                selectstring = string.Format("select x,y from G_DPoint where pointid='{0}' and fileid={1} order by [id] desc", ID, fileid);
            else
                selectstring = string.Format("select x,y from G_DPoint where pointid='{0}' and fileid={1} order by [id] asc", ID, fileid);
            return dba.GetDataSet(selectstring).Tables[0];
        }

        public bool StationExitsByFileIDandStationPlace(string fileid, string stationheadplace)
        {
            string sqlstr = string.Format("select count(stationheadid) from station_head_info where stationheadplace='{1}' and stationheadid in " +
                                        "(select stationheadid from G_File_Station where fileid={0})", fileid, stationheadplace);
            try
            {
                string num = dba.ExecuteScalarSql(sqlstr);
                if (int.Parse(num) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool HaveColorSet()
        {
            string sqlstr = "select count(*) from G_DColor";
            try
            {
                string num = dba.ExecuteScalarSql(sqlstr);
                if (int.Parse(num) == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DelColor()
        {
            string sqlstr = "delete from G_DColor";
            dba.ExecuteSql(sqlstr);
        }

        public void InsertColor(int colorid, string color)
        {
            string sqlstr = string.Format("insert into G_DColor values({0},'{1}')", colorid, color);
            dba.ExecuteSql(sqlstr);
        }

        public DataTable GetColorSet()
        {
            string sqlstr = "select * from G_DColor order by colorid";
            DataSet da = dba.GetDataSet(sqlstr);
            if (da != null)
                return da.Tables[0];
            else
                return new DataTable();
        }

        public void UpdateColor(int colorid, string color)
        {
            string sqlstr = string.Format("update G_DColor set colorname='{1}' where colorid={0}", colorid, color);
            dba.ExecuteSql(sqlstr);
        }


        #region  【Czlt-2011-01-28 批量插入SQL语句】
        public long SqlBulkCopyInsert(DataTable dt)
        {
            string strCon = dba.GetConn();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(strCon);
            sqlBulkCopy.DestinationTableName = "G_DPoint";
            sqlBulkCopy.BatchSize = dt.Rows.Count;
            SqlConnection sqlConn = new SqlConnection(strCon);
            sqlConn.Open();
            if (dt != null && dt.Rows.Count != 0)
            {
                sqlBulkCopy.WriteToServer(dt);
            }
            sqlBulkCopy.Close();
            sqlConn.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;

        }
        #endregion


        #region【方法：Czlt-2011-12-10 修改配置时间】

        public void UpdateTime()
        {
            string strSQL = "UPDATE [CzltChangeTable] SET ChangeTime ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            dba.GetDataSet(strSQL);
        }

        #endregion

        #region【Czlt-2012-12-14 修改底图时拷贝到备份图形表中】
        /// <summary>
        /// czlt-2012-11-21 从备份表中读取图形信息
        /// </summary>
        public void CzltGetBackFile()
        {
            string sqlstr = "Proc_GetBackFile";
            SqlParameter[] Parameters = {                     
                                        };

            dba.ExecuteSql(sqlstr, Parameters);

        }

        /// <summary>
        /// czlt-2012-11-21修改备份表中的图形信息
        /// </summary>
        public void CzltUpdateBack()
        {
            //Proc_UpdateBackFile
            string sqlstr = "Proc_UpdateBackFile";
            SqlParameter[] Parameters = {
                                      
                                        };

            dba.ExecuteSql(sqlstr, Parameters);
        }
        #endregion

    }
}
