using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.A_HisAlarm
{
    public partial class A_FrmHisAlarm : Wilson.Controls.Docking.DockContent
    {

        #region【声明】


        private A_HisAlarmBLL rtabll = new A_HisAlarmBLL();

        private DataSet ds;

        private int intSelectModel = 1;


        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;

        #endregion

        #region【构造函数】

        public A_FrmHisAlarm()
        {
            InitializeComponent();

            #region【超员】

            dmc_Info.Add(pl_OverEmp, true);

            #endregion

            #region【超时】

            dmc_Info.Add(pl_EmpOverTime);

            #endregion

            #region【区域】
            
            dmc_Info.Add(pl_Territorial);

            #endregion

            #region【工作异常】

            if (IsEnableAlarm(7))
            {
                dmc_Info.Add(pl_Path);
                pl_Path.Visible = true;
            }
            else
            {
                pl_Path.Visible = false;
            }

            #endregion

            #region【传输分站】

            dmc_Info.Add(pl_Station);

            #endregion

            #region【读卡分站】

            dmc_Info.Add(pl_StationHead);

            #endregion

            #region【超速】

            if (IsEnableAlarm(8))
            {
                dmc_Info.Add(pl_OverSpeed);
                pl_OverSpeed.Visible = true;
            }
            else
            {
                pl_OverSpeed.Visible = false;
            }
            #endregion

            #region【欠速】

            if (IsEnableAlarm(9))
            {
                dmc_Info.Add(pl_LackSpeed);
                pl_LackSpeed.Visible = true;
            }
            else
            {
                pl_LackSpeed.Visible = false;
            }
            #endregion

            #region【求救】

            if (IsEnableAlarm(10))
            {
                dmc_Info.Add(pl_EmpHelp);
                pl_EmpHelp.Visible = true;
            }
            else
            {
                pl_EmpHelp.Visible = false;
            }

            //if (RefReshTime.blIsLoadEmpHelp)
            //{
            //    dmc_Info.Add(pl_EmpHelp);
            //    pl_EmpHelp.Visible = true;
            //}
            //else
            //{
            //    pl_EmpHelp.Visible = false;
            //}

            #endregion

            #region【区域超时】

            if (IsEnableAlarm(11))
            {
                dmc_Info.Add(pl_AreaOverTime);
                pl_AreaOverTime.Visible = true;
            }
            else
            {
                pl_AreaOverTime.Visible = false;
            }

            #endregion

            ////异地交接班信息
            //dmc_Info.Add(pnlAssociate);

            #region【区域超员】

            if (IsEnableAlarm(12))
            {
                dmc_Info.Add(pl_TerOverEmp);
                pl_TerOverEmp.Visible = true;
            }
            else
            {
                pl_TerOverEmp.Visible = false;
            }

            #endregion

            #region 【唯一性报警】
            if (IsEnableAlarm(14))
            {
                dmc_Info.Add(palOnlyone);
                palOnlyone.Visible = true;
            }
            else
            {
                palOnlyone.Visible = false;
            }
            #endregion


            #region 【传输分站供电情况】
            if (IsEnableAlarm(17))
            {

                dmc_Info.Add(palDYStation);
                palDYStation.Visible = true;

            }
            else
            {
                palDYStation.Visible = false;
            }
            #endregion

            #region 【串口服务器供电情况】
            if (IsEnableAlarm(18))
            {

                dmc_Info.Add(panDYSerial);
                panDYSerial.Visible = true;

            }
            else
            {
                panDYSerial.Visible = false;
            }
            #endregion

            dmc_Info.LeftPartResize();

        }

        #endregion

        #region【窗体加载】

        private void A_FrmHisAlarm_Load(object sender, EventArgs e)
        {
            cmbSelectCounts.Text = "40";

            #region【默认打开的是历史超员信息】

            lblMainTitle.Text = "历史超员报警";
            intSelectModel = 1;

            dtp_OverEmp_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            dtp_OverEmp_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //strWhere_OverEmp = StrWhere_OverEmp();
            //SelectInfo_OverEmp(1);

            #endregion
            
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

        #region 【方法：初始化部门树（查询）】

        /// <summary>
        /// 初始化部门树
        /// </summary>
        private void LoadTree(DegonControlLib.TreeViewControl tvc, DataSet dsTemp, string strName, bool blCount, string strHeadTip)
        {
            //if (tvc.Nodes.Count > 0)
            //{
            //    tvc.Nodes.Clear();
            //}
            DataTable dt;

            if (dsTemp != null && dsTemp.Tables.Count > 0)
            {
                dt = dsTemp.Tables[0];
            }
            else
            {
                dt = tvc.BuildMenusEntity();
            }

            DataRow dr = dt.NewRow();

            SetDataRow(ref dr, 0, strHeadTip, -1, false, blCount, 0);

            dt.Rows.Add(dr);

            tvc.DataSouce = dt;
            tvc.LoadNode(strName);


            //tvc.ExpandAll();
            //tvc.SelectedNode = tvc.Nodes[0];
            //tvc.SetSelectNodeColor();
        }

        #endregion

        #region【方法：加载树】
        /// <summary>
        /// 加载树
        /// </summary>
        /// <param name="intModel">1:部门树_历史超时、历史工作异常、历史超速、历史欠速、历史求救，2：传输分站树，3：工种树，4：区域树，5：部门树——工作异常，6：部门树——超速，7：部门树——欠速，8：部门树——求救</param>
        private void LoadTree(int intModel)
        {
            switch (intModel)
            {
                case 1:

                    #region【部门——历史超时】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_EmpOverTime();
                        LoadTree(tvc_EmpOverTime_Dept, ds, "人", false,"所有");

                    }
                    #endregion

                    break;
                case 2:

                    #region【传输分站】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetTree_Station();
                        LoadTree(tvc_Station, ds, "人", false,"所有");
                    }

                    #endregion

                    break;
                case 3:

                    #region【读卡分站】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetTree_StationHead();
                        LoadTree(tvc_StationHead, ds, "人", false,"所有");
                    }
                    #endregion

                    break;
                case 4:

                    #region【区域】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_Territorial();
                        LoadTree(tvc_Territorial, ds, "人", false,"所有");
                    }

                    #endregion

                    break;
                case 5:

                    #region【工作异常】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_EmpOverTime();
                        LoadTree(tvc_Path_Dept, ds, "人", false,"所有");
                    }

                    #endregion

                    break;
                case 6:

                    #region【超速】
                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_EmpOverTime();
                        LoadTree(tvc_OverSpeed_Dept, ds, "人", false, "所有");
                    }
                    #endregion

                    break;
                case 7:

                    #region【欠速】
                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_EmpOverTime();
                        LoadTree(tvc_LackSpeed_Dept, ds, "人", false, "所有");
                    }
                    #endregion

                    break;
                case 8:

                    #region【求救】
                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_EmpOverTime();
                        LoadTree(tvc_EmpHelp_Dept, ds, "人", false, "所有");
                    }
                    #endregion

                    break;
                case 13:

                    #region【区域超员】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_Territorial();
                        LoadTree(tvc_TerOverEmp, ds, "人", false, "所有");
                    }

                    #endregion

                    break;
                case 14:
                    #region 【唯一性报警】
                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_Onlyone();
                        LoadTree(tvcOnlyoneDept, ds, "人", false, "所有");
                    }
                    #endregion
                    break;
                case 17:
                    #region【传输分站】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetTree_Station();
                        LoadTree(tvcStation, ds, "人", false, "所有");
                    }

                    #endregion
                    break;
                case 18:
                    #region 【串口服务器】
                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetIPConfigTree();
                        LoadTree(tvcSerial, ds, "人", false, "所有");
                    }
                    #endregion
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region【方法：控制翻页状态】

        private void SetPageEnable(int pIndex, int sumPage)
        {
            if (pIndex == 1)
            {
                if (sumPage == 1)
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = true;
                }
            }
            else if (pIndex >= sumPage)
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = false;
            }
            else
            {
                btnUpPage.Enabled = true;
                btnDownPage.Enabled = true;
            }
        }

        #endregion

        #region【方法：判断时间】

        private bool DecideTime(DateTimePicker dtpBegin, DateTimePicker dtpEnd)
        {
            if (Convert.ToDateTime(dtpEnd.Text) > DateTime.Now)
            {
                dtpEnd.Value = DateTime.Now;
            }
            if (Convert.ToDateTime(dtpBegin.Text) >= Convert.ToDateTime(dtpEnd.Text))
            {
                MessageBox.Show("开始时间不能大于结束时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            //Czlt-2010-11-30 -注销
            //if (Convert.ToDateTime(dtpBegin.Text).AddDays(7) < Convert.ToDateTime(dtpEnd.Text))
            //{
            //    MessageBox.Show("开始时间与结束时间相差不能大于7天！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return false;
            //}
            return true;
        }

        #endregion


        #region【事件：上一页】

        private void btnUpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }
           
            #region【查询各个历史报警信息】

            switch (intSelectModel)
            {
                case 1:

                    #region【超员】

                    SelectInfo_OverEmp(page);
                    
                    #endregion

                    break;
                case 2:

                    #region【超时】

                    SelectInfo_EmpOverTime(page);

                    #endregion

                    break;
                case 3:

                    #region【区域】

                    SelectInfo_Territorial(page);

                    #endregion

                    break;
                case 4:

                    #region【工作异常】

                    SelectInfo_Path(page);

                    #endregion
                    
                    break;
                case 5:

                    #region【求救】


                    #endregion
                    
                    break;
                case 6:

                    #region【传输分站】
                    
                    SelectInfo_Station(page);

                    #endregion

                    break;
                case 7:

                    #region【读卡分站】

                    SelectInfo_StationHead(page);

                    #endregion

                    break;
                case 8:

                    #region【超速】

                    SelectInfo_OverSpeed(page);

                    #endregion

                    break;
                case 9:

                    #region【欠速】

                    SelectInfo_LackSpeed(page);

                    #endregion

                    break;
                case 10:

                    #region【求救】

                    SelectInfo_EmpHelp(page);

                    #endregion

                    break;
                case 11:
                    //#region 【异地交接班信息】
                    //BindDataAssociate(page);
                    //#endregion
                    //break;
                case 12:
                    #region[区域超时]

                    SelectInfo_AreaOverTime(page);

                    #endregion

                    break;
                case 13:

                    #region【区域超员】

                    SelectInfo_TerOverEmp(page);

                    #endregion

                    break;
                case 14:
                    #region 【唯一性】
                    SelectInfo_Onlyone(page);
                    #endregion
                    break;
                default:
                    break;
            }
            #endregion
        }

        #endregion

        #region【事件：下一页】

        private void btnDownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPageCounts.Text);
            page++;

            if (page > countPage)
            {
                return;
            }
           
            #region【查询各个历史报警信息】

            switch (intSelectModel)
            {
                case 1:

                    #region【超员】

                    SelectInfo_OverEmp(page);

                    #endregion

                    break;
                case 2:

                    #region【超时】

                    SelectInfo_EmpOverTime(page);

                    #endregion

                    break;
                case 3:

                    #region【区域】

                    SelectInfo_Territorial(page);

                    #endregion

                    break;
                case 4:

                    #region【工作异常】

                    SelectInfo_Path(page);

                    #endregion

                    break;
                case 5:

                    #region【求救】


                    #endregion

                    break;
                case 6:

                    #region【传输分站】

                    SelectInfo_Station(page);

                    #endregion

                    break;
                case 7:

                    #region【读卡分站】

                    SelectInfo_StationHead(page);

                    #endregion

                    break;
                case 8:

                    #region【超速】

                    SelectInfo_OverSpeed(page);

                    #endregion

                    break;
                case 9:

                    #region【欠速】

                    SelectInfo_LackSpeed(page);

                    #endregion

                    break;
                case 10:

                    #region【求救】

                    SelectInfo_EmpHelp(page);

                    #endregion

                    break;
                //case 11:
                //    #region 【异地交接班信息】
                //    BindDataAssociate(page);
                //    #endregion
                //    break;
                case 12:

                    #region[区域超时]

                    SelectInfo_AreaOverTime(page);

                    #endregion

                    break;
                case 13:

                    #region【区域超员】

                    SelectInfo_TerOverEmp(page);

                    #endregion

                    break;
                case 14:
                    #region 【唯一性】
                    SelectInfo_Onlyone(page);
                    #endregion
                    break;
                default:
                    break;
            }
            #endregion
        }

        #endregion

        #region【事件：跳至】

        private void txtSkipPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    string value = txtSkipPage.Text;
                    if (value.CompareTo("") == 0)       //为空值时
                    {
                        return;
                    }
                    else if (int.Parse(value) > 0)
                    {
                        int page = int.Parse(value);
                        if (countPage > 0 && page > countPage)
                        {
                            page = countPage;
                        }

                        #region【查询各个历史报警信息】

                        switch (intSelectModel)
                        {
                            case 1:

                                #region【超员】

                                SelectInfo_OverEmp(page);

                                #endregion

                                break;
                            case 2:

                                #region【超时】

                                SelectInfo_EmpOverTime(page);

                                #endregion

                                break;
                            case 3:

                                #region【区域】

                                SelectInfo_Territorial(page);

                                #endregion

                                break;
                            case 4:

                                #region【工作异常】

                                SelectInfo_Path(page);

                                #endregion

                                break;
                            case 5:

                                #region【求救】


                                #endregion

                                break;
                            case 6:

                                #region【传输分站】

                                SelectInfo_Station(page);

                                #endregion

                                break;
                            case 7:

                                #region【读卡分站】

                                SelectInfo_StationHead(page);

                                #endregion

                                break;
                            case 8:

                                #region【超速】

                                SelectInfo_OverSpeed(page);

                                #endregion

                                break;
                            case 9:

                                #region【欠速】

                                SelectInfo_LackSpeed(page);

                                #endregion

                                break;
                            case 10:

                                #region【求救】

                                SelectInfo_EmpHelp(page);

                                #endregion

                                break;
                            //case 11:
                            //    #region 【异地交接班信息】
                            //    BindDataAssociate(page);
                            //    #endregion
                            //    break;
                            case 12:

                                #region[区域超时]

                                SelectInfo_AreaOverTime(page);

                                #endregion

                                break;
                            case 13:

                                #region【区域超员】

                                SelectInfo_TerOverEmp(page);

                                #endregion

                                break;
                            case 14:
                                #region 【唯一性】
                                SelectInfo_Onlyone(page);
                                #endregion
                                break;
                            default:
                                break;
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        #endregion

        #region【事件：选择每页显示条数】

        private void cmbSelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbSelectCounts.Text.Trim() == "全部")
                pSize = 9999999;
            else
                pSize = Convert.ToInt32(cmbSelectCounts.SelectedItem);

            #region【查询各个历史报警信息】

            switch (intSelectModel)
            {
                case 1:

                    #region【超员】

                    SelectInfo_OverEmp(1);

                    #endregion

                    break;
                case 2:

                    #region【超时】

                    SelectInfo_EmpOverTime(1);

                    #endregion

                    break;
                case 3:

                    #region【区域】

                    SelectInfo_Territorial(1);

                    #endregion

                    break;
                case 4:

                    #region【工作异常】

                    SelectInfo_Path(1);

                    #endregion

                    break;
                case 5:

                    #region【求救】


                    #endregion

                    break;
                case 6:

                    #region【传输分站】

                    SelectInfo_Station(1);

                    #endregion

                    break;
                case 7:

                    #region【读卡分站】

                    SelectInfo_StationHead(1);

                    #endregion

                    break;
                case 8:

                    #region【超速】

                    SelectInfo_OverSpeed(1);
                    
                    #endregion

                    break;
                case 9:

                    #region【欠速】

                    SelectInfo_LackSpeed(1);

                    #endregion

                    break;
                case 10:

                    #region【求救】

                    SelectInfo_EmpHelp(1);

                    #endregion

                    break;
                //case 11:
                //    #region 【异地交接班】
                //    BindDataAssociate(1);
                //    #endregion
                //    break;
                case 12:

                    #region[区域超时]

                    SelectInfo_AreaOverTime(1);

                    #endregion

                    break;
                case 13:

                    #region【区域超员】

                    SelectInfo_TerOverEmp(1);

                    #endregion

                    break;
                case 14:
                    #region 【唯一性】
                    SelectInfo_Onlyone(1);
                    #endregion
                    break;
                default:
                    break;
            }
            #endregion
        }


        #endregion

       


        #region【方法：获取是否启用该报警】

        private bool IsEnableAlarm(int intAlarm)
        {
            bool blIsEnable = false;
            try
            {
                using (ds = new DataSet())
                {
                    ds = rtabll.IsEnableAlarm(intAlarm);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
                        {
                            blIsEnable = true;
                        }
                    }
                }
            }
            catch { }

            return blIsEnable;
        }

        #endregion


        /*********** 求救 ***********/

        #region【求救】

        #region【事件：选择历史求救报警信息——抽屉式菜单】

        private void bt_EmpHelp_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 10)
            {
                dmc_Info.ButtonClick(pl_EmpHelp.Name);
                this.AcceptButton = bt_EmpHelp_Enquiries;
                dtp_EmpHelp_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_EmpHelp_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史求救报警";
                intSelectModel = 10;

                tvc_EmpHelp_Dept.Nodes.Clear();
                LoadTree(8);    //加载部门树——历史求救
                tvc_EmpHelp_Dept.ExpandAll();

                ////获取查询条件
                //strWhere_EmpHelp = StrWhere_EmpHelp();
                ////查询
                //SelectInfo_EmpHelp(1);
                dgv_Main.DataSource = null;
            }
        }

        #endregion


        #region【事件：查询——求救】

        private void bt_EmpHelp_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_EmpHelp_Begin, dtp_EmpHelp_End))
            {
                return;
            }
            strWhere_EmpHelp = StrWhere_EmpHelp();
            SelectInfo_EmpHelp(1);
        }

        #endregion

        #region【事件：重置——求救】

        private void bt_EmpHelp_Reset_Click(object sender, EventArgs e)
        {
            txt_EmpHelp_CodeSenderAddress.Text = "";
            txt_EmpHelp_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
        }

        #endregion

        #region【事件：选择部门】

        private void tvc_EmpHelp_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_EmpHelp_Begin, dtp_EmpHelp_End))
            {
                return;
            }
            strWhere_EmpHelp = StrWhere_EmpHelp();
            SelectInfo_EmpHelp(1);
        }

        #endregion

        #endregion

        /************唯一性***************/
        #region 【唯一性】
        #region 【事件方法：选择历史唯一性报警信息--抽屉式菜单】
        private void btnOnlyone_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 14)
            {
                dmc_Info.ButtonClick(palOnlyone.Name);
                this.AcceptButton = btnOnlyoneSearch;
                dtpBeginOnlyone.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtpEndOnlyone.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史唯一性报警";
                intSelectModel = 14;

                tvcOnlyoneDept.Nodes.Clear();
                LoadTree(14);    //加载部门树——历史求救
                tvcOnlyoneDept.ExpandAll();

                ////获取查询条件
                //strWhere_Onlyone = StrWhere_Onlyone();
                ////查询
                //SelectInfo_Onlyone(1);

                dgv_Main.DataSource = null; 
            }
        }
        #endregion

        #region 【事件方法：查询--唯一性】
        private void btnOnlyoneSearch_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtpBeginOnlyone, dtpEndOnlyone))
            {
                return;
            }
            //获取查询条件
            strWhere_Onlyone = StrWhere_Onlyone();
            //查询
            SelectInfo_Onlyone(1);
        }
        #endregion

        #region 【事件方法：重置--唯一性】
        private void btnOnlyReset_Click(object sender, EventArgs e)
        {
            txtOnlyoneCodeAddress.Text = "";
            txtOnlyoneName.Text = "";
            dgv_Main.DataSource = new DataTable();
        }
        #endregion

        #region 【事件方法：部门选择】
        private void tvcOnlyoneDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtpBeginOnlyone, dtpEndOnlyone))
            {
                return;
            }
            //获取查询条件
            strWhere_Onlyone = StrWhere_Onlyone();
            //查询
            SelectInfo_Onlyone(1);
        }
        #endregion

        #endregion

        /*********** 区域超员 ***********/

        #region【区域超员】

        #region【事件：选择历史区域超员报警信息——抽屉式菜单】

        private void bt_TerOverEmp_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 13)
            {
                dmc_Info.ButtonClick(pl_TerOverEmp.Name);
                this.AcceptButton = bt_TerOverEmp_Enquiries;
                dtp_TerOverEmp_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_TerOverEmp_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史区域超员报警";
                intSelectModel = 13;

                tvc_TerOverEmp.Nodes.Clear();
                LoadTree(13);    //加载部门树——历史超时
                tvc_TerOverEmp.ExpandAll();

                ////查询
                //strWhere_TerOverEmp = StrWhere_TerOverEmp();
                //SelectInfo_TerOverEmp(1);
                dgv_Main.DataSource = null;
            }
        }

        #endregion

        #region【事件：查询——区域超员】

        private void bt_TerOverEmp_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_TerOverEmp_Begin, dtp_TerOverEmp_End))
            {
                return;
            }

            strWhere_TerOverEmp = StrWhere_TerOverEmp();
            SelectInfo_TerOverEmp(1);
        }

        #endregion

        #region【事件：选择区域名称】

        private void tvc_TerOverEmp_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_TerOverEmp_Begin, dtp_TerOverEmp_End))
            {
                return;
            }

            strWhere_TerOverEmp = StrWhere_TerOverEmp();
            SelectInfo_TerOverEmp(1);
        }

        #endregion

        #endregion


        /*********** 超速 ***********/

        #region【超速】

        #region【事件：选择历史超时报警信息——抽屉式菜单】

        private void bt_OverSpeed_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 8)
            {
                dmc_Info.ButtonClick(pl_OverSpeed.Name);
                this.AcceptButton = bt_OverSpeed_Enquiries;
                dtp_OverSpeed_Begin.Value = DateTime.Today;
                dtp_OverSpeed_End.Value = DateTime.Now;

                lblMainTitle.Text = "历史超速报警";
                intSelectModel = 8;

                tvc_OverSpeed_Dept.Nodes.Clear();

                LoadTree(6);    //加载部门树

                tvc_OverSpeed_Dept.ExpandAll();

                ////获取查询条件
                //strWhere_OverSpeed = StrWhere_OverSpeed();

                ////查询
                //SelectInfo_OverSpeed(1);
                dgv_Main.DataSource = null;

            }
        }

        #endregion

        #region【事件：查询】

        private void bt_OverSpeed_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_OverSpeed_Begin, dtp_OverSpeed_End))
            {
                return;
            }
            strWhere_OverSpeed = StrWhere_OverSpeed();
            SelectInfo_OverSpeed(1);
        }

        #endregion

        #region【事件：重置】

        private void bt_OverSpeed_Reset_Click(object sender, EventArgs e)
        {
            txt_OverSpeed_CodeSenderAddress.Text = "";
            txt_OverSpeed_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
        }

        #endregion

        #region【事件：选择部门】

        private void tvc_OverSpeed_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_OverSpeed_Begin, dtp_OverSpeed_End))
            {
                return;
            }
            strWhere_OverSpeed = StrWhere_OverSpeed();
            SelectInfo_OverSpeed(1);
        }

        #endregion


        #endregion


        /*********** 欠速 ***********/

        #region【欠速】

        #region【事件：选择历史超时报警信息——抽屉式菜单】

        private void bt_LackSpeed_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 9)
            {
                dmc_Info.ButtonClick(pl_LackSpeed.Name);
                this.AcceptButton = bt_LackSpeed_Enquiries;
                dtp_LackSpeed_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_LackSpeed_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史欠速报警";
                intSelectModel = 9;

                tvc_LackSpeed_Dept.Nodes.Clear();
                LoadTree(7);    //加载部门树
                tvc_LackSpeed_Dept.ExpandAll();

                ////获取查询条件
                //strWhere_LackSpeed = StrWhere_LackSpeed();
                ////查询
                //SelectInfo_LackSpeed(1);

                dgv_Main.DataSource = null;

            }
        }

        #endregion

        #region【事件：查询】

        private void bt_LackSpeed_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_LackSpeed_Begin, dtp_LackSpeed_End))
            {
                return;
            }
            strWhere_LackSpeed = StrWhere_LackSpeed();
            SelectInfo_LackSpeed(1);
        }

        #endregion

        #region【事件：重置】

        private void bt_LackSpeed_Reset_Click(object sender, EventArgs e)
        {
            txt_LackSpeed_CodeSenderAddress.Text = "";
            txt_LackSpeed_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
        }

        #endregion

        #region【事件：选择部门】

        private void tvc_LackSpeed_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_LackSpeed_Begin, dtp_LackSpeed_End))
            {
                return;
            }
            strWhere_LackSpeed = StrWhere_LackSpeed();
            SelectInfo_LackSpeed(1);
        }

        #endregion

        #endregion


        /*********** 工作异常 ***********/

        #region【工作异常】

        #region【事件：选择历史工作异常信息——抽屉式菜单】

        private void bt_Path_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 4)
            {
                dmc_Info.ButtonClick(pl_Path.Name);
                this.AcceptButton = bt_Path_Enquiries;
                dtp_Path_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_Path_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史工作异常";
                intSelectModel = 4;

                tvc_Path_Dept.Nodes.Clear();
                LoadTree(5);    //加载部门树——历史超时
                tvc_Path_Dept.ExpandAll();

                ////获取查询条件
                //strWhere_Path = StrWhere_Path();
                ////查询
                //SelectInfo_Path(1);

                dgv_Main.DataSource = null;
            }
        }

        #endregion

        #region【事件：查询——历史工作异常】

        private void bt_Path_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_Path_Begin, dtp_Path_End))
            {
                return;
            }

            strWhere_Path = StrWhere_Path();
            SelectInfo_Path(1);
        }

        #endregion

        #region【事件：重置——历史工作异常】

        private void bt_Path_Reset_Click(object sender, EventArgs e)
        {
            txt_Path_CodeSenderAddress.Text = "";
            txt_Path_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
        }

        #endregion

        #region【事件：选择部门——历史工作异常】

        private void tvc_Path_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_Path_Begin, dtp_Path_End))
            {
                return;
            }

            strWhere_Path = StrWhere_Path();
            SelectInfo_Path(1);
        }

        #endregion

        #endregion


        /*********** 读卡分站 ***********/

        #region【读卡分站】

        #region【事件：选择历史读卡分站故障报警信息——抽屉式菜单】

        private void bt_StationHead_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 7)
            {
                dmc_Info.ButtonClick(pl_StationHead.Name);
                this.AcceptButton = bt_StationHead_Enquiries;
                dtp_StationHead_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_StationHead_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史读卡分站故障报警";
                intSelectModel = 7;

                tvc_StationHead.Nodes.Clear();
                LoadTree(3);    //加载分站树——历史读卡分站故障信息
                tvc_StationHead.ExpandAll();

                ////获取查询条件
                //strWhere_StationHead = StrWhere_StationHead();
                ////查询
                //SelectInfo_StationHead(1);
                dgv_Main.DataSource = null;
            }
        }

        #endregion


        #region【事件：查询——历史读卡分站故障信息】

        private void bt_StationHead_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_StationHead_Begin, dtp_StationHead_End))
            {
                return;
            }
            strWhere_StationHead = StrWhere_StationHead();
            SelectInfo_StationHead(1);
        }

        #endregion

        #region【事件：选择分站树——历史读卡分站故障信息】

        private void tvc_StationHead_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_StationHead_Begin, dtp_StationHead_End))
            {
                return;
            }
            strWhere_StationHead = StrWhere_StationHead();
            SelectInfo_StationHead(1);
        }

        #endregion

        #endregion


        /*********** 传输分站 ***********/

        #region【传输分站】

        #region【事件：选择历史分站故障报警信息——抽屉式菜单】

        private void bt_Station_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 6)
            {
                dmc_Info.ButtonClick(pl_Station.Name);
                this.AcceptButton = bt_Station_Enquiries;
                dtp_Station_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_Station_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史传输分站故障报警";
                intSelectModel = 6;

                tvc_Station.Nodes.Clear();
                LoadTree(2);    //加载分站树——历史传输分站故障信息
                tvc_Station.ExpandAll();

                ////获取查询条件
                //strWhere_Station = StrWhere_Station();
                ////查询
                //SelectInfo_Station(1);

                dgv_Main.DataSource = null;
            }
        }

        #endregion


        #region【事件：查询——历史传输分站故障信息】

        private void bt_Station_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_Station_Begin, dtp_Station_End))
            {
                return;
            }

            strWhere_Station = StrWhere_Station();
            SelectInfo_Station(1);
        }

        #endregion

        #region【事件：选择分站——历史传输分站故障信息】

        private void tvc_Station_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_Station_Begin, dtp_Station_End))
            {
                return;
            }

            strWhere_Station = StrWhere_Station();
            SelectInfo_Station(1);
        }

        #endregion

        #endregion


        /*********** 超时 ***********/

        #region【超时】

        #region【事件：选择历史超时报警信息——抽屉式菜单】

        private void bt_EmpOverTime_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 2)
            {
                dmc_Info.ButtonClick(pl_EmpOverTime.Name);
                this.AcceptButton = bt_EmpOverTime_Enquiries;
                dtp_EmpOverTime_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_EmpOverTime_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史超时报警";
                intSelectModel = 2;

                tvc_EmpOverTime_Dept.Nodes.Clear();
                LoadTree(1);    //加载部门树——历史超时
                tvc_EmpOverTime_Dept.ExpandAll();

                ////获取查询条件
                //strWhere_EmpOverTime = StrWhere_EmpOverTime();
                ////查询
                //SelectInfo_EmpOverTime(1);
                dgv_Main.DataSource = null;
            }
        }

        #endregion

        #region【事件：查询——历史超时】

        private void bt_EmpOverTime_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_EmpOverTime_Begin, dtp_EmpOverTime_End))
            {
                return;
            }
            strWhere_EmpOverTime = StrWhere_EmpOverTime();
            SelectInfo_EmpOverTime(1);
        }

        #endregion

        #region【事件：重置——历史超时】

        private void bt_EmpOverTime_Reset_Click(object sender, EventArgs e)
        {
            txt_EmpOverTime_CodeSenderAddress.Text = "";
            txt_EmpOverTime_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
        }

        #endregion

        #region【事件：选择部门——历史超时】

        private void tvc_EmpOverTime_Dept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_EmpOverTime_Begin, dtp_EmpOverTime_End))
            {
                return;
            }
            strWhere_EmpOverTime = StrWhere_EmpOverTime();
            SelectInfo_EmpOverTime(1);
        }

        #endregion

        #endregion


        /*********** 区域 ***********/

        #region【区域】

        #region【事件：选择历史区域报警信息——抽屉式菜单】

        private void bt_Territorial_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 3)
            {
                dmc_Info.ButtonClick(pl_Territorial.Name);
                this.AcceptButton = bt_Territorial_Enquiries;
                dtp_Territorial_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_Territorial_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史区域报警";
                intSelectModel = 3;

                tvc_Territorial.Nodes.Clear();
                LoadTree(4);    //加载部门树——历史超时
                tvc_Territorial.ExpandAll();

                ////查询
                //strWhere_Territorial = StrWhere_Territorial();
                //SelectInfo_Territorial(1);

                dgv_Main.DataSource = null;
            }
        }

        #endregion


        #region【事件：查询——历史区域】

        private void bt_Territorial_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_Territorial_Begin, dtp_Territorial_End))
            {
                return;
            }

            strWhere_Territorial = StrWhere_Territorial();
            SelectInfo_Territorial(1);
        }

        #endregion

        #region【事件：重置——历史区域】

        private void bt_Territorial_Reset_Click(object sender, EventArgs e)
        {
            txt_Territorial_CodeSenderAddress.Text = "";
            txt_Territorial_EmpName.Text = "";
            dgv_Main.DataSource = new DataTable();
        }

        #endregion

        #region【事件：选择区域——历史区域】

        private void tvc_Territorial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtp_Territorial_Begin, dtp_Territorial_End))
            {
                return;
            }

            strWhere_Territorial = StrWhere_Territorial();
            SelectInfo_Territorial(1);
        }

        #endregion

        #endregion


        /*********** 超员 ***********/

        #region【超员】

        #region【事件：选择历史超员报警信息——抽屉式菜单】

        private void bt_OverEmp_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 1)
            {
                dmc_Info.ButtonClick(pl_OverEmp.Name);
                this.AcceptButton = bt_OverEmp_Enquiries;
                dtp_OverEmp_Begin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtp_OverEmp_End.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "历史超员报警";
                intSelectModel = 1;

                ////查询
                //strWhere_OverEmp = StrWhere_OverEmp();
                //SelectInfo_OverEmp(1);

                dgv_Main.DataSource = null;
            }
        }

        #endregion


        #region【事件：查询——超员】

        private void bt_OverEmp_Enquiries_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtp_OverEmp_Begin, dtp_OverEmp_End))
            {
                return;
            }

            strWhere_OverEmp = StrWhere_OverEmp();
            SelectInfo_OverEmp(1);
        }

        #endregion

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

        private void txtOnlyoneName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_TerOverTime_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_Territorial_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_EmpOverTime_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_EmpHelp_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        /************Czlt-2011-05-12 传输分站供电*********************/
        #region【Czlt-2011-05-12 传输分站供电情况】

        /// <summary>
        /// 传输分站点击抽屉按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDYSta_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 17)
            {
                dmc_Info.ButtonClick(palDYStation.Name);
                this.AcceptButton = btnDYSta_Search;

                dtpBeginDYSta.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtpEndDYSta.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "传输分站供电情况";
                intSelectModel = 17;

                tvcStation.Nodes.Clear();
                LoadTree(17);    //加载分站树——历史传输分站故障信息
                //tvcStation.ExpandAll();

                ////获取查询条件
                //strWhere_Station = StrWhere_Station();
                ////查询
                //SelectInfo_Station(1);

                dgv_Main.DataSource = null;
            }

        }

        /// <summary>
        /// 传输分站点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDYSta_Search_Click(object sender, EventArgs e)
        {
            if (!DecideTime(dtpBeginDYSta, dtpEndDYSta))
            {
                return;
            }
            string strStaWhere = StrWhere_DYStation();
            Select_DYSta(strStaWhere, 1);

        }

        /// <summary>
        /// 传输分站选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvcStation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtpBeginDYSta, dtpEndDYSta))
            {
                return;
            }
            string strStaWhere = StrWhere_DYStation();
            Select_DYSta(strStaWhere, 1);

        }

        #endregion

        /************Czlt-2011-05-12 串口服务器供电历史查询***********/
        #region 【Czlt-2011-05-12 串口服务器供电查询】
        #region【串口服务器抽屉树】
        private void btnDYSer_Click(object sender, EventArgs e)
        {
            if (intSelectModel != 18)
            {
                //tvcSerial

                dmc_Info.ButtonClick(panDYSerial.Name);
                this.AcceptButton = btnSer_Find;

                dtpBeginSerial.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                dtpEndSerial.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblMainTitle.Text = "交换机供电情况";
                intSelectModel = 18;

                tvcSerial.Nodes.Clear();
                LoadTree(18);    //加载分站树——历史传输分站故障信息
                //tvcSerial.ExpandAll();

                ////获取查询条件
                //strWhere_Station = StrWhere_Station();
                ////查询
                //SelectInfo_Station(1);

                dgv_Main.DataSource = null;
            }

        }
        #endregion

        #region 【查询按钮】
        private void btnSer_Find_Click(object sender, EventArgs e)
        {

            if (!DecideTime(dtpBeginSerial, dtpEndSerial))
            {
                return;
            }
            string strSerial = StrWhere_DySerial();
            Selec_Serial(strSerial, 1);
        }
        #endregion

        #region 【点击树之后】
        private void tvcSerial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DecideTime(dtpBeginSerial, dtpEndSerial))
            {
                return;
            }
            string strSerial = StrWhere_DySerial();
            Selec_Serial(strSerial, 1);

        }

        #endregion
        #endregion

        #region 【Czlt-2011-05-12 供电情况查询】

        private string StrWhere_DYStation()
        {

            string strTempWhere = " And 故障开始时间 >= '" + dtpBeginDYSta.Text +
               "' And 故障开始时间 <='" + dtpEndDYSta.Text + "' ";

            if (tvcStation != null && tvcStation.SelectedNode != null && !tvcStation.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And 传输分站编号 = " + tvcStation.SelectedNode.Name;
            }

            return strTempWhere;
        }

        private void Select_DYSta(string strWhere, int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = rtabll.Get_His_DyStation(strWhere);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[0].Rows.Count.ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage == 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史传输分站故障报警：  共 0 个";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史传输分站故障报警：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 个";
                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count.ToString() + " 条记录";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }
                //if (dgv_Main.Columns.Count >= 5)
                //{
                //    dgv_Main.Columns["故障开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                //    dgv_Main.Columns["故障结束时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                //    dgv_Main.Columns["HistoryBadStationsID"].Visible = false;

                //    dgv_Main.Columns["分站编号"].DisplayIndex = 0;
                //    dgv_Main.Columns["分站位置"].DisplayIndex = 1;
                //    dgv_Main.Columns["故障开始时间"].DisplayIndex = 2;
                //    dgv_Main.Columns["故障结束时间"].DisplayIndex = 3;
                //    dgv_Main.Columns["故障持续时长"].DisplayIndex = 4;
                //    dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //}
            }

        }
        #endregion

        #region 【Czlt-2011-05-12 串口服务器供电查询】
        private string StrWhere_DySerial()
        {

            string strTempWhere = " And 故障开始时间 >= '" + dtpBeginSerial.Text +
               "' And 故障开始时间 <='" + dtpEndSerial.Text + "' ";

            if (tvcSerial != null && tvcSerial.SelectedNode != null && !tvcSerial.SelectedNode.Name.Equals("0"))
            {
                strTempWhere += " And IPAddress = '" + tvcSerial.SelectedNode.Name + "' ";
            }

            return strTempWhere;
        }

        private void Selec_Serial(string strWhere, int pIndex)
        {
            if (pIndex < 1)
            {
                MessageBox.Show("您输入的页数超出范围,请正确输入页数");
                return;
            }

            DataSet ds = rtabll.Get_His_DySerial(strWhere);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // 重新设置页数
                int sumPage = int.Parse(ds.Tables[0].Rows.Count.ToString());
                sumPage = sumPage % pSize != 0 ? sumPage / pSize + 1 : sumPage / pSize;
                countPage = sumPage;
                if (sumPage == 0)
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史传输分站故障报警：  共 0 个";
                    lblCounts.Text = "共 0 条记录";

                    lblPageCounts.Text = "1";
                    lblSumPage.Text = "/1页";

                    btnUpPage.Enabled = false;
                    btnDownPage.Enabled = false;
                }
                else
                {
                    dgv_Main.DataSource = ds.Tables[0];

                    //lblMainTitle.Text = "历史传输分站故障报警：  共 " + ds.Tables[2].Rows[0][0].ToString() + " 个";
                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count.ToString() + " 条记录";

                    lblPageCounts.Text = pIndex.ToString();
                    lblSumPage.Text = "/" + sumPage + "页";

                    //控制翻页状态
                    SetPageEnable(pIndex, sumPage);
                }

            }
        }

        #endregion

       

 
        
        #endregion

       

        #region【事件：打印 导出】
        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, lblMainTitle.Text, "");
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, lblMainTitle.Text);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, lblMainTitle.Text, "共" + dgv_Main.Rows.Count.ToString() + "条记录");
        }

        #endregion

        

    }
}
