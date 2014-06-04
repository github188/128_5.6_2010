using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128NDBTable;
using KJ128NInterfaceShow;

namespace KJ128NMainRun.ConfigInfo.ConStaHeadInfo
{
    public partial class FrmConStaHeadInfo : Wilson.Controls.Docking.DockContent
    {

        #region [ 声明 ]

        private ConStaHeadInfoBLL cshibll = new ConStaHeadInfoBLL();

        #endregion


        #region [ 构造函数 ]

        public FrmConStaHeadInfo()
        {
            InitializeComponent();

            LoadStationInfo();      //加载 分站信息

            if (dgvStation.Rows.Count > 0)
            {
                captionPanel1.CaptionTitle = dgvStation.Rows[0].Cells[0].Value.ToString() + " 号传输分站的读卡分站信息";
                LoadStaHeadInfo(dgvStation.Rows[0].Cells[0].Value.ToString());
            }
        }

        #endregion

        /*
         * 方法
         */ 

        #region [ 方法: 加载分站信息 ]

        /// <summary>
        /// 加载分站信息
        /// </summary>
        private void LoadStationInfo()
        {
            int iSum = cshibll.N_SearchStationInfo(dgvStation);
            cpStationInfo.CaptionTitle = "传输分站信息:\t共 "+iSum +" 个传输分站";
        }

        #endregion

        #region [ 方法: 加载接收器信息 ]

        /// <summary>
        /// 加载接收器信息
        /// </summary>
        /// <param name="strStationAddress"></param>
        private void LoadStaHeadInfo(string strStationAddress)
        {
            int iSum = cshibll.N_SearchStaHeadInfo(strStationAddress, dgvStaHead);
            captionPanel1.CaptionTitle = "读卡分站信息:\t共 " + iSum + " 个读卡分站";
        }

        #endregion

        /*
         * 事件
         */ 

        #region [ 事件: 选择分站,加载该分站的接收器 ]

        private void dgvStation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                captionPanel1.CaptionTitle = dgvStation.Rows[e.RowIndex].Cells[0].Value.ToString() + " 号传输分站的读卡分站信息";
                LoadStaHeadInfo(dgvStation.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        #endregion

        #region [ 事件: 分站信息打印 ]

        private void cpStationToExcel_Click(object sender, EventArgs e)
        {
            PrintBLL.Print(dgvStation,"传输分站信息");
        }

        #endregion

        #region [ 事件: 接收器信息打印 ]

        private void cpStaHeadToExcel_Click(object sender, EventArgs e)
        {
            if (dgvStaHead.DataSource != null)
            {
                PrintBLL.Print(dgvStaHead, "读卡分站信息");
            }
            else
            {
                MessageBox.Show("无数据信息，不能打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

    }
}