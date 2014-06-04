using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace KJ128NDataBase
{
    public class EquDAL
    {
        DBAcess dba = new DBAcess();

        #region 对生产厂家的操作

        #region 获得生产厂家的信息
        /// <summary>
        /// 根据生产厂家的编号获得一条数据
        /// </summary>
        /// <param name="int_FactoryID">生产厂家编号</param>
        /// <returns>符合条件的一条数据</returns>
        public DataTable GetFactoryInfo(int int_FactoryID)
        {
            string str = string.Format("select * from FactoryInfo where FactoryID = {0}", int_FactoryID);
            return dba.GetDataSet(str).Tables[0];
        }

        /// <summary>
        /// 获得全部数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetFactoryInfo()
        {
            return dba.GetDataSet("select * from FactoryInfo where FactoryName <> '未知'").Tables[0];
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
            string strDel = string.Format("delete from FactoryInfo where FactoryID = {0}", int_FactoryID);
            return dba.ExecuteSql(strDel);
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
            string strUpdate = string.Format("update FactoryInfo set FactoryNO = '{0}',FactoryName = '{1}',FactoryAddress ='{2}',FactoryFax = '{3}',FactoryTel ='{4}',FactoryEmployee = '{5}',FactoryEmpoyeeTel = '{6}',Remark ='{7}' where FactoryID= {8}"
                , str_FactoryNO, str_FactoryName, str_FactoryAddress, str_FactoryFax, str_FactoryTel, str_FactoryEmployee, str_FactoryEmpoyeeTel, str_Remark, int_FactoryID);
            return dba.ExecuteSql(strUpdate);
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
            string strAdd = string.Format("insert into FactoryInfo (FactoryNO,FactoryName,FactoryAddress,FactoryFax,FactoryTel,FactoryEmployee,FactoryEmpoyeeTel,Remark)" +
                "select '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}' from (select '{0}' as FactoryNO,Count(1) as iCount From FactoryInfo where FactoryNO ='{0}') as Tmp where iCount <1" ,
                 str_FactoryNO, str_FactoryName, str_FactoryAddress, str_FactoryFax, str_FactoryTel, str_FactoryEmployee, str_FactoryEmpoyeeTel, str_Remark);

            return dba.ExecuteSql(strAdd);
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
            string str = "SELECT EquID,EquNO,EquName,IsNull (Dept_Info.DeptName, '未知') DeptID,IsNull (enum.Title,'未知') EquType,IsNull (enumState.Title,'未知') EquState,IsNull (factory.FactoryName,'未知') FactoryID, "+
            "Equ_BaseInfo.Remark FROM Equ_BaseInfo left JOIN Dept_Info ON Equ_BaseInfo.DeptID = Dept_Info.DeptID left join (select * from dbo.EnumTable where FunID =9) "+
            "enum on enum.EnumID = EquType left join (select * from dbo.EnumTable where FunID =10) enumState on enumState.EnumID = EquState "+
            "left join FactoryInfo factory on factory.FactoryID = Equ_BaseInfo.FactoryID";
            return dba.GetDataSet(str).Tables[0];
        }

        /// <summary>
        /// 根据设备编号查询
        /// </summary>
        /// <param name="int_EquID">设备编号</param>
        /// <returns>表</returns>
        public DataTable GetEquInfo(int int_EquID)
        {
            string strInfo = string.Format("select * from Equ_BaseInfo where EquID = {0}", int_EquID);
            return dba.GetDataSet(strInfo).Tables[0];
        }

        /// <summary>
        /// 根据机器编号查询编号
        /// </summary>
        /// <param name="strEquNO">机器编号</param>
        /// <returns></returns>
        public DataTable GetEquID(string strEquNO)
        {
            string strQuery = string.Format("select EquID,EquName from Equ_BaseInfo where EquNO = '{0}'", strEquNO);
            return dba.GetDataSet(strQuery).Tables[0];
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
            string strProcName = "KJ128N_Equ_Del";
            SqlParameter[] sqlPar ={
                new SqlParameter("EquID",SqlDbType.Int)
            };
            sqlPar[0].Value = int_EquID;
            return dba.ExecuteSql(strProcName, sqlPar);
        }
        #endregion

        #region 修改
        //修改
        public int UpdateEqu_BaseInfo(string strEquNO, string strEquName, int intDeptID, int intEquType, int intEquState, int intFactoryID, string strRemark, int intEquID)
        {
            string strUpdate = string.Format("update Equ_BaseInfo set EquNO ='{0}',EquName ='{1}',DeptID = {2},EquType ={3},EquState ={4},FactoryID ={5},Remark ='{6}'" +
                " where EquID = {7}", strEquNO, strEquName, intDeptID, intEquType, intEquState, intFactoryID, strRemark, intEquID);
            return dba.ExecuteSql(strUpdate);
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
            string strProcName = "KJ128N_Equ_Add";

            SqlParameter [] sqlPar ={ 
                new SqlParameter ("strEquNO",SqlDbType.VarChar),
                new SqlParameter("strEquName",SqlDbType.VarChar),
                new SqlParameter("intDeptID",SqlDbType.Int),
                new SqlParameter("intEquType",SqlDbType.Int),
                new SqlParameter("intEquState",SqlDbType.Int),
                new SqlParameter("intFactoryID",SqlDbType.Int),
                new SqlParameter("strRemark",SqlDbType.VarChar)
            };
            sqlPar[0].Value = strEquNO;
            sqlPar[1].Value = strEquName;
            sqlPar[2].Value = intDeptID;
            sqlPar[3].Value = intEquType;
            sqlPar[4].Value = intEquState;
            sqlPar[5].Value = intFactoryID;
            sqlPar[6].Value = strRemark;

            return dba.ExecuteSql(strProcName, sqlPar);
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
            string strDelail = string.Format("select * from Equ_DetailInfo where EquID = {0}", int_EquID);
            return dba.GetDataSet(strDelail).Tables[0];
        }
        #endregion

        #region 修改详细信息

        // 修改详细信息
        public int UpdateEqu_Detail(string strModelSpecial, string strDutyEmployee, string strUseRange, string dtProductionDate, int intEquHeight, int intEquPower, string dtUserDate, int intEquDetailID)
        {
            string strUpdate = string.Format("update Equ_DetailInfo set ModelSpecial = '{0}',DutyEmployee = '{1}',UseRange = '{2}',ProductionDate ='{3}', " +
                " EquHeight ={4},EquPower ={5},UserDate = '{6}' where EquDetailID ={7}", strModelSpecial, strDutyEmployee, strUseRange, DateTime.Parse(dtProductionDate), intEquHeight, intEquPower, DateTime.Parse(dtUserDate), intEquDetailID);
            return dba.ExecuteSql(strUpdate);
        }
        #endregion

        #region 添加详细信息

        // 添加详细信息
        public int AddEqu_Detail(string strEquNO, string strModelSpecial, string strDutyEmployee, string strUseRange, string dtProductionDate, int intEquHeight, int intEquPower, string dtUserDate)
        {
            string strDetailAdd =string.Format( "declare @EquID int "+
                " select @EquID = EquID from Equ_BaseInfo where EquNO = '{0}' "+
                " if(not exists(select 1 from Equ_DetailInfo where EquID = @EquID))" +
                " begin "+
                " INSERT INTO [Equ_DetailInfo]( [EquID], [ModelSpecial], [DutyEmployee], [UseRange], [ProductionDate], [EquHeight], [EquPower], [UserDate]) " +
                " select @EquID,'{1}','{2}','{3}','{4}',{5},{6},'{7}'  from " +
                " (select @EquID as EquID ,count(1) as iCount from Equ_DetailInfo where EquID = @EquID ) as Tmp where iCount <1"+
                " end ",strEquNO, strModelSpecial, strDutyEmployee, strUseRange, DateTime.Parse(dtProductionDate).ToString("yyyy-M-d"),
                intEquHeight, intEquPower, DateTime.Parse(dtUserDate).ToString("yyyy-M-d"));

            return dba.ExecuteSql(strDetailAdd);
        }

        public int AddEqu_Detail(int intEquID, string strModelSpecial, string strDutyEmployee, string strUseRange, string dtProductionDate, int intEquHeight, int intEquPower, string dtUserDate)
        {

            string strDetailAdd = string.Format("INSERT INTO [Equ_DetailInfo]( [EquID], [ModelSpecial], [DutyEmployee], [UseRange], [ProductionDate], [EquHeight], [EquPower], [UserDate]) " +
                "select {0},'{1}','{2}','{3}','{4}',{5},{6},'{7}'  from " +
                "(select {0} as EquID ,count(1) as iCount from Equ_DetailInfo where EquID = {0} ) as Tmp where iCount <1", intEquID, strModelSpecial, strDutyEmployee, strUseRange, DateTime.Parse(dtProductionDate).ToString("yyyy-M-d"),
                intEquHeight, intEquPower, DateTime.Parse(dtUserDate).ToString("yyyy-M-d"));

            return dba.ExecuteSql(strDetailAdd);
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
        public DataSet Equ_Query(string strEquName,string strFactoryID)
        {
            string strProcName = "KJ128N_Equ_Query";
            SqlParameter[] sqlPar = { 
                new SqlParameter("strEquWhere",DbType.String),
                new SqlParameter("strFactroyWhere",DbType.String)
            };
            sqlPar[0].Value = strEquName;
            sqlPar[1].Value = strFactoryID;

            return dba.ExecuteSqlDataSet(strProcName, sqlPar);
        }
        #endregion 

    }
}
