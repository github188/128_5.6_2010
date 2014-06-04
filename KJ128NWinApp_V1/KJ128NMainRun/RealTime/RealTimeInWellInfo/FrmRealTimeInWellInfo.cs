using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NMainRun.RealTime.ReelTimeMonitorInfo;
using KJ128NInterfaceShow;
using KJ128NDataBase;

namespace KJ128NMainRun.RealTime.RealTimeInWellInfo
{
    public partial class FrmRealTimeInWellInfo : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private RealTimeBLL rtbll = new RealTimeBLL();
        private static int pSize = 40;                  //每页条数
        private static string deptID = "";
        private string strDeptID="0";
        private static string where = "";
        /// <summary>
        /// 判断是否是报警
        /// </summary>
        private bool blIsAlarm = false;
        private string strSum = "";

        #endregion


        #region [ 构造函数 ]

        public FrmRealTimeInWellInfo(bool bl,string str)
        {
            InitializeComponent();
            Init();
            blIsAlarm = bl;
            tvDept.SelectedNode = tvDept.Nodes[0];
            tvDept.ExpandAll();
            strDeptID = str;
            label3.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
        }

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 加载信息 ]

        private void Init()
        {
            LoadDept();                             // 加载部门树信息

            LoadCmb();

            //RtDeptInfo(1,false);                       // 初始化部门实时信息


            txtDateBegin.Text = DateTime.Now.AddYears(-1).ToString("yyyy年MM月dd日");
            cmb_Size.SelectedIndex = 0;            //每页显示条数为20
        }

        #endregion

        #region [ 方法: 加载部门树信息 ]

        private void LoadDept()
        {
            DataTable dt = rtbll.getDeptInfo();
            tvDept.ReadDept_Info(dt);
        }

        #endregion

        #region [ 方法: 加载下拉菜单信息 ]

        private void LoadCmb()
        {
            DeptBLL deptbll = new DeptBLL();

            deptbll.getDutyNameCmb(cmbDutyName);    // 职务名称
            deptbll.getDutyClassCmb(cmbDutyClass);  // 职务等级
            deptbll.getWorkTypeCmb(cmbWorkType);    // 工种
            deptbll.getCerTypeCmb(cmbCerType);      // 证书类别

            deptbll.getEquTYpeCmb(cmbEquType);      // 设备类型
            deptbll.getEquFactoryCmb(cmb);          // 生产厂家
        }

        #endregion

        #region [ 方法: 刷新当页数据 ]

        private void LoadRTDeptInfo()
        {
            if (txtPage.CaptionTitle != string.Empty)
            {
                int pIndex = int.Parse(txtPage.CaptionTitle);
                RtDeptInfo(pIndex,false);
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

        #region [ 方法: 组织查询条件 ]

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
                            {"DutyClassID","=",cmbDutyClass.SelectedValue.ToString()=="0"?"":cmbDutyClass.SelectedValue.ToString(),"int"},
                            {"WorkTypeID","=",cmbWorkType.SelectedValue.ToString()=="0"?"":cmbWorkType.SelectedValue.ToString(),"int"},
                            {"CerTypeID","=",cmbCerType.SelectedValue.ToString()=="0"?"":cmbCerType.SelectedValue.ToString(),"int"},
                            {"IDCard","=",txtEmpCard.Text,"string"},
                            //{"EmpName","!=","''","int"},
                            {"CsTypeID","=","0","int"}
                };
                }
                else
                {
                    strArray = new string[9, 4]{{"EmpName","=",txtName.Text,"string"},
                            {"CodeSenderAddress","=",txtCardAddress.Text,"int"},
                            {"DutyID","=",cmbDutyName.SelectedValue.ToString()=="0"?"":cmbDutyName.SelectedValue.ToString(),"int"},
                            {"DutyClassID","=",cmbDutyClass.SelectedValue.ToString()=="0"?"":cmbDutyClass.SelectedValue.ToString(),"int"},
                            {"WorkTypeID","=",cmbWorkType.SelectedValue.ToString()=="0"?"":cmbWorkType.SelectedValue.ToString(),"int"},
                            {"CerTypeID","=",cmbCerType.SelectedValue.ToString()=="0"?"":cmbCerType.SelectedValue.ToString(),"int"},
                            {"IDCard","=",txtEmpCard.Text,"string"},
                            //{"EmpName","!=","''","int"},
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

        #endregion

        #region [ 方法: 查询下井信息 ]

        private void RtDeptInfo(int pIndex, bool isCheckPage)
        {
            if (pIndex < 1)
            {
                return;
            }

            DataSet ds = null;
            if (rbtnEmp.Checked)
            {
                ds = rtbll.getRTInWellEmpInfo(pIndex - 1, pSize, where);
            }
            else if (rbtnDept.Checked)
            {
                ds = rtbll.getRTInWellEquInfo(pIndex - 1, pSize, where);
            }

            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }
            bcpInfo.CaptionTitle = "信息栏：对查询结果，或者执行错误的提示";

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                strSum = sumPage.ToString();
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;

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
                        //bcpPageSum.Visible = false;
                        //bcpPageSum.Visible = true;
                        //bcpPageSum.Location = new Point(683, 5);
                    }
                    else
                    {
                        //bcpPageSum.Location = new Point(380, 5);
                        pageControlsVisible(true);
                       // bcpPageSum.Visible = true;
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

                    if (isCheckPage)
                    {
                        bcpInfo.CaptionTitle = "您输入的页数超出范围,请正确输入页数";
                    }
                    else
                    {
                        RtDeptInfo(sumPage, false);
                    }
                    return;
                }

                //bcpPageSum.CaptionTitle = "本页" + ds.Tables[0].Rows.Count.ToString() + "条/共查到" + ds.Tables[1].Rows[0][0].ToString() + "条";
                //bcpPageSum.CaptionTitle = "共" + ds.Tables[1].Rows[0][0].ToString() + "条";
                txtPage.CaptionTitle = pIndex.ToString();
                lblSumPage.CaptionTitle = "/" + sumPage + "页";
                dgvRTInfo.Columns.Clear();
                dgvRTInfo.DataSource = ds.Tables[0];

                //人员
                if (rbtnEmp.Checked)
                {
                    //将下井时间精确到秒
                    dgvRTInfo.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                    dgvRTInfo.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgvRTInfo.Columns[5].FillWeight = 130;
                    dgvRTInfo.Columns[5].HeaderText = HardwareName.Value(CorpsName.InWellTime);
                    dgvRTInfo.Columns[6].HeaderText = HardwareName.Value(CorpsName.StandingWellTime);
                    if (sumPage > 1)
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时下井信息:\t共 " + ds.Tables[1].Rows[0][0].ToString() + " 人";
                    }
                    else
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时下井信息:  \t\t\t\t\t\t    共 " + ds.Tables[1].Rows[0][0].ToString() + " 人";
                    }
                    //增加 查看 按钮
                    AddColumns(dgvRTInfo);
                }
                else       //设备
                {
                    //将下井时间精确到秒
                    dgvRTInfo.Columns[0].HeaderText = HardwareName.Value(CorpsName.CodeSenderAddress);
                    dgvRTInfo.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dgvRTInfo.Columns[3].HeaderText = HardwareName.Value(CorpsName.InWellTime);
                    dgvRTInfo.Columns[4].HeaderText = HardwareName.Value(CorpsName.StandingWellTime);
                    if (sumPage > 1)
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时下井信息:\t共 " + ds.Tables[1].Rows[0][0].ToString() + " 个设备";
                    }
                    else
                    {
                        buttonCaptionPanel8.CaptionTitle = "实时下井信息:  \t\t\t\t\t\t    共 " + ds.Tables[1].Rows[0][0].ToString() + " 个设备";
                    }
                }
            }
            else
            {
                pageControlsVisible(false);
                //bcpPageSum.Visible = false;
            }
        }

        #endregion

        #region [ 方法: 查找所有的子节点 ]

        private void SelectNodeAllChild(TreeNode tn)
        {
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    if (n.Nodes.Count > 0)
                    {
                        SelectNodeAllChild(n);
                    }
                    if (n.Name == "N" + strDeptID)
                    {
                        tvDept.SelectedNode = n;
                    }
                }
            }
        }

        #endregion

        #region [ 方法: 清空 ]

        //人员
        private void empClear()
        {
            txtName.Text = "";
            txtCardAddress.Text = "";
            cmbDutyName.SelectedIndex = 0;
            cmbDutyClass.SelectedIndex = 0;
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

        #region [ 方法: 添加查看列 ]

        private void AddColumns(DataGridView dgvTmep)
        {
            DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
            dgvLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvLink.HeaderText = "查看员工信息";
            dgvLink.Name = "EmpInfo";
            dgvLink.Text = "查看";
            dgvLink.UseColumnTextForLinkValue = true;
            dgvLink.Resizable = DataGridViewTriState.False;
            dgvTmep.Columns.Add(dgvLink);
        }

        #endregion


        /*
         * 事件
         */ 

        #region [ 事件: 窗体加载 ]

        private void FrmRealTimeInWellInfo_Load(object sender, EventArgs e)
        {
            if (blIsAlarm)
            {
                rbtnEmp_CheckedChanged(sender, e);
            }


            if (strDeptID != "0")
            {
                SelectNodeAllChild(tvDept.Nodes[0]);
                cbpExec_Click(sender, e);
            }
        }

        #endregion

        #region [ 事件: 定时器 ]

        private void timeControl_Tick(object sender, EventArgs e)
        {
            if (this.IsActivated)
            {
                LoadRTDeptInfo();               // 刷新当页数据
            }
        }

        #endregion

        #region [ 事件: 翻页事件 ]

        // 跳至
        void cpCheckPage_Click(object sender, EventArgs e)
        {
            if (txtCheckPage.Text == "") return;
            bcpInfo.CaptionTitle = "信息栏：对查询结果，或者执行错误的提示";
            string value = txtCheckPage.Text;
            int page = int.Parse(value);
            if (page <= 0)
            {
                bcpInfo.CaptionTitle = "信息栏：请正确输入要跳至的页数";
            }
            RtDeptInfo(page,true);

        }

        // 下一页

        void cpDown_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page++;
            // 显示方式
            RtDeptInfo(page,false);
            
        }

        // 上一页

        void cpUp_Click(object sender, EventArgs e)
        {
            int page = int.Parse(txtPage.CaptionTitle);
            page--;
            // 显示方式
            RtDeptInfo(page, false);
        }

        #endregion

        #region [ 事件: 人员和设备rbtn单击事件 ]

        private void rbtnDept_CheckedChanged(object sender, EventArgs e)
        {
            where = strWhere();
            RtDeptInfo(1, false);
            gbx0.Visible = false;
            gbx1.Visible = true;
        }

        private void rbtnEmp_CheckedChanged(object sender, EventArgs e)
        {
            where = strWhere();
            RtDeptInfo(1, false);
            gbx0.Visible = true;
            gbx1.Visible = false ;
        }

        #endregion

        #region [ 事件: 部门树单击事件 ]

        // 部门树选择
        private void tvDept_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //string tmpNode = e.Node.Name.Substring(1);
            //if (tmpNode == "oot")
            //{
            //    deptID = "";
            //    RtDeptInfo(1, false);
            //}
            //else
            //{
            //    deptID = e.Node.Name.Substring(1);
            //    getNodeAllChild(e.Node);
            //    RtDeptInfo(1, false);
            //}
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

        #region [ 事件: 查询按钮_Click事件 ]

        private void cbpExec_Click(object sender, EventArgs e)
        {
            string tmpNode = tvDept.SelectedNode.Name.Substring(1); //e.Node.Name.Substring(1);
            if (tmpNode == "oot")
            {
                deptID = "";
                //RtDeptInfo(1, false);
            }
            else
            {
                deptID = tvDept.SelectedNode.Name.Substring(1);
                getNodeAllChild(tvDept.SelectedNode);
               // RtDeptInfo(1, false);
            }
            where = strWhere();
            RtDeptInfo(1, false);
            tvDept.Focus();
        }

        #endregion

        #region [ 事件: 重置按钮_Click事件 ]

        private void bcpClear_Click(object sender, EventArgs e)
        {
            empClear();
            EquClear();
        }

        #endregion

        #region [ 事件: 是否实时更新按钮_Click事件 ]

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

        #region [ 事件: 是否启用日期查询 ]

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

        #region [ 事件: 选择每页显示条数 ]

        private void cmb_Size_DropDownClosed(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(cmb_Size.SelectedItem);
            RtDeptInfo(1, false);                       // 初始化部门实时信息
        }

        #endregion

        #region [ 事件: 点击部门树 ]

        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            if (tvDept.SelectedNode.Name == "root")
            {
                deptID = "";
                if (rbtnEmp.Checked)
                {
                    where = " EmpName!='' And CsTypeID=0 ";
                }
                else
                {
                    where = " CsTypeID=1";
                }
            }
            else
            {
                deptID = e.Node.Name.Substring(1);
                getNodeAllChild(e.Node);
                if (rbtnEmp.Checked)
                {
                    where = " EmpName!='' And CsTypeID=0 And ( DeptID=" + deptID +")";
                }
                else
                {
                    where = " CsTypeID=1 And ( DeptID=" + deptID + " )";
                }
                //RtDeptInfo(1, false);
            }
            //where = " EmpName!='' And CsTypeID=0 And " + deptID;//deptID;
            //where = strWhere();
            RtDeptInfo(1, false);
        }
        #endregion

        #region [ 事件: 单击下井信息表中单元格 ]
        //private void dgvRTInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        string strCodeSenderAddress = dgvRTInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
        //        RealTimeMonitorInfo rtmi = new RealTimeMonitorInfo(strCodeSenderAddress);
        //        rtmi.Show();
        //    }
        //}
        #endregion

        #region [ 事件: 单击单元格 跳转到 实时发码器信息窗体 ]
        private void dgvRTInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string strCodeSenderAddress = dgvRTInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                RealTimeMonitorInfo rtmi = new RealTimeMonitorInfo(strCodeSenderAddress);
                rtmi.Show();
            }
        }
        #endregion

        #region [ 事件: 打印 ]
        private void cpToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvRTInfo,Text,"下井人员总数:"+strSum);
        }
        #endregion

        #region [ 事件: 单击DataGridView单元格 ]

        private void dgvRTInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRTInfo.Columns[e.ColumnIndex].HeaderText.Equals("查看员工信息") && e.RowIndex >= 0)
            {
                string strCodeSenderAddress = dgvRTInfo.Rows[e.RowIndex].Cells["发码器编号"].Value.ToString();
                FrmEmpInfo frm = new FrmEmpInfo(strCodeSenderAddress,false);
                frm.ShowDialog();

                frm.Dispose();
            }
        }

        #endregion
    }
}