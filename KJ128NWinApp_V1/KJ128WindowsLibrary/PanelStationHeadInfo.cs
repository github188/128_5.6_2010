using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
namespace KJ128WindowsLibrary
{
    /// <summary>
    /// 信息的样式
    /// </summary>
    public enum PanelStationHeadInfoStyle
    {
        /// <summary>
        /// 正常模式
        /// </summary>
        NormalMode,
        /// <summary>
        /// 鼠标移动过去的模式
        /// </summary>
        MouseMoveMode
    }
    /// <summary>
    /// 显示接收器号的信息的面板
    /// </summary>
    public class PanelStationHeadInfo:LabelPanel
    {

        #region 私有变量
             
        #region 显示的内容
        private LabelInfo m_FieldStationAddress = new LabelInfo("",new PointF(4, 8));
        private LabelInfo m_ValueStationAddress = new LabelInfo("", new PointF(75, 8));
        private LabelInfo m_FieldStationHeadAddress = new LabelInfo("读卡分站编号:",new PointF(4,25));
        private LabelInfo m_ValueStatinHeadAddress = new LabelInfo("1", new PointF(95,25));
        private LabelInfo m_ValueEnterTotalPerson = new LabelInfo("进入总人数", new PointF(4,65));
        private LabelInfo m_ValueStationHeadPlace = new LabelInfo("安装位置安装位置安装位置安装位置", new PointF(4, 42));
        private LabelInfo m_FieldAntennaA = new LabelInfo("");
        private LabelInfo m_ValueAntennaA = new LabelInfo("");
        private LabelInfo m_FieldAntennaB = new LabelInfo("");
        private LabelInfo m_ValueAntennaB = new LabelInfo("");
        /// <summary>
        /// 原始
        /// </summary>
        private string oldFA="1", oldFB="2";

        /// <summary>
        /// 原始天线A名称
        /// </summary>
        public string OldFB
        {
            get { return oldFB; }
            set { oldFB = value; }
        }

        /// <summary>
        /// 原始天线B名称
        /// </summary>
        public string OldFA
        {
            get { return oldFA; }
            set { oldFA = value; }
        }

        #endregion
        #region 样式
        //private PanelStationHeadInfoStyle m_PanelStationHeadInfoStyle = PanelStationHeadInfoStyle.NormalMode;
        #endregion
        #region 附加
        private string m_StationAddress = "";
        private string m_StationHeadAddress = "";
        #endregion


        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public PanelStationHeadInfo():base()
        {
           // base.Paint += new PaintEventHandler(PanelStationHeadInfo_Paint);
            this.SetLabelPanelStyle = LabelPanelStyle.FillGradual;
            this.Paint += new PaintEventHandler(PanelStationHeadInfo_Paint);
           // this.MouseEnter += new System.EventHandler(PanelStationHeadInfo_MouseEnter);
        }
        #endregion
        #region 属性 

        /// <summary>
        /// 分站地址
        /// </summary>
        [Category("显示内容"), Description("分站编号")]
        public string StationAddress
        {
            get { return this.m_StationAddress; }
            set
            {
                this.m_StationAddress = value;
               
            }
        }

        /// <summary>
        /// 接收器地址
        /// </summary>
        [Category("显示内容"), Description("接收器地址")]
        public string StationHeadAddress
        {
            get { return this.m_StationHeadAddress; }
            set
            {
                this.m_StationHeadAddress = value;
               
            }
        }

