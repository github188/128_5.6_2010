using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;
namespace KJ128WindowsLibrary
{
    /// <summary>
    /// �̳�Label�ؼ���ʵ��Label�ؼ��Ĳ���͸��
    /// </summary>
    public class LabelTransparent:Label

    {
        #region ˽�б���
        private bool m_IsTransparent = false;

        #endregion
        #region ���캯��
        /// <summary>
       /// ʹ��label()�Ĺ���
       /// </summary>
        public LabelTransparent():base()
        {

        }
        #endregion
        #region ����
     
        /// <summary>
        /// �Ƿ�͸��
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
        #region ����

        
 /// <summary>
 /// ����Label
 /// </summary>
 /// <param name="g">����</param>
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
        /// ����Label
        /// </summary>
        /// <param name="g">����Graphics</param>
        /// <param name="x">��߽�</param>
        /// <param name="y">�ϱ߽�</param>
        public void DrawLabel(Graphics g,int x ,int y)
        {
            if (m_IsTransparent)
            {
                this.Visible = false;
                g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), x, y);
            }
        }

   
        /// <summary>
        /// ����Label
        /// </summary>
        /// <param name="g">����</param>
        public void DrawLabel(Graphics g)
        {
            if (m_IsTransparent)
            {
               this.Visible = false;
               g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.Left, this.Top);
              //g.DrawString("��ð�", new Font("����", 12), new SolidBrush(Color.Black), 0, 0);
            }
        }
        #endregion
    }//class
}//namespace