using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    #region [PathInfoModel]

    /// <summary>
    /// ·����Ϣ
    /// </summary>
    public class PathInfoModel
    {
        /// <summary>
        /// id������
        /// </summary>
        private int id;
        /// <summary>
        /// id������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ·�߱��
        /// </summary>
        private string pathNo;
        /// <summary>
        /// ·�߱��
        /// </summary>
        public string PathNo
        {
            get { return pathNo; }
            set { pathNo = value; }
        }

        /// <summary>
        /// ·����
        /// </summary>
        private string pathName;
        /// <summary>
        /// ·����
        /// </summary>
        public string PathName
        {
            get { return pathName; }
            set { pathName = value; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        private string remark;
        /// <summary>
        /// ��ע
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
    /// ·����ϸ��Ϣ
    /// </summary>
    public class PathDetailModel
    {
        /// <summary>
        /// ������
        /// </summary>
        private int id;
        /// <summary>
        /// ������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int pathID;
        /// <summary>
        /// ·��˳��
        /// </summary>
        public int PathID
        {
            get { return pathID; }
            set { pathID = value; }
        }

        /// <summary>
        /// ·�߱��
        /// </summary>
        private string pathNo;
        /// <summary>
        /// ·�߱��
        /// </summary>
        public string PathNo
        {
            get { return pathNo; }
            set { pathNo = value; }
        }

        /// <summary>
        /// ��վ��ַ
        /// </summary>
        private int stationAddress;
        /// <summary>
        /// ��վ��ַ
        /// </summary>
        public int StationAddress
        {
            get { return stationAddress; }
            set { stationAddress = value; }
        }

        /// <summary>
        /// ̽ͷ��ַ
        /// </summary>
        private int stationHeadAddress;
        /// <summary>
        /// ̽ͷ��ַ
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
    /// ·��Ա����ϵ
    /// </summary>
    public class PathEmpRelationModel
    {
        /// <summary>
        /// ������
        /// </summary>
        private int id;
        /// <summary>
        /// ������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ·��Id
        /// </summary>
        private string pathNo;
        /// <summary>
        /// ·��Id
        /// </summary>
        public string PathNo
        {
            get { return pathNo; }
            set { pathNo = value; }
        }

        /// <summary>
        /// Ա�����
        /// </summary>
        private string empNo;
        /// <summary>
        /// Ա�����
        /// </summary>
        public string EmpNo
        {
            get { return empNo; }
            set { empNo = value; }
        }

        /// <summary>
        /// Ա��Id
        /// </summary>
        private int empID;
        /// <summary>
        /// Ա��Id
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
    /// ��ʷ·�߱���
    /// </summary>
    public class HisPathAlertModel
    {
        /// <summary>
        /// ������
        /// </summary>
        private int id;
        /// <summary>
        /// ������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ·��Id
        /// </summary>
        private int pathId;
        /// <summary>
        /// ·��Id
        /// </summary>
        public int PathId
        {
            get { return pathId; }
            set { pathId = value; }
        }

        /// <summary>
        /// ̽ͷId
        /// </summary>
        private int stationHeadId;
        /// <summary>
        /// ̽ͷId
        /// </summary>
        public int StationHeadId
        {
            get { return stationHeadId; }
            set { stationHeadId = value; }
        }

        /// <summary>
        /// Ա��Id
        /// </summary>
        private int empId;
        /// <summary>
        /// Ա��Id
        /// </summary>
        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        /// <summary>
        /// Ա�����
        /// </summary>
        private string empNO;
        /// <summary>
        /// Ա�����
        /// </summary>
        public string EmpNO
        {
            get { return empNO; }
            set { empNO = value; }
        }

        /// <summary>
        /// Ա������
        /// </summary>
        private string empName;
        /// <summary>
        /// Ա������
        /// </summary>
        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        /// <summary>
        /// ������ʼʱ��
        /// </summary>
        private DateTime alertBeginTime;
        /// <summary>
        /// ������ʼʱ��
        /// </summary>
        public DateTime AlertBeginTime
        {
            get { return alertBeginTime; }
            set { alertBeginTime = value; }
        }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        private DateTime alertEndTime;
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime AlertEndTime
        {
            get { return alertEndTime; }
            set { alertEndTime = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private int alertTimeValue;
        /// <summary>
        /// ����ʱ��
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
        /// ��ˮ�ţ�������
        /// </summary>
        private int id;
        /// <summary>
        /// ��ˮ�ţ�������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ��ԱID
        /// </summary>
        private int empID;
        /// <summary>
        /// ��ԱID
        /// </summary>
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        /// <summary>
        /// ��Ա���
        /// </summary>
        private string empNo;
        /// <summary>
        /// ��Ա���
        /// </summary>
        public string EmpNO
        {
            get { return empNo; }
            set { empNo = value; }
        }

        /// <summary>
        /// ���ID
        /// </summary>
        private int interval;
        /// <summary>
        /// ���ID
        /// </summary>
        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        /// <summary>
        /// ��ǰѲ��ʱ��
        /// </summary>
        private DateTime checkTime;
        /// <summary>
        /// ��ǰѲ��ʱ��
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
        /// ��ˮ�ţ�������
        /// </summary>
        private int id;
        /// <summary>
        /// ��ˮ�ţ�������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ��ԱID
        /// </summary>
        private int empID;
        /// <summary>
        /// ��ԱID
        /// </summary>
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        /// <summary>
        /// ��Ա���
        /// </summary>
        private string empNo;
        /// <summary>
        /// ��Ա���
        /// </summary>
        public string EmpNO
        {
            get { return empNo; }
            set { empNo = value; }
        }

        /// <summary>
        /// Ա������
        /// </summary>
        private string empName;
        /// <summary>
        /// Ա������
        /// </summary>
        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        /// <summary>
        /// ���ID
        /// </summary>
        private int interval;
        /// <summary>
        /// ���ID
        /// </summary>
        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        /// <summary>
        /// Ѳ�쿪ʼʱ��
        /// </summary>
        private DateTime checkBeginTime;
        /// <summary>
        /// Ѳ�쿪ʼʱ��
        /// </summary>
        public DateTime CheckBeginTime
        {
            get { return checkBeginTime; }
            set { checkBeginTime = value; }
        }

        /// <summary>
        /// Ѳ�����ʱ��
        /// </summary>
        private DateTime checkEndTime;
        /// <summary>
        /// Ѳ�����ʱ��
        /// </summary>
        public DateTime CheckEndTime
        {
            get { return checkEndTime; }
            set { checkEndTime = value; }
        }
    }

    #endregion
}
