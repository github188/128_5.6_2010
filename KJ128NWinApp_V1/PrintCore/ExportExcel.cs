using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace PrintCore
{
    public partial class ExportExcel : Form
    {

        private string ttName = string.Empty;
        private string tjTime = string.Empty;
        private DataGridView dgvs = null;
        Thread myThread = null;
        Microsoft.Office.Interop.Excel.Application excel = null;
        _Workbook wkb;
        public ExportExcel()
        {
            InitializeComponent();

        }

        PrintModel model = new PrintModel();

        public void Sql_ExportExcel(DataGridView dgv, string TitleName, string TjTime)
        {
            if (dgv.DataSource == null || (dgv.DataSource as System.Data.DataTable).Rows.Count == 0)
            {
                MessageBox.Show("没有数据源，无法导出数据", "提示");
                return;
            }
            dgvs = dgv;
            ttName = TitleName;
            tjTime = TjTime;
            if (dgvs.Rows.Count > 5000)
            {
                label1.Text = "数据集合较大，执行导出将要花费一段时间" + Environment.NewLine + "           是否执行导出？";
                label1.Left = (this.Width - label1.Width) / 2;
            }
            this.ShowDialog();
        }


        public void Sql_ExportExcel(DataGridView dgv, string TitleName)
        {
            if (dgv.DataSource == null || (dgv.DataSource as System.Data.DataTable).Rows.Count == 0)
            {
                MessageBox.Show("没有数据源，无法导出数据", "提示");
                return;
            }
            dgvs = dgv;
            ttName = TitleName;
            if (dgvs.Rows.Count > 10000)
            {
                label1.Text = "数据集合较大，执行导出将要花费一段时间" + Environment.NewLine + "           是否执行导出？";
                label1.Left = (this.Width - label1.Width) / 2;
            }
            this.ShowDialog();
        }

        //导出线程
        private void Export()
        {
            try
            {
                model = GetModel.getMode(dgvs, ttName, tjTime);//获取导出数据的模型

                //删除大于模板的列
                if (model.Columns.Count != 0 && model.Printtable.TableName != "A_InitialData")
                {
                    //判断一个string是否在string[]中
                    List<string> lst = model.Columns;

                    for (int j = 0; j < model.Printtable.Columns.Count; j++)
                    {
                        if (!lst.Contains(model.Printtable.Columns[j].ColumnName.ToString()))
                        {
                            model.Printtable.Columns.Remove(model.Printtable.Columns[j].ColumnName);
                            j--;
                        }

                    }
                }

                object objOpt = Missing.Value;

                try
                {
                    excel = new Microsoft.Office.Interop.Excel.Application();
                }
                catch(Exception ee)
                {
                    if (!ee.Message.Equals("正在中止线程。"))
                    {
                        MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                    }
                    //string time = System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
                    //myop.addOper(time, "无法创建Excel对象，可能您的机子未安装Excel", "NO");
                    return;
                }

                excel.Visible = false;
                wkb = excel.Workbooks.Add(objOpt);
                _Worksheet wks = (_Worksheet)wkb.ActiveSheet;
                wks.Visible = XlSheetVisibility.xlSheetVisible;

                int rowIndex = 1;
                int colIndex = 1;
                int x = 0;
                int y = 0;
                System.Data.DataTable table = ProcessDataTable(model.Printtable);
               

                #region[标题栏]
                //标题栏
                var RowAll1 = wks.get_Range(wks.Cells[rowIndex, 1], wks.Cells[rowIndex, table.Columns.Count]);
                RowAll1.Merge(0);
                excel.Cells[rowIndex, 1] = model.Printname;
                RowAll1.Font.Size = model.Titlefontsize;
                RowAll1.Font.FontStyle = FontStyle.Bold;
                RowAll1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                rowIndex++;
                #endregion

                #region[副标题信息]

                //统计时间
                var RowAll2 = wks.get_Range(wks.Cells[rowIndex, 1], wks.Cells[rowIndex, table.Columns.Count / 2]);
                RowAll2.Merge(0);
                excel.Cells[rowIndex, 1] = "打印时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                RowAll2.Font.Size = model.Subfontsize;
                RowAll2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                var RowAll3 = wks.get_Range(wks.Cells[rowIndex, table.Columns.Count / 2 + 1], wks.Cells[rowIndex, table.Columns.Count]);
                RowAll3.Merge(0);
                excel.Cells[rowIndex, table.Columns.Count / 2 + 1] = model.Tjtime;
                RowAll3.Font.Size = model.Subfontsize;
                RowAll3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                rowIndex++;
                #endregion

                #region[主体信息]
                x = rowIndex;
                foreach (DataColumn col in table.Columns)
                {

                    excel.Cells[x, colIndex] = dgvs.Columns[col.ColumnName].HeaderText;
                    excel.Columns.NumberFormatLocal = "@";
                    colIndex++;
                }
                //foreach (DataRow row in table.Rows)
                //{
                //    rowIndex++;
                //    colIndex = 0;

                //    foreach (DataColumn col in table.Columns)
                //    {
                //        try
                //        {
                //            colIndex++;
                //            // excel.Cells[rowIndex, colIndex] = "1";
                //            excel.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
                //        }
                //        catch (Exception ex)
                //        {

                //        }
                //        //excel.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
                //    }
                //}
                int rowCount = table.Rows.Count;

                int colCount = table.Columns.Count;

                object[,] dataArray = new object[rowCount, colCount];

                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        dataArray[i, j] = table.Rows[i][j].ToString();
                    }

                }
                try
                {
                    wks.get_Range("A4", wks.Cells[rowCount + 3, colCount]).Value2 = dataArray;
                }
                catch(Exception ee)
                {
                    if (!ee.Message.Equals("正在中止线程。"))
                    {
                        MessageBox.Show("Excel2003最多只支持65536行数据导出，请重新选择导出数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        wkb.Close(false, objOpt, objOpt);
                        excel.Quit();
                        if (this.IsHandleCreated)
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                this.Close();
                            }));
                    }
                    catch { }
                }

                y = rowIndex;
                var RowAll = wks.get_Range("A3", wks.Cells[rowCount + 3, colCount]);
                    //wks.get_Range(wks.Cells[x, 1], wks.Cells[y, table.Columns.Count]);
                RowAll.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                RowAll.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                RowAll.EntireColumn.AutoFit();//列宽自适应
                rowIndex = 4 + rowCount;
                #endregion

                #region[签名栏]
                if (table.Columns.Count >= 4)
                {
                    var RowAll4 = wks.get_Range(wks.Cells[rowIndex, 1], wks.Cells[rowIndex, (table.Columns.Count / 4) > 0 ? (table.Columns.Count / 4) : 1]);
                    RowAll4.Merge(0);
                    excel.Cells[rowIndex, 1] = model.Signcontent.Split(',')[0].ToString();
                    RowAll4.Font.Size = model.Signfontsize;
                    RowAll4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    var RowAll5 = wks.get_Range(wks.Cells[rowIndex, table.Columns.Count / 4 + 1], wks.Cells[rowIndex, (table.Columns.Count / 2) > 0 ? (table.Columns.Count / 2) : 1]);
                    RowAll5.Merge(0);
                    excel.Cells[rowIndex, table.Columns.Count / 4 + 1] = model.Signcontent.Split(',')[1].ToString();
                    RowAll5.Font.Size = model.Signfontsize;
                    RowAll5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    var RowAll6 = wks.get_Range(wks.Cells[rowIndex, table.Columns.Count / 2 + 1], wks.Cells[rowIndex, (table.Columns.Count * 3 / 4) > 0 ? (table.Columns.Count * 3 / 4) : 1]);
                    RowAll6.Merge(0);
                    excel.Cells[rowIndex, table.Columns.Count / 2 + 1] = model.Signcontent.Split(',')[2].ToString();
                    RowAll6.Font.Size = model.Signfontsize;
                    RowAll6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    var RowAll7 = wks.get_Range(wks.Cells[rowIndex, table.Columns.Count * 3 / 4 + 1], wks.Cells[rowIndex, table.Columns.Count]);
                    RowAll7.Merge(0);
                    excel.Cells[rowIndex, table.Columns.Count * 3 / 4 + 1] = model.Signcontent.Split(',')[3].ToString();
                    RowAll7.Font.Size = model.Signfontsize;
                    RowAll7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }
                else
                {
                    var RowAll8 = wks.get_Range(wks.Cells[rowIndex, 1], wks.Cells[rowIndex, table.Columns.Count]);
                    RowAll8.Merge(0);
                    string s = string.Empty;
                    foreach (string str in model.Signcontent.Split(','))
                    {
                        s += str + "  ";
                    }
                    excel.Cells[rowIndex, 1] = s;
                    RowAll8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }
                #endregion

                #region[获得父窗体句柄]
                System.IntPtr IntPart;
                IntPart = GetForegroundWindow();
                WindowWrapper ParentFrm = new WindowWrapper(IntPart);
                #endregion

                #region[导出对话框]
                string excelFileName = string.Empty;
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "*.xls|*.*";
                if (sf.ShowDialog(ParentFrm) == DialogResult.OK)
                {
                    try
                    {
                        excelFileName = sf.FileName;
                        wkb.SaveAs(excelFileName, objOpt, null, null, false, false, XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
                        wkb.Close(false, objOpt, objOpt);
                        excel.Quit();
                        excel = null;
                        if (this.IsHandleCreated)
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                label1.Text = "导出成功！";
                                label1.Left = (this.Width - label1.Width) / 2;
                                btn_Export.Text = "确定";
                                btn_Export.Click -= new EventHandler(btn_Export_Click);
                                btn_Export.Click += new EventHandler(btn_Export_Exit);
                                pictureBox2.Visible = false;
                                lblExport.Visible = false;
                            }));

                        //MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        wkb.Close(false, objOpt, objOpt);
                        excel.Quit();
                        if (this.IsHandleCreated)
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                this.Close();
                            }));
                    }
                }
                else
                {
                    wkb.Close(false, objOpt, objOpt);
                    excel.Quit();
                    if (this.IsHandleCreated)
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            this.Close();
                        }));
                }
                #endregion
            }
            catch (Exception ee)
            {
                if (!ee.Message.ToString().Equals("正在中止线程。"))
                    MessageBox.Show("Excel导出失败[" + ee.Message + "][" + ee.StackTrace + "]");
            }
           
        }

        /// <summary>
        /// 处理DataTable,把DataTable里面的true 或 false 换成文字
        /// </summary>
        /// <param name="dt">要处理的DataTable</param>
        /// <returns>处理后的DataTable</returns>
        private System.Data.DataTable ProcessDataTable(System.Data.DataTable dt)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    bool flag = false;
                    System.Data.DataTable dtClone = dt.Clone();
                    foreach (DataColumn dc in dtClone.Columns)
                    {
                        if (dc.DataType.Name.ToLower() == "boolean")
                        {
                            dc.DataType = typeof(string);
                            flag = true;

                        }
                    }
                    if (flag == true)
                    {
                        //复制数据到克隆的datatable里
                        try
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                dtClone.ImportRow(dr);
                            }
                        }
                        catch { }
                        dt = dtClone;
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dt.Rows[i][j].ToString().ToLower() == "true")
                            {
                                dt.Rows[i][j] = "是";
                            }
                            else if (dt.Rows[i][j].ToString().ToLower() == "false")
                            {
                                dt.Rows[i][j] = "";
                            }
                        }
                    }
                }

                return dt;
            }
            catch (Exception e)
            {
                if (!e.Message.Equals("正在中止线程。"))
                {
                    MessageBox.Show("发生错误,错误信息[" + e.Message + "]", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return null;
            }
        }

        private void btn_Export_Exit(object sender, EventArgs e)
        {
            this.Close();
        }
        //导出按钮
        private void btn_Export_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            lblExport.Visible = true;
            this.Controls.SetChildIndex(lblExport, 0);

            //开启导出线程
            myThread = new Thread(Export);
            myThread.IsBackground = true;
            myThread.SetApartmentState(ApartmentState.STA);
            myThread.Start();

        }

        public class WindowWrapper : System.Windows.Forms.IWin32Window
        {
            private System.IntPtr _hwnd;
            public WindowWrapper(System.IntPtr handle)
            {
                _hwnd = handle;
            }
            public System.IntPtr Handle
            {
                get { return _hwnd; }
            }
        }
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern System.IntPtr GetForegroundWindow();

        //关闭窗体时关闭线程
        private void ExportExcel_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (myThread != null)
                {
                    myThread.Abort();
                }
              
            }
            catch { }
            try
            {
                wkb.Close(false, Missing.Value, Missing.Value);
                excel.Quit();
            }
            catch { }
        }
    }
}
