using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class A_StationConfigInfoBLL
    {
        private A_StationConfigInfoDAL dal = new A_StationConfigInfoDAL();

        /// <summary>
        /// 查询分站配置信息
        /// </summary>
        /// <param name="stationAddress">分站地址</param>
        /// <param name="selectModel">查询模式 0传输分站 1读卡分站 2为全部传输分站 </param>
        /// <param name="selectAll">是否全部选择</param>
        /// <param name="whereString">查询安装位置条件</param>
        /// <returns>数据集</returns>
        public DataSet SelectStationConfigInfo(int selectModel, string strWhere)
        {
            if (dal == null)
                dal = new A_StationConfigInfoDAL();
            return dal.SelectStationConfigInfo(selectModel, strWhere);
        }
    }
}
