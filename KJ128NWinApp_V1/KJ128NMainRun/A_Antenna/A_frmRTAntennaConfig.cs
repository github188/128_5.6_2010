using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.A_Antenna
{
    public partial class A_frmRTAntennaConfig : Form
    {
        private bool issaved = false;

        private bool _IsUse = false;

        private bool show = true;

        public bool IsUse
        {
            get { return chkUse.Checked; }
        }

        public DateTime StartTime
        {
            get { return dtpStart.Value; }
        }

        public DateTime EndTime
        {
            get { return dtpEnd.Value; }
        }

        public bool ShowMine
        {
            get { return chkShowMine.Checked; }
        }

        private DateTime time1;
        private DateTime time2;

        public A_frmRTAntennaConfig(bool showmine)
        {
            InitializeComponent();
            this.show = showmine;
        }

        public A_frmRTAntennaConfig(bool isuse,DateTime starttime,DateTime endtime,bool showmine)
        {
            InitializeComponent();
            this._IsUse = isuse;
            this.time1 = starttime;
            this.time2 = endtime;
            this.show = showmine;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.chkUse.Checked = false;
            dtpStart.Enabled = chkUse.Checked;
            dtpEnd.Enabled = chkUse.Checked;
            dtpStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            dtpEnd.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void A_frmRTAntennaConfig_Load(object sender, EventArgs e)
        {
            if (this._IsUse == true)
            {
                this.chkUse.Checked = true;
                dtpStart.Enabled = chkUse.Checked;
                dtpEnd.Enabled = chkUse.Checked;
                chkShowMine.Checked = show;
                dtpStart.Value = time1;
                dtpEnd.Value = time2;
            }
            else
            {
                this.chkUse.Checked = false;
                dtpStart.Enabled = chkUse.Checked;
                dtpEnd.Enabled = chkUse.Checked;
                chkShowMine.Checked = show;
                dtpStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                dtpEnd.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            dtpStart.Enabled = chkUse.Checked;
            dtpEnd.Enabled = chkUse.Checked;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (issaved)
                this.DialogResult = DialogResult.OK;
            else
                this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtpStart, dtpEnd))
            {
                return;
            }
            this.issaved = true;
            labTT.Visible = true;
            labMessage.Text = "保存成功";
            labMessage.Visible = true;
        }

        private void chkShowMine_CheckedChanged(object sender, EventArgs e)
        {

        }

        #region【方法：判断时间】

        private bool DecideTime(DateTimePicker dtpBegin, DateTimePicker dtpEnd)
        {
            if (Convert.ToDateTime(dtpEnd.Text) > DateTime.Now)
            {
                MessageBox.Show("结束时间不能大于当前系统时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (Convert.ToDateTime(dtpBegin.Text) >= Convert.ToDateTime(dtpEnd.Text))
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (Convert.ToDateTime(dtpBegin.Text).AddDays(7) < Convert.ToDateTime(dtpEnd.Text))
            {
                MessageBox.Show("开始时间与结束时间相差不能大于7天！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        #endregion
    }
}
