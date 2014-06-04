using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZzhaControlLibrary
{
    [Serializable]
    public class RouteModel
    {
        private PointF _from;

        public PointF From
        {
            get { return _from; }
            set { _from = value; }
        }
        private PointF _to;

        public PointF To
        {
            get { return _to; }
            set { _to = value; }
        }
        private int _routeLength;

        public int RouteLength
        {
            get { return _routeLength; }
            set { _routeLength = value; }
        }

        private Color _penColor;
        public Color PenColor
        {
            get { return _penColor; }
            set { _penColor = value; }
        }
    }
}
