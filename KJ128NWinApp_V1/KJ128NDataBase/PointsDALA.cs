using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KJ128NModel;
namespace KJ128NDataBase
{
    public class PointsDALA
    {
        DbHelperSQL DB = new DbHelperSQL();
        public PointsDALA()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet GetListByPointId(string strPointId, out string strErrMsg)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strPointId", SqlDbType.VarChar, 20) };
            parameters[0].Value = strPointId;
            return DB.RunProcedureByDataSet("Shine_Points_GetListByPointId", "ds", parameters, out strErrMsg);
        }

        public void DeleteByPointId(string strPointId, out string strErrMsg)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strPointId", SqlDbType.VarChar, 20) };
            parameters[0].Value = strPointId;
            DB.RunProcedureByInt("Shine_Points_DeleteByPointId", parameters, out strErrMsg);
        }

        public DataSet GetListDistinct(out string strErrMsg)
        {
            return DB.RunProcedureByDataSet("Shine_Points_GetListDistinct", "ds", out strErrMsg);
        }

        public void Add(PointsModel pointsModel, out string strErrMsg)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@id", SqlDbType.Int, 4),
                    new SqlParameter("@PointId", SqlDbType.VarChar, 20),
                    new SqlParameter("@x", SqlDbType.Float, 8),
                    new SqlParameter("@y", SqlDbType.Float, 8)};
            parameters[0].Value = pointsModel.id;
            parameters[1].Value = pointsModel.PointId;
            parameters[2].Value = pointsModel.x;
            parameters[3].Value = pointsModel.y;
            DB.RunProcedureByInt("Shine_Points_Add", parameters, out strErrMsg);
        }

        public DataSet GetList(out string strErrMsg)
        {
            return DB.RunProcedureByDataSet("Shine_Points_GetList", "ds", out strErrMsg);
        }
    }
}
