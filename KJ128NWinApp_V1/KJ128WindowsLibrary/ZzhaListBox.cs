using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace KJ128WindowsLibrary
{
    /// <summary>
    /// 带有value值的ListBox
    /// </summary>
    public partial class ZzhaListBox : ListBox
    {
        private List<string> _Values = new List<string>();
        /// <summary>
        /// item所对应的value集合
        /// </summary>
        public List<string> Values
        {
            get { return _Values; }
            set { _Values = value; }
        }

        public ZzhaListBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加带value的项
        /// </summary>
        /// <param name="item">项名称</param>
        /// <param name="value">项值</param>
        public void AddItem(string item, string value)
        {
            this.Items.Add(item);
            this.Values.Add(value);
        }
        /// <summary>
        /// 获得当前选中项对应的Value值
        /// </summary>
        public string SelectedValue
        {
            get
            {
                if (SelectedIndex >= 0)
                    return Values[SelectedIndex];
                else
                    return null;
            }
        }
    }
}
