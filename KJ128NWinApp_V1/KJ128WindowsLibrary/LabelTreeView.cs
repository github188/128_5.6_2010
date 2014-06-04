using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace KJ128WindowsLibrary
{
    /// <summary>
    /// 文本框和TreeView组合使用,实现文本信息，来源于TreeView
    /// </summary>
    public class LabelTreeView:Control
    {
        #region 私有变量
        private Label m_LabelControl = new Label();
        private TreeViewDepartment m_TreeViewDepartment = new TreeViewDepartment();
        private bool m_IsShiftShow = true;//是否收缩显示
        private int m_SheetageHeight = 100;//展开的高度
        private int m_ShiftHeight = 13;//收缩的高度
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public LabelTreeView()
        {
            InitCompent();
        }
        #region 方法
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitCompent()
        {
            m_LabelControl.Location = new Point(1, 1);
            m_LabelControl.Size = new Size(111, m_ShiftHeight-1);
            m_LabelControl.BackColor = Color.White;
            m_LabelControl.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(m_LabelControl);
            m_TreeViewDepartment.Location = new Point(1, m_ShiftHeight);
            m_TreeViewDepartment.Size=new Size(111,13);
            m_TreeViewDepartment.Anchor = ((AnchorStyles.Left) | (AnchorStyles.Right) | (AnchorStyles.Bottom) | (AnchorStyles.Top));
            this.Controls.Add(m_TreeViewDepartment);
            m_LabelControl.MouseClick += new MouseEventHandler(m_LabelControl_MouseClick);
        }

        void m_LabelControl_MouseClick(object sender, MouseEventArgs e)
        {
            m_TreeViewDepartment.Visible = true;
            this.Size = m_LabelControl.Size;
        }
        /// <summary>
        /// 当尺寸改变时
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (m_IsShiftShow)
            {
                this.Height = m_ShiftHeight;
            }
            else
            {
                this.Height=m_SheetageHeight;
            }
            this.Width = 111;
        }
        #endregion
        #region 属性
        /// <summary>
        /// 收缩的高度，其值>5
        /// </summary>
        [Category("扩展的属性"), Description("收缩的高度，其值>5")]
        public int ShiftHeight
        {
            get
            {
                return m_ShiftHeight;
            }
            set
            {
                if (value > 5)
                {
                    m_ShiftHeight = value;
                }
            }
        }

        /// <summary>
        /// 展开的高度，其值大于5
        /// </summary>
        [Category("扩展的属性"), Description("展开的高度，其值大于5")]
        public int SheetageHeight
        {
            get
            {
                return m_SheetageHeight;
            }
            set
            {
                if (value > 5)
                {
                    m_SheetageHeight = value;
                }
            }
        }
        #endregion
    }//class
}//namespace