        #region 显示内容
        /// <summary>
        /// 接收器号的文本
        /// </summary>
        [Category("显示内容"), Description("接收器号的文本")]
        public LabelInfo FieldStationAddress
        {
            get { return this.m_FieldStationAddress; }
            set
            {
                this.m_FieldStationAddress = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 接收器号的文本
        /// </summary>
        [Category("显示内容"), Description("接收器号的文本")]
        public LabelInfo ValueStationAddress
        {
            get { return this.m_ValueStationAddress; }
            set
            {
                this.m_ValueStationAddress = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 接收器号的文本
        /// </summary>
        [Category("显示内容"),Description("接收器号的文本")]
        public LabelInfo FiledStationHeadAddress
        {
            get { return this.m_FieldStationHeadAddress; }
            set 
            { 
                 this.m_FieldStationHeadAddress = value;
                 this.Refresh();
            }
        }
        /// <summary>
        /// 接收器地址
        /// </summary>
        [Category("显示内容"), Description("接收器地址值")]
        public LabelInfo ValueStationHeadAddress
        {
            get { return m_ValueStatinHeadAddress; }
            set { m_ValueStatinHeadAddress = value; this.Refresh(); }
        }

        /// <summary>
        /// 进入总人数
        /// </summary>
        [Category("显示内容"), Description("进入总人数")]
        public LabelInfo ValueEnterTotalPerson
        {
            get { return m_ValueEnterTotalPerson; }
            set { m_ValueEnterTotalPerson = value; this.Refresh(); }
        }

        /// <summary>
        /// 接收器安装位置
        /// </summary>
        [Category("显示内容"), Description("接收器安装位置")]
        public LabelInfo ValueStationHeadPlace
        {
            get { return m_ValueStationHeadPlace; }
            set { m_ValueStationHeadPlace = value; this.Refresh();
            }
        }

        /// <summary>
        /// 天线A字段
        /// </summary>
        [Category("显示内容"), Description("天线A字段")]
        public LabelInfo FieldAntennaA
        {
            get { return m_FieldAntennaA; }
            set
            {
              this.oldFA = value.FieldName.ToString();
                m_FieldAntennaA =value; this.Refresh(); 
            }
        }

        /// <summary>
        /// 天线A的值
        /// </summary>
        [Category("显示内容"), Description("天线A的值")]
        public LabelInfo ValueAntennaA
        {
            get {return  m_ValueAntennaA; }
            set 
            {    
                m_ValueAntennaA = value; this.Refresh(); 
            }
        }

        /// <summary>
        /// 天线B字段
        /// </summary>
        [Category("显示内容"), Description("天线B字段")]
        public LabelInfo FieldAntennaB
        {
            get 
            {
                return m_FieldAntennaB; 
            }
            set 
            {
                this.oldFB = value.FieldName.ToString();
                m_FieldAntennaB = value;
            }
        }
        /// <summary>
        /// 天线B的值
        /// </summary>
        [Category("显示内容"), Description("天线B的值")]
        public LabelInfo ValueAntennaB
        {
            get { return m_ValueAntennaB; }
            set { m_ValueAntennaB = value; this.Refresh(); }
        }
        #endregion
        #endregion
        #region 方法
        void DrawString(Graphics g,LabelInfo lblInfo)
        {
            g.DrawString(lblInfo.FieldName,lblInfo.FieldFont,new SolidBrush(lblInfo.FieldColor),lblInfo.Location);
        }
        
        #endregion
        #region 事件
        void PanelStationHeadInfo_Paint(object sender, PaintEventArgs e)
        {
            DrawString(e.Graphics, m_FieldStationAddress);
            DrawString(e.Graphics, m_ValueStationAddress);
            DrawString(e.Graphics, m_FieldStationHeadAddress);
            DrawString(e.Graphics, m_ValueStatinHeadAddress);
            DrawString(e.Graphics, m_ValueStationHeadPlace);
            DrawString(e.Graphics, m_ValueEnterTotalPerson);
            if (m_FieldAntennaA.FieldName.IndexOf("...") == -1)
            m_FieldAntennaA.FieldName = GetDisPlayString(m_FieldAntennaA.FieldName);
            DrawString(e.Graphics, m_FieldAntennaA);
            DrawString(e.Graphics, m_ValueAntennaA);
            if (m_FieldAntennaB.FieldName.IndexOf("...") == -1)
            m_FieldAntennaB.FieldName = GetDisPlayString(m_FieldAntennaB.FieldName);
            DrawString(e.Graphics, m_FieldAntennaB);
            DrawString(e.Graphics, m_ValueAntennaB);
        }
        #endregion
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PanelStationHeadInfo
            // 
            this.Name = "PanelStationHeadInfo";
            this.Size = new System.Drawing.Size(150, 107);
            this.ResumeLayout(false);
            
        }

        #region [ 方法: 超过6个字符用…显示 ]

        private string GetDisPlayString(string str)
        {
            int _iCount = 8;
            System.Text.ASCIIEncoding n = new System.Text.ASCIIEncoding();
            byte[] b = n.GetBytes(str);
            int length = 0;                          // l 为字符串的实际长度
            int len = 0;
            bool _blDouble = true;
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63)             //判断是否为汉字或全脚符号
                {
                    length++;
                }
                else
                {
                   _blDouble = _blDouble ? false : true;
                }
                length++;
                len++;
                if (length >= _iCount)
                {
                    if (!_blDouble)
                    {
                        return str.Substring(0, len) + "...:";
                    }
                    else
                    {
                        return str.Substring(0, len) + "....:";
                    }
                }
            }
            return str;
        }

        #endregion

        #region [ 方法: 得到字符串长度 ]

        /// <summary>
        /// 得到字符串长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int GetLength(string str)
        {
            System.Text.ASCIIEncoding n = new System.Text.ASCIIEncoding();
            byte[] b = n.GetBytes(str);
            int length = 0;                          // l 为字符串的实际长度
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63)             //判断是否为汉字或全脚符号
                {
                    length++;
                }
                length++;
            }
            return length;
        }

