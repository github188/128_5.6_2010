using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;
namespace KJ128WindowsLibrary
{
    /// <summary>
    /// 继承Label控件，实现Label控件的部分透明
    /// </summary>
    public class LabelTransparent:Label

    {
        #region 私有变量
        private bool m_IsTransparent = false;

        #endregion
        #region 构造函数
        /// <summary>
       /// 使用label()的构造
       /// </summary>
        public LabelTransparent():base()
        {

        }
        #endregion
        #region 属性
     
        /// <summary>
        /// 是否透明
        /// </summary>
        public bool IsTransparent
        {
            get
            {
                return m_IsTransparent;
            }
            set
            {
                m_IsTransparent = value;
            }
        }
        #endregion
        #region 方法

        
 /// <summary>
 /// 绘制Label
 /// </summary>
 /// <param name="g">画布</param>
 /// <param name="l">lbl</param>
        public void DrawLabel(Graphics g,LabelTransparent l)
        {
            if(m_IsTransparent)
            {
                this.Visible = false;
            g.DrawString(l.Text, l.Font, new SolidBrush(l.ForeColor), l.Left, l.Top);
            }
        }
        /// <summary>
        /// 绘制Label
        /// </summary>
        /// <param name="g">画布Graphics</param>
        /// <param name="x">左边界</param>
        /// <param name="y">上边界</param>
        public void DrawLabel(Graphics g,int x ,int y)
        {
            if (m_IsTransparent)
            {
                this.Visible = false;
                g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), x, y);
            }
        }

   
        /// <summary>
        /// 绘制Label
        /// </summary>
        /// <param name="g">画布</param>
        public void DrawLabel(Graphics g)
        {
            if (m_IsTransparent)
            {
               this.Visible = false;
               g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.Left, this.Top);
              //g.DrawString("你好啊", new Font("宋体", 12), new SolidBrush(Color.Black), 0, 0);
            }
        }
        #endregion
    }//class
}//namespace