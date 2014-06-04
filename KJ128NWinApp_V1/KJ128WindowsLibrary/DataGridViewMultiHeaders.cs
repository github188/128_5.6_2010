using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace KJ128NInterfaceShow
{
    ///   <summary > 
    ///   支持双行表头的的DataGridView 
    ///   
    ///   用法示例： 
    ///   dg.AddSpanHeader(4,   4,   "主标题"); 
    ///   则将第4列开始的4列设为双行表头，主标题为“主标题”，子标题为原来的   Value   值 
    ///   
    ///   phommy@hotmail.com 
    ///   </summary > 
    public partial class DataGridViewMultiHeaders : DataGridViewKJ128
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DataGridViewMultiHeaders()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            //   TODO:   在此处添加自定义绘制代码 

            //   调用基类   OnPaint 
            base.OnPaint(pe);
        }
        private struct SpanInfo     //表头信息 
        {
            public SpanInfo(string Text, int Position, int Left, int Right)
            {
                this.Text = Text;
                this.Position = Position;
                this.Left = Left;
                this.Right = Right;
            }

            public string Text;           //列主标题 
            public int Position;         //位置，1:左，2中，3右 
            public int Left;                 //对应左行 
            public int Right;               //对应右行 
        }

        private Dictionary<int, SpanInfo> SpanRows = new Dictionary<int, SpanInfo>();//需要2维表头的列 

        /// <summary>
        /// 增加表头
        /// </summary>
        /// <param name="ColIndex">开始的列索引</param>
        /// <param name="ColCount">合并的列数</param>
        /// <param name="Text">增加的表头的内容</param>
        public void AddSpanHeader(int ColIndex, int ColCount, string Text)
        {
            if (ColCount < 2)
            //throw new Exception("行宽应大于等于2，合并1列无意义。");
            {
                MessageBox.Show("行宽应大于等于2，合并1列无意义。");
                return;
            }
            //检查范围 
            //for (int i = 0; i < ColCount; i++)
            //{
            //    if (SpanRows.ContainsKey(ColIndex + i))
            //        throw new Exception("单元格范围重叠!");
            //}

            //将这些列加入列表 
            int Right = ColIndex + ColCount - 1;         //同一大标题下的最后一列的索引 
            SpanRows[ColIndex] = new SpanInfo(Text, 1, ColIndex, Right);         //添加标题下的最左列 
            SpanRows[Right] = new SpanInfo(Text, 3, ColIndex, Right);       //添加该标题下的最右列 
            for (int i = ColIndex + 1; i < Right; i++)     //中间的列 
            {
                SpanRows[i] = new SpanInfo(Text, 2, ColIndex, Right);
            }
        }
        /// <summary>
        /// 清空块
        /// </summary>
        public void ClearSpanInfo()
        {
            SpanRows.Clear();
            //ReDrawHead(); 
        }

        /// <summary>
        /// 重绘表头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewEx_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (SpanRows.ContainsKey(e.ColumnIndex))     //被合并的列 
                {
                    //画边框 
                    Graphics g = e.Graphics;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    int left = e.CellBounds.Left, top = e.CellBounds.Top + 2,
                            right = e.CellBounds.Right, bottom = e.CellBounds.Bottom;

                    switch (SpanRows[e.ColumnIndex].Position)
                    {
                        case 1:
                            left += 2;
                            break;
                        case 2:
                            break;
                        case 3:
                            right -= 2;
                            break;
                    }

                    //画上半部分底色 
                    g.FillRectangle(new SolidBrush(e.CellStyle.BackColor), left, top,
                            right - left, (bottom - top) / 2);

                    //画中线 
                    g.DrawLine(new Pen(this.GridColor), left, (top + bottom) / 2,
                            right, (top + bottom) / 2);

                    //写小标题 
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString(e.Value + "", e.CellStyle.Font, Brushes.Black,
                    new Rectangle(left, (top + bottom) / 2, right - left, (bottom - top) / 2), sf);

                    //写大标题 
                    //if   (this.SpanRows[e.ColumnIndex].Position==3) 
                    {
                        left = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Left, true).Left - 2;

                        if (left < 0) left = this.GetCellDisplayRectangle(-1, -1, true).Width;
                        right = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Right, true).Right - 2;
                        if (right < 0) right = this.Width;

                        g.DrawString(SpanRows[e.ColumnIndex].Text, e.CellStyle.Font, Brushes.Black,
                                new Rectangle(left, top, right - left, (bottom - top) / 2), sf);
                    }
                    e.Handled = true;
                }
            }
        }
        private void DataGridViewEx_Scroll(object sender, ScrollEventArgs e)
        {

            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)//   &&   e.Type   ==   ScrollEventType.EndScroll) 
            {
                timer1.Enabled = false; timer1.Enabled = true;
            }
        }

        //刷新显示表头 
        public void ReDrawHead()
        {
            foreach (int si in SpanRows.Keys)
            {
                this.Invalidate(this.GetCellDisplayRectangle(si, -1, true));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ReDrawHead();
        }///   <summary > 
        ///   必需的设计器变量。 
        ///   </summary > 
        private System.ComponentModel.IContainer components = null;

        ///   <summary > 
        ///   清理所有正在使用的资源。 
        ///   </summary > 
        ///   <param   name="disposing" >如果应释放托管资源，为   true；否则为   false。 </param > 
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region   组件设计器生成的代码

        ///   <summary > 
        ///   设计器支持所需的方法   -   不要 
        ///   使用代码编辑器修改此方法的内容。 
        ///   </summary > 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            //   
            //   timer1 
            //   
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //   
            //   DataGridViewEx1 
            //   
            this.RowTemplate.Height = 23;
            this.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewEx_CellPainting);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DataGridViewEx_Scroll);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Timer timer1;
    }

}
