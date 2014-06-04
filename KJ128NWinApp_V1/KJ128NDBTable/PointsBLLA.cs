using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using KJ128NModel;
using System.Data;
namespace KJ128NDBTable
{
    public class PointsBLLA
    {
        private PointsDALA dal = new PointsDALA();

        public PointsBLLA()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet GetListByPointId(string strPointId, out string strErrMsg)
        {
            return dal.GetListByPointId(strPointId, out strErrMsg);
        }

        public void DeleteByPointId(string strPointId, out string strErrMsg)
        {
            dal.DeleteByPointId(strPointId, out strErrMsg);
        }

        public DataSet GetListDistinct(out string strErrMsg)
        {
            return dal.GetListDistinct(out strErrMsg);
        }

        public void Add(PointsModel pointsModel, out string strErrMsg)
        {
            dal.Add(pointsModel, out strErrMsg);
        }

        public DataSet GetList(out string strErrMsg)
        {
            return dal.GetList(out strErrMsg);
        }
    }
}
