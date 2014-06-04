using System;
using System.Collections.Generic;
using System.Text;

namespace ZzhaControlLibrary
{
    [Serializable]
    public class StationInfo
    {
        private string _StationID;

        public string StationID
        {
            get { return _StationID; }
            set { _StationID = value; }
        }

        private string _StationName;

        public string StationName
        {
            get { return _StationName; }
            set { _StationName = value; }
        }

        private System.Drawing.PointF _StationPoint;

        public System.Drawing.PointF StationPoint
        {
            get { return _StationPoint; }
            set { _StationPoint = value; }
        }

        public StationInfo()
        { 
            
        }
        public StationInfo(string id, string name)
        {
            this.StationID = id;
            this.StationName = name;
        }
    }
}
