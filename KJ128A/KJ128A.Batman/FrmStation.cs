using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NMainRun;

namespace KJ128A.Batman
{
    /// <summary>
    /// 添加分站页面 
    /// </summary>
    public partial class FrmStation : Form
    {
        /// <summary>
        /// 添加分站页面
        /// </summary>
        public FrmStation()
        {
            InitializeComponent();
            label7.Visible = false;
            textBox_max.Visible = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = checkBox1.Checked;
            textBox_max.Visible = checkBox1.Checked;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            #region 写XML文件
            
            #endregion
        }

        private void textBox_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_didian_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void textBox_lianxi_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}