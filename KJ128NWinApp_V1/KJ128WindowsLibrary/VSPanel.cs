using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using System.Drawing.Drawing2D;
namespace KJ128WindowsLibrary
{
    #region 样式
    /// <summary>
    /// 样式
    /// </summary>
    public enum VSPanelLayoutType
    {
        /// <summary>
        /// 自由定制
        /// </summary>
        FreeLayoutType,
        /// <summary>
        /// 水平
        /// </summary>
        VerticalType,
        /// <summary>
        ///垂直 
        /// </summary>
        HorizontalType
    }
    #endregion

    #region enum VsPaneBackGroundStyle
    /// <summary>
    /// 背景
    /// </summary>
    public enum VsPaneBackGroundStyle
    {
        /// <summary>
        /// office2007
        /// </summary>
        Office2007Panel,
        /// <summary>
        /// Office2007NoBackColor
        /// </summary>
        Office2007NoBackColor,
        /// <summary>
        /// BlueCaption
        /// </summary>
        BlueCaption,
        /// <summary>
        /// paleCaption
        /// </summary>
        paleCaption,
        /// <summary>
        /// windowsStyle
        /// </summary>
        windowsStyle,
        /// <summary>
        /// Office2003
        /// </summary>
        Office2003,
        /// <summary>
        /// 无背景样式
        /// </summary>
        NoBackstyle,
        /// <summary>
        /// 背景色比PaleCaption深
        /// </summary>
        DeepPaleCaption,
        /// <summary>
        /// 无样式
        /// </summary>
        None
    }
    #endregion
    /// <summary>
    /// 学习魏文元 自定义panel
    /// </summary>
    public class VSPanel:Panel
    {
        #region 私有变量fields
       
        /// <summary>
        /// 是否采用直接在窗体拖曳模式
        /// </summary>
        private bool m_IsDragModel = false; 
        #region 分隔控制　
        private VSPanelLayoutType m_LayoutType = VSPanelLayoutType.FreeLayoutType;
        private int m_VerticalInterval = 8;//水平间隔
        private int m_HorizontalInterval = 8;//垂直间隔

        private int m_LeftInterval = 0; //左边界
        private int m_RightInterval = 0;//右边界

        private int m_TopInterval = 0;
        private int m_BottomInterval = 0;

        private bool m_IsmiddleInterval = false;//是否启用中间分隔
        private int m_BetweenControlCount = 2;

        private int m_MiddleInterval = 80;

        #endregion
        #region 背景
        private bool m_IsCaptionSingleColor = true;//是否不启用渐变
        private Color m_LinearGradientColor1 = Color.FromArgb(244, 248, 250);
        private Color m_LinearGradientColor2 = Color.FromArgb(211, 220, 233);
       
        private LinearGradientMode m_BackLinearGradientMode = LinearGradientMode.ForwardDiagonal;
        #endregion
        #region 边框线
        /// <summary>
        /// 是否有边框线
        /// </summary>
        private bool m_IsBorderLine = false;

        private Color m_BorderLineColor = Color.FromArgb(118, 153, 199);
        

        #endregion
        #region 底部线
        private Color m_BottomLineColor = Color.FromArgb(197, 197, 197);
        private bool m_IsBottomLineColor = false;
        #endregion
        #region 样式
        private VsPaneBackGroundStyle m_BackGroundStyle = VsPaneBackGroundStyle.windowsStyle;
        #endregion
        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public VSPanel():base()
        {
            this.ControlAdded += new ControlEventHandler(VSPanel_ControlAdded);
            MouseWheel += VSPanel_MouseWheel;
            Scroll += new ScrollEventHandler(VSPanel_Scroll);
        }

        void VSPanel_Scroll(object sender, ScrollEventArgs e)
        {
            Focus();
        }

        

