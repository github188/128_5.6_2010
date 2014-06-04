using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ZzhaControlLibrary
{
    /// <summary>
    /// 移动者
    /// </summary>
    public class Mover
    {
        #region[声明]

        //*****************Czlt-2010-10-12**Start*****************    
        private float oldX;
        /// <summary>
        /// 上一次的X坐标
        /// </summary>
        public float OldX
        {
            get { return oldX; }
            set { oldX = value; }

        }

        private float oldY;
        /// <summary>
        /// 上一次的Y坐标
        /// </summary>
        public float OldY
        {
            get { return oldY; }
            set { oldY = value; }

        }

        private string strPassTime;
        /// <summary>
        /// 出分站的时间
        /// </summary>
        public string StrPassTime
        {
            get { return strPassTime; }
            set { strPassTime = value; }
        }

        private string strStationName;
        public string StrStationName
        {
            get { return strStationName; }
            set { strStationName = value; }
        }


        private int _nowStationsIndex = 0;
        /// <summary>
        /// 当前所在的位置
        /// </summary>
        public int NowStationsIndex
        {
            get { return this._nowStationsIndex; }
            set { this._nowStationsIndex = value; }
        }


        private int _stationSum = 1;
        /// <summary>
        /// 共有多少个分站.
        /// </summary>
        public int StationSum
        {
            get { return this._stationSum; }
            set { this._stationSum = value; }
        }

        //*****************Czlt-2010-10-12**End*******************

        private string labHead;
        /// <summary>
        /// 移动个人信息
        /// </summary>
        public string LabHead
        {
            get { return labHead; }
            set { labHead = value; }
        }

        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string labFoot;
        /// <summary>
        /// 移动起始时间，目的地等信息
        /// </summary>
        public string LabFoot
        {
            get { return labFoot; }
            set { labFoot = value; }
        }

        private Image _MoverImage;
        /// <summary>
        /// 移动者图片
        /// </summary>
        public Image MoverImage
        {
            get { return _MoverImage; }
            set { _MoverImage = value; }
        }
        
        private PointF _MapPoint;
        /// <summary>
        /// 地图上的坐标点
        /// </summary>
        public PointF MapPoint
        {
            get { return _MapPoint; }
            set { _MapPoint = value; }
        }

        private string dateAndTime;

        /// <summary>
        /// 进出基站时间集合
        /// </summary>
        public string DateAndTime
        {
          get { return dateAndTime; }
          set { dateAndTime = value; }
        }
        /// <summary>
        /// 拆分后的进出基站时间集合
        /// </summary>
        private string[] DataAndTimes;

        private string nextStation;
        /// <summary>
        /// 目的地集合
        /// </summary>
        public string NextStation
        {
            get { return nextStation; }
            set { nextStation = value; }
        }
        /// <summary>
        /// 拆分后的目的地集合
        /// </summary>
        private string[] NextStations;

        private string nextStationPoint;

        public string NextStationPoint
        {
            get { return nextStationPoint; }
            set { nextStationPoint = value; }
        }

        private string[] NextStationPoints;

        private string route;
        /// <summary>
        /// 路径点的集合
        /// </summary>
        public string Route
        {
            get { return route; }
            set { route = value; }
        }
       
        private float x;
        /// <summary>
        /// 当前的坐标X
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        private float y;
        /// <summary>
        /// 当前的坐标Y
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        /// <summary>
        /// 拆分后的路径坐标集合
        /// </summary>
        private string[] Routes;
        /// <summary>
        /// 目前坐标在路径集合中的位置
        /// </summary>
        private int NowIndex = 1;
        /// <summary>
        /// 在时间集合中的位置
        /// </summary>
        private int NowDatetime=0;
        /// <summary>
        /// 在目的地集合中的位置
        /// </summary>
        private int NowNextStation=0;

        //private bool HasShowed = false;

        private string zFilePath;
        /// <summary>
        /// 正向运动图片路径
        /// </summary>
        public string ZFilePath
        {
            get { return zFilePath; }
            set { zFilePath = value; }
        }

        private string fFilePath;
        /// <summary>
        /// 反向运动图片路径
        /// </summary>
        public string FFilePath
        {
            get { return fFilePath; }
            set { fFilePath = value; }
        }

        private string _NowFilePath;
        /// <summary>
        /// 当前图片路径
        /// </summary>
        public string NowFilePath
        {
            get { return _NowFilePath; }
            set { _NowFilePath = value; }
        }

        private float oldleft;
        /// <summary>
        /// 拖动前坐标记录X
        /// </summary>
        public float Oldleft
        {
            get { return oldleft; }
            set { oldleft = value; }
        }
        private float oldtop;
        /// <summary>
        /// 拖动前坐标记录Y
        /// </summary>
        public float Oldtop
        {
            get { return oldtop; }
            set { oldtop = value; }
        }

        private bool _isShow = false;

        public bool IsShow
        {
            get { return _isShow; }
            set { _isShow = value; }
        }

        private List<string> StationsRecord;
        //private int leftLenght;
        ///// <summary>
        ///// 拖动坐标偏量X;
        ///// </summary>
        //public int LeftLenght
        //{
        //    get { return leftLenght; }
        //    set { leftLenght = value; }
        //}

        //private int topLength;
        ///// <summary>
        ///// 拖动坐标偏量Y
        ///// </summary>
        //public int TopLength
        //{
        //    get { return topLength; }
        //    set { topLength = value; }
        //}
        
        private StepXY step;
        /// <summary>
        /// 移动信息类，用于存放最新的移动方向等
        /// </summary>
        internal StepXY Step
        {
            get { return step; }
        }
        #endregion

        #region[构造Mover]
        public void MoverCreate(string route, string datatime, string stations, string stationpoints, string name, string Zfilepath, string Ffilepath, List<string> stationrecord)
        {
            this.StationsRecord = stationrecord;
            this.Route = route;
            this.Routes = route.Split('|');
            string[] xy = this.Routes[0].Split(',');
            this.X = float.Parse(xy[0]);
            this.Y = float.Parse(xy[1]);
            this.Oldleft = float.Parse(xy[0]);
            this.Oldtop = float.Parse(xy[1]);
            xy = this.Routes[1].Split(',');
            this.step = GetSetp(this.X, this.Y, float.Parse(xy[0]), float.Parse(xy[1]));
            this.ZFilePath = Zfilepath;
            this.FFilePath = Ffilepath;
            if (datatime != null && datatime != "")
            {
                this.DateAndTime = datatime;
                this.DataAndTimes = DateAndTime.Split('|');
            }
            if (stations != null && stations != "")
            {
                this.NextStation = stations;
                NextStations = NextStation.Split('|');
            }
            if (stationpoints != null && stationpoints != "")
            {
                this.NextStationPoint = stationpoints;
                NextStationPoints = NextStationPoint.Split('|');
            }
            //PicBox = new PictureBox();
            //PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //PicBox.BackColor = System.Drawing.Color.Transparent;
            //PicBox.Size = new System.Drawing.Size(50, 50);
            labHead = name;
            labFoot = "";
            if (DataAndTimes.Length > 0)
            {
                labFoot = labFoot + DataAndTimes[0];
                //NowDatetime++;
            }
            if (NextStations.Length > 0)
            {
                labFoot = labFoot + "\r\n目的地:" + NextStations[0];
                //NowNextStation++;
            }
            if (Step.IsRtoL)
            {
                this.MoverImage = new System.Drawing.Bitmap(ZFilePath);
                this.NowFilePath = ZFilePath;
            }
            else
            {
                this.MoverImage = new System.Drawing.Bitmap(FFilePath);
                this.NowFilePath = FFilePath;
            }
        }
        #endregion

        #region[公共方法]
        /// <summary>
        /// 移动一次
        /// </summary>
        /// <returns>成功返回true,失败返回false</returns>
        public bool Move()
        {
            try
            {
                string nowposition = this.X.ToString() + "," + this.Y.ToString();
                if (NowIndex < Routes.Length)
                {
                    if (ComparePoint(nowposition, this.Routes[NowIndex], step.IsRtoL, step.IsTtoB))
                    {
                        //Czlt-2010-10-13
                        this.OldX = this.X;
                        this.OldY = this.Y;
                        

                        this.X += step.X * ZzhaMapGis.Speed * ZzhaMapGis.MoverBili;
                        this.y += step.Y * ZzhaMapGis.Speed * ZzhaMapGis.MoverBili;
                        if (!ComparePoint(this.X.ToString() + "," + this.Y.ToString(), this.Routes[NowIndex], step.IsRtoL, step.IsTtoB))
                        {
                            this.X = float.Parse(Routes[NowIndex].Split(',')[0]);
                            this.Y = float.Parse(Routes[NowIndex].Split(',')[1]);
                        }
                        return true;
                    }
                    else
                    {
                        NowIndex++;
                        if (NowIndex >= this.Routes.Length)
                        {
                            return false;
                        }
                        else
                        {
                            if (StationsRecord.Contains(X.ToString() + "," + Y.ToString()))
                            {
                                string nowxy = X.ToString() + "," + Y.ToString();
                                if (nowxy.Trim() == NextStationPoints[NowNextStation].Trim())
                                {
                                    if (NowDatetime < DataAndTimes.Length && NowNextStation < NextStations.Length)
                                    {
                                        //Czlt-2010-10-13
                                        this.StrPassTime = DataAndTimes[NowDatetime]; //当前分站时间
                                        this.StrStationName = NextStations[NowNextStation]; //当前分站名称
                                        this.StationSum = NextStations.Length-1; //共有多少个分站


                                        NowDatetime = NowDatetime + 2;
                                        NowNextStation++;
                                        LabFoot = DataAndTimes[NowDatetime] + "\r\n目的地:" + NextStations[NowNextStation];
                                        //Czlt-2010-10-13-下一个分站序数
                                        this.NowStationsIndex = NowNextStation;
                                       
                                    }
                                }
                            }
                            string[] xy = this.Routes[NowIndex].Split(',');
                            this.step = GetSetp(this.X, this.Y, float.Parse(xy[0]), float.Parse(xy[1]));
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void ReadyForReMove()
        {
            NowIndex = 1;
            NowDatetime = 0;
            NowNextStation = 0;
            this.Route = route;
            this.Routes = route.Split('|');
            string[] xy = this.Routes[0].Split(',');
            this.X = float.Parse(xy[0]);
            this.Y = float.Parse(xy[1]);
            this.Oldleft = float.Parse(xy[0]);
            this.Oldtop = float.Parse(xy[1]);
            xy = this.Routes[1].Split(',');
            this.step = GetSetp(this.X, this.Y, float.Parse(xy[0]), float.Parse(xy[1]));
            if (DataAndTimes.Length > 0)
            {
                labFoot = DataAndTimes[0];
                //NowDatetime++;
            }
            if (NextStations.Length > 0)
            {
                labFoot = labFoot + "\r\n目的地:" + NextStations[0];
                //NowNextStation++;
            }
            if (Step.IsRtoL)
            {
                ImageAnimator.StopAnimate(this.MoverImage, null);
                this.MoverImage = new System.Drawing.Bitmap(ZFilePath);
                this.NowFilePath = ZFilePath;
                if (ImageAnimator.CanAnimate(this.MoverImage))
                    ImageAnimator.Animate(this.MoverImage, null);
            }
            else
            {
                ImageAnimator.StopAnimate(this.MoverImage, null);
                this.MoverImage = new System.Drawing.Bitmap(FFilePath);
                this.NowFilePath = FFilePath;
                if (ImageAnimator.CanAnimate(this.MoverImage))
                    ImageAnimator.Animate(this.MoverImage, null);
            }
        }
        #endregion

        #region[私有方法]
        
        /// <summary>
        /// 对比两坐标点
        /// </summary>
        /// <param name="now">当前移动坐标</param>
        /// <param name="next">目的地坐标</param>
        /// <param name="xzhengfan">X正向移动</param>
        /// <param name="yzhengfan">Y正向移动</param>
        /// <returns>到达目的地返回false，未到达返回true</returns>
        private bool ComparePoint(string now, string next, bool xzhengfan,bool yzhengfan)
        {
            bool flag = true;
            string[] xy = now.Split(',');
            double nowX = double.Parse(xy[0]);
            double nowY = double.Parse(xy[1]);
            xy = next.Split(',');
            double nextX = double.Parse(xy[0]);
            double nextY = double.Parse(xy[1]);
            if (nextX == nowX && nextY == nowY)
            {
                return false;
            }
            else
            {
                //if (nextX > nowX || nextY > nowY)
                //    flag = true;
                //else
                //    flag = false;
                //if (xzhengfan || yzhengfan)
                //    return flag;
                //else
                //    return !flag;
                if (xzhengfan || yzhengfan)
                {
                    if (xzhengfan)
                    {
                        if (nextX > nowX)
                            flag = true;
                        else
                            flag = false;
                    }
                    else
                    {
                        if (nextY > nowY)
                            flag = true;
                        else
                            flag = false;
                    }
                }
                else
                {
                    if (nextX >= nowX&&nextY >= nowY)
                        flag = false;
                    else
                        flag = true;
                }
                return flag;
            }
        }
        /// <summary>
        /// 得到移动信息
        /// </summary>
        /// <param name="fromx">起始坐标X</param>
        /// <param name="fromy">起始坐标Y</param>
        /// <param name="tox">目的地坐标X</param>
        /// <param name="toy">目的地坐标Y</param>
        /// <returns>移动信息类</returns>
        private StepXY GetSetp(float fromx, float fromy, float tox, float toy)
        {
            float lenghtX = tox - fromx;
            float lengthY = toy - fromy;
            StepXY stepxy = new StepXY();
            if (lenghtX > 0)
            {
                stepxy.IsRtoL = true;
            }
            else
            {
                stepxy.IsRtoL = false;
            }
            if (lengthY > 0)
            {
                stepxy.IsTtoB = true;
            }
            else
            {
                stepxy.IsTtoB = false;
            }
            if (Math.Abs(lenghtX) > Math.Abs(lengthY))
            {
                stepxy.X = lenghtX / Math.Abs(lenghtX);
                stepxy.Y = lengthY / Math.Abs(lenghtX);
            }
            else
            {
                stepxy.X = lenghtX / Math.Abs(lengthY);
                stepxy.Y = lengthY / Math.Abs(lengthY);
            }
            return stepxy;
        }
        #endregion
    }
    #region[步差类]
    /// <summary>
    /// 移动信息保存类
    /// </summary>
    class StepXY
    {
        private float x;
        /// <summary>
        /// X的步差值
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        private float y;
        /// <summary>
        /// Y的步差值
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        private bool isRtoL;
        /// <summary>
        /// X轴是否正向
        /// </summary>
        public bool IsRtoL
        {
            get { return isRtoL; }
            set { isRtoL = value; }
        }

        private bool isTtoB;
        /// <summary>
        /// Y轴是否正向
        /// </summary>
        public bool IsTtoB
        {
            get { return isTtoB; }
            set { isTtoB = value; }
        }

        public StepXY()
        {

        }

        public StepXY(float x, float y, bool isrtol)
        {
            this.X = x;
            this.Y = y;
            this.isRtoL = isrtol;
        }
    }
    #endregion
}
