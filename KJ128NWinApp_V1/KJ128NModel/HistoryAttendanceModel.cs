using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    public class HistoryAttendanceModel
    {
        int m_ID_RealTimeError;
        long m_ID_HistroyAttendance;
        int m_BlockID;
        int m_EmployeeID;
        string m_EmployeeName;
        int m_DeptID;
        int m_ClassID;
        string m_ClassShortName;
        string m_BeginWorkTime;
        string m_EndWorkTime;
        int m_OperatorID;
        string m_Remark;
        int m_TimerIntervalID;
        string m_DataAttendance;
        /// <summary>
        /// 实时考勤异常表的流水
        /// </summary>
        public int ID_RealTimeError
        {
            get
            {
                return m_ID_RealTimeError;
            }
            set
            {
                m_ID_RealTimeError = value;
            }
        }

        /// <summary>
        /// 考勤历史表的流水号
        /// </summary>
        public long ID_HistoryAttendance
        {
            get
            {
                return m_ID_HistroyAttendance;
            }
            set
            {
                m_ID_HistroyAttendance = value;
            }
        }

        /// <summary>
        /// 员工卡号
        /// </summary>
        public int BlockID
        {
            get
            {
                return m_BlockID;
            }
            set
            {
                m_BlockID = value;
            }
        }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return m_EmployeeName;
            }
            set
            {
                m_EmployeeName = value;
            }
        }

        /// <summary>
        /// 员工流水号
        /// </summary>
        public int EmployeeID
        {
            get
            {
                return m_EmployeeID;
            }
            set
            {
                m_EmployeeID = value;
            }
        }

        /// <summary>
        /// 部门流水
        /// </summary>
        public int DeptID
        {
            get
            {
                return m_DeptID;
            }
            set
            {
                m_DeptID = value;
            }
        }

        /// <summary>
        /// 班次流水
        /// </summary>
        public int ClassID
        {
            get
            {
                return m_ClassID;
            }
            set
            {
                m_ClassID = value;
            }
        }

        /// <summary>
        /// 时段简称
        /// </summary>
        public string ClassShortName
        {
            get
            {
                return m_ClassShortName;
            }
            set
            {
                m_ClassShortName = value;
            }
        }

        /// <summary>
        /// 上班时间
        /// </summary>
        public string BeginWorkTime
        {
            get
            {
                return m_BeginWorkTime;
            }
            set
            {
                m_BeginWorkTime = value;
            }
        }

        /// <summary>
        /// 下班时间
        /// </summary>
        public string EndWorkTime
        {
            get
            {
                return m_EndWorkTime;
            }
            set
            {
                m_EndWorkTime = value;
            }
        }

        /// <summary>
        /// 操作员流水
        /// </summary>
        public int OperatorID
        {
            get
            {
                return m_OperatorID;
            }
            set
            {
                m_OperatorID = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return m_Remark;
            }
            set
            {
                m_Remark = value;
            }
        }

        /// <summary>
        /// 时段流水
        /// </summary>
        public int TimerIntervalID
        {
            get
            {
                return m_TimerIntervalID;
            }
            set
            {
                m_TimerIntervalID = value;
            }
        }

        public string DataAttendance
        {
            get
            {
                return m_DataAttendance;
            }
            set
            {
                m_DataAttendance = value;
            }
        }
    }
}
