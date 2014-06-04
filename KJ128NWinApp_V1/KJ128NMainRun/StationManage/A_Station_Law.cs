using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using System.Drawing.Drawing2D;
using KJ128NDBTable;
using System.Data.SqlClient;
using KJ128N.Command;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NMainRun.StationManage
{
    public partial class A_Station_Law : Form
    {
        A_FrmStationInfo fr = (A_FrmStationInfo)Application.OpenForms["A_FrmStationInfo"];
        private A_StationBLL sbll = new A_StationBLL();
        public A_Station_Law()
        {
            InitializeComponent();
            cmb_StationPacket.Text = "1";
            DataRow dr = sbll.getStationInfo(fr._cmsStationHand1);
            if (dr != null)
            {
                txt_StationAddress.Text = dr["StationAddress"].ToString();
                txt_StationPlace.Text = dr["StationPlace"].ToString();
                txt_StationTel.Text = dr["StationTel"].ToString();
                if (dr["StationModel"].ToString().Equals("1"))
                {
                    rb_A.Checked = true;
                }
                else
                {
                    rb_V2.Checked = true;
                }
                
                
                
                //pl_AddStationInfo.BringToFront();
                bt_Station_Reset.Enabled = false;
                txt_StationAddress.Enabled = false;
                lb_StationTipsInfo.Visible = label110.Visible = false;
                
            }
        }

        private void A_Station_Law_Load(object sender, EventArgs e)
        {

        }

        private void bt_Station_Save_Click(object sender, EventArgs e)
        {
            if (txt_StationAddress.Text.Trim().Equals(""))
            {
                lb_StationTipsInfo.Text = "分站号不能为空";
                lb_StationTipsInfo.ForeColor = Color.Red;
                return;
            }
            if (cmb_StationPacket.Text.Trim().Equals(""))
            {
                lb_StationTipsInfo.Text = "分站组不能为空";
                lb_StationTipsInfo.ForeColor = Color.Red;
                return;
            }
            if (cmb_StationPacket.Text.Trim().Equals(""))
            {
                lb_StationTipsInfo.Text = "分站组不能为空";
                lb_StationTipsInfo.ForeColor = Color.Red;
                return;
            }
            else
            {
                if (Convert.ToInt32(txt_StationAddress.Text.Trim()) > 64)
                {
                    lb_StationTipsInfo.Text = "分站号不能大于64";
                    lb_StationTipsInfo.ForeColor = Color.Red;
                    return;
                }
            }
            //if (txt_StationPlace.Text.Trim().Equals(""))
            //{
            //    lb_StationTipsInfo.Text = "分站安装位置不能为空！";
            //    lb_StationTipsInfo.ForeColor = Color.Red;
            //    return;
            //}

            //判断系统中该安装位置是否存在

            int intImpactCounts = 0;
            int intStationModel = 1;
            if (rb_V2.Checked)
            {
                intStationModel = 2;
            }
            intImpactCounts = sbll.UpdateStationInfo(Convert.ToInt32(txt_StationAddress.Text), txt_StationPlace.Text, txt_StationTel.Text,
                    1, "通用接收器", int.Parse(cmb_StationPacket.Text.ToString()), intStationModel);
            if (intImpactCounts > 0)
            {
                lb_StationTipsInfo.Text = "修改成功！";
                lb_StationTipsInfo.ForeColor = Color.Black;

                //存入日志
                LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "修改分站，分站编号：" + txt_StationAddress.Text + "，安装位置：" + txt_StationPlace.Text);

                //if (!New_DBAcess.IsDouble)
                //{
                //    InitData();             // 重新加载
                //}
                //else
                //{
                //    timer1.Start();
                //}

            }
            else
            {
                lb_StationTipsInfo.Text = "修改失败！";
                lb_StationTipsInfo.ForeColor = Color.Red;
            }
        }

        private void bt_Station_Reset_Click(object sender, EventArgs e)
        {
            ClearStation();
        }

        private void bt_Station_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #region【方法：清空 分站信息】

        /// <summary>
        /// 清空 分站信息
        /// </summary>
        private void ClearStation()
        {
            txt_StationAddress.Text = "";
            txt_StationPlace.Text = "";
            txt_StationTel.Text = "";
            rb_A.Checked = true;
            //cmb_StationPacket.SelectedIndex = 0;
        }
        #endregion

        private void txt_StationPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void cmb_StationPacket_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StationTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
