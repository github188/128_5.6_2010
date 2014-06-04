using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJ128NMainRun.A_RT_StationHead
{
    public partial class A_FrmRTStationHead_Set : Form
    {

        #region【声明】

        A_FrmRTStationHead frmrts;

        #endregion

        #region【构造函数】

        public A_FrmRTStationHead_Set(A_FrmRTStationHead frm)
        {
            InitializeComponent();

            dtp_Begin.Value = DateTime.Now.Date;
            dtp_End.Value = DateTime.Now;

            frmrts = frm;
            if (frm.isEnableTime)
            {
                cb.Checked = true;
                gb.Enabled = true;
                dtp_Begin.Value = frm.dtBeginTime;
                dtp_End.Value = frm.dtEndTime;
            }
            else
            {
                cb.Checked = false;
                gb.Enabled = false;
            }
        }

        #endregion

        #region【方法：判断时间】

        private bool DecideTime(DateTimePicker dtpBegin, DateTimePicker dtpEnd)
        {
            if (Convert.ToDateTime(dtpEnd.Text) > DateTime.Now)
            {
                lb_TipsInfo.Text = "结束时间不能大于当前系统时间！";
                //MessageBox.Show("结束时间不能大于当前系统时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (Convert.ToDateTime(dtpBegin.Text) >= Convert.ToDateTime(dtpEnd.Text))
            {
                lb_TipsInfo.Text = "开始时间不能大于结束时间！";
                //MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (Convert.ToDateTime(dtpBegin.Text).AddDays(7) < Convert.ToDateTime(dtpEnd.Text))
            {
                lb_TipsInfo.Text = "开始时间与结束时间相差不能大于7天！";
                //MessageBox.Show("开始时间与结束时间相差不能大于7天！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        #endregion

        #region【事件：保存】

        private void savebutton_Click(object sender, EventArgs e)
        {
            lb_TipsInfo.Visible = true;
            if (cb.Checked)
            {
                if (!DecideTime(dtp_Begin, dtp_End))
                {
                    lb_TipsInfo.ForeColor = Color.Red;
                    return;
                }
            }

            frmrts.isEnableTime = cb.Checked;
            frmrts.dtBeginTime = dtp_Begin.Value;
            frmrts.dtEndTime = dtp_End.Value;
            lb_TipsInfo.Text = "保存成功！";
            lb_TipsInfo.ForeColor = Color.Black;
            frmrts.Flash();
        }
        
        #endregion

        #region【事件：重置】

        private void removebutton_Click(object sender, EventArgs e)
        {
            cb.Checked = false;
            gb.Enabled = false;
        }

        #endregion

        #region【事件：返回】

        private void returnbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            gb.Enabled = cb.Checked;
        }
    }
}
