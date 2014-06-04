using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using ZdcCommonLibrary;
using System.Text.RegularExpressions;
using Shine.Logs;
using KJ128NModel;
using Shine.Logs.LogType;
using Shine;
using KJ128WindowsLibrary;
using System.IO;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.EmployeeManage
{
    public partial class A_FrmEmpInfo : Wilson.Controls.Docking.DockContent
    {

        #region【声明】
        private A_AddEmpBLL aebll = new A_AddEmpBLL();

        /// <summary>
        /// 1:员工；2:部门；3:职务；4:工种；5:证书
        /// </summary>
        private int intSelectModel = 1;

        /// <summary>
        /// 查询条件
        /// </summary>
        private static string where;

        /// <summary>
        /// 每页条数
        /// </summary>
        private static int pSize = 40;

        /// <summary>
        /// 查询到记录的总页数
        /// </summary>
        private int countPage;


        /// <summary>
        /// 员工ID（-1表示增加，其余表示要修改的员工ID）

        /// </summary>
        public int tempEmpID=-1;

        /// <summary>
        /// 要修改员工的工种1 EmpWorkTypeID
        /// </summary>
        public int tempEmpWorkTypeID1 = 0;

        /// <summary>
        /// 修改时获取到的员工的照片ID，-1表示无

        /// </summary>
        public int tempEmpPhotoID = -1;

        /// <summary>
        /// 是否更新员工照片，true表示更新
        /// </summary>
        public bool isUpDatePhoto;

        private DataSet ds;

        /// <summary>
        /// 用于保存要修改的部门ID
        /// </summary>
        public int tempDept_ID;

        /// <summary>
        /// 用于保存要修改的职务ID
        /// </summary>
        public int tempDuty_ID;

        /// <summary>
        /// 用于保存要修改的工种ID
        /// </summary>
        public int tempWork_ID;

        /// <summary>
        /// 用于保存要修改的证书ID
        /// </summary>
        public int tempCer_ID;

        public bool blIsUpdate = false;

        /// <summary>
        /// 热备当前刷新次数
        /// </summary>
        private int intRefReshCount = 0;

        /// <summary>
        /// 热备刷新最大次数
        /// </summary>
        private int intHostBackRefCount = 2;

        private string strParentDeptID;

        #endregion

        #region【构造函数】

        public A_FrmEmpInfo()
        {
            InitializeComponent();

            intHostBackRefCount = RefReshTime.intHostBackRefCount;
            timer_Refresh.Interval = RefReshTime.intHostBackRefTime;

            dmc_Info.Add(pl_Emp,true);

            dmc_Info.Add(pl_Dept);

            dmc_Info.Add(pl_Duty);

            dmc_Info.Add(pl_WorkType);

            dmc_Info.Add(pl_Cer);

            dmc_Info.LeftPartResize();

            //加载员工信息
            LoadEmpInfo();

        }

        #endregion

        #region【窗体加载】


        private void A_FrmEmpInfo_Load(object sender, EventArgs e)
        {
            this.cmb_SelectCounts.Items.Add("全部");
            cmb_SelectCounts.Text = "40";
            LoadDept_Emp();         //加载部门——员工树

            LoadDuty_Emp();         //加载职务——员工树

            LoadWorkType_Emp();     //加载工种——员工树

            
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

        #region【方法：热备刷新】

        /// <summary>
        /// 热备刷新
        /// </summary>
        /// <param name="bl">true:开启刷新;false:终止刷新</param>
        public void HostBackRefresh(bool bl)
        {
            if (bl)
            {
                if (timer_Refresh.Enabled)
                {
                    timer_Refresh.Enabled = false;
                }
                intRefReshCount = 0;
                timer_Refresh.Enabled = true;
            }
            else
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
        }

        #endregion

        #region【方法：获取所有子部门的DeptID】

        private void GetAllDeptIDAndParentDeptID(string strDeptID)
        {
            using (ds = new DataSet())
            {
                ds = dbll.GetAllDeptIDAndParentDeptID();
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRow[] drT = ds.Tables[0].Select("ParentDeptID = " + strDeptID);
                    if (drT.Length > 0)
                    {
                        for (int i = 0; i < drT.Length; i++)
                        {
                            strParentDeptID += " Or DeptID = "+drT[i]["DeptID"].ToString();
                            GetAllDeptIDAndParentDeptID(drT[i]["DeptID"].ToString());
                        }
                    }
                }
            }
        }

        #endregion

        #region【事件：新增】

        private void bt_Add_Click(object sender, EventArgs e)
        {
            switch (intSelectModel)
            {
                case 1:

                    #region【人员】


                    //pl_AddEmpInfo.Visible = true;
                    tempEmpID = -1;
                    //GetEmpInfo_Add();
                    //bt_AddEmpSave.Enabled = bt_AddEmpReset.Enabled = groupBox1.Enabled = groupBox3.Enabled = groupBox4.Enabled = groupBox5.Enabled = groupBox6.Enabled = true;
                    //tbc_EmpInfo.SelectedTab = tbp_EmpBasic;
                    A_FrmEmpInfo_AddEmpInfo frmAei = new A_FrmEmpInfo_AddEmpInfo(this);
                    frmAei.ShowDialog();

                    #endregion

                    break;
                case 2:     

                    #region【部门】

                    tempDept_ID = -1;

                    A_FrmEmpInfo_AddDeptInfo frmAdi = new A_FrmEmpInfo_AddDeptInfo(this);
                    frmAdi.ShowDialog();

                    #endregion

                    break;
                case 3:

                    #region【职务】

                    tempDuty_ID = -1;

                    A_FrmEmpInfo_AddDutyInfo frmAdui = new A_FrmEmpInfo_AddDutyInfo(this);
                    frmAdui.ShowDialog();

                    #endregion

                    break;
                case 4:

                    #region【工种】

                    tempWork_ID= -1;

                    //GetWorkTypeInfo_Add();
                    A_FrmEmpInfo_AddWorkTypeInfo frmAwt = new A_FrmEmpInfo_AddWorkTypeInfo(this);
                    frmAwt.ShowDialog();

                    #endregion

                    break;
                case 5:

                    #region【证书】

                    tempCer_ID = -1;

                    A_FrmEmpInfo_AddCerInfo frmAdc = new A_FrmEmpInfo_AddCerInfo(this);
                    frmAdc.ShowDialog();

                    #endregion

                    break;
                default:
                    break;
            }
            
        }

        #endregion

        #region【事件：全部选择】


        private void bt_SelectAll_Click(object sender, EventArgs e)
        {
            if (bt_SelectAll.Text.Equals("全选"))
            {
                foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                {
                    dgvr.Cells["cl"].Value = 1;
                }
                bt_SelectAll.Text = "取消";
            }
            else
            {
                foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                {
                    dgvr.Cells["cl"].Value = 0;
                }
                bt_SelectAll.Text = "全选";
            }
        }

        #endregion

        #region【事件：修改】

        private void bt_Laws_Click(object sender, EventArgs e)
        {
            int i = 0;
            int intUpDateID = -1;
            blIsUpdate = true;
            switch (intSelectModel)
            {
                case 1:

                    #region【人员】


                    try
                    {
                        foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                        {
                            if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                            {
                                intUpDateID = Convert.ToInt32(dgvr.Cells["EmpID"].Value.ToString());
                                i += 1;
                            }
                        }
                    }
                    catch
                    {
                        intUpDateID = -1;
                        i = 0;
                    }
                    if (i == 0)
                    {
                        MessageBox.Show("请选择要修改的员工", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选员工不能大于1人，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        tempEmpID = intUpDateID;
                        //GetEmpInfo_Add();
                        //pl_AddEmpInfo.Visible = true;

                        //bt_AddEmpReset.Enabled = false;

                        //bt_AddEmpSave.Enabled = groupBox1.Enabled = groupBox3.Enabled = groupBox4.Enabled = groupBox5.Enabled = groupBox6.Enabled = true;
                        //tbc_EmpInfo.SelectedTab = tbp_EmpBasic;

                        A_FrmEmpInfo_AddEmpInfo frmAei = new A_FrmEmpInfo_AddEmpInfo(this);
                        frmAei.ShowDialog();
                    }

                    #endregion

                    break;
                case 2:

                    #region【部门】

                    try
                    {
                        foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                        {
                            if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                            {
                                intUpDateID = Convert.ToInt32(dgvr.Cells[7].Value.ToString());
                                i += 1;
                            }
                        }
                    }
                    catch
                    {
                        intUpDateID = -1;
                        i = 0;
                    }
                    if (i == 0)
                    {
                        MessageBox.Show("请选择要修改的部门", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选部门不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        tempDept_ID = intUpDateID;

                        A_FrmEmpInfo_AddDeptInfo frmAdi = new A_FrmEmpInfo_AddDeptInfo(this);
                        frmAdi.ShowDialog();
                    }

                    #endregion

                    break;
                case 3:

                    #region【职务】

                    try
                    {
                        foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                        {
                            if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                            {
                                intUpDateID = Convert.ToInt32(dgvr.Cells[4].Value.ToString());
                                i += 1;
                            }
                        }
                    }
                    catch
                    {
                        intUpDateID = -1;
                        i = 0;
                    }
                    if (i == 0)
                    {
                        MessageBox.Show("请选择要修改的职务", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选职务不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        tempDuty_ID = intUpDateID;

                        A_FrmEmpInfo_AddDutyInfo frmAdi = new A_FrmEmpInfo_AddDutyInfo(this);
                        frmAdi.ShowDialog();
                    }

                    #endregion

                    break;
                case 4:

                    #region【工种】

                    try
                    {
                        foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                        {
                            if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                            {
                                intUpDateID = Convert.ToInt32(dgvr.Cells[6].Value.ToString());
                                i += 1;
                            }
                        }
                    }
                    catch
                    {
                        intUpDateID = -1;
                        i = 0;
                    }
                    if (i == 0)
                    {
                        MessageBox.Show("请选择要修改的工种", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选工种不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        tempWork_ID = intUpDateID;
 
                        A_FrmEmpInfo_AddWorkTypeInfo frmAwt = new A_FrmEmpInfo_AddWorkTypeInfo(this);
                        frmAwt.ShowDialog();
                    }

                    #endregion

                    break;
                case 5:

                    #region【证书】

                    try
                    {
                        foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                        {
                            if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                            {
                                intUpDateID = Convert.ToInt32(dgvr.Cells[4].Value.ToString());
                                i += 1;
                            }
                        }
                    }
                    catch
                    {
                        intUpDateID = -1;
                        i = 0;
                    }
                    if (i == 0)
                    {
                        MessageBox.Show("请选择要修改的证书", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (i > 1)
                    {
                        MessageBox.Show("所选证书不能大于1个，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        tempCer_ID = intUpDateID;

                        A_FrmEmpInfo_AddCerInfo frmAdc = new A_FrmEmpInfo_AddCerInfo(this);
                        frmAdc.ShowDialog();
                    }

                    #endregion

                    break;
                default:
                    break;
            }
            
        }

        #endregion

        #region【事件：删除】

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            int intDeleteCount = 0;
            string strDeleteEmpID = "";
            string strDeleteUserID = "";
            string strDeleteNO = "";
            string strDeleteName = "";
            DialogResult result;
            switch (intSelectModel)
            {
                case 1:

                    #region【人员】


                    foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                    {
                        if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        {
                            intDeleteCount += 1;

                            if (strDeleteNO == "")
                            {
                                strDeleteEmpID = " EmpID = " + dgvr.Cells["EmpID"].Value.ToString();
                                strDeleteUserID = " UserID= " + dgvr.Cells["EmpID"].Value.ToString();
                                strDeleteNO = dgvr.Cells["编号"].Value.ToString();
                                strDeleteName = dgvr.Cells["姓名"].Value.ToString();
                            }
                            else
                            {
                                strDeleteEmpID += " Or EmpID = " + dgvr.Cells["EmpID"].Value.ToString();
                                strDeleteUserID += " Or UserID= " + dgvr.Cells["EmpID"].Value.ToString();
                                strDeleteNO += "，" + dgvr.Cells["编号"].Value.ToString();
                                strDeleteName += "，" + dgvr.Cells["姓名"].Value.ToString();
                            }
                        }
                    }

                    if (intDeleteCount == 0)
                    {
                        MessageBox.Show("请选择要删除的人员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    result = MessageBox.Show("是否要删除选中人员？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Yes)
                    {
                        aebll.DeleteEmp(strDeleteEmpID, strDeleteUserID);

                        dgv_Main.ClearSelection();
                        //存入日志
                        LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "删除员工档案，编号为：" + strDeleteNO + "，姓名为：" + strDeleteName);

                        //czlt-2011-12-19 星期一
                        aebll.UpdateTime();
                        //刷新
                        Refresh_Emp();
                    }

                    #endregion

                    break;
                case 2:

                    #region【部门】

                    foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                    {
                        if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        {
                            intDeleteCount += 1;

                            if (strDeleteNO == "")
                            {
                                strDeleteEmpID = " DeptID = " + dgvr.Cells[7].Value.ToString();

                                strDeleteNO = dgvr.Cells[1].Value.ToString();
                                strDeleteName = dgvr.Cells[2].Value.ToString();

                                strParentDeptID = " DeptID =" + dgvr.Cells[7].Value.ToString();
                                GetAllDeptIDAndParentDeptID(dgvr.Cells[7].Value.ToString());

                                strDeleteEmpID = strParentDeptID;
                            }
                            else
                            {
                                //strDeleteEmpID += " Or DeptID = " + dgvr.Cells[7].Value.ToString();
                                strDeleteNO += "，" + dgvr.Cells[1].Value.ToString();
                                strDeleteName += "，" + dgvr.Cells[2].Value.ToString();

                                strParentDeptID = " DeptID = " + dgvr.Cells[7].Value.ToString();
                                GetAllDeptIDAndParentDeptID(dgvr.Cells[7].Value.ToString());
                                strDeleteEmpID += " Or "+strParentDeptID;

                            }
                        }
                    }

                    if (intDeleteCount == 0)
                    {
                        MessageBox.Show("请选择要删除的部门！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    result = MessageBox.Show("删除该部门后其下级部门都将删除，并且会丢失绑定了该部门或绑定其下级部门的员工信息，是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Yes)
                    {
                        dbll.DeleteDept(strDeleteEmpID);

                        dgv_Main.ClearSelection();
                        //存入日志
                        LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "删除部门信息，编号为：" + strDeleteNO + "，名称为：" + strDeleteName);


                        //czlt-2011-12-19 星期一
                        aebll.UpdateTime();
                        //刷新
                        Refresh_Dept();

                    }
                    #endregion

                    break;
                case 3:

                    #region【职务】

                    foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                    {
                        if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        {
                            intDeleteCount += 1;

                            if (strDeleteName == "")
                            {
                                strDeleteEmpID =  dgvr.Cells[4].Value.ToString();

                                strDeleteName = dgvr.Cells[1].Value.ToString();
                            }
                            else
                            {
                                strDeleteEmpID += " Or DutyID = " + dgvr.Cells[4].Value.ToString();
                                strDeleteName += "，" + dgvr.Cells[1].Value.ToString();
                            }
                        }
                    }

                    if (intDeleteCount == 0)
                    {
                        MessageBox.Show("请选择要删除的职务！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    result = MessageBox.Show("是否要删除职务？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Yes)
                    {
                        dbll.DeleteDuty(strDeleteEmpID);

                        dgv_Main.ClearSelection();
                        //存入日志
                        LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "删除职务信息，名称为：" + strDeleteName);


                        //czlt-2011-12-19 星期一
                        aebll.UpdateTime();
                        //刷新
                        Refresh_Duty();

                    }

                    #endregion

                    break;
                case 4:
                    #region【工种】


                    foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                    {
                        if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        {
                            intDeleteCount += 1;

                            if (strDeleteName == "")
                            {
                                strDeleteEmpID = " WorkTypeID = " + dgvr.Cells[6].Value.ToString();

                                strDeleteName = dgvr.Cells[1].Value.ToString();
                            }
                            else
                            {
                                strDeleteEmpID += " Or WorkTypeID = " + dgvr.Cells[6].Value.ToString();
                                strDeleteName += "，" + dgvr.Cells[1].Value.ToString();
                            }
                        }
                    }

                    if (intDeleteCount == 0)
                    {
                        MessageBox.Show("请选择要删除的工种！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    result = MessageBox.Show("是否删除要工种？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Yes)
                    {

                        dbll.DeleteWork(strDeleteEmpID);

                        dgv_Main.ClearSelection();
                        //存入日志
                        LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "删除工种信息，名称为：" + strDeleteName);


                        //czlt-2011-12-19 星期一
                        aebll.UpdateTime();
                        //刷新
                        Refresh_WorkType();

                    }

                    #endregion

                    break;
                case 5:

                    #region【证书】


                    foreach (DataGridViewRow dgvr in dgv_Main.Rows)
                    {
                        if (dgvr.Cells["cl"].Value != null && int.Parse(dgvr.Cells["cl"].Value.ToString()) == 1)
                        {
                            intDeleteCount += 1;

                            if (strDeleteName == "")
                            {
                                strDeleteEmpID = " CerTypeID = " + dgvr.Cells[4].Value.ToString();

                                strDeleteName = dgvr.Cells[1].Value.ToString();
                            }
                            else
                            {
                                strDeleteEmpID += " Or CerTypeID = " + dgvr.Cells[4].Value.ToString();
                                strDeleteName += "，" + dgvr.Cells[1].Value.ToString();
                            }
                        }
                    }

                    if (intDeleteCount == 0)
                    {
                        MessageBox.Show("请选择要删除的证书！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    //删除证书将会丢失与证书相关的工种信息，是否删除？
                    result = MessageBox.Show("删除证书将会丢失与该证书相关的工种信息，是否删除？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Yes)
                    {
                        dbll.DeleteCertificate(strDeleteEmpID);

                        dgv_Main.ClearSelection();
                        //存入日志
                        LogSave.Messages("[A_FrmEmpInfo]", LogIDType.UserLogID, "删除证书信息，名称为：" + strDeleteName);


                        //czlt-2011-12-19 星期一
                        aebll.UpdateTime();
                        //刷新
                        Refresh_Cer();

                    }

                    #endregion

                    break;
                default:
                    break;
            }

        }

        #endregion

        

        #region【事件：双击单元格（查看具体信息）】

        private void dgv_Main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            blIsUpdate = false;
            try
            {
                switch (intSelectModel)
                {
                    case 1:

                        #region【人员】

                        //bcp_EmpTitle.CaptionTitle = "查看员工信息";
                        //lb_EmpTipsInfo.Visible = false;     //隐藏提示信息

                        //aebll.GetDeptNameCmb(comboBox_EmployeeDepartment);              //初始化部门名词(comboBox)
                        //aebll.GetDutyNameCmb(combobox_EmployeeDuty, false);             //初始化职务名称(comboBox)
                        //aebll.GetWorkTypeCmb(comboBox_EmpWorkTypeName);                 //初始化工种名称(comboBox)
                        //comboBox_EmployeeSex.DataSource = aebll.GetEmpSexTab();         //初始化性别(comboBox)
                        //comboBox_EmployeeClan.DataSource = aebll.GetEmpClanTab();       //初始化政治面貌(comboBox)
                        //comboBox_EmployeeWedlock.DataSource = aebll.GetEmpWedlockTab(); //初始化婚姻状况(comboBox)
                        //comboBox_EmployeeSchoolRecord.DataSource = aebll.GetEmpSchoolRecordTab();   //初始化学历(comboBox)
                        //combobox_EmployeeHireType.DataSource = aebll.GetEmpHireTypeTab();           //初始化聘用形式(comboBox)

                        //GetEmpTable(int.Parse(dgv_Main.Rows[e.RowIndex].Cells["EmpID"].Value.ToString()));
                        //pl_AddEmpInfo.Visible = true;

                        tempEmpID = int.Parse(dgv_Main.Rows[e.RowIndex].Cells["EmpID"].Value.ToString());
                        //bt_AddEmpSave.Enabled = bt_AddEmpReset.Enabled = groupBox1.Enabled = groupBox3.Enabled = groupBox4.Enabled = groupBox5.Enabled = groupBox6.Enabled = false;
                        //tbc_EmpInfo.SelectedTab = tbp_EmpBasic;
                        A_FrmEmpInfo_AddEmpInfo frmAei = new A_FrmEmpInfo_AddEmpInfo(this);
                        frmAei.ShowDialog();

                        #endregion

                        break;
                    case 2:

                        #region【部门】

                        tempDept_ID = int.Parse(dgv_Main.Rows[e.RowIndex].Cells[7].Value.ToString());

                        A_FrmEmpInfo_AddDeptInfo frmAdi = new A_FrmEmpInfo_AddDeptInfo(this);
                        frmAdi.ShowDialog();

                        #endregion

                        break;
                    case 3:

                        #region【职务】

                        tempDuty_ID = int.Parse(dgv_Main.Rows[e.RowIndex].Cells[4].Value.ToString());               //绑定查看的职务信息

                        A_FrmEmpInfo_AddDutyInfo frmAdui = new A_FrmEmpInfo_AddDutyInfo(this);
                        frmAdui.ShowDialog();

                        #endregion

                        break;
                    case 4:

                        #region【工种】

                        tempWork_ID = int.Parse(dgv_Main.Rows[e.RowIndex].Cells[6].Value.ToString());               //绑定查看的职务信息

                        A_FrmEmpInfo_AddWorkTypeInfo frmAwt = new A_FrmEmpInfo_AddWorkTypeInfo(this);
                        frmAwt.ShowDialog();
                        #endregion

                        break;
                    case 5:

                        #region【证书】

                        tempCer_ID = int.Parse(dgv_Main.Rows[e.RowIndex].Cells[4].Value.ToString());

                        A_FrmEmpInfo_AddCerInfo frmAdc = new A_FrmEmpInfo_AddCerInfo(this);
                        frmAdc.ShowDialog();

                        #endregion

                        break;
                    default:
                        break;
                }
                
            }
            catch{}
        }

        #endregion



        #region 【事件: 上一页 单击事件 Click】

        private void bt_UpPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lb_PageCounts.Text);
            page--;
            if (page < 1)
            {
                return;
            }
            EmpInfo(page);
        }
        #endregion

        #region 【事件: 下一页 单击事件 Click】

        private void bt_DownPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lb_PageCounts.Text);
            page++;

            if (page > countPage)
            {
                return;
            }

            EmpInfo(page);
        }
        #endregion

        #region【事件：跳至】

        private void txt_SkipPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    string value = txt_SkipPage.Text;
                    if (value.CompareTo("") == 0)       //为空值时
                    {
                        return;
                    }
                    else if (int.Parse(value) > 0)
                    {
                        int page = int.Parse(value);
                        if (page > countPage)
                        {
                            page = countPage;
                        }
                        EmpInfo(page);
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        #endregion

        #region【事件：选择每页显示行数】

        private void cmb_SelectCounts_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_SelectCounts.Text.Trim() == "全部")
                pSize = 9999999;
            else
                pSize = Convert.ToInt32(cmb_SelectCounts.SelectedItem);
            //pSize = Convert.ToInt32(cmb_SelectCounts.SelectedItem);
            EmpInfo(1);
        }

        #endregion

        #region【事件：单元格单击事件】

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv_Main.Columns[e.ColumnIndex].Name.Equals("cl"))
                {
                    if (dgv_Main.Rows[e.RowIndex].Cells["cl"].Value != null && dgv_Main.Rows[e.RowIndex].Cells["cl"].Value.ToString().Equals("1"))
                    {
                        dgv_Main.Rows[e.RowIndex].Cells["cl"].Value = 0;
                        if (bt_SelectAll.Text.Equals("取消"))
                        {
                            bt_SelectAll.Text = "全选";
                        }
                    }
                    else
                    {
                        dgv_Main.Rows[e.RowIndex].Cells["cl"].Value = 1;
                    }
                }
            }
        }

        #endregion


        #region【事件：热备刷新】

        private void timer_RefResh_Tick(object sender, EventArgs e)
        {
            if (intRefReshCount >= intHostBackRefCount)
            {
                intRefReshCount = 0;
                timer_Refresh.Enabled = false;
            }
            else
            {
                intRefReshCount = intRefReshCount + 1;

                #region【刷新界面】

                switch (intSelectModel)
                {
                    case 1:

                        #region【人员】

                        Refresh_Emp();

                        #endregion

                        break;
                    case 2:

                        #region【部门】

                        Refresh_Dept();

                        #endregion

                        break;
                    case 3:

                        #region【职务】

                        Refresh_Duty();

                        #endregion

                        break;
                    case 4:

                        #region【工种】

                        Refresh_WorkType();

                        #endregion

                        break;
                    case 5:

                        #region【证书】

                        Refresh_Cer();

                        #endregion

                        break;
                    default:
                        break;
                }

                #endregion
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

        #region[事件：关闭]
        private void A_FrmEmpInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigXmlWiter.Write("Employees.xml");
        }
        #endregion

        private IButtonControl IB = null;
        private void txt_SkipPage_Enter(object sender, EventArgs e)
        {
            this.IB = this.AcceptButton;
            this.AcceptButton = null;
        }

        private void txt_SkipPage_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.IB;
        }

        private void txt_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }

        private void txt_EmpNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputFormat ifobj = new InputFormat();
            ifobj.HalfWidthFormat(e);
        }
        #region【事件：打印  导出】
        private string PrintTableName()
        {
            string strInfo = "员工";
            switch (intSelectModel)
            {
                case 1:
                    strInfo = "员工";
                    break;
                case 2:
                    strInfo = "部门";
                    break;
                case 3:
                    strInfo = "职务";
                    break;
                case 4:
                    strInfo = "工种";
                    break;
                case 5:
                    strInfo = "证书";
                    break;
                default:
                    break;
            }
            return strInfo + "信息";
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            PrintCore.ExportExcel excel = new PrintCore.ExportExcel();
            excel.Sql_ExportExcel(dgv_Main, PrintTableName());
        }

        private void btnConfigModel_Click(object sender, EventArgs e)
        {
            PrintBLL.PrintSet(dgv_Main, PrintTableName(), "");
        }
        private void bt_Print_Click(object sender, EventArgs e)
        {
            KJ128NDBTable.PrintBLL.Print(dgv_Main, PrintTableName(), "共 " + dgv_Main.Rows.Count.ToString() + "条信息");
        }

        #endregion
    }
}
