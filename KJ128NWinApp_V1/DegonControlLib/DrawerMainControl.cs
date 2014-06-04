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
        /// ���
        /// </summary>
        public Control s_panel;
        /// <summary>
        /// չ��״̬
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
        /// ����б�
        /// </summary>
        private ArrayList alPanel = new ArrayList();
        /// <summary>
        /// �˵�����״̬
        /// </summary>
        private bool stretchFlag = true;

        #region ���Զ������ԡ�
        #region �����ԣ����������롿
        /// <summary>
        /// ��ʾ�����ļ�����롣
        /// </summary>
        private int _splitHeight = 1;
        /// <summary>
        /// ���û��ȡ����˵���ļ�����루��ֵ����С��0��С��0����Ĭ��Ϊ0��
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
        #endregion �����ԣ����������롿

        #region �����ԣ�����߶ȡ�
        /// <summary>
        /// ����߶�
        /// </summary>
        private int _titleHeight = 30;
        /// <summary>
        /// ���û��ȡ����˵��ı���߶�(��ֵ����С��1��С��1����Ĭ��Ϊ10)
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
        #endregion �����ԣ�����߶ȡ�

        #region �����ԣ������߶ȡ�
        /// <summary>
        /// ���ĸ߶�
        /// </summary>
        private int _mainHeight = 100;
        /// <summary>
        /// ��ȡ�����������ĸ߶�
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
        #endregion �����ԣ������߶ȡ�

        #region �����ԣ����չ���ͺϲ��ٶȡ�
        /// <summary>
        /// չ���ͺϲ��ٶ�
        /// </summary>
        private int _partTime = 1;
        /// <summary>
        /// ���û��ȡչ���ͺϲ��ٶ�
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
        #endregion �����ԣ����չ���ͺϲ��ٶȡ�

        #region �����ԣ����򿪷�ʽ��
        private PartType _partType = PartType.Time;
        /// <summary>
        /// ��ȡ���������򿪷�ʽ
        /// </summary>
        public PartType PType
        {
            get { return _partType; }
            set { _partType = value; }
        }
        #endregion

        #endregion ���Զ������ԡ�

        public DrawerMainControl()
        {
            InitializeComponent();
            
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// �����������
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
        /// ������
        /// </summary>
        /// <param name="control">���</param>
        /// <param name="partState">�ϲ���չ��״̬ true չ�� false �ϲ�</param>
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
        /// ������(Ĭ�Ϻϲ�)
        /// </summary>
        /// <param name="control">���</param>
        public void Add(Control control)
        {
            Add(control, false);
        }

        /// <summary>
        /// ���չ��
        /// </summary>
        /// <param name="name">��������</param>
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
        /// �������������������С��
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
        /// ����Ч����
        /// </summary>
        /// <param name="alPanel">�˵��б�</param>
        /// <param name="myControl">Ҫ���ƵĲ˵�</param>
        /// <param name="MaxValue">��ʾ�������߶�</param>
        /// <param name="Increment">չ���ϲ��ٶ�ֵ</param>
        /// <param name="Flag">չ���ϲ�״̬  trueչ��  false�ϲ�</param>
        /// <param name="Part">�˵�����</param>
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
        /// �������������������С��
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
        /// ����Ч����
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
