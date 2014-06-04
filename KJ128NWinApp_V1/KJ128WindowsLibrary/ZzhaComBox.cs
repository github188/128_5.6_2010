using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace KJ128WindowsLibrary
{
    public partial class ZzhaComBox : ComboBox
    {
        private List<string> _Values = new List<string>();
        /// <summary>
        /// 下拉列表中Item所对应的Value集合
        /// </summary>
        public List<string> Values
        {
            get { return _Values; }
            set { _Values = value; }
        }

        public ZzhaComBox()
        {
            InitializeComponent();
        }

        public void AddItem(string item, string value)
        {
            this.Items.Add(item);
            this.Values.Add(value);
        }

        public string SelectedValue
        {
            get 
            {
                if (this.SelectedIndex >= 0)
                    return this.Values[SelectedIndex];
                else
                    return null;
            }
        }
    }
}
