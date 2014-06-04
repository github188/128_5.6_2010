using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun
{
    public partial class FrmIpConfig : Wilson.Controls.Docking.DockContent
    {
        private FrmIpConfig_Main frmIpConfig_Main = new FrmIpConfig_Main();
        public FrmIpConfig()
        {
            InitializeComponent();
            this.SuspendLayout();
            this.Controls.Clear();

            Control c = frmIpConfig_Main.rerurnPandel1;
            c.Location =new Point(0,0);
            c.Name = "ipmain";
            this.Controls.Add(c);


            Control c1 = new FrmIpConfig_Add().rerurnPandel1;
            c1.Location = new Point(0, 0);
            c1.Name = "ipadd";

            this.Controls.Add(c1);


            Control c2 = new FrmStationIpConfig().rerurnPandel1;
            c2.Location = new Point(0, 0);
            c2.Name = "station";

            this.Controls.Add(c2);


            this.ResumeLayout(false);
        }

       
    }
}
