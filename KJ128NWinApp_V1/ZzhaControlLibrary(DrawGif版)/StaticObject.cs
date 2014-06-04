using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ZzhaControlLibrary
{
    public class StaticObject
    {
        private Image _StaticImage;

        public Image StaticImage
        {
            get { return _StaticImage; }
            set { _StaticImage = value; }
        }

        private string _StaticState;

        public string StaticState
        {
            get { return _StaticState; }
            set { _StaticState = value; }
        }

        private PointF _StaticPoint;

        public PointF StaticPoint
        {
            get { return _StaticPoint; }
            set { _StaticPoint = value; }
        }

        private PointF _StaticNowPoint;

        public PointF StaticNowPoint
        {
            get { return _StaticNowPoint; }
            set { _StaticNowPoint = value; }
        }

        private string _StaticName;

        public string StaticName
        {
            get { return _StaticName; }
            set { _StaticName = value; }
        }

        private string _DivName;

        public string DivName
        {
            get { return _DivName; }
            set { _DivName = value; }
        }

        private int _StaticWidth=50;

        public int StaticWidth
        {
            get { return _StaticWidth; }
            set { _StaticWidth = value; }
        }

        private int _StaticHeight=50;

        public int StaticHeight
        {
            get { return _StaticHeight; }
            set { _StaticHeight = value; }
        }

        private StaticType _Type;

        public StaticType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _NameKey;

        public string NameKey
        {
            get { return _NameKey; }
            set { _NameKey = value; }
        }

        private Font _StaticFont=Label.DefaultFont;

        public Font StaticFont
        {
            get { return _StaticFont; }
            set { _StaticFont = value; }
        }

        private Color _StaticColor = Color.Red;

        public Color StaticColor
        {
            get { return _StaticColor; }
            set { _StaticColor = value; }
        }
        //public StaticObject(float pointx, float pointy, string name, Image filepath, string divname, string staticfilepath, StaticType type)
        //{
        //    this.StaticPoint = new PointF(pointx, pointy);
        //    this.StaticName = name;
        //    this.StaticImage = filepath;
        //    this.DivName = divname;
        //    this.StaticState = staticfilepath;
        //    this.Type = type;
        //}
        public StaticObject(float pointx, float pointy, string name, string key, string divname, StaticType type,Font staticfont,Color staticcolor)
        {
            this.StaticPoint = new PointF(pointx, pointy);
            this.StaticName = name;
            this.DivName = divname;
            this.Type = type;
            this.NameKey = key;
            this.StaticFont = staticfont;
            this.StaticColor = staticcolor;
        }
        //public StaticObject(float pointx, float pointy, string name, string key, Image filepath, string divname, int width, int height, string staticfilepath, StaticType type)
        //{
        //    this.StaticPoint = new PointF(pointx, pointy);
        //    this.StaticName = name;
        //    this.StaticImage = filepath;
        //    this.DivName = divname;
        //    this.StaticWidth = width;
        //    this.StaticHeight = height;
        //    this.StaticState = staticfilepath;
        //    this.Type = type;
        //    this.NameKey = key;
        //}


        public StaticObject(float pointx, float pointy, Image filepath, string divname, string staticfilepath, StaticType type, Font staticfont, Color staticcolor)
        {
            this.StaticPoint = new PointF(pointx, pointy);
            //this.StaticName = name;
            this.StaticImage = filepath;
            this.DivName = divname;
            this.StaticState = staticfilepath;
            this.Type = type;
            this.StaticFont = staticfont;
            this.StaticColor = staticcolor;
        }


        public StaticObject(float pointx, float pointy, Image img, string divname, string staticfilepath, int width, int height, string name, string key, StaticType type, Font staticfont, Color staticcolor)
        {
            this.StaticPoint = new PointF(pointx, pointy);
            //this.StaticName = name;
            this.StaticImage = img;
            this.DivName = divname;
            this.StaticState = staticfilepath;
            this.StaticWidth = width;
            this.StaticHeight = height;
            this.StaticName = name;
            this.NameKey = key;
            this.Type = type;
            this.StaticFont = staticfont;
            this.StaticColor = staticcolor;
        }
        //public StaticObject(float pointx, float pointy, Image filepath, string divname, int width, int height, string staticfilepath, StaticType type)
        //{
        //    this.StaticPoint = new PointF(pointx, pointy);
        //    //this.StaticName = name;
        //    this.StaticImage = filepath;
        //    this.DivName = divname;
        //    this.StaticWidth = width;
        //    this.StaticHeight = height;
        //    this.StaticState = staticfilepath;
        //    this.Type = type;
        //}
    }
    public enum StaticType
    { 
        Image,
        Word,
        ImageAndWord
    }
}