        void VSPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            Update();
        }
        #endregion
        #region 方法
        #region 样式设置
        /// <summary>
        /// 设置背景样式
        /// </summary>
        protected void SetVsPaneBackGroundStyle()
        {
            switch (m_BackGroundStyle)
            {
                case VsPaneBackGroundStyle.BlueCaption:
                    {
                        m_IsBorderLine = true;
                        m_LinearGradientColor1 = Color.FromArgb(38, 121, 191);
                        m_LinearGradientColor2 = Color.FromArgb(29, 97, 168);
                        m_IsBottomLineColor = false;
                        break;
                    }
                case VsPaneBackGroundStyle.Office2003:
                    {
                        m_IsBorderLine = true;
                        m_LinearGradientColor1 = Color.FromArgb(215, 232, 253);
                        m_LinearGradientColor2= Color.FromArgb(140, 176, 228);
                        m_IsBottomLineColor = false;
                        break;
                    }
                case VsPaneBackGroundStyle.windowsStyle:
                    {
                        m_IsBorderLine = true;
                        m_LinearGradientColor1 = Color.FromArgb(244, 248, 250);
                        m_LinearGradientColor2 = Color.FromArgb(211, 220, 233);
                        m_IsBottomLineColor = false;
                        break;
                    }
                case VsPaneBackGroundStyle.paleCaption:
                    {
                        m_IsBorderLine = true;
                        this.BackColor=Color.FromArgb(221, 231, 238);
                         m_IsBottomLineColor = true;
                       break;
                    }
                case VsPaneBackGroundStyle.DeepPaleCaption:
                    {
                        m_IsBorderLine = true;
                        this.BackColor = Color.FromArgb(184, 207, 233);
                        m_IsBottomLineColor = true;
                        break;
                    }
                case VsPaneBackGroundStyle.None:
                    {
                        m_IsBorderLine = true;
                        m_LinearGradientColor1 = Color.FromArgb(255, 255, 255);
                        m_LinearGradientColor2 = Color.FromArgb(255, 255, 255);
                        m_IsBottomLineColor = false;
                        break;
                    }
            }
        }
        #endregion

