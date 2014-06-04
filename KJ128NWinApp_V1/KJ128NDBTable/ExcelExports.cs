using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Tools.Excel;
using System.IO;
using System.Reflection;
namespace KJ128NDBTable
{
    public class ExcelExports
    {
        ///// <summary>
        ///// 把DataGridView到处到Excel中
        ///// </summary>
        ///// <param name="gridView">目标DataGridView</param>
        ///// <param name="fileName">保存文件名称</param>
        ///// <param name="isShowExcle">是否显示Excel界面</param>
        ///// <returns>导出是否成功</returns>
        //public static bool ExportForDataGridview(DataGridView gridView,string fileName,bool isShowExcle)
        //{
            
        //    //建立Ｅｘｃｅｌ对象
        //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office..Excel.Application();
        //    try
        //    {
        //        if (app == null)
        //        {
        //            return false;
        //        }
        //        app.Visible = isShowExcle;
        //        Workbooks workbooks = app.Workbooks;
        //        _Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        //        Sheets sheets = workbook.Worksheets;
        //        _Worksheet worksheet = (_Worksheet)sheets.get_Item(1);
        //        if (worksheet == null)
        //        {
        //            return false;
        //        }
        //        string sLen = "";
        //        //取得最后一列列名
        //        char H=(char)(64+gridView.ColumnCount /26 );
        //        char L = (char)(64 + gridView.ColumnCount % 26);
        //        if (gridView.ColumnCount < 26)
        //        {
        //            sLen = L.ToString();
        //        }
        //        else
        //        {
        //            sLen = H.ToString() + L.ToString();
        //        }


        //        //标题
        //        string sTmp = sLen + "1";
        //        Range ranCaption = worksheet.get_Range(sTmp, "A1");
        //        string[] asCaption = new string[gridView.ColumnCount];
        //        for (int i = 0; i < gridView.ColumnCount; i++)
        //        {
        //            asCaption[i] = gridView.Columns[i].HeaderText;
        //        }
        //        ranCaption.Value2 = asCaption;

        //        //数据
        //        object[] obj = new object[gridView.Columns.Count];
        //        for (int r = 0; r < gridView.RowCount-1; r++)
        //        {
        //            for (int l = 0; l < gridView.Columns.Count; l++)
        //            {
        //                if (gridView[l, r].ValueType==typeof(DateTime))
        //                {
        //                    obj[l] = gridView[l, r].Value.ToString();
        //                }
        //                else
        //                {
        //                    obj[l] = gridView[l, r].Value;
        //                }
        //            }
        //            string cell1 = sLen + ((int)(r + 2)).ToString();
        //            string cell2="A"+((int)(r+2)).ToString();
        //            Range ran = worksheet.get_Range(cell1, cell2);
        //            ran.Value2 = obj;
        //        }
        //        //保存
        //        workbook.SaveCopyAs(fileName);
        //        workbook.Saved = true;
        //    }
        //    finally
        //    {
        //        //关闭
        //        app.UserControl = false;
        //        app.Quit();
        //    }
        //    return true;

        //}

        /// <summary>
        /// 将DataGridView中的内容导入Excel
        /// </summary>
        /// <param name="dataGridview1">要导入的DataGridView</param>
        public static void ExportDataGridViewToExcel(DataGridView dataGridview1)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl   files   (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";

            saveFileDialog.ShowDialog();

            Stream myStream;
            if (saveFileDialog.FileName == "")
            {
                return;
            }
            try
            {
                myStream = saveFileDialog.OpenFile();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                int i_Temp = 0;
                //写标题     
                for (int i = 0; i < dataGridview1.ColumnCount; i++)
                {
                    if (!dataGridview1.Columns[i].Visible || dataGridview1.Columns[i].HeaderText.Equals("配置") || dataGridview1.Columns[i].HeaderText.Equals("索引编号") || dataGridview1.Columns[i].HeaderText.Equals("职务编号") || dataGridview1.Columns[i].HeaderText.Equals("证书类别") || dataGridview1.Columns[i].HeaderText.Equals("工种编号") || dataGridview1.Columns[i].HeaderText.Equals("操作") || dataGridview1.Columns[i].HeaderText.Equals("修改") || dataGridview1.Columns[i].HeaderText.Equals("删除") || dataGridview1.Columns[i].HeaderText.Equals("员工照片"))
                    {
                        continue;
                    }

                    if (i_Temp !=0)
                    {
                        str += "\t";
                    }
                    i_Temp++;
                    str += dataGridview1.Columns[i].HeaderText;
                }

                sw.WriteLine(str);
                //写内容   
                for (int j = 0; j < dataGridview1.Rows.Count; j++)
                {
                    string tempStr = "";
                    i_Temp = 0;
                    for (int k = 0; k < dataGridview1.Columns.Count; k++)
                    {
                        if (!dataGridview1.Columns[k].Visible || dataGridview1.Columns[k].HeaderText.Equals("配置") || dataGridview1.Columns[k].HeaderText.Equals("索引编号") || dataGridview1.Columns[k].HeaderText.Equals("职务编号") || dataGridview1.Columns[k].HeaderText.Equals("证书类别") || dataGridview1.Columns[k].HeaderText.Equals("工种编号") || dataGridview1.Columns[k].HeaderText.Equals("操作") || dataGridview1.Columns[k].HeaderText.Equals("修改") || dataGridview1.Columns[k].HeaderText.Equals("删除") || dataGridview1.Columns[k].HeaderText.Equals("员工照片"))
                        {
                            continue;
                        }

                        if (i_Temp != 0)
                        {
                            tempStr += "\t";
                        }
                        i_Temp++;


                        //将 True False 转换成 是 否
                        if (dataGridview1.Rows[j].Cells[k].Value.ToString().ToLower() == "true" || dataGridview1.Rows[j].Cells[k].Value.ToString().ToLower() == "false")
                        {
                            //tempStr += dataGridview1.Rows[j].Cells[k].Value.ToString();
                            if (dataGridview1.Rows[j].Cells[k].Value.ToString().ToLower() == "true")
                            {
                                tempStr += "是";
                            }
                            else
                            {
                                tempStr += "否";
                            }
                        }
                        else
                        {
                            tempStr += dataGridview1.Rows[j].Cells[k].Value.ToString();
                        }
                    }
                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }   
    
    }
}