        #endregion
    }
    /// <summary>
    /// 指定文本输入内容的结构
    /// </summary>
    public class LabelInfo
    {
        #region 私有变量
        private string m_FieldName = "FiledName";
        private Color m_FieldColor = Color.Black;
        private Font m_FieldFont = new Font("宋体", 9F,
            System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        private bool m_IsShowBackGround = false;
        private Color m_BackGroundColor = Color.White;
        private PointF m_Location = new PointF(19, 6);

        private Color m_MouseMoveColor = Color.FromArgb(184, 207, 233);
        
        #endregion

        #region 构造函数
        /// <summary>
        /// 文字信息基类
        /// </summary>
        public LabelInfo()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public LabelInfo(string fieldName)
        {
            m_FieldName = fieldName;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="location">控件左上角的坐标</param>
        public LabelInfo(string fieldName, PointF location)
        {
            m_FieldName = fieldName;
            m_Location = location;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="location">控件左上角的坐标</param>
        /// <param name="font">字体</param>
        public LabelInfo(string fieldName,PointF location,Font font)
        {
            m_FieldName = fieldName;
            m_Location = location;
            m_FieldFont = font;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="location">控件左上角的坐标</param>
        /// <param name="color">字体颜色</param>
        public LabelInfo(string fieldName, PointF location, Color color)
        {
            m_FieldName = fieldName;
            m_Location = location;
            m_FieldColor = color;
        }
     /// <summary>
        /// 构造函数
     /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="location">控件左上角的坐标</param>
        /// <param name="font">字体颜色</param>
     /// <param name="color"></param>
        public LabelInfo(string fieldName, PointF location,Font font, Color color)
        {
            m_FieldName = fieldName;
            m_Location = location;
            m_FieldFont = font;
            m_FieldColor = color;
        }
        #endregion
        #region 属性
        /// <summary>
        /// 鼠标移动上去的颜色
        /// </summary>
        [Category("显示的内容"), Description("鼠标移动上去的颜色")]
        public Color MouseMoveColor
        {
            get
            {
                return m_MouseMoveColor;
            }
            set
            {
                m_MouseMoveColor = value;
            }
        }
        /// <summary>
        /// 字段的名称
        /// </summary>
        [Category("显示的内容"), Description("字段的名字")]
        public string FieldName
        {
            get { return m_FieldName; }
            set { m_FieldName = value;}
        }
        /// <summary>
        /// 文字的颜色
        /// </summary>
        [Category("显示的内容"), Description("文字的颜色")]
        public Color FieldColor
        {
            get { return m_FieldColor; }
            set { m_FieldColor = value; }
        }
        /// <summary>
        /// 文字的字体
        /// </summary>
        [Category("显示的内容"), Description("文字的字体")]
        public Font FieldFont
        {
            get { return m_FieldFont; }
            set { m_FieldFont = value; }
        }
        /// <summary>
        /// 是否显示背景
        /// </summary>
        [Category("显示的内容"), Description("是否显示背景")]
        public bool IsShowBackGround
        {
            get { return m_IsShowBackGround; }
            set { m_IsShowBackGround = value; }
        }
        /// <summary>
        /// 背景的颜色
        /// </summary>
        [Category("显示的内容"), Description("背景的颜色")]
        public Color BackGroundColor
        {
            get { return m_BackGroundColor; }
            set { m_BackGroundColor = value; }
        }
        /// <summary>
        /// 控件的左上角的坐标
        /// </summary>
        [Category("显示的内容"), Description("控件的左上角的坐标")]
        public PointF Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }
        #endregion
        #region 方法
        /// <summary>
        /// tostring
        /// </summary>
        /// <returns>name</returns>
        public override string ToString()
        {
            return m_FieldName;
        }
        #endregion

    }
}