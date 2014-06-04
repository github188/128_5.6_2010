using System;
using System.Collections.Generic;
using System.Text;

namespace ZzhaControlLibrary
{
    public class MapDivInfo
    {
        private string _MapDivName;

        public string MapDivName
        {
            get { return _MapDivName; }
            set { _MapDivName = value; }
        }

        private int _DivMinWidth;

        public int DivMinWidth
        {
            get { return _DivMinWidth; }
            set { _DivMinWidth = value; }
        }

        private int _DivMaxWidth;

        public int DivMaxWidth
        {
            get { return _DivMaxWidth; }
            set { _DivMaxWidth = value; }
        }

        public MapDivInfo()
        { }

        public MapDivInfo(string name,int min,int max)
        {
            this.MapDivName = name;
            this.DivMinWidth = min;
            this.DivMaxWidth = max;
        }
    }
}
