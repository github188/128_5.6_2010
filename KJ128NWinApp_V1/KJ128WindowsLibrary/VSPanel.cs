using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using System.Drawing.Drawing2D;
namespace KJ128WindowsLibrary
{
    #region ��ʽ
    /// <summary>
    /// ��ʽ
    /// </summary>
    public enum VSPanelLayoutType
    {
        /// <summary>
        /// ���ɶ���
        /// </summary>
        FreeLayoutType,
        /// <summary>
        /// ˮƽ
        /// </summary>
        VerticalType,
        /// <summary>
        ///��ֱ 
        /// </summary>
        HorizontalType
    }
    #endregion

    #region enum VsPaneBackGroundStyle
    /// <summary>
    /// ����
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
        /// �ޱ�����ʽ
        /// </summary>
        NoBackstyle,
        /// <summary>
        /// ����ɫ��PaleCaption��
        /// </summary>
        DeepPaleCaption,
        /// <summary>
        /// ����ʽ
        /// </summary>
        None
    }
    #endregion
    /// <summary>
    /// ѧϰκ��Ԫ �Զ���panel
    /// </summary>
    public class VSPanel:Panel
    {
        #region ˽�б���fields
       
        /// <summary>
        /// �Ƿ����ֱ���ڴ�����ҷģʽ
        /// </summary>
        private bool m_IsDragModel = false; 
        #region �ָ����ơ�
        private VSPanelLayoutType m_LayoutType = VSPanelLayoutType.FreeLayoutType;
        private int m_VerticalInterval = 8;//ˮƽ���
        private int m_HorizontalInterval = 8;//��ֱ���

        private int m_LeftInterval = 0; //��߽�
        private int m_RightInterval = 0;//�ұ߽�

        private int m_TopInterval = 0;
        private int m_BottomInterval = 0;

        private bool m_IsmiddleInterval = false;//�Ƿ������м�ָ�
        private int m_BetweenControlCount = 2;

        private int m_MiddleInterval = 80;

        #endregion
        #region ����
        private bool m_IsCaptionSingleColor = true;//�Ƿ����ý���
        private Color m_LinearGradientColor1 = Color.FromArgb(244, 248, 250);
        private Color m_LinearGradientColor2 = Color.FromArgb(211, 220, 233);
       
        private LinearGradientMode m_BackLinearGradientMode = LinearGradientMode.ForwardDiagonal;
        #endregion
        #region �߿���
        /// <summary>
        /// �Ƿ��б߿���
        /// </summary>
        private bool m_IsBorderLine = false;

        private Color m_BorderLineColor = Color.FromArgb(118, 153, 199);
        

        #endregion
        #region �ײ���
        private Color m_BottomLineColor = Color.FromArgb(197, 197, 197);
        private bool m_IsBottomLineColor = false;
        #endregion
        #region ��ʽ
        private VsPaneBackGroundStyle m_BackGroundStyle = VsPaneBackGroundStyle.windowsStyle;
        #endregion
        #endregion
        #region ���캯��
        /// <summary>
        /// ���캯��
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
        #region ����
        #region ��ʽ����
        /// <summary>
        /// ���ñ�����ʽ
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

        #region ���� ���С�����
        #region ���Ƶײ��ߺͱ߿���
        /// <summary>
        /// ���Ƶײ���
        /// </summary>
        /// <param name="g">����</param>
        protected void DrawBottomLine(Graphics g)
        {
            if(m_IsBottomLineColor)
            {
                g.DrawLine(new Pen(m_BottomLineColor),0,Height-1,Width,Height-1);
            }
        }
        /// <summary>
        /// ���Ʊ߿���
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
        #region ���ÿؼ�������ˮƽ����ֱ������ѡ��
        #region ˮƽ
        /// <summary>
       /// ���ÿؼ������ݵڼ�������
       /// </summary>
       /// <param name="s">�ؼ�</param>
       /// <param name="controlIndex">�ؼ��������ţ��ڼ����ؼ�</param>
        protected void VerticalLayout(Control s,int controlIndex)
        {
            int tem_Left = 0;
            int tem_ScrollRel = 0;//���������ƫ����
            int int_preControl = 0;
            int int_temTop = 0;

           // tem_ScrollRel = (this.VerticalScroll.Value*this.Height)/
                           // (this.VerticalScroll.Maximum - this.VerticalScroll.Minimum);


            int_temTop = m_TopInterval;
            if(m_IsDragModel)//��ҷģʽ
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
            else//�ֶ�ģʽ
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
       #region ˮƽ�ָ�
       /// <summary>
       /// ˮƽ�ָ����õĿ���
       /// </summary>
       /// <param name="s">��ǰ���ӿؼ�</param>
       /// <param name="int_preControl">��һ���ӿؼ�</param>
        protected void VerticalIntervalLayout(Control s,int int_preControl)
        {
            int tem_Left = 0;
            #region �����м�ָ�
            if (m_IsmiddleInterval)//�����м�ָ�����ô
            {
                if ((int_preControl) % m_BetweenControlCount == 0)//�ܱ�����
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
            #region ���ں�����
            //����������Է�һ��
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
        /// ˮƽ����
        /// </summary>
        /// <param name="s">��ӿؼ�</param>
        protected void VerticalLayout(Control s)
        {

            int tem_Left = 0;
            int int_ControlCount = this.Controls.Count;
            int int_preControl = int_ControlCount - 2;
            if (int_ControlCount > 1)
            {
                if (m_IsmiddleInterval)//�����м�ָ�����ô
                {
                    if ((int_preControl) % m_BetweenControlCount == 0)//�ܱ�����
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
                //����������Է�һ��
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
        #region ����
        /// <summary>
        /// �������͵Ĵ���
        /// </summary>
        /// <param name="e">����</param>
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
        /// �������͵Ĵ���
        /// </summary>
        /// <param name="c">�ڲ��ؼ�</param>
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
        #region ��ֱ
        /// <summary>
        /// ��ֱ����
        /// </summary>
        /// <param name="s">��ӿؼ�</param>
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
       /// ��ֱ���ÿؼ������ݵڼ����ؼ�����
       /// </summary>
       /// <param name="s">�ؼ�</param>
       /// <param name="controlIndex">�ڼ����ؼ�</param>
        protected void HorizontalLayout(Control s,int controlIndex)
        {
           
            int int_PreControl = 0;//�����һ���ؼ�������
            #region ��Ϊ������ҷ�ʹ����������ַ��÷��� 
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
        /// ��ֱ�ָ�
        /// </summary>
        /// <param name="s">��ǰ�ӿؼ�</param>
        /// <param name="int_PreControl">��һ���ؼ�������</param>
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
        #region ���Ʊ���
        /// <summary>
        /// ���Ʊ���
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
        #region �ػ� ����OnPaint
        /// <summary>
        /// �ػ�,�����ػ��¼�
        /// </summary>
        /// <param name="e">PaintEventArgs</param>
        protected override void OnPaint(PaintEventArgs e)
        {   DrawBackGround(e);
            DrawBorderLine(e.Graphics);
            DrawBottomLine(e.Graphics);
          
            base.OnPaint(e);


        }
        #endregion
        #region ���������������
        /// <summary>
        /// ���������������
        /// </summary>
        public virtual void RainRangeControl()
        {
            int controlIndex = 0;
            #region ���ŷ�Ϊ������ҷ���ֶ�������ӿؼ�
            if (m_IsDragModel)//������ҷ
            {
                for(int i=this.Controls.Count-1;i>=0;i--)
                {
                     LayoutTypeHander(this.Controls[i],i);
                }
            }
            else//������ӿؼ�
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
        #region��OnScroll
        /// <summary>
        /// ����Scroll�¼�
        /// </summary>
        /// <param name="se"></param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            
            this.Refresh();
        }
        #endregion
        #endregion
        #region ����
        #region �߿���
        /// <summary>
        /// �߿��ߵ���ɫ
        /// </summary>
        [Category("��չ������"), Description("�߿��ߵ���ɫ")]
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
        /// �Ƿ��б߿���
        /// </summary>
        [Category("��չ������"), Description("�Ƿ��б߿���")]
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
        #region �м�ָ�������
        /// <summary>
        /// �м�������
        /// </summary>
        [Category("��չ������"), Description("�м�������")]
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
        /// �м�ָ��ؼ�����
        /// </summary>
        [Category("��չ������"), Description("�м�ָ��ؼ�����")]
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
        /// �Ƿ������м�ָ�
        /// </summary>
        [Category("��չ������"), Description("�Ƿ������м�ָ�")]

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
        /// �����ߵ���ʽ
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
        /// �Ƿ����ý���
        /// </summary>
        [Category("��չ������"), Description("�Ƿ����ý���")]
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
        /// ������ɫ1
        /// </summary>
        [Category("��չ������"), Description("������ɫ1")]

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
        /// ������ɫ2
        /// </summary>
        [Category("��չ������"), Description("������ɫ2")]
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
        /// ��ʽ
        /// </summary>
        [Category("��չ������"), Description("ѡ���û���ʽ")]
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
        #region �߽缰���
        /// <summary>
        /// ˮƽ���
        /// </summary>
        [Category("��չ������"), Description("�ӿؼ�֮���ˮƽ���")]
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
        /// ��ֱ���
        /// </summary>
        [Category("��չ������"), Description("�ӿؼ�֮��Ĵ�ֱ���")]
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
        /// ����
        /// </summary>
        [Category("��չ������"), Description("�ɻ����ӿؼ�����߽�")]
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
        /// �ұ߽�
        /// </summary>
        [Category("��չ������"), Description("�ɻ����ӿؼ����ұ߽�")]
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
        /// ���߽�
        /// </summary>
        [Category("��չ������"), Description("�ɻ����ӿؼ��Ķ��߽�")]
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

        #region ��ʽ����
        /// <summary>
        /// ��ʽ����
        /// </summary>
        [Category("��չ������"), Description("��ʽ����")]
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
        #region �ײ���
        /// <summary>
        /// �Ƿ��еײ���
        /// </summary>
        [Category("��չ������"), Description("�Ƿ��еײ���")]
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
        /// �ײ��ߵ���ɫ
        /// </summary>
        [Category("��չ������"), Description("�ײ��ߵ���ɫ")]
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
        #region ��ҷ
        /// <summary>
        /// �Ƿ����ֱ���ڴ�����ҷģʽ
        /// </summary>
        [Category("��չ������"), Description("�Ƿ����ֱ���ڴ�����ҷģʽ")]
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
        #region �¼�����
        void VSPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            LayoutTypeHander(e);
        }
        #endregion

    }
}//namespace

