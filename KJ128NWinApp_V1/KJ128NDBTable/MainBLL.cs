using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using KJ128NDataBase;
using System.Data;
using KJ128NInterfaceShow;

namespace KJ128NDBTable
{
    public class MainBLL
    {
        private DBAcess dbacc = new DBAcess();
        private DataSet ds;
        private string strSql;

        #region 存储显示设置
        public void SaveDisplayInfo(string strDisplayFun, string strPpageSum, string strVartical, string strLeftVartical, string strTopVartical,
                            string strDisplayType, string strHeadDisplayType, string strDept, string strDirectional, string strSizeX, string strSizeY,
                            string strOutWellTime)
        {
            string procName = "KJ128N_Display_UpDate";
            SqlParameter[] sqlParmeters ={
                            new SqlParameter("DisplayFun",SqlDbType.NVarChar,20),
                            new SqlParameter("PpageSum",SqlDbType.NVarChar,20),
                            new SqlParameter("Vartical",SqlDbType.NVarChar,20),
                            new SqlParameter("LeftVartical",SqlDbType.NVarChar,20),
                            new SqlParameter("TopVartical",SqlDbType.NVarChar,20),
                            new SqlParameter("DisplayType",SqlDbType.NVarChar,20),
                            new SqlParameter("HeadDisplayType",SqlDbType.NVarChar,20),
                            new SqlParameter("DisplayDept",SqlDbType.NVarChar,20),
                            new SqlParameter("DisplayDirectional",SqlDbType.NVarChar,20),
                            new SqlParameter("SizeX",SqlDbType.NVarChar,20),
                            new SqlParameter("SizeY",SqlDbType.NVarChar,20),
                            new SqlParameter("OutWellTime",SqlDbType.NVarChar,20)
            };
            sqlParmeters[0].Value = strDisplayFun;
            sqlParmeters[1].Value = strPpageSum;
            sqlParmeters[2].Value = strVartical;
            sqlParmeters[3].Value = strLeftVartical;
            sqlParmeters[4].Value = strTopVartical;
            sqlParmeters[5].Value = strDisplayType;
            sqlParmeters[6].Value = strHeadDisplayType;
            sqlParmeters[7].Value = strDept;
            sqlParmeters[8].Value = strDirectional;
            sqlParmeters[9].Value = strSizeX;
            sqlParmeters[10].Value = strSizeY;
            sqlParmeters[11].Value = strOutWellTime;

            dbacc.ExecuteSql(procName, sqlParmeters);
        }
        #endregion

        #region 获取初始化显示设置信息
        public DataSet GetInitdisplay()
        {
            string strSql;
            strSql = " Select EnumValue, EnumID From EnumTable Where FunID=46 or (FunID=14 and EnumID=0) ";
            return dbacc.GetDataSet(strSql);
        }
        #endregion

        #region 查询接收器的具体发码器信息
        public void SearchStaHeadInfo(string strSta, string strStaHead, int headDisplayType, DataGridViewKJ128 dv,out string strCounts)
        {
            /*string strSql;
            strSql = " Select " +
                        " Rcs.CodeSenderAddress as 发码器, " +
                        " 名称=case when CsTypeID=0 then Ei.EmpName when CsTypeID=1 then Ebi.EquName end, " +
                        " 配置类型= case when CsTypeID=0 then '人员' when CsTypeID=1 then '设备' end, " +
                        " 部门=case when CsTypeID=0 then Di1.DeptName when CsTypeID=1 then Di2.DeptName end, " +
                        " Cd.Directional as 方向性, " +
                        " StationHeadDetectTime as 监测时间 " +
                     " From " +
                        " RealTimeCodeSender as Rcs left join CodeSender_Set as Cs on Cs.CsSetID=Rcs.CsSetID " +
                        " left join Emp_Info as Ei on Ei.EmpID=Cs.UserID and CsTypeID=0 " +
                        " left join Emp_NowCompany as Enc on Enc.EmpID=Ei.EmpID " +
                        " left join Dept_Info as Di1 on Di1.DeptID=Enc.DeptID " +
                        " left join CodeSender_Directional as Cd on Cd.DetectionInfo =Rcs.CodeSenderDirectional " +
                        " left join Equ_BaseInfo as Ebi on Ebi.EquID =Cs.UserID and CsTypeID=1 " +
                        " left join Dept_Info as Di2 on Di2.DeptID=Ebi.DeptID " +
                     " Where " +
                        " Rcs.StationAddress = " + strSta;
            if (strStaHead != "")
            {
                strSql += " And Rcs.StationHeadAddress = " + strStaHead;
            }
            if (headDisplayType != 2)
            {
                strSql += " And CsTypeID=" + headDisplayType.ToString();
            }
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = dbacc.GetDataSet(strSql);
                dv.DataSource = ds.Tables[0].DefaultView;
            }*/
            string procName = "PROC_GetRTStaHeadCodeInfo";
            SqlParameter[] sqlParmeters ={
                            new SqlParameter("StationAddress",SqlDbType.Int),
                            new SqlParameter("StationHeadAddress",SqlDbType.Int),
                            new SqlParameter("sumType",SqlDbType.Int)
            };
            sqlParmeters[0].Value = strSta;
            sqlParmeters[1].Value = strStaHead;
            sqlParmeters[2].Value = headDisplayType;

            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = dbacc.GetDataSet(procName, sqlParmeters);

                if (ds == null)
                {
                    dv.DataSource = null;
                    strCounts = "0";
                    return;
                }
                ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);   //发码器编号
                ds.Tables[0].Columns[5].ColumnName = HardwareName.Value(CorpsName.Inspect);             //监测时间

