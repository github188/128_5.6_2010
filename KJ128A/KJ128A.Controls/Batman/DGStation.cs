using System;
using System.Text;
using System.Windows.Forms;

namespace KJ128A.Controls.Batman
{
    /// <summary>
    /// 基站的 DataGridView 状态
    /// </summary>
    public class DGStation : DataGridView
    {
        private readonly KJTpStation_Menu menuStation = null;

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

        #region [ 构造函数 ]

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="index"></param>
        /// <param name="frm"></param>
        public DGStation(int index, KJ128A.BatmanAPI.IFrmMain frm)
        {
            Index = index;

            menuStation = new KJTpStation_Menu(index, frm);

            ReadOnly = true;
            Dock = DockStyle.Fill;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            RowHeadersVisible = false;

            SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //this.CellMouseClick += new DataGridViewCellMouseEventHandler(DGStation_CellMouseClick);
            this.CellMouseDown += new DataGridViewCellMouseEventHandler(DGStation_CellMouseClick);
            this.ContextMenuStrip = menuStation;
        }

        #endregion

        #region [ 方法 ] 绘制界面

        /// <summary>
        /// 绘制界面
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Columns.Count != 0)
            {
                this.Columns["ID"].Visible = false;
                this.Columns["State"].Visible = false;
                this.Columns["Ver"].Visible = false;
                this.Columns["Group"].Visible = false;
                this.Columns["NoAnswer"].Visible = false;

                this.Columns["CmdVersion"].Visible = false;
                this.Columns["CmdPolling"].Visible = false;
                this.Columns["CmdPollingRight"].Visible = false;
                this.Columns["CmdReset"].Visible = false;
                this.Columns["IsPointSelect"].Visible = false;
                this.Columns["CmdTwo"].Visible = false;
                this.Columns["IsTwo"].Visible = false;
                this.Columns["IpAddress"].Visible = false;
                this.Columns["Port"].Visible = false;
                this.Columns["SCmd"].Visible = false;
                this.Columns["SaveCount"].Visible = false;
                this.Columns["TimeCheckOut"].Visible = false;
                this.Columns["StationModel"].Visible = false;

                this.Columns["Address"].HeaderText = "地址";
                this.Columns["Address"].Width = 60;
                this.Columns["Address"].DisplayIndex = 0;

                this.Columns["CState"].HeaderText = "状态描述";
                this.Columns["CState"].Width = 100;
                this.Columns["CState"].DisplayIndex = 1;
            }

            base.OnPaint(e);
        }

        #endregion

        #region [ 事件 ] 基站选中状态改变 鼠标点击时触发

        /// <summary>
        /// 基站选中状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGStation_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.ClearSelection();
                this.Rows[e.RowIndex].Selected = true;

                // 通知菜单当前选中的基站地址
                string strAddress = this.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                if (strAddress != string.Empty)
                {
                    menuStation.CurStationAddress = int.Parse(strAddress);
                }
            }
        }

        #endregion
    }
}
