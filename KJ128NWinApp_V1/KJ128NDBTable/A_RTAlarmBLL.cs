using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KJ128NDataBase;

namespace KJ128NDBTable
{
    public class A_RTAlarmBLL
    {

        #region【声明】

        private A_RTAlarmDAL rtadal = new A_RTAlarmDAL();

        private DataSet ds;
        #endregion

        #region【方法：获取部门信息（树）——实时超时】

        public DataSet GetDeptTree_EmpOverTime()
        {
            return rtadal.GetDeptTree_EmpOverTime();
        }

        #endregion

        #region 【方法: 查询超时报警】

        public DataSet Select_EmpOverTime(string strWhere)
        {
            return rtadal.Select_EmpOverTime(strWhere);
        }

        #endregion

        #region[方法：查询区域超时]
        public DataSet Select_EmpTerOverTime(string str)
        {
            return rtadal.Select_TerEmpOverTime(str);
        }
        #endregion

        #region [ 方法: 查询求救信息的总数 ]
        /// <summary>
        /// 查询求救信息的总数
        /// </summary>
        /// <returns>实时求救信息总数</returns>
        public string GetEmpHelpCounts()
        {
            return rtadal.GetEmpHelpCounts();
        }

        #endregion

        #region【方法：判断是否报警】
        /// <summary>
        /// 判断是否 报警
        /// </summary>
        /// <param name="intAlarmType">1:超时报警,2:区域报警,3:分站报警,4:超员报警,5:低电量报警,6:接收器故障报警,7:路线报警</param>
        /// <returns>true 报警,false 不报警</returns>
        public bool IsAlarm(int intAlarmType)
        {
            DataTable dt;
            switch (intAlarmType)
            {
                case 1:                             //超时报警
                    using (dt = new DataTable())
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
                        dt = OverEmpCountAlarm();
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
                case 7:                                 //路线报警
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
                case 8:                                 //超速报警
                    using (dt=new DataTable())
                    {
                        dt = OverSpeedAlarm();
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
                case 9:                                 //欠速报警
                    using (dt = new DataTable())
                    {
                        dt = LackSpeedAlarm();
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
                case 11:
                    using (dt = new DataTable())
                    {
                        dt = Selelct_Ter_count();
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
                case 12:                                //区域超员报警
                    using (dt = new DataTable())
                    {
                        dt = TerOverEmpAlarm();
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
                case 13:               //异地交接班报警
                    using (dt = new DataTable())
                    {
                        dt = AssociateInfoAlarm();
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
                case 14:
                    using (dt = new DataTable())
                    {
                        dt = CheckCardsAlarm();
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
                case 15:
                    using (dt = new DataTable())
                    {
                        dt = InWellValidate();
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

        #endregion

        #region【方法：获取报警信息(DataSet)】

        //查询超时
        private DataTable OverTimeAlarm()
        {
            
            using (ds = new DataSet())
            {
                ds = rtadal.OverTimeAlarm(); ;
                if ( ds!=null && ds.Tables.Count > 0)
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
            using (ds = new DataSet())
            {
                ds = rtadal.TerAlarm();
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

        //分站报警
        private DataTable StationAlarm()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.StationAlarm();
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

        //超员上限
        private DataTable OverEmpCountAlarm()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.OverEmpCountAlarm();
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

        //下井总人数
        private DataTable RTInOutMineEmpCount()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.RTInOutMineEmpCount();
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

        //低电量报警
        private DataTable ElectricityAlarm()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.ElectricityAlarm();
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

        //接收器故障报警
        private DataTable StaHeadAlarm()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.StaHeadAlarm();
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
        //区域报警
        private DataTable Selelct_Ter_count()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.Selelct_Ter_count();
                if (ds != null && ds.Tables.Count > 0)
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
            using (ds = new DataSet())
            {
                ds = rtadal.PathAlarm();
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

        /// <summary>
        /// 超速报警
        /// </summary>
        /// <returns></returns>
        private DataTable OverSpeedAlarm()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.OverSpeedAlarm();
                if (ds != null && ds.Tables.Count > 0)
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
        /// 欠速报警
        /// </summary>
        /// <returns></returns>
        private DataTable LackSpeedAlarm()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.LackSpeedAlarm();
                if (ds != null && ds.Tables.Count > 0)
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
        /// 区域超员报警
        /// </summary>
        /// <returns></returns>
        private DataTable TerOverEmpAlarm()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.TerOverEmpAlarm();
                if (ds != null && ds.Tables.Count > 0)
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
        /// 异地交接班报警
        /// </summary>
        /// <returns></returns>
        private DataTable AssociateInfoAlarm()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.AssociateAlarm();
                if (ds != null && ds.Tables.Count > 0)
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
        /// 唯一性检测报警
        /// </summary>
        /// <returns></returns>
        private DataTable CheckCardsAlarm()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.CheckCardsAlarm();
                if (ds != null && ds.Tables.Count > 0)
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
        /// 验证下井人员
        /// </summary>
        /// <returns></returns>
        private DataTable InWellValidate()
        {
            using (ds = new DataSet())
            {
                ds = rtadal.InWellValidateAlarm();
                if (ds != null && ds.Tables.Count > 0)
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

        #region【方法：获取报警路径】

        public DataTable LoadAlarmPath(int intType)
        {
            using (ds = new DataSet())
            {
                ds = rtadal.LoadAlarmPath(intType);
                if (ds != null && ds.Tables.Count > 0)
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

        #region 【方法：查询异地交接班报警】
        public DataSet Select_Associate(string strWhere)
        {
            return rtadal.Select_Associate(strWhere);
        }
        #endregion

        #region 【方法: 查询超员报警】

        public DataSet Select_OverEmp()
        {
            return rtadal.Select_OverEmp(1);
        }

        #endregion

        #region【方法：存储超员报警人数】

        public int SaveEmpCount(string strEmpCount)
        {
            return rtadal.SaveEmpCount(strEmpCount);
        }

        #endregion

        #region【方法：判断是否超员】

        public bool IsOverEmp()
        {
            return rtadal.IsOverEmp();
        }

        #endregion

        #region【方法：加载超员人数】

        public DataSet GetEmpCount()
        {
            return rtadal.GetEmpCount();
        }

        #endregion

        #region【方法：获取区域信息（树）——实时区域】

        public DataSet GetDeptTree_Territorial()
        {
            return rtadal.GetDeptTree_Territorial();
        }

        #endregion

        #region 【方法: 查询区域报警信息】

        public DataSet Select_Territorial(string strWhere)
        {
            return rtadal.Select_Territorial(strWhere);
        }

        #endregion


        #region【方法：获取传输分站信息（树）——实时传输分站】

        public DataSet GetTree_Station()
        {
            return rtadal.GetTree_Station();
        }

        #endregion

        #region 【方法: 查询实时传输分站故障信息】

        public DataSet Select_Station(string strWhere)
        {
            return rtadal.Select_Station(strWhere);
        }

        #endregion

        #region【方法：获取读卡分站信息（树）——实时读卡分站】

        public DataSet GetTree_StationHead()
        {
            return rtadal.GetTree_StationHead();
        }

        #endregion

        #region 【方法: 查询实时读卡分站故障信息】

        public DataSet Select_StationHead(string strWhere)
        {
            return rtadal.Select_StationHead(strWhere);
        }

        #endregion

        #region 【方法: 查询实时低电量信息】

        public DataSet Select_Electricity(string strWhere)
        {
            return rtadal.Select_Electricity(strWhere);
        }

        #endregion

        #region【方法：获取部门信息（树）——工作异常】

        public DataSet GetDeptTree_Path()
        {
            return rtadal.GetDeptTree_Path();
        }

        #endregion

        #region 【方法: 查询工作异常信息】

        public DataSet Select_Path(string strWhere)
        {
            return rtadal.Select_Path(strWhere);
        }

        #endregion

        #region【方法：获取部门信息（树）——超速】

        public DataSet GetDeptTree_OverSpeed()
        {
            return rtadal.GetDeptTree_OverSpeed();
        }

        #endregion

        #region 【方法: 查询超速报警信息】

        public DataSet Select_OverSpeed(string strWhere)
        {
            return rtadal.Select_OverSpeed(strWhere);
        }

        #endregion

        #region【方法：获取部门信息（树）——欠速】

        public DataSet GetDeptTree_LackSpeed()
        {
            return rtadal.GetDeptTree_LackSpeed();
        }

        #endregion

        #region 【方法: 查询欠速报警信息】

        public DataSet Select_LackSpeed(string strWhere)
        {
            return rtadal.Select_LackSpeed(strWhere);
        }

        #endregion

        #region【方法：获取部门信息（树）——求救】

        public DataSet GetDeptTree_EmpHelp()
        {
            return rtadal.GetDeptTree_EmpHelp();
        }

        #endregion

        #region 【方法: 查询求救报警】

        public DataSet Select_EmpHelp(string strWhere)
        {
            return rtadal.Select_EmpHelp(strWhere);
        }
        #endregion

        public DataSet Select_InWellValidate(string strWhere)
        {
            return rtadal.Select_InWellValidate(strWhere);
        }

        #region【方法：完成求救信息】

        public int DeleteRTEmpHelp(string strCodeSenderAddress,string strMeasure)
        {
            return rtadal.DeleteRTEmpHelp(strCodeSenderAddress, strMeasure);
        }

        #endregion

        #region 【方法：解除唯一性报警信息】
        public int UnchainRTOnlyone(string strCodeSenderAddress,string strName)
        {
            return rtadal.UnChainOnlyone(strCodeSenderAddress,strName);
        }
        #endregion

        #region 【方法: 查询区域超员报警】

        public DataSet Select_TerOverEmp()
        {
            return rtadal.Select_TerOverEmp();
        }

        #endregion

        #region 【方法：获取部门信息（树）--唯一性】
        public DataSet GetDeptTree_CheckCards()
        {
            return rtadal.GetDeptTree_CheckCards();
        }
        #endregion

        #region 【方法：获取部门信息（树）--下井人员验证】
        public DataSet GetDeptTree_InWellValidate()
        {
            return rtadal.GetDeptTree_InWellValidate();
        }
        #endregion

        #region 【方法: 查询唯一性报警】

        public DataSet Select_OnlyOne(string strWhere)
        {
            return rtadal.Select_OnlyOne(strWhere);
        }

        #endregion

        #region【方法：获取是否启用该报警】

        public DataSet IsEnableAlarm(int intAlarm)
        {
            return rtadal.IsEnableAlarm(intAlarm);
        }

        #endregion


        #region 【Czlt-2011-05-25 加载直流供电的传输分站】
        /// <summary>
        /// 加载传输分站直流供电情况
        /// </summary>
        /// <returns></returns>
        public DataSet GetTree_StaEle()
        {
            return rtadal.GetTree_StaEle();
        }
        /// <summary>
        /// 加载交换机交直流供电情况
        /// </summary>
        /// <returns></returns>
        public DataSet GetTree_JHHEle()
        {
            return rtadal.GetTree_JHHEle();
        }

        /// <summary>
        /// 查询传输分站供电情况
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetStationEle(string strSql)
        {
            return rtadal.GetStationEle(strSql);
        }

        /// <summary>
        /// 查询交换机供电情况
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetJHJEle(string strWhere, int type)
        {
            return rtadal.GetJHJEle(strWhere, type);
        }
        #endregion

        #region【Czlt-2011-07-13 判断报警信息】
        #region【方法：判断是否报警】
        /// <summary>
        /// 判断是否 报警
        /// </summary>
        /// <param name="intAlarmType">1:超时报警,2:区域报警,3:分站报警,4:超员报警,5:低电量报警,6:接收器故障报警,7:路线报警</param>
        /// <returns>true 报警,false 不报警</returns>
        public int CzltIsAlarm(int intAlarmType)
        {
            DataTable dt;
            switch (intAlarmType)
            {
                case 1:                             //超时报警
                    using (dt = new DataTable())
                    {
                        dt = OverTimeAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
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
                                return i;
                            }
                            else
                            {
                                return 0;
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
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                    break;
                case 4:                             //超员报警
                    using (dt = new DataTable())
                    {
                        dt = OverEmpCountAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            //int j = Convert.ToInt32(tempdt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
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
                                return i;
                            }
                            else
                            {
                                return 0;
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
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                    break;
                case 7:                                 //路线报警
                    using (dt = new DataTable())
                    {
                        dt = PathAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                    break;
                case 8:                                 //超速报警
                    using (dt = new DataTable())
                    {
                        dt = OverSpeedAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }

                    break;
                case 9:                                 //欠速报警
                    using (dt = new DataTable())
                    {
                        dt = LackSpeedAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }

                    break;
                case 11:
                    using (dt = new DataTable())
                    {
                        dt = Selelct_Ter_count();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                    break;
                case 12:                                //区域超员报警
                    using (dt = new DataTable())
                    {
                        dt = TerOverEmpAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }

                    break;
                case 13:               //异地交接班报警
                    using (dt = new DataTable())
                    {
                        dt = AssociateInfoAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                    break;
                case 14:
                    using (dt = new DataTable())
                    {
                        dt = CheckCardsAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                    break;
                case 15:
                    using (dt = new DataTable())
                    {
                        dt = InWellValidate();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                    break;
                ////传输分站供电报警
                case 16:
                    using (dt = new DataTable())
                    {
                        dt = rtadal.StationEleAlarm();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int i = Convert.ToInt32(dt.Rows[0][0]);
                            if (i > 0)
                            {
                                return i;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                    break;
                ////交换机供电报警
                //case 17:
                //    using (dt = new DataTable())
                //    {
                //        dt = rtadal.JHJEleAlarm();
                //        if (dt != null && dt.Rows.Count > 0)
                //        {
                //            int i = Convert.ToInt32(dt.Rows[0][0]);
                //            if (i > 0)
                //            {
                //                return i;
                //            }
                //            else
                //            {
                //                return 0;
                //            }
                //        }
                //    }

                //    break;
                default:
                    break;
            }

            return 0;
        }

        #endregion
        #endregion


        #region 【Czlt-2011-12-10 监测配置文件被修改的日期】
        public string GetChangeTime()
        {
            return rtadal.Select_Change();
        }
        #endregion

        #region 【Czlt-2012-1-12 生成历史数据】
        public int CzltCreateHisTable(int iYear, int iMonth)
        {
            return rtadal.CzltCreateHisTable(iYear, iMonth);
        }
        #endregion
    }
}