        #region 绘制 排列　放置
        #region 绘制底部线和边框线
        /// <summary>
        /// 绘制底部线
        /// </summary>
        /// <param name="g">画布</param>
        protected void DrawBottomLine(Graphics g)
        {
            if(m_IsBottomLineColor)
            {
                g.DrawLine(new Pen(m_BottomLineColor),0,Height-1,Width,Height-1);
            }
        }
        /// <summary>
        /// 绘制边框线
        /// </summary>
        /// <param name="g">Graphics</param>
        protected void DrawBorderLine(Graphics g)
        {
            if (m_IsBorderLine)
            {
                Rectangle rect = new Rectangle(0, 0, this.Bounds.Width - 1, this.Bounds.Height-1);

                g.DrawRectangle(new Pen(m_BorderLineColor), rect);
            }
        }
        #endregion
        #region 放置控件　包括水平　垂直　类型选择
        #region 水平
        /// <summary>
       /// 放置控件，根据第几个放置
       /// </summary>
       /// <param name="s">控件</param>
       /// <param name="controlIndex">控件的索引号，第几个控件</param>
        protected void VerticalLayout(Control s,int controlIndex)
        {
            int tem_Left = 0;
            int tem_ScrollRel = 0;//滚动条相对偏移量
            int int_preControl = 0;
            int int_temTop = 0;

           // tem_ScrollRel = (this.VerticalScroll.Value*this.Height)/
                           // (this.VerticalScroll.Maximum - this.VerticalScroll.Minimum);


            int_temTop = m_TopInterval;
            if(m_IsDragModel)//拖曳模式
            {
                
                if(controlIndex<this.Controls.Count-1)
                {
                    int_preControl = controlIndex + 1;
                    VerticalIntervalLayout(s,int_preControl);
                }
                else
                {
                    if (this.VerticalScroll.Value > 4)
                    {
                       
                    }
                    else
                    {
                        s.Left = m_LeftInterval;
                        s.Top = int_temTop;
                    }
                }
            }
            else//手动模式
            {
                
                if(controlIndex>=1)
                {
                    int_preControl = controlIndex - 1;
                    VerticalIntervalLayout(s,int_preControl);
                }
                else
                {
                    if (this.VerticalScroll.Value > 4)
                    {

                    }
                    else
                    {
                        s.Left = m_LeftInterval;
                        s.Top = int_temTop;
                    }
                }
            }
        }
       #region 水平分隔
       /// <summary>
       /// 水平分隔放置的控制
       /// </summary>
       /// <param name="s">当前的子控件</param>
       /// <param name="int_preControl">上一个子控件</param>
        protected void VerticalIntervalLayout(Control s,int int_preControl)
        {
            int tem_Left = 0;
            #region 关于中间分隔
            if (m_IsmiddleInterval)//存在中间分隔，那么
            {
                if ((int_preControl) % m_BetweenControlCount == 0)//能被整除
                {
                    tem_Left = (this.Controls[int_preControl].Left +
                         this.Controls[int_preControl].Width) + m_MiddleInterval;
                }
                else
                {
                    tem_Left = (this.Controls[int_preControl].Left +
                    this.Controls[int_preControl].Width) + m_VerticalInterval;
                }
            }
            else
            {
                tem_Left = (this.Controls[int_preControl].Left +
                    this.Controls[int_preControl].Width) + m_VerticalInterval;
            }
            #endregion
            #region 关于横向不足
            //如果横向不足以放一个
            if (this.Width - tem_Left - m_RightInterval > s.Width)
            {
                s.Left = tem_Left;
                s.Top = this.Controls[int_preControl].Top;
            }
            else
            {
                s.Left = m_LeftInterval;
                s.Top = Controls[int_preControl].Top + Controls[int_preControl].Height + m_HorizontalInterval;
            }
            #endregion
        }
        #endregion
        /// <summary>
        /// 水平放置
        /// </summary>
        /// <param name="s">外接控件</param>
        protected void VerticalLayout(Control s)
        {

            int tem_Left = 0;
            int int_ControlCount = this.Controls.Count;
            int int_preControl = int_ControlCount - 2;
            if (int_ControlCount > 1)
            {
                if (m_IsmiddleInterval)//存在中间分隔，那么
                {
                    if ((int_preControl) % m_BetweenControlCount == 0)//能被整除
                    {
                        tem_Left = (this.Controls[int_preControl].Left +
                             this.Controls[int_preControl].Width) + m_MiddleInterval;
                    }
                    else
                    {
                        tem_Left = (this.Controls[int_preControl].Left +
                       this.Controls[int_preControl].Width) + m_VerticalInterval;
                    }
                }
                else
                {
                    tem_Left = (this.Controls[int_preControl].Left +
                       this.Controls[int_preControl].Width) + m_VerticalInterval;
                }
                //如果横向不足以放一个
                if (this.Width - tem_Left - m_RightInterval > s.Width)
                {
                    s.Left = tem_Left;
                    s.Top = this.Controls[int_preControl].Top;
                }
                else
                {
                    s.Left = m_LeftInterval;
                    s.Top = Controls[int_preControl].Top + Controls[int_preControl].Height + m_HorizontalInterval;
                }
            }
            else
            {
                s.Left = m_LeftInterval;
                s.Top = m_TopInterval;
            }
        }
        #endregion
        #region 类型
        /// <summary>
        /// 放置类型的处理
        /// </summary>
        /// <param name="e">对象</param>
        protected virtual void LayoutTypeHander(ControlEventArgs e)
        {
            switch (m_LayoutType)
            {
                case VSPanelLayoutType.VerticalType:
                    {
                        VerticalLayout(e.Control);
                        break;
                    }
                case VSPanelLayoutType.HorizontalType:
                    {
                        HorizontalLayout(e.Control);
                        break;
                    }
                case VSPanelLayoutType.FreeLayoutType:
                    {
                        break;
                    }
            }
        }
        /// <summary>
        /// 放置类型的处理
        /// </summary>
        /// <param name="c">内部控件</param>
        /// <param name="controlIndex">index</param>
        protected virtual void LayoutTypeHander(Control c,int controlIndex)
        {
            switch (m_LayoutType)
            {
                case VSPanelLayoutType.VerticalType:
                    {
                        VerticalLayout(c,controlIndex);
                        break;
                    }
                case VSPanelLayoutType.HorizontalType:
                    {
                        HorizontalLayout(c,controlIndex);
                        break;
                    }
                case VSPanelLayoutType.FreeLayoutType:
                    {
                        break;
                    }
            }
        }
        #endregion
        #region 垂直
        /// <summary>
        /// 垂直放置
        /// </summary>
        /// <param name="s">外接控件</param>
       protected  void HorizontalLayout(Control s)
        {
            int tem_top = 0;
            int int_ControlCount = this.Controls.Count;
            int int_PreControl = int_ControlCount - 2;
            if (int_ControlCount > 1)
            {
                tem_top = this.Controls[int_PreControl].Top + this.Controls[int_PreControl].Height+m_HorizontalInterval;
                if (this.Height - tem_top - m_BottomInterval > s.Height)
                {
                    s.Top = tem_top;
                    s.Left = this.Controls[int_PreControl].Left;
                }
                else
                {
                    s.Top = m_TopInterval;
                    s.Left = this.Controls[int_PreControl].Left +this.Controls[int_PreControl].Width+ m_VerticalInterval;
                }
            }
            else
            {
                s.Top = m_TopInterval;
                s.Left = m_LeftInterval;
            }
        }
       /// <summary>
       /// 垂直放置控件，根据第几个控件放置
       /// </summary>
       /// <param name="s">控件</param>
       /// <param name="controlIndex">第几个控件</param>
        protected void HorizontalLayout(Control s,int controlIndex)
        {
           
            int int_PreControl = 0;//相对上一个控件的索引
            #region 分为窗口拖曳和代码生成两种放置方法 
            if (IsDragModel)
            {
                if(controlIndex<this.Controls.Count-1)
                {
                    int_PreControl = controlIndex + 1;
                    HorizontalIntervalLayout(s, int_PreControl);
                }
                else
                {
                    s.Top = m_TopInterval;
                    s.Left = m_LeftInterval;
                }
            }
            else
            {
                if(controlIndex>=1)
                {
                    int_PreControl = controlIndex-1;
                    HorizontalIntervalLayout(s,int_PreControl);
                }
                else
                {
                    s.Top = m_TopInterval;
                    s.Left = m_LeftInterval;
                }
            }
            #endregion
        }
        /// <summary>
        /// 垂直分隔
        /// </summary>
        /// <param name="s">当前子控件</param>
        /// <param name="int_PreControl">上一个控件的索引</param>
        private void HorizontalIntervalLayout(Control s,int int_PreControl)
        {
            int tem_top = 0;
            tem_top = this.Controls[int_PreControl].Top + this.Controls[int_PreControl].Height + m_HorizontalInterval;
            if (this.Height - tem_top - m_BottomInterval > s.Height)
            {
                s.Top = tem_top;
                s.Left = this.Controls[int_PreControl].Left;
            }
            else
            {
                s.Top = m_TopInterval;
                s.Left = this.Controls[int_PreControl].Left + this.Controls[int_PreControl].Width + m_VerticalInterval;
            }
        }
        #endregion
        #endregion
        #region 绘制背景
        /// <summary>
        /// 绘制背景
        /// </summary>
        protected void DrawBackGround(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.ClipRectangle;
            if (!m_IsCaptionSingleColor)
            {
                if (rect.Width<1 | rect.Height< 1)
                {
                }
                else
                {
                    g.FillRectangle(new LinearGradientBrush(rect, m_LinearGradientColor1, m_LinearGradientColor2,
                        m_BackLinearGradientMode), rect);
                }
            }
        }
        #endregion
        #region 重绘 引发OnPaint
        /// <summary>
        /// 重绘,触发重绘事件
        /// </summary>
        /// <param name="e">PaintEventArgs</param>
        protected override void OnPaint(PaintEventArgs e)
        {   DrawBackGround(e);
            DrawBorderLine(e.Graphics);
            DrawBottomLine(e.Graphics);
          
            base.OnPaint(e);


        }
        #endregion
        #region 重新排列所有组件
        /// <summary>
        /// 重新排列所有组件
        /// </summary>
        public virtual void RainRangeControl()
        {
            int controlIndex = 0;
            #region 重排分为窗体拖曳和手动代码添加控件
            if (m_IsDragModel)//窗体拖曳
            {
                for(int i=this.Controls.Count-1;i>=0;i--)
                {
                     LayoutTypeHander(this.Controls[i],i);
                }
            }
            else//代码添加控件
            {
                foreach (Control c in this.Controls)
                {
                    LayoutTypeHander(c, controlIndex);
                    controlIndex++;
                }
            }
            #endregion
        }
          
