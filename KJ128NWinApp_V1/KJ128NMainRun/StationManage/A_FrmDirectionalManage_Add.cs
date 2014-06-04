using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using DegonControlLib;
using KJ128NDataBase;

namespace KJ128NMainRun.StationManage
{
    public partial class A_FrmDirectionalManage_Add : Form
    {

        #region【声明】

        private A_StationBLL sbll = new A_StationBLL();

        private DataSet ds;

        private A_FrmDirectionalManage frm_Dm;

        /// <summary>
        /// 保存要修改的方向性ID，-1：新增
        /// </summary>
        private int tempCodeSenderDirlID = -1;

        private string strStaHead = "";

        #endregion

        #region【构造函数】

        public A_FrmDirectionalManage_Add(A_FrmDirectionalManage frm)
        {
            InitializeComponent();
            tempCodeSenderDirlID = frm.tempCodeSenderDirlID;
            frm_Dm = frm;

            //清空信息
            ClearDirectional();

            if (frm.blIsSee)    //查看
            {
               this.Text = "查看方向性";

                tvc_BeginStaHead_Add.Enabled = tvc_EndStaHead_Add.Enabled = false;
                bt_Directional_Reset.Enabled = false;
                bt_Directional_Save.Enabled = gb_AddDirectionalInfo.Enabled = false;
                lb_DirectionalTipsInfo2.Enabled = lb_DirectionalTipsInfo.Enabled = false;

                GetDirectionalTable(tempCodeSenderDirlID);
            }
            else if(tempCodeSenderDirlID==-1)   //新增
            {
                this.Text = "新增方向性";

                tvc_BeginStaHead_Add.Enabled = tvc_EndStaHead_Add.Enabled = true;
                bt_Directional_Save.Enabled = bt_Directional_Reset.Enabled = gb_AddDirectionalInfo.Enabled = true;
                lb_DirectionalTipsInfo2.Enabled = lb_DirectionalTipsInfo.Enabled = true;
            }
            else
            {
                this.Text = "修改方向性";

                tvc_BeginStaHead_Add.Enabled = tvc_EndStaHead_Add.Enabled = false;
                bt_Directional_Reset.Enabled = false;
                bt_Directional_Save.Enabled = gb_AddDirectionalInfo.Enabled = true;
                lb_DirectionalTipsInfo2.Enabled = lb_DirectionalTipsInfo.Enabled = true;

                GetDirectionalTable(tempCodeSenderDirlID);
            }
        }

        #endregion

        #region【方法: 获取和绑定要修改方向性的信息】

        /// <summary>
        /// 获取和绑定要修改方向性的信息
        /// </summary>
        private void GetDirectionalTable(int intTempID)
        {
            using (ds = new DataSet())
            {
                ds = sbll.GetDirectionalInfo_Binding(intTempID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string strBeginStationAddress, strBeginStationHeadAddress, strEndStationAddress, strEndStationHeadAddress;

                    strBeginStationAddress = ds.Tables[0].Rows[0]["BeginStationAddress"].ToString();
                    strBeginStationHeadAddress = ds.Tables[0].Rows[0]["BeginStationHeadAddress"].ToString();
                    strEndStationAddress = ds.Tables[0].Rows[0]["EndStationAddress"].ToString();
                    strEndStationHeadAddress = ds.Tables[0].Rows[0]["EndStationHeadAddress"].ToString();

                    txt_BeginStationAddress.Text = strBeginStationAddress;
                    txt_BeginStationHeadAddress.Text = strBeginStationHeadAddress;
                    txt_EndStationAddress.Text = strEndStationAddress;
                    txt_EndStationHeadAddress.Text = strEndStationHeadAddress;
                    txt_Directional_Add.Text = ds.Tables[0].Rows[0]["Directional"].ToString();

                    if (tvc_BeginStaHead_Add.Nodes.Count > 0)
                    {
                        if (tvc_BeginStaHead_Add.Nodes.ContainsKey("S" + strBeginStationAddress))
                        {
                            if (tvc_BeginStaHead_Add.Nodes["S" + strBeginStationAddress].Nodes.ContainsKey("H" + strBeginStationHeadAddress))
                            {
                                tvc_BeginStaHead_Add.SelectedNode = tvc_BeginStaHead_Add.Nodes["S" + strBeginStationAddress].Nodes["H" + strBeginStationHeadAddress];
                                tvc_BeginStaHead_Add.SetSelectNodeColor();
                                tvc_BeginStaHead_Add.SelectedNode.ForeColor = Color.Blue;
                                //tvc_BeginStaHead_Add.SelectedNode.BackColor = Color.FromArgb(44, 67, 132);
                            }
                        }
                    }
                    if (tvc_EndStaHead_Add.Nodes.Count > 0)
                    {
                        if (tvc_EndStaHead_Add.Nodes.ContainsKey("S" + strEndStationAddress))
                        {
                            if (tvc_EndStaHead_Add.Nodes["S" + strEndStationAddress].Nodes.ContainsKey("H" + strEndStationHeadAddress))
                            {
                                tvc_EndStaHead_Add.SelectedNode = tvc_EndStaHead_Add.Nodes["S" + strEndStationAddress].Nodes["H" + strEndStationHeadAddress];
                                tvc_EndStaHead_Add.SetSelectNodeColor();
                                tvc_EndStaHead_Add.SelectedNode.ForeColor = Color.Blue;
                            }
                        }
                    }
                    strStaHead = txt_BeginStationAddress.Text + "," + txt_BeginStationHeadAddress.Text + ";" + txt_EndStationAddress.Text + "," + txt_EndStationHeadAddress.Text;
                }
            }

        }

