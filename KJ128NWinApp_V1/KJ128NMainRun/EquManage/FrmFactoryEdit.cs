using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KJ128NDBTable;
using Shine.Logs;
using Shine.Logs.LogType;

namespace KJ128NMainRun.EquManage
{
    public partial class FrmFactoryEdit : Wilson.Controls.Docking.DockContent
    {
        EquBLL equDAL = new EquBLL();
        DataTable dt = null;

        #region 初始化

        public FrmFactoryEdit()
        {
            InitializeComponent();
            // Init();
        }

        // 传入一条数据
        public void ShowDialog(DataTable dtUpdate )
        {
            dt = dtUpdate;
            Init();
            ShowDialog();
        }

        public void Init()
        {
            if (this.Text == "修改厂家信息") // 是修改要将
            {
                btnEdit.Text = "修改";

                if(dt == null) return;

                txtFactoryNO.Enabled = false;

                // 给所有控件赋值
                DataRow dr = dt.Rows[0];

                txtFactoryNO.Text = dr["FactoryNO"].ToString();
                txtFactoryName.Text = dr["FactoryName"].ToString();
                txtFactoryTel.Text = dr["FactoryTel"].ToString();
                txtRemark.Text = dr["Remark"].ToString();
                txtFactoryFax.Text = dr["FactoryFax"].ToString();
                txtFactoryEmpoyeeTel.Text = dr["FactoryEmpoyeeTel"].ToString();
                txtFactoryEmployee.Text = dr["FactoryEmployee"].ToString();
                txtFactoryAddress.Text = dr["FactoryAddress"].ToString();

                btnCanel.Visible = false;
            }
            else
            {
                btnEdit.Text = "添加";
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
                if (ctl.GetType() == typeof(TextBox))
                {
                    ctl.Text = "";
                }
            }

            btnCanel.Visible = true;
        }
        #endregion 

        #region 判断是否为空
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsNull()
        {
            if (txtFactoryNO.Text == "")
            {
                MessageBox.Show("请填写厂家编号");
                txtFactoryNO.Focus();
                return false;
            }

            if (txtFactoryName.Text == "")
            {
                MessageBox.Show("请填写厂家名称");
                txtFactoryName.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region 按钮事件

        #region 取消
        // 取消
        private void btnCanel_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "修改")
            {
                // 重新加载传入的数据
                Init();
            }
            else
            { 
                // 清空
                ClearCon();
            }
        }
        #endregion 

        #region 添加，修改
        // 添加，修改
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!IsNull()) return;
            if (btnEdit.Text == "修改")
            {
                //存入日志
                LogSave.Messages("[FrmFactoryEdit]", LogIDType.UserLogID, "修改生产厂家信息，生产厂家编号：" + txtFactoryNO.Text + "，生产厂家名称：" + txtFactoryName.Text);

                DataRow dr = dt.Rows[0];
                // 修改
                int intCount = equDAL.UpdateFactory(txtFactoryNO.Text, txtFactoryName.Text, txtFactoryAddress.Text,txtFactoryFax.Text, 
                    txtFactoryTel.Text, txtFactoryEmployee.Text, txtFactoryEmpoyeeTel.Text, txtRemark.Text, int.Parse(dr["FactoryID"].ToString()));
                if (intCount == 1)
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改不成功");
                }
            }
            else
            {
                //存入日志
                LogSave.Messages("[FrmFactoryEdit]", LogIDType.UserLogID, "增加生产厂家信息，生产厂家编号：" + txtFactoryNO.Text + "，生产厂家名称：" + txtFactoryName.Text);

                // 向数据库添加
                int intCount = equDAL.AddFactory(txtFactoryNO.Text, txtFactoryName.Text, txtFactoryAddress.Text, 
                    txtFactoryFax.Text, txtFactoryTel.Text, txtFactoryEmployee.Text, txtFactoryEmpoyeeTel.Text, txtRemark.Text);

                if (intCount == 1)
                {
                    MessageBox.Show("添加成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("该生产厂家的编号已经存在请重新添加");
                    return;
                }
                
            }
            
        }
        #endregion 

        #region 返回
        // 返回
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #endregion 

    }
}