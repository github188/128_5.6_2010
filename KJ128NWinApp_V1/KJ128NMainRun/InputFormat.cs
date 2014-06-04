using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun
{
    public class InputFormat
    {
        public void HalfWidthFormat(KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65281 && e.KeyChar <= 65374)
            {
                e.KeyChar -= Convert.ToChar(65248);
            }
        }
    }
}
