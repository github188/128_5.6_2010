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
using System.IO;
using System.Xml;

namespace KJ128NMainRun.StationManage
{
    public partial class A_Station_Add : Form
    {

        #region【声明】

        private A_StationBLL sbll = new A_StationBLL();

        private A_FrmStationInfo frmSi;

        private int intStationAddress = -1;

        /// <summary>
        /// 是否是修改
        /// </summary>
        private bool blIsUpDate = true;

        private DataSet ds;

        //Czlt-2011-06-09 修改分站的时候保存现在的状态
        private string stationState = "";

        #endregion

        #region【构造函数】

        public A_Station_Add(A_FrmStationInfo frm)
        {
            InitializeComponent();

            frmSi = frm;
            cmb_StationPacket.Text = "1";

            intStationAddress = frm.intStationAddress;
            GetStation_Add();

            //Czlt-2011-11-29 判断交直流是否启用
            IsOpenJHJ();
        }

        #endregion


     

        #region【方法：验证】

        private bool CheckingStation()
        {
            if (txt_StationAddress.Text.Trim().Equals(""))
            {
                SetTipsInfo(false, "分站号不能为空！");
                txt_StationAddress.Focus();
                txt_StationAddress.SelectAll();
                return false;
            }
            else
            {
                //Czlt-2011-01-25注销
                //if (Convert.ToInt32(txt_StationAddress.Text.Trim()) > 64)
                //{
                //    SetTipsInfo(false, "分站号不能大于64！");
                //    txt_StationAddress.Focus();
                //    txt_StationAddress.SelectAll();
                //    return false;
                //}
            }

            if (txt_StationPlace.Text.Trim().Equals(""))
            {
                SetTipsInfo(false, "分站安装位置不能为空！");
                txt_StationPlace.Focus();
                txt_StationPlace.SelectAll();
                return false;
            }

            if (intStationAddress == -1)
            {
                //判断系统中是否已经有该探头
                if (sbll.existsStationAddress(int.Parse(txt_StationAddress.Text)) > 0)
                {
                    SetTipsInfo(false, txt_StationAddress.Text + " 号传输分站已经存在！");
                    txt_StationAddress.Focus();
                    txt_StationAddress.SelectAll();
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region【方法：加载传输分站信息（新增）】

        /// <summary>
        /// 加载传输分站信息（新增）
        /// </summary>
        private void GetStation_Add()
        {
            if (intStationAddress != -1)    //新增
            {
                if (blIsUpDate)         //修改
                {

                    this.Text = "修改传输分站";
                    txt_StationAddress.Enabled = false;
                    bt_Station_Reset.Enabled = false;
                }
                else                            //查看
                {
                    this.Text = "查看传输分站";
                    gb_AddStationInfo.Enabled = false;
                    bt_Station_Save.Enabled = bt_Station_Reset.Enabled = false;
                }
                BindingStation(intStationAddress);
            }
        }

        #endregion

        #region【方法：绑定修改的传输分站】

        private void BindingStation(int intID)
        {
            //Czlt-2011-11-23 -交直流供电状态
            string strJHJEle = "";

            using (ds = sbll.GetStationInfo_Binding(intID))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        txt_StationAddress.Text = dt.Rows[0]["StationAddress"].ToString();
                        txt_StationPlace.Text = dt.Rows[0]["StationPlace"].ToString();
                        cmb_StationPacket.Text = dt.Rows[0]["StationGroup"].ToString();
                       // txt_StationTel.Text = dt.Rows[0]["StationTel"].ToString();
                        strJHJEle = dt.Rows[0]["StationTel"].ToString();

                        stationState = dt.Rows[0]["StationState"].ToString();

                        if (dt.Rows[0]["StationModel"].ToString().Equals("1"))      //A 版
                        {
                            rb_A.Checked = true;
                            if(!UpDateStationModel(txt_StationAddress.Text.Trim()))
                            {
                                gb_StationModel.Enabled=false;
                            }
                        }
                        else if (dt.Rows[0]["StationModel"].ToString().Equals("2")) // V2 版
                        {
                            rb_V2.Checked = true;
                        }
                        else
                        {
                            rb_CheckCard.Checked = true;
                        }

                        //Czlt-2011-11-23 关联交直流供电状态
                        if (strJHJEle.Trim().Equals("1"))
                        {
                            chkJHJEle.Checked = true;
                        }
                        else
                        {
                            chkJHJEle.Checked = false;
                        }
                    }
                }
            }
        }

