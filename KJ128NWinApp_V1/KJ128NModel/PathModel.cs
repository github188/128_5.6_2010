using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    #region [PathInfoModel]

    /// <summary>
    /// 路线信息
    /// </summary>
    public class PathInfoModel
    {
        /// <summary>
        /// id自增列
        /// </summary>
        private int id;
        /// <summary>
        /// id自增列
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 路线编号
        /// </summary>
        private string pathNo;
        /// <summary>
        /// 路线编号
        /// </summary>
        public string PathNo
        {
            get { return pathNo; }
            set { pathNo = value; }
        }

        /// <summary>
        /// 路线名
        /// </summary>
        private string pathName;
        /// <summary>
        /// 路线名
        /// </summary>
        public string PathName
        {
            get { return pathName; }
            set { pathName = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }

    #endregion

    #region [PathDetailModel]

    /// <summary>
    /// 路线详细信息
    /// </summary>
    public class PathDetailModel
    {
        /// <summary>
        /// 自增列
        /// </summary>
        private int id;
        /// <summary>
        /// 自增列
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int pathID;
        /// <summary>
        /// 路线顺序
        /// </summary>
        public int PathID
        {
            get { return pathID; }
            set { pathID = value; }
        }

        /// <summary>
        /// 路线编号
        /// </summary>
        private string pathNo;
        /// <summary>
        /// 路线编号
        /// </summary>
        public string PathNo
        {
            get { return pathNo; }
            set { pathNo = value; }
        }

        /// <summary>
        /// 分站地址
        /// </summary>
        private int stationAddress;
        /// <summary>
        /// 分站地址
        /// </summary>
        public int StationAddress
        {
            get { return stationAddress; }
            set { stationAddress = value; }
        }

        /// <summary>
        /// 探头地址
        /// </summary>
        private int stationHeadAddress;
        /// <summary>
        /// 探头地址
        /// </summary>
        public int StationHeadAddress
        {
            get { return stationHeadAddress; }
            set { stationHeadAddress = value; }
        }

        private int m_PathInterval;
        public int PathInterval
        {
            get { return m_PathInterval; }
            set { m_PathInterval = value; }
        }
    }
    #endregion

    #region [PathEmpRelationModel]

    /// <summary>
    /// 路线员工关系
    /// </summary>
    public class PathEmpRelationModel
    {
        /// <summary>
        /// 自增列
        /// </summary>
        private int id;
        /// <summary>
        /// 自增列
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 路线Id
        /// </summary>
        private string pathNo;
        /// <summary>
        /// 路线Id
        /// </summary>
        public string PathNo
        {
            get { return pathNo; }
            set { pathNo = value; }
        }

        /// <summary>
        /// 员工编号
        /// </summary>
        private string empNo;
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmpNo
        {
            get { return empNo; }
            set { empNo = value; }
        }

        /// <summary>
        /// 员工Id
        /// </summary>
        private int empID;
        /// <summary>
        /// 员工Id
        /// </summary>
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
    }
    #endregion

    #region [HisPathAlertModel]

    /// <summary>
    /// 历史路线报警
    /// </summary>
    public class HisPathAlertModel
    {
        /// <summary>
        /// 自增列
        /// </summary>
        private int id;
        /// <summary>
        /// 自增列
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 路线Id
        /// </summary>
        private int pathId;
        /// <summary>
        /// 路线Id
        /// </summary>
        public int PathId
        {
            get { return pathId; }
            set { pathId = value; }
        }

        /// <summary>
        /// 探头Id
        /// </summary>
        private int stationHeadId;
        /// <summary>
        /// 探头Id
        /// </summary>
        public int StationHeadId
        {
            get { return stationHeadId; }
            set { stationHeadId = value; }
        }

        /// <summary>
        /// 员工Id
        /// </summary>
        private int empId;
        /// <summary>
        /// 员工Id
        /// </summary>
        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        /// <summary>
        /// 员工编号
        /// </summary>
        private string empNO;
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmpNO
        {
            get { return empNO; }
            set { empNO = value; }
        }

        /// <summary>
        /// 员工姓名
        /// </summary>
        private string empName;
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        /// <summary>
        /// 报警开始时间
        /// </summary>
        private DateTime alertBeginTime;
        /// <summary>
        /// 报警开始时间
        /// </summary>
        public DateTime AlertBeginTime
        {
            get { return alertBeginTime; }
            set { alertBeginTime = value; }
        }

        /// <summary>
        /// 报警结束时间
        /// </summary>
        private DateTime alertEndTime;
        /// <summary>
        /// 报警结束时间
        /// </summary>
        public DateTime AlertEndTime
        {
            get { return alertEndTime; }
            set { alertEndTime = value; }
        }

        /// <summary>
        /// 报警时间
        /// </summary>
        private int alertTimeValue;
        /// <summary>
        /// 报警时间
        /// </summary>
        public int AlertTimeValue
        {
            get { return alertTimeValue; }
            set { alertTimeValue = value; }
        }	
    }

    #endregion

    #region [RealTimePathCheckModel]

    public class RealTimePathCheckModel
    {
        /// <summary>
        /// 流水号，自增列
        /// </summary>
        private int id;
        /// <summary>
        /// 流水号，自增列
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 人员ID
        /// </summary>
        private int empID;
        /// <summary>
        /// 人员ID
        /// </summary>
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        /// <summary>
        /// 人员编号
        /// </summary>
        private string empNo;
        /// <summary>
        /// 人员编号
        /// </summary>
        public string EmpNO
        {
            get { return empNo; }
            set { empNo = value; }
        }

        /// <summary>
        /// 班次ID
        /// </summary>
        private int interval;
        /// <summary>
        /// 班次ID
        /// </summary>
        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        /// <summary>
        /// 当前巡检时间
        /// </summary>
        private DateTime checkTime;
        /// <summary>
        /// 当前巡检时间
        /// </summary>
        public DateTime CheckTime
        {
            get { return checkTime; }
            set { checkTime = value; }
        }	
    }

    #endregion

    #region [HisPathCheckModel]

    public class HisPathCheckModel
    {
        /// <summary>
        /// 流水号，自增列
        /// </summary>
        private int id;
        /// <summary>
        /// 流水号，自增列
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 人员ID
        /// </summary>
        private int empID;
        /// <summary>
        /// 人员ID
        /// </summary>
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        /// <summary>
        /// 人员编号
        /// </summary>
        private string empNo;
        /// <summary>
        /// 人员编号
        /// </summary>
        public string EmpNO
        {
            get { return empNo; }
            set { empNo = value; }
        }

        /// <summary>
        /// 员工姓名
        /// </summary>
        private string empName;
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        /// <summary>
        /// 班次ID
        /// </summary>
        private int interval;
        /// <summary>
        /// 班次ID
        /// </summary>
        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        /// <summary>
        /// 巡检开始时间
        /// </summary>
        private DateTime checkBeginTime;
        /// <summary>
        /// 巡检开始时间
        /// </summary>
        public DateTime CheckBeginTime
        {
            get { return checkBeginTime; }
            set { checkBeginTime = value; }
        }

        /// <summary>
        /// 巡检结束时间
        /// </summary>
        private DateTime checkEndTime;
        /// <summary>
        /// 巡检结束时间
        /// </summary>
        public DateTime CheckEndTime
        {
            get { return checkEndTime; }
            set { checkEndTime = value; }
        }
    }

    #endregion
}
