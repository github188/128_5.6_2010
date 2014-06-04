using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;


namespace KJ128WindowsLibrary
{
    #region class:StationMakeupVspanel
    /// <summary>
    /// 组合分站与接收器的信息的面板，可实现自由缩放
    /// </summary>
    public class StationMakeupVspanel:VSPanel
    {
        #region 私有变量
            private StationCaptionPanel m_StationCaptionPanel = new StationCaptionPanel();
            private bool m_AllowMaxHeight = false;
            private int m_MaxHeight =22;
            private int m_StationAddress = 1;

       
        #endregion
        
        #region 事件定义
        /// <summary>
        /// 用户鼠标单击收缩按钮，引发的事件
        /// </summary>
        public event EventHandler ShiftButtonMouseClick;
        /// <summary>
        /// 单击删除分站按钮
        /// </summary>
        [Category("自定义事件"), Description("单击删除分站按钮")]
        public event EventHandler ClickDeleteStationButton
        {
            add
            {
                m_StationCaptionPanel.DeleteStationInfoClick += value;
            }
            remove
            {
                m_StationCaptionPanel.DeleteStationInfoClick -= value;
            }
        }
        /// <summary>
        /// 单击编辑分站按钮
        /// </summary>
        [Category("自定义事件"), Description("单击编辑分站按钮")]
        public event EventHandler ClickEditStationButton
        {
            add
            {
                m_StationCaptionPanel.EditStationInfo += value;
            }
            remove
            {
                m_StationCaptionPanel.EditStationInfo -= value;
            }
        }
        /// <summary>
        /// 单击添加接收器按钮
        /// </summary>
        [Category("自定义事件"), Description("单击添加接收器按钮")]
        public event EventHandler ClickAddStationHead
        {
            add
            {
                m_StationCaptionPanel.AddNewStationHeadInfo += value;
            }
            remove
            {
                m_StationCaptionPanel.AddNewStationHeadInfo -= value;
            }
        }

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public StationMakeupVspanel():base()
        {
            IniComponent();

            //2008-4-30 新加
            //m_StationCaptionPanel.BackColor = Color.FromArgb(255,255,255);
            m_StationCaptionPanel.SetCaptionPanelStyle = CaptionPanelStyleEnum.None;
            
        }
        #endregion

        #region 属性

        /// <summary>
        /// 是否收缩显示
        /// </summary>
        [Category("扩展的属性"), Description("是否收缩显示")]
        public bool IsShrink
        {
            get
            {
                return m_StationCaptionPanel.IsShrink;
            }
            set
            {
                m_StationCaptionPanel.IsShrink = value;
                AutoComputeControlHeight();

               

            }
        }
        #region 控件本身
        
        #endregion
        #region 标题按钮功能

        #region 删除分站按钮
        /// <summary>
        /// 是否显示删除分站按钮
        /// </summary>
        [Category("功能按钮属性"), Description("是否显示删除分站按钮")]
        public bool IsShowDeleteStationInfo
        {
            get
            {
                return m_StationCaptionPanel.IsShowDeleteStationInfo;
            }
            set
            {
                m_StationCaptionPanel.IsShowDeleteStationInfo = value;
            }
        }
        /// <summary>
        /// 删除分站按钮宽度
        /// </summary>
        [Category("分站标题属性"), Description("删除分站按钮宽度")]
        public int DeleteStationButtonWidth
        {
            get
            {
                return m_StationCaptionPanel.DeleteStationButtonWidth;
            }
            set
            {
                m_StationCaptionPanel.DeleteStationButtonWidth = value;
            }
        }
        /// <summary>
        /// 删除分站按钮文本
        /// </summary>
        [Category("分站标题属性"), Description("删除分站按钮文本")]
        public string DeleteStationButtonText
        {
            get
            {
                return m_StationCaptionPanel.DeleteStationButtonText;
            }
            set
            {
                m_StationCaptionPanel.DeleteStationButtonText = value;
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
                return m_StationCaptionPanel.IsShowEditStationInfo;
            }
            set
            {
                m_StationCaptionPanel.IsShowEditStationInfo = value;
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
                return m_StationCaptionPanel.EditStationInfoText;
            }
            set
            {
                m_StationCaptionPanel.EditStationInfoText = value;
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
                return m_StationCaptionPanel.EditStationInfoWidth;
            }
            set
            {
                m_StationCaptionPanel.EditStationInfoWidth = value;
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
                return m_StationCaptionPanel.IsShowAddNewStationHeadInfo;
            }
            set
            {
                m_StationCaptionPanel.IsShowAddNewStationHeadInfo = value;
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
                return m_StationCaptionPanel.AddNewStationHeadInfoWidth;
            }
            set
            {
                m_StationCaptionPanel.AddNewStationHeadInfoWidth = value;
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
                return m_StationCaptionPanel.AddNewStationHeadInfoText;
            }
            set
            {
                m_StationCaptionPanel.AddNewStationHeadInfoText = value;
            }
        }
        #endregion
        #endregion
        #region 附加的内容
        /// <summary>
        /// 显示附加信息的左边界
        /// </summary>
        [Category("附加的内容"), Description("显示附加信息的左边界")]
        public int LabelStationInfoLeft
        {
            get
            {
                return m_StationCaptionPanel.LabelStationInfoLeft;
            }
            set
            {
                m_StationCaptionPanel.LabelStationInfoLeft = value;
                this.Refresh();
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
                return m_StationCaptionPanel.LabelStatonInfoWidth;
            }
            set
            {
                m_StationCaptionPanel.LabelStatonInfoWidth = value;
                this.Refresh();
            }
        }
   
