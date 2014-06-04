using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class Graphics_ConfigFileDAL
    {
        #region[申明]
        private DBAcess dba = new DBAcess();
        #endregion

        public DataTable GetAllFileName()
        {
            string sqlstr = "select Filename from ConfigFile_ZZHA";
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }

        public bool ExitsFileName(string filename)
        {
            string sqlstr = string.Format("select count(FileName) from ConfigFile_ZZHA where [FileName]='{0}'", filename);
            string num = dba.ExecuteScalarSql(sqlstr);
            int count = int.Parse(num);
            if (count > 0)
                return true;
            else
                return false;
        }

        public void AddFile(string filename, byte[] xmlbyte, byte[] imgbyte)
        {
            string sqlstr = "KJ128N_Graphics_AddConfigFile";
            SqlParameter[] Parameters = {
                                        new SqlParameter("@filename",SqlDbType.VarChar,50),
                                        new SqlParameter("@configfile",SqlDbType.Image),
                                        new SqlParameter("@mapfile",SqlDbType.Image)
                                        };
            Parameters[0].Value = filename;
            Parameters[1].Value = xmlbyte;
            Parameters[2].Value = imgbyte;
            dba.ExecuteSql(sqlstr, Parameters);
        }

        public void UpdateFile(string filename, byte[] xmlbyte, byte[] imgbyte)
        {
            string sqlstr = "KJ128N_Graphics_UpdateConfigFile";
            SqlParameter[] Parameters = {
                                        new SqlParameter("@filename",filename),
                                        new SqlParameter("@configfile",xmlbyte),
                                        new SqlParameter("@mapfile",imgbyte)
                                        };
            Parameters[0].Value = filename;
            Parameters[1].Value = xmlbyte;
            Parameters[2].Value = imgbyte;
            dba.ExecuteSql(sqlstr, Parameters);
        }

        public DataTable GetXmlAndMapByFileName(string filename)
        {
            string sqlstr = string.Format("select ConfigFile,MapFile from ConfigFile_ZZHA where filename='{0}'", filename);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }

        public void RemoveFile(string filename)
        {
            string sqlstr = string.Format("delete from ConfigFile_ZZHA where [FileName]='{0}'", filename);
            dba.ExecuteScalarSql(sqlstr);
        }
    }
}
