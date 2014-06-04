using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
namespace KJ128WindowsLibrary
{
    ///// <summary>
    ///// ��Ϣ����ʽ
    ///// </summary>
    //public enum PanelStationHeadInfoStyle
    //{
    //    /// <summary>
    //    /// ����ģʽ
    //    /// </summary>
    //    NormalMode,
    //    /// <summary>
    //    /// ����ƶ���ȥ��ģʽ
    //    /// </summary>
    //    MouseMoveMode
    //}
    /// <summary>
    /// ��ʾ�������ŵ���Ϣ�����
    /// </summary>
    public class PanelStationInfo:LabelPanel
    {

        #region ˽�б���
             
        #region ��ʾ������

        private LabelInfo m_FieldStationAddress = new LabelInfo("");
        private LabelInfo m_ValueStationAddress = new LabelInfo("");
        private LabelInfo m_ValueEnterTotalPerson = new LabelInfo("����������", new PointF(4,50));
        private LabelInfo m_ValueStationHeadPlace = new LabelInfo("��װλ�ð�װλ�ð�װλ�ð�װλ��", new PointF(4, 75));
        
        #endregion

        #region ��ʽ
        //private PanelStationHeadInfoStyle m_PanelStationHeadInfoStyle = PanelStationHeadInfoStyle.NormalMode;
        #endregion

        #endregion

        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public PanelStationInfo():base()
        {
           // base.Paint += new PaintEventHandler(PanelStationHeadInfo_Paint);
            this.SetLabelPanelStyle = LabelPanelStyle.FillGradual;
            this.Paint += new PaintEventHandler(PanelStationHeadInfo_Paint);
           // this.MouseEnter += new System.EventHandler(PanelStationHeadInfo_MouseEnter);
        }
        #endregion

        #region ���� 
        #region ��ʾ����
        /// <summary>
        /// 
        /// </summary>
        [Category("��ʾ����"), Description("��վ����ı�")]
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
        /// 
        /// </summary>
        [Category("��ʾ����"), Description("��վ���ֵ")]
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
            set { m_ValueStationHeadPlace = value; this.Refresh(); }
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
            m_FieldStationAddress.Location = new PointF(4, 25);
            m_ValueStationAddress.Location = new PointF(67, 25);
            DrawString(e.Graphics, m_FieldStationAddress);
            DrawString(e.Graphics, m_ValueStationAddress);
            DrawString(e.Graphics, m_ValueStationHeadPlace);
            DrawString(e.Graphics, m_ValueEnterTotalPerson);
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PanelStationHeadInfo
            // 
            this.Name = "PanelStationHeadInfo";
            this.Size = new System.Drawing.Size(150, 101);
            this.ResumeLayout(false);
        }
    }
}