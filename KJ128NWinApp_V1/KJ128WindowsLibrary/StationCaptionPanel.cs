using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace KJ128WindowsLibrary
{

    /// <summary>
    /// 在主界面显示的分站信息
    /// </summary>
    public class StationCaptionPanel:CaptionPanel
    {
        private bool m_IsShrink = false;//是否收缩
        #region LabelStationInfo

        private bool m_IsShowLabelStationInfo = true;
        private Label m_LabelStationInfo = new Label();
        private bool m_IsLabelStationInfoAlarm = false;
        private int m_LabelStationInfoLeft = 0;
        private int m_LabelStatonInfoWidth = 300;
        private string m_LabelStationInfoText = "10101主巷道上巷头右拐口,监测到120人";
        private Color m_LabelStationInfoForeColor = Color.Wheat;
        //private Color m_LabelStationInfoForeColor = Color.FromArgb(255, 255, 255);
        private Font m_LabelStationInfoFont = new Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
       /// <summary>
       /// 文本对齐方式
       /// </summary>
        private ContentAlignment m_LabelStationInfoTextAlign = ContentAlignment.MiddleLeft;
        
        #endregion

        #region LabelFunctionInfo

 

        #endregion

        #region FunctionButton

        private CaptionPanelStyleEnum m_FunctionButtonStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;

        #region 编辑分站

        private bool m_IsShowEditStationInfo = true;
        private bool m_IsShowAddNewStationHeadInfo = true;
       /// <summary>t
       /// 是否显示删除分站按钮
       /// </summary>
        private bool m_IsShowDeleteStationInfo = true;
        /// <summary>
        /// 编辑分站
        /// </summary>
        private ButtonCaptionPanel  m_EditStationInfo=new ButtonCaptionPanel();
        private int m_EditStationInfoWidth = 100;//76;
        private string m_EditStationInfoText = "编辑传输分站";

        /// <summary>
        /// 功能按钮相对于应右边界的距离
        /// </summary>
        private int m_FunctionButtonRightInterval = 1;
       
        
        #endregion

        #region 添加接收器
        /// <summary>
        /// 添加接收器
        /// </summary>
        private ButtonCaptionPanel m_AddNewStationHeadInfo = new ButtonCaptionPanel();
        private int m_AddNewStationHeadInfoWidth = 100;//86;
        private string m_AddNewStationHeadInfoText = "添加读卡分站";
        #endregion

        #region 删除分站
        /// <summary>
        /// 删除分站
        /// </summary>
        private ButtonCaptionPanel m_DeleteStationButton=new ButtonCaptionPanel();
        private int m_DeleteStationButtonWidth = 100;//76;
        private string m_DeleteStationButtonText="删除传输分站";
        
        #endregion

        #endregion

        #region 定义事件
        /// <summary>
        /// 提供删除分站按钮事件
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Category("自定义事件"), Description("单击删除分站按钮")]
        public event EventHandler DeleteStationInfoClick
        {
            add
            {
                m_DeleteStationButton.Click += value;
            }
            remove
            {
                m_DeleteStationButton.Click -= value;
            }
        }

        /// <summary>
        /// 提供单击添加接收器按钮事件
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Category("自定义事件"), Description("单击添加接收器按钮")]
        public event EventHandler AddNewStationHeadInfo
        {
            add
            {
                m_AddNewStationHeadInfo.Click += value;
            }
            remove
            {
                m_AddNewStationHeadInfo.Click -= value;
            }
        }
        /// <summary>
        /// 提供单击编辑分站按钮事件
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Category("自定义事件"), Description("单击编辑分站按钮")]
        public event EventHandler EditStationInfo
        {
            add
            {
                m_EditStationInfo.Click += value;
            }
            remove
            {
                m_EditStationInfo.Click -= value;
            }
        }

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public StationCaptionPanel():base()
        {
            this.IsOnlyCaption = true;
            this.IsUserButtonClose = true;
            this.IsUserSystemCloseButtonLeft = false;
            this.CaptionCloseButtonTitle = "-";
            InitialzeAdditionalInfo();
            InitEditStationInfo();
            InitAddNewStationHeadInfo();
            InitDeleteStationButton();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isShrink">是否收缩，true 收缩，false 不收缩</param>
        public StationCaptionPanel(bool isShrink)
            : this()
        {
            if (m_IsShrink)
            {
                this.CaptionCloseButtonTitle = "+";
            }
            else
            {
                this.CaptionCloseButtonTitle = "-";
            }
        }
        #endregion

        #region 属性

        #region 删除分站按钮
        /// <summary>
        /// 是否显示删除分站按钮
        /// </summary>
        [Category("功能按钮属性"), Description("是否显示删除分站按钮")]
        public bool IsShowDeleteStationInfo
        {
            get
            {
                return m_IsShowDeleteStationInfo;
            }
            set
            {
                m_IsShowDeleteStationInfo = value;
                m_DeleteStationButton.Visible = value;
            }
        }
        /// <summary>
        /// 删除分站按钮宽度
        /// </summary>
        [Category("分站标题属性"),Description("删除分站按钮宽度")]
        public int DeleteStationButtonWidth
        {
            get
            {
                return m_DeleteStationButtonWidth;
            }
            set
            {
                m_DeleteStationButtonWidth=value;
            }
        }
        /// <summary>
        /// 删除分站按钮文本
        /// </summary>
        [Category("分站标题属性"),Description("删除分站按钮文本")]
        public string DeleteStationButtonText
        {
            get
            {
                return m_DeleteStationButtonText;
            }
            set
            {
                m_DeleteStationButtonText=value;
            }
        }
#endregion

        #region 编辑分站

       
         /// <summary>
        /// 是否显示编辑分站按钮
        /// </summary>
        [Category("功能按钮属性"), Description("是否显示编辑分站按钮")]
        public bool IsShowEditStationInfo
        {
            get
            {
                return m_IsShowEditStationInfo;
            }
            set
            {
                m_IsShowEditStationInfo = value;
                m_EditStationInfo.Visible = value;
            }
        }
        /// <summary>
        /// 编辑按钮的文本
        /// </summary>
        [Category("功能按钮属性"), Description("编辑按钮的文本")]
        public string EditStationInfoText
        {
            get
            {
                return m_EditStationInfoText;
            }
            set
            {
                m_EditStationInfoText = value; 
            }
        }
        /// <summary>
        /// 编辑按钮的宽度
        /// </summary>
        [Category("功能按钮属性"), Description("编辑按钮的宽度")]
        public int EditStationInfoWidth
        {
            get
            {
                return m_EditStationInfoWidth;
            }
            set
            {
                m_EditStationInfoWidth = value;
            }
        }
        #endregion

        #region 添加接收器
        /// <summary>
        /// 是否显示添加接收器按钮
        /// </summary>
        [Category("功能按钮属性"), Description("是否显示添加接收器按钮")]
        public bool IsShowAddNewStationHeadInfo
        {
            get
            {
                return m_IsShowAddNewStationHeadInfo;
            }
            set
            {
                m_IsShowAddNewStationHeadInfo = value;
                m_AddNewStationHeadInfo.Visible = value;
            }
        }

        /// <summary>
        /// 添加接收器的宽度
        /// </summary>
        [Category("功能按钮属性"), Description("添加接收器的宽度")]
        public int AddNewStationHeadInfoWidth
        {
            get
            {
                return m_AddNewStationHeadInfoWidth;
            }
            set
            {
                m_AddNewStationHeadInfoWidth = value;
            }
        }

       /// <summary>
        /// 添加接收器的文本
        /// </summary>
        [Category("功能按钮属性"), Description("添加接收器的文本")]
        public string AddNewStationHeadInfoText
        {
            get
            {
                return m_AddNewStationHeadInfoText;
            }
            set
            {
                m_AddNewStationHeadInfoText = value;
            }
        }
        #endregion

        #region LabelStationInfo
        /// <summary>
        /// 显示附加信息的左边界
        /// </summary>
        [Category("附加的内容"), Description("显示附加信息的左边界")]
        public int LabelStationInfoLeft
        {
            get
            {
                return m_LabelStationInfoLeft;
            }
            set
            {
                m_LabelStationInfoLeft = value;
                m_LabelStationInfo.Left = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 文本对齐方式
        /// </summary>
        [Category("附加的内容"), Description("显示附加信息的文本对齐方式")]
        public ContentAlignment LabelStationInfoTextAlign
        {
            get 
            {
                return m_LabelStationInfoTextAlign; 
            }
            set 
            {
                m_LabelStationInfoTextAlign = value;
                m_LabelStationInfo.TextAlign = value;
             }
        }
        
        /// <summary>
        /// 显示附加信息的宽度
        /// </summary>
        [Category("附加的内容"), Description("显示附加信息的宽度")]
        public int LabelStatonInfoWidth
        {
            get
            {
                return m_LabelStatonInfoWidth;
            }
            set
            {
                m_LabelStatonInfoWidth = value;
                this.Refresh();
            }
        }
        
        /// <summary>
        /// 是否显示附加功能
        /// </summary>
        [Category("附加的内容"), Description("是否显示附加信息")]
        public bool IsShowLabelStationInfo
        {
            get
            {
                return m_IsShowLabelStationInfo;
            }
            set
            {
                m_IsShowLabelStationInfo = value;
                m_LabelStationInfo.Visible = m_IsShowLabelStationInfo;
            }
        }
        /// <summary>
        ///附加内容的文本
        /// </summary>
        public string LabelStationInfoText
        {
            get { return m_LabelStationInfoText; }
            set { m_LabelStationInfoText = value;  
                m_LabelStationInfo.Text=value;
            this.Refresh();
        }
        }
        /// <summary>
        /// 是否可以手动更改颜色或字体
        /// </summary>
        public bool IsLabelStationInfoAlarm
        {
            get { return m_IsLabelStationInfoAlarm; }
            set { m_IsLabelStationInfoAlarm = value; this.Refresh(); }
        }
        /// <summary>
        /// 附加内容的背景色
        /// </summary>
        public Color LabelStationInfoForeColor
        {
            get { return m_LabelStationInfoForeColor;  }
            set { m_LabelStationInfoForeColor = value; this.Refresh(); }
        }
        #endregion

        /// <summary>
        /// 是否收缩显示
        /// </summary>
        [Category("分站标题属性"),Description("是否收缩显示")]
        public  bool IsShrink
        {
            get
            {
                return m_IsShrink;
            }
            set
            {
                m_IsShrink = value;
                if (m_IsShrink)
                {
                    this.CaptionCloseButtonTitle = "+";
                }
                else
                {
                    this.CaptionCloseButtonTitle = "-";
                }
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化信息_增加一个信息Label
        /// </summary>
        private void InitialzeAdditionalInfo()
        {
             m_LabelStationInfoLeft = CaptionTitleLeft +130;
             
            m_LabelStationInfoFont=this.CaptionFont;
            m_LabelStationInfoForeColor = this.CaptionForeColor;
            m_LabelStationInfo.Location = new Point(m_LabelStationInfoLeft,this.CloseButtonTop);
            m_LabelStationInfo.Size = new Size(m_LabelStatonInfoWidth, this.CloseButtonHeight);
           
            m_LabelStationInfo.Text = m_LabelStationInfoText;
            m_LabelStationInfo.Font=m_LabelStationInfoFont;
            m_LabelStationInfo.ForeColor = m_LabelStationInfoForeColor;
            m_LabelStationInfo.TextAlign = m_LabelStationInfoTextAlign; // 文本对齐方式
            
            m_LabelStationInfo.Paint+=new PaintEventHandler(m_LabelStationInfo_Paint);
          
            this.Controls.Add(m_LabelStationInfo);
        }
        /// <summary>
        /// 删除分站按钮
        /// </summary>
        private void InitDeleteStationButton()
        {
            m_DeleteStationButton.CaptionFont = this.CaptionFont;
            m_DeleteStationButton.CaptionForeColor = this.CaptionForeColor;

            m_DeleteStationButton.Size = new Size(m_DeleteStationButtonWidth, this.CloseButtonHeight);
            
            m_DeleteStationButton.CaptionHeight = this.CloseButtonHeight - 4;

            m_DeleteStationButton.CaptionTitle = m_DeleteStationButtonText;
            m_DeleteStationButton.SetCaptionPanelStyle = m_FunctionButtonStyle;
            m_DeleteStationButton.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;
            m_DeleteStationButton.Left = this.CloseButtonTop + 1;
          

            this.Controls.Add(m_DeleteStationButton);
        }
        /// <summary>
        /// 编辑分站按钮
        /// </summary>
        private void InitEditStationInfo()
        {
            m_EditStationInfo.CaptionFont = this.CaptionFont;
            m_EditStationInfo.CaptionForeColor = this.CaptionForeColor;
           
            m_EditStationInfo.Size = new Size(m_EditStationInfoWidth, this.CloseButtonHeight);
            m_EditStationInfo.CaptionHeight = this.CloseButtonHeight-4;
            m_EditStationInfo.CaptionTitle = m_EditStationInfoText;
            m_EditStationInfo.SetCaptionPanelStyle = m_FunctionButtonStyle;
            m_EditStationInfo.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;
            m_EditStationInfo.Left = this.CloseButtonTop + 1;           
            this.Controls.Add(m_EditStationInfo);
        }
        /// <summary>
        /// 初始化新增接收器按钮
        /// </summary>
        private void InitAddNewStationHeadInfo()
        {
            m_AddNewStationHeadInfo.CaptionFont = this.CaptionFont;
            m_AddNewStationHeadInfo.CaptionForeColor = this.CaptionForeColor;

            m_AddNewStationHeadInfo.Size = new Size(m_AddNewStationHeadInfoWidth,this.CloseButtonHeight);
            m_AddNewStationHeadInfo.CaptionHeight = this.CloseButtonHeight - 4;
            m_AddNewStationHeadInfo.CaptionTitle = m_AddNewStationHeadInfoText;

            m_AddNewStationHeadInfo.SetCaptionPanelStyle = m_FunctionButtonStyle;
            m_AddNewStationHeadInfo.SetButtonStyle = ButtonCaptionPanelButtonStyle.Office2003Style;
            m_AddNewStationHeadInfo.Left = this.CloseButtonTop + 1;

            this.Controls.Add(m_AddNewStationHeadInfo);
            
        }
        /// <summary>
        /// 尺寸改变时
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            int int_left = this.Width - m_FunctionButtonRightInterval - m_DeleteStationButtonWidth;
            m_DeleteStationButton.Location = new Point(int_left, this.CloseButtonTop + 1);

            int_left = int_left - m_FunctionButtonRightInterval - m_EditStationInfoWidth;
            m_EditStationInfo.Location = new Point(int_left, this.CloseButtonTop + 1);
            

            int_left =int_left - m_FunctionButtonRightInterval - m_AddNewStationHeadInfoWidth;

            m_AddNewStationHeadInfo.Location = new Point(int_left, this.CloseButtonTop + 1);
         
        }
        /// <summary>
        /// 绘制附加信息
        /// </summary>
        /// <param name="g"></param>
        /// <param name="lbl1"></param>
        private void  DrawAdditionalInfo(Graphics g,Label lbl1)
        {
            Rectangle rect = new Rectangle(lbl1.Location, lbl1.Size);
            if (!this.IsCaptionSingleColor)//启用渐变
            {
                LinearGradientBrush lgb = new LinearGradientBrush(rect, this.CaptionBackColor1, this.CaptionBackColor2, this.CaptionPanelLineMode);
                g.FillRectangle(lgb, rect);
            }
            else
            {
                lbl1.BackColor = this.CaptionBackColor;
            }
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // StationCaptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "StationCaptionPanel";
            this.Size = new System.Drawing.Size(150, 25);
            this.ResumeLayout(false);

        }
        #region 事件
        
      /// <summary>
      /// 重绘附加信息时
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        void m_LabelStationInfo_Paint(object sender, PaintEventArgs e)
        {
            DrawAdditionalInfo(e.Graphics, m_LabelStationInfo);
        }
         #endregion
#region 垃圾
        /*
        void StationCaptionPanel_Paint(object sender, PaintEventArgs e)
        {
            UpadteAdditianInfo();
        }
        *  /// <summary>
        /// 重绘时的_更新附加信息
        /// </summary>
        private void UpadteAdditianInfo()
        {
            m_LabelStationInfoForeColor = CaptionForeColor;
            m_LabelStationInfo.ForeColor = m_LabelStationInfoForeColor;
            m_LabelStationInfoFont = CaptionFont;
            m_LabelStationInfo.Font = m_LabelStationInfoFont;
        }
         * 
         * 
         *  /// <summary>
        /// 鼠标进入
        /// </summary>
        protected virtual void MouseEnterHander()
        {
           this.SetCaptionPanelStyle = CaptionPanelStyleEnum.Office2007Panel;
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        protected virtual void MouseLeaveHander()
        {
            this.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaption;
        }
        */
#endregion
    }
}
