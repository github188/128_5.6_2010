using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZzhaControlLibrary
{
    public class PositionChanger
    {
        public static PointF PositionChange(PointF from, PointF to, PointF old)
        {
            PointF newPoint = new Point();
            newPoint.X = old.X + to.X - from.X;
            newPoint.Y = old.Y + to.Y - from.Y;
            return newPoint;
        }

        public static PointF ZoomPositionChange(double bili,PointF old)
        {
            PointF newPoint = new PointF();
            newPoint.X =float.Parse((old.X * bili).ToString());
            newPoint.Y = float.Parse((old.Y * bili).ToString());
            return newPoint;
        }
    }
}
