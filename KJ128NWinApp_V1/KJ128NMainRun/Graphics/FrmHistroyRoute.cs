using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using KJ128NDBTable;
using System.Threading;
using KJ128NModel;

namespace KJ128NMainRun.Graphics
{
    public partial class FrmHistroyRoute : Wilson.Controls.Docking.DockContent
    {
        #region[声明]
        /// <summary>
        /// 弹出边框是否弹出
        /// </summary>
        private bool IsOut = false;
        /// <summary>
        /// 地图路径
        /// </summary>
        private string MapFilePath;
        /// <summary>
        /// 分站图片路径
        /// </summary>
        private string StationFilePath;
        /// <summary>
        /// 移动者正向移动图片路径
        /// </summary>
        private string MoverZFilePath;
        /// <summary>
        /// 移动者反向移动图片路径
        /// </summary>
        private string MoverFFilePath;
        /// <summary>
        /// 雇员表
        /// </summary>
        private DataTable EmpDt;
        /// <summary>
        /// 已选中的移动者列表
        /// </summary>
        private List<EmpMoverModel> EmpMoverList = new List<EmpMoverModel>();
        /// <summary>
        /// 部门表
        /// </summary>
        private DataTable BanDeptDt;
        /// <summary>
        /// 当前选中的部门ID
        /// </summary>
        private string Bandeptid;
        /// <summary>
        /// 当前选中的部门班次表
        /// </summary>
        private DataTable classdt;
        /// <summary>
        /// 当前选中日期中所有班次所涉及的雇员表
        /// </summary>
        private DataTable classempdt;
        /// <summary>
        /// 雇员零时表
        /// </summary>
        private DataTable EmpDtBuffer;
        /// <summary>
        /// 当前图形系统是否已配置完成
        /// </summary>
        private bool isConfiged = true;
        /// <summary>
        /// 没有历史轨迹的人员列表
        /// </summary>
        List<string> NoRoutePeoples = new List<string>();
        /// <summary>
        /// 历史路径生成线程
        /// </summary>
        Thread HistoryThread;
        /// <summary>
        /// 选项卡INDEX
        /// </summary>
        private int PageIndex = 0;
        #endregion

        #region[初始化]
        public FrmHistroyRoute()
        {
            InitializeComponent();
        }
        #endregion

