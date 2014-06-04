using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NInterfaceShow;
using KJ128NDataBase;
using System.Media;
using System.Xml;
using Wilson.Controls.Docking;

namespace KJ128NMainRun.A_RTAlarm
{
    public partial class A_FrmRTAlarm : Wilson.Controls.Docking.DockContent
    {

        #region【声明】


        #region 【Czlt-2011-10-07 静音设置】

        private bool[] IsAlarmFull = new bool[17];

        //获取报警信息条数
        private int[] GetNewAlarm = new int[17];

        //比对信息条数
        private int[] CheckAlarm = new int[17];

        //报警总数
        private int intCzltAlarmCount = 0;
        #endregion

        //Czlt-2011-05-26交直流供电情况查询条件
        private string strEleWhere = " 1=1 ";

        /// <summary>
        /// 单一声音路径
        /// </summary>
        private string strPath;
        private A_RTAlarmBLL rtabll = new A_RTAlarmBLL();

        private int intSelectModel = 1;

        private string[] strAlarm = new string[17];


        private List<string> NoExitsSoundFile = new List<string>();

        private A_TreeBLL treebll = new A_TreeBLL();

        private bool blIsRefreshTree = true;


        private bool _blIsAlarm = false;

        /// <summary>
        /// 定时播放到第几个报警声音
        /// </summary>
        private int intAlarm = 1;

        /// <summary>
        /// 报警总数
        /// </summary>
        private int intAlarmCount = 17;

        /// <summary>
        /// 是否报警
        /// </summary>
        public bool BlIsAlarm
        {
            get { return _blIsAlarm; }
            set { _blIsAlarm = value; }
        }

        #endregion

        #region【构造函数】
        DockPanel dockPanel;
        public A_FrmRTAlarm(DockPanel p)
        {
            InitializeComponent();
            dockPanel = p;
            try
            {
                
                /////czlt-2012-01-13-创建当前月份的历史表
                rtabll.CzltCreateHisTable(DateTime.Now.Year, DateTime.Now.Month);


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

                #region【低电量】

                if (IsEnableAlarm(5))
                {
                    dmc_Info.Add(pl_Electricity);
                    pl_Electricity.Visible = true;
                }
                else
                {
                    pl_Electricity.Visible = false;
                }
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
                //    //求救
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
                    dmc_Info.Add(pl_TerOverTime);
                    pl_TerOverTime.Visible = true;
                }
                else
                {
                    pl_TerOverTime.Visible = false;
                }

                #endregion

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

                #region【异地交接班信息】

                if (IsEnableAlarm(13))
                {
                    dmc_Info.Add(pnlAssociate);
                    pnlAssociate.Visible = true;
                }
                else
                {
                    pnlAssociate.Visible = false;
                }
                #endregion

                #region 【唯一性报警】
                if (IsEnableAlarm(14))
                {
                    dmc_Info.Add(palCheckCards);
                    palCheckCards.Visible = true;

                    //Czlt-2012-03-28 取消未下井人员验证
                    //dmc_Info.Add(palInWellValidate);
                    //palInWellValidate.Visible = true;
                    palInWellValidate.Visible = false;
                }
                else
                {
                    palCheckCards.Visible = false;
                    palInWellValidate.Visible = false;
                }
                #endregion

                #region 【Czlt-2011-05-25 交直流供电】

                #region 【传输分站供电】
                if (IsEnableAlarm(17))
                {
                    dmc_Info.Add(panStaEle);
                    panStaEle.Visible = true;
                }
                else
                {
                    panStaEle.Visible = false;
                }
                #endregion

                #region 【交换机供电】
                if (IsEnableAlarm(18))
                {
                    dmc_Info.Add(panJHJEle);
                    panJHJEle.Visible = true;
                }
                else
                {
                    panJHJEle.Visible = false;
                }
                #endregion

                #endregion

                dmc_Info.LeftPartResize();

                strPath = System.Environment.CurrentDirectory + "\\Sound\\Alarm.wav";
                this.timer_Alarm.Interval = RefReshTime._rtTime;

                if (New_DBAcess.blIsClient) //客户端
                {
                    txt_RationEmpCount.Enabled = false;
                }
                else
                {
                    txt_RationEmpCount.Enabled = true;
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region【窗体加载】

        private void A_FrmRTAlarm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadEmpCount();             //额定工作人数
                Refresh_OverEmp();
               
                
                timer_Alarm.Enabled = true;
                timer_Sound.Enabled = true;
            }
            catch (Exception ex)
            { }
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
        private void LoadTree(DegonControlLib.TreeViewControl tvc, DataSet dsTemp, string strName, bool blCount)
        {
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
            SetDataRow(ref dr, 0, "所有", -1, false, blCount, 0);
            dt.Rows.Add(dr);

            tvc.DataSouce = dt;
            tvc.LoadNode(strName);


            //tvc.ExpandAll();
            //tvc.SelectedNode = tvc.Nodes[0];
            //tvc.SetSelectNodeColor();
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

        #region【方法：加载树】
        /// <summary>
        /// 加载树
        /// </summary>
        /// <param name="intModel">1:部门树_实时超时，2：传输分站树，3：工种树，4：区域树，5：部门树——工作异常，
        /// 6：部门树——超速，7：部门树——欠速，8：部门树——求救，14：部门-唯一性，15：部门-下井人员验证</param>
        private void LoadTree(int intModel)
        {
            blIsRefreshTree = false;

            switch (intModel)
            {
                case 1:
                    #region【部门——实时超时】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_EmpOverTime();
                        LoadTree(tvc_EmpOverTime_Dept, ds, "人", true);
                        //treebll.AddTreeRoot(tvc_EmpOverTime_Dept, ds, "所有", "人");
                    }
                    #endregion
                    break;
                case 2:
                    #region【传输分站】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetTree_Station();
                        LoadTree(tvc_Station, ds, "人", false);
                        //treebll.AddTreeRoot(tvc_Station, ds, "所有", "人");
                    }

                    #endregion
                    break;
                case 3:
                    #region【读卡分站】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetTree_StationHead();
                        LoadTree(tvc_StationHead, ds, "人", false);
                        //treebll.AddTreeRoot(tvc_StationHead, ds, "所有", "人");
                    }
                    #endregion
                    break;
                case 4:
                    #region【区域】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_Territorial();
                        LoadTree(tvc_Territorial, ds, "人", true);
                        //treebll.AddTreeRoot(tvc_Territorial, ds, "所有", "人");
                    }

                    #endregion
                    break;
                case 5:
                    #region【部门——工作异常】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_Path();
                        LoadTree(tvc_Path_Dept, ds, "人", true);
                        //treebll.AddTreeRoot(tvc_Path_Dept, ds, "所有", "人");
                    }

