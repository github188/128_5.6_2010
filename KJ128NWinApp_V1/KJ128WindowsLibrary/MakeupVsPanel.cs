using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace KJ128WindowsLibrary
{
    /// <summary>
    /// 可缩放的VsPanel
    /// </summary>
    public class MakeupVsPanel:VSPanel
    {
        #region 私有变量
        #region m_ExpansionLabel
        private LabelButton m_ExpansionLabel = new KJ128WindowsLibrary.LabelButton();
        private string m_ExpansionLabelText = "+";
        private int m_ExpansionLabelHeight=20;
        private int m_ExpansionLabelWidth=14;
        private int m_ExpansionLabelLeft = 4;
        private int m_ExpansionLabelTop = 0;
        private int m_ExpansionTextLeft = 0;
        private int m_ExpansionTextTop = 0;
        

        
        #endregion

        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public MakeupVsPanel():base()
        {
            InitExpansionLabel();
        }
        #endregion
        #region 方法
        private void InitExpansionLabel()
        {
           
            m_ExpansionLabel.AutoSize = false;
            m_ExpansionLabel.Location = new Point(m_ExpansionLabelLeft, m_ExpansionLabelTop);
            m_ExpansionLabel.Size = new Size(m_ExpansionLabelWidth, m_ExpansionLabelHeight);
           
            
            this.Controls.Add(m_ExpansionLabel);
            m_ExpansionLabel.Paint += new PaintEventHandler(m_ExpansionLabel_Paint);
            m_ExpansionLabel.MouseLeave += new EventHandler(m_ExpansionLabel_MouseLeave);
        }

        private void DrawExpansionLabelText(Graphics g)
        {
            g.DrawString(m_ExpansionLabelText,this.Font,new SolidBrush(this.ForeColor),new PointF(m_ExpansionTextLeft,m_ExpansionTextTop));
        }
        /// <summary>
        /// 绘制m_ExpansionLabel背景
        /// </summary>
        /// <param name="g"></param>
        private void DrawExpansionLabel(Graphics g)
        {
            Rectangle rect = m_ExpansionLabel.Bounds;
            if (IsCaptionSingleColor)
            {
                m_ExpansionLabel.BackColor = BackColor;
            }
            else
            {
                g.FillRectangle(new LinearGradientBrush(rect,LinearGradientColor1,LinearGradientColor2,BackLinearGradientMode),rect);
            }
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion
        #region 事件处理
        /// <summary>
        /// 重绘_ExpansionLabel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_ExpansionLabel_Paint(object sender, PaintEventArgs e)
        {
            
            switch(m_ExpansionLabel.MouseState)
            {
                case LabelButtonMouseState.MouseLeaver:
                    {
                          DrawExpansionLabel(e.Graphics);
                          break;
                    }
                case LabelButtonMouseState.NoMouseHandle:
                    {
                       DrawExpansionLabel(e.Graphics);
                        break;
                    }
            }
            DrawExpansionLabelText(e.Graphics);
        }
        /// <summary>
        /// m_ExpansionLabel_MouseLeave 将组件的背景与父控件的背景一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_ExpansionLabel_MouseLeave(object sender, EventArgs e)
        {
            DrawExpansionLabel(m_ExpansionLabel.CreateGraphics());
            DrawExpansionLabelText(m_ExpansionLabel.CreateGraphics());
        }
        
        #endregion


    }

}
