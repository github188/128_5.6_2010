using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128A.Batman
{
    /// <summary>
    /// 关于窗体
    /// </summary>
    public partial class FrmABout : Form
    {
        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmABout()
        {
            InitializeComponent();
        }

        #endregion

        #region [ 按钮: 单击事件 ]

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}