        #endregion
        #endregion``
        #region　OnScroll
        /// <summary>
        /// 引发Scroll事件
        /// </summary>
        /// <param name="se"></param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            
            this.Refresh();
        }
        #endregion
        #endregion
        #region 属性
        #region 边框线
        /// <summary>
        /// 边框线的颜色
        /// </summary>
        [Category("扩展的属性"), Description("边框线的颜色")]
        public Color BorderLineColor
        {
            get
            {
                return m_BorderLineColor;
            }
            set
            {
                m_BorderLineColor = value;
            }
        }
        /// <summary>
        /// 是否有边框线
        /// </summary>
        [Category("扩展的属性"), Description("是否有边框线")]
        public bool IsBorderLine
        {
            get
            {
                return m_IsBorderLine;
            }
            set
            {
                m_IsBorderLine = value;
            }
        }
        #endregion
        #region 中间分隔及渐变
        /// <summary>
        /// 中间间隔长度
        /// </summary>
        [Category("扩展的属性"), Description("中间间隔长度")]
        public int MiddleInterval
        {
            get
            {
                return m_MiddleInterval;
            }
            set
            {
                m_MiddleInterval = value;
            }
        }

        /// <summary>
        /// 中间分隔控件个数
        /// </summary>
        [Category("扩展的属性"), Description("中间分隔控件个数")]
        public int BetweenControlCount
        {
            get
            {
                return m_BetweenControlCount;
            }
            set
            {
                m_BetweenControlCount = value;
            }
        }
        /// <summary>
        /// 是否启用中间分隔
        /// </summary>
        [Category("扩展的属性"), Description("是否启用中间分隔")]

        public bool IsmiddleInterval
        {
            get
            {
                return m_IsmiddleInterval;
            }
            set
            {
                m_IsmiddleInterval = value;
            }
        }
        /// <summary>
        /// 背景线的样式
        /// </summary>
        public LinearGradientMode BackLinearGradientMode
        {
            get
            {
                return m_BackLinearGradientMode;
            }
            set
            {
                m_BackLinearGradientMode = value;
            }
        }
        /// <summary>
        /// 是否不启用渐变
        /// </summary>
        [Category("扩展的属性"), Description("是否不启用渐变")]
        public bool IsCaptionSingleColor
        {
            get
            {
                return m_IsCaptionSingleColor;
            }
            set
            {
                m_IsCaptionSingleColor = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 背景颜色1
        /// </summary>
        [Category("扩展的属性"), Description("背景颜色1")]

        public Color LinearGradientColor1
        {
            get
            {
                return m_LinearGradientColor1;
            }
            set
            {
                m_LinearGradientColor1 = value;
            }
        }
        /// <summary>
        /// 背景颜色2
        /// </summary>
        [Category("扩展的属性"), Description("背景颜色2")]
        public Color LinearGradientColor2
        {
            get
            {
                return m_LinearGradientColor2;
            }
            set
            {
                m_LinearGradientColor2 = value;
            }
        }
        /// <summary>
        /// 样式
        /// </summary>
        [Category("扩展的属性"), Description("选择用户样式")]
        public VSPanelLayoutType LayoutType
        {
            get
            {
                return m_LayoutType;
            }
            set
            {
                m_LayoutType = value;
            }
        }
        #endregion
        #region 边界及间距
        /// <summary>
        /// 水平间距
        /// </summary>
        [Category("扩展的属性"), Description("子控件之间的水平间距")]
        public int VerticalInterval
        {
            get
            {
                return m_VerticalInterval;
            }
            set
            {
                m_VerticalInterval = value;
            }
        }
        /// <summary>
        /// 垂直间距
        /// </summary>
        [Category("扩展的属性"), Description("子控件之间的垂直间距")]
        public int HorizontalInterval
        {
            get
            {
                return m_HorizontalInterval;
            }
            set
            {
                m_HorizontalInterval = value;
            }
        }
        /// <summary>
        /// 左间距
        /// </summary>
        [Category("扩展的属性"), Description("可绘制子控件的左边界")]
        public int LeftInterval
        {
            get
            {
                return m_LeftInterval;
            }
            set
            {
                m_LeftInterval = value;
            }
        }
        /// <summary>
        /// 右边界
        /// </summary>
        [Category("扩展的属性"), Description("可绘制子控件的右边界")]
        public int RightInterval
        {
            get
            {
                return m_RightInterval;
            }
            set
            {
                m_RightInterval = value;
            }
        }
        /// <summary>
        /// 顶边界
        /// </summary>
        [Category("扩展的属性"), Description("可绘制子控件的顶边界")]
        public int TopInterval
        {
            get
            {
                return m_TopInterval;
            }
            set
            {
                m_TopInterval = value;
            }
        }
        #endregion

        #region 样式设置
        /// <summary>
        /// 样式设置
        /// </summary>
        [Category("扩展的属性"), Description("样式设置")]
        public VsPaneBackGroundStyle SetBackGroundStyle
        {
            get
            {
                return m_BackGroundStyle;
            }
            set
            {
                m_BackGroundStyle = value;
                SetVsPaneBackGroundStyle();
                this.Refresh();
            }
        }
        #endregion
        #region 底部线
        /// <summary>
        /// 是否有底部线
        /// </summary>
        [Category("扩展的属性"), Description("是否有底部线")]
        public bool IsBottomLineColor
        {
            get
            {
                return m_IsBottomLineColor;
            }
            set
            {
                m_IsBottomLineColor = value;
            }
        }
        /// <summary>
        /// 底部线的颜色
        /// </summary>
        [Category("扩展的属性"), Description("底部线的颜色")]
        public Color BottomLineColor
        {
            get
            {
                return m_BottomLineColor;
            }
            set
            {
                m_BottomLineColor = value;
            }
        }
        #endregion
        #region 拖曳
        /// <summary>
        /// 是否采用直接在窗体拖曳模式
        /// </summary>
        [Category("扩展的属性"), Description("是否采用直接在窗体拖曳模式")]
        public bool IsDragModel
        {
            get
            {
                return m_IsDragModel;
            }
            set
            {
                m_IsDragModel = value;
            }
        }
        #endregion
        #endregion
        #region 事件处理
        void VSPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            LayoutTypeHander(e);
        }
        #endregion

    }
}//namespace

