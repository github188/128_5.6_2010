using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;
using System.Drawing;

namespace KJ128NDBTable
{
    public class Graphics_StationInfoBLL
    {
        #region[申明]
        private Graphics_StationInfoDAL gsd = new Graphics_StationInfoDAL();
        #endregion

        #region[周志豪]
        /// <summary>
        /// 得到所有的分站信息
        /// </summary>
        /// <returns>信息表</returns>
        public DataTable GetStationInfo()
        {
            return gsd.GetStationInfo();
        }

        /// <summary>
        /// 删除所有的路径
        /// </summary>
        public string DelRoute()
        {
            return gsd.DelRoute();
        }

        /// <summary>
        /// 插入路径表一行
        /// </summary>
        /// <param name="from">路径起始点</param>
        /// <param name="to">路径结束点</param>
        /// <param name="length">路径长度</param>
        /// <returns>是否成功</returns>
        public string InsertIntoRoute(PointF from, PointF to, int length)
        {
            string strfrom = from.X.ToString() + "," + from.Y.ToString();
            string strto = to.X.ToString() + "," + to.Y.ToString();
            return gsd.InsertIntoRoute(strfrom, strto, length);            
        }

        /// <summary>
        /// 根据探头名称修改探头坐标点
        /// </summary>
        /// <param name="p">探头坐标点</param>
        /// <param name="stationheadName">探头名称</param>
        /// <returns>是否成功</returns>
        public string UpdateStationHeadInfo(PointF p, string stationheadName)
        {
            return gsd.UpdateStationInfo(p.X.ToString(), p.Y.ToString(), stationheadName);
        }

        public bool SaveStationAndRoute(string savestr)
        {
            return gsd.SavePointAndRoute(savestr);
        }

        public bool SaveStationAndRoute(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (!gsd.SavePointAndRoute(list[i]))
                    return false;
            }
            return true;
        }
        #endregion
    }
}
