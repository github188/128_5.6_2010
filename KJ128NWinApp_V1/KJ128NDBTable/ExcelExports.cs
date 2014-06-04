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
        ///// ��DataGridView������Excel��
        ///// </summary>
        ///// <param name="gridView">Ŀ��DataGridView</param>
        ///// <param name="fileName">�����ļ�����</param>
        ///// <param name="isShowExcle">�Ƿ���ʾExcel����</param>
        ///// <returns>�����Ƿ�ɹ�</returns>
        //public static bool ExportForDataGridview(DataGridView gridView,string fileName,bool isShowExcle)
        //{
            
        //    //�����ţ��������
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
        //        //ȡ�����һ������
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


        //        //����
        //        string sTmp = sLen + "1";
        //        Range ranCaption = worksheet.get_Range(sTmp, "A1");
        //        string[] asCaption = new string[gridView.ColumnCount];
        //        for (int i = 0; i < gridView.ColumnCount; i++)
        //        {
        //            asCaption[i] = gridView.Columns[i].HeaderText;
        //        }
        //        ranCaption.Value2 = asCaption;

        //        //����
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
        //        //����
        //        workbook.SaveCopyAs(fileName);
        //        workbook.Saved = true;
        //    }
        //    finally
        //    {
        //        //�ر�
        //        app.UserControl = false;
        //        app.Quit();
        //    }
        //    return true;

        //}

        /// <summary>
        /// ��DataGridView�е����ݵ���Excel
        /// </summary>
        /// <param name="dataGridview1">Ҫ�����DataGridView</param>
        public static void ExportDataGridViewToExcel(DataGridView dataGridview1)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl   files   (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "����Excel�ļ���";

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
                //д����     
                for (int i = 0; i < dataGridview1.ColumnCount; i++)
                {
                    if (!dataGridview1.Columns[i].Visible || dataGridview1.Columns[i].HeaderText.Equals("����") || dataGridview1.Columns[i].HeaderText.Equals("�������") || dataGridview1.Columns[i].HeaderText.Equals("ְ����") || dataGridview1.Columns[i].HeaderText.Equals("֤�����") || dataGridview1.Columns[i].HeaderText.Equals("���ֱ��") || dataGridview1.Columns[i].HeaderText.Equals("����") || dataGridview1.Columns[i].HeaderText.Equals("�޸�") || dataGridview1.Columns[i].HeaderText.Equals("ɾ��") || dataGridview1.Columns[i].HeaderText.Equals("Ա����Ƭ"))
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
                //д����   
                for (int j = 0; j < dataGridview1.Rows.Count; j++)
                {
                    string tempStr = "";
                    i_Temp = 0;
                    for (int k = 0; k < dataGridview1.Columns.Count; k++)
                    {
                        if (!dataGridview1.Columns[k].Visible || dataGridview1.Columns[k].HeaderText.Equals("����") || dataGridview1.Columns[k].HeaderText.Equals("�������") || dataGridview1.Columns[k].HeaderText.Equals("ְ����") || dataGridview1.Columns[k].HeaderText.Equals("֤�����") || dataGridview1.Columns[k].HeaderText.Equals("���ֱ��") || dataGridview1.Columns[k].HeaderText.Equals("����") || dataGridview1.Columns[k].HeaderText.Equals("�޸�") || dataGridview1.Columns[k].HeaderText.Equals("ɾ��") || dataGridview1.Columns[k].HeaderText.Equals("Ա����Ƭ"))
                        {
                            continue;
                        }

                        if (i_Temp != 0)
                        {
                            tempStr += "\t";
                        }
                        i_Temp++;


                        //�� True False ת���� �� ��
                        if (dataGridview1.Rows[j].Cells[k].Value.ToString().ToLower() == "true" || dataGridview1.Rows[j].Cells[k].Value.ToString().ToLower() == "false")
                        {
                            //tempStr += dataGridview1.Rows[j].Cells[k].Value.ToString();
                            if (dataGridview1.Rows[j].Cells[k].Value.ToString().ToLower() == "true")
                            {
                                tempStr += "��";
                            }
                            else
                            {
                                tempStr += "��";
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
