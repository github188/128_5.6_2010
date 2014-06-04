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
    public partial class A_Station_Head_Add : Form
    {

        #region【声明】

        private DataSet ds;

        private A_StationBLL sbll = new A_StationBLL();

        private A_FrmStationInfo frmSi;

        private int intStationAddressJudgment;

        private int intStationHeadID = -1;

        /// <summary>
        /// 是否是修改
        /// </summary>
        private bool blIsUpDate = true;

        private string strStationHeadPlace = "";
        #endregion

        #region【构造函数】

        public A_Station_Head_Add(A_FrmStationInfo frm)
        {
            InitializeComponent();
            frmSi = frm;
            blIsUpDate = frm.blIsUpDate;

            intStationAddressJudgment = frm.intStationAddressJudgment;
            intStationHeadID = frm.intStationHeadID;

            GetStationHead_Add();
        }

        #endregion

        #region【方法：验证】

        private bool CheckingStationHead()
        {
            if (txt_StaHeadAddress.Text.Trim().Equals(""))
            {
                SetTipsInfo(false, "读卡分站号不能为空！");
                txt_StaHeadAddress.Focus();
                txt_StaHeadAddress.SelectAll();
                return false;
            }
            else
            {
                if (Convert.ToInt32(txt_StaHeadAddress.Text.Trim()) > 6 )
                {
                    SetTipsInfo(false, "读卡分站号的编号在1--6之间！");
                    txt_StaHeadAddress.Focus();
                    txt_StaHeadAddress.SelectAll();
                    return false;
                }

                //Czlt-2011-04-01 读卡分站的编号只能是1--6之间
                if (Convert.ToInt32(txt_StaHeadAddress.Text.Trim()) <= 0)
                {
                    SetTipsInfo(false, "读卡分站号的编号在1--6之间！");
                    txt_StaHeadAddress.Focus();
                    txt_StaHeadAddress.SelectAll();
                    return false;
                }
            }
            //if(txtNO.Text.Trim().Length==0)
            //{
            //    SetTipsInfo(false, "请输入编号！");
            //    txtNO.Focus();
            //    txtNO.SelectAll();
            //    return false;
            //}
            //if (intStationHeadID == -1)
            //{
            //    if (sbll.IsExistsStationHeadNO(txtNO.Text.Trim()))
            //    {
            //        SetTipsInfo(false, "输入的编号已存在！");
            //        txtNO.Focus();
            //        txtNO.SelectAll();
            //        return false;
            //    }
            //}
            if (txt_StaHeadPlace.Text.Equals(""))
            {
                SetTipsInfo(false, "请输入读卡分站的安装位置！");
                txt_StaHeadPlace.Focus();
                txt_StaHeadPlace.SelectAll();
                return false;
            }

            if (intStationHeadID == -1 || (intStationHeadID != -1 && !txt_StaHeadPlace.Text.Trim().Equals(strStationHeadPlace)))
            {
                //判断读卡分站的安装位置是否存在
                if (sbll.ExistsStationHeadPlace(txt_StaHeadPlace.Text) > 0)
                {
                    SetTipsInfo(false, "该读卡分站的安装位置已经存在，请重新输入！");
                    txt_StaHeadPlace.Focus();
                    txt_StaHeadPlace.SelectAll();
                    return false;
                }
            }
            if (intStationHeadID == -1)
            {
                //判断系统中是否已经有该探头
                if (sbll.existsStationHeadAddress(int.Parse(txt_StaHeadAddress.Text), int.Parse(txt_StaHead_StaAddress.Text)) > 0)
                {
                    SetTipsInfo(false, txt_StaHead_StaAddress.Text + " 号传输分站下已存在 " + txt_StaHeadAddress.Text + " 号读卡分站！");
                    txt_StaHeadAddress.Focus();
                    txt_StaHeadAddress.SelectAll();
                    return false ;
                }
            }

            return true;
        }

        #endregion

        #region【方法：根据分站协议，判断探头号】

        /// <summary>
        /// 判断分站的通讯协议是否是A版
        /// </summary>
        /// <param name="intStationAddress">传输分站的编号</param>
        /// <returns>1:A版；2:V2版 3:检卡仪</returns>
        private int GetStationModel(int intStationAddress)
        {
            using (ds = new DataSet())
            {
                ds = sbll.GetStationModel(intStationAddress);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    }
                }
            }
            return 0;
        }

        #endregion

        #region【方法：加载读卡分站信息（新增）】

        /// <summary>
        /// 加载读卡分站信息（新增）
        /// </summary>
        private void GetStationHead_Add()
        {
            if (intStationHeadID == -1)    //新增
            {
                txt_StaHead_StaAddress.Text = intStationAddressJudgment.ToString();
                if (GetStationModel(intStationAddressJudgment) == 3)
                {
                    txt_StaHeadAddress.Text = "1";
                    txt_StaHeadAddress.Enabled = false;
                    rb_CheckCard.Checked = true;
                    rb_WellHead.Enabled = false;
                    rb_WellUp.Enabled = false;
                }
                else if (GetStationModel(intStationAddressJudgment) == 2)
                {
                    txt_StaHeadAddress.Text = "1";
                    txt_StaHeadAddress.Enabled = false;
                }
                else
                {
                    txt_StaHeadAddress.Enabled = true;
                }
            }
            else
            {
                if (blIsUpDate)         //修改
                {
                    this.Text = "修改读卡分站";
                    txt_StaHeadAddress.Enabled = false;
                    bt_StaHead_Reset.Enabled = false;
                    txtNO.Enabled = false;
                }
                else                            //查看
                {
                    this.Text = "查看读卡分站";
                    txt_StaHeadAddress.Enabled = false;
                    bt_StaHead_Save.Enabled = bt_StaHead_Reset.Enabled = false;
                    gb_AddStaHeadInfo.Enabled = false;
                    lb_StaHeadTipsInfo2.Visible = false;
                    txtNO.Enabled = false;
                }
                BindingStationHead(intStationHeadID);
            }
        }

        #endregion

        #region【方法：绑定修改的传输分站】

        private void BindingStationHead(int intID)
        {
            using (ds = sbll.GetStationHeadInfo_Binding(intID))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        txt_StaHeadAddress.Text = dt.Rows[0]["StationHeadAddress"].ToString();
                        txt_StaHead_StaAddress.Text = dt.Rows[0]["StationAddress"].ToString();
                        txt_StaHeadPlace.Text = dt.Rows[0]["StationHeadPlace"].ToString();
                        txt_StaHeadAntennaA.Text = dt.Rows[0]["AntennaA"].ToString();
                        txt_StaHeadAntennaB.Text = dt.Rows[0]["AntennaB"].ToString();
                        txt_StaHeadTel.Text = dt.Rows[0]["StationHeadTel"].ToString();
                        txt_StaHeadRemark.Text = dt.Rows[0]["Remark"].ToString();
                        txtNO.Text = dt.Rows[0]["StationHeadNO"].ToString();
                  
                        if (dt.Rows[0]["StationHeadTypeID"].ToString().Equals("8"))
                        {
                            rb_WellHead.Checked = true;
                        }
                        else if (dt.Rows[0]["StationHeadTypeID"].ToString().Equals("32"))
                        {
                            rb_WellUp.Checked = true;
                        }
                        else
                        {
                            rb_CheckCard.Checked = true;
                        }

                        strStationHeadPlace = dt.Rows[0]["StationHeadPlace"].ToString();

                    }
                }
            }
        }

        #endregion

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
            txtNO.Text = "";
        }
        #endregion

        #region 【方法：设置提示信息】

        private void SetTipsInfo(bool blIsSuccess, string strInfo)
        {
            lb_StaHeadTipsInfo.Text = strInfo;
            lb_StaHeadTipsInfo.Visible = true;

            if (blIsSuccess)
            {
                lb_StaHeadTipsInfo.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lb_StaHeadTipsInfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion

        #region【事件：保存】

        private void bt_StaHead_Save_Click(object sender, EventArgs e)
        {
            if (!CheckingStationHead())
            {
                return;
            }
          
            int intImpactCounts = 0;
            int intTypeID;
            string strType;
            if (rb_WellHead.Checked)        //上井口接收器
            {
                intTypeID = 8;
                strType = "上井口接收器";
            }
            else if (rb_WellUp.Checked)                           //井下接收器
            {
                intTypeID = 32;
                strType = "井下接收器";
            }
            else
            {
                intTypeID = 64;
                strType = "检卡仪分站";
            }
            if (intStationHeadID==-1)       //新增
            {
                
                intImpactCounts = sbll.insertStationHead(Convert.ToInt32(txt_StaHead_StaAddress.Text), Convert.ToInt32(txt_StaHeadAddress.Text.Trim()),
                    txt_StaHeadPlace.Text, txt_StaHeadTel.Text, intTypeID, strType, txt_StaHeadAntennaA.Text, txt_StaHeadAntennaB.Text,
                    txt_StaHeadRemark.Text,txtNO.Text);
                if (intImpactCounts > 0)
                {
                    SetTipsInfo(true, "保存成功！");
                    frmSi.IsSave = true;
                    //存入日志
                    LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "添加新读卡分站，传输分站编号：" + txt_StaHead_StaAddress.Text + "，读卡分站编号：" + txt_StaHeadAddress.Text + "，读卡分站安装位置：" + txt_StaHeadPlace.Text);

                    #region【刷新】

                    if (!New_DBAcess.IsDouble)
                    {
                        frmSi.RefreshStationHead();
                    }
                    else
                    {
                        frmSi.intSelectModel = 2;
                        frmSi.HostBackRefresh(true);
                    }
                    #endregion
                }
                else
                {
                    SetTipsInfo(false, "保存失败！");
                }
            }
            else                                                             //修改
            {
                intImpactCounts = sbll.updateStationHead(txt_StaHead_StaAddress.Text, txt_StaHeadAddress.Text.Trim(), txt_StaHeadPlace.Text, txt_StaHeadTel.Text, intTypeID, strType, txt_StaHeadAntennaA.Text, txt_StaHeadAntennaB.Text, txt_StaHeadRemark.Text);
                if (intImpactCounts > 0)
                {
                    SetTipsInfo(true, "修改成功！");
                    strStationHeadPlace = txt_StaHeadPlace.Text.Trim();
                    //frmSi.IsSave = true;
                    //存入日志
                    LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "修改读卡分站，传输分站编号：" + txt_StaHead_StaAddress.Text + "，读卡分站编号：" + txt_StaHeadAddress.Text + "，读卡分站安装位置：" + txt_StaHeadPlace.Text);

                    #region【刷新】

                    if (!New_DBAcess.IsDouble)
                    {
                        frmSi.RefreshStationHead();
                    }
                    else
                    {
                        frmSi.intSelectModel = 2;
                        frmSi.HostBackRefresh(true);
                    }
                    #endregion
                }
                else
                {
                    SetTipsInfo(false, "修改失败！");
                }

            }
        }

        #endregion

        #region【事件：重置】

        private void bt_StaHead_Reset_Click(object sender, EventArgs e)
        {
            ClearStaHead();
            if (txt_StaHeadAddress.Enabled)
            {
                txt_StaHeadAddress.Text = "";
            }
        }

        #endregion

        #region【事件：返回】

        private void bt_StaHead_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void A_Station_Head_Add_Load(object sender, EventArgs e)
        {

        }

        private void txt_StaHeadPlace_KeyPress(object sender, KeyPressEventArgs e)
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
