using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace KJ128NInterfaceShow
{
    /// <summary>
    /// DataGridViewKJ128Style样式
    /// </summary>
    public enum DataGridViewKJ128Style
    {
        /// <summary>
        /// windows 默认可视化效果
        /// </summary>
        WindowsStyle,
        /// <summary>
        ///绿色
        /// </summary>
        GreenStyle,
        /// <summary>
        /// KJ70表格
        /// </summary>
        KJ70Style,
        /// <summary>
        /// 蓝色表格
        /// </summary>
        BlueStyle,
        /// <summary>
        /// 无样式
        /// </summary>
        None
    }
    /// <summary>
    /// 继承DataGridView
    /// </summary>
    public class DataGridViewKJ128 : DataGridView
    {
        #region 私有变量

        private DataGridViewKJ128Style dgvKJ128Style = DataGridViewKJ128Style.WindowsStyle;

        #endregion

        #region  构造函数
        /// <summary>
        ///  构造函数
        /// </summary>
        public DataGridViewKJ128()
            : base()
        {
            //InitDataGridViewKJ128();
            //MouseWheel += DataGridViewKJ128_MouseWheel;
            Scroll += DataGridViewKJ128_Scroll;
        }

        void DataGridViewKJ128_Scroll(object sender, ScrollEventArgs e)
        {
            Focus();
        }

        //void DataGridViewKJ128_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    Update();
        //}

        #endregion

        #region 方法
        private void SetShowStyle()
        {
            switch(dgvKJ128Style)
            {
                case DataGridViewKJ128Style.WindowsStyle:
                    {
                        this.EnableHeadersVisualStyles = true;
                        this.RowHeadersVisible = false;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 10, System.Drawing.FontStyle.Bold,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region 外观
                        this.BorderStyle = BorderStyle.Fixed3D;
                        this.GridColor = Color.FromArgb(197, 197, 197);//线条颜色
                        this.BackgroundColor = Color.FromArgb(244, 244, 244);//背景
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);//行颜色
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);//行的前景色
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//奇 数行颜色

                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//选择的背景色
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//前景色
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//选择的前景色
                        #endregion
                        break;
                    }
                case DataGridViewKJ128Style.GreenStyle:
                    {
                        this.EnableHeadersVisualStyles = false;
                        this.RowHeadersVisible = false;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region 外观
                        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        this.BackColor = Color.FromArgb(231, 241, 251);
                        this.BorderStyle = BorderStyle.Fixed3D;
                        this.GridColor = Color.FromArgb(197, 197, 197);//线条颜色
                        this.BackgroundColor = Color.FromArgb(231, 241, 251);//背景
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(231,241,251);//行颜色
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);//行的前景色
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//行颜色
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//前景色
                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(49, 106, 197);//选择的背景色
                        
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(255,255,255);//选择的前景色

                        this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(39,163,91);//标题背景色
                        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255,255,255);//标题前景色
                        #endregion
                        break;
                    }
                case DataGridViewKJ128Style.KJ70Style:
                    {
                        this.EnableHeadersVisualStyles = false;
                        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region 外观
                        this.BorderStyle = BorderStyle.Fixed3D;
                        this.GridColor = Color.FromArgb(197, 197, 197);//线条颜色
                        this.BackgroundColor = Color.FromArgb(231, 241, 251);//背景
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//行的背颜色
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 128, 0);//行的前景色

                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//奇 数行颜色

                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//选择的背景色
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//前景色
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//选择的前景色

                        this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 217);//标题背景色

                        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 255);//标题前景色

                        this.RowHeadersVisible = true;

                        this.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 217);
                        this.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 255);//标题前景色

                        #endregion
                        break;
                    }
                case DataGridViewKJ128Style.BlueStyle:
                    {
                        this.EnableHeadersVisualStyles = false;
                        this.RowHeadersVisible = false;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region 外观
                        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        
                        //this.BackColor = Color.FromArgb(231, 241, 251);
                        this.BackColor = Color.FromArgb(255, 255, 255);

                        this.BorderStyle = BorderStyle.Fixed3D;
                        //this.GridColor = Color.FromArgb(184,191,219);//线条颜色
                        this.GridColor = Color.FromArgb(117, 154, 198);//线条颜色
                        this.BackgroundColor = Color.FromArgb(231, 241, 251);//背景
                        //this.RowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//行颜色
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(249, 255, 255);//行颜色

                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);//行的前景色
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//行颜色
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//奇 数行颜色
                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//选择的背景色
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//前景色
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//选择的前景色

                        //this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);//标题背景色
                        this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(236, 251, 248);//标题背景色
                        //this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);//标题前景色
                        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 0,0);//标题前景色

                        this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; //标题高的模式
                        

                        #endregion
                        break;
                    }
                case DataGridViewKJ128Style.None:
                    {
                        break;
                    }
            }
        }

        private void InitDataGridViewKJ128()
        {
            
            #region 操作控制
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            
            this.ReadOnly = false;
            this.RowHeadersVisible = false;//不启用行头
            #endregion
            #region 外观
            //this.BorderStyle = BorderStyle.Fixed3D;
            //this.GridColor = Color.FromArgb(197, 197, 197);//线条颜色
            //this.BackgroundColor = this.BackgroundColor = Color.FromArgb(244, 244, 244);//背景
            //this.RowsDefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);//行颜色
            //this.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//奇 数行颜色

            //this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//选择的背景色
            //this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//前景色
            //this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//选择的前景色
            #endregion
            #region 列标题
            if (!this.EnableHeadersVisualStyles)
            {
                this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(221, 231, 238);
                this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(62, 22, 110);
            }
            this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 10, System.Drawing.FontStyle.Bold,
              System.Drawing.GraphicsUnit.Point, (byte)(134));
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = 32;
            this.ReadOnly = true;
            #endregion
        }
        #endregion

        #region 属性
        /// <summary>
        /// 设定表格设定样式
        /// </summary>
        [Category("扩展的属性"), Description("是否采用直接在窗体拖曳模式")]
        public DataGridViewKJ128Style DataGridShowStype
        {
            get
            {
                return dgvKJ128Style;
            }
            set
            {
                dgvKJ128Style = value;
                SetShowStyle();
            }
        }
        /// <summary>
        /// 获取垂直滚动条的值
        /// </summary>
        [Category("扩展的属性"), Description("获取垂直滚动条的值")]
        public int VerticalScrollBarValue
        {
            get
            {
                return this.VerticalScrollBar.Value;
            }
            set
            {
                this.VerticalScrollBar.Value = value;
            }

        }

        /// <summary>
        /// 获取垂直滚动条的上限
        /// </summary>
        [Category("扩展的属性"), Description("获取垂直滚动条的上限")]
        public int VerticalScrollBarMax
        {
            get 
            {
                return this.VerticalScrollBar.Maximum;
            }
            set 
            {
                this.VerticalScrollBar.Maximum = value;
            }
        }
        #endregion

        #region blue


        /*
         * case DataGridViewKJ128Style.BlueStyle:
                    {
                        this.EnableHeadersVisualStyles = false;
                        this.RowHeadersVisible = false;
                        this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular,
  System.Drawing.GraphicsUnit.Point, (byte)(134));
                        #region 外观
                        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        this.BackColor = Color.FromArgb(231, 241, 251);
                        this.BorderStyle = BorderStyle.Fixed3D;
                        this.GridColor = Color.FromArgb(184,191,219);//线条颜色
                        this.BackgroundColor = Color.FromArgb(231, 241, 251);//背景
                        this.RowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//行颜色
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);//行的前景色
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 241, 251);//行颜色
                        this.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//奇 数行颜色
                        this.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 247, 222);//选择的背景色
                        this.RowsDefaultCellStyle.ForeColor = Color.FromArgb(49, 93, 165);//前景色
                        this.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(49, 93, 165);//选择的前景色

                        this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);//标题背景色
                        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);//标题前景色

                        this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; //标题高的模式
                        

                        #endregion
                        break;
                    }
         * 
         */

        #endregion
    }
}
