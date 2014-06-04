using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KJ128WindowsLibrary;
using KJ128NDBTable;
using KJ128NDataBase;

namespace KJ128NMainRun.ConfigInfo.ConDeptEmpCounts
{
    public partial class FrmConDeptEmpCounts : Wilson.Controls.Docking.DockContent
    {

        #region [ 申明 ]

        private ConDeptEmpCountsBLL cdbll = new ConDeptEmpCountsBLL();

        #endregion


        #region [ 构造函数 ]

        public FrmConDeptEmpCounts()
        {
            InitializeComponent();
        }

        #endregion

        /*
         * 事件
         */
 
        #region [ 事件: 窗体加载 ]

        private void FrmConDeptEmpCounts_Load(object sender, EventArgs e)
        {
            cdbll.N_LoadDeptTree(trDept);
        }

        #endregion
    }
}