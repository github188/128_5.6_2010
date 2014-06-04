using System;
using System.Collections.Generic;
using System.Text;
using KJ128NDataBase;
using System.Data;

namespace KJ128NDBTable
{
    public class EquBLL
    {
        private EquDAL edal = new EquDAL();

        #region 对生产厂家的操作

        #region 获得生产厂家的信息
        /// <summary>
        /// 根据生产厂家的编号获得一条数据
        /// </summary>
        /// <param name="int_FactoryID">生产厂家编号</param>
        /// <returns>符合条件的一条数据</returns>
        public DataTable GetFactoryInfo(int int_FactoryID)
        {
            return edal.GetFactoryInfo(int_FactoryID);
        }

        /// <summary>
        /// 获得全部数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetFactoryInfo()
        {
            return edal.GetFactoryInfo();
        }
        #endregion

        #region 删除生产厂家
        /// <summary>
        /// 删除生产厂家
        /// </summary>
        /// <param name="int_FactoryID">编号</param>
        /// <returns>返回受影响的行数（-1为删除失败）</returns>
        public int DelFactory(int int_FactoryID)
        {
            return edal.DelFactory(int_FactoryID);
        }
        #endregion

        #region 修改生产厂家的详细信息
        /// <summary>
        /// 修改生产厂家的详细信息
        /// </summary>
        /// <param name="str_FactoryNO">厂家编号</param>
        /// <param name="str_FactoryName">厂家名称</param>
        /// <param name="str_FactoryAddress">厂家地址</param>
        /// <param name="str_FactoryFax">厂家传真</param>
        /// <param name="str_FactoryTel">厂家电话</param>
        /// <param name="str_FactoryEmployee">联系人</param>
        /// <param name="str_FactoryEmpoyeeTel">联系人电话</param>
        /// <param name="str_Remark">备注</param>
        /// <param name="int_FactoryID">编号</param>
        /// <returns>受影响的条数</returns>
        public int UpdateFactory(string str_FactoryNO, string str_FactoryName, string str_FactoryAddress, string str_FactoryFax, string str_FactoryTel, string str_FactoryEmployee, string str_FactoryEmpoyeeTel, string str_Remark, int int_FactoryID)
        {
            return edal.UpdateFactory(str_FactoryNO, str_FactoryName, str_FactoryAddress, str_FactoryFax, str_FactoryTel,str_FactoryEmployee, str_FactoryEmpoyeeTel, str_Remark,int_FactoryID);
        }
        #endregion

        #region 添加一个新厂家
        /// <summary>
        /// 添加一个新厂家
        /// </summary>
        /// <param name="str_FactoryNO">厂家编号</param>
        /// <param name="str_FactoryName">厂家名称</param>
        /// <param name="str_FactoryAddress">厂家地址</param>
        /// <param name="str_FactoryFax">厂家传真</param>
        /// <param name="str_FactoryTel">厂家电话</param>
        /// <param name="str_FactoryEmployee">联系人</param>
        /// <param name="str_FactoryEmpoyeeTel">联系人电话</param>
        /// <param name="str_Remark">备注</param>
        /// <returns>受影响的条数(返回1插入成功，返回0说明有FactoryNO相同的存在)</returns>
        public int AddFactory(string str_FactoryNO, string str_FactoryName, string str_FactoryAddress, string str_FactoryFax, string str_FactoryTel, string str_FactoryEmployee, string str_FactoryEmpoyeeTel, string str_Remark)
        {
            return edal.AddFactory(str_FactoryNO, str_FactoryName, str_FactoryAddress, str_FactoryFax, str_FactoryTel, str_FactoryEmployee, str_FactoryEmpoyeeTel, str_Remark);
        }
        #endregion

        #endregion

        #region 设备操作

        #region 必填信息

        #region 获得设备信息
        /// <summary>
        /// 获得全部数据
        /// </summary>
        /// <returns>表</returns>
        public DataTable GetEquInfo()
        {
            return edal.GetEquInfo();
        }

