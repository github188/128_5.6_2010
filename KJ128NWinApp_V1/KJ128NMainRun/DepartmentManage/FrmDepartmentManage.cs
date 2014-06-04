using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128WindowsLibrary;
using ZdcCommonLibrary;
using KJ128NDataBase;
using System.Data.SqlClient;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NInterfaceShow
{
    public partial class FrmDepartmentManage : Wilson.Controls.Docking.DockContent
    {
        #region 私有变量
        private DeptBLL dbll = new DeptBLL();
        private AddEmpDAL adal = new AddEmpDAL();
        //KJ128NDataBase.DBAcess dbAcess = new KJ128NDataBase.DBAcess();

        #region

        /// <summary>
        /// 部门信息表
        /// </summary>
        DataTable dtDeptInfo;
        /// <summary>
        /// 职务信息表
        /// </summary>
        DataTable dtDutyInfo;
        /// <summary>
        /// 证书信息表
        /// </summary>
        DataTable dtCerInfo;

        /// <summary>
        /// 工种信息表
        /// </summary>
        DataTable dtWorkInfo;
        /// <summary>
        /// 用于保存要修改的部门ID
        /// </summary>
        int tempDept_ID;
        /// <summary>
        /// 用于保存要修改的部门编号
        /// </summary>
        string tempDept_NO;
        /// <summary>
        /// 用于保存要修改的职务名称
        /// </summary>
        string tempDuty_Name;
        /// <summary>
        /// 用于保存要修改的职务ID
        /// </summary>
        int tempDuty_ID;
        /// <summary>
        /// 用于保存要修改的证书ID
        /// </summary>
        int tempCer_ID;
        /// <summary>
        /// 用于保存要修改的工种ID
        /// </summary>
        int tempWork_ID;
        /// <summary>
        /// 用于保存要修改的工种名称
        /// </summary>
        string tempWork_Name;

        //拖动
        private bool isMove = false;            // (设置面板) 是否移动
        private int mleft = 0;
        private int mtop = 0;
        /// <summary>
        /// 记录部门表中选中的是第几行
        /// </summary>
        int tmpInt;                                      
        /// <summary>
        /// 记录职务表中选中的是第几行
        /// </summary>
        int tmpInt1;                                      
        /// <summary>
        /// 记录证书表中选中的是第几行
        /// </summary>
        int tmpInt2;                                      
        /// <summary>
        /// 记录工种表中选中的是第几行
        /// </summary>
        int tmpInt3;                                      

        #endregion

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmDepartmentManage()
        {
            InitializeComponent();

            //初始化工种、证书、职务信息状态
            InitializeModel();
        }

        private void InitializeModel()
        {
            //显示表格
            this.dgvCertificate.Visible = true;
            this.dgvDuty.Visible = false;
            this.dgvWorkType.Visible = false;

            //显示新增按钮
            buttonCaptionPanel10.Visible = true;
            buttonCaptionPanel8.Visible = false;
            buttonCaptionPanel12.Visible = false;
        }

        #endregion

        #region 窗体加载事件
        private void FrmDepartmentManage_Load(object sender, EventArgs e)
        {
            InitTreeViewDepartment();       //初始化部门树
            InitDataGridViewDepartment();   //初始化部门信息

            SetComboBoxParentDept();        //初始化上级部门名称

            SetComboBoxClassName();         //初始化班制名称


            InitDataGridViewDuty();         //初始化职务信息

            InitComboBoxDutyClass();        //初始化职务等级


            InitDataGridViewCertificate();  //初始化证书信息


            InitDataGridViewWorkType();     //初始化工种信息

            InitComboBoxCerName();          //初始化证书名称
            //this.WindowState = FormWindowState.Maximized;

        }
        #endregion

        #region 部门
        #region 初始化部门树
        /// <summary>
        ///初始化部门树
        /// </summary>
        private void InitTreeViewDepartment()
        {
            tvDepartment.Nodes.Clear();
            //DBAcess dbAcess = new DBAcess();
            //using (DataSet ds = dbAcess.GetDataSet("KJ128N_Dept_Info_Select_TreeView", null))
            //{
            //    if (ds != null)
            //    {
            //        tvDepartment.ReadDept_Info(ds.Tables[0]);         
            //    }
            //}
            using (DataSet ds = dbll.GetDeptDataSet())
            {
                //ds = dbll.GetDeptDataSet();

                if (ds != null)
                {
                    tvDepartment.ReadDept_Info(ds.Tables[0]);
                }
            }
            tvDepartment.ExpandAll();
        }
        #endregion

        #region 初始化部门信息
        /// <summary>
        /// 初始化部门信息
        /// </summary>
        private void InitDataGridViewDepartment()
        {
            string strSql;
            strSql = "select * from KJ128N_Dept_Info_Table order by 部门编号";
            using (dtDeptInfo = dbll.GetDataTableDept(strSql))
            {
                if (dtDeptInfo != null)
                {
                    dgvDepartment.DataSource = dtDeptInfo;
                    dgvDepartment.ReadOnly=true;
                    dgvDepartment.Columns[0].DisplayIndex = 13;
                    dgvDepartment.Columns[1].DisplayIndex = 13;
                    #region 隐藏部分信息
                    dgvDepartment.Columns[2].Visible = false;
                    dgvDepartment.Columns[6].Visible = false;
                    dgvDepartment.Columns[7].Visible = false;
                    dgvDepartment.Columns[8].Visible = false;
                    dgvDepartment.Columns[9].Visible = false;
                    #endregion
                    #region 设置宽度
                    dgvDepartment.Columns[3].Width = 96;
                    dgvDepartment.Columns[4].Width = 90;
                    dgvDepartment.Columns[5].Width = 90;
                    #endregion
                }
            }
        }
        #endregion
        
        #region 增加部门信息窗体关闭 单击事件 Click
        private void buttonCaptionPanel4_CloseButtonClick(object sender, EventArgs e)
        {
            vsPanel1.Visible = false;           //隐藏增加部门信息窗体
        }
        #endregion

        #region "修改"和"删除" 单击事件
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
            DataTable drTempDeptInfo;

            tmpInt = e.RowIndex;


            //tmpInt = Convert.ToInt32(dgvDepartment.CurrentRow.Cells[0].Value);

            if (e.ColumnIndex == 0 && e.RowIndex>=0)                 //点击“修改”
            {
                textBox_DeptNO.Enabled = false;
                operate = 1;

                ClearDeptInfo();                    //清空 增加部门信息
                
                vsPanel1.Parent = this;
                vsPanel1.BringToFront();
                vsPanel1.Visible = true;
                buttonCaptionPanel4.CaptionTitle = "修改部门";
                buttonCaptionPanel5.CaptionTitle = "修改并返回";
                buttonCaptionPanel6.CaptionTitle = "返回";
                SetComboBoxParentDept();
                #region 绑定数据


                //tempDept_ID = Convert.ToInt32(dtDeptInfo.Rows[e.RowIndex][0]);

                tempDept_ID = Convert.ToInt32(dgvDepartment.CurrentRow.Cells["DeptID"].Value);

                using (DataSet ds = dbll.GetKJ128NAllDept(tempDept_ID))
                {
                    if (ds != null)
                    {
                        drTempDeptInfo = ds.Tables[0];
                        if (drTempDeptInfo.Rows.Count == 1)
                        {
                            tempDept_NO = drTempDeptInfo.Rows[0][2].ToString();
                            textBox_DeptNO.Text = drTempDeptInfo.Rows[0][2].ToString();     //获取部门编号
                            textBox_DeptName.Text = drTempDeptInfo.Rows[0][3].ToString();   //获取部门名称
                            textBox_Remark.Text = drTempDeptInfo.Rows[0][4].ToString();     //获取部门备注
                            #region 获取上级部门名称
                            using (DataSet dsTemp = dbll.GetIDDeptInfo(drTempDeptInfo.Rows[0][1].ToString()))
                            {
                                if (dsTemp != null)
                                {
                                    DataTable drTemp;
                                    drTemp = dsTemp.Tables[0];
                                    if (drTemp.Rows.Count == 1)
                                    {
                                        comboBox_ParentDept.Text = drTemp.Rows[0][3].ToString();
                                    }
                                    else if (drTemp.Rows.Count == 0)
                                    {
                                        comboBox_ParentDept.Text = "无";
                                    }
                                }
                            }
                            #endregion

                            #region 计算最大工作时间

                            if (drTempDeptInfo.Rows[0][5].ToString().CompareTo("") == 0)
                            {
                                textBox_MaxHour.Text = "";
                                textBox_MaxMinute.Text = "";
                                textBox_MaxSecond.Text = "";
                            }
                            else
                            {
                                int intMax = Convert.ToInt32(drTempDeptInfo.Rows[0][5]);
                                int hourMax = intMax / 3600;
                                int minuteMax = (intMax - hourMax * 3600) / 60;
                                int secondMax = intMax % 60;
                                textBox_MaxHour.Text = hourMax.ToString();
                                textBox_MaxMinute.Text = minuteMax.ToString();
                                textBox_MaxSecond.Text = secondMax.ToString();
                            }
                            #endregion
                            #region 计算最小工作时间

                            if (drTempDeptInfo.Rows[0][6].ToString().CompareTo("") == 0)
                            {
                                textBox_MinHour.Text = "";
                                textBox_MinMinute.Text = "";
                                textBox_MinSecond.Text = "";
                            }
                            else
                            {
                                int intMin = Convert.ToInt32(drTempDeptInfo.Rows[0][6]);
                                int hourMin = intMin / 3600;
                                int minuteMin = (intMin - hourMin * 3600) / 60;
                                int secondMin = intMin % 60;
                                textBox_MinHour.Text = hourMin.ToString();
                                textBox_MinMinute.Text = minuteMin.ToString();
                                textBox_MinSecond.Text = secondMin.ToString();
                            }
                            #endregion
                            textBox_DeptTel1.Text = drTempDeptInfo.Rows[0][9].ToString();       //获取部门电话1
                            textBox_DeptTel2.Text = drTempDeptInfo.Rows[0][10].ToString();      //获取部门电话2
                            textBox_DeptFax.Text = drTempDeptInfo.Rows[0][11].ToString();       //获取部门传真
                            textBox_DeptEmail.Text = drTempDeptInfo.Rows[0][14].ToString();     //获取部门电子邮箱
                            textBox_DeptPost.Text = drTempDeptInfo.Rows[0][12].ToString();      //获取部门邮编
                            textBox_DeptAddress.Text = drTempDeptInfo.Rows[0][13].ToString();   //获取部门地址
                            #region 获取部门领导姓名和上任时间

                            string strDeptLeadID;
                            strDeptLeadID = drTempDeptInfo.Rows[0][7].ToString();
                            if (strDeptLeadID.CompareTo("") != 0)
                            {

                                using (DataSet dsTemp = dbll.GetEmpIDEmpInfo(drTempDeptInfo.Rows[0][7].ToString()))
                                {
                                    if (dsTemp != null)
                                    {
                                        DataTable drTemp;
                                        drTemp = dsTemp.Tables[0];
                                        if (drTemp.Rows.Count == 1)
                                        {
                                            textBox_DeptLeadName.Text = drTemp.Rows[0][1].ToString();
                                        }
                                    }
                                }
                                if (drTempDeptInfo.Rows[0][8].ToString().CompareTo("") == 0)
                                {
                                    textBox_LeadDateTime.Text = DateTime.Now.Date.ToString();
                                    textBox_LeadDateTime.Enabled = false;
                                    cb_LeadDateTime.Checked = false;
                                }
                                else
                                {
                                    textBox_LeadDateTime.Enabled = true;
                                    cb_LeadDateTime.Checked = true;
                                    textBox_LeadDateTime.Text = Convert.ToDateTime(drTempDeptInfo.Rows[0][8].ToString()).Year.ToString() + "-" + Convert.ToDateTime(drTempDeptInfo.Rows[0][8].ToString()).Month.ToString() + "-" + Convert.ToDateTime(drTempDeptInfo.Rows[0][8].ToString()).Day.ToString();
                                }
                            }                          
                            #endregion                           
                            #region 获取班制名称
                            if (drTempDeptInfo.Rows[0][15].ToString()!= "")
                            {
                                comboBox_ClassName.SelectedValue = Convert.ToInt32(drTempDeptInfo.Rows[0][15]);
                            }
                            #endregion
                            comboBox_ParentDept.Enabled = false;
                        }                       
                    }
                }
                #endregion
            }
            else if (e.ColumnIndex == 1 &&e.RowIndex>=0)            //点击“删除”
            {
                operate = 2;

                //MessageBox.Show(dgvDepartment.CurrentRow.Cells["部门编号"].Value.ToString());

                DialogResult result;
                tmpInt = e.RowIndex;
                tempDept_ID = Convert.ToInt32(dtDeptInfo.Rows[e.RowIndex][0]);
                
                //存入日志
                LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "删除部门信息，部门编号：" + dtDeptInfo.Rows[e.RowIndex][1].ToString()
                    + "，部门名称：" + dtDeptInfo.Rows[e.RowIndex][2].ToString() + "。");

                string str2 = string.Format("select * from Emp_NowCompany where DeptID = {0}",tempDept_ID);
                if (adal.GetBool(str2))
                {
                    if (MessageBox.Show("该部门已经绑定了员工，如果删除将会造成不可估量的后果，请不要删除！", "提示", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        return;
                    }
                }

                string str1 = string.Format("select * from Dept_Info where ParentDeptID={0}", tempDept_ID);
                if (adal.GetBool(str1))
                {
                    result = MessageBox.Show("删除该部门后其下级部门都将删除，并且会丢失绑定了该部门或绑定其下级部门的员工信息，是否删除？", "提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        dbll.DeleteDept(tempDept_ID);

                        if (!New_DBAcess.IsDouble)
                        {
                            InitDataGridViewDepartment();
                            InitTreeViewDepartment();
                        }
                        else
                        {
                            timerDept.Start();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    result = MessageBox.Show("删除该部门，将会丢失绑定了该部门的员工信息，是否要删除？", "提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        dbll.DeleteDept(tempDept_ID);

                        if (!New_DBAcess.IsDouble)
                        {
                            InitDataGridViewDepartment();
                            InitTreeViewDepartment();
                        }
                        else
                        {
                            timerDept.Start();
                        }   
                    }
                }
                dgvDepartment.ClearSelection();
                if (tmpInt > 0)
                {
                    if (dgvDepartment.Rows.Count >= tmpInt + 1)
                    {
                        dgvDepartment.Rows[tmpInt].Selected = true;
                    }
                    else
                    {
                        dgvDepartment.Rows[tmpInt - 1].Selected = true;
                    }
                }
            }
        }
        #endregion

        #region 单击部门树，显示所点击的部门信息
        private void tvDepartment_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strsql;
            if (e.Node.Text == "所有")
                strsql = "select * from KJ128N_Dept_Info_Table";
            else
                strsql = "select * from KJ128N_Dept_Info_Table where ParentDeptID in (select DeptID from KJ128N_Dept_Info_Table where 部门名称='" + e.Node.Text + "') or ParentDeptID in (select DeptID from KJ128N_Dept_Info_Table where ParentDeptID in(select DeptID from KJ128N_Dept_Info_Table where 部门名称='" + e.Node.Text + "') ) or ParentDeptID in(select DeptID from KJ128N_Dept_Info_Table where  ParentDeptID in(select DeptID from KJ128N_Dept_Info_Table where  ParentDeptID in(select DeptID from KJ128N_Dept_Info_Table where 部门名称='" + e.Node.Text + "'))) or 部门名称='" + e.Node.Text + "'";          
            using ( dtDeptInfo = dbll.GetDataTableDept(strsql))
            {
                if (dtDeptInfo != null)
                {
                    dgvDepartment.DataSource = dtDeptInfo;
                    dgvDepartment.ReadOnly = true;
                }
            }
        }
        #endregion
                
        #region 增加 单击事件 Click
        private void buttonCaptionPanel3_Click(object sender, EventArgs e)
        {
            SetComboBoxParentDept();                //初始化上级部门名称

            SetComboBoxClassName();                 //初始化班制名称

            textBox_DeptNO.Enabled = true;

            vsPanel1.Parent = this;
            vsPanel1.BringToFront();
            vsPanel1.Visible = true;                //显示增加部门信息窗体

            ClearDeptInfo();                        //清空增加部门信息窗体内容
            buttonCaptionPanel4.CaptionTitle = "新增部门";
            buttonCaptionPanel5.CaptionTitle = "存储并新增";
            buttonCaptionPanel6.CaptionTitle = "存储并返回";
            comboBox_ParentDept.Enabled = true;
        }
        #endregion

        #region 添加 部门信息
        #region 初始化上级部门名称
        /// <summary>
        /// 初始化上级部门名称
        /// </summary>
        void SetComboBoxParentDept()
        {
            dbll.GetParentDeptCmb(comboBox_ParentDept);           
        }
        #endregion

        #region 初始化班制名称
        /// <summary>
        /// 初始化班制名称
        /// </summary>
        void SetComboBoxClassName()
        {
            dbll.GetClassNameCmb(comboBox_ClassName);
        }
        #endregion

        #region 清空 增加部门信息
        /// <summary>
        /// 清空 增加部门信息
        /// </summary>
        void ClearDeptInfo()
        {
            foreach (Control cl in vsPanel1.Controls)
            {
                if (cl.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)cl).SelectedIndex = 0;
                }
                if (cl.GetType() == typeof(TextBox))
                {
                    ((TextBox)cl).Text = "";
                }
            }
            textBox_MaxHour.Text = "10";
            textBox_MaxMinute.Text = "0";
            textBox_MaxSecond.Text = "0";
            textBox_MinHour.Text = "0";
            textBox_MinMinute.Text = "0";
            textBox_MinSecond.Text = "0";
            cb_LeadDateTime.Checked = false;
            textBox_LeadDateTime.Enabled = false;
            SetComboBoxParentDept();                //初始化上级部门名称

            SetComboBoxClassName();                 //初始化班制名称          
        }

        #endregion

        #region 验证部门信息
        /// <summary>
        /// 验证部门信息是否符合要求
        /// </summary>
        /// <returns>返回是否通过验证</returns>
        bool CheckingDeptInfo()
        {
            string sqlString = "";
            #region 验证部门编号不能为空
            if (textBox_DeptNO.Text.ToString().CompareTo("") == 0)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：没有输入部门代号,请输入部门代号!");
                textBox_DeptNO.Focus();
                textBox_DeptNO.SelectAll();
                return false;
            }
            #endregion
            #region 验证部门名称不能为空
            if (textBox_DeptName.Text.ToString().CompareTo("") == 0)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：没有输入部门名称,请输入部门名称!");
                textBox_DeptName.Focus();
                textBox_DeptName.SelectAll();
                return false;
            }
            #endregion
            #region 验证部门编号的唯一性

            if (!(buttonCaptionPanel5.CaptionTitle.CompareTo("修改并返回") == 0 && textBox_DeptNO.Text.CompareTo(tempDept_NO)== 0))
            {
                using (DataSet ds = dbll.GetIDDeptID(textBox_DeptNO.Text.ToString()))
                {
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count != 0)
                        {
                            DeptErorrInfo.CaptionTitle = String.Format("信息提示：部门代号已存在,请重新输入部门代号!");
                            textBox_DeptNO.Focus();
                            textBox_DeptNO.SelectAll();
                            return false;
                        }
                    }
                }
            }
            #endregion
            #region 验证当输入领导上任时间时，部门领导不能为空

            if (textBox_DeptLeadName.Text.ToString().CompareTo("") == 0 && cb_LeadDateTime.Checked)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：有领导上任时间，但没输入领导，请输入部门领导!");
                textBox_DeptLeadName.Focus();
                textBox_DeptLeadName.SelectAll();
                return false;
            }
            #endregion
            #region 验证部门领导是否存在
            if (textBox_DeptLeadName.Text.ToString().CompareTo("") != 0)
            {
                using (DataSet ds = dbll.GetEmpNameEmpInfo(textBox_DeptLeadName.Text.ToString()))
                {
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count == 0)
                        {
                            DeptErorrInfo.CaptionTitle = String.Format("信息提示：部门领导不存在,请重新输入部门领导!");
                            textBox_DeptLeadName.Focus();
                            textBox_DeptLeadName.SelectAll();
                            return false;
                        }
                    }
                }
            }
            #endregion
            #region 验证 最小工作时间、最大工作时间

            if (textBox_MaxHour.Text == string.Empty)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：请输入最大工作时间！");
                textBox_MaxHour.Focus();
                textBox_MaxHour.SelectAll();
                return false;
            }
            else if(textBox_MaxMinute.Text==string.Empty)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：请输入最大工作时间！");
                textBox_MaxMinute.Focus();
                textBox_MaxMinute.SelectAll();
                return false;
            }
            else if (textBox_MaxSecond.Text == string.Empty)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：请输入最大工作时间！");
                textBox_MaxSecond.Focus();
                textBox_MaxSecond.SelectAll();
                return false;
            }
            else if (textBox_MinHour.Text == string.Empty)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：请输入最小工作时间！");
                textBox_MinHour.Focus();
                textBox_MinHour.SelectAll();
                return false;
            }
            else if (textBox_MinMinute.Text == string.Empty)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：请输入最小工作时间！");
                textBox_MinMinute.Focus();
                textBox_MinMinute.SelectAll();
                return false;
            }
            else if (textBox_MinSecond.Text == string.Empty)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：请输入最小工作时间！");
                textBox_MinSecond.Focus();
                textBox_MinSecond.SelectAll();
                return false;
            }

            int intMax, intMin;
            intMax = Convert.ToInt32(textBox_MaxHour.Text) * 3600 + Convert.ToInt32(textBox_MaxMinute.Text) * 60 + Convert.ToInt32(textBox_MaxSecond.Text);
            intMin = Convert.ToInt32(textBox_MinHour.Text) * 3600 + Convert.ToInt32(textBox_MinMinute.Text) * 60 + Convert.ToInt32(textBox_MinSecond.Text);

            if (intMax < intMin)
            {
                DeptErorrInfo.CaptionTitle = String.Format("信息提示：最小工作时间不能大于最大工作时间！");
                textBox_MinHour.Focus();
                textBox_MinHour.SelectAll();
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region 添加 部门的各种信息
        /// <summary>
        /// 添加部门的各种信息
        /// </summary>
        void SaveSetDept()
        {
            this.label4.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            //存入日志
            LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "添加部门信息，部门编号：" + textBox_DeptNO.Text.Trim() + "，部门名称：" + textBox_DeptName.Text.ToString() + "。");

            int EmpID;
            int ParentDept_ID=Convert.ToInt32(comboBox_ParentDept.SelectedValue);      //获取上级部门编号
            int DeptLevel_ID = dbll.GetDeptLevelID(ParentDept_ID);//获取部门级别

            
            //#region 添加 部门基本信息
            //dbll.SaveDeptInfoData(ParentDept_ID, DeptLevel_ID, textBox_DeptNO.Text.Trim(), textBox_DeptName.Text.ToString(), textBox_Remark.Text.ToString(), Convert.ToInt32(comboBox_ClassName.SelectedValue));
            //#endregion

            //int Dept_ID = dbll.GetDeptID(textBox_DeptNO.Text.ToString());

            //#region 添加 部门信息
            //dbll.SaveDeptDetailData(/*Dept_ID*/textBox_DeptNO.Text.Trim(), textBox_DeptTel1.Text.ToString(), textBox_DeptTel2.Text.ToString(), textBox_DeptFax.Text.ToString(), textBox_DeptPost.Text.ToString(), textBox_DeptAddress.Text.ToString(), textBox_DeptEmail.Text.ToString());
            //#endregion

            //#region 添加 部门设置
            //dbll.SaveDeptSysSetData(textBox_DeptNO.Text.Trim(), Convert.ToInt32(textBox_MaxHour.Text.ToString()), Convert.ToInt32(textBox_MaxMinute.Text.ToString()), Convert.ToInt32(textBox_MaxSecond.Text.ToString()), Convert.ToInt32(textBox_MinHour.Text.ToString()), Convert.ToInt32(textBox_MinMinute.Text.ToString()), Convert.ToInt32(textBox_MinSecond.Text.ToString()));
            //#endregion

            //#region 添加 部门领导信息
            //if (textBox_DeptLeadName.Text.ToString().CompareTo("") != 0)  //判断部门领导不为空
            //{
            //    EmpID = dbll.GetDeptLeadID(textBox_DeptLeadName.Text.ToString());    //获取部门领导的ID
            //    string strLeadDate;
            //    if (cb_LeadDateTime.Checked)
            //    {
            //        strLeadDate = textBox_LeadDateTime.Text.ToString();
            //    }
            //    else
            //    {
            //        strLeadDate = "";
            //    }
            //    dbll.SaveDeptLeadData(/*Dept_ID*/textBox_DeptNO.Text.Trim(), EmpID, strLeadDate);
            //}
            //#endregion
            
            
            string strLeadDate;
            if (textBox_DeptLeadName.Text.ToString().CompareTo("") != 0)  //判断部门领导不为空
            {
                EmpID = dbll.GetDeptLeadID(textBox_DeptLeadName.Text.ToString());    //获取部门领导的ID
                
                if (cb_LeadDateTime.Checked)
                {
                    strLeadDate = textBox_LeadDateTime.Text.ToString();
                }
                else
                {
                    strLeadDate = "";
                }
            }
            else
            {
                EmpID=0;
                strLeadDate="";
            }
            dbll.SaveDeptInfo(ParentDept_ID, DeptLevel_ID, textBox_DeptNO.Text.Trim(), textBox_DeptName.Text.ToString(), textBox_Remark.Text.ToString(), Convert.ToInt32(comboBox_ClassName.SelectedValue),
                textBox_DeptTel1.Text.ToString(), textBox_DeptTel2.Text.ToString(), textBox_DeptFax.Text.ToString(), textBox_DeptPost.Text.ToString(), textBox_DeptAddress.Text.ToString(), textBox_DeptEmail.Text.ToString(),
                Convert.ToInt32(textBox_MaxHour.Text.ToString()), Convert.ToInt32(textBox_MaxMinute.Text.ToString()), Convert.ToInt32(textBox_MaxSecond.Text.ToString()), Convert.ToInt32(textBox_MinHour.Text.ToString()), Convert.ToInt32(textBox_MinMinute.Text.ToString()), Convert.ToInt32(textBox_MinSecond.Text.ToString()),
                EmpID, strLeadDate);
             
        }
        #endregion

        #region 修改 部门的各种信息
        /// <summary>
        /// 修改 部门的各种信息
        /// </summary>
        void UpDateDept()
        {
            //存入日志
            LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "修改部门信息，部门编号：" + textBox_DeptNO.Text.Trim() + "，部门名称：" + textBox_DeptName.Text.ToString() + "。");

            int EmpID;      //部门领导的ID
            int ParentDept_ID = Convert.ToInt32(comboBox_ParentDept.SelectedValue);     //dbll.GetParentDeptID(comboBox_ParentDept.Text.ToString());   //获取上级部门编号
            int DeptLevel_ID = dbll.GetDeptLevelID(ParentDept_ID);      //获取部门级别
            #region 修改 部门基本信息
            dbll.UpDateDeptInfoData(tempDept_ID, ParentDept_ID, DeptLevel_ID, textBox_DeptNO.Text.ToString(), textBox_DeptName.Text.ToString(), textBox_Remark.Text.ToString(),Convert.ToInt32(comboBox_ClassName.SelectedValue));
            #endregion
            #region 修改 部门信息
            //dbll.UpDateDeptDetailData(tempDept_ID, textBox_DeptTel1.Text.ToString(), textBox_DeptTel2.Text.ToString(), textBox_DeptFax.Text.ToString(), textBox_DeptPost.Text.ToString(), textBox_DeptAddress.Text.ToString(), textBox_DeptEmail.Text.ToString());
            dbll.SaveDeptDetailData(/*tempDept_ID*/textBox_DeptNO.Text.Trim(), textBox_DeptTel1.Text.ToString(), textBox_DeptTel2.Text.ToString(), textBox_DeptFax.Text.ToString(), textBox_DeptPost.Text.ToString(), textBox_DeptAddress.Text.ToString(), textBox_DeptEmail.Text.ToString());
            #endregion
            #region 修改 部门设置
            dbll.UpDateDeptSysSetData(tempDept_ID, Convert.ToInt32(textBox_MaxHour.Text.ToString()), Convert.ToInt32(textBox_MaxMinute.Text.ToString()), Convert.ToInt32(textBox_MaxSecond.Text.ToString()), Convert.ToInt32(textBox_MinHour.Text.ToString()), Convert.ToInt32(textBox_MinMinute.Text.ToString()), Convert.ToInt32(textBox_MinSecond.Text.ToString()));
            #endregion
            #region 修改 部门领导信息
            if (textBox_DeptLeadName.Text.ToString().CompareTo("") != 0)  //
            {
                EmpID = dbll.GetDeptLeadID(textBox_DeptLeadName.Text.ToString());    //获取部门领导的ID
                string strLeadDate;
                if (cb_LeadDateTime.Checked)
                {
                    strLeadDate = textBox_LeadDateTime.Text.ToString();
                }
                else
                {
                    strLeadDate = "";
                }
                dbll.UpDateDeptLeadData(/*tempDept_ID*/textBox_DeptNO.Text.Trim(), EmpID, strLeadDate);
            }
            else
            {
                dbll.DeleteDeptLead(tempDept_ID);
            }
            #endregion
        }
        #endregion

        #region [ 属性:  ]

        private bool CheckTime()
        {
            try
            {
                int iMinute = int.Parse(textBox_MaxMinute.Text);
                int iSecond = int.Parse(textBox_MaxSecond.Text);
                int i1 = int.Parse(textBox_MinMinute.Text);
                int i2 = int.Parse(textBox_MinSecond.Text);
                if (Check(iMinute) && Check(iSecond) && Check(i1) && Check(i2))
                {
                    return true;
                }
                else
                {
                    DeptErorrInfo.CaptionTitle = "分和秒不能大于60且不能小于0!";
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool CheckTimeN()
        {
            try
            {
                int iMinute = int.Parse(textBox_WorkMaxMinute.Text);
                int iSecond = int.Parse(textBox_WorkMaxSecond.Text);
                int i1 = int.Parse(textBox_WorkMinMinute.Text);
                int i2 = int.Parse(textBox_WorkMinSecond.Text);
                if (Check(iMinute) && Check(iSecond) && Check(i1) && Check(i2))
                {
                    return true;
                }
                else
                {
                    WorkErorrInfo.CaptionTitle = "分和秒不能大于60且不能小于0!";
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool Check(int i)
        {
            if (i >= 0 && i <= 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "存储并新增"和"修改并返回" 单击事件 Click
        private void buttonCaptionPanel5_Click(object sender, EventArgs e)
        {
            if (CheckingDeptInfo())         //验证部门信息
            {
                if (!CheckTime())
                {
                    return;
                }

                operate = 1;

                if (buttonCaptionPanel5.CaptionTitle.CompareTo("存储并新增") == 0)
                {
                    SaveSetDept();                                  //添加 部门的各种信息
     
                    DeptErorrInfo.CaptionTitle = String.Format("信息提示：一切正常!");
                    MessageBox.Show("部门信息增加成功!");
                    ClearDeptInfo();
                    //清空 增加部门信息

                    if (!New_DBAcess.IsDouble)
                    {
                        InitTreeViewDepartment();                       //重新初始化部门树 
                        InitDataGridViewDepartment();                   //初始化部门信息

                        SetComboBoxParentDept();                        //初始化上级部门名称
                    }
                    else
                    {
                        timerDept.Start();
                    }

                    dgvDepartment.ClearSelection();
                    if (tmpInt > 0)
                    {
                        if (dgvDepartment.Rows.Count >= tmpInt + 1)
                        {
                            dgvDepartment.Rows[tmpInt].Selected = true;
                        }
                        else
                        {
                            dgvDepartment.Rows[tmpInt - 1].Selected = true;
                        }
                    }
                }
                else if (buttonCaptionPanel5.CaptionTitle.CompareTo("修改并返回") == 0)
                {

                    UpDateDept();       //修改 部门的各种信息
                       
                    DeptErorrInfo.CaptionTitle = String.Format("信息提示：一切正常!");
                    MessageBox.Show("部门信息修改成功!");
                    vsPanel1.Visible = false;

                    operate = 1;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitTreeViewDepartment();                       //重新初始化部门树   
                        InitDataGridViewDepartment();                   //初始化部门信息
                    }
                    else
                    {
                        //有问题
                        timerDept.Start();
                    }

                    dgvDepartment.ClearSelection();
                    if (tmpInt > 0)
                    {
                        if (dgvDepartment.Rows.Count >= tmpInt + 1)
                        {
                            dgvDepartment.Rows[tmpInt].Selected = true;
                        }
                        else
                        {
                            dgvDepartment.Rows[tmpInt - 1].Selected = true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("部门信息填写有错误,请查看最下边的信息提示!");
            }

        }
        #endregion

        #region "存储并返回"和"返回" 单击事件 Click
        private void buttonCaptionPanel6_Click(object sender, EventArgs e)
        {
            
            if (buttonCaptionPanel6.CaptionTitle.CompareTo("存储并返回") == 0)
            {
                operate = 1;

                if (!CheckTime())
                {
                    return;
                }
                if (CheckingDeptInfo())     //验证部门信息
                {
                    SaveSetDept();//添加部门的各种信息

                    DeptErorrInfo.CaptionTitle = String.Format("信息提示：一切正常!");
                    MessageBox.Show("部门信息增加成功!");
                    vsPanel1.Visible = false;


                    if (!New_DBAcess.IsDouble)
                    {

                        InitTreeViewDepartment();   //重新初始化部门树  

                        InitDataGridViewDepartment();                   //初始化部门信息

                        SetComboBoxParentDept();                        //初始化上级部门名称
                    }
                    else
                    {
                        timerDept.Start();
                    }

                    dgvDepartment.ClearSelection();
                    if (tmpInt > 0)
                    {
                        if (dgvDepartment.Rows.Count >= tmpInt + 1)
                        {
                            dgvDepartment.Rows[tmpInt].Selected = true;
                        }
                        else
                        {
                            dgvDepartment.Rows[tmpInt - 1].Selected = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("部门信息填写有错误,请查看最下边的信息提示!");
                }
            }
            else if (buttonCaptionPanel6.CaptionTitle.CompareTo("返回") == 0)
            {
                vsPanel1.Visible = false;
            }
        }
        #endregion 

        #region 启用领导上任时间 单击事件 Click
        private void cb_LeadDateTime_Click(object sender, EventArgs e)
        {
            if (cb_LeadDateTime.Checked)
            {
                textBox_LeadDateTime.Enabled = true;
            }
            else
            {
                textBox_LeadDateTime.Enabled = false;
            }
        }
        #endregion
        #endregion

        #region 拖动
        private void buttonCaptionPanel4_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }
        private void buttonCaptionPanel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }

        private void buttonCaptionPanel4_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion
        #endregion

        #region 职务
        #region 方法
        #region 初始化职务信息
        /// <summary>
        /// 初始化职务信息
        /// </summary>
        private void InitDataGridViewDuty()
        {
            string strSql = "select * from KJ128N_Duty_Info_Table";
            dtDutyInfo = dbll.GetDataTableDuty(strSql);

            dgvDuty.DataSource = dtDutyInfo;
            dgvDuty.ReadOnly = true;
            dgvDuty.Columns[5].Visible = false;
            dgvDuty.Columns[0].DisplayIndex = 6;
            dgvDuty.Columns[1].DisplayIndex = 6;
            dgvDuty.Columns[2].HeaderText = "职务编号";
            dgvDuty.Columns[6].Width = 396;
            dgvDuty.Columns[2].Visible = false;
        }
        #endregion

        #region 初始化职务等级

        /// <summary>
        /// 绑定职务等级
        /// </summary>
        private void InitComboBoxDutyClass()
        {
            using (DataSet ds = dbll.GetDutyGrade())
            {
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count != 0)
                    {
                        comboBox_DutyClass.DataSource = dt.DefaultView;
                        comboBox_DutyClass.DisplayMember = "Title";
                        comboBox_DutyClass.SelectedIndex = 5; 
                    }
                }
            }
            
        }
        #endregion

        #region 验证 职务信息
        /// <summary>
        /// 验证职务信息
        /// </summary>
        /// <returns></returns>
        bool CheckingDutyInfo()
        {
            string sqlString;
            #region 验证职务名称不能为空
            if (textBox_DutyName.Text.ToString().CompareTo("") == 0)
            {
                DutyErorrInfo.CaptionTitle = String.Format("信息提示：没有输入职务名称,请输入职务名称!");
                textBox_DutyName.Focus();
                textBox_DutyName.SelectAll();
                return false;
            }
            #endregion
            #region 验证职务名称的唯一性

            if (!(buttonCaptionPanel14.CaptionTitle.CompareTo("修改并返回") == 0 && textBox_DutyName.Text.CompareTo(tempDuty_Name) == 0))
            {
                using (DataSet ds = dbll.GetDutyInfoTable(textBox_DutyName.Text.ToString()))
                {
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count != 0)
                        {
                            DutyErorrInfo.CaptionTitle = String.Format("信息提示：职务名称已存在,请重新输入职务名称!");
                            textBox_DutyName.Focus();
                            textBox_DutyName.SelectAll();
                            return false;
                        }
                    }
                }
            }
            #endregion
            return true;
        }
        #endregion

        #region 清空 增加职务信息
        /// <summary>
        /// 清空 增加职务信息
        /// </summary>
        void ClearDutyInfo()
        {
            textBox_DutyName.Text = "";
            comboBox_DutyClass.SelectedIndex=5;// .Text = "员工";
            textBox_DutyRemark.Text = "";
        }
        #endregion
        #endregion

        #region 事件
        #region "新增"按钮的单击事件

        private void buttonCaptionPanel8_Click(object sender, EventArgs e)
        {
            textBox_DutyName.Enabled = true;

            this.vsPanel2.Visible = true;
            buttonCaptionPanel13.CaptionTitle = "增加职务";
            buttonCaptionPanel14.CaptionTitle = "存储并新增";
            buttonCaptionPanel15.CaptionTitle = "存储并返回";
            InitComboBoxDutyClass();
            ClearDutyInfo();            //清空职务信息
        }
        #endregion

        #region "关闭"按钮的单击事件

        private void buttonCaptionPanel13_CloseButtonClick(object sender, EventArgs e)
        {
            this.vsPanel2.Visible = false;
        }
        #endregion

        #region "存储并新增"和"修改并返回"按钮的单击事件
        private void buttonCaptionPanel14_Click(object sender, EventArgs e)
        {
            if (CheckingDutyInfo())
            {
                if (buttonCaptionPanel14.CaptionTitle.CompareTo("存储并新增") == 0)
                {
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "添加职务信息，职务名称："+textBox_DutyName.Text+"，职务等级："+comboBox_DutyClass.SelectedText+"。");
                    
                    int DutyClassID = comboBox_DutyClass.SelectedIndex + 1;
                    dbll.SaveDutyInfoData(textBox_DutyName.Text.ToString(), DutyClassID, textBox_DutyRemark.Text.ToString());

                    duty = textBox_DutyName.Text.ToString();
                    DutyErorrInfo.CaptionTitle = String.Format("信息提示：一切正常!");
                    MessageBox.Show("职务信息增加成功!");
                    ClearDutyInfo();            //清空职务信息

                    operate = 1;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewDuty();     //初始化职务信息
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
                else if (buttonCaptionPanel14.CaptionTitle.CompareTo("修改并返回") == 0)
                {
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "修改职务信息，职务名称：" + textBox_DutyName.Text + "，职务等级：" + comboBox_DutyClass.SelectedText + "。");
                    duty = textBox_DutyName.Text.ToString();
                    dbll.UpDateDutyInfo(tempDuty_ID, textBox_DutyName.Text.ToString(), comboBox_DutyClass.SelectedIndex + 1, textBox_DutyRemark.Text.ToString());
                    vsPanel2.Visible = false;

                    MessageBox.Show("职务信息修改成功");

                    operate = 1;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewDuty();     //初始化职务信息
                    }
                    else
                    {
                        timer1.Start();
                    }

                }
                dgvDuty.ClearSelection();
                //if (tmpInt1 > 0)
                //{
                //    if (dgvDuty.Rows.Count >= tmpInt1 + 1)
                //    {
                //        dgvDuty.Rows[tmpInt1].Selected = true;
                //    }
                //    else
                //    {
                //        dgvDuty.Rows[tmpInt1 - 1].Selected = true;
                //    }
                //}
            }
        }
        #endregion

        #region "存储并返回"和"返回"按钮的单击事件

        private void buttonCaptionPanel15_Click(object sender, EventArgs e)
        {
            if (CheckingDutyInfo())
            {
                if (buttonCaptionPanel15.CaptionTitle.CompareTo("存储并返回") == 0)
                {
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "增加职务信息，职务名称：" + textBox_DutyName.Text + "，职务等级：" + comboBox_DutyClass.SelectedText + "。");

                    int DutyClassID = comboBox_DutyClass.SelectedIndex + 1;
                    dbll.SaveDutyInfoData(textBox_DutyName.Text.ToString(), DutyClassID, textBox_DutyRemark.Text.ToString());
                    //InitDataGridViewDuty();     //初始化职务信息
                    duty = textBox_DutyName.Text.ToString();
                    DutyErorrInfo.CaptionTitle = String.Format("信息提示：一切正常!");
                    MessageBox.Show("职务信息增加成功!");
                    ClearDutyInfo();            //清空职务信息
                    vsPanel2.Visible = false;

                    operate = 1;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewDuty();
                    }
                    else
                    {
                        timer1.Start();
                    }

                    dgvDuty.ClearSelection();
                    #region 控制选中行数
                    //if (tmpInt1 > 0)
                    //{
                    //    if (dgvDuty.Rows.Count >= tmpInt1 + 1)
                    //    {
                    //        dgvDuty.Rows[tmpInt1].Selected = true;
                    //    }
                    //    else
                    //    {
                    //        dgvDuty.Rows[tmpInt1 - 1].Selected = true;
                    //    }
                    //}
                    #endregion
                }
                else if (buttonCaptionPanel15.CaptionTitle.CompareTo("返回") == 0)
                {
                    vsPanel2.Visible = false;
                }
            }
        }
        #endregion 

        #region "修改"和"删除"的单击事件

        private void dgvDuty_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataTable drTempDutyInfo;
            tmpInt1 = e.RowIndex;
            string strsql;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)                 //点击“修改”
            {
                textBox_DutyName.Enabled = false;
                ClearDutyInfo();                    //清空职务信息
                vsPanel2.Visible = true;
                buttonCaptionPanel13.CaptionTitle = "修改职务";
                buttonCaptionPanel14.CaptionTitle = "修改并返回";
                buttonCaptionPanel15.CaptionTitle = "返回";
                InitComboBoxDutyClass();            //初始化职务等级

                #region 绑定数据
                //tempDuty_ID = Convert.ToInt32(dtDutyInfo.Rows[e.RowIndex][0]);          //获取点击“删除”按钮的那一行的职务ID
                tempDuty_ID = Convert.ToInt32(dgvDuty.CurrentRow.Cells["DutyID"].Value);

                tempDuty_Name = dtDutyInfo.Rows[e.RowIndex][1].ToString();              //获取点击“删除”按钮的那一行的职务名                
                using (DataSet ds = dbll.GetIDDutyInfoTable(tempDuty_ID))
                {
                    if (ds != null)
                    {
                        drTempDutyInfo = ds.Tables[0];
                        if (drTempDutyInfo.Rows.Count == 1)
                        {
                            textBox_DutyName.Text = drTempDutyInfo.Rows[0][1].ToString();
                            comboBox_DutyClass.SelectedIndex = Convert.ToInt32(drTempDutyInfo.Rows[0][2].ToString()) - 1;
                            textBox_DutyRemark.Text = drTempDutyInfo.Rows[0][3].ToString();
                        }
                    }
                }
                #endregion
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)            //点击“删除”
            {
                operate = 2;

                //MessageBox.Show(dgvDuty.CurrentRow.Cells["职务名称"].Value.ToString());

                DialogResult result;
                result = MessageBox.Show("删除该职务，将会丢失绑定了该职务的员工信息，是否要删除？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "修改职务信息，职务名称：" + dtDutyInfo.Rows[e.RowIndex][1] + "。");

                    //tempDuty_ID = Convert.ToInt32(dtDutyInfo.Rows[e.RowIndex][0]);
                    tempDuty_ID = Convert.ToInt32(dgvDuty.CurrentRow.Cells["DutyID"].Value);

                    dbll.DeleteDuty(tempDuty_ID);

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewDuty();
                    }
                    else
                    {
                        timer1.Start();
                    }

                    dgvDuty.ClearSelection();
                    //if (tmpInt1 > 0)
                    //{
                    //    if (dgvDuty.Rows.Count >= tmpInt1 + 1)
                    //    {
                    //        dgvDuty.Rows[tmpInt1].Selected = true;
                    //    }
                    //    else
                    //    {
                    //        dgvDuty.Rows[tmpInt1 - 1].Selected = true;
                    //    }
                    //}
                }

            }
        }
        #endregion

        #region "职务信息管理"的单击事件

        private void cap_Duty_Click(object sender, EventArgs e)
        {
            model = 3;

            cap_WorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            cap_Cer.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            cap_Duty.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption;
            captionPanel5.CaptionTitle = "职务信息一览表";
            buttonCaptionPanel12.Visible = false;   //工种新增按钮
            buttonCaptionPanel10.Visible = false;   //证书新增按钮
            buttonCaptionPanel8.Visible = true;    //职务新增按钮
            dgvWorkType.Visible = false;
            dgvCertificate.Visible = false;
            dgvDuty.Visible = true;
            InitDataGridViewDuty();                 //初始化职务信息
        }
        #endregion

        #region 拖动
        private void buttonCaptionPanel13_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void buttonCaptionPanel13_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }
        private void buttonCaptionPanel13_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion
        #endregion
        #endregion

        #region 证书
        #region 方法
        #region 初始化证书信息

        /// <summary>
        /// 初始化证书信息

        /// </summary>
        private void InitDataGridViewCertificate()
        {
            string strSql = "select * from KJ128N_Certificate_Info_Table";
            dtCerInfo = dbll.GetDataTableCertificate(strSql);
            dgvCertificate.DataSource = dtCerInfo;
            dgvCertificate.ReadOnly = true;
            dgvCertificate.Columns[0].DisplayIndex = 7;
            dgvCertificate.Columns[1].DisplayIndex = 7;
            dgvCertificate.Columns[5].Visible = false;
            dgvCertificate.Columns[2].Width = 71;
            dgvCertificate.Columns[6].Width = 125;
            dgvCertificate.Columns["证书类别"].Visible = false;

        }
        #endregion
        #region 清空 增加证书信息
        /// <summary>
        /// 清空 增加证书信息
        /// </summary>
        void ClearCertificate()
        {
            comboBox_IsCheckExpDate.SelectedIndex = 0;
            textBox_CerName.Text = "";
            textBox_CerVestIn.Text = "";
            textBox_CertificateRemark.Text = "";
        }
        #endregion
        #region 验证 证书信息
        /// <summary>
        /// 验证证书信息
        /// </summary>
        /// <returns></returns>
        bool CheckingCertificate()
        {
            #region 验证证书名称不能为空
            if (textBox_CerName.Text.ToString().CompareTo("") == 0)
            {
                CerErorrInfo.CaptionTitle = String.Format("信息提示：没有输入职务名称,请输入职务名称!");
                textBox_CerName.Focus();
                textBox_CerName.SelectAll();
                return false;
            }
            #endregion
            return true;
        }
        #endregion
        #endregion

        #region 事件
        #region "关闭"按钮单击事件
        private void buttonCaptionPanel16_CloseButtonClick(object sender, EventArgs e)
        {
            vsPanel3.Visible = false; 
        }
        #endregion
        #region "修改"和"删除"的单击事件

        private void dgvCertificate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable drTempCerInfo;
            tmpInt2 = e.RowIndex;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)                 //点击“修改”
            {
                textBox_CerName.Enabled = false;

                vsPanel3.Visible = true;
                buttonCaptionPanel16.CaptionTitle = "修改证书";
                buttonCaptionPanel17.CaptionTitle = "修改并返回";
                buttonCaptionPanel18.CaptionTitle = "返回";
                #region 绑定数据
                //tempCer_ID = Convert.ToInt32(dtCerInfo.Rows[e.RowIndex][0]);          //获取点击“修改”按钮的那一行的职务ID
                tempCer_ID = Convert.ToInt32(dgvCertificate.CurrentRow.Cells["证书类别"].Value);          //获取点击“修改”按钮的那一行的职务ID
                
                using (DataSet ds = dbll.GetCertificateInfo(tempCer_ID))
                {
                    if (ds != null)
                    {
                        drTempCerInfo = ds.Tables[0];
                        if (drTempCerInfo.Rows.Count != 0)
                        {
                            textBox_CerName.Text = drTempCerInfo.Rows[0][1].ToString();
                            textBox_CerVestIn.Text = drTempCerInfo.Rows[0][2].ToString();
                            if (drTempCerInfo.Rows[0][3].ToString().CompareTo("") != 0)
                            {
                                comboBox_IsCheckExpDate.SelectedIndex = Convert.ToInt32(drTempCerInfo.Rows[0][3]);
                            }
                            textBox_CertificateRemark.Text = drTempCerInfo.Rows[0][4].ToString();
                        }
                    }
                }
                #endregion
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)            //点击“删除”
            {
                operate = 2;

                //MessageBox.Show(dgvCertificate.CurrentRow.Cells["证书名称"].Value.ToString());

                DialogResult result;
                result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "删除证书信息，工证书类别：" + dtCerInfo.Rows[e.RowIndex][0].ToString()
                        + "，证书名称：" + dtCerInfo.Rows[e.RowIndex][1].ToString() + "。");

                    tempCer_ID = Convert.ToInt32(dgvCertificate.CurrentRow.Cells["证书类别"].Value);          //获取点击“修改”按钮的那一行的职务ID
                
                    dbll.DeleteCertificate(tempCer_ID);

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewCertificate();          //初始化证书信息
                    }
                    else
                    {
                        timer1.Start();
                    }


                    dgvCertificate.ClearSelection();
                    //if (tmpInt2 > 0)
                    //{
                    //    if (dgvCertificate.Rows.Count >= tmpInt2 + 1)
                    //    {
                    //        dgvCertificate.Rows[tmpInt2].Selected = true;
                    //    }
                    //    else
                    //    {
                    //        dgvCertificate.Rows[tmpInt2 - 1].Selected = true;
                    //    }
                    //}
                }

            }
        }
        #endregion
        #region "新增"按钮的单击事件
        private void buttonCaptionPanel10_Click(object sender, EventArgs e)
        {
            textBox_CerName.Enabled = true;
            vsPanel3.Visible = true;
            buttonCaptionPanel16.CaptionTitle = "增加证书";
            buttonCaptionPanel17.CaptionTitle = "存储并新增";
            buttonCaptionPanel18.CaptionTitle = "存储并返回";
            ClearCertificate();
        }
        #endregion
        #region "存储并新增"和"修改并返回"按钮的单击事件

        private void buttonCaptionPanel17_Click(object sender, EventArgs e)
        {
            if(CheckingCertificate())
            {
                operate = 1;

                if (buttonCaptionPanel17.CaptionTitle.CompareTo("存储并新增") == 0)
                {
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "增加证书信息，证书名称：" + textBox_CerName.Text.ToString() + "。");

                    dbll.SaveCertificateData(textBox_CerName.Text.ToString(), textBox_CerVestIn.Text.ToString(), comboBox_IsCheckExpDate.SelectedIndex, textBox_CertificateRemark.Text);
                    //InitDataGridViewCertificate();
                    cer = textBox_CerName.Text;
                    CerErorrInfo.CaptionTitle = String.Format("信息提示：一切正常!");
                    MessageBox.Show("证书信息增加成功!");
                    ClearCertificate();

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewCertificate();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
                else if (buttonCaptionPanel17.CaptionTitle.CompareTo("修改并返回") == 0)
                {
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "修改证书信息，证书编号：" + tempCer_ID.ToString() + "，证书名称：" + textBox_CerName.Text.ToString() + "。");
                    cer = textBox_CerName.Text;
                    dbll.UpDateCertificate(tempCer_ID, textBox_CerName.Text, textBox_CerVestIn.Text, comboBox_IsCheckExpDate.SelectedIndex, textBox_CertificateRemark.Text);
                    vsPanel3.Visible = false;
                    MessageBox.Show("证书信息修改成功");
                    operate = 1;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewCertificate();
                    }
                    else
                    {
                        timer1.Start();
                    }

                }
                dgvCertificate.ClearSelection();
                //if (tmpInt2 > 0)
                //{
                //    if (dgvCertificate.Rows.Count >= tmpInt2 + 1)
                //    {
                //        dgvCertificate.Rows[tmpInt2].Selected = true;
                //    }
                //    else
                //    {
                //        dgvCertificate.Rows[tmpInt2 - 1].Selected = true;
                //    }
                //}
            }
        }
        #endregion
        #region "存储并返回"和"返回"按钮的单击事件

        private void buttonCaptionPanel18_Click(object sender, EventArgs e)
        {
            if (CheckingCertificate())
            {
                if (buttonCaptionPanel18.CaptionTitle.CompareTo("存储并返回") == 0)
                {
                    operate = 1;

                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "增加证书信息，证书名称：" + textBox_CerName.Text.ToString() + "。");

                    dbll.SaveCertificateData(textBox_CerName.Text.ToString(), textBox_CerVestIn.Text.ToString(), comboBox_IsCheckExpDate.SelectedIndex, textBox_CertificateRemark.Text);
                    cer = textBox_CerName.Text;
                    CerErorrInfo.CaptionTitle = String.Format("信息提示：一切正常!");
                    MessageBox.Show("证书信息增加成功!");
                    vsPanel3.Visible = false;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewCertificate();
                    }
                    else
                    {
                        timer1.Start();
                    }

                    dgvCertificate.ClearSelection();
                    //if (tmpInt2 > 0)
                    //{
                    //    if (dgvCertificate.Rows.Count >= tmpInt2 + 1)
                    //    {
                    //        dgvCertificate.Rows[tmpInt2].Selected = true;
                    //    }
                    //    else
                    //    {
                    //        dgvCertificate.Rows[tmpInt2 - 1].Selected = true;
                    //    }
                    //}
                }
                else if (buttonCaptionPanel18.CaptionTitle.CompareTo("返回") == 0)
                {
                    vsPanel3.Visible = false;
                }
            }
        }
        #endregion
        #region "证书信息管理"的单击事件
        private void cap_Cer_Click(object sender, EventArgs e)
        {
            model = 2;

            cap_WorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            cap_Cer.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption;
            cap_Duty.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            captionPanel5.CaptionTitle = "证书信息一览表";
            buttonCaptionPanel12.Visible = false;   //工种新增按钮
            buttonCaptionPanel10.Visible = true;   //证书新增按钮
            buttonCaptionPanel8.Visible = false;    //职务新增按钮
            dgvWorkType.Visible = false;
            dgvCertificate.Visible = true;
            dgvDuty.Visible = false;
            InitDataGridViewCertificate();          //初始化证书信息
        }
        #endregion

        #region 拖动
        private void buttonCaptionPanel16_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
            mleft = e.Location.X;
            mtop = e.Location.Y;
        }

        private void buttonCaptionPanel16_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                VSPanel p = (VSPanel)((CaptionPanel)sender).Parent;
                p.Location = new Point(p.Left + e.Location.X - mleft, p.Top + e.Location.Y - mtop);
            }
        }
        private void buttonCaptionPanel16_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion

        #endregion
        #endregion

        #region 工种
        #region 方法
        #region 初始化工种信息
        /// <summary>
        /// 初始化工种信息
        /// </summary>
        private void InitDataGridViewWorkType()
        {
            string strSql = "select * from KJ128N_WorkType_Info_Table";
            dtWorkInfo= dbll.GetDataTableWorkType(strSql);

            dgvWorkType.DataSource = dtWorkInfo;
            dgvWorkType.ReadOnly = true;
            dgvWorkType.Columns[0].DisplayIndex = 11;
            dgvWorkType.Columns[1].DisplayIndex = 11;
            dgvWorkType.Columns[4].Visible = false;
            dgvWorkType.Columns[9].Visible = false;
            dgvWorkType.Columns[10].Visible = false;
            dgvWorkType.Columns[11].Visible = false;
            dgvWorkType.Columns[2].Width = 60;
            dgvWorkType.Columns[3].Width = 80;
            dgvWorkType.Columns[5].Width = 80;
            dgvWorkType.Columns[6].Width = 90;
            dgvWorkType.Columns[7].Width = 90;
            dgvWorkType.Columns["工种编号"].Visible = false;
            dgvWorkType.AutoSize = true;
        }
        #endregion

        #region 初始化证书名称
        /// <summary>
        /// 初始化证书名称
        /// </summary>
        private void InitComboBoxCerName()
        {
            dbll.GetWorkCerCmb(comboBox_CerTypeName);           
        }
        #endregion

        #region 清空 工种信息
        /// <summary>
        /// 清空工种信息
        /// </summary>
        void ClearWork()
        {
            textBox_WtName.Text = "";
            InitComboBoxCerName();
            textBox_WorkMaxHour.Text = "10";
            textBox_WorkMaxMinute.Text = "0";
            textBox_WorkMaxSecond.Text = "0";
            textBox_WorkMinHour.Text = "0";
            textBox_WorkMinMinute.Text = "0";
            textBox_WorkMinSecond.Text = "0";
            textBox_WorkRemark.Text = "";
        }
        #endregion

        #region 验证 工种信息
        /// <summary>
        /// 验证工种信息
        /// </summary>
        /// <returns></returns>
        bool CheckingWork()
        {
            string sqlString;
            #region 验证工种名称不能为空
            if (textBox_WtName.Text.ToString().CompareTo("") == 0)
            {
                WorkErorrInfo.CaptionTitle = String.Format("信息提示：没有输入工种名称,请输入工种名称!");
                WorkErorrInfo.ForeColor = Color.Red;
                textBox_WtName.Focus();
                textBox_WtName.SelectAll();
                return false;
            }
            #endregion
            #region 验证工种名称的唯一性

            if (!(buttonCaptionPanel21.CaptionTitle.CompareTo("修改并返回") == 0 && textBox_WtName.Text.CompareTo(tempWork_Name) == 0))
            {
                using (DataSet ds = dbll.GetNameWorkTypeInfoTable(textBox_WtName.Text.ToString()))
                {
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count != 0)
                        {
                            WorkErorrInfo.CaptionTitle = String.Format("信息提示：工种名称已存在,请重新输入工种名称!");
                            textBox_WtName.Focus();
                            textBox_WtName.SelectAll();
                            return false;
                        }
                    }
                }
            }
            #endregion
            #region 验证是否有证书信息
            if (comboBox_CerTypeName.DataSource == null)
            {
                WorkErorrInfo.CaptionTitle = String.Format("信息提示：未输入证书信息，请先增加证书信息！");
                return false;
            }
            #endregion
            #region 验证 最小工作时间、最大工作时间
            
            if (textBox_WorkMaxHour.Text == string.Empty)
            {
                WorkErorrInfo.CaptionTitle = String.Format("信息提示：请输入最大工作时间！");
                textBox_WorkMaxHour.Focus();
                textBox_WorkMaxHour.SelectAll();
                return false;
            }
            else if (textBox_WorkMaxMinute.Text == string.Empty)
            {
                WorkErorrInfo.CaptionTitle = String.Format("信息提示：请输入最大工作时间！");
                textBox_WorkMaxMinute.Focus();
                textBox_WorkMaxMinute.SelectAll();
                return false;
            }
            else if (textBox_WorkMaxSecond.Text == string.Empty)
            {
                WorkErorrInfo.CaptionTitle = String.Format("信息提示：请输入最大工作时间！");
                textBox_WorkMaxSecond.Focus();
                textBox_WorkMaxSecond.SelectAll();
                return false;
            }
            else if (textBox_WorkMinHour.Text == string.Empty)
            {
                WorkErorrInfo.CaptionTitle = String.Format("信息提示：请输入最小工作时间！");
                textBox_WorkMinHour.Focus();
                textBox_WorkMinHour.SelectAll();
                return false;
            }
            else if (textBox_WorkMinMinute.Text == string.Empty)
            {
                WorkErorrInfo.CaptionTitle = String.Format("信息提示：请输入最小工作时间！");
                textBox_WorkMinMinute.Focus();
                textBox_WorkMinMinute.SelectAll();
                return false;
            }
            else if (textBox_WorkMinSecond.Text == string.Empty)
            {
                WorkErorrInfo.CaptionTitle = String.Format("信息提示：请输入最小工作时间！");
                textBox_WorkMinSecond.Focus();
                textBox_WorkMinSecond.SelectAll();
                return false;
            }

            int intMax, intMin;
            intMax = Convert.ToInt32(textBox_WorkMaxHour.Text) * 3600 + Convert.ToInt32(textBox_WorkMaxMinute.Text) * 60 + Convert.ToInt32(textBox_WorkMaxSecond.Text);
            intMin = Convert.ToInt32(textBox_WorkMinHour.Text) * 3600 + Convert.ToInt32(textBox_WorkMinMinute.Text) * 60 + Convert.ToInt32(textBox_WorkMinSecond.Text);

            if (intMax < intMin)
            {
                WorkErorrInfo.CaptionTitle = String.Format("信息提示：最小工作时间不能大于最大工作时间！");
                textBox_WorkMinHour.Focus();
                textBox_WorkMinHour.SelectAll();
                return false;
            }

            #endregion
            return true;
        }
        #endregion

        #region 【方法: 增加工种信息 】

        /// <summary>
        /// 增加工种信息
        /// </summary>
        /// <returns></returns>
        private bool SaveWorkTypeInfo()
        {
            int intValue = 0;

            intValue = dbll.SaveWorkData(textBox_WtName.Text, dbll.GetCerID(comboBox_CerTypeName.Text), textBox_WorkRemark.Text,
                Convert.ToInt32(textBox_WorkMaxHour.Text), Convert.ToInt32(textBox_WorkMaxMinute.Text), 
                Convert.ToInt32(textBox_WorkMaxSecond.Text), Convert.ToInt32(textBox_WorkMinHour.Text), 
                Convert.ToInt32(textBox_WorkMinMinute.Text), Convert.ToInt32(textBox_WorkMinSecond.Text));
            if (intValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 【方法: 修改工种信息 】

        /// <summary>
        /// 修改工种信息
        /// </summary>
        /// <returns></returns>
        private bool UpdateWorkTypeInfo()
        {
            int intValue = 0;

            intValue = dbll.UpDateWorkType(textBox_WtName.Text, dbll.GetCerID(comboBox_CerTypeName.Text), textBox_WorkRemark.Text,
                Convert.ToInt32(textBox_WorkMaxHour.Text), Convert.ToInt32(textBox_WorkMaxMinute.Text),
                Convert.ToInt32(textBox_WorkMaxSecond.Text), Convert.ToInt32(textBox_WorkMinHour.Text),
                Convert.ToInt32(textBox_WorkMinMinute.Text), Convert.ToInt32(textBox_WorkMinSecond.Text));
            if (intValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #endregion

        #region 事件
        #region "关闭"按钮的单击事件
        private void buttonCaptionPanel19_CloseButtonClick(object sender, EventArgs e)
        {
            vsPanel4.Visible = false;
        }
        #endregion

        #region "新增"按钮的单击事件
        private void buttonCaptionPanel12_Click(object sender, EventArgs e)
        {
            textBox_WtName.Enabled = true;

            vsPanel4.Visible = true;
            textBox_WtName.Enabled = true;

            buttonCaptionPanel19.CaptionTitle = "增加工种";
            buttonCaptionPanel21.CaptionTitle = "存储并新增";
            buttonCaptionPanel22.CaptionTitle = "存储并返回";
            ClearWork();
        }
        #endregion

        #region "存储并新增"和"修改并返回"按钮的单击事件
        private void buttonCaptionPanel21_Click(object sender, EventArgs e)
        {
            
            if (CheckingWork())
            {
                if (!CheckTimeN())
                {
                    return;
                }

                operate = 1;

                if (buttonCaptionPanel21.CaptionTitle.CompareTo("存储并新增") == 0)
                {
                    
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "添加工种信息，工种名称：" + textBox_WtName.Text + "，证书名称：" + comboBox_CerTypeName.Text + "。");

                    //添加工种信息
                    SaveWorkTypeInfo();

                    worktype = textBox_WtName.Text;

                    WorkErorrInfo.CaptionTitle = String.Format("信息提示：一切正常!");
                    MessageBox.Show("工种信息增加成功!");
                    ClearWork();

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewWorkType();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
                else if (buttonCaptionPanel21.CaptionTitle.CompareTo("修改并返回") == 0)
                {
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "修改工种信息，工种名称：" + textBox_WtName.Text + "，证书名称：" + comboBox_CerTypeName.Text + "。");

                    //修改工种信息
                    UpdateWorkTypeInfo();
                    
                    vsPanel4.Visible = false;
                    //InitDataGridViewWorkType();          //初始化工种信息
                    worktype = textBox_WtName.Text;
                    MessageBox.Show("工种信息修改成功!");

                    operate = 1;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewWorkType();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
                //dgvWorkType.ClearSelection();
                //if (tmpInt3 > 0)
                //{
                //    if (dgvWorkType.Rows.Count >= tmpInt3 + 1)
                //    {
                //        dgvWorkType.Rows[tmpInt3].Selected = true;
                //    }
                //    else
                //    {
                //        dgvWorkType.Rows[tmpInt3 - 1].Selected = true;
                //    }
                //}
            }
        }
        #endregion

        #region "存储并返回"和"返回"按钮的单击事件
        private void buttonCaptionPanel22_Click(object sender, EventArgs e)
        {
            if (CheckingWork())
            {
                if (buttonCaptionPanel22.CaptionTitle.CompareTo("存储并返回") == 0)
                {
                    if (!CheckTimeN())
                    {
                        return;
                    }

                    operate = 1;

                    //添加工种信息
                    SaveWorkTypeInfo();

                    //#region 添加 工种信息
                    //dbll.SaveWorkData(textBox_WtName.Text, dbll.GetCerID(comboBox_CerTypeName.Text), textBox_WorkRemark.Text);
                    //#endregion
                    //#region 添加 工种配置信息
                    //dbll.SaveWorkSysSetData(textBox_WtName.Text.Trim(), Convert.ToInt32(textBox_WorkMaxHour.Text), Convert.ToInt32(textBox_WorkMaxMinute.Text), Convert.ToInt32(textBox_WorkMaxSecond.Text), Convert.ToInt32(textBox_WorkMinHour.Text), Convert.ToInt32(textBox_WorkMinMinute.Text), Convert.ToInt32(textBox_WorkMinSecond.Text));
                    //#endregion

                    WorkErorrInfo.CaptionTitle = String.Format("信息提示：一切正常!");
                    MessageBox.Show("工种信息增加成功!");
                    vsPanel4.Visible = false;

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewWorkType();
                    }
                    else
                    {
                        timer1.Start();
                    }

                    dgvWorkType.ClearSelection();
                    //if (tmpInt3 > 0)
                    //{
                    //    if (dgvWorkType.Rows.Count >= tmpInt3 + 1)
                    //    {
                    //        dgvWorkType.Rows[tmpInt3].Selected = true;
                    //    }
                    //    else
                    //    {
                    //        dgvWorkType.Rows[tmpInt3 - 1].Selected = true;
                    //    }
                    //}
                }
                else if (buttonCaptionPanel22.CaptionTitle.CompareTo("返回") == 0)
                {
                    vsPanel4.Visible = false;
                }
            }
        }
        #endregion

        #region "修改"和"删除"的单击事件
        private void dgvWorkType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable drTempWorkInfo;
            string strsql;
            tmpInt3 = e.RowIndex;
            if (e.ColumnIndex == 0 && e.RowIndex>=0)                 //点击“修改”
            {
                textBox_WtName.Enabled = false;
                vsPanel4.Visible = true;
                
                //不允许用户修改工种名称
                textBox_WtName.Enabled = false;

                buttonCaptionPanel19.CaptionTitle = "修改工种";
                buttonCaptionPanel21.CaptionTitle = "修改并返回";
                buttonCaptionPanel22.CaptionTitle = "返回";
                InitComboBoxCerName();
                #region 绑定数据
                //tempWork_ID = Convert.ToInt32(dtWorkInfo.Rows[e.RowIndex][0]);          //获取点击“修改”按钮的那一行的职务ID

                tempWork_ID = Convert.ToInt32(dgvWorkType.CurrentRow.Cells["工种编号"].Value);

                using (DataSet ds = dbll.GetIDWorkTypeInfoTable(tempWork_ID))
                {
                    if (ds != null)
                    {
                        drTempWorkInfo = ds.Tables[0];
                        if (drTempWorkInfo.Rows.Count != 0)
                        {
                            tempWork_Name = drTempWorkInfo.Rows[0][1].ToString();
                            textBox_WtName.Text = drTempWorkInfo.Rows[0][1].ToString();
                            comboBox_CerTypeName.Text = drTempWorkInfo.Rows[0][3].ToString();                    
                            #region 计算最大工作时间

                            if (drTempWorkInfo.Rows[0][5].ToString().CompareTo("") == 0)
                            {
                                textBox_WorkMaxHour.Text = "";
                                textBox_WorkMaxMinute.Text = "";
                                textBox_WorkMaxSecond.Text = "";
                            }
                            else
                            {
                                int intMax = Convert.ToInt32(drTempWorkInfo.Rows[0][5]);
                                int hourMax = intMax / 3600;
                                int minuteMax = (intMax - hourMax * 3600) / 60;
                                int secondMax = intMax % 60;
                                textBox_WorkMaxHour.Text = hourMax.ToString();
                                textBox_WorkMaxMinute.Text = minuteMax.ToString();
                                textBox_WorkMaxSecond.Text = secondMax.ToString();
                            }
                            #endregion
                            #region 计算最小工作时间

                            if (drTempWorkInfo.Rows[0][6].ToString().CompareTo("") == 0)
                            {
                                textBox_WorkMinHour.Text = "";
                                textBox_WorkMinMinute.Text = "";
                                textBox_WorkMinSecond.Text = "";
                            }
                            else
                            {
                                int intMin = Convert.ToInt32(drTempWorkInfo.Rows[0][6]);
                                int hourMin = intMin / 3600;
                                int minuteMin = (intMin - hourMin * 3600) / 60;
                                int secondMin = intMin % 60;
                                textBox_WorkMinHour.Text = hourMin.ToString();
                                textBox_WorkMinMinute.Text = minuteMin.ToString();
                                textBox_WorkMinSecond.Text = secondMin.ToString();
                            }
                            #endregion
                            textBox_WorkRemark.Text=drTempWorkInfo.Rows[0][4].ToString();                        
                        }
                    }
                }
                #endregion
            }
            else if (e.ColumnIndex == 1 && e.RowIndex>=0)            //点击“删除”
            {
                operate = 2;

                //MessageBox.Show(dgvWorkType.CurrentRow.Cells["工种名称"].Value.ToString());

                DialogResult result;
                result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //存入日志
                    LogSave.Messages("[FrmDepartmentManage]", LogIDType.UserLogID, "删除工种信息，工种名称："
                        + dtWorkInfo.Rows[e.RowIndex][1] + "，证书名称：" + dtWorkInfo.Rows[e.RowIndex][2] + "。");

                    //tempWork_ID = Convert.ToInt32(dtWorkInfo.Rows[e.RowIndex][0]);    //获取点击“删除”按钮的那一行的职务ID

                    tempWork_ID = Convert.ToInt32(dgvWorkType.CurrentRow.Cells["工种编号"].Value);

                    dbll.DeleteWork(tempWork_ID);

                    if (!New_DBAcess.IsDouble)
                    {
                        InitDataGridViewWorkType();         //初始化工种信息
                    }
                    else
                    {
                        timer1.Start();
                    }

                    //dgvWorkType.ClearSelection();
                    //if (tmpInt3 > 0)
                    //{
                    //    if (dgvWorkType.Rows.Count >= tmpInt3 + 1)
                    //    {
                    //        dgvWorkType.Rows[tmpInt3].Selected = true;
                    //    }
                    //    else
                    //    {
                    //        dgvWorkType.Rows[tmpInt3 - 1].Selected = true;
                    //    }
                    //}
                }

            }
        }
        #endregion

        #region "工种信息管理"的单击事件

        private void cap_WorkType_Click(object sender, EventArgs e)
        {
            model = 1;

            cap_WorkType.SetCaptionPanelStyle = CaptionPanelStyleEnum.BlueCaption;
            cap_Cer.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            cap_Duty.SetCaptionPanelStyle = CaptionPanelStyleEnum.paleCaptionNoBorder;
            captionPanel5.CaptionTitle = "工种信息一览表";
            buttonCaptionPanel12.Visible = true;   //工种新增按钮
            buttonCaptionPanel10.Visible = false;   //证书新增按钮
            buttonCaptionPanel8.Visible = false;    //职务新增按钮
            dgvWorkType.Visible = true;
            dgvCertificate.Visible = false;
            dgvDuty.Visible = false;
            InitDataGridViewWorkType();  
            //初始化工种信息

        }
        #endregion

        #region 拖动
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
        #endregion

        #region 改变窗体大小时
        private void FrmDepartmentManage_Resize(object sender, EventArgs e)
        {
            //int tempWidth1, tempWidth2, tempWidth3;


            //#region 改变职务信息DataGird的大小

            //tempWidth1 = dgvDuty.Columns[0].Width + dgvDuty.Columns[1].Width + dgvDuty.Columns[2].Width + dgvDuty.Columns[3].Width + dgvDuty.Columns[4].Width + dgvDuty.Columns[6].Width;
            //if (dgvCertificate.Size.Width > tempWidth1)
            //{
            //    dgvDuty.Columns[6].Width = dgvDuty.Columns[6].Width + dgvDuty.Size.Width - tempWidth1 - 3;
            //}
            //else
            //{
            //    dgvDuty.Columns[6].Width = 195;
            //}
            //#endregion
            //#region 改变证书信息DataGird的大小
            //tempWidth2 = dgvCertificate.Columns[0].Width + dgvCertificate.Columns[1].Width + dgvCertificate.Columns[2].Width + dgvCertificate.Columns[3].Width + dgvCertificate.Columns[4].Width + dgvCertificate.Columns[6].Width + dgvCertificate.Columns[7].Width;
            //if (dgvCertificate.Size.Width > tempWidth2)
            //{
            //    dgvCertificate.Columns[7].Width = dgvCertificate.Columns[7].Width + dgvCertificate.Size.Width - tempWidth2 -3;
            //}
            //else
            //{
            //    dgvCertificate.Columns[7].Width = 100;
            //}
            //#endregion
            //#region 改变工种信息DataGird的大小
            //tempWidth3 = dgvWorkType.Columns[0].Width + dgvWorkType.Columns[1].Width + dgvWorkType.Columns[2].Width + dgvWorkType.Columns[3].Width + dgvWorkType.Columns[5].Width + dgvWorkType.Columns[6].Width + dgvWorkType.Columns[7].Width + dgvWorkType.Columns[8].Width;
            //if (dgvWorkType.Size.Width > tempWidth3)
            //{
            //    dgvWorkType.Columns[8].Width = dgvWorkType.Columns[8].Width + dgvWorkType.Size.Width - tempWidth3-1;
            //}
            //else
            //{
            //    dgvWorkType.Columns[8].Width = 100;
            //}
            //#endregion

        }
        #endregion

        #region [ 事件: 工种、职务、证书信息导出Excel ]

        private void bcp_Work_Click(object sender, EventArgs e)
        {
            if (cap_WorkType.SetCaptionPanelStyle == CaptionPanelStyleEnum.BlueCaption)      //导出工种信息
            {
                PrintBLL.Print(dgvWorkType, Text);
                //ExcelExports.ExportDataGridViewToExcel(dgvWorkType);
            }
            else if(cap_Cer.SetCaptionPanelStyle == CaptionPanelStyleEnum.BlueCaption)       //导出证书信息
            {
                PrintBLL.Print(dgvCertificate, Text);
                //ExcelExports.ExportDataGridViewToExcel(dgvCertificate);
            }
            else if (cap_Duty.SetCaptionPanelStyle == CaptionPanelStyleEnum.BlueCaption)     //导出职务信息
            {
                PrintBLL.Print(dgvDuty,Text);
                //ExcelExports.ExportDataGridViewToExcel(dgvDuty);
            }
        }

        #endregion

        #region [ 事件: 打印 ]

        private void buttonCaptionPanel7_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvDepartment,Text);
        }

        #endregion

        #region [ 事件: 防止输入"'" ]

        private void textBox_DeptLeadName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'")
            {
                e.Handled = true;
            }
        }

        private void textBox_DeptNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }

        private void textBox_DeptName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
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
        /// 1表示增加，修改 2 表示删除 
        /// </summary>
        private int operate = 1;

        /// <summary>
        /// 检测是哪个模块触发
        /// 1是工种 2是证书 3是职务
        /// </summary>
        private int model = 2;


        private string worktype = "";

        private string cer = "";

        private string duty = "";

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (model)
            {
                //工种
                case 1:

                    if (operate == 1)
                    {
                        if (RecordSearch.IsRecordExists("WorkType_Info", "WtName", worktype, DataType.String))
                        {
                            //刷新

                            InitDataGridViewWorkType();
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                        else
                        {
                            if (times < maxTimes)
                            {
                                times++;
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
                    }
                    else
                    {
                        string valueWT = dgvWorkType.CurrentRow.Cells["工种名称"].Value.ToString();

                        if (!RecordSearch.IsRecordExists("WorkType_Info", "WtName", valueWT, DataType.String))
                        {
                            //刷新

                            InitDataGridViewWorkType();
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                        else
                        {
                            if (times < maxTimes)
                            {
                                times++;
                                //timer1_Tick(sender, e);
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
                    }

                    break;

                //证书
                case 2:

                    if (operate == 1)
                    {
                        if (RecordSearch.IsRecordExists("Certificate_Info", "CerName", cer, DataType.String))
                        {
                            //刷新

                            InitDataGridViewCertificate();

                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                        else
                        {
                            if (times < maxTimes)
                            {
                                times++;
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
                    }
                    else
                    {
                        string valueCer = dgvCertificate.CurrentRow.Cells["证书名称"].Value.ToString();

                        if (!RecordSearch.IsRecordExists("Certificate_Info", "CerName", valueCer, DataType.String))
                        {
                            //刷新

                            InitDataGridViewCertificate();

                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                        else
                        {
                            if (times < maxTimes)
                            {
                                times++;
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
                    }

                    break;

                //职务
                case 3:

                    if (operate == 1)
                    {
                        if (RecordSearch.IsRecordExists("Duty_Info", "DutyName", duty, DataType.String))
                        {
                            //刷新


                            InitDataGridViewDuty();
                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                        else
                        {
                            if (times < maxTimes)
                            {
                                times++;
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
                    }
                    else
                    {
                        string valueDuty = dgvDuty.CurrentRow.Cells["职务名称"].Value.ToString();
                        if (RecordSearch.IsRecordExists("Duty_Info", "DutyName", valueDuty, DataType.String))
                        {
                            //刷新

                            InitDataGridViewDuty();

                            times = 0;
                            //关闭timer1
                            timer1.Stop();
                        }
                        else
                        {
                            if (times < maxTimes)
                            {
                                times++;
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
                    }

                    break;

                default:
                    break;
            }
        }

        private void timerDept_Tick(object sender, EventArgs e)
        {
            if (operate == 1)
            {
                if (RecordSearch.IsRecordExists("Dept_Info", "DeptNO", textBox_DeptNO.Text, DataType.String))
                {
                    //刷新

                    //重新初始化部门树
                    InitTreeViewDepartment();

                    //初始化部门信息
                    InitDataGridViewDepartment();

                    //初始化上级部门名称
                    SetComboBoxParentDept();

                    times = 0;
                    //关闭timer1
                    timerDept.Stop();
                }
                else
                {
                    if (times < maxTimes)
                    {
                        times++;
                        timerDept_Tick(sender, e);
                    }
                    else
                    {
                        times = 0;
                        //关闭timer1
                        timerDept.Stop();
                    }
                }
            }
            else
            {
                if (times < maxTimes)
                {
                    //刷新

                    //重新初始化部门树
                    InitTreeViewDepartment();

                    //初始化部门信息
                    InitDataGridViewDepartment();

                    //初始化上级部门名称
                    SetComboBoxParentDept();

                    times++;
                    timerDept.Stop();
                    timerDept.Start();
                }
                else
                {
                    times = 0;
                    //关闭timer1
                    timerDept.Stop();
                }
                
            }

        }

        #endregion

        #region 【 事件: 刷新工种、证书、职务信息 】
        private void buttonCaptionPanel11_Click(object sender, EventArgs e)
        {
            if (cap_WorkType.SetCaptionPanelStyle == CaptionPanelStyleEnum.BlueCaption)      
            {
                //刷新工种信息
                InitDataGridViewWorkType();
            }
            else if(cap_Cer.SetCaptionPanelStyle == CaptionPanelStyleEnum.BlueCaption)      
            {
                //刷新证书信息
                InitDataGridViewCertificate();

            }
            else if (cap_Duty.SetCaptionPanelStyle == CaptionPanelStyleEnum.BlueCaption)    
            {
                //刷新职务信息
                InitDataGridViewDuty();
            }
        }

        #endregion

        #region 【 事件: 刷新部门信息 】

        private void buttonCaptionPanel9_Click(object sender, EventArgs e)
        {
            //重新初始化部门树
            InitTreeViewDepartment();

            //初始化部门信息
            InitDataGridViewDepartment();

            //初始化上级部门名称
            SetComboBoxParentDept();
        }

        #endregion
    }

    
}