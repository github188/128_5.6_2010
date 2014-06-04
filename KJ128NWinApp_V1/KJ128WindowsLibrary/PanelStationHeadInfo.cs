using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
namespace KJ128WindowsLibrary
{
    /// <summary>
    /// ��Ϣ����ʽ
    /// </summary>
    public enum PanelStationHeadInfoStyle
    {
        /// <summary>
        /// ����ģʽ
        /// </summary>
        NormalMode,
        /// <summary>
        /// ����ƶ���ȥ��ģʽ
        /// </summary>
        MouseMoveMode
    }
    /// <summary>
    /// ��ʾ�������ŵ���Ϣ�����
    /// </summary>
    public class PanelStationHeadInfo:LabelPanel
    {

        #region ˽�б���
             
        #region ��ʾ������
        private LabelInfo m_FieldStationAddress = new LabelInfo("",new PointF(4, 8));
        private LabelInfo m_ValueStationAddress = new LabelInfo("", new PointF(75, 8));
        private LabelInfo m_FieldStationHeadAddress = new LabelInfo("������վ���:",new PointF(4,25));
        private LabelInfo m_ValueStatinHeadAddress = new LabelInfo("1", new PointF(95,25));
        private LabelInfo m_ValueEnterTotalPerson = new LabelInfo("����������", new PointF(4,65));
        private LabelInfo m_ValueStationHeadPlace = new LabelInfo("��װλ�ð�װλ�ð�װλ�ð�װλ��", new PointF(4, 42));
        private LabelInfo m_FieldAntennaA = new LabelInfo("");
        private LabelInfo m_ValueAntennaA = new LabelInfo("");
        private LabelInfo m_FieldAntennaB = new LabelInfo("");
        private LabelInfo m_ValueAntennaB = new LabelInfo("");
        /// <summary>
        /// ԭʼ
        /// </summary>
        private string oldFA="1", oldFB="2";

        /// <summary>
        /// ԭʼ����A����
        /// </summary>
        public string OldFB
        {
            get { return oldFB; }
            set { oldFB = value; }
        }

        /// <summary>
        /// ԭʼ����B����
        /// </summary>
        public string OldFA
        {
            get { return oldFA; }
            set { oldFA = value; }
        }

        #endregion
        #region ��ʽ
        //private PanelStationHeadInfoStyle m_PanelStationHeadInfoStyle = PanelStationHeadInfoStyle.NormalMode;
        #endregion
        #region ����
        private string m_StationAddress = "";
        private string m_StationHeadAddress = "";
        #endregion


        #endregion
        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public PanelStationHeadInfo():base()
        {
           // base.Paint += new PaintEventHandler(PanelStationHeadInfo_Paint);
            this.SetLabelPanelStyle = LabelPanelStyle.FillGradual;
            this.Paint += new PaintEventHandler(PanelStationHeadInfo_Paint);
           // this.MouseEnter += new System.EventHandler(PanelStationHeadInfo_MouseEnter);
        }
        #endregion
        #region ���� 

        /// <summary>
        /// ��վ��ַ
        /// </summary>
        [Category("��ʾ����"), Description("��վ���")]
        public string StationAddress
        {
            get { return this.m_StationAddress; }
            set
            {
                this.m_StationAddress = value;
               
            }
        }

        /// <summary>
        /// ��������ַ
        /// </summary>
        [Category("��ʾ����"), Description("��������ַ")]
        public string StationHeadAddress
        {
            get { return this.m_StationHeadAddress; }
            set
            {
                this.m_StationHeadAddress = value;
               
            }
        }

        #region ��ʾ����
        /// <summary>
        /// �������ŵ��ı�
        /// </summary>
        [Category("��ʾ����"), Description("�������ŵ��ı�")]
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
        /// �������ŵ��ı�
        /// </summary>
        [Category("��ʾ����"), Description("�������ŵ��ı�")]
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
        /// �������ŵ��ı�
        /// </summary>
        [Category("��ʾ����"),Description("�������ŵ��ı�")]
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
        /// ��������ַ
        /// </summary>
        [Category("��ʾ����"), Description("��������ֵַ")]
        public LabelInfo ValueStationHeadAddress
        {
            get { return m_ValueStatinHeadAddress; }
            set { m_ValueStatinHeadAddress = value; this.Refresh(); }
        }

        /// <summary>
        /// ����������
        /// </summary>
        [Category("��ʾ����"), Description("����������")]
        public LabelInfo ValueEnterTotalPerson
        {
            get { return m_ValueEnterTotalPerson; }
            set { m_ValueEnterTotalPerson = value; this.Refresh(); }
        }

        /// <summary>
        /// ��������װλ��
        /// </summary>
        [Category("��ʾ����"), Description("��������װλ��")]
        public LabelInfo ValueStationHeadPlace
        {
            get { return m_ValueStationHeadPlace; }
            set { m_ValueStationHeadPlace = value; this.Refresh();
            }
        }

        /// <summary>
        /// ����A�ֶ�
        /// </summary>
        [Category("��ʾ����"), Description("����A�ֶ�")]
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
        /// ����A��ֵ
        /// </summary>
        [Category("��ʾ����"), Description("����A��ֵ")]
        public LabelInfo ValueAntennaA
        {
            get {return  m_ValueAntennaA; }
            set 
            {    
                m_ValueAntennaA = value; this.Refresh(); 
            }
        }