        #endregion

        #region【方法：验证方向性】

        private bool CheckingDirectionalInfo()
        {
            if (txt_BeginStationAddress.Text.Equals(""))
            {
                SetTipsInfo(false, "起始分站不能为空！");
                return false;
            }
            if (txt_EndStationAddress.Text.Equals(""))
            {
                SetTipsInfo(false, "终止分站不能为空！");
                return false;
            }
            if (txt_BeginStationAddress.Text.Equals(txt_EndStationAddress.Text) && txt_BeginStationHeadAddress.Text.Equals(txt_EndStationHeadAddress.Text))
            {
                SetTipsInfo(false, "起始分站和终止分站不能相同！");
                return false;
            }
            if (txt_Directional_Add.Text.Equals(""))
            {
                SetTipsInfo(false, "方向性描述不能为空！");
                return false;
            }

            string strStaHead_Temp = txt_BeginStationAddress.Text + "," + txt_BeginStationHeadAddress.Text + ";" + txt_EndStationAddress.Text + "," + txt_EndStationHeadAddress.Text;

            if (tempCodeSenderDirlID == -1 || tempCodeSenderDirlID != -1 && strStaHead != strStaHead_Temp)
            {
                using (ds = new DataSet())
                {
                    ds = sbll.IsDirectionalBeings(txt_Directional_Add.Text.Trim());
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            SetTipsInfo(false, "系统中已存在该方向性描述，请重新选择起始设置！");
                            return false;
                        }
                    }
                }
            }



