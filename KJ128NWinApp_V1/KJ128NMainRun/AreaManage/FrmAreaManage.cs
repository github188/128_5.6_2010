using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128WindowsLibrary;
using KJ128NDataBase;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NInterfaceShow
{
    public partial class FrmAreaManage : Wilson.Controls.Docking.DockContent
    {

        
        #region [ 私有变量 ]

        private AreaBLL areaBll = new AreaBLL();
        private DeptDAL deptDal = new DeptDAL();

        int temp_TerID;
        int intX=0;         //1表示点击了系统存在的分站树，-1表示点击了已有的分站树，0表示两个都没点

        /// <summary>
        /// 每页的条数

        /// </summary>
        int intSize;                  
        /// <summary>
        /// 记录选中的是第几行

        /// </summary>
        int tmpInt;
        /// <summary>
        /// 查询结果的总页数

        /// </summary>
        int countPage;
        /// <summary>
        /// 记录点击分站树的内容
        /// </summary>
        string strStation=" ";
        /// <summary>
        /// 记录点击已配分站树的内容
        /// </summary>
        string strHeadStation;

        int temp_TerInfoID;
        string temp_TerName;
        int temp_TerTypeID;
        string temp_TerTypeName;
        string where_TerInfoID="";
        string where_TerTypeID="";
        //拖动
        private bool isMove = false;            // (设置面板) 是否移动
        private int mleft = 0;
        private int mtop = 0;
        //查询条件
        private string where;
        private int pSize=20;
        #endregion

        #region [ 构造函数 ]

        public FrmAreaManage()
        {
            InitializeComponent();
        }
        #endregion

        #region [ 方法: 窗体加载 ]
        private void FrmAreaManage_Load(object sender, EventArgs e)
        {
            InitdgvTerSet();                //初始化区域设置

            InitdgvTerInfo();               //初始化区域信息

            InitdgvTerType();               //初始化区域类别


            comboBox1.SelectedIndex = 0;
            areaBll.GetTerTypeCmb1(comBox_TerType);
            areaBll.GetTerNameCmb(comBox_TerName);
            InitTreeViewStation();
        }
        #endregion

        #region [ 方法: 区域设置 ]

        #region [ 方法: 初始化区域设置 ]

        private void InitdgvTerSet()
        {
            where = strWhere();
            EmpInfo(1);
            dgv_TerSet.ReadOnly = true;
            dgv_TerSet.Columns[0].DisplayIndex = 12;
            dgv_TerSet.Columns[1].DisplayIndex = 12;
            dgv_TerSet.Columns[9].Visible = false;
            dgv_TerSet.Columns[10].Visible = false;
            dgv_TerSet.Columns[11].Visible = false;
            //for (int i = 0; i < dgv_TerSet.Rows.Count; i++)
            //{
            //    if (dgv_TerSet.Rows[i].Cells[9].Value.ToString() == "")
            //    {
            //        dgv_TerSet.Rows[i].Cells[1].Visible= false;
            //    }
            //}
            if (countPage > 1)
            {
                //cpUp.Cursor = Cursors.Default;
                cpUp.Enabled = false;
                cpDown.Enabled = true;
            }
            
        }
        #endregion

        #region [ 方法: 初始化部门树 ]

        private void InitTreeViewStation()
        {
            tvStation.Nodes.Clear();
            using (DataSet ds = areaBll.GetStationInfoTreeView())
            {
                if (ds != null)
                {
                    areaBll.TrStation(tvStation, ds.Tables[0]);
                }
            }

        }
        #endregion

        #region [ 事件: 点击分站树的节点 ]
        private void tvStation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strStation = tvStation.SelectedNode.Name;
            intX = 1;
            
        }
        #endregion

        #region [ 事件: 选择区域名称(ComboBox) ]
        private void comBox_TerName_DropDownClosed(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(comBox_TerName.SelectedValue) != 0)
            //{
            //    dgv_TerSet.DataSource = areaBll.getTerNameSetTable(Convert.ToInt32(comBox_TerName.SelectedValue));
            //}
            if (Convert.ToInt32(comBox_TerName.SelectedValue) != 0)
            {
                where_TerInfoID = comBox_TerName.SelectedValue.ToString();
            }
            else
            {
                where_TerInfoID = "";
            }
            where = strWhere();
            EmpInfo(1);
            
        }
        #endregion

        #region [ 事件: 选择区域类别(ComboBox) ]
        private void comBox_TerType_DropDownClosed(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comBox_TerType.SelectedValue) != 0)
            {
                where_TerTypeID = comBox_TerType.SelectedValue.ToString();
            }
            else
            {
                where_TerTypeID = "";
            }
            where = strWhere();
            EmpInfo(1);
        }

        
        #endregion

        #region [ 事件: 翻页 ]
        //上一页

        private void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            cpDown.Cursor = Cursors.Hand;
            cpDown.Enabled = true;
            if (page == 1)
            {
                //cpUp.Cursor = Cursors.Default;
                cpUp.Enabled = false;
             }
             else if (page < 1)
             {
                 return;
             }

            
            where = strWhere();
            EmpInfo(page);
        }
        //下一页
        private void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            //cpUp.Cursor = Cursors.Hand;
            cpUp.Enabled = true;
            if (page == countPage)
            {
                //cpDown.Cursor = Cursors.Default;
                cpDown.Enabled = false;
            }
            else if(page>countPage)
            {

                return;
            }

            where = strWhere();
            EmpInfo(page);
        }
        //跳至
        private void cpCheckPage_Click(object sender, EventArgs e)
        {
            string value = txtCheckPage.Text;
            if (value.CompareTo("") == 0)
            {
                return;
            }
            else if (int.Parse(value) > 0)
            {
                int page = int.Parse(value);
                if (page == 1)
                {
                    //cpUp.Cursor = Cursors.Default;
                    cpUp.Enabled = false;
                    //cpDown.Cursor = Cursors.Hand;
                    cpDown.Enabled = true;
                }
                else if (page == countPage)
                {
                    //cpUp.Cursor = Cursors.Hand;
                    cpUp.Enabled = true;
                    //cpDown.Cursor = Cursors.Default;
                    cpDown.Enabled = false;
                }
                else
                {
                    //cpUp.Cursor = Cursors.Hand;
                    cpUp.Enabled = true;
                    //cpDown.Cursor = Cursors.Hand;
                    cpDown.Enabled = true;
                }
                if (page > countPage)
                {
                    //MessageBox.Show("不存在该页数，请重新输入！");
                    //txtCheckPage.Focus();
                    //txtCheckPage.SelectAll();
                    //return;
                    page = countPage;
                    //cpUp.Cursor = Cursors.Hand;
                    cpUp.Enabled = true;
                    //cpDown.Cursor = Cursors.Default;
                    cpDown.Enabled = false;
                }

                where = strWhere();
                EmpInfo(page);
            }
        }

        #endregion

        #region [ 方法: 查询信息 ]
        //组织查询条件
        private string strWhere()
        {
            where = string.Empty;
            string[,] strArray = new string[2, 4]{{"TerritorialID","=",where_TerInfoID,"int"},
                                {"TerritorialTypeID","=",where_TerTypeID,"int"}
            };
            return areaBll.SelectWhere(strArray, 1);
        }
        //分页查询
        private void EmpInfo(int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数！");
                return;
            }
            DataSet ds =areaBll.GetTerSet(pIndex, pSize, where);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (countPage > 1)
                {
                    bcpPageSum.Location = new Point(495, 4);
                }
                else
                {
                    bcpPageSum.Location = new Point(785, 4);
                }
                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgv_TerSet.DataSource = ds.Tables[0];

                        dgv_TerSet.Columns[0].FillWeight = 50;
                        dgv_TerSet.Columns[1].FillWeight = 50;
                        dgv_TerSet.Columns[2].FillWeight = 120;
                        dgv_TerSet.Columns[3].FillWeight = 120;
                        dgv_TerSet.Columns[8].FillWeight = 180;

                        dgv_TerSet.Columns[5].HeaderText = HardwareName.Value(CorpsName.StationAddress);
                        dgv_TerSet.Columns[7].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);

                        dgv_TerSet.Columns[4].Visible = false;
                        dgv_TerSet.Columns[6].Visible = false;

                        bcpPageSum.CaptionTitle = "0 条";
                        //bcpPageSum.Location = new Point(869, 2);
                        //bcpPageSum.Visible = false;
                        cpUp.Visible = false;
                        cpDown.Visible = false;
                        txtPage.Visible = false;
                        lblSumPage.Visible = false;
                        txtCheckPage.Visible = false;
                        cpCheckPage.Visible = false;
                        return;
                    }
                    if (pIndex > sumPage)
                    {
                        // 大于最后一页

                        return;
                    }
                    //EmpInfo(sumPage);
                    //return;
                }
                bcpPageSum.CaptionTitle = "共" + ds.Tables[1].Rows[0][0].ToString() + "条";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";
                dgv_TerSet.DataSource = ds.Tables[0];

                dgv_TerSet.Columns[0].FillWeight = 50;
                dgv_TerSet.Columns[1].FillWeight = 50;
                dgv_TerSet.Columns[2].FillWeight = 120;
                dgv_TerSet.Columns[3].FillWeight = 120;
                dgv_TerSet.Columns[8].FillWeight = 180;

                dgv_TerSet.Columns[5].HeaderText = HardwareName.Value(CorpsName.StationAddress);
                dgv_TerSet.Columns[7].HeaderText = HardwareName.Value(CorpsName.StaHeadAddress);

                dgv_TerSet.Columns[4].Visible = false;
                dgv_TerSet.Columns[6].Visible = false;

                intSize = ds.Tables[0].Rows.Count;
                #region 控制“上一页”、“下一页”等按钮的显示状态

                if (Convert.ToInt32(ds.Tables[1].Rows[0][0]) <= pSize)
                {
                    //bcpPageSum.Location = new Point(869, 2);
                    //bcpPageSum.Visible = false;
                    cpUp.Visible = false;
                    cpDown.Visible = false;
                    txtPage.Visible = false;
                    lblSumPage.Visible = false;
                    txtCheckPage.Visible = false;
                    cpCheckPage.Visible = false;
                }
                else
                {
                    //bcpPageSum.Location = new Point(542, 2);//542
                    //bcpPageSum.Visible = true;
                    cpUp.Visible = true;              
                    cpDown.Visible = true;        
                    txtPage.Visible = true;
                    lblSumPage.Visible = true;
                    txtCheckPage.Visible = true;
                    cpCheckPage.Visible = true;
                }
                #endregion
            }
        }
        #endregion

        #region [ 事件: 每页显示条数设置 ]
        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(comboBox1.SelectedItem);
            InitdgvTerSet();
        }
        #endregion

        #region [ 事件: "×" 关闭 新增区域设置 ]
        private void buttonCaptionPanel11_CloseButtonClick(object sender, EventArgs e)
        {
            vsp_TerSet.Visible = false;
        }
        #endregion

        #region [ 事件: 拖动 ]
        private void buttonCaptionPanel11_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void buttonCaptionPanel11_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void buttonCaptionPanel11_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion

        #region [ 事件: 点击 接收器树 ]

        private void tvStaHead_AfterSelect(object sender, TreeViewEventArgs e)
        {
            intX = -1;
        }
        #endregion

        #region [ 事件: 删除 分站或接收器 ]

        private void buttonCaptionPanel5_Click(object sender, EventArgs e)
        {
            model = 1;

            int intSta, intHead;
            string strSta, strHead;
            if (tvStaHead.Nodes.Count < 1)
            {
                return;
            }
            if (intX==-1)
            {
                if (tvStaHead.SelectedNode.Name.StartsWith("H"))
                {
                    strHead = tvStaHead.SelectedNode.Name;
                    strSta = tvStaHead.SelectedNode.Parent.Name;

                    intHead = Convert.ToInt32(tvStaHead.SelectedNode.Name.Substring(1));
                    if (tvStaHead.Nodes[strSta].Nodes.Count==1)
                    {
                        tvStaHead.Nodes.Remove(tvStaHead.Nodes[strSta].Nodes[strHead]);
                        tvStaHead.Nodes.Remove(tvStaHead.Nodes[strSta]);
                    }
                    else
                    {
                        tvStaHead.Nodes.Remove(tvStaHead.Nodes[strSta].Nodes[strHead]);
                    }
                    areaBll.DeleteStationHead(intHead);

                    if (!New_DBAcess.IsDouble)
                    {
                        EmpInfo(int.Parse(txtPage.CaptionTitle));
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }

                }
                else
                {
                    strSta = tvStaHead.SelectedNode.Name;
                    intSta = Convert.ToInt32(tvStaHead.SelectedNode.Name.Substring(1));
                    tvStaHead.Nodes.Remove(tvStaHead.Nodes[strSta]);
                    areaBll.DeleteStation(intSta);

                    if (!New_DBAcess.IsDouble)
                    {
                        EmpInfo(int.Parse(txtPage.CaptionTitle));
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                }
            }

        }
        #endregion

        #region [ 事件: 添加 分站或接收器 ]

        private void buttonCaptionPanel10_Click(object sender, EventArgs e)
        {

            model = 1;

            int intSta, intHead;
            string strHead,strSta;
            if (tvStation.Nodes!=null && tvStation.Nodes.Count < 1)
            {
                return;
            }
            if (intX==1)
            {
                if (tvStation.SelectedNode == null)
                {
                    return;
                }

                if (tvStation.SelectedNode.Name.StartsWith("H"))        //选中的是接收器
                {
                    strHead = tvStation.SelectedNode.Name;                       
                    strSta = tvStation.SelectedNode.Parent.Name;                 
                    intHead = Convert.ToInt32(tvStation.SelectedNode.Name.Substring(1));            //获取选中的接收器编号

                    intSta = Convert.ToInt32(tvStation.SelectedNode.Parent.Name.Substring(1));      //获取选中的接收器的分站编号

                    //存入日志
                    LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "区域设置—添加读卡分站，区域名称：，类型名称：，传输分站编号：" + intSta.ToString() + "，读卡分站名称：" + strHead + "。");

                    if (tvStaHead.Nodes[strSta] != null)                                            //已配置接收器树中，存在该分站

                    {
                        if (tvStaHead.Nodes[strSta].Nodes.ContainsKey(strHead))                     //已配置接收器树中，存在该接收器

                        {
                            return;
                        }
                    }

                    using (DataSet ds = areaBll.GetStationInfoTreeView())
                    {
                        if (ds != null)
                        {
                            areaBll.TrTerStaHead(tvStaHead, ds.Tables[0], intSta, intHead);
                        }
                    }

                    areaBll.EditArea(temp_TerID, intSta, intHead,(chkIsEnter.Checked?1:0));
                }
                else if (tvStation.SelectedNode.Name.StartsWith("N"))               //选中 分站
                {
                    strSta=tvStation.SelectedNode.Name;
                    intSta=Convert.ToInt32(tvStation.SelectedNode.Name.Substring(1));               //获取选中的分站编号

                    foreach (TreeNode tr in tvStation.SelectedNode.Nodes)
                    {
                        strHead=tr.Name;
                        intHead=Convert.ToInt32(tr.Name.Substring(1));                                               //获取选中的分站的接收器编号

                        if(!(tvStaHead.Nodes[strSta] != null && tvStaHead.Nodes[strSta].Nodes.ContainsKey(strHead)))    //已配置接收器树中，不存在该接收器
                        {
                            using (DataSet ds = areaBll.GetStationInfoTreeView())
                            {
                                if (ds != null)
                                {
                                    areaBll.TrTerStaHead(tvStaHead, ds.Tables[0], intSta, intHead);
                                }
                            }
                            areaBll.EditArea(temp_TerID, intSta, intHead, (chkIsEnter.Checked ? 1 : 0));
                        }

                    }
                }
            
                if (!New_DBAcess.IsDouble)
                {
                    EmpInfo(int.Parse(txtPage.CaptionTitle));
                }
                else
                {
                    timer1.Stop();
                    timer1.Start();
                }

                #region  还原上次选择的位置

               dgv_TerSet.ClearSelection();
                if (tmpInt > 0)
                {
                    if (dgv_TerSet.Rows.Count >= tmpInt + 1)
                    {
                        dgv_TerSet.Rows[tmpInt].Selected = true;
                    }
                    else
                    {
                        dgv_TerSet.Rows[tmpInt - 1].Selected = true;
                    }
                }

               #endregion
                if (countPage>Convert.ToInt32(txtPage.CaptionTitle) && !cpDown.Enabled)
                {
                    cpDown.Enabled = true;
                }
                tvStaHead.ExpandAll();                  //展开已配置接收器树
            }
        }
        #endregion

        #region [ 事件: 配置、删除 按钮的单击事件(区域设置) ]
        private void dgv_TerSet_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            model = 1;

            tmpInt = e.RowIndex;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)                  //点击“配置”
            {
                //存入日志
                LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "区域设置，类型名称：" + dgv_TerSet.Rows[e.RowIndex].Cells[3].Value
                    + "，区域名称：" + dgv_TerSet.Rows[e.RowIndex].Cells[2].Value + "，传输分站编号：" + dgv_TerSet.Rows[e.RowIndex].Cells[5].Value + "，读卡分站编号：" 
                    + dgv_TerSet.Rows[e.RowIndex].Cells[7].Value.ToString() + "。");

                chkIsEnter.Checked = false;
                buttonCaptionPanel11.CaptionTitle = dgv_TerSet.Rows[e.RowIndex].Cells[3].Value.ToString() + "—" + dgv_TerSet.Rows[e.RowIndex].Cells[2].Value.ToString() + "区域设置";
                label11.Text =dgv_TerSet.Rows[e.RowIndex].Cells[2].Value.ToString() +  "已配置的读卡分站信息";            //11311工作面已配置的接收器信息

                tvStaHead.Nodes.Clear();
                vsp_TerSet.Visible = true;
                temp_TerID = Convert.ToInt32(dgv_TerSet.Rows[e.RowIndex].Cells[11].Value);
                string strSql1 = string.Format("select count(*)  from KJ128N_TerSet_Head_Table where TerritorialID={0}", temp_TerID);
                if (deptDal.GetID(strSql1) ==0)
                {
                    tvStaHead.Nodes.Clear();
                }
                else if (deptDal.GetID(strSql1) > 0)
                {
                    using (DataSet ds = areaBll.GetTerSetHeadTable(temp_TerID))
                    {
                        if (ds != null)
                        {
                            areaBll.TrStation(tvStaHead, ds.Tables[0]);
                        }
                    }
                }
                tvStation.ExpandAll();                                  //展开系统接收器树

                tvStaHead.ExpandAll();                                  //展开已配置接收器树
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)             //点击“删除”
            {
                //存入日志
                LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "删除区域设置，类型名称：" + dgv_TerSet.Rows[e.RowIndex].Cells[3].Value
                    + "，区域名称：" + dgv_TerSet.Rows[e.RowIndex].Cells[2].Value + "，传输分站编号：" + dgv_TerSet.Rows[e.RowIndex].Cells[5].Value + "，读卡分站编号："
                    + dgv_TerSet.Rows[e.RowIndex].Cells[7].Value.ToString() + "。");

                if (dgv_TerSet.Rows[e.RowIndex].Cells[9].Value.ToString() == "")
                {
                    MessageBox.Show("该工作面没有配置信息，不能删除！", "提示", MessageBoxButtons.OK);
                    return;
                }
                int int_TerSet;
                DialogResult result;
                result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {                    
                    int_TerSet = Convert.ToInt32(dgv_TerSet.Rows[e.RowIndex].Cells[9].Value);
                    areaBll.RemoveAreaSet(int_TerSet);
                    //InitdgvTerSet();
                    //EmpInfo(int.Parse(txtPage.CaptionTitle));

                    if (intSize == 1)
                    {
                        if (txtPage.CaptionTitle.CompareTo("1") == 0)
                        {
                            if (!New_DBAcess.IsDouble)
                            {
                                EmpInfo(int.Parse(txtPage.CaptionTitle));
                            }
                            else
                            {
                                timer1.Stop();
                                timer1.Start();
                            }
                        }
                        else
                        {
                            if (!New_DBAcess.IsDouble)
                            {
                                EmpInfo(int.Parse(txtPage.CaptionTitle) - 1);
                            }
                            else
                            {
                                timer1.Stop();
                                timer1.Start();
                            }
                        }
                    }
                    else
                    {
                        if (!New_DBAcess.IsDouble)
                        {
                            EmpInfo(int.Parse(txtPage.CaptionTitle));
                        }
                        else
                        {
                            timer1.Stop();
                            timer1.Start();
                        }
                    }

                    dgv_TerSet.ClearSelection();
                    if (tmpInt > 0)
                    {
                        if (dgv_TerSet.Rows.Count >= tmpInt + 1)
                        {
                            dgv_TerSet.Rows[tmpInt].Selected = true;
                        }
                        else
                        {
                            dgv_TerSet.Rows[tmpInt - 1].Selected = true;
                        }
                    }
                }
            }
        }
        #endregion

        #endregion

        #region [ 方法: 区域信息 ]

        #region [ 方法: 初始化区域信息 ]

        private void InitdgvTerInfo()
        {
            DataTable dt = areaBll.GetTerInfoTable();
            if (dt != null)
            {
                dgv_TerInfo.DataSource = dt;
                dgv_TerInfo.ReadOnly = true;
                dgv_TerInfo.Columns[0].DisplayIndex = 8;
                dgv_TerInfo.Columns[1].DisplayIndex = 8;
                dgv_TerInfo.Columns[2].Visible = false;
                dgv_TerInfo.Columns[4].Visible = false;
            }
        }
        #endregion

        #region [ 事件: 显示 新增区域信息 ]
        private void bcp_AddTerInfo_Click(object sender, EventArgs e)
        {
            vsp_TerInfo.Visible = true;
            areaBll.GetTerTypeCmb2(comBox_TerInfoType);
            comBox_IsEnable.Text = "启用";
            textBox_TerInfoName.Text = "";
            textBox_TerInfoInst.Text = "";
            textBox_TerInfoRemark.Text = "";
            buttonCaptionPanel19.CaptionTitle = "新增区域信息";
            buttonCaptionPanel21.CaptionTitle = "存储并新增";
            buttonCaptionPanel2.CaptionTitle = "存储并返回";
            CerErorrTerInfo.CaptionTitle = String.Format("信息提示：一起正常!");
        }
        #endregion

        #region [ 方法: 验证 区域信息 ]
        bool CheckingTerInfo()
        {
            if (textBox_TerInfoName.Text.CompareTo("") == 0)
            {
                CerErorrTerInfo.CaptionTitle = String.Format("信息提示：没有输入区域名称,请输入区域名称!");
                textBox_TerInfoName.Focus();
                textBox_TerInfoName.SelectAll();
                return false;
            }
            else
            {
                #region 验证 区域名称不重复

                if (!(buttonCaptionPanel21.CaptionTitle.CompareTo("修改并返回") == 0 && textBox_TerInfoName.Text.CompareTo(temp_TerName) == 0))
                {
                    
                    using (DataSet ds = areaBll.GetTreInfoTable(textBox_TerInfoName.Text.ToString()))
                    {
                        if (ds != null)
                        {
                            DataTable dt = ds.Tables[0];
                            if (dt.Rows.Count != 0)
                            {
                                CerErorrTerInfo.CaptionTitle = String.Format("信息提示：区域名称已存在,请重新输入区域名称!");
                                textBox_TerInfoName.Focus();
                                textBox_TerInfoName.SelectAll();
                                return false;
                            }
                        }
                    }
                }
                #endregion
            }
            return true;
        }
        #endregion

        #region [ 事件: 修改、删除 按钮的单击事件(区域信息表) ]
        private void dgv_TerInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)                 //点击“修改”

            {
                vsp_TerInfo.Visible = true;
                buttonCaptionPanel19.CaptionTitle = "修改区域信息";
                buttonCaptionPanel21.CaptionTitle = "修改并返回";
                buttonCaptionPanel2.CaptionTitle = "返回";
                CerErorrTerInfo.CaptionTitle = String.Format("信息提示：一起正常!");
                areaBll.GetTerTypeCmb2(comBox_TerInfoType);      //初始化区域类型

                #region 绑定数据
                temp_TerInfoID=Convert.ToInt32( dgv_TerInfo.Rows[e.RowIndex].Cells[2].Value);
                temp_TerName = dgv_TerInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox_TerInfoName.Text = dgv_TerInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (dgv_TerInfo.Rows[e.RowIndex].Cells[4].Value.ToString().CompareTo("") == 0)
                {
                    comBox_TerInfoType.SelectedValue = 0;
                }
                else
                {
                    comBox_TerInfoType.SelectedValue = Convert.ToInt32(dgv_TerInfo.Rows[e.RowIndex].Cells[4].Value);
                }
                
                comBox_IsEnable.SelectedIndex = Convert.ToInt32(dgv_TerInfo.Rows[e.RowIndex].Cells[6].Value);
                textBox_TerInfoInst.Text = dgv_TerInfo.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox_TerInfoRemark.Text = dgv_TerInfo.Rows[e.RowIndex].Cells[8].Value.ToString();
                #endregion
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)            //点击“删除”
            {
                DialogResult result;
                result = MessageBox.Show("删除区域信息后，将会导致与该区域信息相关的信息丢失，确定删除吗？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "删除区域信息，区域名称："+dgv_TerInfo.Rows[e.RowIndex].Cells[3].Value
                        + "，区域类别：" + dgv_TerInfo.Rows[e.RowIndex].Cells[5].Value + "。");
                    temp_TerInfoID = Convert.ToInt32(dgv_TerInfo.Rows[e.RowIndex].Cells[2].Value);
                    areaBll.DeleteTerInfo(temp_TerInfoID);

                    model = 2;

                    operated = 2;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitdgvTerInfo();           //刷新 区域信息
                        InitdgvTerSet();            //刷新 区域设置
                        areaBll.GetTerNameCmb(comBox_TerName);
                        dgv_TerSet.DataSource = areaBll.GetTerSetTable();       //刷新 区域名称
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                }

            }
        }
        #endregion

        #region [ 事件: 存储并新增、修改并返回 区域信息 ]
        private void buttonCaptionPanel21_Click(object sender, EventArgs e)
        {
            if (CheckingTerInfo())
            {
                if (buttonCaptionPanel21.CaptionTitle.CompareTo("存储并新增") == 0)         //"存储并新增"
                {
                    //存入日志
                    LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "添加区域信息，区域名称：" + textBox_TerInfoName.Text + "，区域类别："+comBox_TerInfoType.SelectedText+"。");

                    model = 2;
                    operated = 1;
                    territorialName = textBox_TerInfoName.Text;

                    areaBll.SaveTerInfoData(textBox_TerInfoName.Text, Convert.ToInt32(comBox_TerInfoType.SelectedValue), Convert.ToByte(comBox_IsEnable.SelectedIndex), textBox_TerInfoInst.Text, textBox_TerInfoRemark.Text);

                    if (!New_DBAcess.IsDouble)
                    {
                        InitdgvTerInfo();           //刷新 区域信息
                        InitdgvTerSet();            //刷新 区域设置
                        areaBll.GetTerNameCmb(comBox_TerName);                  //刷新 区域名称
                        dgv_TerSet.DataSource = areaBll.GetTerSetTable();       //刷新 区域设置表
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }

                }
                else                                                                        //"修改并返回"
                {
                    //存入日志
                    LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "修改区域信息，区域名称：" + textBox_TerInfoName.Text + "，区域类别：" + comBox_TerInfoType.SelectedText + "。");

                    model = 2;
                    operated = 1;
                    territorialName = textBox_TerInfoName.Text;


                    areaBll.UpDateTerInfo(temp_TerInfoID, textBox_TerInfoName.Text, Convert.ToInt32(comBox_TerInfoType.SelectedValue), Convert.ToByte(comBox_IsEnable.SelectedIndex), textBox_TerInfoInst.Text, textBox_TerInfoRemark.Text);
                    vsp_TerInfo.Visible = false;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitdgvTerInfo();           //刷新 区域信息
                        InitdgvTerSet();            //刷新 区域设置
                        areaBll.GetTerNameCmb(comBox_TerName);                  //刷新 区域名称
                        dgv_TerSet.DataSource = areaBll.GetTerSetTable();       //刷新 区域设置表
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                }
            }
        }
        #endregion

        #region [ 事件: 存储并返回、返回 区域信息 ]
        private void buttonCaptionPanel2_Click(object sender, EventArgs e)
        {
            if (CheckingTerInfo())
            {
                if (buttonCaptionPanel2.CaptionTitle.CompareTo("存储并返回") == 0)           //"存储并返回"
                {
                    //存入日志
                    LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "添加区域信息，区域名称：" + textBox_TerInfoName.Text + "，区域类别：" + comBox_TerInfoType.SelectedText + "。");

                    model = 2;

                    operated = 1;

                    territorialName = textBox_TerInfoName.Text;

                    areaBll.SaveTerInfoData(textBox_TerInfoName.Text, Convert.ToInt32(comBox_TerInfoType.SelectedValue), Convert.ToByte(comBox_IsEnable.SelectedIndex), textBox_TerInfoInst.Text, textBox_TerInfoRemark.Text);

                    vsp_TerInfo.Visible = false;

                    if (!New_DBAcess.IsDouble)
                    {

                        InitdgvTerInfo();           //刷新 区域信息
                        InitdgvTerSet();            //刷新 区域设置
                        areaBll.GetTerNameCmb(comBox_TerName);                  //刷新 区域名称
                        dgv_TerSet.DataSource = areaBll.GetTerSetTable();       //刷新 区域设置表
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                    
                }
                else                                                                          //"返回"
                {
                    vsp_TerInfo.Visible = false;
                }
            }
        }
        #endregion

        #region [ 事件: "×" 关闭 新增区域信息 ]
        private void buttonCaptionPanel19_CloseButtonClick(object sender, EventArgs e)
        {
            vsp_TerInfo.Visible = false;
        }
        #endregion

        #region [ 事件: 实现拖动 ]
        private void buttonCaptionPanel19_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void buttonCaptionPanel19_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void buttonCaptionPanel19_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion

        #endregion

        #region [ 方法: 区域类别 ]

        #region [ 方法: 初始化区域类别 ]

        private void InitdgvTerType()
        {
            DataTable dt=areaBll.GetTerTypeTable();
            if (dt != null)
            {
                dgv_TerType.DataSource = dt;
                dgv_TerType.ReadOnly = true;
                dgv_TerType.Columns[0].DisplayIndex = 5;
                dgv_TerType.Columns[1].DisplayIndex = 5;
                dgv_TerType.Columns[2].Visible = false;
            }
        }
        #endregion

        #region [ 事件: 显示 新增区域类别 ]
        private void bcp_AddTerType_Click(object sender, EventArgs e)
        {
            textBox_TerTypeName.Enabled = true;
            vsp_TerType.Visible = true;
            textBox_TerTypeName.Text = "";
            comBox_IsAlarm.Text = "报警";
            textBox_TerTypeRemark.Text = "";
            buttonCaptionPanel9.CaptionTitle = "新增区域类别";
            buttonCaptionPanel8.CaptionTitle = "存储并新增";
            buttonCaptionPanel6.CaptionTitle = "存储并返回";
            CerErorrTerType.CaptionTitle = String.Format("信息提示：一起正常!");
        }
        #endregion

        #region [ 方法: 验证 区域类别 ]
        private bool CheckingTerType()
        {
            if (textBox_TerTypeName.Text.CompareTo("") == 0)
            {
                CerErorrTerType.CaptionTitle = String.Format("信息提示：没有输入类别名称,请输入类别名称!");
                textBox_TerTypeName.Focus();
                textBox_TerTypeName.SelectAll();
                return false;
            }
            else
            {
                #region 验证 区域类别不重复

                if (!(buttonCaptionPanel8.CaptionTitle.CompareTo("修改并返回") == 0 && textBox_TerTypeName.Text.CompareTo(temp_TerTypeName) == 0))
                {
                    using (DataSet ds = areaBll.GetKJ128NTerTypeTable(textBox_TerTypeName.Text.ToString()))
                    {
                        if (ds != null)
                        {
                            DataTable dt = ds.Tables[0];
                            if (dt.Rows.Count != 0)
                            {
                                CerErorrTerType.CaptionTitle = String.Format("信息提示：类别名称已存在,请重新输入类别名称!");
                                textBox_TerTypeName.Focus();
                                textBox_TerTypeName.SelectAll();
                                return false;
                            }
                        }
                    }
                }
                #endregion
            }
            return true;
        }
        #endregion

        #region [ 事件: 修改、删除 区域类别 ]
        private void dgv_TerType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)                 //点击“修改”

            {
                vsp_TerType.Visible = true;
                buttonCaptionPanel9.CaptionTitle = "修改区域类别";
                buttonCaptionPanel8.CaptionTitle = "修改并返回";
                buttonCaptionPanel6.CaptionTitle = "返回";
                CerErorrTerType.CaptionTitle = String.Format("信息提示：一起正常!");
                #region 绑定数据
                temp_TerTypeID = Convert.ToInt32(dgv_TerType.Rows[e.RowIndex].Cells[2].Value);
                temp_TerTypeName = dgv_TerType.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (dgv_TerType.Rows[e.RowIndex].Cells["类别名称"].Value.ToString() == "重点区域"
                        || dgv_TerType.Rows[e.RowIndex].Cells["类别名称"].Value.ToString() == "限制区域")
                {
                    textBox_TerTypeName.Enabled = false;
                }
                textBox_TerTypeName.Text = dgv_TerType.Rows[e.RowIndex].Cells[3].Value.ToString();
                comBox_IsAlarm.SelectedIndex =Convert.ToInt32( dgv_TerType.Rows[e.RowIndex].Cells[4].Value);
                textBox_TerTypeRemark.Text = dgv_TerType.Rows[e.RowIndex].Cells[5].Value.ToString();
                #endregion
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)            //点击“删除”
            {
                DialogResult result;
                if (dgv_TerType.Rows[e.RowIndex].Cells["类别名称"].Value.ToString() == "重点区域"
                        || dgv_TerType.Rows[e.RowIndex].Cells["类别名称"].Value.ToString() == "限制区域"
                        || dgv_TerType.Rows[e.RowIndex].Cells["类别名称"].Value.ToString() == "地域")
                {
                    MessageBox.Show("无法删除系统必备类别", "提示");
                }
                else
                {
                    result = MessageBox.Show("删除该区域类别，将会导致该区域类别相关的信息丢失，确定删除吗？", "提示", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        model = 3;
                        operated = 2;


                        //存入日志
                        LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "删除区域类别，类型名称：" + dgv_TerType.Rows[e.RowIndex].Cells[3].Value);

                        temp_TerTypeID = Convert.ToInt32(dgv_TerType.Rows[e.RowIndex].Cells[2].Value);

                        if (!New_DBAcess.IsDouble)
                        {
                            areaBll.DeleteTerType(temp_TerTypeID);
                            InitdgvTerInfo();           //刷新 区域信息
                            InitdgvTerSet();            //刷新 区域设置
                            InitdgvTerType();           //刷新 区域类别
                            areaBll.GetTerTypeCmb1(comBox_TerType);       //刷新 区域类别1
                            areaBll.GetTerTypeCmb2(comBox_TerInfoType);       //刷新 区域类别2
                            areaBll.GetTerNameCmb(comBox_TerName);          //刷新 区域名称
                        }
                        else
                        {
                            timer1.Stop();
                            timer1.Start();
                        }

                    }
                }

            }
        }
        #endregion

        #region [ 事件: 存储并新增、修改并返回 区域设置 ]
        private void buttonCaptionPanel8_Click(object sender, EventArgs e)
        {
            if (CheckingTerType())
            {
                if (buttonCaptionPanel8.CaptionTitle.CompareTo("存储并新增") == 0)         //"存储并新增"
                {
                    //存入日志
                    LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "新增区域类别，类型名称：" + textBox_TerTypeName.Text
                        + "，报警设置：" + comBox_IsAlarm.SelectedText );

                    model = 3;
                    operated = 1;
                    typeName = textBox_TerTypeName.Text;

                    areaBll.SaveTerTypeData(textBox_TerTypeName.Text, Convert.ToByte(comBox_IsAlarm.SelectedIndex), textBox_TerTypeRemark.Text);

                    if (!New_DBAcess.IsDouble)
                    {
                        InitdgvTerInfo();           //刷新 区域信息
                        InitdgvTerType();           //刷新 区域类别
                        InitdgvTerSet();            //刷新 区域设置
                        areaBll.GetTerTypeCmb1(comBox_TerType);       //刷新 区域类别1
                        areaBll.GetTerTypeCmb2(comBox_TerInfoType);       //刷新 区域类别2
                        dgv_TerSet.DataSource = areaBll.GetTerSetTable();       //刷新 区域设置
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                }
                else                                                                        //"修改并返回"
                {
                    //存入日志
                    LogSave.Messages("[FrmAreaManage]", LogIDType.UserLogID, "修改区域类别，类型名称：" + textBox_TerTypeName.Text
                        + "，报警设置：" + comBox_IsAlarm.SelectedText);


                    model = 3;
                    operated = 1;
                    typeName = textBox_TerTypeName.Text;

                    areaBll.UpDateTerType(temp_TerTypeID, textBox_TerTypeName.Text, Convert.ToByte(comBox_IsAlarm.SelectedIndex), textBox_TerTypeRemark.Text);
                    vsp_TerType.Visible = false;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitdgvTerInfo();           //刷新 区域信息
                        InitdgvTerType();           //刷新 区域类别
                        InitdgvTerSet();            //刷新 区域设置
                        areaBll.GetTerTypeCmb1(comBox_TerType);       //刷新 区域类别1
                        areaBll.GetTerTypeCmb2(comBox_TerInfoType);       //刷新 区域类别2
                        dgv_TerSet.DataSource = areaBll.GetTerSetTable();       //刷新 区域设置
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }  
                }
                textBox_TerTypeName.Enabled = true;
            }
        }
        #endregion

        #region [ 方法: 存储并返回、返回 区域设置 ]
        private void buttonCaptionPanel6_Click(object sender, EventArgs e)
        {
            if (CheckingTerType())
            {
                if (buttonCaptionPanel6.CaptionTitle.CompareTo("存储并返回") == 0)           //"存储并返回"
                {

                    model = 3;
                    operated = 1;

                    typeName = textBox_TerTypeName.Text;

                    areaBll.SaveTerTypeData(textBox_TerTypeName.Text, Convert.ToByte(comBox_IsAlarm.SelectedIndex), textBox_TerTypeRemark.Text);
                    vsp_TerType.Visible = false;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitdgvTerInfo();           //刷新 区域信息
                        InitdgvTerType();           //刷新 区域类别
                        InitdgvTerSet();            //刷新 区域设置
                        areaBll.GetTerTypeCmb1(comBox_TerType);       //刷新 区域类别1
                        areaBll.GetTerTypeCmb2(comBox_TerInfoType);       //刷新 区域类别2
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                    
                }
                else                                                                          //"返回"
                {
                    vsp_TerType.Visible = false;
                }
            }
        }
        #endregion

        #region [ 事件: "×" 关闭 新增区域信息 ]
        private void buttonCaptionPanel9_CloseButtonClick(object sender, EventArgs e)
        {
            vsp_TerType.Visible = false;
        }
        #endregion

        #region [ 事件: 拖动 ]
        private void buttonCaptionPanel9_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void buttonCaptionPanel9_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void buttonCaptionPanel9_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion

        private void tvStation_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("123");
            if (tvStation.SelectedNode != null)
            {
                if (tvStation.SelectedNode.Name == strStation)
                {
                    intX = 1;
                }
            }
        }

       
        #endregion

        #region [ 事件: 区域设置信息导出Excel ]

        private void buttonCaptionPanel13_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dgv_TerSet);
        }

        #endregion

        #region [ 事件: 区域信息导出Excel ]

        private void buttonCaptionPanel14_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dgv_TerInfo);
        }

        #endregion

        #region [ 事件: 区域类别导出Excel ]

        private void buttonCaptionPanel15_Click(object sender, EventArgs e)
        {
            ExcelExports.ExportDataGridViewToExcel(dgv_TerType);
        }

        #endregion

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

        private string territorialName = "";

        private string typeName = "";

        /// <summary>
        /// 1表示区域设置，2表示区域信息，3表示区域类别
        /// </summary>
        private int model = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (model)
            {
                #region [区域设置]

                case 1:

                    if (times < maxTimes)
                    {
                        times++;

                        //刷新

                        EmpInfo(int.Parse(txtPage.CaptionTitle));

                        timer1.Stop();
                        timer1.Start();
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timer1.Stop();
                    }

                    break;

                #endregion

                #region [区域信息]

                case 2:

                    if (operated == 1)
                    {

                        if (times < maxTimes)
                        {
                            times++;

                            InitdgvTerInfo();           //刷新 区域信息
                            InitdgvTerSet();            //刷新 区域设置
                            areaBll.GetTerNameCmb(comBox_TerName);                  //刷新 区域名称
                            dgv_TerSet.DataSource = areaBll.GetTerSetTable();       //刷新 区域设置表

                            timer1.Stop();
                            timer1.Start();
                        }
                        else
                        {
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                    }
                    else
                    {
                        if (times < maxTimes)
                        {
                            times++;

                            InitdgvTerInfo();           //刷新 区域信息
                            InitdgvTerSet();            //刷新 区域设置
                            areaBll.GetTerNameCmb(comBox_TerName);
                            dgv_TerSet.DataSource = areaBll.GetTerSetTable();       //刷新 区域名称
                        }
                        else
                        {
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                    }

                    break;

                #endregion

                #region[区域类别]

                case 3:

                    if (operated == 1)
                    {

                        if (times < maxTimes)
                        {
                            times++;

                            //刷新
                            InitdgvTerInfo();           //刷新 区域信息
                            InitdgvTerType();           //刷新 区域类别
                            InitdgvTerSet();            //刷新 区域设置
                            areaBll.GetTerTypeCmb1(comBox_TerType);       //刷新 区域类别1
                            areaBll.GetTerTypeCmb2(comBox_TerInfoType);       //刷新 区域类别2

                            timer1.Stop();
                            timer1.Start();
                        }
                        else
                        {
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                    }
                    else
                    {
                        if (times < maxTimes)
                        {
                            times++;

                            //刷新
                            areaBll.DeleteTerType(temp_TerTypeID);
                            InitdgvTerInfo();           //刷新 区域信息
                            InitdgvTerSet();            //刷新 区域设置
                            InitdgvTerType();           //刷新 区域类别
                            areaBll.GetTerTypeCmb1(comBox_TerType);       //刷新 区域类别1
                            areaBll.GetTerTypeCmb2(comBox_TerInfoType);       //刷新 区域类别2
                            areaBll.GetTerNameCmb(comBox_TerName);          //刷新 区域名称

                            timer1.Stop();
                            timer1.Start();
                        }
                        else
                        {
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                    }

                    break;

                #endregion

                default:
                    break;
            }
        }

        #endregion

        /// <summary>
        /// 刷新区域类别信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpReType_Click(object sender, EventArgs e)
        {
            InitdgvTerType();
        }

        /// <summary>
        /// 刷新区域信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpReInfo_Click(object sender, EventArgs e)
        {
            InitdgvTerInfo();
        }

        /// <summary>
        /// 刷新区域配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bcpReConfig_Click(object sender, EventArgs e)
        {
            InitdgvTerSet();
        }
    }
}