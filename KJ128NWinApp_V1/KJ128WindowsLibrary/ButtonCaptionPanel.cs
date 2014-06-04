using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
namespace KJ128WindowsLibrary
{
    /// <summary>
    /// �����롡���¡��İ�ť������ʽ
    /// </summary>
    public enum ButtonCaptionPanelButtonStyle
    {
        /// <summary>
        /// windows��ʽ
        /// </summary>
        WindowsStyle,
        /// <summary>
        /// office2003��ʽ
        /// </summary>
        Office2003Style,
        /// <summary>
        /// û������Ч��
        /// </summary>
        None
    }

    /// <summary>
    /// ��CaptionPanel��Ϊһ����ťʹ��
    /// </summary>
    public class ButtonCaptionPanel : CaptionPanel
    {
        
        #region ˽�б���
        private CaptionPanelStyleEnum cpse_DefualStyle = CaptionPanelStyleEnum.windowsStyle; //Ĭ����ʽ
        //��ť��ʽ
        private ButtonCaptionPanelButtonStyle m_ButtonStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;

        private CaptionPanelStyleEnum m_UnEnableStyle = CaptionPanelStyleEnum.UnEnableWindowsStyle;

        private bool m_IsMouseEnter = false;

        //private ButtonCaptionPanelButtonStyle m_NormalStyle = ButtonCaptionPanelButtonStyle.WindowsStyle;
        //private ButtonCaptionPanelButtonStyle
        #endregion
        /// <summary>
        /// ��CaptionPanel��Ϊһ����ťʹ��
        /// </summary>
        public ButtonCaptionPanel()
            : base()
        {
            this.IsUserButtonClose = false;//��ʹ�ùرհ�ť
            this.IsOnlyCaption = true;
            this.IsPanelImage = true;
          
            this.SetCaptionPanelStyle = CaptionPanelStyleEnum.windowsStyle;
            this.Cursor = Cursors.Hand;

        }
        #region ����
        /// <summary>
        /// ����Office2007NoBorder
        /// </summary>
        protected override void SetOffice2007NoBorder()
        {
            base.SetOffice2007NoBorder();
            this.IsBorderLine = true;
            this.BorderLineColor = this.CaptionBackColor;
        }
        /// <summary>
        /// ����BlueCaption��ʽ���ޱ���
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
        /// ���¶���Office2003NoBorder��ʽ
        /// </summary>
        protected override void SetOffice2003NoBorder()
        {
            base.SetOffice2003NoBorder();
            this.IsBorderLine = true;
            this.BorderLineColor = this.CaptionBackColor1;
        }
        /// <summary>
        /// ���¶���paleCaptionNoBorde��ʽ
        /// </summary>
        protected override void SetpaleCaptionNoBorder()
        {
            base.SetpaleCaptionNoBorder();
            this.IsBorderLine = true;
            this.BorderLineColor = this.CaptionBackColor;
        }
        /// <summary>
        /// ������
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
        /// ����뿪
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
        /// ��갴��
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

        #region ����
        /// <summary>
        /// ���õ������롡�뿪�����¡�ʱ�������ʽ
        /// </summary>
        [Category("���ӵ�����"), Description("���õ������롡�뿪�����¡�ʱ�������ʽ")]
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
        /// �ؼ���Чʱ��ʾ����ʽ
        /// </summary>
        [Category("���ӵ�����"), Description("�ؼ���Чʱ��ʾ����ʽ")]
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