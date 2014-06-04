using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
namespace KJ128WindowsLibrary
{
    ///// <summary>
    ///// 信息的样式
    ///// </summary>
    //public enum PanelStationHeadInfoStyle
    //{
    //    /// <summary>
    //    /// 正常模式
    //    /// </summary>
    //    NormalMode,
    //    /// <summary>
    //    /// 鼠标移动过去的模式
    //    /// </summary>
    //    MouseMoveMode
    //}
    /// <summary>
    /// 显示接收器号的信息的面板
    /// </summary>
    public class PanelStationInfo:LabelPanel
    {

        #region 私有变量
             
        #region 显示的内容

        private LabelInfo m_FieldStationAddress = new LabelInfo("");
        private LabelInfo m_ValueStationAddress = new LabelInfo("");
        private LabelInfo m_ValueEnterTotalPerson = new LabelInfo("进入总人数", new PointF(4,50));
        private LabelInfo m_ValueStationHeadPlace = new LabelInfo("安装位置安装位置安装位置安装位置", new PointF(4, 75));
        
        #endregion

        #region 样式
        //private PanelStationHeadInfoStyle m_PanelStationHeadInfoStyle = PanelStationHeadInfoStyle.NormalMode;
        #endregion

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public PanelStationInfo():base()
        {
           // base.Paint += new PaintEventHandler(PanelStationHeadInfo_Paint);
            this.SetLabelPanelStyle = LabelPanelStyle.FillGradual;
            this.Paint += new PaintEventHandler(PanelStationHeadInfo_Paint);
           // this.MouseEnter += new System.EventHandler(PanelStationHeadInfo_MouseEnter);
        }
        #endregion

        #region 属性 
        #region 显示内容
        /// <summary>
        /// 
        /// </summary>
        [Category("显示内容"), Description("分站编号文本")]
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
        [Category("显示内容"), Description("分站编号值")]
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
        /// 进入总人数
        /// </summary>
        [Category("显示内容"), Description("进入总人数")]
        public LabelInfo ValueEnterTotalPerson
        {
            get { return m_ValueEnterTotalPerson; }
            set { m_ValueEnterTotalPerson = value; this.Refresh(); }
        }
        /// <summary>
        /// 接收器安装位置
        /// </summary>
        [Category("显示内容"), Description("接收器安装位置")]
        public LabelInfo ValueStationHeadPlace
        {
            get { return m_ValueStationHeadPlace; }
            set { m_ValueStationHeadPlace = value; this.Refresh(); }
        }
        #endregion
        #endregion

        #region 方法
        void DrawString(Graphics g,LabelInfo lblInfo)
        {
            g.DrawString(lblInfo.FieldName,lblInfo.FieldFont,new SolidBrush(lblInfo.FieldColor),lblInfo.Location);
        }
        
        #endregion

        #region 事件

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