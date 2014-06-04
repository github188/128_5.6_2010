using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.Graphics
{
    public partial class frmWait : Form
    {
        public ProgressBar PgbWait
        {
            get { return this.pgbWait; }
        }

        public frmWait()
        {
            InitializeComponent();
        }

        public frmWait(string message)
        {
            InitializeComponent();
            this.labMessage.Text = message;
        }
    }
}