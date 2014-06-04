using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.Graphics
{
    public partial class frmStaticConfig : Form
    {
        private ZzhaControlLibrary.StaticObject StaticObj = null;
        private ZzhaControlLibrary.ZzhaMapGis MapGis = null;

        public frmStaticConfig()
        {
            InitializeComponent();
        }
        public frmStaticConfig(ZzhaControlLibrary.StaticObject staticobj)
        {
            InitializeComponent();
            this.StaticObj = staticobj;
        }

        public frmStaticConfig(ZzhaControlLibrary.StaticObject staticobj,ZzhaControlLibrary.ZzhaMapGis mapgis)
        {
            InitializeComponent();
            this.StaticObj = staticobj;
            this.MapGis = mapgis;
        }

        private void frmStaticConfig_Load(object sender, EventArgs e)
        {
            this.labWidth.Text = "宽:" + StaticObj.StaticWidth.ToString();
            this.labHeight.Text = "高:" + StaticObj.StaticHeight.ToString();
            this.hsbWidth.Value = StaticObj.StaticWidth;
            this.hsbHeight.Value = StaticObj.StaticHeight;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.StaticObj.StaticWidth = hsbWidth.Value;
            this.StaticObj.StaticHeight = hsbHeight.Value;
            if (MapGis != null)
                MapGis.FlashAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hsbHeight_ValueChanged(object sender, EventArgs e)
        {
            this.labHeight.Text = "高:" + hsbHeight.Value.ToString();
        }

        private void hsbWidth_ValueChanged(object sender, EventArgs e)
        {
            this.labWidth.Text = "宽:" + hsbWidth.Value.ToString();
        }
    }
}