        /// <summary>
        /// 获取面板标题控件
        /// </summary>
        public StationCaptionPanel CaptionTitleControl
        {
            get
            {
                return m_StationCaptionPanel;
            }
        }
        /// <summary>
        ///附加内容的文本
        /// </summary>
        public string LabelStationInfoText
        {
            get { return m_StationCaptionPanel.LabelStationInfoText; }
            set { m_StationCaptionPanel.LabelStationInfoText = value; }
        }
        /// <summary>
        /// 是否可以手动更改颜色或字体
        /// </summary>
        public bool IsLabelStationInfoAlarm
        {
            get { return m_StationCaptionPanel.IsLabelStationInfoAlarm; }
            set { m_StationCaptionPanel.IsLabelStationInfoAlarm = value; }
        }
        /// <summary>
        /// 附加内容的背景色
        /// </summary>
        public Color LabelStationInfoForeColor
        {
            get { return m_StationCaptionPanel.LabelStationInfoForeColor; }
            set { m_StationCaptionPanel.LabelStationInfoForeColor = value; }
        }
        #endregion
        #region 扩展属性
        /// <summary>
        /// 控件的标题文本
        /// </summary>
        [Category("扩展的属性"), Description("控件的标题文本")]
        public string CaptionTitle
        {
            get { return m_StationCaptionPanel.CaptionTitle; }
            set { m_StationCaptionPanel.CaptionTitle = value; }
        }
        /// <summary>
        /// 返回标题控件
        /// </summary>
        public StationCaptionPanel StationCaptionControl
        {
            get { return m_StationCaptionPanel; }
            set { m_StationCaptionPanel = value; }
        }
        /// <summary>
        /// 是否允许设置缩放的最大值
        /// </summary>
        [Category("扩展的属性"), Description("是否允许设置缩放的最大值")]
        public bool AllowMaxHeight
        {
            get
            {
                return m_AllowMaxHeight;
            }
            set
            {
                m_AllowMaxHeight = value;
            }
        }
        /// <summary>
        /// 最大值高度，需要设置AllowMaxHeight=true;
        /// </summary>
        [Category("扩展的属性"), Description("最大值高度，需要设置AllowMaxHeight=true")]
        public int MaxHeight
        {
            get
            {
                return m_MaxHeight;
            }
            set
            {
               m_MaxHeight = value;
               if (m_MaxHeight < 1)
               {
                   m_MaxHeight = 1;
               }
            }
        }
        /// <summary>
        /// 一个标题的实例
        /// </summary>
        [Category("扩展的属性"), Description("获取或设置一个新的标题面板")]
        public StationCaptionPanel StationCaptionPanel
        {
            get
            {
                return m_StationCaptionPanel;
            }
            set
            {
                m_StationCaptionPanel = value;
            }
        }
        
        /// <summary>
        /// 是否显示附加功能
        /// </summary>
        [Category("附加的内容"), Description("是否显示附加功能")]
        public bool IsShowLabelStationInfo
        {
            get
            {
                return m_StationCaptionPanel.IsShowLabelStationInfo ;
            }
            set
            {
                m_StationCaptionPanel.IsShowLabelStationInfo = value;
            }
        }
        /// <summary>
        /// 特殊标记,表示唯一索引，用于分站遍历，表示分站编号
        /// </summary>
        [Category("特殊标记"), Description("表示唯一索引，用于分站遍历，KJ128N中表示分站编号")]
        public int StationAddress
        {
            get
            {
                return m_StationAddress;
            }
            set
            {
                m_StationAddress = value;
            }
        }
        #endregion
        #endregion

        #region 方法
       
