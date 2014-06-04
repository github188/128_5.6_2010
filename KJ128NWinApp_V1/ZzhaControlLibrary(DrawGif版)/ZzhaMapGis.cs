using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace ZzhaControlLibrary
{
    public partial class ZzhaMapGis : UserControl
    {

        #region[声明]
        //****************************Czlt-2010-10-12*路径*Start****************************************

        private bool isClear = false;
        private bool isPaintRoute = false;   
        private bool isStartPoint = true;
        private int index = 0;
        /// <summary>
        /// 重要人员的索引
        /// </summary>
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        private PointF startPoint;
        /// <summary>
        /// 地图上的坐标点
        /// </summary>
        public PointF StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        /// <summary>
        /// 是否开启画路线图
        /// </summary>
        public bool IsPaintRoute
        {
            get { return isPaintRoute; }
            set { isPaintRoute = value; }
        }

       // public List<RouteModel> CzltRouteList = new List<RouteModel>();//路径链表画颜色

        public List<RouteModel> CzltRouteList0 = new List<RouteModel>();//0号路径链表
        public List<RouteModel> CzltRouteList1 = new List<RouteModel>();//1号路径链表
        public List<RouteModel> CzltRouteList2 = new List<RouteModel>();//2号路径链表
        public List<RouteModel> CzltRouteList3 = new List<RouteModel>();//3号路径链表
        public List<RouteModel> CzltRouteList4 = new List<RouteModel>();//4号路径链表
        public List<RouteModel> CzltRouteList5 = new List<RouteModel>();//5号路径链表
        public List<RouteModel> CzltRouteList6 = new List<RouteModel>();//6号路径链表
        public List<RouteModel> CzltRouteList7 = new List<RouteModel>();//7号路径链表
        public List<RouteModel> CzltRouteList8 = new List<RouteModel>();//8号路径链表
        public List<RouteModel> CzltRouteList9 = new List<RouteModel>();//9号路径链表


        private string strNameAndColor;
        /// <summary>
        /// 人员路线的颜色配置
        /// </summary>
        public string StrNameAndColor
        {
            get { return strNameAndColor; }
            set { strNameAndColor = value; }
        }

        /// <summary>
        /// 序号和颜色
        /// </summary>
       // Hashtable hashPenColor = new Hashtable();
        ///// <summary>
        ///// 姓名和序号
        ///// </summary>
        //Hashtable hashNameIndex = new Hashtable();

        /// <summary>
        /// 站点哈希表
        /// </summary>
        Hashtable hashStation = new Hashtable();

        private Hashtable hashNameColor = new Hashtable();
        /// <summary>
        /// 从界面传入的人员和颜色的比对哈希表
        /// </summary>
        public Hashtable HashNameColor
        {
            get { return hashNameColor; }
            set { hashNameColor = value; }
        }


        private string strPassTime = "";
        private string strStationName = "";
        private string strHeadName = "";
        private string strImpEmpName = "";
        /// <summary>
        /// 重点监视人员的名称
        /// </summary>
        public string StrImpEmpName
        {
            get { return strImpEmpName; }
            set { strImpEmpName = value; }
        }


        //****************************Czlt-2010-10-12*路径*End****************************************


        private BufferedGraphics bgraph;
        private BufferedGraphicsContext context;
        public static List<PointF> lpt = new List<PointF>();
        private Timer GifTimer = new Timer();

        //private bool _StaticCanMove = false;
        ///// <summary>
        ///// 是否可以移动静态对象
        ///// </summary>
        //public bool StaticCanMove
        //{
        //    get { return _StaticCanMove; }
        //    set { _StaticCanMove = value; }
        //}

        public static bool _IsStationChangeed = false;
        /// <summary>
        /// 分站是否发生变化
        /// </summary>
        public bool IsStationChangeed
        {
            get { return _IsStationChangeed; }
            set { _IsStationChangeed = value; }
        }

        private List<PointF> listPointDraw = new List<PointF>();
        private static ListView _StationListView = null;

        private static bool _IsEverStop = false;

        /// <summary>
        /// 画路径过程中是否被打断过
        /// </summary>
        public static bool IsEverStop
        {
            get
            {
                return _IsEverStop;
            }
            set
            {
                _IsEverStop = value;
            }
        }


        public static ListView StationlistView
        {
            get
            {
                return _StationListView;
            }
            set
            {
                _StationListView = value;
            }
        }

        private static bool _IsBeginDrawRoute = false;
        /// <summary>
        /// 是否开始画路径
        /// </summary>
        public static bool IsBeginDrawRoute
        {
            get
            {
                return _IsBeginDrawRoute;
            }
            set
            {
                _IsBeginDrawRoute = value;
            }
        }

        public static bool _IsRouteLine = true;
        /// <summary>
        /// 路径点使用线段连接为true，用折线连接则为flase
        /// </summary>
        public static bool IsRouteLine
        {
            get
            {
                return _IsRouteLine;
            }
            set
            {
                _IsRouteLine = value;
            }
        }
        private bool _UseGif = false;
        /// <summary>
        /// 是否使用Gif动画效果
        /// </summary>
        public bool UseGif
        {
            get { return _UseGif; }
            set
            {
                _UseGif = value;
                if (value == true)
                {
                    this.StartFlash();
                }
                else
                {
                    this.EndFlash();
                }
            }
        }

        private bool _ShowStationOther = false;
        /// <summary>
        /// 是否显示分站其他信息
        /// </summary>
        public bool ShowStationOther
        {
            get { return _ShowStationOther; }
            set { _ShowStationOther = value; }
        }

        private int _maxWidth;

        public int MaxWidth
        {
            get { return _maxWidth; }
            set { _maxWidth = value; }
        }

        private int _minWidth;

        public int MinWidth
        {
            get { return _minWidth; }
            set { _minWidth = value; }
        }

        private string _MapFilePath;
        /// <summary>
        /// 地图文件路径
        /// </summary>
        public string MapFilePath
        {
            get { return _MapFilePath; }
            set
            {
                _MapFilePath = value;
                try
                {
                    MinMap = this.NewBitMap(_MapFilePath);
                    Map = CreateBitMap(_MapFilePath);
                    LoadMap();
                }
                catch (ArgumentException ex)
                {
                    Map = null;
                    MinMap = null;
                }
            }
        }

        private string _StationFilePath;
        /// <summary>
        /// 分站图形文件路径
        /// </summary>
        public string StationFilePath
        {
            get { return _StationFilePath; }
            set
            {
                _StationFilePath = value;
                try
                {
                    this.StationImg = new Bitmap(this._StationFilePath);
                }
                catch (ArgumentException ex)
                {
                    this.StationImg = null;
                }
                LoadMap();
            }
        }

        private bool _UseDiv;
        /// <summary>
        /// 是否使用层显示
        /// </summary>
        public bool UseDiv
        {
            get { return _UseDiv; }
            set
            {
                _UseDiv = value;
                FlashMap();
            }
        }

        private Image _Map;//大地图
        /// <summary>
        /// 地图IMG
        /// </summary>
        private Image Map
        {
            get { return _Map; }
            set { _Map = value; }
        }
        private Image _MinMap;//小地图
        /// <summary>
        /// 鹰眼地图IMG
        /// </summary>
        private Image MinMap
        {
            get { return _MinMap; }
            set { _MinMap = value; }
        }

        private bool IsStationLeftMouseDown = false;
        private Image _StationImg;
        /// <summary>
        /// 分站IMG
        /// </summary>
        private Image StationImg
        {
            get { return _StationImg; }
            set { _StationImg = value; }
        }

        private Color _StationStrColor = Color.Blue;

        public Color StationStrColor
        {
            get { return _StationStrColor; }
            set { _StationStrColor = value; }
        }

        private Color _MoverStrColor = Color.Red;

        public Color MoverStrColor
        {
            get { return _MoverStrColor; }
            set { _MoverStrColor = value; }
        }

        private bool ShowAllStation = false;
        private int OldMapX;//记录移动前Map坐标
        private int OldMapY;
        private int OldZoomMapX;//用于放大的移动原始坐标
        private int OldZoomMapY;
        public int MapX = 0;//当前Map坐标
        public int MapY = 0;
        private int MouseDownX;//鼠标按下时坐标
        private int MouseDownY;
        private bool isMouseDown = false;//鼠标是否按下
        public int _MapWidth;//目前Map宽和高
        public int _MapHeight;
        public int OldMapWidth;//载入时Map宽高
        public int OldMapHeight;
        private int RectLeft;//矩形左边和顶端
        private int RectTop;
        private int MoveOrRect = 1;
        private Rectangle rect = new Rectangle();
        private List<MapInfo> MapList = new List<MapInfo>();//放大栈
        private List<Mover> MoverList = new List<Mover>();//移动图片组
        public List<Station> StationsList = new List<Station>();//基站组
        private List<string> StationsRecord = new List<string>();//Mover的分站校对信息
        public Hashtable StationHashTable = new Hashtable();//未配置位置的基站信息
        public List<RouteModel> RouteList = new List<RouteModel>();//路径链表
        private List<PointF> ExitsRoutePoint = new List<PointF>();//已存在的路径点
        private Hashtable StationsIDHash = new Hashtable();
        public List<StaticObject> StaticList = new List<StaticObject>();
        /// <summary>
        /// 图层链表
        /// </summary>
        private List<MapDivInfo> DivList = new List<MapDivInfo>();
        private List<string> NowDivNameList = new List<string>();
        public List<string> FilterDivList = new List<string>();

        private System.Windows.Forms.Timer MoveTimer;
        /// <summary>
        /// Mover的移动速度
        /// </summary>
        public static int Speed = 1;//移动速度
        //private string _stations;//基站信息
        private double zoomleft;//放大信息，参照局部放大
        private double zoomtop;
        private double zoomwidth;
        private int tkbValue = 0;
        private bool isMoving = false;//是否正在移动
        private double WidthHeightBili = 0.0;
        /// <summary>
        /// 当前是否正在播放历史轨迹
        /// </summary>
        public bool IsMoving
        {
            get { return isMoving; }
            set { isMoving = value; }
        }
        private bool isStationShowed = false;//是否已经显示Station
        private bool isSetting = false;//是否在配置状态
        private PointF routeFrom;//记录路径起始点\
        private int MoveZoomX;
        private float movezoomleft;
        private float movezoomtop;
        private float movezoomwidth;
        //private DrawThread thread;

        public delegate void MoveingEnd();
        /// <summary>
        /// 移动结束事件
        /// </summary>
        public event MoveingEnd MoveEnded;

        public delegate void ClickStation(Station EventStation);
        /// <summary>
        /// 分站点击事件
        /// </summary>
        public event ClickStation StationClick;

        public delegate void ClickStatic(StaticObject EventStaticObj);
        /// <summary>
        /// 静态图片点击事件
        /// </summary>
        public event ClickStatic StaticClick;


        /// <summary>
        /// 地图宽
        /// </summary>
        private int MapWidth
        {
            get { return _MapWidth; }
            set { _MapWidth = value; }
        }
        /// <summary>
        /// 地图高
        /// </summary>
        private int MapHeight
        {
            get { return _MapHeight; }
            set { _MapHeight = value; }
        }

        public static float MoverBili = 1;
        #endregion

        #region[初始化]
        public ZzhaMapGis()
        {
            InitializeComponent();
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            this.Cursor = Cursors.Hand;
            
        }
        #endregion

        #region[载入]
        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.MoveEnded += new MoveingEnd(ZzhaMapGis_MoveEnded);
            this.StationClick += new ClickStation(ZzhaMapGis_StationClick);
            this.StaticClick += new ClickStatic(ZzhaMapGis_StaticClick);

            LoadMap();
        }

        public void ReSet()
        {
            this.ClearAllStation();
            this.ClearAllStatic();
            this.ClareMover();
            this.DivList.Clear();
            this.FilterDivList.Clear();
            this.MapFilePath = null;
            this.PicMinBox.Image = null;
            this.MapX = 0;
            this.MapY = 0;
            this.FlashMap();
        }
        #endregion

        #region[动态图]
        /// <summary>
        /// 启用动态图刷新
        /// </summary>
        private void StartFlash()
        {
            GifTimer.Interval = 250;
            GifTimer.Tick += new EventHandler(t_Tick);
            GifTimer.Start();
        }
        /// <summary>
        /// 停止动态图刷新
        /// </summary>
        private void EndFlash()
        {
            GifTimer.Stop();
        }
        /// <summary>
        /// 动态图Timer函数
        /// </summary>
        void t_Tick(object sender, EventArgs e)
        {
            try
            {
                ImageAnimator.UpdateFrames();
                FlashMap();
            }
            catch (Exception ex)
            {
                GifTimer.Stop();
            }
        }
        #endregion

        #region[地图载入]
        private void LoadMap()
        {
            MapList.Clear();
            if (Map != null)
            {
                this.OldMapWidth = this.Map.Width;
                this.OldMapHeight = this.Map.Height;
                this.WidthHeightBili = (double)this.OldMapWidth / (double)this.OldMapHeight;
            }
            if (Map != null)
                this.MapWidth = this.Width;
            if (Map != null)
                this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
            this.PicMinBox.Image = MinMap;
            MapList.Clear();
            MapInfo m = new MapInfo(MapX, MapY, this.MapWidth, this.MapHeight);
            MapList.Add(m);
            zoomleft = this.Width / 10;
            zoomtop = this.Height / 10;
            zoomwidth = this.Width * 4 / 5;
            movezoomleft = (float)this.Width / (float)100;
            movezoomtop = (float)this.Height / (float)100;
            movezoomwidth = this.Width * 98 / 100;
        }

        #endregion

        #region[图形图像操作]
        public void FlashMap()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                this.ZzhaMapGis_Paint(this, new PaintEventArgs(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height)));
                g.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        public void ClearMap()
        {
            this.Map = null;
            this.MinMap = null;
            this.PicMinBox.Image = null;
            this.Refresh();
            this.PicMinBox.Refresh();
        }

        public void FlashAll()
        {
            this.FalshStatics();
            this.FalshStations();
            this.FlashMap();
            this.CheckDivRount();
        }
        /// <summary>
        /// 创建底图的Image实例
        /// </summary>
        /// <param name="filepath">底图图片路径</param>
        /// <returns>返回创建好的底图实例</returns>
        private Image CreateBitMap(string filepath)
        {
            try
            {
                Metafile bitmap = new Metafile(filepath);
                return bitmap;
            }
            catch (System.Exception ex)
            {
                Image image = NewBitMap(filepath);
                return image;
            }
        }

        private Image NewBitMap(string filepath)
        {
            Stream stream = new FileStream(filepath, FileMode.Open);
            byte[] buffer = new byte[Convert.ToInt32(stream.Length)];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            stream.Close();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            return Image.FromStream(ms);
        }

        /// <summary>
        /// 双缓冲画图，用于画map底图
        /// </summary>
        /// <param name="g">目标设备的Graphics</param>
        /// <param name="PicImg">底图的Image实例</param>
        /// <param name="left">底图左边线X坐标</param>
        /// <param name="top">底图上边线Y坐标</param>
        /// <param name="width">底图宽</param>
        /// <param name="height">底图的高</param>
        private void BufferedDrawImg(Graphics g, Image PicImg, int left, int top, float width, float height)
        {
            if (PicImg != null)
            {
                context = BufferedGraphicsManager.Current;
                context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
                bgraph = context.Allocate(g, new Rectangle(0, 0, this.Width + 1, this.Height + 1));
                bgraph.Graphics.Clear(this.BackColor);
                bgraph.Graphics.DrawImage(PicImg, left, top, width, height);
                bgraph.Graphics.DrawRectangle(Pens.Black, rect);
                PaintStation(bgraph.Graphics);
                PaintMover(bgraph.Graphics);
                PaintRoute(bgraph.Graphics);
                if (IsPaintRoute)
                {
                    PaintStation(bgraph.Graphics);
                    PaintMover(bgraph.Graphics);
                }
                PaintMoverRoute(bgraph.Graphics);

                //bgraph.Graphics.DrawImage(myimage, 200, 200, 50, 50);
                bgraph.Render();
                bgraph.Dispose();
            }
        }
        /// <summary>
        /// 画分站
        /// </summary>
        /// <param name="g">目标设备的Graphics</param>
        private void PaintStation(Graphics g)
        {
            if (this.UseDiv)
            {
                foreach (Station s in StationsList)
                {
                    if (HasSameDivName(NowDivNameList, s.DivName))
                    {
                        if (ShowStationOther)
                            g.DrawString(s.StationOther, Label.DefaultFont, new SolidBrush(StationStrColor), new PointF(s.StationNowPoint.X - 16, s.StationNowPoint.Y - 32));
                        g.DrawImage(s.StationImage, s.StationNowPoint.X - 16, s.StationNowPoint.Y - 16, 32, 32);

                        if (strPassTime != null && strStationName != null && strHeadName != null)
                        {
                            if (hashStation.ContainsKey(s.StationName.Trim()))
                            {
                                g.DrawString(s.StationName + "\n" +strHeadName+"\n"+hashStation[s.StationName.Trim()], Label.DefaultFont, new SolidBrush(StationStrColor), new PointF(s.StationNowPoint.X - 16, s.StationNowPoint.Y + 16));
                            }
                            else
                            {
                                g.DrawString(s.StationName, Label.DefaultFont, new SolidBrush(StationStrColor), new PointF(s.StationNowPoint.X - 16, s.StationNowPoint.Y + 16));
                            }
                        }
                        else
                        {
                            g.DrawString(s.StationName, Label.DefaultFont, new SolidBrush(StationStrColor), new PointF(s.StationNowPoint.X - 16, s.StationNowPoint.Y + 16));
                        }
                        s.HasShowed = true;
                    }
                    else
                    {
                        s.HasShowed = false;
                    }
                }
                foreach (StaticObject so in StaticList)
                {
                    if (HasSameDivName(NowDivNameList, so.DivName) || so.DivName == "all")
                    {
                        if (so.Type == StaticType.Image)
                            g.DrawImage(so.StaticImage, so.StaticNowPoint.X - so.StaticWidth / 2, so.StaticNowPoint.Y - so.StaticHeight / 2, so.StaticWidth, so.StaticHeight);
                        if (so.Type == StaticType.Word)
                            g.DrawString(so.StaticName, so.StaticFont, new SolidBrush(so.StaticColor), so.StaticNowPoint);
                        if (so.Type == StaticType.ImageAndWord)
                        {
                            g.DrawImage(so.StaticImage, so.StaticNowPoint.X - so.StaticWidth / 2, so.StaticNowPoint.Y - so.StaticHeight / 2, so.StaticWidth, so.StaticHeight);
                            g.DrawString(so.StaticName, so.StaticFont, new SolidBrush(so.StaticColor), new PointF(so.StaticNowPoint.X - so.StaticWidth / 2, so.StaticNowPoint.Y + so.StaticHeight / 2));
                        }
                    }
                }
            }
            else
            {
                if (this.MapWidth > (this.Width - 10) || isSetting || ShowAllStation)
                {
                    foreach (Station s in StationsList)
                    {
                        //if (ShowStationOther)
                        //    g.DrawString(s.StationOther, Label.DefaultFont, new SolidBrush(StationStrColor), new PointF(s.StationNowPoint.X - 16, s.StationNowPoint.Y - 20));
                        //g.DrawImage(s.StationImage, s.StationNowPoint.X - 16, s.StationNowPoint.Y - 10, 32, 20);
                        //g.DrawString(s.StationName, Label.DefaultFont, new SolidBrush(StationStrColor), new PointF(s.StationNowPoint.X - 16, s.StationNowPoint.Y + 10));
                        if (ShowStationOther)
                            g.DrawString(s.StationOther, Label.DefaultFont, new SolidBrush(StationStrColor), new PointF(s.StationNowPoint.X - 16, s.StationNowPoint.Y - 32));
                        g.DrawImage(s.StationImage, s.StationNowPoint.X - 16, s.StationNowPoint.Y - 16, 32, 32);
                        g.DrawString(s.StationName, Label.DefaultFont, new SolidBrush(StationStrColor), new PointF(s.StationNowPoint.X - 16, s.StationNowPoint.Y + 16));
                    }
                    this.isStationShowed = true;
                    foreach (StaticObject so in StaticList)
                    {
                        //g.DrawImage(so.StaticImage, so.StaticNowPoint.X - so.StaticWidth / 2, so.StaticNowPoint.Y - so.StaticHeight / 2, so.StaticWidth, so.StaticHeight);
                        if (so.Type == StaticType.Image)
                            g.DrawImage(so.StaticImage, so.StaticNowPoint.X - so.StaticWidth / 2, so.StaticNowPoint.Y - so.StaticHeight / 2, so.StaticWidth, so.StaticHeight);
                        if (so.Type == StaticType.Word)
                            g.DrawString(so.StaticName, so.StaticFont, new SolidBrush(so.StaticColor), so.StaticNowPoint);
                        if (so.Type == StaticType.ImageAndWord)
                        {
                            g.DrawImage(so.StaticImage, so.StaticNowPoint.X - so.StaticWidth / 2, so.StaticNowPoint.Y - so.StaticHeight / 2, so.StaticWidth, so.StaticHeight);
                            g.DrawString(so.StaticName, so.StaticFont, new SolidBrush(so.StaticColor), new PointF(so.StaticNowPoint.X - so.StaticWidth / 2, so.StaticNowPoint.Y + so.StaticHeight / 2));
                        }
                    }
                }
                else
                {
                    this.isStationShowed = false;
                }
            }


        }
        /// <summary>
        /// 画Mover
        /// </summary>
        /// <param name="g">目标设备的Graphics</param>
        private void PaintMover(Graphics g)
        {
            if (isMoving)
            {
                if (MoverList.Count > 0)
                {
                    foreach (Mover m in MoverList)
                    {
                        if (m.IsShow)
                        {
                            //ImgMover = Image.FromFile(m.NowFilePath);
                            //Czlt- 2010-10-14
                            if (isStartPoint)
                            {
                                StartPoint = new PointF(m.OldX,m.OldY);
                                isStartPoint = false;
                            }


                            g.DrawImage(m.MoverImage, m.MapPoint.X - 15, m.MapPoint.Y - 30, 30, 30);
                            if (this.MapWidth > (this.Width - 200))
                            {
                                g.DrawString(m.LabHead, Label.DefaultFont, new SolidBrush(MoverStrColor), new PointF(m.MapPoint.X - 15, m.MapPoint.Y - 30 - 10));
                                g.DrawString(m.LabFoot, Label.DefaultFont, new SolidBrush(MoverStrColor), new PointF(m.MapPoint.X - 15, m.MapPoint.Y - 30 + 30));
                            }
                        }
                    }
                }
            }
        }

        private Mover SelectedPaintMover = null;

        public void SetPaintMover(string id)
        {
            if (MoverList.Count > 0)
            {
                foreach (Mover m in MoverList)
                {
                    if (m.ID == id)
                    {
                        this.SelectedPaintMover = m;
                        return;
                    }
                }
                SelectedPaintMover = new Mover();
            }
        }

        private void PaintMoverRoute(Graphics g)
        {
            if (SelectedPaintMover != null)
            {
                if (isMoving)
                {
                    if (MoverList.Count > 0)
                    {
                        if (this.SelectedPaintMover.Route != null)
                        {
                            string[] routes = this.SelectedPaintMover.Route.Split('|');
                            PointF[] points = new PointF[routes.Length];
                            for (int i = 0; i < routes.Length; i++)
                            {
                                string[] xy = routes[i].Split(',');
                                float X1 = float.Parse(xy[0]);
                                float Y1 = float.Parse(xy[1]);
                                PointF p = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), new PointF(X1, Y1));
                                points[i] = PositionChanger.PositionChange(new Point(0, 0), new Point(MapX, MapY), p);
                            }
                            g.DrawLines(Pens.Red, points);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 画路径
        /// </summary>
        /// <param name="g">目标设备的Graphics</param>
        private void PaintRoute(Graphics g)
        {
            if (isSetting)
            {
                if (RouteList.Count > 0)
                {
                    foreach (RouteModel rm in RouteList)
                    {
                        PointF from = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), rm.From);
                        from = PositionChanger.PositionChange(new Point(0, 0), new Point(MapX, MapY), from);
                        PointF to = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), rm.To);
                        to = PositionChanger.PositionChange(new Point(0, 0), new Point(MapX, MapY), to);
                        g.FillEllipse(Brushes.Red, from.X - 6, from.Y - 6, 12, 12);
                        g.FillEllipse(Brushes.Red, to.X - 6, to.Y - 6, 12, 12);
                        g.DrawLine(Pens.Blue, from, to);
                    }
                }

                if (listPointDraw.Count > 0)
                {
                    PointF from = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), listPointDraw[0]);
                    from = PositionChanger.PositionChange(new Point(0, 0), new Point(MapX, MapY), from);
                    g.FillEllipse(Brushes.Blue, from.X - 6, from.Y - 6, 12, 12);
                }
            }
            else
            {               
                PaintRoutTen(g);
            }
        }

        /// <summary>
        /// 当前Map拖动坐标变换，用于画面重画
        /// </summary>
        /// <param name="changeX">需要改变的量值X</param>
        /// <param name="changeY">需要改变的量值Y</param>
        private void ChangeMapXY(int changeX, int changeY)
        {
            MapX = this.OldMapX + changeX;
            MapY = this.OldMapY + changeY;
            this.OldZoomMapX = this.OldMapX + changeX;
            this.OldZoomMapY = this.OldMapY + changeY;
        }
        /// <summary>
        /// 当前控件重画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZzhaMapGis_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.BufferedDrawImg(g, this.Map, MapX, MapY, this.MapWidth, this.MapHeight);
        }
        #endregion

        #region[鼠标事件  按下，移动及松开事件]
        private bool mouseflag = true;//鼠标标记  用于区分双击和单击
        private PointF MoveStationPoint;
        private PointF WantRemoveRPoint = PointF.Empty;//需要移除的路径点
        #region[鼠标按下事件]
        private void ZzhaMapGis_MouseDown(object sender, MouseEventArgs e)
        {
            this.tkbSize.Focus();
            if (!isSetting)
            {
                #region[非配置操作]
                if (e.Button == MouseButtons.Left)
                {
                    if (isStationShowed || UseDiv)
                    {
                        Station station = CompareStation(e.Location);
                        if (station != null)
                        {
                            StationClick(station);
                        }
                    }
                    if (MoveOrRect == 1)
                    {
                        this.MouseDownX = e.X;
                        this.MouseDownY = e.Y;
                        this.OldMapX = MapX;
                        this.OldMapY = MapY;
                        this.isMouseDown = true;
                    }
                    if (MoveOrRect == 2)
                    {
                        this.RectLeft = e.X;
                        this.RectTop = e.Y;
                    }
                    if (MoveOrRect == 3)
                    {
                        MoveZoomX = e.X;
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    StaticObject staticobj = CompareStaticObj(e.Location);
                    if (staticobj != null)
                    {
                        StaticClick(staticobj);
                    }
                }
                #endregion
            }
            else
            {
                #region[配置操作]
                if (e.Button == MouseButtons.Right)
                {
                    PointF p = ExitsRPoint(e.Location);
                    //Station station = CompareStation(e.Location);
                    //if (station != null)
                    //{
                    //    return;
                    //}
                    if (p != PointF.Empty)
                    {
                        PointF nowp = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), p);
                        nowp = PositionChanger.PositionChange(new Point(0, 0), new Point(MapX, MapY), nowp);
                        cms.Show(MousePosition);
                        WantRemoveRPoint = p;
                        return;
                    }
                    if (MoveOrRect == 1)
                    {
                        this.Cursor = Cursors.Hand;
                        this.MouseDownX = e.X;
                        this.MouseDownY = e.Y;
                        this.OldMapX = MapX;
                        this.OldMapY = MapY;
                        this.isMouseDown = true;
                    }
                    else
                    {
                        this.RectLeft = e.X;
                        this.RectTop = e.Y;
                        if (MoveOrRect == 3)
                        {
                            this.Cursor = Cursors.Hand;
                        }
                    }
                }
                if (e.Button == MouseButtons.Left)
                {


                    if (MoveOrRect == 1)
                    {
                        this.Cursor = Cursors.Hand;
                        this.MouseDownX = e.X;
                        this.MouseDownY = e.Y;
                        this.OldMapX = MapX;
                        this.OldMapY = MapY;
                        this.isMouseDown = true;
                    }
                    else
                    {
                        this.RectLeft = e.X;
                        this.RectTop = e.Y;
                        if (MoveOrRect == 3)
                        {
                            this.Cursor = Cursors.Hand;
                        }
                    }

                    Station station = CompareStation(e.Location);
                    if (station != null)
                    {

                        IsStationLeftMouseDown = true;
                        //mouseflag = true;
                        //return;
                    }




                }
                #endregion
            }
        }
        #endregion

        #region[鼠标移动事件]
        private void ZzhaMapGis_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (!isSetting)
                {
                    #region[非配置操作]
                    if (e.Button == MouseButtons.Left)
                    {
                        //#region[静态对象操作]
                        //StaticObject staticobj = CompareStaticObj(e.Location);
                        //if (staticobj != null)
                        //{
                        //    PointF p = PositionChanger.PositionChange(new Point(MapX, MapY), new Point(0, 0), e.Location);
                        //    p = PositionChanger.ZoomPositionChange(Convert.ToDouble(OldMapWidth) / Convert.ToDouble(MapWidth), p);
                        //    staticobj.StaticPoint = p;
                        //    FalshStatics();
                        //    FlashMap();
                        //    return;
                        //}
                        //#endregion
                        #region[底图操作]
                        if (MoveOrRect == 1)
                        {
                            if (isMouseDown)
                            {
                                this.ChangeMapXY(e.X - this.MouseDownX, e.Y - this.MouseDownY);
                                if (MoverList.Count > 0)
                                {
                                    foreach (Mover m in MoverList)
                                    {
                                        ShowMover(m);
                                    }
                                }
                                FalshStations();
                                FalshStatics();
                                FlashMap();
                            }
                        }
                        if (MoveOrRect == 2)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                if (Map == null)
                                    this.Refresh();
                                FlashMap();
                                rect = new Rectangle(RectLeft > e.X ? e.X : RectLeft, RectTop > e.Y ? e.Y : RectTop, (e.X - RectLeft) > 0 ? (e.X - RectLeft) : (RectLeft - e.X), (e.Y - RectTop) > 0 ? (e.Y - RectTop) : (RectTop - e.Y));
                                Graphics g = this.CreateGraphics();
                                g.DrawRectangle(Pens.Black, rect);
                            }
                        }
                        if (MoveOrRect == 3)
                        {
                            if (e.X > MoveZoomX)
                            {
                                if (this.MapWidth < this.MaxWidth)
                                {
                                    this.MapWidth = Convert.ToInt32(MapWidth * this.Width / movezoomwidth);
                                    this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                                    MapX = Convert.ToInt32(0 - (movezoomleft - 0 - MapX) * this.Width / movezoomwidth);
                                    MapY = Convert.ToInt32(0 - (movezoomtop - 0 - MapY) * this.Width / movezoomwidth);
                                    if (MoverList.Count > 0)
                                    {
                                        foreach (Mover m in MoverList)
                                        {
                                            this.ShowMover(m);
                                        }
                                    }
                                    FalshStations();
                                    FalshStatics();
                                    MoverBili = (float)OldMapWidth / (float)MapWidth;
                                    CheckDivRount();
                                    FlashMap();
                                }
                            }
                            if (e.X < MoveZoomX)
                            {
                                if (this.MapWidth > this.MinWidth)
                                {
                                    MapX = Convert.ToInt32(0 + MapX * this.movezoomwidth / Width + movezoomleft);
                                    MapY = Convert.ToInt32(0 + MapY * this.movezoomwidth / Width + movezoomtop);
                                    this.MapWidth = Convert.ToInt32(MapWidth * this.movezoomwidth / Width);
                                    this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                                    if (MoverList.Count > 0)
                                    {
                                        foreach (Mover m in MoverList)
                                        {
                                            this.ShowMover(m);
                                        }
                                    }
                                    FalshStations();
                                    FalshStatics();
                                    MoverBili = (float)OldMapWidth / (float)MapWidth;
                                    CheckDivRount();
                                    FlashMap();
                                }
                            }
                            MoveZoomX = e.X;
                        }
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region[配置操作]
                    #region[底图操作]
                    #region[其他个体操作]
                    //if (e.Button == MouseButtons.Right)
                    //{
                    //    Station station = CompareStation(e.Location);
                    //    if (station != null)
                    //    {

                    //        MoveStationPoint = station.StationPoint;
                    //        PointF p = PositionChanger.PositionChange(new Point(MapX, MapY), new Point(0, 0), e.Location);
                    //        p = PositionChanger.ZoomPositionChange(Convert.ToDouble(OldMapWidth) / Convert.ToDouble(MapWidth), p);
                    //        station.StationPoint = p;
                    //        ChangeConfigStation(station);
                    //        FalshStations();
                    //        FlashMap();
                    //        mouseflag = true;
                    //        IsStationChangeed = true;
                    //        return;
                    //    }
                    //}
                    Station station = CompareStation(e.Location);
                    if (station != null)
                    {
                        if (IsStationLeftMouseDown)
                        {
                            MoveStationPoint = station.StationPoint;
                            PointF p = PositionChanger.PositionChange(new Point(MapX, MapY), new Point(0, 0), e.Location);
                            p = PositionChanger.ZoomPositionChange(Convert.ToDouble(OldMapWidth) / Convert.ToDouble(MapWidth), p);
                            station.StationPoint = p;
                            ChangeConfigStation(station);
                            FalshStations();
                            FlashMap();
                            mouseflag = true;
                            IsStationChangeed = true;
                            return;
                        }
                    }

                    if (e.Button == MouseButtons.Left)
                    {
                        if (MoveOrRect == 1)
                        {
                            if (isMouseDown)
                            {
                                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                                {
                                    this.ChangeMapXY(e.X - this.MouseDownX, e.Y - this.MouseDownY);
                                    if (MoverList.Count > 0)
                                    {
                                        foreach (Mover m in MoverList)
                                        {
                                            ShowMover(m);
                                        }
                                    }
                                    FalshStations();
                                    FalshStatics();
                                    FlashMap();
                                }
                            }
                        }


                    }
                    #endregion
                    //if (MoveOrRect == 1)
                    //{
                    //    if (isMouseDown)
                    //    {
                    //        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    //        {
                    //            this.ChangeMapXY(e.X - this.MouseDownX, e.Y - this.MouseDownY);
                    //            if (MoverList.Count > 0)
                    //            {
                    //                foreach (Mover m in MoverList)
                    //                {
                    //                    ShowMover(m);
                    //                }
                    //            }
                    //            FalshStations();
                    //            FalshStatics();
                    //            FlashMap();
                    //        }
                    //    }
                    //}
                    if (MoveOrRect == 2)
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            if (Map == null)
                                this.Refresh();
                            FlashMap();
                            rect = new Rectangle(RectLeft > e.X ? e.X : RectLeft, RectTop > e.Y ? e.Y : RectTop, (e.X - RectLeft) > 0 ? (e.X - RectLeft) : (RectLeft - e.X), (e.Y - RectTop) > 0 ? (e.Y - RectTop) : (RectTop - e.Y));
                            Graphics g = this.CreateGraphics();
                            g.DrawRectangle(Pens.Black, rect);
                        }
                    }
                    if (MoveOrRect == 3)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            if (e.X > MoveZoomX)
                            {
                                if (this.MapWidth < this.MaxWidth)
                                {
                                    this.MapWidth = Convert.ToInt32(MapWidth * this.Width / movezoomwidth);
                                    this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                                    MapX = Convert.ToInt32(0 - (movezoomleft - 0 - MapX) * this.Width / movezoomwidth);
                                    MapY = Convert.ToInt32(0 - (movezoomtop - 0 - MapY) * this.Width / movezoomwidth);
                                    if (MoverList.Count > 0)
                                    {
                                        foreach (Mover m in MoverList)
                                        {
                                            this.ShowMover(m);
                                        }
                                    }
                                    FalshStations();
                                    FalshStatics();
                                    MoverBili = (float)OldMapWidth / (float)MapWidth;
                                    CheckDivRount();
                                    FlashMap();
                                }
                            }
                            if (e.X < MoveZoomX)
                            {
                                if (this.MapWidth > this.MinWidth)
                                {
                                    MapX = Convert.ToInt32(0 + MapX * this.movezoomwidth / Width + movezoomleft);
                                    MapY = Convert.ToInt32(0 + MapY * this.movezoomwidth / Width + movezoomtop);
                                    this.MapWidth = Convert.ToInt32(MapWidth * this.movezoomwidth / Width);
                                    this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                                    if (MoverList.Count > 0)
                                    {
                                        foreach (Mover m in MoverList)
                                        {
                                            this.ShowMover(m);
                                        }
                                    }
                                    FalshStations();
                                    FalshStatics();
                                    MoverBili = (float)OldMapWidth / (float)MapWidth;
                                    CheckDivRount();
                                    FlashMap();
                                }
                            }
                            MoveZoomX = e.X;
                        }
                    }
                    #endregion
                    #endregion
                }
            }
            catch (Exception ex)
            {
                //this.Refresh();
            }
        }
        #endregion

        #region[鼠标松开事件]
        private void ZzhaMapGis_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (!isSetting)
                {
                    #region[非配置操作]
                    if (e.Button == MouseButtons.Left)
                    {
                        if (MoveOrRect == 1)
                        {
                            this.isMouseDown = false;
                            //this.MouseUpX = e.X;
                            //this.MouseUpY = e.Y;
                            //foreach (Mover m in MoverList)
                            //{
                            //    m.LeftLenght =m.LeftLenght + e.X - MouseDownX;
                            //    m.TopLength =m.TopLength + e.Y - MouseDownY;
                            //}
                        }
                        if (MoveOrRect == 2)
                        {
                            rect = new Rectangle();
                            FlashMap();
                            int width = e.X - RectLeft;
                            int height = e.Y - RectTop;
                            if (Math.Abs(height) > Math.Abs(width) && width > 0)
                            {
                                //if (height > 0)
                                //{
                                height = Math.Abs(height);
                                if (this.MapWidth < MaxWidth)
                                {
                                    this.MapWidth = MapWidth * this.Height / height;
                                    this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                                    MapX = -((RectLeft < e.X ? RectLeft : e.X) - MapX) * this.Height / height + this.Width / 2 - width * this.Height / height / 2;
                                    MapY = -((RectTop < e.Y ? RectTop : e.Y) - MapY) * this.Height / height;
                                    MapInfo m = new MapInfo(MapX, MapY, MapWidth, MapHeight);
                                    if (MoverList.Count > 0)
                                    {
                                        foreach (Mover mover in MoverList)
                                        {
                                            this.MoveMover(mover);
                                        }
                                    }
                                    FalshStations();
                                    FalshStatics();
                                    CheckDivRount();
                                    FlashMap();
                                    this.MapList.Add(m);
                                }

                                //}
                                //else
                                //{
                                //    if (height < 0)
                                //    {
                                //        if (MapList.Count > 1)
                                //        {
                                //            this.MapList.RemoveAt(MapList.Count - 1);
                                //            MapInfo m = MapList[MapList.Count - 1];
                                //            MapX = m.MapLeft;
                                //            MapY = m.MapTop;
                                //            this.MapWidth = m.MapWidth;
                                //            this.MapHeight = m.MapHeight;
                                //            if (MoverList.Count > 0)
                                //            {
                                //                foreach (Mover mover in MoverList)
                                //                {
                                //                    this.MoveMover(mover);
                                //                }
                                //            }
                                //            FalshStations();
                                //            FalshStatics();
                                //            FlashMap();
                                //        }
                                //    }
                                //}
                            }
                            else
                            {
                                if (width > 0)
                                {
                                    if (this.MapWidth < MaxWidth)
                                    {
                                        this.MapWidth = MapWidth * this.Width / width;
                                        this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                                        MapX = -((RectLeft < e.X ? RectLeft : e.X) - MapX) * this.Width / width;
                                        MapY = -((RectTop < e.Y ? RectTop : e.Y) - MapY) * this.Width / width;
                                        //MapX = -(RectLeft - MapX) * this.Width / width;
                                        //MapY = -(RectTop - MapY) * this.Width / width;
                                        MapInfo m = new MapInfo(MapX, MapY, MapWidth, MapHeight);
                                        if (MoverList.Count > 0)
                                        {
                                            foreach (Mover mover in MoverList)
                                            {
                                                this.MoveMover(mover);
                                            }
                                        }
                                        FalshStations();
                                        FalshStatics();
                                        CheckDivRount();
                                        FlashMap();
                                        this.MapList.Add(m);
                                    }
                                }
                                else
                                {
                                    if (width < 0)
                                    {
                                        if (MapList.Count > 1)
                                        {
                                            this.MapList.RemoveAt(MapList.Count - 1);
                                            MapInfo m = MapList[MapList.Count - 1];
                                            MapX = m.MapLeft;
                                            MapY = m.MapTop;
                                            this.MapWidth = m.MapWidth;
                                            this.MapHeight = m.MapHeight;
                                            if (MoverList.Count > 0)
                                            {
                                                foreach (Mover mover in MoverList)
                                                {
                                                    this.MoveMover(mover);
                                                }
                                            }
                                            FalshStations();
                                            FalshStatics();
                                            CheckDivRount();
                                            FlashMap();
                                        }
                                    }
                                }
                            }
                        }

                    }
                    #endregion
                }
                else
                {
                    #region[配置操作]
                    if (e.Button == MouseButtons.Left)
                    {
                        if (MoveOrRect == 1)
                        {
                            this.IsStationLeftMouseDown = false;
                            this.Cursor = Cursors.Default;
                        }
                    }

                    if (e.Button == MouseButtons.Left)
                    {
                        if (MoveOrRect == 1)
                        {
                            this.isMouseDown = false;
                            this.Cursor = Cursors.Default;
                            //this.MouseUpX = e.X;
                            //this.MouseUpY = e.Y;
                            //foreach (Mover m in MoverList)
                            //{
                            //    m.LeftLenght =m.LeftLenght + e.X - MouseDownX;
                            //    m.TopLength =m.TopLength + e.Y - MouseDownY;
                            //}
                        }
                        if (MoveOrRect == 2)
                        {
                            rect = new Rectangle();
                            FlashMap();
                            int width = e.X - RectLeft;
                            int height = e.Y - RectTop;
                            if (Math.Abs(height) > Math.Abs(width) && width > 0)
                            {
                                //if (height > 0)
                                //{
                                height = Math.Abs(height);
                                if (this.MapWidth < MaxWidth)
                                {
                                    this.MapWidth = MapWidth * this.Height / height;
                                    this.MapHeight = MapHeight * this.Height / height;
                                    MapX = -((RectLeft < e.X ? RectLeft : e.X) - MapX) * this.Height / height + this.Width / 2 - width * this.Height / height / 2;
                                    MapY = -((RectTop < e.Y ? RectTop : e.Y) - MapY) * this.Height / height;
                                    MapInfo m = new MapInfo(MapX, MapY, MapWidth, MapHeight);
                                    if (MoverList.Count > 0)
                                    {
                                        foreach (Mover mover in MoverList)
                                        {
                                            this.MoveMover(mover);
                                        }
                                    }
                                    FalshStations();
                                    FalshStatics();
                                    FlashMap();
                                    this.MapList.Add(m);
                                }
                            }
                            else
                            {
                                if (width > 0)
                                {
                                    if (this.MapWidth < MaxWidth)
                                    {
                                        this.MapWidth = MapWidth * this.Width / width;
                                        this.MapHeight = MapHeight * this.Width / width;
                                        MapX = -((RectLeft < e.X ? RectLeft : e.X) - MapX) * this.Width / width;
                                        MapY = -((RectTop < e.Y ? RectTop : e.Y) - MapY) * this.Width / width;
                                        //MapX = -(RectLeft - MapX) * this.Width / width;
                                        //MapY = -(RectTop - MapY) * this.Width / width;
                                        MapInfo m = new MapInfo(MapX, MapY, MapWidth, MapHeight);
                                        if (MoverList.Count > 0)
                                        {
                                            foreach (Mover mover in MoverList)
                                            {
                                                this.MoveMover(mover);
                                            }
                                        }
                                        FalshStations();
                                        FalshStatics();
                                        FlashMap();
                                        this.MapList.Add(m);
                                    }
                                }
                                else
                                {
                                    if (width < 0)
                                    {
                                        if (MapList.Count > 1)
                                        {
                                            this.MapList.RemoveAt(MapList.Count - 1);
                                            MapInfo m = MapList[MapList.Count - 1];
                                            MapX = m.MapLeft;
                                            MapY = m.MapTop;
                                            this.MapWidth = m.MapWidth;
                                            this.MapHeight = m.MapHeight;
                                            if (MoverList.Count > 0)
                                            {
                                                foreach (Mover mover in MoverList)
                                                {
                                                    this.MoveMover(mover);
                                                }
                                            }
                                            FalshStations();
                                            FalshStatics();
                                            FlashMap();
                                        }
                                    }
                                }
                            }
                        }
                        if (MoveOrRect == 3)
                        {
                            this.Cursor = Cursors.Default;
                        }
                    }
                    #endregion
                }
                if (this.Map == null)
                    this.Refresh();
            }
            catch (Exception ex)
            {
                this.Refresh();
            }
        }
        #endregion
        #endregion

        #region[鼠标滚动放大缩小操作]
        /// <summary>
        /// 放大缩小事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tkbSize_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (tkbSize.Value > tkbValue)
                {
                    if (this.MapWidth < this.MaxWidth)
                    {
                        this.MapWidth = Convert.ToInt32(MapWidth * this.Width / zoomwidth);
                        this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                        MapX = Convert.ToInt32(0 - (zoomleft - 0 - MapX) * this.Width / zoomwidth);
                        MapY = Convert.ToInt32(0 - (zoomtop - 0 - MapY) * this.Width / zoomwidth);
                        if (MoverList.Count > 0)
                        {
                            foreach (Mover m in MoverList)
                            {
                                this.ShowMover(m);
                            }
                        }
                        FalshStations();
                        FalshStatics();
                        MoverBili = (float)OldMapWidth / (float)MapWidth;
                        CheckDivRount();
                        FlashMap();
                    }
                }
                else
                {
                    if (tkbValue == 0 && tkbSize.Value == 0)
                    {
                        if (this.MapWidth > this.MinWidth)
                        {
                            MapX = Convert.ToInt32(0 + MapX * this.zoomwidth / Width + zoomleft);
                            MapY = Convert.ToInt32(0 + MapY * this.zoomwidth / Width + zoomtop);
                            this.MapWidth = Convert.ToInt32(MapWidth * this.zoomwidth / Width);
                            //this.MapHeight = Convert.ToInt32(MapHeight * this.zoomwidth / Width);
                            this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                            if (MoverList.Count > 0)
                            {
                                foreach (Mover m in MoverList)
                                {
                                    this.ShowMover(m);
                                }
                            }
                            FalshStations();
                            FalshStatics();
                            MoverBili = (float)OldMapWidth / (float)MapWidth;
                            CheckDivRount();
                            FlashMap();
                        }
                    }
                    else
                    {
                        if (tkbValue == 10 && tkbSize.Value == 10)
                        {
                            if (this.MapWidth < this.MaxWidth)
                            {
                                this.MapWidth = Convert.ToInt32(MapWidth * this.Width / zoomwidth);
                                //this.MapHeight = Convert.ToInt32(MapHeight * this.Width / zoomwidth);
                                this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                                MapX = Convert.ToInt32(0 - (zoomleft - 0 - MapX) * this.Width / zoomwidth);
                                MapY = Convert.ToInt32(0 - (zoomtop - 0 - MapY) * this.Width / zoomwidth);
                                if (MoverList.Count > 0)
                                {
                                    foreach (Mover m in MoverList)
                                    {
                                        this.ShowMover(m);
                                    }
                                }
                                FalshStations();
                                FalshStatics();
                                MoverBili = (float)OldMapWidth / (float)MapWidth;
                                CheckDivRount();
                                FlashMap();
                            }
                        }
                        else
                        {
                            if (this.MapWidth > this.MinWidth)
                            {
                                MapX = Convert.ToInt32(0 + MapX * this.zoomwidth / Width + zoomleft);
                                MapY = Convert.ToInt32(0 + MapY * this.zoomwidth / Width + zoomtop);
                                this.MapWidth = Convert.ToInt32(MapWidth * this.zoomwidth / Width);
                                //this.MapHeight = Convert.ToInt32(MapHeight * this.zoomwidth / Width);
                                this.MapHeight = Convert.ToInt32((double)this.MapWidth / this.WidthHeightBili);
                                if (MoverList.Count > 0)
                                {
                                    foreach (Mover m in MoverList)
                                    {
                                        this.ShowMover(m);
                                    }
                                }
                                FalshStations();
                                FalshStatics();
                                MoverBili = (float)OldMapWidth / (float)MapWidth;
                                CheckDivRount();
                                FlashMap();
                            }
                        }
                    }
                }
                tkbValue = tkbSize.Value;
            }
            catch (Exception ex)
            {

            }
        }




        /// <summary>
        /// 控件大小发生变化事件，比例基准要跟随其变化
        /// </summary>
        private void ZzhaMapGis_Resize(object sender, EventArgs e)
        {
            zoomleft = this.Width / 10;
            zoomtop = this.Height / 10;
            zoomwidth = this.Width * 4 / 5;
            movezoomleft = (float)this.Width / (float)100;
            movezoomtop = (float)this.Height / (float)100;
            movezoomwidth = this.Width * 98 / 100;
        }
        #endregion

        #region[鹰眼操作]
        /// <summary>
        /// 单击鹰眼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicMinBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MapX = (0 - e.X) * this.MapWidth / 150 + this.Width / 2;
                MapY = (0 - e.Y) * this.MapHeight / 114 + this.Height / 2;
                this.OldZoomMapX = (0 - e.X) * this.OldMapWidth / 150 + this.Width / 2;
                this.OldZoomMapY = (0 - e.Y) * this.OldMapHeight / 114 + this.Height / 2;
                if (MoverList.Count > 0)
                {
                    foreach (Mover m in MoverList)
                    {
                        ShowMover(m);
                    }
                }
                FalshStations();
                FalshStatics();
                FlashMap();
            }
            else
            {
                RollBackRoute();
            }
        }
        /// <summary>
        /// 工具栏显示隐藏鹰眼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSee_Click(object sender, EventArgs e)
        {
            if (this.PicMinBox.Visible)
                this.PicMinBox.Visible = false;
            else
                this.PicMinBox.Visible = true;
        }
        /// <summary>
        /// 鼠标进入鹰眼范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicMinBox_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 鼠标移出鹰眼范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicMinBox_MouseLeave(object sender, EventArgs e)
        {
            if (MoveOrRect == 1)
                this.Cursor = Cursors.Hand;
        }
        #endregion

        #region[历史轨迹 Mover操作]
        /// <summary>
        /// 添加Mover信息
        /// </summary>
        /// <param name="route">路径点字符串，路径点之间用 | 隔开</param>
        /// <param name="datatime">出分站时间字符串，分隔符同路径点分隔符</param>
        /// <param name="stations">目的地字符串，分隔符同路径点分隔符</param>
        /// <param name="name">移动者姓名</param>
        /// <param name="zfilepath">正向移动图片</param>
        /// <param name="ffilepath">反向移动图片</param>
        public void AddMover(string route, string datatime, string stationname, string stationpoint, string name, string zfilepath, string ffilepath)
        {
            Mover m = new Mover();
            m.MoverCreate(route, datatime, stationname, stationpoint, name, zfilepath, ffilepath, this.StationsRecord);
            if (ImageAnimator.CanAnimate(m.MoverImage) && this.UseGif)
                ImageAnimator.Animate(m.MoverImage, null);
            this.MoverList.Add(m);
        }

        public void AddMover(string route, string datatime, string stationname, string stationpoint, string name, string zfilepath, string ffilepath, string id)
        {
            Mover m = new Mover();
            m.ID = id;
            m.MoverCreate(route, datatime, stationname, stationpoint, name, zfilepath, ffilepath, this.StationsRecord);
            if (ImageAnimator.CanAnimate(m.MoverImage) && this.UseGif)
                ImageAnimator.Animate(m.MoverImage, null);
            this.MoverList.Add(m);
            //SetHashPenColor(name);
        }

        /// <summary>
        /// 清除所有的Mover
        /// </summary>
        public void ClareMover()
        {
            MoverList.Clear();
            ////Czlt-2010-10-14-清空线路
            //ClearPainRoute();

        }     


        /// <summary>
        /// 在控件中显示Mover
        /// </summary>
        /// <param name="m">当前要显示的Mover实例</param>
        public void ShowMover(Mover m)
        {
            MoveMover(m);
        }

        /// <summary>
        /// 移动Mover
        /// </summary>
        /// <param name="m">当前要移动的Mover实例</param>
        public void MoveMover(Mover m)
        {
            //m.PicBox.Refresh();
            if (m.Step.IsRtoL)
            {
                if (m.NowFilePath != m.ZFilePath)
                {
                    ImageAnimator.StopAnimate(m.MoverImage, null);
                    m.MoverImage = Image.FromFile(m.ZFilePath);
                    m.NowFilePath = m.ZFilePath;
                    if (ImageAnimator.CanAnimate(m.MoverImage) && this.UseGif)
                        ImageAnimator.Animate(m.MoverImage, null);
                }
            }
            else
            {
                if (m.NowFilePath != m.FFilePath)
                {
                    ImageAnimator.StopAnimate(m.MoverImage, null);
                    m.MoverImage = Image.FromFile(m.FFilePath);
                    m.NowFilePath = m.FFilePath;
                    if (ImageAnimator.CanAnimate(m.MoverImage) && this.UseGif)
                        ImageAnimator.Animate(m.MoverImage, null);
                }
            }
            PointF p = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), new PointF(m.X, m.Y));
            p = PositionChanger.PositionChange(new PointF(0, 0), new PointF(MapX, MapY), p);
            m.MapPoint = p;
        }

        /// <summary>
        /// 开始历史轨迹播放
        /// </summary>
        public void StartMoving()
        {
            if (this.MoverList.Count > 0)
            {               
                isMoving = true;        
                StartMoveDatetime = DateTime.Now;
                MoveTimer = new System.Windows.Forms.Timer();
                this.MoveTimer.Interval = 200;
                this.MoveTimer.Tick += new EventHandler(MoveTimer_Tick);          
                ShowCount = 1;
                MoverBili = (float)OldMapWidth / (float)MapWidth;
                this.MoveTimer.Start();
            }
        }
        private bool ShowEndDialog = true;
        /// <summary>
        /// 开始实时轨迹播放
        /// </summary>
        public void StartRTMoving()
        {
            if (this.MoverList.Count > 0)
            {
               
                isMoving = true;
                ShowEndDialog = false;
                StartMoveDatetime = DateTime.Now;
                MoveTimer = new System.Windows.Forms.Timer();
                this.MoveTimer.Interval = 200;
                this.MoveTimer.Tick += new EventHandler(MoveTimer_Tick);
                ShowCount = 1;
                MoverBili = (float)OldMapWidth / (float)MapWidth;
                this.MoveTimer.Start();
            }
        }
        /// <summary>
        /// 停止轨迹播放
        /// </summary>
        public void StopMoving()
        {
            try
            {
                MoveTimer.Stop();
                this.ClareMover();
                //Czlt-2010-10-14-清空线路
                ClearPainRoute();
                this.IsPaintRoute = false;


                this.IsMoving = false;     
                FlashMap();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        private DateTime StartMoveDatetime;//起始时间，用于按顺序逐个播放历史轨迹
        private int ShowCount = 1;//已显示的轨迹个数
        /// <summary>
        /// Timer事件，历史轨迹播放
        /// </summary>
        void MoveTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ShowCount == 1)
                {
                    MoverList[ShowCount - 1].IsShow = true;
                }
                if (ShowCount < MoverList.Count)
                {
                    if (DateTime.Now.Ticks - StartMoveDatetime.Ticks > 30000000)
                    {
                        ShowCount++;
                        MoverList[ShowCount - 1].IsShow = true;
                        StartMoveDatetime = DateTime.Now;
                    }
                }
                bool flag = false;
                for (int i = 0; i < ShowCount; i++)
                {
                    if (MoverList[i].Move())
                    {
                        //Czlt-2010-10-13-坐标点
                        GetRoute(i);
                        MoveMover(MoverList[i]);
                        flag = true;
                    }
                }
                FlashMap();
                if (ShowEndDialog)
                {
                    if (!flag)
                    {
                        this.MoveTimer.Stop();
                        isMoving = false;
                        MoveEnded();
                    }
                }
                else
                {
                    if (!flag)
                    {
                        this.MoveTimer.Stop();
                        MoveEnded();
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                MoveTimer.Stop();
            }
        }
        /// <summary>
        /// 移动结束事件
        /// </summary>
        void ZzhaMapGis_MoveEnded()
        {
            if (ShowEndDialog)
            {
                if (MessageBox.Show("历史轨迹播放结束,是否重放？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Czlt-2010-10-14-清空线路                   
                    ClearPainRoute();
                    IsPaintRoute = false;
                    FlashMap();
                    foreach (Mover mover in MoverList)
                    {
                        mover.ReadyForReMove();
                    }
                    //Czlt-2010-16 去掉第一员工的时间
                    MoverList[0].StrPassTime = null;
                    MoverList[0].StrStationName = null;
                    this.ShowCount = 1;
                    StartMoving();
                }
                else
                {

                    this.ClareMover();
                    FlashMap();
                }
            }
        }
        #endregion

        #region[分站]
        /// <summary>
        /// 添加分站信息
        /// </summary>
        /// <param name="x">分站的X坐标</param>
        /// <param name="y">分站的Y坐标</param>
        /// <param name="name">分站的名称</param>
        /// <param name="id">分站的ID</param>
        /// <param name="state">分站状态</param>
        /// <param name="img">分站的图片</param>
        public void AddStation(float x, float y, string name, string id, string state, Image img)
        {
            //if (ImageAnimator.CanAnimate(img) && this.UseGif)
            //    ImageAnimator.Animate(img, null);
            Station s = new Station(x, y, name, id, state, img);
            this.StationsList.Add(s);
            if (!StationsRecord.Contains(x.ToString() + "," + y.ToString()))
            {
                this.StationsRecord.Add(x.ToString() + "," + y.ToString());
            }
            StationsIDHash.Add(s.StationID, s);
        }

        public void AddStation(float x, float y, string name, string id, string state, Image img, string divname)
        {
            //if (ImageAnimator.CanAnimate(img) && this.UseGif)
            //    ImageAnimator.Animate(img, null);
            Station s = new Station(x, y, name, id, state, img, divname);
            this.StationsList.Add(s);
            if (!StationsRecord.Contains(x.ToString() + "," + y.ToString()))
            {
                this.StationsRecord.Add(x.ToString() + "," + y.ToString());
            }
            StationsIDHash.Add(s.StationID, s);
        }
        /// <summary>
        /// 添加分站信息
        /// </summary>
        /// <param name="x">分站的X坐标</param>
        /// <param name="y">分站的Y坐标</param>
        /// <param name="name">分站的名称</param>
        /// <param name="id">分站的ID</param>
        /// <param name="state">分站状态</param>
        /// <param name="empnum">所监测到人员数量</param>
        /// <param name="img">分站的图片</param>

        public void AddStation(float x, float y, string name, string id, string state, string empnum, Image img)
        {
            //if (ImageAnimator.CanAnimate(img) && this.UseGif)
            //    ImageAnimator.Animate(img, null);
            Station s = new Station(x, y, name, id, state, empnum, img);
            this.StationsList.Add(s);
            if (!StationsRecord.Contains(x.ToString() + "," + y.ToString()))
            {
                this.StationsRecord.Add(x.ToString() + "," + y.ToString());
            }
            StationsIDHash.Add(s.StationID, s);
        }
        public void AddStation(float x, float y, string name, string id, string state, string empnum, string divname, Image img)
        {
            //if (ImageAnimator.CanAnimate(img) && this.UseGif)
            //    ImageAnimator.Animate(img, null);
            Station s = new Station(x, y, name, id, state, empnum, divname, img);
            this.StationsList.Add(s);
            if (!StationsRecord.Contains(x.ToString() + "," + y.ToString()))
            {
                this.StationsRecord.Add(x.ToString() + "," + y.ToString());
            }
            StationsIDHash.Add(s.StationID, s);
        }
        /// <summary>
        /// 添加分站信息
        /// </summary>
        /// <param name="x">分站的X坐标</param>
        /// <param name="y">分站的Y坐标</param>
        /// <param name="name">分站的名称</param>
        /// <param name="id">分站的ID</param>
        /// <param name="img">分站的图片</param>
        public void AddStation(float x, float y, string name, string id, Image img)
        {
            //if (ImageAnimator.CanAnimate(img) && this.UseGif)
            //    ImageAnimator.Animate(img, null);
            Station s = new Station(x, y, name, id, img);
            this.StationsList.Add(s);
            if (!StationsRecord.Contains(x.ToString() + "," + y.ToString()))
            {
                this.StationsRecord.Add(x.ToString() + "," + y.ToString());
            }
            StationsIDHash.Add(s.StationID, s);
        }
        /// <summary>
        /// 刷新分站
        /// </summary>
        public void FalshStations()
        {
            for (int i = 0; i < StationsList.Count; i++)
            {
                PointF p = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), StationsList[i].StationPoint);
                StationsList[i].StationNowPoint = PositionChanger.PositionChange(new Point(0, 0), new Point(MapX, MapY), p);
            }
        }
        /// <summary>
        /// 改变分站状态
        /// </summary>
        /// <param name="id">分站ID</param>
        /// <param name="state">分站状态</param>
        /// <param name="empnum">分站监测到人数</param>
        /// <param name="stationimage">分站状态对应图片</param>
        public void ChangeStationState(string id, string state, string empnum, Image stationimage)
        {
            Station s = (Station)StationsIDHash[id];
            if (s != null)
            {
                s.StationState = state;
                s.StationOther = empnum;
                ImageAnimator.StopAnimate(s.StationImage, null);
                s.StationImage = stationimage;
                if (ImageAnimator.CanAnimate(s.StationImage) && UseGif)
                    ImageAnimator.Animate(s.StationImage, null);
            }
        }

        /// <summary>
        /// 是否显示所有分站
        /// </summary>
        /// <param name="flag">是否标记  true为显示所有分站 false反之</param>
        public void IsShowAllStations(bool flag)
        {
            this.ShowAllStation = flag;
            FlashMap();
        }

        /// <summary>
        /// 对比分站坐标  用于单击分站事件
        /// </summary>
        /// <param name="p">当前坐标</param>
        /// <returns>如果分站坐标有重合则返回重合的分站坐标，无则返回当前坐标</returns>
        private Station CompareStation(Point p)
        {
            if (StationsList.Count > 0)
            {
                foreach (Station station in StationsList)
                {
                    if (p.X > station.StationNowPoint.X - 25 && p.X < station.StationNowPoint.X + 25 && p.Y > station.StationNowPoint.Y - 16 && p.Y < station.StationNowPoint.Y + 16)
                    {
                        return station;

                    }
                }
            }
            return null;
        }


        /// <summary>
        /// 单击分站事件
        /// </summary>
        /// <param name="EventStation">被单击的分站类实例</param>
        void ZzhaMapGis_StationClick(Station EventStation)
        {

            FalshStations();
            FlashMap();
        }

        /// <summary>
        /// 移除所有分站
        /// </summary>
        public void ClearAllStation()
        {
            this.StationsList.Clear();
            StationsIDHash = new Hashtable();
            FlashMap();
        }
        #endregion

        #region[静态图片]
        public void AddStaticObj(float pointx, float pointy, Image img, string filepath, string divname, StaticType type, Font staticfont, Color staticcolor)
        {
            if (ImageAnimator.CanAnimate(img) && this.UseGif)
                ImageAnimator.Animate(img, null);
            StaticObject sobj = new StaticObject(pointx, pointy, img, divname, filepath, type, staticfont, staticcolor);
            this.StaticList.Add(sobj);
            FalshStatics();
        }

        public void AddStaticObj(float pointx, float pointy, Image img, string divname, int width, int height, string filepath, string name, string key, StaticType type, Font staticfont, Color staticcolor)
        {
            if (ImageAnimator.CanAnimate(img) && this.UseGif)
                ImageAnimator.Animate(img, null);
            StaticObject sobj = new StaticObject(pointx, pointy, img, divname, filepath, width, height, name, key, type, staticfont, staticcolor);
            this.StaticList.Add(sobj);
            FalshStatics();
        }

        public void AddStaticObj(float pointx, float pointy, string name, string key, string divname, Font staticfont, Color staticcolor)
        {
            StaticObject sobj = new StaticObject(pointx, pointy, name, key, divname, StaticType.Word, staticfont, staticcolor);
            this.StaticList.Add(sobj);
            FalshStatics();
        }

        public void DelStaticObj(StaticObject so)
        {
            ImageAnimator.StopAnimate(so.StaticImage, null);
            StaticList.Remove(so);
            FalshStatics();
            FlashMap();
        }
        public void FalshStatics()
        {
            for (int i = 0; i < StaticList.Count; i++)
            {
                PointF p = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), StaticList[i].StaticPoint);
                StaticList[i].StaticNowPoint = PositionChanger.PositionChange(new Point(0, 0), new Point(MapX, MapY), p);
            }
        }
        public void ClearAllStatic()
        {
            foreach (StaticObject so in StaticList)
            {
                ImageAnimator.StopAnimate(so.StaticImage, null);
            }
            this.StaticList.Clear();
            FlashMap();
        }

        private StaticObject CompareStaticObj(Point p)
        {
            if (StaticList.Count > 0)
            {
                foreach (StaticObject so in StaticList)
                {
                    if (p.X > (so.StaticNowPoint.X - so.StaticWidth / 2) && p.X < (so.StaticNowPoint.X + so.StaticWidth / 2) && p.Y > (so.StaticNowPoint.Y - so.StaticHeight / 2) && p.Y < (so.StaticNowPoint.Y + so.StaticHeight / 2))
                    {
                        return so;
                    }
                }
            }
            return null;
        }
        void ZzhaMapGis_StaticClick(StaticObject EventStaticObj)
        {
            FalshStatics();
            FlashMap();
        }
        #endregion

        #region[图层]
        /// <summary>
        /// 添加图层信息
        /// </summary>
        /// <param name="divinfo">图层信息实体</param>
        public void AddDiv(MapDivInfo divinfo)
        {
            this.DivList.Add(divinfo);
        }

        /// <summary>
        /// 添加图层信息
        /// </summary>
        /// <param name="divname">图层名称</param>
        /// <param name="minwidth">图层显示最小值</param>
        /// <param name="maxwidth">图层显示最大值</param>
        public void AddDiv(string divname, int minwidth, int maxwidth)
        {
            MapDivInfo m = new MapDivInfo(divname, minwidth, maxwidth);
            DivList.Add(m);
        }

        public void DelAllDiv()
        {
            DivList.Clear();
        }

        private void CheckDivRount()
        {
            if (UseDiv && DivList.Count > 0)
            {
                if (this.MapWidth < this.MinWidth || this.MapWidth > this.MaxWidth)
                    return;
                NowDivNameList.Clear();
                foreach (MapDivInfo divinfo in DivList)
                {
                    if (this.MapWidth >= divinfo.DivMinWidth && MapWidth < divinfo.DivMaxWidth)
                    {
                        NowDivNameList.Add(divinfo.MapDivName);
                    }
                }
            }
        }

        private bool HasSameDivName(List<string> nowDivlist, string divnamestr)
        {
            string[] divnames = divnamestr.Split('|');
            for (int i = 0; i < divnames.Length; i++)
            {
                if (divnames[i] != "")
                {
                    if (nowDivlist.Contains(divnames[i]) && !FilterDivList.Contains(divnames[i]))
                        return true;
                }
            }
            return false;
        }
        #endregion

        #region[配置]
        /// <summary>
        /// 开始配置
        /// </summary>
        public void StartSetting()
        {
            if (!isSetting)
            {
                this.Cursor = Cursors.Default;
                this.isSetting = true;
                this.pnlItem.Visible = true;
                ImageList imagelist = new ImageList();
                imagelist.Images.Add(this.StationImg);
                imagelist.ImageSize = new Size(40, 40);
                this.lsvItems.LargeImageList = imagelist;
                foreach (DictionaryEntry de in this.StationHashTable)
                {
                    StationInfo sinfo = (StationInfo)de.Value;
                    ListViewItem item = new ListViewItem();
                    item.Text = sinfo.StationName;
                    item.ToolTipText = sinfo.StationID;
                    item.ImageIndex = 0;
                    item.Name = sinfo.StationName;
                    this.lsvItems.Items.Add(item);

                }
                if (lsvItems.Items.Count > 0)
                {
                    lsvItems.Items[0].ForeColor = Color.White;
                    this.lsvItems.Items[0].BackColor = Color.Blue;
                }

                StationlistView = lsvItems;

            }
        }
        /// <summary>
        /// 结束配置
        /// </summary>
        public void EndSetting()
        {
            if (isSetting)
            {
                this.isSetting = false;
                this.pnlItem.Visible = false;
            }
        }

        private void ChangeConfigStation(Station station)
        {
            ((StationInfo)StationHashTable[station.StationName]).StationPoint = station.StationPoint;
            foreach (RouteModel rm in RouteList)
            {
                if (rm.From == MoveStationPoint)
                {
                    rm.From = station.StationPoint;
                    rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));
                }
                if (rm.To == MoveStationPoint)
                {
                    rm.To = station.StationPoint;
                    rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));
                }
            }
            for (int i = 0; i < ExitsRoutePoint.Count; i++)
            {
                if (ExitsRoutePoint[i] == MoveStationPoint)
                {
                    ExitsRoutePoint[i] = station.StationPoint;
                    break;
                }
            }
        }

        /// <summary>
        /// 对比分站坐标和路径坐标  用于路径配置
        /// </summary>
        /// <param name="p">当前坐标</param>
        /// <returns>分站和路径点中如果有重合则返回分站点或路径点，无则返回当前坐标</returns>
        public PointF ComparePoint(Point p)
        {
            if (StationsList.Count > 0)
            {
                foreach (Station station in StationsList)
                {
                    if (p.X > station.StationNowPoint.X - 25 && p.X < station.StationNowPoint.X + 25 && p.Y > station.StationNowPoint.Y - 16 && p.Y < station.StationNowPoint.Y + 16)
                    {
                        return station.StationPoint;
                    }
                }
            }
            if (ExitsRoutePoint.Count > 0)
            {
                //添加路径点对比代码
                foreach (PointF pointf in ExitsRoutePoint)
                {
                    PointF nowp = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), pointf);
                    nowp = PositionChanger.PositionChange(new Point(0, 0), new Point(MapX, MapY), nowp);
                    int length = Convert.ToInt32(Math.Sqrt(Math.Pow(nowp.X - p.X, 2) + Math.Pow(nowp.Y - p.Y, 2)));
                    if (length <= 8)
                        return pointf;
                }
            }
            PointF pf = PositionChanger.PositionChange(new PointF(MapX, MapY), new Point(0, 0), p);
            pf = PositionChanger.ZoomPositionChange(Convert.ToDouble(OldMapWidth) / Convert.ToDouble(MapWidth), pf);
            return pf;
        }

        public PointF ExitsRPoint(Point p)
        {
            if (ExitsRoutePoint.Count > 0)
            {
                //添加路径点对比代码
                foreach (PointF pointf in ExitsRoutePoint)
                {
                    PointF nowp = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), pointf);
                    nowp = PositionChanger.PositionChange(new Point(0, 0), new Point(MapX, MapY), nowp);
                    int length = Convert.ToInt32(Math.Sqrt(Math.Pow(nowp.X - p.X, 2) + Math.Pow(nowp.Y - p.Y, 2)));
                    if (length <= 8)
                        return pointf;
                }
            }
            return PointF.Empty;
        }

        public void RemoveRPoint(PointF p)
        {
            if (ExitsRoutePoint.Count > 0)
            {
                //添加路径点对比代码
                if (ExitsRoutePoint.Contains(p))
                {
                    ExitsRoutePoint.Remove(p);
                    for (int i = (RouteList.Count - 1); i >= 0; i--)
                    {
                        if (RouteList[i].From == p || RouteList[i].To == p)
                            RouteList.RemoveAt(i);
                    }
                }
            }
        }

        private bool IsOut = false;//Panel是否已弹出

        private void picMoveLF_Click(object sender, EventArgs e)//panel弹出或缩进
        {
            if (!IsOut)
            {
                this.picMoveLF.Image = global::ZzhaControlLibrary.Properties.Resources.left;
                this.pnlItem.Left = this.pnlItem.Left + this.lsvItems.Width;
                IsOut = true;
            }
            else
            {
                this.picMoveLF.Image = global::ZzhaControlLibrary.Properties.Resources.right;
                this.pnlItem.Left = this.pnlItem.Left - this.lsvItems.Width;
                IsOut = false;
            }
        }



        private void ZzhaMapGis_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isSetting)
                {

                    int itemIndex = 0;
                    for (int i = 0; i < lsvItems.Items.Count; i++)
                    {
                        if (lsvItems.Items[i].BackColor == Color.Blue)
                        {
                            itemIndex = lsvItems.Items[i].Index;
                        }
                    }


                    if (this.lsvItems.Items.Count > 0)
                    {
                        PointF p = PositionChanger.PositionChange(new Point(MapX, MapY), new Point(0, 0), e.Location);
                        p = PositionChanger.ZoomPositionChange(Convert.ToDouble(OldMapWidth) / Convert.ToDouble(MapWidth), p);


                        string name = string.Empty;


                        name = lsvItems.Items[itemIndex].Text;

                        ((StationInfo)StationHashTable[name]).StationPoint = p;
                        this.lsvItems.Items.Remove(this.lsvItems.Items[itemIndex]);

                        StationlistView = lsvItems;

                        if (lsvItems.Items.Count > 0)
                        {
                            this.lsvItems.Items[0].ForeColor = Color.White;
                            this.lsvItems.Items[0].BackColor = Color.Blue;
                        }

                        this.AddStation(p.X, p.Y, ((StationInfo)StationHashTable[name]).StationName, ((StationInfo)StationHashTable[name]).StationID, "正常", StationImg);
                        FalshStations();
                        FlashMap();
                    }
                }
            }
        }

        public void AddConfigStation(string stationname, PointF p)
        {
            if (isSetting)
            {
                ((StationInfo)StationHashTable[stationname]).StationPoint = p;
                if (lsvItems.Items.ContainsKey(stationname))
                    this.lsvItems.Items.RemoveByKey(stationname);
                this.AddStation(p.X, p.Y, ((StationInfo)StationHashTable[stationname]).StationName, ((StationInfo)StationHashTable[stationname]).StationID, "正常", StationImg);
                FalshStations();
                FlashMap();
            }
        }

        public void AddConfigRouteModel(RouteModel rm)
        {
            this.RouteList.Add(rm);
            if (!ExitsRoutePoint.Contains(rm.From))
                ExitsRoutePoint.Add(rm.From);
            if (!ExitsRoutePoint.Contains(rm.To))
                ExitsRoutePoint.Add(rm.To);
        }

        public void ClareRouteModelList()
        {
            this.RouteList.Clear();
            this.ExitsRoutePoint.Clear();
        }

        /// <summary>
        /// 撤销所配置的路径
        /// </summary>
        public void RollBackRoute()
        {
            if (listPointDraw.Count < 1)
            {
                if (this.RouteList.Count > 0)
                {
                    this.RouteList.RemoveAt(RouteList.Count - 1);
                }
            }
            else
            {
                for (int i = 0; i < listPointDraw.Count; i++)
                {
                    listPointDraw.RemoveAt(0);
                }
            }

            FlashMap();
        }

        #endregion

        #region[工具栏点击]
        /// <summary>
        /// 单击拖动按钮
        /// </summary>
        private void tsbMove_Click(object sender, EventArgs e)
        {
            if (isSetting)
                this.Cursor = Cursors.Default;
            else
                this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveOrRect = 1;
        }
        /// <summary>
        /// 点击局部放大按钮
        /// </summary>
        private void tsbRect_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MoveOrRect = 2;
        }
        /// <summary>
        /// 点击还原按钮
        /// </summary>
        private void tsbRollBack_Click(object sender, EventArgs e)
        {
            MapInfo m = MapList[0];
            MapX = m.MapLeft;
            MapY = m.MapTop;
            this.MapWidth = m.MapWidth;
            this.MapHeight = m.MapHeight;
            if (MoverList.Count > 0)
            {
                foreach (Mover mover in MoverList)
                {
                    this.MoveMover(mover);
                }
            }
            FalshStations();
            FalshStatics();
            CheckDivRount();
            FlashMap();
            MapList.Clear();
            MapList.Add(m);
        }
        /// <summary>
        /// 点击拖动放大按钮
        /// </summary>
        private void tsbMoveZoom_Click(object sender, EventArgs e)
        {
            MoveOrRect = 3;
        }
        #endregion

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveRPoint(WantRemoveRPoint);
            WantRemoveRPoint = PointF.Empty;
            this.FlashAll();
        }

        private void lsvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            for (int i = 0; i < lsvItems.Items.Count; i++)
            {
                lsvItems.Items[i].ForeColor = Color.Black;
                lsvItems.Items[i].BackColor = Color.White;
            }

            e.Item.BackColor = Color.Blue;
            e.Item.ForeColor = Color.White;
        }

        private void lsvItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void lsvItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ZzhaMapGis_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsBeginDrawRoute)
            {
                if (IsEverStop)
                {
                    for (int i = 0; i < lpt.Count; i++)
                    {
                        lpt.RemoveAt(0);
                    }
                }
                if (this.lsvItems.Items.Count < 1)
                {
                    if (this.lsvItems.Items.Count < 1)
                    {
                        if (lpt.Count > 0)
                        {
                            RouteModel rm = new RouteModel();
                            rm.From = lpt[0];
                            PointF p = ComparePoint(e.Location);
                            rm.To = p;

                            rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));
                            this.RouteList.Add(rm);
                            if (!ExitsRoutePoint.Contains(rm.From))
                                ExitsRoutePoint.Add(rm.From);
                            if (!ExitsRoutePoint.Contains(rm.To))
                                ExitsRoutePoint.Add(rm.To);

                            FlashMap();
                            mouseflag = true;

                            for (int i = 0; i < lpt.Count; i++)
                            {
                                lpt.RemoveAt(0);
                            }

                            if (IsRouteLine)
                            {
                                return;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("分站位置尚未配置完成,请配置完成后再配置路径!", "提示", MessageBoxButtons.OK);
                    }

                    bool BFirst = false;
                    //添加配置代码
                    if (mouseflag)
                    {
                        if (!(this.lsvItems.Items.Count > 0))
                        {
                            PointF p = ComparePoint(e.Location);
                            lpt.Add(p);

                            listPointDraw = lpt;

                            FlashMap();
                            //routeFrom = p;
                            //mouseflag = false;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < lpt.Count; i++)
                {
                    lpt.RemoveAt(0);
                }
            }
        }


        #region 【Czlt-2010-10-13-路径点坐标】

        /// <summary>
        /// 获取坐标点
        /// </summary>
        /// <param name="i"></param>
        private void GetRoute(int i)
        {
            if (IsPaintRoute)
            {
                if (i == Index)
                {
                    //Czlt-向Hash表里添加分站名称和出分站时间
                    strPassTime = MoverList[i].StrPassTime;
                    strStationName = MoverList[i].StrStationName;
                    strHeadName = MoverList[i].LabHead;
                    if (strPassTime != null && strStationName != null)
                    {
                        if (hashStation.ContainsKey(strStationName.Trim()))
                        {
                            hashStation.Remove(strStationName.Trim());
                        }
                        hashStation.Add(strStationName.Trim(), strPassTime.Trim());

                    }
                }

                //Czlt-路线模块对象
                RouteModel rm = new RouteModel();
                switch (i)
                {
                    case 0:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList0.Clear();
                            }
                        }
                        rm.From = new PointF(MoverList[i].OldX, MoverList[i].OldY);
                        rm.To = new PointF(MoverList[i].X, MoverList[i].Y);
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));
                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.Blue;
                        }
                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);

                        CzltRouteList0.Add(rm);

                        break;
                    case 1:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList1.Clear();
                            }
                        }
                        rm.From = new PointF(MoverList[i].OldX + 4, MoverList[i].OldY + 4);
                        rm.To = new PointF(MoverList[i].X + 4, MoverList[i].Y + 4);
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));
                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.Yellow;
                        }
                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);

                        CzltRouteList1.Add(rm);

                        break;
                    case 2:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList2.Clear();
                            }
                        }

                        rm.From = new PointF(MoverList[i].OldX - 4, MoverList[i].OldY - 4);
                        rm.To = new PointF(MoverList[i].X - 4, MoverList[i].Y -4);
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));
                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.Green;
                        }

                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);
                        CzltRouteList2.Add(rm);

                        break;
                    case 3:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList3.Clear();
                            }
                        }
                        rm.From = new PointF(MoverList[i].OldX - 8, MoverList[i].OldY - 8);
                        rm.To = new PointF(MoverList[i].X - 8, MoverList[i].Y - 8);
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));
                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.Magenta;
                        }
                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);
                        CzltRouteList3.Add(rm);

                        break;
                    case 4:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList4.Clear();
                            }
                        }
                        rm.From = new PointF(MoverList[i].OldX + 8, MoverList[i].OldY + 8);
                        rm.To = new PointF(MoverList[i].X + 8, MoverList[i].Y + 8);
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));
                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.MediumSlateBlue;
                        }

                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);

                        CzltRouteList4.Add(rm);

                        break;
                    case 5:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList5.Clear();
                            }
                        }
                        rm.From = new PointF(MoverList[i].OldX + 8, MoverList[i].OldY + 8);
                        rm.To = new PointF(MoverList[i].X + 8, MoverList[i].Y + 8);
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));
                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.DodgerBlue;
                        }

                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);

                        CzltRouteList5.Add(rm);

                        break;
                    case 6:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList6.Clear();
                            }
                        }
                        rm.From = new PointF(MoverList[i].OldX - 8, MoverList[i].OldY - 8);
                        rm.To = new PointF(MoverList[i].X - 8, MoverList[i].Y - 8);
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));

                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.Indigo;
                        }

                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);

                        CzltRouteList6.Add(rm);

                        break;
                    case 7:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList7.Clear();
                            }
                        }
                        rm.From = new PointF(MoverList[i].OldX + 4, MoverList[i].OldY + 4);
                        rm.To = new PointF(MoverList[i].X + 4, MoverList[i].Y + 4);
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));

                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.YellowGreen;
                        }

                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);

                        CzltRouteList7.Add(rm);
                        break;
                    case 8:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList8.Clear();
                            }
                        }
                        rm.From = new PointF(MoverList[i].OldX - 4, MoverList[i].OldY - 4);
                        rm.To = new PointF(MoverList[i].X - 4, MoverList[i].Y - 4);
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));

                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.SaddleBrown;
                        }


                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);

                        CzltRouteList8.Add(rm);

                        break;
                    case 9:
                        if (StartPoint.X.Equals(MoverList[i].X) && StartPoint.Y.Equals(MoverList[i].Y))
                        {
                            if (MoverList[i].NowStationsIndex != MoverList[i].StationSum)
                            {
                                CzltRouteList9.Clear();
                            }
                        }
                        rm.From = new PointF(MoverList[i].OldX , MoverList[i].OldY );
                        rm.To = new PointF(MoverList[i].X , MoverList[i].Y );
                        rm.RouteLength = Convert.ToInt32(Math.Sqrt(Math.Pow(rm.From.X - rm.To.X, 2) + Math.Pow(rm.From.Y - rm.To.Y, 2)));

                        if (HashNameColor.ContainsKey(i))
                        {
                            rm.PenColor = (Color)HashNameColor[i];
                        }
                        else
                        {
                            rm.PenColor = Color.Navy;
                        }

                        if (!ExitsRoutePoint.Contains(rm.From))
                            ExitsRoutePoint.Add(rm.From);
                        if (!ExitsRoutePoint.Contains(rm.To))
                            ExitsRoutePoint.Add(rm.To);

                        CzltRouteList9.Add(rm);

                        break;
                    default:
                        break;
                }
            }


        }


        private void PaintRoutTen(Graphics g, RouteModel rm)
        {
            PointF from = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), rm.From);
            from = PositionChanger.PositionChange(new Point(1, 1), new Point(MapX + 1, MapY + 1), from);
            PointF to = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), rm.To);
            to = PositionChanger.PositionChange(new Point(1, 1), new Point(MapX + 1, MapY + 1), to);
            //g.FillEllipse(Brushes.Red, from.X - 6, from.Y - 6, 12, 12);
            //g.FillEllipse(Brushes.Red, to.X - 6, to.Y - 6, 12, 12);

            //g.DrawLine(rm.PenColor, from, to);
            g.DrawLine(new Pen(rm.PenColor, 3.0f), from, to);
        }

        /// <summary>
        /// 画轨迹
        /// </summary>
        /// <param name="g"></param>
        private void PaintRoutTen(Graphics g)
        {
            if (IsPaintRoute)
            {
                //Czlt-第1个人的轨迹
                if (CzltRouteList0.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList0)
                    {

                        //PointF from = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), rm.From);
                        //from = PositionChanger.PositionChange(new Point(1, 1), new Point(MapX + 1, MapY + 1), from);
                        //PointF to = PositionChanger.ZoomPositionChange(Convert.ToDouble(MapWidth) / Convert.ToDouble(OldMapWidth), rm.To);
                        //to = PositionChanger.PositionChange(new Point(1, 1), new Point(MapX + 1, MapY + 1), to);
                        ////g.FillEllipse(Brushes.Red, from.X - 6, from.Y - 6, 12, 12);
                        ////g.FillEllipse(Brushes.Red, to.X - 6, to.Y - 6, 12, 12);
                        //g.DrawLine(rm.PenColor, from, to);
                        PaintRoutTen(g, rm);
                    }
                }

                //Czlt-第2个人的轨迹
                if (CzltRouteList1.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList1)
                    {                   
                        PaintRoutTen(g, rm);
                    }
                }

                //Czlt-第3个人的轨迹
                if (CzltRouteList2.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList2)
                    {                       
                        PaintRoutTen(g, rm);
                    }
                }

                //Czlt-第4个人的轨迹
                if (CzltRouteList3.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList3)
                    {
                        PaintRoutTen(g, rm);
                    }
                }

                //Czlt-第5个人的轨迹
                if (CzltRouteList4.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList4)
                    {                        
                        PaintRoutTen(g, rm);
                    }
                }

                //Czlt-第6个人的轨迹
                if (CzltRouteList5.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList5)
                    {                       
                        PaintRoutTen(g, rm);
                    }
                }

                //Czlt-第7个人的轨迹
                if (CzltRouteList6.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList6)
                    {                      
                        PaintRoutTen(g, rm);
                    }
                }

                //Czlt-第8个人的轨迹
                if (CzltRouteList7.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList7)
                    {                      
                        PaintRoutTen(g, rm);
                    }
                }

                //Czlt-第9个人的轨迹
                if (CzltRouteList8.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList8)
                    {                        
                        PaintRoutTen(g, rm);
                    }
                }

                //Czlt-第10个人的轨迹
                if (CzltRouteList9.Count > 0)
                {
                    foreach (RouteModel rm in CzltRouteList9)
                    {                        
                        PaintRoutTen(g, rm);
                    }
                }

            }


        }

        /// <summary>
        /// 清空线路
        /// </summary>
        public void ClearPainRoute()
        {
            //Czlt-2010-10-14-停止并清除绘图轨迹
            if (IsPaintRoute)
            {
                ClearCzltRlist();
                //IsPaintRoute = false;                
                hashStation.Clear();
                strHeadName = null;
                strStationName = null;
                strPassTime = null;

            }
        }

        /// <summary>
        /// 删除历史轨迹
        /// </summary>
        private void ClearCzltRlist()
        {
            CzltRouteList0.Clear();
            CzltRouteList1.Clear();
            CzltRouteList2.Clear();
            CzltRouteList3.Clear();
            CzltRouteList4.Clear();
            CzltRouteList5.Clear();
            CzltRouteList6.Clear();
            CzltRouteList7.Clear();
            CzltRouteList8.Clear();
            CzltRouteList9.Clear();

        }

        //给哈希表赋值
        private void SetHashPenColor(string name)
        {
            if (IsPaintRoute)
            {

                string[] strName = name.Split(':');

                if (StrImpEmpName.Trim().Equals(strName[1].Trim()))
                {
                    index = (MoverList.Count - 1);
                }
                ///////添加序号和姓名
                ////hashNameIndex.Add((MoverList.Count - 1), strName[1]);

                //if (HashNameColor.Count > 0)
                //{
                //    if (HashNameColor.ContainsKey(strName[1]))
                //    {
                //        //hashPenColor.Add((MoverList.Count - 1), HashNameColor[strName[1]]);
                //    }
                //}

                
           
            }

        }
        #endregion

    }
}