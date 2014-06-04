using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DegonControlLib
{
    struct PanelInfo
    {
        /// <summary>
        /// 面板
        /// </summary>
        public Control s_panel;
        /// <summary>
        /// 展开状态
        /// </summary>
        public bool blPartState;
    }

    public enum PartType
    {
        Time=0,
        Cleft,
    }

    public partial class DrawerMainControl : Panel
    {
        /// <summary>
        /// 面板列表
        /// </summary>
        private ArrayList alPanel = new ArrayList();
        /// <summary>
        /// 菜单运行状态
        /// </summary>
        private bool stretchFlag = true;

        #region 【自定义属性】
        #region 【属性：抽屉间隔距离】
        /// <summary>
        /// 表示抽屉间的间隔距离。
        /// </summary>
        private int _splitHeight = 1;
        /// <summary>
        /// 设置或获取抽屉菜单间的间隔距离（数值不能小于0，小于0的数默认为0）
        /// </summary>
        public int SplitHeight
        {
            get { return _splitHeight; }
            set
            {
                if (value < 0)
                {
                    _splitHeight = 0;
                }
                else
                {
                    _splitHeight = value;
                }
            }
        }
        #endregion 【属性：抽屉间隔距离】

        #region 【属性：标题高度】
        /// <summary>
        /// 标题高度
        /// </summary>
        private int _titleHeight = 30;
        /// <summary>
        /// 设置或获取抽屉菜单的标题高度(数值不能小于1，小于1的数默认为10)
        /// </summary>
        public int TitleHeight
        {
            get { return _titleHeight; }
            set
            {
                if (value < 1)
                {
                    _titleHeight = 10;
                }
                else
                {
                    _titleHeight = value;
                }
            }
        }
        #endregion 【属性：标题高度】

        #region 【属性：总面板高度】
        /// <summary>
        /// 面板的高度
        /// </summary>
        private int _mainHeight = 100;
        /// <summary>
        /// 获取或设置总面板的高度
        /// </summary>
        public int MainHeight
        {
            get { return _mainHeight; }
            set
            {
                if (value < 1)
                {
                    _mainHeight = 50;
                }
                else
                {
                    _mainHeight = value;
                }
            }
        }
        #endregion 【属性：总面板高度】

        #region 【属性：面板展开和合并速度】
        /// <summary>
        /// 展开和合并速度
        /// </summary>
        private int _partTime = 1;
        /// <summary>
        /// 设置或获取展开和合并速度
        /// </summary>
        public int PartTime
        {
            get { return _partTime; }
            set
            {
                if (value < 1)
                {
                    _partTime = 1;
                }
                else
                {
                    _partTime = value;
                }
            }
        }
        #endregion 【属性：面板展开和合并速度】

        #region 【属性：面板打开方式】
        private PartType _partType = PartType.Time;
        /// <summary>
        /// 获取或设置面板打开方式
        /// </summary>
        public PartType PType
        {
            get { return _partType; }
            set { _partType = value; }
        }
        #endregion

        #endregion 【自定义属性】

        public DrawerMainControl()
        {
            InitializeComponent();
            
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// 清除所有容器
        /// </summary>
        public void ControlsClean()
        {
            this.Controls.Clear();
            alPanel.Clear();
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            PartResize();
        }

        private void PartResize()
        {
            if (alPanel.Count <= 0)
            {
                return;
            }
            _mainHeight = this.Height - (_titleHeight + _splitHeight) * (alPanel.Count - 1);
            for (int i = 0; i < alPanel.Count; i++)
            {
                PanelInfo panelInfo1 = (PanelInfo)alPanel[i];
                //if (this.Width > 20)
                //{
                //    panelInfo1.s_panel.Width = this.Width - 20;
                //}
                //else
                //{
                //    panelInfo1.s_panel.Width = 0;
                //}

                panelInfo1.s_panel.Width = this.Width - 2;

                if (panelInfo1.blPartState)
                {
                    panelInfo1.s_panel.Height = _mainHeight;
                }
                else
                {
                    panelInfo1.s_panel.Height = _titleHeight;
                }
                if (i==0)
                {
                    panelInfo1.s_panel.Top = 0;
                }
                else if (i > 0)
                {
                    PanelInfo panelInfo = (PanelInfo)alPanel[i - 1];
                    panelInfo1.s_panel.Top =panelInfo.s_panel.Top + panelInfo.s_panel.Height + _splitHeight;
                }
            }
        }

        /// <summary>
        /// 添加面板
        /// </summary>
        /// <param name="control">面板</param>
        /// <param name="partState">合并或展开状态 true 展开 false 合并</param>
        public void Add(Control control, bool partState)
        {
            this.SuspendLayout();
            PanelInfo stcPanelInfo = new PanelInfo();
            stcPanelInfo.s_panel = control;
            control.Width = this.Width - 2;
            //control.Width = this.Width - 20;
            control.Height = _titleHeight;
            this.Controls.Add(control);
            this.ResumeLayout(false);
            stcPanelInfo.blPartState = partState;
            alPanel.Add(stcPanelInfo);
        }

        /// <summary>
        /// 添加面板(默认合并)
        /// </summary>
        /// <param name="control">面板</param>
        public void Add(Control control)
        {
            Add(control, false);
        }

        /// <summary>
        /// 面板展开
        /// </summary>
        /// <param name="name">容器名称</param>
        public bool ButtonClick(string name)
        {
            if (stretchFlag)
            {
                bool flag = false;
                PanelInfo u3 = new PanelInfo();
                int j = 0;
                for (int i = 0; i < alPanel.Count; i++)
                {
                    PanelInfo u2 = (PanelInfo)alPanel[i];
                    if (name.Equals(u2.s_panel.Name))
                    {
                        if (u2.blPartState == false)
                        {
                            u2.blPartState = true;
                            flag = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (u2.blPartState)
                        {
                            u3.s_panel = u2.s_panel;
                            j = i;
                            u2.blPartState = false;
                        }
                    }
                    alPanel[i] = u2;
                }
                if (flag)
                {
                    switch (_partType)
                    {
                        case PartType.Time:
                            if (u3.s_panel != null)
                            {
                                LeftPartResize(u3.s_panel, j);
                            }
                            break;
                        case PartType.Cleft:
                            LeftPartResize();
                            break;
                        default:
                            break;
                    }

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 重置左部设计区域的区域大小。
        /// </summary>
        public void LeftPartResize()
        {
            if (alPanel.Count<=0)
            {
                return;
            }

            stretchFlag = false;
            int NowHeight = 0;

            _mainHeight = this.Height - (_titleHeight + _splitHeight) * (alPanel.Count - 1);

            for (int i = 0; i < alPanel.Count; i++)
            {
                PanelInfo panelInfo = (PanelInfo)alPanel[i];
                
                panelInfo.s_panel.Left = 0;
                if (i == 0)
                {
                    panelInfo.s_panel.Top = 0;
                    NowHeight = panelInfo.s_panel.Top;
                }
                else
                {
                    panelInfo.s_panel.Top = NowHeight + _splitHeight;
                }
                if (panelInfo.blPartState == false)
                {
                    Stretch(alPanel, panelInfo.s_panel, _mainHeight - _titleHeight, _partTime, false, i);
                }
                if (i != 0)
                {
                    NowHeight = panelInfo.s_panel.Top + _titleHeight;
                }
            }
            NowHeight = 0;
            for (int i = 0; i < alPanel.Count; i++)
            {
                PanelInfo panelInfo = (PanelInfo)alPanel[i];
                panelInfo.s_panel.Left = 0;
                if (i == 0)
                {
                    panelInfo.s_panel.Top = 0;
                    NowHeight = panelInfo.s_panel.Top;
                }
                else
                {
                    panelInfo.s_panel.Top = NowHeight + _splitHeight;
                }
                if (panelInfo.blPartState == true)
                {
                    Stretch(alPanel, panelInfo.s_panel, _mainHeight - _titleHeight, _partTime, true, i);
                }
                if (i != 0)
                {
                    NowHeight = panelInfo.s_panel.Top + _titleHeight;
                }
                if (panelInfo.blPartState == true)
                {
                    NowHeight += _mainHeight;
                }
            }
            stretchFlag = true;
        }

        /// <summary>
        /// 抽屉效果。
        /// </summary>
        /// <param name="alPanel">菜单列表</param>
        /// <param name="myControl">要控制的菜单</param>
        /// <param name="MaxValue">显示部分最大高度</param>
        /// <param name="Increment">展开合并速度值</param>
        /// <param name="Flag">展开合并状态  true展开  false合并</param>
        /// <param name="Part">菜单索引</param>
        private void Stretch(ArrayList alPanel, Control myControl, int MaxValue, int Increment, bool Flag, int Part)
        {

            if (Flag)
            {
                for (; myControl.Height - _titleHeight < MaxValue; )
                {
                    System.Threading.Thread.Sleep(1);

                    if (myControl.Height - _titleHeight + Increment >= MaxValue)
                    {
                        myControl.Height = MaxValue + _titleHeight;
                    }
                    else
                    {
                        myControl.Height += Increment;
                    }

                    Application.DoEvents();

                    for (int i = 0; i < alPanel.Count; i++)
                    {
                        if (i > Part)
                        {
                            PanelInfo panelInfo = (PanelInfo)alPanel[i];
                            panelInfo.s_panel.Top += Increment;
                        }
                    }
                }
            }
            else
            {
                for (; myControl.Height - _titleHeight > 0; )
                {
                    System.Threading.Thread.Sleep(1);
                    if (myControl.Height - _titleHeight - Increment <= 0)
                    {
                        myControl.Height = _titleHeight;
                    }
                    else
                    {
                        myControl.Height -= Increment;
                    }

                    Application.DoEvents();

                    for (int i = 0; i < alPanel.Count; i++)
                    {
                        if (i > Part)
                        {
                            PanelInfo panelInfo = (PanelInfo)alPanel[i];
                            panelInfo.s_panel.Top -= Increment;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 重置左部设计区域的区域大小。
        /// </summary>
        private void LeftPartResize(Control myControl1, int part1)
        {
            for (int i = 0; i < alPanel.Count; i++)
            {
                PanelInfo panelInfo = (PanelInfo)alPanel[i];
                if (panelInfo.blPartState == true)
                {
                    Stretch(alPanel, panelInfo.s_panel, myControl1, _mainHeight - _titleHeight, _partTime, i, part1);
                }
            }
        }

        /// <summary>
        /// 抽屉效果。
        /// </summary>
        private void Stretch(ArrayList alPanel, Control myControl, Control myControl1, int MaxValue, int Increment, int Part, int Part1)
        {
            stretchFlag = false;
            for (; myControl.Height - _titleHeight < MaxValue; )
            {
                System.Threading.Thread.Sleep(1);
                if (myControl1.Height - _titleHeight - Increment <= 0)
                {
                    myControl1.Height = _titleHeight;
                }
                else
                {
                    myControl1.Height -= Increment;
                }

                if (myControl.Height - _titleHeight + Increment >= MaxValue)
                {
                    myControl.Height = MaxValue + _titleHeight;
                }
                else
                {
                    myControl.Height += Increment;
                    myControl.SendToBack();
                }

                if (Part > Part1)
                {
                    for (int i = 0; i < alPanel.Count; i++)
                    {
                        if (i > Part1 && i <= Part)
                        {
                            PanelInfo panelInfo = (PanelInfo)alPanel[i];
                            panelInfo.s_panel.Top -= Increment;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < alPanel.Count; i++)
                    {
                        if (i > Part && i <= Part1)
                        {
                            PanelInfo panelInfo = (PanelInfo)alPanel[i];
                            panelInfo.s_panel.Top += Increment;
                        }
                    }
                }
            }

            for (int i = 0; i < alPanel.Count; i++)
            {
                if (i > 0)
                {
                    PanelInfo panelInfo = (PanelInfo)alPanel[i - 1];
                    PanelInfo panelInfo1 = (PanelInfo)alPanel[i];
                    panelInfo1.s_panel.Top =panelInfo.s_panel.Top + panelInfo.s_panel.Height + _splitHeight;
                }
            }
            stretchFlag = true;
        }
    }
}
