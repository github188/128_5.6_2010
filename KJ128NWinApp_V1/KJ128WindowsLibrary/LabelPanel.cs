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
    /// LabelPanelStyle ��ʽ
    /// </summary>
    public enum LabelPanelStyle
    {
        /// <summary>
        /// ������ģʽ
        /// </summary>
        BorderMode,
        /// <summary>
        /// �������ģʽ
        /// </summary>
        FillGradual,
        /// <summary>
        /// ��Ӱ��ͼ��ģʽ
        /// </summary>
        FillHatchBrush
      
    }
    /// <summary>
    /// д���ı��Ļ���� 
    /// </summary>
    public partial class LabelPanel : UserControl
    {
        #region ˽�б���

        #region �߿�
        private int m_BorderLineWidth = 1;//�߿�
        private Color m_BorderLineColor = Color.FromArgb(158, 182, 206);//������ɫ
        private bool m_IsBorderLine = true; //�Ƿ�ʹ�ñ߿���
        private bool m_IsMouseHander = true;//�������Ĭ���¼�
        #endregion
        
        #region ��ʽ
        private LabelPanelStyle m_SetLabelPanelStyle = LabelPanelStyle.BorderMode;//��ʽ
        
        
        #endregion
        #region ��䱳��
        private bool m_IsFillBackGround = false; //�Ƿ���䱳��ɫ
        private Color m_FillGradualColor1 = Color.FromArgb(244, 248, 250);//Color1
        private Color m_FillGradualColor2 = Color.FromArgb(211, 220, 233);//color2

        private LinearGradientMode m_SetBackGroundGradineMode = LinearGradientMode.ForwardDiagonal;//GradineMode
       
        
        #endregion
        #region ��Ӱ��ͼ��ģʽ
        private bool m_IsHatchBrush = false;//ʹ����Ӱ��ͼ��ģʽ
        private Color m_HatchBackgroundColor = Color.FromArgb(200,200,200);
        private Color m_HatchForegroundColor = Color.FromArgb(255,255,255);
        private HatchStyle m_SetHatchStyle = HatchStyle.Percent40;
        

        
        #endregion

      
        #endregion
        #region ���캯��
        /// <summary>
        /// ����
        /// </summary>
        public LabelPanel()
        {
            
            this.Paint += new PaintEventHandler(LabelPanel_Paint);
            this.MouseEnter += new System.EventHandler(LabelPanel_MouseEnter);
            this.MouseLeave += new System.EventHandler(LabelPanel_MouseLeave);

        }

        


   
        #endregion

        #region ����
        /// <summary>
        /// �Ƿ����Ĭ��������鴦��
        /// </summary>
        [Category("��չ������"), Description("�Ƿ����Ĭ��������鴦��")]
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
        #region ��Χ�߿� border
        /// <summary>
        /// �߿��߿�
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
        /// �߿��ߵ���ɫ
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
        /// �б߿�����
        /// </summary>
        /// <value>
        /// �б߿���
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
        #region ��ʽ
        /// <summary>
        /// ������ʽ 
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
        #region ����
        /// <summary>
        /// �Ƿ���䱳��
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
        /// ��������ɫ1
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
        /// ��������ɫ2
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
        /// �������䷽ʽ
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
        
        #region ��Ӱ��ͼ��
        /// <summary>
        /// �Ƿ�ʹ����Ӱ��ͼ��
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
        /// ��Ӱ�ı���
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
        /// ǰ��ɫHatchBrush
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
        #region ����


        /// <summary>
        /// ���Ʊ���
        /// </summary>
        /// <param name="g"></param>
        void DrawBorder(Graphics g)
        {
            Rectangle rect = new Rectangle(0,0,this.Width-1,this.Height-1);
            g.DrawRectangle(new Pen(m_BorderLineColor, m_BorderLineWidth), rect);
        }
        /// <summary>
        /// �������ı���
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
        ///������ʱ�Ŀؼ�����Ϊ�������Ҫ��һ����Ч��������д�˷���
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
        /// ����뿪ʱ�Ŀؼ�����Ϊ,�����´˷���
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
        /// ������Ӱ��ͼ��
        /// </summary>
        /// <param name="g">����</param>
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
        #region �¼�����
       /// <summary>
       /// ����ػ�
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
