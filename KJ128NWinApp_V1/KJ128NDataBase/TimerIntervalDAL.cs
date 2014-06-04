using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace KJ128NDataBase
{
    public class TimerIntervalDAL
    {

        #region [ 声明 ]

        DBAcess DB = new DBAcess();

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 添加时段信息 ]

        public int TimerInterval_Insert(string strIntervalName, string strNameShort, string strStartWorkTime, string strEndWorkTime, int intSWDateType, int intEWDateType, int intSWFrontTime, int intSWAfterTime, int intEWFrontTime, int intEWAfterTime, int intClassID,int intDataAttendanceType,out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IntervalName",SqlDbType.VarChar,50),
                new SqlParameter("@NameShort",SqlDbType.VarChar,8),
                new SqlParameter("@StartWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@SWDateType",SqlDbType.Int,4),
                new SqlParameter("@EWDateType",SqlDbType.Int,4),
                new SqlParameter("@SWFrontTime",SqlDbType.Int,4),
                new SqlParameter("@SWAfterTime",SqlDbType.Int,4),
                new SqlParameter("@EWFrontTime",SqlDbType.Int,4),
                new SqlParameter("@EWAfterTime",SqlDbType.Int,4),
                new SqlParameter("@ClassID",SqlDbType.Int,4),
                new SqlParameter("@DataAttendanceType",SqlDbType.Int,4),
                new SqlParameter("@ID",SqlDbType.Int)
            };

            parameters[0].Value = strIntervalName;
            parameters[1].Value = strNameShort;
            parameters[2].Value = strStartWorkTime;
            parameters[3].Value = strEndWorkTime;
            parameters[4].Value = intSWDateType;
            parameters[5].Value = intEWDateType;
            parameters[6].Value = intSWFrontTime;
            parameters[7].Value = intSWAfterTime;
            parameters[8].Value = intEWFrontTime;
            parameters[9].Value = intEWAfterTime;
            parameters[10].Value = intClassID;
            parameters[11].Value = intDataAttendanceType;
            parameters[12].Value = strIntervalName.GetHashCode();

            return DB.ExecuteSql("Shine_TimerInterval_Add", parameters, out strErr);
        }

        #endregion

        #region [ 方法: 更新时段信息 ]

        public int TimerInterval_Update(int intID, string strIntervalName, string strNameShort, string strStartWorkTime, string strEndWorkTime, int intSWDateType, int intEWDateType, int intSWFrontTime, int intSWAfterTime, int intEWFrontTime, int intEWAfterTime, int intClassID,int intDataAttendanceType,out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4),
                new SqlParameter("@IntervalName",SqlDbType.VarChar,50),
                new SqlParameter("@NameShort",SqlDbType.VarChar,8),
                new SqlParameter("@StartWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@EndWorkTime",SqlDbType.VarChar,20),
                new SqlParameter("@SWDateType",SqlDbType.Int,4),
                new SqlParameter("@EWDateType",SqlDbType.Int,4),
                new SqlParameter("@SWFrontTime",SqlDbType.Int,4),
                new SqlParameter("@SWAfterTime",SqlDbType.Int,4),
                new SqlParameter("@EWFrontTime",SqlDbType.Int,4),
                new SqlParameter("@EWAfterTime",SqlDbType.Int,4),
                new SqlParameter("@ClassID",SqlDbType.Int,4),
                new SqlParameter("@DataAttendanceType",SqlDbType.Int,4)
            };

            parameters[0].Value = intID;
            parameters[1].Value = strIntervalName;
            parameters[2].Value = strNameShort;
            parameters[3].Value = strStartWorkTime;
            parameters[4].Value = strEndWorkTime;
            parameters[5].Value = intSWDateType;
            parameters[6].Value = intEWDateType;
            parameters[7].Value = intSWFrontTime;
            parameters[8].Value = intSWAfterTime;
            parameters[9].Value = intEWFrontTime;
            parameters[10].Value = intEWAfterTime;
            parameters[11].Value = intClassID;
            parameters[12].Value = intDataAttendanceType;

            return DB.ExecuteSql("Shine_TimerInterval_Update", parameters, out strErr);
        }

        #endregion

        #region [ 方法: 删除时段信息 ]

        public int TimerInterval_Delete(int intID,out string strErr)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int,4)
            };

            parameters[0].Value = intID;

            return DB.ExecuteSql("Shine_TimerInterval_Delete", parameters, out strErr);
        }

        #endregion

        #region [ 方法: 查询时段信息 ]

        public DataSet TimerInterval_Query(string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@strWhere",SqlDbType.VarChar,200)
            };

            parameters[0].Value = strWhere;

            return DB.ExecuteSqlDataSet("Shine_TimerInterval_Query", parameters);
        }

        #endregion

        #region 【方法：查询树时段信息】
        public DataSet TimerIntervalTree_Query()
        {
            string strSql = "select 'c'+convert(varchar(20),ID) as id,ClassName as [Name],'0' as ParentID,'true' as IsChild,'false' as IsUserNum,0 as Num from infoclass union all select 'i'+convert(varchar(20),t.ID) as id,intervalName as [Name],'c'+convert(varchar(20),t.classid) as ParentID,'true' as IsChild,'false' as IsUserNum,0 as Num from TimerInterval t join infoclass i on t.classid=i.id";
            return DB.GetDataSet(strSql);
        }
        #endregion

        #region 【方法：Czlt-修改考勤提前时间信息】
        public int UpdateSWAfterTime(string afterTime, string strWhere)
        {
            string strUpdate = "update TimerInterval set SWfrontTime = '" + afterTime + "' where " + strWhere;
            return DB.ExistsSql(strUpdate);

        }
        #endregion


        #region【方法：Czlt-2011-12-10 修改配置时间】

        public void UpdateTime()
        {
            string strSQL = "UPDATE [CzltChangeTable] SET ChangeTime ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            //dba.GetDataSet(strSQL);
            DB.ExistsSql(strSQL);
        }

        #endregion
    }
}
