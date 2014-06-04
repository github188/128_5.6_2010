using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    public class StationsInfoModel
    {
        #region ID 属性（）

        private int m_ID;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        #endregion

        #region StationAddress 属性（）
        private int m_StationAddress;
        /// <summary>
        /// 
        /// </summary>
        public int StationAddress
        {
            get
            {
                return m_StationAddress;
            }
            set
            {
                m_StationAddress = value;
            }
        }
        #endregion

        #region StationNO 属性（）

        private string m_StationNO;

        /// <summary>
        /// 
        /// </summary>
        public string StationNO
        {
            get
            {
                return m_StationNO;
            }
            set
            {
                m_StationNO = value;
            }
        }

        #endregion

        #region Place 属性（）

        private string m_Place;

        /// <summary>
        /// 
        /// </summary>
        public string Place
        {
            get
            {
                return m_Place;
            }
            set
            {
                m_Place = value;
            }
        }

        #endregion

        #region Type 属性（）

        private int m_Type;

        /// <summary>
        /// 
        /// </summary>
        public int Type
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }

        #endregion

        #region State 属性（）

        private int m_State;

        /// <summary>
        /// 
        /// </summary>
        public int State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
            }
        }

        #endregion

        #region StationX 属性（）

        private float m_StationX;

        /// <summary>
        /// 
        /// </summary>
        public float StationX
        {
            get
            {
                return m_StationX;
            }
            set
            {
                m_StationX = value;
            }
        }

        #endregion

        #region StationY 属性（）

        private float m_StationY;

        /// <summary>
        /// 
        /// </summary>
        public float StationY
        {
            get
            {
                return m_StationY;
            }
            set
            {
                m_StationY = value;
            }
        }

        #endregion

        #region
        private bool m_IsConfig;
        /// <summary>
        /// 
        /// </summary>
        public bool IsConfig
        {
            get
            {
                return m_IsConfig;
            }
            set
            {
                m_IsConfig = value;
            }
        }
        #endregion

        #region Remark 属性（）

        private string m_Remark;

        /// <summary>
        /// 
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

        #endregion

        #region 分站故障时间
        private DateTime m_StationBadTime;
        public DateTime StationBadTime
        {
            get
            {
                return m_StationBadTime;
            }
            set
            {
                m_StationBadTime = value;
            }
        }
        #endregion 分站故障时间
    }
}
