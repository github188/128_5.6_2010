using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NModel;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.PathManage
{
    public partial class FrmPathDetailAdd : Form
    {
        #region 【自定义参数】
        /// <summary>
        /// 巡检配置窗体对象
        /// </summary>
        private FrmPathManage m_frmPathManage;
        /// <summary>
        /// 操作类型  1添加  2修改
        /// </summary>
        private int m_type;

        private DataGridViewRow m_dgvRow;
        /// <summary>
        /// 获取的数据
        /// </summary>
        public DataGridViewRow DgvRow
        {
            set { m_dgvRow = value; }
        }
        /// <summary>
        /// 路径逻辑对象
        /// </summary>
        private PathInfoBll pathinfoBll = new PathInfoBll();
        /// <summary>
        /// 要添加的路径数据
        /// </summary>
        private ArrayList alPathDetailAdd = new ArrayList();
        /// <summary>
        /// 要删除的路径数据
        /// </summary>
        private ArrayList alPathDetailDelete = new ArrayList();
        /// <summary>
        /// 原始的路径数据
        /// </summary>
        private ArrayList alPathDetail = new ArrayList();
        #endregion

        #region 【构造函数】
        public FrmPathDetailAdd(int type,FrmPathManage frmPathManage)
        {
            InitializeComponent();
            m_frmPathManage = frmPathManage;
            m_type = type;
        }
        #endregion

        #region 【自定义方法】

        #region 【方法：保存前期方法】
        /// <summary>
        /// 保存前期判断
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if (txtPathID.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入巡检路线编号", Color.Blue);
                return false;
            }
            if (txtPathName.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入巡检路线名称", Color.Blue);
                return false;
            }
            if (listStation.Items.Count<=0)
            {
                SetShowInfo("路线内读卡分站最少要保留一个", Color.Blue);
                return false;
            }
            return true;
        }
        #endregion

        #region 【方法：获取分站 树信息】
        /// <summary>
        /// 设置班次的树控件信息
        /// </summary>
        private void SetStationTreeView(string pathNO)
        {
            treeViewStation.DataSouce = pathinfoBll.getStationTreeViewTable(pathNO);
            treeViewStation.Nodes.Clear();
            treeViewStation.LoadNode("");
            treeViewStation.ExpandAll();
        }

        /// <summary>
        /// 设置班次的树控件信息
        /// </summary>
        private void SetStationTreeView()
        {
            treeViewStation.DataSouce = pathinfoBll.getStationTreeViewTable();
            treeViewStation.Nodes.Clear();
            treeViewStation.LoadNode("");
            treeViewStation.ExpandAll();
        }
        #endregion 【方法：获取分站 树信息】

        #region 【方法：获取listbox读卡分站信息】
        /// <summary>
        /// 设置listbox读卡分站
        /// </summary>
        /// <param name="strPathNo"></param>
        private void SetListStation(string strPathNo)
        {
            alPathDetail.Clear();
            listStation.Items.Clear();
            DataTable dt = new DataTable();
            dt = pathinfoBll.getStationHeadTable(strPathNo);
            int i = 0;
            if (dt!=null && dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string strStationHeadID = dr["ID"].ToString();
                    string strStationHeadPlace = dr["StationHeadPlace"].ToString();
                    listStation.Items.Add(strStationHeadID + " " + strStationHeadPlace);
                    string[] strAddress = strStationHeadID.Split('.');
                    PathDetailModel pModel = new PathDetailModel();
                    pModel.PathNo = txtPathID.Text;
                    pModel.PathID = i;
                    pModel.StationAddress = int.Parse(strAddress[0]);
                    pModel.StationHeadAddress =int.Parse(strAddress[1]);
                    alPathDetail.Add(pModel);
                    alPathDetailAdd.Add(pModel);
                    i++;
                }
            }
        }
        #endregion

        #region 【方法：设置显示提示信息】
        /// <summary>
        /// 设置显示提示信息
        /// </summary>
        /// <param name="strMessage">显示信息</param>
        /// <param name="c">颜色</param>
        private void SetShowInfo(string strMessage, Color c)
        {
            labMessage.Visible = true;
            labMessage.ForeColor = c;
            labMessage.Text = strMessage;
        }
        #endregion

        #region 【方法：显示数据在文本框中】
        /// <summary>
        /// 显示数据到文本矿中
        /// </summary>
        private void BindText()
        {
            try
            {
                txtPathID.Text = m_dgvRow.Cells["pathNo"].Value.ToString();
                txtPathName.Text = m_dgvRow.Cells["PathName"].Value.ToString();
                txtID.Text = m_dgvRow.Cells["pID"].Value.ToString();
            }
            catch
            { }
        }
        #endregion

        #endregion

        #region 【系统事件方法】

        #region 【窗体加载】
        private void FrmPathDetailAdd_Load(object sender, EventArgs e)
        {
            string strPathNo = "";
            switch (m_type)
            {
                case 1://添加
                    this.Text = "新增巡检路径";
                    strPathNo = "";
                    SetStationTreeView();
                    break;
                case 2://修改
                    this.Text = "修改巡检路径";
                    BindText();
                    strPathNo = txtPathID.Text;
                    txtPathID.Enabled = false;
                    SetStationTreeView();
                    SetListStation(strPathNo);
                    break;
                default://查看
                    this.Text = "查看巡检路径";
                    BindText();
                    strPathNo = txtPathID.Text;
                    SetStationTreeView();
                    SetListStation(strPathNo);
                    break;
            }
            
        }
        #endregion

        #region 【事件方法：保存数据】
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                PathInfoModel pathInfoModel = new PathInfoModel();
                pathInfoModel.PathNo = txtPathID.Text;
                pathInfoModel.PathName = txtPathName.Text;
                pathInfoModel.Remark = "";
                string strMessage = "";
                int rowCount = 0;
                switch (m_type)
                {
                    case 1:
                        rowCount = pathinfoBll.InsertPathInfo(pathInfoModel, out strMessage);
                        break;
                    case 2:
                        pathInfoModel.Id = int.Parse(txtID.Text);
                        rowCount = pathinfoBll.UpdatePathInfo(pathInfoModel, out strMessage);
                        break;
                }
                if (strMessage.Equals("Succeeds"))
                {
                    if (rowCount > 0)
                    {
                        try
                        {
                            for (int i = 0; i < alPathDetail.Count; i++)
                            {
                                PathDetailModel pathDetail = (PathDetailModel)alPathDetail[i];
                                pathDetail.PathNo = txtPathID.Text;
                                pathinfoBll.DeletePathDetail(pathDetail.PathNo, pathDetail.StationAddress, pathDetail.StationHeadAddress);
                            }
                            for (int i = 0; i < alPathDetailAdd.Count; i++)
                            {
                                PathDetailModel pathDetail1 = (PathDetailModel)alPathDetailAdd[i];
                                pathDetail1.PathNo = txtPathID.Text;
                                pathDetail1.PathInterval = i + 1;
                                pathinfoBll.InsertPathDetail(pathDetail1);
                            }
                            SetShowInfo("保存成功", Color.Black);

                            if (!New_DBAcess.IsDouble)          //单机版，直接刷新
                            {
                                m_frmPathManage.SetTreeViewPath();
                                m_frmPathManage.BindData("");
                            }
                            else                                //热备版，启用定时器
                            {
                                m_frmPathManage.HostBackRefresh(true);
                            }
                            //this.Close();
                        }
                        catch
                        {
                            SetShowInfo("保存失败", Color.Black);
                        }
                    }
                    else
                    {
                        SetShowInfo("路径添加重复", Color.Red);
                    }
                }
                else
                {
                    SetShowInfo("保存路径失败", Color.Black);
                }
            }
        }
        #endregion

        #region 【事件方法：重置数据】
        private void btnReset_Click(object sender, EventArgs e)
        {
            alPathDetailAdd.Clear();
            alPathDetailDelete.Clear();
            labMessage.Visible = false;
            switch (m_type)
            {
                case 1:
                    txtPathID.Text = "";
                    txtPathName.Text = "";
                    listStation.Items.Clear();
                    SetStationTreeView();
                    break;
                case 2:
                    BindText();
                    SetStationTreeView(txtPathID.Text);
                    SetListStation(txtPathID.Text);
                    break;
            }
        }
        #endregion

        #region 【事件方法：关闭窗体】
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 【事件方法：从左往右增加】
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (treeViewStation.SelectedNode==null || treeViewStation.SelectedNode.Level==0)
            {
                SetShowInfo("请选择要增加的读卡分站", Color.Blue);
                return;
            }
            labMessage.Visible = false;
            if (txtPathID.Text.Trim().Equals(""))
            {
                SetShowInfo("请输入路径编号", Color.Blue);
                return;
            }

            //增加到列表框中
            TreeNode node = treeViewStation.SelectedNode;
            string[] strAddress = node.Name.Trim().Split('.');

            //增加到临时增加列表中
            PathDetailModel pathDetailModel = new PathDetailModel();
            pathDetailModel.PathNo = txtPathID.Text;
            pathDetailModel.StationAddress =int.Parse(strAddress[0]);
            pathDetailModel.StationHeadAddress = int.Parse(strAddress[1]);

            if (listStation.Items.Count > 0)
            {
                if (listStation.SelectedIndex > 0)
                {
                    listStation.Items.Insert(listStation.SelectedIndex + 1, node.Name + " " + node.Text);
                    pathDetailModel.PathID = listStation.SelectedIndex + 1;
                    try
                    {
                        alPathDetailAdd.Insert(listStation.SelectedIndex + 1,pathDetailModel);
                    }
                    catch { }
                    for (int i = pathDetailModel.PathID; i < alPathDetailAdd.Count; i++)
                    {
                        PathDetailModel pathDetailaddTemp = (PathDetailModel)alPathDetailAdd[i];
                        pathDetailaddTemp.PathID = i;
                    }
                }
                else
                {
                    pathDetailModel.PathID = listStation.Items.Count;
                    listStation.Items.Add(node.Name + " " + node.Text);
                    try
                    {
                        alPathDetailAdd.Add(pathDetailModel);
                    }
                    catch { }
                }
            }
            else
            {
                pathDetailModel.PathID = listStation.Items.Count;
                listStation.Items.Add(node.Name + " " + node.Text);
                try
                {
                    alPathDetailAdd.Add(pathDetailModel);
                }
                catch { }
            }
        }
        #endregion

        #region 【事件方法：从右往左删除】
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (listStation.SelectedIndex<0)
            {
                SetShowInfo("请选择要删除的读卡分站", Color.Blue);
                return;
            }
            labMessage.Visible = false;
            string strTemp = listStation.Items[listStation.SelectedIndex].ToString();
            string strAddressTemp = strTemp.Substring(0, strTemp.IndexOf(" "));
            string[] strAddress = strAddressTemp.Split('.');
            string strPlace = strTemp.Substring(strTemp.IndexOf(" ") + 1);
            TreeNode item = new TreeNode();
            item.Name = strAddressTemp;
            item.Text = strPlace;

            //增加到删除列表中
            PathDetailModel pathDetailModel = new PathDetailModel();
            pathDetailModel.PathNo = txtPathID.Text;
            pathDetailModel.PathID = listStation.SelectedIndex;
            pathDetailModel.StationAddress = int.Parse(strAddress[0]);
            pathDetailModel.StationHeadAddress = int.Parse(strAddress[1]);


            for (int i = 0; i < alPathDetailAdd.Count; i++)
            {
                PathDetailModel pModel = (PathDetailModel)alPathDetailAdd[i];
                if (pModel.PathNo.Equals(pathDetailModel.PathNo) && pModel.StationAddress == pathDetailModel.StationAddress && pModel.StationHeadAddress == pathDetailModel.StationHeadAddress && pModel.PathID == pathDetailModel.PathID)
                {
                    alPathDetailAdd.Remove(pModel);
                    break;
                }
            }
            for (int i = pathDetailModel.PathID; i < alPathDetailAdd.Count; i++)
            {
                PathDetailModel pModel = (PathDetailModel)alPathDetailAdd[i];
                pModel.PathID = i;
            }
            


            //bool flag = false;
            //switch (m_type)
            //{
            //    case 1:
            //        try
            //        {
            //            for (int i = 0; i < alPathDetailAdd.Count; i++)
            //            {
            //                PathDetailModel pModel = (PathDetailModel)alPathDetailAdd[i];
            //                if (pModel.PathNo.Equals(pathDetailModel.PathNo) && pModel.StationAddress == pathDetailModel.StationAddress && pModel.StationHeadAddress == pathDetailModel.StationHeadAddress && pModel.PathID == pathDetailModel.PathID)
            //                {
            //                    alPathDetailAdd.Remove(pModel);
            //                    break;
            //                }
            //            }
            //        }
            //        catch { }
            //        break;
            //    case 2:
            //        for (int i = 0; i < alPathDetail.Count; i++)
            //        {
            //            PathDetailModel pathDetail = (PathDetailModel)alPathDetail[i];
            //            if (pathDetail.StationAddress == pathDetailModel.StationAddress && pathDetail.StationHeadAddress == pathDetailModel.StationHeadAddress && pathDetail.PathID == pathDetailModel.PathID)
            //            {
            //                flag = true;
            //                try
            //                {
            //                    alPathDetailDelete.Add(pathDetailModel);
            //                }
            //                catch { }
            //                break;
            //            }
            //        }
            //        if (!flag)
            //        {
            //            try
            //            {
            //                for (int i = 0; i < alPathDetailAdd.Count; i++)
            //                {
            //                    PathDetailModel pModel = (PathDetailModel)alPathDetailAdd[i];
            //                    if (pModel.PathNo.Equals(pathDetailModel.PathNo) && pModel.StationAddress == pathDetailModel.StationAddress && pModel.StationHeadAddress == pathDetailModel.StationHeadAddress)
            //                    {
            //                        alPathDetailAdd.Remove(pModel);
            //                        break;
            //                    }
            //                }
            //            }
            //            catch { }
            //        }
            //        break;
            //}

            //从列表框中删除
            listStation.Items.RemoveAt(listStation.SelectedIndex);
        }
        #endregion

        private void txtPathID_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        #endregion

        private void txtPathName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }


    }
}