            if (tempCodeSenderDirlID == -1 || tempCodeSenderDirlID != -1 && strStaHead != strStaHead_Temp)
            {
                using (ds = new DataSet())
                {
                    ds = sbll.IsDirectionalBeing(txt_BeginStationAddress.Text + "," + txt_BeginStationHeadAddress.Text + ":" + txt_EndStationAddress.Text + "," + txt_EndStationHeadAddress.Text);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            SetTipsInfo(false, "系统中已存在该方向性，请重新选择起始分站、终止分站！");
                            return false;
                        }
                    }
                }
            }


            return true;
        }

        #endregion

        #region【方法：添加 方向性信息】

        private bool SaveDirectional()
        {
            int intImpactCounts = 0;
            intImpactCounts = sbll.SaveDirectionalInfo(txt_Directional_Add.Text.Trim(), Convert.ToInt32(txt_BeginStationAddress.Text), Convert.ToInt32(txt_BeginStationHeadAddress.Text),
                        Convert.ToInt32(txt_EndStationAddress.Text), Convert.ToInt32(txt_EndStationHeadAddress.Text));
            if (intImpactCounts > 0)
            {
                SetTipsInfo(true, "保存成功！");
                //存入日志
                LogSave.Messages("[A_FrmDirectionalManage]", LogIDType.UserLogID, "新增方向性信息，起始传输分站号为：" + txt_BeginStationAddress.Text + "，起始读卡分站号为：" + txt_BeginStationHeadAddress.Text +
                    "，终止传输分站号为：" + txt_EndStationAddress.Text + "，终止读卡分站号为：" + txt_EndStationHeadAddress.Text + "，方向性描述为：" + txt_Directional_Add.Text);
                return true;
            }
            
            else
            {
                SetTipsInfo(false, "保存失败！");
                return false;
            }
        }

        #endregion

        #region【方法：修改 方向性信息】

        private bool UpDateDirectional()
        {
            int intImpactCounts = 0;
            intImpactCounts = sbll.UpDateDirectionalInfo(txt_Directional_Add.Text.Trim(), Convert.ToInt32(txt_BeginStationAddress.Text), Convert.ToInt32(txt_BeginStationHeadAddress.Text),
                        Convert.ToInt32(txt_EndStationAddress.Text), Convert.ToInt32(txt_EndStationHeadAddress.Text));
            if (intImpactCounts > 0)
            {
                strStaHead = txt_BeginStationAddress.Text + "," + txt_BeginStationHeadAddress.Text + ";" + txt_EndStationAddress.Text + "," + txt_EndStationHeadAddress.Text;

                SetTipsInfo(true, "修改成功！");

                //存入日志
                LogSave.Messages("[A_FrmDirectionalManage]", LogIDType.UserLogID, "修改方向性信息，起始传输分站号为：" + txt_BeginStationAddress.Text + "，起始读卡分站号为：" + txt_BeginStationHeadAddress.Text +
                    "，终止传输分站号为：" + txt_EndStationAddress.Text + "，终止读卡分站号为：" + txt_EndStationHeadAddress.Text + "，方向性描述为：" + txt_Directional_Add.Text);
                return true;
            }
            
            else
            {
                SetTipsInfo(false, "修改失败！");
                return false;
            }
        }

        #endregion

        #region【方法：清空 方向性信息】

        /// <summary>
        /// 清空 方向性信息
        /// </summary>
        private void ClearDirectional()
        {

            LoadTreeView_StaHead(tvc_BeginStaHead_Add, false);
            LoadTreeView_StaHead(tvc_EndStaHead_Add, false);

            tvc_BeginStaHead_Add.SelectedNode = null;
            tvc_EndStaHead_Add.SelectedNode = null;
            txt_BeginStationAddress.Text = txt_BeginStationHeadAddress.Text = txt_EndStationAddress.Text = txt_EndStationHeadAddress.Text = txt_Directional_Add.Text = "";

        }
        #endregion

        #region 【方法：初始化探头树】

        /// <summary>
        /// 自定义树的表的行结构
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="parentid"></param>
        /// <param name="isChild"></param>
        /// <param name="isUserNum"></param>
        /// <param name="num"></param>
        private void SetDataRow(ref DataRow dr, string id, string name, string parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }

        /// <summary>
        /// 初始化部门树
        /// </summary>
        private void LoadTreeView_StaHead(TreeViewControl tvc, bool blIsAll)
        {
            if (tvc.Nodes.Count > 0)
            {
                tvc.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                if (blIsAll)    //主节点是“所有”
                {
                    ds = sbll.GetStaHeadInfo();
                }
                else            //无主节点
                {
                    ds = sbll.GetStaHeadInfo_Binding();
                }

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc.BuildMenusEntity();
                }

                if (blIsAll)
                {
                    DataRow dr = dt.NewRow();
                    SetDataRow(ref dr, "0", "所有", "-1", false, false, 0);
                    dt.Rows.Add(dr);
                }

                tvc.DataSouce = dt;
                tvc.LoadNode("人");
            }

            tvc.ExpandAll();
            if (blIsAll)
            {
                tvc.SelectedNode = tvc.Nodes[0];
                tvc.SetSelectNodeColor();
                // tvc.Focus();
            }
        }

        #endregion

        #region 【方法：设置提示信息】

        private void SetTipsInfo(bool blIsSuccess, string strInfo)
        {
            lb_DirectionalTipsInfo.Text = strInfo;
            lb_DirectionalTipsInfo.Visible = true;

            if (blIsSuccess)
            {
                lb_DirectionalTipsInfo.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lb_DirectionalTipsInfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion


        #region【事件：保存】

        private void bt_Directional_Save_Click(object sender, EventArgs e)
        {
            if (CheckingDirectionalInfo())
            {
                if (tempCodeSenderDirlID == -1)         //新增
                {
                    if (SaveDirectional())
                    {
                        SetTipsInfo(true, "保存成功！");

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frm_Dm.Refresh_Directional();
                        }
                        else                                //热备版，启用定时器
                        {
                            frm_Dm.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                       SetTipsInfo(false, "保存失败！");
                    }
                }
                else                                    //修改
                {
                    if (UpDateDirectional())
                    {
                        SetTipsInfo(true, "修改成功！");

                        if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                        {
                            frm_Dm.Refresh_Directional();
                        }
                        else                                //热备版，启用定时器
                        {
                            frm_Dm.HostBackRefresh(true);
                        }
                    }
                    else
                    {
                        SetTipsInfo(false, "修改失败！");
                    }
                }
            }
        }

        #endregion

        #region【事件：重置】

        private void bt_Directional_Reset_Click(object sender, EventArgs e)
        {
            ClearDirectional();
        }

        #endregion

        #region【事件：返回】

        private void bt_Directional_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region【事件：更改起始分站——新增】

        private void tvc_BeginStaHead_Add_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && !e.Node.Name.Substring(0, 1).Equals("S"))
            {
                txt_BeginStationAddress.Text = e.Node.Parent.Name.Substring(1);
                txt_BeginStationHeadAddress.Text = e.Node.Name.Substring(1);
            }
            else
            {
                txt_BeginStationAddress.Text = "";
                txt_BeginStationHeadAddress.Text = "";
            }

        }

        #endregion

        #region【事件：更改终止分站——新增】

        private void tvc_EndStaHead_Add_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && !e.Node.Name.Substring(0, 1).Equals("S"))
            {
                txt_EndStationAddress.Text = e.Node.Parent.Name.Substring(1);
                txt_EndStationHeadAddress.Text = e.Node.Name.Substring(1);
            }
            else
            {
                txt_EndStationAddress.Text = "";
                txt_EndStationHeadAddress.Text = "";
            }
        }

        #endregion

        private void txt_BeginStationAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_BeginStationHeadAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_EndStationAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_EndStationHeadAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_Directional_Add_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }


    }
}
