using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
namespace KJ128WindowsLibrary
{
    /// <summary>
    /// 鼠标进入　按下　的按钮表面样式
    /// </summary>
    public enum ButtonCaptionPanelButtonStyle
    {
        /// <summary>
        /// windows样式
        /// </summary>
        WindowsStyle,
        /// <summary>
        /// office2003样式
        /// </summary>
        Office2003Style,
        /// <summary>
        /// 没有特殊效果
        /// </summary>
        None
    }

    /// <summary>
    /// 将CaptionPanel作为一个按钮使用
    /// </summary>
    public class ButtonCaptionPanel : CaptionPanel
    {
        
        #region 私有变量
        private CaptionPanelStyleEnum cpse_DefualStyle = CaptionPanelStyleEnum.windowsStyle; //默认样式
        //按钮样式
        private ButtonCaptionPanelButtonStyle m_ButtonStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;

        private CaptionPanelStyleEnum m_UnEnableStyle = CaptionPanelStyleEnum.UnEnableWindowsStyle;

        private bool m_IsMouseEnter = false;

        //private ButtonCaptionPanelButtonStyle m_NormalStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;
        //private ButtonCaptionPanelButtonStyle
        #endregion
        /// <summary>
        /// 将CaptionPanel作为一个按钮使用
        /// </summary>
        public ButtonCaptionPanel()
            : base()
        {
            this.IsUserButtonClose = false;//不使用关闭按钮
            this.IsOnlyCaption = true;
            this.IsPanelImage = true;
          
            this.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            this.Cursor = Cursors.Hand;

        }
        #region 方法
        /// <summary>
        /// 设置Office2007NoBorder
        /// </summary>
        protected override void SetOffice2007NoBorder()
        {
            base.SetOffice2007NoBorder();
            this.IsBorderLine = true;
            this.BorderLineColor = this.CaptionBackColor;
        }
        /// <summary>
        /// 设置BlueCaption样式，无背景
        /// </summary>
        protected override void SetBlueCaption()
        {
           base.SetBlueCaption();
           this.BorderLineColor = this.CaptionBackColor1;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            
            if (!this.Enabled)
            {
                if (!m_IsMouseEnter)
                {
                    cpse_DefualStyle = this.SetCaptionPanelStyle;
                }
                this.SetCaptionPanelStyle = UnEnableStyle;
            }
            else
            {
                this.SetCaptionPanelStyle = cpse_DefualStyle;
            }
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// 重新定义Office2003NoBorder样式
        /// </summary>
        protected override void SetOffice2003NoBorder()
        {
            base.SetOffice2003NoBorder();
            this.IsBorderLine = true;
            this.BorderLineColor = this.CaptionBackColor1;
        }
        /// <summary>
        /// 重新定义paleCaptionNoBorde样式
        /// </summary>
        protected override void SetpaleCaptionNoBorder()
        {
            base.SetpaleCaptionNoBorder();
            this.IsBorderLine = true;
            this.BorderLineColor = this.CaptionBackColor;
        }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            m_IsMouseEnter = true;
           cpse_DefualStyle = this.SetCaptionPanelStyle;
            switch(m_ButtonStyle)
           {
               case ButtonCaptionPanelButtonStyle.WindowsStyle:
                   {
                       this.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                       break;
                   }
               case ButtonCaptionPanelButtonStyle.Office2003Style:
                   {
                       this.SetCaptionPanelStyle = CaptionPanelStyleEnum.MouseEnterStyle;
                       break;
                   }
            }
            base.OnMouseEnter(e);
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.Enabled)
            {
                this.SetCaptionPanelStyle = cpse_DefualStyle;
            }
            m_IsMouseEnter = false;
            base.OnMouseLeave(e);
        }
        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            switch (m_ButtonStyle)
            {
                case ButtonCaptionPanelButtonStyle.WindowsStyle:
                    {
                        this.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
                        break;
                    }
                case ButtonCaptionPanelButtonStyle.Office2003Style:
                    {
                        this.SetCaptionPanelStyle = CaptionPanelStyleEnum.MouseDownStyle;
                        break;
                    }
            }
        }
        #endregion

        #region 属性
        /// <summary>
        /// 设置当鼠标进入　离开　按下　时的鼠标样式
        /// </summary>
        [Category("附加的内容"), Description("设置当鼠标进入　离开　按下　时的鼠标样式")]
        public ButtonCaptionPanelButtonStyle SetButtonStyle
        {
            get
            {
                return m_ButtonStyle;
            }
            set
            {
                m_ButtonStyle = value;
                switch (m_ButtonStyle)
                {
                    case ButtonCaptionPanelButtonStyle.None:
                        {
                            this.Cursor = Cursors.Default;
                            break;
                        }
                    case ButtonCaptionPanelButtonStyle.Office2003Style:
                        {
                            this.Cursor = Cursors.Hand;
                            break;
                        }
                    case ButtonCaptionPanelButtonStyle.WindowsStyle:
                        {
                            this.Cursor = Cursors.Hand;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 控件无效时显示的样式
        /// </summary>
        [Category("附加的内容"), Description("控件无效时显示的样式")]
        public CaptionPanelStyleEnum UnEnableStyle
        {
            get
            {
                return m_UnEnableStyle;
            }
            set
            {
                m_UnEnableStyle = value;
            }
        }
        #endregion
    }
}