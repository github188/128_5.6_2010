using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace KJ128WindowsLibrary
{
    /// <summary>
    /// LabelPanelStyle 样式
    /// </summary>
    public enum LabelPanelStyle
    {
        /// <summary>
        /// 单边线模式
        /// </summary>
        BorderMode,
        /// <summary>
        /// 渐变填充模式
        /// </summary>
        FillGradual,
        /// <summary>
        /// 阴影及图案模式
        /// </summary>
        FillHatchBrush
      
    }
    /// <summary>
    /// 写入文本的基面板 
    /// </summary>
    public partial class LabelPanel : UserControl
    {
        #region 私有变量

        #region 边框
        private int m_BorderLineWidth = 1;//线宽
        private Color m_BorderLineColor = Color.FromArgb(158, 182, 206);//边线颜色
        private bool m_IsBorderLine = true; //是否使用边框线
        private bool m_IsMouseHander = true;//具有鼠标默认事件
        #endregion
        
        #region 样式
        private LabelPanelStyle m_SetLabelPanelStyle = LabelPanelStyle.BorderMode;//样式
        
        
        #endregion
        #region 填充背景
        private bool m_IsFillBackGround = false; //是否填充背景色
        private Color m_FillGradualColor1 = Color.FromArgb(244, 248, 250);//Color1
        private Color m_FillGradualColor2 = Color.FromArgb(211, 220, 233);//color2

        private LinearGradientMode m_SetBackGroundGradineMode = LinearGradientMode.ForwardDiagonal;//GradineMode
       
        
        #endregion
        #region 阴影及图案模式
        private bool m_IsHatchBrush = false;//使用阴影及图案模式
        private Color m_HatchBackgroundColor = Color.FromArgb(200,200,200);
        private Color m_HatchForegroundColor = Color.FromArgb(255,255,255);
        private HatchStyle m_SetHatchStyle = HatchStyle.Percent40;
        

        
        #endregion

      
        #endregion
        #region 构造函数
        /// <summary>
        /// 函数
        /// </summary>
        public LabelPanel()
        {
            
            this.Paint += new PaintEventHandler(LabelPanel_Paint);
            this.MouseEnter += new System.EventHandler(LabelPanel_MouseEnter);
            this.MouseLeave += new System.EventHandler(LabelPanel_MouseLeave);

        }

        


   
        #endregion

        #region 属性
        /// <summary>
        /// 是否具有默认鼠标事情处理
        /// </summary>
        [Category("扩展的属性"), Description("是否具有默认鼠标事情处理")]
        public bool IsMouseHander
        {
            get
            {
                return m_IsMouseHander;
            }
            set
            {
                m_IsMouseHander = value;
            }

        }
        #region 外围边框 border
        /// <summary>
        /// 边框线宽
        /// </summary>
        public int BorderLineWidth
        {
            get
            {
                //26176644
                return m_BorderLineWidth;
            }
            set
            {
                m_BorderLineWidth = value;
            }

        }
        /// <summary>
        /// 边框线的颜色
        /// </summary>
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
        /// 有边框线吗
        /// </summary>
        /// <value>
        /// 有边框吗
        /// </value>
        public bool IsBorderLine
        {
            get
            {
                return m_IsBorderLine;
            }
            set
            {
                m_IsBorderLine = value;
                this.Refresh();
            }
        }
        #endregion
        #region 样式
        /// <summary>
        /// 设置样式 
        /// </summary>
        public LabelPanelStyle SetLabelPanelStyle
        {
            get
            {
                return m_SetLabelPanelStyle;
            }
            set
            {
                m_SetLabelPanelStyle = value;
                switch (m_SetLabelPanelStyle)
                {
                    case LabelPanelStyle.BorderMode:
                        {
                            m_IsBorderLine = true;
                            m_IsHatchBrush = false;
                            m_IsFillBackGround = false;
                            break;
                        }
                    case LabelPanelStyle.FillGradual:
                        {
                            m_IsHatchBrush = false;
                            m_IsFillBackGround = true;
                            break;
                        }
                    case LabelPanelStyle.FillHatchBrush:
                        {
                            m_IsFillBackGround = false;
                            m_IsHatchBrush = true;
                            break;
                        }
                }
                this.Refresh();
            }
        }
        #endregion
        #region 背景
        /// <summary>
        /// 是否填充背景
        /// </summary>
        public bool IsFillBackGround
        {
            get
            {
                return m_IsFillBackGround;
            }
            set
            {
                m_IsFillBackGround = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 背景渐变色1
        /// </summary>
        public Color FillGradualColor1
        {
            get
            {
                return m_FillGradualColor1;
            }
            set
            {
                m_FillGradualColor1 = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 背景渐变色2
        /// </summary>
        public Color FillGradualColor2
        {
            get
            {
                return m_FillGradualColor2;
            }
            set
            {
                m_FillGradualColor2 = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 背景渐变方式
        /// </summary>
        public LinearGradientMode SetBackGroundGradineMode
        {
            get
            {
                return m_SetBackGroundGradineMode;
            }
            set
            {
                m_SetBackGroundGradineMode = value;
                this.Refresh();
            }
        }
        #endregion
        
        #region 阴影和图案
        /// <summary>
        /// 是否使用阴影或图案
        /// </summary>
        public bool IsHatchBrush
        {
            get
            {
                return m_IsHatchBrush;
            }
            set
            {
                m_IsHatchBrush = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 阴影的背景
        /// </summary>
        public Color HatchBackgroundColor
        {
            get
            {
                return m_HatchBackgroundColor;
            }
            set
            {
                m_HatchBackgroundColor = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 前景色HatchBrush
        /// </summary>
        public Color HatchForegroundColor
        {
            get
            {
                return m_HatchForegroundColor;
            }
            set
            {
                m_HatchForegroundColor = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// HatchStyle
        /// </summary>
        public HatchStyle SetHatchStyle
        {
            get { return m_SetHatchStyle; }
            set 
            {
                m_SetHatchStyle = value;
                this.Refresh();
            
            }

        }
        #endregion
        #endregion
        #region 方法


        /// <summary>
        /// 绘制边线
        /// </summary>
        /// <param name="g"></param>
        void DrawBorder(Graphics g)
        {
            Rectangle rect = new Rectangle(0,0,this.Width-1,this.Height-1);
            g.DrawRectangle(new Pen(m_BorderLineColor, m_BorderLineWidth), rect);
        }
        /// <summary>
        /// 绘制填充的背景
        /// </summary>
        /// <param name="g"></param>
        void DrawFillBackGroundGradual(Graphics g)
        {
            Rectangle rect = new Rectangle(1, 1, this.Width  - 2, this.Height  - 2);
            if (rect.Height < 1 || rect.Height < 1)
            {
                return;
            }
            g.FillRectangle(new LinearGradientBrush(rect, m_FillGradualColor1,
                m_FillGradualColor2, m_SetBackGroundGradineMode), rect);
            
        }
        /// <summary>
        ///鼠标进入时的控件的行为，如果需要不一样的效果，可重写此方法
        /// </summary>
        protected virtual void MouseEnterHander()
        {
            if (m_IsMouseHander)
            {
                m_IsBorderLine = true;
                m_IsFillBackGround = false;
                this.BackColor = Color.FromArgb(184, 207, 233);
                this.m_BorderLineColor = Color.FromArgb(118, 153, 199);
                this.Refresh();
            }
        }
        /// <summary>
        /// 鼠标离开时的控件的行为,可重新此方法
        /// </summary>
        protected virtual void MouseLeaveHander()
        {
            if (m_IsMouseHander)
            {
                m_IsBorderLine = true;
                m_IsFillBackGround = true;
                m_BorderLineColor = Color.FromArgb(158, 182, 206);
                this.Refresh();
            }
        }
        /// <summary>
        /// 绘制阴影和图案
        /// </summary>
        /// <param name="g">画布</param>
        void DrawHatchBrush(Graphics g)
        {
            HatchBrush hatchBrush = new HatchBrush(m_SetHatchStyle, m_HatchForegroundColor, m_HatchBackgroundColor);
            Rectangle rect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
            if (rect.Height < 1 || rect.Height < 1)
            {
                return;
            }
            g.FillRectangle(hatchBrush, rect);
        }
  
        #endregion
        #region 事件处理
       /// <summary>
       /// 组件重绘
       /// </summary>
       /// <param name="sender">object</param>
       /// <param name="e">PaintEventArgs</param>
        void LabelPanel_Paint(object sender, PaintEventArgs e)
        {
            if (m_IsBorderLine)
            {
                DrawBorder(e.Graphics);
            }
            if (m_IsFillBackGround)
            {

                 DrawFillBackGroundGradual(e.Graphics);
            }
            if (m_IsHatchBrush)
            {
                DrawHatchBrush(e.Graphics);
            }
        }

        void LabelPanel_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterHander();
        }
        void LabelPanel_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveHander();
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LabelPanel
            // 
            this.Name = "LabelPanel";
            this.Size = new System.Drawing.Size(132, 91);
            this.ResumeLayout(false);

        }



    }
}
