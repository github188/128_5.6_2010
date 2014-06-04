using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace KJ128WindowsLibrary
{
    #region enum CaptionPanelStyleEnum
    /// <summary>
    /// 带标题的面板样式
    /// </summary>
    public enum CaptionPanelStyleEnum
    {
        /// <summary>
        /// Office2007NoBorder
        /// </summary>
        Office2007NoBorder,
        /// <summary>
        /// office2007
        /// </summary>
        Office2007Panel,
        /// <summary>
        /// paleCaptionNoBorder
        /// </summary>
        paleCaptionNoBorder,
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
        /// 鼠标进入样式
        /// </summary>
        MouseEnterStyle,
        /// <summary>
        /// 鼠标按下样式
        /// </summary>
        MouseDownStyle,
        /// <summary>
        /// 背景色比paleCaption深
        /// </summary>
        DeepPaleCaption,
        /// <summary>
        /// 没有边框线的Office2003样式
        /// </summary>
        Office2003NoBorder,
        /// <summary>
        ///  背景色比paleCaption深的无边框
        /// </summary>
        DeepPaleCaptionNoBorder,
        /// <summary>
        /// 按钮无效的样式
        /// </summary>
        ButtonUnenable,
        /// <summary>
        /// 没有样式
        /// </summary>
        None,
        /// <summary>
        /// 将windowsStyle样式设置为灰色
        /// </summary>
        UnEnableWindowsStyle
    }
    #endregion

    
    #region Class CaptionPanel
    /// <summary>
    /// 带标题的面板
    /// </summary>
    public partial class CaptionPanel : UserControl
    {
        #region 私有变量
         /// <summary>
         /// 内部参数
         /// </summary>
          private CaptionPanelParameter captionPanelParmeter = new CaptionPanelParameter();
          private CaptionPanelStyleEnum userCaptionStyle = CaptionPanelStyleEnum.Office2007Panel;
          private bool isCaptionCloseButtonEnter = false;
          private LinearGradientMode captionPanelLineMode = LinearGradientMode.Vertical;//线的渐变模式
          private bool m_IsOnlyCaption = false;//只有标题
          private bool m_IsUserSystemCloseButtonLeft = true;//使用系统默认的关闭按钮的左边界

          private Image m_ImageShow=null;
        /// <summary>
        /// 操作系统是否使用了视觉效果
        /// </summary>
        private bool m_EnableVisualStyle = System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsSupported;

        /// <summary>
        /// 单击关闭按钮
        /// </summary>
        public event EventHandler CloseButtonClick;
        #endregion
        #region 构造函数
        /// <summary>
        /// 标题面板
        /// </summary>
        public CaptionPanel()
        {
            
            InitializeComponent();
            this.Paint+=new PaintEventHandler(CaptionPanel_Paint);

            lblCloseControl.Paint += new PaintEventHandler(lblCloseControl_Paint);
           // InilblCloseButton();
        }

        /// <summary>
        /// 标题面板
        /// </summary>
        /// <param name="isBackcolor">启用背景颜色</param>
        public CaptionPanel(bool isBackcolor):this()
           
        {
           
            if (isBackcolor)
            {
                captionPanelParmeter.IsUserBackColor = true;
                            
            }
        }
        /// <summary>
        /// 标题面板
        /// 使用CaptionPanelStyleEnum，枚举，定义显示样式
        /// </summary>
        /// <param name="panelStyle">使用CaptionPanelStyleEnum，枚举，定义显示样式</param>
        public CaptionPanel(int panelStyle):this()
        {
            switch(panelStyle)
            {
                case (int)CaptionPanelStyleEnum.paleCaptionNoBorder:
                    {
                        break;
                    }
                case (int)CaptionPanelStyleEnum.Office2007Panel:
                    {
                        captionPanelParmeter.IsUserBackColor = true;
                       
                        break;
                    }
                case (int)CaptionPanelStyleEnum.BlueCaption:
                    {
                        SetBlueCaption();
                        break;
                    }
            }
        }
        #endregion
        #region 方法
        #region 绘制panel,title 方法
        #region 设置样式
        /// <summary>
        /// 设置Office2007NoBorder
        /// </summary>
        protected virtual void SetOffice2007NoBorder()
        {
            captionPanelParmeter.IsCaptionSingleColor = true;
            captionPanelParmeter.IsUserCaptionBottomLine = true;
            captionPanelParmeter.CaptionBackColor = Color.FromArgb(184, 207, 233);
            captionPanelParmeter.CaptionForeColor = Color.FromArgb(21, 47, 147);
            captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
            captionPanelParmeter.IsUserCaptionBottomLine = true;
            captionPanelParmeter.IsBorderLine = false;
        }
        /// <summary>
        ///背景色比paleCaption深
        /// </summary>
        void SetDeepPaleCaption()
        {
            captionPanelParmeter.IsCaptionSingleColor = true;
            captionPanelParmeter.CaptionBackColor = Color.FromArgb(184, 207, 233);
            captionPanelParmeter.CaptionForeColor = Color.FromArgb(21,74,147);
            captionPanelParmeter.IsUserCaptionBottomLine = true;
            captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
            captionPanelParmeter.IsBorderLine = true;
        }
        /// <summary>
        /// 背景色比paleCaption深的无边框
        /// </summary>
        void SetDeepPaleCaptionNoBorder()
        {
            captionPanelParmeter.IsCaptionSingleColor = true;
            captionPanelParmeter.CaptionBackColor = Color.FromArgb(184, 207, 233);
            captionPanelParmeter.CaptionForeColor = Color.FromArgb(21, 74, 147);
            captionPanelParmeter.IsUserCaptionBottomLine = true;
            captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
            captionPanelParmeter.IsBorderLine = false;
        }

        /// <summary>
        /// SetpaleCaptionNoBorder
        /// </summary>
       protected  virtual void SetpaleCaptionNoBorder()
        {
           
            captionPanelParmeter.IsCaptionSingleColor = true;
            captionPanelParmeter.CaptionBackColor = Color.FromArgb(221, 231, 238);
            captionPanelParmeter.CaptionForeColor = Color.FromArgb(62, 22, 110);
            captionPanelParmeter.IsUserCaptionBottomLine = false;
            captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
            captionPanelParmeter.IsBorderLine = false;
            
        }
        /// <summary>
        ///  鼠标进入时样式
        /// </summary>
        void SetMouseEnterStyle()
        {
            captionPanelParmeter.IsBorderLine = true;
            captionPanelParmeter.IsCaptionSingleColor = true;
            captionPanelParmeter.CaptionBackColor = Color.FromArgb(255, 231, 162);
            captionPanelParmeter.BorderLineColor = Color.FromArgb(255, 189, 105);
            captionPanelParmeter.CaptionForeColor = Color.Black;
            captionPanelParmeter.IsUserCaptionBottomLine = true;
            captionPanelParmeter.IsBorderLine = true;
        }

        void SetMouseDownStyle()
        {
            captionPanelParmeter.IsBorderLine = true;
            captionPanelParmeter.IsCaptionSingleColor = true;
            captionPanelParmeter.CaptionBackColor = Color.FromArgb(255, 189, 105);
            captionPanelParmeter.BorderLineColor = Color.FromArgb(255, 189, 105);
            captionPanelParmeter.CaptionForeColor = Color.Black;
            captionPanelParmeter.IsUserCaptionBottomLine = true;
            captionPanelParmeter.IsBorderLine = true;
        }
        /// <summary>
        /// 设置BlueCaption样式，无背景
        /// </summary>
     protected virtual void SetBlueCaption()
        {
           captionPanelParmeter.IsCaptionSingleColor = false;
        
               //captionPanelParmeter.CaptionBackColor1 = Color.FromArgb(38, 121, 191);
               //captionPanelParmeter.CaptionBackColor2 = Color.FromArgb(29, 97, 168);
               captionPanelParmeter.CaptionBackColor1 = Color.FromArgb(233, 241, 253);
               captionPanelParmeter.CaptionBackColor2 = Color.FromArgb(233, 241, 253);
               //captionPanelParmeter.CaptionForeColor = Color.FromArgb(255, 255, 255);
               captionPanelParmeter.CaptionForeColor = Color.FromArgb(0, 0, 0);
               captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
               
            captionPanelParmeter.IsUserCaptionBottomLine = true;
            captionPanelParmeter.IsBorderLine = true;
        
        }
        /// <summary>
        /// 设置Offices2003
        /// </summary>
         void SetOffice2003()
        {
            
            captionPanelParmeter.IsCaptionSingleColor = false;
            captionPanelParmeter.CaptionBackColor1 = Color.FromArgb(215,232,253);
            captionPanelParmeter.CaptionBackColor2 = Color.FromArgb(140,176,228);
            captionPanelParmeter.CaptionForeColor = Color.Black;
            captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
            captionPanelParmeter.IsUserCaptionBottomLine = false;
            captionPanelParmeter.IsBorderLine = false;
            
        }
      /// <summary>
        /// 设置SetOffice2003NoBorder
      /// </summary>
      protected virtual void SetOffice2003NoBorder()
        {
            captionPanelParmeter.IsCaptionSingleColor = false;
            captionPanelParmeter.CaptionBackColor1 = Color.FromArgb(215, 232, 253);
            captionPanelParmeter.CaptionBackColor2 = Color.FromArgb(140, 176, 228);
            captionPanelParmeter.CaptionForeColor = Color.Black;
            captionPanelParmeter.IsUserCaptionBottomLine = false;
            captionPanelParmeter.IsBorderLine = false;
           
        }
        /// <summary>
        /// 设置PaleCaption灰色样式
        /// </summary>
       void SetPaleCaption()
        {
            userCaptionStyle = CaptionPanelStyleEnum.paleCaption;
            captionPanelParmeter.IsCaptionSingleColor = true;
            captionPanelParmeter.CaptionBackColor = Color.FromArgb(221, 231, 238);
            captionPanelParmeter.CaptionForeColor = Color.FromArgb(62,22,110);
            captionPanelParmeter.IsUserCaptionBottomLine = true;
            captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
            captionPanelParmeter.IsBorderLine = true;
           
       
        }
        /// <summary>
        /// 设置SetOffice2007Panel
        /// </summary>
        void SetOffice2007Panel()
        {
            userCaptionStyle = CaptionPanelStyleEnum.Office2007Panel;
            captionPanelParmeter.IsCaptionSingleColor = true;
            captionPanelParmeter.IsUserCaptionBottomLine = false;
            captionPanelParmeter.CaptionBackColor = Color.FromArgb(184, 207, 233);
            captionPanelParmeter.CaptionForeColor = Color.FromArgb(21, 47, 147);
            captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
            captionPanelParmeter.IsUserCaptionBottomLine = false;
            captionPanelParmeter.IsBorderLine = true;
        }
        /// <summary>
        /// 设置为WindowsStyle
        /// </summary>
        void SetWindowsStyle()
        {
            captionPanelParmeter.IsCaptionSingleColor = false;//启用渐变
            captionPanelParmeter.IsUserCaptionBottomLine = false;//不使用底线
            captionPanelParmeter.CaptionBackColor1 = Color.FromArgb(244, 248, 250);
            captionPanelParmeter.CaptionBackColor2 = Color.FromArgb(211, 220, 233);
            captionPanelParmeter.CaptionForeColor = Color.FromArgb(0,0,0);
            captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
            captionPanelParmeter.IsUserCaptionBottomLine = false;
            captionPanelParmeter.IsBorderLine = true;
        }
        /// <summary>
        /// 设置为UnEnableWindowsStyle
        /// </summary>
        void SetUnEnableWindowsStyle()
        {
            captionPanelParmeter.IsCaptionSingleColor = false;//启用渐变
            captionPanelParmeter.IsUserCaptionBottomLine = false;//不使用底线
            captionPanelParmeter.CaptionBackColor1 = Color.FromArgb(251, 250, 247);
            captionPanelParmeter.CaptionBackColor2 = Color.FromArgb(211, 220, 233);
            captionPanelParmeter.CaptionForeColor = Color.FromArgb(192,192,192);
            captionPanelParmeter.BorderLineColor = Color.FromArgb(118, 153, 199);
            captionPanelParmeter.IsUserCaptionBottomLine = false;
            captionPanelParmeter.IsBorderLine = true;
        }
        /// <summary>
        /// 设置为按钮无效的样式
        /// </summary>
        void SetButtonUnenable()
        {
            captionPanelParmeter.IsBorderLine = true;
            captionPanelParmeter.IsCaptionSingleColor = false;//启用渐变
            captionPanelParmeter.IsUserCaptionBottomLine = true;//不使用底线
            captionPanelParmeter.CaptionBackColor1 = Color.FromArgb(251, 250, 247);
            captionPanelParmeter.CaptionBackColor2 = Color.FromArgb(192, 192, 168);
            captionPanelParmeter.CaptionForeColor = Color.FromArgb(192, 192, 168);
            captionPanelParmeter.BorderLineColor = Color.FromArgb(192, 192, 168);
        }

        #endregion
        #region lblCloseButton设置
      /// <summary>
      /// 初始化关闭按钮
      /// </summary>
        public void InilblCloseButton()
          {
            if (m_IsUserSystemCloseButtonLeft)
            {
                lblCloseControl.Left = this.Bounds.Width - captionPanelParmeter.CaptionCloseButtonEnterIntervalRight - lblCloseControl.Width;
            }
            else
            {
                lblCloseControl.Left = captionPanelParmeter.CaptionCloseButtonControlLeft;
                captionPanelParmeter.CaptionTitleLeft = captionPanelParmeter.CaptionCloseButtonControlLeft +
                   captionPanelParmeter.CaptionCloseButtonWidth + captionPanelParmeter.CaptionTitleLeftForPanelImage;
            }

            lblCloseControl.Top = captionPanelParmeter.CaptionTop;//captionPanelParmeter.CaptionCloseButtonBorderTop;
            lblCloseControl.Width = captionPanelParmeter.CaptionCloseButtonWidth;
          
            lblCloseControl.Font = captionPanelParmeter.CaptionCloseButtonFont;
            lblCloseControl.Height = captionPanelParmeter.CaptionHeight;
           
            DrawCloseButtonNormal(lblCloseControl.CreateGraphics());

            lblCloseControl.Text = "";
        }
        /// <summary>
        /// 绘制关闭按钮MouseEnter时的边框
        /// </summary>
        /// <param name="g"></param>
        void DrawCloseButtonBorderLine(Graphics g)
        {
            Rectangle rect = new Rectangle(captionPanelParmeter.CaptionCloseButtonBorderLeft,
                captionPanelParmeter.CaptionCloseButtonBorderTop, lblCloseControl.Bounds.Width - captionPanelParmeter.CaptionCloseButtonBorderLeft-1,
                captionPanelParmeter.CaptionHeight-1);
            Pen pen = new Pen(captionPanelParmeter.CaptionCloseButtonEnterBorderColor, captionPanelParmeter.CaptionCloseButtonEnterBorderWidth);
            g.DrawRectangle(pen,rect);
            g.DrawString(captionPanelParmeter.CaptionCloseButtonTitle, captionPanelParmeter.CaptionCloseButtonFont,
                           new SolidBrush(captionPanelParmeter.CaptionCloseButtonForeColor),
            captionPanelParmeter.CaptionCloseButtonTitleLeft, captionPanelParmeter.CaptionTitleTop);
            
        }
        /// <summary>
        /// 绘制关闭按钮在正常情况下的情况
        /// </summary>
        void DrawCloseButtonNormal(Graphics g)
        {
            Rectangle rect =new Rectangle(0,0,lblCloseControl.Bounds.Width,lblCloseControl.Bounds.Height);
       
            if (captionPanelParmeter.IsCaptionSingleColor)
            {
                lblCloseControl.BackColor = captionPanelParmeter.CaptionBackColor;
            }
            else
            {
                LinearGradientBrush lgb = new LinearGradientBrush(rect,
                    captionPanelParmeter.CaptionBackColor1, captionPanelParmeter.CaptionBackColor2,
                    captionPanelLineMode);
                g.FillRectangle(lgb, rect);                
            }
            g.DrawString(captionPanelParmeter.CaptionCloseButtonTitle, captionPanelParmeter.CaptionCloseButtonFont,
                   new SolidBrush(captionPanelParmeter.CaptionForeColor),
               captionPanelParmeter.CaptionCloseButtonTitleLeft, captionPanelParmeter.CaptionTitleTop);
        }
#endregion
        #region 绘制标题
        /// <summary>
        /// 绘制边框线
        /// </summary>
        void DrawBorderLine(Graphics g)
        {
            Rectangle rect=new Rectangle(captionPanelParmeter.BorderLineLeft,
                captionPanelParmeter.BorderLineTop,this.Bounds.Width-captionPanelParmeter.BorderLineLeft-1,
                this.Bounds.Height -captionPanelParmeter.BorderLineTop-1);
            g.DrawRectangle(new Pen(captionPanelParmeter.BorderLineColor, captionPanelParmeter.BorderLineWidth), rect);
        }
        /// <summary>
        /// 绘制标题
        /// </summary>
        /// <param name="g"></param>
        void DrawCaption(Graphics g)
        {
            Rectangle rect = new Rectangle(captionPanelParmeter.CaptionLeft, 
                     captionPanelParmeter.CaptionTop, 
                     this.Bounds.Width - captionPanelParmeter.CaptionLeft-1, 
                     captionPanelParmeter.CaptionHeight);
            if (rect.Width < 1 || rect.Height < 1)
            {
                return;
            }
            if (captionPanelParmeter.IsCaptionSingleColor)
            {
                SolidBrush sb = new SolidBrush(captionPanelParmeter.CaptionBackColor);
                g.FillRectangle(sb, rect);
            }
            else
            {
                LinearGradientBrush lgb = new LinearGradientBrush(rect,
                    captionPanelParmeter.CaptionBackColor1, captionPanelParmeter.CaptionBackColor2,
                    captionPanelLineMode);
                g.FillRectangle(lgb,rect);
            }
            g.DrawString(captionPanelParmeter.CaptionTitle, captionPanelParmeter.CaptionFont, 
                new SolidBrush(captionPanelParmeter.CaptionForeColor), 
                captionPanelParmeter.CaptionTitleLeft, captionPanelParmeter.CaptionTitleTop);
            if (captionPanelParmeter.IsUserCaptionBottomLine)
            {
               Pen pen1=new Pen(captionPanelParmeter.CaptionBottomLineColor,
                   captionPanelParmeter.CaptionBottomLineWidth);
                Point point1=new Point(captionPanelParmeter.CaptionLeft,captionPanelParmeter.CaptionTop+captionPanelParmeter.CaptionHeight);
                Point point2=new Point(captionPanelParmeter.CaptionLeft+this.Bounds.Width,captionPanelParmeter.CaptionTop+captionPanelParmeter.CaptionHeight);
                g.DrawLine(pen1, point1, point2);   
            }
        }
        #endregion
        #region 绘制图形
        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="g">画布</param>
        void DrawImageShow(Graphics g)
        {
            if (captionPanelParmeter.IsPanelImage)
            {
                if (m_ImageShow != null)
                {
                    g.DrawImage(m_ImageShow, new Point(captionPanelParmeter.PanelImageLeft, captionPanelParmeter.PanelImageTop));
                }
            }

        }
        #endregion
        #endregion
        #region 添加新组件
        /// <summary>
        /// 添加新组件
        /// </summary>
        /// <param name="c">组件</param>
        public void AddNewChildControls(Control c)
        {
            this.Controls.Add(c);
        }
        #endregion
        #endregion
        #region 属性

        #region PanelImage
        /// <summary>
        /// 是否显示面板的图像
        /// </summary>
        public bool IsPanelImage
        {
            get
            {
                return captionPanelParmeter.IsPanelImage;
            }
            set
            {
                    captionPanelParmeter.IsPanelImage = value;
                
              
               this.Refresh();
            }
        }
        /// <summary>
        /// 面板的图像
        /// </summary>
        public Image PanelImage
        {
            get
            {
                return m_ImageShow;
            }
            set
            {
                m_ImageShow = value;
            }
        }

        #endregion

        #region ClaseButton
        /// <summary>
        /// 关闭按钮的顶点
        /// </summary>
        public int CloseButtonTop
        {
            get { return lblCloseControl.Top; }
        }
        /// <summary>
        /// 关闭按钮的高度
        /// </summary>
        public int CloseButtonHeight
        {
            get { return lblCloseControl.Height; }
        }
        /// <summary>
        /// 使用关闭按钮
        /// </summary>
        public bool IsUserButtonClose
        {
            get
            {
                return captionPanelParmeter.IsUserButtonClose;
            }
            set
            {
                captionPanelParmeter.IsUserButtonClose = value;
                if (captionPanelParmeter.IsUserButtonClose)
                {
                    lblCloseControl.Visible = true;
                    InilblCloseButton();
                }
                else
                {
                    lblCloseControl.Visible = false;
                }
                this.Refresh();

            }
        }
        /// <summary>
        /// 关闭按钮鼠标移上去的颜色
        /// </summary>
        public Color CaptionCloseButtonForeColor
        {
            get
            {
                return captionPanelParmeter.CaptionCloseButtonForeColor;
            }
            set
            {
                captionPanelParmeter.CaptionCloseButtonForeColor = value;
            }
        }
        /// <summary>
        /// 是否使用默认的关闭按钮，如果不是，其左边界的设置将可成为有效设置
        /// </summary>
       [Category("关闭按钮"),Description("是否使用默认的关闭按钮，如果不是，其左边界的设置将可成为有效设置")]
        public bool IsUserSystemCloseButtonLeft
        {
            get { return m_IsUserSystemCloseButtonLeft; }
            set 
            { 
                m_IsUserSystemCloseButtonLeft = value;
                InilblCloseButton();
                this.Refresh(); 
            }
        }
        /// <summary>
        /// 是否使用默认的关闭按钮，如果不是，其左边界的设置将可成为有效设置
        /// </summary>
        [Category("关闭按钮"), Description("是否使用默认的关闭按钮，如果不是，其左边界的设置将可成为有效设置")]
        public int CaptionCloseButtonControlLeft
        {
            get { return captionPanelParmeter.CaptionCloseButtonControlLeft; }
            set { captionPanelParmeter.CaptionCloseButtonControlLeft = value; this.Refresh(); }
        }
        /// <summary>
        /// 更改关闭按钮上的文字
        /// </summary>
        [Category("关闭按钮"), Description("关闭按钮上的文字")]
        public string CaptionCloseButtonTitle
        {
            get { return captionPanelParmeter.CaptionCloseButtonTitle; }
            set 
            { 
             captionPanelParmeter.CaptionCloseButtonTitle = value;
             this.Refresh();
            }
        }

        #endregion

        #region CaptionTitle
        /// <summary>
        /// 设置标题单色背景
        /// </summary>
        public Color CaptionBackColor
        {
            get
            {
                return captionPanelParmeter.CaptionBackColor;
            }
            set
            {
                captionPanelParmeter.CaptionBackColor = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 标题字的顶
        /// </summary>
        public int CaptionTitleTop
        {
            get
            {
                return captionPanelParmeter.CaptionTitleTop;
            }
            set
            {
                captionPanelParmeter.CaptionTitleTop = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// 标题字  左
        /// </summary>
        public int CaptionTitleLeft
        {
            get
            {
                return captionPanelParmeter.CaptionTitleLeft;
            }
            set
            {
                captionPanelParmeter.CaptionTitleLeft = value;
                this.Refresh();

            }
        }

        /// <summary>
        /// 标题的上边界
        /// </summary>
        public int CaptionTop
        {
            get
            {
                return captionPanelParmeter.CaptionTop;
            }
            set
            {
                captionPanelParmeter.CaptionTop = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 标题的左边界
        /// </summary>
        public int CaptionLeft
        {
            get
            {
                return captionPanelParmeter.CaptionLeft;
            }
            set
            {
                captionPanelParmeter.CaptionLeft = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 标题的高度
        /// </summary>
        [Category("标题设置"),Description("标题的高")]
        public int CaptionHeight
        {
            get
            {
                return captionPanelParmeter.CaptionHeight;
            }
            set
            {
                captionPanelParmeter.CaptionHeight = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 是否只显示标题
        /// </summary>
        [Category("标题设置"), Description("是否只显示标题")]
        public bool IsOnlyCaption
        {
            get
            {
                return m_IsOnlyCaption;
            }
            set
            {
                m_IsOnlyCaption = value;
               
            }
        }
        /// <summary>
        /// 标题的字体
        /// </summary>
        public Font CaptionFont
        {
            get
            {
                return captionPanelParmeter.CaptionFont;
            }
            set
            {
                captionPanelParmeter.CaptionFont = value;
                this.Refresh();
            }

        }

        /// <summary>
        /// 线的渐变模式
        /// </summary>
        public LinearGradientMode CaptionPanelLineMode
        {
            get
            {
                return captionPanelLineMode;
            }
            set
            {
                captionPanelLineMode = value;
                this.Refresh();
            }
            
        }
        /// <summary>
        /// 标题的前景色
        /// </summary>
        public virtual Color CaptionForeColor
        {
            get
            {
                return captionPanelParmeter.CaptionForeColor;
            }
            set
            {
                captionPanelParmeter.CaptionForeColor = value;
            }
        }
        /// <summary>
        /// 渐变1
        /// </summary>
        public Color CaptionBackColor1
        {
            get
            {
                return captionPanelParmeter.CaptionBackColor1;
            }
            set
            {
                captionPanelParmeter.CaptionBackColor1 = value;
            }
        }
        /// <summary>
        /// 渐变2
        /// </summary>
        public Color CaptionBackColor2
        {
            get
            {
                return captionPanelParmeter.CaptionBackColor2;
            }
            set
            {
                captionPanelParmeter.CaptionBackColor2 = value;
            }
        }

        /// <summary>
        /// office2003
        /// </summary>
        public Color FormBackColorOffice2003
        {
            get
            {
                return captionPanelParmeter.FormBackColorOffice2003;
            }          
        }
        /// <summary>
        /// office2007
        /// </summary>
        public Color FormBackColorOffice2007
        {
            get
            {
                return captionPanelParmeter.FormBackColorOffice2007;
            }
        }
        /// <summary>
        /// 是否启用底线
        /// </summary>
        public bool IsUserCaptionBottomLine
        {
            get
            {
                return captionPanelParmeter.IsUserCaptionBottomLine;
            }
            set
            {
                captionPanelParmeter.IsUserCaptionBottomLine = value;
                this.Refresh();
            }
        }
        
        /// <summary>
        /// 标题底线颜色
        /// </summary>
        public Color CaptionBottomLineColor
        {
            get
            {
                return captionPanelParmeter.CaptionBottomLineColor;
            }
            set
            {
                captionPanelParmeter.CaptionBottomLineColor=value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 是否有边框线
        /// </summary>
        public bool IsBorderLine
        {
            get
            {
                return captionPanelParmeter.IsBorderLine;
            }
            set
            {
                captionPanelParmeter.IsBorderLine = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 边框线的颜色
        /// </summary>
        public Color BorderLineColor
        {
            get
            {
                return captionPanelParmeter.BorderLineColor;
            }
            set
            {
                captionPanelParmeter.BorderLineColor = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 标题底线的线宽
        /// </summary>
        public int CaptionBottomLineWidth
        {
            get
            {
                return captionPanelParmeter.CaptionBottomLineWidth;
            }
            set
            {
                captionPanelParmeter.CaptionBottomLineWidth = value;
                this.Refresh();
            }
        }
        /// <summary>
        ///  标题
        /// </summary>
        public string CaptionTitle
        {
            get
            {
                return captionPanelParmeter.CaptionTitle;
            }
            set
            {
                captionPanelParmeter.CaptionTitle = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 标题是否启用渐变
        /// </summary>
        public bool IsCaptionSingleColor
        {
            get
            {
                return captionPanelParmeter.IsCaptionSingleColor;
            }
            set
            {
                captionPanelParmeter.IsCaptionSingleColor = value;
                this.Refresh();
            }

        }
        #endregion

        #region 样式
        /// <summary>
        /// 设置或获取CaptionPanel默认显示样式
        /// </summary>
        public CaptionPanelStyleEnum SetCaptionPanelStyle
        {
            get
            {
                return userCaptionStyle;
            }
            set
            {
                userCaptionStyle = value;
                switch (userCaptionStyle)
                {
                    case CaptionPanelStyleEnum.BlueCaption:
                        {
                            SetBlueCaption();
                            break;
                        }
                    case CaptionPanelStyleEnum.paleCaptionNoBorder:
                        {
                            SetpaleCaptionNoBorder();
                            break;
                        }
                    case CaptionPanelStyleEnum.Office2007Panel:
                        {
                            SetOffice2007Panel();
                            break;
                        }
                    case CaptionPanelStyleEnum.paleCaption:
                        {
                            SetPaleCaption();
                            break;
                        }
                    case CaptionPanelStyleEnum.windowsStyle:
                        {
                            SetWindowsStyle();
                            break;
                        }
                    case CaptionPanelStyleEnum.Office2003:
                        {
                            SetOffice2003();
                            break;
                        }
                    case CaptionPanelStyleEnum.MouseDownStyle:
                        {
                            SetMouseDownStyle();
                            break;
                        }
                    case CaptionPanelStyleEnum.MouseEnterStyle:
                        {
                            SetMouseEnterStyle();
                            break;
                        }
                    case CaptionPanelStyleEnum.DeepPaleCaption:
                        {
                            SetDeepPaleCaption();
                            break;
                        }
                    case CaptionPanelStyleEnum.Office2003NoBorder:
                        {
                            SetOffice2003NoBorder();
                            break;
                        }
                 
                    case CaptionPanelStyleEnum.Office2007NoBorder:
                        {
                            SetOffice2007NoBorder();
                            break;
                        }
                    case CaptionPanelStyleEnum.DeepPaleCaptionNoBorder:
                        {
                            SetDeepPaleCaptionNoBorder();
                            break;
                        }
                    case CaptionPanelStyleEnum.ButtonUnenable:
                        {
                            SetButtonUnenable();
                            break;
                        }
                    case CaptionPanelStyleEnum.None:
                        {
                            captionPanelParmeter.IsBorderLine = true;

                            captionPanelParmeter.IsCaptionSingleColor = true;
                            captionPanelParmeter.IsUserCaptionBottomLine = true;
                            
                            captionPanelParmeter.CaptionBackColor = Color.FromArgb(255, 255, 255);
                            //captionPanelParmeter.CaptionForeColor = Color.FromArgb(255, 255, 255);
                            captionPanelParmeter.BorderLineWidth = 1;
                            captionPanelParmeter.BorderLineColor = Color.FromArgb(245, 239, 239);
                            break;
                        }
                    case CaptionPanelStyleEnum.UnEnableWindowsStyle:
                        {
                            SetUnEnableWindowsStyle();
                            break;
                        }
                }
                this.Refresh();
            }
           
        }
        #endregion
        #region 设置相关参数CaptionPanelParameter对象
        /// <summary>
        /// 设置相关参数CaptionPanelParameter对象
        /// </summary>
        private CaptionPanelParameter SetCaptionPanelParameter
        {
            get
            {
                return captionPanelParmeter;

            }
            set
            {
                captionPanelParmeter = value;
            }
        }

        #endregion
        #endregion
        #region 事件处理
        #region lblCloseControl 事件
        /// <summary>
        /// 成为活动控件生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCloseControl_Enter(object sender, EventArgs e)
        {
            
        }
       
        private void lblCloseControl_Leave(object sender, EventArgs e)
        {
            isCaptionCloseButtonEnter = false;

            lblCloseControl.Refresh();
        }
        
        void lblCloseControl_Paint(object sender, PaintEventArgs e)
        {
           // Graphics g = e.Graphics;
            //g.DrawImage(Image.FromFile(), 0, 0);
            if (isCaptionCloseButtonEnter)
            {
                DrawCloseButtonBorderLine(e.Graphics);
            }
            else
            {
                DrawCloseButtonNormal(e.Graphics);
            }
        }
       
        private void lblCloseControl_Click(object sender, EventArgs e)
        {
            try
            {
                CloseButtonClick(sender, e);
            }
            catch
            {
            }

        }
        private void lblCloseControl_MouseDown(object sender, MouseEventArgs e)
        {
            lblCloseControl.BackColor = captionPanelParmeter.CaptionCloseButtonEnterBorderColor;
        }
        private void lblCloseControl_MouseEnter(object sender, EventArgs e)
        {
            isCaptionCloseButtonEnter = true;
            DrawCloseButtonBorderLine(lblCloseControl.CreateGraphics());
            lblCloseControl.BackColor = captionPanelParmeter.CaptionCloseButtonEnterBackColor;
            
            lblCloseControl.Refresh();
        }
        private void lblCloseControl_MouseLeave(object sender, EventArgs e)
        {
            DrawCloseButtonNormal(lblCloseControl.CreateGraphics());
            isCaptionCloseButtonEnter = false;
            lblCloseControl.Refresh();
        }
        #endregion
        #region CaptionPanel 事件
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptionPanel_Paint(object sender, PaintEventArgs e)
        {

            if (m_IsOnlyCaption)//只有标题
            {
                if (captionPanelParmeter.IsBorderLine)//有边框线
                {
                    //设置控件的高度
                    this.Height = captionPanelParmeter.CaptionHeight + captionPanelParmeter.CaptionTop + captionPanelParmeter.BorderLineWidth;
                    DrawBorderLine(e.Graphics);

                }
                else
                {
                    this.Height = captionPanelParmeter.CaptionHeight + captionPanelParmeter.CaptionTop;
                }
            }
            else
            {
                if (captionPanelParmeter.IsBorderLine)
                {
                    DrawBorderLine(e.Graphics);
                }
            }
            DrawCaption(e.Graphics);//绘制标题
            DrawImageShow(e.Graphics);//绘制图形image
        }
        private void CaptionPanel_Load(object sender, EventArgs e)
        {
            
            
            if (captionPanelParmeter.IsUserBackColor)
            {
                this.BackColor = captionPanelParmeter.PanelBackColor;
            }
        }
        private void CaptionPanel_SizeChanged(object sender, EventArgs e)
        {
            InilblCloseButton();
            this.Refresh();

        }
        private void CaptionPanel_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
        #endregion
        #region 鼠标单击

      
        #endregion
        #endregion
    }
    #endregion

}