                    #endregion
                    break;
                case 6:
                    #region【部门——超速】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_OverSpeed();
                        LoadTree(tvc_OverSpeed_Dept, ds, "人", true);
                    }

                    #endregion
                    break;
                case 7:
                    #region【部门——欠速】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_LackSpeed();
                        LoadTree(tvc_LackSpeed_Dept, ds, "人", true);
                    }

                    #endregion
                    break;
                case 8:
                    #region【部门——求救】

                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_EmpHelp();
                        LoadTree(tvc_EmpHelp_Dept, ds, "人", true);
                    }

                    #endregion
                    break;
                case 14:
                    #region 【部门--唯一性报警】
                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_CheckCards();
                        LoadTree(tvc_CheckCard_Dept, ds, "人", true);
                    }
                    #endregion
                    break;
                case 15:
                    #region 【部门--下井人员验证】
                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetDeptTree_InWellValidate();
                        LoadTree(tvc_InWellValidate, ds, "人", true);
                    }
                    #endregion
                    break;
                case 16:
                    #region【传输分站供电】
                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetTree_StaEle();
                        LoadTree(trViewStaEle, ds, "人", false);
                        //treebll.AddTreeRoot(tvc_Station, ds, "所有", "人");
                    }

                    #endregion
                    break;
                case 17:
                    #region【交换机供电情况】
                    using (ds = new DataSet())
                    {
                        ds = rtabll.GetTree_JHHEle();
                        LoadTree(trvJHJTree, ds, "人", false);
                    }
                    #endregion
                    break;
                default:
                    break;
            }
            blIsRefreshTree = true;
        }

        #endregion

        #region【方法：报警声音】

        /// <summary>
        /// 报警声音
        /// </summary>
        /// <param name="dt">报警声音(DataTable)</param>
        private void AlarmSound(int intAlarmType, DataTable dt)
        {
            int intType = Convert.ToInt32(dt.Rows[0][0]);
            string strNowPath = "";
            switch (intType)
            {
                case 1:
                    strAlarm[intAlarmType - 1] = "-1";

                    break;
                case 2:
                    strNowPath = strPath;
                    //Sound(strNowPath);
                    strAlarm[intAlarmType - 1] = strNowPath;
                    break;
                case 3:
                case 4:
                    strNowPath = dt.Rows[0][1].ToString();
                    strAlarm[intAlarmType - 1] = strNowPath;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region【方法：判断是否报警】

        private void IsAlarm()
        {
            //判断实时报警中，是否有报警信息
            bool blIsAlarm = false;

            DataTable dt;
            try
            {
                #region 【注销】
                //#region【求救报警】

                //if (IsEnableAlarm(10))
                //{
                //    string strEmpHelpCount = rtabll.GetEmpHelpCounts();
                //    if (Convert.ToInt32(strEmpHelpCount) > 0)
                //    {
                //        //Czlt-2011-07-13 给求救数组赋值 -10
                //        GetNewAlarm[4] = Convert.ToInt32(strEmpHelpCount);

                //        if (GetNewAlarm[4] == CheckAlarm[4])
                //        {
                //            //IsAlarmFull[4] = true;
                //        }
                //        else
                //        {
                //            CheckAlarm[4] = GetNewAlarm[4];
                //            IsAlarmFull[4] = false;
                //            SelctText(!IsAlarmFull[4]);

                //        }

                //        //有求救报警
                //        using (dt = new DataTable())
                //        {
                //            //启用报警的时候发出声音
                //            if (!IsAlarmFull[4])
                //            {
                //                dt = rtabll.LoadAlarmPath(10);
                //                if (dt != null && dt.Rows.Count > 0)
                //                {
                //                    AlarmSound(10, dt);
                //                }
                //            }
                //        }
                //        bt_EmpHelp.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无求救报警
                //        blIsAlarm = blIsAlarm || false;

                //        bt_EmpHelp.ForeColor = Color.Black;
                //    }
                //}

                //#endregion

                //#region【超时报警】

                //if (rtabll.IsAlarm(1))
                //{
                //    //有报警
                //    using (dt = new DataTable())
                //    {
                //        dt = rtabll.LoadAlarmPath(1);
                //        if (dt != null && dt.Rows.Count > 0)
                //        {
                //            AlarmSound(1, dt);
                //        }
                //    }
                //    bt_EmpOverTime.ForeColor = Color.Red;

                //    blIsAlarm = blIsAlarm || true;
                //}
                //else
                //{
                //    //无报警
                //    bt_EmpOverTime.ForeColor = Color.Black;

                //    blIsAlarm = blIsAlarm || false;
                //}

                //#endregion

                //#region【区域报警】

                //if (rtabll.IsAlarm(2))
                //{
                //    //有报警
                //    using (dt = new DataTable())
                //    {
                //        dt = rtabll.LoadAlarmPath(2);
                //        if (dt != null && dt.Rows.Count > 0)
                //        {
                //            AlarmSound(2, dt);
                //        }
                //    }
                //    bt_Territorial.ForeColor = Color.Red;

                //    blIsAlarm = blIsAlarm || true;
                //}
                //else
                //{
                //    //无报警
                //    bt_Territorial.ForeColor = Color.Black;

                //    blIsAlarm = blIsAlarm || false;
                //}

                //#endregion

                //#region【传输分站报警】

                //if (rtabll.IsAlarm(3))
                //{
                //    //有报警
                //    using (dt = new DataTable())
                //    {
                //        dt = rtabll.LoadAlarmPath(3);
                //        if (dt != null && dt.Rows.Count > 0)
                //        {
                //            AlarmSound(3, dt);
                //        }
                //    }
                //    bt_Station.ForeColor = Color.Red;

                //    blIsAlarm = blIsAlarm || true;
                //}
                //else
                //{
                //    //无报警
                //    bt_Station.ForeColor = Color.Black;

                //    blIsAlarm = blIsAlarm || false;
                //}

                //#endregion

                //#region【超员报警】

                //if (rtabll.IsAlarm(4))
                //{
                //    //有报警
                //    using (dt = new DataTable())
                //    {
                //        dt = rtabll.LoadAlarmPath(4);
                //        if (dt != null && dt.Rows.Count > 0)
                //        {
                //            AlarmSound(4, dt);
                //        }
                //    }
                //    bt_OverEmp.ForeColor = Color.Red;

                //    blIsAlarm = blIsAlarm || true;
                //}
                //else
                //{
                //    //无报警
                //    bt_OverEmp.ForeColor = Color.Black;

                //    blIsAlarm = blIsAlarm || false;
                //}

                //#endregion

                //#region【低电量报警】

                //if (IsEnableAlarm(5))
                //{
                //    if (rtabll.IsAlarm(5))
                //    {
                //        //有报警
                //        using (dt = new DataTable())
                //        {
                //            dt = rtabll.LoadAlarmPath(5);
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                AlarmSound(5, dt);
                //            }
                //        }

                //        blIsAlarm = blIsAlarm || true;
                //        bt_Electricity.ForeColor = Color.Red;
                //    }
                //    else
                //    {
                //        blIsAlarm = blIsAlarm || false;
                //        //无报警
                //        bt_Electricity.ForeColor = Color.Black;
                //    }
                //}

                //#endregion

                //#region【读卡分站故障报警】

                //if (rtabll.IsAlarm(6))
                //{
                //    //有报警
                //    using (dt = new DataTable())
                //    {
                //        dt = rtabll.LoadAlarmPath(6);
                //        if (dt != null && dt.Rows.Count > 0)
                //        {
                //            AlarmSound(6, dt);
                //        }
                //    }
                //    bt_StationHead.ForeColor = Color.Red;

                //    blIsAlarm = blIsAlarm || true;
                //}
                //else
                //{
                //    //无报警
                //    bt_StationHead.ForeColor = Color.Black;

                //    blIsAlarm = blIsAlarm || false;
                //}

                //#endregion

                //#region【工作异常报警】

                //if (IsEnableAlarm(7))
                //{
                //    if (rtabll.IsAlarm(7))
                //    {
                //        //有报警
                //        using (dt = new DataTable())
                //        {
                //            dt = rtabll.LoadAlarmPath(7);
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                AlarmSound(7, dt);
                //            }
                //        }
                //        bt_Path.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无报警
                //        bt_Path.ForeColor = Color.Black;

                //        blIsAlarm = blIsAlarm || false;
                //    }
                //}

                //#endregion

                //#region【超速】

                //if (IsEnableAlarm(8))
                //{
                //    if (rtabll.IsAlarm(8))
                //    {
                //        //有报警
                //        using (dt = new DataTable())
                //        {
                //            dt = rtabll.LoadAlarmPath(8);
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                AlarmSound(8, dt);
                //            }
                //        }
                //        bt_OverSpeed.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无报警
                //        bt_OverSpeed.ForeColor = Color.Black;

                //        blIsAlarm = blIsAlarm || false;
                //    }
                //}

                //#endregion

                //#region【欠速】

                //if (IsEnableAlarm(9))
                //{
                //    if (rtabll.IsAlarm(9))
                //    {
                //        //有报警
                //        using (dt = new DataTable())
                //        {
                //            dt = rtabll.LoadAlarmPath(9);
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                AlarmSound(9, dt);
                //            }
                //        }
                //        bt_LackSpeed.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无报警
                //        bt_LackSpeed.ForeColor = Color.Black;

                //        blIsAlarm = blIsAlarm || false;
                //    }
                //}

                //#endregion

                //#region【区域超时】

                //if (IsEnableAlarm(11))
                //{
                //    if (rtabll.IsAlarm(11))
                //    {
                //        //有报警
                //        using (dt = new DataTable())
                //        {
                //            dt = rtabll.LoadAlarmPath(11);
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                AlarmSound(11, dt);
                //            }
                //        }
                //        bt_TerOverTime.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无报警
                //        bt_TerOverTime.ForeColor = Color.Black;

                //        blIsAlarm = blIsAlarm || false;
                //    }
                //}
                //#endregion

                //#region【区域超员】

                //if (IsEnableAlarm(12))
                //{
                //    if (rtabll.IsAlarm(12))
                //    {
                //        //有报警
                //        using (dt = new DataTable())
                //        {
                //            dt = rtabll.LoadAlarmPath(12);
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                AlarmSound(12, dt);
                //            }
                //        }
                //        bt_TerOverEmp.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无报警
                //        bt_TerOverEmp.ForeColor = Color.Black;

                //        blIsAlarm = blIsAlarm || false;
                //    }
                //}

                //#endregion

                //#region 【异地交接班信息】

                //if (IsEnableAlarm(13))
                //{
                //    if (rtabll.IsAlarm(13))
                //    {
                //        //有报警
                //        using (dt = new DataTable())
                //        {
                //            dt = rtabll.LoadAlarmPath(13);
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                AlarmSound(13, dt);
                //            }
                //        }
                //        btnAssociate.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无报警
                //        btnAssociate.ForeColor = Color.Black;

                //        blIsAlarm = blIsAlarm || false;
                //    }
                //}

                //#endregion

                //#region 【唯一性报警】
                //if (IsEnableAlarm(14))
                //{
                //    if (rtabll.IsAlarm(14))
                //    {
                //        //有报警
                //        using (dt = new DataTable())
                //        {
                //            dt = rtabll.LoadAlarmPath(14);
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                AlarmSound(14, dt);
                //            }
                //        }
                //        btnCheckCards.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无报警
                //        btnCheckCards.ForeColor = Color.Black;

                //        blIsAlarm = blIsAlarm || false;
                //    }
                //}
                //#endregion

                //#region 【下井人员验证】
                //if (IsEnableAlarm(14))
                //{
                //    if (rtabll.IsAlarm(15))
                //    {
                //        btnInWellValidate.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无报警
                //        btnInWellValidate.ForeColor = Color.Black;

                //        blIsAlarm = blIsAlarm || false;
                //    }
                //}
                //#endregion
                #endregion

                #region【求救报警】


                if (IsEnableAlarm(10))
                {
                    string strEmpHelpCount = rtabll.GetEmpHelpCounts();
                    if (Convert.ToInt32(strEmpHelpCount) > 0)
                    {
                        //Czlt-2011-07-13 给求救数组赋值 -10
                        GetNewAlarm[4] = Convert.ToInt32(strEmpHelpCount);

                        if (GetNewAlarm[4] == CheckAlarm[4])
                        {
                            //IsAlarmFull[4] = true;
                        }
                        else
                        {
                            CheckAlarm[4] = GetNewAlarm[4];
                            IsAlarmFull[4] = false;
                            SelctText(!IsAlarmFull[4]);

                        }

                        //有求救报警
                        using (dt = new DataTable())
                        {
                            //启用报警的时候发出声音
                            if (!IsAlarmFull[4])
                            {
                                dt = rtabll.LoadAlarmPath(10);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    AlarmSound(10, dt);
                                }
                            }
                        }
                        bt_EmpHelp.ForeColor = Color.Red;

                        blIsAlarm = blIsAlarm || true;
                    }
                    else
                    {
                        //无求救报警
                        blIsAlarm = blIsAlarm || false;

                        bt_EmpHelp.ForeColor = Color.Black;
                    }
                }


                #endregion

                #region【超时报警】

                intCzltAlarmCount = rtabll.CzltIsAlarm(1);
                //if (rtabll.IsAlarm(1))
                if (intCzltAlarmCount != 0)
                {
                    ///Czlt-2011-07-13 给超时数组赋值 -1
                    GetNewAlarm[1] = intCzltAlarmCount;

                    if (GetNewAlarm[1] == CheckAlarm[1])
                    {
                        // IsAlarmFull[1] = true;
                    }
                    else
                    {
                        CheckAlarm[1] = GetNewAlarm[1];
                        IsAlarmFull[1] = false;
                        SelctText(!IsAlarmFull[1]);

                    }

                    //有报警
                    using (dt = new DataTable())
                    {
                        if (!IsAlarmFull[1])
                        {
                            dt = rtabll.LoadAlarmPath(1);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                AlarmSound(1, dt);
                            }
                        }
                    }
                    bt_EmpOverTime.ForeColor = Color.Red;

                    blIsAlarm = blIsAlarm || true;
                }
                else
                {
                    //无报警
                    bt_EmpOverTime.ForeColor = Color.Black;

                    blIsAlarm = blIsAlarm || false;
                }


                #endregion

                #region【区域报警】

                //Czlt-2011-07-13 查询区域报警条数
                intCzltAlarmCount = rtabll.CzltIsAlarm(2);
                //if (rtabll.IsAlarm(2))
                if (intCzltAlarmCount != 0)
                {
                    ///Czlt-2011-07-13 为区域报警数组赋值 -2
                    GetNewAlarm[2] = intCzltAlarmCount;

                    if (GetNewAlarm[2] == CheckAlarm[2])
                    {
                        //IsAlarmFull[2] = true;
                    }
                    else
                    {
                        CheckAlarm[2] = GetNewAlarm[2];
                        IsAlarmFull[2] = false;
                        SelctText(!IsAlarmFull[2]);

                    }
                    //有报警
                    using (dt = new DataTable())
                    {
                        if (!IsAlarmFull[2])
                        {
                            dt = rtabll.LoadAlarmPath(2);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                AlarmSound(2, dt);
                            }
                        }
                    }
                    bt_Territorial.ForeColor = Color.Red;

                    blIsAlarm = blIsAlarm || true;
                }
                else
                {
                    //无报警
                    bt_Territorial.ForeColor = Color.Black;

                    blIsAlarm = blIsAlarm || false;
                }


                #endregion

                #region【传输分站报警】

                //Czlt-2011-07-13 查询传输分站报警条数
                intCzltAlarmCount = rtabll.CzltIsAlarm(3);
                //if (rtabll.IsAlarm(3))
                if (intCzltAlarmCount != 0)
                {
                    ///Czlt-2011-07-13 为传输分站报警数组赋值 -3
                    GetNewAlarm[5] = intCzltAlarmCount;
                    if (GetNewAlarm[5] == CheckAlarm[5])
                    {
                        //IsAlarmFull[5] = true;
                    }
                    else
                    {
                        CheckAlarm[5] = GetNewAlarm[5];
                        IsAlarmFull[5] = false;
                        SelctText(!IsAlarmFull[5]);

                    }
                    //有报警
                    using (dt = new DataTable())
                    {
                        if (!IsAlarmFull[5])
                        {
                            dt = rtabll.LoadAlarmPath(3);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                AlarmSound(3, dt);
                            }
                        }
                    }
                    bt_Station.ForeColor = Color.Red;

                    blIsAlarm = blIsAlarm || true;
                }
                else
                {
                    //无报警
                    bt_Station.ForeColor = Color.Black;

                    blIsAlarm = blIsAlarm || false;
                }

                #endregion

                #region【超员报警】

                //Czlt-2011-07-13 查询超员报警条数
                intCzltAlarmCount = rtabll.CzltIsAlarm(4);
                if (intCzltAlarmCount != 0)
                {
                    ///Czlt-2011-07-13 为超员报警数组赋值 -4
                    GetNewAlarm[0] = intCzltAlarmCount;
                    if (GetNewAlarm[0] == CheckAlarm[0])
                    {
                        // IsAlarmFull[0] = true;
                    }
                    else
                    {
                        CheckAlarm[0] = GetNewAlarm[0];
                        IsAlarmFull[0] = false;
                        SelctText(!IsAlarmFull[0]);

                    }
                    //有报警
                    using (dt = new DataTable())
                    {
                        //启用报警的时候发出声音
                        if (!IsAlarmFull[0])
                        {
                            dt = rtabll.LoadAlarmPath(4);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                AlarmSound(4, dt);
                            }
                        }
                    }
                    bt_OverEmp.ForeColor = Color.Red;

                    blIsAlarm = blIsAlarm || true;
                }
                else
                {
                    //无报警
                    bt_OverEmp.ForeColor = Color.Black;

                    blIsAlarm = blIsAlarm || false;
                }

                #endregion

                #region【低电量报警】


                if (IsEnableAlarm(5))
                {
                    //Czlt-2011-07-13 查询低电量报警条数
                    intCzltAlarmCount = rtabll.CzltIsAlarm(5);

                    //if (rtabll.IsAlarm(5))
                    if (intCzltAlarmCount != 0)
                    {
                        ///Czlt-2011-07-13 为低电量报警数组赋值 -5
                        GetNewAlarm[7] = intCzltAlarmCount;
                        if (GetNewAlarm[7] == CheckAlarm[7])
                        {
                            //IsAlarmFull[7] = true;
                        }
                        else
                        {
                            CheckAlarm[7] = GetNewAlarm[7];
                            IsAlarmFull[7] = false;
                            SelctText(!IsAlarmFull[7]);

                        }
                        //有报警
                        using (dt = new DataTable())
                        {
                            //启用报警的时候发出声音
                            if (!IsAlarmFull[7])
                            {
                                dt = rtabll.LoadAlarmPath(5);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    AlarmSound(5, dt);
                                }
                            }
                        }

                        blIsAlarm = blIsAlarm || true;
                        bt_Electricity.ForeColor = Color.Red;
                    }
                    else
                    {
                        blIsAlarm = blIsAlarm || false;
                        //无报警
                        bt_Electricity.ForeColor = Color.Black;
                    }
                }

                #endregion

                #region【读卡分站故障报警】

                //Czlt-2011-07-13 查询读卡分站报警条数
                intCzltAlarmCount = rtabll.CzltIsAlarm(6);
                //if (rtabll.IsAlarm(6))
                if (intCzltAlarmCount != 0)
                {
                    ///Czlt-2011-07-13 为读卡分站报警数组赋值 -6
                    GetNewAlarm[6] = intCzltAlarmCount;

                    if (GetNewAlarm[6] == CheckAlarm[6])
                    {
                        //IsAlarmFull[6] = true;
                    }
                    else
                    {
                        CheckAlarm[6] = GetNewAlarm[6];
                        IsAlarmFull[6] = false;
                        SelctText(!IsAlarmFull[6]);

                    }
                    //有报警
                    using (dt = new DataTable())
                    {
                        //启用报警的时候发出声音
                        if (!IsAlarmFull[6])
                        {
                            dt = rtabll.LoadAlarmPath(6);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                AlarmSound(6, dt);
                            }
                        }
                    }
                    bt_StationHead.ForeColor = Color.Red;

                    blIsAlarm = blIsAlarm || true;
                }
                else
                {
                    //无报警
                    bt_StationHead.ForeColor = Color.Black;

                    blIsAlarm = blIsAlarm || false;
                }

                #endregion

                #region【工作异常报警】

                if (IsEnableAlarm(7))
                {
                    //Czlt-2011-07-13 查询工作异常报警条数
                    intCzltAlarmCount = rtabll.CzltIsAlarm(7);
                    //if (rtabll.IsAlarm(7))
                    if (intCzltAlarmCount != 0)
                    {
                        ///Czlt-2011-07-13 为工作异常报警数组赋值 -7
                        GetNewAlarm[3] = intCzltAlarmCount;
                        if (GetNewAlarm[3] == CheckAlarm[3])
                        {
                            //IsAlarmFull[3] = true;
                        }
                        else
                        {
                            CheckAlarm[3] = GetNewAlarm[3];
                            IsAlarmFull[3] = false;
                            SelctText(!IsAlarmFull[3]);

                        }
                        //有报警
                        using (dt = new DataTable())
                        {
                            //启用报警的时候发出声音
                            if (!IsAlarmFull[3])
                            {
                                dt = rtabll.LoadAlarmPath(7);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    AlarmSound(7, dt);
                                }
                            }
                        }
                        bt_Path.ForeColor = Color.Red;

                        blIsAlarm = blIsAlarm || true;
                    }
                    else
                    {
                        //无报警
                        bt_Path.ForeColor = Color.Black;

                        blIsAlarm = blIsAlarm || false;
                    }
                }

                #endregion

                #region【超速】

                if (IsEnableAlarm(8))
                {
                    //Czlt-2011-07-13 查询超速报警条数
                    intCzltAlarmCount = rtabll.CzltIsAlarm(8);
                    // if (rtabll.IsAlarm(8))
                    if (intCzltAlarmCount != 0)
                    {
                        ///Czlt-2011-07-13 为超速报警数组赋值 -8
                        GetNewAlarm[8] = intCzltAlarmCount;

                        if (GetNewAlarm[8] == CheckAlarm[8])
                        {
                            //IsAlarmFull[8] = true;
                        }
                        else
                        {
                            CheckAlarm[8] = GetNewAlarm[8];
                            IsAlarmFull[8] = false;
                            SelctText(!IsAlarmFull[8]);

                        }

                        //有报警
                        using (dt = new DataTable())
                        {
                            //启用报警的时候发出声音
                            if (!IsAlarmFull[8])
                            {
                                dt = rtabll.LoadAlarmPath(8);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    AlarmSound(8, dt);
                                }
                            }
                        }
                        bt_OverSpeed.ForeColor = Color.Red;

                        blIsAlarm = blIsAlarm || true;
                    }
                    else
                    {
                        //无报警
                        bt_OverSpeed.ForeColor = Color.Black;

                        blIsAlarm = blIsAlarm || false;
                    }
                }

                #endregion

                #region【欠速】

                if (IsEnableAlarm(9))
                {
                    //Czlt-2011-07-13 查询欠速报警条数
                    intCzltAlarmCount = rtabll.CzltIsAlarm(9);

                    //if (rtabll.IsAlarm(9))
                    if (intCzltAlarmCount != 0)
                    {
                        ///Czlt-2011-07-13 为超速报警数组赋值 -9
                        GetNewAlarm[9] = intCzltAlarmCount;
                        if (GetNewAlarm[9] == CheckAlarm[9])
                        {
                            // IsAlarmFull[9] = true;
                        }
                        else
                        {
                            CheckAlarm[9] = GetNewAlarm[9];
                            IsAlarmFull[9] = false;
                            SelctText(!IsAlarmFull[9]);

                        }
                        //有报警
                        using (dt = new DataTable())
                        {
                            //启用报警的时候发出声音
                            if (!IsAlarmFull[9])
                            {
                                dt = rtabll.LoadAlarmPath(9);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    AlarmSound(9, dt);
                                }
                            }
                        }
                        bt_LackSpeed.ForeColor = Color.Red;

                        blIsAlarm = blIsAlarm || true;
                    }
                    else
                    {
                        //无报警
                        bt_LackSpeed.ForeColor = Color.Black;

                        blIsAlarm = blIsAlarm || false;
                    }
                }

                #endregion

                #region【区域超时】

                if (IsEnableAlarm(11))
                {
                    //Czlt-2011-07-13 查询区域超时报警条数
                    intCzltAlarmCount = rtabll.CzltIsAlarm(11);

                    //if (rtabll.IsAlarm(11))
                    if (intCzltAlarmCount != 0)
                    {
                        ///Czlt-2011-07-13 为区域超时报警数组赋值 -11
                        GetNewAlarm[10] = intCzltAlarmCount;
                        if (GetNewAlarm[10] == CheckAlarm[10])
                        {
                            //IsAlarmFull[10] = true;
                        }
                        else
                        {
                            CheckAlarm[10] = GetNewAlarm[10];
                            IsAlarmFull[10] = false;
                            SelctText(!IsAlarmFull[10]);

                        }
                        //有报警
                        using (dt = new DataTable())
                        {
                            //启用报警的时候发出声音
                            if (!IsAlarmFull[10])
                            {
                                dt = rtabll.LoadAlarmPath(11);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    AlarmSound(11, dt);
                                }
                            }
                        }
                        bt_TerOverTime.ForeColor = Color.Red;

                        blIsAlarm = blIsAlarm || true;
                    }
                    else
                    {
                        //无报警
                        bt_TerOverTime.ForeColor = Color.Black;

                        blIsAlarm = blIsAlarm || false;
                    }
                }
                #endregion

                #region【区域超员】

                if (IsEnableAlarm(12))
                {
                    //Czlt-2011-07-13 查询区域超时报警条数
                    intCzltAlarmCount = rtabll.CzltIsAlarm(12);

                    //if (rtabll.IsAlarm(12))
                    if (intCzltAlarmCount != 0)
                    {
                        ///Czlt-2011-07-13 为区域超时报警数组赋值 -12
                        GetNewAlarm[11] = intCzltAlarmCount;
                        if (GetNewAlarm[11] == CheckAlarm[11])
                        {
                            //IsAlarmFull[11] = true;
                        }
                        else
                        {
                            CheckAlarm[11] = GetNewAlarm[11];
                            IsAlarmFull[11] = false;
                            SelctText(!IsAlarmFull[11]);

                        }
                        //有报警
                        using (dt = new DataTable())
                        {
                            //启用报警的时候发出声音
                            if (!IsAlarmFull[11])
                            {
                                dt = rtabll.LoadAlarmPath(12);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    AlarmSound(12, dt);
                                }
                            }
                        }
                        bt_TerOverEmp.ForeColor = Color.Red;

                        blIsAlarm = blIsAlarm || true;
                    }
                    else
                    {
                        //无报警
                        bt_TerOverEmp.ForeColor = Color.Black;

                        blIsAlarm = blIsAlarm || false;
                    }
                }

                #endregion

                #region 【异地交接班信息】

                if (IsEnableAlarm(13))
                {
                    //Czlt-2011-07-13 查询异地交接班报警条数
                    intCzltAlarmCount = rtabll.CzltIsAlarm(13);

                    //if (rtabll.IsAlarm(13))
                    if (intCzltAlarmCount != 0)
                    {
                        ///Czlt-2011-07-13 为异地交接班报警数组赋值 -13
                        GetNewAlarm[12] = intCzltAlarmCount;
                        if (GetNewAlarm[12] == CheckAlarm[12])
                        {
                            // IsAlarmFull[12] = true;
                        }
                        else
                        {
                            CheckAlarm[12] = GetNewAlarm[12];
                            IsAlarmFull[12] = false;
                            SelctText(!IsAlarmFull[12]);

                        }
                        //有报警
                        using (dt = new DataTable())
                        {
                            //启用报警的时候发出声音
                            if (!IsAlarmFull[12])
                            {
                                dt = rtabll.LoadAlarmPath(13);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    AlarmSound(13, dt);
                                }
                            }
                        }
                        btnAssociate.ForeColor = Color.Red;

                        blIsAlarm = blIsAlarm || true;
                    }
                    else
                    {
                        //无报警
                        btnAssociate.ForeColor = Color.Black;

                        blIsAlarm = blIsAlarm || false;
                    }
                }

                #endregion

                #region 【唯一性报警】
                if (IsEnableAlarm(14))
                {
                    //Czlt-2011-07-13 查询异地交接班报警条数
                    intCzltAlarmCount = rtabll.CzltIsAlarm(14);

                    //if (rtabll.IsAlarm(14))
                    if (intCzltAlarmCount != 0)
                    {

                        ///Czlt-2011-07-13 为异地交接班报警数组赋值 -14
                        GetNewAlarm[13] = intCzltAlarmCount;
                        if (GetNewAlarm[13] == CheckAlarm[13])
                        {
                            //IsAlarmFull[13] = true;
                        }
                        else
                        {
                            CheckAlarm[13] = GetNewAlarm[13];
                            IsAlarmFull[13] = false;
                            SelctText(!IsAlarmFull[13]);

                        }
                        //有报警
                        using (dt = new DataTable())
                        {
                            //启用报警的时候发出声音
                            if (!IsAlarmFull[13])
                            {
                                dt = rtabll.LoadAlarmPath(14);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    AlarmSound(14, dt);
                                }
                            }
                        }
                        btnCheckCards.ForeColor = Color.Red;

                        blIsAlarm = blIsAlarm || true;
                    }
                    else
                    {
                        //无报警
                        btnCheckCards.ForeColor = Color.Black;

                        blIsAlarm = blIsAlarm || false;
                    }
                }
                #endregion

                #region 【下井人员验证】
                //if (IsEnableAlarm(14))
                //{
                //    //Czlt-2011-07-13 查询异地交接班报警条数
                //    intCzltAlarmCount = rtabll.CzltIsAlarm(15);
                //    //if (rtabll.IsAlarm(15))
                //    if (intCzltAlarmCount != 0)
                //    {
                //        btnInWellValidate.ForeColor = Color.Red;

                //        blIsAlarm = blIsAlarm || true;
                //    }
                //    else
                //    {
                //        //无报警
                //        btnInWellValidate.ForeColor = Color.Black;

                //        blIsAlarm = blIsAlarm || false;
                //    }
                //}
                #endregion

                #region 【传输分站供电报警】

                //Czlt-2011-07-13 查询传输分站供电报警条数
                intCzltAlarmCount = rtabll.CzltIsAlarm(16);
                //if (rtabll.IsAlarm(16))
                if (intCzltAlarmCount != 0)
                {
                    ///Czlt-2011-07-13 为传输分站供电报警数组赋值 -16
                    GetNewAlarm[15] = intCzltAlarmCount;
                    if (GetNewAlarm[15] == CheckAlarm[15])
                    {
                        //IsAlarmFull[15] = true;
                    }
                    else
                    {
                        CheckAlarm[15] = GetNewAlarm[15];
                        IsAlarmFull[15] = false;
                        SelctText(!IsAlarmFull[15]);

                    }

                    //有报警
                    using (dt = new DataTable())
                    {
                        //启用报警的时候发出声音
                        if (!IsAlarmFull[15])
                        {
                            dt = rtabll.LoadAlarmPath(17);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                AlarmSound(15, dt);
                            }
                        }
                    }
                    btnStaEle.ForeColor = Color.Red;

                    blIsAlarm = blIsAlarm || true;
                }
                else
                {
                    //无报警
                    btnStaEle.ForeColor = Color.Black;

                    blIsAlarm = blIsAlarm || false;

                }
                #endregion

                #region 【交换机供电报警】
                //Czlt-2011-07-13 查询传输分站供电报警条数
                intCzltAlarmCount = rtabll.CzltIsAlarm(17);
                if (intCzltAlarmCount != 0)
                {
                    ///Czlt-2011-07-13 为传输分站供电报警数组赋值 -16
                    GetNewAlarm[16] = intCzltAlarmCount;
                    if (GetNewAlarm[16] == CheckAlarm[16])
                    {
                        //IsAlarmFull[16] = true;
                    }
                    else
                    {
                        CheckAlarm[16] = GetNewAlarm[16];
                        IsAlarmFull[16] = false;
                        SelctText(!IsAlarmFull[16]);

                    }
                    //有报警
                    using (dt = new DataTable())
                    {
                        //启用报警的时候发出声音
                        if (!IsAlarmFull[16])
                        {
                            dt = rtabll.LoadAlarmPath(18);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                AlarmSound(16, dt);
                            }
                        }
                    }
                    btnJHJEle.ForeColor = Color.Red;

                    blIsAlarm = blIsAlarm || true;
                }
                else
                {
                    //无报警
                    btnJHJEle.ForeColor = Color.Black;

                    blIsAlarm = blIsAlarm || false;
                }
                #endregion
            }
            catch
            {
                blIsAlarm = false;
                return;
            }
            _blIsAlarm = blIsAlarm;
        }

        #endregion


        #region【事件：窗体关闭】

        private void A_FrmRTAlarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion


        #region【事件：定时器】

        private void timer_Alarm_Tick(object sender, EventArgs e)
        {
            try
            {
                //qyz 获取焦点判断 2012-3-30
                if (this.IsActivated || this.DockHandler == dockPanel.ActiveDocument.DockHandler)
                {
                    if (chb_RTRefresh.Checked)
                    {
                        #region【刷新打开的界面】

                        switch (intSelectModel)
                        {
                            case 1:
                                #region【超员】

                                Refresh_OverEmp();

                                #endregion
                                break;
                            case 2:
                                #region【超时】

                                Refresh_EmpOverTime();

                                #endregion
                                break;
                            case 3:
                                #region【区域】

                                Refresh_Territorial();

                                #endregion
                                break;
                            case 4:
                                #region【工作异常】

                                Refresh_Path();

                                #endregion
                                break;
                            case 5:
                                #region【求救】

                                Refresh_EmpHelp();

                                #endregion
                                break;
                            case 6:
                                #region【传输分站】

                                Refresh_Station();

                                #endregion
                                break;
                            case 7:
                                #region【读卡分站】

                                Refresh_StationHead();

                                #endregion
                                break;
                            case 8:
                                #region【低电量】

                                Refresh_Electricity();

                                #endregion
                                break;
                            case 9:
                                #region【超速】

                                Refresh_OverSpeed();

                                #endregion
                                break;
                            case 10:
                                #region【欠速】

                                Refresh_LackSpeed();

                                #endregion
                                break;
                            case 11:
                                #region[区域超时]
                                Refresh_EmpTerOverTime();
                                #endregion
                                break;
                            case 12:
                                #region【区域超员】

                                Refresh_TerOverEmp();

                                #endregion
                                break;
                            case 13:
                                #region 【异地交接班】
                                Refresh_Associate();
                                #endregion
                                break;
                            case 14:
                                #region 【唯一性报警】
                                Refresh_Onlyone();
                                #endregion
                                break;
                            case 15:
                                #region 【人员下井验证】
                                Refresh_InWellValidate();
                                #endregion
                                break;
                            case 16:
                                #region 【分站供电报警】
                                Refresh_StaEle();
                                #endregion
                                break;
                            case 17:
                                #region【交换机供电报警】
                                Refresh_JhjEle();
                                #endregion
                                break;
                            default:
                                break;
                        }

                        #endregion
                    }
                }

                //判断是否报警
                IsAlarm();
            }
            catch { }
        }

        #endregion

        #region【事件：打印】

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string printTitle = string.Empty;

            switch (intSelectModel)
            {
                case 1:
                    printTitle = "超员";
                    break;
                case 2:
                    printTitle = "超时";
                    break;
                case 3:
                    printTitle = "区域";
                    break;
                case 4:
                    printTitle = "工作异常";
                    break;
                case 5:
                    printTitle = "求救报警";
                    break;
                case 6:
                    printTitle = "传输分站";
                    break;
                case 7:
                    printTitle = "读卡分站";
                    break;
                case 8:
                    printTitle = "低电量";
                    break;
                case 9:
                    printTitle = "超速";
                    break;
                case 10:
                    printTitle = "欠速";
                    break;
                case 11:
                    printTitle = "区域超时";
                    break;
                case 12:
                    printTitle = "区域超员";
                    break;
                case 13:
                    printTitle = "异地交接班";
                    break;
                case 14:
                    printTitle = "唯一性报警";
                    break;
                case 15:
                    printTitle = "下井人员验证";
                    break;
                case 16:
                    printTitle = "分站供电报警";
                    break;
                case 17:
                    printTitle = "交换机供电报警";
                    break;
                default:
                    break;
            }

            printTitle = "实时" + printTitle + "信息";

            KJ128NDBTable.PrintBLL.Print(dgv_Main, printTitle, "共" + this.dgv_Main.Rows.Count.ToString() + "条记录");
            //if (printTitle.Equals("实时求救报警信息"))
            //{
            //    DataTable czltDt = (DataTable)this.dgv_Main.DataSource;
            //    czltDt.Columns.Remove("RTEmpHelpID");
            //    czltDt.Columns.Remove("救援措施");
            //    new PrintCore.ExportExcel().Sql_ExportExcel(dgv_Main, "");
            //}
            //else
            //{
            //    KJ128NDBTable.PrintBLL.Print(dgv_Main, printTitle, "共" + this.dgv_Main.Rows.Count.ToString() + "条记录");
            //}
        }

        #endregion


        #region【方法：判断是否是显示救援措施】

        private void IsShowRescue(bool bl)
        {
            if (bl)
            {
                //btnLaws.Text = "措施";
            }
            else
            {
                btnLaws.Visible = false;
                if (dgv_Main.Columns.Contains("clMeasure"))
                {
                    dgv_Main.Columns.Remove("clMeasure");
                }
            }

        }

        #endregion

        #region【事件：点击单元格】

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (intSelectModel == 5)        //求救
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        if (dgv_Main.Columns[e.ColumnIndex].Name.Equals("clMeasure"))
                        {
                            string strCodeSenderAddress_EmpHelp, strName_EmpHelp;
                            strCodeSenderAddress_EmpHelp = dgv_Main.Rows[e.RowIndex].Cells["标识卡号"].Value.ToString();
                            strName_EmpHelp = dgv_Main.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                            A_FrmRTAlarm_EmpHelpMeasure frmEhm = new A_FrmRTAlarm_EmpHelpMeasure(strCodeSenderAddress_EmpHelp, strName_EmpHelp);
                            if (frmEhm.ShowDialog() == DialogResult.Yes)
                            {
                                Refresh_EmpHelp();
                            }
                        }
                    }
                }
                catch { }
            }
            if (intSelectModel == 14)//解除唯一性报警
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        if (dgv_Main.Columns[e.ColumnIndex].Name.Equals("clMeasure"))
                        {
                            string strCodeSenderAddress_Onlyone, strName_Onlyone;
                            strCodeSenderAddress_Onlyone = dgv_Main.Rows[e.RowIndex].Cells["标识卡号"].Value.ToString();
                            strName_Onlyone = dgv_Main.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                            A_FrmRTAlarm_unchainCheckCards frmUnchainCheckCards = new A_FrmRTAlarm_unchainCheckCards(strCodeSenderAddress_Onlyone, strName_Onlyone);
                            if (frmUnchainCheckCards.ShowDialog() == DialogResult.Yes)
                            {
                                Refresh_Onlyone();
                            }
                        }
                    }
                }
                catch
                { }
            }
        }

        #endregion

        #region 播放声音
        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="str">声音文件路径</param>
        private void Sound(string str)
        {
            SoundPlayer simpleSound;
            if (str == null || str.Equals("-1") || str == "")
            {
                return;
            }
            try
            {
                simpleSound = new SoundPlayer(@str);
                simpleSound.Play();
            }
            catch
            {
                simpleSound = new SoundPlayer(@strPath);
            }

        }
        #endregion

        #region【事件：定时播放报警声音】

        private void timer_Sound_Tick(object sender, EventArgs e)
        {
            string strSoundPath;
            try
            {
                strSoundPath = strAlarm[intAlarm - 1];

                if (strSoundPath != null && strSoundPath != "" && strSoundPath != "-1")
                {
                    int intSoundTime = GetSoundPlayTime(strSoundPath);

                    timer_Sound.Interval = intSoundTime * 1000 + 1000;

                    //播放报警声音
                    Sound(strSoundPath);
                    strAlarm[intAlarm - 1] = null;
                }
                else
                {
                    timer_Sound.Interval = 10;
                }
                if (intAlarm == intAlarmCount)
                {
                    intAlarm = 1;
                    timer_Sound.Interval = 3000;
                }
                else
                {
                    intAlarm++;
                }



                //********************Czlt-2011-12-10 修改配置信息*Start****************************************
                string strChkTime = "";
                strChkTime = rtabll.GetChangeTime().ToString();
                if (strChkTime.Trim().Equals(""))
                {
                }
                else
                {

                    if ((DateTime.Now - Convert.ToDateTime(strChkTime.Trim())).TotalSeconds < 10)
                    {
                        CzltUpdateXml();
                    }
                    else
                    {
                        //Czlt-20111-10-10 热备分站信息
                        if (DateTime.Now.ToString("HH:mm").Equals("18:00"))
                        {
                            CzltUpdateXml();
                        }


                        //在每天的零点的时候执行 生成历史表的文件
                        if (DateTime.Now.ToString("HH:mm").Equals("00:00"))
                        {
                            //CzltUpdateXml();
                            rtabll.CzltCreateHisTable(DateTime.Now.Year, DateTime.Now.Month);
                        }
                        else
                        {
                            //在每个月的第28天的时候生成下一个月的四个历史表
                            if (DateTime.Now.Day >= 28)
                            {
                                rtabll.CzltCreateHisTable(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month);
                            }
                        }
                    }
                }
                //********************Czlt-2011-12-10 修改配置信息*End******************************************

            }
            catch { }
        }

        #endregion

        #region【方法：获取声音文件的播放时间】

        private int GetSoundPlayTime(string stringpath)
        {
            int s = 0;
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(stringpath, System.IO.FileMode.Open);
                long alldata = fs.Length;
                if (fs.Length > 44)
                {
                    byte[] buffer = new byte[44];
                    fs.Read(buffer, 0, 44);
                    long datanum = (long)System.BitConverter.ToInt32(buffer, 28);
                    s = Convert.ToInt32(alldata / datanum);
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch { }

            if (s == 0)
            {
                s++;
            }

            return s;
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

        #region【事件：DataGridView错误处理】

        private void dgv_Main_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strErr = e.Exception.Message;
            e.ThrowException = false;
        }

        #endregion

        private void dgv_Main_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dgv_Main.Width > 0)
                {
                    if (dgv_Main.DisplayedColumnCount(true) * 100 >= dgv_Main.Width)
                    {
                        dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        for (int i = 0; i < dgv_Main.Columns.Count; i++)
                        {
                            dgv_Main.Columns[i].Width = 100;
                        }
                    }
                    else
                    {
                        dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                else
                {
                    dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            this.AcceptButton = IB;
        }

        private void txt_RationEmpCount_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txt_RationEmpCount_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = IB;
        }

        //解除报警
        private void btnLaws_Click(object sender, EventArgs e)
        {
            if (intSelectModel == 14)//唯一性报警
            {
                if (dgv_Main.Rows.Count > 0)
                {
                    for (int i = dgv_Main.Rows.Count - 1; i >= 0; i--)
                    {
                        rtabll.UnchainRTOnlyone(dgv_Main.Rows[i].Cells["标识卡号"].Value.ToString(), dgv_Main.Rows[i].Cells["姓名"].Value.ToString());
                    }
                    Refresh_Onlyone();
                }
                else
                    MessageBox.Show("没有唯一性报警信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txt_EmpHelp_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_CheckCards_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txtName_InWellValidate_KeyPress(object sender, KeyPressEventArgs e)
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

        #region【Czlt-2011-10-07 声音报警设置 】
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            IsCheckAlarm();
        }

        private void SelctText(bool isTrue)
        {
            if (isTrue)
            {
                //btnSelectAll.Text = "静音";
                btnSelectAll.Text = "报警";

            }
            else
            {
                // btnSelectAll.Text = "报警";
                btnSelectAll.Text = "静音";
            }
        }

        private void IsCheckAlarm()
        {

            switch (intSelectModel)
            {
                //超员
                case 1:
                    SelctText(IsAlarmFull[0]);
                    if (IsAlarmFull[0])
                    {
                        //btnSelectAll.Text = "静音";
                        IsAlarmFull[0] = false;
                    }
                    else
                    {
                        //btnSelectAll.Text = "报警";
                        IsAlarmFull[0] = true;

                    }

                    break;
                //超时
                case 2:
                    SelctText(IsAlarmFull[1]);
                    if (IsAlarmFull[1])
                    {
                        //btnSelectAll.Text = "静音";
                        IsAlarmFull[1] = false;
                    }
                    else
                    {
                        //btnSelectAll.Text = "报警";
                        IsAlarmFull[1] = true;

                    }
                    break;

                //区域报警
                case 3:
                    SelctText(IsAlarmFull[2]);
                    if (IsAlarmFull[2])
                    {
                        // btnSelectAll.Text = "静音";
                        IsAlarmFull[2] = false;
                    }
                    else
                    {
                        // btnSelectAll.Text = "报警";
                        IsAlarmFull[2] = true;

                    }
                    break;

                //工作异常报警
                case 4:
                    SelctText(IsAlarmFull[3]);
                    if (IsAlarmFull[3])
                    {
                        // btnSelectAll.Text = "静音";
                        IsAlarmFull[3] = false;
                    }
                    else
                    {
                        // btnSelectAll.Text = "报警";
                        IsAlarmFull[3] = true;

                    }
                    break;

                //求救报警
                case 5:
                    SelctText(IsAlarmFull[4]);
                    if (IsAlarmFull[4])
                    {
                        // btnSelectAll.Text = "静音";
                        IsAlarmFull[4] = false;
                    }
                    else
                    {
                        // btnSelectAll.Text = "报警";
                        IsAlarmFull[4] = true;

                    }
                    break;

                //传输分站报警
                case 6:
                    SelctText(IsAlarmFull[5]);
                    if (IsAlarmFull[5])
                    {
                        //btnSelectAll.Text = "静音";
                        IsAlarmFull[5] = false;
                    }
                    else
                    {
                        //btnSelectAll.Text = "报警";
                        IsAlarmFull[5] = true;

                    }
                    break;

                //读卡分站报警
                case 7:
                    SelctText(IsAlarmFull[6]);
                    if (IsAlarmFull[6])
                    {
                        // btnSelectAll.Text = "静音";
                        IsAlarmFull[6] = false;
                    }
                    else
                    {
                        // btnSelectAll.Text = "报警";
                        IsAlarmFull[6] = true;
                    }
                    break;

                //低电量报警
                case 8:
                    SelctText(IsAlarmFull[7]);
                    if (IsAlarmFull[7])
                    {
                        //btnSelectAll.Text = "静音";
                        IsAlarmFull[7] = false;
                    }
                    else
                    {
                        //btnSelectAll.Text = "报警";
                        IsAlarmFull[7] = true;
                    }
                    break;

                //超速报警
                case 9:
                    SelctText(IsAlarmFull[8]);
                    if (IsAlarmFull[8])
                    {
                        //btnSelectAll.Text = "静音";
                        IsAlarmFull[8] = false;
                    }
                    else
                    {
                        //btnSelectAll.Text = "报警";
                        IsAlarmFull[8] = true;
                    }
                    break;

                //欠速报警
                case 10:
                    SelctText(IsAlarmFull[9]);
                    if (IsAlarmFull[9])
                    {
                        //  btnSelectAll.Text = "静音";
                        IsAlarmFull[9] = false;
                    }
                    else
                    {
                        // btnSelectAll.Text = "报警";
                        IsAlarmFull[9] = true;
                    }
                    break;

                //区域超时报警
                case 11:
                    SelctText(IsAlarmFull[10]);
                    if (IsAlarmFull[10])
                    {
                        // btnSelectAll.Text = "静音";
                        IsAlarmFull[10] = false;
                    }
                    else
                    {
                        //btnSelectAll.Text = "报警";
                        IsAlarmFull[10] = true;
                    }
                    break;

                //区域超员报警
                case 12:
                    SelctText(IsAlarmFull[11]);
                    if (IsAlarmFull[11])
                    {
                        // btnSelectAll.Text = "静音";
                        IsAlarmFull[11] = false;
                    }
                    else
                    {
                        // btnSelectAll.Text = "报警";
                        IsAlarmFull[11] = true;
                    }
                    break;

                //异地交接班报警
                case 13:
                    SelctText(IsAlarmFull[12]);
                    if (IsAlarmFull[12])
                    {
                        // btnSelectAll.Text = "静音";
                        IsAlarmFull[12] = false;
                    }
                    else
                    {
                        //btnSelectAll.Text = "报警";
                        IsAlarmFull[12] = true;
                    }
                    break;

                //唯一性报警
                case 14:
                    SelctText(IsAlarmFull[13]);
                    if (IsAlarmFull[13])
                    {
                        // btnSelectAll.Text = "静音";
                        IsAlarmFull[13] = false;
                    }
                    else
                    {
                        //btnSelectAll.Text = "报警";
                        IsAlarmFull[13] = true;
                    }
                    break;

                //下井人员验证报警
                case 15:
                    SelctText(IsAlarmFull[14]);
                    if (IsAlarmFull[14])
                    {
                        //btnSelectAll.Text = "静音";
                        IsAlarmFull[14] = false;
                    }
                    else
                    {
                        // btnSelectAll.Text = "报警";
                        IsAlarmFull[14] = true;
                    }
                    break;

                //传输分站供电报警
                case 16:
                    SelctText(IsAlarmFull[15]);
                    if (IsAlarmFull[15])
                    {
                        // btnSelectAll.Text = "静音";
                        IsAlarmFull[15] = false;
                    }
                    else
                    {
                        // btnSelectAll.Text = "报警";
                        IsAlarmFull[15] = true;
                    }
                    break;

                //交换机供电报警
                case 17:
                    SelctText(IsAlarmFull[16]);
                    if (IsAlarmFull[16])
                    {
                        //btnSelectAll.Text = "静音";
                        IsAlarmFull[16] = false;
                    }
                    else
                    {
                        // btnSelectAll.Text = "报警";
                        IsAlarmFull[16] = true;
                    }
                    break;
            }
        }
        #endregion

        #region 【Czlt-2011-05-25 交直流供电】

        #region 【Czlt-2011-05-25 - 传输分站供电情况】
        /// <summary>
        /// 查询传输分站交直流供电情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStaEle_Click(object sender, EventArgs e)
        {
            //  dmc_Info.ButtonClick(pl_Station.Name);
            dmc_Info.ButtonClick(panStaEle.Name);
            trViewStaEle.Nodes.Clear();
            LoadTree(16);

            lblMainTitle.Text = "传输分站供电报警";
            this.btnPrint.Text = "打印";
            intSelectModel = 16;
            Refresh_StaEle(); //刷新分站

            SelctText(!IsAlarmFull[15]);

        }

        private void Refresh_StaEle()
        {
            LoadTree(16); //加载传输分站树

            Select_StationEle();//查询传输分站具体的查询信息
        }

        private void Select_StationEle()
        {
            using (ds = new DataSet())
            {
                ds = rtabll.GetStationEle(strEleWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgv_Main.Columns.Clear();
                    ds.Tables[0].TableName = "A_FrmRTAlarm_StationEle";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";
                    //dgv_Main.Columns["开始时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    //dgv_Main.Columns["操作"].Visible = false;
                    //if (dgv_Main.Columns.Count >= 4)
                    //{
                    //    dgv_Main.Columns["分站编号"].DisplayIndex = 0;
                    //    dgv_Main.Columns["分站位置"].DisplayIndex = 1;
                    //    dgv_Main.Columns["分站联系电话"].DisplayIndex = 2;
                    //    dgv_Main.Columns["故障开始时间"].DisplayIndex = 3;
                    //}
                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                }
            }

        }


        private void trViewStaEle_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strEleWhere = " 1=1 ";
            if (trViewStaEle.SelectedNode != null && !trViewStaEle.SelectedNode.Name.Equals("0"))
            {
                strEleWhere += " And StationAddress = " + trViewStaEle.SelectedNode.Name;
            }

            Select_StationEle();

        }

        #endregion

        #region 【Czlt-2011-05-26 串口服务供电】
        private void btnJHJEle_Click(object sender, EventArgs e)
        {
            dmc_Info.ButtonClick(panJHJEle.Name);
            trvJHJTree.Nodes.Clear();
            LoadTree(17);
            lblMainTitle.Text = "交换机供电报警";

            intSelectModel = 17;
            this.btnPrint.Text = "打印";
            Refresh_JhjEle();

            SelctText(!IsAlarmFull[16]);


        }

        private void Refresh_JhjEle()
        {
            LoadTree(17); //加载传输分站树
            strEleWhere = " 1=1 ";
            Select_JHJEle();//查询传输分站具体的查询信息
        }

        private void Select_JHJEle()
        {
            using (ds = new DataSet())
            {
                if (trViewStaEle.SelectedNode != null && !trViewStaEle.SelectedNode.Name.Equals("0"))
                {
                    strEleWhere += " And StationAddress = " + trViewStaEle.SelectedNode.Name;
                    ds = rtabll.GetJHJEle(strEleWhere, 1);
                }
                else
                {
                    ds = rtabll.GetJHJEle(strEleWhere, 0);

                }


                if (ds != null && ds.Tables.Count > 0)
                {
                    dgv_Main.Columns.Clear();
                    ds.Tables[0].TableName = "A_FrmRTAlarm_JHJEle";
                    dgv_Main.DataSource = ds.Tables[0];

                    lblCounts.Text = "共 " + ds.Tables[0].Rows.Count + " 个报警记录";

                }
                else
                {
                    dgv_Main.DataSource = null;
                    lblCounts.Text = "共 0 个报警记录";
                }
            }

        }

        private void trvJHJTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strEleWhere = " 1=1 ";


            Select_JHJEle();

        }

        #endregion

       
        #endregion

        

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, "实时报警信息");
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, "实时报警信息", "");
        }


        #region【Czlt-2011-10-10 主机分站配置信息备份到备机上】
        private void CzltUpdateXml()
        {
            string configPath = Application.StartupPath + @"\HostIPConfig.xml";

            XmlDocument docConfig = new XmlDocument();
            docConfig.Load(configPath);
            string isHost = docConfig.ChildNodes[1].ChildNodes[0].ChildNodes[1].InnerText;
            if (isHost.ToUpper() == "TRUE")
            {
                ConfigXmlWiter.Write("Station.xml");
                ConfigXmlWiter.Write("StationHead.xml");
                ConfigXmlWiter.Write("Employees.xml");
                ConfigXmlWiter.Write("CodeSender.xml");
                ConfigXmlWiter.Write("Class.xml");
                ConfigXmlWiter.Write("Factory.xml");
                ConfigXmlWiter.Write("AlarmSet.xml");
                ConfigXmlWiter.Write("Directional.xml");
                ConfigXmlWiter.Write("EnumTable.xml");
                ConfigXmlWiter.Write("Holiday.xml");
                ConfigXmlWiter.Write("Picture.xml");
                ConfigXmlWiter.Write("OverSpeed.xml");
                ConfigXmlWiter.Write("Power.xml");
                ConfigXmlWiter.Write("TCPIP.xml");
                ConfigXmlWiter.Write("Territorial.xml");
            }
        }
        #endregion



    }
}