        /// <summary>
        /// 向标题组件增加一个新的组件
        /// </summary>
        /// <param name="c">组件</param>
        public void AddStationCaptionPanel(Control c)
        {
            m_StationCaptionPanel.Controls.Add(c);
        }
        #region 初始化控件
        /// <summary>
        /// 初始控件
        /// </summary>
        private void IniComponent()
        {
            //  m_StationCaptionPanel
            m_StationCaptionPanel.Dock = DockStyle.Top;
            m_StationCaptionPanel.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaption;//默认样式
            m_StationCaptionPanel.IsShrink = true;
            m_StationCaptionPanel.Height =m_StationCaptionPanel.CaptionHeight+10;
            
            this.Controls.Add(m_StationCaptionPanel);
            ComputeHeight(false);
            m_StationCaptionPanel.CloseButtonClick += new EventHandler(m_StationCaptionPanel_CloseButtonClick);
        }
        #endregion
        /// <summary>
        /// 放置类型的处理,在VSPanel_ControlAdded(object sender, ControlEventArgs e)中处理
        /// </summary>
        /// <param name="e">对象</param>
        protected override void LayoutTypeHander(ControlEventArgs e)
        {
            base.LayoutTypeHander(e);
            if (!IsDragModel)
            {
                ComputeHeight(false);
            }
        }
        /// <summary>
        /// 自动根据控件内的子控件计算控件本身的高度
        /// </summary>
        public void AutoComputeControlHeight()
        {
           
            if (this.Controls.Count > 0)
            {

                switch (this.LayoutType)
                {
                    case VSPanelLayoutType.FreeLayoutType: //如果自由放置模式，则计算最大的底
                        {
                            int int_temHeight = ComputeChildControlHeight();
                            #region 有没有收缩

                            if (m_StationCaptionPanel.IsShrink) //有没有收缩啊
                            {
                                if (m_AllowMaxHeight)
                                {
                                    this.Height = m_MaxHeight;
                                }
                                else
                                {
                                    this.Height = m_StationCaptionPanel.Top + m_StationCaptionPanel.Height;
                                }
                            }
                            else
                            {
                              
                                    if (m_AllowMaxHeight)
                                    {
                                        this.Height = m_MaxHeight;
                                    }
                                    else
                                    {
                                        this.Height = int_temHeight + this.HorizontalInterval;
                                    }
                                
                            }

                            #endregion
                            break;
                        }
                    default :
                        {
                            int int_ControlCount = this.Controls.Count;
                            Control control_End = this.Controls[int_ControlCount - 1];
                            #region 有没有收缩

                            if (m_StationCaptionPanel.IsShrink) //有没有收缩啊
                            {
                                if (m_AllowMaxHeight)
                                {
                                    this.Height = m_MaxHeight;
                                }
                                else
                                {
                                    this.Height = m_StationCaptionPanel.Top + m_StationCaptionPanel.Height;
                                }
                            }
                            else
                            {
                                if (this.Controls.Count > 1)
                                {
                                    if (m_AllowMaxHeight)
                                    {
                                        this.Height = m_MaxHeight;
                                    }
                                    else
                                    {
                                        this.Height = control_End.Top + control_End.Height + this.HorizontalInterval;
                                    }
                                }
                            }

                            #endregion
                            break;
                        }
                }
            }
        }
      /// <summary>
      /// 获取子控件的高度
      /// </summary>
      /// <returns>Bottom底值最大</returns>
        private int ComputeChildControlHeight()
        {
          int int_BottomHeight = 0;
         
          foreach(Control c in this.Controls)
          {
              int int_temBottom = c.Bottom;
              if(int_BottomHeight<int_temBottom)
              {
                  int_BottomHeight = int_temBottom;
              }
          }
          return int_BottomHeight;
        }
         /// <summary>
         /// 计算高度
         /// </summary>
         /// <param name="isChange">是否需要更改状态</param>
           void ComputeHeight(bool isChange)
        {
            
            
            if (isChange)//改变状态
            {
                m_StationCaptionPanel.IsShrink = !m_StationCaptionPanel.IsShrink;
            }
             AutoComputeControlHeight();
            
            

        }
        /// <summary>
        ///　当尺寸改变时
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if(m_StationCaptionPanel.IsShrink)
            {
                AutoComputeControlHeight();
            }
        }

        #endregion

        #region 事件
 
        void m_StationCaptionPanel_CloseButtonClick(object sender, EventArgs e)
        {
            ComputeHeight(true);
            this.Refresh();
            ShiftButtonMouseClick(sender,e);//反馈给用户的事件,引发
        }
        #endregion
    }
    #endregion

}
