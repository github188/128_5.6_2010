using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class ConEquManageDAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 查询设备信息 ]

        public DataSet N_GetEquInfo(string strEquNO, string strEquName, string strFacID)
        {
            strSql = " Select " +
                        " EquNO as 设备编号, " +
                        " EquName as 设备名称, " +
                        " DeptName as 所属部门, " +
                        " Et1.Title as 设备类型, " +
                        " Et2.Title as 设备状态, " +
                        " FactoryName as 生产厂家, " +
                        " Ebi.Remark as 备注 " +
                     " From " +
                        " Equ_BaseInfo as Ebi left join EnumTable Et1 on Ebi.EquType=Et1.EnumID and Et1.FunID=9 " +
                        " left join EnumTable Et2 on Ebi.EquState=Et2.EnumID and Et2.FunID=10 " +
                        " left join Dept_Info as Di on Di.DeptID=Ebi.DeptID " +
                        " left join FactoryInfo as Fi on Fi.FactoryID=Ebi.FactoryID " +
                     " Where " +
                        " EquID<>0 ";

            if (!(strEquNO.Equals("") | strEquNO.Equals(null)))
            {
                strSql += " And EquNO like '%" + strEquNO + "%'";
            }
            if (!(strEquName.Equals("") | strEquName.Equals(null)))
            {
                strSql += " And EquName like '%" + strEquName + "%'";
            }
            if (!strFacID.Equals("0"))
            {
                strSql += " And Ebi.FactoryID = " + strFacID;
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询厂家信息 ]

        public DataSet N_GetFactoryInfo(string strFacNO, string strFacID)
        {
            bool blIsFirst = false;
            strSql = " Select " +
                        " FactoryNO as 厂家编号, " +
                        " FactoryName as 厂家名称, " +
                        " FactoryAddress as 地址, " +
                        " FactoryFax as 传真, " +
                        " FactoryTel as 联系电话, " +
                        " FactoryEmployee as 联系人, " +
                        " FactoryEmpoyeeTel as 联系人电话, " +
                        " Remark as 备注 " +
                     " From " +
                        " FactoryInfo ";
            if (!(strFacNO.Equals("") | strFacNO.Equals(null)))
            {
                strSql += " where FactoryNO like '%" + strFacNO + "%'";
                blIsFirst = true;
            }
            if (!strFacID.Equals("0"))
            {
                if (blIsFirst)
                {
                    strSql += " And FactoryID = " + strFacID;
                }
                else
                {
                    strSql += " Where FactoryID =" + strFacID;
                }
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 获取厂家名称基本信息 ]

        public DataSet N_GetFactoryName()
        {
            strSql = " Select FactoryID, FactoryNO, FactoryName From FactoryInfo ";
            return dbacc.GetDataSet(strSql);
        }

        #endregion

    }
}
