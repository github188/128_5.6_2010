using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class A_GraphicsDAL
    {
        #region[申明]
        private DBAcess dba = new DBAcess();
        #endregion

        public void InsertBackMap(string filename, byte[] buffer)
        {
            string selectstring = "Shine_AddGraphicsBackGroudFile";
            SqlParameter[] parameters = new SqlParameter[] {
																new SqlParameter("@filename", SqlDbType.VarChar, 50),
                                                                new SqlParameter("@fileimage", SqlDbType.Image)
                                                           };
            parameters[0].Value = filename;
            parameters[1].Value = buffer;
            dba.ExecuteSql(selectstring, parameters);
        }

        public void DelBackMap()
        {
            string sqlstr = "delete from A_GraphicsMapFile";
            dba.ExecuteSql(sqlstr);
        }

        public byte[] GetBackMapByFileName(string filename)
        {
            string sqlstr = string.Format("select fileimg from A_GraphicsMapFile where [filename]='{0}'", filename);
            DataSet ds = dba.GetDataSet(sqlstr);
            if (ds != null)
            {
                return (byte[])ds.Tables[0].Rows[0][0];
            }
            else
            {
                return null;
            }
        }

        public DataTable GetBackMap()
        {
            string sqlstr = "select [filename],fileimg from A_GraphicsMapFile";
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

        public int GetFlashTime()
        {
            try
            {
                string sqlstr = "select enumvalue from EnumTable where funid=51 and enumid=1";
                return int.Parse(dba.ExecuteScalarSql(sqlstr));
            }
            catch (Exception ex)
            {
                return 3;
            }
        }
    }
}
