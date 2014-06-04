using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.AreaManage
{
    public partial class A_FrmAreaManage_AddTerSet : Form
    {

        #region【声明】

        private A_AreaBLL areaBll = new A_AreaBLL();

        private DataSet ds;

        private int tempTerritorialID_TerSet = -1;

        private A_FrmAreaManage frmAm;

        /// <summary>
        /// 保存配置的区域范围的探头
        /// </summary>
        private string strTerSet = "";

        private Color clColore = Color.Green;

        #endregion


        #region【构造函数】

        public A_FrmAreaManage_AddTerSet(A_FrmAreaManage frm)
        {
            InitializeComponent();

            LoadStaHead_ALL();          //获取系统探头
            tempTerritorialID_TerSet = frm.tempTerritorialID_TerSet;
            frmAm = frm;
            if (frmAm.blIsSee_TerSet)   //查看
            {
                bt_TerSet_Save.Enabled = bt_TerSet_Reset.Enabled = gb_AddTerSetInfo.Enabled = false;
                lb_TerSetTipsInfo.Visible = lb_TerSetTipsInfo2.Visible = false;
                chb_IsTer.Checked = false;
            }
            else                        //配置
            {
                chb_IsTer.Checked = false;
                bt_TerSet_Save.Enabled = bt_TerSet_Reset.Enabled = gb_AddTerSetInfo.Enabled = true;
                lb_TerSetTipsInfo2.Visible = true;
                lb_TerSetTipsInfo.Visible = false;
            }
            GetTerSet_StaHead(frmAm.tempTerritorialID_TerSet);
        }

        #endregion


        #region【方法：保存】

        private bool SaveTerSet(TreeNode trTemp)
        {
            int intTer;
            foreach (TreeNode tr in trTemp.Nodes)
            {
                if (tr.Nodes.Count > 0)
                {
                    SaveTerSet(tr);
                }
                else
                {
                    if (tr.ForeColor == clColore)       //是区域口
                    {
                        intTer = 1;
                    }
                    else                                //不是区域口
                    {
                        intTer = 0;
                    }
                    if (tempTerritorialID_TerSet != -1)
                    {
                        areaBll.SaveTerSet(tempTerritorialID_TerSet, Convert.ToInt32(tr.Name.Substring(1)), intTer);
                        if (strTerSet.Equals(""))
                        {
                            strTerSet = tr.Name.Substring(1);
                        }
                        else
                        {
                            strTerSet += "," + tr.Name.Substring(1);
                        }
                    }
                }
            }
            return true;
        }

        #endregion

        #region【方法：加载区域范围的已配置探头】

        private void GetTerSet_StaHead(int intTerID)
        {
            if (tvc_StationHead_Ter.Nodes.Count > 0)
            {
                tvc_StationHead_Ter.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = areaBll.GetTerSet_StaHead(intTerID);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_StationHead_Ter.BuildMenusEntity();
                }

                tvc_StationHead_Ter.DataSouce = dt;
                tvc_StationHead_Ter.LoadNode("人");
            }

            tvc_StationHead_Ter.ExpandAll();

            string strStation, strStationHead;
            using (ds = new DataSet())
            {
                ds = areaBll.GetTerriorialEnter(intTerID);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drc in ds.Tables[0].Rows)
                        {
                            strStation = drc[1].ToString();
                            strStationHead = drc[0].ToString();

                            if (tvc_StationHead_Ter.Nodes.ContainsKey(strStation))
                            {
                                if (tvc_StationHead_Ter.Nodes[strStation].Nodes.ContainsKey(strStationHead))
                                {
                                    tvc_StationHead_Ter.Nodes[strStation].Nodes[strStationHead].ForeColor = clColore;
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region【方法：获取系统探头树】

        private void LoadStaHead_ALL()
        {
            if (tvc_StationHead_All.Nodes.Count > 0)
            {
                tvc_StationHead_All.Nodes.Clear();
            }
            DataTable dt;
            using (ds = new DataSet())
            {
                ds = areaBll.GetStaHead_ALL();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = tvc_StationHead_All.BuildMenusEntity();
                }

                tvc_StationHead_All.DataSouce = dt;
                tvc_StationHead_All.LoadNode("人");
            }

            tvc_StationHead_All.ExpandAll();
            if (tvc_StationHead_All.Nodes.Count > 0)
            {
                tvc_StationHead_All.SelectedNode = tvc_StationHead_All.Nodes[0];
                tvc_StationHead_All.SetSelectNodeColor();
            }

        }

        #endregion

        #region 【方法：设置提示信息】

        private void SetTipsInfo(Label lb, bool blIsSuccess, string strInfo)
        {
            lb.Text = strInfo;
            lb.Visible = true;
            if (blIsSuccess)
            {
                lb.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lb.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion


        #region【事件：保存】

        private void bt_TerSet_Save_Click(object sender, EventArgs e)
        {
            strTerSet = "";
            int intImpactCounts = 0;

            foreach (TreeNode tr in tvc_StationHead_Ter.Nodes)
            {
                if (tr.Nodes.Count > 0)
                {
                    SaveTerSet(tr);
                }
            }
            intImpactCounts=areaBll.UpDateTerSet(tempTerritorialID_TerSet, strTerSet);

            
            SetTipsInfo(lb_TerSetTipsInfo, true, "保存成功！");

            //Czlt-2011-12-10 跟新时间
            areaBll.UpdateTime();


            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
            {
                frmAm.Refresh_TerSet();
            }
            else                                //热备版，启用定时器
            {
                frmAm.HostBackRefresh(true);
            }
        }

        #endregion

        #region【事件：重置】

        private void bt_TerSet_Reset_Click(object sender, EventArgs e)
        {
            LoadStaHead_ALL();
            tvc_StationHead_Ter.Nodes.Clear();
        }

        #endregion

        #region【事件：返回】

        private void bt_TerSet_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region【事件：添加探头——区域范围】

        private void bt_Right_Click(object sender, EventArgs e)
        {
            bool blIsTer = chb_IsTer.Checked;   //是否是区域口，true：是区域口；false：不是区域口

            if (tvc_StationHead_All.SelectedNode != null)
            {
                string strStation, strStationPlace, strStaHeadID, strstaHeadPlace;
                TreeNode tn;
                tn = tvc_StationHead_All.SelectedNode;

                if (tvc_StationHead_All.SelectedNode.Name.Substring(0, 1).Equals("H"))  //添加的是单个探头信息
                {
                    strStation = tvc_StationHead_All.SelectedNode.Parent.Name;  //选中节点的分站编号(包含"S")
                    strStaHeadID = tvc_StationHead_All.SelectedNode.Name;         //选中节点的探头编号(包含"H")
                    strStationPlace = tvc_StationHead_All.SelectedNode.Parent.Text;//选中节点的分站位置
                    strstaHeadPlace = tvc_StationHead_All.SelectedNode.Text;      //选中节点的探头位置

                    if (tvc_StationHead_Ter.Nodes.ContainsKey(strStation))
                    {
                        if (tvc_StationHead_Ter.Nodes[strStation].Nodes.ContainsKey(strStaHeadID))
                        {
                            return;
                        }
                        else
                        {
                            tvc_StationHead_Ter.Nodes[strStation].Nodes.Add(strStaHeadID, strstaHeadPlace);
                        }
                    }
                    else
                    {
                        tvc_StationHead_Ter.Nodes.Add(strStation, strStationPlace);
                        tvc_StationHead_Ter.Nodes[strStation].Nodes.Add(strStaHeadID, strstaHeadPlace);

                    }

                    if (blIsTer)
                    {
                        tvc_StationHead_Ter.Nodes[strStation].Nodes[strStaHeadID].ForeColor = clColore;
                    }
                }
                else if (tvc_StationHead_All.SelectedNode.Name.Substring(0, 1).Equals("S"))  //添加的是整个分站信息
                {
                    if (tvc_StationHead_All.SelectedNode.Nodes.Count > 0)
                    {

                        strStation = tvc_StationHead_All.SelectedNode.Name;
                        strStationPlace = tvc_StationHead_All.SelectedNode.Text;
                        if (!tvc_StationHead_Ter.Nodes.ContainsKey(strStation))
                        {
                            tvc_StationHead_Ter.Nodes.Add(strStation, strStationPlace);
                        }
                        foreach (TreeNode tr in tvc_StationHead_All.SelectedNode.Nodes)
                        {
                            strStaHeadID = tr.Name;
                            strstaHeadPlace = tr.Text;
                            if (!tvc_StationHead_Ter.Nodes[strStation].Nodes.ContainsKey(strStaHeadID))
                            {
                                tvc_StationHead_Ter.Nodes[strStation].Nodes.Add(strStaHeadID, strstaHeadPlace);
                                if (blIsTer)
                                {
                                    tvc_StationHead_Ter.Nodes[strStation].Nodes[strStaHeadID].ForeColor = clColore;
                                }
                            }
                        }
                    }

                }
                tvc_StationHead_Ter.ExpandAll();
            }
        }

        #endregion

        #region【事件：移除探头——区域范围】

        private void bt_Left_Click(object sender, EventArgs e)
        {
            if (tvc_StationHead_Ter.SelectedNode != null)
            {
                string strStation, strStaHead;
                if (tvc_StationHead_Ter.SelectedNode.Name.Substring(0, 1).Equals("H"))      //移除的是单个探头
                {
                    strStation = tvc_StationHead_Ter.SelectedNode.Parent.Name;      //选中节点的分站编号(包含"S")
                    strStaHead = tvc_StationHead_Ter.SelectedNode.Name;             //选中节点的探头编号(包含"H")
                    if (tvc_StationHead_Ter.Nodes[strStation].Nodes.Count > 1)
                    {
                        tvc_StationHead_Ter.Nodes[strStation].Nodes.RemoveByKey(strStaHead);
                    }
                    else
                    {
                        tvc_StationHead_Ter.Nodes.RemoveByKey(strStation);
                    }
                }
                else
                {
                    tvc_StationHead_Ter.Nodes.Remove(tvc_StationHead_Ter.SelectedNode);
                }
            }
        }

        #endregion


    }
}