        #region[事件]
        /// <summary>
        /// 弹出窗体单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picInOut_Click(object sender, EventArgs e)
        {
            if (IsOut)
            {
                this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.right;
                this.pnlInOut.Left = this.pnlInOut.Left - this.tbcControl.Width;
                IsOut = false;
            }
            else
            {
                this.picInOut.Image = global::KJ128NMainRun.Properties.Resources.left;
                this.pnlInOut.Left = this.pnlInOut.Left + this.tbcControl.Width;
                IsOut = true;
            }
        }

        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHistroyRoute_Load(object sender, EventArgs e)
        {
            try
            {
                dtpStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                LoadGisMapInfo();
                if (System.IO.File.Exists(MapFilePath))
                {
                    this.MapGis.MapFilePath = MapFilePath;
                    this.MapGis.StationFilePath = StationFilePath;
                }
                else
                {
                    MessageBox.Show("您所配置的图形已经失效,请重新配置后使用..", "提示", MessageBoxButtons.OK);
                    return;
                }
                //this.MapGis.UseGif = true;
                DataTable stationinfodt = new Graphics_StationInfoBLL().GetStationInfo();
                if (stationinfodt != null && stationinfodt.Rows.Count > 0)
                {
                    for (int i = 0; i < stationinfodt.Rows.Count; i++)
                    {
                        string stationID = stationinfodt.Rows[i][0].ToString() + "." + stationinfodt.Rows[i][1].ToString();
                        string stationName = stationinfodt.Rows[i][2].ToString();
                        float stationheadx = float.Parse(stationinfodt.Rows[i][3].ToString());
                        float stationheady = float.Parse(stationinfodt.Rows[i][4].ToString());
                        if (StationFilePath != null && StationFilePath != "")
                            this.MapGis.AddStation(stationheadx, stationheady, stationName, stationID,"正常", new Bitmap(StationFilePath));
                    }
                    this.MapGis.FalshStations();
                }
                BanDeptDt = new Graphics_RealTimeBLL().GetAllDept();
                if (BanDeptDt != null && BanDeptDt.Rows.Count > 0)
                {
                    cmbDept.Items.Add("全部部门");
                    cmbDept.SelectedIndex = 0;
                    for (int i = 0; i < BanDeptDt.Rows.Count; i++)
                    {
                        cmbDept.Items.Add(BanDeptDt.Rows[i][0]);
                    }
                    for (int i = 0; i < BanDeptDt.Rows.Count; i++)
                    {
                        cmbBanDept.Items.Add(BanDeptDt.Rows[i][0]);
                    }
                    cmbBanDept.SelectedIndex = 0;
                    cmbSpeed.SelectedIndex = 0;
                }
                this.MapGis.MoveEnded += new ZzhaControlLibrary.ZzhaMapGis.MoveingEnd(MapGis_MoveEnded);
                EmpDt = new Graphics_RealTimeBLL().GetAllEmp();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("您所配置的图形已经失效,请重新配置后使用..", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 载入图形配置信息
        /// </summary>
        private void LoadGisMapInfo()
        {
            XmlDocument xmldoc = new XmlDocument();
            if (System.IO.File.Exists(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml"))
            {
                xmldoc.Load(Application.StartupPath + "\\MapGis\\GraphicsConfig.xml");
            }
            else
            {
                MessageBox.Show("图形图形尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
                isConfiged = false;
                return;
            }
            if (xmldoc.SelectSingleNode("//底图").InnerText == null || xmldoc.SelectSingleNode("//底图").InnerText == "")
            {
                MessageBox.Show("图形图形尚未配置完成,请配置后再使用!", "提示", MessageBoxButtons.OK);
                isConfiged = false;
                return;
            }
            else
            {
                MapFilePath = Application.StartupPath + "\\MapGis\\Map\\" + xmldoc.SelectSingleNode("//底图").InnerText;
            }
            StationFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Signal.gif";
            MoverZFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Zg.GIF";
            MoverFFilePath = Application.StartupPath + "\\MapGis\\ShineImage\\Fg.GIF";
        }

        /// <summary>
        /// MAPGIS中移动结束事件
        /// </summary>
        void MapGis_MoveEnded()
        {
            if (MapGis.IsMoving)
                this.btnHistoryRoute.Enabled = false;
            else
                this.btnHistoryRoute.Enabled = true;
        }

        /// <summary>
        /// 部门下拉列表框选择项发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlashPeople();
        }

        /// <summary>
        /// 重新载入雇员进listbox中，按所选择的部门及已经选中的移动者
        /// </summary>
        private void FlashPeople()
        {
            string deptname = cmbDept.SelectedItem.ToString();
            if (deptname != "")
            {
                if (deptname == "全部部门")
                {
                    EmpDtBuffer = new Graphics_RealTimeBLL().GetAllEmp();
                }
                else
                {
                    EmpDtBuffer = new Graphics_RealTimeBLL().GetEmpByDeptName(deptname);
                }
                this.lsbPeople.Items.Clear();
                this.lsbPeople.Values.Clear();
                for (int i = 0; i < EmpDtBuffer.Rows.Count; i++)
                {
                    string item = EmpDtBuffer.Rows[i][0].ToString();
                    string value = EmpDtBuffer.Rows[i][1].ToString();
                    lsbPeople.AddItem(EmpDtBuffer.Rows[i][0].ToString(), EmpDtBuffer.Rows[i][1].ToString());
                }
                for (int i = 0; i < lsbSelectPeople.Items.Count; i++)
                {
                    if (lsbPeople.Values.Contains(lsbSelectPeople.Values[i]))
                    {                        
                        lsbPeople.Items.RemoveAt(lsbPeople.Values.IndexOf(lsbSelectPeople.Values[i]));
                        lsbPeople.Values.Remove(lsbSelectPeople.Values[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 选择雇员进移动者列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lsbSelectPeople.Items.Count < 10)
            {
                if (lsbPeople.SelectedItem != null)
                {
                    if (lsbPeople.SelectedItems.Count > 0)
                    {
                        for (int i = lsbPeople.SelectedItems.Count; i > 0; i--)
                        {
                            if (lsbSelectPeople.Items.Count < 10)
                            {
                                int index = lsbPeople.SelectedIndex;
                                EmpMoverList.Add(new EmpMoverModel(lsbPeople.SelectedItem.ToString(), lsbPeople.SelectedValue));
                                lsbSelectPeople.AddItem(lsbPeople.SelectedItem.ToString(), lsbPeople.SelectedValue);
                                lsbPeople.Values.Remove(lsbPeople.SelectedValue);
                                lsbPeople.Items.RemoveAt(lsbPeople.SelectedIndex);
                                lsbPeople.SelectedIndex = index > (lsbPeople.Items.Count - 1) ? lsbPeople.Items.Count - 1 : index;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 从移动者列表删除雇员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsbSelectPeople.SelectedItem != null)
            {
                if (lsbSelectPeople.SelectedItems.Count > 0)
                {
                    for (int j = lsbSelectPeople.SelectedItems.Count; j > 0; j--)
                    {
                        //for (int i = 0; i < EmpDt.Rows.Count; i++)
                        //{
                        //    if (EmpDt.Rows[i][0].ToString() == lsbSelectPeople.SelectedItem.ToString())
                        //    {
                        //        //EmpHashTable.Remove(lsbSelectPeople.SelectedItem.ToString());
                                
                        //        break;
                        //    }
                        //}
                        RemoveList(new EmpMoverModel(lsbSelectPeople.SelectedItem.ToString(), lsbSelectPeople.SelectedValue));
                        int index = lsbSelectPeople.SelectedIndex;
                        lsbSelectPeople.Values.Remove(lsbSelectPeople.SelectedValue);
                        lsbSelectPeople.Items.RemoveAt(lsbSelectPeople.SelectedIndex);
                        FlashPeople();
                        lsbSelectPeople.SelectedIndex = index > (lsbSelectPeople.Items.Count - 1) ? lsbSelectPeople.Items.Count - 1 : index;
                    }
                }
            }
        }

        /// <summary>
        /// 从移动者列表中删除雇员
        /// </summary>
        /// <param name="emp">要删除的雇员类</param>
        private void RemoveList(EmpMoverModel emp)
        {
            foreach (EmpMoverModel empm in EmpMoverList)
            {
                if (empm.EmpID == emp.EmpID && empm.EmpName == emp.EmpName)
                {
                    EmpMoverList.Remove(empm);
                    break;
                }
            }
        }

        /// <summary>
        /// 委托  开始移动
        /// </summary>
        private delegate void StartMoving();
        /// <summary>
        /// 开始移动方法  线程安全
        /// </summary>
        private void MapgisStartMoving()
        {
            if (MapGis.InvokeRequired)
            {
                MapGis.Invoke(new StartMoving(MapGis.StartMoving));
            }
            else
            {
                MapGis.StartMoving();
            }
        }

        /// <summary>
        /// 设置历史轨迹按钮可用与不可用
        /// </summary>
        /// <param name="value">true为可用，false为不可用</param>
        private void SetHBtnEnabel(bool value)
        {
            this.btnHistoryRoute.Enabled = value;
        }
        /// <summary>
        /// 委托 设置历史轨迹按钮可用与不可用
        /// </summary>
        /// <param name="value">true为可用，false为不可用</param>
        private delegate void SetBtnEnabel(bool value);
        /// <summary>
        /// 设置历史轨迹按钮可用与不可用 线程安全 
        /// </summary>
        /// <param name="value">true为可用，false为不可用</param>
        private void SetHistoryBtnEnabel(bool value)
        {
            if (btnHistoryRoute.InvokeRequired)
            {
                btnHistoryRoute.Invoke(new SetBtnEnabel(SetHBtnEnabel), new object[] { value});
            }
            else
            {
                SetHBtnEnabel(value);
            }
        }

        /// <summary>
        /// 线程运行  生成轨迹
        /// </summary>
        private void ThreadRun()
        {
            try
            {
                SetHistoryBtnEnabel(false);
                int step = 100 / EmpMoverList.Count;
                frmWait f = new frmWait("正在生成历史轨迹,请稍候....");
                f.Show();
                if (this.PageIndex == 0)
                {
                    #region[时间选择]
                    try
                    {
                        foreach (EmpMoverModel emm in EmpMoverList)
                        {
                            f.Refresh();
                            List<string> list = new Graphics_RealTimeBLL().GetRouteInfoByEmpID(emm.EmpID, dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            if (list != null && list.Count >= 5)
                                this.MapGis.AddMover(list[0], list[1], list[2], list[3], list[4], MoverZFilePath, MoverFFilePath);
                            else
                                NoRoutePeoples.Add(emm.EmpName);
                            f.PgbWait.Value += step;
                        }
                        if (NoRoutePeoples.Count == 0 && EmpMoverList.Count != 0)
                        {
                            //this.MapGis.StartMoving();
                            //this.btnHistoryRoute.Enabled = false;
                            MapgisStartMoving();
                        }
                        else
                        {
                            if (NoRoutePeoples.Count == EmpMoverList.Count)
                            {
                                MessageBox.Show("选择的人员均没有可播放的历史轨迹!", "提示", MessageBoxButtons.OK);
                                SetHistoryBtnEnabel(true);
                            }
                            else
                            {
                                string message = string.Empty;
                                for (int i = 0; i < NoRoutePeoples.Count; i++)
                                {
                                    if (i == 0)
                                        message = NoRoutePeoples[i];
                                    else
                                        message = message + "," + NoRoutePeoples[i];
                                }
                                if (message.Length > 0)
                                    message.Remove(message.Length - 2);
                                MessageBox.Show(message + "等人员没有可播放的历史轨迹!", "提示", MessageBoxButtons.OK);
                                MapgisStartMoving();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("路径尚未配置,或者配置的路径不符合要求,请检查...", "提示", MessageBoxButtons.OK);
                        SetHistoryBtnEnabel(true);
                    }
                    #endregion
                }
                else
                {
                    #region[班次选择]
                    try
                    {
                        foreach (EmpMoverModel emm in EmpMoverList)
                        {
                            f.Refresh();
                            List<string> list = new Graphics_RealTimeBLL().GetRouteInfoByEmpID(emm.EmpID, dtpban.Value.ToString("yyyy-MM-dd 00:00:00"), dtpban.Value.ToString("yyyy-MM-dd 23:59:59"));
                            if (list != null && list.Count >= 5)
                                this.MapGis.AddMover(list[0], list[1], list[2], list[3], list[4], MoverZFilePath, MoverFFilePath);
                            else
                                NoRoutePeoples.Add(emm.EmpName);
                            f.PgbWait.Value += step;
                        }
                        if (NoRoutePeoples.Count == 0)
                        {
                            MapgisStartMoving();
                        }
                        else
                        {
                            if (NoRoutePeoples.Count == EmpMoverList.Count)
                            {
                                MessageBox.Show("选择的所有人员均没有可播放的历史轨迹!", "提示", MessageBoxButtons.OK);
                                SetHistoryBtnEnabel(true);
                            }
                            else
                            {
                                string message = string.Empty;
                                foreach (string str in NoRoutePeoples)
                                {
                                    message = message + str + ",";
                                }
                                if (message.Length > 0)
                                    message.Remove(message.Length - 1);
                                MessageBox.Show(message + "等人员没有可播放的历史轨迹!", "提示", MessageBoxButtons.OK);
                                MapgisStartMoving();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("路径尚未配置,或者配置的路径不符合要求,请检查...", "提示", MessageBoxButtons.OK);
                        SetHistoryBtnEnabel(true);
                    }
                    #endregion
                }
                f.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("历史轨迹生成失败!", "提示", MessageBoxButtons.OK);
                SetHistoryBtnEnabel(true);
            }
            finally
            {                
                NoRoutePeoples.Clear();
                Thread.CurrentThread.Abort();
            }
        }
        /// <summary>
        /// 历史轨迹按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoryRoute_Click(object sender, EventArgs e)
        {
            if (isConfiged)
            {
                if (EmpMoverList.Count > 0)
                {
                    HistoryThread = new Thread(new ThreadStart(this.ThreadRun));
                    HistoryThread.Start();
                }
                else
                {
                    MessageBox.Show("请先选择人员!", "提示", MessageBoxButtons.OK);
                }
            }
        }
        /// <summary>
        /// 速度变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZzhaControlLibrary.ZzhaMapGis.Speed = Convert.ToInt32(this.cmbSpeed.SelectedItem);
        }
        /// <summary>
        /// 班次 部门选择项变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBanDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bandeptid = BanDeptDt.Rows[cmbBanDept.SelectedIndex][1].ToString();
            classdt = new Graphics_RealTimeBLL().GetClassByDeptID(Bandeptid);
            if (classdt != null && classdt.Rows.Count > 0)
            {
                cmbBan.Items.Clear();
                for (int i = 0; i < classdt.Rows.Count; i++)
                {
                    cmbBan.Items.Add(classdt.Rows[i][0].ToString());
                }
                cmbBan.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 班次 班次发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            BanFlashPeople();
        }
        /// <summary>
        /// 班次 重新载入雇员 根据班次及部门
        /// </summary>
        private void BanFlashPeople()
        {
            DataTable dt = null;
            lsbBanPeople.Items.Clear();
            lsbBanPeople.Values.Clear();
            DataSet ds = new Graphics_RealTimeBLL().GetEmpByDeptAndClass(int.Parse(Bandeptid), dtpban.Value, classdt.Rows[cmbBan.SelectedIndex][1].ToString());
            if (ds != null)
                classempdt = ds.Tables[0];
            classempdt = DistinctDataTable(classempdt, 0);
            for (int i = 0; i < classempdt.Rows.Count; i++)
            {
                lsbBanPeople.AddItem(classempdt.Rows[i]["EmployeeName"].ToString(), classempdt.Rows[i]["EmployeeId"].ToString());
            }
            for (int i = 0; i < lsbBanSelectpeople.Items.Count; i++)
            {
                if (lsbBanPeople.Values.Contains(lsbBanSelectpeople.Values[i]))
                {                    
                    lsbBanPeople.Items.RemoveAt(lsbBanPeople.Values.IndexOf(lsbBanSelectpeople.Values[i]));
                    lsbBanPeople.Values.Remove(lsbBanSelectpeople.Values[i]);
                }
            }
        }

        private DataTable DistinctDataTable(DataTable dt, int index)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i][index].ToString().Trim();
                if (ht.Contains(dt.Rows[i][index].ToString().Trim()))
                {
                    dt.Rows.RemoveAt(i);
                    i--;
                }
                else
                {
                    ht.Add(dt.Rows[i][index].ToString().Trim(), 1);
                }
            }
            return dt;
        }
        /// <summary>
        /// 班次 选择雇员进移动者表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBanselect_Click(object sender, EventArgs e)
        {
            if (lsbBanSelectpeople.Items.Count < 10)
            {
                if (lsbBanPeople.SelectedItems.Count>0)
                {
                    for (int j = lsbBanPeople.SelectedItems.Count; j > 0; j--)
                    {
                        if (lsbBanSelectpeople.Items.Count < 10)
                        {
                            string empid = string.Empty;
                            for (int i = 0; i < EmpDt.Rows.Count; i++)
                            {
                                if (EmpDt.Rows[i][0].ToString() == lsbBanPeople.SelectedItem.ToString())
                                {
                                    empid = EmpDt.Rows[i][1].ToString();
                                    break;
                                }
                            }
                            if (empid == "")
                            {
                                for (int i = 0; i < classempdt.Rows.Count; i++)
                                {
                                    if (classempdt.Rows[i]["EmployeeName"].ToString() == lsbBanPeople.SelectedItem.ToString())
                                    {
                                        empid = classempdt.Rows[i]["EmployeeId"].ToString();
                                        break;
                                    }
                                }
                                MessageBox.Show("该员工已离职,运动轨迹中将不显示该员工的部门信息!", "提示", MessageBoxButtons.OK);
                            }
                            int index = lsbBanPeople.SelectedIndex;
                            EmpMoverList.Add(new EmpMoverModel(lsbBanPeople.SelectedItem.ToString(), empid));
                            lsbBanSelectpeople.AddItem(lsbBanPeople.SelectedItem.ToString(), empid);
                            lsbBanPeople.Values.Remove(lsbBanPeople.SelectedValue);
                            lsbBanPeople.Items.RemoveAt(lsbBanPeople.SelectedIndex);
                            if (index > lsbBanPeople.Items.Count - 1)
                                lsbBanPeople.SelectedIndex = lsbBanPeople.Items.Count - 1;
                            else
                                lsbBanPeople.SelectedIndex = index;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 班次 从移动者表中移除雇员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBanremove_Click(object sender, EventArgs e)
        {
            if (lsbBanSelectpeople.SelectedItem != null)
            {
                if (lsbBanSelectpeople.SelectedItems.Count > 0)
                {
                    for (int j = lsbBanSelectpeople.SelectedItems.Count; j>0; j--)
                    {
                        //for (int i = 0; i < EmpDt.Rows.Count; i++)
                        //{
                        //    if (EmpDt.Rows[i][0].ToString() == lsbBanSelectpeople.SelectedItem.ToString())
                        //    {
                        //        //EmpMoverList.Remove(EmpMoverList.Find(new EmpMoverModel(lsbBanSelectpeople.SelectedItem.ToString(), lsbBanSelectpeople.SelectedValue)));
                                
                        //        break;
                        //    }
                        //}
                        RemoveList(new EmpMoverModel(lsbBanSelectpeople.SelectedItem.ToString(), lsbBanSelectpeople.SelectedValue));
                        int index = lsbBanSelectpeople.SelectedIndex;
                        lsbBanSelectpeople.Values.Remove(lsbBanSelectpeople.SelectedValue);
                        lsbBanSelectpeople.Items.RemoveAt(lsbBanSelectpeople.SelectedIndex);
                        BanFlashPeople();
                        if (index > lsbBanSelectpeople.Items.Count - 1)
                            lsbBanSelectpeople.SelectedIndex = lsbBanSelectpeople.Items.Count - 1;
                        else
                            lsbBanSelectpeople.SelectedIndex = index;
                    }
                }
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHistroyRoute_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.HistoryThread!=null && this.HistoryThread.ThreadState == ThreadState.Running)
            {
                HistoryThread.Abort();
            }
        }

        /// <summary>
        /// 选项卡变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbcControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PageIndex = tbcControl.SelectedIndex;
            EmpMoverList.Clear();
            if (PageIndex == 0)
            {
                for (int i = 0; i < lsbSelectPeople.Items.Count; i++)
                {
                    EmpMoverModel emm = new EmpMoverModel(lsbSelectPeople.Items[i].ToString(), lsbSelectPeople.Values[i]);
                    EmpMoverList.Add(emm);
                }
            }
            if (PageIndex == 1)
            {
                for (int i = 0; i < lsbBanSelectpeople.Items.Count; i++)
                {
                    EmpMoverModel emm = new EmpMoverModel(lsbBanSelectpeople.Items[i].ToString(), lsbBanSelectpeople.Values[i]);
                    EmpMoverList.Add(emm);
                }
            }
        }

        /// <summary>
        /// 结束轨迹播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (MapGis.IsMoving)
                {
                    this.MapGis.StopMoving();
                    this.btnHistoryRoute.Enabled = true;
                }
                else
                {
                    MessageBox.Show("当前并没有轨迹在播放中", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("当前并没有轨迹在播放中","提示",MessageBoxButtons.OK);
            }
        }

        #endregion

        private void labColor_Click(object sender, EventArgs e)
        {
            ColorDialog Cdlg = new ColorDialog();
            if (Cdlg.ShowDialog() == DialogResult.OK)
            {
                labColor.BackColor = Cdlg.Color;
                MapGis.MoverStrColor = Cdlg.Color;
                MapGis.FlashAll();
            }
        }

    }
}