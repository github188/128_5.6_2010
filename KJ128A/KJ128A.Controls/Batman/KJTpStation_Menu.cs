using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace KJ128A.Controls.Batman
{
    internal class KJTpStation_Menu : ContextMenuStrip
    {
        private KJ128A.BatmanAPI.IFrmMain frmMain = null;

        private ToolStripMenuItem menuItemStation = new ToolStripMenuItem("传输分站");              // 基站菜单
        private ToolStripSeparator menuItemSeparator3 = new ToolStripSeparator();               // 分隔符 3

        #region KJTpStation_Menu 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public KJTpStation_Menu(int index, KJ128A.BatmanAPI.IFrmMain frm)
        {
            frmMain = frm;
            Index = index;

            InitMenu();
        }

        #endregion

        #region [ 属性 ] 索引

        private int _Index;

        /// <summary>
        /// 索引, 当初始化多个串口时, 用来做串口的初始化标识
        /// </summary>
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        #endregion

        #region [ 属性 ] 当前操作的基站地址

        private int m_CurStationAddress = 0;

        /// <summary>
        /// 当前操作的基站地址
        /// </summary>
        public int CurStationAddress
        {
            get
            {
                return m_CurStationAddress;
            }
            set
            {
                m_CurStationAddress = value;
            }
        }

        #endregion

        #region [ 菜单 ] 初始化菜单

        /// <summary>
        /// 初始化菜单
        /// </summary>
        public void InitMenu()
        {
            // 重启菜单
            ToolStripMenuItem menuItemReset = new ToolStripMenuItem("重启");
            menuItemReset.Click += new System.EventHandler(menuItemReset_Click);
            Items.Add(menuItemReset);

            // 分隔符
            Items.Add("-");

            // 唤醒菜单
            ToolStripMenuItem menuItemWaken = new ToolStripMenuItem("唤醒");
            menuItemWaken.Click += new System.EventHandler(menuItemWaken_Click);
            Items.Add(menuItemWaken);

            // 休眠菜单
            ToolStripMenuItem menuItemSleep = new ToolStripMenuItem("休眠");
            menuItemSleep.Click += new System.EventHandler(menuItemSleep_Click);
            Items.Add(menuItemSleep);

            // 分隔符
            Items.Add("-");

            //定点巡检
            ToolStripMenuItem menuItemPoint = new ToolStripMenuItem("定点巡检");
            menuItemPoint.Click += new EventHandler(menuItemPoint_Click);
            Items.Add(menuItemPoint);

            ////分隔符
            //Items.Add("-");
            
            ////双向通讯
            //ToolStripMenuItem menuItemTwo = new ToolStripMenuItem("双向通讯");
            //menuItemTwo.Click += new EventHandler(menuItemTwo_Click);
            //Items.Add(menuItemTwo);

            // 分隔符
            Items.Add(menuItemSeparator3);

            // 基站菜单
            //Items.Add(menuItemStation);

            // 添加基站
            ToolStripMenuItem menuItemStationAdd = new ToolStripMenuItem("添加");
            menuItemStationAdd.Click += new EventHandler(menuItemStationAdd_Click);
            menuItemStation.DropDownItems.Add(menuItemStationAdd);

            // 编辑基站
            ToolStripMenuItem menuItemStationEdit = new ToolStripMenuItem("编辑");
            menuItemStationEdit.Click += new EventHandler(menuItemStationEdit_Click);
            menuItemStation.DropDownItems.Add(menuItemStationEdit);

            // 删除基站
            ToolStripMenuItem menuItemStationDel = new ToolStripMenuItem("删除");
            menuItemStationDel.Click += new EventHandler(menuItemStationDel_Click);
            menuItemStation.DropDownItems.Add(menuItemStationDel);

        }

        //void menuItemTwo_Click(object sender, EventArgs e)
        //{
            
        //}

        void menuItemPoint_Click(object sender, EventArgs e)
        {

            int iStationAddress = 0;
            try
            {
                iStationAddress = int.Parse(CurStationAddress.ToString());
            }
            catch { return; }
            if (iStationAddress != 0)
            {
                if (Items[5].Text.Equals("定点巡检"))
                {
                    Items[5].Text = "撤销" + CurStationAddress.ToString() + "号定点巡检";
                    if (frmMain.GetCommType())//网络
                    {
                        frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointSelect);
                    }
                    else//串口
                    {
                        frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointSelect);
                    }
                    //frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointSelect);
                }
                else
                {
                    Items[5].Text = "定点巡检";
                    if (frmMain.GetCommType())//网络
                    {
                        frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointCancal);
                    }
                    else//串口
                    {
                        frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointCancal);
                    }
                    //frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.PointCancal);
                }
            }
        }

        // 删除基站
        void menuItemStationDel_Click(object sender, EventArgs e)
        {
            int iStationAddress = int.Parse(CurStationAddress.ToString());
            frmMain.Station_Change(Index, iStationAddress, KJ128A.BatmanAPI.EnumOP.Del);
        }

        /// <summary>
        /// 编辑基站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemStationEdit_Click(object sender, EventArgs e)
        {
            int iStationAddress = int.Parse(CurStationAddress.ToString());
            frmMain.Station_Change(Index, iStationAddress, KJ128A.BatmanAPI.EnumOP.Edit);
        }

        /// <summary>
        /// 添加基站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemStationAdd_Click(object sender, EventArgs e)
        {
            int iStationAddress = int.Parse(CurStationAddress.ToString());
            frmMain.Station_Change(Index, iStationAddress, KJ128A.BatmanAPI.EnumOP.Add);
            
        }

        /// <summary>
        /// 基站唤醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemWaken_Click(object sender, System.EventArgs e)
        {
            int iStationAddress = 0;
            try
            {
                iStationAddress = int.Parse(CurStationAddress.ToString());
            }
            catch { return; }
            if (iStationAddress != 0)
            {
                if (frmMain.GetCommType())//网络
                {
                    frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.NoInit);
                }
                else//串口
                {
                    frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.NoInit);
                }
                //frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.NoInit);
            }
        }

        /// <summary>
        /// 基站休眠
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemSleep_Click(object sender, System.EventArgs e)
        {
            int iStationAddress = 0;
            try
            {
                iStationAddress = int.Parse(CurStationAddress.ToString());
            }
            catch { return; }
            if (iStationAddress != 0)
            {
                bool blnOP;
                if (frmMain.GetCommType())//网络
                {
                    blnOP = frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.Sleep);
                }
                else
                {
                    blnOP = frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.Sleep);
                }

                if (!blnOP)
                {
                    MessageBox.Show("最后一个传输分站不能休眠");
                }
            }
        }

        /// <summary>
        /// 基站重启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemReset_Click(object sender, System.EventArgs e)
        {
            int iStationAddress = 0;
            try
            {
                iStationAddress = int.Parse(CurStationAddress.ToString());
            }
            catch { return; }
            if (iStationAddress != 0)
            {
                if (frmMain.GetCommType())//网络
                {
                    frmMain.Station_ChangeState(iStationAddress, KJ128A.BatmanAPI.EnumStationState.Reset);
                }
                else//串口
                {
                    frmMain.Station_ChangeState(Index, iStationAddress, KJ128A.BatmanAPI.EnumStationState.Reset);
                }
            }
        }

        #endregion
    }
}
