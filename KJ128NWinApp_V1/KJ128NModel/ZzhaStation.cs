using System;
using System.Collections.Generic;
using System.Text;

namespace KJ128NModel
{
    public class ZzhaStation
    {
        private string _stationAddressNum;

        public string StationAddressNum
        {
            get { return _stationAddressNum; }
            set { _stationAddressNum = value; }
        }
        private string _position;

        public string Position
        {
            get { return this._position; }
            set { this._position = value; }
        }
    }
}
