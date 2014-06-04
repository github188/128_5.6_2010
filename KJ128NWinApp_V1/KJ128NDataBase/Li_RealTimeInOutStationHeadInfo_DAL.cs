using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KJ128NDataBase
{
    public class Li_RealTimeInOutStationHeadInfo_DAL
    {

        #region [ 声明 ]

        private DBAcess dbacc = new DBAcess();

        private string strSql = string.Empty;

        #endregion


        #region [ 方法: 获取(部门,工种)基本信息 ]

        public DataSet N_GetDeptInfo()
        {
            strSql = " Select DeptID, ParentDeptID, DeptLevelID, DeptNO, DeptName, Remark From Dept_Info Order By DeptLevelID ";
            return dbacc.GetDataSet(strSql);
        }

        public DataSet N_GetWorkTypeInfo()
        {
            strSql = " Select WorkTypeID, WtName, CerTypeID ,Remark From WorkType_Info ";
            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region [ 方法: 查询实时进出接收器信息_人员 ]

        /// <summary>
        /// 查询实时进出接收器信息_人员
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strStationAddress">分站编号</param>
        /// <param name="strStationHeadAddress">接收器号</param>
        /// <param name="strName">姓名</param>
        /// <param name="strCard">发码器</param>
        /// <param name="strWorkTypeId">工种</param>
        /// <param name="strDeptName">部门</param>
        /// <param name="intUserType">用户类型 1人 2设备</param>
        /// <returns></returns>
        public DataSet N_GetRTInOutStationHeadInfo(
            string strStartTime,
            string strEndTime,
            string strStationAddress,
            string strStationHeadAddress,
            string strName,
            string strCard,
            string strWorkTypeId,
            string strDeptName,
            int intUserType)
        {
            strSql = " Select " +
                     " Ri.CodeSenderAddress As " + HardwareName.Value(CorpsName.CodeSenderAddress) + ", " +
                     " Ei.EmpName As 姓名, " +
                     " Di.DeptName As 部门, " +
                     " Wi.WtName As 工种, " +
                     " Si.StationAddress As " + HardwareName.Value(CorpsName.StationAddress) + ", " +
                     " Si.StationHeadAddress As " + HardwareName.Value(CorpsName.StaHeadAddress) + ", " +
                     " Si.StationHeadPlace As " + HardwareName.Value(CorpsName.StaHeadSplace) + ", " +
                     " Ri.InAntennaPlace As 所在位置, " +
                     " Ri.InStationHeadTime As 进入接收器时间, " +
                     " dbo.FunConvertTime((Select DateDiff(ss, Ri.InStationHeadTime, getDate()))) As 持续时间 " +
                     " From RT_InStationHeadInfo As Ri " +
                     " Left Join Emp_Info As Ei On Ei.EmpID = Ri.UserID " +
                     " Left Join Emp_NowCompany As En On En.EmpID = Ri.UserID " +
                     " Left Join Dept_Info As Di On Di.DeptID = En.DeptID " +
                     " Left Join Emp_WorkType As Ew On Ew.EmpID = Ri.UserID and Ew.IsEnable=1" +
                     " Left Join WorkType_Info As Wi On Wi.WorkTypeID = Ew.WorkTypeID " +
                     " Left Join Station_Head_Info As Si On Si.StationHeadID = Ri.StationHeadID " +
                     " Where " +
                     " Ri.CsTypeID = " + intUserType.ToString() + " And Ri.InStationHeadTime >= '" + strStartTime + "' And Ri.InStationHeadTime <= '" + strEndTime + "' ";

            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And Ei.EmpName like '%" + strName + "%' ";
            }

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And Ri.CodeSenderAddress = " + strCard;
            }

            if (!(strDeptName.Equals("")))
            {
                strSql += " And ( Di.DeptID = " + strDeptName + " ) ";
            }

            if (!strWorkTypeId.Equals("0"))
            {
                strSql += " And Wi.WorkTypeID = " + strWorkTypeId;
            }

            if (!strStationAddress.Equals("0"))
            {
                strSql += " And Si.StationAddress = " + strStationAddress;
            }

            if (!strStationHeadAddress.Equals("0"))
            {
                strSql += " And Si.StationHeadAddress = " + strStationHeadAddress;
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion

        #region [ 方法: 查询实时进出接收器信息_设备 ]

        /// <summary>
        /// 查询实时进出接收器信息_设备
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <param name="strStationAddress">分站编号</param>
        /// <param name="strStationHeadAddress">接收器号</param>
        /// <param name="strName">设备名称</param>
        /// <param name="strCard">发码器编号</param>
        /// <param name="strEquNO">设备编号</param>
        /// <param name="strDeptName">部门</param>
        /// <returns></returns>
        public DataSet N_GetRTInOutStationHeadInfo_Equ(
            string strStartTime,
            string strEndTime,
            string strStationAddress,
            string strStationHeadAddress,
            string strName,
            string strCard,
            string strEquNO,
            string strDeptName)
        {
            strSql = " Select " +
                        " Ri.CodeSenderAddress As " + HardwareName.Value(CorpsName.CodeSenderAddress) + ", " +
                        " Eb.EquName As 设备名称, " +
                        " Eb.EquNO As 设备编号, " +
                        " Di.DeptName As 部门, " +
                        " Shi.StationAddress As " + HardwareName.Value(CorpsName.StationAddress) + ", " +
                        " Shi.StationHeadAddress As " + HardwareName.Value(CorpsName.StaHeadAddress) + ", " +
                        " Shi.StationHeadPlace As " + HardwareName.Value(CorpsName.StaHeadSplace) + ", " +
                        " Ri.InAntennaPlace As 所在位置, " +
                        " Ri.InStationHeadTime As 进入接收器时间, " +
                        " dbo.FunConvertTime((Select DateDiff(ss, Ri.InStationHeadTime, getDate()))) As 持续时间 " +
                     " From RT_InStationHeadInfo As Ri " +
                        " Left Join Equ_BaseInfo as Eb on Ri.UserID=Eb.EquID and CsTypeID=1 "+
                        " Left Join Dept_Info as Di on Eb.DeptID=Di.DeptID "+
                        " Left Join Station_Head_Info As Shi On Shi.StationHeadID = Ri.StationHeadID " +
                     " Where " +
                        " Ri.CsTypeID = 1 And Ri.InStationHeadTime >= '" + strStartTime + "' And Ri.InStationHeadTime <= '" + strEndTime + "' ";

            if (!(strName.Equals("") | strName.Equals(null)))
            {
                strSql += " And Eb.EquName like '%" + strName + "%' ";
            }

            if (!(strEquNO.Equals("") | strEquNO.Equals(null)))
            {
                strSql += " And Eb.EquNO = '" + strEquNO +"' ";
            }

            if (!(strCard.Equals("") | strCard.Equals(null)))
            {
                strSql += " And Ri.CodeSenderAddress = " + strCard;
            }

            if (!(strDeptName.Equals("")))
            {
                strSql += " And ( Di.DeptID = " + strDeptName + " ) ";
            }

            if (!strStationAddress.Equals("0"))
            {
                strSql += " And Shi.StationAddress = " + strStationAddress;
            }

            if (!strStationHeadAddress.Equals("0"))
            {
                strSql += " And Shi.StationHeadAddress = " + strStationHeadAddress;
            }

            return dbacc.GetDataSet(strSql);
        }

        #endregion

    }
}
