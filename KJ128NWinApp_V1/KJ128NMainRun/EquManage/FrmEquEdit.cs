using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using KJ128NDataBase;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.EquManage
{
    public partial class FrmEquEdit : Wilson.Controls.Docking.DockContent
    {
        EquBLL equDAL = new EquBLL();
        DeptBLL deptBll = new DeptBLL();
        DataTable dtEqu = null;
        DataTable dtDetail = null;
        public FrmEquEdit()
        {
            InitializeComponent();
            Init();
        }

        #region 初始化绑定

        public void Init()
        {
            BindDept();
            BindType();
            BindState();
            BindFactory();
            txtEquHeight.Text = "0";
            txtEquPower.Text = "0";
        }

        #region 绑定
        // 绑定部门
        public void BindDept()
        {
            deptBll.getDept(cmbDeptID);
        }

        // 设备类型
        public void BindType()
        {
            deptBll.getEquType(cmbEquType);
        }

        // 设备状态
        public void BindState()
        {
            deptBll.getEquState(cmbEquState);
        }

        // 生产厂家
        public void BindFactory()
        {
            deptBll.getFactory(cmbFactoryID);
        }
        #endregion 

        #endregion

        #region 判断是添加还是修改
        /// <summary>
        /// 判断是添加还是修改
        /// </summary>
        public void GetValue()
        {
            if (this.Text == "修改设备信息")
            { 
                // 修改
                btnEdit.Text = "修改";
                ShowValue();
            }
            else
            { 
                // 添加
                btnEdit.Text = "添加";
            }
        }
        #endregion 

        #region 赋值
        /// <summary>
        /// 赋值
        /// </summary>
        public void ShowValue()
        {
            if (dtEqu == null) return;
            if (dtEqu.Rows.Count > 0)
            {
                // 给所以控件赋值
                DataRow dr = dtEqu.Rows[0];
                // 给必填的赋值
                txtEquNO.Text = dr["EquNO"].ToString();
                txtEquName.Text = dr["EquName"].ToString();
                
                // 判断部门是否添加
                cmbDeptID.SelectedValue = dr["DeptID"].ToString();

                // 判断生产厂家是否添加
                cmbFactoryID.SelectedValue = dr["FactoryID"].ToString();
                
                cmbEquState.SelectedValue = dr["EquState"].ToString();
                cmbEquType.SelectedValue = dr["EquType"].ToString();
                txtRemark.Text = dr["Remark"].ToString();
            }

            if (dtDetail == null) return;
            if (dtDetail.Rows.Count > 0)
            {
                DataRow dr = dtDetail.Rows[0];
                txtModelSpecial.Text = dr["ModelSpecial"].ToString();
                txtDutyEmployee.Text = dr["DutyEmployee"].ToString();
                dtimeProductionDate.Text = dr["ProductionDate"].ToString();
                txtEquHeight.Text = dr["EquHeight"].ToString() == "0" ? "" : dr["EquHeight"].ToString();
                txtEquPower.Text = dr["EquPower"].ToString() == "0" ? "" : dr["EquPower"].ToString();
                txtUseRange.Text = dr["UseRange"].ToString();
                dtimeUserDate.Text = dr["UserDate"].ToString();
            }
        }
        #endregion 

        #region 清空
        /// <summary>
        /// 清空
        /// </summary>
        public void ClearCon()
        { 
            foreach (Control ctl in Controls)
            {
                if(ctl.GetType() == typeof(TextBox))
                {
                    ctl.Text = "";
                }
            }
            dtimeProductionDate.Text = DateTime.Now.ToString("yyyy年M月d日");
            dtimeUserDate.Text = DateTime.Now.ToString("yyyy年M月d日");
        }
        #endregion

        #region ShowDialog

        public void ShowDialog(DataTable dt,DataTable dtD)
        {
            dtEqu = dt;
            dtDetail = dtD;
            GetValue();
            ShowDialog();
        }
        #endregion

        #region 按钮事件

        #region 收缩功能
        // 收缩功能
        private void plEqu_BaseInfo_ShiftButtonMouseClick(object sender, EventArgs e)
        {
            vsPanel.RainRangeControl();
            vsPanel.Height = vsPanel.Controls[vsPanel.Controls.Count - 1].Top + vsPanel.Controls[vsPanel.Controls.Count - 1].Height + 10;
            this.Height = vsPanel.Height + 50;
        }
        #endregion 

        #region 返回，取消
        // 返回
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 取消
        private void btnCanel_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "修改")
            { 
                // 修改(重新加载)
                ShowValue();
            }
            else
            { 
                // 清空
                ClearCon();
            }
        }
        #endregion 

        #region 是否填写完整
        /// <summary>
        /// 是否填写完整
        /// </summary>
        /// <returns>0为填写完整</returns>
        public int  IsFull()
        {
            int i = 0;
            foreach (Control ctl in plEqu_BaseInfo.Controls)
            {
                if (ctl.GetType() == typeof(ComboBox))
                {
                    if (ctl.Text == "")
                    {
                        ctl.BackColor = Color.Yellow;
                        i++;
                    }
                    else
                    {
                        ctl.BackColor = Color.Empty;
                    }
                }
            }
            return i;
        }
        #endregion

        #region 确定
        // 确定
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 判断是否填写完整
            if (IsFull() != 0)
            {
                return;
            }

            if (txtEquHeight.Text.Trim() == "")
            {
                MessageBox.Show("重量不能为空！");
                return;
            }
            if (this.txtEquPower.Text.Trim() == "")
            {
                MessageBox.Show("功耗不能为空！");
                return;
            }
            try
            {
                int.Parse(txtEquHeight.Text);
            }
            catch
            {
                MessageBox.Show("重量只能为数字!");
                return;
            }
            if (btnEdit.Text == "修改")
            {
                //存入日志
                LogSave.Messages("[FrmEquEdit]", LogIDType.UserLogID, "修改设备信息，生产厂家：" + cmbFactoryID.SelectedText.ToString() + "，设备名称：" + txtEquName.Text);

                // 修改必填信息
                int intCount = equDAL.UpdateEqu_BaseInfo(txtEquNO.Text, txtEquName.Text, cmbDeptID.Text == "" ? 0 : int.Parse(cmbDeptID.SelectedValue.ToString()),
                    cmbEquType.Text == "" ? 0 : int.Parse(cmbEquType.SelectedValue.ToString()), cmbEquState.Text == "" ? 0 : int.Parse(cmbEquState.SelectedValue.ToString()),
                    cmbFactoryID.Text == "" ? 0 : int.Parse(cmbFactoryID.SelectedValue.ToString()), txtRemark.Text, int.Parse(dtEqu.Rows[0]["EquID"].ToString()));

                if (dtDetail.Rows.Count < 1)
                {
                    if (!IsFill())
                    {
                        // 向详细表中添加
                        int intCounta = equDAL.AddEqu_Detail(int.Parse(dtEqu.Rows[0]["EquID"].ToString()), txtModelSpecial.Text, txtDutyEmployee.Text, txtUseRange.Text,
                            Convert.ToDateTime(dtimeProductionDate.Text).ToString("yyyy-M-d"), txtEquHeight.Text == "" ? 0 : int.Parse(txtEquHeight.Text), txtEquPower.Text == "" ? 0 : int.Parse(txtEquPower.Text),
                            Convert.ToDateTime(dtimeUserDate.Text).ToString("yyyy-M-d"));
                        if (intCounta == -1)
                        {
                            MessageBox.Show("详细信息修改失败");
                            return;
                        }
                        else if (intCounta == 0)
                        {
                            //return;
                        }
                    }
                }
                else
                {
                    // 修改选填信息
                    int intCountD = equDAL.UpdateEqu_Detail(txtModelSpecial.Text, txtDutyEmployee.Text, txtUseRange.Text, dtimeProductionDate.Text,
                        int.Parse(txtEquHeight.Text), int.Parse(txtEquPower.Text), dtimeUserDate.Text, int.Parse(dtDetail.Rows[0]["EquDetailID"].ToString()));
                }
                if (intCount == 1 && intCount == 1) MessageBox.Show("修改成功");
                this.Close();
            }
            else
            {
                //存入日志
                LogSave.Messages("[FrmEquEdit]", LogIDType.UserLogID, "添加设备信息，生产厂家：" + cmbEquType.SelectedText.ToString() + "，设备名称：" + txtEquName.Text);

                // 必填的是否填写完整
                if (!IsNull()) return;
                int iCount = equDAL.AddEqu_BaseInfo(txtEquNO.Text, txtEquName.Text, cmbDeptID.Text == "" ? 0 : int.Parse(cmbDeptID.SelectedValue.ToString()),
                    cmbEquType.Text == "" ? 0 : int.Parse(cmbEquType.SelectedValue.ToString()), cmbEquState.Text == "" ? 0 : int.Parse(cmbEquState.SelectedValue.ToString()),
                    cmbFactoryID.Text == "" ? 0 : int.Parse(cmbFactoryID.SelectedValue.ToString()), txtRemark.Text);
                if (iCount == -1)
                {
                    MessageBox.Show("添加失败");
                    return;
                }
                else if (iCount == 0)
                {
                    MessageBox.Show("您添加的设备编号已存在，请重新填写");
                    txtEquNO.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK);
                }

                // 获得EquID
                //DataTable dt = equDAL.GetEquID(txtEquNO.Text);
                //int int_EquID = int.Parse(dt.Rows[0]["EquID"].ToString());

                // 判断详细信息是否填写
                if (!IsFill())
                {
                    // 向详细表中添加
                    int intCount = equDAL.AddEqu_Detail(/*int.Parse(dtEqu.Rows[0]["EquID"].ToString())*/txtEquNO.Text.Trim(), txtModelSpecial.Text, txtDutyEmployee.Text, txtUseRange.Text,
                            Convert.ToDateTime(dtimeProductionDate.Text).ToString("yyyy-M-d"), txtEquHeight.Text == "" ? 0 : int.Parse(txtEquHeight.Text), txtEquPower.Text == "" ? 0 : int.Parse(txtEquPower.Text),
                            Convert.ToDateTime(dtimeUserDate.Text).ToString("yyyy-M-d"));
                    if (intCount != 1)
                    {
                        MessageBox.Show("详细信息添加失败");

                        return;
                    }
                }
            }
            this.Close();
        }
        #endregion

        #endregion 

        #region 是否要向详细表中添加
        /// <summary>
        /// 是否要向详细表中添加
        /// </summary>
        /// <returns>true(不添加)</returns>
        public bool IsFill()
        {
            bool isEmpty = true;
            foreach (Control ctl in plEquDetail.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    if (ctl.Text != "")
                    {
                        // 修改了
                        isEmpty = false;
                    }
                }
            }
            if (Convert.ToDateTime(dtimeProductionDate.Text).ToString("yyyy-M-d") != DateTime.Now.ToString("yyyy-M-d") || DateTime.Parse(dtimeUserDate.Text).ToString("yyyy-M-d") != DateTime.Now.ToString("yyyy-M-d"))
            {
                // 修改了
                isEmpty = false;
            }
            return isEmpty;
        }
        #endregion

        #region 判断填写是否完整
        /// <summary>
        /// 判断填写是否完整
        /// </summary>
        /// <returns>true(完整)</returns>
        public bool IsNull()
        {
            if (txtEquNO.Text == "")
            {
                MessageBox.Show("请填写设备编号");
                txtEquNO.Focus();
                return false;
            }
            if (txtEquName.Text == "")
            {
                MessageBox.Show("请填写设备名称");
                txtEquName.Focus();
                return false;
            }

            return true;
        }
        #endregion 

    }
}