        #endregion

        #region【方法：判断是否允许修改分站协议】

        private bool UpDateStationModel(string strStationAddress)
        {
            DataSet dsStation = sbll.GetStationHeadCount(strStationAddress);
            if (dsStation != null && ds.Tables.Count > 0)
            {
                if (dsStation.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region 【方法：设置提示信息】

        private void SetTipsInfo(bool blIsSuccess, string strInfo)
        {
            lb_StationTipsInfo.Text = strInfo;
            lb_StationTipsInfo.Visible = true;

            if (blIsSuccess)
            {
                lb_StationTipsInfo.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lb_StationTipsInfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion

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
            cmb_StationPacket.SelectedIndex = 0;
        }
        #endregion


        #region【事件：保存】

        private void bt_Station_Save_Click(object sender, EventArgs e)
        {
            string strJHJEle = "";
            if (!CheckingStation())
            {
                return;
            }

            //判断系统中该安装位置是否存在

            int intImpactCounts = 0;
            int intStationModel = 1;
            if (rb_V2.Checked)
            {
                intStationModel = 2;
            }
            else if(rb_CheckCard.Checked)
            {
                intStationModel = 3;
            }

            #region 【Czlt-2011-11-22 交换机关联传输分站】
            if (chkJHJEle.Checked)
            {
                strJHJEle = "1";
            }
            else
            {
                strJHJEle = "";
            }

            #endregion


            if (intStationAddress==-1)       //新增
            {
                //intImpactCounts = sbll.SaveStationInfo(Convert.ToInt32(txt_StationAddress.Text), txt_StationPlace.Text, txt_StationTel.Text,
                //    -1000, "通用接收器", int.Parse(cmb_StationPacket.Text.ToString()), intStationModel);
                intImpactCounts = sbll.SaveStationInfo(Convert.ToInt32(txt_StationAddress.Text), txt_StationPlace.Text, strJHJEle,
   2000, "通用接收器", int.Parse(cmb_StationPacket.Text.ToString()), intStationModel);
                if (intImpactCounts > 0)
                {
                    SetTipsInfo(true, " 保存成功！");
                    frmSi.IsSave = true;
                    //存入日志
                    LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "添加新分站，分站编号：" + txt_StationAddress.Text + "，安装位置：" + txt_StationPlace.Text);


                    //Czlt-2011-12-10 修改日期
                    sbll.UpdateTime();
                    if (!New_DBAcess.IsDouble)
                    {
                        frmSi.InitData();             // 重新加载
                    }
                    else
                    {
                        frmSi.intSelectModel = 1;
                        frmSi.HostBackRefresh(true);
                    }

                }
                else
                {
                    SetTipsInfo(false," 保存失败！");
                }
            }
            else                                                           //修改
            {
                if (stationState.Trim().Equals(""))
                {
                    stationState = "2000";
                }

                //intImpactCounts = sbll.UpdateStationInfo(Convert.ToInt32(txt_StationAddress.Text), txt_StationPlace.Text, txt_StationTel.Text,
                //    -1000, "通用接收器", int.Parse(cmb_StationPacket.Text.ToString()), intStationModel);
                intImpactCounts = sbll.UpdateStationInfo(Convert.ToInt32(txt_StationAddress.Text), txt_StationPlace.Text, strJHJEle,
    Convert.ToInt32(stationState), "通用接收器", int.Parse(cmb_StationPacket.Text.ToString()), intStationModel);
                if (intImpactCounts > 0)
                {

                    //Czlt-2011-12-10 修改日期
                    sbll.UpdateTime();
         
                    SetTipsInfo(true, " 修改成功！");
                    frmSi.IsSave = true;
                    //存入日志
                    LogSave.Messages("[A_FrmStationInfo]", LogIDType.UserLogID, "修改分站，分站编号：" + txt_StationAddress.Text + "，安装位置：" + txt_StationPlace.Text);
                    
                    if (!New_DBAcess.IsDouble)
                    {
                        frmSi.InitData();             // 重新加载
                    }
                    else
                    {
                        frmSi.intSelectModel = 1;
                        frmSi.HostBackRefresh(true);
                    }

                }
                else
                {
                    SetTipsInfo(false, " 修改失败！");
                }

            }
        }

        #endregion

        #region【事件：重置】

        private void bt_Station_Reset_Click(object sender, EventArgs e)
        {
            ClearStation();
        }

        #endregion

        #region【事件：返回】

        private void bt_Station_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region【事件：帮助】

        private void llb_Help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        #endregion

        #region【事件：关闭帮助】

        private void bt_CloseHelp_Click(object sender, EventArgs e)
        {
            pl_Help.Visible = false;
        }

        #endregion

        #region【方法：加载帮助】

        private string GetHelpText()
        {
            string strPath, strText;
            try
            {
                strPath = System.Environment.CurrentDirectory + "\\Help\\协议.txt";
                strText = "";

                if (File.Exists(strPath))
                {

                    FileStream fs = File.OpenRead(strPath);
                    byte[] b = new byte[1024];
                    while (fs.Read(b,0,b.Length)>0)
                    {
                        strText = strText+ Encoding.Default.GetString(b);
                    }
                }
            }
            catch
            {
                strText = "";
            }
            return strText;
        }

        #endregion

        #region【事件：帮助——传输协议】

        private void llb_Help_MouseEnter(object sender, EventArgs e)
        {
            tt1.ToolTipTitle = "传输协议";
            this.tt1.SetToolTip(this.llb_Help, GetHelpText());
        }

        #endregion

        #region【事件：帮助——分组编号】

        private void llb_StationPacket_MouseEnter(object sender, EventArgs e)
        {
            tt1.ToolTipTitle = "分组编号";
            this.tt1.SetToolTip(this.llb_StationPacket,GetStationPacketText());
        }

        #endregion

        #region【方法：加载帮助】

        private string GetStationPacketText()
        {
            string strPath, strText;
            try
            {
                strPath = System.Environment.CurrentDirectory + "\\Help\\分组编号.txt";
                strText = "";

                if (File.Exists(strPath))
                {

                    FileStream fs = File.OpenRead(strPath);
                    byte[] b = new byte[1024];
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        strText = strText + Encoding.Default.GetString(b);
                    }
                }
            }
            catch
            {
                strText = "";
            }
            return strText;
        }

        #endregion

        private void txt_StationPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_StationTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }


        #region 【Czlt-2011-05-25 关联交直流供电情况】
        private void chkJHJEle_CheckedChanged(object sender, EventArgs e)
        {
            if (!txt_StationAddress.Text.Trim().Equals(""))
            {
                using (ds = sbll.GetStationInfo_Binding(Convert.ToInt32(txt_StationAddress.Text.Trim())))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            string staGroup = dt.Rows[0]["StationGroup"].ToString();
                            string strJHJ = dt.Rows[0]["StationTel"].ToString();
                            string strAddress = dt.Rows[0]["StationAddress"].ToString();
                            if (strAddress.Trim().Equals(txt_StationAddress.Text.Trim()))
                                return;
                            if (cmb_StationPacket.Text.Trim().Equals(staGroup) && strJHJ.Trim().Equals("1"))
                            {
                                lb_StationTipsInfo.Text = staGroup + " 组通讯中" + strAddress + " 号传输分站已经关联交换机供电情况!";
                            }

                        }
                    }
                }
            }
        }
        #endregion

        #region 【Czlt-2011-11-29 判断是否启用交直流】
        private void IsOpenJHJ()
        {
            if (File.Exists(Application.StartupPath + "\\PowerManager.xml"))
            {
                XmlDocument dom = new XmlDocument();
                dom.Load(Application.StartupPath + "\\PowerManager.Xml");
                string staID = dom.SelectSingleNode("Root/IsOpen").InnerText;
                if (staID.ToLower().Trim().Equals("true"))
                {
                    string type = "";
                    if (File.Exists(Application.StartupPath + "\\CommType.xml"))
                    {
                        XmlDocument czltDom = new XmlDocument();
                        czltDom.Load(Application.StartupPath + "\\CommType.Xml");
                        type = czltDom.SelectSingleNode("comm/commType").InnerText;
                    }

                    //判断是否为环网  1-环网 
                    if (type.Trim().Equals("1"))
                    {
                        lblJHJ.Visible = true;
                        chkJHJEle.Visible = true;
                    }
                    else
                    {
                        lblJHJ.Visible = false;
                        chkJHJEle.Visible = false;
                    }

                }
                else
                {
                    lblJHJ.Visible = false;
                    chkJHJEle.Visible = false;

                }
            }
            else
            {
                lblJHJ.Visible = false;
                chkJHJEle.Visible = false;
 
            }
        }
        #endregion
    }
}
