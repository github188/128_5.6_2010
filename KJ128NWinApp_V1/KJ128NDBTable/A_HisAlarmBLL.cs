using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class A_HisAlarmBLL
    {

        #region【声明】

        private A_HisAlarmDAL his = new A_HisAlarmDAL();

        #endregion

        #region [ 方法: 历史超员信息 ]

        public DataSet GetHisOverEmpAll(int pageIndex, int pageSize, string where)
        {
            return his.GetHisOverEmpAll(pageIndex, pageSize, where);
        }

        #endregion

        #region[方法：历史区域超时]
        public DataSet GetHisTerOverTime(int pageIndex, int pageSize, string where)
        {
            return his.GetHisTerOVerTime(pageIndex, pageSize, where);
        }
        #endregion


        #region【方法：获取部门信息（树）——历史超时】

        public DataSet GetDeptTree_EmpOverTime()
        {
            return his.GetDeptTree_EmpOverTime();
        }

        #endregion

        #region 查询历史超时信息
        
        public DataSet GetOverTimeSet(int pageIndex, int pageSize, string where)
        {
            return his.GetOverTimeSet(pageIndex, pageSize, where);
        }
        #endregion

        #region【方法：获取区域信息（树）——历史区域】

        public DataSet GetDeptTree_Territorial()
        {
            return his.GetDeptTree_Territorial();
        }

        #endregion

        #region【方法：获取区域信息（树）——历史唯一性】

        public DataSet GetDeptTree_Onlyone()
        {
            return his.GetDeptTree_Onlyone();
        }

        #endregion

        #region【方法：查询报警信息——历史区域】

        public DataSet GetInfo_HisTerritorial(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisTerritorial(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：查询报警信息——历史工作异常】

        public DataSet GetInfo_HisPath(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisPath(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：获取传输分站信息（树）——历史传输分站】

        public DataSet GetTree_Station()
        {
            return his.GetTree_Station();
        }

        #endregion


        #region【方法：查询报警信息——历史传输分站故障信息】

        public DataSet GetInfo_HisStation(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisStation(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：获取读卡分站信息（树）——历史读卡分站】

        public DataSet GetTree_StationHead()
        {
            return his.GetTree_StationHead();
        }

        #endregion

        #region【方法：查询报警信息——历史读卡分站故障信息】

        public DataSet GetInfo_HisStationHead(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisStationHead(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：查询报警信息——历史超速报警信息】

        public DataSet GetInfo_HisOverSpeed(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisOverSpeed(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：查询报警信息——历史欠速报警信息】

        public DataSet GetInfo_HisLackSpeed(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisLackSpeed(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：查询报警信息——历史求救报警信息】

        public DataSet GetInfo_HisEmpHelp(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisEmpHelp(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：查询报警信息——历史唯一性报警信息】

        public DataSet GetInfo_HisOnlyone(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisOnlyone(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：查询报警信息——历史区域超员】

        public DataSet GetInfo_HisTerOverEmp(int pageIndex, int pageSize, string where)
        {
            return his.GetInfo_HisTerOverEmp(pageIndex, pageSize, where);
        }

        #endregion

        #region【方法：获取是否启用该报警】

        public DataSet IsEnableAlarm(int intAlarm)
        {
            return his.IsEnableAlarm(intAlarm);
        }

        #endregion

        #region【Czlt-2011-11-17 历史供电情况】
        /// <summary>
        /// 查询传输分站历史供电情况
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Get_His_DyStation(string strWhere)
        {
            return his.GetHisDYStation(strWhere);
        }

        /// <summary>
        /// 查询串口服务器历史供电情况
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Get_His_DySerial(string strWhere)
        {
            return his.GetHisDYSerial(strWhere);
        }
        /// <summary>
        /// 查询串口服务器树
        /// </summary>
        /// <returns></returns>
        public DataSet GetIPConfigTree()
        {
            return his.GetTree_IpConfig();
        }
        #endregion
    }
}