        /// <summary>
        /// 根据设备编号查询
        /// </summary>
        /// <param name="int_EquID">设备编号</param>
        /// <returns>表</returns>
        public DataTable GetEquInfo(int int_EquID)
        {
            return edal.GetEquInfo(int_EquID);
        }

        /// <summary>
        /// 根据机器编号查询编号
        /// </summary>
        /// <param name="strEquNO">机器编号</param>
        /// <returns></returns>
        public DataTable GetEquID(string strEquNO)
        {
            return edal.GetEquID(strEquNO);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="int_EquID">设备编号</param>
        /// <returns>影响条数</returns>
        public int DelEqu_BaseInfo(int int_EquID)
        {
            return edal.DelEqu_BaseInfo(int_EquID);
        }
        #endregion

        #region 修改
        //修改
        public int UpdateEqu_BaseInfo(string strEquNO, string strEquName, int intDeptID, int intEquType, int intEquState, int intFactoryID, string strRemark, int intEquID)
        {
            return edal.UpdateEqu_BaseInfo(strEquNO, strEquName, intDeptID, intEquType, intEquState, intFactoryID, strRemark, intEquID);
        }
        #endregion

        #region 添加
        // 添加
        public int AddEqu_BaseInfo(string strEquNO, string strEquName, int intDeptID, int intEquType, int intEquState, int intFactoryID, string strRemark)
        {
            // 先要判断一下

            //string str = string.Format("insert into Equ_BaseInfo(EquNO,EquName,DeptID,EquType,EquState,FactoryID,Remark) select '{0}','{1}',{2},{3},{4},{5},'{6}' "+
            //    "from (select '{0}' as EquNo ,Count(1) as iCount From Equ_BaseInfo Where EquNo ='{0}' ) AS Tmp where iCount <1 ",
            //    strEquNO, strEquName, intDeptID, intEquType, intEquState, intFactoryID, strRemark);

            //return dba.ExecuteSql(str);

            return edal.AddEqu_BaseInfo(strEquNO, strEquName, intDeptID, intEquType, intEquState, intFactoryID, strRemark);
        }
        #endregion

        #endregion

        #region  选填信息

        #region 详细信息
        /// <summary>
        /// 根据设备编号查询详细信息
        /// </summary>
        /// <param name="int_EquID"></param>
        /// <returns></returns>
        public DataTable GetEquEqu_DetailInfo(int int_EquID)
        {
            return edal.GetEquEqu_DetailInfo(int_EquID);
        }
        #endregion

        #region 修改详细信息

        // 修改详细信息
        public int UpdateEqu_Detail(string strModelSpecial, string strDutyEmployee, string strUseRange, string dtProductionDate, int intEquHeight, int intEquPower, string dtUserDate, int intEquDetailID)
        {

            return edal.UpdateEqu_Detail(strModelSpecial, strDutyEmployee, strUseRange, dtProductionDate, intEquHeight, intEquPower, dtUserDate, intEquDetailID);
        }
        #endregion

        #region 添加详细信息

        // 添加详细信息
        public int AddEqu_Detail(string EquNO, string strModelSpecial, string strDutyEmployee, string strUseRange, string dtProductionDate, int intEquHeight, int intEquPower, string dtUserDate)
        {
            return edal.AddEqu_Detail(EquNO, strModelSpecial, strDutyEmployee, strUseRange, dtProductionDate,
                intEquHeight, intEquPower,dtUserDate);
        }

        public int AddEqu_Detail(int intEupID, string strModelSpecial, string strDutyEmployee, string strUseRange, string dtProductionDate, int intEquHeight, int intEquPower, string dtUserDate)
        {
            return edal.AddEqu_Detail(intEupID, strModelSpecial, strDutyEmployee, strUseRange, dtProductionDate,
                intEquHeight, intEquPower, dtUserDate);
        }
        #endregion

        #endregion

        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strEquName">设备名称</param>
        /// <param name="strFactoryID">生产厂家</param>
        /// <returns></returns>
        public DataSet Equ_Query(string strEquName, string strFactoryID)
        {
            return edal.Equ_Query(strEquName, strFactoryID);
        }
        #endregion 
    }
}
