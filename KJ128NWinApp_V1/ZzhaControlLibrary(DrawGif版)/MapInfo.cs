using System;
using System.Collections.Generic;
using System.Text;

namespace ZzhaControlLibrary
{
    public class MapInfo
    {
        private int mapLeft;

        public int MapLeft
        {
            get { return mapLeft; }
            set { mapLeft = value; }
        }

        private int mapTop;

        public int MapTop
        {
            get { return mapTop; }
            set { mapTop = value; }
        }

        private int mapWidth;

        public int MapWidth
        {
            get { return mapWidth; }
            set { mapWidth = value; }
        }

        private int mapHeight;

        public int MapHeight
        {
            get { return mapHeight; }
            set { mapHeight = value; }
        }

        public MapInfo(int left, int top, int width, int height)
        {
            this.MapLeft = left;
            this.MapTop = top;
            this.mapHeight = height;
            this.MapWidth = width;
        }
    }
}
