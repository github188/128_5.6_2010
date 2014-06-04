using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    public class RouteModel
    {
        private string _from;

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }
        private string _to;

        public string To
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
    }
}
