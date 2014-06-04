using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NInterfaceShow;
using System.IO;
using KJ128NDataBase;

namespace KJ128NMainRun.RealTime.ReelTimeMonitorInfo
{
    public partial class RealTimeMonitorInfo : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private RealTimeBLL rtbll = new RealTimeBLL();
        private static int pSize = 40;                  //每页条数
        private string deptID = "";
        private static int intPageCounts = 0;
        private static int countPage = 0;
        private string strCodeSenderAddress = "";
        private string sum = "";

        #endregion


        #region [ 构造函数 ]

        public RealTimeMonitorInfo(string strTempCodeAddress)
        {
            if (strTempCodeAddress != "")
            {
                strCodeSenderAddress = strTempCodeAddress;
            }
            InitializeComponent();

            label3.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";

            Init();
        }
        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 分页查询 ]

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pIndex">第几页</param>
        private void SelectInfo(int pIndex)
        {
            //dgvRTInfo.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);

            if (pIndex < 1)
            {
                //MessageBox.Show("您输入的页数超出范围,请正确输入页数！");
                return;
            }
            DataSet ds = new DataSet();
            string where;
            if (rbtnEmp.Checked)
            {
                where = rtbll.WhereEmp(txtName.Text.Trim(), txtCardAddress.Text.Trim(), Convert.ToInt32(cmbDutyName.SelectedValue), Convert.ToInt32(cmbWorkType.SelectedValue), Convert.ToInt32(cmbCerType.SelectedValue), txtEmpCard.Text.Trim(), deptID);
                ds = rtbll.GetRTInMineEmp(pIndex, pSize, where);
            }
            else
            {
                string strDateBegin, strDateEnd;
                if (chkIsDate.Checked)
                {
                    strDateBegin = txtDateBegin.Text.Trim();
                    strDateEnd = txtDateEnd.Text.Trim();
                }
                else
                {
                    strDateBegin = "";
                    strDateEnd = "";
                }
                where = rtbll.WhereEqu(txtNO.Text.Trim(), txtEquName.Text.Trim(), txtEquAddress.Text.Trim(), strDateBegin, strDateEnd, Convert.ToInt32(cmbEquType.SelectedValue), Convert.ToInt32(cmb.SelectedValue), deptID);
                ds = rtbll.GetRTInMineEqu(pIndex, pSize, where);
            }
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sum = sumPage.ToString();
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (!cpUp.Enabled)
                {
                    cpUp.Enabled = true;
                }
                if (!cpDown.Enabled)
                {
                    cpDown.Enabled = true;
                }
                //if (sumPage > 1)
                //{
                //    //bcpPageSum.Location = new Point(368, 5);
                //}
                //else
                //{
                //    bcpPageSum.Location = new Point(682, 5);
                //}
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
                        bcpInfo.CaptionTitle = "信息栏：第一页";
                    }
                }
                else if (pIndex == sumPage)
                {
                    cpDown.Enabled = false;
                    bcpInfo.CaptionTitle = "信息栏：最后一页";
                    // 最后一页
                }
                else if (pIndex > sumPage || pIndex < 1)
                {
                    // 大于最后一页
                    bcpInfo.CaptionTitle = "您输入的页数超出范围,请正确输入页数";
                    return;
                }
                if (pIndex > sumPage)
                {
                    if (sumPage == 0)
                    {
                        dgvRTInfo.Columns.Clear();
                        dgvRTInfo.DataSource = ds.Tables[0];
                        if (rbtnEmp.Checked)
                        {

                            dgvRTInfo.Columns[8].Visible = false;
                            dgvRTInfo.Columns[9].Visible = false;
                            dgvRTInfo.Columns[10].Visible = false;
                            dgvRTInfo.Columns[11].Visible = false;
                            dgvRTInfo.Columns[12].Visible = false;
                            dgvRTInfo.Columns[13].Visible = false;
                            dgvRTInfo.Columns[14].Visible = false;
                            dgvRTInfo.Columns[0].FillWeight = 50;
                            dgvRTInfo.Columns[1].FillWeight = 60;
                            dgvRTInfo.Columns[2].FillWeight = 70;
                            dgvRTInfo.Columns[3].FillWeight = 80;
                            dgvRTInfo.Columns[4].FillWeight = 90;
                            dgvRTInfo.Columns[5].FillWeight = 120;
                            dgvRTInfo.Columns[6].FillWeight = 170;
                            dgvRTInfo.Columns[7].FillWeight = 190;
                            dgvRTInfo.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                            buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:  \t\t\t\t\t       共 0 人";
                        }
                        else
                        {
                            dgvRTInfo.Columns[6].Visible = false;
                            dgvRTInfo.Columns[7].Visible = false;
                            dgvRTInfo.Columns[8].Visible = false;
                            dgvRTInfo.Columns[9].Visible = false;
                            dgvRTInfo.Columns[10].Visible = false;
                            dgvRTInfo.Columns[11].Visible = false;
                            dgvRTInfo.Columns[12].Visible = false;
                            dgvRTInfo.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                            buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:  \t\t\t\t\t   共 0 个设备";
                        }

                        //bcpPageSum.CaptionTitle = "0 条";
                        
                        pageControlsVisible(false);
                        return;
                    }
                    // 大于最后一页
                    return;
                }
               // bcpPageSum.CaptionTitle = "共" + ds.Tables[1].Rows[0][0].ToString() + "条";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";

                dgvRTInfo.Columns.Clear();
                dgvRTInfo.DataSource = ds.Tables[0];
                if (rbtnEmp.Checked)
                {
                    dgvRTInfo.Columns[8].Visible = false;
                    dgvRTInfo.Columns[9].Visible = false;
                    dgvRTInfo.Columns[10].Visible = false;
                    dgvRTInfo.Columns[11].Visible = false;
                    dgvRTInfo.Columns[12].Visible = false;
                    dgvRTInfo.Columns[13].Visible = false;
                    dgvRTInfo.Columns[14].Visible = false;
                    dgvRTInfo.Columns[0].FillWeight = 50;
                    dgvRTInfo.Columns[1].FillWeight = 60;
                    dgvRTInfo.Columns[2].FillWeight = 70;
                    dgvRTInfo.Columns[3].FillWeight = 80;
                    dgvRTInfo.Columns[4].FillWeight = 90;
                    dgvRTInfo.Columns[5].FillWeight = 140;
                    dgvRTInfo.Columns[6].FillWeight = 170;
                    dgvRTInfo.Columns[7].FillWeight = 190;
                    dgvRTInfo.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);

                    dgvRTInfo.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (sumPage > 1)
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:\t共 " + ds.Tables[1].Rows[0][0].ToString() + " 人";
                    }
                    else
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:  \t\t\t\t\t       共 " + ds.Tables[1].Rows[0][0].ToString() + " 人";
                    }
                }
                else
                {
                    dgvRTInfo.Columns[6].Visible = false;
                    dgvRTInfo.Columns[7].Visible = false;
                    dgvRTInfo.Columns[8].Visible = false;
                    dgvRTInfo.Columns[9].Visible = false;
                    dgvRTInfo.Columns[10].Visible = false;
                    dgvRTInfo.Columns[11].Visible = false;
                    dgvRTInfo.Columns[12].Visible = false;
                    dgvRTInfo.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                    dgvRTInfo.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (sumPage > 1)
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:\t共 " + ds.Tables[1].Rows[0][0].ToString() + " 个设备";
                    }
                    else
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:  \t\t\t\t\t   共 " + ds.Tables[1].Rows[0][0].ToString() + " 个设备";
                    }
                }
                #region 控制“上一页”、“下一页”等按钮的显示状态
                if (Convert.ToInt32(ds.Tables[1].Rows[0][0]) <= pSize)
                {
                    pageControlsVisible(false);
                }
                else
                {
                    pageControlsVisible(true);
                }
                #endregion
            }

            dgvRTInfo.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
        }
        #endregion

        #region [ 方法: 清空 ]

        //人员
        private void empClear()
        {
            txtName.Text = "";
            txtCardAddress.Text = "";
            cmbDutyName.SelectedIndex = 0;
            cmbWorkType.SelectedIndex = 0;
            cmbCerType.SelectedIndex = 0;
            txtEmpCard.Text = "";
        }

        //设备
        private void EquClear()
        {
            foreach (Control cl in gbx1.Controls)
            {
                if (cl.GetType() == typeof(TextBox))
                {
                    ((TextBox)cl).Text = "";
                }
                if (cl.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)cl).SelectedIndex = 0;
                }
            }
        }

        #endregion

        #region [ 方法: 加载 ]
        private void Init()
        {
            LoadDept();                             // 加载部门树信息
            LoadCmb();
            //RtDeptInfo(1);                       // 初始化部门实时信息

            cmbSize.SelectedIndex = 0;
            txtDateBegin.Text = DateTime.Now.AddYears(-1).ToString("yyyy年MM月dd日");

        }

        // 加载部门树信息
        private void LoadDept()
        {
            DataTable dt = rtbll.getDeptInfo();
            tvDept.ReadDept_Info(dt);
            tvDept.ExpandAll();
            tvDept.SelectedNode = tvDept.Nodes[0];
        }

        // 加载下拉菜单信息
        private void LoadCmb()
        {
            DeptBLL deptbll = new DeptBLL();

            deptbll.getDutyNameCmb(cmbDutyName);    // 职务名称
            deptbll.getWorkTypeCmb(cmbWorkType);    // 工种
            deptbll.getCerTypeCmb(cmbCerType);      // 证书类别

            deptbll.getEquTYpeCmb(cmbEquType);      // 设备类型
            deptbll.getEquFactoryCmb(cmb);          // 生产厂家
        }

        // 刷新当页数据
        private void LoadRTDeptInfo()
        {
            if (txtPage.CaptionTitle != string.Empty)
            {
                int pIndex = int.Parse(txtPage.CaptionTitle);
                if (chbIsInMine.Checked)
                {
                    SelectInfo(pIndex);
                }
                else
                {
                    RtDeptInfo(pIndex);
                }
            }
        }

        // 定时器事件
        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                if (chk.Checked)
                {
                    LoadRTDeptInfo();               // 刷新当页数据
                }
            }
        }

        #endregion

        #region [ 方法: 处理空数据页数显示 ]
        // 处理空数据页数显示
        private void pageControlsVisible(bool bl)
        {
            cpUp.Visible = bl;
            cpDown.Visible = bl;
            txtPage.Visible = bl;
            lblSumPage.Visible = bl;
            txtCheckPage.Visible = bl;
            cpCheckPage.Visible = bl;
        }

        #endregion

        #region [ 方法: 查询 ]
        //组织查询条件
        private string strWhere()
        {
            string[,] strArray = null;
            // 人员查询
            if (rbtnEmp.Checked)
            {
                //是否是多有部门显示
                if (deptID == "")
                {
                    strArray = new string[8, 4]{{"EmpName","=",txtName.Text,"string"},
                            {"CodeSenderAddress","=",txtCardAddress.Text,"int"},
                            {"DutyID","=",cmbDutyName.SelectedValue.ToString()=="0"?"":cmbDutyName.SelectedValue.ToString(),"int"},
                            {"WorkTypeID","=",cmbWorkType.SelectedValue.ToString()=="0"?"":cmbWorkType.SelectedValue.ToString(),"int"},
                            {"CerTypeID","=",cmbCerType.SelectedValue.ToString()=="0"?"":cmbCerType.SelectedValue.ToString(),"int"},
                            {"IDCard","=",txtEmpCard.Text,"string"},
                            {"EmpName","!=","''","int"},
                            {"CsTypeID","=","0","int"}
                };
                }
                else
                {
                    strArray = new string[9, 4]{{"EmpName","=",txtName.Text,"string"},
                            {"CodeSenderAddress","=",txtCardAddress.Text,"int"},
                            {"DutyID","=",cmbDutyName.SelectedValue.ToString()=="0"?"":cmbDutyName.SelectedValue.ToString(),"int"},
                            {"WorkTypeID","=",cmbWorkType.SelectedValue.ToString()=="0"?"":cmbWorkType.SelectedValue.ToString(),"int"},
                            {"CerTypeID","=",cmbCerType.SelectedValue.ToString()=="0"?"":cmbCerType.SelectedValue.ToString(),"int"},
                            {"IDCard","=",txtEmpCard.Text,"string"},
                            {"EmpName","!=","''","int"},
                            {"DeptID","=",deptID,"int"},
                            {"CsTypeID","=","0","int"}
                };
                }
            }
            else if (rbtnDept.Checked)
            {
                strArray = new string[9, 4]{{"EquNO","=",txtNO.Text,"string"},
                                {"CodeSenderAddress","=",txtEquAddress.Text,"int"},
                                {"EquName","=",txtEquName.Text,"string"},
                                {"ProductionDate",">=",chkIsDate.Checked?Convert.ToDateTime(txtDateBegin.Value).ToString("yyyy-MM-dd"):"","datetime"},
                                {"ProductionDate","<=",chkIsDate.Checked?Convert.ToDateTime(txtDateEnd.Value).AddDays(1).ToString("yyyy-MM-dd"):"","datetime"},
                                {"EquType","=",cmbEquType.SelectedValue.ToString()=="0"?"":cmbEquType.SelectedValue.ToString(),"int"},
                                {"FactoryID","=",cmb.SelectedValue.ToString()=="0"?"":cmb.SelectedValue.ToString(),"string"},
                                {"DeptID","=",deptID,"int"},
                                {"CsTypeID","=","1","int"}
                };
            }
            return rtbll.SelectWhere(strArray, 0);
            
        }
       
        private void RtDeptInfo(int pIndex)
        {
            if (pIndex < 1)
            {
                return;
            }
            string where="";
            if (!rbtnCard.Checked)
            {
                 where= strWhere();
            }
            DataSet ds = null;
            if (rbtnEmp.Checked)
            {
                ds = rtbll.getRTDeptInfo(pIndex - 1, pSize, where);
            }
            else if (rbtnDept.Checked)
            {
                ds = rtbll.getRTDeptEquInfo(pIndex - 1, pSize, where);
            }
            else if (rbtnCard.Checked)
            {
                ds = rtbll.getRTEmptyCardInfo(pIndex - 1, pSize);
            }

            if (pIndex < 1)
            {
                //MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            bcpInfo.CaptionTitle = "信息栏：对查询结果，或者执行错误的提示";

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                intPageCounts = sumPage;
                if (!cpUp.Enabled)
                {
                    cpUp.Enabled = true;
                }
                if (!cpDown.Enabled)
                {
                    cpDown.Enabled = true;
                }
                //if (sumPage > 1)
                //{
                //    bcpPageSum.Location = new Point(368, 5);
                //}
                //else
                //{
                //    bcpPageSum.Location = new Point(682, 5);
                //}
                if (pIndex == 1)
                {
                    // 只有一页时
                    if (sumPage <= 1)
                    {
                        pageControlsVisible(false);
                       // bcpPageSum.Visible = false;
                    }
                    else
                    {
                        pageControlsVisible(true);
                        //bcpPageSum.Visible = true;
                        cpUp.Enabled = false;
                        bcpInfo.CaptionTitle = "信息栏：第一页";
                    }
                }
                else if (pIndex == sumPage)
                {
                    cpDown.Enabled = false;
                    bcpInfo.CaptionTitle = "信息栏：最后一页";
                    // 最后一页
                }
                else if (pIndex > sumPage || pIndex < 1)
                {
                    // 大于最后一页
                    bcpInfo.CaptionTitle = "您输入的页数超出范围,请正确输入页数";
                    //MessageBox.Show(bcpInfo.Controls[1].GetType().ToString());// = Color.Red;
                    return;
                }
                //bcpPageSum.CaptionTitle = "本页" + ds.Tables[0].Rows.Count.ToString() + "条/共查到" + ds.Tables[1].Rows[0][0].ToString() + "条";
                //bcpPageSum.CaptionTitle = "共" + ds.Tables[1].Rows[0][0].ToString() + "条";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";
                dgvRTInfo.Columns.Clear();
                dgvRTInfo.DataSource = ds.Tables[0];
                if (rbtnEmp.Checked)
                {
                    dgvRTInfo.Columns[6].FillWeight = 170;
                    dgvRTInfo.Columns[7].FillWeight = 190;
                    dgvRTInfo.Columns[5].FillWeight = 170;

                    dgvRTInfo.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (sumPage > 1)
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:\t共 " + ds.Tables[1].Rows[0][0].ToString() + " 人";
                    }
                    else
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:  \t\t\t\t\t       共 " + ds.Tables[1].Rows[0][0].ToString() + " 人";
                    }
                }
                else
                {
                    dgvRTInfo.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (sumPage > 1)
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:\t共 " + ds.Tables[1].Rows[0][0].ToString() + " 个设备";
                    }
                    else
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时标识卡信息:  \t\t\t\t\t   共 " + ds.Tables[1].Rows[0][0].ToString() + " 个设备";
                    }
                }
                
            }
            else
            {
                dgvRTInfo.Columns.Clear();
                dgvRTInfo.DataSource = null;
                pageControlsVisible(false);
                //bcpPageSum.Visible = false;
            }
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 翻页事件 ]
        // 跳至
        void cpCheckPage_Click(object sender, EventArgs e)
        {
            if (txtCheckPage.Text == "") return;
            bcpInfo.CaptionTitle = "信息栏：对查询结果，或者执行错误的提示";
            string value = txtCheckPage.Text;
            int page = int.Parse(value);
            if (page == 0)
            {
                bcpInfo.CaptionTitle = "信息栏：请正确输入要跳至的页数";
            }
            if (chbIsInMine.Checked)
            {
                if (page > countPage)
                {
                    page = countPage;
                }
                SelectInfo(page);
            }
            else
            {
                if (page > intPageCounts)
                {
                    page = intPageCounts;
                }
                RtDeptInfo(page);
            }
        }

        // 下一页

        void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            // 显示方式
            if (chbIsInMine.Checked)
            {
                SelectInfo(page);
            }
            else
            {
                RtDeptInfo(page);
            }

        }

        // 上一页

        void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            // 显示方式
            if (chbIsInMine.Checked)
            {
                SelectInfo(page);
            }
            else
            {
                RtDeptInfo(page);
            }
        }

        #endregion

        #region [ 事件: 人员和设备rbtn单击事件 未登记的发码器 ]

        private void rbtnDept_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDept.Checked)
            {
                chbIsInMine.Checked = false;
                chbIsInMine.Enabled = false;
            }


            if (chbIsInMine.Checked)
            {
                SelectInfo(1);
            }
            else
            {
                RtDeptInfo(1);
            }
            gbx0.Visible = false;
            gbx1.Visible = true;
        }

        private void rbtnEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEmp.Checked)
            {
                chbIsInMine.Enabled = true;
            }
            if (chbIsInMine.Checked)
            {
                SelectInfo(1);
            }
            else
            {
                RtDeptInfo(1);
            }
            gbx0.Visible = true;
            gbx1.Visible = false ;
        }

        private void rbtnCard_CheckedChanged(object sender, EventArgs e)
        {
            RtDeptInfo(1);
        }

        #endregion

        #region [ 事件: 部门树单击事件 ]

        // 部门树选择
        private void tvDept_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string tmpNode = e.Node.Name.Substring(1);
            if (tmpNode == "oot")
            {
                deptID = "";
               // RtDeptInfo(1);
            }
            else
            {
                deptID = e.Node.Name.Substring(1);
                getNodeAllChild(e.Node);
                //RtDeptInfo(1);
            }
            if (chbIsInMine.Checked)
            {
                SelectInfo(1);
            }
            else
            {
                RtDeptInfo(1);
            }
        }

        // 遍历节点下的所有子节点
        private void getNodeAllChild(TreeNode tn)
        {
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    if (n.Nodes.Count > 0)
                    {
                        getNodeAllChild(n);
                    }
                    deptID += " or DeptID=" + n.Name.Substring(1);
                }
            }
        }

        #endregion

        #region [ 事件: 按钮操作 ]
        //查询按钮
        private void cbpExec_Click(object sender, EventArgs e)
        {
            if (chbIsInMine.Checked)
            {
                SelectInfo(1);
                tvDept.Focus();
            }
            else
            {
                RtDeptInfo(1);
                tvDept.Focus();
            }
        }

        #region 重置按钮
        private void bcpClear_Click(object sender, EventArgs e)
        {
            empClear();
            EquClear();
            tvDept.ExpandAll();
            tvDept.SelectedNode = tvDept.Nodes[0];
        }
        #endregion

        #region 是否实时更新
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                timeControl.Start();
            }
            else
            {
                timeControl.Stop();
            }
        }
        #endregion
        #endregion

        #region [ 事件: 是否启用日期 ]
        private void chkIsDate_Click(object sender, EventArgs e)
        {
            if (chkIsDate.Checked)
            {
                txtDateBegin.Enabled = true;
                txtDateEnd.Enabled = true;
            }
            else
            {
                txtDateBegin.Enabled = false;
                txtDateEnd.Enabled = false;
            }
        }
        #endregion

        #region [ 事件: 选中每页行数 ]
        private void cmbSize_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmbSize.Text);
            if (chbIsInMine.Checked)
            {
                SelectInfo(1);
            }
            else
            {
                RtDeptInfo(1);
            }
        }
        #endregion

        #region [ 事件: 窗体加载 ]
        private void RealTimeMonitorInfo_Load(object sender, EventArgs e)
        {
            txtCardAddress.Text = strCodeSenderAddress;
            chbIsInMine.Checked = true;
            tvDept.SelectedNode = tvDept.Nodes[0];
            deptID = "";
            SelectInfo(1);
            cpUp.Enabled = false;
            cpDown.Enabled = true;
        }
        #endregion

        #region [ 事件: 打印 ]

        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvRTInfo,Text,rbtnEmp.Checked?"人员总数:"+sum.ToString():"设备总数:"+sum.ToString());
        }

        #endregion
    }
}