                dv.DataSource = ds.Tables[0].DefaultView;

                dv.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strCounts = ds.Tables[0].Rows.Count.ToString();
                    }
                    else
                    {
                        strCounts = "0";
                    }
                }
                else
                {
                    strCounts = "0";
                }
            }

        }
        #endregion

        #region 查询分站的具体发码器信息
        public void SearchStaInfo(string strSta, int displayType, DataGridViewKJ128 dv,out string strCounts)
        {
            /*
            string strSql;
            strSql = " Select " +
                        " Rcs.CodeSenderAddress as 发码器, " +
                        " 名称=case when CsTypeID=0 then Ei.EmpName when CsTypeID=1 then Ebi.EquName end, " +
                        " 配置类型= case when CsTypeID=0 then '人员' when CsTypeID=1 then '设备' end, " +
                        " 部门=case when CsTypeID=0 then Di1.DeptName when CsTypeID=1 then Di2.DeptName end, " +
                        " Cd.Directional as 方向性, " +
                        " StationHeadDetectTime as 监测时间 " +
                     " From " +
                        " RealTimeCodeSender as Rcs left join CodeSender_Set as Cs on Cs.CsSetID=Rcs.CsSetID " +
                        " left join Emp_Info as Ei on Ei.EmpID=Cs.UserID and CsTypeID=0 " +
                        " left join Emp_NowCompany as Enc on Enc.EmpID=Ei.EmpID " +
                        " left join Dept_Info as Di1 on Di1.DeptID=Enc.DeptID " +
                        " left join CodeSender_Directional as Cd on Cd.DetectionInfo =Rcs.CodeSenderDirectional " +
                        " left join Equ_BaseInfo as Ebi on Ebi.EquID =Cs.UserID and CsTypeID=1 " +
                        " left join Dept_Info as Di2 on Di2.DeptID=Ebi.DeptID " +
                     " Where " +
                        " Rcs.StationAddress = " + strSta;
            if (displayType != 2)
            {
                strSql += " And CsTypeID=" + displayType.ToString();
            }
            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = dbacc.GetDataSet(strSql);
                dv.DataSource = ds.Tables[0].DefaultView;
            }
             */
            string procName = "PROC_GetRTStationCodeInfo";
            SqlParameter[] sqlParmeters ={
                            new SqlParameter("StationAddress",SqlDbType.Int),
                            new SqlParameter("sumType",SqlDbType.Int)
            };
            sqlParmeters[0].Value = strSta;
            sqlParmeters[1].Value = displayType;

            using (ds = new DataSet())
            {
                dv.Columns.Clear();
                ds = dbacc.GetDataSet(procName, sqlParmeters);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].Columns[0].ColumnName = HardwareName.Value(CorpsName.CodeSenderAddress);   //发码器编号
                    ds.Tables[0].Columns[5].ColumnName = HardwareName.Value(CorpsName.Inspect);             //监测时间

                    dv.DataSource = ds.Tables[0].DefaultView;

                    dv.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strCounts = ds.Tables[0].Rows.Count.ToString();
                    }
                    else
                    {
                        strCounts = "0";
                    }
                }
                else
                {
                    strCounts = "0";
                }
            }
        }
        #endregion

        #region 获取报警类别
        public DataTable SearchAlarmType()
        {
            strSql = " Select Title,EnumID From EnumTable Where FunID=12 And EnumValue=1";
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);

                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }
        #endregion

        #region 判断是否 报警
        /// <summary>
        /// 判断是否 报警
        /// </summary>
        /// <param name="intAlarmType">1:超时报警,2:区域报警,3:分站报警,4:超员报警,5:低电量报警</param>
        /// <returns>true 报警,false 不报警</returns>
        public bool IsAlarm(int intAlarmType)
        {
            if (!IsAlarmType(intAlarmType))
            {
                return false;
            }
            DataTable dt;
            switch (intAlarmType)
            {
                case 1:                             //超时报警
                    using(dt=new DataTable())
                    {
                        dt = OverTimeAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }                   
                    break;
                case 2:                             //区域报警
                    using (dt = new DataTable())
                    {
                        dt = TerAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    break;
                case 3:                             //分站故障报警
                    using (dt = new DataTable())
                    {
                        dt = StationAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    break;
                case 4:                             //超员报警
                    using (dt = new DataTable())
                    {
                        dt= OverEmpCountAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            //int j = Convert.ToInt32(tempdt.Rows[0][0]);
                            if (i > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    break;
                case 5:                             //低电量报警
                    using (dt = new DataTable())
                    {
                        dt = ElectricityAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = dt.Rows.Count;
                            if (i > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    break;
                case 6:                                 //接收器故障报警
                    using (dt = new DataTable())
                    {
                        dt = StaHeadAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    break;
                case 7:
                    using (dt = new DataTable())
                    {
                        dt = PathAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    break;

                default:
                    break;
            }

            return false;
        }

        #region 获取报警信息(DataSet)
        //查询超时
        private DataTable OverTimeAlarm()
        {
            strSql = " Select count(*) From RT_OverTimeInfo_View ";
            using(ds=new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        //区域报警
        private DataTable TerAlarm()
        {
            strSql = " Select count(*) From RT_TerritorialInfo as Rt left join Territorial_Info as Ti on Rt.TerritorialID=Ti.TerritorialID left join Territorial_Type as Tt on Tt.TerritorialTypeID=Ti.TerritorialTypeID Where Rt.IsAlarm = 1 ";
            using (ds=new DataSet())
            {
              ds = dbacc.GetDataSet(strSql);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }        
            }
        }

        //分站报警
        private DataTable StationAlarm()
        {
            strSql = " Select count(*) From Station_Info Where StationState=-1000 ";
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        //超员上限
        private DataTable OverEmpCountAlarm()
        {
            //strSql = " select EnumValue From EnumTable Where FunID=8 And EnumID=1 ";
            strSql = " Select count(1) From RT_OverEmployees ";
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        //下井总人数
        private DataTable RTInOutMineEmpCount()
        {
            strSql = " Select count(*) From RT_InOutMine as Ri left join CodeSender_Set as Cs on Cs.CsSetID=Ri.CsSetID Where CsTypeID=0 ";
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        //低电量报警
        private DataTable ElectricityAlarm()
        {
            string procName = "KJ128N_CodeAlarmElectricity_Select";
            SqlParameter[] sqlParmeters ={
                new SqlParameter("CodeSenderStateID",SqlDbType.Int)
            };
            sqlParmeters[0].Value = 4;
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(procName, sqlParmeters);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        //接收器故障报警
        private DataTable StaHeadAlarm()
        {
            //strSql = " select Count(*) from Station_Head_Info as Shi left join Station_Info as Si on Shi.StationAddress=Si.StationAddress "+
            //            " Where StationHeadState=-1000 or StationState=-1000 ";
            strSql = " Select Count(*) From KJ128N_RTStaHead_Info_View Where 接收器状态='故障'";
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 路线报警
        /// </summary>
        /// <returns></returns>
        private DataTable PathAlarm()
        {
            strSql = " Select * From RealTimeAlarmPathInfo";
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion
        #endregion

        #region 获取报警路径
        public DataTable LoadAlarmPath(int intType)
        {
            strSql = " Select AlarmWaveType,AlarmWavePath From AlarmSet Where AlarmSetType=" + intType.ToString();
            using (ds=new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds!=null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }         
        }
        #endregion

        #region 获取报警类别是否设置为报警
        private bool IsAlarmType(int intAlarmType)
        {
            strSql = " Select EnumValue from EnumTable Where FunID=12 and EnumID= " + intAlarmType.ToString();
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }
            return false;
        }
        #endregion

        #region 根据分站地址，获取分站位置
        public string SelectStationPlace(string strStaAddress)
        {
            strSql = " Select StationPlace from Station_Info Where StationAddress=" + strStaAddress;
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            return null;
        }
        #endregion

        #region 根据接收器地址，获取接收器位置
        public string SelectStaHeadPlace(string strStationAddress, string strStaHeadAddress)
        {
            strSql = " Select StationHeadPlace From Station_Head_Info Where StationAddress=" + strStationAddress + " And StationHeadAddress=" + strStaHeadAddress;
            using (ds = new DataSet())
            {
                ds = dbacc.GetDataSet(strSql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            return null;
        }
        #endregion

    }
}
