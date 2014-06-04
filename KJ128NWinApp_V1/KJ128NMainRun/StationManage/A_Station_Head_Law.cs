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
    public partial class A_Station_Head_Law : Form
    {
        private DataSet dsTemp;

        
        private bool isMove = false;            // (设置面板) 是否移动
        private int mleft = 0;
        private int mtop = 0;
        /// <summary>
        /// 存储分站信息
        /// </summary>
        private DataTable dtStationInfo = new DataTable();
        private A_StationBLL sbll = new A_StationBLL();
        A_FrmStationInfo fr = (A_FrmStationInfo)Application.OpenForms["A_FrmStationInfo"];
        public A_Station_Head_Law()
        {
            InitializeComponent();
            DataRow dr = sbll.getStationHeadRowInfo(fr._cmsStationHand1);

            txt_StaHead_StaAddress.Text = dr["StationAddress"].ToString();
            txt_StaHeadAddress.Text = dr["StationHeadAddress"].ToString();

            txt_StaHeadAddress.Enabled = false;
            txt_StaHeadPlace.Text = dr["StationHeadPlace"].ToString();
            txt_StaHeadTel.Text = dr["StationHeadTel"].ToString();
            txt_StaHeadAntennaA.Text = dr["AntennaA"].ToString();
            txt_StaHeadAntennaB.Text = dr["AntennaB"].ToString();
            if (dr["StationHeadTypeID"].ToString().Equals("8"))
            {
                rb_WellHead.Checked = true;
            }
            else
            {
                rb_WellUp.Checked = true;
            }
            txt_StaHeadRemark.Text = dr["Remark"].ToString();

            bt_StaHead_Reset.Enabled = false;
            bt_StaHead_Save.Enabled = gb_AddStaHeadInfo.Enabled = true;
            lb_StaHeadTipsInfo.Visible = lb_StaHeadTipsInfo2.Visible = false;

        }

        private void bt_StaHead_Save_Click(object sender, EventArgs e)
        {
            if (txt_StaHeadAddress.Text.Trim().Equals(""))
            {
                lb_StaHeadTipsInfo.Text = "读卡分站号不能为空！";
                lb_StaHeadTipsInfo.ForeColor = Color.Red;
                return;
            }
            else
            {
                if (Convert.ToInt32(txt_StaHeadAddress.Text.Trim()) > 6)
                {
                    lb_StaHeadTipsInfo.Text = "读卡分站号不能大于6！";
                    lb_StaHeadTipsInfo.ForeColor = Color.Red;
                    return;
                }
            }
            if (txt_StaHeadPlace.Text.Equals(""))
            {
                lb_StaHeadTipsInfo.Text = "请输入读卡分站的安装位置！";
                lb_StaHeadTipsInfo.ForeColor = Color.Red;
                return;
            }

            ////判断读卡分站的安装位置是否存在
            //if (sbll.ExistsStationHeadPlace(txt_StaHeadPlace.Text) > 0)
            //{
            //    lb_StaHeadTipsInfo.Text = "该读卡分站的安装位置已经存在，请重新输入！";
            //    lb_StaHeadTipsInfo.ForeColor = Color.Red;

            //    return;
            //}

            int intImpactCounts = 0;
            int intTypeID;
            string strType;
            if (rb_WellHead.Checked)        //上井口接收器
            {
                intTypeID = 8;
                strType = "上井口接收器";
            }
            else                            //井下接收器
            {
                intTypeID = 32;
                strType = "井下接收器";
            }
            intImpactCounts = sbll.updateStationHead(txt_StaHead_StaAddress.Text, txt_StaHeadAddress.Text.Trim(), txt_StaHeadPlace.Text, txt_StaHeadTel.Text, intTypeID, strType, txt_StaHeadAntennaA.Text, txt_StaHeadAntennaB.Text, txt_StaHeadRemark.Text);
            if (intImpactCounts > 0)
            {
                lb_StaHeadTipsInfo.Text = "修改成功！";
                lb_StaHeadTipsInfo.ForeColor = Color.Black;

                //存入日志
                LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "修改读卡分站，传输分站编号：" + txt_StaHead_StaAddress.Text + "，读卡分站编号：" + txt_StaHeadAddress.Text + "，读卡分站安装位置：" + txt_StaHeadPlace.Text);

                
            }
            else
            {
                lb_StaHeadTipsInfo.Text = "修改失败！";
                lb_StaHeadTipsInfo.ForeColor = Color.Red;

            }
                
        }

        private void bt_StaHead_Reset_Click(object sender, EventArgs e)
        {
            ClearStaHead();
            if (txt_StaHeadAddress.Enabled)
            {
                txt_StaHeadAddress.Text = "";
            }
        }

        private void bt_StaHead_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region【方法：清空 探头信息】

        /// <summary>
        /// 清空 探头信息
        /// </summary>
        private void ClearStaHead()
        {
            txt_StaHeadPlace.Text = "";
            txt_StaHeadAntennaA.Text = "";
            txt_StaHeadAntennaB.Text = "";
            rb_WellUp.Checked = true;
            txt_StaHeadTel.Text = "";
            txt_StaHeadRemark.Text = "";
        }
        #endregion

        private void txt_StaHeadPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StaHeadAntennaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StaHeadAntennaB_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StaHeadTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StaHeadRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
    }
}
