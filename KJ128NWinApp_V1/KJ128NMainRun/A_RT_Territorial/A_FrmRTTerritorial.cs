using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NInterfaceShow;
using Wilson.Controls.Docking;

namespace KJ128NMainRun.A_RT_Territorial
{
    public partial class A_FrmRTTerritorial : Wilson.Controls.Docking.DockContent
    {

        #region【声明】

        private A_RTTerritorialBLL rttbll = new A_RTTerritorialBLL();
        private bool blIsEmp = true;
        private DataSet ds;

        private string strWhere = " 1=1";

        private A_TreeBLL tbll = new A_TreeBLL();

        /// <summary>
        /// 1：区域；2：限制区域；3：重点区域；4：地域
        /// </summary>
        private int intSelectModel = 1;

        //czlt-2010-9-16*start*****
        SortOrder sortDirection = new SortOrder();
        private int index = 0;
        private bool isHearderSort;
        private bool isClickSort;
        ListSortDirection listSort;
        //czlt-2010-9-16*end*****

        #endregion

        DockPanel dockPanel = null;
        #region【构造函数】
        public A_FrmRTTerritorial(DockPanel dock)
        {
            InitializeComponent();
            dockPanel = dock;
            this.timer_Alarm.Interval = RefReshTime._rtTime;

            //区域
            dmc_Info.Add(pl_RTTerritorial, true);

            //限制区域
            dmc_Info.Add(pl_ConfineArea);

            //重点区域
            dmc_Info.Add(pl_KeyArea);

            //地域
            dmc_Info.Add(pl_DistrictArea);

            dmc_Info.LeftPartResize();
        }
        #endregion

        #region【窗体加载】

        private void A_FrmRTTerritorial_Load(object sender, EventArgs e)
        {
            LoadComboBox_Dept();    //加载部门信息
            LoadTree(1);    //加载实时区域树——人员
            tvc_Territorial.ExpandAll();
            this.AcceptButton = bt_Territorial_Enquiries;
            RT_Territorial_RefResh();
            timer_Alarm.Enabled = true;

            //Czlt-2010-09-16
            listSort = new ListSortDirection();
            isClickSort = false;
            isHearderSort = false;
        }

        #endregion



        #region【方法：返回当前区域类别】

        private string GetStrTitle()
        {
            string strTitle = "区域";
            switch (intSelectModel)
            {
                case 1:

                    strTitle = "区域";

                    break;
                case 2:

                    strTitle = "限制区域";

                    break;
                case 3:

                    strTitle = "重点区域";

                    break;
                case 4:

                    strTitle = "地域";

                    break;
                default:
                    break;
            }
            return strTitle + "信息";
        }

        #endregion

        #region 【方法: 遍历节点下的所有子节点】

