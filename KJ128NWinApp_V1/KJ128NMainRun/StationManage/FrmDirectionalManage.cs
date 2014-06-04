using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;
using KJ128NDataBase;

namespace KJ128NMainRun.StationManage
{
    public partial class FrmDirectionalManage : Wilson.Controls.Docking.DockContent
    {
        //拖动
        private bool isMove = false;            // (设置面板) 是否移动
        private int mleft = 0;
        private int mtop = 0;
        private StationBLL sbll = new StationBLL();
        private int pSize = 40;
        

        public FrmDirectionalManage()
        {
            InitializeComponent();
            Init();
        }

        #region 初始化数据

        private void Init()
        {
            vsPanel.Visible = false;
            vspConfig.Visible = false;

            cmb_Size.SelectedIndex = 0;
            loaddgvData();
        }

        #endregion

        #region 初始化DataGridView

        private void loaddgvData()
        {
            getInfo(1,"");
        }

        #endregion

        #region 加载treeview

        private void loadTreeView()
        {
            trFromStation.Nodes.Clear();
            trToStation.Nodes.Clear();

            DataSet ds = sbll.GetStationAndHead();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TreeNode tnode = new TreeNode();
                    TreeNode tnode1 = new TreeNode();
                    tnode.Name = dr["StationAddress"].ToString();
                    tnode.Text = dr["StationPlace"].ToString();
                    tnode1.Name = dr["StationAddress"].ToString();
                    tnode1.Text = dr["StationPlace"].ToString();
                    DataRow[] drhead = ds.Tables[1].Select("StationAddress = " + dr["StationAddress"].ToString());
                    if (drhead.GetUpperBound(0) + 1>0)
                    {
                        TreeNode headnode = null;
                        TreeNode headnode1 = null;
                        foreach (DataRow drh in drhead)
	                    {
                            headnode = new TreeNode();
                            headnode.Name = drh["StationHeadAddress"].ToString();
                            headnode.Text = drh["StationHeadPlace"].ToString();
                            // 天线地址为空时 默认为 天线A 
                            headnode.Tag = drh["AntennaA"].ToString()==""?"天线A,":drh["AntennaA"].ToString()+",";
                            headnode.Tag += drh["AntennaB"].ToString()==""?"天线B":drh["AntennaB"].ToString();

                            headnode1 = new TreeNode();
                            headnode1.Name = drh["StationHeadAddress"].ToString();
                            headnode1.Text = drh["StationHeadPlace"].ToString();
                            // 天线地址为空时 默认为 天线A 
                            headnode1.Tag = drh["AntennaA"].ToString() == "" ? "天线A," : drh["AntennaA"].ToString() + ",";
                            headnode1.Tag += drh["AntennaB"].ToString() == "" ? "天线B" : drh["AntennaB"].ToString();
                            // 添加到分站节点下
                            tnode.Nodes.Add(headnode);
                            tnode1.Nodes.Add(headnode1);
	                    }
                    }
                    // 添加到treeView
                    trFromStation.Nodes.Add(tnode);
                    trToStation.Nodes.Add(tnode1);
                }
                if (trFromStation.Nodes.Count > 0)
                {
                    trFromStation.Nodes[0].Checked = true;
                }
                if (trToStation.Nodes.Count >0)
                {
                    trToStation.Nodes[0].Checked = true;
                }
            }
        }

        #endregion

        #region 分页处理 删除 修改

        #region 翻页事件

        // 跳至
        void cpCheckPage_Click(object sender, EventArgs e)
        {
            if (txtCheckPage.Text == string.Empty) return;
            string value = txtCheckPage.Text;
            int page = int.Parse(value);
            getInfo(page,"");
        }

        // 下一页


        void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            // 显示方式
            getInfo(page,"");

        }

        // 上一页


        void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            // 显示方式
            getInfo(page,"");
        }

        #endregion

        // 页数加载
        private void getInfo(int pIndex,string strWhere)
        {
            dgvData.Columns.Clear();
            if (pIndex < 0) return;
            DataSet ds = null;
            if (strWhere == "") strWhere = "1=1";
            ds = sbll.getAllDirectional(pIndex - 1, pSize, strWhere);
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                //if (sumPage > 1)
                //{
                //    bcpPageSum.Location = new Point(394, 5);
                //}
                //else
                //{
                //    bcpPageSum.Location = new Point(704, 5);
                //}

                if (!cpUp.Enabled)
                {
                    cpUp.Enabled = true;
                }
                if (!cpDown.Enabled)
                {
                    cpDown.Enabled = true;
                }

                if (pIndex == 1)
                {
                    // 只有一页时
                    if (sumPage <= 1)
                    {
                        pageControlsVisible(false);
                    }
                    else
                    {
                        pageControlsVisible(true);
                        cpUp.Enabled = false;
                    }
                }
                else if (pIndex == sumPage)
                {
                    cpDown.Enabled = false;
                    // 最后一页
                }
                else if (pIndex > sumPage)
                {
                    // 大于最后一页
                    getInfo(sumPage,"");
                    return;
                }
                //bcpPageSum.CaptionTitle = "共" + ds.Tables[1].Rows[0][0].ToString() + "条/本页" + ds.Tables[0].Rows.Count.ToString() + "条";
                bcpPageSum.CaptionTitle = "共" + ds.Tables[1].Rows[0][0].ToString() + "条";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";

                //删除
                DataGridViewLinkColumn dgvLBtnColRemove = new DataGridViewLinkColumn();
                dgvLBtnColRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLBtnColRemove.HeaderText = "操作";
                dgvLBtnColRemove.Name = "delete";
                dgvLBtnColRemove.DataPropertyName = "索引号";
                dgvLBtnColRemove.Text = "删  除";
                dgvLBtnColRemove.Visible = true;
                dgvLBtnColRemove.UseColumnTextForLinkValue = true;

                // 修改
                DataGridViewLinkColumn dgvLBtnColUpdate = new DataGridViewLinkColumn();
                dgvLBtnColUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLBtnColUpdate.HeaderText = "操作";
                dgvLBtnColUpdate.Name = "update";
                dgvLBtnColUpdate.DataPropertyName = "索引号";
                dgvLBtnColUpdate.Text = "修  改";
                dgvLBtnColUpdate.Visible = true;
                dgvLBtnColUpdate.UseColumnTextForLinkValue = true;

                dgvData.DataSource = ds.Tables[0];
                dgvData.Columns.Add(dgvLBtnColUpdate);
                dgvData.Columns.Add(dgvLBtnColRemove);
                dgvData.Columns[0].Visible = false;
                dgvData.Columns[1].FillWeight = 25;
                dgvData.Columns[3].FillWeight = 50;
            }
        }

        #region 处理空数据页数显示
        // 处理空数据页数显示

        private void pageControlsVisible(bool bl)
        {
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
            //bcpPageSum.Visible = bl;
        }

        #endregion

        // 修改 删除
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 删除
            if (e.RowIndex > -1 && e.ColumnIndex == dgvData.Columns["delete"].Index)
            {
                dgvData.Rows[e.RowIndex].Selected = true;
                ((DataGridViewLinkColumn)dgvData.Columns["delete"]).VisitedLinkColor = Color.Blue;

                //MessageBox.Show(dgvData.CurrentRow.Cells["标识"].Value.ToString());

                if (MessageBox.Show("您确认删除该方向性", "删  除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    operated = 2;

                    //删除方向性信息的标识
                    strDelete = dgvData.Rows[e.RowIndex].Cells["标识"].Value.ToString();

                    //存入日志
                    LogSave.Messages("[FrmDirectionalManage]", LogIDType.UserLogID, "删除方向性，标识：" + dgvData.Rows[e.RowIndex].Cells["标识"].Value.ToString()
                        + "，描述：" + dgvData.Rows[e.RowIndex].Cells["方向性描述"].Value.ToString() + "。");

                    int tmpInt = e.RowIndex;
                    sbll.removeDirectional(int.Parse(dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["索引号"].Index].Value.ToString()));
                    getInfo(int.Parse(txtPage.CaptionTitle),"1=1");
                    dgvData.ClearSelection();
                    //if (tmpInt > 0)
                    //{
                    //    if (dgvData.Rows.Count > tmpInt + 1)
                    //    {
                    //        dgvData.Rows[tmpInt].Selected = true;
                    //    }
                    //    else
                    //    {
                    //        dgvData.Rows[tmpInt - 1].Selected = true;
                    //    }
                    //}


                    if (!New_DBAcess.IsDouble)
                    {
                        getInfo(int.Parse(txtPage.CaptionTitle), "");
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
            else if (e.RowIndex > -1 && e.ColumnIndex == dgvData.Columns["update"].Index)
            {
                //存入日志
                LogSave.Messages("[FrmDirectionalManage]", LogIDType.UserLogID, "修改方向性，标识：" + dgvData.Rows[e.RowIndex].Cells["标识"].Value.ToString()
                    + "，描述：" + dgvData.Rows[e.RowIndex].Cells["方向性描述"].Value.ToString() + "。");

                ((DataGridViewLinkColumn)dgvData.Columns["update"]).VisitedLinkColor = Color.Blue;
                vsPanel.Visible = true;
                vsPanel.Tag = dgvData.Rows[e.RowIndex].Cells["索引号"].Value.ToString();
                txt.Text = dgvData.Rows[e.RowIndex].Cells["标识"].Value.ToString();
                txtUpdateDInfo.Text = dgvData.Rows[e.RowIndex].Cells["位置"].Value.ToString();
                txtUpdateD.Text = dgvData.Rows[e.RowIndex].Cells["方向性描述"].Value.ToString();
                lblUpdateResult.Text = "";

            }
        }

        #endregion

        #region panel拖动

        private void cpConfigHead_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void cpConfigHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void cpConfigHead_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        // 配置面板关闭事件
        private void cpConfigHead_CloseButtonClick(object sender, EventArgs e)
        {
            vspConfig.Visible = false;
        }

        // 修改面板关闭事件
        private void cp_CloseButtonClick(object sender, EventArgs e)
        {
            vsPanel.Visible = false;
        }

        #endregion 

        #region 点击TreeView From

        private void trFromStation_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                lblFromStation.Text = e.Node.Parent.Text;
                lblFromHead.Text = e.Node.Text;
                string[] s = e.Node.Tag.ToString().Split(',');
                rbtnFromA.Text = s[0].ToString();
                rbtnFromB.Text = s[1].ToString();

                rbtnFromA.Visible = true;
                rbtnFromB.Visible = true;

                lblFromStation.Tag = e.Node.Parent.Name;
                lblFromHead.Tag = e.Node.Name;
            }
            else
            {
                lblFromStation.Text = "";
                lblFromHead.Text = "";
                
                rbtnFromA.Visible = false;
                rbtnFromB.Visible = false;

                lblFromStation.Tag = null;
                lblFromHead.Tag = null;
            }
        }

        #endregion

        #region 点击TreeView To

        private void trToStation_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                lblToStation.Text = e.Node.Parent.Text;
                lblToHead.Text = e.Node.Text;
                string[] s = e.Node.Tag.ToString().Split(',');
                rbtnToA.Text = s[0].ToString();
                rbtnToB.Text = s[1].ToString();

                rbtnToA.Visible = true;
                rbtnToB.Visible = true;

                lblToStation.Tag = e.Node.Parent.Name;
                lblToHead.Tag = e.Node.Name;
            }
            else
            {
                lblToStation.Text = "";
                lblToHead.Text = "";

                rbtnToA.Visible = false;
                rbtnToB.Visible = false;

                lblToStation.Tag = null;
                lblToHead.Tag = null;
            }
        }

        #endregion

        #region 验证

        private bool CheckSave()
        {
            // 判断是否选择接收器
            if (lblFromHead.Tag == null || lblToHead.Tag == null)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "请选择方向性配置所需的读卡分站";
                return false;
            }

            string tmpd1 = lblFromStation.Tag.ToString() + "," + lblFromHead.Tag.ToString() + ",";
            tmpd1 += rbtnFromA.Checked ? "1" : "2";
            string tmpd2 = lblToStation.Tag.ToString() + "," + lblToHead.Tag.ToString() + ",";
            tmpd2 += rbtnToA.Checked ? "1" : "2";

            //存入日志
            LogSave.Messages("[FrmDirectionalManage]", LogIDType.UserLogID, "配置方向性，起始读卡分站，" + tmpd1 + "：目标读卡分站：" + tmpd2
                + "，描述：" + txtDirectional.Text + "。");

            if (tmpd1 == tmpd2)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "方向性不能是一个读卡分站下的同一个天线";
                return false;
            }
            
            return true;
        }

        // 方向性描述获得焦点时 验证
        private void txtDirectional_Enter(object sender, EventArgs e)
        {
            if (!CheckSave())
            {
                return;
            }
        }

        #endregion

        #region 添加方向性

        private void bcpSave_Click(object sender, EventArgs e)
        {
            if (!CheckSave())
            {
                return;
            }
            if (txtDirectional.Text == string.Empty)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "请填写方向性描述";
                return;
            }

            // 构造方向性
            string tmpd1 = lblFromStation.Tag.ToString() + "," + lblFromHead.Tag.ToString() + ",";
            tmpd1 += rbtnFromA.Checked ? "1" : "2"; 
            string tmpd2 = lblToStation.Tag.ToString() + "," + lblToHead.Tag.ToString() + ",";
            tmpd2 += rbtnToA.Checked ? "1" : "2";

            //存入日志
            LogSave.Messages("[FrmDirectionalManage]", LogIDType.UserLogID, "配置方向性，起始接收器：" + tmpd1 + "，目标接收器：" + tmpd2
                + "，描述：" + txtDirectional.Text + "。");

            operated = 1;

            int result = sbll.addDirectional(tmpd1 + ":" + tmpd2, txtDirectional.Text);
            if (result == 0)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Text = "方向性已存在";
                return;
            }
            else if (result == 1)
            {
                txtDirectional.Text = "";
                lblInfo.ForeColor = Color.Blue;
                lblInfo.Text = "添加成功";

                if (!New_DBAcess.IsDouble)
                {
                    getInfo(int.Parse(txtPage.CaptionTitle), "");
                }
                else
                {
                    timer1.Start();
                }
                return;
            }
        }

        #endregion

        // 查询 根据标识 描述查询
        private void bcpSelect_Click(object sender, EventArgs e)
        {
            string[,] strArray = new string[2, 4]{{"DetectionInfo","=",txtD.Text,"string"},
                                    {"Directional","=",txtWhere.Text,"string"}
              };
            RealTimeBLL rtbll = new RealTimeBLL();
            string where = rtbll.SelectWhere(strArray, 0);
            getInfo(1, where);

        }

        private void bcpUpdate_Click(object sender, EventArgs e)
        {
            if (txtUpdateD.Text == string.Empty)
            {
                lblUpdateResult.ForeColor = Color.Red;
                lblUpdateResult.Text = "请填写方向性描述";
                return;
            }

            

            if (vsPanel.Tag != null)
            {
                int result = sbll.upDateDirectional(int.Parse(vsPanel.Tag.ToString()), txtUpdateD.Text);
                if (result == 1)
                {
                    lblUpdateResult.ForeColor = Color.Blue;
                    lblUpdateResult.Text = "修改成功!";
                }
                vsPanel.Visible = false;

                operated = 3;

                if (!New_DBAcess.IsDouble)
                {
                    getInfo(int.Parse(txtPage.CaptionTitle), "");
                }
                else
                {
                    timer1.Start();
                }
            }
        }

        private void bcpConfig_Click(object sender, EventArgs e)
        {
            vspConfig.Visible = true;
            loadTreeView();
            
            // 初始化处理
            lblInfo.Text = "";
            lblFromStation.Text = "";
            lblFromHead.Text = "";
            rbtnFromA.Visible = false;
            rbtnFromB.Visible = false;
            lblFromStation.Tag = null;
            lblFromHead.Tag = null;

            lblToStation.Text = "";
            lblToHead.Text = "";
            rbtnToA.Visible = false;
            rbtnToB.Visible = false;
            lblToStation.Tag = null;
            lblToHead.Tag = null;
        }

        private void buttonCaptionPanel1_Click(object sender, EventArgs e)
        {
            vsPanel.Visible = false;
        }

        private void FrmDirectionalManage_Load(object sender, EventArgs e)
        {

        }

        private void bcpSelect_Load(object sender, EventArgs e)
        {

        }

        private void vspConfig_Paint(object sender, PaintEventArgs e)
        {

        }


        #region 选择 每页显示行数
        private void cmb_Size_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmb_Size.SelectedItem);
            loaddgvData();
        }
        #endregion

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }


        #region [热备定时刷新]

        /// <summary>
        /// 最大刷新次数
        /// </summary>
        private int maxTimes = 2;

        /// <summary>
        /// 查询刷新次数
        /// </summary>
        private int times = 0;

        /// <summary>
        /// 1表示 增加，修改 2 表示删除 
        /// </summary>
        private int operated = 1;

        /// <summary>
        /// 删除方向性信息的标识
        /// </summary>
        private string strDelete = string.Empty;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (operated == 1)
            {

                // 构造方向性
                string tmpd1 = lblFromStation.Tag.ToString() + "," + lblFromHead.Tag.ToString() + ",";
                tmpd1 += rbtnFromA.Checked ? "1" : "2";
                string tmpd2 = lblToStation.Tag.ToString() + "," + lblToHead.Tag.ToString() + ",";
                tmpd2 += rbtnToA.Checked ? "1" : "2";

                string value = tmpd1 + ":" + tmpd2;

                if (RecordSearch.IsRecordExists("CodeSender_Directional", "DetectionInfo", value, DataType.String))
                {
                    //刷新

                    getInfo(int.Parse(txtPage.CaptionTitle), "");

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timer1_Tick(sender, e);
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
            else if (operated == 2)
            {
                if (strDelete != string.Empty)
                {
                    string value = strDelete; //dgvData.CurrentRow.Cells["标识"].Value.ToString();

                    if (!RecordSearch.IsRecordExists("CodeSender_Directional", "DetectionInfo", value, DataType.String))
                    {
                        //刷新

                        getInfo(int.Parse(txtPage.CaptionTitle), "");

                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                    else
                    {
                        if (times < maxTimes)
                        {
                            times++;
                            timer1_Tick(sender, e);
                        }
                        else
                        {
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                    }
                }
            }
            else
            {
                string strWhere = "DetectionInfo='" + txt.Text + "'"
                    + " and Directional='" + txtUpdateD.Text + "'";

                if (RecordSearch.IsRecordExists("CodeSender_Directional", strWhere))
                {
                    //刷新

                    getInfo(int.Parse(txtPage.CaptionTitle), "");

                    times = 0;
                    //关闭timer1
                    timer1.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                       // timer1_Tick(sender, e);
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }
                }
            }
        }

        #endregion

        #region 【 事件: 刷新 】

        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmb_Size.SelectedItem);
            loaddgvData();
        }

        #endregion

    }
}