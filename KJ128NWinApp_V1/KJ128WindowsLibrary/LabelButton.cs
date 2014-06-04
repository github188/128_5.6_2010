using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace KJ128WindowsLibrary
{
    /// <summary>
    /// 鼠标状态
    /// </summary>
    public enum LabelButtonMouseState
    {
        /// <summary>
        /// 无鼠标处理事件
        /// </summary>
        NoMouseHandle,
        /// <summary>
        /// 鼠标进入
        /// </summary>
        MouseEnter,
        /// <summary>
        /// 鼠标离开
        /// </summary>
        MouseLeaver,
        /// <summary>
        /// 鼠标按下
        /// </summary>
        MouseDown
    }
    /// <summary>
   /// 使用标签制作的按钮
   /// </summary>
    public class LabelButton:Label
    {
        #region 私有变量
        private Color m_MouseEnterColor = Color.FromArgb(255, 231, 162);//当鼠标进入时的显示颜色
        private Color m_MouseEnterBorderColor = Color.FromArgb(255, 189, 105);//当鼠标进入时边框线的颜色
        private Color m_MouseDownColor = Color.FromArgb(255, 189, 105);//当鼠标按下去的颜色
        private Font  m_ControlFont= new System.Drawing.Font
             ("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));//字体

        private LabelButtonMouseState m_MouseState = LabelButtonMouseState.NoMouseHandle;
        
        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public LabelButton()
            : base()
        {
            
        }
        #endregion
        #region 方法
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            m_MouseState = LabelButtonMouseState.MouseEnter;
            DrawBorderLine(this.CreateGraphics());
            this.BackColor = m_MouseEnterColor;
            
            base.OnMouseEnter(e);
            this.Refresh();
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            m_MouseState = LabelButtonMouseState.MouseLeaver;
            base.OnMouseLeave(e);
        }
        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            m_MouseState = LabelButtonMouseState.MouseDown;
            this.BackColor = m_MouseDownColor;
            base.OnMouseDown(e);
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
          
            DrawBorderLine(e.Graphics);
            switch (m_MouseState)
            {
                case LabelButtonMouseState.MouseEnter:
                    {
                        DrawBorderLine(e.Graphics);
                        this.BackColor = m_MouseEnterColor;
                       
                        break;
                    }
                case LabelButtonMouseState.MouseDown:
                    {
                        this.BackColor = m_MouseDownColor;
                        
                        break;
                    }
            }
            base.OnPaint(e);
            
        }
        /// <summary>
        /// 绘制边框线
        /// </summary>
        /// <param name="g"></param>
        private void DrawBorderLine(Graphics g)
        {
            if (m_MouseState == LabelButtonMouseState.MouseEnter)
            {
                Rectangle rect = new Rectangle(0, 0, this.Bounds.Width - 1, this.Height - 1);
                g.DrawRectangle(new Pen(m_MouseEnterBorderColor), rect);
            }
        }
       
        
        #endregion

        #region 属性
        /// <summary>
        /// 鼠标状态
        /// </summary>
        [Category("扩展的属性"), Description("鼠标状态")]
        public LabelButtonMouseState MouseState
        {
            get
            {
                return m_MouseState;
            }
            set
            {
                m_MouseState = value;
            }
        }
        #endregion
    }
}