        /// <summary>
        /// 遍历节点下的所有子节点
        /// </summary>
        /// <param name="tn"></param>
        private string GetNodeAllChild(TreeNode tn)
        {
            string strNodeChildName;

            strNodeChildName = " '" + tn.Tag.ToString() + "' ";
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode n in tn.Nodes)
                {
                    if (n.Nodes.Count > 0)
                    {
                        GetNodeAllChild(n);
                    }
                    strNodeChildName += " or 部门= '" + n.Tag.ToString() + "' ";
                }
            }
            return strNodeChildName;
        }
        #endregion

        #region【方法：自定义树的表的行结构】

        private void SetDataRow(ref DataRow dr, int id, string name, int parentid, bool isChild, bool isUserNum, int num)
        {
            dr[0] = id;
            dr[1] = name;
            dr[2] = parentid;
            dr[3] = isChild;
            dr[4] = isUserNum;
            dr[5] = num;
        }

        #endregion

        #region【方法：加载树】
        /// <summary>
        /// 加载实时区域树
        /// </summary>
        /// <param name="intModel">1:人员，2：设备</param>
        private void LoadTree(int intModel)
        {

            switch (intModel)
            {
                case 1:

                    #region【区域——人员】

                    using (ds = new DataSet())
                    {
                        ds = rttbll.GetTerritorialTree_Emp();
                        tbll.LoadTree(tvc_Territorial, ds, "人", true, "所有");
                    }

                    #endregion

                    break;
                case 2:

                    #region【区域——设备】

                    using (ds = new DataSet())
                    {
                        ds = rttbll.GetTerritorialTree_Equ();

                        tbll.LoadTree(tvc_Territorial, ds, "个", true, "所有");
                    }

                    #endregion

                    break;
                case 3:

                    #region【限制区域——人员】

                    using (ds = new DataSet())
                    {
                        ds = rttbll.GetDeptTree_ConfineArea_Emp();

                        tbll.LoadTree(tvc_ConfineArea_Dept, ds, "人", true, "所有");
                    }

                    #endregion

                    break;
                case 4:

                    #region【限制区域——设备】

                    using (ds = new DataSet())
                    {
                        ds = rttbll.GetDeptTree_ConfineArea_Equ();

                        tbll.LoadTree(tvc_ConfineArea_Dept, ds, "个", true, "所有");
                    }

                    #endregion

                    break;
                case 5:

                    #region【重点区域——人员】

                    using (ds = new DataSet())
                    {
                        ds = rttbll.GetDeptTree_KeyArea_Emp();

                        tbll.LoadTree(tvc_KeyArea_Dept, ds, "人", true, "所有");
                    }

                    #endregion

                    break;
                case 6:

                    #region【重点区域——设备】

                    using (ds = new DataSet())
                    {
                        ds = rttbll.GetDeptTree_KeyArea_Equ();

                        tbll.LoadTree(tvc_KeyArea_Dept, ds, "个", true, "所有");
                    }

                    #endregion

                    break;
                case 7:

                    #region【地域——人员】

                    using (ds = new DataSet())
                    {
                        ds = rttbll.GetDeptTree_DistrictArea_Emp();

                        tbll.LoadTree(tvc_DistrictArea_Dept, ds, "人", true, "所有");
                    }

                    #endregion

                    break;
                case 8:

                    #region【地域——设备】

                    using (ds = new DataSet())
                    {
                        ds = rttbll.GetDeptTree_DistrictArea_Equ();

                        tbll.LoadTree(tvc_DistrictArea_Dept, ds, "个", true, "所有");
                    }

                    #endregion

                    break;
                default:
                    break;
            }

        }

        #endregion

        #region【方法：查询实时区域——人员】

        private void Select_Territorial_Emp()
        {
            using (ds = new DataSet())
            {
                ds = rttbll.Select_Territorial_Emp(strWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTTerritorial_Emp";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个记录";

                    //lblMainTitle.Text = GetStrTitle() + "：  共 " + ds.Tables[1].Rows.Count + " 人";

                    dgv_Main.Columns["进入时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (dgv_Main.Columns.Count >= 10)
                    {
                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["姓名"].DisplayIndex = 1;
                        dgv_Main.Columns["部门"].DisplayIndex = 2;
                        dgv_Main.Columns["职务"].DisplayIndex = 3;
                        dgv_Main.Columns["工种"].DisplayIndex = 4;
                        dgv_Main.Columns["区域类型"].DisplayIndex = 5;
                        dgv_Main.Columns["区域名称"].DisplayIndex = 6;
                        dgv_Main.Columns["进入时间"].DisplayIndex = 7;
                        dgv_Main.Columns["持续时长"].DisplayIndex = 8;
                        dgv_Main.Columns["方向性"].DisplayIndex = 9;

                        dgv_Main.Columns["职务"].DefaultCellStyle.NullValue = "——";
                        dgv_Main.Columns["工种"].DefaultCellStyle.NullValue = "——";
                        dgv_Main.Columns["方向性"].DefaultCellStyle.NullValue = "——";

                        if (intSelectModel == 1)
                        {
                            dgv_Main.Columns["区域类型"].Visible = true;
                        }
                        else
                        {
                            dgv_Main.Columns["区域类型"].Visible = false;
                        }
                    }

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个记录";
                    //lblMainTitle.Text = GetStrTitle() + "：  共 0 人";
                }

                //****czlt-2010-9-16**start****
                if (isHearderSort == true)
                {
                    DataGridViewColumn newColumn = dgv_Main.Columns[index];
                    dgv_Main.Sort(newColumn, listSort);
                }
                //****czlt-2010-9-16**end****
            }

        }

        #endregion

        #region【方法：查询实时区域——设备】

        private void Select_Territorial_Equ()
        {
            using (ds = new DataSet())
            {
                ds = rttbll.Select_Territorial_Equ(strWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "A_FrmRTTerritorial_Equ";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个记录";
                    //lblMainTitle.Text = GetStrTitle() + "：  共 " + ds.Tables[1].Rows.Count + " 个";

                    dgv_Main.Columns["进入时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                    if (dgv_Main.Columns.Count >= 9)
                    {
                        dgv_Main.Columns["标识卡号"].DisplayIndex = 0;
                        dgv_Main.Columns["设备名称"].DisplayIndex = 1;
                        dgv_Main.Columns["设备编号"].DisplayIndex = 2;
                        dgv_Main.Columns["部门"].DisplayIndex = 3;
                        dgv_Main.Columns["区域类型"].DisplayIndex = 4;
                        dgv_Main.Columns["区域名称"].DisplayIndex = 5;
                        dgv_Main.Columns["进入时间"].DisplayIndex = 6;
                        dgv_Main.Columns["持续时长"].DisplayIndex = 7;
                        dgv_Main.Columns["方向性"].DisplayIndex = 8;

                        dgv_Main.Columns["方向性"].DefaultCellStyle.NullValue = "——";

                        if (intSelectModel == 1)
                        {
                            dgv_Main.Columns["区域类型"].Visible = true;
                        }
                        else
                        {
                            dgv_Main.Columns["区域类型"].Visible = false;
                        }
                    }

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个记录";
                    //lblMainTitle.Text = GetStrTitle() + "：  共 0 个";
                }

                //****czlt-2010-9-16**start****
                if (isHearderSort == true)
                {

                    DataGridViewColumn newColumn = dgv_Main.Columns[index];
                   
                    dgv_Main.Sort(newColumn, listSort);
                }
                //****czlt-2010-9-16**end****
            }

        }

        #endregion



        #region【事件：定时器】

        private void timer_Alarm_Tick(object sender, EventArgs e)
        {
            //qyz 改 获得焦点刷新
            if ((this.IsActivated || this.DockHandler == dockPanel.ActiveDocument.DockHandler) && chb.Checked)
            {
                switch (intSelectModel)
                {
                    case 1:

                        #region【区域】
                        LoadTree(1);
                        RT_Territorial_RefResh();

                        #endregion

                        break;
                    case 2:

                        #region【限制区域】
                        LoadTree(2);
                        RT_ConfineArea_RefResh();

                        #endregion

                        break;
                    case 3:

                        #region【重点区域】
                        LoadTree(3);
                        RT_KeyArea_RefResh();

                        #endregion

                        break;
                    case 4:

                        #region【地域】
                        LoadTree(4);
                        RT_DistrictArea_RefResh();

                        #endregion

                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region【事件：选择设备、人员】

        private void rb_Emp_CheckedChanged(object sender, EventArgs e)
        {
            strWhere = " 1=1";

            switch (intSelectModel)
            {
                case 1:

                    #region【区域】

                    txt_Territorial_CodeSenderAddress.Text = "";
                    txt_Territorial_EmpName.Text = "";
                    LoadComboBox_Dept();

                    if (rb_Emp.Checked)         //人员
                    {
                        label1.Text = "姓名：";
                        blIsEmp = true;
                        LoadTree(1);    //加载实时区域树——人员

                        strWhere = StrWhere_RTTerr();
                        Select_Territorial_Emp();

                    }
                    else                        //设备
                    {
                        label1.Text = "设备：";
                        blIsEmp = false;
                        LoadTree(2);    //加载实时区域树——设备

                        strWhere = StrWhere_RTTerr();
                        Select_Territorial_Equ();
                    }

                    #endregion

                    break;

                case 2:

                    #region【限制区域】

                    txt_ConfineArea_CodeSenderAddress.Text = "";
                    txt_ConfineArea_EmpName.Text = "";

                    if (rb_Emp.Checked)         //人员
                    {
                        lb_ConfineArea_Name.Text = "姓名：";
                        blIsEmp = true;
                        LoadTree(3);    //加载实时区域树——人员
                    }
                    else                        //设备
                    {
                        lb_ConfineArea_Name.Text = "设备：";
                        blIsEmp = false;
                        LoadTree(4);    //加载实时区域树——设备
                    }

                    Select_ConfineArea();

                    #endregion

                    break;

                case 3:

                    #region【重点区域】

                    txt_KeyArea_CodeSenderAddress.Text = "";
                    txt_KeyArea_EmpName.Text = "";

                    if (rb_Emp.Checked)         //人员
                    {
                        lb_KeyArea_Name.Text = "姓名：";
                        blIsEmp = true;
                        LoadTree(5);
                    }
                    else                        //设备
                    {
                        lb_KeyArea_Name.Text = "设备：";
                        blIsEmp = false;
                        LoadTree(6);
                    }

                    Select_KeyArea();

                    #endregion

                    break;

                case 4:

                    #region【地域】

                    txt_DistrictArea_CodeSenderAddress.Text = "";
                    txt_DistrictArea_EmpName.Text = "";

                    if (rb_Emp.Checked)         //人员
                    {
                        lb_DistrictArea_Name.Text = "姓名：";
                        blIsEmp = true;
                        LoadTree(7);
                    }
                    else                        //设备
                    {
                        lb_DistrictArea_Name.Text = "设备：";
                        blIsEmp = false;
                        LoadTree(8);
                    }

                    Select_DistrictArea();


                    #endregion

                    break;

                default:
                    break;
            }

        }

        #endregion

        

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        /*****************************区域*****************************/

        #region【方法：刷新——区域】

        private void RT_Territorial_RefResh()
        {
            if (blIsEmp)                //人员
            {
                //LoadTree(1);
                Select_Territorial_Emp();
            }
            else                        //设备
            {
                //LoadTree(2);
                Select_Territorial_Equ();
            }
        }

        #endregion

        #region【方法：加载部门】

        /// <summary>
        /// 加载部门
        /// </summary>
        private void LoadComboBox_Dept()
        {
            using (ds = new DataSet())
            {
                ds = rttbll.GetDeptComboBox();
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = 0;
                    dr[1] = "所有";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cmb_Dept.DataSource = ds.Tables[0];
                    cmb_Dept.DisplayMember = "DeptName";
                    cmb_Dept.ValueMember = "DeptID";
                    cmb_Dept.SelectedValue = 0;
                }
            }
        }

        #endregion

        #region【方法：组织查询条件——实时区域】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_RTTerr()
        {
            string strTempWhere = " 1=1 ";

            if (tvc_Territorial.SelectedNode != null && !tvc_Territorial.SelectedNode.Name.Equals("0"))
            {
                if (tvc_Territorial.SelectedNode.Name.Substring(0, 1).Equals("T"))  //区域类型
                {
                    strTempWhere += " And 区域类型 = '" + tvc_Territorial.SelectedNode.Tag.ToString() + "' ";
                }
                else if (tvc_Territorial.SelectedNode.Name.Substring(0, 1).Equals("I"))  //区域名称
                {
                    strTempWhere += " And 区域名称 = '" + tvc_Territorial.SelectedNode.Tag.ToString() + "' ";
                }
            }
            if (!cmb_Dept.SelectedValue.Equals(0))
            {
                strTempWhere += " And 部门 ='" + cmb_Dept.Text + "' ";
            }
            if (!txt_Territorial_EmpName.Text.Trim().Equals(""))
            {
                if (blIsEmp)
                {
                    strTempWhere += " And 姓名 like '%" + txt_Territorial_EmpName.Text.Trim() + "%' ";
                }
                else
                {
                    strTempWhere += " And 设备名称 like '%" + txt_Territorial_EmpName.Text.Trim() + "%' ";
                }
            }

            if (!txt_Territorial_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_Territorial_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【事件：选择实时区域信息——抽屉式菜单】

        private void bt_RTTerritorial_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 1)
            {
                dmc_Info.ButtonClick(pl_RTTerritorial.Name);
                this.AcceptButton = bt_Territorial_Enquiries;
                lblMainTitle.Text = "区域";
                intSelectModel = 1;

                //****czlt-2010-9-16**start****
                isHearderSort = false;
                isClickSort = false;
                //****czlt-2010-9-16**end****

                tvc_Territorial.Nodes.Clear();
                if (blIsEmp)                //人员
                {
                    LoadTree(1);
                    strWhere = StrWhere_RTTerr();
                    Select_Territorial_Emp();
                }
                else                        //设备
                {
                    LoadTree(2);
                    strWhere = StrWhere_RTTerr();
                    Select_Territorial_Equ();
                }
                tvc_Territorial.ExpandAll();
            }
        }

        #endregion

        #region【事件：查询】

        private void bt_EmpOverTime_Enquiries_Click(object sender, EventArgs e)
        {
            strWhere = StrWhere_RTTerr();
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            if (blIsEmp)            //人员
            {
                Select_Territorial_Emp();
            }
            else                    //设备
            {
                Select_Territorial_Equ();
            }
        }

        #endregion

        #region【事件：重置】

        private void bt_EmpOverTime_Reset_Click(object sender, EventArgs e)
        {
            txt_Territorial_CodeSenderAddress.Text = "";
            txt_Territorial_EmpName.Text = "";
            LoadComboBox_Dept();
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            tvc_Territorial.Nodes.Clear();
            LoadTree(1);    //加载实时区域树——人员

            tvc_Territorial.ExpandAll();

            rb_Emp.Checked = true;

        }

        #endregion

        #region【事件：选择区域类型】

        private void tvc_Territorial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strWhere = StrWhere_RTTerr();         
            if (blIsEmp)            //人员
            {
                Select_Territorial_Emp();
            }
            else                    //设备
            {
                Select_Territorial_Equ();
            }

        }

        #endregion

        /*****************************限制区域*****************************/

        #region【方法：组织查询条件——限制区域】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_ConfineArea()
        {
            string strTempWhere = " 区域类型='限制区域' ";

            if (tvc_ConfineArea_Dept.SelectedNode != null && !tvc_ConfineArea_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_ConfineArea_Dept.SelectedNode) + " )";
            }

            if (!txt_ConfineArea_EmpName.Text.Trim().Equals(""))
            {
                if (blIsEmp)
                {
                    strTempWhere += " And 姓名 like '%" + txt_ConfineArea_EmpName.Text.Trim() + "%' ";
                }
                else
                {
                    strTempWhere += " And 设备名称 like '%" + txt_ConfineArea_EmpName.Text.Trim() + "%' ";
                }
            }

            if (!txt_ConfineArea_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_ConfineArea_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询】

        /// <summary>
        /// 查询——限制区域
        /// </summary>
        private void Select_ConfineArea()
        {
            strWhere = StrWhere_ConfineArea();
            if (blIsEmp)
            {
                Select_Territorial_Emp();
            }
            else
            {
                Select_Territorial_Equ();
            }
        }

        #endregion

        #region【方法：刷新——限制区域】

        private void RT_ConfineArea_RefResh()
        {
            if (blIsEmp)                //人员
            {
               // LoadTree(3);
                Select_Territorial_Emp();
            }
            else                        //设备
            {
                //LoadTree(4);
                Select_Territorial_Equ();
            }
        }

        #endregion

        #region【事件：选择实时限制区域信息——抽屉式菜单】

        private void bt_ConfineArea_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 2)
            {
                dmc_Info.ButtonClick(pl_ConfineArea.Name);
                this.AcceptButton = bt_ConfineArea_Enquiries;
                lblMainTitle.Text = "限制区域";
                intSelectModel = 2;
                //****czlt-2010-9-16**start****
                isHearderSort = false;
                isClickSort = false;
                //****czlt-2010-9-16**end****

                tvc_ConfineArea_Dept.Nodes.Clear();
                if (blIsEmp)                //人员
                {
                    LoadTree(3);
                    strWhere = StrWhere_ConfineArea();
                    Select_Territorial_Emp();
                }
                else                        //设备
                {
                    LoadTree(4);
                    strWhere = StrWhere_ConfineArea();
                    Select_Territorial_Equ();
                }
                tvc_ConfineArea_Dept.ExpandAll();

            }
        }

        #endregion

        #region【事件：选择部门——限制区域】

        private void tvc_ConfineArea_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ////****czlt-2010-9-16**start****
            //isHearderSort = false;
            //isClickSort = false;
            ////****czlt-2010-9-16**end****

            Select_ConfineArea();
        }

        #endregion

        #region【事件：查询——限制区域】

        private void bt_ConfineArea_Enquiries_Click(object sender, EventArgs e)
        {
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****
            Select_ConfineArea();
        }

        #endregion

        #region【事件：重置——限制区域】

        private void bt_ConfineArea_Reset_Click(object sender, EventArgs e)
        {
            txt_ConfineArea_CodeSenderAddress.Text = "";
            txt_ConfineArea_EmpName.Text = "";

            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            tvc_ConfineArea_Dept.Nodes.Clear();

            LoadTree(3);

            tvc_ConfineArea_Dept.ExpandAll();

            rb_Emp.Checked = true;
            Select_ConfineArea();
        }

        #endregion

        /*****************************重点区域*****************************/

        #region【方法：组织查询条件——重点区域】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_KeyArea()
        {
            string strTempWhere = " 区域类型='重点区域' ";

            if (tvc_KeyArea_Dept.SelectedNode != null && !tvc_KeyArea_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_KeyArea_Dept.SelectedNode) + " )";
            }

            if (!txt_KeyArea_EmpName.Text.Trim().Equals(""))
            {
                if (blIsEmp)
                {
                    strTempWhere += " And 姓名 like '%" + txt_KeyArea_EmpName.Text.Trim() + "%' ";
                }
                else
                {
                    strTempWhere += " And 设备名称 like '%" + txt_KeyArea_EmpName.Text.Trim() + "%' ";
                }
            }

            if (!txt_KeyArea_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_KeyArea_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询】

        /// <summary>
        /// 查询——重点区域
        /// </summary>
        private void Select_KeyArea()
        {
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            strWhere = StrWhere_KeyArea();
            if (blIsEmp)
            {
                Select_Territorial_Emp();
            }
            else
            {
                Select_Territorial_Equ();
            }
        }

        #endregion

        #region【方法：刷新——重点区域】

        private void RT_KeyArea_RefResh()
        {
            if (blIsEmp)                //人员
            {
                //LoadTree(5);
                Select_Territorial_Emp();
            }
            else                        //设备
            {
                //LoadTree(6);
                Select_Territorial_Equ();
            }
        }

        #endregion


        #region【事件：选择重点区域信息——抽屉式菜单】

        private void bt_KeyArea_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 3)
            {
                dmc_Info.ButtonClick(pl_KeyArea.Name);
                this.AcceptButton = bt_KeyArea_Enquiries;
                lblMainTitle.Text = "重点区域";
                intSelectModel = 3;
                //****czlt-2010-9-16**start****
                isHearderSort = false;
                isClickSort = false;
                //****czlt-2010-9-16**end****

                tvc_KeyArea_Dept.Nodes.Clear();
                if (blIsEmp)                //人员
                {
                    LoadTree(5);
                    strWhere = StrWhere_KeyArea();
                    Select_Territorial_Emp();
                }
                else                        //设备
                {
                    LoadTree(6);
                    strWhere = StrWhere_KeyArea();
                    Select_Territorial_Equ();
                }
                tvc_KeyArea_Dept.ExpandAll();
            }
        }

        #endregion

        #region【事件：选择部门——重点区域】

        private void tvc_KeyArea_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ////****czlt-2010-9-16**start****
            //isHearderSort = false;
            //isClickSort = false;
            ////****czlt-2010-9-16**end****

            Select_KeyArea();
        }

        #endregion

        #region【事件：查询——重点区域】

        private void bt_KeyArea_Enquiries_Click(object sender, EventArgs e)
        {
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            Select_KeyArea();
        }

        #endregion

        #region【事件：重置——重点区域】

        private void bt_KeyArea_Reset_Click(object sender, EventArgs e)
        {
            txt_KeyArea_CodeSenderAddress.Text = "";
            txt_KeyArea_EmpName.Text = "";
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****

            tvc_KeyArea_Dept.Nodes.Clear();

            LoadTree(5);

            tvc_KeyArea_Dept.ExpandAll();

            rb_Emp.Checked = true;
            Select_KeyArea();
        }

        #endregion


        /*****************************地域*****************************/

        #region【方法：组织查询条件——地域】

        /// <summary>
        /// 组织查询条件
        /// </summary>
        /// <returns>返回查询条件</returns>
        private string StrWhere_DistrictArea()
        {
            string strTempWhere = " 区域类型='地域' ";

            if (tvc_DistrictArea_Dept.SelectedNode != null && !tvc_DistrictArea_Dept.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And ( 部门 = " + GetNodeAllChild(tvc_DistrictArea_Dept.SelectedNode) + " )";
            }

            if (!txt_DistrictArea_EmpName.Text.Trim().Equals(""))
            {
                if (blIsEmp)
                {
                    strTempWhere += " And 姓名 like '%" + txt_DistrictArea_EmpName.Text.Trim() + "%' ";
                }
                else
                {
                    strTempWhere += " And 设备名称 like '%" + txt_DistrictArea_EmpName.Text.Trim() + "%' ";
                }
            }

            if (!txt_DistrictArea_CodeSenderAddress.Text.Trim().Equals(""))
            {
                strTempWhere += " And 标识卡号 = " + txt_DistrictArea_CodeSenderAddress.Text.Trim();
            }

            return strTempWhere;
        }

        #endregion

        #region【方法：查询】

        /// <summary>
        /// 查询——地域
        /// </summary>
        private void Select_DistrictArea()
        {
            strWhere = StrWhere_DistrictArea();

            if (blIsEmp)
            {
                Select_Territorial_Emp();
            }
            else
            {
                Select_Territorial_Equ();
            }
        }

        #endregion

        #region【方法：刷新——重点区域】

        private void RT_DistrictArea_RefResh()
        {
            if (blIsEmp)                //人员
            {
                //LoadTree(7);
                Select_Territorial_Emp();
            }
            else                        //设备
            {
               // LoadTree(8);
                Select_Territorial_Equ();
            }
        }

        #endregion


        #region【事件：选择地域信息——抽屉式菜单】

        private void bt_DistrictArea_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 4)
            {
                dmc_Info.ButtonClick(pl_DistrictArea.Name);
                this.AcceptButton = bt_DistrictArea_Enquiries;
                lblMainTitle.Text = "地域";
                intSelectModel = 4;
                //****czlt-2010-9-16**start****
                isHearderSort = false;
                isClickSort = false;
                //****czlt-2010-9-16**end****
                tvc_DistrictArea_Dept.Nodes.Clear();
                if (blIsEmp)                //人员
                {
                    LoadTree(7);
                    strWhere = StrWhere_DistrictArea();
                    Select_Territorial_Emp();
                }
                else                        //设备
                {
                    LoadTree(8);
                    strWhere = StrWhere_DistrictArea();
                    Select_Territorial_Equ();
                }
                tvc_DistrictArea_Dept.ExpandAll();
            }
        }

        #endregion

        #region【事件：选择部门——地域】

        private void tvc_DistrictArea_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ////****czlt-2010-9-16**start****
            //isHearderSort = false;
            //isClickSort = false;
            ////****czlt-2010-9-16**end****

            Select_DistrictArea();
        }

        #endregion

        #region【事件：查询——地域】

        private void bt_DistrictArea_Enquiries_Click(object sender, EventArgs e)
        {
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****
            Select_DistrictArea();
        }

        #endregion

        #region【事件：重置——地域】

        private void bt_DistrictArea_Reset_Click(object sender, EventArgs e)
        {
            txt_DistrictArea_CodeSenderAddress.Text = "";
            txt_DistrictArea_EmpName.Text = "";
            //****czlt-2010-9-16**start****
            isHearderSort = false;
            isClickSort = false;
            //****czlt-2010-9-16**end****
            tvc_DistrictArea_Dept.Nodes.Clear();

            LoadTree(7);

            tvc_DistrictArea_Dept.ExpandAll();

            rb_Emp.Checked = true;
            Select_DistrictArea();
        }

        #endregion

        private void dgv_Main_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgv.Columns.Count > 0)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dgv.Columns[i].DefaultCellStyle.NullValue = "——";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private IButtonControl IB = null;
        private void txtSkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txtSkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }

        #region Czlt-2010-9-16***点击表头信息****
        /// <summary>
        /// 点击列标题事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (index != e.ColumnIndex)
            {
                index = e.ColumnIndex;
                isClickSort = false;
            }
            if (isClickSort == false)
            {
                listSort = ListSortDirection.Ascending;
                isClickSort = true;
            }
            else if (isClickSort == true)
            {
                listSort = ListSortDirection.Descending;
                isClickSort = false;
            }

            isHearderSort = true;
        }
        #endregion

        private void txt_Territorial_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_ConfineArea_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_KeyArea_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_DistrictArea_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region【事件：打印 导出】
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, GetStrTitle());
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, GetStrTitle(), "");
        }
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, GetStrTitle(), lblCounts.Text);
        }

        #endregion
    }
}
