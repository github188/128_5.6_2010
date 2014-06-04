using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    public class PointsModel
    {
        // 
        private int m_id;

        // 
        private string m_PointId;

        // 
        private float m_x;

        // 
        private float m_y;

        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            get
            {
                return this.m_id;
            }
            set
            {
                this.m_id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PointId
        {
            get
            {
                return this.m_PointId;
            }
            set
            {
                this.m_PointId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float x
        {
            get
            {
                return this.m_x;
            }
            set
            {
                this.m_x = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float y
        {
            get
            {
                return this.m_y;
            }
            set
            {
                this.m_y = value;
            }
        }
    }
}
