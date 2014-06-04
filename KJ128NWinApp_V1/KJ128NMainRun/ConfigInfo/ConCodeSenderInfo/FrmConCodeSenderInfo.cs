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

namespace KJ128NMainRun.ConfigInfo.ConCodeSenderInfo
{
    public partial class FrmConCodeSenderInfo : Wilson.Controls.Docking.DockContent
    {

        #region [ 申明 ]

        private ConCodeSenderInfoBLL ccsibll = new ConCodeSenderInfoBLL();

        #endregion


        #region [ 构造函数 ]

        public FrmConCodeSenderInfo()
        {
            InitializeComponent();

            labelTransparent2.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
            labelTransparent3.Text = HardwareName.Value(CorpsName.CodeSenderAddress) + ":";
            labelTransparent5.Text = HardwareName.Value(CorpsName.CodeSender) + "状态:";

            dgvCode.Columns[1].HeaderText = HardwareName.Value(CorpsName.CodeSender) + "状态";

            ccsibll.N_LoadInfo(cmbCodeSenderStateID);         //加载发码器状态
            btnQuery1_Click(null,null);
            btnQuery2_Click(null,null);
        }
        #endregion

        /*
         * 事件
         */
 
        #region [ 事件: 发码器查询_Click事件 ]

        private void btnQuery1_Click(object sender, EventArgs e)
        {
            string strCounts;
            ccsibll.N_SearchCodeInfo(txtCodeSender1.Text.Trim(), cmbCodeSenderStateID.SelectedValue.ToString(), dgvCode,out strCounts);
            buttonCaptionPanel1.CaptionTitle = HardwareName.Value(CorpsName.CodeSender) + "信息:" + "\t共 " + strCounts + " 个" + HardwareName.Value(CorpsName.CodeSender);
        }

        #endregion

        #region [ 事件: 发码器重置_Click事件 ]

        private void btnCanel1_Click(object sender, EventArgs e)
        {
            txtCodeSender1.Text = "";
            cmbCodeSenderStateID.SelectedIndex = 0;
        }

        #endregion

        #region [ 事件: 发码器配置查询_Click事件 ]

        private void btnQuery2_Click(object sender, EventArgs e)
        {
            string strCounts;
            ccsibll.N_SearchCodeSetInfo(txtCodeSender2.Text.Trim(), txtName.Text.Trim(), rbEmp.Checked || rbEqu.Checked ? rbEmp.Checked ? 0 : 1 : 2, dgvCodeSender,out strCounts);
            buttonCaptionPanel3.CaptionTitle = HardwareName.Value(CorpsName.CodeSender) + "配置信息:" + "\t共 " + strCounts + " 个" + HardwareName.Value(CorpsName.CodeSender);
        }

        #endregion

        #region [ 事件: 发码器配置重置_Click事件 ]

        private void btnCanel2_Click(object sender, EventArgs e)
        {
            rbEmp.Checked = true;
            txtCodeSender2.Text = "";
            txtName.Text = "";
        }
        #endregion

        #region [ 事件: 发码器信息打印 ]

        private void cpCodeToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvCode,HardwareName.Value(CorpsName.CodeSender)+"信息");
        }

        #endregion

        #region [ 事件: 发码器配置信息打印 ]

        private void cpCodeSenderToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvCodeSender,HardwareName.Value(CorpsName.CodeSender)+"配置信息");
        }

        #endregion

    }
}