        /// <summary>
        /// ����B�ֶ�
        /// </summary>
        [Category("��ʾ����"), Description("����B�ֶ�")]
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
        /// ����B��ֵ
        /// </summary>
        [Category("��ʾ����"), Description("����B��ֵ")]
        public LabelInfo ValueAntennaB
        {
            get { return m_ValueAntennaB; }
            set { m_ValueAntennaB = value; this.Refresh(); }
        }
        #endregion
        #endregion
        #region ����
        void DrawString(Graphics g,LabelInfo lblInfo)
        {
            g.DrawString(lblInfo.FieldName,lblInfo.FieldFont,new SolidBrush(lblInfo.FieldColor),lblInfo.Location);
        }
        
        #endregion
        #region �¼�
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

        #region [ ����: ����6���ַ��á���ʾ ]

        private string GetDisPlayString(string str)
        {
            int _iCount = 8;
            System.Text.ASCIIEncoding n = new System.Text.ASCIIEncoding();
            byte[] b = n.GetBytes(str);
            int length = 0;                          // l Ϊ�ַ�����ʵ�ʳ���
            int len = 0;
            bool _blDouble = true;
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63)             //�ж��Ƿ�Ϊ���ֻ�ȫ�ŷ���
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

        #region [ ����: �õ��ַ������� ]

        /// <summary>
        /// �õ��ַ�������
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int GetLength(string str)
        {
            System.Text.ASCIIEncoding n = new System.Text.ASCIIEncoding();
            byte[] b = n.GetBytes(str);
            int length = 0;                          // l Ϊ�ַ�����ʵ�ʳ���
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63)             //�ж��Ƿ�Ϊ���ֻ�ȫ�ŷ���
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
    /// ָ���ı��������ݵĽṹ
    /// </summary>
    public class LabelInfo
    {
        #region ˽�б���
        private string m_FieldName = "FiledName";
        private Color m_FieldColor = Color.Black;
        private Font m_FieldFont = new Font("����", 9F,
            System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        private bool m_IsShowBackGround = false;
        private Color m_BackGroundColor = Color.White;
        private PointF m_Location = new PointF(19, 6);

        private Color m_MouseMoveColor = Color.FromArgb(184, 207, 233);
        
        #endregion

        #region ���캯��
        /// <summary>
        /// ������Ϣ����
        /// </summary>
        public LabelInfo()
        {
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        public LabelInfo(string fieldName)
        {
            m_FieldName = fieldName;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="fieldName">�ֶ�����</param>
        /// <param name="location">�ؼ����Ͻǵ�����</param>
        public LabelInfo(string fieldName, PointF location)
        {
            m_FieldName = fieldName;
            m_Location = location;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="fieldName">�ֶ�����</param>
        /// <param name="location">�ؼ����Ͻǵ�����</param>
        /// <param name="font">����</param>
        public LabelInfo(string fieldName,PointF location,Font font)
        {
            m_FieldName = fieldName;
            m_Location = location;
            m_FieldFont = font;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="fieldName">�ֶ�����</param>
        /// <param name="location">�ؼ����Ͻǵ�����</param>
        /// <param name="color">������ɫ</param>
        public LabelInfo(string fieldName, PointF location, Color color)
        {
            m_FieldName = fieldName;
            m_Location = location;
            m_FieldColor = color;
        }
     /// <summary>
        /// ���캯��
     /// </summary>
        /// <param name="fieldName">�ֶ�����</param>
        /// <param name="location">�ؼ����Ͻǵ�����</param>
        /// <param name="font">������ɫ</param>
     /// <param name="color"></param>
        public LabelInfo(string fieldName, PointF location,Font font, Color color)
        {
            m_FieldName = fieldName;
            m_Location = location;
            m_FieldFont = font;
            m_FieldColor = color;
        }
        #endregion
        #region ����
        /// <summary>
        /// ����ƶ���ȥ����ɫ
        /// </summary>
        [Category("��ʾ������"), Description("����ƶ���ȥ����ɫ")]
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
        /// �ֶε�����
        /// </summary>
        [Category("��ʾ������"), Description("�ֶε�����")]
        public string FieldName
        {
            get { return m_FieldName; }
            set { m_FieldName = value;}
        }
        /// <summary>
        /// ���ֵ���ɫ
        /// </summary>
        [Category("��ʾ������"), Description("���ֵ���ɫ")]
        public Color FieldColor
        {
            get { return m_FieldColor; }
            set { m_FieldColor = value; }
        }
        /// <summary>
        /// ���ֵ�����
        /// </summary>
        [Category("��ʾ������"), Description("���ֵ�����")]
        public Font FieldFont
        {
            get { return m_FieldFont; }
            set { m_FieldFont = value; }
        }
        /// <summary>
        /// �Ƿ���ʾ����
        /// </summary>
        [Category("��ʾ������"), Description("�Ƿ���ʾ����")]
        public bool IsShowBackGround
        {
            get { return m_IsShowBackGround; }
            set { m_IsShowBackGround = value; }
        }
        /// <summary>
        /// ��������ɫ
        /// </summary>
        [Category("��ʾ������"), Description("��������ɫ")]
        public Color BackGroundColor
        {
            get { return m_BackGroundColor; }
            set { m_BackGroundColor = value; }
        }
        /// <summary>
        /// �ؼ������Ͻǵ�����
        /// </summary>
        [Category("��ʾ������"), Description("�ؼ������Ͻǵ�����")]
        public PointF Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }
        #endregion
        #region ����
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