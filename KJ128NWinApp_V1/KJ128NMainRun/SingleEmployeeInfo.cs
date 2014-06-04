using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun
{
    /// <summary>
    /// 单个员工信息面板，根据用户传入的EmpID 或者 用户姓名,显示单个用户的基本信息
    /// </summary>
    public partial class SingleEmployeeInfo : UserControl
    {
        public SingleEmployeeInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 隐藏此组件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCaptionPanel1_CloseButtonClick(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
